using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Mvc;
using QuanLyMonHocDoAn.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
namespace QuanLyMonHocDoAn.Controllers
{
    public class GiangVienController : Controller
    {
        
        //private readonly QldetainckhContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QldetainckhContext _context;

        public GiangVienController(QldetainckhContext context, IWebHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        //QldetainckhContext db = new QldetainckhContext();
        
        // GET: GiangVien
        public ActionResult Index()
        {
            //string jsoncart = HttpContext.Session.GetString("GiangVien");
            //var ac = JsonSerializer.Deserialize<Giangvien>(jsoncart);
            //ViewBag.account = ac.TenGiangVien;
            Giangvien gv = LayGiangVien();
            ViewBag.account = gv.TenGiangVien;
            var tb = _context.Thongbaos.OrderByDescending(s => s.Id).ToList().Take(10);
            return View(tb);
        }
        public void ThongBaoToDs(int id)
        {
            if (DataProvider.Instance.ExcuteNonQuery("UPDATE ThongBaoChamLai SET IsCheck = 1 WHERE Id=" + id) > 0)
            {
                Response.Redirect("~/GiangVien/DsDeCuong");
            }

        }
        public ActionResult PartialTBChamLai()
        {
            //var tb = GiangVienDAO.Instance.DsThongBaoChamLai(LayGiangVien().MaGiangVien).OrderByDescending(n => n.Id);
            return PartialView();
        }




        //public ActionResult PartialMenuGiangVien()
        //{
        //    return PartialView();
        //}
        public Giangvien LayGiangVien()
        {
            var svJson = HttpContext.Session.GetString("GiangVien");
            if (svJson != null)
            {
                var gv = JsonSerializer.Deserialize<Giangvien>(svJson);
                return gv;
            }
            return null;
        }
        [HttpGet]
        public ActionResult DsDeCuong(string strLoc1, string strLoc2)
        {
            Giangvien gv = LayGiangVien();
            ViewBag.account = gv.TenGiangVien;
            List<DataChamDiemData> listDangKy = DsChamDiem.Instance.ListDsDeCuong(gv.MaGiangVien, gv.MaCt);
            if (string.IsNullOrEmpty(strLoc1) && string.IsNullOrEmpty(strLoc2))
            {
                return View(listDangKy);
            }
            else if (string.IsNullOrEmpty(strLoc1) || string.IsNullOrEmpty(strLoc2))
            {

                return View(listDangKy);
            }
            else
            {
                List<DataChamDiemData> listDangKyloc = DsChamDiem.Instance.ListLocDeTai(gv.MaGiangVien, gv.MaCt, DateTime.Parse(strLoc1), DateTime.Parse(strLoc2));
                return View(listDangKyloc);
            }
        }
        [HttpGet]
        public ActionResult DsDeTaiNT(string strLoc1, string strLoc2)
        {
            Giangvien gv = LayGiangVien();
            ViewBag.account = gv.TenGiangVien;
            List<DTChamDiemDT> listDangKy = DsChamDiemDT.Instance.ListDsDeTai(gv.MaGiangVien, gv.MaCt);
            if (string.IsNullOrEmpty(strLoc1) && string.IsNullOrEmpty(strLoc2))
            {
                return View(listDangKy);
            }
            else if (string.IsNullOrEmpty(strLoc1) || string.IsNullOrEmpty(strLoc2))
            {

                return View(listDangKy);
            }
            else
            {
                List<DTChamDiemDT> listDangKyloc = DsChamDiemDT.Instance.ListLocDeTai(gv.MaGiangVien, gv.MaCt, DateTime.Parse(strLoc1), DateTime.Parse(strLoc2));
                return View(listDangKyloc);
            }
        }
        [HttpPost]
        public ActionResult GetMinhChung(FormCollection f, IFormFile fFileUpload)
        {
            Giangvien gv = LayGiangVien();
            var bb = _context.Bienbanchamdecuongs
                      .Where(s => s.IdDangKy == int.Parse(f["id"]))
                      .Where(s => s.MaGiangVien == gv.MaGiangVien)
                      .Count();

            if (bb == 0)
            {
                return RedirectToAction("DsDeCuong", "GiangVien");
            }
            else
            {
                var md = _context.Bienbanchamdecuongs
                          .Where(s => s.IdDangKy == int.Parse(f["id"]))
                          .Where(s => s.MaGiangVien == gv.MaGiangVien)
                          .SingleOrDefault();

                // Kiểm tra xem tệp đã được chọn chưa
                if (fFileUpload != null && fFileUpload.Length > 0)
                {
                    // Lấy tên file
                    var sFileName = Path.GetFileName(fFileUpload.FileName);

                    // Lấy đường dẫn thư mục lưu file
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "Theme/Luufile", sFileName);

                    // Lưu tệp vào thư mục
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        fFileUpload.CopyTo(stream);
                    }

                    // Lưu tên tệp vào cơ sở dữ liệu
                    md.MinhChung = sFileName;
                    _context.SaveChanges();
                }

                return RedirectToAction("DsDeCuong", "GiangVien");
            }
        }

        [HttpPost]
        public JsonResult BienBanChamDeCuong(int iddt, int diem, string danhgia)
        {
            var count = _context.Bienbanchamdecuongs.Count(s => s.IdDangKy == iddt);
            Giangvien gv = LayGiangVien(); 

            if (count < 3)
            {
                var dt = _context.Dangkies.SingleOrDefault(n => n.IddangKy == iddt);
                Bienbanchamdecuong bb = new Bienbanchamdecuong();
                bb.Diem = diem;
                bb.IdDangKy = iddt;
                bb.MaHoiDong = dt.MaHoiDong;
                bb.MaGiangVien = gv.MaGiangVien;
                bb.DanhGia = danhgia;
                _context.Bienbanchamdecuongs.Add(bb);
                _context.SaveChanges();

                var dem = _context.Bienbanchamdecuongs.Count(s => s.IdDangKy == iddt);

                if (dem == 3)
                {
                    var tb = (float)_context.Bienbanchamdecuongs
                        .Where(s => s.IdDangKy == iddt)
                        .Sum(s => s.Diem) / 3;

                    if (tb >= 5)
                    {
                        var dk = _context.Dangkies.SingleOrDefault(s => s.IddangKy == iddt);
                        var sv = _context.Sinhviens.SingleOrDefault(s => s.MaSoSinhVien == dk.MaSoSinhVien);
                        dk.TrangThai = 3;

                        Detai detai = new Detai();
                        detai.TenDeTai = dk.TenDeTai;
                        detai.GhiChu = dk.GhiChu;
                        detai.NgayThucHien = dk.NgayDangKy;
                        detai.MaNganh = sv.MaNganh;
                        detai.MaHoiDong = 4;
                        detai.NgayThucHien = dk.NgayDangKy;
                        detai.MaTrangThai = 3;
                        detai.MaSoSinhVien = dk.MaNhom;
                        detai.MaGiangVien = dk.MaGiangVien;
                        detai.MaNhom = dk.MaNhom;

                        _context.Detais.Add(detai);
                        _context.SaveChanges();
                    }
                    else
                    {
                        var dk = _context.Dangkies.SingleOrDefault(s => s.IddangKy == iddt);
                        dk.TrangThai = 6;
                        _context.SaveChanges();
                    }
                }

                return Json(new { code = 200, msg = "Lưu điểm thành công" });
            }
            else
            {
                return Json(new { code = 500, msg = "Khó quá! Bó tay" });
            }
        }

        [HttpPost]
        public JsonResult BienBanChamDeTai(int iddt, int diem, string danhgia)
        {
            var count = _context.Bienbannghiemthus.Where(s => s.MaDeTai == iddt).Count();
            if (count < 3)
            {
                Giangvien gv = LayGiangVien();
                var dt = _context.Detais.SingleOrDefault(n => n.MaDeTai == iddt);
                Bienbannghiemthu bb = new Bienbannghiemthu();
                bb.Diem = diem;
                bb.MaDeTai = iddt;
                bb.MaHoiDong = dt.MaHoiDong;
                bb.MaGiangVien = gv.MaGiangVien;
                bb.NhanXet = danhgia;
                _context.Bienbannghiemthus.Add(bb);
                _context.SaveChanges();

                var dem = _context.Bienbannghiemthus.Where(s => s.MaDeTai == iddt).Count();
                if (dem == 3)
                {
                    var tb = (float)_context.Bienbannghiemthus.Where(s => s.MaDeTai == iddt).Sum(s => s.Diem) / 3;
                    if (tb >= 5)
                    {
                        var dk = _context.Detais.Where(s => s.MaDeTai == iddt).SingleOrDefault();
                        dk.MaTrangThai = 5;
                        dk.KetQua = "Đạt";
                        dk.KinhPhiDuKien = 4000000;
                    }
                    else
                    {
                        var dk = _context.Detais.Where(s => s.MaDeTai == iddt).SingleOrDefault();
                        dk.MaTrangThai = 5;
                        dk.KetQua = "Không Đạt";
                        dk.KinhPhiDuKien = 4000000;
                    }
                    _context.SaveChanges();
                }
                return Json(new { code = 200, msg = "Lưu điểm thành công" });
            }
            else
            {
                return Json(new { code = 500, msg = "Khó quá! Bó tay" });
            }
        }



        [HttpGet]
        public JsonResult TTDeTai(int idDT)
        {
            try
            {
                var list = (from dk in _context.Dangkies
                            where dk.IddangKy == idDT
                            select new
                            {
                                a = dk.TenDeTai,
                                b = dk.GhiChu,
                                c = dk.LinkDeCuong
                            }).SingleOrDefault();
                
                return Json(new { code = 200, da = list, msg = "Lay thong tin thanh cong."});
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Khó quá! Bó tay" });
            }
        }

        [HttpGet]
        public JsonResult TTDeTaiNT(int idDT)
        {
            try
            {
                var list = (from dk in _context.Detais
                            where dk.MaDeTai == idDT
                            select new
                            {
                                TenDeTai = dk.TenDeTai,
                                GhiChu = dk.GhiChu,
                                LinkDeTai = dk.LinkDeTai
                            }).SingleOrDefault();
                return Json(new { code = 200, dt= list, msg = "Lấy thông tin thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Khó quá! Bó tay" });
            }
        }
        public FileResult GetFile(FormCollection f, [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            string ReportURL = f["getfile"];
            string output = Path.Combine(hostingEnvironment.WebRootPath, "Theme/Luufile/", ReportURL);
            return File(output, "application/pdf");
        }
        //public ActionResult PartialNavGV()
        //{
        //    Giangvien gv = LayGiangVien();
        //    ViewBag.account = gv.TenGiangVien;
        //    return PartialView();
        //}
        [HttpGet]
        public ActionResult ProfileGV()
        {
            Giangvien gv = LayGiangVien();
            var pfgv = _context.Giangviens.SingleOrDefault(n => n.MaGiangVien == gv.MaGiangVien);
            return View(pfgv);
        }
        [HttpPost]
        public ActionResult ProfileGV(FormCollection f)
        {
            Giangvien gv = LayGiangVien();
            var pfgv = _context.Giangviens.SingleOrDefault(n => n.MaGiangVien == gv.MaGiangVien);
            //pfgv.SDT = f["sSDT"];
            //pfgv.TKNganHang = f["sTKNH"];
            //pfgv.CCCD = f["sCCCD"];
            //pfgv.DiaChi = f["sDiaChi"];
            //pfgv.ChiNhanhNganHang = f["sCNNH"];
            //db.SubmitChanges();
            return View(pfgv);

        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(int iddk, List<IFormFile> files, [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            if (files.Count > 0)
            {
                try
                {
                    Giangvien gv = LayGiangVien();
                    int count = _context.Bienbanchamdecuongs.Where(n => n.IdDangKy == iddk && n.MaGiangVien == gv.MaGiangVien).Count();
                    if (count == 0)
                    {
                        return Json(new { code = 500, msg = "Khó quá! Bó tay" });
                    }
                    else
                    {
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "Theme/Luufile", fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                var bb = _context.Bienbanchamdecuongs.Where(s => s.IdDangKy == iddk).SingleOrDefault();
                                bb.MinhChung = fileName;
                                _context.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
                            }
                        }

                        return Json(new { code = 200, msg = "thanh cong" });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { code = 500, msg = "Error occurred. Error details: " + ex.Message });
                }
            }
            else
            {
                return Json(new { code = 500, msg = "No files selected." });
            }
        }
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TaiKhoan");
            HttpContext.Session.Remove("GiangVien");
            return RedirectToAction("Login", "User"); // Chuyển hướng người dùng đến trang đăng nhập sau khi đăng xuất
        }

    }
}

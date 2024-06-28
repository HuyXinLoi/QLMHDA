using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLyMonHocDoAn.Models;
using System.Reflection;
using System.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using QuanLyMonHocDoAn.Repositories;

namespace QuanLyMonHocDoAn.Controllers
{
    public class StudentDBController : Controller
    {
        private readonly QldetainckhContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IThongBaoRepository _thongbaorepository;
        public StudentDBController(QldetainckhContext _db, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, IThongBaoRepository thongbaorepository)
        {
            db = _db;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _thongbaorepository = thongbaorepository;
        }

        // GET: StudentDB

        public ActionResult DSDanhGiaDC()
        {
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            Sinhvien sv = LaySinhVien();
            var dv = (from dk in db.Dangkies
                      join gv in db.Giangviens on dk.MaGiangVien equals gv.MaGiangVien
                      where dk.TrangThai >= 2 && dk.MaSoSinhVien == sv.MaSoSinhVien
                      select new
                      {
                          dk.TenDeTai,
                          dk.IddangKy,
                          dk.MaGiangVien,
                          gv.TenGiangVien,
                          dk.GhiChu,
                      }
                      ).ToList();
            List<CTChamDiemDC> ds = new List<CTChamDiemDC>();
            foreach (var item in dv)
            {
                CTChamDiemDC dt = new CTChamDiemDC();
                dt.TenDeTai = item.TenDeTai;
                dt.IDDC = item.IddangKy;
                dt.TenGiangVien = item.TenGiangVien;
                dt.GhiChu = item.GhiChu;
                var ct = (from bb in db.Bienbanchamdecuongs
                          join gv in db.Giangviens on bb.MaGiangVien equals gv.MaGiangVien
                          where bb.IdDangKy == dt.IDDC
                          select new
                          {
                              bb.IdDangKy,
                              gv.TenGiangVien,
                              bb.DanhGia,
                              bb.Diem,
                          }).ToList();
                foreach (var t in ct)
                {
                    CTBienBan ctbb = new CTBienBan();
                    ctbb.IDDC = (int)t.IdDangKy;
                    ctbb.TenGiangVien = t.TenGiangVien;
                    ctbb.DanhGia = t.DanhGia;
                    ctbb.Diem = (float)t.Diem;
                    dt.DSBienBan.Add(ctbb);
                }
                ds.Add(dt);
            }

            return View(ds);
        }
        public ActionResult DSDanhGiaDT()
        {
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            Sinhvien sv = LaySinhVien();
            var dv = (from dt in db.Detais
                      join gv in db.Giangviens on dt.MaGiangVien equals gv.MaGiangVien
                      where dt.MaTrangThai >= 5 && dt.MaSoSinhVien == sv.MaSoSinhVien
                      select new
                      {
                          dt.TenDeTai,
                          dt.MaDeTai,
                          dt.MaGiangVien,
                          gv.TenGiangVien,
                          dt.GhiChu,
                      }
                      ).ToList();
            List<CTChamDiemDC> ds = new List<CTChamDiemDC>();
            foreach (var item in dv)
            {
                CTChamDiemDC dt = new CTChamDiemDC();
                dt.TenDeTai = item.TenDeTai;
                dt.IDDC = item.MaDeTai;
                dt.TenGiangVien = item.TenGiangVien;
                dt.GhiChu = item.GhiChu;
                var ct = (from bb in db.Bienbannghiemthus
                          join gv in db.Giangviens on bb.MaGiangVien equals gv.MaGiangVien
                          where bb.MaDeTai == dt.IDDC
                          select new
                          {
                              bb.MaDeTai,
                              gv.TenGiangVien,
                              bb.NhanXet,
                              bb.Diem,
                          }).ToList();
                foreach (var t in ct)
                {
                    CTBienBan ctbb = new CTBienBan();
                    ctbb.IDDC = (int)t.MaDeTai;
                    ctbb.TenGiangVien = t.TenGiangVien;
                    ctbb.DanhGia = t.NhanXet;
                    ctbb.Diem = (float)t.Diem;
                    dt.DSBienBan.Add(ctbb);
                }
                ds.Add(dt);
            }

            return View(ds);
        }
        [HttpGet]
        public JsonResult GetChamDiem(int iddk)
        {

            try
            {

                var dv = (from bb in db.Bienbanchamdecuongs
                          join gv in db.Giangviens on bb.MaGiangVien equals gv.MaGiangVien
                          where bb.IdDangKy == iddk
                          select new
                          {
                              MaGV = bb.MaGiangVien,
                              TenGV = gv.TenGiangVien,
                              Diem = bb.Diem,
                              DanhGia = bb.DanhGia,
                          }
                ).ToList();
                return Json(new { code = 200, cd = dv, msg = "Thanh cong" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm that bai " + ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> StudentDB()
        {
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            var tb = await db.Thongbaos.OrderByDescending(s => s.Id).ToListAsync();
            Sinhvien sv = LaySinhVien();
            var lst = db.Dangkies.Where(n => n.MaSoSinhVien == sv.MaSoSinhVien /*&& n.KetQua == false*/).Count();
            ViewBag.listdtdk = lst;
            //var tb = db.Thongbaos.OrderByDescending(s => s.Id).ToList().Take(10);
            return PartialView(tb);
        }
        public Sinhvien LaySinhVien()
        {
            var svJson = HttpContext.Session.GetString("SinhVien");
            if (svJson != null)
            {
                var sv = JsonSerializer.Deserialize<Sinhvien>(svJson);
                return sv;
            }
            return null;
        }

        public ActionResult DetailTB(int id)
        {
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            var tb = db.Thongbaos.Where(a => a.Id == id).Single();
            return View(tb);
        }
        public ActionResult PartialNav()
        {
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            return PartialView();
        }
        public ActionResult PartialMenu()
        {
            return PartialView();
        }
        public ActionResult PartialMenuKhoa()
        {
            var kh = db.Khoas.OrderByDescending(a => a.MaKhoa).ToList();
            return PartialView(kh);
        }
        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TaiKhoan");
            HttpContext.Session.Remove("SinhVien");
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            Sinhvien ad = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            ViewBag.MSSV = ad.MaSoSinhVien;
            ViewBag.MaGiangVien = new SelectList(db.Giangviens.Where(n => n.MaSoGiangVien.Contains("GV")).ToList().OrderBy(n => n.TenGiangVien), "MaGiangVien", "TenGiangVien");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(Dangky dk, IFormCollection f, IFormFile fFileUpload)
        {
            Sinhvien ad = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            ViewBag.MSSV = ad.MaSoSinhVien;
            ViewBag.MaGiangVien = new SelectList(db.Giangviens.Where(n => n.MaSoGiangVien.Contains("GV")).ToList().OrderBy(n => n.TenGiangVien), "MaGiangVien", "TenGiangVien");
            if (String.IsNullOrEmpty(f["sTenDT"]))
            {
                ViewBag.err1 = " Vui lòng nhập tên đề tài.";
            }
            if (String.IsNullOrEmpty(f["sGhichu"]))
            {
                ViewBag.err3 = " Vui lòng nhập ghi chú.";
            }
            //if (!ModelState.IsValid)
            //{
            Sinhvien sv = new Sinhvien();
            var svJson = HttpContext.Session.GetString("SinhVien");
            sv = JsonSerializer.Deserialize<Sinhvien>(svJson);
            dk.TenDeTai = f["sTenDT"];
            dk.GhiChu = f["sGhichu"];
            dk.MaSoSinhVien = f["sMasv"];
            dk.LinkDeCuong = "Chưa Nộp Đề Cương";
            dk.MaNhom = sv.MaSoSinhVien;
            dk.KetQua = false;
            dk.TrangThai = 1;
            dk.MaHoiDong = 1;
            dk.NgayDangKy = DateTime.Now;
            dk.MaGiangVien = int.Parse(f["MaGiangVien"]);
            db.Dangkies.Add(dk);
            db.SaveChanges();
            return RedirectToAction("TrangThaiDeTai", "StudentDB");
            //}
            //return View();
        }
        public IActionResult PartialFormNhom()
        {
            Sinhvien sv = LaySinhVien();
            var lsNhom = db.Chitietnhoms.Where(n => n.MaNhom == sv.MaSoSinhVien && n.TrangThai == 1).OrderBy(n => n.IdCtnhom).ToList();
            return PartialView(lsNhom);
        }
        [HttpPost]
        public JsonResult AddNhom(string strNhom)
        {
            Sinhvien sv = LaySinhVien();
            string id = sv.MaSoSinhVien;
            try
            {
                string[] listTV = strNhom.Split('|');

                for (int i = 4; i < listTV.Length - 1; i = i + 2)
                {
                    string tensv = listTV[i];
                    string mssv = listTV[i + 1];
                    Chitietnhom tempCT = db.Chitietnhoms.SingleOrDefault(n => n.MaSoSinhVien == mssv && n.TrangThai == 1);
                    if (tempCT == null || tempCT.ToString() == "")
                    {
                        Chitietnhom tempChiTiet = new Chitietnhom();
                        tempChiTiet.MaNhom = sv.MaSoSinhVien;
                        tempChiTiet.HoTen = tensv;
                        tempChiTiet.MaSoSinhVien = mssv;
                        tempChiTiet.TrangThai = 1;

                        db.Chitietnhoms.Add(tempChiTiet);
                        db.SaveChanges();
                    }
                }
                return Json(new { code = 200, cd = id, msg = listTV[2] });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm thất bại " + ex.Message });
            }
        }

        public async Task<IActionResult> PartialModalNhom()
        {
            Sinhvien sv = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("SinhVien");
            var ac = JsonSerializer.Deserialize<Sinhvien>(jsoncart);
            ViewBag.account = ac;
            ViewBag.MSSV = ac.MaSoSinhVien;
            ViewBag.HOTEN = ac.HoTen;
            var lsNhom = await db.Chitietnhoms.Where(n => n.MaNhom == sv.MaSoSinhVien && n.TrangThai == 1).OrderBy(n => n.IdCtnhom).ToListAsync();
            //var lsNhom = await db.Chitietnhoms.Where(n => n.MaNhom == sv.MaSoSinhVien && n.TrangThai == 1).OrderBy(n => n.IdCtnhom).ToListAsync();
            return PartialView(lsNhom);

        }
        public async Task<IActionResult> PartialDangKy()
        {
            Sinhvien sv = LaySinhVien();
            var lst = await db.Dangkies.Where(n => n.MaNhom == sv.MaSoSinhVien && n.KetQua == false).ToListAsync();
            var list = new List<Dangky>();
            if (lst != null)
            {
                list = lst;
            }
            return PartialView(lst);
        }

        private static void ConvertWordToSpecifiedFormat(object input, object output, object format)
        {
            Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application();
            application.Visible = false;
            object missing = Missing.Value;
            object isVisible = true;
            object readOnly = false;
            Microsoft.Office.Interop.Word._Document document = application.Documents.Open(ref input, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);

            document.Activate();
            document.SaveAs(ref output, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            application.Quit(ref missing, ref missing, ref missing);
        }
        [HttpGet]
        public ActionResult ProfileSV()
        {
            Sinhvien sv = LaySinhVien();
            var pfsv = db.Sinhviens.SingleOrDefault(n => n.MaSinhVien == sv.MaSinhVien);
            return View(pfsv);
        }
        [HttpPost]
        public ActionResult ProfileSV(FormCollection f)
        {
            Sinhvien sv = LaySinhVien();
            var pfsv = db.Sinhviens.SingleOrDefault(n => n.MaSinhVien == sv.MaSinhVien);
            pfsv.Sdt = f["sSDT"];
            pfsv.TknganHang = f["sTKNH"];
            pfsv.Cccd = f["sCCCD"];
            pfsv.DiaChi = f["sDiaChi"];
            pfsv.ChiNhanhNganHang = f["sCNNH"];
            db.SaveChanges();
            return View(pfsv);

        }
        [HttpPost]
        public async Task<ActionResult> UploadFiles(List<IFormFile> files)
        {

            // Checking no of files injected in Request object  
            if (files.Count > 0)
            {

                try
                {
                    Sinhvien sv = LaySinhVien();
                    //  Get all files from Request object  
                    foreach (var file in files)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  
                        string fname, sfile;

                        // Checking for Internet Explorer  
                        // Kiểm tra xem User-Agent có chứa chuỗi "Trident" hoặc "MSIE" không
                        if (Request.Headers["User-Agent"].ToString().Contains("Trident") || Request.Headers["User-Agent"].ToString().Contains("MSIE"))
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
                        var dt = db.Dangkies.Where(s => s.MaSoSinhVien == sv.MaSoSinhVien && s.KetQua == false).SingleOrDefault();
                        string[] listname = fname.Split('.');
                        if (dt.KetQua == false)
                        {
                            dt.LinkDeCuong = fileNameWithoutExtension + ".pdf";
                            //ThongBaoChamLai tb = new ThongBaoChamLai();
                            //tb.Thongbao = "Thông Báo Chấm Lại";
                            //tb.MaHoiDong = dt.MaHoiDong;
                            //tb.IdDangKy = dt.IDDangKy;
                            //tb.IsCheck = false;
                            //tb.DateModified = DateTime.Now;
                            //db.ThongBaoChamLais.InsertOnSubmit(tb);
                            db.SaveChanges();
                            if (dt.TrangThai == 6)
                            {
                                var df1 = db.Bienbanchamdecuongs.Where(n => n.IdDangKy == dt.IddangKy).ToList();
                                if (df1.Count > 0)
                                {
                                    db.Bienbanchamdecuongs.RemoveRange(df1);
                                    db.SaveChanges();
                                }
                                var gf = db.ThongBaoChamLais.Where(n => n.IdDangKy == dt.IddangKy).ToList();
                                if (gf.Count() < 1)
                                {
                                    TrangThaiViewModel.Instance.InsertThongBaoChamDiem("Thông Báo Chấm Lại", (int)dt.MaHoiDong, dt.IddangKy, false, DateTime.Now);
                                }
                                else if (gf.Count() >= 1)
                                {
                                    DataProvider.Instance.ExcuteNonQuery("DELETE FROM ThongBaoChamLai WHERE IdDangKy =" + dt.IddangKy);
                                    TrangThaiViewModel.Instance.InsertThongBaoChamDiem("Thông Báo Chấm Lại", (int)dt.MaHoiDong, dt.IddangKy, false, DateTime.Now);
                                }
                            }
                        }
                        // Lấy đường dẫn tới thư mục ~/wwwroot/Theme/Luufile
                        string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "Theme", "Luufile");
                        // Kiểm tra xem thư mục tồn tại chưa, nếu chưa thì tạo mới
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        // Đường dẫn đầy đủ tới file
                        string filePath = Path.Combine(folderPath, fname);
                        // Lưu file vào thư mục
                        if (file.Length > 0)
                        {
                            string fileName = Path.GetFileName(file.FileName);
                            filePath = Path.Combine(folderPath, fname);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }

                        string input = filePath;
                        if (listname[listname.Length - 1] != "pdf")
                        {
                            string output = Path.Combine(folderPath, fileNameWithoutExtension + ".pdf");
                            ConvertWordToSpecifiedFormat(input, output, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                        }

                        // Get the complete folder path and store the file inside it.  
                    }
                    // Returns message that successfully uploaded


                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        //StudentDetai
        public ActionResult _PartialProgressBar()
        {
            Sinhvien sv = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            ViewBag.MSSV = sv.MaSoSinhVien;
            return PartialView();
        }
        public ActionResult TrangThaiDeTai()
        {
            Sinhvien sv = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            ViewBag.MSSV = sv.MaSoSinhVien;
            List<DTDangKy> listDangKy = DangKyDAO.Instance.ListDangKy(sv.MaSoSinhVien);
            var dk = db.Dangkies.Where(n => n.MaSoSinhVien == sv.MaSoSinhVien && n.KetQua == false).ToList();
            if (dk.Count() > 0)
            {
                ViewBag.TTDT = dk.ElementAt(0).TrangThai;
            }
            return View(listDangKy);
        }
        public ActionResult DsDeTai()
        {
            Sinhvien sv = LaySinhVien();
            string jsoncart = HttpContext.Session.GetString("TaiKhoan");
            var ac = JsonSerializer.Deserialize<Account>(jsoncart);
            ViewBag.account = ac.HoVaTen;
            ViewBag.MSSV = sv.MaSoSinhVien;
            List<DTDeTai> listDeTai = DeTaiDAO.Instance.ListDeTaiThucHien(sv.MaSoSinhVien);
            var dk = db.Detais.Where(n => n.MaSoSinhVien == sv.MaSoSinhVien).OrderByDescending(n => n.MaDeTai).ToList();
            if (dk.Count > 0)
            {
                ViewBag.TTDT = dk.ElementAt(0).MaTrangThai;
            }
            return View(listDeTai);
        }
        [HttpGet]
        public JsonResult Detail(int idDT)
        {
            try
            {
                var list = (from s in db.Dangkies
                            join t in db.Giangviens on s.MaGiangVien equals t.MaGiangVien
                            join c in db.Trangthais on s.TrangThai equals c.MaTrangThai
                            join h in db.Hoidongduyetdecuongs on s.MaHoiDong equals h.MaHoiDong
                            join sv in db.Sinhviens
                            on s.MaSoSinhVien equals sv.MaSoSinhVien
                            where s.IddangKy == idDT
                            select new
                            {
                                TenDT = s.TenDeTai,
                                TenSV = sv.HoTen,
                                MaSV = s.MaSoSinhVien,
                                TenHD = h.TenHoiDong,
                                TenTT = c.TenTrangThai,
                                LinkDT = s.LinkDeCuong
                            }).SingleOrDefault();


                return Json(new { code = 200, dt = list, msg = "Lay thong tin thanh cong." });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lay thong tin that bai " + ex.Message });
            }
        }

        [HttpGet]
        public JsonResult DetailDTNT(int idDT)
        {
            try
            {
                var list = (from s in db.Detais
                            join t in db.Giangviens
                               on s.MaGiangVien equals t.MaGiangVien
                            join c in db.Trangthais
                            on s.MaTrangThai equals c.MaTrangThai
                            join h in db.Hoidongnghiemthus
                            on s.MaHoiDong equals h.MaHoiDong
                            join sv in db.Sinhviens
                            on s.MaSoSinhVien equals sv.MaSoSinhVien
                            where s.MaDeTai == idDT
                            select new
                            {
                                TenDT = s.TenDeTai,
                                TenSV = sv.HoTen,
                                MaSV = s.MaSoSinhVien,
                                TenHD = h.TenHoiDong,
                                TenTT = c.TenTrangThai,
                                LinkDT = s.LinkDeTai
                            }).SingleOrDefault();
                return Json(new { code = 200, dt = list, msg = "Lay thong tin thanh cong." });
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lay thong tin that bai " + ex.Message });
            }
        }
        [HttpPost]
        public ActionResult UploadFilesDeTai()
        {
            // Checking no of files injected in Request object  
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    IFormFileCollection files = HttpContext.Request.Form.Files;
                    string namefile = "";
                    var id = Request.Form["id"];
                    var dt = db.Detais.Where(s => s.MaDeTai == int.Parse(id)).SingleOrDefault();
                    for (int i = 0; i < files.Count; i++)
                    {

                        IFormFile file = Request.Form.Files[i];
                        string fname, sfile;

                        // Checking for Internet Explorer  
                        string userAgent = Request.Headers["User-Agent"].ToString();
                        if (userAgent.Contains("MSIE") || userAgent.Contains("Trident/"))
                        {
                            // IE
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                            namefile += fname + "\\";
                        }
                        sfile = Path.Combine(_webHostEnvironment.WebRootPath, "Theme", "Luufile", fname);

                        // Sao chép dữ liệu từ file đến đường dẫn mới
                        using (var stream = new FileStream(sfile, FileMode.Create))
                        {
                            file.CopyToAsync(stream);
                        }
                        // Get the complete folder path and store the file inside it.  

                    }
                    dt.LinkDeTai = namefile;
                    dt.MaTrangThai = 4;
                    db.SaveChanges();
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}

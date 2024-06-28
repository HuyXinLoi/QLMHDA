using Microsoft.AspNetCore.Mvc;
using QuanLyMonHocDoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
namespace QuanLyMonHocDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QldetainckhContext _context;

        public HomeController(QldetainckhContext context, IWebHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: Admin/Home
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
        public ActionResult Index()
        {
            Giangvien gv = LayGiangVien();
            ViewBag.account = gv.TenGiangVien;
            ViewBag.Email = gv.Gmail;
            var dv = (from dt in _context.Detais
                      join n in _context.Nganhs on dt.MaNganh equals n.MaNganh
                      join k in _context.Khoas on n.MaKhoa equals k.MaKhoa
                      group dt by new { k.MaKhoa, k.TenKhoa } into g
                      select new
                      {
                          SLDT = g.Count(),
                          ChiPhi = g.Sum(dt => dt.KinhPhiDuKien),
                          TenKhoa = g.Key.TenKhoa,
                          MaKhoa = g.Key.MaKhoa
                      }).ToList();
            List<CTThongKeKhoa> ds = new List<CTThongKeKhoa>();
            foreach (var item in dv)
            {
                CTThongKeKhoa dt = new CTThongKeKhoa();
                dt.MaKhoa = item.MaKhoa;
                dt.TenKhoa = item.TenKhoa;
                dt.SLDT = item.SLDT;
                dt.ChiPhi = (float)item.ChiPhi;
                var ct = (from q in _context.Dangkies
                          join e in _context.Giangviens on q.MaGiangVien equals e.MaGiangVien
                          join r in _context.Chuongtrinhs on e.MaCt equals r.MaCt
                          where e.MaKhoa == dt.MaKhoa
                          group q by new { r.TenCt, r.MaCt } into g
                          select new
                          {
                              SLDK = g.Count(),
                              TenChuongTrinh = g.Key.TenCt,
                              MaCT = g.Key.MaCt
                          }).ToList();
                foreach (var t in ct)
                {
                    CTThongKeCT ctbb = new CTThongKeCT();
                    ctbb.MaCT = t.MaCT;
                    ctbb.TenChuongTrinh = t.TenChuongTrinh;
                    ctbb.SLDK = t.SLDK;
                    dt.DSCT.Add(ctbb);
                }
                ds.Add(dt);
            }
            return View(ds);
        }
    }
}

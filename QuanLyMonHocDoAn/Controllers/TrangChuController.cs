using Microsoft.AspNetCore.Mvc;

namespace QuanLyMonHocDoAn.Controllers
{
    public class TrangChuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult PartialNav()
        {
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();

        }
        public ActionResult PartialTopNav()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ThongBao()
        {
            return View();
        }
    }
}

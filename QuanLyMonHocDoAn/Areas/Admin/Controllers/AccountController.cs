using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLyMonHocDoAn.Models;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyMonHocDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QldetainckhContext _context;

        public AccountController(QldetainckhContext context, IWebHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public static string GetMD5(string str)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account ac = _context.Accounts.SingleOrDefault(n => n.UserName == username && n.Pass == GetMD5(password));
            //if (ac != null && ac.MaTypeAccount == 6)
            //{
            //    Session["TaiKhoan"] = ac;
            //    GIANGVIEN ad = _context.GIANGVIENs.SingleOrDefault(n => n.MaSoGiangVien == tk.ToString());
            //    Session["Admin"] = ad;
            //    return RedirectToAction("Index", "Home");
            //}
            if(ac!= null)
            {
                if (ac.MaTypeAccount == 6 )
                {
                    // Nếu là giảng viên
                    Giangvien gv = _context.Giangviens.SingleOrDefault(n => n.MaSoGiangVien == username);
                    HttpContext.Session.SetString("TaiKhoan", JsonConvert.SerializeObject(ac));
                    HttpContext.Session.SetString("GiangVien", JsonConvert.SerializeObject(gv));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TaiKhoan");
            HttpContext.Session.Remove("GiangVien");
            return RedirectToAction("Login", "Account");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuanLyMonHocDoAn.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;


namespace QuanLyMonHocDoAn.Controllers
{
    public class UserController : Controller
    {
        private readonly QldetainckhContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(QldetainckhContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: User
        public IActionResult Login()
        {
            return View();
        }
        public static string GetMD5(string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] fromData = Encoding.UTF8.GetBytes(str);
                byte[] targetData = md5.ComputeHash(fromData);
                StringBuilder byte2String = new StringBuilder();

                for (int i = 0; i < targetData.Length; i++)
                {
                    byte2String.Append(targetData[i].ToString("x2"));
                }

                return byte2String.ToString();
            }
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Account ac = _db.Accounts.SingleOrDefault(n => n.UserName == username && n.Pass == GetMD5(password));

            if (ac != null)
            {
                if (ac.MaTypeAccount == 1)
                {
                    HttpContext.Session.SetString("TaiKhoan", JsonConvert.SerializeObject(ac));
                    Sinhvien sv = _db.Sinhviens.SingleOrDefault(n => n.MaSoSinhVien == username);
                    HttpContext.Session.SetString("SinhVien", JsonConvert.SerializeObject(sv));

                    return RedirectToAction("StudentDB", "StudentDB");
                }
                else if (ac.MaTypeAccount == 2)
                {
                    // Nếu là giảng viên
                    Giangvien gv = _db.Giangviens.SingleOrDefault(n => n.MaSoGiangVien == username);
                    HttpContext.Session.SetString("TaiKhoan", JsonConvert.SerializeObject(ac));
                    HttpContext.Session.SetString("GiangVien", JsonConvert.SerializeObject(gv));
                    return RedirectToAction("Index", "GiangVien");
                }
                else if (ac.MaTypeAccount == 5)
                {
                    // Nếu là quản lý tổng
                    return RedirectToAction("Index", "QuanLyTong");

                }
                else if (ac.MaTypeAccount == 3)
                {
                    // Nếu là quản lý
                    Giangvien gv = _db.Giangviens.SingleOrDefault(n => n.MaSoGiangVien == username);
                    HttpContext.Session.SetString("TaiKhoan", JsonConvert.SerializeObject(ac));
                    Sinhvien sv = _db.Sinhviens.SingleOrDefault(n => n.MaSoSinhVien == username);
                    HttpContext.Session.SetString("GiangVien", JsonConvert.SerializeObject(sv));
                    return RedirectToAction("Index", "QuanLy");
                }
                else if (ac.MaTypeAccount == 4)
                {
                    // Nếu là quản lý viên
                    return RedirectToAction("Index", "QuanLyVien");
                }
            }

            ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }

        public IActionResult SuccessPage()
        {
            //var session = _httpContextAccessor.HttpContext.Session;
            //var userName = session.GetString("UserName");
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
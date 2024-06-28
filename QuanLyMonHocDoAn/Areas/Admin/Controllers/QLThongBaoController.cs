using Microsoft.AspNetCore.Mvc;
using QuanLyMonHocDoAn.Models;


namespace QuanLyMonHocDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QLThongBaoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QldetainckhContext _context;

        public QLThongBaoController(QldetainckhContext context, IWebHostEnvironment hostingEnvironment)
        {

            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Index()
        {
            var ds = _context.Thongbaos.ToList().OrderByDescending(n => n.Id).Take(10);
            return View(ds);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Thongbao model)
        {
            if (ModelState.IsValid)
            {
                // Thêm dữ liệu vào database
                using (_context)
                {
                    model.NgayGui = DateOnly.FromDateTime(DateTime.Now);
                    model.NguoiNhan = 1;
                    _context.Thongbaos.Add(model);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index"); // Chuyển hướng đến trang index
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var tb = _context.Thongbaos.SingleOrDefault(n => n.Id == id);
            return View(tb);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Edit(int id, Thongbao t)
        {
            t = _context.Thongbaos.SingleOrDefault(n => n.Id == id);
            t.TenThongBao = Request.Form["TenThongBao"];
            t.NoiDungTb = Request.Form["NoiDungTb"];
            t.NgayGui = DateOnly.FromDateTime(DateTime.Now);

            _context.SaveChanges();
            return RedirectToAction("Index"); // Chuyển hướng đến trang index
        }
       
        public ActionResult Delete(int id)
        {
            //var tb = _context.Thongbaos.Where(n => n.Id == id).SingleOrDefault();
            var tb = _context.Thongbaos.SingleOrDefault(n => n.Id == id);
            return View(tb);
        }
        [HttpPost]
        public ActionResult Delete(int id, Thongbao t)
        {
            var entityToDelete = _context.Thongbaos.SingleOrDefault(n => n.Id == id);

            if (entityToDelete != null)
            {
                // Xóa đối tượng khỏi context
                _context.Thongbaos.Remove(entityToDelete);

                // Lưu các thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();
            }

            // Sau khi xóa, chuyển hướng đến action "Index"
            return RedirectToAction("Index"); 
        }
    }
}

using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using QuanLyMonHocDoAn.Areas.Admin.Models;
using QuanLyMonHocDoAn.Models;
using System.Globalization;

namespace QuanLyMonHocDoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QLSinhVienController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly QldetainckhContext _context;

        public QLSinhVienController(QldetainckhContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(IFormFile csvfile)
        {
            // Kiểm tra nếu không có file được chọn
            if (csvfile == null || csvfile.Length == 0)
            {
                ViewBag.Message = "Bạn Chưa Chọn File.";
                return View();
            }

            // Đọc dữ liệu từ file CSV
            using (var reader = new StreamReader(csvfile.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StudentViewModel>().ToList();

                foreach (var record in records)
                {
                    var account = new Sinhvien
                    {
                        MaSinhVien = record.MaSinhVien,
                        MaSoSinhVien = record.MaSoSinhVien,
                        HoTen = record.HoTen,
                        MaNganh = record.MaNganh,
                        NgaySinh = record.NgaySinh,
                        Cccd = record.Cccd,
                        TknganHang = record.TknganHang,
                        Sdt = record.Sdt,
                        Lop = record.Lop,
                        NienKhoa = record.NienKhoa,
                        GioiTinh = record.GioiTinh,
                        DiaChi = record.DiaChi,
                        ChiNhanhNganHang = record.ChiNhanhNganHang,
                        MaAccount = record.MaAccount,
                        MaNhom = record.MaNhom,
                        Email = record.Email,
                    };
                    _context.Sinhviens.Add(account);
                }
                await _context.SaveChangesAsync();
            }
            /*using (var reader = new StreamReader(csvfile.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
            {
                // Bỏ qua dòng tiêu đề
                reader.ReadLine();

                // Duyệt qua từng dòng dữ liệu trong file CSV
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Tạo một đối tượng SinhVien từ dữ liệu trong file CSV
                    var ac = new Account
                    {

                        UserName = values[1],
                        Email = values[2],
                        Pass = values[3],
                        HoVaTen = values[4],
                        MaTypeAccount = Convert.ToInt32(values[5])
                    };
                    // Thêm đối tượng SinhVien vào database
                    _context.Accounts.Add(ac);
                    _context.SaveChangesAsync();
                }
            }*/

            ViewBag.Message = "Thêm Dữ Liệu Thành Công.";

            return View();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DTChamDiemDT
    {
        public int MaDeTai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Đề Tài")]
        public string TenDeTai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Mã Số Sinh Viên")]
        public string MaSoSinhVien { get; set; }


        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public string MaSoGiangVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public int MaGiangVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Giảng Viên")]
        public string TenGiangVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }


        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Trạng Thái")]
        public string TenTrangThai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "LinkDeCuong")]
        public string LinkDeTai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Mã Hội Đồng")]
        public string MaHoiDong { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Hội Đồng")]

        public bool CheckChamDiem { get; set; }
        public string TenHoiDong { get; set; }

        public int MaTrangThai { get; set; }

        public DTChamDiemDT(DataRow row)
        {
            this.MaDeTai = (int)row["MaDeTai"];
            this.TenDeTai = row["TenDeTai"].ToString();
            this.MaSoSinhVien = row["MaSoSinhVien"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.MaGiangVien = (int)row["MaGiangVien"];
            this.MaSoGiangVien = row["MaSoGiangVien"].ToString();
            this.TenGiangVien = row["TenGiangVien"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.TenTrangThai = row["TenTrangThai"].ToString();
            this.LinkDeTai = row["LinkDeTai"].ToString();
            this.CheckChamDiem = DsChamDiemDT.Instance.CheckChamDiem(this.MaGiangVien, this.MaDeTai);
            this.TenHoiDong = row["TenHoiDong"].ToString();
            this.MaTrangThai = (int)row["MaTrangThai"];
        }
    }
}

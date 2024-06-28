using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DTDangKy
    {
        public int IDDangKy { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Đề Tài")]
        public string TenDeTai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Mã Số Sinh Viên")]
        public string MaSoSinhVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public string MaSoGiangVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Giảng Viên Hướng Dẫn")]
        public string TenGiangVien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public string TrangThai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public int MaHD { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Trạng Thái")]
        public string TenTrangThai { get; set; }

        public DTDangKy(DataRow row)
        {
            this.IDDangKy = (int)row["IDDangKy"];
            this.TenDeTai = row["TenDeTai"].ToString();
            this.MaSoSinhVien = row["MaSoSinhVien"].ToString();
            this.MaSoGiangVien = row["MaSoGiangVien"].ToString();
            this.TenGiangVien = row["TenGiangVien"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
            this.TenTrangThai = row["TenTrangThai"].ToString();
            this.MaHD = (int)row["MaHoiDong"];
        }
    }
}

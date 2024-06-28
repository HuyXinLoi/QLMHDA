using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DTDeTai
    {
        public int MaDeTai { get; set; }

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
        [Display(Name = "Ngày Thực Hiện")]
        public DateTime NgayThucHien { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Ngày Kết Thúc")]
        public DateTime NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        public string TrangThai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Trạng Thái")]
        public string TenTrangThai { get; set; }
        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên hội đồng")]
        public int MaHoiDong { get; set; }

        public DTDeTai(DataRow row)
        {
            this.MaDeTai = (int)row["MaDeTai"];
            this.MaHoiDong = (int)row["MaHoiDong"];
            this.TenDeTai = row["TenDeTai"].ToString();
            this.MaSoSinhVien = row["MaSoSinhVien"].ToString();
            this.MaSoGiangVien = row["MaSoGiangVien"].ToString();
            this.TenGiangVien = row["TenGiangVien"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.TrangThai = row["MaTrangThai"].ToString();
            this.TenTrangThai = row["TenTrangThai"].ToString();

        }
    }
}

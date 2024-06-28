using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DataChamDiemData
    {
        public int IDDangKy { get; set; }

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
        public string TrangThai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Trạng Thái")]
        public string TenTrangThai { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "LinkDeCuong")]
        public string LinkDeCuong { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Mã Hội Đồng")]
        public string MaHoiDong { get; set; }

        [Required(ErrorMessage = "Lỗi")]
        [Display(Name = "Tên Hội Đồng")]
        public bool SLTV { get; set; }
        public string TenHoiDong { get; set; }

        public int MaTrangThai { get; set; }

        public DataChamDiemData(DataRow row)
        {
            this.IDDangKy = (int)row["IDDangKy"];
            this.TenDeTai = row["TenDeTai"].ToString();
            this.MaSoSinhVien = row["MaSoSinhVien"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.MaGiangVien = (int)row["MaGiangVien"];
            this.MaSoGiangVien = row["MaSoGiangVien"].ToString();
            this.TenGiangVien = row["TenGiangVien"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
            this.TenTrangThai = row["TenTrangThai"].ToString();
            this.LinkDeCuong = row["LinkDeCuong"].ToString();
            this.TenHoiDong = row["TenHoiDong"].ToString();
            this.SLTV = DsChamDiem.Instance.CheckChamDiem(this.MaGiangVien, this.IDDangKy);
            this.MaTrangThai = (int)row["MaTrangThai"];
        }
    }
}
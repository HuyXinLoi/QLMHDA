using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Detai
{
    public int MaDeTai { get; set; }

    public string? TenDeTai { get; set; }

    public string? GhiChu { get; set; }

    public string? MaNganh { get; set; }

    public DateTime? NgayThucHien { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public decimal? KinhPhiDuKien { get; set; }

    public string? KetQua { get; set; }

    public string? LinkDeTai { get; set; }

    public int? MaTrangThai { get; set; }

    public int? MaGiangVien { get; set; }

    public int? MaHoiDong { get; set; }

    public string? MaNhom { get; set; }

    public string? MaSoSinhVien { get; set; }

    public virtual ICollection<Bienbannghiemthu> Bienbannghiemthus { get; set; } = new List<Bienbannghiemthu>();

    public virtual ICollection<Donxingiahan> Donxingiahans { get; set; } = new List<Donxingiahan>();

    public virtual Giangvien? MaGiangVienNavigation { get; set; }

    public virtual Hoidongnghiemthu? MaHoiDongNavigation { get; set; }

    public virtual Nganh? MaNganhNavigation { get; set; }

    public virtual Trangthai? MaTrangThaiNavigation { get; set; }
}

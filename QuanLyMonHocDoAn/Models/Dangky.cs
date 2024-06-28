using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Dangky
{
    public int IddangKy { get; set; }

    public string? TenDeTai { get; set; }

    public string? MaNhom { get; set; }

    public string MaSoSinhVien { get; set; } = null!;

    public int? MaGiangVien { get; set; }

    public string? GhiChu { get; set; }

    public int? MaHoiDong { get; set; }

    public string? LinkDeCuong { get; set; }

    public int? TrangThai { get; set; }

    public DateTime? NgayDangKy { get; set; }

    public bool? KetQua { get; set; }
}

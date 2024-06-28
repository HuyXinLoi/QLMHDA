using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Bienbanchamdecuong
{
    public int IdbienBan { get; set; }

    public int? IdDangKy { get; set; }

    public int? MaHoiDong { get; set; }

    public int? MaGiangVien { get; set; }

    public double? Diem { get; set; }

    public string? DanhGia { get; set; }

    public string? MinhChung { get; set; }
}

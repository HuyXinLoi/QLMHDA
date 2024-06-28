using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Chitietnhom
{
    public int IdCtnhom { get; set; }

    public string MaNhom { get; set; } = null!;

    public string? MaSoSinhVien { get; set; }

    public string? HoTen { get; set; }

    public int? IddangKy { get; set; }

    public int? TrangThai { get; set; }
}

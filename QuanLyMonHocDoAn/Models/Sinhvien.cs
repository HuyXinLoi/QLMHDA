using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Sinhvien
{
    public int MaSinhVien { get; set; }

    public string? MaSoSinhVien { get; set; }

    public string? HoTen { get; set; }

    public string? MaNganh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? Cccd { get; set; }

    public string? TknganHang { get; set; }

    public string? Sdt { get; set; }

    public string? Lop { get; set; }

    public string? NienKhoa { get; set; }

    public bool? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? ChiNhanhNganHang { get; set; }

    public int? MaAccount { get; set; }

    public int? MaNhom { get; set; }

    public string? Email { get; set; }

    public virtual Account? MaAccountNavigation { get; set; }
}

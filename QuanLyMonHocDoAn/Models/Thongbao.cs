using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public class Thongbao
{
    public int Id { get; set; }

    public string? TenThongBao { get; set; }

    public string? NoiDungTb { get; set; }

    public DateOnly? NgayGui { get; set; }

    public int? NguoiNhan { get; set; }
}

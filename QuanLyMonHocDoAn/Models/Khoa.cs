using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Khoa
{
    public string MaKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public virtual ICollection<Hoidongnghiemthu> Hoidongnghiemthus { get; set; } = new List<Hoidongnghiemthu>();

    public virtual ICollection<Nganh> Nganhs { get; set; } = new List<Nganh>();
}

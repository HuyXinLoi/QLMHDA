using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Nganh
{
    public string MaNganh { get; set; } = null!;

    public string? TenNganh { get; set; }

    public string MaKhoa { get; set; } = null!;

    public string? MaCt { get; set; }

    public virtual ICollection<Detai> Detais { get; set; } = new List<Detai>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;
}

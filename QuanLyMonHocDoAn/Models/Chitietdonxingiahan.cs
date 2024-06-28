using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Chitietdonxingiahan
{
    public int MaCtdxgh { get; set; }

    public DateOnly? NgayGiaHan { get; set; }

    public DateOnly? NgayHoanThanh { get; set; }

    public string? LinkDonXin { get; set; }

    public int? IsAccept { get; set; }

    public virtual ICollection<Donxingiahan> Donxingiahans { get; set; } = new List<Donxingiahan>();
}

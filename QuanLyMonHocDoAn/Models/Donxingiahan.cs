using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Donxingiahan
{
    public int MaDonXinGiaHan { get; set; }

    public int? MaGiangVien { get; set; }

    public int? MaCtdxgh { get; set; }

    public int? MaDeTai { get; set; }

    public virtual Chitietdonxingiahan? MaCtdxghNavigation { get; set; }

    public virtual Detai? MaDeTaiNavigation { get; set; }

    public virtual Giangvien? MaGiangVienNavigation { get; set; }
}

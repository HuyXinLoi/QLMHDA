using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Bienbannghiemthu
{
    public int IdbienBan { get; set; }

    public int? MaHoiDong { get; set; }

    public int? MaDeTai { get; set; }

    public double? Diem { get; set; }

    public string? NhanXet { get; set; }

    public string? LinkBienBan { get; set; }

    public int? MaGiangVien { get; set; }

    public virtual Detai? MaDeTaiNavigation { get; set; }

    public virtual Hoidongnghiemthu? MaHoiDongNavigation { get; set; }
}

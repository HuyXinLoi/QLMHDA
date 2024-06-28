using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Hoidongnghiemthu
{
    public int MaHoiDong { get; set; }

    public string? TenHoiDong { get; set; }

    public DateTime? NgayNghiemThu { get; set; }

    public string? MaKhoa { get; set; }

    public bool? SoLuongTv { get; set; }

    public string? MaCt { get; set; }

    public virtual ICollection<Bienbannghiemthu> Bienbannghiemthus { get; set; } = new List<Bienbannghiemthu>();

    public virtual ICollection<Detai> Detais { get; set; } = new List<Detai>();

    public virtual Khoa? MaKhoaNavigation { get; set; }
}

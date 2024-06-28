using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Giangvien
{
    public int MaGiangVien { get; set; }

    public string? MaSoGiangVien { get; set; }

    public string? TenGiangVien { get; set; }

    public string? Nganh { get; set; }

    public string? TrinhDo { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public int? MaAccount { get; set; }

    public string? MaKhoa { get; set; }

    public string? Gmail { get; set; }

    public string? MaCt { get; set; }

    public virtual ICollection<Detai> Detais { get; set; } = new List<Detai>();

    public virtual ICollection<Donxingiahan> Donxingiahans { get; set; } = new List<Donxingiahan>();
}

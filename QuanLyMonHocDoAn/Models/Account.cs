using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyMonHocDoAn.Models;

public partial class Account
{
    [Key]
    public int MaAccount { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Pass { get; set; }

    public string? HoVaTen { get; set; }

    public int? MaTypeAccount { get; set; }

    public virtual Typeaccount? MaTypeAccountNavigation { get; set; }

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}

using System;
using System.Collections.Generic;

namespace QuanLyMonHocDoAn.Models;

public partial class Typeaccount
{
    public int MaTypeAccount { get; set; }

    public string? TenTypeAccount { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

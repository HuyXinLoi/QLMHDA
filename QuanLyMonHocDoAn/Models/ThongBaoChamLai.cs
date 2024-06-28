using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyMonHocDoAn.Models;

public partial class ThongBaoChamLai
{
    public int Id { get; set; }

    public string? Thongbao { get; set; }

    public int? MaHoiDong { get; set; }

    public int? IdDangKy { get; set; }

    public bool? IsCheck { get; set; }

    public DateTime? DateModified { get; set; }
    public string TenDeTai { get; set; }

    public int ThoiGian { get; set; }
    //public ThongBaoChamLai(DataRow row)
    //{
    //    DateTime now = DateTime.Now;
    //    TimeSpan timeDiff = now.Subtract((DateTime)row["DateModified"]);
    //    double totalMinutes = timeDiff.TotalMinutes;
    //    this.Id = (int)row["Id"];
    //    this.Thongbao = row["Thongbao"].ToString();
    //    this.MaHoiDong = (int)row["MaHoiDong"];
    //    this.IsCheck = (bool)row["IsCheck"]; // Gán trực tiếp giá trị bool
    //    this.TenDeTai = row["TenDeTai"].ToString();
    //    this.ThoiGian = (int)totalMinutes;
    //}
}


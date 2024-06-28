namespace QuanLyMonHocDoAn.Areas.Admin.Models
{
    public class GiangVienViewModel
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
    }
}

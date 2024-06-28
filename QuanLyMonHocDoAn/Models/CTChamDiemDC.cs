namespace QuanLyMonHocDoAn.Models
{
    public class CTChamDiemDC
    {
        public string TenDeTai { get; set; }
        public int IDDC { get; set; }
        public string TenGiangVien { get; set; }
        public string GhiChu { get; set; }

        public List<CTBienBan> DSBienBan = new List<CTBienBan>();
    }
}

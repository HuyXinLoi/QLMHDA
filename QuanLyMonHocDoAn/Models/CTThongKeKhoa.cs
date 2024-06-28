namespace QuanLyMonHocDoAn.Models
{
    public class CTThongKeKhoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int SLDT { get; set; }
        public double ChiPhi { get; set; }

        public List<CTThongKeCT> DSCT = new List<CTThongKeCT>();
    }
}

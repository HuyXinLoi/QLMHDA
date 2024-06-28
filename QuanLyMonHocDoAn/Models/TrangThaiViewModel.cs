namespace QuanLyMonHocDoAn.Models
{
    public class TrangThaiViewModel
    {
        public List<Trangthai> trangThai = new List<Trangthai>();
        private readonly QldetainckhContext db;

        public TrangThaiViewModel(QldetainckhContext db)
        {
            this.db = db;
        }

        public static TrangThaiViewModel instance;

        public static TrangThaiViewModel Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public int TrangThaiDeTaiDangLam(string MSSV)
        {
            int q;
            var tt = db.Dangkies.Where(n => n.MaSoSinhVien == MSSV).ToList();
            if (tt.Count > 0)
            {
                q = (int)tt.ElementAt(0).TrangThai;
            }
            else
            {
                q = 1;
            }
            return q;
        }

        public int TrangThaiDeTaiDangLamNghiemThu(string MSSV)
        {
            int q;
            var tt = db.Detais.Where(n => n.MaSoSinhVien == MSSV && n.MaTrangThai <= 5).ToList();
            if (tt.Count > 0)
            {
                q = (int)tt.ElementAt(0).MaTrangThai;
            }
            else
            {
                q = 1;
            }

            return q;
        }
        public Dangky DeTaiDangDangKy(string MSSV)
        {
            Dangky dk = db.Dangkies.Where(n => n.MaSoSinhVien == MSSV && n.KetQua == false).SingleOrDefault();
            return dk;
        }
        public bool InsertThongBaoChamDiem(string ThongBao, int IdHoiDong, int IdDangKy, bool ICheck, DateTime Date)
        {
            string query = "sp_AddThongBaoChamLai @thongbao , @idhoidong , @iddangky , @check , @date ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { ThongBao, IdHoiDong, IdDangKy, ICheck, Date }) > 0)
            {
                return true;
            }
            return false;
        }
    }
}

using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DangKyDAO
    {
        private static DangKyDAO instance;
        public static DangKyDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DangKyDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public List<DTDangKy> ListDangKy(string mssv)
        {
            List<DTDangKy> listDangKy = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC sp_LAYDUYETDETAI " + mssv);
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy dangKy = new DTDangKy(item);
                listDangKy.Add(dangKy);
            }
            return listDangKy;
        }

        public List<DTDangKy> ListTongDeCuong()
        {
            List<DTDangKy> listDecuong = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYTONGDANHSACHDECUONG]");
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy detai = new DTDangKy(item);
                listDecuong.Add(detai);
            }
            return listDecuong;
        }

        public List<DTDangKy> ListTongDeCuongLoc(DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDangKy> listDecuong = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYTONGDANHSACHDECUONGLOC] @ngaybd , @ngaykt", new object[] { ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy decuong = new DTDangKy(item);
                listDecuong.Add(decuong);
            }
            return listDecuong;
        }

        public List<DTDangKy> ListDSDeCuongTheoVien(string makhoa)
        {
            List<DTDangKy> listDecuong = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYDSDECUONGTHEOVIEN] @makhoa", new object[] { makhoa });
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy detai = new DTDangKy(item);
                listDecuong.Add(detai);
            }
            return listDecuong;
        }

        public List<DTDangKy> ListDSDeCuongTheoVienLoc(string makhoa, DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDangKy> listDecuong = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYDSDECUONGTHEOVIENLOC] @makhoa , @ngaybd , @ngaykt", new object[] { makhoa, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy decuong = new DTDangKy(item);
                listDecuong.Add(decuong);
            }
            return listDecuong;
        }

        public List<DTDangKy> ListDeTaiDaDangKy()
        {
            List<DTDangKy> listDangKy = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC sp_LAYDETAIDADANGKY");
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy dangKy = new DTDangKy(item);
                listDangKy.Add(dangKy);
            }
            return listDangKy;
        }
        public DTDangKy GetDeTaiByID(int id)
        {
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC sp_LAYDETAITHEOID", new object[] { id });
            DTDangKy dangKy = new DTDangKy(dt.Rows[0]);
            return dangKy;
        }
        public List<DTDangKy> ListDangKyTheoMaCT(string mact, DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDangKy> listDangKy = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDUYETDETAITHEOMACTLOC] @mact , @ngaybd , @ngaykt", new object[] { mact, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy dangKy = new DTDangKy(item);
                listDangKy.Add(dangKy);
            }
            return listDangKy;
        }

        public List<DTDangKy> ListDangKyTheoMaCTDefault(string mact)
        {
            List<DTDangKy> listDangKy = new List<DTDangKy>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDUYETDETAITHEOMACTDEFAULT] @mact", new object[] { mact });
            foreach (DataRow item in dt.Rows)
            {
                DTDangKy dangKy = new DTDangKy(item);
                listDangKy.Add(dangKy);
            }
            return listDangKy;
        }
    }
}

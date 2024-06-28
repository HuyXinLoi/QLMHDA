using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DeTaiDAO
    {
        private static DeTaiDAO instance;
        public static DeTaiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeTaiDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public List<DTDeTai> ListDeTaiThucHien(string mssv)
        {
            List<DTDeTai> listDeTai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYDSDETAIDADUYET] " + mssv);
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDeTai.Add(detai);
            }
            return listDeTai;
        }
        public List<DTDeTai> ListTongDeTai()
        {
            List<DTDeTai> listDeTai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYTONGDANHSACHDETAI]");
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDeTai.Add(detai);
            }
            return listDeTai;
        }

        public List<DTDeTai> ListTongDeTaiLoc(DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDeTai> listDeTai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYTONGDANHSACHDETAILOC] @ngaybd , @ngaykt", new object[] { ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDeTai.Add(detai);
            }
            return listDeTai;
        }


        public List<DTDeTai> ListTongDeTaiVien(string makhoa)
        {
            List<DTDeTai> listDeTai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYDSDETAITHEOVIEN] @makhoa ", new object[] { makhoa });
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDeTai.Add(detai);
            }
            return listDeTai;
        }

        public List<DTDeTai> ListTongDeTaiVienLoc(string makhoa, DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDeTai> listDeTai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("EXEC [sp_LAYDSDETAITHEOVIENLOC] @makhoa , @ngaybd , @ngaykt", new object[] { makhoa, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDeTai.Add(detai);
            }
            return listDeTai;
        }


        public List<DTDeTai> ListDeTaiTheoMaCT(string mact, DateTime ngaybd, DateTime ngaykt)
        {
            List<DTDeTai> listDetai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDUYETDETAITHEOMACTLOC] @mact , @ngaybd , @ngaykt", new object[] { mact, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDetai.Add(detai);
            }
            return listDetai;
        }

        public List<DTDeTai> ListDeTaiTheoMaCTDefault(string mact)
        {
            List<DTDeTai> listDetai = new List<DTDeTai>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDUYETDETAINTTHEOMACTDEFAULT] @mact", new object[] { mact });
            foreach (DataRow item in dt.Rows)
            {
                DTDeTai detai = new DTDeTai(item);
                listDetai.Add(detai);
            }
            return listDetai;
        }
    }
}

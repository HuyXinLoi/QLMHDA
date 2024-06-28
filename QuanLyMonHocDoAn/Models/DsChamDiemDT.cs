using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class DsChamDiemDT
    {
        private static DsChamDiemDT instance;
        public static DsChamDiemDT Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DsChamDiemDT();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<DTChamDiemDT> ListDsDeTai(int mgv, string mact)
        {
            List<DTChamDiemDT> listDsDeTai = new List<DTChamDiemDT>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDSCHAMDETAITHEOMAGIANGVIEN] @magiangvien , @mact", new object[] { mgv, mact });
            foreach (DataRow item in dt.Rows)
            {
                DTChamDiemDT danhsach = new DTChamDiemDT(item);
                listDsDeTai.Add(danhsach);
            }
            return listDsDeTai;
        }

        public List<DTChamDiemDT> ListLocDeTai(int mgv, string mact, DateTime ngaybd, DateTime ngaykt)
        {
            List<DTChamDiemDT> listDsDeTai = new List<DTChamDiemDT>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDSCHAMDETAITHEOMAGIANGVIENLOC] @magiangvien , @mact , @ngaybd , @ngaykt", new object[] { mgv, mact, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DTChamDiemDT Loc = new DTChamDiemDT(item);
                listDsDeTai.Add(Loc);
            }
            return listDsDeTai;
        }
        public bool CheckChamDiem(int mgv, int iddt)
        {
            if ((int)DataProvider.Instance.ExcuteQuery("Select COUNT(*) FROM BIENBANNGHIEMTHU where MaGiangVien = " + mgv + "and MaDeTai=" + iddt).Rows[0][0] > 0)
            {
                return true;
            }
            return false;
        }
    }
}

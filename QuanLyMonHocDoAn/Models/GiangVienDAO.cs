using System.Data;

namespace QuanLyMonHocDoAn.Models
{
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;
        public static GiangVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GiangVienDAO();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        //public List<ThongBaoChamLai> DsThongBaoChamLai(int mgv)
        //{
        //    List<ThongBaoChamLai> dsTb = new List<ThongBaoChamLai>();
        //    DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDSTBChamLai] @magiangvien ", new object[] { mgv });
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        ThongBaoChamLai danhsach = new ThongBaoChamLai(item);
        //        dsTb.Add(danhsach);
        //    }
        //    return dsTb;
        //}
    }
}

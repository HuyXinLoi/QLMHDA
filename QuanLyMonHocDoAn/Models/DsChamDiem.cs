
using QuanLyMonHocDoAn.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace QuanLyMonHocDoAn.Models
{
    public class DsChamDiem
    {
        private static DsChamDiem instance;
        public static DsChamDiem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DsChamDiem();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<DataChamDiemData> ListDsDeCuong(int mgv, string mact)
        {
            List<DataChamDiemData> listDsDeCuong = new List<DataChamDiemData>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("[sp_LAYDUYETDETAITHEOMAGIANGVIEN] @magiangvien , @mact", new object[] { mgv, mact });
            foreach (DataRow item in dt.Rows)
            {
                DataChamDiemData danhsach = new DataChamDiemData(item);
                listDsDeCuong.Add(danhsach);
            }
            return listDsDeCuong;
        }

        public List<DataChamDiemData> ListLocDeTai(int mgv, string mact, DateTime ngaybd, DateTime ngaykt)
        {
            List<DataChamDiemData> listDangKy = new List<DataChamDiemData>();
            DataTable dt = DataProvider.Instance.ExcuteQuery("sp_LAYDUYETDETAITHEOMAGIANGVIENLOC @magiangvien , @mact , @ngaybd , @ngaykt", new object[] { mgv, mact, ngaybd, ngaykt });
            foreach (DataRow item in dt.Rows)
            {
                DataChamDiemData Loc = new DataChamDiemData(item);
                listDangKy.Add(Loc);
            }
            return listDangKy;
        }
        public bool CheckChamDiem(int mgv, int iddt)
        {
            if ((int)DataProvider.Instance.ExcuteQuery("Select COUNT(*) FROM BIENBANCHAMDECUONG where MaGiangVien = " + mgv + "and IdDangKy=" + iddt).Rows[0][0] > 0)
            {
                return true;
            }
            return false;
        }
    }
}
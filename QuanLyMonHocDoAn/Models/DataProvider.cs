using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace QuanLyMonHocDoAn.Models
{
    public class DataProvider
    {
        private static DataProvider instance;
        private readonly string _connection;
        public DataProvider(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("db");
        }

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    // Lấy IConfiguration từ DI container để inject vào constructor
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

                    // Tạo instance mới của lớp DataProvider với IConfiguration đã lấy được
                    instance = new DataProvider(configuration);
                }
                return instance;
            }
        }
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Con = new SqlConnection(_connection))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter sql = new SqlDataAdapter(cmd);
                sql.Fill(dt);
                Con.Close();
            }
            return dt;
        }
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int dt = 0;
            using (SqlConnection Con = new SqlConnection(_connection))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteNonQuery();
                Con.Close();
            }
            return dt;
        }
        public DataTable ExcuteQuery1(string query, string colum, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Con = new SqlConnection(_connection))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                dt.Columns.Add(colum, typeof(string));
                dt.Load(rdr);
                Con.Close();
            }
            return dt;
        }
    }
}

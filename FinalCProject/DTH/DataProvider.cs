using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCProject.DTH
{
    internal class DataProvider
    {
        private static DataProvider instance;

        private string strConnect = "Data Source=.\\sqlexpress;Initial Catalog=finalCinema3;Integrated Security=True;TrustServerCertificate=True";

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connect = new SqlConnection(strConnect))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
                connect.Close();

            }
            return table;
        }//Thực hiện câu truy vấn trả về bảng

        public int ExcuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connect = new SqlConnection(strConnect))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connect.Close();
            }
            return data;
        }//Thực hiện câu truy vấn trả về số dòng thành công

        public int ExcuteNoneQuery1(string query, SqlParameter[] parameters)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Gắn các tham số vào câu lệnh
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                // Thực thi câu lệnh
                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connect = new SqlConnection(strConnect))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connect.Close();
            }
            return data;
        }//Thực hiện câu truy vấn trả về số lượng dòng (đến count(*)) thành công
    }
}

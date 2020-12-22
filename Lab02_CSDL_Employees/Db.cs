using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_CSDL_Employees
{
    class Db
    {
        // thực thi câu truy vấn SQL
        // trả về bảng kết quả SELECT
        public static DataTable q(string sql)
        {
            //kết nối với máy chủ Cơ sở dữ liệu
            var sc = new SqlConnection();

            //  |DataDirectory| là bí danh của đường dẫn tuyệt đối đến thư mục thực thi bin/Debug
            sc.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            |DataDirectory|\Database_Lab02_Employees.mdf;Integrated Security=True";
            sc.Open();

            // truy vấn 
            var dt = new DataTable();
            var sda = new SqlDataAdapter(sql, sc);
            try
            {
                sda.Fill(dt);
            }
            catch (Exception)
            {
                throw new Exception("error: " + sql);
            }

            // đóng kết nối
            sc.Close();

            return dt;
        }


        // thực thi câu truy vấn sql
        // trả về dòng bản ghi
        public static DataRow row(string sql)
        {
            var dt = q(sql);

            if (dt == null || dt.Rows.Count < 1)
            {
                return null;
            }
            return dt.Rows[0];

        }

        // SELECT Count(*) FROM Employee
        // sql for: cout, avg, min, max 
        public static string one(string sql)
        {
            var dt = q(sql);
            if (dt == null || dt.Rows.Count < 1)
            {
                return null;
            }

            return dt.Rows[0][0].ToString();
        }

    }
}

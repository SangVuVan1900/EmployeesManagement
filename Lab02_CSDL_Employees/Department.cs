using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Lab02_CSDL_Employees
{
    class Department
    {
        // Ctrl + K + D căn chỉnh dòng 
        //DataTable học thuộc để  using @@
        public static DataTable table()
        {
            var sql = "SELECT * FROM Departments";
            return Db.q(sql);
        }
    }
}

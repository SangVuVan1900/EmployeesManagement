using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_CSDL_Employees
{
    class Employee  
    {
        // DataTable học thuộc để using
        public static DataTable table()
        {
            var sql = @"
                SELECT E.EmployeeID, E.EmployeeName, D.DeptName, E.Gender,  
                       E.BirthDate, E.Tel, E.Address  
                FROM Employees AS E 
                LEFT JOIN Departments AS D ON E.DeptID = D.DeptID                  
                ";
            return Db.q(sql);
        }

        // trả về 1 dòng bản ghi dựa trên khóa chính ID
        public static DataRow row(string id)
        {
            var sql = "SELECT * FROM Employees WHERE EmployeeID=" + id;
            return Db.row(sql);
        }

        public static void add(Dictionary<string, string> row)
        { 
            var sql = string.Format(@"  
            INSERT INTO Employees([EmployeeName], [DeptID], [Gender], [BirthDate], [Tel], [Address])                  
                           VALUES (N'{0}',  '{1}',  {2},  '{3}',  N'{4}',  N'{5}')
            ", row["EmployeeName"], row["DeptID"], row["Gender"], row["BirthDate"], row["Tel"], row["Address"]
            ); 

            Db.q(sql); 
        }
          
        public static void edit(Dictionary<string, string> row, string id)
        {
            var sql = string.Format(@"  
                UPDATE Employees 
                SET EmployeeName= N'{0}' ,
                    DeptID      = '{1}'  ,
                    Gender      = {2}    ,
                    BirthDate   = '{3}'  ,   
                    Tel         = N'{4}' , 
                    Address     = N'{5}' 
                WHERE EmployeeID= {6} 
            ", row["EmployeeName"], row["DeptID"], row["Gender"], row["BirthDate"], row["Tel"], row["Address"],id
          );

            Db.q(sql);
        }    

        public static void delete(string id)  
        { 
            var sql = "DELETE FROM Employees WHERE EmployeeID=" + id;
            Db.q(sql);  
        } 
         
        public static DataTable searchByDeptName(string DeptName)
        {
            var sql = string.Format(@" 
                        SELECT 
                            EmployeeID, EmployeeName, Gender, BirthDate, Tel, Address, E.DeptID, D.DeptName
                        FROM Employees AS E
                        LEFT JOIN Departments AS D ON E.DeptID = D.DeptID
                        WHERE D.DeptName = '{0}'", DeptName);   

            return Db.q(sql);   
        }
     
    }
} 

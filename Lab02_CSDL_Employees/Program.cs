using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
   
namespace Lab02_CSDL_Employees
{
    static class Program   
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form_MDI());  
            //  Application.Run(new Form_EmployeeDetails());
           // Application.Run(new Form_EmployeeList());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Lab02_CSDL_Employees 
{ 
    public partial class Form_MDI : Form 
    {  
        public Form_MDI()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // khai báo hàm xử lí sự kiện trên Form_MDI
            this.exitToolStripMenuItem.Click += OnClick_Exit;
            this.employeeProfilesToolStripMenuItem.Click += OnClick_EmployeeProfile; 

        }
         
        private void OnClick_EmployeeProfile(object sender, EventArgs e)
        {
            var f = new Form_EmployeeList();
            f.MdiParent = this;
            f.Show(); 
        }
         
        // thoát ứng dụng     
        private void OnClick_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

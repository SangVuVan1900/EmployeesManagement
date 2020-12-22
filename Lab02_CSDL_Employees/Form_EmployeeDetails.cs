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
    public partial class Form_EmployeeDetails : Form
    {
        public Form_EmployeeDetails()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ui_comboBox_dept.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ui_radioButton_Male.Checked = true;
            this.Shown += OnShown_FormEmployeeDetails;
            this.FormClosed += OnFormClosed_FormEmployeeDetails;

            this.ui_btn_save.Click += OnClick_Save;
            this.ui_btn_cancel.Click += OnClick_Cancel;
        }

        private void OnClick_Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnClick_Save(object sender, EventArgs e)
        {
            // Validation
            if (Validationn() != "")
            {
                MessageBox.Show
                    (Validationn(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            //sửa
            if (this.Action == "Edit" && this.RowID != null)
            {

                Employee.edit(inputData(), this.RowID);
                this.Msg = "Đã hoàn tất việc sửa";
            }
            else // thêm mới
            {
                Employee.add(inputData());
                this.Msg = "Đã hoàn tất việc THÊM mới";

            }
            MessageBox.Show(this.Msg, "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // đóng FormDetail
            this.Close();
        }

        private void OnFormClosed_FormEmployeeDetails(object sender, FormClosedEventArgs e)
        {
            // sau khi đóng FormDetail thì phải tải lại FormList
            (this.Owner as Form_EmployeeList).loadTable();
        }

        private void OnShown_FormEmployeeDetails(object sender, EventArgs e)
        {
            // đổ dữ liệu vào ComboBox trước
            this.ui_comboBox_dept.DataSource = Department.table();
            this.ui_comboBox_dept.DisplayMember = "DeptName";
            this.ui_comboBox_dept.ValueMember = "DeptID";

            // tải dữ liệu bản ghi lên FormDetail
            this.loadRow();
        }

        // các thuộc tính đặc trưng trên bản ghi FormDetails
        public string Action { get; set; }
        public string RowID { get; set; }
        public string Msg { get; set; }

        // tải dữ liệu bản ghi lên Form
        void loadRow()
        {
            // nếu là THÊM MỚI thì chấm dứt ở đây
            if (this.RowID == null)
            {
                return;
            }

            // lấy ra dữ liệu của bản ghi
            var row = Employee.row(this.RowID);

            this.ui_txt_name.Text = row["EmployeeName"].ToString();
            this.ui_txt_address.Text = row["Address"].ToString();
            this.ui_txt_tele.Text = row["Tel"].ToString();
            this.ui_dateTimePicker.Value = Convert.ToDateTime(row["BirthDate"]);

            // giới tính  
            if (row["Gender"].ToString() == "True")
            {
                this.ui_radioButton_Male.Checked = true;
                this.ui_radioButton_Female.Checked = false;
            }
            else
            {
                this.ui_radioButton_Male.Checked = false;
                this.ui_radioButton_Female.Checked = true;
            }

            // chỉnh cho ComboBox khớp với bản ghi ĐANG SỬA
            this.ui_comboBox_dept.SelectedValue = row["DeptID"];


        }

        // lưu dữ liệu nhập trên Form
        Dictionary<string, string> inputData()
        {
            var data = new Dictionary<string, string>();

            data["EmployeeName"] = this.ui_txt_name.Text;
            data["Tel"] = this.ui_txt_tele.Text;
            data["Address"] = this.ui_txt_address.Text;
            data["DeptID"] = this.ui_comboBox_dept.SelectedValue.ToString();
            data["Gender"] = this.ui_radioButton_Male.Checked ? "1" : "0";
            data["BirthDate"] = this.ui_dateTimePicker.Value.ToString("yyyyMMdd");

            return data; 
        }


        public string Validationn()
        {
            string Error = "";
            //check Textbox            
            if (ui_txt_name.Text.Length <= 5)
            {
                Error = "Name must equal or more than 5 characters";
            }
            // check Radio Button choose
            if (ui_radioButton_Female.Text == null || ui_radioButton_Female.Text == null)
            {
                Error = "You  must choose gender";
            }

            // check Year
            if (ui_dateTimePicker.Value.Year > 1999)
            {
                Error = "BirthDate must equal or bigger 1999";
            }
            // check Address
            if (ui_txt_address.Text.Length == 0)
            {
                Error = "You must input your Address into form";
            }
            //check Number input(check first Number in string)  
            if (!(ui_txt_tele.Text.Length > 6 && ui_txt_tele.Text[0] == '0'))
            {
                Error = "TelePhone must begin with 0 and more than 6 character";
            }
            return Error;
        }
    }
}

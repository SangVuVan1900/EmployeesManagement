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
    public partial class Form_EmployeeList : Form
    {
        public Form_EmployeeList()
        {
            InitializeComponent();  

            this.FormBorderStyle = FormBorderStyle.FixedSingle; 

            // tùy chỉnh giao diện 
            // đăng kí hàm xử lí sự kiện
            this.Shown += OnShown_Form_EmployeeList;
            this.ui_treeView.AfterSelect += OnAfterSelect_TreeView;

            // các sự kiện trên bảng dữ liệu
            this.ui_listView.Click += OnClick_ListView;
            this.ui_listView.DoubleClick += OnDoubleClick_ListView;

            // các sự kiện của Nút button 
            this.ui_btn_add.Click += OnClick_Add;
            this.ui_btn_close.Click += OnClick_Close;
            this.ui_btn_delete.Click += OnClick_Delete;
            this.ui_btn_edit.Click += OnClick_Edit;
            this.ui_btn_xml.Click += OnClick_XML;
            this.ui_btn_reload.Click += OnClick_Reload;

            // các sự kiện trên nút Điều Hướng
            this.ui_btn_first.Click += OnClick_First;
            this.ui_btn_last.Click += OnClick_Last;
            this.ui_btn_next.Click += OnClick_Next;
            this.ui_btn_previous.Click += OnClick_Previous;

            // trích dẫn các nút tiếng anh (tooltip)

        }// kết thúc hàm khởi tạo  

        // tải lại bảng dữ liệu sau mỗi lần tìm kiếm 
        private void OnClick_Reload(object sender, EventArgs e)
        {
            this.loadTable();
        }



        // chạy về bản  ghi trước đó
        private void OnClick_Previous(object sender, EventArgs e)
        {
            this.selectRow(this.ui_listView.FocusedItem.Index - 1);
        }

        // chạy về bản ghi tiếp theo  
        private void OnClick_Next(object sender, EventArgs e)
        {
            this.selectRow(this.ui_listView.FocusedItem.Index + 1);
        }

        // chạy về bản ghi cuối cùng
        private void OnClick_Last(object sender, EventArgs e)
        {
            this.selectRow(this.ui_listView.Items.Count - 1);
        }

        // chạy về bản ghi đầu tiên 
        private void OnClick_First(object sender, EventArgs e)
        {
            this.selectRow(0);
        }



        private void OnClick_Delete(object sender, EventArgs e)
        {
            // xác nhận việc xóa
            var yes_no = MessageBox.Show("Chắc chưa", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // xóa
            if (yes_no == DialogResult.Yes)
            {
                // var rowID = this.ui_listView.SelectedItems[0].SubItems["EmployeeID"].Text;

                Employee.delete(this.RowID);

                // tải lại bảng dữ liệu sau khi xóa 
                this.loadTable();

                // thông báo thành công
                MessageBox.Show("Đã hoàn tất việc XÓa", "Thành Kông",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


        }

        private void OnClick_XML(object sender, EventArgs e)
        {
            // hộp thoại lưu File
            var sfd = new SaveFileDialog();
            sfd.Filter = "XML Files|*.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var dt = Employee.table();
                dt.TableName = "Employee";
                dt.WriteXml(sfd.FileName);

                MessageBox.Show("Đã hoàn tất việc xuất File", "Thành Kông",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void OnClick_Edit(object sender, EventArgs e)
        {
            var f = new Form_EmployeeDetails();
            f.Owner = this;
            f.Text = "Sửa mới";
            f.Action = "Edit";
            f.RowID = this.RowID;
            f.Show();
        }

        // dóng ứng dụng
        private void OnClick_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // chuyển sang Form_Detail  để thêm mới
        private void OnClick_Add(object sender, EventArgs e)
        {
            var f = new Form_EmployeeDetails();
            f.Owner = this;
            f.Text = "Thêm mới";
            f.Show();
        }


        // khi nhấp đúp chuột vào ListView thì SỬA bản ghi 
        private void OnDoubleClick_ListView(object sender, EventArgs e)
        {
            this.ui_btn_edit.PerformClick();
        }

        private void OnClick_ListView(object sender, EventArgs e)
        {
            this.selectRow(this.ui_listView.FocusedItem.Index);
        }

        private void OnAfterSelect_TreeView(object sender, TreeViewEventArgs e)
        {
            // lọc nhân sự theo phòng ban
            var dt = Employee.searchByDeptName(this.ui_treeView.SelectedNode.Text);

            this.loadTable(dt);
        }

        private void OnShown_Form_EmployeeList(object sender, EventArgs e)
        {
            // đổ dữ liệu vào TreeView
            foreach (DataRow row in Department.table().Rows)
            {
                var node = new TreeNode();
                node.Text = row["DeptName"].ToString();

                this.ui_treeView.Nodes.Add(node);
            }
            // đổ dữ liệu vào ListView
            this.loadTable();

        }

        // các hàm phụ trợ
        // đọc ghi khóa chính của bản ghi bị bôi đen
        string RowID { get; set; }

        // tải dữ liệu bảng SQL lê ListView
        public void loadTable(DataTable dt = null)
        {
            // cấu hình ListView
            this.ui_listView.View = View.Details;
            this.ui_listView.FullRowSelect = true;
            this.ui_listView.Clear();

            // tạo cộtt
            // *** tên Cột trên ListView phải trùng tên cột trên Database
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "EmployeeID", Text = "Khóa Chính", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "EmployeeName", Text = "Tên Nhân Viên", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "DeptName", Text = "Phòng Ban", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "Gender", Text = "Giới Tính", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "BirthDate", Text = "Ngày Sanh", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "Tel", Text = "Điện Thoại", Width = 100 });
            this.ui_listView.Columns.Add(new ColumnHeader() { Name = "Address", Text = "Địa Chỉ", Width = 100 });

            //Đổ database vào ListView
            if (dt == null)
            {
                dt = Employee.table();
            }

            foreach (DataRow row in dt.Rows)
            {
                // đổ dữ liệu vào cột đầu tiên
                var item = new ListViewItem(row["EmployeeID"].ToString());
                item.SubItems[0].Name = "EmployeeID";

                // đổ dữ liệu vào các cột sau 
                item.SubItems.Add(row["EmployeeName"].ToString());
                item.SubItems.Add(row["DeptName"].ToString());
                item.SubItems.Add(row["Gender"].ToString() == "True" ? "Nam" : "Nữ"); // like php ifelse
                item.SubItems.Add(DateTime.Parse(row["BirthDate"].ToString()).ToString("dd/MM/yyyy"));// dạng ngày
                item.SubItems.Add(row["Tel"].ToString());
                item.SubItems.Add(row["Address"].ToString());

                // thêm item vào ListView
                this.ui_listView.Items.Add(item);
            }
            // chỉnh phong cách cho tất cả các cột đều vừa với nội dung
            this.ui_listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // bôi đen dòng đầu tiên

        }

        // bôi đen dòng ListView theo chỉ số
        // gán giá trị khóa Chính cho RowID
        void selectRow(int index)
        {
            // nếu không có bản ghi nào
            if (this.ui_listView.Items.Count <= 0)
            {
                //  thì Tắt các nút hành động
                this.ui_btn_edit.Enabled = false;
                this.ui_btn_delete.Enabled = false;

                // và Tắt các nút điều hướng
                this.ui_btn_first.Enabled = false;
                this.ui_btn_last.Enabled = false;
                this.ui_btn_next.Enabled = false;
                this.ui_btn_previous.Enabled = false; 

                // chấm dứt ở đây
                return;
            }
            // nếu chỉ số Index nằm ngoài phạm vi
            if (index < 0 || index >= this.ui_listView.Items.Count)
            {
                return;
            }

            // tình huống index hợp lệ
            // bỏ bôi đen các phần tử cũ
            this.ui_listView.SelectedItems.Clear();
            // bôi đen các dòng mới
            this.ui_listView.Items[index].Selected = true;
            this.ui_listView.Items[index].Focused = true;
            // di chuyển con trỏ xuống dòng bôi đen
            this.ui_listView.Select();
             
            // nếu có tối thiểu 1 bản ghi thì bật các nút sửa, xóa
            this.ui_btn_edit.Enabled = true;
            this.ui_btn_delete.Enabled = true;

            // cập nhật khóa chính của bản ghi bị bôi đen
            this.RowID = this.ui_listView.SelectedItems[0].SubItems["EmployeeID"].Text;

            // phần nâng cao: Cập nhật trạng thái của các nút điều hướng
            this.ui_btn_first.Enabled = true;
            this.ui_btn_last.Enabled = true;
            this.ui_btn_next.Enabled = true;
            this.ui_btn_previous.Enabled = true;

            // nếu đang ở bản ghi đầu tiên
            if (index == 0)
            {
                this.ui_btn_first.Enabled = false;
                this.ui_btn_previous.Enabled = false;
            }

            // nếu đnag ở  bản ghi cuối cùng
            if (index == this.ui_listView.Items.Count - 1)
            {
                this.ui_btn_next.Enabled = false;
                this.ui_btn_last.Enabled = false;
            }

        }
    }
}

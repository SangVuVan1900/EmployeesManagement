namespace Lab02_CSDL_Employees
{
    partial class Form_EmployeeList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ui_treeView = new System.Windows.Forms.TreeView();
            this.ui_listView = new System.Windows.Forms.ListView();
            this.ui_btn_add = new System.Windows.Forms.Button();
            this.ui_btn_edit = new System.Windows.Forms.Button();
            this.ui_btn_delete = new System.Windows.Forms.Button();
            this.ui_btn_xml = new System.Windows.Forms.Button();
            this.ui_btn_close = new System.Windows.Forms.Button();
            this.ui_btn_next = new System.Windows.Forms.Button();
            this.ui_btn_last = new System.Windows.Forms.Button();
            this.ui_btn_first = new System.Windows.Forms.Button();
            this.ui_btn_previous = new System.Windows.Forms.Button();
            this.ui_btn_reload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee List";
            // 
            // ui_treeView
            // 
            this.ui_treeView.Location = new System.Drawing.Point(12, 27);
            this.ui_treeView.Name = "ui_treeView";
            this.ui_treeView.Size = new System.Drawing.Size(143, 284);
            this.ui_treeView.TabIndex = 1;
            // 
            // ui_listView
            // 
            this.ui_listView.Location = new System.Drawing.Point(184, 27);
            this.ui_listView.Name = "ui_listView";
            this.ui_listView.Size = new System.Drawing.Size(571, 284);
            this.ui_listView.TabIndex = 2;
            this.ui_listView.UseCompatibleStateImageBehavior = false;
            // 
            // ui_btn_add
            // 
            this.ui_btn_add.Location = new System.Drawing.Point(12, 323);
            this.ui_btn_add.Name = "ui_btn_add";
            this.ui_btn_add.Size = new System.Drawing.Size(60, 23);
            this.ui_btn_add.TabIndex = 3;
            this.ui_btn_add.Text = "Add";
            this.ui_btn_add.UseVisualStyleBackColor = true;
            // 
            // ui_btn_edit
            // 
            this.ui_btn_edit.Location = new System.Drawing.Point(93, 323);
            this.ui_btn_edit.Name = "ui_btn_edit";
            this.ui_btn_edit.Size = new System.Drawing.Size(62, 23);
            this.ui_btn_edit.TabIndex = 4;
            this.ui_btn_edit.Text = "Edit";
            this.ui_btn_edit.UseVisualStyleBackColor = true;
            // 
            // ui_btn_delete
            // 
            this.ui_btn_delete.Location = new System.Drawing.Point(184, 323);
            this.ui_btn_delete.Name = "ui_btn_delete";
            this.ui_btn_delete.Size = new System.Drawing.Size(75, 23);
            this.ui_btn_delete.TabIndex = 5;
            this.ui_btn_delete.Text = "Delete";
            this.ui_btn_delete.UseVisualStyleBackColor = true;
            // 
            // ui_btn_xml
            // 
            this.ui_btn_xml.Location = new System.Drawing.Point(265, 323);
            this.ui_btn_xml.Name = "ui_btn_xml";
            this.ui_btn_xml.Size = new System.Drawing.Size(75, 23);
            this.ui_btn_xml.TabIndex = 6;
            this.ui_btn_xml.Text = "Export XML";
            this.ui_btn_xml.UseVisualStyleBackColor = true;
            // 
            // ui_btn_close
            // 
            this.ui_btn_close.Location = new System.Drawing.Point(346, 323);
            this.ui_btn_close.Name = "ui_btn_close";
            this.ui_btn_close.Size = new System.Drawing.Size(75, 23);
            this.ui_btn_close.TabIndex = 7;
            this.ui_btn_close.Text = "Close";
            this.ui_btn_close.UseVisualStyleBackColor = true;
            // 
            // ui_btn_next
            // 
            this.ui_btn_next.Location = new System.Drawing.Point(674, 323);
            this.ui_btn_next.Name = "ui_btn_next";
            this.ui_btn_next.Size = new System.Drawing.Size(37, 23);
            this.ui_btn_next.TabIndex = 8;
            this.ui_btn_next.Text = ">";
            this.ui_btn_next.UseVisualStyleBackColor = true;
            // 
            // ui_btn_last
            // 
            this.ui_btn_last.Location = new System.Drawing.Point(717, 323);
            this.ui_btn_last.Name = "ui_btn_last";
            this.ui_btn_last.Size = new System.Drawing.Size(38, 23);
            this.ui_btn_last.TabIndex = 9;
            this.ui_btn_last.Text = ">>";
            this.ui_btn_last.UseVisualStyleBackColor = true;
            // 
            // ui_btn_first
            // 
            this.ui_btn_first.Location = new System.Drawing.Point(587, 323);
            this.ui_btn_first.Name = "ui_btn_first";
            this.ui_btn_first.Size = new System.Drawing.Size(37, 23);
            this.ui_btn_first.TabIndex = 10;
            this.ui_btn_first.Text = "<<";
            this.ui_btn_first.UseVisualStyleBackColor = true;
            // 
            // ui_btn_previous
            // 
            this.ui_btn_previous.Location = new System.Drawing.Point(630, 323);
            this.ui_btn_previous.Name = "ui_btn_previous";
            this.ui_btn_previous.Size = new System.Drawing.Size(38, 23);
            this.ui_btn_previous.TabIndex = 11;
            this.ui_btn_previous.Text = "<";
            this.ui_btn_previous.UseVisualStyleBackColor = true;
            // 
            // ui_btn_reload
            // 
            this.ui_btn_reload.ForeColor = System.Drawing.Color.Blue;
            this.ui_btn_reload.Location = new System.Drawing.Point(427, 323);
            this.ui_btn_reload.Name = "ui_btn_reload";
            this.ui_btn_reload.Size = new System.Drawing.Size(75, 23);
            this.ui_btn_reload.TabIndex = 12;
            this.ui_btn_reload.Text = "Reload";
            this.ui_btn_reload.UseVisualStyleBackColor = true;
            // 
            // Form_EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 424);
            this.Controls.Add(this.ui_btn_reload);
            this.Controls.Add(this.ui_btn_previous);
            this.Controls.Add(this.ui_btn_first);
            this.Controls.Add(this.ui_btn_last);
            this.Controls.Add(this.ui_btn_next);
            this.Controls.Add(this.ui_btn_close);
            this.Controls.Add(this.ui_btn_xml);
            this.Controls.Add(this.ui_btn_delete);
            this.Controls.Add(this.ui_btn_edit);
            this.Controls.Add(this.ui_btn_add);
            this.Controls.Add(this.ui_listView);
            this.Controls.Add(this.ui_treeView);
            this.Controls.Add(this.label1);
            this.Name = "Form_EmployeeList";
            this.Text = "Form_EmployeeList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView ui_treeView;
        private System.Windows.Forms.ListView ui_listView;
        private System.Windows.Forms.Button ui_btn_add;
        private System.Windows.Forms.Button ui_btn_edit;
        private System.Windows.Forms.Button ui_btn_delete;
        private System.Windows.Forms.Button ui_btn_xml;
        private System.Windows.Forms.Button ui_btn_close;
        private System.Windows.Forms.Button ui_btn_next;
        private System.Windows.Forms.Button ui_btn_last;
        private System.Windows.Forms.Button ui_btn_first;
        private System.Windows.Forms.Button ui_btn_previous;
        private System.Windows.Forms.Button ui_btn_reload;
    }
}
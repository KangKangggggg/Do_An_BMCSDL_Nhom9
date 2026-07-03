namespace DA_BMCSDL.Presentation
{
    partial class AccountingForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TabControl tabControl;
        private TabPage tabColleagues;
        private TabPage tabSalary;
        private DataGridView dgvColleagues;
        private DataGridView dgvSalary;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnBack = new Button();
            tabControl = new TabControl();
            tabColleagues = new TabPage();
            dgvColleagues = new DataGridView();
            tabSalary = new TabPage();
            dgvSalary = new DataGridView();
            tabControl.SuspendLayout();
            tabColleagues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvColleagues).BeginInit();
            tabSalary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalary).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kế toán";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Gray;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(860, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(110, 36);
            btnBack.TabIndex = 2;
            btnBack.Text = "← Quay lại";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabColleagues);
            tabControl.Controls.Add(tabSalary);
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(20, 65);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(950, 490);
            tabControl.TabIndex = 1;
            // 
            // tabColleagues
            // 
            tabColleagues.Controls.Add(dgvColleagues);
            tabColleagues.Location = new Point(4, 33);
            tabColleagues.Name = "tabColleagues";
            tabColleagues.Padding = new Padding(10);
            tabColleagues.Size = new Size(942, 453);
            tabColleagues.TabIndex = 0;
            tabColleagues.Text = "Đồng nghiệp";
            tabColleagues.UseVisualStyleBackColor = true;
            // 
            // dgvColleagues
            // 
            dgvColleagues.AllowUserToAddRows = false;
            dgvColleagues.AllowUserToDeleteRows = false;
            dgvColleagues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColleagues.Dock = DockStyle.Fill;
            dgvColleagues.Location = new Point(10, 10);
            dgvColleagues.Name = "dgvColleagues";
            dgvColleagues.ReadOnly = true;
            dgvColleagues.RowHeadersWidth = 51;
            dgvColleagues.Size = new Size(922, 433);
            dgvColleagues.TabIndex = 0;
            // 
            // tabSalary
            // 
            tabSalary.Controls.Add(dgvSalary);
            tabSalary.Location = new Point(4, 33);
            tabSalary.Name = "tabSalary";
            tabSalary.Padding = new Padding(10);
            tabSalary.Size = new Size(942, 453);
            tabSalary.TabIndex = 1;
            tabSalary.Text = "Bảng lương";
            tabSalary.UseVisualStyleBackColor = true;
            // 
            // dgvSalary
            // 
            dgvSalary.AllowUserToAddRows = false;
            dgvSalary.AllowUserToDeleteRows = false;
            dgvSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalary.Dock = DockStyle.Fill;
            dgvSalary.Location = new Point(10, 10);
            dgvSalary.Name = "dgvSalary";
            dgvSalary.ReadOnly = true;
            dgvSalary.RowHeadersWidth = 51;
            dgvSalary.Size = new Size(922, 433);
            dgvSalary.TabIndex = 0;
            // 
            // AccountingForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 580);
            Controls.Add(btnBack);
            Controls.Add(tabControl);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "AccountingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế toán - Hệ thống Quản lý Nhân viên";
            Load += AccountingForm_Load;
            tabControl.ResumeLayout(false);
            tabColleagues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvColleagues).EndInit();
            tabSalary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
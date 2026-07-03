namespace DA_BMCSDL.Presentation
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private DataGridView dgvEmployees;
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
            dgvEmployees = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
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
            lblTitle.Text = "Trưởng phòng";
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
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(20, 65);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(950, 490);
            dgvEmployees.TabIndex = 1;
            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 580);
            Controls.Add(btnBack);
            Controls.Add(dgvEmployees);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            Name = "ManagerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trưởng phòng - Hệ thống Quản lý Nhân viên";
            Load += ManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
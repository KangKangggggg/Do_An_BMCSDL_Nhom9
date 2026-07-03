namespace HR_Management_Security
{
    partial class MainDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnViewAuditLogs = new System.Windows.Forms.Button();
            this.btnHRManagement = new System.Windows.Forms.Button();
            this.btnAccountingModule = new System.Windows.Forms.Button();
            this.btnViewCoWorkers = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1703, 76);
            this.panel1.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.Goldenrod;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWelcome.Location = new System.Drawing.Point(107, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(665, 74);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "QUẢN LÝ QUYỀN TRUY CẬP";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cornsilk;
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnViewAuditLogs);
            this.panel2.Controls.Add(this.btnHRManagement);
            this.panel2.Controls.Add(this.btnAccountingModule);
            this.panel2.Controls.Add(this.btnViewCoWorkers);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 735);
            this.panel2.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Location = new System.Drawing.Point(0, 635);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(293, 100);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnViewAuditLogs
            // 
            this.btnViewAuditLogs.BackColor = System.Drawing.Color.Lavender;
            this.btnViewAuditLogs.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAuditLogs.Location = new System.Drawing.Point(0, 335);
            this.btnViewAuditLogs.Name = "btnViewAuditLogs";
            this.btnViewAuditLogs.Size = new System.Drawing.Size(293, 100);
            this.btnViewAuditLogs.TabIndex = 3;
            this.btnViewAuditLogs.Text = "Xem Nhật Ký";
            this.btnViewAuditLogs.UseVisualStyleBackColor = false;
            this.btnViewAuditLogs.Click += new System.EventHandler(this.btnViewAuditLogs_Click);
            // 
            // btnHRManagement
            // 
            this.btnHRManagement.BackColor = System.Drawing.Color.Lavender;
            this.btnHRManagement.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHRManagement.Location = new System.Drawing.Point(0, 485);
            this.btnHRManagement.Name = "btnHRManagement";
            this.btnHRManagement.Size = new System.Drawing.Size(293, 100);
            this.btnHRManagement.TabIndex = 2;
            this.btnHRManagement.Text = "Quản Lý Nhân Sự";
            this.btnHRManagement.UseVisualStyleBackColor = false;
            this.btnHRManagement.Click += new System.EventHandler(this.btnHRManagement_Click);
            // 
            // btnAccountingModule
            // 
            this.btnAccountingModule.BackColor = System.Drawing.Color.Lavender;
            this.btnAccountingModule.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountingModule.Location = new System.Drawing.Point(0, 185);
            this.btnAccountingModule.Name = "btnAccountingModule";
            this.btnAccountingModule.Size = new System.Drawing.Size(293, 100);
            this.btnAccountingModule.TabIndex = 1;
            this.btnAccountingModule.Text = "Phòng Kế Toán";
            this.btnAccountingModule.UseVisualStyleBackColor = false;
            this.btnAccountingModule.Click += new System.EventHandler(this.btnAccountingModule_Click);
            // 
            // btnViewCoWorkers
            // 
            this.btnViewCoWorkers.BackColor = System.Drawing.Color.Lavender;
            this.btnViewCoWorkers.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCoWorkers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnViewCoWorkers.Location = new System.Drawing.Point(0, 35);
            this.btnViewCoWorkers.Name = "btnViewCoWorkers";
            this.btnViewCoWorkers.Size = new System.Drawing.Size(293, 100);
            this.btnViewCoWorkers.TabIndex = 0;
            this.btnViewCoWorkers.Text = "Xem Đồng Nghiệp";
            this.btnViewCoWorkers.UseVisualStyleBackColor = false;
            this.btnViewCoWorkers.Click += new System.EventHandler(this.btnViewCoWorkers_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Cornsilk;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelContent.Location = new System.Drawing.Point(292, 76);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1411, 735);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1703, 811);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainDashboard";
            this.Text = "MainDashBoard";
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewAuditLogs;
        private System.Windows.Forms.Button btnHRManagement;
        private System.Windows.Forms.Button btnAccountingModule;
        private System.Windows.Forms.Button btnViewCoWorkers;
        private System.Windows.Forms.Panel panelContent;
    }
}
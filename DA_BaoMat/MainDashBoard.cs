using System;
using System.Windows.Forms;

namespace HR_Management_Security
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Nhân viên: {UserSession.FullName} | Tài khoản: {UserSession.OracleUser} | Chức vụ: {UserSession.Position}";

            btnViewCoWorkers.Visible = true;

            if (UserSession.DepartmentID == 3 || UserSession.Position == "MANAGER")
            {
                btnAccountingModule.Visible = true;
            }
            else
            {
                btnAccountingModule.Visible = false;
            }

            if (UserSession.DepartmentID == 2)
            {
                btnHRManagement.Visible = true;

                if (UserSession.Position == "MANAGER")
                {
                    btnViewAuditLogs.Visible = true;
                }
                else
                {
                    btnViewAuditLogs.Visible = false;
                }
            }
            else
            {
                btnHRManagement.Visible = false;
                btnViewAuditLogs.Visible = false;
            }
        }

        private void ShowFormInPanel(UserControl userControl)
        {
            panelContent.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnViewCoWorkers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang tải Module xem đồng nghiệp cùng phòng", "Tích hợp");
        }

        private void btnAccountingModule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang tải Module xem lương/mã thuế toàn công ty", "Tích hợp");
        }

        private void btnHRManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang tải Module chỉnh sửa nhân sự (CRUD)", "Tích hợp");
        }

        private void btnViewAuditLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang tải Module giám sát Audit Log", "Tích hợp");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.Clear();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
        }
        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
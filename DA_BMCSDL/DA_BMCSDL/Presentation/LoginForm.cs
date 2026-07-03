using DA_BMCSDL.Business;
using DA_BMCSDL.Data;
using DA_BMCSDL.Presentation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DA_BMCSDL
{
    public partial class Login : Form
    {
        // Ánh xạ: Oracle username → (role, dept_id)
        private readonly Dictionary<string, (string role, int deptId)> _userMap
            = new Dictionary<string, (string, int)>
            {
                { "tp_it",      ("MANAGER",    1) },  // Trưởng phòng IT — dept 1
                { "ke_toan_a",  ("ACCOUNTING", 3) },  // Kế toán — dept 3 
            };

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim().ToLower();
            string pass = txtPassword.Text;

            lblError.Text = "";

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            // Bước 1: kiểm tra Oracle có chấp nhận user/pass không
            if (!OracleHelper.TestLogin(user, pass))
            {
                lblError.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                return;
            }

            // Bước 2: xác định role
            if (!_userMap.ContainsKey(user))
            {
                lblError.Text = "Tài khoản chưa được cấu hình role!";
                return;
            }

            var (role, deptId) = _userMap[user];
            var service = new EmployeeService(user, pass, role, deptId);

            // Bước 3: mở form tương ứng theo role
            if (role == "MANAGER")
            {
                new ManagerForm(service, user, deptId, this).Show();
                this.Hide();
            }
            else if (role == "ACCOUNTING")
            {
                new AccountingForm(service, user, this).Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
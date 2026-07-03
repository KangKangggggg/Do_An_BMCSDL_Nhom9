using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using DA_BaoMat;

namespace HR_Management_Security
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim().ToUpper();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã tài khoản nhân viên và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }

            DataTable dt = new DataTable();
            string currentConnString = OracleConnectionManager.GetConnectionString(username, password);

            try
            {
                using (OracleConnection conn = new OracleConnection(currentConnString))
                {
                    conn.Open();

                    using (OracleCommand roleCmd = new OracleCommand("SET ROLE ALL", conn))
                    {
                        roleCmd.ExecuteNonQuery();
                    }

                    string sql = "SELECT FULLNAME, POSITION, DEPARTMENTID FROM HR_APP.EMPLOYEE WHERE ORACLEUSER = :username";
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2) { Value = username });

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    UserSession.ConnectionString = currentConnString;
                    UserSession.OracleUser = username;
                    UserSession.FullName = dt.Rows[0]["FULLNAME"].ToString();
                    UserSession.Position = dt.Rows[0]["POSITION"].ToString();
                    UserSession.DepartmentID = Convert.ToInt32(dt.Rows[0]["DEPARTMENTID"]);

                    MessageBox.Show($"Xác thực thành công! Xin chào {UserSession.FullName}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainDashboard dashboard = new MainDashboard();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hợp lệ trên Database nhưng hồ sơ nhân viên không tồn tại trong hệ thống quản lý!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                SecurityErrorForm.ShowError("Đăng nhập hệ thống hoặc kích hoạt quyền thất bại!", ex.Message);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
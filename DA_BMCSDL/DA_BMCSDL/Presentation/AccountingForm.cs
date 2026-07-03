using DA_BMCSDL.Business;
using System;
using System.Windows.Forms;

namespace DA_BMCSDL.Presentation
{
    public partial class AccountingForm : Form
    {
        private readonly EmployeeService _service;
        private readonly Form _loginForm; // giữ tham chiếu form Login

        public AccountingForm(EmployeeService service, string username, Form loginForm)
        {
            InitializeComponent();
            _service = service;
            _loginForm = loginForm;
            lblTitle.Text = $"Kế toán: {username}";
        }

        private void AccountingForm_Load(object sender, EventArgs e)
        {
            LoadTab1Colleagues();
            LoadTab2Salary();
        }

        private void LoadTab1Colleagues()
        {
            try
            {
                var data = _service.GetAccountingColleagues();
                dgvColleagues.DataSource = data;

                dgvColleagues.Columns["EmpId"].HeaderText = "Mã NV";
                dgvColleagues.Columns["Name"].HeaderText = "Họ tên";
                dgvColleagues.Columns["BirthDate"].HeaderText = "Ngày sinh";
                dgvColleagues.Columns["Email"].HeaderText = "Email";
                dgvColleagues.Columns["DeptId"].Visible = false;
                dgvColleagues.Columns["DeptName"].HeaderText = "Phòng ban";
                dgvColleagues.Columns["Salary"].Visible = false;
                dgvColleagues.Columns["TaxCode"].Visible = false;

            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi quyền truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab2Salary()
        {
            try
            {
                var data = _service.GetSalaryReport();
                dgvSalary.DataSource = data;

                dgvSalary.Columns["EmpId"].HeaderText = "Mã NV";
                dgvSalary.Columns["Salary"].HeaderText = "Lương (VNĐ)";
                dgvSalary.Columns["TaxCode"].HeaderText = "Mã số thuế";

                dgvSalary.Columns["Salary"].DefaultCellStyle.Format = "N0";
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi quyền truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _loginForm.Show(); // hiện lại form Login
            this.Close();      // đóng form này
        }
    }
}
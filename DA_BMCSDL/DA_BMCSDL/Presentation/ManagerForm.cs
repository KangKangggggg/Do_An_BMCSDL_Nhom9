using DA_BMCSDL.Business;
using System;
using System.Windows.Forms;

namespace DA_BMCSDL.Presentation
{
    public partial class ManagerForm : Form
    {
        private readonly EmployeeService _service;
        private readonly Form _loginForm; // giữ tham chiếu form Login

        public ManagerForm(EmployeeService service, string username, int deptId, Form loginForm)
        {
            InitializeComponent();
            _service = service;
            _loginForm = loginForm;
            lblTitle.Text = $"Trưởng phòng: {username}  |  Phòng: {deptId}";
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _service.GetManagerView();
                dgvEmployees.DataSource = data;

                dgvEmployees.Columns["EmpId"].HeaderText = "Mã NV";
                dgvEmployees.Columns["Name"].HeaderText = "Họ tên";
                dgvEmployees.Columns["BirthDate"].HeaderText = "Ngày sinh";
                dgvEmployees.Columns["Email"].HeaderText = "Email";
                dgvEmployees.Columns["DeptId"].Visible = false;
                dgvEmployees.Columns["DeptName"].HeaderText = "Phòng ban";
                dgvEmployees.Columns["Salary"].HeaderText = "Lương (VNĐ)";
                dgvEmployees.Columns["TaxCode"].HeaderText = "Mã số thuế";

                dgvEmployees.Columns["Salary"].DefaultCellStyle.Format = "N0";
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi quyền truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _loginForm.Show(); 
            this.Close();      
        }
    }
}
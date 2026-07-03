using System;
using System.Drawing;
using System.Windows.Forms;

namespace HR_Management_Security 
{
    public partial class SecurityErrorForm : Form
    {
        public SecurityErrorForm()
        {
            InitializeComponent();
            btnClose.Click += btnClose_Click;
            if (btnClose.Image != null)
            {
                btnClose.Image = new Bitmap(btnClose.Image, new Size(24, 24));
            }
        }

        public static void ShowError(string contextMessage, string oracleErrorMessage)
        {
            using (SecurityErrorForm form = new SecurityErrorForm())
            {
                form.Text = "Hệ Thống Kiểm Soát Truy Cập";
                if (form.Controls.ContainsKey("txtErrorDetails"))
                {
                    form.Controls["txtErrorDetails"].Text = oracleErrorMessage;
                }
                form.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SecurityErrorForm_Load(object sender, EventArgs e)
        {
        }
    }
}
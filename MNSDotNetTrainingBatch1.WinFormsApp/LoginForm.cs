using Microsoft.Data.SqlClient;
using System.Data;

namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    public partial class LoginForm : Form
    {
        SqlService _sqlServices;
        public LoginForm()
        {
            InitializeComponent();
            _sqlServices = new SqlService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string query = "select * from Tbl_User where @Username = Username and @Password = Password";

            DataTable dt = _sqlServices.Query(query,
                                              new SqlParameter("@Username", username),
                                              new SqlParameter("@Password", password));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Login Failed!");
                return;
            }

            MessageBox.Show("Login Successful!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}

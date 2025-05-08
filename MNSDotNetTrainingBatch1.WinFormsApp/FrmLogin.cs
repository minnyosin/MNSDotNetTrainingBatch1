using Microsoft.Data.SqlClient;
using MNSDotNetTrainingBatch1.WinFormsApp.Quaries;
using System.Data;

namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        SqlService _sqlServices;
        public FrmLogin()
        {
            InitializeComponent();
            _sqlServices = new SqlService();
            txtUsername.Text = "mns";
            txtPassword.Text = "123";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            //string query = "select * from Tbl_User where @Username = Username and @Password = Password";

            DataTable dt = _sqlServices.Query(ProductQuery.Login,
                                              new SqlParameter("@Username", username),
                                              new SqlParameter("@Password", password));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Login Failed!");
                return;
            }

            MessageBox.Show("Login Successful!");

            AppSetting.CurrentUser = Convert.ToInt32(dt.Rows[0]["Id"]); // this take the login information

            txtUsername.Clear();
            txtPassword.Clear();

            this.Hide();

            FrmMenu frm= new FrmMenu();
            frm.ShowDialog();

            this.Show();

            txtUsername.Focus();
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

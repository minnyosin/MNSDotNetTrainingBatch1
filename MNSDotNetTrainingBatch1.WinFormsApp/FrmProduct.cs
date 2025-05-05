using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MNSDotNetTrainingBatch1.WinFormsApp.Quaries;
using Microsoft.Data.SqlClient;

namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmProduct : Form
    {

        private readonly SqlService _sqlService;
        public FrmProduct()
        {
            InitializeComponent();
            _sqlService = new SqlService();
        }

        private void BindData()
        {
            DataTable dt = _sqlService.Query(ProductQuery.GetAllProduct);
            dgvData.DataSource = dt;
        }
        private void ClearControls()
        {
            this.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Clear()); // GPT Code
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            decimal price = Convert.ToDecimal(textBox3.Text.Trim());
            int quantity = Convert.ToInt32(textBox4.Text.Trim());

            int result = _sqlService.Execute(ProductQuery.CreateProduct,
                new SqlParameter("@Name", name),
                new SqlParameter("@Price", price),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@CreatedDate", DateTime.Now),
                new SqlParameter("@CreatedBy", AppSetting.CurrentUser));

            BindData();
            ClearControls();

            string message = result > 0 ? "Insert Successful!" : "Insert Failed!";
            MessageBox.Show(message,
                "Inventory Control System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
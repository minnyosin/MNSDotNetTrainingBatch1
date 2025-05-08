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
using System.Diagnostics;

namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmProduct : Form
    {

        private readonly SqlService _sqlService;
        private string _productId = string.Empty;
        public FrmProduct()
        {
            InitializeComponent();
            //dgvData.AutoGenerateColumns = false;
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
            //textBox2.Clear();
            //textBox3.Clear();
            //textBox4.Clear();
            textBox2.Focus();

            btnUpdate.Visible = false;
            btnSave.Visible = true;
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

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string id = dgvData.Rows[e.RowIndex].Cells["colProductId"].Value.ToString()!;

                DataTable dt = _sqlService.Query(ProductQuery.Detail,
                    new SqlParameter("ProductId", id));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Input",
                        "Inventory Managegment System",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                textBox2.Text = dt.Rows[0]["ProductName"].ToString()!;
                textBox3.Text = dt.Rows[0]["Price"].ToString()!;
                textBox4.Text = dt.Rows[0]["Quantity"].ToString()!;

                _productId = id;

                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else if (e.ColumnIndex == 1)
            {
                string id = dgvData.Rows[e.RowIndex].Cells["colProductId"].Value.ToString()!;

                DataTable dt = _sqlService.Query(ProductQuery.Detail,
                    new SqlParameter("ProductId", id));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Input",
                        "Inventory Managegment System",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _productId = id;

                var result = MessageBox.Show("Are you sure you want to delete?",
                    "Inventory Management System", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
                int result1 = _sqlService.Execute(ProductQuery.DeleteProduct,
                    new SqlParameter("@ProductId", id));

                string message = result1 > 0 ? "Delete Successful!" : "Delete Failed!";
                MessageBox.Show(message,
                    "Inventory Management System",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                BindData();
            }

        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            decimal price = Convert.ToDecimal(textBox3.Text.Trim());
            int quantity = Convert.ToInt32(textBox4.Text.Trim());

            int result = _sqlService.Execute(ProductQuery.UpdateProduct,
                new SqlParameter("@ProductId", _productId),
                new SqlParameter("@ProductName", name),
                new SqlParameter("@Price", price),
                new SqlParameter("Quantity", quantity),
                new SqlParameter("@ModifiedDate", DateTime.Now),
                new SqlParameter("ModifiedBy", AppSetting.CurrentUser));

            _productId = string.Empty;
            BindData();
            ClearControls();

            string message = result > 0 ? "Update Successful!" : "Update Failed!";
            MessageBox.Show(message, 
                "Inventory Management System", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}
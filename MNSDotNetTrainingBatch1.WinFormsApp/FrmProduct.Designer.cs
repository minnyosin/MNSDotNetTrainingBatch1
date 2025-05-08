namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    partial class FrmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colProductId = new DataGridViewTextBoxColumn();
            colProductCode = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            btnSave = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colProductId, colProductCode, colProductName });
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Location = new Point(0, 211);
            dgvData.Margin = new Padding(4);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.Size = new Size(1400, 594);
            dgvData.TabIndex = 1;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // colProductId
            // 
            colProductId.DataPropertyName = "ProductId";
            colProductId.HeaderText = "Product Id";
            colProductId.Name = "colProductId";
            colProductId.ReadOnly = true;
            // 
            // colProductCode
            // 
            colProductCode.DataPropertyName = "ProductCode";
            colProductCode.HeaderText = "ProductCode";
            colProductCode.Name = "colProductCode";
            colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product Name";
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(13, 41);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(260, 29);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(13, 99);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(260, 29);
            textBox3.TabIndex = 4;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(13, 157);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(260, 29);
            textBox4.TabIndex = 5;
            textBox4.KeyPress += textBox3_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 16);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 21);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 74);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 21);
            label3.TabIndex = 8;
            label3.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 132);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 21);
            label4.TabIndex = 9;
            label4.Text = "Quantity:";
            // 
            // button1
            // 
            button1.Location = new Point(296, 156);
            button1.Name = "button1";
            button1.Size = new Size(82, 30);
            button1.TabIndex = 10;
            button1.Text = "&Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(384, 156);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(384, 156);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 29);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 805);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(dgvData);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FrmProduct";
            Text = "FrmProduct";
            Load += FrmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private DataGridView dgvData;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button btnSave;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnUpdate;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colProductId;
        private DataGridViewTextBoxColumn colProductCode;
        private DataGridViewTextBoxColumn colProductName;
    }
}
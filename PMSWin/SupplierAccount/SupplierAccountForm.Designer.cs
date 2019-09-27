namespace PMSWin
{
    partial class SupplierAccountForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioCtn_All = new System.Windows.Forms.RadioButton();
            this.btnSupplierAccountForm_Insert = new System.Windows.Forms.Button();
            this.radioCtn_D = new System.Windows.Forms.RadioButton();
            this.radioCtn_E = new System.Windows.Forms.RadioButton();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.panel3);
            this.pnlContent.Size = new System.Drawing.Size(1057, 600);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "供應商帳號查詢";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSupName);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.radioCtn_All);
            this.panel3.Controls.Add(this.btnSupplierAccountForm_Insert);
            this.panel3.Controls.Add(this.radioCtn_D);
            this.panel3.Controls.Add(this.radioCtn_E);
            this.panel3.Controls.Add(this.lblEmployeeID);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblOldPwd);
            this.panel3.Controls.Add(this.txtSupCode);
            this.panel3.Location = new System.Drawing.Point(10, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1017, 550);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 33);
            this.panel1.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-1, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "搜尋條件：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 242);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 306);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // radioCtn_All
            // 
            this.radioCtn_All.AutoSize = true;
            this.radioCtn_All.Checked = true;
            this.radioCtn_All.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioCtn_All.Location = new System.Drawing.Point(926, 122);
            this.radioCtn_All.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_All.Name = "radioCtn_All";
            this.radioCtn_All.Size = new System.Drawing.Size(66, 28);
            this.radioCtn_All.TabIndex = 24;
            this.radioCtn_All.TabStop = true;
            this.radioCtn_All.Text = "全部";
            this.radioCtn_All.UseVisualStyleBackColor = true;
            // 
            // btnSupplierAccountForm_Insert
            // 
            this.btnSupplierAccountForm_Insert.Location = new System.Drawing.Point(2, 3);
            this.btnSupplierAccountForm_Insert.Margin = new System.Windows.Forms.Padding(2);
            this.btnSupplierAccountForm_Insert.Name = "btnSupplierAccountForm_Insert";
            this.btnSupplierAccountForm_Insert.Size = new System.Drawing.Size(172, 49);
            this.btnSupplierAccountForm_Insert.TabIndex = 5;
            this.btnSupplierAccountForm_Insert.Text = "新增供應商帳號";
            this.btnSupplierAccountForm_Insert.UseVisualStyleBackColor = true;
            this.btnSupplierAccountForm_Insert.Click += new System.EventHandler(this.btnSupplierAccountForm_Insert_Click);
            // 
            // radioCtn_D
            // 
            this.radioCtn_D.AutoSize = true;
            this.radioCtn_D.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioCtn_D.Location = new System.Drawing.Point(849, 122);
            this.radioCtn_D.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_D.Name = "radioCtn_D";
            this.radioCtn_D.Size = new System.Drawing.Size(66, 28);
            this.radioCtn_D.TabIndex = 23;
            this.radioCtn_D.Text = "停用";
            this.radioCtn_D.UseVisualStyleBackColor = true;
            // 
            // radioCtn_E
            // 
            this.radioCtn_E.AutoSize = true;
            this.radioCtn_E.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioCtn_E.Location = new System.Drawing.Point(771, 122);
            this.radioCtn_E.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_E.Name = "radioCtn_E";
            this.radioCtn_E.Size = new System.Drawing.Size(66, 28);
            this.radioCtn_E.TabIndex = 22;
            this.radioCtn_E.Text = "啟用";
            this.radioCtn_E.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblEmployeeID.Location = new System.Drawing.Point(13, 122);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(124, 24);
            this.lblEmployeeID.TabIndex = 11;
            this.lblEmployeeID.Text = "供應商帳號：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(658, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "啟用狀態：";
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.AutoSize = true;
            this.lblOldPwd.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldPwd.Location = new System.Drawing.Point(370, 124);
            this.lblOldPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(105, 24);
            this.lblOldPwd.TabIndex = 12;
            this.lblOldPwd.Text = "員工姓名：";
            // 
            // txtSupCode
            // 
            this.txtSupCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtSupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupCode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSupCode.ForeColor = System.Drawing.Color.White;
            this.txtSupCode.Location = new System.Drawing.Point(141, 117);
            this.txtSupCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(205, 33);
            this.txtSupCode.TabIndex = 20;
            this.txtSupCode.TextChanged += new System.EventHandler(this.txtSupCode_TextChanged);
            // 
            // txtSupName
            // 
            this.txtSupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSupName.ForeColor = System.Drawing.Color.White;
            this.txtSupName.Location = new System.Drawing.Point(474, 117);
            this.txtSupName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(163, 33);
            this.txtSupName.TabIndex = 16;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(434, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 49);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "查詢資料";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(2, 223);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 59);
            this.panel2.TabIndex = 27;
            // 
            // SupplierAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 600);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "SupplierAccountForm";
            this.Text = "SupplierAccountForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioCtn_All;
        private System.Windows.Forms.Button btnSupplierAccountForm_Insert;
        private System.Windows.Forms.RadioButton radioCtn_D;
        private System.Windows.Forms.RadioButton radioCtn_E;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.TextBox txtSupName;
    }
}
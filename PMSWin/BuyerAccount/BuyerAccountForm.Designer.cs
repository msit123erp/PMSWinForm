namespace PMSWin
{
    partial class BuyerAccountForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuyerPersonAccountForm_Insert = new System.Windows.Forms.Button();
            this.pnlpwdData = new System.Windows.Forms.Panel();
            this.radioCtn_All = new System.Windows.Forms.RadioButton();
            this.radioCtn_D = new System.Windows.Forms.RadioButton();
            this.radioCtn_E = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlpwdData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Size = new System.Drawing.Size(1000, 600);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "員工帳號總覽";
            // 
            // btnBuyerPersonAccountForm_Insert
            // 
            this.btnBuyerPersonAccountForm_Insert.Location = new System.Drawing.Point(2, 2);
            this.btnBuyerPersonAccountForm_Insert.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuyerPersonAccountForm_Insert.Name = "btnBuyerPersonAccountForm_Insert";
            this.btnBuyerPersonAccountForm_Insert.Size = new System.Drawing.Size(172, 51);
            this.btnBuyerPersonAccountForm_Insert.TabIndex = 5;
            this.btnBuyerPersonAccountForm_Insert.Text = "新增員工帳號";
            this.btnBuyerPersonAccountForm_Insert.UseVisualStyleBackColor = true;
            this.btnBuyerPersonAccountForm_Insert.Click += new System.EventHandler(this.btnBuyerPersonAccountForm_Insert_Click);
            // 
            // pnlpwdData
            // 
            this.pnlpwdData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(209)))));
            this.pnlpwdData.Controls.Add(this.radioCtn_All);
            this.pnlpwdData.Controls.Add(this.radioCtn_D);
            this.pnlpwdData.Controls.Add(this.radioCtn_E);
            this.pnlpwdData.Controls.Add(this.label3);
            this.pnlpwdData.Controls.Add(this.txtEmpID);
            this.pnlpwdData.Controls.Add(this.txtEmpName);
            this.pnlpwdData.Controls.Add(this.lblOldPwd);
            this.pnlpwdData.Controls.Add(this.lblEmployeeID);
            this.pnlpwdData.Location = new System.Drawing.Point(10, 37);
            this.pnlpwdData.Margin = new System.Windows.Forms.Padding(2);
            this.pnlpwdData.Name = "pnlpwdData";
            this.pnlpwdData.Size = new System.Drawing.Size(980, 57);
            this.pnlpwdData.TabIndex = 9;
            // 
            // radioCtn_All
            // 
            this.radioCtn_All.AutoSize = true;
            this.radioCtn_All.Checked = true;
            this.radioCtn_All.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.radioCtn_All.Location = new System.Drawing.Point(890, 14);
            this.radioCtn_All.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_All.Name = "radioCtn_All";
            this.radioCtn_All.Size = new System.Drawing.Size(74, 32);
            this.radioCtn_All.TabIndex = 24;
            this.radioCtn_All.TabStop = true;
            this.radioCtn_All.Text = "全部";
            this.radioCtn_All.UseVisualStyleBackColor = true;
            // 
            // radioCtn_D
            // 
            this.radioCtn_D.AutoSize = true;
            this.radioCtn_D.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.radioCtn_D.Location = new System.Drawing.Point(812, 14);
            this.radioCtn_D.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_D.Name = "radioCtn_D";
            this.radioCtn_D.Size = new System.Drawing.Size(74, 32);
            this.radioCtn_D.TabIndex = 23;
            this.radioCtn_D.Text = "停用";
            this.radioCtn_D.UseVisualStyleBackColor = true;
            // 
            // radioCtn_E
            // 
            this.radioCtn_E.AutoSize = true;
            this.radioCtn_E.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.radioCtn_E.Location = new System.Drawing.Point(735, 14);
            this.radioCtn_E.Margin = new System.Windows.Forms.Padding(2);
            this.radioCtn_E.Name = "radioCtn_E";
            this.radioCtn_E.Size = new System.Drawing.Size(74, 32);
            this.radioCtn_E.TabIndex = 22;
            this.radioCtn_E.Text = "啟用";
            this.radioCtn_E.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(609, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 28);
            this.label3.TabIndex = 21;
            this.label3.Text = "啟用狀態：";
            // 
            // txtEmpID
            // 
            this.txtEmpID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtEmpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpID.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.txtEmpID.ForeColor = System.Drawing.Color.White;
            this.txtEmpID.Location = new System.Drawing.Point(135, 12);
            this.txtEmpID.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(205, 36);
            this.txtEmpID.TabIndex = 20;
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpName.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.txtEmpName.ForeColor = System.Drawing.Color.White;
            this.txtEmpName.Location = new System.Drawing.Point(473, 12);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(116, 36);
            this.txtEmpName.TabIndex = 16;
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.AutoSize = true;
            this.lblOldPwd.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldPwd.Location = new System.Drawing.Point(349, 15);
            this.lblOldPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(122, 28);
            this.lblOldPwd.TabIndex = 12;
            this.lblOldPwd.Text = "員工姓名：";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblEmployeeID.Location = new System.Drawing.Point(13, 15);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(122, 28);
            this.lblEmployeeID.TabIndex = 11;
            this.lblEmployeeID.Text = "員工帳號：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(383, 105);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 41);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "查詢資料";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 154);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(980, 330);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "搜尋條件：";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.pnlpwdData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 494);
            this.panel2.TabIndex = 11;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 106);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.btnBuyerPersonAccountForm_Insert);
            this.panel3.Location = new System.Drawing.Point(3, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(987, 57);
            this.panel3.TabIndex = 13;
            // 
            // BuyerAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BuyerAccountForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlpwdData.ResumeLayout(false);
            this.pnlpwdData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuyerPersonAccountForm_Insert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlpwdData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton radioCtn_All;
        private System.Windows.Forms.RadioButton radioCtn_D;
        private System.Windows.Forms.RadioButton radioCtn_E;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}

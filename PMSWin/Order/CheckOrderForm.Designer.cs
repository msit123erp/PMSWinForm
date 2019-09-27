namespace PMSWin
{
    partial class CheckOrderForm
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
            this.lblEdit = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxReceiver = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.tbxTel = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.tbxPhone = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.labelTotalShow = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonC = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelRole = new System.Windows.Forms.Label();
            this.buttonAgreeOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxReceiver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.lblEdit);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Size = new System.Drawing.Size(1200, 667);
            // 
            // lblEdit
            // 
            this.lblEdit.AutoSize = true;
            this.lblEdit.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEdit.Location = new System.Drawing.Point(14, 11);
            this.lblEdit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(110, 31);
            this.lblEdit.TabIndex = 13;
            this.lblEdit.Text = "編輯訂單";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSend.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonSend.Location = new System.Drawing.Point(492, 20);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(209, 71);
            this.buttonSend.TabIndex = 17;
            this.buttonSend.Text = "送出訂單";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.groupBoxReceiver);
            this.panel1.Controls.Add(this.labelTotalShow);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.buttonC);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.labelRole);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 501);
            this.panel1.TabIndex = 18;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonEdit.Location = new System.Drawing.Point(932, 260);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(209, 71);
            this.buttonEdit.TabIndex = 30;
            this.buttonEdit.Text = "編輯";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonCancel.Location = new System.Drawing.Point(932, 339);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(209, 71);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "取消訂單";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // groupBoxReceiver
            // 
            this.groupBoxReceiver.Controls.Add(this.labelName);
            this.groupBoxReceiver.Controls.Add(this.tbxAddress);
            this.groupBoxReceiver.Controls.Add(this.labelPhone);
            this.groupBoxReceiver.Controls.Add(this.tbxTel);
            this.groupBoxReceiver.Controls.Add(this.labelTel);
            this.groupBoxReceiver.Controls.Add(this.tbxPhone);
            this.groupBoxReceiver.Controls.Add(this.labelAddress);
            this.groupBoxReceiver.Controls.Add(this.tbxName);
            this.groupBoxReceiver.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBoxReceiver.Location = new System.Drawing.Point(3, 205);
            this.groupBoxReceiver.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxReceiver.Name = "groupBoxReceiver";
            this.groupBoxReceiver.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxReceiver.Size = new System.Drawing.Size(764, 286);
            this.groupBoxReceiver.TabIndex = 28;
            this.groupBoxReceiver.TabStop = false;
            this.groupBoxReceiver.Text = "收件人資料";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelName.Location = new System.Drawing.Point(34, 44);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(140, 31);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "收件人姓名:";
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(185, 215);
            this.tbxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(572, 47);
            this.tbxAddress.TabIndex = 15;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelPhone.Location = new System.Drawing.Point(102, 102);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(68, 31);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Text = "手機:";
            // 
            // tbxTel
            // 
            this.tbxTel.Location = new System.Drawing.Point(185, 158);
            this.tbxTel.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTel.Name = "tbxTel";
            this.tbxTel.Size = new System.Drawing.Size(572, 47);
            this.tbxTel.TabIndex = 14;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTel.Location = new System.Drawing.Point(102, 158);
            this.labelTel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(68, 31);
            this.labelTel.TabIndex = 9;
            this.labelTel.Text = "市話:";
            // 
            // tbxPhone
            // 
            this.tbxPhone.Location = new System.Drawing.Point(185, 96);
            this.tbxPhone.Margin = new System.Windows.Forms.Padding(4);
            this.tbxPhone.Name = "tbxPhone";
            this.tbxPhone.Size = new System.Drawing.Size(572, 47);
            this.tbxPhone.TabIndex = 13;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelAddress.Location = new System.Drawing.Point(102, 221);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(68, 31);
            this.labelAddress.TabIndex = 10;
            this.labelAddress.Text = "地址:";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(185, 38);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(572, 47);
            this.tbxName.TabIndex = 12;
            // 
            // labelTotalShow
            // 
            this.labelTotalShow.AutoSize = true;
            this.labelTotalShow.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTotalShow.Location = new System.Drawing.Point(951, 216);
            this.labelTotalShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalShow.Name = "labelTotalShow";
            this.labelTotalShow.Size = new System.Drawing.Size(38, 31);
            this.labelTotalShow.TabIndex = 27;
            this.labelTotalShow.Text = "....";
            this.labelTotalShow.Visible = false;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTotal.Location = new System.Drawing.Point(880, 216);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(68, 31);
            this.labelTotal.TabIndex = 26;
            this.labelTotal.Text = "總計:";
            this.labelTotal.Visible = false;
            // 
            // buttonC
            // 
            this.buttonC.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonC.Location = new System.Drawing.Point(932, 420);
            this.buttonC.Margin = new System.Windows.Forms.Padding(4);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(209, 71);
            this.buttonC.TabIndex = 25;
            this.buttonC.Text = "挑選其他料件";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 41);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1164, 155);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelRole.Location = new System.Drawing.Point(30, 6);
            this.labelRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(164, 31);
            this.labelRole.TabIndex = 23;
            this.labelRole.Text = "負責採購人員 ";
            // 
            // buttonAgreeOrder
            // 
            this.buttonAgreeOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAgreeOrder.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAgreeOrder.Location = new System.Drawing.Point(708, 20);
            this.buttonAgreeOrder.Name = "buttonAgreeOrder";
            this.buttonAgreeOrder.Size = new System.Drawing.Size(209, 71);
            this.buttonAgreeOrder.TabIndex = 23;
            this.buttonAgreeOrder.Text = "同意訂單";
            this.buttonAgreeOrder.UseVisualStyleBackColor = true;
            this.buttonAgreeOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAgreeOrder);
            this.panel2.Controls.Add(this.buttonSend);
            this.panel2.Location = new System.Drawing.Point(12, 543);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1168, 112);
            this.panel2.TabIndex = 19;
            // 
            // CheckOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 667);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CheckOrderForm";
            this.Text = "EditOrderForm";
            this.Load += new System.EventHandler(this.EditOrderForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxReceiver.ResumeLayout(false);
            this.groupBoxReceiver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxReceiver;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox tbxTel;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.TextBox tbxPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label labelTotalShow;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAgreeOrder;
    }
}
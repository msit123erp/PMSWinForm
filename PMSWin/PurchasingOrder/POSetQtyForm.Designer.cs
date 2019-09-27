namespace PMSWin.PurchasingOrder
{
    partial class POSetQtyForm
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
            this.btnPickupPart = new System.Windows.Forms.Button();
            this.lblNavText = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPartSpec = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPartName = new System.Windows.Forms.Label();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbSourceList = new System.Windows.Forms.ComboBox();
            this.btnAddToPO = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblPODCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.lblPODCount);
            this.pnlContent.Controls.Add(this.lblNavText);
            this.pnlContent.Size = new System.Drawing.Size(1006, 723);
            // 
            // btnPickupPart
            // 
            this.btnPickupPart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPickupPart.Location = new System.Drawing.Point(522, 22);
            this.btnPickupPart.Name = "btnPickupPart";
            this.btnPickupPart.Size = new System.Drawing.Size(199, 55);
            this.btnPickupPart.TabIndex = 0;
            this.btnPickupPart.Text = "挑選其他料件";
            this.btnPickupPart.UseVisualStyleBackColor = true;
            this.btnPickupPart.Click += new System.EventHandler(this.btnPickupPart_Click);
            // 
            // lblNavText
            // 
            this.lblNavText.AutoSize = true;
            this.lblNavText.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNavText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNavText.Location = new System.Drawing.Point(26, 20);
            this.lblNavText.Name = "lblNavText";
            this.lblNavText.Size = new System.Drawing.Size(428, 31);
            this.lblNavText.TabIndex = 1;
            this.lblNavText.Text = "新增採購單 > 設定貨源清單及採購數量";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblUnitPrice);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblPartSpec);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPartName);
            this.groupBox1.Controls.Add(this.lblPartNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(25, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 271);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "料件資料";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(132, 224);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(146, 25);
            this.lblSupplierName.TabIndex = 9;
            this.lblSupplierName.Text = "SupplierName";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 224);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 25);
            this.label11.TabIndex = 8;
            this.label11.Text = "供應商名稱";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(132, 178);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(96, 25);
            this.lblUnitPrice.TabIndex = 7;
            this.lblUnitPrice.Text = "UnitPrice";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "料件單價";
            // 
            // lblPartSpec
            // 
            this.lblPartSpec.AutoSize = true;
            this.lblPartSpec.Location = new System.Drawing.Point(132, 132);
            this.lblPartSpec.Name = "lblPartSpec";
            this.lblPartSpec.Size = new System.Drawing.Size(94, 25);
            this.lblPartSpec.TabIndex = 5;
            this.lblPartSpec.Text = "PartSpec";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "料件規格";
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(132, 86);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(106, 25);
            this.lblPartName.TabIndex = 3;
            this.lblPartName.Text = "PartName";
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Location = new System.Drawing.Point(132, 40);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(127, 25);
            this.lblPartNumber.TabIndex = 2;
            this.lblPartNumber.Text = "PartNumber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "料件品名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "料件編號";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 25);
            this.label12.TabIndex = 10;
            this.label12.Text = "貨源清單";
            // 
            // cbSourceList
            // 
            this.cbSourceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceList.FormattingEnabled = true;
            this.cbSourceList.Location = new System.Drawing.Point(162, 315);
            this.cbSourceList.Name = "cbSourceList";
            this.cbSourceList.Size = new System.Drawing.Size(491, 33);
            this.cbSourceList.TabIndex = 11;
            // 
            // btnAddToPO
            // 
            this.btnAddToPO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddToPO.Location = new System.Drawing.Point(297, 22);
            this.btnAddToPO.Name = "btnAddToPO";
            this.btnAddToPO.Size = new System.Drawing.Size(184, 52);
            this.btnAddToPO.TabIndex = 3;
            this.btnAddToPO.Text = "加入採購單";
            this.btnAddToPO.UseVisualStyleBackColor = true;
            this.btnAddToPO.Click += new System.EventHandler(this.btnAddToPO_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(53, 370);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 25);
            this.label14.TabIndex = 12;
            this.label14.Text = "採購數量";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(162, 365);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(491, 34);
            this.txtQty.TabIndex = 13;
            // 
            // lblPODCount
            // 
            this.lblPODCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPODCount.AutoSize = true;
            this.lblPODCount.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPODCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPODCount.Location = new System.Drawing.Point(777, 20);
            this.lblPODCount.Name = "lblPODCount";
            this.lblPODCount.Size = new System.Drawing.Size(206, 31);
            this.lblPODCount.TabIndex = 14;
            this.lblPODCount.Text = "目前貨源清單筆數";
            this.lblPODCount.Click += new System.EventHandler(this.lblPODCount_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cbSourceList);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 502);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnPickupPart);
            this.panel2.Controls.Add(this.btnAddToPO);
            this.panel2.Location = new System.Drawing.Point(1, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(991, 93);
            this.panel2.TabIndex = 14;
            // 
            // POSetQtyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Name = "POSetQtyForm";
            this.Text = "PurchasingOrderAddPartForm";
            this.Load += new System.EventHandler(this.POSetQtyForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPickupPart;
        private System.Windows.Forms.Label lblNavText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.Label lblPartSpec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSourceList;
        private System.Windows.Forms.Button btnAddToPO;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPODCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
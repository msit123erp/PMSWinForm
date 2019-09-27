namespace PMSWin
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.pbAccount = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnFrontPage = new System.Windows.Forms.Button();
            this.btnBuyerAccount = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnPurchasingOrder = new System.Windows.Forms.Button();
            this.btnSourceList = new System.Windows.Forms.Button();
            this.btnPart = new System.Windows.Forms.Button();
            this.btnSupplierAccount = new System.Windows.Forms.Button();
            this.pnlMenuHighlight = new System.Windows.Forms.Panel();
            this.btnSupplierInfo = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.pnlHeader.Controls.Add(this.lblLogout);
            this.pnlHeader.Controls.Add(this.pbAccount);
            this.pnlHeader.Controls.Add(this.lblCompanyName);
            this.pnlHeader.Controls.Add(this.pbLogo);
            this.pnlHeader.Controls.Add(this.lblSystemName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1006, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblLogout
            // 
            this.lblLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("微軟正黑體", 13.74545F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(939, 67);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(48, 24);
            this.lblLogout.TabIndex = 4;
            this.lblLogout.Text = "登出";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
            // 
            // pbAccount
            // 
            this.pbAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAccount.Image = ((System.Drawing.Image)(resources.GetObject("pbAccount.Image")));
            this.pbAccount.Location = new System.Drawing.Point(933, 16);
            this.pbAccount.Name = "pbAccount";
            this.pbAccount.Size = new System.Drawing.Size(61, 49);
            this.pbAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAccount.TabIndex = 3;
            this.pbAccount.TabStop = false;
            this.pbAccount.Click += new System.EventHandler(this.pbAccount_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("微軟正黑體", 18.32727F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblCompanyName.Location = new System.Drawing.Point(115, 6);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(140, 32);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "昶興自行車";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 2;
            this.pbLogo.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("微軟正黑體", 28.14545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.lblSystemName.Location = new System.Drawing.Point(109, 45);
            this.lblSystemName.Margin = new System.Windows.Forms.Padding(0);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(321, 48);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "B2B採購管理系統";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.pnlMenu.Controls.Add(this.btnFrontPage);
            this.pnlMenu.Controls.Add(this.btnBuyerAccount);
            this.pnlMenu.Controls.Add(this.btnOrder);
            this.pnlMenu.Controls.Add(this.btnPurchasingOrder);
            this.pnlMenu.Controls.Add(this.btnSourceList);
            this.pnlMenu.Controls.Add(this.btnPart);
            this.pnlMenu.Controls.Add(this.btnSupplierAccount);
            this.pnlMenu.Controls.Add(this.pnlMenuHighlight);
            this.pnlMenu.Controls.Add(this.btnSupplierInfo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 100);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 556);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnFrontPage
            // 
            this.btnFrontPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnFrontPage.FlatAppearance.BorderSize = 0;
            this.btnFrontPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrontPage.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFrontPage.ForeColor = System.Drawing.Color.White;
            this.btnFrontPage.Location = new System.Drawing.Point(20, 0);
            this.btnFrontPage.Name = "btnFrontPage";
            this.btnFrontPage.Size = new System.Drawing.Size(180, 60);
            this.btnFrontPage.TabIndex = 3;
            this.btnFrontPage.Tag = "";
            this.btnFrontPage.Text = "首頁";
            this.btnFrontPage.UseVisualStyleBackColor = false;
            this.btnFrontPage.Click += new System.EventHandler(this.btnFrontPage_Click_1);
            // 
            // btnBuyerAccount
            // 
            this.btnBuyerAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnBuyerAccount.FlatAppearance.BorderSize = 0;
            this.btnBuyerAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyerAccount.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBuyerAccount.ForeColor = System.Drawing.Color.White;
            this.btnBuyerAccount.Location = new System.Drawing.Point(20, 420);
            this.btnBuyerAccount.Name = "btnBuyerAccount";
            this.btnBuyerAccount.Size = new System.Drawing.Size(180, 60);
            this.btnBuyerAccount.TabIndex = 8;
            this.btnBuyerAccount.Tag = "";
            this.btnBuyerAccount.Text = "採購人員帳號管理";
            this.btnBuyerAccount.UseVisualStyleBackColor = false;
            this.btnBuyerAccount.Click += new System.EventHandler(this.btnBuyerAccount_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(20, 360);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(180, 60);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Tag = "";
            this.btnOrder.Text = "訂單管理";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnPurchasingOrder
            // 
            this.btnPurchasingOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnPurchasingOrder.FlatAppearance.BorderSize = 0;
            this.btnPurchasingOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchasingOrder.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPurchasingOrder.ForeColor = System.Drawing.Color.White;
            this.btnPurchasingOrder.Location = new System.Drawing.Point(20, 300);
            this.btnPurchasingOrder.Name = "btnPurchasingOrder";
            this.btnPurchasingOrder.Size = new System.Drawing.Size(180, 60);
            this.btnPurchasingOrder.TabIndex = 6;
            this.btnPurchasingOrder.Tag = "";
            this.btnPurchasingOrder.Text = "採購單管理";
            this.btnPurchasingOrder.UseVisualStyleBackColor = false;
            this.btnPurchasingOrder.Click += new System.EventHandler(this.btnPurchasingOrder_Click);
            // 
            // btnSourceList
            // 
            this.btnSourceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnSourceList.FlatAppearance.BorderSize = 0;
            this.btnSourceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSourceList.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSourceList.ForeColor = System.Drawing.Color.White;
            this.btnSourceList.Location = new System.Drawing.Point(20, 240);
            this.btnSourceList.Name = "btnSourceList";
            this.btnSourceList.Size = new System.Drawing.Size(180, 60);
            this.btnSourceList.TabIndex = 5;
            this.btnSourceList.Tag = "";
            this.btnSourceList.Text = "貨源清單管理";
            this.btnSourceList.UseVisualStyleBackColor = false;
            this.btnSourceList.Click += new System.EventHandler(this.btnSourceList_Click);
            // 
            // btnPart
            // 
            this.btnPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnPart.FlatAppearance.BorderSize = 0;
            this.btnPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPart.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPart.ForeColor = System.Drawing.Color.White;
            this.btnPart.Location = new System.Drawing.Point(20, 180);
            this.btnPart.Name = "btnPart";
            this.btnPart.Size = new System.Drawing.Size(180, 60);
            this.btnPart.TabIndex = 4;
            this.btnPart.Tag = "";
            this.btnPart.Text = "料件管理";
            this.btnPart.UseVisualStyleBackColor = false;
            this.btnPart.Click += new System.EventHandler(this.btnPart_Click);
            // 
            // btnSupplierAccount
            // 
            this.btnSupplierAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnSupplierAccount.FlatAppearance.BorderSize = 0;
            this.btnSupplierAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierAccount.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSupplierAccount.ForeColor = System.Drawing.Color.White;
            this.btnSupplierAccount.Location = new System.Drawing.Point(20, 120);
            this.btnSupplierAccount.Name = "btnSupplierAccount";
            this.btnSupplierAccount.Size = new System.Drawing.Size(180, 60);
            this.btnSupplierAccount.TabIndex = 3;
            this.btnSupplierAccount.Tag = "";
            this.btnSupplierAccount.Text = "供應商帳號管理";
            this.btnSupplierAccount.UseVisualStyleBackColor = false;
            this.btnSupplierAccount.Click += new System.EventHandler(this.btnSupplierAccount_Click);
            // 
            // pnlMenuHighlight
            // 
            this.pnlMenuHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(213)))), ((int)(((byte)(143)))));
            this.pnlMenuHighlight.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuHighlight.Name = "pnlMenuHighlight";
            this.pnlMenuHighlight.Size = new System.Drawing.Size(20, 60);
            this.pnlMenuHighlight.TabIndex = 3;
            // 
            // btnSupplierInfo
            // 
            this.btnSupplierInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.btnSupplierInfo.FlatAppearance.BorderSize = 0;
            this.btnSupplierInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierInfo.Font = new System.Drawing.Font("微軟正黑體", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSupplierInfo.ForeColor = System.Drawing.Color.White;
            this.btnSupplierInfo.Location = new System.Drawing.Point(20, 60);
            this.btnSupplierInfo.Name = "btnSupplierInfo";
            this.btnSupplierInfo.Size = new System.Drawing.Size(180, 60);
            this.btnSupplierInfo.TabIndex = 2;
            this.btnSupplierInfo.Tag = "";
            this.btnSupplierInfo.Text = "供應商公司管理";
            this.btnSupplierInfo.UseVisualStyleBackColor = false;
            this.btnSupplierInfo.Click += new System.EventHandler(this.btnSupplierInfo_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(200, 100);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(806, 556);
            this.pnlContainer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 656);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.PictureBox pbAccount;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnPurchasingOrder;
        private System.Windows.Forms.Button btnSourceList;
        private System.Windows.Forms.Button btnPart;
        private System.Windows.Forms.Button btnSupplierAccount;
        private System.Windows.Forms.Panel pnlMenuHighlight;
        private System.Windows.Forms.Button btnSupplierInfo;
        private System.Windows.Forms.Button btnBuyerAccount;
        private System.Windows.Forms.Button btnFrontPage;
        public System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlHeader;
        protected System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblLogout;
    }
}
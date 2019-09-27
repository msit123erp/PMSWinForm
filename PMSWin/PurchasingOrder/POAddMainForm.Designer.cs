namespace PMSWin.PurchasingOrder
{
    partial class POAddMainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPickupPart = new System.Windows.Forms.Button();
            this.lblPODCount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSendPO = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.lblPODCount);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Size = new System.Drawing.Size(1006, 723);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "新增採購單";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(19, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(944, 420);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnPickupPart
            // 
            this.btnPickupPart.Location = new System.Drawing.Point(19, 14);
            this.btnPickupPart.Name = "btnPickupPart";
            this.btnPickupPart.Size = new System.Drawing.Size(159, 51);
            this.btnPickupPart.TabIndex = 2;
            this.btnPickupPart.Text = "選取料件";
            this.btnPickupPart.UseVisualStyleBackColor = true;
            this.btnPickupPart.Click += new System.EventHandler(this.btnPickupPart_Click);
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
            this.lblPODCount.TabIndex = 15;
            this.lblPODCount.Text = "目前貨源清單筆數";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(19, 87);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 25);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total";
            // 
            // btnSendPO
            // 
            this.btnSendPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendPO.Location = new System.Drawing.Point(816, 16);
            this.btnSendPO.Name = "btnSendPO";
            this.btnSendPO.Size = new System.Drawing.Size(147, 49);
            this.btnSendPO.TabIndex = 17;
            this.btnSendPO.Text = "送出採購單";
            this.btnSendPO.UseVisualStyleBackColor = true;
            this.btnSendPO.Click += new System.EventHandler(this.btnSendPO_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnPickupPart);
            this.panel1.Controls.Add(this.btnSendPO);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 590);
            this.panel1.TabIndex = 18;
            // 
            // POAddMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Name = "POAddMainForm";
            this.Text = "POAddForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPickupPart;
        private System.Windows.Forms.Label lblPODCount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSendPO;
        private System.Windows.Forms.Panel panel1;
    }
}
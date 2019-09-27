namespace PMSWin.PersonAccount
{
    partial class BuyerPersonAccountForm_ChangePwd
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
            this.pnlpwdData = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnltxtboxHighlight = new System.Windows.Forms.Panel();
            this.txtNewPwdAgain = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.lblEmployeeID_data = new System.Windows.Forms.Label();
            this.lblNewPwdAgain = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.lblOldPwd = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlpwdData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.pnlpwdData);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Size = new System.Drawing.Size(742, 425);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "修改密碼";
            // 
            // pnlpwdData
            // 
            this.pnlpwdData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(236)))), ((int)(((byte)(209)))));
            this.pnlpwdData.Controls.Add(this.button1);
            this.pnlpwdData.Controls.Add(this.pnltxtboxHighlight);
            this.pnlpwdData.Controls.Add(this.txtNewPwdAgain);
            this.pnlpwdData.Controls.Add(this.txtNewPwd);
            this.pnlpwdData.Controls.Add(this.txtOldPwd);
            this.pnlpwdData.Controls.Add(this.lblEmployeeID_data);
            this.pnlpwdData.Controls.Add(this.lblNewPwdAgain);
            this.pnlpwdData.Controls.Add(this.lblNewPwd);
            this.pnlpwdData.Controls.Add(this.lblOldPwd);
            this.pnlpwdData.Controls.Add(this.lblEmployeeID);
            this.pnlpwdData.Location = new System.Drawing.Point(17, 50);
            this.pnlpwdData.Margin = new System.Windows.Forms.Padding(2);
            this.pnlpwdData.Name = "pnlpwdData";
            this.pnlpwdData.Size = new System.Drawing.Size(619, 268);
            this.pnlpwdData.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 212);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 41);
            this.button1.TabIndex = 20;
            this.button1.Text = "確認修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnltxtboxHighlight
            // 
            this.pnltxtboxHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(213)))), ((int)(((byte)(143)))));
            this.pnltxtboxHighlight.Location = new System.Drawing.Point(231, 100);
            this.pnltxtboxHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.pnltxtboxHighlight.Name = "pnltxtboxHighlight";
            this.pnltxtboxHighlight.Size = new System.Drawing.Size(218, 4);
            this.pnltxtboxHighlight.TabIndex = 19;
            // 
            // txtNewPwdAgain
            // 
            this.txtNewPwdAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtNewPwdAgain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPwdAgain.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.txtNewPwdAgain.ForeColor = System.Drawing.Color.White;
            this.txtNewPwdAgain.Location = new System.Drawing.Point(231, 153);
            this.txtNewPwdAgain.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPwdAgain.Name = "txtNewPwdAgain";
            this.txtNewPwdAgain.PasswordChar = '*';
            this.txtNewPwdAgain.Size = new System.Drawing.Size(219, 36);
            this.txtNewPwdAgain.TabIndex = 18;
            this.txtNewPwdAgain.TextChanged += new System.EventHandler(this.txtNewPwdAgain_TextChanged);
            this.txtNewPwdAgain.MouseEnter += new System.EventHandler(this.txtNewPwdAgain_MouseEnter);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPwd.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.txtNewPwd.ForeColor = System.Drawing.Color.White;
            this.txtNewPwd.Location = new System.Drawing.Point(231, 109);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(219, 36);
            this.txtNewPwd.TabIndex = 17;
            this.txtNewPwd.TextChanged += new System.EventHandler(this.txtNewPwd_TextChanged);
            this.txtNewPwd.MouseEnter += new System.EventHandler(this.txtNewPwd_MouseEnter);
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.txtOldPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPwd.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.txtOldPwd.ForeColor = System.Drawing.Color.White;
            this.txtOldPwd.Location = new System.Drawing.Point(231, 65);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(219, 36);
            this.txtOldPwd.TabIndex = 16;
            this.txtOldPwd.TextChanged += new System.EventHandler(this.txtOldPwd_TextChanged);
            this.txtOldPwd.MouseEnter += new System.EventHandler(this.txtOldPwd_MouseEnter);
            // 
            // lblEmployeeID_data
            // 
            this.lblEmployeeID_data.AutoSize = true;
            this.lblEmployeeID_data.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployeeID_data.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblEmployeeID_data.ForeColor = System.Drawing.Color.Black;
            this.lblEmployeeID_data.Location = new System.Drawing.Point(226, 29);
            this.lblEmployeeID_data.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeID_data.Name = "lblEmployeeID_data";
            this.lblEmployeeID_data.Size = new System.Drawing.Size(218, 28);
            this.lblEmployeeID_data.TabIndex = 15;
            this.lblEmployeeID_data.Text = "lblEmployeeID_data";
            // 
            // lblNewPwdAgain
            // 
            this.lblNewPwdAgain.AutoSize = true;
            this.lblNewPwdAgain.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNewPwdAgain.Location = new System.Drawing.Point(85, 153);
            this.lblNewPwdAgain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPwdAgain.Name = "lblNewPwdAgain";
            this.lblNewPwdAgain.Size = new System.Drawing.Size(133, 28);
            this.lblNewPwdAgain.TabIndex = 14;
            this.lblNewPwdAgain.Text = "確認新密碼 :";
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.AutoSize = true;
            this.lblNewPwd.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNewPwd.Location = new System.Drawing.Point(131, 112);
            this.lblNewPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(89, 28);
            this.lblNewPwd.TabIndex = 13;
            this.lblNewPwd.Text = "新密碼 :";
            // 
            // lblOldPwd
            // 
            this.lblOldPwd.AutoSize = true;
            this.lblOldPwd.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldPwd.Location = new System.Drawing.Point(131, 70);
            this.lblOldPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOldPwd.Name = "lblOldPwd";
            this.lblOldPwd.Size = new System.Drawing.Size(89, 28);
            this.lblOldPwd.TabIndex = 12;
            this.lblOldPwd.Text = "舊密碼 :";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblEmployeeID.Location = new System.Drawing.Point(108, 28);
            this.lblEmployeeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(111, 28);
            this.lblEmployeeID.TabIndex = 11;
            this.lblEmployeeID.Text = "員工編號 :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 59);
            this.button2.TabIndex = 9;
            this.button2.Text = "回上一頁";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(17, 316);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 71);
            this.panel1.TabIndex = 10;
            // 
            // BuyerPersonAccountForm_ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 425);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BuyerPersonAccountForm_ChangePwd";
            this.Text = "BuyerPersonAccountForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlpwdData.ResumeLayout(false);
            this.pnlpwdData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlpwdData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmployeeID_data;
        private System.Windows.Forms.Label lblNewPwdAgain;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.Label lblOldPwd;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.TextBox txtNewPwdAgain;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Panel pnltxtboxHighlight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}
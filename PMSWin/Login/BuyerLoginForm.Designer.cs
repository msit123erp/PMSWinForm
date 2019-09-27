namespace PMSWin.Login
{
    partial class BuyerLoginForm
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
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Size = new System.Drawing.Size(784, 461);
            // 
            // btnLogin
            // 
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Size = new System.Drawing.Size(211, 60);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Size = new System.Drawing.Size(647, 36);
            // 
            // txtID
            // 
            this.txtID.ForeColor = System.Drawing.SystemColors.Window;
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Size = new System.Drawing.Size(647, 36);
            // 
            // llFormLink
            // 
            this.llFormLink.Location = new System.Drawing.Point(643, 393);
            this.llFormLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llFormLink.Size = new System.Drawing.Size(122, 28);
            this.llFormLink.Text = "供應商入口";
            // 
            // BuyerLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BuyerLoginForm";
            this.Text = "BuyerLoginForm";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
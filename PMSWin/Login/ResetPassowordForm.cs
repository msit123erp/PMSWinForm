using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSWin.Login
{
    public partial class ResetPassowordForm : Form
    {
        public ResetPassowordForm()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(250, 236, 209);
            txtPasswordOld.BackColor = Color.FromArgb(42, 73, 93);
            txtPasswordNew.BackColor = Color.FromArgb(42, 73, 93);
            txtPasswordNewConfirm.BackColor = Color.FromArgb(42, 73, 93);
            btnLogin.BackColor = Color.FromArgb(112, 177, 181);
        }
    }
}

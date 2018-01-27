using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools
{
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_bt_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main mainDlg = new Main();
            this.Hide();
            if (mainDlg.ShowDialog() == DialogResult.Cancel)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
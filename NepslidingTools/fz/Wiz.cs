using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.fz
{
    public partial class Wiz : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Wiz()
        {
            InitializeComponent();
        }

        private void wizardPage2_FinishButtonClick(object sender, CancelEventArgs e)
        {
            MessageBox.Show("aaa");
        }

        private void wizardPage1_NextButtonClick(object sender, CancelEventArgs e)
        {
            
        }
    }
}
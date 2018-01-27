using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.testModel
{
    public partial class Devsimport : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Devsimport()
        {
            InitializeComponent();
        }

        private void importdev_st_FinishClick(object sender, CancelEventArgs e)
        {
            MessageBox.Show("¹§Ï²ÄúÉè¶¨Íê±Ï");
            this.Close();
        }
    }
}
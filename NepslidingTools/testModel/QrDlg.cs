using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NepslidingTools.testModel
{
    public partial class QrDlg : Form
    {
        public QrDlg()
        {
            InitializeComponent();
        }
        public string  MyCode {get;set;}
        private void btn_OK_Click(object sender, EventArgs e)
        {
            MyCode = this.tb_code.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_cl_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void QrDlg_Load(object sender, EventArgs e)
        {
            this.Activate();

        }
    }
}

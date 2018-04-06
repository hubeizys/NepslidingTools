using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Maticsoft.Model;

namespace NepslidingTools.toolbox
{
    public partial class ADDzhForm : DevExpress.XtraEditors.XtraForm
    {
        public ADDzhForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = DTP.Value.ToString("yyyy-MM-dd HH:mm:ss");
            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            Maticsoft.Model.username us = new username()
            {
                user = txt_n.Text,
                addtime =Convert.ToDateTime(aa),
                password =txt_p.Text,
                power=txt_q.Text,

            };
            use.Add(us);
            MessageBox.Show("保存成功");
            this.Close();
        }
    }
}
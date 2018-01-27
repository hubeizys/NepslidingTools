using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using NepslidingTools.testModel;

namespace NepslidingTools.toolbox
{
    public partial class BomFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        public BomFrom()
        {
            InitializeComponent();
        }

        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            MessageBox.Show(e.Button.ButtonType.ToString());
        }

        private void BomFrom_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("ljh", typeof(String));
            dt.Columns.Add("mc", typeof(String));
            dt.Columns.Add("gdh", typeof(String));
            dt.Columns.Add("scbh", typeof(String));
            dt.Columns.Add("cc", typeof(String));
            dt.Columns.Add("sandsm", typeof(String));
            dt.Columns.Add("tm", typeof(String));
            dt.Columns.Add("clbz", typeof(String));
            dt.Columns.Add("clsj", typeof(String));
            dt.Rows.Add(new object[] { "00001", "XX零件", "123223", "312312", "1*2*3","xxx.step" ,"3213123131231"});//添加行
            dt.Rows.Add(new object[] { "00002", "XX零件", "423523", "321122", "2*2*1", "xxx.step", "3213123131232" });
            dt.Rows.Add(new object[] { "00003", "XX零件", "242123", "441212", "2*3*3", "xxx.step", "3213123131233" });

            this.main_gc.DataSource = dt;
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Show();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            TestBZFrom tbz = new TestBZFrom();
            tbz.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            TestBZFrom tbz = new TestBZFrom();
            tbz.Show();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            QueryFrom qf = new QueryFrom();
            qf.Show();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            TestBZFrom tbz = new TestBZFrom();
            tbz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
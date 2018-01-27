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
    public partial class QueryFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "QueryFrom";
        public QueryFrom()
        {
            InitializeComponent();
        }

        private void QueryFrom_Load(object sender, EventArgs e)
        {
            global.CurActive = "QueryFrom";
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;

            this.TopMost = true;
            this.Activate();

            DataTable dt = new DataTable();                                     //创建表
            dt.Columns.Add("bomNo", typeof(Int32));                             //添加列
            dt.Columns.Add("TestNo", typeof(Int32));
            dt.Columns.Add("TestLoc", typeof(String));
            dt.Columns.Add("TestTime", typeof(DateTime));
            dt.Columns.Add("step1", typeof(string));
            dt.Columns.Add("step2", typeof(string));
            dt.Columns.Add("step3", typeof(string));
            dt.Columns.Add("result", typeof(string));
            dt.Rows.Add(new object[] { 10001, 2123120, "工位1", DateTime.Now,"偏差1mm","偏差-2mm","无偏差" ,"OK"});//添加行
            dt.Rows.Add(new object[] { 10002, 2321115, "工位1", DateTime.Now, "偏差101mm", "偏差10mm", "偏差1mm", "NG"});
            dt.Rows.Add(new object[] { 10003, 3011111, "工位1", DateTime.Now, "偏差1mm", "偏差1mm", "无偏差", "OK"});
            dt.Rows.Add(new object[] { 10004, 3421112 , "工位2", DateTime.Now, "偏差1mm", "偏差1mm", "偏差-134mm", "NG"});
            query_gc.DataSource = dt;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            daochu dc = new daochu();
            dc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void query_bt_Click(object sender, EventArgs e)
        {

        }

        private void QueryFrom_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("当前激活界面是: " + this.name);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void QueryFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }
    }
}
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
    public partial class TestBZFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "TestBZFrom";
        public TestBZFrom()
        {
            InitializeComponent();
        }

        private void TestBZFrom_Load(object sender, EventArgs e)
        {
            global.CurActive = "TestBZFrom";
            Console.WriteLine("当前激活界面是: " + this.name);
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;
            Location = (Point)new Size(0, 0);
            this.TopMost = true;
            this.Activate();

            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("step", typeof(int));//添加列
            dt.Columns.Add("tool", typeof(String));
            dt.Columns.Add("testlocal", typeof(String));
            dt.Columns.Add("bzz", typeof(double));//添加列
            dt.Columns.Add("sgc", typeof(double));
            dt.Columns.Add("xgc", typeof(double));
            dt.Rows.Add(new object[] { 1, "卡尺001", "工位1" , 10, 0.12, 0.123});//添加行
            dt.Rows.Add(new object[] { 2, "卡尺011", "工位12", 10, 0.0, 1.4 });
            dt.Rows.Add(new object[] { 3, "卡尺301", "工位92", 10, 2.6, 6.23 });
            this.dataGridView1.DataSource = dt;
        }

        private void send_bt_Click(object sender, EventArgs e)
        {
        }

        private void TestBZFrom_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("当前激活界面是: " + this.name);
                Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
                this.Size = ScreenArea.Size;
                Location = (Point)new Size(0, 0);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void TestBZFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
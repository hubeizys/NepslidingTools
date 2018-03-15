using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Maticsoft.Model;

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
             textbox_ljh.Text = Program.gdvid;
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            string aa = string.Format("PN = '{0}'", textbox_ljh.Text);
            DataSet ds = use.GetList(aa);
            dgv.DataSource = ds.Tables[0];
            //global.CurActive = "TestBZFrom";
            //Console.WriteLine("当前激活界面是: " + this.name);
            ////Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            ////this.Size = ScreenArea.Size;
            //Location = (Point)new Size(0, 0);
            //this.TopMost = true;
            //this.Activate();

            //DataTable dt = new DataTable();//创建表
            //dt.Columns.Add("step", typeof(int));//添加列
            //dt.Columns.Add("tool", typeof(String));
            //dt.Columns.Add("testlocal", typeof(String));
            //dt.Columns.Add("bzz", typeof(double));//添加列
            //dt.Columns.Add("sgc", typeof(double));
            //dt.Columns.Add("xgc", typeof(double));
            //dt.Rows.Add(new object[] { 1, "卡尺001", "工位1" , 10, 0.12, 0.123});//添加行
            //dt.Rows.Add(new object[] { 2, "卡尺011", "工位12", 10, 0.0, 1.4 });
            //dt.Rows.Add(new object[] { 3, "卡尺301", "工位92", 10, 2.6, 6.23 });
            //this.dgv.DataSource = dt;
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

        private void new_bt_Click(object sender, EventArgs e)
        {
            
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            Maticsoft.Model.measures us = new measures()
            {
                step=Convert.ToInt32( bz.Text),
                Tools = bomname_tb.Text,
                position = gdno_tb.Text,
                standardv = scbh_tb.Text,
                up= sandsm_tb.Text,
                down= tm_tb.Text,
                CC= cicun_tb.Text,
                PN= textbox_ljh.Text,
            };
            use.Add(us);
            MessageBox.Show("保存成功");
            foreach (Control Ctrol in this.Controls)
            {
                if (Ctrol is TextBox)
                {
                    Ctrol.Text = "";
                }
            }
        }

        private void mdf_bt_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            Maticsoft.Model.measures us = new measures()
            {
                step = Convert.ToInt32(bz.Text),
                Tools = bomname_tb.Text,
                position = gdno_tb.Text,
                standardv = scbh_tb.Text,
                up = sandsm_tb.Text,
                down = tm_tb.Text,
                CC = cicun_tb.Text,
                PN = textbox_ljh.Text,
            };
            use.Update(us);
            MessageBox.Show("修改成功");
            foreach (Control Ctrol in this.Controls)
            {
                if (Ctrol is TextBox)
                {
                    Ctrol.Text = "";
                }
            }
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TE_DW.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["danweimc"].Value.ToString();
            bomname_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["tool"].Value.ToString();
            gdno_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["testlocal"].Value.ToString();
            scbh_tb.Text= dgv.Rows[dgv.CurrentRow.Index].Cells["bzz"].Value.ToString();
            sandsm_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["sgc"].Value.ToString();
            tm_tb.Text= dgv.Rows[dgv.CurrentRow.Index].Cells["xgc"].Value.ToString();
            cicun_tb.Text= dgv.Rows[dgv.CurrentRow.Index].Cells["cicun"].Value.ToString(); ;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Maticsoft.Model;
using DevComponents.DotNetBar.Controls;

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
                //step=Convert.ToInt32( bz.Text),
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
                if (Ctrol is TextBox||Ctrol is TextBoxX)
                {
                    Ctrol.Text = "";
                }
            }
        }

        private void mdf_bt_Click(object sender, EventArgs e)
        {
            //for (int i=0; i<dgv.Rows.Count;i++) {
            //bomname_tb.Text = dgv.Rows[0].Cells["tool"].Value.ToString();
            //gdno_tb.Text = dgv.Rows[0].Cells["testlocal"].Value.ToString();
            //scbh_tb.Text = dgv.Rows[0].Cells["bzz"].Value.ToString();
            //sandsm_tb.Text = dgv.Rows[0].Cells["sgc"].Value.ToString();
            //tm_tb.Text = dgv.Rows[0].Cells["xgc"].Value.ToString();
            //cicun_tb.Text = dgv.Rows[0].Cells["cicun"].Value.ToString();
            string st = "";

            int XH = Convert.ToInt32(dgv.Rows[0].Cells["xh"].Value);
            String TO = bomname_tb.Text;
            string PO = gdno_tb.Text;
            string ST = scbh_tb.Text;
            string SG = sandsm_tb.Text;
            string XG = tm_tb.Text;
            string CI = cicun_tb.Text;
            string LJH = textbox_ljh.Text;
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
                Maticsoft.Model.measures us = new measures()
                {
                    id=XH,
                    //step = Convert.ToInt32(bz.Text),
                    Tools = TO,
                    position = PO,
                    standardv = ST,
                    up = SG,
                    down = XG,
                    CC = CI,                   
                    PN = LJH,
                };
                use.Update(us);
           // }
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
            cicun_tb.Text= dgv.Rows[dgv.CurrentRow.Index].Cells["cicun"].Value.ToString();
            textbox_ljh.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["gjh"].Value.ToString();
        }

        private void del_bt_Click(object sender, EventArgs e)
        {
            string DR = dgv.Rows[dgv.CurrentRow.Index].Cells["xh"].Value.ToString();
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            use.Delete(Convert.ToInt32( DR));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("删除成功");
            Maticsoft.BLL.measures usec = new Maticsoft.BLL.measures();
            DataSet ds = usec.GetAllList();
            dgv.DataSource = ds.Tables[0];
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
        }
    }
}
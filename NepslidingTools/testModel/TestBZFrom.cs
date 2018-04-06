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
            //MessageBox.Show("000000");
           
            textbox_ljh.Text = Program.gdvid;
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            string aa = string.Format("PN = '{0}'ORDER BY step", textbox_ljh.Text);
            DataSet ds = use.GetList(aa);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
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
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string to = dgv.Rows[i].Cells["tool"].Value.ToString();
                string tl = dgv.Rows[i].Cells["testlocal"].Value.ToString();
                string bz = dgv.Rows[i].Cells["bzz"].Value.ToString();
                string sg = dgv.Rows[i].Cells["sgc"].Value.ToString();
                string xg = dgv.Rows[i].Cells["xgc"].Value.ToString();
                string cun = dgv.Rows[i].Cells["cicun"].Value.ToString();
                int XH = Convert.ToInt32(dgv.Rows[i].Cells["xh"].Value);
                string pn = dgv.Rows[i].Cells["gjh"].Value.ToString();
                int st =Convert.ToInt32( dgv.Rows[i].Cells["step"].Value);
                Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
                Maticsoft.Model.measures us = new measures()
                {
                    id = XH,
                    step=st,
                    Tools=to,
                    position=tl,
                    standardv=bz,
                    up=sg,
                    down=xg,
                    PN=pn,
                    CC=cun,
                };
                use.Update(us);
            }
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
            try
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
                if (Ctrol is TextBox || Ctrol is TextBoxX)
                {
                    //Ctrol.Text = "";
                        bomname_tb.Text = "";
                        gdno_tb.Text = "";
                        scbh_tb.Text = "";
                        sandsm_tb.Text = "";
                        tm_tb.Text = "";
                        cicun_tb.Text = "";
                        //textbox_ljh.Text = "";
                }
            }
                Maticsoft.BLL.measures use1 = new Maticsoft.BLL.measures();
                string aa = string.Format("PN = '{0}'ORDER BY step", textbox_ljh.Text);//ORDER BY step
                DataSet ds = use1.GetList(aa);
                dgv.DataSource = ds.Tables[0];
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells["step"].Value = row.Index + 1;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
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
                    bomname_tb.Text = "";
                    gdno_tb.Text = "";
                    scbh_tb.Text = "";
                    sandsm_tb.Text = "";
                    tm_tb.Text = "";
                    cicun_tb.Text = "";
                    textbox_ljh.Text = "";
                }
            }
            Maticsoft.BLL.measures use1 = new Maticsoft.BLL.measures();
            string aa = string.Format("PN = '{0}'ORDER BY step", textbox_ljh.Text);
            DataSet ds = use1.GetList(aa);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
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
            use.Delete(Convert.ToInt32(DR));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("删除成功");
            Maticsoft.BLL.measures usec = new Maticsoft.BLL.measures();
            DataSet ds = usec.GetAllList();
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            /*
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }*/
        }

        private void sy_bt_Click(object sender, EventArgs e)
        {
           
            int rowIndex = dgv.SelectedRows[0].Index;  //得到当前选中行的索引     

            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了");
                //MessageBox.Show("已经是第一行了!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                list.Add(dgv.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中     
            }

            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                dgv.Rows[rowIndex].Cells[j].Value = dgv.Rows[rowIndex - 1].Cells[j].Value;
                dgv.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            dgv.Rows[rowIndex - 1].Selected = true;
            dgv.Rows[rowIndex].Selected = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
            //dgv.Rows[dgv.CurrentRow.Index-1].Selected = true;
        }

        private void xy_xzh_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv.SelectedRows[0].Index;  //得到当前选中行的索引     

            if (rowIndex == dgv.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                list.Add(dgv.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中     
            }

            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                dgv.Rows[rowIndex].Cells[j].Value = dgv.Rows[rowIndex + 1].Cells[j].Value;
                dgv.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            dgv.Rows[rowIndex + 1].Selected = true;
            dgv.Rows[rowIndex].Selected = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
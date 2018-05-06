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
    public partial class TestBZFrom : Form
    {
        string name = "TestBZFrom";
        List<Maticsoft.Model.testdevice> td_lists;
        public TestBZFrom()
        {
            InitializeComponent();
        }

        public string LjHao { get; set; }

        /// <summary>
        /// 界面load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestBZFrom_Load(object sender, EventArgs e)
        {
            // 获得工具信息 并放进combox
            #region 获得所有测量工具信息
            Maticsoft.BLL.testdevice td = new Maticsoft.BLL.testdevice();
            td_lists = td.GetModelList("");
            List<string> device_lists = td_lists.ConvertAll<string>(a => a.devicename);
            //绑定推荐的数据源  
            comboBox_devs.Items.AddRange(device_lists.ToArray());
            #endregion

            //MessageBox.Show("000000");

            // textbox_ljh.Text = Program.gdvid;
            textbox_ljh.Text = LjHao;
            initdgv();
            //Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            //string aa = string.Format(" componentId = '{0}' ORDER BY step ", textbox_ljh.Text);
            //DataSet ds = use.GetListByPage2(aa, "", 0 ,100);
            //dgv.DataSource = ds.Tables[0];
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    row.Cells["step"].Value = row.Index + 1;
            //}
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

        private void allupdate()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string to = dgv.Rows[i].Cells["Tools"].Value.ToString();
                string tl = dgv.Rows[i].Cells["position"].Value.ToString();
                string bz = dgv.Rows[i].Cells["standardv"].Value.ToString();
                string sg = dgv.Rows[i].Cells["up"].Value.ToString();
                string xg = dgv.Rows[i].Cells["down"].Value.ToString();
                string cun = dgv.Rows[i].Cells["CC"].Value.ToString();
                int componentid = Convert.ToInt32( dgv.Rows[i].Cells["componentid"].Value);
                int XH = Convert.ToInt32(dgv.Rows[i].Cells["id"].Value);
                int st = Convert.ToInt32(dgv.Rows[i].Cells["step"].Value);
                int device_type = Convert.ToInt32( dgv.Rows[i].Cells["devicetype"].Value == null ? "0" : dgv.Rows[i].Cells["devicetype"].Value);
                Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
                Maticsoft.Model.measures us = new measures()
                {
                    id = XH,
                    step = st,
                    Tools = to,
                    position = tl,
                    standardv = bz,
                    up = sg,
                    down = xg,
                    componentId = componentid,
                    CC = cun,
                    devicetype = device_type,
                };
                use.Update(us);
            }
        }

        private void send_bt_Click(object sender, EventArgs e)
        {
            allupdate();
            groupBox1.Enabled = true;
            MessageBox.Show("数据已经提交");
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

        /// <summary>
        /// 
        /// 新建规矩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void new_bt_Click(object sender, EventArgs e)
        {
            try
            {
                #region 判断条件


                if (gdno_tb.Text == "")
                {
                    MessageBox.Show("请填写位置");
                    return;
                }
                if (scbh_tb.Text == "")
                {
                    MessageBox.Show("请填写标准值");
                    return;
                }
                if (sandsm_tb.Text == "")
                {
                    MessageBox.Show("请填上公差");
                    return;
                }
                if (tm_tb.Text == "")
                {
                    MessageBox.Show("请填下公差");
                    return;
                }
                if (cicun_tb.Text == "")
                {
                    MessageBox.Show("请填写尺寸");
                    return;
                }
                if (comboBox_devs.Text == "")
                {
                    MessageBox.Show("请选择工具");
                    return;
                }
                else
                {
                    int index = comboBox_devs.SelectedIndex;

                }
                #endregion
                int max_step = dgv.Rows.Count;

                Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
                Maticsoft.Model.measures us = new measures()
                {
                    // step=Convert.ToInt32( bz.Text),
                    // S Tools = bomname_tb.Text,
                    position = gdno_tb.Text,
                    standardv = scbh_tb.Text,
                    up = sandsm_tb.Text,
                    down = tm_tb.Text,
                    CC = cicun_tb.Text,
                    componentId = Convert.ToInt32(this.LjHao),
                    devicetype = this.td_lists[comboBox_devs.SelectedIndex].devicetype,
                    step = max_step + 1,
                    Tools = comboBox_devs.Text,
                };
                // MessageBox.Show(this.comboBox_devs.SelectedIndex.ToString());
                use.Add(us);
                MessageBox.Show("已经提交保存");
                gdno_tb.Text = "";
                scbh_tb.Text = "";
                sandsm_tb.Text = "";
                tm_tb.Text = "";
                cicun_tb.Text = "";
                this.initdgv();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        /// <summary>
        /// 
        /// 初始化整个表格
        /// </summary>
        private void initdgv()
        {
            Maticsoft.BLL.measures use1 = new Maticsoft.BLL.measures();
            string aa = string.Format("componentId = '{0}'ORDER BY step", LjHao);//ORDER BY step
            DataSet ds = use1.GetListByPage2(aa, "", 0, 100);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mdf_bt_Click(object sender, EventArgs e)
        {
            //for (int i=0; i<dgv.Rows.Count;i++) {
            //bomname_tb.Text = dgv.Rows[0].Cells["tool"].Value.ToString();
            //gdno_tb.Text = dgv.Rows[0].Cells["testlocal"].Value.ToString();
            //scbh_tb.Text = dgv.Rows[0].Cells["bzz"].Value.ToString();
            //sandsm_tb.Text = dgv.Rows[0].Cells["sgc"].Value.ToString();
            //tm_tb.Text = dgv.Rows[0].Cells["xgc"].Value.ToString();
            //cicun_tb.Text = dgv.Rows[0].Cells["cicun"].Value.ToString();
            #region 判断条件


            if (gdno_tb.Text == "")
            {
                MessageBox.Show("请填写位置");
                return;
            }
            if (scbh_tb.Text == "")
            {
                MessageBox.Show("请填写标准值");
                return;
            }
            if (sandsm_tb.Text == "")
            {
                MessageBox.Show("请填上公差");
                return;
            }
            if (tm_tb.Text == "")
            {
                MessageBox.Show("请填下公差");
                return;
            }
            if (cicun_tb.Text == "")
            {
                MessageBox.Show("请填写尺寸");
                return;
            }
            if (comboBox_devs.Text == "")
            {
                MessageBox.Show("请选择工具");
                return;
            }

            #endregion
            int step_index = dgv.CurrentCell.RowIndex;
            int XH = Convert.ToInt32(dgv.Rows[step_index].Cells["id"].Value);
            //String TO = bomname_tb.Text;
            string PO = gdno_tb.Text;
            string ST = scbh_tb.Text;
            string SG = sandsm_tb.Text;
            string XG = tm_tb.Text;
            string CI = cicun_tb.Text;
            // string LJH = textbox_ljh.Text;
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            Maticsoft.Model.measures us = new measures()
            {
                id = XH,
                Tools = 1.ToString(),
                position = PO,
                standardv = ST,
                up = SG,
                down = XG,
                CC = CI,
                componentId = Convert.ToInt32(this.LjHao),
                step = Convert.ToInt32(dgv.Rows[step_index].Cells["step"].Value),
                devicetype = this.td_lists[comboBox_devs.SelectedIndex].devicetype
            };
            use.Update(us);
            // }
            MessageBox.Show("修改成功");
            //Ctrol.Text = "";
            //bomname_tb.Text = "";
            gdno_tb.Text = "";
            scbh_tb.Text = "";
            sandsm_tb.Text = "";
            tm_tb.Text = "";
            cicun_tb.Text = "";
            textbox_ljh.Text = "";
            Maticsoft.BLL.measures use1 = new Maticsoft.BLL.measures();
            string aa = string.Format("componentId = '{0}'ORDER BY step", LjHao);
            DataSet ds = use1.GetListByPage2(aa, "", 0, 100);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        ///  删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_bt_Click(object sender, EventArgs e)
        {
            string DR = dgv.Rows[dgv.CurrentRow.Index].Cells["id"].Value.ToString();
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            use.Delete(Convert.ToInt32(DR));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("删除成功");
            initdgv();
            allupdate();
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            /*
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }*/
        }


        /// <summary>
        /// 上移动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sy_bt_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            int rowIndex = dgv.CurrentRow.Index;  //得到当前选中行的索引     

            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了");
                //MessageBox.Show("已经是第一行了!");
                return;
            }

            DataTable dt = this.dgv.DataSource as DataTable;
            //DataTable dt2 = dt.Copy();
            DataRow dr = dt.NewRow();
            foreach (DataColumn aDataColumn in dt.Columns)
            {
                dr[aDataColumn.ColumnName] = dt.Rows[rowIndex][aDataColumn.ColumnName];
            }
            dt.Rows.RemoveAt(dgv.CurrentRow.Index);
            dt.Rows.InsertAt(dr, rowIndex - 1);
            this.dgv.Rows[rowIndex - 1].Selected = true;
            this.dgv.CurrentCell = this.dgv.Rows[rowIndex - 1].Cells[this.dgv.CurrentCell.ColumnIndex];

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
            return;
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

        /// <summary>
        /// 下移动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xy_xzh_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            int rowIndex = dgv.SelectedRows[0].Index;  //得到当前选中行的索引     

            if (rowIndex == dgv.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!");
                return;
            }
            DataTable dt = this.dgv.DataSource as DataTable;
            DataRow dr = dt.NewRow();
            foreach (DataColumn aDataColumn in dt.Columns)
            {
                dr[aDataColumn.ColumnName] = dt.Rows[rowIndex][aDataColumn.ColumnName];
            }
            dt.Rows.RemoveAt(dgv.CurrentRow.Index);
            dt.Rows.InsertAt(dr, rowIndex + 1);
            this.dgv.Rows[rowIndex + 1].Selected = true;
            this.dgv.CurrentCell = this.dgv.Rows[rowIndex + 1].Cells[this.dgv.CurrentCell.ColumnIndex];

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }
            return;
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

        private void textbox_ljh_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TE_DW.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["danweimc"].Value.ToString();
            //bomname_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["Tools"].Value.ToString();
            gdno_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["position"].Value.ToString();
            scbh_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["standardv"].Value.ToString();
            sandsm_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["up"].Value.ToString();
            tm_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["down"].Value.ToString();
            cicun_tb.Text = dgv.Rows[dgv.CurrentRow.Index].Cells["CC"].Value.ToString();
        }

        private void comboBox_devs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ofg_cad.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
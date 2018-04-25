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
        List<Maticsoft.Model.testdevice> td_lists;
        public TestBZFrom()
        {
            InitializeComponent();
        }

        public string LjHao { get; set; }

        /// <summary>
        /// ����load�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestBZFrom_Load(object sender, EventArgs e)
        {
            // ��ù�����Ϣ ���Ž�combox
            #region ������в���������Ϣ
            Maticsoft.BLL.testdevice td = new Maticsoft.BLL.testdevice();
            td_lists = td.GetModelList("");
            List<string> device_lists = td_lists.ConvertAll<string>(a => a.devicename);
            //���Ƽ�������Դ  
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
            //Console.WriteLine("��ǰ���������: " + this.name);
            ////Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            ////this.Size = ScreenArea.Size;
            //Location = (Point)new Size(0, 0);
            //this.TopMost = true;
            //this.Activate();

            //DataTable dt = new DataTable();//������
            //dt.Columns.Add("step", typeof(int));//�����
            //dt.Columns.Add("tool", typeof(String));
            //dt.Columns.Add("testlocal", typeof(String));
            //dt.Columns.Add("bzz", typeof(double));//�����
            //dt.Columns.Add("sgc", typeof(double));
            //dt.Columns.Add("xgc", typeof(double));
            //dt.Rows.Add(new object[] { 1, "����001", "��λ1" , 10, 0.12, 0.123});//�����
            //dt.Rows.Add(new object[] { 2, "����011", "��λ12", 10, 0.0, 1.4 });
            //dt.Rows.Add(new object[] { 3, "����301", "��λ92", 10, 2.6, 6.23 });
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
                    componentId = 1,
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
            MessageBox.Show("�����Ѿ��ύ");
        }

        private void TestBZFrom_Deactivate(object sender, EventArgs e)
        {

            if (global.CurActive == this.name)
            {
                Console.WriteLine("��ǰ���������: " + this.name);
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
        /// �½����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void new_bt_Click(object sender, EventArgs e)
        {
            try
            {
                #region �ж�����


                if (gdno_tb.Text == "")
                {
                    MessageBox.Show("����дλ��");
                    return;
                }
                if (scbh_tb.Text == "")
                {
                    MessageBox.Show("����д��׼ֵ");
                    return;
                }
                if (sandsm_tb.Text == "")
                {
                    MessageBox.Show("�����Ϲ���");
                    return;
                }
                if (tm_tb.Text == "")
                {
                    MessageBox.Show("�����¹���");
                    return;
                }
                if (cicun_tb.Text == "")
                {
                    MessageBox.Show("����д�ߴ�");
                    return;
                }
                if (comboBox_devs.Text == "")
                {
                    MessageBox.Show("��ѡ�񹤾�");
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
                MessageBox.Show("�Ѿ��ύ����");
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
        /// ��ʼ���������
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
        /// �޸�
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
            #region �ж�����


            if (gdno_tb.Text == "")
            {
                MessageBox.Show("����дλ��");
                return;
            }
            if (scbh_tb.Text == "")
            {
                MessageBox.Show("����д��׼ֵ");
                return;
            }
            if (sandsm_tb.Text == "")
            {
                MessageBox.Show("�����Ϲ���");
                return;
            }
            if (tm_tb.Text == "")
            {
                MessageBox.Show("�����¹���");
                return;
            }
            if (cicun_tb.Text == "")
            {
                MessageBox.Show("����д�ߴ�");
                return;
            }
            if (comboBox_devs.Text == "")
            {
                MessageBox.Show("��ѡ�񹤾�");
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
            MessageBox.Show("�޸ĳɹ�");
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
        ///  ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_bt_Click(object sender, EventArgs e)
        {
            string DR = dgv.Rows[dgv.CurrentRow.Index].Cells["id"].Value.ToString();
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            use.Delete(Convert.ToInt32(DR));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("ɾ���ɹ�");
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
        /// ���ƶ���ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sy_bt_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            int rowIndex = dgv.CurrentRow.Index;  //�õ���ǰѡ���е�����     

            if (rowIndex == 0)
            {
                MessageBox.Show("�Ѿ��ǵ�һ����");
                //MessageBox.Show("�Ѿ��ǵ�һ����!");
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
                list.Add(dgv.SelectedRows[0].Cells[i].Value.ToString());   //�ѵ�ǰѡ���е����ݴ���list������     
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
        /// ���ƶ���ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xy_xzh_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            int rowIndex = dgv.SelectedRows[0].Index;  //�õ���ǰѡ���е�����     

            if (rowIndex == dgv.Rows.Count - 1)
            {
                MessageBox.Show("�Ѿ������һ����!");
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
                list.Add(dgv.SelectedRows[0].Cells[i].Value.ToString());   //�ѵ�ǰѡ���е����ݴ���list������     
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
    }
}
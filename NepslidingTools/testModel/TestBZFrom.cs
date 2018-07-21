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
using AnyCAD.Platform;
using AnyCAD.Exchange;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace NepslidingTools.testModel
{
    public partial class TestBZFrom : Form
    {
        private AnyCAD.Presentation.RenderWindow3d renderView = null;
        string name = "TestBZFrom";
        List<Maticsoft.Model.testdevice> td_lists;
        List<Maticsoft.Model.port> port_list;
        public TestBZFrom()
        {
            InitializeComponent();
            this.renderView = new AnyCAD.Presentation.RenderWindow3d();
            this.renderView.Location = new System.Drawing.Point(0, 0);
            this.renderView.Size = this.panel1.Size;
            this.renderView.TabIndex = 1;
            this.panel1.Controls.Add(this.renderView);
            this.renderView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnRenderWindow_MouseClick);
            //this.renderView.Click += new EventHandler(this.RenderWindow_Click);
            //this.renderView.ForeColorChanged += new EventHandler(RenderWindow_colorchange);
            //this.renderView.SystemColorsChanged += new EventHandler(RenderWindow_ColorsChanged);
            this.renderView.RenderTick += new AnyCAD.Presentation.RenderEventHandler(Render_Ev);  
        }

        private void Render_Ev()
        {
            SceneNode sc_node = this.renderView.SceneManager.GetSelectedNode();
            if (sc_node != null)
            {
                Console.WriteLine("sasa");
                // MessageBox.Show(sc_node.GetName() + "===" + sc_node.GetHashCode() + "--00--" + sc_node.GetId().AsInt());
                FaceStyle style = new FaceStyle();
                this.renderView.SceneManager.ClearSelection();
                string[] pos_list = gdno_tb.Text.Split(',');
                string id = sc_node.GetId().AsInt().ToString();
                if (-1 == Array.IndexOf(pos_list, id))
                {
                    if (gdno_tb.Text != "" && !gdno_tb.Text.EndsWith(","))
                    {
                        gdno_tb.Text += ",";
                    }
                    gdno_tb.Text += id;

                }
                else
                {
                    gdno_tb.Text = "";
                    // 重铸数据
                    foreach (string temp_date in pos_list)
                    {
                        if (id == temp_date)
                        {

                            continue;
                        }
                        gdno_tb.Text += temp_date;
                        gdno_tb.Text += ",";
                    }
                    FaceStyle fa = null;
                    if (key_colors.TryGetValue(Convert.ToInt32( id), out fa))
                    {
                        sc_node.SetFaceStyle(fa);
                    }
                }
            }
        }
        private void RenderWindow_ColorsChanged(object sender, EventArgs e)
        {
            SceneNode sc_node = this.renderView.SceneManager.GetSelectedNode();
            if (sc_node != null)
            {
                Console.WriteLine("sasa");
            }
        }

        private void RenderWindow_colorchange(object sender, EventArgs e) {
            SceneNode sc_node = this.renderView.SceneManager.GetSelectedNode();
            if (sc_node != null)
            {
                Console.WriteLine("sasa");
            }
        }
        private void RenderWindow_Click(object sender, EventArgs e)
        {
            SceneNode sc_node = this.renderView.SceneManager.GetSelectedNode();
            if (sc_node != null)
            {
                Console.WriteLine("sasa");
            }
        }

        private void OnRenderWindow_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            SceneNode sc_node = this.renderView.SceneManager.GetSelectedNode();
            if (sc_node != null)
            {
                // MessageBox.Show(sc_node.GetName() + "===" + sc_node.GetHashCode() + "--00--" + sc_node.GetId().AsInt());
                FaceStyle style = new FaceStyle();
                //this.renderView.SceneManager.ClearSelection();
                string[] pos_list = gdno_tb.Text.Split(',');
                string id = sc_node.GetId().AsInt().ToString();
                if (-1 == Array.IndexOf(pos_list, id))
                {
                    if (gdno_tb.Text != "" && !gdno_tb.Text.EndsWith(","))
                    {
                        gdno_tb.Text += ",";
                    }
                    gdno_tb.Text += id;
                    
                }
                else
                {
                    gdno_tb.Text = "";
                    // 重铸数据
                    foreach (string temp_date in pos_list)
                    {
                        if (id == temp_date)
                        {
                            continue;
                        }
                        gdno_tb.Text += temp_date;
                        gdno_tb.Text += ",";
                    }
                }
            }
            MouseFlag.MouseLefDownEvent(this.renderView.Location.X, this.renderView.Location.Y, 0);
            MouseFlag.MouseLefUpEvent(this.renderView.Location.X, this.renderView.Location.Y, 0);
            this.renderView.SceneManager.ClearSelection();
            this.renderView.Refresh();
            this.panel1.Focus();
            this.renderView.Focus();*/
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
            //Maticsoft.BLL.testdevice td = new Maticsoft.BLL.testdevice();
            //td_lists = td.GetModelList("");
            //List<string> device_lists = td_lists.ConvertAll<string>(a => a.devicename);


            Maticsoft.BLL.port port_bll = new Maticsoft.BLL.port();
            port_list = port_bll.GetModelList(string.Format( " mac = '{0}' ", global.MachineID));
            List<string> device_lists = port_list.ConvertAll<string>(a => a.manufacturer);
            //绑定推荐的数据源  
            comboBox_devs.Items.AddRange(device_lists.ToArray());
            #endregion
            // textbox_ljh.Text = Program.gdvid;
            textbox_ljh.Text = LjHao;
            label_ljh.Text = "零件类型:"+ LjHao;
            initdgv();
            this.timer_shine.Enabled = true;
            this.timer_ref.Enabled = true;
            dgv.ClearSelection();
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
            Maticsoft.BLL.measures use = new Maticsoft.BLL.measures();
            foreach (int del_id in del_list)
            {
                use.Delete(del_id);
            }
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
            this.del_list.Clear();
            Maticsoft.BLL.measures use1 = new Maticsoft.BLL.measures();
            string aa = string.Format("componentId = '{0}'ORDER BY step", LjHao);//ORDER BY step
            DataSet ds = use1.GetListByPage3(aa, "", 0, 100);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }

            Maticsoft.BLL.component mea_bll = new Maticsoft.BLL.component();
            Maticsoft.Model.component comp_mode = mea_bll.GetModel(Convert.ToInt32( LjHao));
            if (comp_mode != null)
            {
                
                Task a_task = new Task(new Action(()=> {
                    Thread.Sleep(1000);
                    renderView.Invoke(new Action(() =>
                    {
                        string base_dir = Environment.CurrentDirectory;
                        base_dir += "\\shumo\\";
                        base_dir += comp_mode.sm;
                        IgesReader reader = new IgesReader();
                        bool ret = reader.Read(base_dir, new CadView(this.renderView));
                        Console.WriteLine("ret ====== " + ret);
                        renderView.FitAll();
                        renderView.RequestDraw();
                    }));
                }));
                a_task.Start();
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
            DataSet ds = use1.GetListByPage3(aa, "", 0, 100);
            dgv.DataSource = ds.Tables[0];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["step"].Value = row.Index + 1;
            }


            // 选中下一行
            dgv.ClearSelection();
            step_index += 1;
            int last_line = dgv.Rows.Count;
            if (step_index >= last_line -1)
            {
                step_index = last_line - 1;
            }
                
            dgv.Rows[step_index].Selected = true;
            dgv.Rows[step_index].Cells[0].Selected = true;
            dgv.CurrentCell = dgv.Rows[step_index].Cells["step"];


        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        List<int> del_list = new List<int>();

        /// <summary>
        ///  删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void del_bt_Click(object sender, EventArgs e)
        {
            int del_row_index = Convert.ToInt32(dgv.Rows[dgv.CurrentRow.Index].Cells["id"].Value);
            del_list.Add(del_row_index);
            dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
            return;

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            initdgv();
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
            clearcolor();
        }

        private void comboBox_devs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (ofg_cad.ShowDialog() == DialogResult.OK)
            //{

            //}
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (ofg_cad.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // OnRenderWindow_MouseClick(sender, e as MouseEventArgs);
            gdno_tb.Text = "";
            clearcolor();
        }

        private void clearcolor()
        {
            foreach (KeyValuePair<int, FaceStyle> a in key_colors)
            {
                SceneNode node = this.renderView.SceneManager.FindNode(new ElementId(a.Key));
                node.SetFaceStyle(a.Value);
            }
        }
        int n = 0;
        Dictionary<int, FaceStyle> key_colors = new Dictionary<int, FaceStyle>();
        string[] position_list = null;
        private static object objlock = new object();
        private void timer_shine_Tick(object sender, EventArgs e)
        {
            n++;
            if (this.renderView != null && this.renderView.SceneManager == null)
                return;
            lock(objlock)
            { 
                if (position_list != null)
                    foreach (string ca in position_list)
                    {
                        int index = 0;
                        if (!int.TryParse(ca, out index))
                        {
                            continue;
                        }
                        SceneNode node = this.renderView.SceneManager.FindNode(new ElementId(index));

                        if (node != null)
                        {
                            FaceStyle value = null;
                            if (key_colors.TryGetValue(index, out value))
                            {
                                if (n % 2 == 0)
                                { 
                                    node.SetFaceStyle(value);
                                }
                                else
                                {
                                    FaceStyle fa = new FaceStyle();
                                    fa.SetColor(new ColorValue(1, 1, 1));
                                    node.SetFaceStyle(fa);
                                }
                            }
                            else
                            {
                                FaceStyle cur_sty = node.GetFaceStyle();
                                key_colors.Add(index, cur_sty);
                            }
                        }
                    }
            }
        }

        private void gdno_tb_TextChanged(object sender, EventArgs e)
        {
            lock(objlock)
            {
                Console.WriteLine("位置已經修改");
                position_list = this.gdno_tb.Text.Split(',');
            }

        }

        private void timer_ref_Tick(object sender, EventArgs e)
        {
            this.renderView.Height += 1;
            this.renderView.Height -= 1;
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(e.Row.Selected == true)
            {
                gdno_tb.Text = e.Row.Cells["position"].Value.ToString();
                scbh_tb.Text = e.Row.Cells["standardv"].Value.ToString();
                sandsm_tb.Text = e.Row.Cells["up"].Value.ToString();
                tm_tb.Text = e.Row.Cells["down"].Value.ToString();
                cicun_tb.Text = e.Row.Cells["CC"].Value.ToString();
                clearcolor();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class MouseFlag
    {
        [DllImport("user32.dll")]

        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        public static void MouseLefDownEvent(int dx, int dy, uint data)
        {
            mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
        }
        public static void MouseLefUpEvent(int dx, int dy, uint data)
        {
            mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
        }
    }
}
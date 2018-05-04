using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using AnyCAD.Platform;
using Maticsoft.Model;
using System.Threading;

namespace NepslidingTools.testModel
{
    public partial class StepTestFrom : WorkForm
    {
        string name = "steptest";

        #region ���ڱ���
        private SerPort sp_obj = new SerPort();
        List<Maticsoft.Model.port> ports_list;
        #endregion

        #region cad ����
        // The global application object
        public static AnyCAD.Platform.Application theApplication;

        // BREP tool to create geometries.
        BrepTools shapeMaker = new BrepTools();
        // Default 3d View
        AnyCAD.Platform.View3d theView;
        #endregion

        #region ����ʹ�õ���ʱ����

        // ��� ����

        #endregion

        DataTable measures_tables;

        public StepTestFrom()
        {
            InitializeComponent();
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);
        }

        public void jiangyaozhixin(string a)
        {
            if(textcl.IsHandleCreated)
            textcl.Invoke(new Action(() =>
            {
                if (textcl.Text == a)
                {
                    textcl.Text += " ";
                }
                else { textcl.Text = a; }

            }));


            //Console.WriteLine("�ҽ�Ҫִ��aaa�ƻ�");
        }

        private void init_photobytype(int type)
        {
            Maticsoft.BLL.testdevice dt_bll = new Maticsoft.BLL.testdevice();
            Maticsoft.Model.testdevice dt_model =  dt_bll.GetModel(type);
            string dir = System.Environment.CurrentDirectory;
            dir = dir + "\\images\\" + dt_model.remark;
            //MessageBox.Show(dir);
            pictureBox1.Image = Image.FromFile(dir);
        }

        private void init_portbytype(int type)
        {
            if (sp_obj.port_st())
            {
                sp_obj.close();
            }
            #region ��ǰ�����豸չʾ
            // ����ȵô����б�
            #region �����б� ports_list
            string local_id = global.MachineID;
            Maticsoft.BLL.port ports_man = new Maticsoft.BLL.port();
            ports_list = ports_man.GetModelList(string.Format("  mac = '{0}' and devicetype={1} ", local_id, type));
            //MessageBox.Show(ports_list.Count.ToString());
            if (ports_list.Count <= 0)
            {
                // MessageBox.Show("û���κο��õĲ����豸");
            }
            // �Ե�ǰ���ڵ�չʾ�� �Լ�Ĭ�ϵĴ���
            //lab_defportname.Text = ports_list[0].manufacturer + " - " + ports_list[0].portname;
            #endregion

            this.cbb_canselect.Items.Clear();
            foreach (Maticsoft.Model.port tmp_port in ports_list)
            {
                this.cbb_canselect.Items.Add(tmp_port.manufacturer);
            }
            #endregion

        }

        private void init_table()
        {
            #region ����dgv ���ݽṹ �Լ��������
            DataTable dtb = new DataTable();
            #region ����datatable ��  ��ӱ�ͷ
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            //string st = string.Format("componentId = '{0}'", lble.Text);
            string st = string.Format("componentId = '{0}' order by step asc", this.comp_type);
            DataSet ds1 = mes.GetList(st);
            dtb.Columns.Add("���Ա��");
            dtb.Columns.Add("����ʱ��");

            if (ds1.Tables[0].Rows.Count <=0)
            {
                MessageBox.Show("�����ô��������");
                // this.Dispose(false);
                this.Close();
                return;
            }

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                comboBox1.Text = sg;
                dtb.Columns.Add(sg.ToString());
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("���Խ��");
            #endregion

            #region ��������dgv����
            Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
            string TS = string.Format("PN = '{0}'", lble.Text);
            DataSet dst = tst.GetList(TS);
            DataTable test_datatable = dst.Tables[0];
            int test_count = test_datatable.Rows.Count;
            for (int start_test = 0; start_test < test_count; start_test++)
            {
                string bh = test_datatable.Rows[start_test]["measureb"].ToString();
                string sj = test_datatable.Rows[start_test]["time"].ToString();
                string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["���Ա��"] = bh;
                dr["����ʱ��"] = sj;
                dr["���Խ��"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                foreach (string j in sp)
                {
                    sp_num++;
                    string col_name = string.Format("����{0}", sp_num);
                    if( dtb.Columns.Contains(col_name))
                    { dr[col_name] = j; }
                }
                dtb.Rows.InsertAt(dr, 0);
            }
            #endregion
            dgv1.DataSource = dtb;
            #endregion

        }

        private void show_step()
        {
            #region ��ʼ����ǰ������Ϣ
            Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
            string st1 = string.Format("componentId = '{0}'  order by step asc", this.comp_type);
            DataSet ds11 = mes1.GetList(st1);
            //DataTable dt = new DataTable();
            //ds1.Tables.Add(dt);
            measures_tables = ds11.Tables[0];
            if (measures_tables.Rows.Count <= 0)
            {
                MessageBox.Show("�����ô��������");
                this.Close();
            }

            for (int i = 0; i < measures_tables.Rows.Count; i++)
            {
                txtll.Text = measures_tables.Rows[i][4].ToString();
                comboBox1.Items.Add("����" + measures_tables.Rows[i]["step"].ToString());
            }
            this.comboBox1.SelectedIndex = 0;
            #endregion
        }

        private void StepTestFrom_Load(object sender, EventArgs e)
        {
            //global.AsynCall((a) => { MessageBox.Show(a.ToString()); }, "test");

            #region �������ţ�ͨ������Ż����ϸ��Ϣ
            // ��������
            lble.Text = Program.txtbh;
            //global.AsynCall(this.dealwithcomp, lble.Text);
            dealwithcomp(lble.Text);
            #endregion

            // MessageBox.Show("���濪ʼ��");
            txtkw.Text = global.MachineID;


            try
            {
                // cad ��Ϣ
                #region andcad ��ʼ��
                if (StepTestFrom.theApplication == null)
                {
                    StepTestFrom.theApplication = new AnyCAD.Platform.Application();
                    StepTestFrom.theApplication.Initialize();
                }
                Size size = panel3d.Size;
                // Create the 3d View
                theView = theApplication.CreateView(panel3d.Handle.ToInt32(), size.Width, size.Height);
                theView.RequestDraw();
                #endregion

                init_table();

                show_step();

                string device_type = measures_tables.Rows[0]["devicetype"].ToString();
                init_portbytype(Convert.ToInt32(device_type));
                init_photobytype(Convert.ToInt32(device_type));
                lab_defportname.Text = ports_list[0].manufacturer + " - " + ports_list[0].portname;
                #region ��ʼ��������Ϣ
                sp_obj.CheckPort();
                sp_obj.init_port(ports_list[0].portname);
                sp_obj.Processfunc = jiangyaozhixin;
                global.CurActive = "steptest";
                #endregion
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                MessageBox.Show(err.Message);
            }

            this.timer1.Enabled = true;
            create_serpoint();
        }

        private void create_serpoint()
        {

            // ��������ͼ�߳�
            Thread T = new Thread(() =>
            {
                try
                {
                    Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
                    List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList(string.Format(" PN = '{0}'  ORDER BY test.time desc LIMIT 100", lble.Text));
                    // MessageBox.Show(test_lists.Count.ToString());
                    // �ָ����� ���ҷ�������ͼ����
                    int cur_index = 0;
                    // 1 ��õ�ǰ�ǵڼ���
                    comboBox1.Invoke(new Action(() =>
                    {
                        cur_index = int.Parse(comboBox1.SelectedItem.ToString().Replace("����", ""));
                    }));


                    // 2 ѭ����� ����ĸ���
                    int n = 1;
                    this.chartControl1.BeginInvoke(new Action(() =>
                    {
                        this.chartControl1.Series[0].Points.Clear();
                    }));
                    foreach (Maticsoft.Model.test test_obj in test_lists)
                    {
                        string test_result = test_obj.step1;

                        string[] results = test_result.Split('/');
                        // ���ִ��� ����������顣�͵�����������һλ
                        if (cur_index > results.Length)
                        {
                            cur_index = results.Length;
                        }
                        if (results.Length <= 0)
                        {
                            break;
                        }
                        Console.WriteLine(results[cur_index - 1]);
                        this.chartControl1.Invoke(new Action(() =>
                        {

                            this.chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(n++, results[cur_index - 1]==""? "0": results[cur_index - 1]));
                        }));
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            });
            T.Start();
        }

        private SceneNode ShowTopoShape(TopoShape topoShape, int id)
        {
            // Add the TopoShape to Scene.
            TopoShapeConvert convertor = new TopoShapeConvert();
            SceneNode faceNode = convertor.ToFaceNode(topoShape, 0.5f);
            faceNode.SetId(id);
            theView.GetSceneManager().AddNode(faceNode);
            return faceNode;
        }


        private void test()
        {
            TopoShape box = shapeMaker.MakeBox(new Vector3(40, -20, 0), new Vector3(0, 0, 1), new Vector3(30, 40, 60));

            SceneNode sceneNode = ShowTopoShape(box, 101);

            FaceStyle style = new FaceStyle();
            style.SetColor(new ColorValue(0.5f, 0.3f, 0, 1));
            sceneNode.SetFaceStyle(style);

            TopoShape cylinder = shapeMaker.MakeCylinder(new Vector3(80, 0, 0), new Vector3(0, 0, 1), 20, 100, 315);
            SceneNode sceneNode1 = ShowTopoShape(cylinder, 102);
            FaceStyle style1 = new FaceStyle();
            style.SetColor(new ColorValue(0.1f, 0.3f, 0.8f, 1));
            sceneNode.SetFaceStyle(style);

            int size = 20;
            // Create the outline edge
            TopoShape arc = shapeMaker.MakeArc3Pts(new Vector3(-size, 0, 0), new Vector3(size, 0, 0), new Vector3(0, size, 0));
            TopoShape line1 = shapeMaker.MakeLine(new Vector3(-size, -size, 0), new Vector3(-size, 0, 0));
            TopoShape line2 = shapeMaker.MakeLine(new Vector3(size, -size, 0), new Vector3(size, 0, 0));
            TopoShape line3 = shapeMaker.MakeLine(new Vector3(-size, -size, 0), new Vector3(size, -size, 0));

            TopoShapeGroup shapeGroup = new TopoShapeGroup();
            shapeGroup.Add(line1);
            shapeGroup.Add(arc);
            shapeGroup.Add(line2);
            shapeGroup.Add(line3);

            TopoShape wire = shapeMaker.MakeWire(shapeGroup);
            TopoShape face = shapeMaker.MakeFace(wire);

            // Extrude
            TopoShape extrude = shapeMaker.Extrude(face, 100, new Vector3(0, 0, 1));
            ShowTopoShape(extrude, 104);

            // Check find....
            SceneNode findNode = theView.GetSceneManager().FindNode(104);
            theView.GetSceneManager().SelectNode(findNode);

        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            ViewUtility.OnMouseWheelEvent(theView, e);
        }
        private void panel3d_Paint(object sender, PaintEventArgs e)
        {
            if (theView == null)
                return;

            theView.Redraw();
        }

        private void panel3d_MouseDown(object sender, MouseEventArgs e)
        {
            ViewUtility.OnMouseDownEvent(theView, e);
        }

        private void panel3d_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show(theView.ToString());
            ViewUtility.OnMouseMoveEvent(theView, e);
        }

        private void panel3d_MouseUp(object sender, MouseEventArgs e)
        {
            ViewUtility.OnMouseUpEvent(theView, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            theView.RequestDraw();
            theView.Redraw();
        }

        private void StepTestFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.sp_obj.close();
            this.Dispose();
        }

        private void toptime_Tick(object sender, EventArgs e)
        {
        }

        private void StepTestFrom_Deactivate(object sender, EventArgs e)
        {
            //if (global.CurActive == this.name)
            //{
            //    Console.WriteLine("��ǰ���������: " + this.name);
            //    Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //    this.Size = ScreenArea.Size;
            //    Location = (Point)new Size(0, 0);
            //    this.TopMost = true;
            //    this.Activate();
            //}
        }

        private void StepTestFrom_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine("StepTestFrom_Scroll");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textcl_TextChanged(object sender, EventArgs e)
        {
            if (textcl.Text == "")
            {
                return;
            }
            #region �жϵ�ǰ�Ĳ��ԣ� �ǲ��Ǻ����
            // ����ֵ
            double LL = Convert.ToDouble(txtll.Text);
            // ����ֵ
            double GC = Convert.ToDouble(txtgc.Text);
            // ����ֵ
            double BZ = Convert.ToDouble(textcl.Text);

            int test_row = 0;
            double cz = LL - GC;
            double hz = LL + GC;
            if (BZ >= cz && BZ <= hz)
            {
                this.combjg.Text = "Ok";
            }
            else
            {
                combjg.Text = "Ng";
            }
            #endregion

            #region �������һ���ж� ������һ�� �����û���о����һ��
            DataTable dt = dgv1.DataSource as DataTable;
            DataRow need_change_rows = null;

            //DataColumn need_change_count = null;
            int need_cahnge_row = 0;
            int col_num = dt.Columns.Count;
            if (dt.Rows.Count > 0 && dt.Rows[need_cahnge_row][col_num - 1].ToString() == "")
            {
                need_change_rows = dt.Rows[need_cahnge_row];
            }

            //foreach (DataRow temp in dt.Rows)
            //{
            //    int col_num = dt.Columns.Count;
            //    //Console.WriteLine(string.Format("temp[col_num -1 ] == {0}", temp[col_num-1]));
            //    if (temp[col_num - 1].ToString() == "")
            //    {
            //        need_change_rows = temp;
            //        break;
            //    }
            //}
            if (need_change_rows == null)
            {
                // ��� ��ǰ��һ�е����ݲ��������ݿ⡣ ������Ӧ�� ����
                int test_rowindex = 0;
                Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
                if (dgv1.Rows.Count>0)
                {
                    List<Maticsoft.Model.test> tear_mode = test_bll.GetModelList(string.Format(" measureb='{0}'", dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString()));
                    if (tear_mode.Count == 0)
                    {
                        MessageBox.Show("�뱣���ϴβ��Խ�����ڿ�ʼ��һ�εĲ���");
                        return;
                    }
                }

                need_change_rows = dt.NewRow();
                // dt.Rows.Add(need_change_rows);
                dt.Rows.InsertAt(need_change_rows ,0);
                // ����ѡ��
                this.dgv1.Rows[0].Selected = true;
                this.dgv1.CurrentCell = this.dgv1.Rows[0].Cells[this.dgv1.CurrentCell.ColumnIndex];
            }
            this.timer_tostep.Enabled = true;
            #endregion


            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("componentId = '{0}'", this.comp_type);
            DataSet ds1 = mes.GetList(st);
            #region ������������ ��ÿ�����Խ����ֵ
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                if (comboBox1.Text == sg)
                {
                    for (int j = 0; j < dgv1.Rows.Count; j++)
                    {
                        need_change_rows[comboBox1.Text] = textcl.Text;
                        //string BJ = need_change_rows[comboBox1.Text].ToString(); 
                    }
                }
            }
            this.dgv1.Refresh();
            #endregion
            int last_row = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            if (dgv1.Rows[test_row].Cells["���Ա��"].Value.ToString() == "")
            {
                string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string dnum = num.ToString();
                dnum = "p" + dnum;
                dgv1.Rows[test_row].Cells["���Ա��"].Value = dnum;
                dgv1.Rows[test_row].Cells["����ʱ��"].Value = DateTime.Now.ToString();
            }

            #region �ж��ǲ��ǿ��� ok ����ng�� 
            //int last_row1 = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            int CL = dt.Columns.Count;
            string fz = dt.Rows[test_row][CL - 2].ToString();
            if (fz != "")
            {
               
                int t = dt.Columns.Count - 3;
                for (int a = 0; a < t; a++)
                {
                    string dd = "";
                    string col_name = string.Format("����{0}", a + 1);
                    dd = dt.Rows[test_row][col_name].ToString();

                    if (dd == "")
                    {
                        break;
                    }
                    #region ---------------------
                    // ��ò�����Ϣ
                    /*
                    Maticsoft.BLL.measures mesq = new Maticsoft.BLL.measures();
                    string ste = string.Format("PN = '{0}'", lble.Text);
                    DataSet dsf = mesq.GetList(ste);
                    //for (int i = 0; i < dsf.Tables[0].Rows.Count; i++)
                    //{
                    string sg = "����" + dsf.Tables[0].Rows[a]["step"].ToString();// comboBox1.Items.Add()

                    comboBox1.Text = sg;
                    */


                    //Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                    // string st1 = string.Format("PN = '{0}'", lble.Text);
                    // DataSet ds11 = mes1.GetList(st1);
                    #endregion


                    txtll.Text = ds1.Tables[0].Rows[a][4].ToString();
                    string shang_gc = ds1.Tables[0].Rows[a][5].ToString();
                    string xia_gc = ds1.Tables[0].Rows[a][6].ToString();

                    cz = Convert.ToDouble(txtll.Text) - Convert.ToDouble(xia_gc);
                    hz = Convert.ToDouble(txtll.Text) + Convert.ToDouble(shang_gc);

                    string tt = "";
                    
                    if (Convert.ToDouble(dd) >= cz && Convert.ToDouble(dd) <= hz)
                    {
                        need_change_rows["���Խ��"] = "Ok";
                        this.dgv1.Refresh();
                    }
                    else
                    {
                        need_change_rows["���Խ��"] = "NG";
                        this.dgv1.Refresh();
                        break;
                    }

                    
                    #region ------------
                    /*
                    if (tt != "Ok")
                    {
                        need_change_rows["���Խ��"] = "NG";
                        break;
                    }
                    else
                    {
                        need_change_rows["���Խ��"] = "Ok";
                    }*/
                    //  }
                    #endregion

                }
            }
            #endregion
        }






        //if (dt.Columns[dt.Columns.Count-2].ToString() != "")
        //if (comboBox1.Text == "����1")
        //{
        //    for (int i=0;i<dgv1.Rows.Count ;i++) {
        //        //dt.Columns.Add();
        //        need_change_rows[comboBox1.Text] = textcl.Text;
        //        dgv1.Rows[i].Cells["����ʱ��"].Value = DateTime.Now.ToString();
        //        //need_change_rows["TestTime"] = DateTime.Now.ToString();
        //        // need_change_rows["step1"] = textcl.Text;
        //       // Random rd = new Random();
        //        string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //        //int num2 = rd.Next(Convert.ToInt32( num));
        //        string dnum = num.ToString();
        //        dgv1.Rows[i].Cells["���Ա��"].Value = dnum;
        //        // need_change_rows["nearNo"] = dnum;
        //    }
        //    }

        //    if (comboBox1.Text == "����2")
        //    {

        //        need_change_rows[comboBox1.Text] = textcl.Text;

        //        //need_change_rows["step2"] = textcl.Text;

        //        //DataTable dt1 = dgv1.DataSource as DataTable;
        //        //DataRow dr1 = dt1.NewRow();

        //        //dr1["step2"] = textcl.Text;
        //        //dt1.Rows.Add(dr1);

        //        //DataTable dt = dgv1.DataSource as DataTable;
        //        //string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //        //int num2 = rd.Next(0000,9999);
        //        //string dnum = num.ToString();
        //        // dgv1.Rows[i].Cells["nearNo"].Value = dnum;
        //        //dt.Rows.Add(1, dnum, DateTime.Now.ToString(), "", textcl.Text);

        //    }
        //    if (comboBox1.Text == "����3")
        //    {

        //        need_change_rows[comboBox1.Text] = textcl.Text;
        //        //need_change_rows["step3"] = textcl.Text;

        //    }
        //    if (comboBox1.Text == "����4")
        //    {

        //        need_change_rows[comboBox1.Text] = textcl.Text;
        //        //need_change_rows["step4"] = textcl.Text;

        //    }
        //    if (comboBox1.Text == "����5")
        //    {

        //        need_change_rows[comboBox1.Text] = textcl.Text;
        //        //need_change_rows["step5"] = textcl.Text;
        //        double stp1 = Convert.ToDouble(need_change_rows[10]);
        //        double stp2 = Convert.ToDouble(need_change_rows[11]);
        //        double stp3 = Convert.ToDouble(need_change_rows[12]);
        //        double stp4 = Convert.ToDouble(need_change_rows[13]);
        //        double stp5 = Convert.ToDouble(need_change_rows[14]);
        //        if (stp1 >= cz && stp1 <= hz && stp2 >= cz && stp2 <= hz && stp3 >= cz && stp3 <= hz && stp4 >= cz && stp4 <= hz && stp5 >= cz && stp5 <= hz)
        //        {
        //            need_change_rows["OkOrNg"] = "Ok";
        //        }
        //        else
        //        {
        //            need_change_rows["OkOrNg"] = "Ng";
        //        }
        //        //DataTable dt = dgv1.DataSource as DataTable;
        //        //dt.Rows.Add(1, "", "", "", "", "", "", textcl.Text);

        //    }
        //Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
        //string st = string.Format("PN = '{0}'", lble.Text);
        //DataSet ds1 = mes.GetList(st);
        //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        //{
        //    comboBox1.Items.Add(ds1.Tables[0].Rows[i]["step"].ToString());
        //}

        //    if (comboBox1.Text!=sg)
        //{
        //    dt.Columns.Add(comboBox1.Text);
        //}      
        private void buttonX3_Click(object sender, EventArgs e)
        {
            int test_index = 0;
            // MessageBox.Show(dgv1.Rows[test_index].Cells["���Խ��"] .Value.ToString());
            if (dgv1.Rows.Count >= 1 && (dgv1.Rows[test_index].Cells["���Խ��"].Value == null || dgv1.Rows[test_index].Cells["���Խ��"].Value.ToString() == ""))
            {
                // dgv1.Rows.RemoveAt(0);
                if (this.comboBox1.Items.Count > this.comboBox1.SelectedIndex + 1)
                {
                    this.comboBox1.SelectedIndex += 1;
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            //this.comboBox1.Text = "����1";
            // this.comboBox1.SelectedIndex = 0;
            //MessageBox.Show(this.dgv1.CurrentRow.Index.ToString());

            //// DataRow dr = (this.dgv1.DataSource as DataTable ).Rows[this.dgv1.CurrentRow.Index];
            //DataGridViewRow row = this.dgv1.Rows[this.dgv1.CurrentRow.Index];
            //// ɾ��ѡ���У� ���� ����Ϊ��һ��
            //this.dgv1.Rows.RemoveAt(this.dgv1.CurrentRow.Index);
            //this.dgv1.Rows.Insert(0, row);

            // MessageBox.Show();
            string colname = this.dgv1.Columns[this.dgv1.CurrentCell.ColumnIndex].HeaderText;
            colname = colname.Replace("����", "");

            int col_num = 0;
            if (int.TryParse(colname, out col_num))
            {
                this.comboBox1.SelectedIndex = col_num > 0 ? col_num - 1 : 0;
            }

            DataTable dt = this.dgv1.DataSource as DataTable;
            //DataTable dt2 = dt.Copy();
            DataRow dr = dt.NewRow();
            foreach (DataColumn aDataColumn in dt.Columns)
            {
                dr[aDataColumn.ColumnName] = dt.Rows[dgv1.CurrentRow.Index][aDataColumn.ColumnName];
            }
            dr["���Խ��"] = "";
            dt.Rows.RemoveAt(dgv1.CurrentRow.Index);
            dt.Rows.InsertAt(dr, 0);
            this.dgv1.Rows[0].Selected = true;
            this.dgv1.CurrentCell = this.dgv1.Rows[0].Cells[this.dgv1.CurrentCell.ColumnIndex];
            //this
        }


        /// <summary>
        /// 
        ///  ���  ===  ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string join_point = "";
            // int last_row = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            int test_rowindex = 0;
            //int col_count = dgv1.Columns.Count - 3;
            #region �������
            DataTable dt = dgv1.DataSource as DataTable;
            int col_count = dt.Columns.Count - 3;

            //for (int n=0; n<dt.Columns.Count; n++)
            //{
            //    Console.WriteLine(dt.Columns[n].ColumnName);
            //}

            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            List<Maticsoft.Model.test>  tear_mode = test_bll.GetModelList(string.Format(" measureb='{0}'", dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString()));
            if (tear_mode.Count == 0)
            {
                for (int i = 0; i < col_count; i++)
                {
                    string col_name = string.Format("����{0}", i + 1);
                    //join_point += dgv1.Rows[last_row].Cells[col_name].Value.ToString();
                    join_point += dt.Rows[test_rowindex][col_name].ToString();
                    if (i == col_count - 1)
                    { break; }
                    join_point += "/";
                }
                string bh = dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString();
                string sj = dgv1.Rows[test_rowindex].Cells["����ʱ��"].Value.ToString();
                string JG = dgv1.Rows[test_rowindex].Cells["���Խ��"].Value.ToString();
                // MessageBox.Show(join_point);  
                //string stp = string.Format(bz1 + '/' + bz2 + '/' + bz3 + '/' + bz4 + '/' + bz5);



                string ljh = lble.Text;
                Maticsoft.BLL.test use = new Maticsoft.BLL.test();
                Maticsoft.Model.test us = new test()
                {
                    measureb = bh,
                    time = Convert.ToDateTime(sj),
                    step1 = join_point,
                    //step2 = bz2,
                    //step3 = bz3,
                    //step4 = bz4,
                    //step5 = bz5,
                    OKorNG = JG,
                    PN = ljh,
                    workid = global.MachineID
                };

                use.Add(us);
            }
            else if (tear_mode.Count == 1)
            {
                for (int i = 0; i < col_count; i++)
                {
                    string col_name = string.Format("����{0}", i + 1);
                    //join_point += dgv1.Rows[last_row].Cells[col_name].Value.ToString();
                    join_point += dt.Rows[test_rowindex][col_name].ToString();
                    if (i == col_count - 1)
                    { break; }
                    join_point += "/";
                }
                string bh = dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString();
                string sj = dgv1.Rows[test_rowindex].Cells["����ʱ��"].Value.ToString();
                string JG = dgv1.Rows[test_rowindex].Cells["���Խ��"].Value.ToString();
                // MessageBox.Show(join_point);  
                //string stp = string.Format(bz1 + '/' + bz2 + '/' + bz3 + '/' + bz4 + '/' + bz5);



                string ljh = lble.Text;
                Maticsoft.BLL.test use = new Maticsoft.BLL.test();
                Maticsoft.Model.test us = tear_mode[0];
                us.time = Convert.ToDateTime(sj);
                us.step1 = join_point;
                us.OKorNG = JG;
                //Maticsoft.Model.test us = new test()
                //{
                //    measureb = bh,
                //    time = Convert.ToDateTime(sj),
                //    step1 = join_point,
                //    //step2 = bz2,
                //    //step3 = bz3,
                //    //step4 = bz4,
                //    //step5 = bz5,
                //    OKorNG = JG,
                //    PN = ljh,
                //    workid = global.MachineID
                //};

                use.Update(us);
            }
            else {
                MessageBox.Show("��¼�ظ��� ��������ݿ� ");
            }
            MessageBox.Show("��¼�Ա���");
            this.comboBox1.SelectedIndex = 0; 
            #endregion
            return;
            DataTable dtb = new DataTable();
            #region ����datatable ��
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("componentId = '{0}'", this.comp_type);
            DataSet ds1 = mes.GetList(st);
            dtb.Columns.Add("���Ա��");
            dtb.Columns.Add("����ʱ��");

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                comboBox1.Text = sg;
                dtb.Columns.Add(sg.ToString());
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("���Խ��");
            #endregion
            
            #region �������
            Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
            string TS = string.Format("PN = '{0}'", lble.Text);
            DataSet dst = tst.GetList(TS);
            DataTable test_datatable = dst.Tables[0];
            int test_count = test_datatable.Rows.Count;
            for (int start_test = 0; start_test < test_count; start_test++)
            {
                //string bh = ;
                //string sj = ;
                string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["���Ա��"] = test_datatable.Rows[start_test]["measureb"].ToString();
                dr["����ʱ��"] = test_datatable.Rows[start_test]["time"].ToString();
                dr["���Խ��"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                foreach (string j in sp)
                {
                    sp_num++;
                    string col_name = string.Format("����{0}", sp_num);
                    dr[col_name] = j;
                }
                dtb.Rows.Add(dr);
            }
            #endregion
            dgv1.DataSource = dtb;

        }
        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgv1.Columns["OkOrNg"].Frozen = true;

        }

        /// <summary>
        ///  ���ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dgv1.DataSource = dt;
            //int last_row1 = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            //for (int i = 0; i < dgv1.ColumnCount; i++)
            //{
            //    dgv1.Rows[last_row1].Cells[i].Value = "";
            //}
            //int test_index = 0;
            //// MessageBox.Show(dgv1.Rows[test_index].Cells["���Խ��"] .Value.ToString());
            //if (dgv1.Rows.Count>=1 && (dgv1.Rows[test_index].Cells["���Խ��"].Value==null || dgv1.Rows[test_index].Cells["���Խ��"].Value.ToString() == ""))
            //{
            //    dgv1.Rows.RemoveAt(0);
            //    this.comboBox1.SelectedIndex = 0; 
            //}

            DataTable dtb = this.dgv1.DataSource as DataTable;
            dtb.Clear();
            #region ��������dgv����
            Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
            string TS = string.Format("PN = '{0}'", lble.Text);
            DataSet dst = tst.GetList(TS);
            DataTable test_datatable = dst.Tables[0];
            int test_count = test_datatable.Rows.Count;
            for (int start_test = 0; start_test < test_count; start_test++)
            {
                string bh = test_datatable.Rows[start_test]["measureb"].ToString();
                string sj = test_datatable.Rows[start_test]["time"].ToString();
                string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["���Ա��"] = bh;
                dr["����ʱ��"] = sj;
                dr["���Խ��"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                foreach (string j in sp)
                {
                    sp_num++;
                    string col_name = string.Format("����{0}", sp_num);
                    dr[col_name] = j;
                }
                dtb.Rows.InsertAt(dr, 0);
            }
            #endregion
            dgv1.DataSource = dtb;
        }

        private void InitTestData()
        {
            string cur_item = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
            // ����һ�²�������
            string com_step = comboBox1.Text.Replace("����", "");
            string st1 = string.Format("componentId = '{0}' and  step='{1}'", this.comp_type, com_step);
            List<Maticsoft.Model.measures> ms_modes = mes1.GetModelList(st1);
            if (ms_modes.Count == 1)
            {
                txtll.Text = ms_modes[0].standardv;
                txtgc.Text = ms_modes[0].up;
                txtbox_gcxia.Text = ms_modes[0].down;
            }
            else
            {
                MessageBox.Show("������׼û��¼�롣 ����¼�벻����");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string device_type = measures_tables.Rows[index]["devicetype"].ToString();
            init_portbytype(Convert.ToInt32(device_type));
            init_photobytype(Convert.ToInt32(device_type));
            if (ports_list.Count <= 0)
            {
                return;
            }
            lab_defportname.Text = ports_list[0].manufacturer + " - " + ports_list[0].portname;
            this.InitTestData();
            create_serpoint();
            /*
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", lble.Text);
            DataSet ds1 = mes.GetList(st);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

                if (comboBox1.Text == sg)
                {
                    textcl.Text = "";
                    comboBox1.Text = ds1.Tables[0].Rows[i]["step"].ToString();
                    // Maticsoft.BLL.measures aa = new Maticsoft.BLL.measures();
                    Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                    string st1 = string.Format("PN = '{0}' and  step='{1}'", lble.Text, comboBox1.Text);
                    DataSet ds11 = mes1.GetList(st1);
                    for (int j = 0; j < ds11.Tables[0].Rows.Count; j++)
                    {
                        txtll.Text = ds11.Tables[0].Rows[j][4].ToString();

                    }
                }
                
            }*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbb_canselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(cbb_canselect.SelectedValue.ToString() + " == " + cbb_canselect.SelectedText + " 11 " + cbb_canselect.SelectedItem.ToString());
            MessageBox.Show(ports_list[cbb_canselect.SelectedIndex].manufacturer);
            lab_defportname.Text = ports_list[cbb_canselect.SelectedIndex].manufacturer + " - " + ports_list[cbb_canselect.SelectedIndex].portname;
            this.lab_st.Invoke(new Action(() =>
            {
                bool tmp_conn_st = this.sp_obj.port_st();
                this.lab_st.Text = tmp_conn_st ? "����" : "δ����";
                if (!tmp_conn_st)
                {
                    sp_obj.init_port(ports_list[cbb_canselect.SelectedIndex].portname);
                    sp_obj.Processfunc = jiangyaozhixin;
                }

            }));

        }

        private void timer_portst_Tick(object sender, EventArgs e)
        {
            this.lab_st.Invoke(new Action(() =>
            {
                bool tmp_conn_st = this.sp_obj.port_st();
                this.lab_st.Text = tmp_conn_st ? "����" : "δ����";
                if (!tmp_conn_st)
                {
                    if (ports_list == null || ports_list.Count <= 0 )
                    {
                        return;
                    }
                    string test_port = ports_list[0].portname;
                    if (cbb_canselect.SelectedIndex >= 0)
                    {
                        test_port = ports_list[cbb_canselect.SelectedIndex].portname;
                    }
                    sp_obj.init_port(test_port);
                    sp_obj.Processfunc = jiangyaozhixin;
                }
            }));
        }

        private void timer_tostep_Tick(object sender, EventArgs e)
        {

            if (this.comboBox1.Items.Count > this.comboBox1.SelectedIndex + 1)
            {
                this.comboBox1.SelectedIndex += 1;
            }
            this.timer_tostep.Enabled = false;
        }
    }
}
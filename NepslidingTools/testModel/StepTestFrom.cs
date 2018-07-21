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
using System.Threading.Tasks;
using AnyCAD.Exchange;
using DevExpress.XtraCharts;
using Microsoft.VisualBasic;

using NepslidingTools.toolbox;
using DevExpress.Utils;
using System.Runtime.InteropServices;
using System.Media;

namespace NepslidingTools.testModel
{
    public partial class StepTestFrom : WorkForm
    {
        string name = "steptest";
        private AnyCAD.Presentation.RenderWindow3d renderView = null;
        public int comp_tp = -1;
        public DataGridViewSelectedCellCollection Dselect_Cells = null;
        public string CompId { get; set; }
        public string Pn { get; set; }
        ToolTipController toolTipController = new ToolTipController();

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

        bool re_test = false;

        public StepTestFrom()
        {
            InitializeComponent(); 
            this.renderView = new AnyCAD.Presentation.RenderWindow3d();
            
            this.renderView.Location = new System.Drawing.Point(0, 0);
            this.renderView.Size = this.panel3d.Size;
            this.renderView.TabIndex = 1;
            this.panel3d.Controls.Add(this.renderView);
            this.renderView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnRenderWindow_MouseClick);
            // this.renderView.MouseEnter += new EventHandler(aa_MouseEnter);
            // this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);   
            
        }

        private void OnRenderWindow_MouseClick(object sender, MouseEventArgs e)
        {
        }

        public void jiangyaozhixin(string a)
        {
            if(textcl.IsHandleCreated)
            textcl.BeginInvoke(new Action(() =>
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
            labelX3.Text = "����: "+ dt_model.devicename;
        }

        private void init_portbytype(int type)
        {
            try
            {
                if (sp_obj.port_st())
                {
                    this.lab_st.Invoke(new Action(() =>
                    {
                        lab_st.Text = "δ����";
                    }));
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void init_table()
        {
            try
            {
                //bool flags = false;
                //#region ��鵱ǰ�������
                //if (dgv1.Columns.Contains("�����") && dgv1.Rows.Count > 0)
                //{
                //    if (dgv1.Rows[0].Cells["�����"].Value.ToString() != "")
                //    {
                //        this.CompId = dgv1.Rows[0].Cells["�����"].Value.ToString();
                //    }
                //}
                //#endregion

                #region ����dgv ���ݽṹ �Լ��������
                DataTable dtb = new DataTable();
            #region ����datatable ��  ��ӱ�ͷ
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();

            string st = string.Format("componentId = '{0}' order by step asc", this.comp_type);
            DataSet ds1 = mes.GetList(st);
            dtb.Columns.Add("�����");
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
                // todo  ����
                // string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();
                string xin_buz = ds1.Tables[0].Rows[i]["CC"].ToString();
                comboBox1.Text = xin_buz;
                dtb.Columns.Add(xin_buz);
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("���Խ��");
            #endregion

            #region ��������dgv����
            Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
            List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList2(string.Format("  parts.componentId = '{0}'  ORDER BY test.time asc LIMIT 100", this.comp_type));
            int test_count = test_lists.Count;
            for (int start_test = 0; start_test < test_count; start_test++)
            {
                string bh = test_lists[start_test].measureb.ToString();
                string sj = test_lists[start_test].time.ToString();
                string stp1 = test_lists[start_test].step1.ToString();
                //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["�����"] = test_lists[start_test].PN;
                dr["���Ա��"] = bh;
                dr["����ʱ��"] = sj;
                dr["���Խ��"] = test_lists[start_test].OKorNG.ToString();
                foreach (string j in sp)
                {
                    if (sp_num > comboBox1.Items.Count -1 )
                    {
                        break;
                    }
                    string col_name = comboBox1.Items[sp_num].ToString();
                    if (dtb.Columns.Contains(col_name))
                    { dr[col_name] = j; }
                    sp_num++;
                    // string col_name = string.Format("����{0}", sp_num);
                }
                dtb.Rows.InsertAt(dr, 0);
            }
            #endregion


            #region �������
            string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string dnum = num.ToString();
            DataRow dr2 = dtb.NewRow();
            dr2["���Ա��"] = dnum;
            dr2["����ʱ��"] = DateTime.Now;
            dtb.Rows.InsertAt(dr2, 0);
            if (true) {
                string str = "";
                if (this.CompId != null && this.CompId != "")
                {
                    str = CompId;
                }
                else
                {
                    QrDlg qr_dlg = new QrDlg();
                    if( qr_dlg.ShowDialog() == DialogResult.OK)
                    {
                            str = qr_dlg.MyCode;
                    }
                    // str = Interaction.InputBox("���ֶ��������ʹ��ɨ��ǹ", "��������", "", -1,-1);
                }
                dr2["�����"] = str;
                this.CompId = "";
            }

            #endregion

            dgv1.DataSource = dtb;
            dgv1.Refresh();
                #endregion
                this.comboBox1.SelectedIndex = 0;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
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
                // comboBox1.Items.Add("����" + measures_tables.Rows[i]["step"].ToString());
                comboBox1.Items.Add(measures_tables.Rows[i]["CC"].ToString());
            }
            this.comboBox1.SelectedIndex = 0;
            #endregion
        }
        CancellationTokenSource cts = new CancellationTokenSource();
        private void StepTestFrom_Load(object sender, EventArgs e)
        {
            toolbox.SplashScreen.Show(typeof(SplashForm));

            Task sp_from = new Task(new Action(()=> {
                Thread.Sleep(1000);
                toolbox.SplashScreen.ChangeTitle("���ڶ�ȡ��ģ");
                Thread.Sleep(1000);
                SplashScreen.ChangeTitle("��������");
                Thread.Sleep(1000);
                SplashScreen.ChangeTitle("��ʼ��Ⱦ");
                Thread.Sleep(1000);
                SplashScreen.ChangeTitle("ͼ����");
                int n = 0;
                while (! cts.IsCancellationRequested)
                {
                    Thread.Sleep(10);
                    SplashScreen.ChangeTitle("������ģ" + (n++).ToString() );
                }
            }), cts.Token);
            sp_from.Start();
            //global.AsynCall((a) => { MessageBox.Show(a.ToString()); }, "test");
            #region �������ţ�ͨ������Ż����ϸ��Ϣ
            dealwithcomp(Program.type);
            #endregion
            //Task a_task = new Task(new Action(() => {
            //    Thread.Sleep(1000);     
            //}));
            //a_task.Start();
            renderView.Invoke(new Action(() =>
            {
                string base_dir = Environment.CurrentDirectory;
                base_dir += "\\shumo\\";
                base_dir += this.mode;
                IgesReader reader = new IgesReader();
                bool ret = reader.Read(base_dir, new CadView(this.renderView));
                Console.WriteLine("ret ====== " + ret);
                renderView.FitAll();
                renderView.RequestDraw();
                cts.Cancel();
                sp_from.Wait();
                SplashScreen.Close();
            }));
            this.timer_shine.Enabled = true;
            this.timer_ref.Enabled = true;
            // MessageBox.Show("���濪ʼ��");
            txtkw.Text = global.MachineID;


            try
            {
                // cad ��Ϣ
                #region andcad ��ʼ��
                //if (StepTestFrom.theApplication == null)
                //{
                //    StepTestFrom.theApplication = new AnyCAD.Platform.Application();
                //    StepTestFrom.theApplication.Initialize();
                //}
                //Size size = panel3d.Size;
                //// Create the 3d View
                //theView = theApplication.CreateView(panel3d.Handle.ToInt32(), size.Width, size.Height);
                //theView.RequestDraw();
                #endregion
                show_step();
                init_table();
                
                string device_type = measures_tables.Rows[0]["devicetype"].ToString();
                init_portbytype(Convert.ToInt32(device_type));
                init_photobytype(Convert.ToInt32(device_type));
                lab_defportname.Text = ports_list[0].manufacturer + " - " + ports_list[0].portname;
                txtkw.Text = ports_list[0].workid;
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
            this.timer_portst.Enabled = true;
           
            this.Refresh();

            dgv1.ClearSelection();
            test_qu.Clear();
            DataGridViewRow temp_dr = null;
            if (Dselect_Cells != null)
            {
                foreach (DataGridViewRow dr2 in dgv1.Rows)
                {
                    if (dr2.Cells["�����"].Value.ToString() != this.Pn || dr2.Index == 0) { continue; }
                    temp_dr = dr2;
                    // �ѵ�һ��
                    foreach (DataGridViewCell cell in Dselect_Cells)
                    {
                        dr2.Cells[cell.OwningColumn.HeaderText].Selected = true;
                        test_qu.Push(cell.OwningColumn.HeaderText);
                    }
                }
                
                //int start_rowsnum = -1;

                re_test = true;
                //foreach (DataGridViewCell cell in dgv1.SelectedCells)
                //{
                //    if (start_rowsnum == -1)
                //    {
                //        start_rowsnum = cell.RowIndex;
                //    }

                //    if (start_rowsnum == cell.RowIndex)
                //    {
                        
                //    }
                //}

                // MessageBox.Show(comboBox1.Items.Contains("����1").ToString());
                // comboBox1.SelectedItem = "����2";
                string colname = this.dgv1.Columns[this.dgv1.CurrentCell.ColumnIndex].HeaderText;
                //colname = colname.Replace("����", "");

                //int col_num = 0;
                //if (int.TryParse(colname, out col_num))
                //{
                //    this.comboBox1.SelectedIndex = col_num > 0 ? col_num - 1 : 0;
                //}
                this.comboBox1.SelectedItem = colname;
                DataTable dt = this.dgv1.DataSource as DataTable;
                //DataTable dt2 = dt.Copy();
                DataRow dr = dt.NewRow();
                foreach (DataColumn aDataColumn in dt.Columns)
                {
                    dr[aDataColumn.ColumnName] = temp_dr.Cells[aDataColumn.ColumnName].Value;
                }
                dr["���Խ��"] = "";
                dt.Rows.RemoveAt(dgv1.CurrentRow.Index);
                dt.Rows.InsertAt(dr, 0);
                this.dgv1.CurrentCell = this.dgv1.Rows[0].Cells[this.dgv1.CurrentCell.ColumnIndex];

                if (re_test)
                {
                    if (test_qu.Count > 0)
                    {
                        string the_one = test_qu.Pop();
                        comboBox1.SelectedItem = the_one;
                    }
                    else if (test_qu.Count == 0)
                    {
                        int last = this.comboBox1.Items.Count;
                        this.comboBox1.SelectedIndex = last - 1;
                        string last_step = this.comboBox1.SelectedItem.ToString();
                        textcl.Text = this.dgv1.Rows[0].Cells[last_step].Value.ToString();
                    }
                }


            }
            chartControl1.RuntimeHitTesting = true;
            chartControl1.MouseMove += new MouseEventHandler(chartControl4_MouseMove);
            chartControl1.MouseLeave += new EventHandler(chartControl4_MouseLeave);
        }

        private void chartControl4_MouseLeave(object sender, EventArgs e)
        {
            toolTipController.HideHint();
        }

        private void chartControl4_MouseMove(object sender, MouseEventArgs e)
        {
            ChartHitInfo hitInfo = chartControl1.CalcHitInfo(e.Location);
            StringBuilder builder = new StringBuilder();
            //if (hitInfo.InDiagram)
            //    builder.AppendLine("In diagram");
            //if (hitInfo.InNonDefaultPane)
            //    builder.AppendLine("In non-default pane: " + hitInfo.NonDefaultPane.Name);
            //if (hitInfo.InAxis)
            //{
            //    builder.AppendLine("In axis: " + hitInfo.Axis.Name);
            //    if (hitInfo.AxisLabelItem != null)
            //        builder.AppendLine("  Label item: " + hitInfo.AxisLabelItem.Text);
            //    if (hitInfo.AxisTitle != null)
            //        builder.AppendLine("  Axis title: " + hitInfo.AxisTitle.Text);
            //}
            //if (hitInfo.InChartTitle)
            //    builder.AppendLine("In chart title: " + hitInfo.ChartTitle.Text);
            //if (hitInfo.InLegend)
            //    builder.AppendLine("In legend");
            //if (hitInfo.InSeries)
            //    builder.AppendLine("In series: " + ((Series)hitInfo.Series).Name);
            //if (hitInfo.InSeriesLabel)
            //{
            //    builder.AppendLine("In series label");
            //    builder.AppendLine("  Series: " + ((Series)hitInfo.Series).Name);
            //}
            
            if (hitInfo.SeriesPoint != null && dgv1.Rows.Count >= Convert.ToInt32( hitInfo.SeriesPoint.Argument) )
            {
                Console.WriteLine(" �����:  " + hitInfo.SeriesPoint.Argument);
                int rear_row = dgv1.Rows.Count - (Convert.ToInt32(hitInfo.SeriesPoint.Argument) - 1) ;
                builder.AppendLine(" �����: " + dgv1.Rows[rear_row].Cells["�����"].Value);
                if (!hitInfo.SeriesPoint.IsEmpty)
                    builder.AppendLine(" ����ֵ: " + hitInfo.SeriesPoint.Values[0]);
            }
            if (builder.Length > 0)
                toolTipController.ShowHint(/*"Hit-testing results:\n" + */builder.ToString(), chartControl1.PointToScreen(e.Location));
            else
                toolTipController.HideHint();
        }
        private static object objlock = new object();
        private void create_serpoint(string value = "0")
        {
            lock (objlock) {
                int nt = 1;
                Task<string> one = new Task<string>(() =>
                {
                    try
                    {      
                        Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
                        List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList2(string.Format("  parts.componentId = '{0}'  ORDER BY test.time asc LIMIT 100", this.comp_type));
                        // MessageBox.Show(test_lists.Count.ToString());
                        // �ָ����� ���ҷ�������ͼ����
                        int cur_index = 0;
                        string temp_str = "";
                        string last_ljh = "";
                        // 1 ��õ�ǰ�ǵڼ���
                        comboBox1.Invoke(new Action(() =>
                        {
                            // cur_index = int.Parse(comboBox1.SelectedItem.ToString().Replace("����", ""));
                            cur_index = comboBox1.SelectedIndex + 1;
                        }));

                        // 2 ѭ����� ����ĸ���
                    
                        this.chartControl1.Invoke(new Action(() =>
                        {
                            this.chartControl1.Series[0].Points.Clear();
                            this.chartControl1.Series[1].Points.Clear();
                            this.chartControl1.Series[2].Points.Clear();
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

                            if (dgv1.Rows[0].Cells["���Խ��"].Value.ToString() == "")
                            {
                                cur_index--;
                                if (cur_index < 1)
                                    cur_index = 1;
                            }
                            Console.WriteLine(results[cur_index - 1]);
                            this.chartControl1.Invoke(new Action(() =>
                            {
                                nt++;
                                if (test_obj.PN == "")
                                    test_obj.PN = "0";
                                if (results[cur_index - 1] != "")
                                {                // ����ֵ
                                    double LL = Convert.ToDouble(txtll.Text);
                                    // ����ֵ
                                    double GC = Convert.ToDouble(txtgc.Text);
                                    // ����ֵ
                                    double BZ = Convert.ToDouble(results[cur_index - 1] == "" ? "0" : results[cur_index - 1]);

                                    double cz = LL + GC;
                                    double hz = LL + GC;
                                    if (BZ >= hz)
                                    {
                                        this.chartControl1.Series[1].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, results[cur_index - 1] == "" ? "0" : results[cur_index - 1]));
                                    }
                                    if (BZ < cz)
                                    {
                                        this.chartControl1.Series[2].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, results[cur_index - 1] == "" ? "0" : results[cur_index - 1]));
                                    }
                                    double cur_de = Convert.ToDouble(results[cur_index - 1]);
                                }
                                //this.chartControl1.Series[0].Points.Insert(0,new DevExpress.XtraCharts.SeriesPoint( results[cur_index - 1] == "" ? "0" : results[cur_index - 1]));
                                this.chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, results[cur_index - 1] == "" ? "0" : results[cur_index - 1]));
                                temp_str = results[cur_index - 1];
                                last_ljh = test_obj.PN;
                            }));
                        }
                        Console.WriteLine(string.Format("this.chartControl1.Series[0].Points {0} == {1}", nt, temp_str));
                        nt += 1;
                        // ��� �鵽�����һλ�����ڵĲ�һ��  ��ô�ͼ����µ�
                        if (dgv1.Columns.Contains("�����") && dgv1.Rows.Count > 0 && last_ljh != dgv1.Rows[0].Cells["�����"].Value.ToString())
                        {
                            comboBox1.Invoke(new Action(() =>
                            {
                                // cur_index = int.Parse(comboBox1.SelectedItem.ToString().Replace("����", ""));
                                cur_index = comboBox1.SelectedIndex + 1;
                            }));
                            cur_index--;
                            if (cur_index < 1)
                                cur_index = 1;
                            string col_name = comboBox1.Items[cur_index].ToString();
                            value = dgv1.Rows[0].Cells[col_name].Value.ToString();
                            if (value == "")
                                return "" ;
                            double LL = Convert.ToDouble(txtll.Text);
                            // ����ֵ
                            double GC = Convert.ToDouble(txtgc.Text);
                            // ����ֵ
                            double BZ = Convert.ToDouble(value);

                            double cz = LL + GC;
                            double hz = LL + GC;
                            if (BZ >= hz)
                            {
                                this.chartControl1.Series[1].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, value));
                            }
                            if (BZ < cz)
                            {
                                this.chartControl1.Series[2].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, value));
                            }
                            //double cur_de = Convert.ToDouble(results[cur_index - 1]);                
                            this.chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(nt, value));
                            Console.WriteLine(string.Format("this.chartControl1.Series[1].Points {0} == {1}", nt, value));
                        }

                    }
                    catch (IndexOutOfRangeException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                return nt.ToString();
            });

            one.Start();
            }
        }

        private void temp_add_serpoint(string value)
        {
            int n = this.chartControl1.Series[0].Points.Count;
            this.chartControl1.Invoke(new Action(() =>
            {
                n+=2;
                if (value != "")
                {                // ����ֵ
                    double LL = Convert.ToDouble(txtll.Text);
                    // ����ֵ
                    double GC = Convert.ToDouble(txtgc.Text);
                    // ����ֵ
                    double BZ = Convert.ToDouble(value);

                    double cz = LL + GC;
                    double hz = LL + GC;
                    if (BZ >= hz)
                    {
                        this.chartControl1.Series[1].Points.Add(new DevExpress.XtraCharts.SeriesPoint(n, value));
                    }
                    if (BZ < cz)
                    {
                        this.chartControl1.Series[2].Points.Add(new DevExpress.XtraCharts.SeriesPoint(n, value));
                    }
                    //double cur_de = Convert.ToDouble(results[cur_index - 1]);                
                    this.chartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(n, value));
                    chartControl1.Refresh();
                    chartControl1.RefreshData();
                }
                //this.chartControl1.Series[0].Points.Insert(0,new DevExpress.XtraCharts.SeriesPoint( results[cur_index - 1] == "" ? "0" : results[cur_index - 1]));

            }));
        }

        /*
        private SceneNode ShowTopoShape(TopoShape topoShape, int id)
        {
            // Add the TopoShape to Scene.
            //TopoShapeConvert convertor = new TopoShapeConvert();
            //SceneNode faceNode = convertor.ToFaceNode(topoShape, 0.5f);
            //faceNode.SetId(id);
            //theView.GetSceneManager().AddNode(faceNode);
            //return faceNode;
        }*/


        private void test()
        {
            return;
            //TopoShape box = shapeMaker.MakeBox(new Vector3(40, -20, 0), new Vector3(0, 0, 1), new Vector3(30, 40, 60));

            //SceneNode sceneNode = ShowTopoShape(box, 101);

            //FaceStyle style = new FaceStyle();
            //style.SetColor(new ColorValue(0.5f, 0.3f, 0, 1));
            //sceneNode.SetFaceStyle(style);

            //TopoShape cylinder = shapeMaker.MakeCylinder(new Vector3(80, 0, 0), new Vector3(0, 0, 1), 20, 100, 315);
            //SceneNode sceneNode1 = ShowTopoShape(cylinder, 102);
            //FaceStyle style1 = new FaceStyle();
            //style.SetColor(new ColorValue(0.1f, 0.3f, 0.8f, 1));
            //sceneNode.SetFaceStyle(style);

            //int size = 20;
            //// Create the outline edge
            //TopoShape arc = shapeMaker.MakeArc3Pts(new Vector3(-size, 0, 0), new Vector3(size, 0, 0), new Vector3(0, size, 0));
            //TopoShape line1 = shapeMaker.MakeLine(new Vector3(-size, -size, 0), new Vector3(-size, 0, 0));
            //TopoShape line2 = shapeMaker.MakeLine(new Vector3(size, -size, 0), new Vector3(size, 0, 0));
            //TopoShape line3 = shapeMaker.MakeLine(new Vector3(-size, -size, 0), new Vector3(size, -size, 0));

            //TopoShapeGroup shapeGroup = new TopoShapeGroup();
            //shapeGroup.Add(line1);
            //shapeGroup.Add(arc);
            //shapeGroup.Add(line2);
            //shapeGroup.Add(line3);

            //TopoShape wire = shapeMaker.MakeWire(shapeGroup);
            //TopoShape face = shapeMaker.MakeFace(wire);

            //// Extrude
            //TopoShape extrude = shapeMaker.Extrude(face, 100, new Vector3(0, 0, 1));
            //ShowTopoShape(extrude, 104);

            //// Check find....
            //SceneNode findNode = theView.GetSceneManager().FindNode(104);
            //theView.GetSceneManager().SelectNode(findNode);

        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            //ViewUtility.OnMouseWheelEvent(theView, e);
        }
        private void panel3d_Paint(object sender, PaintEventArgs e)
        {
            if (theView == null)
                return;
            theView.Redraw();
        }

        private void panel3d_MouseDown(object sender, MouseEventArgs e)
        {
            //ViewUtility.OnMouseDownEvent(theView, e);
        }

        private void panel3d_MouseMove(object sender, MouseEventArgs e)
        {
            return;
            //MessageBox.Show(theView.ToString());
            //ViewUtility.OnMouseMoveEvent(theView, e);
        }

        private void panel3d_MouseUp(object sender, MouseEventArgs e)
        {
            return;
            //ViewUtility.OnMouseUpEvent(theView, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            return;
            //theView.RequestDraw();
            //theView.Redraw();
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
            int test_row = 0;
            if (textcl.Text == "")
            {
            
            }
            else {
                #region �жϵ�ǰ�Ĳ��ԣ� �ǲ��Ǻ����
                // ����ֵ
                double LL = Convert.ToDouble(txtll.Text);
                // ����ֵ
                double GC = Convert.ToDouble(txtgc.Text);
                // �¹��� 
                double XGc = Convert.ToDouble(txtbox_gcxia.Text);
                // ����ֵ
                double BZ = Convert.ToDouble(textcl.Text);

                double cz = LL + XGc;
                double hz = LL + GC;
                if (BZ >= cz && BZ <= hz)
                {
                    this.combjg.Text = "Ok";
                    lab_cc.ForeColor = Color.Green;
                    lab_cc.Text = (BZ).ToString();
                    label5.Text = "�ϸ�";
                }
                else
                {
                    // Console.Beep();
                    combjg.Text = "Ng";
                    label5.Text = "����";
                    lab_cc.Font = new System.Drawing.Font(lab_cc.Font.FontFamily, 36, lab_cc.Font.Style);

                    Console.WriteLine(string.Format("BZ :{0} == hz {1} -- cz{2}", BZ, hz, cz));
                    if (BZ > hz)
                    {
                        lab_cc.ForeColor = Color.Red;
                        lab_cc.Text = "+" + (BZ - hz).ToString("f3");
                    }
                    if (BZ < cz)
                    {
                        lab_cc.ForeColor = Color.Blue;
                        lab_cc.Text = "-" + (cz - BZ).ToString("f3");
                    }

                }

                if (lab_cc.Text.Length > 4)
                {
                    //System.Drawing.Font tremp = lab_cc.Font;
                    //tremp.Size = 30;
                    lab_cc.Font = new System.Drawing.Font(lab_cc.Font.FontFamily, 30, lab_cc.Font.Style);
                }
                #endregion
            }

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
                comboBox1.SelectedIndex = 0;
                // ����ѡ��
                this.dgv1.Rows[0].Selected = true;
                this.dgv1.CurrentCell = this.dgv1.Rows[0].Cells[this.dgv1.CurrentCell.ColumnIndex];
                string str = "";
                if (this.CompId != null && this.CompId != "")
                {
                    str = CompId;
                }
                else
                {
                    QrDlg qr_dlg = new QrDlg();
                    if (qr_dlg.ShowDialog() == DialogResult.OK)
                    {
                        str = qr_dlg.MyCode;
                    }
                    // str = Interaction.InputBox("���ֶ��������ʹ��ɨ��ǹ", "��������", "", -1, -1);
                }
                need_change_rows["�����"] = str;
                this.CompId = "";
            }
            this.timer_tostep.Enabled = true;
            #endregion


            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("componentId = '{0}'", this.comp_type);
            DataSet ds1 = mes.GetList(st);
            #region ������������ ��ÿ�����Խ����ֵ
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                // string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                string sg = ds1.Tables[0].Rows[i]["CC"].ToString();
                if (comboBox1.Text == sg)
                {
                    for (int j = 0; j < dgv1.Rows.Count; j++)
                    {
                        need_change_rows[comboBox1.Text] = textcl.Text;
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
                
                dgv1.Rows[test_row].Cells["���Ա��"].Value = dnum;
                dgv1.Rows[test_row].Cells["����ʱ��"].Value = DateTime.Now.ToString();
            }

            #region �ж��ǲ��ǿ��� ok ����ng�� 
            //int last_row1 = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            int CL = dt.Columns.Count;
            
            string fz = dt.Rows[test_row][CL - 2].ToString();
            if (comboBox1.SelectedIndex + 1 == CL-4)
            {
                int t = dt.Columns.Count - 4;
                for (int a = 0; a < t; a++)
                {
                    string dd = "";
                    // string col_name = string.Format("����{0}", a + 1);
                    string cur_index = comboBox1.Items[a].ToString();
                    dd = dt.Rows[test_row][cur_index].ToString();

                    txtll.Text = ds1.Tables[0].Rows[a][4].ToString();
                    string shang_gc = ds1.Tables[0].Rows[a][5].ToString();
                    string xia_gc = ds1.Tables[0].Rows[a][6].ToString();
                    double xcz = 0;
                    double xhz = 0;
                    if (txtll.Text != null)
                    {
                        xcz = Convert.ToDouble(txtll.Text) + Convert.ToDouble(xia_gc);
                        xhz = Convert.ToDouble(txtll.Text) + Convert.ToDouble(shang_gc);
                    }
                    
                    if (dd == "" || ( dd!= "" && Convert.ToDouble(dd) >= xcz && Convert.ToDouble(dd) <= xhz))
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
                }

                //���ñ���
                buttonX1_Click(sender, e);

                string str = "";
                if (need_change_rows["�����"].ToString() == "")
                {
                    QrDlg qr_dlg = new QrDlg();
                    if (qr_dlg.ShowDialog() == DialogResult.OK)
                    {
                        str = qr_dlg.MyCode;
                    }
                    //str = Interaction.InputBox("���ֶ��������ʹ��ɨ��ǹ", "��������", "", -1, -1);
                    need_change_rows["�����"] = str;
                }
                this.CompId = "";
              
                re_test = false;
            }
            #endregion
        }
 
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            int test_index = 0;
            // MessageBox.Show(dgv1.Rows[test_index].Cells["���Խ��"] .Value.ToString());
            if (dgv1.Rows.Count >= 1 && (dgv1.Rows[test_index].Cells["���Խ��"].Value == null || dgv1.Rows[test_index].Cells["���Խ��"].Value.ToString() == ""))
            {
                if (this.comboBox1.SelectedIndex + 1 == this.comboBox1.Items.Count)
                {
                    this.textcl.Text = "";
                }
                if (this.comboBox1.Items.Count > this.comboBox1.SelectedIndex + 1)
                {
                    this.comboBox1.SelectedIndex += 1;
                }

            }
            else {
                DataTable dt = dgv1.DataSource as DataTable;
                DataRow need_change_rows = dt.NewRow();
                // dt.Rows.Add(need_change_rows);
                dt.Rows.InsertAt(need_change_rows, 0);
                // ����ѡ��
                this.dgv1.Rows[0].Selected = true;
                this.dgv1.CurrentCell = this.dgv1.Rows[0].Cells[this.dgv1.CurrentCell.ColumnIndex];

                string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string dnum = num.ToString();
           
                dgv1.Rows[0].Cells["���Ա��"].Value = dnum;
                dgv1.Rows[0].Cells["����ʱ��"].Value = DateTime.Now.ToString();
                string str = "";
                if (this.CompId != null && this.CompId != "")
                {
                    str = CompId;
                }
                else
                {
                    QrDlg qr_dlg = new QrDlg();
                    if (qr_dlg.ShowDialog() == DialogResult.OK)
                    {
                        str = qr_dlg.MyCode;
                    }
                    // str = Interaction.InputBox("���ֶ��������ʹ��ɨ��ǹ", "��������", "", -1, -1);
                }
                need_change_rows["�����"] = str;
                this.CompId = "";
                if (this.comboBox1.Items.Count > 1)
                {
                    this.comboBox1.SelectedIndex = 1;
                }
            }

            if (re_test)
            {
                if (test_qu.Count > 0)
                {
                    string the_one = test_qu.Pop();
                    comboBox1.SelectedItem = the_one;
                }
                else if (test_qu.Count == 0)
                {
                    int last = this.comboBox1.Items.Count;
                    this.comboBox1.SelectedIndex = last - 1;
                    string last_step = this.comboBox1.SelectedItem.ToString();
                    textcl.Text = this.dgv1.Rows[0].Cells[last_step].Value.ToString();
                }
            }
        }
        Stack<string> test_qu = new Stack<string>();
        /// <summary>
        /// �ز�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX4_Click(object sender, EventArgs e)
        {
            test_qu.Clear();
            int start_rowsnum = -1;
       
            re_test = true;
            foreach (DataGridViewCell cell in dgv1.SelectedCells)
            {
                if (start_rowsnum == -1)
                {
                    start_rowsnum = cell.RowIndex;
                }

                if (start_rowsnum == cell.RowIndex)
                {
                    test_qu.Push(dgv1.Columns[cell.ColumnIndex].Name);
                }
            }

            // MessageBox.Show(comboBox1.Items.Contains("����1").ToString());
            // comboBox1.SelectedItem = "����2";
            string colname = this.dgv1.Columns[this.dgv1.CurrentCell.ColumnIndex].HeaderText;
            comboBox1.SelectedItem = colname;
            //colname = colname.Replace("����", "");

            //int col_num = 0;
            //if (int.TryParse(colname, out col_num))
            //{
            //    this.comboBox1.SelectedIndex = col_num > 0 ? col_num - 1 : 0;
            //}

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

            if (re_test)
            {
                if (test_qu.Count > 0)
                {
                    string the_one = test_qu.Pop();
                    comboBox1.SelectedItem = the_one;
                }
                else if (test_qu.Count == 0)
                {
                    int last = this.comboBox1.Items.Count;
                    this.comboBox1.SelectedIndex = last - 1;
                    string last_step = this.comboBox1.SelectedItem.ToString();
                    textcl.Text = this.dgv1.Rows[0].Cells[last_step].Value.ToString();
                }
            }
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
            int col_count = dt.Columns.Count - 4;

            //for (int n=0; n<dt.Columns.Count; n++)
            //{
            //    Console.WriteLine(dt.Columns[n].ColumnName);
            //}
            if(dgv1.Rows.Count > 0 )
            {
                string str = "";
                var need_change_rows = (dgv1.DataSource as DataTable).Rows[0];
                if (need_change_rows["�����"].ToString() == "")
                {
                    QrDlg qr_dlg = new QrDlg();
                    if (qr_dlg.ShowDialog() == DialogResult.OK)
                    {
                        str = qr_dlg.MyCode;
                    }
                    // str = Interaction.InputBox("���ֶ��������ʹ��ɨ��ǹ", "��������", "", -1, -1);
                    if (str == "")
                    {
                        MessageBox.Show("����������ţ� �����޷�����");
                        return;
                    }
                    need_change_rows["�����"] = str;
                }
                this.CompId = "";
            }


            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            List<Maticsoft.Model.test>  tear_mode = test_bll.GetModelList(string.Format(" measureb='{0}'", dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString()));
            if (tear_mode.Count == 0)
            {
                for (int i = 0; i < col_count; i++)
                {
                    // string col_name = string.Format("����{0}", i + 1);
                    string col_name = comboBox1.Items[i].ToString();
                    //join_point += dgv1.Rows[last_row].Cells[col_name].Value.ToString();
                    join_point += dt.Rows[test_rowindex][col_name].ToString();
                    if (i == col_count - 1)
                    { break; }
                    join_point += "/";
                }
                string lingjianhao = dgv1.Rows[test_rowindex].Cells["�����"].Value.ToString();
                string bh = dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString();
                string sj = dgv1.Rows[test_rowindex].Cells["����ʱ��"].Value.ToString();
                string JG = dgv1.Rows[test_rowindex].Cells["���Խ��"].Value.ToString();

                string where_str = " 1=1 and ";
                where_str += string.Format("  parts.PN = '{0}' OR parts.Barcode = '{1}' ", lingjianhao, lingjianhao);
                Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
                int totle_num = parts_bll.GetRecordCount(where_str);
                if (totle_num <=0)
                {
                    // DialogResult n = MessageBox.Show("��û�з���������,�Ƿ��Զ����", "������", MessageBoxButtons.YesNoCancel);
                    
                    if (DialogResult.Yes == MessageBox.Show("��û�з���������,�Ƿ��Զ����", "������", MessageBoxButtons.YesNoCancel))
                    {
                        List<Maticsoft.Model.parts> part_mode_list = parts_bll.GetModelList(string.Format("componentId = {0} ORDER BY parts.id DESC LIMIT 1", comp_type));
                        if (part_mode_list.Count != 1)
                        {
                            // MessageBox.Show("���ݲ���ȷ" + "==== comp_type ===" + comp_type);
                            Maticsoft.Model.parts temp_part_mode = new parts()
                            {
                                id = 0 ,
                                PN = lingjianhao,
                                Barcode = lingjianhao,
                                componentId = comp_type,
                            };
                            if (parts_bll.Add(temp_part_mode))
                            {
                                // MessageBox.Show("���ݱ���ɹ�");
                            }
                            else
                            {
                                MessageBox.Show("���ݱ���ʧ��");
                            }
                        }
                        else {
                            Maticsoft.Model.parts temp_part_mode = part_mode_list[0];
                            temp_part_mode.id = 0 ;
                            temp_part_mode.PN = lingjianhao;
                            temp_part_mode.Barcode = lingjianhao;
                            if (parts_bll.Add(temp_part_mode))
                            {
                                // MessageBox.Show("���ݱ���ɹ�");
                            }
                            else
                            {
                                MessageBox.Show("���ݱ���ʧ��");
                            }
                        }
                    }
                    else return;
                }
                List<Maticsoft.Model.test>  pa_modes = test_bll.GetModelList2(where_str);
                foreach (Maticsoft.Model.test test_mode in pa_modes)
                {
                    test_bll.Delete(test_mode.id);
                }
                Maticsoft.Model.test us = new test()
                {
                    measureb = bh,
                    time = Convert.ToDateTime(sj),
                    step1 = join_point,
                    OKorNG = JG,
                    PN = lingjianhao,
                    workid = txtkw.Text
                };
                test_bll.Add(us);

                /*
                if (totle_num > 0)
                {
                    MessageBox.Show("���ִ������ǰ�Ĳ�������,���ڽ�������ǰ������");
                    pa_modes[0].measureb = bh;
                    pa_modes[0].time = Convert.ToDateTime(sj);
                    pa_modes[0].step1 = join_point;
                    pa_modes[0].OKorNG = JG;
                    pa_modes[0].PN = lingjianhao;
                    pa_modes[0].workid = txtkw.Text;
                    test_bll.Update(pa_modes[0]);
                }
                else {
                }*/

            }
            else if (tear_mode.Count == 1)
            {
                for (int i = 0; i < col_count; i++)
                {
                    // string col_name = string.Format("����{0}", i + 1);
                    string col_name = comboBox1.Items[i].ToString();
                    //join_point += dgv1.Rows[last_row].Cells[col_name].Value.ToString();
                    join_point += dt.Rows[test_rowindex][col_name].ToString();
                    if (i == col_count - 1)
                    { break; }
                    join_point += "/";
                }

                string lingjianhao2 = dgv1.Rows[test_rowindex].Cells["�����"].Value.ToString();
                string bh = dgv1.Rows[test_rowindex].Cells["���Ա��"].Value.ToString();
                string sj = dgv1.Rows[test_rowindex].Cells["����ʱ��"].Value.ToString();
                string JG = dgv1.Rows[test_rowindex].Cells["���Խ��"].Value.ToString();
                // MessageBox.Show(join_point);  

                Maticsoft.BLL.test use = new Maticsoft.BLL.test();
                Maticsoft.Model.test us = tear_mode[0];
                us.time = Convert.ToDateTime(sj);
                us.step1 = join_point;
                us.OKorNG = JG;
                use.Update(us);
            }
            else {
                MessageBox.Show("��¼�ظ��� ��������ݿ� ");
            }
            // MessageBox.Show("��¼�Ա���");

            #endregion
            
            // textcl.Text = "";
            init_table();
            this.comboBox1.SelectedIndex = 0;
            return;
            
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
            DataTable dtb = this.dgv1.DataSource as DataTable;
            dtb.Clear();
            #region ��������dgv����

            Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
            List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList2(string.Format("  parts.componentId = '{0}'  ORDER BY test.time asc LIMIT 100", this.comp_type));
            int test_count = test_lists.Count;

            //Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
            //string TS = string.Format("PN = '{0}'", lble.Text);
            //DataSet dst = tst.GetList(TS);
            //DataTable test_datatable = dst.Tables[0];
            //int test_count = test_datatable.Rows.Count;
            for (int start_test = 0; start_test < test_count; start_test++)
            {
                string bh = test_lists[start_test].measureb.ToString();
                string sj = test_lists[start_test].time.ToString();
                string stp1 = test_lists[start_test].step1.ToString();
                //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["�����"] = test_lists[start_test].PN;
                dr["���Ա��"] = bh;
                dr["����ʱ��"] = sj;
                dr["���Խ��"] = test_lists[start_test].OKorNG.ToString();
                foreach (string j in sp)
                {
                    if (sp_num < comboBox1.Items.Count)
                    {
                        string col_name = comboBox1.Items[sp_num].ToString();
                        if (dtb.Columns.Contains(col_name))
                        { dr[col_name] = j; }
                    }
                    sp_num++;
                    // string col_name = string.Format("����{0}", sp_num);
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
            // string com_step = comboBox1.Text.Replace("����", "");
            string st1 = string.Format("componentId = '{0}' and  CC='{1}'", this.comp_type, comboBox1.Text);
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

        Dictionary<int, FaceStyle> key_colors = new Dictionary<int, FaceStyle>();
        string[] position_list = null;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearcolor();
            int index = comboBox1.SelectedIndex;
            string device_type = measures_tables.Rows[index]["devicetype"].ToString();
            string loc_position = measures_tables.Rows[index]["position"].ToString();

            position_list = loc_position.Split(',');
            init_portbytype(Convert.ToInt32(device_type));
            init_photobytype(Convert.ToInt32(device_type));

            this.InitTestData();
            // create_serpoint(textcl.Text);

            if (ports_list.Count <= 0)
            {
                return;
            }
            lab_defportname.Text = ports_list[0].manufacturer + " - " + ports_list[0].portname;
            txtkw.Text = ports_list[0].workid;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbb_canselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(cbb_canselect.SelectedValue.ToString() + " == " + cbb_canselect.SelectedText + " 11 " + cbb_canselect.SelectedItem.ToString());
            MessageBox.Show(ports_list[cbb_canselect.SelectedIndex].manufacturer);
            lab_defportname.Text = ports_list[cbb_canselect.SelectedIndex].manufacturer + " - " + ports_list[cbb_canselect.SelectedIndex].portname;
            // txtkw.Text = ports_list[cbb_canselect.SelectedIndex].portname.Replace("COM", "");
            txtkw.Text = ports_list[cbb_canselect.SelectedIndex].workid;
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

            //���������ĵط�
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
            string dir = System.Environment.CurrentDirectory;
            SoundPlayer player = new SoundPlayer();
            if (lab_cc.ForeColor != Color.Green) {
                //Console.Beep();
                //Console.Beep();
                //Console.Beep();    
                player.SoundLocation = dir + "\\Audio\\faulse.wav";
                player.Load();
                player.Play();
            }
            else
            {
                player.SoundLocation = dir + "\\Audio\\right.wav";
                player.Load();
                player.Play();
            }
            if (this.comboBox1.Items.Count > this.comboBox1.SelectedIndex + 1)
            {
                this.comboBox1.SelectedIndex += 1;
            }
            this.timer_tostep.Enabled = false;
            if (re_test)
            {
                if (test_qu.Count > 0)
                {
                    string the_one = test_qu.Pop();
                    comboBox1.SelectedItem = the_one;
                }
                else if (test_qu.Count == 0)
                {
                    int last = this.comboBox1.Items.Count;
                    this.comboBox1.SelectedIndex = last - 1;
                    string last_step = this.comboBox1.SelectedItem.ToString();
                    textcl.Text = this.dgv1.Rows[0].Cells[last_step].Value.ToString();
                }
            }
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

        private void timer_shine_Tick(object sender, EventArgs e)
        {
            n++;
            if (this.renderView!=null && this.renderView.SceneManager == null)
                return;
            if(position_list != null)
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

        private void StepTestFrom_MouseEnter(object sender, EventArgs e)
        {
            //this.renderView.RequestDraw();
            
        }
        private void aa_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel3d_MouseEnter(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            renderView.FitAll();
            renderView.RequestDraw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            renderView.Height += 1;
        }

        private void timer_ref_Tick(object sender, EventArgs e)
        {
            this.renderView.Height += 1;
            this.renderView.Height -= 1;
        }

        private void txtkw_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void combjg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

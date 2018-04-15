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

namespace NepslidingTools.testModel
{
    public partial class StepTestFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        // The global application object
        public static AnyCAD.Platform.Application theApplication;
        string name = "steptest";
        // BREP tool to create geometries.
        BrepTools shapeMaker = new BrepTools();
        // Default 3d View
        AnyCAD.Platform.View3d theView;

        public StepTestFrom()
        {
            InitializeComponent();
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OnMouseWheel);
        }

        public void jiangyaozhixin(string a)
        {
            textcl.Invoke(new Action(() =>
            {
                textcl.Text = a;
            }));
          
           
            //Console.WriteLine("我将要执行aaa计划");
        }

        private void StepTestFrom_Load(object sender, EventArgs e)
        {
            MessageBox.Show("界面开始了");
            try
            {
                if (StepTestFrom.theApplication == null)
                {
                    StepTestFrom.theApplication = new AnyCAD.Platform.Application();
                    StepTestFrom.theApplication.Initialize();
                }
                Size size = panel3d.Size;
                // Create the 3d View
                theView = theApplication.CreateView(panel3d.Handle.ToInt32(), size.Width, size.Height);

                theView.RequestDraw();
                Console.WriteLine(theView.ToString());

                lble.Text = Program.txtbh;
                DataTable dtb = new DataTable();
                #region 构建datatable 表
                Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
                string st = string.Format("PN = '{0}'", lble.Text);
                DataSet ds1 = mes.GetList(st);
                dtb.Columns.Add("测试编号");
                dtb.Columns.Add("测试时间");
           
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    string sg = "步骤" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                    comboBox1.Text = sg;                                
                    dtb.Columns.Add( sg.ToString());                
                    //dgv1.DataSource = ds.Tables[0];                
                }
                dtb.Columns.Add("测试结果");
                #endregion
                #region 填充数据
                Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
                string TS = string.Format("PN = '{0}'", lble.Text);
                DataSet dst = tst.GetList(TS);
                DataTable test_datatable = dst.Tables[0];
                int test_count = test_datatable.Rows.Count;
                for(int start_test =0;start_test < test_count ; start_test ++)
                {
                    string bh= test_datatable.Rows[start_test]["measureb"].ToString();
                    string sj= test_datatable.Rows[start_test]["time"].ToString();
                    string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                    //string stp1 = dst.Tables[0].Rows[i][4].ToString();
                    string[] sp = stp1.Split(new char[] { '/' });//获取数据集合                 
                    int sp_num = 0;                
                    DataRow dr = dtb.NewRow();
                    dr["测试编号"]= bh;
                    dr["测试时间"]= sj;
                    dr["测试结果"]= test_datatable.Rows[start_test]["OKorNG"].ToString();
                    foreach (string j in sp)
                    {
                        sp_num++;
                        string col_name = string.Format("步骤{0}", sp_num);
                        dr[col_name] = j;                 
                    }  
                    dtb.Rows.Add(dr);        
                }
                #endregion   
                dgv1.DataSource =dtb;
            
                //Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
                //string aa = string.Format("PN = '{0}'", lble.Text);
                //DataSet ds = usec.GetList(aa);
                //string stp1 = ds.Tables[0].Rows[1][4].ToString();
                //string[] sp = stp1.Split(new char[] { '/' });//获取数据集合
                //foreach (string j in sp) ;
           

                //Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
                //string aa = string.Format("PN = '{0}'", lble.Text);
                //DataSet ds = usec.GetList(aa);
                ////DataSet ds = usec.GetAllList();
                //dgv1.DataSource = ds.Tables[0];

                //if (comboBox1.Text=="第一步") {
                Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                string st1 = string.Format("PN = '{0}'", lble.Text);
                DataSet ds11 = mes1.GetList(st1);
                //DataTable dt = new DataTable();
                //ds1.Tables.Add(dt);
            
                for (int i=0; i<ds11.Tables[0].Rows.Count;i++)
                {
                    txtll.Text = ds11.Tables[0].Rows[i][4].ToString();
                    comboBox1.Items.Add("步骤"+ds11.Tables[0].Rows[i]["step"].ToString());
                }
                // }


                SerPort sp_obj = new SerPort();
                 sp_obj.init_port();
                sp_obj.Processfunc = jiangyaozhixin;
                      
                global.CurActive = "steptest";
                //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
                //this.Size = ScreenArea.Size;
                //Location = (Point)new Size(0, 0);
                //this.TopMost = true;
                //this.Activate();
                //DataTable dt = new DataTable();//创建表
                //dt.Columns.Add("nearNo", typeof(string));//添加列
                //dt.Columns.Add("TestTime", typeof(DateTime));
                //dt.Columns.Add("OkOrNg", typeof(String));
                //dt.Columns.Add("step1", typeof(String));
                //dt.Columns.Add("step2", typeof(String));
                //dt.Columns.Add("step3", typeof(String));
                //dt.Columns.Add("step4", typeof(String));
                //dt.Columns.Add("step5", typeof(String));
                //dt.Rows.Add(new object[] { "2017113212200101", DateTime.Now, "OK", "0.1", "0", "1", "0.12", "-0.1" });//添加行
                //dt.Rows.Add(new object[] { "2017113212200102", DateTime.Now, "NG", "-0.2", "0", "0.1", "0", "0" });
                //dt.Rows.Add(new object[] { "2017113212200103", DateTime.Now, "OK", "0.1", "-0.1", "0.2", "0", "0.1" });
                //this.dgv1.DataSource = dt;


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            this.timer1.Enabled = true;
            //this.test();
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
            this.Dispose();
        }

        private void toptime_Tick(object sender, EventArgs e)
        {
        }

        private void StepTestFrom_Deactivate(object sender, EventArgs e)
        {
            //if (global.CurActive == this.name)
            //{
            //    Console.WriteLine("当前激活界面是: " + this.name);
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
            double LL = Convert.ToDouble(txtll.Text);
            double GC = Convert.ToDouble(txtgc.Text);
            double BZ = Convert.ToDouble(textcl.Text);

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
            DataTable dt = dgv1.DataSource as DataTable;
            DataRow need_change_rows = null;

            //DataColumn need_change_count = null;
            foreach (DataRow temp in dt.Rows)
            {
                int col_num = dt.Columns.Count;
                //Console.WriteLine(string.Format("temp[col_num -1 ] == {0}", temp[col_num-1]));
                if (temp[col_num - 1].ToString() == "")
                {
                    need_change_rows = temp;
                    break;
                }
            }
            if (need_change_rows == null)
            {
                need_change_rows = dt.NewRow();
                dt.Rows.Add(need_change_rows);
            }
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", lble.Text);
            DataSet ds1 = mes.GetList(st);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "步骤" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                if (comboBox1.Text == sg)
                {
                    int last_row = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                    string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string dnum = num.ToString();
                    dgv1.Rows[last_row].Cells["测试编号"].Value = dnum;
                    dgv1.Rows[last_row].Cells["测试时间"].Value = DateTime.Now.ToString();
                    for (int j = 0; j < dgv1.Rows.Count; j++)
                    {
                        need_change_rows[comboBox1.Text] = textcl.Text;
                        //string BJ = need_change_rows[comboBox1.Text].ToString(); 
                    }
                }
            }
            int last_row1 = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            int CL = dt.Columns.Count;
            string fz = dt.Rows[last_row1][CL - 2].ToString();
            if (fz != "")
            {
                int t = dt.Columns.Count - 3;
                for (int a = 0; a < t; a++)
                {
                    string dd = "";
                    string col_name = string.Format("步骤{0}", a + 1);
                    dd += dt.Rows[last_row1][col_name];
                    Maticsoft.BLL.measures mesq = new Maticsoft.BLL.measures();
                        string ste = string.Format("PN = '{0}'", lble.Text);
                        DataSet dsf = mesq.GetList(ste);
                    //for (int i = 0; i < dsf.Tables[0].Rows.Count; i++)
                    //{
                        string sg = "步骤" + dsf.Tables[0].Rows[a]["step"].ToString();// comboBox1.Items.Add()

                        comboBox1.Text = sg;               
                                Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                                string st1 = string.Format("PN = '{0}'", lble.Text);
                                DataSet ds11 = mes1.GetList(st1);
                        //for (int b = 0; b < ds11.Tables[0].Rows.Count; b++)
                        //{
                        
                        txtll.Text = ds11.Tables[0].Rows[a][4].ToString();
                        
                        cz = Convert.ToDouble(txtll.Text) - Convert.ToDouble(txtgc.Text);
                                    hz = Convert.ToDouble(txtll.Text) +Convert.ToDouble(txtgc.Text);
                                   
                                    string tt = "";
                                    if (Convert.ToDouble(dd) >= cz && Convert.ToDouble(dd) <= hz)
                                    {
                                        //need_change_rows["测试结果"] = "Ok";
                                        tt = "Ok";
                                        
                        }
                                    else
                                    {
                                        tt = "Ng";
                                      
                            //need_change_rows["测试结果"] = "NG";
                        }
                                    if (tt != "Ok")
                                    {
                                        need_change_rows["测试结果"] = "NG";
                                        break;
                                    }
                                    else
                                    {
                                        need_change_rows["测试结果"] = "Ok";                                    
                        }
                              //  }
                  
                }
                }
            }
        





            //if (dt.Columns[dt.Columns.Count-2].ToString() != "")
            //if (comboBox1.Text == "步骤1")
            //{
            //    for (int i=0;i<dgv1.Rows.Count ;i++) {
            //        //dt.Columns.Add();
            //        need_change_rows[comboBox1.Text] = textcl.Text;
            //        dgv1.Rows[i].Cells["测试时间"].Value = DateTime.Now.ToString();
            //        //need_change_rows["TestTime"] = DateTime.Now.ToString();
            //        // need_change_rows["step1"] = textcl.Text;
            //       // Random rd = new Random();
            //        string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //        //int num2 = rd.Next(Convert.ToInt32( num));
            //        string dnum = num.ToString();
            //        dgv1.Rows[i].Cells["测试编号"].Value = dnum;
            //        // need_change_rows["nearNo"] = dnum;
            //    }
            //    }

            //    if (comboBox1.Text == "步骤2")
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
            //    if (comboBox1.Text == "步骤3")
            //    {

            //        need_change_rows[comboBox1.Text] = textcl.Text;
            //        //need_change_rows["step3"] = textcl.Text;

            //    }
            //    if (comboBox1.Text == "步骤4")
            //    {

            //        need_change_rows[comboBox1.Text] = textcl.Text;
            //        //need_change_rows["step4"] = textcl.Text;

            //    }
            //    if (comboBox1.Text == "步骤5")
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
        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "步骤1";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string join_point = "";
            int last_row = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            //int col_count = dgv1.Columns.Count - 3;
            DataTable dt = dgv1.DataSource as DataTable;
            int col_count = dt.Columns.Count - 3;

            for (int i =0;i<col_count ;i ++)
            {
                string col_name = string.Format("步骤{0}", i+1);
                //join_point += dgv1.Rows[last_row].Cells[col_name].Value.ToString();
                join_point += dt.Rows[last_row][col_name].ToString();
                if(i == col_count -1 )
                { break; }
                join_point += "/";
            }
            string bh = dgv1.Rows[last_row].Cells["测试编号"].Value.ToString();
            string sj = dgv1.Rows[last_row].Cells["测试时间"].Value.ToString();
            string JG = dgv1.Rows[last_row].Cells["测试结果"].Value.ToString();
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
                };
                use.Add(us);
                
                MessageBox.Show("记录以保存");
            DataTable dtb = new DataTable();
            #region 构建datatable 表
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", lble.Text);
            DataSet ds1 = mes.GetList(st);
            dtb.Columns.Add("测试编号");
            dtb.Columns.Add("测试时间");

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "步骤" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                comboBox1.Text = sg;
                dtb.Columns.Add(sg.ToString());
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("测试结果");
            #endregion
            #region 填充数据
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
                string[] sp = stp1.Split(new char[] { '/' });//获取数据集合                 
                int sp_num = 0;
                DataRow dr = dtb.NewRow();
                dr["测试编号"] = test_datatable.Rows[start_test]["measureb"].ToString();
                dr["测试时间"] = test_datatable.Rows[start_test]["time"].ToString();
                dr["测试结果"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                foreach (string j in sp)
                {
                    sp_num++;
                    string col_name = string.Format("步骤{0}", sp_num);
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dgv1.DataSource = dt;
            int last_row1 = dgv1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
            for (int i=0;i<dgv1.ColumnCount ;i++) {
                dgv1.Rows[last_row1].Cells[i].Value = "";
            }
                //((DataTable)dgv1.DataSource).Rows[last_row1].Delete();
            //Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
            //string aa = string.Format("PN = '{0}''", lble.Text);
            //DataSet ds = usec.GetList(aa);
            //// DataSet ds = usec.GetAllList();
            //dgv1.DataSource = ds.Tables[0];


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", lble.Text);
            DataSet ds1 = mes.GetList(st);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "步骤" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                
                if (comboBox1.Text == sg)
                {
                    textcl.Text = "";
                    comboBox1.Text = ds1.Tables[0].Rows[i]["step"].ToString();
                    Maticsoft.BLL.measures aa = new Maticsoft.BLL.measures();
                    Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                    string st1 = string.Format("PN = '{0}' and  step='{1}'",lble.Text, comboBox1.Text);
                    DataSet ds11 = mes1.GetList(st1);
                    for (int j = 0; j < ds11.Tables[0].Rows.Count; j++)
                    {
                        txtll.Text = ds11.Tables[0].Rows[j][4].ToString();
                        
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
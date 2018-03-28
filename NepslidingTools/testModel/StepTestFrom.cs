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
            //lble.Text = Program.txtbh;
            lble.Text = Program.txtbh;
            Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
            string aa = string.Format("PN = '{0}'", lble.Text);
            DataSet ds = usec.GetList(aa);
            //DataSet ds = usec.GetAllList();
            dgv1.DataSource = ds.Tables[0];

            //if (comboBox1.Text=="第一步") {
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", lble.Text);
            DataSet ds1 = mes.GetList(st);
            //DataTable dt = new DataTable();
            //ds1.Tables.Add(dt);
            txtll.Text = ds1.Tables[0].Rows[0][4].ToString();
            for (int i=0; i<ds1.Tables[0].Rows.Count;i++)
            {
                comboBox1.Items.Add("步骤"+ds1.Tables[0].Rows[i]["step"].ToString());
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
            if (StepTestFrom.theApplication == null)
            {
                StepTestFrom.theApplication = new AnyCAD.Platform.Application();
                StepTestFrom.theApplication.Initialize();
            }

            Size size = panel3d.Size;

            // Create the 3d View
            theView = theApplication.CreateView(panel3d.Handle.ToInt32(), size.Width, size.Height);

            theView.RequestDraw();

            this.timer1.Enabled = true;
            this.test();
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
            if (textcl.Text=="")
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

            //for (int i = 0; i < dgv1.Rows.Count; i++)
            //{
            DataTable dt = dgv1.DataSource as DataTable;
            dt.Columns.Add(comboBox1.Text);
            //DataRow dr = dt.NewRow();
            // dt.Rows.Add(dr);
            DataRow need_change_rows = null ;
            //DataColumn need_change_count = null;
            foreach (DataRow temp in dt.Rows)
            {
                int col_num = dt.Columns.Count;
                //Console.WriteLine(string.Format("temp[col_num -1 ] == {0}", temp[col_num-1]));
                if(temp[col_num -1].ToString() == "" )
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
            for (int i = 4; i < dt.Rows.Count; i++)
            {
                if (comboBox1.Text == "步骤1")
                {

                    //dt.Columns.Add();
                    need_change_rows[i] = textcl.Text;

                    need_change_rows["time"] = DateTime.Now.ToString();
                    // need_change_rows["step1"] = textcl.Text;
                    string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    //int num2 = rd.Next(0000, 9999);
                    string dnum = num.ToString();
                    need_change_rows["measureb"] = dnum;

                }

                if (comboBox1.Text == "步骤2")
                {

                    need_change_rows[11] = textcl.Text;

                    //need_change_rows["step2"] = textcl.Text;

                    //DataTable dt1 = dgv1.DataSource as DataTable;
                    //DataRow dr1 = dt1.NewRow();

                    //dr1["step2"] = textcl.Text;
                    //dt1.Rows.Add(dr1);

                    //DataTable dt = dgv1.DataSource as DataTable;
                    //string num = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    //int num2 = rd.Next(0000,9999);
                    //string dnum = num.ToString();
                    // dgv1.Rows[i].Cells["nearNo"].Value = dnum;
                    //dt.Rows.Add(1, dnum, DateTime.Now.ToString(), "", textcl.Text);

                }
                if (comboBox1.Text == "步骤3")
                {

                    need_change_rows[12] = textcl.Text;
                    //need_change_rows["step3"] = textcl.Text;

                }
                if (comboBox1.Text == "步骤4")
                {

                    need_change_rows[13] = textcl.Text;
                    //need_change_rows["step4"] = textcl.Text;

                }
                if (comboBox1.Text == "步骤5")
                {

                    need_change_rows[14] = textcl.Text;
                    //need_change_rows["step5"] = textcl.Text;
                    double stp1 = Convert.ToDouble(need_change_rows[10]);
                    double stp2 = Convert.ToDouble(need_change_rows[11]);
                    double stp3 = Convert.ToDouble(need_change_rows[12]);
                    double stp4 = Convert.ToDouble(need_change_rows[13]);
                    double stp5 = Convert.ToDouble(need_change_rows[14]);
                    if (stp1 >= cz && stp1 <= hz && stp2 >= cz && stp2 <= hz && stp3 >= cz && stp3 <= hz && stp4 >= cz && stp4 <= hz && stp5 >= cz && stp5 <= hz)
                    {
                        need_change_rows["OkOrNg"] = "Ok";
                    }
                    else
                    {
                        need_change_rows["OkOrNg"] = "Ng";
                    }
                    //DataTable dt = dgv1.DataSource as DataTable;
                    //dt.Rows.Add(1, "", "", "", "", "", "", textcl.Text);

                }
                //Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
                //string st = string.Format("PN = '{0}'", lble.Text);
                //DataSet ds1 = mes.GetList(st);
                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    comboBox1.Items.Add(ds1.Tables[0].Rows[i]["step"].ToString());
                //}
            }
            if (comboBox1.Text!="步骤1"&& comboBox1.Text != "步骤2"&& comboBox1.Text != "步骤3"&& comboBox1.Text != "步骤4"&& comboBox1.Text != "步骤5")
            {
                dt.Columns.Add(comboBox1.Text);
            }
        }

        //string stp1 = need_change_rows["step1"].ToString();
        //string stp1 = need_change_rows["step1"].ToString();
    
            
           
        

        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "步骤1";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                string bh = dgv1.Rows[i].Cells["nearNo"].Value.ToString();
                string sj = dgv1.Rows[i].Cells["TestTime"].Value.ToString();
                if (sj==null)
                {
                    sj = DateTime.Now.ToString();
                }
                string bz1 = dgv1.Rows[i].Cells[10].Value.ToString();
                if (bz1==null)
                {
                    bz1 = "";
                }
                string bz2 = dgv1.Rows[i].Cells[11].Value.ToString();
                if (bz2 == null)
                {
                    bz2 = "";
                }
                string bz3 = dgv1.Rows[i].Cells[12].Value.ToString();
                if (bz3 == null)
                {
                    bz3 = "";
                }
                string bz4 = dgv1.Rows[i].Cells[13].Value.ToString();
                if (bz4 == null)
                {
                    bz4 = "";
                }
                string bz5 = dgv1.Rows[i].Cells[14].Value.ToString();
                if (bz5 == null)
                {
                    bz5 = "";
                }
                string stp = string.Format(bz1 + '/' + bz2 + '/' + bz3 + '/' + bz4 + '/' + bz5);

                //string bz1 = dgv1.Rows[i].Cells["step1"].Value.ToString();
                //string bz2 = dgv1.Rows[i].Cells["step2"].Value.ToString();
                //string bz3 = dgv1.Rows[i].Cells["step3"].Value.ToString();
                //string bz4 = dgv1.Rows[i].Cells["step4"].Value.ToString();
                //string bz5 = dgv1.Rows[i].Cells["step5"].Value.ToString();
                string sf = dgv1.Rows[i].Cells["OkOrNg"].Value.ToString();
                string ljh = lble.Text;
                Maticsoft.BLL.test use = new Maticsoft.BLL.test();
                Maticsoft.Model.test us = new test()
                {
                    measureb = bh,
                    time = Convert.ToDateTime(sj),
                    step1 = stp,
                    //step2 = bz2,
                    //step3 = bz3,
                    //step4 = bz4,
                    //step5 = bz5,
                    OKorNG = sf,
                    PN = ljh,
                };
                use.Add(us);
            }
            MessageBox.Show("记录以保存");
            Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
            string aa = string.Format("PN = '{0}'", lble.Text);
            DataSet ds = usec.GetList(aa);
            string stp1 = ds.Tables[0].Rows[1][4].ToString();
            string[] sp = stp1.Split(new char[] { '/' });
            //string sf1 = sp[0];
            //dgv1.Rows[0].Cells[1].Value = ds.Tables[0].Rows[0][1].ToString();
            DataTable db = dgv1.DataSource as DataTable;
            //DataColumn dc = new DataColumn();
            //db.Columns.Add(dc);
            db.Columns.Add("步骤1"); 


           //string sf1 = sp[0];
            //string sg = sp[1];
            //DataSet ds = usec.GetAllList();
            dgv1.DataSource = ds.Tables[0];
        }
        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgv1.Columns["OkOrNg"].Frozen = true;

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
           
            //dgv1.Rows.Clear();
            //Maticsoft.BLL.test usec = new Maticsoft.BLL.test();
            //string aa = string.Format("PN = '{0}''", lble.Text);
            //DataSet ds = usec.GetList(aa);
            //// DataSet ds = usec.GetAllList();
            //dgv1.DataSource = ds.Tables[0];


        }
    }
}
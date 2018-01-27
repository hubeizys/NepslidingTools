using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using AnyCAD.Platform;

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

        private void StepTestFrom_Load(object sender, EventArgs e)
        {
            global.CurActive = "steptest";
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            this.Size = ScreenArea.Size;
            Location = (Point)new Size(0, 0);
            this.TopMost = true;
            this.Activate();
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("nearNo", typeof(string));//添加列
            dt.Columns.Add("TestTime", typeof(DateTime));
            dt.Columns.Add("OkOrNg", typeof(String));
            dt.Columns.Add("step1", typeof(String));
            dt.Columns.Add("step2", typeof(String));
            dt.Columns.Add("step3", typeof(String));
            dt.Columns.Add("step4", typeof(String));
            dt.Columns.Add("step5", typeof(String));
            dt.Rows.Add(new object[] { "2017113212200101", DateTime.Now, "OK", "0.1", "0", "1", "0.12", "-0.1" });//添加行
            dt.Rows.Add(new object[] { "2017113212200102", DateTime.Now, "NG", "-0.2", "0", "0.1", "0", "0" });
            dt.Rows.Add(new object[] { "2017113212200103", DateTime.Now, "OK", "0.1", "-0.1", "0.2", "0", "0.1" });
            this.dataGridView1.DataSource = dt;
            if(StepTestFrom.theApplication == null)
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

        private void StepTestFrom_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine("StepTestFrom_Scroll");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using Maticsoft.Model;
using NepslidingTools.testModel;
using NepslidingTools.toolbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NepslidingTools
{
    public partial class MainFrom : Form
    {
        string name = "main";
        public MainFrom()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pb_starttest_Click(object sender, EventArgs e)
        {
            DevSt devst = new DevSt();
            devst.ShowDialog();
        }

        private void pb_query_Click(object sender, EventArgs e)
        {
            QueryFrom qf = new QueryFrom();
            qf.ShowDialog();
        }

        private void pb_dom_Click(object sender, EventArgs e)
        {
            BomFrom bf = new BomFrom();
            bf.ShowDialog();
        }

        private void pb_users_Click(object sender, EventArgs e)
        {
            UserManForm umf = new UserManForm();
            umf.ShowDialog();
        }

        private void pb_device_Click(object sender, EventArgs e)
        {
            Devsimport di = new Devsimport();
            di.ShowDialog();
        }

        private void pb_save_Click(object sender, EventArgs e)
        {
            SavaAllFrom saf = new SavaAllFrom();
            saf.ShowDialog();
        }

        private void MainFrom_Deactivate(object sender, EventArgs e)
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

        private void MainFrom_Load(object sender, EventArgs e)
        {
            //Maticsoft.BLL.test a = new Maticsoft.BLL.test();
            //MessageBox.Show(Convert.ToString(a.GetList(" sadsa = '1 ' ")));


            //Maticsoft.Model.test aaa = new test()
            //{
            //    measureb = "aa",

            //};
            //a.Add(aaa);
            //a.Update(aaa);
        }
    }
}

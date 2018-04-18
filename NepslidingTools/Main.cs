using NepslidingTools.fz;
using NepslidingTools.testModel;
using NepslidingTools.toolbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NepslidingTools
{
    public partial class Main : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        string name = "main";
        public Main()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }

        private void command1_Executed(object sender, EventArgs e)
        {
            MessageBox.Show("asdasdasd");
        }


        /// <summary>
        /// 导入设备界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DevInput_mti_Click(object sender, EventArgs e)
        {
            Devsimport di = new Devsimport();
            di.ShowDialog();
        }

        /// <summary>
        /// 展示开始测量界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            DevSt devst = new DevSt();
            devst.ShowDialog();
        }

        /// <summary>
        /// 展示查询界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void query_mti_Click(object sender, EventArgs e)
        {
            QueryFrom qf = new QueryFrom();
            qf.ShowDialog();
        }

        /// <summary>
        /// 展示用户管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userman_mti_Click(object sender, EventArgs e)
        {
            UserManForm umf = new UserManForm();
            umf.ShowDialog();
        }

        private void bom_mti_Click(object sender, EventArgs e)
        {
            BomFrom bf = new BomFrom();
            bf.ShowDialog();
        }

        private void cj_mti_Click(object sender, EventArgs e)
        {
            SavaAllFrom saf = new SavaAllFrom();
            saf.ShowDialog();
        }

        private void step_mti_Click(object sender, EventArgs e)
        {
            TestBZFrom tbz = new TestBZFrom();
            tbz.ShowDialog();
        }

        private void dev_mti_Click(object sender, EventArgs e)
        {
            //Devices dvs = new Devices();
            //dvs.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            this.Size = ScreenArea.Size;
            Location = (Point)new Size(0, 0);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            // global.CurActive = "name";
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void Main_Deactivate(object sender, EventArgs e)
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

        private void mti_exit_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
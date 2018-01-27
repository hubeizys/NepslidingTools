using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.testModel
{
    public partial class TestBZFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "TestBZFrom";
        public TestBZFrom()
        {
            InitializeComponent();
        }

        private void TestBZFrom_Load(object sender, EventArgs e)
        {
            global.CurActive = "TestBZFrom";
            Console.WriteLine("��ǰ���������: " + this.name);
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;
            Location = (Point)new Size(0, 0);
            this.TopMost = true;
            this.Activate();

            DataTable dt = new DataTable();//������
            dt.Columns.Add("step", typeof(int));//�����
            dt.Columns.Add("tool", typeof(String));
            dt.Columns.Add("testlocal", typeof(String));
            dt.Columns.Add("bzz", typeof(double));//�����
            dt.Columns.Add("sgc", typeof(double));
            dt.Columns.Add("xgc", typeof(double));
            dt.Rows.Add(new object[] { 1, "����001", "��λ1" , 10, 0.12, 0.123});//�����
            dt.Rows.Add(new object[] { 2, "����011", "��λ12", 10, 0.0, 1.4 });
            dt.Rows.Add(new object[] { 3, "����301", "��λ92", 10, 2.6, 6.23 });
            this.dataGridView1.DataSource = dt;
        }

        private void send_bt_Click(object sender, EventArgs e)
        {
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
    }
}
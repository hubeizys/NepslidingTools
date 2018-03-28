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
    public partial class QueryFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "QueryFrom";
        public QueryFrom()
        {
            InitializeComponent();
        }

        private void QueryFrom_Load(object sender, EventArgs e)
        {
            textBox_ljhao.Text = Program.gdvid;
            global.CurActive = "QueryFrom";
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;

            this.TopMost = true;
            this.Activate();

            DataTable dt = new DataTable();                                     //������
            dt.Columns.Add("bomNo", typeof(Int32));                             //�����
            dt.Columns.Add("TestNo", typeof(Int32));
            dt.Columns.Add("TestLoc", typeof(String));
            dt.Columns.Add("TestTime", typeof(DateTime));
            dt.Columns.Add("step1", typeof(string));
            dt.Columns.Add("step2", typeof(string));
            dt.Columns.Add("step3", typeof(string));
            dt.Columns.Add("result", typeof(string));
            dt.Rows.Add(new object[] { 10001, 2123120, "��λ1", DateTime.Now,"ƫ��1mm","ƫ��-2mm","��ƫ��" ,"OK"});//�����
            dt.Rows.Add(new object[] { 10002, 2321115, "��λ1", DateTime.Now, "ƫ��101mm", "ƫ��10mm", "ƫ��1mm", "NG"});
            dt.Rows.Add(new object[] { 10003, 3011111, "��λ1", DateTime.Now, "ƫ��1mm", "ƫ��1mm", "��ƫ��", "OK"});
            dt.Rows.Add(new object[] { 10004, 3421112 , "��λ2", DateTime.Now, "ƫ��1mm", "ƫ��1mm", "ƫ��-134mm", "NG"});
            query_gc.DataSource = dt;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Program.txtbh = textBox_ljhao.Text;
             StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            daochu dc = new daochu();
            dc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void query_bt_Click(object sender, EventArgs e)
        {

        }

        private void QueryFrom_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("��ǰ���������: " + this.name);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void QueryFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }
    }
}
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
    public partial class DevSt : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "DevSt";
        public DevSt()
        {
            InitializeComponent();
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void stat_deng_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��ɫ����ǰ���������� ��ɫ����ǰû��������");
        }

        private void test_bt_Click(object sender, EventArgs e)
        {
            Program.txtbh= textBoxX1.Text;
            if (textBoxX1.Text=="")
            {
                MessageBox.Show("�����������");
                return;
            }
            StepTestFrom stf = new StepTestFrom();
            stf.ShowDialog();
            
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DevSt_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("��ǰ���������: " + this.name);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void DevSt_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }

        private void DevSt_Load(object sender, EventArgs e)
        {
            //global.CurActive = "DevSt";
            //this.TopMost = true;
            //this.Activate();
        }
    }
}
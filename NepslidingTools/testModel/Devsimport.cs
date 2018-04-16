using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO.Ports;

namespace NepslidingTools.testModel
{
    public partial class Devsimport : DevComponents.DotNetBar.Metro.MetroForm
    {
        private string device_type = "ruler";
        public Devsimport()
        {
            InitializeComponent();
        }

        private void importdev_st_FinishClick(object sender, CancelEventArgs e)
        {
            MessageBox.Show("��ϲ���趨���");
            this.Close();
        }

        private void Devsimport_Load(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex==0)
            {
               
            }
            if (radioGroup1.SelectedIndex == 1)
            {

            }
            if (radioGroup1.SelectedIndex == 2)
            {
                string[] ArryPort = SerialPort.GetPortNames();

                listBox1.Items.Clear();

                for (int i = 0; i < ArryPort.Length; i++)

                    listBox1.Items.Add(ArryPort[i]);

                listBox1.SelectedIndex = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {

            }
            if (radioGroup1.SelectedIndex == 1)
            {

            }
            if (radioGroup1.SelectedIndex == 2)
            {
                string[] ArryPort = SerialPort.GetPortNames();

                listBox1.Items.Clear();

                for (int i = 0; i < ArryPort.Length; i++)

                    listBox1.Items.Add(ArryPort[i]);

                listBox1.Text = ArryPort.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string LB =listBox1.SelectedItem.ToString();
            Program.DK = LB;
        }

        private void importdev_st_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            //MessageBox.Show(e.Page.Text);

            if ("ѡ��Ӳ������" == e.Page.Text)
            {
                // �����Ͷ�����
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    // ɨ��ǹ
                    importdev_st.SelectedPageIndex = 0;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    // ������ӡ��
            
                    importdev_st.SelectedPageIndex = 1;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 2)
                {
                    // ����
                    MessageBox.Show("���ڼ���Ӳ��------- ����");
                    listBox1.Items.Clear();
                    foreach (string port in SerPort.CurPorts())
                    {
                        listBox1.Items.Add(port);
                    }

                    // ���û�з��� �ؼ��б�� ������һ��
                    if (SerPort.CurPorts().Length <= 0)
                    {
                        //this.importdev_st.SelectedPageIndex = 0;
                        MessageBox.Show("û�з���Ӳ��");
                        e.Handled = true;
                        return;
                    }
                }

            }

            if ("��ѡ���豸" == e.Page.Text)
            {
                //MessageBox.Show(SerPort.CurPorts();
                MessageBox.Show(listBox1.SelectedValue + "  " + listBox1.SelectedItem);
            }

            if ("�ȴ�com�Ĳ�������" == e.Page.Text)
            {

            }
        }

        private void groupBox2_CursorChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ppppp");
        }
    }
}
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
            MessageBox.Show("恭喜您设定完毕");
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

            if ("选择硬件类型" == e.Page.Text)
            {
                // 吧类型定下来
                if (this.radioGroup1.SelectedIndex == 0)
                {
                    // 扫描枪
                    importdev_st.SelectedPageIndex = 0;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    // 热敏打印机
            
                    importdev_st.SelectedPageIndex = 1;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 2)
                {
                    // 卡尺
                    MessageBox.Show("正在加载硬件------- 卡尺");
                    listBox1.Items.Clear();
                    foreach (string port in SerPort.CurPorts())
                    {
                        listBox1.Items.Add(port);
                    }

                    // 如果没有发现 控件列表就 继续这一步
                    if (SerPort.CurPorts().Length <= 0)
                    {
                        //this.importdev_st.SelectedPageIndex = 0;
                        MessageBox.Show("没有发现硬件");
                        e.Handled = true;
                        return;
                    }
                }

            }

            if ("请选择设备" == e.Page.Text)
            {
                //MessageBox.Show(SerPort.CurPorts();
                MessageBox.Show(listBox1.SelectedValue + "  " + listBox1.SelectedItem);
            }

            if ("等待com的测试数据" == e.Page.Text)
            {

            }
        }

        private void groupBox2_CursorChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ppppp");
        }
    }
}
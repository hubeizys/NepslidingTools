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
        private SerPort sp_obj = new SerPort();
        private string device_type = "ruler";

        int type = 1;

        // 当前测试串口名
        private string cur_work_portname = "";
        public Devsimport()
        {
            InitializeComponent();
        }

        private void importdev_st_FinishClick(object sender, CancelEventArgs e)
        {
            // MessageBox.Show("恭喜您设定完毕");
            //MessageBox.Show(string.Format("您的机器id是 {0}", global.MachineID));
            //MessageBox.Show(string.Format("您的设备昵称是 {0}", textBoxX2.Text));

            string gz_name = textBoxX2.Text;
            MessageBox.Show(string.Format("当前选择的串口是 == {0} == ", cur_work_portname));

            Maticsoft.BLL.port tempport_bll = new Maticsoft.BLL.port();

            string cur_macnum = global.MachineID;
            List<Maticsoft.Model.port> port_objs = tempport_bll.GetModelList(string.Format(" mac = '{0}' and portname= '{1}' ", cur_macnum, cur_work_portname));


            // 先找是不是有
            if (port_objs.Count > 0)
            {
                // 如果存在的话 就先提醒一下。 用户点确认之后 覆盖以前的com
                DialogResult ret = MessageBox.Show("发现已经存在com的记录", "是否使用这个名字", MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                {
                    // 覆盖掉
                    Maticsoft.Model.port temp_port = port_objs[0];
                    temp_port.manufacturer = gz_name;
                    tempport_bll.Update(temp_port);
                    MessageBox.Show("以更新,工具已经可以使用");
                }
            }
            else
            {
                // 不存在就直接添加
                Maticsoft.Model.port tmp_portobj = new Maticsoft.Model.port()
                {
                    mac = cur_macnum,
                    manufacturer = gz_name,
                    portname = cur_work_portname,
                    devicetype = type,
                    workid = cur_macnum + "号工作站"
                };
                tempport_bll.Add(tmp_portobj);
            }
            this.Close();
        }

        private void Devsimport_Load(object sender, EventArgs e)
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
            string LB = listBox1.SelectedItem.ToString();
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
                    this.type = 3;
                    // 扫描枪
                    importdev_st.SelectedPageIndex = 2;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    // 热敏打印机
                    this.type = 2;
                    importdev_st.SelectedPageIndex = 2;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 2)
                {
                    this.type = 1;
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
                else if (this.radioGroup1.SelectedIndex == 3)
                {                    // 卡尺
                    MessageBox.Show("正在加载硬件------- 高度尺");
                    this.type = 4;
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

            void doing_test(string a)
            {
                //MessageBox.Show(" test data : " + a);
                textBoxX1.Invoke(new Action(() =>
                {
                    this.textBoxX1.Text = a;
                }));
            }

            if ("请选择设备" == e.Page.Text)
            {
                // 串口设置
                MessageBox.Show("SelectedValue + : " + listBox1.SelectedValue + "  item " + listBox1.SelectedItem);
                sp_obj.CheckPort();
                cur_work_portname = listBox1.SelectedItem.ToString();
                sp_obj.init_port(cur_work_portname);
                sp_obj.Processfunc = doing_test;
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
    class a
    {

    }
}
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

        // ��ǰ���Դ�����
        private string cur_work_portname = "";
        public Devsimport()
        {
            InitializeComponent();
        }

        private void importdev_st_FinishClick(object sender, CancelEventArgs e)
        {
            // MessageBox.Show("��ϲ���趨���");
            //MessageBox.Show(string.Format("���Ļ���id�� {0}", global.MachineID));
            //MessageBox.Show(string.Format("�����豸�ǳ��� {0}", textBoxX2.Text));

            string gz_name = textBoxX2.Text;
            MessageBox.Show(string.Format("��ǰѡ��Ĵ����� == {0} == ",cur_work_portname));

            Maticsoft.BLL.port tempport_bll = new Maticsoft.BLL.port();

            string cur_macnum = global.MachineID;
            List<Maticsoft.Model.port> port_objs = tempport_bll.GetModelList(string.Format(" mac = '{0}' and portname= '{1}' ", cur_macnum, cur_work_portname));


            // �����ǲ�����
            if (port_objs.Count >0 )
            {
                // ������ڵĻ� ��������һ�¡� �û���ȷ��֮�� ������ǰ��com
                DialogResult ret = MessageBox.Show("�����Ѿ�����com�ļ�¼","�Ƿ�ʹ���������" , MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                {
                    // ���ǵ�
                    Maticsoft.Model.port temp_port = port_objs[0];
                    temp_port.manufacturer = gz_name;
                    tempport_bll.Update(temp_port);
                    MessageBox.Show("�Ը���,�����Ѿ�����ʹ��");
                }
            }
            else
            {
                // �����ھ�ֱ�����
                Maticsoft.Model.port tmp_portobj = new Maticsoft.Model.port()
                {
                    mac = cur_macnum,
                    manufacturer = gz_name,
                    portname = cur_work_portname,
                    workid = cur_macnum + "�Ź���վ"
                };
                tempport_bll.Add(tmp_portobj);
            }
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
                    importdev_st.SelectedPageIndex = 2;
                    e.Handled = true;
                    return;
                }
                else if (this.radioGroup1.SelectedIndex == 1)
                {
                    // ������ӡ��
            
                    importdev_st.SelectedPageIndex = 2;
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

            void doing_test(string a)
            {
                //MessageBox.Show(" test data : " + a);
                textBoxX1.Invoke(new Action(()=> {
                    this.textBoxX1.Text = a;
                }));
            }

            if ("��ѡ���豸" == e.Page.Text)
            {
                // ��������
                MessageBox.Show("SelectedValue + : " + listBox1.SelectedValue + "  item " + listBox1.SelectedItem);
                sp_obj.CheckPort();
                cur_work_portname = listBox1.SelectedItem.ToString();
                sp_obj.init_port(cur_work_portname);
                sp_obj.Processfunc = doing_test;
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
    class a
    {

    }
}
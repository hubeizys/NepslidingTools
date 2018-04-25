using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NepslidingTools.toolbox
{
    public partial class AddComponent : Form
    {
        public AddComponent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_name.Text == "")
                {
                    MessageBox.Show("名称不可以为空");
                    return;
                }
                if (textBox_gongdan.Text == "")
                {
                    MessageBox.Show("工单号不可以为空");
                    return;
                }
                if (textBox_bianhao.Text == "")
                {
                    MessageBox.Show("生产编号不可以为空");
                    return;
                }
                if (textBox_cc.Text == "")
                {
                    MessageBox.Show("尺寸不可以为空");
                    return;
                }
                if (textBox_sm.Text == "")
                {
                    MessageBox.Show("数模不可以为空");
                    return;
                }
                if (textBox_picname.Text == "")
                {
                    MessageBox.Show("图片不可以为空");
                    return;
                }

                Maticsoft.BLL.component com_bll = new Maticsoft.BLL.component();
                Maticsoft.Model.component copm_mode = new Maticsoft.Model.component()
                {
                    name = textBox_name.Text,
                    jobnum = textBox_gongdan.Text,
                    ARef = textBox_bianhao.Text,
                    size = textBox_cc.Text,
                    sm = textBox_sm.Text,
                    photo = textBox_picname.Text,
                    remark = "管理"
                };
                if (com_bll.Add(copm_mode))
                {
                    MessageBox.Show("新建成功");
                }
                else
                {
                    MessageBox.Show("新建失败");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            } 
        }
    }
}

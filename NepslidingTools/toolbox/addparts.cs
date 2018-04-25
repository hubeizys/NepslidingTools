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
    public partial class addparts : Form
    {
        List<Maticsoft.Model.component> comp_list;
        public addparts()
        {
            InitializeComponent();
        }

        private void addparts_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.component component_bll = new Maticsoft.BLL.component();
            comp_list = component_bll.GetModelList("");
            if (comp_list.Count > 0)
            {
                List<string> com_strlist = comp_list.ConvertAll<string>(x => x.name);
                this.comboBox1.Items.AddRange(com_strlist.ToArray());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox_ljh.Text == "")
                {
                    MessageBox.Show("零件号为空");
                    return;
                }
                if (textBox_lxm.Text == "")
                {
                    MessageBox.Show("序列号为空");
                    return;
                }

                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择正确的类型");
                    return;
                }

                Maticsoft.BLL.parts part_bll = new Maticsoft.BLL.parts();
                Maticsoft.Model.parts parts_mode = new Maticsoft.Model.parts()
                {
                    Barcode = textBox_lxm.Text,
                    PN = textBox_ljh.Text,
                    remark = "管理号",
                    componentId = this.comp_list[comboBox1.SelectedIndex].componentId,
                };


                if (part_bll.Add(parts_mode))
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

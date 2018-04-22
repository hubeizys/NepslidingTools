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
    public partial class password : Form
    {
        public Maticsoft.Model.username user_mode; 
        public password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() != "" && (textBox1.Text == textBox2.Text))
            {
                Maticsoft.BLL.username user = new Maticsoft.BLL.username();
                if (user_mode != null)
                {
                    user_mode.password = textBox1.Text.Trim();
                }

                if (!user.Update(user_mode))
                {
                    MessageBox.Show("更新密码失败");
                }
                else { MessageBox.Show("更新密码成功"); }

            }
            else
            {
                MessageBox.Show("密码不合法");
            }
        }
    }
}

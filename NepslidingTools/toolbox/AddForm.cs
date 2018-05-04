using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Maticsoft.Model;

namespace NepslidingTools.toolbox
{
    public partial class AddForm : Form
    {
        string name = "AddForm";
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("当前激活界面是: " + this.name);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            global.CurActive = "AddForm";
            this.TopMost = true;
            this.Activate();
        }

        private void send_bt_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.parts use = new Maticsoft.BLL.parts();
            Maticsoft.Model.parts us = new parts()
            {
                
                PN = bom_no_tb.Text,
                //name = bomname_tb.Text,
                //jobnum = gdno_tb.Text,
                //ARef = scbh_tb.Text,
                //size= cicun_tb.Text,
                //sm= sandsm_tb.Text,
                Barcode= tm_tb.Text,
            };
            use.Add(us);
            MessageBox.Show("保存成功");
            foreach (Control Ctrol in this.Controls)
            {
                if (Ctrol is TextBox)
                {
                    Ctrol.Text = "";
                }
            }
            this.Close();
        }
    }
}
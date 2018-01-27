using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.toolbox
{
    public partial class AddForm : DevComponents.DotNetBar.Metro.MetroForm
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

        }
    }
}
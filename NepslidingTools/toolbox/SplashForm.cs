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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        public void setLabel(string text)
        {
            label1.Invoke(new Action(()=> {
                label1.Text = text;
            }));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            this.pictureBox1.Image = System.Drawing.Image.FromFile(cur_dict + "\\images\\configimg\\logo1.png");
        }
    }
}

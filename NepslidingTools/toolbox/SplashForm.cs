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
    }
}

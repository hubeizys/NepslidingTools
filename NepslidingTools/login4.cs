using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NepslidingTools
{
    public partial class login4 : Form
    {
        public login4()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("asdasd");
            System.Environment.Exit(0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            //MessageBox.Show("asdasd");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MainFrom mf = new MainFrom();
            mf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainFrom mf = new MainFrom();
            mf.Show();
        }
    }
}

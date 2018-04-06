using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NepslidingTools.testModel
{
    public partial class daochu : Form
    {
        public QueryFrom resa;
    
        public daochu()
        {
  
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {       
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float db = Program.hg / Program.qb;
            double dd=Math.Round(db, 2, MidpointRounding.AwayFromZero);
            txt_hgl.Text = (dd * 100 + "%").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resa.DataGridViewToExcel();
        }
    }
}

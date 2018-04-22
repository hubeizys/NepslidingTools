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
            //string zh = "";
            //string mm = "";
            Maticsoft.BLL.username user = new Maticsoft.BLL.username();
            string lab_name = txtzh.Text;
            string lab_pass_word = txtmm.Text;
            DataSet ds = user.GetList(string.Format( " user = '{0}' ", lab_name));
            DataTable dt = ds.Tables[0];
            string user_name = dt.Rows[0]["user"].ToString();
            string password = dt.Rows[0]["password"].ToString();
            global.power = dt.Rows[0]["power"].ToString();
            //MessageBox.Show(dt.Rows.Count+ " :count   " + user_name +  " : username " + password + " :password  " + lab_name + " :lab_name  " + lab_pass_word + " :mm  ");
            if (user_name == lab_name  && password == lab_pass_word)
            {
                MainFrom mf = new MainFrom();
                mf.Show();
            }
            else
            {
                //MessageBox.Show("  " + password + " ===  " + lab_pass_word);
                MessageBox.Show("密码或账号不正确");
                return;
            }
            /*
            //DataSet ds = use.GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                zh = ds.Tables[0].Rows[i]["user"].ToString();
                mm = ds.Tables[0].Rows[i]["password"].ToString();
                if (txtzh.Text == zh && txtmm.Text == mm)
                {
                    MainFrom mf = new MainFrom();
                    mf.Show();
                    break;
                }
            }
            if(txtzh.Text != zh || txtmm.Text != mm)
            {
                MessageBox.Show("密码或账号不正确");
                return;
            }
           */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string zh = "";
            string mm = "";
            string lab_name = txtzh.Text;
            string lab_pass_word = txtmm.Text;
            Maticsoft.BLL.username user = new Maticsoft.BLL.username();
         
            DataSet ds = user.GetList(string.Format(" user = '{0}' ", lab_name));
            DataTable dt = ds.Tables[0];
            string user_name = dt.Rows[0]["user"].ToString();
            string password = dt.Rows[0]["password"].ToString();
            global.power = dt.Rows[0]["power"].ToString();
            //MessageBox.Show("  " + password + " aa  ");

            //MessageBox.Show(dt.Rows.Count + " :count   " + user_name + " : username " + password + " :password  " + lab_name + " :lab_name  " + lab_pass_word + " :mm  ");
            if (user_name == lab_name && password == lab_pass_word)
            {
                MainFrom mf = new MainFrom();
                mf.Show();
            }
            else
            {
                //MessageBox.Show("  " + password + " ===  " + mm);
                MessageBox.Show("密码或账号不正确");
                return;
            }
            /*
            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            DataSet ds = use.GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                zh = ds.Tables[0].Rows[i]["user"].ToString();
                mm = ds.Tables[0].Rows[i]["password"].ToString();
            

            if (txtzh.Text == zh && txtmm.Text == mm)
            {
                MainFrom mf = new MainFrom();
                mf.Show();
                    break;
            }
            }
            if(txtzh.Text != zh || txtmm.Text != mm)
            {
                MessageBox.Show("密码或账号不正确");
                return;
            }
            */
            //MainFrom mf = new MainFrom();
            //mf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

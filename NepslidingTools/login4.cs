using Maticsoft.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NepslidingTools.toolbox;

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

        private void login4_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void login4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // MessageBox.Show("aaaaaaaaaa");
        }

        private void txtmm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtmm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
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
            }
        }

        private void login4_Load(object sender, EventArgs e)
        {
            // 设置logo
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            System.IO.FileStream fs = new System.IO.FileStream(cur_dict + "\\images\\configimg\\logo1.png", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            pictureBox1.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();

            //string cur_dict = System.IO.Directory.GetCurrentDirectory();
            //System.IO.FileStream fs2 = new System.IO.FileStream(, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            this.BackgroundImage = System.Drawing.Image.FromFile(cur_dict + "\\images\\configimg\\bg.png");
            // fs2.Close();


            Maticsoft.BLL.baseconfig config_bll = new Maticsoft.BLL.baseconfig();
            //config_bll.backup();
            int count = config_bll.GetRecordCount("");
            if (count <= 0)
            {
                MessageBox.Show("未激活");
                baseconfig bc_xin = new baseconfig
                {
                    companyName = "test",
                    expTime = DateTime.Now.AddMonths(7),
                    version = "0.1",
                    startTime = DateTime.Now,

                };
                if (config_bll.Add(bc_xin))
                {
                    MessageBox.Show("试用版激活成功");
                }
                else
                {
                    MessageBox.Show("激活失败");
                    System.Environment.Exit(0);
                }
                return;
            }
            else if (count == 1)
            {
                //MessageBox.Show("");
                List<baseconfig> bc_list = config_bll.GetModelList("");
                //MessageBox.Show("exptime ====== datetime " +  bc_list[0].expTime.ToString() +  DateTime.Now.ToString());
                global.startTime = (DateTime)bc_list[0].startTime;
                if (bc_list[0].expTime > DateTime.Now)
                {
                    MessageBox.Show("使用期限" + bc_list[0].expTime);
                    string boardid = GetSystemInfo.GetMotherBoardID();
                    string mac = GetSystemInfo.GetMacAddress();
                    if (boardid == "" || mac == "")
                    {
                        MessageBox.Show("主板或者mac地址信息缺失");
                        System.Environment.Exit(0);
                    }
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                    string source = boardid + "HelloWorld" + mac;
                    byte[] message;
                    message = Encoding.Default.GetBytes(source);

                    md5.ComputeHash(message);
                    //Console.WriteLine(Convert.ToBase64String(md5.Hash));
                    global.MachineID = Convert.ToBase64String(md5.Hash);
                    //MessageBox.Show(Convert.ToBase64String(md5.Hash));
                }
                else
                {
                    MessageBox.Show("已经过期了，无法继续使用");
                    MessageBox.Show("配置不正确, 请联系管理员");
                    System.Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("配置不正确, 请联系管理员");
                System.Environment.Exit(0);
                return;
            }

            Maticsoft.BLL.workstation ws = new Maticsoft.BLL.workstation();
            Maticsoft.Model.workstation ws_mode = ws.GetModel(global.MachineID);
            if (ws_mode != null)
            {
            }
            else
            {
                String str = Interaction.InputBox("请输入本机编号", "请输入编号", "", -1, -1);
                if (str == "")
                {
                    System.Environment.Exit(0);
                    return;
                }
                ws_mode = new workstation
                {
                    workid = global.MachineID,
                    remark = str,
                    workstationname = str
                };
                ws.Add(ws_mode);
            }
            global.workid = "工作站编号：" + ws_mode.workstationname; 
            label2.Text = "工作站编号：" + ws_mode.workstationname;
        }
    }
}

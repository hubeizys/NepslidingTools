using Maticsoft.Model;
using Microsoft.VisualBasic;
using NepslidingTools.testModel;
using NepslidingTools.toolbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NepslidingTools
{
    public partial class MainFrom : Form
    {
        string name = "main";
        public MainFrom()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pb_starttest_Click(object sender, EventArgs e)
        {
            DevSt devst = new DevSt();
            devst.ShowDialog();
        }

        private void pb_query_Click(object sender, EventArgs e)
        {
            if (global.power != "999")
            {
                MessageBox.Show("权限不够");
                return;
            }
            QueryFrom qf = new QueryFrom();
            qf.ShowDialog();
        }

        private void pb_dom_Click(object sender, EventArgs e)
        {
            if (global.power != "999")
            {
                MessageBox.Show("权限不够");
                return;
            }
            BomFrom2 bf = new BomFrom2();
            bf.ShowDialog();
        }

        private void pb_users_Click(object sender, EventArgs e)
        {
            if (global.power != "999")
            {
                MessageBox.Show("权限不够");
                return;
            }
            UserManForm umf = new UserManForm();
            umf.ShowDialog();
        }

        private void pb_device_Click(object sender, EventArgs e)
        {
            if (global.power != "999")
            {
                MessageBox.Show("权限不够");
                return;
            }
            Devsimport di = new Devsimport();
            di.ShowDialog();
        }

        private void pb_save_Click(object sender, EventArgs e)
        {
            if (global.power != "999")
            {
                MessageBox.Show("权限不够");
                return;
            }
            SavaAllFrom saf = new SavaAllFrom();
            saf.ShowDialog();
        }

        private void MainFrom_Deactivate(object sender, EventArgs e)
        {
            //if (global.CurActive == this.name)
            //{
            //    Console.WriteLine("当前激活界面是: " + this.name);
            //    Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //    this.Size = ScreenArea.Size;
            //    Location = (Point)new Size(0, 0);
            //    this.TopMost = true;
            //    this.Activate();
            //}
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            label1.Text = global.workid;
            //Maticsoft.BLL.test a = new Maticsoft.BLL.test();
            //MessageBox.Show(Convert.ToString(a.GetList(" sadsa = '1 ' ")));

            //Maticsoft.Model.test aaa = new test()
            //{
            //    measureb = "aa",

            //};
            //a.Add(aaa);
            //a.Update(aaa);

            // 设置logo
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            System.IO.FileStream fs = new System.IO.FileStream(cur_dict + "\\images\\configimg\\logo1.png", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            pictureBox1.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();

            this.BackgroundImage = System.Drawing.Image.FromFile(cur_dict + "\\images\\configimg\\bg.png");

        }

        //获取最近创建的文件名和创建时间
        //如果没有指定类型的文件，返回null
        static FileTimeInfo GetLatestFileTimeInfo(string dir, string ext)
        {
            List<FileTimeInfo> list = new List<FileTimeInfo>();
            DirectoryInfo d = new DirectoryInfo(dir);
            foreach (FileInfo fi in d.GetFiles())
            {
                if (fi.Extension.ToUpper() == ext.ToUpper())
                {
                    list.Add(new FileTimeInfo()
                    {
                        FileName = fi.FullName,
                        FileCreateTime = fi.CreationTime
                    });
                }
            }
            var qry = from x in list
                      orderby x.FileCreateTime
                      select x;
            return qry.LastOrDefault();
        }
        private void save_timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("OK sava");
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            // DirectoryInfo d_info = new DirectoryInfo(cur_dict + "\\backup");
            //使用 GetLatestFileTimeInfo
            //获取d:\test文件中，扩展名为.txt的最新文件
            FileTimeInfo fi = GetLatestFileTimeInfo(cur_dict + "\\backup", ".sql");
            if (fi != null)
            {
                Console.WriteLine("文件名：{0} 创建时间：{1}", fi.FileName, fi.FileCreateTime);
                if (fi.FileCreateTime.CompareTo(DateTime.Now.AddHours(-10)) <= 0)
                {
                    Console.WriteLine("需要备份了");
                    SavaAllFrom.SavaAll();
                }
                else
                {
                    Console.WriteLine("不需要备份");
                }
            }
            else
            {
                Console.WriteLine("文件夹中没有指定扩展名的文件!");
            }
        }
    }
    //自定义一个类
    public class FileTimeInfo
    {
        public string FileName;  //文件名
        public DateTime FileCreateTime; //创建时间
    }
}

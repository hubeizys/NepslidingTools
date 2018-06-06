using Maticsoft.Model;
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
                else {
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
            //Maticsoft.BLL.test a = new Maticsoft.BLL.test();
            //MessageBox.Show(Convert.ToString(a.GetList(" sadsa = '1 ' ")));

            //Maticsoft.Model.test aaa = new test()
            //{
            //    measureb = "aa",

            //};
            //a.Add(aaa);
            //a.Update(aaa);
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

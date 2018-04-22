using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.toolbox
{
    public partial class SavaAllFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SavaAllFrom()
        {
            InitializeComponent();
        }


        /// <summary>  
        /// 获取时间戳  13位
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }


        private void save_sql_bt_Click(object sender, EventArgs e)
        {
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo d_info = new DirectoryInfo(cur_dict+"\\backup");

            // MessageBox.Show(d_info.GetFiles().ToString());
            FileInfo[] arrFi = d_info.GetFiles("*.sql");
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
            int i = 0;
            foreach (var a in arrFi)
            {
                i++;
                Console.WriteLine(a.FullName);
                if (i > 10)
                {
                    System.IO.File.Delete(a.FullName);
                }
            }

            string dumptools = cur_dict + "\\tools\\mysqldump.exe";

            System.Diagnostics.Process exep = new System.Diagnostics.Process();
            exep.StartInfo.FileName = dumptools;
            exep.StartInfo.Arguments = string.Format( @" -h test.xtask.work -uroot  -plaozhuhenshuai GLLJ --result-file=backup\todmp{0}.sql", GetTimeStamp());
            exep.StartInfo.CreateNoWindow = true;
            exep.StartInfo.RedirectStandardInput = true;
            exep.StartInfo.RedirectStandardOutput = true;
            exep.StartInfo.RedirectStandardError = true;
            exep.StartInfo.UseShellExecute = false;
            exep.Start();
            //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
            // string str = string.Format(@"""{0}"" {1} {2}", cmdExe, cmdStr, "&exit");

            // exep.StandardInput.WriteLine(str);
            //exep.StandardInput.AutoFlush = true;
            string netmessage = exep.StandardError.ReadToEnd();

            exep.WaitForExit();
            Console.WriteLine(netmessage);
            // ThreadPool.QueueUserWorkItem(new WaitCallback(ExeThread), exep);

        }

        private void ExeThread(object obj)
        {
            Process cmd = obj as Process;
            cmd.Start();
            cmd.OutputDataReceived += new DataReceivedEventHandler(cmd_OutputDataReceived);
            cmd.BeginOutputReadLine();
            //  
            Application.DoEvents();
            cmd.WaitForExit();
            if (cmd.ExitCode != 0)
            {
                ShowMessage(cmd.StandardOutput.ReadToEnd());
            }
            cmd.Close();
        }


        private delegate void ShowMessageHandler(string msg);
        private void ShowMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowMessageHandler(ShowMessage), new object[] { msg });
            }
            else
            {
                if (msg != null)
                {
                    //textBox1.AppendText(msg + "/r/n");
                    Console.WriteLine(msg + "/r/n");
                }
            }
        }
        void cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // ShowMessage(e.Data);
            Console.WriteLine(e.Data);
        }

        private void SavaAllFrom_Load(object sender, EventArgs e)
        {
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo d_info = new DirectoryInfo(cur_dict + "\\backup");

            // MessageBox.Show(d_info.GetFiles().ToString());
            FileInfo[] arrFi = d_info.GetFiles("*.sql");
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
            int i = 0;
            this.dataGridView1.Rows.Clear();
            foreach (var a in arrFi)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Cells[0].Value = Path.GetFileName(a.FullName);
                this.dataGridView1.Rows[i].Cells[1].Value = a.CreationTime;
                
                i++;
                Console.WriteLine("aaaaa " + i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string file_name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo d_info = new DirectoryInfo(cur_dict + "\\backup\\" + file_name);

            FileInfo file = new FileInfo(cur_dict+"\\backup\\" + file_name);  //filename是sql脚本文件路径。
            string sql = file.OpenText().ReadToEnd();
            Maticsoft.BLL.baseconfig bf = new Maticsoft.BLL.baseconfig();
            bf.backup(sql);
            MessageBox.Show(sql);

            return;
            string dumptools = cur_dict + "\\tools\\mysqldump.exe";

            string strInput = dumptools + string.Format(@" -h test.xtask.work -uroot  -plaozhuhenshuai GLLJ < backup\" + d_info.FullName);
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = false;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            //p.StandardInput.WriteLine(strInput + "&exit");
            p.StandardInput.WriteLine(strInput + "&exit");
            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardError.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            
            Console.WriteLine(strOuput);

            //Console.ReadKey();
            return;
            //MessageBox.Show(e.RowIndex.ToString());


            System.Diagnostics.Process exep = new System.Diagnostics.Process();
            exep.StartInfo.FileName = dumptools;
            exep.StartInfo.Arguments = string.Format(@" -h test.xtask.work -uroot  -plaozhuhenshuai GLLJ < backup\" + d_info.FullName);
            exep.StartInfo.CreateNoWindow = true;
            //exep.StartInfo.RedirectStandardInput = true;
            //exep.StartInfo.RedirectStandardOutput = true;
            //exep.StartInfo.RedirectStandardError = true;
            exep.StartInfo.UseShellExecute = true;
            exep.Start();
            //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
            // string str = string.Format(@"""{0}"" {1} {2}", cmdExe, cmdStr, "&exit");

            // exep.StandardInput.WriteLine(str);
            //exep.StandardInput.AutoFlush = true;
            //string netmessage = exep.StandardError.ReadToEnd();

            exep.WaitForExit();
            //Console.WriteLine(netmessage);
        }
    }
}
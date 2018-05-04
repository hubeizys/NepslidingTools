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
    public partial class SavaAllFrom : Form
    {

        private int index = 0;
        public SavaAllFrom()
        {
            InitializeComponent();
        }


        /// <summary>  
        /// ��ȡʱ���  13λ
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
            //������ó���·�����пո�ʱ��cmd����ִ��ʧ�ܣ�������˫���������� ���������������ű�ʾһ�����ţ�ת�壩
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

            string file_name = dataGridView1.Rows[this.index].Cells[0].Value.ToString();
            string cur_dict = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo d_info = new DirectoryInfo(cur_dict + "\\backup\\" + file_name);

            FileInfo file = new FileInfo(cur_dict + "\\backup\\" + file_name);  //filename��sql�ű��ļ�·����
            string sql = file.OpenText().ReadToEnd();
            Maticsoft.BLL.baseconfig bf = new Maticsoft.BLL.baseconfig();
            bf.backup(sql);
            MessageBox.Show(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.index = e.RowIndex;


            return;
           
        }
    }
}
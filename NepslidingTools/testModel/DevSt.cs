using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.testModel
{
    public partial class DevSt : Form
    {
        string name = "DevSt";
        public DevSt()
        {
            InitializeComponent();
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {

        }

        private void stat_deng_Click(object sender, EventArgs e)
        {
            MessageBox.Show("绿色代表当前连接正常， 红色代表当前没连接正常");
        }

        private void test_bt_Click(object sender, EventArgs e)
        {
            Program.txtbh= textBoxX1.Text;
            if (textBoxX1.Text=="")
            {
                MessageBox.Show("请输入零件号");
                return;
            }
            StepTestFrom stf = new StepTestFrom();
            stf.ShowDialog();
            
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DevSt_Deactivate(object sender, EventArgs e)
        {
            if (global.CurActive == this.name)
            {
                Console.WriteLine("当前激活界面是: " + this.name);
                this.TopMost = true;
                this.Activate();
            }
        }

        private void DevSt_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }

        private void get_lingjian()
        {
            Task query_task = new Task(()=> {
                Maticsoft.BLL.parts parts_list = new Maticsoft.BLL.parts();
                List< Maticsoft.Model.parts> pa_list = parts_list.GetModelList(" 1=1 GROUP BY pn");
                var datasou = new AutoCompleteStringCollection();
                List<string> pn_list = pa_list.ConvertAll<string>((temp_obj) => { return temp_obj.PN; });
                datasou.AddRange(pn_list.ToArray());
                textBoxX1.Invoke(new Action(()=> {
                    textBoxX1.AutoCompleteCustomSource = datasou;
                    textBoxX1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }));
            });
            query_task.Start();

        }

        private void DevSt_Load(object sender, EventArgs e)
        {
            this.get_lingjian();
            //where 1 = 1 GROUP BY pn LIMIT 10
            //global.CurActive = "DevSt";
            //this.TopMost = true;
            //this.Activate();
            this.last_flp.Controls.Clear();
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            List<Maticsoft.Model.test> test_lists = test_bll.GetModelList(" 1=1 GROUP BY pn LIMIT 10");
            foreach(var test_obj in test_lists)
            {
                Button a = new Button();
                a.Text = test_obj.PN;
                a.Click += new System.EventHandler(this.button_Click);
                this.last_flp.Controls.Add(a);
            }
        }

        private void button_Click2(object sender, EventArgs e)
        {   
            Program.txtbh = (sender as Button) .Text;
            StepTestFrom stf = new StepTestFrom();
            stf.ShowDialog();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string num_text = (sender as Button).Text;
            if(num_text == textBoxX1.Text)
            {
                Program.txtbh = num_text;
                StepTestFrom stf = new StepTestFrom();
                stf.ShowDialog();
                return;
            }
            // MessageBox.Show((sender as Button).Text );
            textBoxX1.Invoke(new Action(()=> {
                textBoxX1.Text = (sender as Button).Text;
            }));
        }
    }
}
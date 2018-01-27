using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NepslidingTools.toolbox
{
    public partial class UserManForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public UserManForm()
        {
            InitializeComponent();
        }

        private void UserManForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//������
            dt.Columns.Add("username", typeof(String));//�����
            dt.Columns.Add("Manager", typeof(String));
            dt.Columns.Add("addTime", typeof(DateTime));
            dt.Columns.Add("power", typeof(String));
            dt.Rows.Add(new object[] { "admin", "admin", DateTime.Now ,"����Ա"});//�����
            dt.Rows.Add(new object[] {  "����", "zzzs", DateTime.Now, "��ͨ�˻�"});
            dt.Rows.Add(new object[] {  "����", "www", DateTime.Now, "��ͨ�˻�" });
            this.users_gc.DataSource = dt;
        }

        private void query_bt_Click(object sender, EventArgs e)
        {

        }
    }
}
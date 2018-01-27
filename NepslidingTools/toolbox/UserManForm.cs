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
            DataTable dt = new DataTable();//创建表
            dt.Columns.Add("username", typeof(String));//添加列
            dt.Columns.Add("Manager", typeof(String));
            dt.Columns.Add("addTime", typeof(DateTime));
            dt.Columns.Add("power", typeof(String));
            dt.Rows.Add(new object[] { "admin", "admin", DateTime.Now ,"管理员"});//添加行
            dt.Rows.Add(new object[] {  "李四", "zzzs", DateTime.Now, "普通账户"});
            dt.Rows.Add(new object[] {  "王五", "www", DateTime.Now, "普通账户" });
            this.users_gc.DataSource = dt;
        }

        private void query_bt_Click(object sender, EventArgs e)
        {

        }
    }
}
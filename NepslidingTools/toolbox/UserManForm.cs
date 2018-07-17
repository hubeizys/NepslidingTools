using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Maticsoft.Model;

namespace NepslidingTools.toolbox
{
    public partial class UserManForm : Form
    {
        public UserManForm()
        {
            InitializeComponent();
        }

        private void UserManForm_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            DataSet ds = use.GetAllList();
            users_gc.DataSource = ds.Tables[0];
            //ds.Tables.Add();
            //DataTable dt = new DataTable();//创建表
            //dt.Columns.Add("username", typeof(String));//添加列
            //dt.Columns.Add("Manager", typeof(String));
            //dt.Columns.Add("addTime", typeof(DateTime));
            //dt.Columns.Add("power", typeof(String));
            //dt.Rows.Add(new object[] { "admin", "admin", DateTime.Now ,"管理员"});//添加行
            //dt.Rows.Add(new object[] {  "李四", "zzzs", DateTime.Now, "普通账户"});
            //dt.Rows.Add(new object[] {  "王五", "www", DateTime.Now, "普通账户" });
            // this.users_gc.DataSource = dt;

        }

        private void query_bt_Click(object sender, EventArgs e)
        {
            if (username_tb.Text != "" && time_dtp.Text == "")
            {
                Maticsoft.BLL.username use = new Maticsoft.BLL.username();
                string aa = string.Format("user = '{0}'", username_tb.Text);
                DataSet ds = use.GetList(aa);
                users_gc.DataSource = ds.Tables[0];
            }
            if (username_tb.Text==""&&time_dtp.Text!="")
            {
                Maticsoft.BLL.username use = new Maticsoft.BLL.username();
                string aa = string.Format("addtime = '{0}'", time_dtp.Text);
                DataSet ds = use.GetList(aa);
                users_gc.DataSource = ds.Tables[0];
            }
            if (username_tb.Text != "" && time_dtp.Text != "")
            {
                Maticsoft.BLL.username use = new Maticsoft.BLL.username();
                string aa = string.Format("addtime = '{0}'and user='{1}'", time_dtp.Text,username_tb.Text);
                DataSet ds = use.GetList(aa);
                users_gc.DataSource = ds.Tables[0];
            }
            if (username_tb.Text == "" && time_dtp.Text == "")
            {
                Maticsoft.BLL.username use = new Maticsoft.BLL.username();
                DataSet ds = use.GetAllList();
                users_gc.DataSource = ds.Tables[0];
            }
            }

        private void add_bt_Click(object sender, EventArgs e)
        {
            ADDzhForm zh = new ADDzhForm();
            zh.ShowDialog();
        }
        List<int> del_list = new List<int>();
        private void del_bt_Click(object sender, EventArgs e)
        {
            int[] aa = manuser.GetSelectedRows();
            foreach (int testa in aa)
            {
                DataRow drt = manuser.GetDataRow(testa);
                string id = drt["ID"].ToString();
                del_list.Add(Convert.ToInt32(id));
                manuser.DeleteRow(testa);
            }

            // MessageBox.Show(aa.Length.ToString());
            return;
            DataRow a = manuser.GetDataRow(manuser.FocusedRowHandle);

            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            use.Delete(Convert.ToInt32(a["id"]));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("删除成功");
            Maticsoft.BLL.username usec = new Maticsoft.BLL.username();
            DataSet ds = usec.GetAllList();
            users_gc.DataSource = ds.Tables[0];


            //DataSet ds = use.GetList("   ");
            //DataTable dt = ds.Tables[0];


            //MessageBox.Show(ds.Tables.Count.ToString());
            //DataTable dt = ds.Tables[0];
            //MessageBox.Show(dt.Rows.Count.ToString());
        }
        
        private void edit_bt_Click(object sender, EventArgs e)
        {
            DataRow drt =  manuser.GetDataRow(manuser.FocusedRowHandle);
            MessageBox.Show(drt["password"].ToString() + "  "+ drt["ID"].ToString());
            Maticsoft.BLL.username user = new Maticsoft.BLL.username();
            Maticsoft.Model.username user_mode =  user.GetModel( Convert.ToInt32( drt["ID"]));
            password pass_obj = new password();
            pass_obj.user_mode = user_mode;
            pass_obj.Show();
            return;
            for (int i = 0; i < manuser.RowCount; i++)
            {
                string ua = manuser.GetRowCellValue(i, "user").ToString();
                string pw = manuser.GetRowCellValue(i,"password").ToString();
                string po = manuser.GetRowCellValue(i,"power").ToString();
                int id = Convert.ToInt32(  manuser.GetRowCellValue(i, "ID"));
                DateTime tm =Convert.ToDateTime( manuser.GetRowCellValue(i, "addTime"));
                Maticsoft.BLL.username use = new Maticsoft.BLL.username();
                Maticsoft.Model.username us = new username()
                {
                    ID = id,
                    user = ua,
                    addtime =tm ,
                    password =pw ,
                    power = po,

                };
                use.Update(us);                             
            }
            MessageBox.Show("修改成功");
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            DataSet ds = use.GetAllList();
            users_gc.DataSource = ds.Tables[0];
            del_list.Clear();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.username use = new Maticsoft.BLL.username();
            foreach (int del_index in del_list)
            {
                use.Delete(del_index);
            }

            DataSet ds = use.GetAllList();
            users_gc.DataSource = ds.Tables[0];
        }
        private void users_gc_Click(object sender, EventArgs e)
        {
            
        }
    }
}
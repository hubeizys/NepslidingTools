using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NepslidingTools.toolbox
{
    public partial class BomFrom2 : Form
    {
        int cur_step = 0;
        int cur_page_lenb = 20;
        int totle_num = 0;

        int lj_cur_step = 0;
        int lj_cur_page_lenb = 20;
        int lj_totle_num = 0;

        public BomFrom2()
        {
            InitializeComponent();
        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_main.SelectedIndex == 1)
            {
                MessageBox.Show("导入零件类型数据");
                this.init_dgv();
            }
        }

        private void init_ljjldgv()
        {
            #region 获得查询语句
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( PN like  %{0}%  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query);
            }

            if (this.textBox_type.Text != "")
            {
                where_str += string.Format(" and  {0}", textBox_type.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            DataSet ds = parts_bll.GetListByPage2(where_str, "", lj_cur_step, lj_cur_page_lenb);
            DataTable dt = ds.Tables[0];
            this.dgvljjl.DataSource = dt;
            #endregion
        }

        private void init_dgv()
        {
            #region 获得查询语句
            string where_str = " 1=1 ";
            if (this.textBox_query.Text != "")
            {
                // 通过零件的id或者零件的名字
                where_str += string.Format(" componentId like %{0}% or name like '%{1}%' ", this.textBox_query.Text, this.textBox_query);
            }
            Maticsoft.BLL.component com_bll = new Maticsoft.BLL.component();
            DataSet ds = com_bll.GetListByPage2(where_str, "", cur_step, cur_step + cur_page_lenb);
            DataTable dt = ds.Tables[0];
            this.dataGridView1.DataSource = dt;
            #endregion
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            this.init_dgv();
        }

        private void button_likequery_Click(object sender, EventArgs e)
        {

        }
    }
}

using NepslidingTools.testModel;
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
            if (tabControl_main.SelectedIndex == 0)
            {
                this.init_ljjldgv();
            }
            else if (tabControl_main.SelectedIndex == 1)
            {
                // MessageBox.Show("导入零件类型数据");
                this.init_dgv();
            }
        }

        private void init_ljjldgv()
        {
            #region 获得查询语句
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            DataSet ds = parts_bll.GetListByPage2(where_str, "", lj_cur_step, lj_cur_step + lj_cur_page_lenb);
            DataTable dt = ds.Tables[0];

            if (this.textBox_type.Text != "")
            {
                DataTable dtNew = dt.Clone();
                // where_str += string.Format(" and   {0}", textBox_type.Text);
                DataRow[] drArr = dt.Select(string.Format(" name like '%{0}%'", this.textBox_type.Text));
                for (int i = 0; i < drArr.Length; i++)
                {
                    dtNew.ImportRow(drArr[i]);
                }
                this.dgvljjl.DataSource = dtNew;
                return;
            }

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
                where_str += string.Format("  and ( componentId like '%{0}%' or name like '%{1}%') ", this.textBox_query.Text, this.textBox_query.Text);
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
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            lj_totle_num = parts_bll.GetRecordCount(where_str);

            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", 1, tot_page_index);
            this.label_tot.Text = page_info;
        }

        private void button_likequery_Click(object sender, EventArgs e)
        {
            init_ljjldgv();
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            totle_num =  parts_bll.GetRecordCount(where_str);

            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", 1, tot_page_index);
            this.label_baifen1.Text = page_info;
        }

        private void BomFrom2_Load(object sender, EventArgs e)
        {
            this.init_ljjldgv();
        }

        private void dgvljjl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            this.tabControl_main.SelectedIndex = 1;
            if (e.RowIndex >= 0 && e.RowIndex < dgvljjl.Rows.Count)
            {
                string id = dgvljjl.Rows[e.RowIndex].Cells["component"].Value.ToString();
                this.textBox_query.Text = id;
                string where_str = "";
                // 通过零件的id或者零件的名字
                where_str += string.Format("  componentId= '{0}' ", this.textBox_query.Text);

                Maticsoft.BLL.component com_bll = new Maticsoft.BLL.component();
                DataSet ds = com_bll.GetListByPage2(where_str, "", cur_step, cur_step + cur_page_lenb);
                DataTable dt = ds.Tables[0];
                this.dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("选中了无效的行");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // componentId
            TestBZFrom tb = new TestBZFrom();
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                tb.LjHao = dataGridView1.Rows[e.RowIndex].Cells["componentId"].Value.ToString();
                tb.Show();
            }
            else
            {
                MessageBox.Show("选中了无效的行");
            }
        }

        private void buttonjl_pre_Click(object sender, EventArgs e)
        {
            // 上一页
            if (cur_step >= cur_page_lenb)
            {
                cur_step -= cur_page_lenb;
            }
            else if (cur_step < cur_page_lenb)
            {
                cur_step = 0;
            }

            int cur_page_index = cur_step / this.cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", cur_page_index, tot_page_index);
            this.label_baifen1.Text = page_info;
            init_ljjldgv();
        }

        private void buttonjl_next_Click(object sender, EventArgs e)
        {
            if (cur_step + cur_page_lenb > this.totle_num)
            {
                return;
            }
            cur_step += cur_page_lenb;

            int cur_page_index = cur_step / this.cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", cur_page_index, tot_page_index);
            this.label_baifen1.Text = page_info;
            init_ljjldgv();
        }

        private void button_pre_Click(object sender, EventArgs e)
        {
            
            // 上一页
            if (lj_cur_step  >= lj_cur_page_lenb)
            {
                lj_cur_step -= lj_cur_page_lenb;
            }
            else if (lj_cur_step < lj_cur_page_lenb)
            {
                lj_cur_step = 0;
            }

            int cur_page_index = lj_cur_step / this.lj_cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.lj_cur_page_lenb + (this.totle_num % this.lj_cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", cur_page_index, tot_page_index);
            this.label_baifen1.Text = page_info;
            init_dgv();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            
            if (lj_cur_step + lj_cur_page_lenb > this.totle_num)
            {
                return;
            }
            lj_cur_step += lj_cur_page_lenb;

            int cur_page_index = lj_cur_step / this.lj_cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.lj_cur_page_lenb + (this.totle_num % this.lj_cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", cur_page_index, tot_page_index);
            this.label_baifen1.Text = page_info;
            init_dgv();
        }

        private void buttonlj_del_Click(object sender, EventArgs e)
        {
            // 获得选中行
            int index = this.dgvljjl.CurrentCell.RowIndex;
            if (index >=0 && index < this.dgvljjl.Rows.Count)
            {
                var id = this.dgvljjl.Rows[index].Cells["id"].Value;
                Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
                if (parts_bll.Delete(Convert.ToInt32(id)))
                {
                    MessageBox.Show("删除成功");
                }
                else { MessageBox.Show("未删除成功"); }
            }
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentCell.RowIndex;
            if (index >= 0 && index < this.dgvljjl.Rows.Count)
            {
                var id = this.dataGridView1.Rows[index].Cells["id"].Value;
                Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
                if (comp_bll.Delete(Convert.ToInt32(id)))
                {
                    MessageBox.Show("删除成功");
                }
                else {
                    MessageBox.Show("没有删除成功");
                }
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            AddComponent add_from = new AddComponent();
            add_from.Show();
        }

        private void buttolj_add_Click(object sender, EventArgs e)
        {
            addparts add_from = new addparts();
            add_from.Show();
        }
    }
}

using NepslidingTools.testModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        int totle_num2 = 0;


        int lj_cur_step = 0;
        int lj_cur_page_lenb = 20;
        int lj_totle_num = 0;


        int totle_page_num = 0;
        int cur_page_num = 0;

        int totle_page_num2 = 0;
        int cur_page_num2 = 0;

        public BomFrom2()
        {
            InitializeComponent();
        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_main.SelectedIndex == 0)
            {
                // MessageBox.Show("导入零件类型数据");
                this.init_dgv();
            }
            else if (tabControl_main.SelectedIndex == 1)
            {
                string where_str = " 1=1 ";
                if (this.textBoxljjl_query.Text != "")
                {
                    where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
                }
                if (this.textBox_type.Text != "")
                {
                    where_str += string.Format(" and componentId = {0} ", this.textBox_type.Text);
                }

                Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
                totle_num2 = parts_bll.GetRecordCount(where_str);

                if (this.totle_num2 % this.cur_page_lenb == 0)
                {
                    this.totle_page_num2 = this.totle_num2 / this.cur_page_lenb;
                }
                else
                {
                    this.totle_page_num2 = this.totle_num2 / this.cur_page_lenb + 1;
                }

                //int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
                string page_info = string.Format("{0}/{1}", 1, totle_page_num2);
                this.label_baifen1.Text = page_info;
                this.init_ljjldgv();
            }
        }

        private void init_ljjldgv()
        {
            this.del_list.Clear();
            #region 获得查询语句
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }

            if (this.textBox_type.Text != "")
            {
                where_str += string.Format(" and T.componentId = {0} ", this.textBox_type.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            DataSet ds = parts_bll.GetListByPage2(where_str, "", cur_page_lenb * cur_page_num2, cur_page_lenb * (1 + cur_page_num2));
            DataTable dt = ds.Tables[0];

            //if (this.textBox_type.Text != "")
            //{
            //    DataTable dtNew = dt.Clone();
            //    where_str += string.Format(" and   {0}", textBox_type.Text);
            //    DataRow[] drArr = dt.Select(string.Format(" componentId = {0}", this.textBox_type.Text));
            //    for (int i = 0; i < drArr.Length; i++)
            //    {
            //        dtNew.ImportRow(drArr[i]);
            //    }
            //    this.dgvljjl.DataSource = dtNew;
            //    return;
            //}

            this.dgvljjl.DataSource = dt;
            #endregion
        }

        private void init_dgv()
        {
            del_list_for_part.Clear();
            #region 获得查询语句
            string where_str = " 1=1 ";
            if (this.textBox_query.Text != "")
            {
                // 通过零件的id或者零件的名字
                where_str += string.Format("  and ( componentId like '%{0}%' or name like '%{1}%') ", this.textBox_query.Text, this.textBox_query.Text);
            }
            Maticsoft.BLL.component com_bll = new Maticsoft.BLL.component();
            DataSet ds = com_bll.GetListByPage2(where_str, "", cur_page_lenb * cur_page_num, cur_page_lenb * (1 + cur_page_num));
            DataTable dt = ds.Tables[0];
            this.dataGridView1.DataSource = dt;
            #endregion
        }

        private void requery()
        {
            string where_str = " 1=1 ";
            if (this.textBox_query.Text != "")
            {
                // 通过零件的id或者零件的名字
                where_str += string.Format("  and ( componentId like '%{0}%' or name like '%{1}%') ", this.textBox_query.Text, this.textBox_query.Text);
            }
            Maticsoft.BLL.component parts_bll = new Maticsoft.BLL.component();
            totle_num = parts_bll.GetRecordCount(where_str);

            if (this.totle_num % this.cur_page_lenb == 0)
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb;
            }
            else
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb + 1;
            }
            string page_info = string.Format("{0}/{1}", 1, totle_page_num);
            this.label_tot.Text = page_info;
            this.init_dgv();
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            requery();
        }

        private void requery2()
        {
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {

                where_str += string.Format(" and ( PN like  '%{0}%'  or Barcode like '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }
            if (this.textBox_type.Text != "")
            {
                where_str += string.Format(" and componentId = {0} ", this.textBox_type.Text);
            }

            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            totle_num2 = parts_bll.GetRecordCount(where_str);

            if (this.totle_num2 % this.cur_page_lenb == 0)
            {
                this.totle_page_num2 = this.totle_num2 / this.cur_page_lenb;
            }
            else
            {
                this.totle_page_num2 = this.totle_num2 / this.cur_page_lenb + 1;
            }

            //int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", 1, totle_page_num2);
            this.label_baifen1.Text = page_info;
            init_ljjldgv();
        }

        private void button_likequery_Click(object sender, EventArgs e)
        {
            cur_page_num2 = 0;
            requery2();
        }

        private void BomFrom2_Load(object sender, EventArgs e)
        {
            string where_str = " 1=1 ";
            if (this.textBoxljjl_query.Text != "")
            {
                where_str += string.Format(" and ( componentId = {0}'  or Barcode ARef '%{1}%') ", this.textBoxljjl_query.Text, this.textBoxljjl_query.Text);
            }

            Maticsoft.BLL.component parts_bll = new Maticsoft.BLL.component();
            totle_num = parts_bll.GetRecordCount(where_str);
            if (this.totle_num % this.cur_page_lenb == 0)
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb;
            }
            else
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb + 1;
            }
            string page_info = string.Format("{0}/{1}", 1, totle_page_num);
            this.label_tot.Text = page_info;
            this.init_dgv();

        }

        private void dgvljjl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            this.tabControl_main.SelectedIndex = 1;
            if (e.RowIndex >= 0 && e.RowIndex < dgvljjl.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgvljjl.Columns.Count)
            {
                // MessageBox.Show(dgvljjl.Columns.Count.ToString() + " "+ e.ColumnIndex);
                if(dgvljjl.Columns[e.ColumnIndex].HeaderText == "零件类型基础管理")
                {
                    addparts addp = new addparts();
                    string ljh = dgvljjl.Rows[e.RowIndex].Cells["PN"].Value.ToString();
                    string Barcode = dgvljjl.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
                    addp.setenableSetValue(ljh, Barcode);
                    addp.ShowDialog();
                    return;
                    MessageBox.Show("设置位置");
                }
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
               //  MessageBox.Show("选中了无效的行");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(dataGridView1.Columns[e.ColumnIndex].Name);
            TestBZFrom tb = new TestBZFrom();
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count && e.ColumnIndex >=0 && e.ColumnIndex < dataGridView1.Columns.Count)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "remark")
                {
                    tb.LjHao = dataGridView1.Rows[e.RowIndex].Cells["componentId"].Value.ToString();
                    tb.Show();
                }

                // 数模处理
                if (e.ColumnIndex == 7)
                {
                    string cur_dir = System.Environment.CurrentDirectory;
                    ofd_sm.InitialDirectory = cur_dir+"\\shumo";
                    if (this.ofd_sm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(ofd_sm.FileName);
                    }
                    this.dataGridView1.CurrentCell.Value = Path.GetFileName(ofd_sm.FileName);
                }

                if (e.ColumnIndex == 8)
                {
                    string cur_dir = System.Environment.CurrentDirectory;
                    ofd_sm.InitialDirectory = cur_dir + "\\images";
                    if (this.ofd_sm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(ofd_sm.FileName);
                    }
                    this.dataGridView1.CurrentCell.Value = Path.GetFileName(ofd_sm.FileName);
                }

            }
            else
            {
               //  MessageBox.Show("选中了无效的行");
            }
        }

        private void buttonjl_pre_Click(object sender, EventArgs e)
        {
            if (this.cur_page_num2 > 0)
            {
                cur_page_num2--;
                string page_par = string.Format("{0}/{1}", cur_page_num2 + 1, totle_page_num2);
                this.label_baifen1.Text = page_par;
            }
            init_ljjldgv();
            return;
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

            if (this.cur_page_num2 +1  < this.totle_page_num2)
            {
                cur_page_num2++;
                string page_par = string.Format("{0}/{1}", cur_page_num2 + 1, totle_page_num2);
                this.label_baifen1.Text = page_par;
            }
            init_ljjldgv();
            return;

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
            if (this.cur_page_num > 0)
            {
                cur_page_num--;
                string page_par = string.Format("{0}/{1}", cur_page_num + 1, totle_page_num);
                this.label_tot.Text = page_par;
            }
            init_dgv();
            return;
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

            if (this.cur_page_num  +1 < this.totle_page_num)
            {
                cur_page_num++;
                string page_par = string.Format("{0}/{1}", cur_page_num + 1, totle_page_num);
                this.label_tot.Text = page_par;
            }
            init_dgv();
            return;

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
            foreach (DataGridViewRow dr in dgvljjl.SelectedRows)
            {
                int will_del_id = Convert.ToInt32(dr.Cells["id"].Value);
                del_list_for_part.Add(will_del_id);
                dgvljjl.Rows.Remove(dr);
            }

            return;
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
            requery2();
        }
        List<int> del_list = new List<int>();
        List<int> del_list_for_part = new List<int>();
        private void button_del_Click(object sender, EventArgs e)
        {
            //dataGridView1.SelectedRows
            foreach(DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                int will_del_id = Convert.ToInt32(dr.Cells["componentId"].Value);
                del_list.Add(will_del_id);
                dataGridView1.Rows.Remove(dr);
            }
            return;
            int index = this.dataGridView1.CurrentCell.RowIndex;
            if (index >= 0 && index < this.dgvljjl.Rows.Count)
            {
                var id = this.dataGridView1.Rows[index].Cells["componentId"].Value;
                Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
                if (comp_bll.Delete(Convert.ToInt32(id)))
                {
                    MessageBox.Show("删除成功");
                }
                else {
                    MessageBox.Show("没有删除成功");
                }
            }
            requery();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            AddComponent add_from = new AddComponent();
            if( DialogResult.OK == add_from.ShowDialog())
            {
                requery();
            }
  
        }

        private void buttolj_add_Click(object sender, EventArgs e)
        {
            addparts add_from = new addparts();
            if(DialogResult.OK == add_from.ShowDialog())
            {
                requery2();
            }
        }
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                IWorkbook workbook;
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                //    workbook = new XSSFWorkbook(fs);
                ////else if (fileName.IndexOf(".xls") > 0) // 2003版本
                //else
                //    workbook = new HSSFWorkbook(fs);
                workbook = new HSSFWorkbook(fs);
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
            finally
            {
                Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string componentId = dataGridView1.CurrentRow.Cells["componentId"].Value.ToString();
            Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
            DataSet ds= comp_bll.GetList(string.Format( " componentId = '{0}'", componentId));
            DataTable dt = ds.Tables[0];
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                //this.DataToExcel(dt, fName);
                Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
                DataSet ds2 = mea_bll.GetList(string.Format(" componentId = '{0}'", componentId));
                DataTable dt2 = ds2.Tables[0];

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        Console.WriteLine(dt2.Rows[i][j].ToString());
                    }
                }
                this.TableToExcelForXLSX2003(dt, dt2, fName, "s1");
                // this.TableToExcelForXLSX2003(dt2, fName, "s2");
                //string file_name = Path.GetFileNameWithoutExtension(fName) + "详情"+ Path.GetExtension(fName);
                //file_name = Path.GetDirectoryName(fName)+ "\\" + file_name;
                //this.DataToExcel(dt2, file_name);
                //this.TableToExcelForXLSX2003(dt2, file_name, "s2");
            }
        }
        /// <summary>  
        /// Datatable生成Excel表格并返回路径  
        /// </summary>  
        /// <param name="m_DataTable">Datatable</param>  
        /// <param name="s_FileName">文件名</param>  
        /// <returns></returns>  
        public string DataToExcel(System.Data.DataTable m_DataTable, string s_FileName)
        {
            //string FileName = AppDomain.CurrentDomain.BaseDirectory + s_FileName + ".xls";  //文件存放路径  
            if (System.IO.File.Exists(s_FileName))                                //存在则删除  
            {
                System.IO.File.Delete(s_FileName);
            }
            System.IO.FileStream objFileStream;
            System.IO.StreamWriter objStreamWriter;
            string strLine = "";
            objFileStream = new System.IO.FileStream(s_FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            objStreamWriter = new System.IO.StreamWriter(objFileStream, Encoding.Unicode);
            for (int i = 0; i < m_DataTable.Columns.Count; i++)
            {
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //写列标题  
            }
            objStreamWriter.WriteLine(strLine);
            strLine = "";
            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {
                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {
                    if (m_DataTable.Rows[i].ItemArray[j] == null)
                        strLine = strLine + " " + Convert.ToChar(9);                                    //写内容  
                    else
                    {
                        string rowstr = "";
                        rowstr = m_DataTable.Rows[i].ItemArray[j].ToString();
                        if (rowstr.IndexOf("\r\n") > 0)
                            rowstr = rowstr.Replace("\r\n", " ");
                        if (rowstr.IndexOf("\t") > 0)
                            rowstr = rowstr.Replace("\t", " ");
                        strLine = strLine + rowstr + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
            }
            objStreamWriter.Close();
            objFileStream.Close();
            return s_FileName;        //返回生成文件的绝对路径  
        }

        /// <summary>
        /// DataTable导出Excel2003（.xls）
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="file">文件路径（.xls）</param>
        /// <param name="sheetname">Excel工作表名</param>
        public void TableToExcelForXLSX2003(DataTable dt, DataTable dt2, string file, string sheetname)
        {
            HSSFWorkbook xssfworkbook = new HSSFWorkbook();//建立Excel2003对象
            HSSFSheet sheet = (HSSFSheet)xssfworkbook.CreateSheet(sheetname);//新建一个名称为sheetname的工作簿
            //设置列名
            HSSFRow row = (HSSFRow)sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = (ICell)row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }
            //单元格赋值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            HSSFSheet sheet2 = (HSSFSheet)xssfworkbook.CreateSheet("s2");//新建一个名称为sheetname的工作簿

            //设置列名
            HSSFRow row2 = (HSSFRow)sheet2.CreateRow(0);
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                ICell cell = (ICell)row2.CreateCell(i);
                cell.SetCellValue(dt2.Columns[i].ColumnName);
            }
            //单元格赋值
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                IRow row1 = sheet2.CreateRow(i + 1);
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt2.Rows[i][j].ToString());
                }
            }

            using (System.IO.Stream stream = File.OpenWrite(file))
            {
                xssfworkbook.Write(stream);
                stream.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = ExcelToDataTable(openFileDialog1.FileName, "s1", true);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        Console.WriteLine(dt.Rows[i][j].ToString());
                //    }
                //}
                Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
                
                for (int i=0; i<dt.Rows.Count;i++)
                {
                    if (! comp_bll.Exists(Convert.ToInt32(dt.Rows[i]["componentId"])))
                    {
                        Maticsoft.Model.component comp_mode = new Maticsoft.Model.component()
                        {
                            componentId = Convert.ToInt32(dt.Rows[i]["componentId"]),
                            ARef = Convert.ToString(dt.Rows[i]["ARef"]),
                            jobnum = Convert.ToString(dt.Rows[i]["jobnum"]),
                            name = Convert.ToString(dt.Rows[i]["name"]),
                            size = Convert.ToString(dt.Rows[i]["size"]),
                            photo = Convert.ToString(dt.Rows[i]["photo"]),
                            sm = Convert.ToString(dt.Rows[i]["sm"]),
                            remark = Convert.ToString(dt.Rows[i]["remark"])
                        };
                        comp_bll.Add(comp_mode);
                    }
                }

                DataTable dt2 = ExcelToDataTable(openFileDialog1.FileName, "s2", true);
                Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (!mea_bll.Exists(Convert.ToInt32(dt2.Rows[i]["id"])))
                    {
                        Maticsoft.Model.measures mea_obj = new Maticsoft.Model.measures()
                        {
                            id = Convert.ToInt32(dt2.Rows[i]["id"]),
                            componentId = Convert.ToInt32(dt2.Rows[i]["componentId"]),
                            standardv = Convert.ToString(dt2.Rows[i]["standardv"]),
                            step = Convert.ToInt32(dt2.Rows[i]["step"]),
                            down = Convert.ToString(dt2.Rows[i]["down"]),
                            up = Convert.ToString(dt2.Rows[i]["up"]),
                            devicetype = Convert.ToInt32(dt2.Rows[i]["devicetype"]),
                            position = Convert.ToString(dt2.Rows[i]["position"]),
                            Tools = Convert.ToString(dt2.Rows[i]["Tools"]),
                            CC = Convert.ToString(dt2.Rows[i]["CC"]),
                        };
                        mea_bll.Add(mea_obj);
                    }
                }
            }

        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (dgr != null)
                {

                    Maticsoft.Model.component comp_mode = new Maticsoft.Model.component
                    {
                        ARef = dgr.Cells["ARef"].Value.ToString(),
                        componentId = Convert.ToInt32(dgr.Cells["componentId"].Value),
                        jobnum = dgr.Cells["jobnum"].Value.ToString(),
                        size = dgr.Cells["size"].Value.ToString(),
                        name = dgr.Cells["name"].Value.ToString(),
                        photo = dgr.Cells["photo"].Value.ToString(),
                        remark = dgr.Cells["remark"].Value.ToString(),
                        sm = dgr.Cells["sm"].Value.ToString(),
                    };
                    if (comp_bll.Update(comp_mode))
                    {
                        // MessageBox.Show("更新成功");
                    }
                    else
                    {
                        MessageBox.Show("更新失败");
                    }
                }

            }
            foreach (int del_id in del_list)
            {
                if (comp_bll.Delete(del_id))
                {
                   // MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("没有删除成功");
                }
            }
            MessageBox.Show("提交成功");
            // DataGridViewRow dgr = dataGridView1.CurrentRow
        }

        private void bt_updata2_Click(object sender, EventArgs e)
        {
            //DataGridViewRow dgr = dgvljjl.CurrentRow;
            //Maticsoft.BLL.
        }

        private void label_tot_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.parts comp_bll = new Maticsoft.BLL.parts();
            foreach (int del_id in del_list_for_part)
            {
                if (comp_bll.Delete(del_id))
                {
                   //  MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("没有删除成功");
                }
            }
            MessageBox.Show("提交成功");
        }
    }
}

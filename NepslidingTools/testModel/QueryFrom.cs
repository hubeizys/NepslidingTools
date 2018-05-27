using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace NepslidingTools.testModel
{
    public partial class QueryFrom : WorkForm
    {
        string name = "QueryFrom";
        int cur_step = 0;
        int cur_page_lenb = 20;
        int totle_num = 0;

        public QueryFrom()
        {
            InitializeComponent();
        }

        public void test()
        {
            Console.WriteLine("test");
        }

        #region 把数据表格的东西放进excel之中
        //DataGridView dgv
        public void DataGridViewToExcel()
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "   ";///t
                        }
                        columnTitle += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容     
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "  ";///t
                            }
                            if (dgv.Rows[j].Cells[k].Value == null)
                                columnValue += "";
                            else
                                columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        #endregion


        private void QueryFrom_Load(object sender, EventArgs e)
        {
            textBox_ljhao.Text = Program.gdvid;
            global.CurActive = "QueryFrom";

            this.timeselect_dtp.Value = global.startTime;
            this.dgv.ReadOnly = true;

            #region 一共有多少
            // 下一页
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string = this.query_wherestring();
            this.totle_num = test_bll.GetRecordCount(where_string);

            string parem_num = string.Format("1/{0}", this.totle_num / this.cur_page_lenb + 1);
            labelX1.Text = parem_num;
            #endregion


            // 添加 智能补全
            this.AddAutoComp();
            // this.dealwithcomp(textBox_ljhao.Text);
            #region ------------------------------
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;

            //this.TopMost = true;
            //this.Activate();

            //DataTable dt = new DataTable();                                     //创建表
            //dt.Columns.Add("bomNo", typeof(Int32));                             //添加列
            //dt.Columns.Add("TestNo", typeof(Int32));
            //dt.Columns.Add("TestLoc", typeof(String));
            //dt.Columns.Add("TestTime", typeof(DateTime));
            //dt.Columns.Add("step1", typeof(string));
            //dt.Columns.Add("step2", typeof(string));
            //dt.Columns.Add("step3", typeof(string));
            //dt.Columns.Add("result", typeof(string));
            //dt.Rows.Add(new object[] { 10001, 2123120, "工位1", DateTime.Now,"偏差1mm","偏差-2mm","无偏差" ,"OK"});//添加行
            //dt.Rows.Add(new object[] { 10002, 2321115, "工位1", DateTime.Now, "偏差101mm", "偏差10mm", "偏差1mm", "NG"});
            //dt.Rows.Add(new object[] { 10003, 3011111, "工位1", DateTime.Now, "偏差1mm", "偏差1mm", "无偏差", "OK"});
            //dt.Rows.Add(new object[] { 10004, 3421112 , "工位2", DateTime.Now, "偏差1mm", "偏差1mm", "偏差-134mm", "NG"});
            //query_gc.DataSource = dt;
            #endregion
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Program.txtbh = textBox_ljhao.Text;
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void jisuan()
        {
            DataTable dt2 = NewMethod();
            //构建一个计算用的表格
            Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
            List<Maticsoft.Model.measures> mea_list = mea_bll.GetModelList(string.Format(" componentId = '{0}' order by step ", this.comp_type));
            foreach (Maticsoft.Model.measures mea_obj in mea_list)
            {
                dt2.Columns.Add(new DataColumn("s" + mea_obj.step.ToString(), typeof(Double)));
            }

            // 取得数据。 分解数据。 填充数据
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string1 = this.query_wherestring();
            radioGroup1.SelectedIndex = 2;
            DataSet ds = test_bll.GetList(where_string1);
            //DataTable dt = this.dgv.DataSource as DataTable;
            DataTable dt = ds.Tables[0];

            List<double[]> bbb = new List<double[]>();
            foreach (DataRow dr in dt.Rows)
            {
                string step = dr["step1"].ToString();
                string[] temp_step = step.Split('/');

                if (temp_step.Length == dt2.Columns.Count)
                {
                    DataRow dr_temp = dt2.NewRow();
                    for (int i = 0; i < temp_step.Length; i++)
                    {
                        double temp_d = 0;
                        Double.TryParse(temp_step[i], out temp_d);
                        dr_temp["s" + (i + 1).ToString()] = temp_d;
                        Console.WriteLine("temp_step[i] == " + temp_step[i] + " ===  " + i);
                    }
                    dt2.Rows.Add(dr_temp);
                    //Console.WriteLine(Environment.NewLine);
                }
            }
            /*
             CPK=Cp*（1-|Ca|）
            Ca (Capability of Accuracy)：制程准确度；在衡量「实际平均值」与「规格中心值」之一致性。对於单边规格，因不存在规格中心，因此不存在Ca；对於双边规格，Ca=(ˉx-U)/(T/2)。
            Cp (Capability of Precision)：制程精密度；在衡量「规格公差宽度」与「制程变异宽度」之比例。对於单边规格，只有上限和中心值，Cpu = | USL-ˉx | / 3σ 或 只有下限和中心值，Cpl = | ˉx -LSL | / 3σ；对於双边规格：Cp=(USL-LSL) / 6σ=T/6σ
            注意: 计算Cpk时，取样数据至少应有20组数据，而且数据要具有一定代表性。

            某零件质量要求为20±0.15，抽样100件，测得：-x =20.05mm；s=0.05mm，求过程能力指数。根据零件的规格要求，Tu=20.15，Tl=19.85
            M=Tu+Tl/2=(20.15+19.85)/2=20.00
            ε=|M- 20.05|=0.05
            T = USL - LSL = 20.15 - 19.85 = 0.3
            CPK = CP*（|1-CA|）
            = (T-2ε)/6s = (0.3-2*0.05)/(6*0.05)=(0.3-0.1)/(6*0.05)≈0.67
            */
            // 分析数据
            // mea_list
            string all_cpk = "";
            Dictionary<string, double> cpk_dic = new Dictionary<string, double>();
            foreach (DataColumn aa in dt2.Columns)
            {
                string col_name = aa.ColumnName.Replace("s", "");
                List<Maticsoft.Model.measures> mea_obj = mea_list.Where(x => x.step == Convert.ToInt32(col_name)).Select(x => x).ToList<Maticsoft.Model.measures>();
                //string rr = dt2.Select("", aa.ColumnName + " DESC")[0][aa.ColumnName].ToString();
                object max = dt2.Compute(string.Format("Max({0})", aa.ColumnName), "true");
                //  MessageBox.Show(max.ToString());
                object min = dt2.Compute(string.Format("Min({0})", aa.ColumnName), "true");

                double sta = Convert.ToDouble(mea_obj[0].standardv);

                double va_x1 = Convert.ToDouble(max is DBNull ? 0 : max);
                double va_x2 = Convert.ToDouble(min is DBNull ? 0 : min);
                double va_x = va_x1 - sta > sta - va_x2 ? va_x1 : va_x2;
                double va_s = sta - va_x;

                double tu = sta + Convert.ToDouble(mea_obj[0].up);
                double ti = sta - Convert.ToDouble(mea_obj[0].down);

                double v_m = (tu + ti) / 2;
                double sgm = Math.Abs(sta - va_x);
                double v_t = tu - ti;

                double cpk = (v_t - 2 * sgm) / (6 * va_s);
                Console.WriteLine(string.Format("max == {0} --- min {1}----- {2}::{3}", max, min, mea_obj[0].up, mea_obj[0].down));
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("cpk == {0}", cpk));
                all_cpk += " " + aa.ColumnName + "= " + cpk;
                cpk_dic.Add(aa.ColumnName, cpk);
            }
            string op = "\t" + get_okpara();
            //MessageBox.Show("all_cpk" + all_cpk + "   op" + op);
            label_result.Invoke(new Action(() => {
                label_result.Text = string.Format("all_cpk" + all_cpk + "   op" + op);
            }));
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt2 = NewMethod();
            //构建一个计算用的表格
            Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
            List<Maticsoft.Model.measures> mea_list = mea_bll.GetModelList(string.Format(" componentId = '{0}' order by step ", this.comp_type));
            foreach (Maticsoft.Model.measures mea_obj in mea_list)
            {
                dt2.Columns.Add(new DataColumn("s" + mea_obj.step.ToString(), typeof(Double)));
            }

            // 取得数据。 分解数据。 填充数据
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string1 = this.query_wherestring();
            radioGroup1.SelectedIndex = 2;
            DataSet ds = test_bll.GetList(where_string1);
            //DataTable dt = this.dgv.DataSource as DataTable;
            DataTable dt = ds.Tables[0];

            List<double[]> bbb = new List<double[]>();
            foreach (DataRow dr in dt.Rows)
            {
                string step = dr["step1"].ToString();
                string[] temp_step = step.Split('/');

                if (temp_step.Length == dt2.Columns.Count)
                {
                    DataRow dr_temp = dt2.NewRow();
                    for (int i = 0; i < temp_step.Length; i++)
                    {
                        double temp_d = 0;
                        Double.TryParse(temp_step[i], out temp_d);
                        dr_temp["s" + (i + 1).ToString()] = temp_d;
                        Console.WriteLine("temp_step[i] == " + temp_step[i] + " ===  " + i);
                    }
                    dt2.Rows.Add(dr_temp);
                    //Console.WriteLine(Environment.NewLine);
                }
            }
            /*
             CPK=Cp*（1-|Ca|）
            Ca (Capability of Accuracy)：制程准确度；在衡量「实际平均值」与「规格中心值」之一致性。对於单边规格，因不存在规格中心，因此不存在Ca；对於双边规格，Ca=(ˉx-U)/(T/2)。
            Cp (Capability of Precision)：制程精密度；在衡量「规格公差宽度」与「制程变异宽度」之比例。对於单边规格，只有上限和中心值，Cpu = | USL-ˉx | / 3σ 或 只有下限和中心值，Cpl = | ˉx -LSL | / 3σ；对於双边规格：Cp=(USL-LSL) / 6σ=T/6σ
            注意: 计算Cpk时，取样数据至少应有20组数据，而且数据要具有一定代表性。

            某零件质量要求为20±0.15，抽样100件，测得：-x =20.05mm；s=0.05mm，求过程能力指数。根据零件的规格要求，Tu=20.15，Tl=19.85
            M=Tu+Tl/2=(20.15+19.85)/2=20.00
            ε=|M- 20.05|=0.05
            T = USL - LSL = 20.15 - 19.85 = 0.3
            CPK = CP*（|1-CA|）
            = (T-2ε)/6s = (0.3-2*0.05)/(6*0.05)=(0.3-0.1)/(6*0.05)≈0.67
            */
            // 分析数据
            // mea_list
            string all_cpk = "";
            Dictionary<string, double> cpk_dic = new Dictionary<string, double>();
            foreach (DataColumn aa in dt2.Columns)
            {
                string col_name = aa.ColumnName.Replace("s", "");
                List<Maticsoft.Model.measures> mea_obj = mea_list.Where(x => x.step == Convert.ToInt32(col_name)).Select(x => x).ToList<Maticsoft.Model.measures>();
                //string rr = dt2.Select("", aa.ColumnName + " DESC")[0][aa.ColumnName].ToString();
                object max = dt2.Compute(string.Format("Max({0})", aa.ColumnName), "true");
                //  MessageBox.Show(max.ToString());
                object min = dt2.Compute(string.Format("Min({0})", aa.ColumnName), "true");

                double sta = Convert.ToDouble(mea_obj[0].standardv);

                double va_x1 = Convert.ToDouble(max is DBNull ? 0 : max);
                double va_x2 = Convert.ToDouble(min is DBNull ? 0 : min);
                double va_x = va_x1 - sta > sta - va_x2 ? va_x1 : va_x2;
                double va_s = sta - va_x;

                double tu = sta + Convert.ToDouble(mea_obj[0].up);
                double ti = sta - Convert.ToDouble(mea_obj[0].down);

                double v_m = (tu + ti) / 2;
                double sgm = Math.Abs(sta - va_x);
                double v_t = tu - ti;

                double cpk = (v_t - 2 * sgm) / (6 * va_s);
                Console.WriteLine(string.Format("max == {0} --- min {1}----- {2}::{3}", max, min, mea_obj[0].up, mea_obj[0].down));
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("cpk == {0}", cpk));
                all_cpk += " " + aa.ColumnName + "= " + cpk;
                cpk_dic.Add(aa.ColumnName, cpk);
            }
            string op = "\t" + get_okpara();
            //MessageBox.Show("all_cpk" + all_cpk + "   op" + op);
            label_result.Invoke(new Action(()=> {
                label_result.Text = string.Format("all_cpk" + all_cpk + "   op" + op);
            }));
            string all_op =  "   合格率" + op;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                //File fileOpen = new File(fName);
                //isFileHaveName = true;
                //richTextBox1.Text = fileOpen.ReadFile();
                //richTextBox1.AppendText("");
                // this.DataToExcel(dt, fName, all_op);
                Task daochu_task = new Task(new Action(()=> {
                    DataTable all_data = dt.Copy();
                    // 添加列
                    foreach (Maticsoft.Model.measures mea_obj in mea_list)
                    {
                        all_data.Columns.Add(new DataColumn("s" + mea_obj.step.ToString(), typeof(Double)));
                    }

                    foreach (DataRow dr in all_data.Rows)
                    {
                        dr["measureb"] = "'" + dr["measureb"];
                        string step = dr["step1"].ToString();
                        string[] temp_step = step.Split('/');
                        
                        for (int i =0; i< temp_step.Length ;i++)
                        {
                            string colname = "s" + (i + 1).ToString();
                            if(all_data.Columns.Contains(colname))
                            {
                                double a = 0;
                                double.TryParse(temp_step[i], out a);
                                dr[colname] = a;
                            }
                        }
                    }
                    DataRow dr_cpk = all_data.NewRow();
                    foreach (KeyValuePair<string, double> kp in cpk_dic)
                    {
                        if (all_data.Columns.Contains(kp.Key))
                        {
                            dr_cpk[kp.Key] = kp.Value;
                        }
                    }
                    all_data.Rows.Add(dr_cpk);
                    all_data.Columns.Remove("step1");
                    this.DataToExcel(all_data, fName, all_op);
                }));
                daochu_task.Start();
            }
        }

        private static DataTable NewMethod()
        {
            //daochu dc = new daochu();
            //dc.resa = this;
            //dc.ShowDialog();

            return new DataTable();
        }

        /// <summary>  
        /// Datatable生成Excel表格并返回路径  
        /// </summary>  
        /// <param name="m_DataTable">Datatable</param>  
        /// <param name="s_FileName">文件名</param>  
        /// <returns></returns>  
        public string DataToExcel(System.Data.DataTable m_DataTable, string s_FileName, string op)
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
            objStreamWriter.WriteLine(op + Convert.ToChar(9));
            objStreamWriter.Close();
            objFileStream.Close();
            return s_FileName;        //返回生成文件的绝对路径  
        }
        private string get_okpara()
        {
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            radioGroup1.SelectedIndex = 2;
            string where_string1 = this.query_wherestring();
            int tot = test_bll.GetRecordCount(where_string1);

            radioGroup1.SelectedIndex = 0;
            string where_string2 = this.query_wherestring();
            int ok_num = test_bll.GetRecordCount(where_string2);

            double percent = Convert.ToDouble(ok_num) / Convert.ToDouble(tot);
            string result = string.Format("{0:0.00%}", percent);//得到5.88%
            //MessageBox.Show(result);
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string query_wherestring()
        {
            string where_str = " 1=1 ";
            #region 按照需求查出表
            // 罗列条件
            //////////////// 零件号

            #region 零件号基础信息
            string lijianhao = textBox_ljhao.Text;
            if (lijianhao != null && lijianhao != "")
            {
                where_str += string.Format(" and PN = '{0}' ", lijianhao);
            }
            else
            {
                // MessageBox.Show("请输入零件号");
                return where_str;
            }
            #endregion

            #region 预备 --查询-- 表字段
            // 
            //////////////// 时间
            #region 时间条件
            int cmp = timeselect_dtp.Value.CompareTo(dtp.Value);
            if (cmp < 0)
            {
                where_str += string.Format(" and  time >= '{0}'and time<='{1}' ", timeselect_dtp.Value, dtp.Value);
            }
            #endregion

            //////////////// ok or ng
            #region 是否成功的条件
            if (radioGroup1.SelectedIndex == 0)
            {
                where_str += string.Format(" and OKorNG = '{0}' ", "OK");
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                where_str += string.Format(" and OKorNG = '{0}' ", "NG");
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                // where_str += string.Format(" and OKorNG = '{0}' ", "ALL");
            }
            #endregion

            //////////////// 工作站
            #region 工作站 筛选
            if (txt_workst.Text != "")
            {
                where_str += string.Format(" and workid = '{0}'  ", txt_workst.Text);
            }
            #endregion


            return where_str;
            #endregion
        }
        private void SetColor()
        {
            foreach (DataGridViewRow row in this.dgv.Rows)
            {
                this.dgv.BeginInvoke(new Action(()=> {
                    foreach (DataGridViewColumn dgc in dgv.Columns)
                    {
                        string glo_str = row.Cells[dgc.Name].Value.ToString();
                        int index = glo_str.IndexOf("偏差");
                        if (index != -1 )
                        {
                            row.Cells[dgc.Name].Style.BackColor = Color.Red;
                        }
                    }
                }));
            }
        }

        private void reQuery(bool all=false)
        {

            string where_string = this.query_wherestring();

            // 同步处理好 零件的基础信息的事情
            string lijianhao = textBox_ljhao.Text;
            if (lijianhao != null && lijianhao != "")
            {
                this.dealwithcomp(lijianhao);
            }
            else
            {
                return;
            }

            #region 构建基本的表形状
            //DataTable dtb = new DataTable();
            //
            //string st = string.Format("PN = '{0}'", textBox_ljhao.Text);
            DataTable mea_dt = new DataTable();
            Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
            List<Maticsoft.Model.measures> mea_modes = mea_bll.GetModelList(string.Format(" componentId={0}", this.comp_type));
            mea_dt.Columns.Add("零件号");
            mea_dt.Columns.Add("测量编号");
            mea_dt.Columns.Add("测量时间");
            mea_modes = mea_modes.OrderBy(obj => obj.step).ToList();
            foreach (Maticsoft.Model.measures mea_obj in mea_modes)
            {
                //string sg = "步骤" + mea_dt.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                // comboBox1.Text = sg;
                string sg = "步骤" + mea_obj.step.ToString();
                mea_dt.Columns.Add(sg.ToString());
            }
            mea_dt.Columns.Add("测量结果");
            dgv.DataSource = mea_dt;
            #endregion

            // 查询出来test 数据
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            // List<Maticsoft.Model.test> test_lists =  test_bll.GetModelList(where_str);
            DataSet ds = new DataSet();
            if (all == true)
            {
                ds = test_bll.GetListByPage(where_string, "", cur_step + 1, cur_step + cur_page_lenb);
            }
            else {
                ds = test_bll.GetListByPage(where_string, "", 0, 10000);
            }
            DataTable dt = ds.Tables[0];
            DataTable dest_table = dgv.DataSource as DataTable;

            #region 根据数据 更新表结构  ==== 惰性加入数据
            // 放入基础信息
            Task<string[]> parent = new Task<string[]>((aa) =>
            {
                DataTable local_dt = aa as DataTable;
                int count = local_dt.Rows.Count;
                string[] ret = new string[count];

                // MessageBox.Show("一共多少行" + dt.Rows.Count.ToString());
                for (int i = 0; i < count; i++)
                {
                    DataRow xin_dr = dest_table.NewRow();
                    xin_dr["零件号"] = local_dt.Rows[i]["PN"];
                    xin_dr["测量编号"] = local_dt.Rows[i]["measureb"];
                    xin_dr["测量时间"] = local_dt.Rows[i]["time"];
                    xin_dr["测量结果"] = local_dt.Rows[i]["OKorNG"];
                    dest_table.Rows.Add(xin_dr);
                    //xin_dr.Rows[][] = local_dt.Rows[i][0] 
                    new Task((index) =>
                    {
                        int ret_i = Convert.ToInt32(index);
                        // Console.WriteLine("试试   " + index);
                        ret[ret_i] = local_dt.Rows[ret_i]["step1"].ToString();
                    }, i, TaskCreationOptions.AttachedToParent).Start();
                }
                return ret;
            }, dt);
            parent.ContinueWith((t) =>
            {
                for (int i = 0; i < t.Result.Length; i++)
                {
                    string[] sp_l = t.Result[i].Split('/');
                    foreach (Maticsoft.Model.measures mea_obj in mea_modes)
                    {
                        int ret_col_num = 1;
                        bool col_if = int.TryParse(mea_obj.step.ToString(), out ret_col_num);
                        string sg = "步骤" + mea_obj.step.ToString();
                        //mea_modes
                        if (col_if && ret_col_num < sp_l.Length + 1)
                        {
                            int stand_info = Convert.ToInt32(mea_obj.standardv);
                            string test_str = sp_l[ret_col_num - 1];
                            if (test_str == "")
                            {
                                continue;
                            }
                            double test_info = Convert.ToDouble(test_str);
                            dest_table.Rows[i][sg] = sp_l[ret_col_num - 1];
                            if (stand_info - Convert.ToDouble(mea_obj.down) > test_info)
                            {
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.Blue;
                            }

                            else if (stand_info + Convert.ToDouble(mea_obj.up) < test_info)
                            {
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.Red;
                            }
                            else
                            {
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.Green;
                            }
                            //else if ()
                            //{ }

                            //if (  <= test_info &&  Convert.ToDouble(mea_obj.up) >= test_info)
                            //{
                            //}
                            //else {
                            //    dgv.Rows[i].Cells[sg].Style.BackColor = Color.Red;
                            //}
                        }
                    }
                }
            });

            parent.Start();

            #endregion

            #endregion
            return;
        }

        private void query_bt_Click(object sender, EventArgs e)
        {
            if (textBox_ljhao.Text == "")
            {
                MessageBox.Show("请输入查询字段");
                return;
            }
            this.reQuery();
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string = this.query_wherestring();
            this.totle_num = test_bll.GetRecordCount(where_string);
            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", 1, tot_page_index);
            this.labelX1.Text = page_info;

            jisuan();
            return;

            DataTable dtb = new DataTable();
            #region 构建datatable 表
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", textBox_ljhao.Text);
            DataSet ds1 = mes.GetList(st);
            #region 添加
            dtb.Columns.Add("零件号");
            dtb.Columns.Add("测量编号");
            dtb.Columns.Add("测量时间");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "步骤" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                                                                            // comboBox1.Text = sg;
                dtb.Columns.Add(sg.ToString());
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("测量结果");

            #endregion
            #region 填充数据
            if (radioGroup1.SelectedIndex == 0)
            {
                Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
                DateTime sj = Convert.ToDateTime(dtp.Text);
                DateTime sj1 = Convert.ToDateTime(timeselect_dtp.Text);
                string TS = string.Format("PN = '{0}'and time >= '{1}'and time<='{2}' and OKorNG='{3}'", textBox_ljhao.Text, sj1, sj, "OK");
                DataSet dst = tst.GetList(TS);
                DataTable test_datatable = dst.Tables[0];
                int test_count = test_datatable.Rows.Count;
                for (int start_test = 0; start_test < test_count; start_test++)
                {
                    string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                    string[] sp = stp1.Split(new char[] { '/' });//获取数据集合                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["测量编号"] = aa;
                    dr["测量时间"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["测量结果"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["零件号"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("步骤{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "步骤" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

                            if (col_name == sg)
                            {
                                // comboBox1.Text = ds1.Tables[0].Rows[i]["step"].ToString();
                                Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                                string st1 = string.Format("PN = '{0}' ", textBox_ljhao.Text);
                                DataSet ds11 = mes1.GetList(st1);
                                for (int b = 0; b < ds11.Tables[0].Rows.Count; b++)
                                {
                                    tt = ds11.Tables[0].Rows[b][4].ToString();
                                    double rr = Convert.ToDouble(j);
                                    double yy = Convert.ToDouble(tt);
                                    dr[col_name] = "偏差" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
                                    string vv = dr[col_name].ToString();
                                    break;
                                }
                            }
                        }

                    }

                    dtb.Rows.Add(dr);
                }
            }
            if (radioGroup1.SelectedIndex == 1)
            {
                Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
                DateTime sj = Convert.ToDateTime(dtp.Text);
                DateTime sj1 = Convert.ToDateTime(timeselect_dtp.Text);
                string TS = string.Format("PN = '{0}'and time >= '{1}'and time<='{2}' and OKorNG='{3}'", textBox_ljhao.Text, sj1, sj, "Ng");
                DataSet dst = tst.GetList(TS);
                DataTable test_datatable = dst.Tables[0];
                int test_count = test_datatable.Rows.Count;
                for (int start_test = 0; start_test < test_count; start_test++)
                {
                    string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                    string[] sp = stp1.Split(new char[] { '/' });//获取数据集合                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["测量编号"] = aa;
                    dr["测量时间"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["测量结果"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["零件号"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("步骤{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "步骤" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

                            if (col_name == sg)
                            {

                                // comboBox1.Text = ds1.Tables[0].Rows[i]["step"].ToString();
                                Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                                string st1 = string.Format("PN = '{0}' ", textBox_ljhao.Text);
                                DataSet ds11 = mes1.GetList(st1);
                                for (int b = 0; b < ds11.Tables[0].Rows.Count; b++)
                                {
                                    tt = ds11.Tables[0].Rows[b][4].ToString();
                                    double rr = Convert.ToDouble(j);
                                    double yy = Convert.ToDouble(tt);
                                    dr[col_name] = "偏差" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
                                    string vv = dr[col_name].ToString();
                                    break;
                                }
                            }
                        }

                    }

                    dtb.Rows.Add(dr);
                }
            }
            if (radioGroup1.SelectedIndex == 2)
            {
                Maticsoft.BLL.test tst = new Maticsoft.BLL.test();
                DateTime sj = Convert.ToDateTime(dtp.Text);
                DateTime sj1 = Convert.ToDateTime(timeselect_dtp.Text);
                string TS = string.Format("PN = '{0}'and time >= '{1}'and time<='{2}'", textBox_ljhao.Text, sj1, sj);
                string TS1 = string.Format("PN = '{0}'and time >= '{1}'and time<='{2}' and OKorNG='{3}'", textBox_ljhao.Text, sj1, sj, "OK");
                DataSet dst1 = tst.GetList(TS1);
                DataTable test_datatable1 = dst1.Tables[0];
                int test_count1 = test_datatable1.Rows.Count;
                Program.hg = test_count1;
                DataSet dst = tst.GetList(TS);
                DataTable test_datatable = dst.Tables[0];
                int test_count = test_datatable.Rows.Count;
                Program.qb = test_count;
                for (int start_test = 0; start_test < test_count; start_test++)
                {
                    string stp1 = test_datatable.Rows[start_test]["step1"].ToString();
                    string[] sp = stp1.Split(new char[] { '/' });//获取数据集合                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["测量编号"] = aa;
                    dr["测量时间"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["测量结果"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["零件号"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("步骤{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "步骤" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

                            if (col_name == sg)
                            {

                                // comboBox1.Text = ds1.Tables[0].Rows[i]["step"].ToString();
                                Maticsoft.BLL.measures mes1 = new Maticsoft.BLL.measures();
                                string st1 = string.Format("PN = '{0}' ", textBox_ljhao.Text);
                                DataSet ds11 = mes1.GetList(st1);
                                for (int b = 0; b < ds11.Tables[0].Rows.Count; b++)
                                {
                                    tt = ds11.Tables[0].Rows[b][4].ToString();
                                    double rr = Convert.ToDouble(j);
                                    double yy = Convert.ToDouble(tt);
                                    dr[col_name] = "偏差" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
                                    string vv = dr[col_name].ToString();
                                    break;
                                }
                            }
                        }

                    }

                    dtb.Rows.Add(dr);
                }
            }
            #endregion
            #endregion
            // query_gc.DataSource = dtb;
            dgv.DataSource = dtb;
        }

        private void QueryFrom_Deactivate(object sender, EventArgs e)
        {
            //if (global.CurActive == this.name)
            //{
            //    Console.WriteLine("当前激活界面是: " + this.name);
            //    this.TopMost = true;
            //    this.Activate();
            //}
        }

        private void QueryFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            global.CurActive = "main";
            this.Dispose();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgv.CurrentCell.ColumnIndex.ToString());
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddAutoComp()
        {
            Task<List<Maticsoft.Model.parts>> ff_task = new Task<List<Maticsoft.Model.parts>>(() =>
            {
                List<Maticsoft.Model.parts> ret_list = new List<Maticsoft.Model.parts>();
                Maticsoft.BLL.parts part_bll = new Maticsoft.BLL.parts();
                ret_list = part_bll.GetModelList(" ");
                return ret_list;
            });
            ff_task.ContinueWith((ret_list) =>
            {
                var datasou = new AutoCompleteStringCollection();
                List<Maticsoft.Model.parts> local_ret_list = ret_list.Result;
                //ret_list.ConvertAll();
                List<string> pn_list = local_ret_list.ConvertAll<string>((temp_obj) => { return temp_obj.PN; });
                datasou.AddRange(pn_list.ToArray());
                textBox_ljhao.BeginInvoke(new Action(() =>
                {
                    textBox_ljhao.AutoCompleteCustomSource = datasou;
                    textBox_ljhao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox_ljhao.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }));
            });
            ff_task.Start();
        }

        private void textBox_ljhao_TextChanged(object sender, EventArgs e)
        {

            return;
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                    {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                    });

            textBox_ljhao.AutoCompleteCustomSource = source;
            textBox_ljhao.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox_ljhao.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void head_tpl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            this.labelX1.Text = page_info;
            this.reQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cur_step + cur_page_lenb > this.totle_num)
            {
                return;
            }
            cur_step += cur_page_lenb;

            int cur_page_index = cur_step / this.cur_page_lenb +1 ;
            int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb==0?0:1);
            string page_info = string.Format("{0}/{1}", cur_page_index, tot_page_index);
            this.labelX1.Text = page_info;
            this.reQuery();
        }

        private void 重测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.txtbh = textBox_ljhao.Text;
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void bt_ri_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddDays(-1);

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
            jisuan();
        }

        private void bt_zou_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddDays(-7);

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
            jisuan();
        }

        private void bt_yue_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddMonths(-1) ;

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
            jisuan();
        }
    }
}
 
 
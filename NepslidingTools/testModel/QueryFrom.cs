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
using Excel = Microsoft.Office.Interop.Excel;

namespace NepslidingTools.testModel
{
    public partial class QueryFrom : WorkForm
    {
        string name = "QueryFrom";
        int cur_step = 0;
        int cur_page_lenb = 17;
        int totle_num = 0;

        int totle_page_num = 0;
        int cur_page_num = 0;

        int defalut_select = 2;
        public QueryFrom()
        {
            InitializeComponent();
        }

        public void test()
        {
            Console.WriteLine("test");
        }

        #region �����ݱ��Ķ����Ž�excel֮��
        //DataGridView dgv
        public void DataGridViewToExcel()
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "����ΪExcel�ļ�";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //д���б���     
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "   ";///t
                        }
                        columnTitle += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //д��������     
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
            //textBox_ljhao.Text = Program.gdvid;
            global.CurActive = "QueryFrom";

            this.timeselect_dtp.Value = global.startTime;
            this.dgv.ReadOnly = true;

            #region һ���ж���
            // ��һҳ
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string = this.query_wherestring();
            this.totle_num = test_bll.GetRecordCount2(where_string);

            // ��ǰ����ҳ��
            if (this.totle_num % this.cur_page_lenb == 0)
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb;
            }
            else
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb + 1;
            }

            string parem_num = string.Format("1/{0}", this.totle_page_num);
            labelX1.Text = parem_num;
            #endregion


            // ��� ���ܲ�ȫ
            this.AddAutoComp();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


            Program.type = Convert.ToInt32( textBox_ljhao.Text);
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void jisuan()
        {
            DataTable dt2 = NewMethod();
            //����һ�������õı��
            Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
            List<Maticsoft.Model.measures> mea_list = mea_bll.GetModelList(string.Format(" componentId = '{0}' order by step ", this.comp_type));
            foreach (Maticsoft.Model.measures mea_obj in mea_list)
            {
                dt2.Columns.Add(new DataColumn("s" + mea_obj.step.ToString(), typeof(Double)));
            }

            // ȡ�����ݡ� �ֽ����ݡ� �������
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string1 = this.query_wherestring();
            // radioGroup1.SelectedIndex = 2;
            DataSet ds = test_bll.GetList3(where_string1);
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
             CPK=Cp*��1-|Ca|��
            Ca (Capability of Accuracy)���Ƴ�׼ȷ�ȣ��ں�����ʵ��ƽ��ֵ���롸�������ֵ��֮һ���ԡ���춵��߹���򲻴��ڹ�����ģ���˲�����Ca�����˫�߹��Ca=(��x-U)/(T/2)��
            Cp (Capability of Precision)���Ƴ̾��ܶȣ��ں�������񹫲��ȡ��롸�Ƴ̱����ȡ�֮��������춵��߹��ֻ�����޺�����ֵ��Cpu = | USL-��x | / 3�� �� ֻ�����޺�����ֵ��Cpl = | ��x -LSL | / 3�ң����˫�߹��Cp=(USL-LSL) / 6��=T/6��
            ע��: ����Cpkʱ��ȡ����������Ӧ��20�����ݣ���������Ҫ����һ�������ԡ�

            ĳ�������Ҫ��Ϊ20��0.15������100������ã�-x =20.05mm��s=0.05mm�����������ָ������������Ĺ��Ҫ��Tu=20.15��Tl=19.85
            M=Tu+Tl/2=(20.15+19.85)/2=20.00
            ��=|M- 20.05|=0.05
            T = USL - LSL = 20.15 - 19.85 = 0.3
            CPK = CP*��|1-CA|��
            = (T-2��)/6s = (0.3-2*0.05)/(6*0.05)=(0.3-0.1)/(6*0.05)��0.67
            */
            // ��������
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

            dgv.Invoke(new Action(() =>
            {
                #region ���һ���ܽ�
                DataTable temp_table = dgv.DataSource as DataTable;
                DataRow temp_dr = temp_table.NewRow();
                temp_dr["�����"] = "�����CPK";
                foreach (KeyValuePair<string, double> par in cpk_dic)
                {
                    string key_name = par.Key.Replace("s", "����");
                    temp_dr[key_name] = par.Value.ToString("0.00");
                }
                temp_dr["���"] = op.Replace("\t", "");
                temp_table.Rows.Add(temp_dr);
                dgv.Refresh();
            }));
            #endregion
        }
        /// <summary>
        /// �����ݱ��浽Excel�����
        /// </summary>
        /// <param name="addr">Excel����ŵ�ַ����������Ŀ¼����Ĳ��֣�</param>
        /// <param name="dt">Ҫ�����DataTable</param>
        public void SaveToExcel(string addr, System.Data.DataTable dt)
        {
            //0.ע�⣺
            // * Excel������Cells[x][y]��д����ǰ����������У��������������!
            // * Excel�е��С��ж��Ǵ�1��ʼ�ģ�������0
            //1.����һ���µ�Excel�ĵ�ʵ��
            Excel::Application xlsApp = new Excel::Application();
            xlsApp.Workbooks.Add(true);
            /* ʾ�����룺��Ҫע��Excel��������1Ϊ��ʼ��������0��
              * for (int i = 1; i < 10; i++)
              * {
              *   for (int j = 1; j < 10; j++)
              *   {
              *     xlsApp.Cells[i][j] = "-"; 
              *   }
              * }
              */
            //2.����Excel��ҳ������
            xlsApp.ActiveSheet.Name = "���";
            //xlsApp.ActiveSheet.Name = dt.TableName;
            //3.�ϲ���һ�еĵ�Ԫ��
            string temp = "";
            if (dt.Columns.Count < 26)
            {
                temp = ((char)('A' + dt.Columns.Count)).ToString();
            }
            else if (dt.Columns.Count <= 26 + 26 * 26)
            {
                temp = ((char)('A' + (dt.Columns.Count - 26) / 26)).ToString()
                  + ((char)('A' + (dt.Columns.Count - 26) % 26)).ToString();
            }
            else throw new Exception("��������");
            Excel::Range range = xlsApp.get_Range("A1", temp + "1");
            range.ClearContents(); //���Ҫ�ϲ�������
            range.MergeCells = true; //�ϲ���Ԫ��
                                     //4.��д��һ�У���������ӦDataTable��TableName
            //xlsApp.Cells[1][1] = dt.TableName;
            xlsApp.Cells[1][1] = "�����鱨��";
            xlsApp.Cells[1][1].Font.Name = "����";
            xlsApp.Cells[1][1].Font.Size = 25;
            xlsApp.Cells[1][1].Font.Bold = true;
            xlsApp.Cells[1][1].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//����
            xlsApp.Rows[1].RowHeight = 60; //��һ���и�Ϊ60����λ������
                                           //5.�ϲ��ڶ��е�Ԫ��������д�����������
            range = xlsApp.get_Range("A2", temp + "2");
            range.ClearContents(); //���Ҫ�ϲ�������
            range.MergeCells = true; //�ϲ���Ԫ��
                                     //6.��д�ڶ��У�����ʱ��
            xlsApp.Cells[1][2] = "���������ڣ�" + DateTime.Now.ToString();
            xlsApp.Cells[1][2].Font.Name = "����";
            xlsApp.Cells[1][2].Font.Size = 15;
            //xlsApp.Cells[1][2].HorizontalAlignment = 4;//�Ҷ���
            xlsApp.Cells[1][2].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//����
            xlsApp.Rows[2].RowHeight = 30; //��һ���и�Ϊ60����λ������
                                           //7.��д���еı�����
            xlsApp.Cells[1][3] = "���";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                xlsApp.Cells[i + 2][3] = dt.Columns[i].ColumnName;
            }
            xlsApp.Rows[3].Font.Name = "����";
            xlsApp.Rows[3].Font.Size = 15;
            xlsApp.Rows[3].Font.Bold = true;
            xlsApp.Rows[3].HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;//����
                                                                               //������ɫ
            range = xlsApp.get_Range("A3", temp + "3");
            range.Interior.ColorIndex = 33;

            xlsApp.Columns[3].ColumnWidth = 20;
            xlsApp.Columns[4].ColumnWidth = 20;
            xlsApp.Columns[3].NumberFormat = "@";
            //8.��дDataTable�е�����
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                xlsApp.Cells[1][i + 4] = i.ToString();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    xlsApp.Cells[j + 2][i + 4] = dt.Rows[i][j];
                }
            }
            range = xlsApp.get_Range("A4", temp + (dt.Rows.Count + 3).ToString());
            range.Interior.ColorIndex = 37;
            range.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            //9.���߿�
            range = xlsApp.get_Range("A1", temp + (dt.Rows.Count + 3).ToString());
            range.Borders.LineStyle = 1;
            range.Borders.Weight = 3;
            //10.��������ϵı��
            //xlsApp.Visible = true;
            //11.�����񵽸�Ŀ¼��ָ�����Ƶ��ļ���
            //xlsApp.ActiveWorkbook.SaveAs(Application.StartupPath + "/" + addr);
            xlsApp.ActiveWorkbook.SaveAs(addr);
            xlsApp.Quit();
            xlsApp = null;
            GC.Collect();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                //this.DataToExcel(this.dgv.DataSource as DataTable, fName, "");
                SaveToExcel(fName, this.dgv.DataSource as DataTable);
            }
            return;
        }

        private static DataTable NewMethod()
        {
            //daochu dc = new daochu();
            //dc.resa = this;
            //dc.ShowDialog();

            return new DataTable();
        }

        /// <summary>  
        /// Datatable����Excel��񲢷���·��  
        /// </summary>  
        /// <param name="m_DataTable">Datatable</param>  
        /// <param name="s_FileName">�ļ���</param>  
        /// <returns></returns>  
        public string DataToExcel(System.Data.DataTable m_DataTable, string s_FileName, string op)
        {
            //string FileName = AppDomain.CurrentDomain.BaseDirectory + s_FileName + ".xls";  //�ļ����·��  
            if (System.IO.File.Exists(s_FileName))                                //������ɾ��  
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
                strLine = strLine + m_DataTable.Columns[i].Caption.ToString() + Convert.ToChar(9);      //д�б���  
            }
            objStreamWriter.WriteLine(strLine);
            strLine = "";
            for (int i = 0; i < m_DataTable.Rows.Count; i++)
            {
                for (int j = 0; j < m_DataTable.Columns.Count; j++)
                {
                    if (m_DataTable.Rows[i].ItemArray[j] == null)
                        strLine = strLine + " " + Convert.ToChar(9);                                    //д����  
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
            return s_FileName;        //���������ļ��ľ���·��  
        }
        private string get_okpara()
        {
            string result = "";
            radioGroup1.Invoke(new Action(() =>
            {
                Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
                radioGroup1.SelectedIndex = 0;
                string where_string1 = this.query_wherestring();
                int tot = test_bll.GetRecordCount2(where_string1);

                radioGroup1.SelectedIndex = 2;
                string where_string2 = this.query_wherestring();
                int ok_num = test_bll.GetRecordCount2(where_string2);

                double percent = Convert.ToDouble(ok_num) / Convert.ToDouble(tot);
                result = string.Format("{0:0.00%}", percent);//�õ�5.88%
                radioGroup1.SelectedIndex = 0;
            }));
            
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
            #region ������������
            // ��������
            //////////////// �����
            //Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
            //List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList2(string.Format("  parts.componentId = '{0}'  ORDER BY test.time asc LIMIT 100", this.comp_type));
            //int test_count = test_lists.Count;

            #region ����Ż�����Ϣ
            string lingjian_leixing = textBox_ljhao.Text;
            if (lingjian_leixing != null && lingjian_leixing != "")
            {
                where_str += string.Format(" and N.componentId = {0} ", lingjian_leixing);
            }
            else
            {
                // MessageBox.Show("�����������");
                return where_str;
            }
            #endregion

            #region Ԥ�� --��ѯ-- ���ֶ�
            // 
            //////////////// ʱ��
            #region ʱ������
            int cmp = timeselect_dtp.Value.CompareTo(dtp.Value);
            if (cmp < 0)
            {
                where_str += string.Format(" and  time >= '{0}'and time<='{1}' ", timeselect_dtp.Value, dtp.Value);
            }
            #endregion

            //////////////// ok or ng
            #region �Ƿ�ɹ�������
            if (radioGroup1.SelectedIndex == 2)
            {
                where_str += string.Format(" and OKorNG = '{0}' ", "OK");
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                where_str += string.Format(" and OKorNG = '{0}' ", "NG");
            }
            else if (radioGroup1.SelectedIndex == 0)
            {
                // where_str += string.Format(" and OKorNG = '{0}' ", "ALL");
            }
            #endregion

            //////////////// ����վ
            #region ����վ ɸѡ
            if (txt_workst.Text != "")
            {
                where_str += string.Format(" and workid = '{0}'  ", txt_workst.Text);
            }
            #endregion


            return where_str;
            #endregion
        }

        private string query_wherestring_withparam(string param)
        {
            string where_str = " 1=1 ";
            #region ������������
            // ��������
            //////////////// �����
            //Maticsoft.BLL.test Test_bll = new Maticsoft.BLL.test();
            //List<Maticsoft.Model.test> test_lists = Test_bll.GetModelList2(string.Format("  parts.componentId = '{0}'  ORDER BY test.time asc LIMIT 100", this.comp_type));
            //int test_count = test_lists.Count;

            #region ����Ż�����Ϣ
            if (param != null && param != "")
            {
                where_str += string.Format(" and {0} ", param);
            }
            else
            {
                return where_str;
            }
            #endregion

            #region Ԥ�� --��ѯ-- ���ֶ�
            // 
            //////////////// ʱ��
            #region ʱ������
            int cmp = timeselect_dtp.Value.CompareTo(dtp.Value);
            if (cmp < 0)
            {
                where_str += string.Format(" and  time >= '{0}'and time<='{1}' ", timeselect_dtp.Value, dtp.Value);
            }
            #endregion

            //////////////// ok or ng
            #region �Ƿ�ɹ�������
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

            //////////////// ����վ
            #region ����վ ɸѡ
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
                        int index = glo_str.IndexOf("ƫ��");
                        if (index != -1 )
                        {
                            row.Cells[dgc.Name].Style.BackColor = Color.LightSalmon;
                        }
                    }
                }));
            }
        }

        private void reQuery(bool all=false)
        {

            string where_string = this.query_wherestring();

            // ͬ������� ����Ļ�����Ϣ������
            string lijianhao = textBox_ljhao.Text;
            if (lijianhao != null && lijianhao != "")
            {
                this.dealwithcomp(Convert.ToInt32( lijianhao));
            }
            else
            {
                return;
            }

            #region ���������ı���״
            DataTable mea_dt = new DataTable();
            Maticsoft.BLL.measures mea_bll = new Maticsoft.BLL.measures();
            List<Maticsoft.Model.measures> mea_modes = mea_bll.GetModelList(string.Format(" componentId={0}", this.comp_type));
            mea_dt.Columns.Add("�����");
            mea_dt.Columns.Add("�������");
            mea_dt.Columns.Add("����ʱ��");
            mea_modes = mea_modes.OrderBy(obj => obj.step).ToList();
            foreach (Maticsoft.Model.measures mea_obj in mea_modes)
            {
                //string sg = "����" + mea_dt.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                // comboBox1.Text = sg;
                string sg = "����" + mea_obj.step.ToString();
                mea_dt.Columns.Add(sg.ToString());
            }
            mea_dt.Columns.Add("���");
            dgv.DataSource = mea_dt;
            #endregion

            // ��ѯ����test ����
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            // List<Maticsoft.Model.test> test_lists =  test_bll.GetModelList(where_str);
            DataSet ds = new DataSet();
            if (all == true)
            {
                ds = test_bll.GetListByPage2(where_string, "", cur_page_lenb * cur_page_num, cur_page_lenb  * (1+cur_page_num));
            }
            else {
                ds = test_bll.GetListByPage2(where_string, "", 0, 10000);
            }
            DataTable dt = ds.Tables[0];
            DataTable dest_table = dgv.DataSource as DataTable;

            #region �������� ���±�ṹ  ==== ���Լ�������
            // ���������Ϣ
            Task<string[]> parent = new Task<string[]>((aa) =>
            {
                DataTable local_dt = aa as DataTable;
                int count = local_dt.Rows.Count;
                string[] ret = new string[count];

                for (int i = 0; i < count; i++)
                {
                    DataRow xin_dr = dest_table.NewRow();
                    xin_dr["�����"] = local_dt.Rows[i]["PN"];
                    xin_dr["�������"] = local_dt.Rows[i]["measureb"];
                    xin_dr["����ʱ��"] = local_dt.Rows[i]["time"];
                    xin_dr["���"] = local_dt.Rows[i]["OKorNG"];
                    dest_table.Rows.Add(xin_dr);
                    //xin_dr.Rows[][] = local_dt.Rows[i][0] 
                    new Task((index) =>
                    {
                        int ret_i = Convert.ToInt32(index);
                        // Console.WriteLine("����   " + index);
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
                        string sg = "����" + mea_obj.step.ToString();
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
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.Cyan;
                            }

                            else if (stand_info + Convert.ToDouble(mea_obj.up) < test_info)
                            {
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.LightSalmon;
                            }
                            else
                            {
                                dgv.Rows[i].Cells[sg].Style.BackColor = Color.Lime;
;
                            }
                        }
                    }
                }

                // ���� 
                jisuan();
            });

            parent.Start();

            #endregion

            #endregion
            return;
        }

        private void query_bt_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(radioGroup1.SelectedIndex.ToString());
            this.defalut_select = radioGroup1.SelectedIndex;
            if (textBox_ljhao.Text == "")
            {
                MessageBox.Show("�������ѯ�ֶ�");
                return;
            }
            this.reQuery(true);

            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string = this.query_wherestring();
            this.totle_num = test_bll.GetRecordCount2(where_string);
            if (this.totle_num % this.cur_page_lenb == 0)
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb;
            }
            else
            {
                this.totle_page_num = this.totle_num / this.cur_page_lenb + 1;
            }

            //int tot_page_index = this.totle_num / this.cur_page_lenb + (this.totle_num % this.cur_page_lenb == 0 ? 0 : 1);
            string page_info = string.Format("{0}/{1}", 1, totle_page_num);
            this.labelX1.Text = page_info;

            this.radioGroup1.SelectedIndex = defalut_select;
            return;
        }

        private void QueryFrom_Deactivate(object sender, EventArgs e)
        {
            //if (global.CurActive == this.name)
            //{
            //    Console.WriteLine("��ǰ���������: " + this.name);
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

        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddAutoComp()
        {
            Task<List<Maticsoft.Model.component>> ff_task = new Task<List<Maticsoft.Model.component>>(() =>
            {
                List<Maticsoft.Model.component> ret_list = new List<Maticsoft.Model.component>();
                Maticsoft.BLL.component part_bll = new Maticsoft.BLL.component();
                ret_list = part_bll.GetModelList(" ");
                return ret_list;
            });
            ff_task.ContinueWith((ret_list) =>
            {
                var datasou = new AutoCompleteStringCollection();
                List<Maticsoft.Model.component> local_ret_list = ret_list.Result;
                //ret_list.ConvertAll();
                List<string> pn_list = local_ret_list.ConvertAll<string>((temp_obj) => { return temp_obj.componentId.ToString(); });
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
        }

        private void head_tpl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.cur_page_num > 0)
            {
                cur_page_num--;
                string page_par = string.Format("{0}/{1}", cur_page_num+1, totle_page_num);
                this.labelX1.Text = page_par;
            }

            this.reQuery(true);
            return;
            // ��һҳ
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

            if (this.cur_page_num < this.totle_page_num)
            {
                cur_page_num++;
                string page_par = string.Format("{0}/{1}", cur_page_num + 1, totle_page_num);
                this.labelX1.Text = page_par;
            }
            this.reQuery(true);
            return;
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

        private void �ز�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.type = Convert.ToInt32( textBox_ljhao.Text);
            StepTestFrom stf = new StepTestFrom();

            stf.CompId = dgv.CurrentRow.Cells["�����"].Value.ToString(); ;
            stf.Show();
        }

        private void bt_ri_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddDays(-1);

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
        
        }

        private void bt_zou_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddDays(-7);

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
        
        }

        private void bt_yue_Click(object sender, EventArgs e)
        {
            DateTime cur = DateTime.Now;
            DateTime start = cur.AddMonths(-1) ;

            timeselect_dtp.Value = start;
            dtp.Value = cur;
            reQuery();
        
        }

        private void panelend_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioGroup1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_MouseDown(object sender, MouseEventArgs e)
        {


            //if (e.Button == MouseButtons.Right)
            //{
            //    Console.WriteLine(string.Format("dgv.CurrentCell.ColumnIndex {0}  == dgv.Columns[dgv.CurrentCell.ColumnIndex].Name {1}", dgv.CurrentCell.ColumnIndex, dgv.Columns[dgv.CurrentCell.ColumnIndex].Name));
            //    bool if_tr = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("����");
            //    MessageBox.Show(if_tr.ToString());
            //    if (if_tr)
            //    {
            //        dgv.ContextMenuStrip.Show(Cursor.Position);
               
            //    }
                    
            //}
            // MessageBox.Show(dgv.CurrentCell.ColumnIndex.ToString());

        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                this.dgv.ClearSelection();
                this.dgv.CurrentRow.Selected = false;
                this.dgv.Rows[e.RowIndex].Selected = true;
                this.dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Console.WriteLine(string.Format("dgv.CurrentCell.ColumnIndex {0}  == dgv.Columns[dgv.CurrentCell.ColumnIndex].Name {1}", dgv.CurrentCell.ColumnIndex, dgv.Columns[dgv.CurrentCell.ColumnIndex].Name));
                bool if_tr = dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("����");
                // MessageBox.Show(if_tr.ToString());
                if (if_tr)
                {
                    dgv.ContextMenuStrip = contextMenuStrip1;
                    dgv.ContextMenuStrip.Enabled = true;
                    contextMenuStrip1.Enabled = true;
                    dgv.ContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            dgv.ContextMenuStrip = null;
        }
    }
}
#endregion
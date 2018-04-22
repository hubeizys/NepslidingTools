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
            textBox_ljhao.Text = Program.gdvid;
            global.CurActive = "QueryFrom";

            #region һ���ж���
            // ��һҳ
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            string where_string = this.query_wherestring();
            this.totle_num = test_bll.GetRecordCount(where_string);

            string parem_num = string.Format("1/{0}", this.totle_num / this.cur_page_lenb + 1);
            labelX1.Text = parem_num;
            #endregion


            // ��� ���ܲ�ȫ
            this.AddAutoComp();
            // this.dealwithcomp(textBox_ljhao.Text);
            #region ------------------------------
            //Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            //this.Size = ScreenArea.Size;

            //this.TopMost = true;
            //this.Activate();

            //DataTable dt = new DataTable();                                     //������
            //dt.Columns.Add("bomNo", typeof(Int32));                             //�����
            //dt.Columns.Add("TestNo", typeof(Int32));
            //dt.Columns.Add("TestLoc", typeof(String));
            //dt.Columns.Add("TestTime", typeof(DateTime));
            //dt.Columns.Add("step1", typeof(string));
            //dt.Columns.Add("step2", typeof(string));
            //dt.Columns.Add("step3", typeof(string));
            //dt.Columns.Add("result", typeof(string));
            //dt.Rows.Add(new object[] { 10001, 2123120, "��λ1", DateTime.Now,"ƫ��1mm","ƫ��-2mm","��ƫ��" ,"OK"});//�����
            //dt.Rows.Add(new object[] { 10002, 2321115, "��λ1", DateTime.Now, "ƫ��101mm", "ƫ��10mm", "ƫ��1mm", "NG"});
            //dt.Rows.Add(new object[] { 10003, 3011111, "��λ1", DateTime.Now, "ƫ��1mm", "ƫ��1mm", "��ƫ��", "OK"});
            //dt.Rows.Add(new object[] { 10004, 3421112 , "��λ2", DateTime.Now, "ƫ��1mm", "ƫ��1mm", "ƫ��-134mm", "NG"});
            //query_gc.DataSource = dt;
            #endregion
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Program.txtbh = textBox_ljhao.Text;
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            #region ----------------------------------
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = "Execl files (*.xls)|*.xls";
            //dlg.FilterIndex = 0;
            //dlg.RestoreDirectory = true;
            //dlg.CreatePrompt = true;
            //dlg.Title = "����ΪExcel�ļ�";

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    Stream myStream;
            //    myStream = dlg.OpenFile();
            //    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            //    string columnTitle = "";
            //    try
            //    {
            //        //д���б���     
            //        for (int i = 0; i < dgv.ColumnCount; i++)
            //        {
            //            if (i > 0)
            //            {
            //                columnTitle += "/t";
            //            }
            //            columnTitle += dgv.Columns[i].HeaderText;
            //        }
            //        sw.WriteLine(columnTitle);

            //        //д��������     
            //        for (int j = 0; j < dgv.Rows.Count; j++)
            //        {
            //            string columnValue = "";
            //            for (int k = 0; k < dgv.Columns.Count; k++)
            //            {
            //                if (k > 0)
            //                {
            //                    columnValue += "/t";
            //                }
            //                if (dgv.Rows[j].Cells[k].Value == null)
            //                    columnValue += "";
            //                else
            //                    columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
            //            }
            //            sw.WriteLine(columnValue);
            //        }
            //        sw.Close();
            //        myStream.Close();
            //    }
            //    catch (Exception er)
            //    {
            //        MessageBox.Show(er.ToString());
            //    }
            //    finally
            //    {
            //        sw.Close();
            //        myStream.Close();
            //    }
            //}
            #endregion
            daochu dc = new daochu();
            dc.resa = this;
            dc.ShowDialog();
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

            #region ����Ż�����Ϣ
            string lijianhao = textBox_ljhao.Text;
            if (lijianhao != null && lijianhao != "")
            {
                where_str += string.Format(" and PN = '{0}' ", lijianhao);
            }
            else
            {
                MessageBox.Show("�����������");
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

        private void reQuery()
        {

            string where_string = this.query_wherestring();

            // ͬ������� ����Ļ�����Ϣ������
            string lijianhao = textBox_ljhao.Text;
            if (lijianhao != null && lijianhao != "")
            {
                this.dealwithcomp(lijianhao);
            }
            else
            {
                return;
            }

            #region ���������ı���״
            //DataTable dtb = new DataTable();
            //
            //string st = string.Format("PN = '{0}'", textBox_ljhao.Text);
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
            mea_dt.Columns.Add("�������");
            dgv.DataSource = mea_dt;
            #endregion

            // ��ѯ����test ����
            Maticsoft.BLL.test test_bll = new Maticsoft.BLL.test();
            // List<Maticsoft.Model.test> test_lists =  test_bll.GetModelList(where_str);
            DataSet ds = test_bll.GetListByPage(where_string, "", cur_step + 1, cur_step + cur_page_lenb);
            DataTable dt = ds.Tables[0];

            DataTable dest_table = dgv.DataSource as DataTable;

            #region �������� ���±�ṹ  ==== ���Լ�������
            // ���������Ϣ
            Task<string[]> parent = new Task<string[]>((aa) =>
            {
                DataTable local_dt = aa as DataTable;
                int count = local_dt.Rows.Count;
                string[] ret = new string[count];

                // MessageBox.Show("һ��������" + dt.Rows.Count.ToString());
                for (int i = 0; i < count; i++)
                {
                    DataRow xin_dr = dest_table.NewRow();
                    xin_dr["�����"] = local_dt.Rows[i]["PN"];
                    xin_dr["�������"] = local_dt.Rows[i]["measureb"];
                    xin_dr["����ʱ��"] = local_dt.Rows[i]["time"];
                    xin_dr["�������"] = local_dt.Rows[i]["OKorNG"];
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
                //Array.ForEach(t.Result, (r) =>
                //{
                //    // MessageBox.Show("aaaa");
                //    Console.WriteLine(string.Format("===== ============ {0}", r));
                //    //string.Format();
                //});
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
                            int test_info = Convert.ToInt32(sp_l[ret_col_num - 1]);

                            if (stand_info == test_info)
                            {
                                dest_table.Rows[i][sg] = sp_l[ret_col_num - 1];
                            }
                            else
                            {
                                dest_table.Rows[i][sg] = "ƫ��" + (test_info - stand_info).ToString();
                            }
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
            this.reQuery();
            return;

            DataTable dtb = new DataTable();
            #region ����datatable ��
            Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            string st = string.Format("PN = '{0}'", textBox_ljhao.Text);
            DataSet ds1 = mes.GetList(st);
            #region ���
            dtb.Columns.Add("�����");
            dtb.Columns.Add("�������");
            dtb.Columns.Add("����ʱ��");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string sg = "����" + ds1.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()
                                                                            // comboBox1.Text = sg;
                dtb.Columns.Add(sg.ToString());
                //dgv1.DataSource = ds.Tables[0];                
            }
            dtb.Columns.Add("�������");

            #endregion
            #region �������
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
                    string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["�������"] = aa;
                    dr["����ʱ��"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["�������"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["�����"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("����{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "����" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

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
                                    dr[col_name] = "ƫ��" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
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
                    string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["�������"] = aa;
                    dr["����ʱ��"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["�������"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["�����"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("����{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "����" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

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
                                    dr[col_name] = "ƫ��" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
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
                    string[] sp = stp1.Split(new char[] { '/' });//��ȡ���ݼ���                 
                    int sp_num = 0;
                    DataRow dr = dtb.NewRow();
                    string aa = test_datatable.Rows[start_test]["measureb"].ToString();
                    dr["�������"] = aa;
                    dr["����ʱ��"] = test_datatable.Rows[start_test]["time"].ToString();
                    dr["�������"] = test_datatable.Rows[start_test]["OKorNG"].ToString();
                    dr["�����"] = test_datatable.Rows[start_test]["PN"].ToString();
                    foreach (string j in sp)
                    {
                        string tt = "";
                        sp_num++;
                        string col_name = string.Format("����{0}", sp_num);
                        Maticsoft.BLL.measures ms = new Maticsoft.BLL.measures();
                        string pr = string.Format("PN = '{0}'", textBox_ljhao.Text);
                        DataSet std = mes.GetList(pr);

                        for (int i = 0; i < std.Tables[0].Rows.Count; i++)
                        {

                            string sg = "����" + std.Tables[0].Rows[i]["step"].ToString();// comboBox1.Items.Add()

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
                                    dr[col_name] = "ƫ��" + (rr - yy) + "mm";//Convert.ToDouble(j) - Convert.ToDouble(tt);
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
            Program.txtbh = textBox_ljhao.Text;
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
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
            // ��һҳ
            if (cur_step > cur_page_lenb)
            {
                cur_step -= cur_page_lenb;
            }
            else if (cur_step < cur_page_lenb)
            {
                cur_step = 0;
            }

            int cur_page_index = cur_step / this.cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.cur_page_lenb + 1;
            string page_info = string.Format("{1}/{1}", cur_page_index, tot_page_index);
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

            //{

            //    //if (cur_step + 2*  cur_page_lenb > cur_num)
            //    //{
            //    //    this.cur_page_lenb = cur_num;
            //    //}
            //}
            int cur_page_index = cur_step / this.cur_page_lenb + 1;
            int tot_page_index = this.totle_num / this.cur_page_lenb + 1;
            string page_info = string.Format("{1}/{1}", cur_page_index, tot_page_index);
            this.labelX1.Text = page_info;
            this.reQuery();
        }
    }
}
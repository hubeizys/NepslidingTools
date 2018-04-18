using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace NepslidingTools.testModel
{
    public partial class QueryFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
        string name = "QueryFrom";
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

        private void query_bt_Click(object sender, EventArgs e)
        {
            #region Ԥ����ѯ���ֶ�

            #endregion

            #region ����ѯ����
            #endregion


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
    }
}
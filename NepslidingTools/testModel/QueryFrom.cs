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
    public partial class QueryFrom : WorkForm
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            #region ----------------------------------
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = "Execl files (*.xls)|*.xls";
            //dlg.FilterIndex = 0;
            //dlg.RestoreDirectory = true;
            //dlg.CreatePrompt = true;
            //dlg.Title = "保存为Excel文件";

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    Stream myStream;
            //    myStream = dlg.OpenFile();
            //    StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            //    string columnTitle = "";
            //    try
            //    {
            //        //写入列标题     
            //        for (int i = 0; i < dgv.ColumnCount; i++)
            //        {
            //            if (i > 0)
            //            {
            //                columnTitle += "/t";
            //            }
            //            columnTitle += dgv.Columns[i].HeaderText;
            //        }
            //        sw.WriteLine(columnTitle);

            //        //写入列内容     
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

            string where_str = " 1=1 ";
            #region 按照需求查出表
            // 罗列条件
            //////////////// 零件号
            if (textBox_ljhao != null)
            {
                where_str += string.Format(" or  {0}", textBox_ljhao.Text);
            }
            else {
                MessageBox.Show("请输入零件号");
                return;
            }

            // 同步处理好 零件的基础信息的事情
            this.dealwithcomp(textBox_ljhao.Text);

            //////////////// 时间
            //////////////// ok or ng
            //////////////// 工作站
            //DataTable dtb = new DataTable();
            //Maticsoft.BLL.measures mes = new Maticsoft.BLL.measures();
            //string st = string.Format("PN = '{0}'", textBox_ljhao.Text);
            #endregion

            #region 预备查询表字段

            #endregion

            #region 甄别查询条件
            #endregion


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
            Program.txtbh = textBox_ljhao.Text;
            StepTestFrom stf = new StepTestFrom();
            stf.Show();
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_ljhao_TextChanged(object sender, EventArgs e)
        {

        }

        private void head_tpl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
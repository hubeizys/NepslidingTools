using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using NepslidingTools.testModel;
using Maticsoft.Model;
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop.Excel;


namespace NepslidingTools.toolbox
{
    public partial class BomFrom : DevComponents.DotNetBar.Metro.MetroForm
    {
       
        public BomFrom()
        {
            InitializeComponent();
        }

        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            MessageBox.Show(e.Button.ButtonType.ToString());
        }

        private void BomFrom_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.parts pr = new Maticsoft.BLL.parts();
            DataSet ds = pr.GetAllList();
            main_gc.DataSource = ds.Tables[0];
            //DataTable dt = new DataTable();//创建表
            //dt.Columns.Add("ljh", typeof(String));
            //dt.Columns.Add("mc", typeof(String));
            //dt.Columns.Add("gdh", typeof(String));
            //dt.Columns.Add("scbh", typeof(String));
            //dt.Columns.Add("cc", typeof(String));
            //dt.Columns.Add("sandsm", typeof(String));
            //dt.Columns.Add("tm", typeof(String));
            //dt.Columns.Add("clbz", typeof(String));
            //dt.Columns.Add("clsj", typeof(String));
            //dt.Rows.Add(new object[] { "00001", "XX零件", "123223", "312312", "1*2*3","xxx.step" ,"3213123131231"});//添加行
            //dt.Rows.Add(new object[] { "00002", "XX零件", "423523", "321122", "2*2*1", "xxx.step", "3213123131232" });
            //dt.Rows.Add(new object[] { "00003", "XX零件", "242123", "441212", "2*3*3", "xxx.step", "3213123131233" });

            //this.main_gc.DataSource = dt;
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Show();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            TestBZFrom tbz = new TestBZFrom();
            tbz.Show();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //TestBZFrom tbz = new TestBZFrom();
            //tbz.Show();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int XH = Convert.ToInt32(gridView1.GetRowCellValue(i, "id"));
                string LJH = gridView1.GetRowCellValue(i, "PN").ToString();
                string NM = gridView1.GetRowCellValue(i, "name").ToString();
                string GDH = gridView1.GetRowCellValue(i, "jobnum").ToString();
                string CSBH = gridView1.GetRowCellValue(i, "ARef").ToString();
                string CC = gridView1.GetRowCellValue(i, "size").ToString();
                string sd = gridView1.GetRowCellValue(i, "sm").ToString();
                string TM = gridView1.GetRowCellValue(i, "Barcode").ToString();
                Maticsoft.BLL.parts use = new Maticsoft.BLL.parts();
                Maticsoft.Model.parts us = new parts()
                {
                    id = XH,
                    PN = LJH,
                    name = NM,
                    jobnum = GDH,
                    ARef = CSBH,
                    size = CC,
                    sm = sd,
                    Barcode = TM,
                };
                use.Update(us);
            }
            MessageBox.Show("修改成功");
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow DR = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Program.gdvid = DR["PN"].ToString();
            QueryFrom qf = new QueryFrom();
            qf.Show();
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            DataRow DR = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Program.gdvid = DR["PN"].ToString();
            //string GDH = gridView1.GetRowCellValue(0, "jobnum").ToString();

            TestBZFrom tbz = new TestBZFrom();
            tbz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void query_bt_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.parts use = new Maticsoft.BLL.parts();
            string sr = string.Format("PN = '{0}'or name = '{1}'or Barcode = '{2}' ", textBoxX_autolj.Text, textBoxX_autolj.Text, textBoxX_autolj.Text);
            DataSet ds = use.GetList(sr);
            main_gc.DataSource = ds.Tables[0];
        }

        private void del_bt_Click(object sender, EventArgs e)
        {
            DataRow DR = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Maticsoft.BLL.parts use = new Maticsoft.BLL.parts();
            use.Delete(Convert.ToInt32(DR["id"]));
            //MessageBox.Show(a["id"].ToString());
            MessageBox.Show("删除成功");
            Maticsoft.BLL.parts usec = new Maticsoft.BLL.parts();
            DataSet ds = usec.GetAllList();
            main_gc.DataSource = ds.Tables[0];
        }

        private void import_bt_Click(object sender, EventArgs e)
        {
            //string filepath = "";
            //OpenFileDialog opf = new OpenFileDialog();
            //if (opf.ShowDialog() == DialogResult.OK)
            //{
            //    filepath = opf.FileName;
            //}
            DataSet ds = new DataSet();
            DataTable dt = null;
            OpenFileDialog sflg = new OpenFileDialog();
            sflg.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            if (sflg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            FileStream fs = new FileStream(sflg.FileName, FileMode.Open, FileAccess.Read);
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook(fs);
            int sheetCount = book.NumberOfSheets;
            for (int sheetIndex = 0; sheetIndex < sheetCount; sheetIndex++)
            {
                string st_name = book.GetSheetName(sheetIndex);               
                NPOI.SS.UserModel.ISheet sheet = book.GetSheetAt(sheetIndex);
                if (sheet == null) continue;

                NPOI.SS.UserModel.IRow row = sheet.GetRow(0);
                if (row == null) continue;

                int firstCellNum = row.FirstCellNum;
                int lastCellNum = row.LastCellNum;
                if (firstCellNum == lastCellNum) continue;

                dt = new DataTable(sheet.SheetName);
                dt.Columns.Add("PN", typeof(string));
                //MessageBox.Show(dt.Columns["bushe_xianshu"].DataType.ToString());
                //dt.Columns.Add("", typeof(int));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("jobnum", typeof(string));
                dt.Columns.Add("ARef", typeof(string));
                dt.Columns.Add("size", typeof(string));
                dt.Columns.Add("sm", typeof(string));
                dt.Columns.Add("Barcode", typeof(string));
                lastCellNum =7;
                for (int i = firstCellNum; i <lastCellNum; i++)
                {
                    dt.Columns.Add(row.GetCell(i).StringCellValue, typeof(string));
                }

                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow newRow = dt.Rows.Add();
                    for (int j =firstCellNum; j < lastCellNum; j++)
                    {
                        newRow[j] = sheet.GetRow(i).GetCell(j).StringCellValue;
                    }
                }
                NPOI.SS.UserModel.IRow row0 = sheet.GetRow(0);
                ds.Tables.Add(dt);
                main_gc.DataSource = ds.Tables[0];
            }
           
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string LJH = gridView1.GetRowCellValue(i, "PN").ToString();
                string mc = gridView1.GetRowCellValue(i, "name").ToString();
                string gdh = gridView1.GetRowCellValue(i, "jobnum").ToString();
                string BH = gridView1.GetRowCellValue(i, "ARef").ToString();
                string cc = gridView1.GetRowCellValue(i, "size").ToString();
                string dsm=gridView1.GetRowCellValue(i, "sm").ToString();
                string tm= gridView1.GetRowCellValue(i, "Barcode").ToString();
                Maticsoft.BLL.parts use = new Maticsoft.BLL.parts();
                Maticsoft.Model.parts us = new parts()
                {
                    PN = LJH,
                    name = mc,
                    jobnum = gdh,
                    ARef=BH,
                    size=cc,
                    sm=dsm,
                    Barcode=tm,

                };
                use.Add(us);
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("已成功导入");
            Maticsoft.BLL.parts pr = new Maticsoft.BLL.parts();
            DataSet ds2 = pr.GetAllList();
            main_gc.DataSource = ds2.Tables[0];
        }

        private void expend_line_bt_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                //string xzh = gridView1.FocusedRowHandle.ToString();                
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                main_gc.ExportToXls(saveFileDialog.FileName, options);  
                //gridControl1.ExportToExcelOld(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

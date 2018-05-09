using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace NepslidingTools
{
    public partial class WorkForm : Form
    {
        public  int comp_type = 0;
        public string comp_name = "";
        public string mode = "";
        public void dealwithcomp(object lingjianhao)
        {
            string lj_num = lingjianhao.ToString();

            // 目前架构这样， 就不用联合查询了。 宁可多查询一部 
            #region 获得零件id
            Maticsoft.BLL.parts parts_bll = new Maticsoft.BLL.parts();
            List<Maticsoft.Model.parts> parts_objs = parts_bll.GetModelList(string.Format(" PN = {0} ", lj_num));
            if (parts_objs.Count == 1)
            {
                Maticsoft.Model.parts part_obj = parts_objs[0];
                this.comp_type = Convert.ToInt32(part_obj.componentId);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("未知零件类型");
                this.Close();
            }
            #endregion

            #region 获得零件名字
            Maticsoft.BLL.component comp_bll = new Maticsoft.BLL.component();
            Maticsoft.Model.component comp_mode = comp_bll.GetModel(comp_type);
            if (comp_mode != null)
            {
                this.comp_name = comp_mode.name;
                this.mode = comp_mode.sm;
            }
            System.Windows.Forms.MessageBox.Show(string.Format("comp_type : == {0}, comp_name : === {1}", this.comp_type, this.comp_name));
            #endregion
        }
    }
}

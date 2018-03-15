using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.cccc.NEP_table
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcheshu.Text))
			{
				strErr+="cheshu格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdunwei.Text))
			{
				strErr+="dunwei格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdanjia.Text))
			{
				strErr+="danjia格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtjine.Text))
			{
				strErr+="jine格式错误！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="Remarks不能为空！\\n";	
			}
			if(this.txtgonyingdanwei.Text.Trim().Length==0)
			{
				strErr+="gonyingdanwei不能为空！\\n";	
			}
			if(this.txtjinshouren.Text.Trim().Length==0)
			{
				strErr+="jinshouren不能为空！\\n";	
			}
			if(this.txtdingdanbianhao.Text.Trim().Length==0)
			{
				strErr+="dingdanbianhao不能为空！\\n";	
			}
			if(this.txtdanjubianhao.Text.Trim().Length==0)
			{
				strErr+="danjubianhao不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlurushijian.Text))
			{
				strErr+="lurushijian格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string name=this.txtname.Text;
			int cheshu=int.Parse(this.txtcheshu.Text);
			int dunwei=int.Parse(this.txtdunwei.Text);
			int danjia=int.Parse(this.txtdanjia.Text);
			int jine=int.Parse(this.txtjine.Text);
			string Remarks=this.txtRemarks.Text;
			string gonyingdanwei=this.txtgonyingdanwei.Text;
			string jinshouren=this.txtjinshouren.Text;
			string dingdanbianhao=this.txtdingdanbianhao.Text;
			string danjubianhao=this.txtdanjubianhao.Text;
			DateTime lurushijian=DateTime.Parse(this.txtlurushijian.Text);

			Maticsoft.Model.cccc.NEP_table model=new Maticsoft.Model.cccc.NEP_table();
			model.name=name;
			model.cheshu=cheshu;
			model.dunwei=dunwei;
			model.danjia=danjia;
			model.jine=jine;
			model.Remarks=Remarks;
			model.gonyingdanwei=gonyingdanwei;
			model.jinshouren=jinshouren;
			model.dingdanbianhao=dingdanbianhao;
			model.danjubianhao=danjubianhao;
			model.lurushijian=lurushijian;

			Maticsoft.BLL.cccc.NEP_table bll=new Maticsoft.BLL.cccc.NEP_table();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

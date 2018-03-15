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
namespace Maticsoft.Web.cccc.xsddan
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtrq.Text))
			{
				strErr+="rq格式错误！\\n";	
			}
			if(this.txtcpmc.Text.Trim().Length==0)
			{
				strErr+="cpmc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcs.Text))
			{
				strErr+="cs格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdwei.Text))
			{
				strErr+="dwei格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdj.Text))
			{
				strErr+="dj格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtjine.Text))
			{
				strErr+="jine格式错误！\\n";	
			}
			if(this.txtdanwei.Text.Trim().Length==0)
			{
				strErr+="danwei不能为空！\\n";	
			}
			if(this.txtjsr.Text.Trim().Length==0)
			{
				strErr+="jsr不能为空！\\n";	
			}
			if(this.txtddbh.Text.Trim().Length==0)
			{
				strErr+="ddbh不能为空！\\n";	
			}
			if(this.txtdjbh.Text.Trim().Length==0)
			{
				strErr+="djbh不能为空！\\n";	
			}
			if(this.txtbz.Text.Trim().Length==0)
			{
				strErr+="bz不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			DateTime rq=DateTime.Parse(this.txtrq.Text);
			string cpmc=this.txtcpmc.Text;
			int cs=int.Parse(this.txtcs.Text);
			int dwei=int.Parse(this.txtdwei.Text);
			int dj=int.Parse(this.txtdj.Text);
			int jine=int.Parse(this.txtjine.Text);
			string danwei=this.txtdanwei.Text;
			string jsr=this.txtjsr.Text;
			string ddbh=this.txtddbh.Text;
			string djbh=this.txtdjbh.Text;
			string bz=this.txtbz.Text;

			Maticsoft.Model.cccc.xsddan model=new Maticsoft.Model.cccc.xsddan();
			model.rq=rq;
			model.cpmc=cpmc;
			model.cs=cs;
			model.dwei=dwei;
			model.dj=dj;
			model.jine=jine;
			model.danwei=danwei;
			model.jsr=jsr;
			model.ddbh=ddbh;
			model.djbh=djbh;
			model.bz=bz;

			Maticsoft.BLL.cccc.xsddan bll=new Maticsoft.BLL.cccc.xsddan();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

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
namespace Maticsoft.Web.cccc.xsdan
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcpmc.Text.Trim().Length==0)
			{
				strErr+="cpmc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcs.Text))
			{
				strErr+="cs格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdunw.Text))
			{
				strErr+="dunw格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdj.Text))
			{
				strErr+="dj格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtje.Text))
			{
				strErr+="je格式错误！\\n";	
			}
			if(this.txtbz.Text.Trim().Length==0)
			{
				strErr+="bz不能为空！\\n";	
			}
			if(this.txtdanw.Text.Trim().Length==0)
			{
				strErr+="danw不能为空！\\n";	
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
			if(!PageValidate.IsDateTime(txtshijian.Text))
			{
				strErr+="shijian格式错误！\\n";	
			}
			if(this.txtskfs.Text.Trim().Length==0)
			{
				strErr+="skfs不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtskjine.Text))
			{
				strErr+="skjine格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtye.Text))
			{
				strErr+="ye格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string cpmc=this.txtcpmc.Text;
			int cs=int.Parse(this.txtcs.Text);
			int dunw=int.Parse(this.txtdunw.Text);
			int dj=int.Parse(this.txtdj.Text);
			int je=int.Parse(this.txtje.Text);
			string bz=this.txtbz.Text;
			string danw=this.txtdanw.Text;
			string jsr=this.txtjsr.Text;
			string ddbh=this.txtddbh.Text;
			string djbh=this.txtdjbh.Text;
			DateTime shijian=DateTime.Parse(this.txtshijian.Text);
			string skfs=this.txtskfs.Text;
			int skjine=int.Parse(this.txtskjine.Text);
			int ye=int.Parse(this.txtye.Text);

			Maticsoft.Model.cccc.xsdan model=new Maticsoft.Model.cccc.xsdan();
			model.cpmc=cpmc;
			model.cs=cs;
			model.dunw=dunw;
			model.dj=dj;
			model.je=je;
			model.bz=bz;
			model.danw=danw;
			model.jsr=jsr;
			model.ddbh=ddbh;
			model.djbh=djbh;
			model.shijian=shijian;
			model.skfs=skfs;
			model.skjine=skjine;
			model.ye=ye;

			Maticsoft.BLL.cccc.xsdan bll=new Maticsoft.BLL.cccc.xsdan();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

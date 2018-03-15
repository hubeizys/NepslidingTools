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
namespace Maticsoft.Web.cccc.fuk_dan
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtfkfs.Text.Trim().Length==0)
			{
				strErr+="fkfs不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtfkjine.Text))
			{
				strErr+="fkjine格式错误！\\n";	
			}
			if(this.txtdxjine.Text.Trim().Length==0)
			{
				strErr+="dxjine不能为空！\\n";	
			}
			if(this.txtbz.Text.Trim().Length==0)
			{
				strErr+="bz不能为空！\\n";	
			}
			if(this.txtskdw.Text.Trim().Length==0)
			{
				strErr+="skdw不能为空！\\n";	
			}
			if(this.txtjsr.Text.Trim().Length==0)
			{
				strErr+="jsr不能为空！\\n";	
			}
			if(this.txtdjbh.Text.Trim().Length==0)
			{
				strErr+="djbh不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtshijian.Text))
			{
				strErr+="shijian格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string fkfs=this.txtfkfs.Text;
			int fkjine=int.Parse(this.txtfkjine.Text);
			string dxjine=this.txtdxjine.Text;
			string bz=this.txtbz.Text;
			string skdw=this.txtskdw.Text;
			string jsr=this.txtjsr.Text;
			string djbh=this.txtdjbh.Text;
			DateTime shijian=DateTime.Parse(this.txtshijian.Text);

			Maticsoft.Model.cccc.fuk_dan model=new Maticsoft.Model.cccc.fuk_dan();
			model.fkfs=fkfs;
			model.fkjine=fkjine;
			model.dxjine=dxjine;
			model.bz=bz;
			model.skdw=skdw;
			model.jsr=jsr;
			model.djbh=djbh;
			model.shijian=shijian;

			Maticsoft.BLL.cccc.fuk_dan bll=new Maticsoft.BLL.cccc.fuk_dan();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

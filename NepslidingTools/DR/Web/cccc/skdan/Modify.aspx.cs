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
namespace Maticsoft.Web.cccc.skdan
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.cccc.skdan bll=new Maticsoft.BLL.cccc.skdan();
		Maticsoft.Model.cccc.skdan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtskfs.Text=model.skfs;
		this.txtskjine.Text=model.skjine.ToString();
		this.txtdxjine.Text=model.dxjine;
		this.txtbeizhu.Text=model.beizhu;
		this.txtfkdw.Text=model.fkdw;
		this.txtjsr.Text=model.jsr;
		this.txtdjbh.Text=model.djbh;
		this.txtshijian.Text=model.shijian.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtskfs.Text.Trim().Length==0)
			{
				strErr+="skfs不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtskjine.Text))
			{
				strErr+="skjine格式错误！\\n";	
			}
			if(this.txtdxjine.Text.Trim().Length==0)
			{
				strErr+="dxjine不能为空！\\n";	
			}
			if(this.txtbeizhu.Text.Trim().Length==0)
			{
				strErr+="beizhu不能为空！\\n";	
			}
			if(this.txtfkdw.Text.Trim().Length==0)
			{
				strErr+="fkdw不能为空！\\n";	
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
			int id=int.Parse(this.lblid.Text);
			string skfs=this.txtskfs.Text;
			int skjine=int.Parse(this.txtskjine.Text);
			string dxjine=this.txtdxjine.Text;
			string beizhu=this.txtbeizhu.Text;
			string fkdw=this.txtfkdw.Text;
			string jsr=this.txtjsr.Text;
			string djbh=this.txtdjbh.Text;
			DateTime shijian=DateTime.Parse(this.txtshijian.Text);


			Maticsoft.Model.cccc.skdan model=new Maticsoft.Model.cccc.skdan();
			model.id=id;
			model.skfs=skfs;
			model.skjine=skjine;
			model.dxjine=dxjine;
			model.beizhu=beizhu;
			model.fkdw=fkdw;
			model.jsr=jsr;
			model.djbh=djbh;
			model.shijian=shijian;

			Maticsoft.BLL.cccc.skdan bll=new Maticsoft.BLL.cccc.skdan();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

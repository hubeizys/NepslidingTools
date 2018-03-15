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
		Maticsoft.BLL.cccc.fuk_dan bll=new Maticsoft.BLL.cccc.fuk_dan();
		Maticsoft.Model.cccc.fuk_dan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtfkfs.Text=model.fkfs;
		this.txtfkjine.Text=model.fkjine.ToString();
		this.txtdxjine.Text=model.dxjine;
		this.txtbz.Text=model.bz;
		this.txtskdw.Text=model.skdw;
		this.txtjsr.Text=model.jsr;
		this.txtdjbh.Text=model.djbh;
		this.txtshijian.Text=model.shijian.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int id=int.Parse(this.lblid.Text);
			string fkfs=this.txtfkfs.Text;
			int fkjine=int.Parse(this.txtfkjine.Text);
			string dxjine=this.txtdxjine.Text;
			string bz=this.txtbz.Text;
			string skdw=this.txtskdw.Text;
			string jsr=this.txtjsr.Text;
			string djbh=this.txtdjbh.Text;
			DateTime shijian=DateTime.Parse(this.txtshijian.Text);


			Maticsoft.Model.cccc.fuk_dan model=new Maticsoft.Model.cccc.fuk_dan();
			model.id=id;
			model.fkfs=fkfs;
			model.fkjine=fkjine;
			model.dxjine=dxjine;
			model.bz=bz;
			model.skdw=skdw;
			model.jsr=jsr;
			model.djbh=djbh;
			model.shijian=shijian;

			Maticsoft.BLL.cccc.fuk_dan bll=new Maticsoft.BLL.cccc.fuk_dan();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

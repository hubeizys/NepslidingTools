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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int xh=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(xh);
				}
			}
		}
			
	private void ShowInfo(int xh)
	{
		Maticsoft.BLL.cccc.xsddan bll=new Maticsoft.BLL.cccc.xsddan();
		Maticsoft.Model.cccc.xsddan model=bll.GetModel(xh);
		this.lblxh.Text=model.xh.ToString();
		this.txtrq.Text=model.rq.ToString();
		this.txtcpmc.Text=model.cpmc;
		this.txtcs.Text=model.cs.ToString();
		this.txtdwei.Text=model.dwei.ToString();
		this.txtdj.Text=model.dj.ToString();
		this.txtjine.Text=model.jine.ToString();
		this.txtdanwei.Text=model.danwei;
		this.txtjsr.Text=model.jsr;
		this.txtddbh.Text=model.ddbh;
		this.txtdjbh.Text=model.djbh;
		this.txtbz.Text=model.bz;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int xh=int.Parse(this.lblxh.Text);
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
			model.xh=xh;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

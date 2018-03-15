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
namespace Maticsoft.Web.cccc.nep
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
		Maticsoft.BLL.cccc.nep bll=new Maticsoft.BLL.cccc.nep();
		Maticsoft.Model.cccc.nep model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtcpmc.Text=model.cpmc;
		this.txtcs.Text=model.cs.ToString();
		this.txtssdw.Text=model.ssdw.ToString();
		this.txtkfdw.Text=model.kfdw.ToString();
		this.txtdc.Text=model.dc.ToString();
		this.txtdj.Text=model.dj.ToString();
		this.txtje.Text=model.je.ToString();
		this.txtbz.Text=model.bz;
		this.txtgydw.Text=model.gydw;
		this.txtjsr.Text=model.jsr;
		this.txtsj.Text=model.sj.ToString();
		this.txtddbh.Text=model.ddbh;
		this.txtdjbh.Text=model.djbh;
		this.txtskfs.Text=model.skfs;
		this.txtfkjine.Text=model.fkjine.ToString();
		this.txtyue.Text=model.yue.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			if(!PageValidate.IsNumber(txtssdw.Text))
			{
				strErr+="ssdw格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtkfdw.Text))
			{
				strErr+="kfdw格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdc.Text))
			{
				strErr+="dc格式错误！\\n";	
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
			if(this.txtgydw.Text.Trim().Length==0)
			{
				strErr+="gydw不能为空！\\n";	
			}
			if(this.txtjsr.Text.Trim().Length==0)
			{
				strErr+="jsr不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsj.Text))
			{
				strErr+="sj格式错误！\\n";	
			}
			if(this.txtddbh.Text.Trim().Length==0)
			{
				strErr+="ddbh不能为空！\\n";	
			}
			if(this.txtdjbh.Text.Trim().Length==0)
			{
				strErr+="djbh不能为空！\\n";	
			}
			if(this.txtskfs.Text.Trim().Length==0)
			{
				strErr+="skfs不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtfkjine.Text))
			{
				strErr+="fkjine格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtyue.Text))
			{
				strErr+="yue格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string cpmc=this.txtcpmc.Text;
			int cs=int.Parse(this.txtcs.Text);
			int ssdw=int.Parse(this.txtssdw.Text);
			int kfdw=int.Parse(this.txtkfdw.Text);
			int dc=int.Parse(this.txtdc.Text);
			int dj=int.Parse(this.txtdj.Text);
			int je=int.Parse(this.txtje.Text);
			string bz=this.txtbz.Text;
			string gydw=this.txtgydw.Text;
			string jsr=this.txtjsr.Text;
			DateTime sj=DateTime.Parse(this.txtsj.Text);
			string ddbh=this.txtddbh.Text;
			string djbh=this.txtdjbh.Text;
			string skfs=this.txtskfs.Text;
			int fkjine=int.Parse(this.txtfkjine.Text);
			int yue=int.Parse(this.txtyue.Text);


			Maticsoft.Model.cccc.nep model=new Maticsoft.Model.cccc.nep();
			model.id=id;
			model.cpmc=cpmc;
			model.cs=cs;
			model.ssdw=ssdw;
			model.kfdw=kfdw;
			model.dc=dc;
			model.dj=dj;
			model.je=je;
			model.bz=bz;
			model.gydw=gydw;
			model.jsr=jsr;
			model.sj=sj;
			model.ddbh=ddbh;
			model.djbh=djbh;
			model.skfs=skfs;
			model.fkjine=fkjine;
			model.yue=yue;

			Maticsoft.BLL.cccc.nep bll=new Maticsoft.BLL.cccc.nep();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

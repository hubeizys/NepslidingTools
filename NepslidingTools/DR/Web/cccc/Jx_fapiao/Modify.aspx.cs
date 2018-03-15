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
namespace Maticsoft.Web.cccc.Jx_fapiao
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
		Maticsoft.BLL.cccc.Jx_fapiao bll=new Maticsoft.BLL.cccc.Jx_fapiao();
		Maticsoft.Model.cccc.Jx_fapiao model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtcgdbhao.Text=model.cgdbhao;
		this.txtkaipr.Text=model.kaipr;
		this.txtfpneixing.Text=model.fpneixing;
		this.txtjbanr.Text=model.jbanr;
		this.txtcal.Text=model.cal.ToString();
		this.txtfphao.Text=model.fphao.ToString();
		this.txtriqi.Text=model.riqi.ToString();
		this.txtkpdanw.Text=model.kpdanw;
		this.txtkpdunwei.Text=model.kpdunwei.ToString();
		this.txtkpjine.Text=model.kpjine.ToString();
		this.txtshuinv.Text=model.shuinv;
		this.txtshuie.Text=model.shuie.ToString();
		this.txtbz.Text=model.bz;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcgdbhao.Text.Trim().Length==0)
			{
				strErr+="cgdbhao不能为空！\\n";	
			}
			if(this.txtkaipr.Text.Trim().Length==0)
			{
				strErr+="kaipr不能为空！\\n";	
			}
			if(this.txtfpneixing.Text.Trim().Length==0)
			{
				strErr+="fpneixing不能为空！\\n";	
			}
			if(this.txtjbanr.Text.Trim().Length==0)
			{
				strErr+="jbanr不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcal.Text))
			{
				strErr+="cal格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfphao.Text))
			{
				strErr+="fphao格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtriqi.Text))
			{
				strErr+="riqi格式错误！\\n";	
			}
			if(this.txtkpdanw.Text.Trim().Length==0)
			{
				strErr+="kpdanw不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtkpdunwei.Text))
			{
				strErr+="kpdunwei格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtkpjine.Text))
			{
				strErr+="kpjine格式错误！\\n";	
			}
			if(this.txtshuinv.Text.Trim().Length==0)
			{
				strErr+="shuinv不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtshuie.Text))
			{
				strErr+="shuie格式错误！\\n";	
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
			int id=int.Parse(this.lblid.Text);
			string cgdbhao=this.txtcgdbhao.Text;
			string kaipr=this.txtkaipr.Text;
			string fpneixing=this.txtfpneixing.Text;
			string jbanr=this.txtjbanr.Text;
			int cal=int.Parse(this.txtcal.Text);
			int fphao=int.Parse(this.txtfphao.Text);
			DateTime riqi=DateTime.Parse(this.txtriqi.Text);
			string kpdanw=this.txtkpdanw.Text;
			int kpdunwei=int.Parse(this.txtkpdunwei.Text);
			int kpjine=int.Parse(this.txtkpjine.Text);
			string shuinv=this.txtshuinv.Text;
			int shuie=int.Parse(this.txtshuie.Text);
			string bz=this.txtbz.Text;


			Maticsoft.Model.cccc.Jx_fapiao model=new Maticsoft.Model.cccc.Jx_fapiao();
			model.id=id;
			model.cgdbhao=cgdbhao;
			model.kaipr=kaipr;
			model.fpneixing=fpneixing;
			model.jbanr=jbanr;
			model.cal=cal;
			model.fphao=fphao;
			model.riqi=riqi;
			model.kpdanw=kpdanw;
			model.kpdunwei=kpdunwei;
			model.kpjine=kpjine;
			model.shuinv=shuinv;
			model.shuie=shuie;
			model.bz=bz;

			Maticsoft.BLL.cccc.Jx_fapiao bll=new Maticsoft.BLL.cccc.Jx_fapiao();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

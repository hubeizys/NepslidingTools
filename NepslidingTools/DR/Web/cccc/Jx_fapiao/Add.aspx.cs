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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

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
namespace Maticsoft.Web.cccc.xx_fapiao
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtxsdbhao.Text.Trim().Length==0)
			{
				strErr+="xsdbhao不能为空！\\n";	
			}
			if(this.txtkpren.Text.Trim().Length==0)
			{
				strErr+="kpren不能为空！\\n";	
			}
			if(this.txtfpnxing.Text.Trim().Length==0)
			{
				strErr+="fpnxing不能为空！\\n";	
			}
			if(this.txtjbanr.Text.Trim().Length==0)
			{
				strErr+="jbanr不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtlxr.Text))
			{
				strErr+="lxr格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtfph.Text))
			{
				strErr+="fph格式错误！\\n";	
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
			string xsdbhao=this.txtxsdbhao.Text;
			string kpren=this.txtkpren.Text;
			string fpnxing=this.txtfpnxing.Text;
			string jbanr=this.txtjbanr.Text;
			int lxr=int.Parse(this.txtlxr.Text);
			int fph=int.Parse(this.txtfph.Text);
			DateTime riqi=DateTime.Parse(this.txtriqi.Text);
			string kpdanw=this.txtkpdanw.Text;
			int kpdunwei=int.Parse(this.txtkpdunwei.Text);
			int kpjine=int.Parse(this.txtkpjine.Text);
			string shuinv=this.txtshuinv.Text;
			int shuie=int.Parse(this.txtshuie.Text);
			string bz=this.txtbz.Text;

			Maticsoft.Model.cccc.xx_fapiao model=new Maticsoft.Model.cccc.xx_fapiao();
			model.xsdbhao=xsdbhao;
			model.kpren=kpren;
			model.fpnxing=fpnxing;
			model.jbanr=jbanr;
			model.lxr=lxr;
			model.fph=fph;
			model.riqi=riqi;
			model.kpdanw=kpdanw;
			model.kpdunwei=kpdunwei;
			model.kpjine=kpjine;
			model.shuinv=shuinv;
			model.shuie=shuie;
			model.bz=bz;

			Maticsoft.BLL.cccc.xx_fapiao bll=new Maticsoft.BLL.cccc.xx_fapiao();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

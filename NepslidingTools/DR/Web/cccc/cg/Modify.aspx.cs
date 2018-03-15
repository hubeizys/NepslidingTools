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
namespace Maticsoft.Web.cccc.cg
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
			
	private void ShowInfo()
	{
		Maticsoft.BLL.cccc.cg bll=new Maticsoft.BLL.cccc.cg();
		Maticsoft.Model.cccc.cg model=bll.GetModel();
		this.txtXUHAO.Text=model.XUHAO;
		this.txtRIQI.Text=model.RIQI;
		this.txtMINGCHEN.Text=model.MINGCHEN;
		this.txtCHESHU.Text=model.CHESHU;
		this.txtDUNWEI.Text=model.DUNWEI;
		this.txtDANJIA.Text=model.DANJIA;
		this.txtJINE.Text=model.JINE;
		this.txtBEIZHU.Text=model.BEIZHU;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtXUHAO.Text.Trim().Length==0)
			{
				strErr+="XUHAO不能为空！\\n";	
			}
			if(this.txtRIQI.Text.Trim().Length==0)
			{
				strErr+="RIQI不能为空！\\n";	
			}
			if(this.txtMINGCHEN.Text.Trim().Length==0)
			{
				strErr+="MINGCHEN不能为空！\\n";	
			}
			if(this.txtCHESHU.Text.Trim().Length==0)
			{
				strErr+="CHESHU不能为空！\\n";	
			}
			if(this.txtDUNWEI.Text.Trim().Length==0)
			{
				strErr+="DUNWEI不能为空！\\n";	
			}
			if(this.txtDANJIA.Text.Trim().Length==0)
			{
				strErr+="DANJIA不能为空！\\n";	
			}
			if(this.txtJINE.Text.Trim().Length==0)
			{
				strErr+="JINE不能为空！\\n";	
			}
			if(this.txtBEIZHU.Text.Trim().Length==0)
			{
				strErr+="BEIZHU不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string XUHAO=this.txtXUHAO.Text;
			string RIQI=this.txtRIQI.Text;
			string MINGCHEN=this.txtMINGCHEN.Text;
			string CHESHU=this.txtCHESHU.Text;
			string DUNWEI=this.txtDUNWEI.Text;
			string DANJIA=this.txtDANJIA.Text;
			string JINE=this.txtJINE.Text;
			string BEIZHU=this.txtBEIZHU.Text;


			Maticsoft.Model.cccc.cg model=new Maticsoft.Model.cccc.cg();
			model.XUHAO=XUHAO;
			model.RIQI=RIQI;
			model.MINGCHEN=MINGCHEN;
			model.CHESHU=CHESHU;
			model.DUNWEI=DUNWEI;
			model.DANJIA=DANJIA;
			model.JINE=JINE;
			model.BEIZHU=BEIZHU;

			Maticsoft.BLL.cccc.cg bll=new Maticsoft.BLL.cccc.cg();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

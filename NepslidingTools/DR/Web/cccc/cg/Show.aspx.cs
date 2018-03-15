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
namespace Maticsoft.Web.cccc.cg
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblXUHAO.Text=model.XUHAO;
		this.lblRIQI.Text=model.RIQI;
		this.lblMINGCHEN.Text=model.MINGCHEN;
		this.lblCHESHU.Text=model.CHESHU;
		this.lblDUNWEI.Text=model.DUNWEI;
		this.lblDANJIA.Text=model.DANJIA;
		this.lblJINE.Text=model.JINE;
		this.lblBEIZHU.Text=model.BEIZHU;

	}


    }
}

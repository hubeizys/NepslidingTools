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
namespace Maticsoft.Web.cccc.Jx_fapiao
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.cccc.Jx_fapiao bll=new Maticsoft.BLL.cccc.Jx_fapiao();
		Maticsoft.Model.cccc.Jx_fapiao model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblcgdbhao.Text=model.cgdbhao;
		this.lblkaipr.Text=model.kaipr;
		this.lblfpneixing.Text=model.fpneixing;
		this.lbljbanr.Text=model.jbanr;
		this.lblcal.Text=model.cal.ToString();
		this.lblfphao.Text=model.fphao.ToString();
		this.lblriqi.Text=model.riqi.ToString();
		this.lblkpdanw.Text=model.kpdanw;
		this.lblkpdunwei.Text=model.kpdunwei.ToString();
		this.lblkpjine.Text=model.kpjine.ToString();
		this.lblshuinv.Text=model.shuinv;
		this.lblshuie.Text=model.shuie.ToString();
		this.lblbz.Text=model.bz;

	}


    }
}

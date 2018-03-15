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
namespace Maticsoft.Web.cccc.nep
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
		Maticsoft.BLL.cccc.nep bll=new Maticsoft.BLL.cccc.nep();
		Maticsoft.Model.cccc.nep model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblcpmc.Text=model.cpmc;
		this.lblcs.Text=model.cs.ToString();
		this.lblssdw.Text=model.ssdw.ToString();
		this.lblkfdw.Text=model.kfdw.ToString();
		this.lbldc.Text=model.dc.ToString();
		this.lbldj.Text=model.dj.ToString();
		this.lblje.Text=model.je.ToString();
		this.lblbz.Text=model.bz;
		this.lblgydw.Text=model.gydw;
		this.lbljsr.Text=model.jsr;
		this.lblsj.Text=model.sj.ToString();
		this.lblddbh.Text=model.ddbh;
		this.lbldjbh.Text=model.djbh;
		this.lblskfs.Text=model.skfs;
		this.lblfkjine.Text=model.fkjine.ToString();
		this.lblyue.Text=model.yue.ToString();

	}


    }
}

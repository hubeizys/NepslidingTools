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
namespace Maticsoft.Web.cccc.xsdan
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
		Maticsoft.BLL.cccc.xsdan bll=new Maticsoft.BLL.cccc.xsdan();
		Maticsoft.Model.cccc.xsdan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblcpmc.Text=model.cpmc;
		this.lblcs.Text=model.cs.ToString();
		this.lbldunw.Text=model.dunw.ToString();
		this.lbldj.Text=model.dj.ToString();
		this.lblje.Text=model.je.ToString();
		this.lblbz.Text=model.bz;
		this.lbldanw.Text=model.danw;
		this.lbljsr.Text=model.jsr;
		this.lblddbh.Text=model.ddbh;
		this.lbldjbh.Text=model.djbh;
		this.lblshijian.Text=model.shijian.ToString();
		this.lblskfs.Text=model.skfs;
		this.lblskjine.Text=model.skjine.ToString();
		this.lblye.Text=model.ye.ToString();

	}


    }
}

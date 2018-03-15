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
namespace Maticsoft.Web.cccc.xsddan
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
					int xh=(Convert.ToInt32(strid));
					ShowInfo(xh);
				}
			}
		}
		
	private void ShowInfo(int xh)
	{
		Maticsoft.BLL.cccc.xsddan bll=new Maticsoft.BLL.cccc.xsddan();
		Maticsoft.Model.cccc.xsddan model=bll.GetModel(xh);
		this.lblxh.Text=model.xh.ToString();
		this.lblrq.Text=model.rq.ToString();
		this.lblcpmc.Text=model.cpmc;
		this.lblcs.Text=model.cs.ToString();
		this.lbldwei.Text=model.dwei.ToString();
		this.lbldj.Text=model.dj.ToString();
		this.lbljine.Text=model.jine.ToString();
		this.lbldanwei.Text=model.danwei;
		this.lbljsr.Text=model.jsr;
		this.lblddbh.Text=model.ddbh;
		this.lbldjbh.Text=model.djbh;
		this.lblbz.Text=model.bz;

	}


    }
}

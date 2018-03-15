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
namespace Maticsoft.Web.demand
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
		Maticsoft.BLL.demand bll=new Maticsoft.BLL.demand();
		Maticsoft.Model.demand model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblPN.Text=model.PN;
		this.lblmeasureb.Text=model.measureb;
		this.lbltestboard.Text=model.testboard;
		this.lbltime.Text=model.time.ToString();
		this.lblstep1.Text=model.step1;
		this.lblstep2.Text=model.step2;
		this.lblstep3.Text=model.step3;
		this.lblresult.Text=model.result;

	}


    }
}

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
namespace Maticsoft.Web.test
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
		Maticsoft.BLL.test bll=new Maticsoft.BLL.test();
		Maticsoft.Model.test model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblmeasureb.Text=model.measureb;
		this.lbltime.Text=model.time.ToString();
		this.lblstep1.Text=model.step1;
		this.lblstep2.Text=model.step2;
		this.lblstep3.Text=model.step3;
		this.lblstep4.Text=model.step4;
		this.lblstep5.Text=model.step5;
		this.lblOKorNG.Text=model.OKorNG;

	}


    }
}

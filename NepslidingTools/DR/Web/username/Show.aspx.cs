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
namespace Maticsoft.Web.username
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
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		Maticsoft.BLL.username bll=new Maticsoft.BLL.username();
		Maticsoft.Model.username model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblusername.Text=model.username;
		this.lbladdtime.Text=model.addtime.ToString();
		this.lblpassword.Text=model.password;
		this.lblpower.Text=model.power;

	}


    }
}

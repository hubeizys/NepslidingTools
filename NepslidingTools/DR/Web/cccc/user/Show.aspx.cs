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
namespace Maticsoft.Web.cccc.user
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
					int username=(Convert.ToInt32(strid));
					ShowInfo(username);
				}
			}
		}
		
	private void ShowInfo(int username)
	{
		Maticsoft.BLL.cccc.user bll=new Maticsoft.BLL.cccc.user();
		Maticsoft.Model.cccc.user model=bll.GetModel(username);
		this.lblusername.Text=model.username.ToString();
		this.lblpassword.Text=model.password;
		this.lblsex.Text=model.sex;
		this.lblage.Text=model.age.ToString();
		this.lblheig.Text=model.heig.ToString();
		this.lblweight.Text=model.weight.ToString();
		this.lblbeizhu.Text=model.beizhu;

	}


    }
}

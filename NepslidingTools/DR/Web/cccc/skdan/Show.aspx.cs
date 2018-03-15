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
namespace Maticsoft.Web.cccc.skdan
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
		Maticsoft.BLL.cccc.skdan bll=new Maticsoft.BLL.cccc.skdan();
		Maticsoft.Model.cccc.skdan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblskfs.Text=model.skfs;
		this.lblskjine.Text=model.skjine.ToString();
		this.lbldxjine.Text=model.dxjine;
		this.lblbeizhu.Text=model.beizhu;
		this.lblfkdw.Text=model.fkdw;
		this.lbljsr.Text=model.jsr;
		this.lbldjbh.Text=model.djbh;
		this.lblshijian.Text=model.shijian.ToString();

	}


    }
}

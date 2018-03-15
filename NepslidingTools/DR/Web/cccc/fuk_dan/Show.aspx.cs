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
namespace Maticsoft.Web.cccc.fuk_dan
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
		Maticsoft.BLL.cccc.fuk_dan bll=new Maticsoft.BLL.cccc.fuk_dan();
		Maticsoft.Model.cccc.fuk_dan model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblfkfs.Text=model.fkfs;
		this.lblfkjine.Text=model.fkjine.ToString();
		this.lbldxjine.Text=model.dxjine;
		this.lblbz.Text=model.bz;
		this.lblskdw.Text=model.skdw;
		this.lbljsr.Text=model.jsr;
		this.lbldjbh.Text=model.djbh;
		this.lblshijian.Text=model.shijian.ToString();

	}


    }
}

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
namespace Maticsoft.Web.cccc.NEP_table
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
		Maticsoft.BLL.cccc.NEP_table bll=new Maticsoft.BLL.cccc.NEP_table();
		Maticsoft.Model.cccc.NEP_table model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblname.Text=model.name;
		this.lblcheshu.Text=model.cheshu.ToString();
		this.lbldunwei.Text=model.dunwei.ToString();
		this.lbldanjia.Text=model.danjia.ToString();
		this.lbljine.Text=model.jine.ToString();
		this.lblRemarks.Text=model.Remarks;
		this.lblgonyingdanwei.Text=model.gonyingdanwei;
		this.lbljinshouren.Text=model.jinshouren;
		this.lbldingdanbianhao.Text=model.dingdanbianhao;
		this.lbldanjubianhao.Text=model.danjubianhao;
		this.lbllurushijian.Text=model.lurushijian.ToString();

	}


    }
}

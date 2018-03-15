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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.cccc.danweixinxi
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		Maticsoft.BLL.cccc.danweixinxi bll=new Maticsoft.BLL.cccc.danweixinxi();
		Maticsoft.Model.cccc.danweixinxi model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtdanwei.Text=model.danwei;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtdanwei.Text.Trim().Length==0)
			{
				strErr+="danwei不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string danwei=this.txtdanwei.Text;


			Maticsoft.Model.cccc.danweixinxi model=new Maticsoft.Model.cccc.danweixinxi();
			model.id=id;
			model.danwei=danwei;

			Maticsoft.BLL.cccc.danweixinxi bll=new Maticsoft.BLL.cccc.danweixinxi();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

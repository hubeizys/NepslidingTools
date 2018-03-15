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
namespace Maticsoft.Web.measures
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
		Maticsoft.BLL.measures bll=new Maticsoft.BLL.measures();
		Maticsoft.Model.measures model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtstep.Text=model.step;
		this.txt Tools.Text=model. Tools;
		this.txtposition.Text=model.position;
		this.txtstandardv.Text=model.standardv;
		this.txtup.Text=model.up;
		this.txtdown.Text=model.down;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtstep.Text.Trim().Length==0)
			{
				strErr+="step不能为空！\\n";	
			}
			if(this.txt Tools.Text.Trim().Length==0)
			{
				strErr+=" Tools不能为空！\\n";	
			}
			if(this.txtposition.Text.Trim().Length==0)
			{
				strErr+="position不能为空！\\n";	
			}
			if(this.txtstandardv.Text.Trim().Length==0)
			{
				strErr+="standardv不能为空！\\n";	
			}
			if(this.txtup.Text.Trim().Length==0)
			{
				strErr+="up不能为空！\\n";	
			}
			if(this.txtdown.Text.Trim().Length==0)
			{
				strErr+="down不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string step=this.txtstep.Text;
			string  Tools=this.txt Tools.Text;
			string position=this.txtposition.Text;
			string standardv=this.txtstandardv.Text;
			string up=this.txtup.Text;
			string down=this.txtdown.Text;


			Maticsoft.Model.measures model=new Maticsoft.Model.measures();
			model.id=id;
			model.step=step;
			model. Tools= Tools;
			model.position=position;
			model.standardv=standardv;
			model.up=up;
			model.down=down;

			Maticsoft.BLL.measures bll=new Maticsoft.BLL.measures();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

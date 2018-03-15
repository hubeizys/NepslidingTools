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
namespace Maticsoft.Web.demand
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
		Maticsoft.BLL.demand bll=new Maticsoft.BLL.demand();
		Maticsoft.Model.demand model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtPN.Text=model.PN;
		this.txtmeasureb.Text=model.measureb;
		this.txttestboard.Text=model.testboard;
		this.txttime.Text=model.time.ToString();
		this.txtstep1.Text=model.step1;
		this.txtstep2.Text=model.step2;
		this.txtstep3.Text=model.step3;
		this.txtresult.Text=model.result;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPN.Text.Trim().Length==0)
			{
				strErr+="PN不能为空！\\n";	
			}
			if(this.txtmeasureb.Text.Trim().Length==0)
			{
				strErr+="measureb不能为空！\\n";	
			}
			if(this.txttestboard.Text.Trim().Length==0)
			{
				strErr+="testboard不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txttime.Text))
			{
				strErr+="time格式错误！\\n";	
			}
			if(this.txtstep1.Text.Trim().Length==0)
			{
				strErr+="step1不能为空！\\n";	
			}
			if(this.txtstep2.Text.Trim().Length==0)
			{
				strErr+="step2不能为空！\\n";	
			}
			if(this.txtstep3.Text.Trim().Length==0)
			{
				strErr+="step3不能为空！\\n";	
			}
			if(this.txtresult.Text.Trim().Length==0)
			{
				strErr+="result不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string PN=this.txtPN.Text;
			string measureb=this.txtmeasureb.Text;
			string testboard=this.txttestboard.Text;
			DateTime time=DateTime.Parse(this.txttime.Text);
			string step1=this.txtstep1.Text;
			string step2=this.txtstep2.Text;
			string step3=this.txtstep3.Text;
			string result=this.txtresult.Text;


			Maticsoft.Model.demand model=new Maticsoft.Model.demand();
			model.id=id;
			model.PN=PN;
			model.measureb=measureb;
			model.testboard=testboard;
			model.time=time;
			model.step1=step1;
			model.step2=step2;
			model.step3=step3;
			model.result=result;

			Maticsoft.BLL.demand bll=new Maticsoft.BLL.demand();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

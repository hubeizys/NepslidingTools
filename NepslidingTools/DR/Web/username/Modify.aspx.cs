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
namespace Maticsoft.Web.username
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		Maticsoft.BLL.username bll=new Maticsoft.BLL.username();
		Maticsoft.Model.username model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtusername.Text=model.username;
		this.txtaddtime.Text=model.addtime.ToString();
		this.txtpassword.Text=model.password;
		this.txtpower.Text=model.power;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaddtime.Text))
			{
				strErr+="addtime格式错误！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(this.txtpower.Text.Trim().Length==0)
			{
				strErr+="power不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string username=this.txtusername.Text;
			DateTime addtime=DateTime.Parse(this.txtaddtime.Text);
			string password=this.txtpassword.Text;
			string power=this.txtpower.Text;


			Maticsoft.Model.username model=new Maticsoft.Model.username();
			model.ID=ID;
			model.username=username;
			model.addtime=addtime;
			model.password=password;
			model.power=power;

			Maticsoft.BLL.username bll=new Maticsoft.BLL.username();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

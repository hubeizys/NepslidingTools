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
namespace Maticsoft.Web.cccc.user
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(this.txtsex.Text.Trim().Length==0)
			{
				strErr+="sex不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtage.Text))
			{
				strErr+="age格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtheig.Text))
			{
				strErr+="heig格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtweight.Text))
			{
				strErr+="weight格式错误！\\n";	
			}
			if(this.txtbeizhu.Text.Trim().Length==0)
			{
				strErr+="beizhu不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string password=this.txtpassword.Text;
			string sex=this.txtsex.Text;
			int age=int.Parse(this.txtage.Text);
			int heig=int.Parse(this.txtheig.Text);
			int weight=int.Parse(this.txtweight.Text);
			string beizhu=this.txtbeizhu.Text;

			Maticsoft.Model.cccc.user model=new Maticsoft.Model.cccc.user();
			model.password=password;
			model.sex=sex;
			model.age=age;
			model.heig=heig;
			model.weight=weight;
			model.beizhu=beizhu;

			Maticsoft.BLL.cccc.user bll=new Maticsoft.BLL.cccc.user();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

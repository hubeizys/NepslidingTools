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
namespace Maticsoft.Web.parts
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPN.Text.Trim().Length==0)
			{
				strErr+="PN不能为空！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txtjobnum.Text.Trim().Length==0)
			{
				strErr+="jobnum不能为空！\\n";	
			}
			if(this.txtARef.Text.Trim().Length==0)
			{
				strErr+="ARef不能为空！\\n";	
			}
			if(this.txtsize.Text.Trim().Length==0)
			{
				strErr+="size不能为空！\\n";	
			}
			if(this.txtsm.Text.Trim().Length==0)
			{
				strErr+="sm不能为空！\\n";	
			}
			if(this.txtBarcode.Text.Trim().Length==0)
			{
				strErr+="Barcode不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string PN=this.txtPN.Text;
			string name=this.txtname.Text;
			string jobnum=this.txtjobnum.Text;
			string ARef=this.txtARef.Text;
			string size=this.txtsize.Text;
			string sm=this.txtsm.Text;
			string Barcode=this.txtBarcode.Text;

			Maticsoft.Model.parts model=new Maticsoft.Model.parts();
			model.PN=PN;
			model.name=name;
			model.jobnum=jobnum;
			model.ARef=ARef;
			model.size=size;
			model.sm=sm;
			model.Barcode=Barcode;

			Maticsoft.BLL.parts bll=new Maticsoft.BLL.parts();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

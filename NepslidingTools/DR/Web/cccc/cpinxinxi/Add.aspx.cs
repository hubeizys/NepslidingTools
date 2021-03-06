﻿using System;
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
namespace Maticsoft.Web.cccc.cpinxinxi
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtcpbianh.Text))
			{
				strErr+="cpbianh格式错误！\\n";	
			}
			if(this.txtcgmc.Text.Trim().Length==0)
			{
				strErr+="cgmc不能为空！\\n";	
			}
			if(this.txtxsmc.Text.Trim().Length==0)
			{
				strErr+="xsmc不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int cpbianh=int.Parse(this.txtcpbianh.Text);
			string cgmc=this.txtcgmc.Text;
			string xsmc=this.txtxsmc.Text;

			Maticsoft.Model.cccc.cpinxinxi model=new Maticsoft.Model.cccc.cpinxinxi();
			model.cpbianh=cpbianh;
			model.cgmc=cgmc;
			model.xsmc=xsmc;

			Maticsoft.BLL.cccc.cpinxinxi bll=new Maticsoft.BLL.cccc.cpinxinxi();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

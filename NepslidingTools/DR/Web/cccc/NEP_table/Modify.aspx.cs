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
namespace Maticsoft.Web.cccc.NEP_table
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
		Maticsoft.BLL.cccc.NEP_table bll=new Maticsoft.BLL.cccc.NEP_table();
		Maticsoft.Model.cccc.NEP_table model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtname.Text=model.name;
		this.txtcheshu.Text=model.cheshu.ToString();
		this.txtdunwei.Text=model.dunwei.ToString();
		this.txtdanjia.Text=model.danjia.ToString();
		this.txtjine.Text=model.jine.ToString();
		this.txtRemarks.Text=model.Remarks;
		this.txtgonyingdanwei.Text=model.gonyingdanwei;
		this.txtjinshouren.Text=model.jinshouren;
		this.txtdingdanbianhao.Text=model.dingdanbianhao;
		this.txtdanjubianhao.Text=model.danjubianhao;
		this.txtlurushijian.Text=model.lurushijian.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcheshu.Text))
			{
				strErr+="cheshu格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdunwei.Text))
			{
				strErr+="dunwei格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdanjia.Text))
			{
				strErr+="danjia格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtjine.Text))
			{
				strErr+="jine格式错误！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="Remarks不能为空！\\n";	
			}
			if(this.txtgonyingdanwei.Text.Trim().Length==0)
			{
				strErr+="gonyingdanwei不能为空！\\n";	
			}
			if(this.txtjinshouren.Text.Trim().Length==0)
			{
				strErr+="jinshouren不能为空！\\n";	
			}
			if(this.txtdingdanbianhao.Text.Trim().Length==0)
			{
				strErr+="dingdanbianhao不能为空！\\n";	
			}
			if(this.txtdanjubianhao.Text.Trim().Length==0)
			{
				strErr+="danjubianhao不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlurushijian.Text))
			{
				strErr+="lurushijian格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			string name=this.txtname.Text;
			int cheshu=int.Parse(this.txtcheshu.Text);
			int dunwei=int.Parse(this.txtdunwei.Text);
			int danjia=int.Parse(this.txtdanjia.Text);
			int jine=int.Parse(this.txtjine.Text);
			string Remarks=this.txtRemarks.Text;
			string gonyingdanwei=this.txtgonyingdanwei.Text;
			string jinshouren=this.txtjinshouren.Text;
			string dingdanbianhao=this.txtdingdanbianhao.Text;
			string danjubianhao=this.txtdanjubianhao.Text;
			DateTime lurushijian=DateTime.Parse(this.txtlurushijian.Text);


			Maticsoft.Model.cccc.NEP_table model=new Maticsoft.Model.cccc.NEP_table();
			model.ID=ID;
			model.name=name;
			model.cheshu=cheshu;
			model.dunwei=dunwei;
			model.danjia=danjia;
			model.jine=jine;
			model.Remarks=Remarks;
			model.gonyingdanwei=gonyingdanwei;
			model.jinshouren=jinshouren;
			model.dingdanbianhao=dingdanbianhao;
			model.danjubianhao=danjubianhao;
			model.lurushijian=lurushijian;

			Maticsoft.BLL.cccc.NEP_table bll=new Maticsoft.BLL.cccc.NEP_table();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

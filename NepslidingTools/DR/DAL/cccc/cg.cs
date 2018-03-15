using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:cg
	/// </summary>
	public partial class cg
	{
		public cg()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cccc.cg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cg(");
			strSql.Append("XUHAO,RIQI,MINGCHEN,CHESHU,DUNWEI,DANJIA,JINE,BEIZHU)");
			strSql.Append(" values (");
			strSql.Append("@XUHAO,@RIQI,@MINGCHEN,@CHESHU,@DUNWEI,@DANJIA,@JINE,@BEIZHU)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@XUHAO", MySqlDbType.VarChar,255),
					new MySqlParameter("@RIQI", MySqlDbType.VarChar,255),
					new MySqlParameter("@MINGCHEN", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHESHU", MySqlDbType.VarChar,255),
					new MySqlParameter("@DUNWEI", MySqlDbType.VarChar,255),
					new MySqlParameter("@DANJIA", MySqlDbType.VarChar,255),
					new MySqlParameter("@JINE", MySqlDbType.VarChar,255),
					new MySqlParameter("@BEIZHU", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.XUHAO;
			parameters[1].Value = model.RIQI;
			parameters[2].Value = model.MINGCHEN;
			parameters[3].Value = model.CHESHU;
			parameters[4].Value = model.DUNWEI;
			parameters[5].Value = model.DANJIA;
			parameters[6].Value = model.JINE;
			parameters[7].Value = model.BEIZHU;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.cccc.cg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cg set ");
			strSql.Append("XUHAO=@XUHAO,");
			strSql.Append("RIQI=@RIQI,");
			strSql.Append("MINGCHEN=@MINGCHEN,");
			strSql.Append("CHESHU=@CHESHU,");
			strSql.Append("DUNWEI=@DUNWEI,");
			strSql.Append("DANJIA=@DANJIA,");
			strSql.Append("JINE=@JINE,");
			strSql.Append("BEIZHU=@BEIZHU");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@XUHAO", MySqlDbType.VarChar,255),
					new MySqlParameter("@RIQI", MySqlDbType.VarChar,255),
					new MySqlParameter("@MINGCHEN", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHESHU", MySqlDbType.VarChar,255),
					new MySqlParameter("@DUNWEI", MySqlDbType.VarChar,255),
					new MySqlParameter("@DANJIA", MySqlDbType.VarChar,255),
					new MySqlParameter("@JINE", MySqlDbType.VarChar,255),
					new MySqlParameter("@BEIZHU", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.XUHAO;
			parameters[1].Value = model.RIQI;
			parameters[2].Value = model.MINGCHEN;
			parameters[3].Value = model.CHESHU;
			parameters[4].Value = model.DUNWEI;
			parameters[5].Value = model.DANJIA;
			parameters[6].Value = model.JINE;
			parameters[7].Value = model.BEIZHU;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cg ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.cccc.cg GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select XUHAO,RIQI,MINGCHEN,CHESHU,DUNWEI,DANJIA,JINE,BEIZHU from cg ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Maticsoft.Model.cccc.cg model=new Maticsoft.Model.cccc.cg();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.cccc.cg DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.cg model=new Maticsoft.Model.cccc.cg();
			if (row != null)
			{
				if(row["XUHAO"]!=null)
				{
					model.XUHAO=row["XUHAO"].ToString();
				}
				if(row["RIQI"]!=null)
				{
					model.RIQI=row["RIQI"].ToString();
				}
				if(row["MINGCHEN"]!=null)
				{
					model.MINGCHEN=row["MINGCHEN"].ToString();
				}
				if(row["CHESHU"]!=null)
				{
					model.CHESHU=row["CHESHU"].ToString();
				}
				if(row["DUNWEI"]!=null)
				{
					model.DUNWEI=row["DUNWEI"].ToString();
				}
				if(row["DANJIA"]!=null)
				{
					model.DANJIA=row["DANJIA"].ToString();
				}
				if(row["JINE"]!=null)
				{
					model.JINE=row["JINE"].ToString();
				}
				if(row["BEIZHU"]!=null)
				{
					model.BEIZHU=row["BEIZHU"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select XUHAO,RIQI,MINGCHEN,CHESHU,DUNWEI,DANJIA,JINE,BEIZHU ");
			strSql.Append(" FROM cg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM cg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from cg T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "cg";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


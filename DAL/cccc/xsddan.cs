using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:xsddan
	/// </summary>
	public partial class xsddan
	{
		public xsddan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("xh", "xsddan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int xh)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from xsddan");
			strSql.Append(" where xh=@xh");
			MySqlParameter[] parameters = {
					new MySqlParameter("@xh", MySqlDbType.Int32)
			};
			parameters[0].Value = xh;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cccc.xsddan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into xsddan(");
			strSql.Append("rq,cpmc,cs,dwei,dj,jine,danwei,jsr,ddbh,djbh,bz)");
			strSql.Append(" values (");
			strSql.Append("@rq,@cpmc,@cs,@dwei,@dj,@jine,@danwei,@jsr,@ddbh,@djbh,@bz)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@rq", MySqlDbType.DateTime),
					new MySqlParameter("@cpmc", MySqlDbType.VarChar,64),
					new MySqlParameter("@cs", MySqlDbType.Int32,64),
					new MySqlParameter("@dwei", MySqlDbType.Int32,64),
					new MySqlParameter("@dj", MySqlDbType.Int32,64),
					new MySqlParameter("@jine", MySqlDbType.Int32,64),
					new MySqlParameter("@danwei", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@ddbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.rq;
			parameters[1].Value = model.cpmc;
			parameters[2].Value = model.cs;
			parameters[3].Value = model.dwei;
			parameters[4].Value = model.dj;
			parameters[5].Value = model.jine;
			parameters[6].Value = model.danwei;
			parameters[7].Value = model.jsr;
			parameters[8].Value = model.ddbh;
			parameters[9].Value = model.djbh;
			parameters[10].Value = model.bz;

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
		public bool Update(Maticsoft.Model.cccc.xsddan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update xsddan set ");
			strSql.Append("rq=@rq,");
			strSql.Append("cpmc=@cpmc,");
			strSql.Append("cs=@cs,");
			strSql.Append("dwei=@dwei,");
			strSql.Append("dj=@dj,");
			strSql.Append("jine=@jine,");
			strSql.Append("danwei=@danwei,");
			strSql.Append("jsr=@jsr,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("djbh=@djbh,");
			strSql.Append("bz=@bz");
			strSql.Append(" where xh=@xh");
			MySqlParameter[] parameters = {
					new MySqlParameter("@rq", MySqlDbType.DateTime),
					new MySqlParameter("@cpmc", MySqlDbType.VarChar,64),
					new MySqlParameter("@cs", MySqlDbType.Int32,64),
					new MySqlParameter("@dwei", MySqlDbType.Int32,64),
					new MySqlParameter("@dj", MySqlDbType.Int32,64),
					new MySqlParameter("@jine", MySqlDbType.Int32,64),
					new MySqlParameter("@danwei", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@ddbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@xh", MySqlDbType.Int32,64)};
			parameters[0].Value = model.rq;
			parameters[1].Value = model.cpmc;
			parameters[2].Value = model.cs;
			parameters[3].Value = model.dwei;
			parameters[4].Value = model.dj;
			parameters[5].Value = model.jine;
			parameters[6].Value = model.danwei;
			parameters[7].Value = model.jsr;
			parameters[8].Value = model.ddbh;
			parameters[9].Value = model.djbh;
			parameters[10].Value = model.bz;
			parameters[11].Value = model.xh;

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
		public bool Delete(int xh)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xsddan ");
			strSql.Append(" where xh=@xh");
			MySqlParameter[] parameters = {
					new MySqlParameter("@xh", MySqlDbType.Int32)
			};
			parameters[0].Value = xh;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string xhlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xsddan ");
			strSql.Append(" where xh in ("+xhlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.cccc.xsddan GetModel(int xh)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select xh,rq,cpmc,cs,dwei,dj,jine,danwei,jsr,ddbh,djbh,bz from xsddan ");
			strSql.Append(" where xh=@xh");
			MySqlParameter[] parameters = {
					new MySqlParameter("@xh", MySqlDbType.Int32)
			};
			parameters[0].Value = xh;

			Maticsoft.Model.cccc.xsddan model=new Maticsoft.Model.cccc.xsddan();
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
		public Maticsoft.Model.cccc.xsddan DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.xsddan model=new Maticsoft.Model.cccc.xsddan();
			if (row != null)
			{
				if(row["xh"]!=null && row["xh"].ToString()!="")
				{
					model.xh=int.Parse(row["xh"].ToString());
				}
				if(row["rq"]!=null && row["rq"].ToString()!="")
				{
					model.rq=DateTime.Parse(row["rq"].ToString());
				}
				if(row["cpmc"]!=null)
				{
					model.cpmc=row["cpmc"].ToString();
				}
				if(row["cs"]!=null && row["cs"].ToString()!="")
				{
					model.cs=int.Parse(row["cs"].ToString());
				}
				if(row["dwei"]!=null && row["dwei"].ToString()!="")
				{
					model.dwei=int.Parse(row["dwei"].ToString());
				}
				if(row["dj"]!=null && row["dj"].ToString()!="")
				{
					model.dj=int.Parse(row["dj"].ToString());
				}
				if(row["jine"]!=null && row["jine"].ToString()!="")
				{
					model.jine=int.Parse(row["jine"].ToString());
				}
				if(row["danwei"]!=null)
				{
					model.danwei=row["danwei"].ToString();
				}
				if(row["jsr"]!=null)
				{
					model.jsr=row["jsr"].ToString();
				}
				if(row["ddbh"]!=null)
				{
					model.ddbh=row["ddbh"].ToString();
				}
				if(row["djbh"]!=null)
				{
					model.djbh=row["djbh"].ToString();
				}
				if(row["bz"]!=null)
				{
					model.bz=row["bz"].ToString();
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
			strSql.Append("select xh,rq,cpmc,cs,dwei,dj,jine,danwei,jsr,ddbh,djbh,bz ");
			strSql.Append(" FROM xsddan ");
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
			strSql.Append("select count(1) FROM xsddan ");
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
				strSql.Append("order by T.xh desc");
			}
			strSql.Append(")AS Row, T.*  from xsddan T ");
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
			parameters[0].Value = "xsddan";
			parameters[1].Value = "xh";
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


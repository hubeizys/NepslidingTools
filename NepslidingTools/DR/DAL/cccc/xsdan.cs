using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:xsdan
	/// </summary>
	public partial class xsdan
	{
		public xsdan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "xsdan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from xsdan");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cccc.xsdan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into xsdan(");
			strSql.Append("cpmc,cs,dunw,dj,je,bz,danw,jsr,ddbh,djbh,shijian,skfs,skjine,ye)");
			strSql.Append(" values (");
			strSql.Append("@cpmc,@cs,@dunw,@dj,@je,@bz,@danw,@jsr,@ddbh,@djbh,@shijian,@skfs,@skjine,@ye)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cpmc", MySqlDbType.VarChar,64),
					new MySqlParameter("@cs", MySqlDbType.Int32,64),
					new MySqlParameter("@dunw", MySqlDbType.Int32,64),
					new MySqlParameter("@dj", MySqlDbType.Int32,64),
					new MySqlParameter("@je", MySqlDbType.Int32,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@danw", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@ddbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@shijian", MySqlDbType.DateTime),
					new MySqlParameter("@skfs", MySqlDbType.VarChar,64),
					new MySqlParameter("@skjine", MySqlDbType.Int32,64),
					new MySqlParameter("@ye", MySqlDbType.Int32,64)};
			parameters[0].Value = model.cpmc;
			parameters[1].Value = model.cs;
			parameters[2].Value = model.dunw;
			parameters[3].Value = model.dj;
			parameters[4].Value = model.je;
			parameters[5].Value = model.bz;
			parameters[6].Value = model.danw;
			parameters[7].Value = model.jsr;
			parameters[8].Value = model.ddbh;
			parameters[9].Value = model.djbh;
			parameters[10].Value = model.shijian;
			parameters[11].Value = model.skfs;
			parameters[12].Value = model.skjine;
			parameters[13].Value = model.ye;

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
		public bool Update(Maticsoft.Model.cccc.xsdan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update xsdan set ");
			strSql.Append("cpmc=@cpmc,");
			strSql.Append("cs=@cs,");
			strSql.Append("dunw=@dunw,");
			strSql.Append("dj=@dj,");
			strSql.Append("je=@je,");
			strSql.Append("bz=@bz,");
			strSql.Append("danw=@danw,");
			strSql.Append("jsr=@jsr,");
			strSql.Append("ddbh=@ddbh,");
			strSql.Append("djbh=@djbh,");
			strSql.Append("shijian=@shijian,");
			strSql.Append("skfs=@skfs,");
			strSql.Append("skjine=@skjine,");
			strSql.Append("ye=@ye");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cpmc", MySqlDbType.VarChar,64),
					new MySqlParameter("@cs", MySqlDbType.Int32,64),
					new MySqlParameter("@dunw", MySqlDbType.Int32,64),
					new MySqlParameter("@dj", MySqlDbType.Int32,64),
					new MySqlParameter("@je", MySqlDbType.Int32,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@danw", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@ddbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@shijian", MySqlDbType.DateTime),
					new MySqlParameter("@skfs", MySqlDbType.VarChar,64),
					new MySqlParameter("@skjine", MySqlDbType.Int32,64),
					new MySqlParameter("@ye", MySqlDbType.Int32,64),
					new MySqlParameter("@id", MySqlDbType.Int32,64)};
			parameters[0].Value = model.cpmc;
			parameters[1].Value = model.cs;
			parameters[2].Value = model.dunw;
			parameters[3].Value = model.dj;
			parameters[4].Value = model.je;
			parameters[5].Value = model.bz;
			parameters[6].Value = model.danw;
			parameters[7].Value = model.jsr;
			parameters[8].Value = model.ddbh;
			parameters[9].Value = model.djbh;
			parameters[10].Value = model.shijian;
			parameters[11].Value = model.skfs;
			parameters[12].Value = model.skjine;
			parameters[13].Value = model.ye;
			parameters[14].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xsdan ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from xsdan ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Maticsoft.Model.cccc.xsdan GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,cpmc,cs,dunw,dj,je,bz,danw,jsr,ddbh,djbh,shijian,skfs,skjine,ye from xsdan ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.cccc.xsdan model=new Maticsoft.Model.cccc.xsdan();
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
		public Maticsoft.Model.cccc.xsdan DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.xsdan model=new Maticsoft.Model.cccc.xsdan();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["cpmc"]!=null)
				{
					model.cpmc=row["cpmc"].ToString();
				}
				if(row["cs"]!=null && row["cs"].ToString()!="")
				{
					model.cs=int.Parse(row["cs"].ToString());
				}
				if(row["dunw"]!=null && row["dunw"].ToString()!="")
				{
					model.dunw=int.Parse(row["dunw"].ToString());
				}
				if(row["dj"]!=null && row["dj"].ToString()!="")
				{
					model.dj=int.Parse(row["dj"].ToString());
				}
				if(row["je"]!=null && row["je"].ToString()!="")
				{
					model.je=int.Parse(row["je"].ToString());
				}
				if(row["bz"]!=null)
				{
					model.bz=row["bz"].ToString();
				}
				if(row["danw"]!=null)
				{
					model.danw=row["danw"].ToString();
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
				if(row["shijian"]!=null && row["shijian"].ToString()!="")
				{
					model.shijian=DateTime.Parse(row["shijian"].ToString());
				}
				if(row["skfs"]!=null)
				{
					model.skfs=row["skfs"].ToString();
				}
				if(row["skjine"]!=null && row["skjine"].ToString()!="")
				{
					model.skjine=int.Parse(row["skjine"].ToString());
				}
				if(row["ye"]!=null && row["ye"].ToString()!="")
				{
					model.ye=int.Parse(row["ye"].ToString());
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
			strSql.Append("select id,cpmc,cs,dunw,dj,je,bz,danw,jsr,ddbh,djbh,shijian,skfs,skjine,ye ");
			strSql.Append(" FROM xsdan ");
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
			strSql.Append("select count(1) FROM xsdan ");
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
			strSql.Append(")AS Row, T.*  from xsdan T ");
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
			parameters[0].Value = "xsdan";
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


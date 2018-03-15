using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class user
	{
		public user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("username", "user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int username)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from user");
			strSql.Append(" where username=@username");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.Int32)
			};
			parameters[0].Value = username;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cccc.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user(");
			strSql.Append("password,sex,age,heig,weight,beizhu)");
			strSql.Append(" values (");
			strSql.Append("@password,@sex,@age,@heig,@weight,@beizhu)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@password", MySqlDbType.VarChar,64),
					new MySqlParameter("@sex", MySqlDbType.VarChar,64),
					new MySqlParameter("@age", MySqlDbType.Int32,64),
					new MySqlParameter("@heig", MySqlDbType.Int32,64),
					new MySqlParameter("@weight", MySqlDbType.Int32,64),
					new MySqlParameter("@beizhu", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.sex;
			parameters[2].Value = model.age;
			parameters[3].Value = model.heig;
			parameters[4].Value = model.weight;
			parameters[5].Value = model.beizhu;

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
		public bool Update(Maticsoft.Model.cccc.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			strSql.Append("password=@password,");
			strSql.Append("sex=@sex,");
			strSql.Append("age=@age,");
			strSql.Append("heig=@heig,");
			strSql.Append("weight=@weight,");
			strSql.Append("beizhu=@beizhu");
			strSql.Append(" where username=@username");
			MySqlParameter[] parameters = {
					new MySqlParameter("@password", MySqlDbType.VarChar,64),
					new MySqlParameter("@sex", MySqlDbType.VarChar,64),
					new MySqlParameter("@age", MySqlDbType.Int32,64),
					new MySqlParameter("@heig", MySqlDbType.Int32,64),
					new MySqlParameter("@weight", MySqlDbType.Int32,64),
					new MySqlParameter("@beizhu", MySqlDbType.VarChar,64),
					new MySqlParameter("@username", MySqlDbType.Int32,64)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.sex;
			parameters[2].Value = model.age;
			parameters[3].Value = model.heig;
			parameters[4].Value = model.weight;
			parameters[5].Value = model.beizhu;
			parameters[6].Value = model.username;

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
		public bool Delete(int username)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where username=@username");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.Int32)
			};
			parameters[0].Value = username;

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
		public bool DeleteList(string usernamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where username in ("+usernamelist + ")  ");
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
		public Maticsoft.Model.cccc.user GetModel(int username)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select username,password,sex,age,heig,weight,beizhu from user ");
			strSql.Append(" where username=@username");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.Int32)
			};
			parameters[0].Value = username;

			Maticsoft.Model.cccc.user model=new Maticsoft.Model.cccc.user();
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
		public Maticsoft.Model.cccc.user DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.user model=new Maticsoft.Model.cccc.user();
			if (row != null)
			{
				if(row["username"]!=null && row["username"].ToString()!="")
				{
					model.username=int.Parse(row["username"].ToString());
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["age"]!=null && row["age"].ToString()!="")
				{
					model.age=int.Parse(row["age"].ToString());
				}
				if(row["heig"]!=null && row["heig"].ToString()!="")
				{
					model.heig=int.Parse(row["heig"].ToString());
				}
				if(row["weight"]!=null && row["weight"].ToString()!="")
				{
					model.weight=int.Parse(row["weight"].ToString());
				}
				if(row["beizhu"]!=null)
				{
					model.beizhu=row["beizhu"].ToString();
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
			strSql.Append("select username,password,sex,age,heig,weight,beizhu ");
			strSql.Append(" FROM user ");
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
			strSql.Append("select count(1) FROM user ");
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
				strSql.Append("order by T.username desc");
			}
			strSql.Append(")AS Row, T.*  from user T ");
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
			parameters[0].Value = "user";
			parameters[1].Value = "username";
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


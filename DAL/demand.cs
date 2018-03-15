using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:demand
	/// </summary>
	public partial class demand
	{
		public demand()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "demand"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from demand");
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
		public bool Add(Maticsoft.Model.demand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into demand(");
			strSql.Append("PN,measureb,testboard,time,step1,step2,step3,result)");
			strSql.Append(" values (");
			strSql.Append("@PN,@measureb,@testboard,@time,@step1,@step2,@step3,@result)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PN", MySqlDbType.VarChar,64),
					new MySqlParameter("@measureb", MySqlDbType.VarChar,64),
					new MySqlParameter("@testboard", MySqlDbType.VarChar,64),
					new MySqlParameter("@time", MySqlDbType.DateTime),
					new MySqlParameter("@step1", MySqlDbType.VarChar,64),
					new MySqlParameter("@step2", MySqlDbType.VarChar,64),
					new MySqlParameter("@step3", MySqlDbType.VarChar,64),
					new MySqlParameter("@result", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.PN;
			parameters[1].Value = model.measureb;
			parameters[2].Value = model.testboard;
			parameters[3].Value = model.time;
			parameters[4].Value = model.step1;
			parameters[5].Value = model.step2;
			parameters[6].Value = model.step3;
			parameters[7].Value = model.result;

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
		public bool Update(Maticsoft.Model.demand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update demand set ");
			strSql.Append("PN=@PN,");
			strSql.Append("measureb=@measureb,");
			strSql.Append("testboard=@testboard,");
			strSql.Append("time=@time,");
			strSql.Append("step1=@step1,");
			strSql.Append("step2=@step2,");
			strSql.Append("step3=@step3,");
			strSql.Append("result=@result");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PN", MySqlDbType.VarChar,64),
					new MySqlParameter("@measureb", MySqlDbType.VarChar,64),
					new MySqlParameter("@testboard", MySqlDbType.VarChar,64),
					new MySqlParameter("@time", MySqlDbType.DateTime),
					new MySqlParameter("@step1", MySqlDbType.VarChar,64),
					new MySqlParameter("@step2", MySqlDbType.VarChar,64),
					new MySqlParameter("@step3", MySqlDbType.VarChar,64),
					new MySqlParameter("@result", MySqlDbType.VarChar,64),
					new MySqlParameter("@id", MySqlDbType.Int32,64)};
			parameters[0].Value = model.PN;
			parameters[1].Value = model.measureb;
			parameters[2].Value = model.testboard;
			parameters[3].Value = model.time;
			parameters[4].Value = model.step1;
			parameters[5].Value = model.step2;
			parameters[6].Value = model.step3;
			parameters[7].Value = model.result;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from demand ");
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
			strSql.Append("delete from demand ");
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
		public Maticsoft.Model.demand GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,PN,measureb,testboard,time,step1,step2,step3,result from demand ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.demand model=new Maticsoft.Model.demand();
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
		public Maticsoft.Model.demand DataRowToModel(DataRow row)
		{
			Maticsoft.Model.demand model=new Maticsoft.Model.demand();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["PN"]!=null)
				{
					model.PN=row["PN"].ToString();
				}
				if(row["measureb"]!=null)
				{
					model.measureb=row["measureb"].ToString();
				}
				if(row["testboard"]!=null)
				{
					model.testboard=row["testboard"].ToString();
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=DateTime.Parse(row["time"].ToString());
				}
				if(row["step1"]!=null)
				{
					model.step1=row["step1"].ToString();
				}
				if(row["step2"]!=null)
				{
					model.step2=row["step2"].ToString();
				}
				if(row["step3"]!=null)
				{
					model.step3=row["step3"].ToString();
				}
				if(row["result"]!=null)
				{
					model.result=row["result"].ToString();
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
			strSql.Append("select id,PN,measureb,testboard,time,step1,step2,step3,result ");
			strSql.Append(" FROM demand ");
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
			strSql.Append("select count(1) FROM demand ");
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
			strSql.Append(")AS Row, T.*  from demand T ");
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
			parameters[0].Value = "demand";
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


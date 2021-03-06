﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:fuk_dan
	/// </summary>
	public partial class fuk_dan
	{
		public fuk_dan()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "fuk_dan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fuk_dan");
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
		public bool Add(Maticsoft.Model.cccc.fuk_dan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fuk_dan(");
			strSql.Append("fkfs,fkjine,dxjine,bz,skdw,jsr,djbh,shijian)");
			strSql.Append(" values (");
			strSql.Append("@fkfs,@fkjine,@dxjine,@bz,@skdw,@jsr,@djbh,@shijian)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fkfs", MySqlDbType.VarChar,64),
					new MySqlParameter("@fkjine", MySqlDbType.Int32,64),
					new MySqlParameter("@dxjine", MySqlDbType.VarChar,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@skdw", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@shijian", MySqlDbType.DateTime)};
			parameters[0].Value = model.fkfs;
			parameters[1].Value = model.fkjine;
			parameters[2].Value = model.dxjine;
			parameters[3].Value = model.bz;
			parameters[4].Value = model.skdw;
			parameters[5].Value = model.jsr;
			parameters[6].Value = model.djbh;
			parameters[7].Value = model.shijian;

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
		public bool Update(Maticsoft.Model.cccc.fuk_dan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fuk_dan set ");
			strSql.Append("fkfs=@fkfs,");
			strSql.Append("fkjine=@fkjine,");
			strSql.Append("dxjine=@dxjine,");
			strSql.Append("bz=@bz,");
			strSql.Append("skdw=@skdw,");
			strSql.Append("jsr=@jsr,");
			strSql.Append("djbh=@djbh,");
			strSql.Append("shijian=@shijian");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@fkfs", MySqlDbType.VarChar,64),
					new MySqlParameter("@fkjine", MySqlDbType.Int32,64),
					new MySqlParameter("@dxjine", MySqlDbType.VarChar,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@skdw", MySqlDbType.VarChar,64),
					new MySqlParameter("@jsr", MySqlDbType.VarChar,64),
					new MySqlParameter("@djbh", MySqlDbType.VarChar,64),
					new MySqlParameter("@shijian", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,64)};
			parameters[0].Value = model.fkfs;
			parameters[1].Value = model.fkjine;
			parameters[2].Value = model.dxjine;
			parameters[3].Value = model.bz;
			parameters[4].Value = model.skdw;
			parameters[5].Value = model.jsr;
			parameters[6].Value = model.djbh;
			parameters[7].Value = model.shijian;
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
			strSql.Append("delete from fuk_dan ");
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
			strSql.Append("delete from fuk_dan ");
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
		public Maticsoft.Model.cccc.fuk_dan GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,fkfs,fkjine,dxjine,bz,skdw,jsr,djbh,shijian from fuk_dan ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.cccc.fuk_dan model=new Maticsoft.Model.cccc.fuk_dan();
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
		public Maticsoft.Model.cccc.fuk_dan DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.fuk_dan model=new Maticsoft.Model.cccc.fuk_dan();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["fkfs"]!=null)
				{
					model.fkfs=row["fkfs"].ToString();
				}
				if(row["fkjine"]!=null && row["fkjine"].ToString()!="")
				{
					model.fkjine=int.Parse(row["fkjine"].ToString());
				}
				if(row["dxjine"]!=null)
				{
					model.dxjine=row["dxjine"].ToString();
				}
				if(row["bz"]!=null)
				{
					model.bz=row["bz"].ToString();
				}
				if(row["skdw"]!=null)
				{
					model.skdw=row["skdw"].ToString();
				}
				if(row["jsr"]!=null)
				{
					model.jsr=row["jsr"].ToString();
				}
				if(row["djbh"]!=null)
				{
					model.djbh=row["djbh"].ToString();
				}
				if(row["shijian"]!=null && row["shijian"].ToString()!="")
				{
					model.shijian=DateTime.Parse(row["shijian"].ToString());
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
			strSql.Append("select id,fkfs,fkjine,dxjine,bz,skdw,jsr,djbh,shijian ");
			strSql.Append(" FROM fuk_dan ");
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
			strSql.Append("select count(1) FROM fuk_dan ");
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
			strSql.Append(")AS Row, T.*  from fuk_dan T ");
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
			parameters[0].Value = "fuk_dan";
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


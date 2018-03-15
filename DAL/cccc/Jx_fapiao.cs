using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:Jx_fapiao
	/// </summary>
	public partial class Jx_fapiao
	{
		public Jx_fapiao()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "Jx_fapiao"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Jx_fapiao");
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
		public bool Add(Maticsoft.Model.cccc.Jx_fapiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Jx_fapiao(");
			strSql.Append("cgdbhao,kaipr,fpneixing,jbanr,cal,fphao,riqi,kpdanw,kpdunwei,kpjine,shuinv,shuie,bz)");
			strSql.Append(" values (");
			strSql.Append("@cgdbhao,@kaipr,@fpneixing,@jbanr,@cal,@fphao,@riqi,@kpdanw,@kpdunwei,@kpjine,@shuinv,@shuie,@bz)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cgdbhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@kaipr", MySqlDbType.VarChar,64),
					new MySqlParameter("@fpneixing", MySqlDbType.VarChar,64),
					new MySqlParameter("@jbanr", MySqlDbType.VarChar,64),
					new MySqlParameter("@cal", MySqlDbType.Int32,64),
					new MySqlParameter("@fphao", MySqlDbType.Int32,64),
					new MySqlParameter("@riqi", MySqlDbType.DateTime),
					new MySqlParameter("@kpdanw", MySqlDbType.VarChar,64),
					new MySqlParameter("@kpdunwei", MySqlDbType.Int32,64),
					new MySqlParameter("@kpjine", MySqlDbType.Int32,64),
					new MySqlParameter("@shuinv", MySqlDbType.VarChar,64),
					new MySqlParameter("@shuie", MySqlDbType.Int32,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.cgdbhao;
			parameters[1].Value = model.kaipr;
			parameters[2].Value = model.fpneixing;
			parameters[3].Value = model.jbanr;
			parameters[4].Value = model.cal;
			parameters[5].Value = model.fphao;
			parameters[6].Value = model.riqi;
			parameters[7].Value = model.kpdanw;
			parameters[8].Value = model.kpdunwei;
			parameters[9].Value = model.kpjine;
			parameters[10].Value = model.shuinv;
			parameters[11].Value = model.shuie;
			parameters[12].Value = model.bz;

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
		public bool Update(Maticsoft.Model.cccc.Jx_fapiao model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Jx_fapiao set ");
			strSql.Append("cgdbhao=@cgdbhao,");
			strSql.Append("kaipr=@kaipr,");
			strSql.Append("fpneixing=@fpneixing,");
			strSql.Append("jbanr=@jbanr,");
			strSql.Append("cal=@cal,");
			strSql.Append("fphao=@fphao,");
			strSql.Append("riqi=@riqi,");
			strSql.Append("kpdanw=@kpdanw,");
			strSql.Append("kpdunwei=@kpdunwei,");
			strSql.Append("kpjine=@kpjine,");
			strSql.Append("shuinv=@shuinv,");
			strSql.Append("shuie=@shuie,");
			strSql.Append("bz=@bz");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@cgdbhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@kaipr", MySqlDbType.VarChar,64),
					new MySqlParameter("@fpneixing", MySqlDbType.VarChar,64),
					new MySqlParameter("@jbanr", MySqlDbType.VarChar,64),
					new MySqlParameter("@cal", MySqlDbType.Int32,64),
					new MySqlParameter("@fphao", MySqlDbType.Int32,64),
					new MySqlParameter("@riqi", MySqlDbType.DateTime),
					new MySqlParameter("@kpdanw", MySqlDbType.VarChar,64),
					new MySqlParameter("@kpdunwei", MySqlDbType.Int32,64),
					new MySqlParameter("@kpjine", MySqlDbType.Int32,64),
					new MySqlParameter("@shuinv", MySqlDbType.VarChar,64),
					new MySqlParameter("@shuie", MySqlDbType.Int32,64),
					new MySqlParameter("@bz", MySqlDbType.VarChar,64),
					new MySqlParameter("@id", MySqlDbType.Int32,64)};
			parameters[0].Value = model.cgdbhao;
			parameters[1].Value = model.kaipr;
			parameters[2].Value = model.fpneixing;
			parameters[3].Value = model.jbanr;
			parameters[4].Value = model.cal;
			parameters[5].Value = model.fphao;
			parameters[6].Value = model.riqi;
			parameters[7].Value = model.kpdanw;
			parameters[8].Value = model.kpdunwei;
			parameters[9].Value = model.kpjine;
			parameters[10].Value = model.shuinv;
			parameters[11].Value = model.shuie;
			parameters[12].Value = model.bz;
			parameters[13].Value = model.id;

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
			strSql.Append("delete from Jx_fapiao ");
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
			strSql.Append("delete from Jx_fapiao ");
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
		public Maticsoft.Model.cccc.Jx_fapiao GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,cgdbhao,kaipr,fpneixing,jbanr,cal,fphao,riqi,kpdanw,kpdunwei,kpjine,shuinv,shuie,bz from Jx_fapiao ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.cccc.Jx_fapiao model=new Maticsoft.Model.cccc.Jx_fapiao();
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
		public Maticsoft.Model.cccc.Jx_fapiao DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.Jx_fapiao model=new Maticsoft.Model.cccc.Jx_fapiao();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["cgdbhao"]!=null)
				{
					model.cgdbhao=row["cgdbhao"].ToString();
				}
				if(row["kaipr"]!=null)
				{
					model.kaipr=row["kaipr"].ToString();
				}
				if(row["fpneixing"]!=null)
				{
					model.fpneixing=row["fpneixing"].ToString();
				}
				if(row["jbanr"]!=null)
				{
					model.jbanr=row["jbanr"].ToString();
				}
				if(row["cal"]!=null && row["cal"].ToString()!="")
				{
					model.cal=int.Parse(row["cal"].ToString());
				}
				if(row["fphao"]!=null && row["fphao"].ToString()!="")
				{
					model.fphao=int.Parse(row["fphao"].ToString());
				}
				if(row["riqi"]!=null && row["riqi"].ToString()!="")
				{
					model.riqi=DateTime.Parse(row["riqi"].ToString());
				}
				if(row["kpdanw"]!=null)
				{
					model.kpdanw=row["kpdanw"].ToString();
				}
				if(row["kpdunwei"]!=null && row["kpdunwei"].ToString()!="")
				{
					model.kpdunwei=int.Parse(row["kpdunwei"].ToString());
				}
				if(row["kpjine"]!=null && row["kpjine"].ToString()!="")
				{
					model.kpjine=int.Parse(row["kpjine"].ToString());
				}
				if(row["shuinv"]!=null)
				{
					model.shuinv=row["shuinv"].ToString();
				}
				if(row["shuie"]!=null && row["shuie"].ToString()!="")
				{
					model.shuie=int.Parse(row["shuie"].ToString());
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
			strSql.Append("select id,cgdbhao,kaipr,fpneixing,jbanr,cal,fphao,riqi,kpdanw,kpdunwei,kpjine,shuinv,shuie,bz ");
			strSql.Append(" FROM Jx_fapiao ");
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
			strSql.Append("select count(1) FROM Jx_fapiao ");
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
			strSql.Append(")AS Row, T.*  from Jx_fapiao T ");
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
			parameters[0].Value = "Jx_fapiao";
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


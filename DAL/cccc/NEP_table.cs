using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.cccc
{
	/// <summary>
	/// 数据访问类:NEP_table
	/// </summary>
	public partial class NEP_table
	{
		public NEP_table()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "NEP_table"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NEP_table");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cccc.NEP_table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NEP_table(");
			strSql.Append("name,cheshu,dunwei,danjia,jine,Remarks,gonyingdanwei,jinshouren,dingdanbianhao,danjubianhao,lurushijian)");
			strSql.Append(" values (");
			strSql.Append("@name,@cheshu,@dunwei,@danjia,@jine,@Remarks,@gonyingdanwei,@jinshouren,@dingdanbianhao,@danjubianhao,@lurushijian)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,64),
					new MySqlParameter("@cheshu", MySqlDbType.Int32,64),
					new MySqlParameter("@dunwei", MySqlDbType.Int32,64),
					new MySqlParameter("@danjia", MySqlDbType.Int32,64),
					new MySqlParameter("@jine", MySqlDbType.Int32,64),
					new MySqlParameter("@Remarks", MySqlDbType.VarChar,64),
					new MySqlParameter("@gonyingdanwei", MySqlDbType.VarChar,64),
					new MySqlParameter("@jinshouren", MySqlDbType.VarChar,64),
					new MySqlParameter("@dingdanbianhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@danjubianhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@lurushijian", MySqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.cheshu;
			parameters[2].Value = model.dunwei;
			parameters[3].Value = model.danjia;
			parameters[4].Value = model.jine;
			parameters[5].Value = model.Remarks;
			parameters[6].Value = model.gonyingdanwei;
			parameters[7].Value = model.jinshouren;
			parameters[8].Value = model.dingdanbianhao;
			parameters[9].Value = model.danjubianhao;
			parameters[10].Value = model.lurushijian;

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
		public bool Update(Maticsoft.Model.cccc.NEP_table model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NEP_table set ");
			strSql.Append("name=@name,");
			strSql.Append("cheshu=@cheshu,");
			strSql.Append("dunwei=@dunwei,");
			strSql.Append("danjia=@danjia,");
			strSql.Append("jine=@jine,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("gonyingdanwei=@gonyingdanwei,");
			strSql.Append("jinshouren=@jinshouren,");
			strSql.Append("dingdanbianhao=@dingdanbianhao,");
			strSql.Append("danjubianhao=@danjubianhao,");
			strSql.Append("lurushijian=@lurushijian");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,64),
					new MySqlParameter("@cheshu", MySqlDbType.Int32,64),
					new MySqlParameter("@dunwei", MySqlDbType.Int32,64),
					new MySqlParameter("@danjia", MySqlDbType.Int32,64),
					new MySqlParameter("@jine", MySqlDbType.Int32,64),
					new MySqlParameter("@Remarks", MySqlDbType.VarChar,64),
					new MySqlParameter("@gonyingdanwei", MySqlDbType.VarChar,64),
					new MySqlParameter("@jinshouren", MySqlDbType.VarChar,64),
					new MySqlParameter("@dingdanbianhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@danjubianhao", MySqlDbType.VarChar,64),
					new MySqlParameter("@lurushijian", MySqlDbType.DateTime),
					new MySqlParameter("@ID", MySqlDbType.Int32,64)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.cheshu;
			parameters[2].Value = model.dunwei;
			parameters[3].Value = model.danjia;
			parameters[4].Value = model.jine;
			parameters[5].Value = model.Remarks;
			parameters[6].Value = model.gonyingdanwei;
			parameters[7].Value = model.jinshouren;
			parameters[8].Value = model.dingdanbianhao;
			parameters[9].Value = model.danjubianhao;
			parameters[10].Value = model.lurushijian;
			parameters[11].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NEP_table ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NEP_table ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.cccc.NEP_table GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,name,cheshu,dunwei,danjia,jine,Remarks,gonyingdanwei,jinshouren,dingdanbianhao,danjubianhao,lurushijian from NEP_table ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.cccc.NEP_table model=new Maticsoft.Model.cccc.NEP_table();
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
		public Maticsoft.Model.cccc.NEP_table DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cccc.NEP_table model=new Maticsoft.Model.cccc.NEP_table();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["cheshu"]!=null && row["cheshu"].ToString()!="")
				{
					model.cheshu=int.Parse(row["cheshu"].ToString());
				}
				if(row["dunwei"]!=null && row["dunwei"].ToString()!="")
				{
					model.dunwei=int.Parse(row["dunwei"].ToString());
				}
				if(row["danjia"]!=null && row["danjia"].ToString()!="")
				{
					model.danjia=int.Parse(row["danjia"].ToString());
				}
				if(row["jine"]!=null && row["jine"].ToString()!="")
				{
					model.jine=int.Parse(row["jine"].ToString());
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
				}
				if(row["gonyingdanwei"]!=null)
				{
					model.gonyingdanwei=row["gonyingdanwei"].ToString();
				}
				if(row["jinshouren"]!=null)
				{
					model.jinshouren=row["jinshouren"].ToString();
				}
				if(row["dingdanbianhao"]!=null)
				{
					model.dingdanbianhao=row["dingdanbianhao"].ToString();
				}
				if(row["danjubianhao"]!=null)
				{
					model.danjubianhao=row["danjubianhao"].ToString();
				}
				if(row["lurushijian"]!=null && row["lurushijian"].ToString()!="")
				{
					model.lurushijian=DateTime.Parse(row["lurushijian"].ToString());
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
			strSql.Append("select ID,name,cheshu,dunwei,danjia,jine,Remarks,gonyingdanwei,jinshouren,dingdanbianhao,danjubianhao,lurushijian ");
			strSql.Append(" FROM NEP_table ");
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
			strSql.Append("select count(1) FROM NEP_table ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from NEP_table T ");
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
			parameters[0].Value = "NEP_table";
			parameters[1].Value = "ID";
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


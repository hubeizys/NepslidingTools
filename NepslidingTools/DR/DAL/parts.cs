using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:parts
	/// </summary>
	public partial class parts
	{
		public parts()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "parts"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from parts");
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
		public bool Add(Maticsoft.Model.parts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into parts(");
			strSql.Append("PN,name,jobnum,ARef,size,sm,Barcode)");
			strSql.Append(" values (");
			strSql.Append("@PN,@name,@jobnum,@ARef,@size,@sm,@Barcode)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PN", MySqlDbType.VarChar,64),
					new MySqlParameter("@name", MySqlDbType.VarChar,64),
					new MySqlParameter("@jobnum", MySqlDbType.VarChar,64),
					new MySqlParameter("@ARef", MySqlDbType.VarChar,64),
					new MySqlParameter("@size", MySqlDbType.Double,64),
					new MySqlParameter("@sm", MySqlDbType.VarChar,64),
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.PN;
			parameters[1].Value = model.name;
			parameters[2].Value = model.jobnum;
			parameters[3].Value = model.ARef;
			parameters[4].Value = model.size;
			parameters[5].Value = model.sm;
			parameters[6].Value = model.Barcode;

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
		public bool Update(Maticsoft.Model.parts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update parts set ");
			strSql.Append("PN=@PN,");
			strSql.Append("name=@name,");
			strSql.Append("jobnum=@jobnum,");
			strSql.Append("ARef=@ARef,");
			strSql.Append("size=@size,");
			strSql.Append("sm=@sm,");
			strSql.Append("Barcode=@Barcode");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PN", MySqlDbType.VarChar,64),
					new MySqlParameter("@name", MySqlDbType.VarChar,64),
					new MySqlParameter("@jobnum", MySqlDbType.VarChar,64),
					new MySqlParameter("@ARef", MySqlDbType.VarChar,64),
					new MySqlParameter("@size", MySqlDbType.Double,64),
					new MySqlParameter("@sm", MySqlDbType.VarChar,64),
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,64),
					new MySqlParameter("@id", MySqlDbType.Int32,64)};
			parameters[0].Value = model.PN;
			parameters[1].Value = model.name;
			parameters[2].Value = model.jobnum;
			parameters[3].Value = model.ARef;
			parameters[4].Value = model.size;
			parameters[5].Value = model.sm;
			parameters[6].Value = model.Barcode;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from parts ");
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
			strSql.Append("delete from parts ");
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
		public Maticsoft.Model.parts GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,PN,name,jobnum,ARef,size,sm,Barcode from parts ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.parts model=new Maticsoft.Model.parts();
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
		public Maticsoft.Model.parts DataRowToModel(DataRow row)
		{
			Maticsoft.Model.parts model=new Maticsoft.Model.parts();
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
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["jobnum"]!=null)
				{
					model.jobnum=row["jobnum"].ToString();
				}
				if(row["ARef"]!=null)
				{
					model.ARef=row["ARef"].ToString();
				}
					//model.size=row["size"].ToString();
				if(row["sm"]!=null)
				{
					model.sm=row["sm"].ToString();
				}
				if(row["Barcode"]!=null)
				{
					model.Barcode=row["Barcode"].ToString();
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
			strSql.Append("select id,PN,name,jobnum,ARef,size,sm,Barcode ");
			strSql.Append(" FROM parts ");
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
			strSql.Append("select count(1) FROM parts ");
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
			strSql.Append(")AS Row, T.*  from parts T ");
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
			parameters[0].Value = "parts";
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


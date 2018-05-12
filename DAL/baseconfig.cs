using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:baseconfig
    /// </summary>
    public partial class baseconfig
    {
        public baseconfig()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string version, DateTime startTime, DateTime expTime, string companyName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from baseconfig");
            strSql.Append(" where  version=@ version and startTime=@startTime and expTime=@expTime and companyName=@companyName ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ version", MySqlDbType.VarChar,32),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@expTime", MySqlDbType.DateTime),
                    new MySqlParameter("@companyName", MySqlDbType.VarChar,255)         };
            parameters[0].Value = version;
            parameters[1].Value = startTime;
            parameters[2].Value = expTime;
            parameters[3].Value = companyName;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.baseconfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into baseconfig(");
            strSql.Append(" version,startTime,expTime,companyName)");
            strSql.Append(" values (");
            strSql.Append("@ version,@startTime,@expTime,@companyName)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ version", MySqlDbType.VarChar,32),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@expTime", MySqlDbType.DateTime),
                    new MySqlParameter("@companyName", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.version;
            parameters[1].Value = model.startTime;
            parameters[2].Value = model.expTime;
            parameters[3].Value = model.companyName;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.baseconfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update baseconfig set ");
            strSql.Append(" version=@ version,");
            strSql.Append("startTime=@startTime,");
            strSql.Append("expTime=@expTime,");
            strSql.Append("companyName=@companyName");
            strSql.Append(" where  version=@ version and startTime=@startTime and expTime=@expTime and companyName=@companyName ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ version", MySqlDbType.VarChar,32),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@expTime", MySqlDbType.DateTime),
                    new MySqlParameter("@companyName", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.version;
            parameters[1].Value = model.startTime;
            parameters[2].Value = model.expTime;
            parameters[3].Value = model.companyName;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string version, DateTime startTime, DateTime expTime, string companyName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from baseconfig ");
            strSql.Append(" where  version=@ version and startTime=@startTime and expTime=@expTime and companyName=@companyName ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ version", MySqlDbType.VarChar,32),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@expTime", MySqlDbType.DateTime),
                    new MySqlParameter("@companyName", MySqlDbType.VarChar,255)         };
            parameters[0].Value = version;
            parameters[1].Value = startTime;
            parameters[2].Value = expTime;
            parameters[3].Value = companyName;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public Maticsoft.Model.baseconfig GetModel(string version, DateTime startTime, DateTime expTime, string companyName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  version,startTime,expTime,companyName from baseconfig ");
            strSql.Append(" where  version=@ version and startTime=@startTime and expTime=@expTime and companyName=@companyName ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ version", MySqlDbType.VarChar,32),
                    new MySqlParameter("@startTime", MySqlDbType.DateTime),
                    new MySqlParameter("@expTime", MySqlDbType.DateTime),
                    new MySqlParameter("@companyName", MySqlDbType.VarChar,255)         };
            parameters[0].Value = version;
            parameters[1].Value = startTime;
            parameters[2].Value = expTime;
            parameters[3].Value = companyName;

            Maticsoft.Model.baseconfig model = new Maticsoft.Model.baseconfig();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.baseconfig DataRowToModel(DataRow row)
        {
            Maticsoft.Model.baseconfig model = new Maticsoft.Model.baseconfig();
            if (row != null)
            {
                if (row[" version"] != null)
                {
                    model.version = row[" version"].ToString();
                }
                if (row["startTime"] != null && row["startTime"].ToString() != "")
                {
                    model.startTime = DateTime.Parse(row["startTime"].ToString());
                }
                if (row["expTime"] != null && row["expTime"].ToString() != "")
                {
                    model.expTime = DateTime.Parse(row["expTime"].ToString());
                }
                if (row["companyName"] != null)
                {
                    model.companyName = row["companyName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select baseconfig.` version`,startTime,expTime,companyName ");
            strSql.Append(" FROM baseconfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM baseconfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.companyName desc");
            }
            strSql.Append(")AS Row, T.*  from baseconfig T ");
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
			parameters[0].Value = "baseconfig";
			parameters[1].Value = "companyName";
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


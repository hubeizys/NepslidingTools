using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:workstation
    /// </summary>
    public partial class workstation
    {
        public workstation()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string workid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from workstation");
            strSql.Append(" where workid=@workid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@workid", MySqlDbType.VarChar,64)           };
            parameters[0].Value = workid;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.workstation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into workstation(");
            strSql.Append("workid,workstationname,remark)");
            strSql.Append(" values (");
            strSql.Append("@workid,@workstationname,@remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@workid", MySqlDbType.VarChar,64),
                    new MySqlParameter("@workstationname", MySqlDbType.VarChar,64),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.workid;
            parameters[1].Value = model.workstationname;
            parameters[2].Value = model.remark;

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
        public bool Update(Maticsoft.Model.workstation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update workstation set ");
            strSql.Append("workstationname=@workstationname,");
            strSql.Append("remark=@remark");
            strSql.Append(" where workid=@workid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@workstationname", MySqlDbType.VarChar,64),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@workid", MySqlDbType.VarChar,64)};
            parameters[0].Value = model.workstationname;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.workid;

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
        public bool Delete(string workid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from workstation ");
            strSql.Append(" where workid=@workid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@workid", MySqlDbType.VarChar,64)           };
            parameters[0].Value = workid;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string workidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from workstation ");
            strSql.Append(" where workid in (" + workidlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.workstation GetModel(string workid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select workid,workstationname,remark from workstation ");
            strSql.Append(" where workid=@workid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@workid", MySqlDbType.VarChar,64)           };
            parameters[0].Value = workid;

            Maticsoft.Model.workstation model = new Maticsoft.Model.workstation();
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
        public Maticsoft.Model.workstation DataRowToModel(DataRow row)
        {
            Maticsoft.Model.workstation model = new Maticsoft.Model.workstation();
            if (row != null)
            {
                if (row["workid"] != null)
                {
                    model.workid = row["workid"].ToString();
                }
                if (row["workstationname"] != null)
                {
                    model.workstationname = row["workstationname"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
            strSql.Append("select workid,workstationname,remark ");
            strSql.Append(" FROM workstation ");
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
            strSql.Append("select count(1) FROM workstation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.workid desc");
            }
            strSql.Append(")AS Row, T.*  from workstation T ");
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
			parameters[0].Value = "workstation";
			parameters[1].Value = "workid";
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


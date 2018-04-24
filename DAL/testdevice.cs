using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:testdevice
    /// </summary>
    public partial class testdevice
    {
        public testdevice()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("devicetype", "testdevice");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int devicetype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from testdevice");
            strSql.Append(" where devicetype=@devicetype ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11)         };
            parameters[0].Value = devicetype;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.testdevice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into testdevice(");
            strSql.Append("devicetype,devicename,devicetest,remark)");
            strSql.Append(" values (");
            strSql.Append("@devicetype,@devicename,@devicetest,@remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11),
                    new MySqlParameter("@devicename", MySqlDbType.VarChar,255),
                    new MySqlParameter("@devicetest", MySqlDbType.VarChar,32),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.devicetype;
            parameters[1].Value = model.devicename;
            parameters[2].Value = model.devicetest;
            parameters[3].Value = model.remark;

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
        public bool Update(Maticsoft.Model.testdevice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update testdevice set ");
            strSql.Append("devicename=@devicename,");
            strSql.Append("devicetest=@devicetest,");
            strSql.Append("remark=@remark");
            strSql.Append(" where devicetype=@devicetype ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devicename", MySqlDbType.VarChar,255),
                    new MySqlParameter("@devicetest", MySqlDbType.VarChar,32),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11)};
            parameters[0].Value = model.devicename;
            parameters[1].Value = model.devicetest;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.devicetype;

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
        public bool Delete(int devicetype)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from testdevice ");
            strSql.Append(" where devicetype=@devicetype ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11)         };
            parameters[0].Value = devicetype;

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
        public bool DeleteList(string devicetypelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from testdevice ");
            strSql.Append(" where devicetype in (" + devicetypelist + ")  ");
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
        public Maticsoft.Model.testdevice GetModel(int devicetype)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select devicetype,devicename,devicetest,remark from testdevice ");
            strSql.Append(" where devicetype=@devicetype ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11)         };
            parameters[0].Value = devicetype;

            Maticsoft.Model.testdevice model = new Maticsoft.Model.testdevice();
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
        public Maticsoft.Model.testdevice DataRowToModel(DataRow row)
        {
            Maticsoft.Model.testdevice model = new Maticsoft.Model.testdevice();
            if (row != null)
            {
                if (row["devicetype"] != null && row["devicetype"].ToString() != "")
                {
                    model.devicetype = int.Parse(row["devicetype"].ToString());
                }
                if (row["devicename"] != null)
                {
                    model.devicename = row["devicename"].ToString();
                }
                if (row["devicetest"] != null)
                {
                    model.devicetest = row["devicetest"].ToString();
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
            strSql.Append("select devicetype,devicename,devicetest,remark ");
            strSql.Append(" FROM testdevice ");
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
            strSql.Append("select count(1) FROM testdevice ");
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
                strSql.Append("order by T.devicetype desc");
            }
            strSql.Append(")AS Row, T.*  from testdevice T ");
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
			parameters[0].Value = "testdevice";
			parameters[1].Value = "devicetype";
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


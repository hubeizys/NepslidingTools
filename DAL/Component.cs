using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:component
    /// </summary>
    public partial class component
    {
        public component()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("componentId", "component");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int componentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from component");
            strSql.Append(" where componentId=@componentId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11)            };
            parameters[0].Value = componentId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into component(");
            strSql.Append("componentId,name,remark,jobnum,ARef,size,sm,photo)");
            strSql.Append(" values (");
            strSql.Append("@componentId,@name,@remark,@jobnum,@ARef,@size,@sm,@photo)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11),
                    new MySqlParameter("@name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,64),
                    new MySqlParameter("@jobnum", MySqlDbType.VarChar,64),
                    new MySqlParameter("@ARef", MySqlDbType.VarChar,64),
                    new MySqlParameter("@size", MySqlDbType.VarChar,64),
                    new MySqlParameter("@sm", MySqlDbType.VarChar,64),
                    new MySqlParameter("@photo", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.componentId;
            parameters[1].Value = model.name;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.jobnum;
            parameters[4].Value = model.ARef;
            parameters[5].Value = model.size;
            parameters[6].Value = model.sm;
            parameters[7].Value = model.photo;

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
        public bool Update(Maticsoft.Model.component model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update component set ");
            strSql.Append("name=@name,");
            strSql.Append("remark=@remark,");
            strSql.Append("jobnum=@jobnum,");
            strSql.Append("ARef=@ARef,");
            strSql.Append("size=@size,");
            strSql.Append("sm=@sm,");
            strSql.Append("photo=@photo");
            strSql.Append(" where componentId=@componentId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,64),
                    new MySqlParameter("@jobnum", MySqlDbType.VarChar,64),
                    new MySqlParameter("@ARef", MySqlDbType.VarChar,64),
                    new MySqlParameter("@size", MySqlDbType.VarChar,64),
                    new MySqlParameter("@sm", MySqlDbType.VarChar,64),
                    new MySqlParameter("@photo", MySqlDbType.VarChar,255),
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.jobnum;
            parameters[3].Value = model.ARef;
            parameters[4].Value = model.size;
            parameters[5].Value = model.sm;
            parameters[6].Value = model.photo;
            parameters[7].Value = model.componentId;

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
        public bool Delete(int componentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from component ");
            strSql.Append(" where componentId=@componentId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11)            };
            parameters[0].Value = componentId;

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
        public bool DeleteList(string componentIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from component ");
            strSql.Append(" where componentId in (" + componentIdlist + ")  ");
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
        public Maticsoft.Model.component GetModel(int componentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select componentId,name,remark,jobnum,ARef,size,sm,photo from component ");
            strSql.Append(" where componentId=@componentId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11)            };
            parameters[0].Value = componentId;

            Maticsoft.Model.component model = new Maticsoft.Model.component();
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
        public Maticsoft.Model.component DataRowToModel(DataRow row)
        {
            Maticsoft.Model.component model = new Maticsoft.Model.component();
            if (row != null)
            {
                if (row["componentId"] != null && row["componentId"].ToString() != "")
                {
                    model.componentId = int.Parse(row["componentId"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["jobnum"] != null)
                {
                    model.jobnum = row["jobnum"].ToString();
                }
                if (row["ARef"] != null)
                {
                    model.ARef = row["ARef"].ToString();
                }
                if (row["size"] != null)
                {
                    model.size = row["size"].ToString();
                }
                if (row["sm"] != null)
                {
                    model.sm = row["sm"].ToString();
                }
                if (row["photo"] != null)
                {
                    model.photo = row["photo"].ToString();
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
            strSql.Append("select componentId,name,remark,jobnum,ARef,size,sm,photo ");
            strSql.Append(" FROM component ");
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
            strSql.Append("select count(1) FROM component ");
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
                strSql.Append("order by T.componentId desc");
            }
            strSql.Append(")AS Row, T.*  from component T ");
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
			parameters[0].Value = "component";
			parameters[1].Value = "componentId";
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


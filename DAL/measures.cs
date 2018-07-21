/**  版本信息模板在安装目录下，可自行修改。
* measures.cs
*
* 功 能： N/A
* 类 名： measures
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/20 22:05:39   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:measures
    /// </summary>
    public partial class measures
    {
        public measures()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "measures");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from measures");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.measures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into measures(");
            strSql.Append("step,Tools,position,standardv,up,down,componentId,CC,devicetype,portid)");
            strSql.Append(" values (");
            strSql.Append("@step,@Tools,@position,@standardv,@up,@down,@componentId,@CC,@devicetype,@portid)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@step", MySqlDbType.Int32,64),
                    new MySqlParameter("@Tools", MySqlDbType.VarChar,64),
                    new MySqlParameter("@position", MySqlDbType.VarChar,64),
                    new MySqlParameter("@standardv", MySqlDbType.VarChar,64),
                    new MySqlParameter("@up", MySqlDbType.VarChar,64),
                    new MySqlParameter("@down", MySqlDbType.VarChar,64),
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11),
                    new MySqlParameter("@CC", MySqlDbType.VarChar,64),
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11),
                    new MySqlParameter("@portid", MySqlDbType.Int32,11)};
            parameters[0].Value = model.step;
            parameters[1].Value = model.Tools;
            parameters[2].Value = model.position;
            parameters[3].Value = model.standardv;
            parameters[4].Value = model.up;
            parameters[5].Value = model.down;
            parameters[6].Value = model.componentId;
            parameters[7].Value = model.CC;
            parameters[8].Value = model.devicetype;
            parameters[9].Value = model.portid;

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
        public bool Update(Maticsoft.Model.measures model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update measures set ");
            strSql.Append("step=@step,");
            strSql.Append("Tools=@Tools,");
            strSql.Append("position=@position,");
            strSql.Append("standardv=@standardv,");
            strSql.Append("up=@up,");
            strSql.Append("down=@down,");
            strSql.Append("componentId=@componentId,");
            strSql.Append("CC=@CC,");
            strSql.Append("devicetype=@devicetype,");
            strSql.Append("portid=@portid");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@step", MySqlDbType.Int32,64),
                    new MySqlParameter("@Tools", MySqlDbType.VarChar,64),
                    new MySqlParameter("@position", MySqlDbType.VarChar,64),
                    new MySqlParameter("@standardv", MySqlDbType.VarChar,64),
                    new MySqlParameter("@up", MySqlDbType.VarChar,64),
                    new MySqlParameter("@down", MySqlDbType.VarChar,64),
                    new MySqlParameter("@componentId", MySqlDbType.Int32,11),
                    new MySqlParameter("@CC", MySqlDbType.VarChar,64),
                    new MySqlParameter("@devicetype", MySqlDbType.Int32,11),
                    new MySqlParameter("@portid", MySqlDbType.Int32,11),
                    new MySqlParameter("@id", MySqlDbType.Int32,64)};
            parameters[0].Value = model.step;
            parameters[1].Value = model.Tools;
            parameters[2].Value = model.position;
            parameters[3].Value = model.standardv;
            parameters[4].Value = model.up;
            parameters[5].Value = model.down;
            parameters[6].Value = model.componentId;
            parameters[7].Value = model.CC;
            parameters[8].Value = model.devicetype;
            parameters[9].Value = model.portid;
            parameters[10].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from measures ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from measures ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Maticsoft.Model.measures GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,step,Tools,position,standardv,up,down,componentId,CC,devicetype,portid from measures ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Maticsoft.Model.measures model = new Maticsoft.Model.measures();
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
        public Maticsoft.Model.measures DataRowToModel(DataRow row)
        {
            Maticsoft.Model.measures model = new Maticsoft.Model.measures();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["step"] != null && row["step"].ToString() != "")
                {
                    model.step = int.Parse(row["step"].ToString());
                }
                if (row["Tools"] != null)
                {
                    model.Tools = row["Tools"].ToString();
                }
                if (row["position"] != null)
                {
                    model.position = row["position"].ToString();
                }
                if (row["standardv"] != null)
                {
                    model.standardv = row["standardv"].ToString();
                }
                if (row["up"] != null)
                {
                    model.up = row["up"].ToString();
                }
                if (row["down"] != null)
                {
                    model.down = row["down"].ToString();
                }
                if (row["componentId"] != null && row["componentId"].ToString() != "")
                {
                    model.componentId = int.Parse(row["componentId"].ToString());
                }
                if (row["CC"] != null)
                {
                    model.CC = row["CC"].ToString();
                }
                if (row["devicetype"] != null && row["devicetype"].ToString() != "")
                {
                    model.devicetype = int.Parse(row["devicetype"].ToString());
                }
                if (row["portid"] != null && row["portid"].ToString() != "")
                {
                    model.portid = int.Parse(row["portid"].ToString());
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
            strSql.Append("select id,step,Tools,position,standardv,up,down,componentId,CC,devicetype,portid ");
            strSql.Append(" FROM measures ");
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
            strSql.Append("select count(1) FROM measures ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from measures T ");
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
			parameters[0].Value = "measures";
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


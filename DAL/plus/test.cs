using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class test
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList2(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT test.*, parts.Barcode  FROM test LEFT JOIN parts ON test.PN = parts.PN  ");
        
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
    }
}

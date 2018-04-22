using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    public partial class baseconfig
    {
        public void backup(string sql)
        {
            //int count =  DbHelperMySQL.ExecuteSql("mysqldump --databases GLLJ > dump.sql");
            DbHelperMySQL.ExecuteSql(sql.ToString());
        }
    }
}

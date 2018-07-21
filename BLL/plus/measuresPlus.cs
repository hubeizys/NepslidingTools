using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class measures
    {        /// <summary>
             /// 分页获取数据列表
             /// </summary>
        public DataSet GetListByPage2(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage2(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetListByPage3(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage3(strWhere, orderby, startIndex, endIndex);
        }
    }
}

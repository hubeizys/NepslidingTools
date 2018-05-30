using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class test
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.test> GetModelList2(string strWhere)
        {
            DataSet ds = dal.GetList2(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList3(string strWhere)
        {
            return dal.GetList3(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount2(string strWhere)
        {
            return dal.GetRecordCount2(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage2(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage2(strWhere, orderby, startIndex, endIndex);
        }
    }
}

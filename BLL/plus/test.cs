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
    }
}

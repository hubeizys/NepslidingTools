using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public partial class baseconfig
    {
        // private readonly Maticsoft.DAL.baseconfig dal = new Maticsoft.DAL.baseconfig();
        public void backup(string sql)
        {
            dal.backup(sql);
        }
    }
}

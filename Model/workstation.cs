using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// workstation:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class workstation
    {
        public workstation()
        { }
        #region Model
        private string _workid;
        private string _workstationname;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string workid
        {
            set { _workid = value; }
            get { return _workid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string workstationname
        {
            set { _workstationname = value; }
            get { return _workstationname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}


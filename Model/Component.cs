using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// component:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class component
    {
        public component()
        { }
        #region Model
        private int _componentid;
        private string _name;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int componentId
        {
            set { _componentid = value; }
            get { return _componentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
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


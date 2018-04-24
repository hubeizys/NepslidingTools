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
        private string _jobnum;
        private string _aref;
        private string _size;
        private string _sm;
        private string _photo;
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
        /// <summary>
        /// 
        /// </summary>
        public string jobnum
        {
            set { _jobnum = value; }
            get { return _jobnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ARef
        {
            set { _aref = value; }
            get { return _aref; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sm
        {
            set { _sm = value; }
            get { return _sm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
        #endregion Model

    }
}


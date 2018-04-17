using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// port:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class port
    {
        public port()
        { }
        #region Model
        private int _id;
        private string _mac;
        private string _workid;
        private string _manufacturer;
        private string _portname;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mac
        {
            set { _mac = value; }
            get { return _mac; }
        }
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
        public string manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string portname
        {
            set { _portname = value; }
            get { return _portname; }
        }
        #endregion Model

    }
}


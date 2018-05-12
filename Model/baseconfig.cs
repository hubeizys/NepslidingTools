using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// baseconfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class baseconfig
    {
        public baseconfig()
        { }
        #region Model
        private string _version;
		private DateTime? _starttime;
        private DateTime? _exptime;
        private string _companyname;
        /// <summary>
        /// 
        /// </summary>
        public string version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? expTime
        {
            set { _exptime = value; }
            get { return _exptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        #endregion Model

    }
}


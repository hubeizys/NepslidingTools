using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// testdevice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class testdevice
    {
        public testdevice()
        { }
        #region Model
        private int _devicetype;
        private string _devicename;
        private string _devicetest;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int devicetype
        {
            set { _devicetype = value; }
            get { return _devicetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string devicename
        {
            set { _devicename = value; }
            get { return _devicename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string devicetest
        {
            set { _devicetest = value; }
            get { return _devicetest; }
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


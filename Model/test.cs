using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// test:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class test
    {
        public test()
        { }
        #region Model
        private int _id;
        private string _pn;
        private string _measureb;
        private DateTime? _time;
        private string _step1;
        private string _okorng;
        private string _workid;
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
        public string PN
        {
            set { _pn = value; }
            get { return _pn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string measureb
        {
            set { _measureb = value; }
            get { return _measureb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string step1
        {
            set { _step1 = value; }
            get { return _step1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OKorNG
        {
            set { _okorng = value; }
            get { return _okorng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string workid
        {
            set { _workid = value; }
            get { return _workid; }
        }
        #endregion Model

    }
}


using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// parts:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class parts
    {
        public parts()
        { }
        #region Model
        private int _id;
        private string _pn;
        private string _name;
        private string _jobnum;
        private string _aref;
        private string _size;
        private string _sm;
        private string _barcode;
        private int? _componentid;
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
        public string name
        {
            set { _name = value; }
            get { return _name; }
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
        public string Barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? componentId
        {
            set { _componentid = value; }
            get { return _componentid; }
        }
        #endregion Model

    }
}


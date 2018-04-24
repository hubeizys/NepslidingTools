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
        private string _barcode;
        private int? _componentid;
        private string _remark;
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


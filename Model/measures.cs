/**  版本信息模板在安装目录下，可自行修改。
* measures.cs
*
* 功 能： N/A
* 类 名： measures
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/20 22:05:39   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// measures:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class measures
    {
        public measures()
        { }
        #region Model
        private int _id;
        private int? _step;
        private string _tools;
        private string _position;
        private string _standardv;
        private string _up;
        private string _down;
        private int? _componentid;
        private string _cc;
        private int? _devicetype;
        private int? _portid;
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
        public int? step
        {
            set { _step = value; }
            get { return _step; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tools
        {
            set { _tools = value; }
            get { return _tools; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string standardv
        {
            set { _standardv = value; }
            get { return _standardv; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string up
        {
            set { _up = value; }
            get { return _up; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string down
        {
            set { _down = value; }
            get { return _down; }
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
        public string CC
        {
            set { _cc = value; }
            get { return _cc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? devicetype
        {
            set { _devicetype = value; }
            get { return _devicetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? portid
        {
            set { _portid = value; }
            get { return _portid; }
        }
        #endregion Model

    }
}


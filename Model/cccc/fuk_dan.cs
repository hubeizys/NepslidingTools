using System;
namespace Maticsoft.Model.cccc
{
	/// <summary>
	/// fuk_dan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fuk_dan
	{
		public fuk_dan()
		{}
		#region Model
		private int _id;
		private string _fkfs;
		private int? _fkjine;
		private string _dxjine;
		private string _bz;
		private string _skdw;
		private string _jsr;
		private string _djbh;
		private DateTime? _shijian;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fkfs
		{
			set{ _fkfs=value;}
			get{return _fkfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? fkjine
		{
			set{ _fkjine=value;}
			get{return _fkjine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dxjine
		{
			set{ _dxjine=value;}
			get{return _dxjine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bz
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string skdw
		{
			set{ _skdw=value;}
			get{return _skdw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jsr
		{
			set{ _jsr=value;}
			get{return _jsr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string djbh
		{
			set{ _djbh=value;}
			get{return _djbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? shijian
		{
			set{ _shijian=value;}
			get{return _shijian;}
		}
		#endregion Model

	}
}


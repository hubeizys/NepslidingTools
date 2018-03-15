using System;
namespace Maticsoft.Model.cccc
{
	/// <summary>
	/// skdan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class skdan
	{
		public skdan()
		{}
		#region Model
		private int _id;
		private string _skfs;
		private int? _skjine;
		private string _dxjine;
		private string _beizhu;
		private string _fkdw;
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
		public string skfs
		{
			set{ _skfs=value;}
			get{return _skfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? skjine
		{
			set{ _skjine=value;}
			get{return _skjine;}
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
		public string beizhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fkdw
		{
			set{ _fkdw=value;}
			get{return _fkdw;}
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


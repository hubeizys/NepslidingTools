using System;
namespace Maticsoft.Model.cccc
{
	/// <summary>
	/// cpinxinxi:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cpinxinxi
	{
		public cpinxinxi()
		{}
		#region Model
		private int _id;
		private int? _cpbianh;
		private string _cgmc;
		private string _xsmc;
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
		public int? cpbianh
		{
			set{ _cpbianh=value;}
			get{return _cpbianh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cgmc
		{
			set{ _cgmc=value;}
			get{return _cgmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xsmc
		{
			set{ _xsmc=value;}
			get{return _xsmc;}
		}
		#endregion Model

	}
}


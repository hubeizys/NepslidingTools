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
		{}
		#region Model
		private int _id;
		private string _ports;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ports
		{
			set{ _ports=value;}
			get{return _ports;}
		}
		#endregion Model

	}
}


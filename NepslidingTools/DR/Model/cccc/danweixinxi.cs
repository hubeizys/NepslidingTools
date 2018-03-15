using System;
namespace Maticsoft.Model.cccc
{
	/// <summary>
	/// danweixinxi:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class danweixinxi
	{
		public danweixinxi()
		{}
		#region Model
		private int _id;
		private string _danwei;
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
		public string danwei
		{
			set{ _danwei=value;}
			get{return _danwei;}
		}
		#endregion Model

	}
}


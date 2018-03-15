using System;
namespace Maticsoft.Model.geli
{
	/// <summary>
	/// usermana:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class usermana
	{
		public usermana()
		{}
		#region Model
		private int _id;
		private string _username;
		private DateTime? _addtime;
		private string _password;
		private string _power;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string power
		{
			set{ _power=value;}
			get{return _power;}
		}
		#endregion Model

	}
}


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
		{}
		#region Model
		private int _id;
		private string _step;
		private string _ tools;
		private string _position;
		private string _standardv;
		private string _up;
		private string _down;
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
		public string step
		{
			set{ _step=value;}
			get{return _step;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string  Tools
		{
			set{ _ tools=value;}
			get{return _ tools;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string standardv
		{
			set{ _standardv=value;}
			get{return _standardv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string up
		{
			set{ _up=value;}
			get{return _up;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string down
		{
			set{ _down=value;}
			get{return _down;}
		}
		#endregion Model

	}
}


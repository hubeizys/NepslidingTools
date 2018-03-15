using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// demand:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class demand
	{
		public demand()
		{}
		#region Model
		private int _id;
		private string _pn;
		private string _measureb;
		private string _testboard;
		private DateTime? _time;
		private string _step1;
		private string _step2;
		private string _step3;
		private string _result;
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
		public string PN
		{
			set{ _pn=value;}
			get{return _pn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string measureb
		{
			set{ _measureb=value;}
			get{return _measureb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string testboard
		{
			set{ _testboard=value;}
			get{return _testboard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string step1
		{
			set{ _step1=value;}
			get{return _step1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string step2
		{
			set{ _step2=value;}
			get{return _step2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string step3
		{
			set{ _step3=value;}
			get{return _step3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string result
		{
			set{ _result=value;}
			get{return _result;}
		}
		#endregion Model

	}
}


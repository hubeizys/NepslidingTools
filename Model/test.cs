using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// test:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class test
	{
		public test()
		{}
		#region Model
		private int _id;
		private string _measureb;
		private DateTime? _time;
		private string _step1;
		private string _step2;
		private string _step3;
		private string _step4;
		private string _step5;
		private string _okorng;
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
		public string measureb
		{
			set{ _measureb=value;}
			get{return _measureb;}
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
		public string step4
		{
			set{ _step4=value;}
			get{return _step4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string step5
		{
			set{ _step5=value;}
			get{return _step5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OKorNG
		{
			set{ _okorng=value;}
			get{return _okorng;}
		}
		#endregion Model

	}
}


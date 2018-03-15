using System;
namespace Maticsoft.Model.cccc
{
	/// <summary>
	/// NEP_table:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NEP_table
	{
		public NEP_table()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _cheshu;
		private int? _dunwei;
		private int? _danjia;
		private int? _jine;
		private string _remarks;
		private string _gonyingdanwei;
		private string _jinshouren;
		private string _dingdanbianhao;
		private string _danjubianhao;
		private DateTime? _lurushijian;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cheshu
		{
			set{ _cheshu=value;}
			get{return _cheshu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dunwei
		{
			set{ _dunwei=value;}
			get{return _dunwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? danjia
		{
			set{ _danjia=value;}
			get{return _danjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? jine
		{
			set{ _jine=value;}
			get{return _jine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gonyingdanwei
		{
			set{ _gonyingdanwei=value;}
			get{return _gonyingdanwei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jinshouren
		{
			set{ _jinshouren=value;}
			get{return _jinshouren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dingdanbianhao
		{
			set{ _dingdanbianhao=value;}
			get{return _dingdanbianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string danjubianhao
		{
			set{ _danjubianhao=value;}
			get{return _danjubianhao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? lurushijian
		{
			set{ _lurushijian=value;}
			get{return _lurushijian;}
		}
		#endregion Model

	}
}


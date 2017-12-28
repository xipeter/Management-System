using System;

namespace Neusoft.HISFC.Object.Registration
{
	/// <summary>
	/// 排班实体
	/// </summary>
	public class Tabulation:Neusoft.NFC.Object.NeuObject
	{
		public Tabulation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 私有变量
		//Memo,ID
		private string arrangeid;
		private string emplid;
		private string deptid;
		private DateTime workdate;
		private string operid;
		private DateTime operdate;
		#endregion

		#region 共有变量
		/// <summary>
		/// 排班序号
		/// </summary>
		public string arrangeID
		{
			get{return arrangeid;}
			set{arrangeid=value;}
		}
		/// <summary>
		/// 员工代码
		/// </summary>
		public string EmplID
		{
			get{return emplid;}
			set{emplid=value;}
		}
		
		/// <summary>
		/// 员工科室
		/// </summary>
		public string DeptID
		{
			get{return deptid;}
			set{deptid=value;}
		}
		/// <summary>
		/// 出勤类别
		/// </summary>
		public WorkType Kind=new WorkType();
		/// <summary>
		/// 出勤日期
		/// </summary>
		public DateTime Workdate
		{
			get{return workdate;}
			set{workdate=value;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int SortID = 0;
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperID
		{
			get{return operid;}
			set{operid=value;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OperDate
		{
			get{return operdate;}
			set{operdate=value;}
		}
		#endregion
		
	}
	/// <summary>
	/// 排班类型实体
	/// </summary>
	public class WorkType:Neusoft.HISFC.Object.Base.Spell
	{		
		public WorkType()
		{
		}
		//ID,Name,Memo
		
		#region 私有变量
		//private string spell;//拼音码
		private string class_code;//出勤大类代码
		private string sign;//简称
		private DateTime begin;//出勤开始时间
		private DateTime end;//出勤结束时间
		private decimal quotiety;//扣款系数
		private decimal positivedays;//出勤权值
		private decimal minusdays;//缺勤权值
		private bool isvalid;//是否有效
		private string operid;//操作员
		private DateTime operdate;//操作日期
		#endregion
		
		#region 公有变量

		
		/// <summary>
		/// 出勤大类代码
		/// </summary>
		public string ClassID
		{
			get{return class_code;}
			set{class_code=value;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string Sign
		{
			get{return sign;}
			set{sign=value;}
		}
		/// <summary>
		/// 出勤开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get{return begin;}
			set{begin=value;}
		}
		/// <summary>
		/// 出勤结束时间
		/// </summary>
		public DateTime EndTime
		{
			get{return end;}
			set{end=value;}
		}
		/// <summary>
		/// 扣款系数
		/// </summary>
		public decimal Quotiety
		{
			get{return quotiety;}
			set{quotiety=value;}
		}
		/// <summary>
		/// 出勤权值
		/// </summary>
		public decimal PositiveDays
		{
			get{return positivedays;}
			set{positivedays=value;}
		}
		/// <summary>
		/// 缺勤权值
		/// </summary>
		public decimal MinusDays
		{
			get{return minusdays;}
			set{minusdays=value;}
		}
		/// <summary>
		/// 前景色
		/// </summary>
		public string ForeColor="";
		/// <summary>
		/// 是否有效
		/// </summary>
		public bool Isvalid
		{
			get{return isvalid;}
			set{isvalid=value;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public string OperID
		{
			get{return operid;}
			set{operid=value;}
		}
		public DateTime OperDate
		{
			get{return operdate;}
			set{operdate=value;}
		}
		#endregion 

		
	}
	public class TabularType:Neusoft.NFC.Object.NeuObject
	{
		/* by MaoKb
		 *05.7.26*/

		public TabularType()
		{
		}
        
		#region 私有变量
		private string empcode;      //1.员工代码
		private string deptcode;     //2.科室代码
		private DateTime workdate;   //3.出勤日期
		//private string name;         //4.出勤类型名称
		private string classcode;    //5.排班大类代码
		private DateTime begin;      //6.出勤开始时间
		private DateTime end;        //7.记结束时间
		private decimal positivedays;//8.出侵权值
		private decimal minusdays;   //9.缺勤权值
		private string opercode;     //10.排班人代码
		private DateTime operdate;   //11.排班日期
		private bool ischecked;      //12.是否审核
		private string remark;       //13.备注
		#endregion

		#region 公有变量
		/// <summary>
		/// 员工代码
		/// </summary>
		public string EmpCode
		{
			get{return empcode;}
			set{empcode=value;}
		}
		public string DeptCode
		{
			get{return deptcode;}
			set{deptcode=value;}
		}
		public DateTime WorkDate
		{
			get{return workdate;}
			set{workdate=value;}
		}

		public string ClassCode
		{
			get{return classcode;}
			set{classcode=value;}
		}
		public DateTime Begin
		{
			get{return begin;}
			set{begin=value;}
		}
		public DateTime End
		{
			get{return end;}
			set{end=value;}
		}
		public decimal PositiveDays
		{
			get{return positivedays;}
			set{positivedays=value;}
		}
		public decimal MinusDays
		{
			get{return minusdays;}
			set{minusdays=value;}
		}
		public string OperCode
		{
			get{return opercode;}
			set{opercode=value;}
		}
		public DateTime OperDate
		{
			get{return operdate;}
			set{operdate=value;}
		}
		public bool IsChecked
		{
			get{return ischecked;}
			set{ischecked=value;}
		}
		public string Remark
		{
			get{return remark;}
			set{remark=value;}
		}
		#endregion
	}

}

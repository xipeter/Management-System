using System;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// MedTechItemTemp 的摘要说明。
	/// 医技预约排班信息
	/// by sunxh
	/// 2005-3-3
	/// 
	/// 项目类     项目 项目预约模板
	///item_code,   --项目代码
	///item_name,   --项目名称
	///unit_flag,   --单位标识
	///dept_code,   --科室号
	///dept_name,   --科室名称
	///week,        --星期
	///noon_code,   --午别
	///book_lmt,   --预约限额
	///specialbook_lmt,   --特诊预约限额
	///valid_flag,   --1有效/0无效
	///remark,   --注意事项
	///oper_code,   --操作员
	///oper_date    --操作日期
	/// </summary>
	public class MedTechItemTemp : neusoft.neuFC.Object.neuObject
	{
		public MedTechItemTemp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 定义量
		string deptName;		//科室名称
		string week;            //星期
		string noonCode;        //午别
		decimal bookLmt;         //预约限额
		decimal specialBookLmt;  //特诊预约限额
		private int conformNum ; //终端确认数
		#endregion

		/// <summary>
		/// 医技预约项目信息
		/// </summary>
		public neusoft.HISFC.Object.MedTech.MedTechItem MedTechItem = new MedTechItem();
		/// <summary>
		/// 终端确认数
		/// </summary>
		public int  ConformNum
		{
			get
			{
				return conformNum;
			}
			set
			{
				conformNum = value;
			}
		}
		/// <summary>
		/// 科室名称
		/// </summary>
		public string DeptName
		{
			get 
			{
				return deptName;
			}
			set
			{
				deptName = value;
			}
		}
		/// <summary>
		/// 星期
		/// </summary>
		public string Week
		{
			get 
			{
				return week;
			}
			set
			{
				week = value;
			}
		}
		/// <summary>
		/// 午别
		/// </summary>
		public string NoonCode
		{
			get 
			{
				return noonCode;
			}
			set
			{
				noonCode = value;
			}
		}
		/// <summary>
		/// 预约限额
		/// </summary>
		public decimal BookLmt
		{
			get 
			{
				return bookLmt;
			}
			set
			{
				bookLmt = value;
			}
		}
		/// <summary>
		/// 特诊预约限额
		/// </summary>
		public decimal SpecialBookLmt
		{
			get 
			{
				return specialBookLmt;
			}
			set
			{
				specialBookLmt = value;
			}
		}

		public new MedTechItemTemp Clone()
		{
			MedTechItemTemp obj = (MedTechItemTemp)base.Clone() ;
			return obj;
		}

	}
}

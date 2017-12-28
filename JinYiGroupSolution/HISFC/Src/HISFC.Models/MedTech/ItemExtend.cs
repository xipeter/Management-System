using System;

namespace neusoft.HISFC.Object.MedTech
{
	/// <summary>
	/// ItemExtend 的摘要说明
	/// 非药品信息的扩展信息
	/// by sunxh
	/// 2005-3-1
	/// 
	/// 项目类     项目 非药品扩展
	/// DeptCode		科室代码  
	/// UnitFlag		单位标识
	/// BookLocate		预约地点
	/// BookDate		预约时间
	/// ExecuteLocate   执行地点
	/// ReportDate		取报告时间
	/// HurtFlag		有创无创
	/// SelfBookFlag	是否科内预约                     
	/// Speciality      所属专业
	/// ClinicMeaning   临床意义
	/// SimpleQty		标本量
	/// SimpleKind		标本
	/// ReasonableFlag  知情同意书
	/// SimpleWay		采样方法
	/// SimpleUnit	    标本单位
	/// Container		容器
	/// Scope			正常值范围
	/// machineType     设备类型
	/// </summary>
	public class ItemExtend :neusoft.neuFC.Object.neuObject
	{
		public ItemExtend()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 定义量

		string deptCode;      //科室代码
		string unitFlag;	  //单位标识
		string bookLocate;	  //预约地点
		string bookDate;	  //预约时间
		string executeLocate; //执行地点
		string reportDate;    //取报告时间
		string hurtFlag;      //有创无创
		string selfBookFlag;  //是否科内预约
		string speciality;    //所属专业
		string clinicMeaning; //临床意义
		decimal simpleQty;     //标本量
		string reasonableFlag;//知情同意书
		string simpleKind;	  //标本
		string simpleWay;     //采样方法
		string simpleUnit;    //标本单位
		string container;     //容器
		string scope;         //正常值范围
		string machineType = "";//设备类型
//		string executeWay = "";//执行方式
		string bloodWay = "";//抽血方式
		string ext1 = "";//扩展1
		string ext2 = "";//扩展2
		string ext3 = "";//扩展3

		#endregion
		/// <summary>
		/// 科室代码
		/// </summary>
		public string DeptCode
		{
			get 
			{
				return deptCode;
			}
			set
			{
				deptCode = value;
			}
		}
		/// <summary>
		/// 单位标识
		/// </summary>
		public string UnitFlag
		{
			get 
			{
				return unitFlag;
			}
			set
			{
				unitFlag = value;
			}
		}
		/// <summary>
		/// 预约地点
		/// </summary>
		public string BookLocate
		{
			get 
			{
				return bookLocate;
			}
			set
			{
				bookLocate = value;
			}
		}
		/// <summary>
		/// 预约时间
		/// </summary>
		public string BookDate
		{
			get 
			{
				return bookDate;
			}
			set
			{
				bookDate = value;
			}

		}

		/// <summary>
		/// 执行地点
		/// </summary>
		public string ExecuteLocate
		{
			get 
			{
				return executeLocate;
			}
			set
			{
				executeLocate = value;
			}

		}

		/// <summary>
		/// 取报告时间
		/// </summary>
		public string ReportDate
		{
			get 
			{
				return reportDate;
			}
			set
			{
				reportDate = value;
			}

		}

		/// <summary>
		/// 有创无创
		/// </summary>
		public string HurtFlag
		{
			get 
			{
				return hurtFlag;
			}
			set
			{
				hurtFlag = value;
			}

		}

		/// <summary>
		/// 是否科内预约
		/// </summary>
		public string SelfBookFlag
		{
			get 
			{
				return selfBookFlag;
			}
			set
			{
				selfBookFlag = value;
			}

		}

		/// <summary>
		/// 所属专业
		/// </summary>
		public string Speciality
		{
			get 
			{
				return speciality;
			}
			set
			{
				speciality = value;
			}

		}

		/// <summary>
		/// 临床意义
		/// </summary>
		public string ClinicMeaning
		{
			get 
			{
				return clinicMeaning;
			}
			set
			{
				clinicMeaning = value;
			}

		}

		/// <summary>
		/// 标本量
		/// </summary>
		public decimal SimpleQty
		{
			get 
			{
				return simpleQty;
			}
			set
			{
				simpleQty = value;
			}

		}

		/// <summary>
		/// 知情同意书
		/// </summary>
		public string ReasonableFlag
		{
			get 
			{
				return reasonableFlag;
			}
			set
			{
				reasonableFlag = value;
			}

		}

		/// <summary>
		/// 采样
		/// </summary>
		public string SimpleKind
		{
			get 
			{
				return simpleKind;
			}
			set
			{
				simpleKind = value;
			}

		}

		/// <summary>
		/// 采样方法
		/// </summary>
		public string SimpleWay
		{
			get 
			{
				return simpleWay;
			}
			set
			{
				simpleWay = value;
			}

		}

		/// <summary>
		/// 标本单位
		/// </summary>
		public string SimpleUnit
		{
			get 
			{
				return simpleUnit;
			}
			set
			{
				simpleUnit = value;
			}

		}

		/// <summary>
		/// 容器
		/// </summary>
		public string Container
		{
			get 
			{
				return container;
			}
			set
			{
				container = value;
			}

		}

		/// <summary>
		/// 正常值范围
		/// </summary>
		public string Scope
		{
			get 
			{
				return scope;
			}
			set
			{
				scope = value;
			}

		}
		/// <summary>
		/// 设备类型
		/// </summary>
		public string MachineType
		{
			get 
			{
				return machineType;
			}
			set
			{
				machineType = value;
			}
		}

		/// <summary>
		/// 抽血方式
		/// </summary>
		public string BloodWay
		{
			get 
			{
				return bloodWay;
			}
			set
			{
				bloodWay = value;
			}
		}
		/// <summary>
		/// 扩展
		/// </summary>
		public string Ext1
		{
			get 
			{
				return ext1;
			}
			set
			{
				ext1 = value;
			}
		}
		/// <summary>
		/// 扩展
		/// </summary>
		public string Ext2
		{
			get 
			{
				return ext2;
			}
			set
			{
				ext2 = value;
			}
		}
		/// <summary>
		/// 扩展
		/// </summary>
		public string Ext3
		{
			get 
			{
				return ext3;
			}
			set
			{
				ext3 = value;
			}
		}
		
		public new ItemExtend Clone()
		{
			ItemExtend obj=base.Clone() as ItemExtend;
			return obj;
		}
	}
}



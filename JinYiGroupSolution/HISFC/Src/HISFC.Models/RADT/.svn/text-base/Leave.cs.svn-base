using System;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Models.RADT
{
	/// <summary>
	/// [功能描述: 请假实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-05]<br></br>
	/// <修改记录
	///		修改人='张立伟'
	///		修改时间='2006-9-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary> 
    [Serializable]
    public class Leave: Neusoft.FrameWork.Models.NeuObject 
	{
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public Leave() 
		{
		}


		#region 变量

		/// <summary>
		/// 请假日期
		/// </summary>
		private System.DateTime leaveTime ;
		
	    /// <summary>
	    /// 请假天数
	    /// </summary>
		private int leaveDays ;
		
		/// <summary>
		/// 准假医生
		/// </summary>
		private string doctCode ;
		
	    /// <summary>
	    /// 操作环境（操作人，操作时间）
	    /// </summary>
		private OperEnvironment oper = new OperEnvironment();
		
		/// <summary>
		/// 休假标志
		/// </summary>
		private string leaveFlag ;
		
		/// <summary>
		/// 消假医生（消假医生编号，消假时间）
		/// </summary>
		private OperEnvironment cancelOper = new OperEnvironment() ;
		

		#endregion

		#region 属性
		/// <summary>
		/// 请假时间
		/// </summary>
		public System.DateTime LeaveTime 
		{
			get
			{
				return this.leaveTime;
			}
			set
			{
				this.leaveTime = value;
			}
		}


		/// <summary>
		/// 请假天数
		/// </summary>
		public int LeaveDays {
			get
			{
				return this.leaveDays;
			}
			set
			{
				this.leaveDays = value;
			}
		}


		/// <summary>
		/// 给假医生
		/// </summary>
		public string DoctCode {
			get
			{
				return this.doctCode; 
			}
			set
			{
				this.doctCode = value; 
			}
		}


		/// <summary>
		/// 请假操作人
		/// </summary>
		public OperEnvironment Oper {
			get
			{
				return this.oper; 
			}
			set
			{
				this.oper = value;
			}
		}

		/// <summary>
		/// 0请假 1消假,作废
		/// </summary>
		public string LeaveFlag {
			get
			{
				
				return this.leaveFlag; 
			}
			set
			{
				this.leaveFlag = value; 
			}
		}


		/// <summary>
		/// 消假人(作废操作人)
		/// </summary>
		public OperEnvironment CancelOper {
			get
			{
				return this.cancelOper; 
			}
			set
			{
				this.cancelOper = value; 
			}
		}

		#endregion
		
		#region 方法
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Leave Clone()
		{
			Leave leave = base.Clone() as Leave;
			leave.Oper=this.Oper.Clone();
			leave.CancelOper = this.CancelOper.Clone();
			return leave;
		}
		
		#endregion

		#region 过期
		/// <summary>
		/// 请假时间
		/// </summary>
		[System.Obsolete("更改为 LeaveTime",true)]
		public System.DateTime LeaveDate ;

		/// <summary>
		/// 请假操作人
		/// </summary>
		[System.Obsolete("更改为 this.Oper.Oper.ID",true)]
		public string OperCode ;
        
		/// <summary>
		/// 消假人(作废操作人)
		/// </summary>
		[System.Obsolete("更改为 this.CancelOper.Oper.ID",true)]
		public string CancelOpcd ;
	
		/// <summary>
		/// 消假时间(作废时间)
		/// </summary>
		[System.Obsolete("更改为 this.CancelOper.OperTime",true)]
		public System.DateTime CancelDate ;
	
		#endregion
	}
}

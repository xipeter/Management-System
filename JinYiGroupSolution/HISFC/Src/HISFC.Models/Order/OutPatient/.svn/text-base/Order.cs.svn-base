using System;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.Models;
namespace Neusoft.HISFC.Models.Order.OutPatient
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.OutPatient.Order<br></br>
	/// [功能描述: 门诊医嘱资料实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///		/>
	/// </summary>
    [Serializable]
    public class Order:Neusoft.HISFC.Models.Order.Order
	{
		public Order()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		#region 私有

		/// <summary>
		/// 看诊序号
		/// </summary>
		private string seeno;

		/// <summary>
		/// 收费序列
		/// </summary>
		private string recipeSeq;

		/// <summary>
		/// 挂号日期
		/// </summary>
		private DateTime regDate;

		/// <summary>
		/// 项目费用信息
		/// </summary>
		private FT ft = new FT();

		/// <summary>
		/// 收费人员
		/// </summary>
		private Base.OperEnvironment chargeOper = new OperEnvironment();

		/// <summary>
		/// 确认人
		/// </summary>
		private Base.OperEnvironment confirmOper = new OperEnvironment();

		/// <summary>
		/// 是否已经收费
		/// </summary>
		protected bool isHaveCharged = false;

		/// <summary>
		/// 是否需要终端确认
		/// </summary>
		private bool isNeedConfirm = false;
		#endregion

		#endregion

		#region 属性

		/// <summary>
		/// 看诊序号
		/// </summary>
		public string SeeNO
		{
			get
			{
				return this.seeno;
			}
			set
			{
				this.seeno = value;
			}
		}

		/// <summary>
		/// 收费序列
		/// </summary>
		public  string ReciptSequence
		{
			get
			{
				return this.recipeSeq;
			}
			set
			{
				this.recipeSeq = value;
			}
		}

		/// <summary>
		/// 挂号日期
		/// </summary>
		public DateTime RegTime
		{
			get
			{
				return this.regDate;
			}
			set
			{
				this.regDate = value;
			}
		}

		/// <summary>
		/// 项目费用信息
		/// </summary>
		public FT FT
		{
			get
			{
				return ft;
			}
			set
			{
				this.ft = value;
			}
		}

		/// <summary>
		/// 收费人员
		/// </summary>
		public Base.OperEnvironment ChargeOper
		{
			get
			{
				return this.chargeOper;
			}
			set
			{
				this.chargeOper = value;
			}
		}

		/// <summary>
		/// 确认人
		/// </summary>
		public Base.OperEnvironment ConfirmOper
		{
			get
			{
				return this.confirmOper;		
			}
			set
			{
				this.confirmOper = value;
			}
		}

		/// <summary>
		/// 是否已经收费
		/// </summary>
		public bool IsHaveCharged
		{
			get
			{
				return isHaveCharged ;
			}
			set
			{
				isHaveCharged = value;
			}
		}

		/// <summary>
		/// 是否需要终端确认
		/// </summary>
		public bool IsNeedConfirm
		{
			get
			{
				return this.isNeedConfirm;
			}
			set
			{
				this.isNeedConfirm = value;
			}
		}
		#endregion

		#region 作废的

		/// <summary>
		/// 看诊序号
		/// </summary>
		[Obsolete("用SeeNO",true)]
		public string SeeNo 
		{
			get
			{
				return seeno;
			}
			set
			{
				seeno = value;
			}
		}

		/// <summary>
		/// 项目内流水号
		/// </summary>
		[Obsolete("用SequenceNO",true)]
		public int SeqNo
		{
			get
			{
				return int.Parse(base.ID);
			}
			set
			{
				base.ID  = value.ToString();
			}
		}

		/// <summary>
		/// 收费序列
		/// </summary>
		[Obsolete("用ReciptSequence",true)]
		public  string RecipeSeq
		{
			get
			{
				return this.recipeSeq;
			}
			set
			{
				this.recipeSeq = value;
			}
		}

		/// <summary>
		/// 挂号日期
		/// </summary>
		[Obsolete("用RegTime",true)]
		public DateTime RegDate
		{
			get
			{
				return regDate;
			}
			set
			{
				regDate = value;
			}
		}

		/// <summary>
		/// 收费者
		/// </summary>
		[Obsolete("用ChargeOper.Oper代替",true)]
		public NeuObject ChargeUser=new NeuObject();
		/// <summary>
		/// 收费科室
		/// </summary>
		[Obsolete("用ChargeOper.Dept代替",true)]
		public NeuObject ChargeDept=new NeuObject();
		/// <summary>
		/// 收费时间
		/// </summary>
		[Obsolete("用ChargeOper.OperTime代替",true)]
		public DateTime ChargeTime;

		/// <summary>
		/// 确认科室
		/// </summary>
		[Obsolete("用ConfirmOper.Dept代替",true)]
		public NeuObject ComfirmDept = new NeuObject();
		/// <summary>
		/// 确认人
		/// </summary>
		[Obsolete("用ConfirmOper.Oper代替",true)]
		public NeuObject User_Comfirm = new NeuObject();
		
		#endregion

		#region 方法

		#region 克隆
		
		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new Order Clone()
		{
			// TODO:  添加 Order.Clone 实现
			Order obj = base.Clone() as Order;
			obj.chargeOper = this.chargeOper.Clone();
			obj.confirmOper = this.confirmOper.Clone();
			obj.ft = this.ft.Clone();
			return obj;
		}

		#endregion

		#endregion
	
	}
}

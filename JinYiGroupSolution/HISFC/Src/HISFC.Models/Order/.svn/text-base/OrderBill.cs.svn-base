using System;
//using Neusoft.NFC;
using Neusoft.HISFC;

namespace Neusoft.HISFC.Models.Order
{
	/// <summary>
	/// Neusoft.HISFC.Models.Order.OrderBill<br></br>
	/// [功能描述: 医嘱单的实体]<br></br>
	/// [创 建 者: 李云凡]<br></br>
	/// [创建时间: 2006-09-10]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间='yyyy-mm-dd'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
    [Serializable]
    public class OrderBill:Neusoft.FrameWork.Models.NeuObject
	{
		public OrderBill()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 变量

		/// <summary>
		/// 患者医嘱实体
		/// </summary>
		private Neusoft.HISFC.Models.Order.Inpatient.Order order = new Inpatient.Order();

		/// <summary>
		/// 医嘱单页号
		/// </summary>
		private int pageNO;

		/// <summary>
		/// 医嘱单行号
		/// </summary>
		private int   lineno;

		/// <summary>
		/// 医嘱开立打印标单
		/// </summary>
		private string Prnflag;
		
		/// <summary>
		/// 打印操作者
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment printOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 打印停止标记
		/// </summary>
		private string printDCFlag ;

		/// <summary>
		/// 医嘱整理次数
		/// </summary>
		private int moTimes;

		/// <summary>
		/// 医嘱整理时间
		/// </summary>
		private DateTime moTime;

		/// <summary>
		/// 操作员，操作时间
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment oper = new Neusoft.HISFC.Models.Base.OperEnvironment();

        /// <summary>
        /// 打印序号
        /// </summary>
        private int printSequence;

		#endregion

		#region 属性
		///<summary>
		///聚合病人医嘱实体
		///</summary>
		public Neusoft.HISFC.Models.Order.Inpatient.Order Order 
		{
			get
			{
				return this.order;
			}
			set
			{
				this.order = value;
			}
		}

		/// <summary>
		/// 医嘱单页号
		/// </summary>
		public int   PageNO
		{
			get
			{
				return this.pageNO;
			}
			set
			{
				this.pageNO = value;
			}
		}

		/// <summary>
		/// 医嘱单行号
		/// </summary>
		public int LineNO
		{
			get
			{
				return this.lineno;
			}
			set
			{
				this.lineno = value;
			}
		}
		
		/// <summary>
		///  医嘱开立打印标单
		/// </summary>
		public string PrintFlag
		{
			get
			{
				return this.Prnflag;
			}
			set
			{
				this.Prnflag = value;
			}
		}
	
		/// <summary>
		/// 打印操作者
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment  PrintOper
		{
			get
			{
				return this.printOper;
			}
			set
			{
				this.printOper = value;
			}
		}

		/// <summary>
		/// 打印停止标记
		/// </summary>
		public string PrintDCFlag
		{
			get
			{
				return this.printDCFlag;
			}
			set
			{
				this.printDCFlag = value;
			}
		}

		/// <summary>
		/// 医嘱整理次数
		/// </summary>
		public int MOTimes
		{
			get
			{
				return this.moTimes;
			}
			set
			{
				this.moTimes = value;
			}
		}

		/// <summary>
		/// 医嘱整理时间
		/// </summary>
		public DateTime MOTime
		{
			get
			{
				return this.moTime;
			}
			set
			{
				this.moTime = value;
			}
		}

		/// <summary>
		/// 操作员，操作时间
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment Oper
		{
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
        /// 打印序号
        /// </summary>
        public int PrintSequence
        {
            get 
            { 
                return this.printSequence; 
            }
            set
            {
                this.printSequence = value;
            }
        }

		#endregion

		#region 作废
		/// <summary>
		/// 医嘱整理时间
		/// </summary>
		[Obsolete("用MOTime代替",true)]
		public DateTime MoDidt;
		/// <summary>
		/// 医嘱整理次数
		/// </summary>
		[Obsolete("用MOTimes代替",true)]
		public int      MoTimes;
		/// <summary>
		/// 打印日期
		/// </summary>
		[Obsolete("用PrintOper.Oper.OperTime代替",true)]
		public DateTime  PrnDate;
                
		/// <summary>
		/// 停止医嘱打印标志
		/// </summary>
		[Obsolete("用PrintDCFlag代替",true)]
		public string    PrnDcflag;
			/// <summary>
		/// 打印人
		/// </summary>
		[Obsolete("用PrintOper.Oper.ID代替",true)]
		public string    PrnUserCD;
		
		/// <summary>
		///提取操作员 
		/// </summary>
		[Obsolete("用Oper.Oper.ID代替",true)]
		public string   OperCode;
		
		/// <summary>
		/// 提取时间
		/// </summary>
		[Obsolete("用Oper.OperTime代替",true)]
		public DateTime OperDate;
	
		#endregion

		#region 方法

		#region 克隆

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		public new OrderBill Clone()
		{
			// TODO:  添加 Order.Clone 实现
			OrderBill obj=base.Clone() as OrderBill;
			obj.Order  = this.Order.Clone();
			obj.oper = this.oper.Clone();
			obj.printOper = this.printOper.Clone();
			return obj;
		}

		#endregion

		#endregion

   }
	
}

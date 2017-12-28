using System;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Models.Pharmacy
{
	/// <summary>
	/// Copyright (C) 2004 东软股份有限公司
	/// 版权所有
	/// 
	/// 文件名：DrugRecipe.cs
	/// 文件功能描述：门诊摆药处方(处方调剂)实体
	/// 
	/// 
	/// 创建标识：梁俊泽 2005-11
	/// 创建说明：ID 发药药房编码 Name 发药药房名称
	/// 
	/// 
	/// 修改标识：梁俊泽 2006-04
	/// 修改描述：修改Sex属性为Sex类
	/// 
	/// 
	/// 
	/// 修改标识：梁俊泽 2006-09
	/// 修改描述：程序整合
	/// </summary>
    [Serializable]
    public class DrugRecipe : Neusoft.FrameWork.Models.NeuObject,Neusoft.HISFC.Models.Base.IValidState
	{
		public DrugRecipe()
		{
			
		}
		
		
		#region 变量		

		/// <summary>
		/// 处方号
		/// </summary>
		private string recipeNo = "";

		/// <summary>
		/// 出库申请分类(权限类型 Class3_Menaing_Code) 门诊 M1 发药 M2 退、还药
		/// </summary>
		private string systemType = "";

		/// <summary>
		/// 交易类型 1 正交易 2 反交易
		/// </summary>
		private string transType = "";

		/// <summary>
		/// 处方状态: 0申请,1打印,2配药,3发药,4还药(当天未发的药品返回)
		/// </summary>
		private string recipeState = "";

		/// <summary>
		/// 门诊号
		/// </summary>
		private string clinicCode = "";

		/// <summary>
		/// 病历卡号
		/// </summary>
		private string cardNo = "";

		/// <summary>
		/// 患者姓名
		/// </summary>
		private string patientName = "";

		/// <summary>
		/// 性别
		/// </summary>
		Neusoft.HISFC.Models.Base.SexEnumService sex = new Neusoft.HISFC.Models.Base.SexEnumService();

		/// <summary>
		/// 年龄
		/// </summary>
		DateTime age = DateTime.MinValue;

		/// <summary>
		/// 挂号日期
		/// </summary>
		DateTime regDate = DateTime.MinValue;

		/// <summary>
		/// 结算类别
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject payKind = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 患者科室
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject patientDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 开方医生
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject doct = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 开方医生科室
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject doctDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 配药终端
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject drugTerminal = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 发药终端
		/// </summary>
		Neusoft.FrameWork.Models.NeuObject sendTerminal = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 配/发药科室
		/// </summary>
		private Neusoft.FrameWork.Models.NeuObject drugDept = new Neusoft.FrameWork.Models.NeuObject();

		/// <summary>
		/// 收费操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment feeOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 发票号
		/// </summary>
		string invoiceNo;

		/// <summary>
		/// 处方金额
		/// </summary>
		decimal cost;

		/// <summary>
		/// 处方内药品品种数量
		/// </summary>
		decimal recipeNum;

		/// <summary>
		/// 已配药药品品种数量
		/// </summary>
		decimal drugedNum;

		/// <summary>
		/// 配药操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment drugedOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
		
		/// <summary>
		/// 发药操作信息
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment sendOper = new Neusoft.HISFC.Models.Base.OperEnvironment();
		
		/// <summary>
		/// 还药人
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment backOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 取消人
		/// </summary>
		private Neusoft.HISFC.Models.Base.OperEnvironment cancelOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

		/// <summary>
		/// 是否退改药
		/// </summary>
		private bool isModify;

        /// <summary>
        /// 有效状态  0 有效 1 无效  2 发药后退药
        /// 改后状态 0 无效 1 有效 2 发药后退药
        /// </summary>
        Neusoft.HISFC.Models.Base.EnumValidState validState = Neusoft.HISFC.Models.Base.EnumValidState.Valid;

        /// <summary>
        /// 处方内药品剂数合计
        /// </summary>
        decimal sumDays;
		#endregion

		/// <summary>
		/// 处方号
		/// </summary>
		public string RecipeNO
		{
			get
			{
				return this.recipeNo;
			}
			set
			{
				this.recipeNo = value;
			}
		}


		/// <summary>
		/// 出库申请分类(权限类型 Class3_Menaing_Code) 门诊 M1 发药 M2 退、还药
		/// </summary>
		public string SystemType
		{
			get
			{
				return this.systemType;
			}
			set
			{
				this.systemType = value;
			}
		}


		/// <summary>
		/// 交易类型 1 正交易 2 反交易
		/// </summary>
		public string TransType
		{
			get
			{
				return this.transType;
			}
			set
			{
				this.transType = value;
			}
		}


		/// <summary>
		/// 处方状态: 0申请,1打印,2配药,3发药,4还药(当天未发的药品返回)
		/// </summary>
		public string RecipeState
		{
			get
			{
				return this.recipeState;
			}
			set
			{
				this.recipeState = value;
			}
		}


		/// <summary>
		/// 门诊号
		/// </summary>
		public string ClinicNO
		{
			get
			{
				return this.clinicCode;
			}
			set
			{
				this.clinicCode = value;
			}
		}


		/// <summary>
		/// 病历卡号
		/// </summary>
		public string CardNO
		{
			get
			{
				return this.cardNo;
			}
			set
			{
				this.cardNo = value;
			}
		}


		/// <summary>
		/// 患者姓名
		/// </summary>
		public string PatientName
		{
			get
			{
				return this.patientName;
			}
			set
			{
				this.patientName = value;
			}
		}


		/// <summary>
		/// 性别
		/// </summary>
		public Neusoft.HISFC.Models.Base.SexEnumService Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}


		/// <summary>
		/// 年龄
		/// </summary>
		public DateTime Age
		{
			get
			{
				return this.age;
			}
			set
			{
				this.age = value;
			}
		}


		/// <summary>
		/// 结算类别
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PayKind
		{
			get
			{
				return this.payKind;
			}
			set
			{
				this.payKind = value;
			}
		}


		/// <summary>
		/// 患者科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject PatientDept
		{
			get
			{
				return this.patientDept;
			}
			set
			{
				this.patientDept = value;
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
		/// 开方医生
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject Doct
		{
			get
			{
				return this.doct;
			}
			set
			{
				this.doct = value;
			}
		}


		/// <summary>
		/// 开方医生科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DoctDept
		{
			get
			{
				return this.doctDept;
			}
			set
			{
				this.doctDept = value;
			}
		}


		/// <summary>
		/// 配药终端
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject DrugTerminal
		{
			get
			{
				return this.drugTerminal;
			}
			set
			{
				this.drugTerminal = value;
			}
		}


		/// <summary>
		/// 发药终端
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject SendTerminal
		{
			get
			{
				return this.sendTerminal;
			}
			set
			{
				this.sendTerminal = value;
			}
		}


		/// <summary>
		/// 操作员收费信息
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment FeeOper
		{
			get
			{
				return this.feeOper;
			}
			set
			{
				this.feeOper = value;
			}
		}


		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNO
		{
			get
			{
				return this.invoiceNo;
			}
			set
			{
				this.invoiceNo = value;
			}
		}


		/// <summary>
		/// 处方金额
		/// </summary>
		public decimal Cost
		{
			get
			{
				return this.cost;
			}
			set
			{
				this.cost = value;
			}
		}


		/// <summary>
		/// 处方内药品品种数量
		/// </summary>
		public decimal RecipeQty
		{
			get
			{
				return this.recipeNum;
			}
			set
			{
				this.recipeNum = value;
			}
		}


		/// <summary>
		/// 已配药药品品种数量
		/// </summary>
		public decimal DrugedQty
		{
			get
			{
				return this.drugedNum;
			}
			set
			{
				this.drugedNum = value;
			}
		}


		/// <summary>
		/// 配药人
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment DrugedOper
		{
			get
			{
				return this.drugedOper;
			}
			set
			{
				this.drugedOper = value;
			}
		}


		/// <summary>
		/// 发药人
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment SendOper
		{
			get
			{
				return this.sendOper;
			}
			set
			{
				this.sendOper = value;
			}
		}
		

		/// <summary>
		/// 配/发药科室
		/// </summary>
		public Neusoft.FrameWork.Models.NeuObject StockDept
		{
			get
			{
				return this.drugDept;
			}
			set
			{
				this.drugDept = value;
				this.ID = value.ID;
				this.Name = value.Name;
			}
		}


		/// <summary>
		/// 退/改药状态 0 否 1 是
		/// </summary>
		public bool IsModify
		{
			get
			{
				return this.isModify;
			}
			set
			{
				this.isModify = value;
			}
		}


		/// <summary>
		/// 还药人
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment BackOper
		{
			get
			{
				return this.backOper;
			}
			set
			{
				this.backOper = value;
			}
		}


		/// <summary>
		/// 取消人
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment CancelOper
		{
			get
			{
				return this.cancelOper;
			}
			set
			{
				this.cancelOper = value;
			}
		}


        /// <summary>
        /// 有效状态  0 有效 1 无效  2 发药后退药
        /// 有效状态  0 无效 1 有效  2 发药后退药
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumValidState ValidState
        {
            get
            {
                return this.validState;
            }
            set
            {
                this.validState = value;
            }
        }

        /// <summary>
        /// 处方内药品剂数合计
        /// </summary>
        public decimal SumDays
        {
            get
            {
                return this.sumDays;
            }
            set
            {
                this.sumDays = value;
            }
        }

		#region 方法

		/// <summary>
		/// 克隆函数
		/// </summary>
		/// <returns>成功返回当前实例的副本</returns>
		public new DrugRecipe Clone()
		{
			DrugRecipe drugRecipe = base.Clone() as DrugRecipe;
			
			drugRecipe.Sex = this.Sex.Clone();
			drugRecipe.PayKind = this.PayKind.Clone();
			drugRecipe.PatientDept = this.PatientDept.Clone();
			drugRecipe.Doct = this.Doct.Clone();
			drugRecipe.DoctDept = this.DoctDept.Clone();
			drugRecipe.DrugTerminal = this.DrugTerminal.Clone();
			drugRecipe.SendTerminal = this.SendTerminal.Clone();
			drugRecipe.FeeOper = this.FeeOper.Clone();
			drugRecipe.DrugedOper = this.DrugedOper.Clone();
			drugRecipe.SendOper = this.SendOper.Clone();
			drugRecipe.StockDept = this.StockDept.Clone();
			drugRecipe.BackOper = this.BackOper.Clone();
			drugRecipe.CancelOper = this.CancelOper.Clone();

			return drugRecipe;
			
		}


		#endregion

		#region 无效属性

		/// <summary>
		/// 收费时间
		/// </summary>
		DateTime feeDate;

		/// <summary>
		/// 配药日期
		/// </summary>
		DateTime drugedDate;

		/// <summary>
		/// 发药日期
		/// </summary>
		DateTime sendDate;

		


		/// <summary>
		/// 处方号
		/// </summary>
		[System.Obsolete("程序整合 更改为RecipeNO属性")]
		public string RecipeNo
		{
			get
			{
				return this.recipeNo;
			}
			set
			{
				this.recipeNo = value;
			}
		}


		/// <summary>
		/// 门诊号
		/// </summary>
		[System.Obsolete("程序整合 更改为ClinicNO属性",true)]
		public string ClinicCode
		{
			get
			{
				return this.clinicCode;
			}
			set
			{
				this.clinicCode = value;
			}
		}


		/// <summary>
		/// 病历卡号
		/// </summary>
		[System.Obsolete("程序整合 更改为CardNO属性",true)]
		public string CardNo
		{
			get
			{
				return this.cardNo;
			}
			set
			{
				this.cardNo = value;
			}
		}


		/// <summary>
		/// 挂号日期
		/// </summary>
		[System.Obsolete("程序整合 更改为RegTime属性",true)]
		public DateTime RegDate
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
		/// 收费时间
		/// </summary>
		[System.Obsolete("程序整合 更改为OperEnvironment类型的FeeOper属性",true)]
		public DateTime FeeDate
		{
			get
			{
				return this.feeDate;
			}
			set
			{
				this.feeDate = value;
			}
		}


		/// <summary>
		/// 发票号
		/// </summary>
		[System.Obsolete("程序整合 更改为InvoiceNO属性",true)]
		public string InvoiceNo
		{
			get
			{
				return this.invoiceNo;
			}
			set
			{
				this.invoiceNo = value;
			}
		}


		/// <summary>
		/// 处方内药品品种数量
		/// </summary>
		[System.Obsolete("程序整合 更改为RecipeQty属性",true)]
		public decimal RecipeNum
		{
			get
			{
				return this.recipeNum;
			}
			set
			{
				this.recipeNum = value;
			}
		}


		/// <summary>
		/// 已配药药品品种数量
		/// </summary>
		[System.Obsolete("程序整合 更改为DrugedQty属性")]
		public decimal DrugedNum
		{
			get
			{
				return this.drugedNum;
			}
			set
			{
				this.drugedNum = value;
			}
		}


		/// <summary>
		/// 配药日期
		/// </summary>
		[System.Obsolete("程序整合 更改为DrugedOper属性",true)]
		public DateTime DrugedDate
		{
			get
			{
				return this.drugedDate;
			}
			set
			{
				this.drugedDate = value;
			}
		}


		/// <summary>
		/// 发药日期
		/// </summary>
		[System.Obsolete("程序整合 更改为SendOper属性")]
		public DateTime SendDate
		{
			get
			{
				return this.sendDate;
			}
			set
			{
				this.sendDate = value;
			}
		}


		/// <summary>
		/// 配/发药科室
		/// </summary>
		[System.Obsolete("程序整合 更改为StockDept属性",true)]
		public Neusoft.FrameWork.Models.NeuObject DrugDept
		{
			get
			{
				return this.drugDept;
			}
			set
			{
				this.drugDept = value;
				this.ID = value.ID;
				this.Name = value.Name;
			}
		}
		

		/// <summary>
		/// 还药时间
		/// </summary>
		[System.Obsolete("程序整合 更改为BackOper属性",true)]
		public DateTime BackDate;

		/// <summary>
		/// 取消时间
		/// </summary>
		[System.Obsolete("程序整合 更改为CancelOper属性")]
		public DateTime CancelDate;

		/// <summary>
		/// 退/改药状态 0 否 1 是
		/// </summary>
		[System.Obsolete("程序整合 更改为Bool类型的IsModify属性")]
		public string ModifyState;

		#endregion

		
	}
}

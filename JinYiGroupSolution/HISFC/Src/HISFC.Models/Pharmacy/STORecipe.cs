using System;

namespace Neusoft.HISFC.Object.Pharmacy
{
	/// <summary>
	/// STORecipe 的摘要说明。
	/// 门诊摆药处方(处方调剂)实体
	/// </summary>
	public class STORecipe:Neusoft.NFC.Object.NeuObject
	{
		public STORecipe()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
		/// <summary>
		/// 处方号
		/// </summary>
		public string RecipeNo;
		/// <summary>
		/// 出库申请分类(权限类型 Class3_Menaing_Code) 门诊 M1 发药 M2 退、还药
		/// </summary>
		public string SystemType;
		/// <summary>
		/// 交易类型 1 正交易 2 反交易
		/// </summary>
		public string TransType;
		/// <summary>
		/// 处方状态: 0申请,1打印,2配药,3发药,4还药(当天未发的药品返回)
		/// </summary>
		public string RecipeState;
		/// <summary>
		/// 门诊号
		/// </summary>
		public string ClinicCode;
		/// <summary>
		/// 病历卡号
		/// </summary>
		public string CardNo;
		/// <summary>
		/// 患者姓名
		/// </summary>
		public string PatientName;
		/// <summary>
		/// 性别
		/// </summary>
		public string SexCode;
		/// <summary>
		/// 年龄
		/// </summary>
		public DateTime Age;
		/// <summary>
		/// 结算类别
		/// </summary>
		public Neusoft.NFC.Object.NeuObject PayKind;
		/// <summary>
		/// 患者科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject PatientDept;
		/// <summary>
		/// 挂号日期
		/// </summary>
		public DateTime RegDate;
		/// <summary>
		/// 开方医生
		/// </summary>
		public Neusoft.NFC.Object.NeuObject Doct;
		/// <summary>
		/// 开方医生科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject DoctDept;
		/// <summary>
		/// 配药终端
		/// </summary>
		public Neusoft.NFC.Object.NeuObject DrugTerminal;
		/// <summary>
		/// 发药终端
		/// </summary>
		public Neusoft.NFC.Object.NeuObject SendTerminal;
		/// <summary>
		/// 收费人编码(申请编码)
		/// </summary>
		public string FeeOper;
		/// <summary>
		/// 收费时间
		/// </summary>
		public DateTime FeeDate;
		/// <summary>
		/// 发票号
		/// </summary>
		public string InvoiceNo;
		/// <summary>
		/// 处方金额
		/// </summary>
		public decimal Cost;
		/// <summary>
		/// 处方内药品品种数量
		/// </summary>
		public decimal RecipeNum;
		/// <summary>
		/// 已配药药品品种数量
		/// </summary>
		public decimal DrugedNum;
		/// <summary>
		/// 配药人
		/// </summary>
		public string DrugedOper;
		/// <summary>
		/// 配药科室
		/// </summary>
		public string DrugedDept;
		/// <summary>
		/// 配药日期
		/// </summary>
		public DateTime DrugedDate;
		/// <summary>
		/// 发药人
		/// </summary>
		public string SendOper;
		/// <summary>
		/// 发药科室
		/// </summary>
		public Neusoft.NFC.Object.NeuObject SendDept;
		/// <summary>
		/// 发药日期
		/// </summary>
		public DateTime SendDate;
		/// <summary>
		/// 有效状态  0 有效 1 无效
		/// </summary>
		public string ValidState;
		/// <summary>
		/// 退/改药状态 0 否 1 是
		/// </summary>
		public string ModifyState;
		/// <summary>
		/// 还药人
		/// </summary>
		public string BackOper;
		/// <summary>
		/// 还药时间
		/// </summary>
		public DateTime BackDate;
		/// <summary>
		/// 取消人
		/// </summary>
		public string CancelOper;
		/// <summary>
		/// 取消时间
		/// </summary>
		public DateTime CancelDate;


	}
}

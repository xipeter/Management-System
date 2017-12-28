using System;
using System.Collections;
using neusoft.HISFC.Object.Check;
using neusoft.HISFC.Object.Fee.OutPatient;
using neusoft.neuFC.Object;

namespace neusoft.HISFC.Management.Fee
{
	/// <summary>
	/// 为体检划价提供服务。
	/// 1、保存、修改和删除体检划价明细
	/// </summary>
	public class CheckUp:neusoft.neuFC.Management.Database
	{
		/// <summary>
		/// 
		/// </summary>
		public CheckUp()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 变量定义
		/// <summary>
		/// 存储方法调用的返回值
		/// </summary>
		int intReturn = 0;
		/// <summary>
		/// 药品类
		/// </summary>
		neusoft.HISFC.Object.Pharmacy.Item drug = new Object.Pharmacy.Item();
		/// <summary>
		/// 非药品方法类
		/// </summary>
		neusoft.HISFC.Management.Fee.Item undrugFunction = new Item();
		neusoft.HISFC.Object.Fee.Item undrug = new Object.Fee.Item();
		/// <summary>
		/// 门诊患者类
		/// </summary>
		neusoft.HISFC.Management.Fee.OutPatient outPatient = new OutPatient();
		/// <summary>
		/// 药品总共费用
		/// </summary>
		decimal drugCost = 0;
		/// <summary>
		/// 非药品总费用
		/// </summary>
		decimal undrugCost = 0;
		/// <summary>
		/// 处方定价总金额
		/// </summary>
		decimal priceCost = 0;
		/// <summary>
		/// 非药品实收金额
		/// </summary>
		decimal realCost = 0;
		string clinicNo = "";
		#endregion

		#region 设置错误信息
		/// <summary>
		/// 设置错误信息
		/// </summary>
		/// <param name="errorCode">错误号</param>
		/// <param name="errorText">错误信息文本</param>
		public void SetError(string errorCode,string errorText)
		{
			this.ErrCode = errorCode;
			this.Err = errorText;
		}
		#endregion

		#region 体检划价
		/// <summary>
		/// 体检划价
		/// 1、形成FeeItemList：MakeFeeItemList
		/// 2、分配项目应收金额（PAY_COST）（收费项目在体检中心定价）
		///		2.1 药品按照销售价格分配（PHA_COM_BASEINFO）
		///		2.2 非药品按照剩余金额平均分配（FIN_COM_UNDRUGINFO）
		/// 3、分配项目实收金额（OWN_COST）（实际应该收取患者）
		///		3.1 药品按照销售价格分配（PHA_COM_BASEINFO）
		///		3.2 非药品按照剩余金额平均分配（FIN_COM_UNDRUGINFO）
		///	4、计算项目减免/优惠金额（ECO_COST）（收费时如果有减免，那么ECO_COST=PAY_COST-OWN_COST）
		///		4.1 药品没有减免金额
		///		4.2 非药品按照平均分配
		/// </summary>
		/// <param name="checkUpRegister">体检顾客类（包括应收金额）</param>
		/// <param name="checkUpFeeList">FeeItemList类的ArrayList</param>
		/// <param name="ownCost">自付金额（实收）</param>
		/// <param name="shouldCost">处方应收金额</param>
		/// <param name="t">事务</param>
		/// <returns>1：成功；-1：没有处方</returns>
		public int CheckUpFee(ChkRegister checkUpRegister,ArrayList checkUpFeeList,Decimal ownCost,Decimal shouldCost,
			neusoft.neuFC.Management.Transaction t)
		{
			this.drugCost = 0;
			this.undrugCost = 0;
			this.realCost = 0;
			this.priceCost = 0;
			clinicNo = "";
			undrugFunction.SetTrans(t.Trans);
			outPatient.SetTrans(t.Trans);
			int j = 0;
			// 形成FeeItemList
//			j = MakeFeeItemList(ref checkUpFeeList,checkUpRegister,t);
//			if (j<=0)
//			{
//				this.SetError("200001","没有用于划价的处方！");
//				return -1;
//			}
			if(checkUpFeeList == null)
			{
				return -1;
			}
			foreach(neusoft.HISFC.Object.Fee.OutPatient.FeeItemList obj in checkUpFeeList)
			{
				if(!obj.isPharmacy)
				{
					j++;
					undrugCost = obj.Price * obj.Amount;
				}
				else
				{
					drugCost = obj.Price * obj.Amount;
				}
			}
			// 计算项目总金额
			priceCost = this.drugCost + this.undrugCost;
			// 计算非药品项目划价的实收金额
			realCost = ownCost - drugCost;
			// 删除现有未收费的处方明细
			try
			{
				this.outPatient.DeleteFeeDetail(this.clinicNo);
			}
			catch
			{
				this.SetError("200003","删除处方明细失败！");
				t.Trans.Rollback();
				return -3;
			}
			// 分配非药品费用，插入处方表
			foreach(neusoft.HISFC.Object.Fee.OutPatient.FeeItemList fee in checkUpFeeList)
			{
				if (fee.isPharmacy)
				{
					
				}
				else
				{
					fee.Cost.Pay_Cost = Decimal.Round(realCost/j,2); // 自付金额
					fee.Cost.Own_Cost = fee.Cost.Pay_Cost; // 现金
					fee.Cost.Dereate_Cost = 0; // 优惠金额
				}
				this.intReturn = this.outPatient.InsertFeeDetail(fee,true); // 体检插入处方明细
				if (this.intReturn<=0)
				{
					this.Err = "插入处方表失败:" + outPatient.Err;
					this.SetError("200002","插入处方表失败！");
					return -2;
				}
			}
			return 1;
		}
		#endregion

		#region 形成FeeItemList
		/// <summary>
		/// 形成完整FeeItemList
		/// </summary>
		/// <param name="checkUpFeeList">体检处方的ArrayList</param>
		/// <param name="checkUpRegister">体检顾客类</param>
		/// <param name="t">事务</param>
		/// <returns>1：成功；-1：失败</returns>
		private int MakeFeeItemList(ref ArrayList checkUpFeeList,ChkRegister checkUpRegister ,neusoft.neuFC.Management.Transaction t)
		{
//			int i = 1;
			int j = 0;
//			string recipeNO = ""; // 处方号
//			string clinicCode = ""; // 门诊号
//			outPatient.SetTrans(t.Trans);
//            recipeNO = outPatient.GetRecipeNo(); // 取处方号
//			this.clinicNo = checkUpRegister.ChkClinicNo;
//
//			// 循环每一条处方，设置每一条处方明细
//			foreach(neusoft.HISFC.Object.Fee.OutPatient.FeeItemList fee in checkUpFeeList)
//			{
//				fee.ID = fee.ID; // 项目编号
//				fee.Name = fee.Name; // 项目名称
//				fee.RecipeNo = recipeNO; // 处方号
//				fee.SeqNo = i; // 处方内流水号
//				fee.TransType = neusoft.HISFC.Object.Base.TransTypes.Positive; // 交易类型
//				fee.ClinicCode = checkUpRegister.ChkClinicNo; // 门诊号
//				fee.CardNo = checkUpRegister.PatientInfo.Patient.Card.ID; // 病历卡号
//				fee.RegDate = checkUpRegister.CheckDate; // 挂号日期
//				fee.RegDeptInfo.ID = ""; // 挂号科室编号
//				fee.RegDeptInfo.Name = ""; // 挂号科室名称
//				fee.DoctDeptInfo.ID = ""; // 开方医生所在科室编码
//				fee.Qty = fee.Qty; // 数量
//				if (fee.Qty==0) fee.Qty = 1;
//				fee.Days = fee.Days; // 草药付数
//				fee.IsUrgent = fee.IsUrgent; // 是否加急
//				fee.LabTypeInfo = fee.LabTypeInfo; // 样本类型
//				fee.Cost.Pub_Cost = 0; // 可报销金额
//				fee.ExeDeptInfo = fee.ExeDeptInfo; // 执行科室
//				fee.CombNo = fee.CombNo; // 组合号
//				fee.ChargeOperInfo = this.Operator; // 划价人信息
//				fee.ChargeDate = this.GetDateTimeFromSysDateTime(); // 划价时间
//				fee.PayType = neusoft.HISFC.Object.Base.PayTypes.Charged; // 收费标志
//				fee.CancelType = neusoft.HISFC.Object.Base.CancelTypes.Valid; // 状态
//				fee.IsConfirm = false; // 确认标志
//				if (fee.isPharmacy) // 药品
//				{
//					this.drug = this.drugFunction.GetItem(fee.ID);
//					fee.Name = drug.Name;
//					fee.Specs = drug.Specs; // 规格
//					fee.IsSelfMade = drug.IsSelfMade; // 自制药标志
//					fee.DrugQualityInfo = new neuObject(); // 药品性质
//					fee.DoseInfo = drug.DosageForm; // 剂型
//					fee.Price = drug.Price; // 价格
//					fee.FreqInfo = drug.Frequency; // 频次
//					fee.UsageInfo = drug.Usage; // 用法
//					fee.InjectCount = fee.InjectCount; // 院注次数
//					fee.MinFee = drug.MinFee; // 最小费用代码
//					fee.DoseOnce = drug.OnceDose; // 每次用量
//					fee.DoseUnit = drug.DoseUnit; // 每次用量单位
//					fee.BaseDose = drug.BaseDose; // 基本剂量
//					fee.PackQty = drug.PackQty; // 包装数量
//					fee.PriceUnit = drug.PriceUnit; // 计价单位
//					fee.Cost.Pay_Cost = fee.Price*fee.Qty; // 自付金额
//					fee.Cost.Own_Cost = fee.Price*fee.Qty; // 现金
//					fee.CenterInfo = new Object.InterfaceSi.Item(); // 医保对照信息
//					fee.IsMainDrug = false; // 主药标志
//					fee.Cost.Dereate_Cost = 0; // 减免金额
//					drugCost = drugCost + fee.Cost.Own_Cost; // 药品总金额
//				}
//				else // 非药品
//				{
//					j++; // 用来计算非药品处方明细个数
//					undrug = undrugFunction.GetItem(fee.ID);
//					fee.Name = undrug.Name; // 名称
//					fee.Price = undrug.Price; // 价格
//					fee.MinFee = undrug.MinFee; // 最小费用代码
//					fee.CheckBody = undrug.DefaultSample; // 检体
//					fee.Cost.Pay_Cost = 0; // 自付金额
//					fee.Cost.Own_Cost = 0; // 现金
//					fee.Cost.Dereate_Cost = 0; // 减免金额
//					undrugCost = undrugCost + fee.Price*fee.Qty; // 非药品总金额
//				}
//				i++;
//			}
			return j;
		}
		#endregion

		#region 体检收费：更新fin_opb_feedetail
		/// <summary>
		/// 体检收费：更新fin_opb_feedetail
		/// </summary>
		/// <param name="parm">更新用传送到SQL中的参数</param>
		/// <returns>1：成功；-1：获取SQL失败；-2：SQL语句格式化失败：-3：SQL语句执行失败</returns>
		public int UpdateFeeDetail(string [] parm)
		{
			string SQL = "";
			// 设置、获取SQL语句
			if (this.Sql.GetSql("neusoft.HISFC.Management.Fee.CheckUp.UpdateFeeDetail",ref SQL)==-1)
			{
				this.Err = "获取更新SQL：neusoft.HISFC.Management.Fee.CheckUp.UpdateFeeDetail失败";
				return -1;
			}
			try
			{
				SQL = string.Format(SQL,parm);
			}
			catch(Exception e)
			{
				this.Err = "SQL语句FORMAT失败" + e.Message;
				return -2;
			}
			
			// 执行更新语句
			try
			{
				this.ExecNoQuery(SQL);
			}
			catch(Exception e)
			{
				this.Err = "SQL语句执行失败" + e.Message;
				return -3;
			}
			return 1;
		}
		#endregion

		#region 体检收费插入收费结算支付情况表FIN_OPB_PAYMODE
		/// <summary>
		/// 体检收费插入收费结算支付情况表FIN_OPB_PAYMODE
		/// </summary>
		/// <param name="parms">字段值</param>
		/// <returns>1：成功</returns>
		public int InsertFinOpbPayMode(string [] parms)
		{
			string SQL = "";
			// 设置、获取SQL语句
			if (this.Sql.GetSql("neusoft.HISFC.Management.Fee.CheckUp.InsertFinOpbPayMode",ref SQL)==-1)
			{
				this.Err = "获取更新SQL：neusoft.HISFC.Management.Fee.CheckUp.InsertFinOpbPayMode失败";
				return -1;
			}
			try
			{
				SQL = string.Format(SQL,parms);
			}
			catch(Exception e)
			{
				this.Err = "SQL语句FORMAT失败" + e.Message;
				return -2;
			}
			
			// 执行更新语句
			try
			{
				this.ExecNoQuery(SQL);
			}
			catch(Exception e)
			{
				this.Err = "SQL语句执行失败" + e.Message;
				return -3;
			}
			return 1;
		}
		#endregion

	}
}

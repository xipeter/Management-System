using System;
using System.Collections;
using System.Data;
using Neusoft.HISFC.Models;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Registration;
using Neusoft.HISFC.Models.Fee.Outpatient;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.BizLogic.Fee
{
	/// <summary>
	/// Outpatient<br></br>
	/// [功能描述: 门诊费用业务类]<br></br>
	/// [创 建 者: 王宇]<br></br>
	/// [创建时间: 2006-10-15]<br></br>
	/// <修改记录 
	///		修改人='' 
	///		修改时间='yyyy-mm-dd' 
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public class Outpatient:Neusoft.FrameWork.Management.Database
	{
		
		#region 私有函数
		
		#region 日结信息操作
			
		/// <summary>
		/// 获得日结实体SQL
		/// </summary>
		/// <returns>成功: 查询日结的SELECT部分 失败: null</returns>
		private string GetSqlDayBalance() 
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.Outpatient.GetSqlPayMode", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.Outpatient.GetSqlPayMode的SQL语句";

				return null;
			}

			return sql;
		}
		
		/// <summary>
		/// 根据SQL语句和参数列表获得日结信息数组
		/// </summary>
		/// <param name="sql">查询SQL语句</param>
		/// <param name="args">SQL语句参数</param>
		/// <returns>成功:日结信息数组 失败 null 没有查找到数据 元素数为0的ArrayList</returns>
		private ArrayList QueryDayBalanceBySql(string sql, params string[] args)
		{	
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}

			ArrayList dayBalances = new ArrayList();//日结信息数组
			
			DayBalance dayBalance ;//日结信息实体
			
			try
			{   //循环读取数据
				while (this.Reader.Read()) 
				{
					dayBalance = new DayBalance();
				
					dayBalance.ID = this.Reader[0].ToString();//日结序号
					dayBalance.BeginTime = NConvert.ToDateTime(this.Reader[1].ToString());//开始时间
					dayBalance.EndTime = NConvert.ToDateTime(this.Reader[2].ToString());//结束时间
					dayBalance.FT.TotCost = NConvert.ToDecimal(this.Reader[3].ToString());//总收入
					dayBalance.Oper.ID = this.Reader[4].ToString();//收款员代码
					dayBalance.Oper.Name = this.Reader[5].ToString();//收款员名称
					dayBalance.Oper.Memo = this.Reader[6].ToString();//操作日期
					dayBalance.User01 = this.Reader[7].ToString();//操作日期
					dayBalance.User02 = this.Reader[8].ToString();//备注1
					dayBalance.User03 = this.Reader[9].ToString();//备注2
					if (this.Reader[10].ToString() == "1")
					{
						dayBalance.IsAuditing = true;
					}
					else
					{
						dayBalance.IsAuditing = false;
					}
					dayBalance.AuditingOper.ID = this.Reader[11].ToString();//核查人
					dayBalance.AuditingOper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());//核查日期

					dayBalances.Add(dayBalance);
					
				}//循环结束
				
				this.Reader.Close();

				return dayBalances;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
		}

		/// <summary>
		/// 获得支付情况实体数组
		/// </summary>
		/// <param name="dayBalance"></param>
		/// <returns></returns>
		private string [] GetDayBalanceParams(DayBalance dayBalance)
		{
			string[] args = 
				{	
					dayBalance.ID ,//日结序号
					dayBalance.BeginTime.ToString(),//开始时间
					dayBalance.EndTime.ToString(),//结束时间
					dayBalance.FT.TotCost.ToString(),//总收入
					dayBalance.Oper.ID,//收款员代码
					dayBalance.Oper.Name,//收款员名称
					dayBalance.Oper.Memo,//操作日期
					dayBalance.User01,//;
					dayBalance.User02,//
					dayBalance.User03 ,
					dayBalance.IsAuditing ? "1" : "0",
					dayBalance.AuditingOper.ID,
					dayBalance.AuditingOper.OperTime.ToString() 
				};

			return args;
		}

		#endregion

		#region 结算支付信息操作

		/// <summary>
		/// 获得支付情况表的sql语句
		/// </summary>
		/// <returns>成功: 查询支付的SELECT部分 失败: null</returns>
		private string GetBalancePaySelectSql()
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.OutPatient.GetSqlPayMode",ref sql) == -1 )
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetSqlPayMode的SQL语句";

				return null;
			}
			
			return sql;
		}

		/// <summary>
		/// 获得支付方式数组
		/// </summary>
		/// <param name="sql">查询SQL语句</param>
		/// <param name="args">SQL参数</param>
		/// <returns>成功:获得支付方式数组 失败:null 没有查找到数据: 元素数为0的ArrayList</returns>
		private ArrayList QueryBalancePaysBySql(string sql, params string[] args) 
		{
			//执行SQL语句
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}

			ArrayList balancePays = new ArrayList();//支付方式信息
			BalancePay balancePay;//支付方式实体
			
			try
			{
				//循环读取数据
				while (this.Reader.Read()) 
                {
					balancePay = new BalancePay();
				
					balancePay.Invoice.ID = this.Reader[0].ToString();//,	--		发票号
					if(this.Reader[1].ToString()=="2")//交易类型
					{
						balancePay.TransType = TransTypes.Negative;
					}
					else
					{
						balancePay.TransType = TransTypes.Positive;
					}
					balancePay.Squence = this.Reader[2].ToString();//交易流水号
					balancePay.PayType.ID = this.Reader[3].ToString();//支付方式
					balancePay.FT.TotCost = NConvert.ToDecimal(this.Reader[4].ToString());//应付金额
					balancePay.FT.RealCost = NConvert.ToDecimal(this.Reader[5].ToString());//实付金额
					balancePay.Bank.ID = this.Reader[6].ToString();//银行号
					balancePay.Bank.Name = this.Reader[7].ToString();//名
					balancePay.Bank.Account = this.Reader[8].ToString();//帐号
					balancePay.POSNO = this.Reader[9].ToString();//pos号
					balancePay.Bank.InvoiceNO = this.Reader[10].ToString();//支票号
					balancePay.InputOper.ID = this.Reader[11].ToString();//结算人
                    balancePay.InputOper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());//结算时间
					//是否核查
					if (this.Reader[13].ToString() == "1")
					{
						balancePay.IsAuditing = true;
					}
					else
					{
						balancePay.IsAuditing = false;
					}	
					balancePay.AuditingOper.ID = this.Reader[14].ToString();
					balancePay.AuditingOper.OperTime = NConvert.ToDateTime(this.Reader[15].ToString());//检查时间
					balancePay.IsDayBalanced = NConvert.ToBoolean(this.Reader[16].ToString());//是否日结
					balancePay.BalanceOper.ID = this.Reader[18].ToString();//日结人
					//是否对帐
					if(this.Reader[19].ToString()=="1")
					{
						balancePay.IsChecked = true;
					}
					else
					{
						balancePay.IsChecked = false;
					}
					balancePay.CheckOper.ID = this.Reader[20].ToString();//对帐人
					balancePay.CheckOper.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());//对帐时间
					balancePay.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString());//日结时间
                    balancePay.InvoiceCombNO = this.Reader[23].ToString();//发票序号
                    balancePay.CancelType = (CancelTypes)NConvert.ToInt32(this.Reader[24].ToString());
                    balancePay.InvoiceUnion = this.Reader[25].ToString();
					balancePays.Add(balancePay);
				}//循环结束

				this.Reader.Close();

				return balancePays;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
		}
		/// <summary>
		/// 获得支付情况实体数组
		/// </summary>
		/// <param name="balancePay"></param>
		/// <returns></returns>
		private string [] GetBalancePayParams(BalancePay balancePay)
		{
			string[] args = 
				{	
					balancePay.Invoice.ID,
					((int)balancePay.TransType).ToString(),
					balancePay.Squence.ToString(),
					balancePay.PayType.ID.ToString(),
					balancePay.FT.TotCost.ToString(),
					balancePay.FT.RealCost.ToString(),
					balancePay.Bank.ID,
					balancePay.Bank.Name,
					balancePay.Bank.Account,
					balancePay.POSNO,
					balancePay.Bank.InvoiceNO,
					balancePay.InputOper.ID ,
					balancePay.InputOper.OperTime.ToString(),
					balancePay.IsAuditing?"1":"0",
					balancePay.AuditingOper.ID,
					balancePay.AuditingOper.OperTime.ToString(),
					NConvert.ToInt32(balancePay.IsDayBalanced).ToString(),
					"",
					balancePay.BalanceOper.ID,
					NConvert.ToInt32(balancePay.IsChecked).ToString(),
					balancePay.CheckOper.ID,//对帐人
					balancePay.CheckOper.OperTime.ToString(),//对帐时间
					balancePay.BalanceOper.OperTime.ToString(), //;//日结时间
                    balancePay.InvoiceCombNO,
                    ((int)balancePay.CancelType).ToString(),
                    balancePay.InvoiceUnion
				};

			return args;
		}

		/// <summary>
		/// 根据Where条件的索引查询支付信息
		/// </summary>
		/// <param name="whereIndex">Where条件索引</param>
		/// <param name="args">参数</param>
		/// <returns>成功:支付信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		private ArrayList QueryBalancePays(string whereIndex, params string[] args)
		{
			string sql = string.Empty;//SELECT语句
			string where = string.Empty;//WHERE语句
			
			//获得Where语句
			if (this.Sql.GetSql(whereIndex, ref where) == - 1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return null;
			}

			sql = this.GetBalancePaySelectSql();

			return this.QueryBalancePaysBySql(sql + " " + where, args);
		}

		#endregion

		#region 处方明细检索
		
		/// <summary>
		/// 获得处方明细的sql语句
		/// </summary>
		/// <returns>返回查询费用明细SQL语句</returns>
		private string GetSqlFeeDetail() 
		{
			string sql = string.Empty;//查询SQL语句的SELECT部分

			if (this.Sql.GetSql("Fee.Item.GetFeeItem",ref sql) == -1)
			{
				this.Err = "没有找到索引为Fee.Item.GetFeeItem的SQL语句";

				return null;
			}

			return sql;
		}

		/// <summary>
		/// 通过SQL语句获得费用明细信息
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="args">SQL参数</param>
		/// <returns>成功:费用明细集合 失败: null 没有查找到数据: 元素数为0的ArrayList</returns>
		private ArrayList QueryFeeDetailBySql(string sql, params string[] args) 
		{
			if(this.ExecQuery(sql, args) == -1)
			{
				return null;
			}
			
			ArrayList feeItemLists = new ArrayList();//费用明细数组
			FeeItemList feeItemList = null;//费用明细实体

			try
			{
				//循环读取数据
				while (this.Reader.Read()) 
				{
					feeItemList = new FeeItemList();

                    //feeItemList.Item.IsPharmacy = NConvert.ToBoolean(this.Reader[11].ToString());

                    feeItemList.Item.ItemType = (EnumItemType)NConvert.ToInt32(this.Reader[11]);

                    //if (feeItemList.Item.IsPharmacy)
                    if(feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        feeItemList.Item = new Neusoft.HISFC.Models.Pharmacy.Item();
                        feeItemList.Item.ItemType = EnumItemType.Drug;
                        //feeItemList.Item.IsPharmacy = true;
                    }
                    //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    else if (feeItemList.Item.ItemType == EnumItemType.UnDrug)
                    {
                        feeItemList.Item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                        //feeItemList.Item.IsPharmacy = false;
                        feeItemList.Item.ItemType = EnumItemType.UnDrug;
                    }
                    //物资 {40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
                    else
                    {
                        feeItemList.Item = new Neusoft.HISFC.Models.FeeStuff.MaterialItem();
                        feeItemList.Item.ItemType = EnumItemType.MatItem;

                    }

					feeItemList.RecipeNO = this.Reader[0].ToString();		
					feeItemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());
					if (this.Reader[2].ToString() == "1")
					{
						feeItemList.TransType = TransTypes.Positive;
					}
					else
					{
						feeItemList.TransType = TransTypes.Negative;
					}
					feeItemList.Patient.ID = this.Reader[3].ToString();
					feeItemList.Patient.PID.CardNO = this.Reader[4].ToString();	
					((Register)feeItemList.Patient).DoctorInfo.SeeDate = NConvert.ToDateTime(this.Reader[5].ToString());
					((Register)feeItemList.Patient).DoctorInfo.Templet.Dept.ID = this.Reader[6].ToString();
					feeItemList.RecipeOper.ID = this.Reader[7].ToString();
                    ((Register)feeItemList.Patient).DoctorInfo.Templet.Doct.ID = this.Reader[7].ToString();
					feeItemList.RecipeOper.Dept.ID = this.Reader[8].ToString();
					feeItemList.Item.ID = this.Reader[9].ToString();
					feeItemList.Item.Name = this.Reader[10].ToString();
                    feeItemList.Item.Specs = this.Reader[12].ToString();

                    //if (feeItemList.Item.IsPharmacy)
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).Product.IsSelfMade = NConvert.ToBoolean(this.Reader[13].ToString());
                        ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).Quality.ID = this.Reader[14].ToString();
                        ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).DosageForm.ID = this.Reader[15].ToString();
                    }
					feeItemList.Item.MinFee.ID = this.Reader[16].ToString();
					feeItemList.Item.SysClass.ID = this.Reader[17].ToString();
					feeItemList.Item.Price = NConvert.ToDecimal(this.Reader[18].ToString());
					feeItemList.Item.Qty = NConvert.ToDecimal(this.Reader[19].ToString());
					feeItemList.Days = NConvert.ToDecimal(this.Reader[20].ToString());
					feeItemList.Order.Frequency.ID = this.Reader[21].ToString();
					feeItemList.Order.Usage.ID = this.Reader[22].ToString();
					feeItemList.Order.Usage.Name = this.Reader[23].ToString();
					feeItemList.InjectCount = NConvert.ToInt32(this.Reader[24].ToString());
					feeItemList.IsUrgent = NConvert.ToBoolean(this.Reader[25].ToString());
					feeItemList.Order.Sample.ID = this.Reader[26].ToString();
					feeItemList.Order.CheckPartRecord = this.Reader[27].ToString();
					feeItemList.Order.DoseOnce = NConvert.ToDecimal(this.Reader[28].ToString());
					feeItemList.Order.DoseUnit = this.Reader[29].ToString();
                    //if (feeItemList.Item.IsPharmacy)
                    if (feeItemList.Item.ItemType == EnumItemType.Drug)
                    {
                        ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).BaseDose = NConvert.ToDecimal(this.Reader[30].ToString());
                    }
					feeItemList.Item.PackQty = NConvert.ToDecimal(this.Reader[31].ToString());
					feeItemList.Item.PriceUnit = this.Reader[32].ToString();
					feeItemList.FT.PubCost = NConvert.ToDecimal(this.Reader[33].ToString());
					feeItemList.FT.PayCost = NConvert.ToDecimal(this.Reader[34].ToString());
					feeItemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[35].ToString());
					feeItemList.ExecOper.Dept.ID = this.Reader[36].ToString();
					feeItemList.ExecOper.Dept.Name = this.Reader[37].ToString();
					feeItemList.Compare.CenterItem.ID = this.Reader[38].ToString();
					feeItemList.Compare.CenterItem.ItemGrade = this.Reader[39].ToString();
					feeItemList.Order.Combo.IsMainDrug = NConvert.ToBoolean(this.Reader[40].ToString());
					feeItemList.Order.Combo.ID = this.Reader[41].ToString();
					feeItemList.ChargeOper.ID = this.Reader[42].ToString();
					feeItemList.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[43].ToString());
					feeItemList.PayType = (PayTypes)(NConvert.ToInt32(this.Reader[44].ToString()));
					feeItemList.CancelType = (CancelTypes)(NConvert.ToInt32(this.Reader[45].ToString()));
					feeItemList.FeeOper.ID = this.Reader[46].ToString();
					feeItemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[47].ToString());
					feeItemList.Invoice.ID = this.Reader[48].ToString();
					feeItemList.Invoice.Type.ID = this.Reader[49].ToString();
					feeItemList.IsConfirmed = NConvert.ToBoolean(this.Reader[51].ToString());
					feeItemList.ConfirmOper.ID = this.Reader[52].ToString();
					feeItemList.ConfirmOper.Dept.ID = this.Reader[53].ToString();
					feeItemList.ConfirmOper.OperTime = NConvert.ToDateTime(this.Reader[54].ToString());
					feeItemList.InvoiceCombNO = this.Reader[55].ToString();
					feeItemList.NewItemRate = NConvert.ToDecimal(this.Reader[56].ToString());
					feeItemList.OrgItemRate = NConvert.ToDecimal(this.Reader[57].ToString());
					feeItemList.ItemRateFlag = this.Reader[58].ToString();
					feeItemList.Item.SpecialFlag1 = this.Reader[59].ToString();
					feeItemList.Item.SpecialFlag2 = this.Reader[60].ToString();
					feeItemList.FeePack = this.Reader[61].ToString();
					feeItemList.UndrugComb.ID = this.Reader[62].ToString();
					feeItemList.UndrugComb.Name = this.Reader[63].ToString();
					feeItemList.NoBackQty = NConvert.ToDecimal(this.Reader[64].ToString());
					feeItemList.ConfirmedQty = NConvert.ToDecimal(this.Reader[65].ToString());
					feeItemList.ConfirmedInjectCount = NConvert.ToInt32(this.Reader[66].ToString());
					feeItemList.Order.ID = this.Reader[67].ToString();
					feeItemList.RecipeSequence = this.Reader[68].ToString();
					feeItemList.FT.RebateCost = NConvert.ToDecimal(this.Reader[69].ToString());
					feeItemList.SpecialPrice = NConvert.ToDecimal(this.Reader[70].ToString());
					feeItemList.FT.ExcessCost = NConvert.ToDecimal(this.Reader[71].ToString());
					feeItemList.FT.DrugOwnCost = NConvert.ToDecimal(this.Reader[72].ToString());
					feeItemList.FTSource = this.Reader[73].ToString();
					feeItemList.Item.IsMaterial = NConvert.ToBoolean(this.Reader[74].ToString());
                    feeItemList.IsAccounted = NConvert.ToBoolean(this.Reader[75].ToString());
                    //{143CA424-7AF9-493a-8601-2F7B1D635026}
                    //物资出库流水号
                    feeItemList.UpdateSequence = NConvert.ToInt32(this.Reader[76].ToString());
                    //账户患者账号
                    feeItemList.AccountNO = this.Reader[77].ToString();
					feeItemLists.Add(feeItemList);
				}//循环结束

				this.Reader.Close();

				return feeItemLists;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}
				
				return null;
			}
		}
		
		/// <summary>
		/// 根据Where条件的索引查询费用明细信息
		/// </summary>
		/// <param name="whereIndex">Where条件索引</param>
		/// <param name="args">参数</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		private ArrayList QueryFeeItemLists(string whereIndex, params string[] args)
		{
			string sql = string.Empty;//SELECT语句
			string where = string.Empty;//WHERE语句
			
			//获得Where语句
			if (this.Sql.GetSql(whereIndex, ref where) == - 1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return null;
			}

			sql = this.GetSqlFeeDetail();

			return this.QueryFeeDetailBySql(sql + " " + where, args);
		}

		/// <summary>
		/// 获得insert表的传入参数数组update
		/// </summary>
		/// <param name="feeItemList">费用明细实体</param>
		/// <returns>字符串数组</returns>
		private string[] GetFeeItemListParams(FeeItemList feeItemList)
		{
			//{143CA424-7AF9-493a-8601-2F7B1D635027}
            string[] args = new string[78];					 
			
			args[0] = feeItemList.RecipeNO;//RECIPE_NO,	--		处方号							0
			args[1] = feeItemList.SequenceNO.ToString();	  //SEQUENCE_NO;	--		处方内项目流水号				1
			args[2] = ((int)feeItemList.TransType).ToString();//TRANS_TYPE;	--		交易类型;1正交易，2反交易		2
			args[3] = feeItemList.Patient.ID;//CLINIC_CODE;	--		门诊号								3	
			args[4] = feeItemList.Patient.PID.CardNO;//CARD_NO;	--		病历卡号									4		
			args[5] = ((Neusoft.HISFC.Models.Registration.Register)feeItemList.Patient).DoctorInfo.SeeDate.ToString();//REG_DATE;	--		挂号日期						5	
			args[6] = ((Neusoft.HISFC.Models.Registration.Register)feeItemList.Patient).DoctorInfo.Templet.Dept.ID;//REG_DPCD;	--		挂号科室							6	
			args[7] = feeItemList.RecipeOper.ID;//DOCT_CODE;	--		开方医师							7
			args[8] = feeItemList.RecipeOper.Dept.ID;//DOCT_DEPT;	--		开方医师所在科室				8
			args[9] = feeItemList.Item.ID;//ITEM_CODE;	--		项目代码									9.
			args[10] = feeItemList.Item.Name;//ITEM_NAME;	--		项目名称									10
			//args[11] = NConvert.ToInt32(feeItemList.Item.IsPharmacy).ToString();//DRUG_FLAG;	--		1药品/0非要					11
            args[11] = ((int)(feeItemList.Item.ItemType)).ToString();
			args[12] = feeItemList.Item.Specs;//SPECS;		--		规格										12
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
            {
                args[13] = NConvert.ToInt32(((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).Product.IsSelfMade).ToString();//SELF_MADE;	--		自制药标志					13
                args[14] = ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).Quality.ID;//DRUG_QUALITY;	--		药品性质，麻药，普药		14	
                args[15] = ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).DosageForm.ID;//DOSE_MODEL_CODE;--		剂型							15.
            }
            args[16] = feeItemList.Item.MinFee.ID;//FEE_CODE;	--		最小费用代码							16	
			args[17] = feeItemList.Item.SysClass.ID.ToString();//CLASS_CODE;	--		系统类别				17	
			args[18] = feeItemList.Item.Price.ToString();//UNIT_PRICE;	--		单价							18	
			args[19] = feeItemList.Item.Qty.ToString();//QTY;		--		数量								19	
			args[20] = feeItemList.Days.ToString() ;//DAYS;		--		草药的付数，其他药品为1			20	
			args[21] = feeItemList.Order.Frequency.ID;//FREQUENCY_CODE;	--		频次代码						21	
			args[22] = feeItemList.Order.Usage.ID;//USAGE_CODE;	--		用法代码							22	
			args[23] = feeItemList.Order.Usage.Name;//USE_NAME;	--		用法名称							23
			args[24] = feeItemList.InjectCount.ToString();//INJECT_NUMBER;	--		院内注射次数		24	
			args[25] = NConvert.ToInt32(feeItemList.IsUrgent).ToString();//EMC_FLAG;	--		加急标记:1加急/0普通			25	
			args[26] = feeItemList.Order.Sample.ID;//LAB_TYPE;	--		样本类型							26	
			args[27] = feeItemList.Order.CheckPartRecord;//CHECK_BODY;	--		检体								27	
			args[28] = feeItemList.Order.DoseOnce.ToString();//DOSE_ONCE;	--		每次用量					28
			args[29] = feeItemList.Order.DoseUnit;//DOSE_UNIT;	--		每次用量单位							29
            //if (feeItemList.Item.IsPharmacy)
            if (feeItemList.Item.ItemType == EnumItemType.Drug)
            {
                args[30] = ((Neusoft.HISFC.Models.Pharmacy.Item)feeItemList.Item).BaseDose.ToString();//BASE_DOSE;	--		基本剂量					30
            }
            args[31] = feeItemList.Item.PackQty.ToString();//PACK_QTY;	--		包装数量						31	
			args[32] = feeItemList.Item.PriceUnit;//PRICE_UNIT;	--		计价单位							32	
			args[33] = feeItemList.FT.PubCost.ToString();//PUB_COST;	--		可报效金额				33	
			args[34] = feeItemList.FT.PayCost.ToString();//PAY_COST;	--		自付金额				34	
			args[35] = feeItemList.FT.OwnCost.ToString();//OWN_COST;	--		现金金额				35	
			args[36] = feeItemList.ExecOper.Dept.ID;//EXEC_DPCD;	--		执行科室代码					36
			args[37] = feeItemList.ExecOper.Dept.Name;//EXEC_DPNM;	--		执行科室名称					37
			args[38] = feeItemList.Compare.CenterItem.ID;//CENTER_CODE;	--		医保中心项目代码				38	
			args[39] = feeItemList.Compare.CenterItem.ItemGrade;//ITEM_GRADE;	--		项目等级1甲类2乙类3丙类		39	
			args[40] = NConvert.ToInt32(feeItemList.Order.Combo.IsMainDrug).ToString();//MAIN_DRUG;	--		主药标志					40
			args[41] = feeItemList.Order.Combo.ID;//COMB_NO;	--		组合号										41	
			args[42] = feeItemList.ChargeOper.ID;//OPER_CODE;	--		划价人							42
			args[43] = feeItemList.ChargeOper.OperTime.ToString();//OPER_DATE;	--		划价时间					43
			args[44] = ((int)feeItemList.PayType).ToString();// //PAY_FLAG;	--		收费标志，1未收费，2收费	44	
			args[45] = ((int)feeItemList.CancelType).ToString();			
			args[46] = feeItemList.FeeOper.ID;//FEE_CPCD;	--		收费员代码							46	
			args[47] = feeItemList.FeeOper.OperTime.ToString() ;//FEE_DATE;	--		收费日期					47	
			args[48] = feeItemList.Invoice.ID;//INVOICE_NO;	--		票据号								48	
			args[49] = "" ;//INVO_CODE;	--		发票科目代码				49
			args[50] = "" ;//INVO_SEQUENCE;	--		发票内流水号		50
			args[51] = NConvert.ToInt32(feeItemList.IsConfirmed).ToString();//CONFIRM_FLAG;	--		1未确认/2确认				51		
			args[52] = feeItemList.ConfirmOper.ID;//CONFIRM_CODE;	--		确认人						52		
			args[53] = feeItemList.ConfirmOper.Dept.ID;//CONFIRM_DEPT;	--		确认科室					53	
			args[54] = feeItemList.ConfirmOper.OperTime.ToString();//CONFIRM_DATE;	--		确认时间				54	
			args[55] = feeItemList.FT.RebateCost.ToString();// ECO_COST -- 优惠金额 55
			args[56] = feeItemList.InvoiceCombNO;//发票序号，一次结算产生多张发票的combNo  56
			args[57] = feeItemList.NewItemRate.ToString();//新项目比例  57
			args[58] = feeItemList.OrgItemRate.ToString();//原项目比例  58 
			args[59] = feeItemList.ItemRateFlag;//扩展标志 特殊项目标志 1自费 2 记帐 3 特殊  59
			args[60] = feeItemList.UndrugComb.ID;
			args[61] = feeItemList.UndrugComb.Name;
			args[62] = feeItemList.Item.SpecialFlag1;
			args[63] = feeItemList.Item.SpecialFlag2;
			args[64] = feeItemList.FeePack;
			args[65] = feeItemList.NoBackQty.ToString();
			args[66] = feeItemList.ConfirmedQty.ToString();
			args[67] = feeItemList.ConfirmedInjectCount.ToString();
			args[68] = feeItemList.Order.ID;
			args[69] = feeItemList.RecipeSequence;
			args[70] = feeItemList.SpecialPrice.ToString();
			args[71] = feeItemList.FT.ExcessCost.ToString();
			args[72] = feeItemList.FT.DrugOwnCost.ToString();
			args[73] = feeItemList.FTSource;
			args[74] = NConvert.ToInt32(feeItemList.Item.IsMaterial).ToString();
            args[75] = NConvert.ToInt32(feeItemList.IsAccounted).ToString();
            //{143CA424-7AF9-493a-8601-2F7B1D635027}
            //物资出库流水号
            args[76] = NConvert.ToInt32(feeItemList.UpdateSequence).ToString();
            args[77] = feeItemList.AccountNO;
			return args;
		}

		/// <summary>
		/// 获取费用明细查询语句
		/// </summary>
		/// <returns>成功: 返回的SQL语句 失败: null</returns>
		public string GetQueryFeeItemListsSql()
		{
			string sql = string.Empty;//SQL语句

			if (this.Sql.GetSql("Fee.OutPatient.GetFeeDetailByInvoiceNo.Select", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetFeeDetailByInvoiceNo.Select的SQL语句";

				return null;
			}

			return sql;
		}

		/// <summary>
		/// 根据Where条件索引查询费用明细信息数组
		/// </summary>
		/// <param name="whereIndex">where条件</param>
		/// <param name="ds">返回的DataSet</param>
		/// <param name="args">参数</param>
		/// <returns>成功:费用信息明细DataSet 失败:null</returns>
		private int QueryFeeItemLists(string whereIndex, ref DataSet ds, params string[] args)
		{
			string select = string.Empty;//SELECT语句;
			string where = string.Empty;//WHERE语句;

			if (this.Sql.GetSql(whereIndex, ref where) == -1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return -1;
			}

			try
			{
				where = string.Format(where, args);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			select = this.GetQueryFeeItemListsSql();
			
			return this.ExecQuery(select + " " + where, ref ds);
		}

		#endregion

		#region 结算操作

		/// <summary>
		/// 获得发票信息数组
		/// </summary>
		/// <param name="balance">发票实体</param>
		/// <returns>发票信息数组</returns>
		private string [] GetBalanceParams(Balance balance)
		{
			string[] args =
				{	
					balance.Invoice.ID,//发票号	
					((int)balance.TransType).ToString(),//1交易类型,1正，2反
					balance.Patient.PID.CardNO,//2病历卡号
					((Register)balance.Patient).DoctorInfo.SeeDate.ToString(),//3 挂号日期
					balance.Patient.Name,//4患者姓名
					balance.Patient.Pact.PayKind.ID,//5结算类别代码
					balance.Patient.Pact.ID,//6合同单位代码
					balance.Patient.Pact.Name,//7合同单位名称
					balance.Patient.SSN,//8个人编号
					"",//9医疗类别
					balance.FT.TotCost.ToString(),//10总额
					balance.FT.PubCost.ToString(),//11可报效金额
					balance.FT.OwnCost.ToString(),//12不可报效金额
					balance.FT.PayCost.ToString(),//13自付金额
					balance.User01,//14预留1
					balance.User02,//15预留2
					balance.User03,//16预留3
					balance.FT.BalancedCost.ToString(),//17实付金额
					balance.BalanceOper.ID,//18结算人
					balance.BalanceOper.OperTime.ToString(),//19结算时间
					balance.ExamineFlag,//0不是体检/1个人体检/2团体体检 
					((int)balance.CancelType).ToString(),//21作废标志,0未,1已
					balance.CanceledInvoiceNO,//22作废票据号
					balance.CancelOper.ID,//23作废操作员
					balance.CancelOper.OperTime.ToString(),//24作废时间
					NConvert.ToInt32(balance.IsAuditing).ToString(),//25 0未核查/1已核查
					balance.AuditingOper.ID,//26核查人
					balance.AuditingOper.OperTime.ToString(),//	27核查时间
					NConvert.ToInt32(balance.IsDayBalanced).ToString(),//0未日结/1已日结
					balance.BalanceID,//29	日结标识号
					balance.DayBalanceOper.ID,//			30日结人
					balance.DayBalanceOper.OperTime.ToString(),//31日结时间0
					balance.CombNO, // 32 发票序号，一次结算产生多张发票的combNo 		
					balance.InvoiceType.ID, // 33扩展标志 1 自费 2 记帐 3 特殊
					balance.Patient.ID, //34挂号流水号	
				    balance.PrintedInvoiceNO,
                    balance.DrugWindowsNO,
                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    NConvert.ToInt32(balance.IsAccount).ToString(),
                    balance.InvoiceCombo
				};
			
			return args;
		}

		/// <summary>
		/// 通过SQL语句获得结算信息数组
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="args">参数</param>
		/// <returns>成功:结算信息信息数组 失败:null 没有查找到数据返回元素数为0的ArrayList</returns>
		private ArrayList QueryBalancesBySql(string sql, params string[] args)
		{
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}
			
			ArrayList balances = new ArrayList();//结算信息实体数组
			Balance balance = null;//结算信息实体
			
			try
			{	
				//循环读取数据
				while (this.Reader.Read()) 
				{
					balance = new Balance();
					
					balance.Invoice.ID = this.Reader[0].ToString();//0发票号
					balance.TransType = (TransTypes)NConvert.ToInt32(this.Reader[1].ToString());//交易类型,1正交易，2反交易
					balance.Patient.PID.CardNO = this.Reader[2].ToString();//2病历卡号
					((Register)balance.Patient).DoctorInfo.SeeDate = NConvert.ToDateTime(this.Reader[3].ToString());//3挂号日期
					balance.Patient.Name = this.Reader[4].ToString();//	4患者姓名
					balance.Patient.Pact.PayKind.ID = this.Reader[5].ToString();//5结算类别代码
					balance.Patient.Pact.ID = this.Reader[6].ToString();//6合同单位代码
					balance.Patient.Pact.Name = this.Reader[7].ToString();//7合同单位名称
					balance.Patient.SSN = this.Reader[8].ToString();//8个人编号
					balance.FT.TotCost = NConvert.ToDecimal(this.Reader[10].ToString());//10总额
					balance.FT.PubCost = NConvert.ToDecimal(this.Reader[11].ToString());//11可报效金额
					balance.FT.OwnCost = NConvert.ToDecimal(this.Reader[12].ToString());//12不可报效金额
					balance.FT.PayCost = NConvert.ToDecimal(this.Reader[13].ToString());//13自付金额
					balance.User01 = this.Reader[14].ToString();//14预留1
					balance.User02 = this.Reader[15].ToString();//15预留2
					balance.User03 = this.Reader[16].ToString();//16预留3
					balance.FT.BalancedCost = NConvert.ToDecimal(this.Reader[17].ToString());//17实付金额
					balance.BalanceOper.ID = this.Reader[18].ToString();//18结算人
					balance.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[19].ToString());//19结算时间
					balance.ExamineFlag = this.Reader[20].ToString();//0不是体检/1个人体检/2团体体检 
					balance.CancelType = (CancelTypes)NConvert.ToInt32(this.Reader[21].ToString());
					balance.CanceledInvoiceNO = this.Reader[22].ToString();//22作废票据号
					balance.CancelOper.ID = this.Reader[23].ToString();//23作废操作员
					balance.CancelOper.OperTime = NConvert.ToDateTime(this.Reader[24].ToString());//24作废时间
					balance.IsAuditing = NConvert.ToBoolean(this.Reader[25].ToString());//是否核查
					balance.AuditingOper.ID = this.Reader[26].ToString();//		26核查人
					balance.AuditingOper.OperTime = NConvert.ToDateTime(this.Reader[27].ToString());//27核查时间
					balance.IsDayBalanced = NConvert.ToBoolean(this.Reader[28].ToString());//28是否日结
					balance.BalanceID = this.Reader[29].ToString();//29	日结标识号
					balance.DayBalanceOper.ID = this.Reader[30].ToString();//30日结人
					balance.DayBalanceOper.OperTime = NConvert.ToDateTime(this.Reader[31].ToString());//31日结时间0
					balance.CombNO = this.Reader[32].ToString();
					balance.InvoiceType.ID = this.Reader[33].ToString();
					balance.Patient.ID = this.Reader[34].ToString();
                    balance.PrintedInvoiceNO = this.Reader[35].ToString();
                    balance.DrugWindowsNO = this.Reader[36].ToString();
                    //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                    balance.IsAccount = NConvert.ToBoolean(this.Reader[37]);
                    balance.InvoiceCombo = this.Reader[38].ToString();
                    balances.Add(balance);
				}//循环结束

				this.Reader.Close();

				return balances;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
		}
		/// <summary>
		/// 获得发票信息的Select的SQL语句
		/// </summary>
		/// <returns>成功:发票信息的Select的SQL语句 失败: null</returns>
		public string GetBalanceSelectSql() 
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.OutPatient.GetInvoInfo",ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetInvoInfo的SQL语句";
				
				return null;
			}

			return sql;
		}

		/// <summary>
		/// 根据Where条件的索引查询结算信息
		/// </summary>
		/// <param name="whereIndex">Where条件索引</param>
		/// <param name="args">参数</param>
		/// <returns>成功:结算信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		private ArrayList QueryBalances(string whereIndex, params string[] args)
		{
			string sql = string.Empty;//SELECT语句
			string where = string.Empty;//WHERE语句
			
			//获得Where语句
			if (this.Sql.GetSql(whereIndex, ref where) == - 1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return null;
			}

			sql = this.GetBalanceSelectSql();

			return this.QueryBalancesBySql(sql + " " + where, args);
		}

		/// <summary>
		/// 获取发票基本信息(1：成功/-1：失败)
		/// </summary>
		/// <returns>成功:获取结算信息SQL查询语句 失败: null</returns>
		public string GetQueryBalancesSql()
		{
			string sql = string.Empty;//SQL语句
			
			if( this.Sql.GetSql("Fee.OutPatient.GetInvoiceInformation.Select", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetInvoiceInformation.Select的SQL语句";
				
				return null;
			}

			return sql;
		}
		
		/// <summary>
		/// 根据Where条件索引查询结算信息数组
		/// </summary>
		/// <param name="whereIndex">where条件</param>
		/// <param name="ds">返回的DataSet</param>
		/// <param name="args">参数</param>
		/// <returns>成功:结算信息DataSet 失败:null</returns>
		private int QueryBalances(string whereIndex, ref DataSet ds, params string[] args)
		{
			string select = string.Empty;//SELECT语句;
			string where = string.Empty;//WHERE语句;

			if (this.Sql.GetSql(whereIndex, ref where) == -1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return -1;
			}

			try
			{
				where = string.Format(where, args);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			select = this.GetQueryBalancesSql();
			
			return this.ExecQuery(select + " " + where, ref ds);
		}

		#endregion

		#region 结算明细操作

		/// <summary>
		/// 获得结算明细数组
		/// </summary>
		/// <param name="balanceList">结算明细实体</param>
		/// <returns>结算明细实体字段数组</returns>
		protected string [] GetBalanceListParams(BalanceList balanceList)
		{
			string[] args =
				{	
					balanceList.BalanceBase.Invoice.ID,//发票号
					((int)balanceList.BalanceBase.TransType).ToString(),//交易类型,1正交易，2反交易		2
					balanceList.InvoiceSquence.ToString(),//2发票内流水号
					balanceList.FeeCodeStat.ID,//3发票科目代码
					balanceList.FeeCodeStat.Name,//4发票科目名称
					balanceList.BalanceBase.FT.PubCost.ToString(),//5可报效金额
					balanceList.BalanceBase.FT.OwnCost.ToString(),//6不可报效金额
					balanceList.BalanceBase.FT.PayCost.ToString(),//7自付金额
					"",//8执行科室
					"",//9执行科室名称
					balanceList.BalanceBase.BalanceOper.OperTime.ToString(),//10操作时间
					balanceList.BalanceBase.BalanceOper.ID,//11操作员
					NConvert.ToInt32(balanceList.BalanceBase.IsDayBalanced).ToString(),//12 0未日结/1已日结
					((Balance)balanceList.BalanceBase).BalanceID,//13日结标识号
					balanceList.BalanceBase.DayBalanceOper.ID,//14日结人
					balanceList.BalanceBase.DayBalanceOper.OperTime.ToString(),//15日结时间
					((int)balanceList.BalanceBase.CancelType).ToString(),//16 退费标记
					((Balance)balanceList.BalanceBase).CombNO //17 发票序号，一次结算产生多张发票的combNo 
				};

			return args;
		}

		/// <summary>
		/// 通过SQL语句获得结算明细实体
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="args">参数</param>
		/// <returns>成功: 结算明细实体数组 失败: null</returns>
		private ArrayList QueryBalanceListsBySql(string sql, params string[] args)
		{
			if (this.ExecQuery(sql, args) == -1)
			{
				return null;
			}
			
			ArrayList balanceLists = new ArrayList();//结算明细实体集合
			BalanceList balanceList = null;//结算明细实体
            
			try
			{	//循环读取数据
				while (this.Reader.Read()) 
				{
					balanceList = new BalanceList();
               
					balanceList.BalanceBase.Invoice.ID = this.Reader[0].ToString();//0发票号
					balanceList.BalanceBase.TransType = (TransTypes)NConvert.ToInt32(this.Reader[1].ToString());//1交易类型,1正，2反	
					balanceList.InvoiceSquence = NConvert.ToInt32(this.Reader[2].ToString());//2发票内流水号
					balanceList.FeeCodeStat.ID = this.Reader[3].ToString();//3发票科目代码
					balanceList.FeeCodeStat.Name = this.Reader[4].ToString();//4发票科目名称
					balanceList.BalanceBase.FT.PubCost = NConvert.ToDecimal(this.Reader[5].ToString());//5可报效金额
					balanceList.BalanceBase.FT.OwnCost = NConvert.ToDecimal(this.Reader[6].ToString());//6不可报效金额
					balanceList.BalanceBase.FT.PayCost = NConvert.ToDecimal(this.Reader[7].ToString());//7自付金额
					balanceList.BalanceBase.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[10].ToString());//10操作时间
					balanceList.BalanceBase.BalanceOper.ID = this.Reader[11].ToString();//11操作员
					balanceList.BalanceBase.IsDayBalanced = NConvert.ToBoolean(this.Reader[12].ToString());//12 1已日结/0未日结
					((Balance)balanceList.BalanceBase).BalanceID = this.Reader[13].ToString();//13日结标识号
					balanceList.BalanceBase.DayBalanceOper.ID = this.Reader[14].ToString();//14	日结人
					balanceList.BalanceBase.DayBalanceOper.OperTime = NConvert.ToDateTime(this.Reader[15].ToString());//15日结时间
					((Balance)balanceList.BalanceBase).CombNO = this.Reader[16].ToString();//16发票序列号

					balanceLists.Add(balanceList);
				}

				this.Reader.Close();
				
				return balanceLists;
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();
				
				if (!this.Reader.IsClosed)
				{
					this.Reader.Close();
				}

				return null;
			}
		}
		/// <summary>
		/// 获得发票明细的SQL语句
		/// </summary>
		/// <returns>成功:发票明细的SQL语句 失败: null</returns>
		public string GetBalanceListsSql() 
		{
			string sql = string.Empty;//SQL语句
			
			if (this.Sql.GetSql("Fee.OutPatient.GetInvoDetailInfo" ,ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetInvoDetailInfo的SQL语句";

				return null;
			}

			return sql;
		}

		/// <summary>
		/// 根据Where条件的索引查询结算信息
		/// </summary>
		/// <param name="whereIndex">Where条件索引</param>
		/// <param name="args">参数</param>
		/// <returns>成功:结算明细信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		private ArrayList QueryBalanceLists(string whereIndex, params string[] args)
		{
			string sql = string.Empty;//SELECT语句
			string where = string.Empty;//WHERE语句
			
			//获得Where语句
			if (this.Sql.GetSql(whereIndex, ref where) == - 1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return null;
			}

			sql = this.GetBalanceListsSql();

			return this.QueryBalanceListsBySql(sql + " " + where, args);
		}

		/// <summary>
		/// 获取结算明细查询SQL语句
		/// </summary>
		/// <returns>成功:发票明细的SQL语句 失败: null</returns>
		public string GetQueryBalanceListsSql()
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.OutPatient.GetInvoiceDetailByInvoiceNo.Select", ref sql) == -1)
			{
				this.Err = "没有找到索引为:Fee.OutPatient.GetInvoiceDetailByInvoiceNo.Select的SQL语句";

				return null;
			}

			return sql;
		}

		/// <summary>
		/// 根据Where条件索引查询结算明细信息数组
		/// </summary>
		/// <param name="whereIndex">where条件</param>
		/// <param name="ds">返回的DataSet</param>
		/// <param name="args">参数</param>
		/// <returns>成功:结算信息明细DataSet 失败:null</returns>
		private int QueryBalanceLists(string whereIndex, ref DataSet ds, params string[] args)
		{
			string select = string.Empty;//SELECT语句;
			string where = string.Empty;//WHERE语句;

			if (this.Sql.GetSql(whereIndex, ref where) == -1)
			{
				this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

				return -1;
			}

			try
			{
				where = string.Format(where, args);
			}
			catch (Exception e)
			{
				this.Err = e.Message;
				this.WriteErr();

				return -1;
			}

			select = this.GetQueryBalanceListsSql();
			
			return this.ExecQuery(select + " " + where, ref ds);
		}

		#endregion

		#region 单表更新操作
		
		/// <summary>
		/// 更新单表操作
		/// </summary>
		/// <param name="sqlIndex">SQL语句索引</param>
		/// <param name="args">参数</param>
		/// <returns>成功: >= 1 失败 -1 没有更新到数据 0</returns>
		private int UpdateSingleTable(string sqlIndex, params string[] args)
		{
			string sql = string.Empty;//Update语句
			
			//获得Where语句
			if (this.Sql.GetSql(sqlIndex, ref sql) == - 1)
			{
				this.Err = "没有找到索引为:" + sqlIndex + "的SQL语句";

				return -1;
			}

			return this.ExecNoQuery(sql, args);
		}

        /// <summary>
        /// 返回唯一值
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回当前唯一值 失败:null</returns>
        private string ExecSqlReturnOne(string index, params string[] args)
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql(index, ref sql) == -1)
            {
                this.Err = "没有找到索引为:" + index + "的SQL语句";

                return null;
            }

            try
            {
                sql = string.Format(sql, args);
            }
            catch (Exception e)
            {
                this.Err = e.Message;
                this.WriteErr();

                return null;
            }

            return base.ExecSqlReturnOne(sql);
        }

		#endregion

		#endregion

		#region 公有方法

		#region 日结操作

		/// <summary>
		/// 插入日结信息
		/// </summary>
		/// <param name="dayBalance">日结实体</param>
		/// <returns>成功: 1 失败 -1 没有插入数据 0</returns>
		public int InsertDayBalance(DayBalance dayBalance)
		{
			return this.UpdateSingleTable("Fee.OutPatient.DayBalance.Insert", this.GetDayBalanceParams(dayBalance));
		}

		#endregion

		#region 支付信息操作
		
		/// <summary>
		/// 插入支付情况
		/// </summary>
		/// <param name="balancePay">支付信息实体</param>
		/// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
		public int InsertBalancePay(BalancePay balancePay)
		{
			return this.UpdateSingleTable("Fee.OutPatient.PayMode.Insert", this.GetBalancePayParams(balancePay));
		}
		
		/// <summary>
		/// 更新支付信息
		/// </summary>
		/// <param name="balancePay">支付信息实体</param>
		/// <returns>成功: 1 失败: -1 没有插入数据 0</returns>
		public int UpdateBalancePay(BalancePay balancePay)
		{
			return this.UpdateSingleTable("Fee.OutPatient.PayMode.Update", this.GetBalancePayParams(balancePay));
		}

		/// <summary>
		/// 根据发票号查询支付信息
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功: 支付信息数组 失败: null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalancePaysByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalancePays("Fee.OutPatient.GetSqlPayMode.Where.1", invoiceNO);
		}

		/// <summary>
		/// 根据结算序号查询支付信息
		/// </summary>
		/// <param name="invoiceSequence">结算序列</param>
		/// <returns>成功: 支付信息数组 失败: null 没有查找到数据返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalancePaysByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryBalancePays("Fee.OutPatient.GetInvoInfo.Where.Seq", invoiceSequence);
		}

        /// <summary>
        /// 根据发票组号查询支付信息
        /// </summary>
        /// <param name="invoiceUnion">发票组号</param>
        /// <returns></returns>
        public ArrayList QueryBalancePaysByInvoiceUnion(string invoiceUnion)
        {
            return this.QueryBalancePays("Fee.OutPatient.GetInvoInfo.InvoiceCombo", invoiceUnion);
        }
		#endregion

		#region 处方明细操作

		/// <summary>
		/// 插入费用明细
		/// </summary>
		/// <param name="feeItemList">费用明细实体</param>
		/// <returns>成功: 1 失败: -1 没有插入数据返回 0</returns>
		public int InsertFeeItemList(FeeItemList feeItemList) 
		{
			return this.UpdateSingleTable("Fee.Item.GetFeeItemDetail.Insert", this.GetFeeItemListParams(feeItemList));
		}

		/// <summary>
		/// 更新费用明细
		/// </summary>
		/// <param name="feeItemList">费用明细实体</param>
		/// <returns>成功: 1 失败: -1 没有更新到数据返回 0</returns>
		public int UpdateFeeItemList(FeeItemList feeItemList) 
		{
			return this.UpdateSingleTable("Fee.OutPatient.ItemDetail.Update", this.GetFeeItemListParams(feeItemList));
		}
		
		/// <summary>
		/// 删除处方明细根据组合号
		/// </summary>
		/// <param name="combNO">组合号</param>
		/// <returns>成功: >= 1 失败: -1 没有删除到数据返回 0</returns>
		public int DeleteFeeItemListByCombNO(string combNO)
		{
			return this.UpdateSingleTable("Fee.DelFeeDetail.1", combNO);
		}

		/// <summary>
		/// 根据处方号和处方项目流水号更新确认标志
		/// </summary>
		/// <param name="recipeNO">处方号</param>
		/// <param name="recipeSquence">处方项目流水号</param>
		/// <param name="confirmFlag">确认标志 1未确认/2确认</param>
		/// <param name="confirmOper">确认人</param>
		/// <param name="confirmDeptCode">确认科室</param>
		/// <param name="confirmTime">确认时间</param>
		/// <param name="noBackQty">可退数量</param>
		/// <param name="confirmQty">确认数量</param>
		/// <returns>成功: >= 1 失败: -1 没有更新到数据返回 0</returns>
		public int UpdateConfirmFlag(string recipeNO, int recipeSquence, string confirmFlag, string confirmOper, string confirmDeptCode, DateTime confirmTime,
			decimal noBackQty, decimal confirmQty)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateConfirmFlag.Update.1", recipeNO, recipeSquence.ToString(), confirmFlag, confirmOper, confirmDeptCode, confirmTime.ToString(),
				noBackQty.ToString(), confirmQty.ToString());
		}

        /// <summary>
        /// 根据处方号和处方项目流水号更新确认标志
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="moOrder">医嘱流水号</param>
        /// <param name="confirmFlag">确认标志 1未确认/2确认</param>
        /// <param name="confirmOper">确认人</param>
        /// <param name="confirmDeptCode">确认科室</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="noBackQty">可退数量</param>
        /// <param name="confirmQty">确认数量</param>
        /// <returns>成功: >= 1 失败: -1 没有更新到数据返回 0</returns>
        public int UpdateConfirmFlag(string recipeNO, string moOrder, string confirmFlag, string confirmOper, string confirmDeptCode, DateTime confirmTime, decimal noBackQty, decimal confirmQty)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdateConfirmFlag.Update.2", recipeNO, moOrder, confirmFlag, confirmOper, confirmDeptCode, confirmTime.ToString(),
                noBackQty.ToString(), confirmQty.ToString());
        }

		/// <summary>
		/// 根据处方号和处方项目流水号更新院注已确认数量
		/// </summary>
		/// <param name="moOrder">医嘱流水号</param>
		/// <param name="recipeNO">处方号</param>
		/// <param name="recipeSquence">处方内流水号</param>
		/// <param name="qty">院注次数</param>
		/// <returns>成功: >= 1 失败: -1 没有更新到数据返回 0</returns>
		public int UpdateConfirmInject(string moOrder,string recipeNO,string recipeSquence, int qty)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateConfirmInject.Update.1", moOrder, recipeNO, recipeSquence, qty.ToString());
		}

		/// <summary>
		/// 根据处方号和处方内流水号删除费用明细.
		/// </summary>
		/// <param name="recipeNO">处方号</param>
		/// <param name="recipeSequence">处方内流水号</param>
		/// <returns>成功: >= 1 失败: -1 没有删除到数据返回 0</returns>
		public int DeleteFeeItemListByRecipeNO(string recipeNO, string recipeSequence)
		{
			return this.UpdateSingleTable("Fee.OutPatient.DeleteFeeDetailByRecipeNo", recipeNO, recipeSequence);
		}

		/// <summary>
		/// 根据医嘱或者体检项目流水号删除明细
		/// </summary>
		/// <param name="moOrder">医嘱或者体检项目流水号</param>
		/// <returns>成功: >= 1 失败: -1 没有删除到数据返回 0</returns>
		public int DeleteFeeItemListByMoOrder(string moOrder)
		{
			return this.UpdateSingleTable("Fee.OutPatient.DeleteFeeDetailbySeqNo", moOrder);
		}

		/// <summary>
		/// 删除划价遗留的组套信息
		/// </summary>
		/// <param name="moOrder">医嘱流水号</param>
		/// <returns>成功: >= 1 失败: -1 没有删除到数据返回 0</returns>
		public int DeletePackageByMoOrder(string moOrder)
		{
			return this.UpdateSingleTable("Fee.OutPatient.DeleteGroup", moOrder);
		}

		/// <summary>
		///  删除体检明细中体检号对应的未收费的处方明细
		/// </summary>
		/// <param name="clinicNO">体检号</param>
		/// <returns>1：成功</returns>
		public int DeleteFeeItemListByClinicNO(string clinicNO)
		{
			return this.UpdateSingleTable("Neusoft.HISFC.BizLogic.Fee.CheckUp.DeleteFeeList", clinicNO);
		}

        /// <summary>
        /// 根据组合号和流水号删除费用明细
        /// </summary>
        /// <param name="combNo"></param>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public int DeleteFeeDetailByCombNoAndClinicCode(string combNo, string clinicCode)
        {
            return this.UpdateSingleTable("Fee.OutPatient.DeleteFeeDetailByCombNoAndClinicCode", combNo, clinicCode);
        }

		/// <summary>
		/// 获得处方号
		/// </summary>
		/// <returns>成功</returns>
		public string GetRecipeNO()
		{
			return this.GetSequence("Fee.OutPatient.GetRecipeNo.Select");
		}

		
		/// <summary>
		/// 通过患者卡号，得到费用明细
		/// </summary>
		/// <param name="cardNO">门诊卡号</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeItemListsByCardNO(string cardNO)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetail.Where.1", cardNO);
		}
		
		/// <summary>
		/// 通过发票号获得获得患者费用明细信息
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeItemListsByInvoiceNO(string invoiceNO)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetailFromInvoiceNo.Where.1", invoiceNO);
		}

        /// <summary>
        /// 通过患者流水号和组合号得到费用明细
        /// </summary>
        /// <param name="ComoNO"></param>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public ArrayList QueryFeeDetailbyComoNOAndClinicCode(string ComoNO, string clinicCode)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetailFromComoIdAndClinicCode.Select.1", ComoNO, clinicCode);
        }

		/// <summary>
		/// 获得患者的未收费项目信息
		/// </summary>
		/// <param name="clinicNO">挂号流水号</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryChargedFeeItemListsByClinicNO(string clinicNO)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.1", clinicNO);
		}

        //{2B2F694F-F469-4577-9859-66E30E81C95C}
        /// <summary>
        /// 获得患者在本科室收费项目信息
        /// </summary>
        /// <param name="clinicNO">挂号流水号</param>
        /// <param name="execDept">执行科室号</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryChargedFeeItemListsByClinicNOExecDept(string clinicNO, string execDept)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.7", clinicNO, execDept);
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 根据开方科室获得患者为收费项目信息
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <param name="doctDept"></param>
        /// <returns></returns>
        public ArrayList QueryChargedFeeItemListsByClinicNODoctDept(string clinicNO, string doctDept)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.5", clinicNO, doctDept);
        }


        /// <summary>
        /// 获得患者的已收费项目信息
        /// </summary>
        /// <param name="clinicNO">挂号流水号</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryFeeItemListsByClinicNO(string clinicNO)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.AlreadFee", clinicNO);
        }

		/// <summary>
		/// 获得患者的 已经收费， 未确认的指定SysClass的项目信息
		/// </summary>
		/// <param name="cardNO">患者卡号</param>
		/// <param name="sysClass">项目系统类别</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeItemLists(string cardNO, EnumSysClass sysClass)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.2", cardNO, sysClass.ToString());
		}

		/// <summary>
		/// 获得患者的 已经收费， 未确认的指定 需要院注的项目信息
		/// </summary>
		/// <param name="cardNO">患者卡号</param>
		/// <param name="isInject">true需要有院注的项目 false 查询患者所有项目</param>
		/// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryFeeItemLists(string cardNO, bool isInject)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.3", cardNO, NConvert.ToInt32(isInject).ToString());
		}

        /// <summary>
        /// 根据病历号和时间段得到患者未收费明细
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="dtFrom">开始时间</param>
        /// <param name="dtTo">结束时间</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryFeeItemLists(string cardNO, DateTime dtFrom, DateTime dtTo)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.3", cardNO, dtFrom.ToString(), dtTo.ToString());

        }

        /// <summary>
        /// 根据病历号和时间段得到患者已经收费明细
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="dtFrom">开始时间</param>
        /// <param name="dtTo">结束时间</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryFeeItemListsForZs(string cardNO, DateTime dtFrom, DateTime dtTo)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetChargeDetail.Select.4", cardNO, dtFrom.ToString(), dtTo.ToString());

        }

        /// <summary>
        /// 根据处方号和项目流水号获得项目明细实体(已经收费信息)
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方内流水号</param>
        /// <returns>成功:费用明细实体 失败或者没有数据:null</returns>
        public FeeItemList GetFeeItemListBalanced(string recipeNO, int sequenceNO) 
        {
            ArrayList feeItemLists = this.QueryFeeItemLists("Fee.Item.GetDrugItemList.WhereFeed", recipeNO, sequenceNO.ToString());

            if (feeItemLists == null)
            {
                return null;
            }

            if (feeItemLists.Count > 0)
            {
                foreach (FeeItemList f in feeItemLists) 
                {
                    if (f.CancelType == CancelTypes.Valid) 
                    {
                        return f;
                    }
                }
            }
            else
            {
                return null;
            }

            return null;
        }

		/// <summary>
		/// 根据处方号和项目流水号获得项目明细实体(划价信息)
		/// </summary>
		/// <param name="recipeNO">处方号</param>
		/// <param name="sequenceNO">处方内流水号</param>
		/// <returns>成功:费用明细实体 失败或者没有数据:null</returns>
		public FeeItemList GetFeeItemList(string recipeNO, int sequenceNO)
		{
			ArrayList feeItemLists = this.QueryFeeItemLists("Fee.Item.GetDrugItemList.Where2", recipeNO, sequenceNO.ToString());

			if (feeItemLists == null)
			{
				return null;
			}
			
			if (feeItemLists.Count > 0)
			{
				return feeItemLists[0] as FeeItemList;
			}
			else
			{
				return null;
			}
		}

        //{39B2599D-2E90-4b3d-A027-4708A70E45C3}
        /// <summary>
        /// 根据处方号和项目流水号获得项目划价数量
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="se">处方内流水号</param>
        /// <returns></returns>
        public int GetChargeItemCount(string recipeNO, int sequenceNO)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Item.GetDrugItemList.Where6", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Item.GetDrugItemList.Where6的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, recipeNO, sequenceNO);
            return NConvert.ToInt32(base.ExecSqlReturnOne(sql));
            
        }


		/// <summary>
		/// 根据结算序列检索药品明细
		/// </summary>
		/// <param name="invoiceSequence">结算序列</param>
		/// <returns>成功:药品明细 失败:null 没有数据: 返回元素数为0的ArrayList</returns>
		public ArrayList QueryDrugFeeItemListByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryFeeItemLists("Fee.Item.GetDrugItemList.Where", invoiceSequence);
		}

		/// <summary>
		///根据结算序列检索非药品明细
		/// </summary>
		/// <param name="invoiceSequence">结算序列</param>
		/// <returns>成功:非药品明细 失败:null 没有数据: 返回元素数为0的ArrayList</returns>
		public ArrayList QueryUndrugFeeItemListByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryFeeItemLists("Fee.Item.GetUndrugItemList.Where", invoiceSequence);
		}


        //{40DFDC91-0EC1-4cd4-81BC-0EAE4DE1D3AB}
        /// <summary>
        /// 根据结算序列检索物资明细
        /// </summary>
        /// <param name="invoiceSequence">结算序号</param>
        /// <returns>成功:物资明细 失败: null 没有数据: 返回元素数为0的ArrayList</returns>
        public ArrayList QueryMateFeeItemListByInvoiceSequence(string invoiceSequence)
        {
            return this.QueryFeeItemLists("Fee.Item.GetMateItemList.Where", invoiceSequence);
        }

		/// <summary>
		/// 根据结算序列获得费用明细
		/// </summary>
		/// <param name="invoiceSequence"></param>
		/// <returns></returns>
		public ArrayList QueryFeeItemListsByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetInvoInfo.Where.Seq", invoiceSequence);
		}

		/// <summary>
		/// 根据一主发票号，获取全部兄弟发票号的费用明细
		/// </summary>
		/// <param name="invoiceNO"></param>
		/// <returns></returns>
		public ArrayList QueryFeeItemListsSameInvoiceCombNOByInvoiceNO(string invoiceNO)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetInvoInfo.Where8", invoiceNO);
		}


		/// <summary>
		/// 根据发票号获取费用明细
		/// </summary>
		/// <param name="invoiceNO">输入的发票号</param>
		/// <param name="dataSet">返回的结果数据集</param>
		/// <returns>成功 1 失败: -1</returns>
		public int QueryFeeItemListsByInvoiceNO(string invoiceNO, ref DataSet dataSet)
		{
			return this.QueryFeeItemLists("Fee.OutPatient.GetInvoInfo.Where", ref dataSet, invoiceNO);
		}

        /// <summary>
        /// 通过医嘱项目流水号或者体检项目流水号，得到费用明细
        /// </summary>
        /// <param name="MOOrder">医嘱项目流水号或者体检项目流水号</param>
        /// <returns>null 错误 ArrayList Fee.OutPatient.FeeItemList实体集合</returns>
        public ArrayList QueryFeeDetailFromMOOrder(string MOOrder)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetailFromMOOrder.Select.1", MOOrder);
        }

        /// <summary>
        /// 根据医嘱流水号查询患者收费的费用信息
        /// </summary>
        /// <param name="MOOrder"></param>
        /// <returns></returns>
        public FeeItemList QueryFeeItemListFromMOOrder(string MOOrder)
        {
            ArrayList al = this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetailFromMOOrder.Select.1", MOOrder);
            if (al == null || al.Count == 0)
            {
                this.Err = "查询患者费用信息失败！";
                return null;
            }
            return al[0] as FeeItemList;
        }

        /// <summary>
        /// 通过处方号，得到费用明细
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <returns>null 错误 ArrayList Fee.OutPatient.FeeItemList实体集合</returns>
        public ArrayList QueryFeeDetailFromRecipeNO(string recipeNO)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetailFromRecipeNo.Select.1", recipeNO);
        }

        /// <summary>
        /// 通过患者流水号和组合号得到已收费未退费的费用明细
        /// </summary>
        /// <param name="ComoNO"></param>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public ArrayList QueryValidFeeDetailbyComoNOAndClinicCode(string ComoNO, string clinicCode)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetailFromComoIdAndClinicCode.Select.2", ComoNO, clinicCode);
        }

		#endregion

		#region 获得自动生成的卡号
		
		/// <summary>
		/// 获得自动生成的卡号， 主要为收费直接输入患者信息时生成。
		/// </summary>
		/// <returns>成功:自动生成的卡号 失败:null </returns>
		public string GetAutoCardNO()
		{
			string tempCardNo = this.GetSequence("Fee.OutPatient.GetAutoCardNo.Select");
			
			return tempCardNo.PadLeft(9, '0');
		}

		#endregion

		#region 获得收费序列号

		/// <summary>
		/// 获得收费序列号
		/// </summary>
		/// <returns>成功:收费序列号 失败:null</returns>
		public string GetRecipeSequence()
		{
			return this.GetSequence("Fee.OutPatient.GetRecipeSeq.Select");
		}

		#endregion

		#region 结算操作

		/// <summary>
		/// 获得发票组合号
		/// </summary>
		/// <returns>成功:发票组合号 失败 null</returns>
		public string GetInvoiceCombNO()
		{
			return this.GetSequence("Fee.OutPatient.GetInvoiceSeq.Select");
		}
		
		/// <summary>
		/// 插入发票信息
		/// </summary>
		/// <param name="balance">发票信息实体</param>
		/// <returns>成功: 1 失败: -1 没有插入数据返回 0</returns>
		public int InsertBalance(Balance balance)
		{
			return this.UpdateSingleTable("Fee.OutPatient.InvoInfo.Insert", this.GetBalanceParams(balance));
		}

		/// <summary>
		/// 更新发票信息
		/// </summary>
		/// <param name="balance">发票信息实体</param>
		/// <returns>成功: 1 失败: -1 没有更新数据返回 0</returns>
		public int UpdateBalance(Balance balance)
		{
			return this.UpdateSingleTable("Fee.OutPatient.InvoInfo.Update", this.GetBalanceParams(balance));
		}

		#endregion

		#region 结算明细操作

		/// <summary>
		/// 插入结算明细
		/// </summary>
		/// <param name="balanceList">结算明细实体</param>
		/// <returns>成功: 1 失败: -1 没有插入数据返回 0</returns>
		public int InsertBalanceList(BalanceList balanceList)
		{
			return this.UpdateSingleTable("Fee.OutPatient.InvoDetail.Insert", this.GetBalanceListParams(balanceList));
		}

		/// <summary>
		/// 更新结算明细
		/// </summary>
		/// <param name="balanceList">结算明细实体</param>
		/// <returns>成功: 1 失败: -1 没有更新数据返回 0</returns>
		public int UpdateBalanceList(BalanceList balanceList)
		{
			return this.UpdateSingleTable("Fee.OutPatient.InvoDetail.Updat", this.GetBalanceListParams(balanceList));
		}

		#endregion

		#region 结算检索

		/// <summary>
		/// 根据发票号,检索存在的发票数目
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功:发票的数目 失败 -1</returns>
		public string QueryExistInvoiceCount(string invoiceNO)
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.OutPatient.QueryExistInvoiceCount.Select.1", ref sql) == -1)
			{
				this.Err += "没有找到索引为: Fee.OutPatient.QueryExistInvoiceCount.Select.1 的SQL语句";
				
				return "-1";
			}
			
			return this.ExecSqlReturnOne(sql, invoiceNO);
		}

		/// <summary>
		/// 得到当前操作员从当前开始计算前N张发票的信息
		/// </summary>
		/// <param name="count">数量</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesByCount(int count)
		{
			string sql = string.Empty;

			if (this.Sql.GetSql("Fee.OutPatient.GetSpecifyCountsInfosSinceNow.Select.1", ref sql) == -1)
			{
				this.Err += "没有找到索引为: Fee.OutPatient.GetSpecifyCountsInfosSinceNow.Select.1 的SQL语句";

				return null;
			}

			return this.QueryBalancesBySql(sql, (count + 1).ToString());
		}

		/// <summary>
		/// 获得患者的正交易发票信息，发票重打用
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesValidByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalances("Fee.OutPatient.GetValidInvoiceInfo.Where.1", invoiceNO);
		}

		/// <summary>
		/// 根据患者卡号和时间段查找符合条件的发票实体集合
		/// </summary>
		/// <param name="cardNO">患者卡号</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesByCardNO(string cardNO, DateTime beginTime, DateTime endTime)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoiceInfoByPatientCardNo.Where.1", cardNO, beginTime.ToString(), endTime.ToString());
		}

		/// <summary>
		/// 根据患者姓名和时间段查找符合条件的发票实体集合
		/// </summary>
		/// <param name="name">患者姓名</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesByName(string name, DateTime beginTime, DateTime endTime)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoiceInfoByPatientName.Where.1", name, beginTime.ToString(), endTime.ToString());
		}

		/// <summary>
		/// 通过发票号获得所有结算信息
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoInfo.Where", invoiceNO);
		}

		/// <summary>
		/// 根据主发票号，获取相同结算序号的结算信息(有效结算信息)   
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesSameInvoiceCombNOByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoInfo.Where7", invoiceNO);
		}

		/// <summary>
		/// 根据结算序号,获取相同结算序号的结算信息(有效结算信息)   
		/// </summary>
		/// <param name="invoiceSequence">结算序号</param>
		/// <returns>成功: 结算信息数组 失败: null</returns>
		public ArrayList QueryBalancesByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoInfo.Where.Seq", invoiceSequence);
		}
		
		/// <summary>
		/// 根据发票号获得结算信息的DataSet
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <param name="dataSet">结算信息DataSet</param>
		/// <returns>成功 1 失败 -1</returns>
		public int QueryBalancesByInvoiceNO(string invoiceNO, ref DataSet dataSet)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoInfo.Where", ref dataSet, invoiceNO);
		}

		/// <summary>
		/// 根据患者姓名获得结算信息的DataSet
		/// </summary>
		/// <param name="name">输入患者姓名</param>
		/// <param name="beginTime">查询的起始日期</param>
		/// <param name="endTime">查询的截止日期</param>
		/// <param name="dataSet">返回的结果数据集</param>
		/// <returns>成功 1 失败 -1</returns>
		public int QueryBalancesByPatientName(string name, DateTime beginTime, DateTime endTime, ref DataSet dataSet)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoiceInformationByName.Where", ref dataSet, name, beginTime.ToString(), endTime.ToString());
		}

		/// <summary>
		/// 根据病例号获得结算信息DataSet
		/// </summary>
		/// <param name="cardNO">患者病例号</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <param name="dataSet">返回的结果数据集</param>
		/// <returns>成功 1 失败 -1</returns>
		public int QueryBalancesByCardNO(string cardNO, DateTime beginTime, DateTime endTime, ref DataSet dataSet)
		{
			return this.QueryBalances("Fee.OutPatient.GetInvoiceInformationByCardNo.Where", ref dataSet, cardNO, beginTime.ToString(), endTime.ToString());
		}


		#endregion

		#region 结算明细检索
		
		/// <summary>
		/// 通过发票号获得所有的结算明细
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功:结算明细信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalanceListsByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalanceLists("Fee.OutPatient.GetInvoDetail.Where", invoiceNO);
		}

		/// <summary>
		/// 根据一个发票号 获取所有相同结算序列的结算明细(有效的结算明细)
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <returns>成功:结算明细信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalanceListsSameInvoiceCombNOByInvoiceNO(string invoiceNO)
		{
			return this.QueryBalanceLists("Fee.OutPatient.GetBalanceBrotherInvoDetail.Where", invoiceNO);
		}
		/// <summary>
		/// 根据结算序列获得结算明细(有效的结算明细)
		/// </summary>
		/// <param name="invoiceSequence">结算序列</param>
		/// <returns>成功:结算明细信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalanceListsByInvoiceSequence(string invoiceSequence)
		{
			return this.QueryBalanceLists("Fee.OutPatient.GetInvoInfo.Where.Seq", invoiceSequence);
		}

		/// <summary>
		/// 根据发票号和结算序列获得结算明细(有效的结算明细)
		/// </summary>
		/// <param name="invoiceNO">发票号</param>
		/// <param name="invoiceSequence">结算序列</param>
		/// <returns>成功:结算明细信息 失败:null 没有数据:返回元素数为0的ArrayList</returns>
		public ArrayList QueryBalanceListsByInvoiceNOAndInvoiceSequence(string invoiceNO, string invoiceSequence)
		{
			return this.QueryBalanceLists("Fee.OutPatient.GetBalanceBrotherInvoDetailBySeq.Where.1", invoiceNO, invoiceSequence);
		}

		/// <summary>
		/// 根据发票号获取发票明细(1：成功/-1：失败)
		/// </summary>
		/// <param name="invoiceNO">输入的发票号</param>
		/// <param name="dataSet">返回的结果数据集</param>
		/// <returns>成功 1 失败 -1</returns>
		public int QueryBalanceListsByInvoiceNO(string invoiceNO, ref DataSet dataSet)
		{
			return this.QueryBalanceLists("Fee.OutPatient.GetInvoInfo.Where", ref dataSet, invoiceNO);
		}

		#endregion

		#region 批费项目列表检索

		/// <summary>
		/// 获得门诊批费项目列表
		/// </summary>
		/// <param name="deptCode">收费员所在科室</param>
		/// <param name="ds">项目列表</param>
		/// <returns> -1 失败 > 0 成功</returns>
		public int QueryItemList(string deptCode, ref DataSet ds)
		{			
			return this.ExecQuery("Fee.Item.GetOutPatientItemList.Select",ref ds, deptCode);
		}

		#endregion
        #region {5D62CB1F-6134-48f4-B905-02AD69D6A433}
        /// <summary>
        /// 获得门诊批费项目列表
        /// </summary>
        /// <param name="deptCode">收费员所在科室</param>
        /// <param name="itemCode">项目编码</param>
        /// <param name="ds">项目列表</param>
        /// <returns> -1 失败 > 0 成功</returns>
        public int QueryItemList(string deptCode, string itemCode, ref DataSet ds)
        {
            return this.ExecQuery("Fee.Item.GetOutPatientItemList.Select.ItemCode", ref ds, deptCode, itemCode);
        }

          #endregion
        /// <summary>
        /// 获得门诊批费项目列表
        /// </summary>
        /// <param name="deptCode">收费员所在科室</param>
        /// <param name="itemKind">项目列表类别</param>
        /// <param name="ds">项目列表</param>
        /// <returns> -1 失败 > 0 成功</returns>
        public int QueryItemList(string deptCode, Neusoft.HISFC.Models.Base.ItemKind itemKind, ref DataSet ds)
        {
            if (itemKind == ItemKind.All)
            {
                return this.ExecQuery("Fee.Item.GetOutPatientItemList.Select", ref ds, deptCode);
            }
            if (itemKind == ItemKind.Undrug)
            {
                return this.ExecQuery("Fee.Item.GetOutPatientItemList.Select.Undrug", ref ds, deptCode);
            }
            if (itemKind == ItemKind.Pharmacy)
            {
                return this.ExecQuery("Fee.Item.GetOutPatientItemList.Select.Pharmacy", ref ds, deptCode);
            }
            return 1;
        }

        /// <summary>
        /// 获得门诊批费项目列表 手工处方模式{CCDAA6CD-B5FA-439c-ABDD-710054D9DA31}wbo 2011-03-01
        /// </summary>
        /// <param name="ds">项目列表</param>
        /// <returns> -1 失败 > 0 成功</returns>
        public int QueryItemListOld(ref DataSet ds)
        {
            string sql = @"select 'undrug' as dept_code,
       '0' as drug_flag, -- 非药品标志
       a.sys_class as sys_class,
       a.fee_code as fee_code,
       a.item_code as item_code,
       a.item_name as item_name,
       '' as en_name,
       1 as pack_qty,
       a.specs as specs,
       '' as dose_code,
       a.spell_code as spell_code,
       a.wb_code as wb_code,
       a.input_code as user_code,
       a.item_name as cus_name,
       a.spell_code as cus_spell_code,
       a.wb_code as cus_wb_code,
       a.input_code as cus_user_code,
       a.unit_price as unit_price,
       a.unit_price1 as child_price,
       a.unit_price2 as sp_price,
       a.stock_unit as pack_unit,
       a.stock_unit as min_unit,
       '0' as now_store,
       nvl(a.exedept_code, '无') as exe_dept,
       '' as gf_flag,
       '' as usage_code,
       '' as freq_code,
       '' as dose_unit,
       SPECIAL_FLAG as shenxz,
       SPECIAL_FLAG1 as shixz,
       SPECIAL_FLAG2 as zf,
       NEEDBESPEAK as needbespeak,
       1 as base_dose,
       nvl(CONFIRM_FLAG, '0') as CONFIRM_FLAG,
       '0' as split_type,
       '0' as LACK_FLAG,
       a.special_flag3 as Special_Check, --特殊检查
       0 as once_dose,
       '' as other_name,
       '' as other_spell,
       a.default_sample as default_sample --样本
  from fin_com_undruginfo a
 where a.valid_state = fun_get_valid
   and a.UNITFLAG = '0'
   and a.APPLICABILITYAREA <> '2'
   and a.input_code like '%A'
--order by a.input_code

";
            return this.ExecQuery(sql, ref ds);
        }

		#region 退费业务

		/// <summary>
		/// 根据原始发票号更新费用明细的有效标志
		/// </summary>
		/// <param name="orgInvoiceNO">原始发票号</param>
		/// <param name="operTime">操作时间</param>
		/// <param name="cancelType">作废类型</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int UpdateFeeItemListCancelType(string orgInvoiceNO, DateTime operTime, CancelTypes cancelType)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateFeeDetailCancelFlag.1", orgInvoiceNO, operTime.ToString(), ((int)cancelType).ToString());
		}

		/// <summary>
		/// 根据项目流水号和内流水号更新费用明细的有效标志
		/// </summary>
		/// <param name="recipeNO">处方号</param>
		/// <param name="recipeSequence">处方内流水号</param>
		/// <param name="cancelType">作废类型</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int UpdateFeeItemListCancelType(string recipeNO, int recipeSequence, CancelTypes cancelType)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateFeeDetailCancelFlag", recipeNO, recipeSequence.ToString(), ((int)cancelType).ToString());
		}

		/// <summary>
		/// 根据原始发票号和结算序号更新结算信息
		/// </summary>
		/// <param name="orgInvoiceNO">原始发票号</param>
		/// <param name="invoiceSequence">结算序列</param>
		/// <param name="operTime">操作时间</param>
		/// <param name="cancelType">作废类型</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int UpdateBalanceCancelType(string orgInvoiceNO, string invoiceSequence, DateTime operTime, CancelTypes cancelType)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoCancelFlag", orgInvoiceNO, invoiceSequence, operTime.ToString(), ((int)cancelType).ToString());
		}

        /// <summary>
        /// 根据原始发票号和结算序号更新结算信息(用于郑大发票作废)
        /// </summary>
        /// <param name="orgInvoiceNO">原始发票号</param>
        /// <param name="invoiceSequence">结算序列</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="cancelType">作废类型</param>
        /// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateCancelFeeType(string orgInvoiceNO, string invoiceSequence, DateTime operTime, CancelTypes cancelType,string cancelReason)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoCancelFlag.New1", orgInvoiceNO, invoiceSequence, operTime.ToString(), ((int)cancelType).ToString(), cancelReason);
        }

        /// <summary>
        /// 根据原始发票号和结算序号更新结算信息(用于郑大门诊退费)
        /// </summary>
        /// <param name="orgInvoiceNO">原始发票号</param>
        /// <param name="invoiceSequence">结算序列</param>
        /// <param name="operTime">操作时间</param>
        /// <param name="cancelType">作废类型</param>
        /// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateBalanceCancelFeeType(string orgInvoiceNO, string invoiceSequence, DateTime operTime, CancelTypes cancelType, string cancelReason)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoCancelFlag.New2", orgInvoiceNO, invoiceSequence, operTime.ToString(), ((int)cancelType).ToString(), cancelReason);
        }
		/// <summary>
		/// 根据原始发票号和结算序号更新结算明细信息
		/// </summary>
		/// <param name="orgInvoiceNO">原始发票号</param>
		/// <param name="invoiceSequence">结算序列</param>
		/// <param name="operTime">操作时间</param>
		/// <param name="cancelType">作废类型</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int UpdateBalanceListCancelType(string orgInvoiceNO, string invoiceSequence, DateTime operTime, CancelTypes cancelType)
		{
			return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoDetailCancelFlag", orgInvoiceNO, invoiceSequence, operTime.ToString(), ((int)cancelType).ToString());
		}

		#endregion

		#region 发票重打业务

		/// <summary>
		/// 作废费用信息用
		/// </summary>
		/// <param name="type">类型: 1 结算主表 2 结算明细表 3 费用明细表 4 支付方式表</param>
		/// <param name="invoiceSequence">结算序号</param>
		/// <param name="cancelType">作废类型</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int UpdateCancelTyeByInvoiceSequence(string type, string invoiceSequence, CancelTypes cancelType)
		{
			string sql = string.Empty; //SQL语句
			string index = string.Empty;; //SQL语句索引

			switch(type)
			{
				case "1"://发票主表
					index = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.Invoice";
					break;
				case "2"://发票明细表
					index = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.InvoiceDetail";
					break;
				case "3"://费用明细表
					index = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.FeeDetail";
					break;
				case "4"://支付方式
					index = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.PayMode";
					break;
			}

			return this.UpdateSingleTable(index, invoiceSequence, ((int)cancelType).ToString());
		}

		#endregion

		#region 发票注销

		/// <summary>
		/// 发票注销
		/// </summary>
		/// <param name="invoiceSequence">结算序号</param>
		/// <returns>成功; >= 1 失败: -1 没有更新到数据: 0</returns>
		public int LogOutInvoice(string invoiceSequence)
		{
			if (invoiceSequence == string.Empty)
			{
				this.Err = "流水号出错";

				return -1;
			}

			int iReturn = 0;

			iReturn = UpdateCancelTyeByInvoiceSequence("1", invoiceSequence, CancelTypes.LogOut);
			if (iReturn <= 0)
			{
				this.Err += "更新发票主表错误!";
				
				return iReturn;
			}

			iReturn = UpdateCancelTyeByInvoiceSequence("2", invoiceSequence, CancelTypes.LogOut);
			if (iReturn <= 0)
			{
				this.Err += "更新发票明细错误!";
				
				return iReturn;
			}

			iReturn = UpdateCancelTyeByInvoiceSequence("3", invoiceSequence, CancelTypes.LogOut);
			if (iReturn == -1)
			{
				this.Err += "更新费用明细错误!";
				return iReturn;
			}
			if( iReturn == 0)
			{
				this.Err += "发票内项目已经确认，不能取消!";
				return -1;
			}

			iReturn = UpdateCancelTyeByInvoiceSequence("4", invoiceSequence, CancelTypes.LogOut);
			if (iReturn <= 0)
			{																									
				this.Err += "更新支付信息表错误!";
				return -1;
			}
			
			return iReturn;
		}

		#endregion


        #region 删除　集体体检汇总划价信息
        /// <summary>
        /// 根据体检流水号和发票组合号删除体检汇总信息　
        /// </summary>
        /// <param name="ClinicNO">体检流水号</param>
        /// <param name="RecipeNO">发票组合号</param>
        /// <returns></returns>
        public int DeleteFeeItemListByClinicNOAndRecipeNO(string ClinicNO, string RecipeNO)
        {
            string sql = string.Empty; //查询SQL语句

            if (this.Sql.GetSql("Fee.InvoiceService.DeleteFeeItemListByClinicNOAndRecipeNO", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.InvoiceService.DeleteFeeItemListByClinicNOAndRecipeNO的SQL语句";

                return -1;
            }
            sql = string.Format(sql, ClinicNO, RecipeNO);

            return this.ExecNoQuery(sql);
        }
        #endregion 
       
        #region 查询发票组合号是否已经收费
        /// <summary>
        /// 根据发票组合号查询体检汇总信息是否收费 　
        /// </summary>
        /// <param name="RecipeSeq">发票组合号</param>
        /// <returns>0 已收费， 1 未收费 ，-1 查询出错</returns>
        public int IsFeeItemListByRecipeNO(string RecipeSeq)
        {
            string strSql1 = "";
            string strSql2 = "";
            ArrayList list = new ArrayList();
            //获得项目明细的SQL语句
            strSql1 = this.GetSqlFeeDetail();
            if (this.Sql.GetSql("Fee.Item.IsFeeItemListByRecipeNO.Where", ref strSql2) == -1) return -1;
            strSql1 = strSql1 + " " + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, RecipeSeq);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            list = this.QueryFeeDetailBySql(strSql1);
            if(list == null)
            {
                return -1; //出错
            }
            if (list.Count == 0)
            {
                return 1;
            }
            foreach (FeeItemList feeItemList in list)
            {
                if (feeItemList.PayType == PayTypes.Balanced) //如果已经收费
                {
                    return 0; 
                }
            }
            return 1; //没有收费 
        }
        #endregion 

        #region 更新扣取账户标志

        /// <summary>
        /// 更新费用明细,是否已经扣取账户(按照处方号,和处方流水号)
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方流水号</param>
        /// <param name="isAccounted">是否已经扣取账户</param>
        /// <returns>成功 1 不符合更新条件 0 错误 -1</returns>
        public int UpdateAccountFlag(string recipeNO, int sequenceNO, bool isAccounted) 
        {
            return this.UpdateSingleTable("Fee.Outpatient.UpdateAccountFlag.RecipeNO", recipeNO, sequenceNO.ToString(), NConvert.ToInt32(isAccounted).ToString());
        }

        /// <summary>
        /// 更新费用明细,是否已经扣取账户(按照项目编码, 医嘱流水号)
        /// </summary>
        /// <param name="itemCode">项目编码</param>
        /// <param name="moOrder">医嘱流水号</param>
        /// <param name="isAccounted">是否已经扣取账户</param>
        /// <returns>成功 1 不符合更新条件 0 错误 -1</returns>
        public int UpdateAccountFlag(string itemCode, string moOrder, bool isAccounted) 
        {
            return this.UpdateSingleTable("Fee.Outpatient.UpdateAccountFlag.MoOrder", itemCode, moOrder, NConvert.ToInt32(isAccounted).ToString());            
        }

        #endregion


        #region 公用

        /// <summary>
        /// 获得发票大类，按照最小费用排序
        /// </summary>
        /// <param name="type">发票类别默认MZ01</param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int GetInvoiceClass(string type, ref DataSet ds)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.Item.GetInvoiceClass.Select", ref sql) == -1) 
            {
                this.Err = "没有找到索引为: " + "Fee.Item.GetInvoiceClass.Select的SQL语句";

                return -1;
            }

            sql = string.Format(sql, type);

            return this.ExecQuery(sql, ref ds);
        }

        #endregion

        #region 其他

        /// <summary>
        /// 根据处方号获得最大处方流水号
        /// </summary>
        /// <param name="recipeNo"></param>
        /// <returns></returns>
        public string GetMaxSeqByRecipeNO(string recipeNO)
        {
            return this.ExecSqlReturnOne("Fee.OutPatient.GetMaxSeqByRecipeNo", recipeNO);
        }

        /// <summary>
        /// 根据费用明细查询医嘱的申请单号
        /// {6FAEEEC2-CF03-4b2e-B73F-92C1C8CAE1C0} 电子申请单用 20100505
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public string GetApplyNoByRecipeFeeSeq(FeeItemList f)
        {
            return this.ExecSqlReturnOne("Fee.OutPatient.GetApplyNoByRecipeFeeSeq", f.RecipeNO, "" + f.SequenceNO);
        }

        #endregion

        #region 日结

        /// <summary>
        /// 更新发票主表日结标记
        /// </summary>
        /// <param name="beginTime">日结开始时间</param>
        /// <param name="endTime">日结结束时间</param>
        /// <param name="balanceFlag">日结标记</param>
        /// <param name="balanceNO">日结序号</param>
        /// <param name="balanceDate">日结时间</param>
        /// <returns> >=1成功, 0 没有找到更新的行， -1 失败</returns>
        public int UpdateInvoiceForDayBalance(DateTime beginTime, DateTime endTime, string balanceFlag,
            string balanceNO, DateTime balanceDate)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoiceForDayBalance.Update", beginTime.ToString(), 
                endTime.ToString(), this.Operator.ID, balanceFlag, balanceNO, balanceDate.ToString());
        }

        /// <summary>
        /// 更新发票明细表日结标记
        /// </summary>
        /// <param name="beginTime">日结开始时间</param>
        /// <param name="endTime">日结结束时间</param>
        /// <param name="balanceFlag">日结标记</param>
        /// <param name="balanceNO">日结序号</param>
        /// <param name="balanceDate">日结时间</param>
        /// <returns> >=1成功, 0 没有找到更新的行， -1 失败</returns>
        public int UpdateInvoiceDetailForDayBalance(DateTime beginTime, DateTime endTime, string balanceFlag,
            string balanceNO, DateTime balanceDate)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdateInvoiceDetailForDayBalance.Update", beginTime.ToString(),
                endTime.ToString(), this.Operator.ID, balanceFlag, balanceNO, balanceDate.ToString());
        }

        /// <summary>
        /// 更新发票支付方式表日结标记
        /// </summary>
        /// <param name="dtBegin">日结开始时间</param>
        /// <param name="dtEnd">日结结束时间</param>
        /// <param name="balanceFlag">日结标记</param>
        /// <param name="balanceNO">日结序号</param>
        /// <param name="balanceDate">日结时间</param>
        /// <returns> >=1成功, 0 没有找到更新的行， -1 失败</returns>
        public int UpdatePayModeForDayBalance(DateTime beginTime, DateTime endTime, string balanceFlag,
            string balanceNO, DateTime balanceDate)
        {
            return this.UpdateSingleTable("Fee.OutPatient.UpdatePayModeForDayBalance.Update", beginTime.ToString(),
                endTime.ToString(), this.Operator.ID, balanceFlag, balanceNO, balanceDate.ToString());
        }

        #endregion

        #endregion

        #region 废弃方法
        /// <summary>
		/// 根据发票号获取费用明细
		/// </summary>
		/// <param name="strInvoice">输入的发票号</param>
		/// <param name="dsResult">返回的结果数据集</param>
		/// <returns>1：成功/-1：失败</returns>
		[Obsolete("作废,使用QueryFeeItemListsByInvoiceNO", true)]
		public int QueryFeeDetailByInvoiceNo(string strInvoice, ref System.Data.DataSet dsResult)
		{
			return 1;
		}
		
		/// <summary>
		/// 根据发票号获取发票明细(1：成功/-1：失败)
		/// </summary>
		/// <param name="strInvoice">输入的发票号</param>
		/// <param name="dsResult">返回的结果数据集</param>
		/// <returns>1：成功/-1：失败</returns>
		[Obsolete("作废,使用QueryBalanceListsByInvoiceNO", true)]
		public int QueryInvoiceDetailByInvoiceNo(string strInvoice, ref System.Data.DataSet dsResult)
		{
			return 1;
		}


		/// <summary>
		/// 根据病历号查询发票基本信息(1：成功/-1：失败)
		/// </summary>
		/// <param name="strCard">输入的病历号</param>
		/// <param name="dsResult">返回的结果数据集</param>
		/// <param name="dtFrom">查询的起始日期</param>
		/// <param name="dtTo">查询的截止日期</param>
		/// <returns>1：成功/-1：失败</returns>
		[Obsolete("作废,使用QueryBalancesByCardNO", true)]
		public int QueryInvoiceInformationByCardNo(string strCard, DateTime dtFrom, DateTime dtTo, ref System.Data.DataSet dsResult)
		{
	
			return 1;
		}

		/// <summary>
		/// 根据患者姓名查询发票基本信息(1：成功/-1：失败)
		/// </summary>
		/// <param name="strName">输入患者姓名</param>
		/// <param name="dtFrom">查询的起始日期</param>
		/// <param name="dtTo">查询的截止日期</param>
		/// <param name="dsResult">返回的结果数据集</param>
		/// <returns>1：成功/-1：失败</returns>
		[Obsolete("作废,使用QueryBalancesByPatientName", true)]
		public int QueryInvoiceInformationByName(string strName, DateTime dtFrom, DateTime dtTo, ref System.Data.DataSet dsResult)
		{
			return 1;
		}


		/// <summary>
		/// 根据发票号查询发票基本信息(1：成功/-1：失败)
		/// </summary>
		/// <param name="strInvoiceNo">输入的发票号</param>
		/// <param name="dsResult">返回的结果数据集</param>
		/// <returns>1：成功/-1：失败</returns>
		[Obsolete("作废,使用QueryBalancesByInvoiceNO", true)]
		public int QueryInvoiceInformationByInvoiceNo(string strInvoiceNo, ref System.Data.DataSet dsResult)
		{
			return 1;
		}
		
		/// <summary>
		/// 发票注销
		/// </summary>
		/// <param name="oldInvoiceNo"></param>
		/// <param name="operDate"></param>
		/// <returns></returns>
		[Obsolete("作废,使用LogOutInvoice", true)]
		public int LonoutBill(string oldInvoiceNo, DateTime operDate)
		{
			return 0;
		}

		
		/// <summary>
		/// 作废费用信息用
		/// </summary>
		/// <param name="type"></param>
		/// <param name="invoiceSeq"></param>
		/// <param name="cancelType"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateCancelTyeByInvoiceSequence", true)]
		public int UpdateOutItemsUsingSeqNo(string type, string invoiceSeq, CancelTypes cancelType)
		{
			string strSQL = null;
			string strIndex = null;
			switch(type)
			{
				case "1"://发票主表
					strIndex = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.Invoice";
					break;
				case "2"://发票明细表
					strIndex = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.InvoiceDetail";
					break;
				case "3"://费用明细表
					strIndex = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.FeeDetail";
					break;
				case "4"://支付方式
					strIndex = "Fee.OutPatient.UpdateOutItemsUsingSeqNo.PayMode";
					break;
			}
			if(this.Sql.GetSql(strIndex, ref strSQL) == -1)
			{
				this.Err += "没有找到索引为:" + strIndex + "的sql语句";
				return -1;
			}
			
			try
			{
				strSQL = string.Format(strSQL, invoiceSeq, ((int)cancelType).ToString());
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				return -1;
			}
			return this.ExecNoQuery(strSQL);
		}

		/// <summary>
		/// 获得门诊批费项目列表
		/// </summary>
		/// <param name="deptCode">收费员所在科室</param>
		/// <param name="ds">项目列表</param>
		/// <returns> -1 失败 > 0 成功</returns>
		[Obsolete("作废,使用QueryItemList", true)]
		public int GetItemList(string deptCode, ref DataSet ds)
		{
			return -1;
		}

		/// <summary>
		/// 根据发票号作废明细
		/// </summary>
		/// <param name="invoNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalanceCancelType", true)]
		public int UpdateInvoDetailCancelFlag(string invoNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("Fee.OutPatient.UpdateInvoDetailCancelFlagByInvo",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,invoNo);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 根据发票号和病理卡号作废发票
		/// </summary>
		/// <param name="invoNo"></param>
		/// <param name="cardNo"></param>
		/// <param name="Sysdate"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalanceCancelType", true)]
		public int UpdateInvoInfoCancelFlag(string invoNo,string cardNo,string Sysdate)
		{
			string strSql = "";
			if(this.Sql.GetSql("Fee.OutPatient.UpdateInvoInfoCancelFlag",ref strSql)==-1)return -1;
			try
			{
				strSql = string.Format(strSql,invoNo,cardNo,this.Operator.ID,Sysdate);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 更新发票表
		/// </summary>
		/// <param name="oldInvoiceNo"></param>
		/// <param name="invoiceSeq"></param>
		/// <param name="operDate"></param>
		/// <param name="cancelType"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalanceCancelType", true)]
		public int UpdateInvoCancelFlag(string oldInvoiceNo, string invoiceSeq, DateTime operDate,CancelTypes cancelType)
		{
			return -1;
		}
		/// <summary>
		/// 更新发票明细
		/// </summary>
		/// <param name="oldInvoiceNo"></param>
		/// <param name="invoiceSeq"></param>
		/// <param name="operDate"></param>
		/// <param name="cancelType"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalanceListCancelType", true)]
		public int UpdateInvoDetailCancelFlag(string oldInvoiceNo, string invoiceSeq, DateTime operDate,CancelTypes cancelType)
		{
			return -1;
		}

		/// <summary>
		/// 根据项目流水号和内流水号作废项目记录
		/// </summary>
		/// <param name="recipe"></param>
		/// <param name="seq"></param>
		/// <param name="cancelType"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateFeeItemListCancelType", true)]
		public int UpdateFeeDetailCancelFlag(string recipe, int seq,CancelTypes cancelType)
		{
			return -1;
		}

		/// <summary>
		/// 根据项目流水号和内流水号作废项目记录
		/// </summary>
		/// <param name="oldInvoiceNo"></param>
		/// <param name="operDate"></param>
		/// <param name="cancelType"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateFeeItemListCancelType", true)]
		public int UpdateFeeDetailCancelFlag(string oldInvoiceNo, DateTime operDate,Neusoft.HISFC.Models.Base.CancelTypes cancelType)
		{
			string strSql = "",CancelType = "0";
			if(this.Sql.GetSql("Fee.Outpatient.UpdateFeeDetailCancelFlag.1",ref strSql)==-1)return -1;
			
			try
			{
				switch(cancelType)
				{
					case Neusoft.HISFC.Models.Base.CancelTypes.Canceled:
						CancelType = "1";
						break;
					case Neusoft.HISFC.Models.Base.CancelTypes.LogOut:
						CancelType = "3";
						break;
					case Neusoft.HISFC.Models.Base.CancelTypes.Valid:
						CancelType = "0";
						break;
					case Neusoft.HISFC.Models.Base.CancelTypes.Reprint:
						CancelType = "2";
						break;
					default:
						CancelType = "0";
						break;

				}
				strSql = string.Format(strSql,oldInvoiceNo,operDate,CancelType);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 根据一主发票号，获取全部兄弟发票号的费用明细
		/// </summary>
		/// <param name="strInvo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemListsSameInvoiceCombNOByInvoiceNO", true)]
		public ArrayList GetBrotherFeeDetail(string strInvo)
		{
			return null;
		}

		/// <summary>
		/// 根据发票流水号，获取全部兄弟发票号   
		/// </summary>
		/// <param name="strSeq">主发票号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancesByInvoiceSequence", true)]
		public ArrayList GetBrotherInvoBySeq(string strSeq)
		{
			return null;
		}

		/// <summary>
		/// 根据主发票号，获取全部兄弟发票号   
		/// </summary>
		/// <param name="strInvo">主发票号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancesSameInvoiceCombNOByInvoiceNO", true)]
		public ArrayList GetBrotherInvo(string strInvo)
		{
			return null;
		}
		
		/// <summary>
		/// 根据发票序列获得支付方式
		/// </summary>
		/// <param name="seq"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancePaysByInvoiceSequence", true)]
		public ArrayList GetPayModeBySeq(string seq)
		{
			return null;
		}


		/// <summary>
		/// 根据发票序列获得费用明细
		/// </summary>
		/// <param name="seq"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemListsByInvoiceSequence", true)]
		public ArrayList GetBrotherFeeDetailBySeq(string seq)
		{
			return null;
		}
		/// <summary>
		/// 当时发票的发票明细
		/// </summary>
		/// <param name="invoiceNo"></param>
		/// <param name="seq"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalanceListsByInvoiceNOAndInvoiceSequence", true)]
		public ArrayList GetBalanceBrotherInvoDetailBySeq(string invoiceNo, string seq)
		{
			return null;
		}
		/// <summary>
		/// 根据发票序列获得发票明细
		/// </summary>
		/// <param name="seq"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalanceListsByInvoiceSequence", true)]
		public ArrayList GetBalanceBrotherInvoDetailBySeq(string seq)
		{
			return null;
		}

		/// <summary>
		/// 根据一个发票号 获取所有的兄弟发票的明细
		/// </summary>
		/// <param name="strInvo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalanceListsSameInvoiceCombNOByInvoiceNO", true)]
		public ArrayList GetBalanceBrotherInvoDetail(string strInvo)
		{
			return null;
		}
		
		/// <summary>
		/// 获得患者的正交易发票信息，发票重打用
		/// </summary>
		/// <param name="invoNo">发票号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancesValidByInvoiceNO", true)]
		public ArrayList GetValidInvoiceInfo(string invoNo)
		{
			string strMain = "";
			string strWhere = "";

			strMain = this.GetBalanceSelectSql();
			
			if(this.Sql.GetSql("Fee.Outpatient.GetValidInvoiceInfo.Where.1", ref strWhere) == -1)
			{
				this.Err += "获得索引 Fee.Outpatient.GetValidInvoiceInfo.Where.1 出错";
				return null;
			}
			try
			{
				strWhere = string.Format(strWhere, invoNo);
			}
			catch(Exception ex)
			{
				this.Err += ex.Message;
				return null;
			}

			return this.QueryBalancesBySql(strMain + strWhere);
		}
		/// <summary>
		/// 得到当前操作员从当前开始计算前N张发票的信息
		/// </summary>
		/// <param name="count">数量</param>
		/// <returns>符合信息的发票实体信息 null 错误</returns>
		[Obsolete("作废,使用QueryBalancesByCount", true)]
		public ArrayList GetSpecifyCountsInfosSinceNow(int count)
		{
			string sql = null;
			if(this.Sql.GetSql("Fee.Outpatient.GetSpecifyCountsInfosSinceNow.Select.1", ref sql) == -1)
			{
				this.Err += "获得索引 Fee.Outpatient.GetSpecifyCountsInfosSinceNow.Select.1 出错";
				return null;
			}
			try
			{
				sql = string.Format(sql, this.Operator.ID, count + 1);	
			}
			catch(Exception ex)
			{
				this.Err += ex.Message;
				return null;
			}
			return this.QueryBalancesBySql(sql);
		}
		/// <summary>
		/// 更新发票明细
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalanceList", true)]
		public int UpdateInvoDetail(Neusoft.HISFC.Models.Fee.Outpatient.BalanceList obj)
		{
			string strSql="";			
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.InvoDetail.Update",ref strSql)==-1) return -1;
			try
			{
				//获取参数列表
				strParam = GetBalanceListParams(obj);
				strSql = string.Format(strSql,strParam);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
            
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 插入发票明细
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用InsertBalanceList", true)]
		public int InsertInvoDetail(Neusoft.HISFC.Models.Fee.Outpatient.BalanceList objInvoDetail)
		{
			string sql = string.Empty;
			//取插入操作的SQL语句
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.InvoDetail.Insert",ref sql) == -1) 
			{
				this.Err = "没有找到字段!";
				return -1;
			}
			try
			{

				if (objInvoDetail.ID == null) return -1;
				strParam = GetBalanceListParams(objInvoDetail);  
				
			}
			catch(Exception ex)
			{
				this.Err = "格式化SQL语句时出错:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql,strParam);
		}
		
		
		/// <summary>
		/// 更新发票信息
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalance", true)]
		public int UpdateInvoInfo(Neusoft.HISFC.Models.Fee.Outpatient.Balance obj)
		{
			string strSql="";			
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.InvoInfo.Update",ref strSql)==-1) return -1;
			try
			{
				//获取参数列表
				strParam = this.GetBalanceParams(obj);
				strSql = string.Format(strSql,strParam);

			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
            
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 插入发票信息
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用InsertBalance", true)]
		public int InsertInvoInfo(Balance objInvoInfo)
		{
			string strSQL = "";
			//取插入操作的SQL语句
			string[] strParam ;
			if(this.Sql.GetSql("Fee.OutPatient.InvoInfo.Insert",ref strSQL) == -1) 
			{
				this.Err = "没有找到字段!";
				return -1;
			}
			try
			{
				if (objInvoInfo.ID == null) return -1;
				strParam = this.GetBalanceParams(objInvoInfo);  
				
			}
			catch(Exception ex)
			{
				this.Err = "格式化SQL语句时出错:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(strSQL,strParam);
		}

		/// <summary>
		/// 获得收费序列号
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用GetRecipeSequence", true)]
		public string GetRecipeSeq()
		{
			return this.GetSequence("Fee.OutPatient.GetRecipeSeq.Select");
		}
		/// <summary>
		/// 获得发票流水号
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用GetInvoiceCombNO", true)]
		public string GetInvoiceSeq()
		{
			return this.GetSequence("Fee.OutPatient.GetInvoiceSeq.Select");
		}
		/// <summary>
		/// 获得自动生成的卡号， 主要为收费直接输入患者信息时生成。
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用GetAutoCardNO", true)]
		public string GetAutoCardNo()
		{
			string tempCardNo = this.GetSequence("Fee.OutPatient.GetAutoCardNo.Select");
			
			return tempCardNo.PadLeft(9, '0');
		}

		/// <summary>
		/// 获得处方号
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用GetRecipeNO", true)]
		public string GetRecipeNo()
		{
			return this.GetSequence("Fee.OutPatient.GetRecipeNo.Select");
		}
		/// <summary>
		/// 修改处方明细
		/// </summary>
		/// <param name="f"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateFeeItemList", true)]
		public int UpdateFeeDetail(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f) 
		{
			string strSql="";			
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.ItemDetail.Update",ref strSql)==-1) return -1;
			try
			{
				//获取参数列表
				strParam = this.GetFeeItemListParams(f);
				strSql = string.Format(strSql,strParam);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
            
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		///  删除体检明细中体检号对应的未收费的处方明细
		/// </summary>
		/// <param name="clinicCode">体检号</param>
		/// <returns>1：成功</returns>
		[Obsolete("作废,使用DeleteFeeItemListByClinicNO", true)]
		public int DeleteFeeDetail(string clinicCode)
		{
			string strSQL = "";
			if (this.Sql.GetSql("Neusoft.HISFC.BizLogic.Fee.CheckUp.DeleteFeeList",ref strSQL)==-1)
			{
				this.Err = "没有删除用的SQL语句";
				return -1;
			}
			strSQL = string.Format(strSQL,clinicCode);
			try
			{
				if(this.ExecNoQuery(strSQL)==-1)
				{
					this.Err = "执行删除失败";
					return -2;
				}
			}
			catch(Exception ex)
			{
				this.Err = "执行删除失败" + ex.Message;
				return -2;
			}
			return 1;
		}
		/// <summary>
		/// 删除划价遗留的组套信息
		/// </summary>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用DeletePackageByMoOrder", true)]
		public int DeleteGroup(string seqNo)
		{
			string strSQL = "";
			if (this.Sql.GetSql("Fee.OutPatient.DeleteGroup",ref strSQL)==-1)
			{
				this.Err = "没有删除用的SQL语句";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, seqNo);
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				return -1;
			}
			
			return this.ExecNoQuery(strSQL);
		}
		/// <summary>
		/// 根据医嘱或者体检项目流水号删除明细
		/// </summary>
		/// <param name="seqNo">医嘱或者体检项目流水号</param>
		/// <returns>-1失败 0 没有删除记录 >=1删除成功</returns>
		[Obsolete("作废,使用DeleteFeeItemListByMoOrder", true)]
		public int DeleteFeeDetailBySeqNo(string seqNo)
		{
			string strSQL = "";
			if (this.Sql.GetSql("Fee.OutPatient.DeleteFeeDetailbySeqNo",ref strSQL)==-1)
			{
				this.Err = "没有删除用的SQL语句";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, seqNo);
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				return -1;
			}
			
			return this.ExecNoQuery(strSQL);
		}
		/// <summary>
		/// 根据处方号和处方内流水号删除费用明细.
		/// </summary>
		/// <param name="recipeNo">处方号</param>
		/// <param name="seqNo">处方内流水号</param>
		/// <returns>-1失败 0 没有删除记录 >=1删除成功</returns>
		[Obsolete("作废,使用DeleteFeeItemListByRecipeNO", true)]
		public int DeleteFeeDetail(string recipeNo, string seqNo)
		{
			string strSQL = "";
			if (this.Sql.GetSql("Fee.OutPatient.DeleteFeeDetailByRecipeNo",ref strSQL)==-1)
			{
				this.Err = "没有删除用的SQL语句";
				return -1;
			}
			try
			{
				strSQL = string.Format(strSQL, recipeNo, seqNo);
			}
			catch(Exception e)
			{
				this.Err = e.Message;
				return -1;
			}
			
			return this.ExecNoQuery(strSQL);
		}
		/// <summary>
		/// 插入处方明细
		/// </summary>
		/// <returns></returns>
		[Obsolete("作废,使用InsertFeeItemList", true)]
		public int InsertFeeDetail(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList objFeeItemList) 
		{
			string sql = string.Empty;
			//取插入操作的SQL语句
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Item.Undrug.GetFeeItemDetail.Insert",ref sql) == -1) 
			{
				this.Err = "没有找到字段!";
				return -1;
			}
			try
			{
				//取处方号
				//				objFeeItemList.ID = this.GetSequence("Manager.%CLASSName%.GetConstantID");
				//				if (objFeeItemList.ID == null) return -1;
				strParam = this.GetFeeItemListParams(objFeeItemList);  
				
			}
			catch(Exception ex)
			{
				this.Err = "格式化SQL语句时出错:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql,strParam);
		}
		/// <summary>
		/// 删除处方明细根据组合号
		/// </summary>
		/// <param name="combNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用DeleteFeeItemListByCombNO", true)]
		public int DelFeeDetail(string combNo)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.DelFeeDetail.1",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,combNo);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}			
			return this.ExecNoQuery(strSql);
		}
		/// <summary>
		/// 检索非药品明细
		/// </summary>
		/// <param name="invoNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryUndrugFeeItemListByInvoiceSequence", true)]
		public ArrayList GetUnDrugItemList(string invoNo)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetSqlFeeDetail();
			if(this.Sql.GetSql("Fee.Item.GetUndrugItemList.Where",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,invoNo);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.QueryFeeDetailBySql(strSql1);
		}
		
		/// <summary>
		/// 检索药品明细
		/// </summary>
		/// <param name="invoNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryDrugFeeItemListByInvoiceSequence", true)]
		public ArrayList GetDrugItemList(string invoNo)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetSqlFeeDetail();
			if(this.Sql.GetSql("Fee.Item.GetDrugItemList.Where",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,invoNo);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.QueryFeeDetailBySql(strSql1);
		}
		/// <summary>
		/// 根据处方号和项目流水号获得项目明细实体
		/// </summary>
		/// <param name="noteNo"></param>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用GetFeeItemList", true)]
		public Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList GetItemObj(string noteNo,int seqNo)
		{
			string sql="",where="";
			sql = this.GetSqlFeeDetail();
			if(sql == "")return null;			
			if(this.Sql.GetSql("Fee.Item.GetDrugItemList.Where2",ref where)==-1)return null;

			try
			{
				where=string.Format(where,noteNo,seqNo.ToString());
			}
			catch(Exception e)
			{
				this.Err="[Registration.Register.Query.6]"+e.Message;
				this.ErrCode=e.Message;
				return null;
			}

			sql=sql +" "+where;
			al = this.QueryFeeDetailBySql(sql);
			if(this.al.Count>0)
				return (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList)this.al[0];
			else
				return null;
		}
		/// <summary>
		/// 获得患者的 已经收费， 未确认的指定 需要院注的项目信息
		/// </summary>
		/// <param name="cardNo"></param>
		/// <param name="isInject">t需要有院注的项目 false 查询患者所有项目</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemLists", true)]
		public ArrayList GetChargeDetail(string cardNo, bool isInject)
		{
			string strSqlWhere = "";
			string strSqlOrg = "";
			if(this.Sql.GetSql("Fee.Outpatient.GetChargeDetail.Select.3", ref strSqlWhere) == -1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.Outpatient.GetChargeDetail.Select.1";
				return null;
			}
			if(!isInject)
			{
				//return this.GetChargeDetail(cardNo);
			}
			try
			{
				strSqlWhere = string.Format(strSqlWhere, cardNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}
			strSqlOrg = GetSqlFeeDetail();
			strSqlOrg = strSqlOrg + strSqlWhere;
			return QueryFeeDetailBySql(strSqlOrg);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cardNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemListsByCardNO()", true)]
		public ArrayList GetFeeDetailByCardNo(string cardNo)
		{
			string strSql = "",strWhere = "";
			if(this.Sql.GetSql("Fee.Outpatient.GetFeeDetail.Where.1", ref strWhere) == - 1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.Outpatient.GetFeeDetail.Where.1";
				return null;
			}
			try
			{
				strWhere = string.Format(strWhere, cardNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}

			strSql = this.GetSqlFeeDetail();
			strSql = strSql +" "+strWhere;
			return QueryFeeDetailBySql(strSql);
		}

		/// <summary>
		/// 通过患者卡号，得到费用明细
		/// </summary>
		/// <param name="cardNo">患者病例号</param>
		/// <returns>null 错误 ArrayList Fee.Outpatient.FeeItemList实体集合</returns>
		[Obsolete("作废,使用QueryFeeItemListsByCardNO()", true)]
		public ArrayList GetFeeDetailFromCardNo(string cardNo)
		{
			string strSql = "";
			if(this.Sql.GetSql("Fee.Outpatient.GetFeeDetail.Select.1", ref strSql) == - 1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.Outpatient.GetFeeDetail.Select.1";
				return null;
			}
			try
			{
				strSql = string.Format(strSql, cardNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}

			return QueryFeeDetailBySql(strSql);
		}
		
		/// <summary>
		/// 插入支付情况表
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		[Obsolete("作废,使用InsertBalancePay()", true)]
		public int InsertPayMode(Neusoft.HISFC.Models.Fee.Outpatient.BalancePay obj)
		{
			string sql = string.Empty;
			//取插入操作的SQL语句
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.PayMode.Insert",ref sql) == -1) 
			{
				this.Err = "没有找到字段!";
				return -1;
			}
			try
			{
				if (obj.Invoice.ID == null) return -1;
				strParam = this.GetBalancePayParams(obj);  				
			}
			catch(Exception ex)
			{
				this.Err = "格式化SQL语句时出错:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql,strParam);
		}
		/// <summary>
		/// 修改日结信息
		/// </summary>
		/// <param name="dayBalance"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalancePay()", true)]
		public int UpdateDayBalance(Neusoft.HISFC.Models.Fee.Outpatient.BalancePay dayBalance)
		{
			string strSql="";			
			string[] strParam ;
			if(this.Sql.GetSql("Fee.OutPatient.PayMode.Update",ref strSql)==-1) return -1;
			try
			{
				//获取参数列表
				strParam = this.GetBalancePayParams(dayBalance);
				strSql = string.Format(strSql,strParam);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
            
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="invoNo">发票号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancePayByInvoiceNO()", true)]
		public ArrayList GetPayModeByInvo(string invoNo)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetBalancePaySelectSql();
			if(this.Sql.GetSql("Fee.Outpatient.GetSqlPayMode.Where.1",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,invoNo);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.QueryBalancePaysBySql(strSql1);
		}

		/// <summary>
		/// 修改支付情况表
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		[Obsolete("作废,使用UpdateBalancePay()", true)]
		public int UpdatePayMode(Neusoft.HISFC.Models.Fee.Outpatient.BalancePay obj)
		{
			string strSql="";			
			string[] strParam ;
			if(this.Sql.GetSql("Fee.Outpatient.PayMode.Update",ref strSql)==-1) return -1;
			try
			{
				//获取参数列表
				strParam = this.GetBalancePayParams(obj);
				strSql = string.Format(strSql,strParam);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
            
			return this.ExecNoQuery(strSql);
		}
		
		/// <summary>
		/// 通过发票号获得获得患者费用明细信息
		/// </summary>
		/// <param name="invoNo">发票号</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemListsByInvoiceNO()", true)]
		public ArrayList GetChargeDetailFromInvoiceNo(string invoNo)
		{
			string strSqlWhere = "";
			string strSqlOrg = "";
			if(this.Sql.GetSql("Fee.OutPatient.GetChargeDetailFromInvoiceNo.Where.1", ref strSqlWhere) == -1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.OutPatient.GetChargeDetailFromInvoiceNo.Where.1";
				return null;
			}
			try
			{
				strSqlWhere = string.Format(strSqlWhere, invoNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}
			strSqlOrg = GetSqlFeeDetail();
			strSqlOrg = strSqlOrg + strSqlWhere;
			return QueryFeeDetailBySql(strSqlOrg);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="invoNo"></param>
		/// <returns></returns>
		[Obsolete("作废,不使用()", true)]
		public ArrayList QueryFeeDetailByInvoiceNo(string invoNo)
		{
			string strSqlWhere = "";
			string strSqlOrg = "";
			if(this.Sql.GetSql("Fee.Outpatient.GetChargeDetailFromInvoiceNo.Where.5", ref strSqlWhere) == -1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.Outpatient.GetChargeDetailFromInvoiceNo.Where.1";
				return null;
			}
			try
			{
				strSqlWhere = string.Format(strSqlWhere, invoNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}
			strSqlOrg = GetSqlFeeDetail();
			strSqlOrg = strSqlOrg + strSqlWhere;
			return QueryFeeDetailBySql(strSqlOrg);
		}
		/// <summary>
		/// 获得患者的未收费项目信息
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
		[Obsolete("作废,QueryFeeItemListsByClinicNO()", true)]
		public ArrayList GetChargeDetail(string clinicNo)
		{
			string strSqlWhere = "";
			string strSqlOrg = "";
			if(this.Sql.GetSql("Fee.OutPatient.GetChargeDetail.Select.1", ref strSqlWhere) == -1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.OutPatient.GetChargeDetail.Select.1";
				return null;
			}
			try
			{
				strSqlWhere = string.Format(strSqlWhere, clinicNo);
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}
			strSqlOrg = GetSqlFeeDetail();
			strSqlOrg = strSqlOrg + strSqlWhere;
			return QueryFeeDetailBySql(strSqlOrg);
		}

		/// <summary>
		/// 获得患者的 已经收费， 未确认的指定SysClass的项目信息
		/// </summary>
		/// <param name="cardNo">患者卡号</param>
		/// <param name="sysClass">项目系统类别</param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryFeeItemList()", true)]
		public ArrayList GetChargeDetail(string cardNo, Neusoft.HISFC.Models.Base.EnumSysClass sysClass)
		{
			string strSqlWhere = "";
			string strSqlOrg = "";
			if(this.Sql.GetSql("Fee.OutPatient.GetChargeDetail.Select.2", ref strSqlWhere) == -1)
			{
				this.Err += "获得SQL语句出错" + "索引: Fee.Outpatient.GetChargeDetail.Select.1";
				return null;
			}
			try
			{
				strSqlWhere = string.Format(strSqlWhere, cardNo, sysClass.ToString());
			}
			catch(Exception ex)
			{
				this.Err += "参数付值出错!" + ex.Message;
				return null;
			}
			strSqlOrg = GetSqlFeeDetail();
			strSqlOrg = strSqlOrg + strSqlWhere;
			return QueryFeeDetailBySql(strSqlOrg);
		}
		/// <summary>
		/// 根据患者卡号和时间段查找符合条件的发票实体集合
		/// </summary>
		/// <param name="cardNo">患者卡号</param>
		/// <param name="dtBegin">开始时间</param>
		/// <param name="dtEnd">结束时间</param>
		/// <returns>null失败 count = 0 没有结果 〉0 正确</returns>
		[Obsolete("作废,使用QueryBalancesByCardNO()", true)]
		public ArrayList GetInvoiceInfoByPatientCardNo(string cardNo, DateTime dtBegin, DateTime dtEnd)
		{
			string strMain = "";
			string strWhere = "";

			strMain = this.GetBalanceSelectSql();
			
			if(this.Sql.GetSql("Fee.Outpatient.GetInvoiceInfoByPatientCardNo.Where.1", ref strWhere) == -1)
			{
				this.Err += "获得索引 Fee.Outpatient.GetInvoiceInfoByPatientCardNo.Where.1 出错";
				return null;
			}
			try
			{
				strWhere = string.Format(strWhere, cardNo, dtBegin.ToString(), dtEnd.ToString());
			}
			catch(Exception ex)
			{
				this.Err += ex.Message;
				return null;
			}

			return this.QueryBalancesBySql(strMain + strWhere);
		}
		/// <summary>
		/// 根据患者姓名和时间段查找符合条件的发票实体集合
		/// </summary>
		/// <param name="name">患者卡号</param>
		/// <param name="dtBegin">开始时间</param>
		/// <param name="dtEnd">结束时间</param>
		/// <returns>null失败 count = 0 没有结果 〉0 正确</returns>
		[Obsolete("作废,使用QueryBalancesByName()", true)]
		public ArrayList GetInvoiceInfoByPatientName(string name, DateTime dtBegin, DateTime dtEnd)
		{
			string strMain = "";
			string strWhere = "";

			strMain = this.GetBalanceSelectSql();
			
			if(this.Sql.GetSql("Fee.Outpatient.GetInvoiceInfoByPatientName.Where.1", ref strWhere) == -1)
			{
				this.Err += "获得索引 Fee.Outpatient.GetInvoiceInfoByPatientName.Where.1 出错";
				return null;
			}
			try
			{
				strWhere = string.Format(strWhere, name, dtBegin.ToString(), dtEnd.ToString());
			}
			catch(Exception ex)
			{
				this.Err += ex.Message;
				return null;
			}

			return this.QueryBalancesBySql(strMain + strWhere);
		}
		/// <summary>
		/// 获得发票信息
		/// </summary>
		/// <param name="invoNo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalancesByInvoiceNO()", true)]
		public ArrayList GetBalanceInfoByInvoNo(string invoNo)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetBalanceSelectSql();
			if(this.Sql.GetSql("Fee.Outpatient.GetInvoInfo.Where",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,invoNo);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.QueryBalancesBySql(strSql1);
		}
		
		/// <summary>
		/// 获得发票明细
		/// </summary>
		/// <param name="strInvo"></param>
		/// <returns></returns>
		[Obsolete("作废,使用QueryBalanceListsByInvoiceNO()", true)]
		public ArrayList GetBalanceInvoDetail(string strInvo)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetBalanceListsSql();
			if(this.Sql.GetSql("Fee.Outpatient.GetInvoDetail.Where",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,strInvo);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.QueryBalanceListsBySql(strSql1);
		}

		/// <summary>
		/// 获得门诊收费项目列表
		/// </summary>
		/// <param name="itemType">显示的项目类别</param>
		/// <param name="inputType">查询方式</param>
		/// <param name="queryCode">查询码</param>
		/// <param name="beginRows">起始行</param>
		/// <param name="endRows">结束行</param>
		/// <returns></returns>
		[Obsolete("作废作废", true)]
		public ArrayList GetItemList(ItemTypes itemType, InputTypes inputType, string queryCode, int beginRows, int endRows)
		{
			string sysClass = "";//系统类别;
			string drugFlag = "";//是否药品 1是 0 不是;
			string sql = string.Empty;
			ArrayList al = new ArrayList();//存放项目列表信息;

			Spell inputInfo = new Spell();

			switch(itemType)
			{
				case ItemTypes.All: //所有项目
					sysClass = "%";
					drugFlag = "%";
					break;
				case ItemTypes.AllMedicine: //所有药品项目
					sysClass = "P%";
					drugFlag = "1";
					break;
				case ItemTypes.WesternMedicine: //西药
					sysClass = "P";
					drugFlag = "1";
					break;
				case ItemTypes.ChineseMedicine: //中成药
					sysClass = "PCZ";
					drugFlag = "1";
					break;
				case ItemTypes.HerbalMedicine: //中草药
					sysClass = "PCC";
					drugFlag = "1";
					break;
				case ItemTypes.Undrug: //非药品
					sysClass = "%";
					drugFlag = "0";
					break;
				default: //默认选择所有项目
					sysClass = "%";
					drugFlag = "%";
					break;
			}

			switch(inputType)
			{
				case InputTypes.Spell: //输入的是拼音
					inputInfo.SpellCode = "%" + queryCode + "%";
					inputInfo.WBCode = "%";
					inputInfo.UserCode = "%";
					inputInfo.Name = "%";
					break;
				case InputTypes.WB: //输入的是五笔
					inputInfo.SpellCode = "%";
					inputInfo.WBCode = "%" + queryCode + "%";
					inputInfo.UserCode = "%";
					inputInfo.Name = "%";
					break;
				case InputTypes.UserCode: //输入的是自定义
					inputInfo.SpellCode = "%";
					inputInfo.WBCode = "%";
					inputInfo.UserCode = "%" + queryCode + "%";
					inputInfo.Name = "%";
					break;
				case InputTypes.Name: //输入的是名称
					inputInfo.SpellCode = "%";
					inputInfo.WBCode = "%";
					inputInfo.UserCode = "%" + queryCode + "%";
					inputInfo.Name = "%";
					break;
				default: //默认为拼音
					inputInfo.SpellCode = "%" + queryCode + "%";
					inputInfo.WBCode = "%";
					inputInfo.UserCode = "%";
					inputInfo.Name = "%";
					break;
			}

			if(this.Sql.GetSql("Fee.Item.Undrug.GetOutPatientItemList.Select", ref sql) == -1)
			{
				this.Err = "获得SQL出错";
				return null;
			}

			try
			{
				sql = string.Format(sql, sysClass, drugFlag, inputInfo.SpellCode, inputInfo.WBCode,
					inputInfo.UserCode, inputInfo.Name, beginRows, endRows);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return null;
			}

			this.ExecQuery(sql);

			Neusoft.HISFC.Models.Fee.Item.Undrug feeItem = null;
			Neusoft.HISFC.Models.Pharmacy.Item drugItem = null;

			try
			{	
				while(Reader.Read())
				{
					if(Reader[0].ToString() == "1")//药品
					{
						drugItem = new Neusoft.HISFC.Models.Pharmacy.Item();
						drugItem.IsPharmacy = true;
						drugItem.SysClass.ID = Reader[1].ToString();
						drugItem.MinFee.ID = Reader[2].ToString();
						drugItem.ID = Reader[3].ToString();
						drugItem.Name = Reader[4].ToString();
						drugItem.NameCollection.EnglishName = Reader[5].ToString();
						drugItem.Specs = Reader[6].ToString();
						drugItem.DosageForm.ID = Reader[7].ToString();
						drugItem.Price = NConvert.ToDecimal(Reader[8].ToString());
						drugItem.ChildPrice = NConvert.ToDecimal(Reader[9].ToString());
						drugItem.SpecialPrice = NConvert.ToDecimal(Reader[10].ToString());
						drugItem.PriceUnit = Reader[11].ToString();
						al.Add(drugItem);
						drugItem = null;
					}
					else //非药品
					{
						feeItem = new Neusoft.HISFC.Models.Fee.Item.Undrug();
						feeItem.IsPharmacy = false;
						feeItem.SysClass.ID = Reader[1].ToString();
						feeItem.MinFee.ID = Reader[2].ToString();
						feeItem.ID = Reader[3].ToString();
						feeItem.Name = Reader[4].ToString();
						feeItem.Specs = Reader[6].ToString();
						feeItem.Price = NConvert.ToDecimal(Reader[8].ToString());
						feeItem.ChildPrice = NConvert.ToDecimal(Reader[9].ToString());
						feeItem.SpecialPrice = NConvert.ToDecimal(Reader[10].ToString());
						feeItem.PriceUnit = Reader[11].ToString();
						feeItem.ExecDept = Reader[12].ToString();
						al.Add(feeItem);
						feeItem = null;
					}
				}

				Reader.Close();
				return al;
			}
			catch(Exception ex)
			{
				if(Reader != null || !Reader.IsClosed)
				{
					Reader.Close();
				}
				feeItem = null;
				drugItem = null;
				al = null;
				this.Err += ex.Message;
				return null;
			}
			finally
			{
				feeItem = null;
				drugItem = null;
				al = null;
			}
		}

		ArrayList al = new ArrayList();

		
		
		
		#endregion

		#region 院注维护

		/// <summary>
		/// 获得对象参数
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		protected string [] myGetParmInjectInfo(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string[] strParm={	
								 obj.ID,
								 obj.Name,
								 obj.Memo,
								 obj.User01,
								 obj.User02												
							 };

			return strParm;

		}


		/// <summary>
		/// 删除用法项目信息
		/// </summary>
		/// <param name="Usage"></param>
		/// <returns></returns>
		public int DelInjectInfo(string Usage)
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.OutPatient.DelInjectInfo.Del",ref strSql)==-1) return -1;
			try
			{
				strSql = string.Format(strSql,Usage);
			}
			catch(Exception ex)
			{
				this.Err=ex.Message;
				this.ErrCode=ex.Message;
				return -1;
			}
			return this.ExecNoQuery(strSql);
		}

		/// <summary>
		/// 插入用法项目信息
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int InsertInjectInfo(Neusoft.FrameWork.Models.NeuObject obj)
		{
			string sql = string.Empty;
			//取插入操作的SQL语句
			//			 obj.ID,
			//								 obj.Name,
			//								 obj.Memo,
			//								 obj.User01,
			//								 obj.User02		
			string[] strParam ;
			if(this.Sql.GetSql("Fee.OutPatient.InsertInjectInfo.Insert",ref sql) == -1) 
			{
				this.Err = "没有找到字段!";
				return -1;
			}
			try
			{
				if (obj.ID == null) return -1;
				strParam = this.myGetParmInjectInfo(obj); 
				
			}
			catch(Exception ex)
			{
				this.Err = "格式化SQL语句时出错:" + ex.Message;
				this.WriteErr();
				return -1;
			}
			return this.ExecNoQuery(sql,strParam);
			
		}

		/// <summary>
		/// 获得用法项目信息sql语句
		/// </summary>
		/// <returns></returns>
		public string GetSqlInject() 
		{
			string strSql = "";
			if (this.Sql.GetSql("Fee.OutPatient.GetSqlInject.Select",ref strSql)==-1) return null;
			return strSql;
		}

		/// <summary>
		/// 获得院注信息根据用法
		/// </summary>
		/// <param name="usageCode"></param>
		/// <returns></returns>
		public ArrayList GetInjectInfoByUsage(string usageCode)
		{
			string strSql1="";
			string strSql2="";
			//获得项目明细的SQL语句
			strSql1=this.GetSqlInject();
			if(this.Sql.GetSql("Fee.OutPatient.GetSqlInject.Where1",ref strSql2)==-1)return null;
			strSql1=strSql1+" "+strSql2;
			try
			{
				strSql1=string.Format(strSql1,usageCode);
			}
			catch(Exception ex)
			{
				this.ErrCode = ex.Message;
				this.Err = ex.Message;
				return null;
			}			
			return this.GetInjectInfo(strSql1);
		}

		private ArrayList GetInjectInfo(string strSql)
		{
			ArrayList al = new ArrayList();
			Neusoft.FrameWork.Models.NeuObject obj;
			this.ExecQuery(strSql);
			while (this.Reader.Read()) 
			{
				#region
				//USAGE_CODE	VARCHAR2(4)	N			用法代码
				//ITEM_CODE	VARCHAR2(12)	N			项目代码
				//ITEM_NAME	VARCHAR2(100)	Y			项目名称
				//OPER_CODE	VARCHAR2(6)	Y			操作员
				//OPER_DATE	DATE	Y			操作时间
				//USAGE_NAME	VARCHAR2(50)	Y			
				#endregion
				obj = new Neusoft.FrameWork.Models.NeuObject();
				try 
				{
					obj.ID = this.Reader[0].ToString();//项目代码
	
					obj.Name = this.Reader[1].ToString();//项目名称

					obj.Memo = this.Reader[2].ToString();//用法代码

					obj.User01 = this.Reader[3].ToString();//用法

					obj.User02 = this.Reader[4].ToString();//操作员
			
					obj.User03 = this.Reader[5].ToString();//操作时间				
					
				}

				catch(Exception ex) 
				{
					this.Err= "查询明细赋值错误"+ex.Message;
					this.ErrCode=ex.Message;
					this.WriteErr();
					return null;
				}
				
				al.Add(obj);
			}
			this.Reader.Close();
			return al;
		}


		#endregion

		

		#region 公费部分
		/// <summary>
		/// 获得公费患者当日已收取的药品费用金额
		/// </summary>
		/// <param name="mCardNo">患者卡号</param>
		/// <returns>公费患者当日已收取的药品费用金额 - 1错误</returns>
		public decimal GetDayDrugFee(string mCardNo)
		{
			string strSql = null;
			decimal tmpDayFee = 0;
			if (this.Sql.GetSql("Fee.Outpatient.GetDayDrugFee.Select", ref strSql) == -1) 
			{
				this.Err = Sql.Err;
				return -1;
			}
			try
			{
				strSql = string.Format(strSql, mCardNo);
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
			try
			{
				this.ExecQuery(strSql);
				while (this.Reader.Read()) 
				{
					tmpDayFee = NConvert.ToDecimal(Reader[0].ToString());
				}
				this.Reader.Close();

				return tmpDayFee;
			}
			catch(Exception ex)
			{
				this.Err = ex.Message;
				return -1;
			}
			finally
			{
				if(!Reader.IsClosed)
				{
					this.Reader.Close();
					strSql = null;
				}
			}
		}

		#endregion

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户收费新增

        /// <summary>
        /// 更新费用收费标记
        /// </summary>
        /// <param name="f">费用实体</param>
        /// <returns></returns>
        public int UpdateFeeDetailFeeFlag(FeeItemList f)
        {
            string[] parms = new string[] { f.RecipeNO,
                                            f.SequenceNO.ToString(),
                                            ((int)f.PayType).ToString(),
                                            f.FeeOper.ID,
                                            f.FeeOper.OperTime.ToString()};
            return this.UpdateSingleTable("Fee.OutPatient.UpdateFeeDetailFeeFlag", parms);
        }

        /// <summary>
        /// 根据处方号执行科室查询药品费用明细
        /// </summary>
        /// <param name="recipeNO"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList GetDurgFeeByRecipeAndDept(string recipeNO, string deptCode)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetDrugFeeByRecipeAndDept.Where", recipeNO, deptCode);
        }

        /// <summary>
        /// 根据病历号时间段获取
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="isDrug">是否药品</param>
        /// <returns></returns>
        public ArrayList GetDrugFeeByCardNODate(string cardNO, DateTime beginDate, DateTime endDate, bool isDrug)
        {
            return this.QueryFeeItemLists("Fee.OutPatient.GetFeeDetail.Where", cardNO, beginDate.ToString(), endDate.ToString(), NConvert.ToInt32(isDrug).ToString());
        }

        /// <summary>
        /// 根据处方号和项目流水号获得项目明细实体(收费信息)
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方内流水号</param>
        /// <returns>成功:费用明细实体 失败或者没有数据:null</returns>
        public FeeItemList GetFeeItemListForFee(string recipeNO, int sequenceNO)
        {
            ArrayList feeItemLists = this.QueryFeeItemLists("Fee.Item.GetDrugItemList.Where3", recipeNO, sequenceNO.ToString());
            if (feeItemLists == null)
            {
                return null;
            }

            if (feeItemLists.Count > 0)
            {
                return feeItemLists[0] as FeeItemList;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 根据处方号执行科室查找药品
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="deptCode">执行科室</param>
        /// <returns></returns>
        public int GetDrugUnFeeCount(string recipeNO, string deptCode)
        {
            return Convert.ToInt32(this.ExecSqlReturnOne("Fee.OutPatient.GetFeeDrugCountByRecipe", recipeNO, deptCode));
        }

        /// <summary>
        /// 生成临时的发票组号
        /// </summary>
        /// <returns></returns>
        public string GetTempInvoiceComboNO()
        {
            string resutValue = this.ExecSqlReturnOne("Fee.OutPatient.GetTempInvoiceSeq.Select");
            if (resutValue == "-1") return "-1";
            return "T" + resutValue;
        }

        /// <summary>
        /// 根据病历号获得未打印发票的账户项目明细
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="payType">收费划价标识</param>
        /// <param name="isAccount">是否账户费用</param>
        /// <returns></returns>
        public ArrayList GetAccountNoPrintFeeItemList(string cardNO, PayTypes payType,bool isAccount)
        {
            return this.QueryFeeItemLists("Fee.Item.GetDrugItemList.Where4", cardNO, ((int)payType).ToString(),NConvert.ToInt32(isAccount).ToString());
        }

        /// <summary>
        /// 更新费用的发票信息
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int UpdateFeeItemListInvoiceInfo(FeeItemList f)
        {
            string[] args = new string[] { f.RecipeNO, f.SequenceNO.ToString(), f.Invoice.ID, f.InvoiceCombNO };
            return this.UpdateSingleTable("Fee.OutPatient.UpdateFeeDetailInvoiceInfo", args);
        }

        /// <summary>
        /// 根据病历号查询账户患者未收费的费用信息
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <returns></returns>
        public ArrayList GetAccountNoFeeFeeItemList(string cardNO)
        {
            return this.QueryFeeItemLists("Fee.Item.GetDrugItemList.Where5", cardNO);
        }

        /// <summary>
        /// 根据clinicNO和Morder查询该费用是否收费
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <param name="morder"></param>
        /// <returns>大于0收费</returns>
        public int GetItemIsFee(string clinicNO, string morder,string itemCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Item.GetDrugItemList.Where8", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Item.GetDrugItemList.Where8的SQL失败！";
                return -1;
            }
            sql = string.Format(sql, clinicNO, morder,itemCode);
            return NConvert.ToInt32(base.ExecSqlReturnOne(sql));
        }
        #endregion

//        #region 门诊退费明细

//        /// <summary>
//        /// 门诊退费明细插入方法
//        /// </summary>
//        /// <returns></returns>
//        public int InsertQuite(Neusoft.HISFC.Models.Fee.Outpatient.QuiteItem quiteItem)
//        {
//            string Sql=@"INSERT INTO fin_opb_quiteitem   --门诊退费明细表
//          ( quite_no,   --退费序号
//            card_no,   --病历号
//            clinic_no,   --挂号序号
//            recipe_no,   --处方号
//            sequence_no,   --处方流水号
//            item_code,   --项目代码[12]
//            item_name,   --项目名称[13]
//            drug_flag,   --1药品/0非要[14]
//            fee_code,   --最小费用代码[19]
//            class_code,   --系统类别[20]
//            unit_price,   --单价[21]
//            qty,   --数量[22]
//            price_unit,   --计价单位[35]
//            pub_cost,   --可报效金额[36]
//            pay_cost,   --自付金额[37]
//            own_cost,   --现金金额[38]
//            invoice_no,   --票据号[51]
//            account_flag,   --账户支付
//            qutie_oper,   --退费人
//            qutie_date,   --退费时间
//            balance_no,   --日结标识号[20]
//            balance_opcd,   --日结人[21]
//            balance_date )  --日结时间
//     VALUES 
//          ( '{0}',   --退费序号
//            '{1}',   --病历号
//            '{2}',   --挂号序号
//            '{3}',   --处方号
//            {4},   --处方流水号
//            '{5}',   --项目代码[12]
//            '{6}',   --项目名称[13]
//            '{7}',   --1药品/0非要[14]
//            '{8}',   --最小费用代码[19]
//            '{9}',   --系统类别[20]
//            {10},   --单价[21]
//            {11},   --数量[22]
//            '{12}',   --计价单位[35]
//            {13},   --可报效金额[36]
//            {14},   --自付金额[37]
//            {15},   --现金金额[38]
//            '{16}',   --票据号[51]
//            '{17}',   --账户支付
//            '{18}',   --退费人
//            to_date('{19}','yyyy-MM-dd hh24:mi:ss'),   --退费时间
//            '{20}',   --日结标识号[20]
//            '{21}',   --日结人[21]
//            to_date('{22}','yyyy-MM-dd hh24:mi:ss') --日结时间
//            ); ";
//            try
//            {
//                if (quiteItem.QuiteNO == "" || quiteItem.QuiteNO == string.Empty)
//                {
//                    this.Err="关键字不能为空！";
//                    return -1;
//                }
//                string[] strParam = this.myGetParmInsertQuite(quiteItem);
//                Sql = string.Format(Sql,strParam);
//            }
//            catch(Exception ex) 
//            {
//                this.Err = "插入数据失败！" + ex.Message;
//                return -1;
//            }
//            finally
//            {
//                this.Reader.Close();
//            }
//            return this.ExecNoQuery(Sql);
//        }

//        /// <summary>
//        /// SQL辅值语句
//        /// </summary>
//        /// <param name="quiteItem"></param>
//        /// <returns></returns>
//        protected string[] myGetParmInsertQuite(Neusoft.HISFC.Models.Fee.Outpatient.QuiteItem quiteItem)
//        {
//            string[] strParm ={	
//                                 quiteItem.QuiteNO,
//                                 quiteItem.CardNO,
//                                 quiteItem.ClinicNO,
//                                 quiteItem.RecipeNO,
//                                 quiteItem.SequenceNO.ToString(),
//                                 quiteItem.ItemCode,
//                                 quiteItem.ItemName,
//                                 quiteItem.DrugFlag,
//                                 quiteItem.FeeCode,
//                                 quiteItem.ClassCode,
//                                 quiteItem.UnitPrice.ToString(),
//                                 quiteItem.Qty.ToString(),
//                                 quiteItem.RecipeNO,
//                                 quiteItem.Ft.PubCost.ToString(),
//                                 quiteItem.Ft.PayCost.ToString(),
//                                 quiteItem.Ft.OwnCost.ToString(),
//                                 quiteItem.InvoiceNO,
//                                 quiteItem.AccountFlag,
//                                 quiteItem.QutieOper,
//                                 quiteItem.QutieDate.ToString(),
//                                 quiteItem.BalanceNO,
//                                 quiteItem.BalanceOpcd,
//                                 quiteItem.BalanceDate.ToString()
//                             };

//            return strParm;

//        }

//        #endregion


        #region 按病历号及划价时间查询非药品的划价数量

        /// <summary>
        /// 按病历号及划价时间查询非药品的划价数量
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="operDate"></param>
        /// <returns></returns>
        public int QueryUndrugByCardAndOperDate(string cardNO, DateTime operDate)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Item.GetUndrgByCardNOAndOper", ref sql) == -1)
            {
                this.Err = "查找索引为Fee.Item.GetUndrgByCardNOAndOper的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, cardNO, operDate.ToString());
            return NConvert.ToInt32(this.ExecSqlReturnOne(sql));
        }

        #endregion
    }
}
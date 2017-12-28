using System;
using System.Data;
using Neusoft.HISFC.Models;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Fee.Inpatient;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.BizLogic.Fee
{
    /// <summary>
    /// 费用管理类-住院 
    /// <br>1、	AddPatientAccount(BAR/ACK)</br>
    ///	<br>2、	PurgePatientAccount(BAR/ACK)</br>
    ///	<br><strike>3、	PostDetailFinancialTransactions(DFT)</strike></br>
    ///	<br>4、	UpdateAccount(BAR/ACK)</br>
    ///	<br>5、	EndAccount(BAR/ACK)</br>
    /// </summary>
    public class InPatient : Neusoft.FrameWork.Management.Database
    {

        #region 私有方法

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
            if (this.Sql.GetSql(sqlIndex, ref sql) == -1)
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

        #region 预交金

        /// <summary>
        /// 获得预交金属性字符串数组
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 预交金属性字符串数组 失败: null</returns>
        private string[] GetPrepayParams(Prepay prepay)
        {
            return this.GetPrepayParams(prepay.Patient, prepay);
        }

        /// <summary>
        /// 获得预交金属性字符串数组
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 预交金属性字符串数组 失败: null</returns>
        private string[] GetPrepayParams(PatientInfo patient, Prepay prepay)
        {
            string[] args ={
							   //住院流水号
							   patient.ID,
							   //发生序号
							   prepay.ID,
							   //患者姓名
							   patient.Name,
							   //预交金额
							   prepay.FT.PrepayCost.ToString(),
							   //交付方式
							   prepay.PayType.ID.ToString(),
							   // 科室代码
							   patient.PVisit.PatientLocation.Dept.ID,
							   //预交金收据号码
							   prepay.RecipeNO,
							   //结算时间
							   prepay.BalanceOper.OperTime.ToString(),
							   //结算标志 0:未结算；1:已结算
							   prepay.BalanceState,
							   //预交金状态0:收取；1:作废;2:补打3:召回
							   prepay.PrepayState,
							   //开户银行
							   prepay.Bank.Name,
							   //开户帐户
							   prepay.Bank.Account,
							   //结算发票号
							   prepay.Invoice.ID,
							   //结算序号
							   prepay.BalanceNO.ToString(),
							   //结算人代码
							   prepay.BalanceOper.ID,
							   //上缴标志（1是 0否）
							   System.Convert.ToInt16(prepay.IsTurnIn).ToString(),
							   //财务组代码
							   prepay.FinGroup.ID,
							   //工作单位
							   prepay.Bank.WorkName,
							   //0非转押金，1转押金2转押金已打印
							   prepay.TransferPrepayState,
							   //转押金结算员
							   prepay.TransPrepayOper.ID,
							   //转押金时间
							   prepay.TransferPrepayTime.ToString(),
							   //交易流水号或支票号或汇票号
							   prepay.Bank.InvoiceNO,
							   //操作员
							   prepay.PrepayOper.ID,
							   //操作日期
							   prepay.PrepayOper.OperTime.ToString(),
							   //财务审核序号
							   prepay.AuditingNO,
							   //转押金时结算序号
							   prepay.TransferPrepayBalanceNO.ToString(),
							   //原发票号码
							   prepay.OrgInvoice.ID,
							   //操作员科室
							   prepay.PrepayOper.Dept.ID,
                               //预交来源 1 正常收退 2 结算召回
                               prepay.PrepaySourceState
						   };

            return args;
        }

        /// <summary>
        /// 获取检索fin_ipb_inprepay的全部数据的sql
        /// </summary>
        /// <returns>成功: 返回SQL语句 失败 null</returns>
        private string GetSqlForSelectAllPrepay()
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql("Fee.Inpatient.Prepay.Get.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.Inpatient.Prepay.Get.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 通过Where条件查询预交金信息
        /// </summary>
        /// <param name="whereIndex">Where条件</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回预交金实体集合 失败 null</returns>
        private ArrayList QueryPrepays(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectAllPrepay();

            return this.QueryPrepaysBySql(sql + " " + where, args);
        }

        /// <summary>
        /// 根据SQL查询预交金
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:返回预交金实体集合 失败 null</returns>
        private ArrayList QueryPrepaysBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList prepays = new ArrayList();//预交金集合
            Prepay prepay = null;//预交金实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    prepay = new Prepay();

                    prepay.ID = this.Reader[0].ToString(); //0发生序号
                    prepay.Name = this.Reader[1].ToString();//1姓名
                    prepay.FT.PrepayCost = NConvert.ToDecimal(this.Reader[2].ToString());//2预交金额
                    prepay.PayType.ID = this.Reader[3].ToString();//3交付方式
                    prepay.Dept.ID = this.Reader[4].ToString();//4科室代码
                    prepay.Patient.PVisit.PatientLocation.Dept.ID = this.Reader[4].ToString();//4科室代码
                    prepay.RecipeNO = this.Reader[5].ToString();//5预交金收据号码
                    prepay.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[6].ToString());//6结算时间
                    prepay.BalanceState = this.Reader[7].ToString();//7结算标志	0:未结算；1:已结算
                    prepay.PrepayState = this.Reader[8].ToString();//8预交金状态0:收取；1:作废;2:补打 3：召回
                    prepay.Bank.Name = this.Reader[9].ToString();//9开户银行
                    prepay.Bank.Account = this.Reader[10].ToString();//10开户帐户
                    prepay.Invoice.ID = this.Reader[11].ToString();//11结算发票号
                    prepay.BalanceNO = NConvert.ToInt32(this.Reader[12].ToString());//12结算序号
                    prepay.BalanceOper.ID = this.Reader[13].ToString();//13结算人代码
                    prepay.IsTurnIn = NConvert.ToBoolean(this.Reader[14].ToString());//14上缴标志（1是 0否）
                    prepay.FinGroup.ID = this.Reader[15].ToString();//15财务组代码
                    prepay.Bank.WorkName = this.Reader[16].ToString();//16工作单位
                    prepay.TransferPrepayState = this.Reader[17].ToString();//17 0非转押金，1转押金，2转押金已打印
                    prepay.TransPrepayOper.ID = this.Reader[18].ToString();//18转押金结算员
                    prepay.TransferPrepayTime = NConvert.ToDateTime(this.Reader[19].ToString());//19转押金时间
                    prepay.Bank.InvoiceNO = this.Reader[20].ToString();//20pos交易流水号或支票号或汇票号
                    prepay.PrepayOper.ID = this.Reader[21].ToString();//21操作员	
                    prepay.PrepayOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString());//22操作日期
                    prepay.AuditingNO = this.Reader[23].ToString();//23财务审核序号
                    prepay.TransferPrepayBalanceNO = NConvert.ToInt32(this.Reader[24].ToString());//24转押金时结算序号
                    prepay.OrgInvoice.ID = this.Reader[25].ToString();//25原始发票号
                    prepay.PrepayOper.Dept.ID = this.Reader[26].ToString();//26操作员所在科室
                    prepay.PayType.Name = this.Reader[27].ToString();//支付方式名称
                    //{9B8D83F8-CB0F-48fb-8ECD-0BA4462A952A}
                    prepay.Memo = this.Reader[28].ToString(); //日结标记
                    prepays.Add(prepay);
                }//循环结束

                this.Reader.Close();

                return prepays;
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

        #endregion

        #region 插入费用明细

        /// <summary>
        /// 通过非药品实体获得实体属性数组
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="feeItemList">非药品费用基本信息</param>
        /// <returns>非药品实体获得实体属性数组</returns>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        private string[] GetFeeItemListParams(PatientInfo patient, FeeItemList feeItemList)
        {
            feeItemList.Patient = patient.Clone();

            string[] args = 
				{
					feeItemList.RecipeNO,//0 处方号
					feeItemList.SequenceNO.ToString(),//处方内流水号
					feeItemList.Item.MinFee.ID,//1最小费用代码
					((int)feeItemList.TransType).ToString(),//2 交易类型,1正交易，2反交易
					feeItemList.Patient.ID,//3住院流水号
					feeItemList.Patient.Name,//4姓名
					feeItemList.Patient.Pact.PayKind.ID,//5结算类别
					feeItemList.Patient.Pact.ID,//6合同单位
					((PatientInfo)feeItemList.Patient).PVisit.PatientLocation.Dept.ID,// 7在院科室代码
					((PatientInfo)feeItemList.Patient).PVisit.PatientLocation.NurseCell.ID,//8护士站代码
					feeItemList.RecipeOper.Dept.ID,//9开立科室代码
					feeItemList.ExecOper.Dept.ID,//10执行科室代码
					feeItemList.StockOper.Dept.ID,//11扣库科室代码
					feeItemList.RecipeOper.ID,//12开立医师代码
					feeItemList.Item.ID,//13项目代码
					feeItemList.Compare.CenterItem.ID,//14中心代码
                    feeItemList.Item.Name,
					feeItemList.Item.Price.ToString(),//15单价
					feeItemList.Item.Qty.ToString(),//16数量
					feeItemList.UndrugComb.ID,//17组套代码
					feeItemList.UndrugComb.Name,//18组套名称
					feeItemList.FT.TotCost.ToString(),//19费用金额
					feeItemList.FT.OwnCost.ToString(),//20自费金额
					feeItemList.FT.PayCost.ToString(),//21自付金额
					feeItemList.FT.PubCost.ToString(),//22公费金额
					feeItemList.FT.RebateCost.ToString(),//23优惠金额
					((int)feeItemList.PayType).ToString(),//25发放状态
					NConvert.ToInt32(feeItemList.IsBaby).ToString(),//26是否婴儿用
					NConvert.ToInt32(feeItemList.IsEmergency).ToString(),//27急诊抢救标志
					((Neusoft.HISFC.Models.Order.Inpatient.Order)feeItemList.Order).OrderType.ID,//28出院带疗标记
					feeItemList.Invoice.ID,//29结算发票号
					feeItemList.BalanceNO.ToString(),//30结算序号
					feeItemList.AuditingNO,//31审批号
					feeItemList.ChargeOper.ID,//32划价人
					feeItemList.ChargeOper.OperTime.ToString(),//33划价日期
					feeItemList.MachineNO,//34设备号
					feeItemList.FeeOper.ID,//35计费人
					feeItemList.FeeOper.OperTime.ToString(),//36计费日期
					feeItemList.AuditingNO,//37审批序号
					feeItemList.Order.ID,//39医嘱流水号
					feeItemList.ExecOrder.ID,//40医嘱执行单流水号
					feeItemList.ExecOper.ID,//43执行人
					feeItemList.ExecOper.OperTime.ToString(),//44执行日期
					feeItemList.Item.PriceUnit,//当前单位
					feeItemList.SendSequence.ToString(),// 出库单序列号
					feeItemList.UpdateSequence.ToString(),//扣库流水号	
					feeItemList.NoBackQty.ToString(),//46可退数量
					feeItemList.BalanceState,//47结算状态
					feeItemList.FTRate.ItemRate.ToString(),//48收费比例
					feeItemList.FeeOper.Dept.ID,//49 收费员科室
					feeItemList.Item.SpecialFlag,		//50 扩展标记
					feeItemList.Item.SpecialFlag1,		//51 扩展标记1
					feeItemList.Item.SpecialFlag2,		//52 扩展标记2
					//feeItemList.User01,//53 扩展编码
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    feeItemList.ExtCode,
					feeItemList.User02,//54 扩展操作员编码
					feeItemList.User03, //55 扩展日期
                    ((int)feeItemList.Item.ItemType).ToString() ,//0非药品　2物资
                    //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
                    feeItemList.MedicalTeam.ID,
                    // 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
                    feeItemList.OperationNO,
                    feeItemList.CancelRecipeNO //{9C9F3289-C6E9-4c52-9077-FBF8ABDB4DE5}
                   
				};

            return args;
        }

        /// <summary>
        /// 通过药品实体获得实体属性数组
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="medItemList">药品费用基本信息</param>
        /// <returns>药品实体获得实体属性数组</returns>
        private string[] GetMedItemListParams(PatientInfo patient, FeeItemList medItemList)
        {
            medItemList.Patient = patient.Clone();

            string[] args = 
				{
					medItemList.RecipeNO,
					medItemList.SequenceNO.ToString(),
					((int)medItemList.TransType).ToString(),
					medItemList.Patient.ID,
					medItemList.Patient.Name,
					medItemList.Patient.Pact.PayKind.ID,
					medItemList.Patient.Pact.ID,
					((Neusoft.HISFC.Models.RADT.PatientInfo)medItemList.Patient).PVisit.PatientLocation.Dept.ID,
					((Neusoft.HISFC.Models.RADT.PatientInfo)medItemList.Patient).PVisit.PatientLocation.NurseCell.ID,
					medItemList.RecipeOper.Dept.ID,
					medItemList.ExecOper.Dept.ID,
					medItemList.StockOper.Dept.ID,
					medItemList.RecipeOper.ID,
					medItemList.Item.ID,
					medItemList.Item.MinFee.ID,
					medItemList.Compare.CenterItem.ID,
					medItemList.Item.Name,
					medItemList.Item.Specs,
					((Neusoft.HISFC.Models.Pharmacy.Item)medItemList.Item).Type.ID,
					((Neusoft.HISFC.Models.Pharmacy.Item)medItemList.Item).Quality.ID,
					NConvert.ToInt32(((Neusoft.HISFC.Models.Pharmacy.Item)medItemList.Item).Product.IsSelfMade).ToString(),
					medItemList.Item.Price.ToString(),
					medItemList.Item.PriceUnit,
					medItemList.Item.PackQty.ToString(),
					medItemList.Item.Qty.ToString(),
					medItemList.Days.ToString(),
					medItemList.FT.TotCost.ToString(),
					medItemList.FT.OwnCost.ToString(),
					medItemList.FT.PayCost.ToString(),
					medItemList.FT.PubCost.ToString(),
					medItemList.FT.RebateCost.ToString(),
                    ((int)medItemList.PayType).ToString(),
                    NConvert.ToInt32(medItemList.IsBaby).ToString(),
                    NConvert.ToInt32(medItemList.IsEmergency).ToString(),
                    ((Models.Order.Inpatient.Order)medItemList.Order).OrderType.ID,
					medItemList.Invoice.ID,
					medItemList.BalanceNO.ToString(),
					medItemList.ApproveNO,
					medItemList.ChargeOper.ID,
					medItemList.ChargeOper.OperTime.ToString(),
					medItemList.ExecOper.ID,
					medItemList.ExecOper.OperTime.ToString(),
					medItemList.AuditingNO,
					medItemList.Order.ID,
					medItemList.ExecOrder.ID,
					medItemList.FeeOper.ID,
                    medItemList.FeeOper.OperTime.ToString(),
                    medItemList.SendSequence.ToString(),
                    medItemList.UpdateSequence.ToString(),
					medItemList.NoBackQty.ToString(),
					medItemList.BalanceState,
					medItemList.FTRate.OwnRate.ToString(),	
					medItemList.FeeOper.Dept.ID,		
					medItemList.Item.SpecialFlag,	
					medItemList.Item.SpecialFlag1,
					medItemList.Item.SpecialFlag2,
                    medItemList.ExtCode,
                    medItemList.ExtOper.ID,
                    medItemList.ExtOper.OperTime.ToString(),
                      //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
                    medItemList.MedicalTeam.ID,
                    //{0604764A-3F55-428f-9064-FB4C53FD8136}
                    medItemList.OperationNO,
                    medItemList.CancelRecipeNO  //{9C9F3289-C6E9-4c52-9077-FBF8ABDB4DE5}
				};

            return args;
        }

        /// <summary>
        /// 获得更新划价信息属性字段集合
        /// </summary>
        /// <param name="feeItemList">费用信息</param>
        /// <returns>更新划价信息属性字段集合</returns>
        private string[] GetUpdateChargeItemParams(FeeItemList feeItemList)
        {
            string[] args = 
				{
					feeItemList.RecipeNO,
					feeItemList.SequenceNO.ToString(),
					feeItemList.Item.Qty.ToString(),
					feeItemList.FT.TotCost.ToString(),
					feeItemList.FT.OwnCost.ToString(),
					feeItemList.FT.PayCost.ToString(),
					feeItemList.FT.PubCost.ToString(),
					feeItemList.ChargeOper.ID,
					feeItemList.ChargeOper.OperTime.ToString()
				};

            return args;
        }

        /// <summary>
        /// 获得更新划价后收费信息属性字段集合
        /// </summary>
        /// <param name="feeItemList">费用信息</param>
        /// <returns>更新划价后收费信息属性字段集合</returns>
        private string[] GetUpdateChargeItemToFeeParmas(FeeItemList feeItemList)
        {
            string[] args = 
				{
					feeItemList.RecipeNO,
					feeItemList.SequenceNO.ToString(),
					feeItemList.FeeOper.ID,
					feeItemList.FeeOper.OperTime.ToString(),
					((int)feeItemList.PayType).ToString(),
					feeItemList.FeeOper.Dept.ID	
				};

            return args;
        }

        /// <summary>
        /// FeeItemList实体转换成FeeInfo实体
        /// </summary>
        /// <param name="feeItemList">明细实体</param>
        /// <returns>成功 FeeInfo实体 失败: -1</returns>
        private FeeInfo ConvertFeeItemListToFeeInfo(FeeItemList feeItemList) 
        {
            FeeInfo feeInfo = new FeeInfo();
            
            feeInfo.RecipeNO = feeItemList.RecipeNO;
			feeInfo.Item = feeItemList.Item;
            feeInfo.TransType = feeItemList.TransType;
			feeInfo.Patient = feeItemList.Patient;
			feeInfo.RecipeOper = feeItemList.RecipeOper;
			feeInfo.ExecOper = feeItemList.ExecOper;
		    feeInfo.StockOper = feeItemList.StockOper;
			feeInfo.FT = feeItemList.FT;
			feeInfo.ChargeOper = feeItemList.ChargeOper;
			feeInfo.FeeOper = feeItemList.FeeOper;
			feeInfo.BalanceOper = feeItemList.BalanceOper;
			feeInfo.Invoice = feeItemList.Invoice;
            feeInfo.BalanceNO = feeItemList.BalanceNO;
			feeInfo.BalanceState = feeItemList.BalanceState;
			feeInfo.AuditingNO = feeItemList.AuditingNO;
			feeInfo.IsBaby = feeItemList.IsBaby;

            return feeInfo;
        }

        /// <summary>
        /// 获得费用汇总信息实体字段数组
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeInfo">费用汇总信息实体</param>
        /// <returns>用汇总信息实体字段数组</returns>
        private string[] GetFeeInfoParams(PatientInfo patient, FeeInfo feeInfo)
        {
            feeInfo.Patient = patient.Clone();

            if (feeInfo.FeeOper.Dept.ID == null || feeInfo.FeeOper.Dept.ID == string.Empty)
            {
                feeInfo.FeeOper.Dept.ID = this.GetDeptByEmplId(feeInfo.FeeOper.ID);
            }

            string[] args = 
				{
					feeInfo.RecipeNO,
					feeInfo.Item.MinFee.ID,
					((int)feeInfo.TransType).ToString(),
					feeInfo.Patient.ID,
					feeInfo.Patient.Name,
					feeInfo.Patient.Pact.PayKind.ID,
					feeInfo.Patient.Pact.ID,
					((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.Dept.ID,
					((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.NurseCell.ID,
					feeInfo.RecipeOper.Dept.ID,
					feeInfo.ExecOper.Dept.ID,
					feeInfo.StockOper.Dept.ID,
					feeInfo.RecipeOper.ID,
					feeInfo.FT.TotCost.ToString(),
					feeInfo.FT.OwnCost.ToString(),
					feeInfo.FT.PayCost.ToString(),
					feeInfo.FT.PubCost.ToString(),
					feeInfo.FT.RebateCost.ToString(),
					feeInfo.ChargeOper.ID,
					feeInfo.ChargeOper.OperTime.ToString(),
					feeInfo.FeeOper.ID,
					feeInfo.FeeOper.OperTime.ToString(),
					feeInfo.BalanceOper.ID,
					feeInfo.BalanceOper.OperTime.ToString(),
					feeInfo.Invoice.ID,
					feeInfo.BalanceNO.ToString(),
					feeInfo.BalanceState,
					feeInfo.AuditingNO,
					NConvert.ToInt32(feeInfo.IsBaby).ToString(),
					feeInfo.FeeOper.Dept.ID,	//操作员科室
					feeInfo.ExtFlag,			//扩展标记
					feeInfo.ExtFlag1,			//扩展标记1
					feeInfo.ExtFlag2,			//扩展标记2
					feeInfo.ExtCode,			//扩展编码
					feeInfo.ExecOper.ID,		//扩展操作人员
					feeInfo.ExecOper.OperTime.ToString()	
				};

            return args;
        }

        /// <summary>
        /// 获得费用汇总信息实体字段数组(更新用)
        /// </summary>
        /// <param name="feeInfo">费用汇总信息实体</param>
        /// <returns>费用汇总信息实体字段数组</returns>
        private string[] GetFeeInfoUpdateParams(FeeInfo feeInfo)
        {
            string[] args = 
				{
					feeInfo.FT.TotCost.ToString(),
					feeInfo.FT.OwnCost.ToString(),
					feeInfo.FT.PayCost.ToString(),
					feeInfo.FT.PubCost.ToString(),
					feeInfo.RecipeNO,
					feeInfo.Item.MinFee.ID,
					feeInfo.ExecOper.Dept.ID,
					feeInfo.FT.RebateCost.ToString()
				};

            return args;
        }

        #endregion

        #region 插入结算信息

        /// <summary>
        /// 获得结算明细信息属性数组
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="balanceList">患者结算明细信息</param>
        /// <returns>结算明细信息属性数组</returns>
        private string[] GetBalanceListParams(PatientInfo patient, BalanceList balanceList)
        {
            ((Balance)balanceList.BalanceBase).Patient = patient.Clone();

            if (((Balance)balanceList.BalanceBase).BalanceOper.Dept.ID == null || ((Balance)balanceList.BalanceBase).BalanceOper.Dept.ID == string.Empty)
            {
                ((Balance)balanceList.BalanceBase).BalanceOper.Dept.ID = this.GetDeptByEmplId(((Balance)balanceList.BalanceBase).BalanceOper.ID);
            }

            string[] args = 
				{
					((Balance)balanceList.BalanceBase).Invoice.ID,
					((int)((Balance)balanceList.BalanceBase).TransType).ToString(),
					((Balance)balanceList.BalanceBase).Patient.ID,
					((Balance)balanceList.BalanceBase).Patient.Name,
					((Balance)balanceList.BalanceBase).Patient.Pact.PayKind.ID,
					((Balance)balanceList.BalanceBase).Patient.Pact.ID,
					((PatientInfo)((Balance)balanceList.BalanceBase).Patient).PVisit.PatientLocation.Dept.ID,
					balanceList.FeeCodeStat.StatCate.ID,
					balanceList.FeeCodeStat.StatCate.Name,
					balanceList.FeeCodeStat.SortID.ToString(),
					((Balance)balanceList.BalanceBase).FT.TotCost.ToString(),
					((Balance)balanceList.BalanceBase).FT.OwnCost.ToString(),
					((Balance)balanceList.BalanceBase).FT.PayCost.ToString(),
					((Balance)balanceList.BalanceBase).FT.PubCost.ToString(),
					((Balance)balanceList.BalanceBase).FT.RebateCost.ToString(),
					((Balance)balanceList.BalanceBase).FT.OwnCost.ToString(),
					((Balance)balanceList.BalanceBase).BalanceOper.ID,
					((Balance)balanceList.BalanceBase).BalanceOper.OperTime.ToString(),
					((Balance)balanceList.BalanceBase).BalanceType.ID.ToString(),
					((Balance)balanceList.BalanceBase).ID,
					NConvert.ToInt32(((Balance)balanceList.BalanceBase).Patient.IsBaby).ToString(),
					((Balance)balanceList.BalanceBase).AuditingNO,
					((Balance)balanceList.BalanceBase).BalanceOper.Dept.ID
				};

            return args;
        }

        /// <summary>
        /// 获得结算信息属性数组
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="balance">患者结算信息</param>
        /// <returns>结算信息属性数组</returns>
        private string[] GetBalanceParams(PatientInfo patient, Balance balance)
        {
            balance.Patient = patient.Clone();

            if (balance.BalanceOper.Dept.ID == null || balance.BalanceOper.Dept.ID == string.Empty)
            {
                balance.BalanceOper.Dept.ID = this.GetDeptByEmplId(balance.BalanceOper.ID);
            }

            string[] args = 
				{
					balance.Invoice.ID,
					((int)balance.TransType).ToString(),
					balance.Patient.ID,
					balance.ID,
					balance.Patient.Pact.PayKind.ID,
					balance.Patient.Pact.ID,
					balance.FT.PrepayCost.ToString(),
					balance.FT.TotCost.ToString(),
					balance.FT.OwnCost.ToString(),
					balance.FT.PayCost.ToString(),
					balance.FT.PubCost.ToString(),
					balance.FT.RebateCost.ToString(),
					balance.FT.DerateCost.ToString(),
					((int)balance.CancelType).ToString(),
					balance.FT.SupplyCost.ToString(),
					balance.FT.ReturnCost.ToString(),
					balance.FT.TransferPrepayCost.ToString(),
					balance.BeginTime.ToString(),
					balance.EndTime.ToString(),
					balance.BalanceType.ID.ToString(),
					balance.BalanceOper.ID,
					balance.BalanceOper.OperTime.ToString(),
					balance.FinanceGroup.ID,
					balance.PrintTimes.ToString(),
					"0",
					"0",
					"0",
					"0",
					"0",
					balance.AuditingNO,
					NConvert.ToInt32(balance.IsMainInvoice).ToString(),
					NConvert.ToInt32(balance.IsLastBalance).ToString(),
					balance.Patient.Name,
					balance.BalanceOper.Dept.ID,
					balance.FT.AdjustOvertopCost.ToString()
				};

            return args;
        }

        #endregion

        #region 插入支付信息

        /// <summary>
        /// 获得支付信息属性数组
        /// </summary>
        /// <param name="balancePay">支付实体</param>
        /// <returns>支付信息属性数组</returns>
        private string[] GetBalancePayParams(BalancePay balancePay)
        {
            string[] args = 
				{
					balancePay.Invoice.ID,
					((int)balancePay.TransType).ToString(),
					balancePay.TransKind.ID,
					balancePay.PayType.ID.ToString(),
					balancePay.FT.TotCost.ToString(),
					balancePay.Qty.ToString(),
					balancePay.Bank.ID,
					balancePay.Bank.Name,
					balancePay.Bank.Account,
					balancePay.BalanceNO.ToString(),
					balancePay.RetrunOrSupplyFlag,
					balancePay.BalanceOper.ID,
					balancePay.BalanceOper.OperTime.ToString()
				};

            return args;
        }

        #endregion

        #region 插入担保信息

        /// <summary>
        /// 获得担保信息属性数组
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <returns>担保信息属性数组</returns>
        private string[] GetPatientSurtyParmas(PatientInfo patient)
        {
            string[] args =
				{
                  patient.ID,//住院流水号
                  patient.PVisit.PatientLocation.Dept.ID,//科室代码
                  patient.Surety.SuretyPerson.ID,//担保人编码
                  patient.Surety.SuretyPerson.Name,//担保人姓名
                  patient.Surety.SuretyCost.ToString(),//担保金额
                  patient.Surety.SuretyType.ID.ToString(),//担保类型
                  patient.Surety.ApplyPerson.ID,//审核人编码
                  patient.Surety.ApplyPerson.Name,//审核人姓名
                  patient.Surety.Mark,//备注
                  patient.Surety.Oper.ID,//操作员
                  //{43B68F1F-988A-44ff-9C95-2EDCB7ACC5A9}
                  patient.Surety.PayType.ID,
                  patient.Surety.State,
                  patient.Surety.Bank.ID,
                  patient.Surety.Bank.Account,
                  patient.Surety.Bank.WorkName,
                  patient.Surety.Bank.InvoiceNO,
                  patient.Surety.InvoiceNO,
                  patient.Surety.OldInvoiceNO

				};
            return args;
        }

        #endregion

        #region 插入结转信息

        /// <summary>
        /// 获得结转属性集合
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="feeInfo">费用汇总实体</param>
        /// <returns>结转属性集合</returns>
        private string[] GetCarryFowardFeeParams(PatientInfo patient, FeeInfo feeInfo)
        {
            feeInfo.Patient = patient.Clone();

            string[] args = 
				{
					feeInfo.RecipeNO,
					feeInfo.Item.MinFee.ID,
					((int)feeInfo.TransType).ToString(),
					feeInfo.Patient.ID,
					feeInfo.Patient.Name,
					feeInfo.Patient.Pact.PayKind.ID,
					feeInfo.Patient.Pact.ID,
					((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.Dept.ID,
					((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.NurseCell.ID,
					feeInfo.StockOper.Dept.ID,
					feeInfo.ExecOper.Dept.ID,
					feeInfo.StockOper.Dept.ID,
					feeInfo.RecipeOper.ID,
					feeInfo.FT.TotCost.ToString(),
					feeInfo.ChargeOper.ID,
					feeInfo.ChargeOper.OperTime.ToString(),
					feeInfo.FeeOper.ID,
					feeInfo.FeeOper.OperTime.ToString(),
					feeInfo.BalanceOper.ID,
					feeInfo.BalanceOper.OperTime.ToString(),
					feeInfo.BalanceNO.ToString(),
					feeInfo.BalanceState,
					feeInfo.AuditingNO,
					NConvert.ToInt32(feeInfo.IsBaby).ToString()
				};

            return args;
        }

        #endregion

        #region 费用查询

        /// <summary>
        /// 获得费用组信息
        /// </summary>
        /// <param name="index">SQL索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得费用组信息 失败:null</returns>
        private ArrayList QueryFeeInfoGroups(string index, params string[] args)
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql(index, ref sql) == -1)
            {
                this.Err = "没有找到索引为: " + index + "的SQL语句";

                return null;
            }

            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList feeInfos = new ArrayList();//FeeInfo集合
            FeeInfo feeInfo = null;//费用实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    feeInfo = new FeeInfo();

                    feeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    feeInfo.FT.TotCost = NConvert.ToDecimal(this.Reader[1].ToString());
                    feeInfo.FT.OwnCost = NConvert.ToDecimal(this.Reader[2].ToString());
                    feeInfo.FT.PubCost = NConvert.ToDecimal(this.Reader[3].ToString());
                    feeInfo.FT.PayCost = NConvert.ToDecimal(this.Reader[4].ToString());
                    feeInfo.FT.RebateCost = NConvert.ToDecimal(this.Reader[5].ToString());

                    feeInfos.Add(feeInfo);
                }

                this.Reader.Close();

                return feeInfos;
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

        #endregion

        #region 明细查询

        /// <summary>
        /// 获取检索fin_com_itemlist的全部数据的sql
        /// </summary>
        /// <returns>成功:检索fin_com_itemlist的全部数据的sql 失败:null</returns>
        private string GetFeeItemsSelectSql()
        {
            string sql = string.Empty;//SQly语句

            if (this.Sql.GetSql("Fee.SelectAllFromFeeItem.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.SelectAllFromFeeItem.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得费用项目信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得费用项目信息 失败: null</returns>
        private ArrayList QueryFeeItemListsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList feeItemLists = new ArrayList();//费用明细信息集合
            FeeItemList itemList = null;//费用明细实体

            try
            {
                while (this.Reader.Read())
                {
                    itemList = new FeeItemList();

                    itemList.RecipeNO = this.Reader[0].ToString();//0 处方号
                    itemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());//1处方内项目流水号
                    itemList.TransType = (TransTypes)NConvert.ToInt32(Reader[2].ToString());//2交易类型,1正交易，2反交易
                    itemList.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Patient.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Pact.PayKind.ID = this.Reader[5].ToString();//5结算类别
                    itemList.Patient.Pact.ID = this.Reader[6].ToString();//6合同单位
                    itemList.UpdateSequence = NConvert.ToInt32(this.Reader[7].ToString());//7更新库存的流水号(物资)
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.Dept.ID = this.Reader[8].ToString();//8在院科室代码
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[9].ToString();//9护士站代码
                    itemList.RecipeOper.Dept.ID = this.Reader[10].ToString();//10开立科室代码
                    itemList.ExecOper.Dept.ID = this.Reader[11].ToString();//11执行科室代码
                    itemList.StockOper.Dept.ID = this.Reader[12].ToString();//12扣库科室代码
                    itemList.RecipeOper.ID = this.Reader[13].ToString();//13开立医师代码
                    itemList.Item.ID = this.Reader[14].ToString();//14项目代码
                    itemList.Item.MinFee.ID = this.Reader[15].ToString();//15最小费用代码
                    itemList.Compare.CenterItem.ID = this.Reader[16].ToString();//16中心代码
                    itemList.Item.Name = this.Reader[17].ToString();//17项目名称
                    itemList.Item.Price = NConvert.ToDecimal(this.Reader[18].ToString());//18单价
                    itemList.Item.Qty = NConvert.ToDecimal(this.Reader[19].ToString());//19数量
                    itemList.Item.PriceUnit = this.Reader[20].ToString();//20当前单位
                    itemList.UndrugComb.ID = this.Reader[21].ToString();//21组套代码
                    itemList.UndrugComb.Name = this.Reader[22].ToString();//22组套名称
                    itemList.FT.TotCost = NConvert.ToDecimal(this.Reader[23].ToString());//23费用金额
                    itemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[24].ToString());//24自费金额
                    itemList.FT.PayCost = NConvert.ToDecimal(this.Reader[25].ToString());//25自付金额
                    itemList.FT.PubCost = NConvert.ToDecimal(this.Reader[26].ToString());//26公费金额
                    itemList.FT.RebateCost = NConvert.ToDecimal(this.Reader[27].ToString());//27优惠金额
                    itemList.SendSequence = NConvert.ToInt32(this.Reader[28].ToString());//28出库单序列号
                    itemList.PayType = (PayTypes)NConvert.ToInt32(this.Reader[29].ToString());//29收费状态
                    itemList.IsBaby = NConvert.ToBoolean(this.Reader[30].ToString());//30是否婴儿用
                    ((Models.Order.Inpatient.Order)itemList.Order).OrderType.ID = this.Reader[32].ToString();
                    itemList.Invoice.ID = this.Reader[33].ToString();//33结算发票号
                    itemList.BalanceNO = NConvert.ToInt32(this.Reader[34].ToString());//34结算序号
                    itemList.ChargeOper.ID = this.Reader[36].ToString();//36划价人
                    itemList.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());//37划价日期
                    itemList.MachineNO = this.Reader[39].ToString();//39设备号
                    itemList.ExecOper.ID = this.Reader[40].ToString();//40执行人代码
                    itemList.ExecOper.OperTime = NConvert.ToDateTime(this.Reader[41].ToString());//41执行日期
                    itemList.FeeOper.ID = this.Reader[42].ToString();//42计费人
                    itemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[43].ToString());//43计费日期
                    itemList.AuditingNO = this.Reader[45].ToString();//45审核序号
                    itemList.Order.ID = this.Reader[46].ToString();//46医嘱流水号
                    itemList.ExecOrder.ID = this.Reader[47].ToString();//47医嘱执行单流水号
                    //itemList.Item.IsPharmacy = false;
                    //itemList.Item.ItemType = //HISFC.Models.Base.EnumItemType.UnDrug;
                    itemList.NoBackQty = NConvert.ToDecimal(this.Reader[48].ToString());//48可退数量
                    itemList.BalanceState = this.Reader[49].ToString();//49结算状态
                    itemList.FTRate.ItemRate = NConvert.ToDecimal(this.Reader[50].ToString());//50收费比例
                    itemList.FeeOper.Dept.ID = this.Reader[51].ToString();//51收费员科室
                    itemList.FTSource = this.Reader[54].ToString();
                    if (itemList.Item.PackQty == 0) 
                    {
                        itemList.Item.PackQty = 1;
                    }
                    itemList.Item.ItemType = (Neusoft.HISFC.Models.Base.EnumItemType)(NConvert.ToInt32(this.Reader[58]));
                    //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
                    itemList.MedicalTeam.ID = this.Reader[59].ToString();
                    // 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
                    itemList.OperationNO = this.Reader[60].ToString();
                    //读取退费处方号，处方内流水号{F7581BFE-6680-4e3f-90FA-3F07778E8821}
                    itemList.CancelRecipeNO = this.Reader[61].ToString();
                    itemList.CancelSequenceNO = NConvert.ToInt32(this.Reader[1].ToString());
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    itemList.ExtCode = this.Reader[55].ToString();
                    feeItemLists.Add(itemList);
                }

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
        /// 获得费用项目信息
        /// </summary>
        /// <param name="whereIndex">where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得费用项目信息 失败: null</returns>
        private ArrayList QueryFeeItemLists(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetFeeItemsSelectSql();

            return this.QueryFeeItemListsBySql(sql + " " + where, args);
        }

        /// <summary>
        /// 获取检索fin_com_medicinelist的全部数据的sql
        /// </summary>
        /// <returns>成功: 获取检索fin_com_medicinelist的全部数据的sql 失败:null</returns>
        public string GetMedItemListSelectSql()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.SelectAllFromMedItem.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.SelectAllFromMedItem.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得药品费用项目信息
        /// </summary>
        /// <param name="sql">SQl语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得药品费用项目信息 失败: null</returns>
        public ArrayList QueryMedItemListsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList medItemLists = new ArrayList();//药品明细集合
            FeeItemList itemList = null;//药品明细实体

            try
            {
                while (this.Reader.Read())
                {
                    itemList = new FeeItemList();

                    Neusoft.HISFC.Models.Pharmacy.Item pharmacyItem = new Neusoft.HISFC.Models.Pharmacy.Item();
                    itemList.Item = pharmacyItem;

                    itemList.RecipeNO = this.Reader[0].ToString();//0 处方号
                    itemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());//1处方内项目流水号
                    itemList.TransType = (TransTypes)NConvert.ToInt32(this.Reader[2].ToString());//2交易类型,1正交易，2反交易
                    itemList.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Patient.ID = this.Reader[3].ToString();//3住院流水号
                    itemList.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Name = this.Reader[4].ToString();//4姓名
                    itemList.Patient.Pact.PayKind.ID = this.Reader[5].ToString();//5结算类别
                    itemList.Patient.Pact.ID = this.Reader[6].ToString();//6合同单位
                    itemList.UpdateSequence = NConvert.ToInt32(this.Reader[7].ToString());//7更新库存的流水号(物资)
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.Dept.ID = this.Reader[8].ToString();//8在院科室代码
                    ((PatientInfo)itemList.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[9].ToString();//9护士站代码
                    itemList.RecipeOper.Dept.ID = this.Reader[10].ToString();//10开立科室代码
                    itemList.ExecOper.Dept.ID = this.Reader[11].ToString();//11执行科室代码
                    itemList.StockOper.Dept.ID = this.Reader[12].ToString();//12扣库科室代码
                    itemList.RecipeOper.ID = this.Reader[13].ToString();//13开立医师代码
                    itemList.Item.ID = this.Reader[14].ToString();//14项目代码
                    itemList.Item.MinFee.ID = this.Reader[15].ToString();//15最小费用代码
                    itemList.Compare.CenterItem.ID = this.Reader[14].ToString();//16中心代码
                    itemList.Item.Name = this.Reader[17].ToString();//17项目名称
                    itemList.Item.Price = NConvert.ToDecimal(this.Reader[18].ToString());//18单价1
                    itemList.Item.Qty = NConvert.ToDecimal(this.Reader[19].ToString());//9数量
                    itemList.Item.PriceUnit = this.Reader[20].ToString();//20当前单位
                    itemList.Item.PackQty = NConvert.ToDecimal(this.Reader[21].ToString());//21包装数量
                    itemList.Days = NConvert.ToDecimal(this.Reader[22].ToString());//22付数
                    itemList.FT.TotCost = NConvert.ToDecimal(this.Reader[23].ToString());//23费用金额
                    itemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[24].ToString());//24自费金额
                    itemList.FT.PayCost = NConvert.ToDecimal(this.Reader[25].ToString());//25自付金额
                    itemList.FT.PubCost = NConvert.ToDecimal(this.Reader[26].ToString());//26公费金额
                    itemList.FT.RebateCost = NConvert.ToDecimal(this.Reader[27].ToString());//27优惠金额
                    itemList.SendSequence = NConvert.ToInt32(this.Reader[28].ToString());//28出库单序列号
                    itemList.PayType = (PayTypes)NConvert.ToInt32(this.Reader[29].ToString());//29收费状态
                    itemList.IsBaby = NConvert.ToBoolean(this.Reader[30].ToString());//30是否婴儿用
                    ((Models.Order.Inpatient.Order)itemList.Order).OrderType.ID = this.Reader[32].ToString();//32出院带疗标记
                    itemList.Invoice.ID = this.Reader[33].ToString();//33结算发票号
                    itemList.BalanceNO = NConvert.ToInt32(this.Reader[34].ToString());//34结算序号
                    itemList.ChargeOper.ID = this.Reader[36].ToString();//36划价人
                    itemList.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[37].ToString());//37划价日期
                    pharmacyItem.Product.IsSelfMade = NConvert.ToBoolean(this.Reader[38].ToString());//38自制标识
                    pharmacyItem.Quality.ID = this.Reader[39].ToString();//39药品性质
                    itemList.ExecOper.ID = this.Reader[40].ToString();//40发药人代码
                    itemList.ExecOper.OperTime = NConvert.ToDateTime(this.Reader[41].ToString());//41发药日期
                    itemList.FeeOper.ID = this.Reader[42].ToString();//42计费人
                    itemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[43].ToString());//43计费日期
                    itemList.AuditingNO = this.Reader[45].ToString();//45审核序号
                    itemList.Order.ID = this.Reader[46].ToString();//46医嘱流水号
                    itemList.ExecOrder.ID = this.Reader[47].ToString();//47医嘱执行单流水号
                    pharmacyItem.Specs = this.Reader[48].ToString();//规格
                    pharmacyItem.Type.ID = this.Reader[49].ToString();//49药品类别
                    //pharmacyItem.IsPharmacy = true;
                    pharmacyItem.ItemType = HISFC.Models.Base.EnumItemType.Drug;
                    itemList.NoBackQty = NConvert.ToDecimal(this.Reader[50].ToString());//50可退数量
                    itemList.BalanceState = this.Reader[51].ToString();//51结算状态
                    itemList.FTRate.ItemRate = NConvert.ToDecimal(this.Reader[52].ToString());//52收费比例
                    itemList.FTRate.OwnRate = itemList.FTRate.ItemRate;

                    itemList.FeeOper.Dept.ID = this.Reader[53].ToString();//53收费员科室
                    //itemList.Item.IsPharmacy = true;
                    itemList.Item.ItemType = HISFC.Models.Base.EnumItemType.Drug;
                    itemList.FTSource = this.Reader[56].ToString();
                    //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
                    itemList.MedicalTeam.ID = this.Reader[57].ToString();
                    // 手术编码{0604764A-3F55-428f-9064-FB4C53FD8136}
                    itemList.OperationNO = this.Reader[58].ToString();
                    //读取退费处方号，处方内流水号{F7581BFE-6680-4e3f-90FA-3F07778E8821}
                    itemList.CancelRecipeNO = this.Reader[62].ToString();
                    itemList.CancelSequenceNO = NConvert.ToInt32(this.Reader[1].ToString());
                    //{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
                    itemList.ExtCode = this.Reader[57].ToString();

                    medItemLists.Add(itemList);
                }

                this.Reader.Close();

                return medItemLists;
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
        /// 获得药品费用项目信息
        /// </summary>
        /// <param name="whereIndex">where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得药品费用项目信息 失败: null</returns>
        private ArrayList QueryMedItemLists(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetMedItemListSelectSql();

            return this.QueryMedItemListsBySql(sql + " " + where, args);
        }

        /// <summary>
        /// 获取检索feeinfo的sql
        /// </summary>
        /// <returns>成功:检索SQL语句 失败:null</returns>
        private string GetSqlForSelectFeeInfo()
        {
            string sql = string.Empty;//Sql语句

            if (this.Sql.GetSql("GetSqlForSelectFeeInfo.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:GetSqlForSelectFeeInfo.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获取feeinfo中的各字段的值 注意顺序
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得费用汇总信息 失败:null</returns>
        private ArrayList QueryFeeInfosBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList feeInfos = new ArrayList();//费用汇总实体集合
            FeeInfo feeInfo = null;//费用汇总实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    feeInfo = new FeeInfo();

                    feeInfo.RecipeNO = this.Reader[0].ToString();//0处方号
                    feeInfo.Item.MinFee.ID = this.Reader[1].ToString();//1最小费用代码
                    feeInfo.TransType = (TransTypes)NConvert.ToInt32(Reader[2].ToString());//2交易类型
                    feeInfo.Patient.Pact.PayKind.ID = this.Reader[3].ToString();//3结算类别
                    feeInfo.Patient.Pact.ID = this.Reader[4].ToString();//4合同单位
                    ((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.Dept.ID = this.Reader[5].ToString();//5在院科室代码
                    ((PatientInfo)feeInfo.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[6].ToString();//6护士站代码
                    ((Neusoft.HISFC.Models.RADT.PatientInfo)feeInfo.Patient).PVisit.PatientLocation.NurseCell.ID = this.Reader[6].ToString();//6护士站代码
                    feeInfo.RecipeOper.Dept.ID = this.Reader[7].ToString();//7开立科室代码
                    feeInfo.ExecOper.Dept.ID = this.Reader[8].ToString();//8执行科室代码
                    feeInfo.StockOper.Dept.ID = this.Reader[9].ToString();//9扣库科室代码
                    feeInfo.RecipeOper.ID = this.Reader[10].ToString();//10开立医师代码
                    feeInfo.FT.TotCost = NConvert.ToDecimal(this.Reader[11].ToString());//11费用金额
                    feeInfo.FT.OwnCost = NConvert.ToDecimal(this.Reader[12].ToString());//12自费金额
                    feeInfo.FT.PayCost = NConvert.ToDecimal(this.Reader[13].ToString());//13自付金额
                    feeInfo.FT.PubCost = NConvert.ToDecimal(this.Reader[14].ToString());//14公费金额
                    feeInfo.FT.RebateCost = NConvert.ToDecimal(this.Reader[15].ToString());//15优惠金额
                    feeInfo.ChargeOper.ID = this.Reader[16].ToString();//16划价人
                    feeInfo.ChargeOper.OperTime = NConvert.ToDateTime(this.Reader[17].ToString());//17划价日期
                    feeInfo.FeeOper.ID = this.Reader[18].ToString();//18计费人
                    feeInfo.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[19].ToString());//19计费日期
                    feeInfo.BalanceOper.ID = this.Reader[20].ToString();//20结算人代码
                    feeInfo.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[21].ToString());//21结算时间
                    feeInfo.Invoice.ID = this.Reader[22].ToString();//22结算发票号
                    feeInfo.BalanceNO = NConvert.ToInt32(this.Reader[23].ToString());//23结算序号
                    feeInfo.BalanceState = this.Reader[24].ToString();//24结算标志
                    feeInfo.AuditingNO = this.Reader[25].ToString();//25审核序号
                    feeInfo.IsBaby = NConvert.ToBoolean(this.Reader[26].ToString());//26婴儿标记
                    feeInfo.FeeOper.Dept.ID = this.Reader[27].ToString();//27收费员科室
                    feeInfo.ExtFlag = this.Reader[28].ToString();//28扩展标记
                    feeInfo.ExtFlag1 = this.Reader[29].ToString();//扩展标记1
                    feeInfo.ExtFlag2 = this.Reader[30].ToString();//扩展标记2
                    feeInfo.ExtCode = this.Reader[31].ToString();//扩展编码
                    feeInfo.ExecOper.ID = this.Reader[32].ToString();//扩展操作员
                    feeInfo.ExecOper.OperTime = NConvert.ToDateTime(this.Reader[33].ToString());//扩展日期

                    feeInfos.Add(feeInfo);
                }//循环结束

                this.Reader.Close();

                return feeInfos;
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
        /// 获得费用汇总信息
        /// </summary>
        /// <param name="whereIndex">where条件索引</param>
        /// <param name="args">参数</param>
        /// <returns>成功: 获得费用汇总信息 失败: null</returns>
        private ArrayList QueryFeeInfos(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectFeeInfo();

            return this.QueryFeeInfosBySql(sql + " " + where, args);
        }

        #endregion

        #region 结算查询

        /// <summary>
        /// 获取检索fin_ipb_balanceHead的全部数据的sql
        /// </summary>
        /// <returns>成功:检索SQL语句 失败:null</returns>
        private string GetSqlForSelectAllInfoFromBalanceHead()
        {
            string sql = string.Empty;//SQL语句

            if (this.Sql.GetSql("Fee.GetSqlForSelectAllInfoFromBalanceHead.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetSqlForSelectAllInfoFromBalanceHead.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得结算信息
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:结算头表信息 失败:null 没有查找到数据ArrayList.Count = 0</returns>
        private ArrayList QueryBalancesBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList balances = new ArrayList();//结算头实体集合
            Balance balance = null;//结算头实体

            try
            {
                //开始循环读取数据
                while (this.Reader.Read())
                {
                    balance = new Balance();

                    balance.Invoice.ID = this.Reader[0].ToString();//0发票号码
                    balance.TransType = (TransTypes)NConvert.ToInt32(Reader[1].ToString());//1交易类型
                    balance.Patient.ID = this.Reader[2].ToString();//2住院流水号
                    balance.ID = this.Reader[3].ToString();//3结算序号
                    balance.Patient.Pact.PayKind.ID = this.Reader[4].ToString();//4结算类别
                    balance.Patient.Pact.ID = this.Reader[5].ToString();//5合同代码
                    balance.FT.PrepayCost = NConvert.ToDecimal(this.Reader[6].ToString());//6预交金额
                    balance.FT.TransferPrepayCost = NConvert.ToDecimal(this.Reader[7].ToString());//7转入预交金额
                    balance.FT.TotCost = NConvert.ToDecimal(this.Reader[8].ToString());//8费用金额
                    balance.FT.OwnCost = NConvert.ToDecimal(this.Reader[9].ToString());//9自费金额
                    balance.FT.PayCost = NConvert.ToDecimal(this.Reader[10].ToString());//10自付金额
                    balance.FT.PubCost = NConvert.ToDecimal(this.Reader[11].ToString());//11公费金额
                    balance.FT.RebateCost = NConvert.ToDecimal(this.Reader[12].ToString());//12优惠金额
                    balance.FT.DerateCost = NConvert.ToDecimal(this.Reader[13].ToString());//13减免金额
                    balance.FT.TransferTotCost = NConvert.ToDecimal(this.Reader[14].ToString());//14转入费用金额
                    balance.FT.SupplyCost = NConvert.ToDecimal(this.Reader[15].ToString());//15补收金额
                    balance.FT.ReturnCost = NConvert.ToDecimal(this.Reader[16].ToString());//16返还金额
                    balance.FT.TransferPrepayCost = NConvert.ToDecimal(this.Reader[17].ToString());//17转押金
                    balance.BeginTime = NConvert.ToDateTime(this.Reader[18].ToString());//18起始日期
                    balance.EndTime = NConvert.ToDateTime(this.Reader[19].ToString());//19终止日期
                    balance.BalanceType.ID = this.Reader[20].ToString();//20结算类型
                    balance.BalanceOper.ID = this.Reader[21].ToString();//21结算人代码
                    balance.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[22].ToString());//22结算时间
                    balance.FinanceGroup.ID = this.Reader[23].ToString();//23财务组代码
                    balance.PrintTimes = NConvert.ToInt32(this.Reader[24].ToString());//24打印次数
                    balance.AuditingNO = this.Reader[25].ToString();//25审核序号
                    balance.CancelType = (CancelTypes)NConvert.ToInt32(Reader[26].ToString());//26作废标志
                    balance.IsMainInvoice = NConvert.ToBoolean(this.Reader[27].ToString());//27主发票标记
                    balance.IsLastBalance = NConvert.ToBoolean(this.Reader[28].ToString());//28生育保险最后结算标记
                    balance.Name = this.Reader[29].ToString();//29 患者姓名
                    balance.Patient.Name = this.Reader[29].ToString();//29 患者姓名
                    balance.BalanceOper.Dept.ID = this.Reader[30].ToString();//30结算员科室
                    balance.FT.AdjustOvertopCost = NConvert.ToDecimal(this.Reader[31].ToString());//31结算调整公费日限额超标金额
                    balance.CancelOper.ID = this.Reader[32].ToString();//32作废操作员
                    balance.CancelOper.OperTime = NConvert.ToDateTime(this.Reader[33].ToString());//33作废时间

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
        /// 获得结算信息
        /// </summary>
        /// <param name="whereIndex">Where条件</param>
        /// <param name="args">参数</param>
        /// <returns>成功:结算头表信息 失败:null 没有查找到数据ArrayList.Count = 0</returns>
        private ArrayList QueryBalances(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectAllInfoFromBalanceHead();

            return this.QueryBalancesBySql(sql + " " + where, args);
        }

        /// <summary>
        /// 获取检索fin_ipb_balancelist的全部数据的sql
        /// </summary>
        /// <returns>成功:检索SQL语句 失败:null</returns>
        private string GetSqlForSelectAllInfoFromBalanceList()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.GetSqlForSelectAllInfoFromBalanceList.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetSqlForSelectAllInfoFromBalanceList.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得结算明细信息
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得结算明细信息 失败:null 没有查找到数据ArrayList.Count = 0</returns>
        private ArrayList QueryBalanceListsBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList balanceLists = new ArrayList();//结算明细实体集合
            BalanceList balanceList = null;//结算明细实体

            try
            {
                //循环结束
                while (this.Reader.Read())
                {
                    balanceList = new BalanceList();

                    ((Balance)balanceList.BalanceBase).Invoice.ID = this.Reader[0].ToString();//0发票号码
                    ((Balance)balanceList.BalanceBase).TransType = (TransTypes)NConvert.ToInt32(this.Reader[1].ToString());//1交易类型
                    ((Balance)balanceList.BalanceBase).Patient.ID = this.Reader[2].ToString();//2住院流水号
                    ((Balance)balanceList.BalanceBase).Patient.Pact.PayKind.ID = this.Reader[4].ToString();//4结算类别
                    ((Balance)balanceList.BalanceBase).Patient.Pact.ID = this.Reader[5].ToString();//5合同代码6
                    balanceList.FeeCodeStat.StatCate.ID = this.Reader[7].ToString();//7统计大类
                    balanceList.FeeCodeStat.StatCate.Name = this.Reader[8].ToString();//8统计大类名称
                    balanceList.FeeCodeStat.SortID = NConvert.ToInt32(this.Reader[9].ToString());//9打印顺序号
                    ((Balance)balanceList.BalanceBase).FT.TotCost = NConvert.ToDecimal(this.Reader[10].ToString());//10费用金额
                    ((Balance)balanceList.BalanceBase).FT.OwnCost = NConvert.ToDecimal(this.Reader[11].ToString());//11自费金额
                    ((Balance)balanceList.BalanceBase).FT.PayCost = NConvert.ToDecimal(this.Reader[12].ToString());//12自付金额
                    ((Balance)balanceList.BalanceBase).FT.PubCost = NConvert.ToDecimal(this.Reader[13].ToString());//13公费金额
                    ((Balance)balanceList.BalanceBase).FT.RebateCost = NConvert.ToDecimal(this.Reader[14].ToString());//14优惠金额
                    ((Balance)balanceList.BalanceBase).BalanceOper.ID = this.Reader[15].ToString();//15结算人代码
                    ((Balance)balanceList.BalanceBase).BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[16].ToString());//16结算时间
                    ((Balance)balanceList.BalanceBase).BalanceType.ID = this.Reader[17].ToString();//17结算类型
                    ((Balance)balanceList.BalanceBase).ID = this.Reader[18].ToString();//18结算序号
                    balanceList.ID = this.Reader[18].ToString();//18结算序号
                    //blist.IsBaby=NConvert.ToBoolean(this.Reader[19].ToString());
                    ((Balance)balanceList.BalanceBase).AuditingNO = this.Reader[20].ToString();// 20审核序号
                    ((Balance)balanceList.BalanceBase).BalanceOper.Dept.ID = this.Reader[21].ToString();// 21结算员科室

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
        /// 获得结算明细信息
        /// </summary>
        /// <param name="whereIndex">Where条件</param>
        /// <param name="args">参数</param>
        /// <returns>成功:结算明细信息 失败:null 没有查找到数据ArrayList.Count = 0</returns>
        private ArrayList QueryBalanceLists(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectAllInfoFromBalanceList();

            return this.QueryBalanceListsBySql(sql + " " + where, args);
        }

        #endregion

        #region 支付方式

        /// <summary>
        /// 获取检索balancepay的sql
        /// </summary>
        /// <returns>成功: 返回SQL语句 失败:null</returns>
        private string GetSqlForSelectBalancePay()
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.GetSqlForSelectBalancePay.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetSqlForSelectBalancePay.1的SQL语句";

                return null;
            }

            return sql;
        }

        /// <summary>
        /// 获得结算实付信息
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="args">参数</param>
        /// <returns>成功:支付信息集合 失败:null</returns>
        private ArrayList QueryBalancePaysBySql(string sql, params string[] args)
        {
            if (this.ExecQuery(sql, args) == -1)
            {
                return null;
            }

            ArrayList balancePays = new ArrayList();//支付方式集合
            BalancePay balancePay = null;//支付方式实体

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    balancePay = new BalancePay();

                    balancePay.Invoice.ID = this.Reader[0].ToString();//0发票号
                    balancePay.TransType = (TransTypes)NConvert.ToInt32(this.Reader[1].ToString());//1交易类型
                    balancePay.TransKind.ID = this.Reader[2].ToString();//2交易种类
                    balancePay.PayType.ID = this.Reader[3].ToString();//3支付方式
                    balancePay.BalanceNO = NConvert.ToInt32(this.Reader[4].ToString());//4结算序号
                    balancePay.FT.TotCost = NConvert.ToDecimal(this.Reader[5].ToString());//5金额
                    balancePay.Qty = NConvert.ToInt32(this.Reader[6].ToString());//6张数
                    //转入预交金
                    balancePay.Bank.ID = this.Reader[8].ToString();//8开户银行
                    balancePay.Bank.WorkName = this.Reader[9].ToString();//10开户行单位
                    balancePay.Bank.Account = this.Reader[10].ToString();//9开户行帐号
                    balancePay.Bank.InvoiceNO = this.Reader[11].ToString();//11支票号
                    balancePay.RetrunOrSupplyFlag = this.Reader[12].ToString();//12返回补收标记
                    balancePay.BalanceOper.ID = this.Reader[13].ToString();//结算人
                    balancePay.BalanceOper.OperTime = NConvert.ToDateTime(this.Reader[14].ToString());//14结算日期
                    balancePay.Bank.Name = this.Reader[15].ToString();//15开户行名称

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
        /// 获得支付信息
        /// </summary>
        /// <param name="whereIndex">where条件</param>
        /// <param name="args">参数</param>
        /// <returns>成功:获得支付信息集合 失败: null</returns>
        private ArrayList QueryBalancePays(string whereIndex, params string[] args)
        {
            string sql = string.Empty;//SELECT语句
            string where = string.Empty;//WHERE语句

            //获得Where语句
            if (this.Sql.GetSql(whereIndex, ref where) == -1)
            {
                this.Err = "没有找到索引为:" + whereIndex + "的SQL语句";

                return null;
            }

            sql = this.GetSqlForSelectBalancePay();

            return this.QueryBalancePaysBySql(sql + " " + where, args);
        }

        #endregion

        #endregion

        #region 公有方法

        #region 费用增删改操作

        /// <summary>
        /// 添加患者项目费用-插入非药品费用明细表信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="feeItemList">交的费用项目信息</param>
        ///  <param name="Insurence">医保的项目相关信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertFeeItemList(PatientInfo patient, FeeItemList feeItemList, Neusoft.HISFC.Models.Insurance.IInsurence Insurence)
        {
            if (feeItemList.Patient.Pact.ID == null || feeItemList.Patient.Pact.ID.Trim() == string.Empty)
            {
                feeItemList.Patient.Pact.ID = patient.Pact.ID;
            }

            if (feeItemList.Patient.Pact.PayKind.ID == null || feeItemList.Patient.Pact.PayKind.ID.Trim() == string.Empty)
            {
                feeItemList.Patient.Pact.PayKind.ID = patient.Pact.PayKind.ID;
            }

            return this.UpdateSingleTable("AddPatientAccount.1", this.GetFeeItemListParams(patient, feeItemList));
        }

        /// <summary>
        /// 添加患者项目费用-插入非药品费用明细表信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="feeItemList">交的费用项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertFeeItemList(PatientInfo patient, FeeItemList feeItemList)
        {
            return this.InsertFeeItemList(patient, feeItemList, null);
        }

        /// <summary>
        /// 添加患者项目费用-插入非药品费用明细表信息
        /// </summary>
        /// <param name="feeItemList">交的费用项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertFeeItemList(FeeItemList feeItemList)
        {
            return this.InsertFeeItemList(((PatientInfo)feeItemList.Patient), feeItemList);
        }

        /// <summary>
        /// 添加患者项目费用-插入药品费用明细表信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="medItemList">药品费用项目信息</param>
        /// <param name="Insurance">医保的项目相关信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertMedItemList(PatientInfo patient, FeeItemList medItemList, Neusoft.HISFC.Models.Insurance.IInsurence Insurance)
        {
            if (medItemList.Patient.Pact.ID == null || medItemList.Patient.Pact.ID.Trim() == string.Empty)
            {
                medItemList.Patient.Pact.ID = patient.Pact.ID;
            }

            if (medItemList.Patient.Pact.PayKind.ID == null || medItemList.Patient.Pact.PayKind.ID.Trim() == string.Empty)
            {
                medItemList.Patient.Pact.PayKind.ID = patient.Pact.PayKind.ID;
            }

            return this.UpdateSingleTable("AddPatientAccount.2", this.GetMedItemListParams(patient, medItemList));
        }

        ///<summary>
        /// 添加患者项目费用-插入药品费用明细表信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="medItemList">药品费用项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertMedItemList(PatientInfo patient, FeeItemList medItemList)
        {
            return this.InsertMedItemList(patient, medItemList, null);
        }

        ///<summary>
        /// 添加患者项目费用-插入药品费用明细表信息
        /// </summary>
        /// <param name="medItemList">药品费用项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertMedItemList(FeeItemList medItemList)
        {
            return this.InsertMedItemList(((PatientInfo)medItemList.Patient), medItemList);
        }

        /// <summary>
        /// 更新非药品费用明细表出库单号和扣库存流水号
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="updateSequence">更新库存流水号</param>
        /// <param name="sendSequence">出库单序列号</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateFeeItemSequence(string recipeNO, int recipeSequence, int updateSequence, int sendSequence)
        {
            return this.UpdateSingleTable("UpdateFeeItemSequence.1", recipeNO, recipeSequence.ToString(), updateSequence.ToString(), sendSequence.ToString());
        }

        /// <summary>
        /// 摆药时更新更新药品费用明细表出库单号和扣库存流水号
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="updateSequence">更新库存流水号</param>
        /// <param name="sendSequence">出库单序列号</param>
        /// <param name="sendDrugDept">摆药科室</param>
        /// <param name="sendDrugOperCode">摆药人代码</param>
        /// <param name="sendDrugTime">摆药时间</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateMedItemExecInfo(string recipeNO, int recipeSequence, int updateSequence, int sendSequence, string sendDrugDept, string sendDrugOperCode, DateTime sendDrugTime)
        {
            return this.UpdateSingleTable("UpdateMedItemSequence.1", recipeNO, recipeSequence.ToString(), updateSequence.ToString(), sendSequence.ToString(),
                sendDrugDept, sendDrugOperCode, sendDrugTime.ToString());
        }
        /// <summary>
        /// 摆药时更新更新药品费用明细表出库单号和扣库存流水号
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="updateSequence">更新库存流水号</param>
        /// <param name="sendSequence">出库单序列号</param>
        /// <param name="sendState">是否发药</param>
        /// <param name="sendDrugDept">摆药科室</param>
        /// <param name="sendDrugOperCode">摆药人代码</param>
        /// <param name="sendDrugTime">摆药时间</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateMedItemExecInfo(string recipeNO, int recipeSequence, int updateSequence, int sendSequence,int sendState, string sendDrugDept, string sendDrugOperCode, DateTime sendDrugTime)
        {
            return this.UpdateSingleTable("UpdateMedItemSequence.2", recipeNO, recipeSequence.ToString(), updateSequence.ToString(), sendSequence.ToString(),
                sendState.ToString(), sendDrugDept, sendDrugOperCode, sendDrugTime.ToString());
        }    

        /// <summary>
        /// 删除划价信息
        /// </summary>
        /// <param name="itemList">项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int DeleteChargeInfo(FeeItemList itemList)
        {
            //if (itemList.Item.IsPharmacy)
            if (itemList.Item.ItemType == HISFC.Models.Base.EnumItemType.Drug)
            {
                return this.UpdateSingleTable("Fee.DeleteDrugCharge.1", itemList.RecipeNO, itemList.SequenceNO.ToString());
            }
            else
            {
                return this.UpdateSingleTable("Fee.DeleteUndrugCharge.1", itemList.RecipeNO, itemList.SequenceNO.ToString());
            }
        }

        /// <summary>
        /// 更改划价后的信息
        /// </summary>
        /// <param name="itemList">项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateChargeInfo(FeeItemList itemList)
        {
            //if (itemList.Item.IsPharmacy)
            if (itemList.Item.ItemType == EnumItemType.Drug)
            {
                return this.UpdateSingleTable("Fee.UpdateChargeInfoForDrug.1", this.GetUpdateChargeItemParams(itemList));
            }
            else
            {
                return this.UpdateSingleTable("Fee.UpdateChargeInfoForUnDrug.1", this.GetUpdateChargeItemParams(itemList));
            }
        }

        /// <summary>
        /// 划价后更新收费标记收费人收费时间相关信息
        /// </summary>
        /// <param name="itemList">项目信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateChargeItemToFee(FeeItemList itemList)
        {
            //if (itemList.Item.IsPharmacy)
            if(itemList.Item.ItemType == EnumItemType.Drug)
            {
                return this.UpdateSingleTable("UpdateDrugItem.2", this.GetUpdateChargeItemToFeeParmas(itemList));
            }
            else
            {
                return this.UpdateSingleTable("UpdateUndrugItem.2", this.GetUpdateChargeItemToFeeParmas(itemList));
            }
        }

        /// <summary>
        /// 更新费用信息为结算状态 Written By 王儒超--------------暂时没用,考虑效率问题采用直接全部update
        /// </summary>
        /// <param name="feeInfo">费用信息</param>
        /// <param name= "balance">结算信息</param>>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateFeeInfoBalanced(FeeInfo feeInfo, Balance balance)
        {
            return this.UpdateSingleTable("UpdateAccoutBalanced.1", feeInfo.RecipeNO, feeInfo.ExecOper.Dept.ID, feeInfo.Item.MinFee.ID,
                balance.ID, balance.Oper.ID, balance.Oper.OperTime.ToString());
        }

        /// <summary>
        /// 更新患者药品明细表急诊审批标记
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="isApp">是否审批</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateEmergencyForDrug(string recipeNO, int recipeSequence, bool isApp)
        {
            return this.UpdateSingleTable("Fee.UpdateEmergencyForDrug", recipeNO, recipeSequence.ToString(), NConvert.ToInt32(isApp).ToString());
        }

        /// <summary>
        /// 更新患者非药品明细表急诊审批标记
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="isApp">是否审批</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateEmergencyForUndrug(string recipeNO, int recipeSequence, bool isApp)
        {
            return this.UpdateSingleTable("Fee.UpdateEmergencyForUndrug", recipeNO, recipeSequence.ToString(), NConvert.ToInt32(isApp).ToString());
        }

        /// <summary>
        /// 更新患者费用信息-主表的
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateInMainInfoFee(string inpatientNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.InPatient.UpdateAccount.10", inpatientNO, ft.OwnCost.ToString(), ft.PubCost.ToString(),
                ft.PayCost.ToString(), ft.TotCost.ToString(), ft.RebateCost.ToString());
        }
      
        /// <summary>
        /// 更新患者费用信息-主表的(医保)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateInMainInfoFeeYB(string inpatientNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.InPatient.UpdateAccount.8", inpatientNO, ft.OwnCost.ToString(), ft.PubCost.ToString(),
                ft.PayCost.ToString(), ft.TotCost.ToString(), ft.RebateCost.ToString());
        }

        /// <summary>
        /// 更新患者费用信息-主表的
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateInMainInfoFeeForDirQuit(string inpatientNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.InPatient.UpdateAccount.ForDirQuit", inpatientNO, ft.OwnCost.ToString(), ft.PubCost.ToString(),
                ft.PayCost.ToString(), ft.TotCost.ToString(), ft.RebateCost.ToString());
        }

        /// <summary>
        /// 更新药品明细可退数量
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="qty">可退数量</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateNoBackQtyForDrug(string recipeNO, int recipeSequence, decimal qty, string balanceState)
        {
            return this.UpdateSingleTable("Fee.UpdateNoBackNumForDrug.1", recipeNO, recipeSequence.ToString(), qty.ToString(), balanceState);
        }

        /// <summary>
        /// 更新非药品明细可退数量
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="qty">可退数量</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateNoBackQtyForUndrug(string recipeNO, int recipeSequence, decimal qty, string balanceState)
        {
            return this.UpdateSingleTable("Fee.UpdateNoBackNumForUndrug.1", recipeNO, recipeSequence.ToString(), qty.ToString(), balanceState);
        }

        /// <summary>
        /// 更新非药品明细扩展标记
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="extFlag2">扩展标记2</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateExtFlagForUndrug(string recipeNO, int recipeSequence, string extFlag2, string balanceState)
        {
            return this.UpdateSingleTable("Fee.UpdateExtFlagForUndrug.1", recipeNO, recipeSequence.ToString(), extFlag2, balanceState);
        }

        /// <summary>
        /// 更新主表各费用金额----为了中山医医保预结算用  更新令主表金额直接等于Ft中各项值
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdateInmaininfoFeeForMedicare(PatientInfo patient, FT ft)
        {
            return this.UpdateSingleTable("Fee.UpdateInmaininfoFeeForMedicare", patient.ID, ft.TotCost.ToString(), ft.OwnCost.ToString(), ft.PayCost.ToString(), ft.PubCost.ToString());
        }

        /// <summary>
        /// 更新托收单打印标记
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功: 1 失败 : -1 没有更新数据: 0</returns>
        public int UpdatePrintFlag(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.UpdateSingleTable("Fee.InPatient.UpdatePrintFlag", inpatientNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        ///插入FeeInfo信息
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="feeItemList">费用明细信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertFeeInfo(PatientInfo patient, FeeItemList feeItemList)
        {
            return this.UpdateSingleTable("Fee.Inpatient.AddPatientAccount.2", this.GetFeeInfoParams(patient, this.ConvertFeeItemListToFeeInfo(feeItemList)));
        }
        
        /// <summary>
        ///插入FeeInfo信息
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="feeInfo">费用汇总信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertFeeInfo(PatientInfo patient, FeeInfo feeInfo)
        {
            return this.UpdateSingleTable("Fee.Inpatient.AddPatientAccount.2", this.GetFeeInfoParams(patient, feeInfo));
        }

        /// <summary>
        /// 插入患者费用汇总信息,如果主键重复,那么更新该条费用汇总信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="feeItemList">费用明细信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertAndUpdateFeeInfo(PatientInfo patient, FeeItemList feeItemList)
        {
            int returnValue = 0;

            returnValue = this.InsertFeeInfo(patient, feeItemList);

            //插入费用信息后主键重复,那么更新该条费用汇总信息
            if (returnValue == -1 && this.DBErrCode == 1)
            {
                return this.UpdateSingleTable("Fee.Inpatient.AddPatientAccount.3", this.GetFeeInfoParams(patient, this.ConvertFeeItemListToFeeInfo(feeItemList)));
            }

            return returnValue;
        }

        /// <summary>
        /// 插入患者费用汇总信息,如果主键重复,那么更新该条费用汇总信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="feeInfo">费用汇总信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertAndUpdateFeeInfo(PatientInfo patient, FeeInfo feeInfo)
        {
            int returnValue = 0;

            returnValue = this.InsertFeeInfo(patient, feeInfo);

            //插入费用信息后主键重复,那么更新该条费用汇总信息
            if (returnValue == -1 && this.DBErrCode == 1)
            {
                return this.UpdateSingleTable("Fee.Inpatient.AddPatientAccount.3", this.GetFeeInfoUpdateParams(feeInfo));
            }

            return returnValue;
        }

        /// <summary>
        /// 添加结算明细记录
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="balanceList">结算明细记录信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertBalanceList(PatientInfo patient, BalanceList balanceList)
        {
            return this.UpdateSingleTable("AddBalanceList.1", this.GetBalanceListParams(patient, balanceList));
        }

        /// <summary>
        /// 添加结算记录
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="balance">结算记录信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertBalance(PatientInfo patient, Balance balance)
        {
            return this.UpdateSingleTable("AddBalanceHead.1", this.GetBalanceParams(patient, balance));
        }

        /// <summary>
        /// 添加结算支付信息
        /// </summary>
        /// <param name="balancePay">支付信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertBalancePay(BalancePay balancePay)
        {
            return this.UpdateSingleTable("AddBalancePay.1", this.GetBalancePayParams(balancePay));
        }

        /// <summary>
        /// 更新结算主表生育保险最后结算标志
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="transType">交易类型</param>
        /// <param name="laseFalg">最后结算标志</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int UpdateBalanceHeadLastFlag(string invoiceNO, string transType, string laseFalg)
        {
            return this.UpdateSingleTable("Fee.UpdateBalanceHeadLastFlag", invoiceNO, transType, laseFalg);
        }

        #endregion

        #region 预交金

        /// <summary>
        /// 插入预交金费用(prepay实体中的Patient属性没有赋值)
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有插入数据 0</returns>
        public int InsertPrepay(PatientInfo patient, Prepay prepay)
        {
            return this.UpdateSingleTable("Fee.Inpatient.Prepay.1", this.GetPrepayParams(patient, prepay));
        }

        /// <summary>
        ///  插入预交金费用(prepay实体中的Patient属性已经赋值)
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有插入数据 0</returns>
        public int InsertPrepay(Prepay prepay)
        {
            return this.InsertPrepay(prepay.Patient, prepay);
        }

        /// <summary>
        /// 更新患者主表预交金信息
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepay(PatientInfo patient, Prepay prepay)
        {
            return this.UpdateSingleTable("Fee.Inpatient.UpdateAccount11", patient.ID, prepay.FT.PrepayCost.ToString());
        }

        /// <summary>
        /// 更新患者主表预交金信息(prepay实体中的Patient属性已经赋值,至少Patient.ID赋值)
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepay(Prepay prepay)
        {
            return this.UpdatePrepay(prepay.Patient, prepay);
        }

        /// <summary>
        /// 更新转押金发票号和转押金状态
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdateForgift(PatientInfo patient, Prepay prepay)
        {
            //{0E4732FC-5C33-4106-9784-2673D7D88316} 转押金打印转入预交金票号
            //return this.UpdateSingleTable("UpdateForgift.1", patient.ID, prepay.ID, prepay.Invoice.ID, this.Operator.ID);
            return this.UpdateSingleTable("UpdateForgift.1", patient.ID, prepay.ID, prepay.RecipeNO, this.Operator.ID);
        }

        /// <summary>
        /// 更新转押金发票号和转押金状态(prepay实体中的Patient属性已经赋值,至少Patient.ID赋值)
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdateForgift(Prepay prepay)
        {
            return this.UpdateForgift(prepay.Patient, prepay);
        }

        /// <summary>
        /// 更新单条预交金-为结算状态 Written By 王儒超
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepayBalanced(PatientInfo patient, Prepay prepay)
        {
            return this.UpdateSingleTable("Fee.Inpatient.Prepay.2", patient.ID, prepay.ID, prepay.BalanceOper.OperTime.ToString(),
                prepay.BalanceOper.ID, prepay.BalanceNO.ToString(), prepay.Invoice.ID);
        }

        /// <summary>
        /// 更新单条预交金-为结算状态(prepay实体中的Patient属性已经赋值,至少Patient.ID赋值)
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepayBalanced(Prepay prepay)
        {
            return this.UpdatePrepayBalanced(prepay.Patient, prepay);
        }

        /// <summary>
        /// 更新预交金反还标志-为已经反还或补打
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepayHaveReturned(PatientInfo patient, Prepay prepay)
        {
            return this.UpdateSingleTable("Fee.Inpatient.Prepay.3", patient.ID, prepay.ID, prepay.PrepayState);
        }

        /// <summary>
        /// 更新预交金反还标志-为已经反还或补打(prepay实体中的Patient属性已经赋值,至少Patient.ID赋值)
        /// </summary>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepayHaveReturned(Prepay prepay)
        {
            return this.UpdatePrepayHaveReturned(prepay.Patient, prepay);
        }

        /// <summary>
        /// 更新预交金新发票号,和结算序号.
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int UpdatePrepayForReprint(PatientInfo patient, Prepay prepay)
        {
            return this.UpdateSingleTable("Fee.Inpatient.Prepay.4", patient.ID, prepay.ID, prepay.Invoice.ID, prepay.BalanceNO.ToString());
        }

        /// <summary>
        /// 预交金收取,返还-操作标记0收取1返还
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <param name="flag">操作标记 0收取 1返还</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        private int PrepayManager(PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.Prepay prepay, string flag)
        {
            if ((flag != "0") && (flag != "1"))
            {
                this.Err = "输入操作类型不正确!";
                this.ErrCode = "输入操作类型不正确!";

                return -1;
            }
            //返还
            if (flag == "1")
            {
                prepay.FT.PrepayCost = -prepay.FT.PrepayCost;
                prepay.PrepayOper.ID = this.Operator.ID;
                prepay.PrepayOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(GetSysDateTime());
                prepay.PrepayState = "1";

                if (UpdatePrepayHaveReturned(patient, prepay) < 1)
                {
                    this.Err = this.Err + "该条记录已经结算或者进行过返还补打,更新状态出错!";

                    return -1;
                }
            }
            //插入预交金
            if (this.InsertPrepay(patient, prepay) == -1)
            {
                this.Err = this.Err + "插入预交金出错!函数为AddPatientAccount";

                return -1;
            }
            //更新预交金
            if (UpdatePrepay(patient, prepay) == -1)
            {
                this.Err = this.Err + "更新住院主表失败!函数为UpdateAccount";

                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 预交金收取
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int PrepayManager(PatientInfo patient, Prepay prepay)
        {
            return this.PrepayManager(patient, prepay, "0");
        }
        /// <summary>
        /// 预交金返还
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="prepay">预交金实体</param>
        /// <returns>成功: 1 失败 -1 没有更新数据 0</returns>
        public int PrepayManagerReturn(PatientInfo patient, Prepay prepay)
        {
            return this.PrepayManager(patient, prepay, "1");
        }

        #endregion

        #region 预交金查询

        /// <summary>
        /// 预交金查询-通过住院流水号查
        /// </summary>
        /// <param name="inpatientNO">住院流水号InpatientNo</param>
        /// <returns>成功:返回预交金实体集合 失败 null</returns>
        public ArrayList QueryPrepays(string inpatientNO)
        {
            return this.QueryPrepays("Fee.Inpatient.Prepay.Get.3", inpatientNO);
        }

        /// <summary>
        /// 查询患者有效预交金记录--For结算-通过住院流水号查
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:返回预交金实体集合 失败 null</returns>
        public ArrayList QueryPrepaysBalanced(string inpatientNO)
        {
            return this.QueryPrepays("Fee.QueryPrepayForBalance.1", inpatientNO);
        }

        /// <summary>
        ///  提取未打印转押金-通过住院流水号查
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功: 未打印转押金集合 失败 null</returns>
        public ArrayList QueryForegif(string inpatientNO)
        {
            return this.QueryPrepays("Fee.Inpatient.Prepay.Get.2", inpatientNO);
        }

        /// <summary>
        /// 获取转入预交金总金额
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:转入预交金总金额 失败: -1</returns>
        public decimal GetTotChangePrepayCost(string inpatientNO)
        {
            return NConvert.ToDecimal(this.ExecSqlReturnOne("Fee.GetTotChangePrepayCost.1", inpatientNO));
        }

        /// <summary>
        /// 获取某此结算的预交金记录
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:返回预交金实体集合 失败 null</returns>
        public ArrayList QueryPrepaysByInpatientNOAndBalanceNO(string inpatientNO, string balanceNO)
        {
            return this.QueryPrepays("Fee.GetPrepayByBalNo.1", inpatientNO, balanceNO);
        }

        /// <summary>
        /// 查询预交金信息
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="happenNO"></param>
        /// <returns></returns>
        public Prepay QueryPrePay(string inpatientNO, string happenNO)
        {
            ArrayList al = QueryPrepays("Fee.Inpatient.Prepay.Get.4", inpatientNO, happenNO);
            if (al == null || al.Count == 0)
            {
                return null;
            }
            return al[0] as Prepay;
        }
        #endregion

        #region 获得处方号

        /// <summary>
        /// 获得新非药品处方号
        /// </summary>
        /// <returns>成功:非药品处方号 失败:null</returns>
        public string GetUndrugRecipeNO()
        {
            string recipeNO = this.GetSequence("GetUndrugNewNoteNo.1");

            if (recipeNO != null)
            {
                return "F" + recipeNO.PadLeft(13, '0');
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得新药品处方号
        /// </summary>
        /// <returns>成功:药品处方号 失败:null</returns>
        public string GetDrugRecipeNO()
        {
            string recipeNO = this.GetSequence("GetDrugNewNoteNo.1");

            if (recipeNO != null)
            {
                return "Y" + recipeNO.PadLeft(13, '0');
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 获得发票号

        /// <summary>
        /// 获得新的发票号 Written By 王儒超 调用存储过程
        /// 根据操作员的ID和财务组代码 输入票据预警数目 返回剩余发票数目 表现层用发票数目-预警数目判断提示领取发票
        /// 由于票据预警数目的定义可能比较不固定所以业务层不作判断 返回的剩余数目默认10000 只有小于预警数目才会返回
        /// 真实数目,考虑这样表现层只需相减判断,处理比较简单也比较通用.
        /// </summary>
        /// <param name="OperatorID">操作员代码</param>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="alarmQty">票据预警数目</param>
        /// <param name="leftQty">剩余发票数目</param>
        /// <param name="finGroupCode">财务组代码</param>
        /// <returns>发票号 </returns>
        ///{18CCD3AA-4DA2-4d7c-BE29-54A7751B183F}
        [Obsolete("废弃",true)]
        public string GetNewInvoiceNO(string OperatorID, EnumInvoiceType invoiceType, int alarmQty, ref int leftQty, string finGroupCode)
        {
            string sql = string.Empty;//SQL语句
            string returnString = string.Empty;//返回参数
            string[] temp;//临时存储过程返回字符串
            string invoiceNO = string.Empty;//发票号
            int errCode = 0;//返回错误编码
            string errText = string.Empty;//存储过程返回错误信息

            if (this.Sql.GetSql("Fee.Inpatient.Invoice.Get.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.Inpatient.Invoice.Get.1得SQL语句";

                return null;
            }
            try
            {
                sql = string.Format(sql, invoiceType.ToString(), OperatorID, leftQty, invoiceNO, errText, errCode, finGroupCode);
            }
            catch (Exception e)
            {
                this.Err = e.Message;

                return null;
            }

            if (this.ExecEvent(sql, ref returnString) == -1)
            {
                this.Err = "执行存储过程出错!PRC_GET_INVOICE";
                this.WriteErr();

                return null;
            }

            temp = returnString.Split(',');
            invoiceNO = temp[0];
            errText = temp[1];

            errCode = NConvert.ToInt32(temp[2]);

            //如果返回错误编码为100说明没有找到发票号
            if (errCode == 100)
            {
                this.Err ="请领取发票！";
                this.ErrCode = errCode.ToString();

                return null;
            }
            //如果返回错误编码为101说明找到发票号但是剩余发票号低于预警数目
            if (errCode == 101)
            {
                leftQty = NConvert.ToInt32(errText);
            }
            else//如果正常获得发票号,那么剩余发票号默认为10000
            {
                leftQty = 10000;
            }

            return invoiceNO;
        }

        #endregion

        #region 获得发票号

        /// <summary>
        /// 获得新的发票号 Written By 王儒超 调用存储过程
        /// 根据操作员的ID和财务组代码 输入票据预警数目 返回剩余发票数目 表现层用发票数目-预警数目判断提示领取发票
        /// 由于票据预警数目的定义可能比较不固定所以业务层不作判断 返回的剩余数目默认10000 只有小于预警数目才会返回
        /// 真实数目,考虑这样表现层只需相减判断,处理比较简单也比较通用.
        /// </summary>
        /// <param name="OperatorID">操作员代码</param>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="alarmQty">票据预警数目</param>
        /// <param name="leftQty">剩余发票数目</param>
        /// <param name="finGroupCode">财务组代码</param>
        /// <returns>发票号 </returns>
        //{18CCD3AA-4DA2-4d7c-BE29-54A7751B183F}
        public string GetNewInvoiceNO(string OperatorID, string invoiceType, int alarmQty, ref int leftQty, string finGroupCode)
        {
            string sql = string.Empty;//SQL语句
            string returnString = string.Empty;//返回参数
            string[] temp;//临时存储过程返回字符串
            string invoiceNO = string.Empty;//发票号
            int errCode = 0;//返回错误编码
            string errText = string.Empty;//存储过程返回错误信息

            if (this.Sql.GetSql("Fee.Inpatient.Invoice.Get.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.Inpatient.Invoice.Get.1得SQL语句";

                return null;
            }
            try
            {
                sql = string.Format(sql, invoiceType.ToString(), OperatorID, leftQty, invoiceNO, errText, errCode, finGroupCode);
            }
            catch (Exception e)
            {
                this.Err = e.Message;

                return null;
            }

            if (this.ExecEvent(sql, ref returnString) == -1)
            {
                this.Err = "执行存储过程出错!PRC_GET_INVOICE";
                this.WriteErr();

                return null;
            }

            temp = returnString.Split(',');
            invoiceNO = temp[0];
            errText = temp[1];

            errCode = NConvert.ToInt32(temp[2]);

            //如果返回错误编码为100说明没有找到发票号
            if (errCode == 100)
            {
                this.Err = "请领取发票！";
                this.ErrCode = errCode.ToString();

                return null;
            }
            //如果返回错误编码为101说明找到发票号但是剩余发票号低于预警数目
            if (errCode == 101)
            {
                leftQty = NConvert.ToInt32(errText);
            }
            else//如果正常获得发票号,那么剩余发票号默认为10000
            {
                leftQty = 10000;
            }

            return invoiceNO;
        }

        #endregion

        #region 费用查询

        /// <summary>
        /// 通过最小费用代码获得最小费用名称
        /// </summary>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:最小费用名称 失败: null</returns>
        public string GetMinFeeNameByCode(string minFeeCode)
        {
            return this.ExecSqlReturnOne("GetFeeNameByFeeCode.1", minFeeCode);
        }

        /// <summary>
        ///  获得婴儿费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功:获得婴儿费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeForBaby(string inpatientNO, DateTime beginTime, DateTime endTime, string balanceState)
        {
            return this.QueryFeeInfoGroups("GetFeeInfosGroupByMinFeeForBaby.1", inpatientNO, beginTime.ToString(), endTime.ToString(), balanceState);
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeByInpatientNO(string inpatientNO, DateTime beginTime, DateTime endTime, string balanceState)
        {
            return this.QueryFeeInfoGroups("GetFeeInfosGroupbyMinFee.1", inpatientNO, beginTime.ToString(), endTime.ToString(), balanceState);
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// GetFeeInfosGroupbyMinFee.1
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeByInpatientNO(string inpatientNO, DateTime beginTime, string balanceState)
        {
            DateTime endTime = this.GetDateTimeFromSysDateTime();

            return this.QueryFeeInfosGroupByMinFeeByInpatientNO(inpatientNO, beginTime, endTime, balanceState);
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组）住院流水号,结算序号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeByInpatientNO(string inpatientNO, int balanceNO)
        {
            return this.QueryFeeInfoGroups("GetFeeInfosGroupbyMinFee.2", inpatientNO, balanceNO.ToString());
        }

        /// <summary>
        /// 获得费用信息FeeInfoUnion转入费用（最小费用分组）-住院流水号,结算状态
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceState">balanceState</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosAndChangeCostGroupByMinFeeByInpatientNO(string inpatientNO, string balanceState)
        {
            return this.QueryFeeInfoGroups("GetFeeInfosAndChangeCostGroupByMinFee.1", inpatientNO, balanceState);
        }

        /// <summary>
        ///  获得费用信息FeeInfo（最小费用分组)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceState">结算状态</param>
        /// <param name="transType">交易类型，1正交易2反交易3药费调整</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeByInpatientNO(string inpatientNO, string balanceState, TransTypes transType)
        {
            return this.QueryFeeInfoGroups("Fee.InPatient.GetMinFeeInfoByPatientID", inpatientNO, balanceState, ((int)transType).ToString());
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeForAdjustOverTopByInpatientNO(string inpatientNO)
        {
            return this.QueryFeeInfoGroups("Fee.InPatient.GetMinFeeForAdjustOverTop", inpatientNO);
        }

        /// <summary>
        /// 获取日限额调整过的明细
        /// 特征：tot_cost=0,own_cost!=0
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosGroupByMinFeeForAdjustByInpatientNO(string inpatientNO)
        {
            return this.QueryFeeInfoGroups("Fee.InPatient.GetMinFeeInfoForAdjust", inpatientNO);
        }

        /// <summary>
        /// 根据住院号，开始结束时间查找未打印的托收单
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosForPrintBill(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryFeeInfoGroups("Fee.InPatient.GetFeeInfosForPrintBill", inpatientNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 指定时间到现在未打印的托收单
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosForPrintBill(string inpatientNO, DateTime beginTime)
        {
            DateTime endTime = this.GetDateTimeFromSysDateTime();

            return this.QueryFeeInfosForPrintBill(inpatientNO, beginTime, endTime);
        }

        /// <summary>
        /// 根据住院号，开始结束时间查找已打印的托收单--用于补打
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:获得费用信息FeeInfo（最小费用分组） 失败:null</returns>
        public ArrayList QueryFeeInfosForPrinted(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryFeeInfoGroups("Fee.InPatient.GetFeeInfosForPrinted", inpatientNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 获得患者的非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>成功:获得费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemLists(string inpatientNO, DateTime beginTime, DateTime endTime, string flag)
        {
            string upload = string.Empty;//是否上传标记

            if (flag.ToUpper() == "ALL")//所有
            {
                upload = "%";
            }
            else if (flag.ToUpper() == "YES")
            {
                upload = "1";
            }
            else
            {
                upload = "0";
            }

            return this.QueryFeeItemLists("Fee.GetMedItemsForInpatient.Where.Upload", inpatientNO, beginTime.ToString(), endTime.ToString(), upload);
        }

        /// <summary>
        /// 获得患者非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:获得费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemLists(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryFeeItemLists("Fee.GetMedItemsForInpatient.Where.1", inpatientNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 获得非药品划价信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:获得费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsForCharged(string inpatientNO)
        {
            return this.QueryFeeItemLists("Fee.GetUndrugChargeItems.1", inpatientNO);
        }

        /// <summary>
        /// 获得患者的药品费用信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>成功:获得药品费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemLists(string inpatientNO, DateTime beginTime, DateTime endTime, string flag)
        {
            string upload = string.Empty;//上传标志

            if (flag.ToUpper() == "ALL")//所有
            {
                upload = "%";
            }
            else if (flag.ToUpper() == "YES")
            {
                upload = "1";
            }
            else
            {
                upload = "0";
            }

            return this.QueryMedItemLists("Fee.GetMedItemsForInpatient.Where.Upload", inpatientNO, beginTime.ToString(), endTime.ToString(), upload);
        }


        /// <summary>
        /// 获得患者药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:获得药品费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList GetMedItemsForInpatient(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryMedItemLists("Fee.GetMedItemsForInpatient.Where.1", inpatientNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 获得药品划价信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功:获得药品费用信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListCharged(string inpatientNO)
        {
            return this.QueryMedItemLists("Fee.GetDrugChargeItems.1", inpatientNO);
        }

        /// <summary>
        /// 根据是否结算提取患者可退费非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isBalanced">是否结算</param>
        /// <returns>成功:根据是否结算提取患者可退费非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime, bool isBalanced)
        {
            return this.QueryFeeItemLists("Fee.GetForQuitUndrug.1", inpatientNO, beginTime.ToString(), endTime.ToString(), NConvert.ToInt32(isBalanced).ToString());
        }

        /// <summary>
        /// 根据是否结算提取患者可退费非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:根据是否结算提取患者可退费非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryFeeItemListsCanQuit(inpatientNO, beginTime, endTime, false);
        }

        /// <summary>
        /// 根据是否结算提取患者可退费非药品信息
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isBalanced"></param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:根据是否结算提取患者可退费非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime, bool isBalanced, string minFeeCode)
        {
            return this.QueryFeeItemLists("Fee.GetForQuitUndrug.2", inpatientNO, beginTime.ToString(), endTime.ToString(),
                NConvert.ToInt32(isBalanced).ToString(), minFeeCode);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="sendDrugState">是否发药</param>
        /// <param name="isBalanced">是否结算</param>
        /// <returns>成功:根据是否结算提取患者可退费药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime, string sendDrugState, bool isBalanced)
        {
            return this.QueryMedItemLists("Fee.GetForQuitDrug.1", inpatientNO, beginTime.ToString(), endTime.ToString(), sendDrugState, NConvert.ToInt32(isBalanced).ToString());
        }

        /// <summary>
        /// 根据发放状态提取一段时间范围内未结算的供可供退费的药品项目
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="sendDrugState">是否发药</param>
        /// <returns>成功:根据是否结算提取患者可退费药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime, string sendDrugState)
        {
            return this.QueryMedItemListsCanQuit(inpatientNO, beginTime, endTime, sendDrugState, false);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="sendDrugState">是否发药</param>
        /// <param name="isBalanced">是否结算</param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:根据是否结算提取患者可退费药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsCanQuit(string inpatientNO, DateTime beginTime, DateTime endTime, string sendDrugState, bool isBalanced, string minFeeCode)
        {
            return this.QueryMedItemLists("Fee.GetForQuitDrug.3", inpatientNO, beginTime.ToString(), endTime.ToString(), sendDrugState, NConvert.ToInt32(isBalanced).ToString(), minFeeCode);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="sendDrugState">是否发药</param>
        /// <param name="isBalanced">是否结算</param>
        /// <returns>成功:根据是否结算提取患者可退费药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsCanQuitByInvoiceNO(string invoiceNO, DateTime beginTime, DateTime endTime, string sendDrugState, bool isBalanced)
        {
            return this.QueryMedItemLists("Fee.GetForQuitDrug.2", invoiceNO, beginTime.ToString(), endTime.ToString(), sendDrugState, NConvert.ToInt32(isBalanced).ToString());
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="sendDrugState">是否发药</param>
        /// <param name="isBalanced">是否结算</param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:根据是否结算提取患者可退费药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsCanQuitByInvoiceNO(string invoiceNO, DateTime beginTime, DateTime endTime, string sendDrugState, bool isBalanced, string minFeeCode)
        {
            return this.QueryMedItemLists("Fee.GetForQuitDrug.4", invoiceNO, beginTime.ToString(), endTime.ToString(), sendDrugState, NConvert.ToInt32(isBalanced).ToString(), minFeeCode);
        }

        /// <summary>
        /// 按获得患者非药品收费信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">科室代码</param>
        /// <returns>成功:患者非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsByInpatientNO(string inpatientNO, DateTime beginTime, DateTime endTime, string deptCode)
        {
            return this.QueryFeeItemLists("Fee.GetPatientUndrug.1", inpatientNO, beginTime.ToString(), endTime.ToString(), deptCode);
        }

        /// <summary>
        /// 获得患者药品收费信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">科室代码</param>
        /// <returns>成功:患者药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsByInpatientNO(string inpatientNO, DateTime beginTime, DateTime endTime, string deptCode)
        {
            return this.QueryMedItemLists("Fee.GetPatientDrug.1", inpatientNO, beginTime.ToString(), endTime.ToString(), deptCode);
        }

        /// <summary>
        /// 获得患者和执行科室的非药品收费明细
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="execDeptCode">科室代码</param>
        /// <returns>成功:患者非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListsByInpatientNOAndDept(string inpatientNO, string execDeptCode)
        {
            return this.QueryFeeItemLists("Fee.GetFeeItemListByInpatientAndDept.1", inpatientNO, execDeptCode);
        }

        /// <summary>
        /// 获得患者和执行科室已经确认的非药品收费明细
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="execDeptCode">科室代码</param>
        /// <returns>成功:患者非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryExeFeeItemListsByInpatientNOAndDept(string inpatientNO, string execDeptCode)
        {
            return this.QueryFeeItemLists("Fee.GetExeFeeItemListByInpatientAndDept.1", inpatientNO, execDeptCode);
        }

        /// <summary>
        /// 获得患者和执行科室的药品收费明细
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="execDeptCode">科室代码</param>
        /// <returns>成功:患者药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsByInpatientNOAndDept(string inpatientNO, string execDeptCode)
        {
            return this.QueryMedItemLists("Fee.GetMedItemListByInpatientAndDept.1", inpatientNO, execDeptCode);
        }



        //{F8137B37-C1B1-4fe1-8008-00F17B4FE40E}
        /// <summary>
        /// 根据药品状态查找患者药品项目
        /// </summary>
        /// <param name="inpatientNO">住院号</param>
        /// <param name="sendDrugState">药品状态</param>
        /// <returns></returns>
        public ArrayList QueryMedItemLists(string inpatientNO, string sendDrugState)
        {
            return this.QueryMedItemLists("Fee.GetForQuitDrug.5", inpatientNO, sendDrugState);
        }

        /// <summary>
        /// 检索药品和非药品明细单条记录---通过主键
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="isPharmacy">是否药品 Drug(true)是 UnDrug(false)非药品</param>
        /// <returns>成功: 药品和非药品明细单条记录 失败: null</returns>
        public FeeItemList GetItemListByRecipeNO(string recipeNO, int recipeSequence, EnumItemType isPharmacy)
        {
            ArrayList feeItemLists = new ArrayList();

            if (isPharmacy == EnumItemType.Drug)
            {
                feeItemLists = this.QueryMedItemLists("Fee.GetFeeItemListByNoteNoAndNoteSequence.1", recipeNO, recipeSequence.ToString());
            }
            else
            {
                feeItemLists = this.QueryFeeItemLists("Fee.GetFeeItemListByNoteNoAndNoteSequence.1", recipeNO, recipeSequence.ToString());
            }

            if (feeItemLists == null)
            {
                return null;
            }

            if (feeItemLists.Count == 0)
            {
                this.Err = "没有找到费用信息";

                return null;
            }

            return (FeeItemList)feeItemLists[0];
        }

        /// <summary>
        /// 直接结算退费,通过发票号获得药品费用明细
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:患者药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListByInvoiceNO(string invoiceNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryMedItemLists("Fee.GetMedItemFromInvoice.1", invoiceNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 直接结算退费,通过发票号获得非药品费用明细
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功:患者非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListByInvoiceNO(string invoiceNO, DateTime beginTime, DateTime endTime)
        {
            return this.QueryFeeItemLists("Fee.GetUndrugItemFromInvoice.1", invoiceNO, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 获取费用汇总信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:费用汇总信息 失败:null 没有找到数据:ArrayList.Count = 0</returns>
        public ArrayList QueryFeeInfosByInpatientNOAndBalanceNO(string inpatientNO, string balanceNO)
        {
            return this.QueryFeeInfos("Fee.GetFeeInfoBalanceByBalNo.1", inpatientNO, balanceNO);
        }

        /// <summary>
        /// 查询患者费用分类汇总信息,返回的是包含费用实体的数组,但是实体内并非所有的信息都赋值
        /// 调用时注意
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="balanceFlag">0,未结算，1已结算 ，ALL 全部</param>
        /// <returns>成功:费用信息 失败:null 没有找到数据:ArrayList.Count = 0</returns>
        public ArrayList QueryFeeItemListSum(string inpatientNO, DateTime beginTime, DateTime endTime, string balanceFlag)
        {
            //如果需要更改,请同时更改SQL语句,			
            ArrayList feeItemLists = new ArrayList();
            string sql = string.Empty;
            FeeItemList feeItemList = null;

            if (this.Sql.GetSql("Fee.Inpatient.GetPatientFeeItemsSum", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.Inpatient.GetPatientFeeItemsSum的SQL语句";

                return null;
            }
            if (balanceFlag == "" || balanceFlag == "All")
            {
                balanceFlag = "ALL";
            }
            try
            {
                if (this.ExecQuery(sql, inpatientNO, beginTime.ToString(), endTime.ToString(), balanceFlag) == -1)
                {
                    return null;
                }
                while (this.Reader.Read())
                {
                    feeItemList = new FeeItemList();

                    feeItemList.ID = inpatientNO;
                    feeItemList.Item.Name = this.Reader[0].ToString();
                    feeItemList.Item.MinFee.ID = this.Reader[1].ToString();
                    feeItemList.Item.Price = NConvert.ToDecimal(this.Reader[2].ToString());
                    feeItemList.Item.Qty = NConvert.ToDecimal(this.Reader[3].ToString());
                    feeItemList.Item.PriceUnit = this.Reader[4].ToString();
                    feeItemList.FT.TotCost = NConvert.ToDecimal(this.Reader[5].ToString());
                    feeItemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[6].ToString());
                    feeItemList.FT.PayCost = NConvert.ToDecimal(this.Reader[7].ToString());
                    feeItemList.FT.PubCost = NConvert.ToDecimal(this.Reader[8].ToString());
                    feeItemList.Item.Specs = this.Reader[9].ToString();
                    feeItemList.Item.ID = this.Reader[10].ToString();
                    feeItemList.Item.Memo = this.Reader[11].ToString();

                    feeItemLists.Add(feeItemList);
                }

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
        /// 获取结转费用各费用分项
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceState">结算状态</param>
        /// <returns>成功:结转费用各费用分项 失败:null</returns>
        public FeeInfo GetChangeCostTotal(string inpatientNO, string balanceState)
        {
            ArrayList temp = this.QueryFeeInfoGroups("Fee.GetChangeCostTotal.1", inpatientNO, balanceState);

            if (temp == null || temp.Count == 0)
            {
                return null;
            }

            return (FeeInfo)temp[0];
        }



        #endregion

        #region 封闭结帐状态开关

        /// <summary>
        /// 封闭结帐状态开关,当打结算清单后，更新患者的in_state = 'C', 所有地方不可以在继续录费用
        /// 当需要打开次状态时，必须患者为C状态，更新为'B'
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <param name="state">C 封 B 开(患者均为出院登记未结算状态</param>
        /// <returns>-1 失败 0 没有记录，1成功</returns>
        public int UpdateCloseAccount(string inpatientNO, string state)
        {
            return this.UpdateSingleTable("Fee.Inpatient.UpdateCloseAccount.Update", inpatientNO, state);
        }

        #region "帐开关"

        /// <summary>
        /// 关帐
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>0成功 -1 失败</returns>
        public int CloseAccount(string inpatientNO)
        {
            return this.UpdateSingleTable("Fee.Inpatient.CloseAccountNo.1", inpatientNO);
        }

        /// <summary>
        /// 开帐
        /// </summary>
        /// <param name="inpatientNO">患者流水号</param>
        /// <returns>0成功 -1 失败</returns>
        public int OpenAccount(string inpatientNO)
        {
            return this.UpdateSingleTable("Fee.Inpatient.OpenAccountNo.1", inpatientNO);
        }

        /// <summary>
        /// 查询患者帐开关
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>关帐标志1关帐0开帐</returns>
        public string GetStopAccount(string inpatientNO)
        {
            return this.ExecSqlReturnOne("Fee.Inpatient.QueryStopAccount.1", inpatientNO);
        }

        #endregion

        #endregion

        #region 更新结算信息

        /// <summary>
        ///  更新住院主表结算信息
        /// </summary>
        /// <param name="patient">患者基本信息</param>
        /// <param name="balanceTime">结算时间</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateInMainInfoBalanced(PatientInfo patient, DateTime balanceTime, int balanceNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.UpdateInMaininfoBalanced.1", patient.ID, balanceTime.ToString(), ft.PrepayCost.ToString(),
                ft.TransferPrepayCost.ToString(), ft.TotCost.ToString(), ft.OwnCost.ToString(), ft.PubCost.ToString(), ft.PayCost.ToString(),
                ft.RebateCost.ToString(), balanceNO.ToString(), patient.PVisit.InState.ID.ToString(), ft.TransferTotCost.ToString(), ft.TransferPrepayCost.ToString());
        }

        /// <summary>
        /// 获得新的结算序号
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <returns>成功:最新结算序号即本次结算操作序号 失败:null</returns>
        public string GetNewBalanceNO(string inpatientNO)
        {
            return this.ExecSqlReturnOne("Fee.Inpatient.GetNewBalanceNo.No1", inpatientNO);
        }

        /// <summary>
        /// 将转入预交金更新为结算状态
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据:0</returns>
        public int UpdateChangePrepayBalanced(string inpatientNO, int balanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateChangePrepayBalanced.1", inpatientNO, this.Operator.ID, this.GetSysDate(), balanceNO.ToString());
        }

        /// <summary>
        /// 出院结算将所有未结预交金更新为结算状态-------------- 暂时没有用到这个函数
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据:0</returns>
        public int UpdateAllPrepayBalanced(string inpatientNO, int balanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateAllPrepayBalanced.1", inpatientNO, this.Operator.ID, this.GetSysDate(), balanceNO.ToString());
        }

        /// <summary>
        /// 更新所有转入费用为结算
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据:0</returns>
        public int UpdateAllChangeCostBalanced(string inpatientNO, int balanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateAllChangeCostBalanced.1", inpatientNO, this.Operator.ID, this.GetSysDateTime(), balanceNO.ToString());
        }

        /// <summary>
        /// 将结算的费用汇总信息置为结算状态--出院结算全update使用
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="balanceTime">结算时间</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateFeeInfoBalanced(string inpatientNO, int balanceNO, DateTime balanceTime, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateFeeInfoBalanced.1", inpatientNO, balanceNO.ToString(), invoiceNO, this.Operator.ID, balanceTime.ToString());
        }

        /// <summary>
        /// 将结算的费用汇总信息置为结算状态-中途结算按时间和最小费用update
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="balanceTime">结算时间</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateFeeInfoBalanced(string inpatientNO, int balanceNO, DateTime balanceTime, string invoiceNO, DateTime beginTime, DateTime endTime, string minFeeCode)
        {
            return this.UpdateSingleTable("Fee.UpdateFeeInfoBalanced.2", inpatientNO, balanceNO.ToString(), invoiceNO, this.Operator.ID, balanceTime.ToString(),
                beginTime.ToString(), endTime.ToString(), minFeeCode);
        }

        /// <summary>
        /// 将结算的非药品费用明细信息置为结算状态--出院结算全update使用
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateFeeItemListBalanced(string inpatientNO, int balanceNO, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateItemListBalanced.1", inpatientNO, balanceNO.ToString(), invoiceNO);
        }

        /// <summary>
        /// 将结算的非药品费用明细信息置为结算状态--中途结算按时间和最小费用update
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateFeeItemListBalanced(string inpatientNO, int balanceNO, string invoiceNO, DateTime beginTime, DateTime endTime, string minFeeCode)
        {
            return this.UpdateSingleTable("Fee.UpdateItemListBalanced.2", inpatientNO, balanceNO.ToString(), invoiceNO, beginTime.ToString(), endTime.ToString(), minFeeCode);
        }

        /// <summary>
        /// 将结算的药品费用明细信息置为结算状态--出院结算全update使用
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateMedItemListBalanced(string inpatientNO, int balanceNO, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateMedItemListBalanced.1", inpatientNO, balanceNO.ToString(), invoiceNO);
        }

        /// <summary>
        /// 将结算的药品费用明细信息置为结算状态--中途结算按时间和最小费用update
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="minFeeCode">最小费用代码</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        public int UpdateMedItemListBalanced(string inpatientNO, int balanceNO, string invoiceNO, DateTime beginTime, DateTime endTime, string minFeeCode)
        {
            return this.UpdateSingleTable("Fee.UpdateMedItemListBalanced.2", inpatientNO, balanceNO.ToString(), invoiceNO, beginTime.ToString(), endTime.ToString(), minFeeCode);
        }

        #endregion

        #region 结算查询

        /// <summary>
        /// 通过住院流水号查询患者结算头表信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByInpatientNO(string inpatientNO)
        {
            return this.QueryBalances("Fee.GetBalanceHeadInfoByInpatientNo.Select.1", inpatientNO);
        }

        /// <summary>
        /// 根据住院流水号获取未作废的发票号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="flag">ALL 全部，O 出院结算，I 中途结算</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByInpatientNO(string inpatientNO, string flag)
        {
            string whereIndex = string.Empty;//Where条件

            if (flag == string.Empty || flag == "ALL")
            {
                whereIndex = "Fee.GetBalanceHeadInfoByInpatientNo.Select.2";
            }
            else if (flag == "0")
            {
                whereIndex = "Fee.GetBalanceHeadInfoByInpatientNo.Select.3";
            }
            else
            {
                whereIndex = "Fee.GetBalanceHeadInfoByInpatientNo.Select.4";
            }

            return this.QueryBalances(whereIndex, inpatientNO);
        }

        /// <summary>
        /// 通过发票号码检索结算头表结算信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByInvoiceNO(string invoiceNO)
        {
            return this.QueryBalances("GetBalanceInfoByInvoice.1", invoiceNO);
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByTime(DateTime beginTime, DateTime endTime)
        {
            return this.QueryBalances("GetBalanceInfoByDate.Where", beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isPositive">是否只显示正交易</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByTime(DateTime beginTime, DateTime endTime, bool isPositive)
        {
            if (isPositive)
            {
                return this.QueryBalances("GetBalanceInfoByDate.Where.1", beginTime.ToString(), endTime.ToString());
            }
            else
            {
                return this.QueryBalances("GetBalanceInfoByDate.Where", beginTime.ToString(), endTime.ToString());
            }
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isPositive">是否显示正交易</param>
        /// <param name="operCode">操作员</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByTime(DateTime beginTime, DateTime endTime, bool isPositive, string operCode)
        {
            string select = string.Empty;
            string whereMain = string.Empty;
            string whereSec = string.Empty;

            select = this.GetSqlForSelectAllInfoFromBalanceHead();

            if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref whereMain) == -1)
            {
                this.Err = "没有找到索引为:GetBalanceInfoByDate.Where的SQL语句";

                return null;
            }
            select = select + " " + whereMain;

            if (isPositive)
            {
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where.1", ref whereSec) == -1)
                {
                    this.Err = "没有找到索引为:GetBalanceInfoByDate.Where.1的SQL语句";

                    return null;
                }

                select = select + " " + whereSec;

            }

            if (operCode != "ALL")
            {
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where.2", ref whereSec) == -1)
                {
                    this.Err = "没有找到索引为:GetBalanceInfoByDate.Where.2的SQL语句";

                    return null;
                }

                select = select + " " + whereSec;
            }

            return this.QueryBalancesBySql(select, beginTime.ToString(), endTime.ToString(), operCode);
        }

        /// <summary>
        /// 操作员实收明细,不包含补打作废的数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="operCode">操作员 ALL 全部</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByTime(DateTime beginTime, DateTime endTime, string operCode)
        {

            string select = string.Empty;
            string whereMain = string.Empty;
            string whereSec = string.Empty;

            select = this.GetSqlForSelectAllInfoFromBalanceHead();

            if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref whereMain) == -1)
            {
                this.Err = "没有找到索引为:GetBalanceInfoByDate.Where的SQL语句";

                return null;
            }

            select = select + " " + whereMain;

            if (this.Sql.GetSql("GetBalanceInfoByDate.Where.NoReprint", ref whereSec) == -1)
            {
                this.Err = "没有找到索引为:GetBalanceInfoByDate.Where的SQL语句";

                return null;
            }

            select = select + " " + whereSec;

            if (operCode != "ALL")
            {
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where.2", ref whereSec) == -1)
                {
                    this.Err = "没有找到索引为:GetBalanceInfoByDate.Where.2的SQL语句";

                    return null;
                }

                select = select + " " + whereSec;
            }

            return this.QueryBalancesBySql(select, beginTime.ToString(), endTime.ToString());
        }

        /// <summary>
        /// 通过结算序号住院流水号检索结算头表发票组结算信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功: 患者结算头表信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalancesByBalanceNO(string inpatientNO, int balanceNO)
        {
            return this.QueryBalances("GetBalanceInfoBybalNo.1", balanceNO.ToString(), inpatientNO);
        }

        /// <summary>
        /// 通过发票号码检索结算明细结算信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功: 患者结算明细信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalanceListsByInvoiceNO(string invoiceNO)
        {
            return this.QueryBalanceLists("GetBalanceListInfoByInvoice.1", invoiceNO);
        }

        /// <summary>
        /// 根据发票号和结算序号获取结算明细信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功: 患者结算明细信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalanceListsByInvoiceNOAndBalanceNO(string invoiceNO, int balanceNO)
        {
            return this.QueryBalanceLists("GetBalanceListInfoByInvoiceAndbalance.Where", invoiceNO, balanceNO.ToString());
        }


        /// <summary>
        /// 根据住院流水号和结算序号获取结算明细信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功: 患者结算明细信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalanceListsByInpatientNOAndBalanceNO(string inpatientNO, int balanceNO)
        {
            return this.QueryBalanceLists("Fee.GetBalanceListByBalNo.1", inpatientNO, balanceNO.ToString());
        }

        /// <summary>
        /// 通过住院流水号，发票号根结算序号,获取结算明细信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功: 患者结算明细信息 失败:Null 没有查找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryBalanceListsByInpatientNOAndBalanceNO(string inpatientNO, string invoiceNO, int balanceNO)
        {
            return this.QueryBalanceLists("Fee.GetBalanceListByInvoiceAndBalNo.1", inpatientNO, invoiceNO, balanceNO.ToString());
        }

        /// <summary>
        /// 获取某此结算支付信息
        /// </summary>
        /// <param name="invoiceNO">发票号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <returns>成功:支付信息集合 失败: null</returns>
        public ArrayList QueryBalancePaysByInvoiceNOAndBalanceNO(string invoiceNO, int balanceNO)
        {
            return this.QueryBalancePays("Fee.GetBalancePayByInvoiceAndBalNo.1", invoiceNO, balanceNO.ToString());
        }

        /// <summary>
        /// 获取患者上次中途结算的时间，作为本次结算的开始时间,若没有进行过中结，取入院时间
        /// </summary>
        /// <param name="patient">患者实体</param>
        /// <returns>成功: 患者上次中途结算的时间，作为本次结算的开始时间,若没有进行过中结，取入院时间 失败: "-1"</returns>
        public string GetLastMidBalanceDate(PatientInfo patient)
        {
            return this.ExecSqlReturnOne("Fee.GetLastMidBalanceDate", patient.ID);
        }

        #endregion

        #region 结算召回

        /// <summary>
        /// 更新结算头表是否作废
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="wasteFlag">作废标记</param>
        /// <param name="balanceTime">结算时间</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateBalanceHeadWasteFlag(string inpatientNO, int balanceNO, string wasteFlag, DateTime balanceTime, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateBalanceHeadWasteFlag.1", inpatientNO, balanceNO.ToString(), wasteFlag, this.Operator.ID, balanceTime.ToString(), invoiceNO);
        }

        /// <summary>
        /// 结算召回更新主表
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateInmaininfoBalanceRecall(PatientInfo patient, int balanceNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.UpdateInmaininfoBalanceRecall.1", patient.ID, ft.PrepayCost.ToString(), ft.TotCost.ToString(),
                ft.OwnCost.ToString(), ft.PubCost.ToString(), ft.PayCost.ToString(), ft.RebateCost.ToString(), ft.TransferTotCost.ToString(),
                ft.TransferTotCost.ToString(), ft.TransferPrepayCost.ToString(), balanceNO.ToString(), patient.PVisit.InState.ID.ToString());
        }

        /// <summary>
        /// 更新非药品明细,为发票补打提供,只更新结算序号,和发票号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="orgInvoiceNO">原始发票号</param>
        /// <param name="newInvoiceNO">新发票号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateFeeItemListsBalanceNOForReprint(string inpatientNO, string orgInvoiceNO, string newInvoiceNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateFeeItemBalanceNoForReprint.1", inpatientNO, orgInvoiceNO, newInvoiceNO, newBalanceNO.ToString());
        }

        /// <summary>
        /// 更新药品明细,为发票补打提供,只更新结算序号,和发票号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="orgInvoiceNO">原始发票号</param>
        /// <param name="newInvoiceNO">新发票号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateMedItemListsBalanceNOForReprint(string inpatientNO, string orgInvoiceNO, string newInvoiceNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateMedItemBalanceNoForReprint.1", inpatientNO, orgInvoiceNO, newInvoiceNO, newBalanceNO.ToString());
        }

        /// <summary>
        /// 更新主表,为直接退费
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceCost">结算金额</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="balanceTime">结算时间</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateMainInfoForDirQuitFee(string inpatientNO, decimal balanceCost, int balanceNO, DateTime balanceTime)
        {
            return this.UpdateSingleTable("Fee.UpdateMainInfoForDirQuitFee.1", inpatientNO, balanceCost.ToString(), balanceNO.ToString(), balanceTime.ToString());
        }

        /// <summary>
        /// 结算召回更新患者非药品费用明细结算序号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="orgBalanceNO">原始结算序号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateFeeItemListsBalanceNO(string inpatientNO, int orgBalanceNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateFeeItemBalanceNo.1", inpatientNO, orgBalanceNO.ToString(), newBalanceNO.ToString());
        }

        /// <summary>
        /// 结算召回更新患者药品费用明细结算序号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="orgBalanceNO">原始结算序号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateMedItemListsBalanceNO(string inpatientNO, int orgBalanceNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateMedItemBalanceNo.1", inpatientNO, orgBalanceNO.ToString(), newBalanceNO.ToString());
        }

        /// <summary>
        /// 更新患者主表结算序号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateInMainInfoBalanceNO(string inpatientNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateInmaininfoBalanceNo.1", inpatientNO, newBalanceNO.ToString());
        }


        //{402C1A7D-6874-441e-B335-37B408C41C16}
        /// <summary>
        /// 在中途结算存在转押金时结算召回更新主表
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="ft">费用信息</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateInmaininfoMidBalanceRecall(PatientInfo patient, int balanceNO, FT ft)
        {
            return this.UpdateSingleTable("Fee.UpdateInmaininfoMidBalanceRecall.1", patient.ID, ft.PrepayCost.ToString(), ft.TotCost.ToString(),
                ft.OwnCost.ToString(), ft.PubCost.ToString(), ft.PayCost.ToString(), ft.RebateCost.ToString(), ft.TransferTotCost.ToString(),
                ft.TransferTotCost.ToString(), ft.TransferPrepayCost.ToString(), balanceNO.ToString(), patient.PVisit.InState.ID.ToString());
        }

        #endregion

        #region 公费日限额

        /// <summary>
        /// 更新公费患者公费药累计和公费药超标金额
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="cost">金额</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateBursaryTotMedFee(string inpatientNO, decimal cost)
        {
            return this.UpdateSingleTable("Fee.UpdateBursaryTotMedFee.1", inpatientNO, cost.ToString());
        }

        /// <summary>
        /// 更新日限额累计        
        /// 同时要更新日限额超标部分，只更新日限总额无意义
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="cost">金额</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateLimitTot(string inpatientNO, decimal cost)
        {
            return this.UpdateSingleTable("Fee.UpdateLimitTot.1", inpatientNO, cost.ToString());
        }

        /// <summary>
        /// 更新主表日限额和日限额累计和超标金额 ---用于日限额变更
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="cost">金额</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateInMainInfoForChangeDayLimit(string inpatientNO, decimal cost)
        {
            return this.UpdateSingleTable("Fee.UpdateInmaininfoForChangeDayLimit", inpatientNO, cost.ToString());
        }

        /// <summary>
        /// 更新患者超标金额--用于每天自费药调整更新
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="cost">日限额调整量</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateLimitOverTop(string inpatientNO, decimal cost)
        {
            return this.UpdateSingleTable("Fee.Inpatient.UpdateLimitOverTop", inpatientNO, cost.ToString());
        }

        /// <summary>
        /// 更新公费日限额,通过超标金额和总限额,用于数据倒入是老系统数据调整.
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="overtopCost">超标金额</param>
        /// <param name="dayLimitTotCost">日限额总额</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据: 0</returns>
        public int UpdateLimitOverTopAndTot(string inpatientNO, decimal overtopCost, decimal dayLimitTotCost)
        {
            return this.UpdateSingleTable("Fee.Inpatient.UpdateLimitOverTopAndTot", inpatientNO, overtopCost.ToString(), dayLimitTotCost.ToString());
        }


        #endregion

        #region 直接退费

        /// <summary>
        /// 获得药品明细(直接退费用)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功:药品明细 失败:null 没有找到数据ArrayList.Count = 0</returns>
        public ArrayList QueryMedItemListsForDirQuit(string inpatientNO, string invoiceNO)
        {
            string sql = string.Empty;//查询SQL语句

            if (this.Sql.GetSql("Fee.GetDirQuitFeeMedList.Select.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetDirQuitFeeMedList.Select.1的SQL语句";

                return null;
            }

            if (this.ExecQuery(sql, inpatientNO, invoiceNO) == -1)
            {
                return null;
            }

            try
            {
                ArrayList feeItemLists = new ArrayList();//费用明细集合
                FeeItemList feeItemList = null;//费用明细实体

                while (this.Reader.Read())
                {
                    feeItemList = new FeeItemList();

                    feeItemList.RecipeNO = this.Reader[0].ToString();
                    feeItemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());
                    feeItemList.Item.ID = this.Reader[2].ToString();
                    feeItemList.Item.Name = this.Reader[3].ToString();
                    feeItemList.Item.Specs = this.Reader[4].ToString();
                    feeItemList.Item.Price = NConvert.ToDecimal(this.Reader[5].ToString());
                    feeItemList.NoBackQty = NConvert.ToDecimal(this.Reader[6].ToString());
                    feeItemList.Item.PriceUnit = this.Reader[7].ToString();
                    feeItemList.FT.TotCost = NConvert.ToDecimal(this.Reader[8].ToString());
                    feeItemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[9].ToString());
                    feeItemList.FT.PayCost = NConvert.ToDecimal(this.Reader[10].ToString());
                    feeItemList.FT.PubCost = NConvert.ToDecimal(this.Reader[11].ToString());
                    feeItemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());
                    feeItemList.Memo = this.Reader[13].ToString();
                    feeItemList.Item.SpellCode = this.Reader[14].ToString();
                    feeItemList.Item.MinFee.ID = this.Reader[15].ToString();
                    feeItemList.Memo = this.Reader[16].ToString();

                    feeItemLists.Add(feeItemList);
                }

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
        /// 获得非药品明细(直接退费用)
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功:非药品明细 失败:null 没有找到数据ArrayList.Count = 0</returns>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        public ArrayList QueryFeeItemListsForDirQuit(string inpatientNO, string invoiceNO)
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.GetDirQuitFeeItemList.Select.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetDirQuitFeeItemList.Select.1的SQL语句";

                return null;
            }

            if (this.ExecQuery(sql, inpatientNO, invoiceNO) == -1)
            {
                return null;
            }

            try
            {
                ArrayList feeItemLists = new ArrayList();//费用明细集合
                FeeItemList feeItemList = null;//费用明细实体

                while (this.Reader.Read())
                {
                    feeItemList = new FeeItemList();

                    feeItemList.RecipeNO = this.Reader[0].ToString();
                    feeItemList.SequenceNO = NConvert.ToInt32(this.Reader[1].ToString());
                    feeItemList.Item.ID = this.Reader[2].ToString();
                    feeItemList.Item.Name = this.Reader[3].ToString();
                    feeItemList.Item.Price = NConvert.ToDecimal(this.Reader[4].ToString());
                    feeItemList.NoBackQty = NConvert.ToDecimal(this.Reader[5].ToString());
                    feeItemList.Item.PriceUnit = this.Reader[6].ToString();
                    feeItemList.FT.TotCost = NConvert.ToDecimal(this.Reader[7].ToString());
                    feeItemList.FT.OwnCost = NConvert.ToDecimal(this.Reader[8].ToString());
                    feeItemList.FT.PayCost = NConvert.ToDecimal(this.Reader[9].ToString());
                    feeItemList.FT.PubCost = NConvert.ToDecimal(this.Reader[10].ToString());
                    feeItemList.ExecOper.Dept.ID = this.Reader[11].ToString();
                    feeItemList.FeeOper.OperTime = NConvert.ToDateTime(this.Reader[12].ToString());
                    //feeItemList.Item.SpellCode = this.Reader[13].ToString();
                    feeItemList.Item.MinFee.ID = this.Reader[13].ToString();
                    feeItemList.Memo = this.Reader[14].ToString();
                    feeItemList.UpdateSequence = NConvert.ToInt32(this.Reader[15]);
                    feeItemLists.Add(feeItemList);
                }

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

        #endregion

        #region 减免信息

        /// <summary>
        /// 检索患者减免费用总额
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public decimal GetTotDerateCost(string inpatientNO)
        {
            return NConvert.ToDecimal(this.ExecSqlReturnOne("Fee.GetTotDerateCost.1", inpatientNO));
        }

        /// <summary>
        /// 更新减免信息为结算状态 Written By 王儒超
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">发票号</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int UpdateDerateBalanced(string inpatientNO, int balanceNO, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.InPatient.UpdateDerateBalance.1", inpatientNO, balanceNO.ToString(), invoiceNO);
        }

        /// <summary>
        /// 添加减免费用记录
        /// </summary>
        /// <returns></returns>
        public int AddDerateFee(Neusoft.HISFC.Models.Fee.DerateFee DerateFee)
        {
            return 0;
        }

        #endregion

        #region 担保信息

        /// <summary>
        /// 添加担保信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入或者更新到数据: 0</returns>
        public int InsertSurty(PatientInfo patient)
        {
            return this.UpdateSingleTable("Fee.Inpatient.InsertSurety", this.GetPatientSurtyParmas(patient));
        }


        /// <summary>
        /// 查找担保金额
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public string GetSurtyCost(string InpatientNo)
        {
            //string sqlStr = string.Empty;
            //if (this.Sql.GetSql("Fee.Inpatient.SelectSuretyCost", ref sqlStr) == -1)
            //{
            //    this.Err = "查找SQL：" + "Fee.Inpatient.SelectSuretyCost" + "语句失败！";
            //    return "-1";
            //}
            //try
            //{
            //    sqlStr = string.Format(sqlStr, InpatientNo);
            //}
            //catch (Exception ex)
            //{
            //    this.Err = ex.Message;
            //    return "-1";
            //}
            return this.ExecSqlReturnOne("Fee.Inpatient.SelectSuretyCost",InpatientNo);
        }


        //发生序号{0374EA05-782E-4609-9CDC-03236AB97906}

        private string QuerytSurtyInfoBase()
        {
            string strBaseSql = string.Empty;
            int returnValue = this.Sql.GetSql("Fee.Inpatient.SelectSurety.Base", ref strBaseSql);

            if (returnValue < 0)
            {
                this.Err = "查询索引为:[Fee.Inpatient.SelectSurety.Base]的sql语句失败";
                return null;
            }

            return strBaseSql;

           
        }

        /// <summary>
        /// 根据where条件查询信息{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        /// <param name="whereSqlIndex"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private ArrayList QuerySureTyDetailBySql(string whereSqlIndex, params string[] args)
        {
            string strBaseSql = this.QuerytSurtyInfoBase();

            if (strBaseSql == null)
            {
                return null;
            }
            string strWhereSql = string.Empty;
            int returnValue = this.Sql.GetSql(whereSqlIndex, ref strWhereSql);

            string strSql = string.Empty;
            if (returnValue < 0)
            {
                this.Err = "查询索引为:" + whereSqlIndex + "的sql语句失败";
                return null;
            }
            try
            {
                strSql = string.Format(strBaseSql + " " + strWhereSql, args);
            }
            catch (Exception ex)
            {

                this.Err = "格式化sql失败：" + ex.Message;
                return null;
            }

            return this.ExcuteBySql(strSql);


        }

        /// <summary>
        /// {0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList ExcuteBySql(string strSql)
        {
            int returnValue = this.ExecQuery(strSql);
            if (returnValue < 0)
            {
                this.Err = "查询担保信息出错!" + this.Err;
                return null;
            }
            ArrayList al = new ArrayList();
           
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = new PatientInfo();
                p.ID = this.Reader[0].ToString();
                p.Surety.HappenNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());
                p.PVisit.PatientLocation.Dept.ID = this.Reader[2].ToString();
                p.Surety.SuretyPerson.ID = this.Reader[3].ToString();
                p.Surety.SuretyPerson.Name = this.Reader[4].ToString();
                p.Surety.SuretyCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                p.Surety.SuretyType.ID = this.Reader[6].ToString();
                p.Surety.ApplyPerson.ID = this.Reader[7].ToString();
                p.Surety.ApplyPerson.Name = this.Reader[8].ToString();
                p.Surety.Memo = this.Reader[9].ToString();
                p.Surety.Oper.ID = this.Reader[10].ToString();
                p.Surety.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
                p.Surety.PayType.ID = this.Reader[12].ToString();
                p.Surety.State = this.Reader[13].ToString();
                p.Surety.Bank.ID = this.Reader[14].ToString();
                p.Surety.Bank.Account = this.Reader[15].ToString();
                p.Surety.Bank.WorkName = this.Reader[16].ToString();
                p.Surety.Bank.InvoiceNO = this.Reader[17].ToString();//小票或者pos机流水
                p.Surety.InvoiceNO = this.Reader[18].ToString();
                p.Surety.OldInvoiceNO = this.Reader[19].ToString();
                al.Add(p);

                
 
            }
            return al;

        }

        /// <summary>
        /// 根据住院号号查询担保信息{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public ArrayList QuerySuretyDetailByInpatientNO(string inpatientNO)
        {
            return this.QuerySureTyDetailBySql("Fee.Inpatient.SelectSurety.ByInpatientNO", inpatientNO);
        }

        /// <summary>
        /// 更新有效标记{0374EA05-782E-4609-9CDC-03236AB97906}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="happenNO"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public int UpdateSurtyState(string inpatientNO,string happenNO,string state)
        {
            return this.UpdateSingleTable("Fee.Inpatient.UpdateSurety.State", state,inpatientNO,happenNO);
        }

        #endregion

        #region 结算类别

        /// <summary>
        /// 获得结算类别
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <returns>成功: 结算类别 失败:null</returns>
        public PayKind GetPayKind(string inpatientNO)
        {
            PayKind payKind = new PayKind();

            payKind.ID = this.ExecSqlReturnOne("Fee.Inpatient.GetPayKind.1", inpatientNO);
            if (payKind.ID == null || payKind.ID == string.Empty)
            {
                this.Err = "获得结算类别编码出错!";

                return null;
            }

            payKind.Name = this.ExecSqlReturnOne("Fee.Inpatient.GetPayKind.2", payKind.ID);
            if (payKind.Name == null || payKind.Name == string.Empty)
            {
                this.Err = "获得结算类别名称出错!";

                return null;
            }

            return payKind;
        }

        #endregion

        #region 结转

        /// <summary>
        /// 处理结转欠费部分费用插入结转表
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="feeInfo">费用信息</param>
        /// <returns>成功: 1 失败 : -1</returns>
        public int InsertCarryFowardFee(PatientInfo patient, FeeInfo feeInfo)
        {
            return this.UpdateSingleTable("AddPatientCarryFowardFee.1", this.GetCarryFowardFeeParams(patient, feeInfo));
        }

        #endregion

        #region 财务组

        /// <summary>
        /// 提取人员财务组编码和财务组名称
        /// </summary>
        /// <param name="operCode">人员编码</param>
        /// <returns>成功:人员财务组编码和财务组名称 失败:null</returns>
        public NeuObject GetFinGroupInfoByOperCode(string operCode)
        {
            string sql = string.Empty;

            NeuObject group = new NeuObject();
            if (this.Sql.GetSql("GetOperGrpId.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为:GetOperGrpId.1的SQL语句";

                return null;
            }

            if (this.ExecQuery(sql, operCode) == -1)
            {
                return null;
            }
            try
            {
                while (this.Reader.Read())
                {
                    group.ID = this.Reader[0].ToString();
                    group.Name = this.Reader[1].ToString();
                }

                this.Reader.Close();

                return group;
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

        #endregion

        #region 合同单位

        /// <summary>
        /// 获得枚举日合同单位项目的优惠比例
        /// </summary>
        /// <param name="itemList">费用明细实体</param>
        /// <returns>成功:优惠比例 失败:null</returns>
        public string GetRebateRateEnuDate(FeeItemList itemList)
        {
            return this.ExecSqlReturnOne("Fee.GetRebateRateEnuDate.1", itemList.Patient.Pact.ID, itemList.Item.ID, this.GetSysDate("YYYY/MM/DD"));
        }

        /// <summary>
        /// 将时间转换成星期几---中文
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>成功:星期? 失败: null</returns>
        public string TransferDateTimetoWeekDay(DateTime time)
        {
            return this.ExecSqlReturnOne("Fee.TransferDateTimetoWeekDay.1", time.ToString());
        }

        /// <summary>
        /// 将时间转换成星期几---中文 重载 默认系统当前时间
        /// </summary>
        /// <returns>成功:星期? 失败: null</returns>
        public string TransferDateTimetoWeekDay()
        {
            return this.TransferDateTimetoWeekDay(this.GetDateTimeFromSysDateTime());
        }

        /// <summary>
        ///  获得枚举星期合同单位项目的优惠比例
        /// </summary>
        /// <param name="itemList">费用明细实体</param>
        /// <returns>成功:枚举星期合同单位项目的优惠比例 失败:null</returns>
        public string GetRebateRateEnuWeek(FeeItemList itemList)
        {
            return this.ExecSqlReturnOne("Fee.GetRebateRateEnuWeek.1", itemList.Patient.Pact.ID, itemList.Item.ID, this.TransferDateTimetoWeekDay());
        }

        /// <summary>
        /// 获得时间范围合同单位项目的优惠比例
        /// </summary>
        /// <param name="itemList">费用明细实体</param>
        /// <returns>成功: 时间范围合同单位项目的优惠比例 失败: null</returns>
        public string GetRebateRateBetweenDate(FeeItemList itemList)
        {
            return this.ExecSqlReturnOne("Fee.GetRebateBetweenDate.1", itemList.Patient.Pact.ID, itemList.Item.ID, this.GetSysDateTime());
        }

        #endregion

        #region 其他应用

        /// <summary>
        /// 获取发票大类项目---暂时为知情权使用
        /// </summary>
        /// <param name="reportCode">报表代码</param>
        /// <returns>成功:发票大类项目 失败:null 没有找到数据:ArrayList.Count = 0</returns>
        public ArrayList QueryFeeStatsByReportCode(string reportCode)
        {
            string sql = string.Empty;

            ArrayList temp = new ArrayList();
            if (this.Sql.GetSql("Fee.GetStatCodeAndNameByReportCode", ref sql) == -1)
            {
                this.Err = "没有找到索引为:Fee.GetStatCodeAndNameByReportCode的SQL语句";

                return null;
            }

            if (this.ExecQuery(sql, reportCode) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    NeuObject obj = new NeuObject();

                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();

                    temp.Add(obj);
                }

                this.Reader.Close();

                return temp;
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
        /// 常数表检索通过id检索name
        /// </summary>
        /// <param name="type">常熟类型</param>
        /// <param name="code">常熟编码</param>
        /// <returns>成功:常数值 失败: null</returns>
        public string GetComDictionaryNameByID(string type, string code)
        {
            return this.ExecSqlReturnOne("Fee.GetComDictionaryNameById", type, code);
        }

        #endregion

        #region 直接结算

        /// <summary>
        /// 获得临时住院号码
        /// </summary>
        /// <param name="patientNO">住院号</param>
        /// <returns>成功:临时住院号码 失败: null</returns>
        public string GetTempPatientNO(string patientNO)
        {
            return this.ExecSqlReturnOne("Fee.GetTempPatientNo.1", patientNO);
        }

        #endregion

        #region 退费新增

        /// <summary>
        /// 根据医嘱号，和组合号查询复合项目{F4912030-EF65-4099-880A-8A1792A3B449}
        /// </summary>
        /// <param name="moOrder">医嘱号</param>
        /// <param name="packageCode">复合项目编码</param>
        /// <returns>同一收费复合项目的处方号，和处方流水号集合</returns>
        public ArrayList QueryRecipesByMoOrder(string moOrder, string packageCode) 
        {
            string sql = string.Empty;

            if (this.Sql.GetSql("Fee.Inpatient.QueryRecipesByMoOrder.Query.1", ref sql) == -1) 
            {
                this.Err = "没有找到索引为:Fee.Inpatient.QueryRecipesByMoOrder.Query.1的SQl语句";

                return null;
            }

            sql = string.Format(sql, moOrder, packageCode);

            if (this.ExecQuery(sql) == -1) 
            {
                return null;
            }
            ArrayList recipeNOs = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();

            try
            {
                //循环读取数据
                while (this.Reader.Read())
                {
                    obj = new NeuObject();

                    obj.ID = this.Reader[0].ToString();
                    obj.Name = this.Reader[1].ToString();

                    recipeNOs.Add(obj);
                }

                this.Reader.Close();

                return recipeNOs;
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
        }//{F4912030-EF65-4099-880A-8A1792A3B449}结束

        #endregion

        #endregion

        #region 废弃方法


        /// <summary>
        /// 常数表检索通过type检索name and id up by lisy   
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        [Obsolete("作废", true)]
        public ArrayList GetComDictionaryName(string Type)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.GetComDictionaryName", ref strSql) == -1) return null;
            try
            {
                //传入0类型1id
                strSql = string.Format(strSql, Type);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                ArrayList al = new ArrayList();
                while (Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();

                    obj.Name = Reader[0].ToString();
                    obj.ID = Reader[1].ToString();

                    al.Add(obj);
                }
                Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
        }
        /// <summary>
        /// 常数表检索通过id检索name   通过name检索id等有时间再写,任务太紧
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        [Obsolete("作废 GetComDictionaryNameByID", true)]
        public string GetComDictionaryNameById(string Type, string Code)
        {
            string strSql = "";

            if (this.Sql.GetSql("Fee.GetComDictionaryNameById", ref strSql) == -1) return null;
            try
            {
                //传入0类型1id
                strSql = string.Format(strSql, Type, Code);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
            return this.ExecSqlReturnOne(strSql);
        }


        /// <summary>
        /// 获取发票大类项目---暂时为知情权使用
        /// </summary>
        /// <param name="ReportCode"></param>
        /// <returns></returns>
        [Obsolete("作废,QueryFeeStatsByReportCode", true)]
        public ArrayList GetStatCodeAndNameByReportCode(string ReportCode)
        {
            string strSql = "";
            ArrayList al = new ArrayList();
            if (this.Sql.GetSql("Fee.GetStatCodeAndNameByReportCode", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, ReportCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            while (this.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject Obj = new NeuObject();
                try
                {
                    Obj.ID = this.Reader[0].ToString();
                    Obj.Name = this.Reader[1].ToString();
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.ErrCode = ex.Message;
                    return null;
                }

                al.Add(Obj);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得临时住院号码
        /// </summary>
        [Obsolete("作废,GetTempPatientNO", true)]
        public string GetTempPatientNo(string parm)
        {
            string pNo = "";
            string strSql = "";
            if (this.Sql.GetSql("Fee.GetTempPatientNo.1", ref strSql) == -1) return null;
            strSql = System.String.Format(strSql, parm);
            pNo = this.ExecSqlReturnOne(strSql);
            //			pNo="LS"+pNo.PadLeft(8,'0');
            return pNo;
        }

        /// <summary>
        /// 返回dataset
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废", true)]
        public DataSet GetDataSetBalanceHeadInfo()
        {
            DataSet dts = new DataSet();
            string strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
            this.ExecQuery(strSql, ref dts);
            //			this.r
            return dts;
        }


        /// <summary>
        /// 提取人员财务组编码和财务组名称
        /// </summary>
        /// <param name="OperId">人员id</param>
        /// <returns>财务组实体类id编码name名称</returns>
        [Obsolete("作废,GetFinGroupInfoByOperCode()", true)]
        public NeuObject GetOperGrp(string OperId)
        {
            string strSql = "";
            //			string strDataSet = "";
            NeuObject OperGrp = new NeuObject();
            if (this.Sql.GetSql("GetOperGrpId.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, OperId);
            }
            catch (Exception ex)
            {
                this.ErrCode = "Fee.Inpateint.GetOperGrp" + ex.Message;
                this.Err = ex.Message;
                return null;
            }
            this.ExecQuery(strSql);
            if (this.Reader == null) return null;
            while (this.Reader.Read())
            {
                try
                {
                    OperGrp.ID = this.Reader[0].ToString();
                    OperGrp.Name = this.Reader[1].ToString();
                }
                catch (Exception ex)
                {
                    this.Err = "查询人员财务组赋值时候错误!" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
            return OperGrp;
        }


        /// <summary>
        /// 处理结转欠费部分费用插入结转表
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="FeeInfo">费用信息</param>
        /// <returns>0成功-1失败</returns>
        [Obsolete("作废,InsertCarryFowardFee()", true)]
        public int AddPatientCarryFowardFee(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo)
        {
            string strSql = "";
            if (this.Sql.GetSql("AddPatientCarryFowardFee.1", ref strSql) == -1) return -1;
            //0 处方号1最小费用代码2 交易类型,1正交易，2反交易 3住院流水号 4姓名 5结算类别 6合同单位 7在院科室代码8护士站代码
            //9开立科室代码 10执行科室代码11扣库科室代码12开立医师代码13欠费金额14划价人
            //15划价日期16计费人17计费日期18结算人代码19结算时间20结算序号21结算标志 0:未结算；1:已结算 2:已结转
            //22审核序号23婴儿标记

            try
            {
                strSql = string.Format(strSql, FeeInfo.RecipeNO, FeeInfo.Item.MinFee.ID, FeeInfo.TransType, PatientInfo.ID, PatientInfo.Name,
                    PatientInfo.Pact.PayKind.ID, PatientInfo.Pact.ID, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.Dept.ID, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.NurseCell.ID, 
                    FeeInfo.StockOper.Dept.ID,
                    FeeInfo.ExecOper.Dept.ID, FeeInfo.StockOper.Dept.ID, FeeInfo.RecipeOper.ID, FeeInfo.FT.TotCost.ToString(), FeeInfo.ChargeOper.ID,
                    FeeInfo.ChargeOper.OperTime.ToString(), FeeInfo.FeeOper.ID, FeeInfo.FeeOper.OperTime.ToString(), FeeInfo.BalanceOper.ID, FeeInfo.BalanceOper.OperTime.ToString(),
                    FeeInfo.BalanceNO.ToString(), FeeInfo.BalanceState, FeeInfo.AuditingNO, System.Convert.ToInt16(FeeInfo.IsBaby).ToString()
                    );
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 获得所有患者身份类别 Written By Wangrc
        /// 返回PayKind数组
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废", true)]
        public ArrayList GetPayKindList()
        {
            string strSql = "";
            ArrayList al = new ArrayList();
            if (this.Sql.GetSql("Fee.Inpatient.GetPayKindList.1", ref strSql) != 0) return null;
            this.ExecQuery(strSql);
            //0身份类别 1身份类别名称

            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Base.PayKind payKind = new Neusoft.HISFC.Models.Base.PayKind();
                try
                {
                    payKind.ID = this.Reader[0].ToString();
                    payKind.Name = this.Reader[1].ToString();
                }


                catch (Exception ex)
                {
                    this.Err = "查询患者身份类别赋值时候出错！" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                }
                al.Add(payKind);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 添加担保信息
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <returns></returns>
        [Obsolete("作废,使用InsertSurty", true)]
        public int AddPatientSurty(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo)
        {
            #region
            //添加担保信息
            //AddPatientSurty.1
            //0住院流水号2科室代码3担保人代码4担保人姓名5担保金额6担保类型 7审批人代码8审批人姓名
            //10操作员11操作日期
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("AddPatientSurty.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, PatientInfo.ID, PatientInfo.PVisit.PatientLocation.Dept.ID,
                    PatientInfo.Caution.ID, PatientInfo.Caution.Name, PatientInfo.Caution.Money.ToString(),
                    PatientInfo.Caution.Type, PatientInfo.Caution.AuditingOper.ID, PatientInfo.Caution.AuditingOper.Name,
                    this.Operator.ID, this.GetSysDateTime());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


        /// <summary>
        /// 添加结算实付记录
        /// AddBalancePay.1
        /// </summary>
        /// <param name="BalancePay">实付信息</param>
        /// <returns>0成功-1失败</returns>
        [Obsolete("作废,使用InsertBalancePay", true)]
        public int AddBalancePay(Neusoft.HISFC.Models.Fee.Inpatient.BalancePay BalancePay)
        {
            string strSql = "";
            if (this.Sql.GetSql("AddBalancePay.1", ref strSql) == -1) return -1;
            //0发票号码1交易类型2交易种类0 预交款 1 结算款 3支付方式 4金额5张数6开户银行7开户银行名称8开户银行帐号
            //10返回或补收标志11结算人代码12结算日期9结算序号
            try
            {
                strSql = string.Format(strSql, BalancePay.Invoice.ID, BalancePay.TransType, BalancePay.TransKind, BalancePay.PayType.ID,
                    BalancePay.FT.TotCost.ToString(), BalancePay.Qty.ToString(), BalancePay.Bank.ID, BalancePay.Bank.Name, BalancePay.Bank.Account,
                    BalancePay.BalanceNo,
                    BalancePay.RetrunOrSupplyFlag, BalancePay.BalanceOper.ID, BalancePay.BalanceOper.OperTime.ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="Balance"></param>
        /// <returns></returns>
        [Obsolete("作废,使用InsertBalance", true)]
        public int AddBalanceHead(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.Balance Balance)
        {
            return 0;
            //return this.AddBalanceHead(PatientInfo,Balance,null);
        }


        /// <summary>
        /// 添加结算记录 Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="Balance">结算信息</param>
        /// <param name="IInsuranceBalance">医保结算信息</param>
        /// <returns></returns>
        [Obsolete("作废", true)]
        public int AddBalanceHead(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.Balance Balance, Neusoft.HISFC.Models.Insurance.IInsuraceBalace IInsuranceBalance)
        {
            #region
            //添加患者结算记录
            //AddBalanceHead.1
            //传入参数：0发票号码 结转时为流水号1交易类型,1正交易，2反交易2住院流水号3结算序号4结算类别5合同代码6预交金额
            //7费用金额8自费金额9自付金额10公费金额11优惠金额12减免金额14补收金额15返还金额16转押金17起始日期
            //18终止日期19结算类型20结算人代码21结算时间
            //22财务组代码23打印次数24本次账户支付25公务员补助26大额补助27老红军28本次现金支付29审核序号13作废标记30主发票标记31剩余保险最终结算标记32患者姓名
            //33结算员科室
            //传出参数：无
            #endregion
            string strSql = "";
            decimal AcountPay = 0;
            decimal CashPay = 0;
            decimal LargePay = 0;
            decimal MiltrayPay = 0;
            decimal OfficePay = 0;
            if (IInsuranceBalance == null)
            {
                AcountPay = 0;
                CashPay = 0;
                LargePay = 0;
                MiltrayPay = 0;
                OfficePay = 0;
            }
            else
            {
                AcountPay = IInsuranceBalance.AcountPay;
                CashPay = IInsuranceBalance.CashPay;
                LargePay = IInsuranceBalance.LargePay;
                MiltrayPay = IInsuranceBalance.MiltrayPay;
                OfficePay = IInsuranceBalance.OfficePay;
            }
            string PactCode = "";
            string PayKindCode = "";
            if (Balance.Patient.Pact.ID == null || Balance.Patient.Pact.ID.Trim() == "")
            {
                PactCode = PatientInfo.Pact.ID;
            }
            else
            {
                PactCode = Balance.Patient.Pact.ID;
            }
            if (Balance.Patient.Pact.PayKind.ID == null || Balance.Patient.Pact.PayKind.ID.Trim() == "")
            {
                PayKindCode = PatientInfo.Pact.PayKind.ID;
            }
            else
            {
                PayKindCode = Balance.Patient.Pact.PayKind.ID;
            }

            string BalanceOperDeptCode = ""; //结算员科室
            //结算员科室
            if (Balance.Oper.ID == null || Balance.Oper.ID == "")
            {
                BalanceOperDeptCode = "";
            }
            else
            {
                if (Balance.Oper.Dept.ID == null || Balance.Oper.Dept.ID == "")
                {

                    BalanceOperDeptCode = this.GetDeptByEmplId(Balance.Oper.ID);
                }
                else
                {
                    BalanceOperDeptCode = Balance.Oper.Dept.ID;
                }
            }


            if (this.Sql.GetSql("AddBalanceHead.1", ref strSql) == -1) return -1;
            try
            {

                strSql = string.Format(strSql, Balance.Invoice.ID, Balance.TransType, PatientInfo.ID, Balance.ID, PatientInfo.Pact.PayKind.ID, PatientInfo.Pact.ID,
                    Balance.FT.PrepayCost.ToString(), Balance.FT.TotCost.ToString(), Balance.FT.OwnCost.ToString(), Balance.FT.PayCost.ToString(),
                    Balance.FT.PubCost.ToString(), Balance.FT.RebateCost.ToString(), Balance.FT.DerateCost.ToString(), ((int)Balance.CancelType).ToString(),
                    Balance.FT.SupplyCost.ToString(), Balance.FT.ReturnCost.ToString(), Balance.FT.TransferPrepayCost.ToString(),
                    Balance.BeginTime.ToString(), Balance.EndTime.ToString(), Balance.BalanceType.ID.ToString(), Balance.Oper.ID, Balance.Oper.OperTime.ToString(),
                    Balance.FinanceGroup.ID, Balance.PrintTimes.ToString(), AcountPay.ToString(), OfficePay.ToString(), LargePay.ToString(), MiltrayPay.ToString(),
                    CashPay.ToString(), Balance.AuditingNO, NConvert.ToInt32(Balance.IsMainInvoice), NConvert.ToInt32(Balance.IsLastBalance).ToString(),
                    PatientInfo.Name,
                    //结算员科室
                    BalanceOperDeptCode,
                    //结算调整公费日限额超标金额
                    Balance.FT.AdjustOvertopCost.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }


            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 添加结算明细记录 Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="BalanceList">结算明细记录信息</param>
        /// <returns>0 成功 -1 失败</returns>
        [Obsolete("作废,用InsertBalanceList()", true)]
        public int AddBalanceList(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.BalanceList BalanceList)
        {
            #region
            //添加患者结算明细记录
            //AddBalanceList.1
            //传入参数：0发票号码1交易类型2住院流水号3姓名4结算类别5合同单位6在院科室代码7统计大类8统计大类名称9打印顺序号
            //10费用金额11自费金额12自付金额13公费金额14优惠金额15为了凑数16结算人代码17结算时间18结算类型19结算序号
            //20婴儿标志21审核序号22结算员科室
            //传出参数：无
            #endregion
            string strSql = "";
            string PactCode = "";
            string PayKindCode = "";
            if (((Balance)BalanceList.BalanceBase).Patient.Pact.ID == null || ((Balance)BalanceList.BalanceBase).Patient.Pact.ID.Trim() == "")
            {
                PactCode = PatientInfo.Pact.ID;
            }
            else
            {
                PactCode = ((Balance)BalanceList.BalanceBase).Patient.Pact.ID;
            }
            if (((Balance)BalanceList.BalanceBase).Patient.Pact.PayKind.ID == null || ((Balance)BalanceList.BalanceBase).Patient.Pact.PayKind.ID.Trim() == "")
            {
                PayKindCode = PatientInfo.Pact.PayKind.ID;
            }
            else
            {
                PayKindCode = ((Balance)BalanceList.BalanceBase).Patient.Pact.PayKind.ID;
            }

            string BalanceOperDeptCode = ""; //结算员科室
            //结算员科室
            if (((Balance)BalanceList.BalanceBase).Oper.ID == null || ((Balance)BalanceList.BalanceBase).Oper.ID == "")
            {
                BalanceOperDeptCode = "";
            }
            else
            {
                if (((Balance)BalanceList.BalanceBase).Oper.Dept.ID == null || ((Balance)BalanceList.BalanceBase).Oper.Dept.ID == "")
                {

                    BalanceOperDeptCode = this.GetDeptByEmplId(((Balance)BalanceList.BalanceBase).Oper.ID);
                }
                else
                {
                    BalanceOperDeptCode = ((Balance)BalanceList.BalanceBase).Oper.Dept.ID;
                }
            }


            if (this.Sql.GetSql("AddBalanceList.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, ((Balance)BalanceList.BalanceBase).Invoice.ID,
                    ((int)((Balance)BalanceList.BalanceBase).TransType).ToString(),
                    PatientInfo.ID,
                    PatientInfo.Name, PayKindCode,
                    PactCode,
                    PatientInfo.PVisit.PatientLocation.Dept.ID,
                    BalanceList.FeeCodeStat.ID,
                    BalanceList.FeeCodeStat.Name,
                    ((Balance)BalanceList.BalanceBase).User01,
                    ((Balance)BalanceList.BalanceBase).FT.TotCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).FT.OwnCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).FT.PayCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).FT.PubCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).FT.RebateCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).FT.OwnCost.ToString(),
                    ((Balance)BalanceList.BalanceBase).Oper.ID, ((Balance)BalanceList.BalanceBase).Oper.OperTime.ToString(), ((Balance)BalanceList.BalanceBase).BalanceType.ID.ToString(), ((Balance)BalanceList.BalanceBase).ID,
                    BalanceList.User02,
                    ((Balance)BalanceList.BalanceBase).AuditingNO,
                    //收费员科室
                    BalanceOperDeptCode);

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }


            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 查询患者费用分类汇总信息,返回的是包含费用实体的数组,但是实体内并非所有的信息都赋值
        /// 调用时注意
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="balanceFlag">0,未结算，1已结算 ，ALL 全部</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListSum()", true)]
        public ArrayList GetPatientFeeItemsSum(string InpatientNo, DateTime begin, DateTime end, string balanceFlag)
        {
            //如果需要更改,请同时更改SQL语句,			
            ArrayList al = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.GetPatientFeeItemsSum", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql  Fee.Inpatient.GetPatientFeeItemsSum";
                return null;
            }
            if (balanceFlag == "" || balanceFlag == "All")
            {
                balanceFlag = "ALL";
            }
            try
            {
                strSql = string.Format(strSql, InpatientNo, begin.ToString(), end.ToString(), balanceFlag);
                if (this.ExecQuery(strSql) == -1) return null;
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList list = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    list.ID = InpatientNo;
                    list.Item.Name = Reader[0].ToString();
                    list.Item.MinFee.ID = Reader[1].ToString();
                    list.Item.Price = NConvert.ToDecimal(Reader[2].ToString());
                    list.Item.Qty = NConvert.ToDecimal(this.Reader[3].ToString());
                    list.Item.PriceUnit = this.Reader[4].ToString();
                    list.FT.TotCost = NConvert.ToDecimal(this.Reader[5].ToString());
                    list.FT.OwnCost = NConvert.ToDecimal(this.Reader[6].ToString());
                    list.FT.PayCost = NConvert.ToDecimal(this.Reader[7].ToString());
                    list.FT.PubCost = NConvert.ToDecimal(this.Reader[8].ToString());
                    list.Item.Specs = this.Reader[9].ToString();
                    list.Item.ID = this.Reader[10].ToString();
                    list.Item.Memo = this.Reader[11].ToString();//保存原来项目的编码 Add by Wangyu

                    al.Add(list);
                }
                return al;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 更新患者费用信息-更新FeeInfo表信息 Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="FeeInfo">费用信息</param>
        /// <returns><br>0 成功</br><br>-1 失败</br></returns>
        [Obsolete("作废,用InsertAndUpdateFeeInfo()", true)]
        public int UpdateAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.FeeInfo FeeInfo)
        {
            #region "接口说明"
            //更新患者费用汇总表的费用信息 
            //Fee.Inpatient.AddPatientAccount.2
            //传入参数：0 处方号1最小费用代码2 交易类型,1正交易，2反交易 3住院流水号 4姓名 5结算类别 6合同单位 7在院科室代码8护士站代码
            //9开立科室代码 10执行科室代码11扣库科室代码12开立医师代码13费用金额14自费金额15自付金额16公费金额17优惠金额18划价人
            //19划价日期20计费人21计费日期22结算人代码23结算时间24结算发票号25结算序号26结算标志 0:未结算；1:已结算 2:已结转
            //27审核序号28婴儿标记
            //传出参数：无
            #endregion
            string strSql = "";
            //解决插负记录和收费取值问题
            string PactId = "";
            if (FeeInfo.Patient.Pact.ID == null || FeeInfo.Patient.Pact.ID == "")
            {
                PactId = PatientInfo.Pact.ID;
            }
            else
            {
                PactId = FeeInfo.Patient.Pact.ID;
            }
            string PayKind = "";
            if (FeeInfo.Patient.Pact.PayKind.ID == null || FeeInfo.Patient.Pact.PayKind.ID == "")
            {
                PayKind = PatientInfo.Pact.PayKind.ID;
            }
            else
            {
                PayKind = FeeInfo.Patient.Pact.PayKind.ID;
            }
            string FeeOperDeptCode = ""; //收费员科室
            //操作员科室
            if (FeeInfo.FeeOper.ID == null || FeeInfo.FeeOper.ID == "")
            {
                FeeOperDeptCode = "";
            }
            else
            {
                if (FeeInfo.FeeOper.Dept.ID == null || FeeInfo.FeeOper.Dept.ID == "")
                {
                    FeeOperDeptCode = this.GetDeptByEmplId(FeeInfo.FeeOper.ID);
                }
                else
                {
                    FeeOperDeptCode = FeeInfo.FeeOper.Dept.ID;
                }
            }
            int IntResult = 0;
            if (this.Sql.GetSql("Fee.Inpatient.AddPatientAccount.2", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, FeeInfo.RecipeNO, FeeInfo.Item.MinFee.ID, FeeInfo.TransType, PatientInfo.ID, PatientInfo.Name,
                    PayKind, PactId, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.Dept.ID, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.NurseCell.ID, FeeInfo.RecipeOper.Dept.ID, FeeInfo.ExecOper.Dept.ID,
                    FeeInfo.StockOper.Dept.ID, FeeInfo.RecipeOper.ID, FeeInfo.FT.TotCost.ToString(), FeeInfo.FT.OwnCost.ToString(),
                    FeeInfo.FT.PayCost.ToString(), FeeInfo.FT.PubCost.ToString(), FeeInfo.FT.RebateCost.ToString(), FeeInfo.ChargeOper.ID,
                    FeeInfo.ChargeOper.OperTime.ToString(), FeeInfo.FeeOper.ID, FeeInfo.FeeOper.OperTime.ToString(), FeeInfo.BalanceOper.ID, FeeInfo.BalanceOper.OperTime.ToString(),
                    FeeInfo.Invoice.ID, FeeInfo.BalanceNO.ToString(), FeeInfo.BalanceState, FeeInfo.AuditingNO,
                    System.Convert.ToInt16(FeeInfo.IsBaby).ToString(),
                    FeeOperDeptCode,			//操作员科室
                    FeeInfo.ExtFlag,			//扩展标记
                    FeeInfo.ExtFlag1,			//扩展标记1
                    FeeInfo.ExtFlag2,			//扩展标记2
                    FeeInfo.ExtCode,			//扩展编码
                    FeeInfo.ExecOper.ID,		//扩展操作人员
                    FeeInfo.ExecOper.OperTime.ToString()				//扩展日期
                    );
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }

            IntResult = this.ExecNoQuery(strSql);
            if (IntResult == -1 && this.DBErrCode == 1)
            {
                if (this.Sql.GetSql("Fee.Inpatient.AddPatientAccount.3", ref strSql) == 1) return -1;
                try
                {
                    #region "接口说明"
                    //更新患者费用汇总表的费用信息 
                    //Fee.Inpatient.AddPatientAccount.3
                    //传入参数：0  tot_cost,1 own_cost,2 pay_cost,3 pub_cost
                    //4 处方号,5最小费用,6.执行科室7优惠费用
                    //传出参数：无
                    #endregion
                    strSql = string.Format(strSql, FeeInfo.FT.TotCost.ToString(), FeeInfo.FT.OwnCost.ToString(), FeeInfo.FT.PayCost.ToString(),
                        FeeInfo.FT.PubCost.ToString(), FeeInfo.RecipeNO, FeeInfo.Item.MinFee.ID, FeeInfo.ExecOper.Dept.ID, FeeInfo.FT.RebateCost.ToString());
                }
                catch (Exception e)
                {
                    this.Err = e.Message;
                    this.ErrCode = e.Message;
                    return -1;
                }
                IntResult = this.ExecNoQuery(strSql);

            }
            return IntResult;
        }

        /// <summary>
        /// 添加feeinfo单条insert数据
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="FeeInfo"></param>
        /// <returns></returns>
        [Obsolete("作废,用InsertFeeInfo()", true)]
        public int AddFeeInfoRecord(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo)
        {
            string strSql = "";
            //解决插负记录和收费取值问题
            string PactId = "";
            if (FeeInfo.Patient.Pact.ID == null || FeeInfo.Patient.Pact.ID.Trim() == "")
            {
                PactId = PatientInfo.Pact.ID;
            }
            else
            {
                PactId = FeeInfo.Patient.Pact.ID;
            }
            string FeeOperDeptCode = ""; //收费员科室
            //操作员科室
            if (FeeInfo.FeeOper.ID == null || FeeInfo.FeeOper.ID == "")
            {
                FeeOperDeptCode = "";
            }
            else
            {
                if (FeeInfo.FeeOper.Dept.ID == null || FeeInfo.FeeOper.Dept.ID == "")
                {
                    FeeOperDeptCode = this.GetDeptByEmplId(FeeInfo.FeeOper.ID);
                }
                else
                {
                    FeeOperDeptCode = FeeInfo.FeeOper.Dept.ID;
                }
            }



            if (this.Sql.GetSql("Fee.Inpatient.AddPatientAccount.2", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, FeeInfo.RecipeNO, FeeInfo.Item.MinFee.ID, FeeInfo.TransType, PatientInfo.ID, PatientInfo.Name,
                    FeeInfo.Patient.Pact.PayKind.ID, PactId, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.Dept.ID, ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeInfo.Patient).PVisit.PatientLocation.NurseCell.ID, FeeInfo.RecipeOper.Dept.ID, FeeInfo.ExecOper.Dept.ID,
                    FeeInfo.StockOper.Dept.ID, FeeInfo.RecipeOper.ID, FeeInfo.FT.TotCost.ToString(), FeeInfo.FT.OwnCost.ToString(),
                    FeeInfo.FT.PayCost.ToString(), FeeInfo.FT.PubCost.ToString(), FeeInfo.FT.RebateCost.ToString(), FeeInfo.ChargeOper.ID,
                    FeeInfo.ChargeOper.OperTime.ToString(), FeeInfo.FeeOper.ID, FeeInfo.FeeOper.OperTime.ToString(), FeeInfo.BalanceOper.ID, FeeInfo.BalanceOper.OperTime.ToString(),
                    FeeInfo.Invoice.ID, FeeInfo.BalanceNO.ToString(), FeeInfo.BalanceState, FeeInfo.AuditingNO,
                    System.Convert.ToInt16(FeeInfo.IsBaby).ToString(),
                    FeeOperDeptCode,			//操作员科室
                    FeeInfo.ExtFlag,			//扩展标记
                    FeeInfo.ExtFlag1,			//扩展标记1
                    FeeInfo.ExtFlag2,			//扩展标记2
                    FeeInfo.ExtCode,			//扩展编码
                    FeeInfo.ExecOper.ID,		//扩展操作人员
                    FeeInfo.ExecOper.OperTime.ToString());			//扩展日期
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新非药品明细可退数量
        /// </summary>
        /// <param name="NoteNo"></param>
        /// <param name="SequenceNO"></param>
        /// <param name="BackNum">本次退的数量</param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateNoBackQtyForUndrug()", true)]
        public int UpdateNoBackNumForUndrug(string NoteNo, decimal SequenceNO, decimal BackNum, string BalanceState)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateNoBackNumForUndrug.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, NoteNo, SequenceNO, BackNum, BalanceState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新药品明细可退数量
        /// </summary>
        /// <param name="NoteNo"></param>
        /// <param name="SequenceNO"></param>
        /// <param name="BackNum"></param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateNoBackQtyForDrug()", true)]
        public int UpdateNoBackNumForDrug(string NoteNo, int SequenceNO, decimal BackNum, string BalanceState)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateNoBackNumForDrug.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, NoteNo, SequenceNO, BackNum, BalanceState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新患者费用信息-主表的
        /// </summary>
        /// 		/// <param name="InpatientNo">患者信息</param>
        /// <param name="FT">费用信息</param>
        /// <returns>0失败(没更新) >0 成功 -1 错误</returns>
        [Obsolete("作废,用UpdateInMainInfoFee()", true)]
        public int UpdateAccount(string InpatientNo, Models.Base.FT FT)
        {
            #region "接口说明"
            //更新患者主表的费用信息 
            //Fee.InPatient.UpdateAccount.10
            //传入参数：0 inpatientNo 住院流水号,1 OwnCost,2 pub_cost,3 Pay_cost
            //			 4 tot_cost5 优惠金额
            //传出参数：无
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.UpdateAccount.10", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, FT.OwnCost.ToString(), FT.PubCost.ToString(),
                    FT.PayCost.ToString(), FT.TotCost.ToString(), FT.RebateCost.ToString());
            }
            catch
            {
                this.Err = "传入参数错误！Fee.InPatient.UpdateAccount.10";
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新费用信息为结算状态 Written By 王儒超--------------暂时没用,考虑效率问题采用直接全部update
        /// </summary>
        /// <param name="FeeInfo">费用信息</param>
        /// <param name= "Balance">结算信息</param>>
        /// <returns></returns>
        [Obsolete("作废,用UpdateFeeInfoBalanced()", true)]
        public int UpdateAccoutBalanced(Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo, Neusoft.HISFC.Models.Fee.Inpatient.Balance Balance)
        {
            #region
            //更新费用信息为结算状态
            //UpdateAccoutBalanced.1
            //传入参数：0  处方号,1 执行科室,2最小费用 3结算序号4操作员5结算时间
            //传出参数：无
            #endregion

            string strSql = "";
            if (this.Sql.GetSql("UpdateAccoutBalanced.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, FeeInfo.RecipeNO, FeeInfo.ExecOper.Dept.ID, FeeInfo.Item.MinFee.ID, Balance.ID,
                    Balance.Oper.ID, Balance.Oper.OperTime.ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 划价后更新收费标记收费人收费时间相关信息
        /// </summary>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateChargeItemToFee()", true)]
        public int UpdateChargeItem(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList)
        {

            string strSql = "";
            //操作员科室
            string FeeOperDeptCode = "";
            if (ItemList.FeeOper.ID == null || ItemList.FeeOper.ID == "")
            {
                FeeOperDeptCode = "";
            }
            else
            {
                if (ItemList.FeeOper.Dept.ID == null || ItemList.FeeOper.Dept.ID == "")
                {

                    FeeOperDeptCode = this.GetDeptByEmplId(ItemList.FeeOper.ID);
                }
                else
                {
                    FeeOperDeptCode = ItemList.FeeOper.Dept.ID;
                }
            }

            //0 处方号 1处方内流水号2计费人3计费时间4发药状态5收费员科室

            if (ItemList.Item.IsPharmacy)
            {
                if (this.Sql.GetSql("UpdateDrugItem.2", ref strSql) == -1) return -1;
            }
            else
            {
                if (this.Sql.GetSql("UpdateUndrugItem.2", ref strSql) == -1) return -1;
            }
            try
            {
                strSql = string.Format(strSql, ItemList.RecipeNO, ItemList.SequenceNO.ToString(),
                    ItemList.FeeOper.ID, ItemList.FeeOper.OperTime.ToString(), ((int)ItemList.PayType).ToString(),
                    //收费员科室
                    FeeOperDeptCode
                    );
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="MedItemList"></param>
        /// <returns></returns>
        [Obsolete("作废,用InsertMedItemList()", true)]
        public int AddPatientMedAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.FeeItemList MedItemList)
        {
            return this.InsertMedItemList(PatientInfo, MedItemList, null);
        }

        /// <summary>
        /// 添加患者 项目费用-更新药品费用明细表信息  Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="MedItemList">药品费用项目信息</param>
        /// <param name="Insurance"></param>
        /// <returns>0 成功 -1 失败</returns>
        [Obsolete("作废,用InsertMedItemList()", true)]
        public int AddPatientMedAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.FeeItemList MedItemList, Neusoft.HISFC.Models.Insurance.IInsurence Insurance)
        {
            string strSql = "";
            string ApprNo = "";
            string CenterCode = "";
            bool IsEmergency = false;

            string FeeOperDeptCode = ""; //收费员科室
            //操作员科室
            if (MedItemList.FeeOper.ID == null || MedItemList.FeeOper.ID == "")
            {
                FeeOperDeptCode = "";
            }
            else
            {
                if (MedItemList.FeeOper.Dept.ID == null || MedItemList.FeeOper.Dept.ID == "")
                {
                    FeeOperDeptCode = this.GetDeptByEmplId(MedItemList.FeeOper.ID);
                }
                else
                {
                    FeeOperDeptCode = MedItemList.FeeOper.Dept.ID;
                }
            }


            if (Insurance == null)
            {
                ApprNo = null;
                CenterCode = null;
                IsEmergency = false;
            }
            else
            {
                ApprNo = Insurance.ApprNo;
                CenterCode = Insurance.CenterCode;
                IsEmergency = Insurance.IsEmergency;
            }
            #region
            //添加患者药品费用明细表的费用信息
            //0 处方号1处方内流水号2 交易类型,1正交易，2反交易 3住院流水号 4姓名 5结算类别 6合同单位 7在院科室代码8护士站代码
            //9开立科室代码 10执行科室代码11取药科室代码12开立医师代码13药品编码14最小费用代码15医疗中心项目代码16药品名称17规格
            //18药品类别19药品性质20自制标识21单价22当前单位23包装数24数量25付数26费用金额27自费金额28自付金额29公费金额30优惠金额
            //31发药单流水号32扣库流水号33发药状态（0 划价 2摆药 1批费）34是否婴儿用药 0 不是 1 是35急诊抢救标志36出院带药标记 0 否 1 是
            //37结算发票号38结算序号39审批号40划价人41划价日期42发药人43发药日期 44计费时间45审核序号46医嘱流水号47医嘱执行单流水号
            //48计费人49药品可退数量50结算状态51收费比例 52 收费员科室
            #endregion
            if (this.Sql.GetSql("AddPatientAccount.2", ref strSql) == -1) return -1;
            if (MedItemList.Item.GetType() != typeof(Neusoft.HISFC.Models.Pharmacy.Item)) return -1;
            Neusoft.HISFC.Models.Pharmacy.Item Obj = (Neusoft.HISFC.Models.Pharmacy.Item)MedItemList.Item;
            try
            {


                //解决插负记录和收费取值问题
                string PactId = "";
                if (MedItemList.Patient.Pact.ID == null || MedItemList.Patient.Pact.ID.Trim() == "")
                {
                    PactId = PatientInfo.Pact.ID;
                }
                else
                {
                    PactId = MedItemList.Patient.Pact.ID;
                }
                string PayKindId = "";
                if (MedItemList.Patient.Pact.PayKind.ID == null || MedItemList.Patient.Pact.PayKind.ID.Trim() == "")
                {
                    PayKindId = PatientInfo.Pact.PayKind.ID;
                }
                else
                {
                    PayKindId = MedItemList.Patient.Pact.PayKind.ID;
                }
                //解决目前全部都按照最小费用收取
                if (MedItemList.Item.PriceUnit == "")
                {
                    MedItemList.Item.PriceUnit = Obj.MinUnit;
                }
                string[] s = 
				{
					MedItemList.RecipeNO,
					MedItemList.SequenceNO.ToString(),
					((int)MedItemList.TransType).ToString(),
					PatientInfo.ID,
					PatientInfo.Name,
					PayKindId,
					PactId,
					((Neusoft.HISFC.Models.RADT.PatientInfo)MedItemList.Patient).PVisit.PatientLocation.Dept.ID,
					((Neusoft.HISFC.Models.RADT.PatientInfo)MedItemList.Patient).PVisit.PatientLocation.NurseCell.ID,
					MedItemList.RecipeOper.Dept.ID,//10
					MedItemList.ExecOper.Dept.ID,
					MedItemList.StockOper.Dept.ID,
					MedItemList.RecipeOper.ID,
					MedItemList.Item.ID,
					MedItemList.Item.MinFee.ID,
					CenterCode,
					MedItemList.Item.Name,
					MedItemList.Item.Specs,
					Obj.Type.ID,
					Obj.Quality.ID.ToString(),
					NConvert.ToInt32(Obj.Product.IsSelfMade).ToString(),//20
					MedItemList.Item.Price.ToString(),MedItemList.Item.PriceUnit,MedItemList.Item.PackQty.ToString(),MedItemList.Item.Qty.ToString(),
					MedItemList.Days.ToString(),MedItemList.FT.TotCost.ToString(),MedItemList.FT.OwnCost.ToString(),
					MedItemList.FT.PayCost.ToString(),MedItemList.FT.PubCost.ToString(),MedItemList.FT.RebateCost.ToString(),
					MedItemList.SendSequence.ToString(),MedItemList.UpdateSequence.ToString(),
					((int)MedItemList.PayType).ToString(),System.Convert.ToInt16(MedItemList.IsBaby).ToString(),
					System.Convert.ToInt16(IsEmergency).ToString(),((Models.Order.Inpatient.Order)MedItemList.Order).OrderType.ID,
					MedItemList.Invoice.ID,MedItemList.BalanceNO.ToString(),ApprNo,MedItemList.ChargeOper.ID,
					MedItemList.ChargeOper.OperTime.ToString(),MedItemList.ExecOper.ID,MedItemList.ExecOper.OperTime.ToString(),MedItemList.FeeOper.OperTime.ToString(),
					MedItemList.AuditingNO,MedItemList.Order.ID,MedItemList.Order.ID,MedItemList.FeeOper.ID,MedItemList.NoBackQty.ToString(),
					MedItemList.BalanceState,MedItemList.FTRate.OwnRate.ToString(),	//51 收费比率
					FeeOperDeptCode,		//52 收费员科室
					MedItemList.Item.SpecialFlag,	//53 扩展标记
					MedItemList.Item.SpecialFlag1,	//54 扩展标记1
					MedItemList.Item.SpecialFlag2	//55 扩展标记2 MedItemList.ExtCode,	//56 扩展编码MedItemList.ExtOperCode,//57 扩展操作员编码MedItemList.ExecOper.OperTime.ToString().ToString() //58 扩展日期
					
				};

                strSql = string.Format(strSql, s);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="FeeItemList"></param>
        /// <returns></returns>
        [Obsolete("作废,用InsertFeeItemList()", true)]
        public int AddPatientAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.FeeItemList FeeItemList)
        {
            return this.InsertFeeItemList(PatientInfo, FeeItemList, null);
        }


        /// <summary>
        /// 添加患者 项目费用-更新非药品费用明细表信息  Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="FeeItemList">交的费用项目信息</param>
        ///  <param name="Insurence">医保的项目相关信息</param>
        /// <returns><br>0 成功</br><br>-1 失败</br></returns>
        [Obsolete("作废,用InsertFeeItemList()", true)]
        public int AddPatientAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.FeeItemList FeeItemList, Neusoft.HISFC.Models.Insurance.IInsurence Insurence)
        {

            string strSql = "";
            string ApprNo = "";  //审批号
            string CenterCode = ""; //中心代码
            bool IsEmergency = false; //急诊标记
            string FeeOperDeptCode = ""; //收费员科室
            //操作员科室
            if (FeeItemList.FeeOper.ID == null || FeeItemList.FeeOper.ID == "")
            {
                FeeOperDeptCode = "";
            }
            else
            {
                if (FeeItemList.FeeOper.Dept.ID == null || FeeItemList.FeeOper.Dept.ID == "")
                {

                    FeeOperDeptCode = this.GetDeptByEmplId(FeeItemList.FeeOper.Dept.ID);
                }
                else
                {
                    FeeOperDeptCode = FeeItemList.FeeOper.Dept.ID;
                }
            }


            if (Insurence == null)
            {
                ApprNo = null;
                CenterCode = null;
                IsEmergency = false;
            }
            else
            {
                ApprNo = Insurence.ApprNo;
                CenterCode = Insurence.CenterCode;
                IsEmergency = Insurence.IsEmergency;
            };

            //			Neusoft.HISFC.Models.Fee.Item.Undrug Obj = (Neusoft.HISFC.Models.Fee.Item.Undrug)FeeItemList.Item;
            if (this.Sql.GetSql("AddPatientAccount.1", ref strSql) == -1) return -1;
            try
            {
                //解决插负记录和收费取值问题
                string PactId = "";

                if (FeeItemList.Patient.Pact.ID == null || FeeItemList.Patient.Pact.ID.Trim() == "")
                {
                    PactId = PatientInfo.Pact.ID;
                }
                else
                {
                    PactId = FeeItemList.Patient.Pact.ID;
                }
                string PayKindId = "";
                if (FeeItemList.Patient.Pact.PayKind.ID == null || FeeItemList.Patient.Pact.PayKind.ID.Trim() == "")
                {
                    PayKindId = PatientInfo.Pact.PayKind.ID;
                }
                else
                {
                    PayKindId = FeeItemList.Patient.Pact.PayKind.ID;
                }
                string[] s = {
								 #region 
								 //添加患者非药品费用明细表的费用信息 
								 //AddPatientAccount.1
								 //传入参数：0 处方号1最小费用代码2 交易类型,1正交易，2反交易 3住院流水号 4姓名 5结算类别 6合同单位 7在院科室代码8护士站代码
								 //9开立科室代码 10执行科室代码11扣库科室代码12开立医师代码13项目代码14中心代码15单价16数量17组套代码18组套名称
								 //19费用金额20自费金额21自付金额22公费金额23优惠金额25发放状态26是否婴儿用27急诊抢救标志28出院带疗标记
								 //29结算发票号30结算序号31审批号32划价人33划价日期34设备号35计费人36计费日期38审核序号39医嘱流水号40医嘱执行单流水号
								 //42处方内流水号43执行人44执行日期45项目名称24当前单位37出库单流水号41扣库流水号46可退数量47结算状态48收费比例 49 收费员科室
								 //传出参数：无
								 #endregion
								 // 0 处方号
								 FeeItemList.RecipeNO,
								 //1最小费用代码
								 FeeItemList.Item.MinFee.ID,
								 //交易类型,1正交易，2反交易
								 ((int)FeeItemList.TransType).ToString(),
								 //住院流水号
								 PatientInfo.ID,
								 //姓名
								 PatientInfo.Name,
								 //结算类别
								 PayKindId,
								 //合同单位
								 PactId,
								 //在院科室代码
								 ((Neusoft.HISFC.Models.RADT.PatientInfo)FeeItemList.Patient).PVisit.PatientLocation.Dept.ID,
								 "",FeeItemList.RecipeOper.Dept.ID,FeeItemList.ExecOper.Dept.ID,FeeItemList.StockOper.Dept.ID,
								 FeeItemList.RecipeOper.ID,FeeItemList.Item.ID,CenterCode,FeeItemList.Item.Price.ToString(),FeeItemList.Item.Qty.ToString(),
								 FeeItemList.UndrugComb.ID,FeeItemList.UndrugComb.Name,FeeItemList.FT.TotCost.ToString(),FeeItemList.FT.OwnCost.ToString(),
								 FeeItemList.FT.PayCost.ToString(),FeeItemList.FT.PubCost.ToString(),FeeItemList.FT.RebateCost.ToString(),
								 FeeItemList.Item.PriceUnit,
								 ((int)FeeItemList.PayType).ToString(),System.Convert.ToInt16(FeeItemList.IsBaby).ToString(),
								 System.Convert.ToInt16(IsEmergency).ToString(),((Neusoft.HISFC.Models.Order.Inpatient.Order)FeeItemList.Order).OrderType.ID,
								 FeeItemList.Invoice.ID,FeeItemList.BalanceNO.ToString(),ApprNo,FeeItemList.ChargeOper.ID,
								 FeeItemList.ChargeOper.OperTime.ToString(),FeeItemList.MachineNO,FeeItemList.FeeOper.ID,FeeItemList.FeeOper.OperTime.ToString(),
								 FeeItemList.SendSequence.ToString(),
								 FeeItemList.AuditingNO,FeeItemList.Order.ID,FeeItemList.Order.ID,FeeItemList.UpdateSequence.ToString(),FeeItemList.SequenceNO.ToString(),
								 FeeItemList.ExecOper.ID,FeeItemList.ExecOper.OperTime.ToString(),FeeItemList.Item.Name,FeeItemList.NoBackQty.ToString(),FeeItemList.BalanceState,
								 FeeItemList.FTRate.OwnRate.ToString(),
								 FeeOperDeptCode,			//49 收费员科室
								 FeeItemList.Item.SpecialFlag,		//50 扩展标记
								 FeeItemList.Item.SpecialFlag1,		//51 扩展标记1
								 FeeItemList.Item.SpecialFlag2,		//52 扩展标记2
								 FeeItemList.User01,		//53 扩展编码
								 FeeItemList.User02,	//54 扩展操作员编码
								 FeeItemList.User03 //55 扩展日期
							 };

                strSql = string.Format(strSql, s);

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }

        /// <summary>
        /// 获得非药品明细
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsForDirQuit()", true)]
        public ArrayList GetDirQuitFeeItemList(string inpatientNo, string invoiceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.GetDirQuitFeeItemList.Select.1", ref strSql) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "没有找到Fee.GetDirQuitFeeItemList.Select.1";
                this.WriteErr();
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                ArrayList al = new ArrayList();
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                    obj.RecipeNO = Reader[0].ToString();
                    obj.SequenceNO = NConvert.ToInt32(Reader[1].ToString());
                    obj.Item.ID = Reader[2].ToString();
                    obj.Item.Name = Reader[3].ToString();
                    obj.Item.Price = NConvert.ToDecimal(Reader[4].ToString());
                    obj.NoBackQty = NConvert.ToDecimal(Reader[5].ToString());
                    obj.Item.PriceUnit = Reader[6].ToString();
                    obj.FT.TotCost = NConvert.ToDecimal(Reader[7].ToString());
                    obj.FT.OwnCost = NConvert.ToDecimal(Reader[8].ToString());
                    obj.FT.PayCost = NConvert.ToDecimal(Reader[9].ToString());
                    obj.FT.PubCost = NConvert.ToDecimal(Reader[10].ToString());
                    obj.ExecOper.Dept.ID = Reader[11].ToString();
                    if (!Reader.IsDBNull(12))
                        obj.FeeOper.OperTime = NConvert.ToDateTime(Reader[12].ToString());
                    obj.Item.SpellCode = Reader[13].ToString();
                    obj.Item.MinFee.ID = Reader[14].ToString();
                    obj.Memo = Reader[15].ToString();
                    al.Add(obj);
                }
                Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
        }

        /// <summary>
        /// 获得药品明细
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListsForDirQuit()", true)]
        public ArrayList GetDirQuitFeeMedList(string inpatientNo, string invoiceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.GetDirQuitFeeMedList.Select.1", ref strSql) == -1)
            {
                this.ErrCode = "-1";
                this.Err = "没有找到Fee.GetDirQuitFeeMedList.Select.1";
                this.WriteErr();
                return null;
            }
            try
            {
                strSql = string.Format(strSql, inpatientNo, invoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
            this.ExecQuery(strSql);
            try
            {
                ArrayList al = new ArrayList();
                while (Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList obj = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                    obj.RecipeNO = Reader[0].ToString();
                    obj.SequenceNO = NConvert.ToInt32(Reader[1].ToString());
                    obj.Item.ID = Reader[2].ToString();
                    obj.Item.Name = Reader[3].ToString();
                    obj.Item.Specs = Reader[4].ToString();
                    obj.Item.Price = NConvert.ToDecimal(Reader[5].ToString());
                    obj.NoBackQty = NConvert.ToDecimal(Reader[6].ToString());
                    obj.Item.PriceUnit = Reader[7].ToString();
                    obj.FT.TotCost = NConvert.ToDecimal(Reader[8].ToString());
                    obj.FT.OwnCost = NConvert.ToDecimal(Reader[9].ToString());
                    obj.FT.PayCost = NConvert.ToDecimal(Reader[10].ToString());
                    obj.FT.PubCost = NConvert.ToDecimal(Reader[11].ToString());

                    if (!Reader.IsDBNull(12))
                        obj.FeeOper.OperTime = NConvert.ToDateTime(Reader[12].ToString());
                    obj.Memo = Reader[13].ToString();
                    obj.Item.SpellCode = Reader[14].ToString();
                    obj.Item.MinFee.ID = Reader[15].ToString();
                    obj.Memo = Reader[16].ToString();
                    al.Add(obj);
                }
                Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                if (Reader.IsClosed == false)
                {
                    Reader.Close();
                }
                this.ErrCode = "-1";
                this.Err = ex.Message;
                this.WriteErr();
                return null;
            }
        }

        /// <summary>
        /// 更新主表日限额和日限额累计和超标金额 ---用于日限额变更
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="difCost"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateInMainInfoForChangeDayLimit()", true)]
        public int UpdateInmaininfoForChangeDayLimit(string InpatientNo, decimal difCost)
        {
            string strSql = "";
            // 0 住院流水号1变更后和变更前金额的差值
            if (this.Sql.GetSql("Fee.UpdateInmaininfoForChangeDayLimit", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, difCost.ToString());
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);

        }

        /// <summary>
        /// 更新患者主表结算序号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="NewBalNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateInMainInfoBalanceNO()", true)]
        public int UpdateInmaininfoBalanceNo(string InpatientNo, string NewBalNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateInmaininfoBalanceNo.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, NewBalNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 结算召回更新患者药品费用明细结算序号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="OldbalNo"></param>
        /// <param name="NewbalNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateMedItemListsBalanceNO()", true)]
        public int UpdateMedItemBalanceNo(string InpatientNo, string OldbalNo, string NewbalNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateMedItemBalanceNo.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, OldbalNo, NewbalNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 结算召回更新患者非药品费用明细结算序号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="OldbalNo"></param>
        /// <param name="NewbalNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateFeeItemListsBalanceNO()", true)]
        public int UpdateFeeItemBalanceNo(string InpatientNo, string OldbalNo, string NewbalNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateFeeItemBalanceNo.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, OldbalNo, NewbalNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        ///  更新药品明细,为发票补打提供,只更新结算序号,和发票号
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="oldInvoiceNo"></param>
        /// <param name="newBalNo"></param>
        /// <param name="newInvoiceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateMedItemListsBalanceNOForReprint()", true)]
        public int UpdateMedItemBalanceNoForReprint(string inpatientNo, string oldInvoiceNo, string newBalNo, string newInvoiceNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateMedItemBalanceNoForReprint.1", ref strSql) == -1)
                return -1;
            try
            {
                strSql = string.Format(strSql, inpatientNo, oldInvoiceNo, newInvoiceNo, newBalNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 更新非药品明细,为发票补打提供,只更新结算序号,和发票号
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="orgInvoiceNO">原始发票号</param>
        /// <param name="newInvoiceNO">新发票号</param>
        /// <param name="newBalanceNO">新结算序号</param>
        /// <returns>成功:1 失败: -1 没有更新到数据: 0</returns>
        [Obsolete("作废,用UpdateFeeItemListsBalanceNOForReprint()", true)]
        public int UpdateFeeItemBalanceNoForReprint(string inpatientNO, string orgInvoiceNO, string newInvoiceNO, int newBalanceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateFeeItemBalanceNoForReprint.1", inpatientNO, orgInvoiceNO, newInvoiceNO, newBalanceNO.ToString());
        }

        /// <summary>
        /// 获取某此结算balancepay信息
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="BalNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancePaysByInvoiceNOAndBalanceNO()", true)]
        public ArrayList GetBalancePayByInvoiceAndBalNo(string InvoiceNo, string BalNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectBalancePay();
            if (this.Sql.GetSql("Fee.GetBalancePayByInvoiceAndBalNo.1", ref strSql2) == -1) return null;
            strSql1 += strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InvoiceNo, BalNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryBalancePaysBySql(strSql1);
        }

        /// <summary>
        /// 通过发票号根结算序号,查找balanceList的对应信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="invoiceNo"></param>
        /// <param name="balanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalanceListsByInpatientNOAndBalanceNO()", true)]
        public ArrayList GetBalanceListByInvoiceAndBalNo(string inpatientNo, string invoiceNo, string balanceNo)
        {
            string strSql1 = "";
            string strSql2 = "";

            strSql1 = this.GetSqlForSelectAllInfoFromBalanceList();
            if (this.Sql.GetSql("Fee.GetBalanceListByInvoiceAndBalNo.1", ref strSql2) == -1)
                return null;
            strSql1 += strSql2;
            try
            {
                strSql1 = string.Format(strSql1, inpatientNo, invoiceNo, balanceNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }

            return this.QueryBalanceListsBySql(strSql1);
        }

        /// <summary>
        /// 获取某此结算balancelist信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalanceListsByInpatientNOAndBalanceNO()", true)]
        public ArrayList GetBalanceListByBalNo(string InpatientNo, string BalanceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllInfoFromBalanceList();
            if (this.Sql.GetSql("Fee.GetBalanceListByBalNo.1", ref strSql2) == -1) return null;
            strSql1 += strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, BalanceNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryBalanceListsBySql(strSql1);
        }

        /// <summary>
        /// 获取某此结算的预交金记录
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryPrepaysByInpatientNOAndBalanceNO()", true)]
        public ArrayList GetPrepayByBalNo(string InpatientNo, string BalanceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllPrepay();
            if (this.Sql.GetSql("Fee.GetPrepayByBalNo.1", ref strSql2) == -1) return null;
            strSql1 += strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, BalanceNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryPrepaysBySql(strSql1);
        }

        /// <summary>
        /// 获取某此结算的feeinfo信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosByInpatientNOAndBalanceNO()", true)]
        public ArrayList GetFeeInfoBalanceByBalNo(string InpatientNo, string BalanceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectFeeInfo();
            if (this.Sql.GetSql("Fee.GetFeeInfoBalanceByBalNo.1", ref strSql2) == -1) return null;
            strSql1 += strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, BalanceNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeInfosBySql(strSql1);
        }

        /// <summary>
        /// 根据发票号和结算序号获取
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="balanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalanceListsByInvoiceNOAndBalanceNO()", true)]
        public ArrayList GetBalanceListByInvoiceAndBalance(string invoiceNo, string balanceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllInfoFromBalanceList();
            if (this.Sql.GetSql("GetBalanceListInfoByInvoiceAndbalance.Where", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, invoiceNo, balanceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalanceListsBySql(strSql1);

        }

        /// <summary>
        /// 通过发票号码检索结算明细结算信息
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalanceListsByInvoiceNO()", true)]
        public ArrayList GetBalanceListInfoByInvoice(string invoiceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllInfoFromBalanceList();
            if (this.Sql.GetSql("GetBalanceListInfoByInvoice.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, invoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalanceListsBySql(strSql1);

        }

        /// <summary>
        /// 通过结算序号住院流水号检索结算头表发票组结算信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="balNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByBalanceNO()", true)]
        public ArrayList GetBalanceInfoBybalNo(string InpatientNo, int balNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllInfoFromBalanceHead();
            if (this.Sql.GetSql("GetBalanceInfoBybalNo.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, balNo.ToString(), InpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalancesBySql(strSql1);
        }

        /// <summary>
        /// 操作员实收明细,不包含补打作废的数据
        /// </summary>
        /// <param name="Begin">开始时间</param>
        /// <param name="End">结束时间</param>
        /// <param name="Oper">操作员 ALL 全部</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByTime()", true)]
        public ArrayList GetBalanceInfoDetailByDate(string Begin, string End, string Oper)
        {
            string strSql = "";
            string strSql1 = "", strSql2 = "", strSql3 = "";
            try
            {
                strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref strSql1) == -1) return null;

                strSql1 = string.Format(strSql1, Begin, End);
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where.NoReprint", ref strSql2) == -1) return null;
                strSql = strSql + " " + strSql2;
                if (Oper != "ALL")
                {
                    if (this.Sql.GetSql("GetBalanceInfoByDate.Where.2", ref strSql3) == -1) return null;
                    strSql3 = string.Format(strSql3, Oper);
                    strSql = strSql + " " + strSql3;
                }

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return this.QueryBalancesBySql(strSql);
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="Begin">开始时间</param>
        /// <param name="End">结束时间</param>
        /// <param name="Tag">是否显示正交易</param>
        /// <param name="Oper">操作员</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByTime()", true)]
        public ArrayList GetBalanceInfoByDate(string Begin, string End, bool Tag, string Oper)
        {
            string strSql = "";
            string strSql1 = "", strSql2 = "", strSql3 = "";
            try
            {
                strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref strSql1) == -1) return null;

                strSql1 = string.Format(strSql1, Begin, End);
                strSql = strSql + strSql1;
                if (Tag)
                {
                    if (this.Sql.GetSql("GetBalanceInfoByDate.Where.1", ref strSql2) == -1) return null;
                    strSql = strSql + " " + strSql2;
                }
                if (Oper != "ALL")
                {
                    if (this.Sql.GetSql("GetBalanceInfoByDate.Where.2", ref strSql3) == -1) return null;
                    strSql3 = string.Format(strSql3, Oper);
                    strSql = strSql + " " + strSql3;
                }
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return this.QueryBalancesBySql(strSql);
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="Begin">开始时间</param>
        /// <param name="End">结束时间</param>
        /// <param name="Tag">是否只显示正交易</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByTime()", true)]
        public ArrayList GetBalanceInfoByDate(string Begin, string End, bool Tag)
        {
            string strSql = "";
            string strSql1 = "", strSql2 = "";
            try
            {
                strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
                if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref strSql1) == -1) return null;
                strSql = strSql + strSql1;
                if (Tag)
                {

                    strSql = string.Format(strSql, Begin, End);

                    if (this.Sql.GetSql("GetBalanceInfoByDate.Where.1", ref strSql2) == -1) return null;
                    strSql = strSql + " " + strSql2;
                }
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            return this.QueryBalancesBySql(strSql);
        }

        /// <summary>
        /// 根据时间检索发票头
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByTime()", true)]
        public ArrayList GetBalanceInfoByDate(string Begin, string End)
        {
            string strSql = "";
            string strSql1 = "";
            strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
            if (this.Sql.GetSql("GetBalanceInfoByDate.Where", ref strSql1) == -1) return null;
            strSql = strSql + strSql1;
            try
            {
                strSql = string.Format(strSql, Begin, End);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalancesBySql(strSql);
        }

        /// <summary>
        /// 通过发票号码检索结算头表结算信息
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByInvoiceNO()", true)]
        public ArrayList GetBalanceInfoByInvoice(string InvoiceNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetSqlForSelectAllInfoFromBalanceHead();
            if (this.Sql.GetSql("GetBalanceInfoByInvoice.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InvoiceNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalancesBySql(strSql1);
        }

        /// <summary>
        /// 根据住院流水号获取未作废的发票号
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="flag">ALL 全部，O 出院结算，I 中途结算</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByInpatientNO()", true)]
        public ArrayList GetBalanceHeadInfoByInpatientNo(string inpatientNo, string flag)
        {
            string strSql = "";
            string strSqlWhere = "";
            strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
            if (flag == "" || flag == "ALL")
            {
                if (this.Sql.GetSql("Fee.GetBalanceHeadInfoByInpatientNo.Select.2", ref strSqlWhere) == -1)
                    return null;
            }
            else if (flag == "O")
            {
                if (this.Sql.GetSql("Fee.GetBalanceHeadInfoByInpatientNo.Select.3", ref strSqlWhere) == -1)
                    return null;
            }
            else
            {
                if (this.Sql.GetSql("Fee.GetBalanceHeadInfoByInpatientNo.Select.4", ref strSqlWhere) == -1)
                    return null;
            }
            strSql = strSql + strSqlWhere;
            try
            {
                strSql = string.Format(strSql, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalancesBySql(strSql);

        }

        /// <summary>
        /// 通过住院流水号查询患者结算头表信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryBalancesByInpatientNO()", true)]
        public ArrayList GetBalanceHeadInfoByInpatientNo(string inpatientNo)
        {
            string strSql = "";
            string strSqlWhere = "";
            strSql = this.GetSqlForSelectAllInfoFromBalanceHead();
            if (this.Sql.GetSql("Fee.GetBalanceHeadInfoByInpatientNo.Select.1", ref strSqlWhere) == -1)
                return null;
            strSql = strSql + strSqlWhere;
            try
            {
                strSql = string.Format(strSql, inpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.QueryBalancesBySql(strSql);

        }

        /// <summary>
        /// 直接结算退费,通过发票号获得非药品费用明细
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListByInvoiceNO()", true)]
        public ArrayList GetUndrugItemFromInvoice(string invoiceNo, DateTime dtBegin, DateTime dtEnd)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetUndrugItemFromInvoice.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, invoiceNo, dtBegin, dtEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }

        /// <summary>
        /// 直接结算退费,通过发票号获得药品费用明细
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListByInvoiceNO()", true)]
        public ArrayList GetMedItemFromInvoice(string invoiceNo, DateTime dtBegin, DateTime dtEnd)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetMedItemFromInvoice.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, invoiceNo, dtBegin, dtEnd);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            //ReadDetailUndrug
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 将结算的非药品费用明细信息置为结算状态--中途结算按时间和最小费用update
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceNo"></param>
        /// <param name="InvoiceNo"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="FeeCode"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateFeeItemListBalanced()", true)]
        public int UpdateItemListBalanced(string InpatientNo, int BalanceNo, string InvoiceNo, DateTime dt1, DateTime dt2, string FeeCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateItemListBalanced.2", ref strSql) == -1) return -1;
            try
            {
                //0 住院流水号1结算序号2结算发票号3开始时间4结束时间
                strSql = string.Format(strSql, InpatientNo, BalanceNo, InvoiceNo, dt1, dt2, FeeCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 将结算的非药品费用明细信息置为结算状态--出院结算全update使用
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="balanceNO">结算序号</param>
        /// <param name="invoiceNO">结算发票号</param>
        /// <returns>成功:>=1 失败: -1 没有更新到数据:0</returns>
        [Obsolete("作废,用UpdateFeeItemListBalanced()", true)]
        public int UpdateItemListBalanced(string inpatientNO, int balanceNO, string invoiceNO)
        {
            return this.UpdateSingleTable("Fee.UpdateItemListBalanced.1", inpatientNO, balanceNO.ToString(), invoiceNO);
        }

        /// <summary>
        /// 获得新的结算序号Written By 王儒超
        /// </summary>
        /// <param name="InpatientNo">患者住院流水号</param>
        /// <returns>最新结算序号即本次结算操作序号</returns>
        /// GetNewBalanceNo.No1
        [Obsolete("作废,用GetNewBalanceNO()", true)]
        public string GetNewBalanceNo(string InpatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.GetNewBalanceNo.No1", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, InpatientNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.ExecSqlReturnOne(strSql);

        }

        /// <summary>
        ///  更新住院主表结算信息
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="dtBalance"></param>
        /// <param name="balNo"></param>
        /// <param name="Fee"></param>
        /// <returns></returns>
        [Obsolete("作废,用UpdateInMainInfoBalanced()", true)]
        public int UpdateInMaininfoBalanced(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, DateTime dtBalance, int balNo, Neusoft.HISFC.Models.Base.FT Fee)
        {
            //0 住院流水号1结算时间2预交金3转押金4结算金额5自费金额6pub金额7pay金额8优惠金额 9结算序号10在院状

            //态11转入费用12转入预交金
            string strSql = "";
            if (this.Sql.GetSql("Fee.UpdateInMaininfoBalanced.1", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, PatientInfo.ID, dtBalance.ToString(), Fee.PrepayCost.ToString(), Fee.TransferPrepayCost.ToString(),
                    Fee.TotCost.ToString(), Fee.OwnCost.ToString(), Fee.PubCost.ToString(), Fee.PayCost.ToString(), Fee.RebateCost.ToString(),
                    balNo, PatientInfo.PVisit.InState.ID, Fee.TransferTotCost.ToString(), Fee.TransferPrepayCost.ToString());

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 查询患者帐开关
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <returns>关帐标志1关帐0开帐</returns>
        [Obsolete("作废,用GetStopAccount()", true)]
        public string QueryStopAccount(string InpatientNo)
        {
            string strSql;
            strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.QueryStopAccount.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            return this.ExecSqlReturnOne(strSql);

        }

        /// <summary>
        /// 检索药品和非药品明细单条记录---通过主键
        /// </summary>
        /// <param name="NoteNo"></param>
        /// <param name="SequenceNO"></param>
        /// <param name="IsPharmacy"></param>
        /// <returns></returns>
        [Obsolete("作废,用GetItemListByRecipeNO()", true)]
        public Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList GetFeeItemListByNoteNoAndNoteSequence(string NoteNo, int SequenceNO, bool IsPharmacy)
        {

            //0 处方号1处方内流水号
            string strSql1 = "";
            string strSql2 = "";
            ArrayList alItem = new ArrayList();
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
            if (IsPharmacy)
            {
                strSql1 = this.GetMedItemListSelectSql();
                if (this.Sql.GetSql("Fee.GetFeeItemListByNoteNoAndNoteSequence.1", ref strSql2) == -1) return null;
                strSql2 = string.Format(strSql2, NoteNo, SequenceNO);
            }
            else
            {

                strSql1 = this.GetFeeItemsSelectSql();
                if (this.Sql.GetSql("Fee.GetFeeItemListByNoteNoAndNoteSequence.1", ref strSql2) == -1) return null;
                strSql2 = string.Format(strSql2, NoteNo, SequenceNO);
            }
            strSql1 = strSql1 + strSql2;
            if (IsPharmacy)
            {

                alItem = this.QueryMedItemListsBySql(strSql1);

            }
            else
            {
                alItem = this.QueryFeeItemListsBySql(strSql1);
            }
            if (alItem == null) return null;
            if (alItem.Count == 0)
            {
                this.Err = "没有找到该项目";
                return null;
            }
            ItemList = (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)alItem[0];
            return ItemList;
        }

        /// <summary>
        /// 获得患者和执行科室的药品收费明细
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListsByInpatientNOAndDept()", true)]
        public ArrayList GetMedItemListByInpatientAndDept(string InpatientNo, string DeptCode)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetMedItemListByInpatientAndDept.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, DeptCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 获得患者和执行科室的非药品收费明细
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsByInpatientNOAndDept()", true)]
        public ArrayList GetFeeItemListByInpatientAndDept(string InpatientNo, string DeptCode)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetFeeItemListByInpatientAndDept.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, DeptCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }

        /// <summary>
        /// 获得患者药品收费信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="Dept"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListsByInpatientNO()", true)]
        public ArrayList GetPatientDrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, string Dept)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetPatientDrug.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, Dept);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 按获得患者非药品收费信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="Dept"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsByInpatientNO()", true)]
        public ArrayList GetPatientUndrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, string Dept)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetPatientUndrug.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, Dept);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目 Edit by liangjz
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="SendDrugState">是否发药</param>
        /// <param name="isBalance">是否结算</param>
        /// <param name="minFeeID">最小费用代码</param>
        /// <returns>返回动态数组，失败返回null</returns>
        [Obsolete("作废,用QueryMedItemListsCanQuitByInvoiceNO()", true)]
        public ArrayList GetForQuitDrugByInvoice(string InvoiceNo, DateTime dtBegin, DateTime dtEnd, string SendDrugState, bool isBalance, string minFeeID)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitDrug.4", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InvoiceNo, dtBegin, dtEnd, SendDrugState, balanceState, minFeeID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目 Edit by liangjz
        /// </summary>
        /// <param name="InvoiceNo">发票号</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="SendDrugState">是否发药</param>
        /// <param name="isBalance">是否结算</param>
        /// <returns>返回动态数组，失败返回null</returns>
        [Obsolete("作废,用QueryMedItemListsCanQuitByInvoiceNO()", true)]
        public ArrayList GetForQuitDrugByInvoice(string InvoiceNo, DateTime dtBegin, DateTime dtEnd, string SendDrugState, bool isBalance)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitDrug.2", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InvoiceNo, dtBegin, dtEnd, SendDrugState, balanceState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目 Edit by liangjz
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="SendDrugState">是否发药</param>
        /// <param name="isBalance">是否结算</param>
        /// <param name="minFeeID">最小费用代码</param>
        /// <returns>返回动态数组，失败返回null</returns>
        [Obsolete("作废,用QueryMedItemListsCanQuit()", true)]
        public ArrayList GetForQuitDrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, string SendDrugState, bool isBalance, string minFeeID)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitDrug.3", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, SendDrugState, balanceState, minFeeID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 根据发放状态提取一段时间范围内未结算的供可供退费的药品项目 Edit by liangjz
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="SendDrugState"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListsCanQuit()", true)]
        public ArrayList GetForQuitDrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, string SendDrugState)
        {
            return this.QueryMedItemListsCanQuit(InpatientNo, dtBegin, dtEnd, SendDrugState, false);
        }

        /// <summary>
        /// 根据是否结算、是否发放提取一段时间范围内可供退费的药品项目 Edit by liangjz
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="dtBegin">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <param name="SendDrugState">是否发药</param>
        /// <param name="isBalance">是否结算</param>
        /// <returns>返回动态数组，失败返回null</returns>
        [Obsolete("作废,用QueryMedItemListsCanQuit()", true)]
        public ArrayList GetForQuitDrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, string SendDrugState, bool isBalance)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitDrug.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, SendDrugState, balanceState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 根据是否结算提取患者可退费非药品信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="isBalance"></param>
        /// <param name="minFeeID">最小费用代码</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsCanQuit()", true)]
        public ArrayList GetForQuitUndrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, bool isBalance, string minFeeID)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitUndrug.2", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, balanceState, minFeeID);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }
        /// <summary>
        /// 提取一段时间范围内供可供退费的非药品项目
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsCanQuit()", true)]
        public ArrayList GetForQuitUndrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd)
        {
            return this.QueryFeeItemListsCanQuit(InpatientNo, dtBegin, dtEnd, false);
        }

        /// <summary>
        /// 根据是否结算提取患者可退费非药品信息
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="isBalance"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsCanQuit()", true)]
        public ArrayList GetForQuitUndrug(string InpatientNo, DateTime dtBegin, DateTime dtEnd, bool isBalance)
        {
            string strSql1 = "";
            string strSql2 = "";
            string balanceState;
            if (isBalance)	//已结算
                balanceState = "1";
            else	//未结算
                balanceState = "0";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetForQuitUndrug.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo, dtBegin, dtEnd, balanceState);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }

        /// <summary>
        /// 获得药品划价信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废,用QueryMedItemListCharged()", true)]
        public ArrayList GetDrugChargeItems(string InpatientNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetDrugChargeItems.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryMedItemListsBySql(strSql1);
        }

        /// <summary>
        /// 获得患者的药品信息
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>null错误, ArrayList.Count = 0没有符合要求记录, >=1 有效记录</returns>
        [Obsolete("作废,用QueryMedItemLists()", true)]
        public ArrayList GetMedItemsForInpatient(string inpatientNo, DateTime beginDate, DateTime endDate, string flag)
        {
            string strSql = "";
            string strSqlWhere = "";
            string sUpload = "";
            strSql = GetMedItemListSelectSql();
            if (this.Sql.GetSql("Fee.GetMedItemsForInpatient.Where.Upload", ref strSqlWhere) == -1)
                return null;
            if (flag.ToUpper() == "ALL")//所有
            {
                sUpload = "%";
            }
            else if (flag.ToUpper() == "Yes")
            {
                sUpload = "1";
            }
            else
            {
                sUpload = "0";
            }
            try
            {
                strSqlWhere = string.Format(strSqlWhere, inpatientNo, beginDate, endDate, sUpload);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            strSql = strSql + strSqlWhere;
            return QueryMedItemListsBySql(strSql);
        }

        /// <summary>
        /// 获得非药品划价信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemListsForCharged()", true)]
        public ArrayList GetUndrugChargeItems(string InpatientNo)
        {
            string strSql1 = "";
            string strSql2 = "";
            strSql1 = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetUndrugChargeItems.1", ref strSql2) == -1) return null;
            strSql1 = strSql1 + strSql2;
            try
            {
                strSql1 = string.Format(strSql1, InpatientNo);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.QueryFeeItemListsBySql(strSql1);
        }

        /// <summary>
        /// 获得患者非药品信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeItemLists()", true)]
        public ArrayList GetFeeItemsForInpatient(string inpatientNo, DateTime beginDate, DateTime endDate)
        {
            string strSql = "";
            string strSqlWhere = "";
            strSql = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetMedItemsForInpatient.Where.1", ref strSqlWhere) == -1)
                return null;
            try
            {
                strSqlWhere = string.Format(strSqlWhere, inpatientNo, beginDate, endDate);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            strSql = strSql + strSqlWhere;
            return this.QueryFeeItemListsBySql(strSql);
        }
        /// <summary>
        /// 获得患者的非药品信息
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="flag">"All"所有, "Yes"已上传 "No"未上传</param>
        /// <returns>null错误, ArrayList.Count = 0没有符合要求记录, >=1 有效记录</returns>
        [Obsolete("作废,用QueryFeeItemLists()", true)]
        public ArrayList GetFeeItemsForInpatient(string inpatientNo, DateTime beginDate, DateTime endDate, string flag)
        {
            string strSql = "";
            string strSqlWhere = "";
            string sUpload = "";
            strSql = this.GetFeeItemsSelectSql();
            if (this.Sql.GetSql("Fee.GetMedItemsForInpatient.Where.Upload", ref strSqlWhere) == -1)
                return null;
            if (flag.ToUpper() == "ALL")//所有
            {
                sUpload = "%";
            }
            else if (flag.ToUpper() == "Yes")
            {
                sUpload = "1";
            }
            else
            {
                sUpload = "0";
            }
            try
            {
                strSqlWhere = string.Format(strSqlWhere, inpatientNo, beginDate, endDate, sUpload);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            strSql = strSql + strSqlWhere;
            return this.QueryFeeItemListsBySql(strSql);
        }

        /// <summary>
        /// 根据住院号，开始结束时间查找已打印的托收单--用于补打
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosForPrinted()", true)]
        public ArrayList GetFeeInfosForPrinted(string InpatientNo, string begin, string end)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetFeeInfosForPrinted", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, begin, end);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }


            this.ExecQuery(strSql);
            //			Neusoft.HISFC.Models.Base.FT Fee;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    if (!this.Reader.IsDBNull(1)) FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    if (!this.Reader.IsDBNull(2)) FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    if (!this.Reader.IsDBNull(3)) FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    if (!this.Reader.IsDBNull(4)) FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    if (!this.Reader.IsDBNull(5)) FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 指定时间到现在未打印的托收单
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="begin">开始时间</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosForPrintBill()", true)]
        public ArrayList GetFeeInfosForPrintBill(string InpatientNo, string begin)
        {
            return null;
        }
        /// <summary>
        /// 根据住院号，开始结束时间查找未打印的托收单
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosForPrintBill()", true)]
        public ArrayList GetFeeInfosForPrintBill(string InpatientNo, string begin, string end)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetFeeInfosForPrintBill", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, begin, end);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }


            this.ExecQuery(strSql);
            //			Neusoft.HISFC.Models.Base.FT Fee;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    if (!this.Reader.IsDBNull(1)) FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    if (!this.Reader.IsDBNull(2)) FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    if (!this.Reader.IsDBNull(3)) FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    if (!this.Reader.IsDBNull(4)) FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    if (!this.Reader.IsDBNull(5)) FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获取日限额调整过的明细
        /// 特征：tot_cost=0,own_cost!=0
        /// </summary>
        /// <param name="InPatientNo">住院流水号</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeForAdjustByInpatientNO", true)]
        public ArrayList GetMinFeeInfoForAdjust(string InPatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetMinFeeInfoForAdjust", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InPatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeForAdjustOverTopByInpatientNO", true)]
        public ArrayList GetMinFeeForAdjustOverTop(string InPatientNo)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetMinFeeForAdjustOverTop", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InPatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 根据住院号，结算状态，交易类型查询患者信息
        /// </summary>
        /// <param name="InPatientNo">住院流水号</param>
        /// <param name="BalanceState">结算状态</param>
        /// <param name="TransType">交易类型，1正交易2反交易3药费调整</param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeByInpatientNO()", true)]
        public ArrayList GetMinFeeInfoByPatientID(string InPatientNo, string BalanceState, string TransType)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetMinFeeInfoByPatientID", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InPatientNo, BalanceState, TransType);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得费用信息FeeInfoUnion转入费用（最小费用分组）-住院流水号,结算状态
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosAndChangeCostGroupByMinFeeByInpatientNO()", true)]
        public ArrayList GetFeeInfosAndChangeCostGroupByMinFee(string InpatientNo, string BalanceState)
        {
            string strSql = "";
            if (this.Sql.GetSql("GetFeeInfosAndChangeCostGroupByMinFee.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, BalanceState);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }

            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;

        }

        /// <summary>
        /// 按照住院流水号和结算序号检索feeinfo
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="BalanceNo"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeByInpatientNO()", true)]
        public ArrayList GetFeeInfoGroupbyMinFee(string InpatientNo, int BalanceNo)
        {
            string strSql = "";

            //0住院流水号1结算序号
            if (this.Sql.GetSql("GetFeeInfosGroupbyMinFee.2", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, BalanceNo.ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }


            this.ExecQuery(strSql);
            //			Neusoft.HISFC.Models.Base.FT Fee;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    if (!this.Reader.IsDBNull(1)) FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    if (!this.Reader.IsDBNull(2)) FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    if (!this.Reader.IsDBNull(3)) FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    if (!this.Reader.IsDBNull(4)) FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    if (!this.Reader.IsDBNull(5)) FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// GetFeeInfosGroupbyMinFee.1
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dt1"></param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeByInpatientNO()", true)]
        public ArrayList GetFeeInfosGroupbyMinFee(string InpatientNo, DateTime dt1, string BalanceState)
        {
            DateTime dt2 = this.GetDateTimeFromSysDateTime();
            return this.QueryFeeInfosGroupByMinFeeByInpatientNO(InpatientNo, dt1, dt2, BalanceState);
        }

        /// <summary>
        /// 获得费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// GetFeeInfosGroupbyMinFee.1
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeByInpatientNO()", true)]
        public ArrayList GetFeeInfosGroupbyMinFee(string InpatientNo, DateTime dt1, DateTime dt2, string BalanceState)
        {
            string strSql = "";
            if (this.Sql.GetSql("GetFeeInfosGroupbyMinFee.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, dt1, dt2, BalanceState);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }


            this.ExecQuery(strSql);
            //			Neusoft.HISFC.Models.Base.FT Fee;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    if (!this.Reader.IsDBNull(1)) FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    if (!this.Reader.IsDBNull(2)) FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    if (!this.Reader.IsDBNull(3)) FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    if (!this.Reader.IsDBNull(4)) FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    if (!this.Reader.IsDBNull(5)) FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;

        }

        /// <summary>
        ///  获得婴儿费用信息FeeInfo（最小费用分组）-住院流水号，费用发生开始时间，结束时间,结算状态
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="BalanceState"></param>
        /// <returns></returns>
        [Obsolete("作废,用QueryFeeInfosGroupByMinFeeForBaby()", true)]
        public ArrayList GetFeeInfosGroupByMinFeeForBaby(string InpatientNo, DateTime dt1, DateTime dt2, string BalanceState)
        {
            string strSql = "";
            if (this.Sql.GetSql("GetFeeInfosGroupByMinFeeForBaby.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, InpatientNo, dt1, dt2, BalanceState, "1");
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }


            this.ExecQuery(strSql);
            //			Neusoft.HISFC.Models.Base.FT Fee;
            Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo;
            ArrayList al = new ArrayList();
            while (this.Reader.Read())
            {
                FeeInfo = new FeeInfo();
                try
                {
                    FeeInfo.Item.MinFee.ID = this.Reader[0].ToString();
                    if (!this.Reader.IsDBNull(1)) FeeInfo.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                    if (!this.Reader.IsDBNull(2)) FeeInfo.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    if (!this.Reader.IsDBNull(3)) FeeInfo.FT.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    if (!this.Reader.IsDBNull(4)) FeeInfo.FT.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    if (!this.Reader.IsDBNull(5)) FeeInfo.FT.RebateCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                }
                catch (Exception ex)
                {
                    this.Err = "获得费用信息（最小费用分组）赋值错误" + ex.Message;
                    this.ErrCode = ex.Message;
                    this.WriteErr();
                    return null;
                }
                al.Add(FeeInfo);
            }
            this.Reader.Close();
            return al;

        }

        /// <summary>
        /// 通过最小费用代码获得最小费用名称
        /// </summary>
        /// <param name="FeeCode"></param>
        /// <returns></returns>
        [Obsolete("作废,用GetMinFeeNameByCode()", true)]
        public string GetFeeNameByFeeCode(string FeeCode)
        {
            string strSql = "";
            if (this.Sql.GetSql("GetFeeNameByFeeCode.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, FeeCode);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.ErrCode = ex.Message;
                return null;
            }
            return this.ExecSqlReturnOne(strSql);
        }

        /// <summary>
        /// 获得所有费用信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("作废()", true)]
        public ArrayList GetFeeInfos()
        {
            return null;
        }
        /// <summary>
        /// 获得费用信息-根据患者的住院流水号
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="strDataSet"></param>
        /// <returns></returns>
        [Obsolete("作废()", true)]
        public ArrayList GetFeeInfos(string InpatientNo, ref string strDataSet)
        {
            return null;
        }
        /// <summary>
        /// 获得费用信息-住院流水号，费用发生开始时间，结束时间
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <param name="strDataSet"></param>
        /// <returns></returns>
        [Obsolete("作废()", true)]
        public ArrayList GetFeeInfos(string InpatientNo, DateTime dt1, DateTime dt2, ref string strDataSet)
        {
            return null;
        }

        /// <summary>
        /// 获得新的发票号 Written By 王儒超 调用存储过程
        /// 根据操作员的ID和财务组代码 输入票据预警数目 返回剩余发票数目 表现层用发票数目-预警数目判断提示领取发票
        /// 由于票据预警数目的定义可能比较不固定所以业务层不作判断 返回的剩余数目默认10000 只有小于预警数目才会返回
        /// 真实数目,考虑这样表现层只需相减判断,处理比较简单也比较通用.
        /// </summary>
        /// <param name="OperatorID">操作员代码</param>
        /// <param name="InvoiceType">发票类型</param>
        /// <param name="InAlarm">票据预警数目</param>
        /// <param name="InLeftNum">剩余发票数目</param>
        /// <param name="FinGrpId">财务组代码</param>
        /// <returns>发票号 </returns>
        [Obsolete("作废, 使用GetNewInvoiceNO()", true)]
        public string GetNewInvoiceNo(string OperatorID, Neusoft.HISFC.Models.Fee.EnumInvoiceType InvoiceType, int InAlarm, ref int InLeftNum,
            string FinGrpId)
        {
            string strSql = "";
            string strReturn = "";
            string[] s;
            string InvoiceNo = "";
            int InCode = 0;
            string strText = "";
            InLeftNum = 10000;
            #region 接口说明
            //获得发票号
            //传入:0 opratorID
            //传出:0 下一个新发票号
            #endregion
            if (this.Sql.GetSql("Fee.Inpatient.Invoice.Get.1", ref strSql) == -1)
            {
                this.Err = "获得发票号的sql语句没找到出错！Fee.Inpatient.Invoice.Get.1没找到!";
                this.ErrCode = "Fee.Inpatient.Invoice.Get.1没找到!";
                this.WriteErr();
                return null;
            }
            try
            {
                strSql = string.Format(strSql, ((int)InvoiceType).ToString(), OperatorID, InAlarm, InvoiceNo, strText, InCode, FinGrpId);
            }
            catch
            {
                this.Err = "参数不对";
                return null;
            }
            if (this.ExecEvent(strSql, ref strReturn) == -1)
            {
                this.Err = "执行存储过程出错!PRC_GET_INVOICE";
                this.ErrCode = "PRC_GET_INVOICE";
                this.WriteErr();
                return null;

            };

            s = strReturn.Split(',');
            InvoiceNo = s[0];
            strText = s[1];
            try
            {
                InCode = NConvert.ToInt32(s[2]);
                if (InCode == 100)//没有找到发票号
                {
                    this.Err = strText;
                    this.ErrCode = "100";
                    return null;
                }
                if (InCode == 101)//找到发票号但是剩余发票号低于预警数目
                {
                    InLeftNum = NConvert.ToInt32(strText);
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
            }

            return InvoiceNo;
        }

        /// <summary>
        /// 获得新药品处方号 Written By 王儒超
        /// </summary>
        /// <returns>药品处方号</returns>
        [Obsolete("作废, 使用GetDrugRecipeNO()", true)]
        public string GetDrugNewNoteNo()
        {
            string strSql = "";
            string strNoteNo = "";
            if (this.Sql.GetSql("GetDrugNewNoteNo.1", ref strSql) == -1) return "";
            if (this.ExecQuery(strSql) == -1) return "";
            try
            {
                this.Reader.Read();
                strNoteNo = (this.Reader[0].ToString());
                strNoteNo = strNoteNo.PadLeft(13, '0');
                strNoteNo = "y" + strNoteNo;
                this.Reader.Close();
                return strNoteNo;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.ErrCode = ex.Message;
                this.Err = "获得新处方号出错！" + this.GetType().ToString() + ex.Message;
                this.WriteErr();
                return "";
            }

        }

        /// <summary>
        /// 获得新非药品处方号 Written By 王儒超
        /// </summary>GetUndrugNewNoteNo.1
        /// <returns>非药品处方号</returns>
        [Obsolete("作废, 使用GetUndrugRecipeNO()", true)]
        public string GetUndrugNewNoteNo()
        {
            string strSql = "";
            string strNoteNo = "";
            if (this.Sql.GetSql("GetUndrugNewNoteNo.1", ref strSql) == -1) return null;
            if (this.ExecQuery(strSql) == -1) return null;
            try
            {
                this.Reader.Read();
                strNoteNo = (this.Reader[0].ToString());
                strNoteNo = strNoteNo.PadLeft(13, '0');
                strNoteNo = "f" + strNoteNo;
                this.Reader.Close();
                return strNoteNo;
            }
            catch (Exception ex)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
                this.ErrCode = ex.Message;
                this.Err = "获得新处方号出错！" + this.GetType().ToString() + ex.Message;
                this.WriteErr();
                return "";
            }

        }


        /// <summary>
        /// 是否婴儿享受待遇
        /// </summary>
        /// <param name="FeeInfo"></param>
        /// <returns></returns>
        [Obsolete("作废", true)]
        public bool ifBabyShared(Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo)
        {
            #region 接口说明
            //获得合同单位是否享受婴儿待遇
            //传入:0 合同编码
            //传出：0 否 1是
            #endregion
            string strSql = "";
            int i = 0;
            if (this.Sql.GetSql("Fee.Inpatient.FeeRate.2", ref strSql) == -1) return false;
            strSql = string.Format(strSql, FeeInfo.Patient.Pact.ID);
            if (this.ExecQuery(strSql) == -1) return false;
            try
            {
                this.Reader.Read();
                i = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0].ToString());

            }
            catch { }
            finally
            {
                this.Reader.Close();
            }
            return System.Convert.ToBoolean(i);
        }

        /// <summary>
        /// 获得项目费用比例(包括婴儿的待遇判断)
        /// </summary>
        /// <param name="FeeInfo">患者基本信息</param>
        /// <param name="Item">项目信息</param>
        /// <returns>费用比例对象</returns>
        [Obsolete("作废", true)]
        public Neusoft.HISFC.Models.Base.FTRate GetFeeRate(Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo FeeInfo, Neusoft.HISFC.Models.Base.Item Item)
        {
            Neusoft.HISFC.Models.Base.FTRate Rate = new Neusoft.HISFC.Models.Base.FTRate();
            string strSql = "";

            Rate.OwnRate = 1;
            Rate.PayRate = 0;
            Rate.PubRate = 0;
            if (FeeInfo.IsBaby)//婴儿
            {
                if (this.ifBabyShared(FeeInfo) == false)
                {
                    return Rate;
                }
            }
            #region 接口说明
            //获得项目的比例
            //传入:0 合同编码，1最小费用编码，2 0 非药品 1 药品,3 项目编码
            //传出：0 OwnRate,1 PayRate,2 PubRate
            #endregion
            if (this.Sql.GetSql("Fee.Inpatient.FeeRate.1", ref strSql) == -1) return null;
            strSql = string.Format(strSql, FeeInfo.Patient.Pact.ID, FeeInfo.Item.MinFee.ID, Neusoft.FrameWork.Function.NConvert.ToInt32(Item.IsPharmacy.ToString()), Item.ID);
            if (this.ExecQuery(strSql) == -1) return Rate;
            try
            {
                this.Reader.Read();
                Rate.OwnRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0].ToString());
                Rate.PayRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1].ToString());
                Rate.PubRate = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "读取比例出错！" + this.GetType().ToString() + ex.Message;
                this.WriteErr();
            }
            finally
            {
                this.Reader.Close();
            }
            return Rate;
        }

        /// <summary>
        /// 查询患者有效预交金记录--For结算
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        [Obsolete("作废,使用QueryPrepaysBalanced()", true)]
        public ArrayList QueryPrepayForBalance(string InpatientNo)
        {
            string strSql1 = this.GetSqlForSelectAllPrepay();
            string strSql2 = "";

            if (this.Sql.GetSql("Fee.QueryPrepayForBalance.1", ref strSql2) == -1) return null;
            try
            {
                strSql2 = string.Format(strSql2, InpatientNo);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return null;
            }
            strSql1 += strSql2;
            return this.QueryPrepaysBySql(strSql1);

        }

        /// <summary>
        /// 更新患者主表预交金信息
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="Prepay"></param>
        /// <returns></returns>
        [Obsolete("作废,使用UpdatePrepay()", true)]
        public int UpdateAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.Prepay Prepay)
        {
            //0住院流水号1预交金额
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.UpdateAccount11", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, PatientInfo.ID, Prepay.FT.PrepayCost.ToString());

            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


        /// <summary>
        ///  添加患者 预交金费用  Written By 王儒超
        /// </summary>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="Prepay">预交金费用</param>
        /// <returns><br>0 成功</br><br>-1 失败</br></returns>
        [Obsolete("作废,使用InsertPrepay()", true)]
        public int AddPatientAccount(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Models.Fee.Inpatient.Prepay Prepay)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.Prepay.1", ref strSql) == -1)
            {
                return -1;
            }
            #region 接口说明
            //添加患者预交金信息 更新预交金表和住院主表Fee.Inpatient.Prepay.1
            //传入参数
            //0住院流水号  1发生序号  2姓名  3预交金额 4交付方式 5科室代码  6预交金收据号码 7结算时间 8结算标志 0:未结算；1:已结算
            //9预交金状态0:收取；1:作废;2:补打 10开户银行 11开户帐户 12结算发票号 13结算序号 14结算人代码 15上缴标志（1是 0否） 
            //16财务组代码 17工作单位 18 0非转押金，1转押金，2转押金已打印 19转押金结算员 20转押金时间 21 pos交易流水号或支票号或汇票号
            //22 操作员 23操作日期 24 财务审核序号25转押金时结算序号 26原发票号码 27操作员科室
            #endregion
            if (Prepay.PrepayOper.OperTime == DateTime.MinValue)
            {
                this.ErrCode = "预交金收费时间参数没有赋值!";
                this.Err = "预交金收费时间参数没有赋值!";
                return -1;
            }
            if ((Prepay.PrepayOper.ID == null) || (Prepay.PrepayOper.ID == ""))
            {
                this.ErrCode = "预交金操作员没有赋值!";
                this.Err = "预交金操作员没有赋值!";
                return -1;
            }
            string OperDeptCode = ""; //操作员科室
            if (Prepay.PrepayOper.Dept.ID == null || Prepay.PrepayOper.Dept.ID == "")
            {
                OperDeptCode = this.GetDeptByEmplId(Prepay.PrepayOper.ID);
            }
            else
            {
                OperDeptCode = Prepay.PrepayOper.Dept.ID;
            }

            try
            {

                string[] s ={
							   //住院流水号
							   PatientInfo.ID,
							   //发生序号
							   Prepay.ID,
							   //预交金额
							   PatientInfo.Name,Prepay.FT.PrepayCost.ToString(),
							   //交付方式
							   Prepay.PayType.ID.ToString(),
							   // 科室代码
							   PatientInfo.PVisit.PatientLocation.Dept.ID,
							   //预交金收据号码
							   Prepay.Invoice.ID,
							   //结算时间
							   Prepay.BalanceTime.ToString(),
							   //结算标志 0:未结算；1:已结算
							   Prepay.BalanceState,
							   //预交金状态0:收取；1:作废;2:补打
							   Prepay.PrepayState,
							   //开户银行
							   Prepay.Bank.Name,
							   //开户帐户
							   Prepay.Bank.Account,
							   //结算发票号
							   Prepay.Invoice.ID,
							   //结算序号
							   Prepay.BalanceNO.ToString(),
							   //结算人代码
							   Prepay.BalanceOper.ID,
							   //上缴标志（1是 0否）
							   System.Convert.ToInt16(Prepay.IsTurnIn).ToString(),
							   //财务组代码
							   Prepay.FinGroup.ID,
							   //工作单位
							   Prepay.Bank.WorkName,
							   //0非转押金，1转押金2转押金已打印
							   Prepay.TransferPrepayState,
							   //转押金结算员
							   Prepay.TransPrepayOper.ID,
							   //转押金时间
							   Prepay.TransferPrepayTime.ToString(),
							   //交易流水号或支票号或汇票号
							   Prepay.Bank.InvoiceNO,
							   //操作员
							   Prepay.PrepayOper.ID,
							   //操作日期
							   Prepay.PrepayOper.OperTime.ToString(),
							   //财务审核序号
							   Prepay.AuditingNO,
							   //转押金时结算序号
							   Prepay.TransferPrepayBalanceNO.ToString(),//
							   //原发票号码
							   Prepay.OrgInvoice.ID,
							   //操作员科室
							   OperDeptCode
						   };

                strSql = string.Format(strSql, s);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "信息未输入完整！" + ex.Message;
                return -1;
            }
            return this.ExecNoQuery(strSql);
        }


        #endregion




        #region "获取人员科室"
        /// <summary>
        /// 通过人员id获取科室代码
        /// </summary>
        /// <param name="PersonId">人员id</param>
        /// <returns></returns>
        public string GetDeptByEmplId(string PersonId)
        {
            Neusoft.HISFC.BizLogic.Manager.Person Person = new Neusoft.HISFC.BizLogic.Manager.Person();
            //Person.SetTrans(this.commond.Transaction);
            Neusoft.HISFC.Models.Base.Employee p = new Employee();
            //p=Person.GetPersonByID(PersonId);
            if (p == null)
            {
                this.Err = "检索人员科室出错!" + Person.Err;
                return null;
            }

            return p.Dept.ID;
        }
        #endregion
        #region 医保费用查询
        /// <summary>
        /// 获取医保患者上传总费用
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <param name="TotCost">上传总费用</param>
        /// <returns></returns>
        public int GetUploadTotCost(string InpatientNo, ref decimal TotCost)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.InPatient.GetUploadTotCost", ref strSql) == -1)
            {
                this.Err = "没有找到SQL语句Fee.InPatient.GetUploadTotCost";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, InpatientNo);

                this.ExecQuery(strSql);
                while (Reader.Read())
                {
                    TotCost = Convert.ToDecimal(Reader[0]);
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            return 0;
        }
        #endregion

        #region "组合业务"


        /// <summary>
        /// 插入正负预交金记录
        /// </summary>
        /// <param name="Prepay">预交金实体(原型的预交金信息)</param>
        /// <param name="PatientInfo">患者信息</param>
        /// <param name="NewReciptNo">新产生的发票号</param>
        /// <param name="ReturnInvoiceNo">负记录发票号</param>
        /// <param name="ReturnPrepay">负记录实体返回以供打印冲红发票使用</param>
        /// <returns>0成功-1失败</returns>

        public int PrepaySignOperation(Neusoft.HISFC.Models.Fee.Inpatient.Prepay Prepay, Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, string NewReciptNo, string ReturnInvoiceNo, ref Neusoft.HISFC.Models.Fee.Inpatient.Prepay ReturnPrepay)
        {
            //形成负记录实体

            Prepay.OrgInvoice.ID = Prepay.Invoice.ID;
            //负记录是否使用新的发票号
            if (ReturnInvoiceNo.Length > 1) Prepay.RecipeNO = ReturnInvoiceNo;
            Prepay.FT.PrepayCost = -Prepay.FT.PrepayCost;
            Prepay.PrepayOper.ID = this.Operator.ID;
            Prepay.PrepayOper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.GetSysDateTime());
            Prepay.PrepayState = "2";
            ReturnPrepay = Prepay.Clone();
            //插入负记录
            if (this.InsertPrepay(PatientInfo, Prepay) < 1)
            {
                this.Err = "插入预交金出错!";
                return -1;
            }
            //更新原有记录
            if (UpdatePrepayHaveReturned(PatientInfo, Prepay) < 1)
            {
                this.Err = "该条记录已经结算或者进行过返还补打,更新状态出错!" + this.Err;
                return -1;
            }
            //形成正记录实体
            Prepay.FT.PrepayCost = -Prepay.FT.PrepayCost;
            Prepay.PrepayState = "0";
            Prepay.RecipeNO = NewReciptNo;
            //插入正记录
            if (this.InsertPrepay(PatientInfo, Prepay) < 1)
            {
                this.Err = "插入预交金出错!";
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 划价后收费
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public int FeeAfterCharge(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList)
        {
            if (this.UpdateChargeItemToFee(ItemList) == -1)
            {
                this.Err = "更新划价记录失败!";
                return -1;
            }
            //ItemList.Item.MinFee.ID=ItemList.Item.MinFee.ID;
            //			if (this.UpdateAccount(PatientInfo,ItemList)==-1)
            //			{
            //				this.Err="插入费用汇总表失败!"+this.DBErrCode.ToString();
            //				return -1;
            //			}
            int parm = this.UpdateInMainInfoFee(PatientInfo.ID, ItemList.FT);
            if (parm == -1)
            {
                this.Err = "更新住院主表失败!";
                return -1;
            }
            if (parm == 0)
            {
                this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 收费
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public int FeeManager(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList)
        {
            return this.FeeManager(PatientInfo, ItemList, "0");
        }
        /// <summary>
        /// 退费
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public int FeeManagerReturn(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList)
        {
            return this.FeeManager(PatientInfo, ItemList, "1");
        }
        /// <summary>
        /// 只为直接退费服务
        /// 0收费 1退费   退费时候进入的实体为要退费的正记录(负记录函数内处理)  收费的时候为要收费的赋值完后的正记录实体
        /// isUpdate == true 更新被退费的可退数量 == false 不更新
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="ItemList"></param>
        /// <param name="Flag"></param>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        public int DirQuitFee(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList, string Flag, bool isUpdate)
        {
            //判断费用总额
            if (ItemList.FT.TotCost == 0)
            {
                this.Err = "费用总额为0,收取无意义,请重新确认!";
                return -1;
            }
            //判断护士站代码
            //直接退费患者可能没有护士站
            //			if(PatientInfo.PVisit.PatientLocation.NurseCell.ID==null||PatientInfo.PVisit.PatientLocation.NurseCell.ID.Trim()=="")
            //			{
            //				this.Err="表现层患者护士站编码没有赋值!";
            //				return -1;
            //			}
            //判断执行科室代码
            if (ItemList.ExecOper.Dept.ID == null || ItemList.ExecOper.Dept.ID == "")
            {
                this.Err = "表现层执行科室没有赋值!";
                return -1;
            }
            //判断收费比例
            if (ItemList.FTRate.ItemRate < 0)
            {
                this.Err = "收费比例赋值错误!";
                return -1;
            }
            if (ItemList.FTRate.ItemRate == 0) ItemList.FTRate.ItemRate = 1;

            //计算患者费用比例
            //			if(this.ComputePatientFee(PatientInfo,ref ItemList)==-1)
            //			{
            //				this.Err="计算费用比例出错"+this.Err;
            //				return -1;
            //			}
            //			
            if (Flag == "1")
            {
                //更新可退数量 然后取得新的处方号
                //if (ItemList.Item.IsPharmacy)
                if(ItemList.Item.ItemType == EnumItemType.Drug)
                {
                    if (isUpdate)
                    {
                        if (this.UpdateNoBackQtyForDrug(ItemList.RecipeNO, ItemList.SequenceNO, ItemList.Item.Qty, ItemList.BalanceState) == -1)
                        {
                            this.Err = "更新原有记录可退数量出错!可能同时有其他人进行同一患者退费!";
                            return -1;
                        }
                    }
                    //获得新的处方号
                    ItemList.RecipeNO = GetDrugRecipeNO();
                }
                else
                {
                    if (isUpdate)
                    {
                        if (this.UpdateNoBackQtyForUndrug(ItemList.RecipeNO, ItemList.SequenceNO, ItemList.Item.Qty, ItemList.BalanceState) == -1)
                        {
                            this.Err = "更新原有记录可退数量出错!可能同时有其他人进行同一患者退费!";
                            return -1;
                        }
                    }
                    //获得新的处方号
                    ItemList.RecipeNO = GetUndrugRecipeNO();
                }

                //形成负记录
                ItemList.Item.Qty = -ItemList.Item.Qty;
                ItemList.FT.TotCost = -ItemList.FT.TotCost;
                ItemList.FT.OwnCost = -ItemList.FT.OwnCost;
                ItemList.FT.PayCost = -ItemList.FT.PayCost;
                ItemList.FT.PubCost = -ItemList.FT.PubCost;
                ItemList.FT.RebateCost = -ItemList.FT.RebateCost;
                ItemList.TransType = TransTypes.Negative;
                ItemList.FeeOper.ID = this.Operator.ID;
                ItemList.FeeOper.OperTime = this.GetDateTimeFromSysDateTime();
                if (ItemList.BalanceState == null) ItemList.BalanceState = "0";
                ItemList.BalanceOper.OperTime = this.GetDateTimeFromSysDateTime();
            }
            else
            {
                //if (ItemList.Item.IsPharmacy)
                if(ItemList.Item.ItemType == EnumItemType.Drug)
                {
                    ItemList.RecipeNO = GetDrugRecipeNO();
                }
                else
                {
                    ItemList.RecipeNO = this.GetUndrugRecipeNO();
                }

                ItemList.FeeOper.OperTime = this.GetDateTimeFromSysDateTime();
                ItemList.BalanceState = "1";
                ItemList.BalanceOper.OperTime = this.GetDateTimeFromSysDateTime();
            }

            //if (ItemList.Item.IsPharmacy)
            if(ItemList.Item.ItemType == EnumItemType.Drug)
            {
                if (this.InsertMedItemList(PatientInfo, ItemList) == -1)
                {
                    this.Err = "插入药品明细出错!";
                    return -1;
                }
            }
            else
            {
                if (this.InsertFeeItemList(PatientInfo, ItemList) == -1)
                {
                    this.Err = "插入非药品明细出错!";
                    return -1;
                }
            }
            //ItemList.Item.MinFee.ID=ItemList.Item.MinFee.ID;
            //费用汇总表
            //			if (this.UpdateAccount(PatientInfo,ItemList)==-1)
            //			{
            //				this.Err="插入费用汇总表失败!";
            //				return -1;
            //			}

            //公费更新日限额
            if (PatientInfo.Pact.PayKind.ID == "03")
            {
                //if (ItemList.Item.IsPharmacy == true || ItemList.FT.PubCost != 0)
                if(ItemList.Item.ItemType == EnumItemType.Drug || ItemList.FT.PubCost != 0)
                {
                    //更新公费日限额累计
                    if (this.UpdateBursaryTotMedFee(PatientInfo.ID, ItemList.FT.TotCost) < 1)
                    {
                        this.Err = "更新公费患者日限额累计失败!";
                        return -1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 0收费 1退费   退费时候进入的实体为要退费的正记录(负记录函数内处理)  收费的时候为要收费的赋值完后的正记录实体
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="ItemList"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        private int FeeManager(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList, string Flag)
        {
            //判断费用总额
            if (ItemList.FT.TotCost == 0)
            {
                this.Err = "表现层费用总额没有赋值";
                return -1;
            }



            //判断护士站代码
            if (PatientInfo.PVisit.PatientLocation.NurseCell.ID == null || PatientInfo.PVisit.PatientLocation.NurseCell.ID.Trim() == "")
            {
                this.Err = "表现层患者护士站编码没有赋值!";
                return -1;
            }
            //判断执行科室代码
            if (ItemList.ExecOper.Dept.ID == null || ItemList.ExecOper.Dept.ID == "")
            {
                this.Err = "表现层执行科室没有赋值!";
                return -1;
            }
            //判断收费比例
            if (ItemList.FTRate.ItemRate < 0)
            {
                this.Err = "收费比例赋值错误!";
                return -1;
            }
            if (ItemList.FTRate.ItemRate == 0) ItemList.FTRate.ItemRate = 1;


            //将totcost截取
            //			ItemList.FT.TotCost=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost,2);
            if (ItemList.User01 != "1" && Flag == "0") //用以患者费用比例修改,重新调用的时候不需要在计算费用比例
            {
                //计算患者费用比例
                if (this.ComputePatientFee(PatientInfo, ItemList) == -1)
                {
                    this.Err = "计算费用比例出错" + this.Err;
                    return -1;
                }

            }
            //为防止最后余额不符，统一转换为2位。
            ItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost, 2);
            ItemList.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.OwnCost, 2);
            ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.PayCost, 2);
            ItemList.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.PubCost, 2);
            //防止空调床位拆分后记录为0
            if (ItemList.FT.TotCost == 0) return 0;
            //				//医保预结算
            //				Neusoft.HISFC.Models.Base.FT InmaininfoFee = new Neusoft.HISFC.Models.Base.FT();
            //				if(PatientInfo.Pact.ID=="2")  //广州医保
            //				{
            //					Neusoft.HISFC.BizLogic.Fee.Interface InterFace = new Interface();
            //					InterFace.SetTrans(this.command.Transaction);
            //
            //				
            //					//预结算
            //					if(InterFace.CalculateSiFee(PatientInfo,ItemList,InmaininfoFee)==false)
            //					{
            //						this.Err=InterFace.Err;
            //						return -1;
            //					}
            //
            //				}


            if (Flag == "1")
            {
                //更新可退数量 然后取得新的处方号
                //if (ItemList.Item.IsPharmacy)
                if(ItemList.Item.ItemType == EnumItemType.Drug)
                {
                    if (ItemList.Memo != "BACKFEE")
                    {
                        if (this.UpdateNoBackQtyForDrug(ItemList.RecipeNO, ItemList.SequenceNO, ItemList.Item.Qty, ItemList.BalanceState) < 1)
                        {
                            this.Err = "更新原有记录可退数量出错!" + ItemList.Item.Name + "费用已经被退费或结算!";
                            return -1;
                        }
                    }
                    //获得新的处方号
                    ItemList.RecipeNO = GetDrugRecipeNO();
                }
                else
                {
                    if (ItemList.Memo != "BACKFEE")
                    {
                        if (this.UpdateNoBackQtyForUndrug(ItemList.RecipeNO, ItemList.SequenceNO, ItemList.Item.Qty, ItemList.BalanceState) < 1)
                        {
                            this.Err = "更新原有记录可退数量出错!" + ItemList.Item.Name + "费用已经被退费或结算!";
                            return -1;
                        }
                    }
                    //获得新的处方号
                    ItemList.RecipeNO = GetUndrugRecipeNO();
                }
                //形成负记录
                ItemList.Item.Qty = -ItemList.Item.Qty;
                ItemList.FT.TotCost = -ItemList.FT.TotCost;
                ItemList.FT.OwnCost = -ItemList.FT.OwnCost;
                ItemList.FT.PayCost = -ItemList.FT.PayCost;
                ItemList.FT.PubCost = -ItemList.FT.PubCost;
                ItemList.FT.RebateCost = -ItemList.FT.RebateCost;
                ItemList.TransType = TransTypes.Negative;
                ItemList.FeeOper.ID = this.Operator.ID;
                ItemList.FeeOper.OperTime = this.GetDateTimeFromSysDateTime();

                if (ItemList.BalanceState == null) ItemList.BalanceState = "0";
            }
            else                                                            //Add By Maokb
            {
                ItemList.Patient.Pact.ID = PatientInfo.Pact.ID;     //Add By Maokb
                ItemList.Patient.Pact.PayKind.ID = PatientInfo.Pact.PayKind.ID;       //Add By maokb
            }

            ItemList.ChargeOper.OperTime = ItemList.FeeOper.OperTime; //保持划价时间跟收费时间同步

            //if (ItemList.Item.IsPharmacy)
            if(ItemList.Item.ItemType == EnumItemType.Drug)
            {
                if (this.InsertMedItemList(PatientInfo, ItemList) == -1)
                {
                    this.Err = "插入药品明细出错!";
                    return -1;
                }
            }
            else
            {
                if (this.InsertFeeItemList(PatientInfo, ItemList) == -1)
                {
                    this.Err = "插入非药品明细出错!";
                    return -1;
                }
            }
            //ItemList.Item.MinFee.ID=ItemList.Item.MinFee.ID;
            //费用汇总表
            //			if (this.UpdateAccount(PatientInfo,ItemList)==-1)
            //			{
            //				this.Err="插入费用汇总表失败!"+this.Err;
            //				return -1;
            //			}
            //更新主表费用
            //			if(PatientInfo.Pact.ID=="2")
            //			{
            //				if(this.UpdateInmaininfoFeeForMedicare(PatientInfo,InmaininfoFee)==-1)
            //				{
            //					this.Err="医保更新主表失败"+this.Err;
            //					return -1;
            //				}
            //			}
            //			else
            //			{

            //Moidfy By 王宇 马上就到2005年12月26号了,最郁闷的圣诞节...
            //修改更新主表SQL语句，加上Where in_state <> 'O'和不等于in_state <> C条件，控制并发
            //如果患者处于结算状态，控制不可以录入费用. 和 C封账状态不可以录入或者退费用
            //保证结算清单的正确.
            int iReturn = this.UpdateInMainInfoFee(PatientInfo.ID, ItemList.FT);

            if (iReturn == -1)
            {
                this.Err = "更新住院主表失败!";
                return -1;
            }
            //如果返回为0 说明不符合in_state <> 0条件，让前台不可以再录入费用.
            if (iReturn == 0)
            {
                this.Err = PatientInfo.Name + "已经结算或者出于封账状态，不能继续录入费用!请与住院处联系!";
                return -1;
            }
            //Modify完毕
            //			}
            //更新公费药累计
            if (PatientInfo.Pact.PayKind.ID == "03" && ItemList.ExtFlag != "1")
            {
                //因为非药品明细表中也有药品--by Maokb
                //此处使用PubCost!=0,因为自费药调整的时候,TotCost是0,但是PubCost!=0
                if ((ItemList.Item.MinFee.ID == "001" || ItemList.Item.MinFee.ID == "002" || ItemList.Item.MinFee.ID == "003") && ItemList.FT.PubCost != 0)
                {
                    //更新公费药累计
                    /*
                     * 程序原来用PubCost来更新，看用户需求也是这样。
                     * this.UpdateBursaryTotMedFee(PatientInfo.ID,ItemList.Fee.Pub_Cos
                     * 但是和用户咨询后得实，药限额超标指的是超出药品总额部分，所以用TotCost来更新
                     * */
                    if (this.UpdateBursaryTotMedFee(PatientInfo.ID, ItemList.FT.TotCost) < 1)
                    {
                        this.Err = "更新公费患者日限额累计失败!" + this.Err;
                        return -1;
                    }
                }
            }
            return 0;
        }
        #endregion
        /// <summary>
        /// 计算患者费用---按比例分配
        /// </summary>
        /// <param name="Pinfo"></param>
        /// <param name="ItemList"></param>
        /// <returns></returns>
        public int ComputePatientFee(Neusoft.HISFC.Models.RADT.PatientInfo Pinfo, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList)
        {
            if (ItemList.Item.MinFee.ID == null || ItemList.Item.MinFee.ID.Trim() == "") ItemList.Item.MinFee.ID = ItemList.Item.MinFee.ID;
            if (ItemList.FT.TotCost == 0)
            {
                this.Err = "费用总额为0,收取没有意义!";
                return -1;
            }
            //调用求比例函数，只有Tot_cost有用，其它Cost无效
            //但是在有些收费中给own_cost赋值，在此取消
            ItemList.FT.OwnCost = 0;
            ItemList.FT.PayCost = 0;
            ItemList.FT.PubCost = 0;

            //自费患者直接赋值返回
            if (Pinfo.Pact.PayKind.ID == "01")
            {
                ItemList.FT.OwnCost = ItemList.FT.TotCost;
                ItemList.FT.PayCost = 0;
                ItemList.FT.PubCost = 0;

                return 0;
            }
            //自费项目，自费处理
            if (ItemList.ExtFlag == "1")
            {//如果是限制类药品,且转为自费项目,标志为1
                //如果是特殊检查等项目，在审批前为自费，标志1
                ItemList.FT.OwnCost = ItemList.FT.TotCost;
                ItemList.FT.PayCost = 0;
                ItemList.FT.PubCost = 0;
                return 0;
            }

            //医保患者，暂时自费处理--待改
            if (Pinfo.Pact.ID == "2")//Pinfo.Pact.PayKind.ID=="02"||
            {
                #region Delete By 不知是谁
                //医保患者处理比例

                Fee.Interface Interface = new Interface();
                //Interface.SetTrans(this.command.Transaction);

                if (Interface.ComputeRate(Pinfo.Pact.ID, ref ItemList) == -1)
                {
                    this.Err = "提取医保患者费用比例计算出错!";
                    return -1;
                }
                return 0;

                #endregion
                //				ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //				ItemList.FT.PayCost=0;
                //				ItemList.FT.PubCost=0;
            }
            #region 公费患者
            if (Pinfo.Pact.PayKind.ID == "03")
            {
                //公费患者--限制类用药，自费特别治疗-膳食-用品-及其他-走自费路线---在判断合同单位前计算

                /*对公费患者
                 * 1.求费用比例
                 * 2.床位费是否超标
                 * 3.药品是否超标
                 * */
                //求费用比例

                Neusoft.HISFC.Models.Base.FTRate Rate = this.ComputeFeeRate(Pinfo.Pact.ID, ItemList.Item);
                if (Rate == null)
                {
                    return -1;
                }
                if (Pinfo.CaseState == "S" && Pinfo.PVisit.InState.ID.ToString() == "B")//公费特殊登记患者，如果维护取此比例
                {
                    Rate.OwnRate = 0;
                    Rate.PayRate = Pinfo.FT.FTRate.PayRate;
                    this.ComputeCost(ItemList, Rate);
                    return 0;
                }


                //判断是否是监护床，若是，取监护床标准
                if (this.IsIcuBedList(ItemList.Item.ID))
                {
                    //床位限额
                    decimal IcuLimit = Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.AirLimitCost * ItemList.Item.Qty, 2);
                    //超标自理
                    if (Pinfo.FT.BedOverDeal == "1")
                    {
                        if (IcuLimit >= ItemList.FT.TotCost)
                        {
                            //监护床标准大于监护床费，不超标
                            this.ComputeCost(ItemList, Rate);
                            return 0;
                        }
                        else
                        {
                            //超标，超标部分自费
                            ItemList.FT.OwnCost = ItemList.FT.TotCost - IcuLimit;
                            this.ComputeCost(ItemList, Rate);
                            return 0;
                        }
                    }
                    //超标不限 全额报销
                    if (Pinfo.FT.BedOverDeal == "0")
                    {
                        this.ComputeCost(ItemList, Rate);
                        return 0;
                    }
                    //超标不计，报销限额内，剩下的舍掉
                    if (Pinfo.FT.BedOverDeal == "2")
                    {
                        //超标
                        if (ItemList.FT.TotCost > IcuLimit)
                        {
                            ItemList.FT.TotCost = IcuLimit;
                        }
                        this.ComputeCost(ItemList, Rate);
                        return 0;
                    }
                }

                // 如果是床位费
                if (ItemList.Item.MinFee.ID == "A02")
                {

                    //床位限额
                    decimal BedLimitCost = Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.BedLimitCost * ItemList.Item.Qty, 2);
                    //超标自理
                    if (Pinfo.FT.BedOverDeal == "1")
                    {
                        //不超标
                        if (ItemList.FT.TotCost <= BedLimitCost)
                        {
                            this.ComputeCost(ItemList, Rate);
                            return 0;
                        }
                        else
                        {//超标部分转为自费
                            ItemList.FT.OwnCost = ItemList.FT.TotCost - BedLimitCost;
                            this.ComputeCost(ItemList, Rate);
                            return 0;
                        }
                    }
                    //超标不限 全额报销
                    if (Pinfo.FT.BedOverDeal == "0")
                    {
                        this.ComputeCost(ItemList, Rate);
                        return 0;
                    }
                    //超标不计，报销限额内，剩下的舍掉
                    if (Pinfo.FT.BedOverDeal == "2")
                    {
                        //超标
                        if (ItemList.FT.TotCost > BedLimitCost)
                        {
                            ItemList.FT.TotCost = BedLimitCost;
                        }
                        this.ComputeCost(ItemList, Rate);
                        return 0;
                    }
                }
                #region Delete By Maokb 05-10-18
                // 如果是药品
                //				if(ItemList.Item.MinFee.ID == "001"||ItemList.Item.MinFee.ID == "002"||ItemList.Item.MinFee.ID =="003")
                //				{
                //					
                //					if(Pinfo.FT.OvertopCost < 0)
                //					{
                //						//如果不超标
                //						if(ItemList.FT.TotCost + Pinfo.FT.OvertopCost < 0)
                //						{
                //							this.ComputeCost(ItemList,Rate);
                //							//重新设置超标金额
                //							Pinfo.FT.OvertopCost = Pinfo.FT.OvertopCost + ItemList.FT.TotCost;
                //							return 0;
                //						}
                //						else
                //						{//插入本项目前不超标，插入本项目后超标，超标部分转为自费
                //							ItemList.FT.OwnCost = ItemList.FT.TotCost + Pinfo.FT.OvertopCost ;
                //							this.ComputeCost(ItemList,Rate);
                //							//重新设置超标金额
                //							Pinfo.FT.OvertopCost = Pinfo.FT.OvertopCost + ItemList.FT.TotCost;
                //							return 0;
                //						}
                //					}
                //					else
                //					{//插入本项目前已经超标,全部自费
                //						ItemList.FT.OwnCost = ItemList.FT.TotCost;
                //						ItemList.FT.PayCost = 0;
                //						ItemList.FT.PubCost = 0;
                //						//重新设置超标金额
                //						Pinfo.FT.OvertopCost = Pinfo.FT.OvertopCost + ItemList.FT.TotCost;
                //						return 0;
                //					}
                //					
                //
                //				}
                #endregion
                // 其它
                this.ComputeCost(ItemList, Rate);
                return 0;

                #region Delete By Maokb--05-10-15
                //				// 自费项目 -- By Maokb
                //				/*对于自费项目可以不判断合同单位直接赋值返回
                //				 * 根据最小费用判断是否是自费项目
                //				 * 1.超标2.未完待续
                //				 * */
                //				if(ItemList.Item.MinFee.ID=="A03")
                //				{
                //					//如果是超标，全部自费
                //					ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //					ItemList.FT.PayCost=0;
                //					ItemList.FT.PubCost=0;
                //
                //					return 0;
                //				}
                //				//定义合同单位实体
                //				Neusoft.HISFC.Models.Base.PactInfo PactUnitInfo = new Neusoft.HISFC.Models.Base.PactInfo();
                //				Neusoft.HISFC.Management.Base.PactInfo PactManagment = new PactUnitInfo();
                //				PactManagment.SetTrans(this.command.Transaction);
                //				PactUnitInfo = PactManagment.GetPactUnitInfoByPactCode(Pinfo.Patient.Pact.ID);
                //				if(PactUnitInfo==null)
                //				{
                //					this.Err="检索患者的合同单位信息失败";
                //					return -1;
                //				}
                //				#region 床位费的原收取过程 Delete By Maokb
                //			
                //				//			//床费和空调按照定额往下减
                //				//			if(ItemList.Item.MinFee.ID=="A02")//床费
                //				//			{
                //				//				if(ItemList.Memo=="Wangrc") return 0;
                //				//				//没有超标床报销金额
                //				//				if(Pinfo.FT.BedLimitCost==0)
                //				//				{
                //				//					ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.PayCost=0;
                //				//					ItemList.FT.PubCost=0;
                //				//					return 0;
                //				//				}
                //				//				//超标不限 全额报销
                //				//				if(Pinfo.FT.BedOverDeal=="0")
                //				//				{
                //				//					ItemList.FT.PubCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.OwnCost=0;
                //				//					ItemList.FT.PayCost=0;
                //				//					return 0;
                //				//				}
                //				//				//zhangjunyi@Neusoft.com 2005/8/23 增加 超标不计的算法 以前没有处理这种情况
                //				//				//超标不计 
                //				//				if((ItemList.FT.TotCost > Pinfo.FT.BedLimitCost)&&Pinfo.FT.BedOverDeal=="2") 
                //				//				{
                //				//					//超标不计
                //				//					ItemList.FT.OwnCost = 0;
                //				//					ItemList.FT.PubCost = Pinfo.FT.BedLimitCost;
                //				//					ItemList.FT.PayCost = 0;
                //				//					return 0;
                //				//				}
                //				//
                //				//				//小于超标金额全部报销记帐
                //				//				if(ItemList.FT.TotCost <= Pinfo.FT.BedLimitCost)
                //				//				{
                //				//					ItemList.FT.OwnCost=0;
                //				//					ItemList.FT.PubCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.PayCost=0;
                //				//				}
                //				//				else //拆分成两条记录 超标部分为自费
                //				//				{
                //				//					//克隆
                //				//					Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList CloneItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                //				//					CloneItem = ItemList.Clone();
                //				//					//金额
                //				//					CloneItem.FT.PubCost=Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.BedLimitCost*CloneItem.Item.Qty,2);
                //				//					CloneItem.FT.OwnCost=0;
                //				//					CloneItem.FT.PayCost=0;
                //				//					CloneItem.FT.TotCost=CloneItem.FT.PubCost;
                //				//
                //				//					//名称单价
                //				//					if(CloneItem.FT.TotCost!=ItemList.FT.TotCost)
                //				//					{
                //				//						CloneItem.Item.Name=CloneItem.Item.Name+"(报销部分)";
                //				//					}
                //				//					CloneItem.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(CloneItem.FT.TotCost/CloneItem.Item.Qty,2);
                //				//					CloneItem.Memo="Wangrc";
                //				//					//调用收费函数
                //				//					if(this.FeeManager(Pinfo,CloneItem)==-1) return -1;
                //				//
                //				//					//拆分的另一条
                //				//					ItemList.Memo="Wangrc";
                //				//
                //				//					//最小费用
                //				//					ItemList.Item.MinFee.ID="A10";
                //				//					ItemList.Item.MinFee.ID="A10";
                //				//					//处方号
                //				//					ItemList.RecipeNO=this.GetUndrugNewNoteNo();
                //				//					//金额
                //				//					ItemList.FT.TotCost=ItemList.FT.TotCost-Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.BedLimitCost*ItemList.Item.Qty,2);;
                //				//					ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.PayCost=0;
                //				//					ItemList.FT.PubCost=0;
                //				//					//单价名称
                //				//					ItemList.Item.Name=ItemList.Item.Name+"(超标部分)";
                //				//					ItemList.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost/ItemList.Item.Qty,2);
                //				//				}
                //				//				return 0;
                //				//			}
                //				//			if(ItemList.Item.MinFee.ID=="A03") //空调
                //				//			{
                //				//				if(ItemList.Memo=="Wangrc") return 0;
                //				//				//没有超标空调
                //				//				if(Pinfo.FT.AirLimitCost==0)
                //				//				{
                //				//					ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.PayCost=0;
                //				//					ItemList.FT.PubCost=0;
                //				//					return 0;
                //				//				}
                //				//				//小于超标金额全部报销记帐
                //				//				if(ItemList.FT.TotCost <= Pinfo.FT.AirLimitCost)
                //				//				{
                //				//					ItemList.FT.OwnCost=0;
                //				//					ItemList.FT.PayCost=0;
                //				//					ItemList.FT.PubCost=ItemList.FT.TotCost;
                //				//		
                //				//				}
                //				//				else//拆分成两条记录 超标部分为自费
                //				//				{
                //				//					//克隆
                //				//					Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList CloneItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                //				//					CloneItem = ItemList.Clone();
                //				//
                //				//                    //金额
                //				//					CloneItem.FT.PubCost=Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.AirLimitCost*CloneItem.Item.Qty,2);
                //				//					CloneItem.FT.OwnCost=0;
                //				//					CloneItem.FT.PayCost=0;
                //				//					CloneItem.FT.TotCost=CloneItem.FT.PubCost;
                //				//
                //				//                    //名称单价
                //				//					if(CloneItem.FT.TotCost !=ItemList.FT.TotCost)
                //				//					{
                //				//						CloneItem.Item.Name=CloneItem.Item.Name+"(报销部分)";
                //				//					}
                //				//					CloneItem.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(CloneItem.FT.TotCost/CloneItem.Item.Qty,2);
                //				//					CloneItem.Memo="Wangrc";
                //				//					//调用收费函数
                //				//					if(this.FeeManager(Pinfo,CloneItem)==-1) return -1;
                //				//
                //				//					//拆分的另一条
                //				//					ItemList.Memo="Wangrc";
                //				//					//最小费用
                //				//					ItemList.Item.MinFee.ID="A11";
                //				//					ItemList.Item.MinFee.ID="A11";
                //				//				    //处方号
                //				//					ItemList.RecipeNO=this.GetUndrugNewNoteNo();
                //				//					//金额
                //				//					ItemList.FT.TotCost=ItemList.FT.TotCost-Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.AirLimitCost*CloneItem.Item.Qty,2);
                //				//					ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //				//					ItemList.FT.PayCost=0;
                //				//					ItemList.FT.PubCost=0;
                //				//					//名称单价
                //				//					ItemList.Item.Name=ItemList.Item.Name+"(超标部分)";
                //				//					ItemList.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost/ItemList.Item.Qty,2);
                //				//				}
                //				//				return 0;
                //				//			}
                //				#endregion
                //			
                //				#region 收取床位费
                //				/*收取床位费的过程是这样的：
                //				 * 1.判断是否是公费患者
                //				 * 2.判断床位费是否超标，超标部分转为自费
                //				 *  1)
                //				 * 3.判断是否是超标不限-若是，全部公费
                //				 * 4.判断是否是超标不计-若是，报销公费限额内部分，其它部分舍掉
                //				 * 
                //				 * */
                //				if(Pinfo.Pact.PayKind.ID == "03")
                //				{
                //					if(ItemList.Memo=="Wangrc") return 0;
                //					//公费
                //					if(ItemList.Item.MinFee.ID == "A02")
                //					{//床位费
                //
                //						//床位限额
                //						decimal BedLimitCost=Neusoft.FrameWork.Public.String.FormatNumber(Pinfo.FT.BedLimitCost * ItemList.Item.Qty,2);
                //
                //						//超标自理
                //						if(Pinfo.FT.BedOverDeal =="1")
                //						{
                //							//不超标
                //							if(ItemList.FT.TotCost <= BedLimitCost)
                //							{
                //								ItemList.FT.OwnCost = 0;
                //								ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost * PactUnitInfo.Rate.PayRate,2);
                //								ItemList.FT.PubCost =ItemList.FT.TotCost - ItemList.FT.PayCost;
                //								return 0;
                //							}
                //							else
                //							{
                //								//克隆
                //								Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList CloneItem = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                //								CloneItem = ItemList.Clone();
                //
                //								//金额
                //								CloneItem.FT.TotCost = BedLimitCost;
                //								CloneItem.FT.PayCost=Neusoft.FrameWork.Public.String.FormatNumber(BedLimitCost * PactUnitInfo.Rate.PayRate,0);							
                //								CloneItem.FT.OwnCost=0;
                //								CloneItem.FT.PubCost=ItemList.FT.TotCost - ItemList.FT.PayCost;
                //							
                //
                //								//名称单价
                //								if(CloneItem.FT.TotCost !=ItemList.FT.TotCost)
                //								{
                //									CloneItem.Item.Name=CloneItem.Item.Name+"(报销部分)";
                //								}
                //								CloneItem.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(CloneItem.FT.TotCost/CloneItem.Item.Qty,2);
                //								CloneItem.Memo="Wangrc";
                //								//调用收费函数
                //								if(this.FeeManager(Pinfo,CloneItem)==-1) return -1;
                //
                //								//拆分的另一条
                //								ItemList.Memo="Wangrc";
                //								//最小费用
                //								ItemList.Item.MinFee.ID="A03";
                //								ItemList.Item.MinFee.ID="A03";
                //								//处方号
                //								ItemList.RecipeNO=this.GetUndrugNewNoteNo();
                //								//金额
                //								ItemList.FT.TotCost=ItemList.FT.TotCost-CloneItem.FT.TotCost;
                //								ItemList.FT.OwnCost=ItemList.FT.TotCost;
                //								ItemList.FT.PayCost=0;
                //								ItemList.FT.PubCost=0;
                //								//名称单价
                //								ItemList.Item.Name=ItemList.Item.Name+"(超标部分)";
                //								ItemList.Item.Price=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost/ItemList.Item.Qty,2);	
                //	
                //								return 0;
                //
                //							}
                //						}
                //					 
                //						//超标不限 全额报销
                //						if(Pinfo.FT.BedOverDeal=="0")
                //						{
                //							
                //							ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost * PactUnitInfo.Rate.PayRate,2);
                //							ItemList.FT.OwnCost = 0;
                //							ItemList.FT.PubCost = ItemList.FT.TotCost - ItemList.FT.PayCost;						
                //							return 0;
                //						}
                //						//超标不计，报销限额内，剩下的舍掉
                //						if(Pinfo.FT.BedOverDeal =="2")
                //						{
                //							//超标
                //							if(ItemList.FT.TotCost >	BedLimitCost) 
                //							{
                //								ItemList.FT.TotCost =BedLimitCost; 
                //								ItemList.FT.OwnCost =0;
                //								ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost * PactUnitInfo.Rate.PayRate,2);
                //								ItemList.FT.PubCost = ItemList.FT.TotCost - ItemList.FT.PayCost;
                //								return 0;
                //							}
                //							else
                //							{//不超标
                //								ItemList.FT.OwnCost = 0;
                //								ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost * PactUnitInfo.Rate.PayRate,2);
                //								ItemList.FT.PubCost =ItemList.FT.TotCost - ItemList.FT.PayCost;
                //								return 0;
                //							}
                //						}					
                //					}
                //				}			
                //				#endregion
                //                //其他费用---取比例分配-----
                //				//原则,项目-最小费用-合同比例
                //				Neusoft.HISFC.Management.Base.PactItemRate PactItemRate = new PactUnitItemRate();
                //				PactItemRate.SetTrans(this.command.Transaction);
                //				Neusoft.HISFC.Models.Base.PactItemRate ObjPactItemRate = new Neusoft.HISFC.Models.Base.PactItemRate();
                //				//项目
                //				ObjPactItemRate= PactItemRate.GetOnepPactUnitItemRateByItem(Pinfo.Patient.Pact.ID,ItemList.Item.ID);
                //				if(ObjPactItemRate ==null)
                //				{
                //					//最小费用
                //					ObjPactItemRate= PactItemRate.GetOnepPactUnitItemRateByItem(Pinfo.Patient.Pact.ID,ItemList.Item.MinFee.ID);
                //					if(ObjPactItemRate ==null)
                //					{
                //						//取合同单位的比例
                //						try
                //						{
                //							ObjPactItemRate=new Neusoft.HISFC.Models.Base.PactItemRate();
                //							ObjPactItemRate.Rate.PayRate=PactUnitInfo.Rate.PayRate;
                //							ObjPactItemRate.Rate.OwnRate=PactUnitInfo.Rate.OwnRate;
                //						}
                //						catch(Exception ex)
                //						{
                //							this.Err=ex.Message;
                //							return -1;
                //						}
                //					}
                //				}
                //			
                //				//		#region  zhangjunyi@Neusoft.com 2005/08/23 删除 改为下边部分  删除原因 ：自费药没有按 全额自费处理
                //				//计算
                //				ItemList.FT.OwnCost=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost*ObjPactItemRate.Rate.OwnRate,2);
                //				ItemList.FT.PayCost=Neusoft.FrameWork.Public.String.FormatNumber((ItemList.FT.TotCost - ItemList.FT.OwnCost)*ObjPactItemRate.Rate.PayRate,2);
                //				ItemList.FT.PubCost=ItemList.FT.TotCost-ItemList.FT.OwnCost-ItemList.FT.PayCost;	
                //				//	#endregion 
                //				#region 在判断比例前判断自费项目 Delete By Maokb
                //				//			if(ItemList.Item.MinFee.ID=="A03"  ||ItemList.Item.MinFee.ID=="A10"||ItemList.Item.MinFee.ID=="A11"  ) //自费药 和超标床 全额自费
                //				//			{
                //				//				//计算
                //				//				ItemList.FT.OwnCost = ItemList.FT.TotCost;
                //				//				ItemList.FT.PayCost=0;
                //				//				ItemList.FT.PubCost= 0;
                //				//			}
                //				//			else
                //				//			{
                //				//				//计算
                //				//				ItemList.FT.OwnCost=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost*ObjPactItemRate.Rate.OwnRate,2);
                //				//				ItemList.FT.PayCost=Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost*ObjPactItemRate.Rate.PayRate,2);
                //				//				ItemList.FT.PubCost=ItemList.FT.TotCost-ItemList.FT.OwnCost-ItemList.FT.PayCost; 
                //				//			}
                //				#endregion
                #endregion
            }
            #endregion
            return 0;

        }
        /// <summary>
        ///  计算总费用的各个组成部分的值
        /// </summary>
        /// <param name="ItemList"></param>
        /// <param name="rate">各部分之间的比例</param>
        /// <returns>-1失败，0成功</returns>
        private int ComputeCost(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList, Neusoft.HISFC.Models.Base.FTRate rate)
        {
            if (ItemList.FT.OwnCost == 0)
            {
                ItemList.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.FT.TotCost * rate.OwnRate, 2);
                ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber((ItemList.FT.TotCost - ItemList.FT.OwnCost) * rate.PayRate, 2);
                ItemList.FT.PubCost = ItemList.FT.TotCost - ItemList.FT.OwnCost - ItemList.FT.PayCost;
            }
            else
            {
                ItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber((ItemList.FT.TotCost - ItemList.FT.OwnCost) * rate.PayRate, 2);
                ItemList.FT.PubCost = ItemList.FT.TotCost - ItemList.FT.OwnCost - ItemList.FT.PayCost;
            }
            return 0;

        }

        /// <summary>
        /// 获得省公医的编码
        /// </summary>
        /// <returns></returns>
        public string[] GetProPayCode()
        {
            string[] Code = new string[50];
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.GetProPayCode", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql";
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行出错!";
                return null;
            }
            int i = 0;
            while (this.Reader.Read())
            {
                Code[i] = this.Reader[0].ToString();
                i++;
            }
            this.Reader.Close();
            return Code;
        }
        /// <summary>
        /// 获得市公医的编码
        /// </summary>
        /// <returns></returns>
        public string[] GetCityPayCode()
        {
            string[] Code = new string[50];
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.GetCityPayCode", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql";
                return null;
            }
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "执行出错!";
                return null;
            }
            int i = 0;
            while (this.Reader.Read())
            {
                Code[i] = this.Reader[0].ToString();
                i++;
            }
            this.Reader.Close();
            return Code;
        }
        /// <summary>
        /// 求患者费用比例
        /// </summary>
        /// <param name="PactID">合同单位代码</param>
        /// <param name="item">药品费药品信息</param>
        /// <returns>失败null；成功 Neusoft.HISFC.Models.Fee.FtRate</returns>
        public Neusoft.HISFC.Models.Base.FTRate ComputeFeeRate(string PactID, Neusoft.HISFC.Models.Base.Item item)
        {
            //Neusoft.HISFC.Management.Base.PactItemRate PactItemRate = new PactUnitItemRate();
            //PactItemRate.SetTrans(this.command.Transaction);
            //
            Neusoft.HISFC.Models.Base.PactItemRate ObjPactItemRate = null;
            //			try
            //			{
            //				//项目
            //				ObjPactItemRate= PactItemRate.GetOnepPactUnitItemRateByItem(PactID,item.ID);
            //				if(ObjPactItemRate ==null)
            //				{
            //					//最小费用
            //					ObjPactItemRate= PactItemRate.GetOnepPactUnitItemRateByItem(PactID,item.MinFee.ID);
            //					if(ObjPactItemRate ==null)
            //					{
            //						//取合同单位的比例
            //						Neusoft.HISFC.Management.Base.PactInfo PactManagment = new PactUnitInfo();
            //						//PactManagment.SetTrans(this.command.Transaction);
            //						Neusoft.HISFC.Models.Base.PactInfo PactUnitInfo = PactManagment.GetPactUnitInfoByPactCode(PactID);
            //						if(PactUnitInfo == null) {
            //							this.Err = PactManagment.Err;
            //							return null;
            //						}
            //						try
            //						{
            //							ObjPactItemRate=new Neusoft.HISFC.Models.Base.PactItemRate();
            //							ObjPactItemRate.Rate.PayRate=PactUnitInfo.Rate.PayRate;
            //							ObjPactItemRate.Rate.OwnRate=PactUnitInfo.Rate.OwnRate;
            //						}
            //						catch(Exception ex)
            //						{
            //							this.Err=ex.Message;
            //							return null;
            //						}
            //					}
            //				}
            //			}
            //			catch(Exception ee)
            //			{
            //				this.Err = ee.Message;
            //				return null;
            //			}
            return ObjPactItemRate.Rate;
        }

        /// <summary>
        /// 查找预结算费用
        /// </summary>
        /// <param name="info">患者信息</param>
        /// <returns>1:成功 -1:失败</returns>
        public int GetFeePreBalance(Neusoft.HISFC.Models.RADT.PatientInfo info)
        {
            string strSql = string.Empty;
            if (this.Sql.GetSql("Fee.InpatientFee.GetFeePreBalance", ref strSql) == -1)
            {
                this.Err = "查找Sql语句Fee.InpatientFee.GetFeePreBalance出错！";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, info.ID);
                if (this.ExecQuery(strSql) == -1)
                {
                    this.Err = "格式化SQL语句失败！";
                }
                while (this.Reader.Read())
                {
                    info.SIMainInfo.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
                    info.SIMainInfo.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[1]);
                    info.SIMainInfo.PubCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2]);
                    info.SIMainInfo.PayCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3]);
                    info.SIMainInfo.OverCost = 0;
                    info.SIMainInfo.OfficalCost = 0;
                }
                return 1;
            }
            catch
            {
                this.Err = "查找数据失败！";
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }
        }

        /// <summary>
        /// 公费日限额超标调整
        /// </summary>
        /// <param name="pInfo">患者基本信息</param>
        /// <returns>-1失败，0成功</returns>
        public int AdjustOverLimitFee(Neusoft.HISFC.Models.RADT.PatientInfo pInfo)
        {
            int parm = 0;
            //判断是否有公费药超标金额
            if (pInfo.Pact.PayKind.ID == "03")
            {
                if (pInfo.FT.OvertopCost == 0) return 0;

                //判断是否是超标，如果有超标，调整超标部分
                if (pInfo.FT.OvertopCost > 0)
                {
                    #region 从公费转为自费
                    //需要判断各部分费用的金额以免结算出现负值
                    ArrayList alFee = new ArrayList();
                    //检索患者费用列表汇总
                    alFee = this.QueryFeeInfosGroupByMinFeeForAdjustOverTopByInpatientNO(pInfo.ID);
                    //西药费
                    decimal WCost = 0m;
                    //成药费
                    decimal PCost = 0m;
                    //草药费
                    decimal CCost = 0m;
                    //西药的负记录金额
                    decimal WShouldCost = 0m;
                    //成药的负记录金额
                    decimal PShouldCost = 0m;
                    //草药的负记录金额
                    decimal CShouldCost = 0m;

                    if (alFee == null)
                    {
                        this.Err = this.Err + "检索患者费用出错!";
                        return -1;
                    }
                    //循环得到中西草药费各部分值
                    for (int i = 0; i < alFee.Count; i++)
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo fInfo;
                        fInfo = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)alFee[i];
                        if (fInfo.Item.MinFee.ID == "001") WCost = fInfo.FT.TotCost;
                        if (fInfo.Item.MinFee.ID == "002") PCost = fInfo.FT.TotCost;
                        if (fInfo.Item.MinFee.ID == "003") CCost = fInfo.FT.TotCost;
                    }
                    //计算负记录金额分配情况
                    if (pInfo.FT.OvertopCost <= WCost)
                    {
                        //西药负记录金额
                        WShouldCost = pInfo.FT.OvertopCost;
                    }
                    else
                    {
                        //西药负记录金额
                        WShouldCost = WCost;
                        //计算成药费用
                        if (pInfo.FT.OvertopCost - WCost <= PCost)
                        {
                            //成药负记录金额
                            PShouldCost = (pInfo.FT.OvertopCost - WCost);
                        }
                        else
                        {

                            PShouldCost = PCost;
                            //计算中药负记录金额
                            if (pInfo.FT.OvertopCost - WCost - PCost <= CCost)
                            {
                                //中药负记录金额
                                CShouldCost = (pInfo.FT.OvertopCost - WCost - PCost);
                            }
                            else
                            {
                                this.Err = "超标金额不等于发生药品费用总额!可能存在并发操作!";
                                return -1;
                            }
                        }
                    }
                    //取当前时间
                    DateTime dtNow = this.GetDateTimeFromSysDateTime();

                    //取患者费用比例					
                    Neusoft.HISFC.Models.Base.PactInfo PactUnitInfo = new Neusoft.HISFC.Models.Base.PactInfo();
                    Neusoft.HISFC.BizLogic.Fee.PactUnitInfo PactManagment = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();//Base.PactInfo();
                    //PactManagment.SetTrans(this.command.Transaction);
                    PactUnitInfo = PactManagment.GetPactUnitInfoByPactCode(pInfo.Pact.ID);


                    // 插入自费药调整
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    Neusoft.HISFC.Models.Pharmacy.Item PhaItem = new Neusoft.HISFC.Models.Pharmacy.Item();
                    ItemList.Item = PhaItem;
                    // 赋值
                    //ItemList.RecipeNO= this.GetDrugNewNoteNo();  //处方号
                    //ItemList.SequenceNO=1; // 处方内流水号
                    //ItemList.Item.MinFee.ID="A01";//最小费用代码
                    //ItemList.Item.MinFee.ID="A01";
                    //ItemList.Item.ID="FA01";      //项目编码
                    //ItemList.Item.Name="自费药调整"; //项目名称

                    //这里要注意，不能用3代表调整
                    //ItemList.TransType="3";  //交易类型-3为调整

                    ((PatientInfo)ItemList.Patient).PVisit.PatientLocation.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;//在院科室
                    //ItemList.NurseStation.ID=pInfo.PVisit.PatientLocation.NurseCell.ID; //护士站
                    ItemList.ExecOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.StockOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.RecipeOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.RecipeOper.ID = pInfo.PVisit.AdmittingDoctor.ID; //医生
                    //ItemList.Item.Price=pInfo.FT.OvertopCost;
                    ItemList.Item.Qty = 1;//数量
                    //ItemList.NoBackQty=0;
                    ItemList.Item.PriceUnit = "次";
                    //ItemList.FT.TotCost=pInfo.FT.OvertopCost;
                    //ItemList.FT.OwnCost=pInfo.FT.OvertopCost;
                    //ItemList.Item.IsPharmacy = true;
                    ItemList.Item.ItemType = EnumItemType.Drug;
                    ItemList.PayType = PayTypes.Balanced;
                    ItemList.IsBaby = false;
                    ItemList.BalanceNO = 0;
                    ItemList.BalanceState = "0";
                    ItemList.NoBackQty = 1;
                    ItemList.ChargeOper.ID = this.Operator.ID;
                    ItemList.ChargeOper.OperTime = dtNow; //划价时间
                    ItemList.FeeOper.ID = this.Operator.ID;
                    ItemList.FeeOper.OperTime = dtNow;
                    ItemList.ChargeOper.OperTime = dtNow;
                    ItemList.Item.PackQty = 1;

                    //西药
                    if (WShouldCost > 0)
                    {
                        ItemList.FT.OwnCost = WShouldCost;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(WShouldCost * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(WShouldCost + ItemList.FT.PayCost);

                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//
                        ItemList.Item.ID = "Y001";
                        ItemList.Item.Name = "西药费(公费到自费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "001";
                        ItemList.Item.MinFee.ID = "001";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}
                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }

                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }

                    }
                    //成药
                    if (PShouldCost > 0)
                    {
                        ItemList.FT.OwnCost = PShouldCost;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(PShouldCost * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(PShouldCost + ItemList.FT.PayCost);

                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//PShouldCost;//
                        ItemList.Item.ID = "Y002";
                        ItemList.Item.Name = "成药费(公费到自费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "002";
                        ItemList.Item.MinFee.ID = "002";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}

                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }


                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }

                    }
                    //草药
                    if (CShouldCost > 0)
                    {
                        ItemList.FT.OwnCost = CShouldCost;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(CShouldCost * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(CShouldCost + ItemList.FT.PayCost);
                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//CShouldCost;  //
                        ItemList.Item.ID = "Y003";
                        ItemList.Item.Name = "草药费(公费到自费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "003";
                        ItemList.Item.MinFee.ID = "003";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}

                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }


                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }
                    }
                    return 0;
                    #endregion
                }
                //如果超标金额小于0，但存在自费药，需要把自费部分调整为公费部分
                if (pInfo.FT.OvertopCost < 0)
                {
                    #region 从自费转为公费
                    //查看是否有需要调整的自费药
                    ArrayList al;
                    al = this.QueryFeeInfosGroupByMinFeeForAdjustByInpatientNO(pInfo.ID);
                    if (al == null)
                    {
                        return -1;
                    }
                    if (al.Count == 0)
                    {
                        return 0;
                    }
                    //限额剩余
                    decimal overTop = pInfo.FT.OvertopCost;
                    //西药费自费部分
                    decimal WOwnCost = 0m;
                    //草药费自费部分
                    decimal COwnCost = 0m;
                    //成药费自费部分
                    decimal POwnCost = 0m;
                    //西药费调整部分
                    decimal WAdjust = 0m;
                    //成药费调整部分
                    decimal PAdjust = 0m;
                    //草药费调整部分
                    decimal CAdjust = 0m;
                    //循环得到中西草药费各部分值
                    for (int i = 0; i < al.Count; i++)
                    {
                        Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo fInfo;
                        fInfo = (Neusoft.HISFC.Models.Fee.Inpatient.FeeInfo)al[i];
                        if (fInfo.Item.MinFee.ID == "001") WOwnCost = fInfo.FT.OwnCost;
                        if (fInfo.Item.MinFee.ID == "002") POwnCost = fInfo.FT.OwnCost;
                        if (fInfo.Item.MinFee.ID == "003") COwnCost = fInfo.FT.OwnCost;
                    }
                    //如果各项都为0，返回
                    if (WOwnCost == 0 && POwnCost == 0 && COwnCost == 0) return 0;
                    //计算金额分配情况
                    if (WOwnCost > 0)
                    {
                        if (WOwnCost + overTop >= 0)
                        {
                            WAdjust = overTop;
                            overTop = 0;
                        }
                        else
                        {
                            WAdjust = -WOwnCost;
                            overTop = overTop + WOwnCost;
                        }
                    }
                    if (POwnCost > 0 && overTop < 0)
                    {
                        if (POwnCost + overTop >= 0)
                        {
                            PAdjust = overTop;
                            overTop = 0;
                        }
                        else
                        {
                            PAdjust = -POwnCost;
                            overTop = overTop + POwnCost;
                        }
                    }
                    if (COwnCost > 0 && overTop < 0)
                    {
                        if (COwnCost + overTop >= 0)
                        {
                            CAdjust = overTop;
                            overTop = 0;
                        }
                        else
                        {
                            CAdjust = -COwnCost;
                        }
                    }
                    //取当前时间
                    DateTime dtNow = this.GetDateTimeFromSysDateTime();

                    //取患者费用比例					
                    Neusoft.HISFC.Models.Base.PactInfo PactUnitInfo = new Neusoft.HISFC.Models.Base.PactInfo();
                    Neusoft.HISFC.BizLogic.Fee.PactUnitInfo PactManagment = new PactUnitInfo();
                    //PactManagment.SetTrans(this.command.Transaction);
                    PactUnitInfo = PactManagment.GetPactUnitInfoByPactCode(pInfo.Pact.ID);


                    // 插入自费药调整
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
                    Neusoft.HISFC.Models.Pharmacy.Item Drug = new Neusoft.HISFC.Models.Pharmacy.Item();
                    ItemList.Item = Drug;
                    // 赋值
                    //ItemList.RecipeNO= this.GetDrugNewNoteNo();  //处方号
                    //ItemList.SequenceNO=1; // 处方内流水号
                    //ItemList.Item.MinFee.ID="A01";//最小费用代码
                    //ItemList.Item.MinFee.ID="A01";
                    //ItemList.Item.ID="FA01";      //项目编码
                    //ItemList.Item.Name="自费药调整"; //项目名称


                    //这里注意是要再次修改的，加另外的字段标记是公费比例调整
                    //ItemList.TransType=;  //交易类型-3为调整



                    ((PatientInfo)ItemList.Patient).PVisit.PatientLocation.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;//在院科室
                    //ItemList.NurseStation.ID=pInfo.PVisit.PatientLocation.NurseCell.ID; //护士站
                    ItemList.ExecOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.StockOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.RecipeOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
                    ItemList.RecipeOper.ID = pInfo.PVisit.AdmittingDoctor.ID; //医生
                    //ItemList.Item.Price=pInfo.FT.OvertopCost;
                    ItemList.Item.Qty = 1;//数量
                    //ItemList.NoBackQty=0;
                    ItemList.Item.PriceUnit = "次";
                    //ItemList.FT.TotCost=pInfo.FT.OvertopCost;
                    //ItemList.FT.OwnCost=pInfo.FT.OvertopCost;
                    //ItemList.Item.IsPharmacy = true;
                    ItemList.Item.ItemType = EnumItemType.Drug;
                    ItemList.PayType = PayTypes.Balanced;
                    ItemList.IsBaby = false;

                    ItemList.BalanceNO = 0;
                    ItemList.BalanceState = "0";
                    ItemList.NoBackQty = 1;
                    ItemList.ChargeOper.ID = this.Operator.ID;
                    ItemList.ChargeOper.OperTime = dtNow; //划价时间
                    ItemList.FeeOper.ID = this.Operator.ID;
                    ItemList.FeeOper.OperTime = dtNow;
                    ItemList.ChargeOper.OperTime = dtNow;
                    ItemList.Item.PackQty = 1;

                    if (WAdjust < 0)
                    {//调整西药费
                        ItemList.FT.OwnCost = WAdjust;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(WAdjust * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(WAdjust + ItemList.FT.PayCost);

                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//-WAdjust; //
                        ItemList.Item.ID = "Y001";
                        ItemList.Item.Name = "西药费(自费到公费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "001";
                        ItemList.Item.MinFee.ID = "001";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}

                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }


                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }
                    }
                    if (PAdjust < 0)
                    {//调整成药费
                        ItemList.FT.OwnCost = PAdjust;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(PAdjust * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(PAdjust + ItemList.FT.PayCost);

                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//-PAdjust;//
                        ItemList.Item.ID = "Y002";
                        ItemList.Item.Name = "成药费(自费到公费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "002";
                        ItemList.Item.MinFee.ID = "002";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}

                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }

                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }
                    }
                    if (CAdjust < 0)
                    {//调整草药费
                        ItemList.FT.OwnCost = CAdjust;
                        ItemList.FT.PayCost = -Neusoft.FrameWork.Public.String.FormatNumber(CAdjust * PactUnitInfo.Rate.PayRate, 2);
                        ItemList.FT.TotCost = 0;
                        ItemList.FT.PubCost = -(CAdjust + ItemList.FT.PayCost);
                        //ItemList.Item.Qty=-ItemList.Item.Qty;
                        ItemList.Item.Price = 0;//-CAdjust;  //
                        ItemList.Item.ID = "Y003";
                        ItemList.Item.Name = "草药费(自费到公费)";
                        //最小费用
                        ItemList.Item.MinFee.ID = "003";
                        ItemList.Item.MinFee.ID = "003";
                        ItemList.RecipeNO = GetDrugRecipeNO();
                        ItemList.SequenceNO = 1;

                        //费用明细表
                        if (this.InsertMedItemList(pInfo, ItemList) == -1)
                        {

                            return -1;

                        }
                        //费用汇总表
                        //						if(this.UpdateAccount(pInfo,ItemList)==-1)
                        //						{
                        //							
                        //							return -1 ;
                        //						}

                        parm = this.UpdateInMainInfoFee(pInfo.ID, ItemList.FT);
                        if (parm == -1)
                        {
                            this.Err = "更新住院主表失败!";
                            return -1;
                        }
                        if (parm == 0)
                        {
                            this.Err = "患者已结算或者处于封账状态，不能收费，请与住院处联系!";
                            return -1;
                        }

                        //更新公费日限额累计和超标金额
                        if (this.UpdateLimitOverTop(pInfo.ID, -ItemList.FT.OwnCost) < 1)
                        {
                            return -1;
                        }
                    }

                    #endregion
                }
            }
            return 0;
        }
        /// <summary>
        /// 更新个人上次固定费用计费时间
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <param name="PreFixFeeDateTime"></param>
        /// <returns></returns>
        public int UpdateFixFeeDateByPerson(string InpatientNo, string PreFixFeeDateTime)
        {
            string strSql = "";
            if (this.Sql.GetSql("FixFee.SetPatientPreFixFeeDate", ref strSql) == -1) return -1;
            try
            {
                strSql = string.Format(strSql, InpatientNo, PreFixFeeDateTime);
            }
            catch (Exception e)
            {
                this.Err = "更新上次固定费用计费时间FixFee.SetUpdatePreFixFeeDateTime!" + e.Message;
                WriteErr();
                return -1;
            }

            if (this.ExecNoQuery(strSql) == -1) return -1;
            return 0;
        }
        #region 根据明细表中数据更新主表费用
        /// <summary>
        /// 从患者明细中查询患者费用
        /// </summary>
        /// <param name="InpatientNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.FT SumCostFromDetail(string InpatientNo)
        {
            //定义字符串 存储SQL语句
            string strSql = "";
            string strReturn = "";

            //获取SQL语句
            if (this.Sql.GetSql("Fee.Report.SumCostFromDetail", ref strSql) == -1)
            {
                this.Err = "没有找到 Fee.Report.SumCostFromDetail 字段!";
                this.ErrCode = "-1";
                return null;
            }
            //格式化字符串
            strSql = string.Format(strSql, InpatientNo, "1",
                "1", "1", "1", "1", "1", "1", "1", "1");

            if (this.ExecEvent(strSql, ref strReturn) == -1)
            {
                this.Err = "执行存储过程出错!Fee.Report.SumCostFromDetail";
                this.ErrCode = "Fee.Report.SumCostFromDetail";
                this.WriteErr();
                return null;
            }

            string[] s = strReturn.Split(',');
            Neusoft.HISFC.Models.Base.FT obj = new Neusoft.HISFC.Models.Base.FT();

            try
            {
                obj.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[0]), 2);
                obj.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[1]), 2);
                obj.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[2]), 2);
                obj.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[3]), 2);
                obj.LeftCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[4]), 2);
                obj.DrugFeeTotCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[5]), 2);
                obj.OvertopCost = Neusoft.FrameWork.Public.String.FormatNumber(NConvert.ToDecimal(s[6]), 2);
            }
            catch (Exception ex)
            {
                this.ErrCode = "-1";
                this.Err += ex.Message;
                return null;
            }
            return obj;
        }
        /// <summary>
        /// 根据患者费用明细，更新患者主表各项费用
        /// </summary>
        /// <param name="InpatientNo">住院流水号</param>
        /// <returns></returns>
        public int UpdateInMainInfoCost(string InpatientNo)
        {
            Neusoft.HISFC.Models.Base.FT ft = this.SumCostFromDetail(InpatientNo);
            if (ft == null) return -1;
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.UpdateInMainInfoCost", ref strSql) == -1)
            {
                this.Err = "找不到SQL语句 Fee.Inpatient.UpdateInMainInfoCost";
                return -1;
            }
            try
            {
                strSql = string.Format(strSql, InpatientNo,
                    ft.TotCost.ToString(),
                    ft.OwnCost.ToString(),
                    ft.PayCost.ToString(),
                    ft.PubCost.ToString(),
                    ft.LeftCost.ToString(),
                    ft.OvertopCost.ToString(),
                    ft.DrugFeeTotCost.ToString());
                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public int UpdatePatientsCost(ArrayList al)
        {
            if (al == null) return 0;
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo info in al)
            {
                if (this.UpdateInMainInfoCost(info.ID) == -1)
                    return -1;
            }
            return 1;
        }

        /// <summary>
        /// 更新医保患者基本信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateSiPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo info)
        {
            string strSql = "";
            if (this.Sql.GetSql("Fee.Inpatient.UpdateSiPatientInfo", ref strSql) == -1)
            {
                this.Err = "Can't Find Sql:Fee.Inpatient.UpdateSiPatientInfo";
                return -1;
            }
            strSql = System.String.Format(strSql, info.SSN, info.ID);
            return this.ExecNoQuery(strSql);
        }
        #endregion

        #region 监护床---
        static ArrayList _IcuBedList = null;
        /// <summary>
        /// 监护床列表
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ArrayList IcuBedList(System.Data.OracleClient.OracleTransaction t)
        {

            //如果数据为null,则表示第一次加载,从数据库中提取
            if (_IcuBedList == null)
            {
                _IcuBedList = new ArrayList();
                Neusoft.HISFC.BizLogic.Manager.Constant cons = new Neusoft.HISFC.BizLogic.Manager.Constant();
                cons.SetTrans(t);
                _IcuBedList = cons.GetList("FIN_ICUBED");
                if (_IcuBedList == null)
                    return null;
                else
                    return _IcuBedList;
            }
            else
            {
                return _IcuBedList;
            }

        }
        /// <summary>
        /// 该项目是否是监护床
        /// </summary>
        /// <param name="BedID"></param>
        /// <returns></returns>
        public bool IsIcuBedList(string BedID)
        {
            ArrayList al = null;//IcuBedList(this.command.Transaction);
            if (al == null) return false;
            foreach (Neusoft.HISFC.Models.Base.Const cons in al)
            {
                if (cons.ID == BedID)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        //{1E64A9A8-F0CC-449d-B16C-1C8B6D226839}
        #region  费用组套
        /// <summary>
        /// 查询费用组套
        /// </summary>
        /// <param name="patientNO">住院流水号</param>
        /// <param name="nurseCode">护理站编码</param>
        /// <returns></returns>
        public ArrayList QueryPatientFeeGroup(string patientNO, string nurseCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.FeeGroup.Select", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.FeeGroup.Select的SQL语句失败！";
                return null;
            }
            sql = string.Format(sql, patientNO, nurseCode);
            return GetPatientFeeGroupBySql(sql);
        }

        /// <summary>
        /// 根据SQL获取费用组套信息
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private ArrayList GetPatientFeeGroupBySql(string sql)
        {
            if (this.ExecQuery(sql) == -1)
            {
                this.Err = "查询费用组套数据失败！";
                return null;
            }
            ArrayList al = new ArrayList();
            FeeGroup feeGroup = null;
            while (this.Reader.Read())
            {
                feeGroup = new FeeGroup();
                feeGroup.ID = this.Reader[0].ToString();
                feeGroup.Patient.ID = this.Reader[1].ToString();
                feeGroup.NurseCell.ID = this.Reader[2].ToString();
                feeGroup.Item.ID = this.Reader[3].ToString();
                feeGroup.Item.Name  = this.Reader[4].ToString();
                feeGroup.DrugFlag = this.Reader[5].ToString();
                feeGroup.Item.Qty = NConvert.ToDecimal(this.Reader[6].ToString());
                feeGroup.Days = NConvert.ToDecimal(this.Reader[7]);
                feeGroup.Item.PriceUnit = this.Reader[8].ToString();
                feeGroup.FeeDate = NConvert.ToDateTime(this.Reader[9]);
                feeGroup.ExecDept.ID = this.Reader[10].ToString();
                feeGroup.Package.ID = this.Reader[11].ToString();
                feeGroup.Package.Name = this.Reader[12].ToString();
                feeGroup.Oper.ID = this.Reader[13].ToString();
                feeGroup.Oper.OperTime = NConvert.ToDateTime(this.Reader[14]);
                al.Add(feeGroup);
            }
            return al;
        }

        /// <summary>
        /// 获得费用组套流水号
        /// </summary>
        /// <returns></returns>
        public string GetFeeGroupID()
        {
            return this.GetSequence("Fee.Inpatient.FeeGroup.ID");
        }

        /// <summary>
        /// 插入费用组套
        /// </summary>
        /// <param name="feeGroup"></param>
        /// <returns></returns>
        public int InsertFeeGroup(FeeGroup feeGroup)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.FeeGroup.Insert", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.FeeGroup.Insert的SQL语句失败！";
                return -1;
            }

            sql = string.Format(sql,feeGroup.ID,feeGroup.Patient.ID,feeGroup.NurseCell.ID,feeGroup.Item.ID,
                                    feeGroup.Item.Name,feeGroup.DrugFlag,feeGroup.Item.Qty.ToString(),feeGroup.Days.ToString(),
                                    feeGroup.Item.PriceUnit,feeGroup.FeeDate.ToString(),feeGroup.ExecDept.ID,feeGroup.Package.ID,
                                    feeGroup.Package.Name,feeGroup.Oper.ID,feeGroup.Oper.OperTime.ToString());
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 删除费用组套
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="nurcellCode"></param>
        /// <returns></returns>
        public int DeleteFeeGroup(string inpatientNO, string nurcellCode)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.FeeGroup.Delete", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.FeeGroup.Delete的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, inpatientNO, nurcellCode);
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 删除费用组套{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="nurcellCode"></param>
        /// <returns></returns>
        public int DeleteFeeGroup(string groupID)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.FeeGroup.DeleteByGroupID", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.FeeGroup.Delete的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, groupID);
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新费用组套搜费时间
        /// </summary>
        /// <param name="feeGroupId">费用组套项目编码</param>
        /// <param name="feeDate">收费时间</param>
        /// <returns></returns>
        public int UpdateFeeGroupFeeDate(string feeGroupId, DateTime feeDate)
        {
            string sql = string.Empty;
            if (this.Sql.GetSql("Fee.Inpatient.FeeGroup.UpdateFeeDate", ref sql) == -1)
            {
                this.Err = "查询索引为Fee.Inpatient.FeeGroup.Insert的SQL语句失败！";
                return -1;
            }
            sql = string.Format(sql, feeGroupId, feeDate.ToString());
            return this.ExecNoQuery(sql);
        }

        #endregion

        #region 郑大新增{D6A25CA7-331A-4034-BBC6-A6FF821E290C}
        /// <summary>
        /// 查询当日费用
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="fromdate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public DataSet QueryDayFeeByInpaientNO(string inpatientNO,string fromdate,string toDate,string deptCode,bool isLong)
        {
            string strSql = string.Empty;

           int returnValue = this.Sql.GetSql("Fee.QueryPaientDayFee.1", ref strSql);
           if (returnValue < 0)
           {
               this.Err = "查询Fee.QueryPaientDayFee.1对应的sql语句失败";
               return null;

           }
           try
           {
               strSql = string.Format(strSql, inpatientNO, fromdate, toDate,deptCode,Neusoft.FrameWork.Function.NConvert.ToInt32(isLong));
           }
           catch (Exception)
           {

               this.Err = "格式话sql语句失败";
           }
            DataSet ds = new DataSet ();
            returnValue = this.ExecQuery(strSql, ref ds);
            if (returnValue <0)
            {
                return null;

            }

            return ds;
        }

        #region MyRegion
        public int QueryMedicinlistForQuery(string inpatientNO,string fromDate,string toDate,ref DataSet ds)
        {
             ds = new DataSet();

            string strSql = @"select drug_name 药品名称,
                               a.specs 规格,
                               a.unit_price 单价,
                               a.qty 数量,
                               a.days 付数,
                               a.current_unit 单位,
                               a.tot_cost 金额,
                               a.own_cost 自费,
                               a.pub_cost 公费,
                               a.pay_cost 自负,
                               a.eco_cost 优惠,
                               nvl((select b.dept_name
                                     from com_department b
                                    where b.dept_code = a.execute_deptcode),
                                   a.execute_deptcode) 执行科室,
                               nvl((select b.dept_name
                                     from com_department b
                                    where b.dept_code = a.inhos_deptcode),
                                   a.inhos_deptcode) 患者科室,
                               
                               a.fee_date 收费时间,
                               nvl((select c.empl_name
                                     from com_employee c
                                    where c.empl_code = a.fee_opercode),
                                   a.fee_opercode),
                               a.senddrug_date,
                               nvl((select c.empl_name
                                     from com_employee c
                                    where c.empl_code = a.senddrug_opercode),
                                   a.senddrug_opercode)

                          from fin_ipb_medicinelist a

                         where inpatient_no = '{0}'
                           AND fee_date >= to_date('{1}', 'YYYY-MM-DD hh24:mi:ss')
                           and fee_date <= to_date('{2}', 'yyyy-mm-dd hh24:mi:ss')
                         order by fee_date
                        ";
            strSql = string.Format(strSql, inpatientNO, fromDate, toDate);

           return  this.ExecQuery(strSql, ref ds);
          
        }
        #endregion
        #endregion

        #region 郑大新增：获取终端确认状态 {B98851B0-9C5A-4d68-ABB5-CB48C4DBD34B}
        /// <summary>
        /// 获取终端确认状态
        /// </summary>
        /// <param name="execsql">执行单流水号</param>
        /// <returns>false:没有确认过 true：已经确认</returns>
        public bool GetTecFlag(string execsql)
        {
            bool ret = false;
            string sql = string.Empty;
            sql = @" select count(c.current_sequence)
                       from met_tec_inpatientconfirm c
                      where c.exec_sqn = '{0}'";
            try
            {
                sql = string.Format(sql, execsql);
            }
            catch (Exception ex)
            {

                this.Err = "获取确认状态出错" + ex.ToString();
            }
            DataSet ds = new DataSet();
            this.ExecQuery(sql, ref ds);
            string val = string.Empty;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                val = item.ItemArray.GetValue(0).ToString();
            }
            if ("0" != val)
            {
                ret = true;
            }
            return ret;
        }
        #endregion

    }
}

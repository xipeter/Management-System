using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Fee;
using Neusoft.HISFC.Models.RADT;
using Neusoft.FrameWork.Function;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.DefultInterfacesAchieve.Function
{
    public class SISpecialLimit : Neusoft.FrameWork.Management.Database
    {

        #region 私有方法

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
        /// 通过药品实体获得实体属性数组
        /// </summary>
        /// <param name="patient">人员基本信息</param>
        /// <param name="medItemList">药品费用基本信息</param>
        /// <returns>药品实体获得实体属性数组</returns>
        private string[] GetMedItemListParams(PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medItemList)
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
                    ((Neusoft.HISFC.Models.Order.Inpatient.Order)medItemList.Order).OrderType.ID,
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
                    medItemList.Item.Memo
				};

            return args;
        }
        /// <summary>
        /// 获得sql，传入参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        protected string getOutpatOrderInfo(string sql, Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            #region sql
            //   0--看诊序号 ,1 --项目流水号,2 --门诊号,3   --病历号 ,4    --挂号日期
            //   5 --挂号科室,6   --项目代码,7   --项目名称, 8  --规格, 9  --1药品，2非药品
            //   10   --系统类别,   --最小费用代码,   --单价,   --开立数量,   --付数
            //    --包装数量,   --计价单位,   --自费金额0,   --自负金额0,   --报销金额0
            //   --基本剂量,   --自制药,   --药品性质，普药、贵药,   --每次用量
            //     --每次用量单位,   --剂型代码,   --频次,   --频次名称,   --使用方法
            //     --用法名称,   --用法英文缩写,   --执行科室代码,   --执行科室名称
            //      --主药标志,   --组合号,   --1不需要皮试/2需要皮试，未做/3皮试阳/4皮试阴
            //     --院内注射次数,   --备注,   --开立医生,   --开立医生名称,   --医生科室
            //     --开立时间,   --处方状态,1开立，2收费，3确认，4作废,   --作废人,   --作废时间
            //        --加急标记0普通/1加急,   --样本类型,   --检体,   --申请单号
            //     --0不是附材/1是附材,   --是否需要确认，1需要，0不需要,   --确认人
            //        --确认科室,   --确认时间,   --0未收费/1收费,   --收费员
            //       --收费时间,   --处方号,    --处方内流水号,     --发药药房，    
            //      --开立单位是否是最小单位 1 是 0 不是，      --医嘱类型（目前没有）
            #endregion

            if (order.Item.ItemType == EnumItemType.Drug)//药品
            {
                Neusoft.HISFC.Models.Pharmacy.Item pItem = order.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                System.Object[] s = {order.SeeNO ,Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID),order.Patient.ID,order.Patient.PID.CardNO,order.RegTime,
										order.InDept.ID,pItem.ID,pItem.Name,pItem.Specs,"1",
										order.Item.SysClass.ID,order.Item.MinFee.ID,order.Item.Price,order.Qty,order.HerbalQty,
										pItem.PackQty,pItem.PriceUnit,order.FT.OwnCost ,order.FT.PayCost,order.FT.PubCost,
										pItem.BaseDose,Neusoft.FrameWork.Function.NConvert.ToInt32(pItem.Product.IsSelfMade),pItem.Quality.ID,order.DoseOnce,
										order.DoseUnit,pItem.DosageForm.ID,order.Frequency.ID,order.Frequency.Name,order.Usage.ID,
										order.Usage.Name,order.Usage.Memo,order.ExeDept.ID,order.ExeDept.Name,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug),order.Combo.ID,order.HypoTest,
										order.InjectCount,order.Memo,order.ReciptDoctor.ID,order.ReciptDoctor.Name,order.ReciptDept.ID,
										order.MOTime,order.Status,order.DCOper.ID,order.DCOper.OperTime,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsEmergency),order.Sample.Name,order.CheckPartRecord,order.ID,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsNeedConfirm),order.ConfirmOper.ID,
										order.ConfirmOper.Dept.ID,order.ConfirmOper.OperTime,Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsHaveCharged),order.ChargeOper.ID,
										order.ChargeOper.OperTime,order.ReciptNO,order.SequenceNO,
                                        order.StockDept.ID,order.NurseStation.User03,"",
                                        order.NurseStation.User01,order.ExtendFlag1,
										order.ReciptSequence,order.NurseStation.Memo,order.SortID,order.Item.Memo};

                try
                {
                    string sReturn = string.Format(sql, s);
                    return sReturn;
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
            else//非药品
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug pItem = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
                System.Object[] s = {order.SeeNO,Neusoft.FrameWork.Function.NConvert.ToInt32(order.ID),order.Patient.ID,order.Patient.PID.CardNO,order.RegTime,
										order.InDept.ID,pItem.ID,pItem.Name,pItem.Specs,"2",
										order.Item.SysClass.ID,order.Item.MinFee.ID,order.Item.Price,order.Qty,order.HerbalQty,
										pItem.PackQty,pItem.PriceUnit,order.FT.OwnCost ,order.FT.PayCost,order.FT.PubCost,
										"0",0,"",order.DoseOnce,
										order.DoseUnit,"",order.Frequency.ID,order.Frequency.Name,order.Usage.ID,
										order.Usage.Name,order.Usage.Memo,order.ExeDept.ID,order.ExeDept.Name,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.Combo.IsMainDrug),order.Combo.ID,order.HypoTest,
										order.InjectCount,order.Memo,order.ReciptDoctor.ID,order.ReciptDoctor.Name,order.ReciptDept.ID,
										order.MOTime,order.Status,order.DCOper.ID,order.DCOper.OperTime,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsEmergency),order.Sample.Name,order.CheckPartRecord,order.ID,
										Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsNeedConfirm),order.ConfirmOper.ID,
										order.ConfirmOper.Dept.ID,order.ConfirmOper.OperTime,Neusoft.FrameWork.Function.NConvert.ToInt32(order.IsHaveCharged),order.ChargeOper.ID,
										order.ChargeOper.OperTime,order.ReciptNO,order.SequenceNO,
                                        order.StockDept.ID,order.NurseStation.User03,"",
                                        order.NurseStation.User01,order.ExtendFlag1,
										order.ReciptSequence,order.NurseStation.Memo,order.SortID,order.Item.Memo};
                try
                {
                    string sReturn = string.Format(sql, s);
                    return sReturn;
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                    return null;
                }

            }

        }
        /// <summary>
        /// 获得医嘱信息
        /// </summary>
        /// <param name="sqlOrder"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        private string getOrderInfo(string sqlOrder, Neusoft.HISFC.Models.Order.Inpatient.Order Order)
        {
            #region "接口说明"
            //0 ID医嘱流水号
            //患者信息——  
            //			1 住院流水号   2住院病历号     3患者科室id      4患者护理id
            //医嘱辅助信息
            // ——项目信息
            //	       5项目类别      6项目编码       7项目名称      8项目输入码,    9项目拼音码 
            //	       10项目类别代码 11项目类别名称  12药品规格     13药品基本剂量  14剂量单位       
            //         15最小单位     16包装数量,     17剂型代码     18药品类别  ,   19药品性质
            //         20零售价       21用法代码      22用法名称     23用法英文缩写  24频次代码  
            //         25频次名称     26每次剂量      27项目总量     28计价单位      29使用天数			  
            // ——医嘱属性
            //		   30医嘱类别代码 31医嘱类别名称  32医嘱是否分解:1长期/2临时     33是否计费 
            //		   34药房是否配药 35打印执行单    36是否需要确认  
            // ——执行情况
            //		   37开立医师Id   38开立医师name  39开始时间      40结束时间     41开立科室
            //		   42开立时间     43录入人员代码  44录入人员姓名  45审核人ID     46审核时间       
            //		   47DC原因代码   48DC原因名称    49DC医师代码    50DC医师姓名   51Dc时间
            //         52执行人员代码 53执行时间      54执行科室代码  55执行科室名称 
            //		   56本次分解时间 57下次分解时间
            // ——医嘱类型
            //		   58是否婴儿（1是/2否）          59发生序号  	  60组合序号     61主药标记 
            //		   62是否附材'1'  63是否包含附材  64医嘱状态      65扣库标记     66执行标记1未执行/2已执行/3DC执行 
            //		   67医嘱说明                     68加急标记:1普通/2加急         69排列序号
            //         70检查部位备注                 71批注          72整档,          73 样本类型名称,
            //         74 取药药房编码 
            #endregion
            string strItemType = "";
            if (Order.CurMOTime == DateTime.MinValue)
            {
                Order.CurMOTime = Order.BeginTime;
            }
            if (Order.NextMOTime == DateTime.MinValue)
            {
                Order.NextMOTime = Order.BeginTime;
            }
            //判断药品/非药品

            if (Order.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
            {
                Neusoft.HISFC.Models.Pharmacy.Item objPharmacy;
                objPharmacy = (Neusoft.HISFC.Models.Pharmacy.Item)Order.Item;
                strItemType = "1";
                try
                {
                    System.Object[] s ={Order.ID,Order.Patient.ID,Order.Patient.PID.PatientNO,Order.Patient.PVisit.PatientLocation.Dept.ID,Order.Patient.PVisit.PatientLocation.NurseCell.ID,
										  strItemType,Order.Item.ID,Order.Item.Name,Order.Item.UserCode,Order.Item.SpellCode,
										  Order.Item.SysClass.ID.ToString(),Order.Item.SysClass.Name,objPharmacy.Specs,objPharmacy.BaseDose,objPharmacy.DoseUnit,objPharmacy.MinUnit,objPharmacy.PackQty,
										  objPharmacy.DosageForm.ID,objPharmacy.Type.ID,objPharmacy.Quality.ID,objPharmacy.PriceCollection.RetailPrice,
										  Order.Usage.ID,Order.Usage.Name,Order.Usage.Memo,Order.Frequency.ID,Order.Frequency.Name,
										  Order.DoseOnce,Order.Qty,Order.Unit,Order.HerbalQty.ToString(),
										  Order.OrderType.ID,Order.OrderType.Name,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsDecompose),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsCharge),
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsNeedPharmacy),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsPrint),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsConfirm),
										  Order.ReciptDoctor.ID,Order.ReciptDoctor.Name,Order.BeginTime,Order.EndTime,Order.ReciptDept.ID,
										  Order.MOTime,Order.Oper.ID,Order.Oper.Name,Order.Nurse.ID,Order.ConfirmTime,
										  Order.DcReason.ID,Order.DcReason.Name,Order.DCOper.ID,Order.DCOper.Name,Order.DCOper.OperTime,
										  Order.ExecOper.ID,Order.ExecOper.OperTime,Order.ExeDept.ID,Order.ExeDept.Name,
										  Order.CurMOTime,Order.NextMOTime,
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsBaby),Order.BabyNO,Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Combo.IsMainDrug),
										  Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsSubtbl),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsHaveSubtbl),Order.Status,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsStock),Order.ExecStatus,
										  Order.Note,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsEmergency),Order.SortID,Order.Memo,Order.CheckPartRecord,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Reorder),Order.Sample.Name,Order.StockDept.ID,
										  objPharmacy.IsAllergy==true ?"2":"1",Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsPermission),Order.Package.ID,Order.Package.Name,Order.ExtendFlag1,Order.ExtendFlag2,Order.ExtendFlag3,
                                          Order.Frequency.Time,Order.ExecDose,Order.Item.Memo};//新加特殊频次

                    string myErr = "";
                    if (Neusoft.FrameWork.Public.String.CheckObject(out myErr, s) == -1)
                    {
                        this.Err = myErr;
                        this.WriteErr();
                        return null;
                    }
                    sqlOrder = string.Format(sqlOrder, s);
                }
                catch (Exception ex)
                {
                    this.Err = "付数值时候出错！" + ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
            else if (Order.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug objAssets;
                objAssets = (Neusoft.HISFC.Models.Fee.Item.Undrug)Order.Item;
                strItemType = "2";

                try
                {
                    string[] s ={Order.ID,Order.Patient.ID,Order.Patient.PID.PatientNO,Order.Patient.PVisit.PatientLocation.Dept.ID,Order.Patient.PVisit.PatientLocation.NurseCell.ID,
								   strItemType,Order.Item.ID,Order.Item.Name,Order.Item.UserCode,Order.Item.SpellCode,
								   Order.Item.SysClass.ID.ToString(),Order.Item.SysClass.Name,objAssets.Specs,"0","","","0","","","",objAssets.Price.ToString(),
								   Order.Usage.ID,Order.Usage.Name,Order.Usage.Memo,Order.Frequency.ID,Order.Frequency.Name,
								   Order.DoseOnce.ToString(),Order.Qty.ToString(),Order.Unit,Order.HerbalQty.ToString(),
								   Order.OrderType.ID,Order.OrderType.Name,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsDecompose).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsCharge).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsNeedPharmacy).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsPrint).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.OrderType.IsConfirm).ToString(),
								   Order.ReciptDoctor.ID,Order.ReciptDoctor.Name,Order.BeginTime.ToString(),Order.EndTime.ToString(),Order.ReciptDept.ID,
								   Order.MOTime.ToString(),Order.Oper.ID,Order.Oper.Name,Order.Nurse.ID,Order.ConfirmTime.ToString(),
								   Order.DcReason.ID,Order.DcReason.Name,Order.DCOper.ID,Order.DCOper.Name,Order.DCOper.OperTime.ToString(),
								   Order.ExecOper.ID,Order.ExecOper.OperTime.ToString(),Order.ExeDept.ID,Order.ExeDept.Name,
								   Order.CurMOTime.ToString(),Order.NextMOTime.ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsBaby).ToString(),Order.BabyNO.ToString(),Order.Combo.ID,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Combo.IsMainDrug).ToString(),
								   Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsSubtbl).ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsHaveSubtbl).ToString(),Order.Status.ToString(),Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsStock).ToString(),Order.ExecStatus.ToString(),
								   Order.Note,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsEmergency).ToString(),Order.SortID.ToString(),Order.Memo,Order.CheckPartRecord,Neusoft.FrameWork.Function.NConvert.ToInt32(Order.Reorder).ToString(),Order.Sample.Name,Order.StockDept.ID,
								   "",Neusoft.FrameWork.Function.NConvert.ToInt32(Order.IsPermission).ToString(),Order.Package.ID,Order.Package.Name,Order.ExtendFlag1,Order.ExtendFlag2,Order.ExtendFlag3,
                                   Order.Frequency.Time,Order.ExecDose,Order.Item.Memo};//新加特殊频次
                    sqlOrder = string.Format(sqlOrder, s);
                }
                catch (Exception ex)
                {
                    this.Err = "付数值时候出错！" + ex.Message;
                    this.WriteErr();
                    return null;
                }
            }
            else
            {
                this.Err = "项目类型出错！";
                return null;
            }
            return sqlOrder;
        }

        /// <summary>
        /// 获得insert表的传入参数数组update
        /// </summary>
        /// <param name="feeItemList">费用明细实体</param>
        /// <returns>字符串数组</returns>
        private string[] GetOutFeeItemListParams(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
        {
            string[] args = new string[77];

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
            args[11] = NConvert.ToInt32(feeItemList.Item.ItemType == EnumItemType.Drug).ToString();//DRUG_FLAG;	--		1药品/0非要					11
            args[12] = feeItemList.Item.Specs;//SPECS;		--		规格										12
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
            args[20] = feeItemList.Days.ToString();//DAYS;		--		草药的付数，其他药品为1			20	
            args[21] = feeItemList.Order.Frequency.ID;//FREQUENCY_CODE;	--		频次代码						21	
            args[22] = feeItemList.Order.Usage.ID;//USAGE_CODE;	--		用法代码							22	
            args[23] = feeItemList.Order.Usage.Name;//USE_NAME;	--		用法名称							23
            args[24] = feeItemList.InjectCount.ToString();//INJECT_NUMBER;	--		院内注射次数		24	
            args[25] = NConvert.ToInt32(feeItemList.IsUrgent).ToString();//EMC_FLAG;	--		加急标记:1加急/0普通			25	
            args[26] = feeItemList.Order.Sample.ID;//LAB_TYPE;	--		样本类型							26	
            args[27] = feeItemList.Order.CheckPartRecord;//CHECK_BODY;	--		检体								27	
            args[28] = feeItemList.Order.DoseOnce.ToString();//DOSE_ONCE;	--		每次用量					28
            args[29] = feeItemList.Order.DoseUnit;//DOSE_UNIT;	--		每次用量单位							29
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
            args[47] = feeItemList.FeeOper.OperTime.ToString();//FEE_DATE;	--		收费日期					47	
            args[48] = feeItemList.Invoice.ID;//INVOICE_NO;	--		票据号								48	
            args[49] = "";//INVO_CODE;	--		发票科目代码				49
            args[50] = "";//INVO_SEQUENCE;	--		发票内流水号		50
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
            args[76] = feeItemList.Item.Memo;

            return args;
        }

        #endregion

        #region 共有方法

        /// <summary>
        /// 添加患者项目费用-插入药品费用明细表信息
        /// </summary>
        /// <param name="patient">患者信息</param>
        /// <param name="medItemList">药品费用项目信息</param>
        /// <param name="Insurance">医保的项目相关信息</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据: 0</returns>
        public int InsertMedItemList(PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medItemList)
        {
            if (medItemList.Patient.Pact.ID == null || medItemList.Patient.Pact.ID.Trim() == string.Empty)
            {
                medItemList.Patient.Pact.ID = patient.Pact.ID;
            }

            if (medItemList.Patient.Pact.PayKind.ID == null || medItemList.Patient.Pact.PayKind.ID.Trim() == string.Empty)
            {
                medItemList.Patient.Pact.PayKind.ID = patient.Pact.PayKind.ID;
            }

            return this.UpdateSingleTable("SI.AddSpecialLimitDrug.1", this.GetMedItemListParams(patient, medItemList));
        }

        /// <summary>
        /// 删除一条适用症住院明细
        /// </summary>
        /// <param name="medItemList"></param>
        /// <returns></returns>
        public int DeleteMedItemList(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medItemList)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.DeleteItemPracticableSymptom.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return -1;
            }
            try
            {
                sql = string.Format(sql, medItemList.RecipeNO, medItemList.SequenceNO, ((int)medItemList.TransType).ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }
            
            return this.ExecNoQuery(sql);
        }

        /// <summary>
        /// 检查住院项目是否符合适应症
        /// </summary>
        /// <param name="medItemList"></param>
        /// <returns></returns>
        public bool CheckItemPracticableSymptom(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList medItemList)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.CheckItemPracticableSymptom.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return false;
            }
            try
            {
                sql = string.Format(sql, medItemList.RecipeNO, medItemList.SequenceNO, ((int)medItemList.TransType).ToString());
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToBoolean(myresult);
        }

        /// <summary>
        /// 检查住院医嘱是否符合适应症
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool CheckOrderPracticableSymptom(string orderID)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.CheckOrderPracticableSymptom.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return false;
            }
            try
            {
                sql = string.Format(sql, orderID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToBoolean(myresult);
        }
        /// <summary>
        /// 检查门诊医嘱是否符合适应症SeeNO
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public bool CheckClinicOrderPracticableSymptom(string orderID)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.CheckClinicOrderPracticableSymptom.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return false;
            }
            try
            {
                sql = string.Format(sql, orderID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToBoolean(myresult);
        }

        /// <summary>
        /// 开立新医嘱(插入新医嘱记录)
        /// </summary>
        /// <param name="order"></param>
        /// <returns>0 success -1 fail</returns>
        public int InsertOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            #region 开立新医嘱
            //开立新医嘱
            //Order.Order.CreateOrder.1
            //传入：71
            //			//传出：0 
            #endregion

            string strSql = "";

            if (this.Sql.GetSql("SI.Order.Order.CreateOrder.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = getOrderInfo(strSql, order);
            if (strSql == null) return -1;

            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        /// 开立门诊新医嘱(插入新医嘱记录)
        /// </summary>
        /// <param name="order"></param>
        /// <returns>0 success -1 fail</returns>
        public int InsertOutpatOrder(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            #region 开立新医嘱
            //开立新医嘱
            //Order.Order.CreateOrder.1
            //传入：71
            //			//传出：0 
            #endregion

            string strSql = "";

            if (this.Sql.GetSql("SI.Order.Order.CreateOrder.OutPatient.1", ref strSql) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            strSql = getOutpatOrderInfo(strSql, order);
            if (strSql == null) return -1;

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 删除一条住院适用症医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int DeleteOrder(Neusoft.HISFC.Models.Order.Inpatient.Order order)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.Order.Order.DeleteOrder.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return -1;
            }
            try
            {
                sql = string.Format(sql, order.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }
        /// <summary>
        /// 删除一条门诊适用症医嘱
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int DeleteOutpatOrder(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.Order.Order.DeleteOrder.OutPatient.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return -1;
            }
            try
            {
                sql = string.Format(sql, order.SeeNO, order.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }


        /// <summary>
        /// 插入门诊费用明细
        /// </summary>
        /// <param name="feeItemList">费用明细实体</param>
        /// <returns>成功: 1 失败: -1 没有插入数据返回 0</returns>
        public int InsertFeeItemList(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
        {
            return this.UpdateSingleTable("SI.Fee.Item.GetFeeItemDetail.Insert", this.GetOutFeeItemListParams(feeItemList));
        }

        /// <summary>
        /// 检查住院项目是否符合适应症
        /// </summary>
        /// <param name="medItemList"></param>
        /// <returns></returns>
        public bool CheckClinicItemPracticableSymptom(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.CheckClinicItemPracticableSymptom.1", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return false;
            }
            try
            {
                sql = string.Format(sql, feeItemList.RecipeNO, feeItemList.SequenceNO, ((int)feeItemList.TransType).ToString(), feeItemList.Order.ID, feeItemList.InvoiceCombNO);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return false;
            }
            string myresult = this.ExecSqlReturnOne(sql);

            return Neusoft.FrameWork.Function.NConvert.ToBoolean(myresult);
        }

        /// <summary>
        /// 删除一条适用症门诊明细
        /// </summary>
        /// <param name="feeItemList"></param>
        /// <returns></returns>
        public int DeleteFeeItemList(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItemList)
        {
            string sql = string.Empty;//Update语句

            //获得Where语句
            if (this.Sql.GetSql("SI.Fee.Item.GetFeeItemDetail.Delete", ref sql) == -1)
            {
                this.Err = "没有找到索引为: 的SQL语句";

                return -1;
            }
            try
            {
                sql = string.Format(sql, feeItemList.RecipeNO, feeItemList.SequenceNO, ((int)feeItemList.TransType).ToString(), feeItemList.Order.ID, feeItemList.InvoiceCombNO);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = ex.Message;
                return -1;
            }

            return this.ExecNoQuery(sql);
        }

        #endregion

    }
}

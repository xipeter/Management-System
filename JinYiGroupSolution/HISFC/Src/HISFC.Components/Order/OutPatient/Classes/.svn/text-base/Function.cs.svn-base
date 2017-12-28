using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using Neusoft.HISFC.Models.Base;

namespace Neusoft.HISFC.Components.Order.OutPatient.Classes
{
    public class Function
    {
        public Function()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            //查询全部医嘱参数
            ArrayList alControler = controler.QueryControlerInfoByKind("MET");
            if (alControler == null)
            {
                MessageBox.Show("获取医嘱控制参数出错，系统将按照默认值进行操作！");
            }
            else
            {
                Function.controlerHelper.ArrayObject = alControler;
            }
            
			
		}
		/// <summary>
		/// 参数管理类
		/// </summary>
        private static Neusoft.HISFC.BizProcess.Integrate.Manager controler = new Neusoft.HISFC.BizProcess.Integrate.Manager();
		/// <summary>
		/// 存储项目信息
		/// </summary>
		public  static Hashtable hsItemInfo = new Hashtable();
		/// <summary>
		/// 用法和附材
		/// </summary>
		public  static Hashtable hsUsageAndSub = new Hashtable();
		//全局控制参数帮助类
		public static Neusoft.FrameWork.Public.ObjectHelper controlerHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        public static Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();



		/// <summary>
		///  插入费用档
		/// </summary>
		/// <param name="fee"></param>//收费管理类
		/// <param name="order"></param>//医嘱实体
		/// <param name="reciptNo"></param>//处方号
		/// <param name="seqNo"></param>//处方流水号
		/// <param name="dtNow"></param>//操作时间
		/// <returns></returns>
		public static int SaveToFee(Neusoft.HISFC.BizProcess.Integrate.Fee fee,Neusoft.HISFC.Models.Order.OutPatient.Order order,string reciptNo,int seqNo,DateTime dtNow)
		{
			Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitemlist = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();
			
			feeitemlist.Item.Qty = order.Item.Qty; //记价数量
			feeitemlist.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;//操作类型
			feeitemlist.Patient.ID = order.Patient.PID.ID;//门诊流水号
			feeitemlist.Patient.PID.CardNO = order.Patient.PID.CardNO;//门诊卡号 
			
			feeitemlist.ChargeOper.OperTime = dtNow;//划价日期
			feeitemlist.ChargeOper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;//划价人
			feeitemlist.Order.CheckPartRecord = order.CheckPartRecord;//检体 
			feeitemlist.Order.Combo.ID = order.Combo.ID ;//组合号
			if(order.Unit == "[复合项]")//如果是复合项目，置标记
			{
				feeitemlist.IsGroup = true;
				feeitemlist.UndrugComb.ID = order.User01;
				feeitemlist.UndrugComb.Name = order.User02;
			}
			
			//if(order.Item.IsPharmacy)
            if (order.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
			{
				feeitemlist.ExecOper.Dept = order.StockDept.Clone();//传扣库科室，by zuowy
			}
			else
			{
                feeitemlist.ExecOper.Dept = order.ExeDept.Clone();//传执行科室
			}
			feeitemlist.InjectCount = order.InjectCount;//院内次数

			if(order.Item.PackQty <=0)//包装单位为0，赋1
			{
				order.Item.PackQty = 1;
			}
			order.FT.OwnCost = order.Qty*order.Item.Price/order.Item.PackQty;//自付金额
            feeitemlist.FT = Round(order,2);//取两位
			feeitemlist.Days = order.HerbalQty ;//草药付数
			feeitemlist.Order.ReciptDept = order.ReciptDept ;//开方科室信息
			feeitemlist.Order.ReciptDoctor = order.ReciptDoctor ;//开方医生信息
			feeitemlist.Order.DoseOnce = order.DoseOnce ;//每次用量
			feeitemlist.Order.DoseUnit = order.DoseUnit ;//用量单位
			feeitemlist.Order.Frequency = order.Frequency ;//频次信息
			feeitemlist.IsGroup = false;//是否组套
            feeitemlist.Order.Combo.IsMainDrug = order.Combo.IsMainDrug ;//是否主药
			feeitemlist.ID = order.Item.ID;
			feeitemlist.Name = order.Item.Name ;
			//if(order.Item.IsPharmacy )//是否药品
            if (order.Item.ItemType ==  EnumItemType.Drug)//是否药品
			{
                //add by sunm 不知道以下写法是否正确
                ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).BaseDose = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose;//基本计量
                ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).Quality = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Quality;//药品性质
                ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).DosageForm = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm;//剂型
				
				feeitemlist.IsConfirmed = false;//是否终端确认
				feeitemlist.Item.PackQty = order.Item.PackQty ;//包装数量
			}
			else
			{
								
				Neusoft.HISFC.Models.Fee.Item.Undrug myobj = order.Item as Neusoft.HISFC.Models.Fee.Item.Undrug;
                feeitemlist.Item.IsNeedConfirm = myobj.IsNeedConfirm;//下面的代码不太懂,不知道这么修改是否正确
                //if(myobj.ConfirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All////????????????
                //    ||myobj.ConfirmFlag==Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
                //{
                //    feeitemlist.IsConfirmed = true;
                //}
                //else
                //{
                //    feeitemlist.IsConfirmed = false;
                //}
				feeitemlist.Item.PackQty = 1 ;//包装数量
			}
		
			//feeitemlist.Item.IsPharmacy = order.Item.IsPharmacy;//是否药品
            feeitemlist.Item.ItemType = order.Item.ItemType;//是否药品
			//if(order.Item.IsPharmacy)//药品
            if (order.Item.ItemType == EnumItemType.Drug)//药品
			{
				feeitemlist.Item.Specs = order.Item.Specs;
			}
			feeitemlist.IsUrgent = order.IsEmergency ;//是否加急
			feeitemlist.Order.Sample = order.Sample ;//样本信息
			feeitemlist.Memo = order.Memo ;//备注
			feeitemlist.Item.MinFee = order.Item.MinFee ;//最小费用
			feeitemlist.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;//收费状态
			feeitemlist.Item.Price = order.Item.Price ;//价格
		    
			feeitemlist.Item.PriceUnit = order.Item.PriceUnit ;//价格单位
			feeitemlist.Item.Qty = order.Qty ;//数量
            ((Neusoft.HISFC.Models.Registration.Register)feeitemlist.Patient).DoctorInfo.SeeDate = order.RegTime;//登记日期
            ((Neusoft.HISFC.Models.Registration.Register)feeitemlist.Patient).DoctorInfo.Templet.Dept = order.ReciptDept;//登记科室
			feeitemlist.Item.SysClass = order.Item.SysClass ;//系统类别
			feeitemlist.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive ;//交易类型
			feeitemlist.Order.Usage = order.Usage ;//用法

            if (order.ReciptNO == "")
            {
                feeitemlist.RecipeNO = reciptNo;//处方号
                feeitemlist.SequenceNO = seqNo;//处方内流水号

                return fee.InsertFeeItemList(feeitemlist);
            }
            else
            {
                feeitemlist.RecipeNO = order.ReciptNO;
                feeitemlist.SequenceNO = order.SequenceNO;
                int i = -1;
                i = fee.UpdateFeeItemList(feeitemlist);//更新
                if (i == -1)
                    return -1;
                else if (i == 0)
                    return fee.InsertFeeItemList(feeitemlist);//插入
                else
                    return i;
            }
		}
        
        /// <summary>
        /// 插入费用档
        /// </summary>
        /// <param name="fee"></param>
        /// <param name="feeitem"></param>
        /// <param name="dtNow"></param>
        /// <returns></returns>
        public static int SaveToFee(Neusoft.HISFC.BizProcess.Integrate.Fee fee, Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitem, DateTime dtNow)
        {
            
            int i = -1;//临时变量
            i = fee.UpdateFeeItemList(feeitem);//更新
            if (i == -1)
                i = -1;
            else if (i == 0)
                i = fee.InsertFeeItemList(feeitem);//插入
            return i;
        }
        
        /// <summary>
        /// 将复合项目拆分成明细
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static ArrayList ChangeZtToSingle(Neusoft.HISFC.Models.Order.OutPatient.Order order, Neusoft.HISFC.Models.Registration.Register reg, Neusoft.HISFC.Models.Base.PactInfo pactInfo)
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager myZt = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList alZt = myZt.QueryUndrugPackageDetailByCode(order.Item.ID);

            if (alZt == null)
            {
                MessageBox.Show("查找复合项目" + order.Item.Name + "失败!", "提示");
                return null;
            }

            Neusoft.HISFC.BizProcess.Integrate.Fee myItem = new Neusoft.HISFC.BizProcess.Integrate.Fee();

            ArrayList alOrder = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.Item.Undrug info in alZt)
            {
                Neusoft.HISFC.Models.Fee.Item.Undrug item = myItem.GetItem(info.ID);

                if (item == null)
                {
                    MessageBox.Show("查找复合项目明细" + info.ID + "失败!", "提示");
                    return null;
                }

                Neusoft.HISFC.Models.Order.OutPatient.Order temp = new Neusoft.HISFC.Models.Order.OutPatient.Order();

                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                temp.Item = item.Clone();
                temp.Item.ID = item.ID;
                temp.Package.ID = order.Item.ID;
                temp.Package.Name = order.Item.Name;
                temp.Combo = order.Combo;
                temp.Doctor = order.Doctor;
                temp.DoseOnce = order.DoseOnce;
                temp.DoseUnit = order.DoseUnit;
                temp.ExeDept = order.ExeDept;
                temp.Frequency = order.Frequency;
                temp.HerbalQty = order.HerbalQty;
                temp.ID = order.ID;
                temp.Usage = order.Usage;
                temp.Unit = item.PriceUnit;
                temp.NurseStation = order.NurseStation;
                temp.Item.Price = GetPrice(temp, reg, pactInfo);
                temp.Qty = info.Qty * order.Qty;
                //Add By Maokb
                temp.Item.SysClass = order.Item.SysClass;

                alOrder.Add(temp);
            }

            return alOrder;
        }
        
        /// <summary>
        /// 将医嘱实体转成费用实体
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList ChangeToFeeItemList(Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            try
            {
                Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeitemlist = new Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList();

                //if (order.Item.IsPharmacy)
                if (order.Item.ItemType == EnumItemType.Drug)
                {
                    feeitemlist.Item = new Neusoft.HISFC.Models.Pharmacy.Item();
                    
                }
                else 
                {
                    feeitemlist.Item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                }
                
                feeitemlist.Item.Qty = order.Qty;
                feeitemlist.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                feeitemlist.Patient.ID = order.Patient.ID;//门诊流水号
                feeitemlist.Patient.PID.CardNO = order.Patient.PID.CardNO;//门诊卡号 
                feeitemlist.Order.ID = order.ID;//医嘱流水号

                feeitemlist.ChargeOper.ID = Neusoft.FrameWork.Management.Connection.Operator.ID;
                feeitemlist.Order.CheckPartRecord = order.CheckPartRecord;//检体 
                feeitemlist.Order.Combo.ID = order.Combo.ID;//组合号
                if (order.Unit == "[复合项]")
                {
                    feeitemlist.IsGroup = true;
                    feeitemlist.UndrugComb.ID = order.User01;
                    feeitemlist.UndrugComb.Name = order.User02;
                }
                
                //if (order.Item.IsPharmacy && !((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsSubtbl )
                if (order.Item.ItemType == EnumItemType.Drug && !((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsSubtbl)
                {
                    feeitemlist.ExecOper.Dept.ID = order.StockDept.Clone().ID;//传扣库科室
                    feeitemlist.ExecOper.Dept.Name = order.StockDept.Clone().Name;
                }
                else
                {
                    feeitemlist.ExecOper.Dept.ID = order.ExeDept.Clone().ID;
                    feeitemlist.ExecOper.Dept.Name = order.ExeDept.Clone().Name;
                }
                feeitemlist.InjectCount = order.InjectCount;//院内次数
                
                if (order.Item.PackQty <= 0)
                {
                    order.Item.PackQty = 1;
                }
                //自批价项目
                ////if (order.Item.Price == 0)
                ////{
                ////    order.Item.Price = order.Item.Price;
                ////}
                //by zuowy 根据收费是否是最小单位 确定收费 改时慎重
                //if (order.Item.IsPharmacy)
                if (order.Item.ItemType == EnumItemType.Drug)
                {
                    feeitemlist.Item.SpecialFlag = order.Item.SpecialFlag;

                    if (order.NurseStation.User03 == "")//user03为空,说明不知道开立的什么单位 默认为最小单位
                    {
                        order.NurseStation.User03 = "1";//默认
                    }
                    if (order.NurseStation.User03 != "1")//开立最小单位 !=((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit)
                    {
                        feeitemlist.Item.Qty = order.Item.PackQty * order.Qty;
                        order.FT.OwnCost = order.Qty * order.Item.Price;
                        
                        order.Item.PriceUnit = order.Unit;
                        feeitemlist.FeePack = "1";//开立单位 1:包装单位 0:最小单位
                    }
                    else
                    {
                        if (order.Item.PackQty == 0)
                        {
                            order.Item.PackQty = 1;
                        }
                        order.FT.OwnCost = order.Qty * order.Item.Price / order.Item.PackQty;
                        
                        order.Item.PriceUnit = order.Unit;
                        feeitemlist.FeePack = "0";//开立单位 1:包装单位 0:最小单位
                    }
                }
                else
                {
                    order.FT.OwnCost = order.Qty * order.Item.Price;
                    feeitemlist.FeePack = "1";
                }

                if (order.HerbalQty == 0)
                {
                    order.HerbalQty = 1;
                }

                feeitemlist.Days = order.HerbalQty;//草药付数
                feeitemlist.RecipeOper.Dept = order.ReciptDept;//开方科室信息
                feeitemlist.RecipeOper.Name = order.ReciptDoctor.Name;//开方医生信息
                feeitemlist.RecipeOper.ID = order.ReciptDoctor.ID;
                feeitemlist.Order.DoseUnit = order.DoseUnit;//用量单位
                //if (order.Item.IsPharmacy)
                if (order.Item.ItemType == EnumItemType.Drug)
                {
                    if (((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).SysClass.ID.ToString() == "PCC")
                    {
                        if (order.HerbalQty == 0)
                        {
                            order.HerbalQty = 1;
                        }
                        
                        feeitemlist.Order.DoseOnce = order.DoseOnce;
                        
                    }
                    else
                    {
                        feeitemlist.Order.DoseOnce = order.DoseOnce;//每次用量
                    }
                }
                feeitemlist.Order.Frequency = order.Frequency;//频次信息
                
                feeitemlist.Order.Combo.IsMainDrug = order.Combo.IsMainDrug;//是否主药
                feeitemlist.Item.ID = order.Item.ID;
                feeitemlist.Item.Name = order.Item.Name;
                //if (order.Item.IsPharmacy)//是否药品
                if (order.Item.ItemType == EnumItemType.Drug)//是否药品
                {
                    ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).BaseDose = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose;//基本计量
                    ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).Quality = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Quality;//药品性质
                    ((Neusoft.HISFC.Models.Pharmacy.Item)feeitemlist.Item).DosageForm = ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm;//剂型
                    
                    feeitemlist.IsConfirmed = false;//是否终端确认
                    feeitemlist.Item.PackQty = order.Item.PackQty;//包装数量
                }
                else
                {
                    if (order.ExtendFlag3 != "SUBTBL")
                    {
                        feeitemlist.IsConfirmed = false;
                        feeitemlist.Item.PackQty = 1;//包装数量
                    }
                    else//附材中的复合项目
                    {
                        feeitemlist.IsConfirmed = false;//neusoft.neHISFC.Components.Function.NConvert.ToBoolean(order.Mark2);
                        feeitemlist.Item.PackQty = 1;
                    }
                }

                //feeitemlist.Order.Item.IsPharmacy = order.Item.IsPharmacy;//是否药品
                feeitemlist.Order.Item.ItemType = order.Item.ItemType;//是否药品
                //if (order.Item.IsPharmacy)//药品
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    feeitemlist.Item.Specs = order.Item.Specs;
                }
                feeitemlist.IsUrgent = order.IsEmergency;//是否加急
                feeitemlist.Order.Sample = order.Sample;//样本信息
                feeitemlist.Memo = order.Memo;//备注
                feeitemlist.Item.MinFee = order.Item.MinFee;//最小费用
                feeitemlist.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;//划价状态
                feeitemlist.Item.Price = order.Item.Price;//价格

                feeitemlist.Item.PriceUnit = order.Item.PriceUnit;//价格单位
                if (order.Item.SysClass.ID.ToString() == "PCC" && order.HerbalQty > 0)
                {
                    
                }
                order.FT.TotCost = order.FT.TotCost;
                order.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.TotCost, 2);
                order.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.TotCost, 2);
                feeitemlist.FT = Round(order, 2);//取两位				
                ((Neusoft.HISFC.Models.Registration.Register)feeitemlist.Patient).DoctorInfo.SeeDate = order.RegTime;//登记日期
                ((Neusoft.HISFC.Models.Registration.Register)feeitemlist.Patient).DoctorInfo.Templet.Dept = order.ReciptDept;//登记科室
                feeitemlist.Item.SysClass = order.Item.SysClass;//系统类别
                feeitemlist.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;//交易类型
                feeitemlist.Order.Usage = order.Usage;//用法
                feeitemlist.RecipeSequence = order.ReciptSequence;//收费序列
                feeitemlist.RecipeNO = order.ReciptNO;//处方号
                feeitemlist.SequenceNO = order.SequenceNO;//处方流水号
                feeitemlist.FTSource = "1";//来自医嘱
                if (order.IsSubtbl)
                {
                    feeitemlist.Item.IsMaterial = true;//是附材
                }

                //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                feeitemlist.Item.IsNeedConfirm = order.Item.IsNeedConfirm;
                return feeitemlist;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转换成带00的字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ToDecimal(decimal val, int i)
        {
            try
            {
                decimal m = 0m;
                if (val.ToString().LastIndexOf(".") > 0)
                {
                    m = System.Math.Round(val, i);
                    return m.ToString();
                }
                else
                {
                    System.Text.StringBuilder buffer = null;
                    buffer = new System.Text.StringBuilder();
                    buffer.Append(val.ToString());
                    buffer.Append(".");
                    for (int j = 0; j < i; j++)
                    {
                        buffer.Append("0");
                    }
                    return buffer.ToString();
                }
            }
            catch
            {
                return val.ToString();
            }
        }

        /// <summary>
        /// 检查收费项目
        /// </summary>
        /// <param name="item"></param>
        public static void CheckFeeItemList(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item)
        {
            if (item.UndrugComb.Package.Name == "[复合项]")
            {
                item.IsGroup = true;
            }
            item.FT.OwnCost = item.Item.Qty * item.Item.Price;
        }

        /// <summary>
        /// 为费用取整
        /// </summary>
        /// <param name="order"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private static Neusoft.HISFC.Models.Base.FT Round(Neusoft.HISFC.Models.Order.OutPatient.Order order, int i)
        {
            Neusoft.HISFC.Models.Base.FT ft = new Neusoft.HISFC.Models.Base.FT();
            //为NULL返回新实体
            if (order == null || order.FT == null)
            {
                return ft;
            }

            ft.AdjustOvertopCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.AdjustOvertopCost, i);
            ft.AirLimitCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.AirLimitCost, i);
            ft.BalancedCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BalancedCost, i);
            ft.BalancedPrepayCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BalancedPrepayCost, i);
            ft.BedLimitCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BedLimitCost, i);
            ft.BedOverDeal = order.FT.BedOverDeal;
            ft.BloodLateFeeCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BloodLateFeeCost, i);
            ft.BoardCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BoardCost, i);
            ft.BoardPrepayCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.BoardPrepayCost, i);
            ft.DrugFeeTotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.DrugFeeTotCost, i);
            ft.TransferPrepayCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.TransferPrepayCost, i);
            ft.TransferTotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.TransferTotCost, i);
            ft.DayLimitCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.DayLimitCost, i);
            ft.DerateCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.DerateCost, i);
            ft.FixFeeInterval = order.FT.FixFeeInterval;
            ft.ID = order.FT.ID;
            ft.LeftCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.LeftCost, i);
            ft.OvertopCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.OvertopCost, i);
            ft.DayLimitTotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.DayLimitTotCost, i);
            ft.Memo = order.FT.Memo;
            ft.Name = order.FT.Name;
            ft.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.OwnCost, i);
            ft.FTRate.OwnRate = order.FT.FTRate.OwnRate;
            ft.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.PayCost, i);
            ft.FTRate.PayRate = order.FT.FTRate.PayRate;
            ft.PreFixFeeDateTime = order.FT.PreFixFeeDateTime;
            ft.PrepayCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.PrepayCost, i);
            ft.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.PubCost, i);
            ft.RebateCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.RebateCost, i);
            ft.ReturnCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.ReturnCost, i);
            ft.SupplyCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.SupplyCost, i);
            ft.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(order.FT.TotCost, i);
            
            ft.User01 = order.FT.User01;
            ft.User02 = order.FT.User02;
            ft.User03 = order.FT.User03;
            return ft;
        }

        /// <summary>
        /// 获得是否可以开库存为零的药品
        /// </summary>
        /// <returns></returns>
        public static int GetIsOrderCanNoStock()
        {
            
            object o = Classes.Function.controlerHelper.GetObjectFromID("200001");
            if (o != null)
            {
                return Neusoft.FrameWork.Function.NConvert.ToInt32(controler.QueryControlerInfo("200001"));
            }
            return -1;
        }

        /// <summary>
        /// 检查库存
        /// </summary>
        /// <param name="iCheck"></param>
        /// <param name="itemID"></param>
        /// <param name="itemName"></param>
        /// <param name="deptCode"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public static bool CheckPharmercyItemStock(int iCheck, string itemID, string itemName, string deptCode, decimal qty)
        {
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy manager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            Neusoft.HISFC.Models.Pharmacy.Storage item = null;
            switch (iCheck)
            {
                case 0:
                    item = manager.GetItemForInpatient(deptCode, itemID);
                    if (item == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(item.StoreQty))
                    {
                        return false;
                    }
                    break;
                case 1:
                    item = manager.GetItemForInpatient(deptCode, itemID);
                    if (item == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(item.StoreQty))
                    {
                        if (MessageBox.Show("药品【" + itemName + "】的库存不够！是否继续执行！", "提示库存不足", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 2:
                    break;
                default:
                    return true;
            }
            return true;
        }

        /// <summary>
        /// 用于选择维护的药品列表检查库存{24BDD373-4F2C-4899-88A7-FE2E8386F7CF}
        /// </summary>
        /// <param name="iCheck"></param>
        /// <param name="itemID"></param>
        /// <param name="itemName"></param>
        /// <param name="deptCode"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public static bool CheckPharmercyItemStockNew(int iCheck, string itemID, string itemName, string deptCode, decimal qty)
        {
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy manager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            Neusoft.HISFC.Models.Pharmacy.Storage item = null;
            switch (iCheck)
            {
                case 0:
                    item = manager.GetItemForInpatient(deptCode, itemID);
                    if (item == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(item.StoreQty))
                    {
                        return false;
                    }
                    break;
                case 1:
                    item = manager.GetItemForInpatient(deptCode, itemID);
                    if (item == null) return true;
                    if (qty > Neusoft.FrameWork.Function.NConvert.ToDecimal(item.StoreQty) || item.Item.ID == string.Empty)
                    {
                        if (MessageBox.Show("药品【" + itemName + "】的库存不够！是否继续执行！", "提示库存不足", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            return true;
                        else
                            return false;
                    }
                    break;
                case 2:
                    break;
                default:
                    return true;
            }
            return true;
        }

        /// <summary>
        /// 重新获取药品取药药房等信息
        /// </summary>
        /// <param name="pManager"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int FillPharmacyItemWithStockDept(Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManager, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (order.Item.ID == "999")
            {
                //if (order.Item.IsPharmacy)//药品
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        //置药品类型给药品
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Storage item;
            try
            {
                item = pManager.GetItemForInpatient(order.ReciptDept.ID, order.Item.ID);
            }
            catch
            {
                MessageBox.Show("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                return -1;
            }
            if (item == null || item.Item.ID == "")
            {
                MessageBox.Show("没有获得药品信息！\n" + "当前科室的领药药房中没有" + order.Item.Name);
                return -1;
            }
            else
            {
                if (item.IsStop)
                {
                    MessageBox.Show(order.Item.Name + "已经停用！");
                    return -1;
                }
            }
            
            order.Item.MinFee = item.Item.MinFee;
            
            order.Item.Name = item.Item.Name;
            order.StockDept.ID = item.StockDept.ID;
            order.StockDept.Name = item.StockDept.Name;
            
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.Item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.Item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.Item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.Item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.Item.DosageForm;
            return 0;
        }

        /// <summary>
        /// 获得药品基本信息
        /// </summary>
        /// <param name="pManager"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int FillPharmacyItem(Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManager, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (order.Item.ID == "999")
            {
                //if (order.Item.IsPharmacy)//药品
                if (order.Item.ItemType == EnumItemType.Drug)//药品
                {
                    try
                    {
                        //置药品类型给药品
                        ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).Type.ID = order.Item.SysClass.ID.ToString().Substring(order.Item.SysClass.ID.ToString().Length - 1, 1);
                    }
                    catch { }
                }
                return 0;
            }
            Neusoft.HISFC.Models.Pharmacy.Item item;
            try
            {
                item = pManager.GetItem(order.Item.ID);
            }
            catch
            {
                MessageBox.Show("获得药品信息出错！\n" + order.Item.Name + "已经停用！");
                return -1;
            }
            if (item == null || item.IsStop)
            {
                
                MessageBox.Show(order.Item.Name + "已经停用!请医生停止医嘱!");
                return -1;
            }
            order.Item.MinFee = item.MinFee;
            order.Item.Price = item.Price;
            order.Item.Name = item.Name;
            order.Item.SysClass = item.SysClass.Clone();//付给系统类别
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).IsAllergy = item.IsAllergy;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).PackUnit = item.PackUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).MinUnit = item.MinUnit;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).BaseDose = item.BaseDose;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).DosageForm = item.DosageForm;
            ((Neusoft.HISFC.Models.Pharmacy.Item)order.Item).SplitType = item.SplitType;
            return 0;
        }
        
        /// <summary>
        /// 获得非药品信息
        /// </summary>
        /// <param name="itemManager"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int FillFeeItem(Neusoft.HISFC.BizProcess.Integrate.Fee itemManager, ref Neusoft.HISFC.Models.Order.OutPatient.Order order)
        {
            if (order.Item.ID == "999") return 0;
            if (order.Unit == "[复合项]") return 0;//如果是复合项目不变
            Neusoft.HISFC.Models.Fee.Item.Undrug item = itemManager.GetItem(order.Item.ID);
            if (item == null)
            {
                
                return -1;
            }

            ((Neusoft.HISFC.Models.Fee.Item.Undrug)order.Item).IsNeedConfirm = item.IsNeedConfirm;
            
            //sunm modified(do not know istrue)
            order.IsNeedConfirm = item.IsNeedConfirm;
            
            order.Item.Price = item.Price;
            order.Item.MinFee = item.MinFee;
            order.Item.SysClass = item.SysClass.Clone();//付给系统类别
            return 0;
        }

        /// <summary>
        /// 显示医嘱信息
        /// </summary>
        /// <param name="sender"></param>
        public static void ShowOrder(object sender, ArrayList alOrder)
        {
            ShowOrder(sender, alOrder, 0);
        }
        /// <summary>
        /// 显示医嘱信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="alOrder"></param>
        /// <param name="type"></param>
        public static void ShowOrder(object sender, ArrayList alOrder, int type)
        {
            try
            {
                #region 设置dataSet

                #region 变量声明及初始化
                //定义传出DataSet
                DataSet myDataSet = new DataSet();
                myDataSet.EnforceConstraints = false;//是否遵循约束规则
                //定义类型
                System.Type dtStr = System.Type.GetType("System.String");
                System.Type dtBool = System.Type.GetType("System.Boolean");
                System.Type dtInt = System.Type.GetType("System.Int32");
                //定义表********************************************************
                //Main Table
                DataTable dtMain = new DataTable();
                dtMain = myDataSet.Tables.Add("TableMain");

                dtMain.Columns.AddRange(new DataColumn[]{  new DataColumn("ID", dtStr),new DataColumn("组合号", dtStr), new DataColumn("医嘱名称", dtStr),new DataColumn("规格", dtStr),
                                                            new DataColumn("组合", dtStr),new DataColumn("间隔时间", dtStr),new DataColumn("每次剂量", dtStr),
                                                            new DataColumn("频次", dtStr),new DataColumn("数量", dtStr),new DataColumn("付数", dtStr),
                                                            new DataColumn("用法", dtStr),new DataColumn("医嘱类型", dtStr),new DataColumn("加急", dtBool),
                                                            new DataColumn("开始时间", dtStr),new DataColumn("开立时间", dtStr),new DataColumn("开立医生", dtStr),
                                                            new DataColumn("执行科室", dtStr),new DataColumn("停止时间", dtStr),new DataColumn("停止医生", dtStr),
                                                            new DataColumn("备注", dtStr),new DataColumn("顺序号", dtStr)});


                Neusoft.HISFC.BizProcess.Integrate.Pharmacy pManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
                Neusoft.HISFC.BizProcess.Integrate.Fee fManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
                Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                //Neusoft.HISFC.BizLogic..OrderType orderType = new Neusoft.HISFC.BizLogic.Manager.OrderType();
                Neusoft.HISFC.BizProcess.Integrate.Fee ztMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();

                Neusoft.FrameWork.Public.ObjectHelper helper = new Neusoft.FrameWork.Public.ObjectHelper(deptMgr.QueryOrderTypeList());
                #endregion

                string beginDate = "", endDate = "", moDate = "";
                ArrayList alTemp = new ArrayList();
                
                for (int i = 0; i < alOrder.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.OutPatient.Order o = alOrder[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                    Neusoft.HISFC.Models.Base.Item tempItem = null;
                    
                    #region 更新项目信息
                    if (o.Item == null || o.Item.ID == "")
                    {
                        if (o.ID == "999")//自备项目
                        {
                            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                            undrug.ID = o.ID;
                            undrug.Name = o.Name;
                            undrug.Qty = o.Item.Qty;
                            //undrug.IsPharmacy = false;
                            undrug.ItemType = EnumItemType.UnDrug;
                            undrug.SysClass.ID = "M";
                            undrug.PriceUnit = o.Unit;
                            tempItem = undrug;
                            o.Item = tempItem;
                            alTemp.Add(o);
                        }
                        else if (o.ID.Substring(0, 1) == "F")//非药品
                        {
                            #region 非药品
                            tempItem = fManager.GetItem(o.Item.ID);
                            if (tempItem == null || tempItem.ID == "")
                            {
                                MessageBox.Show("项目" + o.Name + "已经停用！!", "提示");
                                
                                o.Item.ID = o.ID;
                                o.Item.Name = o.Name;
                                o.ExtendFlag2 = "N";
                            }
                            else
                            {
                                if (o.ExeDept.ID.Length <= 0)
                                {
                                    if (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts.Count > 0)
                                        o.ExeDept.ID = (((Neusoft.HISFC.Models.Fee.Item.Undrug)tempItem).ExecDepts[0]).ToString();
                                    else
                                        o.ExeDept = new Neusoft.FrameWork.Models.NeuObject();
                                }
                                tempItem.Qty = o.Item.Qty;
                                o.Item = tempItem;
                                alTemp.Add(o);
                            }
                            #endregion
                        }
                        else if (o.ID.Substring(0, 1) == "Y")//药品
                        {
                            #region 药品
                            ////Neusoft.HISFC.Models.RADT.Person p = pManager.Operator as Neusoft.HISFC.Models.RADT.Person;
                            ////if (p == null) return;
                            ////tempItem = pManager.GetItemForInpatient(p.Dept.ID, o.ID);
                            tempItem = pManager.GetItem(o.Item.ID);
                            if (tempItem == null || tempItem.ID == "")
                            {
                                MessageBox.Show("项目" + o.Name + "已经停用！!", "提示");
                                
                                o.ExtendFlag2 = "N";
                            }
                            else
                            {
                                //药品执行科室为空
                                
                                tempItem.Qty = o.Item.Qty;
                                o.Item = tempItem;
                                o.StockDept.ID = tempItem.User02;

                                Neusoft.HISFC.Models.Base.Department dept = null;
                                if (o.StockDept != null && o.StockDept.ID != null && o.StockDept.ID != "")
                                    dept = deptMgr.GetDepartment(o.StockDept.ID);
                                if (dept != null && dept.ID != "")
                                    o.StockDept.Name = dept.Name;

                                alTemp.Add(o);
                            }
                            #endregion
                        }
                        else if (o.Unit == "[复合项]")//复合项目
                        {
                            #region 复合项
                            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                            Neusoft.HISFC.Models.Fee.Item.Undrug zt = ztMgr.GetItem(o.ID);
                            if (zt == null)
                            {
                                MessageBox.Show("复合项目:" + o.Name + "已经停用或者删除,不能调用!", "提示");
                                
                                o.ExtendFlag2 = "N";
                            }
                            else
                            {
                                
                                undrug.ID = o.ID;
                                undrug.Name = o.Name;
                                undrug.Qty = o.Item.Qty;
                                //undrug.IsPharmacy = false;
                                undrug.ItemType = EnumItemType.UnDrug;
                                undrug.SysClass.ID = zt.SysClass;
                                undrug.PriceUnit = o.Unit;
                                o.ExeDept.ID = zt.ExecDept;
                                tempItem = undrug as Neusoft.HISFC.Models.Base.Item;
                                o.Item = tempItem;

                                alTemp.Add(o);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        alTemp.Add(o);
                    }
                    #endregion

                    #region 显示医嘱
                    if (o.Item != null && o.ExtendFlag2 != "N")
                    {
                        
                        if (o.BeginTime == DateTime.MinValue)
                            beginDate = "";
                        else
                            beginDate = o.BeginTime.ToString();

                        if (o.EndTime == DateTime.MinValue)
                            endDate = "";
                        else
                            endDate = o.EndTime.ToString();

                        if (o.MOTime == DateTime.MinValue)
                            moDate = "";
                        else
                            moDate = o.MOTime.ToString();

                        if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Pharmacy.Item))
                        {
                            Neusoft.HISFC.Models.Pharmacy.Item item = o.Item as Neusoft.HISFC.Models.Pharmacy.Item;
                            o.DoseUnit = item.DoseUnit;
                            dtMain.Rows.Add(new Object[] {  o.ID,o.Combo.ID,o.Item.Price.ToString()+"元/"+o.Item.Name,o.Item.Specs,
                                                             "",o.User03,o.DoseOnce.ToString()+item.DoseUnit ,
                                                             o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
                                                             /*o.OrderType.Name*/"门诊",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,o.ExeDept.Name,endDate,
                                                             o.DCOper.Name,o.Memo,o.SortID});

                        }
                        else if (o.Item.GetType() == typeof(Neusoft.HISFC.Models.Fee.Item.Undrug))
                        {
                            if (o.Unit == "[复合项]")
                            {
                                o.Item.Price = Order.OutPatient.Classes.Function.GetUndrugZtPrice(o.Item.ID);
                            }
                            dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID,o.Item.Price.ToString()+"元/"+o.Item.Name,o.Item.Specs,
                                                             "",o.User03,"" ,
                                                             o.Frequency.ID,o.Qty.ToString()+o.Unit,"","",
                                                             /*o.OrderType.Name*/"门诊",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
                                                             o.ExeDept.Name,endDate,
                                                             o.DCOper.Name,o.Memo,o.SortID});

                        }
                        else
                        {
                            dtMain.Rows.Add(new Object[] { o.ID,o.Combo.ID,o.Item.Name,o.Item.Specs,
                                                             "",o.User03,o.DoseOnce.ToString()+o.DoseUnit,
                                                             o.Frequency.ID,o.Qty.ToString()+o.Unit,o.HerbalQty,o.Usage.Name,
                                                             /*o.OrderType.Name*/"门诊",o.IsEmergency,beginDate,moDate,o.ReciptDoctor.Name,
                                                             o.ExeDept.Name,endDate,
                                                             o.DCOper.Name,o.Memo,o.SortID});
                        }
                        
                    #endregion
                    }
                }
                #endregion

                switch (sender.GetType().ToString().Substring(sender.GetType().ToString().LastIndexOf(".") + 1))
                {
                    case "SheetView":
                        FarPoint.Win.Spread.SheetView o = sender as FarPoint.Win.Spread.SheetView;
                        o.RowCount = 0;
                        o.DataSource = myDataSet.Tables[0];
                        for (int i = 0; i < alTemp.Count; i++)
                        {
                            if ((alTemp[i] as Neusoft.HISFC.Models.Order.OutPatient.Order).ExtendFlag2 != "N")
                            {
                                o.Rows[i].Tag = alTemp[i];
                            }
                        }
                        #region 设置列
                        o.Columns[0].Visible = false;
                        o.Columns[1].Visible = false;
                        //2 ("医嘱名称", dtStr),3("规格", dtStr),4 组合,5间隔时间,6("每次剂量", dtStr),
                        //7("频次", dtStr),8("数量", dtStr),9("付数", dtStr),
                        //10("用法", dtStr),11("医嘱类型", dtStr),12("加急", dtBool),
                        //13("开始时间", dtStr),14("开立时间", dtStr),15("开立医生", dtStr),
                        //16("执行科室", dtStr),17("停止时间", dtStr),18("停止医生", dtStr),
                        //19("备注", dtStr),20("顺序号", dtStr)});
                        o.Columns[2].Width = 150;
                        o.Columns[3].Width = 50;
                        o.Columns[4].Width = 40;
                        o.Columns[5].Width = 80;
                        o.Columns[5].CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                        o.Columns[6].Width = 100;
                        o.Columns[7].Width = 80;
                        o.Columns[8].Width = 80;
                        o.Columns[9].Width = 60;
                        o.Columns[10].Width = 80;
                        o.Columns[11].Width = 60;
                        o.Columns[12].Width = 40;
                        o.Columns[13].Width = 100;
                        o.Columns[14].Width = 80;
                        o.Columns[15].Width = 80;
                        o.Columns[16].Width = 80;
                        o.Columns[17].Width = 80;
                        o.Columns[18].Width = 80;
                        o.Columns[19].Width = 80;
                        o.Columns[20].Width = 30;
                        if (type == 1)//组套
                        {
                            o.Columns[5].Visible = true;
                        }
                        else
                        {
                            o.Columns[5].Visible = false;
                        }
                        #endregion
                        
                        Order.Classes.Function.DrawCombo(o, 1, 4);
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 根据复合项编码获得其价格(在原来4.0代码转过来的,如果没有引用的地方可删除)
        /// </summary>
        /// <param name="ztManager"></param>
        /// <param name="itemManager"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static decimal GetUndrugZtPrice(Neusoft.HISFC.BizProcess.Integrate.Fee ztManager, Neusoft.HISFC.BizProcess.Integrate.Fee itemManager, string ID)
        {
            //if (ID == "")
            //{
            //    return 0m;
            //}
            //ArrayList al = null;
            //al = ztManager.GetUndrugztinfo(ID);
            //if (al == null)
            //{
            //    return 0m;
            //}
            decimal tot_cost = 0m;
            //for (int i = 0; i < al.Count; i++)
            //{
            //    Neusoft.HISFC.Models.Fee.Undrugztinfo info = al[i] as Neusoft.HISFC.Models.Fee.Undrugztinfo;
            //    if (info == null || info.ValidState == "1")
            //    {
            //        continue;
            //    }
            //    Neusoft.HISFC.Models.Fee.Item item = itemManager.GetItem(info.itemCode);
            //    if (item == null)
            //    {
            //        continue;
            //    }
            //    tot_cost += info.Qty * item.Price;
            //}
            return tot_cost;
        }
        /// <summary>
        /// 根据复合项编码获得其价格
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static decimal GetUndrugZtPrice(string ID)
        {
            Neusoft.HISFC.BizProcess.Integrate.Fee ztManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            
            decimal tot_cost = 0m;
            tot_cost = ztManager.GetUndrugCombPrice(ID);
            return tot_cost;
        }
        
        /// <summary>
        /// 根据复合项编码获得其样本
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetUndrugZtSample(string ID)
        {
            if (ID == "")
            {
                return "";
            }

            ArrayList al = null;
            
            Neusoft.HISFC.BizProcess.Integrate.Manager ztManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            
            al = ztManager.QueryUndrugPackageDetailByCode(ID);
            if (al == null)
            {
                return "";
            }

            string sampleName = "";

            Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();

            for (int i = 0; i < al.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.Item.UndrugComb info = al[i] as Neusoft.HISFC.Models.Fee.Item.UndrugComb;
                if (info == null || info.ValidState == "1")
                {
                    continue;
                }
                Neusoft.HISFC.Models.Fee.Item.Undrug item = itemManager.GetItem(info.ID);
                if (item == null)
                {
                    continue;
                }

                if (item.CheckBody != null && item.CheckBody.Length > 0)
                {
                    sampleName = item.CheckBody;
                    break;
                }
            }
            return sampleName;
        }
        
        /// <summary>
        /// 获得组套价格
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static decimal GetGroupPrice(string ID)
        {
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy phaManager = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            Neusoft.HISFC.BizProcess.Integrate.Fee itemManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            Neusoft.HISFC.BizProcess.Integrate.Manager groupManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            if (ID == "")
            {
                return 0m;
            }
            ArrayList al = groupManager.QueryGroupDetailByGroupCode(ID);
            if (al == null || al.Count <= 0)
            {
                return 0m;
            }
            decimal tot = 0m;
            foreach (Neusoft.HISFC.Models.Fee.ComGroupTail detail in al)
            {
                if (detail.itemCode.Substring(0, 1) == "Y")
                {
                    Neusoft.HISFC.Models.Pharmacy.Item phaitem = phaManager.GetItem(detail.itemCode);
                    if (phaitem == null)
                    {
                        continue;
                    }
                    if (detail.unitFlag == "1")
                    {
                        if (phaitem.PackQty == 0)
                        {
                            phaitem.PackQty = 1;
                        }
                        tot += phaitem.Price * detail.qty / phaitem.PackQty;
                    }
                    else
                    {
                        if (phaitem.PackQty == 0)
                        {
                            phaitem.PackQty = 1;
                        }
                        tot += phaitem.Price * detail.qty;
                    }
                }
                else if (detail.itemCode.Substring(0, 1) == "F")
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug feeitem = itemManager.GetItem(detail.itemCode);
                    if (feeitem == null)
                    {
                        continue;
                    }
                    tot += feeitem.Price * detail.qty;
                }
                else
                {
                    tot += Function.GetUndrugZtPrice(detail.itemCode);
                }
            }
            return tot;
        }
        
        /// <summary>
        /// 参数太多了 定义个结构
        /// </summary>
        public struct ULOrderParms
        {
            //医技管理
            ////public Neusoft.HISFC.BizLogic.MedTech.MedTech medManager;
            //项目管理
            public Neusoft.HISFC.BizProcess.Integrate.Fee itemManager;
            //费用管理
            public Neusoft.HISFC.BizProcess.Integrate.Fee feeManager;
            //复合项管理
            public Neusoft.HISFC.BizProcess.Integrate.Manager ztManager;
            //复合明细管理
            ////public Neusoft.HISFC.BizLogic.Fee.undrugztinfo ztInfo;
            //医嘱管理
            public Neusoft.HISFC.BizLogic.Order.OutPatient.Order management;
        }
        
        /// <summary>
        ///  获得项目价格
        /// </summary>
        /// <param name="order"></param>
        /// <param name="reg"></param>
        /// <param name="pactInfo"></param>
        /// <returns></returns>
        public static decimal GetPrice(Neusoft.HISFC.Models.Order.OutPatient.Order order, Neusoft.HISFC.Models.Registration.Register reg, Neusoft.HISFC.Models.Base.PactInfo pactInfo)
        {
            Neusoft.FrameWork.Management.DataBaseManger db = new Neusoft.FrameWork.Management.DataBaseManger();
            Neusoft.HISFC.BizProcess.Integrate.Fee myItem = new Neusoft.HISFC.BizProcess.Integrate.Fee();
            Neusoft.HISFC.BizProcess.Integrate.Pharmacy myPha = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            
            DateTime nowDate = db.GetDateTimeFromSysDateTime();

            int age = (int)((new TimeSpan(nowDate.Ticks - reg.Birthday.Ticks)).TotalDays / 365);

            Neusoft.FrameWork.Models.NeuObject priceObj = new Neusoft.FrameWork.Models.NeuObject();
            priceObj.ID = pactInfo.PriceForm;
            priceObj.Name = age.ToString();

            if (order.Unit != "[复合项]")
            {
                if (order.Item.ID.Substring(0, 1) == "F")
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = myItem.GetItem(order.Item.ID);

                    if (item == null)
                    {
                        MessageBox.Show("查找项目" + order.Item.Name + "失败!", "提示");
                        return order.Item.Price;
                    }

                    priceObj.User01 = item.Price.ToString();//三甲价
                    priceObj.User02 = item.SpecialPrice.ToString();//特诊价
                    priceObj.User03 = item.ChildPrice.ToString();//儿童价

                }
                else
                {
                    Neusoft.HISFC.Models.Pharmacy.Item item = myPha.GetItem(order.Item.ID);

                    if (item == null)
                    {
                        MessageBox.Show("查找项目" + order.Item.Name + "失败!", "提示");
                        return order.Item.Price;
                    }

                    priceObj.User01 = item.Price.ToString();
                    priceObj.User02 = item.SpecialPrice.ToString();
                    priceObj.User03 = item.ChildPrice.ToString();

                    //Add By Maokb  --药品取啥儿童价
                    return item.Price;
                }
                
                return myItem.GetPrice(priceObj);
            }
            else
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager myZt = new Neusoft.HISFC.BizProcess.Integrate.Manager();

                ArrayList alZt = myZt.QueryUndrugPackageDetailByCode(order.Item.ID);

                if (alZt == null)
                {
                    MessageBox.Show("查找复合项目" + order.Item.Name + "失败!", "提示");
                    return order.Item.Price;
                }

                decimal price = 0m;

                foreach (Neusoft.HISFC.Models.Fee.Item.UndrugComb info in alZt)
                {
                    Neusoft.HISFC.Models.Fee.Item.Undrug item = myItem.GetItem(info.ID);

                    if (item == null)
                    {
                        MessageBox.Show("查找复合项目明细" + info.ID + "失败!", "提示");
                        return order.Item.Price;
                    }

                    //价格*数量
                    priceObj.User01 = (item.Price * info.Qty).ToString();
                    priceObj.User02 = (item.SpecialPrice * info.Qty).ToString();
                    priceObj.User03 = (item.ChildPrice * info.Qty).ToString();

                    price += myItem.GetPrice(priceObj);
                }

                return price;
            }
            
        }
        
        /// <summary>
        /// 非药品根据执行方式获得附材
        /// </summary>
        /// <param name="ulParm"></param>
        /// <param name="alOrder" desc = "医嘱数组"></param>
        /// <param name="alFeeItem" desc = "返回的费用数组"></param>
        /// <param name="bSingleDeal" desc = "加急医嘱是否单独处理"></param>
        /// <param name="EmrUsage" desc = "加急医嘱的处理方式"></param>
        /// <param name="ULOrderUsage" desc = "合管的处理方式"></param>
        public static void GetSubByExeType(ULOrderParms ulParm, ArrayList alOrder, ref ArrayList alFeeItem, bool bSingleDeal, string EmrUsage, string ULOrderUsage)
        {
            #region 为空 返回
            if (alOrder == null || alOrder.Count <= 0)
            {
                return;
            }
            #endregion

            #region 定义局部变量
            //临时存放扩展信息
            ArrayList altempMedItem = new ArrayList();
            //扩展信息数组
            ArrayList alMedItem = new ArrayList();
            //加急医嘱
            ArrayList alEmrOrder = new ArrayList();
            //非加急医嘱
            ArrayList alNotEmr = new ArrayList();

            string combNO = ulParm.management.GetNewOrderComboID();
            if (combNO == "")
            {
                MessageBox.Show("获得新组合号出错！\n" + ulParm.management.Err);
                alFeeItem = null;
                return;
            }
            #endregion

            #region 区分加急和非加急医嘱
            for (int i = 0; i < alOrder.Count; i++)
            {
                Neusoft.HISFC.Models.Order.OutPatient.Order order = alOrder[i] as Neusoft.HISFC.Models.Order.OutPatient.Order;
                
                if (order == null || order.Item.SysClass.ID.ToString() == "" || order.Item.SysClass.ID.ToString() != "UL")
                {
                    continue;
                }
                if (order.NurseStation.User01 != null && order.NurseStation.User01 != "")
                {
                    if (ulParm.feeManager.DeleteFeeDetailByCombNoAndClinicCode(order.NurseStation.User01, order.Patient.ID) < 0)
                    {
                        MessageBox.Show("根据组合号删除费用明细出错！");
                        alFeeItem = null;
                        return;
                    }
                }
                //加急医嘱单独处理
                if (bSingleDeal)
                {
                    if (order.IsEmergency)
                    {
                        alEmrOrder.Add(order);
                    }
                    else
                    {
                        alNotEmr.Add(order);
                    }
                }
                else
                {
                    alNotEmr.Add(order);
                }
            }
            #endregion

            #region 处理加急医嘱
            //if (alEmrOrder.Count > 0)
            //{
            //    foreach (Neusoft.HISFC.Models.Order.OutPatient.Order temp in alEmrOrder)
            //    {
            //        #region 获得项目扩展信息
            //        Neusoft.HISFC.Models.Terminal.MedTechItem medItem = ulParm.medManager.SelectDeptItem(temp.ExeDept.ID, temp.Item.ID);
            //        if (medItem == null)
            //        {
            //            MessageBox.Show("获得项目扩展信息出错！");
            //            alFeeItem = null;
            //            return;
            //        }
            //        #endregion
            //        #region 找不到抽血方式，提示
            //        if (medItem.ItemExtend.BloodWay != null && medItem.ItemExtend.BloodWay != "")
            //        {
            //            MessageBox.Show("项目:" + temp.Item.Name + "的扩展信息没有维护！");
            //            continue;
            //        }
            //        #endregion
            //        #region 抽血方式为偶数
            //        if (Neusoft.FrameWork.Function.NConvert.ToInt32(medItem.ItemExtend.BloodWay) % 2 == 0)
            //        {
            //            #region 附材信息
            //            ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(medItem.ItemExtend.SimpleWay);
            //            if (alSubtbls == null)
            //            {
            //                MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                alFeeItem = null;
            //                return;
            //            }

            //            string combNo = ulParm.management.GetNewOrderComboID();
            //            if (combNo == "")
            //            {
            //                MessageBox.Show("获得新组合号出错！\n" + ulParm.management.Err);
            //                alFeeItem = null;
            //                return;
            //            }

            //            for (int m = 0; m < alSubtbls.Count; m++)
            //            {

            //                //rep_no++;//插入划价表时增加处方内流水号；
            //                Neusoft.HISFC.Models.Fee.Item item = null;
            //                Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                try
            //                {
            //                    item = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                    if (item == null)
            //                    {

            //                        undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                        if (undrugzt == null)
            //                        {
            //                            MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                    }

            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                    alFeeItem = null;
            //                }

            //                Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                newOrder.RecipeNo = "";
            //                if (item != null)
            //                {
            //                    newOrder.Item = item.Clone();
            //                }
            //                else if (undrugzt != null)
            //                {
            //                    newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                    newOrder.Item.ID = undrugzt.ID;
            //                    newOrder.Item.Name = undrugzt.Name;
            //                    newOrder.Mark3 = "SUBTBL";//复合项目
            //                    //								newOrder.Mark2 = undrugzt.confirmFlag;
            //                    //By Maokb 061016
            //                    if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                        || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                    {
            //                        newOrder.Mark2 = "1";
            //                    }
            //                    else
            //                    {
            //                        newOrder.Mark2 = "0";
            //                    }
            //                    newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                    newOrder.Unit = "[复合项]";
            //                    newOrder.Item.PriceUnit = "[复合项]";
            //                    newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                    newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                }
            //                newOrder.QTY = temp.QTY;
            //                if (item != null)
            //                {
            //                    newOrder.Unit = item.PriceUnit;
            //                }

            //                newOrder.Combo.ID = combNo;//组合号
            //                temp.NurseStation.User01 = combNo;//关联的载体
            //                newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                if (newOrder.ID == "")
            //                {
            //                    MessageBox.Show("获得医嘱流水号出错！");
            //                    alFeeItem = null;
            //                    return;
            //                }
            //                newOrder.Item.isPharmacy = false;
            //                newOrder.IsSubtbl = true;
            //                newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                newOrder.SequenceNo = -1;
            //                if (newOrder.ExeDept.ID == "")//执行科室默认
            //                    newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList feeitem = Classes.Function.ChangeToFeeItemList(newOrder);
            //                if (feeitem == null)
            //                {
            //                    MessageBox.Show("转换成费用实体出错！");
            //                    alFeeItem = null;
            //                    return;
            //                }
            //                alFeeItem.Add(feeitem);
            //            }
            //            #endregion
            //        }
            //        #endregion
            //        #region 抽血方式为奇数
            //        else
            //        {
            //            alMedItem.Add(medItem);
            //            temp.NurseStation.User01 = combNO;
            //        }

            //        altempMedItem = alMedItem;

            //        if (alMedItem.Count >= 0)
            //        {
            //            foreach (Neusoft.HISFC.Models.MedTech.MedTechItem item in alMedItem)
            //            {
            //                #region 合抽血费
            //                if (item == alMedItem[0])
            //                {
            //                    #region 附材信息
            //                    ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(ULOrderUsage);
            //                    if (alSubtbls == null)
            //                    {
            //                        MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                        alFeeItem = null;
            //                        return;
            //                    }

            //                    for (int m = 0; m < alSubtbls.Count; m++)
            //                    {

            //                        //rep_no++;//插入划价表时增加处方内流水号；
            //                        Neusoft.HISFC.Models.Fee.Item feeitem = null;
            //                        Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                        try
            //                        {
            //                            feeitem = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                            if (item == null)
            //                            {

            //                                undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                                if (undrugzt == null)
            //                                {
            //                                    MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                                    alFeeItem = null;
            //                                    return;
            //                                }
            //                            }

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show(ex.Message);
            //                            alFeeItem = null;
            //                        }

            //                        Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                        newOrder.RecipeNo = "";
            //                        if (item != null)
            //                        {
            //                            newOrder.Item = feeitem.Clone();
            //                        }
            //                        else if (undrugzt != null)
            //                        {
            //                            newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                            newOrder.Item.ID = undrugzt.ID;
            //                            newOrder.Item.Name = undrugzt.Name;
            //                            newOrder.Mark3 = "SUBTBL";//复合项目
            //                            //										newOrder.Mark2 = undrugzt.confirmFlag;
            //                            //By Maokb 061016
            //                            if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                                || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                            {
            //                                newOrder.Mark2 = "1";
            //                            }
            //                            else
            //                            {
            //                                newOrder.Mark2 = "0";
            //                            }
            //                            newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                            newOrder.Unit = "[复合项]";
            //                            newOrder.Item.PriceUnit = "[复合项]";
            //                            newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                            newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                        }
            //                        newOrder.QTY = temp.QTY;
            //                        if (item != null)
            //                        {
            //                            newOrder.Unit = feeitem.PriceUnit;
            //                        }

            //                        newOrder.Combo.ID = combNO;//组合号
            //                        newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                        if (newOrder.ID == "")
            //                        {
            //                            MessageBox.Show("获得医嘱流水号出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        newOrder.Item.isPharmacy = false;
            //                        newOrder.IsSubtbl = true;
            //                        newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                        newOrder.SequenceNo = -1;
            //                        if (newOrder.ExeDept.ID == "")//执行科室默认
            //                            newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                        Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList fee = Classes.Function.ChangeToFeeItemList(newOrder);
            //                        if (fee == null)
            //                        {
            //                            MessageBox.Show("转换成费用实体出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        alFeeItem.Add(fee);
            //                    }
            //                    #endregion
            //                }
            //                #endregion
            //                #region 具有设备类型和容器类型相同的项目则合抽血管
            //                if (Classes.Function.RemoveOrderHaveSameContiner(altempMedItem, item) > 0)
            //                {
            //                    #region 附材信息
            //                    ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(item.ItemExtend.SimpleWay);
            //                    if (alSubtbls == null)
            //                    {
            //                        MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                        alFeeItem = null;
            //                        return;
            //                    }

            //                    for (int m = 0; m < alSubtbls.Count; m++)
            //                    {

            //                        //rep_no++;//插入划价表时增加处方内流水号；
            //                        Neusoft.HISFC.Models.Fee.Item feeitem = null;
            //                        Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                        try
            //                        {
            //                            feeitem = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                            if (item == null)
            //                            {

            //                                undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                                if (undrugzt == null)
            //                                {
            //                                    MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                                    alFeeItem = null;
            //                                    return;
            //                                }
            //                            }

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show(ex.Message);
            //                            alFeeItem = null;
            //                        }

            //                        Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                        newOrder.RecipeNo = "";
            //                        if (item != null)
            //                        {
            //                            newOrder.Item = feeitem.Clone();
            //                        }
            //                        else if (undrugzt != null)
            //                        {
            //                            newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                            newOrder.Item.ID = undrugzt.ID;
            //                            newOrder.Item.Name = undrugzt.Name;
            //                            newOrder.Mark3 = "SUBTBL";//复合项目
            //                            //										newOrder.Mark2 = undrugzt.confirmFlag;
            //                            //By Maokb 061016
            //                            if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                                || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                            {
            //                                newOrder.Mark2 = "1";
            //                            }
            //                            else
            //                            {
            //                                newOrder.Mark2 = "0";
            //                            }
            //                            newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                            newOrder.Unit = "[复合项]";
            //                            newOrder.Item.PriceUnit = "[复合项]";
            //                            newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                            newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                        }
            //                        newOrder.QTY = temp.QTY;
            //                        if (item != null)
            //                        {
            //                            newOrder.Unit = feeitem.PriceUnit;
            //                        }

            //                        newOrder.Combo.ID = combNO;//组合号
            //                        newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                        if (newOrder.ID == "")
            //                        {
            //                            MessageBox.Show("获得医嘱流水号出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        newOrder.Item.isPharmacy = false;
            //                        newOrder.IsSubtbl = true;
            //                        newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                        newOrder.SequenceNo = -1;
            //                        if (newOrder.ExeDept.ID == "")//执行科室默认
            //                            newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                        Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList fee = Classes.Function.ChangeToFeeItemList(newOrder);
            //                        if (fee == null)
            //                        {
            //                            MessageBox.Show("转换成费用实体出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        alFeeItem.Add(fee);
            //                    }
            //                    #endregion
            //                }
            //                #endregion
            //            }
            //        }
            //        #endregion
            //    }
            //}
            #endregion

            #region 处理非加急医嘱
            //if (alNotEmr.Count > 0)
            //{
            //    foreach (Neusoft.HISFC.Models.Order.OutPatient.Order temp in alNotEmr)
            //    {
            //        #region 获得项目扩展信息
            //        Neusoft.HISFC.Models.MedTech.MedTechItem medItem = ulParm.medManager.SelectDeptItem(temp.ExeDept.ID, temp.Item.ID);
            //        if (medItem == null)
            //        {
            //            MessageBox.Show("获得项目扩展信息出错！");
            //            alFeeItem = null;
            //            return;
            //        }
            //        #endregion
            //        #region 找不到抽血方式，提示
            //        if (medItem.ItemExtend.BloodWay == null || medItem.ItemExtend.BloodWay == "")
            //        {
            //            MessageBox.Show("项目:" + temp.Item.Name + "的扩展信息[抽血方式]没有维护！请通知相关人员维护");
            //            continue;
            //        }
            //        #endregion
            //        #region 抽血方式为偶数
            //        if (neusoft.neHISFC.Components.Function.NConvert.ToInt32(medItem.ItemExtend.BloodWay) % 2 == 0)
            //        {
            //            #region 附材信息
            //            ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(medItem.ItemExtend.SimpleWay);
            //            if (alSubtbls == null)
            //            {
            //                MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                alFeeItem = null;
            //                return;
            //            }
            //            if (alSubtbls.Count <= 0)
            //            {
            //                continue;
            //            }
            //            string combNo = ulParm.management.GetNewOrderComboID();
            //            if (combNo == "")
            //            {
            //                MessageBox.Show("获得新组合号出错！\n" + ulParm.management.Err);
            //                alFeeItem = null;
            //                return;
            //            }

            //            for (int m = 0; m < alSubtbls.Count; m++)
            //            {

            //                //rep_no++;//插入划价表时增加处方内流水号；
            //                Neusoft.HISFC.Models.Fee.Item item = null;
            //                Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                try
            //                {
            //                    item = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                    if (item == null)
            //                    {

            //                        undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                        if (undrugzt == null)
            //                        {
            //                            MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                    }

            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                    alFeeItem = null;
            //                }

            //                Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                newOrder.RecipeNo = "";
            //                if (item != null)
            //                {
            //                    newOrder.Item = item.Clone();
            //                }
            //                else if (undrugzt != null)
            //                {
            //                    newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                    newOrder.Item.ID = undrugzt.ID;
            //                    newOrder.Item.Name = undrugzt.Name;
            //                    newOrder.Mark3 = "SUBTBL";//复合项目
            //                    //								newOrder.Mark2 = undrugzt.confirmFlag;
            //                    //By Maokb 061016
            //                    if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                        || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                    {
            //                        newOrder.Mark2 = "1";
            //                    }
            //                    else
            //                    {
            //                        newOrder.Mark2 = "0";
            //                    }
            //                    newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                    newOrder.Unit = "[复合项]";
            //                    newOrder.Item.PriceUnit = "[复合项]";
            //                    newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                    newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                }
            //                newOrder.QTY = temp.QTY;
            //                if (item != null)
            //                {
            //                    newOrder.Unit = item.PriceUnit;
            //                }

            //                newOrder.Combo.ID = combNo;//组合号
            //                temp.NurseStation.User01 = combNo;//关联的载体
            //                newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                if (newOrder.ID == "")
            //                {
            //                    MessageBox.Show("获得医嘱流水号出错！");
            //                    alFeeItem = null;
            //                    return;
            //                }
            //                newOrder.Item.isPharmacy = false;
            //                newOrder.IsSubtbl = true;
            //                newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                newOrder.SequenceNo = -1;
            //                if (newOrder.ExeDept.ID == "")//执行科室默认
            //                    newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList feeitem = Classes.Function.ChangeToFeeItemList(newOrder);
            //                if (feeitem == null)
            //                {
            //                    MessageBox.Show("转换成费用实体出错！");
            //                    alFeeItem = null;
            //                    return;
            //                }
            //                alFeeItem.Add(feeitem);
            //            }
            //            #endregion
            //        }
            //        #endregion
            //        #region 抽血方式为奇数
            //        else
            //        {
            //            alMedItem.Add(medItem);
            //            temp.NurseStation.User01 = combNO;
            //        }

            //        altempMedItem = alMedItem;

            //        if (alMedItem.Count >= 0)
            //        {
            //            foreach (Neusoft.HISFC.Models.MedTech.MedTechItem item in alMedItem)
            //            {
            //                #region 合抽血费
            //                if (item == alMedItem[0])
            //                {
            //                    #region 附材信息
            //                    ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(ULOrderUsage);
            //                    if (alSubtbls == null)
            //                    {
            //                        MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                        alFeeItem = null;
            //                        return;
            //                    }
            //                    if (alSubtbls.Count <= 0)
            //                    {
            //                        continue;
            //                    }
            //                    for (int m = 0; m < alSubtbls.Count; m++)
            //                    {

            //                        //rep_no++;//插入划价表时增加处方内流水号；
            //                        Neusoft.HISFC.Models.Fee.Item feeitem = null;
            //                        Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                        try
            //                        {
            //                            feeitem = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                            if (item == null)
            //                            {

            //                                undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                                if (undrugzt == null)
            //                                {
            //                                    MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                                    alFeeItem = null;
            //                                    return;
            //                                }
            //                            }

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show(ex.Message);
            //                            alFeeItem = null;
            //                        }

            //                        Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                        newOrder.RecipeNo = "";
            //                        if (item != null)
            //                        {
            //                            newOrder.Item = feeitem.Clone();
            //                        }
            //                        else if (undrugzt != null)
            //                        {
            //                            newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                            newOrder.Item.ID = undrugzt.ID;
            //                            newOrder.Item.Name = undrugzt.Name;
            //                            newOrder.Mark3 = "SUBTBL";//复合项目
            //                            //										newOrder.Mark2 = undrugzt.confirmFlag;
            //                            //By Maokb 061016
            //                            if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                                || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                            {
            //                                newOrder.Mark2 = "1";
            //                            }
            //                            else
            //                            {
            //                                newOrder.Mark2 = "0";
            //                            }
            //                            newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                            newOrder.Unit = "[复合项]";
            //                            newOrder.Item.PriceUnit = "[复合项]";
            //                            newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                            newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                        }
            //                        newOrder.QTY = temp.QTY;
            //                        if (item != null)
            //                        {
            //                            newOrder.Unit = feeitem.PriceUnit;
            //                        }

            //                        newOrder.Combo.ID = combNO;//组合号
            //                        newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                        if (newOrder.ID == "")
            //                        {
            //                            MessageBox.Show("获得医嘱流水号出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        newOrder.Item.isPharmacy = false;
            //                        newOrder.IsSubtbl = true;
            //                        newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                        newOrder.SequenceNo = -1;
            //                        if (newOrder.ExeDept.ID == "")//执行科室默认
            //                            newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                        Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList fee = Classes.Function.ChangeToFeeItemList(newOrder);
            //                        if (fee == null)
            //                        {
            //                            MessageBox.Show("转换成费用实体出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        alFeeItem.Add(fee);
            //                    }
            //                    #endregion
            //                }
            //                #endregion
            //                #region 具有设备类型和容器类型相同的项目则合抽血管
            //                if (Classes.Function.RemoveOrderHaveSameContiner(altempMedItem, item) > 0)
            //                {
            //                    #region 附材信息
            //                    ArrayList alSubtbls = ulParm.feeManager.GetInjectInfoByUsage(item.ItemExtend.SimpleWay);
            //                    if (alSubtbls == null)
            //                    {
            //                        MessageBox.Show("获得院注次数出错！\n" + ulParm.feeManager.Err);
            //                        alFeeItem = null;
            //                        return;
            //                    }
            //                    if (alSubtbls.Count <= 0)
            //                    {
            //                        continue;
            //                    }
            //                    for (int m = 0; m < alSubtbls.Count; m++)
            //                    {

            //                        //rep_no++;//插入划价表时增加处方内流水号；
            //                        Neusoft.HISFC.Models.Fee.Item feeitem = null;
            //                        Neusoft.HISFC.Models.Fee.Undrugzt undrugzt = null;
            //                        try
            //                        {
            //                            feeitem = ulParm.itemManager.GetItem(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);//获得最新项目信息
            //                            if (item == null)
            //                            {

            //                                undrugzt = ulParm.ztManager.GetSingleUndrugzt(((neusoft.neHISFC.Components.Object.neuObject)alSubtbls[m]).ID);
            //                                if (undrugzt == null)
            //                                {
            //                                    MessageBox.Show("未找到附材项目或该项目已经停用,附材:" + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).ID + ((Neusoft.HISFC.Models.Base.Item)alSubtbls[m]).Name + ulParm.ztManager.Err);
            //                                    alFeeItem = null;
            //                                    return;
            //                                }
            //                            }

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show(ex.Message);
            //                            alFeeItem = null;
            //                        }

            //                        Neusoft.HISFC.Models.Order.OutPatient.Order newOrder = temp.Clone();
            //                        newOrder.RecipeNo = "";
            //                        if (item != null)
            //                        {
            //                            newOrder.Item = feeitem.Clone();
            //                        }
            //                        else if (undrugzt != null)
            //                        {
            //                            newOrder.Item = new Neusoft.HISFC.Models.Base.Item();
            //                            newOrder.Item.ID = undrugzt.ID;
            //                            newOrder.Item.Name = undrugzt.Name;
            //                            newOrder.Mark3 = "SUBTBL";//复合项目
            //                            //										newOrder.Mark2 = undrugzt.confirmFlag;
            //                            //By Maokb 061016
            //                            if (undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.All
            //                                || undrugzt.confirmFlag == Neusoft.HISFC.Models.Fee.ConfirmState.Outpatient)
            //                            {
            //                                newOrder.Mark2 = "1";
            //                            }
            //                            else
            //                            {
            //                                newOrder.Mark2 = "0";
            //                            }
            //                            newOrder.Item.SysClass.ID = undrugzt.sysClass;
            //                            newOrder.Unit = "[复合项]";
            //                            newOrder.Item.PriceUnit = "[复合项]";
            //                            newOrder.Item.MinFee = new neusoft.neHISFC.Components.Object.neuObject();
            //                            newOrder.Item.Price = GetUndrugZtPrice(ulParm.ztInfo, ulParm.itemManager, undrugzt.ID);
            //                        }
            //                        newOrder.QTY = temp.QTY;
            //                        if (item != null)
            //                        {
            //                            newOrder.Unit = feeitem.PriceUnit;
            //                        }

            //                        newOrder.Combo.ID = combNO;//组合号
            //                        newOrder.ID = Function.GetNewOrderID(ulParm.management); ;//医嘱流水号
            //                        if (newOrder.ID == "")
            //                        {
            //                            MessageBox.Show("获得医嘱流水号出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        newOrder.Item.isPharmacy = false;
            //                        newOrder.IsSubtbl = true;
            //                        newOrder.Usage = new neusoft.neHISFC.Components.Object.neuObject();
            //                        newOrder.SequenceNo = -1;
            //                        if (newOrder.ExeDept.ID == "")//执行科室默认
            //                            newOrder.ExeDept = (ulParm.management.Operator as Neusoft.HISFC.Models.RADT.Person).Dept;//newOrder.ReciptDept.Clone();

            //                        Neusoft.HISFC.Models.Fee.OutPatient.FeeItemList fee = Classes.Function.ChangeToFeeItemList(newOrder);
            //                        if (fee == null)
            //                        {
            //                            MessageBox.Show("转换成费用实体出错！");
            //                            alFeeItem = null;
            //                            return;
            //                        }
            //                        alFeeItem.Add(fee);
            //                    }
            //                    #endregion
            //                }
            //                #endregion
            //            }
            //        }
            //            #endregion
            //    }
            //}
            #endregion
        }
        
        /// <summary>
        /// 去除具有相同设备类型和容器类型的医嘱(未实现)
        /// </summary>
        /// <param name="altempMedItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int RemoveOrderHaveSameContiner(ArrayList altempMedItem, Neusoft.HISFC.Models.MedTech.Management.Member item)
        {
            //if (altempMedItem.Count <= 0)
            //{
            //    return 0;
            //}

            int count = 0;
            //ArrayList al = new ArrayList();
            
            //foreach (Neusoft.HISFC.Models.MedTech.Management.Member temp in altempMedItem)
            //{
            //    //设备类型和容器类型相同
            //    if (temp.ItemExtend.Container == item.ItemExtend.Container && temp.ItemExtend.MachineType == item.ItemExtend.MachineType)
            //    {
            //        al.Add(temp);
            //        count++;
            //    }
            //}
            //for (int i = 0; i < al.Count; i++)
            //{
            //    altempMedItem.Remove(al[i]);
            //}
            return count;
        }
        
        /// <summary>
        /// 查找复合要求的限定额度
        /// </summary>
        /// <param name="stats">统计编码</param>
        /// <param name="relations">限定额度关系</param>
        /// <returns>当前显额</returns>
        private static Neusoft.FrameWork.Models.NeuObject GetRelation(ArrayList stats, ArrayList relations)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject stat in stats)
            {
                foreach (Neusoft.HISFC.Models.Base.PactStatRelation obj in relations)
                {
                    if (stat.ID == obj.Group.ID)
                    {
                        return obj;
                    }
                }
            }
            return null;
        }
        
        /// <summary>
        /// 计算公费超标
        /// </summary>
        /// <param name="rInfo"></param>
        /// <param name="alOrder"></param>
        /// <param name="relations"></param>
        /// <param name="errText"></param>
        public static int Compute(Neusoft.HISFC.Models.Registration.Register rInfo, ArrayList alOrder, ArrayList relations, ref string PayType, ref string errText)
        {
            //ArrayList feeDetails = new ArrayList();

            //foreach (Neusoft.HISFC.Models.Order.OutPatient.Order order in alOrder)
            //{
            //    Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeItem = ChangeToFeeItemList(order);

            //    if (feeItem != null)
            //    {
            //        feeDetails.Add(feeItem);
            //    }
            //}

            //// TODO:  添加 ComputePubFee.neusoft.Common.Clinic.Interface.IComputePubFee.Compute 实现
            //if (rInfo == null || rInfo.ID == "")
            //{
            //    errText = "患者基本信息为空！";
            //    return -1;
            //}

            //if (feeDetails == null)
            //{
            //    errText = "费用明细集合为空！";
            //    return -1;
            //}

            //if (rInfo.Pact == null || rInfo.Pact.ID == "")
            //{
            //    errText = "患者合同单位为空！";
            //    return -1;
            //}

            
            //Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeMgr = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

            ////清空总额
            //for (int i = 0; i < relations.Count; i++)
            //{
            //    ((Neusoft.FrameWork.Models.NeuObject)relations[i]).User03 = "0";
            //}

            //foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in feeDetails)
            //{
            //    if (f == null)
            //    {
            //        continue;
            //    }

            //    //rowFindStat --根据最小费用找到对应大类
                
            //    ArrayList stats = feeMgr.GetGFDYFeeCodeStatByFeeCode(f.Item.MinFee.ID);

            //    //没有找到对应的费用大类说明肯定不存在超标限制
            //    if (stats == null)//if(rowFindStat == null)
            //    {
            //        continue;
            //    }

            //    //获得限定额度关系
            //    Neusoft.FrameWork.Models.NeuObject relation = GetRelation(stats, relations);

            //    //没有找到对应的费用大类限额说明不存在超标限制
            //    if (relation == null)//if(index == -1)
            //    {
            //        continue;
            //    }

            //    //临时存储患者花费总金额
            //    decimal tempTotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(relation.User03);
            //    //统计大类的限额
            //    decimal limitCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(((Neusoft.HISFC.Models.Base.PactStatRelation)relation).Quota);

            //    //超过限额
            //    if (tempTotCost + f.FT.TotCost > limitCost)
            //    {
            //        if (relation.User01 != "TRUE")
            //        {
            //            MessageBox.Show("患者" + rInfo.Name + "的" + ((Neusoft.HISFC.Models.Base.PactStatRelation)relation).StatClass.Name + "已经超标！察看限额请在患者费用信息处点击", "提示");
            //            relation.User01 = "TRUE";
            //        }
            //        return 0;
            //    }
            //    else
            //    {
            //        relation.User03 = (tempTotCost + f.FT.TotCost).ToString();
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 获得当前公费插件实例
        /// </summary>
        /// <returns>null 获得实例失败</returns>
        public static object GetPubFeeInstance()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam myCtrl = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            //公费算法插件路径
            string pubFeeComputeDll = null;
            string errText = "";
            //获得公费插件路径
            ////pubFeeComputeDll = myCtrl.QueryControlerInfo(Neusoft.Common.Clinic.Class.Const.PUBFEECOMPUTE);
            if (pubFeeComputeDll == null || pubFeeComputeDll == "")
            {
                errText = "没有维护公费算法方案!请维护";
                return null;
            }
            //得到全路径
            pubFeeComputeDll = Application.StartupPath + pubFeeComputeDll;
            Assembly a = null;
            System.Type[] types = null;
            //临时实例
            object objInstance = null;
            try
            {
                //获得当前路径dll的反射信息
                a = Assembly.LoadFrom(pubFeeComputeDll);
                //得到反射获得所有类型.
                types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    //如果符合公费计算接口,那么实例化,并结束循环.
                    if (type.GetInterface("IComputePubFee") != null)
                    {
                        //实例化公费实体.
                        objInstance = System.Activator.CreateInstance(type);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                errText = ex.Message;
                return null;
            }
            finally
            {
                a = null;
                types = null;
            }
            
            return objInstance;
        }

        /// <summary>
        /// 公费费用计算
        /// </summary>
        /// <param name="pubFeeInstance">公费费用计算插件实例</param>
        /// <param name="r">挂号实体</param>
        /// <param name="feeDetails">费用明细集合</param>
        /// <param name="relations">限额关系</param>
        /// <param name="errText">错误信息</param>
        /// <returns>- 1 失败 0 成功</returns>
        public static int ComputePubFee(object pubFeeInstance, Neusoft.HISFC.Models.Registration.Register r, ref ArrayList feeDetails, ArrayList relations, ref string errText)
        {
            if (pubFeeInstance == null)
            {
                errText = "公费算法实例为空!";
                return -1;
            }
            if (pubFeeInstance.GetType().GetInterface("IComputePubFee") == null)
            {
                errText = "公费算法没有实现IComputePubFee接口!";
                return -1;
            }
            int iReturn = 0;//返回值
            try
            {
                ////iReturn = ((Neusoft.Common.Clinic.Interface.IComputePubFee)pubFeeInstance).Compute(r, ref feeDetails, relations, ref errText);
            }
            catch (Exception ex)
            {
                errText += ex.Message;
                return -1;
            }
            if (iReturn == -1)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 取医嘱流水号
        /// </summary>
        /// <returns></returns>
        public static string GetNewOrderID()
        {
            orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            string rtn = "";
            rtn = orderManager.GetNewOrderID();
            if (rtn == null || rtn == "")
            {
                MessageBox.Show("错误获得医嘱流水号！");
            }
            else
            {
                return rtn;
            }
            return "";
        }

        public static void SethsUsageAndSub()
        {
            Neusoft.HISFC.BizLogic.Order.OutPatient.Order myOrder = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

            hsUsageAndSub = myOrder.GetUsageAndSub();
        }

    }
}
    


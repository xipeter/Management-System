using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.BizProcess.Integrate.FeeInterface;
using System.Collections;
using System.Data;
using Neusoft.HISFC.Models.Fee.Outpatient;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Registration;
using System.Reflection;
using Neusoft.HISFC.BizProcess.Interface.FeeInterface;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 整合的入出转管理类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class Fee : IntegrateBase, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {

        #region liuq 2007-8-23 追加
        #region 门诊内部分发票（废弃）

        /// <summary>
        /// 门诊按照执行科室,最小费用等分发票
        /// </summary>
        /// <param name="payKindCode">患者的费用类别</param>
        /// <param name="feeItemLists">患者的总体费用明细</param>
        /// <returns>成功 分好的费用明细,每个ArrayList代表一组应该生成发票的费用明细 失败 null</returns>
        public ArrayList SplitInvoice(string payKindCode, ref ArrayList feeItemLists)
        {

            // 获得是否按照执行科室分发票,默认不刷新参数,默认值为 false即不按照执行科室分发票.
            bool isSplitByExeDept = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_SPLIT_INVOICE_BY_EXEDEPT, false, false);

            //分组后发票
            ArrayList exeGroupList = new ArrayList();

            if (isSplitByExeDept)
            {
                //按照执行科室分组
                exeGroupList = CollectFeeItemListsByExeDeptCode(feeItemLists);
            }
            else
            {
                exeGroupList = feeItemLists;
            }

            //获得是否按照最小分发票,默认不刷新参数,默认值为 false即不按照最小分发票.
            bool isSplitByFeeCode = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.IS_SPLIT_INVOICE_BY_FEECODE, false, false);

            ArrayList finalSplitList = new ArrayList();

            if (isSplitByFeeCode)
            {
                foreach (ArrayList groupList in exeGroupList)
                {
                    ArrayList spList = this.SplitInvoiceByFeeCode(payKindCode, groupList);

                    foreach (ArrayList list in spList)
                    {
                        finalSplitList.Add(list);
                    }
                }
            }
            else
            {
                finalSplitList = exeGroupList;
            }

            //feeItemLists = new ArrayList();

            foreach (ArrayList list in finalSplitList)
            {
                foreach (FeeItemList f in list)
                {
                    feeItemLists.Add(f);
                }
            }

            return finalSplitList;
        }



        /// <summary>
        /// 获得对应支付方式的按照最小费用条目分发票的明细条目
        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <returns></returns>
        private int GetSplitCount(string payKindCode)
        {
            int count = 0;

            switch (payKindCode)
            {
                case "01":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_ZF_COUNT, false, 5);
                    break;
                case "02":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_YB_COUNT, false, 5);
                    break;
                case "03":
                    count = controlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.Const.SPLIT_INVOICE_BY_FEECODE_GF_COUNT, false, 5);
                    break;
            }

            return count;
        }

        /// <summary>
        /// 按照最小费用分明细
        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <param name="feeItemList">费用明细</param>
        /// <returns></returns>
        private ArrayList SplitInvoiceByFeeCode(string payKindCode, ArrayList feeItemList)
        {
            ArrayList sortList = this.CollectFeeItemListsByFeeCode(feeItemList);

            ArrayList finalList = new ArrayList();

            foreach (ArrayList list in sortList)
            {
                ArrayList sortFeeCodeList = this.SplitByFeeCodeCount(payKindCode, list);

                foreach (ArrayList fList in sortFeeCodeList)
                {
                    finalList.Add(fList);
                }
            }

            return finalList;
        }

        /// <summary>
        /// 按照最小费用限制数量分明细
        /// </summary>
        /// <param name="payKindCode">患者的支付方式类别</param>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns></returns>
        private ArrayList SplitByFeeCodeCount(string payKindCode, ArrayList feeItemLists)
        {
            int count = this.GetSplitCount(payKindCode);

            ArrayList splitArrayList = new ArrayList();
            ArrayList groupList = new ArrayList();

            while (feeItemLists.Count > count)
            {
                groupList = new ArrayList();

                for (int i = 0; i < count; i++)
                {
                    FeeItemList f = feeItemLists[0] as FeeItemList;

                    groupList.Add(f);
                }
                foreach (FeeItemList f in groupList)
                {
                    feeItemLists.Remove(f);
                }
                splitArrayList.Add(groupList);
            }
            if (feeItemLists.Count > 0)
            {
                splitArrayList.Add(feeItemLists);
            }

            return splitArrayList;
        }

        /// <summary>
        /// 按照最小费用排序
        /// </summary>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns>成功 排序好的处方明细 失败 null</returns>
        private ArrayList CollectFeeItemListsByFeeCode(ArrayList feeItemLists)
        {
            feeItemLists.Sort(new SortFeeItemListByFeeCode());

            ArrayList sorList = new ArrayList();

            while (feeItemLists.Count > 0)
            {
                ArrayList sameFeeItemLists = new ArrayList();
                FeeItemList compareItem = feeItemLists[0] as FeeItemList;
                foreach (FeeItemList f in feeItemLists)
                {
                    if (f.Item.MinFee.ID == compareItem.Item.MinFee.ID)
                    {
                        sameFeeItemLists.Add(f);
                    }
                    else
                    {
                        break;
                    }
                }
                sorList.Add(sameFeeItemLists);
                foreach (FeeItemList f in sameFeeItemLists)
                {
                    feeItemLists.Remove(f);
                }
            }

            return sorList;
        }

        /// <summary>
        /// 按照执行科室排序
        /// </summary>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns>成功 排序好的处方明细 失败 null</returns>
        private ArrayList CollectFeeItemListsByExeDeptCode(ArrayList feeItemLists)
        {
            feeItemLists.Sort(new SortFeeItemListByExeDeptCode());

            ArrayList sorList = new ArrayList();

            while (feeItemLists.Count > 0)
            {
                ArrayList sameFeeItemLists = new ArrayList();
                FeeItemList compareItem = feeItemLists[0] as FeeItemList;
                foreach (FeeItemList f in feeItemLists)
                {
                    if (f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID)
                    {
                        sameFeeItemLists.Add(f);
                    }
                    else
                    {
                        break;
                    }
                }
                sorList.Add(sameFeeItemLists);
                foreach (FeeItemList f in sameFeeItemLists)
                {
                    feeItemLists.Remove(f);
                }
            }

            return sorList;
        }

        /// <summary>
        /// 排序类
        /// </summary>
        private class SortFeeItemListByExeDeptCode : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if (x is FeeItemList && y is FeeItemList)
                {
                    return ((FeeItemList)x).ExecOper.Dept.ID.CompareTo(
                        ((FeeItemList)y).ExecOper.Dept.ID);
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }

        /// <summary>
        /// 排序类
        /// </summary>
        private class SortFeeItemListByFeeCode : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if (x is FeeItemList && y is FeeItemList)
                {
                    return ((FeeItemList)x).Item.MinFee.ID.CompareTo(
                        ((FeeItemList)y).Item.MinFee.ID);
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }

        #endregion

        #endregion

        #region 更据接口实现分发票
        /// <summary>
        /// 更据接口实现分发票
        /// </summary>
        /// <param name="register"></param>
        /// <param name="feeItemLists"></param>
        /// <returns></returns>
        public ArrayList SplitInvoice(Neusoft.HISFC.Models.Registration.Register register, ref ArrayList feeItemLists)
        {
            ISplitInvoice myISplitInvoice = null;
            if (this.trans == null)
            {
                myISplitInvoice = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice;
            }
            else
            {
                myISplitInvoice = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice), this.trans) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice;
            }
            //{698738F7-D127-47b6-868E-4161E3949CF5}
            if (myISplitInvoice == null)
            {
                this.Err = "请在维护门诊分发票的方式";
                return null;
            }
            return myISplitInvoice.SplitInvoice(register, ref feeItemLists);
        }

        #endregion

        #region 变量

        /// <summary>
        /// 费用类业务层 {2CEA3B1D-2E59-44ac-9226-7724413173C5} 对业务层的引用全部改为非静态的变量
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// item
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Fee.Item itemManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 非药品组套
        /// </summary>
        //protected static Neusoft.HISFC.BizLogic.Fee.UndrugComb undrugCombManager = new Neusoft.HISFC.BizLogic.Fee.UndrugComb();

        /// <summary>
        /// /// 发票业务层
        /// </summary>
        //protected static Neusoft.HISFC.BizLogic.Fee.InvoiceService invoiceServiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceService();
        protected  Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum invoiceServiceManager = new Neusoft.HISFC.BizLogic.Fee.InvoiceServiceNoEnum();

        /// <summary>
        /// 财务组业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Fee.EmployeeFinanceGroup employeeFinanceGroupManager = new Neusoft.HISFC.BizLogic.Fee.EmployeeFinanceGroup();

        /// <summary>
        /// 控制类业务层
        /// </summary>
        protected  Neusoft.FrameWork.Management.ControlParam controlManager = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// 门诊业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.Outpatient outpatientManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 门诊医嘱业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderOutpatientManager = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();

        /// <summary>
        /// 医嘱业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();

        /// <summary>
        /// 终端预约业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Terminal.Terminal terminalManager = new Neusoft.HISFC.BizLogic.Terminal.Terminal();

        ////{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        protected Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct medicalTeamForDoctBizLogic = new Neusoft.HISFC.BizLogic.Order.MedicalTeamForDoct();

        /// <summary>
        /// 药品业务层
        /// </summary>
        protected  Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmarcyManager = new Pharmacy();

        /// <summary>
        /// 管理业务层
        /// </summary>
        protected  Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Manager();

        /// <summary>
        /// 挂号业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();

        /// <summary>
        /// 本地医保业务层
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Fee.Interface interfaceManager = new Neusoft.HISFC.BizLogic.Fee.Interface();

        /// <summary>
        /// 当前医保公费接口
        /// </summary>
        protected  MedcareInterfaceProxy medcareInterfaceProxy = new MedcareInterfaceProxy();

        /// <summary>
        /// 合同单位类
        /// </summary>
        protected  Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

        /// <summary>
        /// 患者实体(liu.xq)
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 是否忽略医保公费接口
        /// </summary>
        private bool isIgnoreMedcareInterface = false;

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        protected  Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 体检业务层
        /// </summary>
        protected  Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager examiIntegrate = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager();
        /// <summary>
        /// 员工
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
        //复合项目明细业务层
        Neusoft.HISFC.BizLogic.Fee.UndrugPackAge undrugPackAgeMgr = new Neusoft.HISFC.BizLogic.Fee.UndrugPackAge();

        /// <summary>
        /// 调号业务层{BF01254E-3C73-43d4-A644-4B258438294E}
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InvoiceJumpRecord invoiceJumpRecordMgr = new Neusoft.HISFC.BizLogic.Fee.InvoiceJumpRecord();
  
        /// <summary>
        /// 门诊收费是否需要更新发票号
        /// </summary>
        protected bool isNeedUpdateInvoiceNO = true;

        /// <summary>
        /// 是否忽略在院状态更新住院主表
        /// </summary>
        protected bool isIgnoreInstate = false;
        /// <summary>
        /// 欠费提示类型
        /// </summary>
        private MessType messType = MessType.Y;

        #region 门诊帐户
        /// <summary>
        /// 门诊帐户类业务层
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 账户密码输入
        /// </summary>
        protected static Neusoft.HISFC.BizProcess.Interface.Account.IPassWord ipassWord = null;
        #endregion
        /// <summary>
        /// 物资收费
        /// </summary>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        protected static Neusoft.HISFC.BizProcess.Integrate.Material.Material materialManager = new Neusoft.HISFC.BizProcess.Integrate.Material.Material();

        /// <summary>
        /// 授权收费
        /// </summary>
        protected static Neusoft.HISFC.BizLogic.Fee.EmpowerFee empowerFeeManager = new Neusoft.HISFC.BizLogic.Fee.EmpowerFee();

        /// <summary>
        /// 终端确认业务层
        /// </summary>
        protected static Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
        #endregion

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;

            itemManager.SetTrans(trans);
            inpatientManager.SetTrans(trans);
            controlManager.SetTrans(trans);
            invoiceServiceManager.SetTrans(trans);
            employeeFinanceGroupManager.SetTrans(trans);
            //medcareInterfaceProxy.SetTrans(trans);
            outpatientManager.SetTrans(trans);
            orderManager.SetTrans(trans);
            orderOutpatientManager.SetTrans(trans);
            terminalManager.SetTrans(trans);
            pharmarcyManager.SetTrans(trans);
            registerManager.SetTrans(trans);
            interfaceManager.SetTrans(trans);
            managerIntegrate.SetTrans(trans);
            controlParamIntegrate.SetTrans(trans);
            examiIntegrate.SetTrans(trans);
            userManager.SetTrans(trans);
            undrugPackAgeMgr.SetTrans(trans);
            empowerFeeManager.SetTrans(trans);

            #region 门诊帐户
            accountManager.SetTrans(trans);
            #endregion
        }

        #region 属性

        /// <summary>
        /// 是否忽略在院状态更新住院主表
        /// </summary>
        public bool IsIgnoreInstate
        {
            get
            {
                return this.isIgnoreInstate;
            }
            set
            {
                this.isIgnoreInstate = value;
            }
        }

        /// <summary>
        /// 门诊收费是否需要更新发票号
        /// </summary>
        public bool IsNeedUpdateInvoiceNO
        {
            get
            {
                return this.isNeedUpdateInvoiceNO;
            }
            set
            {
                this.isNeedUpdateInvoiceNO = value;
            }
        }

        /// <summary>
        /// 当前医保公费接口
        /// </summary>
        public MedcareInterfaceProxy MedcareInterfaceProxy
        {
            get
            {
                return medcareInterfaceProxy;
            }
        }

        /// <summary>
        /// 是否忽略医保公费接口
        /// </summary>
        public bool IsIgnoreMedcareInterface
        {
            set
            {
                this.isIgnoreMedcareInterface = value;
            }
        }
        /// <summary>
        /// 是否判断欠费，欠费是否提示
        /// </summary>
        public MessType MessageType
        {
            set
            {
                messType = value;
            }
            get
            {
                return messType;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 判断收费需要的参数是否合法
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemList">患者费用明细实体</param>
        /// <returns>成功: true 失败 false</returns>
        private bool IsValidFee(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            if (patient == null)
            {
                this.Err = Language.Msg("患者基本信息没有赋值");

                return false;
            }

            if (feeItemList == null)
            {
                this.Err = Language.Msg("患者费用信息没有赋值");

                return false;
            }

            if (feeItemList.FT.TotCost == 0)
            {
                this.Err = Language.Msg("费用总额不能为零：\n单价或数量不能为0");

                return false;
            }

            if (patient.PVisit.PatientLocation.NurseCell.ID == null || patient.PVisit.PatientLocation.NurseCell.ID.Trim() == string.Empty)
            {
                this.Err = Language.Msg("表现层患者护士站编码没有赋值!");

                return false;
            }

            if (feeItemList.ExecOper.Dept.ID == null || feeItemList.ExecOper.Dept.ID == string.Empty)
            {
                this.Err = Language.Msg("表现层执行科室没有赋值!");

                return false;
            }

            if (feeItemList.FTRate.ItemRate < 0)
            {
                this.Err = Language.Msg("收费比例赋值错误!");

                return false;
            }
            feeItemList.Item.Price = Math.Round(feeItemList.Item.Price, 4);
            if (!Neusoft.FrameWork.Public.String.IsPrecisionValid(feeItemList.Item.Price, 10, 4))
            {
                this.Err = feeItemList.Item.Name + Language.Msg("的价格精度不符合,标准的精度应该为小数点前6位,小数点后4位");

                return false;
            }
            feeItemList.Item.Qty = Math.Round(feeItemList.Item.Qty, 4);
            if (!Neusoft.FrameWork.Public.String.IsPrecisionValid(feeItemList.Item.Qty, 9, 4))
            {
                this.Err = feeItemList.Item.Name + Language.Msg("的数量精度不符合,标准的精度应该为小数点前5位,小数点后4位");

                return false;
            }
            feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.TotCost, 2);
            if (!Neusoft.FrameWork.Public.String.IsPrecisionValid(feeItemList.FT.TotCost, 10, 2))
            {
                this.Err = feeItemList.Item.Name + Language.Msg("的金额精度不符合,标准的精度应该为小数点前8位,小数点后2位");

                return false;
            }

            return true;
        }

        /// <summary>
        /// 排序类
        /// </summary>
        private class CompareFeeItemList : IComparer
        {
            #region IComparer 成员

            public int Compare(object x, object y)
            {
                if (x is Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList && y is Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)
                {
                    return ((Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)x).Item.MinFee.ID.CompareTo(
                        ((Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList)y).Item.MinFee.ID);
                }
                else
                {
                    return -1;
                }
            }

            #endregion
        }

        /// <summary>
        /// 设置处方号
        /// </summary>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>成功 1 失败 -1</returns>
        private int SetRecipeNO(ref ArrayList feeItemLists, System.Data.IDbTransaction trans)
        {
            this.SetDB(inpatientManager);
            inpatientManager.SetTrans(trans);

            ArrayList existRecipeNOLists = new ArrayList();

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists)
            {
                if (feeItemList.RecipeNO != null && feeItemList.RecipeNO != string.Empty)
                {
                    existRecipeNOLists.Add(feeItemList);
                }
            }

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in existRecipeNOLists)
            {
                feeItemLists.Remove(feeItemList);
            }

            ArrayList sortByMinFeeLists = this.CollectFeeItemLists(feeItemLists);

            foreach (ArrayList list in sortByMinFeeLists)
            {
                string recipeNO = string.Empty;
                int recipeSequenceNO = 1;
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList temp = list[0] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;

                //if (temp.Item.IsPharmacy)
                if (temp.Item.ItemType == EnumItemType.Drug)
                {
                    recipeNO = inpatientManager.GetDrugRecipeNO();
                }
                else
                {
                    recipeNO = inpatientManager.GetUndrugRecipeNO();
                }

                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in list)
                {
                    feeItemList.RecipeNO = recipeNO;
                    feeItemList.SequenceNO = recipeSequenceNO;

                    recipeSequenceNO++;
                }
            }

            feeItemLists = new ArrayList();

            feeItemLists.AddRange(existRecipeNOLists);

            foreach (ArrayList list in sortByMinFeeLists)
            {
                feeItemLists.AddRange(list);
            }

            return 1;
        }

        /// <summary>
        /// 按照最小费用排序
        /// </summary>
        /// <param name="feeItemLists">费用明细</param>
        /// <returns>成功 排序好的处方明细 失败 null</returns>
        private ArrayList CollectFeeItemLists(ArrayList feeItemLists)
        {
            feeItemLists.Sort(new CompareFeeItemList());

            ArrayList sorList = new ArrayList();

            while (feeItemLists.Count > 0)
            {
                ArrayList sameFeeItemLists = new ArrayList();
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList compareItem = feeItemLists[0] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in feeItemLists)
                {
                    if (f.Item.MinFee.ID == compareItem.Item.MinFee.ID)
                    {
                        if (f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID)
                        {
                            sameFeeItemLists.Add(f);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                sorList.Add(sameFeeItemLists);
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in sameFeeItemLists)
                {
                    feeItemLists.Remove(f);
                }
            }

            return sorList;
        }

        /// <summary>
        /// 把医嘱信息转换为费用信息
        /// 
        /// {F5477FAB-9832-4234-AC7F-ED49654948B4} 增加参数 传入patient信息
        /// </summary>
        /// <param name="orderList">医嘱信息</param>
        /// <returns>成功 费用信息 失败 null</returns>
        private ArrayList ConvertOrderToFeeItemList(Neusoft.HISFC.Models.RADT.PatientInfo patient,ArrayList orderList)
        {
            ArrayList feeItemLists = new ArrayList();

            foreach (Neusoft.HISFC.Models.Order.Inpatient.Order order in orderList)
            {
                Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                feeItemList.Item = order.Item.Clone();

                if (order.HerbalQty == 0)
                {
                    order.HerbalQty = 1;
                }

                //{F5477FAB-9832-4234-AC7F-ED49654948B4}
                Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();
                decimal price = feeItemList.Item.Price;
                if (pactManager.GetPrice(patient, feeItemList.Item.ItemType, feeItemList.Item.ID, ref price) == -1)
                {
                    MessageBox.Show(Language.Msg("取项目:") + feeItemList.Item.Name + Language.Msg("的价格出错!") + pactManager.Err);

                    return null;
                }
                feeItemList.Item.Price = price;

                feeItemList.Item.Qty = order.Qty * order.HerbalQty;
                //增加付数的赋值 {AE53ACB5-3684-42e8-BF28-88C2B4FF2360}
                feeItemList.Days = order.HerbalQty;

                feeItemList.Item.PriceUnit = order.Unit;//单位重新付
                feeItemList.RecipeOper.Dept = order.ReciptDept.Clone();
                feeItemList.RecipeOper.ID = order.ReciptDoctor.ID;
                feeItemList.RecipeOper.Name = order.ReciptDoctor.Name;
                feeItemList.ExecOper = order.ExecOper.Clone();
                feeItemList.StockOper.Dept = order.StockDept.Clone();
                if (feeItemList.Item.PackQty == 0)
                {
                    feeItemList.Item.PackQty = 1;
                }
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty), 2);
                feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                feeItemList.IsBaby = order.IsBaby;
                feeItemList.IsEmergency = order.IsEmergency;
                feeItemList.Order = order.Clone();
                feeItemList.ExecOrder.ID = order.User03;
                feeItemList.NoBackQty = feeItemList.Item.Qty;
                feeItemList.FTRate.OwnRate = 1;
                feeItemList.BalanceState = "0";
                feeItemList.ChargeOper = order.Oper.Clone();
                feeItemList.FeeOper = order.Oper.Clone();
                feeItemList.TransType = TransTypes.Positive;

                #region {10C9E65E-7122-4a89-A0BE-0DF62B65C647} 写入复合项目编码、名称
                feeItemList.UndrugComb.ID = order.Package.ID;
                feeItemList.UndrugComb.Name = order.Package.Name; 
                #endregion

                feeItemLists.Add(feeItemList);
            }

            return feeItemLists;
        }

        /// <summary>
        /// 设置物资扣库科室
        /// </summary>
        /// <returns></returns>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        public void GetMatLoadDataDept(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f)
        {
            //return ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            f.StockOper.Dept.ID = f.ExecOper.Dept.ID;
        }

        /// <summary>
        /// 住院批量收费
        /// </summary>
        /// <param name="patient">住院患者基本信息</param>
        /// <param name="feeItemLists">费用或医嘱信息实体</param>
        /// <param name="payType">收费类型(划价或者收费)</param>
        /// <param name="transType">正交易 反交易</param>
        /// <returns></returns>
        //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
        private int FeeManager(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeItemLists, ChargeTypes payType, TransTypes transType)
        {
          
            #region liu.xq
            this.radtIntegrate.SetTrans(this.trans);
            patient = this.radtIntegrate.GetPatientInfomation(patient.ID);

            if (patient.IsStopAcount) 
            {
                this.Err = "该患者已经封帐!不能继续录入费用或退费,请与住院处联系!";

                return -1;
            }

            //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上
            string motherPayAllFee = this.controlParamIntegrate.GetControlParam<string>(SysConst.Use_Mother_PayAllFee, false, "0");
            if (motherPayAllFee == "1")//婴儿的费用收在妈妈的身上 
            {
                if (patient.ID.IndexOf("B") > 0) //住院流水号好有B,代表是婴儿
                {
                    string motherInpatientNO = this.radtIntegrate.QueryBabyMotherInpatientNO(patient.ID);
                    if (string.IsNullOrEmpty(motherInpatientNO) || motherInpatientNO == "-1")
                    {
                        this.Err = "没有找到婴儿的母亲住院流水号" + this.radtIntegrate.Err;

                        return -1;
                    }

                    patient = this.radtIntegrate.GetPatientInfomation(motherInpatientNO);//用妈妈的基本信息替换婴儿的基本信息

                    object obj = feeItemLists[0];
                    if (obj is Neusoft.HISFC.Models.Order.Inpatient.Order)
                    {
                        feeItemLists = this.ConvertOrderToFeeItemList(patient, feeItemLists);
                        for (int i = 0; i < feeItemLists.Count; i++)
                        {
                            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = feeItemLists[i] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                            feeItemList.IsBaby = true;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < feeItemLists.Count; i++)
                        {
                            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = feeItemLists[i] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList;
                            feeItemList.IsBaby = true;
                        }
                    }
                }
                else 
                {
                    object obj = feeItemLists[0];
                    if (obj is Neusoft.HISFC.Models.Order.Inpatient.Order)
                    {
                        feeItemLists = this.ConvertOrderToFeeItemList(patient, feeItemLists);
                    }
                }
            }
            else 
            {
                object obj = feeItemLists[0];
                if (obj is Neusoft.HISFC.Models.Order.Inpatient.Order)
                {
                    feeItemLists = this.ConvertOrderToFeeItemList(patient, feeItemLists);
                }
            }
            ////{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F}完毕

            #endregion
           

            this.SetDB(inpatientManager);

            if (feeItemLists == null || feeItemLists.Count == 0)
            {
                return -1;
            }

              //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E}增加医疗组处理

            List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct> medicalTeamForDoctList = new List<Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct>();
           
            medicalTeamForDoctList = this.medicalTeamForDoctBizLogic.QueryQueryMedicalTeamForDoctInfo();

            Hashtable hsMedicalTeam = new Hashtable();

            //添加哈希表
            foreach (Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct item in medicalTeamForDoctList)
            {
                string strAdd = item.MedcicalTeam.Dept.ID + "|" + item.Doct.ID;
                if (hsMedicalTeam.Contains(strAdd))
                {
                    continue;
                }

                hsMedicalTeam.Add(strAdd, item);
            }

            


            //取集合的第一个元素判断是费用明细(FeeItemList还是Order)

            long returnValue = 0;
            this.MedcareInterfaceProxy.SetPactTrans(this.trans);
            //如果费用接口没有初始化,那么根据患者的合同单位初始化费用接口
            if (medcareInterfaceProxy != null)
            {
                returnValue = MedcareInterfaceProxy.SetPactCode(patient.Pact.ID);

                MedcareInterfaceProxy.SetTrans(this.trans);

                if (returnValue == -1 && this.isIgnoreMedcareInterface == false)
                {
                    this.Err = MedcareInterfaceProxy.ErrMsg;

                    return -1;
                }
                returnValue = MedcareInterfaceProxy.Connect();

                if (returnValue == -1)
                {
                    this.Err = MedcareInterfaceProxy.ErrMsg;

                    return -1;
                }
            }

            //判断有效性
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists)
            {
                //有效性判断
                if (!this.IsValidFee(patient, feeItemList))
                {
                    return -1;
                }
                // //{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E}增加医疗组处理
                if (string.IsNullOrEmpty(feeItemList.MedicalTeam.ID))
                {
                    string patientDept = ((Neusoft.HISFC.Models.RADT.PatientInfo)feeItemList.Patient).PVisit.PatientLocation.Dept.ID;
                    //患者所在科室
                    //string patientDept = feeItemList.RecipeOper.Dept.ID;

                    if (hsMedicalTeam.Contains(patientDept + "|" + feeItemList.RecipeOper.ID))
                    {
                        Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct obj = hsMedicalTeam[patientDept + "|" + feeItemList.RecipeOper.ID] as Neusoft.HISFC.Models.Order.Inpatient.MedicalTeamForDoct;
                        feeItemList.MedicalTeam = obj.MedcicalTeam;
                    }
                }
            }

            ////如果费用接口没有初始化,那么根据患者的合同单位初始化费用接口
            //if (medcareInterfaceProxy != null)
            //{
            //    medcareInterfaceProxy.SetTrans(this.trans);

            //    returnValue = medcareInterfaceProxy.SetPactCode(patient.Pact.ID);

            //    if (returnValue == -1 && this.isIgnoreMedcareInterface == false)
            //    {
            //        this.Err = medcareInterfaceProxy.ErrMsg;

            //        return -1;
            //    }
            //    returnValue = medcareInterfaceProxy.Connect();

            //    if (returnValue == -1)
            //    {
            //        this.Err = medcareInterfaceProxy.ErrMsg;

            //        return -1;
            //    }

            //}

            //执行费用接口,对比例等进行计算后重新赋值
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists)
            {
                returnValue = MedcareInterfaceProxy.RecomputeFeeItemListInpatient(patient, feeItemList);

                if (returnValue == -1 && this.isIgnoreMedcareInterface == false)
                {
                    this.Err = MedcareInterfaceProxy.ErrMsg;

                    return -1;
                }

                //为防止最后余额不符，统一转换为2位。
                feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.TotCost, 2);
                feeItemList.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.OwnCost, 2);
                feeItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.PayCost, 2);
                feeItemList.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.PubCost, 2);

                //防止空调床位拆分后记录为0
                if (feeItemList.FT.TotCost == 0)
                {
                    return 1;
                }
            }

            //重新分配处方号
            this.SetRecipeNO(ref feeItemLists, this.trans);

            #region 物资收费处理
            //{CEA4E2A5-A045-4823-A606-FC5E515D824D}
            if (transType == TransTypes.Positive)
            {
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList f in feeItemLists)
                {
                    //物资的扣库科室是登录科室（与加载的列表是相同的科室）
                    if (f.Item.ItemType != EnumItemType.Drug)
                    {
                        GetMatLoadDataDept(f);
                    }    
                }
                //物资收费处理
                if (materialManager.MaterialFeeOutput(feeItemLists) < 0)
                {
                    this.Err = materialManager.Err;
                    return -1;
                }
            }
            else
            {

                //退库
                if (materialManager.MaterialFeeOutputBack(feeItemLists) < 0)
                {
                    this.Err = materialManager.Err;
                    return -1;
                }
            }
            #endregion
            //对明细循环处理
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists)
            {
                //如果是收费操作,那么进行正交易和反交易的特殊赋值
                if (payType == ChargeTypes.Fee)
                {
                    //如果是反交易,需要判断更新可退数量和把金额,数量进行负数处理
                    if (transType == TransTypes.Negative)
                    {
                        //更新可退数量 然后取得新的处方号,药品和非药品分别更新(表不同)
                        //if (feeItemList.Item.IsPharmacy)
                        if (feeItemList.Item.ItemType == EnumItemType.Drug)
                        {
                            //如果明细需要更新可退数量,那么进行更新,如果数据来源于退费申请,前台的IsNeedUpdateNoBackQty为False
                            //说明已经更新过可退数量,这里就不用进行更新了
                            if (feeItemList.IsNeedUpdateNoBackQty)
                            {
                                if (inpatientManager.UpdateNoBackQtyForDrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState) < 1)
                                {
                                    this.Err = Language.Msg("更新原有记录可退数量出错!") + feeItemList.Item.Name + Language.Msg("费用已经被退费或结算!") + inpatientManager.Err;

                                    return -1;
                                }
                            }

                            //获得新的处方号
                            feeItemList.RecipeNO = inpatientManager.GetDrugRecipeNO();
                        }
                        else
                        {
                            if (feeItemList.IsNeedUpdateNoBackQty)
                            {
                                if (inpatientManager.UpdateNoBackQtyForUndrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState) < 1)
                                {
                                    this.Err = Language.Msg("更新原有记录可退数量出错!") + feeItemList.Item.Name + Language.Msg("费用已经被退费或结算!") + inpatientManager.Err;

                                    return -1;
                                }
                            }

                            //获得新的处方号
                            feeItemList.RecipeNO = inpatientManager.GetUndrugRecipeNO();
                        }
                        //形成负记录
                        feeItemList.Item.Qty = -feeItemList.Item.Qty;
                        feeItemList.FT.TotCost = -feeItemList.FT.TotCost;
                        feeItemList.FT.OwnCost = -feeItemList.FT.OwnCost;
                        feeItemList.FT.PayCost = -feeItemList.FT.PayCost;
                        feeItemList.FT.PubCost = -feeItemList.FT.PubCost;
                        feeItemList.FT.RebateCost = -feeItemList.FT.RebateCost;
                        feeItemList.TransType = TransTypes.Negative;
                        feeItemList.FeeOper.ID = inpatientManager.Operator.ID;
                        feeItemList.FeeOper.OperTime = inpatientManager.GetDateTimeFromSysDateTime();
                        if (feeItemList.BalanceState == null || feeItemList.BalanceState == string.Empty)
                        {
                            feeItemList.BalanceState = "0";
                        }
                    }

                    //保持划价时间跟收费时间同步
                    feeItemList.ChargeOper.OperTime = feeItemList.FeeOper.OperTime;
                    feeItemList.Patient.Pact.ID = patient.Pact.ID;
                    feeItemList.Patient.Pact.PayKind.ID = patient.Pact.PayKind.ID;
                    //结算序号在对于收费应为0 而直接收费应该为当前患者的结算序号+1
                    //feeItemList.BalanceNO = patient.BalanceNO;
                    feeItemList.FeeOper.ID = inpatientManager.Operator.ID;
                    if (feeItemList.FTRate.ItemRate == 0)
                    {
                        feeItemList.FTRate.ItemRate = 1;
                    }
                }

                //给明细记录的收费划价标志赋值
                if (payType == ChargeTypes.Fee)
                {
                    feeItemList.PayType = PayTypes.Balanced;
                }
                else
                {
                    feeItemList.PayType = PayTypes.Charged;
                }

                //插入处方明细表,分别为药品,非药品
                //if (feeItemList.Item.IsPharmacy)
                if (feeItemList.Item.ItemType == EnumItemType.Drug)
                {
                    if (inpatientManager.InsertMedItemList(patient, feeItemList) == -1)
                    {
                        this.Err = Language.Msg("插入药品明细出错!") + inpatientManager.Err;

                        return -1;
                    }
                }
                else
                {
                    if (inpatientManager.InsertFeeItemList(patient, feeItemList) == -1)
                    {
                        this.Err = Language.Msg("插入非药品明细出错!") + inpatientManager.Err;

                        return -1;
                    }
                }

                //特殊更新费用明细,如果有需要特殊更新的标志,这里更新(属于费用接口操作)
                if (MedcareInterfaceProxy != null)
                {
                    if (MedcareInterfaceProxy.UpdateFeeItemListInpatient(patient, feeItemList) == -1)
                    {
                        this.Err = MedcareInterfaceProxy.ErrMsg;

                        return -1;
                    }
                }
            }
            ///费用待遇接口处理


            //由于划价和收费流程,以上代码均通用,下面为收费与划价不同的流程,收费需要按照最小费用(MinFee.ID)汇总,插入费用汇总表
            //并更新住院主表
            if (payType == ChargeTypes.Fee)
            {
                //decimal freeCost = patient.FT.LeftCost;//余额
                //decimal moneyAlert = patient.PVisit.MoneyAlert;//警戒线
                //decimal totCost = 0m;//费用金额
                //decimal surtyCost = 0m;//担保金额
                //if (this.MessageType != MessType.N)
                //{
                //    //查找担保金额
                //    string resultValue = inpatientManager.GetSurtyCost(patient.ID);
                //    if (resultValue == "-1")
                //    {
                //        this.Err = "查找担保金额失败！";
                //        return -1;
                //    }
                //    surtyCost = NConvert.ToDecimal(resultValue);
                //}
                //上传接口明细

                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList in feeItemLists)
                {
                    if (feeItemList.FT.TotCost < 0)
                    {

                        returnValue = this.MedcareInterfaceProxy.DeleteUploadedFeeDetailInpatient(patient, feeItemList);
                        if (returnValue != 1)
                        {
                            this.Err = "待遇接口上传退费明细失败" + this.MedcareInterfaceProxy.ErrMsg;
                            return -1;

                        }

                    }
                    else
                    {
                        returnValue = this.MedcareInterfaceProxy.UploadFeeDetailInpatient(patient, feeItemList);
                        if (returnValue != 1)
                        {
                            this.Err = "待遇接口上传明细失败" + this.MedcareInterfaceProxy.ErrMsg;
                            return -1;

                        }

                    }
                }


                //获得按照MinFee.ID分组后的数据集合

                ArrayList sorList = this.CollectFeeItemLists(feeItemLists);

                int iReturn = 0;
                //创建一个费用
                FT ftMain = new FT();

                foreach (ArrayList list in sorList)
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList temp = (list[0] as Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList).Clone();
                    temp.FT = new FT();

                    feeItemLists.AddRange(list);

                    foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemTot in list)
                    {
                        temp.FT.TotCost += feeItemTot.FT.TotCost;
                        temp.FT.OwnCost += feeItemTot.FT.OwnCost;
                        temp.FT.PayCost += feeItemTot.FT.PayCost;
                        temp.FT.PubCost += feeItemTot.FT.PubCost;

                        ftMain.TotCost += feeItemTot.FT.TotCost;
                        ftMain.OwnCost += feeItemTot.FT.OwnCost;
                        ftMain.PayCost += feeItemTot.FT.PayCost;
                        ftMain.PubCost += feeItemTot.FT.PubCost;
                    }

                    iReturn = inpatientManager.InsertAndUpdateFeeInfo(patient, temp);

                    if (iReturn <= 0)
                    {
                        this.Err = Language.Msg("插入费用汇总信息出错!");

                        return -1;
                    }


                }
                //上传明细
                //returnValue = this.MedcareInterfaceProxy.GetRegInfoInpatient(patient);

                returnValue = MedcareInterfaceProxy.PreBalanceInpatient(patient, ref feeItemLists);
                if (returnValue != 1)
                {
                    this.Err = "待遇接口预结算失败" + this.MedcareInterfaceProxy.ErrMsg;
                    return -1;

                }

                //if (patient.SIMainInfo.OwnCost + patient.SIMainInfo.PayCost + patient.SIMainInfo.PubCost > 0)
                //{
                //    ftMain.OwnCost = patient.SIMainInfo.OwnCost;
                //    ftMain.PubCost = patient.SIMainInfo.PubCost;
                //    ftMain.PayCost = patient.SIMainInfo.PayCost;
                //    ftMain.TotCost = patient.SIMainInfo.PayCost + patient.SIMainInfo.OwnCost + patient.SIMainInfo.PubCost;
                //}
                if (patient.Pact.PayKind.ID == "02" || patient.Pact.PayKind.ID == "03")
                {
                    ftMain.OwnCost = patient.SIMainInfo.OwnCost;
                    ftMain.PubCost = patient.SIMainInfo.PubCost;
                    ftMain.PayCost = patient.SIMainInfo.PayCost;
                    ftMain.TotCost = patient.SIMainInfo.PayCost + patient.SIMainInfo.OwnCost + patient.SIMainInfo.PubCost;
                }

                #region 欠费设置信息进行判断
                //判断欠费 条件：余额+担保金额-当前费用金额<警戒线 2007-08-23 路志鹏
                if (transType == TransTypes.Positive)
                {
                    IFeeOweMessage feeOweMessage = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IFeeOweMessage)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IFeeOweMessage;
                    if (feeOweMessage == null)
                    {
                        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
                        #region 按照金额判断
                        //{56F3CD2F-64A3-4bbe-9ECE-BBF5F6944412}
                        decimal freeCost = 0;
                        //{639C0ACE-3505-4dc5-97FB-87322CE3CC8E}
                        //if (patient.Pact.PayKind.ID == "02" || patient.Pact.PayKind.ID == "03")
                        //{
                        //    freeCost = patient.FT.PrepayCost;//预交金
                        //}
                        //else
                        //{
                        //    freeCost = patient.FT.LeftCost;//余额
                        //}
                        freeCost = patient.FT.LeftCost;//余额
                        decimal moneyAlert = patient.PVisit.MoneyAlert;//警戒线
                        decimal totCost = 0m;//费用金额
                        decimal surtyCost = 0m;//担保金额
                        if (this.MessageType != MessType.N)
                        {
                            //查找担保金额
                            string resultValue = inpatientManager.GetSurtyCost(patient.ID);
                            if (resultValue == "-1")
                            {
                                this.Err = "查找担保金额失败！";
                                return -1;
                            }
                            surtyCost = NConvert.ToDecimal(resultValue);
                        }

                        totCost = ftMain.OwnCost;
                        decimal MessCost = freeCost + surtyCost - totCost - moneyAlert;
                        //按照时间段判断的时间范围
                        DateTime beginDate = NConvert.ToDateTime(patient.PVisit.BeginDate.ToString("yyyy-MM-dd") + " 00:00:00");
                        DateTime endDate = NConvert.ToDateTime(patient.PVisit.EndDate.ToString("yyyy-MM-dd") + " 23:59:59");
                        DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
                        //欠费判断类型
                        string alertType = patient.PVisit.AlertType.ID.ToString();
                        //是否欠费
                        bool isOwn = false;
                        //{6005F670-C1C6-43f6-BDD3-D5E37A628438} 20101120 欠费判断
                        if (patient.Pact.ID == "01")
                        {
                             isOwn = freeCost + surtyCost - totCost < moneyAlert;
                        }
                        else {
                             isOwn = freeCost + surtyCost - (totCost- patient.FT.TotCost) < moneyAlert;
                        }
                        bool isValid = true;

                        //按照时间段判断如果在时间范围内则不判断欠费
                        if (alertType == EnumAlertType.D.ToString())
                        {
                            if (now >= beginDate && now <= endDate)
                            {
                                isValid = false;
                            }
                        }

                        if (isOwn && isValid)
                        {
                            if (MessageType == MessType.Y)
                            {
                                //{6C42FDE7-B167-429e-B89E-37E5845F8946} 20101126 xizf
                                if (patient.Pact.ID == "01")
                                {
                                    this.Err = "患者姓名: " + patient.Name + "\n\n警 戒 线:" + moneyAlert.ToString() + "\n\n预 交 金:" + patient.FT.PrepayCost.ToString() + "\n\n费用总额:" + patient.FT.TotCost.ToString() + "\n\n自费总额:" + patient.FT.OwnCost.ToString() + "\n\n余  额:" + freeCost.ToString() + "\n\n本次费用:" + totCost.ToString() + " \n\n余额不足，不能进行收费！" + "\n\n" + "请补交" + (-MessCost).ToString() + "元";
                                    return -1;
                                }
                                else {
                                    this.Err = "患者姓名: " + patient.Name + "\n\n警 戒 线:" + moneyAlert.ToString() + "\n\n预 交 金:" + patient.FT.PrepayCost.ToString() + "\n\n费用总额:" + patient.FT.TotCost.ToString() + "\n\n自费总额:" + patient.FT.OwnCost.ToString() + "\n\n余  额:" + freeCost.ToString() + "\n\n本次费用:" + (totCost - patient.FT.TotCost).ToString() + " \n\n余额不足，不能进行收费！" + "\n\n" + "请补交" + (-MessCost).ToString() + "元";
                                    return -1;
                                }
                                
                            }
                            if (MessageType == MessType.M)//{639C0ACE-3505-4dc5-97FB-87322CE3CC8E}
                            {
                                #region {403682AB-DF9E-4009-84EC-21CE355E3FA5} 医保患者本次费用显示错误 by guanyx
                                if (patient.Pact.ID == "01")
                                {
                                    if (MessageBox.Show("患者姓名: " + patient.Name + "\n\n警 戒 线:" + moneyAlert.ToString() + "\n\n预 交 金:" + patient.FT.PrepayCost.ToString() + "\n\n费用总额:" + patient.FT.TotCost.ToString() + "\n\n自费总额:" + patient.FT.OwnCost.ToString() + "\n\n余    额:" + freeCost.ToString() + "\n\n本次费用:" + totCost.ToString()
                                        + "\n\n该患者余额不足,是否继续收费？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        this.Err = "已取消收费！";
                                        return -1;
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("患者姓名: " + patient.Name + "\n\n警 戒 线:" + moneyAlert.ToString() + "\n\n预 交 金:" + patient.FT.PrepayCost.ToString() + "\n\n费用总额:" + patient.FT.TotCost.ToString() + "\n\n自费总额:" + patient.FT.OwnCost.ToString() + "\n\n余    额:" + freeCost.ToString() + "\n\n本次费用:" + (totCost - patient.FT.TotCost).ToString()
                                        + "\n\n该患者余额不足,是否继续收费？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        this.Err = "已取消收费！";
                                        return -1;
                                    }
                                }
                               
                                #endregion

                                Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFrmValidUserPassWord isShowForm  = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFrmValidUserPassWord)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFrmValidUserPassWord;

                                if (isShowForm != null)
                                {
                                    string tempErr = string.Empty;
                                    bool isShow = isShowForm.ShowFrmValidUserPassWord(ref tempErr);
                                    if (!isShow)
                                    {
                                        this.Err = "已取消收费！" + tempErr;
                                        return -1;
                                    }

                                    
                                }
                            }
                            freeCost -= totCost;
                        }
                        #endregion
                       

                    }
                    else
                    {
                        string err = string.Empty;
                        //{2518013C-40B2-4693-B494-3DE193C002FF} //接口变化
                        bool bl = feeOweMessage.FeeOweMessage(patient, ftMain,feeItemLists,ref messType, ref err);
                        if (!bl)
                        {
                            //{492188AA-397C-4d8d-BABC-E0ECD25FD8F1} 界面提示
                            //MessageBox.Show(err);
                            this.Err = err;
                            return -1;
                        }
                        else
                        {
                            if (messType == MessType.Y)
                            {
                                this.Err = err;
                                return -1;
                            }
                            if (messType == MessType.M)
                            {
                                if (MessageBox.Show(err, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    this.Err = "已取消收费！";
                                    return -1;
                                }
                            }
                        }
                    }
                }
                #endregion

                //如果忽略在院状态,比如直接收费患者,那么在更新住院主表的时候不判断在院状态是否为'O'
                if (this.isIgnoreInstate)
                {
                    iReturn = inpatientManager.UpdateInMainInfoFeeForDirQuit(patient.ID, ftMain);
                }
                else
                {
                    if (patient.Pact.PayKind.ID == "02" || patient.Pact.PayKind.ID == "03") //医保单独处理
                    {
                        iReturn = inpatientManager.UpdateInMainInfoFeeYB(patient.ID, ftMain);
                    }
                    else
                    {
                        iReturn = inpatientManager.UpdateInMainInfoFee(patient.ID, ftMain);
                    }
                }

                if (iReturn == -1)
                {
                    this.Err = Language.Msg("更新住院主表失败!") + inpatientManager.Err;

                    return -1;
                }

                //如果返回为0 说明不符合in_state <> 0条件，让前台不可以再录入费用.
                if (iReturn == 0)
                {
                    this.Err = patient.Name + Language.Msg("已经结算或者处于封账状态，不能继续录入费用!请与住院处联系!");

                    return -1;
                }
            }

            return 1;

        }

        /// <summary>
        /// 收费函数
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemList">费用明细实体</param>
        /// <param name="payType">划价 收费标志</param>
        /// <param name="transType">收费正交易 反交易标志</param>
        /// <returns>成功 1 失败 -1</returns>
        private int FeeManager(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList,
            ChargeTypes payType, TransTypes transType)
        {
            ArrayList temp = new ArrayList();

            temp.Add(feeItemList);

            return this.FeeManager(patient, ref temp, payType, transType);
            //long returnValue = 0;

            //this.SetDB(inpatientManager);

            ////有效性判断
            //if (!this.IsValidFee(patient, feeItemList))
            //{
            //    return -1;
            //}

            ////如果项目的比例没有赋值,那么默认为1
            //if (feeItemList.FTRate.ItemRate == 0)
            //{
            //    feeItemList.FTRate.ItemRate = 1;
            //}

            //if (medcareInterfaceProxy != null)
            //{
            //    returnValue = medcareInterfaceProxy.SetPactCode(patient.Pact.ID);

            //    if (returnValue == -1 && this.isIgnoreMedcareInterface == false)
            //    {
            //        this.Err = medcareInterfaceProxy.ErrMsg;

            //        return -1;
            //    }

            //    returnValue = medcareInterfaceProxy.RecomputeFeeItemListInpatient(patient, feeItemList);

            //    if (returnValue == -1 && this.isIgnoreMedcareInterface == false)
            //    {
            //        this.Err = medcareInterfaceProxy.ErrMsg;

            //        return -1;
            //    }
            //}

            ////为防止最后余额不符，统一转换为2位。
            //feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.TotCost, 2);
            //feeItemList.FT.OwnCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.OwnCost, 2);
            //feeItemList.FT.PayCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.PayCost, 2);
            //feeItemList.FT.PubCost = Neusoft.FrameWork.Public.String.FormatNumber(feeItemList.FT.PubCost, 2);

            ////防止空调床位拆分后记录为0
            //if (feeItemList.FT.TotCost == 0)
            //{
            //    return 1;
            //}

            ////如果是收费的话,处理费用明细的退费操作
            //if (payType == ChargeTypes.Fee)
            //{
            //    //如果是负交易
            //    if (transType == TransTypes.Negative)
            //    {

            //        //更新可退数量 然后取得新的处方号
            //        if (feeItemList.Item.IsPharmacy)
            //        {
            //            if (feeItemList.IsNeedUpdateNoBackQty)
            //            {
            //                if (inpatientManager.UpdateNoBackQtyForDrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState) < 1)
            //                {
            //                    this.Err = Language.Msg("更新原有记录可退数量出错!") + feeItemList.Item.Name + Language.Msg("费用已经被退费或结算!") + inpatientManager.Err;

            //                    return -1;
            //                }
            //            }

            //            //获得新的处方号
            //            feeItemList.RecipeNO = inpatientManager.GetDrugRecipeNO();
            //        }
            //        else
            //        {
            //            if (feeItemList.IsNeedUpdateNoBackQty)
            //            {
            //                if (inpatientManager.UpdateNoBackQtyForUndrug(feeItemList.RecipeNO, feeItemList.SequenceNO, feeItemList.Item.Qty, feeItemList.BalanceState) < 1)
            //                {
            //                    this.Err = Language.Msg("更新原有记录可退数量出错!") + feeItemList.Item.Name + Language.Msg("费用已经被退费或结算!") + inpatientManager.Err;

            //                    return -1;
            //                }
            //            }

            //            //获得新的处方号
            //            feeItemList.RecipeNO = inpatientManager.GetUndrugRecipeNO();
            //        }
            //        //形成负记录
            //        feeItemList.Item.Qty = -feeItemList.Item.Qty;
            //        feeItemList.FT.TotCost = -feeItemList.FT.TotCost;
            //        feeItemList.FT.OwnCost = -feeItemList.FT.OwnCost;
            //        feeItemList.FT.PayCost = -feeItemList.FT.PayCost;
            //        feeItemList.FT.PubCost = -feeItemList.FT.PubCost;
            //        feeItemList.FT.RebateCost = -feeItemList.FT.RebateCost;
            //        feeItemList.TransType = TransTypes.Negative;
            //        feeItemList.FeeOper.ID = inpatientManager.Operator.ID;
            //        feeItemList.FeeOper.OperTime = inpatientManager.GetDateTimeFromSysDateTime();

            //        if (feeItemList.BalanceState == null || feeItemList.BalanceState == string.Empty)
            //        {
            //            feeItemList.BalanceState = "0";
            //        }
            //    }
            //    //保持划价时间跟收费时间同步
            //    feeItemList.ChargeOper.OperTime = feeItemList.FeeOper.OperTime;
            //    feeItemList.Patient.Pact.ID = patient.Pact.ID;
            //    feeItemList.Patient.Pact.PayKind.ID = patient.Pact.PayKind.ID;
            //}

            //if (feeItemList.Item.IsPharmacy)
            //{
            //    if (inpatientManager.InsertMedItemList(patient, feeItemList) == -1)
            //    {
            //        this.Err = Language.Msg("插入药品明细出错!") + inpatientManager.Err;

            //        return -1;
            //    }
            //}
            //else
            //{
            //    if (inpatientManager.InsertFeeItemList(patient, feeItemList) == -1)
            //    {
            //        this.Err = Language.Msg("插入非药品明细出错!") + inpatientManager.Err;

            //        return -1;
            //    }
            //}

            //if (payType == ChargeTypes.Fee)
            //{
            //    int iReturn = inpatientManager.InsertAndUpdateFeeInfo(patient, feeItemList);

            //    if (iReturn <= 0)
            //    {
            //        this.Err = Language.Msg("插入费用汇总信息出错!");

            //        return -1;
            //    }

            //    iReturn = inpatientManager.UpdateInMainInfoFee(patient.ID, feeItemList.FT);

            //    if (iReturn == -1)
            //    {
            //        this.Err = Language.Msg("更新住院主表失败!") + inpatientManager.Err;

            //        return -1;
            //    }

            //    //如果返回为0 说明不符合in_state <> 0条件，让前台不可以再录入费用.
            //    if (iReturn == 0)
            //    {
            //        this.Err = patient.Name + Language.Msg("已经结算或者出于封账状态，不能继续录入费用!请与住院处联系!");

            //        return -1;
            //    }
            //}

            ////特殊更新费用明细
            //if (medcareInterfaceProxy != null)
            //{
            //    if (medcareInterfaceProxy.UpdateFeeItemListInpatient(patient, feeItemList) == -1)
            //    {
            //        this.Err = medcareInterfaceProxy.ErrMsg;

            //        return -1;
            //    }
            //}

            //return 1;
        }

        #endregion

        #region 公有方法

        public string GetUndrugCode()
        {
            this.SetDB(itemManager);
            return itemManager.GetUndrugCode();
        }

        #region 住院
        /// <summary>
        /// 获得有效的,项目类别为手术的项目数组
        /// </summary>
        /// <returns>成功:项目数组 失败返回null</returns>
        public ArrayList QueryOperationItems()
        {
            this.SetDB(itemManager);

            return itemManager.QueryOperationItems();
        }
        /// <summary>
        /// 获得非药品信息
        /// </summary>
        /// <param name="undrugCode"></param>
        /// <returns>成功 非药品信息 失败 null</returns>
        public Neusoft.HISFC.Models.Fee.Item.Undrug GetUndrugByCode(string undrugCode)
        {
            this.SetDB(itemManager);

            return itemManager.GetUndrugByCode(undrugCode);
        }
        /// <summary>
        /// 通过处方号，得到费用明细
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <returns>null 错误 ArrayList Fee.OutPatient.FeeItemList实体集合</returns>
        public ArrayList QueryFeeDetailFromRecipeNO(string recipeNO)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.QueryFeeDetailFromRecipeNO(recipeNO);
        }

        /// <summary>
        /// 获得门诊卡号流水,默认为9位字长,前面补0
        /// </summary>
        /// <returns>成功 门诊卡号 失败 null</returns>
        public string GetAutoCardNO()
        {
            this.SetDB(outpatientManager);

            return outpatientManager.GetAutoCardNO();
        }

        /// <summary>
        /// 根据处方号和处方项目流水号更新院注已确认数量
        /// </summary>
        /// <param name="moOrder">医嘱流水号</param>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSquence">处方内流水号</param>
        /// <param name="qty">院注次数</param>
        /// <returns>成功: >= 1 失败: -1 没有更新到数据返回 0</returns>
        public int UpdateConfirmInject(string moOrder, string recipeNO, string recipeSquence, int qty)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.UpdateConfirmInject(moOrder, recipeNO, recipeSquence, qty);
        }

        /// <summary>
        /// 判断患者是否欠费
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>true 欠费 false 不欠费</returns>
        public bool IsPatientLackFee(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            #region 查询医嘱欠费判断加入按天数设置的功能 {EE219CB3-16EB-4cbd-ACDF-233F3585E355} wbo 2010-12-25
            //if (patient.FT.LeftCost > patient.PVisit.MoneyAlert)
            //{
            //    return false;
            //}
            //按照时间段判断的时间范围
            DateTime beginDate = NConvert.ToDateTime(patient.PVisit.BeginDate.ToString("yyyy-MM-dd") + " 00:00:00");
            DateTime endDate = NConvert.ToDateTime(patient.PVisit.EndDate.ToString("yyyy-MM-dd") + " 23:59:59");
            DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
            //欠费判断类型
            string alertType = patient.PVisit.AlertType.ID.ToString();
            //按照时间段判断如果在时间范围内则不判断欠费
            if (alertType == EnumAlertType.D.ToString())
            {
                if (now >= beginDate && now <= endDate)
                {
                    return false;
                }
            }
            else
            {
                if (patient.FT.LeftCost > patient.PVisit.MoneyAlert)
                {
                    return false;
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 查询所有合同单位
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryPactUnitAll()
        {
            this.SetDB(pactManager);

            return pactManager.QueryPactUnitAll();
        }
        /// <summary>
        /// 提交函数
        /// </summary>
        /// 按着HIS4.5.0.1的commit方式修改
        public void Commit()
        {
            //this.trans.Commit();
            //if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null)
            //{
            //    medcareInterfaceProxy.Commit();
            //}
            if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null && medcareInterfaceProxy.PactCode != "" && medcareInterfaceProxy.PactCode != null)
            {
                if (medcareInterfaceProxy.Commit() < 0) //沈阳医保 0成功 -1失败
                {
                    medcareInterfaceProxy.Rollback();
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    //this.trans.Rollback();
                }
                else
                {
                    //this.trans.Commit();
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    //{A6CDF67A-DEBE-4ce6-AC8B-CC0CAB9B1B0E}
                    medcareInterfaceProxy.Disconnect();
                }
            }
            else if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null && medcareInterfaceProxy.PactCode == "")
            {
                //this.trans.Commit()
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            else
            {
                //this.trans.Commit();
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
        }
        /// <summary>
        /// 提交公费接口函数
        /// </summary>
        /// 这里单独给药房退费退药时使用了，其他地方如果需要也可以使用
        public int MedcareInterfaceCommit()
        {

            if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null && medcareInterfaceProxy.PactCode != "" && medcareInterfaceProxy.PactCode != null)
            {
                if (medcareInterfaceProxy.Commit() < 0) //沈阳医保 0成功 -1失败
                {
                    medcareInterfaceProxy.Rollback();
                    return -1;
                }
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// 回滚公费接口函数
        /// </summary>
        public void MedcareInterfaceRollback()
        {
            if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null)
            {
                medcareInterfaceProxy.Rollback();
            }
        }
        /// <summary>
        /// 回滚函数
        /// </summary>
        public void Rollback()
        {
            //this.trans.Rollback();
            Neusoft.FrameWork.Management.PublicTrans.RollBack();
            if (!this.isIgnoreMedcareInterface && medcareInterfaceProxy != null)
            {
                medcareInterfaceProxy.Rollback();
            }
        }
        /* {4E6415B8-8BFE-4fe5-8AC2-66DBCC887F71}
        /// <summary>
        /// 获得发票号
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <returns>成功: 发票号 失败: null</returns>
        public string GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType invoiceType)
        {
            int leftQty = 0;//发票剩余数目
            int alarmQty = 0;//发票预警数目
            string finGroupID = string.Empty;//发票组代码
            string newInvoiceNO = string.Empty;//获得的发票号

            alarmQty = Neusoft.FrameWork.Function.NConvert.ToInt32(controlManager.QueryControlerInfo("100002"));

            finGroupID = inpatientManager.GetFinGroupInfoByOperCode(inpatientManager.Operator.ID).ID;

            if (finGroupID == null || finGroupID == string.Empty)
            {
                finGroupID = " ";
            }

            Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeState = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

            if (this.trans != null)
            {
                feeCodeState.SetTrans(this.trans);
            }

            newInvoiceNO = inpatientManager.GetNewInvoiceNO(feeCodeState.Operator.ID, invoiceType, alarmQty, ref leftQty, finGroupID);

            if (newInvoiceNO == null || newInvoiceNO == string.Empty)
            {
                this.SetDB(inpatientManager);

                return null;
            }

            if (leftQty < alarmQty)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("剩余发票") + leftQty.ToString() + Language.Msg("张,请补领发票!"));
            }

            return newInvoiceNO;
        }
        */
        /// <summary>
        /// 门诊取发票
        /// </summary>
        /// <param name="invoiceType">发票类型R:挂号收据 C:门诊收据 P:预交收据 I:住院收据 A:门诊账户</param>
        /// <returns></returns>
        public string GetNewInvoiceNO(string invoiceType)
        {
            int leftQty = 0;//发票剩余数目
            int alarmQty = 0;//发票预警数目
            string finGroupID = string.Empty;//发票组代码
            string newInvoiceNO = string.Empty;//获得的发票号

            alarmQty = Neusoft.FrameWork.Function.NConvert.ToInt32(controlManager.QueryControlerInfo("100002"));

            finGroupID = inpatientManager.GetFinGroupInfoByOperCode(inpatientManager.Operator.ID).ID;

            if (finGroupID == null || finGroupID == string.Empty)
            {
                finGroupID = " ";
            }

            Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeState = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

            if (this.trans != null)
            {
                feeCodeState.SetTrans(this.trans);
            }

            newInvoiceNO = inpatientManager.GetNewInvoiceNO(feeCodeState.Operator.ID, invoiceType, alarmQty, ref leftQty, finGroupID);

            if (newInvoiceNO == null || newInvoiceNO == string.Empty)
            {
                this.SetDB(inpatientManager);

                return null;
            }

            if (leftQty < alarmQty)
            {
                System.Windows.Forms.MessageBox.Show(Language.Msg("剩余发票") + leftQty.ToString() + Language.Msg("张,请补领发票!"));
            }

            return newInvoiceNO;
        }

        /// <summary>
        /// 项目收费
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemList">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int FeeItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            return this.FeeManager(patient, feeItemList, ChargeTypes.Fee, TransTypes.Positive);
        }

        /// <summary>
        /// 项目收费
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int FeeItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeItemLists)
        {
            return this.FeeManager(patient, ref feeItemLists, ChargeTypes.Fee, TransTypes.Positive);
        }

        /// <summary>
        /// 项目退费
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemList">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int QuitItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            return this.FeeManager(patient, feeItemList, ChargeTypes.Fee, TransTypes.Negative);
        }

        /// <summary>
        /// 项目退费
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int QuitItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeItemLists)
        {
            return this.FeeManager(patient, ref feeItemLists, ChargeTypes.Fee, TransTypes.Negative);
        }

        /// <summary>
        /// 项目划价
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemList">费用明细</param>
        /// <returns>成功 1 失败 -1</returns>
        public int ChargeItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {
            return this.FeeManager(patient, feeItemList, ChargeTypes.Charge, TransTypes.Positive);
        }

        /// <summary>
        /// 项目划价
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <param name="feeItemLists">费用明细集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int ChargeItem(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref ArrayList feeItemLists)
        {
            return this.FeeManager(patient, ref feeItemLists, ChargeTypes.Charge, TransTypes.Positive);
        }

        /// <summary>
        /// 循环插入结算明细
        /// </summary>
        /// <param name="patient">住院患者基本信息</param>
        /// <param name="balanceLists">结算明细集合</param>
        /// <returns>成功 1 失败 -1</returns>
        public int InsertBalanceList(Neusoft.HISFC.Models.RADT.PatientInfo patient, ArrayList balanceLists)
        {
            this.SetDB(inpatientManager);

            int returnValue = 0;

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.BalanceList balanceList in balanceLists)
            {
                returnValue = inpatientManager.InsertBalanceList(patient, balanceList);
                if (returnValue == -1)
                {
                    return -1;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 获得发票默认起始号
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <returns>成功 发票默认起始号 失败 null</returns>
        //public string GetInvoiceDefaultStartCode(Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService invoiceType)
        //{
        //    this.SetDB(invoiceServiceManager);

        //    return invoiceServiceManager.GetDefaultStartCode(invoiceType);
        //}

        public string GetInvoiceDefaultStartCode(string invoiceType)
        {
            this.SetDB(invoiceServiceManager);

            return invoiceServiceManager.GetDefaultStartCode(invoiceType);
        }

        /// <summary>
        /// 获得所有发票组信息
        /// </summary>
        /// <returns>成功 发票组信息 失败 null</returns>
        public ArrayList QueryFinaceGroupAll()
        {
            this.SetDB(employeeFinanceGroupManager);

            return employeeFinanceGroupManager.QueryFinaceGroupIDAndNameAll();
        }

        /// <summary>
        /// 验证发票区间是否合法
        /// </summary>
        /// <param name="startNO">开始号</param>
        /// <param name="endNO">结束号</param>
        /// <param name="invoiceType">发票类型</param>
        /// <returns>合法 True, 不合法 false</returns>
        //public bool InvoicesIsValid(int startNO, int endNO, Neusoft.HISFC.Models.Fee.InvoiceTypeEnumService invoiceType)
        //{
        //    this.SetDB(invoiceServiceManager);

        //    return invoiceServiceManager.InvoicesIsValid(startNO, endNO, invoiceType);
        //}
        public bool InvoicesIsValid(int startNO, int endNO, string invoiceType)
        {
            this.SetDB(invoiceServiceManager);

            return invoiceServiceManager.InvoicesIsValid(startNO, endNO, invoiceType);
        }

        /// <summary>
        /// 获得发票大类的DataSet
        /// </summary>
        /// <param name="invoiceType">发票类型</param>
        /// <param name="ds">发票大类的DataSet</param>
        /// <returns>成功 1 失败 -1</returns>
        public int GetInvoiceClass(string invoiceType, ref DataSet ds)
        {
            this.SetDB(outpatientManager);
            // TODO: 编译不过去，临时改一下
            return outpatientManager.GetInvoiceClass(invoiceType, ref ds);
        }

        /// <summary>
        /// 获得患者药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns></returns>
        public ArrayList QueryMedcineList(string inpatientNO, DateTime beginTime, DateTime endTime, string deptCode)
        {
            this.SetDB(inpatientManager);

            return inpatientManager.QueryMedItemListsByInpatientNO(inpatientNO, beginTime, endTime, deptCode);

        }

        /// <summary>
        /// 获得患者非药品信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns></returns>
        public ArrayList QueryFeeItemListsByInpatientNO(string inpatientNO, DateTime beginTime, DateTime endTime, string deptCode)
        {
            this.SetDB(inpatientManager);

            return inpatientManager.QueryFeeItemListsByInpatientNO(inpatientNO, beginTime, endTime, deptCode);
        }

        public ArrayList GetMedItemsForInpatient(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return inpatientManager.GetMedItemsForInpatient(inpatientNO, beginTime, endTime);
        }

        public ArrayList QueryFeeItemLists(string inpatientNO, DateTime beginTime, DateTime endTime)
        {
            return inpatientManager.QueryFeeItemLists(inpatientNO, beginTime, endTime);
        }

        /// <summary>
        /// 检索药品和非药品明细单条记录---通过主键{5C2A9C83-D165-434c-ACA4-86F23E956442}
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequence">处方内流水号</param>
        /// <param name="isPharmacy">是否药品 Drug(true)是 UnDrug(false)非药品</param>
        /// <returns>成功: 药品和非药品明细单条记录 失败: null</returns>
        public Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList GetItemListByRecipeNO(string recipeNO, int recipeSequence, EnumItemType isPharmacy)
        {
            this.SetDB(inpatientManager);
            return inpatientManager.GetItemListByRecipeNO(recipeNO, recipeSequence, isPharmacy);
        }

        #region 非药品项目信息
        /// <summary>
        /// 都督读
        /// 王宇添加
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Fee.Item.Undrug GetItem(string itemCode)
        {
            this.SetDB(itemManager);
            return itemManager.GetValidItemByUndrugCode(itemCode);
        }

        //{8F86BB0D-9BB4-4c63-965D-969F1FD6D6B2} 取出非药品及物资
        /// <summary>
        /// 取出非药品或物资
        /// </summary>
        /// <param name="itemCode">非药品或物资编码</param>
        /// <param name="price">单价、非药品可传入0</param>
        /// <returns>非药品或物资实体</returns>
        public Neusoft.HISFC.Models.Base.Item GetUndrugAndMatItem(string itemCode, decimal price)
        {
            this.SetDB(itemManager);
            if (itemCode.StartsWith("F"))
            {
                return itemManager.GetValidItemByUndrugCode(itemCode);
            }
            else
            {
                Neusoft.HISFC.Models.FeeStuff.MaterialItem matItem = materialManager.GetMetItem(itemCode);
                if (matItem == null)
                {
                    return null;
                }
                matItem.ItemType = EnumItemType.MatItem;
                matItem.Price = price;
                (matItem as Neusoft.HISFC.Models.Base.Item).Specs = matItem.Specs;
                matItem.SysClass.ID = "U";
                return matItem;
            }
        }

        /// <summary>
        /// 项目是否被使用过
        /// </summary>
        /// <param name="itemCode">项目ID</param>
        /// <returns>true:使用</returns>
        public bool IsUsed(string itemCode)
        {
            this.SetDB(itemManager);
            return itemManager.IsUsed(itemCode);
        }

        /// <summary>
        /// 删除非药品信息
        /// </summary>
        /// <param name="undrugCode">非药品编码</param>
        /// <returns>成功 1 失败 -1 未删除到数据 0</returns>
        public int DeleteUndrugItemByCode(string undrugID)
        {
            this.SetDB(itemManager);
            return itemManager.DeleteUndrugItemByCode(undrugID);
        }

        /// <summary>
        /// 获得所有可能的项目信息
        /// </summary>
        /// <returns>成功 有效的可用项目信息, 失败 null</returns>
        public ArrayList QueryValidItems()
        {
            this.SetDB(itemManager);
            return itemManager.QueryValidItems();
        }

        /// <summary>
        /// 获得所有项目信息
        /// </summary>
        /// <returns>成功 所有项目信息, 失败 null</returns>
        public List<Neusoft.HISFC.Models.Fee.Item.Undrug> QueryAllItemsList()
        {
            this.SetDB(itemManager);
            return itemManager.QueryAllItemList();
        }

        #endregion

        #region 非药品组套

        /// <summary>
        ///  插入非药品组合项目
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有插入数据 0</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
        public int InsertUndrugComb(Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb)
        {
            return -1;
            //this.SetDB(undrugCombManager);
            //return undrugCombManager.InsertUndrugComb(undrugComb);
        }

        /// <summary>
        /// 更新 非药品组套中的数据
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有更新到数据 0</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
        public int UpdateUndrugComb(Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb)
        {
            return -1;
            //this.SetDB(undrugCombManager);

            //return undrugCombManager.UpdateUndrugComb(undrugComb);
        }

        /// <summary>
        ///  删除非药品组合项目
        /// </summary>
        /// <param name="undrugComb">非药品组合项目实体</param>
        /// <returns>成功: 1 失败 : -1 没有删除到数据 0</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
        public int DeleteUndrugComb(Neusoft.HISFC.Models.Fee.Item.UndrugComb undrugComb)
        {
            return -1;
            //this.SetDB(undrugCombManager);

            //return undrugCombManager.DeleteUndrugComb(undrugComb);
        }

        /// <summary>
        /// 通过组合项目编码获取一条组合项目
        /// </summary>
        /// <param name="undrugCombCode">组合项目编码</param>
        /// <returns>成功: 一条组合项目 失败: null</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
        public Neusoft.HISFC.Models.Fee.Item.UndrugComb GetUndrugCombByCode(string undrugCombCode)
        {
            Neusoft.HISFC.Models.Fee.Item.UndrugComb com = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
            return com;
            //this.SetDB(undrugCombManager);

            //return undrugCombManager.GetUndrugCombByCode(undrugCombCode);
        }

        /// <summary>
        /// 通过组合项目编码获取一条有效组合项目
        /// </summary>
        /// <param name="undrugCombCode">组合项目编码</param>
        /// <returns>成功: 一条有效组合项目 失败: null</returns>
        [Obsolete("作废,复合项目已归并到非药品", true)]
        public Neusoft.HISFC.Models.Fee.Item.UndrugComb GetUndrugCombValidByCode(string undrugCombCode)
        {
            Neusoft.HISFC.Models.Fee.Item.UndrugComb com = new Neusoft.HISFC.Models.Fee.Item.UndrugComb();
            return com;
            //this.SetDB(undrugCombManager);

            //return undrugCombManager.GetUndrugCombValidByCode(undrugCombCode);
        }
        /// <summary>
        /// 获取复合项目的总价格
        /// </summary>
        /// <param name="undrugCombCode">复合项目编码</param>
        /// <returns></returns>
        public decimal GetUndrugCombPrice(string undrugCombCode)
        {
            this.SetDB(undrugPackAgeMgr);

            return undrugPackAgeMgr.GetUndrugCombPrice(undrugCombCode);
        }

        #endregion

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
            this.SetDB(inpatientManager);
            return inpatientManager.UpdateNoBackQtyForUndrug(recipeNO, recipeSequence, qty, balanceState);
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
            this.SetDB(inpatientManager);
            return inpatientManager.UpdateExtFlagForUndrug(recipeNO, recipeSequence, extFlag2, balanceState);
        }

        /// <summary>
        /// 获得患者和执行科室已经确认的非药品收费明细
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="execDeptCode">科室代码</param>
        /// <returns>成功:患者非药品信息 失败:null 没有找到记录 ArrayList.Count = 0</returns>
        public ArrayList QueryExeFeeItemListsByInpatientNOAndDept(string inpatientNO, string execDeptCode)
        {
            this.SetDB(inpatientManager);
            return inpatientManager.QueryExeFeeItemListsByInpatientNOAndDept(inpatientNO, execDeptCode);
        }

        #endregion

        #region 门诊

        #region 参数

        /// <summary>
        /// 获得指定控制参数
        /// </summary>
        /// <param name="controlID">控制类ID</param>
        /// <param name="defaultValue">默认值，没有找到返回此值</param>
        /// <returns>控制参数</returns>
        public string GetControlValue(string controlID, string defaultValue)
        {
            string tempValue = string.Empty;

            if (controlerHelper == null || controlerHelper.ArrayObject == null || controlerHelper.ArrayObject.Count <= 0)
            {
                tempValue = controlManager.QueryControlerInfo(controlID);
            }
            else
            {
                NeuObject obj = controlerHelper.GetObjectFromID(controlID);

                if (obj == null)
                {
                    tempValue = controlManager.QueryControlerInfo(controlID);
                }
                else
                {
                    tempValue = ((Neusoft.HISFC.Models.Base.Controler)obj).ControlerValue;
                }
            }

            if (tempValue == null || tempValue == string.Empty)
            {
                return defaultValue;
            }
            else
            {
                return tempValue;
            }
        }

        #endregion

        #region 门诊收费函数

        /// <summary>
        /// 获得当前接口插件
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <param name="controlCode">反射插件参数编码</param>
        /// <param name="defalutInstance">默认插件</param>
        /// <returns>成功T类型实例 错误 返回默认实例</returns>
        public T GetPlugIns<T>(string controlCode, T defalutInstance)
        {
            string controlValue = controlParamIntegrate.GetControlParam<string>(controlCode, true, string.Empty);

            if (controlValue == string.Empty)
            {
                return defalutInstance;
            }

            string dllName = string.Empty;
            string namesSpaceAndUcName = string.Empty;

            try
            {
                dllName = controlValue.Split('|')[0];
                namesSpaceAndUcName = controlValue.Split('|')[1];

                Assembly assemblyName = System.Reflection.Assembly.LoadFrom(Application.StartupPath + dllName);

                System.Runtime.Remoting.ObjectHandle objPlugin = null;

                objPlugin = System.Activator.CreateInstance(assemblyName.ToString(), namesSpaceAndUcName);

                if (objPlugin == null)
                {
                    MessageBox.Show("反射失败!请确认您选择的dll和uc的正确和完整! 将采用默认插件");

                    return defalutInstance;
                }

                object obj = objPlugin.Unwrap();

                defalutInstance = default(T);

                return (T)obj;
            }
            catch (Exception e)
            {
                MessageBox.Show("当前插件参数维护错误! 将采用默认插件" + e.Message);

                return defalutInstance;
            }
        }

        /// <summary>
        /// 获得患者的未收费项目信息
        /// </summary>
        /// <param name="clinicNO">挂号流水号</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public System.Collections.ArrayList QueryChargedFeeItemListsByClinicNO(string clinicNO)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.QueryChargedFeeItemListsByClinicNO(clinicNO);
        }

        /// <summary>
        /// 获得患者的已收费项目信息
        /// </summary>
        /// <param name="clinicNO">挂号流水号</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public System.Collections.ArrayList QueryFeeItemListsByClinicNO(string clinicNO)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.QueryFeeItemListsByClinicNO(clinicNO);
        }

        /// <summary>
        /// 获得项目价格
        /// priceObj.ID 保存 合同单位得价格形式编码
        /// priceObj.Name 保存患者得年龄
        /// priceObj.Memo 错误信息
        /// priceObj.User01 三甲价
        /// priceObj.User02 特诊价格
        /// priceObj.User03 儿童价格
        /// </summary>
        /// <param name="priceObj"></param>
        /// <returns>-1 失败 其他:应该使用得价格</returns>
        public decimal GetPrice(NeuObject priceObj)
        {
            decimal unitPrice = 0;
            decimal spPrice = 0;
            decimal chindPrice = 0;
            int age = 0;
            try
            {
                unitPrice = NConvert.ToDecimal(priceObj.User01);
            }
            catch (Exception ex)
            {
                priceObj.Memo = "三甲价转换错误" + ex.Message;

                return -1;
            }
            try
            {
                spPrice = NConvert.ToDecimal(priceObj.User02);
            }
            catch (Exception ex)
            {
                priceObj.Memo = "特诊价转换错误" + ex.Message;

                return -1;
            }
            try
            {
                chindPrice = NConvert.ToDecimal(priceObj.User03);
            }
            catch (Exception ex)
            {
                priceObj.Memo = "儿童价转换错误" + ex.Message;

                return -1;
            }
            try
            {
                age = NConvert.ToInt32(priceObj.Name);
            }
            catch (Exception ex)
            {
                priceObj.Memo = "年龄转换错误" + ex.Message;

                return -1;
            }
            if (priceObj.ID == "特诊价")
            {
                return spPrice;
            }
            //先注释掉{7BFE3521-F843-4789-AC85-DB16F3C428D6} wbo 2011-02-10
            //else if (age <= 14)
            //{
            //    return chindPrice;
            //}
            if (priceObj.ID == "三甲价")//三甲
            {
                return unitPrice;
            }
            else if (priceObj.ID == "儿童价")//儿童
            {
                return chindPrice;
            }
            else
            {
                return unitPrice;
            }
        }

        /// <summary>
        /// 控制参数帮助类
        /// </summary>
        public static Neusoft.FrameWork.Public.ObjectHelper controlerHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 转换科室帮助类
        /// </summary>
        private static Neusoft.FrameWork.Public.ObjectHelper hsInvertDept = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 分处方号忽略类别
        /// </summary>
        private static bool isDecSysClassWhenGetRecipeNO = false;

        /// <summary>
        /// 每次用量可否为空
        /// </summary>
        public static bool isDoseOnceCanNull = false;

        /// <summary>
        /// 不打小票的科室
        /// </summary>
        private static Neusoft.FrameWork.Public.ObjectHelper printRecipeHeler = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 获得[最大的流水号]和处方号
        /// </summary>
        /// <param name="feeItemLists">处方明细</param>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequence">处方流水号</param>
        public void GetRecipeNoAndMaxSeq(ArrayList feeItemLists, ref string recipeNO, ref int sequence)
        {
            if (feeItemLists == null || feeItemLists.Count <= 0)
            {
                return;
            }

            foreach (FeeItemList feeItem in feeItemLists)
            {
                if (feeItem.RecipeNO != null && feeItem.RecipeNO.Length > 0)
                {
                    recipeNO = feeItem.RecipeNO;

                    sequence = NConvert.ToInt32(outpatientManager.GetMaxSeqByRecipeNO(recipeNO));

                    break;
                }
            }
        }

        /// <summary>
        /// 针对收费项目列表按照 系统类别，执行科室，付数 声称处方号
        /// 同一系统类别，统一执行科室，同一付数的项目处方号相同
        /// 对已经分配好处方号的项目不进行重新分配
        /// </summary>
        /// <param name="feeDetails">费用信息</param>
        /// <param name="t">数据库Trans</param>
        /// <param name="errText">错误信息</param>
        /// <returns>false失败 true成功</returns>
        public bool SetRecipeNOOutpatient(Register r,ArrayList feeDetails, ref string errText)
        {
            Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitRecipe iSplitRecipe = null;
            //iSplitRecipe = new InterfaceInstanceDefault.ISplitRecipe.ISplitRecipeDefault();
            iSplitRecipe = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitRecipe)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitRecipe;
            if (iSplitRecipe != null)
            {
                //保存适应症信息
                return iSplitRecipe.SplitRecipe(r, feeDetails,ref errText);
                //if (returnValue < 0)
                //{
                //    return false;
                //}

            }
            else
            {
                #region 默认的实现
                bool isDealCombNO = false; //是否优先处理组合号
                int noteCounts = 0;        //获得单张处方最多的项目数

                //是否优先处理组合号
                isDealCombNO = controlParamIntegrate.GetControlParam<bool>(Const.DEALCOMBNO, false, true);

                //获得单张处方最多的项目数, 默认项目数 5
                noteCounts = controlParamIntegrate.GetControlParam<int>(Const.NOTECOUNTS, false, 5);

                //是否忽略系统类别
                isDecSysClassWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Const.DEC_SYS_WHENGETRECIPE, false, false);

                //是否优先处理暂存记录
                bool isDecTempSaveWhenGetRecipeNO = controlParamIntegrate.GetControlParam<bool>(Const.处方号优先考虑分方记录, false, false);

                ArrayList sortList = new ArrayList();
                while (feeDetails.Count > 0)
                {
                    ArrayList sameNotes = new ArrayList();
                    FeeItemList compareItem = feeDetails[0] as FeeItemList;
                    foreach (FeeItemList f in feeDetails)
                    {
                        if (isDecSysClassWhenGetRecipeNO)
                        {
                            if (f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID
                                && f.Days == compareItem.Days && (isDecTempSaveWhenGetRecipeNO ? f.RecipeSequence == compareItem.RecipeSequence : true))
                            {
                                sameNotes.Add(f);
                            }
                        }
                        else
                        {
                            if (f.Item.SysClass.ID.ToString() == compareItem.Item.SysClass.ID.ToString()
                                && f.ExecOper.Dept.ID == compareItem.ExecOper.Dept.ID
                                && f.Days == compareItem.Days && (isDecTempSaveWhenGetRecipeNO ? f.RecipeSequence == compareItem.RecipeSequence : true))
                            {
                                sameNotes.Add(f);
                            }
                        }

                    }
                    sortList.Add(sameNotes);
                    foreach (FeeItemList f in sameNotes)
                    {
                        feeDetails.Remove(f);
                    }
                }

                foreach (ArrayList temp in sortList)
                {
                    ArrayList combAll = new ArrayList();
                    ArrayList noCombAll = new ArrayList();
                    ArrayList noCombUnits = new ArrayList();
                    ArrayList noCombFinal = new ArrayList();


                    if (isDealCombNO)//优先处理组合号，将所有的组合号再重新分组
                    {
                        //挑选出没有组合号的项目
                        foreach (FeeItemList f in temp)
                        {
                            if (f.Order.Combo.ID == null || f.Order.Combo.ID == string.Empty)
                            {
                                noCombAll.Add(f);
                            }
                        }
                        //从整体数组中删除没有组合号的项目
                        foreach (FeeItemList f in noCombAll)
                        {
                            temp.Remove(f);
                        }
                        //针对同一处方最多项目数再重新分组
                        while (noCombAll.Count > 0)
                        {
                            noCombUnits = new ArrayList();
                            foreach (FeeItemList f in noCombAll)
                            {
                                if (noCombUnits.Count < noteCounts)
                                {
                                    noCombUnits.Add(f);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            noCombFinal.Add(noCombUnits);
                            foreach (FeeItemList f in noCombUnits)
                            {
                                noCombAll.Remove(f);
                            }
                        }
                        //如果剩余的项目条目> 0说明还有组合的项目
                        if (temp.Count > 0)
                        {
                            while (temp.Count > 0)
                            {
                                ArrayList combNotes = new ArrayList();
                                FeeItemList compareItem = temp[0] as FeeItemList;
                                foreach (FeeItemList f in temp)
                                {
                                    if (f.Order.Combo.ID == compareItem.Order.Combo.ID)
                                    {
                                        combNotes.Add(f);
                                    }
                                }
                                combAll.Add(combNotes);
                                foreach (FeeItemList f in combNotes)
                                {
                                    temp.Remove(f);
                                }
                            }
                        }
                        foreach (ArrayList tempNoComb in noCombFinal)
                        {
                            string recipeNo = null;//处方流水号
                            int noteSeq = 1;//处方内项目流水号

                            string tempRecipeNO = string.Empty;
                            int tempSequence = 0;
                            this.GetRecipeNoAndMaxSeq(tempNoComb, ref tempRecipeNO, ref tempSequence);

                            if (tempRecipeNO != string.Empty && tempSequence > 0)
                            {
                                tempSequence += 1;
                                foreach (FeeItemList f in tempNoComb)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = tempRecipeNO;
                                        f.SequenceNO = tempSequence;
                                        tempSequence++;
                                    }
                                }
                            }
                            else
                            {
                                recipeNo = outpatientManager.GetRecipeNO();
                                if (recipeNo == null || recipeNo == string.Empty)
                                {
                                    errText = "获得处方号出错!";
                                    return false;
                                }
                                foreach (FeeItemList f in tempNoComb)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = recipeNo;
                                        f.SequenceNO = noteSeq;
                                        noteSeq++;
                                    }
                                }
                            }
                        }
                        foreach (ArrayList tempComb in combAll)
                        {
                            string recipeNo = null;//处方流水号
                            int noteSeq = 1;//处方内项目流水号

                            string tempRecipeNO = string.Empty;
                            int tempSequence = 0;
                            this.GetRecipeNoAndMaxSeq(tempComb, ref tempRecipeNO, ref tempSequence);

                            if (tempRecipeNO != string.Empty && tempSequence > 0)
                            {
                                tempSequence += 1;
                                foreach (FeeItemList f in tempComb)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = tempRecipeNO;
                                        f.SequenceNO = tempSequence;
                                        tempSequence++;
                                    }
                                }
                            }
                            else
                            {
                                recipeNo = outpatientManager.GetRecipeNO();
                                if (recipeNo == null || recipeNo == string.Empty)
                                {
                                    errText = "获得处方号出错!";
                                    return false;
                                }
                                foreach (FeeItemList f in tempComb)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = recipeNo;
                                        f.SequenceNO = noteSeq;
                                        noteSeq++;
                                    }
                                }
                            }
                        }
                    }
                    else //不优先处理组合号
                    {
                        ArrayList counts = new ArrayList();
                        ArrayList countUnits = new ArrayList();
                        while (temp.Count > 0)
                        {
                            countUnits = new ArrayList();
                            foreach (FeeItemList f in temp)
                            {
                                if (countUnits.Count < noteCounts)
                                {
                                    countUnits.Add(f);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            counts.Add(countUnits);
                            foreach (FeeItemList f in countUnits)
                            {
                                temp.Remove(f);
                            }
                        }

                        //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                        Hashtable hs = new Hashtable();


                        foreach (ArrayList tempCounts in counts)
                        {
                            string recipeNO = null;//处方流水号
                            int recipeSequence = 1;//处方内项目流水号

                            string tempRecipeNO = string.Empty;
                            int tempSequence = 0;
                            this.GetRecipeNoAndMaxSeq(tempCounts, ref tempRecipeNO, ref tempSequence);
                            //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                            if (hs.Contains(tempRecipeNO))
                            {
                                tempSequence = Neusoft.FrameWork.Function.NConvert.ToInt32((hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name);
                            }
                            else
                            {
                                Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
                                obj.ID = tempRecipeNO;
                                obj.Name = tempSequence.ToString();
                                hs.Add(tempRecipeNO, obj);
                            }

                            if (tempRecipeNO != string.Empty && tempSequence > 0)
                            {
                                tempSequence += 1;
                                foreach (FeeItemList f in tempCounts)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = tempRecipeNO;
                                        f.SequenceNO = tempSequence;
                                        tempSequence++;
                                    }
                                }
                                //{B24B174D-F261-4c6b-94C9-EEED0F736013}
                                if (hs.Contains(tempRecipeNO))
                                {
                                    (hs[tempRecipeNO] as Neusoft.FrameWork.Models.NeuObject).Name = tempSequence.ToString();
                                }
                            }
                            else
                            {
                                recipeNO = outpatientManager.GetRecipeNO();
                                if (recipeNO == null || recipeNO == string.Empty)
                                {
                                    errText = "获得处方号出错!";
                                    return false;
                                }
                                foreach (FeeItemList f in tempCounts)
                                {
                                    feeDetails.Add(f);
                                    if (f.RecipeNO != null && f.RecipeNO != string.Empty)//已经分配处方号
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        f.RecipeNO = recipeNO;
                                        f.SequenceNO = recipeSequence;
                                        recipeSequence++;
                                    }
                                }//{B24B174D-F261-4c6b-94C9-EEED0F736013}
                                if (!hs.Contains(tempRecipeNO))
                                {
                                    Neusoft.FrameWork.Models.NeuObject obj = new NeuObject();
                                    obj.ID = recipeNO;
                                    obj.Name = recipeSequence.ToString();
                                    hs.Add(recipeNO, obj);
                                }
                            }


                        }
                    }
                }
                #endregion
            }
            return true;
        }


        /// <summary>
        /// 门诊明细数据校验
        /// </summary>
        /// <param name="f">费用实体</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 true 失败 false</returns>
        public bool IsFeeItemListDataValid(FeeItemList f, ref string errText)
        {
            string itemName = f.Item.Name;
            if (f == null)
            {
                errText = itemName + "获得费用实体出错!";

                return false;
            }
            if (f.Item.ID == null || f.Item.ID == string.Empty)
            {
                errText = itemName + "项目编码没有付值";

                return false;
            }
            if (f.Item.Name == null || f.Item.Name == string.Empty)
            {
                errText = itemName + "项目名称没有付值";

                return false;
            }
            //if (f.Item.IsPharmacy)
            if (f.Item.ItemType == EnumItemType.Drug)
            {
                if (f.Item.Specs == null || f.Item.Specs == string.Empty)
                {
                    errText = itemName + "药品的规格没有付值";

                    return false;
                }
                #region 根据参数&& !isDoseOnceCanNull 来判断是否需要输入各个值 刘兴强20070828
                if ((f.Order.Frequency.ID == null || f.Order.Frequency.ID == string.Empty) && !isDoseOnceCanNull)
                {
                    errText = itemName + "频次代码没有付值";

                    return false;
                }
                if ((f.Order.Usage.ID == null || f.Order.Usage.ID == string.Empty) && !isDoseOnceCanNull)
                {
                    errText = itemName + "用法代码没有付值";

                    return false;
                }
                if (f.Order.DoseOnce == 0 && !isDoseOnceCanNull)
                {
                    errText = itemName + "每次用量没有付值";

                    return false;
                }
                if ((f.Order.DoseUnit == null || f.Order.DoseUnit == string.Empty) && !isDoseOnceCanNull)
                {
                    errText = itemName + "每次用量单位没有付值";

                    return false;
                }
                #endregion
            }
            if (f.Item.PackQty == 0)
            {
                errText = itemName + "包装数量没有付值";

                return false;
            }
            if (f.Item.PriceUnit == null || f.Item.PriceUnit == string.Empty)
            {
                errText = itemName + "计价单位没有付值";

                return false;
            }


            if (f.Item.MinFee.ID == null || f.Item.MinFee.ID == string.Empty)
            {
                errText = itemName + "最小费用没有付值";

                return false;
            }
            if (f.Item.SysClass.ID == null || f.Item.SysClass.Name == string.Empty)
            {
                errText = itemName + "系统类别没有付值";

                return false;
            }
            if (f.Item.Price == 0)
            {
                errText = itemName + "单价没有付值";

                return false;
            }
            if (f.Item.Price < 0)
            {
                errText = itemName + "单价不能小于0";

                return false;
            }
            if (f.Item.Qty == 0)
            {
                errText = itemName + "数量没有付值";

                return false;
            }
            if (f.Item.Qty < 0)
            {
                errText = itemName + "数量不能小于0";

                return false;
            }

            if (f.Item.Qty > 99999)
            {
                errText = itemName + "数量不能大于99999";

                return false;
            }

            if (f.Days == 0)
            {
                errText = itemName + "草药付数没有付值";

                return false;
            }
            if (f.Days < 0)
            {
                errText = itemName + "草药付数不能小于0";

                return false;
            }
            if (f.FT.OwnCost + f.FT.PayCost + f.FT.PubCost == 0)
            {
                errText = itemName + "项目金额没有付值";

                return false;
            }
            if (f.FT.OwnCost + f.FT.PayCost + f.FT.PubCost < 0)
            {
                errText = itemName + "项目金额为负";

                return false;
            }
            ////{8DF48FD8-14E9-464a-A368-256B19A0EE54} 修改又会比例
            //if (Neusoft.FrameWork.Public.String.FormatNumber(f.Item.Price * f.Item.Qty / f.Item.PackQty, 2) != Neusoft.FrameWork.Public.String.FormatNumber
            //    (f.FT.OwnCost + f.FT.PayCost + f.FT.PubCost /*+ f.FT.RebateCost*/, 2))
            //{
            //    errText = itemName + "金额与单价数量不符";

            //    return false;
            //}
            if (f.ExecOper.Dept.ID == null || f.ExecOper.Dept.ID == string.Empty)
            {
                errText = itemName + "执行科室代码没有付值";

                return false;
            }
            if (f.ExecOper.Dept.Name == null || f.ExecOper.Dept.Name == string.Empty)
            {
                errText = itemName + "执行科室名称没有付值";

                return false;
            }

            return true;
        }

        #region 删除　集体体检汇总划价信息
        /// <summary>
        /// 根据体检流水号和发票组合号删除体检汇总信息　
        /// </summary>
        /// <param name="ClinicNO">体检流水号</param>
        /// <param name="RecipeNO">发票组合号</param>
        /// <returns></returns>
        public int DeleteFeeItemListByClinicNOAndRecipeNO(string ClinicNO, string RecipeNO)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.DeleteFeeItemListByClinicNOAndRecipeNO(ClinicNO, RecipeNO);
        }
        #endregion

        /// <summary>
        /// 获得发票号
        /// </summary>
        /// <param name="oper">人员基本信息</param>
        /// <param name="ctrl">控制参数类</param>
        /// <param name="invoiceNO">发票电脑号</param>
        /// <param name="realInvoiceNO">实际发票号</param>
        /// <param name="t">数据库事务</param>
        /// <param name="errText">错误信息</param>
        /// <returns>-1 失败 1 成功!</returns>
        public int GetInvoiceNO(Neusoft.HISFC.Models.Base.Employee oper, ref string invoiceNO, ref string realInvoiceNO, ref string errText, Neusoft.FrameWork.Management.Transaction trans)
        {
            string invoiceType = controlParamIntegrate.GetControlParam<string>(Const.GET_INVOICE_NO_TYPE, false, "0");

            NeuObject objInvoice = new NeuObject();

            switch (invoiceType)
            {
                case "2"://普通模式

                    objInvoice = managerIntegrate.GetConstansObj("MZINVOICE", oper.ID);

                    //没有维护发票起始号
                    if (objInvoice == null || objInvoice.ID == null || objInvoice.ID == string.Empty)
                    {
                        if (Neusoft.FrameWork.Management.PublicTrans.Trans == null)
                        {
                            //trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                            //trans.BeginTransaction();
                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        }
                        managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();
                        con.ID = oper.ID;
                        con.Name = "1";//默认从1开始
                        con.Memo = "1";//默认从1开始
                        con.IsValid = true;
                        con.OperEnvironment.ID = oper.ID;
                        con.OperEnvironment.OperTime = inpatientManager.GetDateTimeFromSysDateTime();

                        int iReturn = managerIntegrate.InsertConstant("MZINVOICE", con);
                        if (iReturn <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            errText = "插入操作员初试发票失败!" + managerIntegrate.Err;

                            return -1;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        //invoiceNO = objInvoice.Name;
                        //realInvoiceNO = objInvoice.Name;
                        //string invoiceNOTemp = this.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.C);
                        //{BCB3B25A-69CD-4dfe-84D2-21D2239A7467}
                        if (Neusoft.FrameWork.Management.PublicTrans.Trans == null) 
                        {
                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        }

                        string invoiceNOTemp = this.GetNewInvoiceNO("C");
                        //{BCB3B25A-69CD-4dfe-84D2-21D2239A7467}
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();

                        if (invoiceNOTemp == null || invoiceNOTemp == string.Empty)
                        {
                            errText = "获得发票失败!" + this.Err;

                            return -1;
                        }

                        invoiceNO = invoiceNOTemp;
                        realInvoiceNO = objInvoice.Name;
                    }
                    else
                    {
                        //string invoiceNOTemp = this.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.C);
                        string invoiceNOTemp = this.GetNewInvoiceNO("C");
                        if (invoiceNOTemp == null || invoiceNOTemp == string.Empty)
                        {
                            errText = "获得发票失败!" + this.Err;

                            return -1;
                        }

                        invoiceNO = invoiceNOTemp;
                        realInvoiceNO = objInvoice.Name;
                    }

                    break;

                case "0": //广医模式
                    objInvoice = managerIntegrate.GetConstansObj("MZINVOICE", oper.ID);

                    //没有维护发票起始号
                    if (objInvoice == null || objInvoice.ID == null || objInvoice.ID == string.Empty)
                    {
                        //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                        //trans.BeginTransaction(); by niuxy

                        if (Neusoft.FrameWork.Management.PublicTrans.Trans == null)
                        {
                            //trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                            //trans.BeginTransaction();
                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        }
                        managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                        Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();
                        con.ID = oper.ID;
                        con.Name = "1";//默认从1开始
                        con.Memo = "1";//默认从1开始
                        con.IsValid = true;
                        con.OperEnvironment.ID = oper.ID;
                        con.OperEnvironment.OperTime = inpatientManager.GetDateTimeFromSysDateTime();

                        int iReturn = managerIntegrate.InsertConstant("MZINVOICE", con);
                        if (iReturn <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            errText = "插入操作员初试发票失败!" + managerIntegrate.Err;

                            return -1;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        invoiceNO = objInvoice.Name;
                        realInvoiceNO = objInvoice.Name;
                    }
                    else
                    {
                        invoiceNO = objInvoice.Name.PadLeft(12, '0');
                        realInvoiceNO = NConvert.ToInt32(objInvoice.Name).ToString();
                    }
                    break;
                case "1": //中山医模式!

                    objInvoice = managerIntegrate.GetConstansObj("MZINVOICE", oper.ID);
                    if (objInvoice == null)
                    {
                        errText = "获得发票信息出错!" + managerIntegrate.Err;

                        return -1;
                    }

                    Employee empl = managerIntegrate.GetEmployeeInfo(oper.ID);
                    if (empl == null)
                    {
                        errText = "获得操作员基本信息出错!" + managerIntegrate.Err;

                        return -1;
                    }

                    string tmpOperCode = empl.UserCode;
                    oper.UserCode = empl.UserCode;

                    if (oper == null || oper.UserCode == null || oper.UserCode == string.Empty || oper.UserCode.Length > 2)
                    {
                        tmpOperCode = "XX";
                    }
                    else
                    {
                        tmpOperCode = empl.UserCode;
                    }

                    //没有维护发票起始号
                    if (objInvoice == null || objInvoice.ID == null || objInvoice.ID == string.Empty)
                    {
                        //Neusoft.FrameWork.Management.Transaction 
                        if (Neusoft.FrameWork.Management.PublicTrans.Trans == null)
                        {
                            //trans = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                            //trans.BeginTransaction();
                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                        }
                        managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        inpatientManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                        Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();
                        con.ID = oper.ID;
                        con.Name = "1";//默认从1开始
                        con.IsValid = true;
                        con.OperEnvironment.ID = oper.ID;
                        con.OperEnvironment.OperTime = inpatientManager.GetDateTimeFromSysDateTime();
                        con.Memo = con.OperEnvironment.OperTime.Year.ToString().Substring(2, 2) + con.OperEnvironment.OperTime.Month.ToString().PadLeft(2, '0') +
                            con.OperEnvironment.OperTime.Day.ToString().PadLeft(2, '0') + tmpOperCode + "0001";
                        int iReturn = managerIntegrate.InsertConstant("MZINVOICE", con);
                        if (iReturn <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            errText = "插入操作员初试发票失败!" + managerIntegrate.Err;
                            return -1;
                        }
                        Neusoft.FrameWork.Management.PublicTrans.Commit();
                        invoiceNO = con.Memo;
                    }
                    else
                    {
                        invoiceNO = objInvoice.Memo;
                        DateTime now = inpatientManager.GetDateTimeFromSysDateTime();
                        if (invoiceNO == null || invoiceNO == string.Empty)
                        {
                            invoiceNO = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') +
                                now.Day.ToString().PadLeft(2, '0') + tmpOperCode + "0001";
                        }
                        try
                        {
                            DateTime dtInvoice = new DateTime(2000 + Neusoft.FrameWork.Function.NConvert.ToInt32(invoiceNO.Substring(0, 2)), Neusoft.FrameWork.Function.NConvert.ToInt32(invoiceNO.Substring(2, 2)), Neusoft.FrameWork.Function.NConvert.ToInt32(invoiceNO.Substring(4, 2)));
                            if (now.Date > dtInvoice)
                            {
                                invoiceNO = now.Year.ToString().Substring(2, 2) + now.Month.ToString().PadLeft(2, '0') +
                                    now.Day.ToString().PadLeft(2, '0') + tmpOperCode + "0001";
                            }
                        }
                        catch (Exception ex)
                        {
                            errText = "发票转换日期出错!" + ex.Message;
                            return -1;
                        }

                        realInvoiceNO = objInvoice.Name;
                    }

                    break;
            }

            return 1;
        }

        /// <summary>
        /// 获得下一张发票号
        /// </summary>
        /// <param name="invoiceType">获得发票号方式</param>
        /// <param name="invoiceNO">当前电脑发票号</param>
        /// <param name="realInvoiceNO">当前实际发票号</param>
        /// <param name="nextInvoiceNO">下一张电脑发票号</param>
        /// <param name="nextRealInvoiceNO">下一张实际发票号</param>
        /// <param name="errText">错误信息</param>
        /// <returns>-1 错误 1 正确</returns>
        public int GetNextInvoiceNO(string invoiceType, string invoiceNO, string realInvoiceNO, ref string nextInvoiceNO, ref string nextRealInvoiceNO, ref string errText)
        {
            return GetNextInvoiceNO(invoiceType, invoiceNO, realInvoiceNO, ref nextInvoiceNO, ref nextRealInvoiceNO, 1, ref errText);
        }

        /// <summary>
        /// 获得下N张发票号
        /// </summary>
        /// <param name="invoiceType">获得发票号方式</param>
        /// <param name="invoiceNO">当前电脑发票号</param>
        /// <param name="realInvoiceNO">当前实际发票号</param>
        /// <param name="nextInvoiceNO">下一张电脑发票号</param>
        /// <param name="nextRealInvoiceNO">下一张实际发票号</param>
        /// <param name="count">下几张发票</param>
        /// <param name="errText">错误信息</param>
        /// <returns>-1 错误 1 正确</returns>
        public int GetNextInvoiceNO(string invoiceType, string invoiceNO, string realInvoiceNO, ref string nextInvoiceNO, ref string nextRealInvoiceNO, int count, ref string errText)
        {
            switch (invoiceType)
            {
                case "2"://普通模式

                    string invoiceNOTemp = string.Empty;

                    for (int i = 0; i < count; i++)
                    {
                        //invoiceNOTemp = this.GetNewInvoiceNO(Neusoft.HISFC.Models.Fee.EnumInvoiceType.C);
                        invoiceNOTemp = this.GetNewInvoiceNO("C");
                        if (invoiceNOTemp == null || invoiceNOTemp == string.Empty)
                        {
                            errText = "获得发票失败!";

                            return -1;
                        }
                    }

                    if (count == 0)
                    {
                        invoiceNOTemp = invoiceNO;
                    }

                    nextInvoiceNO = invoiceNOTemp;
                    nextRealInvoiceNO = nextRealInvoiceNO = (NConvert.ToInt32(realInvoiceNO) + count).ToString();

                    break;

                case "0"://广医方式
                    //广医方式的发票号,为纯数字,所以直接增加1即可
                    nextInvoiceNO = ((NConvert.ToInt32(invoiceNO) + count).ToString()).PadLeft(12, '0');
                    //广医方式的实际发票号,根电脑号一样,同步增加
                    nextRealInvoiceNO = NConvert.ToInt32(nextInvoiceNO).ToString();

                    break;
                case "1"://中山方式
                    //因为中山方式的发票最后四位决定发票的序列号,所以一定要大于4位,并且最后四位为数字才是合法发票
                    if (invoiceNO.Length < 4)
                    {
                        errText = "发票号长度不符合!";

                        return -1;
                    }
                    //获得中山发票的长度
                    int len = invoiceNO.Length;
                    //获得发票除了后四位的字符串,代表发票的日期和收款员,格式为yymmddxx(年,月,日,操作员2位工号)
                    string orgInvoice = invoiceNO.Substring(0, len - 4);
                    //获得后四位发票序列号
                    string addInvoice = invoiceNO.Substring(len - 4, 4);

                    //获得下一张发票号
                    nextInvoiceNO = orgInvoice + (NConvert.ToInt32(addInvoice) + count).ToString().PadLeft(4, '0');
                    //实际发票号为数字,直接增加1即可
                    nextRealInvoiceNO = (NConvert.ToInt32(realInvoiceNO) + count).ToString();

                    break;
            }

            return 1;
        }

        /// <summary>
        /// 当选择系统发票时候,重打调用,只更新发票打印号
        /// </summary>
        /// <param name="invoiceNO">当前发票号</param>
        /// <param name="realInvoiceNO">当前发票打印号</param>
        /// <param name="errText">错误编码</param>
        /// <returns>成功1  失败 -1</returns>
        public int UpdateOnlyRealInvoiceNO(string invoiceNO, string realInvoiceNO, ref string errText)
        {
            Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();

            con.ID = outpatientManager.Operator.ID;
            realInvoiceNO = (NConvert.ToInt32(realInvoiceNO) + 1).ToString();
            con.Name = realInvoiceNO;
            con.Memo = invoiceNO;

            con.IsValid = true;
            con.OperEnvironment.ID = outpatientManager.Operator.ID;
            con.OperEnvironment.OperTime = outpatientManager.GetDateTimeFromSysDateTime();
            int returnValue = managerIntegrate.UpdateConstant("MZINVOICE", con);
            if (returnValue <= 0)
            {
                errText = "更新操作员初试发票失败!" + managerIntegrate.Err;

                return -1;
            }

            return returnValue;
        }

        /// <summary>
        /// 获得发票号
        /// </summary>
        /// <param name="invoiceNO">发票电脑号</param>
        /// <param name="realInvoiceNO">实际发票号</param>
        /// <param name="errText">错误信息</param>
        /// <returns>-1 失败 1 成功!</returns>
        public int UpdateInvoiceNO(string invoiceNO, string realInvoiceNO, ref string errText)
        {
            string invoiceType = controlParamIntegrate.GetControlParam<string>(Const.GET_INVOICE_NO_TYPE, false, "0");

            int returnValue = 0;
            string nextInvoiceNO = string.Empty;
            string nextRealInvoiceNO = string.Empty;

            Neusoft.HISFC.Models.Base.Const con = new Neusoft.HISFC.Models.Base.Const();

            con.ID = outpatientManager.Operator.ID;
            returnValue = this.GetNextInvoiceNO(invoiceType, invoiceNO, realInvoiceNO, ref nextInvoiceNO, ref nextRealInvoiceNO, ref errText);
            if (returnValue < 0)
            {
                return -1;
            }

            if (invoiceType == "1")
            {
                con.Name = nextRealInvoiceNO;
                con.Memo = nextInvoiceNO;
            }
            else if (invoiceType == "2")
            {
                con.Name = nextRealInvoiceNO;
                con.Memo = nextInvoiceNO;
            }
            else
            {
                con.Name = nextInvoiceNO;
                con.Memo = nextRealInvoiceNO;
            }

            con.IsValid = true;
            con.OperEnvironment.ID = outpatientManager.Operator.ID;
            con.OperEnvironment.OperTime = outpatientManager.GetDateTimeFromSysDateTime();
            returnValue = managerIntegrate.UpdateConstant("MZINVOICE", con);
            if (returnValue <= 0)
            {
                errText = "更新操作员初试发票失败!" + managerIntegrate.Err;

                return -1;
            }

            return returnValue;
        }
        /// <summary>
        /// 更新发票主表表FIN_OPB_INVOICEINFO
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="balanceFlag"></param>
        /// <param name="balanceNo"></param>
        /// <param name="dtBalanceDate"></param>
        /// <returns></returns>
        public int UpdateInvoiceForDayBalance(System.DateTime dtBegin, System.DateTime dtEnd, string balanceFlag, string balanceNo, System.DateTime dtBalanceDate)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.UpdateInvoiceForDayBalance(dtBegin, dtEnd, balanceFlag, balanceNo, dtBalanceDate);
        }
        /// <summary>
        /// 更新发票明细表FIN_OPB_INVOICEDETAIL
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="balanceFlag"></param>
        /// <param name="balanceNo"></param>
        /// <param name="dtBalanceDate"></param>
        /// <returns></returns>
        public int UpdateInvoiceDetailForDayBalance(System.DateTime dtBegin, System.DateTime dtEnd, string balanceFlag, string balanceNo, System.DateTime dtBalanceDate)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.UpdateInvoiceForDayBalance(dtBegin, dtEnd, balanceFlag, balanceNo, dtBalanceDate);
        }
        /// <summary>
        /// 更新支付情况表FIN_OPB_PAYMODE
        /// </summary>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="balanceFlag"></param>
        /// <param name="balanceNo"></param>
        /// <param name="dtBalanceDate"></param>
        /// <returns></returns>
        public int UpdatePayModeForDayBalance(System.DateTime dtBegin, System.DateTime dtEnd, string balanceFlag, string balanceNo, System.DateTime dtBalanceDate)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.UpdatePayModeForDayBalance(dtBegin, dtEnd, balanceFlag, balanceNo, dtBalanceDate);
        }
        public static string invoiceType = "0";//发票类型

        /// <summary>
        /// 获得体检所有收费序列
        /// </summary>
        /// <param name="feeItemLists"></param>
        /// <returns></returns>
        private ArrayList GetRecipeSequenceForChk(ArrayList feeItemLists)
        {
            ArrayList list = new ArrayList();

            foreach (FeeItemList f in feeItemLists)
            {
                if (list.IndexOf(f.RecipeSequence) >= 0)
                {
                    continue;
                }
                else
                {
                    list.Add(f.RecipeSequence);
                }
            }

            return list;
        }

        /// <summary>
        /// 拆分协定处方
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private ArrayList SplitNostrumDetail(Neusoft.HISFC.Models.Registration.Register rInfo, FeeItemList f,ref string errText)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Nostrum> listDetail = this.pharmarcyManager.QueryNostrumDetail(f.Item.ID);
            ArrayList alTemp = new ArrayList();
            if (listDetail == null)
            {
                errText = "获得协定处方明细出错!" + pharmarcyManager.Err;

                return null;
            }
            decimal price = 0;
            decimal count = 0;
            string feeCode = string.Empty;
            string itemType = string.Empty;
            decimal totCost = 0;
            decimal packQty = 0m;
            FeeItemList feeDetail = null;
            if (f.Order.ID == null || f.Order.ID == string.Empty)
            {
                f.Order.ID = this.orderManager.GetNewOrderID();
                if (f.Order.ID == null || f.Order.ID == string.Empty)
                {
                    errText = "获得医嘱流水号出错!";

                    return null;
                }
            }
            string comboNO = string.Empty;
            if (string.IsNullOrEmpty(f.Order.Combo.ID))
            {
                comboNO = f.Order.Combo.ID;
            }
            else
            {
                comboNO = orderManager.GetNewOrderComboID();
            }
            foreach (Neusoft.HISFC.Models.Pharmacy.Nostrum nosItem in listDetail)
            {
                Neusoft.HISFC.Models.Pharmacy.Item item = pharmarcyManager.GetItem(nosItem.Item.ID);
                if (item == null)
                {
                    errText = "查找协定处方明细出错!";

                    continue;
                }

                feeDetail = new FeeItemList();
                feeDetail.Item = item;
                feeCode = item.MinFee.ID;
                try
                {
                    DateTime nowTime = this.outpatientManager.GetDateTimeFromSysDateTime();
                    int age = (int)((new TimeSpan(nowTime.Ticks - rInfo.Birthday.Ticks)).TotalDays / 365);

                    NeuObject priceObj = new NeuObject();
                    priceObj.ID = rInfo.Pact.PriceForm;
                    priceObj.Name = age.ToString();
                    priceObj.User01 = NConvert.ToDecimal(item.Price).ToString();
                    priceObj.User02 = NConvert.ToDecimal(item.SpecialPrice).ToString();
                    priceObj.User02 = NConvert.ToDecimal(item.ChildPrice).ToString();
                    price = this.GetPrice(priceObj);

                    packQty = item.PackQty;
                    price = Neusoft.FrameWork.Public.String.FormatNumber(
                            NConvert.ToDecimal(price / packQty), 4);
                }
                catch (Exception e)
                {
                    errText = e.Message;

                    return null;
                }
                count = NConvert.ToDecimal(f.Item.Qty) * nosItem.Qty;
                totCost = price * count;

                feeDetail.Patient = f.Patient.Clone();
                feeDetail.Name = feeDetail.Item.Name;
                feeDetail.ID = feeDetail.Item.ID;
                feeDetail.RecipeOper = f.RecipeOper.Clone();
                feeDetail.Item.Price = price;
                feeDetail.Days = NConvert.ToDecimal(f.Days);
                feeDetail.FT.TotCost = totCost;
                feeDetail.Item.Qty = count;
                feeDetail.FeePack = f.FeePack;

                //自费如此，如果加上公费需要重新计算!!!
                feeDetail.FT.OwnCost = totCost;
                feeDetail.ExecOper = f.ExecOper.Clone();
                feeDetail.Item.PriceUnit = item.MinUnit == string.Empty ? "g" : item.MinUnit;
                if (item.IsMaterial)
                {
                    feeDetail.Item.IsNeedConfirm = true;
                }
                else
                {
                    feeDetail.Item.IsNeedConfirm = false;
                }
                feeDetail.Order = f.Order;
                feeDetail.UndrugComb.ID = f.Item.ID;
                feeDetail.UndrugComb.Name = f.Item.Name;
                feeDetail.Order.Combo.ID = f.Order.Combo.ID;
                feeDetail.Item.IsMaterial = f.Item.IsMaterial;
                feeDetail.RecipeSequence = f.RecipeSequence;
                feeDetail.FTSource = f.FTSource;
                feeDetail.FeePack = f.FeePack;
                feeDetail.IsNostrum = true;
                feeDetail.Invoice = f.Invoice;
                feeDetail.InvoiceCombNO = f.InvoiceCombNO;
                feeDetail.NoBackQty = feeDetail.Item.Qty;
                feeDetail.Order.Combo.ID = comboNO;
                //if (this.rInfo.Pact.PayKind.ID == "03")
                //{
                //    Neusoft.HISFC.Models.Base.PactItemRate pactRate = null;

                //    if (pactRate == null)
                //    {
                //        pactRate = this.pactUnitItemRateManager.GetOnepPactUnitItemRateByItem(this.rInfo.Pact.ID, feeDetail.Item.ID);
                //    }
                //    if (pactRate != null)
                //    {
                //        if (pactRate.Rate.PayRate != this.rInfo.Pact.Rate.PayRate)
                //        {
                //            if (pactRate.Rate.PayRate == 1)//自费
                //            {
                //                feeDetail.ItemRateFlag = "1";
                //            }
                //            else
                //            {
                //                feeDetail.ItemRateFlag = "3";
                //            }
                //        }
                //        else
                //        {
                //            feeDetail.ItemRateFlag = "2";

                //        }
                //        if (f.ItemRateFlag == "3")
                //        {
                //            feeDetail.OrgItemRate = f.OrgItemRate;
                //            feeDetail.NewItemRate = f.NewItemRate;
                //            feeDetail.ItemRateFlag = "2";
                //        }
                //    }
                //    else
                //    {
                //        if (f.ItemRateFlag == "3")
                //        {

                //            if (rowFindZT["ZF"].ToString() != "1")
                //            {
                //                feeDetail.OrgItemRate = f.OrgItemRate;
                //                feeDetail.NewItemRate = f.NewItemRate;
                //                feeDetail.ItemRateFlag = "2";
                //            }
                //        }
                //        else
                //        {
                //            feeDetail.OrgItemRate = f.OrgItemRate;
                //            feeDetail.NewItemRate = f.NewItemRate;
                //            feeDetail.ItemRateFlag = f.ItemRateFlag;
                //        }
                //    }
                //}

                alTemp.Add(feeDetail);
            }
            if (alTemp.Count > 0)
            {
                if (f.FT.RebateCost > 0)//有减免
                {
                    if (rInfo.Pact.PayKind.ID != "01")
                    {
                        errText = "暂时不允许非自费患者减免!";

                        return null;
                    }
                    //减免单独算
                    decimal rebateRate =
                        Neusoft.FrameWork.Public.String.FormatNumber(f.FT.RebateCost / f.FT.OwnCost, 2);
                    decimal tempFix = 0;
                    decimal tempRebateCost = 0;
                    foreach (FeeItemList feeTemp in alTemp)
                    {
                        feeTemp.FT.RebateCost = (feeTemp.FT.OwnCost) * rebateRate;
                        tempRebateCost += feeTemp.FT.RebateCost;
                    }
                    tempFix = f.FT.RebateCost - tempRebateCost;
                    FeeItemList fFix = alTemp[0] as FeeItemList;
                    fFix.FT.RebateCost = fFix.FT.RebateCost + tempFix;
                }
            }
            if (alTemp.Count > 0)
            {
                if (f.SpecialPrice > 0)//有特殊自费
                {
                    decimal tempPrice = 0m;
                    string id = string.Empty;
                    foreach (FeeItemList feeTemp in alTemp)
                    {
                        if (feeTemp.Item.Price > tempPrice)
                        {
                            id = feeTemp.Item.ID;
                            tempPrice = feeTemp.Item.Price;
                        }
                    }

                    foreach (FeeItemList fee in alTemp)
                    {
                        if (fee.Item.ID == id)
                        {
                            fee.SpecialPrice = f.SpecialPrice;

                            break;
                        }
                    }
                }
            }

            return alTemp;
        }

        /// <summary>
        /// 拆分协定处方
        /// </summary>
        /// <param name="feeItemLists"></param>
        /// <returns></returns>
        private int SplitNostrumDetail(Register rInfo, ref ArrayList  feeItemLists,ref ArrayList drugList, ref string errText)
        {
            ArrayList itemList = new ArrayList();
            foreach(FeeItemList f in feeItemLists)
            {
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    if (!f.IsConfirmed)
                    {
                        if (!f.Item.IsNeedConfirm)
                        {
                            drugList.Add(f);
                        }
                    }
                    if (f.IsNostrum)
                    {
                        ArrayList al = SplitNostrumDetail(rInfo, f, ref errText);
                        if (al == null)
                        {
                            return -1;
                        }
                        if (al.Count == 0)
                        {
                            errText = f.Item.Name + "是协定处方,但是没有维护明细或者明细已经停用！请与信息科联系！";
                            return -1;
                        }
                        itemList.AddRange(al);
                        continue;
                    }
                }
                itemList.Add(f);

            }
            feeItemLists.Clear();
            feeItemLists.AddRange(itemList);
            return 1;
        }

        /// <summary>
        /// 门诊收费函数
        /// </summary>
        /// <param name="type">收费,划价标志</param>
        /// <param name="r">患者挂号基本信息</param>
        /// <param name="invoices">发票主表集合</param>
        /// <param name="invoiceDetails">发票明细表集合</param>
        /// <param name="feeDetails">费用明细集合</param>
        /// <param name="t">Transcation</param>
        /// <param name="payModes">支付方式集合</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        public bool ClinicFee(Neusoft.HISFC.Models.Base.ChargeTypes type, Neusoft.HISFC.Models.Registration.Register r,
            ArrayList invoices, ArrayList invoiceDetails, ArrayList feeDetails, ArrayList invoiceFeeDetails, ArrayList payModes, ref string errText)
        {

            Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
            Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking();

            if (this.trans != null)
            {
                confirmIntegrate.SetTrans(this.trans);
                bookingIntegrate.SetTrans(this.trans);
            }

            invoiceType = controlParamIntegrate.GetControlParam<string>(Const.GET_INVOICE_NO_TYPE, false, "0");

            isDoseOnceCanNull = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DOSE_ONCE_NULL, false, true);

            //是否才分协定处方
            bool isSplitNostrum = controlParamIntegrate.GetControlParam<bool>(Const.Split_NostrumDetail, false, false);
            
            //获得收费时间
            DateTime feeTime = inpatientManager.GetDateTimeFromSysDateTime();

            //获得收费操作员
            string operID = inpatientManager.Operator.ID;

            Neusoft.HISFC.Models.Base.Employee employee = inpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;
            //返回值
            int iReturn = 0;
            //定义处方号
            string recipeNO = string.Empty;

            //如果是收费，获得发票信息
            if (type == Neusoft.HISFC.Models.Base.ChargeTypes.Fee)//收费
            {
                #region 收费流程
                //发票已经在预览界面分配完毕,直接插入就可以了.

                #region//获得发票序列,多张发票发票号不同,共享一个发票序列,通过发票序列号,可以查询一次收费的多张发票.

                string invoiceCombNO = outpatientManager.GetInvoiceCombNO();
                if (invoiceCombNO == null || invoiceCombNO == string.Empty)
                {
                    errText = "获得发票流水号失败!" + outpatientManager.Err;

                    return false;
                }

                string invoiceUnion = outpatientManager.GetSequence("Fee.OutPatient.InvoiceUnionID");

                if (string.IsNullOrEmpty(invoiceUnion))
                {
                    errText ="获取发票组号失败！"+outpatientManager.Err;
                    return false;
                }

                //获得特殊显示类别
                /////GetSpDisplayValue(myCtrl, t);
                //第一个发票号
                string mainInvoiceNO = string.Empty;
                string mainInvoiceCombNO = string.Empty;
                foreach (Balance balance in invoices)
                {
                    //主发票信息,不插入只做显示用
                    if (balance.Memo == "5")
                    {
                        mainInvoiceNO = balance.ID;

                        continue;
                    }

                    //自费患者不需要显示主发票,那么取第一个发票号作为主发票号
                    if (mainInvoiceNO == string.Empty)
                    {
                        mainInvoiceNO = balance.Invoice.ID;
                        mainInvoiceCombNO = balance.CombNO;
                    }
                    balance.InvoiceCombo = invoiceUnion;
                }

                #endregion

                #region //插入发票明细表

                foreach (ArrayList tempsInvoices in invoiceDetails)
                {
                    foreach (ArrayList tempDetals in tempsInvoices)
                    {
                        foreach (BalanceList balanceList in tempDetals)
                        {
                            //总发票处理
                            if (balanceList.Memo == "5")
                            {
                                continue;
                            }
                            if (string.IsNullOrEmpty(((Balance)balanceList.BalanceBase).CombNO))
                            {
                                ((Balance)balanceList.BalanceBase).CombNO = invoiceCombNO;
                            }
                            balanceList.BalanceBase.BalanceOper.ID = operID;
                            balanceList.BalanceBase.BalanceOper.OperTime = feeTime;
                            balanceList.BalanceBase.IsDayBalanced = false;
                            balanceList.BalanceBase.CancelType = CancelTypes.Valid;
                            balanceList.ID = balanceList.ID.PadLeft(12, '0');

                            //插入发票明细表 fin_opb_invoicedetail
                            iReturn = outpatientManager.InsertBalanceList(balanceList);
                            if (iReturn == -1)
                            {
                                errText = "插入发票明细出错!" + outpatientManager.Err;

                                return false;
                            }
                        }
                    }
                }

                #endregion

                #region 协定处方
                ArrayList noSplitDrugList = new ArrayList();
                if (isSplitNostrum)
                {

                    if (SplitNostrumDetail(r, ref feeDetails, ref noSplitDrugList, ref errText) < 0)
                    {
                        return false;
                    }
                }

                #endregion

                #region//药品信息列表,生成处方号

                ArrayList drugLists = new ArrayList();
                //重新生成处方号,如果已有处方号,明细不重新赋值.
                if (!this.SetRecipeNOOutpatient(r ,feeDetails, ref errText))
                {
                    return false;
                }

                #endregion

               


                #region//插入费用明细

                foreach (FeeItemList f in feeDetails)
                {
                    //验证数据
                    if (!this.IsFeeItemListDataValid(f, ref errText))
                    {
                        return false;
                    }

                    //如果没有处方号,重新赋值
                    if (f.RecipeNO == null || f.RecipeNO == string.Empty)
                    {
                        if (recipeNO == string.Empty)
                        {
                            recipeNO = outpatientManager.GetRecipeNO();
                            if (recipeNO == null || recipeNO == string.Empty)
                            {
                                errText = "获得处方号出错!";

                                return false;
                            }
                        }
                    }

                    #region 2007-8-29 liuq 判断是否已有发票号序号，没有则赋值
                    //{1A5CC61F-01F9-4dee-A6A8-580200C10EB4}
                    if (string.IsNullOrEmpty(f.InvoiceCombNO)|| f.InvoiceCombNO == "NULL")
                    {
                        f.InvoiceCombNO = invoiceCombNO;
                    }
                    #endregion
                    //
                    #region 2007-8-28 liuq 判断是否已有发票号，没有初始化为12个0
                    if (string.IsNullOrEmpty(f.Invoice.ID))
                    {
                        f.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                    }
                    #endregion
                    f.FeeOper.ID = operID;
                    f.FeeOper.OperTime = feeTime;
                    f.PayType = Neusoft.HISFC.Models.Base.PayTypes.Balanced;
                    f.TransType = TransTypes.Positive;
                    f.Patient.PID.CardNO = r.PID.CardNO;

                    //f.Patient = r.Clone();
                    ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.SeeDate = r.DoctorInfo.SeeDate;
                    if (((Register)f.Patient).DoctorInfo.Templet.Dept.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Dept.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Dept = r.DoctorInfo.Templet.Dept.Clone();
                    }
                    if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = r.DoctorInfo.Templet.Doct.Clone();
                    }
                    if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                    {
                        f.RecipeOper.Dept.ID = r.DoctorInfo.Templet.Doct.User01;
                    }

                    if (f.ChargeOper.OperTime == DateTime.MinValue)
                    {
                        f.ChargeOper.OperTime = feeTime;
                    }
                    if (f.ChargeOper.ID == null || f.ChargeOper.ID == string.Empty)
                    {
                        f.ChargeOper.ID = operID;
                    }
                    //if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    //{
                    //    errText = "请选择医生";

                    //    return false;
                    //}

                    if (f.RecipeOper.ID == null || f.RecipeOper.ID == string.Empty)
                    {
                        f.RecipeOper.ID = ((Register)f.Patient).DoctorInfo.Templet.Doct.ID;
                    }

                    f.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    f.FeeOper.ID = operID;
                    f.FeeOper.OperTime = feeTime;
                    f.ExamineFlag = r.ChkKind;

                    //如果患者为团体体检，那么所有项目都插入终端审核。
                    if (r.ChkKind == "2")
                    {
                        if (!f.IsConfirmed)
                        {
                            //如果项目流水号为空，说明没有经过划价流程，那么插入终端审核信息。
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                f.Order.ID = orderManager.GetNewOrderID();
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    errText = "获得医嘱流水号出错!";
                                    return false;
                                }

                                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                                {
                                    errText = "处理终端申请确认表失败!";

                                    return false;
                                }
                            }
                        }
                    }
                    else//其他患者如果项目为需要终端审核项目则插入终端审核信息。
                    {
                        if (!f.IsConfirmed)
                        {
                            if (f.Item.IsNeedConfirm)
                            {
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    f.Order.ID = orderManager.GetNewOrderID();
                                }
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    errText = "获得医嘱流水号出错!";

                                    return false;
                                }

                                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                                {
                                    errText = "处理终端申请确认表失败!" + confirmIntegrate.Err;

                                    return false;
                                }
                            }
                        }
                    }
                    //没有付值医嘱流水号,赋值新的医嘱流水号
                    if (f.Order.ID == null || f.Order.ID == string.Empty)
                    {
                        f.Order.ID = orderManager.GetNewOrderID();
                        if (f.Order.ID == null || f.Order.ID == string.Empty)
                        {
                            errText = "获得医嘱流水号出错!";

                            return false;
                        }
                    }

                    if (r.ChkKind == "1")//个人体检更新收费标记
                    {
                        iReturn = examiIntegrate.UpdateItemListFeeFlagByMoOrder("1", f.Order.ID);
                        if (iReturn == -1)
                        {
                            errText = "更新体检收费标记失败!" + examiIntegrate.Err;

                            return false;
                        }
                    }

                    //如果删除划价保存中的组合项目主项目信息,保留明细.
                    if (f.UndrugComb.ID != null && f.UndrugComb.ID.Length > 0)
                    {
                        iReturn = outpatientManager.DeletePackageByMoOrder(f.Order.ID);
                        if (iReturn == -1)
                        {
                            errText = "删除组套失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    //FeeItemList feeTemp = new FeeItemList();
                    //feeTemp = outpatientManager.GetFeeItemList(f.RecipeNO, f.SequenceNO);
                    //{39B2599D-2E90-4b3d-A027-4708A70E45C3}
                    int chargeItemCount = outpatientManager.GetChargeItemCount(f.RecipeNO, f.SequenceNO);
                    if (chargeItemCount == -1)
                    {
                        errText = "查询项目信息失败！";
                        return false;
                    }

                    if (chargeItemCount == 0)//说明不存在
                    {
                        if (f.FTSource != "0" && (f.UndrugComb.ID == null || f.UndrugComb.ID == string.Empty))
                        {
                            errText = f.Item.Name + "可能已经被其他操作员删除,请刷新后再收费!";

                            return false;
                        }

                        iReturn = outpatientManager.InsertFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "插入费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    else
                    {
                        iReturn = outpatientManager.UpdateFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "更新费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }

                    #region//回写医嘱信息

                    if (f.FTSource == "1")
                    {
                        iReturn = orderOutpatientManager.UpdateOrderChargedByOrderID(f.Order.ID, operID);
                        if (iReturn == -1)
                        {
                            errText = "更新医嘱信息出错!" + orderOutpatientManager.Err;

                            return false;
                        }
                    }

                    #endregion

                    //如果是药品,并且没有被确认过,而且不需要终端确认,那么加入发药申请列表.
                    //if (f.Item.IsPharmacy)
                    if (f.Item.ItemType == EnumItemType.Drug)
                    {
                        if (!f.IsConfirmed)
                        {
                            if (!f.Item.IsNeedConfirm)
                            {
                                drugLists.Add(f);
                            }
                        }
                    }
                    //需要医技预约,插入终端预约信息.
                    if (f.Item.IsNeedBespeak && r.ChkKind != "2")
                    {
                        iReturn = bookingIntegrate.Insert(f);

                        if (iReturn == -1)
                        {
                            errText = "插入医技预约信息出错!" + f.Name + bookingIntegrate.Err;

                            return false;
                        }
                    }

                }

                #endregion

                #region 集体体检更新收费标记

                if (r.ChkKind == "2")//集体体检
                {
                    ArrayList recipeSeqList = this.GetRecipeSequenceForChk(feeDetails);
                    if (recipeSeqList != null && recipeSeqList.Count > 0)
                    {
                        foreach (string recipeSequenceTemp in recipeSeqList)
                        {
                            iReturn = examiIntegrate.UpdateItemListFeeFlagByRecipeSeq("1", recipeSequenceTemp);
                            if (iReturn == -1)
                            {
                                errText = "更新体检收费标记失败!" + examiIntegrate.Err;

                                return false;
                            }

                        }
                    }
                }

                #endregion

                #region//发药窗口信息

                string drugSendInfo = null;

                if (isSplitNostrum)
                {
                    drugLists.Clear();
                    foreach (FeeItemList item in noSplitDrugList)
                    {
                        foreach (FeeItemList f in feeDetails)
                        {
                            if (item.Order.ID == f.Order.ID)
                            {
                                item.RecipeNO = f.RecipeNO;
                                item.FeeOper = f.FeeOper;
                                break;
                            }
                        }
                    }
                    drugLists.AddRange(noSplitDrugList);
                }

                //插入发药申请信息,返回发药窗口,显示在发票上
                iReturn = pharmarcyManager.ApplyOut(r, drugLists, string.Empty, feeTime, false, out drugSendInfo);
                if (iReturn == -1)
                {
                    errText = "处理药品明细失败!" + pharmarcyManager.Err;

                    return false;
                }

                //'如果有药品,那么设置发票的显示发药窗口信息.
                if (drugLists.Count > 0)
                {
                    //{02F6E9D7-E311-49a4-8FE4-BF2AC88B889B}屏蔽掉小版本代码，采用核心版本的代码
                    //foreach (Balance invoice in invoices)
                    //{
                    //    invoice.DrugWindowsNO = drugSendInfo;
                    //}
                    foreach (Balance invoice in invoices)
                    {
                        string tempInvoiceNo = string.Empty;
                        for (int i = 0; i < drugLists.Count; i++)
                        {
                            Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList oneFeeItem = new FeeItemList();
                            oneFeeItem = drugLists[i] as Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList;
                            //if (oneFeeItem.Item.IsPharmacy)
                            if (oneFeeItem.Item.ItemType == EnumItemType.Drug)
                            {
                                tempInvoiceNo = oneFeeItem.Invoice.ID;
                            }
                            if (invoice.Invoice.ID == tempInvoiceNo)
                            {
                                invoice.DrugWindowsNO = drugSendInfo;
                            }
                        }
                    }
                }

                #region//插入发票主表

                foreach (Balance balance in invoices)
                {
                    //主发票信息,不插入只做显示用
                    if (balance.Memo == "5")
                    {
                        mainInvoiceNO = balance.ID;

                        continue;
                    }
                    if (string.IsNullOrEmpty(balance.CombNO))
                    {
                        balance.CombNO = invoiceCombNO;
                    }
                    balance.BalanceOper.ID = operID;
                    balance.BalanceOper.OperTime = feeTime;
                    balance.Patient.Pact = r.Pact;
                    //体检标志
                    string tempExamineFlag = null;
                    //获得体检标志 0 普通患者 1 个人体检 2 团体体检
                    //如果没有赋值,默认为普通患者
                    if (r.ChkKind.Length > 0)
                    {
                        tempExamineFlag = r.ChkKind;
                    }
                    else
                    {
                        tempExamineFlag = "0";
                    }
                    balance.ExamineFlag = tempExamineFlag;
                    balance.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;

                    //=====去掉CanceledInvoiceNO=string.Empty 路志鹏================
                    //balance.CanceledInvoiceNO = string.Empty;
                    //==============================================================

                    balance.IsAuditing = false;
                    balance.IsDayBalanced = false;
                    balance.ID = balance.ID.PadLeft(12, '0');
                    balance.Patient.Pact.Memo = r.User03;//限额代码
                    //自费患者不需要显示主发票,那么取第一个发票号作为主发票号
                    if (mainInvoiceNO == string.Empty)
                    {
                        mainInvoiceNO = balance.Invoice.ID;
                    }
                    if (invoiceType == "0")
                    {
                        string tmpCount = outpatientManager.QueryExistInvoiceCount(balance.Invoice.ID);
                        if (tmpCount == "1")
                        {
                            DialogResult result = MessageBox.Show("已经存在发票号为: " + balance.Invoice.ID +
                                " 的发票!,是否继续?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.No)
                            {
                                errText = "因发票号重复暂时取消本次结算!";

                                return false;
                            }
                        }
                    }
                    else if (invoiceType == "1")
                    {
                        string tmpCount = outpatientManager.QueryExistInvoiceCount(balance.PrintedInvoiceNO);
                        if (tmpCount == "1")
                        {
                            DialogResult result = MessageBox.Show("已经存在票据号为: " + balance.PrintedInvoiceNO +
                                " 的发票!,是否继续?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.No)
                            {
                                errText = "因发票号重复暂时取消本次结算!";

                                return false;
                            }
                        }
                    }
                    //插入发票主表fin_opb_invoice
                    iReturn = outpatientManager.InsertBalance(balance);
                    if (iReturn == -1)
                    {
                        errText = "插入结算表出错!" + outpatientManager.Err;

                        return false;
                    }
                }

                string invoiceNo = ((Balance)invoices[invoices.Count - 1]).Invoice.ID;
                string realInvoiceNo = ((Balance)invoices[invoices.Count - 1]).PrintedInvoiceNO;

                if (invoiceType == "2")
                {
                    for (int i = 0; i < invoices.Count; i++)
                    {
                        if (this.isNeedUpdateInvoiceNO)
                        {
                            iReturn = this.UpdateInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                            if (iReturn == -1)
                            {
                                this.Err = errText;

                                return false;
                            }
                        }
                        else
                        {
                            iReturn = this.UpdateOnlyRealInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                            if (iReturn == -1)
                            {
                                this.Err = errText;

                                return false;
                            }
                        }
                    }
                }
                else
                {
                    iReturn = this.UpdateInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                    if (iReturn == -1)
                    {
                        this.Err = errText;

                        return false;
                    }
                }

                #endregion

                #endregion

                #region 插入支付方式信息

                int payModeSeq = 1;

                foreach (BalancePay p in payModes)
                {
                    p.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                    p.TransType = TransTypes.Positive;
                    p.Squence = payModeSeq.ToString();
                    p.IsDayBalanced = false;
                    p.IsAuditing = false;
                    p.IsChecked = false;
                    p.InputOper.ID = operID;
                    p.InputOper.OperTime = feeTime;
                    p.InvoiceUnion = invoiceUnion;
                    if (string.IsNullOrEmpty(p.InvoiceCombNO))
                    {
                        //p.InvoiceCombNO = mainInvoiceCombNO;
                        if (string.IsNullOrEmpty(mainInvoiceCombNO))
                        {
                            p.InvoiceCombNO = invoiceCombNO;
                        }
                        else
                        {
                            p.InvoiceCombNO = mainInvoiceCombNO;
                        }
                    }
                    p.CancelType = CancelTypes.Valid;

                    payModeSeq++;

                    //realCost += p.FT.RealCost;

                    iReturn = outpatientManager.InsertBalancePay(p);
                    if (iReturn == -1)
                    {
                        errText = "插入支付方式表出错!" + outpatientManager.Err;

                        return false;
                    }

                    //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
                    //if (p.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.YS.ToString())
                    if (p.PayType.ID.ToString() == "YS")
                    {
                        //bool returnValue = this.AccountPay(r.PID.CardNO, p.FT.TotCost, p.Invoice.ID, p.InputOper.Dept.ID);

                        

                        //if (!returnValue)
                        //{
                        //    errText = "扣取门诊账户失败!" + "\n" + this.Err;

                        //    return false;
                        //}
                        //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
                        int returnValue = this.AccountPay(r, p.FT.TotCost, p.Invoice.ID, (accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID, "C");
                        if (returnValue < 0)
                        {
                            errText = "扣取门诊账户失败!" + "\n" + this.Err;

                            return false;
                        }
                        //if (returnValue == 0)
                        //{
                        //    errText = "取消帐户支付!";
                        //    return false;
                        //}
                    }
                }
                #endregion

                #region//如果不是直接收费患者和体检患者，更新看诊标志

                string noRegRules = controlParamIntegrate.GetControlParam(Const.NO_REG_CARD_RULES, false, "9");

                if (r.PID.CardNO.Substring(0, 1) != noRegRules && r.ChkKind.Length == 0)
                {
                    //更新看诊标志
                    iReturn = registerManager.UpdateSeeDone(r.ID);

                    if (iReturn <= 0)
                    {
                        errText = "更新看诊标志出错!" + registerManager.Err;

                        return false;
                    }
                }
                //输入姓名患者收费,那么插入挂号信息,如果已经插入过,那么忽略.
                if (r.PID.CardNO.Substring(0, 1) == noRegRules)
                {
                    r.InputOper.OperTime = DateTime.MinValue;
                    r.InputOper.ID = operID;
                    r.IsFee = true;
                    r.TranType = TransTypes.Positive;
                    iReturn = registerManager.Insert(r);
                    if (iReturn == -1)
                    {
                        if (registerManager.DBErrCode != 1)//不是主键重复
                        {
                            errText = "插入挂号信息出错!" + registerManager.Err;

                            return false;
                        }
                    }
                }
                //如果是医保患者,更新本地医保结算信息表 fin_ipr_siinmaininfo
                if (r.Pact.PayKind.ID == "02")
                {
                    //设置已结算标志
                    r.SIMainInfo.IsBalanced = true;
                    // iReturn = interfaceManager.update(r);
                    //{8F40C4C6-F331-4925-B96E-7C3D5444611C}
                    //if (iReturn < 0)
                    //{
                    //    errText = "更新医保患者结算信息出错!" + interfaceManager.Err;
                    //    return false;
                    //}
                    //{8F40C4C6-F331-4925-B96E-7C3D5444611C}
                }

                #endregion

                #region//发票打印
                //变更2007-12-30liuq
                //string invoicePrintDll = null;

                //invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Const.INVOICEPRINT, false, string.Empty);

                //if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                //{
                //    MessageBox.Show("没有设置发票打印参数，收费请维护!");

                //    return false;
                //}

                //iReturn = PrintInvoice(invoicePrintDll, r, invoices, invoiceDetails, feeDetails, invoiceFeeDetails, payModes, false, ref errText);
                //if (iReturn == -1)
                //{
                //    return false;
                //}

                #endregion

                #endregion
            }
            else//划价
            {
                #region 划价流程

                string noRegRules = controlParamIntegrate.GetControlParam<string>(Const.NO_REG_CARD_RULES, false, "9");
                if (r.PID.CardNO.Substring(0, 1) == noRegRules)
                {
                    r.InputOper.OperTime = DateTime.MinValue;
                    r.InputOper.ID = outpatientManager.Operator.ID;
                    r.IsFee = true;
                    r.TranType = TransTypes.Positive;
                    iReturn = registerManager.Insert(r);
                    if (iReturn == -1)
                    {
                        if (registerManager.DBErrCode != 1)//不是主键重复
                        {
                            errText = "插入挂号信息出错!" + registerManager.Err;

                            return false;
                        }
                    }
                }
                //处理划价保存信息.
                bool returnValue = this.SetChargeInfo(r, feeDetails, feeTime, ref errText);
                if (!returnValue)
                {
                    return false;
                }

                #endregion
            }

            return true;
        }


        /// <summary>
        /// 门诊收费函数
        /// </summary>
        /// <param name="type">收费,划价标志</param>
        /// <param name="r">患者挂号基本信息</param>
        /// <param name="invoices">发票主表集合</param>
        /// <param name="invoiceDetails">发票明细表集合</param>
        /// <param name="feeDetails">费用明细集合</param>
        /// <param name="t">Transcation</param>
        /// <param name="payModes">支付方式集合</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        public bool ClinicFeeSaveFee(Neusoft.HISFC.Models.Base.ChargeTypes type, Neusoft.HISFC.Models.Registration.Register r,
            ArrayList invoices, ArrayList invoiceDetails, ArrayList feeDetails, ArrayList invoiceFeeDetails, ArrayList payModes, ref string errText)
        {

            Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
            Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking();

            if (this.trans != null)
            {
                confirmIntegrate.SetTrans(this.trans);
                bookingIntegrate.SetTrans(this.trans);
            }

            invoiceType = controlParamIntegrate.GetControlParam<string>(Const.GET_INVOICE_NO_TYPE, false, "0");

            isDoseOnceCanNull = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.DOSE_ONCE_NULL, false, true);

            //获得收费时间
            DateTime feeTime = inpatientManager.GetDateTimeFromSysDateTime();

            //获得收费操作员
            string operID = inpatientManager.Operator.ID;

            Neusoft.HISFC.Models.Base.Employee employee = inpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee;
            //返回值
            int iReturn = 0;
            //定义处方号
            string recipeNO = string.Empty;

            //如果是收费，获得发票信息
            if (type == Neusoft.HISFC.Models.Base.ChargeTypes.Fee)//收费
            {
                #region 收费流程
                //发票已经在预览界面分配完毕,直接插入就可以了.

                #region//获得发票序列,多张发票发票号不同,共享一个发票序列,通过发票序列号,可以查询一次收费的多张发票.

                string invoiceCombNO = outpatientManager.GetInvoiceCombNO();
                if (invoiceCombNO == null || invoiceCombNO == string.Empty)
                {
                    errText = "获得发票流水号失败!" + outpatientManager.Err;

                    return false;
                }
                //获得特殊显示类别
                /////GetSpDisplayValue(myCtrl, t);
                //第一个发票号
                string mainInvoiceNO = string.Empty;
                string mainInvoiceCombNO = string.Empty;
                foreach (Balance balance in invoices)
                {
                    //主发票信息,不插入只做显示用
                    if (balance.Memo == "5")
                    {
                        mainInvoiceNO = balance.ID;

                        continue;
                    }

                    //自费患者不需要显示主发票,那么取第一个发票号作为主发票号
                    if (mainInvoiceNO == string.Empty)
                    {
                        mainInvoiceNO = balance.Invoice.ID;
                        mainInvoiceCombNO = balance.CombNO;
                    }
                }

                #endregion

                #region //插入发票明细表

                foreach (ArrayList tempsInvoices in invoiceDetails)
                {
                    foreach (ArrayList tempDetals in tempsInvoices)
                    {
                        foreach (BalanceList balanceList in tempDetals)
                        {
                            //总发票处理
                            if (balanceList.Memo == "5")
                            {
                                continue;
                            }
                            if (string.IsNullOrEmpty(((Balance)balanceList.BalanceBase).CombNO))
                            {
                                ((Balance)balanceList.BalanceBase).CombNO = invoiceCombNO;
                            }
                            balanceList.BalanceBase.BalanceOper.ID = operID;
                            balanceList.BalanceBase.BalanceOper.OperTime = feeTime;
                            balanceList.BalanceBase.IsDayBalanced = false;
                            balanceList.BalanceBase.CancelType = CancelTypes.Valid;
                            balanceList.ID = balanceList.ID.PadLeft(12, '0');

                            //插入发票明细表 fin_opb_invoicedetail
                            iReturn = outpatientManager.InsertBalanceList(balanceList);
                            if (iReturn == -1)
                            {
                                errText = "插入发票明细出错!" + outpatientManager.Err;

                                return false;
                            }
                        }
                    }
                }

                #endregion

                #region//药品信息列表,生成处方号

                ArrayList drugLists = new ArrayList();
                //重新生成处方号,如果已有处方号,明细不重新赋值.
                if (!this.SetRecipeNOOutpatient(r,feeDetails, ref errText))
                {
                    return false;
                }

                #endregion

                #region//插入费用明细

                foreach (FeeItemList f in feeDetails)
                {
                    //验证数据
                    if (!this.IsFeeItemListDataValid(f, ref errText))
                    {
                        return false;
                    }

                    //如果没有处方号,重新赋值
                    if (f.RecipeNO == null || f.RecipeNO == string.Empty)
                    {
                        if (recipeNO == string.Empty)
                        {
                            recipeNO = outpatientManager.GetRecipeNO();
                            if (recipeNO == null || recipeNO == string.Empty)
                            {
                                errText = "获得处方号出错!";

                                return false;
                            }
                        }
                    }

                    #region 2007-8-29 liuq 判断是否已有发票号序号，没有则赋值
                    if (string.IsNullOrEmpty(f.InvoiceCombNO))
                    {
                        f.InvoiceCombNO = invoiceCombNO;
                    }
                    #endregion
                    //
                    #region 2007-8-28 liuq 判断是否已有发票号，没有初始化为12个0
                    if (string.IsNullOrEmpty(f.Invoice.ID))
                    {
                        f.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                    }
                    #endregion
                    f.FeeOper.ID = operID;
                    f.FeeOper.OperTime = feeTime;
                    f.PayType = Neusoft.HISFC.Models.Base.PayTypes.Balanced;
                    f.TransType = TransTypes.Positive;
                    f.Patient.PID.CardNO = r.PID.CardNO;
                    //f.Patient = r.Clone();
                    ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.SeeDate = r.DoctorInfo.SeeDate;
                    if (((Register)f.Patient).DoctorInfo.Templet.Dept.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Dept.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Dept = r.DoctorInfo.Templet.Dept.Clone();
                    }
                    if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = r.DoctorInfo.Templet.Doct.Clone();
                    }
                    if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                    {
                        f.RecipeOper.Dept.ID = r.DoctorInfo.Templet.Doct.User01;
                    }

                    if (f.ChargeOper.OperTime == DateTime.MinValue)
                    {
                        f.ChargeOper.OperTime = feeTime;
                    }
                    if (f.ChargeOper.ID == null || f.ChargeOper.ID == string.Empty)
                    {
                        f.ChargeOper.ID = operID;
                    }
                    //if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    //{
                    //    errText = "请选择医生";

                    //    return false;
                    //}

                    if (f.RecipeOper.ID == null || f.RecipeOper.ID == string.Empty)
                    {
                        f.RecipeOper.ID = ((Register)f.Patient).DoctorInfo.Templet.Doct.ID;
                    }

                    f.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    f.FeeOper.ID = operID;
                    f.FeeOper.OperTime = feeTime;
                    f.ExamineFlag = r.ChkKind;

                    //如果患者为团体体检，那么所有项目都插入终端审核。
                    if (r.ChkKind == "2")
                    {
                        if (!f.IsConfirmed)
                        {
                            //如果项目流水号为空，说明没有经过划价流程，那么插入终端审核信息。
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                f.Order.ID = orderManager.GetNewOrderID();
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    errText = "获得医嘱流水号出错!";
                                    return false;
                                }

                                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                                {
                                    errText = "处理终端申请确认表失败!";

                                    return false;
                                }
                            }
                        }
                    }
                    else//其他患者如果项目为需要终端审核项目则插入终端审核信息。
                    {
                        if (!f.IsConfirmed)
                        {
                            if (f.Item.IsNeedConfirm)
                            {
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    f.Order.ID = orderManager.GetNewOrderID();
                                }
                                if (f.Order.ID == null || f.Order.ID == string.Empty)
                                {
                                    errText = "获得医嘱流水号出错!";

                                    return false;
                                }

                                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                                {
                                    errText = "处理终端申请确认表失败!" + confirmIntegrate.Err;

                                    return false;
                                }
                            }
                        }
                    }
                    //没有付值医嘱流水号,赋值新的医嘱流水号
                    if (f.Order.ID == null || f.Order.ID == string.Empty)
                    {
                        f.Order.ID = orderManager.GetNewOrderID();
                        if (f.Order.ID == null || f.Order.ID == string.Empty)
                        {
                            errText = "获得医嘱流水号出错!";

                            return false;
                        }
                    }

                    if (r.ChkKind == "1")//个人体检更新收费标记
                    {
                        iReturn = examiIntegrate.UpdateItemListFeeFlagByMoOrder("1", f.Order.ID);
                        if (iReturn == -1)
                        {
                            errText = "更新体检收费标记失败!" + examiIntegrate.Err;

                            return false;
                        }
                    }

                    //如果删除划价保存中的组合项目主项目信息,保留明细.
                    if (f.UndrugComb.ID != null && f.UndrugComb.ID.Length > 0)
                    {
                        iReturn = outpatientManager.DeletePackageByMoOrder(f.Order.ID);
                        if (iReturn == -1)
                        {
                            errText = "删除组套失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    FeeItemList feeTemp = new FeeItemList();
                    feeTemp = outpatientManager.GetFeeItemList(f.RecipeNO, f.SequenceNO);
                    if (feeTemp == null)//说明不存在
                    {
                        if (f.FTSource != "0" && (f.UndrugComb.ID == null || f.UndrugComb.ID == string.Empty))
                        {
                            errText = f.Item.Name + "可能已经被其他操作员删除,请刷新后再收费!";

                            return false;
                        }

                        iReturn = outpatientManager.InsertFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "插入费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    else
                    {
                        iReturn = outpatientManager.UpdateFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "更新费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }

                    #region//回写医嘱信息

                    if (f.FTSource == "1")
                    {
                        iReturn = orderOutpatientManager.UpdateOrderChargedByOrderID(f.Order.ID, operID);
                        if (iReturn == -1)
                        {
                            errText = "更新医嘱信息出错!" + orderOutpatientManager.Err;

                            return false;
                        }
                    }

                    #endregion

                    //如果是药品,并且没有被确认过,而且不需要终端确认,那么加入发药申请列表.
                    //if (f.Item.IsPharmacy)
                    if (f.Item.ItemType == EnumItemType.Drug)
                    {
                        if (!f.IsConfirmed)
                        {
                            if (!f.Item.IsNeedConfirm)
                            {
                                drugLists.Add(f);
                            }
                        }
                    }
                    //需要医技预约,插入终端预约信息.
                    if (f.Item.IsNeedBespeak && r.ChkKind != "2")
                    {
                        iReturn = bookingIntegrate.Insert(f);

                        if (iReturn == -1)
                        {
                            errText = "插入医技预约信息出错!" + f.Name + bookingIntegrate.Err;

                            return false;
                        }
                    }

                }

                #endregion

                #region 集体体检更新收费标记

                if (r.ChkKind == "2")//集体体检
                {
                    ArrayList recipeSeqList = this.GetRecipeSequenceForChk(feeDetails);
                    if (recipeSeqList != null && recipeSeqList.Count > 0)
                    {
                        foreach (string recipeSequenceTemp in recipeSeqList)
                        {
                            iReturn = examiIntegrate.UpdateItemListFeeFlagByRecipeSeq("1", recipeSequenceTemp);
                            if (iReturn == -1)
                            {
                                errText = "更新体检收费标记失败!" + examiIntegrate.Err;

                                return false;
                            }

                        }
                    }
                }

                #endregion

                #region//发药窗口信息

                string drugSendInfo = null;
                //插入发药申请信息,返回发药窗口,显示在发票上
                iReturn = pharmarcyManager.ApplyOut(r, drugLists, string.Empty, feeTime, false, out drugSendInfo);
                if (iReturn == -1)
                {
                    errText = "处理药品明细失败!" + pharmarcyManager.Err;

                    return false;
                }
                //如果有药品,那么设置发票的显示发药窗口信息.
                if (drugLists.Count > 0)
                {
                    foreach (Balance invoice in invoices)
                    {
                        invoice.DrugWindowsNO = drugSendInfo;
                    }
                }

                #region//插入发票主表

                foreach (Balance balance in invoices)
                {
                    //主发票信息,不插入只做显示用
                    if (balance.Memo == "5")
                    {
                        mainInvoiceNO = balance.ID;

                        continue;
                    }
                    if (string.IsNullOrEmpty(balance.CombNO))
                    {
                        balance.CombNO = invoiceCombNO;
                    }
                    balance.BalanceOper.ID = operID;
                    balance.BalanceOper.OperTime = feeTime;
                    balance.Patient.Pact = r.Pact;
                    //体检标志
                    string tempExamineFlag = null;
                    //获得体检标志 0 普通患者 1 个人体检 2 团体体检
                    //如果没有赋值,默认为普通患者
                    if (r.ChkKind.Length > 0)
                    {
                        tempExamineFlag = r.ChkKind;
                    }
                    else
                    {
                        tempExamineFlag = "0";
                    }
                    balance.ExamineFlag = tempExamineFlag;
                    balance.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;

                    //=====去掉CanceledInvoiceNO=string.Empty 路志鹏================
                    //balance.CanceledInvoiceNO = string.Empty;
                    //==============================================================

                    balance.IsAuditing = false;
                    balance.IsDayBalanced = false;
                    balance.ID = balance.ID.PadLeft(12, '0');
                    balance.Patient.Pact.Memo = r.User03;//限额代码
                    //自费患者不需要显示主发票,那么取第一个发票号作为主发票号
                    if (mainInvoiceNO == string.Empty)
                    {
                        mainInvoiceNO = balance.Invoice.ID;
                    }
                    if (invoiceType == "0")
                    {
                        string tmpCount = outpatientManager.QueryExistInvoiceCount(balance.Invoice.ID);
                        if (tmpCount == "1")
                        {
                            DialogResult result = MessageBox.Show("已经存在发票号为: " + balance.Invoice.ID +
                                " 的发票!,是否继续?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.No)
                            {
                                errText = "因发票号重复暂时取消本次结算!";

                                return false;
                            }
                        }
                    }
                    else if (invoiceType == "1")
                    {
                        string tmpCount = outpatientManager.QueryExistInvoiceCount(balance.PrintedInvoiceNO);
                        if (tmpCount == "1")
                        {
                            DialogResult result = MessageBox.Show("已经存在票据号为: " + balance.PrintedInvoiceNO +
                                " 的发票!,是否继续?", "提示!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.No)
                            {
                                errText = "因发票号重复暂时取消本次结算!";

                                return false;
                            }
                        }
                    }
                    //插入发票主表fin_opb_invoice
                    iReturn = outpatientManager.InsertBalance(balance);
                    if (iReturn == -1)
                    {
                        errText = "插入结算表出错!" + outpatientManager.Err;

                        return false;
                    }
                }

                string invoiceNo = ((Balance)invoices[invoices.Count - 1]).Invoice.ID;
                string realInvoiceNo = ((Balance)invoices[invoices.Count - 1]).PrintedInvoiceNO;

                if (invoiceType == "2")
                {
                    for (int i = 0; i < invoices.Count; i++)
                    {
                        if (this.isNeedUpdateInvoiceNO)
                        {
                            iReturn = this.UpdateInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                            if (iReturn == -1)
                            {
                                this.Err = errText;

                                return false;
                            }
                        }
                        else
                        {
                            iReturn = this.UpdateOnlyRealInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                            if (iReturn == -1)
                            {
                                this.Err = errText;

                                return false;
                            }
                        }
                    }
                }
                else
                {
                    iReturn = this.UpdateInvoiceNO(invoiceNo, realInvoiceNo, ref errText);
                    if (iReturn == -1)
                    {
                        this.Err = errText;

                        return false;
                    }
                }

                #endregion

                #endregion

                #region 插入支付方式信息

                //int payModeSeq = 1;

                //foreach (BalancePay p in payModes)
                //{
                //    p.Invoice.ID = mainInvoiceNO.PadLeft(12, '0');
                //    p.TransType = TransTypes.Positive;
                //    p.Squence = payModeSeq.ToString();
                //    p.IsDayBalanced = false;
                //    p.IsAuditing = false;
                //    p.IsChecked = false;
                //    p.InputOper.ID = operID;
                //    p.InputOper.OperTime = feeTime;
                //    if (string.IsNullOrEmpty(p.InvoiceCombNO))
                //    {
                //        p.InvoiceCombNO = mainInvoiceCombNO;
                //    }
                //    p.CancelType = CancelTypes.Valid;

                //    payModeSeq++;

                //    //realCost += p.FT.RealCost;

                //    iReturn = outpatientManager.InsertBalancePay(p);
                //    if (iReturn == -1)
                //    {
                //        errText = "插入支付方式表出错!" + outpatientManager.Err;

                //        return false;
                //    }

                //    if (p.PayType.ID.ToString() == Neusoft.HISFC.Models.Fee.EnumPayType.YS.ToString())
                //    {
                //        bool returnValue = this.AccountPay(r.PID.CardNO, p.FT.TotCost, p.Invoice.ID, p.InputOper.Dept.ID);
                //        if (!returnValue)
                //        {
                //            errText = "扣取门诊账户失败!" + "\n" + this.Err;

                //            return false;
                //        }
                //    }
                //}
                #endregion

                #region//如果不是直接收费患者和体检患者，更新看诊标志

                string noRegRules = controlParamIntegrate.GetControlParam(Const.NO_REG_CARD_RULES, false, "9");

                if (r.PID.CardNO.Substring(0, 1) != noRegRules && r.ChkKind.Length == 0)
                {
                    //更新看诊标志
                    iReturn = registerManager.UpdateSeeDone(r.ID);

                    if (iReturn <= 0)
                    {
                        errText = "更新看诊标志出错!" + registerManager.Err;

                        return false;
                    }
                }
                //输入姓名患者收费,那么插入挂号信息,如果已经插入过,那么忽略.
                if (r.PID.CardNO.Substring(0, 1) == noRegRules)
                {
                    r.InputOper.OperTime = DateTime.MinValue;
                    r.InputOper.ID = operID;
                    r.IsFee = true;
                    r.TranType = TransTypes.Positive;
                    iReturn = registerManager.Insert(r);
                    if (iReturn == -1)
                    {
                        if (registerManager.DBErrCode != 1)//不是主键重复
                        {
                            errText = "插入挂号信息出错!" + registerManager.Err;

                            return false;
                        }
                    }
                }
                ////如果是医保患者,更新本地医保结算信息表 fin_ipr_siinmaininfo
                //if (r.Pact.PayKind.ID == "02")
                //{
                //    //设置已结算标志
                //    r.SIMainInfo.IsBalanced = true;
                //    // iReturn = interfaceManager.update(r);
                //    if (iReturn < 0)
                //    {
                //        errText = "更新医保患者结算信息出错!" + interfaceManager.Err;
                //        return false;
                //    }
                //}

                #endregion

                #region 发票打印

                //string invoicePrintDll = null;

                //invoicePrintDll = controlParamIntegrate.GetControlParam<string>(Const.INVOICEPRINT, false, string.Empty);

                //if (invoicePrintDll == null || invoicePrintDll == string.Empty)
                //{
                //    MessageBox.Show("没有设置发票打印参数，收费请维护!");

                //    return false;
                //}

                //iReturn = PrintInvoice(invoicePrintDll, r, invoices, invoiceDetails, feeDetails, invoiceFeeDetails, payModes, false, ref errText);
                //if (iReturn == -1)
                //{
                //    return false;
                //}

                #endregion

                #endregion
            }
            else//划价
            {
                #region 划价流程

                string noRegRules = controlParamIntegrate.GetControlParam<string>(Const.NO_REG_CARD_RULES, false, "9");
                if (r.PID.CardNO.Substring(0, 1) == noRegRules)
                {
                    r.InputOper.OperTime = DateTime.MinValue;
                    r.InputOper.ID = outpatientManager.Operator.ID;
                    r.IsFee = true;
                    r.TranType = TransTypes.Positive;
                    iReturn = registerManager.Insert(r);
                    if (iReturn == -1)
                    {
                        if (registerManager.DBErrCode != 1)//不是主键重复
                        {
                            errText = "插入挂号信息出错!" + registerManager.Err;

                            return false;
                        }
                    }
                }
                //处理划价保存信息.
                bool returnValue = this.SetChargeInfo(r, feeDetails, feeTime, ref errText);
                if (!returnValue)
                {
                    return false;
                }

                #endregion
            }

            //处理适应症{E4C0E5CF-D93F-48f9-A53C-9ADCCED97A7E}
            Neusoft.HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessOutPatient iAdptIllnessOutPatient = null;
            iAdptIllnessOutPatient = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessOutPatient)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessOutPatient;
            if (iAdptIllnessOutPatient != null)
            {
                //保存适应症信息
                int returnValue = iAdptIllnessOutPatient.SaveOutPatientFeeDetail(r, ref feeDetails);
                if (returnValue < 0)
                {
                    return false;
                }

            }

            return true;
        }


        /// <summary>
        /// 插入或者更新划价信息
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="feeItemLists">费用信息</param>
        /// <param name="chargeTime">收费时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns>true成功 false 失败</returns>
        public bool SetChargeInfo(Register r, ArrayList feeItemLists, DateTime chargeTime, ref string errText)
        {
            bool returnValue = false;
            int iReturn = 0;
            string recipeSeq = null;//收费序列

            recipeSeq = outpatientManager.GetRecipeSequence();
            if (recipeSeq == null || recipeSeq == string.Empty)
            {
                errText = "获得收费序列号出错!";

                return false;
            }

            //设置处方号
            returnValue = this.SetRecipeNOOutpatient(r,feeItemLists, ref errText);
            if (!returnValue)
            {
                return false;
            }

            foreach (FeeItemList f in feeItemLists)
            {
                //验证数据合法性
                if (!this.IsFeeItemListDataValid(f, ref errText))
                {
                    return false;
                }
                //划价保存
                f.ChargeOper.ID = outpatientManager.Operator.ID;
                f.ChargeOper.OperTime = chargeTime;
                f.Patient = r.Clone();

                f.Patient.PID.CardNO = r.PID.CardNO;

                ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.SeeDate = r.DoctorInfo.SeeDate;
                if (((Register)f.Patient).DoctorInfo.Templet.Dept.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Dept.ID == string.Empty)
                {
                    ((Register)f.Patient).DoctorInfo.Templet.Dept = r.DoctorInfo.Templet.Dept.Clone();
                }
                if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                {
                    ((Register)f.Patient).DoctorInfo.Templet.Doct = r.DoctorInfo.Templet.Doct.Clone();
                }
                if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                {
                    f.RecipeOper.Dept.ID = r.User01;
                }

                f.PayType = PayTypes.Charged;
                f.TransType = TransTypes.Positive;
                f.NoBackQty = f.Item.Qty;
                f.ExamineFlag = r.ChkKind;
                if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                {
                    f.RecipeOper.Dept.ID = r.User01;
                }
                if (f.Order.ID == null || f.Order.ID == string.Empty)//没有付值医嘱流水号
                {
                    f.Order.ID = orderManager.GetNewOrderID();
                    if (f.Order.ID == null || f.Order.ID == string.Empty)
                    {
                        errText = "获得医嘱流水号出错!";

                        return false;
                    }
                }
                if (f.RecipeSequence == null || f.RecipeSequence == string.Empty)
                {
                    f.RecipeSequence = recipeSeq;
                }
                if (f.InvoiceCombNO == null || f.InvoiceCombNO == string.Empty)
                {
                    f.InvoiceCombNO = "NULL";
                }

                iReturn = outpatientManager.InsertFeeItemList(f);

                #region 集体体检,在体检划价时已经处理,这里屏蔽
                //if (r.ChkKind == "2")//团体体检
                //{

                //    Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = new Neusoft.HISFC.Models.Terminal.TerminalApply();
                //    terminalApply.Item = f;
                //    terminalApply.Patient = r;
                //    terminalApply.InsertOperEnvironment.OperTime = chargeTime;
                //    terminalApply.InsertOperEnvironment.ID = outpatientManager.Operator.ID;

                //    terminalApply.PatientType = "4";

                //    iReturn = terminalManager.InsertMedTechItem(terminalApply);
                //    if (iReturn == -1)
                //    {
                //        errText = "处理终端申请确认表失败!" + myConfirm.Err;

                //        return false;
                //    }

                //    if (f.Item.IsNeedBespeak)
                //    {
                //        ////iReturn = terminalManager.MedTechApply(f, this.trans);
                //        if (iReturn == -1)
                //        {
                //            errText = "插入医技预约信息出错!" + f.Name + terminalManager.Err;

                //            return false;
                //        }
                //    }
                //}
                #endregion

                if (iReturn == -1)
                {
                    if (outpatientManager.DBErrCode == 1)//主键重复，直接更新
                    {
                        iReturn = outpatientManager.UpdateFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "更新费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    else
                    {
                        errText = "插入费用明细失败!" + outpatientManager.Err;

                        return false;
                    }
                }
            }

            return true;
        }


        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 门诊账户使用的划价收费函数

        /// <summary>
        /// 账户终端收费函数
        /// </summary>
        /// <param name="r">挂号信息</param>
        /// <param name="f">费用信息</param>
        /// <param name="errText">错误信息</param>
        /// <returns>true成功 false 失败</returns>
        public bool SaveFeeToAccount(Register r, string recipeNO, int sequenceNO, ref string errText)
        {

            FeeItemList f = outpatientManager.GetFeeItemList(recipeNO, sequenceNO);
            if (f == null)
            {
                errText = "查询费用信息失败！" + outpatientManager.Err;
                return false;
            }
            DateTime feeTime = outpatientManager.GetDateTimeFromSysDateTime();
            string feeOper = outpatientManager.Operator.ID;
            f.FeeOper.ID = feeOper;
            f.FeeOper.OperTime = feeTime;
            f.PayType = PayTypes.Balanced;
            int iReturn;
            iReturn = outpatientManager.UpdateFeeDetailFeeFlag(f);
            if (iReturn <= 0)
            {
                errText = "更新费用收费标记失败！" + outpatientManager.Err;
                return false;
            }

            if (f.FTSource == "1")
            {
                iReturn = orderOutpatientManager.UpdateOrderChargedByOrderID(f.Order.ID, feeOper);
                if (iReturn == -1)
                {
                    errText = "更新医嘱信息出错!" + orderOutpatientManager.Err;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 账户划价函数
        /// </summary>
        /// <param name="r">患者挂号信息</param>
        /// <param name="feeItemLists">费用信息</param>
        /// <param name="chargeTime">划价时间</param>
        /// <param name="errText">错误信息</param>
        /// <returns></returns>
        public bool SetChargeInfoToAccount(Register r, ArrayList feeItemLists, DateTime chargeTime, ref string errText)
        {
            #region 删除申请表
            ArrayList drugLists = new ArrayList();
            ArrayList undrugList = new ArrayList();
            Dictionary<string, string> dicRecipe = new Dictionary<string, string>();
            foreach (FeeItemList f in feeItemLists)
            {
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    if (!f.IsConfirmed)
                    {
                        if (!f.Item.IsNeedConfirm)
                        {
                            if (pharmarcyManager.DelApplyOut(f.RecipeNO, f.SequenceNO.ToString()) < 0)
                            {
                                errText = "删除发药申请信息细失败！" + confirmIntegrate.Err;
                                return false;
                            }
                            if (!dicRecipe.ContainsKey(f.RecipeNO))
                            {
                                dicRecipe.Add(f.RecipeNO, f.ExecOper.Dept.ID);
                            }
                            else
                            {
                                if (dicRecipe[f.RecipeNO] != f.ExecOper.Dept.ID)
                                {
                                    dicRecipe.Add(f.RecipeNO, f.ExecOper.Dept.ID);
                                }
                            }
                            drugLists.Add(f);
                        }
                    }
                }
                else
                {
                    if (!f.IsConfirmed)
                    {
                        if (f.Item.IsNeedConfirm)
                        {
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                f.Order.ID = orderManager.GetNewOrderID();
                            }
                            if (f.Order.ID == null || f.Order.ID == string.Empty)
                            {
                                errText = "获得医嘱流水号出错!";

                                return false;
                            }
                            if (confirmIntegrate.DelTecApply(f.RecipeNO, f.SequenceNO.ToString()) < 0)
                            {
                                errText = "删除终端申请信息失败！" + confirmIntegrate.Err;
                                return false;
                            }
                            undrugList.Add(f);
                        }
                    }
                }
            }
            #endregion

            #region 删除药品调剂头表
            foreach (string recipeNO in dicRecipe.Keys)
            {
                if (pharmarcyManager.DeleteDrugStoRecipe(recipeNO, dicRecipe[recipeNO]) < 0)
                {
                    MessageBox.Show("删除调剂头表信息失败！" + pharmarcyManager.Err);
                    return false;
                }
            }
            #endregion

            #region 正常划价

            foreach (FeeItemList f in feeItemLists)
            {
                f.IsAccounted = true;
                f.FT.TotCost = f.FT.OwnCost;
                if (string.IsNullOrEmpty((f.Patient as Register).DoctorInfo.Templet.Doct.ID))
                {
                    (f.Patient as Register).DoctorInfo.Templet.Doct = outpatientManager.Operator;
                }
            }

            bool resultValue = SetChargeInfo(r, feeItemLists, chargeTime, ref errText);
            if (!resultValue) return false;
            #endregion

            #region 插入药品申请表
            string drugSendInfo = null;
            //插入发药申请信息,返回发药窗口,显示在发票上
            if (drugLists.Count > 0)
            {
                foreach (FeeItemList f in drugLists)
                {
                    if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = outpatientManager.Operator;
                    }
                }
                
                int iReturn = pharmarcyManager.ApplyOut(r, drugLists, string.Empty, chargeTime, false, out drugSendInfo);
                if (iReturn == -1)
                {
                    errText = "处理药品明细失败!" + pharmarcyManager.Err;

                    return false;
                }
            }
            #endregion

            #region 插入终端项目申请
            foreach (FeeItemList f in undrugList)
            {
                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                {
                    errText = "处理终端申请确认表失败!" + confirmIntegrate.Err;

                    return false;
                }
            }
            #endregion

            return true;
        }

        /// <summary>
        /// 账户收费(终端划价收费使用)
        /// </summary>
        /// <param name="r"></param>
        /// <param name="feeItemLists"></param>
        /// <param name="chargeTime"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public bool SaveFeeToAccount(Register r, ArrayList feeItemLists, DateTime feeTime,string accountNO, ref string errText)
        {
            //总费用
            decimal totCost = 0m;
            ArrayList drugLists = new ArrayList();
            ArrayList undrugList = new ArrayList();
            #region 费用
            bool returnValue = false;
            int iReturn = 0;
            string recipeSeq = null;//收费序列

            recipeSeq = outpatientManager.GetRecipeSequence();
            if (recipeSeq == null || recipeSeq == string.Empty)
            {
                errText = "获得收费序列号出错!";

                return false;
            }

            //设置处方号
            returnValue = this.SetRecipeNOOutpatient(r, feeItemLists, ref errText);
            if (!returnValue)
            {
                return false;
            }

            foreach (FeeItemList f in feeItemLists)
            {
                //验证数据合法性
                if (!this.IsFeeItemListDataValid(f, ref errText))
                {
                    return false;
                }
                //划价保存
                f.ChargeOper.ID = outpatientManager.Operator.ID;
                f.ChargeOper.OperTime = feeTime;
                f.Patient = r.Clone();

                f.FeeOper.ID = outpatientManager.Operator.ID;
                f.FeeOper.OperTime = feeTime;
                f.CancelType = CancelTypes.Valid;
                f.Patient.PID.CardNO = r.PID.CardNO;
                f.AccountNO = accountNO;//账号
                ((Neusoft.HISFC.Models.Registration.Register)f.Patient).DoctorInfo.SeeDate = r.DoctorInfo.SeeDate;
                if (((Register)f.Patient).DoctorInfo.Templet.Dept.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Dept.ID == string.Empty)
                {
                    ((Register)f.Patient).DoctorInfo.Templet.Dept = r.DoctorInfo.Templet.Dept.Clone();
                }
                if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                {
                    ((Register)f.Patient).DoctorInfo.Templet.Doct = r.DoctorInfo.Templet.Doct.Clone();
                }
                if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                {
                    f.RecipeOper.Dept.ID = r.User01;
                }

                f.PayType = PayTypes.Balanced;
                f.TransType = TransTypes.Positive;
                f.NoBackQty = f.Item.Qty;
                f.IsAccounted = true;//账户扣费标记
                f.ExamineFlag = r.ChkKind;
                if (f.RecipeOper.Dept.ID == null || f.RecipeOper.Dept.ID == string.Empty)
                {
                    f.RecipeOper.Dept.ID = r.User01;
                }
                if (f.Order.ID == null || f.Order.ID == string.Empty)//没有付值医嘱流水号
                {
                    f.Order.ID = orderManager.GetNewOrderID();
                    if (f.Order.ID == null || f.Order.ID == string.Empty)
                    {
                        errText = "获得医嘱流水号出错!";

                        return false;
                    }
                }
                if (f.RecipeSequence == null || f.RecipeSequence == string.Empty)
                {
                    f.RecipeSequence = recipeSeq;
                }
                if (f.InvoiceCombNO == null || f.InvoiceCombNO == string.Empty)
                {
                    f.InvoiceCombNO = "NULL";
                }
                //判断是否收费
                if (outpatientManager.GetItemIsFee(r.ID, f.Order.ID,f.Item.ID) > 0)
                {
                    errText = f.Item.Name + "可能已经收费,请刷新后再收费";
                    return false;
                }

                iReturn = outpatientManager.InsertFeeItemList(f);
                if (iReturn == -1)
                {
                    if (outpatientManager.DBErrCode == 1)//主键重复，直接更新
                    {
                        iReturn = outpatientManager.UpdateFeeItemList(f);
                        if (iReturn <= 0)
                        {
                            errText = "更新费用明细失败!" + outpatientManager.Err;

                            return false;
                        }
                    }
                    else
                    {
                        errText = "插入费用明细失败!" + outpatientManager.Err;

                        return false;
                    }
                }
                #region 区分药品非药品
                if (f.Item.ItemType == EnumItemType.Drug)
                {
                    if (!f.IsConfirmed)
                    {
                        if (!f.Item.IsNeedConfirm)
                        {
                            drugLists.Add(f);
                        }
                    }
                }
                else
                {
                    if (!f.IsConfirmed)
                    {
                        if (f.Item.IsNeedConfirm)
                        {
                            undrugList.Add(f);
                        }
                    }
                }
                #endregion

                totCost += f.FT.TotCost;
            }
            #endregion

            #region 扣去账户费用
            string deptCode = (outpatientManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
            int iResult = this.AccountPay(r, totCost, string.Empty,deptCode,string.Empty);
            if (iResult == -1)
            {
                
                return false;
            }
            #endregion

            #region 申请数据

            #region 插入药品申请表
            string drugSendInfo = null;
            //插入发药申请信息,返回发药窗口,显示在发票上
            if (drugLists.Count > 0)
            {
                foreach (FeeItemList f in drugLists)
                {
                    if (((Register)f.Patient).DoctorInfo.Templet.Doct.ID == null || ((Register)f.Patient).DoctorInfo.Templet.Doct.ID == string.Empty)
                    {
                        ((Register)f.Patient).DoctorInfo.Templet.Doct = outpatientManager.Operator;
                    }
                }

                iReturn = pharmarcyManager.ApplyOut(r, drugLists, string.Empty, feeTime, false, out drugSendInfo);
                if (iReturn == -1)
                {
                    errText = "处理药品明细失败!" + pharmarcyManager.Err;

                    return false;
                }
            }
            #endregion

            #region 插入终端项目申请
            foreach (FeeItemList f in undrugList)
            {
                Terminal.Result result = confirmIntegrate.ServiceInsertTerminalApply(f, r);

                if (result != Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Success)
                {
                    errText = "处理终端申请确认表失败!" + confirmIntegrate.Err;

                    return false;
                }
            }
            #endregion

            #endregion

            return true;
        }
        
        #endregion


        /// <summary>
        /// 发票打印方法
        /// </summary>
        /// <param name="invoicePrintDll">发票打印dll位置</param>
        /// <param name="rInfo">患者基本信息</param>
        /// <param name="invoices">发票集合</param>
        /// <param name="invoiceDetails">发票明细集合</param>
        /// <param name="feeDetails">费用明细集合</param>
        /// <param name="alPayModes">支付方式集合</param>
        /// <param name="t">数据库事务</param>
        /// <param name="isPreView">是否预览</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int PrintInvoice(string invoicePrintDll, Register rInfo, ArrayList invoices, ArrayList invoiceDetails,
            ArrayList feeDetails, ArrayList alPayModes, bool isPreView, ref string errText)
        {

            int iReturn = 0;//返回值
            ArrayList alTempPayModes = new ArrayList();//临时支付方式

            if (alPayModes != null)
            {
                foreach (BalancePay p in alPayModes)
                {
                    alTempPayModes.Add(p);
                }
            }

            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                errText = "没有维护发票打印方案!请维护";
                return -1;
            }
            invoicePrintDll = Application.StartupPath + invoicePrintDll;
            ArrayList alPrint = new ArrayList();
            IInvoicePrint iInvoicePrint = null;

            for (int i = 0; i < invoices.Count; i++)
            {
                Balance invoice = invoices[i] as Balance;
                if (invoice.Memo == "5")
                {
                    continue;
                }

                ArrayList invoiceDetailsTemp = ((ArrayList)invoiceDetails[0])[i] as ArrayList;
                object obj = null;
                Assembly a = Assembly.LoadFrom(invoicePrintDll);
                System.Type[] types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IInvoicePrint") != null)
                    {
                        try
                        {
                            obj = System.Activator.CreateInstance(type);
                            iInvoicePrint = obj as IInvoicePrint;

                            iInvoicePrint.SetTrans(this.trans);
                            //if (invoices.Count > 1 && rInfo.Pact.PayKind.ID == "01")
                            //{
                                string payMode = string.Empty;
                                DealSplitPayMode(alTempPayModes, invoice, ref payMode);
                                iInvoicePrint.SetPayModeType = "1";
                                iInvoicePrint.SplitInvoicePayMode = payMode;
                            //}

                            iReturn = iInvoicePrint.SetPrintValue(rInfo, invoice, invoiceDetailsTemp, feeDetails, isPreView);

                            if (iReturn == -1)
                            {
                                return 0;
                            }

                            alPrint.Add(obj);
                            break;
                        }
                        catch (Exception ex)
                        {
                            errText = ex.Message;

                            return 0;
                        }
                    }
                }
            }
            for (int i = 0; i < alPrint.Count; i++)//foreach(object objPrint in alPrint)
            {
                if (i == 0)
                {
                    iInvoicePrint = alPrint[i] as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint;
                }
                iReturn = ((IInvoicePrint)alPrint[i]).Print();
                if (iReturn == -1)
                {
                    return 0;
                }
            }

            if (alPrint.Count > 0 && feeDetails.Count > 0)
            {
                try
                {
                    FeeItemList feeTemp = feeDetails[0] as FeeItemList;

                    if (iInvoicePrint != null && printRecipeHeler.GetObjectFromID(((Register)feeTemp.Patient).DoctorInfo.Templet.Doct.ID) == null)
                    {
                        iInvoicePrint.SetPrintOtherInfomation(rInfo, invoices, null, feeDetails);
                        iInvoicePrint.PrintOtherInfomation();
                    }
                }
                catch (Exception ex)
                {
                    errText = ex.Message;

                    return 0;
                }
            }

            return 1;
        }
        /// 发票打印方法
        /// </summary>
        /// <param name="invoicePrintDll">发票打印dll位置</param>
        /// <param name="rInfo">患者基本信息</param>
        /// <param name="invoices">发票集合</param>
        /// <param name="invoiceDetails">发票明细集合</param>
        /// <param name="feeDetails">费用明细集合</param>
        /// <param name="invoiceFeeDetails">发票费用明细信息（按发票分组后的费用明细，每个对象对应该发票下的费用明细）</param>
        /// <param name="alPayModes">支付方式集合</param>
        /// <param name="t">数据库事务</param>
        /// <param name="isPreView">是否预览</param>
        /// <param name="errText">错误信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int PrintInvoice(string invoicePrintDll, Register rInfo, ArrayList invoices, ArrayList invoiceDetails,
            ArrayList feeDetails, ArrayList invoiceFeeDetails, ArrayList alPayModes, bool isPreView, ref string errText)
        {

            int iReturn = 0;//返回值
            ArrayList alTempPayModes = new ArrayList();//临时支付方式

            if (alPayModes != null)
            {
                foreach (BalancePay p in alPayModes)
                {
                    alTempPayModes.Add(p);
                }
            }

            if (invoicePrintDll == null || invoicePrintDll == string.Empty)
            {
                errText = "没有维护发票打印方案!请维护";
                return -1;
            }
            invoicePrintDll = Application.StartupPath + invoicePrintDll;
            ArrayList alPrint = new ArrayList();
            IInvoicePrint iInvoicePrint = null;

            for (int i = 0; i < invoices.Count; i++)
            {
                Balance invoice = invoices[i] as Balance;
                if (invoice.Memo == "5")
                {
                    continue;
                }

                ArrayList invoiceDetailsTemp = ((ArrayList)invoiceDetails[0])[i] as ArrayList;
                ArrayList invoiceFeeDetailsTemp = ((ArrayList)invoiceFeeDetails[0])[i] as ArrayList;

                object obj = null;
                Assembly a = Assembly.LoadFrom(invoicePrintDll);
                System.Type[] types = a.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("IInvoicePrint") != null)
                    {
                        try
                        {
                            obj = System.Activator.CreateInstance(type);
                            iInvoicePrint = obj as IInvoicePrint;

                            iInvoicePrint.SetTrans(this.trans);
                            //if (invoices.Count > 1 && rInfo.Pact.PayKind.ID == "01")
                            //{
                            string payMode = string.Empty;
                            DealSplitPayMode(alTempPayModes, invoice, ref payMode);
                            iInvoicePrint.SetPayModeType = "1";
                            iInvoicePrint.SplitInvoicePayMode = payMode;
                            //}

                            iReturn = iInvoicePrint.SetPrintValue(rInfo, invoice, invoiceDetailsTemp, invoiceFeeDetailsTemp, isPreView);

                            if (iReturn == -1)
                            {
                                return 0;
                            }

                            alPrint.Add(obj);
                            break;
                        }
                        catch (Exception ex)
                        {
                            errText = ex.Message;

                            return 0;
                        }
                    }
                }
            }
            for (int i = 0; i < alPrint.Count; i++)//foreach(object objPrint in alPrint)
            {
                if (i == 0)
                {
                    iInvoicePrint = alPrint[i] as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInvoicePrint;
                }
                iReturn = ((IInvoicePrint)alPrint[i]).Print();
                if (iReturn == -1)
                {
                    return 0;
                }
            }

            if (alPrint.Count > 0 && feeDetails.Count > 0)
            {
                try
                {
                    FeeItemList feeTemp = feeDetails[0] as FeeItemList;

                    if (iInvoicePrint != null && printRecipeHeler.GetObjectFromID(((Register)feeTemp.Patient).DoctorInfo.Templet.Doct.ID) == null)
                    {
                        iInvoicePrint.SetPrintOtherInfomation(rInfo, invoices, null, feeDetails);
                        iInvoicePrint.PrintOtherInfomation();
                    }
                }
                catch (Exception ex)
                {
                    errText = ex.Message;

                    return 0;
                }
            }

            return 1;
        }

        /// <summary>
        /// 设置分发票后的支付方式
        /// </summary>
        /// <param name="alPayModes"></param>
        /// <param name="invoice"></param>
        /// <param name="payMode"></param>
        private void DealSplitPayMode(ArrayList alPayModes, Balance invoice, ref string payMode)
        {
            #region donggq--20101216--{3354E8E0-97B6-4ac6-B8D4-EA92C9DAD00E}
            //decimal totCost = invoice.FT.PayCost + invoice.FT.PubCost + invoice.FT.OwnCost;
            //decimal cardCost = 0m;
            //foreach (BalancePay p in alPayModes)
            //{
            //    if (p.PayType.ID.ToString() == "CA" && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            payMode += "现金: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(p.FT.RealCost, 2);
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.TotCost -= totCost;
            //            payMode += "现金: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2);
            //            break;
            //        }
            //    }
            //    if (p.PayType.ID.ToString() == "PS" && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            payMode += "医保卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(p.FT.RealCost, 2);
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.RealCost -= totCost;
            //            payMode += "医保卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2);
            //            break;
            //        }
            //    }
            //    if ((p.PayType.ID.ToString() == "CD" || p.PayType.ID.ToString() == "DB") && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            cardCost += p.FT.RealCost;
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.RealCost -= totCost;
            //            cardCost += totCost;
            //            //payMode += "医保卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost,2);
            //            break;
            //        }
            //    }
            //    if (p.PayType.ID.ToString() == "CH" && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            payMode += "支票: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(p.FT.RealCost, 2);
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.RealCost -= totCost;
            //            payMode += "支票: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2);
            //            break;
            //        }
            //    }
            //    if (p.PayType.ID.ToString() == "SB" && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            payMode += "社保卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(p.FT.RealCost, 2);
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.RealCost -= totCost;
            //            payMode += "社保卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2);
            //            break;
            //        }
            //    }
            //    if (p.PayType.ID.ToString() == "YS" && p.FT.RealCost > 0)
            //    {
            //        if (p.FT.RealCost <= totCost)
            //        {
            //            totCost -= p.FT.RealCost;
            //            payMode += "院内账户: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(p.FT.RealCost, 2);
            //            p.FT.RealCost = 0;
            //        }
            //        else
            //        {
            //            p.FT.TotCost -= totCost;
            //            payMode += "院内账户: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(totCost, 2);
            //            break;
            //        }
            //    }
            //}

            //if (cardCost > 0)
            //{
            //    payMode += "银行卡: " + Neusoft.FrameWork.Public.String.FormatNumberReturnString(cardCost, 2);
            //}

            foreach (BalancePay p in alPayModes)
            {
                if (p.PayType.ID.ToString() == "CA")
                {
                    payMode += "现金  ";
                }
                if (p.PayType.ID.ToString() == "PS")
                {
                    payMode += "医保卡  ";
                }
                if (p.PayType.ID.ToString() == "CD" || p.PayType.ID.ToString() == "DB")
                {
                    payMode += "银行卡  ";
                }
                if (p.PayType.ID.ToString() == "CH")
                {
                    payMode += "支票  ";
                }
                if (p.PayType.ID.ToString() == "SB")
                {
                    payMode += "社保卡  ";
                }
                if (p.PayType.ID.ToString() == "YS")
                {
                    payMode += "院内账户  ";
                }
            } 
            #endregion
        }

        /// <summary>
        /// 获得处方号
        /// </summary>
        /// <returns></returns>
        public string GetRecipeNO()
        {
            this.SetDB(outpatientManager);

            return outpatientManager.GetRecipeNO();
        }

        /// <summary>
        /// 通过医嘱项目流水号或者体检项目流水号，得到费用明细
        /// </summary>
        /// <param name="MOOrder">医嘱项目流水号或者体检项目流水号</param>
        /// <returns>null 错误 ArrayList Fee.OutPatient.FeeItemList实体集合</returns>
        public ArrayList QueryFeeDetailFromMOOrder(string MOOrder)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.QueryFeeDetailFromMOOrder(MOOrder);
        }

        /// <summary>
        /// 根据医嘱或者体检项目流水号删除明细
        /// </summary>
        /// <param name="MOOrder">医嘱或者体检项目流水号</param>
        /// <returns>成功: >= 1 失败: -1 没有删除到数据返回 0</returns>
        public int DeleteFeeItemListByMoOrder(string MOOrder)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.DeleteFeeItemListByMoOrder(MOOrder);
        }

        #region 查询发票组合号是否已经收费
        /// <summary>
        /// 根据发票组合号查询体检汇总信息是否已经收费　
        /// </summary>
        /// <param name="RecipeSeq">发票组合号</param>
        /// <returns>0 已收费， 1 未收费 ，-1 查询出错</returns>
        public int IsFeeItemListByRecipeNO(string RecipeSeq)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.IsFeeItemListByRecipeNO(RecipeSeq);
        }
        #endregion

        /// <summary>
        /// 根据病历号和时间段得到患者未收费明细
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="dtFrom">开始时间</param>
        /// <param name="dtTo">结束时间</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryOutpatientFeeItemLists(string cardNO, DateTime dtFrom, DateTime dtTo)
        {
            return outpatientManager.QueryFeeItemLists(cardNO, dtFrom, dtTo);
        }


        /// <summary>
        /// 根据病历号和时间段得到患者未收费明细
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="dtFrom">开始时间</param>
        /// <param name="dtTo">结束时间</param>
        /// <returns>成功:费用明细 失败:null 没有数据:返回元素数为0的ArrayList</returns>
        public ArrayList QueryOutpatientFeeItemListsZs(string cardNO, DateTime dtFrom, DateTime dtTo)
        {
            return outpatientManager.QueryFeeItemListsForZs(cardNO, dtFrom, dtTo);
        }

        #region 获得收费序列号

        /// <summary>
        /// 获得收费序列号
        /// </summary>
        /// <returns>成功:收费序列号 失败:null</returns>
        public string GetRecipeSequence()
        {
            this.SetDB(outpatientManager);
            return outpatientManager.GetRecipeSequence();
        }

        #endregion

        #endregion

        /// <summary>
        /// 获取合同单位列表
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryPackList()
        {
            this.SetDB(pactManager);

            return pactManager.QueryPactUnitAll();
        }

        #endregion

        #region 门诊医生站相关add by sunm

        /// <summary>
        /// 插入门诊费用明细
        /// </summary>
        /// <param name="feeItemList"></param>
        /// <returns></returns>
        public int InsertFeeItemList(FeeItemList feeItemList)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.InsertFeeItemList(feeItemList);
        }

        /// <summary>
        /// 更新门诊费用明细
        /// </summary>
        /// <param name="feeItemList"></param>
        /// <returns></returns>
        public int UpdateFeeItemList(FeeItemList feeItemList)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.UpdateFeeItemList(feeItemList);
        }

        /// <summary>
        /// 根据处方号和处方内流水号删除费用明细
        /// </summary>
        /// <param name="recipeNO"></param>
        /// <param name="recipeSequence"></param>
        /// <returns></returns>
        public int DeleteFeeItemListByRecipeNO(string recipeNO, string recipeSequence)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.DeleteFeeItemListByRecipeNO(recipeNO, recipeSequence);
        }

        /// <summary>
        /// 根据组合号和流水号删除费用明细
        /// </summary>
        /// <param name="combNO"></param>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public int DeleteFeeDetailByCombNoAndClinicCode(string combNO, string clinicCode)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.DeleteFeeDetailByCombNoAndClinicCode(combNO, clinicCode);
        }

        /// <summary>
        /// 通过患者流水号和组合号得到费用明细
        /// </summary>
        /// <param name="combNO"></param>
        /// <param name="clinicCode"></param>
        /// <returns></returns>
        public ArrayList QueryFeeDetailbyComoNOAndClinicCode(string combNO, string clinicCode)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.QueryFeeDetailbyComoNOAndClinicCode(combNO, clinicCode);
        }

        #endregion

        #region 院内注射

        /// <summary>
        /// 获得院注信息根据用法
        /// </summary>
        /// <param name="usageCode"></param>
        /// <returns></returns>
        public ArrayList GetInjectInfoByUsage(string usageCode)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.GetInjectInfoByUsage(usageCode);
        }

        /// <summary>
        /// 删除用法项目信息
        /// </summary>
        /// <param name="Usage"></param>
        /// <returns></returns>
        public int DelInjectInfo(string Usage)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.DelInjectInfo(Usage);
        }

        /// <summary>
        /// 插如用法项目信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertInjectInfo(NeuObject obj)
        {
            SetDB(outpatientManager);
            return outpatientManager.InsertInjectInfo(obj);
        }

        #endregion

        #region addby xuewj 2009-8-26 执行单管理 单项目维护 {0BB98097-E0BE-4e8c-A619-8B4BCA715001}

        /// <summary>
        /// 好像是执行单维护用的
        /// </summary>
        /// <param name="nruseID">护士站编码</param>
        /// <param name="sysClass">系统类别</param>
        /// <param name="validState">有效状态</param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public int QueryItemOutExecBill(string nruseID, string sysClass, string validState, ref DataSet ds)
        {
            this.SetDB(itemManager);
            return itemManager.QueryItemOutExecBill(nruseID, sysClass, validState, ref ds);
        }

        #endregion

        #endregion

        #region 枚举

        /// <summary>
        /// 收费函数操作类型
        /// </summary>
        private enum ChargeTypes
        {
            /// <summary>
            /// 划价
            /// </summary>
            Charge = 0,

            /// <summary>
            /// 收费
            /// </summary>
            Fee = 1,

            /// <summary>
            /// 划价记录转收费
            /// </summary>
            ChargeToFee = 2,

        }

        #endregion

        #region 门诊帐户

        /// <summary>
        /// 根据处方号和处方内流水号更新已扣账户标志
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方内流水号</param>
        /// <param name="isAccounted">true 已经扣取账户 false 没有扣取账户</param>
        /// <returns>成功 1 失败 -1 不符合更新条件 0</returns>
        public int UpdateAccountByRecipeNO(string recipeNO, int sequenceNO, bool isAccounted)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.UpdateAccountFlag(recipeNO, sequenceNO, isAccounted);
        }

        /// <summary>
        /// 根据医嘱流水号和项目编码更新已扣账户标志
        /// </summary>
        /// <param name="itemCode">项目编码</param>
        /// <param name="moOrder">医嘱流水号</param>
        /// <param name="isAccounted">true 已经扣取账户 false 没有扣取账户</param>
        /// <returns>成功 1 失败 -1 不符合更新条件 0</returns>
        public int UpdateAccountByMoOrderAndItemCode(string itemCode, string moOrder, bool isAccounted)
        {
            this.SetDB(outpatientManager);

            return outpatientManager.UpdateAccountFlag(itemCode, moOrder, isAccounted);
        }


        /// <summary>
        /// 帐户支付
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="money">金额</param>
        /// <param name="reMark">标识</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns> 1 成功 0取消收费 -1失败</returns>
        public int AccountPay(HISFC.Models.RADT.Patient patient, decimal money, string reMark, string deptCode, string invoiceType)
        {
            this.SetDB(accountManager);
            bool bl = accountManager.AccountPayManager(patient, money, reMark, invoiceType, deptCode, 0);
            if (!bl) return -1;
            this.Err = accountManager.Err;
            return 1;
        }

        /// <summary>
        /// 退费入户
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="money">金额</param>
        /// <param name="reMark">标识</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>1成功 -1失败</returns>
        public int AccountCancelPay(HISFC.Models.RADT.Patient patient, decimal money, string reMark, string deptCode, string invoiceType)
        {
            this.SetDB(accountManager);
            bool bl = accountManager.AccountPayManager(patient, money, reMark, invoiceType, deptCode, 1);
            if (!bl)
            {
                this.Err = accountManager.Err;
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 得到帐户余额
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="vacancy">余额</param>
        /// <returns>0:帐户停用或帐户不存在 -1查询失败 1成功</returns>
        public int GetAccountVacancy(string cardNO, ref decimal vacancy)
        {
            this.SetDB(accountManager);
            int resultValue = accountManager.GetVacancy(cardNO, ref vacancy);
            this.Err = accountManager.Err;
            return resultValue;
        }

        /// <summary>
        /// 得到帐户余额
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <param name="vacancy">余额</param>
        /// <param name="accountNO">账号</param>
        /// <returns>0:帐户停用或帐户不存在 -1查询失败 1成功</returns>
        public int GetAccountVacancy(string cardNO, ref decimal vacancy,ref string accountNO)
        {
            this.SetDB(accountManager);
            int resultValue = accountManager.GetVacancy(cardNO, ref vacancy,ref accountNO);
            this.Err = accountManager.Err;
            return resultValue;
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        private Neusoft.HISFC.BizProcess.Interface.Account.IPassWord GetIPassWord()
        {
            if (ipassWord == null)
            {
                System.Runtime.Remoting.ObjectHandle obj = System.Activator.CreateInstance("HISFC.Components.Account", "Neusoft.HISFC.Components.Account.Controls.ucPassWord");
                if (obj == null)
                {
                    return null; ;
                }
                ipassWord = obj.Unwrap() as Neusoft.HISFC.BizProcess.Interface.Account.IPassWord;
            }
            return ipassWord;
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 验证帐户密码
        /// </summary>
        /// <param name="cardNo">门诊卡号</param>
        /// <returns>true 成功　false失败</returns>
        public bool CheckAccountPassWord(HISFC.Models.RADT.Patient patient)
        {
            //GetIPassWord();
            //ipassWord.Patient = patient;
            //Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(ipassWord as Control);
            //if (ipassWord.IsOK)
            //{
            //    if (ipassWord.ValidPassWord)
            //        return true;
            //}
            //return false;

            return true;
        }

  
        /// <summary>
        /// 通过物理卡号查找门诊卡号
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <param name="markType">卡类型</param>
        /// <param name="cardNo">门诊卡号</param>
        /// <returns>bool true 成功　false 失败</returns>
        public bool GetCardNoByMarkNo(string markNo, ref string cardNo)
        {
            this.SetDB(accountManager);
            bool bl = accountManager.GetCardNoByMarkNo(markNo, ref cardNo);
            this.Err = accountManager.Err;
            return bl;
        }

        /// <summary>
        /// 通过物理卡号查找门诊卡号
        /// </summary>
        /// <param name="markNo">物理卡号</param>
        /// <param name="markType">卡类型</param>
        /// <param name="cardNo">门诊卡号</param>
        /// <returns>bool true 成功　false 失败</returns>
        public bool GetCardNoByMarkNo(string markNo, NeuObject markType, ref string cardNo)
        {
            this.SetDB(accountManager);
            bool bl = accountManager.GetCardNoByMarkNo(markNo, markType, ref cardNo);
            this.Err = accountManager.Err;
            return bl;
        }

        /// <summary>
        /// 根据门诊卡号查找密码
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns>用户密码</returns>
        public string GetPassWordByCardNO(string cardNO)
        {
            this.SetDB(accountManager);
            return accountManager.GetPassWordByCardNO(cardNO);
        }

        /// <summary>
        /// 根据门诊卡号查找患者信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string cardNO)
        {
            this.SetDB(accountManager);
            return accountManager.GetPatientInfo(cardNO);
        }


        /// <summary>
        /// 根据卡规则读出卡号
        /// </summary>
        /// <param name="markNo">输入卡号</param>
        /// <param name="accountCard">根据规则读出的卡信息</param>
        /// <returns>1成功(已经发放) 0卡还为发放 -1失败</returns>
        public int ValidMarkNO(string markNo, ref HISFC.Models.Account.AccountCard accountCard)
        {
            this.SetDB(accountManager);
            return accountManager.GetCardByRule(markNo, ref accountCard);
        }
        #endregion

        #region 发票跳号{BF01254E-3C73-43d4-A644-4B258438294E}
        /// <summary>
        /// 插入发票调号表
        /// </summary>
        /// <param name="invoiceJumpRecord"></param>
        /// <returns></returns>
        public int InsertInvoiceJumpRecord(Neusoft.HISFC.Models.Fee.InvoiceJumpRecord invoiceJumpRecord)
        {
  
            //{BF01254E-3C73-43d4-A644-4B258438294E}
            this.SetDB(this.invoiceJumpRecordMgr);
            this.SetDB(invoiceServiceManager);
            //去最大序号
            string happenNO = this.invoiceJumpRecordMgr.GetMaxHappenNO(invoiceJumpRecord.Invoice.AcceptOper.ID, invoiceJumpRecord.Invoice.Type.ID);

            if (happenNO == "-1")
            {
                this.Err = this.invoiceJumpRecordMgr.Err;
                return -1;
            }

            invoiceJumpRecord.HappenNO = int.Parse(happenNO) + 1;
            invoiceJumpRecord.Oper.OperTime = this.invoiceJumpRecordMgr.GetDateTimeFromSysDateTime();

            int returnValue = 0;
            returnValue = this.invoiceJumpRecordMgr.InsertTable(invoiceJumpRecord);

            if (returnValue < 0)
            {
                this.Err = this.invoiceJumpRecordMgr.Err;
                return -1;
            }

            //更新使用号
            returnValue = this.invoiceServiceManager.UpdateUsedNO(invoiceJumpRecord.NewUsedNO, invoiceJumpRecord.Invoice.AcceptOper.ID, invoiceJumpRecord.Invoice.Type.ID);
            if (returnValue < 0)
            {
                this.Err = this.invoiceServiceManager.Err;
            }

            return 1;

        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {

                Type[] type = new Type[5];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitInvoice);
                type[1] = typeof(IFeeOweMessage);
                type[2] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IAdptIllnessOutPatient);
                type[3] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.ISplitRecipe);

                type[4] = typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IShowFrmValidUserPassWord);
                return type;
            }
        }

        #endregion

        /// <summary>
        /// 根据传入的项目函数内自动赋值，
        /// </summary>
        /// <param name="pInfo">患者实体</param>
        /// <param name="item">项目信息，收费数量要包含在项目实体item.qty中</param>
        /// <param name="execDept">执行科室代码</param>
        /// <returns></returns>
        public int FeeAutoItem(Neusoft.HISFC.Models.RADT.PatientInfo pInfo, Neusoft.HISFC.Models.Base.Item item,
            string execDept)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
            Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactUnitManager = new Neusoft.HISFC.BizLogic.Fee.PactUnitInfo();

            pactUnitManager.SetTrans(this.trans);

            string operCode = pactUnitManager.Operator.ID;
            DateTime dtNow = pactUnitManager.GetDateTimeFromSysDateTime();

            ItemList.Item = item;
            //在院科室
            ((Neusoft.HISFC.Models.RADT.PatientInfo)ItemList.Patient).PVisit.PatientLocation.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
            //护士站
            ((Neusoft.HISFC.Models.RADT.PatientInfo)ItemList.Patient).PVisit.PatientLocation.NurseCell.ID = pInfo.PVisit.PatientLocation.NurseCell.ID;
            //执行科室
            ItemList.ExecOper.Dept.ID = execDept;
            //扣库科室
            ItemList.StockOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
            //开方科室
            ItemList.RecipeOper.Dept.ID = pInfo.PVisit.PatientLocation.Dept.ID;
            //开方医生
            ItemList.RecipeOper.ID = pInfo.PVisit.AdmittingDoctor.ID; //医生
            //根据传入的实体处理价格
            decimal price = 0;
            //if (pactUnitManager.GetPrice(pInfo, item.IsPharmacy, item.ID, ref price) == -1)
            if (pactUnitManager.GetPrice(pInfo, item.ItemType, item.ID, ref price) == -1)
            {
                this.Err = "取项目:" + item.Name + "的价格出错!" + pactUnitManager.Err;
                return -1;
            }
            item.Price = price;

            //药品默认按最小单位收费,显示价格也为最小单位价格,存入数据库的为包装单位价格
            //if (item.IsPharmacy)//药品
            if (item.ItemType == EnumItemType.Drug)//药品
            {
                price = Neusoft.FrameWork.Public.String.FormatNumber(item.Price / item.PackQty, 4);
            }

            /* 外部已经赋值部分：价格、数量、单位、是否药品
             * ItemList.Item.Price = 0;ItemList.Item.Qty;  
             * ItemList.Item.PriceUnit = "次"; 
             * ItemList.Item.IsPharmacy = false;
             */

            ItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber(ItemList.Item.Qty * price, 2);
            //ItemList.FT.OwnCost = ItemList.FT.TotCost;

            ItemList.PayType = PayTypes.Balanced;
            ItemList.IsBaby = false;
            ItemList.BalanceNO = 0;
            ItemList.BalanceState = "0";
            //可退数量
            ItemList.NoBackQty = item.Qty;

            //操作员
            ItemList.FeeOper.ID = operCode;
            ItemList.ChargeOper.ID = operCode;
            ItemList.ChargeOper.OperTime = dtNow;
            ItemList.FeeOper.OperTime = dtNow;

            #region {3C6A1DD7-7522-418b-89A5-4B973ED320C3}
            ItemList.FT.OwnCost = ItemList.FT.TotCost;
            ItemList.TransType = TransTypes.Positive;
            #endregion

            //调用收费函数
            return this.FeeItem(pInfo, ItemList);
        }

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        /// <summary>
        /// 根据处方号执行科室查找药品
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="deptCode">执行科室</param>
        /// <returns></returns>
        public int GetDrugUnFeeCount(string recipeNO, string deptCode)
        {
            this.SetDB(outpatientManager);
            return outpatientManager.GetDrugUnFeeCount(recipeNO, deptCode);
        }

        #endregion

        //{645F3DDE-4206-4f26-9BC5-307E33BD882C}
        #region 日结后收费判断

        /// <summary>
        /// 日结后收费判断设置
        /// </summary>
        /// <param name="feeOperCode">收款员编码</param>
        /// <param name="isInpatient">是否住院</param>
        /// <param name="errTxt">错误信息</param>
        /// <returns></returns>
        public bool AfterDayBalanceCanFee(string feeOperCode,bool isInpatient,ref string errTxt)
        {
            string canFeeType = controlParamIntegrate.GetControlParam<string>("100035", true, "0");
            //不判断
            if (canFeeType == "0")
            {
                return true;
            }
            else
            {
                bool returnValue = false;
                DateTime now = empowerFeeManager.GetDateTimeFromSysDateTime();
                DateTime begin = Neusoft.FrameWork.Function.NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 00:00:00");
                DateTime end = Neusoft.FrameWork.Function.NConvert.ToDateTime(now.ToString("yyyy-MM-dd") + " 23:59:59");
                if (isInpatient)
                {
                    returnValue = empowerFeeManager.QueryIsDayBalance(feeOperCode,begin.ToString(),end.ToString());
                }
                if (returnValue)
                {
                    //日结后不许继续收费
                    if (canFeeType == "1")
                    {
                        errTxt = "日结后不可以再收费!";
                        return false;
                    }
                    //日结后只有财务授权后才可收费
                    if (canFeeType == "2")
                    {
                        //是否授权
                        if (empowerFeeManager.QueryIsEmpower(feeOperCode))
                        {
                            return true;
                        }
                        else
                        {
                            errTxt = "日结后没有经过授权不许收费！";
                            return false;
                        }
                    }

                }
            }

            return true;
        }
        

        #endregion

        #region 郑大账户新增{C4259A87-6EFC-4f7a-8D7E-3FB0DF9B58E0}
        public int InsertAccountCard(Neusoft.HISFC.Models.Account.AccountCard accountCard)
        {
            this.SetDB(accountManager);
            return accountManager.InsertAccountCard(accountCard);
        }

        public int InsertAccountCardRecord(Neusoft.HISFC.Models.Account.AccountCardRecord accountCardRecord)
        {
            this.SetDB(accountManager);
            return accountManager.InsertAccountCardRecord(accountCardRecord);
        }
        #endregion
        #region 郑大新增：获取终端确认状态 {B98851B0-9C5A-4d68-ABB5-CB48C4DBD34B}
        /// <summary>
        /// 获取终端确认状态
        /// </summary>
        /// <param name="execsql">执行单流水号</param>
        /// <returns>false： 没有确认 true：已经确认</returns>
        public bool GetTecFlag(string execsql) {
            return inpatientManager.GetTecFlag(execsql);
        }
        #endregion

    }

    ///// <summary>
    ///// [功能描述: 门诊帐户预交金打印]<br></br>
    ///// [创 建 者: 路志鹏]<br></br>
    ///// [创建时间: 2006-6-22]<br></br>
    ///// <修改记录
    /////		修改人=''
    /////		修改时间=''
    /////		修改目的=''
    /////		修改描述=''
    /////  />
    ///// </summary>
    //public interface IAccountPrint
    //{
    //    /// <summary>
    //    /// 设置打印数据
    //    /// </summary>
    //    /// <param name="account">帐户实体</param>
    //    /// <returns></returns>
    //    int PrintSetValue(Neusoft.HISFC.Models.Account.Account account);
    //    /// <summary>
    //    /// 打印
    //    /// </summary>
    //    /// <returns></returns>
    //    int Print();
    //}

    //public interface IFeeOweMessage
    //{
    //    /// <summary>
    //    /// 欠费提示
    //    /// </summary>
    //    /// <param name="patient">患者信息</param>
    //    /// <param name="ft">费用信息</param>
    //    /// <param name="feeItemLists">费用明细</param>
    //    /// <param name="type">欠费提示类型</param>
    //    /// <param name="err">提示信息</param>
    //    /// <returns>true:成功 false:函数内部报错</returns>
    //    //{2518013C-40B2-4693-B494-3DE193C002FF} //增加处理明细
    //    bool FeeOweMessage(Neusoft.HISFC.Models.RADT.PatientInfo patient, FT ft,System.Collections.ArrayList feeItemLists,ref Fee.MessType type, ref string err);
    //}
}

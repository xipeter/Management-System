using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Base;
using System.Data;

namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 药品组合业务类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-10]<br></br>
    /// <修改记录>
    ///    1.修改生成返回入出库单号中非数字字符处理的BUG by Sunjh 2010-8-17 {FA29FD4A-7379-49ae-847E-ED4BAB67E815}
    ///    2.住院摆药性能优化【修改撤销，为了不影响住院摆药之外的出库库存判断】 by Sunjh 2010-8-30 {32F6FA1C-0B8E-4b9c-83B6-F9626397AC7C}
    ///    3.兼容住院集中发药相关 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
    ///    4.取消更新方式的终端处方调剂，采用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
    /// </修改记录>
    /// </summary>
    public class Pharmacy : IntegrateBase
    {
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static Pharmacy()
        {

        }

        #region 静态量

        /// <summary>
        /// 住院摆药是否需要核准
        /// </summary>
        internal static bool IsNeedApprove = false;

        /// <summary>
        /// 住院摆药同时计费
        /// </summary>
        internal static bool IsApproveCharge = false;

        /// <summary>
        /// 住院退药是否需要核准
        /// </summary>
        internal static bool IsReturnNeedApprove = false;

        /// <summary>
        /// 住院退药同时退费
        /// </summary>
        internal static bool IsReturnCharge = false;

        /// <summary>
        /// 门诊是否预出库
        /// </summary>
        internal static bool IsClinicPreOut = false;

        /// <summary>
        /// 住院是否预出库
        /// </summary>
        internal static bool IsInPatientPreOut = false;

        /// <summary>
        /// 协定处方是否管理库存
        /// </summary>
        internal static bool isNostrumManageStore;

        private string originalOutBillCode = string.Empty;
        #endregion

        #region SetDB 函数 用于 保证对 Err信息可以通过Integrate直接获取 不必调用业务层

        #endregion

        #region 变量

        /// <summary>
        /// 事务设置
        /// </summary>
        /// <param name="trans"></param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            ctrlMgr.SetTrans(trans);
            ctrlIntegrate.SetTrans(trans);
            itemManager.SetTrans(trans);
            drugStoreManager.SetTrans(trans);
            feeInpatientManager.SetTrans(trans);
            radtIntegrate.SetTrans(trans);
        }

        /// <summary>
        /// 药品管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        
        /// <summary>
        /// 药房管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        /// <summary>
        /// 常数管理类
        /// </summary>
        protected Neusoft.FrameWork.Management.ControlParam ctrlMgr = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// 常数管理类
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 费用管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 管理类
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new RADT();

        protected Neusoft.HISFC.BizLogic.Fee.Outpatient OutPatientfeeManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

        /// <summary>
        /// 挂号综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();

        /// <summary>
        /// 常数管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Constant constantMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();
        #endregion

        #region 控制参数获取

        /// <summary>
        /// 根据控制值获取控制参数并返回布尔值 1 为True 否则为False
        /// </summary>
        /// <param name="controlCode">控制值</param>
        /// <param name="isRefresh">是否刷新重取</param>
        /// <returns></returns>
        public bool QueryControlForBool(string controlCode, bool isRefresh)
        {           
            string ctrlStr = ctrlMgr.QueryControlerInfo(controlCode, isRefresh);
            if (ctrlStr == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据控制值获取控制参数
        /// </summary>
        /// <param name="controlCode">控制值</param>
        /// <param name="isRefresh">是否刷新重取</param>
        /// <returns></returns>
        public string QueryControlForStr(string controlCode, bool isRefresh)
        {
            string ctrlStr = ctrlMgr.QueryControlerInfo(controlCode, isRefresh);
            return ctrlStr;
        }
        #endregion

        #region 权限判断

        /// <summary>
        /// 判断某操作员是否有某一权限
        /// </summary>
        /// <param name="class2Code">二级权限编码</param>
        /// <returns>存在权限返回True 无权限返回False</returns>
        public static bool ChoosePiv(string class2Code)
        {
            List<Neusoft.FrameWork.Models.NeuObject> al = null;
            //权限管理类
            Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager privManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();
            //取操作员拥有权限的科室
            al = privManager.QueryUserPriv(privManager.Operator.ID, class2Code);

            if (al == null || al.Count == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 获取常数/扩展信息

        //  1、通用单据号获取函数
        //  2、ApplyOut内获取PrintLabel常数函数
        //  3、DrugRecipe内获取科室地址常数
        //  4、协定处方是否管理库存

        #region 获取通用格式单据号    {59C9BD46-05E6-43f6-82F3-C0E3B53155CB} 入出库单号获取规则修改

        /// <summary>
        /// 入出库单据号获取
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="isInListNO">是否入库单号</param>
        /// <returns>成功返回入库单号  失败返回null</returns>
        public string GetInOutListNO(string deptCode, bool isInListNO)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptCons = phaConsManager.QueryDeptConstant(deptCode);

            string listCode = "";
            if (isInListNO)
            {
                listCode = deptCons.InListNO;
            }
            else
            {
                listCode = deptCons.OutListNO;
            }

            if (string.IsNullOrEmpty(listCode))
            {
                //return this.GetCommonListNO(deptCode);
                listCode = this.GetCommonListNOZD(deptCode, isInListNO);
                #region {29920C0A-84E0-4591-A1F7-432C86B32BA6}判断并发
                ArrayList list = null;
                if (isInListNO)
                {
                    list = itemManager.QueryInputInfoByListID(deptCode, listCode, "AAAA", "AAAA");
                }
                else
                {
                    list = itemManager.QueryOutputInfo(deptCode, listCode, "A");                    
                }
                if (list != null && list.Count != 0)
                {
                    listCode = this.GetCommonListNOZD(deptCode, isInListNO);
                }
                return listCode;
                #endregion
            }
            else
            {
                string nextListCode = this.GetNextListSequence(listCode, true);
                if (isInListNO)
                {
                    deptCons.InListNO = nextListCode;
                }
                else
                {
                    deptCons.OutListNO = nextListCode;
                }
                if (phaConsManager.UpdateDeptConstant(deptCons) == -1)
                {
                    this.Err = "生成下一单据号序列发生错误" + phaConsManager.Err;
                    return null;
                }

                return listCode;
            }
        }

        /// <summary>
        /// 入出库单号作废
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="isInListNO">是否入库单号</param>
        /// <param name="cancelListNO">入出单号</param>
        /// <returns>成功返回1 否则-1</returns>
        public int CancelInOutListNO(string deptCode, bool isInListNO, string cancelListNO)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptCons = phaConsManager.QueryDeptConstant(deptCode);

            string nowListCode = "";
            if (isInListNO)
            {
                nowListCode = deptCons.InListNO;
            }
            else
            {
                nowListCode = deptCons.OutListNO;
            }

            string tempListCode = this.GetNextListSequence(nowListCode, false);
            if (string.Compare(tempListCode, cancelListNO) == 0)     //说明已经两个单据号相等 可以正常取消
            {
                if (isInListNO)
                {
                    deptCons.InListNO = tempListCode;
                }
                else
                {
                    deptCons.OutListNO = tempListCode;
                }
                return phaConsManager.UpdateDeptConstant(deptCons);
            }

            this.Err = "下一序列单据号已占用 不能回退";
            return -1;
        }

        /// <summary>
        /// 获取通用单据号 科室编码+YYMMDD+三位流水号
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回新获取的单据号 失败返回null</returns>
        public string GetCommonListNO(string deptCode)
        {
            Neusoft.FrameWork.Management.ExtendParam extentManager = new Neusoft.FrameWork.Management.ExtendParam();
            this.SetDB(extentManager);

            string ListNO = "";
            decimal iSequence = 0;
            DateTime sysDate = extentManager.GetDateTimeFromSysDateTime().Date;

            //获取当前科室的单据最大流水号
            Neusoft.HISFC.Models.Base.ExtendInfo deptExt = extentManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, "ListCode", deptCode);
            if (deptExt == null)
            {
                return null;
            }
            else
            {
                if (deptExt.Item.ID == "")          //当前科室尚无记录 流水号置为1
                {
                    iSequence = 1;
                }
                else                                //当前科室存在记录 根据日期是否为当天 确定流水号是否归1
                {
                    if (deptExt.DateProperty.Date != sysDate)
                    {
                        iSequence = 1;
                    }
                    else
                    {
                        iSequence = deptExt.NumberProperty + 1;
                    }
                }
                //生成单据号
                ListNO = deptCode + sysDate.Year.ToString().Substring(2, 2) + sysDate.Month.ToString().PadLeft(2, '0') + sysDate.Day.ToString().PadLeft(2, '0')
                    + iSequence.ToString().PadLeft(3, '0');

                //保存当前最大流水号
                deptExt.Item.ID = deptCode;
                deptExt.DateProperty = sysDate;
                deptExt.NumberProperty = iSequence;
                deptExt.PropertyCode = "ListCode";
                deptExt.PropertyName = "科室单据号最大流水号";

                if (extentManager.SetComExtInfo(deptExt) == -1)
                {
                    return null;
                }
            }
            return ListNO;
        }

        /// <summary>
        /// 获取通用单据号 "I"/"O" + 科室编码+YYMM+四位流水号{29920C0A-84E0-4591-A1F7-432C86B32BA6}
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="isInListNO">是否入库</param>
        /// <returns>成功返回新获取的单据号 失败返回null</returns>
        public string GetCommonListNOZD(string deptCode, bool isInListNO)
        {
            Neusoft.FrameWork.Management.ExtendParam extentManager = new Neusoft.FrameWork.Management.ExtendParam();
            this.SetDB(extentManager);

            string ListNO = "";
            decimal iSequence = 0;
            DateTime sysDate = extentManager.GetDateTimeFromSysDateTime().Date;

            //获取当前科室的单据最大流水号
            Neusoft.HISFC.Models.Base.ExtendInfo deptExt = extentManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, "ListCode", deptCode);
            if (deptExt == null)
            {
                return null;
            }
            else
            {
                if (deptExt.Item.ID == "")          //当前科室尚无记录 流水号置为1
                {
                    iSequence = 1;
                }
                else                                //当前科室存在记录 根据日期是否为当天 确定流水号是否归1
                {
                    if (deptExt.DateProperty.Month != sysDate.Month)
                    {
                        iSequence = 1;
                    }
                    else
                    {
                        iSequence = deptExt.NumberProperty + 1;
                    }
                }
                //生成单据号
                if (isInListNO)
                {
                    ListNO = "I" + deptCode + sysDate.Year.ToString().Substring(2, 2) + sysDate.Month.ToString().PadLeft(2, '0')
                        + iSequence.ToString().PadLeft(4, '0');
                }
                else
                {
                    ListNO = "O" + deptCode + sysDate.Year.ToString().Substring(2, 2) + sysDate.Month.ToString().PadLeft(2, '0')
                        + iSequence.ToString().PadLeft(4, '0');
                }

                //保存当前最大流水号
                deptExt.Item.ID = deptCode;
                deptExt.DateProperty = sysDate;
                deptExt.NumberProperty = iSequence;
                deptExt.PropertyCode = "ListCode";
                deptExt.PropertyName = "科室单据号最大流水号";

                if (extentManager.SetComExtInfo(deptExt) == -1)
                {
                    return null;
                }
            }
            return ListNO;
        }

        /// <summary>
        /// 根据字符串获取下一个单据号的数值部分
        /// </summary>
        /// <param name="listCode"></param>
        /// <returns></returns>
        private string GetNextListSequence(string listCode, bool isAddSequence)
        {
            string listNum = "";
            string listStr = "";
            //修改生成返回入出库单号中非数字字符处理的BUG by Sunjh 2010-8-17 {FA29FD4A-7379-49ae-847E-ED4BAB67E815}
            int numIndex = 0;//listCode.Length;
            for (int i = listCode.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(listCode[i]))
                {
                    listNum = listCode[i] + listNum;
                }
                else
                {
                    numIndex = i + 1;       //序列部分截至位置
                    break;
                }
            }

            listStr = listCode.Substring(0, numIndex);

            if (string.IsNullOrEmpty(listNum))
            {
                this.Err = "单据号格式不规范 无法继续获取下一序列";
                return null;
            }
            else
            {
                int listNumLength = listNum.Length;
                string nextListNum = "";
                if (isAddSequence)
                {
                    nextListNum = ((Neusoft.FrameWork.Function.NConvert.ToDecimal(listNum) + 1).ToString()).PadLeft(listNumLength, '0');
                }
                else
                {
                    nextListNum = ((Neusoft.FrameWork.Function.NConvert.ToDecimal(listNum) - 1).ToString()).PadLeft(listNumLength, '0');
                }
                
                return listStr + nextListNum;
            }
        }

        #endregion

        #region 根据Sql索引获取单据号 用处不大。暂时保留

        /// <summary>
        /// 按照日期加流水号方式生成新单据号
        /// </summary>
        /// <param name="sqlStr">获取已有最大流水号的sql索引</param>
        /// <param name="dateFormat">日期格式化生成方式 YYYY MM DD 年月日 </param>
        /// <param name="iNum">流水号位数</param>
        /// <param name="formatStr">sql语句格式化字符串</param>
        /// <returns>成功返回单据号 失败返回null</returns>
        public string GetCommonListNO(string sqlStr, string dateFormat, int iNum, params string[] formatStr)
        {
            Neusoft.FrameWork.Management.ExtendParam extentManager = new Neusoft.FrameWork.Management.ExtendParam();

            string strSQL = "";
            string tempDate, tempList;
            //获取日期格式化字符串
            try
            {
                tempDate = extentManager.GetDateTimeFromSysDateTime().ToString(dateFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化日期字符串存在错误！请注意大小写" + ex.Message;
                return null;
            }
            //取已有的最大单号
            if (extentManager.Sql.GetSql(sqlStr, ref strSQL) == -1)
            {
                this.Err = "没有找到" + sqlStr + "字段!";
                return null;
            }
            //格式化SQL语句
            try
            {
                strSQL = string.Format(strSQL, formatStr);
            }
            catch (Exception ex)
            {
                this.Err = "格式化SQL语句时出错Pharmacy.Item.GetMaxBillCode:" + ex.Message;
                return null;
            }
            //执行SQL语句
            try
            {
                this.Err = "";
                tempList = extentManager.ExecSqlReturnOne(strSQL);
                if (tempList == "-1")
                {
                    this.Err = "SQL语句执行出错" + this.Err;
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.Err = "SQL语句执行出错" + ex.Message;
                return null;
            }
            //设置单据号
            if (tempList.ToString() == "-1" || tempList.ToString() == "")
            {
                tempList = "1".PadLeft(iNum, '0');
            }
            else
            {
                if (tempList.Length < iNum)
                {
                    this.Err = "指定流水号位数过长 与已有单据号冲突";
                    return null;
                }
                decimal i = Neusoft.FrameWork.Function.NConvert.ToDecimal(tempList.Substring(tempList.Length - iNum, iNum)) + 1;
                tempList = i.ToString().PadLeft(iNum, '0');
            }
            return tempDate + tempList;
        }

        /// <summary>
        /// 按照日期加流水号方式生成新单据号 默认格式 YYMMDD + 三位流水号
        /// </summary>
        /// <param name="sqlStr">获取已有最大流水号的sql索引</param>
        /// <param name="formatStr">sql语句格式化字符串</param>
        /// <returns>成功返回单据号 失败返回null</returns>
        public string GetCommonListNO(string sqlStr, params string[] formatStr)
        {
            return this.GetCommonListNO(sqlStr, "yyMMdd", 3, formatStr);
        }

        /// <summary>
        /// 按照日期加流水号方式生成新单据号，默认格式 YYMMDD ＋ 三位流水号
        /// </summary>
        /// <param name="sqlStr">获取已有最大单据号的sql索引 默认格式化参数为 科室编码  + 符合单据格式的当日最小单据 yyMMdd000</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回单据号 失败返回null</returns>
        public string GetCommonListNO(string sqlStr, string deptCode)
        {
            Neusoft.FrameWork.Management.ExtendParam extentManager = new Neusoft.FrameWork.Management.ExtendParam();

            string tempDate;
            //获取日期格式化字符串
            try
            {
                tempDate = extentManager.GetDateTimeFromSysDateTime().ToString("yyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            catch (Exception ex)
            {
                this.Err = "格式化日期字符串存在错误！请注意大小写" + ex.Message;
                return null;
            }
            return this.GetCommonListNO(sqlStr, deptCode, tempDate);
        }

        #endregion

        /// <summary>
        /// 获取控制参数 协定处方是否管理库存  默认管理库存
        /// 如管理库存 则协定处方药品与普通药品类似。可进行入出库、调价。收费不拆分明细
        /// 否则 协定处方药品不能进行入出库、调价操作。收费拆分明细
        /// </summary>
        public static bool IsNostrumManageStore
        {
            get
            {
                if (isNostrumManageStore == null)
                {
                    Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                    isNostrumManageStore = ctrlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Nostrum_Manage_Store, false, true);
                    return isNostrumManageStore;
                }
                return isNostrumManageStore;
            }
        }

        #endregion

        #region 住院摆药方法

         /// <summary>
        /// 住院摆药
        /// </summary>
        /// <param name="alApplyOut">待发药申请信息</param>
        /// <param name="drugMessage">摆药通知，用来更新摆药通知(摆药后产生的摆药单保存在drugMessage.DrugBillClass.Memo中)</param>
        /// <param name="arkDept">药柜科室</param>
        /// <param name="approveDept">核准科室 为空值时设置为当前科室</param>
        /// <param name="trans">外部传入事务 为空值时将自动建立事务</param>
        /// <returns></returns>
        public int InpatientDrugConfirm(ArrayList alApplyOut, Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage, Neusoft.FrameWork.Models.NeuObject arkDept, Neusoft.FrameWork.Models.NeuObject approveDept)
        {
            return InpatientDrugConfirm(alApplyOut, drugMessage, arkDept, approveDept, null);
        }

        /// <summary>
        /// 住院摆药
        /// </summary>
        /// <param name="alApplyOut">待发药申请信息</param>
        /// <param name="drugMessage">摆药通知，用来更新摆药通知(摆药后产生的摆药单保存在drugMessage.DrugBillClass.Memo中)</param>
        /// <param name="arkDept">药柜科室</param>
        /// <param name="approveDept">核准科室 为空值时设置为当前科室</param>
        /// <param name="trans">外部传入事务 为空值时将自动建立事务</param>
        /// <returns></returns>
        public int InpatientDrugConfirm(ArrayList alApplyOut, Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage, Neusoft.FrameWork.Models.NeuObject arkDept, Neusoft.FrameWork.Models.NeuObject approveDept,System.Data.IDbTransaction trans)
        {            
            if (trans == null)      //开启事务
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            }

            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 数据库连接传递 事务声明
            Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrateManager = new Fee();
            Neusoft.HISFC.BizLogic.Fee.InPatient feeManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
            Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new RADT();

            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  Integrate需要调用SetTrans
            feeIntegrateManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            radtIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            ctrlParamIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #endregion

            #region 获取摆药单号

            int parm = 0;

            //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
            string drugBillID = "";
            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
            if (isNursePrint)
            {
                if (alApplyOut != null && alApplyOut.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = alApplyOut[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    drugBillID = applyOut.DrugNO;
                }
                else
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrateManager.Rollback();
                        //Neusoft.NFC.Management.PublicTrans.RollBack();
                    }
                    this.Err = "获取摆药单流水号发生错误" + itemManager.Err;
                    return -1;
                }

                if (drugMessage != null)
                {
                    //在摆药通知中保存摆药单号,可以返回给调用者
                    drugMessage.DrugBillClass.Memo = drugBillID;
                }
            }
            else
            {
                drugBillID = this.itemManager.GetNewDrugBillNO();
                if (drugBillID == null)
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrateManager.Rollback();
                        //Neusoft.NFC.Management.PublicTrans.RollBack();
                    }
                    this.Err = "获取摆药单流水号发生错误" + itemManager.Err;
                    return -1;
                }
                if (drugMessage != null)
                {
                    //在摆药通知中保存摆药单号,可以返回给调用者
                    drugMessage.DrugBillClass.Memo = drugBillID;
                }
            }
            ////取摆药单流水号（出库申请表中的摆药单号）
            //string drugBillID = this.itemManager.GetNewDrugBillNO();
            //if (drugBillID == null)
            //{
            //    if (trans == null)      //事务由本函数内部开启
            //    {
            //        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
            //        feeIntegrateManager.Rollback();
            //        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    }
            //    this.Err = "获取摆药单流水号发生错误" + itemManager.Err;
            //    return -1;
            //}
            //if (drugMessage != null)
            //{
            //    //在摆药通知中保存摆药单号,可以返回给调用者
            //    drugMessage.DrugBillClass.Memo = drugBillID;
            //}

            //取系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            #endregion

            //摆药时收费项目
            ArrayList alFee = new ArrayList();
            //存储患者信息
            System.Collections.Hashtable hsPatient = new Hashtable();
            //本次摆药药品信息
            System.Collections.Hashtable hsDrugMinFee = new Hashtable();
            //住院摆药是否需核准 默认需核准 原控制参数编码  501001
            Pharmacy.IsNeedApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Need_Approve, true, true);

            //住院摆药性能优化【修改撤销，为了不影响住院摆药之外的出库库存判断】 by Sunjh 2010-8-30 {32F6FA1C-0B8E-4b9c-83B6-F9626397AC7C}
            #region 住院摆药性能优化

            //System.Collections.Hashtable hsDrugStorage = new Hashtable();
            //ArrayList alDrugStorage = new ArrayList();
            //int iCount = 0;
            //foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOutTemp in alApplyOut)
            //{
            //    if (hsDrugStorage.ContainsKey(applyOutTemp.StockDept.ID + applyOutTemp.Item.ID))
            //    {
            //        Neusoft.FrameWork.Models.NeuObject objTemp = alDrugStorage[Convert.ToInt32(hsDrugStorage[applyOutTemp.StockDept.ID + applyOutTemp.Item.ID])] as Neusoft.FrameWork.Models.NeuObject;
            //        objTemp.User01 = Convert.ToString(Convert.ToDecimal(objTemp.User01) + applyOutTemp.Operation.ApplyQty * applyOutTemp.Days);
            //    }
            //    else
            //    {
            //        Neusoft.FrameWork.Models.NeuObject objTemp = new NeuObject();
            //        objTemp.ID = applyOutTemp.Item.ID;
            //        objTemp.Name = applyOutTemp.Item.Name;                    
            //        objTemp.Memo = applyOutTemp.StockDept.ID;
            //        objTemp.User01 = Convert.ToString(applyOutTemp.Operation.ApplyQty * applyOutTemp.Days);
            //        alDrugStorage.Add(objTemp);
            //        hsDrugStorage.Add(applyOutTemp.StockDept.ID + applyOutTemp.Item.ID, iCount);
            //        iCount++;
            //    }
            //}

            //Neusoft.FrameWork.Management.ControlParam ctrlManager = new Neusoft.FrameWork.Management.ControlParam();
            //string negativeStore = ctrlManager.QueryControlerInfo("S00024", false);
            //bool isMinusStore = Neusoft.FrameWork.Function.NConvert.ToBoolean(negativeStore);

            //for (int i = 0; i < alDrugStorage.Count; i++)
            //{
            //    decimal storageNum = 0;
            //    decimal totalNum = 0;
            //    Neusoft.FrameWork.Models.NeuObject objTemp = alDrugStorage[i] as Neusoft.FrameWork.Models.NeuObject;
            //    if (this.GetStorageNum(objTemp.Memo, objTemp.ID, out storageNum) == -1)
            //    {
            //        return -1;
            //    }
            //    //判断库存是否不足，退库允许没有库存或者不足
            //    if ((isMinusStore == false) && (storageNum < Convert.ToDecimal(objTemp.User01)) && (Convert.ToDecimal(objTemp.User01) > 0))
            //    {
            //        this.Err = objTemp.Name + "的库存数量不足。请补充库存";
            //        this.ErrCode = "2";
            //        return -1;
            //    }
            //}

            #endregion

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alApplyOut)
            {
                #region 实体字段赋值

                applyOut.Operation.ApproveQty = applyOut.Operation.ApplyQty;
                if (approveDept != null && approveDept.ID != "")
                {
                    applyOut.Operation.ApproveOper.Dept = approveDept;
                }
                else
                {
                    applyOut.Operation.ApproveOper.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)itemManager.Operator).Dept.ID;
                }

                applyOut.Operation.ExamOper.OperTime = sysTime;
                applyOut.Operation.ExamOper.ID = ((Neusoft.HISFC.Models.Base.Employee)itemManager.Operator).ID;
                applyOut.Operation.ExamOper.Dept = applyOut.Operation.ApproveOper.Dept;

                //获取科室库存信息 获得货位号               
                //Neusoft.HISFC.Models.Pharmacy.Storage storage;
                //storage = itemManager.GetStockInfoByDrugCode(applyOut.Operation.ApproveOper.Dept.ID, applyOut.Item.ID);
                //if (storage == null)
                //{
                //    if (trans == null)      //事务由本函数内部开启
                //    {
                //        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                //        feeIntegrateManager.Rollback();
                //        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    }
                //    this.Err = "获取库存信息出错" + this.itemManager.Err;
                //    return 0;
                //}
                //applyOut.PlaceNO = storage.PlaceNO;

                //住院摆药性能优化 by Sunjh 2010-8-30 {32F6FA1C-0B8E-4b9c-83B6-F9626397AC7C}
                applyOut.PlaceNO = this.itemManager.GetPlaceNoOptimize(applyOut.Operation.ApproveOper.Dept.ID, applyOut.Item.ID);

                #endregion

                #region 根据是否需要核准 进行申请信息状态赋值

                if (Pharmacy.IsNeedApprove)
                {
                    applyOut.State = "1";
                }
                else
                {
                    //表示核准出库 
                    applyOut.State = "2";
                    applyOut.Operation.ApproveOper.OperTime = sysTime;
                    applyOut.Operation.ApproveOper.ID = ((Neusoft.HISFC.Models.Base.Employee)itemManager.Operator).ID;

                }
                #endregion

                #region 出库处理
                applyOut.DrugNO = drugBillID;
                applyOut.PrivType = "Z1";
                if (arkDept != null && arkDept.ID != "")
                {
                    parm = itemManager.ArkOutput(applyOut, arkDept);
                    if (parm == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }

                        if (this.ErrCode == "2")
                            this.Err = this.itemManager.Err;
                        else
                            this.Err = "药品出库失败:" + this.itemManager.Err;

                        return -1;
                    }
                }
                else
                {
                    parm = itemManager.Output(applyOut);
                    if (parm == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }

                        if (this.ErrCode == "2")
                            this.Err = this.itemManager.Err;
                        else
                            this.Err = "药品出库失败:" + this.itemManager.Err;

                        return -1;
                    }
                }
                #endregion

                #region 是否需要进行计费处理 对需要收费 调用收费函数 更新费用档发药标记

                if (!applyOut.IsCharge)
                {
                    #region 患者信息赋值处理
                    Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
                    if (hsPatient.ContainsKey(applyOut.PatientNO))
                    {
                        patient = hsPatient[applyOut.PatientNO] as Neusoft.HISFC.Models.RADT.PatientInfo;
                    }
                    else
                    {
                        patient = radtIntegrate.QueryPatientInfoByInpatientNO(applyOut.PatientNO);
                        hsPatient.Add(applyOut.PatientNO, patient);
                    }
                    //{389D4EDA-B312-492a-8EDA-B9D0F9A30041} 判断患者是否在院
                    if (patient.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = patient.Name + " 患者非在院状态，不能进行发药收费操作";
                        return -1;
                    }

                    #endregion

                    #region 药品信息赋值处理
                    if (hsDrugMinFee.ContainsKey(applyOut.Item.ID))
                    {
                        applyOut.Item.MinFee = hsDrugMinFee[applyOut.Item.ID] as Neusoft.FrameWork.Models.NeuObject;
                    }
                    else
                    {
                        Neusoft.HISFC.Models.Pharmacy.Item item = itemManager.GetItem(applyOut.Item.ID);
                        applyOut.Item.MinFee = item.MinFee;
                        hsDrugMinFee.Add(applyOut.Item.ID, item.MinFee);
                    }
                    #endregion

                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem = this.ConvertApplyOutToFeeItem(applyOut);

                    if (feeIntegrateManager.FeeItem(patient, feeItem) == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = feeIntegrateManager.Err;
                        return -1;
                    }

                    //向药品回写收费标记 处方号 流水号
                    applyOut.IsCharge = true;
                    applyOut.RecipeNO = feeItem.RecipeNO;
                    applyOut.SequenceNO = feeItem.SequenceNO;
                }

                #region 更新费用发药标记
                try
                {
                    parm = feeManager.UpdateMedItemExecInfo(
                        applyOut.RecipeNO,							//处方号
                        applyOut.SequenceNO,						//处方内流水号
                        Convert.ToInt32(applyOut.OutBillNO),      //更新库存流水号
                        Convert.ToInt32(applyOut.OutBillNO),      //出库单序列号
                        applyOut.StockDept.ID,						//摆药科室
                        applyOut.Operation.ExamOper.ID,					//摆药人
                        sysTime);							//摆药时间
                    if (parm == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = "更新费用明细信息出错!" + itemManager.Err + " 处方号" + applyOut.RecipeNO;
                        return -1;
                    }
                    if (parm == 0)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = "更新费用明细信息失败! 未找到相应的费用明细信息\n" + "处方号" + applyOut.RecipeNO;
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrateManager.Rollback();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    this.Err = "更新费用明细信息出错" + ex.Message;
                    return -1;
                }
                #endregion

                #endregion

                #region 医嘱执行档发药更新  目前流程屏蔽对医嘱执行挡的状态更新

                if (applyOut.ExecNO != "")
                {
                    parm = orderManager.UpdateOrderDruged(applyOut.ExecNO, applyOut.OrderNO, orderManager.Operator.ID, applyOut.Operation.ApproveOper.Dept.ID);
                    if (parm == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = string.Format("更新药品医嘱执行档出错！错误信息:{0} \n药品名称:{1} 执行单流水号:{2} 医嘱流水号:{3}", orderManager.Err, applyOut.Item.Name, applyOut.ExecNO, applyOut.OrderNO);
                        return -1;
                    }
                }

                #endregion

                #region 更新出库申请表中的摆药信息

                applyOut.DrugNO = drugBillID;
                //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                if (isNursePrint)
                {
                    parm = this.itemManager.ExamApplyOutByNursePrint(applyOut);
                }
                else
                {
                    parm = this.itemManager.ExamApplyOut(applyOut);
                }
                //parm = this.itemManager.ExamApplyOut(applyOut);
                if (parm != 1)
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrateManager.Rollback();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    if (parm == 0)
                    {
                        this.Err = "当前数据已作废或者已被其他程序确认，程序将刷新当前数据";
                        return 0;
                    }
                    else
                    {
                        this.Err = "审核摆药申请信息发生错误" + itemManager.Err;
                    }
                    return -1;
                }
                #endregion
            }


            if (drugMessage != null)
            {
                #region 摆药通知处理

                //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                List<Neusoft.FrameWork.Models.NeuObject> al = new List<NeuObject>();
                if (isNursePrint)
                {
                    al = itemManager.QueryApplyOutPatientListByBill(drugMessage);
                }
                else
                {
                    al = itemManager.QueryApplyOutPatientList(drugMessage);
                }
                //List<Neusoft.FrameWork.Models.NeuObject> al = itemManager.QueryApplyOutPatientList(drugMessage);
                if (al == null)
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrateManager.Rollback();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    this.Err = "查询摆药申请GetApplyOutPatientList时出错！" + itemManager.Err;
                    return -1;
                }

                //如果全部核准(没有待摆药数据)，则更新摆药通知信息。否则不更新摆药通知信息
                if (al.Count == 0)
                {
                    //摆药标记置为已摆药：摆药标记0-通知1-已摆
                    drugMessage.SendFlag = 1;
                    if (drugStoreManager.SetDrugMessage(drugMessage) == -1)
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrateManager.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = "更新摆药通知时出错！" + drugStoreManager.Err;
                        return -1;
                    }
                }
                #endregion
            }

            if (trans == null)      //事务由本函数内部开启
            {
                //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用FeeIntegrate的Commit
                //Neusoft.FrameWork.Management.PublicTrans.Commit();
                feeIntegrateManager.Commit();
            }

            return 1;
        }

         /// <summary>
        /// 对已打印的摆药单进行核准处理（摆药核准）
        /// </summary>
        /// <param name="alApplyOut">出库申请信息</param>
        /// <param name="approveOperCode">核准人（摆药人）</param>
        /// <param name="deptCode">核准科室</param>
        /// <returns>1成功，-1失败</returns>
        public int InpatientDrugApprove(ArrayList alApplyOut, string approveOperCode, string deptCode)
        {
            return InpatientDrugApprove(alApplyOut, approveOperCode, deptCode, null);
        }
        /// <summary>
        /// 对已打印的摆药单进行核准处理（摆药核准）
        /// </summary>
        /// <param name="alApplyOut">出库申请信息</param>
        /// <param name="approveOperCode">核准人（摆药人）</param>
        /// <param name="deptCode">核准科室</param>
        /// <param name="trans">外部传入事务，传入空值时 将自动建立事务</param>
        /// <returns>1成功，-1失败</returns>
        public int InpatientDrugApprove(ArrayList alApplyOut, string approveOperCode, string deptCode,System.Data.IDbTransaction trans)
        {
            if (trans == null)      //外部未开启事务
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            }

            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            #region 管理类及事务声明

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            ////定义数据库处理事务
            //Neusoft.FrameWork.Management.Transaction t = null;
            //if (trans == null)
            //{                
            //    t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //    t.BeginTransaction();
            //    this.SetTrans(t.Trans);
            //    ctrlParamIntegrate.SetTrans(t.Trans);
            //}
            //else
            //{
            //    this.SetTrans(trans);
            //    ctrlParamIntegrate.SetTrans(trans);
            //}
            #endregion

            //住院摆药是否需核准 默认需核准 原控制参数编码  501001
            Pharmacy.IsNeedApprove = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Need_Approve, true, true);
            if (!Pharmacy.IsNeedApprove)
            {
                return 1;
            }

            DateTime sysDate = this.itemManager.GetDateTimeFromSysDateTime();
            //对摆药单进行核准处理
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alApplyOut)
            {
                #region 核准数据赋值
                //不处理作废的数据
                if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    applyOut.State = "2";                  //表示已核准
                    applyOut.Operation.ApproveOper.ID = approveOperCode; //核准人
                    applyOut.Operation.ApproveOper.Dept.ID = deptCode;        //核准科室
                    applyOut.Operation.ApproveOper.OperTime = sysDate;         //核准时间
                }
                #endregion

                #region 核准摆药单
                int parm = 0;
                parm = this.itemManager.ApproveApplyOut(applyOut);
                if (parm != 1)
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    if (parm == 0)
                    {
                        this.Err = "不能重复核准摆药单！程序将刷新当前数据";
                        return 0;
                    }
                    else
                    {
                        this.Err = "出库申请信息核准出错!";
                    }
                    return -1;
                }
                #endregion
            }

            if (trans == null)      //事务由本函数内部开启
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }

            return 1;
        }

        /// <summary>
        /// 对退药申请进行核准处理（退药核准）
        /// </summary>
        /// <param name="alApplyOut">出库申请信息</param>
        /// <param name="drugMessage">摆药通知，用来更新摆药通知(摆药后产生的摆药单保存在drugMessage.DrugBillClass.Memo中)</param>
        /// <param name="arkDept">药柜科室</param>
        /// <returns>1成功，-1失败</returns>
        public int InpatientDrugReturnConfirm(ArrayList alApplyOut, Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage,Neusoft.FrameWork.Models.NeuObject arkDept,Neusoft.FrameWork.Models.NeuObject approveDept)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 管理类声明

            //退费申请管理类
            Neusoft.HISFC.BizLogic.Fee.ReturnApply applyReturn = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

            //费用组合管理类
            Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Fee();

            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处Integrate需SetTrans
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //this.SetTrans(t.Trans);
            //applyReturn.SetTrans(t.Trans); 
            //feeIntegrate.SetTrans(t.Trans);

            #endregion

            //费用实体
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
            //患者实体类
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

            #region 取摆药单流水号（出库申请表中的摆药单号）

            //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
            bool isNursePrint = this.ctrlIntegrate.GetControlParam<bool>("P01016", true, false);
            string drugBillID = "";
            if (isNursePrint)
            {
                if (alApplyOut != null && alApplyOut.Count > 0)
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = alApplyOut[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    drugBillID = applyOut.DrugNO;
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    feeIntegrate.MedcareInterfaceRollback();
                    this.Err = this.itemManager.Err;
                    return -1;
                }
            }
            else
            {
                drugBillID = this.itemManager.GetNewDrugBillNO();
                if (drugBillID == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    feeIntegrate.MedcareInterfaceRollback();
                    this.Err = this.itemManager.Err;
                    return -1;
                }
            }
            //string drugBillID = this.itemManager.GetNewDrugBillNO();
            //if (drugBillID == null)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    feeIntegrate.MedcareInterfaceRollback();
            //    this.Err = this.itemManager.Err;
            //    return -1;
            //}
            //在摆药通知中保存摆药单号,可以返回给调用者
            drugMessage.DrugBillClass.Memo = drugBillID;

            //取系统时间
            DateTime sysTime = this.itemManager.GetDateTimeFromSysDateTime();

            #endregion

            //对用户check的数据进行发药处理
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alApplyOut)
            {
                //保存原OUT_BILL_CODE{B0536663-E701-474e-BCE2-BE13D7257EF2}
                this.originalOutBillCode = applyOut.OutBillNO;

                patientInfo = this.radtIntegrate.QueryPatientInfoByInpatientNO(applyOut.PatientNO);

                //{389D4EDA-B312-492a-8EDA-B9D0F9A30041} 判断患者是否在院
                if (patientInfo.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrate.Rollback();

                        
                    }
                    applyOut.OutBillNO = this.originalOutBillCode;
                    this.Err = patientInfo.Name + " 患者非在院状态，不能进行退药退费操作";
                    return -1;
                }

                #region 实体字段赋值
                applyOut.Operation.ApproveQty = applyOut.Operation.ApplyQty;
                applyOut.Operation.ExamOper.OperTime = sysTime;
                applyOut.Operation.ExamOper.ID = itemManager.Operator.ID;		//核准人
                Pharmacy.IsReturnNeedApprove = ctrlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Need_Approve, true, true);
                if (Pharmacy.IsReturnNeedApprove)
                {
                    applyOut.State = "1";		//需核准
                }
                else								//不需核准
                {
                    applyOut.Operation.ApproveOper.ID = itemManager.Operator.ID;	//核准人
                    applyOut.Operation.ApproveOper.OperTime = sysTime;
                    applyOut.State = "2";	//表示核准出库 	
                }
                //更新出库申请表中的摆药信息。
                applyOut.DrugNO = drugBillID;
                if (approveDept != null && approveDept.ID != "")
                {
                    applyOut.Operation.ApproveOper.Dept = approveDept;
                }
                else
                {
                    applyOut.Operation.ApproveOper.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)itemManager.Operator).Dept.ID;
                }
                //退库时,还回预扣的库存
                applyOut.IsPreOut = true;
                #endregion

                #region 退库处理
                applyOut.PrivType = "Z2";
                if (arkDept != null && arkDept.ID != "")
                {
                    if (itemManager.ArkOutput(applyOut,arkDept) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        this.Err = itemManager.Err;
                        return -1;
                    }
                }
                else
                {
                    if (itemManager.Output(applyOut) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        this.Err = itemManager.Err;
                        return -1;
                    }
                }
                #endregion

                #region 退库申请核准

                int parm = 0;
                //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
                if (isNursePrint)
                {
                    parm = this.itemManager.ExamApplyOutByNursePrint(applyOut);
                }
                else
                {
                    parm = this.itemManager.ExamApplyOut(applyOut);
                }
                //parm = this.itemManager.ExamApplyOut(applyOut);
                if (parm != 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    feeIntegrate.MedcareInterfaceRollback();
                    applyOut.OutBillNO = this.originalOutBillCode;
                    if (parm == 0)
                    {
                        this.Err = "当前数据已作废或者已被其他程序确认，程序将刷新当前数据";
                        return 0;
                    }
                    else
                    {
                        this.Err = this.itemManager.Err;
                    }
                    return -1;
                }

                #endregion

                #region 退费后处理费用信息 如不需处理费用 则更新退费申请标记

                //如果退药的同时退费,则处理费用信息
                //Pharmacy.IsReturnCharge = Pharmacy.QueryControlForBool("501003", false);
                Pharmacy.IsReturnCharge = this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_BackFee, false, false);
            
                if (Pharmacy.IsReturnCharge)
                {
                    #region 退费处理   取费用信息

                    //feeItemList = feeInpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, true);
                    feeItemList = feeInpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, Neusoft.HISFC.Models.Base.EnumItemType.Drug);
                    if (feeItemList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        System.Windows.Forms.MessageBox.Show(feeInpatientManager.Err);
                        return -1;
                    }

                    feeItemList.Item.Qty = applyOut.Operation.ApplyQty * applyOut.Days;
                    feeItemList.NoBackQty = 0;
                    feeItemList.FT.TotCost = feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty;
                    feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
                    feeItemList.CancelRecipeNO = applyOut.RecipeNO;
                    feeItemList.CancelSequenceNO = applyOut.SequenceNO;

                    feeItemList.IsNeedUpdateNoBackQty = false;
                    feeItemList.PayType = Neusoft.HISFC.Models.Base.PayTypes.SendDruged;

                    

                    if (feeIntegrate.QuitItem(patientInfo, feeItemList.Clone()) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        this.Err = Neusoft.FrameWork.Management.Language.Msg( "退费失败!" ) + feeIntegrate.Err;
                        return -1;
                    }

                    #endregion
                }
                else
                {
                    #region 生成退费申请

                    patientInfo = this.radtIntegrate.QueryPatientInfoByInpatientNO(applyOut.PatientNO);

                    //取费用信息
                    //feeItemList = feeInpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, true);
                    feeItemList = feeInpatientManager.GetItemListByRecipeNO(applyOut.RecipeNO, applyOut.SequenceNO, EnumItemType.Drug);
                    if (feeItemList == null)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        this.Err = feeInpatientManager.Err;
                        return -1;
                    }

                    //进行退费申请
                    feeItemList.Item.Qty = applyOut.Operation.ApplyQty * applyOut.Days; //退费数量为退药的数量
                    feeItemList.User02 = applyOut.BillNO;						//退费申请单据号
                    feeItemList.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    feeItemList.IsConfirmed = true;

                    parm = applyReturn.Apply(patientInfo, feeItemList, applyOut.Operation.ExamOper.OperTime);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.MedcareInterfaceRollback();
                        applyOut.OutBillNO = this.originalOutBillCode;
                        this.Err = applyReturn.Err;
                        return -1;
                    }

                    #endregion
                }

                #endregion
            }

            #region 摆药通知处理

            //取待摆药患者列表,如果全部核准(没有待摆药数据)，则更新摆药通知信息

            //住院领药单 by Sunjh 2010-11-17 {F667C43C-FA2B-4c94-843D-5C540B6F06F7}
            List<Neusoft.FrameWork.Models.NeuObject> al = new List<NeuObject>();
            if (isNursePrint)
            {
                //QueryApplyOutPatientListByBill
                al = itemManager.QueryApplyOutPatientListByBill(drugMessage);
            }
            else
            {
                al = itemManager.QueryApplyOutPatientList(drugMessage);
            }
            //List<Neusoft.FrameWork.Models.NeuObject> al = itemManager.QueryApplyOutPatientList(drugMessage);
            if (al == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                feeIntegrate.MedcareInterfaceRollback();
                this.Err = "查询摆药申请GetApplyOutPatientList时出错！";
                return -1;
            }

            //如果全部核准(没有待摆药数据)，则更新摆药通知信息。否则不更新摆药通知信息
            if (al.Count == 0)
            {
                //摆药标记置为已摆药：摆药标记0-通知1-已摆
                drugMessage.SendFlag = 1;
                if (drugStoreManager.SetDrugMessage(drugMessage) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    feeIntegrate.MedcareInterfaceRollback();
                    this.Err = "更新摆药通知时出错！";
                    return -1;
                }
            }

            #endregion
            //返回值〈 0 是错误，0是正确的！
            //公费接口提交！
            if (feeIntegrate.MedcareInterfaceCommit() < 0 ) 
            {
                feeIntegrate.MedcareInterfaceRollback();
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "公费接口提交时出错，提交未成功！";
                return -1;
            }
            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用feeIntegrate的Commit
            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            feeIntegrate.Commit();
            return 1;
        }

        /// <summary>
        /// 将药品申请信息转换为费用信息实体
        /// </summary>
        /// <param name="applyOut">药品申请信息</param>
        /// <returns>成功返回费用信息实体 失败返回null</returns>
        internal Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList ConvertApplyOutToFeeItem(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();
            //需进行赋值
            applyOut.Item.Price = applyOut.Item.PriceCollection.RetailPrice;

            feeItemList.Item = applyOut.Item.Clone();
            feeItemList.Item.PriceUnit = applyOut.Item.MinUnit;

            feeItemList.UpdateSequence = (int)Neusoft.FrameWork.Function.NConvert.ToDecimal(applyOut.OutBillNO);
            feeItemList.SendSequence = feeItemList.UpdateSequence;
            
            feeItemList.Item.Qty = applyOut.Operation.ApproveQty * applyOut.Days;
            feeItemList.Days = applyOut.Days;
            feeItemList.StockOper = applyOut.Operation.ExamOper;

            feeItemList.RecipeOper = applyOut.RecipeInfo;
            feeItemList.ExecOper.Dept = applyOut.StockDept;
            feeItemList.ExecOper.ID = applyOut.Operation.Oper.ID;

            feeItemList.FT.TotCost = Neusoft.FrameWork.Public.String.FormatNumber((feeItemList.Item.Price * feeItemList.Item.Qty / feeItemList.Item.PackQty), 2);
            feeItemList.FT.OwnCost = feeItemList.FT.TotCost;
            feeItemList.IsBaby = applyOut.IsBaby;

            feeItemList.Order.ID = applyOut.OrderNO;
            feeItemList.ExecOrder.ID = applyOut.ExecNO;
            feeItemList.NoBackQty = feeItemList.Item.Qty;
            feeItemList.FTRate.OwnRate = 1;
            feeItemList.BalanceState = "0";
            feeItemList.ChargeOper = applyOut.Operation.ExamOper.Clone();
            feeItemList.FeeOper = applyOut.Operation.ExamOper.Clone();
            feeItemList.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;

            return feeItemList;
        }
        #endregion

        #region 门诊配/发药

        /// <summary>
        /// 门诊配药保存
        /// </summary>
        /// <param name="applyOutCollection">摆药申请信息</param>
        /// <param name="terminal">配药终端</param>
        /// <param name="drugedDept">配药科室信息</param>
        /// <param name="drugedOper">配药人员信息</param>
        /// <param name="isUpdateAdjustParam">是否更新处方调剂信息</param>
        /// <returns>配药确认成功返回1 失败返回-1</returns>
        public int OutpatientDrug(List<ApplyOut> applyOutCollection, NeuObject terminal, NeuObject drugedDept, NeuObject drugedOper, bool isUpdateAdjustParam)
        {
            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 账户新增(配药时扣账户)
            //bool isAccountTerminal = ctrlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process, true, false);
            //if (applyOutCollection.Count == 0) return -1;
            //ApplyOut tempApply = applyOutCollection[0];
            ////查询患者挂号信息
            //Neusoft.HISFC.Models.Registration.Register r = registeIntegrate.GetByClinic(tempApply.PatientNO);
            //if (r == null)
            //{
            //    this.Err = "查找患者挂号信息失败！" + registeIntegrate.Err;
            //    return -1;
            //}
            //bool isAccountFee = false;
            //decimal recipeCost = 0m;
            //string recipeNO = string.Empty;
            ///// <summary>
            ///// 费用综合业务层
            ///// </summary>
            //Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Fee();
            //if (isAccountTerminal)
            //{
            //    //是否账户患者
            //    if (r.IsAccount)
            //    {
            //        if (!feeIntegrate.CheckAccountPassWord(r))
            //        {
            //            this.Err = "账户密码输入失败！";
            //            return -1;
            //        }
            //        decimal vacancy = 0m;
            //        if (feeIntegrate.GetAccountVacancy(r.PID.CardNO, ref vacancy) <= 0)
            //        {
            //            this.Err = feeIntegrate.Err;
            //            return -1;
            //        }
            //        Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe = drugStoreManager.GetDrugRecipe(tempApply.StockDept.ID, tempApply.RecipeNO);
            //        if (drugRecipe == null)
            //        {
            //            this.Err = "查询处方调剂信息失败！" + drugStoreManager.Err;
            //            return -1;
            //        }
            //        recipeCost = drugRecipe.Cost;
            //        recipeNO = drugRecipe.RecipeNO;
            //        //在半退时判断使用
            //        int resultValue = feeIntegrate.GetDrugUnFeeCount(recipeNO, tempApply.StockDept.ID);
            //        if (resultValue < 0)
            //        {
            //            this.Err = "查询药品费用信息失败！" + feeIntegrate.Err;
            //            return -1;
            //        }

            //        if (resultValue > 0)
            //        {
            //            if (vacancy < recipeCost)
            //            {
            //                this.Err = "账户金额不足，请交费！";
            //                return -1;
            //            }
            //            isAccountFee = true;
            //        }
            //        else
            //        {
            //            isAccountFee = false;
            //        }

            //    }
            //}
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
            #region 账户新增
            //if (isAccountTerminal && r.IsAccount && isAccountFee)
            //{
            //    string deptCode = (drugStoreManager.Operator as Employee).Dept.ID;
            //    string operCode = drugStoreManager.Operator.ID;
            //    //扣账户金额
            //    if (feeIntegrate.AccountPay(r, recipeCost, "药房摆药", deptCode, string.Empty) < 0)
            //    {
            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //        this.Err = "扣账户金额失败！" + feeIntegrate.Err;
            //        return -1;
            //    }

            //    if (drugStoreManager.UpdateStoRecipeFeeOper(recipeNO, deptCode, operCode) <= 0)
            //    {
            //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //        this.Err = "更新处方调剂信息失败！" + drugStoreManager.Err;
            //        return -1;
            //    }

            //}
            #endregion

            ApplyOut info = new ApplyOut();
            //门诊终端配药数量 对于替代药房的数据不进行统计
            decimal drugedQty = 0;
            for (int i = 0; i < applyOutCollection.Count; i++)
            {
                info = applyOutCollection[i] as ApplyOut;

                //配药确认 更新出库申请表内数据状态
                if (itemManager.UpdateApplyOutStateForDruged(info.StockDept.ID, "M1", info.RecipeNO, info.SequenceNO, "1", drugedOper.ID, info.Operation.ApplyQty) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "更新出库申请数据出错!" + this.itemManager.Err;
                    return -1;
                }
                //存在替代药房的情况 对此种记录不进行更新
                if (info.PrintState != "1" || info.BillClassNO == "")
                    drugedQty++;

                ////{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                #region 账户新增
                //if (isAccountTerminal && r.IsAccount && isAccountFee)
                //{
                //    string errTxt = string.Empty;
                //    if (!feeIntegrate.SaveFeeToAccount(r, info.RecipeNO, info.SequenceNO, ref errTxt))
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //        this.Err = "更新费用明细出错!" + this.itemManager.Err;
                //        return -1;
                //    }
                //}
                #endregion
            }

            if (isUpdateAdjustParam)
            {
                //屏蔽更新语句使用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
                ////更新门诊终端待配药信息 传入-1每次减少1
                //if (drugStoreManager.UpdateTerminalAdjustInfo(terminal.ID, 0, -drugedQty, 0) == -1)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    this.Err = "更新门诊终端已配药信息出错" + this.itemManager.Err;
                //    return -1;
                //}
            }

            #region 更新门诊调剂表内配药信息
            int parm = drugStoreManager.UpdateDrugRecipeDrugedInfo(info.StockDept.ID, info.RecipeNO, "M1", drugedOper.ID, drugedDept.ID, terminal.ID,applyOutCollection.Count);
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "更新门诊调剂数据出错!" + drugStoreManager.Err;
                return -1;
            }
            else if (parm == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "数据可能已被核准! 请刷新重试" + drugStoreManager.Err;
                return -1;
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        /// <summary>
        /// 门诊发药保存
        /// </summary>
        /// <param name="applyOutCollection">摆药申请信息</param>
        /// <param name="terminal">发药终端</param>
        /// <param name="sendDept">发药科室信息(扣库科室)</param>
        /// <param name="sendOper">发药人员信息</param>
        /// <param name="isDirectSave">是否直接保存 (无配药流程)</param>
        /// <param name="isUpdateAdjustParam">是否更新处方调剂信息</param>
        /// <returns>发药确认成功返回1 失败返回-1</returns>
        public int OutpatientSend(List<ApplyOut> applyOutCollection, NeuObject terminal, NeuObject sendDept, NeuObject sendOper, bool isDirectSave, bool isUpdateAdjustParam)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.BizLogic.Fee.Outpatient outPatientFeeManager = new Neusoft.HISFC.BizLogic.Fee.Outpatient();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //this.SetTrans(t.Trans);
            //outPatientFeeManager.SetTrans(t.Trans);

            DateTime sysTime = itemManager.GetDateTimeFromSysDateTime();

            int parm;
            ApplyOut info = new ApplyOut();
            for(int i = 0;i < applyOutCollection.Count;i++)
            {
                info = applyOutCollection[i] as ApplyOut;

                #region 申请表信息处理
                if (this.itemManager.UpdateApplyOutStateForSend(info, "2", sendOper.ID) < 1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "更新出库申请数据出错!" + itemManager.Err;
                    return -1;
                }
                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                    continue;
                #endregion

                #region 出库处理

                info.DrugNO = "0";
                //摆药信息 摆药科室、摆药人
                if (info.PrintState == "1" && info.BillClassNO != "")
                {
                    info.Operation.ApproveOper.Dept.ID = info.BillClassNO;
                }
                else
                {
                    info.Operation.ApproveOper.Dept = sendDept;
                }
                info.Operation.ApproveQty = info.Operation.ApplyQty;
                info.PrivType = "M1";

                info.Operation.ExamOper.ID = sendOper.ID;
                info.Operation.ExamOper.OperTime = sysTime;

                if (this.itemManager.Output(info) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "生成出库记录 更新库存出错  " + itemManager.Err;
                    return -1;
                }

                #endregion

                #region 更新费用表内确认信息
                //0未确认/1已确认 还是 1未确认/2已确认
                parm = outPatientFeeManager.UpdateConfirmFlag(info.RecipeNO, info.OrderNO, "1", sendOper.ID, sendDept.ID, sysTime, 0, info.Operation.ApplyQty * info.Days);
                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "更新费用表确认标记失败" + outPatientFeeManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "未正确更新费用确认标记 数据可能已被核准";
                    return -1;
                }
                #endregion

                #region 是否更新处方调剂信息
                if (isUpdateAdjustParam || isDirectSave)
                {
                    //存在替代药房的情况 对此种记录不进行更新
                    if (info.PrintState != "1" || info.BillClassNO == "")
                    {
                        //更新门诊终端待配药信息 传入-1每次减少1
                        Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipeTemp = new Neusoft.HISFC.Models.Pharmacy.DrugRecipe();
                        string recipeState = "1";
                        if (isDirectSave)           //直接发药 状态为 "1"
                            recipeState = "1";
                        else                        //配/发药操作 状态为"2"
                            recipeState = "2";

                        drugRecipeTemp = drugStoreManager.GetDrugRecipe(info.StockDept.ID, "M1", info.RecipeNO, recipeState);
                        if (drugRecipeTemp != null)
                        {
                            //屏蔽更新语句使用新处方调剂方式by Sunjh 2010-12-9 {61D29CAF-7EA1-4949-B9D6-F14C54AD9B2F}
                            //if (drugStoreManager.UpdateTerminalAdjustInfo(drugRecipeTemp.DrugTerminal.ID, 0, -1, 0) == -1)
                            //{
                            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            //    this.Err = "更新门诊终端已配药信息出错" + drugStoreManager.Err;
                            //    return -1;
                            //}
                        }
                    }
                }
                #endregion

            }

            //更新门诊调剂表内发药信息		

            #region 更新调剂表内发药信息
            ArrayList al = itemManager.QueryApplyOutListForClinic(info.StockDept.ID, "M1", "1", info.RecipeNO);
            if (al != null && al.Count <= 0)
            {
                if (isDirectSave)           //直接发药  需先更新配药信息
                {
                    parm = drugStoreManager.UpdateDrugRecipeDrugedInfo(info.StockDept.ID, info.RecipeNO, "M1", sendOper.ID, sendDept.ID,applyOutCollection.Count);
                    if (parm == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.Err = "更新门诊配药数据出错!" + drugStoreManager.Err;
                        return -1;
                    }
                    else if (parm == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.Err = "数据可能已被核准! 请刷新重试" + drugStoreManager.Err;
                        return -1;
                    }

                    parm = drugStoreManager.UpdateDrugRecipeSendInfo(info.StockDept.ID, info.RecipeNO, "M1", "2", sendOper.ID, sendDept.ID, terminal.ID);
                }
                else                       //配/发药操作 
                {
                    parm = drugStoreManager.UpdateDrugRecipeSendInfo(info.StockDept.ID, info.RecipeNO, "M1", "1", sendOper.ID, sendDept.ID, terminal.ID);
                }

                if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "更新门诊发药数据出错!" + drugStoreManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "调剂头表信息可能已被核准 请刷新重试" + drugStoreManager.Err;
                    return -1;
                }
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }

        /// <summary>
        /// 门诊还药操作 对已配药确认的数据 更新为未打印状态
        /// </summary>
        /// <param name="applyOutCollection">摆药申请信息</param>
        /// <param name="backOper">还药人员信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int OutpatientBack(List<ApplyOut> applyOutCollection, NeuObject backOper)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //this.SetTrans(t.Trans);

            int parm;
            ApplyOut info = new ApplyOut();
            for (int i = 0; i < applyOutCollection.Count; i++)
            {
                info = applyOutCollection[i] as ApplyOut;

                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                    continue;

                //还药确认 更新出库申请表内数据状态 为申请
                if (this.itemManager.UpdateApplyOutStateForDruged(info.StockDept.ID, "M1", info.RecipeNO, info.SequenceNO, "0", backOper.ID, info.Operation.ApplyQty) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    this.Err = "更新出库申请数据出错!" + itemManager.Err;
                    return -1;
                }
            }
            //更新门诊调剂表内还药信息、处方状态  对已配药确认的数据进行还药
            parm = this.drugStoreManager.UpdateDrugRecipeBackInfo(info.StockDept.ID, info.RecipeNO, "M1", backOper.ID, "2");
            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "更新门诊调剂数据出错!" + drugStoreManager.Err;
                return -1;
            }
            else if (parm == 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                this.Err = "数据可能已被核准! 请刷新重试";
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return 1;
        }
        #endregion

        #region 住院配置中心收费/退费

        /// <summary>
        ///  配置中心收费
        /// </summary>
        /// <param name="arrayApplyOut">住院配置数据</param>
        /// <param name="execDept">执行科室</param>
        /// <param name="trans">事务</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int CompoundFee(ArrayList arrayApplyOut, Neusoft.FrameWork.Models.NeuObject execDept, System.Data.IDbTransaction trans)
        {
            if (trans == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            }
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 事务记录

            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new RADT();
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Fee();

            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对Integrate进行SetTrans
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            ////定义数据库处理事务
            //Neusoft.FrameWork.Management.Transaction t = null;
            //if (trans == null)
            //{
            //    t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //    t.BeginTransaction();
            //    this.SetTrans(t.Trans);
            //    radtIntegrate.SetTrans(t.Trans);
            //    consManager.SetTrans(t.Trans);
            //    feeIntegrate.SetTrans(t.Trans);
            //}
            //else
            //{
            //    this.SetTrans(trans);
            //    radtIntegrate.SetTrans(trans);
            //    consManager.SetTrans(trans);
            //    feeIntegrate.SetTrans(trans);
            //}

            #endregion

            #region 形成待收费数据

            string privCombo = "-1";
            ArrayList alGroupApplyOut = new ArrayList();
            ArrayList alCombo = new ArrayList();

            #region 按批次形成数据

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in arrayApplyOut)
            {
                if ((privCombo == info.CompoundGroup && info.CompoundGroup != ""))        //与上一条是同一批次流水
                {
                    continue;
                }
                else			//不同批次流水号
                {
                    alGroupApplyOut.Add(info);

                    privCombo = info.CompoundGroup;
                }
            }

            #endregion

            #endregion

            System.Collections.Hashtable hsPatientInfo = new Hashtable();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alGroupApplyOut)
            {
                #region 设置患者信息

                if (hsPatientInfo.Contains(info.PatientNO))
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patent = hsPatientInfo[info.PatientNO] as Neusoft.HISFC.Models.RADT.PatientInfo;
                    patent.User01 = (Neusoft.FrameWork.Function.NConvert.ToInt32(patent.User01) + 1).ToString();
                }
                else
                {
                    //获取新患者信息 并设置需收费批次初值                        
                    Neusoft.HISFC.Models.RADT.PatientInfo patient = radtIntegrate.QueryPatientInfoByInpatientNO(info.PatientNO);
                    if (patient == null)
                    {
                        if (trans == null)          //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                            feeIntegrate.Rollback();
                        }
                        this.Err = radtIntegrate.Err;
                        return -1;
                    }

                    patient.User01 = "1";
                    hsPatientInfo.Add(info.PatientNO, patient);
                }

                #endregion
            }

            Neusoft.HISFC.Models.Base.Item item = new Neusoft.HISFC.Models.Base.Item();
            ArrayList alList = consManager.GetAllList("CompoundItem");
            if (alList == null)
            {
                if (trans == null)          //事务由本函数内部开启
                {
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                    feeIntegrate.Rollback();
                }
                this.Err = consManager.Err;
                return -1;
            }
            if (alList.Count > 0)
            {
                Neusoft.HISFC.Models.Base.Const cons = new Neusoft.HISFC.Models.Base.Const();
                //{110FFB2C-EE8A-4378-9DA8-E1681271749F} 对于无效的常数维护项目 不进行收费
                for (int i = 0; i < alList.Count; i++)
                {
                    cons = alList[i] as Neusoft.HISFC.Models.Base.Const;
                    if (cons.IsValid)       //有效
                    {
                        break;
                    }
                    cons = new Neusoft.HISFC.Models.Base.Const();
                }

                if (string.IsNullOrEmpty(cons.ID) == true)
                {
                    if (trans == null)          //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                        feeIntegrate.Rollback();
                    }
                    this.Err = "未设置配置中心需收费的项目 无法完成费用自动收取";
                    //{0C5037B6-06FB-4dd8-AED8-B7412D2A6576}  更改返回值 对于未设置配置项目返回-0
                    return 0;
                }

                item = feeIntegrate.GetItem(cons.ID);
                if (item == null)
                {
                    if (trans == null)          //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                        feeIntegrate.Rollback();
                    }
                    this.Err = "未设置配置中心需收费的项目 无法完成费用自动收取";
                    //{0C5037B6-06FB-4dd8-AED8-B7412D2A6576}  更改返回值 对于未设置配置项目返回-0
                    return 0;
                }
            }
            else
            {
                if (trans == null)          //事务由本函数内部开启
                {
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                    feeIntegrate.Rollback();
                }
                this.Err = "未设置配置中心需收费的项目 无法完成费用自动收取";
                //{0C5037B6-06FB-4dd8-AED8-B7412D2A6576}  更改返回值 对于未设置配置项目返回-0
                return 0;
            }

            foreach (Neusoft.HISFC.Models.RADT.PatientInfo info in hsPatientInfo.Values)
            {
                item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(info.User01);

                //{389D4EDA-B312-492a-8EDA-B9D0F9A30041} 判断患者是否在院
                if (info.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                {
                    if (trans == null)      //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                        feeIntegrate.Rollback();
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    }
                    this.Err = info.Name + " 患者非在院状态，不能进行配置费收取操作";
                    return -1;
                }

                if (feeIntegrate.FeeAutoItem(info, item, execDept.ID) == -1)
                {
                    if (trans == null)          //事务由本函数内部开启
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行RollBack
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.Rollback();
                    }
                    this.Err = feeIntegrate.Err;
                    return -1;
                }
            }

            if (trans == null)          //事务由本函数内部开启
            {
                //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对调用FeeIntegrate的进行Commit
                //Neusoft.FrameWork.Management.PublicTrans.Commit();
                feeIntegrate.Commit();
            }

            return 1;
        }

        /// <summary>
        /// 配置中心退费
        /// </summary>
        /// <param name="alOriginalData">住院配置数据</param>
        /// <param name="approveDept">核准科室</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int CompoundBackFee(List<Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList> alFeeData, Neusoft.FrameWork.Models.NeuObject approveDept)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            #region 管理类声明

            //退费申请管理类
            Neusoft.HISFC.BizLogic.Fee.ReturnApply applyReturn = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();

            //费用组合管理类
            Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Fee();

            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需对Integrate进行SetTrans
            feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            //this.SetTrans(t.Trans);
            //applyReturn.SetTrans(t.Trans);
            //feeIntegrate.SetTrans(t.Trans);

            #endregion

            DateTime sysTime = applyReturn.GetDateTimeFromSysDateTime();
            string operCode = applyReturn.Operator.ID;
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo;
            //如果退药的同时退费,则处理费用信息
            Pharmacy.IsReturnCharge = this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_BackFee, false, false);

            #region 退库/退费操作

            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem in alFeeData)
            {
                //药品退库
                if (this.OutputReturn(feeItem, operCode, sysTime) != 1)
                {
                    //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用feeIntegrate的RollBack
                    //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    feeIntegrate.Rollback();
                    return -1;
                }
                //根据控制参数 设置是否生成退费申请或直接退费
                if (Pharmacy.IsReturnCharge)
                {
                    #region 退费处理   取费用信息

                    feeItem.NoBackQty = 0;
                    feeItem.IsNeedUpdateNoBackQty = false;
                    feeItem.PayType = Neusoft.HISFC.Models.Base.PayTypes.SendDruged;

                    patientInfo = this.radtIntegrate.QueryPatientInfoByInpatientNO(feeItem.Patient.ID);

                    //{389D4EDA-B312-492a-8EDA-B9D0F9A30041} 判断患者是否在院
                    if (patientInfo.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                    {
                        if (trans == null)      //事务由本函数内部开启
                        {
                            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942}  此处需调用FeeIntegrate的RollBack
                            feeIntegrate.Rollback();
                            //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        }
                        this.Err = patientInfo.Name + " 患者非在院状态，不能进行退药退费操作";
                        return -1;
                    }

                    if (feeIntegrate.QuitItem(patientInfo, feeItem.Clone()) == -1)
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用feeIntegrate的RollBack
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.Rollback();
                        System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("退费失败!") + feeIntegrate.Err);
                        return -1;
                    }

                    #endregion
                }
                else
                {
                    #region 生成退费申请

                    patientInfo = this.radtIntegrate.QueryPatientInfoByInpatientNO(feeItem.Patient.ID);

                    //进行退费申请
                    feeItem.CancelType = Neusoft.HISFC.Models.Base.CancelTypes.Valid;
                    feeItem.IsConfirmed = true;

                    int parm = applyReturn.Apply(patientInfo, feeItem.Clone(), sysTime);
                    if (parm == -1)
                    {
                        //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用feeIntegrate的RollBack
                        //Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        feeIntegrate.Rollback();
                        System.Windows.Forms.MessageBox.Show(applyReturn.Err);
                        return -1;
                    }

                    #endregion
                }
            }

            #endregion

            //{3EE6172A-301B-4d16-91C7-E5D8AC94D942} 此处需调用feeIntegrate的Commit
            //Neusoft.FrameWork.Management.PublicTrans.Commit();
            feeIntegrate.Commit();

            return 1;
        }

        /// <summary>
        /// 配置退费
        /// </summary>
        /// <param name="alCompound">配置中心项目</param>
        /// <param name="approveDept">核准科室</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int CompoundBackFee(ArrayList alCompound, Neusoft.FrameWork.Models.NeuObject approveDept)
        {
            Neusoft.HISFC.BizLogic.Fee.InPatient feeInpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = null;
            List<Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList> alFeeList = new List<Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList>();
            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alCompound)
            {
                //feeItemList = feeInpatientManager.GetItemListByRecipeNO(info.RecipeNO, info.SequenceNO, true);
                feeItemList = feeInpatientManager.GetItemListByRecipeNO(info.RecipeNO, info.SequenceNO, EnumItemType.Drug);
                if (feeItemList == null)
                {
                    System.Windows.Forms.MessageBox.Show(feeInpatientManager.Err);
                    return -1;
                }
                alFeeList.Add(feeItemList);
            }

            return this.CompoundBackFee(alFeeList, approveDept);
        }
        #endregion

        #region 获取药品信息/列表

        /// <summary>
        /// 获取药品最新零售价
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="newPrice">药品零售价</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int GetDrugNewPrice(string drugCode, ref decimal newPrice)
        {
            this.SetDB(itemManager);

            return this.itemManager.GetNowPrice(drugCode, ref newPrice);
        }

        /// <summary>
        /// 根据药品编码获得某一药品信息
        /// </summary>
        /// <param name="ID">药品编码</param>
        /// <returns>成功返回药品实体 失败返回null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Item GetItem(string ID)
        {
            this.SetDB(this.itemManager);

            return this.itemManager.GetItem(ID);
        }

        /// <summary>
        /// 根据药品编码和患者科室，获取住院医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">患者科室</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>药品库存实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.Storage GetItemForInpatient(string deptCode, string drugCode)
        {
            this.SetDB(itemManager);

            return this.itemManager.GetItemForInpatient(deptCode, drugCode);
        }

        /// <summary>
        /// 根据药品编码和患者科室，获取住院医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="order">患者医嘱</param>
        /// <param name="deptCode">患者科室</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>药品库存实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.Storage GetItemForInpatient(Neusoft.HISFC.Models.Order.Inpatient.Order order ,string deptCode, string drugCode)
        {
            this.SetDB(itemManager);

            Neusoft.HISFC.Models.Pharmacy.Storage storage = this.itemManager.GetItemForInpatient(deptCode, drugCode);
            if (storage == null)
            {
                return null;
            }

            if (order.OrderType.ID == "CZ")
            {
                Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();            
                ArrayList alStock = constantManager.GetList("CompoundStock");
                if (alStock == null)
                {
                    this.Err = "获取常数类别发生错误" + constantManager.Err;
                }
                foreach (Neusoft.HISFC.Models.Base.Const consInfo in alStock)
                {
                    if (consInfo.ID == order.Usage.ID)
                    {
                        storage.StockDept.ID = consInfo.Name;
                        break;
                    }
                }
            }

            return storage;
        }

        /// <summary>
        /// 获取门诊医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryItemAvailableListForClinic(string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryItemAvailableListForClinic(deptCode);
        }

        /// <summary>
        /// 获取科常用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryDeptAlwaysUsedItem(string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryDeptAlwaysUsedItem(deptCode);
        }

        /// <summary>
        /// 获取住院医嘱、收费使用的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <returns>成功返回药品数组 失败返回null</returns>
        public ArrayList QueryItemAvailableList(string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryItemAvailableList(deptCode);
        }

        /// <summary>
        /// 获取住院医嘱、收费使用的某一类别的药品数据
        /// </summary>
        /// <param name="deptCode">取药病区</param>
        /// <param name="drugType">药品类别 传入ALL获取全部药品类别</param>
        /// <returns>成功返回药品列表 失败返回null</returns>
        public ArrayList QueryItemAvailableList(string deptCode, string drugType)
        {
            this.SetDB(itemManager);

            ArrayList al = itemManager.QueryItemAvailableList(deptCode, drugType);

            if (Neusoft.HISFC.BizProcess.Integrate.Pharmacy.IsNostrumManageStore)
            {
                List<Neusoft.HISFC.Models.Pharmacy.Item> nostrumList = itemManager.QueryNostrumList("C");
                if (nostrumList == null)
                {
                    return null;
                }

                al.AddRange(new ArrayList(nostrumList.ToArray()));
            }

            return al;
        }
        
        /// <summary>
        /// 获得全部药品信息列表，根据参数判断是否显示简单数据列
        /// </summary>
        /// <param name="IsShowSimple">是否显示简单数据列</param>
        /// <returns>成功返回药品信息简略数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemList(bool IsShowSimple)
        {
            this.SetDB(itemManager);

            return itemManager.QueryItemList(IsShowSimple);
        }

        /// <summary>
        /// 获得可用药品信息列表
        /// </summary>
        /// <returns>成功返回药品信息 失败返回null</returns>
        public System.Data.DataSet QueryItemValidList()
        {
            this.SetDB(itemManager);

            return itemManager.QueryItemValidList();
        }

        /// <summary>
        /// 获得可用药品信息列表
        /// 可以通过参数选择是否显示部分基本信息字段
        /// </summary>
        /// <param name="IsShowSimple">是否显示简单信息</param>
        /// <returns>成功返回药品信息数组 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableList(bool IsShowSimple)
        {
            this.SetDB(itemManager);

            return itemManager.QueryItemAvailableList(IsShowSimple);
        }

        /// <summary>
        /// 获取药品列表库存信息
        /// </summary>
        /// <param name="deptCode">取药部门</param>
        /// <param name="doctCode">医生编码</param>
        /// <param name="doctGrade">医生等级</param>
        /// <returns>成功返回库存信息数组 失败返回null 无数据返回空数组</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryItemAvailableList(string deptCode, string doctCode, string doctGrade)
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            this.SetDB(consManager);
            consManager.SetTrans(trans);
            this.SetDB(itemManager);

            ArrayList al = consManager.GetList("SpeDrugGrade");
            if (al == null || al.Count == 0)
            {
                //无医生职级与等级对应信息
                return itemManager.QueryItemAvailableList(deptCode, doctCode, null);
            }
            else
            {
                string drugGradeCollection = "";
                foreach (Neusoft.HISFC.Models.Base.Const consInfo in al)
                {
                    //{3972BA6D-5CE4-4995-90AA-30DD281D1660}
                    if (consInfo.ID.IndexOf("|") != -1)
                    {
                        consInfo.ID = consInfo.ID.Substring(0, consInfo.ID.IndexOf("|"));       //拆分字符 获取医生职级
                    }
                    if (consInfo.ID == doctGrade)
                    {
                        //{3972BA6D-5CE4-4995-90AA-30DD281D1660}
                        if (drugGradeCollection == "")
                            drugGradeCollection = consInfo.Name;
                        else
                            drugGradeCollection = drugGradeCollection + "','" + consInfo.Name;
                        //return itemManager.QueryItemAvailableList(deptCode, doctCode, consInfo.Name);
                    }
                }

                if (drugGradeCollection != "")
                {
                    return itemManager.QueryItemAvailableList(deptCode, doctCode, drugGradeCollection);
                }
                //无医生职级与等级对应信息
                return itemManager.QueryItemAvailableList(deptCode, doctCode, null);
            }
        }

        /// <summary>
        /// 获取药品列表库存信息
        /// </summary>
        /// <param name="deptCode">取药部门</param>
        /// <param name="doctCode">医生编码</param>
        /// <param name="doctGrade">医生等级</param>
        /// <returns>成功返回库存信息数组 失败返回null 无数据返回空数组</returns>
        public ArrayList QueryItemAvailableArrayList(string deptCode, string doctCode, string doctGrade)
        {
            List<Neusoft.HISFC.Models.Pharmacy.Item> al = this.QueryItemAvailableList(deptCode, doctCode, doctGrade);

            if (al == null)
            {
                return null;
            }

            return new ArrayList(al.ToArray());
        }
        #endregion

        #region 摆药单信息判断 判断相应的药品医嘱是否已维护了对应的药品摆药单

        /// <summary>
        /// 判断相应的药品医嘱是否已维护了对应的药品摆药单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool IsHaveDrugBill(Neusoft.HISFC.Models.Order.Order order)
        {
            
            return true;
        }

        /// <summary>
        /// 判断相应的药品医嘱是否已维护了对应的药品摆药单
        /// </summary>
        /// <param name="orderType">医嘱类别</param>
        /// <param name="usageCode">用法</param>
        /// <param name="drugType">药品类别</param>
        /// <param name="drugQuality">药品性质</param>
        /// <param name="dosageFormCode">剂型</param>
        /// <returns>已存在维护的单 返回True 否则返回False</returns>
        public bool IsHaveDrugBill(string orderType,string usageCode,string drugType,string drugQuality,string dosageFormCode)
        {
            Neusoft.HISFC.Models.Pharmacy.DrugBillClass findDrugBill = drugStoreManager.GetDrugBillClass(orderType, usageCode, drugType, drugQuality, dosageFormCode);
           
            if (findDrugBill == null || findDrugBill.ID == "")
                return false;
            else
                return true;
        }

        #endregion

        #region 出库申请 对费用/医嘱 公开 使用  是否预出库 住院根据是否摆药时收费判断 门诊采用控制参数盘点

        #region 住院申请

        /// <summary>
        /// 获得申请信息
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="sequenceNO">处方流水号</param>
        /// <returns>成功 申请信息 失败 null</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut GetApplyOut(string recipeNO, int sequenceNO)
        {
            this.SetDB(itemManager);

            return itemManager.GetApplyOut(recipeNO, sequenceNO);
        }

        /// <summary>
        /// 获得申请信息
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <returns>成功 申请信息 失败 null</returns>
        public ArrayList QueryApplyOut(string recipeNO)
        {
            this.SetDB(itemManager);

            return itemManager.QueryApplyOut(recipeNO);
        }

        #region addby xuewj 2010-9-23 增加退费申请单 {0C4C8562-4E12-4303-8BA3-6FF8FCD16B1A}
        /// <summary>
        /// 获取满足条件的单条申请明细信息	
        /// </summary>
        ///<param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">项目流水号</param>
        /// <returns>成功返回摆药实体 失败返回null 无数据返回空实体</returns>
        public Neusoft.HISFC.Models.Pharmacy.ApplyOut QueryApplyOutNew(string recipeNO, int sequenceNo)
        {
            this.SetDB(itemManager);

            return itemManager.QueryApplyOutNew(recipeNO, sequenceNo);
        } 
        #endregion

        /// <summary>
        /// 申请出库－－对医嘱子系统公开的函数
        /// </summary>
        /// <param name="execOrder">医嘱执行实体</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isRefreshStockDept">是否根据申请科室重新获取取药科室</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Order.ExecOrder execOrder, DateTime operDate,bool isRefreshStockDept)
        {
            this.SetDB(itemManager);

            //如果摆药时计费 则不进行预扣库存操作 否则 预扣库存   SysConst.Use_Drug_ApartFee "100003"
            Pharmacy.IsApproveCharge = !this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);
            //摆药申请科室类型 0 科室 1 护理站
            string applyDeptType = this.ctrlIntegrate.GetControlParam<string>(SysConst.Use_Drug_ApplyNurse, false, "0");

            if (Pharmacy.IsApproveCharge)
            {
                string property = this.GetDrugProperty(execOrder.Order.Item.ID, ((Neusoft.HISFC.Models.Pharmacy.Item)execOrder.Order.Item).DosageForm.ID, execOrder.Order.Patient.PVisit.PatientLocation.Dept.ID);
                if (property == "0")
                {
                    execOrder.Order.Qty = (decimal)System.Math.Ceiling((double)execOrder.Order.Qty);
                }
            }
            
            //是否实现预扣库存操作
            //{F766D3A5-CC25-4dd7-809E-3CBF9B152362}  对于预扣库存动作由最后统一完成
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            //{8113BE34-A5E0-4d87-B6FF-B8428BAA8711}  对{F766D3A5-CC25-4dd7-809E-3CBF9B152362} 的补救 
            //因为ApplyOut业务层函数里边对ApplyOut实体赋值时使用了传入参数 所以此处不能直接传入False
            return itemManager.ApplyOut(execOrder, operDate, Pharmacy.IsInPatientPreOut, applyDeptType, isRefreshStockDept);
        }

        /// <summary>
        /// 申请出库 -- 对医嘱子系统公开函数 根据传入的医嘱进行库存统一预扣
        /// 
        /// {F766D3A5-CC25-4dd7-809E-3CBF9B152362}  完成一次医嘱分解的库存统一预扣
        /// </summary>
        /// <param name="execOrderList">医嘱执行信息</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isRefreshStockDept">是否根据申请科室重新获取取药科室</param>
        /// <returns>0没有操作 1成功 -1失败</returns>
        public int InpatientDrugPreOutNum(List<Neusoft.HISFC.Models.Order.ExecOrder> execOrderList, DateTime operDate, bool isRefreshStockDept)
        {
            //{C37BEC96-D671-46d1-BCDD-C634423755A4}  取消此种库存预扣管理模式。以下代码屏蔽
            return 1;

            //以下代码屏蔽

            #region 原有库存预扣管理模式屏蔽

            ////是否实现预扣库存操作
            //Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);
            //if (!Pharmacy.IsInPatientPreOut)
            //{
            //    return 1;
            //}

            //this.SetDB(itemManager);

            //Dictionary<string, System.Data.DataRow> storePreOutNum = new Dictionary<string, System.Data.DataRow>();

            //System.Data.DataTable preOutDataTable = new System.Data.DataTable();
            //preOutDataTable.Columns.AddRange(new DataColumn[] {														 
            //                                            new DataColumn("药品编码",  System.Type.GetType("System.String")),
            //                                            new DataColumn("药品名称",  System.Type.GetType("System.String")),
            //                                            new DataColumn("科室编码",  System.Type.GetType("System.String")),//2
            //                                            new DataColumn("数量",   System.Type.GetType("System.Decimal")) 
            //                                        });
            //DataColumn[] keyColumn = new DataColumn[] { preOutDataTable.Columns["药品编码"], preOutDataTable.Columns["科室编码"] };
            //preOutDataTable.PrimaryKey = keyColumn;

            //foreach (Neusoft.HISFC.Models.Order.ExecOrder info in execOrderList)
            //{
            //    DataRow findDr = preOutDataTable.Rows.Find(new object[] { info.Order.Item.ID, info.Order.StockDept.ID });
            //    if (findDr != null)
            //    {
            //        findDr["数量"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(findDr["数量"]) + info.Order.Qty;
            //    }
            //    else
            //    {
            //        DataRow newDr = preOutDataTable.NewRow();
            //        newDr["药品编码"] = info.Order.Item.ID;
            //        newDr["药品名称"] = info.Order.Item.Name;
            //        newDr["科室编码"] = info.Order.StockDept.ID;
            //        newDr["数量"] = info.Order.Qty;

            //        preOutDataTable.Rows.Add(newDr);
            //    }
            //}

            //preOutDataTable.DefaultView.Sort = "科室编码,药品编码";

            //for (int i = 0; i < preOutDataTable.DefaultView.Count; i++)
            //{
            //    DataRow viewRow = preOutDataTable.DefaultView[i].Row;

            //    Neusoft.HISFC.Models.Pharmacy.Storage stockInfo = this.itemManager.GetStockInfoByDrugCode(viewRow["科室编码"].ToString(), viewRow["药品编码"].ToString());
            //    if (stockInfo == null)
            //    {
            //        return -1;
            //    }
            //    //对于库存数量的判断的地方 需要判断预扣库存  {5D32F201-AD50-4d0e-A89E-0231B5F0B488}
            //    if (Neusoft.FrameWork.Function.NConvert.ToDecimal(viewRow["数量"]) > (stockInfo.StoreQty - stockInfo.PreOutQty))
            //    {
            //        this.Err = viewRow["药品名称"].ToString() + " 药品库存不足！";
            //        return -1;
            //    }

            //    if (itemManager.UpdateStoragePreOutNum(viewRow["科室编码"].ToString(), viewRow["药品编码"].ToString(), Neusoft.FrameWork.Function.NConvert.ToDecimal(viewRow["数量"])) == -1)
            //    {
            //        return -1;
            //    }
            //}

            //return 1;

            #endregion
        }

        /// <summary>
        /// 插入申请信息
        /// </summary>
        /// <param name="applyOut">申请信息</param>
        /// <returns>成功 1 失败 -1</returns>
        [System.Obsolete("原有申请管理模式作废 采用ApplyOut重载函数实现", true)]
        public int InsertApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.SetDB(itemManager);

            return itemManager.InsertApplyOut(applyOut);
        }

        /// <summary>
        /// 插入申请信息
        /// 
        /// {C37BEC96-D671-46d1-BCDD-C634423755A4}
        /// </summary>
        /// <param name="applyOut">申请信息</param>
        /// <returns>成功 1 失败 -1</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.SetDB(itemManager);

            applyOut.ID = null;

            if (itemManager.InsertApplyOut(applyOut) == -1)
            {
                return -1;
            }

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            if (Pharmacy.IsInPatientPreOut)
            {
                return itemManager.UpdateStockinfoPreOutNum(applyOut, applyOut.Operation.ApplyQty, applyOut.Days);
            }

            return 1;
        }
        
        /// <summary>
        /// 申请出库－－对费用公开的函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeItem">患者费用信息实体</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isRefreshStockDept">是否根据申请科室重新获取取药科室</param>
        /// <returns>0没有删除 1成功 -1失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem, DateTime operDate,bool isRefreshStockDept)
        {
            this.SetDB(itemManager);

            ////如果摆药时计费 则不进行预扣库存操作 否则 预扣库存
            //Pharmacy.IsApproveCharge = Pharmacy.QueryControlForBool("501003", false);
            //如果摆药时计费 则不进行预扣库存操作 否则 预扣库存   SysConst.Use_Drug_ApartFee "100003"
            Pharmacy.IsApproveCharge = !this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);
            //摆药申请科室类型 0 科室 1 护理站
            string applyDeptType = this.ctrlIntegrate.GetControlParam<string>(SysConst.Use_Drug_ApplyNurse, false, "0");

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            return itemManager.ApplyOut(patient, feeItem, operDate, Pharmacy.IsInPatientPreOut, applyDeptType, isRefreshStockDept);
        }

        /// <summary>
        /// 申请退库－－对费用子系统公开的函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeItem">费用信息实体</param>
        /// <param name="operDate">操作时间</param>
        /// <returns>0没有更新 1成功 -1失败</returns>
        public int ApplyOutReturn(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItem, DateTime operDate)
        {
            this.SetDB(itemManager);

            //摆药申请科室类型 0 科室 1 护理站
            string applyDeptType = this.ctrlIntegrate.GetControlParam<string>(SysConst.Use_Drug_ApplyNurse, false, "0");

            return itemManager.ApplyOutReturn(patient, feeItem, operDate, applyDeptType);
        }

        //{3E83AFA1-C364-4f72-8DFD-1B733CB9379E}
        //增加查询患者是否有未审核的退药记录,为出院登记判断用 Add by 王宇 2009.6.10

        /// <summary>
        ///  查询住院患者是否有未确认的退药申请
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <returns>成功 > 0 记录 0 没有记录 -1 错误</returns>
        public int QueryNoConfirmQuitApply(string inpatientNO) 
        {
            this.SetDB(itemManager);

            return this.itemManager.QueryNoConfirmQuitApply(inpatientNO);
        }
        ////{3E83AFA1-C364-4f72-8DFD-1B733CB9379E} 添加完毕

        #endregion

        #region 对住院医嘱接受数组 汇总处理 用于摆药时收费

        /// <summary>
        /// 申请出库 －－ 医嘱汇总处理 仅用于摆药时收费的处理
        /// 按同一医嘱流水号进行汇总
        /// </summary>
        /// <param name="alExeOrder">医嘱执行实体数组</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isRefreshStockDept">是否根据申请科室重新获取取药药房</param>
        /// <returns>1 成功 －1 失败</returns>
        public int ApplyOut(ArrayList alExeOrder, DateTime operDate, bool isRefreshStockDept)
        {
            this.SetDB(itemManager);

            ArrayList alFeeExeOrder = new ArrayList();

            //本次已处理患者
            System.Collections.Hashtable hsOrderNO = new Hashtable();
            //医嘱循环处理
            foreach (Neusoft.HISFC.Models.Order.ExecOrder exeOrder in alExeOrder)
            {
                #region 医嘱汇总处理

                if (!exeOrder.Order.OrderType.IsDecompose)      //医嘱不分解（临时医嘱）
                {
                    alFeeExeOrder.Add(exeOrder);
                }
                else
                {                   
                    string feeFlag = "1";
                    bool isFee = false;
                    decimal feeNum = exeOrder.Order.Qty;
                    if (itemManager.PatientStore(exeOrder, ref feeFlag, ref feeNum, ref isFee) == -1)
                    {
                        return -1;
                    }
                    switch (feeFlag)
                    {
                        case "0":           //不需计费处理
                            continue;
                        case "1":           //按指定数量计费处理  此时feeNum数量已发生变化
                        case "2":           //按原流程处理
                            exeOrder.Order.Qty = feeNum;
                            break;
                    }
                    //对同一医嘱流水号进行汇总
                    if (hsOrderNO.ContainsKey(exeOrder.Order.ID))
                    {
                        Neusoft.HISFC.Models.Order.ExecOrder feeExeOrder = hsOrderNO[exeOrder.Order.ID] as Neusoft.HISFC.Models.Order.ExecOrder;
                        feeExeOrder.Order.Qty = feeExeOrder.Order.Qty + exeOrder.Order.Qty;
                    }
                    else
                    {
                        hsOrderNO.Add(exeOrder.Order.ID, exeOrder);
                    }
                }

                #endregion
            }

            //摆药申请科室类型 0 科室 1 护理站
            string applyDeptType = this.ctrlIntegrate.GetControlParam<string>(SysConst.Use_Drug_ApplyNurse, false, "0");

            foreach (Neusoft.HISFC.Models.Order.ExecOrder feeExeOrder in alFeeExeOrder)
            {
                itemManager.ApplyOut(feeExeOrder, operDate, false, applyDeptType, isRefreshStockDept);
            }
            return 1;
        }

        #endregion

        #region 门诊申请

        /// <summary>
        /// 门诊收费调用的出库函数
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeAl">费用信息数组</param>
        /// <param name="feeWindow">收费窗口</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="isModify">是否门诊退改药</param>
        /// <param name="drugSendInfo">处方调剂信息 发药药房+发药窗口</param>
        /// <returns>1 成功 －1 失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Registration.Register patient, ArrayList feeAl, string feeWindow, DateTime operDate, bool isModify,out string drugSendInfo)
        {
            Neusoft.HISFC.BizLogic.Manager.Constant constantManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            if (this.trans != null) 
            {
                constantManager.SetTrans(this.trans);
                ctrlParamIntegrate.SetTrans(this.trans);
            }

            #region 无申请信息，直接扣库存科室

            ArrayList alSpeDept = constantManager.GetList("PrintLabel");
            if (alSpeDept == null)
            {
                this.Err = "获取常数类别发生错误" + constantManager.Err;
            }

            #endregion

            //由于不同药房可以使用不同的调剂方式 所以调剂方式(竞争/平均)由业务层获取

            this.SetDB(itemManager);
            
            Pharmacy.IsClinicPreOut = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Pre_Out, false, true);
            //判断是否启用门诊注射管理流程。启用门诊注射管理流程时，对于院注次数大于零的不进行处理
            bool useInjectFlow = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Inject_Flow, false, false);
            if (useInjectFlow)
            {   
                ArrayList alFilterFee = new ArrayList();
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeInfo in alFilterFee)
                {
                    if (feeInfo.InjectCount <= 0)
                    {
                        alFilterFee.Add(feeInfo);
                    }
                }

                return itemManager.ApplyOut(patient, alFilterFee, operDate, Pharmacy.IsClinicPreOut, isModify, alSpeDept, out drugSendInfo);
            }
            else
            {
                return itemManager.ApplyOut(patient, feeAl, operDate, Pharmacy.IsClinicPreOut, isModify, alSpeDept, out drugSendInfo);
            }
        }

        /// <summary>
        /// 门诊收费调用的出库函数
        /// 将Fee.OutPatient.FeeItemList 转化为出库申请对象 处方调剂方式采用平均调剂 门诊收费调用
        /// </summary>
        /// <param name="patient">患者信息实体</param>
        /// <param name="feeAl">费用信息数组</param>
        /// <param name="operDate">操作时间</param>
        /// <param name="drugSendInfo">处方调剂信息 发药药房+发药窗口</param>
        /// <returns>1 成功 －1 失败</returns>
        public int ApplyOut(Neusoft.HISFC.Models.Registration.Register patient, ArrayList feeAl, DateTime operDate, out string drugSendInfo)
        {
            return this.ApplyOut(patient, feeAl, "", operDate, false, out drugSendInfo);
        }

        /// <summary>
        /// 根据旧发票号更新新发票号
        /// </summary>
        /// <param name="orgInvoiceNO">旧发票号</param>
        /// <param name="newInvoiceNO">新发票号</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UpdateDrugRecipeInvoiceN0(string orgInvoiceNO, string newInvoiceNO)
        {
            this.SetDB(drugStoreManager);

            return drugStoreManager.UpdateDrugRecipeInvoiceN0(orgInvoiceNO, newInvoiceNO);
        }

        #endregion

        #region 申请作废

        #region 申请函数作废 根据处方号作废申请

        /// <summary>
        /// 取消门诊发药申请
        /// 根据处方流水号，作废门诊发药申请 不进行预扣库存
        /// </summary>
        /// <param name="recipeNo">处方流水号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOutClinic(string recipeNo)
        {
            return this.CancelApplyOutClinic(recipeNo, -1);
        }

        /// <summary>
        /// 取消门诊发药申请
        /// 根据处方流水号，作废门诊发药申请
        /// </summary>
        /// <param name="recipeNo">处方号</param>
        /// <param name="sequenceNo">处方内项目流水号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOutClinic(string recipeNo, int sequenceNo)
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.SetDB(itemManager);

            Pharmacy.IsClinicPreOut = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Pre_Out, false, true);

            return itemManager.CancelApplyOutClinic(recipeNo, sequenceNo, Pharmacy.IsClinicPreOut);
        }

        /// <summary>
        /// 取消出库申请
        /// 根据处方流水号和处方内序号，作废出库申请
        /// </summary>
        /// <param name="recipeNo">处方流水号</param>
        /// <param name="sequenceNo">处方内序号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOut(string recipeNo, int sequenceNo)
        {
            this.SetDB(itemManager);

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            return itemManager.CancelApplyOut(recipeNo, sequenceNo, Pharmacy.IsInPatientPreOut);
        }

        /// <summary>
        /// 撤销取消出库申请（取消申请的逆过程）
        /// 根据处方流水号和处方内序号，撤销作废出库申请
        /// </summary>
        /// <param name="recipeNo">处方流水号</param>
        /// <param name="sequenceNo">处方内序号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UndoCancelApplyOut(string recipeNo, int sequenceNo)
        {
            this.SetDB(itemManager);

            //Pharmacy.IsApproveCharge = Pharmacy.QueryControlForBool("501003", false);
            //如果摆药时计费 则不进行预扣库存操作 否则 预扣库存   SysConst.Use_Drug_ApartFee "100003"
            Pharmacy.IsApproveCharge = !this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            return itemManager.UndoCancelApplyOut(recipeNo, sequenceNo, Pharmacy.IsInPatientPreOut);
        }

        #endregion

        #region 函数作废  根据退费实体作废申请 对于部分退重新发送申请

        /// <summary>
        /// 作废退费申请  如果是部分退 则作废原申请 并产生新申请
        /// </summary>
        /// <param name="feeItemList">退费信息实体</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public int CancelApplyOut(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList)
        {           
            //Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList originalFee = feeInpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO,feeItemList.SequenceNO,true);
            Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList originalFee = feeInpatientManager.GetItemListByRecipeNO(feeItemList.RecipeNO, feeItemList.SequenceNO, EnumItemType.Drug);

            if (this.CancelApplyOut(originalFee.RecipeNO, originalFee.SequenceNO) == -1)
            {
                this.Err = "作废发药申请信息失败";
                return -1;
            }

            if (originalFee.Item.Qty > feeItemList.Item.Qty)      //部分退 重新发送申请
            {
                originalFee.Item.Qty = originalFee.NoBackQty - feeItemList.Item.Qty;
                originalFee.FeeOper = feeItemList.FeeOper;
               
                Neusoft.HISFC.Models.RADT.PatientInfo patient = radtIntegrate.QueryPatientInfoByInpatientNO(feeItemList.Patient.ID);

                if (this.ApplyOut(patient, originalFee, feeInpatientManager.GetDateTimeFromSysDateTime(), true) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }

        #endregion

        #region 申请函数作废 根据执行单流水号作废申请

        /// <summary>
        /// 取消出库申请
        /// 根据处方流水号和处方内序号，作废出库申请
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int CancelApplyOut(string orderExecNO)
        {
            this.SetDB(itemManager);

            //Pharmacy.IsApproveCharge = Pharmacy.QueryControlForBool("501003", false);
            //如果摆药时计费 则不进行预扣库存操作 否则 预扣库存   SysConst.Use_Drug_ApartFee "100003"
            Pharmacy.IsApproveCharge = !this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            return itemManager.CancelApplyOut(orderExecNO, Pharmacy.IsInPatientPreOut);
        }

        /// <summary>
        /// 撤销取消出库申请（取消申请的逆过程）
        /// 根据执行档流水号更新出库申请
        /// </summary>
        /// <param name="orderExecNO">执行档流水号</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UndoCancelApplyOut(string orderExecNO)
        {
            this.SetDB(itemManager);

            //Pharmacy.IsApproveCharge = Pharmacy.QueryControlForBool("501003", false);
            //如果摆药时计费 则不进行预扣库存操作 否则 预扣库存   SysConst.Use_Drug_ApartFee "100003"
            Pharmacy.IsApproveCharge = !this.ctrlIntegrate.GetControlParam<bool>(SysConst.Use_Drug_ApartFee, false, true);

            //是否实现预扣库存操作
            Pharmacy.IsInPatientPreOut = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, false, true);

            return itemManager.UndoCancelApplyOut(orderExecNO, Pharmacy.IsInPatientPreOut);
        }

        #endregion

        #region 申请信息作废 根据住院流水号进行作废

        /// <summary>
        /// 药品发药申请信息作废
        /// 
        /// {CC0E14C4-A66B-42db-A6D7-82DF31870DDC}  根据患者信息作废药品申请
        /// </summary>
        /// <param name="patientID">住院流水号</param>
        /// <param name="drugDeptCode">库存药房</param>
        /// <param name="applyDept">申请科室</param>
        /// <param name="beginTime">起始时间</param>
        /// <param name="endTime">截至时间</param>
        /// <returns>成功返回1  失败返回-1</returns>
        public int CancelApplyOut(string patientID, string drugDeptCode, string applyDept, DateTime beginTime, DateTime endTime)
        {
            ArrayList alApplyList = this.itemManager.GetPatientApply(patientID, drugDeptCode, applyDept, beginTime, endTime, "0");

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alApplyList)
            {
                //有效数据才进行后续处理
                if (info.ValidState == EnumValidState.Valid)
                {
                    if (this.CancelApplyOut(info.ExecNO) == -1)
                    {
                        return -1;
                    }
                }
            }

            return 1;
        }

        #endregion

        #endregion

        /// <summary>
        /// 取消出库申请
        /// 根据出库申请流水号，作废出库申请
        /// </summary>
        /// <param name="ID">出库申请流水号</param>
        /// <param name="validState">有效状态</param>
        /// <returns>正确1,没找到数据0,错误－1</returns>
        public int UpdateApplyOutValidState(string ID, string validState)
        {
            this.SetDB(itemManager);

            return itemManager.UpdateApplyOutValidState(ID, validState);
        }

        /// <summary>
        /// 更新摆药申请处方号
        /// </summary>
        /// <param name="oldRecipeNo">旧处方号</param>
        /// <param name="oldSeqNo">旧处方内项目序号</param>
        /// <param name="newRecipeNo">新处方号</param>
        /// <param name="newSeqNo">新处方内项目许号</param>
        /// <returns>成功返回1 出错返回-1</returns>
        public int UpdateApplyOutRecipe(string oldRecipeNo, int oldSeqNo, string newRecipeNo, int newSeqNo)
        {
            this.SetDB(itemManager);

            return itemManager.UpdateApplyOutRecipe(oldRecipeNo, oldSeqNo, newRecipeNo, newSeqNo);
        }

        #endregion

        #region 直接退库操作

        /// <summary>
        /// 门诊退库
        /// 如果退库申请中，指定确定的批次，则将此批次记录退掉。
        /// 否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。
        /// </summary>
        /// <param name="feeInfo">收费费用实体</param>
        /// <param name="operCode">操作员</param>
        /// <param name="operDate">操作时间</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList feeInfo, string operCode, DateTime operDate)
        {
            this.SetDB(itemManager);

            return itemManager.OutputReturn(feeInfo, operCode, operDate);
        }

        /// <summary>
        /// 住院退库
        /// 如果退库申请中，指定确定的批次，则将此批次记录退掉。
        /// 否则，在与出库申请对应的出库记录中按批次小先退的原则，做退库处理。
        /// </summary>
        /// <param name="feeInfo">收费费用实体</param>
        /// <param name="operCode">操作员</param>
        /// <param name="operDate">操作时间</param>
        /// <returns>成功返回1 失败返回-1 无记录返回0</returns>
        public int OutputReturn(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeInfo, string operCode, DateTime operDate)
        {
            this.SetDB(itemManager);

            return itemManager.OutputReturn(feeInfo, operCode, operDate);
        }        
        #endregion

        #region 库存信息

        /// <summary>
        /// 取某一药房中某一药品在库存汇总表中的数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="deptCode">库房编码</param>
        /// <param name="storageNum">库存总数量（返回参数）</param>
        /// <returns>1成功，-1失败</returns>
        public int GetStorageNum(string deptCode, string drugCode, out decimal storageNum)
        {
            this.SetDB(itemManager);

            return itemManager.GetStorageNum(deptCode, drugCode, out storageNum);
        }

        /// <summary>
        /// 取某一药房中某一药品在库存汇总表中的数量
        /// </summary>
        /// <param name="deptCode">药房编码</param>
        /// <param name="drugQuality">药品性质编码</param>
        /// <returns>成功返回库存记录数组，出错返回null</returns>
        public ArrayList QueryStockinfoList(string deptCode, string drugQuality)
        {
            this.SetDB(itemManager);

            return itemManager.QueryStockinfoList(deptCode, drugQuality);
        }

        /// <summary>
        /// 取某一药房中在库存汇总表中的记录
        /// </summary>
        /// <param name="deptCode">库房编码</param>
        /// <returns>库存记录数组，出错返回null</returns>
        public ArrayList QueryStockinfoList(string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryStockinfoList(deptCode);
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="storageBase">库存基类</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UpdateStorage(StorageBase storageBase)
        {
            this.SetDB(itemManager);

            return itemManager.UpdateStorageNum(storageBase);
        }

        /// <summary>
        /// 通过科室编码和药品编码获得库存信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>成功 库存信息实体 失败 null</returns>
        public Neusoft.HISFC.Models.Pharmacy.Storage GetStockInfoByDrugCode(string deptCode, string drugCode) 
        {
            this.SetDB(itemManager);

            return itemManager.GetStockInfoByDrugCode(deptCode, drugCode);
        }

        /// <summary>
        /// 更新预扣库存、预扣数量（正数是增加，负数是减少）
        /// 
        /// {C37BEC96-D671-46d1-BCDD-C634423755A4} 更改参数定义
        /// </summary>
        /// <param name="drugDeptCode">库存编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <param name="alterStoreNum">库存变化量</param>
        /// <returns>成功 1 失败 -1</returns>
        public int UpdateStoragePreOutNum(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal alterStoreNum, decimal days)
        {
            this.SetDB(itemManager);

            return itemManager.UpdateStockinfoPreOutNum(applyOut, alterStoreNum, days);
        }

        #endregion

        #region 配药属性/多级单位属性

        /// <summary>
        /// 获取药品配药属性
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="doseCode">剂型编码</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回配药属性 0 不可拆分 1 可拆分不取整 2 可拆分上取整，失败返回NULL</returns>
        public string GetDrugProperty(string drugCode, string doseCode, string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.GetDrugProperty(drugCode, doseCode, deptCode);
        }

        /// <summary>
        /// 根据传入数量 计算取整后数量
        /// </summary>
        /// <param name="drugCode">药品编码</param>
        /// <param name="doseCode">剂型编码</param>
        /// <param name="doseOnce">医嘱每次量</param>
        /// <param name="baseDose">基本剂量</param>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回取整后数量</returns>
        public decimal ComputeAmount(string drugCode, string doseCode, decimal doseOnce, decimal baseDose, string deptCode)
        {
            string unitSate = this.GetDrugProperty(drugCode, doseCode, deptCode);
            decimal amount = 0;
            if (baseDose == 0) return amount;
            switch (unitSate)
            {
                case "0"://不可以，向上取整
                    //amount = (decimal)System.Math.Ceiling((double)doseOnce / (double)baseDose);
                    amount = (decimal)System.Math.Ceiling((double)((decimal)doseOnce / (decimal)baseDose));
                    break;
                case "1"://可以，配药时不取整
                    amount = System.Convert.ToDecimal(doseOnce) / baseDose;
                    break;
                case "2"://可以，配药时上取整 
                    amount = System.Convert.ToDecimal(doseOnce) / baseDose;
                    break;
                default://
                    amount = System.Convert.ToDecimal(doseOnce) / baseDose;
                    break;
            }
            return amount;
        }

        /// <summary>
        /// 根据指定类别 获取取整后的特殊单位、转换取整数量
        /// 以最小单位数量显示
        /// </summary>
        /// <param name="unitType">类别</param>
        /// <param name="item">药品实体</param>
        /// <param name="originalNum">原始传入数量 以最小单位显示</param>
        /// <param name="splitNum">转换后取整数量 以最小单位显示</param>
        /// <param name="splitUnit">该类别对应的特殊单位</param>
        /// /// <param name="standNum">每个特殊单位对应最小单位数量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int QuerySpeUnit(string unitType, Neusoft.HISFC.Models.Pharmacy.Item item, decimal originalNum, out decimal splitNum, out string splitUnit, out decimal standNum)
        {
            this.SetDB(itemManager);

            return itemManager.QuerySpeUnit(unitType, item, originalNum, out splitNum, out splitUnit, out standNum);
        }
       
        /// <summary>
        /// 返回门诊取整数量
        /// </summary>
        /// <param name="item">药品实体</param>
        /// <param name="originalNum">原始传入数量 以最小单位计算</param>
        /// <param name="splitNum">转换后取整数量 以最小单位显示</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int QuerySpeUnitForClinic(Neusoft.HISFC.Models.Pharmacy.Item item, decimal originalNum, out decimal splitNum)
        {
            string unit = "";
            decimal standNum;

            return this.QuerySpeUnit("Clinic", item, originalNum, out splitNum, out unit, out standNum);
        }

        #endregion

        #region 库存监控

        /// <summary>
        /// 获取库存量低于库存警戒线的药品
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回Storage实体数组 失败返回null</returns>
        public ArrayList QueryWarnStockDrug(string deptCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryWarnDrugStockInfoList(deptCode);
        }

        /// <summary>
        /// 根据科室编码/药品编码 获取该药品在科室内库存是否已低于警戒线
        /// </summary>
        /// <param name="stockDeptCode">库房编码</param>
        /// <param name="drugCode">药品编码</param>
        /// <returns>等于小于警戒线 False 大于警戒线 True</returns>
        public bool GetWarnDrugStock(string stockDeptCode, string drugCode)
        {
            this.SetDB(itemManager);

            return itemManager.GetWarnDrugStock(stockDeptCode, drugCode);
        }

        /// <summary>
        /// 获取本科室有效期报警信息
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns>成功返回科室有效期报警信息 失败返回null</returns>
        public ArrayList GetWarnValidStock(string deptCode)
        {
            this.SetDB(itemManager);

            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            //警戒线默认天数
            int ctrlValid = ctrlParamIntegrate.GetControlParam<int>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Valid_Warn_Days, true, 30);

            return itemManager.QueryWarnValidDateStockInfoList(deptCode, ctrlValid);
        }

        #endregion

        #region 患者库存

        /// <summary>
        /// 对患者管理库存的药品进行出库处理
        /// </summary>
        /// <param name="execOrder">医嘱执行实体</param>
        /// <param name="feeFlag">计费标志 0 不计费 1 根据计费数量feeNum进行计费 2 按原流程进行 根据执行档信息正常计费</param>
        /// <param name="isFee">是否已收费 feeFlag 为 "0" 时该参数才有意义</param>
        /// <param name="feeNum">计费数量 isFee为true时本参数才有效</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int PatientStore(Neusoft.HISFC.Models.Order.ExecOrder execOrder, ref string feeFlag, ref decimal feeNum, ref bool isFee)
        {
            this.SetDB(itemManager);

            return itemManager.PatientStore(execOrder, ref feeFlag, ref feeNum, ref isFee);
        }

        /// <summary>
        /// 获得科室,患者库存
        /// </summary>
        /// <param name="deptCode">科室或者患者住院流水号</param>
        /// <param name="itemCode">项目编码</param>
        /// <returns>成功 获得科室,患者库存 失败 null</returns>
        public ArrayList QueryStorageList(string deptCode, string itemCode)
        {
            this.SetDB(itemManager);

            return itemManager.QueryStorageList(deptCode, itemCode);
        }

        #endregion

        #region 退费申请信息检索调用

        /// <summary>
        /// 取某一药房中某一申请科室，某一患者待退药明细列表
        /// </summary>
        /// <param name="applyDeptCode">申请科室编码</param>
        /// <param name="medDeptCode">药房编码</param>
        /// <param name="patientID">住院流水号 查询全部患者住院流水号传入空</param>
        /// <returns>成功返回ApplyOut实体数组 失败返回null</returns>
        public ArrayList QueryDrugReturn(string applyDeptCode, string medDeptCode, string patientID)
        {
            this.SetDB(itemManager);

            return itemManager.QueryDrugReturn(applyDeptCode, medDeptCode, patientID);
        }

        public List<Neusoft.HISFC.Models.Fee.ReturnApply> QueryReturnApply(string applyDeptCode, string medDeptCode, string patientID)
        {
            ArrayList al = this.QueryDrugReturn(applyDeptCode, medDeptCode, patientID);
            if (al == null)
            {
                return null;
            }

            List<Neusoft.HISFC.Models.Fee.ReturnApply> returnApplyList = new List<Neusoft.HISFC.Models.Fee.ReturnApply>();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
            {
                Neusoft.HISFC.Models.Fee.ReturnApply temp = new Neusoft.HISFC.Models.Fee.ReturnApply();

                temp.Item = info.Item;

                //applyOut.ID = applyReturn.ID;								//申请流水号
                //applyOut.BillCode = applyReturn.BillCode;					//申请单据号
                //applyOut.RecipeNo = applyReturn.RecipeNo;					//处方号
                //applyOut.SequenceNo = applyReturn.SequenceNo;				//处方内项目流水号
                //applyOut.ApplyDept.ID = applyReturn.OperDpcd;				//申请科室
                //applyOut.Item.Name = applyReturn.Item.Name;					//项目名称
                //applyOut.Item.ID = applyReturn.Item.ID;						//项目编码
                //applyOut.Item.Specs = applyReturn.Item.Specs;				//规格
                //applyOut.Item.Price = applyReturn.Item.Price;				//零售价  以最小单位计算的零售价
                //applyOut.ApplyNum = applyReturn.Item.Amount;				//申请退药数量（乘以付数后的总数量）
                //applyOut.Item.PackQty = applyReturn.Item.PackQty;
                //applyOut.Days = applyReturn.Days;							//付数
                //applyOut.Item.MinUnit = applyReturn.Item.PriceUnit;			//计价单位
                //applyOut.User01 = "0";										//标志该数据由病区退费申请表获得 由applyReturn实体获取
                //applyOut.BillCode = applyReturn.BillCode;
            }

            return null;
        }

        #endregion

        #region 获取取药药房列表

        public ArrayList QueryReciveDrugDept(string roomCode,string drugType)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            this.SetDB(phaConsManager);

            return phaConsManager.QueryReciveDrugDept(roomCode, drugType);
        }

        #endregion

        #region addby xuewj 2010-10-10 增加执行科室/发药药房显示 {313866E8-C672-44bd-9635-E3A3397A53EA}
        /// <summary>
        /// 获取所有取药药房列表
        /// </summary>
        /// <param name="roomCode"></param>
        /// <returns></returns>
        public ArrayList QueryReciveDrugDeptNew(string roomCode)
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            this.SetDB(phaConsManager);

            return phaConsManager.QueryReciveDrugDeptNew(roomCode);
        } 
        #endregion

        #region 制剂库存扣除、成品入库

        /// <summary>
        /// 制剂生产原料库存扣除.出库记录生成。
        /// </summary>
        /// <param name="materialItem">生产原料出库信息</param>
        /// <param name="outDept">出库科室</param>
        /// <param name="qty">出库数量</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public int ProduceOutput(Neusoft.HISFC.Models.Pharmacy.Item materialItem,Neusoft.HISFC.Models.Preparation.Expand expand,Neusoft.FrameWork.Models.NeuObject outDept)
        {
            this.SetDB(itemManager);

            return itemManager.ProduceOutput(materialItem, expand, outDept);
        }

        /// <summary>
        /// 制剂原料申请
        /// </summary>
        /// <param name="item">出库项目信息</param>
        /// <param name="expand">制剂消耗信息</param>
        /// <param name="applyDept">申请科室</param>
        /// <param name="stockDept">库存科室</param>
        /// <returns></returns>
        public int ProduceApply(Neusoft.HISFC.Models.Pharmacy.Item item, Neusoft.HISFC.Models.Preparation.Expand expand, Neusoft.FrameWork.Models.NeuObject applyDept, Neusoft.FrameWork.Models.NeuObject stockDept)
        {
            this.SetDB(itemManager);

            return itemManager.ProduceApply(item, expand, applyDept, stockDept);
        }

        /// <summary>
        /// 制剂生产入库
        /// </summary>
        /// <param name="preparationList">入库制剂信息</param>
        /// <returns></returns>
        public int ProduceInput(List<Neusoft.HISFC.Models.Preparation.Preparation> preparationList,Neusoft.FrameWork.Models.NeuObject pprDept,Neusoft.FrameWork.Models.NeuObject stockDept,bool isApply)
        {
            this.SetDB(itemManager);

            return itemManager.ProduceInput(preparationList, pprDept,stockDept,isApply);
        }
        #endregion

        #region 药理作用

        /// <summary>
        /// 查询药理作用叶子节点数组 by Sunjh 2009-6-5 {D7977C2D-3047-406f-A0D2-4B7245CB0088}
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryPhaFunction()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            return consManager.QueryPhaFunctionLeafage();
        }

        #endregion

        #region 医疗权限

        /// <summary>
        /// 医疗权限验证方法（提供医生站使用） {4D5E0EB4-E673-478b-AE8C-6A537F49FC5C}
        /// </summary>
        /// <param name="operCode">医生代码</param>
        /// <param name="drugInfo">药品实体</param>
        /// <returns> -1失败 0无权限 大于0有权限</returns>
        public int CheckPopedom(string operCode, Neusoft.HISFC.Models.Pharmacy.Item drugInfo)
        {
            string doctLevel = "";
            int retCode = -1;
            Neusoft.HISFC.BizLogic.Pharmacy.Constant constantManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            Neusoft.HISFC.Models.Base.Employee emplObj = personManager.GetPersonByID(operCode);
            if (emplObj != null)
            {
                doctLevel = emplObj.Level.ID;
            }

            if (doctLevel == "")
            {
                return -1;
            }

            if (drugInfo.Quality.ID != "")
            {
                retCode = constantManager.QueryPopedom(doctLevel, drugInfo.Quality.ID, 0);
                if (retCode > 0)
                {
                    if (drugInfo.PhyFunction1.ID != "")
                    {
                        retCode = constantManager.QueryPopedom(doctLevel, drugInfo.PhyFunction1.ID, 1);
                    }
                    else
                    {
                        retCode = 1;
                    }
                }
                else
                {
                    return retCode;
                }
            }
            else
            {
                retCode = 1;
            }            

            return retCode;
        }

        #endregion

        #region 账户新增  //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        /// <summary>
        /// 删除单条药品发药申请
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequenceNO">处方内项目流水号</param>
        /// <returns></returns>
        public int DelApplyOut(Neusoft.HISFC.Models.Order.Order order)
        {
            this.SetDB(itemManager);
            this.SetDB(OutPatientfeeManager);
            this.SetDB(drugStoreManager);
            string recipeNO = order.ReciptNO;
            string recipeSequenceNO = order.SequenceNO.ToString();
            string execDeptCode = order.StockDept.ID;
            //删除发药申请
            if (itemManager.DelApplyOut(recipeNO, recipeSequenceNO) <= 0)
            {
                this.Err = "删除发药申请失败！" + itemManager.Err;
                return -1;
            }
            //根据处方号执行科室查询药品费用信息
            ArrayList drugFee = OutPatientfeeManager.GetDurgFeeByRecipeAndDept(recipeNO, execDeptCode);
            if (drugFee == null)
            {
                return -1;
            }
            if (drugFee.Count == 0)
            {
                if (drugStoreManager.DeleteDrugStoRecipe(recipeNO, execDeptCode) < 0)
                {
                    this.Err = "删除调剂头表信息失败！" + drugStoreManager.Err;
                    return -1;
                }
            }
            else
            {
                decimal cost = 0m;
                int drugCount = drugFee.Count;
                foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList f in drugFee)
                {
                    cost += f.FT.OwnCost;
                }
                if (drugStoreManager.UpdateStoRecipe(recipeNO, execDeptCode, cost, drugCount) <= 0)
                {
                    this.Err = "更新处方调剂表失败！" + drugStoreManager.Err;
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 划价时删除药品发药申请
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="recipeSequenceNO">处方项目流水号</param>
        /// <returns></returns>
        public int DelApplyOut(string recipeNO, string recipeSequenceNO)
        {
            this.SetDB(itemManager);
            return itemManager.DelApplyOut(recipeNO, recipeSequenceNO);
        }

        /// <summary>
        /// 删除调剂头表
        /// </summary>
        /// <param name="recipeNO">处方号</param>
        /// <param name="execDeptCode">执行科室</param>
        /// <returns></returns>
        public int DeleteDrugStoRecipe(string recipeNO, string execDeptCode)
        {
            this.SetDB(OutPatientfeeManager);
            return drugStoreManager.DeleteDrugStoRecipe(recipeNO, execDeptCode);
        }
        #endregion

        #region 协定处方
        /// <summary>
        /// 获取协定处方药品列表
        /// </summary>
        /// <returns>成功返回协定处方药品数据 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryNostrumList()
        {
            this.SetDB(itemManager);

            return itemManager.QueryNostrumList("ALL");
        }

        /// <summary>
        /// 获取协定处方药品列表
        /// </summary>
        /// <returns>成功返回协定处方药品数据 失败返回null</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Item> QueryNostrumList(string DrugType)
        {
            this.SetDB(itemManager);

            return itemManager.QueryNostrumList(DrugType);
        }

        /// <summary>
        /// 查询协定处方按明细计算的单价
        /// </summary>
        /// <param name="nostrumCode">协定处方编码</param>
        /// <returns>单付价格0则查询失败或没有维护</returns>
        public decimal GetNostrumPrice(string nostrumCode)
        {
            this.SetDB(itemManager);

            return itemManager.GetNostrumPrice(nostrumCode);
        }

        /// <summary>
        /// 获取协定处方明细信息
        /// </summary>
        /// <param name="packageCode">组套编码</param>
        /// <returns>成功返回1 失败返回－1</returns>
        public List<Neusoft.HISFC.Models.Pharmacy.Nostrum> QueryNostrumDetail(string packageCode)
        {
            this.SetDB(itemManager);
            return itemManager.QueryNostrumDetail(packageCode);
        }

        #endregion

        /// <summary>
        /// 根据科室编码、药品类别、药品编码查询药房信息
        /// </summary>
        /// <param name="deptID">科室编码</param>
        /// <param name="itemType">药品类别</param>
        /// <param name="itemCode">药品编码</param>
        /// <returns></returns>
        public Neusoft.FrameWork.Models.NeuObject GetStockDept(string deptID, string itemType, string itemCode)
        {
            // 获取扣库科室
            ArrayList al = this.QueryReciveDrugDept(deptID, itemType);
            Neusoft.FrameWork.Models.NeuObject stockDept = new Neusoft.FrameWork.Models.NeuObject();

            if (al == null)
            {
                this.Err = "获得取药科室信息错误!";
                return null;
            }
            else if (al.Count == 0)
            {
                this.Err = "获得取药科室信息错误,请确认项目所在病区已设置取药科室";
                return null;
            }

            //排除的药房--临床营养中心
            ArrayList alCons = this.constantMgr.GetList("RemoveDrugRoom");
            if (alCons == null)
            {
                this.Err = this.constantMgr.Err;
                return null;
            }

            if (alCons.Count == 0)
            {
                this.Err = "请维护常数RemoveDrugRoom";
                return null;
            }
            Neusoft.FrameWork.Models.NeuObject removeDept = alCons[0] as Neusoft.FrameWork.Models.NeuObject;
            ArrayList alTempDepts = new ArrayList();

            foreach (Neusoft.FrameWork.Models.NeuObject drugDeptInfo in al)
            {
                if (drugDeptInfo.ID != removeDept.ID)
                {
                    decimal storageNum = 0;
                    this.itemManager.GetStorageNum(drugDeptInfo.ID, itemCode, out storageNum);
                    if (storageNum > 0)
                    {
                        alTempDepts.Add(drugDeptInfo);
                    }
                }
            }

            if (alTempDepts.Count == 0)//只对应一个药房
            {
                stockDept = removeDept;
            }
            else if (alTempDepts.Count == 1)//排除后只剩一个药房
            {
                stockDept = alTempDepts[0] as Neusoft.FrameWork.Models.NeuObject;
            }
            else//排除后有多个药房--郑大无此情况
            {
            }
            if (stockDept.ID == "")
            {
                this.Err = "查询默认取消药房失败!";
            }

            return stockDept;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data;
using System.Text; 
using System.Collections;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.HISFC.Models.Registration;
using Controler = Neusoft.HISFC.BizLogic.Manager.Controler; 
namespace Neusoft.HISFC.BizLogic.Terminal
{
    /// <summary>
    /// TerminalConfirm <br></br>
    /// [功能描述: 医技终端确认业务层类]<br></br>
    /// [创 建 者: 赫一阳]<br></br>
    /// [创建时间: 2007-3-1]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class TerminalConfirm : Neusoft.FrameWork.Management.Database
    {
        #region 普通构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public TerminalConfirm()
        {
            // 初始化局部变量
            this.intReturn = 0;
            this.SQL = "";
        }
        #endregion
        #region 构造函数：带事务对象入参
        /// <summary>
        /// 构造函数：带事务对象入参
        /// </summary>
        /// <param name="transaction">事务对象</param>
        public TerminalConfirm(Neusoft.FrameWork.Management.Transaction transaction)
        {
            // 初始化局部变量
            this.intReturn = 0;
            this.SQL = "";
            // 设置事务对象
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
        }
        #endregion

        #region 变量

        /// <summary>
        /// 存储各种调用的返回值
        /// </summary>
        private int intReturn;

        /// <summary>
        /// 执行操作所使用的SQL语句
        /// </summary>
        private string SQL;

        /// <summary>
        /// SQL语句的WHERE条件
        /// </summary>
        private string WHERE;

        /// <summary>
        /// SQL语句的ORDER语句
        /// </summary>
        private string ORDER;

        /// <summary>
        /// 限制的日期
        /// </summary>
        string stringLimitedDate = "";

        /// <summary>
        /// 是否有时间限制
        /// </summary>
        
        bool boolLimited = false;

        /// <summary>
        /// 参数数组
        /// </summary>
        string[] parms = new string[39];

        /// <summary>
        /// 业务子表参数数组
        /// </summary>
        string[] detailParms = new string[21];

        #endregion

        #region 私有函数

        #region 设置错误信息
        /// <summary>
        /// 设置错误信息
        /// </summary>
        /// <param name="errorCode">错误代码发生行数</param>
        /// <param name="errorText">错误信息</param>
        private void SetError(string errorCode, string errorText)
        {
            this.ErrCode = errorCode;
            this.Err = errorText + "[" + this.Err + "]"; // + "在TerminalConfirm.cs的第" + argErrorCode + "行代码";
            this.WriteErr();
        }
        #endregion
        #region 初始化变量
        /// <summary>
        /// 初始化变量
        /// </summary>
        private void Clear()
        {
            this.intReturn = 0;
            this.SQL = "";
            this.WHERE = "";
            this.stringLimitedDate = "";
            this.boolLimited = false;
            this.ORDER = "";
        }
        #endregion

        #region 获取主SQL语句
        /// <summary>
        /// 获取主SQL
        /// </summary>
        /// <returns></returns>
        private string GetTerminalSql()
        {
            // SQL语句
            string strSql = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Terminal.TerminalValidate.GetApplyListByCardNO", ref strSql) == -1)
            {
                this.Err = "获取SQL语句Terminal.TerminalValidate.GetApplyListByCardNO 失败";
                return null;
            }
            return strSql;
        }
        #endregion

        #region  私有 获取终端确认信息
        private ArrayList GetTerminalList(string strSql)
        {
            ArrayList applyList = new ArrayList();
            //执行查询语句
            if (this.ExecQuery(strSql) == -1)
            {
                this.Err = "获取终端确认信息时，执行SQL语句出错！" + this.Err;
                this.ErrCode = "-1";
                return null;
            }
            try
            {
                // 定义承载对象
                Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply;

                while (this.Reader.Read()) // 循环读取继承的Reader对象
                {
                    #region 获取数据
                    terminalApply = new TerminalApply();
                    // 申请单流水号[3]
                    terminalApply.ID = this.Reader[0].ToString();

                    // 住院流水号或门诊号[04]
                    terminalApply.Patient.PID.ID = this.Reader[1].ToString();
                    terminalApply.Patient.ID = terminalApply.Patient.PID.ID;
                    // 姓名[05]
                    terminalApply.Patient.Name = this.Reader[2].ToString();
                    // 合同单位[06]
                    terminalApply.Patient.Pact.ID = this.Reader[3].ToString();
                    // 申请部门编码（科室或者病区）[07]
                    terminalApply.Item.Order.DoctorDept.ID = this.Reader[4].ToString();
                    // 终端科室编码[08]
                    terminalApply.Item.ExecOper.Dept.ID = this.Reader[5].ToString();
                    // 门诊是挂号科室、住院是在院科室[09]
                    terminalApply.Patient.DoctorInfo.Templet.Dept.ID = this.Reader[6].ToString();
                    // 发药部门编码[10]
                    terminalApply.Item.Order.DoctorDept.ID = this.Reader[7].ToString();

                    // 更新库存的流水号(物资)[11]
                    terminalApply.UpdateStoreSequence = Convert.ToInt32(this.Reader[8]);

                    // 开立医师代码[12]
                    //terminalApply.Item.DoctInfo.ID = this.Reader[11].ToString();
                    terminalApply.Item.Order.Doctor.ID = this.Reader[9].ToString();

                    // 处方号[13]
                    //terminalApply.Item.RecipeNo = this.Reader[12].ToString();
                    terminalApply.Item.RecipeNO = this.Reader[10].ToString();

                    // 处方内项目流水号[14]
                    //terminalApply.Item.SeqNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());
                    terminalApply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[11].ToString());

                    // 项目代码[15]
                    terminalApply.Item.Item.ID = this.Reader[12].ToString();

                    // 项目名称[16]
                    terminalApply.Item.Item.Name = this.Reader[13].ToString();

                    // 单价[17]
                    //terminalApply.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
                    terminalApply.Item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14].ToString());

                    // 数量[18]
                    //terminalApply.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
                    terminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15].ToString());

                    //当前单位[19]
                    //terminalApply.Item.PriceUnit = this.Reader[18].ToString();
                    terminalApply.Item.Item.PriceUnit = this.Reader[16].ToString();

                    //组套代码[20]
                    //terminalApply.Item.Package.ID = this.Reader[19].ToString();
                    terminalApply.Item.UndrugComb.ID = this.Reader[17].ToString();

                    // 组套名称[21]
                    //terminalApply.Item.Package.Name = this.Reader[20].ToString();
                    terminalApply.Item.UndrugComb.Name = this.Reader[18].ToString();

                    // 费用金额[22]
                    //terminalApply.Item.Cost.Tot_Cost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[21].ToString());
                    terminalApply.Item.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());

                    // 项目状态（0 划价  1 批费 2 执行（药品发放））[23]
                    terminalApply.ItemStatus = this.Reader[20].ToString();

                    // 已确认数[24]
                    terminalApply.AlreadyConfirmCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[21].ToString());

                    // 设备号[25]
                    terminalApply.Machine.ID = this.Reader[22].ToString();

                    // 根据设备编号获取设备名称
                    //
                    if (this.Reader[23].ToString() == "0") // 收费标志：0未收费，1已收费[26]
                    {
                        terminalApply.Item.PayType = PayTypes.Charged;
                    }
                    else
                    {
                        terminalApply.Item.PayType = PayTypes.Balanced;
                    } // 收费标志：0未收费，1已收费[26]

                    // 新旧项目标识： 0 旧 1 新[27]
                    terminalApply.NewOrOld = this.Reader[24].ToString();

                    // 扩展标志1[28]
                    terminalApply.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[25].ToString());

                    // 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)[29]
                    terminalApply.User02 = this.Reader[26].ToString();

                    // 备注[30]
                    terminalApply.User03 = this.Reader[27].ToString();

                    // 医嘱流水号[31]
                    terminalApply.Order.ID = this.Reader[28].ToString();

                    // 医嘱执行单流水号[32]
                    terminalApply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29].ToString());

                    // 操作员（插入申请单）[33]
                    //terminalApply.InsertOperator.ID = this.Reader[32].ToString();
                    terminalApply.InsertOperEnvironment.ID = this.Reader[30].ToString();

                    // 操作时间（插入申请单）[34]
                    //terminalApply.InsertDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[33].ToString());
                    terminalApply.InsertOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[31].ToString());

                    // 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检[35]
                    terminalApply.PatientType = this.Reader[32].ToString();
                    terminalApply.Patient.Memo = this.Reader[32].ToString();

                    // 性别[36]
                    //terminalApply.Patient.SexID = this.Reader[35].ToString();
                    terminalApply.Patient.Sex.ID = this.Reader[33].ToString();

                    // 药品发放时间[37]
                    terminalApply.SendDrugDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[34].ToString());

                    // 终端执行人编号[38]
                    //terminalApply.ConfirmOperator.ID = this.Reader[37].ToString();
                    terminalApply.ConfirmOperEnvironment.ID = this.Reader[35].ToString();

                    // 终端执行时间[39]
                    //terminalApply.ConfirmDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[38].ToString());
                    terminalApply.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[36].ToString());

                    // 是否药品（1：是/0：否）[40]
                    //terminalApply.Item.IsPhamarcy = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[39].ToString());
                    //terminalApply.Item.Item.IsPharmacy = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[37].ToString());
                    terminalApply.Item.Item.ItemType = (EnumItemType)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[37].ToString());

                    // 病历号
                    //terminalApply.Patient.PID.CardNo = this.Reader[40].ToString();
                    terminalApply.Patient.PID.CardNO = this.Reader[38].ToString();

                    applyList.Add(terminalApply);
                    #endregion

                }
            }//抛出错误
            catch (Exception ex)
            {
                this.Err = "获取终端确认信息出错！" + ex.Message;
                this.ErrCode = "-1";
                return null;
            }
            this.Reader.Close();
            return applyList;
        }
        #endregion
        #region 从Reader返回的申请单全部明细ArrayList
        /// <summary>
        /// 从Reader返回的申请单全部明细ArrayList
        /// </summary>
        /// <param name="applyList">返回的申请单全部字段明细</param>
        private void FillApply(ref ArrayList applyList)
        {
            // 定义承载对象
            Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply;

            while (this.Reader.Read()) // 循环读取继承的Reader对象
            {
                terminalApply = new TerminalApply();
                // 申请单流水号[3]
                terminalApply.ID = this.Reader[0].ToString();

                // 住院流水号或门诊号[04]
                terminalApply.Patient.PID.ID = this.Reader[1].ToString();
                terminalApply.Patient.ID = terminalApply.Patient.PID.ID;
                // 姓名[05]
                terminalApply.Patient.Name = this.Reader[2].ToString();
                // 合同单位[06]
                terminalApply.Patient.Pact.ID = this.Reader[3].ToString();
                // 申请部门编码（科室或者病区）[07]
                terminalApply.Item.Order.DoctorDept.ID = this.Reader[4].ToString();
                // 终端科室编码[08]
                terminalApply.Item.ExecOper.Dept.ID = this.Reader[5].ToString();
                // 门诊是挂号科室、住院是在院科室[09]
                terminalApply.Patient.DoctorInfo.Templet.Dept.ID = this.Reader[6].ToString();
                // 发药部门编码[10]
                terminalApply.Item.Order.DoctorDept.ID = this.Reader[7].ToString();

                // 更新库存的流水号(物资)[11]
                terminalApply.UpdateStoreSequence = Convert.ToInt32(this.Reader[8]);

                // 开立医师代码[12]
                //terminalApply.Item.DoctInfo.ID = this.Reader[11].ToString();
                terminalApply.Item.Order.Doctor.ID = this.Reader[9].ToString();

                // 处方号[13]
                //terminalApply.Item.RecipeNo = this.Reader[12].ToString();
                terminalApply.Item.RecipeNO = this.Reader[10].ToString();

                // 处方内项目流水号[14]
                //terminalApply.Item.SeqNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13].ToString());
                terminalApply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[11].ToString());

                // 项目代码[15]
                terminalApply.Item.Item.ID = this.Reader[12].ToString();

                // 项目名称[16]
                terminalApply.Item.Item.Name = this.Reader[13].ToString();

                // 单价[17]
                //terminalApply.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[16].ToString());
                terminalApply.Item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[14].ToString());

                // 数量[18]
                //terminalApply.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[17].ToString());
                terminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[15].ToString());

                //当前单位[19]
                //terminalApply.Item.PriceUnit = this.Reader[18].ToString();
                terminalApply.Item.Item.PriceUnit = this.Reader[16].ToString();

                //组套代码[20]
                //terminalApply.Item.Package.ID = this.Reader[19].ToString();
                terminalApply.Item.UndrugComb.ID = this.Reader[17].ToString();

                // 组套名称[21]
                //terminalApply.Item.Package.Name = this.Reader[20].ToString();
                terminalApply.Item.UndrugComb.Name = this.Reader[18].ToString();

                // 费用金额[22]
                //terminalApply.Item.Cost.Tot_Cost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[21].ToString());
                terminalApply.Item.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[19].ToString());

                // 项目状态（0 划价  1 批费 2 执行（药品发放））[23]
                terminalApply.ItemStatus = this.Reader[20].ToString();

                // 已确认数[24]
                terminalApply.AlreadyConfirmCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[21].ToString());

                // 设备号[25]
                terminalApply.Machine.ID = this.Reader[22].ToString();

                // 根据设备编号获取设备名称
                //
                if (this.Reader[23].ToString() == "0") // 收费标志：0未收费，1已收费[26]
                {
                    terminalApply.Item.PayType = PayTypes.Charged;
                }
                else
                {
                    terminalApply.Item.PayType = PayTypes.Balanced;
                } // 收费标志：0未收费，1已收费[26]

                // 新旧项目标识： 0 旧 1 新[27]
                terminalApply.NewOrOld = this.Reader[24].ToString();

                // 有效标志1[28]
                terminalApply.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[25].ToString());

                // 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)[29]
                terminalApply.User02 = this.Reader[26].ToString();

                // 备注[30]
                terminalApply.User03 = this.Reader[27].ToString();

                // 医嘱流水号[31]
                terminalApply.Order.ID = this.Reader[28].ToString();

                // 医嘱执行单流水号[32]
                terminalApply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[29].ToString());

                // 操作员（插入申请单）[33]
                //terminalApply.InsertOperator.ID = this.Reader[32].ToString();
                terminalApply.InsertOperEnvironment.ID = this.Reader[30].ToString();

                // 操作时间（插入申请单）[34]
                //terminalApply.InsertDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[33].ToString());
                terminalApply.InsertOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[31].ToString());

                // 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检[35]
                terminalApply.PatientType = this.Reader[32].ToString();
                terminalApply.Patient.Memo = this.Reader[32].ToString();

                // 性别[36]
                //terminalApply.Patient.SexID = this.Reader[35].ToString();
                terminalApply.Patient.Sex.ID = this.Reader[33].ToString();

                // 药品发放时间[37]
                terminalApply.SendDrugDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[34].ToString());

                // 终端执行人编号[38]
                //terminalApply.ConfirmOperator.ID = this.Reader[37].ToString();
                terminalApply.ConfirmOperEnvironment.ID = this.Reader[35].ToString();

                // 终端执行时间[39]
                //terminalApply.ConfirmDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[38].ToString());
                terminalApply.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[36].ToString());

                // 是否药品（1：是/0：否）[40]
                //terminalApply.Item.IsPhamarcy = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[39].ToString());
                terminalApply.Item.Item.ItemType = (EnumItemType)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[37].ToString());

                // 病历号
                //terminalApply.Patient.PID.CardNo = this.Reader[40].ToString();
                terminalApply.Patient.PID.CardNO = this.Reader[38].ToString();

                applyList.Add(terminalApply);

            } // 循环读取继承的Reader对象
        }
        #endregion
        #region 转换实体到参数数组
        /// <summary>
        /// 转换实体到参数数组
        /// </summary>
        /// <param name="terminalApply">传入的实体数组</param>
        /// <param name="newApply">是否是新申请单</param>
        /// <returns>1：成功/-1失败</returns>
        private int FillParms(Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply, bool newApply)
        {
            //
            // 新项目的流水号
            //
            string sequence = "";

            //
            // 转换赋值
            //
            // 申请单流水号
            if (newApply)
            {
                intReturn = this.GetNextSequence(ref sequence);
                if (intReturn == -1)
                {
                    this.SetError("", "获取Sequence失败");
                    return -1;
                }
                parms[0] = sequence;
                terminalApply.ID = sequence;
                if (terminalApply.Item.PayType == PayTypes.Balanced && (terminalApply.ItemStatus == "" || terminalApply.ItemStatus == null || terminalApply.ItemStatus == string.Empty || terminalApply.ItemStatus == "0"))
                {
                    terminalApply.ItemStatus = "1";
                }

            }
            else
            {
                parms[0] = terminalApply.ID;
            }
            // 住院流水号或门诊号
            if (terminalApply.Patient.PID.ID == "")
            {
                terminalApply.Patient.PID.ID = terminalApply.Patient.ID;
            }
            parms[1] = terminalApply.Patient.PID.ID;
            // 姓名
            parms[2] = terminalApply.Patient.Name;
            // 合同单位
            parms[3] = terminalApply.Patient.Pact.ID;
            // 申请部门编码
            parms[4] = terminalApply.Item.Order.DoctorDept.ID;
            if (parms[4] == "")
            {
                // 如果申请部门为null,那么挂号部门
                parms[4] = terminalApply.Patient.DoctorInfo.Templet.Dept.ID;
            }
            // 终端科室编码
            parms[5] = terminalApply.Item.ExecOper.Dept.ID;
            // 门诊是挂号科室、住院是在院科室
            parms[6] = terminalApply.Patient.DoctorInfo.Templet.Dept.ID;
            // 发药部门编码
            parms[7] = terminalApply.Item.ExecOper.Dept.ID;
            // 更新库存的流水号(物资)
            parms[8] = terminalApply.UpdateStoreSequence.ToString();
            // 开立医师代码
            //parms[9] = terminalApply.Item.Order.Doctor.ID;
            parms[9] = terminalApply.Item.RecipeOper.ID;
            // 处方号
            parms[10] = terminalApply.Item.RecipeNO;
            // 处方内项目流水号
            parms[11] = terminalApply.Item.SequenceNO.ToString();
            // 项目代码
            parms[12] = terminalApply.Item.Item.ID;
            // 项目名称
            parms[13] = terminalApply.Item.Item.Name;
            // 单价
            parms[14] = terminalApply.Item.Item.Price.ToString();
            // 数量
            parms[15] = terminalApply.Item.Item.Qty.ToString();
            // 当前单位
            parms[16] = terminalApply.Item.Item.PriceUnit;
            // 组套代码
            parms[17] = terminalApply.Item.UndrugComb.ID;
            // 组套名称
            parms[18] = terminalApply.Item.UndrugComb.Name;
            // 费用金额
            parms[19] = terminalApply.Item.FT.TotCost.ToString();
            // 项目状态（0 划价  1 批费 2 执行（药品发放））
            parms[20] = terminalApply.ItemStatus;
            // 已确认数
            parms[21] = terminalApply.AlreadyConfirmCount.ToString();
            // 设备号
            parms[22] = "";  // ************* 由于收费部分没有该信息，所以没有赋值，留给加载患者申请单明细时动态加载
            // 收费标志：0未收费，1已收费
            if (terminalApply.Item.PayType == PayTypes.Charged)
            {
                parms[23] = "0";
            }
            else
            {
                parms[23] = "1";
            }
            // 新旧项目标识： 0 旧 1 新
            parms[24] = "0";
            // 是否有效1
            parms[25] = Neusoft.FrameWork.Function.NConvert.ToInt32(terminalApply.IsValid).ToString();
            // 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)★
            parms[26] = terminalApply.User02;
            // 备注
            parms[27] = terminalApply.User03;
            // 医嘱流水号
            parms[28] = terminalApply.Order.ID;
            if (parms[28] == "" || parms[28] == null)
            {
                //parms[28] = terminalApply.Item.MoOrder;
                parms[28] = terminalApply.Item.Order.ID;
            }
            if (parms[28] == "" || parms[28] == null)
            {
                this.SetError("", "没有医嘱流水号");
                return -1;
            }
            // 医嘱执行单流水号：门诊=医嘱流水号
            parms[29] = terminalApply.OrderExeSequence.ToString();
            // 操作员（插入申请单）
            parms[30] = terminalApply.InsertOperEnvironment.ID;
            // 操作时间（插入申请单）
            parms[31] = terminalApply.InsertOperEnvironment.OperTime.ToString();
            // 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检
            parms[32] = terminalApply.PatientType;
            if (parms[32] == "" || parms[32] == null)
            {
                this.SetError("", "患者类别不允许为空:‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检");
                return -1;
            }
            // 性别
            parms[33] = terminalApply.Patient.Sex.ID.ToString();
            // 药品发放时间
            parms[34] = DateTime.MinValue.ToString();
            // 终端执行人编号
            parms[35] = terminalApply.ConfirmOperEnvironment.ID;
            // 终端执行时间
            parms[36] = DateTime.MinValue.ToString();
            // 是否药品
            //if (terminalApply.Item.Item.IsPharmacy)
            if(terminalApply.Item.Item.ItemType == EnumItemType.Drug)
            {
                parms[37] = "1";
            }
            else
            {
                parms[37] = "0";
            }
            // 患者病历号
            parms[38] = terminalApply.Patient.PID.CardNO;

            return 1;
        }
        #endregion

        #region 获取时间限制(1：获取成功；-1：获取失败)
        /// <summary>
        /// 获取时间限制(1：获取成功；-1：获取失败)
        /// </summary>
        /// <returns>1：获取成功；-1：获取失败</returns>
        private int GetLimited()
        {
            //
            // 判断是否有时间限制
            //
            this.intReturn = this.JudgeDaysLimited(ref this.stringLimitedDate);
            // 如果失败返回-1
            if (this.intReturn == -1)
            {
                return -1;
            }

            //
            // 判断成功，进行设置：0代表没有限制，1代表有限制
            // 
            if (this.intReturn == 0)
            {
                boolLimited = false;
            }
            if (this.intReturn == 1)
            {
                boolLimited = true;
            }

            return 1;
        }
        #endregion

        #region 合并SQL语句（是查询语句和条件语句合并到一起）
        /// <summary>
        /// 合并SQL语句（是查询语句和条件语句合并到一起）
        /// </summary>
        private void CreateSql()
        {
            this.SQL = this.SQL + " " + this.WHERE;// +" " + this.ORDER;
        }
        #endregion

        #region 获取新的Sequence
        /// <summary>
        /// 获取新的Sequence(1：成功/-1：失败)
        /// </summary>
        /// <param name="sequence">获取的新的Sequence</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetNextSequence(ref string sequence)
        {
            //
            // 执行SQL语句
            //
            sequence = this.GetSequence("neusoft.HISFC.Management.TerminalValidate.GetNextSequence");
            //
            // 如果返回NULL，则获取失败
            //
            if (sequence == null)
            {
                this.SetError("", "获取Sequence失败");
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion

        #region 转换住院患者实体和住院患者费用为终端确认实体
        /// <summary>
        /// 转换住院患者实体和住院患者费用为终端确认实体
        /// </summary>
        /// <param name="inpatientFee">住院患者费用</param>
        /// <param name="terminalApply">医技终端实体</param>
        /// <returns>1－成功；－1－失败</returns>
        public int ConvertToTerminalApply(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList inpatientFee,
                                          ref Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply,
                                          Neusoft.HISFC.Models.Terminal.InpatientChargeType chargeType)
        {
            try
            {
                // 住院号
                terminalApply.Patient.PID.ID = inpatientFee.Patient.PID.ID;
                // 姓名[05]
                terminalApply.Patient.Name = inpatientFee.Patient.Name;
                // 合同单位[06]
                terminalApply.Patient.Pact.ID = inpatientFee.Patient.Pact.ID;
                // 申请部门编码（科室或者病区）[07]
                terminalApply.Item.Order.DoctorDept.ID = inpatientFee.Order.DoctorDept.ID;
                // 终端科室编码[08]
                terminalApply.Item.ExecOper.Dept.ID = inpatientFee.Order.ExecOper.Dept.ID;
                // 门诊是挂号科室、住院是在院科室[09]
                terminalApply.Patient.DoctorInfo.Templet.Dept.ID = inpatientFee.Order.DoctorDept.ID;
                // 发药部门编码[10]
                terminalApply.Item.Order.DoctorDept.ID = inpatientFee.Order.StockDept.ID;
                // 更新库存的流水号(物资)[11]
                terminalApply.UpdateStoreSequence = 0;
                // 开立医师代码[12]
                terminalApply.Item.Order.Doctor.ID = inpatientFee.Order.Doctor.ID;
                // 处方号[13]
                terminalApply.Item.RecipeNO = inpatientFee.RecipeNO;
                // 处方内项目流水号[14]
                terminalApply.Item.SequenceNO = inpatientFee.SequenceNO;
                // 项目代码[15]
                terminalApply.Item.Item.ID = inpatientFee.Item.ID;
                // 项目名称[16]
                terminalApply.Item.Item.Name = inpatientFee.Item.Name;
                // 单价[17]
                terminalApply.Item.Item.Price = inpatientFee.Item.Price;
                // 数量[18]
                terminalApply.Item.Item.Qty = inpatientFee.Item.Qty;
                //当前单位[19]
                terminalApply.Item.Item.PriceUnit = inpatientFee.Item.PriceUnit;
                //组套代码[20]
                terminalApply.Item.UndrugComb.ID = inpatientFee.UndrugComb.ID;
                // 组套名称[21]
                terminalApply.Item.UndrugComb.Name = inpatientFee.UndrugComb.Name;
                // 费用金额[22]
                terminalApply.Item.FT.TotCost = inpatientFee.FT.TotCost;
                // 项目状态（0 划价  1 批费 2 执行（药品发放））[23]
                if (inpatientFee.PayType == PayTypes.Charged)
                {
                    terminalApply.ItemStatus = "0";
                }
                else
                {
                    terminalApply.ItemStatus = "1";
                }
                // 已确认数[24]
                terminalApply.AlreadyConfirmCount = 0;
                // 设备号[25]
                terminalApply.Machine.ID = inpatientFee.MachineNO;
                // 新旧项目标识： 0 旧 1 新[27]
                terminalApply.NewOrOld = "0";
                // 扩展标志1[28]
                terminalApply.IsValid = true;
                // 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)[29]
                terminalApply.User02 = ((int)chargeType).ToString();
                // 备注[30]
                terminalApply.User03 = inpatientFee.Item.Memo;
                // 医嘱流水号[31]
                terminalApply.Order.ID = inpatientFee.Order.ID;
                // 医嘱执行单流水号[32]
                terminalApply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(inpatientFee.ExecOrder.ID);
                // 操作员（插入申请单）[33]
                terminalApply.InsertOperEnvironment.ID = inpatientFee.ChargeOper.ID;
                // 操作时间（插入申请单）[34]
                terminalApply.InsertOperEnvironment.OperTime = inpatientFee.ChargeOper.OperTime;
                // 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检[35]
                terminalApply.PatientType = "2";
                // 性别[36]
                terminalApply.Patient.Sex.ID = inpatientFee.Patient.Sex.ID;
                // 药品发放时间[37]
                terminalApply.SendDrugDate = DateTime.MinValue;
                // 终端执行人编号[38]
                terminalApply.ConfirmOperEnvironment.ID = "";
                // 终端执行时间[39]
                terminalApply.ConfirmOperEnvironment.OperTime = DateTime.MinValue;
                // 是否药品（1：是/0：否）[40]
                //terminalApply.Item.Item.IsPharmacy = terminalApply.Order.Item.IsPharmacy;
                terminalApply.Item.Item.ItemType = terminalApply.Order.Item.ItemType;
                // 病历号
                terminalApply.Patient.PID.CardNO = inpatientFee.Patient.PID.CardNO;
            }
            catch (Exception e)
            {
                this.Err += e.Message;
                return -1;
            }
            // 成功返回
            return 1;
        }

        #endregion

        //
        // 业务主表
        //
        #region 插入申请单
        /// <summary>
        /// 插入申请单
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        private int Insert()
        {
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Terminal.Insert", ref SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, parms);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败!" + e.Message);
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }

            return 1;
        }
        #endregion
        #region 更新申请单
        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        private int Update()
        {
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Terminal.ReUpdate.Update", ref SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Terminal.ReUpdate.Where", ref WHERE) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            this.CreateSql();

            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, parms, parms[28]);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败!" + e.Message);
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }

            return 1;
        }
        #endregion
        #region 根据医嘱流水号删除申请单(1：成功/-1：失败)
        /// <summary>
        /// 根据医嘱流水号删除申请单(1：成功/-1：失败)
        /// </summary>
        /// <param name="stringOrderNo">医嘱流水号</param>
        /// <returns>1：成功/-1：失败</returns>
        public int DeleteByOrder(string stringOrderNo)
        {
            // 判断申请单是否存在
            string stringTemp = "";
            this.intReturn = JudgeIfConfirm(stringOrderNo, ref stringTemp);
            if (intReturn == -1)
            {
                return -1;
            }
            else if (intReturn != 1)
            {
                //终端确认表中不存在 不需要删除
                return 1;
            }
            //
            // 初始化变量
            //
            this.Clear();

            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Terminal.DeleteByOrder.Delete", ref SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Terminal.DeleteByOrder.Where", ref WHERE) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            this.CreateSql();

            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, stringOrderNo);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败!" + e.Message);
                return -1;
            }

            //
            // 执行SQL语句
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }

            return 1;
        }
        #endregion
        //
        // 业务明细子表
        #region 填充数组
        /// <summary>
        /// 填充数组
        /// [参数: Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail - 业务子表实体]
        /// </summary>
        /// <param name="detail">业务子表实体</param>
        private void FillDetailParm(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            //// 父级编码
            //this.detailParms[0] = detail.Hospital.ID;
            //// 本级编码
            //this.detailParms[1] = detail.Hospital.Name;
            // '流水号';
            //this.detailParms[0] = detail.Sequence;
            //  '申请单流水号';
            this.detailParms[0] = detail.Apply.ID;
            // '患者类别';
            this.detailParms[1] = detail.Apply.PatientType;
            // '卡号';
            this.detailParms[2] = detail.Apply.Patient.PID.CardNO;
            //if (detail.Apply.Patient.PID.CardNO == null)
            //{
            //    this.detailParms[5] = detail.Apply.Patient.CardNo;
            //}
            // '看诊号';
            this.detailParms[3] = detail.Apply.Patient.ID;
            //  '项目编码';
            this.detailParms[4] = detail.Apply.Item.Item.ID;
            //  '项目名称';
            this.detailParms[5] = detail.Apply.Item.Item.Name;
            //  '开立数量';
            this.detailParms[6] = detail.Apply.Item.Item.Qty.ToString();
            //  '本次确认数量';
            this.detailParms[7] = detail.Apply.Item.ConfirmedQty.ToString();
            //  '剩余数量';
            this.detailParms[8] = detail.FreeCount.ToString();
            //  '确认时间';
            this.detailParms[9] = detail.Apply.ConfirmOperEnvironment.OperTime.ToString();
            //  '确认科室';
            this.detailParms[10] = detail.Apply.Item.ExecOper.Dept.ID;
            //  '确认人';
            this.detailParms[11] = detail.Apply.ConfirmOperEnvironment.ID;
            //  '申请单状态';
            this.detailParms[12] = detail.Status.ID;
            //  '扩展字段1';
            this.detailParms[13] = detail.Apply.Order.ID;
            //  '扩展字段2';
            this.detailParms[14] = detail.Apply.SpecalFlag;;
            //  '扩展字段3';
            this.detailParms[15] = detail.User03;
            this.detailParms[16] = detail.OperInfo.ID;//操作员
            this.detailParms[17] = detail.OperInfo.OperTime.ToString();//操作时间
            this.detailParms[18] = detail.ExecDevice;//执行设备
            this.detailParms[19] = detail.Oper.ID;//执行人
        }
        #endregion
        #region 转换Reader为实体
        /// <summary>
        /// 转换Reader为实体
        /// [参数: Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail - 转换后的实体]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="detail">转换后的实体</param>
        /// <returns>1-成功,-1-失败</returns>
        private int DetailReaderToObject(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            // 父级编码
            //detail.Hospital.ID = this.Reader[0].ToString();
            //// 本级编码
            //detail.Hospital.Name = this.Reader[1].ToString();
            // '流水号';
            try
            {
                detail.Sequence = this.Reader[0].ToString();
            }
            catch
            {
                //
                // 转换失败
                //
                this.SetError("", "转换成实体对象失败!");
                return -1;
            }
            //  '申请单流水号';
            detail.Apply.ID = this.Reader[1].ToString();
            // '患者类别';
            detail.Apply.PatientType = this.Reader[2].ToString();
            // '卡号';
            detail.Apply.Patient.PID.CardNO = this.Reader[3].ToString();
            // '看诊号';
            detail.Apply.Patient.PID.ID = this.Reader[4].ToString();
            //  '项目编码';
            detail.Apply.Item.Item.ID = this.Reader[5].ToString();
            //  '项目名称';
            detail.Apply.Item.Item.Name = this.Reader[6].ToString();
            //  '开立数量';
            try
            {
                detail.Apply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
            }
            catch
            {
                this.SetError("", "转换成实体对象失败!");
                return -1;
            }
            //  '本次确认数量';
            try
            {
                detail.Apply.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[8].ToString());
            }
            catch
            {
                this.SetError("", "转换成实体对象失败!");
                return -1;
            }
            //  '剩余数量';
            try
            {
                detail.FreeCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
            }
            catch
            {
                this.SetError("", "转换成实体对象失败!");
                return -1;
            }
            //  '确认时间';
            try
            {
                detail.Apply.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());
            }
            catch
            {
                this.SetError("", "转换成实体对象失败!");
                return -1;
            }
            //  '确认科室';
            detail.Apply.Item.ConfirmOper.Dept.ID = this.Reader[11].ToString();
            //  '确认人';
            detail.Apply.ConfirmOperEnvironment.ID = this.Reader[12].ToString();
            //  '申请单状态';
            detail.Status.ID = this.Reader[13].ToString();
            //  '扩展字段';
            detail.Apply.Order.ID = this.Reader[14].ToString();
            //  '扩展字段';
            detail.Apply.SpecalFlag = this.Reader[15].ToString();
            //  '扩展字段';
            detail.User03 = this.Reader[16].ToString();
            detail.OperInfo.ID = this.Reader[17].ToString(); //操作员
            detail.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[18].ToString()); //操作时间
            detail.CancelInfo.ID = this.Reader[19].ToString();//作废人
            detail.CancelInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[20].ToString()); //作废时间
            //
            // 成功返回
            //
            return 1;
        }
        #endregion

        #endregion

        #region 公有函数

        #region 作废终端确认主表
        /// <summary>
        /// 作废终端确认主表
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public int UpdateConfirm(string MoOrder,string ItemCode)
        {
            // SQL语句
            string sql = "";
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("TerminalConfirm.UpdateConfirm.1", ref sql) == -1)
            {
                this.Err = "获取SQL语句TerminalConfirm.UpdateConfirm.1失败";
                return -1;
            }
            // 匹配执行
            try
            {
                //sql = string.Format(sql, GetParam(medTechItem));
                return this.ExecNoQuery(sql, MoOrder, ItemCode);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
        }
        #endregion
        #region 更新终端确认表的执行标志
        /// <summary>
        /// 更新终端确认表的执行标志
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public int UpdateConfirmSendFlag(string MoOrder, string ItemCode,string SendFlag)
        {
            // SQL语句
            string sql = "";
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("TerminalConfirm.UpdateConfirmSendFlag", ref sql) == -1)
            {
                this.Err = "获取SQL语句TerminalConfirm.UpdateConfirmSendFlag失败";
                return -1;
            }
            // 匹配执行
            try
            {
                return this.ExecNoQuery(sql, MoOrder, ItemCode, SendFlag);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
        }
        #endregion 
        #region 更新费用表的已确认数量 和确认标记 ,取消确认的项目时调用
        /// <summary>
        /// 更新费用表的已确认数量 和确认标记 ,取消确认的项目时调用
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="ConfirmFlag"></param>
        /// <param name="ConfirmQty"></param>
        /// <returns></returns>
        public int UpdateFeeConfirmQty(string MoOrder, string ConfirmFlag, int ConfirmQty)
        {
            // SQL语句
            string sql = "";
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("TerminalConfirm.UpdateFeeConfirmQty", ref sql) == -1)
            {
                this.Err = "获取SQL语句TerminalConfirm.UpdateFeeConfirmQty.1失败";
                return -1;
            }
            // 匹配执行
            try
            {
                //sql = string.Format(sql, GetParam(medTechItem));
                return this.ExecNoQuery(sql, MoOrder, ConfirmQty.ToString(), ConfirmFlag);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
        }
               #endregion 
        //
        // Insert、Update、Delete
        //
        #region 医技终端确认插入(1：成功/-1：失败)
        /// <summary>
        /// 医技终端确认插入(1：成功/-1：失败)
        /// </summary>
        /// <param name="terminalApply">申请单类</param>
        /// <returns>1：成功/-1：失败</returns>
        public int Insert(Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply)
        {
            // 医嘱号
            string confirmFlag = "";
            // 申请单号
            string applyNo = "";
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 判断医嘱号，判断申请单是否存在，判断申请单是否已经确认
            //
            if (terminalApply.Order.ID == "")
            {
                terminalApply.Order.ID = terminalApply.Item.Order.ID;
            }
            #region 如果存在相同的医嘱流水号申请先作废之前的申请,再插入新的申请
            if (UpdateConfirm(terminalApply.Order.ID, terminalApply.Item.Item.ID) == -1)
            {
                return -1;
            }
            #endregion 
            this.intReturn = this.JudgeIfConfirmByID(terminalApply.ID, ref confirmFlag);
            if (intReturn == -1)
            {
                // 判断发生错误
                this.SetError("", "判断申请单是否存在失败！" + this.Err);
                return -1;
            }
            else if (intReturn == 1)
            {
                // 存在，判断是否已经确认
                if (confirmFlag == "2")
                {
                    // 已经确认，不能执行更改，返回-1；
                    this.SetError("", "申请单已经确认，不能更改");
                    return -1;
                }
                else
                {
                    //
                    // 未确认，可以执行更新
                    //
                    // 根据医嘱号获取申请单号
                    if (terminalApply.Order.ID == "")
                    {
                        terminalApply.Order.ID = terminalApply.Item.Order.ID;
                    }
                    intReturn = this.GetApplyNoByOrderNo(terminalApply.Order.ID, ref applyNo);
                    if (intReturn == -1)
                    {
                        this.SetError("", "更新执行单获取申请单号失败！" + this.Err);
                        return -1;
                    }
                    // 填充参数
                    if (this.FillParms(terminalApply, false) == -1)
                    {
                        return -1;
                    }
                    // 执行更新
                    intReturn = this.Update();
                    {
                        if (intReturn == -1)
                        {
                            // 更新失败，返回-1；
                            this.SetError("", "更新失败！" + this.Err);
                            return -1;
                        }
                        else
                        {
                            // 更新成功，返回1；
                            return 1;
                        }
                    }
                }
            }
            else
            {
                // 不存在直接插入
                // 填充参数
                if (this.FillParms(terminalApply, true) == -1)
                {
                    return -1;
                }

                // 插入
                intReturn = this.Insert();
                if (intReturn == -1)
                {
                    this.SetError("", "插入申请单失败！" + this.Err);
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        #endregion
        #region 根据处方号和处方内项目流水号删除申请单(影响的行数；-1：失败)
        /// <summary>
        /// 根据处方号和处方内项目流水号删除申请单(影响的行数；-1：失败)
        /// </summary>
        /// <param name="recipeCode">处方号</param>
        /// <param name="sequanceInRecipe">处方内项目流水号</param>
        /// <returns>影响的行数；-1：失败</returns>
        public int Delete(string recipeCode, string sequanceInRecipe)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL
            // 
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并SQL语句
            SQL = SQL + WHERE;
            //
            // 格式化语句
            //
            try
            {
                SQL = string.Format(SQL, recipeCode, sequanceInRecipe);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }

            return intReturn;
        }
        #endregion
        #region 老项目更新确认标志(影响的行数；-1：失败)
        /// <summary>
        /// 老项目更新确认标志(影响的行数；-1：失败)
        /// </summary>
        /// <param name="terminalApply">申请单类</param>
        /// <returns>影响的行数；-1：失败</returns>
        public int Update(Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply)
        {
            // 格式化SQL语句参数数组
            string[] parmsUpdate = new string[7];
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.UpdateApply", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "格式化SQL语句失败");
                return -1;
            }
            //
            // 设置格式化语句参数
            //
            parmsUpdate[0] = terminalApply.Item.ConfirmedQty.ToString(); // 已经确认数量
            parmsUpdate[1] = terminalApply.ConfirmOperEnvironment.ID; // 确认人
            parmsUpdate[2] = terminalApply.ConfirmOperEnvironment.OperTime.ToString(); // 终端执行时间
            parmsUpdate[4] = terminalApply.ID; // 流水号
            //
            // 格式化SQL
            //
            try
            {
                SQL = string.Format(SQL, parmsUpdate);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn < 0)
            {
                this.SetError("", "执行SQL失败" + this.Err);
                return -1;
            }
            //
            // 影响的行数
            //
            return intReturn;
        }
        #endregion
        #region 根据申请单流水号删除申请单(影响的行数/-1：失败)
        /// <summary>
        /// 根据申请单流水号删除申请单(影响的行数/-1：失败)
        /// </summary>
        /// <param name="sequence">申请单流水号</param>
        /// <returns>影响的行数/-1：失败</returns>
        public int Delete(string sequence)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.DeleteApplyBySequence", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.DeleteApplyBySequence.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并SQL语句
            SQL = SQL + WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, sequence);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecNoQuery(SQL);
            if (intReturn < 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            //
            // 影响的行数
            //
            return intReturn;
        }
        /// <summary>
        ///根据医嘱号 更新终端确认表的数量,已确认数量,价格
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateTerminalConfirmByMoOrder(string MoOrder, int BackQty, decimal Cost)
        {
            string strSql = "";
            if (this.Sql.GetSql("TerminalConfirm.UpdateTerminalByMoOrder", ref strSql) == -1)
            {
                this.Err = "获取TerminalConfirm.UpdateTerminalByMoOrder 失败";
                return -1;
            }
            strSql = string.Format(strSql, MoOrder, BackQty, Cost);
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        ///根据医嘱号 更新终端确认表的数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateTerminalConfirmByMoOrder(string MoOrder, int BackQty)
        {
            string strSql = "";
            if (this.Sql.GetSql("TerminalConfirm.UpdateTerminalByMoOrderNotCost", ref strSql) == -1)
            {
                this.Err = "获取TerminalConfirm.UpdateTerminalByMoOrderNotCost 失败";
                return -1;
            }
            strSql = string.Format(strSql, MoOrder, BackQty);
            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        ///根据医嘱号 更新费用明细表的可退数量和已确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateNobackNum(string moOrder, string itemCode, decimal cancelNum)
        {
            string strSql = "";
            if (this.Sql.GetSql("Terminal.TerminalConfirm.UpdateFeeDetailNobackNum", ref strSql) == -1)
            {
                this.Err = "获取 Terminal.TerminalConfirm.UpdateFeeDetailNobackNum 失败";

                return -1;
            }
            strSql = string.Format(strSql, moOrder, itemCode, cancelNum);

            return this.ExecNoQuery(strSql);
        }
        /// <summary>
        ///根据确认流水号 更新门诊终端确认明细表的已确认数量和extend_field3=旧的已确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateConfirmedQty(string applyID, decimal newConfirmedQty, string oldConfirmedQtyString)
        {
            string strSql = "";
            if (this.Sql.GetSql("Terminal.TerminalConfirm.UpdateTaDetailConfirmedQty", ref strSql) == -1)
            {
                this.Err = "获取 Terminal.TerminalConfirm.UpdateTaDetailConfirmedQty 失败";

                return -1;
            }
            strSql = string.Format(strSql, applyID, newConfirmedQty, oldConfirmedQtyString);

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        ///根据确认流水号 更新门诊终端确认明细表的已确认数量和extend_field3=旧的已确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateConfirmedFlag(string applyID,string operCode,string operDate)
        {
            string strSql = "";
            if (this.Sql.GetSql("Terminal.TerminalConfirm.UpdateTaDetailConfirmedFlag", ref strSql) == -1)
            {
                this.Err = "获取 Terminal.TerminalConfirm.UpdateTaDetailConfirmedFlag 失败";

                return -1;
            }
            strSql = string.Format(strSql, applyID, operCode, operDate);

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        ///根据确认流水号 更新门诊终端确认申请表的确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int UpdateApplyConfirmQty(string applyCode,decimal cancelQty)
        {
            string strSql = "";
            if (this.Sql.GetSql("Terminal.TerminalConfirm.UpdateTerminalApplyConfirmQty", ref strSql) == -1)
            {
                this.Err = "获取 Terminal.TerminalConfirm.UpdateTerminalApplyConfirmQty 失败";

                return -1;
            }
            strSql = string.Format(strSql, applyCode, cancelQty);

            return this.ExecNoQuery(strSql);
        }
        #endregion

        /// <summary>
        /// 住院费用插入终端申请单
        /// </summary>
        /// <param name="inpatientFee">住院费用</param>
        /// <returns>1：成功/-1：失败</returns>
        public int Insert(Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList inpatientFee,
                          Neusoft.HISFC.Models.Terminal.InpatientChargeType chargeType)
        {
            // 终端确认实体
            Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = new TerminalApply();

            // 转换住院患者实体为门诊患者实体
            this.intReturn = this.ConvertToTerminalApply(inpatientFee, ref terminalApply, chargeType);
            if (this.intReturn == -1)
            {
                return -1;
            }

            // 执行插入
            return this.Insert(terminalApply);
        }
        //
        // 维护天数限制
        //
        #region 删除允许的最大申请单天数限制(1：成功；-1：失败)
        /// <summary>
        /// 删除允许的最大申请单天数限制(1：成功；-1：失败)
        /// </summary>
        /// <returns>1：成功；-1：失败</returns>
        public int RemoveDaysLimited()
        {
            //
            // 初始化局部变量
            //
            this.Clear();
            //
            // 获取删除SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.DeleteMaxPermitDays", ref this.SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.DeleteMaxPermitDays.Where", ref this.WHERE) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            //
            // 合并语句
            //
            this.CreateSql();
            //
            // 执行删除SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            //
            // 获取插入SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.NoDaysLimited", ref this.SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 更改允许的最大申请单天数限制(1：成功；-1：失败)
        /// <summary>
        /// 更改允许的最大申请单天数限制(1：成功；-1：失败)
        /// </summary>
        /// <param name="days">限制天数</param>
        /// <returns>1：成功；-1：失败</returns>
        public int UpdateDaysLimited(int days)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取删除SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.DeleteMaxPermitDays", ref this.SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn <= 0)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            //
            // 获取插入SQL语句
            //
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.UpdateMaxPermitDays", ref this.SQL) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, days);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn <= 0)
            {
                this.SetError("", "003执行SQL语句失败");
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        //
        // 查询天数限制
        //
        #region 获取系统允许的最大申请单申请天数限制(大于0：允许的最大天数；0：没有天数限制；小于0：获取失败)
        /// <summary>
        /// 获取系统允许的最大申请单申请天数限制(大于0：允许的最大天数；0：没有天数限制；小于0：获取失败)
        /// </summary>
        /// <returns>大于0：允许的最大天数；0：没有天数限制；小于0：获取失败</returns>
        public int GetMaxPermitDays()
        {
            Neusoft.HISFC.BizLogic.Manager.Controler controlerFunction = new Controler();
            int intDays = 0;

            if (this.Trans != null)
            {
                controlerFunction.SetTrans(this.Trans);
            }
            intDays = Neusoft.FrameWork.Function.NConvert.ToInt32(controlerFunction.QueryControlerInfo("TC001"));
            if (intDays >= 0)
            {
                return intDays;
            }
            ////
            //// 字符串型的天数
            ////
            //string stringDays = "";
            ////
            //// 初始化SQL语句
            ////
            //this.Clear();
            ////
            //// 获取SQL语句
            ////
            //if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetMaxPermitDays", ref SQL) == -1)
            //{
            //    this.SetError("", "获取SQL语句失败");
            //    return -1;
            //}
            ////
            //// 执行SQL语句
            ////
            //this.intReturn = this.ExecQuery(this.SQL);
            //if (this.intReturn == -1)
            //{
            //    this.SetError("", "执行SQL语句失败");
            //    return -1;
            //}
            ////
            //// 返回天数限制
            ////
            //if (this.Reader.Read())
            //{
            //    stringDays = this.Reader[0].ToString();
            //    return Neusoft.FrameWork.Function.NConvert.ToInt32(stringDays);
            //}
            //
            // 如果没有读取成功，则失败
            //
            this.SetError("", "没有设置天数限制");
            return -1;
        }
        #endregion
        #region 自动获取最大天数限制，返回相应的日期(1：转换成功/-1：失败/0：没有天数限制)
        /// <summary>
        /// 自动天数限制，返回相应的日期(1：转换成功/-1：失败/0：没有天数限制)
        /// </summary>
        /// <param name="limitedDay">返回的日期</param>
        /// <returns>1：转换成功/-1：失败/0：没有天数限制</returns>
        public int JudgeDaysLimited(ref string limitedDay)
        {
            //
            //变量定义
            //
            // 现在的时间
            DateTime datetimeNow;
            // 限制的时间
            DateTime dtLimited;
            // 辅助计算
            System.TimeSpan timeSpan;
            // 年
            int year = 0;
            // 月
            int month = 0;
            // 日
            int day = 0;
            //
            // 获取天数限制
            //
            this.intReturn = this.GetMaxPermitDays();
            //
            // 判断限制
            //
            // 没有天数限制
            if (intReturn == 0)
            {
                return 0;
            }
            // 获取失败！
            if (intReturn < 0)
            {
                return -1;
            }
            // 
            // 计算转换日期，返回结果
            //
            // 获取系统时间
            datetimeNow = this.GetDateTimeFromSysDateTime();
            // 计算
            timeSpan = TimeSpan.FromDays(intReturn);
            year = (datetimeNow - timeSpan).Year;
            month = (datetimeNow - timeSpan).Month;
            day = (datetimeNow - timeSpan).Day;
            dtLimited = new DateTime(year, month, day, 0, 0, 0);
            limitedDay = dtLimited.ToString();
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据天数获取日期
        /// <summary>
        /// 根据天数获取日期
        /// </summary>
        /// <param name="dayLimited">天数</param>
        /// <returns>日期</returns>
        public System.DateTime GetDateByDays(int dayLimited)
        {
            // 现在的时间
            DateTime datetimeNow;
            // 时间间隔
            System.TimeSpan timeSpan;
            // 年
            int year = 0;
            // 月
            int month = 0;
            // 日
            int day = 0;
            //
            // 获取系统时间
            //
            datetimeNow = this.GetDateTimeFromSysDateTime();
            // 计算
            timeSpan = TimeSpan.FromDays(dayLimited);
            year = (datetimeNow - timeSpan).Year;
            month = (datetimeNow - timeSpan).Month;
            day = (datetimeNow - timeSpan).Day;

            // 返回时间
            return new DateTime(year, month, day, 0, 0, 0);
        }
        #endregion
        //
        // 获取患者
        //
        #region 根据患者病历号获取患者基本信息（1：成功/-1：失败）
        /// <summary>
        /// 根据患者病历号获取患者基本信息（1：成功/-1：失败）
        /// </summary>
        /// <param name="cardNO">病历号/卡号</param>
        /// <param name="register">返回的患者信息</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetPatientsByCardNO(string cardNO, string departmentID, ref ArrayList register)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1)
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientByCardNO", ref SQL);
            if (SQL == null)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 如果查找其它科室的患者信息
            if (departmentID.Equals(""))
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientByCardNO.Where.Other", ref WHERE);
            }
            else
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientByCardNO.Where", ref WHERE);
            }
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            this.CreateSql();
            // 如果有时间限制，附加时间限制WHERE条件
            if (boolLimited)
            {
                // 如果查找其它科室的患者信息
                if (departmentID.Equals(""))
                {
                    intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientByCardNO.Where.Date.Other", ref WHERE);
                }
                else
                {
                    intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientByCardNO.Where.Date", ref WHERE);
                }
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    return -1;
                }
                this.CreateSql();
            }
            //
            // SQL语句格式化
            // 
            if (boolLimited) // 如果有时间限制
            {
                try
                {
                    // 如果查找其它科室的患者信息
                    if (departmentID.Equals(""))
                    {
                        SQL = string.Format(SQL, cardNO, this.stringLimitedDate);
                    }
                    else
                    {
                        SQL = string.Format(SQL, cardNO, departmentID, this.stringLimitedDate);
                    }
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            } // 如果有时间限制
            else
            {
                try
                {
                    if (departmentID.Equals(""))
                    {
                        SQL = string.Format(SQL, cardNO);
                    }
                    else
                    {
                        SQL = string.Format(SQL, cardNO, departmentID);
                    }
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败" + this.Err);
                return -1;
            }
            // 如果内容为空，则返回0
            if (this.Reader == null)
            {
                return 0;
            }
            //
            // 形成结果集
            //
            if (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Registration.Register patient = new Register();

                // 患者编号
                patient.ID = this.Reader[0].ToString();
                // 患者姓名
                patient.Name = this.Reader[1].ToString();
                // 合同单位编码
                patient.Pact.ID = this.Reader[2].ToString();
                // 挂号科室
                patient.DoctorInfo.Templet.Dept.ID = this.Reader[3].ToString();
                // 患者类型：1-门诊；2-住院；3-急诊；4-体检
                patient.Memo = this.Reader[4].ToString();
                // 性别编码
                patient.Sex.ID = this.Reader[5].ToString();
                //卡号
                patient.PID.CardNO = this.Reader[6].ToString();

                register.Add(patient);
                //
                // 成功返回
                //
                return 1;
            }
            return 1;
        }
        #endregion
        #region 根据患者编号和患者类型获取患者基本信息（1：成功/-1：失败）
        /// <summary>
        /// 根据患者编号和患者类型获取患者基本信息（1：成功/-1：失败）
        /// </summary>
        /// <param name="clinicCode">病历号/卡号</param>
        /// <param name="departmentID">科室编码</param>
        /// <param name="patientType">患者类别</param>
        /// <param name="register">返回的挂号信息</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetPatientsByClinicCode(string clinicCode, string patientType, string departmentID, ref Register register)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1)
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByClinicCode", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            if (departmentID.Equals(""))
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByClinicCode.Where.Other", ref WHERE);
            }
            else
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByClinicCode.Where", ref WHERE);
            }
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            this.CreateSql();
            // 如果有时间限制，附加时间限制WHERE条件
            if (boolLimited)
            {
                if (departmentID.Equals(""))
                {
                    intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByClinicCode.Where.Date.Other", ref WHERE);
                }
                else
                {
                    intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByClinicCode.Where.Date", ref WHERE);
                }
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    return -1;
                }
                this.CreateSql();
            }
            //
            // SQL语句格式化
            // 
            if (boolLimited) // 如果有时间限制
            {
                try
                {
                    if (departmentID.Equals(""))
                    {
                        SQL = string.Format(SQL, clinicCode, patientType, this.stringLimitedDate);
                    }
                    else
                    {
                        SQL = string.Format(SQL, clinicCode, patientType, departmentID, this.stringLimitedDate);
                    }
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            } // 如果有时间限制
            else
            {
                try
                {
                    if (departmentID.Equals(""))
                    {
                        SQL = string.Format(SQL, clinicCode, patientType);
                    }
                    else
                    {
                        SQL = string.Format(SQL, clinicCode, patientType, departmentID);
                    }
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败" + this.Err);
                return -1;
            }
            // 如果内容为空，则返回0
            if (this.Reader == null)
            {
                return 0;
            }
            //
            // 形成结果集
            //
            if (this.Reader.Read())
            {
                // 患者编号
                register.ID = this.Reader[0].ToString();
                // 患者姓名
                register.Name = this.Reader[1].ToString();
                // 合同单位编码
                register.Pact.ID = this.Reader[2].ToString();
                // 挂号科室
                register.DoctorInfo.Templet.Dept.ID = this.Reader[3].ToString();
                // 患者类型：1-门诊；2-住院；3-急诊；4-体检
                register.Memo = this.Reader[4].ToString();
                // 性别编码
                register.Sex.ID = this.Reader[5].ToString();
                //卡号
                register.PID.CardNO = this.Reader[6].ToString();
                //
                // 成功返回
                //
                return 1;
            }
            //
            // 错误返回
            //
            return -1;
        }
        #endregion
        #region 根据患者门诊号获取患者挂号日期(1：成功/-1：失败)
        /// <summary>
        /// 根据患者门诊号获取患者挂号日期(1：成功/-1：失败)
        /// </summary>
        /// <param name="clinicNO">门诊号</param>
        /// <param name="regDate">挂号日期</param>
        /// <returns>1：成功/-1：失败</returns>
        public int GetRegDate(string clinicNO, ref DateTime regDate)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetRegDate.Select", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetRegDate.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                ;
                return -1;
            }
            // 合并没有时间限制的SQL语句
            SQL = SQL + " " + WHERE;

            // 格式化SQL语句
            try
            {
                SQL = string.Format(SQL, clinicNO);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            // 执行SQL语句
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            // 形成结果
            this.Reader.Read();
            regDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[0].ToString());
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据科室编码，返回所有的患者基本信息(1：成功；-1：失败；0：返回空)
        /// <summary>
        /// 根据科室编码，返回所有的患者基本信息(1：成功；-1：失败；0：返回空)
        /// </summary>
        /// <param name="patientList">TerminalApply实体类</param>
        /// <param name="deptCode">执行科室编码</param>
        /// <param name="dayLimited">患者列表天数限制</param>
        /// <returns>1：成功；-1：失败；0：返回空</returns>
        public int QueryPatients(ref ArrayList patientList, string deptCode, int dayLimited)
        {
            //
            // 初始化变量
            //
            String stringDayLimited = "";
            string sqlGroup = "";

            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1)
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByDepartmentCode", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 获取ORDER语句
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByDepartmentCode.Order", ref ORDER);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 如果有天数限制，附加时间限制WHERE条件
            if (dayLimited > 0)
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByDepartmentCode.Where", ref WHERE);
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    return -1;
                }
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetPatientsByDepartmentCode.Group", ref sqlGroup);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            this.SQL = this.SQL + " " + this.WHERE + " " + sqlGroup + " " + this.ORDER;
            //
            // SQL语句格式化
            // 
            if (dayLimited > 0) // 如果有时间限制
            {
                try
                {
                    stringDayLimited = this.GetDateByDays(dayLimited).ToString();
                    SQL = string.Format(SQL, deptCode, stringDayLimited);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            else
            {
                try
                {
                    SQL = string.Format(SQL, deptCode);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败" + this.Err);
                return -1;
            }
            // 如果内容为空，则返回0
            if (this.Reader == null)
            {
                return 0;
            }
            //
            // 形成结果集
            //
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Registration.Register patient = new Register();
                //// 患者编号
                patient.ID = this.Reader[0].ToString();
                // 患者姓名
                patient.Name = this.Reader[1].ToString();
                // 合同单位编码
                patient.Pact.ID = this.Reader[2].ToString();
                // 挂号科室
                patient.DoctorInfo.Templet.Dept.ID = this.Reader[3].ToString();
                // 患者类型：1-门诊；2-住院；3-急诊；4-体检
                patient.Memo = this.Reader[4].ToString();
                // 性别编码
                patient.Sex.ID = this.Reader[5].ToString();
                //卡号
                patient.PID.CardNO = this.Reader[6].ToString();

                patientList.Add(patient);
            }
            return 1;
        }
        #endregion
        /// <summary>
        /// 根据执行科室查询需要确认项目的患者的所在科室
        /// </summary>
        /// <param name="applyList"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public int QueryPatientDeptByConfirmDeptID(ref ArrayList applyList, string deptCode)
        {
            string strSQL = "";

            if (this.Sql.GetSql("Terminal.TerminalConfirm.QueryPatientDept.NeedConfirm.1", ref strSQL) == -1)
            {
                this.Err = this.Sql.Err;
                return -1;
            }
            try
            {
                strSQL = string.Format(strSQL, deptCode);
            }
            catch
            {
                this.Err = "传入参数不对！Terminal.TerminalConfirm.QueryPatientDept.NeedConfirm.1";
                return -1;
            }

            if (this.ExecQuery(strSQL) == -1)
            {
                return -1;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

                    obj.ID = this.Reader[0].ToString();

                    applyList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return -1;
            }
            finally
            {
                this.Reader.Close();
            }

            return 1;
        }

        /// <summary>
        /// 根据住院流水号和执行科室  查找需要确认的项目信息
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryItemListNeedConfirmByDeptCode(string inpatientNO, string deptCode)
        {
            ArrayList alItemList = new ArrayList();
            string strSQL = "";

            if (this.Sql.GetSql("Terminal.TerminalConfirm.QueryItemList.NeedConfirm.1", ref strSQL) == -1)
            {
                this.Err = this.Sql.Err;

                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, inpatientNO, deptCode);
            }
            catch
            {
                this.Err = "传入参数不对！Terminal.TerminalConfirm.QueryItemList.NeedConfirm.1";

                return null;
            }

            if (this.ExecQuery(strSQL) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList feeItemList = new Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList();

                    feeItemList.Item.ID = this.Reader[0].ToString();
                    feeItemList.Item.Name = this.Reader[1].ToString();
                    feeItemList.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    feeItemList.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[3].ToString());
                    feeItemList.NoBackQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[4].ToString());
                    feeItemList.Item.PriceUnit = this.Reader[5].ToString();
                    feeItemList.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[6].ToString());
                    feeItemList.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[7].ToString());
                    feeItemList.Order.ID = this.Reader[8].ToString();
                    feeItemList.ExecOrder.ID = this.Reader[9].ToString();
                    feeItemList.RecipeNO = this.Reader[10].ToString();
                    feeItemList.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[11].ToString());
                    feeItemList.TransType = (TransTypes)Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[12].ToString());

                    alItemList.Add(feeItemList);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();

                return null;
            }
            finally 
            {
                this.Reader.Close(); 
            }

            return alItemList;
        }

        /// <summary>
        /// 根据执行科室、患者所在科室查询需要确认项目的患者
        /// </summary>
        /// <param name="confirmDept">执行科室</param>
        /// <param name="patientDept">患者所在科室</param>
        /// <returns></returns>
        public ArrayList QueryPatientByConfirmDeptAndPatDept(string confirmDept, string patientDept)
        {
            ArrayList alPatient = new ArrayList();
            string strSQL = "";

            if (this.Sql.GetSql("Terminal.TerminalConfirm.QueryInpatientNO.NeedConfirm.1", ref strSQL) == -1)
            {
                this.Err = this.Sql.Err;
                return null;
            }
            try
            {
                strSQL = string.Format(strSQL, confirmDept, patientDept);
            }
            catch
            {
                this.Err = "传入参数不对！Terminal.TerminalConfirm.QueryInpatientNO.NeedConfirm.1";
                return null;
            }

            if (this.ExecQuery(strSQL) == -1)
            {
                return null;
            }

            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

                    obj.ID = this.Reader[0].ToString();

                    alPatient.Add(obj);
                }
            }
            catch (Exception ex)
            {
                this.Err = "查询出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            finally
            {
                this.Reader.Close();
            }

            return alPatient;
        }
        //
        // 获取申请单
        //
        #region 根据患者编号获取等待确认的申请单明细信息(1：成功；-1：失败；0：空)
        /// <summary>
        /// 根据患者编号获取等待确认的申请单明细信息(1：成功；-1：失败；0：空)
        /// </summary>
        /// <param name="queryCode">患者编号</param>
        /// <param name="applyList">返回的申请单明细</param>
        /// <param name="executeDepartment">执行科室编码</param>
        /// <returns>1：成功；-1：失败；0：空</returns>
        public int QueryTerminalApplyList(string queryCode, ref ArrayList applyList, string executeDepartment)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1) // 获取时间限制失败
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            string strSql = this.GetTerminalSql();
            if (strSql == null)
            {
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetTerminalApplyList", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            SQL = strSql + SQL;
            // 如果有时间限制，附加时间限制WHERE条件
            if (boolLimited)
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetTerminalApplyList.Where", ref WHERE);
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    return -1;
                }
                this.CreateSql();
            }
            //
            // 格式化SQL语句
            //
            if (boolLimited) // 如果有时间限制，附加时间格式化参数
            {
                try
                {
                    SQL = string.Format(SQL, executeDepartment, queryCode, this.stringLimitedDate);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            } // 如果有时间限制，附加时间格式化参数
            else
            {
                try
                {
                    SQL = string.Format(SQL, executeDepartment, queryCode);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            //
            // 存储返回值
            //
            if (this.Reader == null)
            {
                return 0;
            }
            this.FillApply(ref applyList);

            return 1;
        }
        #endregion
        #region 根据门诊患者编号和患者类别获取等待确认的申请单明细信息(1：成功；-1：失败：0：空)
        /// <summary>
        /// 根据门诊患者编号和患者类别获取等待确认的申请单明细信息(1：成功；-1：失败：0：空)
        /// </summary>
        /// <param name="queryCode">患者编码</param>
        /// <param name="patientType">患者类别</param>
        /// <param name="applyList">返回的申请单明细</param>
        /// <param name="executeDepartment">执行科室编码</param>
        /// <returns>1：成功；-1：失败：0：空</returns>
        public int QueryTerminalApplyList(string queryCode, ref ArrayList applyList, string executeDepartment, string patientType)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1)
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            string strSql = this.GetTerminalSql();
            if (strSql == null)
            {
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetOutpatientTerminalApplyList", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            SQL = strSql + SQL;
            // 如果有时间限制，附加时间限制WHERE语句
            if (boolLimited)
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetTerminalApplyList.Where", ref WHERE);
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    ;
                    return -1;
                }
                SQL = SQL + " " + WHERE;
            }

            //
            // 格式化SQL语句
            //
            if (boolLimited) // 如果有时间限制，附加时间参数
            {
                try
                {
                    SQL = string.Format(SQL, executeDepartment, queryCode, patientType, this.stringLimitedDate);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            } // 如果有时间限制，附加时间参数
            else
            {
                try
                {
                    SQL = string.Format(SQL, executeDepartment, queryCode, patientType);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            //
            // 形成结果
            //
            if (this.Reader == null)
            {
                return 0;
            }
            this.FillApply(ref applyList);
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据申请单流水号获取已经确认数量(1：成功/-1：失败/0：空)
        /// <summary>
        /// 根据申请单流水号获取已经确认数量(1：成功/-1：失败/0：空)
        /// </summary>
        /// <param name="applyNumber">申请单流水号</param>
        /// <param name="alreadyCount">返回的已经确认数量</param>
        /// <returns>1：成功/-1：失败/0：空</returns>
        public int GetAlreadyCount(string applyNumber, ref decimal alreadyCount)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetAlreadyCount", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetAlreadyCount", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并SQL和WHERE
            SQL = SQL + WHERE;
            //
            // 格式化SQL语句
            // 
            try
            {
                SQL = string.Format(SQL, applyNumber);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            //
            // 返回结果
            //
            if (this.Reader.Read())
            {
                alreadyCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
            }
            else
            {
                return 0;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据病历号获取申请单数组
        /// <summary>
        /// 根据病历号获取申请单数组
        /// [参数1: string cardNO - 病历号]
        /// [参数2: ArrayList applyList - 申请单数组]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="cardNO">病例号</param>
        /// <param name="applyList">返回的明细</param>
        /// <returns>1：成功/-1：失败</returns>
        public int QueryApplyListByCardNO(string cardNO, ref ArrayList applyList)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            SQL = this.GetTerminalSql();
            if (SQL == null)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            intReturn = this.Sql.GetSql("Terminal.TerminalValidate.GetApplyListByCardNO.Where.Nodepartment", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            SQL = SQL + " " + WHERE;
            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, cardNO);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            //
            // 形成结果
            //
            if (this.Reader == null)
            {
                return 0;
            }
            this.FillApply(ref applyList);
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        /// <summary>
        /// 根据住院号查找终端确认明细
        /// </summary>
        /// <param name="inpatientNO">住院号</param>
        /// <param name="operDept">操作员所在科室</param>
        /// <param name="applyList">返回的明细</param>
        /// <returns></returns>
        public int QueryTerminalConfirmList(string inpatientNO,string  operDept, ref ArrayList applyList)
        {
            // SQL语句
            string sql = "";
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("Terminal.TerminalConfirm.QueryConfirmInfoByInpatientNO", ref sql) == -1)
            {
                this.Err = "获取SQL语句Terminal.TerminalConfirm.QueryConfirmInfoByInpatientNO失败";
                return -1;
            }
            // 匹配执行SQL语句
            try
            {
                //sql = string.Format(sql, GetParam(medTechItem));

                this.ExecQuery(sql, inpatientNO, operDept);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }

            this.FillInpatientConfirmDetail(applyList);

            return 1;
        }
        /// <summary>
        /// 根据查询结果对arraylist赋值
        /// </summary>
        /// <param name="applyList"></param>
        /// <returns></returns>
        private void FillInpatientConfirmDetail(ArrayList applyList)
        {
            // 定义承载对象
            Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail confirmDetail;

            while (this.Reader.Read()) // 循环读取继承的Reader对象
            {
                confirmDetail = new TerminalConfirmDetail();
                confirmDetail.MoOrder = this.Reader[0].ToString();
                confirmDetail.ExecMoOrder = this.Reader[1].ToString();
                confirmDetail.Sequence = this.Reader[2].ToString();
                confirmDetail.Apply.Item.ID = this.Reader[3].ToString();
                confirmDetail.Apply.Item.Name = this.Reader[4].ToString();
                confirmDetail.Apply.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                confirmDetail.Apply.Item.ConfirmOper.ID = this.Reader[6].ToString();
                confirmDetail.Apply.ConfirmOperEnvironment.Dept.ID = this.Reader[7].ToString();
                confirmDetail.Apply.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());
                confirmDetail.Apply.Item.RecipeNO = this.Reader[9].ToString();
                confirmDetail.Apply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[10].ToString());
                confirmDetail.ExecDevice = this.Reader[11].ToString();
                confirmDetail.Oper.ID = this.Reader[12].ToString();

                applyList.Add(confirmDetail);
            }
        }


        #region 根据病历号获取患者的申请单明细（1：成功/-1：失败）
        /// <summary>
        /// 根据病历号获取患者的申请单明细（1：成功/-1：失败）
        /// </summary>
        /// <param name="cardNO">病例号</param>
        /// <param name="applyList">返回的明细</param>
        /// <param name="currentDepartment">当前科室编码</param>
        /// <param name="IsExam">是不是集体体检</param>
        /// <returns>1：成功/-1：失败</returns>
        public int QueryApplyListByCardNO(string cardNO, ref ArrayList applyList, string currentDepartment, bool IsExam)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取时间限制
            //
            if (this.GetLimited() == -1)
            {
                return -1;
            }
            //
            // 获取SQL语句
            //
            SQL = this.GetTerminalSql();
            if (SQL == null)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            if (currentDepartment.Equals(""))
            {
                if (boolLimited)
                {
                    intReturn = this.Sql.GetSql("Terminal.TerminalConfirm.GetApplyListByCardNO.Where.1.Other1", ref WHERE);
                }
                else
                {
                    intReturn = this.Sql.GetSql("Terminal.TerminalConfirm.GetApplyListByCardNO.Where.1.Other", ref WHERE);
                }               
            }
            else
            {
                if (boolLimited)
                {
                    intReturn = this.Sql.GetSql("Terminal.TerminalConfirm.GetApplyListByCardNO.Where.11", ref WHERE);
                }
                else
                {
                    intReturn = this.Sql.GetSql("Terminal.TerminalConfirm.GetApplyListByCardNO.Where.1", ref WHERE);
                }
            }       
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            SQL = SQL + " " + WHERE;

            #region 因修改com_sql需要，屏掉以下代码。 —by lichao2007-4-28
            /*
            string IsFeeWhere = "";
            if (!IsExam)
            {
                intReturn = this.Sql.GetSql("TerminalValidate.GetApplyListByCardNO.Where.IsFeeWhere", ref IsFeeWhere);
            }            
           
            // 如果有时间限制，附加时间限制WHERE条件语句
            if (boolLimited)
            {
                intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetApplyListByCardNO.Where.2", ref WHERE);
                if (intReturn == -1)
                {
                    this.SetError("", "获取SQL语句失败");
                    return -1;
                }
                SQL = SQL + " " + WHERE;
            }
            */
            #endregion
            //
            // 格式化SQL语句
            //
            if (boolLimited) // 如果有时间限制，附加时间参数
            {
                try
                {
                    SQL = string.Format(SQL, cardNO, currentDepartment, this.stringLimitedDate);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            else
            {
                try
                {
                    SQL = string.Format(SQL, cardNO, currentDepartment);
                }
                catch (Exception e)
                {
                    this.SetError("", "格式化SQL语句失败" + e.Message);
                    return -1;
                }
            }
            //
            // 执行SQL语句
            //
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            //
            // 形成结果
            //
            if (this.Reader == null)
            {
                return 0;
            }
            this.FillApply(ref applyList);
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据医嘱号判断申请单是否存在，返回已经确认标志(1：存在/0：不存在/-1：失败)
        /// <summary>
        /// 根据医嘱号判断申请单是否存在，返回已经确认标志(1：存在/0：不存在/-1：失败)
        /// </summary>
        /// <param name="orderCode">医嘱流水号</param>
        /// <param name="sendFlag">医嘱执行状态：'2'已经执行</param>
        /// <returns>1：存在/0：不存在/-1：失败</returns>
        public int JudgeIfConfirm(string orderCode, ref string sendFlag)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.JudgeIfConfirm.Select", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.JudgeIfConfirm.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            this.CreateSql();
            // 格式化SQL语句
            try
            {
                SQL = string.Format(SQL, orderCode);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }

            // 执行SQL语句
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            // 判断获取结果
            if (this.Reader == null)
            {
                return 0;
            }
            else if (this.Reader.Read())
            {
                // 如果有记录
                sendFlag = this.Reader[0].ToString();
                return 1;
            }
            else
            {
                // 不存在
                return 0;
            }
        }

        /// <summary>
        /// 根据医嘱号判断申请单是否存在，返回已经确认标志(1：存在/0：不存在/-1：失败)
        /// </summary>
        /// <param name="applyID">申请单号码</param>
        /// <param name="sendFlag">医嘱执行状态：'2'已经执行</param>
        /// <returns>1：存在/0：不存在/-1：失败</returns>
        public int JudgeIfConfirmByID(string applyID, ref string sendFlag)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.JudgeIfConfirm.Select", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.JudgeIfConfirm.Where.ID", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            this.CreateSql();
            // 格式化SQL语句
            try
            {
                if (applyID == "" || applyID == null)
                {
                    applyID = "0";
                }
                SQL = string.Format(SQL, applyID);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }

            // 执行SQL语句
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            // 判断获取结果
            if (this.Reader == null)
            {
                return 0;
            }
            else if (this.Reader.Read())
            {
                // 如果有记录
                sendFlag = this.Reader[0].ToString();
                return 1;
            }
            else
            {
                // 不存在
                return 0;
            }
        }
        #endregion
        #region 根据医嘱号获取申请单号
        /// <summary>
        /// 根据医嘱号获取申请单号
        /// </summary>
        /// <param name="orderNO">医嘱号</param>
        /// <param name="applyNO">申请单号</param>
        /// <returns>1－成功，－1－失败</returns>
        public int GetApplyNoByOrderNo(string orderNO, ref string applyNO)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetApplyNoByOrderNo.Select", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetApplyNoByOrderNo.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            this.CreateSql();
            // 格式化SQL语句
            try
            {
                SQL = string.Format(SQL, orderNO);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            // 执行SQL语句
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            // 判断获取结果
            if (this.Reader == null)
            {
                return -1;
            }
            else if (this.Reader.Read())
            {
                // 如果有记录
                applyNO = this.Reader[0].ToString();
                return 1;
            }
            else
            {
                // 失败
                return -1;
            }
        }
        #endregion
        #region 根据医嘱号判断是否存在预约记录
        /// <summary>
        /// 根据医嘱号获取申请单号
        /// </summary>
        /// <param name="orderNO">医嘱号</param>
        /// <param name="applyNO">申请单号</param>
        /// <returns>1－成功，－1－失败</returns>
        public int GetTerminalApply(string moOrder)
        {
            string applyNO = string.Empty;
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Terminal.TerminalConfirm.GetTerminalApply", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            try
            {
                SQL = string.Format(SQL, moOrder);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            // 执行SQL语句
            intReturn = this.ExecQuery(SQL);
            if (intReturn == -1)
            {
                this.SetError("", "执行SQL语句失败");
                return -1;
            }
            // 判断获取结果
            if (this.Reader == null)
            {
                return -1;
            }
            else if (this.Reader.Read())
            {
                // 如果有记录
                applyNO = this.Reader[0].ToString();
                return -1;
            }
            else
            {
                // 无记录
                return 1;
            }
        }
        #endregion

        /// <summary>
        /// 根据医嘱号获取终端确认主表信息
        /// </summary>
        /// <param name="SequenceNo"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Terminal.TerminalApply GetItemListBySequence(string MoOrder, string ApplyNum)
        {
            string strSQL = "";
            string strSql2 = GetTerminalSql();
            //取SELECT语句
            if (this.Sql.GetSql("Neusoft.HISFC.Object.Terminal.TerminalApply", ref strSQL) == -1)
            {
                this.Err = "没有找到Neusoft.HISFC.Object.Terminal.TerminalApply字段!";
                return null;
            }
            strSQL = string.Format(strSQL, MoOrder, ApplyNum);
            strSQL = strSql2 + strSQL;
            ArrayList list = GetTerminalList(strSQL); //体检项目信息实体
            if (list == null)
            {
                return null;
            }
            if (list.Count == 0)
            {
                return new Neusoft.HISFC.Models.Terminal.TerminalApply();
            }
            return (Neusoft.HISFC.Models.Terminal.TerminalApply)list[0];
        }

      


        //
        // 其它
        //
        #region 根据执行科室编码、时间范围获取处方明细(1：成功/-1：失败)
        /// <summary>
        /// 根据执行科室编码、时间范围获取处方明细(1：成功/-1：失败)
        /// </summary>
        /// <param name="departmentCode">输入的科室编码</param>
        /// <param name="operatorCode">输入的操作员编码</param>
        /// <param name="dateFrom">输入的起始时间</param>
        /// <param name="dateTo">输入的截止时间</param>
        /// <param name="dsResult">返回的查询结果</param>
        /// <returns>1：成功/-1：失败</returns>
        public int QueryFeeItemList(string departmentCode, string operatorCode, string dateFrom, string dateTo, ref System.Data.DataSet dsResult)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetFeeItemList.Select", ref SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }

            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetFeeItemList.Where", ref WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            // 合并没有时间限制的SQL语句
            SQL = SQL + " " + WHERE;

            // 格式化SQL语句
            try
            {
                SQL = string.Format(SQL, departmentCode, operatorCode, dateFrom, dateTo);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            // 执行SQL语句
            intReturn = this.ExecQuery(SQL, ref dsResult);
            if (intReturn == -1)
            {
                this.SetError("", "SQL语句执行失败");
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据医嘱号获取发票明细信息
        /// <summary>
        /// 根据医嘱号获取发票明细信息
        /// [参数1: string orderCode - 医嘱号]
        /// [参数2: System.Data.DataSet dsResult - 查询结果]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="orderCode">医嘱号</param>
        /// <param name="dsResult">查询结果</param>
        /// <returns>1-成功,-1-失败</returns>
        public int QueryInvoiceDetailByOrderCode(string orderCode, ref System.Data.DataSet dsResult)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetInvoiceDetailByOrderCode.Select", ref this.SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            intReturn = this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.GetInvoiceDetailByOrderCode.Where", ref this.WHERE);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            this.CreateSql();
            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, orderCode);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL, ref dsResult);
            if (this.intReturn == -1)
            {
                this.SetError("", "根据医嘱号获取发票明细信息");
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion

        /// <summary>
        /// 住院患者获取项目的执行数量
        /// </summary>
        /// <param name="patient">患者实体</param>
        /// <param name="fee">费用实体</param>
        /// <param name="confirmedCount">已经确认执行数量</param>
        /// <returns>1－成功；－1－失败；0－不存在</returns>
        public int GetInpatientConfirmInformation(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList fee, ref int confirmedCount)
        {
            //
            // 初始化变量
            //
            this.Clear();
            //
            // 获取SQL语句
            //
            intReturn = this.Sql.GetSql("Neusoft.HISFC.BizLogic.Terminal.Confirm.GetConfirmInformation", ref this.SQL);
            if (intReturn == -1)
            {
                this.SetError("", "获取SQL语句Neusoft.HISFC.BizLogic.Terminal.Confirm.GetConfirmInformation失败");
                return -1;
            }
            //
            // 格式化SQL语句
            //
            try
            {
                SQL = string.Format(SQL, "2", fee.RecipeNO, fee.SequenceNO);
            }
            catch (Exception e)
            {
                this.SetError("", "格式化SQL语句失败" + e.Message);
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.SetError("", "根据医嘱号获取发票明细信息");
                return -1;
            }
            if (this.Reader.Read())
            {
                confirmedCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[0].ToString());
            }
            else
            {
                return 0;
            }
            // 成功返回
            return 1;
        }

        //
        // 业务子表
        //
        #region 取消终端确认明细表 已确认过的明细
        public int UpdateConfirmDetail(string ApplyNum, string ValidFlag)
        {
            // SQL语句
            string sql = "";
            //
            // 获取SQL语句
            //
            if (this.Sql.GetSql("TerminalConfirm.UpdateConfirmDetail", ref sql) == -1)
            {
                this.Err = "获取SQL语句TerminalConfirm.UpdateConfirmDetail失败";
                return -1;
            }
            // 匹配执行
            try
            {
                //sql = string.Format(sql, GetParam(medTechItem));
                return this.ExecNoQuery(sql, ApplyNum, ValidFlag,this.Operator.ID);
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                return -1;
            }
        }

        #endregion
        #region 创建明细
        /// <summary>
        /// 创建明细
        /// [参数: Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail - 明细实体类]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="detail">明细实体类</param>
        /// <returns>1-成功,-1-失败</returns>
        public int Insert(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.TerminalConfirm.CreateDetail", ref this.SQL);
            if (this.intReturn == -1)
            {
                this.SetError("", "创建业务明细获取SQL语句失败!" + "\n" + this.Err);
                return -1;
            }
            //
            // 填充数组
            //
            this.FillDetailParm(detail);
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, detailParms);
            }
            catch
            {
                this.SetError("", "创建业务明细格式化SQL语句失败!" + "\n" + this.Err);
                return -1;
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecNoQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.SetError("", "创建业务明细执行SQL语句失败!" + "\n" + this.Err);
                return -1;
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion
        #region 根据申请单流水号获取业务明细
        /// <summary>
        /// 根据申请单流水号获取业务明细
        /// [参数1: Neusoft.HISFC.Models.Terminal.TerminalApply apply - 申请单]
        /// [参数2: ArrayList alDetails - 业务明细]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="apply">申请单</param>
        /// <param name="alDetails">业务明细</param>
        /// <returns></returns>
        public int QueryDetailsByApply(Neusoft.HISFC.Models.Terminal.TerminalApply apply, ref ArrayList alDetails)
        {
            //
            // 获取SQL语句
            //
            this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetDetails", ref this.SQL);
            if (this.intReturn == -1)
            {
                this.SetError("", "获取业务明细失败!" + "\n" + this.Err);
                return -1;
            }
            this.intReturn = this.Sql.GetSql("neusoft.HISFC.Management.MedTech.GetDetails.ByApplyCode", ref this.WHERE);
            if (this.intReturn == -1)
            {
                this.SetError("", "获取业务明细失败!" + "\n" + this.Err);
                return -1;
            }
            // 构造SQL语句
            this.CreateSql();
            //
            // 格式化SQL语句
            //
            try
            {
                this.SQL = string.Format(this.SQL, apply.Order.ID, apply.ID);
            }
            catch
            {
                this.SetError("", "获取业务明细失败!" + "\n" + "格式化SQL语句失败");
            }
            //
            // 执行SQL语句
            //
            this.intReturn = this.ExecQuery(this.SQL);
            if (this.intReturn == -1)
            {
                this.SetError("", "获取业务明细失败!" + "\n" + this.Err);
                return -1;
            }
            //
            // 转换结果到数组
            //
            while (this.Reader.Read())
            {
                // 业务明细类
                Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail = new TerminalConfirmDetail();
                // 转换Reader成对象
                this.intReturn = this.DetailReaderToObject(detail);
                // 如果出错返回
                if (this.intReturn == -1)
                {
                    this.SetError("", "获取业务明细失败!" + "\n" + this.Err);
                    return -1;
                }
                // 添加对象进数组
                alDetails.Add(detail);
            }
            //
            // 成功返回
            //
            return 1;
        }
        #endregion

        #endregion 

        #region 住院终端确认明细表
        /// <summary>
        /// 获取主SQL
        /// </summary>
        /// <returns></returns>
        private string GetInpatientConfirmDetailSql()
        {
            // SQL语句
            string strSql = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.GetInpatientDetailSql", ref strSql) == -1)
            {
                this.Err = "获取SQL语句 Management.Terminal.TerminalConfirm.GetInpatientDetailSql 失败";
                return null;
            }
            return strSql;
        }

        /// <summary>
        /// 根据医嘱流水号获取确认明细
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail>  QueryTerminalConfirmDetailByMoOrder(string MoOrder)
        {
            string strSql = GetInpatientConfirmDetailSql();
            if (strSql == null)
            {
                return null;
            }
            string strSql2 = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByMoOrder", ref strSql2) == -1)
            {
                this.Err = "获取SQL语句 Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByMoOrder 失败";
                return null;
            }

            strSql = strSql + strSql2;
            strSql = string.Format(strSql, MoOrder);
            List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> list = new List<TerminalConfirmDetail>();
            list = QuertMyTerminalConfirmDetail(strSql);
            return list;
        }
        /// <summary>
        /// 根据流水号获取确认明细
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> QueryTerminalConfirmDetailBySequence(string Sequence)
        {
            string strSql = GetInpatientConfirmDetailSql();
            if (strSql == null)
            {
                return null;
            }
            string strSql2 = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Terminal.TerminalConfirm.QueryTerminalConfirmDetailBySequence", ref strSql2) == -1)
            {
                this.Err = "获取SQL语句 Terminal.TerminalConfirm.QueryTerminalConfirmDetailBySequence 失败";
                return null;
            }

            strSql = strSql + strSql2;
            strSql = string.Format(strSql, Sequence);
            List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> list = new List<TerminalConfirmDetail>();
            list = QuertMyTerminalConfirmDetail(strSql);
            return list;
        }
        
        /// <summary>
        /// 根据门诊号获取终端确认明细
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public int QueryConfirmInfoByClinicNo(string clinicNo,string deptID, ref List<Neusoft.HISFC.Models.Terminal.TerminalApply> apply)
        {
            string strSql = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Terminal.TerminalConfirm.GetOutpaientConfirmInfoByCardno", ref strSql) == -1)
            {
                this.Err = "获取SQL语句 Terminal.TerminalConfirm.GetOutpaientConfirmInfoByCardno 失败";
                return -1;
            }

            strSql = string.Format(strSql, clinicNo, deptID);
            apply = QueryOutpatientConfirmDetail(strSql);
            return 1;
        }
        
        /// <summary>
        /// 根据医嘱流水号和医嘱执行单号查询
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <param name="ExecNO"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> QueryTerminalConfirmDetailByMoOrderAndExeMoOrder(string MoOrder,string  ExecNO)
        {
            string strSql = GetInpatientConfirmDetailSql();
            if (strSql == null)
            {
                return null;
            }
            string strSql2 = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByMoOrderAndExeMoOrder", ref strSql2) == -1)
            {
                this.Err = "获取SQL语句 Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByMoOrderAndExeMoOrder 失败";
                return null;
            }

            strSql = strSql + strSql2;
            List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> list = new List<TerminalConfirmDetail>();
            strSql = string.Format(strSql, MoOrder, ExecNO);
            list = QuertMyTerminalConfirmDetail(strSql);
            return list;
        }
        /// <summary>
        /// 查询门诊终端确认明细
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private List<TerminalApply> QueryOutpatientConfirmDetail(string strSql)
        {
            List<Neusoft.HISFC.Models.Terminal.TerminalApply> list = new List<TerminalApply>();
            /*
            select t.item_code,--项目代码0
             t.item_name, --项目名1
            t.confirm_number,--已确认数量2
            t.confirm_employee,--确认人3
            t.confirm_department,--确认科室4
            t.extend_field1,--医嘱流水号5
            t.exec_device,--执行设备6
            t.exec_oper,--执行人7
            t.confirm_date,--确认时间8
             t.current_sequence,--流水号
             t.apply_code
             from met_tec_ta_detail t 
             where t.card_no = '{0}' and t.status = '0'
             
             order by t.oper_date desc
             */
            try
            {

                intReturn = this.ExecQuery(strSql);
                if (intReturn < 0)
                {
                    this.Err = "查询终端确认明细失败";
                    return null;
                }
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.Terminal.TerminalApply obj = new TerminalApply();
                    obj.Item.ID = this.Reader[0].ToString();
                    obj.Item.Name = this.Reader[1].ToString();
                    obj.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[2].ToString());
                    obj.ConfirmOperEnvironment.ID = this.Reader[3].ToString();
                    obj.ConfirmOperEnvironment.Dept.ID = this.Reader[4].ToString();
                    obj.Order.ID = this.Reader[5].ToString();
                    obj.Machine.ID = this.Reader[6].ToString();
                    obj.ExecOper.ID = this.Reader[7].ToString();
                    obj.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());
                    obj.ID = this.Reader[9].ToString();
                    obj.User02 = this.Reader[10].ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
            }
            finally 
            {
                this.Reader.Close();
            }
            return list;
        }
        /// <summary>
        /// 根据确认明细流水号查询
        /// </summary>
        /// <param name="ApplyNum"></param>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> QueryTerminalConfirmDetailByApplyNum(string ApplyNum)
        {
            string strSql = GetInpatientConfirmDetailSql();
            if (strSql == null)
            {
                return null;
            }
            string strSql2 = "";
            // 获取SQL语句
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByApplyNum", ref strSql2) == -1)
            {
                this.Err = "获取SQL语句 Management.Terminal.TerminalConfirm.QueryTerminalConfirmDetailByApplyNum 失败";
                return null;
            }

            strSql = strSql + strSql2;
            List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> list = new List<TerminalConfirmDetail>();
            strSql = string.Format(strSql, ApplyNum);
            list = QuertMyTerminalConfirmDetail(strSql);
            return list;
        }

        private List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> QuertMyTerminalConfirmDetail(string strSql)
        {
            List<Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail> list = new List<TerminalConfirmDetail>();
            intReturn = this.ExecQuery(strSql);
            if (intReturn < 0)
            {
                this.Err = "查询终端确认明细失败";
                return null;
            } 
            while (this.Reader.Read())
            {
                Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail obj = new TerminalConfirmDetail();
                obj.MoOrder = this.Reader[0].ToString();
                obj.ExecMoOrder = this.Reader[1].ToString();
                obj.Sequence = this.Reader[2].ToString();
                obj.Apply.Item.ID = this.Reader[3].ToString();
                obj.Apply.Item.Name = this.Reader[4].ToString();
                obj.Apply.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[5].ToString());
                obj.Apply.ConfirmOperEnvironment.ID = this.Reader[6].ToString();
                obj.Apply.ConfirmOperEnvironment.Dept.ID = this.Reader[7].ToString();
                obj.Apply.ConfirmOperEnvironment.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[8].ToString());
                obj.Status.ID = this.Reader[9].ToString();
                obj.CancelInfo.ID = this.Reader[10].ToString();
                obj.CancelInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
                obj.Apply.Patient.ID = this.Reader[12].ToString();
                obj.Apply.Item.RecipeNO = this.Reader[13].ToString();
                obj.Apply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[14].ToString());
                obj.ExecDevice = this.Reader[15].ToString();
                obj.Oper.ID = this.Reader[16].ToString();
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// 插入申请单
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int InsertInpatientConfirmDetail(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.InsertInpatientConfirmDetail", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            string[] parms = new string[]{  detail.MoOrder,//0
                                            detail.ExecMoOrder,//1
                                            detail.Sequence,//2
                                            detail.Apply.Item.ID,//3
                                            detail.Apply.Item.Name,//4
                                            detail.Apply.Item.ConfirmedQty.ToString(),//5
                                            detail.Apply.ConfirmOperEnvironment.ID,//6
                                            detail.Apply.ConfirmOperEnvironment.Dept.ID,//7
                                            detail.Apply.ConfirmOperEnvironment.OperTime.ToString(),//8
                                            detail.Status.ID,//9
                                            detail.CancelInfo.ID,//10
                                            detail.CancelInfo.OperTime.ToString(),//11
                                            detail.Apply.Patient.ID,
                                            detail.Apply.Item.RecipeNO,
                                            detail.Apply.Item.SequenceNO.ToString(),
                                            detail.ExecDevice,//执行设备
                                            detail.Oper.ID  //执行技师
                                        };
            strSql = string.Format(strSql, parms);
            intReturn = this.ExecNoQuery(strSql);
            if (intReturn <= 0)
            {
                this.Err = "插入终端确认明细失败";
                return -1;
            } 
            return 1;
        }
        /// <summary>
        /// 作废申请单
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int CancelInpatientConfirmDetail(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            string strSql = "";
            string status = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.CancelInpatientConfirmDetail", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            Neusoft.HISFC.Models.Base.Employee obj = (Neusoft.HISFC.Models.Base.Employee)this.Operator;
            //if (detail.Apply.Item.ConfirmedQty > detail.FreeCount)
            //{
            //    status = "0";
            //}
            //else
            //{
            //    status = "1";
            //}
            strSql = string.Format(strSql, detail.Sequence, "0", obj.ID, detail.FreeCount, detail.Apply.Item.ConfirmedQty - detail.FreeCount);
            intReturn = this.ExecNoQuery(strSql);
            if (intReturn <= 0)
            {
                this.Err = "作废终端确认明细失败";
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 更新医嘱单
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int CancelInpatientConfirmMoOrder(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.CancelInpatientConfirmMoOrder", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, detail.MoOrder,detail.ExecMoOrder);
            intReturn = this.ExecNoQuery(strSql);
            if (intReturn <= 0)
            {
                this.Err = "更新医嘱执行档失败";
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 更新收费表
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int CancelInpatientItemList(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.CancelInpatientItemList", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, detail.Apply.Item.RecipeNO,detail.Apply.Item.SequenceNO,detail.FreeCount);//准备改
            intReturn = this.ExecNoQuery(strSql);
            if (intReturn <= 0)
            {
                this.Err = "更新医嘱执行档失败";
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 更新收费表{2CE2BB1D-9DEB-4afa-90CF-15E3E44285E1}
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int CancelInpatientItemListWithSeq(Neusoft.HISFC.Models.Terminal.TerminalConfirmDetail detail)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.CancelInpatientItemListWithSeq", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            //strSql = string.Format(strSql, detail.Apply.Item.RecipeNO,detail.Apply.Item.SequenceNO,detail.Apply.Item.ConfirmedQty);
            #region {CB8F8F87-3389-4757-AC01-242CAF44A492}
            strSql = string.Format(strSql,
                detail.MoOrder, detail.ExecMoOrder, detail.Apply.Item.ConfirmedQty, detail.Apply.Item.RecipeNO
                , detail.Apply.Item.SequenceNO);
            #endregion
            intReturn = this.ExecNoQuery(strSql);
            if (intReturn <= 0)
            {
                this.Err = "更新医嘱执行档失败";
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 查询医嘱号下的已确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public decimal GetAlreadConfirmNum(string MoOrder)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.GetAlreadConfirmNum", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, MoOrder);
            this.ExecQuery(strSql);
            decimal confirmQty = 0;
            while(this.Reader.Read())
            {
                confirmQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
            }
            return confirmQty;
        }
        /// <summary>
        /// 查询医嘱号下的已确认数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public decimal GetAlreadConfirmNum(string MoOrder,string ExeNO)
        {
            if (ExeNO == null || ExeNO == "")
            {
                return GetAlreadConfirmNum(MoOrder);
            }
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.GetAlreadConfirmNumMoOrder", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, MoOrder, ExeNO);
            this.ExecQuery(strSql);
            decimal confirmQty = 0;
            while (this.Reader.Read())
            {
                confirmQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
            }
            return confirmQty;
        }  

        /// <summary>
        /// 查询医嘱执行档数量
        /// </summary>
        /// <param name="MoOrder"></param>
        /// <returns></returns>
        public decimal GetExecOrderQty(string execOrder)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.GetExecOrderQty", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, execOrder);
            this.ExecQuery(strSql);
            decimal execOrderQty = 0;
            while (this.Reader.Read())
            {
                execOrderQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[0]);
            }
            return execOrderQty;
        } 

        /// <summary>
        /// 作废执行档
        /// </summary>
        /// <returns>1：成功/-1：失败</returns>
        public int CancelExecOrder(string execOrder)
        {
            string strSql = "";
            if (this.Sql.GetSql("Management.Terminal.TerminalConfirm.CancelExecOrder", ref strSql) == -1)
            {
                this.SetError("", "获取SQL语句失败");
                return -1;
            }
            strSql = string.Format(strSql, execOrder, this.Operator.ID, this.GetSysDateTime());
            return this.ExecNoQuery(strSql);
        }
        #endregion 

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        /// <summary>
        /// 删除有效的申请数据
        /// </summary>
        /// <param name="recipeNO">处方序号</param>
        /// <param name="recipeSequenceNO">处方内项目流水号</param>
        /// <returns></returns>
        public int DelTecApply(string recipeNO, string recipeSequenceNO)
        {
            string sql = string.Empty;
            string wheresql = string.Empty;
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate", ref sql) == -1)
            {
                this.Err = "查询索引为neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate的SQL失败！";
                return -1;
            }
            if (this.Sql.GetSql("neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate.Where1", ref wheresql) == -1)
            {
                this.Err = "查询索引为neusoft.HISFC.Management.TerminalValidate.Outpatient.DeleteValidate.Where1的SQL失败！";
                return -1;
            }
            sql += wheresql;
            sql = string.Format(sql, recipeNO, recipeSequenceNO);
            return this.ExecNoQuery(sql);
        }

        #endregion
    }
}

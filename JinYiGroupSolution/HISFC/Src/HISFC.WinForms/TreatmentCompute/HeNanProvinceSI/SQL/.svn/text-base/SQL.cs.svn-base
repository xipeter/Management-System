using System;
using System.Collections.Generic;
using System.Text;

namespace HeNanProvinceSI
{
    /// <summary>
    /// [功能描述: SQL语句]<br></br>
    /// [创 建 者: 许超]<br></br>
    /// [创建时间: 2009-2-13]<br></br>
    /// 修改记录
    /// 修改人=''
    ///	修改时间=''
    ///	修改目的=''
    ///	修改描述=''
    /// 
    /// </summary>
    public class SQL
    {

        #region SQL语句

        #region 住院业务
        /// <summary>
        /// 插入主表信息
        /// </summary>
        public static string InsertInpatientSIMainInfoSQL = @"
                                                        Insert Into Fin_Ipr_Siinmaininfo --医保信息住院主表
                                                          (Inpatient_No, --住院流水号
                                                           Balance_No, --结算序号
                                                           Invoice_No, --发票号
                                                           Medical_Type, --医疗类别
                                                           Patient_No, --住院号
                                                           Card_No, --就诊卡号
                                                           Mcard_No, --医疗证号
                                                           App_No, --审批号
                                                           Procreate_Pcno, --生育保险患者电脑号
                                                           Si_Begindate, --参保日期
                                                           Si_State, --参保状态
                                                           Name, --姓名
                                                           Sex_Code, --性别
                                                           Idenno, --身份证号
                                                           Spell_Code, --拼音
                                                           Birthday, --生日
                                                           Empl_Type, --人员类别 1 在职 2 退休 
                                                           Work_Name, --工作单位
                                                           Clinic_Diagnose, --门诊诊断
                                                           Dept_Code, --科室代码
                                                           Dept_Name, --科室名称
                                                           Paykind_Code, --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                           Pact_Code, --合同代码
                                                           Pact_Name, --合同单位名称
                                                           Bed_No, --床号
                                                           In_Date, --入院日期
                                                           In_Diagnosedate, --入院诊断日期
                                                           In_Diagnose, --入院诊断代码
                                                           In_Diagnosename, --入院诊断名称
                                                           Oper_Code, --操作员
                                                           Oper_Date,
                                                           Reg_No,
                                                           Fee_Times,
                                                           Hos_Cost,
                                                           Year_Cost,
                                                           Out_Date,
                                                           Out_Diagnose,
                                                           Out_Diagnosename,
                                                           Balance_Date,
                                                           Tot_Cost,
                                                           Pay_Cost,
                                                           Pub_Cost,
                                                           Item_Paycost,
                                                           Base_Cost,
                                                           Item_Ylcost,
                                                           Item_Paycost2,
                                                           Own_Cost,
                                                           Over_Cost,
                                                           Valid_Flag,
                                                           Balance_State,
                                                           Remark,
                                                           Official_Cost,
                                                           Type_Code,
                                                           Person_Type,
                                                           Primarydiagnosecode, --20081226ADD
                                                           Operatecode1,
                                                           Operatecode2,
                                                           Operatecode3,
                                                           Primarydiagnosename)
                                                        Values
                                                          ('{0}', --住院流水号
                                                           '{1}', --结算序号
                                                           '{2}', --发票号
                                                           '{3}', --医疗类别
                                                           '{4}', --住院号
                                                           '{5}', --就诊卡号
                                                           '{6}', --医疗证号
                                                           '{7}', --审批号
                                                           '{8}', --生育保险患者电脑号
                                                           To_Date('{9}', 'YYYY-MM-DD hh24:mi:ss'), --参保日期
                                                           '{10}', --参保状态
                                                           '{11}', --姓名
                                                           '{12}', --性别
                                                           '{13}', --身份证号
                                                           '{14}', --拼音
                                                           To_Date('{15}', 'YYYY-MM-DD hh24:mi:ss'), --生日
                                                           '{16}', --人员类别 1 在职 2 退休 
                                                           '{17}', --工作单位
                                                           '{18}', --门诊诊断
                                                           '{19}', --科室代码
                                                           '{20}', --科室名称
                                                           '{21}', --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                           '{22}', --合同代码
                                                           '{23}', --合同单位名称
                                                           '{24}', --床号
                                                           To_Date('{25}', 'YYYY-MM-DD hh24:mi:ss'), --入院日期
                                                           To_Date('{26}', 'YYYY-MM-DD hh24:mi:ss'), --入院诊断日期
                                                           '{27}', --入院诊断代码
                                                           '{28}', --入院诊断名称
                                                           '{29}', --操作员
                                                           Sysdate,
                                                           '{31}',
                                                           {32},
                                                           {33},
                                                           {34},
                                                           To_Date('{35}', 'yyyy-mm-dd hh24:mi:ss'),
                                                           '{36}',
                                                           '{37}',
                                                           To_Date('{38}', 'yyyy-mm-dd hh24:mi:ss'),
                                                           {39},
                                                           {40},
                                                           {41},
                                                           {42},
                                                           {43},
                                                           {44},
                                                           {45},
                                                           {46},
                                                           {47},
                                                           '{48}',
                                                           '{49}',
                                                           '{50}',
                                                           '{51}',
                                                           '2',
                                                           '{52}',
                                                           '{53}', --20081226ADD
                                                           '{54}',
                                                           '{55}',
                                                           '{56}',
                                                           '{57}')";

        /// <summary>
        /// 获取住院患者信息
        /// </summary>
        public static string GetInpatientInfoByBalanceStateSQL = @"Select '', --本级医疗机构编码
                                                           Inpatient_No, --住院流水号
                                                           Balance_No, --结算序号
                                                           Invoice_No, --发票号
                                                           Medical_Type, --医疗类别
                                                           Patient_No, --住院号
                                                           Card_No, --就诊卡号
                                                           Mcard_No, --医疗证号
                                                           App_No, --审批号
                                                           Procreate_Pcno, --生育保险患者电脑号
                                                           Si_Begindate, --参保日期
                                                           Si_State, --参保状态
                                                           Name, --姓名
                                                           Sex_Code, --性别
                                                           Idenno, --身份证号
                                                           Birthday, --生日
                                                           Empl_Type, --人员类别 1 在职 2 退休
                                                           Work_Name, --工作单位
                                                           Clinic_Diagnose, --门诊诊断
                                                           Dept_Code, --科室代码
                                                           Dept_Name, --科室名称
                                                           Paykind_Code, --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                           Pact_Code, --合同代码
                                                           Pact_Name, --合同单位名称
                                                           Bed_No, --床号
                                                           In_Date, --入院日期
                                                           In_Diagnose, --入院诊断代码
                                                           In_Diagnosename, --入院诊断名称
                                                           Out_Date, --出院日期
                                                           Out_Diagnose, --出院诊断代码
                                                           Out_Diagnosename, --出院诊断名称
                                                           Balance_Date, --结算日期(上次)
                                                           Tot_Cost, --费用金额(未结)(住院总金额)
                                                           Pay_Cost, --帐户支付
                                                           Pub_Cost, --公费金额(未结)(社保支付金额)
                                                           Item_Paycost, --部分项目自付金额
                                                           Base_Cost, --个人起付金额
                                                           Item_Paycost2, --个人自费项目金额
                                                           Item_Ylcost, --个人自付金额（乙类自付部分）
                                                           Own_Cost, --个人自负金额
                                                           Overtake_Owncost, --超统筹支付限额个人自付金额
                                                           Own_Cause, --自费原因
                                                           Oper_Code, --操作员
                                                           Oper_Date, --操作日期
                                                           Reg_No,
                                                           Fee_Times,
                                                           Hos_Cost,
                                                           Year_Cost,
                                                           Valid_Flag,
                                                           Balance_State,
                                                           Remark,
                                                           Type_Code,
                                                           Over_Cost,
                                                           Person_Type,
                                                           
                                                           Primarydiagnosecode, --20081226ADD
                                                           Operatecode1,
                                                           Operatecode2,
                                                           Operatecode3,
                                                           Primarydiagnosename

                                                      From Fin_Ipr_Siinmaininfo --医保信息住院主表
                                                     Where Inpatient_No = '{0}'
                                                       And Balance_State = '{1}'
                                                       And Type_Code = '2'
                                                    ";

        /// <summary>
        /// 根据发票号获取住院患者信息
        /// </summary>
        public static string GetInpatientInfoByInvoiceSQL = @"SELECT '',   --本级医疗机构编码
                                                           inpatient_no,   --住院流水号
                                                           balance_no,   --结算序号
                                                           invoice_no,   --发票号
                                                           medical_type,   --医疗类别
                                                           patient_no,   --住院号
                                                           card_no,   --就诊卡号
                                                           mcard_no,   --医疗证号
                                                           app_no,   --审批号
                                                           procreate_pcno,   --生育保险患者电脑号
                                                           si_begindate,   --参保日期
                                                           si_state,   --参保状态
                                                           name,   --姓名
                                                           sex_code,   --性别
                                                           idenno,   --身份证号
                                                           birthday,   --生日
                                                           empl_type,   --人员类别 1 在职 2 退休
                                                           work_name,   --工作单位
                                                           clinic_diagnose,   --门诊诊断
                                                           dept_code,   --科室代码
                                                           dept_name,   --科室名称
                                                           paykind_code,   --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                           pact_code,   --合同代码
                                                           pact_name,   --合同单位名称
                                                           bed_no,   --床号
                                                           in_date,   --入院日期
                                                           in_diagnose,   --入院诊断代码
                                                           in_diagnosename,   --入院诊断名称
                                                           out_date,   --出院日期
                                                           out_diagnose,   --出院诊断代码
                                                           out_diagnosename,   --出院诊断名称
                                                           balance_date,   --结算日期(上次)
                                                           tot_cost,   --费用金额(未结)(住院总金额)
                                                           pay_cost,   --帐户支付
                                                           pub_cost,   --公费金额(未结)(社保支付金额)
                                                           item_paycost,   --部分项目自付金额
                                                           base_cost,   --个人起付金额
                                                           item_paycost2,   --个人自费项目金额
                                                           item_ylcost,   --个人自付金额（乙类自付部分）
                                                           own_cost,   --个人自负金额
                                                           overtake_owncost,   --超统筹支付限额个人自付金额
                                                           own_cause,   --自费原因
                                                           oper_code,   --操作员
                                                           oper_date,    --操作日期
                                                           reg_no,
                                                           fee_times,
                                                           hos_cost,
                                                          year_cost,
                                                          VALID_FLAG,
                                                          BALANCE_STATE,
                                                               remark,
                                                               type_code,
                                                               person_type,
                                                               
                                                               
                                                  PRIMARYDIAGNOSECODE, --20081226ADD
                                                  OPERATECODE1,
                                                  OPERATECODE2,
                                                  OPERATECODE3,
                                                  PRIMARYDIAGNOSENAME
                                                               
                                                      FROM fin_ipr_siinmaininfo   --医保信息住院主表
                                                     WHERE   inpatient_no = '{0}'
                                                     and invoice_no = '{1}'
                                                         and type_code = '2'
                                                ";


        /// <summary>
        /// 更新住院信息
        /// </summary>
        public static string UpdateInpatientInfoSQL = @"
                                            Update Fin_Ipr_Siinmaininfo --医保信息住院主表
                                               Set Balance_No       = '{1}',
                                                   Invoice_No       = '{2}', --发票号
                                                   Medical_Type     = '{3}', --医疗类别
                                                   Patient_No       = '{4}', --住院号
                                                   Card_No          = '{5}', --就诊卡号
                                                   Mcard_No         = '{6}', --医疗证号
                                                   App_No           = '{7}', --审批号
                                                   Procreate_Pcno   = '{8}', --生育保险患者电脑号
                                                   Si_Begindate     = To_Date('{9}', 'yyyy-mm-dd hh24:mi:ss'), --参保日期
                                                   Si_State         = '{10}', --参保状态
                                                   Name             = '{11}', --姓名
                                                   Sex_Code         = '{12}', --性别
                                                   Idenno           = '{13}', --身份证号
                                                   Spell_Code       = '{14}', --拼音
                                                   Birthday         = To_Date('{15}', 'yyyy-mm-dd hh24:mi:ss'), --生日
                                                   Empl_Type        = '{16}', --人员类别 1 在职 2 退休
                                                   Work_Name        = Work_Name, --工作单位
                                                   Clinic_Diagnose  = Clinic_Diagnose, --门诊诊断
                                                   Dept_Code        = '{19}', --科室代码
                                                   Dept_Name        = '{20}', --科室名称
                                                   Paykind_Code     = '{21}', --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                   Pact_Code        = '{22}', --合同代码
                                                   Pact_Name        = '{23}', --合同单位名称
                                                   Bed_No           = '{24}', --床号
                                                   In_Date          = To_Date('{25}', 'yyyy-mm-dd hh24:mi:ss'), --入院日期
                                                   In_Diagnosedate  = To_Date('{26}', 'yyyy-mm-dd hh24:mi:ss'), --入院诊断日期
                                                   In_Diagnose      = '{27}', --入院诊断代码
                                                   In_Diagnosename  = '{28}', --入院诊断名称
                                                   Out_Date         = To_Date('{29}', 'yyyy-mm-dd hh24:mi:ss'), --出院日期
                                                   Out_Diagnose     = '{30}', --出院诊断代码
                                                   Out_Diagnosename = '{31}', --出院诊断名称
                                                   Balance_Date     = To_Date('{32}', 'yyyy-mm-dd hh24:mi:ss'), --结算日期(上次)
                                                   Tot_Cost         = '{33}', --费用金额(未结)(住院总金额)
                                                   Pay_Cost         = '{34}', --帐户支付
                                                   Pub_Cost         = '{35}', --公费金额(未结)(社保支付金额)
                                                   Item_Paycost     = '{36}', --部分项目自付金额
                                                   Base_Cost        = '{37}', --个人起付金额
                                                   Item_Paycost2    = '{38}', --个人自费项目金额
                                                   Item_Ylcost      = '{39}', --个人自付金额（乙类自付部分）
                                                   Own_Cost         = '{40}', --个人自负金额
                                                   Overtake_Owncost = '{41}', --超统筹支付限额个人自付金额
                                                   Own_Cause        = '{42}', --自费原因
                                                   Oper_Code        = '{43}', --操作员
                                                   Oper_Date        = Sysdate, --操作日期
                                                   Reg_No           = '{44}',
                                                   Fee_Times        = {45},
                                                   Hos_Cost         = {46},
                                                   Year_Cost        = {47},
                                                   Valid_Flag       = '{48}',
                                                   Balance_State    = '{49}',
                                                   Over_Cost        = '{50}',
                                                   Official_Cost    = '{51}',
                                                   
                                                   Primarydiagnosecode = '{52}', --20081226ADD
                                                   Operatecode1        = '{53}',
                                                   Operatecode2        = '{54}',
                                                   Operatecode3        = '{55}',
                                                   Primarydiagnosename = '{56}'

                                             Where Inpatient_No = '{0}'
                                               And Valid_Flag = '1'
                                               And Balance_No = '{1}'
                                            ";

        /// <summary>
        /// 住院召回插入信息
        /// </summary>
        public static string InsertInpatientInfoForRecallBalance = @"Insert Into Fin_Ipr_Siinmaininfo
                                                                      (Inpatient_No,
                                                                       Reg_No,
                                                                       Fee_Times,
                                                                       Balance_No,
                                                                       Invoice_No,
                                                                       Medical_Type,
                                                                       Patient_No,
                                                                       Card_No,
                                                                       Mcard_No,
                                                                       App_No,
                                                                       Procreate_Pcno,
                                                                       Si_Begindate,
                                                                       Si_State,
                                                                       Name,
                                                                       Sex_Code,
                                                                       Idenno,
                                                                       Spell_Code,
                                                                       Birthday,
                                                                       Empl_Type,
                                                                       Work_Name,
                                                                       Clinic_Diagnose,
                                                                       Dept_Code,
                                                                       Dept_Name,
                                                                       Paykind_Code,
                                                                       Pact_Code,
                                                                       Pact_Name,
                                                                       Bed_No,
                                                                       In_Date,
                                                                       In_Diagnosedate,
                                                                       In_Diagnose,
                                                                       In_Diagnosename,
                                                                       Out_Date,
                                                                       Out_Diagnose,
                                                                       Out_Diagnosename,
                                                                       Balance_Date,
                                                                       Tot_Cost,
                                                                       Pay_Cost,
                                                                       Pub_Cost,
                                                                       Item_Paycost,
                                                                       Base_Cost,
                                                                       Item_Paycost2,
                                                                       Item_Ylcost,
                                                                       Own_Cost,
                                                                       Overtake_Owncost,
                                                                       Hos_Cost,
                                                                       Own_Cause,
                                                                       Oper_Code,
                                                                       Oper_Date,
                                                                       Year_Cost,
                                                                       Valid_Flag,
                                                                       Balance_State,
                                                                       Individualbalance,
                                                                       Freezemessage,
                                                                       Applysequence,
                                                                       Applytypeid,
                                                                       Applytypename,
                                                                       Fundid,
                                                                       Fundname,
                                                                       Businesssequence,
                                                                       Invoice_Seq,
                                                                       Over_Cost,
                                                                       Official_Cost,
                                                                       Remark,
                                                                       Type_Code)
                                                                      Select Inpatient_No,
                                                                             Reg_No,
                                                                             Fee_Times,
                                                                             '{2}',
                                                                             Invoice_No,
                                                                             Medical_Type,
                                                                             Patient_No,
                                                                             Card_No,
                                                                             Mcard_No,
                                                                             App_No,
                                                                             Procreate_Pcno,
                                                                             Si_Begindate,
                                                                             Si_State,
                                                                             Name,
                                                                             Sex_Code,
                                                                             Idenno,
                                                                             Spell_Code,
                                                                             Birthday,
                                                                             Empl_Type,
                                                                             Work_Name,
                                                                             Clinic_Diagnose,
                                                                             Dept_Code,
                                                                             Dept_Name,
                                                                             Paykind_Code,
                                                                             Pact_Code,
                                                                             Pact_Name,
                                                                             Bed_No,
                                                                             In_Date,
                                                                             In_Diagnosedate,
                                                                             In_Diagnose,
                                                                             In_Diagnosename,
                                                                             Out_Date,
                                                                             Out_Diagnose,
                                                                             Out_Diagnosename,
                                                                             Balance_Date,
                                                                             -tot_Cost,
                                                                             -pay_Cost,
                                                                             -pub_Cost,
                                                                             -item_Paycost,
                                                                             Base_Cost,
                                                                             Item_Paycost2,
                                                                             -item_Ylcost,
                                                                             -own_Cost,
                                                                             Overtake_Owncost,
                                                                             Hos_Cost,
                                                                             Own_Cause,
                                                                             '{4}',
                                                                             To_Date('{3}', 'yyyy-mm-dd hh24:mi:ss'),
                                                                             Year_Cost,
                                                                             '0',
                                                                             '1',
                                                                             Individualbalance,
                                                                             Freezemessage,
                                                                             Applysequence,
                                                                             Applytypeid,
                                                                             Applytypename,
                                                                             Fundid,
                                                                             Fundname,
                                                                             Businesssequence,
                                                                             Invoice_Seq,
                                                                             -over_Cost,
                                                                             -official_Cost,
                                                                             Remark,
                                                                             Type_Code
                                                                        From Fin_Ipr_Siinmaininfo
                                                                       Where Inpatient_No = '{0}'
                                                                         And Invoice_No = '{1}'
                                                                         And Type_Code = '2'
                                                                         And Valid_Flag = '1'
                                                                    ";

        #endregion

        #region 门诊业务

        /// <summary>
        /// 门诊插入中间表
        /// </summary>
        public static string InsertOutpatientSIMainInfoSQL = @"
                                                    Insert Into Fin_Ipr_Siinmaininfo --医保信息住院主表
                                                      (Inpatient_No, --住院流水号
                                                       Balance_No, --结算序号
                                                       Invoice_No, --发票号
                                                       Medical_Type, --医疗类别
                                                       Patient_No, --住院号
                                                       Card_No, --就诊卡号
                                                       Mcard_No, --医疗证号
                                                       App_No, --审批号
                                                       Procreate_Pcno, --生育保险患者电脑号
                                                       Si_Begindate, --参保日期
                                                       Si_State, --参保状态
                                                       Name, --姓名
                                                       Sex_Code, --性别
                                                       Idenno, --身份证号
                                                       Spell_Code, --拼音
                                                       Birthday, --生日
                                                       Empl_Type, --人员类别 1 在职 2 退休 
                                                       Work_Name, --工作单位
                                                       Clinic_Diagnose, --门诊诊断
                                                       Dept_Code, --科室代码
                                                       Dept_Name, --科室名称
                                                       Paykind_Code, --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                       Pact_Code, --合同代码
                                                       Pact_Name, --合同单位名称
                                                       Bed_No, --床号
                                                       In_Date, --入院日期
                                                       In_Diagnosedate, --入院诊断日期
                                                       In_Diagnose, --入院诊断代码
                                                       In_Diagnosename, --入院诊断名称
                                                       Oper_Code, --操作员
                                                       Oper_Date,
                                                       Reg_No,
                                                       Fee_Times,
                                                       Hos_Cost,
                                                       Year_Cost,
                                                       Out_Date,
                                                       Out_Diagnose,
                                                       Out_Diagnosename,
                                                       Balance_Date,
                                                       Tot_Cost,
                                                       Pay_Cost,
                                                       Pub_Cost,
                                                       Item_Paycost,
                                                       Base_Cost,
                                                       Item_Ylcost,
                                                       Item_Paycost2,
                                                       Own_Cost,
                                                       Over_Cost,
                                                       Valid_Flag,
                                                       Balance_State,
                                                       Remark,
                                                       Official_Cost, --医保公务员
                                                       Type_Code,
                                                       Person_Type,
                                                       Primarydiagnosecode, --20081226ADD
                                                       Operatecode1,
                                                       Operatecode2,
                                                       Operatecode3,
                                                       Primarydiagnosename)
                                                    Values
                                                      ('{0}', --住院流水号
                                                       '{1}', --结算序号
                                                       '{2}', --发票号
                                                       '{3}', --医疗类别
                                                       '{4}', --住院号
                                                       '{5}', --就诊卡号
                                                       '{6}', --医疗证号
                                                       '{7}', --审批号
                                                       '{8}', --生育保险患者电脑号
                                                       To_Date('{9}', 'YYYY-MM-DD hh24:mi:ss'), --参保日期
                                                       '{10}', --参保状态
                                                       '{11}', --姓名
                                                       '{12}', --性别
                                                       '{13}', --身份证号
                                                       '{14}', --拼音
                                                       To_Date('{15}', 'YYYY-MM-DD hh24:mi:ss'), --生日
                                                       '{16}', --人员类别 1 在职 2 退休 
                                                       '{17}', --工作单位
                                                       '{18}', --门诊诊断
                                                       '{19}', --科室代码
                                                       '{20}', --科室名称
                                                       '{21}', --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                       '{22}', --合同代码
                                                       '{23}', --合同单位名称
                                                       '{24}', --床号
                                                       To_Date('{25}', 'YYYY-MM-DD hh24:mi:ss'), --入院日期
                                                       To_Date('{26}', 'YYYY-MM-DD hh24:mi:ss'), --入院诊断日期
                                                       '{27}', --入院诊断代码
                                                       '{28}', --入院诊断名称
                                                       '{29}', --操作员
                                                       Sysdate,
                                                       '{31}',
                                                       {32},
                                                       {33},
                                                       {34},
                                                       To_Date('{35}', 'yyyy-mm-dd hh24:mi:ss'),
                                                       '{36}',
                                                       '{37}',
                                                       To_Date('{38}', 'yyyy-mm-dd hh24:mi:ss'),
                                                       {39},
                                                       {40},
                                                       {41},
                                                       {42},
                                                       {43},
                                                       {44},
                                                       {45},
                                                       {46},
                                                       {47},
                                                       '{48}',
                                                       '{49}',
                                                       '{50}',
                                                       '{51}',
                                                       '1',
                                                       '{52}',
                                                       '{53}', --20081226ADD
                                                       '{54}',
                                                       '{55}',
                                                       '{56}',
                                                       '{57}')
                                                    ";

        /// <summary>
        /// 获取门诊患者信息
        /// </summary>
        public static string GetOutpatinetInfoByBalanceNOSQL = @"Select '', --本级医疗机构编码
                                                       Inpatient_No, --住院流水号
                                                       Balance_No, --结算序号
                                                       Invoice_No, --发票号
                                                       Medical_Type, --医疗类别
                                                       Patient_No, --住院号
                                                       Card_No, --就诊卡号
                                                       Mcard_No, --医疗证号
                                                       App_No, --审批号
                                                       Procreate_Pcno, --生育保险患者电脑号
                                                       Si_Begindate, --参保日期
                                                       Si_State, --参保状态
                                                       Name, --姓名
                                                       Sex_Code, --性别
                                                       Idenno, --身份证号
                                                       Birthday, --生日
                                                       Empl_Type, --人员类别 1 在职 2 退休
                                                       Work_Name, --工作单位
                                                       Clinic_Diagnose, --门诊诊断
                                                       Dept_Code, --科室代码
                                                       Dept_Name, --科室名称
                                                       Paykind_Code, --结算类别 1-自费  2-保险 3-公费在职 4-公费退休 5-公费高干
                                                       Pact_Code, --合同代码
                                                       Pact_Name, --合同单位名称
                                                       Bed_No, --床号
                                                       In_Date, --入院日期
                                                       In_Diagnose, --入院诊断代码
                                                       In_Diagnosename, --入院诊断名称
                                                       Out_Date, --出院日期
                                                       Out_Diagnose, --出院诊断代码
                                                       Out_Diagnosename, --出院诊断名称
                                                       Balance_Date, --结算日期(上次)
                                                       Tot_Cost, --费用金额(未结)(住院总金额)
                                                       Pay_Cost, --帐户支付
                                                       Pub_Cost, --公费金额(未结)(社保支付金额)
                                                       Item_Paycost, --部分项目自付金额
                                                       Base_Cost, --个人起付金额
                                                       Item_Paycost2, --个人自费项目金额
                                                       Item_Ylcost, --个人自付金额（乙类自付部分）
                                                       Own_Cost, --个人自负金额
                                                       Overtake_Owncost, --超统筹支付限额个人自付金额
                                                       Own_Cause, --自费原因
                                                       Oper_Code, --操作员
                                                       Oper_Date, --操作日期
                                                       Reg_No,
                                                       Fee_Times,
                                                       Hos_Cost,
                                                       Year_Cost,
                                                       Valid_Flag,
                                                       Balance_State,
                                                       Remark,
                                                       Type_Code,
                                                       Person_Type,
                                                       Primarydiagnosecode, --20081226ADD
                                                       Operatecode1,
                                                       Operatecode2,
                                                       Operatecode3,
                                                       Primarydiagnosename
                                                  From Fin_Ipr_Siinmaininfo --医保信息住院主表
                                                 Where Inpatient_No = '{0}'
                                                   And Type_Code = '1'
                                                   And Balance_No = '{1}'
                                                ";

        #endregion

        #region 通用业务

        #region {D5386B6C-2CA5-4929-839B-AB970ADB254D}
        /// <summary>
        /// 查询医保统计编码
        /// </summary>
        public static string GetCenterStatSQL = @"select a.center_statcode
                                                   from FIN_COM_FEECODESTAT a
                                                   where
                                                   a.report_code = '{0}' and a.fee_code='{1}'"; 
        #endregion
        /// <summary>
        /// 得到最大结算序号
        /// </summary>
        public static string GetBalanceNOSQL = @"select max(to_number(BALANCE_NO))
			                                        from fin_ipr_siinmaininfo
			                                        where  inpatient_no = '{0}'";

        /// <summary>
        /// 更新记录为无效
        /// </summary>
        public static string UpdateToUnValidSQL = @"update  FIN_IPR_SIINMAININFO a 
                                                   set a.valid_flag = '0'
                                                   where inpatient_no = '{0}' and  INVOICE_NO = '{1}' 
                                                   and type_code = '{2}' and VALID_FLAG = '1'";

        /// <summary>
        /// 获取医疗类别
        /// </summary>
        public static string GetMedcareTypeSQL = @"select a.medical_type  from FIN_IPR_SIINMAININFO a 
                                                   where inpatient_no = '{0}' and  INVOICE_NO = '{1}' 
                                                   and type_code = '{2}' and VALID_FLAG = '1' ";

        /// <summary>
        /// 更新交易类别
        /// </summary>
        public static string UpdateTransTypeSQL = @"update fin_ipr_siinmaininfo a
                                                    set a.trans_type = '{0}'
                                                    where a.inpatient_no = '{1}' and a.balance_no = '{2}'";


        /// <summary>
        /// 更新备注段
        /// </summary>
        public static string UpdateRemarkInfoSQL = @"update fin_ipr_siinmaininfo a
                                                    set a.remark = '{0}'
                                                    where a.inpatient_no = '{1}' and a.BALANCE_STATE = '0'
                                                       and a.type_code = '2'";

        /// <summary>
        /// 更新上传标志
        /// </summary>
        public static string UpdateUploadFlagSQL = @"update fin_ipb_itemlist a
                                                    set a.upload_flag = '1'
                                                    where a.recipe_no = '{0}' 
                                                    and a.sequence_no = '{1}' 
                                                    and a.trans_type = '{2}'";
        #region 诊断相关

        /// <summary>
        /// 获取识别码
        /// </summary>
        public static  string GetPDiagnoseSQL = "SELECT t.aka120,t.aka121,t.aka066,t.zka002 from view_ka06 t\n";

        /// <summary>
        /// 获取主诊断（所有）
        /// </summary>
        public static  string GetDiagnoseALLSQL = @"select 
                                                    T.aka120,
                                                    T.aka121,
                                                    T.aka122,
                                                    fun_get_querycode(T.aka066,0),
                                                    T.zka004,
                                                    T.aae035,
                                                    T.ckc295 
                                                    from view_ka19 t order by to_number(t.zka004)";
        /// <summary>
        /// 获取手术码
        /// </summary>
        public static  string GetOperationDiagnoseSQL = @"select T.AKA120,t.aka121,t.aka066 from view_ka20 t";


        /// <summary>
        /// 更新住院患者出院诊断信息
        /// </summary>
        #region {98485611-DADE-4b4f-8DA5-E1827DD4191D}
        //        public static string UpdateInpatientOutDiagnosInfo = @"Update Fin_Ipr_Siinmaininfo t
        //                                                            Set t.Out_Diagnose = '{0}' --主码
        //                                                                ,t.Out_Diagnosename = '{1}' 
        //                                                                ,t.Primarydiagnosecode= '{2}'
        //                                                                ,t.Primarydiagnosename = '{3}'
        //                                                                ,t.Operatecode1 = '{4}'
        //                                                                ,t.Operatecode2 = '{5}'
        //                                                                ,t.Operatecode3 = '{6}'
        //                                                                ,t.Out_Date = sysdate
        //                                                            Where t.Inpatient_No = '{7}'
        //                                                                  And t.Balance_state = '0'
        //                                                                  And t.Type_Code = '2'
        //                                                                ";
        public static string UpdateInpatientOutDiagnosInfo = @"Update Fin_Ipr_Siinmaininfo t
                                                            Set t.Out_Diagnose = '{0}' --主码
                                                                ,t.Out_Diagnosename = '{1}' 
                                                                ,t.Primarydiagnosecode= '{2}'
                                                                ,t.Primarydiagnosename = '{3}'
                                                                ,t.Operatecode1 = '{4}'
                                                                ,t.Operatecode2 = '{5}'
                                                                ,t.Operatecode3 = '{6}'
                                                                ,t.Out_Date = sysdate
                                                            Where t.Inpatient_No = '{7}'
                                                                  And t.DIAGNOSE_OPER_CODE = '{8}'
                                                                  And t.Balance_state = '0'
                                                                  And t.Type_Code = '2'
                                                                "; 
        #endregion
        #endregion

        #endregion

        #region 河南省保

        /// <summary>
        /// 医保住院号
        /// </summary>
        public static string GetInPatientNOSI = @"select seq_si_inpatientno.nextval from dual";

        /// <summary>
        /// 医保门诊号
        /// </summary>
        public static string GetOutPatientNOSI = @"select seq_si_outpatientno.nextval from dual";

        /// <summary>
        /// 住院非药品
        /// </summary>
        public static string GetFeeItemsForInpatientWhere1 = @"
where  inpatient_no = '{0}'
        and balance_state='0'
        and pact_code = '{1}'
AND fee_date >= to_date('{2}','YYYY-MM-DD hh24:mi:ss')
and fee_date <= to_date('{3}','yyyy-mm-dd hh24:mi:ss')
and upload_flag like '{4}' 
and tot_cost <> 0
   order by  fee_date";

        /// <summary>
        /// 住院非药品全部
        /// </summary>
        public static string SelectAllFromFeeItem1 = @"
SELECT recipe_no, --处方号
       sequence_no, --处方内项目流水号
       trans_type, --交易类型,1正交易，2反交易
       inpatient_no, --住院流水号
       name, --姓名
       paykind_code, --结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
       pact_code, --合同单位
       update_sequenceno, --更新库存的流水号(物资)
       inhos_deptcode, --在院科室代码
       nurse_cell_code, --护士站代码
       recipe_deptcode, --开立科室代码
       execute_deptcode, --执行科室代码
       stock_deptcode, --扣库科室代码
       recipe_doccode, --开立医师代码
       item_code, --项目代码
       fee_code, --最小费用代码
       center_code, --中心代码
       item_name, --项目名称
       unit_price, --单价
       qty, --数量
       current_unit, --当前单位
       package_code, --组套代码
       package_name, --组套名称
       tot_cost, --费用金额
       own_cost, --自费金额
       pay_cost, --自付金额
       pub_cost, --公费金额
       eco_cost, --优惠金额
       sendmat_sequence, --出库单序列号
       send_flag, --发放状态（0 划价 2发放（执行） 1 批费）
       baby_flag, --是否婴儿用 0 不是 1 是
       jzqj_flag, --急诊抢救标志
       brought_flag, --出院带疗标记 0 否 1 是
       invoice_no, --结算发票号
       balance_no, --结算序号
       apprno, --审批号
       charge_opercode, --划价人
       charge_date, --划价日期
       confirm_num, --已确认数
       machine_no, --设备号
       exec_opercode, --执行人代码
       exec_date, --执行日期
       fee_opercode, --计费人
       fee_date, --计费日期
       check_opercode, --审核人
       check_no, --审核序号
       mo_order, --医嘱流水号
       mo_exec_sqn, --医嘱执行单流水号
       NOBACK_NUM,
       balance_state,
       fee_rate,
       FEEOPER_DEPTCODE,
       EXT_FLAG, --扩展标记
       EXT_FLAG1, --扩展标记1
       EXT_FLAG2, --扩展标记2
       EXT_CODE, --扩展编码
       EXT_OPERCODE, --扩展人员编码
       EXT_DATE, --扩展日期
       ITEM_FLAG, --0非药品 2物资  
       EXT_FLAG3 --扩展标记3 原处方号退费用
  FROM fin_ipb_itemlist --住院非药品明细表

";

        /// <summary>
        /// 住院药品
        /// </summary>
        public static string GetMedItemsForInpatientWhere1 = @"
where  inpatient_no = '{0}'
        and balance_state='0'
        and pact_code = '{1}'
AND fee_date >= to_date('{2}','YYYY-MM-DD hh24:mi:ss')
and fee_date <= to_date('{3}','yyyy-mm-dd hh24:mi:ss')
and upload_flag like '{4}' 
and tot_cost <> 0
   order by  fee_date";

        /// <summary>
        /// 住院药品全部
        /// </summary>
        public static string SelectAllFromMedItem1 = @"

SELECT recipe_no, --处方号
       sequence_no, --处方内项目流水号
       trans_type, --交易类型,1正交易，2反交易
       inpatient_no, --住院流水号
       name, --姓名
       paykind_code, --结算类别 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
       pact_code, --合同单位
       update_sequenceno, --更新库存的流水号  ---------7
       inhos_deptcode, --在院科室代码
       nurse_cell_code, --护士站代码
       recipe_deptcode, --开立科室代码
       execute_deptcode, --执行科室代码
       medicine_deptcode, --取药科室代码
       recipe_doccode, --开立医师代码
       drug_code, --药品编码
       fee_code, --最小费用代码
       center_code, --医疗中心项目代码
       drug_name, --药品名称-----------------------17
       unit_price, --单价
       qty, --数量
       current_unit, --当前单位
       pack_qty, --包装数---------------------------
       days, --付数----------------------------
       tot_cost, --费用金额
       own_cost, --自费金额
       pay_cost, --自付金额
       pub_cost, --公费金额
       eco_cost, --优惠金额
       senddrug_sequence, --发药单序列号
       senddrug_flag, --发药状态（0 划价 2摆药 1批费）
       baby_flag, --是否婴儿用药 0 不是 1 是
       jzqj_flag, --急诊抢救标志
       brought_flag, --出院带药标记 0 否 1 是
       invoice_no, --结算发票号
       balance_no, --结算序号
       apprno, --审批号
       charge_opercode, --划价人
       charge_date, --划价日期---------------------------37
       home_made_flag, --自制标识---------
       drug_quality, --药品性质-----------
       senddrug_opercode, --发药人
       senddrug_date, --发药日期
       fee_opercode, --计费人
       fee_date, --计费时间
       check_opercode, --审核人
       check_no, --审核序号
       mo_order, --医嘱流水号
       mo_exec_sqn, --医嘱执行单流水号
       specs, --规格---------------
       drug_type, --药品类别----------------
       NOBACK_NUM,
       balance_state,
       fee_rate,
       FEEOPER_DEPTCODE,
       EXT_FLAG, --扩展标记
       EXT_FLAG1, --扩展标记1
       EXT_FLAG2, --扩展标记2
       EXT_CODE, --扩展编码
       EXT_OPERCODE, --扩展人员编码
       EXT_DATE, --扩展日期
       EXT_FLAG3 --扩展标记3 原处方号 退费时用
  FROM fin_ipb_medicinelist --住院药品明细

";
        /// <summary>
        /// 医保诊断
        /// </summary>
        public static string GetDiagnose = @"
select a.seq_id,
a.icd_code,
a.icd_name,
a.icd_spell 
from MET_COM_ICDMEDICARE a
";
        #endregion

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ShenYangCitySI
{
    /// <summary>
    /// [功能描述: 医保动态库函数申明类]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-10-12]<br></br>
    /// 修改记录
    /// 修改人='牛鑫元'
    ///	修改时间=''
    ///	修改目的='丰富医保信息'
    ///	修改描述=''
    ///  >
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// 动态库初始化方法
        /// </summary>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int InitDLL();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int CommitTrans();

        /// <summary>
        /// 事务回滚
        /// </summary>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int RollbackTrans();

        /// <summary>
        /// 读卡获取各种信息
        /// </summary>
        /// <param name="readType"></param>
        /// <param name="dataBuffer"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int ReadCard(int readType, StringBuilder dataBuffer);
       
        /// <summary>
        /// 待遇资格审核
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="SINumber"></param>
        /// <param name="unitNumber"></param>
        /// <param name="sysDate"></param>
        /// <param name="appCode"></param>
        /// <param name="dataBuffer"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int CheckMTQ(string cardNO, string SINumber, string unitNumber, string sysDate, int appCode, StringBuilder dataBuffer);

        /// <summary>
        /// 读取审批信息
        /// </summary>
        /// <param name="apprNO"></param>
        /// <param name="inHosNO"></param>
        /// <param name="apprType"></param>
        /// <param name="personNO"></param>
        /// <param name="PID"></param>
        /// <param name="Name"></param>
        /// <param name="sex"></param>
        /// <param name="personType"></param>
        /// <param name="unitNO"></param>
        /// <param name="doctorName"></param>
        /// <param name="diseaseNO"></param>
        /// <param name="diseaseName"></param>
        /// <param name="diagnostics"></param>
        /// <param name="itemNO"></param>
        /// <param name="itemName"></param>
        /// <param name="apprFlag"></param>
        /// <param name="reportDate"></param>
        /// <param name="apprPerson"></param>
        /// <param name="apprDate"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="transactor"></param>
        /// <param name="transDate"></param>
        /// <param name="remarks"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int GetApprInfo(string apprNO, StringBuilder inHosNO, StringBuilder apprType, StringBuilder personNO, StringBuilder PID,
            StringBuilder Name, StringBuilder sex, StringBuilder personType, StringBuilder unitNO, StringBuilder doctorName, StringBuilder diseaseNO,
            StringBuilder diseaseName, StringBuilder diagnostics, StringBuilder itemNO, StringBuilder itemName, StringBuilder apprFlag, StringBuilder reportDate,
            StringBuilder apprPerson, StringBuilder apprDate, StringBuilder startDate, StringBuilder endDate, StringBuilder transactor, StringBuilder transDate,
            StringBuilder remarks, StringBuilder errorMsg);

        /// <summary>
        /// 写审批信息
        /// </summary>
        /// <param name="apprNO"></param>
        /// <param name="inHosNO"></param>
        /// <param name="apprType"></param>
        /// <param name="personNO"></param>
        /// <param name="PID"></param>
        /// <param name="Name"></param>
        /// <param name="sex"></param>
        /// <param name="personType"></param>
        /// <param name="unitNO"></param>
        /// <param name="doctorName"></param>
        /// <param name="diseaseNO"></param>
        /// <param name="diseaseName"></param>
        /// <param name="diagnostics"></param>
        /// <param name="itemNO"></param>
        /// <param name="itemName"></param>
        /// <param name="apprFlag"></param>
        /// <param name="reportDate"></param>
        /// <param name="apprPerson"></param>
        /// <param name="apprDate"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="transactor"></param>
        /// <param name="transDate"></param>
        /// <param name="remarks"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int SetApprInfo(StringBuilder apprNO, string inHosNO, string apprType, string personNO, string PID,
            string Name, string sex, string personType, string unitNO, string doctorName, string diseaseNO,
            string diseaseName, string diagnostics, string itemNO, string itemName, string apprFlag, string reportDate,
            string apprPerson, string apprDate, string startDate, string endDate, string transactor, string transDate,
            string remarks, StringBuilder errorMsg);

        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="personAccountInfo"></param>
        /// <param name="transType"></param>
        /// <param name="medType"></param>
        /// <param name="billNO"></param>
        /// <param name="inHosNO"></param>
        /// <param name="sysDate"></param>
        /// <param name="userName"></param>
        /// <param name="diseaseNO"></param>
        /// <param name="diseaseName"></param>
        /// <param name="dataBuffer"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int Registration(string personAccountInfo, int transType, string medType, string billNO, 
            string inHosNO, string sysDate, string userName, string diseaseNO, string diseaseName, StringBuilder dataBuffer);
        
        /// <summary>
        ///住院登记 
        /// </summary>
        /// <param name="regType">登记类型  0 入院登记 1 出院登记</param>
        /// <param name="transType">交易类型 1正交易 -1  反交易</param>
        /// <param name="inHosNO">住院号</param>
        /// <param name="medType">医疗类别21-普通住院 22--转入医院 25--家庭病床42--生育住院43--节育住院45—生育转入住院</param>
        /// <param name="treatDate">入院日期</param>
        /// <param name="leaveHosDt">出院日期</param>
        /// <param name="diseaseName">入院疾病名称</param>
        /// <param name="diseaseNO">入院疾病编码(医保中心提供的编码信息)</param>
        /// <param name="LHDiseaseName">出院疾病名称</param>
        /// <param name="LHDiseaseNO">出院疾病编码(医保中心提供的编码信息</param>
        /// <param name="transactor">经办人</param>
        /// <param name="transDate">经办日期</param>
        /// <param name="billNO">出院原因(医保中心给代码)</param>
        /// <param name="errorMsg">出错信息</param>
        /// <returns>成功 0 失败 -1</returns>
        [DllImport("DBLib.dll")]
        public static extern int TreatInfoEntry(int regType, int transType, string inHosNO, string medType, string treatDate, 
            string leaveHosDt, string diseaseName, string diseaseNO, string LHDiseaseName, string LHDiseaseNO, 
            string transactor, string transDate, string billNO, StringBuilder errorMsg);

        /// <summary>
        /// 费用明细录入及其修改
        /// </summary>
        /// <param name="inHosNO">门诊号(住院号)</param>
        /// <param name="billNO">单据号</param>
        /// <param name="internalCode">收费项目医院内编码码</param>
        /// <param name="formularyNO">处方号</param>
        /// <param name="sysDate">开方日期</param>
        /// <param name="centerCode">收费项目医保中心编码</param>
        /// <param name="itemName">收费项目名称</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="quantity">数量</param>
        /// <param name="Amount">金额</param>
        /// <param name="doseType">剂型</param>
        /// <param name="dosage">剂量</param>
        /// <param name="frequency">频次</param>
        /// <param name="usage">用法</param>
        /// <param name="KeBie">科别名称</param>
        /// <param name="execDays">执行天数</param>
        /// <param name="feeType">医保中心收费类别</param>
        /// <param name="selfPayInd">1全额自费0不自费</param>
        /// <param name="ErrorMsg">出错信息</param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int FormularyEntry(string inHosNO, string billNO, string internalCode, string formularyNO, 
            string sysDate, string centerCode, string itemName, double unitPrice, int quantity, double Amount, string doseType, 
            string dosage, string frequency, string usage, string KeBie, int execDays, string feeType, ref int selfPayInd, 
            StringBuilder ErrorMsg);

        /// <summary>
        /// 医保病人预结算
        /// </summary>
        /// <param name="calcType">结算类别（1、出院结算2、中途结算）</param>
        /// <param name="medType">医疗类别(NOTNULL)—11–普通门诊12--特殊门诊(规定病种或门诊慢性病)41-生育门诊43-节育门诊21-住院,22--转入医院24--特殊住院25--家庭病床42--生育住院43--节育住院45—生育转入住院</param>
        /// <param name="inHosNO">住院号（门诊号）(NOTNULL)</param>
        /// <param name="personAccountInfo">个人及其帐户信息(各项数据由管道分隔符’|’隔开)</param>
        /// <param name="sysDate">系统时间(NOTNULL)</param>
        /// <param name="diseaseNO">诊断代码(主要用于门诊特殊病种)</param>
        /// <param name="diseaseName">诊断名称(主要用于门诊特殊病种)</param>
        /// <param name="sreimflag">生育结算标志0不结算1结算</param>
        /// <param name="DataBuffer">结算结果(结算执行成功)或出错原因(结算执行失败)</param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int PreExpenseCalc(string calcType, string medType, string inHosNO, string personAccountInfo, 
            string sysDate, string diseaseNO, string diseaseName, int sreimflag, StringBuilder dataBuffer);

        /// <summary>
        /// 医保患者结算
        /// </summary>
        /// <param name="transType">交易类型——-1反交易(退费)1正常交易；(NOTNULL)</param>
        /// <param name="calcType">结算类别（1、出院(门诊)结算2、中途结算</param>
        /// <param name="medType">医疗类别(NOTNULL)—11–普通门诊12--特殊门诊(规定病种或门诊慢性病)13—非定点医疗机构急诊41-生育门诊43-节育门诊21---住院22--转入医院24--特殊住院25--家庭病床26–异地急诊42--生育住院43--节育住院45—生育转入住院</param>
        /// <param name="inHosNO">住院号（门诊号）(NOTNULL)</param>
        /// <param name="billNO">单据号(发票号)(NOTNULL)</param>
        /// <param name="personAccountInfo">个人及其帐户信息(各项数据由管道分隔符’|’隔开)</param>
        /// <param name="userName">操作员姓名</param>
        /// <param name="sysDate">系统时间(NOTNULL)</param>
        /// <param name="diseaseNO">诊断代码(主要用于门诊特殊病种)</param>
        /// <param name="diseaseName">诊断名称(主要用于门诊特殊病种)</param>
        /// <param name="sreimflag">生育结算标志0不结算1结算</param>
        /// <param name="dataBuffer"></param>
        /// <returns>结算结果(结算执行成功)或出错原因(结算执行失败)</returns>
        [DllImport("DBLib.dll")]
        public static extern int ExpenseCalc(int transType, string calcType, string medType, string inHosNO, string billNO, 
             string personAccountInfo, string userName, string sysDate, string diseaseNO, string diseaseName, int sreimflag, StringBuilder dataBuffer);

        /// <summary>
        /// 生育审批申请
        /// </summary>
        /// <param name="operType"></param>
        /// <param name="inputString"></param>
        /// <param name="DataBuffer"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int Bussiness(string operType, string inputString,  string DataBuffer);

        /// <summary>
        /// 更新单据号(发票号)
        /// </summary>
        /// <param name="operType"></param>
        /// <param name="inputString"></param>
        /// <param name="DataBuffer"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int UpdateInvoiceNo(ref string origInvoiceNO, ref string newInvoiceNO, ref string transactor, ref string transDate, 
            ref int appCode, ref string dataBuffer);

        /// <summary>
        /// 字符串分解函数
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        [DllImport("DBLib.dll")]
        public static extern int GetPosValue(int pos, string sourceString);

        [DllImport("DBLib.dll")]
        public static extern int OpenCOM();

        [DllImport("DBLib.dll")]
        public static extern int ReleaseCOM();

    }
}

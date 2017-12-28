using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizProcess.Integrate.Registration
{
    public class Registration : IntegrateBase
    {
        public Registration()
        {
        }

        /// <summary>
        /// 挂号管理业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Registration.Register registerManager = new Neusoft.HISFC.BizLogic.Registration.Register();

        protected Neusoft.HISFC.BizLogic.Registration.DoctSchema docs = new Neusoft.HISFC.BizLogic.Registration.DoctSchema();

        /// <summary>
        /// 挂号级别业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Registration.RegLevel regLevelManager = new Neusoft.HISFC.BizLogic.Registration.RegLevel();

        /// <summary>
        /// 挂号级别业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Registration.RegLvlFee regLvlFeeManager = new Neusoft.HISFC.BizLogic.Registration.RegLvlFee();
        /// <summary>
        /// 分诊队列业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Nurse.Assign assingManager = new Neusoft.HISFC.BizLogic.Nurse.Assign();

        protected Neusoft.HISFC.BizLogic.Registration.Noon noonManager = new Neusoft.HISFC.BizLogic.Registration.Noon();
       
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans = trans;
            docs.SetTrans(trans);
            registerManager.SetTrans(trans);
            regLvlFeeManager.SetTrans(trans);
            regLevelManager.SetTrans(trans);
            assingManager.SetTrans(trans);
            noonManager.SetTrans(trans);
        }

        public ArrayList Query()
        {
            this.SetDB(docs);
            return docs.Query();
        }

        /// <summary>
        /// 获取所有有效的挂号级别
        /// </summary>
        /// <returns>成功 所有有效的挂号级别集合 失败 null</returns>
        public ArrayList QueryRegLevel() 
        {
            this.SetDB(regLevelManager);

            return regLevelManager.Query(true);
        }

        /// <summary>
		/// 查询患者一段时间内挂的有效号
		/// </summary>
        /// <param name="cardNo"></param>
		/// <param name="limitDate"></param>
		/// <returns></returns>
        public ArrayList Query(string cardNo, DateTime limitDate)
        {
            this.SetDB(registerManager);
            return registerManager.Query(cardNo, limitDate);
        }
        /// <summary>
        ///更具住门诊流水号查询挂号信息
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(string clinicNO)
        {
            this.SetDB(registerManager);
            return registerManager.QueryPatient(clinicNO);
        }

        /// <summary>
        /// 查询患者一段时间未分诊的有效号
        /// </summary>
        /// <param name="cardNo">就诊卡号</param>
        /// <param name="limitDate">现号时间</param>
        /// <returns></returns>
        public ArrayList QueryUnionNurse(string cardNo, DateTime limitDate)
        {
            this.SetDB(registerManager);
            return registerManager.QueryUnionNurse(cardNo,limitDate);
        }

        /// <summary>
        /// 通过一段时间内 某护理站对应科室的挂号患者 addby sunxh
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="myNurseDept">护理站代码</param>
        /// <returns></returns>
        public ArrayList QueryNoTriagebyDept(DateTime begin, string myNurseDept)
        {
            this.SetDB(registerManager);
            return registerManager.QueryNoTriagebyDept(begin, myNurseDept);
        }

        /// <summary>
        /// 通过一段时间内 某护理站对应科室的挂号患者未看诊 addby sunxh
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="myNurseDept">护理站代码</param>
        /// <returns></returns>
        public ArrayList QueryNoTriagebyDeptUnSee(DateTime begin, string myNurseDept)
        {
            this.SetDB(registerManager);
            return registerManager.QueryNoTriagebyDeptUnSee(begin, myNurseDept);
        }
        
        /// <summary>
        /// 根据门诊号判断挂号信息是否分诊
        /// </summary>
        /// <param name="clinicNo"></param>
        /// <returns></returns>
        public bool QueryIsTriage(string clinicNo)
        {
            this.SetDB(registerManager);
            return registerManager.QueryIsTriage(clinicNo);
        }

        /// <summary>
        /// 根据门诊号判断挂号信息是否作废
        /// </summary>
        /// <param name="clinicNo"></param>
        /// <returns></returns>
        public bool QueryIsCancel(string clinicNo)
        {
            this.SetDB(registerManager);
            return registerManager.QueryIsCancel(clinicNo);
        }

        /// <summary>
        /// 置已分诊标志
        /// </summary>
        /// <param name="clinicID"></param>
        /// <param name="operID"></param>
        /// <param name="operDate"></param>
        /// <returns></returns>
        public int Update(string clinicID, string operID, DateTime operDate)
        {
            this.SetDB(registerManager);
            return registerManager.Update(clinicID, operID, operDate);
        }

        /// <summary>
        /// 取消分诊状态
        /// </summary>
        /// <param name="clinicID"></param>
        /// <returns></returns>
        public int CancelTriage(string clinicID)
        {
            this.SetDB(registerManager);
            return registerManager.CancelTriage(clinicID);
        }

        /// <summary>
        /// 通过门诊卡号查询一段时间内的合法的挂号患者
        /// </summary>
        /// <param name="cardNO">卡号</param>
        /// <param name="limitDate">有效的截至时间</param>
        /// <returns>成功 返回挂号患者的集合 失败 返回 null 没有查找到数据返回 ArrayList.Count == 0</returns>
        public ArrayList QueryValidPatientsByCardNO(string cardNO, DateTime limitDate)
        {
            this.SetDB(registerManager);

            return registerManager.Query(cardNO, limitDate);
        }

        /// <summary>
        /// 通过看诊序号查询一段时间内的合法的挂号患者
        /// </summary>
        /// <param name="seeNO">看诊序号</param>
        /// <param name="limitDate">有效的截至时间</param>
        /// <returns>成功 返回挂号患者的集合 失败 返回 null 没有查找到数据返回 ArrayList.Count == 0</returns>
        public ArrayList QueryValidPatientsBySeeNO(string seeNO, DateTime limitDate)
        {
            this.SetDB(registerManager);

            return registerManager.QueryBySeeNo(seeNO, limitDate);
        }

        /// <summary>
        /// 通过姓名合法的挂号患者
        /// </summary>
        /// <param name="name">患者姓名</param>
        /// <returns>成功 返回挂号患者的集合 失败 返回 null 没有查找到数据返回 ArrayList.Count == 0</returns>
        public ArrayList QueryValidPatientsByName(string name)
        {
            this.SetDB(registerManager);

            return registerManager.QueryByName(name);
        }

        /// <summary>
        /// 通过合同单位,和挂号级别获得挂号费
        /// </summary>
        /// <param name="pactCode">合同单位编码</param>
        /// <param name="regLevel">挂号级别</param>
        /// <returns>成功 挂号费实体 失败 null</returns>
        public Neusoft.HISFC.Models.Registration.RegLvlFee GetRegLevelByPactCode(string pactCode, string regLevel) 
        {
            this.SetDB(regLvlFeeManager);

            return regLvlFeeManager.Get(pactCode, regLevel);
        }

        /// <summary>
		/// 按门诊号查询挂号信息
		/// </summary>
		/// <param name="clinicNo"></param>
		/// <returns></returns>
        public Neusoft.HISFC.Models.Registration.Register GetByClinic(string clinicNo)
        {
            this.SetDB(registerManager);
            return registerManager.GetByClinic(clinicNo);
        }
       


        #region 门诊医生站使用的add by sunm

        /// <summary>
        /// 按挂号医生查询某一段时间内挂的有效号
        /// </summary>
        /// <param name="doctID">医生编码</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSee"></param>
        /// <returns></returns>
        public ArrayList QueryByDoct(string doctID, DateTime beginDate, DateTime endDate, bool isSee)
        {
            this.SetDB(registerManager);
            return registerManager.QueryByDoct(doctID, beginDate, endDate, isSee);
        }

        /// <summary>
        /// 按挂号科室查询某一段时间内挂的有效号
        /// </summary>
        /// <param name="deptID">科室编码</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSee"></param>
        /// <returns></returns>
        public ArrayList QueryByDept(string deptID, DateTime beginDate, DateTime endDate, bool isSee)
        {
            this.SetDB(registerManager);
            return registerManager.QueryByDept(deptID, beginDate, endDate, isSee);
        }

        /// <summary>
        /// 按看诊医生查询某一段时间内挂的有效号
        /// </summary>
        /// <param name="docID">医生编码</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSee"></param>
        /// <returns></returns>
        public ArrayList QueryBySeeDoc(string docID, DateTime beginDate, DateTime endDate, bool isSee)
        {
            this.SetDB(registerManager);
            return registerManager.QueryBySeeDoc(docID, beginDate, endDate, isSee);
        }

        /// <summary>
        /// 查询一条挂号级别
        /// </summary>
        /// <param name="regLevelCode"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Registration.RegLevel QueryRegLevelByCode(string regLevelCode)
        {
            this.SetDB(regLevelManager);
            return regLevelManager.Query(regLevelCode);
        }

        /// <summary>
        /// 更新看诊科室
        /// </summary>
        /// <param name="clinicID"></param>
        /// <param name="seeDeptID"></param>
        /// <param name="seeDoctID"></param>
        /// <returns></returns>
        public int UpdateDept(string clinicID, string seeDeptID, string seeDoctID)
        {
            this.SetDB(registerManager);
            return registerManager.UpdateDept(clinicID, seeDeptID, seeDoctID);
        }

        /// <summary>
        /// 更新看诊
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        public int UpdateSeeDone(string clinicNO)
        {
            this.SetDB(registerManager);
            return registerManager.UpdateSeeDone(clinicNO);
        }

        /// <summary>
        /// 插入一条挂号记录
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public int InsertByDoct(Neusoft.HISFC.Models.Registration.Register reg)
        {
            this.SetDB(registerManager);
            return registerManager.Insert(reg);
        }

        /// <summary>
        /// 按看诊医生看诊时间查询某一段时间内的有效号
        /// </summary>
        /// <param name="docID">医生编码</param>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isSee"></param>
        /// <returns></returns>
        public ArrayList QueryBySeeDocAndSeeDate(string docID, DateTime beginDate, DateTime endDate, bool isSee)
        {
            this.SetDB(registerManager);
            return registerManager.QueryBySeeDocAndSeeDate(docID, beginDate, endDate, isSee);
        }
        /// <summary>
        /// 根据门诊号判断患者是否在分诊队列中
        /// </summary>
        /// <param name="clinicNo">门诊号</param>
        /// <returns>大于等于1：分诊队列中有患者  0： 没有  -1:查询出错</returns>
        public int JudgeInQueue(string clinicNo)
        {
            this.SetDB(assingManager);
            return assingManager.JudgeInQueue(clinicNo);
        }

        #endregion


        #region 按护士站和在院状态查询急诊留观患者
        #endregion
        /// <summary>
        /// 按护士站和在院状态查询急诊留观患者
        /// </summary>
        /// <param name="nursecellcode">护士站代码</param>
        /// <param name="status">急诊留观人员状态</param>
        /// <returns>null为错</returns>
        public ArrayList PatientQueryByNurseCell(string nursecellcode, string status)
        {
            this.SetDB(registerManager);
            return registerManager.PatientQueryByNurseCell(nursecellcode, status); 
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 医生站加载留观患者
        /// </summary>
        /// <param name="nursecellcode">护士站代码</param>
        /// <param name="status">急诊留观人员状态</param>
        /// <returns>null为错</returns>
        public ArrayList PatientQueryByNurseCell(string deptCode)
        {
            this.SetDB(registerManager);
            return registerManager.PatientQueryByNurseCell(deptCode);
        }
        

        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
        #region 账户新增
        //账户流程 医生站收挂号费，置挂号费收费状态 
        /// <summary>
        /// 置已收挂号费标志
        /// </summary>
        /// <param name="clinicID"></param>
        /// <param name="operID"></param>
        /// <param name="operDate"></param>
        /// <returns></returns>
        public int UpdateAccountFeeState(string clinicID, string operID,string dept , DateTime operDate)
        {
            this.SetDB(registerManager);
            return registerManager.UpdateAccountFeeState(clinicID, operID,dept, operDate);
        }

        /// <summary>
        /// 根据病历号查询已看诊的有效挂号信息
        /// </summary>
        /// <param name="cardNO">病历号</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结算时间</param>
        public ArrayList GetRegisterByCardNODate(string cardNO, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(registerManager);
            return registerManager.GetRegisterByCardNODate(cardNO, beginDate, endDate);
        }

        /// <summary>
        /// 插入挂号记录表{E43E0363-0B22-4d2a-A56A-455CFB7CF211}
		/// </summary>
		/// <param name="register"></param>
		/// <returns></returns>
        public int Insert(Neusoft.HISFC.Models.Registration.Register register)
        {
            this.SetDB(registerManager);
            return registerManager.Insert(register);
        }


        /// <summary>
        /// 查询午别
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryNoon()
        {
            this.SetDB(noonManager);
            return noonManager.Query();
        }

        /// <summary>
		/// 更新看诊序号
		/// </summary>
		/// <param name="Type">1医生 2科室 4全院</param>
		/// <param name="seeDate">看诊日期</param>
		/// <param name="Subject">Type=1时,医生代码;Type=2,科室代码;Type=4,ALL</param>
		/// <param name="noonID">午别</param>
		/// <returns></returns>
        public int UpdateSeeNo(string Type, DateTime seeDate, string Subject, string noonID)
        {
            this.SetDB(registerManager);
            return registerManager.UpdateSeeNo(Type, seeDate, Subject, noonID);
        }

        /// <summary>
		/// 获得患者看诊序号
		/// </summary>
		/// <param name="Type">Type:1专家序号、2科室序号、4全院序号</param>
		/// <param name="current">看诊日期</param>
		/// <param name="subject">Type=1时,医生代码;Type=2,科室代码;Type=4,ALL</param>
		/// <param name="noonID">午别</param>
		/// <param name="seeNo">当前看诊号</param>
		/// <returns></returns>
        public int GetSeeNo(string Type, DateTime current, string subject, string noonID, ref int seeNo)
        {
            this.SetDB(registerManager);
            return registerManager.GetSeeNo(Type, current, subject, noonID, ref seeNo);
        }
        #endregion


    }
    ///// <summary>
    ///// 挂号票打印 统一放到HISFC.BizProcess.Interface下
    ///// </summary>
    //public interface IRegPrint
    //{
    //     ///<summary>
    //     ///数据库连接
    //     ///</summary>
    //    System.Data.IDbTransaction Trans
    //    {
    //        get;
    //        set;
    //    }
    //    /// <summary>
    //    /// 添值
    //    /// </summary>
    //    /// <param name="register"></param>
    //    /// <param name="reglvlfee"></param>
    //    /// <returns></returns>

    //    int SetPrintValue(Neusoft.HISFC.Models.Registration.Register register);

    //    /// <summary>
    //    /// 打印预览
    //    /// </summary>
    //    /// <returns>>成功 1 失败 -1</returns>
    //    int PrintView();
    //    /// <summary>
    //   /// 打印
    //   /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>

    //    int Print();

    //    /// <summary>
    //    /// 清空当前信息
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int Clear();

    //    /// <summary>
    //    /// 设置本地数据库连接
    //    /// </summary>
    //    /// <param name="trans">数据库连接</param>
    //    void SetTrans(System.Data.IDbTransaction trans);
    //}
    ///// <summary>
    ///// 挂号票打印
    ///// </summary>
    //public interface IShowLED
    //{
    //    ///<summary>
    //    ///数据库连接
    //    ///</summary>
    //    //System.Data.IDbTransaction Trans
    //    //{
    //    //    get;
    //    //    set;
    //    //}
    //    /// <summary>
    //    /// 查找
    //    /// </summary>
    //    /// <param name="register"></param>
    //    /// <param name="reglvlfee"></param>
    //    /// <returns></returns>

    //    string  Query();

      
    //    /// <summary>
    //    /// 显示farpoint格式
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>

    //    int SetFPFormat();

    //    /// <summary>
    //    ///  调用LED 接口 组成显示串给LED
    //    /// </summary>
    //    /// <returns>成功 1 失败 -1</returns>
    //    int CreateString();

    //    /// <summary>
    //    /// 设置本地数据库连接
    //    /// </summary>
    //    /// <param name="trans">数据库连接</param>
    //    //void SetTrans(System.Data.IDbTransaction trans);
    //}
}

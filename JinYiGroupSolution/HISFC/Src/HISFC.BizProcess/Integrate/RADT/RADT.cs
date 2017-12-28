using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Neusoft.HISFC.BizLogic.RADT;
using System.Windows.Forms;
namespace Neusoft.HISFC.BizProcess.Integrate
{
    /// <summary>
    /// [功能描述: 整合的入出转管理类]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class RADT : IntegrateBase
    {
        /// <summary>
        /// 入出转业务层
        /// </summary>
        protected InPatient radtManager = new InPatient();
        protected OutPatient radtEmrManager = new OutPatient();

       

        /// <summary>
        /// 费用业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        protected Neusoft.HISFC.BizLogic.Manager.Bed managerBed = new Neusoft.HISFC.BizLogic.Manager.Bed();

        protected Neusoft.HISFC.BizLogic.Order.Order managerOrder = new Neusoft.HISFC.BizLogic.Order.Order();

        protected Neusoft.HISFC.BizLogic.Manager.Department managerDepartment = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 入出转业务层
        /// </summary>
        protected Neusoft.HISFC.BizLogic.RADT.InPatient inPatienMgr = new Neusoft.HISFC.BizLogic.RADT.InPatient();

        protected Neusoft.HISFC.BizLogic.RADT.LifeCharacter lfchManagement = new Neusoft.HISFC.BizLogic.RADT.LifeCharacter();

        protected Neusoft.HISFC.BizLogic.RADT.InpatientDayReport indrManager = new InpatientDayReport();

        private bool quitFeeApplyFlag = true;
        /// <summary>
        /// 有退费申请是否允许出院登记
        /// </summary>
        public bool QuitFeeApplyFlag
        {
            get
            {
                return quitFeeApplyFlag;
            }
            set
            {
                quitFeeApplyFlag = value;
            }
        }
        

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="trans">数据库事务</param>
        public override void SetTrans(System.Data.IDbTransaction trans)
        {
            radtManager.SetTrans(trans);
            radtEmrManager.SetTrans(trans);
            inpatientManager.SetTrans(trans);
            managerBed.SetTrans(trans);
            managerDepartment.SetTrans(trans);
            managerOrder.SetTrans(trans);
            lfchManagement.SetTrans(trans);
            inPatienMgr.SetTrans(trans);
            this.trans = trans;
        }

        #region 方法

       

        /// <summary>
        /// 自动生成住院号
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 失败: -1</returns>
        public int CreateAutoInpatientNO(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            this.SetDB(radtManager);

            if (radtManager.AutoCreatePatientNO(patient) == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 自动生成住院号
        /// </summary>
        /// <param name="patientNO">当前住院号</param>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 失败: -1</returns>
        public int CreateAutoInpatientNO(string patientNO, ref Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.SetDB(radtManager);

            if (radtManager.AutoCreatePatientNO(patientNO, ref patient) == -1)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 通过门诊卡号信息获得最大住院流水号
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns>成功: 获得最大住院流水号 失败 :null </returns>
        public string GetMaxPatientNOByCardNO(string cardNO) 
        {
            this.SetDB(radtManager);

            return radtManager.GetMaxPatientNOByCardNO(cardNO);
        }
        ///
        ///通过门诊号获取住院证信息
        /// <param name="cardNO">门诊号</param>
        /// <returns>成功:住院证信息 失败 null</returns>
        public Neusoft.HISFC.Models.RADT.InPatientProof QueryInPatientProofinfo(string clinicNO)
        {
            this.SetDB(radtManager);

            return radtManager.QueryInPatientProofinfo(clinicNO);
        }

        /// <summary>
        /// 通过门诊卡号在com_patientInfo中获得患者基本信息
        /// </summary>
        /// <param name="cardNO">门诊卡号</param>
        /// <returns>成功:患者基本信息 失败 null</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo QueryComPatientInfo(string cardNO) 
        {
            this.SetDB(radtManager);

            return radtManager.QueryComPatientInfo(cardNO);
        }

        //{971E891B-4E05-42c9-8C7A-98E13996AA17}
        /// <summary>
        /// 通过身份证号在com_patientInfo中获得患者基本信息
        /// </summary>
        /// <param name="IDNO">身份证号卡号</param>
        /// <returns>成功:患者基本信息 失败 null</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo QueryComPatientInfoByIDNO(string IDNO)
        {
            this.SetDB(radtManager);

            return radtManager.QueryComPatientInfoByIDNO(IDNO);
        }

        /// <summary>
        /// 获得患者婴儿
        /// </summary>
        /// <param name="inpatientNO">妈妈住院流水号</param>
        /// <returns></returns>
        public ArrayList QueryBabiesByMother(string inpatientNO) 
        {
            this.SetDB(radtManager);

            return radtManager.QueryBabiesByMother(inpatientNO);
        }

        /// <summary>
        /// 通过医保卡号在com_patientInfo中获得患者基本信息
        /// </summary>
        /// <param name="cardNO">医保卡号</param>
        /// <returns>成功:患者基本信息 失败 null</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo QueryComPatientInfoByMcardNO(string mcardNO)
        {
            this.SetDB(radtManager);

            return radtManager.QueryComPatientInfoByMcardNO(mcardNO);
        }

        /// <summary>
        /// 自动生成住院号
        /// </summary>
        /// <param name="patientNO">当前住院号</param>
        /// <param name="usedPatientNO">使用了的住院号</param>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 失败: -1</returns>
        public int CreateAutoInpatientNO(string patientNO, string usedPatientNO, Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.SetDB(radtManager);
           
            if (radtManager.AutoCreatePatientNO(patientNO, usedPatientNO, ref patient) == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 住院患者登记
        /// </summary>
        /// <param name="patient">住院患者基本信息实体</param>
        /// <returns>成功 1 失败: -1</returns>
        public int RegisterPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            this.SetDB(radtManager);

            if (radtManager.InsertPatient(patient) == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 更新患者信息
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int UpdatePatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.SetDB(radtManager);

            if (radtManager.UpdatePatient(patient) <=0)
            {
                return -1;
            }

            return 1;
        }
        /// <summary>
        /// 更新未使用的住院号为使用状态
        /// </summary>
        /// <param name="oldPatientNO">旧的住院号，未使用的</param>
        /// <returns>成功 1 并发 0 应该重新获取住院号 失败: -1</returns>
        public int UpdatePatientNOState(string oldPatientNO) 
        {
            this.SetDB(radtManager);

            if (radtManager.UpdatePatientNoState(oldPatientNO) == -1) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 插入患者基本登记信息com_patientinfo
        /// </summary>
        /// <param name="patient">当前患者基本信息实体</param>
        /// <returns>成功 1 并发 0 应该重新获取住院号 失败: -1</returns>
        public int RegisterComPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            this.SetDB(radtManager);

            if (radtManager.InsertPatientInfo(patient) == -1) 
            {
                if (this.DBErrCode == 1)
                {
                    if (radtManager.UpdatePatientInfo(patient) <= 0)
                    {
                        return -1;
                    }
                }
                else 
                {
                    return -1;
                }
            }

            return 1;
        }
        ///
        ///插入或更新住院证信息
        ///
        public int InPatientProof(Neusoft.HISFC.Models.RADT.InPatientProof inpatientproof)
        {
            this.SetDB(radtManager);

            if (radtManager.InsertInpatientProof(inpatientproof) == -1)
            {
                if (this.DBErrCode == 1)
                {
                    if (radtManager.UpdateInpatientProof(inpatientproof) <= 0)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }

            return 1;
        }
        /// <summary>
        /// 插入患者变更信息
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 并发 0  失败: -1</returns>
        public int InsertShiftData(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            this.SetDB(radtManager);

            if (radtManager.SetShiftData(patient.ID, Neusoft.HISFC.Models.Base.EnumShiftType.B, "住院登记", patient.PVisit.PatientLocation.Dept,
                patient.PVisit.PatientLocation.Dept) <= 0) 
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 根据患者查询变更记录{28C63B3A-9C64-4010-891D-46F846EA093D}
        /// </summary>
        /// <param name="clinicNO"></param>
        /// <returns></returns>
        public ArrayList QueryPatientShiftInfoNew(string clinicNO)
        {
            this.SetDB(radtManager);
            return radtManager.QueryPatientShiftInfoNew(clinicNO);
        }
        //{FA3B8CE6-0414-423a-A92D-33678E5FF193}
        /// <summary>
        /// 插入登记即接诊患者变更信息
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 并发 0  失败: -1</returns>
        public int InsertRecievePatientShiftData(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.SetDB(radtManager);

            //变更信息
            if (radtManager.SetShiftData(patient.ID, Neusoft.HISFC.Models.Base.EnumShiftType.K, "接诊", patient.PVisit.PatientLocation.NurseCell, patient.PVisit.PatientLocation.Bed) < 0)
            {
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 插入变更记录
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="shiftType">变更类型</param>
        /// <param name="shiftText">变更说明</param>
        /// <param name="oldShift">以前状态</param>
        /// <param name="newShift">当前状态</param>
        /// <returns>成功 1 并发 0  失败: -1</returns>
        public int InsertShiftData(string inpatientNO, Neusoft.HISFC.Models.Base.EnumShiftType shiftType, string shiftText, Neusoft.FrameWork.Models.NeuObject oldShift,
            Neusoft.FrameWork.Models.NeuObject newShift) 
        {
            this.SetDB(radtManager);

            return radtManager.SetShiftData(inpatientNO, shiftType, shiftText, oldShift, newShift);
        }

        /// <summary>
        /// 插入担保信息,插入的担保条件已经判断
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 并发 0 应该重新获取住院号 失败: -1</returns>
        public int InsertSurty(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            if (patient.Surety.SuretyType.ID != null && patient.Surety.SuretyCost > 0 && patient.Surety.SuretyType.ID != string.Empty)
            {
                this.SetDB(inpatientManager);

                if (inpatientManager.InsertSurty(patient) <= 0)
                {
                    return -1;
                }

            }

            return 1;
        }

        /// <summary>
        /// 更新患者科室
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有更新到数据 0</returns>
        public int UpdatePatientDept(Neusoft.HISFC.Models.RADT.PatientInfo patient) 
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientDeptByInpatientNo(patient);
        }
        //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
        /// <summary>
        /// 更新患者科室
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns>成功 1 失败 -1 没有更新到数据 0</returns>
        public int UpdatePatientNurse(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientNursCellByInpatientNo(patient);
        }

        /// <summary>
        /// 根据住院号查询患者基本信息
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <returns>成功: 患者基本信息实体 失败 null</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfomation(string inpatientNO) 
        {
            this.SetDB(radtManager);

            return radtManager.QueryPatientInfoByInpatientNO(inpatientNO);
        }

        /// <summary>
        /// 查询一段时间内的登记患者
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>成功: 患者集合 失败 Null</returns>
        public ArrayList QueryPatientsByDateTime(DateTime beginTime, DateTime endTime) 
        {
            this.SetDB(radtManager);

            return radtManager.QueryPatient(beginTime, endTime);
        }
        /// <summary>
		/// 更新基本信息表－不是患者主表  表名：com_patientinfo
		/// </summary>
		/// <param name="PatientInfo"></param>
		/// <returns></returns>
        public int UpdatePatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientInfo(PatientInfo);
        }
        /// <summary>
		/// 插入病人基本信息表-不是患者主表 表名：com_patientinfo 
		/// </summary>
		/// <param name="PatientInfo">患者基本信息</param>
		/// <returns>成功标志 0 失败，1 成功</returns>
		/// <returns></returns>
        public int InsertPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo)
        {
            this.SetDB(radtManager);

            return radtManager.InsertPatientInfo(PatientInfo);
        }
        /// <summary>
        /// 获取卡号
        /// </summary>
        /// <returns></returns>
        public string GetCardNOSequece()
        {
            this.SetDB(radtManager);

            return radtManager.GetCardNOSequece();
        }

        /// <summary>
        /// 更新患者病案标记
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="CaseFlag">病案标记</param>
        /// <returns>1成功else失败</returns>
        public int UpdatePatientCaseFlag(string InpatientNO, string CaseFlag)
        {
            this.SetDB(radtManager);

            return radtManager.UpdateCase(InpatientNO, CaseFlag);
        }
        #endregion

        #region 患者查询
        #region  查询病人基本信息 com_patientinfo表
        [Obsolete("废弃,用QueryComPatientInfo代替")]
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatient(string CardNO)
        {
            this.SetDB(radtManager);
            return radtManager.GetPatient(CardNO);
        }
        #endregion 
        /// <summary>
        /// 查询科室患者
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <returns></returns>
        public ArrayList QueryPatient( string deptCode, Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);

            Neusoft.HISFC.Models.RADT.InStateEnumService istate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            istate.ID = inState;
            return radtManager.PatientQuery(deptCode, istate);

        }

         /// <summary>
        /// 患者查询-查询医疗组不同状态的患者//{AC6A5576-BA29-4dba-8C39-E7C5EBC7671E} 增加医疗组处理
        /// </summary>
        /// <param name="medicalTeamCode">科室编码</param>
        /// <param name="State">住院状态</param>
        /// <returns></returns>
        public ArrayList PatientQueryByMedicalTeam(string medicalTeamCode, Neusoft.HISFC.Models.Base.EnumInState inState, string deptCode)
        {
            this.SetDB(radtEmrManager);
            Neusoft.HISFC.Models.RADT.InStateEnumService istate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            istate.ID = inState;
            return radtManager.PatientQueryByMedicalTeam(medicalTeamCode, istate,deptCode);
        }

        

        /// <summary>
        /// 根据状态查询患者
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <returns></returns>
        public ArrayList QueryPatient( Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);

            Neusoft.HISFC.Models.RADT.InStateEnumService istate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            istate.ID = inState;
            return radtManager.QueryPatientBasicByInState(istate);

        }
        /// <summary>
        /// 根据病区状态查询患者
        /// </summary>
        /// <param name="nurseCellID">病区编码</param>
        /// <param name="inState">住院状态</param>
        /// <returns></returns>
        public ArrayList QueryPatientByNurseCellAndState(string nurseCellID,Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryByNurseCell(nurseCellID,inState);

        }
        /// <summary>
        /// 根据病区科室状态查询患者
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByNurseCellAndDept(string nurseCellID, string deptCode,Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryByNurseCellAndDept(nurseCellID,deptCode,inState);

        }
                 
        /// <summary>
        /// 查询患者信息
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="inState"></param>
        /// <returns></returns>
        public ArrayList QueryPatient(DateTime beginTime,DateTime endTime, Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);

            
            return radtManager.QueryPatientInfoByTimeInState(beginTime, endTime, inState.ToString());

        }
        /// <summary>
        /// 获得医生的患者
        /// </summary>
        /// <param name="objDoc"></param>
        /// <param name="inState"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByHouseDoc(Neusoft.FrameWork.Models.NeuObject objDoc,Neusoft.HISFC.Models.Base.EnumInState inState,string deptCode)
        {
             this.SetDB(radtManager);

            
            return radtManager.QueryHouseDocPatient(objDoc, inState, deptCode);
            
        }
        /// <summary>
        /// 根据病区状态查询患者(欠费)  {62EAD92D-49F6-45d5-B378-1E573EC27728}
        /// </summary>
        /// <param name="nurseCellID">病区编码</param>
        /// <param name="inState">住院状态</param>
        /// <returns></returns>
        public ArrayList QueryPatientByNurseCellAndStateForAlert(string nurseCellID, Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryByNurseCellForAlert(nurseCellID, inState);

        }
        /// <summary>
        /// 获得指定科室及医生的会诊患者
        /// </summary>
        /// <param name="objDoc"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByConsultation(Neusoft.FrameWork.Models.NeuObject objDoc, DateTime dtBegin,DateTime dtEnd, string deptCode)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryConsultation(objDoc, "0", dtBegin, dtEnd, deptCode);
            
        }

        /// <summary>
        /// 获得分给医生权限的患者
        /// </summary>
        /// <param name="objDoc"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByPermission(Neusoft.FrameWork.Models.NeuObject objDoc)
        {
            this.SetDB(radtManager);
            return radtManager.QueryPatientByPermission(objDoc.ID);
            
        }

        /// <summary>
        /// 查询住院流水号根据住院号
        /// 查找患者多次入院的医嘱
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <returns></returns>
        public ArrayList QueryInpatientNoByPatientNo(string patientNo)
        {
            SetDB(radtManager);
            return radtManager.QueryInpatientNOByPatientNO(patientNo);
        }

        /// <summary>
        /// 根据病区科室状态查询患者（欠费患者）{62EAD92D-49F6-45d5-B378-1E573EC27728}
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByNurseCellAndDeptForAlert(string nurseCellID, string deptCode, Neusoft.HISFC.Models.Base.EnumInState inState)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryByNurseCellAndDeptForAlert(nurseCellID, deptCode, inState);

        }
        //患者查询
		/// <summary>
		/// 患者查询-按住院号查
		/// </summary>
		/// <param name="inPatientNO">住院流水号</param>
		/// <returns>患者信息 PatientInfo</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo QueryPatientInfoByInpatientNO(string inPatientNO)
        {
            SetDB(radtManager);
            return radtManager.QueryPatientInfoByInpatientNO(inPatientNO);
        }
        /// <summary>
        /// 按姓名查询患者基本信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByName(string name)
        {
            this.SetDB(radtManager);
            return radtManager.QueryPatientByName(name);
        }
        /// <summary>
		/// 患者查询-按住院号查
		/// </summary>
		/// <param name="inPatientNO">患者住院流水号</param>
		/// <returns>返回患者信息</returns>
        public Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfoByPatientNO(string inPatientNO)
        {
            this.SetDB(radtManager);
            return radtManager.GetPatientInfoByPatientNO(inPatientNO);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        public ArrayList QureyPatientInfobyCardno(string cardNO)
        {
            this.SetDB(inPatienMgr);
            return inPatienMgr.QureyPatientInfo(cardNO);
        }
        #endregion



        /// <summary>
        /// 根据有效出院召回的有效天数查询科室出院登记患者信息
        /// ----Create By By ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="inState"></param>
        /// <param name="vaildDays"></param>
        /// <returns></returns>
        public ArrayList QueryPatientByVaildDate(string deptCode, Neusoft.HISFC.Models.Base.EnumInState inState, int vaildDays)
        {
            this.SetDB(radtManager);
            Neusoft.HISFC.Models.RADT.InStateEnumService istate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            istate.ID = inState;
            return radtManager.PatientQueryByVaildDate(deptCode, istate, vaildDays);
        }

        /// <summary>
        /// 根据有效召回期查询一段时间内某个科室的出院登记患者(起止时间  科室代码 有效天数)
        /// ----Create By By ZhangQi
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="vaildDays"></param>
        /// <returns></returns>
        public ArrayList QueryOutHosPatient(string deptCode, string beginTime, string endTime, int vaildDays, int myPaientState)
        {
            this.SetDB(radtManager);
            return radtManager.OutHosPatientByState(deptCode, beginTime, endTime, vaildDays, myPaientState);
        }

        /// <summary>
        /// 按就诊卡号查询住院期间有病案的患者
        /// by niuxinyuan
        /// </summary>
        /// <param name="cardNO">就诊卡号</param>
        /// <returns></returns>
        public ArrayList GetPatientInfoHaveCaseByCardNO(string cardNO)
        {
            this.SetDB(inPatienMgr);
            return inPatienMgr.GetPatientInfoHaveCaseByCardNO(cardNO);
        }

        //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上

        /// <summary>
        /// 通过婴儿的住院流水号,查询母亲的住院流水号
        /// </summary>
        /// <param name="babyInpatientNO">婴儿住院流水号</param>
        /// <returns>母亲的住院流水号 错误返回 null 或者 string.Empty</returns>
        public string QueryBabyMotherInpatientNO(string babyInpatientNO)
        {
            this.SetDB(inPatienMgr);

            return inPatienMgr.QueryBabyMotherInpatientNO(babyInpatientNO);
        }
        //{02B13899-6FE7-4266-AC64-D3C0CDBBBC3F} 婴儿的费用是否可以收取到妈妈身上 结束
        #region 根据医保卡号查询住院患者信息
        /// <summary>
        /// 根据医保卡号查询住院患者信息
        /// </summary>
        /// <param name="markNO"></param>
        /// <returns></returns>
        public ArrayList PatientQueryByMcardNO(string mcardNO)
        {
            this.SetDB(radtManager);
            return radtManager.PatientQueryByMcardNO(mcardNO);
        }
        #endregion
        #region 入出转大函数

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线根据住院号
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlert(string inpatientNO, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate) 
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientAlert(inpatientNO, moneyAlert,alertType,beginDate,endDate);
        }
        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线根据合同单位
        /// </summary>
        /// <param name="pactID"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertByPactID(string pactID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientAlertByPactID(pactID, moneyAlert,alertType,beginDate,endDate);
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线根据住院科室
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertByDeptID(string deptID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientAlertByDeptID(deptID, moneyAlert,alertType,beginDate,endDate);
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线根据护士站
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertByNurseCellID(string nurseCellID, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientAlertByNurseCellID(nurseCellID, moneyAlert,alertType,beginDate,endDate);
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线根据护士站和科室
        /// </summary>
        /// <param name="nurseCellID"></param>
        /// <param name="deptCode"></param>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertByNurseCellIDAndDept(string nurseCellID, string deptCode, decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientAlertByNurseCellIDAndDept(nurseCellID, deptCode, moneyAlert,alertType,beginDate,endDate);
        }

        //{A45EE85D-B1E3-4af0-ACAD-9DAF65610611}
        /// <summary>
        /// 更新患者警戒线所有患者
        /// </summary>
        /// <param name="moneyAlert"></param>
        /// <returns></returns>
        public int UpdatePatientAlertAll(decimal moneyAlert, string alertType, DateTime beginDate, DateTime endDate)
        {
            this.SetDB(radtManager);
            return radtManager.UpdatePatientAlert(moneyAlert,alertType,beginDate,endDate);           
        }


        /// <summary>
        /// 召回患者
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        public int CallBack(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Base.Bed Bed)
        {
            #region  //{E7D41747-D6D7-42f5-899B-B7911592E9FF} 出院召回对患者进行开帐操作
            //控制当患者正在出院结算的时候不能召回.
            //string stopAccountFlag = inpatientManager.GetStopAccount(patientInfo.ID);
            
            //if (stopAccountFlag == "1")
            //{//关帐,患者正在结算
            //    //this.Err = "患者正在结算...请稍后再试!";{92467DA0-BE20-4a4b-8596-62598E3728A3}
            //    this.Err = "患者正在结算或者已经封帐...，请与住院处联系";
            //    return -1;
            //}
            #endregion 

            int parm = 0;
            Neusoft.HISFC.Models.RADT.PatientInfo pMother = new Neusoft.HISFC.Models.RADT.PatientInfo();
            //判断婴儿召回
            if (patientInfo.IsBaby)
            {
                //生成婴儿妈妈的住院流水号
                string temp = patientInfo.ID.Substring(4, 2);
                string motherPatientNo = (patientInfo.ID).Replace(temp, "00");

                //取婴儿妈妈的住院信息
                pMother = radtManager.QueryPatientInfoByInpatientNO(motherPatientNo);
                if (pMother == null || pMother.ID == "")
                {
                    this.Err = "查找:" + patientInfo.Name + "母亲信息出错!" + radtManager.Err;
                    return -1;
                }

                //如果妈妈不是在院状态,不能单独召回婴儿
                if (pMother.PVisit.InState.ID.ToString() != "I")
                {
                    this.Err = patientInfo.Name + "的母亲" + pMother.Name + "是出院登记状态,请先召回母亲!";
                    return -1;
                }

                //婴儿召回的床应该跟妈妈相同.不处理床位信息
                Bed = pMother.PVisit.PatientLocation.Bed.Clone();
            }

            
            Bed = managerBed.GetBedInfo(Bed.ID);

            //如果患者不是婴儿,不允许召回到占用的床位
            if (patientInfo.IsBaby==false &&
                Bed.Status.ID.ToString() != "U" && Bed.Status.ID.ToString() != "H")
            {
                this.Err = "您所选择的床位为" + Bed.Status.Name + ", 无法召回!";
                return -1;
            }

            //变更类型:召回
            parm = radtManager.RecievePatient(patientInfo, Bed, Neusoft.HISFC.Models.Base.EnumShiftType.C, "召回");
            
            if (parm == -1)
            {
               
                this.Err = "召回失败！" + radtManager.Err;
                return -1;
            }
            else if (parm == 0)
            {
               
                this.Err = "召回失败! 患者信息有变动,请刷新当前窗口";
                return -1;
            }

            //{E7D41747-D6D7-42f5-899B-B7911592E9FF} 出院登记时对患者进行开帐处理
            if (inpatientManager.OpenAccount(patientInfo.ID) == -1)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("患者开帐出错!",111);
                return -1;
            }
           
            this.Err = "召回成功！";
            return 1;
        }
        #region 急诊留观出院召回
        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 急诊留观出院召回
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Bed"></param>
        /// <param name="isOut">是否出关召回</param>
        /// <returns></returns>
        public int CallBack(Neusoft.HISFC.Models.Registration.Register patientInfo, Neusoft.HISFC.Models.Base.Bed Bed,bool isOut)
        {
            int parm = 0;

            Bed = managerBed.GetBedInfo(Bed.ID);

            //如果患者不是婴儿,不允许召回到占用的床位
            if (Bed.Status.ID.ToString() != "U" && Bed.Status.ID.ToString() != "H")
            {
                this.Err = "您所选择的床位为" + Bed.Status.Name + ", 无法召回!";
                return -1;
            }
            if (isOut)
            {
                //变更类型:出院召回
                parm = radtEmrManager.RecievePatient(patientInfo, Bed, Neusoft.HISFC.Models.Base.EnumShiftType.EC, "留观召回");
            }
            else
            {
                //变更类型:转住院召回
                parm = radtEmrManager.RecievePatient(patientInfo, Bed, Neusoft.HISFC.Models.Base.EnumShiftType.IC, "留观召回");
            }
            if (parm == -1)
            {

                this.Err = "留观召回失败！" + radtManager.Err;//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}
                return -1;
            }
            else if (parm == 0)
            {

                this.Err = "留观召回失败! 患者信息有变动,请刷新当前窗口";//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}
                return -1;
            }


            this.Err = "留观召回成功！";//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}
            return 1;
        }

        #endregion

        /// <summary>
        /// 接诊
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Bed"></param>
        /// <returns></returns>
        public  int ArrivePatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo, Neusoft.HISFC.Models.Base.Bed Bed)
        {
            int parm = 0;

            
            //判断选择的床位是否可用
            Bed = managerBed.GetBedInfo(Bed.ID);
            if (Bed.Status.ID.ToString() != "U" &&
                Bed.Status.ID.ToString() != "H")
            {
                this.Err = "您所选择的床位为" + Bed.Status.Name;
                return -1;
            }

            //{FA32C976-E003-4a10-9028-71F2CD154052} 固定费用时间
            DateTime saveDate = patientInfo.PVisit.RegistTime;
            patientInfo.PVisit.RegistTime = radtManager.GetDateTimeFromSysDateTime();


            //接珍处理(1更新患者信息, 2插入接珍表)
            parm = radtManager.RecievePatient(patientInfo, Bed, Neusoft.HISFC.Models.Base.EnumShiftType.K, "接诊");

            //{FA32C976-E003-4a10-9028-71F2CD154052} 固定费用时间
            patientInfo.PVisit.RegistTime = saveDate;

            if (parm == -1)
            {

                this.Err = "接诊失败！" + radtManager.Err;
                return -1;
            }
            else if (parm == 0)
            {
                
                this.Err = "接诊失败! 患者信息有变动,请刷新当前窗口";
                return -1;
            }

            this.Err = "接诊成功！";

            return 1;
        }

        /// <summary>
        /// 急诊留观接诊
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="Bed"></param>
        /// <returns></returns>
        public int EmrArrivePatient(Neusoft.HISFC.Models.Registration.Register outpatientInfo, Neusoft.HISFC.Models.Base.Bed Bed)
        {
            int parm = 0;


            //判断选择的床位是否可用
            Bed = managerBed.GetBedInfo(Bed.ID);
            if (Bed.Status.ID.ToString() != "U" &&
                Bed.Status.ID.ToString() != "H")
            {
                this.Err = "您所选择的床位为" + Bed.Status.Name;
                return -1;
            }

            //接珍处理(1更新患者信息, 2插入接珍表)
            parm = radtEmrManager.RecievePatient(outpatientInfo, Bed, Neusoft.HISFC.Models.Base.EnumShiftType.EK, "接诊");
            if (parm == -1)
            {

                this.Err = "留观接诊失败！" + radtManager.Err;//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}
                return -1;
            }
            else if (parm == 0)
            {

                this.Err = "留观接诊失败! 患者信息有变动,请刷新当前窗口";//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}
                return -1;
            }

            this.Err = "留观接诊成功！";//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}

            return 1;
        }
        /// <summary>
        /// 更换医生
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <returns></returns>
        public int ChangeDoc(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo)
        {
            int parm = 0;
    
            //更新患者信息

            parm = radtManager.RecievePatient(PatientInfo, PatientInfo.PVisit.InState);
            if (parm == -1)
            {

                this.Err = "更新出错！\n" + radtManager.Err;
                return -1;
            }
            else if (parm == 0)
            {
              
                this.Err = "保存失败! 患者信息有变动,请刷新当前窗口";
                return -1;
            }
            else
            {
                
                this.Err = "保存成功！";
            }
            return 1;
        }

       /// <summary>
       /// 转科确认
       /// </summary>
       /// <param name="PatientInfo"></param>
       /// <param name="nurseCell"></param>
       /// <param name="bedNo"></param>
       /// <returns></returns>
        public int ShiftIn(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo,Neusoft.FrameWork.Models.NeuObject nurseCell,string bedNo)
        {
            int parm = 0;
            Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
            newLocation = radtManager.QueryShiftNewLocation(PatientInfo.ID, PatientInfo.PVisit.PatientLocation.Dept.ID);
            if (newLocation == null)
            {
                this.Err = "转科、转病区确认出错！\n患者信息有变动,请刷新当前窗口";
                return -1;
            }

            //如果没有找到数据,说明患者已经被确认,并发
            if (newLocation.Dept.ID == "" && newLocation.NurseCell.ID == "")
            {
                this.Err = "转科、转病区确认失败！\n" + radtManager.Err;
                return -1;
            }
            if (newLocation.Dept.Name == "" && newLocation.Dept.ID != "")
            {
                newLocation.Dept = managerDepartment.GetDeptmentById(newLocation.Dept.ID);
                if (newLocation.Dept == null)
                {
                    this.Err = "转科确认失败！\n" + managerDepartment.Err;
                    return -1;
                }

            }
            #region {9A2D53D3-25BE-4630-A547-A121C71FB1C5}
            if (newLocation.NurseCell.Name == "" && newLocation.NurseCell.ID != "")
            {
                newLocation.NurseCell = managerDepartment.GetDeptmentById(newLocation.NurseCell.ID);
                if (newLocation.NurseCell == null)
                {
                    this.Err = "转病区确认失败！\n" + managerDepartment.Err;
                    return -1;
                }

            }
            #endregion
            newLocation.NurseCell = nurseCell.Clone();
            newLocation.Bed.ID = bedNo;	//新病床
            newLocation.Bed.Status.ID = "U";					//新床的状态
            newLocation.Bed.InpatientNO = "N";					//新床的患者住院流水号
    
         
            try
            {
                //去系统时间
                DateTime sysDate = radtManager.GetDateTimeFromSysDateTime();

                //接珍处理(1更新患者信息, 2插入接珍表), 注:只要有接珍操作,都进行此处理
                if (radtManager.RecievePatient(PatientInfo, Neusoft.HISFC.Models.Base.EnumInState.I) == -1)
                {

                    this.Err = "转科确认出错！\n" + radtManager.Err;
                    return -1;
                }

                //转科处理
                parm = radtManager.TransferPatient(PatientInfo, newLocation);
                if (parm == -1)
                {

                    this.Err = "转科确认出错！\n" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                   
                    this.Err = "保存失败! \n患者信息有变动,请刷新当前窗口";
                    return -1;
                }

                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtManager.GetSpecialBedInfo(PatientInfo.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtManager.UnWrapPatientBed(PatientInfo, obj.ID, obj.Memo) < 0)
                    {

                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                }


                //停止医嘱
                System.Windows.Forms.DialogResult r = System.Windows.Forms.MessageBox.Show("是否停止以前的医嘱！", "转科确认", System.Windows.Forms.MessageBoxButtons.OKCancel);
                if (r == System.Windows.Forms.DialogResult.OK)
                {
                    if (managerOrder.DcOrder(PatientInfo.ID, sysDate, "01", "转科停止") == -1)
                    {

                        this.Err = "停止医嘱失败！" + managerOrder.Err;
                        return -1;
                    }
                }
              
                this.Err = "转科确认成功！";
            }
            catch (Exception ex)
            {
               
                this.Err = ex.Message;
                return -1;
            }

            return 1;
        }

        /// <summary>
        ///  转科申请，取消
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="newDept"></param>
        /// <param name="state">当前申请状态"1"</param>
        /// <param name="isCancel">是否取消</param>
        /// <returns></returns>
        public int ShiftOut(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,
            Neusoft.FrameWork.Models.NeuObject newDept,Neusoft.FrameWork.Models.NeuObject newNurseCell,string state,bool isCancel)
        {
       
            //婴儿不允许转科
            if (patientInfo.IsBaby) //
            {
               this.Err = ("婴儿不可以单独转科,只能跟着母亲一同转科.");
                return -1;
            }

            //取母亲是否有在院的婴儿，如果有，就不允许转科
            int baby = radtManager.IsMotherHasBabiesInHos(patientInfo.ID);
            if (baby == -1)
            {
                 this.Err = (radtManager.Err);
                return -1;
            }
        

            //取患者主表中最新的信息,用来判断并发
            Neusoft.HISFC.Models.RADT.PatientInfo patient = radtManager.QueryPatientInfoByInpatientNO(patientInfo.ID);
            if (patient == null)
            {
                 this.Err = (radtManager.Err);
                return -1;
            }
            //如果患者已不在本科,则清空数据---当患者转科后,如果本窗口没有关闭,会出现此种情况
            if (patient.PVisit.PatientLocation.NurseCell.ID != ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Nurse.ID)
            {
                 this.Err = ("患者已不在本病区,请刷新当前窗口");
                return -1;
            }
            //如果患者已不是在院状态,则不允许操作
            if (patient.PVisit.InState.ID.ToString() != patientInfo.PVisit.InState.ID.ToString())
            {
                this.Err = ("患者信息已发生变化,请刷新当前窗口");
                return -1;
            }


            
            Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
            //{9A2D53D3-25BE-4630-A547-A121C71FB1C5}start
            Neusoft.HISFC.Models.Base.Department tmpDept = new Neusoft.HISFC.Models.Base.Department();
            tmpDept = managerDepartment.GetDeptmentById(newDept.ID);
            bool isShiftNurseCell = false;
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            //if (tmpDept.DeptType.ID.ToString() == "N")
            //{
            //    isShiftNurseCell = true;
            //    newLocation.NurseCell.ID = newDept.ID;
            //    newLocation.NurseCell.Name = newDept.Name;
            //    newLocation.NurseCell.Memo = newDept.Memo;

            //    if (patientInfo.PVisit.PatientLocation.NurseCell.ID == newLocation.NurseCell.ID)
            //    {
            //        this.Err = ("原病区不能与目标病区相同！");
            //        return -1;
            //    }
            //}
            ////{9A2D53D3-25BE-4630-A547-A121C71FB1C5}end
            //else
            //{
            //    //更新科室信息
            //    newLocation.Dept.ID = newDept.ID;
            //    newLocation.Dept.Name = newDept.Name;
            //    newLocation.Dept.Memo = newDept.Memo;

            //    if (patientInfo.PVisit.PatientLocation.Dept.ID == newLocation.Dept.ID)
            //    {
            //        this.Err = ("原科室不能与目标科室相同！");
            //        return -1;
            //    }
            //}
            //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
            newLocation.Dept.ID = newDept.ID;
            newLocation.Dept.Name = newDept.Name;
            newLocation.Dept.Memo = newDept.Memo;
            newLocation.NurseCell.ID = newNurseCell.ID;
            newLocation.NurseCell.Name = newNurseCell.Name;
            
            

            if (patientInfo.PVisit.PatientLocation.NurseCell.ID == newLocation.NurseCell.ID && patientInfo.PVisit.PatientLocation.Dept.ID == newLocation.Dept.ID)
            {
                this.Err = ("原病区和原科室不能与目标病区和目标科室都相同！");
                return -1;
            }


            //转科申请/取消
            try
            {
                int parm;
                if (state == null || state == "") state = "1";
                parm = radtManager.TransferPatientApply(patientInfo, newLocation,
                    isCancel, state);//状态，申请还是啥?
                if (parm == -1)
                {
                    this.Err = (radtManager.Err);
                    return -1;
                }
                else if (parm == 0)
                {
                    //取消申请时,发生并发操作
                    if (isCancel)
                        this.Err = ("此转{0}申请已生效,不能取消.");
                    else
                        this.Err = ("此转{0}申请已被取消,不能确认");
                    return -1;
                }
                else
                {
                    if(isCancel)
                        this.Err = "取消转{0}申请成功！";
                    else
                        this.Err = "转{0}申请成功！";
                }
                
                if(this.Err.Contains("{0}"))
                {
                    if (isShiftNurseCell)
                    {
                        this.Err = string.Format(this.Err, "病区");
                    }
                    else
                    {
                        this.Err = string.Format(this.Err, "科");
                    }
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
        
            return 1;
        }

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <param name="patientInfo">患者信息</param>
        /// <returns>-1 错误 0取消 1 成功</returns>
        public int OutPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            //判断是否还有为确认的出单


            #region 判断是否还有未确认的退费申请
            try
            {
                Neusoft.HISFC.BizLogic.Fee.ReturnApply apprMgr = new Neusoft.HISFC.BizLogic.Fee.ReturnApply();
                apprMgr.SetTrans(this.trans);

                ArrayList applys = apprMgr.QueryReturnApplys(patientInfo.ID, false);
                if (applys == null)
                {
                    this.Err = apprMgr.Err;
                    return -1;
                }
                if (applys.Count > 0) //存在退费申请提示是否需要做院登记
                {
                    if (!quitFeeApplyFlag) 
                    {
                        DialogResult dr = MessageBox.Show("还有未确认的退费申请，是否继续出院？", "提示"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.No)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        //存在退费申请不允许做出院登记
                        MessageBox.Show("还有未确认的退费申请,请退费或取消退费后再做出院登记");
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }

            #endregion

            #region 判断患者是存在为摆药的药品
            //{F8137B37-C1B1-4fe1-8008-00F17B4FE40E}
            ArrayList medList = inpatientManager.QueryMedItemLists(patientInfo.ID, "1");

            if (medList == null)
            {
                this.Err = inpatientManager.Err;
                return -1;
            }

            if (medList.Count > 0)
            {
                MessageBox.Show("存在未摆药的药品项目，请摆药后再做出院登记！");
                return 0;
            }
            #endregion

            try
            {

                //停止医嘱
                //补收费（床费、医嘱收费）
                DialogResult r = MessageBox.Show("是否停止全部的医嘱！", "出院登记", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    if (managerOrder.DcOrder(patientInfo.ID, managerOrder.GetDateTimeFromSysDateTime(), "01", "出院停止") == -1)
                    {
                        this.Err = "停止医嘱失败！" + managerOrder.Err;
                        return -1;
                    }
                }

              
                //更新患者状态、置空床位
                int parm = radtManager.RegisterOutHospital(patientInfo);
                if (parm == -1)
                {

                    this.Err = "保存失败！" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    this.Err = "保存失败! 患者信息有变动,请刷新当前窗口";
                    return -1;
                }

                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtManager.GetSpecialBedInfo(patientInfo.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtManager.UnWrapPatientBed(patientInfo, obj.ID, obj.Memo) < 0)
                    {

                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                }

                //
                if (this.inpatientManager.CloseAccount(patientInfo.ID) == -1)
                {
                    this.Err = "患者封帐出错!" + inpatientManager.Err;
                    return -1;
                }

                this.Err = "出院登记成功！";

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;
        }
        /// <summary>
        /// 急诊留观出院登记
        /// </summary>
        /// <param name="patientInfo">患者信息</param>
        /// <returns>-1 错误 0取消 1 成功</returns>
        public int OutPatient(Neusoft.HISFC.Models.Registration.Register patientInfo)
        {
            try
            {
                //更新患者状态、置空床位
                int parm = radtEmrManager.RegisterOutHospital(patientInfo);
                
                if (parm == -1)
                {

                    this.Err = "保存失败！" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    this.Err = "保存失败! 患者信息有变动,请刷新当前窗口";
                    return -1;
                }

                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtEmrManager.GetSpecialBedInfo(patientInfo.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtEmrManager.UnWrapPatientBed(patientInfo, obj.ID, obj.Memo) < 0)
                    {

                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                }

                this.Err = "留观出院成功！";//{1D08D511-B7E9-4e00-8A1D-87421815A4C4}

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;
        }
        #region addby xuewj 2010-10-11 {EFF73DC9-3543-49a4-9751-BC8D95F0BDD3} 出院登记时判断是否可以进行下一步（郑大本地化需求）
        /// <summary>
        /// 出院登记德惠用
        /// </summary>
        /// <param name="patientInfo">患者信息</param>
        /// <returns>-1 错误 0取消 1 成功</returns>
        public int OutPatientZZU(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            try
            {
                //停止医嘱
                //补收费（床费、医嘱收费）
                DialogResult r = MessageBox.Show("是否停止全部的医嘱！", "出院登记", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    if (managerOrder.DcOrder(patientInfo.ID, managerOrder.GetDateTimeFromSysDateTime(), "01", "出院停止") == -1)
                    {
                        this.Err = "停止医嘱失败！" + managerOrder.Err;
                        return -1;
                    }
                }

                //更新患者状态、置空床位
                int parm = radtManager.RegisterOutHospital(patientInfo);
                if (parm == -1)
                {

                    this.Err = "保存失败！" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    this.Err = "保存失败! 患者信息有变动,请刷新当前窗口";
                    return -1;
                }

                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtManager.GetSpecialBedInfo(patientInfo.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtManager.UnWrapPatientBed(patientInfo, obj.ID, obj.Memo) < 0)
                    {

                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                }

                this.Err = "出院登记成功！";

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return -1;
            }
            return 1;
        }
        #endregion

        /// <summary>
        /// 无费退院
        /// </summary>
        /// <param name="patient">住院患者信息实体</param>
        /// <returns>1 成功 -1 失败</returns>
        public int UnregisterNoFee(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            this.SetDB(radtManager);

            //如果在院状态是在院并且不是婴儿,则释放床位
            if (patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.I.ToString() &&
               !patientInfo.IsBaby)
            {
                //更新床位
                Neusoft.HISFC.Models.Base.Bed newBed = patientInfo.PVisit.PatientLocation.Bed.Clone();
                newBed.InpatientNO = "N";	//床位无患者
                newBed.Status.ID = "U";	//床位状态是空床

                //更新床位状态
                int parm = radtManager.UpdateBedStatus(newBed, patientInfo.PVisit.PatientLocation.Bed);
                if (parm == -1)
                {
                    this.Err = "释放床位失败" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                    this.Err = "患者信息发生变动,请刷新当前窗口" + radtManager.Err;
                    return -1;
                }

                #region 释放包床
                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtManager.GetSpecialBedInfo(patientInfo.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtManager.UnWrapPatientBed(patientInfo, obj.ID, obj.Memo) < 0)
                    {

                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                }
                #endregion
            }
            //更新患者主表:住院状态改为无费退院N
            patientInfo.PVisit.InState.ID = Neusoft.HISFC.Models.Base.EnumInState.N.ToString();
            // patientInfo.PVisit.OutTime = (DateTime)radtManager.GetSysDateTime;

            if (radtManager.UpdatePatient(patientInfo) != 1)
            {
                this.Err = "更新住院主表失败" + radtManager.Err;
                return -1;
            }

            //处理变更日志

            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "无费退院";
            if (radtManager.SetShiftData(patientInfo.ID, Neusoft.HISFC.Models.Base.EnumShiftType.OF, "无费退院", obj1, obj2) < 0)
            {
                this.Err = "更新变更日志失败。" + radtManager.Err;
                return -1;
            }

            return 1;
        }
        #endregion

        #region 患者生命体征

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="lfch"></param>
        /// <returns></returns>
        public int InsertLifeCharacter(Neusoft.HISFC.Models.RADT.LifeCharacter lfch)
        {
            this.SetDB(lfchManagement);
            return lfchManagement.InsertLifeCharacter(lfch);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inPatientNO"></param>
        /// <param name="measureDate"></param>
        /// <returns></returns>
        public int DeleteLifeCharacter(string inPatientNO, DateTime measureDate)
        {
            this.SetDB(lfchManagement);
            return lfchManagement.DeleteLifeCharacter(inPatientNO, measureDate);
        }

        #endregion

        #region 住院处转科转床 by luzhp 2007-7-11
        /// <summary>
        /// 根据科室和在院状态查找患者
        /// </summary>
        /// <param name="dept_Code">科室编码</param>
        /// <param name="state">在院状态</param>
        /// <returns></returns>
        public ArrayList QueryPatientByDeptCode(string dept_Code,Neusoft.HISFC.Models.RADT.InStateEnumService state)
        { 
            this.SetDB(inPatienMgr);
            return inPatienMgr.QueryPatientBasic(dept_Code, state);
        }

        public int ChangeDept(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, Neusoft.HISFC.Models.RADT.Location newlocation)
        {
            try
            {
                #region 验证患者

                Neusoft.HISFC.Models.RADT.PatientInfo patient = QueryPatientInfoByInpatientNO(PatientInfo.ID); //inPatienMgr.GetPatientInfoByPatientNO(PatientInfo.ID);
                if (patient.PVisit.InState.ID.ToString() != Neusoft.HISFC.Models.Base.EnumInState.I.ToString())
                {
                    this.Err = "该患者未接诊！";
                    return -1;
                }
                #endregion

                if (patient.IsBaby)
                {
                    this.Err = "婴儿不可以单独转科、转床,\n只能跟着母亲一同转科";
                    return -1;
                }

                #region 验证床位
                string bedNo = newlocation.Bed.ID;
                Neusoft.HISFC.Models.Base.Bed bed = managerBed.GetBedInfo(bedNo);
                if (bed == null)
                {
                    this.Err = "转科、床失败！";
                    return -1;
                }
                if (bed.Status.ID.ToString() == "W")
                {
                    MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为包床，不能占用！", "提示：");
                    return -1;
                }
                else if (bed.Status.ID.ToString() == "C")
                {
                    MessageBox.Show("床号为 [" + bedNo + " ]的床位状态为关闭，不能占用！", "提示：");
                    return -1;
                }
                else if (bed.IsPrepay)
                {
                    MessageBox.Show("床号为 [" + bedNo + " ]的床位已经预约，不能占用！", "提示：");
                    return -1;
                }
                else if (!bed.IsValid)
                {
                    MessageBox.Show("床号为 [" + bedNo + " ]的床位已经停用，不能占用！", "提示：");
                    return -1;
                }
                #endregion

                //去系统时间
                DateTime sysDate = radtManager.GetDateTimeFromSysDateTime();

                //接珍处理(1更新患者信息, 2插入接珍表), 注:只要有接珍操作,都进行此处理
                if (radtManager.RecievePatient(patient, Neusoft.HISFC.Models.Base.EnumInState.I) == -1)
                {

                    this.Err = "转科确认出错！\n" + radtManager.Err;
                    return -1;
                }
                int parm;
                //转科处理
                parm = radtManager.TransferPatientLocation(patient, newlocation);
                if (parm == -1)
                {

                    this.Err = "转科确认出错！\n" + radtManager.Err;
                    return -1;
                }
                else if (parm == 0)
                {
                   
                    this.Err = "保存失败! \n患者信息有变动,请刷新当前窗口";
                    return -1;
                }

                //释放包床和挂床
                ArrayList al = new ArrayList();
                al = radtManager.GetSpecialBedInfo(patient.ID);
                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Bed obj;
                    obj = (Neusoft.HISFC.Models.Base.Bed)al[i];
                    if (radtManager.UnWrapPatientBed(patient, obj.ID, obj.Memo) < 0)
                    {
                        this.Err = "释放床位失败！" + radtManager.Err;
                        return -1;
                    }
                    
                }

                //停止医嘱
                System.Windows.Forms.DialogResult r = System.Windows.Forms.MessageBox.Show("是否停止以前的医嘱！", "转科确认", System.Windows.Forms.MessageBoxButtons.OKCancel);
                if (r == System.Windows.Forms.DialogResult.OK)
                {
                    if (managerOrder.DcOrder(PatientInfo.ID, sysDate, "01", "转科停止") == -1)
                    {

                        this.Err = "停止医嘱失败！" + managerOrder.Err;
                        return -1;
                    }
                }
              
                this.Err = "转科、床确认成功！";
                return parm;
            }
            catch (Exception ex)
            {
               
                this.Err = ex.Message;
                return -1;
            }
        }
        /// <summary>
        /// 变更身份
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="newobj"></param>
        /// <param name="oldobj"></param>
        /// <returns></returns>
        public int SetPactShiftData(Neusoft.HISFC.Models.RADT.PatientInfo patient, Neusoft.FrameWork.Models.NeuObject newobj, Neusoft.FrameWork.Models.NeuObject oldobj)
        {
            this.SetDB(inPatienMgr);
            return inPatienMgr.SetPactShiftData(patient, newobj, oldobj);
        }

        #endregion

        #region 更新患者状态

        /// <summary>
        /// 更新患者在院状态
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="patientStatus"></param>
        /// <returns></returns>
        public int UpdatePatientState(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo,Neusoft.HISFC.Models.RADT.InStateEnumService patientStatus)
        {
            this.SetDB(radtManager);

            return radtManager.UpdatePatientStatus(patientInfo, patientStatus);
        }

        #endregion

        #region 急诊留观
        public int RegisterObservePatient(Neusoft.HISFC.Models.Registration.Register outPatient)
        { 
            this.SetDB(radtEmrManager);
            return radtEmrManager.RegisterObservePatient(outPatient);
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        /// <summary>
        /// 留观患者出关函数
        /// </summary>
        /// <returns></returns>
        public int OutObservePatientManager(Neusoft.HISFC.Models.Registration.Register OutPatient, Neusoft.HISFC.Models.Base.EnumShiftType type,string notes)
        {
            this.SetDB(radtEmrManager);
            return radtEmrManager.OutObservePatientManager(OutPatient, type,notes);
        }
        #endregion

        #region 更改患者病情{F0C48258-8EFB-4356-B730-E852EE4888A0}
        /// <summary>
        /// 更新患者病情状态（更新为病重）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateBZ_Info(string id)
        {
            this.SetDB(radtManager);
            return this.radtManager.UpdateBZ_Info(id);
        }
        /// <summary>
        /// 更新患者病情状态（更新为普通）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdatePT_Info(string id)
        {
            this.SetDB(radtManager);
            return this.radtManager.UpdatePT_Info(id);
        }

        public string SelectBQ_Info(string id)
        {
            this.SetDB(radtManager);
            return this.radtManager.SelectBQ_Info(id);
        }
        //{F0C48258-8EFB-4356-B730-E852EE4888A0}
        #endregion

        #region 取全院某一天的住院日报数据{A500A213-41EC-4d2f-87DA-4A2BB0D635A4}
        public ArrayList GetInpatientDayReportList(DateTime dateStat) 
        {
            this.SetDB(indrManager);
            return indrManager.GetInpatientDayReportList(dateStat);
        }
        #endregion

        #region 取全院某一天的住院日报数据{CB8DF724-12C6-47b9-A375-0F32167A6659}
        public ArrayList GetDayReportDetailList(DateTime dateBegin, DateTime dateEnd, string deptCode, string nurseCellCode) 
        {
            this.SetDB(indrManager);
            return indrManager.GetDayReportDetailList(dateBegin, dateEnd,deptCode,nurseCellCode);
        }
        #endregion

        #region 更新住院日报汇总表中一条记录{563EE3FB-8744-478a-8A63-B383DF637E94}
        public int UpdateInpatientDayReport(Neusoft.HISFC.Models.HealthRecord.InpatientDayReport dayReport)
        {
            this.SetDB(indrManager);
            return indrManager.UpdateInpatientDayReport(dayReport);
        }
        #endregion

        #region 向住院日报汇总表中插入一条记录{C4275ACD-5523-4c15-903B-473527F0B43D}
        public int InsertInpatientDayReport(Neusoft.HISFC.Models.HealthRecord.InpatientDayReport dayReport)
        {
            this.SetDB(indrManager);
            return indrManager.InsertInpatientDayReport(dayReport);
        }
        #endregion
    }

    ///// <summary>
    ///// 出院登记接口
    ///// </summary>
    //public interface IucOutPatient
    //{
    //    bool IsSelect
    //    {
    //        set;
    //    }
    //}
    ///// <summary>
    ///// 护士站出院召回接口
    ///// </summary>
    //public interface ICallBackPatient
    //{
    //    bool IsSelect
    //    {
    //        set;
    //    }
    //}

    ///// <summary>
    ///// 出院、出院召回等地方的判断,是否可以执行下一步操作
    ///// </summary>
    //public interface IPatientShiftValid
    //{
    //    /// <summary>
    //    /// 出院、出院召回等地方的判断,是否可以执行下一步操作
    //    /// </summary>
    //    /// <param name="p">患者信息</param>
    //    /// <param name="type">操作类型</param>
    //    /// <param name="err">错误</param>
    //    /// <returns>true判断成功 false错误返回错误err</returns>
    //    bool IsPatientShiftValid(Neusoft.HISFC.Models.RADT.PatientInfo p, EnumPatientShiftValid type, ref string err);
    //}

}

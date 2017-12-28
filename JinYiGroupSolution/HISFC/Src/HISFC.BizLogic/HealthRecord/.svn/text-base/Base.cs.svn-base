using System;
using System.Collections;
using System.Data;


namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// BaseDML 的摘要说明。
    /// </summary>
    public class Base : Neusoft.FrameWork.Management.Database
    {
        public Base()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}

        /// <summary>
        /// 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
        /// </summary>
        private string sqlSelectByName = @"
           select 
                  n.dept_name 出院科室,
                  n.out_date 出院日期,
                  n.name 姓名, 
                  n.sex_code 性别,
                  (select t.case_no  from met_cas_base t where t.inpatient_no = n.inpatient_no) 病案号, 
                  n.patient_no 住院号,
                  n.inpatient_no 住院流水号,
                  (select t.in_times  from met_cas_base t where t.inpatient_no = n.inpatient_no) 住院次数,
                  (select '病案信息'  from met_cas_base t where t.inpatient_no = n.inpatient_no) 类型,
                  (select t.birthday  from met_cas_base t where t.inpatient_no = n.inpatient_no) 生日,
                  (select t.home_add  from met_cas_base t where t.inpatient_no = n.inpatient_no) 地址,
                  n.in_state 在院状态,
                  (select t.case_stus  from met_cas_base t where t.inpatient_no = n.inpatient_no) 病案状态
           from  fin_ipr_inmaininfo n
           where n.name = '{0}' 
           order by n.out_date ";

        private string sqlCasSelectByPatientNo = @"
           select 
                  n.dept_name 出院科室,
                  n.out_date 出院日期,
                  n.name 姓名, 
                  n.sex_code 性别,
                  n.case_no 病案号, 
                  n.patient_no 住院号,
                  n.inpatient_no 住院流水号,
                  n.in_times 住院次数,
                  '病案信息' 类型,
                  n.birthday 生日,
                  n.home_add 地址,
                  'O' 在院状态,
                  n.case_stus 病案状态
           from  met_cas_base n
           where n.PATIENT_NO = '{0}' 
          union 
           select 
                  n.dept_name 出院科室,
                  n.out_date 出院日期,
                  n.name 姓名, 
                  n.sex_code 性别,
                  '' 病案号, 
                  n.patient_no 住院号,
                  n.inpatient_no 住院流水号,
                  1 住院次数,
                  '住院信息' 类型,
                  n.birthday 生日,
                  n.home 地址,
                  n.in_state 在院状态,
                  n.case_flag 病案状态
           from  fin_ipr_inmaininfo n
           where n.PATIENT_NO = '{0}' 
            and n.case_flag in ('1','2') ";

        private string sqlCasSelectByCasNo = @"
           select 
                  n.dept_name 出院科室,
                  n.out_date 出院日期,
                  n.name 姓名, 
                  n.sex_code 性别,
                  n.case_no 病案号, 
                  n.patient_no 住院号,
                  n.inpatient_no 住院流水号,
                  n.in_times 住院次数,
                  '病案信息' 类型,
                  n.birthday 生日,
                  n.home_add 地址,
                  'O' 在院状态,
                  n.case_stus 病案状态
           from  met_cas_base n
           where n.case_no = '{0}' 
           order by n.out_date ";

        private string sqlCasSelectByName = @"
           select 
                  n.dept_name 出院科室,
                  n.out_date 出院日期,
                  n.name 姓名, 
                  n.sex_code 性别,
                  n.case_no 病案号, 
                  n.patient_no 住院号,
                  n.inpatient_no 住院流水号,
                  n.in_times 住院次数,
                  '病案信息' 类型,
                  n.birthday 生日,
                  n.home_add 地址,
                  'O' 在院状态,
                  n.case_stus 病案状态
           from  met_cas_base n
           where n.name = '{0}'  
            and n.case_stus <> '5'
           order by n.out_date ";

        private string sqlSelectByDeptCode = @"
                select t.name,
                       t.patient_no,
                       t.inpatient_no,
                       t.dept_code,
                       t.dept_name,
                       t.in_date,
                       t.out_date,
                       t.charge_doc_code,
                       t.CHARGE_DOC_NAME,
                       t.balance_cost,
                       t.sex_code,
                       t.birthday,
                       t.pact_name
                from fin_ipr_inmaininfo t
                where t.in_state = 'O'
                and  (t.dept_code = '{0}' OR  'ALL' =  '{0}')  
                and t.case_flag in ('1','2') 
                order by t.out_date ";

        private string sqlSelectRecallCas = @"
                select t.name,
                       t.patient_no,
                       t.inpatient_no,
                       t.dept_code,
                       t.dept_name,
                       t.in_date,
                       t.out_date,
                       t.charge_doc_code,
                       t.CHARGE_DOC_NAME,
                       t.balance_cost,
                       t.sex_code,
                       t.birthday,
                       t.pact_name
                from fin_ipr_inmaininfo t,met_cas_base n
                where t.in_state = 'O'
                and t.inpatient_no = n.inpatient_no
                and n.case_stus = '5'
                and  (t.dept_code = '{0}' OR  'ALL' =  '{0}')  
                order by t.out_date  ";

        #endregion

        #region 病案首页 患者基本信息操作函数

        #region 更新
        /// <summary>
        /// 更新患者在住院主表的登记病案标记
        /// </summary>
        /// <param name="inpatientNO">住院流水号</param>
        /// <param name="caseState">病案状态: 0 无需病案 1 需要病案 2 医生站形成病案 3 病案室形成病案 4病案封存 </param>
        /// <returns> 成功返回</returns>
        public int UpdateMainInfoCaseFlag(string inpatientNO, string caseState)
        {
            string strSQL = "";

            if (Sql.GetSql("CASE.BaseDML.UpdateMainInfoCaseFlag.Update", ref strSQL) == 0)
            {
                try
                {
                    strSQL = string.Format(strSQL, inpatientNO, caseState);
                }
                catch(Exception ex ) 
                {
                    this.Err = ex.Message;
                    return -1;
                }
            }

            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新患者在住院主表的登记病案标记
        /// </summary>
        /// <param name="inpatientNO">住院流水号 </param>
        /// <param name="caseSendFlag">病案送入病案室否0未1送  </param>
        /// <returns> 成功返回</returns>
        public int UpdateMainInfoCaseSendFlag(string inpatientNO, string caseSendFlag)
        {
            string strSQL = "";

            if (Sql.GetSql("CASE.BaseDML.UpdateMainInfoCaseFlag.Update", ref strSQL) == 0)
            {
                try
                {
                    strSQL = string.Format(strSQL, inpatientNO, caseSendFlag);
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    return -1;
                }
            }

            return this.ExecNoQuery(strSQL);
        }
        /// <summary>
        /// 更新病案主表
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public int UpdateBaseInfo(Neusoft.HISFC.Models.HealthRecord.Base b)
        {
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.UpdateBaseInfo.Update", ref strSql) == -1) return -1; 
            return this.ExecNoQuery(strSql, GetBaseInfo(b));
        }
        #endregion 

        /// <summary>
        /// 查询未登记病案信息的患者的诊断信息,从met_com_diagnose中提取
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <param name="diagType">诊断类别,要提取所有诊断输入%</param>
        /// <returns>诊断信息数组</returns>
        public ArrayList QueryInhosDiagnoseInfo(string inpatientNO, string diagType)
        {
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetInhosDiagInfo.Select", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, inpatientNO, diagType);

            return this.myGetDiagInfo(strSql);
        }

        /// <summary>
        /// 从病案基本表中获取信息
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <returns></returns>
        public Neusoft.HISFC.Models.HealthRecord.Base GetCaseBaseInfo(string inpatientNO)
        {
            Neusoft.HISFC.Models.HealthRecord.Base info = new Neusoft.HISFC.Models.HealthRecord.Base();
            //获取主sql语句
            string strSQL = GetCaseSql();
            if (strSQL == null)
            {
                return null;
            }
            string str = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetCaseBaseInfo.Select.where", ref str) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSQL += str;
            strSQL = string.Format(strSQL, inpatientNO);
            ArrayList arrList = this.myGetCaseBaseInfo(strSQL);
            if (arrList == null)
            {
                return null;
            }
            if (arrList.Count > 0)
            {
                info = (Neusoft.HISFC.Models.HealthRecord.Base)arrList[0];
            }
            return info;
        }
       
        /// <summary>
        /// 根据病案号获取信息
        /// </summary>
        /// <param name="CaseNo"></param>
        /// <returns></returns>
        public ArrayList QueryCaseBaseInfoByCaseNO(string CaseNo)
        {
            ArrayList list = new ArrayList();
            //获取主sql语句
            string strSQL = GetCaseSql();
            string str = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetCaseBaseInfoByCaseNum.Select.where", ref str) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSQL += str;
            strSQL = string.Format(strSQL, CaseNo);
            return this.myGetCaseBaseInfo(strSQL);
        } 
        /// <summary>
        /// 向病案主表中插入一条记录
        /// </summary>
        /// <param name="b"></param>
        /// <returns> 成功返回 1 失败返回－1 ，0  </returns>
        public int InsertBaseInfo(Neusoft.HISFC.Models.HealthRecord.Base b)
        {
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.InsertBaseInfo.Insert", ref strSql) == -1) return -1; 
            return this.ExecNoQuery(strSql, GetBaseInfo(b));
        }
        
        /// <summary>
        /// 根据住院号和住院次数查询住院流水号 
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="InNum"></param>
        /// <returns></returns>
        public ArrayList QueryPatientInfoByInpatientAndInNum(string inpatientNO, string InNum)
        {
            //先从病案主表中查询 如果没有查到 再在住院主表中查询 
            ArrayList list = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetPatientInfo.GetPatientInfo", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, inpatientNO, InNum);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.RADT.PatientInfo info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.RADT.PatientInfo();
                info.ID = this.Reader[0].ToString();
                list.Add(info);
                info = null;
            }
            if (list == null)
            {
                return list;
            }
            if (list.Count == 0)
            {
                //查询住院主表 获取病人信息
                if (this.Sql.GetSql("RADT.Inpatient.PatientInfoGetByTime", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return null;
                }
                strSql = string.Format(strSql, inpatientNO, InNum);
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    info.ID = this.Reader[0].ToString();
                    list.Add(info);
                    info = null;
                }
            }
            return list;
        }
        /// <summary>
        /// 根据住院号查询 病案信息和住院信息
        /// </summary>
        /// <param name="PatientNO"></param>
        /// <returns></returns>
        public ArrayList QueryPatientInfo(string PatientNO)
        {
            //先从病案主表中查询 如果没有查到 再在住院主表中查询 
            ArrayList list = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetPatientInfo.GetPatientInfo", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, PatientNO);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.HealthRecord.Base info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.HealthRecord.Base();
                info.OutDept.Name = this.Reader[0].ToString(); //出院科室
                info.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString()); //出院日期
                info.PatientInfo.Name = this.Reader[2].ToString(); //姓名
                info.PatientInfo.Sex.ID = this.Reader[3].ToString(); //性别
                info.CaseNO = this.Reader[4].ToString(); //病案号
                info.PatientInfo.PID.PatientNO = this.Reader[5].ToString(); //住院号
                info.PatientInfo.ID = this.Reader[6].ToString(); //住院流水号
                info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //住院次数
                info.PatientInfo.User01 = this.Reader[8].ToString();
                list.Add(info);
                info = null;
            }
           
            return list;
        }

        /// <summary>
        /// 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList QueryPatientInfoByName(string name)
        {            //先从病案主表中查询 如果没有查到 再在住院主表中查询 
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlSelectByName, name);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.HealthRecord.Base info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.HealthRecord.Base();
                info.OutDept.Name = this.Reader[0].ToString(); //出院科室
                info.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString()); //出院日期
                info.PatientInfo.Name = this.Reader[2].ToString(); //姓名
                info.PatientInfo.Sex.ID = this.Reader[3].ToString(); //性别
                info.CaseNO = this.Reader[4].ToString(); //病案号
                info.PatientInfo.PID.PatientNO = this.Reader[5].ToString(); //住院号
                info.PatientInfo.ID = this.Reader[6].ToString(); //住院流水号
                info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //住院次数
                info.PatientInfo.User01 = this.Reader[8].ToString();
                info.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString()); //生日
                info.PatientInfo.AddressHome = this.Reader[10].ToString();
                info.PatientInfo.PVisit.InState.ID = this.Reader[11].ToString();
                info.CaseStat = this.Reader[12].ToString();
                list.Add(info);
                info = null;
            }

            return list;
        }
        public ArrayList QueryCasInfoByPatientNo(string patientNo)
        {
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlCasSelectByPatientNo, patientNo);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.HealthRecord.Base info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.HealthRecord.Base();
                info.OutDept.Name = this.Reader[0].ToString(); //出院科室
                info.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString()); //出院日期
                info.PatientInfo.Name = this.Reader[2].ToString(); //姓名
                info.PatientInfo.Sex.ID = this.Reader[3].ToString(); //性别
                info.CaseNO = this.Reader[4].ToString(); //病案号
                info.PatientInfo.PID.PatientNO = this.Reader[5].ToString(); //住院号
                info.PatientInfo.ID = this.Reader[6].ToString(); //住院流水号
                info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //住院次数
                info.PatientInfo.User01 = this.Reader[8].ToString();
                info.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString()); //生日
                info.PatientInfo.AddressHome = this.Reader[10].ToString();
                info.PatientInfo.PVisit.InState.ID = this.Reader[11].ToString();
                info.CaseStat = this.Reader[12].ToString();
                list.Add(info);
                info = null;
            }

            return list;
        }
        public ArrayList QueryCasInfoByCasNo(string casNo)
        {
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlCasSelectByCasNo, casNo);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.HealthRecord.Base info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.HealthRecord.Base();
                info.OutDept.Name = this.Reader[0].ToString(); //出院科室
                info.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString()); //出院日期
                info.PatientInfo.Name = this.Reader[2].ToString(); //姓名
                info.PatientInfo.Sex.ID = this.Reader[3].ToString(); //性别
                info.CaseNO = this.Reader[4].ToString(); //病案号
                info.PatientInfo.PID.PatientNO = this.Reader[5].ToString(); //住院号
                info.PatientInfo.ID = this.Reader[6].ToString(); //住院流水号
                info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //住院次数
                info.PatientInfo.User01 = this.Reader[8].ToString();
                info.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString()); //生日
                info.PatientInfo.AddressHome = this.Reader[10].ToString();
                info.PatientInfo.PVisit.InState.ID = this.Reader[11].ToString();
                info.CaseStat = this.Reader[12].ToString();
                list.Add(info);
                info = null;
            }

            return list;
        }

        /// <summary>
        /// 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList QueryCasInfoByName(string name)
        {            //先从病案主表中查询 如果没有查到 再在住院主表中查询 
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlCasSelectByName, name);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.HealthRecord.Base info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.HealthRecord.Base();
                info.OutDept.Name = this.Reader[0].ToString(); //出院科室
                info.PatientInfo.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[1].ToString()); //出院日期
                info.PatientInfo.Name = this.Reader[2].ToString(); //姓名
                info.PatientInfo.Sex.ID = this.Reader[3].ToString(); //性别
                info.CaseNO = this.Reader[4].ToString(); //病案号
                info.PatientInfo.PID.PatientNO = this.Reader[5].ToString(); //住院号
                info.PatientInfo.ID = this.Reader[6].ToString(); //住院流水号
                info.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[7]); //住院次数
                info.PatientInfo.User01 = this.Reader[8].ToString();
                info.PatientInfo.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[9].ToString()); //生日
                info.PatientInfo.AddressHome = this.Reader[10].ToString();
                info.PatientInfo.PVisit.InState.ID = this.Reader[11].ToString();
                info.CaseStat = this.Reader[12].ToString();
                list.Add(info);
                info = null;
            }

            return list;
        }
        public ArrayList QueryPatientOutHospitalByDept(string deptCode)
        {
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlSelectByDeptCode, deptCode);
            this.ExecQuery(strSql);
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patientObj = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    patientObj.Name = this.Reader[0].ToString();
                    patientObj.PID.PatientNO = this.Reader[1].ToString();
                    patientObj.ID = this.Reader[2].ToString();
                    patientObj.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString();
                    patientObj.PVisit.PatientLocation.Dept.Name = this.Reader[4].ToString();
                    patientObj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());
                    patientObj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());
                    patientObj.PVisit.AttendingDoctor.ID = this.Reader[7].ToString();
                    patientObj.PVisit.AttendingDoctor.Name = this.Reader[8].ToString();
                    patientObj.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
                    patientObj.Sex.ID = this.Reader[10].ToString();
                    patientObj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
                    patientObj.Pact.Name = this.Reader[12].ToString();

                    list.Add(patientObj);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                this.Err = "获得患者住院信息出错!" + ex.Message;
                return null;
            }
            return list;
        }

        public ArrayList QueryRecallCasByDept(string deptCode)
        {
            ArrayList list = new ArrayList();
            string strSql = string.Format(this.sqlSelectRecallCas, deptCode);
            this.ExecQuery(strSql);
            try
            {
                while (this.Reader.Read())
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patientObj = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    patientObj.Name = this.Reader[0].ToString();
                    patientObj.PID.PatientNO = this.Reader[1].ToString();
                    patientObj.ID = this.Reader[2].ToString();
                    patientObj.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString();
                    patientObj.PVisit.PatientLocation.Dept.Name = this.Reader[4].ToString();
                    patientObj.PVisit.InTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[5].ToString());
                    patientObj.PVisit.OutTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());
                    patientObj.PVisit.AttendingDoctor.ID = this.Reader[7].ToString();
                    patientObj.PVisit.AttendingDoctor.Name = this.Reader[8].ToString();
                    patientObj.FT.TotCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[9].ToString());
                    patientObj.Sex.ID = this.Reader[10].ToString();
                    patientObj.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());
                    patientObj.Pact.Name = this.Reader[12].ToString();

                    list.Add(patientObj);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                this.Err = "获得患者住院信息出错!" + ex.Message;
                return null;
            }
            return list;
        }

        public int UpdateBaseDiagAndOperation(string inpatienNO, Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType)
        {

            Neusoft.HISFC.BizLogic.HealthRecord.Diagnose dia = new Neusoft.HISFC.BizLogic.HealthRecord.Diagnose();
            Neusoft.HISFC.BizLogic.HealthRecord.Operation op = new Operation();
             if (this.Trans != null)
            {
                dia.SetTrans(Trans);
                op.SetTrans(Trans);
            }
            Neusoft.HISFC.Models.HealthRecord.Diagnose ClinicDiag = dia.GetFirstDiagnose(inpatienNO, Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.CLINIC, frmType);
            Neusoft.HISFC.Models.HealthRecord.Diagnose InhosDiag = dia.GetFirstDiagnose(inpatienNO, Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.IN, frmType);
            Neusoft.HISFC.Models.HealthRecord.Diagnose OutDiag = dia.GetFirstDiagnose(inpatienNO, Neusoft.HISFC.Models.HealthRecord.DiagnoseType.enuDiagnoseType.OUT, frmType);
            Neusoft.HISFC.Models.HealthRecord.OperationDetail ops = op.GetFirstOperation(inpatienNO, frmType);
            if (ClinicDiag == null || InhosDiag == null || OutDiag == null || ops == null)
            {
                return -1;
            }
            string[] str = new string[14];
            str[0] = inpatienNO;
            str[1] = ClinicDiag.DiagInfo.ICD10.ID;
            str[2] = ClinicDiag.DiagInfo.ICD10.Name;
            str[3] = InhosDiag.DiagInfo.ICD10.ID;
            str[4] = InhosDiag.DiagInfo.ICD10.Name;
            str[5] = OutDiag.DiagInfo.ICD10.ID;
            str[6] = OutDiag.DiagInfo.ICD10.Name;
            str[7] = OutDiag.DiagOutState;
            str[8] = OutDiag.CLPA;
            str[9] = ops.OperationInfo.ID;
            str[10] = ops.OperationInfo.Name;
            str[11] = ops.FirDoctInfo.ID;
            str[12] = ops.FirDoctInfo.Name;
            str[13] = ops.OperationDate.ToString();
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.UpdateBaseDiagAndOperation", ref strSql) == -1) return -1;

            strSql = string.Format(strSql, str);
            return this.ExecNoQuery(strSql);

        }
        /// <summary>
        /// 更新诊断表和手术表中的出院日期和出院科室 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DiagnoseAndOperation(Neusoft.FrameWork.Models.NeuObject obj, string InpatientNo)
        {
            //obj.User01 出院日期
            //obj.User02 出院科室
            string strSql1 = "";
            string strSql2 = "";
            //诊断
            if (this.Sql.GetSql("CASE.Diagnose.DiagnoseAndOperation.1", ref strSql1) == -1) return -1;
            //手术 
            if (this.Sql.GetSql("CASE.Diagnose.DiagnoseAndOperation.2", ref strSql2) == -1) return -1;
            strSql1 = string.Format(strSql1, InpatientNo, obj.User01);
            strSql2 = string.Format(strSql2, InpatientNo, obj.User01, obj.User02);
            if (this.ExecNoQuery(strSql1) != -1)
            {
                return this.ExecNoQuery(strSql2);
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 判断某个住院号的某次入院是否已经存在
        /// </summary>
        /// <param name="InpatientNO"></param>
        /// <param name="PatientNo"></param>
        /// <param name="InNum"></param>
        /// <returns>没有记录 返回 0 ,查询失败返回-1 ,住院号,住院流水号,住院次数全相同 返回 1 住院号住院次数相同 ,住院流水号不同 返回2</returns>
        public int ExistCase(string InpatientNO, string PatientNo, string InNum)
        {
            string strSQL = GetCaseSql();
            string str = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetCaseBaseInfoByCaseNum.Select.ExistCase", ref str) == -1)
            {
                this.Err = "获取SQL语句失败";
                return -1;
            }
            strSQL += str;
            strSQL = string.Format(strSQL, PatientNo, InNum);
            ArrayList List = this.myGetCaseBaseInfo(strSQL);
            if (List == null)
            {
                return -1; //查询出错 
            }
            if (List.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.HealthRecord.Base obj in List)
                {
                    if (obj.PatientInfo.ID == InpatientNO) //住院流水号相同 住院号相同 住院次数相同 
                    {
                        return 1; //一般执行更新操作 
                    }
                }
                return 2; //住院号相同,住院次数相同 住院流水号不同 ,一般是住院次数填写错了 
            }
            return 0; //没有查到相关的记录 一般执行插入操作
        }

       /// <summary>
        /// 获取一段时间的患者
       /// </summary>
       /// <param name="BeginTime">开始时间</param>
       /// <param name="EndTime">结束时间</param>
       /// <param name="DeptCode">科室编码</param>
       /// <returns></returns>
        public ArrayList QueryPatientOutHospital(string BeginTime, string EndTime,string DeptCode)
        {
            ArrayList list = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.QueryPatientOutHospital", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, BeginTime, EndTime, DeptCode); 
             this.ExecQuery(strSql); 
             try
             {
                 while (this.Reader.Read())
                 {
                     Neusoft.HISFC.Models.RADT.PatientInfo patientObj = new Neusoft.HISFC.Models.RADT.PatientInfo();
                     patientObj.Name = this.Reader[0].ToString();
                     patientObj.PID.PatientNO = this.Reader[1].ToString();
                     patientObj.ID = this.Reader[2].ToString();
                     //{C80E9978-D3E3-4af7-92F3-D91ED5288419} 显示时按照科室列表分组
                     patientObj.PVisit.PatientLocation.Dept.ID = this.Reader[3].ToString();
                     patientObj.PVisit.PatientLocation.Dept.Name = this.Reader[4].ToString();
                     list.Add(patientObj);
                 }
                 this.Reader.Close();
             }
             catch (Exception ex)
             {
                 if (!this.Reader.IsClosed)
                 {
                     this.Reader.Close();
                 }
                 this.Err = "获得患者住院诊断信息出错!" + ex.Message;
                 return null;
             }
             return list;
        }

        public int UpdateCasBaseRecallDate(string inpatientNo, DateTime recallDate)
        {
            string sql = @" update MET_CAS_BASE set RECALL_DATE = to_date('{1}','yyyy-mm-dd hh24:mi:ss') where INPATIENT_NO = '{0}' ";
            return this.ExecNoQuery(string.Format(sql, inpatientNo, recallDate.ToString("yyyy-MM-dd HH:mm:ss")));
        }

        /// <summary>
        /// 获取手工录入病案时的住院流水号
        /// </summary>
        /// <returns></returns>
        public string GetCaseInpatientNO()
        {
            string str = this.GetSequence("CASE.BaseDML.GetCaseInpatientNO");
            if (str == null || str == "")
            {
                return str;
            }
            else
            {
                str = "BA" + str.PadLeft(12, '0');
            }
            return str;
        }
        #endregion

        //{7D094A18-0FC9-4e8b-A8E6-901E55D4C20C}

        #region  私有函数
        
        
       

        /// <summary>
        /// 将实体 转变成字符串数组
        /// </summary>
        /// <param name="b"> 病案的实体类</param>
        /// <returns>失败返回null</returns>
        private string[] GetBaseInfo(Neusoft.HISFC.Models.HealthRecord.Base b)
        {
            string[] s = new string[157];//{2FDCC429-B30E-463c-AAD6-6BADCE600458}
            try
            {
                s[0] = b.PatientInfo.ID;//住院流水号

                s[1] = b.PatientInfo.PID.PatientNO;//住院病历号

                s[2] = b.PatientInfo.PID.CardNO;//卡号

                s[3] = b.PatientInfo.Name;//姓名

                s[4] = b.Nomen;//曾用名

                s[5] = b.PatientInfo.Sex.ID.ToString();//性别

                s[6] = b.PatientInfo.Birthday.ToString();//出生日期

                s[7] = b.PatientInfo.Country.ID;//国家

                s[8] = b.PatientInfo.Nationality.ID;//民族

                s[9] = b.PatientInfo.Profession.ID;//职业

                s[10] = b.PatientInfo.BloodType.ID.ToString();//血型编码

                s[11] = b.PatientInfo.MaritalStatus.ID.ToString();//婚否

                s[12] = b.PatientInfo.Age.ToString();//年龄

                s[13] = b.AgeUnit;//年龄单位

                s[14] = b.PatientInfo.IDCard;//身份证号

                s[15] = b.PatientInfo.PVisit.InSource.ID;//地区来源

                s[16] = b.PatientInfo.Pact.ID;//结算类别号

                s[17] = b.PatientInfo.Pact.ID;//合同代码

                s[18] = b.PatientInfo.SSN;//医保公费号

                s[19] = b.PatientInfo.DIST;//籍贯

                s[20] = b.PatientInfo.AreaCode;//出生地

                s[21] = b.PatientInfo.AddressHome;//家庭住址

                s[22] = b.PatientInfo.PhoneHome;//家庭电话

                s[23] = b.PatientInfo.HomeZip;//住址邮编

                s[24] = b.PatientInfo.AddressBusiness;//单位地址

                s[25] = b.PatientInfo.PhoneBusiness;//单位电话

                s[26] = b.PatientInfo.BusinessZip;//单位邮编

                s[27] = b.PatientInfo.Kin.Name;//联系人

                s[28] = b.PatientInfo.Kin.RelationLink;//与患者关系

                s[29] = b.PatientInfo.Kin.RelationPhone;//联系电话

                s[30] = b.PatientInfo.Kin.RelationAddress;//联系地址

                s[31] = b.ClinicDoc.ID;//门诊诊断医生

                s[32] = b.ClinicDoc.Name;//门诊诊断医生姓名

                s[33] = b.ComeFrom;//转来医院

                s[34] = b.PatientInfo.PVisit.InTime.ToString();//入院日期

                s[35] = b.PatientInfo.InTimes.ToString();//住院次数

                s[36] = b.InDept.ID;//入院科室代码

                s[37] = b.InDept.Name;//入院科室名称

                s[38] = b.PatientInfo.PVisit.InSource.ID;//入院来源

                s[39] = b.PatientInfo.PVisit.Circs.ID;//入院状态

                s[40] = b.DiagDate.ToString();//确诊日期

                s[41] = b.OperationDate.ToString();//手术日期

                s[42] = b.PatientInfo.PVisit.OutTime.ToString();//出院日期

                s[43] = b.OutDept.ID;//出院科室代码

                s[44] = b.OutDept.Name;//出院科室名称

                s[45] = b.PatientInfo.PVisit.ZG.ID;//转归代码

                s[46] = b.DiagDays.ToString();//确诊天数

                s[47] = b.InHospitalDays.ToString();//住院天数

                s[48] = b.DeadDate.ToString();//死亡日期

                s[49] = b.DeadReason;//死亡原因

                s[50] = b.CadaverCheck;//尸检

                s[51] = b.DeadKind;//死亡种类

                s[52] = b.BodyAnotomize;//尸体解剖号

                s[53] = b.Hbsag;//乙肝表面抗原

                s[54] = b.HcvAb;//丙肝病毒抗体

                s[55] = b.HivAb;//获得性人类免疫缺陷病毒抗体

                s[56] = b.CePi;//门急_入院符合

                s[57] = b.PiPo;//入出_院符合

                s[58] = b.OpbOpa;//术前_后符合

                s[59] = b.ClX;//临床_X光符合

                s[60] = b.ClCt;//临床_CT符合

                s[61] = b.ClMri;//临床_MRI符合

                s[62] = b.ClPa;//临床_病理符合

                s[63] = b.FsBl;//放射_病理符合

                s[64] = b.SalvTimes.ToString();//抢救次数

                s[65] = b.SuccTimes.ToString();//成功次数

                s[66] = b.TechSerc;//示教科研

                s[67] = b.VisiStat;//是否随诊

                s[68] = b.VisiPeriod.ToString();//随访期限

                s[69] = b.InconNum.ToString();//院际会诊次数 70 远程会诊次数

                s[70] = b.OutconNum.ToString();//院际会诊次数 70 远程会诊次数

                s[71] = b.AnaphyFlag;//药物过敏

                s[72] = b.FirstAnaphyPharmacy.ID;//过敏药物名称

                s[73] = b.SecondAnaphyPharmacy.ID;//过敏药物名称

                s[74] = b.CoutDate.ToString();//更改后出院日期

                s[75] = b.PatientInfo.PVisit.AdmittingDoctor.ID;//住院医师代码

                s[76] = b.PatientInfo.PVisit.AdmittingDoctor.Name;//住院医师姓名

                s[77] = b.PatientInfo.PVisit.AttendingDoctor.ID;//主治医师代码

                s[78] = b.PatientInfo.PVisit.AttendingDoctor.Name;//主治医师姓名

                s[79] = b.PatientInfo.PVisit.ConsultingDoctor.ID;//主任医师代码

                s[80] = b.PatientInfo.PVisit.ConsultingDoctor.Name;//主任医师姓名

                s[81] = b.PatientInfo.PVisit.ReferringDoctor.ID;//科主任代码

                s[82] = b.PatientInfo.PVisit.ReferringDoctor.Name;//科主任名称

                s[83] = b.RefresherDoc.ID;//进修医师代码

                s[84] = b.RefresherDoc.Name;//进修医生名称

                s[85] = b.GraduateDoc.ID;//研究生实习医师代码

                s[86] = b.GraduateDoc.Name;//研究生实习医师名称

                s[87] = b.PatientInfo.PVisit.TempDoctor.ID;//实习医师代码

                s[88] = b.PatientInfo.PVisit.TempDoctor.Name;//实习医师名称

                s[89] = b.CodingOper.ID;//编码员代码

                s[90] = b.CodingOper.Name;//编码员名称

                s[91] = b.MrQuality;//病案质量

                s[92] = b.MrEligible;//合格病案

                s[93] = b.QcDoc.ID;//质控医师代码

                s[94] = b.QcDoc.Name;//质控医师名称

                s[95] = b.QcNurse.ID;//质控护士代码

                s[96] = b.QcNurse.Name;//质控护士名称

                s[97] = b.CheckDate.ToString();//检查时间

                s[98] = b.YnFirst;//手术操作治疗检查诊断为本院第一例项目

                s[99] = b.RhBlood;//Rh血型(阴阳)

                s[100] = b.ReactionBlood;//输血反应（有无）

                s[101] = b.BloodRed;//红细胞数

                s[102] = b.BloodPlatelet;//血小板数

                s[103] = b.BodyAnotomize;//血浆数

                s[104] = b.BloodWhole;//全血数

                s[105] = b.BloodOther;//其他输血数

                s[106] = b.XNum;//X光号

                s[107] = b.CtNum;//CT号

                s[108] = b.MriNum;//MRI号

                s[109] = b.PathNum;//病理号

                s[110] = b.DsaNum;//DSA号

                s[111] = b.PetNum;//PET号

                s[112] = b.EctNum;//ECT号

                s[113] = b.XQty.ToString();//X线次数

                s[114] = b.CTQty.ToString();//CT次数

                s[115] = b.MRQty.ToString();//MR次数

                s[116] = b.DSAQty.ToString();//DSA次数

                s[117] = b.PetQty.ToString();//PET次数

                s[118] = b.EctQty.ToString();//ECT次数

                s[119] = b.PatientInfo.Memo;//说明

                s[120] = b.BarCode;//归档条码号

                s[121] = b.LendStat;//病案借阅状态(O借出 I在架)

                s[122] = b.PatientInfo.CaseState;//病案状态1科室质检2登记保存3整理4病案室质检5无效

                s[123] = b.OperInfo.ID;//操作员

                //				s[124]=b.OperDate.ToString() ;//操作时间
                s[124] = b.VisiPeriodWeek; //随访期限 周
                s[125] = b.VisiPeriodMonth; //随访期限 月
                s[126] = b.VisiPeriodYear;//随访期限 年
                s[127] = b.SpecalNus.ToString();  // 特殊护理(日)                                        
                s[128] = b.INus.ToString(); //I级护理时间(日)                                     
                s[129] = b.IINus.ToString(); //II级护理时间(日)                                    
                s[130] = b.IIINus.ToString(); //III级护理时间(日)                                   
                s[131] = b.StrictNuss.ToString(); //重症监护时间( 小时)                                 
                s[132] = b.SuperNus.ToString(); //特级护理时间(小时)     
                s[133] = b.PackupMan.ID; //整理员
                s[134] = b.Disease30; //单病种 
                s[135] = b.IsHandCraft;//手工录入病案 标志
                s[136] = b.SyndromeFlag; //是否有并犯症
                s[137] = b.InfectionNum.ToString();//院内感染次数 
                s[138] = b.OperationCoding.ID;//手术编码员 
                s[139] = b.CaseNO;//病案号
                s[140] = b.InfectionPosition.ID; //院内感染部位编码
                s[141] = b.InfectionPosition.Name; //院内感染部位名称

                s[142] = b.Out_Type ; //出院方式（1、常规 2、自动 3、转院）
                s[143] = b.Cure_Type ; //治疗类别（1、中      2、西      3、中西）
                s[144] = b.Use_CHA_Med ; //自制中药制剂（0、未知   1、有    2、无）
                s[145] = b.Save_Type ; //抢救方法（1、中     2、西       3、中西）
                s[146] = b.Ever_Sickintodeath ; //是否出现危重（１、是　　　０、否）
                s[147] = b.Ever_Firstaid ; //是否出现急症（１、是　　　０、否）
                s[148] = b.Ever_Difficulty; //是否出现疑难情况（１、是　０、否）
                s[149] = b.ReactionLiquid; //输液反应（１、有　２、无　３、未输）

                #region{2FDCC429-B30E-463c-AAD6-6BADCE600458}
                s[150] = b.PatientInfo.PVisit.AttendingDirector.ID;//科主任
                s[151] = b.PatientInfo.PVisit.TemporaryLocation.User03;//形态学编码
                s[152] = b.PatientInfo.PVisit.TempDoctor.User01;//抗生素是否使用
                s[153] = b.PatientInfo.PVisit.TempDoctor.User02;//抗生素使用次数
                s[154] = b.PatientInfo.PVisit.TemporaryLocation.User01;//传染病卡
                s[155] = b.PatientInfo.PVisit.TemporaryLocation.User02;//肿瘤卡
                #endregion

                #region 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                s[156] = b.PatientInfo.Pact.User01;//医疗付款方式
                #endregion

                return s;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

        }
        /// <summary>
        /// 获取主sql语句
        /// </summary>
        /// <returns></returns>
        private string GetCaseSql()
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetCaseBaseInfo.Select", ref strSQL) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            return strSQL;
        }
        /// <summary>
        /// 根据SQL查询符合条件病案首页的信息
        /// zhangjunyi@neusoft.com 修改
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>失败返回 null 成功返回符合条件的信息</returns>
        private ArrayList myGetCaseBaseInfo(string strSQL)
        {
            //执行操查询操作
            this.ExecQuery(strSQL);
            //读取数据
            //			Neusoft.HISFC.Models.HealthRecord.Base b = ReaderBase();
            ArrayList list = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Base b = null;
            try
            {
                while (this.Reader.Read())
                {
                    b = new Neusoft.HISFC.Models.HealthRecord.Base();
                    b.PatientInfo.ID = this.Reader[0].ToString();//住院流水号
                    b.PatientInfo.PID.PatientNO = this.Reader[1].ToString();//住院病历号

                    b.PatientInfo.PID.CardNO = this.Reader[2].ToString();//门诊号

                    b.PatientInfo.Name = this.Reader[3].ToString();//姓名
                    b.PatientInfo.Name = this.Reader[3].ToString();
                    b.PatientInfo.PID.Name = this.Reader[3].ToString();

                    b.Nomen = this.Reader[4].ToString();//曾用名

                    b.PatientInfo.Sex.ID = this.Reader[5].ToString();//性别

                    b.PatientInfo.Birthday = System.Convert.ToDateTime(this.Reader[6].ToString());//出生日期

                    b.PatientInfo.Country.ID = this.Reader[7].ToString();//国家

                    b.PatientInfo.Nationality.ID = this.Reader[8].ToString();//民族

                    b.PatientInfo.Profession.ID = this.Reader[9].ToString();//职业

                    b.PatientInfo.BloodType.ID = this.Reader[10].ToString();//血型编码

                    b.PatientInfo.MaritalStatus.ID = this.Reader[11].ToString();//婚否

                    b.PatientInfo.Age = this.Reader[12].ToString();//年龄

                    b.AgeUnit = this.Reader[13].ToString();//年龄单位

                    b.PatientInfo.IDCard = this.Reader[14].ToString();//身份证号

                    b.PatientInfo.PVisit.InSource.ID = this.Reader[15].ToString();//地区来源

                    b.PatientInfo.Pact.ID = this.Reader[16].ToString();//结算类别号

                    b.PatientInfo.Pact.ID = this.Reader[17].ToString();//合同代码

                    b.PatientInfo.SSN = this.Reader[18].ToString();//医保公费号

                    b.PatientInfo.DIST = this.Reader[19].ToString();//籍贯

                    b.PatientInfo.AreaCode = this.Reader[20].ToString();//出生地

                    b.PatientInfo.AddressHome = this.Reader[21].ToString();//家庭住址

                    b.PatientInfo.PhoneHome = this.Reader[22].ToString();//家庭电话

                    b.PatientInfo.HomeZip = this.Reader[23].ToString();//住址邮编

                    b.PatientInfo.AddressBusiness = this.Reader[24].ToString();//单位地址

                    b.PatientInfo.PhoneBusiness = this.Reader[25].ToString();//单位电话

                    b.PatientInfo.BusinessZip = this.Reader[26].ToString();//单位邮编

                    b.PatientInfo.Kin.Name = this.Reader[27].ToString();//联系人

                    b.PatientInfo.Kin.RelationLink = this.Reader[28].ToString();//与患者关系

                    b.PatientInfo.Kin.RelationPhone = this.Reader[29].ToString();//联系电话

                    b.PatientInfo.Kin.RelationAddress = this.Reader[30].ToString();//联系地址

                    b.ClinicDoc.ID = this.Reader[31].ToString();//门诊诊断医生

                    b.ClinicDoc.Name = this.Reader[32].ToString();//门诊诊断医生姓名

                    b.ComeFrom = this.Reader[33].ToString();//转来医院

                    b.PatientInfo.PVisit.InTime = System.Convert.ToDateTime(this.Reader[34].ToString());//入院日期

                    b.PatientInfo.InTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[35].ToString());//住院次数

                    b.InDept.ID = this.Reader[36].ToString();//入院科室代码

                    b.InDept.Name = this.Reader[37].ToString();//入院科室名称

                    b.PatientInfo.PVisit.InSource.ID = this.Reader[38].ToString();//入院来源

                    b.PatientInfo.PVisit.Circs.ID = this.Reader[39].ToString();//入院状态

                    b.DiagDate = System.Convert.ToDateTime(this.Reader[40].ToString());//确诊日期

                    b.OperationDate = System.Convert.ToDateTime(this.Reader[41].ToString());//手术日期

                    b.PatientInfo.PVisit.OutTime = System.Convert.ToDateTime(this.Reader[42].ToString());//出院日期

                    b.OutDept.ID = this.Reader[43].ToString();//出院科室代码

                    b.OutDept.Name = this.Reader[44].ToString();//出院科室名称

                    b.PatientInfo.PVisit.ZG.ID = this.Reader[45].ToString();//转归代码

                    b.DiagDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[46].ToString());//确诊天数

                    b.InHospitalDays = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[47].ToString());//住院天数

                    b.DeadDate = System.Convert.ToDateTime(this.Reader[48].ToString());//死亡日期

                    b.DeadReason = this.Reader[49].ToString();//死亡原因

                    b.CadaverCheck = this.Reader[50].ToString();//尸检

                    b.DeadKind = this.Reader[51].ToString();//死亡种类

                    b.BodyAnotomize = this.Reader[52].ToString();//尸体解剖号

                    b.Hbsag = this.Reader[53].ToString();//乙肝表面抗原

                    b.HcvAb = this.Reader[54].ToString();//丙肝病毒抗体

                    b.HivAb = this.Reader[55].ToString();//获得性人类免疫缺陷病毒抗体

                    b.CePi = this.Reader[56].ToString();//门急_入院符合

                    b.PiPo = this.Reader[57].ToString();//入出_院符合

                    b.OpbOpa = this.Reader[58].ToString();//术前_后符合

                    b.ClX = this.Reader[59].ToString();//临床_X光符合

                    b.ClCt = this.Reader[60].ToString();//临床_CT符合

                    b.ClMri = this.Reader[61].ToString();//临床_MRI符合

                    b.ClPa = this.Reader[62].ToString();//临床_病理符合

                    b.FsBl = this.Reader[63].ToString();//放射_病理符合

                    b.SalvTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[64].ToString());//抢救次数

                    b.SuccTimes = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[65].ToString());//成功次数

                    b.TechSerc = this.Reader[66].ToString();//示教科研

                    b.VisiStat = this.Reader[67].ToString();//是否随诊

                    b.VisiPeriod = System.Convert.ToDateTime(this.Reader[68].ToString());//随访期限

                    b.InconNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[69].ToString());//院际会诊次数 

                    b.OutconNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[70].ToString());//70 远程会诊次数

                    b.AnaphyFlag = this.Reader[71].ToString();//药物过敏

                    b.FirstAnaphyPharmacy.ID = this.Reader[72].ToString();//过敏药物名称

                    b.SecondAnaphyPharmacy.ID = this.Reader[73].ToString();//过敏药物名称

                    b.CoutDate = System.Convert.ToDateTime(this.Reader[74].ToString());//更改后出院日期

                    b.PatientInfo.PVisit.AdmittingDoctor.ID = this.Reader[75].ToString();//住院医师代码

                    b.PatientInfo.PVisit.AdmittingDoctor.Name = this.Reader[76].ToString();//住院医师姓名

                    b.PatientInfo.PVisit.AttendingDoctor.ID = this.Reader[77].ToString();//主治医师代码

                    b.PatientInfo.PVisit.AttendingDoctor.Name = this.Reader[78].ToString();//主治医师姓名

                    b.PatientInfo.PVisit.ConsultingDoctor.ID = this.Reader[79].ToString();//主任医师代码

                    b.PatientInfo.PVisit.ConsultingDoctor.Name = this.Reader[80].ToString();//主任医师姓名

                    b.PatientInfo.PVisit.ReferringDoctor.ID = this.Reader[81].ToString();//科主任代码

                    b.PatientInfo.PVisit.ReferringDoctor.Name = this.Reader[82].ToString();//科主任名称

                    b.RefresherDoc.ID = this.Reader[83].ToString();//进修医师代码

                    b.RefresherDoc.Name = this.Reader[84].ToString();//进修医生名称

                    b.GraduateDoc.ID = this.Reader[85].ToString();//研究生实习医师代码

                    b.GraduateDoc.Name = this.Reader[86].ToString();//研究生实习医师名称

                    b.PatientInfo.PVisit.TempDoctor.ID = this.Reader[87].ToString();//实习医师代码

                    b.PatientInfo.PVisit.TempDoctor.Name = this.Reader[88].ToString();//实习医师名称

                    b.CodingOper.ID = this.Reader[89].ToString();//编码员代码

                    b.CodingOper.Name = this.Reader[90].ToString();//编码员名称

                    b.MrQuality = this.Reader[91].ToString();//病案质量

                    b.MrEligible = this.Reader[92].ToString();//合格病案

                    b.QcDoc.ID = this.Reader[93].ToString();//质控医师代码

                    b.QcDoc.Name = this.Reader[94].ToString();//质控医师名称

                    b.QcNurse.ID = this.Reader[95].ToString();//质控护士代码

                    b.QcNurse.Name = this.Reader[96].ToString();//质控护士名称

                    b.CheckDate = System.Convert.ToDateTime(this.Reader[97].ToString());//检查时间

                    b.YnFirst = this.Reader[98].ToString();//手术操作治疗检查诊断为本院第一例项目

                    b.RhBlood = this.Reader[99].ToString();//Rh血型(阴阳)

                    b.ReactionBlood = this.Reader[100].ToString();//输血反应（有无）

                    b.BloodRed = this.Reader[101].ToString();//红细胞数

                    b.BloodPlatelet = this.Reader[102].ToString();//血小板数

                    b.BloodPlasma = this.Reader[103].ToString();//血浆数

                    b.BloodWhole = this.Reader[104].ToString();//全血数

                    b.BloodOther = this.Reader[105].ToString();//其他输血数

                    b.XNum = this.Reader[106].ToString();//X光号

                    b.CtNum = this.Reader[107].ToString();//CT号

                    b.MriNum = this.Reader[108].ToString();//MRI号

                    b.PathNum = this.Reader[109].ToString();//病理号

                    b.DsaNum = this.Reader[110].ToString();//DSA号

                    b.PetNum = this.Reader[111].ToString();//PET号

                    b.EctNum = this.Reader[112].ToString();//ECT号

                    b.XQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[113].ToString());//X线次数

                    b.CTQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[114].ToString());//CT次数

                    b.MRQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[115].ToString());//MR次数

                    b.DSAQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[116].ToString());//DSA次数

                    b.PetQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[117].ToString());//PET次数

                    b.EctQty = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[118].ToString());//ECT次数

                    b.PatientInfo.Memo = this.Reader[119].ToString();//说明

                    b.BarCode = this.Reader[120].ToString();//归档条码号

                    b.LendStat = this.Reader[121].ToString();//病案借阅状态(O借出 I在架)

                    b.PatientInfo.CaseState = this.Reader[122].ToString();//病案状态1科室质检2登记保存3整理4病案室质检5无效

                    b.OperInfo.ID = this.Reader[123].ToString();//操作员

                    b.OperInfo.OperTime = System.Convert.ToDateTime(this.Reader[124].ToString());//操作时间
                    b.VisiPeriodWeek = this.Reader[125].ToString();
                    b.VisiPeriodMonth = this.Reader[126].ToString();
                    b.VisiPeriodYear = this.Reader[127].ToString();
                    b.SpecalNus = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[128]); 	// 特殊护理(日)                                        
                    b.INus = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[129]); 	//I级护理时间(日)                                     
                    b.IINus = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[130]);	//II级护理时间(日)                                    
                    b.IIINus = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[131]);	//III级护理时间(日)                                   
                    b.StrictNuss = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[132]);	//重症监护时间( 小时)                                 
                    b.SuperNus = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.Reader[133]);	//特级护理时间(小时) 
                    b.PackupMan.ID = this.Reader[134].ToString(); // 整理人
                    b.Disease30 = this.Reader[135].ToString();// 单病种 
                    b.IsHandCraft = this.Reader[136].ToString(); //手动录病案
                    b.ClinicDiag.ID = this.Reader[137].ToString(); //门诊诊断 编码
                    b.ClinicDiag.Name = this.Reader[138].ToString();//门诊诊断 名称
                    b.InHospitalDiag.ID = this.Reader[139].ToString(); //入院诊断 编码
                    b.InHospitalDiag.Name = this.Reader[140].ToString();//入院诊断 名称
                    b.OutDiag.ID = this.Reader[141].ToString();//出院主诊断 编码
                    b.OutDiag.Name = this.Reader[142].ToString();//出院主诊断 名称
                    b.OutDiag.User01 = this.Reader[143].ToString();//出院主诊断 治疗情况
                    b.OutDiag.User02 = this.Reader[144].ToString();//出院主诊断病理符合情况
                    b.FirstOperation.ID = this.Reader[145].ToString();//第一主手术代码
                    b.FirstOperation.Name = this.Reader[146].ToString();//第一主手术名称
                    b.FirstOperationDoc.ID = this.Reader[147].ToString();//第一主手术医师代码
                    b.FirstOperationDoc.Name = this.Reader[148].ToString();//第一主手术医师名称
                    b.SyndromeFlag = this.Reader[149].ToString();//是否有并发症 1 有 0 无
                    b.InfectionNum = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[150].ToString()); //院内感染次数
                    b.OperationCoding.ID = this.Reader[151].ToString();//手术编码员
                    b.CaseNO = this.Reader[152].ToString();//病案号
                    b.InfectionPosition.ID = this.Reader[153].ToString(); //院内感染部位编码
                    b.InfectionPosition.Name = this.Reader[154].ToString(); //院内感染部位名称

                    b.Out_Type  = this.Reader[155].ToString();//输血反应（有无）
                    b.Cure_Type  = this.Reader[156].ToString();//输血反应（有无）
                    b.Use_CHA_Med  = this.Reader[157].ToString();//输血反应（有无）
                    b.Save_Type  = this.Reader[158].ToString();//输血反应（有无）
                    b.Ever_Sickintodeath  = this.Reader[159].ToString();//输血反应（有无）
                    b.Ever_Firstaid  = this.Reader[160].ToString();//输血反应（有无）
                    b.Ever_Difficulty  = this.Reader[161].ToString();//输血反应（有无）
                    b.ReactionLiquid  = this.Reader[162].ToString();//输血反应（有无）

                    #region{2FDCC429-B30E-463c-AAD6-6BADCE600458}
                    b.PatientInfo.PVisit.AttendingDirector.ID=this.Reader[163].ToString();//科主任
                    b.PatientInfo.PVisit.TemporaryLocation.User03 = this.Reader[164].ToString();//形态学编码
                    b.PatientInfo.PVisit.TempDoctor.User01 = this.Reader[165].ToString();//抗生素是否使用
                    b.PatientInfo.PVisit.TempDoctor.User02 = this.Reader[166].ToString();//抗生素使用次数
                    b.PatientInfo.PVisit.TemporaryLocation.User01 = this.Reader[167].ToString();//传染病卡
                    b.PatientInfo.PVisit.TemporaryLocation.User02 = this.Reader[168].ToString();//肿瘤卡
                    #endregion

                    #region 集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                    b.PatientInfo.Pact.User01 = this.Reader[169].ToString();
                    #endregion

                    list.Add(b);
                }
                return list;
            }
            catch (Exception ex)
            {
                this.Err = "获得患者病案信息出错!" + ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 得到未等登记病案信息的患者的诊断信息
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        private ArrayList myGetDiagInfo(string strSql)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.DiagnoseBase dg;
            this.ExecQuery(strSql);

            try
            {
                while (this.Reader.Read())
                {
                    dg = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();

                    dg.ID = Reader[0].ToString();//住院流水号
                    dg.Patient.ID = Reader[0].ToString();//住院流水号
                    dg.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[1]);//发生序号
                    dg.Patient.PID.CardNO = this.Reader[2].ToString();//就诊卡号
                    dg.DiagType.ID = this.Reader[3].ToString();//诊断类别
                    dg.ICD10.ID = this.Reader[4].ToString();//诊断代码
                    dg.ICD10.Name = this.Reader[5].ToString();//诊断名称
                    dg.DiagDate = System.Convert.ToDateTime(this.Reader[6].ToString());//诊断日期
                    dg.Doctor.ID = this.Reader[7].ToString();//诊断医生代码
                    dg.Doctor.Name = this.Reader[8].ToString();//诊断医师名称
                    dg.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9].ToString());//是否有效0有效1无效
                    dg.Dept.ID = this.Reader[10].ToString();//科室
                    dg.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[11].ToString());//是否主诊断
                    dg.Memo = this.Reader[12].ToString();//备注
                    al.Add(dg);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                this.Err = "获得患者住院诊断信息出错!" + ex.Message;
                return null;
            }
            this.Reader.Close();
            return al;
        }
        /// <summary>
        /// 计算两个DateTime时间差
        /// </summary>
        /// <param name="flag">"YYYY"年龄|"MM"|月|"DD"天</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <returns>double</returns>
        private double DateDiff(string flag, DateTime dateBegin, DateTime dateEnd)
        {
            double diff = 0;
            try
            {
                TimeSpan TS = new TimeSpan(dateEnd.Ticks - dateBegin.Ticks);

                switch (flag.ToLower())
                {
                    case "m":
                        diff = Convert.ToDouble(TS.TotalMinutes);
                        break;
                    case "s":
                        diff = Convert.ToDouble(TS.TotalSeconds);
                        break;
                    case "t":
                        diff = Convert.ToDouble(TS.Ticks);
                        break;
                    case "mm":
                        diff = Convert.ToDouble(TS.TotalMilliseconds);
                        break;
                    case "yyyy":
                        diff = Convert.ToDouble(TS.TotalDays / 365);
                        break;
                    case "q":
                        diff = Convert.ToDouble((TS.TotalDays / 365) / 4);
                        break;
                    case "dd":
                        diff = Convert.ToDouble((TS.TotalDays));
                        break;
                    default:
                        diff = Convert.ToDouble(TS.TotalDays);
                        break;
                }
            }
            catch
            {

                diff = -1;
            }

            return diff;
        }
        #endregion 

        /// <summary>
        /// 根据生日和当前时间得出患者得年龄和年龄单位
        /// ID 保存年龄 Name保存年龄单位
        /// </summary>
        /// <param name="bornDate">患者得出生日期</param>
        /// <returns>Neusoft.FrameWork.Models.NeuObject</returns>
        public new Neusoft.FrameWork.Models.NeuObject GetAge(DateTime bornDate)
        {
            DateTime nowDate;
            double temp;

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();

            nowDate = this.GetDateTimeFromSysDateTime();


            temp = DateDiff("YYYY", bornDate, nowDate);
            obj.Name = "Y";

            if (temp < 0) //小于一年
            {
                temp = DateDiff("DD", bornDate, nowDate);

                if (temp < 28)
                {
                    obj.Name = "D";
                }
                else
                {
                    obj.Name = "M";
                }
            }

            obj.ID = temp.ToString();

            return obj;
        }
      
        /// <summary>
        /// 获取入院科室 
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.Location GetDeptIn(string inpatienNo)
        {
            string strSql = "";
            Neusoft.HISFC.Models.RADT.Location info = null;
            if (this.Sql.GetSql("Case.BaseDML.GetDeptIn.1", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatienNo);
                //查询
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Location();
                    info.Dept.ID = Reader[0].ToString(); //科室编码
                    info.Dept.Name = Reader[1].ToString();//科室名称
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                info = null;
            }
            return info;
        }
        /// <summary>
        /// 获取出院科室
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.RADT.Location GetDeptOut(string inpatienNo)
        {
            string strSql = "";
            Neusoft.HISFC.Models.RADT.Location info = null;
            if (this.Sql.GetSql("Case.BaseDML.GetDeptOut", ref strSql) == -1) return null;
            try
            {
                strSql = string.Format(strSql, inpatienNo);
                //查询
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.Location();
                    info.Dept.ID = Reader[0].ToString(); //科室编码
                    info.Dept.Name = Reader[1].ToString();//科室名称
                }
                this.Reader.Close();
            }
            catch (Exception ee)
            {
                this.Err = ee.Message;
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
                info = null;
            }
            return info;
        }

        #region  组合查询Sql

        /// <summary>
        /// 自己设置where条件来查询病案信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public ArrayList QueryBaseCasBySetWhere(string where)
        {
            string str = "";
            ArrayList list = null;

            try
            {
                //获得主sql语句
                str = GetCaseSql();

                str = str + where;
                str = string.Format(str);

                list = myGetCaseBaseInfo(str);

                return list;

            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                return null;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="xml"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        protected int _InsertQueryCondtion(string formName, string xml, bool isDefault, string condtionName)
        {
            string sql = "Manager.QueryCondition.Insert1";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;
            if (isDefault)
            {
                return this.ExecNoQuery(sql, formName, "", xml, condtionName);
            }
            else
            {
                return this.ExecNoQuery(sql, formName, this.Operator.ID, xml, condtionName);
            }
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="xml"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public int SetQueryCondition(string formName, string xml, bool isDefault)
        {
            string s = this.GetQueryCondtion(formName, isDefault);
            if (s == "-1") return -1;
            if (s == "") //insert
            {
                return this._InsertQueryCondtion(formName, xml, isDefault, "");
            }
            else //update
            {
                return this._UpdateQueryCondition(formName, xml, isDefault);
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <returns></returns>
        public string GetQueryCondtion(string formName, bool isDefault)
        {
            string sql1 = "Manager.QueryCondition.Get.11";
            string sql2 = "Manager.QueryCondition.Get.22";
            string sql = "";

            if (isDefault)//默认的配置
            {
                if (this.Sql.GetSql(sql2, ref sql) == -1) return "-1";
                if (this.ExecQuery(sql, formName, "") == -1) return "-1";
            }
            else //个人配置
            {
                if (this.Sql.GetSql(sql1, ref sql) == -1) return "-1";
                if (this.ExecQuery(sql, formName, this.Operator.ID) == -1) return "-1";
            }
            if (this.Reader.Read())
            {
                return this.Reader[0].ToString();
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// 保存查询条件,带模板名称
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="xml"></param>
        /// <param name="isDefault"></param>
        /// <param name="conditonName"></param>
        /// <returns></returns>
        public int InsertQueryConditon(string formName, string xml, bool isDefault, string condtionName)
        {
            return this._InsertQueryCondtion(formName, xml, isDefault, condtionName);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="xml"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        protected int _UpdateQueryCondition(string formName, string xml, bool isDefault)
        {
            string sql = "Manager.QueryCondition.Update";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;
            if (isDefault)
            {
                return this.ExecNoQuery(sql, formName, "", xml);
            }
            else
            {
                return this.ExecNoQuery(sql, formName, this.Operator.ID, xml);
            }
        }


        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public string GetQueryCondtion(string formName)
        {
            return GetQueryCondtion(formName, false);
        }

        /// <summary>
        /// 获得查询条件（根据ID ）
        /// </summary>
        /// <returns></returns>
        public string GetQueryCondtionByID(string ID)
        {
            string sql = "Manager.QueryCondition.Get.4";


            if (this.Sql.GetSql(sql, ref sql) == -1) return "-1";
            if (this.ExecQuery(sql, ID) == -1) return "-1";

            if (this.Reader.Read())
            {
                return this.Reader[0].ToString();
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// 获得查询ID name(多条)
        /// </summary>
        /// <returns></returns>
        public ArrayList GetQueryCondtionInfo(string formName)
        {
            string sql1 = "Manager.QueryCondition.Get.3";

            string sql = "";
            ArrayList al = null;


            if (this.Sql.GetSql(sql1, ref sql) == -1) return null;
            if (this.ExecQuery(sql, formName, this.Operator.ID) == -1) return null;
            try
            {
                Neusoft.FrameWork.Models.NeuObject neuObject = null;
                al = new ArrayList();
                while (this.Reader.Read())
                {
                    neuObject = new Neusoft.FrameWork.Models.NeuObject();
                    neuObject.ID = this.Reader[0].ToString();
                    neuObject.Name = this.Reader[1].ToString();
                    al.Add(neuObject);
                }
                this.Reader.Close();
                return al;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }

        }


        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public int SetQueryCondition(string formName, string xml)
        {
            return SetQueryCondition(formName, xml, false);
        }

        /// <summary>
        /// 根据ID 更新条件名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateQueryCondition(string ID, string condtionName, string xml)
        {
            string sql = "Manager.QueryCondition.Update.2";
            if (this.Sql.GetSql(sql, ref sql) == -1)
            {
                this.Err = "根新数据失败" + this.ErrCode;

                return -1;
            }

            return this.ExecNoQuery(sql, ID, condtionName, xml);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="xml"></param>
        /// <param name="isDefault"></param>
        /// <returns></returns>
        public int DeleteQueryCondition(string ID)
        {
            string sql = "Manager.QueryCondition.Delete";
            if (this.Sql.GetSql(sql, ref sql) == -1) return -1;

            return this.ExecNoQuery(sql, ID);

        }
        #endregion

        #region  废弃
        /// <summary>
        /// 根据住院号和住院次数查询住院流水号 
        /// </summary>
        /// <param name="inpatientNO"></param>
        /// <param name="InNum"></param>
        /// <returns></returns>
        [Obsolete(" 废弃,用QueryPatientInfoByInpatientAndInNum 代替",true)]
        public ArrayList GetPatientInfo(string inpatientNO, string InNum)
        {
            //先从病案主表中查询 如果没有查到 再在住院主表中查询 
            ArrayList list = new ArrayList();
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetPatientInfo.GetPatientInfo", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, inpatientNO, InNum);
            this.ExecQuery(strSql);
            Neusoft.HISFC.Models.RADT.PatientInfo info = null;
            while (this.Reader.Read())
            {
                info = new Neusoft.HISFC.Models.RADT.PatientInfo();
                info.ID = this.Reader[0].ToString();
                list.Add(info);
                info = null;
            }
            if (list == null)
            {
                return list;
            }
            if (list.Count == 0)
            {
                //查询住院主表 获取病人信息
                if (this.Sql.GetSql("RADT.Inpatient.PatientInfoGetByTime", ref strSql) == -1)
                {
                    this.Err = "获取SQL语句失败";
                    return null;
                }
                strSql = string.Format(strSql, inpatientNO, InNum);
                this.ExecQuery(strSql);
                while (this.Reader.Read())
                {
                    info = new Neusoft.HISFC.Models.RADT.PatientInfo();
                    info.ID = this.Reader[0].ToString();
                    list.Add(info);
                    info = null;
                }
            }
            return list;
        }
        /// <summary>
        /// 查询未登记病案信息的患者的诊断信息,从met_com_diagnose中提取
        /// </summary>
        /// <param name="inpatientNO">患者住院流水号</param>
        /// <param name="diagType">诊断类别,要提取所有诊断输入%</param>
        /// <returns>诊断信息数组</returns>
        [Obsolete("废弃,用 QueryInhosDiagnoseInfo 代替",true)]
        public ArrayList GetInhosDiagInfo(string inpatientNO, string diagType)
        {
            string strSql = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetInhosDiagInfo.Select", ref strSql) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSql = string.Format(strSql, inpatientNO, diagType);

            return this.myGetDiagInfo(strSql);
        }
        /// <summary>
        /// 根据病案号获取信息
        /// </summary>
        /// <param name="CaseNo"></param>
        /// <returns></returns
        [Obsolete("废弃 用 QueryCaseBaseInfoByCaseNO 代替",true)]
        public ArrayList GetCaseBaseInfoByCaseNum(string CaseNo)
        {
            ArrayList list = new ArrayList();
            //获取主sql语句
            string strSQL = GetCaseSql();
            string str = "";
            if (this.Sql.GetSql("CASE.BaseDML.GetCaseBaseInfoByCaseNum.Select.where", ref str) == -1)
            {
                this.Err = "获取SQL语句失败";
                return null;
            }
            strSQL += str;
            strSQL = string.Format(strSQL, CaseNo);
            return this.myGetCaseBaseInfo(strSQL);
        }
        /// <summary>
        /// 费用类别 
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用 合同单位 代替", true)]
        public ArrayList GetPayKindCode()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "01";
            //info.Name = "自费";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "02";
            //info.Name = "医保";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "03";
            //info.Name = "公费";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "04";
            //info.Name = "特约单位";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "05";
            //info.Name = "本院职工";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 血型列表
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用 常数 BLOODTYPE 代替", true)]
        public ArrayList GetBloodType()
        {
            //血型列表 
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "0";
            //info.Name = "U";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "A";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "B";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "AB";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "4";
            //info.Name = "O";
            //list.Add(info);

            return list;
            #region  住院处用的列表
            //			ArrayList list = new ArrayList();
            //			neusoft.HISFC.Object.Base.SpellCode info = null;
            //			ArrayList list2 = Neusoft.HISFC.Models.RADT.BloodType.List();
            //			foreach(Neusoft.FrameWork.Models.NeuObject obj in list2)
            //			{
            //				info = new neusoft.HISFC.Object.Base.SpellCode();
            //				info.ID = obj.ID;
            //				info.Name = obj.Name;
            //				list.Add(info);
            //			}
            #endregion
        }
        /// <summary>
        /// 输血反应
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用常数 BloodReaction 代替", true)]
        public ArrayList GetReactionBlood()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "无";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "有";
            //list.Add(info);

            return list;
        }
        [Obsolete("废弃，用 常数 RHSTATE 代替", true)]
        public ArrayList GetRHType()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "阴";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "阳";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 病案质量
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用 常数 CASEQUALITY 代替", true)]
        public ArrayList GetCaseQC()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "0";
            //info.Name = "甲";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "乙";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "丙";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 诊断符合情况
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用常数 DIAGNOSEACCORD 代替", true)]
        public ArrayList GetDiagAccord()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "0";
            //info.Name = "未做";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "符合";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "不符合";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "不肯定";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 药物过敏
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用常数 PHARMACYALLERGIC 代替", true)]
        public ArrayList GetHbsagList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "0";
            //info.Name = "未做";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "阴性";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "阳性";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 病人来源  
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用 常数 INSOURCE 代替", true)]
        public ArrayList GetPatientSource()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "1";
            //info.Name = "本区";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "2";
            //info.Name = "本市";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "3";
            //info.Name = "外市";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "4";
            //info.Name = "外省";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "5";
            //info.Name = "港澳台";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "6";
            //info.Name = "外国";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 获取性别列表
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用枚举 代替", true)]
        public ArrayList GetSexList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "M";
            //info.Name = "男";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "F";
            //info.Name = "女";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "U";
            //info.Name = "未知";
            //list.Add(info);

            //info = new neusoft.HISFC.Object.Base.SpellCode();
            //info.ID = "O";
            //info.Name = "其他";
            //list.Add(info);

            return list;
        }
        /// <summary>
        /// 婚姻列表
        /// </summary>
        /// <returns></returns>
        [Obsolete("废弃，用枚举代替", true)]
        public ArrayList GetMaryList()
        {
            ArrayList list = new ArrayList();
            //neusoft.HISFC.Object.Base.SpellCode info = null;
            //ArrayList list2 = Neusoft.HISFC.Models.RADT.MaritalStatus.List();
            //foreach (Neusoft.FrameWork.Models.NeuObject obj in list2)
            //{
            //    info = new neusoft.HISFC.Object.Base.SpellCode();
            //    info.ID = obj.ID;
            //    info.Name = obj.Name;
            //    list.Add(info);
            //}
            return list;
        }
        #endregion 
    }
}

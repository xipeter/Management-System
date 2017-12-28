using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.BizLogic.Operation
{
    public  class OpsDiagnose : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 更新患者诊断信息
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns> 
        public int UpdatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.UpdatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.UpdatePatientDiagnose.1", ref strSql) == -1) return -1;

            try
            {
                string[] s = new string[15];
                try
                {
                    s[0] = Diagnose.Patient.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[1] = Diagnose.HappenNo.ToString();//  --发生序号
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[2] = Diagnose.Patient.PID.CardNO;// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[3] = Diagnose.DiagType.ID.ToString();//  --诊断类别
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[4] = Diagnose.ID.ToString();// --诊断编码
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[5] = Diagnose.Name;//.Replace("'","''");//--诊断名称
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[6] = Diagnose.DiagDate.ToString();//  --诊断时间
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[7] = Diagnose.Doctor.ID.ToString();//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[8] = Diagnose.Doctor.Name;//    --诊断医生
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[9] = (System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[10] = Diagnose.Dept.ID.ToString();//  --诊断科室
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[11] = (System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }

                try
                {
                    s[12] = Diagnose.Memo;//    --备注
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[13] = this.Operator.ID.ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                try
                {
                    s[14] = this.GetSysDateTime().ToString();//    --操作人
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    this.WriteErr();
                }
                //				strSql=string.Format(strSql,s);
                return this.ExecNoQuery(strSql, s);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;
                this.WriteErr();
                return -1;
            }

        }
        #region 申请新诊断发生序号
        /// <summary>
        /// 申请新诊断发生序号
        /// </summary>
        /// <returns> 新申请的序号 错误时返回-1</returns> 
        public int GetNewDignoseNo()
        {
            int lNewNo = -1;
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.GetNewDiagnoseNo.1", ref strSql) == -1) return -1;
            if (strSql == null) return -1;
            this.ExecQuery(strSql);
            try
            {
                while (this.Reader.Read())
                {
                    lNewNo = Neusoft.FrameWork.Function.NConvert.ToInt32(Reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr(); ;
                return -1;
            }
            this.Reader.Close();
            return lNewNo;
        }
        #endregion
        #region 登记患者诊断信息
        /// <summary>
        /// 登记新的患者诊断
        /// </summary>
        /// <param name="Diagnose"></param>
        /// <returns></returns> 
        public int CreatePatientDiagnose(Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose)
        {
            #region "接口说明"
            //接口名称 RADT.Diagnose.CreatePatientDiagnose.1
            // 0  --住院流水号, 1 --发生序号      2   --病历号   ,     3   --诊断类别  ,4   --诊断编码 
            // 5  --诊断名称,   6   --诊断时间   ,7   --诊断医生编码  ,8   --医生名称 , 9   --是否有效
            // 10 --诊断科室ID 11   --是否主诊断 12   --备注          13   --操作员    14   --操作时间
            #endregion
            string strSql = "";
            if (this.Sql.GetSql("RADT.Diagnose.CreatePatientDiagnose.1", ref strSql) == -1) return -1;
            string[] s = new string[16];
            s[0] = Diagnose.Patient.ID.ToString();// --患者住院流水号 
            s[1] = Diagnose.HappenNo.ToString();//  --发生序号 
            s[2] = Diagnose.Patient.PID.CardNO;// --就诊卡号 
            s[3] = Diagnose.DiagType.ID.ToString();//  --诊断类别 
            s[4] = Diagnose.ID.ToString();// --诊断编码 
            s[5] = Diagnose.Name;//.Replace("'","''") ;//--诊断名称 
            s[6] = Diagnose.DiagDate.ToString();//  --诊断时间 
            s[7] = Diagnose.Doctor.ID.ToString();//    --诊断医生 
            s[8] = Diagnose.Doctor.Name;//    --诊断医生 
            s[9] = (System.Convert.ToInt16(Diagnose.IsValid)).ToString();//    --是否有效 
            s[10] = Diagnose.Dept.ID.ToString();//  --诊断科室 
            s[11] = (System.Convert.ToInt16(Diagnose.IsMain)).ToString();//  --是否主诊断 
            s[12] = Diagnose.Memo;//    --备注 
            s[13] = this.Operator.ID.ToString();//    --操作人 
            s[14] = this.GetSysDateTime().ToString();//    --操作人 
            s[15] = Diagnose.OperationNo;//手术序号 
            return this.ExecNoQuery(strSql, s);
        }
        #endregion
        /// <summary>
        /// 查询患者所有诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <returns></returns> 
        public ArrayList QueryOpsDiagnose(string InPatientNo)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.1
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.1", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.1字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo);
            return this.myPatientQuery(sql1);
        }
        /// <summary>
        /// 查询患者各类型诊断
        /// </summary>
        /// <param name="InPatientNo"></param>
        /// <param name="DiagType"></param>
        /// <returns></returns> 
        public ArrayList QueryOpsDiagnose(string InPatientNo, string DiagType)
        {
            #region 接口说明
            //RADT.Diagnose.PatientDiagnoseQuery.2
            //传入：住院流水号
            //传出：患者诊断信息
            #endregion
            ArrayList al = new ArrayList();
            string sql1 = "", sql2 = "";

            sql1 = PatientQuerySelect();
            if (sql1 == null) return null;

            if (this.Sql.GetSql("RADT.Diagnose.PatientDiagnoseQuery.3", ref sql2) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.PatientDiagnoseQuery.3字段!";
                this.ErrCode = "-1";
                return null;
            }
            sql1 = sql1 + " " + string.Format(sql2, InPatientNo, DiagType);
            return this.myPatientQuery(sql1);
        }
        /// 查询患者诊断信息的select语句（无where条件） 
        private string PatientQuerySelect()
        {
            #region 接口说明
            //RADT.Diagnose.DiagnoseQuery.select.1
            //传入：0
            //传出：sql.select
            #endregion
            string sql = "";
            if (this.Sql.GetSql("RADT.Diagnose.DiagnoseQuery.select.1", ref sql) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.DiagnoseQuery.select.1字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            return sql;
        }
        //私有函数，查询患者基本信息 
        private ArrayList myPatientQuery(string SQLPatient)
        {
            ArrayList al = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.DiagnoseBase Diagnose;
            this.ProgressBarText = "正在查询患者诊断...";
            this.ProgressBarValue = 0;

            this.ExecQuery(SQLPatient);
            try
            {
                while (this.Reader.Read())
                {
                    Diagnose = new Neusoft.HISFC.Models.HealthRecord.DiagnoseBase();
                    Diagnose.Patient.ID = this.Reader[0].ToString();// 住院流水号

                    Diagnose.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//  发生序号

                    Diagnose.Patient.PID.CardNO = this.Reader[2].ToString();//病历号

                    Diagnose.DiagType.ID = this.Reader[3].ToString();//诊断类别
                    //Neusoft.HISFC.Models.HealthRecord.DiagnoseType diagnosetype = new Neusoft.HISFC.Models.HealthRecord.DiagnoseType();
                    //diagnosetype.ID = Diagnose.DiagType.ID;
                    //Diagnose.DiagType.Name = diagnosetype.Name;//获得诊断名称 zjy

                    Diagnose.ID = this.Reader[4].ToString();		//诊断代码
                    Diagnose.ICD10.ID = this.Reader[4].ToString();
                    Diagnose.Name = this.Reader[5].ToString();		//诊断名称
                    Diagnose.ICD10.Name = this.Reader[5].ToString();

                    Diagnose.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[6].ToString());

                    Diagnose.Doctor.ID = this.Reader[7].ToString();

                    Diagnose.Doctor.Name = this.Reader[8].ToString();

                    Diagnose.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[9]);

                    Diagnose.Dept.ID = this.Reader[10].ToString();

                    Diagnose.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[11]);

                    Diagnose.Memo = this.Reader[12].ToString();

                    Diagnose.User01 = this.Reader[13].ToString();
                    Diagnose.User02 = this.Reader[14].ToString();

                    //手术序号
                    Diagnose.OperationNo = this.Reader[15].ToString();

                    al.Add(Diagnose);
                }
            }
            catch (Exception ex)
            {
                this.Err = "获得患者诊断信息出错！" + ex.Message;
                this.ErrCode = "-1";
                this.WriteErr();
                return null;
            }
            this.Reader.Close();

            this.ProgressBarValue = -1;
            return al;
        }

        public int DeleteDiagnoseByOperationNO(string operationNO)
        {
              string sql = "";
              if (this.Sql.GetSql("RADT.Diagnose.Diagnose.Delete.By.OperationNO", ref sql) == -1)
            {
                this.Err = "没有找到RADT.Diagnose.Diagnose.Delete.By.OperationNO字段!";
                this.ErrCode = "-1";
                this.WriteErr();
                return -1;
            }

              sql = string.Format(sql, operationNO);
              return this.ExecNoQuery(sql);

            
        }
    }
}

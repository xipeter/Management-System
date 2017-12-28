using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Models.HealthRecord;
using Neusoft.FrameWork.Function;
using System.Data;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord.Case
{
    /// <summary>
    /// Visit<br></br>
    /// [功能描述: 患者病历基本信息维护]<br></br>
    /// [创 建 者: 蒋飞]<br></br>
    /// [创建时间: 2007-08-21]<br></br>
    /// <修改记录
    ///		修改人='周全'
    ///		修改时间='2007-09-10'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class CaseInfo : Neusoft.FrameWork.Management.Database
    {
        #region 数据库基本操作

        /// <summary>
        /// 新增病历
        /// </summary>
        /// <param name="CaseInfo">病历类</param>
        /// <returns>出现异常返回－1 成功返回1 插入失败返回 0</returns>
        public int Insert(Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo)
        {

            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseInfo.Insert", ref strSql) == -1) return -1;
            try
            {
                //插入
                strSql = string.Format(strSql, GetInfo(caseInfo));

                return this.ExecNoQuery(strSql);
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;

                return -1;
            }

        }

        private string[] GetInfo(Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo)
        {
            string[] str = new string[13];

            str[0] = caseInfo.ID;         //病历流水号 
            str[1] = caseInfo.Patient.PID.CardNO; //当前病历号
            str[2] = caseInfo.Patient.User01;     //初诊病历号
            str[3] = caseInfo.Patient.User02;     //门诊病历号
            str[4] = caseInfo.Patient.User03;     //住院病历号
            str[5] = caseInfo.Cabinet.ID; //病案柜编码
            str[6] = caseInfo.GridNO;     //病案柜格号
            str[7] = caseInfo.CaseState.ID;      //病案状态编码，对应常数表CASE02
            str[8] = caseInfo.LoseState.ID;      //丢失原因编码，对应常数表CASE03
            str[9] = caseInfo.InType.ToString(); //所在类型：0－人、1－科室
            str[10] = caseInfo.InEmployee.ID;    //所在人员编码
            str[11] = caseInfo.InDept.ID;        //所在科室编码
            str[12] = caseInfo.EmpiID;           //患者主索引号

            return str;
        }

        /// <summary>
        /// 更新病历记录
        /// </summary>
        /// <param name="caseInfo">病历类</param>
        /// <returns>影响的行数-成功;-1-异常，0失败</returns>
        public int Update(Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo)
        {
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseInfo.Update", ref strSql) == -1) return -1;
            try
            {
                string[] strParm = GetInfo(caseInfo);
                strSql = string.Format(strSql, strParm);
            }
            catch (Exception ex)
            {
                this.Err = "赋值时候出错！" + ex.Message;

                return -1;
            }

            //　执行SQL语句返回
            return this.ExecNoQuery(strSql);

        }

        /// <summary>
        /// 创建患者信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <param name="empiID"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int CreatePatientInfo(string cardNO, string empiID, ref string caseID)
        {
            Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();

            caseInfo.ID = this.GetSequence("HealthRecord.Case.CaseID"); //病历流水号
            caseInfo.Patient.PID.CardNO = cardNO; //当前病历号
            caseInfo.Patient.User01 = cardNO;     //初诊病历号
            caseInfo.EmpiID = empiID;     //患者主索引号

            caseID = caseInfo.ID; //返回引用病历流水号

            return this.Insert(caseInfo);
        }

        /// <summary>
        /// 获取所有病案信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllCaseInfo()
        {
            ArrayList arrayList = null;
            string strSql = "";

            if (this.Sql.GetSql("HealthReacord.Case.CaseInfo.SelectAll", ref strSql) == -1) return null;

            try
            {
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = null;
                arrayList = new ArrayList();
                while (this.Reader.Read())
                {
                    caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();
                    caseInfo.ID = this.Reader[0].ToString(); //病案流水号
                    caseInfo.Patient.PID.CardNO = this.Reader[1].ToString();  //当前病历号
                    caseInfo.Patient.User01 = this.Reader[2].ToString();  //初诊病历号
                    caseInfo.Patient.User02 = this.Reader[3].ToString();  //门诊病历号
                    caseInfo.Patient.User03 = this.Reader[4].ToString();  //住院病历号
                    caseInfo.Patient.Name = this.Reader[5].ToString();    //患者姓名
                    caseInfo.Patient.Sex.ID = this.Reader[6].ToString();  //患者性别
                    caseInfo.Patient.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7]); //患者出生日期
                    caseInfo.Patient.IDCard = this.Reader[8].ToString();  //患者身份证号
                    caseInfo.Cabinet.ID = this.Reader[9].ToString();  //病案柜编码
                    caseInfo.GridNO = this.Reader[10].ToString();  //病案柜格号
                    caseInfo.CaseState.ID = this.Reader[11].ToString();  //病案状态
                    caseInfo.LoseState.ID = this.Reader[12].ToString();  //丢失原因
                    caseInfo.InType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[13]);  //病案所在类型
                    caseInfo.InEmployee.ID = this.Reader[14].ToString();  //所在人员编号
                    caseInfo.InDept.ID = this.Reader[15].ToString();   //所在科室编号
                    caseInfo.EmpiID = this.Reader[16].ToString();  //患者主索引号

                    arrayList.Add(caseInfo);
                }

                return arrayList;
            }
            catch(Exception Ex)
            {
                this.Err = Ex.Message;
                return null;
            }
        }

        #endregion


        #region 查询

        /// <summary>
        ///　根据病历编码查询病历的信息
        /// </summary>
        /// <param name="">病历流水号</param>
        /// <returns>信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo</returns>  
        public ArrayList Query(string caseID)
        {
            ArrayList List = null;
            string strSql = "";
            if (this.Sql.GetSql("HealthReacord.Case.CaseInfo.Select", ref strSql) == -1) return null;
            try
            {
                //查询
                strSql = string.Format(strSql, caseID);
                this.ExecQuery(strSql);
                Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo = null;
                List = new ArrayList();
                while (this.Reader.Read())
                {
                    caseInfo = new Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo();
                    caseInfo.ID = this.Reader[0].ToString();           //病案流水号 
                    //caseInfo..PatientNO = this.Reader[1].ToString(); //当前病历号
                    //caseInfo.PID.ID = this.Reader[2].ToString();      //初诊病历号
                    //caseInfo.PID.CardNO = this.Reader[3].ToString();  //门诊病历号
                    //caseInfo.PID.CaseNO = this.Reader[4].ToString();//住院病历号
                    caseInfo.Cabinet.ID = this.Reader[5].ToString(); //病案柜编码
                    caseInfo.Cabinet.GridCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[6].ToString()); //病案柜格号
                    caseInfo.CaseState.ID = this.Reader[7].ToString(); //病案状态编码，对应常数表CASE02
                    caseInfo.LoseState.ID = this.Reader[8].ToString(); //丢失原因编码，对应常数表CASE03
                    caseInfo.InType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[9].ToString());//所在类型：0－人、1－科室
                    caseInfo.InEmployee.ID = this.Reader[10].ToString(); //所在人员编码
                    caseInfo.InDept.ID = this.Reader[11].ToString();   //所在科室编码
                    List.Add(caseInfo);
                    caseInfo = null;
                }

                return List;
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据病历号获取病历基本信息
        /// </summary>
        /// <param name="caseInfo">病历基本信息</param>
        /// <param name="cardNo">病历号</param>
        /// <returns>－1－失败，0－不存在，1－成功 </returns>
        public int GetCaseInfoByCardNo(ref Neusoft.HISFC.Models.HealthRecord.Case.CaseInfo caseInfo, string cardNo)
        {
            string selectSql = string.Empty;

            int callReturn = this.Sql.GetSql("Neusoft.HISFC.Management.HealthRecord.Case.CaseInfo.GetCaseInfoByCardNo", ref selectSql);
            if (callReturn == -1)
            {
                return -1;
            }

            try
            {
                selectSql = string.Format(selectSql, cardNo);
                callReturn = this.ExecQuery(selectSql);
                if (callReturn == -1)
                {
                    this.Err = "根据病历号获取病历基本信息失败" + this.Err;

                    return -1;
                }

                if (this.Reader.Read())
                {
                    caseInfo.ID = this.Reader[0].ToString();
                    caseInfo.CaseState.Name = this.Reader[1].ToString();
                    // 病历归属
                    caseInfo.InType = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[2].ToString());
                    caseInfo.InDept.Name = this.Reader[3].ToString();
                    caseInfo.InEmployee.Name = this.Reader[4].ToString();
                    caseInfo.Patient.Name = this.Reader[5].ToString();
                    caseInfo.Patient.Sex.ID = this.Reader[6].ToString();
                    caseInfo.Patient.Birthday = Convert.ToDateTime(this.Reader[7].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                this.Err = "根据病历号获取病历基本信息失败" + exception.Message;

                return -1;
            }

            return 1;
        }
        #endregion
    }
}

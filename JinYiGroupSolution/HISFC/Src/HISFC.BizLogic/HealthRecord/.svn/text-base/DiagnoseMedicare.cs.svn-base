using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.BizLogic.HealthRecord
{
    /// <summary>
    /// 类名称<br>DiagnoseMediccare</br>
    /// <Font color='#FF1111'>医保诊断业务类</Font><br></br>
    /// [创 建 者: ]<br>耿晓雷</br>
    /// [创建时间: ]<br>2007-08-13</br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public class DiagnoseMedicare : Neusoft.FrameWork.Management.Database
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DiagnoseMedicare()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 变量

        #region 私有
        #endregion

        #region 保护
        #endregion

        #region 公开
        #endregion

        #endregion

        #region 属性
        #endregion

        #region 方法

        #region 私有
        /// <summary>
        /// 从实体中获取数据形成数组
        /// </summary>
        /// <param name="Diag"></param>
        /// <returns></returns>
        private string[] myGetItemParm(Neusoft.HISFC.Models.HealthRecord.Diagnose Diag)
        {
            string[] strParm = new string[13];
            String isMain = "";
            if (Diag.DiagInfo.IsMain)
            {
                isMain = "1";
            }
            else
            {
                isMain = "0";
            }
            strParm[0] = Diag.DiagInfo.Patient.ID; // 住院流水号
            strParm[1] = Diag.DiagInfo.HappenNo.ToString();// 发生序号
            strParm[2] = Diag.DiagInfo.Patient.Card.ID; //就诊卡号
            strParm[3] = Diag.DiagInfo.DiagType.ID; // 诊断类别
            strParm[4] = Diag.DiagInfo.ICD10.ID;// 诊断ICD码
            strParm[5] = Diag.DiagInfo.ICD10.Name;// 诊断名称
            strParm[6] = Diag.DiagInfo.ICD10.SpellCode;// 诊断拼音
            strParm[7] = isMain;// 是否主诊断1是0否
            strParm[8] = Diag.Pvisit.PatientLocation.Dept.ID;// 患者科室
            strParm[9] = this.Operator.ID;// 操作员
            strParm[10] = this.GetSysDateTime().ToString();// 操作时间
            strParm[11] = Diag.DiagInfo.DiagDate.ToString();// 诊断时间
            strParm[12] = Diag.DiagInfo.Doctor.ID;// 诊断医生

            return strParm;
        }
        private ArrayList myQuery(string strSQL)
        {
            ArrayList arrl = new ArrayList();
            Neusoft.HISFC.Models.HealthRecord.Diagnose diags;
            this.ExecQuery(strSQL);

            try
            {
                while (this.Reader.Read())
                {
                    diags = new Neusoft.HISFC.Models.HealthRecord.Diagnose();

                    diags.DiagInfo.Patient.ID = this.Reader[0].ToString();//住院流水号
                    diags.DiagInfo.HappenNo = Neusoft.FrameWork.Function.NConvert.ToInt32(this.Reader[1].ToString());//发生序号
                    diags.DiagInfo.Patient.Card.ID = this.Reader[2].ToString();//就诊卡号
                    diags.DiagInfo.DiagType.ID = this.Reader[3].ToString();//诊断类别
                    diags.DiagInfo.ICD10.ID = this.Reader[4].ToString();//诊断ICD码
                    diags.DiagInfo.ICD10.Name = this.Reader[5].ToString();//诊断名称
                    diags.DiagInfo.ICD10.SpellCode = this.Reader[6].ToString();//诊断拼音
                    diags.DiagInfo.IsMain = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.Reader[7].ToString());//是否主诊断
                    diags.Pvisit.PatientLocation.Dept.ID = this.Reader[8].ToString();//患者科室
                    diags.ID = this.Reader[9].ToString();//操作员
                    diags.OperInfo.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[10].ToString());//操作时间
                    diags.DiagInfo.DiagDate = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[11].ToString());//诊断时间
                    diags.DiagInfo.Doctor.ID = this.Reader[12].ToString();//诊断医生
                    diags.DiagInfo.User03 = this.Reader[13].ToString();//诊断代码类别 '医保';'ICD10'
                    diags.OperType = this.Reader[14].ToString();//类别 1 医生站录入诊断  2 病案室录入诊断
                    arrl.Add(diags);
                }
                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = "获得医保病案诊断信息出错![MET_COM_DIAGNOSE_MEDICARE]" + ex.Message;
                this.WriteErr();
                if (!this.Reader.IsClosed)
                {
                    this.Reader.Close();
                }
            }

            this.Reader.Close();

            return arrl;
        }
        #endregion

        #region 保护
        #endregion

        #region 公开
        /// <summary>
        /// 插入一条医保诊断信息
        /// </summary>
        /// <param name="Diag"></param>
        /// <returns></returns>
        public int InsertDiagnoseMedicare(Neusoft.HISFC.Models.HealthRecord.Diagnose Diag)
        {
            String strSQL = "";
            if (this.Sql.GetSql("CASE.DiagnoseMedicare.Insert", ref strSQL) == -1) return -1;
            string[] strParm = myGetItemParm(Diag);
            return this.ExecNoQuery(strSQL, strParm);
        }
        /// <summary>
        /// 查询医保诊断信息
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="HappenNo">发生序号 查询所有可输入%</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryDiagnoseMedicare(string InpatientNO,string HappenNo)
        {
            string strSQL = "";
            if (this.Sql.GetSql("CASE.DiagnoseMedicare.Select", ref strSQL) == -1) return null;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, HappenNo);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.DiagnoseMedicare.Select";
                return null;
            }
            return this.myQuery(strSQL);

        }
        /// <summary>
        /// 查询病案(met_cas_diagnose)和医保(met_com_diagnose_medicare)的诊断信息
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <returns>诊断信息数组元素型: Neusoft.HISFC.Models.HealthRecord.Diagnose</returns>
        public ArrayList QueryDiagnoseBoth(string InpatientNO)
        {
            String strSQL = "";
            if (this.Sql.GetSql("CASE.DiagnoseBoth.Select", ref strSQL) == -1) return null;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO);
            }
            catch
            {
                this.Err = "传入参数不对！CASE.DiagnoseBoth.Select";
                return null;
            }
            return this.myQuery(strSQL);

        }
        /// <summary>
        /// 获取出院主诊断
        /// </summary>
        /// <param name="inpatientNo">住院流水号</param>
        /// <returns>主诊断数组</returns>
        public ArrayList GetOutMainDiagnose(string inpatientNo)
        {
            ArrayList myArr = null;//存放该住院流水号所有诊断信息
            ArrayList mainDiagNose = new ArrayList();//存放出院主诊断信息
            myArr = this.QueryDiagnoseBoth(inpatientNo);
            Neusoft.HISFC.Models.HealthRecord.Diagnose tempDiagNose = null;
            #region 查询出院主诊断，插入数组
            for (int i = 0;i < myArr.Count; i++)
            {
                tempDiagNose = (Neusoft.HISFC.Models.HealthRecord.Diagnose)myArr[i];

                #region 判断是否出院主诊断

                if (tempDiagNose.DiagInfo.User03 == "医保")//是否医保诊断
                {
                    if (tempDiagNose.DiagInfo.IsMain)//是否主诊断
                    {
                        if (tempDiagNose.DiagInfo.DiagType.ID == "1")//诊断类型是否是主诊断（出院诊断）
                        {
                            mainDiagNose.Add(tempDiagNose);
                        }
                    }
                }
                #endregion
            }
            #endregion
            return mainDiagNose;
        }
        /// <summary>
        /// 修改医保诊断
        /// </summary>
        /// <param name="dg">Neusoft.HISFC.Models.HealthRecord.Diagnose</param>
        /// <returns>成功0 失败-1</returns>
        public int UpdateDiagnoseMedicare(Neusoft.HISFC.Models.HealthRecord.Diagnose dg)
        {
            String strSQL = "";
            if (this.Sql.GetSql("CASE.DiagnoseMedicare.Update.1", ref strSQL) == -1) return -1;
            string[] strParm = this.myGetItemParm(dg);
            return this.ExecNoQuery(strSQL, strParm);
        }
        /// <summary>
        /// 删除医保诊断表单条记录
        /// </summary>
        /// <param name="InpatientNO">住院流水号</param>
        /// <param name="happenNO">HAPPEN_NO</param>
        /// <returns>失败 -1</returns>
        public int DeleteDiagnoseMedicare(String InpatientNO, int happenNO)
        {
            String strSQL = "";
            if (this.Sql.GetSql("CASE.DiagnoseMedicare.Delete.1", ref strSQL) == -1) return -1;
            try
            {
                strSQL = string.Format(strSQL, InpatientNO, happenNO.ToString());
            }
            catch
            {
                this.Err = "传入参数不对！CASE.DiagnoseMedicare.Delete.1";
                return -1;
            }
            return this.ExecNoQuery(strSQL);
        }
        #endregion

        #endregion

        #region 事件
        #endregion

        #region 接口实现
        #endregion

    }
}

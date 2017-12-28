using System;
using System.Collections.Generic;
using System.Data;

namespace InterfaceInstanceDefault.IQueryGFPatient
{
    public class IQueryGFPatientDefault : Neusoft.HISFC.BizProcess.Interface.IQueryGFPatient
    {
        #region IQueryGFPatient 成员

        public int QueryGFPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient, ref string errText, params string[] args)
        {
            string pactCode = args[0];
            string mcardNO = args[1];
            if (string.IsNullOrEmpty(pactCode))
            {
                errText = "请先选择患者的合同单位！";
                return -1;
            }
            if (pactCode == "06")
            {
                GFPatientManager manager = new GFPatientManager();
                DataTable dt = manager.QueryGFPatient(mcardNO);
                if (dt == null)
                {
                    errText = "查询公费患者信息失败！" + manager.Err;
                    return -1;
                }
                if(dt.Rows.Count == 0)
                {
                    errText = "该医疗证号信息信息不存在，请重新输入！";
                    return 0;
                }
                patient.Name = dt.Rows[0][2].ToString();
                patient.SSN = dt.Rows[0][1].ToString();
                patient.Sex.Name = dt.Rows[0][3].ToString();
                patient.IDCard = dt.Rows[0][5].ToString();
                patient.CompanyName = dt.Rows[0][6].ToString();
                patient.PhoneHome = dt.Rows[0][7].ToString();
            }
            return 1;
        }

        #endregion
    }

    public class GFPatientManager : Neusoft.FrameWork.Management.Database
    {
        public DataTable QueryGFPatient(string mcardNO)
        {
            string sql = "SELECT xh,ylbzh,xm,xb,rylb,sfzh,dw,lxfs,yllb,bs,nf,bz,add1 " +
                      " FROM zz_fin_ipr_cityresi_baseinfo " +
                     " WHERE  ylbzh='{0}' and bs='有效'";
            sql = string.Format(sql, mcardNO);
            DataSet ds = new DataSet();
            if(this.ExecQuery(sql, ref ds) == -1)
            {
                return null;
            }
            return ds.Tables[0];
        }
    }
}

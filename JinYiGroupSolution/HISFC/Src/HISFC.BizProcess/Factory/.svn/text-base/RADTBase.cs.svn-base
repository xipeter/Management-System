using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.BizProcess.Factory
{
    /// <summary>
    /// 入出转相关
    /// </summary>
    public abstract class RADTBase:FactoryBase
    {
        public virtual Neusoft.HISFC.Models.RADT.PatientInfo QueryPatientInfoByInpatientNO(string inpatientNo)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatientInfoByInpatientNO(inpatientNo);
        }
  
        public virtual  System.Collections.ArrayList  QueryInpatientNOByPatientNO(string patientNo, bool tr)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryInpatientNOByPatientNO(patientNo, tr);        
        }
        public virtual System.Collections.ArrayList QueryInpatientNOByBedNO(string bedNo)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryInpatientNOByBedNO(bedNo);
        }
        public virtual System.Collections .ArrayList  PatientQueryByPcNoRetArray(string str,string str1)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQueryByPcNoRetArray(str,str1);
        }
        public virtual System.Collections.ArrayList QueryPatientByEmpl(string emplCode,string deptCode)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = emplCode;
            return manager.QueryHouseDocPatient(obj, Neusoft.HISFC.Models.Base.EnumInState.I,deptCode);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            Neusoft.HISFC.Models.RADT.InStateEnumService instate = new Neusoft.HISFC.Models.RADT.InStateEnumService();
            instate.ID = "I";
            return manager.PatientQuery(deptCode,instate);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode, int days)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQuery(deptCode, days);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode, Neusoft.HISFC.Models.RADT.InStateEnumService state)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQuery(deptCode, state);
        }

        public virtual System.Collections.ArrayList PatientInfoGet(string strWhere)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientInfoGet(strWhere);
        }



        public virtual System.Collections.ArrayList QuereyPatientByDateAndState(DateTime dt1, DateTime dt2, Neusoft.HISFC.Models.Base.EnumInState state)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatientInfoByTimeInState(dt1, dt2, state.ToString());

        }
        public virtual System.Collections.ArrayList QuereyPatientByDate(DateTime dt1, DateTime dt2)
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatient(dt1, dt2);

        }
    }
}

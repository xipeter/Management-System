using System;
using System.Collections.Generic;
using System.Text;

namespace Neusoft.HISFC.Management.Factory
{
    /// <summary>
    /// 入出转相关
    /// </summary>
    public abstract class RADTBase:FactoryBase
    {
        public virtual Neusoft.HISFC.Object.RADT.PatientInfo QueryPatientInfoByInpatientNO(string inpatientNo)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatientInfoByInpatientNO(inpatientNo);
        }
  
        public virtual  System.Collections.ArrayList  QueryInpatientNOByPatientNO(string patientNo, bool tr)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryInpatientNOByPatientNO(patientNo, tr);        
        }
        public virtual System.Collections.ArrayList QueryInpatientNOByBedNO(string bedNo)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryInpatientNOByBedNO(bedNo);
        }
        public virtual System.Collections .ArrayList  PatientQueryByPcNoRetArray(string str,string str1)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQueryByPcNoRetArray(str,str1);
        }
        public virtual System.Collections.ArrayList QueryPatientByEmpl(string emplCode,string deptCode)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            Neusoft.NFC.Object.NeuObject obj = new Neusoft.NFC.Object.NeuObject();
            obj.ID = emplCode;
            return manager.QueryHouseDocPatient(obj, Neusoft.HISFC.Object.Base.EnumInState.I,deptCode);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            Neusoft.HISFC.Object.RADT.InStateEnumService instate = new Neusoft.HISFC.Object.RADT.InStateEnumService();
            instate.ID = "I";
            return manager.PatientQuery(deptCode,instate);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode, int days)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQuery(deptCode, days);
        }

        public virtual System.Collections.ArrayList QueryPatientByDept(string deptCode, Neusoft.HISFC.Object.RADT.InStateEnumService state)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientQuery(deptCode, state);
        }

        public virtual System.Collections.ArrayList PatientInfoGet(string strWhere)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.PatientInfoGet(strWhere);
        }



        public virtual System.Collections.ArrayList QuereyPatientByDateAndState(DateTime dt1, DateTime dt2, Neusoft.HISFC.Object.Base.EnumInState state)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatientInfoByTimeInState(dt1, dt2, state.ToString());

        }
        public virtual System.Collections.ArrayList QuereyPatientByDate(DateTime dt1, DateTime dt2)
        {
            Neusoft.HISFC.Management.RADT.InPatient manager = new Neusoft.HISFC.Management.RADT.InPatient();
            this.SetDB(manager);
            return manager.QueryPatient(dt1, dt2);

        }
    }
}

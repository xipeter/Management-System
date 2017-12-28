using System;
using System.Collections.Generic;
using System.Text;
using Neusoft.HISFC.Object.Base;
using Neusoft.HISFC.Object.RADT;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Management.Operation;

namespace UFC.Operation
{
    /// <summary>
    /// [功能描述: 环境类]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-01]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public static class Environment
    {
        #region 字段

        private static Neusoft.HISFC.Integrate.Manager integrateManager = new Neusoft.HISFC.Integrate.Manager();
        private static Neusoft.HISFC.Integrate.RADT radtManager = new Neusoft.HISFC.Integrate.RADT();
        private static Neusoft.HISFC.Integrate.Operation.Operation operationManager = new Neusoft.HISFC.Integrate.Operation.Operation();
        private static Neusoft.HISFC.Management.Operation.OpsTableManage tableManager = new Neusoft.HISFC.Management.Operation.OpsTableManage();
        private static Neusoft.HISFC.Integrate.Operation.OpsRecord recordManager = new Neusoft.HISFC.Integrate.Operation.OpsRecord();
        private static Neusoft.HISFC.Integrate.Operation.AnaeRecord anaeManager = new Neusoft.HISFC.Integrate.Operation.AnaeRecord();
        private static System.Collections.ArrayList alAnes;     //麻醉类型
        private static System.Collections.ArrayList alPayKind;  //结算类别
        private static System.Collections.ArrayList alDept;     //科室列表
        //private static Neusoft.NFC.Public.ObjectHelper payKindHelper = new Neusoft.NFC.Public.ObjectHelper();
        private static Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
        private static Neusoft.HISFC.Integrate.Operation.OperationReport reportManager = new Neusoft.HISFC.Integrate.Operation.OperationReport();
        #endregion

        #region 属性
        public static string OperatorID
        {
            get
            {
                return Neusoft.NFC.Management.Connection.Operator.ID;
            }
        }

        public static string OperatorDeptID
        {
            get
            {
                return (Neusoft.NFC.Management.Connection.Operator as Neusoft.HISFC.Object.Base.Employee).Dept.ID;
            }
        }

        /// <summary>
        /// 操者者所在科室
        /// </summary>
        public static NeuObject OperatorDept
        {
            get
            {
                return (Neusoft.NFC.Management.Connection.Operator as Neusoft.HISFC.Object.Base.Employee).Dept;
            }
        }

        public static Neusoft.HISFC.Integrate.Manager IntegrateManager
        {
            get
            {
                return integrateManager;
            }
        }

        public static Neusoft.HISFC.Integrate.RADT RadtManager
        {
            get
            {
                return radtManager;
            }
        }

        public static Neusoft.HISFC.Integrate.Operation.Operation OperationManager
        {
            get
            {
                return operationManager;
            }
        }

        public static Neusoft.HISFC.Management.Operation.OpsTableManage TableManager
        {
            get
            {
                return tableManager;
            }
        }

        public static OpsRecord RecordManager
        {
            get
            {
                return recordManager;
            }
        }

        public static AnaeRecord AnaeManager
        {
            get
            {
                return anaeManager;
            }
        }

        public static bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");


            }
        }

        public static Neusoft.NFC.Interface.Classes.Print Print
        {
            get
            {
                return print;
            }
        }

        public static Neusoft.HISFC.Integrate.Operation.OperationReport ReportManager
        {
            get
            {
                return reportManager;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 得到麻醉
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static NeuObject GetAnes(string id)
        {
            if (alAnes == null)
            {
                alAnes = IntegrateManager.GetConstantList(Neusoft.HISFC.Object.Base.EnumConstant.ANESTYPE);
            }

            foreach (NeuObject obj in alAnes)
            {
                if (obj.ID == id)
                    return obj;
            }

            return null;
        }

        /// <summary>
        /// 得到结算类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Robin   2006-12-12
        public static NeuObject GetPayKind(string id)
        {
            if (alPayKind == null)
            {
                alPayKind = IntegrateManager.GetConstantList(Neusoft.HISFC.Object.Base.EnumConstant.PAYKIND);
            }

            foreach (NeuObject obj in alPayKind)
            {
                if (obj.ID == id)
                    return obj;
            }

            return null;
        }

        /// <summary>
        /// 得到科室
        /// </summary>
        /// <param name="id">科室ID</param>
        /// <returns>科室</returns>
        /// Robin   2006-12-13
        public static NeuObject GetDept(string id)
        {
            if (alDept == null)
            {
                alDept = IntegrateManager.GetDepartment();
            }

            foreach (NeuObject obj in alDept)
            {
                if (obj.ID == id)
                    return obj;
            }

            return null;
        }

        public static int GetPatientInfomation(Neusoft.HISFC.Object.Operation.OperationAppllication operationAppllication)
        {
            operationAppllication.PatientInfo = RadtManager.GetPatientInfomation(operationAppllication.PatientInfo.ID);

            return 0;
        }

        #endregion
    }
}

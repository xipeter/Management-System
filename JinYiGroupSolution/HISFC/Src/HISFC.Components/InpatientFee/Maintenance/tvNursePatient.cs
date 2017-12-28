using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class tvNursePatient : Neusoft.HISFC.Components.Common.Controls.tvPatientList
    {
        public tvNursePatient()
        {
            InitializeComponent();
            
        }

        public tvNursePatient(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private ArrayList dept = null;
        private ArrayList GetDepts(string nurseCode)
        {
            if (dept == null)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager man = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                dept = man.QueryDepartment(nurseCode);
            }
            return dept;
        }

        /// <summary>
        /// ³õÊ¼»¯Ê÷
        /// </summary>
        public void Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.RADT radt = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            ArrayList operDept = this.GetDepts(employee.Nurse.ID);
            
            foreach (Neusoft.FrameWork.Models.NeuObject objDept in operDept)
            {
                ArrayList al = radt.QueryPatient(objDept.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
                al.Insert(0, objDept.Name);
                
                this.SetPatient(al);
            }
            
        }
    }
}

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Controls
{
    /// <summary>
    /// [功能描述: 急诊留观护士站患者列表]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2007-10-20]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class tvEmergencyPatientList:Neusoft.HISFC.Components.Nurse.Controls.tvEmergencyBasePatientList
    {
        public tvEmergencyPatientList()
        {
            InitializeComponent();
            this.ShowType = enuShowType.Bed;
            this.Direction = enuShowDirection.Ahead;
            //if (Neusoft.FrameWork.Management.Connection.Instance != null)
            this.Refresh();
        }

        public tvEmergencyPatientList(IContainer container)
            : this()
        {
            container.Add(this);

        }

        Neusoft.HISFC.BizLogic.Registration.Register manager = null;

        Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        //允许召回天数
        private int allowCallBackDays = 0;
        private ArrayList depts = null;
        private ArrayList GetDepts(string nurseCode)
        {
            if (depts == null)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager m = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                depts = m.QueryDepartment(nurseCode);

            }
            return depts;
        }
        public override void Refresh()
        {
            this.BeginUpdate();
            this.Nodes.Clear();
            if (manager == null)
            {
                manager = new Neusoft.HISFC.BizLogic.Registration.Register();
            }

            ArrayList al = new ArrayList();//患者列表

            //节点说明: 本区患者\待接诊患者\转入患者\转出患者\出院登记患者
            //显示本护理站在院的患者
            al.Add("本区患者|" + EnumPatientType.In.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.In);

            //显示本护理站待接珍患者
            al.Add("待接诊患者|" + EnumPatientType.Arrive.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.R, EnumPatientType.Arrive);

            // {1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            //显示本护理站出关登记的患者
            al.Add("出关登记患者|" + EnumPatientType.PreOut.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.P, EnumPatientType.PreOut);

            al.Add("留观转住院|" + EnumPatientType.PreIn.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.E, EnumPatientType.PreIn);

            //显示本护理站出院登记的患者
            al.Add("留观结束患者|" + EnumPatientType.Out.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.B, EnumPatientType.Out);
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.C, EnumPatientType.Out);
            //显示所有患者列表
            this.SetPatient(al);

            this.EndUpdate();
            base.Refresh();
        }
        ///// <summary>
        ///// 刷新
        ///// </summary>
        //public new void Refresh()
        //{
        //    this.BeginUpdate();
        //    this.Nodes.Clear();
        //    if (manager == null)
        //        manager = new Neusoft.HISFC.BizLogic.Registration.Register();


        //    ArrayList al = new ArrayList();//患者列表

        //    //节点说明: 本区患者\待接诊患者\转入患者\转出患者\出院登记患者
        //    //显示本护理站在院的患者
        //    al.Add("本区患者|" + EnumPatientType.In.ToString());
        //    addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.In);

        //    //显示本护理站待接珍患者
        //    al.Add("待接诊患者|" + EnumPatientType.Arrive.ToString());
        //    addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.R, EnumPatientType.Arrive);

        //    ////显示转入本护理站待接珍患者
        //    //al.Add("转入患者|" + EnumPatientType.ShiftIn.ToString());
        //    //addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.ShiftIn);

        //    ////显示本护理站转科申请的患者
        //    //al.Add("转出患者|" + EnumPatientType.ShiftOut.ToString());
        //    //addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.ShiftOut);

        //    //显示本护理站出院登记的患者
        //    al.Add("留观结束患者|" + EnumPatientType.Out.ToString());
        //    addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.B, EnumPatientType.Out);
           
        //    //显示所有患者列表
        //    this.SetPatient(al);

        //    this.EndUpdate();

        //}

        /// <summary>
        /// 根据病区站得到患者
        /// </summary>
        /// <param name="al"></param>
        private void addPatientList(ArrayList al, Neusoft.HISFC.Models.Base.EnumInState Status, EnumPatientType patientType)
        {
            ArrayList al1 = new ArrayList();

            Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

            if (employee == null) return;

            if (patientType == EnumPatientType.In) //本区在院患者
            {
                al1 = this.registerManager.PatientQueryByNurseCell(employee.Dept.ID, Status.ToString());
                if (al1 != null)
                {
                    al.AddRange(al1);
                }
               
            }
            else
            {
                ArrayList alDept = this.GetDepts(employee.Dept.ID);
                foreach (Neusoft.FrameWork.Models.NeuObject objDept in alDept)
                {
                    //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
                    if (patientType == EnumPatientType.Arrive || patientType == EnumPatientType.PreOut || patientType == EnumPatientType.In || patientType == EnumPatientType.PreIn)
                    {
                        al1 = this.manager.QueryPatient(objDept.ID, Status.ToString());				//按科室接珍
                    }
                    else if (patientType == EnumPatientType.ShiftOut)
                    {
                       // al1 = this.registerManager.QueryPatientShiftOutApply(objDept.ID, "1");				//按科室查转出申请的
                    }
                    else if (patientType == EnumPatientType.ShiftIn)
                    {
                        //al1 = this.registerManager.QueryPatientShiftInApply(objDept.ID, "1");				//按科室查转入申请的
                    }
                    else if (patientType == EnumPatientType.Out)
                    {
                        DateTime dtNow = dataManager.GetDateTimeFromSysDateTime();
                        string strFromDate = dtNow.AddDays(-allowCallBackDays).ToShortDateString() + " 00:00:00" ;
                        
                        
                        al1 = this.manager.QueryPatient(objDept.ID.ToString(), Status.ToString(),strFromDate,dtNow.ToString());				//按科室查出院登记的
                    }
                    if (al1 != null)
                    {
                        al.AddRange(al1);
                    }
                }
            }

  

        }
        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        public enum EnumPatientType
        {
            In = 0,//在院患者
            Arrive = 1,//待接诊患者
            Out = 2,//出院登记患者
            ShiftIn = 3,//转入患者
            ShiftOut = 4,//转出患者
            Dept = 5, //科室列表
            PreOut = 6,//出关登记
            PreIn = 7,//留观转住院
            ChangeIn //住院
        }

    }
}

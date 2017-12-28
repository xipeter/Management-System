using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 护士站患者列表]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人='张琦'
    ///		修改时间='2008-09-3'
    ///		修改目的='控制出院召回患者的有效天数'
    ///		修改描述='在出院患者列表中只显示在有效天数内的患者列表信息'
    ///  />
    /// </summary>
    public partial class tvNursePatientList : Neusoft.HISFC.Components.Common.Controls.tvPatientList
    {
        public tvNursePatientList()
        {
            InitializeComponent();
            this.ShowType = enuShowType.Bed;
            this.Direction = enuShowDirection.Ahead;
            //if (Neusoft.FrameWork.Management.Connection.Instance != null)
            this.Refresh();
        }

        public tvNursePatientList(IContainer container)
            : this()
        {
            container.Add(this);

            //InitializeComponent();
        }
        
        Neusoft.HISFC.BizProcess.Integrate.RADT manager = null;
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
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

        //出院召回的有效天数
        private int callBackVaildDays;
        public const string control_id = "ZY0001";

        /// <summary>
        /// 初始化控制参数,获得出院召回的有效天数
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            this.callBackVaildDays = ctrlParamIntegrate.GetControlParam<int>(control_id, true, 1);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public new void Refresh()
        {
            //{707F2343-20AC-445b-9ACB-2B707C8EA249}
            InitControlParam();
            this.BeginUpdate();
            this.Nodes.Clear();
            if (manager == null)
                manager = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            
            ArrayList al =  new ArrayList();//患者列表

            //节点说明: 本区患者\待接诊患者\转入患者\转出患者\出院登记患者
            //显示本护理站在院的患者
            al.Add("本区患者|"+EnumPatientType.In.ToString());

            addPatientList(al,Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.In);

            //显示本护理站待接珍患者
            al.Add("待接诊患者|" + EnumPatientType.Arrive.ToString());
            
            addPatientList(al,Neusoft.HISFC.Models.Base.EnumInState.R, EnumPatientType.Arrive);

            //显示转入本护理站待接珍患者
            al.Add("转入患者|" + EnumPatientType.ShiftIn.ToString());
            addPatientList(al,Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.ShiftIn);

            //显示本护理站转科申请的患者
            al.Add("转出患者|" + EnumPatientType.ShiftOut.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.I, EnumPatientType.ShiftOut);

            //显示本护理站出院登记的患者
            al.Add("出院登记患者|" + EnumPatientType.Out.ToString());
            addPatientList(al, Neusoft.HISFC.Models.Base.EnumInState.B, EnumPatientType.Out);

            //显示所有患者列表
            this.SetPatient(al);
       
            this.EndUpdate();
			
        }

        /// <summary>
        /// 根据病区站得到患者
        /// </summary>
        /// <param name="al"></param>
        private void addPatientList(ArrayList al, Neusoft.HISFC.Models.Base.EnumInState Status,EnumPatientType patientType)
        {
            ArrayList al1 = new ArrayList();

            Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

            if(employee == null) return;

            if (patientType == EnumPatientType.In) //本区在院患者
            {
                al1 = this.radtManager.PatientQueryByNurseCell(employee.Nurse.ID, Status);

                al.AddRange(al1);
            }
            else
            {
                ArrayList alDept = this.GetDepts(employee.Nurse.ID);
                //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
                //foreach (Neusoft.FrameWork.Models.NeuObject objDept in alDept)
                //{
                //    if(patientType == EnumPatientType.Arrive)
                //    {
                //         al1 = this.manager.QueryPatient(objDept.ID, Status);				//按科室接珍
                //    }
                //    else if (patientType == EnumPatientType.ShiftOut)
                //    {
                //        al1 = this.radtManager.QueryPatientShiftOutApply(objDept.ID, "1");				//按科室查转出申请的
                //    }
                //    else if (patientType == EnumPatientType.ShiftIn)
                //    {
                //        al1 = this.radtManager.QueryPatientShiftInApply(objDept.ID, "1");				//按科室查转入申请的
                                                
                //    }
                //    else if (patientType == EnumPatientType.Out)
                //    {
                //        //{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                //        ////al1 = this.manager.QueryPatient(objDept.ID, Status);				//按科室查出院登记的患者
                //        ////根据出院召回的有效天数查询出院登记患者信息
                //        //InitControlParam();
                //        //al1 = this.manager.QueryPatientByVaildDate(objDept.ID, Status, callBackVaildDays);
                //    }

                //    al.AddRange(al1);
                //}

                //foreach (Neusoft.FrameWork.Models.NeuObject objDept in alDept)
                //{
                    if (patientType == EnumPatientType.Arrive)
                    {
                        al1 = this.manager.QueryPatientByNurseCellAndState(employee.Nurse.ID, Status);				//按科室接珍
                    }
                    else if (patientType == EnumPatientType.ShiftOut)
                    {
                        //al1 = this.radtManager.QueryPatientShiftOutApply(objDept.ID, "1");				//按科室查转出申请的
                        al1 = this.radtManager.QueryPatientShiftOutApplyByNurseCell(employee.Nurse.ID, "1");	
                    }
                    else if (patientType == EnumPatientType.ShiftIn)
                    {
                        //al1 = this.radtManager.QueryPatientShiftInApply(objDept.ID, "1");				//按科室查转入申请的
                        al1 = this.radtManager.QueryPatientShiftInApplyByNurseCell(employee.Nurse.ID, "1");				//按科室查转入申请的

                    }
                    else if (patientType == EnumPatientType.Out)
                    {
                        //{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                        ////al1 = this.manager.QueryPatient(objDept.ID, Status);				//按科室查出院登记的患者
                        ////根据出院召回的有效天数查询出院登记患者信息
                        //InitControlParam();
                        //al1 = this.manager.QueryPatientByVaildDate(objDept.ID, Status, callBackVaildDays);
                    }
                    //{F0BF027A-9C8A-4bb7-AA23-26A5F3539586}
                    //al.AddRange(al1);
               // }
                //if (patientType == EnumPatientType.ShiftIn)
                //{
                //    al1 = this.radtManager.QueryPatientShiftInApplyByNurseCell(employee.Nurse.ID, "1");
                //    al.AddRange(al1);
                //}
                if (patientType == EnumPatientType.Out)
                {
                    //{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                    //根据出院召回的有效天数查询出院登记患者信息
                    al1 = this.radtManager.PatientQueryByNurseCellVaildDate(employee.Nurse.ID, Status, callBackVaildDays);
                    //al.AddRange(al1);
                }
                al.AddRange(al1);

            }                       
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum EnumPatientType
    {
        /// <summary>
        /// 
        /// </summary>
        In = 0,//在院患者
        /// <summary>
        /// 
        /// </summary>
        Arrive = 1,//待接诊患者
        /// <summary>
        /// 
        /// </summary>
        Out = 2,//出院登记患者
        /// <summary>
        /// 
        /// </summary>
        ShiftIn = 3,//转入患者
        /// <summary>
        /// 
        /// </summary>
        ShiftOut = 4,//转出患者
        /// <summary>
        /// 
        /// </summary>
        Dept = 5 //科室列表
    }
}

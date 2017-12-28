using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 出院患者列表]<br></br>
    /// [创 建 者: 张琦]<br></br>
    /// [创建时间: 2008-09-3]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class tvOutHosList : Neusoft.HISFC.Components.Common.Controls.tvPatientList
    {
        #region 初始化

        public tvOutHosList()
        {
            InitializeComponent();
        }

        public tvOutHosList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion      

        #region 变量

        Neusoft.HISFC.BizProcess.Integrate.RADT manager = null;
        Neusoft.HISFC.BizLogic.RADT.InPatient radtManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        Neusoft.HISFC.Models.Base.Employee employee = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
        //出院召回的有效天数
        private int callBackVaildDays;
        public const string control_id = "ZY0001";
        #endregion

        #region 函数

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
        public void Refresh(string deptCode, string beginTime, string endTime)
        {
            if(beginTime==null)
            {
                beginTime = System.DateTime.Now.AddDays(-3).ToShortDateString();
            }
            if(endTime==null)
            {
                endTime = System.DateTime.Now.AddDays(4).ToShortDateString();
            }
            this.BeginUpdate();
            this.Nodes.Clear();
            if (manager == null)
                manager = new Neusoft.HISFC.BizProcess.Integrate.RADT();


            ArrayList al = new ArrayList();//患者列表

            //显示出院登记未过有效召回期的患者
            al.Add("未过有效召回期患者|" + EnumPatientState.InVaildDayPatient.ToString());
            addPatientList(al,deptCode, beginTime, endTime, EnumPatientState.InVaildDayPatient);

            //显示出院登记已过有效召回期的患者
            al.Add("已过有效召回期患者|" + EnumPatientState.OutVaildDayPatient.ToString());
            addPatientList(al,deptCode,beginTime, endTime, EnumPatientState.OutVaildDayPatient);

            //显示所有患者列表
            this.SetPatient(al);
            this.EndUpdate();

        }

        /// <summary>
        /// 根据病区站得到患者
        /// </summary>
        /// <param name="al"></param>
        private void addPatientList(ArrayList al,string deptCode, string beginTime, string endTime, EnumPatientState patientState)
        {
            ArrayList al1 = new ArrayList();
            InitControlParam();
            int myPatientState;
            if (patientState == EnumPatientState.InVaildDayPatient)
            {
                myPatientState = 0;
            }
            else if (patientState == EnumPatientState.OutVaildDayPatient)
            {
                myPatientState = 1;
            }
            else
            {
                myPatientState = 2;
            }
                al1 = this.manager.QueryOutHosPatient(deptCode, beginTime, endTime, callBackVaildDays, myPatientState);
                al.AddRange(al1);

        }
    }
        #endregion
    public enum EnumPatientState
    {
        InVaildDayPatient=0,//在有效召回期内的患者
        OutVaildDayPatient=1,//不在有效召回期内的患者
        OutHos=2 //出院登记患者
 
    }
}

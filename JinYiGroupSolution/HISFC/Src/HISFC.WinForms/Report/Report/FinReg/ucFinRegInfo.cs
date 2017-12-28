using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Common = Report.Common;
//using Manager = Report.Manager;
using System.Collections;

namespace DongDian.Report.FinReg
{
    public partial class ucFinRegInfo : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucFinRegInfo()
        {
            InitializeComponent();
        }
        //科室
        private string DeptCode = string.Empty;
        private string DeptName = string.Empty;
        
        #region 管理类

        Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager powerManager = new Neusoft.HISFC.BizLogic.Manager.UserPowerDetailManager();


        //Manager.PhaPriv phaPriv = new Manager.PhaPriv();
        Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();


        System.Collections.ArrayList DeptList = new System.Collections.ArrayList();

        #endregion

        protected override void OnLoad()
        {
            this.Init();

            string strAll = "all";
            string strName = "全部";

            Neusoft.HISFC.Models.Base.Department deptO = new Neusoft.HISFC.Models.Base.Department();
            deptO.ID = strAll;
            deptO.Name = strName;

            #region 科室
            DeptList = manager.GetDeptmentAllValid();
       //     DeptList = phaPriv.GetAllPrivDept(operDeptCode);
            DeptList.Add(deptO);
            foreach (Neusoft.FrameWork.Models.NeuObject con in DeptList)
            {

                this.neuComboBox1.Items.Add(con);

            }


            if (neuComboBox1.Items.Count >= 0)
            {
                neuComboBox1.SelectedIndex = 0;
                DeptCode = ((Neusoft.FrameWork.Models.NeuObject)neuComboBox1.Items[0]).ID;
                DeptName = ((Neusoft.FrameWork.Models.NeuObject)neuComboBox1.Items[0]).Name;
            }

            #endregion

            SetCmb();

            base.OnLoad();
        }
        protected override int OnRetrieve(params object[] objects)
        {
            #region 科室
            string[] deptStr;
            DeptCode = neuComboBox1.SelectedItem.ID;
            DeptName = neuComboBox1.SelectedItem.Name;

            //if (DeptCode == "all")
            //{

            //    //deptStr = new string[DeptList.Count];
            //    //for (int i = 0; i < DeptList.Count; i++)
            //    //{
            //    //    Neusoft.FrameWork.Models.NeuObject s = DeptList[i] as Neusoft.FrameWork.Models.NeuObject;
            //    //    deptStr[i] = s.ID;
            //    //}
            //    deptStr = new string[]
            //    {
            //        DeptCode
            //    };
            //}
            //else
            //{
            deptStr = new string[]
                {
                    DeptCode
                };
            //}

            #endregion

            dwMain.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,deptStr);
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,deptStr);
        }

        private void SetCmb()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager m = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList al = m.GetDepartment();
            string strAll = "all";
            string strName = "全部";


            if (al == null) return;
            Neusoft.HISFC.Models.Base.Department deptO = new Neusoft.HISFC.Models.Base.Department();
            deptO.ID = strAll;
            deptO.Name = strName;
            al.Add(deptO);
            this.neuComboBox1.AddItems(al);
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptCode = this.neuComboBox1.Tag.ToString();
        }

    }
}
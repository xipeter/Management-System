using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    public partial class tvInpatientConfirm : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvInpatientConfirm()
        {
            InitializeComponent(); 
        }

        public tvInpatientConfirm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 变量

        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        
        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        #endregion

        #region 方法

        public void Init()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList alDept = deptManager.GetDeptmentAllValid();
            if (alDept == null)
            {
                return;
            }

            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            this.ImageList = this.deptImageList;
            this.RefreshTree();
        }
        string operDept = "";
        public string OperDept
        {
            get
            {
                return operDept;
            }

            set
            {
                operDept = value;
            }
        }
        /// <summary>
        /// 列表显示
        /// </summary>
        /// <returns></returns>
        public int RefreshTree()
        {
            Neusoft.HISFC.BizProcess.Integrate.Order orderManager = new Neusoft.HISFC.BizProcess.Integrate.Order();
            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            Neusoft.HISFC.BizProcess.Integrate.RADT patientManager = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            if (string.IsNullOrEmpty(operDept))
            {
                operDept = oper.Dept.ID;
            }
            ArrayList alDept = orderManager.QueryPatientDeptByConfirmDeptID(operDept);

            this.Nodes.Clear(); 

            System.Windows.Forms.TreeNode deptNode = new System.Windows.Forms.TreeNode();

            foreach (Neusoft.FrameWork.Models.NeuObject dept in alDept)
            {
                deptNode = new System.Windows.Forms.TreeNode();

                deptNode.Text = this.deptHelper.GetName(dept.ID);
                deptNode.ImageIndex = 0;
                deptNode.SelectedImageIndex = 1;
                deptNode.Tag = deptManager.GetDepartment(dept.ID);

                this.Nodes.Add(deptNode);

                ArrayList alPatient = orderManager.QueryPatientByConfirmDeptAndPatDept(operDept, dept.ID);
                foreach (Neusoft.FrameWork.Models.NeuObject patient in alPatient)
                {
                    System.Windows.Forms.TreeNode patientNode = new System.Windows.Forms.TreeNode();
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = patientManager.QueryPatientInfoByInpatientNO(patient.ID);
                    patientNode.Text = patientInfo.Name;
                    patientNode.ImageIndex = 6;
                    patientNode.SelectedImageIndex = 7;
                    patientNode.Tag = patientInfo;

                    deptNode.Nodes.Add(patientNode);
                }

            }

            return 1;
        }

        public override void Refresh()
        {
            this.RefreshTree();
            base.Refresh();
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.MET.MetTec
{
    public partial class ucMetTecConfirmItems : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetTecConfirmItems()
        {
            InitializeComponent();
            InitCboPatientType();
            InitCboRecipeDept();
        }

        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.Models.Base.Employee emp = new Neusoft.HISFC.Models.Base.Employee();
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        private ArrayList alDept = new ArrayList();
        private ArrayList alDept1 = new ArrayList();
        private ArrayList alPatient =new ArrayList();
        private string rdeptID = string.Empty;
        private string rdeptName = string.Empty;
        private string deptNo = string.Empty;
        private string patientTypeID = string.Empty;
        private string patientTypeName = string.Empty;

        Boolean isAllDept = false;
        [Category("控件设置"), Description("是否仅显示本科执行的项目")]
        public Boolean IsAllDept
        {
            get { return isAllDept; }
            set { isAllDept = value; }
        }
        

        private void InitCboRecipeDept()
        {
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "ALL";
            obj1.Name = "全部";
            alDept.Add(obj1);
            alDept1 = deptManager.GetDeptmentAll();
            alDept.AddRange(alDept1);
            this.cboRecipeDept.AddItems(alDept);
            if (this.cboRecipeDept.Items.Count > 0)
            {
                this.cboRecipeDept.SelectedIndex = 0;
            }
        }

        private void InitCboPatientType()
        {
            Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
            obj3.ID = "ALL";
            obj3.Name = "全部";
            this.alPatient.Add(obj3);
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "ZY";
            obj1.Name = "住院";
            this.alPatient.Add(obj1);
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "MZ";
            obj2.Name = "门诊";
            this.alPatient.Add(obj2);
            this.cboPatientType.AddItems(alPatient);
            this.cboPatientType.SelectedIndex = 0;
        }
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            emp = (Neusoft.HISFC.Models.Base.Employee)dept.Operator;

            this.dwMain.SetRedrawOff();
            base.OnRetrieve(base.beginTime, base.endTime, rdeptID, patientTypeID);

            if (!isAllDept)
            {
                this.dwMain.Dv.RowFilter = "compute_0010 ='"+this.emp.Dept.Name+"'";
            }
            this.dwMain.SetRedrawOn();

            return this.dwMain.RowCount;
           // return base.OnRetrieve(base.beginTime, base.endTime, rdeptID, emp.ID,patientTypeID, rdeptName, this.emp.Dept.Name, patientTypeName);
        }

        private void cboRecipeDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdeptID = ((Neusoft.FrameWork.Models.NeuObject)alDept[this.cboRecipeDept.SelectedIndex]).ID.ToString();
            rdeptName = ((Neusoft.FrameWork.Models.NeuObject)alDept[this.cboRecipeDept.SelectedIndex]).Name.ToString();
        }

        private void cboPatientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            patientTypeID = ((Neusoft.FrameWork.Models.NeuObject)alPatient[this.cboPatientType.SelectedIndex]).ID.ToString();
            patientTypeName = ((Neusoft.FrameWork.Models.NeuObject)alPatient[this.cboPatientType.SelectedIndex]).Name.ToString();
        }

        private void ucMetTecConfirmItems_Load(object sender, EventArgs e)
        {
            this.dtpBeginTime.Value = Convert.ToDateTime(this.dtpBeginTime.Value.ToShortDateString());
            this.dtpEndTime.Value = this.dtpBeginTime.Value.AddDays(1).AddSeconds(-1);
        }
       
    }
}

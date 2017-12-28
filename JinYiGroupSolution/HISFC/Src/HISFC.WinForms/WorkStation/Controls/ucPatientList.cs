using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.WinForms.WorkStation.Controls
{
    /// <summary>
    /// 患者信息及功能
    /// </summary>
    public partial class ucPatientList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPatientList()
        {
            InitializeComponent();
            this.button2.Click += new EventHandler(button2_Click);
            this.button3.Click += new EventHandler(button3_Click);
            this.button4.Click += new EventHandler(button4_Click);
            this.button6.Click += new EventHandler(button6_Click);
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            {
                this.SetPatient(neuObject as Neusoft.HISFC.Models.RADT.PatientInfo);
                this.neuSpread1_Sheet1.ActiveRowIndex = 0;
            }
           
            return 0;
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {

            return new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        }


        protected virtual void SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.neuSpread1_Sheet1.Rows.Add(0, 1);
            this.neuSpread1_Sheet1.Cells[0, 0].Text = patient.Name; //姓名
            this.neuSpread1_Sheet1.Cells[0, 1].Text = patient.Sex.ToString();//性别
            this.neuSpread1_Sheet1.Cells[0, 2].Text = patient.Age.ToString();//年龄
            this.neuSpread1_Sheet1.Cells[0, 3].Text = "";//诊断
            this.neuSpread1_Sheet1.Cells[0, 4].Text = "";//过敏
            this.neuSpread1_Sheet1.Cells[0, 5].Text = patient.PVisit.PatientLocation.Bed.Name + "-" +  patient.PVisit.PatientLocation.Dept.Name;//位置
            this.neuSpread1_Sheet1.Rows[0].Tag = patient;

        }

        protected virtual void InitPatientList()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            ArrayList al1 = new ArrayList();
            al1 = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientByEmpl( Neusoft.FrameWork.Management.Connection.Operator.ID, ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID );
            if (al1 == null || al1.Count == 0) //无分管患者
            {
                this.ReadDeptPatients();
            }
            else //科室患者
            {
                foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in al1)
                {
                    SetPatient(patient);
                }
            }
        }
        protected void ReadDeptPatients()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            ArrayList al1 = new ArrayList();
            al1 = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateRADT.QueryPatientByDept( ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID );
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patient in al1)
            {
                SetPatient(patient);
            }

        }
        private void ucPatientList_Load(object sender, EventArgs e)
        {
            this.InitPatientList();
        }

        private Neusoft.HISFC.Models.RADT.PatientInfo GetCurrentPatient()
        {
            if (this.neuSpread1_Sheet1.ActiveRow == null) return null;
            return this.neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
        }

        #region 接口
        private Interface.IEMRable myEMR = null;

        protected Interface.IEMRable EMR
        {
            get
            {
                if (myEMR == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    myEMR = getInstance(form.GetEmr()) as Interface.IEMRable;
                }
                return myEMR;
            }
        }

        private Interface.IOrderable myOrder = null;

        protected Interface.IOrderable Order
        {
            get
            {
                if (myOrder == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    myOrder = getInstance(form.GetOrder()) as Interface.IOrderable;
                }
                return myOrder;

            }
        }

        private Interface.ILisable myLis = null;

        protected Interface.ILisable Lis
        {
            get
            {
                if (myLis == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    myLis = getInstance(form.GetLis()) as Interface.ILisable;
                }
                return myLis;
            }
        }

        private Interface.IPacsable myPacs = null;

        protected Interface.IPacsable Pacs
        {
            get
            {
                if (myPacs == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    myPacs = getInstance(form.GetPacs()) as Interface.IPacsable;
                }
                return myPacs;
            }
        }

        private Interface.IConsulatation myConsulation = null;

        protected Interface.IConsulatation Consulation
        {
            get
            {
                if (myConsulation == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    myConsulation = getInstance(form.GetConsulation()) as Interface.IConsulatation;
                }
                return myConsulation;
            }
        }

        private Neusoft.HISFC.Components.EPR.Interface.ISearchPatient mySearchPatient = null;

        protected Neusoft.HISFC.Components.EPR.Interface.ISearchPatient SearchPatient
        {
            get
            {
                if (mySearchPatient == null)
                {
                    frmPatientListSet form = new frmPatientListSet();
                    mySearchPatient = getInstance(form.GetSearchPatient()) as Neusoft.HISFC.Components.EPR.Interface.ISearchPatient;
                }
                return mySearchPatient;

            }
        }

        #endregion

        #region 功能按键


        /// <summary>
        /// 电子病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            EMR.SetValue(this.GetCurrentPatient());
            EMR.Show();
        }


        private object getInstance(Neusoft.FrameWork.Models.NeuObject obj)
        {
            if (obj.ID == "" || obj.Name == "") return null;
            System.Reflection.Assembly assembly = null;

            assembly = System.Reflection.Assembly.LoadFrom(obj.ID);
            Type type = assembly.GetType(obj.Name);
            if (type == null)
            {

                return null;
            }
            System.Object objHandle = System.Activator.CreateInstance(type);
            return objHandle;
        }
        /// <summary>
        /// 定制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            frmPatientListSet form = new frmPatientListSet();
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
        /// <summary>
        /// 查找患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            SearchPatient.OnSelectedPatient += new Neusoft.HISFC.Components.EPR.Interface.ObjectHandle( SearchPatient_OnSelectedPatient );
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(SearchPatient.SearchControl);
        }

        void SearchPatient_OnSelectedPatient(Neusoft.FrameWork.Models.NeuObject patient)
        {
            this.SetValue(patient,null);
        }
        
        //科室患者
        private void button8_Click(object sender, EventArgs e)
        {
            this.ReadDeptPatients();
        }

        void button6_Click(object sender, EventArgs e)
        {
            //会诊
            Consulation.SetValue(this.GetCurrentPatient());
            Consulation.Show();
        }

        void button4_Click(object sender, EventArgs e)
        {
            //pacs
            Pacs.SetValue(this.GetCurrentPatient());
            Pacs.Show();
        }

        void button3_Click(object sender, EventArgs e)
        {
            //LIS
            Lis.SetValue(this.GetCurrentPatient());
            Lis.Show();
        }

        void button2_Click(object sender, EventArgs e)
        {
            //医嘱
            Order.SetValue(this.GetCurrentPatient());
            Order.Show();
        }
        #endregion

       
      

    }
}

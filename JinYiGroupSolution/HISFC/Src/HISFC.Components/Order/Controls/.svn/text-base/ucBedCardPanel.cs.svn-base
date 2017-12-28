using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    public partial class ucBedCardPanel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private ArrayList myValues;
        private Neusoft.HISFC.BizProcess.Integrate.RADT Patient = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private ArrayList myPatients = null;

        public ucBedCardPanel()
        {
            InitializeComponent();
        }
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            if (tv != null && tv.CheckBoxes == false)
                tv.CheckBoxes = true;
            return base.OnInit(sender, neuObject, param);
        }
        /// <summary>
        /// 数值
        /// </summary>
        private ArrayList alValues
        {
            get
            {
                return this.myValues;
            }
            set
            {
                this.myValues = value;
                if (value != null)
                {
                    this.neuPanel1.Controls.Clear();
                    //{A12B2819-A0CC-4ba4-9C57-A6530D72AAFB}
                    Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(value, typeof(ucBedCardFp), this.neuPanel1, new System.Drawing.Size(790, 1150));

                    #region 暂时不用
                    //if (this.rbBed.Checked)
                    //    Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(value, new ucBedCard(), this.panel1, new System.Drawing.Size(800, 1200));
                    //else if (this.rbBrowse.Checked)
                    //    Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(value, new ucBrowseCard(), this.panel1, new System.Drawing.Size(800, 1200));
                    //else if (this.rdOtherCard.Checked)
                    //{
                    //    Neusoft.FrameWork.WinForms.Classes.Function.AddControlToPanel(value, new ucCard(), this.panel1, new System.Drawing.Size(800, 1200));
                    //}
                    #endregion
                }
            }
        }

        /// <summary>
        /// 患者信息
        /// </summary>
        public ArrayList Patients
        {
            get
            {
                return this.myPatients;
            }
            set
            {
                this.myPatients = value;
            }
        }

        private void myQuery()
        {
            ArrayList al = new ArrayList();

            if (this.myPatients == null) return;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询患者信息...");
            for (int i = 0; i < this.myPatients.Count; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo P = new Neusoft.HISFC.Models.RADT.PatientInfo();

                //P = this.Patient.QueryPatientInfoByInpatientNO(((Neusoft.HISFC.Models.RADT.PatientInfo)this.myPatients[i]).ID);
                P = this.Patient.GetPatientInfomation(((Neusoft.HISFC.Models.RADT.PatientInfo)this.myPatients[i]).ID);
                if (P == null)
                {
                    MessageBox.Show(Patient.Err);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                al.Add(P);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            this.alValues = al;

            #region 暂时不用
            //if (this.rbBed.Checked)
            //    this.tabPage1.Title = this.rbBed.Text;
            //else if (this.rbBrowse.Checked)
            //    this.tabPage1.Title = this.rbBrowse.Text;
            //else
            //    this.tabPage1.Title = this.comboBox1.Text;
            #endregion
        }

        private void ucBedCardPanel_Load(object sender, EventArgs e)
        {
            //this.myPatients = this.Patient.QueryPatient(Neusoft.HISFC.Models.Base.EnumInState.I);
            //Neusoft.HISFC.BizLogic.Manager.Constant manager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            //this.neuComboBox1.AddItems(manager.GetList("NURSECARD"));
            //if (this.neuComboBox1.Items.Count > 0)
            //    this.neuComboBox1.SelectedIndex = 0;
        }

        //protected override int OnSetValue(object neuObject, TreeNode e)
        //{
        //    if (tv != null && tv.CheckBoxes == false)
        //        tv.CheckBoxes = true;
        //    return 0;
        //}

        #region donggq--20101118--{7DC99247-EB4B-4660-87D0-E581F9247F51}

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            if (tv != null && this.tv.CheckBoxes == false)
            {
                tv.CheckBoxes = true;
            }

            if (e != null && e.Tag.ToString() != "In")
            {
                ArrayList patientList = new ArrayList();
                patientList.Add((Neusoft.HISFC.Models.RADT.PatientInfo)e.Tag);
                return this.SetValues(patientList, e);
            }

            return base.OnSetValue(neuObject, e);
        }

        #endregion

        protected override int OnSetValues(ArrayList alValues, object e)
        {
            if (alValues == null )
                return -1;

            this.Patients = alValues;
            this.myQuery();
            return 0;
        }
        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPage(0, 0, this.neuPanel1);
            return 0;
        }
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.PrintPreview( this.neuPanel1);
            return 0;
        }
    }
}
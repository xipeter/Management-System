using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// {A12B2819-A0CC-4ba4-9C57-A6530D72AAFB}
    /// </summary>
    public partial class ucBedCardFp : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {

        private int vnum = 0;
        private int hnum = 0;

        /// <summary>
        /// 
        /// </summary>
        public ucBedCardFp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orgBedNo"></param>
        /// <returns></returns>
        private string BedDisplay(string orgBedNo)
        {
            if (orgBedNo == "")
            {
                return orgBedNo;
            }

            string tempBedNo = "";
            //int tempBedNoInt = 0;

            if (orgBedNo.Length > 4)
            {
                tempBedNo = orgBedNo.Substring(4);
            }
            else
            {
                return orgBedNo;
            }
            return tempBedNo;
        }

        #region 变量

        //传递患者信息类
        private Neusoft.HISFC.Models.RADT.PatientInfo patient;

        /// <summary>
        /// 接收传过来的患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return this.patient;
            }
            set
            {
                this.patient = value;
                SetInfo(); 
            }

        }

        Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase diagManager = new Neusoft.HISFC.BizProcess.Integrate.HealthRecord.HealthRecordBase();

        #endregion

        #region 方法

        /// <summary>
        /// 传递病人实体信息
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.Patient = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;
            return base.OnSetValue(neuObject, e);
        }
        /// <summary>
        /// 设置显示信息
        /// </summary>
        private void SetInfo()
        {
            if (this.Patient != null)
            {
                this.fpBedCard_Sheet1.Cells[1, 1].Text = this.Patient.Name;
                this.fpBedCard_Sheet1.Cells[1, 3].Text = this.Patient.Sex.Name;
                #region 年龄用统一的算法 {9BE8D34E-752D-4d32-A37C-87C62A949C55} wbo 2010-10-23
                //this.fpBedCard_Sheet1.Cells[1, 5].Text = this.Patient.Age;
                try
                {
                    this.fpBedCard_Sheet1.Cells[1, 5].Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.Patient.Birthday);
                }
                catch (Exception ex)
                { }
                #endregion
                this.fpBedCard_Sheet1.Cells[1, 7].Text = this.BedDisplay(this.Patient.PVisit.PatientLocation.Bed.ID);
                this.fpBedCard_Sheet1.Cells[2, 1].Text = this.Patient.PVisit.PatientLocation.Dept.Name;
                this.fpBedCard_Sheet1.Cells[2, 3].Text = this.Patient.PID.PatientNO;
                this.fpBedCard_Sheet1.Cells[2, 6].Text = this.Patient.PVisit.InTime.ToString("yyyy-MM-dd");

                ArrayList alDiag = diagManager.QueryDiagnoseNoOps(this.Patient.ID);

                if (alDiag != null && alDiag.Count > 0)
                {
                    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose diag in alDiag)
                    {
                        if (diag.DiagInfo.DiagType.ID == "1")
                        {
                            this.fpBedCard_Sheet1.Cells[3, 1].Text = diag.DiagInfo.Name;
                        }
                    }
                }
                this.fpBedCard_Sheet1.Cells[3, 5].Text = this.Patient.Disease.Tend.Name;
                this.fpBedCard_Sheet1.Cells[3, 7].Text = this.Patient.Disease.Memo;
                this.fpBedCard_Sheet1.Cells[4, 1].Text = this.Patient.PVisit.AdmittingDoctor.Name;
                this.fpBedCard_Sheet1.Cells[4, 5].Text = this.Patient.PVisit.AdmittingNurse.Name;
            }
        }

        #endregion

        #region IControlPrintable 成员

        public int BeginHorizontalBlankWidth
        {
            get
            {
                return 5;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int BeginVerticalBlankHeight
        {
            get
            {
                return 10;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public System.Collections.ArrayList Components
        {
            get
            {
                return null;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public Size ControlSize
        {
            get 
            {
                return new Size(386, 147);
                //throw new Exception("The method or operation is not implemented."); 
            }
        }

        public object ControlValue
        {
            get
            {
                return null;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                Neusoft.HISFC.Models.RADT.PatientInfo P = value as Neusoft.HISFC.Models.RADT.PatientInfo;
                if (P == null) return;

                //this.lblName.Text = P.Name;
                //this.lblBed.Text = this.BedDisplay(P.PVisit.PatientLocation.Bed.ID);
                //this.lblSex.Text = P.Sex.Name;
                //this.lblAge.Text = P.Age;
                //this.lblPatient.Text = P.PID.PatientNO;
                //if (P.PVisit.InTime.ToString().Substring(6, 1) != "-")
                //    this.lblIndate.Text = P.PVisit.InTime.ToString().Substring(0, 10);
                //else
                //    this.lblIndate.Text = P.PVisit.InTime.ToString().Substring(0, 9);
                //throw new Exception("The method or operation is not implemented.");
                this.fpBedCard_Sheet1.Cells[1, 1].Text = P.Name;
                this.fpBedCard_Sheet1.Cells[1, 3].Text = P.Sex.Name;
                #region 年龄用统一的算法 {9BE8D34E-752D-4d32-A37C-87C62A949C55} wbo 2010-10-23
                //this.fpBedCard_Sheet1.Cells[1, 5].Text = P.Age;
                try
                {
                    this.fpBedCard_Sheet1.Cells[1, 5].Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(P.Birthday);
                }
                catch (Exception ex)
                { }
                #endregion
                this.fpBedCard_Sheet1.Cells[1, 7].Text = this.BedDisplay(P.PVisit.PatientLocation.Bed.ID);
                this.fpBedCard_Sheet1.Cells[2, 1].Text = P.PVisit.PatientLocation.Dept.Name;
                this.fpBedCard_Sheet1.Cells[2, 3].Text = P.PID.PatientNO;
                this.fpBedCard_Sheet1.Cells[2, 6].Text = P.PVisit.InTime.ToString("yyyy-MM-dd");
                ArrayList alDiag = diagManager.QueryDiagnoseNoOps(P.ID);
                #region{5B06E0A1-8F05-45bc-B056-26E485F10382}
                FarPoint.Win.Spread.CellType.TextCellType cellType = new FarPoint.Win.Spread.CellType.TextCellType();
                cellType.WordWrap = true;
                this.fpBedCard_Sheet1.Cells[3, 1].CellType = cellType;
                #endregion
                //hzl 2011.02.15 {46CB4A9F-2E28-4f7a-8D5C-64B3C5492D82} modify:注释床头卡诊断原来取值方式，修改为从门诊诊断中取值
                //if (alDiag != null && alDiag.Count > 0)
                //{
                //    foreach (Neusoft.HISFC.Models.HealthRecord.Diagnose diag in alDiag)
                //    {
                //        if (diag.DiagInfo.DiagType.ID == "1")
                //        {
                //            this.fpBedCard_Sheet1.Cells[3, 1].Text = diag.DiagInfo.Name;
                //        }
                //    }
                //}   
                
                this.fpBedCard_Sheet1.Cells[3, 1].Text = P.ClinicDiagnose;
                this.fpBedCard_Sheet1.Cells[3, 5].Text = P.Disease.Tend.Name;
                this.fpBedCard_Sheet1.Cells[3, 7].Text = P.Disease.Memo;
                this.fpBedCard_Sheet1.Cells[4, 1].Text = P.PVisit.AdmittingDoctor.Name;
                this.fpBedCard_Sheet1.Cells[4, 5].Text = P.PVisit.AdmittingNurse.Name;
            }
        }

        public int HorizontalBlankWidth
        {
            get
            {
                return 10;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int HorizontalNum
        {
            get
            {
                return this.hnum;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                this.hnum = value;
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsCanExtend
        {
            get
            {
                return false;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsShowGrid
        {
            get
            {
                return false;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int VerticalBlankHeight
        {
            get
            {
                return 10;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        public int VerticalNum
        {
            get
            {
                return this.vnum;
                //throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                this.vnum = value;
                //throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion


    }
}

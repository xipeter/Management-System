using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Controls
{
    /// <summary>
    /// [功能描述: 患者卡片]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucPatientCard : UserControl,
        Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {
        public ucPatientCard()
        {
            InitializeComponent();
        }

        #region IControlPrintable 成员

        public int BeginHorizontalBlankWidth
        {
            get
            {
                return 5;
            }
            set
            {
               
            }
        }

        public int BeginVerticalBlankHeight
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        public System.Collections.ArrayList Components
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public Size ControlSize
        {
            get {  return new Size (181, 288); }
        }
        protected int vnum = 0;
        protected int hnum = 0;
        public object ControlValue
        {
            get
            {
                return null;
            }
            set
            {
                Neusoft.HISFC.Models.RADT.PatientInfo PInfo = value as Neusoft.HISFC.Models.RADT.PatientInfo;
                if (PInfo == null) return;
                if (PInfo.PVisit.PatientLocation.Bed.Status.ID.ToString() == "W")
                    this.lblBed.Text = PInfo.PVisit.PatientLocation.Bed.ID.Substring(4) + "【包】";
                else
                    this.lblBed.Text = PInfo.PVisit.PatientLocation.Bed.ID.Length >= 4 ? PInfo.PVisit.PatientLocation.Bed.ID.Substring(4) : PInfo.PVisit.PatientLocation.Bed.ID;

                this.lblName.Text = PInfo.Name;
                this.lblSex.Text = PInfo.Sex.Name;

                if (PInfo.Name != "")
                    this.lblAge.Text = PInfo.Age;

                this.lblInpatientNo.Text = PInfo.PID.PatientNO;
                this.lblFood.Text = PInfo.Disease.Memo;
                this.lblTend.Text = PInfo.Disease.Tend.Name;
                if (PInfo.Diagnoses != null && PInfo.Diagnoses.Count > 0) this.lblDiagnose.Text = PInfo.Diagnoses[0].ToString();
                this.lblIndate.Text = PInfo.PVisit.InTime.ToString().Substring(0, 10);
                if (PInfo.Diagnoses.Count > 0) this.lblDiagnose.Text = PInfo.Diagnoses[0].ToString();
			
            }
        }

        public int HorizontalBlankWidth
        {
            get
            {
                return 10;
            }
            set
            {
                
            }
        }

        public int HorizontalNum
        {
            get
            {
                return hnum;
            }
            set
            {
                hnum = value;
            }
        }

        public bool IsCanExtend
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public bool IsShowGrid
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public int VerticalBlankHeight
        {
            get
            {
                return 10;
            }
            set
            {
                
            }
        }

        public int VerticalNum
        {
            get
            {
                return vnum;
            }
            set
            {
                vnum = value;
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.RADT.Controls
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
        //{46063507-0C5A-405d-BD9D-4762ADE8DE02}
        Neusoft.HISFC.Models.RADT.PatientInfo PInfo = null;
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
            get {  return new Size (181, 275); }
        }
        protected int vnum = 0;
        protected int hnum = 0;
        public object ControlValue
        {
            get
            {
                //{46063507-0C5A-405d-BD9D-4762ADE8DE02}
                return PInfo;
            }
            set
            {
                //{46063507-0C5A-405d-BD9D-4762ADE8DE02}
                PInfo = value as Neusoft.HISFC.Models.RADT.PatientInfo;
                if (PInfo == null) return;
                if (PInfo.PVisit.PatientLocation.Bed.Status.ID.ToString() == "W")
                    this.lblBed.Text = PInfo.PVisit.PatientLocation.Bed.ID.Substring(4) + "【包】";
                else
                    this.lblBed.Text = PInfo.PVisit.PatientLocation.Bed.ID.Length >= 4 ? PInfo.PVisit.PatientLocation.Bed.ID.Substring(4) : PInfo.PVisit.PatientLocation.Bed.ID;

                this.lblName.Text = PInfo.Name;
                this.lblSex.Text = PInfo.Sex.Name;
                #region {5F752A30-7971-4b65-A84B-D233EF2A4406}
                if (PInfo.Name != "")
                {
                    //this.lblAge.Text = PInfo.Age;
                    //{E97C4002-8168-4e06-9CB5-C2331FAD09BC} 年龄采用统一方法 by guanyx
                    try
                    {
                        this.lblAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(PInfo.Birthday);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    this.lblAge.Text = "";
                }

                this.lblInpatientNo.Text = PInfo.PID.PatientNO;
                this.lblFood.Text = PInfo.Disease.Memo;
                this.lblTend.Text = PInfo.Disease.Tend.Name;
                if (PInfo.Diagnoses != null && PInfo.Diagnoses.Count > 0)
                {
                    this.lblDiagnose.Text = PInfo.Diagnoses[0].ToString();
                    //{F764A18C-FF2B-4f36-BDE2-B5C795077097}
                    ToolTip to = new ToolTip();
                    to.ShowAlways = true;
                    to.SetToolTip(lblDiagnose, PInfo.Diagnoses[0].ToString());
                    
                }
                else
                {
                    this.lblDiagnose.Text = "";
                }

                
                //{997A8EEC-A27E-492f-941A-CDEAA3CC4AE7}
                this.lblIndate.Text = PInfo.PVisit.InTime.ToString("yyyy-MM-dd");
                if (this.lblIndate.Text.Contains("0001"))
                {
                    this.lblIndate.Text = "";
                }
                //if (PInfo.Diagnoses.Count > 0) this.lblDiagnose.Text = PInfo.Diagnoses[0].ToString();
                #region {6429B24A-3573-429f-8CE3-C375549CE30F}
                this.lblPact.Text = PInfo.Pact.Name;
                this.lblDoctor.Text = PInfo.PVisit.AdmittingDoctor.Name;

                Neusoft.FrameWork.WinForms.Classes.ControlParam ctrlParm = new Neusoft.FrameWork.WinForms.Classes.ControlParam();
                List<Neusoft.FrameWork.WinForms.Classes.ControlParam> listCtrl = new List<Neusoft.FrameWork.WinForms.Classes.ControlParam>();
                Neusoft.FrameWork.WinForms.Classes.ControlParamManager ctrlManager = new Neusoft.FrameWork.WinForms.Classes.ControlParamManager();
                    

                if (PInfo.Disease.Tend.Name.Contains("一级护理"))
                {

                    listCtrl = ctrlManager.QueryByID("200305");
                    if (listCtrl != null && listCtrl.Count > 0)
                    {
                        ctrlParm = listCtrl[0];
                        if (ctrlParm.ParamControlKind == "颜色")
                        {
                            this.SetTextForeColor(Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(ctrlParm.ParamValue)));
                        }
                    }
                }
                else if (PInfo.Disease.Tend.Name.Contains("二级护理"))
                {
                    listCtrl = ctrlManager.QueryByID("200306");
                    if (listCtrl != null && listCtrl.Count > 0)
                    {
                        ctrlParm = listCtrl[0];
                        if (ctrlParm.ParamControlKind == "颜色")
                        {
                            this.SetTextForeColor(Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(ctrlParm.ParamValue)));
                        }
                    }
                }
                else if (PInfo.Disease.Tend.Name.Contains("三级护理"))
                {
                    listCtrl = ctrlManager.QueryByID("200307");
                    if (listCtrl != null && listCtrl.Count > 0)
                    {
                        ctrlParm = listCtrl[0];
                        if (ctrlParm.ParamControlKind == "颜色")
                        {
                            this.SetTextForeColor(Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(ctrlParm.ParamValue)));
                        }
                    }
                }

                #endregion
                #endregion


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

        /// <summary>
        /// {6429B24A-3573-429f-8CE3-C375549CE30F}
        /// </summary>
        /// <param name="curcolor"></param>
        private void SetTextForeColor(Color curcolor)
        {
            this.lblAge.ForeColor = curcolor;
            this.lblBed.ForeColor = curcolor;
            this.lblDiagnose.ForeColor = curcolor;
            this.lblDoctor.ForeColor = curcolor;
            this.lblFood.ForeColor = curcolor;
            this.lblIndate.ForeColor = curcolor;
            this.lblInpatientNo.ForeColor = curcolor;
            this.lblName.ForeColor = curcolor;
            this.lblPact.ForeColor = curcolor;
            this.lblSex.ForeColor = curcolor;
            this.lblTend.ForeColor = curcolor;
            //this.lblBed.ForeColor = curcolor;
        }

        private void ucPatientCard_Click(object sender, EventArgs e)
        {
            if (this.BackColor == System.Drawing.SystemColors.Control)
            {
                this.BackColor = Color.Blue;
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.Control;
            }
        }

    }
}

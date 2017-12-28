using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    public partial class ucFeeAlertQueryPrintPanel : UserControl
    {
        public ucFeeAlertQueryPrintPanel()
        {
            InitializeComponent();
        }

        //
        private ArrayList alPatientInfo = null;
        /// <summary>
        /// 患者基本信息集合
        /// </summary>
        public ArrayList AlPatientInfo
        {
            set
            {
                this.alPatientInfo = value;
                SetDetail();
            }
            get
            {
                return this.alPatientInfo;
            }
        }

        protected virtual void SetDetail()
        {
            if (this.AlPatientInfo == null || this.AlPatientInfo.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this.AlPatientInfo.Count; i++)
            {
                Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                //System.Drawing.Graphics g = this.neuPanel1.CreateGraphics();
                patientInfo = (Neusoft.HISFC.Models.RADT.PatientInfo)this.AlPatientInfo[i];
                {
                    ucFeeAlertQueryPrintPanelDetail ucprint = new ucFeeAlertQueryPrintPanelDetail();
                    ucprint.PatientInfo = patientInfo;
                    ucprint.Size = new Size(ucprint.Size.Width + 50, ucprint.Size.Height);
                    ucprint.Location = new Point( 0,ucprint.Height*i+i*10);
                    ucprint.BorderStyle = BorderStyle.None;
                    //Point p,p1;
                    //p = new Point(0, neuPanel1.Height - 10);
                    //p1=new Point(neuPanel1.Width,ucprint.Height-10);
                    ////g.DrawLine(new Pen(Brushes.Black, 1), p, p1);

                   // ucprint.Dock = DockStyle.Bottom;
                    this.neuPanel1.Controls.Add(ucprint);
                    
                }
            }

        }



        public void Print()
        {

            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.IsHaveGrid = false;
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;

            print.PrintPage(0,0,this.neuPanel1);
    
        }
        public void PrintView()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPreview(this.neuPanel1);
        }
    }

}

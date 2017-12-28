using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace Neusoft.WinForms.Report.Order
{
    /// <summary>
    /// [功能描述: 住院住院瓶贴默认实现]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2010-01]<br></br>
    /// </summary>
    public partial class ucInfusionLabelNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {
        public ucInfusionLabelNew()
        {
            InitializeComponent();
        }

        #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印

        private ArrayList alInfusionData = new ArrayList();

        public delegate void ComboSelect(string combo, int pageNO);

        public event ComboSelect comboSelectEvent;

        /// <summary>
        /// 组合号
        /// </summary>
        public string ComboNO
        {
            get
            {
                return this.lbCombo.Text.Trim();
            }
        }

        /// <summary>
        /// 组合内页码
        /// </summary>
        private int pageNO = 0;

        /// <summary>
        /// 组合内页码
        /// </summary>
        public int PageNO
        {
            get
            {
                return this.pageNO;
            }
        }

        #endregion

        /// <summary>
        /// 患者信息显示
        /// </summary>
        private System.Collections.Hashtable hsPatientInfo = new Hashtable();

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 
        /// </summary>
        protected int vnum = 0;

        /// <summary>
        /// 
        /// </summary>
        protected int hnum = 0;

        #region IControlPrintable 成员

        public int BeginHorizontalBlankWidth
        {
            get
            {
                return 2;
            }
            set
            {

            }
        }

        public int BeginVerticalBlankHeight
        {
            get
            {
                return 2;
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
            get
            {
                //return new Size( 262, 221 );addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                //return new Size(195, 123);
                return new Size(226, 305);
            }
        }

        public object ControlValue
        {
            get
            {
                return alInfusionData;//addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
            }
            set
            {
                //ArrayList alInfusionData = value as ArrayList;addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                alInfusionData = value as ArrayList;
                if (alInfusionData == null)
                {
                    return;
                }

                Neusoft.HISFC.Models.RADT.PatientInfo patientnifo = new Neusoft.HISFC.Models.RADT.PatientInfo();
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManagemnt = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                bool isHavePccExecBill = controlManagemnt.GetControlParam<bool>("200211", false, false);
                //Neusoft.HISFC.PC.MNS.Implement.OrderExcBill ppcExecBillMgr = null;
                //if (isHavePccExecBill)
                //{
                //    ppcExecBillMgr = new Neusoft.HISFC.PC.MNS.Implement.OrderExcBill();
                //}

                #region 标签信息

                int iIndex = 1;

                foreach (Neusoft.HISFC.Models.Order.ExecOrder info in alInfusionData)
                {
                    #region 设置患者信息

                    if (this.hsPatientInfo.ContainsKey(info.Order.Patient.ID))
                    {
                        patientnifo = this.hsPatientInfo[info.Order.Patient.ID] as Neusoft.HISFC.Models.RADT.PatientInfo;
                    }
                    else
                    {
                        patientnifo = radtIntegrate.QueryPatientInfoByInpatientNO(info.Order.Patient.ID);
                    }

                    if (patientnifo != null)
                    {
                        this.lbDept.Text = patientnifo.PVisit.PatientLocation.Dept.Name;

                        if (patientnifo.PVisit.PatientLocation.Bed.ID.Length <= 4)
                        {
                            this.lbBed.Text = patientnifo.PVisit.PatientLocation.Bed.ID;
                        }
                        else
                        {
                            this.lbBed.Text = patientnifo.PVisit.PatientLocation.Bed.ID.Substring(4, patientnifo.PVisit.PatientLocation.Bed.ID.Length - 4);//床号
                        }

                        this.lbName.Text = patientnifo.Name;
                    }

                    #endregion

                    #region 设置用药信息

                    this.lbDate.Text = info.DateUse.ToString("yy.MM.dd HH");     //用药时间

                    this.lbUsage.Text = info.Order.Usage.Name;

                    this.lbCombo.Text = "(" + info.Order.Combo.ID + ")";

                    if (iIndex == 0)
                    {
                        //this.lbLabelTotNum.Text = info.Operation.User01;
                        //if (info.Operation.User03 == "-1")
                        //{
                        //    this.lbiCount.Text = info.Operation.User02;
                        //}
                        //else
                        //{
                        //    this.lbiCount.Text = info.Operation.User02 + "(" + info.Operation.User03 + ")";
                        //}
                    }

                    #endregion

                    #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                    if (iIndex == 1)
                    {
                        this.fpSpread1_Sheet1.Cells[0, 0].Text = this.lbBed.Text + " " + this.lbName.Text 
                            + " " + patientnifo.PID.PatientNO + " " + this.lbCombo.Text;
                        if (isHavePccExecBill)
                        {
                            #region addby xuewj 2010-10-23 PDA {D81BC4C8-FDD1-42ab-93A0-56049C99DF9D}
                            BarcodeLib.Barcode barCode = new BarcodeLib.Barcode();
                            barCode.IncludeLabel = true;
                            this.neuPictureBox1.Image = barCode.Encode(BarcodeLib.TYPE.CODE128, info.Order.Combo.ID + info.DateUse.ToString("yyMMddHH"), Color.Black, Color.White, barCode.Width, barCode.Height); 
                            #endregion
                        }                        
                    }
                    #endregion

                    #region 药品信息
                    #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
                    if (info.User01 != "")
                    {
                        this.pageNO = Neusoft.FrameWork.Function.NConvert.ToInt32(info.User01);
                    }
                    this.fpSpread1_Sheet1.Cells[iIndex, 0].Text = ((this.pageNO - 1) * 8 + iIndex).ToString() + "." + info.Order.Item.Name;         //药品名称
                    #endregion
                    //用量 因为存在合并列 列索引+1
                    this.fpSpread1_Sheet1.Cells[iIndex, 2].Text = info.Order.DoseOnce.ToString() + "." + info.Order.DoseUnit.ToString();

                    #region {DCF0FEE2-BBC8-407f-8828-E420932DA83E}更改瓶贴显示，将频次更改为每次用量 by guanyx
                    //this.fpSpread1_Sheet1.Cells[iIndex, 3].Text = info.Order.Frequency.ID;
                    this.fpSpread1_Sheet1.Cells[iIndex, 3].Text = info.Order.DoseOnce.ToString() + info.Order.DoseUnit.ToString();
                    #endregion
                    #endregion

                    iIndex++;
                }

                #endregion
            }
        }

        public int HorizontalBlankWidth
        {
            get
            {
                return 2;
            }
            set
            {

            }
        }

        public int HorizontalNum
        {
            get
            {
                return this.hnum;
            }
            set
            {
                this.hnum = value;
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
                return 8;
            }
            set
            {

            }
        }

        public int VerticalNum
        {
            set
            {
                this.vnum = value;
            }
            get
            {
                return this.vnum;
            }
        }

        #endregion

        /// <summary>
        /// 是否选择
        /// </summary>
        protected bool bSelected = false;

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.bSelected;
            }
            set
            {
                this.bSelected = value;
                if (value)
                {
                    this.BackColor = Color.FromArgb(224, 224, 224);
                }
                else
                {
                    this.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            this.IsSelected = !this.IsSelected;

            base.OnClick(e);
        }

        #region addby xuewj 2010-9-28 {4628BA40-7AB2-4396-80E8-9BB361B36496} 瓶贴打印
        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ChangeStatus();
            this.comboSelectEvent(this.lbCombo.Text.Trim(), this.pageNO);
        }

        /// <summary>
        /// 切换选中状态
        /// </summary>
        public void ChangeStatus()
        {
            this.IsSelected = !this.IsSelected;
            if (this.IsSelected)
            {
                this.fpSpread1_Sheet1.Cells[0, 0].BackColor = Color.DarkBlue;
            }
            else
            {
                this.fpSpread1_Sheet1.Cells[0, 0].BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        /// <summary>
        /// 重置背景色
        /// </summary>
        public void ResetBackColor()
        {
            this.fpSpread1_Sheet1.Cells[0, 0].BackColor = Color.FromArgb(255, 255, 255);
            this.fpSpread1.BackColor = Color.FromArgb(255, 255, 255);
            this.BackColor = Color.FromArgb(255, 255, 255);
            this.bSelected = false;
        }
        #endregion

    }
}

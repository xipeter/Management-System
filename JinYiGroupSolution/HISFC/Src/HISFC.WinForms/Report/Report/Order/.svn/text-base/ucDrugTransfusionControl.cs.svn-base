using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.WinForms.Report.Order
{
    /// <summary>
    /// [功能描述: 输液卡小控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDrugTransfusionControl : UserControl,Neusoft.FrameWork.WinForms.Classes.IControlPrintable
    {
        public ucDrugTransfusionControl()
        {
            InitializeComponent();
        }



        #region IControlPrintable 成员

        public bool IsCanExtend
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.IsCanExtend getter 实现
                return false;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.IsCanExtend setter 实现
            }
        }

        public int BeginVerticalBlankHeight
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.BeginVerticalBlankHeight getter 实现
                return 1;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.BeginVerticalBlankHeight setter 实现
            }
        }

        public int VerticalBlankHeight
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.VerticalBlankHeight getter 实现
                return 1;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.VerticalBlankHeight setter 实现
            }
        }

        public int HorizontalBlankWidth
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.HorizontalBlankWidth getter 实现
                return 0;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.HorizontalBlankWidth setter 实现
            }
        }

     

        protected int vnum = 0;
        protected int hnum = 0;
        public int HorizontalNum
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.HorizontalNum getter 实现
                return this.hnum;
            }
            set
            {
                this.hnum = value;
            }
        }

        public Size ControlSize
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.ControlSize getter 实现
                return new Size(331, 220);
            }
        }

        public bool IsShowGrid
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.IsShowGrid getter 实现
                return false;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.IsShowGrid setter 实现
            }
        }

        /// <summary>
        /// 控件数值
        /// </summary>
        public object ControlValue
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.ControlValue getter 实现
                return null;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.ControlValue setter 实现
                ArrayList al = value as ArrayList;
                if (al == null) return;
                int intWidth = 0;
                intWidth = 130 / al.Count;
                if (intWidth > 20) intWidth = 20;

                #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}
                Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlManagemnt = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                bool isHavePccExecBill = controlManagemnt.GetControlParam<bool>("200211", false, false);
                Neusoft.HISFC.PC.MNS.Implement.OrderExcBill ppcExecBillMgr = null;
                if (isHavePccExecBill)
                {
                    ppcExecBillMgr = new Neusoft.HISFC.PC.MNS.Implement.OrderExcBill();
                }

                #endregion

                for (int i = 0; i < al.Count; i++)
                {
                    Neusoft.HISFC.Models.Order.ExecOrder order = al[i] as Neusoft.HISFC.Models.Order.ExecOrder;
                    if (order == null) return;
                    string hypoTest = "";
                    if (order.Order.HypoTest == 3)
                        hypoTest = "[+]";
                    if (order.Order.HypoTest == 4)
                        hypoTest = "[－]";

                    if (i == 0)
                    {
                        this.lblName.Text = order.Order.Patient.Name;
                        this.lblBed.Text = Neusoft.HISFC.Components.Order.Classes.Function.BedDisplay(order.Order.Patient.PVisit.PatientLocation.Bed.ID);
                        this.lblFrequency.Text = order.Order.Frequency.ID;
                        this.lblUsage.Text = order.Order.Usage.Name;
                        this.lblUseTime.Text = order.DateUse.Month + "." + order.DateUse.Day;// +" " + order.DateUse.ToShortTimeString();
          
                    }
                    if (i == 0)
                    {
                        this.lblItem.Text = order.Order.DoseOnce.ToString() + order.Order.DoseUnit + order.Order.Item.Name + hypoTest + "[" + order.Order.Item.Specs + "]";

                        this.lblPage.Text = order.User01 + "/" + order.User02;//设置页码
                        if (Neusoft.FrameWork.Function.NConvert.ToInt32(order.User01) > 1)//非第一页没有主药
                            this.lblItem.Font = new Font(this.lblItem.Font.FontFamily, this.lblItem.Font.Size, System.Drawing.FontStyle.Regular);
                    }
                    else
                    {
                        Label lb = new Label();
                        lb.Location = new Point(0, this.lblItem.Top + this.lblItem.Height + (i - 1) * intWidth);
                        lb.Size = new Size(224, 16);
                        lb.Font = new Font(this.lblItem.Font.FontFamily, this.lblItem.Font.Size, System.Drawing.FontStyle.Regular);
                        lb.Text = order.Order.DoseOnce.ToString() + order.Order.DoseUnit + order.Order.Item.Name + hypoTest + "[" + order.Order.Item.Specs + "]";
                        lb.Visible = true;
                        this.Controls.Add(lb);
                    }

                    #region {47D5BD74-2263-4275-9CF8-18DD973E31E7}
                    if (isHavePccExecBill)
                    {
                        string barcode = ppcExecBillMgr.GetBarCodeByExecSqn(order.ID);
                        if (string.IsNullOrEmpty(barcode))
                        {
                            barcode = order.Order.Combo.ID + order.DateUse.ToString("yyMMddHHmm");
                        }

                        Common.Code39 code39 = new Neusoft.WinForms.Report.Common.Code39();
                        code39.ShowCodeString = true;
                        Bitmap bitmap = code39.GenerateBarcode(barcode);
                        PicBoxBarCode.Image = bitmap as Image;
                    }
                    #endregion
                }

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
                // TODO:  添加 ucDrugCardInfo.VerticalNum getter 实现
                return this.vnum;
            }
        }

        public int BeginHorizontalBlankWidth
        {
            get
            {
                // TODO:  添加 ucDrugCardInfo.BeginHorizontalBlankWidth getter 实现
                return 1;
            }
            set
            {
                // TODO:  添加 ucDrugCardInfo.BeginHorizontalBlankWidth setter 实现
            }
        }


        public ArrayList Components
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        #endregion
    }
}

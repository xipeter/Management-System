using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Models.Registration;
using System.Collections;

namespace LCRecipePrint.OutpatientFee
{
    public partial class ucRegBillPrintLC : UserControl, Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint
    {
        public ucRegBillPrintLC()
        {
            InitializeComponent();
        }

        private Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction();

        /// <summary>
        /// 打印用的标签集合
        /// </summary>
        public Collection<Label> lblPrint;
        /// <summary>
        /// 预览用的标签集合
        /// </summary>
        public Collection<Label> lblPreview;

        /// <summary>
        /// 设置打印值
        /// </summary>
        /// <param name="register">挂号实体</param>
        /// <returns></returns>
        public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register register)
        {
            try
            {
                this.InitReceipt();
                //门诊号
                this.lblCardNo.Text = register.PID.CardNO;
                //挂号科室
                this.lblDeptName.Text = register.DoctorInfo.Templet.Dept.Name;
                this.lblDeptName0.Text = register.DoctorInfo.Templet.Dept.Name;
                //号别
                this.lblRegLevel.Text = register.DoctorInfo.Templet.RegLevel.Name;
                this.lblRegLevel0.Text = register.DoctorInfo.Templet.RegLevel.Name;
                //姓名
                this.lblPatientName.Text = register.Name;
                this.lblPatientName0.Text = register.Name;
                this.lblPatientName1.Text = register.Name;
                //挂号员号
                this.lblRegOper.Text = register.InputOper.ID;
                this.lblRegOper0.Text = register.InputOper.ID;
                this.lblRegOper1.Text = register.InputOper.ID;
                this.lblRegOper2.Text = register.InputOper.ID;
                //小记                
                this.lblCostsum.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.PubCost + register.PayCost + register.OwnCost, 2) +
                    "元";
                this.lblCostsum0.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.PubCost + register.PayCost + register.OwnCost, 2) +
                    "元"; 
                //大写
                this.lblUpperCostSum.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(
                   register.PubCost + register.PayCost + register.OwnCost
                    );
                //挂号日期
                this.lblRegDate.Text = register.DoctorInfo.SeeDate.ToShortDateString();
                this.lblRegDate0.Text = register.DoctorInfo.SeeDate.ToShortDateString();
                this.lblRegDate1.Text = register.DoctorInfo.SeeDate.ToShortDateString();
                //医疗类别
                this.lblPactName.Text = register.Pact.Name;
                //挂号费
                this.lblRegFee.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.RegFee, 2) +
                    "元";
                this.lblRegFee0.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.RegFee, 2) +
                    "元";
                this.lblRegFee1.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.RegFee, 2) +
                    "元";
                //诊察费
                this.lblChkFee.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                    "元";
                this.lblChkFee0.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                    "元";
                //病历手册 暂无　留空
                this.lblCaseBookCost.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    0m, 2) +
                    "元";
                this.lblCaseBookCost0.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    0m, 2) +
                    "元";
                //发票号
                this.lblFlowNo.Text = register.InvoiceNO;
                //控制根据打印和预览显示选项
                if (IsPreview)
                {
                    SetToPreviewMode();
                }
                else
                {
                    SetToPrintMode();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }
        private bool _isPreview = false;

        private bool IsPreview
        {
            get { return _isPreview; }
            set { _isPreview = value; }
        }

        public int Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            Neusoft.HISFC.BizLogic.Manager.PageSize pageManager = new Neusoft.HISFC.BizLogic.Manager.PageSize();
            print.SetPageSize(pageManager.GetPageSize("MZGH"));
            print.PrintPage(0, 0, this);
            return 0;
        }
        public int Clear()
        {
            return 0;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            //this.trans.Trans = trans;
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                //return this.trans.Trans;
                return Neusoft.FrameWork.Management.PublicTrans.Trans;
            }
            set
            {
                //this.trans.Trans = value;
            }
        }
        public int PrintView()
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPreview(0, 0, this);
            return 0;
        }
        #region 报表打印用函数
        /// <summary>
        /// 设置为打印模式
        /// </summary>
        public void SetToPrintMode()
        {
            //将预览项设为不可见
            SetLableVisible(false, lblPreview);
            foreach (Label lbl in lblPrint)
            {
                lbl.BorderStyle = BorderStyle.None;
                lbl.BackColor = SystemColors.ControlLightLight;
            }
        }
        /// <summary>
        /// 设置为预览模式
        /// </summary>
        public void SetToPreviewMode()
        {
            //将预览项设为可见
            SetLableVisible(true, lblPreview);
            foreach (Label lbl in lblPrint)
            {
                lbl.BorderStyle = BorderStyle.None;
                lbl.BackColor = SystemColors.ControlLightLight;
            }
        }

        /// <summary>
        /// 初始化收据
        /// </summary>
        /// <remarks>
        /// 把打印项和预览项根据ｔａｇ标签的值区分开
        /// </remarks>
        private void InitReceipt(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType().FullName == "System.Windows.Forms.Label"||
                    c.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuLabel")
                {
                    Label l = (Label)c;
                    if (l.Tag != null)
                    {
                        if (l.Tag.ToString() == "print")
                        {
                            if (!string.IsNullOrEmpty(l.Text) || l.Text == "印")
                            {
                                l.Text = "";
                            }
                            lblPrint.Add(l);
                        }
                        else
                        {
                            lblPreview.Add(l);
                        }
                    }
                    else
                    {
                        lblPreview.Add(l);
                    }
                }
            }
        }


        /// <summary>
        /// 初始化收据
        /// </summary>
        /// <remarks>
        /// 把打印项和预览项根据ｔａｇ标签的值区分开
        /// </remarks>
        private void InitReceipt()
        {
            lblPreview = new Collection<Label>();
            lblPrint = new Collection<Label>();
            foreach (Control c in this.Controls)
            {
                if (c.GetType().FullName == "System.Windows.Forms.Label" ||
                    c.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuLabel")
                {
                    Label l = (Label)c;
                    if (l.Tag != null)
                    {
                        if (l.Tag.ToString() == "print")
                        {
                            #region 将代印字的打印项值清空
                            if (!string.IsNullOrEmpty(l.Text) && l.Text == "印")
                            {
                                l.Text = "";
                            }
                            #endregion
                            lblPrint.Add(l);
                        }
                        else
                        {
                            lblPreview.Add(l);
                        }
                    }
                    else
                    {
                        lblPreview.Add(l);
                    }
                }
            }
        }
        /// <summary>
        /// 设置标签集合的可见性
        /// </summary>
        /// <param name="v">是否可见</param>
        /// <param name="l">标签集合</param>
        private void SetLableVisible(bool v, Collection<Label> l)
        {
            foreach (Label lbl in l)
            {
                lbl.Visible = v;
            }
        }


        /// <summary>
        /// 设置打印集合的值
        /// </summary>
        /// <param name="t">值数组</param>
        /// <param name="l">标签集合</param>
        private void SetLableText(string[] t, Collection<Label> l)
        {
            foreach (Label lbl in l)
            {
                lbl.Text = "";
            }
            if (t != null)
            {
                if (t.Length <= l.Count)
                {
                    int i = 0;
                    foreach (string s in t)
                    {
                        l[i].Text = s;
                        i++;
                    }
                }
                else
                {
                    if (t.Length > l.Count)
                    {
                        int i = 0;
                        foreach (Label lbl in l)
                        {
                            lbl.Text = t[i];
                            i++;
                        }
                    }
                }
            }
        }
        #endregion
    }
}

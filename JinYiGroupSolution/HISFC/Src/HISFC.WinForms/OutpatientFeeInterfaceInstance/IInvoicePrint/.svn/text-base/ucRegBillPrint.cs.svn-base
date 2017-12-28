using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Object.Registration;
using System.Collections;

namespace ReceiptPrint
{
    public partial class ucRegBillPrint : UserControl, Neusoft.HISFC.Integrate.Registration.IRegPrint
    {
        public ucRegBillPrint()
        {
            InitializeComponent();
        }

        private Neusoft.NFC.Management.Transaction trans = new Neusoft.NFC.Management.Transaction();
        /// <summary>
        /// 设置打印值
        /// </summary>
        /// <param name="register">挂号实体</param>
        /// <returns></returns>
        public int SetPrintValue(Neusoft.HISFC.Object.Registration.Register register)
        {
            try
            {
                this.InitReceipt();
                //门诊号
                this.lblCardNo.Text = register.PID.CardNO;
                //挂号科室
                this.lblDeptName.Text = register.DoctorInfo.Templet.Dept.Name;
                //号别
                this.lblRegLevel.Text = register.DoctorInfo.Templet.RegLevel.Name;
                //挂号发票号
                this.lblInvoiceno.Text = register.InvoiceNO;
                //姓名
                this.lblPatientName.Text = register.Name;
                //挂号员号
                this.lblRegOper.Text = register.InputOper.ID;
                //小记                
                this.lblCostsum.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    register.PubCost + register.PayCost + register.OwnCost, 2) +
                    "元";
                //大写
                this.lblUpperCostSum.Text = Neusoft.NFC.Public.String.LowerMoneyToUpper(
                   register.PubCost + register.PayCost + register.OwnCost
                    );
                //挂号日期
                this.lblRegDate.Text = register.DoctorInfo.SeeDate.ToShortDateString();
                string medicalTypeName = string.Empty;

                //this.lblPayCostTitle.Visible = false;
                //this.lblOwnCostTitle.Visible = false;
                //this.lblIndividualBalanceTitle.Visible = false;
                //register.Pact.ID = "2";
                if (register.Pact.ID == "2")
                {
                    //this.lblPayCostTitle.Visible = true;
                    //this.lblOwnCostTitle.Visible = true;
                    //this.lblIndividualBalanceTitle.Visible = true;

                    //this.lblPayCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    //register.SIMainInfo.PayCost, 2) +
                    //"元";

                    //this.lblOwnCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    //register.SIMainInfo.OwnCost, 2) +
                    //"元";

                    //this.lblIndividualBalance.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    //register.SIMainInfo.IndividualBalance, 2) +
                    //"元";                  
                    switch (register.SIMainInfo.MedicalType.ID)
                    {
                        case "11":
                            {
                                //
                                medicalTypeName = "(" + "普通门诊)";
                                break;
                            }
                        case "12":
                            {
                                //
                                medicalTypeName = "(" + "特殊门诊)";
                                break;
                            }
                        case "15":
                            {
                                //
                                medicalTypeName = "(" + "门诊慢性病)";
                                break;
                            }
                        case "16":
                            {
                                //
                                medicalTypeName = "(" + "门诊大病)";
                                break;
                            }
                        default:
                            {
                                //
                                medicalTypeName = "(" + "普通门诊)";
                                break;
                            }
                    } 
                }
                //医疗类别
                this.lblPactName.Text = register.Pact.Name + medicalTypeName;
               
                //挂号费
                this.lblRegFee.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.RegFee, 2) +
                    "元";
                //诊察费
                this.lblChkFee.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                    "元";
                //病历手册 
                //this.lblCaseBookCost.Text = Neusoft.NFC.Public.String.FormatNumberReturnString(
                //    register.RegLvlFee.OthFee, 2) +
                //    "元";
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
        private bool isPreview = false ;

        private bool IsPreview
        {
            get { return isPreview; }
            set { isPreview = value; }
        }

        public int Print()
        {
            try
            {
                Neusoft.NFC.Interface.Classes.Print print = null;
                try
                {
                    print = new Neusoft.NFC.Interface.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                Neusoft.HISFC.Object.Base.PageSize ps = new Neusoft.HISFC.Object.Base.PageSize("MZGH", 0, 0);               
                ////纸张宽度
                //ps.Width = this.Width;
                ////纸张高度
                //ps.Height = this.Height;
                ps.Printer = "MZGH";
                //上边距
                ps.Top = 0;
                //左边距
                ps.Left = 0;               
                print.SetPageSize(ps);               
                print.PrintPage(0, 0, this);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 1;
            }

            return 1;
        }
        public int Clear()
        {
            return 0;
        }

        public void SetTrans(System.Data.IDbTransaction trans)
        {
            this.trans.Trans = trans;
        }

        public System.Data.IDbTransaction Trans
        {
            get
            {
                return this.trans.Trans;
            }
            set
            {
                this.trans.Trans = value;
            }
        }
        public int PrintView()
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
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
        /// 打印用的标签集合
        /// </summary>
        public Collection<Label> lblPrint;
        /// <summary>
        /// 预览用的标签集合
        /// </summary>
        public Collection<Label> lblPreview;

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
                if (c.GetType().FullName == "System.Windows.Forms.Label" ||
                    c.GetType().FullName == "Neusoft.NFC.Interface.Controls.NeuLabel")
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
                    c.GetType().FullName == "Neusoft.NFC.Interface.Controls.NeuLabel")
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

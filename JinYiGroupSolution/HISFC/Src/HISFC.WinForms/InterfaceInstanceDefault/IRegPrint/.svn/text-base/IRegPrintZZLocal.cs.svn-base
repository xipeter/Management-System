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

namespace InterfaceInstanceDefault.IRegPrint
{
    /// <summary>
    /// 郑大门诊挂号收据
    /// donggq
    /// 20101125
    /// {C73BC54D-9206-48f5-B83F-2169E463DB4E}
    /// </summary>
    public partial class IRegPrintZZLocal : UserControl, Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint
    {
        public IRegPrintZZLocal()
        {
            InitializeComponent();
        }

        private Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction();

        private Neusoft.HISFC.BizProcess.Integrate.Manager manageIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 设置打印值
        /// </summary>
        /// <param name="register">挂号实体</param>
        /// <returns></returns>
        public int SetPrintValue(Neusoft.HISFC.Models.Registration.Register register)
        {
            /// <summary>
            /// 控制参数业务层--{C6BACB66-61EF-4d55-B93D-00E8C8F1C2CA}
            /// </summary>
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            bool RegCostStyle = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.Const.REG_COST_STYLE,false,false);



            this.lblHosptialName.Text = manageIntegrate.GetHospitalName();
            this.lblHosptialName1.Text = manageIntegrate.GetHospitalName();
            this.lblHosptialName2.Text = manageIntegrate.GetHospitalName();

            //MessageBox.Show("请记录门诊号："+register.PID.CardNO);
            try
            {
                this.InitReceipt();

                //挂号费---{C6BACB66-61EF-4d55-B93D-00E8C8F1C2CA}
                //if (RegCostStyle)//免费号
                //{
                //    this.lblRegFee.Text = "免费号";
                //}
                //else //收费号
                //{
                //    this.lblRegFee.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                //        register.RegLvlFee.RegFee, 2) +
                //        "元";
                //}

                //诊察费
                //挂号费---{C6BACB66-61EF-4d55-B93D-00E8C8F1C2CA}
                if (RegCostStyle)//免费号
                {
                    this.neuLabel5.Text = "免费号";
                    this.lblChkFee.Text = "免费号";
                    this.neuLabel28.Text = "免费号";
                }
                else //收费号
                {
                    this.neuLabel5.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                        register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                        "元";
                    this.lblChkFee.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                    register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                    "元";
                    this.neuLabel28.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                        register.RegLvlFee.ChkFee + register.RegLvlFee.PubDigFee + register.RegLvlFee.OwnDigFee, 2) +
                        "元";
                }

                
                //医生名称
                this.lblDocName.Text = register.DoctorInfo.Templet.Doct.Name;
                this.lblDocName1.Text = register.DoctorInfo.Templet.Doct.Name;
                this.lblDocName2.Text = register.DoctorInfo.Templet.Doct.Name;
                //挂号日期
                this.lblRegDate.Text = register.DoctorInfo.SeeDate.ToString();
                this.lblRegDate1.Text = register.DoctorInfo.SeeDate.ToString();
                this.lblRegDate2.Text = register.DoctorInfo.SeeDate.ToString();
                //挂号员号
                this.lblRegOper.Text = register.InputOper.ID;
                this.lblRegOper1.Text = register.InputOper.ID;
                this.lblRegOper2.Text = register.InputOper.ID;

                //流水号
                this.lblOrderNo.Text = register.OperSeq;//.OrderNO.ToString();
                this.lblOrderNo1.Text = register.OperSeq;
                this.lblOrderNo2.Text = register.OperSeq;

                //就诊号+午别
                this.lblSeeNo.Text = register.DoctorInfo.SeeNO.ToString() + "  " + register.DoctorInfo.Templet.Noon.Name;
                this.lblSeeNo1.Text = register.DoctorInfo.SeeNO.ToString() + "  " + register.DoctorInfo.Templet.Noon.Name;
                this.lblSeeNo2.Text = register.DoctorInfo.SeeNO.ToString() + "  " + register.DoctorInfo.Templet.Noon.Name;
                
                //发票号
                this.lblInvoiceno.Text = register.InvoiceNO;

                
                //挂号科室
                this.lblDeptName.Text = register.DoctorInfo.Templet.Dept.Name;
                
                //就诊科室地点
                Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
                this.lblDeptAddr.Text = deptMgr.GetDeptAddress(register.DoctorInfo.Templet.Dept.ID);
                
                //标志号
                this.lblCardNo.Text = register.PID.CardNO;
                this.lblCardNo1.Text = register.PID.CardNO;
                this.lblCardNo2.Text = register.PID.CardNO;

                ////号别
                //this.lblRegLevel.Text = register.DoctorInfo.Templet.RegLevel.Name;
                
                //姓名
                this.lblPatientName.Text = register.Name;
                this.lblPatientName1.Text = register.Name;
                this.lblPatientName2.Text = register.Name;
                
                ////小记                
                //this.lblCostsum.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                //    register.PubCost + register.PayCost + register.OwnCost, 2) +
                //    "元";
                ////大写
                //this.lblUpperCostSum.Text = Neusoft.FrameWork.Public.String.LowerMoneyToUpper(
                //   register.PubCost + register.PayCost + register.OwnCost
                //    );
                
                //string medicalTypeName = string.Empty;

                //this.lblPayCostTitle.Visible = false;
                //this.lblOwnCostTitle.Visible = false;
                //this.lblIndividualBalanceTitle.Visible = false;
                //register.Pact.ID = "2";
                
                //医疗类别
                ////this.lblPactName.Text = register.Pact.Name + medicalTypeName;

                
                //病历手册 
                ////this.lblOherFee.Text = Neusoft.FrameWork.Public.String.FormatNumberReturnString(
                ////    register.RegLvlFee.OthFee, 2) +
                ////    "元";

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
                Neusoft.FrameWork.WinForms.Classes.Print print = null;
                try
                {
                    print = new Neusoft.FrameWork.WinForms.Classes.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化打印机失败!" + ex.Message);

                    return -1;
                }

                Neusoft.HISFC.Models.Base.PageSize ps = new Neusoft.HISFC.Models.Base.PageSize("MZGHFP", 0, 0);
                ////纸张宽度
                //ps.Width = this.Width;
                ////纸张高度
                //ps.Height = this.Height;
                ps.Printer = "MZGHFP";
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

        private void neuLabel39_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

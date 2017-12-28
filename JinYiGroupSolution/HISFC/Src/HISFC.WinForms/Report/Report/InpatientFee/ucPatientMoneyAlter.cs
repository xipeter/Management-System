using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.InpatientFee
{
    /// <summary>
    /// 病房管理里面的欠费报警的单据打印实现
    /// 此接口反射不是通过表数据读取的
    /// 是HISFC.Components里面代码写死的
    /// </summary>
    public partial class ucPatientMoneyAlter : UserControl,Neusoft.HISFC.BizProcess.Interface.FeeInterface.IMoneyAlert
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ucPatientMoneyAlter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前患者信息
        /// </summary>
        protected Neusoft.HISFC.Models.RADT.PatientInfo curPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        private Neusoft.HISFC.BizLogic.Manager.Constant constantMgr = new Neusoft.HISFC.BizLogic.Manager.Constant();

        #region IMoneyAlert 成员

        /// <summary>
        /// 患者信息
        /// </summary>
        public Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo
        {
            get
            {
                return curPatientInfo ;
            }
            set
            {
                this.curPatientInfo = value;
            }
        }

        /// <summary>
        /// 设置界面信息
        /// </summary>
        public void SetPatientInfo()
        {
            this.lbl姓名.Text = this.PatientInfo.Name;
            this.lbl床号.Text = this.PatientInfo.PVisit.PatientLocation.Bed.ID.Substring(4);
            this.lbl住院号.Text = this.PatientInfo.PID.PatientNO;
            this.lbl科室.Text = this.PatientInfo.PVisit.PatientLocation.Dept.Name;

            this.lbl预交金总额.Text = this.PatientInfo.FT.PrepayCost.ToString();
            decimal TotCost = this.PatientInfo.FT.TotCost + this.PatientInfo.FT.BalancedCost;
            this.lbl已花费总金额.Text = TotCost.ToString();
            
            this.nlb打印时间.Text = this.constantMgr.GetSysDate().ToString();

            if (this.PatientInfo.PVisit.AdmittingDoctor.User02 == "2")
            {
                if (string.IsNullOrEmpty(this.PatientInfo.PVisit.AdmittingDoctor.User01))
                {
                    this.lbl补交金额.Text = "__________";
                }
                else
                {
                    this.lbl补交金额.Text = this.PatientInfo.PVisit.AdmittingDoctor.User01;
                }
            }
            else if (this.PatientInfo.PVisit.AdmittingDoctor.User02 == "1")
            {
                ucInputPrepayNum uc = new ucInputPrepayNum();
                Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = this.PatientInfo.Name;
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                string inputValue = uc.InputValue;

                if (Neusoft.FrameWork.Function.NConvert.ToDecimal(inputValue) > 0)
                {
                    this.lbl补交金额.Text = inputValue;
                }
                else
                {
                    this.lbl补交金额.Text = "__________";
                }
            }
            else
            {
                this.lbl补交金额.Text = "__________";
            }
            
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            //Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
            //page.Height = 342;
            //page.Width = 342;
            //page.Name = "PhaInput";
            //p.SetPageSize(page);

            #region 郑大更新--{0E4B7A1C-6F83-44eb-90B3-A57637C27D3A}

            try
            {
                Neusoft.HISFC.Models.Base.PageSize page = new Neusoft.HISFC.Models.Base.PageSize();
                Neusoft.HISFC.BizLogic.Manager.PageSize psMgr = new Neusoft.HISFC.BizLogic.Manager.PageSize();
                page = psMgr.GetPageSize("165");
                p.SetPageSize(page);
            }
            catch 
            {
                MessageBox.Show("打印参数获取失败!");
                return ;
            }

            #endregion


            p.PrintPage(0, 0, this);
        }

        #endregion

    }
}

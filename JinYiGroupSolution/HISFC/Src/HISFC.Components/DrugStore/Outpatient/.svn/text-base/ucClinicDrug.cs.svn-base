using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 门诊配发药控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明>
    ///     1、使用本控件时 需先调用初始化Init方法
    ///                     设置OperDept OperInfo  属性
    ///     2、实现接口IOutpatientShow 可自定义患者显示方式  使用时需继承ucBaseControl 实现接口IOutpatientShow
    ///                     如果不实现 则采用默认方式显示
    /// </说明>
    /// <修改记录 
    ///	 直接发药 列表加载的树节点状态为 " 1 "	
    /// 
    ///  />
    /// </summary>
    public partial class ucClinicDrug : DrugStore.Outpatient.ucClinicBase,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucClinicDrug()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存前
        /// </summary>
        public new event System.EventHandler BeginSave;

        /// <summary>
        /// 保存后
        /// </summary>
        public new event System.EventHandler EndSave;

        /// <summary>
        /// 需显示的提示信息
        /// </summary>
        public event System.EventHandler MessageEvent;

        #region 帮助类

        /// <summary>
        /// 频次帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper frequencyHelper = null;

        /// <summary>
        /// 用法帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper usageHelper = null;

        /// <summary>
        /// 人员帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper personHelper = null;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 终端信息
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper terminalHelper = null;

        #endregion

        #region 域变量

        /// <summary>
        /// 对草药的显示 是否同时显示付数
        /// </summary>
        private bool isShowDays = false;

        /// <summary>
        /// 是否打印处方
        /// </summary>
        private bool isPrintRecipe = false;

        /// <summary>
        /// 是否打印发药清单
        /// </summary>
        private bool isPrintListing = false;

        /// <summary>
        /// 本次处理的处方调剂信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugRecipe tempDrugRecipe = null;

        /// <summary>
        /// 是否显示患者明细信息
        /// </summary>
        private bool isPatientDetail = false;

        /// <summary>
        /// 是否再配药确认时更新处方调剂信息
        /// </summary>
        private bool isAdjustInDrug = true;

        /// <summary>
        /// 库存报警时是否判断虚库存
        /// </summary>
        private bool judgeWarnPreStore = true;

        /// <summary>
        /// 库存报警时是否用库存下限判断
        /// </summary>
        private bool judgeWarnLowQty = true;

        /// <summary>
        /// 门诊配药时是否进行库存警戒判断
        /// </summary>
        private bool isJudgeWarDruged = false;

        /// <summary>
        /// 门诊发药时是否进行库存警戒判断
        /// </summary>
        private bool isJudgeWarnSend = false;

        #endregion

        #region 属性

        /// <summary>
        /// 对草药的显示 是否同时显示付数
        /// </summary>
        [Description("对草药的显示 是否同时显示付数"),Category("设置"),DefaultValue(false)]
        public bool IsShowDays
        {
            get
            {
                return this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDays].Visible;
            }
            set
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColDays].Visible = value;
                this.isShowDays = value;
            }
        }

        /// <summary>
        /// 发药后是否打印处方
        /// </summary>
        [Description("发药后是否打印处方"), Category("设置"), DefaultValue(false)]
        public bool IsPrintRecipe
        {
            get
            {
                return this.isPrintRecipe;
            }
            set
            {
                this.isPrintRecipe = value;
            }
        }

        /// <summary>
        /// 配药后是否打印发药清单
        /// </summary>
        [Description("配药后是否打印发药清单"), Category("设置"), DefaultValue(false)]
        public bool IsPrintListing
        {
            get
            {
                return this.isPrintListing;
            }
            set
            {
                this.isPrintListing = value;
            }
        }

        /// <summary>
        /// 是否显示患者明细信息
        /// </summary>
        [Description("是否显示患者明细信息"),Category("设置"),DefaultValue(false)]
        public bool IsPatientDetail
        {
            get
            {
                return this.isPatientDetail;
            }
            set
            {
                this.isPatientDetail = value;
            }
        }

        /// <summary>
        /// 患者基本信息
        /// </summary>
        [Description("是否显示患者基本信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowPatientBaseInfo
        {
            get
            {
                return this.lbBasePatientInfo.Visible;
            }
            set
            {
                this.lbBasePatientInfo.Visible = value;
            }
        }

        /// <summary>
        /// 患者本次看诊信息
        /// </summary>
        [Description("是否显示患者本次看诊信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowPatientFeeInfo
        {
            get
            {
                return this.lblPatientInfo.Visible;
            }
            set
            {
                this.lblPatientInfo.Visible = value;
            }
        }

        /// <summary>
        /// 患者本次摆药信息
        /// </summary>
        [Description("是否显示患者本次摆药信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowDrugSendInfo
        {
            get
            {
                return this.lbDrugSendInfo.Visible;
            }
            set
            {
                this.lbDrugSendInfo.Visible = value;

                if (value)
                {
                    this.splitContainer1.SplitterDistance = 90;
                }
                else
                {
                    this.splitContainer1.SplitterDistance = 60;
                }
            }
        }

        /// <summary>
        /// Fp边框设置
        /// </summary>
        [Description("Fp边框格式设置"), Category("设置"), DefaultValue(System.Windows.Forms.BorderStyle.None)]
        public System.Windows.Forms.BorderStyle FpBorder
        {
            get
            {
                return this.neuSpread1.BorderStyle;
            }
            set
            {
                this.neuSpread1.BorderStyle = value;
            }
        }

        /// <summary>
        /// Lb格式设置
        /// </summary>
        [Description("Lb背景色设置"), Category("设置")]
        public System.Drawing.Color LabelBackColor
        {
            get
            {
                return this.lbBasePatientInfo.BackColor;
            }
            set
            {
                this.lbBasePatientInfo.BackColor = value;
                this.lbDrugSendInfo.BackColor = value;
                this.lblPatientInfo.BackColor = value;
            }
        }

        /// <summary>
        /// 库存报警时是否判断虚库存
        /// </summary>
        [Description("库存报警时是否判断虚库存"), Category("设置"),DefaultValue(true)]
        public bool IsJudgeWarnPreStore
        {
            get
            {
                return this.judgeWarnPreStore;
            }
            set
            {
                this.judgeWarnPreStore = value;
            }
        }

        /// <summary>
        /// 库存报警时是否用库存下限判断
        /// </summary>
        [Description("库存报警时是否用库存下限判断"), Category("设置"), DefaultValue(true)]
        public bool IsJudgeWarLowQty
        {
            get
            {
                return this.judgeWarnLowQty;
            }
            set
            {
                this.judgeWarnLowQty = value;
            }            
        }


        /// <summary>
        /// 门诊配药时是否进行库存警戒判断
        /// </summary>
        [Description("门诊配药时是否进行库存警戒判断"), Category("设置"), DefaultValue(false)]
        public bool IsJudgeWarnDruged
        {
            get
            {
                return this.isJudgeWarDruged;
            }
            set
            {
                this.isJudgeWarDruged = value;
            }
        }

        /// <summary>
        /// 门诊发药时是否进行库存警戒判断
        /// </summary>
        [Description("门诊发药时是否进行库存警戒判断"), Category("设置"), DefaultValue(false)]
        public bool IsJudgeWarnSend
        {
            get
            {
                return this.isJudgeWarnSend;
            }
            set
            {
                this.isJudgeWarnSend = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void IntiControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.IsShowDays = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Show_Days, true, false);
            this.IsPrintListing = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Print_List, true, false);
            this.IsPrintRecipe = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Print_Recipe, true, false);

            this.IsJudgeWarnDruged = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Warn_Druged, true, false);
            this.IsJudgeWarnSend = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.OutDrug_Warn_Send, true, false);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在加载单据打印基础数据..."));
            Application.DoEvents();

            #region 获取常数信息 用于界面数据显示

            //获得所有频次信息 
            Neusoft.HISFC.BizLogic.Manager.Frequency frequencyManagement = new Neusoft.HISFC.BizLogic.Manager.Frequency();
            ArrayList alFrequency = frequencyManagement.GetAll("Root");
            this.frequencyHelper = new Neusoft.FrameWork.Public.ObjectHelper(alFrequency);
            //获取所用用法
            Neusoft.HISFC.BizLogic.Manager.Constant c = new Neusoft.HISFC.BizLogic.Manager.Constant();
            ArrayList alUsage = c.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);
            if (alUsage == null)
            {
                MessageBox.Show("获取用法列表出错!");
                return;
            }
            this.usageHelper = new Neusoft.FrameWork.Public.ObjectHelper(alUsage);

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //获取所有人员
            ArrayList alEmployee = managerIntegrate.QueryEmployeeAll();
            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(alEmployee);
            //获取所有科室
            ArrayList alDept = managerIntegrate.GetDepartment();
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            //获取所有门诊终端
            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();
            ArrayList alDruged = drugStoreManager.QueryDrugTerminalByDeptCode(this.OperDept.ID, "0");
            ArrayList alSend = drugStoreManager.QueryDrugTerminalByDeptCode(this.OperDept.ID, "1");
            alDruged.AddRange(alSend);
            this.terminalHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDruged);

            #endregion

            #region 获取控制参数信息 用于控制调剂参数更新方式

            Neusoft.FrameWork.Management.ExtendParam extManager = new Neusoft.FrameWork.Management.ExtendParam();
            try
            {
                Neusoft.HISFC.Models.Base.ExtendInfo deptExt = extManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT,"AdjustGist", this.OperDept.ID);
                if (deptExt == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取科室扩展属性内配药调剂参数失败！"));
                }

                if (deptExt.StringProperty == "1")		//发药
                    this.isAdjustInDrug = false;
                else
                    this.isAdjustInDrug = true;			//配药
            }
            catch { }

            #endregion

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            this.IntiControlParam();
        }

        /// <summary>
        /// 清除显示信息
        /// </summary>
        public virtual void Clear()
        {
            try
            {
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCost].Formula = "";
                    this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.SystemColors.WindowText;
                }
                this.neuSpread1_Sheet1.Rows.Count = 0;
            }
            catch { }
        }

        /// <summary>
        /// 申请信息显示
        /// </summary>
        /// <param name="drugRecipe">门诊处方调剂信息</param>
        /// <param name="state">门诊处方状态</param>
        public virtual void ShowData(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            if (drugRecipe == null)
                return;

            this.tempDrugRecipe = drugRecipe;

            this.ShowPatientInfo(drugRecipe);

            string state = "";
            switch (drugRecipe.RecipeState)
            {
                case "0":
                case "1":
                    state = "0";
                    break;
                case "2":
                    state = "1";
                    break;
                case "3":
                    state = "2";
                    break;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList al = itemManager.QueryApplyOutListForClinic(this.OperDept.ID, "M1", state, drugRecipe.RecipeNO);
            if (al == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("根据调剂信息获取申请明细信息发生错误") + itemManager.Err);
                return;
            }

            this.ShowData(al);
        }

        /// <summary>
        /// 根据传入的数组显示数据
        /// </summary>
        /// <param name="alApplyOut"></param>
        internal virtual void ShowData(ArrayList alApplyOut)
        {
            //清空数据显示
            this.Clear();

            this.neuSpread1_Sheet1.Rows.Count = alApplyOut.Count;
            Neusoft.HISFC.Models.Pharmacy.ApplyOut info;
            for (int i = 0; i < alApplyOut.Count; i++)
            {
                info = alApplyOut[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                
                if (info.Item.PackQty == 0)
                    info.Item.PackQty = 1;

                if (info.Days <= 0)
                    info.Days = 1;
                try
                {
                    
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value = true;
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColName].Text = info.Item.Name + "[" + info.Item.Specs + "]";
          
                    if (this.isShowDays)
                    {
                        int outMinQty;
                        int outPackQty = System.Math.DivRem((int)(info.Operation.ApplyQty), (int)info.Item.PackQty, out outMinQty);

                        if (outPackQty == 0)
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = (info.Operation.ApplyQty).ToString() + info.Item.MinUnit;
                        }
                        else if (outMinQty == 0)
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = outPackQty.ToString() + info.Item.PackUnit;
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = outPackQty.ToString() + info.Item.PackUnit + outMinQty.ToString() + info.Item.MinUnit;
                        }
                    }
                    else
                    {
                        int outMinQty;
                        int outPackQty = System.Math.DivRem((int)(info.Operation.ApplyQty * info.Days), (int)info.Item.PackQty, out outMinQty);

                        if (outPackQty == 0)
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = (info.Operation.ApplyQty * info.Days).ToString() + info.Item.MinUnit;
                        }
                        else if (outMinQty == 0)
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = outPackQty.ToString() + info.Item.PackUnit;
                        }
                        else                        
                        {
                            this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColNum].Text = outPackQty.ToString() + info.Item.PackUnit + outMinQty.ToString() + info.Item.MinUnit ;
                        }
                    }
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDays].Text = info.Days.ToString();                    

                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColUseNum].Text = info.DoseOnce.ToString() + info.Item.DoseUnit;
                    if (this.frequencyHelper != null)
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColFrequency].Text = this.frequencyHelper.GetName(info.Frequency.ID);
                    }
                    if (this.usageHelper != null)
                    {
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColUse].Text = this.usageHelper.GetName(info.Usage.ID);
                    }
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColPrice].Text = Math.Round(info.Item.Price / info.Item.PackQty, 4).ToString();
                    this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCost].Text = Math.Round(info.Operation.ApplyQty * info.Days / info.Item.PackQty * info.Item.PriceCollection.RetailPrice, 2).ToString();
                    this.neuSpread1_Sheet1.Rows[i].Tag = info;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (info.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    this.neuSpread1_Sheet1.Rows[i].ForeColor = System.Drawing.Color.Red;
                }
            }

            this.ComputeSum();
        }

        /// <summary>
        /// 患者信息显示
        /// </summary>
        protected virtual void ShowPatientInfo(Neusoft.HISFC.Models.Pharmacy.DrugRecipe drugRecipe)
        {
            try
            {
                if (this.IPatientShow != null)
                {
                    this.IPatientShow.ShowInfo(drugRecipe);
                    return;
                }

                //该处方的发票号，诊卡号，病人姓名（加粗放大），性别，年龄，收费员工号，医生姓名，收费时间
                string strBase = "";
                string strFee = "";

                #region 设置显示信息初始字符串

                string strDrugSend = "  配药时间：{0} 配药人：{1} 配药台：{2} 发药时间：{3} 发药人：{4} 发药台：{5}";

                if (this.isPatientDetail)
                {
                    strBase = " 发 票 号：{0}  门 诊 号：{1}  姓 名：{2}  性 别：{3}  年 龄：{4}  联系方式：{5}  家庭住址：{6}";
                    strFee = " 挂号日期：{0} 收费人：{1} 收费时间：{2} 看诊科室：{3} 医 生：{4} 诊断：{5}";
                }
                else
                {
                    strBase = " 发 票 号：{0}  门诊号：{1}  姓名：{2}  性别：{3}  年龄：{4}";
                    strFee = " 挂号日期：{0} 收费人：{1} 收费时间：{2} 看诊科室：{3} 医 生：{4}";
                }

                #endregion

                Neusoft.FrameWork.Management.DataBaseManger dataBase = new Neusoft.FrameWork.Management.DataBaseManger();
                string strAge = dataBase.GetAge(drugRecipe.Age);
                if (drugRecipe.RecipeNO != "" && drugRecipe.RecipeNO != null)
                {
                    drugRecipe.Doct.Name = this.personHelper.GetName(drugRecipe.Doct.ID);
                    drugRecipe.DoctDept.Name = this.deptHelper.GetName(drugRecipe.PatientDept.ID);

                    drugRecipe.DrugTerminal.Name = this.terminalHelper.GetName(drugRecipe.DrugTerminal.ID);
                    drugRecipe.SendTerminal.Name = this.terminalHelper.GetName(drugRecipe.SendTerminal.ID);

                    if (this.isPatientDetail)
                    {
                        #region 显示患者明细信息  涉及挂号/病案业务层的 暂时先不写

                        //neusoft.HISFC.Management.Registration.Register regMgr = new neusoft.HISFC.Management.Registration.Register();
                        //neusoft.HISFC.Object.Registration.Register register = regMgr.QueryByClinic(drugRecipe.ClinicCode);
                        //if (register != null)
                        //    this.lbBasePatientInfo.Text = string.Format(strBase, drugRecipe.InvoiceNo, drugRecipe.CardNo, drugRecipe.PatientName, drugRecipe.Sex.Name, strAge, register.Phone, register.Address);
                        //else
                        //    this.lbBasePatientInfo.Text = string.Format(strBase, drugRecipe.InvoiceNo, drugRecipe.CardNo, drugRecipe.PatientName, drugRecipe.Sex.Name, strAge);

                        //neusoft.HISFC.Management.Case.Diagnose diagnoseMgr = new neusoft.HISFC.Management.Case.Diagnose();
                        //ArrayList alDiagnose = diagnoseMgr.QueryCaseDiagnoseForClinic(drugRecipe.ClinicCode, neusoft.HISFC.Management.Case.frmTypes.DOC);
                        //string diagnose = "";
                        //if (alDiagnose != null && alDiagnose.Count > 0)
                        //{
                        //    neusoft.HISFC.Object.Case.Diagnose diagnoseObj = alDiagnose[0] as neusoft.HISFC.Object.Case.Diagnose;
                        //    diagnose = diagnoseObj.DiagInfo.ICD10.Name;
                        //}
                        //this.lblPatientInfo.Text = string.Format(strFee, drugRecipe.RegDate.ToString(), drugRecipe.FeeOper, drugRecipe.FeeDate.ToString(), drugRecipe.DoctDept.Name, drugRecipe.Doct.Name, diagnose);

                        #endregion
                    }
                    else
                    {
                        this.lbBasePatientInfo.Text = string.Format(strBase, drugRecipe.InvoiceNO, drugRecipe.CardNO, drugRecipe.PatientName, drugRecipe.Sex.Name, strAge);
                        this.lblPatientInfo.Text = string.Format(strFee, drugRecipe.RegTime.ToString(), this.personHelper.GetName(drugRecipe.FeeOper.ID), drugRecipe.FeeOper.OperTime.ToString(), drugRecipe.DoctDept.Name, drugRecipe.Doct.Name);
                    }

                    this.lbDrugSendInfo.Text = string.Format(strDrugSend, drugRecipe.DrugedOper.OperTime.ToString(), 
                        this.personHelper.GetName(drugRecipe.DrugedOper.ID), 
                        drugRecipe.DrugTerminal.Name, drugRecipe.SendOper.OperTime.ToString(), 
                        this.personHelper.GetName(drugRecipe.SendOper.ID), drugRecipe.SendTerminal.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 患者信息显示
        /// </summary>
        /// <param name="basePatientInfo">患者基本信息</param>
        /// <param name="feePatientInfo">患者本次看诊信息</param>
        /// <param name="drugSendInfo">患者摆/发药信息</param>
        public void ShowPatientInfo(string basePatientInfo, string feePatientInfo, string drugSendInfo)
        {
            this.lbBasePatientInfo.Text = basePatientInfo;
            this.lblPatientInfo.Text = feePatientInfo;
            this.lbDrugSendInfo.Text = drugSendInfo;
        }

        /// <summary>
        /// 计算合计金额
        /// </summary>
        private void ComputeSum()
        {
            try
            {
                int rowCount = this.neuSpread1_Sheet1.Rows.Count;
                if (rowCount <= 0)
                    return;
                this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColumnSet.ColName].Text = "合计:";
                decimal totCost = 0;
                Neusoft.HISFC.Models.Pharmacy.ApplyOut info;
                for (int i = 0; i < rowCount; i++)
                {
                    info = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    if (info.ValidState != Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                        continue;
                    totCost = totCost + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCost].Text);

                }
                this.neuSpread1_Sheet1.Cells[rowCount, (int)ColumnSet.ColCost].Text = totCost.ToString();
                //				this.neuSpread1_Sheet1.Cells[rowCount,(int)ColumnSet.ColCost].Formula = "SUM(" + (char)(65 + (int)ColumnSet.ColCost) + "1:" + (char)(65 + (int)ColumnSet.ColCost) + (rowCount).ToString() + ")";
            }
            catch
            { }
        }

        /// <summary>
        /// 获取当前选中的数据
        /// </summary>
        /// <returns></returns>
        internal List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> GetData()
        {
            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alSelectData = new List<Neusoft.HISFC.Models.Pharmacy.ApplyOut>();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count - 1; i++)
            {
                if ((bool)this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value)
                {
                    alSelectData.Add(this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                }
            }

            return alSelectData;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual int Save()
        {
            if (this.OperInfo == null || this.OperInfo.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请设置操作员"));
                return -1;
            }
            if (this.OperDept == null || this.OperDept.ID == "")
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请设置操作科室"));
                return -1;
            }

            if (this.BeginSave != null)
                this.BeginSave(null, System.EventArgs.Empty);

            List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alData = this.GetData();
            if (alData == null || alData.Count <= 0)
                return -1;

            int parm = 1;
            //根据不同功能组调用不同方法实现
            switch (this.funModle)
            {
                case OutpatientFun.Drug:
                    //配药 标签自动打印 更新状态不扣库
                    parm = Function.OutpatientDrug(alData, this.terminal, this.ApproveDept, this.OperInfo,this.isAdjustInDrug);
                    if (parm == 1)
                    {
                        if (this.isPrintListing && ListingPrint != null)            //打印发药清单
                        {
                            ListingPrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                            ListingPrint.Print();
                        }
                    }
                    break;
                case OutpatientFun.Send:                //保存扣库
                    //判断是否已进行过发药处理
                    if (alData != null && alData.Count > 0)
                    {
                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = alData[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                        if (applyOut.State == "2")                        
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该药品已发药 不需保存"));
                            return -1;
                        }
                    }
                    try
                    {
                        //{60453BF5-EFFA-4cd5-832F-D63FD1B91CD2} 核准科室赋值  根据西安项目反馈修改
                        foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alData)
                        {
                            applyOut.Operation.ApproveOper.Dept = this.ApproveDept;
                        }

                        parm = Function.OutpatientSend(alData, this.terminal, this.ApproveDept, this.OperInfo, false, !this.isAdjustInDrug);
                        if (parm == 1)
                        {
                            if (this.isPrintRecipe && RecipePrint != null)              //打印处方
                            {
                                RecipePrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                                RecipePrint.Print();

                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                    break;
                case OutpatientFun.DirectSend:          //直接保存 标签自动打印完成后 保存扣库  不需判断调剂参数 每次都更新
                    //判断是否已进行过发药处理
                    if (alData != null && alData.Count > 0)
                    {
                        Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = alData[0] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                        if (applyOut.State == "2")
                        {
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该药品已发药 不需保存"));
                            return -1;
                        }
                    }
                    //{60453BF5-EFFA-4cd5-832F-D63FD1B91CD2} 核准科室赋值  根据西安项目反馈修改
                    foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alData)
                    {
                        applyOut.Operation.ApproveOper.Dept = this.ApproveDept;
                    }

                    parm = Function.OutpatientSend(alData, this.terminal, this.ApproveDept, this.OperInfo, true, true);
                    if (parm == 1)
                    {
                        if (this.isPrintRecipe && RecipePrint != null)              //打印处方
                        {
                            RecipePrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                            RecipePrint.Print();
                        }
                    }
                    break;
                case OutpatientFun.Back:
                    parm = Function.OutpatientBack(alData, this.OperInfo);                    
                    break;
            }

            this.JudgeWarnStore();

            if (parm == 1)
                this.Clear();
            else
                return -1;

            if (this.EndSave != null)
                this.EndSave(null, System.EventArgs.Empty);
           
            return 1;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void Print()
        {
             List<Neusoft.HISFC.Models.Pharmacy.ApplyOut> alData = this.GetData();

            //根据不同功能组调用不同方法实现
             switch (this.funModle)
             {
                 case OutpatientFun.Drug:
                     if (this.isPrintListing && ListingPrint != null)            //打印发药清单
                     {
                         ListingPrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                         ListingPrint.Print();
                     }
                     break;
                 case OutpatientFun.Send:
                     if (this.isPrintRecipe && RecipePrint != null)              //打印处方
                     {
                         RecipePrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                         RecipePrint.Print();
                     }
                     break;
                 case OutpatientFun.DirectSend:
                     if (this.isPrintRecipe && RecipePrint != null)              //打印处方
                     {
                         RecipePrint.AddAllData(new ArrayList(alData.ToArray()), this.tempDrugRecipe);
                         RecipePrint.Print();
                     }
                     break;
             }
        }

        /// <summary>
        /// 库存警戒线判断
        /// </summary>
        /// <param name="drugCode"></param>
        public virtual void JudgeWarnStore()
        {
            if ((this.funModle == OutpatientFun.Drug && this.IsJudgeWarnDruged) || (this.funModle == OutpatientFun.Send && this.IsJudgeWarnSend))
            {
                Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count - 1; i++)
                {
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                    if (itemManager.JudgeIsWarnStore(this.ApproveDept.ID, applyOut.Item.ID, this.judgeWarnPreStore, this.judgeWarnLowQty))
                    {
                        if (this.MessageEvent != null)
                        {
                            this.MessageEvent(this.neuSpread1_Sheet1.Cells[i, 1].Text + " 已达到库存警戒线！！", System.EventArgs.Empty);
                        }
                    }
                }
            }
        }
        #endregion

        #region 患者信息显示接口

        /// <summary>
        /// 患者信息显示接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientShow IPatientShow = null;

        /// <summary>
        /// 患者信息显示接口处理
        /// </summary>
        public int SetShowInterface()
        {
            object[] o = new object[] { };

            try
            {
                this.IPatientShow = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject( this.GetType(), typeof( Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientShow ) ) as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientShow;
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                //使用默认患者信息显示方式
                this.IPatientShow = null;

                return -1;
            }

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //初始化改为由外部窗口调用
                //this.Init();

                this.SetShowInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 设置窗口功能
        /// </summary>
        public override void SetFunMode(DrugStore.OutpatientFun winFunMode)
        {
            this.funModle = winFunMode;
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] printType = new Type[1];
                printType[0] = typeof( Neusoft.HISFC.BizProcess.Interface.Pharmacy.IOutpatientShow );

                return printType;
            }
        }

        #endregion
    }
}

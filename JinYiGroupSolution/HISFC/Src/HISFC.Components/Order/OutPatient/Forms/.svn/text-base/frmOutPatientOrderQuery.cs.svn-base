using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Order.OutPatient.Forms
{
    /// <summary>
    /// 移植门诊医嘱窗口，只保留查询医嘱、结果查询、病历、诊断等功能  by guanyx
    /// </summary>
    public partial class frmOutPatientOrderQuery : Neusoft.FrameWork.WinForms.Forms.frmBaseForm,Neusoft.FrameWork.WinForms.Classes.IPreArrange,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public frmOutPatientOrderQuery()
        {
            InitializeComponent();
            this.iControlable = this.ucOutPatientOrder1 as Neusoft.FrameWork.WinForms.Forms.IControlable;
            this.CurrentControl = this.ucOutPatientOrder1;
            this.panelToolBar.Visible = false;
                        
        }


        /// <summary>
        /// 账户操作的业务层  {184209CF-569F-4355-896D-FB33FF6C506F} 
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();

        private HISFC.Components.Order.OutPatient.Classes.Function Function = new HISFC.Components.Order.OutPatient.Classes.Function();

        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private bool isAccountTerimal = false;

        /// <summary>
        /// 传染病上报类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.DCP.IDCP dcpInstance = null;

        private void frmOutPatientOrderQuery_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.tbFilter.DropDownItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);

            this.tbAddOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Y医嘱);
            this.tbAddOrder.Visible = false;
            this.tbComboOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H合并);
            this.tbComboOrder.Visible = false;
            this.tbCancelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消);
            this.tbCancelOrder.Visible = false;
            this.tbDelOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除);
            this.tbDelOrder.Visible = false;
            this.tbOperation.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z诊断);
            this.tbOperation.Visible = false;
            this.tbSaveOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存);
            this.tbSaveOrder.Visible = false;
            this.tbCheck.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.H换单);
            this.tbCheck.Visible = false;
            this.tb1Exit.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tbExitOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.T退出);
            this.tbExitOrder.Visible = false;
            this.tbGroup.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z组套);
            this.tbGroup.Visible = false;
            this.tbSeePatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.X下一个);
            this.tbRefreshPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新);
            this.tbQueryOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询);
            this.tbPatientTree.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.G顾客);
            this.tbChooseDrugDept.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室);
            this.tbChooseDrugDept.Visible = false;
            #region {777C56C9-D8D7-478c-A10F-EF9B37335A08}
            this.tbPrintOrder.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印);
            this.tbRegisterEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J接诊);
            this.tbOutEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C出院登记);
            this.tbInEmergencyPatient.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z转科);
            this.tbDiseaseReport.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.J健康档案);
            this.tbDiseaseReport.Visible = false;
            this.tbHerbal.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.M明细);
            this.tbHerbal.Visible = false;
            #endregion
            this.panelTree.Height = this.Height - 162;
            this.panelTree.Visible = false;

            this.tbCallNO.Visible = false;
            this.tbPassNO.Visible = false;
            this.tbSeePatient.Visible = false;
            this.tbFilter.Visible = false;

            this.toolStripSeparator6.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.toolStripSeparator5.Visible = false;

            this.ucOutPatientTree1.TreeDoubleClick += new HISFC.Components.Order.OutPatient.Controls.ucOutPatientTree.TreeDoubleClickHandler(ucOutPatientTree1_TreeDoubleClick);
            isAccountTerimal = controlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.SysConst.Use_Account_Process, true, false);
        }

        private void ucOutPatientTree1_TreeDoubleClick(object sender, HISFC.Components.Order.OutPatient.Controls.ClickEventArgs e)
        {
            #region {22571B58-A56B-4dc3-A32C-EC17D74423A2}

            try
            {
                if (this.ucOutPatientTree1.neuTreeView1.Visible)
                {
                    this.tree = this.ucOutPatientTree1.neuTreeView1;
                    TreeViewEventArgs mye = new TreeViewEventArgs(this.ucOutPatientTree1.neuTreeView1.SelectedNode);
                    this.tree_AfterSelect(e.Message, mye);
                    this.Tag = this.ucOutPatientTree1.neuTreeView1.SelectedNode.Tag;
                }
                if (this.ucOutPatientTree1.neuTreeView2.Visible)
                {
                    this.tree = this.ucOutPatientTree1.neuTreeView2;
                    TreeViewEventArgs mye = new TreeViewEventArgs(this.ucOutPatientTree1.neuTreeView2.SelectedNode);
                    this.tree_AfterSelect(e.Message, mye);
                    this.Tag = this.ucOutPatientTree1.neuTreeView2.SelectedNode.Tag;
                }

                if (this.Tag is Neusoft.HISFC.Models.Registration.Register)
                {
                    //判断账户流程的挂号收费情况
                    bool isAccount = false;
                    decimal vacancy = 0m;
                    Neusoft.HISFC.Models.Registration.Register r = (Neusoft.HISFC.Models.Registration.Register)Tag;

                    if (isAccountTerimal && r.IsAccount)
                    {

                        if (feeMgr.GetAccountVacancy(r.PID.CardNO, ref vacancy) <= 0)
                        {
                            MessageBox.Show(feeMgr.Err);
                            return;
                        }
                        isAccount = true;

                    }
                    if (isAccount && r.IsFee == false)
                    {
                        //{6FC43DF1-86E1-4720-BA3F-356C25C74F16}
                        #region 账户扣取挂号费

                        if (!feeMgr.CheckAccountPassWord(r))
                        {
                            this.ucOutPatientTree1.neuTreeView1.SelectedNode = null;
                            this.ucOutPatientTree1.PatientInfo = null;
                            return;
                        }

                        if (isAccount && !r.IsFee)
                        {
                            if (vacancy < r.OwnCost)
                            {
                                MessageBox.Show("账户金额不足，请交费！");
                                return;
                            }


                            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                            if (feeMgr.AccountPay(r, r.OwnCost, "挂号收费", (orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID, string.Empty) < 0)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("扣账户金额失败！" + feeMgr.Err);
                                return;
                            }
                            Neusoft.HISFC.BizProcess.Integrate.Registration.Registration registerManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
                            r.SeeDOCD = orderManager.Operator.ID;
                            r.SeeDPCD = (orderManager.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                            if (registerManager.UpdateAccountFeeState(r.ID,r.SeeDOCD ,r.SeeDPCD , orderManager.GetDateTimeFromSysDateTime()) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                MessageBox.Show("更新挂号表已收费状态出错");
                                return;
                            }
                            Neusoft.FrameWork.Management.PublicTrans.Commit();
                            r.IsFee = true;
                        }
                        #endregion
                    }
                }
            }
            catch { }
            finally { }
            #endregion
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Controls.Count > 0)
            {
                this.iQueryControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IQueryControlable;
                this.iControlable = this.tabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                this.CurrentControl = this.tabControl1.SelectedTab.Controls[0];
                if (this.CurrentControl.GetType() == typeof(HISFC.Components.Order.OutPatient.Controls.ucPatientCase))
                {
                    (this.CurrentControl as HISFC.Components.Order.OutPatient.Controls.ucPatientCase).Reg = ucOutPatientTree1.PatientInfo;
                    this.neuPanel1.Visible = false;
                }
                
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             if (e.ClickedItem == this.tbQueryOrder)//查询
            {
                this.ucOutPatientOrder1.Patient = this.ucOutPatientTree1.PatientInfo;
                this.ucOutPatientOrder1.Retrieve();
            }
             else if (e.ClickedItem == this.tbPrintOrder)//打印
             {
                 this.ucOutPatientOrder1.PrintOrder();
             }
             else if (e.ClickedItem == this.tbRefreshPatient)//刷新
             {
                 ucOutPatientTree1.RefreshTreeView();
                 ucOutPatientTree1.RefreshTreePatientDone();
             }
             else if (e.ClickedItem == this.tbPatientTree)//列表
             {
                 this.neuPanel1.Visible = !this.neuPanel1.Visible;
             }
             else if (e.ClickedItem == this.tb1Exit)//退出
             {
                 if (this.ucOutPatientOrder1.IsDesignMode) //是在开立状态
                 {
                     DialogResult result = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("医嘱目前处于开立模式，是否保存?"), "提示", MessageBoxButtons.YesNoCancel);
                     if (result == DialogResult.Yes)
                     {
                         if (this.ucOutPatientOrder1.Save() == 0)
                             this.Close();

                     }
                     else if (result == DialogResult.Cancel)
                     {
                         return;
                     }

                     else
                     {
                         this.Close();
                     }
                 }
                 else
                 {
                     this.Close();
                 }
             }
             else if (e.ClickedItem == this.tbLisResultPrint)//{9B06773D-9674-4b20-94B8-47A1B066EA0B},检查、检验结果查询，shangxw 2009-11-10
             {
                 Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();
                 patient = this.ucOutPatientTree1.PatientInfo;
                
                 if (patient == null || patient.PID.CardNO == "" || patient.PID.CardNO == null)
                 {
                     MessageBox.Show("请选择一个患者！");


                     return;
                 }

                 try
                 {


                     string s = "LisResult";

                     System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName(s);
                     if (proc.Length > 0)
                     {
                         for (int i = 0; i < proc.Length; i++)
                         {
                             proc[i].Kill();
                         }
                     }

                     System.Diagnostics.Process p = new System.Diagnostics.Process();

                     p.StartInfo.FileName = Application.StartupPath + @"\LisBin\LisResult.exe";    //需要启动的程序名       
                     #region 取配置参数
                     ArrayList defaultValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("lis");
                     if ((defaultValue == null) || (defaultValue.Count == 0))
                     {
                         p.StartInfo.Arguments = " '" + patient.PID.CardNO + "' " + "门诊" + "";// +" " + "'住院'";//启动参数      

                     }
                     else
                     {
                         p.StartInfo.Arguments = " '" + defaultValue[0].ToString() + "' " + "门诊" + "";// +" " + "'住院'";//启动参数      

                     }

                     #endregion
                     p.Start();//启动     
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
             else if (e.ClickedItem == this.tbPacsResultPrint)//{17CC6DF8-1883-4d3c-8D24-2E08C93F047F},Lis结果打印,shangxw 2009-11-10
             {
                 Neusoft.HISFC.Models.Registration.Register patient = new Neusoft.HISFC.Models.Registration.Register();
                 patient = this.ucOutPatientTree1.PatientInfo;
                
                 if (patient == null || patient.PID.CardNO == "" || patient.PID.CardNO == null)
                 {
                     MessageBox.Show("请选择一个患者！");


                     return;
                 }

                 try
                 {
                     string patientNo = patient.ID;
                     this.ucOutPatientOrder1.ShowPacsResultByPatient(patientNo);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }
             else if (e.ClickedItem == this.tbClinicCase)
             {
                 #region 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
                 ShowClinicCase();
                 #endregion
             }
        }

        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        private void ShowClinicCase()
        {
            StringBuilder strPatientInfo = new StringBuilder("");
            try
            {
                #region 拼串
                Neusoft.HISFC.Models.Registration.Register register = this.ucOutPatientTree1.PatientInfo;
                if (register == null || string.IsNullOrEmpty(register.ID))
                {
                    MessageBox.Show("患者基本信息为空！");
                    return;
                }
                /*
                Args[0]	操作员代码
                Args[1]	操作员名称
                Args[2]	操作员所在科室代码
                Args[3]	操作员所在科室名称
                */
                strPatientInfo.Append(orderManager.Operator.ID + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Name + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.ID + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.Name + "\r\n");
                /*
                 * Args[4]	PATIENT_ID	病人标识号	C	16	病人唯一标识号，可以由用户赋予具体的含义，如：病案号，门诊号等
                Args[5]	NAME	姓名	C	30	病人姓名
                Args[6]	NAME_PHONETIC	姓名拼音	C	16	病人姓名拼音，大写，字间用一个空格分隔，超长截断
                Args[7]	SEX	性别	C	8	男、女、未知，使用名称
                Args[8]	DATE_OF_BIRTH	出生日期	D	　	　
                Args[9]	BIRTH_PLACE	出生地	C	80	指定省市县，使用名称
                Args[10]	CITIZENSHIP	国籍	C	28	使用国家代码，使用名称
                Args[11]	NATION	民族	C	10	民族规范名称，使用名称
                Args[12]	ID_NO	身份证号	C	20	
                 */
                strPatientInfo.Append(register.ID + "\r\n");
                strPatientInfo.Append(register.Name + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetSex(register.Sex.ToString()) + "\r\n");
                strPatientInfo.Append(register.Birthday.ToString("yyyyMMdd") + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append("中国" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Nationality.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.IDCard) + "\r\n");
                /*
                Args[13]	IDENTITY	身份	C	16	由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用规范名称，由用户定义使用名称
                Args[14]	CHARGE_TYPE	费别	C	8	由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用规范名称，由用户定义，使用名称
                Args[15]	UNIT_IN_CONTRACT	合同单位	C	40	如果病人所在单位为本医院的合同单位或体系单位，则使用代码，否则为空。由身份登记子系统生成，门诊登记子系统在办理入院时更新。使用名称
                Args[16]	MAILING_ADDRESS	通信地址	C	80	指永久通信地址
                Args[17]	ZIP_CODE	邮政编码	C	6	对应通信地址的邮政编码
                Args[18]	PHONE_NUMBER_HOME	家庭电话号码	C	16	　2
                Args[19]	PHONE_NUMBER_BUSINESS	单位电话号码	C	16	　
                Args[20]	NEXT_OF_KIN	联系人姓名	C	30	病人的亲属姓名
                Args[21]	RELATIONSHIP	与联系人关系	C	16	夫妻、父子等，使用名称
                Args[22]	NEXT_OF_KIN_ADDR	联系人地址	C	80	　
                Args[23]	NEXT_OF_KIN_ZIP_CODE	联系人邮政编码	C	6	　
                Args[24]	NEXT_OF_KIN_PHONE	联系人电话号码	C	20	　
                Args[25]	LAST_VISIT_DATE	上次就诊日期	D	　	由挂号与预约子系统根据就诊记录填写
                Args[26]	VIP_INDICATOR	重要人物标志	N	1	1-VIP 0-非VIP
                Args[27]	CREATE_DATE	建卡日期	D	　	　
                Args[28]	OPERATOR	操作员	C	8	最后修改本记录的操作员姓名
                 */
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.PhoneHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.PhoneBusiness) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append((register.VipFlag == true ? "1" : "0") + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Name + "\r\n");
                /*
                Args[29]	PATIENT_ID	病人标识	C	16	非空
                Args[30]	VISIT_ID	病人本次门诊就诊次数	N	4	取该患者挂号次数
                Args[31]	DEPT_ADMISSION_TO	门诊就诊科室	C	8	按统计要求的科室代码，见2.6科室字典
                Args[32]	ADMISSION_DATE_TIME	门诊就诊日期及时间	D	　	　
                Args[33]	OCCUPATION	职业	C	40	使用名称
                Args[34]	MARITAL_STATUS	婚姻状况	C	4	已婚、未婚、离婚、丧偶，使用规范名称，
                Args[35]	IDENTITY	身份	C	16	使用名称
                Args[36]	ARMED_SERVICES	　	C	4	填空
                Args[37]	DUTY	　	C	4	填空
                Args[38]	UNIT_IN_CONTRACT	合同单位	C	40	病人所属的体系单位名称，用户定义，没有就添空
                Args[39]	CHARGE_TYPE	费别	C	20	使用规范名称
                Args[40]	WORKING_STATUS	在职标志	N	1	0-在职 1-离休 2-退休
                Args[41]	INSURANCE_TYPE	医保类别	C	16	如果此病人为医保病人，则记录反映本次门诊支付方案的医保类别
                Args[42]	INSURANCE_NO	医疗保险号	C	18	如果此病人为医保病人，则记录其保险号
                Args[43]	SERVICE_AGENCY	工作单位	C	80	　
                Args[44]	MAILING_ADDRESS	通信地址	C	80	　
                Args[45]	ZIP_CODE	邮政编码	C	10	　
                Args[46]	NEXT_OF_KIN	联系人姓名	C	30	病人的亲属姓名
                Args[47]	RELATIONSHIP	与联系人关系	C	16	夫妻、父子等，使用名称
                Args[48]	NEXT_OF_KIN_ADDR	联系人地址	C	80	　
                Args[49]	NEXT_OF_KIN_ZIPCODE	联系人邮政编码	C	6	　
                Args[50]	NEXT_OF_KIN_PHONE	联系人电话	C	20	　
                 * Args[51]	INP_NO	住院号
                 */
                strPatientInfo.Append(this.GetString(register.ID) + "\r\n");
                strPatientInfo.Append("1" + "\r\n");
                strPatientInfo.Append(((Neusoft.HISFC.Models.Base.Employee)orderManager.Operator).Dept.ID + "\r\n");
                strPatientInfo.Append(this.GetString(register.DoctorInfo.SeeDate.ToString("yyyy-MM-dd HH:mm:ss")) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append("0" + "\r\n");
                strPatientInfo.Append(this.GetString(register.Pact.Name) + "\r\n");
                strPatientInfo.Append(this.GetString(register.SSN) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressBusiness) + "\r\n");
                strPatientInfo.Append(this.GetString(register.AddressHome) + "\r\n");
                strPatientInfo.Append(this.GetString(register.HomeZip) + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");
                strPatientInfo.Append("" + "\r\n");

                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("获取患者基本信息失败！" + e.ToString());
                return;
            }

            try
            {
                #region 显示
                JHEMR.OutpatientEMREdit.Class1 jhEMR = new JHEMR.OutpatientEMREdit.Class1();
                jhEMR.MyDiagnose(strPatientInfo.ToString());
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("电子病历显示失败！" + e.ToString());
                return;
            }
        }


        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        private string GetSex(string sex)
        {
            switch (sex)
            {
                case "M":
                    return "男";
                    break;
                case "F":
                    return "女";
                    break;
                default:
                    return "未知";
                    break;
            }
        }

        /// <summary>
        /// 门诊电子病历 {54F5B3CC-25C6-4e93-B810-4721578DE378} wbo 2010-12-05
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        private string GetString(object sourceStr)
        {
            if (sourceStr == null)
            {
                return "";
            }
            else
            {
                return sourceStr.ToString();
            }
        }

        #region IPreArrange 成员   {B17077E6-7E65-45fb-BA25-F2883EB6BA27}

        public int PreArrange()
        {
            this.ucOutPatientTree1.InitControl();

            if (this.ucOutPatientTree1.RefreshTreeView() == -1)
            {
                return -1;
            }

            return 1;
        }

        #endregion

        #region IInterfaceContainer 成员    {E53A21A7-2B74-4b48-A9F4-9E05F8FA11A2}

        public Type[] InterfaceTypes
        {
            get
            {
                return new Type[] { typeof( Neusoft.HISFC.BizProcess.Interface.DCP.IDCP ) };
            }
        }

        #endregion
    }
}


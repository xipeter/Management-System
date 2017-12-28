using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Account;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.BizProcess.Interface.Account;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 就诊卡发放
    /// </summary>
    public partial class ucCardManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucCardManager()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        
        /// <summary>
        /// Acount业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();
        
        /// <summary>
        /// 卡实体
        /// </summary>
        private Neusoft.HISFC.Models.Account.AccountCard accountCard = null;

        /// <summary>
        /// 卡操作实体
        /// </summary>
        private Neusoft.HISFC.Models.Account.AccountCardRecord accountCardRecord = null;

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        
        /// <summary>
        /// 工具栏
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBar = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 卡类型帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper markTypeHelp = new Neusoft.FrameWork.Public.ObjectHelper();
        
        /// <summary>
        /// 在输入过程中是否动态查找患者信息
        /// </summary>
        private bool isSelectPatientByEnter = true;

        /// <summary>
        /// 数据是否只在本地处理，不往数据中心发送
        /// {BCE8D830-5FEA-4681-A08A-4BB48D172E20}
        /// </summary>
        private bool isLocalOperation = true;

       

        #endregion

        #region 属性

        #region 输入控制属性
        [Category("输入设置"), Description("姓名是否必须输入！")]
        public bool IsInputName
        {
            get
            {
                return this.ucRegPatientInfo1.IsInputName;
            }
            set
            {
                this.ucRegPatientInfo1.IsInputName = value;
            }
        }

        [Category("输入设置"), Description("性别是否必须输入！")]
        public bool IsInputSex
        {
            get
            {
                return this.ucRegPatientInfo1.IsInputSex;
            }
            set
            {
                this.ucRegPatientInfo1.IsInputSex = value;
            }
        }

        [Category("输入设置"), Description("合同单位是否必须输入！")]
        public bool IsInputPact
        {
            get
            {
                return this.ucRegPatientInfo1.IsInputPact;
            }
            set
            {
                this.ucRegPatientInfo1.IsInputPact = value;
            }
        }

        [Category("输入设置"), Description("医保证号是否必须输入！")]
        public bool IsInputSiNo
        {
            get 
            {
                return this.ucRegPatientInfo1.IsInputSiNo; 
            }
            set 
            {
                this.ucRegPatientInfo1.IsInputSiNo = value;
            }
        }

        [Category("输入设置"), Description("出生日期是否必须输入！")]
        public bool IsInputBirthDay
        {
            get 
            {
                return this.ucRegPatientInfo1.IsInputBirthDay; 
            }
            set
            {
                this.ucRegPatientInfo1.IsInputBirthDay = value;
            }
        }

        [Category("输入设置"), Description("证件类型是否必须输入！")]
        public bool IsInputIDEType
        {
            get 
            { 
                return this.ucRegPatientInfo1.IsInputIDEType; 
            }
            set
            {
                this.ucRegPatientInfo1.IsInputIDEType = value;
            }
        }

        [Category("输入设置"), Description("证件号是否必须输入！")]
        public bool IsInputIDENO
        {
            get 
            {
                return this.ucRegPatientInfo1.IsInputIDENO; 
            }
            set
            {
                this.ucRegPatientInfo1.IsInputIDENO = value;
            }
        }

        #endregion

        [Category("控件设置"), Description("是否按照必录项跳转输入焦点 True:是 False:否")]
        public bool IsMustInputTabIndex
        {
            get
            {
                return this.ucRegPatientInfo1.IsMustInputTabIndex;
            }
            set
            {
                this.ucRegPatientInfo1.IsMustInputTabIndex = value;
            }
        }

        [Category("控件设置"),Description("在输入过程中是否动态查找患者信息 True:是 False:否")]
        public bool IsSelectPatientByEnter
        {
            get 
            { 
                return isSelectPatientByEnter;
            }
            set 
            { 
                isSelectPatientByEnter = value; 
            }
        }

        /// <summary>
        /// 数据是否只在本地处理，不往数据中心发送
        /// {BCE8D830-5FEA-4681-A08A-4BB48D172E20}
        /// </summary>
        [Category("控件设置"), Description("数据是否只在本地处理，不往数据中心发送 True:是 False:否")]
        public bool IsLocalOperation
        {
            get
            {
                return isLocalOperation;
            }
            set
            {
                isLocalOperation = value;
            }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="consList">提示信息集合</param>
        private void DealConstantList(ArrayList consList)
        {
            if (consList == null || consList.Count <= 0)
            {
                return;
            }

            this.spInfo.RowCount = 0;
            this.spInfo.RowCount = (consList.Count / 3) + (consList.Count % 3 == 0 ? 0 : 1);

            int row = 0;
            int col = 0;

            foreach (Neusoft.FrameWork.Models.NeuObject obj in consList)
            {
                if (col >= 5)
                {
                    col = 0;
                    row++;
                }

                this.spInfo.SetValue(row, col, obj.ID);
                this.spInfo.SetValue(row, col + 1, obj.Name);

                col = col + 2;
            }
        }

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns>true:成功　false失败</returns>
        private bool Valid()
        {
            if (this.txtMarkNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入卡号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMarkNo.Focus();
                return false;
            }
            if (this.cmbMarkType.Tag == null || this.cmbMarkType.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("请输入卡号后回车确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMarkNo.Focus();
                this.txtMarkNo.SelectAll();
                return false;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(txtMarkNo.Text.Trim(), 20))
            {
                MessageBox.Show("就诊卡号过长，请重新输入就诊卡号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMarkNo.Focus();
                this.txtMarkNo.SelectAll();
                return false;
            }

            AccountCard card = this.accountManager.GetAccountCard(txtMarkNo.Text.Trim(), this.cmbMarkType.Tag.ToString());
            if (card != null)
            {
                MessageBox.Show("该卡已被其他患者使用，请换卡！", "错误");
                this.txtMarkNo.Focus();
                this.txtMarkNo.SelectAll();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作废正在使用的就诊卡
        /// </summary>
        /// <returns>1作废成功　0不进行作废操作　-1失败</returns>
        private int StopPatientCard()
        {
            string tempCardNO = this.ucRegPatientInfo1.CardNO;
            //当tempCardNO为空的时候是正常发卡操作，当不为空的时候是补发新卡
            //当正常发卡操作的时候回新建立CardNO形成新的患者信息
            //在补发的时候只更新患者信息
            if (string.IsNullOrEmpty(tempCardNO)) return 0;
            //查找患者正在使用的卡的集合
            List<AccountCard> list = accountManager.GetMarkList(tempCardNO, true);
            if (list.Count == 0) return 0;
            DialogResult digRreslut = MessageBox.Show("是否停用正在使用的就诊卡？", "提示", MessageBoxButtons.OKCancel);
            if (digRreslut == DialogResult.Cancel) return 0;   
            ucCancelMark uc = new ucCancelMark(list);
            uc.StopCardEvent+=new ucCancelMark.EventStopCard(uc_StopCardEvent);
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(uc);
            if (uc.FindForm().DialogResult == DialogResult.No) return 0;
            if (uc.FindForm().DialogResult == DialogResult.Cancel) return -1;
            return 1;
            
        }

        /// <summary>
        /// 停用就诊卡
        /// </summary>
        /// <param name="markList">卡集合</param>
        /// <returns></returns>
        private bool uc_StopCardEvent(List<AccountCard> markList)
        {
            int resultValue = 0;
            AccountCardRecord tempCardRecord = null;
            
            foreach (AccountCard tempAccountCard in markList)
            {
                //修改卡状态
                resultValue = accountManager.UpdateAccountCardState(tempAccountCard.MarkNO, tempAccountCard.MarkType, false);
                if (resultValue < 0)
                {
                    MessageBox.Show("作废患者就诊卡失败！" + accountManager.Err, "提示");
                    return false;
                }

                #region 形成卡操作记录
                tempCardRecord = new AccountCardRecord();
                tempCardRecord.CardNO = tempAccountCard.Patient.PID.CardNO;//门诊卡号
                tempCardRecord.MarkNO = tempAccountCard.MarkNO;//就诊卡号
                tempCardRecord.MarkType = tempAccountCard.MarkType; //卡类型
                tempCardRecord.OperateTypes.ID = (int)MarkOperateTypes.Cancel; //操作类型
                tempCardRecord.Oper.ID = accountManager.Operator.ID; //操作人
                #endregion
                //形成操作记录
                resultValue = accountManager.InsertAccountCardRecord(tempCardRecord);
                if (resultValue < 0)
                {
                    MessageBox.Show("插入卡操作记录失败！" + accountManager.Err);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        protected virtual void Save()
        {
            if (!this.Valid()) return;

            #region 设置事物
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.accountManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            #endregion

            #region  保存患者信息
            int resultValue = 0;
            if (this.ucRegPatientInfo1.CardNO == string.Empty)
            {
                this.ucRegPatientInfo1.McardNO = txtMarkNo.Text;
                resultValue = this.ucRegPatientInfo1.Save();
                if (resultValue <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return;
                }
            }
            #endregion

            #region 作废正在使用的就诊卡
            if (StopPatientCard() < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }
            #endregion

            #region 发卡

            #region 获取卡实体
            accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
            //accountCard.Patient.PID.CardNO = this.ucRegPatientInfo1.CardNO;
            accountCard.Patient = this.ucRegPatientInfo1.GetPatientInfomation();
            accountCard.MarkNO = this.txtMarkNo.Text.Trim();
            accountCard.MarkType = this.cmbMarkType.SelectedItem as FrameWork.Models.NeuObject;
            accountCard.IsValid = true;
            #endregion
            //处理发卡操作
            string error = string.Empty;
            resultValue = this.BulidCard(accountCard);
            if (resultValue == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(error, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            //打印标签
            PrintLable();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功！"), Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ClearData();
        }

        /// <summary>
        /// 打印标签
        /// </summary>
        private void PrintLable()
        {
            IPrintLable iPrintLable = Neusoft.FrameWork.WinForms.Classes.
              UtilInterface.CreateObject(this.GetType(), typeof(IPrintLable)) as IPrintLable;
            if (iPrintLable != null)
            {
                iPrintLable.PrintLable(accountCard);
            }
        }

        
        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearData()
        {
            this.ucRegPatientInfo1.Clear();
            this.txtMarkNo.Text = string.Empty;
            this.cmbMarkType.Text = string.Empty;
            this.cmbMarkType.Tag = string.Empty;
            this.ucRegPatientInfo1.Focus();
            accountCard = null;
            this.ckIsTreatment.Checked = false;
        }

        /// <summary>
        /// 建立新的病理卡号
        /// </summary>
        private int BulidCard(AccountCard tempAccountCard)
        {
            try
            {
                if (accountManager.InsertAccountCard(tempAccountCard) == -1)
                {
                    MessageBox.Show("保存卡记录失败！" + accountManager.Err, "错误");
                    return -1;
                }
                accountCardRecord = new Neusoft.HISFC.Models.Account.AccountCardRecord();
                //插入卡的操作记录
                accountCardRecord.MarkNO = tempAccountCard.MarkNO;
                accountCardRecord.MarkType.ID = tempAccountCard.MarkType.ID;
                accountCardRecord.CardNO = tempAccountCard.Patient.PID.CardNO;
                accountCardRecord.OperateTypes.ID = (int)Neusoft.HISFC.Models.Account.MarkOperateTypes.Begin;
                accountCardRecord.Oper.ID = (this.accountManager.Operator as Neusoft.HISFC.Models.Base.Employee).ID;
                //是否收取卡成本费
                bool bl = controlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.AccountConstant.IsAcceptCardFee, true, false);
                if (bl)
                {
                    accountCardRecord.CardMoney = controlParamIntegrate.GetControlParam<decimal>(Neusoft.HISFC.BizProcess.Integrate.AccountConstant.AcceptCardFee, true, 0);
                }
                if (accountManager.InsertAccountCardRecord(accountCardRecord) == -1)
                {
                    MessageBox.Show("保存卡操作记录失败！"+ accountManager.Err);
                    return -1;
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 查询患者信息
        /// </summary>
        protected virtual int QueryPatientInfo()
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patient = this.ucRegPatientInfo1.GetPatientInfomation();
            if (string.IsNullOrEmpty(patient.Name) && string.IsNullOrEmpty(patient.Sex.ID.ToString()) && string.IsNullOrEmpty(patient.Pact.ID)
              && string.IsNullOrEmpty(patient.PID.CaseNO) && string.IsNullOrEmpty(patient.IDCardType.ID) && string.IsNullOrEmpty(patient.IDCard)
              && string.IsNullOrEmpty(patient.SSN))
            {
                return -1;
            }
                    

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查找患者信息，请稍后...");
            Application.DoEvents();
            //查找患者信息
            
            List<AccountCard> list = accountManager.GetAccountCard(patient.Name,
                                                                    patient.Sex.ID.ToString(),
                                                                    patient.Pact.ID,
                                                                    patient.PID.CaseNO,
                                                                    patient.IDCardType.ID,
                                                                    patient.IDCard,
                                                                    patient.SSN);
            if (list == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(accountManager.Err);
                return -1;
            }
            try
            {
                if (this.spPatient.Rows.Count > 0)
                {
                    this.spPatient.Rows.Remove(0, this.spPatient.Rows.Count);
                }
                this.spPatient.Rows.Count = list.Count;
                int count = 0,beginIndex = 0,rangCount = 1;
                count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    AccountCard tempCard = list[i];
                    //姓名
                    this.spPatient.Cells[i, 0].Text = tempCard.Patient.Name;
                    //性别
                    this.spPatient.Cells[i, 1].Text = tempCard.Patient.Sex.Name;
                    //生日
                    this.spPatient.Cells[i, 2].Text = this.accountManager.GetAge(tempCard.Patient.Birthday);
                    //民族
                    this.spPatient.Cells[i, 3].Text = this.ucRegPatientInfo1.GetName(tempCard.Patient.Nationality.ID, 0);
                    //合同单位
                    this.spPatient.Cells[i, 4].Text = tempCard.Patient.Pact.Name;
                    //证件类型
                    this.spPatient.Cells[i, 5].Text = this.ucRegPatientInfo1.GetName(tempCard.Patient.IDCardType.ID, 1);
                    //证件号
                    this.spPatient.Cells[i, 6].Text = tempCard.Patient.IDCard;
                    this.spPatient.Cells[i, 7].Text = tempCard.Patient.CompanyName;
                    this.spPatient.Cells[i, 8].Text = tempCard.Patient.AddressHome;
                    this.spPatient.Cells[i, 9].Text = tempCard.MarkNO;
                    this.spPatient.Cells[i, 10].Text = markTypeHelp.GetName(tempCard.MarkType.ID);
                    this.spPatient.Rows[i].Tag = tempCard;
                    //计算合并单元格
                    if (i < count - 1)
                    {
                        if (tempCard.Patient.PID.CardNO == list[i + 1].Patient.PID.CardNO)
                        {
                            rangCount += 1;
                            if (i == count - 2)
                            {
                                if (rangCount > 1)
                                {
                                    RangFpCell(beginIndex, rangCount);
                                }
                            }
                        }
                        else
                        {
                            if (rangCount > 1)
                            {
                                RangFpCell(beginIndex, rangCount);
                            }
                            beginIndex = i+1;
                            rangCount = 1;
                        }
                    }
                    
                }
                this.neuSpread1.ActiveSheet = spPatient;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="count"></param>
        private void RangFpCell(int begin, int count)
        {
            for (int col = 0; col < this.spPatient.Columns.Count - 2; col++)
            {
                this.spPatient.Models.Span.Add(begin, col, count, 1);
            }
        }

        /// <summary>
        /// 跳转焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRegPatientInfo1_OnFoucsOver(object sender, EventArgs e)
        {
            this.txtMarkNo.Focus();
            this.neuSpread1.ActiveSheet = this.spPatient;
        }

        /// <summary>
        /// 查找患者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRegPatientInfo1_OnEnterSelectPatient(object sender, EventArgs e)
        {
            if (this.IsSelectPatientByEnter)
            {
                this.QueryPatientInfo();
            }
        }

        /// <summary>
        /// ucRegPatientInfo控件cmb得到焦点时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucRegPatientInfo1_CmbFoucs(object sender, EventArgs e)
        {
            if (sender is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
            {
                FrameWork.WinForms.Controls.NeuComboBox cmb = sender as FrameWork.WinForms.Controls.NeuComboBox;
                ArrayList al = cmb.alItems;
                DealConstantList(al);
                this.neuSpread1.ActiveSheet = this.spInfo;
            }
            else
            {
                this.neuSpread1.ActiveSheet = this.spPatient;
            }
        }
        #endregion

        #region 事件
        private void ucCardManager_Load(object sender, EventArgs e)
        {
            ArrayList al = managerIntegrate.GetConstantList("MarkType");
            if (al == null)
            {
                MessageBox.Show("查找就诊卡类型失败");
                return;
            }
            this.cmbMarkType.AddItems(al);
            markTypeHelp.ArrayObject = al;
            this.ucRegPatientInfo1.CmbFoucs += new HandledEventHandler(ucRegPatientInfo1_CmbFoucs);
            this.ucRegPatientInfo1.OnFoucsOver+=new HandledEventHandler(ucRegPatientInfo1_OnFoucsOver);
            this.ucRegPatientInfo1.OnEnterSelectPatient +=new HandledEventHandler(ucRegPatientInfo1_OnEnterSelectPatient);
            this.ucRegPatientInfo1.IsLocalOperation = this.isLocalOperation;
            this.ucRegPatientInfo1.IsEnableIDEType = false;
            this.ucRegPatientInfo1.IsEnableIDENO = false;
            
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBar.AddToolButton("患者信息查询", "患者信息查询", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询, true, false, null);
            toolBar.AddToolButton("清屏", "清屏", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            return toolBar;
        }
        
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "患者信息查询":
                    {
                        QueryPatientInfo();
                        break;
                    }
                case "清屏":
                    {
                        this.ClearData();
                        break;
                    }
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return base.OnSave(sender, neuObject);
        }
        
        private void txtMarkNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                accountCard = new AccountCard();
                int resultValue = accountManager.GetCardByRule(this.txtMarkNo.Text.Trim(), ref accountCard);
                if (resultValue < 0)
                {
                    MessageBox.Show(accountManager.Err);
                    this.txtMarkNo.Focus();
                    this.txtMarkNo.SelectAll();
                    this.cmbMarkType.Tag = string.Empty;
                    return;
                }

                if (resultValue == 1)
                {
                    MessageBox.Show("该卡已被使用，请换卡！");
                    this.txtMarkNo.Focus();
                    this.txtMarkNo.SelectAll();
                    this.cmbMarkType.Tag = string.Empty;
                    return;
                }
                this.txtMarkNo.Text = accountCard.MarkNO;
                this.cmbMarkType.Tag = accountCard.MarkType.ID;
                if (MessageBox.Show("是否保存数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save();
                }
            }
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (this.neuSpread1.ActiveSheet != spPatient) return;

            if (this.spPatient.ActiveRow.Tag == null)
            {
                this.menuItem2.Enabled = false;
            }
            else
            {
                AccountCard tempAccountCard = this.spPatient.ActiveRow.Tag as AccountCard;
                //1为条码卡
                if (tempAccountCard != null && tempAccountCard.MarkType.ID == "1")
                {
                    this.menuItem2.Enabled = true;
                }
                else
                {
                    this.menuItem2.Enabled = false;
                }
            }
            this.menu.Show(neuSpread1 as Control, new Point(e.X, e.Y));
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1.ActiveSheet != this.spPatient) return;
            if (this.spPatient.ActiveRow.Tag == null) return;
            AccountCard tempCard = this.spPatient.ActiveRow.Tag as AccountCard;
            if (tempCard.Patient == null)
            {
                MessageBox.Show("查询患者信息失败！");
                return;
            }
            this.ucRegPatientInfo1.CardNO = tempCard.Patient.PID.CardNO;
            this.txtMarkNo.Focus();
        }

        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1.ActiveSheet != this.spPatient) return;
            if (this.spPatient.ActiveRow.Tag == null) return;
            //{63F68506-F49D-4ed5-92BD-28A52AF54626}
            AccountCard tempaccontCard = this.spPatient.ActiveRow.Tag as AccountCard;
            if (tempaccontCard == null) return;
            PictureBox picBox = new PictureBox();
            picBox.Size = new Size(400, 30);
            picBox.Visible = true;
            picBox.BackColor = System.Drawing.Color.White;
            picBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Panel panel = new Panel();
            panel.Controls.Add(picBox);
            panel.Visible = true;
            Class.Code39 code39 = new Neusoft.HISFC.Components.Account.Class.Code39();
            code39.ShowCodeString = true;
            Bitmap bitmap = code39.GenerateBarcode(tempaccontCard.MarkNO);
            picBox.Image = bitmap as Image;
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0, 0, panel);
        }

        private void ckIsTreatment_CheckedChanged(object sender, EventArgs e)
        {
            bool bl = ckIsTreatment.Checked;
            this.ucRegPatientInfo1.IsTreatment = bl;
            if (bl)
            {
                this.ucRegPatientInfo1.Clear();
                this.txtMarkNo.Focus();
            }
            else
            {
                this.ucRegPatientInfo1.Focus();
            }

        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {

            get
            {
                Type[] vtype = new Type[2];
                vtype[0] = typeof(IPrintLable);
               
                return vtype;
            }
        }

        #endregion
    }
        
}

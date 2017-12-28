using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Account.Controls
{
    /// <summary>
    /// 患者基本信息修改
    /// </summary>
    public partial class ucEditPatientInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEditPatientInfo()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 帐户管理业务层
        /// </summary>
        private HISFC.BizLogic.Fee.Account accountManager = new Neusoft.HISFC.BizLogic.Fee.Account();

        /// <summary>
        /// 就诊卡实体
        /// </summary>
        private HISFC.Models.Account.AccountCard accountCard = null;

        /// <summary>
        /// 入出转实体
        /// </summary>
        private HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        
        /// <summary>
        /// 输入类型 
        /// </summary>
        private EnumInputType inputType=new EnumInputType();

        /// <summary>
        /// 患者信息
        /// </summary>
        private HISFC.Models.RADT.PatientInfo oldPatient = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 变更记录业务层
        /// </summary>
        HISFC.BizProcess.Integrate.Function functionIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Function();

        /// <summary>
        /// EMPI管理类
        /// </summary>
        //private Neusoft.HISFC.BizProcess.Integrate.Registration.EMPIManager empiManager = new Neusoft.HISFC.BizProcess.Integrate.Registration.EMPIManager();

        #endregion

        #region 修改控制属性
        [Category("修改控制"), Description("费用来源是否可以修改")]
        public bool IsEnablePact
        {
            get 
            {
                return this.ucRegPatientInfo1.IsEnablePact; 
            }
            set
            {
                this.ucRegPatientInfo1.IsEnablePact = value;
            }
        }


        [Category("修改控制"), Description("医保证号是否可以修改")]
        public bool IsEnableSiNO
        {
            get 
            { 
                return  this.ucRegPatientInfo1.IsEnableSiNO; 
            }
            set
            {
                this.ucRegPatientInfo1.IsEnableSiNO = value;
            }
        }

        [Category("修改控制"), Description("是否可以修改证件类型")]
        public bool IsEnableIDEType
        {
            get 
            {
                return this.ucRegPatientInfo1.IsEnableIDEType;  
            }
            set
            {
                this.ucRegPatientInfo1.IsEnableIDEType = value;
            }
        }

        [Category("修改控制"), Description("是否可以修改证件号")]
        public bool IsEnableIDENO
        {
            get 
            {
                return this.ucRegPatientInfo1.IsEnableIDENO; 
            }
            set
            {
                this.ucRegPatientInfo1.IsEnableIDENO = value;
            }
        }

        [Category("修改控制"), Description("患者姓名加密是否可以修改")]
        public bool IsEnableEntry
        {
            get
            {
                return this.ucRegPatientInfo1.IsEnableEntry;
            }
            set
            {
                this.ucRegPatientInfo1.IsEnableEntry = value;
            }
        }

        [Category("修改控制"), Description("是否可以修改Vip标识")]
        public bool IsEnableVip
        {
            get
            {
                return this.ucRegPatientInfo1.IsEnableVip;
            }
            set
            {
                this.ucRegPatientInfo1.IsEnableVip = value;
            }
        }

        [Category("控件设置"),Description("输入类型 CardNO:门诊卡号 MarkNO:就诊卡号")]
        public EnumInputType InputType
        {
            get
            {
                return inputType;
            }
            set
            {
                inputType = value;
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
        /// 保存患者信息
        /// </summary>
        protected virtual void SavePatient()
        {
            if (!this.ucRegPatientInfo1.InputValid()) return;
            HISFC.Models.RADT.PatientInfo patient = this.ucRegPatientInfo1.GetPatientInfomation();
            FrameWork.Management.PublicTrans.BeginTransaction();
            #region 更新患者基本信息
            int resultValue = radtIntegrate.UpdatePatientInfo(patient);
            if (resultValue <= 0)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("保存患者信息失败！" + accountManager.Err);
                return;
            }
            #endregion

            //变更记录由触发器代替

            resultValue = functionIntegrate.SaveChange<HISFC.Models.RADT.Patient>(false, false, patient.PID.CardNO, oldPatient, patient);
            if (resultValue < 0)
            {
                FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("生成变更记录失败！");
                return;
            }

            #region 集成平台EMPI
            
            //if (this.empiManager.SaveOutpatientEMPI(this.ucRegPatientInfo1.GetPatientInfomation()) == -1)
            //{
            //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
            //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.empiManager.Err));
            //    return;
            //}

            #endregion

            FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存患者信息成功！");
            this.ucRegPatientInfo1.Clear();
            this.txtMarkNO.Text = string.Empty;
            this.txtMarkNO.Focus();
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        protected virtual void Clear()
        {
            this.ucRegPatientInfo1.Clear();
            this.txtMarkNO.Text = string.Empty;
        }

        /// <summary>
        /// 查找患者信息
        /// </summary>
        protected virtual void QueryPaitentInfo()
        {
            string cardNO = string.Empty;
            string tempStr = this.txtMarkNO.Text.Trim();
            string showStr = string.Empty;
            if (tempStr == string.Empty) return;
            if (InputType == EnumInputType.MarkNO)
            {
                accountCard = new Neusoft.HISFC.Models.Account.AccountCard();
                int resultValue = accountManager.GetCardByRule(tempStr, ref accountCard);
                if (resultValue <= 0)
                {
                    MessageBox.Show(accountManager.Err);
                    this.txtMarkNO.Focus();
                    this.txtMarkNO.SelectAll();
                    return;
                }
                if (this.accountCard.Patient == null) return;
                cardNO = this.accountCard.Patient.PID.CardNO;
                showStr = accountCard.MarkNO;

            }
            if (InputType == EnumInputType.CardNO)
            {
                cardNO = tempStr;
                //cardNO = cardNO.PadLeft(HISFC.BizProcess.Integrate.Common.ControlParam.GetCardNOLen(), '0');
                cardNO = cardNO.PadLeft(10, '0');
                showStr = cardNO;
            }
            this.txtMarkNO.Text = showStr;
            this.ucRegPatientInfo1.CardNO = cardNO;
            oldPatient = this.ucRegPatientInfo1.GetPatientInfomation().Clone();

            #region 集成平台EMPI
            if (oldPatient == null||string.IsNullOrEmpty(oldPatient.Name))
            {
                //if (this.empiManager.GetInpatientEMPI(this.ucRegPatientInfo1.CardNO,ref oldPatient) == -1)
                //{
                //    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.empiManager.Err));

                //    return;
                //}
            }

            #endregion

            this.ucRegPatientInfo1.Focus();
        }
        #endregion

        #region 事件
        private void ucEditPatientInfo_Load(object sender, EventArgs e)
        {
            this.ucRegPatientInfo1.CmbFoucs += new HandledEventHandler(ucRegPatientInfo1_CmbFoucs);
            this.ActiveControl = this.txtMarkNO;
        }

        private void ucRegPatientInfo1_CmbFoucs(object sender, EventArgs e)
        {
            if (sender is Neusoft.FrameWork.WinForms.Controls.NeuComboBox)
            {
                FrameWork.WinForms.Controls.NeuComboBox cmb = sender as FrameWork.WinForms.Controls.NeuComboBox;
                ArrayList al = cmb.alItems;
                DealConstantList(al);
                this.neuSpread1.ActiveSheet = this.spInfo;
            }
        }


        private void txtMarkNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                QueryPaitentInfo();
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            SavePatient();
            return base.OnSave(sender, neuObject);
        }
        #endregion
    }

    public enum EnumInputType
    {
        /// <summary>
        /// 就诊卡号
        /// </summary>
        MarkNO,
        /// <summary>
        /// 门诊卡号
        /// </summary>
        CardNO
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Integrate;
using System.Collections;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucSetting : UserControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        public ucSetting()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 错误信息
        /// </summary>
        private string errText = string.Empty;
        /// <summary>
        /// 是否修改
        /// </summary>
        private bool isModify = false;
        /// <summary>
        /// 是否显示按钮
        /// </summary>
        private bool isShowOwnButtons = true;

        /// <summary>
        /// 控制参数业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        /// <summary>
        /// 帐户设置
        /// </summary>
        AccountConstant accountConstant = new AccountConstant();

        /// <summary>
        /// 管理公共业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region 属性
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return "门诊帐户参数设置";
            }
            set
            {

            }
        }
        /// <summary>
        /// 错误提示
        /// </summary>
        public string ErrText
        {
            get
            {
                return errText;
            }
            set
            {
                errText = value;
            }
        }

        /// <summary>
        /// 是否修改
        /// </summary>
        public bool IsModify
        {
            get
            {
                return isModify;
            }
            set
            {
                isModify = value;
            }
        }

        /// <summary>
        /// 是否显示按钮
        /// </summary>
        public bool IsShowOwnButtons
        {
            get
            {
                return isShowOwnButtons;
            }
            set
            {
                isShowOwnButtons = value;
            }
        }
        #endregion 

        #region 方法

        public int Apply()
        {
            return 1;
        }
 
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            #region 建卡
            this.ckbIsAcceptCardFee.Checked = this.controlParamIntegrate.GetControlParam<bool>(AccountConstant.IsAcceptCardFee, true, false);
            this.txtAcceptCardFee.Text = this.controlParamIntegrate.GetControlParam<string>(AccountConstant.AcceptCardFee, true, "0");
            //this.ckCase.Checked = this.controlParamIntegrate.GetControlParam<bool>(AccountConstant.BulidCardIsCreateCaseInfo, true, true);
            #endregion 

            #region 换卡
            this.ckbisChangeCardFee.Checked = this.controlParamIntegrate.GetControlParam<bool>(AccountConstant.IsAcceptChangeCardFee, true, false);
            this.txtChangeCardFee.Text = this.controlParamIntegrate.GetControlParam<string>(AccountConstant.AcceptChangeCardFee, true, "0");
            #endregion
            this.Focus();
            return 1;
        }

        /// <summary>
        /// 从界面读取的控制参数值
        /// </summary>
        /// <returns>从界面读取的控制参数值集合</returns>
        public ArrayList GetAllControl()
        {
            ArrayList allControlValues = new ArrayList(); //所有的控制类集合

            Neusoft.HISFC.Models.Base.Controler tempControlObj = null;//临时控制类实体;

            string tempControlValue = null;// 从界面读取的控制参数值
                        
   

            #region 发卡
            #region 是否收取卡成本费用
            if (this.ckbIsAcceptCardFee.Checked == true)
            {
                tempControlValue = "1";//收取
            }
            else
            {
                tempControlValue = "0";//不收取
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = AccountConstant.IsAcceptCardFee;
            tempControlObj.Name = accountConstant.GetParamDescription(AccountConstant.IsAcceptCardFee);
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region  收取金额
            tempControlValue = this.txtAcceptCardFee.Text;
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = AccountConstant.AcceptCardFee;
            tempControlObj.Name = accountConstant.GetParamDescription(AccountConstant.AcceptCardFee);
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 发卡的同时是否建立病案信息
            //if (this.ckCase.Checked == true)
            //{
            //    tempControlValue = "1";//建立病案信息
            //}
            //else
            //{
            //    tempControlValue = "0";//不建立病案信息
            //}
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = AccountConstant.BulidCardIsCreateCaseInfo;
            //tempControlObj.Name = accountConstant.GetParamDescription(AccountConstant.BulidCardIsCreateCaseInfo);
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;

            //allControlValues.Add(tempControlObj.Clone());
            #endregion
            #endregion

            #region 换卡
            #region 是否收取
            if (this.ckbisChangeCardFee.Checked == true)
            {
                tempControlValue = "1";//收取
            }
            else
            {
                tempControlValue = "0";//不收取
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = AccountConstant.IsAcceptChangeCardFee;
            tempControlObj.Name = accountConstant.GetParamDescription(AccountConstant.IsAcceptChangeCardFee);
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region  收取金额
            tempControlValue = this.txtChangeCardFee.Text;
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = AccountConstant.AcceptChangeCardFee;
            tempControlObj.Name = accountConstant.GetParamDescription(AccountConstant.AcceptChangeCardFee);
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #endregion

            return allControlValues;
        }
      
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            ArrayList allControlsValues = GetAllControl();
            if (allControlsValues == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();

                return -1;
            }

            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.Base.Controler c in allControlsValues)
            {
                int iReturn = this.managerIntegrate.InsertControlerInfo(c);
                if (iReturn == -1)
                {
                    //主键重复，说明已经存在参数值,那么直接更新
                    if (managerIntegrate.DBErrCode == 1)
                    {
                        iReturn = this.managerIntegrate.UpdateControlerInfo(c);
                        if (iReturn <= 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("更新控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);

                            return -1;
                        }
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("插入控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);

                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("保存成功!");

            return 1;
        }

        #endregion

        #region 事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void ckbIsAcceptCardFee_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbIsAcceptCardFee.Checked)
            {
                this.txtAcceptCardFee.Text = "0";
                this.txtAcceptCardFee.ReadOnly = true;
            }
            else
            {
                this.txtAcceptCardFee.ReadOnly = false;
            }
        }

        private void ckbisChangeCardFee_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbisChangeCardFee.Checked)
            {
                this.txtChangeCardFee.Text = "0";
                this.txtChangeCardFee.ReadOnly = true;
            }
            else
            {
                this.txtChangeCardFee.ReadOnly = false;
            }
        }
        #endregion

    }
}

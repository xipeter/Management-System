using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Neusoft.HISFC.BizProcess.Integrate;
using Neusoft.FrameWork.Function;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucRegConstant : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        public ucRegConstant()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private string errText = string.Empty;

        /// <summary>
        /// 是否显示本UC的按钮
        /// </summary>
        private bool isShowButtons = true;

        /// <summary>
        /// 是否更改数据
        /// </summary>
        private bool isModify = false;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int Init()
        {
            

            #region 门诊挂号－挂号级别显示列数 
            this.nudRegLevCount.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Display_RegLevel_ColumnNumber);
            #endregion 

            #region 门诊挂号－挂号科室显示列数 
            this.nudRegDeptCount.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Display_RegDept_ColumnNumber);
            #endregion

            #region 门诊挂号－合同单位显示列数 
            this.nudRegPactCount.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Display_RegPact_ColumnNumber);
            #endregion

            #region 门诊挂号－出诊教授显示列数 
            this.nudRegProfCount.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Display_RegProfessor_ColumnNumber,true,3);
            #endregion

            #region 专家号是否先输科室 
            this.ckbFirsDept.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_RegProfessor_IsFirstDept,true,false);
            #endregion

            #region 诊金是否报销
            this.ckbDialogFeePub.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Dialog_IsPub,true,false);
            #endregion
            
            #region 是否只显示出诊科室 
            this.ckbDisplayDeptOnly.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Display_Only_Dept,true,false);
            #endregion

            #region 多张号是否作为加号 
            this.ckbMultiAdd.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsMultAdd,true,false);
            #endregion
            
            #region 挂号是否允许超出排班限额
            this.ckbOverFlowLimit.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Allow_Beyond_Limit,true,false);
            #endregion

            #region 诊断是否录入ICD码  {4C9DD3E0-9CE6-4dce-A9BB-EB56317AD24E}
            //this.ckbICD.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsICD,true,false);
            #endregion

            #region 是否跳到预约流水号处
            this.ckbJumpToYY.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Jump_To_Yuyue,true,false);
            #endregion
            
            #region 光标是否需跳到预约时间段处
            
            this.ckbJumpToYYTime.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Jump_To_YuyueTime,true,false); 
            #endregion
            
            #region 科室、医生下拉列表是否显示全院,默认是 
            this.ckbDeptDoctList.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Alow_Quanyuan,true,false);
            #endregion
            
            #region 保存时是否提示 
            this.ckbSaveMessage.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsSaveMsg,true,false); 
            #endregion
            
            #region 排班是否输入医生类别 
            this.ckbDoctType.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Schama_Doct_IsDoctType,true,false); 
            #endregion

            #region 排班是否选择挂号级别
            this.chkReglevel.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsInputRegLevel, true, false);
            #endregion

            #region 是否预约号看诊序号排在现场号前面别
            this.ckbYYBeforeXC.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsBookingBeforeLocal,true,false); 
            #endregion

            #region 门诊挂号－挂号费中otherfee的意义 0:床费(广医专用) 1：病历本费 2：其他费
            //this.cmbAirCondition. = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_Is_AirCondition, true, false); 

            int selectIndex = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Is_AirCondition, true, 0);

            this.cmbAirCondition.SelectedIndex = selectIndex;


            #endregion

            #region 专家号是否区分教授级别 
            this.ckbDifferentProfLev.Checked = this.controlParamIntegrate.GetControlParam<bool>(RegistrationConstant.Const_IsDivision_ProLevel,true,false);
            #endregion

            #region 允许退号天数
            this.nudAllow_QuitReg_Days.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Allow_QuitReg_Days,true,0);
            #endregion

            #region 公费患者允许日挂号限额
            this.nudAllow_PubPatient_RegLimitCost.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Allow_PubPatient_RegLimitCost, true, 0);
            #endregion

            #region 排班默认时间段间隔
            this.udDefaultNoon.Value = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_Default_Noon, true, 0);
            #endregion


            selectIndex = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_GetInvoiceWay, true, 0);
            
            #region 获得发票号方案 
            selectIndex = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_GetRecipe_Way, true, 0);
            if (selectIndex > 0)
            {
                this.cmbGetRecipe_Way.SelectedIndex = selectIndex - 1;
            }
            else
            {
                this.cmbGetRecipe_Way.SelectedIndex = 0;
 
            }
            #endregion

            #region 门诊挂号－打印哪种收据Invoice?Recipe  {4C9DD3E0-9CE6-4dce-A9BB-EB56317AD24E}
            //this.cmbInvoiceType.SelectedIndex = this.controlParamIntegrate.GetControlParam<int>(RegistrationConstant.Const_InvoiceType , true, 0);
            #endregion

            #region  合同单位默认代码
            ArrayList al = new ArrayList();
            al = this.managerIntegrate.QueryPactUnitAll();
            if (al.Count > 0)
            {
                this.cmbPact.AddItems(al); 
               
                string defoultPactId = this.controlParamIntegrate.GetControlParam<string>(RegistrationConstant.Const_Display_DefaultPact, true, string.Empty);
                for (int i = 0; i < al.Count; i++)
                {
                    if (((Neusoft.FrameWork.Models.NeuObject)al[i]).ID == defoultPactId)
                    {
                        this.cmbPact.SelectedIndex = i;
                    }
                }

            }

            
            #endregion


            this.InitTab();


            return 1;
        }
        public int Apply()
        {
            return 1;
        }
        /// <summary>
        /// 从界面读取的控制参数值
        /// </summary>
        /// <returns>从界面读取的控制参数值集合</returns>
        private ArrayList GetAllControlValue()
        {
            ArrayList allControlValues = new ArrayList(); //所有的控制类集合

            Neusoft.HISFC.Models.Base.Controler tempControlObj = null;//临时控制类实体;

            string tempControlValue = null;// 从界面读取的控制参数值
            #region 门诊挂号－挂号级别显示列数
            tempControlValue = this.nudRegLevCount.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_RegLevel_ColumnNumber;
            tempControlObj.Name = "门诊挂号－挂号级别显示列数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－挂号科室显示列数
            tempControlValue = this.nudRegDeptCount.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_RegDept_ColumnNumber;
            tempControlObj.Name = "门诊挂号－挂号科室显示列数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－合同单位显示列数

            tempControlValue = this.nudRegPactCount.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_RegPact_ColumnNumber;
            tempControlObj.Name = "门诊挂号－合同单位显示列数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－出诊教授显示列数
            tempControlValue = this.nudRegProfCount.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_RegProfessor_ColumnNumber;
            tempControlObj.Name = "门诊挂号－出诊教授显示列数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－专家号是否先输科室

            if (this.ckbFirsDept.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_RegProfessor_IsFirstDept;
            tempControlObj.Name = "门诊挂号－专家号是否先输科室";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－诊金是否报销
            if (this.ckbDialogFeePub.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Dialog_IsPub;
            tempControlObj.Name = "门诊挂号－诊金是否报销";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－是否只显示出诊科室

            if (this.ckbDisplayDeptOnly.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_Only_Dept;
            tempControlObj.Name = "门诊挂号－是否只显示出诊科室";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－多张号是否作为加号

            if (this.ckbMultiAdd.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsMultAdd;
            tempControlObj.Name = "门诊挂号－多张号是否作为加号";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－挂号是否允许超出排班限额
            if (this.ckbOverFlowLimit.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Allow_Beyond_Limit;
            tempControlObj.Name = "门诊挂号－挂号是否允许超出排班限额";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－诊断是否录入ICD码 {4C9DD3E0-9CE6-4dce-A9BB-EB56317AD24E}


            //if (this.ckbICD.Checked)
            //{
            //    tempControlValue = "1";
            //}
            //else
            //{
            //    tempControlValue = "0";
            //}
            //tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            //tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsICD;
            //tempControlObj.Name = "门诊挂号－诊断是否录入ICD码";
            //tempControlObj.ControlerValue = tempControlValue;
            //tempControlObj.VisibleFlag = true;
            //allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－是否跳到预约流水号处
            if (this.ckbJumpToYY.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Jump_To_Yuyue;
            tempControlObj.Name = "门诊挂号－是否跳到预约流水号处";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－光标是否需跳到预约时间段处
            if (this.ckbJumpToYYTime.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Jump_To_YuyueTime;
            tempControlObj.Name = "门诊挂号－光标是否需跳到预约时间段处";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－科室、医生下拉列表是否显示全院,默认是

            if (this.ckbDeptDoctList.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Alow_Quanyuan;
            tempControlObj.Name = "门诊挂号－科室、医生下拉列表是否显示全院,默认是";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－保存时是否提示

            if (this.ckbSaveMessage.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsSaveMsg;
            tempControlObj.Name = "门诊挂号－保存时是否提示";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－排班是否输入医生类别

            if (this.ckbDoctType.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Schama_Doct_IsDoctType;
            tempControlObj.Name = "门诊挂号－排班是否输入医生类别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊挂号 - 排班是否选择挂号级别
            if (this.chkReglevel.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsInputRegLevel;
            tempControlObj.Name = "门诊挂号－排班是否选择挂号级别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊挂号－是否预约号看诊序号排在现场号前面别

            if (this.ckbYYBeforeXC.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsBookingBeforeLocal;
            tempControlObj.Name = "门诊挂号－是否预约号看诊序号排在现场号前面别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－是否收取空调费(附加费)
            if (this.ckbYYBeforeXC.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Is_AirCondition;
            tempControlObj.Name = "门诊挂号－是否收取空调费(附加费) ";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－专家号是否区分教授级别

            if (this.ckbDifferentProfLev.Checked)
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = "0";
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_IsDivision_ProLevel;
            tempControlObj.Name = "门诊挂号－专家号是否区分教授级别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊退号－允许退号天数

            tempControlValue = this.nudAllow_QuitReg_Days.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Allow_QuitReg_Days;
            tempControlObj.Name = "门诊退号－允许退号天数";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－公费患者允许日挂号限额

            tempControlValue = this.nudAllow_PubPatient_RegLimitCost.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Allow_PubPatient_RegLimitCost;
            tempControlObj.Name = "门诊挂号－公费患者允许日挂号限额";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－排班默认时间段间隔,0默认为整个午别
            tempControlValue = this.udDefaultNoon.Value.ToString();
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Default_Noon;
            tempControlObj.Name = "门诊挂号－排班默认时间段间隔,0默认为整个午别";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;
            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 获得发票号方案

            if (this.cmbGetRecipe_Way.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "2";
            }
            else
            {
                tempControlValue = (this.cmbGetRecipe_Way.SelectedIndex + 1).ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_GetRecipe_Way;
            tempControlObj.Name = "门诊挂号－1处方号,2挂号收据号,3门诊收据号";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion

            #region 门诊挂号－挂号费中otherfee的意义 0:床费(广医专用) 1：病历本费 2：其他费
             if (this.cmbAirCondition.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "2";
            }
            else
            {
                tempControlValue = (this.cmbGetRecipe_Way.SelectedIndex).ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Is_AirCondition;
            tempControlObj.Name = "门诊挂号－挂号费中otherfee的意义 0:床费(广医专用) 1：病历本费 2：其他费";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
            #endregion

            #region 门诊挂号－打印哪种收据Invoice?Recipe {4C9DD3E0-9CE6-4dce-A9BB-EB56317AD24E}
            /*

            if (this.cmbInvoiceType.Text.Trim() == "")//如果没有输入默认为0 
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = this.cmbInvoiceType.SelectedIndex.ToString();
            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_InvoiceType;
            tempControlObj.Name = "门诊挂号－打印哪种收据Invoice?Recipe";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());
             */

            #endregion

            #region  合同单位默认代码
            if (this.cmbPact.Text.Trim() == "")
            {
                tempControlValue = "1";
            }
            else
            {
                tempControlValue = this.cmbPact.Tag.ToString() ;

            }
            tempControlObj = new Neusoft.HISFC.Models.Base.Controler();
            tempControlObj.ID = Neusoft.HISFC.BizProcess.Integrate.RegistrationConstant.Const_Display_DefaultPact;
            tempControlObj.Name = "合同单位默认代码";
            tempControlObj.ControlerValue = tempControlValue;
            tempControlObj.VisibleFlag = true;

            allControlValues.Add(tempControlObj.Clone());

            #endregion
            return allControlValues;
        }
        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            ArrayList allControlsValues = GetAllControlValue();
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
        /// <summary>
        /// 去处空的tabpage
        /// </summary>
        private void InitTab()
        {

            System.Windows.Forms.TabControl.TabPageCollection TPCollection = this.neuTabControl1.TabPages;
            if (TPCollection == null || TPCollection.Count == 0)
            {
                return;
            }
            {
                for (int i = 0; i < TPCollection.Count; i++)
                {
                    System.Windows.Forms.Control.ControlCollection CC = this.neuTabControl1.TabPages[i].Controls;
                    {
                        if (CC == null || CC.Count == 0)
                        {
                            this.neuTabControl1.TabPages.RemoveAt(i) ;
                        }

                    }
                }
            }


        }

        #region 属性

        /// <summary>
        /// 是否更改数据
        /// </summary>
        public bool IsModify
        {
            get
            {
                return this.isModify;
            }
            set
            {
                this.isModify = value;
            }
        }

        /// <summary>
        /// 是否显示本UC的按钮
        /// </summary>
        public bool IsShowOwnButtons
        {
            get
            {
                return this.isShowButtons;
            }
            set
            {
                this.isShowButtons = value;
                if (!this.isShowButtons)
                {
                    this.plBottom.Height = 0;
                }
                else
                {
                    this.plBottom.Height = 34;
                }
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrText
        {
            get
            {
                return this.errText;
            }
            set
            {
                this.errText = value;
            }
        }

        /// <summary>
        /// 控件描述
        /// </summary>
        public string Description
        {
            get
            {
                return "门诊挂号参数设置";
            }
            set
            {

            }
        }

        #endregion
        protected override  Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.Init();
            return base.OnInit(sender, neuObject, param);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.isShowButtons)
            {
                this.FindForm().Close();
            }
        }
       
       

    }
}

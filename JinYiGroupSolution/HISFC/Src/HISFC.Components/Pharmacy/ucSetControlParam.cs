using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizProcess.Integrate;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品日消耗设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///     1、屏蔽对于“显示摆药单预览”参数的设置。该参数意义不大
    ///     2、屏蔽是否按批号盘点参数 该属性通过部门库存常数获取
    ///     3、增加住院是否使用预扣库存方式的控制参数
    ///     4、增加协定处方是否管理库存的控制参数
    /// </修改记录>
    /// </summary>
    public partial class ucSetControlParam : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Common.IControlParamMaint
    {
        public ucSetControlParam()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        #region 域变量

        /// <summary>
        /// 功能描述
        /// </summary>
        private string description = "药品管理参数设置";

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        /// <summary>
        /// 药品控制参数信息
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant phaConsInfo = new PharmacyConstant();

        /// <summary>
        /// 获取本次初始化时的参数值 保存时对于变化的参数进行保存
        /// </summary>
        private System.Collections.Hashtable hsOriginalParam = new System.Collections.Hashtable();

        /// <summary>
        /// 管理公共业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        #endregion

        #region 方法

        /// <summary>
        /// 获取所有参数
        /// </summary>
        /// <returns></returns>
        public List<Neusoft.HISFC.Models.Base.Controler> GetControlerList()
        {
            List<Neusoft.HISFC.Models.Base.Controler> alControler = new List<Neusoft.HISFC.Models.Base.Controler>();

            Neusoft.HISFC.Models.Base.Controler tempControler = new Neusoft.HISFC.Models.Base.Controler();

            #region 住院药房参数

            #region 拆分属性

            ///药房拆分属性是否可维护为不可拆分当日取整
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckNosplitAndDayToInteger.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckNosplitAndDayToInteger.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //药房拆分属性是否可维护为不可拆分
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckNoSplitAtAll.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckNoSplitAtAll.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品拆分属性是否可设置为可拆分不取整
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckSplitAndNoInteger.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSplitAndNoInteger.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品拆分属性是否可设置为可拆分上取整
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckSplitAndUpperToInteger.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSplitAndUpperToInteger.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品拆分属性是否可设置为可拆分按科室取整
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckSplitAndDeptToInteger.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSplitAndDeptToInteger.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品拆分属性是否可设置为按病区取整
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckSplitAndNurceCellToInteger.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSplitAndNurceCellToInteger.Checked).ToString();
            alControler.Add(tempControler.Clone());

            #endregion

            #region 摆药流程控制

            ///摆药是否需核准
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInNeedApprove.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInNeedApprove.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否药师才可以核准
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInNeedPriv.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInNeedPriv.Checked).ToString();
            alControler.Add(tempControler.Clone());

            #endregion

            #region 摆药功能控制

            //屏蔽作废参数设置信息
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckInPartApprove.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInPartApprove.Checked).ToString();
            //alControler.Add(tempControler.Clone());

            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInPatientPreOut.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInPatientPreOut.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //屏蔽作废参数设置信息
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckAutoPrintOutput.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckAutoPrintOutput.Checked).ToString();
            //alControler.Add(tempControler.Clone());

            #endregion

            #region 摆药界面控制

            ///摆药是否预览
            ///            //屏蔽作废参数设置信息
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckInPriviewBill.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInPriviewBill.Checked).ToString();
            //alControler.Add(tempControler.Clone());

            ///新加信息是否自动选中
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInAutoCheck.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInAutoCheck.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否显示患者汇总
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckPatientTot.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckPatientTot.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否显示科室汇总
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckDeptTot.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckDeptTot.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否显示科室优先方式显示
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckDeptFirst.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckDeptFirst.Checked).ToString();
            alControler.Add(tempControler.Clone());

            #endregion

            #endregion

            #region 门诊药房参数

            ///门诊发药终端保存后 是否刷新
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckSaveRefresh.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSaveRefresh.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///门诊发药界面是否显示付数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckOutShowDays.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckOutShowDays.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///配药确认后是否打印配药清单
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckOutPrintList.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckOutPrintList.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///发药确认后是否打印处方
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckOutPrintRecipe.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckOutPrintRecipe.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///配药检索时工号补足位数 －1 不需补位
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ndUOperLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.ndUOperLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///配/发药窗口是否进行权限控制 (只有药师可以操作) 
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckOutNeedPriv.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckOutNeedPriv.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///门诊标签自动打印时  是否对存在作废记录的处方不打印
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckPrintBackRecipe.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckPrintBackRecipe.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///门诊配药时 是否进行库存警戒判断 
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckClinicWarDrug.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckClinicWarDrug.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///门诊发药时 是否进行库存警戒判断 
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckClinicWarnSend.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckClinicWarnSend.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///门诊收费时是否预扣库存
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckClinicPreOut.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckClinicPreOut.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //门诊发药界面是否显示隔天待发药患者
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckShowOldSendedInfo.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckShowOldSendedInfo.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //门诊配药采用自动配药模式
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckAutoDruged.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckAutoDruged.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //门诊发药采用自动发药模式
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckAutoSend.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckAutoSend.Checked).ToString();
            alControler.Add(tempControler.Clone());

            #endregion

            #region 字典维护参数

            ///新增药品是否需审核后生效
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckNewDrugNeedApprove.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckNewDrugNeedApprove.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品字典信息特殊标记维护信息设置   {6F6120F5-6D88-47ce-AF9C-0CF781DE412F}
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.Set_Item_SpecialFlag;
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);

            string ctrlValue = "";
            if (this.ckItemSpeFlag1.Checked)
            {
                ctrlValue = ctrlValue + "A1" + this.txtItemSpeFlag1.Text;
            }
            else
            {
                ctrlValue = ctrlValue + "A0" + this.txtItemSpeFlag1.Text;
            }
            if (this.ckItemSpeFlag2.Checked)
            {
                ctrlValue = ctrlValue + "B1" + this.txtItemSpeFlag2.Text;
            }
            else
            {
                 ctrlValue = ctrlValue + "B0" + this.txtItemSpeFlag2.Text;
            }
            if (this.ckItemSpeFlag3.Checked)
            {
                ctrlValue = ctrlValue + "C1" + this.txtItemSpeFlag3.Text;
            }
            else
            {
                ctrlValue = ctrlValue + "C0" + this.txtItemSpeFlag3.Text;
            }
            tempControler.ControlerValue = ctrlValue;

            alControler.Add(tempControler.Clone());

            //屏蔽作废参数
            /////操作员无修改权限时 是否允许对药品信息查询浏览
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckQueryNoPriv.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckQueryNoPriv.Checked).ToString();
            //alControler.Add(tempControler.Clone());

            /////操作员无修改权限时 是否允许对药品信息导出/打印
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckExportNoPriv.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckExportNoPriv.Checked).ToString();
            //alControler.Add(tempControler.Clone());

            ///药品信息维护时  对于包装数量允许输入的最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDPackLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDPackLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///药品信息维护时  对于基本剂量允许输入的最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDBaseDoseLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDBaseDoseLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///药品信息维护时  对于价格允许输入的最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDPriceLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDPriceLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///商品名自定义码允许输入的最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDNameCodeLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDNameCodeLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///其他自定义码允许输入的最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDCodeLength.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDCodeLength.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///是否允许通用名维护获得Tab顺序
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckRegularTab.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckRegularTab.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否允许英文名维护获得Tab顺序
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckEnglishTab.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckEnglishTab.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否允许国标/国家编码维护获得Tab顺序
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckCodeTab.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckCodeTab.Checked).ToString();
            alControler.Add(tempControler.Clone());

            //该参数作废 协定处方只按管理库存处理
            /////协定处方是否管理库存 如果不管理库存 则收费时拆分明细 否则不进行拆分
            //tempControler = new Neusoft.HISFC.Models.Base.Controler();
            //tempControler.ID = this.ckNostrumManageStore.Tag.ToString();
            //tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            //tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckNostrumManageStore.Checked).ToString();

            alControler.Add(tempControler.Clone());

            #endregion

            #region 库存管理参数

            ///药品盘点是否按批号进行盘点
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckCheckBatch.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckCheckBatch.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///历史盘点单获取时是否只取结存状态
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.cmbCheckHistoryState.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            if (this.cmbCheckHistoryState.Text == "结存盘点单")
            {
                tempControler.ControlerValue = "1";
            }
            else
            {
                tempControler.ControlerValue = "0";
            }
            alControler.Add(tempControler.Clone());


            ///库存货位号允许输入最大位数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDMaxPlace.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDMaxPlace.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///是否启用有效期警示
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckValidEnable.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckValidEnable.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///有效期最大警示天数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDWarnDays.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDWarnDays.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///有效期警示颜色
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.btValidColor.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.btValidColor.BackColor.ToArgb().ToString();
            alControler.Add(tempControler.Clone());

            ///有效期采用实时获取获取方式
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckValidRealTime.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckValidRealTime.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否采用库存上下限报警
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckStoreValid.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckStoreValid.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///报警时是否采用弹出信息方式 不使用字体颜色警示
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckWarnMsg.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckWarnMsg.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///报警字体颜色警示
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.btStoreColor.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.btStoreColor.BackColor.ToArgb().ToString();
            alControler.Add(tempControler.Clone());

            #endregion

            #region 入出库管理参数

            ///自动生成计划时 计算日均出库量，日消耗 统计默认天数
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.nUDExpandDays.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.nUDExpandDays.Value.ToString();
            alControler.Add(tempControler.Clone());

            ///列表选择控件是否显示行标题
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckPlanRowHeader.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckPlanRowHeader.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否允许通过行索引确认选择数据
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckNumSelectRow.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckNumSelectRow.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///是否对计划量是否为零进行判断
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckPlanZeroValid.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckPlanZeroValid.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///采购是否需要审核后生效
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckStockNeedApprove.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckStockNeedApprove.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///出库时是否可以选择批号
            ///{DE934736-B2C2-44a4-A218-2DC38E1620BA}
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckOutChooseBatch.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckOutChooseBatch.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///采购审核时 是否允许修改相应的计划信息
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckEditInplan.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckEditInplan.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///采购计划/审核时 是否允许修改计划购入价
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckEditPrice.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckEditPrice.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///采购指定时是否使用字典信息内默认的供货公司
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckStockUseDefaultData.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckStockUseDefaultData.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品入库是否需要审核 原参数 500002
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInputNeedApprove.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInputNeedApprove.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///退出时是否保存上一次操作权限类型
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInSavePriv.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInSavePriv.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///药品核准入库时是否更新药品字典信息购入价
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckInEditPrice.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckInEditPrice.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///价让出库时是否使用批发价
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.ckTransferOutUseWholePrice.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckTransferOutUseWholePrice.Checked).ToString();
            alControler.Add(tempControler.Clone());

            ///价让出库默认加价率
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.txtTransferOutRate.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtTransferOutRate.Text).ToString();
            alControler.Add(tempControler.Clone());

            ///药房/药库通用查询大类            
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.txtCommonQuery.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.txtCommonQuery.Text;
            alControler.Add(tempControler.Clone());

            ///药库查询大类
            tempControler = new Neusoft.HISFC.Models.Base.Controler();
            tempControler.ID = this.txtPIQuery.Tag.ToString();
            tempControler.Name = this.phaConsInfo.GetParamDescription(tempControler.ID);
            tempControler.ControlerValue = this.txtPIQuery.Text;
            alControler.Add(tempControler.Clone());

            #endregion

            #region 本地参数

            string strErr = "";

            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("ClinicDrug", "PrintList", out strErr,Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckPrintLabel.Checked).ToString());         

            Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("ClinicDrug", "TerminalCode", out strErr, this.txtDefaultTCode.Text);
            #endregion

            return alControler;
        }

        #endregion

        #region IControlParamMaint 成员

        public int Apply()
        {
            throw new Exception("The method or operation is not implemented.");
            
            
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string ErrText
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Init()
        {

            #region 住院药房参数

            #region 拆分属性

            ///药房拆分属性是否可维护为不可拆分当日取整
            this.ckNosplitAndDayToInteger.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_NosplitAndDayToInteger, true, true);
            this.ckNosplitAndDayToInteger.Tag = PharmacyConstant.Can_Set_NosplitAndDayToInteger;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_NosplitAndDayToInteger, this.ckNosplitAndDayToInteger.Checked.ToString());

            //药房拆分属性是否可维护为不可拆分
            this.ckNoSplitAtAll.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_NoSplitAtAll, true, true);
            this.ckNoSplitAtAll.Tag = PharmacyConstant.Can_Set_NoSplitAtAll;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_NoSplitAtAll, this.ckNoSplitAtAll.Checked.ToString());

            ///药品拆分属性是否可设置为可拆分不取整
            this.ckSplitAndNoInteger.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_SplitAndNoInteger, true, false);
            this.ckSplitAndNoInteger.Tag = PharmacyConstant.Can_Set_SplitAndNoInteger;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_SplitAndNoInteger, this.ckSplitAndNoInteger.Checked.ToString());

            ///药品拆分属性是否可设置为可拆分上取整
            this.ckSplitAndUpperToInteger.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_SplitAndUpperToInteger, true, true);
            this.ckSplitAndUpperToInteger.Tag = PharmacyConstant.Can_Set_SplitAndUpperToInteger;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_SplitAndUpperToInteger, this.ckSplitAndUpperToInteger.Checked.ToString());

            ///药品拆分属性是否可设置为可拆分按科室取整
            this.ckSplitAndDeptToInteger.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_SplitAndDeptToInteger, true, false);
            this.ckSplitAndDeptToInteger.Tag = PharmacyConstant.Can_Set_SplitAndDeptToInteger;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_SplitAndDeptToInteger, this.ckSplitAndDeptToInteger.Checked.ToString());

            ///药品拆分属性是否可设置为按病区取整
            this.ckSplitAndNurceCellToInteger.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Can_Set_SplitAndNurceCellToInteger, true, false);
            this.ckSplitAndNurceCellToInteger.Tag = PharmacyConstant.Can_Set_SplitAndNurceCellToInteger;
            this.hsOriginalParam.Add(PharmacyConstant.Can_Set_SplitAndNurceCellToInteger, this.ckSplitAndNurceCellToInteger.Checked.ToString());

            #endregion

            #region 摆药流程控制
            
            ///摆药是否需核准
            this.ckInNeedApprove.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Need_Approve, true, true);
            this.ckInNeedApprove.Tag = PharmacyConstant.InDrug_Need_Approve;
            this.hsOriginalParam.Add(PharmacyConstant.InDrug_Need_Approve, this.ckInNeedApprove.Checked.ToString());

            ///是否药师才可以核准
            this.ckInNeedPriv.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Need_Priv, true, false);
            this.ckInNeedPriv.Tag = PharmacyConstant.InDrug_Need_Priv;
            this.hsOriginalParam.Add(PharmacyConstant.InDrug_Need_Priv, this.ckInNeedPriv.Checked.ToString());

            #endregion

            #region 摆药功能控制

            //屏蔽作废参数设置信息
            //this.ckInPartApprove.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Part_Approve, true, false);
            //this.ckInPartApprove.Tag = PharmacyConstant.InDrug_Part_Approve;
            //this.hsOriginalParam.Add(PharmacyConstant.InDrug_Part_Approve, this.ckInPartApprove.Checked.ToString());

            this.ckInPatientPreOut.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Pre_Out, true, true);
            this.ckInPatientPreOut.Tag = PharmacyConstant.InDrug_Pre_Out;
            this.hsOriginalParam.Add(PharmacyConstant.InDrug_Pre_Out, this.ckInPatientPreOut.Checked.ToString());

            //屏蔽作废参数设置信息
            //this.ckAutoPrintOutput.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_AutoPrint_Output, true, false);
            //this.ckAutoPrintOutput.Tag = PharmacyConstant.InDrug_AutoPrint_Output;
            //this.hsOriginalParam.Add(PharmacyConstant.InDrug_AutoPrint_Output, this.ckAutoPrintOutput.Checked.ToString());

            #endregion

            #region 摆药界面控制

            ///摆药是否预览
            ///            //屏蔽作废参数设置信息
            //this.ckInPriviewBill.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Priview_Bill, true, false);
            //this.ckInPriviewBill.Tag = PharmacyConstant.InDrug_Priview_Bill;

            ///新加信息是否自动选中
            this.ckInAutoCheck.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Auto_Check, true, false);
            this.ckInAutoCheck.Tag = PharmacyConstant.InDrug_Auto_Check;

            ///是否显示患者汇总
            this.ckPatientTot.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Show_PatientTot, true, false);
            this.ckPatientTot.Tag = PharmacyConstant.InDrug_Show_PatientTot;

            ///是否显示科室汇总
            this.ckDeptTot.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Show_DeptTot, true, false);
            this.ckDeptTot.Tag = PharmacyConstant.InDrug_Show_DeptTot;

            ///是否显示科室优先方式显示
            this.ckDeptFirst.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.InDrug_Show_DeptFirst, true, true);
            this.ckDeptFirst.Tag = PharmacyConstant.InDrug_Show_DeptFirst;
            #endregion

            #endregion

            #region 门诊药房参数

            ///门诊发药终端保存后 是否刷新
            this.ckSaveRefresh.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Terminal_Save_Refresh, true, true);
            this.ckSaveRefresh.Tag = PharmacyConstant.Terminal_Save_Refresh;

            ///门诊发药界面是否显示付数
            this.ckOutShowDays.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Show_Days, true, false);
            this.ckOutShowDays.Tag = PharmacyConstant.OutDrug_Show_Days;

            ///配药确认后是否打印配药清单
            this.ckOutPrintList.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Print_List, true, false);
            this.ckOutPrintList.Tag = PharmacyConstant.OutDrug_Print_List;

            ///发药确认后是否打印处方
            this.ckOutPrintRecipe.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Print_Recipe, true, false);
            this.ckOutPrintRecipe.Tag = PharmacyConstant.OutDrug_Print_Recipe;

            ///配药检索时工号补足位数 －1 不需补位
            this.ndUOperLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.OutDrug_OperCode_Length, true, 6);
            this.ndUOperLength.Tag = PharmacyConstant.OutDrug_OperCode_Length;

            ///配/发药窗口是否进行权限控制 (只有药师可以操作) 
            this.ckOutNeedPriv.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Need_Priv, true, true);
            this.ckOutNeedPriv.Tag = PharmacyConstant.OutDrug_Need_Priv;

            ///门诊标签自动打印时  是否对存在作废记录的处方不打印
            this.ckPrintBackRecipe.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Print_BackRecipe, true, false);
            this.ckPrintBackRecipe.Tag = PharmacyConstant.OutDrug_Print_BackRecipe;

            ///门诊配药时 是否进行库存警戒判断 
            this.ckClinicWarDrug.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Warn_Druged, true, false);
            this.ckClinicWarDrug.Tag = PharmacyConstant.OutDrug_Warn_Druged;

            ///门诊发药时 是否进行库存警戒判断 
            this.ckClinicWarnSend.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Warn_Send, true, false);
            this.ckClinicWarnSend.Tag = PharmacyConstant.OutDrug_Warn_Send;

            ///门诊收费时是否进行预扣库存操作
            this.ckClinicPreOut.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Pre_Out, true, true);
            this.ckClinicPreOut.Tag = PharmacyConstant.OutDrug_Pre_Out;

            this.ckShowOldSendedInfo.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Show_OldSended, true, false);
            this.ckShowOldSendedInfo.Tag = PharmacyConstant.OutDrug_Show_OldSended;

            //门诊配药时采用自动配药模式
            this.ckAutoDruged.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Auto_Druged, true, false);
            this.ckAutoDruged.Tag = PharmacyConstant.OutDrug_Auto_Druged;

            //门诊配药时采用自动配药模式
            this.ckAutoSend.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.OutDrug_Auto_Send, true, false);
            this.ckAutoSend.Tag = PharmacyConstant.OutDrug_Auto_Send;
            #endregion

            #region 字典维护参数

            ///新增药品是否需审核后生效
            this.ckNewDrugNeedApprove.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.NewDrug_Need_Approve, true, false);
            this.ckNewDrugNeedApprove.Tag = PharmacyConstant.NewDrug_Need_Approve;

            ///药品字典信息特殊标记维护信息设置  {6F6120F5-6D88-47ce-AF9C-0CF781DE412F}
            string ctrlValue = this.ctrlIntegrate.GetControlParam<string>( PharmacyConstant.Set_Item_SpecialFlag, true,"");

            if (ctrlValue.IndexOf( "A" ) != -1 && ctrlValue.IndexOf( "B" ) != -1 && ctrlValue.IndexOf( "C" ) != -1)
            {
                string strFlag1 = ctrlValue.Substring( 0, ctrlValue.IndexOf( "B" ) );
                string strFlag2 = ctrlValue.Substring( ctrlValue.IndexOf( "B" ), ctrlValue.IndexOf( "C" ) - ctrlValue.IndexOf( "B" ) );
                string strFlag3 = ctrlValue.Substring( ctrlValue.IndexOf( "C" ) );

                this.ckItemSpeFlag1.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag1.Substring( 1, 1 ) );       //是否选中
                this.txtItemSpeFlag1.Text = strFlag1.Substring( 2 );

                this.ckItemSpeFlag2.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag2.Substring( 1, 1 ) );       //是否选中
                this.txtItemSpeFlag2.Text = strFlag2.Substring( 2 );

                this.ckItemSpeFlag3.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean( strFlag3.Substring( 1, 1 ) );       //是否选中
                this.txtItemSpeFlag3.Text = strFlag3.Substring( 2 );
            }

            //屏蔽作废参数
            ///操作员无修改权限时 是否允许对药品信息查询浏览
            //this.ckQueryNoPriv.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Query_No_EditPriv, true, true);
            //this.ckQueryNoPriv.Tag = PharmacyConstant.Query_No_EditPriv;

            /////操作员无修改权限时 是否允许对药品信息导出/打印
            //this.ckExportNoPriv.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Export_No_EditPriv, true, true);
            //this.ckExportNoPriv.Tag = PharmacyConstant.Export_No_EditPriv;

            ///药品信息维护时  对于包装数量允许输入的最大位数
            this.nUDPackLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_PackQty_Digit, true, 4);
            this.nUDPackLength.Tag = PharmacyConstant.Max_PackQty_Digit;

            ///药品信息维护时  对于基本剂量允许输入的最大位数
            this.nUDBaseDoseLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_BaseDose_Digit, true, 10);
            this.nUDBaseDoseLength.Tag = PharmacyConstant.Max_BaseDose_Digit;

            ///药品信息维护时  对于价格允许输入的最大位数
            this.nUDPriceLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_Price_Digit, true, 12);
            this.nUDPriceLength.Tag = PharmacyConstant.Max_Price_Digit;

            ///商品名自定义码允许输入的最大位数
            this.nUDNameCodeLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_NameCustomeCode_Digit, true, 16);
            this.nUDNameCodeLength.Tag = PharmacyConstant.Max_NameCustomeCode_Digit;

            ///其他自定义码允许输入的最大位数
            this.nUDCodeLength.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_CustomeCode_Digit, true, 16);
            this.nUDCodeLength.Tag = PharmacyConstant.Max_CustomeCode_Digit;

            ///是否允许通用名维护获得Tab顺序
            this.ckRegularTab.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Have_Regular_Tab, true, false);
            this.ckRegularTab.Tag = PharmacyConstant.Have_Regular_Tab;

            ///是否允许英文名维护获得Tab顺序
            this.ckEnglishTab.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Have_English_Tab, true, false);
            this.ckEnglishTab.Tag = PharmacyConstant.Have_English_Tab;

            ///是否允许国标/国家编码维护获得Tab顺序
            this.ckCodeTab.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Have_Code_Tab, true, false);
            this.ckCodeTab.Tag = PharmacyConstant.Have_Code_Tab;

            //该参数作废 协定处方只按管理库存处理
            /////协定处方是否管理库存 如果不管理库存 则收费时拆分明细 否则不进行拆分
            //this.ckNostrumManageStore.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Nostrum_Manage_Store, true, true);
            //this.ckNostrumManageStore.Tag = PharmacyConstant.Nostrum_Manage_Store;

            #endregion

            #region 库存管理参数

            ///药品盘点是否按批号进行盘点
            this.ckCheckBatch.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Check_With_Batch, true, false);
            this.ckCheckBatch.Tag = PharmacyConstant.Check_With_Batch;

            ///历史盘点单获取时是否只取结存状态
            string historyState = this.ctrlIntegrate.GetControlParam<string>(PharmacyConstant.Check_History_State, true, "1");
            if (historyState == "1")
            {
                this.cmbCheckHistoryState.Text = "结存盘点单";
            }
            else
            {
                this.cmbCheckHistoryState.Text = "解封盘点单";
            }
            this.cmbCheckHistoryState.Tag = PharmacyConstant.Check_History_State;

            ///库存货位号允许输入最大位数
            this.nUDMaxPlace.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Max_Place_Code, true, 12);
            this.nUDMaxPlace.Tag = PharmacyConstant.Max_Place_Code;

            ///是否启用有效期警示
            this.ckValidEnable.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Valid_Warn_Enabled, true, false);
            this.ckValidEnable.Tag = PharmacyConstant.Valid_Warn_Enabled;

            ///有效期最大警示天数
            this.nUDWarnDays.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Valid_Warn_Days, true, 60);
            this.nUDWarnDays.Tag = PharmacyConstant.Valid_Warn_Days;

            ///有效期警示颜色
            this.btValidColor.BackColor = Color.FromArgb(this.ctrlIntegrate.GetControlParam<int>(PharmacyConstant.Valid_Warn_Color, true, System.Drawing.Color.Red.ToArgb()));
            this.btValidColor.Tag = PharmacyConstant.Valid_Warn_Color;

            ///有效期采用实时获取获取方式
            this.ckValidRealTime.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Valid_Warn_SourceRealTime,true,true);
            this.ckValidRealTime.Tag = PharmacyConstant.Valid_Warn_SourceRealTime;
            
            ///是否采用库存上下限报警
            this.ckStoreValid.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Store_Warn_Enabled,true,false);
            this.ckStoreValid.Tag = PharmacyConstant.Store_Warn_Enabled;

            ///报警时是否采用弹出信息方式 不使用字体颜色警示
            this.ckWarnMsg.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Store_Warn_Msg,true,false);
            this.ckWarnMsg.Tag = PharmacyConstant.Store_Warn_Msg;

            ///报警字体颜色警示
            this.btStoreColor.BackColor = Color.FromArgb(this.ctrlIntegrate.GetControlParam<int>(PharmacyConstant.Store_Warn_Color, true, System.Drawing.Color.Blue.ToArgb()));
            this.btStoreColor.Tag = PharmacyConstant.Store_Warn_Color;

            #endregion

            #region 入出库管理参数

            ///自动生成计划时 计算日均出库量，日消耗 统计默认天数
            this.nUDExpandDays.Value = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Plan_Expand_Days, true, 30);
            this.nUDExpandDays.Tag = PharmacyConstant.Plan_Expand_Days;

            ///列表选择控件是否显示行标题
            this.ckPlanRowHeader.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Plan_Show_RowHeader, true, true);
            this.ckPlanRowHeader.Tag = PharmacyConstant.Plan_Show_RowHeader;

            ///是否允许通过行索引确认选择数据
            this.ckNumSelectRow.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Plan_Num_SelectRow, true, false);
            this.ckNumSelectRow.Tag = PharmacyConstant.Plan_Num_SelectRow;

            ///是否对计划量是否为零进行判断
            this.ckPlanZeroValid.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Plan_NumZero_Valid, true, true);
            this.ckPlanZeroValid.Tag = PharmacyConstant.Plan_NumZero_Valid;

            ///采购是否需要审核后生效
            this.ckStockNeedApprove.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Stock_Need_Approve, true, true);
            this.ckStockNeedApprove.Tag = PharmacyConstant.Stock_Need_Approve;

            ///出库时是否可以选择批号
            ///{DE934736-B2C2-44a4-A218-2DC38E1620BA}
            this.ckOutChooseBatch.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Out_Choose_BatchNO, true, false);
            this.ckOutChooseBatch.Tag = PharmacyConstant.Out_Choose_BatchNO;

            ///采购审核时 是否允许修改相应的计划信息
            this.ckEditInplan.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Stock_Edit_InPlan, true, false);
            this.ckEditInplan.Tag = PharmacyConstant.Stock_Edit_InPlan;

            ///采购计划/审核时 是否允许修改计划购入价
            this.ckEditPrice.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Stock_Edit_Price, true, false);
            this.ckEditPrice.Tag = PharmacyConstant.Stock_Edit_Price;

            ///采购指定时是否使用字典信息内默认的供货公司
            this.ckStockUseDefaultData.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Stock_Use_DefaultData, true, true);
            this.ckStockUseDefaultData.Tag = PharmacyConstant.Stock_Use_DefaultData;

            ///药品入库是否需要审核 原参数 500002
            this.ckInputNeedApprove.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.In_Need_Approve, true, true);
            this.ckInputNeedApprove.Tag = PharmacyConstant.In_Need_Approve;

            ///退出时是否保存上一次操作权限类型
            this.ckInSavePriv.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.In_Save_Priv, true, true);
            this.ckInSavePriv.Tag = PharmacyConstant.In_Save_Priv;

            ///药品核准入库时是否更新药品字典信息购入价
            this.ckInEditPrice.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.In_EditPrice_WhenApprove, true, false);
            this.ckInEditPrice.Tag = PharmacyConstant.In_EditPrice_WhenApprove;

            ///价让出库时是否使用批发价
            this.ckTransferOutUseWholePrice.Checked = this.ctrlIntegrate.GetControlParam<bool>(PharmacyConstant.Out_Transfer_UseWholePrice, true, false);
            this.ckTransferOutUseWholePrice.Tag = PharmacyConstant.Out_Transfer_UseWholePrice;

            ///价让出库时是否使用批发价
            this.txtTransferOutRate.Text = this.ctrlIntegrate.GetControlParam<decimal>(PharmacyConstant.Out_Transfer_DefaultRate, true, 1.05M).ToString();
            this.txtTransferOutRate.Tag = PharmacyConstant.Out_Transfer_DefaultRate;

            ///药房/药库通用查询大类
            this.txtCommonQuery.Text = this.ctrlIntegrate.GetControlParam<string>(PharmacyConstant.Query_Commo_Type, true, "入库|In,出库|Out,盘点|Check,调价|Adjust");
            this.txtCommonQuery.Tag = PharmacyConstant.Query_Commo_Type;

            ///药库查询大类
            this.txtPIQuery.Text = this.ctrlIntegrate.GetControlParam<string>(PharmacyConstant.Query_PI_Type, true, "入库计划|InPlan,采购|Stock,台帐|Record");
            this.txtPIQuery.Tag = PharmacyConstant.Query_PI_Type;

            #endregion

            #region 本地参数

            string strErr = "";

            ArrayList alValue = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ClinicDrug", "PrintList", out strErr);
            if (alValue == null || alValue.Count == 0)
            {
                this.ckPrintLabel.Checked = true;
            }
            else
            {
                this.ckPrintLabel.Checked = false;
            }
            this.ckPrintLabel.Tag = "LocalParam";

            ArrayList alTCode = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("ClinicDrug", "TerminalCode", out strErr);
            if (alTCode == null || alTCode.Count == 0)
            {
                this.txtDefaultTCode.Text = "";
            }
            else
            {
                this.txtDefaultTCode.Text = alTCode[0] as string;
            }
            this.txtDefaultTCode.Tag = "LocalParam";
            #endregion

            return 1;
        }

        public bool IsModify
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsShowOwnButtons
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            List<Neusoft.HISFC.Models.Base.Controler> alCtrlList = this.GetControlerList();
            if (alCtrlList == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();

                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Neusoft.FrameWork.Management.Language.Msg("正在保存 请稍候..."));
            Application.DoEvents();

            this.managerIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            foreach (Neusoft.HISFC.Models.Base.Controler c in alCtrlList)
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
                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            MessageBox.Show("更新控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);

                            return -1;
                        }
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        MessageBox.Show("插入控制参数[" + c.Name + "]失败! 控制参数值:" + c.ID + "\n错误信息:" + this.managerIntegrate.Err);

                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            MessageBox.Show("保存成功!");

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (this.neuTabControl1.TabPages.Contains(this.tabPage5))
            {
                this.neuTabControl1.TabPages.Remove(this.tabPage5);
            }
            base.OnLoad(e);
        }

        private void btnValidColorSet_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.btValidColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnStoreColorSet_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.btStoreColor.BackColor = colorDialog1.Color;
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();

            return base.OnSave(sender, neuObject);
        }

        private void ckItemSpeFlag1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtItemSpeFlag1.Enabled = this.ckItemSpeFlag1.Checked;
        }

        private void ckItemSpeFlag2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtItemSpeFlag2.Enabled = this.ckItemSpeFlag2.Checked;
        }

        private void ckItemSpeFlag3_CheckedChanged(object sender, EventArgs e)
        {
            this.txtItemSpeFlag3.Enabled = this.ckItemSpeFlag3.Checked;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 摆药科室汇总显示控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public partial class ucDrugMessage : ucDrugBase,Neusoft.HISFC.BizProcess.Interface.Pharmacy.IInpatientDrug
    {
        public ucDrugMessage()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                try
                {
                    this.Init();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败! " + ex.Message);
                }
            }
        }

        #region 域变量

        /// <summary>
        /// 添加数据时 是否自动选中
        /// </summary>
        private bool autoCheck = false;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 药品库存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药房操作管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugstoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();

        #endregion

        #region 属性

        /// <summary>
        /// 添加数据时 是否自动选中
        /// </summary>
        [Description("添加新数据时 是否自动选中该行"),Category("设置"),DefaultValue(false)]
        public bool AutoCheck
        {
            get
            {
                return this.autoCheck;
            }
            set
            {
                this.autoCheck = value;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
            if (deptHelper == null)
            {
                Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
                ArrayList al = deptManager.GetDeptmentAll();
                if (al == null)
                {
                    MessageBox.Show(Language.Msg("获取科室列表发生错误") + deptManager.Err);
                    return;
                }

                this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper();
            }

            this.InitControlParam();
        }

        /// <summary>
        /// 控制参数初始化
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            this.AutoCheck = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Auto_Check, true, false);
        }

        /// <summary>
        /// 显示摆药通知信息
        /// </summary>
        /// <param name="drugMessage">摆药通知信心</param>
        private void AddDataToFp(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage)
        {
            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.Rows.Count, 1);
            
            int iIndex = this.neuSpread1_Sheet1.Rows.Count - 1;

            if (drugMessage.ApplyDept.Name == "")
                drugMessage.ApplyDept.Name = this.deptHelper.GetName(drugMessage.ApplyDept.ID);

            if (this.autoCheck)
                this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColCheck].Value = true;
            this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColPrintType].Value = "打印";
            this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColSendDept].Value = drugMessage.ApplyDept.Name;
            this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColBillType].Value = drugMessage.DrugBillClass.Name;
            this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColSendTime].Value = drugMessage.SendTime.ToString();
            this.neuSpread1_Sheet1.Cells[iIndex, (int)ColumnSet.ColSendOper].Value = drugMessage.Name;
            this.neuSpread1_Sheet1.Rows[iIndex].Tag = drugMessage;
        }

        /// <summary>
        /// 出库申请信息显示
        /// </summary>
        /// <param name="deptFirst">列表显示时 是否按照科室显示</param>
        /// <param name="arrayDrugMessage">摆药通知信息</param>
        /// <returns>加载成功返回1 发生错误返回-1</returns>
        public int ShowData(bool deptFirst,ArrayList arrayDrugMessage)
        {
            //清空表格中的数据
            this.Clear();
            try
            {
                string privDeptCode = "";
                string privBillCode = "";               
                foreach (Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage in arrayDrugMessage)
                {
                    if (deptFirst)              //按照科室显示
                    {
                        if (drugMessage.DrugBillClass.ID != privBillCode)
                        {
                            this.AddDataToFp(drugMessage);
                            privBillCode = drugMessage.DrugBillClass.ID;
                        }
                    }
                    else                       //按照单据显示
                    {
                        if (drugMessage.ApplyDept.ID != privDeptCode)
                        {
                            this.AddDataToFp(drugMessage);
                            privDeptCode = drugMessage.ApplyDept.ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg("加载申请数据信息显示时发生错误") + ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 获取当前用户选中的数据
        /// </summary>
        private ArrayList GetCheckData()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCheck].Value))
                    al.Add(this.neuSpread1_Sheet1.Rows[i].Tag);
            }

            return al;
        }

        /// <summary>
        /// 获取操作员的 选择打印/预览
        /// </summary>
        /// <returns>需要预览返回True 直接打印返回False</returns>
        private bool IsSelectPreview(int iIndex)
        {
            if (this.neuSpread1_Sheet1.Cells[iIndex, 1].Text == "打印")
                return false;
            else
                return true;
        }

        /// <summary>
        /// 打印/预览
        /// </summary>
        /// <param name="isPreview">是否预览</param>
        private void Print(bool isPreview)
        {
            ArrayList alCheckData = this.GetCheckData();
            int i = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugMessage message in alCheckData)
            {
                ArrayList al = this.itemManager.QueryApplyOutList(message);
                if (al == null)
                {
                    MessageBox.Show(Language.Msg("根据摆药通知信息获取摆药申请明细信息发生错误 ") + this.itemManager.Err);
                    return;
                }

                Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass = this.drugstoreManager.GetDrugBillClass(message.DrugBillClass.ID);
                drugBillClass.Memo = message.DrugBillClass.Memo;//摆药单号

                Function.Print(al,drugBillClass,false, this.IsPrintLabel, this.IsSelectPreview(i));
                i++;
            }
        }

        #region IInpatientDrug 成员

        /// <summary>
        /// 保存前
        /// </summary>
        public event EventHandler BeginSaveEvent;

        /// <summary>
        /// 保存后
        /// </summary>
        public event EventHandler EndSaveEvent;

        /// <summary>
        /// 选择全部数据
        /// </summary>
        public void CheckAll()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Value = true;
            }
        }

        /// <summary>
        /// 不选择任何数据
        /// </summary>
        public void CheckNone()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, 0].Value = false;
            }
        }

        /// <summary>
        /// 清空表格中的数据
        /// </summary>
        public void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            //清空摆药单显示
            Function.IDrugPrint.AddAllData(new ArrayList());
        }

        /// <summary>
        /// 摆药保存
        /// </summary>
        /// <param name="drugMessage">摆药通知信息</param>
        public int Save(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage)
        {
            if (this.neuSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show(Language.Msg("没有可以核准的数据。"));
                return -1;
            }

            if (this.BeginSaveEvent != null)
                this.BeginSaveEvent(drugMessage, null);

            ArrayList alCheckData = this.GetCheckData();
            if (alCheckData.Count <= 0)
            {
                MessageBox.Show(Language.Msg("请选择要核准的数据。"));
                return -1;
            }
            //提示是否摆药 {152EF737-99B9-410f-BE97-B11C02B6F330} wbo 2010-09-22
            if (MessageBox.Show("是否确定摆药？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return -1;
            }
            //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在摆药，请稍后... ...");
            Application.DoEvents();
            int iIndex = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.DrugMessage message in alCheckData)
            {
                #region 对选中的申请数据进行保存

                message.SendFlag = 1;                     //摆药通知中的数据全部被核准SendFlag=1，更新摆药通知信息。
                message.SendType = drugMessage.SendType; //处理此摆药通知中的摆药申请数据时，取摆药台的发送类型。

                //检索科室摆药申请明细数据
                ArrayList al = this.itemManager.QueryApplyOutList(message);
                if (al == null)
                {
                    //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show(Language.Msg("根据摆药通知信息获取摆药申请明细信息发生错误 ") + this.itemManager.Err);
                    return -1;
                }
                //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在摆药，请稍后... ...");
                if (message.DrugBillClass.ID == "R")
                {
                    if (DrugStore.Function.DrugReturnConfirm(al, message, this.ArkDept, this.ApproveDept) != 1)
                    {
                        //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return -1;
                    }
                }
                else
                {
                    if (DrugStore.Function.DrugConfirm(al, message, this.ArkDept, this.ApproveDept) != 1)
                    {
                        //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        return -1;
                    }
                }

                //提示打印进度 {C9ADA757-AA2D-4674-8BEE-F647EE683A59} wbo 2010-09-22
                //Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在打印... ...");
                Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass = this.drugstoreManager.GetDrugBillClass(message.DrugBillClass.ID);

                //保存摆药单号
                drugBillClass.Memo = message.DrugBillClass.Memo;//摆药单号
                drugBillClass.DrugBillNO = message.DrugBillClass.Memo;

                Function.Print(al,drugBillClass,this.IsAutoPrint,this.IsPrintLabel,this.IsSelectPreview(iIndex));
                iIndex++;

                #endregion
            }
            if (this.EndSaveEvent != null)
                this.EndSaveEvent(drugMessage, null);

            //提示打印进度 {C9ADA757-AA2D-4674-8BEE-F647EE683A59} wbo 2010-09-22
            //Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //MessageBox.Show("打印完毕！");

            return 1;
        }

        /// <summary>
        /// 加载数据显示
        /// </summary>
        /// <param name="alApplyOut">出库申请信心</param>
        public void ShowData(ArrayList alApplyOut)
        {
            this.ShowData(this.IsDeptFirst, alApplyOut);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            this.Print(false);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void Preview()
        {
            this.Print(true);
        }

        #endregion

        /// <summary>
        /// 列设置
        /// </summary>
        public enum ColumnSet
        {
            /// <summary>
            /// 选中
            /// </summary>
            ColCheck = 0,
            /// <summary>
            /// 打印类型
            /// </summary>
            ColPrintType = 1,
            /// <summary>
            /// 发送科室
            /// </summary>
            ColSendDept,
            /// <summary>
            /// 摆药单类型
            /// </summary>
            ColBillType,
            /// <summary>
            /// 发送时间
            /// </summary>
            ColSendTime,
            /// <summary>
            /// 发送人
            /// </summary>
            ColSendOper
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.DrugStore.Compound
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 配置退库退费]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-12]<br></br>
    /// <说明>
    ///     1、
    /// </说明>
    /// </summary>
    public partial class ucCompoundBack : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCompoundBack()
        {
            InitializeComponent();
        }

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="NeuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object NeuObject, object param)
        {
            //增加工具栏
            this.toolBarService.AddToolButton("全选", "选择全部申请", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            this.toolBarService.AddToolButton("全不选", "取消全部申请选择", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q取消, true, false, null);

            return this.toolBarService;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            return this.SaveBack();
        }

        /// <summary>
        /// 工具栏按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "全选":
                    this.Check(true);
                    break;
                case "全不选":
                    this.Check(false);
                    break;
            }
        }

        #endregion

        /// <summary>
        /// 数据清屏
        /// </summary>
        protected void Clear()
        {
            this.fpApply_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 根据批次流水号检索
        /// </summary>
        /// <param name="compoundGroup">批次流水号</param>
        protected void QueryCompound(string compoundGroup)
        {
            if (compoundGroup == null || compoundGroup == "")
            {
                return;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            ArrayList alList = itemManager.QueryCompoundApplyOut(compoundGroup);
            if (alList == null)
            {
                MessageBox.Show(Language.Msg("根据批次流水号获取配置数据发生错误") + itemManager.Err);
                return;
            }

            this.AddDataToFp(alList);
        }

        /// <summary>
        /// 向Fp内加入数据
        /// </summary>
        /// <param name="alApply">摆药申请信息</param>
        /// <returns></returns>
        protected int AddDataToFp(ArrayList alApply)
        {
            this.fpApply_Sheet1.Rows.Count = 0;

            int i = 0;

            Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in alApply)
            {
                if (info.State == "0")
                {
                    continue;
                }
                this.fpApply_Sheet1.Rows.Add(i, 1);

                if (info.UseTime != System.DateTime.MinValue)
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUseTime].Text = info.UseTime.ToString();
                }

                if (info.User01.Length > 4)
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColBedName].Text = "[" + info.User01.Substring(4) + "]" + info.User02;
                }
                else
                {
                    this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColBedName].Text = "[" + info.User01 + "]" + info.User02;
                }

                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value = true;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColTradeNameSpecs].Text = info.Item.Name + "[" + info.Item.Specs + "]";
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColRetailPrice].Text = info.Item.PriceCollection.RetailPrice.ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoseOnce].Text = info.DoseOnce.ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoseUnit].Text = info.Item.DoseUnit;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColQty].Text = (info.Operation.ApplyQty * info.Days).ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUnit].Text = info.Item.MinUnit;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColFrequency].Text = info.Frequency.ID;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColUsage].Text = info.Usage.Name;

                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColDoctor].Text = info.RecipeInfo.ID;
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColApplyTime].Text = info.Operation.ApplyOper.OperTime.ToString();
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColCompoundGroup].Text = info.CompoundGroup;
                this.fpApply_Sheet1.Rows[i].Tag = info;
            }

            return 1;
        }

        /// <summary>
        /// 选中/不选中
        /// </summary>
        /// <param name="isCheck"></param>
        /// <returns></returns>
        public int Check(bool isCheck)
        {
            for (int i = 0; i < this.fpApply_Sheet1.Rows.Count; i++)
            {
                this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value = isCheck;
            }

            return 1;
        }

        /// <summary>
        /// 获取所有当前选中的数据
        /// </summary>
        /// <returns></returns>
        protected ArrayList GetCheckData()
        {
            ArrayList al = new ArrayList();

            for (int i = 0; i < this.fpApply_Sheet1.Rows.Count; i++)
            {
                if (NConvert.ToBoolean(this.fpApply_Sheet1.Cells[i, (int)ColumnSet.ColSelect].Value))
                {
                    al.Add(this.fpApply_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut);
                }
            }

            return al;
        }

        /// <summary>
        /// 退费保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int SaveBack()
        {
            ArrayList alCheckData = this.GetCheckData();
            if (alCheckData.Count == 0)
            {
                return 0;
            }

              Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

             Neusoft.FrameWork.Models.NeuObject approveDept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;

            Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
            if (pharmacyIntegrate.CompoundBackFee(alCheckData, approveDept) != 1)
            {
                MessageBox.Show(Language.Msg(pharmacyIntegrate.Err) + " 该标签可能已完成退费！");
                return -1;
            }

            MessageBox.Show(Language.Msg("保存成功"));

            this.Clear();

            return 1;
        }
   
        private void txtCompoundGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Clear();

                this.QueryCompound(this.txtCompoundGroup.Text);
            }
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 床号 姓名
            /// </summary>
            ColBedName,
            /// <summary>
            /// 选中
            /// </summary>
            ColSelect,
            /// <summary>
            /// 药品名称 规格
            /// </summary>
            ColTradeNameSpecs,
            /// <summary>
            /// 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 用量
            /// </summary>
            ColDoseOnce,
            /// <summary>
            /// 剂量单位
            /// </summary>
            ColDoseUnit,
            /// <summary>
            /// 总量
            /// </summary>
            ColQty,
            /// <summary>
            /// 单位
            /// </summary>
            ColUnit,
            /// <summary>
            /// 频次
            /// </summary>
            ColFrequency,
            /// <summary>
            /// 用法
            /// </summary>
            ColUsage,
            /// <summary>
            /// 用药时间
            /// </summary>
            ColUseTime,
            /// <summary>
            /// 开方医生
            /// </summary>
            ColDoctor,
            /// <summary>
            /// 申请时间
            /// </summary>
            ColApplyTime,
            /// <summary>
            /// 批次号
            /// </summary>
            ColCompoundGroup
        }      
    }
}

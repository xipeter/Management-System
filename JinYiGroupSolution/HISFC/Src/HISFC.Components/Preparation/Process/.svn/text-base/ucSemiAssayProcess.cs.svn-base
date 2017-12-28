using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Preparation.Process
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 半成品检验流程录入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucSemiAssayProcess : Neusoft.HISFC.Components.Preparation.Process.ucProcessBase
    {
        public ucSemiAssayProcess()
        {
            InitializeComponent();

            this.Init();
        }

        /// <summary>
        /// 人员列表
        /// </summary>
        System.Collections.ArrayList alStaticEmployee = null;

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            #region 哈希表数据初始化

            this.cmbAssayResult.Tag = Function.NoneData;
            this.hsProcessControl.Add("AssayResult", this.cmbAssayResult);

            this.hsProcessControl.Add("AssayQty", this.numAssayNum);
            this.hsProcessControl.Add("ApplyOper", this.cmbApplyOper);
            this.hsProcessControl.Add("ApplyDate", this.dtpApplyDate);
            this.hsProcessControl.Add("AssayOper", this.cmbAssayOper);
            this.hsProcessControl.Add("AssayDate", this.dtpAssayDate);

            Neusoft.HISFC.Models.Preparation.Process pItem = new Neusoft.HISFC.Models.Preparation.Process();
            pItem.ProcessItem.ID = "AssayResult";
            pItem.ProcessItem.Name = "检验合格";
            this.hsProcessItem.Add(this.cmbAssayResult.Name, pItem.Clone());

            pItem.ProcessItem.ID = "AssayQty";
            pItem.ProcessItem.Name = "送检量";
            this.hsProcessItem.Add(this.numAssayNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "ApplyOper";
            pItem.ProcessItem.Name = "送检人";
            this.hsProcessItem.Add(this.cmbApplyOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "ApplyDate";
            pItem.ProcessItem.Name = "送检日期";
            this.hsProcessItem.Add(this.dtpApplyDate.Name, pItem.Clone());

            pItem.ProcessItem.ID = "AssayOper";
            pItem.ProcessItem.Name = "检验人";
            this.hsProcessItem.Add(this.cmbAssayOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "AssayDate";
            pItem.ProcessItem.Name = "检验日期";
            this.hsProcessItem.Add(this.dtpAssayDate.Name, pItem.Clone());

            #endregion

            if (alStaticEmployee == null)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                alStaticEmployee = managerIntegrate.QueryEmployeeAll();
                if (alStaticEmployee == null)
                {
                    MessageBox.Show("加载人员列表发生错误" + managerIntegrate.Err);
                    return;
                }
            }

            this.cmbApplyOper.AddItems(alStaticEmployee);
            this.cmbAssayOper.AddItems(alStaticEmployee);
        }

        #endregion

        /// <summary>
        /// 加载处方内容信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int QueryPrescriptionData()
        {
            string drugCode = this.preparation.Drug.ID;

            this.fpSemiAssay_Sheet1.Rows.Count = 0;

            Neusoft.HISFC.BizLogic.Pharmacy.Preparation pprManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();
            List<Neusoft.HISFC.Models.Preparation.Prescription> al = pprManager.QueryDrugPrescription(drugCode, Neusoft.HISFC.Models.Preparation.EnumMaterialType.Material);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取当前选择成品的配制处方信息出错\n" + drugCode));
                return -1;
            }
           
            foreach (Neusoft.HISFC.Models.Preparation.Prescription info in al)
            {
                int i = this.fpSemiAssay_Sheet1.Rows.Count;

                this.fpSemiAssay_Sheet1.Rows.Add(i, 1);
                this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColItemID].Text = info.Material.ID;
                this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColItemName].Text = info.Material.Name;
                if (this.ProcessList != null)
                {
                    foreach (Neusoft.HISFC.Models.Preparation.Process p in this.ProcessList)
                    {
                        if (p.ProcessItem.ID == info.Material.ID)
                        {
                            this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColDes].Text = p.ResultStr;
                            this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColContent].Text = p.Extend;
                            this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColResult].Text = p.ResultQty.ToString();
                        }
                    }
                }
                else
                {
                    this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColDes].Text = "";
                    this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColContent].Text = "0";
                    this.fpSemiAssay_Sheet1.Cells[i, (int)ReportColumnEnum.ColResult].Text = "0";
                }

                this.fpSemiAssay_Sheet1.Rows[i].Tag = info.Material;
            }

            return 1;
        }

        /// <summary>
        /// 制剂半成品信息设置
        /// </summary>
        /// <param name="preparation"></param>
        /// <returns></returns>
        public new int SetPreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            this.lbPreparationInfo.Text = string.Format(this.strPreparation, preparation.Drug.Name, preparation.Drug.Specs, preparation.BatchNO, preparation.PlanQty, preparation.Unit);

            this.numAssayNum.Text = preparation.AssayQty.ToString();

            base.SetPreparation(preparation);

            return this.QueryPrescriptionData();
        }

        public override int PrintProcess()
        {
            return base.PrintProcess();
        }

        /// <summary>
        /// 生产工艺流程保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public override int SaveProcess()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Pharmacy.Preparation pprManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();

            DateTime sysTime = pprManager.GetDateTimeFromSysDateTime();

            for (int i = 0; i < this.fpSemiAssay_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Process p = this.GetProcessInstance(i);

                p.Oper.OperTime = sysTime;
                p.Oper.ID = pprManager.Operator.ID;

                if (pprManager.SetProcess(p) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存制剂工艺流程信息失败" + pprManager.Err);
                }
            }

            this.preparation.AssayQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.numAssayNum.Text);

            if (base.SaveProcess(false) >= 1)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                MessageBox.Show("工艺流程执行信息保存成功");

                this.PrintProcess();
            }

            return 1;
        }

        /// <summary>
        /// 根据行索引获取Fp信息
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <returns>成功返回工艺流程信息 失败返回null</returns>
        protected Neusoft.HISFC.Models.Preparation.Process GetProcessInstance(int rowIndex)
        {
            Neusoft.HISFC.Models.Preparation.Process process = new Neusoft.HISFC.Models.Preparation.Process();

            process.Preparation = this.preparation;
            process.ProcessItem.ID = this.fpSemiAssay_Sheet1.Cells[rowIndex, (int)ReportColumnEnum.ColItemID].Text;
            process.ProcessItem.Name = this.fpSemiAssay_Sheet1.Cells[rowIndex, (int)ReportColumnEnum.ColItemName].Text;
            process.ResultQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSemiAssay_Sheet1.Cells[rowIndex, (int)ReportColumnEnum.ColResult].Text);      //标示量
            process.Extend = this.fpSemiAssay_Sheet1.Cells[rowIndex, (int)ReportColumnEnum.ColContent].Text;        //含量
            process.ResultStr = this.fpSemiAssay_Sheet1.Cells[rowIndex, (int)ReportColumnEnum.ColDes].Text;         //鉴别
          
            return process;
        }

        #region 列枚举

        protected enum ReportColumnEnum
        {
            /// <summary>
            /// 处方内容
            /// </summary>
            ColItemName,
            /// <summary>
            /// 鉴别
            /// </summary>
            ColDes,
            /// <summary>
            /// 含量
            /// </summary>
            ColContent,
            /// <summary>
            /// 标示量
            /// </summary>
            ColResult,
            /// <summary>
            /// 处方编码
            /// </summary>
            ColItemID
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Preparation.Process
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 分装工艺流程录入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-12]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucDivisionProcess : ucProcessBase
    {
        public ucDivisionProcess()
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

            this.cmbWhole.Tag = Function.NoneData;
            this.hsProcessControl.Add("EquipmentGood", this.cmbWhole);
            this.cmbClean.Tag = Function.NoneData;
            this.hsProcessControl.Add("EquipmentClean", this.cmbClean);

            this.hsProcessControl.Add("Regulation", this.txtRegulation);
            this.hsProcessControl.Add("Exucte", this.txtExucte);
            this.hsProcessControl.Add("Quantity", this.txtQuantity);
            this.hsProcessControl.Add("DivisionOper", this.cmbDivOper);
            this.hsProcessControl.Add("DivisionDate", this.dtpDivDate);
            this.hsProcessControl.Add("InceptOper", this.cmbInceptOper);
            this.hsProcessControl.Add("DivisionQty", this.txtDivNum);
            this.hsProcessControl.Add("WasteQty", this.txtWasteNum);
            this.hsProcessControl.Add("AssayQty", this.txtAssayNum);
            this.hsProcessControl.Add("DivParam", this.txtParam);

            Neusoft.HISFC.Models.Preparation.Process pItem = new Neusoft.HISFC.Models.Preparation.Process();

            pItem.ProcessItem.ID = "DivisionQty";
            pItem.ProcessItem.Name = "半成品分装量";
            this.hsProcessItem.Add(this.txtDivNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "WasteQty";
            pItem.ProcessItem.Name = "废品量";
            this.hsProcessItem.Add(this.txtWasteNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "AssayQty";
            pItem.ProcessItem.Name = "送检量";
            this.hsProcessItem.Add(this.txtAssayNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "DivParam";
            pItem.ProcessItem.Name = "物料平衡";
            this.hsProcessItem.Add(this.txtParam.Name, pItem.Clone());

            pItem.ProcessItem.ID = "EquipmentGood";
            pItem.ProcessItem.Name = "设备是否完好";
            this.hsProcessItem.Add(this.cmbWhole.Name, pItem.Clone());

            pItem.ProcessItem.ID = "EquipmentClean";
            pItem.ProcessItem.Name = "设备是否清洁";
            this.hsProcessItem.Add(this.cmbClean.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Regulation";
            pItem.ProcessItem.Name = "规程执行";
            this.hsProcessItem.Add(this.txtRegulation.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Quantity";
            pItem.ProcessItem.Name = "质量情况";
            this.hsProcessItem.Add(this.txtQuantity.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Exucte";
            pItem.ProcessItem.Name = "工艺执行";
            this.hsProcessItem.Add(this.txtExucte.Name, pItem.Clone());

            pItem.ProcessItem.ID = "DivisionOper";
            pItem.ProcessItem.Name = "分装员";
            this.hsProcessItem.Add(this.cmbDivOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "DivisionDate";
            pItem.ProcessItem.Name = "分装日期";
            this.hsProcessItem.Add(this.dtpDivDate.Name, pItem.Clone());

            pItem.ProcessItem.ID = "InceptOper";
            pItem.ProcessItem.Name = "接收员";
            this.hsProcessItem.Add(this.cmbInceptOper.Name, pItem.Clone());

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

            this.cmbDivOper.AddItems(alStaticEmployee);
            this.cmbInceptOper.AddItems(alStaticEmployee);
        }

        #endregion

        /// <summary>
        /// 制剂配置信息设置
        /// </summary>
        /// <param name="preparation"></param>
        /// <returns></returns>
        public new int SetPreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            this.lbPreparationInfo.Text = string.Format(this.strPreparation, preparation.Drug.Name, preparation.Drug.Specs, preparation.BatchNO, preparation.PlanQty, preparation.Unit);

            this.txtAssayNum.Text = preparation.AssayQty.ToString();
            this.txtDivNum.Text = preparation.ConfectQty.ToString();

            return base.SetPreparation(preparation);
        }

        private void txtAssayNum_Leave(object sender, EventArgs e)
        {
            decimal deivQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDivNum.Text);
            decimal wastQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWasteNum.Text);
            decimal assayQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtAssayNum.Text);
            
            decimal param = (decimal)System.Math.Round((double)((deivQty + wastQty + assayQty) / this.preparation.PlanQty * 100), 2);

            this.txtParam.Text = string.Format("{0}", param.ToString());
        }
    }
}

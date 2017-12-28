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
    /// [功能描述: 外包装工艺流程录入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-03]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucPackageProcess : Neusoft.HISFC.Components.Preparation.Process.ucProcessBase
    {
        public ucPackageProcess()
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

            this.cmbClear.Tag = Function.NoneData;
            this.hsProcessControl.Add("Clear", this.cmbClear);
            this.cmbClean.Tag = Function.NoneData;
            this.hsProcessControl.Add("EquipmentClean", this.cmbClean);

            this.hsProcessControl.Add("Regulation", this.txtRegulation);
            this.hsProcessControl.Add("Exucte", this.txtExucte);
            this.hsProcessControl.Add("Quantity", this.txtQuantity);
            this.hsProcessControl.Add("PackageOper", this.cmbPackageOper);
            this.hsProcessControl.Add("PackageDate", this.dtpPackageDate);
            this.hsProcessControl.Add("InceptOper", this.cmbInceptOper);
            this.hsProcessControl.Add("PackageQty", this.txtPackageNum);
            this.hsProcessControl.Add("WasteQty", this.txtWasteNum);
            this.hsProcessControl.Add("FinParam", this.txtFinParam);

            Neusoft.HISFC.Models.Preparation.Process pItem = new Neusoft.HISFC.Models.Preparation.Process();

            pItem.ProcessItem.ID = "PackageQty";
            pItem.ProcessItem.Name = "成品量";
            this.hsProcessItem.Add(this.txtPackageNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "WasteQty";
            pItem.ProcessItem.Name = "废品量";
            this.hsProcessItem.Add(this.txtWasteNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "FinParam";
            pItem.ProcessItem.Name = "成品率";
            this.hsProcessItem.Add(this.txtFinParam.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Clear";
            pItem.ProcessItem.Name = "是否清场";
            this.hsProcessItem.Add(this.cmbClear.Name, pItem.Clone());

            pItem.ProcessItem.ID = "EquipmentClean";
            pItem.ProcessItem.Name = "是否清洁";
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

            pItem.ProcessItem.ID = "PackageOper";
            pItem.ProcessItem.Name = "包装员";
            this.hsProcessItem.Add(this.cmbPackageOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "PackageDate";
            pItem.ProcessItem.Name = "包装日期";
            this.hsProcessItem.Add(this.dtpPackageDate.Name, pItem.Clone());

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

            this.cmbPackageOper.AddItems(alStaticEmployee);
            this.cmbInceptOper.AddItems(alStaticEmployee);
        }

        #endregion

        /// <summary>
        /// 制剂外包装信息设置
        /// </summary>
        /// <param name="preparation"></param>
        /// <returns></returns>
        public new int SetPreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {
            this.lbPreparationInfo.Text = string.Format(this.strPreparation, preparation.Drug.Name, preparation.Drug.Specs, preparation.BatchNO, preparation.PlanQty, preparation.Unit);

            return base.SetPreparation(preparation);
        }

        private void txtPackageNum_Leave(object sender, EventArgs e)
        {
            decimal packQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtPackageNum.Text);
            decimal wastQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWasteNum.Text);

            decimal finalParam = System.Math.Round(packQty * this.preparation.Drug.PackQty / this.preparation.PlanQty * 100, 2);

            this.txtFinParam.Text = string.Format("{0}", finalParam.ToString());
        }
    }
}

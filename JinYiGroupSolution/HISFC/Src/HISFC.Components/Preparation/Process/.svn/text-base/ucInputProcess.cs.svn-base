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
    /// [功能描述: 入库工艺流程录入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-02]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucInputProcess : ucProcessBase
    {
        public ucInputProcess()
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

            this.cmbMaterial.Tag = Function.NoneData;
            this.hsProcessControl.Add("MaterialParam", this.cmbMaterial);
            this.cmbExceute.Tag = Function.NoneData;
            this.hsProcessControl.Add("ExceuteParam", this.cmbExceute);

            this.hsProcessControl.Add("CheckResult", this.txtCheckResult);
            this.hsProcessControl.Add("InputOper", this.cmbInputOper);
            this.hsProcessControl.Add("InputDate", this.dtpInputDate);
            this.hsProcessControl.Add("InceptOper", this.cmbInceptOper);
            this.hsProcessControl.Add("InputQty", this.txtInputNum);

            Neusoft.HISFC.Models.Preparation.Process pItem = new Neusoft.HISFC.Models.Preparation.Process();

            pItem.ProcessItem.ID = "InputQty";
            pItem.ProcessItem.Name = "入库量";
            this.hsProcessItem.Add(this.txtInputNum.Name, pItem.Clone());

            pItem.ProcessItem.ID = "MaterialParam";
            pItem.ProcessItem.Name = "物料平衡";
            this.hsProcessItem.Add(this.cmbMaterial.Name, pItem.Clone());

            pItem.ProcessItem.ID = "ExceuteParam";
            pItem.ProcessItem.Name = "生产质控";
            this.hsProcessItem.Add(this.cmbExceute.Name, pItem.Clone());

            pItem.ProcessItem.ID = "CheckResult";
            pItem.ProcessItem.Name = "审核意见";
            this.hsProcessItem.Add(this.txtCheckResult.Name, pItem.Clone());

            pItem.ProcessItem.ID = "InputOper";
            pItem.ProcessItem.Name = "入库员";
            this.hsProcessItem.Add(this.cmbInputOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "InputDate";
            pItem.ProcessItem.Name = "入库日期";
            this.hsProcessItem.Add(this.dtpInputDate.Name, pItem.Clone());

            pItem.ProcessItem.ID = "InceptOper";
            pItem.ProcessItem.Name = "审核员";
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

            this.cmbInputOper.AddItems(alStaticEmployee);
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
            this.lbUnit.Text = preparation.Drug.PackUnit;            

            base.SetPreparation(preparation);

            this.txtInputNum.Text = (preparation.InputQty / preparation.Drug.PackQty).ToString();

            return 1;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            this.preparation.InputQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtInputNum.Text) * preparation.Drug.PackQty;

            base.btnOK_Click(sender, e);
        }
    }
}

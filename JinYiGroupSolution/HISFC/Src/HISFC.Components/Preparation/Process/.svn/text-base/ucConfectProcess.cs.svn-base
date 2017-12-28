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
    /// [功能描述: 配置工艺流程录入]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-11]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucConfectProcess : Neusoft.HISFC.Components.Preparation.Process.ucProcessBase
    {
        public ucConfectProcess()
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
            this.cmbScale.Tag = Function.NoneData;
            this.hsProcessControl.Add("Scale", this.cmbScale);
            this.cmbStetlyard.Tag = Function.NoneData;
            this.hsProcessControl.Add("Stetlyard", this.cmbStetlyard);

            this.hsProcessControl.Add("Regulation", this.txtRegulation);
            this.hsProcessControl.Add("Exucte", this.txtExucte);
            this.hsProcessControl.Add("Quantity", this.txtQuantity);
            this.hsProcessControl.Add("ConfectOper", this.cmbConfectOper);
            this.hsProcessControl.Add("ConfectDate", this.dtpConfectDate);
            this.hsProcessControl.Add("CheckOper", this.cmbCheckOper);

            Neusoft.HISFC.Models.Preparation.Process pItem = new Neusoft.HISFC.Models.Preparation.Process();
            pItem.ProcessItem.ID = "EquipmentGood";
            pItem.ProcessItem.Name = "设备是否完好";
            this.hsProcessItem.Add(this.cmbWhole.Name, pItem.Clone());

            pItem.ProcessItem.ID = "EquipmentClean";
            pItem.ProcessItem.Name = "设备是否清洁";
            this.hsProcessItem.Add(this.cmbClean.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Scale";
            pItem.ProcessItem.Name = "药物天平";
            this.hsProcessItem.Add(this.cmbScale.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Stetlyard";
            pItem.ProcessItem.Name = "磅秤";
            this.hsProcessItem.Add(this.cmbStetlyard.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Regulation";
            pItem.ProcessItem.Name = "规程执行";
            this.hsProcessItem.Add(this.txtRegulation.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Quantity";
            pItem.ProcessItem.Name = "质量情况";
            this.hsProcessItem.Add(this.txtQuantity.Name, pItem.Clone());

            pItem.ProcessItem.ID = "Exucte";
            pItem.ProcessItem.Name = "工艺执行";
            this.hsProcessItem.Add(this.txtExucte.Name, pItem.Clone());

            pItem.ProcessItem.ID = "ConfectOper";
            pItem.ProcessItem.Name = "配置员";
            this.hsProcessItem.Add(this.cmbConfectOper.Name, pItem.Clone());

            pItem.ProcessItem.ID = "ConfectDate";
            pItem.ProcessItem.Name = "配置日期";
            this.hsProcessItem.Add(this.dtpConfectDate.Name, pItem.Clone());

            pItem.ProcessItem.ID = "CheckOper";
            pItem.ProcessItem.Name = "复核员";
            this.hsProcessItem.Add(this.cmbCheckOper.Name, pItem.Clone());

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

            this.cmbConfectOper.AddItems(alStaticEmployee);
            this.cmbCheckOper.AddItems(alStaticEmployee);
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

            return base.SetPreparation(preparation);
        }

        public override int PrintProcess()
        {
           // MessageBox.Show("Confect");

            return base.PrintProcess();
        }
    }    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂分装]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-10]<br></br>
    /// <说明>
    /// 
    /// </说明>
    /// </summary>
    public partial class ucDivision : ucPPRManager
    {
        public ucDivision()
        {
            InitializeComponent();
        }

        protected override bool DataValid()
        {
            for (int i = 0; i < this.fsDrug_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Preparation.Preparation info = this.GetDrugFromFp(i);
                if (info.ConfectQty == 0)
                {
                    MessageBox.Show(info.Drug.Name + "  半成品量不能为 零", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (info.ConfectQty > info.PlanQty)
                {
                    MessageBox.Show(info.Drug.Name + "  半成品量不能大于 计划生产量", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return base.DataValid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 患者费用药品查询]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQueryFeeDrug : UserControl
    {
        public ucQueryFeeDrug()
        {
            InitializeComponent();
        }

#region 字段
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeManager = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        
#endregion

#region 方法
        /// <summary>
        /// 添加药品明细
        /// </summary>
        /// <param name="patient"></param>
        public void AddItems(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            
            ArrayList drugs = this.feeManager.GetMedItemsForInpatient(patient.ID, patient.PVisit.InTime, Environment.AnaeManager.GetDateTimeFromSysDateTime());
            decimal totCost = 0;
            this.fpSpread2_Sheet1.RowCount = 0;
            if (drugs != null)
            {
                foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList drug in drugs)
                {
                    fpSpread2_Sheet1.Rows.Add(fpSpread2_Sheet1.RowCount, 1);
                    int row = fpSpread2_Sheet1.RowCount - 1;
                    //添加项目名称
                    if (drug.Item.Specs == "")
                        fpSpread2_Sheet1.SetValue(row, 0, drug.Item.Name, false);
                    else
                        fpSpread2_Sheet1.SetValue(row, 0, drug.Item.Name + "[" + drug.Item.Specs + "]", false);
                    //价格
                    fpSpread2_Sheet1.SetValue(row, 1, drug.Item.Price, false);
                    //数量
                    fpSpread2_Sheet1.SetValue(row, 2, drug.Item.Qty, false);
                    //比率
                    fpSpread2_Sheet1.SetValue(row, 3, drug.FTRate.ItemRate, false);
                    //单位
                    fpSpread2_Sheet1.SetValue(row, 4, drug.Item.PriceUnit, false);
                    //总额
                    fpSpread2_Sheet1.SetValue(row, 5, drug.FT.TotCost, false);
                    //收费人
                    fpSpread2_Sheet1.SetValue(row, 6, drug.FeeOper.ID, false);
                    //收费时间
                    fpSpread2_Sheet1.SetValue(row, 7, drug.FeeOper.OperTime.ToString(), false);
                    totCost = totCost + drug.FT.TotCost;
                }
            }
            if (totCost > 0)
            {
                fpSpread2_Sheet1.Rows.Add(fpSpread2_Sheet1.RowCount, 1);
                int row = fpSpread2_Sheet1.RowCount - 1;
                fpSpread2_Sheet1.SetValue(row, 4, "合计", false);
                fpSpread2_Sheet1.SetValue(row, 5, totCost, false);
            }
        }

        public void Reset()
        {
            this.fpSpread2_Sheet1.RowCount = 0;
        }

        public int Print()
        {
            return Environment.Print.PrintPreview(this);
        }
#endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 单表查询控件]<br></br>
    /// [创 建 者: dorian]<br0511-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的='继承自基类ucMaintenance。实现Spell功能'
    ///		修改描述='{B30340F5-ACAA-4546-B3EB-2E9A52F42F52}'
    ///  />
    /// </summary>
    public partial class ucMaintenance : Neusoft.FrameWork.WinForms.Controls.ucMaintenance
    {
        public ucMaintenance()
        {
            InitializeComponent();
        }

        Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

        protected override void fpSpread1_EditModeOff(object sender, EventArgs e)
        {
            base.fpSpread1_EditModeOff(sender, e);

            int columnIndex = this.fpSpread1_Sheet1.ActiveColumnIndex;
            int rowIndex = this.fpSpread1_Sheet1.ActiveRowIndex;

            if (this.fpSpread1_Sheet1.Columns[columnIndex].Label == "名称")
            {
                string words = this.fpSpread1_Sheet1.Cells[rowIndex, columnIndex].Text;
                Neusoft.HISFC.Models.Base.ISpell spellInfo = spellManager.Get(words);

                int spellColumn = this.GetColumnIndexFromLabel("拼音码");
                if (spellColumn != -1)
                {
                    this.fpSpread1_Sheet1.Cells[rowIndex, spellColumn].Text = spellInfo.SpellCode;
                }
                int wbColumn = this.GetColumnIndexFromLabel("五笔码");
                if (wbColumn != -1)
                {
                    this.fpSpread1_Sheet1.Cells[rowIndex, wbColumn].Text = spellInfo.WBCode;
                }


            }
        }

        /// <summary>
        /// 根据列名返回列索引
        /// </summary>
        /// <param name="label"></param>
        /// <returns>如不存在相应列，则返回-1</returns>
        private int GetColumnIndexFromLabel(string label)
        {
            for (int i = 0; i < this.fpSpread1_Sheet1.Columns.Count; i++)
            {
                if (this.fpSpread1_Sheet1.Columns[i].Label == label)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

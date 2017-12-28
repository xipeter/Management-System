using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 常数维护子窗口，可以自动生成拼音码和五笔码]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-04-16]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMaintenanceConstSub : Neusoft.FrameWork.WinForms.Controls.ucMaintenance
    {
        public ucMaintenanceConstSub()
            :base("const")
        {
            InitializeComponent();
            this.HideFilter();
        }
        private Neusoft.HISFC.BizLogic.Manager.Spell spellManager = new Neusoft.HISFC.BizLogic.Manager.Spell();

        protected override string SQL
        {
            get
            {
                return base.SQL+ string.Format(" where TYPE='{0}'",((Control)this).Text );
            }
        }

        protected override string GetDefaultValue(string fieldName)
        {
            if(fieldName=="TYPE")
            {
                return ((Control)this).Text;
            }else
            {
                return base.GetDefaultValue(fieldName);
            }
        }
        private FarPoint.Win.Spread.Column GetColumnByName(string name)
        {
            foreach (Column column in this.fpSpread1_Sheet1.Columns)
            {
                if (column.Label == name)
                    return column;
            }

            return null;
        }
        protected override void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            base.fpSpread1_Sheet1_CellChanged(sender, e);

            //如果没有装载数据完成，则不做处理
            if (!this.isDataLoaded)
                return;

            //如果改变了名称，则拼音码、五笔码自动发生变化
            if (this.fpSpread1_Sheet1.Columns[e.Column].Label == "名称")
            {
                Column column = this.GetColumnByName("拼音码");
                if (column != null /*&& this.fpSpread1_Sheet1.Cells[e.Row,column.Index].Text.Length==0*/)
                {
                    this.fpSpread1_Sheet1.Cells[e.Row, column.Index].Text = Neusoft.FrameWork.Public.String.GetSpell(this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Text);
                }
                
                column = this.GetColumnByName("五笔码");
                if(column != null)
                {
                    Neusoft.HISFC.Models.Base.ISpell spCode = this.spellManager.Get(this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Text);
                    if(spCode != null)
                        this.fpSpread1_Sheet1.Cells[e.Row, column.Index].Text = spCode.WBCode;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.NFC.Interface.Controls
{
    /// <summary>
    /// [功能描述: 常数维护子窗口,不能自动生成拼音码与五笔码，如果需要，请调用UFC.Manager.Controls.ucMaintenanceConstSub]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-23]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMaintenanceConstSub : ucMaintenance
    {
        public ucMaintenanceConstSub()
            :base("const")
        {
            InitializeComponent();
            this.HideFilter();
        }

        public string ConstType;
        protected override string SQL
        {
            get
            {
                return base.SQL + string.Format(" where TYPE='{0}'", ((Control)this).Text);
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


    }
}

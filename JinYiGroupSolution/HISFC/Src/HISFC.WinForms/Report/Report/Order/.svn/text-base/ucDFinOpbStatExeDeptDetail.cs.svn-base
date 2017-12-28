using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Report.Order
{
    public partial class ucDFinOpbStatExeDeptDetail : Neusoft.WinForms.Report.Common.ucQueryBaseForDataWindow
    {
        public ucDFinOpbStatExeDeptDetail()
        {
            InitializeComponent();
        }
        protected override void OnLoad()
        {
            this.Init();
            base.OnLoad();
        }

        
        /// <summary>
        /// ¼ìË÷Êý¾Ý
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            //InitializeComponent();
            //dwMain.Size = plRightTop.Size;
            //OnLoad();

            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value);

        }

    }
}

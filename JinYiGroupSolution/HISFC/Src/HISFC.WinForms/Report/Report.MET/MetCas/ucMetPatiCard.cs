using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Report.MET.MetCas
{
    public partial class ucMetPatiCard : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucMetPatiCard()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department( );

        #endregion 

        protected override int OnRetrieve( params object[] objects )
        {
            string str开始住院号 = string.Empty;
            if (base.GetQueryTime( ) == -1)
            {
                return -1;
            }
            str开始住院号 = this.txt开始住院号.Text.Trim();
            if (str开始住院号 == null || str开始住院号 == "")
            {
                str开始住院号 = "ALL";
            }
            else
            {
                str开始住院号 = str开始住院号.PadLeft(10, '0');
            }
            base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value,str开始住院号);
            this.txt总人数.Text = "总人数:" + base.dwMain.RowCount.ToString();
            return 1;
        }

        private void ucMetPatiCard_Load( object sender, EventArgs e )
        {
            DateTime sysTime = this.dept.GetDateTimeFromSysDateTime( );
            this.dtpBeginTime.Text = sysTime.AddDays(-1).ToShortDateString( ) + " 00:00:00";
            this.dtpEndTime.Text = sysTime.AddDays(-1).ToShortDateString( ) + " 23:59:59";

        }
    }
}

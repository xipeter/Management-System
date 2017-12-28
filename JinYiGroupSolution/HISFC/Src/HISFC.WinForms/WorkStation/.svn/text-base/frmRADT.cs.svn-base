using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    /// <summary>
    /// 患者入出转主窗口
    /// </summary>
    public partial class frmRADT : Neusoft.FrameWork.WinForms.Forms.frmBaseForm
    {
        public frmRADT()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据,请稍候...");
            Application.DoEvents();
            InitializeComponent();
            this.tvNursePatientList1.Refresh();
            this.isOneControl = true;//只有一个控件
            this.SetTree(this.tvNursePatientList1);
            AddControl(this.ucRADT1, this.panelMain);
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }
        protected override void OnLoad(EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            string tmp = this.Tag.ToString();
            //窗口tag=null,显示维护床位界面，否则不显示维护床位界面
            if (tmp == null || tmp.Trim() == "")
            {
                this.tbBed.Visible = true;
            }
            else
            {
                this.tbBed.Visible = false;
            }
            tbRefresh.Text = "刷新";
            base.OnLoad(e);
           
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.tbBed)
            {
                this.ucRADT1.AddTabpage(new Neusoft.HISFC.Components.RADT.Controls.ucBedManager(), "床位维护", null);
            }
            else if (e.ClickedItem == this.tbFee)
            {
                this.ucRADT1.AddTabpage(new Neusoft.HISFC.Components.RADT.Controls.ucAlert(), "欠费报警", null);
            }
            else if (e.ClickedItem == this.tbExit)
            {
                this.Close();
            }
            else if (e.ClickedItem == this.tbRefresh)
            {
                this.tvNursePatientList1.Refresh();
                this.ucRADT1.ic_RefreshTree(null, null);//{997A8EEC-A27E-492f-941A-CDEAA3CC4AE7}
            }
        }
        protected override void iControlable_RefreshTree(object sender, EventArgs e)
        {
            this.tvNursePatientList1.Refresh();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Common
{
    public partial class frmPreviewDataWindow : Form
    {
        public frmPreviewDataWindow()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 当前数据窗口
        /// </summary>
        protected NeuDataWindow.Controls.NeuDataWindow dwControl = null;

        #endregion

        #region 属性

        /// <summary>
        /// 当前数据窗口
        /// </summary>
        public  NeuDataWindow.Controls.NeuDataWindow PreviewDataWindow 
        {
            get 
            {
                return this.dwControl;
            }
            set
            {
                this.dwControl = value;


                this.ShareData();
            }
        }

        #endregion

        #region 方法

        protected virtual void ShareData()
        {
            if (this.dwControl == null) 
            {
                return;
            }
   //             dw_show.setredraw(false)
   // dw_show.create(adw_data.describe("datawindow.syntax"))
   // dw_show.settransobject(sqlca)
   // //为了能够显示下拉数据窗口中的内容
   // dw_show.deleterow(dw_show.insertrow(0))
   // if  adw_data.rowcount() > 0 then
   //     dw_show.object.data = adw_data.object.data
   //     //
		
   // end if
	
   // //初始化窗口和预览数据窗口
   // //this.bringtotop = TRUE
   // //this.windowstate = maximized!
   // dw_show.Object.DataWindow.Print.Preview = true
   // dw_show.bringtotop = true
   // //确定预览窗口的显示比例
   // wf_iffull()
   //dw_show.setredraw(true)

            this.dwPreview.SetRedrawOff();
            this.dwPreview.Create(this.dwControl.Describe("datawindow.syntax"));
            this.dwControl.ShareData(this.dwPreview);
            this.dwPreview.PrintProperties.Preview = true;
            this.dwPreview.SetRedrawOn();
        }

        #endregion

        private void tbPrint_Click(object sender, EventArgs e)
        {
            this.dwPreview.Print();
        }

        protected override void OnClosed(EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;

            base.OnClosed(e);
        }
    }
}
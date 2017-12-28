using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy
{
    public partial class ucEasySet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEasySet()
        {
            InitializeComponent();
        }        

        /// <summary>
        /// 当前Fp
        /// </summary>
        internal FarPoint.Win.Spread.SheetView FpSv
        {
            get
            {
                return this.neuSpread1_Sheet1;
            }
            set
            {
                this.neuSpread1_Sheet1 = value;
            }
        }

        /// <summary>
        /// 保存代理
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        internal delegate int DataManagerDelegate();

        /// <summary>
        /// 事件保存
        /// </summary>
        internal event DataManagerDelegate SaveFinishedEvent;

        /// <summary>
        /// 数据初始化
        /// </summary>
        internal event DataManagerDelegate InitDataEvent;

        /// <summary>
        /// Fp格式化
        /// </summary>
        /// <param name="label">标签列头</param>
        /// <param name="width">列宽</param>
        /// <param name="visible">列是否可见</param>
        /// <returns>成功返回1 失败返回-1</returns>
        internal int InitFp(string[] label, int[] width, bool[] visible)
        {
            return 1;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        internal int InitData()
        {
            if (this.InitDataEvent != null)
            {
                return this.InitDataEvent();
            }

            return 1;         
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void Close()
        { 
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            this.InitData();

            base.OnLoad(e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveFinishedEvent != null)
            {
                if (this.SaveFinishedEvent() == 1)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}

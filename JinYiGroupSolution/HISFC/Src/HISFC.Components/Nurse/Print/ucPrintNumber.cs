using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Print
{
    /// <summary>
    /// ucPrintNumber<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射号码条打印父控件{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucPrintNumber : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectNumberPrint
    {
        #region 构造函数
        public ucPrintNumber()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量

        /// <summary>
        /// 整合的管理业务层
        /// </summary>
        private HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="al"></param>
        public void Init(ArrayList al)
        {
            //得到有几个序号
            Hashtable htOrderNo = new Hashtable();
            foreach (Neusoft.HISFC.Models.Nurse.Inject info in al)
            {
                if (!htOrderNo.ContainsKey(info.OrderNO))
                {
                    htOrderNo.Add(info.OrderNO, null);
                }
            }
            //循环创建控件
            int i = 1;
            int controlsHeight = 0;
            foreach (string key in htOrderNo.Keys)
            {
                //打两份
                ucPrintNumberControl ucPrint1 = new ucPrintNumberControl();
                ucPrint1.Init(key, htOrderNo.Count * 2, i++);
                ucPrint1.Dock = DockStyle.Top;
                ucPrintNumberControl ucPrint2 = new ucPrintNumberControl();
                ucPrint2.Init(key, htOrderNo.Count * 2, i++);
                ucPrint2.Dock = DockStyle.Top;
                this.Controls.Add(ucPrint1);
                this.Controls.Add(ucPrint2);
                controlsHeight += ucPrint1.Height;
                controlsHeight += ucPrint2.Height;
            }
            //打印
            this.Height = controlsHeight;
            this.Print();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

            p.PrintPage(12, 1, this);
        }

        #endregion
    }
}

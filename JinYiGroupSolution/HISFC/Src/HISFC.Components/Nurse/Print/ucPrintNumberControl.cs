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
    /// ucPrintNumberControl<br></br>
    /// <Font color='#FF1111'>[功能描述:门诊注射号码条打印控件{30E1EF7D-1236-4e38-A8E3-7567C9E33B0B}]</Font><br></br>
    /// [创 建 者: 耿晓雷]<br></br>
    /// [创建时间: 2010-7-19]<br></br>
    /// <修改记录 
    ///		修改人='' 
    ///		修改时间='yyyy-mm-dd' 
    ///		修改目的=''
    ///		修改描述=''
    ///		/>
    /// </summary>
    public partial class ucPrintNumberControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造函数
        public ucPrintNumberControl()
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
        public void Init(string orderNo, int pageCount, int currPage)
        {
            //医院名称
            this.lbHosName.Text = this.interManager.GetHospitalName();
            //时间
            this.lbTime.Text = (new HISFC.BizLogic.Nurse.Inject()).GetDateTimeFromSysDateTime().ToString("yyyy-MM-dd HH:mm:ss");

            //分割序号
            string[] orderSplit = orderNo.Split('-');
            if (orderSplit.Length < 2)
            {
                return;
            }
            //加圈
            string lastNumStr = orderSplit[1];
            int lastNum = FrameWork.Function.NConvert.ToInt32(lastNumStr);
            //只有20以内的带圈数字
            if (lastNum <= 20)
            {
                lastNumStr = ((char)(9311 + lastNum)).ToString();
            }
            this.lbOrderNo.Text = orderSplit[0] + "-" + lastNumStr;
            //页码
            this.lbPage.Text = currPage.ToString() + "/" + pageCount.ToString();
        }

        #endregion
    }
}

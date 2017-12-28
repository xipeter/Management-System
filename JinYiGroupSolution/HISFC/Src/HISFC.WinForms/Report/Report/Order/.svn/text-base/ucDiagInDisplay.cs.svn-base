using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Order
{
    /// <summary>
    /// 门诊医生叫号
    /// </summary>
    public partial class ucDiagInDisplay : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.HISFC.BizProcess.Interface.IDiagInDisplay
    {
        /// <summary>
        /// 门诊医生叫号
        /// </summary>
        public ucDiagInDisplay()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 挂号信息
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();

        /// <summary>
        /// 诊室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject objRoom = new Neusoft.FrameWork.Models.NeuObject();

        #endregion


        #region IDiagInDisplay 成员

        /// <summary>
        /// 实现接口
        /// </summary>
        public void DiagInDisplay()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 诊室
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject ObjRoom
        {
            get
            {
                return this.objRoom;
            }
            set
            {
                this.objRoom = value;
            }
        }

        /// <summary>
        /// 挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register RegInfo
        {
            get
            {
                return this.register;
            }
            set
            {
                this.register = value;
            }
        }

        #endregion
    }
}


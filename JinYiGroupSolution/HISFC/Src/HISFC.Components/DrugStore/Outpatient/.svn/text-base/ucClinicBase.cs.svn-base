using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.DrugStore.Outpatient
{
    /// <summary>
    /// [功能描述: 门诊配发药基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <修改记录 
    ///		
    ///  />
    /// </summary>
    public partial class ucClinicBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucClinicBase()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 当前操作库房
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作人员信息
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operInfo = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 当前操作终端
        /// </summary>
        internal Neusoft.HISFC.Models.Pharmacy.DrugTerminal terminal = new Neusoft.HISFC.Models.Pharmacy.DrugTerminal();

        /// <summary>
        /// 核准库房
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject approveDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 模块功能
        /// </summary>
        internal DrugStore.OutpatientFun funModle = OutpatientFun.Drug;

        #endregion

        #region 属性

        /// <summary>
        /// 当前操作库房
        /// </summary>
        [Description("当前操作科室"),Category("设置"),DefaultValue(null)]
        public Neusoft.FrameWork.Models.NeuObject OperDept
        {
            get
            {
                return this.operDept;
            }
            set
            {
                this.operDept = value;
            }
        }

        /// <summary>
        /// 当前操作人员信息
        /// </summary>
        [Description("当前操作人员信息"), Category("设置"), DefaultValue(null)]
        public virtual Neusoft.FrameWork.Models.NeuObject OperInfo
        {
            get
             {
                return this.operInfo;
            }
            set
            {
                this.operInfo = value;
            }
        }

        /// <summary>
        /// 核准库房
        /// </summary>
        [Description("核准库房"), Category("设置"), DefaultValue(null)]
        public Neusoft.FrameWork.Models.NeuObject ApproveDept
        {
            get
            {
                return this.approveDept;
            }
            set
            {
                this.approveDept = value;
            }
        }

        #endregion

        /// <summary>
        /// 设置FunMode 窗口功能
        /// </summary>
        public virtual void SetFunMode(DrugStore.OutpatientFun winFunMode)
        {
            this.funModle = winFunMode;
        }

        /// <summary>
        /// 设置当前操作终端
        /// </summary>
        /// <param name="winTerminal">传入门诊终端实体信息</param>
        public virtual void SetTerminal(Neusoft.HISFC.Models.Pharmacy.DrugTerminal winTerminal)
        {
            this.terminal = winTerminal;
        }


        #region 打印静态接口

        /// <summary>
        ///// 发药处方打印接口
        /// </summary>
        public static Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint RecipePrint = null;

        /// <summary>
        /// 发药清单打印接口
        /// </summary>
        public static Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint ListingPrint = null;

        #endregion
    }
}

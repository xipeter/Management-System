using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucNurseQuitFee<br></br>
    /// [功能描述: 住院护士退费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucNurseQuitFee : ucQuitFee
    {
        /// <summary>
        /// 护士站退费构造函数
        /// </summary>
        public ucNurseQuitFee()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //设置不可以输入住院号
            this.IsCanInputInpatientNO = false;
            //设置保存方式为退费申请
            this.operation = Operations.QuitFee;

            return base.OnInit(sender, neuObject, param);
        }

        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        protected override void SetPatientInfomation()
        {
            this.ucQueryPatientInfo.Text = this.patientInfo.PID.PatientNO;

            base.SetPatientInfomation();
        }

        /// <summary>
        /// 接收树选择的患者基本信息
        /// </summary>
        /// <param name="neuObject">患者基本信息实体</param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            base.Clear();

            base.PatientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;

            //base.PatientInfo = base.radtIntegrate.GetPatientInfomation(base.patientInfo.ID);

            return base.OnSetValue(neuObject, e);
        }
    }
}

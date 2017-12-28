using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 会诊意见]<br></br>
    /// [创 建 者: 陈樊]<br></br>
    /// [创建时间: 2009-07-22]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucConsultationShow : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucConsultationShow()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 整合的入出转管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.RADT managerRADT = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 当前操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee per = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        /// <summary>
        /// 业务层
        /// </summary>
        private Neusoft.FrameWork.Management.DataBaseManger dbManager = new Neusoft.FrameWork.Management.DataBaseManger();

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            InitTvPatientList();
            return 1;
        }

        /// <summary>
        /// 初始化患者列表
        /// </summary>
        /// <returns></returns>
        private int InitTvPatientList()
        {
            this.tvPatientList.Nodes.Clear();
            TreeNode tnRoot = new TreeNode();
            tnRoot.Name = "ConsultationPatient";
            tnRoot.Text = "科室会诊患者";
            tnRoot.Tag = "ConsultationPatient";
            this.tvPatientList.Nodes.Add(tnRoot);
            DateTime dt = dbManager.GetDateTimeFromSysDateTime();
            DateTime dt1 = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
            DateTime dt2 = new DateTime(dt.Year, dt.AddDays(1).Month, dt.AddDays(1).Day, 0, 0, 0, 0);
            ArrayList al1 = this.managerRADT.QueryPatientByConsultation(dbManager.Operator, dt1, dt2, per.Dept.ID);
            if (al1 == null)
            {
                MessageBox.Show(this.managerRADT.Err);
            }

            foreach (Neusoft.HISFC.Models.RADT.PatientInfo patientInfo in al1)
            {
                TreeNode tn = new TreeNode();
                tn.Name = patientInfo.ID;
                tn.Text = "【" + patientInfo.PVisit.PatientLocation.Bed.ID.Remove(0, 4) + "】" + patientInfo.Name;
                tn.Tag = patientInfo;
                this.tvPatientList.Nodes["ConsultationPatient"].Nodes.Add(tn);
            }
            this.tvPatientList.ExpandAll();

            //this.tv = this.tvPatientList;
            return 1;
        }

        #endregion

        #region 事件

        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
        }

        private void tvPatientList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "ConsultationPatient")
            {
                return;
            }
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = e.Node.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            this.ucConsultation1.IsApply = false;
            this.ucConsultation1.InpatientNo = patientInfo.ID;
        }

        #endregion
    }
}

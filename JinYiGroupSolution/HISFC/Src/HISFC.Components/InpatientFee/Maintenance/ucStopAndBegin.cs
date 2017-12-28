using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// ucBalance<br></br>
    /// [功能描述: 手工封账开账]<br></br>//{B9BC9278-B7CB-4b03-BBF6-2CF6CFB197FF}
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2010-05-21]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucStopAndBegin : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {

        public ucStopAndBegin()
        {
            InitializeComponent();
        }
        #region 域变量
        /// <summary>
        /// 综合管理层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 住院入出转综合业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 工具栏按钮
        /// </summary>
        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 综合费用业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        Neusoft.HISFC.BizLogic.Fee.InPatient inPatientFee = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        
        #endregion

        #region 属性
        
        #endregion

        #region 方法

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            ucQueryInpatientNo1.myEvent += new Neusoft.HISFC.Components.Common.Controls.myEventDelegate(ucQueryInpatientNo1_myEvent);
            //初始化科室
            int returnValue = this.InitDeptList();
            if (returnValue < 0)
            {
                return -1;
            }
            return 1;
        }

        

        /// <summary>
        /// 初始化farpoint
        /// </summary>
        /// <returns></returns>
        private int InitFarpoint()
        {

            return 1;
        }

        /// <summary>
        /// 初始化科室列表
        /// </summary>
        /// <returns></returns>
        private int InitDeptList()
        {
            //获取说有住院科室
            ArrayList alDeptList = this.managerIntegrate.GetDeptmentByType("I");
            if (alDeptList == null)
            {
                MessageBox.Show(Language.Msg("查询住院科室出错") +this.managerIntegrate.Err);
                return -1;
            }

            this.cmbDeptList.AddItems(alDeptList);

            return 1;
        }

        #endregion

        #region farpoint 赋值
        private void AddFarpoint(ArrayList alPatientinfoList)
        {
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo p in alPatientinfoList)
            {
                this.AddFarpoint(p);

            }
        }

        private void AddFarpoint(Neusoft.HISFC.Models.RADT.PatientInfo p)
        {

            this.neuSpread1_Sheet1.Rows.Add(0, 1);

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.PatientNO].Text = p.PID.PatientNO;

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.Name].Text = p.Name;

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.DeptName].Text = p.PVisit.PatientLocation.Dept.Name;

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.Sex].Text = p.Sex.Name;

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.InDate].Text = p.PVisit.InTime.ToString();

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.PrepayCost].Text = p.FT.PrepayCost.ToString();

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.TotCost].Text = p.FT.TotCost.ToString();

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.InState].Text = p.PVisit.InState.ToString();
            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.Birthday].Text = p.Birthday.ToString("yyyy-MM-dd");

            if (p.IsStopAcount)
            {
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.StopFlag].Text = "封账";
                this.neuSpread1_Sheet1.Rows[0].ForeColor = Color.Red;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.StopFlag].Text = "开账";
            }

            this.neuSpread1_Sheet1.Cells[0, (int)EnumCol.FreeCost].Text = p.FT.LeftCost.ToString();
            this.neuSpread1_Sheet1.Rows[0].Tag = p;
        }

        /// <summary>
        /// 是否关账
        /// </summary>
        /// <param name="isStopAccount"></param>
        /// <returns></returns>
        private int ProcessAcountFlag(bool isStopAccount)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo p = this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

            int returnValue = 0;

            if (isStopAccount)
            {
                if (p.IsStopAcount)
                {
                    MessageBox.Show("该患者已经封账，无需封账");
                    return -1;
                }
                returnValue = this.inPatientFee.CloseAccount(p.ID);
                if (returnValue < 0)
                {
                    MessageBox.Show(Language.Msg("封账失败") + this.inPatientFee.Err);
                    return -1;
                }
                MessageBox.Show("封账成功");
            }
            else
            {
                if (!p.IsStopAcount)
                {
                    MessageBox.Show("该患者已经开账，无需开账");
                    return -1;
                }
                returnValue = this.inPatientFee.OpenAccount(p.ID);
                if (returnValue < 0)
                {
                    MessageBox.Show(Language.Msg("开账失败") + this.inPatientFee.Err);
                    return -1;
                }
                MessageBox.Show("开账成功");
            }

            

            p.IsStopAcount = isStopAccount;

            if (p.IsStopAcount)
            {
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)EnumCol.StopFlag].Text = "封账";
                this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].ForeColor = Color.Red;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, (int)EnumCol.StopFlag].Text = "开账";
                this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.ActiveRowIndex].ForeColor = Color.Black;
            }

            

            
            return 1;
        }

        #region 重载方法
       

        //protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        //{
        //    this.toolBarService.AddToolButton("封账", "封账", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
        //    this.toolBarService.AddToolButton("开账", "开账", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.K开帐, true, false, null );

        //    return this.toolBarService;
        //}

        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
          
            this.toolBarService.AddToolButton("封账", "封账", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐, true, false, null);
            this.toolBarService.AddToolButton("开账", "开账", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.K开帐, true, false, null );


            return this.toolBarService;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();
            base.OnLoad(e);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "封账":
                    {
                        this.ProcessAcountFlag(true); 
                        break;
                    }
                case "开账":
                    {
                        ProcessAcountFlag(false);
                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion
        #endregion

        #endregion

        #region 事件


        void ucQueryInpatientNo1_myEvent()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            if (string.IsNullOrEmpty(this.ucQueryInpatientNo1.InpatientNo))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有该患者信息"));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

            patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);

            if (patientInfo == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.radtIntegrate.Err));
                this.ucQueryInpatientNo1.Focus();
                return;
            }

            if (patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);

                patientInfo.ID = null;

                return;
            }

            this.AddFarpoint(patientInfo);
        }

        private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.RowCount = 0;

            if (this.cmbDeptList.SelectedItem == null)
            {
                return;
            }

            Neusoft.FrameWork.Models.NeuObject obj = this.cmbDeptList.SelectedItem as Neusoft.FrameWork.Models.NeuObject;

           ArrayList alPatientInfoList = this.radtIntegrate.QueryPatient(obj.ID, Neusoft.HISFC.Models.Base.EnumInState.I);
           this.AddFarpoint(alPatientInfoList);

           alPatientInfoList = this.radtIntegrate.QueryPatient(obj.ID, Neusoft.HISFC.Models.Base.EnumInState.R);

           this.AddFarpoint(alPatientInfoList);

           alPatientInfoList = this.radtIntegrate.QueryPatient(obj.ID, Neusoft.HISFC.Models.Base.EnumInState.B);

           this.AddFarpoint(alPatientInfoList);
        }
        #endregion

        private enum EnumCol
        {
            /// <summary>
            /// 出院号
            /// </summary>
            PatientNO = 0,

            /// <summary>
            /// 姓名
            /// </summary>
            Name, 

            /// <summary>
            /// 科室
            /// </summary>
            DeptName,

            /// <summary>
            /// 性别
            /// </summary>
            Sex,

            /// <summary>
            /// 出生日期
            /// </summary>
            Birthday,

            /// <summary>
            /// 预交金
            /// </summary>
            PrepayCost,

            /// <summary>
            /// 住院日期
            /// </summary>
            InDate,

            /// <summary>
            /// 总费用
            /// </summary>
            TotCost,

            /// <summary>
            /// 余额
            /// </summary>
            FreeCost,

            /// <summary>
            /// 在院状态
            /// </summary>
            InState,

            /// <summary>
            /// 封帐标志
            /// </summary>
            StopFlag
        }

        private void rbPerson_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDeptList.Enabled = !this.rbPerson.Checked;
            if (this.rbPerson.Checked)
            {
                this.ucQueryInpatientNo1.Focus();
            }

            this.neuSpread1_Sheet1.RowCount = 0;

        }

        private void rbDept_CheckedChanged(object sender, EventArgs e)
        {
            this.ucQueryInpatientNo1.Enabled = !this.rbDept.Checked;
            if (this.rbDept.Checked)
            {
                this.cmbDeptList.Focus();
            }
            this.neuSpread1_Sheet1.RowCount = 0;
        }

      
    }
}

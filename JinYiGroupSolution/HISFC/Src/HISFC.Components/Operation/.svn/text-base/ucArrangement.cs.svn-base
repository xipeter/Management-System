using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Operation;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 手术安排控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-12-04]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucArrangement : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucArrangement()
        {
            InitializeComponent();
        }

        #region 字段
        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
// {CB2F6DC4-F9C6-4756-A118-CEDB907C39EC}
        private Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        #endregion

        #region 方法

        /// <summary>
        /// 刷新手术申请列表
        /// </summary>
        /// <returns></returns>
        public int RefreshApplys()
        {
            this.ucArrangementSpread1.Reset();

            //开始时间
            string beginTime = this.neuDateTimePicker1.Value.Date.ToString();
            //结束时间
            string endTime = this.neuDateTimePicker1.Value.Date.AddDays(1).ToString();

            //neusoft.neNeusoft.HISFC.Components.Interface.Classes.Function.ShowWaitForm("正在载入数据,请稍后...");
            Application.DoEvents();
            ArrayList alApplys;
            try
            {
                this.ucArrangementSpread1.Reset();
                alApplys = Environment.OperationManager.GetOpsAppList(Environment.OperatorDeptID, beginTime, endTime);
                if (alApplys != null)
                {
                    foreach (OperationAppllication apply in alApplys)
                    {
                        this.ucArrangementSpread1.AddOperationApplication(apply);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("生成手术申请信息出错!" + e.Message, "提示");
                return -1;
            }

            this.ucArrangementSpread1.SetFilter();

            //neusoft.neNeusoft.HISFC.Components.Interface.Classes.Function.HideWaitForm();
            //if (fpSpread1_Sheet1.RowCount > 0)
            //{
            //FarPoint.Win.Spread.LeaveCellEventArgs e = new FarPoint.Win.Spread.LeaveCellEventArgs
            //    (new FarPoint.Win.Spread.SpreadView(fpSpread1), 0, 0, 0, (int)Cols.opDate);
            //fpSpread1_LeaveCell(fpSpread1, e);
            //    fpSpread1.Focus();
            //    fpSpread1_Sheet1.SetActiveCell(0, (int)Cols.opDate, true);
            //}

            return 0;
        }
        #endregion

        #region 事件

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {

            this.toolBarService.AddToolButton("全部", "全部", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分解, true, true, null);
            this.toolBarService.AddToolButton("已安排", "已安排", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印输液卡, true, false, null);
            this.toolBarService.AddToolButton("未安排", "未安排", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印执行单, true, false, null);
            this.toolBarService.AddToolButton("换科", "更换手术室", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z转科, true, false, null);
            this.toolBarService.AddToolButton("全屏", "安排信息最大化", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            this.toolBarService.AddToolButton("停", "停", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            return this.toolBarService;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.ucArrangementSpread1.Date = this.neuDateTimePicker1.Value;
            this.ucArrangementSpread1.Print();
            return base.OnPrint(sender, neuObject);
        }
        protected override int OnQuery(object sender, object neuObject)
        {
            this.RefreshApplys();
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.ucArrangementSpread1.Save();
            return base.OnSave(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "已安排")
            {
                this.toolBarService.GetToolButton("已安排").CheckState = System.Windows.Forms.CheckState.Checked;
                this.toolBarService.GetToolButton("全部").CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.toolBarService.GetToolButton("未安排").CheckState = System.Windows.Forms.CheckState.Unchecked;

                this.ucArrangementSpread1.Filter = ucArrangementSpread.EnumFilter.Already;
            }
            else if (e.ClickedItem.Text == "未安排")
            {
                this.toolBarService.GetToolButton("未安排").CheckState = System.Windows.Forms.CheckState.Checked;
                this.toolBarService.GetToolButton("全部").CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.toolBarService.GetToolButton("已安排").CheckState = System.Windows.Forms.CheckState.Unchecked;

                this.ucArrangementSpread1.Filter = ucArrangementSpread.EnumFilter.NotYet;
            }
            else if (e.ClickedItem.Text == "全部")
            {
                this.toolBarService.GetToolButton("全部").CheckState = System.Windows.Forms.CheckState.Checked;
                this.toolBarService.GetToolButton("未安排").CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.toolBarService.GetToolButton("已安排").CheckState = System.Windows.Forms.CheckState.Unchecked;

                this.ucArrangementSpread1.Filter = ucArrangementSpread.EnumFilter.All;
            }
            else if (e.ClickedItem.Text == "换科")
            {
                if (this.ucArrangementSpread1.ChangeDept() < 0) return;
                this.RefreshApplys();
            }
            else if (e.ClickedItem.Text == "全屏")
            {
                this.neuPanel1.Visible = !this.neuPanel1.Visible;
            }
            else if (e.ClickedItem.Text == "停") 
            {
                if(this.ucArrangementSpread1.SetStop()!=-1)
                {
                    this.RefreshApplys();
                }
            }



            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion

        private void ucArrangementSpread1_applictionSelected(object sender, OperationAppllication e)
        {

            if (e != null)
            {


                if (e.PatientSouce == "2")
                {
                    Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = radtIntegrate.GetPatientInfomation(e.PatientInfo.ID);

                    if (patientInfo == null)
                    {
                        MessageBox.Show(radtIntegrate.Err);
                        this.ucArrangementInfo1.OperationApplication = new OperationAppllication();

                        return;
                    }



                    //if ((Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.N
                    //    || (Neusoft.HISFC.Models.Base.EnumInState)this.patientInfo.PVisit.InState.ID == Neusoft.HISFC.Models.Base.EnumInState.O)
                    if (patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.N.ToString() || patientInfo.PVisit.InState.ID.ToString() == Neusoft.HISFC.Models.Base.EnumInState.O.ToString())
                    {
                        Neusoft.FrameWork.WinForms.Classes.Function.Msg("该患者已经出院!", 111);
                        //this.ucArrangementInfo1.OperationApplication = new OperationAppllication();
                        return;
                    }

                }

                this.ucArrangementInfo1.OperationApplication = e;
            }
        }
    }
}

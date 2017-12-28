using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    /// <summary>
    /// [功能描述: 月结帐管理]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public partial class ucMonthStoreManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMonthStoreManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Job jobManager = new Neusoft.HISFC.BizLogic.Manager.Job();

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 药品月结设置
        /// </summary>
        Neusoft.HISFC.Models.Base.Job job = new Neusoft.HISFC.Models.Base.Job();

        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime sysTime = System.DateTime.MinValue;

        /// <summary>
        /// 药品月结管理权限
        /// </summary>
        bool isMonthStorePriv = false;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 权限人员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 窗体功能
        /// </summary>
        private Neusoft.HISFC.Models.IMA.EnumModuelType winFun = Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy;

        /// <summary>
        /// 月结类别字符串
        /// </summary>
        private string monthStoreType = "PHA_MS";

        /// <summary>
        /// 明细信息
        /// </summary>
        private DataSet dsDetail = null;

        #endregion

        #region 属性

        /// <summary>
        /// 窗体功能
        /// </summary>
        [Description("窗体功能 其中设置为All 等同设置为Pharmacy"), Category("设置"), DefaultValue(Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy)]
        public Neusoft.HISFC.Models.IMA.EnumModuelType WinFun
        {
            get
            {
                return this.winFun;
            }
            set
            {
                this.winFun = value;

                switch (value)
                {
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy:           //药品
                        this.monthStoreType = "PHA_MS";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:          //物资
                        this.monthStoreType = "MAT_MS";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:         //设备
                        this.monthStoreType = "EQU_MS";
                        break;
                    default:
                        this.winFun = Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy;
                        this.monthStoreType = "PHA_MS";
                        break;
                }
            }
        }

        /// <summary>
        /// 是否存在月结权限
        /// </summary>
        protected bool IsMonthStorePriv
        {
            get
            {
                return this.isMonthStorePriv;
            }
            set
            {
                this.isMonthStorePriv = value;

                this.toolBarService.SetToolButtonEnabled("月结", value);
                this.toolBarService.SetToolButtonEnabled("作废", value);
            }
        }

        /// <summary>
        /// 是否允许过滤
        /// </summary>
        protected bool IsFilter
        {
            get
            {
                return this.txtFilter.Enabled;
            }
            set
            {
                this.txtFilter.Enabled = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("作废", "作废月结记录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Z注销, true, false, null);
            
            toolBarService.AddToolButton("月结", "重新生成月结记录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "作废")
            {
                this.DelMonthStore();
            }
            if (e.ClickedItem.Text == "月结")
            {
                this.MonthStore();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.MonthStore();

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowMonthStoreHead();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init()
        {
            #region 获取科室

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = deptManager.GetDeptmentAll();

            ArrayList alDept = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department info in al)
            {
                if (info.DeptType.ID.ToString() == "P" || info.DeptType.ID.ToString() == "PI")
                {
                    alDept.Add(info);
                }
            }

            this.cmbStoreDept.AddItems(alDept);

            #endregion

            this.job = this.jobManager.GetJob(this.monthStoreType);
            if (this.job == null)
            {
                MessageBox.Show(Language.Msg("根据药品月结编码获取药品月结设置失败"));
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// 显示月结记录
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        protected int ShowMonthStoreHead()
        {
            if (this.cmbStoreDept.Tag == null || this.cmbStoreDept.Tag.ToString() == "")
            {
                return -1;
            }

            this.neuSpread1.ActiveSheet = this.fpHeadSheet;

            DataSet dsHead = new DataSet();
            if (this.consManager.QueryMonthStoreHead(this.cmbStoreDept.Tag.ToString(),ref dsHead) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结汇总信息失败") + this.consManager.Err);
                return -1;
            }
            if (dsHead.Tables.Count <= 0)
            {
                return -1;
            }

            this.fpHeadSheet.DataSource = dsHead;

            return 1;
        }

        /// <summary>
        /// 获取月结明细信息
        /// </summary>
        /// <returns></returns>
        protected int ShowMonthStoreDetail()
        {
            DateTime dtBeginTime = NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex, 0].Text);
            DateTime dtEndTime = NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex, 1].Text);

            if (this.cmbStoreDept.Tag == null || this.cmbStoreDept.Tag.ToString() == "")
            {
                return -1;
            }

            dsDetail = new DataSet();
            if (this.consManager.QueryMonthStoreDetail(this.cmbStoreDept.Tag.ToString(), dtBeginTime, dtEndTime, ref  dsDetail) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结明细信息失败") + this.consManager.Err);
                return -1;
            }

            if (dsDetail.Tables.Count <= 0)
            {
                return -1;
            }

            this.fpDetailSheet.DataSource = dsDetail.Tables[0].DefaultView;

            if (dsDetail.Tables[0].Rows.Count > 0)
            {
                this.neuSpread1.ActiveSheet = this.fpDetailSheet;
            }

            return 1;

        }

        /// <summary>
        /// 月结执行
        /// </summary>
        /// <returns></returns>
        protected int MonthStore()
        {
            frmMonthStore uc = new frmMonthStore();

            uc.IsShowButton = true;

            //Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            uc.ShowDialog();

            this.ShowMonthStoreHead();

            return 1;
        }

        /// <summary>
        /// 月结记录作废删除
        /// </summary>
        /// <returns></returns>
        protected int DelMonthStore()
        {
            if (this.neuSpread1.ActiveSheet == this.fpDetailSheet)
            {
                return 0;
            }
            if (this.fpHeadSheet.Rows.Count <= 0)
            {
                return 0;
            }

            //判断是否最近一次月结记录 
            if (this.fpHeadSheet.ActiveRowIndex > 0)
            {
                MessageBox.Show(Language.Msg("对月结帐的删除只能删除最近一次月结记录 不可跨时间段删除 请先删除此记录前所有月结记录"));
                return 0;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("确认删除此次月结记录吗？ \n 注意 此操作不可撤销 且将删除本院所有库房的此次月结记录！"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return 0;
            }

            DateTime dtBeginTime = NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex,0].Text);
            DateTime dtEndTime = NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex, 1].Text);

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.jobManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.consManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.job.ID == "")
            {
                this.job.ID = this.monthStoreType;
            }

            if (this.fpHeadSheet.Rows.Count == 1)           //只有一条月结记录 清空job
            {
                if (this.jobManager.DeleteJob(this.job.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新统计时间表失败 ") + this.jobManager.Err);
                    return -1;
                }
            }
            else                                           //更新月结统计表
            {
                this.job.LastTime = dtBeginTime;
                this.job.NextTime = dtBeginTime.AddMonths(1);

                if (this.jobManager.UpdateJob(this.job) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("更新统计时间表失败 ") + this.jobManager.Err);
                    return -1;
                }
            }

            if (this.consManager.DelMonthStore(dtBeginTime, dtEndTime) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("药品月结记录作废发生错误") + this.consManager.Err);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));

            this.ShowMonthStoreHead();

            return 1;
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                //判断操作员是否拥有权限，如果没有则不允许操作此窗口
                List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = Neusoft.HISFC.Components.Common.Classes.Function.QueryPrivList("0303", true);
                if (alPrivDept == null || alPrivDept.Count == 0)
                {
                    this.isMonthStorePriv = false;
                }
                else
                {
                    this.isMonthStorePriv = true;
                }

                this.sysTime = this.consManager.GetDateTimeFromSysDateTime();

                if (this.Init() == -1)
                {
                    this.isMonthStorePriv = false;
                    return;
                }

                this.IsFilter = false;
            }

            base.OnLoad(e);
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                return;
            }

            if (this.neuSpread1.ActiveSheet == this.fpDetailSheet)
            {
                return;
            }

            this.ShowMonthStoreDetail();
        }

        private void cmbStoreDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowMonthStoreHead();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.dsDetail == null || this.dsDetail.Tables == null || this.dsDetail.Tables.Count < 0 || this.dsDetail.Tables[0].DefaultView == null)
            {
                return;
            }

            //获得过滤条件
            string queryCode = "%" + this.txtFilter.Text + "%";

            string filter = Function.GetFilterStr(this.dsDetail.Tables[0].DefaultView, queryCode);

            try
            {
                this.dsDetail.Tables[0].DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("过滤发生异常 " + ex.Message));
            }
        }

        private void neuSpread1_ActiveSheetChanged(object sender, EventArgs e)
        {
            if (this.neuSpread1.ActiveSheet == this.fpHeadSheet)
            {
                this.IsFilter = false;
            }
            else
            {
                this.IsFilter = true;
            }
        }
    }
}

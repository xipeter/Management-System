using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    public partial class frmMonthStore : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmMonthStore()
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
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 药品月结设置
        /// </summary>
        Neusoft.HISFC.Models.Base.Job job = new Neusoft.HISFC.Models.Base.Job();

        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime sysTime = System.DateTime.MinValue;

        /// <summary>
        /// 药品月结权限
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

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示窗体下部按钮
        /// </summary>
        [Description("是否显示窗体下部按钮"),Category("设置"),DefaultValue(false)]
        public bool IsShowButton
        {
            get
            {
                return this.penelButon.Visible;
            }
            set
            {
                this.penelButon.Visible = value;
            }
        }

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

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.privOper = this.jobManager.Operator;
            this.job = this.jobManager.GetJob(this.monthStoreType);
            if (this.job == null)
            {
                MessageBox.Show(Language.Msg("根据药品月结编码获取药品月结设置失败"));
                return;
            }
            if (this.job.ID != "")
            {
                if (this.job.Type == "0")
                    this.cmbType.Text = "手动";
                else
                    this.cmbType.Text = "自动";               

                this.dtpLast.Enabled = false;       //上次月结截至时间不能修改
            }
            else
            {
                this.job.ID = this.monthStoreType;
                this.job.Name = "全院月结";
                this.job.State.ID = "M";
                this.job.LastTime = this.sysTime.AddMonths(-1);
                this.job.NextTime = this.sysTime;
                this.job.Type = "0";
                this.job.IntervalDays = 30;
                this.job.Department.ID = "0";

                this.cmbType.Text = "自动";

                this.jobManager.SetJob(this.job);
            }

            this.dtpLast.Value = this.job.LastTime;
            this.dtpNext.Value = this.job.NextTime;
        }

        /// <summary>
        /// 月结时间设置
        /// </summary>
        /// <returns></returns>
        private bool JudgeMonthStoreTime()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("上次月结时间为" + this.job.LastTime.ToString() + "\n 确认现在进行月结吗?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
                return false;

            rs = MessageBox.Show(Language.Msg("是否进行月结截至时间设置 选择'是' 设置月结截止时间 选择'否' 设置月结截至时间为当前日期"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (rs == DialogResult.Yes)		//设置月结时间
            {
                ucMonthStoreSet uc = new ucMonthStoreSet();
                uc.SetJob(this.job.Clone(), this.sysTime.AddSeconds(-1));

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                if (uc.Result == DialogResult.Cancel)
                    return false;

                this.job.NextTime = uc.NextTime;
            }
            else
            {
                //减一秒 保证存储过程内判断时间是否能够月结时 可以正常执行
                this.job.NextTime = this.sysTime.AddSeconds(-1);
            }

            if (this.jobManager.SetJob(this.job) != 1)
            {
                MessageBox.Show(Language.Msg("根据当前时间设置月结时间 发生错误"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual int Save()
        {
            switch (this.winFun)
            {
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy:           //药品
                case Neusoft.HISFC.Models.IMA.EnumModuelType.All:
                    if (this.isMonthStorePriv)
                    {
                        //{3E00895B-09AD-47c5-AFCF-32D523F4E616} 对于月结失败时 需回滚月结记录状态
                        if (this.SavePHAMS() == -1)
                        {
                            this.job.State.ID = "M";

                            if (this.jobManager.SetJob(this.job) != 1)
                            {
                                MessageBox.Show(Language.Msg("月结发生错误 回滚月结Job状态 发生错误" + this.jobManager.Err));
                                return -1;
                            }
                        }
                    }
                    break;
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:          //物资
                    break;
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:         //设备
                    break;
            }

            return 1;
        }

        /// <summary>
        /// 月结执行
        /// </summary>
        private int SavePHAMS()
        {
            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show(Language.Msg("确认进行月结操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }

            if (!this.SavePHAVlaid())
                return -1;

            if (!this.JudgeMonthStoreTime())
                return -1;

            //定义事务

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在进行月结处理 月结时间很长(4到5个小时).请耐心等候..."));
            Application.DoEvents();

            try
            {
                this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.itemManager.ExecMonthStore(this.privOper.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("月结操作失败" + this.itemManager.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg("月结操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            Function.ShowMsg("月结操作成功");

            #region 更新Com_Job表 设置下次月结时间

            this.job.LastTime = this.job.NextTime;
            this.job.NextTime = this.job.NextTime.AddMonths(1);

            if (this.jobManager.SetJob(this.job) != 1)
            {
                MessageBox.Show(Language.Msg("根据当前时间设置月结时间 发生错误"));
                return -1;
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 判断是否存在未结存的盘点单 进行提示
        /// </summary>
        /// <returns>允许进行 True 否则 False</returns>
        private bool SavePHAVlaid()
        {
            //判断全院的盘点情况 
            List<Neusoft.FrameWork.Models.NeuObject> checkAl = this.itemManager.QueryCheckList("0");
            if (checkAl == null)
            {
                MessageBox.Show(Language.Msg("获取盘点单信息 发生错误"));
                return false;
            }
            if (checkAl.Count > 0)
            {
                DialogResult rs = MessageBox.Show(Language.Msg("存在尚未结存的盘点单 是否继续进行月结"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    Neusoft.FrameWork.Models.NeuObject info = new Neusoft.FrameWork.Models.NeuObject();

                    Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(new ArrayList(checkAl.ToArray()), ref info);

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 月结设置
        /// </summary>
        private void Set()
        {
            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show(Language.Msg("确认进行自动/手动月结设置吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return;
            }

            if (this.cmbType.Text == "手动")
                this.job.Type = "0";
            else
                this.job.Type = "1";

            if (this.jobManager.SetJob(this.job) == -1)
            {
                MessageBox.Show(Language.Msg("Job实体保存失败"));
            }

            MessageBox.Show(Language.Msg("保存成功"));
        }

        protected override void OnLoad(EventArgs e)
        {         
            if (!this.DesignMode)
            {
                //判断操作员是否拥有权限，如果没有则不允许操作此窗口
                List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = Neusoft.HISFC.Components.Common.Classes.Function.QueryPrivList("0303",true);
                if (alPrivDept == null || alPrivDept.Count == 0)
                    return;

                this.isMonthStorePriv = true;

                this.sysTime = this.itemManager.GetDateTimeFromSysDateTime();

                this.Init();
            }

            this.cmbType.Enabled = false;

            base.OnLoad(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Save() == 1)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

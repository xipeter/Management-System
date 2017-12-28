using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Material.MonthStore
{
    /// <summary>
    /// [功能描述:设置本次月结时间]
    /// [创 建 者:王维]
    /// [创建时间:2008-03]
    /// </summary>
    public partial class ucMonthStore : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public ucMonthStore()
        {
            InitializeComponent();
        }

        #region 域变量
        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Job jobManager = new Neusoft.HISFC.BizLogic.Manager.Job();

        /// <summary>
        /// 管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.MetItem metItemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 物资管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Material.Store matManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资月结设置
        /// </summary>
        Neusoft.HISFC.Models.Base.Job job = new Neusoft.HISFC.Models.Base.Job();

        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime sysTime = System.DateTime.MinValue;

        /// <summary>
        /// 物资月结权限
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
        private Neusoft.HISFC.Models.IMA.EnumModuelType winFun = Neusoft.HISFC.Models.IMA.EnumModuelType.Material;

        /// <summary>
        /// 月结类别字符串
        /// </summary>
        private string monthStoreType = "MAT_MS";
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.job = this.jobManager.GetJob(this.monthStoreType);
            if (this.job == null)
            {
                MessageBox.Show(Language.Msg("根据物资月结编码获取物资月结设置失败"));
                return;
            }
            if (this.job.ID != "")
            {
                if (this.job.Type == "0")
                {
                    this.cmbType.Text = "手动";
                }
                else
                {
                    this.cmbType.Text = "自动";
                }
                this.dtpLast.Enabled = false;
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
        /// 本次月结时间设置
        /// </summary>
        /// <returns></returns>
        private bool JudgeMonthStoreTime()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("上次月结时间为" + this.job.LastTime.ToString() + "\n确认现在进行月结吗？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return false;
            }
            rs = MessageBox.Show(Language.Msg("是否进行月结截至时间设置 选择'是' 设置月结截止时间 选择'否' 设置月结截至时间为当前日期"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Yes)
            {
                ucMonthStoreSet uc = new ucMonthStoreSet();
                uc.SetJob(this.job.Clone(), this.sysTime.AddSeconds(-1));

                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);

                if (uc.Result == DialogResult.Cancel)
                {
                    return false;
                }

                this.job.NextTime = uc.NextTime;
            }
            else
            {
                //减一秒 保证存储过程内判断时间是否能够月结时 可以正常执行
                this.job.NextTime = this.sysTime.AddSeconds(-1);
            }

            //更改Com_Job表中的下次月结时间字段，实现月结时间可选
            if (this.jobManager.SetJob(this.job) != 1)
            {
                MessageBox.Show(Language.Msg("根据当前时间设置月结时间 发生错误"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 执行月结
        /// </summary>
        /// <returns></returns>
        public int SaveMATMS()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("确认进行月结操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign);

            if(rs == DialogResult.No)
            {
                return -1;
            }

            if(!this.SaveMATMSVlaid())
            {
                return -1;
            }

            if(!this.JudgeMonthStoreTime())
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在进行月结处理.请您等候..."));
            Application.DoEvents();

            try
            {
                this.matManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if(this.matManager.ExePrcForMonthStore(this.privOper.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("月结操作失败" + this.matManager.Err);
                    return -1;
                }
            }
            catch (System.Exception ex)
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
        /// 判断是否存在未结存的盘点单[暂时没填充内容]
        /// </summary>
        /// <returns></returns>
        private bool SaveMATMSVlaid()
        {
            //判断全院的盘点情况 
            ArrayList checkAl = this.metItemManager.QueryCheckStatic("A", "0");
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

                    Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(checkAl, ref info);

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

        /// <summary>
        /// 保存
        /// </summary>
        public virtual int Save()
        {
            switch (this.winFun)
            {
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:           //物资
                case Neusoft.HISFC.Models.IMA.EnumModuelType.All:
                    if (this.isMonthStorePriv)
                    {
                        return this.SaveMATMS();
                    }
                    break;
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy:          //药品
                    break;
                case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:         //设备
                    break;
            }

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                //判断操作员是否拥有权限，如果没有则不允许操作此窗口
                List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = Neusoft.HISFC.Components.Common.Classes.Function.QueryPrivList("0503", true);
                if (alPrivDept == null || alPrivDept.Count == 0)
                    return;

                this.isMonthStorePriv = true;

                this.sysTime = this.matManager.GetDateTimeFromSysDateTime();

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

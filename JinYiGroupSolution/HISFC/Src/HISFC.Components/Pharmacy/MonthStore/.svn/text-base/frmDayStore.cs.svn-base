using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    /// <summary>
    /// [功能描述: 日结]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// </summary>
    public partial class frmDayStore : Neusoft.FrameWork.WinForms.Forms.BaseForm
    {
        public frmDayStore()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 扩展参数
        /// </summary>
        Neusoft.FrameWork.Management.ExtendParam extManager = new ExtendParam();

        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime sysTime = System.DateTime.MinValue;

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privOper = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 窗体功能
        /// </summary>
        private Neusoft.HISFC.Models.IMA.EnumModuelType winFun = Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy;

        /// <summary>
        /// 当前库存参数
        /// </summary>
        private Neusoft.HISFC.Models.Base.ExtendInfo deptExt = new Neusoft.HISFC.Models.Base.ExtendInfo();

        /// <summary>
        /// 日结参数
        /// </summary>
        private string dayStoreTypeParam = "DayStoreLastTime";
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
                        this.dayStoreTypeParam = "DayStoreLastTime";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Material:          //物资
                        this.dayStoreTypeParam = "DayStoreLastTime";
                        break;
                    case Neusoft.HISFC.Models.IMA.EnumModuelType.Equipment:         //设备
                        this.dayStoreTypeParam = "DayStoreLastTime";
                        break;
                    default:
                        this.winFun = Neusoft.HISFC.Models.IMA.EnumModuelType.Phamacy;
                        this.dayStoreTypeParam = "DayStoreLastTime";
                        break;
                }
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        protected DateTime BeginTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpBegin.Text);
            }            
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        protected DateTime EndTime
        {
            get
            {
                return NConvert.ToDateTime(this.dtpEnd.Text);
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
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

            int iIndex = 0;
            foreach (Neusoft.HISFC.Models.Base.Department dept in alDept)
            {
                if (dept.ID == this.privDept.ID)
                {
                    break;
                }
                iIndex++;
            }

            this.cmbStoreDept.SelectedIndex = iIndex;
            #endregion

            this.GetLastTime();
        }

        /// <summary>
        /// 获取本科室上次日结时间
        /// </summary>
        /// <returns></returns>
        protected int GetLastTime()
        {
            //获取本科室上次日结时间
            this.deptExt = this.extManager.GetComExtInfo(Neusoft.HISFC.Models.Base.EnumExtendClass.DEPT, this.dayStoreTypeParam, this.privDept.ID);
            if (this.deptExt == null)
            {
                MessageBox.Show(Language.Msg("获取科室扩展属性内上次日结时间失败！"));
                return -1;
            }
            if (deptExt.ID == "")
            {
                this.deptExt.Item.ID = this.privDept.ID;
                this.deptExt.PropertyCode = this.dayStoreTypeParam;
                this.deptExt.PropertyName = "科室上次日结时间";
            }
            if (deptExt.DateProperty == System.DateTime.MinValue)
            {
                this.dtpBegin.Value = this.extManager.GetDateTimeFromSysDateTime().AddDays(-1);
                this.dtpBegin.Enabled = true;

                this.lbNotice.Visible = true;
            }
            else
            {
                this.dtpBegin.Value = this.deptExt.DateProperty;
                this.dtpBegin.Enabled = false;

                this.lbNotice.Visible = false;
            }

            return 1;
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
                        return this.SavePHAMS();
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
            if (!this.SavePHAValid())
            {
                return 0;
            }

            DialogResult result;
            //提示用户选择是否继续
            result = MessageBox.Show(Language.Msg("确认进行日结操作吗"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            if (result == DialogResult.No)
            {
                return -1;
            }

            //定义事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在进行日结处理 日结时间很长.请耐心等候..."));
            Application.DoEvents();

            try
            {
                this.itemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (this.itemManager.ExecDayStore(this.privDept.ID,this.BeginTime,this.EndTime,this.privOper.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    Function.ShowMsg("日结操作失败" + this.itemManager.Err);
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                Function.ShowMsg("日结操作失败" + ex.Message);
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            Function.ShowMsg("日结操作成功");

            #region 更新扩展表 设置下次日结时间

            this.deptExt.DateProperty = this.EndTime;

            this.dtpBegin.Value = this.EndTime;
            this.dtpEnd.Value = this.dtpBegin.Value.AddDays(1);

            if (this.extManager.SetComExtInfo(this.deptExt) != 1)
            {
                MessageBox.Show(Language.Msg("根据当前时间设置日结时间 发生错误"));
                return -1;
            }

            #endregion

            return 1;
        }

        /// <summary>
        /// 检验是否可以进行日结
        /// </summary>
        /// <returns></returns>
        private bool SavePHAValid()
        {
            if (this.BeginTime >= this.EndTime)
            {
                MessageBox.Show(Language.Msg("请设置起始时间大于终止时间"));
                return false;
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                //判断操作员是否拥有权限，如果没有则不允许操作此窗口
                List<Neusoft.FrameWork.Models.NeuObject> alPrivDept = Neusoft.HISFC.Components.Common.Classes.Function.QueryPrivList("0303", true);
                if (alPrivDept == null || alPrivDept.Count == 0)
                    return;

                this.sysTime = this.itemManager.GetDateTimeFromSysDateTime();

                this.privDept = ((Neusoft.HISFC.Models.Base.Employee)this.itemManager.Operator).Dept;
                this.privOper = this.itemManager.Operator;

                this.Init();
            }

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

        private void cmbStoreDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbStoreDept.Tag == null || this.cmbStoreDept.Tag.ToString() == "")
            {
                return;
            }

            this.privDept.ID = this.cmbStoreDept.Tag.ToString();

            this.GetLastTime();
        }
    }
}
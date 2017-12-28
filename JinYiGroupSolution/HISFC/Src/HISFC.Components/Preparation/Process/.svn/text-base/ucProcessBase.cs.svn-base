using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Preparation.Process
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 生产工艺流程录入基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-11]<br></br>
    /// <说明>
    /// </说明>
    /// </summary>
    public partial class ucProcessBase : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucProcessBase()
        {
            InitializeComponent();
        }

        public event System.EventHandler ProcessFinished;

        #region 域变量

        /// <summary>
        /// 主键 Control 值 Process实体
        /// </summary>
        protected System.Collections.Hashtable hsProcessItem = new System.Collections.Hashtable();

        /// <summary>
        /// 主键ProcessItem 值 Control
        /// </summary>
        protected System.Collections.Hashtable hsProcessControl = new System.Collections.Hashtable();

        /// <summary>
        /// 制剂头信息
        /// </summary>
        protected Neusoft.HISFC.Models.Preparation.Preparation preparation = null;

        protected string strPreparation = "制剂成品：{0}  规格：{1}  批号：{2}  计划量：{3}  单位：{4}";

        private DialogResult rs = DialogResult.Cancel;

        /// <summary>
        /// 本次制剂成品对应的工艺流程信息
        /// </summary>
        private List<Neusoft.HISFC.Models.Preparation.Process> processList = null;

        #endregion

        #region 属性

        /// <summary>
        /// 获取本次制剂成品对应的工艺流程信息
        /// </summary>
        public List<Neusoft.HISFC.Models.Preparation.Process> ProcessList
        {
            get
            {
                return this.processList;
            }
        }

        #endregion

        public DialogResult Result
        {
            get
            {
                return rs;
            }
        }

        public virtual int SetPreparation(Neusoft.HISFC.Models.Preparation.Preparation preparation)
        {           
            Neusoft.HISFC.BizLogic.Pharmacy.Preparation pprManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();
            this.processList = pprManager.QueryProcess(preparation.PlanNO, preparation.Drug.ID, ((int)preparation.State).ToString());
            if (this.processList != null && this.processList.Count > 0)
            {
                Function.SetProcessItem(this.processList, this.hsProcessControl);
            }

            this.preparation = preparation;

            return 1;
        }

        /// <summary>
        /// 工艺流程保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public virtual int SaveProcess()
        {
            return this.SaveProcess(true);
        }

        /// <summary>
        /// 工艺流程保存
        /// </summary>
        /// <param name="beginTransaction">是否开启事务 如False,则认为事务由外部启动 不提交/不提示成功/不自动打印</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public virtual int SaveProcess(bool beginTransaction)
        {
            if (Function.GetProcessItemList(this.panelInput, ref this.hsProcessItem) == 1)
            {
                foreach (Neusoft.HISFC.Models.Preparation.Process info in this.hsProcessItem.Values)
                {
                    info.Preparation = this.preparation.Clone();
                }
            }

            if (beginTransaction)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            }

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.HISFC.BizLogic.Pharmacy.Preparation pprManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();
            //pprManager.SetTrans(t.Trans);

            DateTime sysTime = pprManager.GetDateTimeFromSysDateTime();

            foreach (Neusoft.HISFC.Models.Preparation.Process p in this.hsProcessItem.Values)
            {
                p.Oper.OperTime = sysTime;
                p.Oper.ID = pprManager.Operator.ID;

                if (pprManager.SetProcess(p) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("保存制剂工艺流程信息失败" + pprManager.Err);
                }
            }

            if (beginTransaction)
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("工艺流程执行信息保存成功");

                this.PrintProcess();
            }

            return 1;
        }

        public virtual int PrintProcess()
        {
            return 1;
        }


        /// <summary>
        /// 关闭
        /// </summary>
        protected void Close()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.rs = DialogResult.Cancel;

            this.Close();
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SaveProcess() == 1)
            {
                this.rs = DialogResult.OK;

                if (ProcessFinished != null)
                {
                    this.ProcessFinished(this, System.EventArgs.Empty);
                }

                this.Close();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (MessageBox.Show("是否确认退出？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }

                return true;
            }
            //if (keyData == Keys.Enter)
            //{
            //    System.Windows.Forms.SendKeys.Send("{Tab}");
            //}

            return base.ProcessDialogKey(keyData);
        }
    }
}

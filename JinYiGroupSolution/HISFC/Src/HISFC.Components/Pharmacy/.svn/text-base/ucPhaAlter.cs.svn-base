using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品警戒线]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// <修改记录>
    ///    1.增加最高最低库存天数有效性校验 by Sunjh 2010-9-6 {9ED65013-E342-48b6-BB6B-6AB2D7CD5058}
    /// </修改记录>
    /// </summary>
    public partial class ucPhaAlter : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPhaAlter()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 库房编码
        /// </summary>
        private string deptCode;

        /// <summary>
        /// 根据日消耗计算 待入库信息
        /// </summary>
        private ArrayList alInfo;

        /// <summary>
        /// 消耗明细信息
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> expandList = new List<Neusoft.FrameWork.Models.NeuObject>();

        /// <summary>
        /// 是否使用消耗列表
        /// </summary>
        private bool isExpandList = false;

        /// <summary>
        /// 点击返回值
        /// </summary>
        public DialogResult rs = DialogResult.Cancel;

        #endregion

        #region 属性

        /// <summary>
        /// 库房编码
        /// </summary>
        public string DeptCode
        {
            set
            {
                this.deptCode = value;
            }
        }

        /// <summary>
        /// 根据日消耗计算 待入库信息
        /// </summary>
        public ArrayList ApplyInfo
        {
            get
            {
                if (this.alInfo == null)
                    this.alInfo = new ArrayList();
                return this.alInfo;
            }
        }

        /// <summary>
        /// 消耗明细信息
        /// </summary>
        public List<Neusoft.FrameWork.Models.NeuObject> ExpandList
        {
            get
            {
                return this.expandList;
            }
        }

        /// <summary>
        /// 是否使用消耗列表  {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 更改属性名称
        /// </summary>
        public bool IsQueryExpandData
        {
            get
            {
                return this.isExpandList;
            }
            set
            {
                this.isExpandList = value;

                if (value)
                {
                    this.rbAllDept.Visible = false;
                }
                else
                {
                    this.rbAllDept.Visible = true;
                }
            }
        }

        /// <summary>
        /// 点击返回值
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.rs;
            }
            set
            {
                this.rs = value;
            }
        }

        /// <summary>
        /// 统计起始时间
        /// </summary>
        private DateTime DtBegin
        {
            get
            {
                return NConvert.ToDateTime(this.dtpBegin.Text);
            }
        }

        /// <summary>
        /// 统计截止时间
        /// </summary>
        private DateTime DtEnd
        {
            get
            {
                return NConvert.ToDateTime(this.dtpEnd.Text);
            }
        }

        /// <summary>
        /// 最高库存天数
        /// </summary>
        private int MaxAlterDays
        {
            get
            {
                return NConvert.ToInt32(this.txtMaxDays.Text);
            }
        }

        /// <summary>
        /// 最低库存天数
        /// </summary>
        private int MinAlterDays
        {
            get
            {
                return NConvert.ToInt32(this.txtMinDays.Text);
            }
        }

        #endregion


        /// <summary>
        /// 根据所赋值的库房编码 设置信息显示
        /// </summary>
        public void SetData()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant consMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptCons = consMgr.QueryDeptConstant(this.deptCode);
            if (deptCons == null)
            {
                MessageBox.Show(Language.Msg("获取科室常数发生错误! \n" + consMgr.Err));
                return;
            }
            this.dtpEnd.Value = consMgr.GetDateTimeFromSysDateTime().Date.AddDays(1).AddSeconds(-1);
            this.dtpBegin.Value = this.dtpEnd.Value.AddDays(-deptCons.ReferenceDays);
            this.txtMaxDays.Text = deptCons.StoreMaxDays.ToString();
            this.txtMinDays.Text = deptCons.StoreMinDays.ToString();
            this.lbIntervalDays.Text = deptCons.ReferenceDays.ToString() + "天";
        }

        /// <summary>
        /// 判断是否允许保存
        /// </summary>
        /// <returns>成功返回True  否则返回False</returns>
        protected bool SaveValid()
        {
            if (this.MaxAlterDays == 0 || this.MinAlterDays == 0)
            {
                MessageBox.Show("库存天数警戒线不能为零");
                return false;
            }
            if (this.MaxAlterDays < this.MinAlterDays)
            {
                MessageBox.Show("最高库存天数不能小于最低库存天数");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 确认参数设置 日消耗处理
        /// 
        /// {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 更改函数名称及调用函数
        /// </summary>
        protected void QueryDayAlterList()
        {
            if (this.SaveValid())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在按照日消耗进行检索 请稍候...");
                Application.DoEvents();

                Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

                this.alInfo = itemMgr.QueryDrugListByDayAlter(this.deptCode, this.DtBegin, this.DtEnd, this.MaxAlterDays, this.MinAlterDays,this.rbAllDept.Checked);
                if (this.alInfo == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("检索日消耗信息发生错误" + itemMgr.Err);
                    return;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 科室消耗信息统计
        /// 
        ///  {F4D82F23-CCDC-45a6-86A1-95D41EF856B8} 更改函数名称及调用函数
        /// </summary>
        protected void QueryDeptExpandData()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在进行药品消耗统计 请稍候...");
            Application.DoEvents();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            this.expandList = itemManager.FindByExpand(this.deptCode,this.DtBegin, this.DtEnd);
            if (this.expandList == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("获取科室消耗信息发生错误！") + itemManager.Err);
                return;
            }

            foreach (Neusoft.FrameWork.Models.NeuObject info in this.expandList)
            {
                info.User02 = (System.Math.Ceiling(NConvert.ToDecimal(info.User01) / (this.DtEnd - this.DtBegin).Days * NConvert.ToDecimal(this.txtMinDays.Text))).ToString();
                info.User03 = (System.Math.Ceiling(NConvert.ToDecimal(info.User01) / (this.DtEnd - this.DtBegin).Days  * NConvert.ToDecimal(this.txtMaxDays.Text))).ToString();
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        public void Close()
        {
            if (this.ParentForm != null)
                this.ParentForm.Close();
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public new void Focus()
        {
            this.dtpBegin.Focus();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (this.DtEnd < this.DtBegin)
            {
                MessageBox.Show("最高库存天数不能小于最低库存天数!");
                this.dtpEnd.Text = this.DtBegin.ToString();
            }
            this.lbIntervalDays.Text = (this.DtEnd - this.DtBegin).Days + "天";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.DtEnd < this.DtBegin)
            {
                MessageBox.Show("统计起始日期不能大于统计截止日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //增加最高最低库存天数有效性校验 by Sunjh 2010-9-6 {9ED65013-E342-48b6-BB6B-6AB2D7CD5058}
            if (this.MaxAlterDays < this.MinAlterDays)
            {
                MessageBox.Show("最高库存天数不能小于最低库存天数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.isExpandList)
            {                
                this.QueryDeptExpandData();
            }
            else
            {
                this.txtMinDays.Enabled = true;
                this.txtMinDays.Enabled = true;
                this.QueryDayAlterList();
            }

            this.rs = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.rs = DialogResult.Cancel;

            this.Close();
        }
    }
}

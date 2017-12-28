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

namespace Neusoft.HISFC.Components.Material
{
    /// <summary>
    /// [功能描述: 药品警戒线]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPhaAlter : UserControl
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
            Neusoft.HISFC.BizLogic.Material.Baseset baseManager = new Neusoft.HISFC.BizLogic.Material.Baseset();
            Neusoft.HISFC.Models.Material.MaterialStorage deptCons = baseManager.QueryStorageInfo(this.deptCode);
            if (deptCons == null)
            {
                MessageBox.Show("获取科室常数发生错误! \n" + baseManager.Err);
                return;
            }
            this.dtpEnd.Value = baseManager.GetDateTimeFromSysDateTime().Date;
            this.dtpBegin.Value = this.dtpEnd.Value.AddDays(-deptCons.ReferenceDays);
            this.txtMaxDays.Text = deptCons.MaxDays.ToString();
            this.txtMinDays.Text = deptCons.MinDays.ToString();
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
        /// </summary>
        public int Save()
        {
            if (this.SaveValid())
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在按照日消耗进行检索 请稍候...");
                Application.DoEvents();
                Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();
                this.alInfo = storeManager.FindByAlter("1", this.deptCode, this.DtBegin, this.DtEnd, this.MaxAlterDays, this.MinAlterDays);
                if (this.alInfo == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    MessageBox.Show("按日消耗查找项目失败！");
                    return -1;
                }
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            else
            {
                return -1;
            }
            return 1;
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
                this.dtpEnd.Text = this.DtBegin.ToString();
            }
            this.lbIntervalDays.Text = (this.DtEnd - this.DtBegin).Days + "天";
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

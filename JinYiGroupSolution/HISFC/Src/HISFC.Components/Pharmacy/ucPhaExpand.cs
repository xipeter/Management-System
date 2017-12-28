using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Pharmacy
{
    /// <summary>
    /// [功能描述: 药品日消耗设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucPhaExpand : UserControl
    {
        public ucPhaExpand()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 统计药房
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept;

        /// <summary>
        /// 统计药品
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject drug;

        /// <summary>
        /// 参考天数 
        /// </summary>
        private int intervalDays = 7;

        /// <summary>
        /// 药品帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper drugHelpter = null;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 是否只对患者入出库(药房发退药)情况进行统计
        /// </summary>
        private bool isOnlyPatientInOut = false;

        #endregion

        #region 属性

        /// <summary>
        /// 统计药房
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            set
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 统计药品
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Drug
        {
            set
            {
                this.drug = value;
            }
        }

        /// <summary>
        /// 参考天数
        /// </summary>
        public int IntervalDays
        {
            set
            {
                this.intervalDays = value;
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
                DateTime dateTime = NConvert.ToDateTime(this.dtpEnd.Text);
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            }
        }

        /// <summary>
        /// 是否只对患者入出库(药房发退药)情况进行统计
        /// </summary>
        public bool IsOnlyPatientInOut
        {
            get
            {
                return this.isOnlyPatientInOut;
            }
            set
            {
                this.isOnlyPatientInOut = value;
            }
        }

        #endregion

     
        /// <summary>
        /// 初始化  外部调用初始化
        /// </summary>
        /// <returns>成功返回1 发生错误返回-1</returns>
        public int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = deptMgr.GetDeptmentAll();
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取药房列表发生错误" + deptMgr.Err));
                return -1;
            }
            ArrayList alDept = new ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department info in al)
            {
                if (info.DeptType.ID.ToString() == "P" || info.DeptType.ID.ToString() == "PI")
                {
                    alDept.Add(info);
                }
            }

            Neusoft.FrameWork.Models.NeuObject deptAll = new Neusoft.FrameWork.Models.NeuObject();
            deptAll.ID = "AAAA";
            deptAll.Name = "全部";
            alDept.Insert(0, deptAll);

            this.cmbDept.AddItems(alDept);
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            List<Neusoft.HISFC.Models.Pharmacy.Item> listDrug = itemMgr.QueryItemAvailableList(true);
            if (listDrug == null)
            {
                MessageBox.Show(Language.Msg("获取药品列表发生错误" + itemMgr.Err));
                return -1;
            }
            ArrayList alDrug = new ArrayList();
            Neusoft.FrameWork.Models.NeuObject drugInfo = new Neusoft.FrameWork.Models.NeuObject();
            foreach (Neusoft.HISFC.Models.Pharmacy.Item info in listDrug)
            {
                drugInfo = new Neusoft.FrameWork.Models.NeuObject();
                drugInfo.ID = info.ID;
                drugInfo.Name = info.Name;
                drugInfo.Memo = info.Specs;
                drugInfo.User01 = info.MinUnit;

                alDrug.Add(drugInfo);
            }

            this.cmbItem.AddItems(alDrug);
            this.drugHelpter = new Neusoft.FrameWork.Public.ObjectHelper(alDrug);
            return 1;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (this.ParentForm != null)
                this.ParentForm.Close();
        }

        /// <summary>
        /// 设置信息
        /// </summary>
        public void SetData(Neusoft.FrameWork.Models.NeuObject dept, Neusoft.FrameWork.Models.NeuObject drug, int intervalDays)
        {
            Neusoft.FrameWork.Management.DataBaseManger databaseMgr = new Neusoft.FrameWork.Management.DataBaseManger();
            DateTime sysTime = databaseMgr.GetDateTimeFromSysDateTime().Date;

            this.dtpEnd.Value = sysTime;
            this.dtpEnd.Text = sysTime.ToString();
            this.dtpBegin.Value = sysTime.AddDays(-intervalDays);
            this.dtpBegin.Text = sysTime.AddDays(-intervalDays).ToString();

            if (dept != null && dept.ID != "")
            {
                this.Dept = dept;
                this.cmbDept.Text = dept.Name;
                this.cmbDept.Tag = dept.ID;
            }

            if (drug != null && drug.ID != "")
            {
                this.Drug = drug;
                this.cmbItem.Text = drug.Name;
                this.cmbItem.Tag = drug.ID;
            }

            this.lbItemInfo.Text = string.Format("药品编码：{0} 规格：{1} 单位：{2}", drug.Name, drug.Memo, drug.User01);

            this.Query();

        }

        /// <summary>
        /// 查询
        /// </summary>
        public int Query()
        {
            if (this.dept == null)
            {
                MessageBox.Show(Language.Msg("请设置查询药房"));
                return -1;
            }
            if (this.drug == null)
            {
                MessageBox.Show(Language.Msg("请设置查询药品"));
                return -1;
            }
            if (this.deptHelper != null)
                this.dept = this.deptHelper.GetObjectFromID(this.cmbDept.Tag.ToString());
            if (this.drugHelpter != null)
                this.drug = this.drugHelpter.GetObjectFromID(this.cmbItem.Tag.ToString());

            int intervalDays = (this.DtEnd - this.DtBegin).Days;

            this.lbItemInfo.Text = string.Format("药品编码：{0} 规格：{1} 单位：{2}", this.drug.Name, this.drug.Memo, this.drug.User01);

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemMgr = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            decimal totOutNum = 0;
            decimal perDayOutNum = 0;
            if (this.isOnlyPatientInOut)
            {
                if (itemMgr.FindByExpand(this.dept.ID, this.drug.ID, intervalDays, this.DtEnd, true, out totOutNum, out perDayOutNum) == -1)
                {
                    MessageBox.Show("统计药品日消耗信息失败！" + itemMgr.Err);
                    return -1;
                }
            }
            else
            {
                if (itemMgr.FindByExpand(this.dept.ID, this.drug.ID, intervalDays, this.DtEnd, out totOutNum, out perDayOutNum) == -1)
                {
                    MessageBox.Show("统计药品日消耗信息失败！" + itemMgr.Err);
                    return -1;
                }
            }

            this.lbExpandInfo.Text = string.Format("参考天数：{0}天 出库总量：{1} 日消耗：{2}", intervalDays.ToString(), totOutNum.ToString("N"), perDayOutNum.ToString("N"));

            return 1;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Query() == -1)
                return;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (this.DtEnd < this.DtBegin)
                this.dtpEnd.Value = this.dtpBegin.Value;
        }
    }
}

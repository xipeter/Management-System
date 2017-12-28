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

namespace Neusoft.HISFC.Components.Material
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
        /// 统计科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject dept;

        /// <summary>
        /// 统计物品
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject item;

        /// <summary>
        /// 参考天数 
        /// </summary>
        private int intervalDays = 7;

        /// <summary>
        /// 物品帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper itemHelper = null;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 是否只对患者入出库(库房发退药)情况进行统计
        /// </summary>
        private bool isOnlyPatientInOut = false;

        #endregion

        #region 属性

        /// <summary>
        /// 统计库房
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Dept
        {
            set
            {
                this.dept = value;
            }
        }

        /// <summary>
        /// 统计物品
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject Item
        {
            set
            {
                this.item = value;
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
                return NConvert.ToDateTime(this.dtpEnd.Text);
            }
        }

        /// <summary>
        /// 是否只对患者入出库(库房发退药)情况进行统计
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
        /// 初始化
        /// </summary>
        /// <returns>成功返回1 发生错误返回-1</returns>
        public int Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptMgr = new Neusoft.HISFC.BizLogic.Manager.Department();
            ArrayList al = deptMgr.GetDeptmentAll();
            if (al == null)
            {
                MessageBox.Show("获取库房列表发生错误" + deptMgr.Err);
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

            Neusoft.HISFC.BizLogic.Material.MetItem itemManager = new Neusoft.HISFC.BizLogic.Material.MetItem();
            Neusoft.HISFC.Models.Material.MaterialItem listItem = itemManager.GetMetItemByValid("1");
            if (listItem == null)
            {
                MessageBox.Show("获取物品列表发生错误" + itemManager.Err);
                return -1;
            }
            ArrayList alItem = new ArrayList();
            alItem.Add(listItem);
            this.cmbItem.AddItems(alItem);
            this.itemHelper = new Neusoft.FrameWork.Public.ObjectHelper(alItem);
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
        public void SetData(Neusoft.FrameWork.Models.NeuObject dept, Neusoft.FrameWork.Models.NeuObject item, int intervalDays)
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

            if (item != null && item.ID != "")
            {
                this.item = item;
                this.cmbItem.Text = item.Name;
                this.cmbItem.Tag = item.ID;
            }

            this.lbItemInfo.Text = string.Format("物品编码：{0} 规格：{1} 单位：{2}", item.Name, item.Memo, item.User01);

            this.Query();

        }

        /// <summary>
        /// 查询
        /// </summary>
        public int Query()
        {
            if (this.dept == null)
            {
                MessageBox.Show("请设置查询科室");
                return -1;
            }
            if (this.item == null)
            {
                MessageBox.Show("请设置查询物品");
                return -1;
            }
            if (this.deptHelper != null)
                this.dept = this.itemHelper.GetObjectFromID(this.cmbDept.Tag.ToString());
            if (this.itemHelper != null)
                this.item = this.itemHelper.GetObjectFromID(this.cmbItem.Tag.ToString());

            int intervalDays = (this.DtEnd - this.DtBegin).Days;

            this.lbItemInfo.Text = string.Format("物品编码：{0} 规格：{1} 单位：{2}", this.item.Name, this.item.Memo, this.item.User01);

            Neusoft.HISFC.BizLogic.Material.MetItem itemMgr = new Neusoft.HISFC.BizLogic.Material.MetItem();
            decimal totOutNum = 0;
            decimal perDayOutNum = 0;

            #region 暂时屏掉 以后根据实际需求继续完善
            /*
			if (this.isOnlyPatientInOut)
			{
				
				if (itemMgr.FindByExpand(this.dept.ID, this.drug.ID, intervalDays, this.DtEnd, true, out totOutNum, out perDayOutNum) == -1)
				{
					MessageBox.Show("统计物品日消耗信息失败！" + itemMgr.Err);
					return -1;
				}
			}
			else
			{
				if (itemMgr.FindByExpand(this.dept.ID, this.drug.ID, intervalDays, this.DtEnd, out totOutNum, out perDayOutNum) == -1)
				{
					MessageBox.Show("统计物品日消耗信息失败！" + itemMgr.Err);
					return -1;
				}

			}
			*/
            #endregion

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

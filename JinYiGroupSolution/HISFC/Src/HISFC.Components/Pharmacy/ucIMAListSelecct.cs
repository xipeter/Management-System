using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Management;

namespace UFC.Pharmacy
{
    /// <summary>
    /// [功能描述: 进销存单据选择基类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucIMAListSelecct : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucIMAListSelecct()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.neuSpread1_Sheet1.DefaultStyle.Locked = true;

                this.Query();
            }
        }

        public delegate void SelectListHandler(string listCode, string state, Neusoft.NFC.Object.NeuObject targetDept);

        public event SelectListHandler SelecctListEvent;

        #region 域变量

        /// <summary>
        /// 科室信息
        /// </summary>
        private Neusoft.NFC.Object.NeuObject deptInfo = new Neusoft.NFC.Object.NeuObject();

        /// <summary>
        /// 二级权限类型
        /// </summary>
        private string class2Priv = "0310";

        /// <summary>
        /// 状态
        /// </summary>
        private string state = "2";

        /// <summary>
        /// 入/出库状态集
        /// </summary>
        private System.Collections.Hashtable hsInOutState = null;

        /// <summary>
        /// 采购状态集
        /// </summary>
        private System.Collections.Hashtable hsStockState = null;

        /// <summary>
        /// 入库单据显示时 默认减少时间间隔
        /// </summary>
        private int inIntervalDays = 30;

        /// <summary>
        /// 出库单据显示时 默认减少时间间隔
        /// </summary>
        private int outIntervalDays = 15;

        /// <summary>
        /// 采购单据显示时 默认减少时间间隔
        /// </summary>
        private int stockIntervalDays = 30;

        /// <summary>
        /// 过滤的权限类
        /// </summary>
        private System.Collections.Hashtable markPrivType = null;

        /// <summary>
        /// 当前操作的权限类型
        /// </summary>
        private Neusoft.NFC.Object.NeuObject privType = null;
      
        #endregion

        #region 属性

        /// <summary>
        /// 科室信息
        /// </summary>
        public Neusoft.NFC.Object.NeuObject DeptInfo
        {
            get
            {
                return this.deptInfo;
            }
            set
            {
                this.deptInfo = value;

                if (value != null)
                {
                    this.lbInfo.Text = value.Name + " - 单据列表";
                }
            }
        }

        /// <summary> 
        /// 二级权限 单据类型 0310入库 0320出库  0312采购
        /// </summary>
        public string Class2Priv
        {
            set
            {
                this.class2Priv = value;

                switch (value)
                {
                    case "0310":    //入库
                        this.rbIn.Checked = true;
                        break;
                    case "0320":    //c出库
                        this.rbOut.Checked = true;
                        break;
                    case "0312":    //采购
                        this.rbStock.Checked = true;
                        break;
                }

                this.SetPrivState();
            }
        }

        /// <summary>
        /// 是否显示功能按钮
        /// </summary>
        public bool IsShowFunButton
        {
            get
            {
                return this.btnOK.Visible;
            }
            set
            {
                this.btnOK.Visible = value;
                this.btnCancel.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示类型选择CheckBox
        /// </summary>
        public bool IsShowTypeCheck
        {
            get
            {
                return this.rbIn.Visible;
            }
            set
            {
                this.rbIn.Visible = value;
                this.rbOut.Visible = value;
                this.rbStock.Visible = value;
            }
        }

        /// <summary>
        /// 是否可以选择状态
        /// </summary>
        public bool IsSelectState
        {
            get
            {
                return this.cmbState.Enabled;
            }
            set
            {
                this.cmbState.Enabled = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;

                this.SetPrivState();
            }
        }

        /// <summary>
        /// 入库单据显示时 默认减少时间间隔
        /// </summary>
        public int InIntervalDays
        {
            get
            {
                return this.inIntervalDays;
            }
            set
            {
                this.inIntervalDays = value;
            }
        }

        /// <summary>
        /// 出库单据显示时 默认减少时间间隔
        /// </summary>
        public int OutIntervalDays
        {
            get
            {
                return outIntervalDays;
            }
            set
            {
                outIntervalDays = value;
            }
        }

        /// <summary>
        /// 采购单据显示时 默认减少时间间隔
        /// </summary>
        public int StockIntervalDays
        {
            get
            {
                return stockIntervalDays;
            }
            set
            {
                stockIntervalDays = value;
            }
        }

        /// <summary>
        /// 获取起始时间
        /// </summary>
        public DateTime BeginDate
        {
            get
            {
                return Neusoft.NFC.Function.NConvert.ToDateTime(this.dtpBegin.Text).Date;
            }
        }

        /// <summary>
        /// 获取终止时间
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return Neusoft.NFC.Function.NConvert.ToDateTime(this.dtpEnd.Text).Date.AddDays(1);
            }
        }

        /// <summary>
        /// 过滤的权限类
        /// </summary>
        public System.Collections.Hashtable MarkPrivType
        {
            get
            {
                return this.markPrivType;
            }
            set
            {
                this.markPrivType = value;
            }
        }

        /// <summary>
        /// 入出库状态集
        /// </summary>
        public System.Collections.Hashtable InOutStateCollection
        {
            get
            {
                return this.hsInOutState;
            }
            set
            {
                this.hsInOutState = value;
            }
        }

        /// <summary>
        /// 采购状态集
        /// </summary>
        public System.Collections.Hashtable StockStateCollection
        {
            get
            {
                return this.hsStockState;
            }
            set
            {
                this.hsStockState = value;
            }
        }

        /// <summary>
        /// 当前操作的权限类型
        /// </summary>
        public Neusoft.NFC.Object.NeuObject PrivType
        {
            get
            {
                return privType;
            }
            set
            {
                privType = value;
            }
        }

        #endregion

        /// <summary>
        /// 根据二级权限与状态设置显示
        /// </summary>
        private void SetPrivState()
        {
            switch(this.class2Priv)
            {
                case "0310":            //入库
                case "0320":            //出库
                    string[] stateCollection = new string[this.hsInOutState.Count];
                    ((System.Collections.ICollection)this.hsInOutState.Values).CopyTo(stateCollection,0);
                    this.cmbState.DataSource = stateCollection;

                    if (this.hsInOutState.ContainsKey(this.state))
                        this.cmbState.Text = this.hsInOutState[this.state].ToString();

                    break;
                case "0312":            //采购

                    string[] stockStateCollection = new string[this.hsStockState.Count];
                    ((System.Collections.ICollection)this.hsStockState.Values).CopyTo(stockStateCollection, 0);
                    this.cmbState.DataSource = stockStateCollection;

                    if (this.hsStockState.ContainsKey(this.state))
                        this.cmbState.Text = this.hsStockState[this.state].ToString();

                    break;
            }           
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            Neusoft.NFC.Management.DataBaseManger dataManager = new Neusoft.NFC.Management.DataBaseManger();
            DateTime sysTime = dataManager.GetDateTimeFromSysDateTime();

            if (this.rbOut.Checked)
                this.dtpBegin.Value = sysTime.AddDays(-this.outIntervalDays);
            if (this.rbIn.Checked)
                this.dtpBegin.Value = sysTime.AddDays(-this.inIntervalDays);
            if (this.rbStock.Checked)
                this.dtpBegin.Value = sysTime.AddDays(-this.stockIntervalDays);

            this.dtpEnd.Value = sysTime;

            #region 加载入出库/采购状态集

            this.hsInOutState = new System.Collections.Hashtable();
            this.hsInOutState.Add("0", "申请");
            this.hsInOutState.Add("1", "审批");
            this.hsInOutState.Add("2", "核准");

            this.hsStockState = new System.Collections.Hashtable();
            this.hsStockState.Add("0", "计划");
            this.hsStockState.Add("1", "采购");
            this.hsStockState.Add("2", "审核");
            this.hsStockState.Add("3", "入库");

            #endregion

            this.IsShowTypeCheck = false;

            this.Clear();
        }

        /// <summary>
        /// 设定Fp的显示
        /// </summary>
        /// <param name="fpLabel">列名称显示</param>
        /// <param name="fpVisible">有效性显示</param>
        /// <param name="fpWidth">列宽度</param>
        public void InitFp(string[] fpLabel, bool[] fpVisible, float[] fpWidth)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Columns.Count; i++)
            {
                if (fpLabel.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Label = fpLabel[i];
                if (fpVisible.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Visible = fpVisible[i];
                if (fpWidth.Length > i)
                    this.neuSpread1_Sheet1.Columns[i].Width = fpWidth[i];
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        private void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public virtual void Query()
        {
            this.Clear();
            
            if (this.rbIn.Checked)
            {
                this.QueryIn();
                return;
            }
            if (this.rbOut.Checked)
            {
                this.QueryOut();
                return;
            }
            if (this.rbStock.Checked)
            {
                this.QueryStock();
                return;
            }
        }

        /// <summary>
        /// 入库单据查询
        /// </summary>
        protected virtual void QueryIn()
        {
         
        }

        /// <summary>
        /// 出库单据查询
        /// </summary>
        protected virtual void QueryOut()
        {
        
        }

        /// <summary>
        /// 采购单据查询
        /// </summary>
        protected virtual void QueryStock()
        {
           
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.class2Priv)
            {
                case "0310":            //入库
                case "0320":            //出库

                    foreach(string strInOutState in this.hsInOutState.Keys)
                    {
                        if ((this.hsInOutState[strInOutState] as string) == this.cmbState.Text)
                        {
                            this.state = strInOutState;
                            return;
                        }
                    }

                    break;
                case "0312":            //采购

                    foreach (string strStockState in this.hsStockState.Keys)
                    {
                        if ((this.hsStockState[strStockState] as string) == this.cmbState.Text)
                        {
                            this.state = strStockState;
                            return;
                        }
                    }

                    break;
            }           
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
                return;

            if (this.SelecctListEvent != null)
            {
                string listCode = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColList].Text;
                Neusoft.NFC.Object.NeuObject company = new Neusoft.NFC.Object.NeuObject();
                company.ID = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColTargetID].Text;
                company.Name = this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColTargetName].Text;

                this.SelecctListEvent(listCode, this.State, company);
            }

            this.ParentForm.Close();

        }


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.Query();
        }


        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.ParentForm.Close();
        }


        /// <summary>
        /// 列设置
        /// </summary>
        protected enum ColumnSet
        {
            /// <summary>
            /// 单据号
            /// </summary>
            ColList,
            /// <summary>
            /// 送货单号
            /// </summary>
            ColDeliveryNO,
            /// <summary>
            /// 类型
            /// </summary>
            ColType,
            /// <summary>
            /// 目标单位
            /// </summary>
            ColTargetName,
            /// <summary>
            /// 目标单位编码
            /// </summary>
            ColTargetID
        }       
    }


}

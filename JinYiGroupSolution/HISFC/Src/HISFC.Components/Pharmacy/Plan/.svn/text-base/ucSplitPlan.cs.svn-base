using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.Plan
{
    /// <summary>
    /// [功能描述: 药品采购计划拆分]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-12]<br></br>
    /// </summary>
    public partial class ucSplitPlan : UserControl
    {
        public ucSplitPlan()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 原始计划信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.StockPlan originalStockPlan = null;

        /// <summary>
        /// 拆分后计划信息
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.StockPlan> splitPlan = null;

        /// <summary>
        /// 供货公司数据组
        /// </summary>
        private ArrayList alCompany = new ArrayList();

        /// <summary>
        /// 窗口结果
        /// </summary>
        private DialogResult result = DialogResult.Cancel;
        #endregion

        #region 属性

        /// <summary>
        /// 原始计划信息
        /// </summary>
        public Neusoft.HISFC.Models.Pharmacy.StockPlan OriginalStockPlan
        {
            get
            {
                return this.originalStockPlan;
            }
            set
            {
                this.originalStockPlan = value;

                this.SetPlanInfo();
            }
        }

        /// <summary>
        /// 拆分后计划信息
        /// </summary>
        public List<Neusoft.HISFC.Models.Pharmacy.StockPlan> SplitPlan
        {
            get
            {
                return this.splitPlan;
            }
            set
            {
                this.splitPlan = value;
            }
        }

        /// <summary>
        /// 结果
        /// </summary>
        public DialogResult Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            this.alCompany = phaConsManager.QueryCompany("1");
            if (this.alCompany == null)
            {
                MessageBox.Show(Language.Msg("获取供货公司列表发生错误") + phaConsManager.Err);
                return;
            }

            this.neuSpread1_Sheet1.Columns[0].Locked = true;
            this.neuSpread1_Sheet1.Columns[2].Locked = true;
        }

        /// <summary>
        /// 原始计划信息显示
        /// </summary>
        private void SetPlanInfo()
        {
            this.lbOriginalPlan.Text = string.Format("商品名称: {0} 规格: {1} 计划数量: {2} 单位: {3}", this.originalStockPlan.Item.Name, 
                this.originalStockPlan.Item.Specs, (this.originalStockPlan.StockApproveQty / this.originalStockPlan.Item.PackQty).ToString(), 
                this.originalStockPlan.Item.PackUnit);

            this.neuSpread1_Sheet1.Rows.Count = 0;

            this.neuSpread1_Sheet1.Rows.Add(0, 1);
            this.neuSpread1_Sheet1.Cells[0, 0].Text = this.originalStockPlan.Company.Name;
            this.neuSpread1_Sheet1.Cells[0, 1].Text = (this.originalStockPlan.StockApproveQty / this.originalStockPlan.Item.PackQty).ToString();
            this.neuSpread1_Sheet1.Cells[0, 2].Text = this.originalStockPlan.Item.PackUnit;

            this.neuSpread1_Sheet1.Rows[0].Tag = this.originalStockPlan.Company;

            this.SetStockQtyInfo();
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>成功返回True  失败返回False</returns>
        protected bool IsValid()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "" && Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i,1].Text) != 0)
                {
                    MessageBox.Show(Language.Msg("请设置第 " + (i+1).ToString() + " 行供货公司"));
                    return false;
                }
            }

            if (this.lbSpareInfo.Visible)
            {
                MessageBox.Show(Language.Msg("拆分数量设置不平,请重新设置"));
                return false;
            }            

            return true;
        }

        /// <summary>
        /// 入库计划信息拆分
        /// </summary>
        protected int SplitStockPlan()
        {
            if (!this.IsValid())
            {
                return -1;
            }

            this.splitPlan = new List<Neusoft.HISFC.Models.Pharmacy.StockPlan>();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "")
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.StockPlan alterStockPlan = this.originalStockPlan.Clone();
                //对于非原始记录 设置流水号为空 保存时进行插入 避免一直进行更新操作
                if (i > 0)
                {
                    alterStockPlan.ID = "";
                }

                alterStockPlan.Company = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.FrameWork.Models.NeuObject;

                alterStockPlan.StockApproveQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 1].Text) * this.originalStockPlan.Item.PackQty;

                this.splitPlan.Add(alterStockPlan);
            }

            return 1;
        }

        /// <summary>
        /// 设置采购总量信息
        /// </summary>
        private void SetStockQtyInfo()
        {
            decimal totQty = 0;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                totQty = totQty + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[i, 1].Text);
            }

            this.lbTotInfo.Text = "当前采购总数量:" + totQty.ToString() + " " + this.originalStockPlan.Item.PackUnit;

            decimal spareQty = this.originalStockPlan.StockApproveQty / this.originalStockPlan.Item.PackQty - totQty;
            if (spareQty == 0)
            {
                this.lbSpareInfo.Visible = false;
            }
            else
            {
                this.lbSpareInfo.Visible = true;

                this.lbSpareInfo.Text = "剩余采购数量:" + spareQty.ToString();
            }
        }        

        /// <summary>
        /// 供货公司弹出 
        /// </summary>
        /// <param name="rowIndex"></param>
        private void PopCompany(int rowIndex)
        {
            Neusoft.FrameWork.Models.NeuObject companyObj = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(this.alCompany, ref companyObj) == 1)
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, 0].Text = companyObj.Name;
                this.neuSpread1_Sheet1.Rows[rowIndex].Tag = companyObj;
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowIndex = this.neuSpread1_Sheet1.Rows.Count;

            this.neuSpread1_Sheet1.Rows.Add(rowIndex, 1);

            this.neuSpread1_Sheet1.Cells[rowIndex, 2].Text = this.originalStockPlan.Item.PackUnit;

            //设置当前选中行
            this.neuSpread1_Sheet1.ActiveRowIndex = rowIndex;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.neuSpread1_Sheet1.Rows.Count > 0 && this.neuSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex,1);
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
                return;

            if (e.Column == 0)
            {
                this.PopCompany(e.Row);
            }
        }

        /// <summary>
        /// 处理对历史药品采购记录的弹出功能
        /// </summary>
        private void fpStockApprove_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //当前记录的行、列
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;
            int j = this.neuSpread1_Sheet1.ActiveColumnIndex;

            //回车键键码 13 空格键键码 32
            if (e.KeyChar == 32)
            {
                this.PopCompany(i);
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SplitStockPlan() == -1)
            {
                this.result = DialogResult.Cancel;
            }
            else
            {
                this.result = DialogResult.OK;

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Cancel;

            this.Close();
        }

        private void neuSpread1_EditModeOff(object sender, EventArgs e)
        {
            this.SetStockQtyInfo();
        }
    }
}

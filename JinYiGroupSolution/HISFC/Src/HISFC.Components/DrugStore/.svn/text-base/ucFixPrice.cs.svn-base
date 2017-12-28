using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.DrugStore
{      
	/// <summary>
	/// 
	/// 药品定价控件 用于中山一院药库需求
	/// liangjz 2005-12
	/// </summary>    
    public partial class ucFixPrice : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucFixPrice()
        {
            InitializeComponent();

            //this.ucDrugList1.ChooseDataEvent += new Common.Controls.ucDrugList.ChooseDataHandler(ucDrugList1_ChooseDataEvent);
        }

        #region 定义工具栏

        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        protected Neusoft.HISFC.BizLogic.Pharmacy.Item myItem = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
 
        public bool isClinic = false;

        /// <summary>
        /// 住院或门诊  
        /// </summary>
        public bool IsClinic
        {
            get
            {
                return this.isClinic;
            }
            set
            {
                this.isClinic = value;
            }
        }

		/// <summary>
		/// 当前总金额
		/// </summary>
		public decimal TotPrice = 0;

		/// <summary>
		/// 品种总数量
		/// </summary>
		public decimal TotKind = 0;

		/// <summary>
		/// 向FarPoint内加入数据
		/// </summary>
		/// <param name="item">药品实体</param>
		public void AddData(Neusoft.HISFC.Models.Pharmacy.Item item)
		{
			if (item == null)
				return;
			int iRow = this.fpSpread1_Sheet1.Rows.Count;
			this.fpSpread1_Sheet1.Rows.Add(iRow,1);
			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColTradeName].Text = item.Name;
			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColSpecs].Text = item.Specs;
			if (item.PackQty == 0)
				item.PackQty = 1;
			if (item.Type.ID == "C")
                this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColPrice].Text = System.Math.Round((item.PriceCollection.RetailPrice / item.PackQty),4).ToString();
			else
                this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColPrice].Text = System.Math.Round((item.PriceCollection.RetailPrice / item.PackQty), 2).ToString();
			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColUnit].Text = item.MinUnit;
			this.fpSpread1_Sheet1.Rows[iRow].Tag = item;
		}

		/// <summary>
		/// 向FarPoint内加入数据
		/// 添加了货位好的显示
		/// add by zengft 2007-4-30
		/// </summary>
		/// <param name="item">药品实体</param>
		public void AddData(Neusoft.HISFC.Models.Pharmacy.Item item,string deptCode)
		{
			if (item == null)
				return;

          
			//add by zengft 2007-4-30
			Neusoft.HISFC.BizLogic.Pharmacy.Item itm = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
			Neusoft.HISFC.Models.Pharmacy.Storage s = new Neusoft.HISFC.Models.Pharmacy.Storage();
			s = itm.GetStockInfoByDrugCode(deptCode,item.ID);
			//end add

			int iRow = this.fpSpread1_Sheet1.Rows.Count;
			this.fpSpread1_Sheet1.Rows.Add(iRow,1);
			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColTradeName].Text = item.Name;
			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColSpecs].Text = item.Specs;
			if (item.PackQty == 0)
				item.PackQty = 1;
			if (item.Type.ID == "C")
                this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColPrice].Text = System.Math.Round((item.PriceCollection.RetailPrice / item.PackQty), 4).ToString();
			else
                this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColPrice].Text = System.Math.Round((item.PriceCollection.RetailPrice / item.PackQty), 2).ToString();

            if (IsClinic)
            {
                if (item.SplitType.Equals(0))
                    this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColUnit].Text = item.MinUnit;
                else
                    this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColUnit].Text = item.PackUnit;
            }
            else
                this.fpSpread1_Sheet1.Cells[iRow, (int)ColEnum.ColUnit].Text = item.MinUnit;

			this.fpSpread1_Sheet1.Rows[iRow].Tag = item;

			this.fpSpread1_Sheet1.Cells[iRow,(int)ColEnum.ColPlace].Text = s.PlaceNO;

		}

		/// <summary>
		/// 数据删除
		/// </summary>
		public void DelData()
		{
			if (this.fpSpread1_Sheet1.Rows.Count <= 0)
				return;
			decimal retailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)ColEnum.ColPrice].Text);
			decimal num = 0;
			try
			{
				num = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)ColEnum.ColNum].Text);
			}
			catch
			{
				num = 0;
			}
			this.TotPrice = this.TotPrice - num * retailPrice;
			this.SetLabel();
			this.fpSpread1_Sheet1.Rows.Remove(this.fpSpread1_Sheet1.ActiveRowIndex,1);
			 
		}

		/// <summary>
		/// 添加合计行
		/// </summary>
		public void Sum()
		{
            decimal cost = 0;
			this.TotPrice = 0;
			for(int i = 0;i < this.fpSpread1_Sheet1.Rows.Count;i++)
			{
				cost = cost + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i,(int)ColEnum.ColCost].Text);
                //try
                //{
                //    num = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[i,(int)ColEnum.ColNum].Text);
                //}
                //catch
                //{
                //    num = 0;
                //}

                
                //Neusoft.HISFC.Models.Pharmacy.Item item = this.fpSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.Item;

                //if (item != null)
                //{
                //    if (this.isClinic && item.SplitType.Equals(0))
                //    {                        
                //        this.TotPrice = this.TotPrice + num * price;
                //    }
                //    else
                //    {
                //        this.TotPrice = this.TotPrice + num / item.PackQty * price;
                //    }
                //}
			}

            this.TotPrice = cost;

			this.SetLabel();
		}

		/// <summary>
		/// 计算总量
		/// </summary>
		public void Count()
		{
			decimal retailPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)ColEnum.ColPrice].Text);
			decimal num = 0;
			try
			{
				num = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)ColEnum.ColNum].Text);
				
			}
			catch 
			{
				this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)ColEnum.ColNum].Text = "0";
				num = 0;
			}

            Neusoft.HISFC.Models.Pharmacy.Item item = this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.Item;

            if (item != null)
            {
                if (this.isClinic && item.SplitType.Equals(0))
                {
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)ColEnum.ColCost].Text = (num * retailPrice).ToString();
                }
                else
                {
                    //this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)ColEnum.ColCost].Text = (num / item.PackQty * retailPrice).ToString();
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)ColEnum.ColCost].Text = (num * retailPrice).ToString();
                }
            }
			
			this.Sum();
		}

		/// <summary>
		/// 清屏
		/// </summary>
		public void Clear()
		{
			this.TotPrice = 0;
			this.fpSpread1_Sheet1.Rows.Count = 0;
			this.SetLabel();
		}

		/// <summary>
		/// 设置label
		/// </summary>
		private void SetLabel()
		{
			this.neuLabel1.Text = "总金额：   " + this.TotPrice.ToString();  
		}

		/// <summary>
		/// 设置焦点
		/// </summary>
		public void SetFocus()
		{
			this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.Rows.Count - 1;
			this.fpSpread1_Sheet1.ActiveColumnIndex = (int)ColEnum.ColNum;
		}

		/// <summary>
		/// 回车跳转
		/// </summary>
		/// <param name="isBottomToTop">在最后一行回车后是否返回第一行</param>
		/// <returns>1 在最后一行回车 0 其他行回车</returns>
		public int SetJump(bool isBottomToTop)
		{
			if (this.fpSpread1.ContainsFocus)
			{
				this.Count();
				if (this.fpSpread1_Sheet1.ActiveColumnIndex == (int)ColEnum.ColNum)
				{
					this.fpSpread1_Sheet1.ActiveColumnIndex = (int)ColEnum.ColNum;
					if (this.fpSpread1_Sheet1.ActiveRowIndex == this.fpSpread1_Sheet1.Rows.Count - 1)
					{
						if (isBottomToTop)
                            this.fpSpread1_Sheet1.ActiveRowIndex = 0;
						return 1;
					}
					else
					{
						this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.ActiveRowIndex + 1;
						return 0;
					}
				}					
			}
			return 2;
		}

		private void ucFixPrice_Load(object sender, EventArgs e)
		{
            this.ShowPharmacyList();

			//屏蔽回车键
			FarPoint.Win.Spread.InputMap im;
			im=this.fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
			im.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter,Keys.None),FarPoint.Win.Spread.SpreadActions.None);

			this.fpSpread1.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(fpSpread1_LeaveCell);
		}

		private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
		{
			if (e.Column == (int)ColEnum.ColNum)
			{
				this.Count();
			}
		}

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.SetJump(false) == 1)
                {
                    this.ucDrugList1.Select();
                    this.ucDrugList1.Focus();
                    this.ucDrugList1.SetFocusSelect();
                }
            }
            return base.ProcessDialogKey(keyData);
        }
		
        /// <summary>
        /// 显示药品列表
        /// </summary>
        protected void ShowPharmacyList()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索药品信息...");
            Application.DoEvents();
            try
            {
                this.ucDrugList1.ShowPharmacyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
		
        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv, int activeRow)
        {
            string drugCode = sv.Cells[activeRow, 0].Text;
            Neusoft.HISFC.Models.Pharmacy.Item item = this.myItem.GetItem(drugCode);

            this.AddData(item,((Neusoft.HISFC.Models.Base.Employee)myItem.Operator).Dept.ID);

            this.fpSpread1.Focus();
            this.fpSpread1_Sheet1.ActiveColumnIndex = (int)ColEnum.ColNum;
            this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.Rows.Count - 1;
        }
 
        #region 初始化工具栏

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("新建", "新建", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("清屏", "清屏", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            toolBarService.AddToolButton("删除", "删除", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);            

            return toolBarService;
        }

        #endregion
  
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "新建":
                    //this.AddData();
                    break; 
                case "删除":
                    this.DelData(); 
                    break;
                case "清屏":
                    this.Clear();
                    break;
                default:
                    break;
            }
        }

        protected enum ColEnum
        {
            /// <summary>
            /// 药品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 数量
            /// </summary>
            ColNum,
            /// <summary>
            /// 最小单位

            /// </summary>
            ColUnit,
            /// <summary>
            /// 最小单位零售价
            /// </summary>
            ColPrice,
            /// <summary>
            /// 金额
            /// </summary>
            ColCost,
            /// <summary>
            /// 货位
            /// </summary>
            ColPlace

        }
}
}
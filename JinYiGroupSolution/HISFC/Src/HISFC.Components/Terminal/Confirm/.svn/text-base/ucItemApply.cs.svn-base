using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.CellType;
using Neusoft.HISFC.BizProcess.Integrate.Terminal;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Fee.Item;
using Neusoft.HISFC.Models.RADT;
using Neusoft.HISFC.Models.Registration;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Components.Common.Controls;
using Item=Neusoft.HISFC.Models.Base.Item;
using System.Collections;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
	/// <summary>
	/// ucItemApply <br></br>
	/// [功能描述: 终端确认的项目列表UC]<br></br>
	/// [创 建 者: 赫一阳]<br></br>
	/// [创建时间: 2006-03-07]<br></br>
	/// <修改记录
	///		修改人=''
	///		修改时间=''
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucItemApply : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucItemApply()
		{
			InitializeComponent();
		}

		#region 变量
		
		/// <summary>
		/// 患者基本信息

		/// </summary>
		Neusoft.HISFC.Models.Registration.Register register = new Register();
        private Neusoft.HISFC.BizProcess.Integrate.Pharmacy pharmacyMgr = new Neusoft.HISFC.BizProcess.Integrate.Pharmacy();
        private Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager examiMgr = new Neusoft.HISFC.BizProcess.Integrate.PhysicalExamination.ExamiManager();
        private bool IsConfirm = true; //集体体检是否需要终端确认 

        /// <summary>
        /// 医技载体业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier terminalCarrier = new Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier();
		/// <summary>
		/// 返回值

		/// </summary>
		int intReturn = 0;

		/// <summary>
		/// 当前行号
		/// </summary>
		int rowIndex = 0;

		/// <summary>
		/// 记录个数
		/// </summary>
		int rowCount = 0;

		/// <summary>
		/// 终端中断确认申请单

		/// </summary>
		Neusoft.HISFC.Models.Terminal.TerminalApply terminalApply = new TerminalApply();
        Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm confirmMgr = new Neusoft.HISFC.BizLogic.Terminal.TerminalConfirm();
        Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        /// <summary>
        /// 医嘱综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Order orderIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Order();

        #region {5E5299D8-95A2-4498-B2F1-52D00E4FB11A}
        //Neusoft.ApplyInterface.HisInterface hisInterface = null;
        Neusoft.HISFC.Components.PacsApply.HisInterface hisInterface = null;
        string passWord = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Password;
        string account = (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).User01;
        #endregion

        /// <summary>
		/// 窗口类型
		/// </summary>
		string windowType = "1";

		/// <summary>
		/// 当前科室
		/// </summary>
		public string currentDepartment = "";

		/// <summary>
		/// 当前科室名称
		/// </summary>
		public string currentDepartmentName = "";

        /// <summary>
        /// 是否使用电子申请单 
        /// </summary>
        private string isUseDL = "0";

		/// <summary>
		/// 收费项目
		/// </summary>
		Neusoft.HISFC.Models.Base.Item item = new Item();

		/// <summary>
		/// 收费项目选择控件
		/// </summary>
		public Neusoft.HISFC.Components.Common.Controls.ucItemList ucItemList;
        Neusoft.HISFC.BizProcess.Integrate.Manager conl = new Neusoft.HISFC.BizProcess.Integrate.Manager();
		/// <summary>
		/// 检索药品文本

		/// </summary>
		string byText = "";

		/// <summary>
		/// 添加新项目时的行号

		/// </summary>
		int editRow = 0;

		/// <summary>
		/// 当前操作员

		/// </summary>
		string currentOperator = "";

		/// <summary>
		/// 单击FARPOINT事件代理
		/// </summary>
		public delegate void MyDelegate(object sender, FarPoint.Win.Spread.CellClickEventArgs e);

		/// <summary>
		/// 根据单击FARPOINT事件代理定义事件
		/// </summary>
		public event MyDelegate ClickApply;

		/// <summary>
		/// 在FARPOINT上按上下箭头事件代理
		/// </summary>
		public delegate void MySecondDelegate(Keys key);

		/// <summary>
		/// 根据在FARPOINT上按上下箭头事件代理定义事件
		/// </summary>
		public event MySecondDelegate KeyUpAndDown;

		/// <summary>
		/// 显示字段的枚举

		/// </summary>
		public enum DisplayField
		{
			/// <summary>
			/// 是否确认0
			/// </summary>
			ConfirmFlag = 0,
			/// <summary>
			/// 项目名称1
			/// </summary>
			ItemName = 1,
			/// <summary>
			/// 单价2
			/// </summary>
			ItemPrice = 2,
			/// <summary>
			/// 项目数量3
			/// </summary>
			ItemAmount = 3,
			/// <summary>
			/// 单位4
			/// </summary>
			ItemUnit = 4,
			/// <summary>
			/// 费用金额5
			/// </summary>
			ItemCost = 5,
			/// <summary>
			/// 确认数量6
			/// </summary>
			ConfirmAmount = 6,
			/// <summary>
			/// 医技设备7
			/// </summary>
			MachineName = 7,
			/// <summary>
			/// 设备编号8
			/// </summary>
			MachineId = 8,
			/// <summary>
			/// 已确认数9
			/// </summary>
			AlreadyAmount = 9,
			/// <summary>
			/// 新旧项目10
			/// </summary>
			NewOld = 10,
			/// <summary>
			/// 申请单流水号11
			/// </summary>
			ApplySequence = 11,
			/// <summary>
			/// 处方号12
			/// </summary>
			RecipeNo = 12,
			/// <summary>
			/// 处方内项目流水号13
			/// </summary>
			SequenceInRecipe = 13,
			/// <summary>
			/// 项目编码14
			/// </summary>
			ItemCode = 14,
			/// <summary>
			/// 组套代码15
			/// </summary>
			PackageCode = 15,
			/// <summary>
			/// 组套名称16
			/// </summary>
			PaceageName = 16,
			/// <summary>
			/// 是否药品17
			/// </summary>
			IsPhamacy = 17,
			/// <summary>
			/// 项目执行状态18
			/// </summary>
			ItemStatus = 18,
			/// <summary>
			/// 医嘱号19
			/// </summary>
			OrderSequence = 19,
			/// <summary>
			/// 医嘱执行单号20
			/// </summary>
			ExecuteFormSequence = 20,
			/// <summary>
			/// 最小费用代码21
			/// </summary>
			MiniCode = 21,
			/// <summary>
			/// 系统类别22
			/// </summary>
			SystemClass = 22,
			/// <summary>
            /// 执行科室23{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
			/// </summary>
			ExecuteDepartment = 23,
            /// <summary>
            /// 执行设备24
            /// </summary>
            ExecDevice = 24,
            /// <summary>
            /// 执行人
            /// </summary>
            Operator = 25
		}

		#endregion

		#region 属性


		/// <summary>
		/// 新下的项目对象

		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Neusoft.HISFC.Models.Base.Item Item
		{
			get
			{
				return this.item;
			}
			set
			{
				this.item = value;
			}
		}

		/// <summary>
		/// 记录个数
		/// </summary>
		public int RowCount
		{
			get
			{
				this.rowCount = this.fpSpread1_Sheet1.RowCount;
				return this.rowCount;
			}
			set
			{
				this.rowCount = value;
			}
		}

		/// <summary>
		/// 中断确认申请单：承载对象
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Neusoft.HISFC.Models.Terminal.TerminalApply TerminalApply
		{
			get
			{
				return this.terminalApply;
			}
			set
			{
				this.terminalApply = value;
			}
		}

		/// <summary>
		/// 窗口类型：1-门诊/2-住院/9-通用
		/// </summary>
		public string WindowType
		{
			get
			{
				return this.windowType;
			}
			set
			{
				this.windowType = value;
			}
		}

		/// <summary>
		/// 当前记录行号
		/// </summary>
		public int CurrentRow
		{
			get
			{
				// 如果记录数为0，返回-1
				if (this.RowCount == 0)
				{
					return -1;
				}

				// 获取当前行

				this.rowIndex = this.fpSpread1_Sheet1.ActiveRowIndex;

				return this.rowIndex;
			}
			set
			{
				this.fpSpread1_Sheet1.ActiveRowIndex = value;
			}
		}

		/// <summary>
		/// 当前记录列号
		/// </summary>
		public int CurrentColumn
		{
			get
			{
				return this.fpSpread1_Sheet1.ActiveColumnIndex;
			}
			set
			{
				this.fpSpread1_Sheet1.ActiveColumnIndex = value;
				this.CellFocus(this.CurrentRow, value);
			}
		}

		/// <summary>
		/// 检索收费项目代码

		/// </summary>
		public string ByText
		{
			get
			{
				return this.byText;
			}
			set
			{
				this.byText = value;
			}
		}
        //
        private Neusoft.HISFC.Components.Common.Controls.EnumShowItemType enumItemType = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.All;
        public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType EnumItemType
        {
            set
            {
                this.enumItemType = value;
            }
            get
            {
                return this.enumItemType;
            }
 
        }

		/// <summary>
		/// 患者基本信息

		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Neusoft.HISFC.Models.Registration.Register Register
		{
			get
			{
				return this.register;
			}
			set
			{
				this.register = value;
			}
		}
		
		#endregion

		#region 函数

		#region 初始化、清空

		/// <summary>
		/// 初始化

		/// </summary>
		public void Init()
		{
			// 实例化项目列表，并且检索全部收费项目

			Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载收费项目信息...");
			Application.DoEvents();

			//this.ucItemList = new ucItemList(Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Undrug);
            this.ucItemList = new ucItemList();//{07F68F35-A29E-46d0-9566-367ABB5F8ED2}
            //this.ucItemList = new ucItemList(this.EnumItemType);
			// 添加项目列表
			this.Controls.Add(this.ucItemList);
            this.ucItemList.enuShowItemType = this.EnumItemType;//{07F68F35-A29E-46d0-9566-367ABB5F8ED2}
            this.ucItemList.Init(string.Empty);//{07F68F35-A29E-46d0-9566-367ABB5F8ED2}
			// 设置项目列表不可见

			this.ucItemList.Visible = false;
			// 使项目列表最前

			this.ucItemList.BringToFront();
			// 收费项目列表选择项目事件
			this.ucItemList.SelectItem += new ucItemList.MyDelegate(ucItemList_SelectItem);
			// 申请单明细回车事件

			this.fpSpread1.KeyEnter+=new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.keyDown(fpSpread1_KeyEnter);

            string objIsConfirm = conl.QueryControlerInfo("TJ0072");　//是否需要插确认表

            isUseDL = conl.QueryControlerInfo("200212");   //是否使用电子申请单

            if (objIsConfirm != null)
            {
                if (!Neusoft.FrameWork.Public.String.StringEqual(objIsConfirm, "1"))
                {
                    IsConfirm = false;
                }
            }
            this.InitSheet1();
			
		}

        private void InitSheet1()
        {
            //
            // 设置可见性
            //
            for (int i = 10; i <= 22; i++)
            {
                // 不改变列宽度,不显示,不改变列头文字
                this.SetColumn(i, 0, false, "");
            }
            this.SetColumn((int)DisplayField.ItemStatus, 0, true, "");
            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new TextCellType();
            txtCellType.ReadOnly = true;
            this.fpSpread1_Sheet1.Columns[(int)DisplayField.ItemStatus].CellType = txtCellType;
            // 设备名称{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            this.SetColumn((int)DisplayField.MachineName, 0, false, "");
            // 设备编号
            this.SetColumn((int)DisplayField.MachineId, 0, false, "");
            //数量、执行设备和执行人可修改{810581A3-6DF5-49af-8A5F-D7F843CBEA89}{07D1BACB-8E4F-4ac8-8254-81763D0F0699}
            this.fpSpread1_Sheet1.Columns[(int)DisplayField.ConfirmAmount].Locked = false;
            this.fpSpread1_Sheet1.Columns[(int)DisplayField.ExecDevice].Locked = false;
            this.fpSpread1_Sheet1.Columns[(int)DisplayField.Operator].Locked = false;
            //在技师列中加入人员列表供选择
            ArrayList al = new ArrayList();
            Neusoft.HISFC.BizProcess.Integrate.Manager ztManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            al = ztManager.QueryEmployeeAll();

            this.fpSpread1.SetColumnList(this.fpSpread1_Sheet1, (int)DisplayField.Operator, al);
            //设备列加入医技设备数据，只显示当前操作员所在科室的医技设备{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            al = this.terminalCarrier.GetDesigns(((Neusoft.HISFC.Models.Base.Employee)confirmMgr.Operator).Dept.ID);
            if (al.Count > 0)
            {
                ArrayList alTer = new ArrayList();
                foreach (HISFC.Models.Terminal.TerminalCarrier terObj in al)
                {
                    alTer.Add(new Neusoft.FrameWork.Models.NeuObject(terObj.CarrierCode, terObj.CarrierName, ""));
                }
                this.fpSpread1.SetColumnList(this.fpSpread1_Sheet1, (int)DisplayField.ExecDevice, alTer);
            }
            this.fpSpread1.SetItem += new Neusoft.FrameWork.WinForms.Controls.NeuFpEnter.setItem(fpSpread1_SetItem);
        }

        private int fpSpread1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
        {
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, this.fpSpread1_Sheet1.ActiveColumnIndex].Text = obj.Name;
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, this.fpSpread1_Sheet1.ActiveColumnIndex].Tag = obj.ID;
            return 0;
        }
		/// <summary>
		/// 清空表格
		/// </summary>
		public void Clear()
		{
			for (int i = this.fpSpread1_Sheet1.RowCount - 1;i >= 0;i--)
			{
				// 删除表格
				this.DeleteRow(i, false);
			}
			// 使本身的患者基本信息为null
			this.register = null;
		}
		
		/// <summary>
		/// Clear
		/// </summary>
		public void ClearFp2()
		{
			this.fpSpread2_Sheet1.DataSource = null;
		}

		#endregion

		#region FarPoint

		/// <summary>
		/// 在指定的行号之前增加一行

		/// [参数: int beginRow - 指定的行号]
		/// </summary>
		/// <param name="beginRow">在第几行前面增加</param>
		public void AddRow(int beginRow)
		{
			// 在指定行号之前插入一行

			this.fpSpread1_Sheet1.AddRows(beginRow, 1);

			// 设置当前行为插入行

			this.fpSpread1_Sheet1.ActiveRowIndex = beginRow;
			// 设置当前行号
			this.rowIndex = beginRow;
			// 设置项目执行状态：新项目设置成划价
			this.Cell(this.CurrentRow, (int)DisplayField.ItemStatus, "划价");
		}

		/// <summary>
		/// 增加一行，并设置焦点到增加行

		/// </summary>
		public void NewRow()
		{
			if (this.register.Memo == "2" )
			{
                MessageBox.Show("住院患者不允许直接划价");
				return;
			}
            if (Register.Memo == "4" || Register.Memo == "5")
            {
                MessageBox.Show("体检患者不允许直接划价");
                return;
            }
			// 判断是否存在无效行、新增行,如果存在不进行添加,直接设置焦点到该行

			if (this.RowCount > 0)
			{
				for (int i = 0;i < this.RowCount;i++)
				{
					if (this.GetItem(i, (int)DisplayField.ItemCode).Equals("") || this.GetItem(i, (int)DisplayField.ItemCode) == null)
					{
						// 设置当前行

						this.CurrentRow = i;

						return;
					}
				}
			}
			// 增加
			if (this.RowCount == 1)
			{
				// 如果只有一条记录，那么在第一条记录前增加一条

				this.AddRow(1);
			}
			else
			{
				// 如果有多个记录，那么在最后添加记录

				this.AddRow(this.rowCount);
			}
			// 设置焦点到项目名称

			this.CurrentColumn = (int)DisplayField.ItemName;
			// 新项目设置新旧项目标志为“新”

			this.Cell(this.rowCount - 1, (int)DisplayField.NewOld, "新"); 
			// 锁定确认数量
            //this.Lock(this.RowCount - 1, (int)DisplayField.ConfirmAmount, true);
			// 锁定项目数量
			this.Lock(this.RowCount - 1, (int)DisplayField.ItemAmount, true);
			// 锁定确认标志
			this.Lock(this.RowCount - 1, (int)DisplayField.ConfirmFlag, true);
            //价格
            this.Lock(this.RowCount - 1, (int)DisplayField.ItemPrice, true);
            //总金额

            this.Lock(this.RowCount - 1, (int)DisplayField.ItemCost, true);
            //单位
            this.Lock(this.RowCount - 1, (int)DisplayField.ItemUnit, true);
			// 锁定已确认数量

			this.Lock(this.RowCount - 1, (int)DisplayField.AlreadyAmount, true);
            this.Lock(this.RowCount - 1, (int)DisplayField.ExecuteDepartment, true);
		}

		/// <summary>
		/// 按指定的行号删除一行

		/// [参数1: int row - 要删除的行号]
		/// [参数2: bool confirm - 是否需要用户确认]
		/// </summary>
		/// <param name="row">要删除的行号</param>
		/// <param name="confirm">是否需要确认</param>
		public void DeleteRow(int row, bool confirm)
		{
			// 如果是空记录，则直接删除，否则需要确认删除

			if (confirm && (!this.IsNull(row)))
			{
				// 如果取消删除，那么返回

				if (MessageBox.Show("是否删除当前行？", "医技终端确认",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					this.Focus();
					return;
				}
			}
            //{8C0239CE-4272-4f30-B547-9C3C27D694E4} 停止编辑模式，否则删除时保留了当前选中文本
            this.fpSpread1.EditMode = false;
			// 删除指定的行
			this.fpSpread1_Sheet1.RemoveRows(row, 1);
			// 设置焦点到上一行

			this.fpSpread1.Focus();
			if (row - 1 >= 0)
			{
				this.CurrentRow = row - 1;
				// 设置焦点到项目名称

				this.CurrentColumn = (int)DisplayField.ItemName;
			}
		}

		/// <summary>
		/// 删除一行(当前行)新项目

		/// </summary>
		public void DeleteNew()
		{
			// 如果没有记录，则返回
			if (this.RowCount == 0)
			{
				return;
			}
			// 只能删除新项目

			if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemStatus) != "划价")
			{
				MessageBox.Show("该项目不允许删除", "医技终端确认");
				this.Focus();
				this.CellFocus(this.CurrentRow, this.CurrentColumn);
				return;
			}
			// 删除
			this.DeleteRow(this.CurrentRow, true);
		}

		/// <summary>
		/// 设置一个CELL的值

		/// [参数1: int row - 行号]
		/// [参数2: int column - 列号]
		/// [参数3: string text - 文本值]
		/// </summary>
		/// <param name="row">行号</param>
		/// <param name="column">列号</param>
		/// <param name="text">值文本</param>
		public void Cell(int row, int column, string text)
		{
			this.fpSpread1_Sheet1.Cells[row, column].Text = text;
		}

		/// <summary>
		/// 获取一个CELL的值

		/// [参数1: int row - 行号]
		/// [参数2: int column - 列号]
		/// [返回: string, 文本值]
		/// </summary>
		/// <param name="row">行</param>
		/// <param name="column">列</param>
		/// <returns>CELL里面的文本</returns>
		public string GetItem(int row, int column)
		{
			return this.fpSpread1_Sheet1.Cells[row, column].Text;
		}

		/// <summary>
		/// 锁定/解锁一个表格

		/// [参数1: int row - 行号]
		/// [参数2: int column - 列号]
		/// [参数3: bool boolLock - 是否锁定]
		/// </summary>
		/// <param name="row">行号</param>
		/// <param name="column">列号</param>
		/// <param name="boolLock">是否锁定</param>
		public void Lock(int row, int column, bool boolLock)
		{
			this.fpSpread1_Sheet1.Cells[row, column].Locked = boolLock;
		}

		/// <summary>
		/// 设置焦点到指定CELL
		/// [参数1: int row - 行号]
		/// [参数2: int column - 列号]
		/// </summary>
		/// <param name="row">行号</param>
		/// <param name="column">列号</param>
		public void CellFocus(int row, int column)
		{
			this.Focus();
			this.fpSpread1.Focus();
			this.fpSpread1_Sheet1.ActiveRowIndex = row;
			this.fpSpread1_Sheet1.ActiveColumnIndex = column;
		}

		/// <summary>
		/// 全部选中
		/// </summary>
		public void SelectAll()
		{
			// 如果记录数为0，那么返回

			if (this.RowCount == 0)
			{
				return;
			}
			// 全选

			for (int i = 0;i < this.RowCount;i++)
			{
				this.Cell(i, (int)DisplayField.ConfirmFlag, "true");
			}
		}

		/// <summary>
		/// 全部取消
		/// </summary>
		public void CancelAll()
		{
			// 如果记录数为0，那么返回

			if (this.RowCount == 0)
			{
				return;
			}
			// 全部取消
			for (int i = 0;i < this.RowCount;i++)
			{
				if (this.GetItem(i, (int)DisplayField.NewOld).Equals("旧"))
				{
					this.Cell(i, (int)DisplayField.ConfirmFlag, "false");
				}
			}
		}

		/// <summary>
		/// 设置表格列的宽度
		/// [参数1: int column - 列号]
		/// [参数2: int width - 宽度,0代表不改变列宽度]
		/// [参数3: bool visible - 列是否可见]
		/// [参数4: string label - 列的标题,''代表不改变列标题]
		/// </summary>
		/// <param name="column">列号</param>
		/// <param name="width">宽度</param>
		/// <param name="visible">是否可见</param>
		/// <param name="label">标题</param>
		public void SetColumn(int column, int width, bool visible, string label)
		{
			// 设置宽度：如果入参为0，代表不修改列宽度

			if (width != 0)
			{
				this.fpSpread1_Sheet1.Columns[column].Width = width;
			}
			// 设置可见性

			this.fpSpread1_Sheet1.Columns[column].Visible = visible;
			// 设置标题：如果入参为空，代表不修改列标题
			if (label != "")
			{
				this.fpSpread1_Sheet1.Columns[column].Label = label;
			}
		}

		/// <summary>
		/// 判断指定行是否为空（如果项目编号14列为空就认为是空记录）

		/// [参数: int row - 行号]
		/// [返回: bool,true - 空, false - 非空]
		/// </summary>
		/// <param name="row">指定的行号</param>
		/// <returns>true：为空/false：不为空</returns>
		public bool IsNull(int row)
		{
			// 如果项目编码为空，代表项目为空

			if (this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ItemCode].Text.Equals(""))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 调用增加新项目

		/// </summary>
		public void InsertNew()
		{
			// 获取当前选中的收费项目

			this.intReturn = this.ucItemList.GetSelectItem(out this.item);
			Neusoft.HISFC.Models.Pharmacy.Item drug;
			Neusoft.HISFC.Models.Fee.Item.Undrug undrug;
			// 如果没有可用的项目,那么返回
			if (this.item.ID == null || this.item.ID.Equals(""))
			{
				// 使收费项目列表消失

				this.UnDisplayUcItemList();
				// 设置项目名称为空
				this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");

				MessageBox.Show("所找项目不存在", "医技终端确认");
				this.fpSpread1.Focus();

				return;
			}
			// 如果有效，那么增加新项目到申请单明细
			if (this.intReturn > 0)
			{
				// 增加新项目
				//if (this.item.IsPharmacy)
                if (this.item.ItemType == HISFC.Models.Base.EnumItemType.Drug)
				{
					drug = (Neusoft.HISFC.Models.Pharmacy.Item)this.item;
                    Neusoft.HISFC.Models.Pharmacy.Storage drugStore = this.pharmacyMgr.GetItemForInpatient(((Neusoft.HISFC.Models.Base.Employee)confirmMgr.Operator).Dept.ID, item.ID);
                    if (drugStore == null)
                    {//没找到

                        drugStore = new Neusoft.HISFC.Models.Pharmacy.Storage();
                        drugStore.Name = "帐目表中无该项目";
                    }
                    //终端划价时药品不判断库存
                    //if (drugStore.StoreQty <= 0)
                    //{
                    //    MessageBox.Show(drug.Name + "库存不足请选择其他药品");
                    //    return ;
                    //}

					this.intReturn = this.AddNewItem(drug);
				}
				else
				{
					undrug = (Neusoft.HISFC.Models.Fee.Item.Undrug) this.item;
					this.intReturn = this.AddNewItem(undrug);
				}
				if (this.intReturn == -1)
				{
					// 使收费项目列表消失

					this.UnDisplayUcItemList();
					// 设置当前字段为项目名称

					this.CurrentColumn = (int)DisplayField.ItemName;

					return;
				}
				// 解锁项目数量
				this.Lock(this.CurrentRow, (int)DisplayField.ItemAmount, false);
				// 使项目列表不可见
				this.UnDisplayUcItemList();
				// 设置焦点到项目数量

				this.CurrentColumn = (int)DisplayField.ItemAmount;
			}
		}

		/// <summary>
		/// 添加新项目（药品）

		/// [参数: neusoft.HISFC.Models.Base.Item item - 项目]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="tempItem">收费项目</param>
		/// <returns>1-成功,-1-失败</returns>
		private int AddNewItem(Neusoft.HISFC.Models.Pharmacy.Item tempItem)
		{
			// 价格实体
			Neusoft.FrameWork.Models.NeuObject objectPrice = new NeuObject();
			// 应该取的单价
			decimal decimalPrice = 0m;
			// 合同单位方法类

			//Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactOperate = new PactUnitInfo();
			// 合同单位
			//neusoft.HISFC.Models.Fee.PactUnitInfo pact = new neusoft.HISFC.Models.Fee.PactUnitInfo();
			//Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
			//
			// 根据合同单位获取价格形式,用来获取应该采用的价格

			//
			// 根据合同单位编码获取价格形式信息
			//pact = pactOperate.GetPactUnitInfoByPactCode(this.register.Pact.ID);
			//// 如果没有取回结果,那么返回
			//if (pact == null)
			//{
			//    MessageBox.Show("获取收费项目的价格形式失败!\n" + pactOperate.Err, "医技终端确认");
			//    this.Focus();
			//    // 清空项目名称
			//    this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");
			//    return -1;
			//}
			//// 价格形式
			//objectPrice.ID = pact.PriceForm;
			//// 患者年龄

			//objectPrice.Name = this.register.Age;
			//// 零售价

			//objectPrice.User01 = item.Price.ToString();
			//// 特诊价

			//objectPrice.User02 = item.Price2.ToString();
			//// 儿童价

			//if (item.IsPharmacy)
			//{
			//    item.Price1 = item.Price;
			//}
			//objectPrice.User03 = item.Price1.ToString();
			//// 获取应该采用的价格

			//decimalPrice = Neusoft.Common.Clinic.Function.Charge.GetPrice(objectPrice);
			decimalPrice = tempItem.Price;
			if (decimalPrice <= 0)
			{
				MessageBox.Show("该项目价格信息不全,不能开立,请将该项目的价格信息维护全!\n" + objectPrice.Memo, "医技终端确认");
				this.Focus();
				// 清空项目名称
				this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");
				return -1;
			}
			// 是否确认
			this.Cell(this.CurrentRow, (int)DisplayField.ConfirmFlag, "true");
			// 项目名称
			this.Cell(this.CurrentRow, (int)DisplayField.ItemName, tempItem.Name);
			// 项目数量
			this.Cell(this.CurrentRow, (int)DisplayField.ItemAmount, "");
			// 确认数量
			this.Cell(this.CurrentRow, (int)DisplayField.ConfirmAmount, "");
			// 新项目不允许输入确认数量
			this.Lock(this.CurrentRow, (int)DisplayField.ConfirmAmount, true);
			// 项目单价,Tag保留原始价格,以备后用
			if (tempItem.PackQty > 0)
			{
				// 价格/包装数量
				this.Cell(this.CurrentRow, (int)DisplayField.ItemPrice, (decimal.Round(decimalPrice / tempItem.PackQty, 4)).ToString());
			}
			else
			{
				// 价格
				this.Cell(this.CurrentRow, (int)DisplayField.ItemPrice, (decimalPrice).ToString());
			}
			this.fpSpread1_Sheet1.Cells[this.CurrentRow, (int)DisplayField.ItemPrice].Tag = decimalPrice;
			// 已确认数,锁定已确认数
			this.Cell(this.CurrentRow, (int)DisplayField.AlreadyAmount, "0");
			this.Lock(this.CurrentRow, (int)DisplayField.AlreadyAmount, true);
			// 计价单位,保留计价单位到Tag,以备后用
			if (tempItem.Specs.Equals(""))
			{
				// 如果规格为空,直接赋值为计价单位
				this.Cell(this.CurrentRow, (int)DisplayField.ItemUnit, tempItem.PriceUnit);
			}
			else
			{
				// 赋值 = 计价单位[规格]
				this.Cell(this.CurrentRow, (int)DisplayField.ItemUnit, tempItem.PriceUnit + "[" + tempItem.Specs + "]");
			}
			this.fpSpread1_Sheet1.Cells[this.CurrentRow, (int)DisplayField.ItemUnit].Tag = tempItem.PriceUnit;
			// 费用金额
			this.Cell(this.CurrentRow, (int)DisplayField.ItemCost, "");
			// 新旧项目
			this.Cell(this.CurrentRow, (int)DisplayField.NewOld, "新");
			// 项目编码
			this.Cell(this.CurrentRow, (int)DisplayField.ItemCode, tempItem.ID);
			// 是否药品
			//if (tempItem.IsPharmacy)
            if (tempItem.ItemType == HISFC.Models.Base.EnumItemType.Drug)
			{
				this.Cell(this.CurrentRow, (int)DisplayField.IsPhamacy, "1");
			}
			else
			{
				this.Cell(this.CurrentRow, (int)DisplayField.IsPhamacy, "0");
			}
			// 项目执行状态

			this.Cell(this.CurrentRow, (int)DisplayField.ItemStatus, "划价");
			// 最小费用代码

			this.Cell(this.CurrentRow, (int)DisplayField.MiniCode, tempItem.MinFee.ID);
			// 系统类别
			this.Cell(this.CurrentRow, (int)DisplayField.SystemClass, tempItem.SysClass.ID.ToString());
			// 设备信息
			//if (!tempItem.IsPharmacy)
            if(tempItem.ItemType != HISFC.Models.Base.EnumItemType.Drug)
			{
				// 医技设备 ************
				this.Cell(this.CurrentRow, (int)DisplayField.MachineName, "");
				// 设备编号 ************
				this.Cell(this.CurrentRow, (int)DisplayField.MachineId, "");
			}
			// 保存行的TAG属性为选择的收费项目，以备后用
			this.fpSpread1_Sheet1.Rows[this.CurrentRow].Tag = tempItem;

			return 1;
		}

		/// <summary>
		/// 添加新项目（非药品）
		/// [参数: neusoft.HISFC.Models.Base.Item item - 项目]
		/// [返回: int,1-成功,-1-失败]
		/// </summary>
		/// <param name="tempItem">收费项目</param>
		/// <returns>1-成功,-1-失败</returns>
		private int AddNewItem(Neusoft.HISFC.Models.Fee.Item.Undrug tempItem)
		{
			// 价格实体
			Neusoft.FrameWork.Models.NeuObject objectPrice = new NeuObject();
			// 应该取的单价
			decimal decimalPrice = 0m;
			// 合同单位方法类


			//Neusoft.HISFC.BizLogic.Fee.PactUnitInfo pactOperate = new PactUnitInfo();
			// 合同单位
			//neusoft.HISFC.Models.Fee.PactUnitInfo pact = new neusoft.HISFC.Models.Fee.PactUnitInfo();
			//Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
			//
			// 根据合同单位获取价格形式,用来获取应该采用的价格


			//
			// 根据合同单位编码获取价格形式信息
			//pact = pactOperate.GetPactUnitInfoByPactCode(this.register.Pact.ID);
			//// 如果没有取回结果,那么返回
			//if (pact == null)
			//{
			//    MessageBox.Show("获取收费项目的价格形式失败!\n" + pactOperate.Err, "医技终端确认");
			//    this.Focus();
			//    // 清空项目名称
			//    this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");
			//    return -1;
			//}
			//// 价格形式
			//objectPrice.ID = pact.PriceForm;
			//// 患者年龄


			//objectPrice.Name = this.register.Age;
			//// 零售价


			//objectPrice.User01 = item.Price.ToString();
			//// 特诊价


			//objectPrice.User02 = item.Price2.ToString();
			//// 儿童价


			//if (item.IsPharmacy)
			//{
			//    item.Price1 = item.Price;
			//}
			//objectPrice.User03 = item.Price1.ToString();
			//// 获取应该采用的价格


			//decimalPrice = Neusoft.Common.Clinic.Function.Charge.GetPrice(objectPrice);
			decimalPrice = tempItem.Price;
			if (decimalPrice <= 0)
			{
				MessageBox.Show("该项目价格信息不全,不能开立,请将该项目的价格信息维护全!\n" + objectPrice.Memo, "医技终端确认");
				this.Focus();
				// 清空项目名称
				this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");
				return -1;
			}
            Neusoft.HISFC.Models.Fee.Item.Undrug undrugObj = feeMgr.GetItem(tempItem.ID);
            if (!undrugObj.IsNeedConfirm)
            {
                MessageBox.Show("该项目不是终端确认项目,不能在终端科室划价");
                this.Focus();
                // 清空项目名称
                this.Cell(this.CurrentRow, (int)DisplayField.ItemName, "");
                return -1;
            }
			// 是否确认
			this.Cell(this.CurrentRow, (int)DisplayField.ConfirmFlag, "true");
			// 项目名称
			this.Cell(this.CurrentRow, (int)DisplayField.ItemName, tempItem.Name);
			// 项目数量
			this.Cell(this.CurrentRow, (int)DisplayField.ItemAmount, "");
			// 确认数量
			this.Cell(this.CurrentRow, (int)DisplayField.ConfirmAmount, "");
			// 新项目不允许输入确认数量
			this.Lock(this.CurrentRow, (int)DisplayField.ConfirmAmount, true);
			// 项目单价,Tag保留原始价格,以备后用
			if (tempItem.PackQty > 0)
			{
				// 价格/包装数量
				this.Cell(this.CurrentRow, (int)DisplayField.ItemPrice, (decimal.Round(decimalPrice / tempItem.PackQty, 4)).ToString());
			}
			else
			{
				// 价格
				this.Cell(this.CurrentRow, (int)DisplayField.ItemPrice, (decimalPrice).ToString());
			}
			this.fpSpread1_Sheet1.Cells[this.CurrentRow, (int)DisplayField.ItemPrice].Tag = decimalPrice;
			// 已确认数,锁定已确认数
			this.Cell(this.CurrentRow, (int)DisplayField.AlreadyAmount, "0");
			this.Lock(this.CurrentRow, (int)DisplayField.AlreadyAmount, true);
			// 计价单位,保留计价单位到Tag,以备后用
			if (tempItem.Specs.Equals(""))
			{
				// 如果规格为空,直接赋值为计价单位
				this.Cell(this.CurrentRow, (int)DisplayField.ItemUnit, tempItem.PriceUnit);
			}
			else
			{
				// 赋值 = 计价单位[规格]
				this.Cell(this.CurrentRow, (int)DisplayField.ItemUnit, tempItem.PriceUnit + "[" + tempItem.Specs + "]");
			}
			this.fpSpread1_Sheet1.Cells[this.CurrentRow, (int)DisplayField.ItemUnit].Tag = tempItem.PriceUnit;
			// 费用金额
			this.Cell(this.CurrentRow, (int)DisplayField.ItemCost, "");
			// 新旧项目
			this.Cell(this.CurrentRow, (int)DisplayField.NewOld, "新");
			// 项目编码
			this.Cell(this.CurrentRow, (int)DisplayField.ItemCode, tempItem.ID);
			// 是否药品
			//if (tempItem.IsPharmacy)
            if (tempItem.ItemType == HISFC.Models.Base.EnumItemType.Drug)
			{
				this.Cell(this.CurrentRow, (int)DisplayField.IsPhamacy, "1");
			}
			else
			{
				this.Cell(this.CurrentRow, (int)DisplayField.IsPhamacy, "0");
			}
			// 项目执行状态

			this.Cell(this.CurrentRow, (int)DisplayField.ItemStatus, "划价");
			// 最小费用代码

			this.Cell(this.CurrentRow, (int)DisplayField.MiniCode, tempItem.MinFee.ID);
			// 系统类别
			this.Cell(this.CurrentRow, (int)DisplayField.SystemClass, tempItem.SysClass.ID.ToString());
			// 设备信息
			//if (!tempItem.IsPharmacy)
            if (tempItem.ItemType != HISFC.Models.Base.EnumItemType.Drug)
			{
				// 医技设备 ************
				this.Cell(this.CurrentRow, (int)DisplayField.MachineName, "");
				// 设备编号 ************
				this.Cell(this.CurrentRow, (int)DisplayField.MachineId, "");
			}
			// 保存行的TAG属性为选择的收费项目，以备后用
			this.fpSpread1_Sheet1.Rows[this.CurrentRow].Tag = tempItem;

			return 1;
		}

		/// <summary>
		/// 获取指定行的数据，并且存储到承载对象里面
		/// [参数1: int row]
		/// [参数2: neusoft.neHISFC.Components.Management.Transaction trans - 事务对象]
		/// [返回: neusoft.HISFC.Models.MedTech.TerminalApply - 申请单对象]
		/// </summary>
		/// <param name="row">指定的行号</param>
		/// <param name="trans">传入的事务对象</param>
		/// <returns>返回申请单实体</returns>
		public Neusoft.HISFC.Models.Terminal.TerminalApply GetRow(int row)
		{
			#region 变量定义

			// 申请单实体

			Neusoft.HISFC.Models.Terminal.TerminalApply tempTerminalApply = new TerminalApply();
			// 药品实体
			Neusoft.HISFC.Models.Pharmacy.Item drug = new Neusoft.HISFC.Models.Pharmacy.Item();
			// 非药品实体

			Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Undrug();
			// 用来保存没行记录的申请单实体
			Neusoft.HISFC.Models.Terminal.TerminalApply rowApply = new TerminalApply();
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			
			#endregion
			//
			// 设置业务层事务对象

			//
            //confirmIntegrate.SetTrans(trans.Trans);
			//
			// 校验
			//
			// 如果当前行为空，则返回NULL
			if (this.IsNull(row))
			{
				return null;
			}
			// 如果当前项目为旧项目，并且没有选中确认标志，则返回NULL
			if (this.GetItem(row, (int)DisplayField.ConfirmFlag) != "True" && this.GetItem(row, (int)DisplayField.NewOld) == "旧")
			{
				return null;
			}
			//
			// 向承载对象赋值

			//
			// 如果是旧项目,那么患者基本信息采用旧项目本身的;新项目采用当前患者基本信息

			if (this.GetItem(row, (int)DisplayField.NewOld) == "旧")
			{
				rowApply = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[row].Tag)).Clone();
			}
			else
			{
				rowApply.Patient = this.Register;
				
			}
			// 如果当前行没有患者基本信息，那么返回NULL
			if (rowApply.Patient == null && this.register == null)
			{
				return null;
			}
			// 设置ID为就诊号
			// 获取当前选择的记录的患者信息

			if ((this.Register == null || this.Register.PID == null || this.Register.PID.ID == null) &&
				this.fpSpread1_Sheet1.RowCount > 0)
			{
				this.register = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[0].Tag)).Patient;
			}

			#region 设置各个属性

			//
			// 设置各个属性

			//
			if (this.GetItem(row, (int)DisplayField.IsPhamacy) == "1" && this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				tempTerminalApply.Item.Item = new Neusoft.HISFC.Models.Pharmacy.Item();
			}
			else if (this.GetItem(row, (int)DisplayField.IsPhamacy) != "1" && this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				tempTerminalApply.Item.Item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
			}
			// 申请单流水号[3]
			tempTerminalApply.ID = this.GetItem(row, (int)DisplayField.ApplySequence);
			// 住院流水号或门诊号[4]
			tempTerminalApply.Patient.PID.ID = this.register.ID;
			tempTerminalApply.Patient.ID = this.register.ID;
			tempTerminalApply.Patient.PID.CardNO = this.register.PID.CardNO;
            
			// 姓名[5]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的患者姓名 = 当前患者信息的姓名
				tempTerminalApply.Patient.Name = this.register.Name;
			}
			else
			{
				// 老项目的患者姓名 = 本身的患者姓名

				tempTerminalApply.Patient.Name = rowApply.Patient.Name;
			}
			// 合同单位[6]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的合同单位 = 当前患者信息的合同单位
				tempTerminalApply.Patient.Pact.ID = this.register.Pact.ID;
			}
			else
			{
				// 老项目的合同单位 = 本身的合同单位

				tempTerminalApply.Patient.Pact.ID = rowApply.Patient.Pact.ID;
			}
			// 申请部门编码（科室或者病区）[7]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的申请部门 = 当前患者信息的挂号科室
				tempTerminalApply.Item.Order.DoctorDept.ID = this.register.DoctorInfo.Templet.Dept.ID;
			}
			else
			{
				// 老项目的申请部门 = 本身的申请部门

				tempTerminalApply.Item.Order.DoctorDept.ID = rowApply.Item.Order.DoctorDept.ID;
			}
			// 终端科室编码[8]
			tempTerminalApply.Item.ExecOper.Dept.ID = this.currentDepartment;
			// 门诊是挂号科室、住院是在院科室[9]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的挂号科室 = 当前患者信息的挂号科室
				tempTerminalApply.Patient.DoctorInfo.Templet.Dept.ID = this.register.DoctorInfo.Templet.Dept.ID;
			}
			else
			{
				// 老项目的挂号科室 = 本身患者信息的挂号科室
				tempTerminalApply.Patient.DoctorInfo.Templet.Dept.ID = rowApply.Patient.DoctorInfo.Templet.Dept.ID;
			}
			// 发药部门编码[10]
			tempTerminalApply.Item.Order.DoctorDept.ID = this.currentDepartment;
			// 更新库存的流水号(物资)[11]
			tempTerminalApply.UpdateStoreSequence = 0;
			// 开立医师代码[12]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的开立医师 = 当前操作员

				tempTerminalApply.Item.Order.Doctor.ID = this.currentOperator;
				tempTerminalApply.Item.RecipeOper.ID = this.currentOperator;
			}
			else
			{
				// 老项目的开立医师 = 本身开立医师

				tempTerminalApply.Item.Order.Doctor.ID = rowApply.Item.Order.Doctor.ID;
			}
			// 处方号[13]
			tempTerminalApply.Item.RecipeNO = this.GetItem(row, (int)DisplayField.RecipeNo);
			// 处方内项目流水号[14]
			tempTerminalApply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(row, (int)DisplayField.SequenceInRecipe));
			// 项目代码[15]
			tempTerminalApply.Item.Item.ID = this.GetItem(row, (int)DisplayField.ItemCode);
			// 项目名称[16]
			tempTerminalApply.Item.Item.Name = this.GetItem(row, (int)DisplayField.ItemName);
			// 单价[17]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的价格 = 添加过程中计算后的价格

				tempTerminalApply.Item.Item.Price = decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ItemPrice].Tag.ToString());
			}
			else
			{
				// 老项目的价格 = 本身的价格

				tempTerminalApply.Item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemPrice));
			}
			// 数量[18]
			tempTerminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemAmount));
			//当前单位[19]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 新项目的计价单位 = 添加过程中形成的计价单位
				tempTerminalApply.Item.Item.PriceUnit = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ItemUnit].Tag.ToString();
			}
			else
			{
				// 老项目的计价单位 = 本身的计价单位

				tempTerminalApply.Item.Item.PriceUnit = this.GetItem(row, (int)DisplayField.ItemUnit);
			}
			//组套代码[20]
			tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PackageCode);
			// 组套名称[21]
			tempTerminalApply.Item.UndrugComb.Name = this.GetItem(row, (int)DisplayField.PaceageName);
			// 费用金额[22]
			tempTerminalApply.Item.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemCost));
			// 项目状态（0 划价  1 批费 2 执行（药品发放））[23]
			if (this.GetItem(row, (int)DisplayField.ItemStatus) == "划价")
			{
				tempTerminalApply.ItemStatus = "0";
			}
			else if (this.GetItem(row, (int)DisplayField.ItemStatus) == "收费")
			{
				tempTerminalApply.ItemStatus = "1";
			}
			else if (this.GetItem(row, (int)DisplayField.ItemStatus) == "执行")
			{
				tempTerminalApply.ItemStatus = "2";
			}
			// 确认数

			tempTerminalApply.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ConfirmAmount));
			// 已确认数[24]
			tempTerminalApply.AlreadyConfirmCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.AlreadyAmount));
            //// 设备号[25]
            //tempTerminalApply.Machine.ID = this.GetItem(row, (int)DisplayField.MachineId);
			// 新旧项目标志
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				tempTerminalApply.NewOrOld = "1";
				// 操作时间（插入申请单）[34]
				tempTerminalApply.InsertOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime();
				// 操作员（插入申请单）[33]
				tempTerminalApply.InsertOperEnvironment.ID = this.currentOperator;
			}
			else
			{
				tempTerminalApply.NewOrOld = "0";
			}
			// 扩展标志1[28]
			tempTerminalApply.User01 = "";
			// 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)[29]
			tempTerminalApply.User02 = "";
			// 备注[30]
			tempTerminalApply.User03 = "";
			// 医嘱流水号[31]
			tempTerminalApply.Order.ID = this.GetItem(row, (int)DisplayField.OrderSequence);
			// 医嘱执行单流水号[32]
			tempTerminalApply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(row, (int)DisplayField.ExecuteFormSequence));
			
			
			// 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检[35]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 老项目不需要更新此标志,所以只有新项目需要保存

				tempTerminalApply.PatientType = this.register.Memo;
			}
			// 性别[36]
			tempTerminalApply.Patient.Sex.ID = this.register.Sex.ID;
			// 药品发放时间[37]
			tempTerminalApply.SendDrugDate = System.DateTime.MinValue;
			// 终端执行人编号[38]
			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
                tempTerminalApply.ConfirmOperEnvironment.ID = "";
				// 终端执行时间[39]
				tempTerminalApply.ConfirmOperEnvironment.OperTime = DateTime.MinValue;
			}
			else
			{
                //tempTerminalApply.ConfirmOperEnvironment.ID = this.currentOperator;

                //执行人
                if (this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.Operator].Tag != null)
                {
                    tempTerminalApply.ConfirmOperEnvironment.ID = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.Operator].Tag.ToString();
                    tempTerminalApply.ConfirmOperEnvironment.Name = this.GetItem(row, (int)DisplayField.Operator);
                    tempTerminalApply.ConfirmOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime(); 
                }
			}
			
			// 是否药品（1：是/0：否）[40]
			if (this.GetItem(row, (int)DisplayField.IsPhamacy) == "1")
			{
				// 如果是药品设置药品属性

				//tempTerminalApply.Item.Item.IsPharmacy = true;
                tempTerminalApply.Item.Item.ItemType = HISFC.Models.Base.EnumItemType.Drug;
				try
				{
					// 获取药品基本信息
					result = confirmIntegrate.GetDrug(ref drug, tempTerminalApply.Item.Item.ID);
					if (drug != null)
					{
						// 自制药标志

						//tempTerminalApply.Item.IsSelfMade = drug.IsSelfMade;
						// 药品性质*
						//tempTerminalApply.Item.DrugQualityInfo = drug.Quality;
						// 剂型*
						//tempTerminalApply.Item.Order.DoseInfo = drug.DosageForm;
						// 频次*
						tempTerminalApply.Item.Order.Frequency.ID = drug.Frequency.ID;
						if (tempTerminalApply.Item.Order.Frequency.ID == null || tempTerminalApply.Item.Order.Frequency.ID.Equals(""))
						{
							// 如果没有获取到频次信息,那么缺省设置为qd
							tempTerminalApply.Item.Order.Frequency.ID = "qd";
						}
						// 规格
						tempTerminalApply.Item.Item.Specs = drug.Specs;
						// 用法*
						tempTerminalApply.Item.Order.Usage = drug.Usage;
                        if (tempTerminalApply.Item.Order.Usage.ID == null || tempTerminalApply.Item.Order.Usage.ID.Equals(""))
                        {
                            tempTerminalApply.Item.Order.Usage.ID = "01"; 
                        }
						// 院注次数
						tempTerminalApply.Item.InjectCount = 0;
						// 每次用量*
						tempTerminalApply.Item.Order.DoseOnce = drug.OnceDose;
						if (tempTerminalApply.Item.Order.DoseOnce == 0)
						{
							// 如果没有获取到每次用量信息,那么缺省设置为1
							tempTerminalApply.Item.Order.DoseOnce = 1;
						}
						// 每次用量单位
						tempTerminalApply.Item.Order.DoseUnit = drug.DoseUnit;
						// 基本剂量
						//tempTerminalApply.Item.BaseDose = drug.BaseDose;
						// 包装数量*
						tempTerminalApply.Item.Item.PackQty = drug.PackQty;
					}
				}
				catch
				{
				}
			}
			else
			{
				// 设置非药品属性

				//tempTerminalApply.Item.Item.IsPharmacy = false;
                tempTerminalApply.Item.Item.ItemType = HISFC.Models.Base.EnumItemType.UnDrug;
				// 包装数量*
				tempTerminalApply.Item.Item.PackQty = 1;
				try
				{
					// 规格
					tempTerminalApply.Item.Item.Specs = "1";
					// 获取非药品基本信息

					result = confirmIntegrate.GetUndrug(ref undrug, tempTerminalApply.ID);
					if (undrug != null)
					{
						// 检体

						tempTerminalApply.Item.Order.CheckPartRecord = undrug.CheckBody;
					}
				}
				catch
				{
				}
			}
			// 交易类型
			tempTerminalApply.Item.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
			// 门诊号

			tempTerminalApply.Item.ID = this.register.ID;
			// 病历号

			tempTerminalApply.Item.Patient.PID.CardNO = this.register.PID.CardNO;
			// 挂号日期
			//tempTerminalApply.Item.RegDate = this.register.DoctorInfo.SeeDate;
			// 挂号科室
			//tempTerminalApply.Item.RegDeptInfo = this.register.DoctorInfo.Templet.Dept.ID;
			// 开方医生科室

			tempTerminalApply.Item.RecipeOper.Dept.ID = this.currentDepartment;
			// 最小费用代码
            //我服了 终端确认增加划价项目时最小费用编码默认为项目本身编码 {F41218DF-EE7E-444e-AAB3-DA4021FB31CA} wbo 2011-03-01
            //tempTerminalApply.Item.Item.MinFee.ID = this.GetItem(row, (int)DisplayField.MiniCode).PadLeft(3, '0');
            tempTerminalApply.Item.Item.MinFee.ID = this.GetItem(row, (int)DisplayField.MiniCode);
			// 系统类别
			tempTerminalApply.Item.Item.SysClass.ID = this.GetItem(row, (int)DisplayField.SystemClass);
			// 数量
			tempTerminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, 3));
			//是否加急

			tempTerminalApply.Item.IsUrgent = false;
			// 执行科室代码
			tempTerminalApply.Item.ExecOper.Dept.ID = this.currentDepartment;
			// 执行科室名称
			tempTerminalApply.Item.ExecOper.Dept.Name = this.currentDepartmentName;
			// 划价人

			tempTerminalApply.Item.ChargeOper.ID = this.currentOperator;
			// 收费类型
			tempTerminalApply.Item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
			// 是否确认
			tempTerminalApply.Item.IsConfirmed = false;
			// 组套代码
			tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PackageCode);
			// 组套名称
			tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PaceageName);
			// 患者类别

			tempTerminalApply.PatientType = this.Register.Memo;
			// 草药付数
			tempTerminalApply.Item.Days = 1;
			// 扩展标志3:0-最小单位/1-包装单位
			tempTerminalApply.Item.Item.SpecialFlag3 = "0";
			// 费用来源和附材标志

			if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
			{
				// 费用来源:1 医嘱 2 终端 3 体检
				tempTerminalApply.Item.FTSource = "2";
				// 附材标志:1是附材0不是
				//terminalApply.Item.SubJobFlag = "0";

				tempTerminalApply.InsertOperEnvironment.ID = this.currentOperator;
				tempTerminalApply.InsertOperEnvironment.Dept.ID = this.currentDepartment;
				tempTerminalApply.InsertOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime();
			}

            //执行设备{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            if (this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ExecDevice].Tag!=null)
            {
                tempTerminalApply.Machine.ID = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ExecDevice].Tag.ToString();
                tempTerminalApply.Machine.Name = this.GetItem(row, (int)DisplayField.ExecDevice); 
            }
			#endregion

			return tempTerminalApply;
		}

        /// <summary>
        /// 获取指定行的数据，并且存储到承载对象里面
        /// [参数1: int row]
        /// [参数2: neusoft.neHISFC.Components.Management.Transaction trans - 事务对象]
        /// [返回: neusoft.HISFC.Models.MedTech.TerminalApply - 申请单对象]
        /// </summary>
        /// <param name="row">指定的行号</param>
        /// <param name="trans">传入的事务对象</param>
        /// <returns>返回申请单实体</returns>
        public Neusoft.HISFC.Models.Terminal.TerminalApply GetAllRow(int row)
        {
            #region 变量定义

            // 申请单实体

            Neusoft.HISFC.Models.Terminal.TerminalApply tempTerminalApply = new TerminalApply();
            // 药品实体
            Neusoft.HISFC.Models.Pharmacy.Item drug = new Neusoft.HISFC.Models.Pharmacy.Item();
            // 非药品实体

            Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Undrug();
            // 用来保存没行记录的申请单实体
            Neusoft.HISFC.Models.Terminal.TerminalApply rowApply = new TerminalApply();
            // 结果
            Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
            // 业务层

            Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();

            #endregion
            //
            // 设置业务层事务对象

            //
            //confirmIntegrate.SetTrans(trans.Trans);
            //
            // 校验
            //
            // 如果当前行为空，则返回NULL
            if (this.IsNull(row))
            {
                return null;
            }
            // 如果当前项目为旧项目，并且没有选中确认标志，则返回NULL
            //if (this.GetItem(row, (int)DisplayField.ConfirmFlag) != "True" && this.GetItem(row, (int)DisplayField.NewOld) == "旧")
            //{
            //   // return null;
            //}
            //
            // 向承载对象赋值

            //
            // 如果是旧项目,那么患者基本信息采用旧项目本身的;新项目采用当前患者基本信息

            if (this.GetItem(row, (int)DisplayField.NewOld) == "旧")
            {
                rowApply = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[row].Tag)).Clone();
            }
            else
            {
                rowApply.Patient = this.Register;

            }
            // 如果当前行没有患者基本信息，那么返回NULL
            if (rowApply.Patient == null && this.register == null)
            {
                return null;
            }
            // 设置ID为就诊号
            // 获取当前选择的记录的患者信息

            if ((this.Register == null || this.Register.PID == null || this.Register.PID.ID == null) &&
                this.fpSpread1_Sheet1.RowCount > 0)
            {
                this.register = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[0].Tag)).Patient;
            }

            #region 设置各个属性

            //
            // 设置各个属性

            //
            if (this.GetItem(row, (int)DisplayField.IsPhamacy) == "1" && this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                tempTerminalApply.Item.Item = new Neusoft.HISFC.Models.Pharmacy.Item();
            }
            else if (this.GetItem(row, (int)DisplayField.IsPhamacy) != "1" && this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                tempTerminalApply.Item.Item = new Neusoft.HISFC.Models.Fee.Item.Undrug();
            }
            // 申请单流水号[3]
            tempTerminalApply.ID = this.GetItem(row, (int)DisplayField.ApplySequence);
            // 住院流水号或门诊号[4]
            tempTerminalApply.Patient.PID.ID = this.register.ID;
            tempTerminalApply.Patient.ID = this.register.ID;
            tempTerminalApply.Patient.PID.CardNO = this.register.PID.CardNO;

            // 姓名[5]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的患者姓名 = 当前患者信息的姓名
                tempTerminalApply.Patient.Name = this.register.Name;
            }
            else
            {
                // 老项目的患者姓名 = 本身的患者姓名

                tempTerminalApply.Patient.Name = rowApply.Patient.Name;
            }
            // 合同单位[6]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的合同单位 = 当前患者信息的合同单位
                tempTerminalApply.Patient.Pact.ID = this.register.Pact.ID;
            }
            else
            {
                // 老项目的合同单位 = 本身的合同单位

                tempTerminalApply.Patient.Pact.ID = rowApply.Patient.Pact.ID;
            }
            // 申请部门编码（科室或者病区）[7]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的申请部门 = 当前患者信息的挂号科室
                tempTerminalApply.Item.Order.DoctorDept.ID = this.register.DoctorInfo.Templet.Dept.ID;
            }
            else
            {
                // 老项目的申请部门 = 本身的申请部门

                tempTerminalApply.Item.Order.DoctorDept.ID = rowApply.Item.Order.DoctorDept.ID;
            }
            // 终端科室编码[8]
            tempTerminalApply.Item.ExecOper.Dept.ID = this.currentDepartment;
            // 门诊是挂号科室、住院是在院科室[9]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的挂号科室 = 当前患者信息的挂号科室
                tempTerminalApply.Patient.DoctorInfo.Templet.Dept.ID = this.register.DoctorInfo.Templet.Dept.ID;
            }
            else
            {
                // 老项目的挂号科室 = 本身患者信息的挂号科室
                tempTerminalApply.Patient.DoctorInfo.Templet.Dept.ID = rowApply.Patient.DoctorInfo.Templet.Dept.ID;
            }
            // 发药部门编码[10]
            tempTerminalApply.Item.Order.DoctorDept.ID = this.currentDepartment;
            // 更新库存的流水号(物资)[11]
            tempTerminalApply.UpdateStoreSequence = 0;
            // 开立医师代码[12]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的开立医师 = 当前操作员

                tempTerminalApply.Item.Order.Doctor.ID = this.currentOperator;
                tempTerminalApply.Item.RecipeOper.ID = this.currentOperator;
            }
            else
            {
                // 老项目的开立医师 = 本身开立医师

                tempTerminalApply.Item.Order.Doctor.ID = rowApply.Item.Order.Doctor.ID;
            }
            // 处方号[13]
            tempTerminalApply.Item.RecipeNO = this.GetItem(row, (int)DisplayField.RecipeNo);
            // 处方内项目流水号[14]
            tempTerminalApply.Item.SequenceNO = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(row, (int)DisplayField.SequenceInRecipe));
            // 项目代码[15]
            tempTerminalApply.Item.Item.ID = this.GetItem(row, (int)DisplayField.ItemCode);
            // 项目名称[16]
            tempTerminalApply.Item.Item.Name = this.GetItem(row, (int)DisplayField.ItemName);
            // 单价[17]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的价格 = 添加过程中计算后的价格

                tempTerminalApply.Item.Item.Price = decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ItemPrice].Tag.ToString());
            }
            else
            {
                // 老项目的价格 = 本身的价格

                tempTerminalApply.Item.Item.Price = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemPrice));
            }
            // 数量[18]
            tempTerminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemAmount));
            //当前单位[19]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 新项目的计价单位 = 添加过程中形成的计价单位
                tempTerminalApply.Item.Item.PriceUnit = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ItemUnit].Tag.ToString();
            }
            else
            {
                // 老项目的计价单位 = 本身的计价单位

                tempTerminalApply.Item.Item.PriceUnit = this.GetItem(row, (int)DisplayField.ItemUnit);
            }
            //组套代码[20]
            tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PackageCode);
            // 组套名称[21]
            tempTerminalApply.Item.UndrugComb.Name = this.GetItem(row, (int)DisplayField.PaceageName);
            // 费用金额[22]
            tempTerminalApply.Item.FT.OwnCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ItemCost));
            // 项目状态（0 划价  1 批费 2 执行（药品发放））[23]
            if (this.GetItem(row, (int)DisplayField.ItemStatus) == "划价")
            {
                tempTerminalApply.ItemStatus = "0";
            }
            else if (this.GetItem(row, (int)DisplayField.ItemStatus) == "收费")
            {
                tempTerminalApply.ItemStatus = "1";
            }
            else if (this.GetItem(row, (int)DisplayField.ItemStatus) == "执行")
            {
                tempTerminalApply.ItemStatus = "2";
            }
            // 确认数

            tempTerminalApply.Item.ConfirmedQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.ConfirmAmount));
            // 已确认数[24]
            tempTerminalApply.AlreadyConfirmCount = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, (int)DisplayField.AlreadyAmount));
            //// 设备号[25]
            //tempTerminalApply.Machine.ID = this.GetItem(row, (int)DisplayField.MachineId);
            // 新旧项目标志
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                tempTerminalApply.NewOrOld = "1";
                // 操作时间（插入申请单）[34]
                tempTerminalApply.InsertOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime();
                // 操作员（插入申请单）[33]
                tempTerminalApply.InsertOperEnvironment.ID = this.currentOperator;
            }
            else
            {
                tempTerminalApply.NewOrOld = "0";
            }
            // 扩展标志1[28]
            tempTerminalApply.User01 = "";
            // 扩展标志2(收费方式0住院处直接收费,1护士站医嘱收费,2确认收费,3身份变更,4比例调整)[29]
            tempTerminalApply.User02 = "";
            // 备注[30]
            tempTerminalApply.User03 = "";
            // 医嘱流水号[31]
            tempTerminalApply.Order.ID = this.GetItem(row, (int)DisplayField.OrderSequence);
            // 医嘱执行单流水号[32]
            tempTerminalApply.OrderExeSequence = Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(row, (int)DisplayField.ExecuteFormSequence));


            // 患者类别：‘1’ 门诊|‘2’ 住院|‘3’ 急诊|‘4’ 体检[35]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 老项目不需要更新此标志,所以只有新项目需要保存

                tempTerminalApply.PatientType = this.register.Memo;
            }
            // 性别[36]
            tempTerminalApply.Patient.Sex.ID = this.register.Sex.ID;
            // 药品发放时间[37]
            tempTerminalApply.SendDrugDate = System.DateTime.MinValue;
            // 终端执行人编号[38]
            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                tempTerminalApply.ConfirmOperEnvironment.ID = "";
                // 终端执行时间[39]
                tempTerminalApply.ConfirmOperEnvironment.OperTime = DateTime.MinValue;
            }
            else
            {
                //tempTerminalApply.ConfirmOperEnvironment.ID = this.currentOperator;

                //执行人
                if (this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.Operator].Tag != null)
                {
                    tempTerminalApply.ConfirmOperEnvironment.ID = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.Operator].Tag.ToString();
                    tempTerminalApply.ConfirmOperEnvironment.Name = this.GetItem(row, (int)DisplayField.Operator);
                    tempTerminalApply.ConfirmOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime();
                }
            }

            // 是否药品（1：是/0：否）[40]
            if (this.GetItem(row, (int)DisplayField.IsPhamacy) == "1")
            {
                // 如果是药品设置药品属性

                //tempTerminalApply.Item.Item.IsPharmacy = true;
                tempTerminalApply.Item.Item.ItemType = HISFC.Models.Base.EnumItemType.Drug;
                try
                {
                    // 获取药品基本信息
                    result = confirmIntegrate.GetDrug(ref drug, tempTerminalApply.Item.Item.ID);
                    if (drug != null)
                    {
                        // 自制药标志

                        //tempTerminalApply.Item.IsSelfMade = drug.IsSelfMade;
                        // 药品性质*
                        //tempTerminalApply.Item.DrugQualityInfo = drug.Quality;
                        // 剂型*
                        //tempTerminalApply.Item.Order.DoseInfo = drug.DosageForm;
                        // 频次*
                        tempTerminalApply.Item.Order.Frequency.ID = drug.Frequency.ID;
                        if (tempTerminalApply.Item.Order.Frequency.ID == null || tempTerminalApply.Item.Order.Frequency.ID.Equals(""))
                        {
                            // 如果没有获取到频次信息,那么缺省设置为qd
                            tempTerminalApply.Item.Order.Frequency.ID = "qd";
                        }
                        // 规格
                        tempTerminalApply.Item.Item.Specs = drug.Specs;
                        // 用法*
                        tempTerminalApply.Item.Order.Usage = drug.Usage;
                        if (tempTerminalApply.Item.Order.Usage.ID == null || tempTerminalApply.Item.Order.Usage.ID.Equals(""))
                        {
                            tempTerminalApply.Item.Order.Usage.ID = "01";
                        }
                        // 院注次数
                        tempTerminalApply.Item.InjectCount = 0;
                        // 每次用量*
                        tempTerminalApply.Item.Order.DoseOnce = drug.OnceDose;
                        if (tempTerminalApply.Item.Order.DoseOnce == 0)
                        {
                            // 如果没有获取到每次用量信息,那么缺省设置为1
                            tempTerminalApply.Item.Order.DoseOnce = 1;
                        }
                        // 每次用量单位
                        tempTerminalApply.Item.Order.DoseUnit = drug.DoseUnit;
                        // 基本剂量
                        //tempTerminalApply.Item.BaseDose = drug.BaseDose;
                        // 包装数量*
                        tempTerminalApply.Item.Item.PackQty = drug.PackQty;
                    }
                }
                catch
                {
                }
            }
            else
            {
                // 设置非药品属性

                //tempTerminalApply.Item.Item.IsPharmacy = false;
                tempTerminalApply.Item.Item.ItemType = HISFC.Models.Base.EnumItemType.UnDrug;
                // 包装数量*
                tempTerminalApply.Item.Item.PackQty = 1;
                try
                {
                    // 规格
                    tempTerminalApply.Item.Item.Specs = "1";
                    // 获取非药品基本信息

                    result = confirmIntegrate.GetUndrug(ref undrug, tempTerminalApply.ID);
                    if (undrug != null)
                    {
                        // 检体

                        tempTerminalApply.Item.Order.CheckPartRecord = undrug.CheckBody;
                    }
                }
                catch
                {
                }
            }
            // 交易类型
            tempTerminalApply.Item.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
            // 门诊号

            tempTerminalApply.Item.ID = this.register.ID;
            // 病历号

            tempTerminalApply.Item.Patient.PID.CardNO = this.register.PID.CardNO;
            // 挂号日期
            //tempTerminalApply.Item.RegDate = this.register.DoctorInfo.SeeDate;
            // 挂号科室
            //tempTerminalApply.Item.RegDeptInfo = this.register.DoctorInfo.Templet.Dept.ID;
            // 开方医生科室

            tempTerminalApply.Item.RecipeOper.Dept.ID = this.currentDepartment;
            // 最小费用代码

            tempTerminalApply.Item.Item.MinFee.ID = this.GetItem(row, (int)DisplayField.MiniCode).PadLeft(3, '0');
            // 系统类别
            tempTerminalApply.Item.Item.SysClass.ID = this.GetItem(row, (int)DisplayField.SystemClass);
            // 数量
            tempTerminalApply.Item.Item.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.GetItem(row, 3));
            //是否加急

            tempTerminalApply.Item.IsUrgent = false;
            // 执行科室代码
            tempTerminalApply.Item.ExecOper.Dept.ID = this.currentDepartment;
            // 执行科室名称
            tempTerminalApply.Item.ExecOper.Dept.Name = this.currentDepartmentName;
            // 划价人

            tempTerminalApply.Item.ChargeOper.ID = this.currentOperator;
            // 收费类型
            tempTerminalApply.Item.PayType = Neusoft.HISFC.Models.Base.PayTypes.Charged;
            // 是否确认
            tempTerminalApply.Item.IsConfirmed = false;
            // 组套代码
            tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PackageCode);
            // 组套名称
            tempTerminalApply.Item.UndrugComb.ID = this.GetItem(row, (int)DisplayField.PaceageName);
            // 患者类别

            tempTerminalApply.PatientType = this.Register.Memo;
            // 草药付数
            tempTerminalApply.Item.Days = 1;
            // 扩展标志3:0-最小单位/1-包装单位
            tempTerminalApply.Item.Item.SpecialFlag3 = "0";
            // 费用来源和附材标志

            if (this.GetItem(row, (int)DisplayField.NewOld) == "新")
            {
                // 费用来源:1 医嘱 2 终端 3 体检
                tempTerminalApply.Item.FTSource = "2";
                // 附材标志:1是附材0不是
                //terminalApply.Item.SubJobFlag = "0";

                tempTerminalApply.InsertOperEnvironment.ID = this.currentOperator;
                tempTerminalApply.InsertOperEnvironment.Dept.ID = this.currentDepartment;
                tempTerminalApply.InsertOperEnvironment.OperTime = confirmIntegrate.GetCurrentDateTime();
            }

            //执行设备{810581A3-6DF5-49af-8A5F-D7F843CBEA89}
            if (this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ExecDevice].Tag != null)
            {
                tempTerminalApply.Machine.ID = this.fpSpread1_Sheet1.Cells[row, (int)DisplayField.ExecDevice].Tag.ToString();
                tempTerminalApply.Machine.Name = this.GetItem(row, (int)DisplayField.ExecDevice);
            }
            #endregion

            return tempTerminalApply;
        }
        /// <summary>
        /// 获取需要扣门诊账户的项目列表 的总金额 
        /// </summary>
        /// <returns></returns>
        public decimal QueryOldList()
        {
            decimal totCost = 0;
            for (int row = 0; row < this.fpSpread1_Sheet1.RowCount; row++)
            {
                //只选择选中的项目

                if (this.GetItem(row, (int)DisplayField.ConfirmFlag) == "True"  && GetItem(row, (int)DisplayField.NewOld) == "旧")
                {
                    //totCost += Neusoft.FrameWork.Function.NConvert.ToDecimal(GetItem(row, (int)DisplayField.ItemCost));
                    decimal price = Neusoft.FrameWork.Function.NConvert.ToDecimal(GetItem(row, (int)DisplayField.ItemPrice));
                    decimal count = Neusoft.FrameWork.Function.NConvert.ToDecimal(GetItem(row, (int)DisplayField.ConfirmAmount));
                    totCost += price * count;
                }
            }
            return totCost;

        }
        /// <summary>
        /// 获取需要扣门诊账户的项目列表 的总金额 
        /// </summary>
        /// <returns></returns>
        public decimal QueryNewList()
        {
            decimal totCost = 0;
            for (int row = 0; row < this.fpSpread1_Sheet1.RowCount; row++)
            {
                //只选择选中的项目

                if (this.GetItem(row, (int)DisplayField.ConfirmFlag) == "True" && GetItem(row, (int)DisplayField.ItemStatus) == "划价" && GetItem(row, (int)DisplayField.NewOld) == "新")
                {
                    totCost += Neusoft.FrameWork.Function.NConvert.ToDecimal(GetItem(row, (int)DisplayField.ItemCost));
                    
                }
            }
            return totCost;
        }
        #endregion

        /// <summary>
        /// 根据挂号信息检索所有的申请单明细（老项目）
        /// [参数1: bool boolClear - 是否清空当前列表]
        /// [参数2: bool boolCardNo - 是否以病历号查询]
        /// [参数3: bool boolOther - 是否查询其它科室的项目信息]
        /// </summary>
        /// <param name="boolClear">是否清空</param>
        /// <param name="boolCardNo">是否以病历号查询</param>
        /// <param name="boolOther">是否是查询其它科室的项目信息</param>
        public void GetApplyByRegister(bool boolClear, bool boolCardNo, bool boolOther)
		{
			#region 变量定义

			// 用于保存获取的申请单明细
			ArrayList applyList = new ArrayList();
			// 非药品实体

			Neusoft.HISFC.Models.Fee.Item.Undrug undrug = new Undrug();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			
			#endregion
			//
			// 获取当前环境信息
			//
			// 当前科室编号
			this.currentDepartment = Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm.CurrentOperEnvironment.Dept.ID;
			// 当前科室名称
			this.currentDepartmentName = Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm.CurrentOperEnvironment.Dept.Name;
			// 当前操作员编号

			this.currentOperator = Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm.CurrentOperEnvironment.ID;
			
			//
			// 执行查询，获取申请单明细
			//
			if (!boolCardNo)
			{
				// 不以病历号查询,那么以就诊号查询
				result = confirmIntegrate.QueryApplyListByClinicCode(this.register.ID, ref applyList, this.currentDepartment);
			}
			else
			{
                if (register.Memo == "5" && IsConfirm)  //如果是体检,并且 集体体检需要先插终端确认表
                {
                    Neusoft.HISFC.Models.PhysicalExamination.Register objReg = examiMgr.GetRegisterByClinicNO(register.ID);
                    // 以病历号查询
                    if (boolOther)
                    {
                        result = confirmIntegrate.QueryApplyListByCardNO(this.Register.PID.CardNO, ref applyList, "", true);
                    }
                    else
                    {
                        result = confirmIntegrate.QueryApplyListByCardNO(this.Register.PID.CardNO, ref applyList, this.currentDepartment, true);
                    }
                }
                else
                {
                    // 以病历号查询
                    if (boolOther)
                    {
                        result = confirmIntegrate.QueryApplyListByCardNO(this.Register.PID.CardNO, ref applyList, "", false);
                    }
                    else
                    {
                        result = confirmIntegrate.QueryApplyListByCardNO(this.Register.PID.CardNO, ref applyList, this.currentDepartment, false);
                    }
                }
			}
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				MessageBox.Show("获取患者医技项目明细失败\n" + confirmIntegrate.Err, "医技终端确认");
				this.Focus();
				return;
			}
			//
			// 清空申请单明细FARPOINT表格
			//
			if (boolClear)
			{
                fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);
			}
			//
			// 循环赋值

			//
            ArrayList alApplyListFill = new ArrayList();
            foreach (Neusoft.HISFC.Models.Terminal.TerminalApply apply in applyList)
            {
                if (apply.Patient.DoctorInfo.Templet.Dept.ID == this.register.DoctorInfo.Templet.Dept.ID)
                {
                    alApplyListFill.Add(apply);
                }
            }

            foreach (Neusoft.HISFC.Models.Terminal.TerminalApply apply in alApplyListFill)
			{
				// 科室
				Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department ();
				//
				// 增加一行

				//
				this.AddRow(0);
				//
				// 获取非药品设备信息

				//
				//if (!apply.Item.Item.IsPharmacy)
                if (apply.Item.Item.ItemType != HISFC.Models.Base.EnumItemType.Drug)
				{
					result = confirmIntegrate.GetUndrug(ref undrug, apply.Item.ID);
				}
				//
				// 老项目设置行的TAG属性为申请单实体

				//
				this.fpSpread1_Sheet1.Rows[0].Tag = apply;
				
				#region 设置各个FARPOINT字段
				//
				// 设置各个FARPOINT字段
				//
				// 是否确认0
				this.Cell(0, (int)DisplayField.ConfirmFlag, "false");
				// 项目名称1
				this.Cell(0, (int)DisplayField.ItemName, apply.Item.Item.Name);
                this.fpSpread1_Sheet1.Cells[0, (int)DisplayField.ItemName].Locked = true;
				// 项目数量3
				this.Cell(0, (int)DisplayField.ItemAmount, apply.Item.Item.Qty.ToString());
				// 确认数量6
				this.Cell(0, (int)DisplayField.ConfirmAmount, (apply.Item.Item.Qty - apply.AlreadyConfirmCount).ToString());
				// 医技设备7
				//if (!apply.Item.Item.IsPharmacy)
                if (apply.Item.Item.ItemType != HISFC.Models.Base.EnumItemType.Drug)
				{
					this.Cell(0, (int)DisplayField.MachineName, apply.Machine.Name);
				}
				// 设备编号8
				this.Cell(0, (int)DisplayField.MachineId, apply.Machine.ID);
				// 非药品,设置设备信息
				//if (!apply.Item.Item.IsPharmacy)
                if (apply.Item.Item.ItemType != HISFC.Models.Base.EnumItemType.Drug)
				{
					if (undrug != null && undrug.MachineNOs != null)
					{
						// 下拉类型的Cell
						FarPoint.Win.Spread.CellType.ComboBoxCellType comboType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
						for (int i = 0;i < undrug.MachineNOs.Count;i++)
						{
							// 增加项目信息
							comboType.Items[i] = undrug.MachineNOs[i].ToString();
						}
						// 设置Cell类型
						this.fpSpread1_Sheet1.Cells[0, (int)DisplayField.MachineId].CellType = comboType;
					}
				}
				// 项目单价2
				this.Cell(0, (int)DisplayField.ItemPrice, apply.Item.Item.Price.ToString());
				// 已确认数9
				this.Cell(0, (int)DisplayField.AlreadyAmount, apply.AlreadyConfirmCount.ToString());
				// 计价单位4
				this.Cell(0, (int)DisplayField.ItemUnit, apply.Item.Item.PriceUnit);
				// 费用金额5
				this.Cell(0, (int)DisplayField.ItemCost, apply.Item.FT.TotCost.ToString());
				// 新旧项目10
				if (apply.NewOrOld == "0")
				{
					this.Cell(0, (int)DisplayField.NewOld, "旧");
				}
				else
				{
					this.Cell(0, (int)DisplayField.NewOld, "新");
				}
				// 申请单流水号11
				this.Cell(0, (int)DisplayField.ApplySequence, apply.ID);
				// 处方号12
				this.Cell(0, (int)DisplayField.RecipeNo, apply.Item.RecipeNO);
				// 处方内项目流水号13
				this.Cell(0, (int)DisplayField.SequenceInRecipe, apply.Item.SequenceNO.ToString());
				// 项目编码14
				this.Cell(0, (int)DisplayField.ItemCode, apply.Item.Item.ID);
				// 组套代码15
				this.Cell(0, (int)DisplayField.PackageCode, apply.Item.UndrugComb.ID);
				// 组套名称16
				this.Cell(0, (int)DisplayField.PaceageName, apply.Item.UndrugComb.Name);
				// 是否药品17
				//if (apply.Item.Item.IsPharmacy)
                if(apply.Item.Item.ItemType == HISFC.Models.Base.EnumItemType.Drug)
				{
					this.Cell(0, (int)DisplayField.IsPhamacy, "是");
				}
				else
				{
					this.Cell(0, (int)DisplayField.IsPhamacy, "否");
				}
				// 项目状态18
				if (apply.ItemStatus == "0")
				{
					this.Cell(0, (int)DisplayField.ItemStatus, "划价");
				}
				else if (apply.ItemStatus == "1")
				{
					this.Cell(0, (int)DisplayField.ItemStatus, "收费");
				}
				else if (apply.ItemStatus == "2")
				{
					this.Cell(0, (int)DisplayField.ItemStatus, "执行");
				}
				// 医嘱号

				this.Cell(0, (int)DisplayField.OrderSequence, apply.Order.ID);
				// 医嘱执行单号
				this.Cell(0, (int)DisplayField.ExecuteFormSequence, apply.OrderExeSequence.ToString());
				#endregion
				// 执行科室
				result = confirmIntegrate.GetDept(ref dept, apply.Item.ExecOper.Dept.ID);
				this.Cell(0, (int)DisplayField.ExecuteDepartment, dept.Name);
                this.Lock(0, (int)DisplayField.ExecuteDepartment, true);
			}
			//
			// 设置列可否修改

			//
			for (int i = 0;i < this.fpSpread1_Sheet1.RowCount;i++)
			{
				// 项目单价2
				this.Lock(i, (int)DisplayField.ItemPrice, true);
				// 已确认数9
				this.Lock(i, (int)DisplayField.AlreadyAmount, true);
				// 计价单位4
				this.Lock(i, (int)DisplayField.ItemUnit, true);
				// 费用金额5
				this.Lock(i, (int)DisplayField.ItemCost, true);
				// 新旧项目10
				this.Lock(i, (int)DisplayField.NewOld, true);
				// 是否药品17
				this.Lock(i, (int)DisplayField.IsPhamacy, true);
				// 老项目

				if (this.GetItem(i, (int)DisplayField.NewOld) == "旧")
				{
					// 项目名称1
					FarPoint.Win.Spread.CellType.TextCellType textType = new TextCellType();
					// 只读
					textType.ReadOnly = true;
					// 设置项目名称
					this.fpSpread1_Sheet1.Cells[i, (int)DisplayField.ItemName].CellType = textType;
					// 锁定项目数量3
					this.Lock(i, (int)DisplayField.ItemAmount, true);
                    //this.Lock(i, (int)DisplayField.ConfirmAmount, true); //加上这行,就控制项目不可以分开确认,去掉就可以分次确认


				}
			}
		}

		/// <summary>
		/// 校验数据
		/// [返回: int, 1-成功,-1-失败]
		/// </summary>
		/// <returns>1：成功；-1：失败</returns>
		public int DataValidate()
		{
			// 业务层

            this.fpSpread1.StopCellEditing();
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 药品实体
			Neusoft.HISFC.Models.Pharmacy.Item drug = new Neusoft.HISFC.Models.Pharmacy.Item ();
			// 计算有效记录个数
			int j = 0;
			//
			// 循环判断
			//
			for (int i = 0;i < this.RowCount;i++)
			{
                if (this.fpSpread1_Sheet1.Cells[i, (int)DisplayField.ConfirmFlag].Value == null || this.fpSpread1_Sheet1.Cells[i, (int)DisplayField.ConfirmFlag].Value.ToString().ToUpper() != "TRUE")
                {
                    continue;
                }
				if (this.GetItem(i, (int)DisplayField.NewOld) == "新")
                {
                    #region 新增的项目

                    // 新项目的项目名称不允许为空

					if (this.GetItem(i, (int)DisplayField.ItemName).Equals(""))
					{
						MessageBox.Show("第" + (i + 1).ToString() + "行的项目名称为空，不能保存。", "医技终端确认");
						this.Focus();
						this.CurrentColumn = (int)DisplayField.ItemName;
						return -1;
					}
					// 新项目的项目数量不允许为空


                    //if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(i, (int)DisplayField.ConfirmAmount)) == 0)
                    //{
                    //    MessageBox.Show("确认数量不能为零");
                    //    this.Focus();
                    //    this.CurrentColumn = (int)DisplayField.ConfirmAmount;
                    //    return -1;
                    //}
					if (this.GetItem(i, (int)DisplayField.ItemAmount).Equals(""))
					{
						MessageBox.Show("第" + (i + 1).ToString() + "行的项目数量为空，不能保存。", "医技终端确认");
						this.Focus();
						this.CurrentColumn = (int)DisplayField.ItemAmount;
						return -1;
					}
					// 新项目的项目数量必须为数字

					if (!this.GetItem(i, (int)DisplayField.ItemAmount).Equals(""))
					{
						try
						{
                            if (Convert.ToDecimal(this.GetItem(i, (int)DisplayField.ItemAmount)) == 0)
                            {
                                MessageBox.Show("第:" + (i + 1) + "行的项目数量不能为零 不能保存 \n 医技终端确认");
                                this.Focus();
                                this.CurrentColumn = (int)DisplayField.ItemAmount;
                                return -1;
                            }
						}
						catch (Exception e)
						{
							MessageBox.Show("第:" + (i + 1) + "行的项目数量输入非法\n" + e.Message + "医技终端确认");
							this.Focus();
							this.CurrentColumn = (int)DisplayField.ItemAmount;
							return -1;
						}
					}
					// 项目编码和项目名称是否匹配一致

					result = confirmIntegrate.GetDrug(ref drug, this.GetItem(i, (int)DisplayField.ItemCode));
					try
					{
						if (!drug.Name.Equals(this.GetItem(i, (int)DisplayField.ItemName)))
						{
							MessageBox.Show("第:" + (i + 1) + "行的项目开立错误,可能是项目不存在或者是项目编码与项目名称不匹配", "医技终端确认");
							this.Focus();
							this.CurrentColumn = (int)DisplayField.ItemName;
							return -1;
						}
					}
					catch
					{
                    }
                    #endregion 
                }
				if (this.GetItem(i, (int)DisplayField.NewOld) == "旧")
				{
                    // 确认数量必须是数字

                    #region 旧项目

                    try
					{
						Convert.ToDecimal(this.GetItem(i, (int)DisplayField.ConfirmAmount)); // 确认数量
                        if (Neusoft.FrameWork.Function.NConvert.ToInt32(this.GetItem(i, (int)DisplayField.ConfirmAmount)) == 0)
                        {
                            MessageBox.Show("确认数量不能为零");
                            this.Focus();
                            this.CurrentColumn = (int)DisplayField.ConfirmAmount;
                            return -1;
                        }
					}
					catch (Exception e)
					{
						MessageBox.Show("第:" + (i + 1) + "行的确认数量输入非法\n" + e.Message + "医技终端确认");
						this.Focus();
						this.CurrentColumn = (int)DisplayField.ConfirmAmount;
						return -1;
                    }

                    #region  校验是否会发生并发操作 
                    Neusoft.HISFC.Models.Terminal.TerminalApply objApply = (Neusoft.HISFC.Models.Terminal.TerminalApply)this.fpSpread1_Sheet1.Rows[i].Tag;
                    Neusoft.HISFC.Models.Terminal.TerminalApply objTemp =  confirmMgr.GetItemListBySequence(objApply.Order.ID,objApply.ID);
                    if (objTemp.ID == null || objTemp.ID == "")
                    {
                        //判断当前已确认数量是否发生变化

                        MessageBox.Show("当前数据已发生变化,请刷新数据");
                        return -1;
                    }
                    if (objTemp.AlreadyConfirmCount != Neusoft.FrameWork.Function.NConvert.ToDecimal(fpSpread1_Sheet1.Cells[i, (int)DisplayField.AlreadyAmount].Text))
                    {
                        //判断当前已确认数量是否发生变化

                        MessageBox.Show("当前数据已发生变化,请刷新数据");
                        return -1;
                    }

                    if (objTemp.Item.Item.Qty != Neusoft.FrameWork.Function.NConvert.ToDecimal(fpSpread1_Sheet1.Cells[i, (int)DisplayField.ItemAmount].Text))
                    {
                        //判断当前已确认数量是否发生变化

                        MessageBox.Show("当前数据已发生变化,请刷新数据");
                        return -1;
                    }
                    #endregion 
                    #endregion
                }
                
				// 项目数量 = 已确认数量 + 确认数量
				if (this.GetItem(i, (int)DisplayField.ConfirmAmount).Equals(""))
				{
					this.Cell(i, 9, "0");
				}
				if (this.GetItem(i, (int)DisplayField.NewOld) == "旧")
				{
					if (Convert.ToDecimal(this.GetItem(i, (int)DisplayField.ItemAmount)) < Convert.ToDecimal(this.GetItem(i, (int)DisplayField.AlreadyAmount)) + Convert.ToDecimal(this.GetItem(i, (int)DisplayField.ConfirmAmount)))
					{
						MessageBox.Show("第:" + (i + 1) + "行的确认数量大于最大可确认数量", "医技终端确认");
						this.Focus();
						this.CurrentRow = i;
						this.CurrentColumn = (int)DisplayField.ConfirmAmount;
						return -1;
					}
				}
				// 旧项目中的选中项目才是有效项目
				if (this.GetItem(i, (int)DisplayField.NewOld) == "旧")
				{
					if (this.GetItem(i, (int)DisplayField.ConfirmFlag) == "True")
					{
						j++;
					}
				}
				else // 新项目通过有效校验的就是有效项目

				{
					j++;
				}
			}
			// 如果没有有效项目不予以保存

			if (j == 0)
			{
				MessageBox.Show("请选择需要确认的项目");
				this.Focus();
				this.fpSpread1.Focus();
				return -1;
			}
			// 返回
			return 1;
		}

		/// <summary>
		/// 使收费项目消失

		/// </summary>
		public void UnDisplayUcItemList()
		{
			if (this.ucItemList.Visible)
			{
				this.ucItemList.Visible = false;
			}
		}

		/// <summary>
		/// 根据医嘱号获取发票明细

		/// [参数: string orderCode - 医嘱号]
		/// </summary>
		/// <param name="orderCode">医嘱号</param>
		public void GetInvoiceDetailByOrder(string clinicCode, string orderCode)
		{
			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			// 查询结果
			System.Data.DataSet dsResult = new DataSet();
			//
			// 执行查询
			//
			result = confirmIntegrate.QueryInvoiceDetailByOrderCode(ref dsResult, orderCode);
			if (result == Neusoft.HISFC.BizProcess.Integrate.Terminal.Result.Failure)
			{
				MessageBox.Show("获取发票明细内容失败!\n" + confirmIntegrate.Err);
			}
			if (dsResult.Tables.Count == 0)
			{
				return;
			}
			//
			// 设置结果
			//
			this.fpSpread2_Sheet1.DataSource = dsResult;
		}


        /// <summary>
        /// 根据clinicCode获取收费明细----{F7A86CA8-6C64-4f27-955C-6B5B912E495F}
        /// [参数: string orderCode - 医嘱号]
        /// </summary>
        /// <param name="orderCode">医嘱号</param>
        public void GetFeeDetailByClinicCode(string clinicCode)
        {
            this.fpSpread2_Sheet1.RowCount = 0;

            ArrayList feeItems =  feeMgr.QueryFeeItemListsByClinicNO(clinicCode);

            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            

            if ( feeItems==null )
            {
                MessageBox.Show("获取费用明细内容失败!\n" + feeMgr.Err);
                return;
            }

            if ( feeItems.Count<=0 )
            {
                MessageBox.Show("没有找到费用明细!\n" + feeMgr.Err);
                return;
            }
            //
            // 设置结果
            //
            Hashtable htExecDept = new Hashtable();
            foreach (Neusoft.HISFC.Models.Fee.Outpatient.FeeItemList item in feeItems) 
            {
                if (item.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.UnDrug)
                {
                    this.fpSpread2_Sheet1.Rows.Add(this.fpSpread2_Sheet1.RowCount, 1);
                    FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
                    this.fpSpread2_Sheet1.Cells[this.fpSpread2_Sheet1.RowCount - 1, 0].CellType = txt;
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 0, item.Item.ID);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 1, item.Item.Name);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 2, item.Item.PriceUnit);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 3, item.Item.Price);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 4, item.Item.Qty);

                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 5, 
                          Neusoft.FrameWork.Function.NConvert.ToDecimal( item.Item.Price * item.Item.Qty));

                    //Neusoft.HISFC.Models.Base.Department dept = manager.GetDepartment(item.RecipeOper.Dept.ID);
                    //this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 6, dept.Name);

                    //begin加入执行科室及优化 {1295A6EE-BCF1-4ece-B91D-67AD46BABE9F} wbo 2011-03-16
                    Neusoft.HISFC.Models.Base.Department deptRec = new Department();
                    Neusoft.HISFC.Models.Base.Department deptExec = new Department();
                    if (htExecDept.Contains(item.RecipeOper.Dept.ID))
                    {
                        deptRec = htExecDept[item.RecipeOper.Dept.ID] as Department;
                    }
                    else
                    {
                        deptRec = manager.GetDepartment(item.RecipeOper.Dept.ID);
                        if (!htExecDept.Contains(deptRec.ID))
                        {
                            htExecDept.Add(deptRec.ID, deptRec);
                        }
                    }
                    if (htExecDept.Contains(item.ExecOper.Dept.ID))
                    {
                        deptExec = htExecDept[item.ExecOper.Dept.ID] as Department;
                    }
                    else
                    {
                        deptExec = manager.GetDepartment(item.ExecOper.Dept.ID);
                        if (!htExecDept.Contains(deptExec.ID))
                        {
                            htExecDept.Add(deptExec.ID, deptExec);
                        }
                    }
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 6, deptRec.Name);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 7, deptExec.Name);
                    //end加入执行科室

                    //
                    Neusoft.HISFC.Models.Base.Employee emp =  manager.GetEmployeeInfo(item.FeeOper.ID);
                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 8, emp.Name);

                    this.fpSpread2_Sheet1.SetValue(this.fpSpread2_Sheet1.RowCount - 1, 9, item.FeeOper.OperTime.ToString("yyyy-MM-dd"));

                }
            }

            //this.fpSpread2_Sheet1.DataSource = dsResult;
        }

		/// <summary>
		/// 是收费项目选择控件不可见

		/// </summary>
		private void MakeItemListDisappear()
		{
			if (this.ucItemList.Visible)
			{
				this.ucItemList.Visible = false;
			}
		}

        /// <summary>
        /// 显示检查申请单
        /// </summary>
        private void ShowPacsApply(int rowIndex)
        {
            string applyNo = string.Empty;
            if (!string.IsNullOrEmpty(isUseDL) && isUseDL == "1")
            {
                #region {5E5299D8-95A2-4498-B2F1-52D00E4FB11A} UpdateApply需要使用Neusoft.HISFC.Components.PacsApply.HisInterface,以后需要电子申请单重构到Neusoft.ApplyInterface.HisInterface中
                //if (hisInterface == null)
                //{
                //    hisInterface = new Neusoft.ApplyInterface.HisInterface();
                //}
                //int rowIndex = this.fpSpread1_Sheet1.ActiveRowIndex;
                if (rowIndex == -1)
                {
                    return;
                }
                if (hisInterface == null)
                {
                    hisInterface = new Neusoft.HISFC.Components.PacsApply.HisInterface(Neusoft.FrameWork.Management.Connection.Operator.ID, (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID);
                    (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).Password = passWord;
                    (Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee).User01 = account;
                }
                #endregion

                if (this.GetItem(rowIndex, (int)DisplayField.NewOld) == "旧")
                {
                    Neusoft.HISFC.Models.Terminal.TerminalApply apply = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[rowIndex].Tag)).Clone();
                    if (apply == null)
                    {
                        return;
                    }
                    Neusoft.HISFC.Models.Order.Order order = orderIntegrate.GetOneOrder(apply.Order.ID);
                    if (order == null)
                    {
                        MessageBox.Show("没有查到医嘱信息！" + orderIntegrate.Err);
                        return;
                    }
                    if (!string.IsNullOrEmpty(order.ApplyNo))
                    {
                        if (hisInterface.UpdateApply(order.ApplyNo) < 0)
                        {
                            MessageBox.Show("查询电子申请单失败！");
                        }
                    }
                }
            }
        }
		#endregion

		#region 事件

		/// <summary>
		/// 项目选择控件选择项目事件
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		int ucItemList_SelectItem(Keys key)
		{
			// 双击产生的插入操作

			this.InsertNew();
			// 设置插入后的焦点为项目数量

			if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemCode) != "")
			{
				this.fpSpread1.Focus();
				this.CurrentColumn = (int)DisplayField.ItemAmount;
				this.fpSpread1.EditMode = true;
			}
			
			return 0;
		}

		/// <summary>
		/// 确认项目表格单击事件，根据当前明细加载明细记载的患者基本信息

		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
         
            if (this.RowCount == 0)
            {
                return;
            }
            if (e.Column == (int)DisplayField.ConfirmFlag)
            {
                this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Value = !Neusoft.FrameWork.Function.NConvert.ToBoolean(this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Value);
                Neusoft.HISFC.Models.Terminal.TerminalApply applyOrgin = this.GetAllRow(e.Row);
                #region {B98AE903-3A36-4b42-9301-D51B59338253}
                if (applyOrgin == null)
                {
                    return;
                }

                #endregion
                Neusoft.HISFC.Models.Terminal.TerminalApply apply;
                for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                {
                    apply = new TerminalApply();
                    apply = this.GetAllRow(i);
                    //{E0E2E484-0230-4448-9C9C-8D85EDB4ECA5} by niuxy
                    if (apply == null)
                    {
                        return;
                    }
                    if (applyOrgin.Order.ID == apply.Order.ID)
                    {
                        this.fpSpread1_Sheet1.Cells[i, e.Column].Value = this.fpSpread1_Sheet1.Cells[e.Row, e.Column].Value;

                    }
                }
                
            }

            

            //if (this.GetItem(e.Row, 10) == "旧")
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索项目的患者基本信息...");
            //    Application.DoEvents();

            //    // 挂号实体
            //    Neusoft.HISFC.Models.Registration.Register tempRegiser = new Register();
            //    // 住院实体
            //    Neusoft.HISFC.Models.RADT.PatientInfo inpatient = new PatientInfo();
            //    // 业务层

            //    Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm();
            //    // 科室实体
            //    Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
            //    // 获取当前选择的记录的患者信息


            //    this.register = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[e.Row].Tag)).Patient;
            //    // 根据门诊号获取患者基本信息


            //    tempRegiser = this.register.Clone();
            //    if (tempRegiser.Memo != "2")
            //    {
            //        if (confirmIntegrate.GetRegisterByClinicCode(ref tempRegiser, tempRegiser.ID) == Result.Success)
            //        {
            //            if (tempRegiser != null)
            //            {
            //                this.register.Birthday = tempRegiser.Birthday;
            //            }
            //        }
            //        else
            //        {
            //            inpatient.ID = this.register.ID;
            //            if (confirmIntegrate.GetInpatient(inpatient.ID, ref inpatient) == Result.Success)
            //            {
            //                this.register.Birthday = inpatient.Birthday;
            //            }
            //        }


            //        if (this.register.Age == null || this.register.Age.Equals(""))
            //        {
            //            string age = "";
            //            confirmIntegrate.GetAge(ref age, this.register.Birthday);
            //            this.register.Age = age;
            //            this.register.Age = this.register.Age.Substring(0, this.register.Age.Length - 1);
            //        }
            //        confirmIntegrate.GetDept(ref dept, this.register.DoctorInfo.Templet.Dept.ID);
            //        this.register.DoctorInfo.Templet.Dept = dept;
            //        this.ClickApply(sender, e);
            //        //
            //        // 根据医嘱号获取发票明细

            //        //
            //        if (this.register.Memo == "2" || this.register.Memo == "3")
            //        {
            //            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //            return;
            //        }
            //        if (this.GetItem(e.Row, (int)DisplayField.OrderSequence) != null && this.GetItem(e.Row, (int)DisplayField.OrderSequence) != "")
            //        {
            //            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索费用的发票相关信息...");
            //            this.GetInvoiceDetailByOrder(this.register.PID.ID, this.GetItem(e.Row, (int)DisplayField.OrderSequence));
            //        }
            //        Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            //    }
            //}
		}

		/// <summary>
		/// 确认项目编辑改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
		{
			// 如果没有记录，则返回
			if (this.RowCount == 0)
			{
				return;
			}
			// 如果是新项目，如果当前焦点在项目名称列，则弹出选择收费项目UC
			if (this.GetItem(this.CurrentRow, (int)DisplayField.NewOld) == "新")
			{
				if (this.CurrentColumn == (int)DisplayField.ItemName)
				{
					System.Windows.Forms.Control cellControl = fpSpread1.EditingControl;
					//设置位置
					this.ucItemList.Location = new System.Drawing.Point(cellControl.Location.X, cellControl.Location.Y + cellControl.Height + 30);
					ucItemList.BringToFront();
					// 过滤项目
					this.ucItemList.Filter(fpSpread1_Sheet1.ActiveCell.Text);
					this.ucItemList.Visible = true;
					// 保存当前行，用于保证移动上下箭头不改变当前记录

					this.CurrentRow = e.Row;
					editRow = e.Row;
				}
				else if (this.CurrentColumn == (int)DisplayField.ItemAmount)
				{
					// 开立数量必须为有效数字
					try
					{
						if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount) != "")
						{
							Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount));
						}
					}
					catch
					{
						MessageBox.Show("开立数量必须为数字", "医技终端确认");
						this.Focus();
						this.CurrentColumn = (int)DisplayField.ItemAmount;
						return;
					}
					// 动态计算金额，并显示出来

					try
					{
						decimal tempNumber = 0, tempPrice = 0;
						// 数量
						tempNumber = Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount));
						// 单价
						tempPrice = Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemPrice));
						// 金额
						this.Cell(this.CurrentRow, (int)DisplayField.ItemCost, (tempNumber * tempPrice).ToString());
					}
					catch
					{
					}
				}
			}
		}

		/// <summary>
		/// 表格按键事件
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private int fpSpread1_KeyEnter(Keys key)
		{
			// 挂号临时对象
			Neusoft.HISFC.Models.Registration.Register tempRegisgter = new Register();

			// 结果
			Neusoft.HISFC.BizProcess.Integrate.Terminal.Result result = new Result();
			// 业务层

			Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm confirmIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Confirm ();
			//
			// 按健处理
			//
			if (key == Keys.Enter)
			{
				// 如果没有记录，那么返回

				if (this.RowCount == 0)
				{
					return 0;
				}
				// 如果是新项目
				if (this.GetItem(this.CurrentRow, (int)DisplayField.NewOld).Equals("新"))
				{
					// 如果当前字段为项目名称，插入新项目

					if (this.CurrentColumn == (int)DisplayField.ItemName)
					{
						if (this.ucItemList.Visible)
						{
							// 插入新项目

							this.InsertNew();
							// 设置焦点到项目数量

							if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemCode) != "")
							{
								this.CurrentColumn = (int)DisplayField.ItemAmount;
							}

							if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemName).Equals(""))
							{
								this.CurrentColumn = (int)DisplayField.ItemName;
							}

							return 0;
						}
						else
						{
							if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemName).Equals(""))
							{
								this.CurrentColumn = (int)DisplayField.ItemName;
								return 0;
							}
							this.CurrentColumn = (int)DisplayField.ItemAmount;
						}
						return 0;
					}
					// 验证开立数量合法性

					if (this.CurrentColumn == (int)DisplayField.ItemAmount)
					{
						// 开立数量不允许为空
						if (this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount).Equals(""))
						{
							MessageBox.Show("开立数量不允许为空", "医技终端确认");
							this.Focus();
							this.CurrentColumn = (int)DisplayField.ItemAmount;
							return 0;
						}
						// 开立数量必须为有效数字
						try
						{
							Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount));
						}
						catch
						{
							MessageBox.Show("开立数量必须为数字", "医技终端确认");
							this.Focus();
							this.CurrentColumn = (int)DisplayField.ItemAmount;
							return 0;
						}
						// 动态计算金额，并显示出来

						try
						{
							decimal tempNumber = 0, tempPrice = 0;
							// 数量
							tempNumber = Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemAmount));
							// 单价
							tempPrice = Convert.ToDecimal(this.GetItem(this.CurrentRow, (int)DisplayField.ItemPrice));
							// 金额
							this.Cell(this.CurrentRow, (int)DisplayField.ItemCost, (tempNumber * tempPrice).ToString());
						}
						catch
						{
						}
						if (this.fpSpread1_Sheet1.Columns[(int)DisplayField.MachineName].Visible)
						{
							this.CurrentColumn = (int)DisplayField.MachineName;
						}
						else
						{
							if (MessageBox.Show("是否增加新收费项目?", "医技终端确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1).Equals(DialogResult.No))
							{
								this.CurrentColumn = (int)DisplayField.ItemAmount;
								return 0;
							}
							this.NewRow();
						}

						return 0;
					}
					// 如果当前字段在机器名称,那么自动增加一行

					if (this.CurrentColumn == (int)DisplayField.MachineName)
					{
						if (this.fpSpread1_Sheet1.Columns[(int)DisplayField.MachineName].Visible)
						{
							this.NewRow();
						}
						return 0;
					}
				}
				else if (this.GetItem(this.CurrentRow, (int)DisplayField.NewOld).Equals("旧"))
				{
					// 如果当前字段是项目名称,那么移动字段为项目数量

					if (this.CurrentColumn == (int)DisplayField.ItemName)
					{
						this.CurrentColumn = (int)DisplayField.ConfirmAmount;
						return 0;
					}
					// 如果当前字段是确认数量

					if (this.CurrentColumn == (int)DisplayField.ConfirmAmount)
					{
						if (this.CurrentRow + 1 < this.RowCount)
						{
							// 如果不是最后一行,那么移动记录到下一行

							this.CurrentRow++;
							this.CurrentColumn = (int)DisplayField.ItemName;
							return 0;
						}
						else
						{
							// 如果当前是最后一行,那么增加一行新记录
							if (DialogResult.Yes.Equals(MessageBox.Show("是否增加新收费项目?", "医技终端确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
							{
								this.NewRow();
							}
							this.Focus();
						}
					}
					if (this.CurrentColumn == (int)DisplayField.ConfirmFlag)
					{
						this.CurrentColumn = (int)DisplayField.ItemName;
						return 0;
					}
					return 0;
				}
				return 0;
			}
			else if (key == Keys.Up)
			{
				// 因为FARPOINT会移动当前记录，所以用editRow记录新增记录的行号

				if (this.ucItemList.Visible)
				{
					this.ucItemList.PriorRow();
					this.CurrentRow = this.editRow;
				}
				else
				{
					if (this.GetItem(this.CurrentRow, (int)DisplayField.NewOld) == "旧")
					{
						// 科室信息
						Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();
						// 合同单位
						Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
						// 如果只有一条记录,那么不检索患者基本信息

						if (this.RowCount == 1)
						{
							return 0;
						}
						// 旧项目根据不同的明细，显示不同的患者基本信息

						this.register = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[this.CurrentRow].Tag)).Patient;
						// 根据门诊号获取患者基本信息
						if (this.register.Memo == "1" || this.register.Memo == "4")
						{
							result = confirmIntegrate.GetRegisterByClinicCode(ref tempRegisgter, this.register.PID.ID);
							if (tempRegisgter != null)
							{
								this.register.Birthday = tempRegisgter.Birthday;
							}
						}
						else
						{
							Neusoft.HISFC.Models.RADT.PatientInfo inpatient = new PatientInfo();
							result = confirmIntegrate.GetInpatient(this.register.PID.ID, ref inpatient);
							if (inpatient != null)
							{
								this.register.Birthday = inpatient.Birthday;
							}
						}
						if (this.register.Age == null || this.register.Age.Equals(""))
						{
							string age = "";
							result = confirmIntegrate.GetAge(ref age, this.register.Birthday.Date);
							this.register.Age = age;
							this.register.Age = this.register.Age.Substring(0, this.register.Age.Length - 1);
						}
						
						result = confirmIntegrate.GetDept(ref dept, this.register.DoctorInfo.Templet.Dept.ID);
						this.register.DoctorInfo.Templet.Dept = dept;
						// 获取合同单位信息
						result = confirmIntegrate.GetPact(ref pact, this.register.Pact.ID);
						this.register.Pact = pact;
						// 设置患者基本信息UC的患者基本信息

						this.KeyUpAndDown(key);
					}
				}
				return 0;
			}
			else if (key == Keys.Down)
			{
				// 因为FARPOINT会移动当前记录，所以用editRow记录新增记录的行号

				if (this.ucItemList.Visible)
				{
					this.ucItemList.NextRow();
					this.CurrentRow = this.editRow;
				}
				else
				{
					if (this.GetItem(this.CurrentRow, (int)DisplayField.NewOld) == "旧")
					{
						Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department ();
						Neusoft.HISFC.Models.Base.PactInfo pact = new PactInfo();
						// 如果只有一条记录,那么不检索患者基本信息

						if (this.RowCount == 1)
						{
							return 0;
						}
						// 旧项目根据不同的明细，显示不同的患者基本信息

						this.register = ((Neusoft.HISFC.Models.Terminal.TerminalApply)(this.fpSpread1_Sheet1.Rows[this.CurrentRow].Tag)).Patient;
						// 根据门诊号获取患者基本信息
						if (this.register.Memo == "1" || this.register.Memo == "4")
						{
							result = confirmIntegrate.GetRegisterByClinicCode(ref tempRegisgter, this.register.PID.ID);
							if (tempRegisgter != null)
							{
								this.register.Birthday = tempRegisgter.Birthday;
							}
						}
						else
						{
							Neusoft.HISFC.Models.RADT.PatientInfo inpatient = new PatientInfo();
							result = confirmIntegrate.GetInpatient(this.register.PID.ID, ref inpatient);
							if (inpatient != null)
							{
								this.register.Birthday = inpatient.Birthday;
							}
						}
						if (this.register.Age == null || this.register.Age.Equals(""))
						{
							string age = "";
							result = confirmIntegrate.GetAge(ref age, this.register.Birthday.Date);
							this.register.Age = age;
							this.register.Age = this.register.Age.Substring(0, this.register.Age.Length - 1);
						}
						result = confirmIntegrate.GetDept(ref dept, this.register.DoctorInfo.Templet.Dept.ID);
						this.register.DoctorInfo.Templet.Dept = dept;
						// 获取合同单位信息
						result = confirmIntegrate.GetPact(ref pact, this.register.Pact.ID);
						this.register.Pact = pact;
						// 设置患者基本信息UC的患者基本信息

						this.KeyUpAndDown(key);
					}
				}
				return 0;
			}

			this.UnDisplayUcItemList();
			return 0;
		}

		/// <summary>
		/// 失去焦点时，是收费项目选择控件消失
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucItemApply_Leave(object sender, EventArgs e)
		{
			this.MakeItemListDisappear();
		}

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ShowPacsApply(e.Row);
        }  

		#endregion

         		
	}
}

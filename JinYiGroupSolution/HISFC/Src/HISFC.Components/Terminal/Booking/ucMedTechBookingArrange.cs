using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Base;
using Neusoft.FrameWork.WinForms.Controls;
using Neusoft.FrameWork.Management;
using MedTechItemTemp=Neusoft.HISFC.Models.Terminal.MedTechItemTemp;
using FarPoint.Win.Spread;
namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucMedTechBookingArrange <br></br>
	/// [功能描述: 科室项目排班]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucMedTechBookingArrange : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucMedTechBookingArrange()
		{
			InitializeComponent();

			if (this.DesignMode)
			{
				return;
			}
		}

		#region 变量

		/// <summary>
		/// 模板集合
		/// </summary>
		private DataTable dsItems;
		
        ///// <summary>
        ///// 模板视图
        ///// </summary>
        //private DataView dataView;
		
		/// <summary>
		/// 集合
		/// </summary>
		private ArrayList arrayList;
		
		/// <summary>
		/// 预约时间
		/// </summary>
		private DateTime seeDate = DateTime.MinValue;
		
		/// <summary>
		/// 业务层
		/// </summary>
		Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        Neusoft.HISFC.BizLogic.Terminal.Terminal applyMgr = new Neusoft.HISFC.BizLogic.Terminal.Terminal();
        /// <summary>
        /// 
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper noonListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        private Neusoft.FrameWork.Public.ObjectHelper machineObjHelper = new Neusoft.FrameWork.Public.ObjectHelper();
		/// <summary>
		/// 显示星期
		/// </summary>
		private DayOfWeek week = DayOfWeek.Monday;
		
		/// <summary>
		/// 操作环境
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();
		
		/// <summary>
		/// 午别列表
		/// </summary>
        //private Neusoft.FrameWork.WinForms.Controls.PopUpListBox noonListBox = new PopUpListBox();

		/// <summary>
		/// 回车事件代理
		/// </summary>
		public delegate void delegateEnter();
		
		/// <summary>
		/// 回车事件
		/// </summary>
		public event delegateEnter KeyEnter;

		/// <summary>
		/// 表格的列
		/// </summary>
		protected enum cols
		{
			/// <summary>
			/// 项目代码0
			/// </summary>
			ItemCode,
			/// <summary>
			/// 项目名称1
			/// </summary>
			ItemName,
			/// <summary>
			/// 午别代码2
			/// </summary>
			Noon,
            /// <summary>
            /// 开始时间3
            /// </summary>
            StartTime,
            /// <summary>
            /// 结束时间4
            /// </summary>
            EndTime,
			/// <summary>
			/// 预约限额5
			/// </summary>
			BookLmt,
			/// <summary>
			/// 特诊预约限额6
			/// </summary>
			SpecialBookLmt,
			/// <summary>
			/// 已经预约数量7
			/// </summary>
			BookNum,
			/// <summary>
			/// 特诊预约数量8
			/// </summary>
			SpecialBookNum,
            /// <summary>
            /// 旧的午别9
            /// </summary>
            OldNoon,
			/// <summary>
			/// 单位标识10
			/// </summary>
			UnitFlag,
            /// <summary>
            /// 标识位11
            /// </summary>
            TmpFlag ,
            //{5A111831-190D-4187-8076-83E220BC97B2}            
            /// <summary>
            /// 设备12
            /// </summary>
            Machine,
            
		}

		#endregion

		#region 属性
		
		/// <summary>
		/// 显示星期
		/// </summary>
		public DayOfWeek Week
		{
			get
			{
				return week;
			}
			set
			{
				week = value;
			}
		}

		/// <summary>
		/// 预约时间
		/// </summary>
		public DateTime SeeDate
		{
			get
			{
				return seeDate;
			}
			set
			{
				seeDate = value.Date;
			}
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 初始化模板数据集
		/// </summary>
		private void InitDataSet()
		{
			// 模板数据集
			this.dsItems = new DataTable("Templet");
			// 初始化
			dsItems.Columns.AddRange(new DataColumn[]
			{ 
                //{5A111831-190D-4187-8076-83E220BC97B2}
				new DataColumn("ItemCode",System.Type.GetType("System.String")),
				new DataColumn("ItemName",System.Type.GetType("System.String")),
				new DataColumn("Noon",System.Type.GetType("System.String")),
                new DataColumn("StartTime",System.Type.GetType("System.String")),
                new DataColumn("EndTime",System.Type.GetType("System.String")),
				new DataColumn("BookLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("SpecialBookLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("BookNum",System.Type.GetType("System.Decimal")),
				new DataColumn("SpecialBookNum",System.Type.GetType("System.Decimal")),
				new DataColumn("OldNoon",System.Type.GetType("System.String")),
				new DataColumn("UnitFlag",System.Type.GetType("System.String")),
                new DataColumn("TmpFlag",System.Type.GetType("System.String")),
                new DataColumn("Machine",System.Type.GetType("System.String"))
			});
			
			
		}

		/// <summary>
		/// 初始化午别列表
		/// </summary>
		private void InitNoon()
		{
			//得到午别
            this.arrayList = managerMgr.QueryConstantList("NOON"); ;
			if (this.arrayList == null)
			{
				MessageBox.Show("获取午别信息时出错!" + this.bookingIntegrate.Err, "提示信息");
				return;
			}
            noonListHelper.ArrayObject = arrayList;
			this.fpSpread1.SetColumnList(this.fpSpread1_Sheet1, 2, this.arrayList);
		}

        ///// <summary>
        ///// 根据午别代码得到午别名称
        ///// </summary>
        ///// <param name="noonID">午别代码</param>
        ///// <returns>午别名称</returns>
        //private string GetNoonNameByID(string noonID)
        //{
        //    foreach (Neusoft.FrameWork.Models.NeuObject noon in this.noonListBox.Items)
        //    {
        //        if (noon.ID == noonID)
        //        {
        //            return noon.Name;
        //        }
        //    }

        //    return noonID;
        //}

        ///// <summary>
        ///// 根据午别名称得到午别代码
        ///// </summary>
        ///// <param name="noonName">午别名称</param>
        ///// <returns>午别代码</returns>
        //private string noonListHelper.GetID(string noonName)
        //{
        //    foreach (Neusoft.FrameWork.Models.NeuObject noon in this.noonListBox.Items)
        //    {
        //        if (noon.Name == noonName)
        //        {
        //            return noon.ID;
        //        }
        //    }

        //    return "";
        //}

		/// <summary>
		/// 根据单位标识名称获取单位标识代码
		/// </summary>
		/// <param name="unitName">单位标识名称</param>
		/// <returns>单位标识代码</returns>
		private string GetUnitIDByName(string unitName)
		{
			string unitID;

			if (unitName == "组套")
			{
				unitID = "2";
			}
			else if (unitName == "明细")
			{
				unitID = "1";
			}
			else
			{
				unitID = "0";
			}

			return unitID;
		}

		/// <summary>
		/// 根据单位标识代码获取单位标识名称
		/// </summary>
		/// <param name="unitID">单位标识代码</param>
		/// <returns>单位标识名称</returns>
		private string GetUnitNameById(string unitID)
		{
			string unitName;

			if (unitID == "2")
			{
				unitName = "组套";
			}
			else if (unitID == "1")
			{
				unitName = "明细";
			}
			else
			{
				unitName = "未知";
			}

			return unitName;
		}

		/// <summary>
		/// 设置Farpoint显示格式
		/// </summary>
		private void SetFpFormat()
		{
			Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numnberCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
			Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType readOnlyNumnberCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
			
			numnberCellType.DecimalPlaces = 0;
			numnberCellType.MaximumValue = 99999;
			numnberCellType.MinimumValue = 0;

			readOnlyNumnberCellType.DecimalPlaces = 0;
			readOnlyNumnberCellType.MaximumValue = 99999;
			readOnlyNumnberCellType.MinimumValue = 0;
			readOnlyNumnberCellType.ReadOnly = true;

			FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();
			textCellType.ReadOnly = true;
			FarPoint.Win.Spread.CellType.TextCellType txttype = new FarPoint.Win.Spread.CellType.TextCellType();

			this.fpSpread1_Sheet1.Columns[0].CellType = textCellType;
			this.fpSpread1_Sheet1.Columns[0].Width = 100;
			this.fpSpread1_Sheet1.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			this.fpSpread1_Sheet1.Columns[1].CellType = textCellType;
			this.fpSpread1_Sheet1.Columns[1].Width = 140;
			this.fpSpread1_Sheet1.Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			this.fpSpread1_Sheet1.Columns[2].CellType = txttype;
			this.fpSpread1_Sheet1.Columns[2].Width = 80;
			this.fpSpread1_Sheet1.Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpSpread1_Sheet1.Columns[2].Resizable = false;

			this.fpSpread1_Sheet1.Columns[5].CellType = numnberCellType;
			this.fpSpread1_Sheet1.Columns[6].CellType = numnberCellType;
			this.fpSpread1_Sheet1.Columns[7].CellType = readOnlyNumnberCellType;
			this.fpSpread1_Sheet1.Columns[8].CellType = readOnlyNumnberCellType;

			this.fpSpread1_Sheet1.Columns[9].Visible = false;
			this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "单位标识";
			this.fpSpread1_Sheet1.Columns[10].CellType = textCellType;

            this.fpSpread1_Sheet1.Columns [ 11 ].Visible = false;

			this.fpSpread1_Sheet1.Columns[7].Locked = true;
			this.fpSpread1_Sheet1.Columns[8].Locked = true;
		}

		/// <summary>
		/// 验证
		/// </summary>
		/// <param name="tempDataTable">数据表</param>
		/// <returns>－1－失败；0－成功</returns>
		private int Valid(DataTable tempDataTable)
		{
			if (tempDataTable != null)
			{
				foreach (DataRow row in tempDataTable.Rows)
				{
					if (row["ItemCode"].ToString() == null || row["ItemCode"].ToString() == "")
					{
						MessageBox.Show("项目代码不能为空!", "提示");
						return -1;
					}
					if (row["BookLmt"].ToString() == null || row["BookLmt"].ToString() == "")
					{
						MessageBox.Show("预约限额必须录入!", "提示");
						return -1;
					}
					if (row["SpecialBookLmt"].ToString() == null || row["SpecialBookLmt"].ToString() == "")
					{
						MessageBox.Show("特诊预约限额必须录入!", "提示");
						return -1;
					}
                    if (row["Noon"].ToString() == null || row["Noon"].ToString() == "")
                    {
                        MessageBox.Show("午别不能为空!", "提示");
                        return -1;
                    }
                    if (row["StartTime"].ToString() == null || row["Noon"].ToString() == "")
                    {
                        MessageBox.Show("开始时间不能为空!", "提示");
                        return -1;
                    }
                    if (row["EndTime"].ToString() == null || row["Noon"].ToString() == "")
                    {
                        MessageBox.Show("开始时间不能为空!", "提示");
                        return -1;
                    }
                    if (Neusoft.FrameWork.Function.NConvert.ToInt32(row["BookLmt"]) == 0 && Neusoft.FrameWork.Function.NConvert.ToInt32(row["SpecialBookLmt"]) == 0)
                    {
                        MessageBox.Show("预约限额和特诊限额不允许同时为0", "提示");
                        return -1;
                    } 
				}
			}

			return 0;
		}
		
		/// <summary>
		/// 检查是否有主键重复
		/// </summary>
		/// <returns>0－成功；－1－失败</returns>
		private int Valid()
		{
			int ret = 0;

			if (this.fpSpread1_Sheet1.RowCount <= 0)
			{
				return ret;
			}
			for (int i = 0;i < this.fpSpread1_Sheet1.RowCount;i++)
			{
				string strID = this.fpSpread1_Sheet1.Cells[i, (int)cols.ItemCode].Text.Trim();
				string strNoon = this.fpSpread1_Sheet1.Cells[i, 2].Text.Trim();
				if (i == this.fpSpread1_Sheet1.RowCount - 1)
				{
					break;
				}
				for (int j = i + 1;j < this.fpSpread1_Sheet1.RowCount;j++)
				{
					string strCompareID = this.fpSpread1_Sheet1.Cells[j, (int)cols.ItemCode].Text.Trim();
					string strCompareNoon = this.fpSpread1_Sheet1.Cells[j, 2].Text.Trim();

					if (strID == strCompareID && strNoon == strCompareNoon)
					{
						ret = -1;
						break;
					}
				}
				if (ret == -1)
				{
					break;
				}
			}

			return ret;
		}

		/// <summary>
		/// 将表中数据转换为实体集合
		/// </summary>
		/// <param name="tempDataTable">数据表</param>
		/// <returns></returns>
		private ArrayList GetChanges(DataTable tempDataTable)
		{
			this.arrayList = new ArrayList();
			if (tempDataTable != null)
			{
				try
				{
					foreach (DataRow row in tempDataTable.Rows)
					{
						Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp = new MedTechItemTemp();
                        //{5A111831-190D-4187-8076-83E220BC97B2}

						tempMedTechItemTemp.MedTechItem.Item.ID = row["ItemCode"].ToString();
						tempMedTechItemTemp.MedTechItem.Item.Name = row["ItemName"].ToString();
						tempMedTechItemTemp.MedTechItem.ItemExtend.UnitFlag = row["UnitFlag"].ToString();
						tempMedTechItemTemp.MedTechItem.ItemExtend.Dept.ID = this.operEnvironment.Dept.ID;
						tempMedTechItemTemp.Dept.Name = this.operEnvironment.Dept.Name;
						tempMedTechItemTemp.MedTechItem.ItemExtend.BookTime = this.seeDate.ToString();
						tempMedTechItemTemp.NoonCode = noonListHelper.GetID(row["Noon"].ToString());
						tempMedTechItemTemp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["BookLmt"]);
						tempMedTechItemTemp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["SpecialBookLmt"]);
						tempMedTechItemTemp.MedTechItem.Item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["BookNum"]);
						tempMedTechItemTemp.MedTechItem.Item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(row["SpecialBookNum"]);
						tempMedTechItemTemp.MedTechItem.Item.Oper.ID = this.operEnvironment.ID;
						tempMedTechItemTemp.MedTechItem.ItemExtend.UnitFlag = this.GetUnitIDByName(row["UnitFlag"].ToString());
                        tempMedTechItemTemp.TmpFlag = row [ "TmpFlag" ].ToString ( );
                        tempMedTechItemTemp.StartTime = row["StartTime"].ToString();
                        tempMedTechItemTemp.EndTime = row["EndTime"].ToString();
                        tempMedTechItemTemp.Machine.ID = row["Machine"].ToString();
						this.arrayList.Add(tempMedTechItemTemp);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show("生成实体集合时出错!" + e.Message, "提示");
					return null;
				}
			}

			return this.arrayList;
		}

		/// <summary>
		/// 保存增加的记录
		/// </summary>
		/// <param name="addArrayList">安排数组</param>
		/// <param name="errorMessage">错误信息</param>
		/// <returns>0－成功；－1－失败</returns>
		private int SaveAdd(ArrayList addArrayList, ref string errorMessage)
		{
			try
			{
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp templet in addArrayList)
				{
					if (this.bookingIntegrate.InsertMedTechItemArrange(templet) == -1)
					{
						errorMessage = bookingIntegrate.Err;
						return -1;
					}
				}
			}
			catch (Exception e)
			{
				errorMessage = e.Message;
				return -1;
			}

			return 0;
		}
		
		/// <summary>
		/// 保存修改记录
		/// </summary>
		/// <param name="modifyArrayList">安排数组</param>
		/// <param name="modifyDataTable">安排数据表</param>
		/// <param name="error">错误信息</param>
		/// <returns>0－成功；－1－失败</returns>
		private int SaveModify(ArrayList modifyArrayList, DataTable modifyDataTable, ref string error)
		{
			try
			{
				foreach (DataRow row in modifyDataTable.Rows)
				{
					if (this.bookingIntegrate.DeleteMedTechItemArrange(this.operEnvironment.Dept.ID, row["ItemCode"].ToString(), this.seeDate.ToString(), noonListHelper.GetID(row["OldNoon"].ToString())) == -1)
					{
						error = this.bookingIntegrate.Err;
						return -1;
					}
				}
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp templet in modifyArrayList)
				{
					if (this.bookingIntegrate.InsertMedTechItemArrange(templet) == -1)
					{
						error = this.bookingIntegrate.Err;
						return -1;
					}
				}
			}
			catch (Exception e)
			{
				error = e.Message;
				return -1;
			}

			return 0;
		}
		
		/// <summary>
		/// 保存删除记录
		/// </summary>
		/// <param name="deleteDataTable">安排数据表</param>
		/// <param name="error">错误信息</param>
		/// <returns>0－成功；－1－失败</returns>
		private int SaveDelete(DataTable deleteDataTable, ref string error)
		{
			try
			{
				foreach (DataRow row in deleteDataTable.Rows)
				{
					if (this.bookingIntegrate.DeleteMedTechItemArrange(this.operEnvironment.Dept.ID, row["ItemCode"].ToString(), this.seeDate.ToString(), noonListHelper.GetID(row["OldNoon"].ToString())) == -1)
					{
						error = this.bookingIntegrate.Err;
						return -1;
					}
				}
			}
			catch (Exception e)
			{
				error = e.Message;
				return -1;
			}

			return 0;
		}

		/// <summary>
		/// 获取选择的午别
		/// </summary>
		/// <returns>0－成功；－1－失败</returns>
		private int ProcessNoon()
		{
			int currentRow = fpSpread1_Sheet1.ActiveRowIndex;
			if (currentRow < 0)
			{
				return 0;
			}

			Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.fpSpread1.getCurrentList(this.fpSpread1_Sheet1, 2);
			//获取选中的信息
			Neusoft.FrameWork.Models.NeuObject noon = null;
			listBox.GetSelectedItem(out noon);
			if (noon == null)
				return -1;
			//午别
			fpSpread1_Sheet1.SetValue(currentRow, 2, noon.Name);
			fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 3);

			return 0;
		}
        
		/// <summary>
		/// 获取模板数组
		/// </summary>
		/// <param name="tempItemList">实体数组</param>
		/// <returns>1－成功；－1－失败</returns>
		private int GetArrayList(ref ArrayList tempItemList)
		{
			for (int i = 0;i < this.fpSpread1_Sheet1.RowCount;i++)
			{
				Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp = new MedTechItemTemp();
				
				if (this.GetTempItem(ref tempMedTechItemTemp, i) == -1)
				{
					return -1;
				}

				tempItemList.Add(tempMedTechItemTemp);
			}
			
			return 1;
		}
		
		/// <summary>
		/// 获取模板项目
		/// </summary>
		/// <param name="tempMedTechItemTemp">模板项目</param>
		/// <param name="row">行号</param>
		/// <returns>1－成功；－1－失败</returns>
		private int GetTempItem(ref Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp, int row)
        {
            //{5A111831-190D-4187-8076-83E220BC97B2}
			tempMedTechItemTemp.MedTechItem.Item.ID = this.fpSpread1_Sheet1.Cells[row, (int)cols.ItemCode].Text;
			tempMedTechItemTemp.MedTechItem.Item.Name = this.fpSpread1_Sheet1.Cells[row, (int)cols.ItemName].Text;
			tempMedTechItemTemp.MedTechItem.ItemExtend.UnitFlag = this.GetUnitIDByName(this.fpSpread1_Sheet1.Cells[row, (int)cols.UnitFlag].Text);
			tempMedTechItemTemp.MedTechItem.ItemExtend.Dept.ID = this.operEnvironment.Dept.ID;
			tempMedTechItemTemp.Dept.Name = this.operEnvironment.Dept.Name;
			tempMedTechItemTemp.MedTechItem.ItemExtend.BookTime = this.seeDate.ToString();
			tempMedTechItemTemp.NoonCode = noonListHelper.GetID(this.fpSpread1_Sheet1.Cells[row, (int)cols.Noon].Text);
			tempMedTechItemTemp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[row, (int)cols.BookLmt].Text);
			tempMedTechItemTemp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[row, (int)cols.SpecialBookLmt].Text);
			tempMedTechItemTemp.MedTechItem.Item.ChildPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[row, (int)cols.BookNum].Text);
			tempMedTechItemTemp.MedTechItem.Item.SpecialPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpSpread1_Sheet1.Cells[row, (int)cols.SpecialBookNum].Text);
			tempMedTechItemTemp.MedTechItem.Item.Oper.ID = this.operEnvironment.ID;
            tempMedTechItemTemp.TmpFlag = this.fpSpread1_Sheet1.Cells [ row , ( int ) cols.TmpFlag ].Text;
            tempMedTechItemTemp.StartTime = this.fpSpread1_Sheet1.Cells[row, (int)cols.StartTime].Text;
            tempMedTechItemTemp.EndTime = this.fpSpread1_Sheet1.Cells[row, (int)cols.EndTime].Text;
            tempMedTechItemTemp.Machine.ID = machineObjHelper.GetID(this.fpSpread1_Sheet1.Cells[row, (int)cols.Machine].Text);


			if (tempMedTechItemTemp.MedTechItem.Item.ID == null || tempMedTechItemTemp.MedTechItem.Item.ID == "")
			{
				this.fpSpread1_Sheet1.ActiveRowIndex = row;
				MessageBox.Show("项目编码不能为空");
				return -1;
			}
			if (tempMedTechItemTemp.MedTechItem.Item.Name == null || tempMedTechItemTemp.MedTechItem.Item.Name == "")
			{
                this.fpSpread1_Sheet1.SetActiveCell(row, (int)cols.ItemName);
				MessageBox.Show("项目名称不能为空");
				return -1;
			}
            if (tempMedTechItemTemp.NoonCode == null || tempMedTechItemTemp.NoonCode == "")
            {
                this.fpSpread1_Sheet1.SetActiveCell(row,(int)cols.Noon);
                MessageBox.Show("午别不能为空");
                return -1;
            }
            if (tempMedTechItemTemp.BookLmt == 0 && tempMedTechItemTemp.SpecialBookLmt == 0)
            {
                this.fpSpread1_Sheet1.SetActiveCell(row, (int)cols.BookLmt);
                this.fpSpread1_Sheet1.ActiveRowIndex = row;
                MessageBox.Show("预约限额和特诊限额不允许同时为0");
                return -1;
            }
			return 1;
		}
        /// <summary>
        /// 初始化farpoint的键盘屏蔽

        /// </summary>
        private void InitFarPoint()
        {
            InputMap inputMap;

            inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            inputMap.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            inputMap.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //inputMap.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            inputMap.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //inputMap.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //inputMap = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            //inputMap.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            //inputMap = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            //inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            //inputMap = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
            //inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
        }
		#endregion

		#region 公有函数
        /// <summary>
        /// 判断标识位
        /// </summary>
        public string JudgeTmpFlag ( )
        {
            if ( this.fpSpread1_Sheet1.Rows.Count == 0 )
            {
                return "0";
            }
            else
            {
                if ( this.fpSpread1_Sheet1.Cells [ 0 , (int)cols.UnitFlag ].Value.ToString ( ) == "1" )
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
        }
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="dayOfWeek">星期</param>
		/// <param name="bookingDate">预约时间</param>
		public void Init(DayOfWeek dayOfWeek, DateTime bookingDate)
		{
			this.week = dayOfWeek;
			this.SeeDate = bookingDate.Date;
			// 初始化午别列表控件
			this.InitNoon();
            //初始化设备列表
            this.InitCarrier();
			// 初始化模板数据集
			this.InitDataSet();
            InitFarPoint();
			//定义响应按键事件
			fpSpread1.SetItem += new NeuFpEnter.setItem(fpSpread1_SetItem);
			fpSpread1.ShowListWhenOfFocus = true;
		}

        private void InitCarrier()
        {
            //得到医技设备{5A111831-190D-4187-8076-83E220BC97B2}
            ArrayList deptEquipmentList = new ArrayList();
            deptEquipmentList = bookingIntegrate.QueryMedTechEquipment(((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID);

            if (deptEquipmentList == null)
            {
                MessageBox.Show("获取医技设备信息时出错!");
                return;
            }

            ArrayList tempAl = new ArrayList();
            foreach (Neusoft.HISFC.Models.Terminal.TerminalCarrier car in deptEquipmentList)
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                obj.ID = car.CarrierCode;
                obj.Name = car.CarrierName;
                tempAl.Add(obj);
            }

            machineObjHelper.ArrayObject = tempAl;
            this.fpSpread1.SetColumnList(this.fpSpread1_Sheet1, (int)cols.Machine, tempAl); 
            
        }
        /// <summary>
        /// 获取选择的医技设备

        /// </summary>
        /// <returns>0－成功；－1－失败</returns>
        private int ProcessMachine()
        {
            int currentRow = fpSpread1_Sheet1.ActiveRowIndex;
            if (currentRow < 0)
            {
                return 0;
            }

            Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox1 = this.fpSpread1.getCurrentList(this.fpSpread1_Sheet1, (int)cols.Machine);
            //获取选中的信息

            Neusoft.FrameWork.Models.NeuObject machine = null;
            listBox1.GetSelectedItem(out machine);
            if (machine == null)
                return -1;
            //医技设备
            fpSpread1_Sheet1.SetValue(currentRow, (int)cols.Machine, machine.Name);

            return 0;
        }
		/// <summary>
		/// 查询该科室一日排班记录
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="currentDay">当前日期</param>
		public void Query(string deptCode, string currentDay)
		{
			this.arrayList = this.bookingIntegrate.QueryArrange(deptCode, this.seeDate.ToString());
			if (this.arrayList == null)
			{
				return;
			}

			dsItems.Rows.Clear();
			dsItems.AcceptChanges();

			try
			{
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp in this.arrayList)
				{
					this.dsItems.Rows.Add(new object[]
			        {
                        //{5A111831-190D-4187-8076-83E220BC97B2}
			            tempMedTechItemTemp.MedTechItem.Item.ID,
			            tempMedTechItemTemp.MedTechItem.Item.Name,
			            noonListHelper.GetName(tempMedTechItemTemp.NoonCode),
                        tempMedTechItemTemp.StartTime,
                        tempMedTechItemTemp.EndTime,
			            tempMedTechItemTemp.BookLmt,
			            tempMedTechItemTemp.SpecialBookLmt,
			            tempMedTechItemTemp.MedTechItem.Item.ChildPrice,
			            tempMedTechItemTemp.MedTechItem.Item.SpecialPrice,
			            noonListHelper.GetName(tempMedTechItemTemp.NoonCode),
			            this.GetUnitNameById(tempMedTechItemTemp.MedTechItem.ItemExtend.UnitFlag),//9单位标识
                        tempMedTechItemTemp.TmpFlag,
                        tempMedTechItemTemp.Machine.ID
			        });
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("查询排班信息生成DataSet时出错!" + e.Message, "提示");
				return;
			}

			dsItems.AcceptChanges();

			//this.dataView = dsItems.DefaultView;
			//this.dataView.AllowEdit = true;
			//this.dataView.AllowDelete = true;
			//this.dataView.AllowNew = true;

			this.fpSpread1_Sheet1.DataSource = this.dsItems;
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                this.fpSpread1_Sheet1.Cells[i, (int)cols.Noon].Locked = true;
            }
			this.SetFpFormat();

		}

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="tempMedTechItem">医技预约项目</param>
        public void Add(Neusoft.HISFC.Models.Terminal.MedTechItem tempMedTechItem)
		{
			try
			{
                //{5A111831-190D-4187-8076-83E220BC97B2}
				this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);
				this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.RowCount - 1;
				int row = this.fpSpread1_Sheet1.ActiveRowIndex;
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.ItemCode, tempMedTechItem.Item.ID, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.ItemName, tempMedTechItem.Item.Name, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.UnitFlag, this.GetUnitNameById(tempMedTechItem.ItemExtend.UnitFlag), false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.BookLmt, 0, false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.SpecialBookLmt, 0, false);
                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.TmpFlag , "1" , false );
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.StartTime, "00:00:00", false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.EndTime, "00:00:00", false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.Machine, "", false);
				this.fpSpread1.Focus();
				this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "提示信息");
				return;
			}
		}
        /// <summary>
        ///  增加设备
        /// </summary>
        public void Add ( Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier )
        {
            try
            {
                //增加一行

                this.fpSpread1_Sheet1.Rows.Add ( this.fpSpread1_Sheet1.RowCount , 1 );
                //设置当前行

                this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.RowCount - 1;
                int row = this.fpSpread1_Sheet1.ActiveRowIndex;

                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.ItemCode , terminalCarrier.CarrierCode , false );
                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.ItemName , terminalCarrier.CarrierName , false );
                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.UnitFlag , this.GetUnitNameById ( terminalCarrier.CarrierType ) , false );
                this.fpSpread1_Sheet1.Cells [ row , ( int ) cols.BookLmt ].Text = "0";
                this.fpSpread1_Sheet1.Cells [ row , ( int ) cols.SpecialBookLmt ].Text = "0";
                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.TmpFlag , "2" , false );
                //{5A111831-190D-4187-8076-83E220BC97B2}
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.StartTime, "00:00:00", false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.EndTime, "00:00:00", false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.Machine, terminalCarrier.CarrierCode, false);
                this.fpSpread1.Focus ( );
                this.fpSpread1_Sheet1.SetActiveCell ( this.fpSpread1_Sheet1.ActiveRowIndex , ( int ) cols.BookLmt , false );
            }
            catch ( Exception e )
            {
                MessageBox.Show ( e.Message , "提示信息" );
                return;
            }
        }
		/// <summary>
		/// 增加
		/// </summary>
		/// <param name="tempMedTechItemTemp">医技预约项目</param>
		public void AddTemp(Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempMedTechItemTemp)
		{
			try
			{
				this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);
				this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.RowCount - 1;
				int row = this.fpSpread1_Sheet1.ActiveRowIndex;

				this.fpSpread1_Sheet1.SetValue(row, (int)cols.ItemCode, tempMedTechItemTemp.MedTechItem.Item.ID, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.ItemName, tempMedTechItemTemp.MedTechItem.Item.Name, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.BookLmt, tempMedTechItemTemp.BookLmt, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.SpecialBookLmt, tempMedTechItemTemp.SpecialBookLmt, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.Noon, noonListHelper.GetName(tempMedTechItemTemp.NoonCode), false);
                //{5A111831-190D-4187-8076-83E220BC97B2}
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.StartTime, tempMedTechItemTemp.StartTime, false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.EndTime, tempMedTechItemTemp.EndTime, false);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.BookNum, 0);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.SpecialBookNum, 0);
				this.fpSpread1_Sheet1.SetValue(row, (int)cols.UnitFlag, this.GetUnitNameById(tempMedTechItemTemp.MedTechItem.ItemExtend.UnitFlag), false);
                this.fpSpread1_Sheet1.SetValue ( row , ( int ) cols.TmpFlag , tempMedTechItemTemp.TmpFlag , false );
                if (tempMedTechItemTemp.TmpFlag == "2")
                {
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.Machine, tempMedTechItemTemp.MedTechItem.Item.ID, false); 
                }
				this.fpSpread1.Focus();
				this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.ItemCode, false);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "提示信息");
				return;
			}
		}

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
		{
			// 行号
			int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            
			// 事务
            //Neusoft.FrameWork.Management.Transaction transaction = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
			// 实体
			Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempItemTemp = new MedTechItemTemp();
			
			if (row < 0 || this.fpSpread1_Sheet1.RowCount == 0)
			{
				return;
			}
            if (!this.fpSpread1_Sheet1.Cells[row, (int)cols.Noon].Locked)
            {
                this.fpSpread1.SetAllListBoxUnvisible();
                this.fpSpread1.EditModePermanent = false;
                this.fpSpread1.EditModeReplace = false;
                this.fpSpread1_Sheet1.Rows.Remove(row, 1);
                this.fpSpread1.EditModePermanent = true;
                this.fpSpread1.EditModeReplace = true;
                MessageBox.Show("删除成功");
                return;
            }

			if (MessageBox.Show("是否删除该条排班?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}

			this.fpSpread1.StopCellEditing();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //transaction.BeginTransaction();
            applyMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);


            ArrayList list = applyMgr.QueryMedTechApplyDetailList(operEnvironment.Dept.ID, noonListHelper.GetID(this.fpSpread1_Sheet1.Cells[row, (int)cols.OldNoon].Text), fpSpread1_Sheet1.Cells[row, (int)cols.ItemCode].Text,seeDate, seeDate);
            if (list == null)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("获取信息失败" + applyMgr.Err);
                return;
            }
            if (list.Count > 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("本次排班已经被使用不能删除" + applyMgr.Err);
                return;
                
            }
			if (this.bookingIntegrate.DeleteMedTechItemArrange(this.operEnvironment.Dept.ID, this.fpSpread1_Sheet1.Cells[row, (int)cols.ItemCode].Text, this.seeDate.ToString(), noonListHelper.GetID(this.fpSpread1_Sheet1.Cells[row, (int)cols.OldNoon].Text)) <=0)
			{
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show("删除失败" + this.bookingIntegrate.Err);
				return;
			}

			this.fpSpread1_Sheet1.Rows.Remove(row, 1);

            Neusoft.FrameWork.Management.PublicTrans.Commit();
			MessageBox.Show("删除成功");

			this.fpSpread1.Focus();
			
			
		}

		/// <summary>
		/// 保存
		/// </summary>
		/// <returns>0－成功；－1－失败</returns>
		public int Save()
		{
			if (this.fpSpread1_Sheet1.RowCount == 0)
			{
				return 1;
			}
			this.fpSpread1.StopCellEditing();
            fpSpread1.SetAllListBoxUnvisible();

			////增加
			//DataTable dataTableAdd = this.dsItems.GetChanges(DataRowState.Added);
			////修改
			//DataTable dataTableModify = this.dsItems.GetChanges(DataRowState.Modified);
			////删除
			//DataTable dataTableDelete = this.dsItems.GetChanges(DataRowState.Deleted);
			// 数据库事务
            //Neusoft.FrameWork.Management.Transaction transaction = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //// 错误信息
            //string rtnText = "";
			// 实体数组
			ArrayList tempItemList = new ArrayList();

			////验证
			//if (Valid(dataTableAdd) == -1)
			//{
			//    return -1;
			//}
			//if (Valid(dataTableModify) == -1)
			//{
			//    return -1;
			//}
			////转为实体集合
			//ArrayList alAdd = this.GetChanges(dataTableAdd);
			//if (alAdd == null)
			//{
			//    return -1;
			//}
			//ArrayList alModify = this.GetChanges(dataTableModify);
			//if (alModify == null)
			//{
			//    return -1;
			//}
			//防止主键重复
			if (this.Valid() == -1)
			{
				MessageBox.Show("维护项目重复!请确定相同午别内没有重复项目后保存!");
				return -1;
			}
			
			// 获取要保存的

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //transaction.BeginTransaction();

            this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

			for (int i = 0; i<this.fpSpread1_Sheet1.RowCount; i++)
			{
				Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempItemTemp = new MedTechItemTemp();
				// 获取一行为实体
				if (this.GetTempItem(ref tempItemTemp, i) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					return -1;					
				}
				// 先删除
				if (this.bookingIntegrate.DeleteMedTechItemArrange(this.operEnvironment.Dept.ID, tempItemTemp.MedTechItem.Item.ID, this.seeDate.ToString(), noonListHelper.GetID(this.fpSpread1_Sheet1.Cells[i, (int)cols.OldNoon].Text)) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.bookingIntegrate.Err);
					return -1;
				}
				// 再增加
				if (this.bookingIntegrate.InsertMedTechItemArrange(tempItemTemp) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.bookingIntegrate.Err);
					return -1;
				}
			}

			//if (dataTableDelete != null)
			//{
			//    dataTableDelete.RejectChanges();

			//    if (this.SaveDelete(dataTableDelete, ref rtnText) == -1)
			//    {
			//        transaction.RollBack();
			//        MessageBox.Show(rtnText, "提示");
			//        return -1;
			//    }
			//}

			//if (this.SaveAdd(alAdd, ref rtnText) == -1)
			//{
			//    transaction.RollBack();
			//    MessageBox.Show(rtnText, "提示");
			//    return -1;
			//}
			//if (alModify != null && alModify.Count != 0)
			//{
			//    if (this.SaveModify(alModify, dataTableModify, ref rtnText) == -1)
			//    {
			//        transaction.RollBack();
			//        MessageBox.Show(rtnText, "提示");
			//        return -1;
			//    }
			//}


            Neusoft.FrameWork.Management.PublicTrans.Commit();

			dsItems.AcceptChanges();
			this.SetFpFormat();

			return 0;
		}

		/// <summary>
		/// 是否修改数据？
		/// </summary>
		/// <returns></returns>
		public bool IsChange()
		{
			this.fpSpread1.StopCellEditing();

			DataTable dt = dsItems.GetChanges();

			if (dt == null || dt.Rows.Count == 0)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 设置下拉列表不可见
		/// </summary>
		public void SetVisible()
		{
			this.fpSpread1.SetAllListBoxUnvisible();
		}

		/// <summary>
		/// 设置焦点
		/// </summary>
		public new void Focus()
		{
			if (this.fpSpread1_Sheet1.RowCount > 0)
			{
				this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, 0, false);
			}
		}
		
		#endregion

		#region 事件

		/// <summary>
		/// 设置响应按键事件
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		int fpSpread1_SetItem(Neusoft.FrameWork.Models.NeuObject obj)
		{
			this.ProcessNoon();
            this.ProcessMachine();
			return 0;
		}

		/// <summary>
		/// 表格按键事件
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private int fpSpread1_KeyEnter(Keys key)
		{
			if (key == Keys.Enter)
			{
				//回车
				if (this.fpSpread1.ContainsFocus)
				{
					//回车操作 
					int i = fpSpread1_Sheet1.ActiveColumnIndex;
					if (i == 2)
					{
						ProcessNoon();
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, 3);
					}
					if (i == 3 )
					{
						fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, i + 1);
					}
					if (i == 4)
					{
						if (fpSpread1_Sheet1.ActiveRowIndex == fpSpread1_Sheet1.RowCount - 1)
						{
							if (this.KeyEnter != null)
								this.KeyEnter();
						}
						else
						{
							fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex + 1, (int)cols.Noon);
						}
					}
                    if (i == (int)cols.Machine)
                    {
                        ProcessMachine();
                    }
				}
				return 0;
			}
			return 0;
		}

		#endregion
	}
}

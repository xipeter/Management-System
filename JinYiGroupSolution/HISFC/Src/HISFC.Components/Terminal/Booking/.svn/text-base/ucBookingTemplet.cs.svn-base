using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Terminal;
using Neusoft.FrameWork.WinForms.Controls;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Models;
using Neusoft.HISFC.Components.Common.Controls;

namespace Neusoft.HISFC.Components.Terminal.Booking
{
	/// <summary>
	/// ucBookingTemplet <br></br>
	/// [功能描述: 医技项目排班模板的项目UC]<br></br>
	/// [创 建 者: ]<br></br>
	/// [创建时间: ]<br></br>
	/// <修改记录
	///		修改人='赫一阳'
	///		修改时间='2006-03-12'
	///		修改目的=''
	///		修改描述=''
	///  />
	/// </summary>
	public partial class ucBookingTemplet : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
	{
		public ucBookingTemplet()
		{
			InitializeComponent();
		}

		#region 变量


       
		/// <summary>
		/// 模板数据集
		/// </summary>
		private DataTable dataTableMedTechItemTemp;
		
		/// <summary>
		/// 模板试图
		/// </summary>
		private DataView dataViewMedTechItemTemp;
		
		/// <summary>
		/// 集合
		/// </summary>
		private ArrayList tempList;
		
		/// <summary>
		/// 显示星期
		/// </summary>
		private int week = 0;
        /// <summary>
        /// 
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper noonListHelper = new Neusoft.FrameWork.Public.ObjectHelper();
		/// <summary>
		/// 当前操作环境
		/// </summary>
		public Neusoft.HISFC.Models.Base.OperEnvironment operEnvironment = new OperEnvironment();
        Neusoft.HISFC.BizProcess.Integrate.Manager managerMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
		/// <summary>
		/// 午别列表
		/// </summary>
        //Neusoft.FrameWork.WinForms.Controls.PopUpListBox popUpListBox = new PopUpListBox();
		
		/// <summary>
		/// 医技预约业务层
		/// </summary>
		Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking bookingIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Terminal.Booking ();
		
		/// <summary>
		/// 回车事件代理
		/// </summary>
		public delegate void delegateEnter();
		
		/// <summary>
		/// 回车事件
		/// </summary>
		public event delegateEnter KeyEnter;
		
		/// <summary>
		/// 枚举列
		/// </summary>
		protected enum cols
		{
			/// <summary>
			/// 项目代码
			/// </summary>
			ItemCode,
			/// <summary>
			/// 项目名称
			/// </summary>
			ItemName,
			/// <summary>
			/// 单位标识
			/// </summary>
			UnitFlag,
			/// <summary>
			/// 预约限额
			/// </summary>
			BookLmt,
			/// <summary>
			/// 特诊预约限额
			/// </summary>
			SpecialBookLmt,
			/// <summary>
			/// 午别代码
			/// </summary>
			Noon,
			/// <summary>
			/// 是否有效
			/// </summary>
			Valid,
			/// <summary>
			/// 注意事项
			/// </summary>
			Remark,
			/// <summary>
			/// 旧的午别
			/// </summary>
			OldNoon,
            /// <summary>
            /// 标识位
            /// </summary>
            TmpFlag,
            //{5A111831-190D-4187-8076-83E220BC97B2}
            /// <summary>
            /// 开始时间
            /// </summary>
            StartTime,
            /// <summary>
            /// 结束时间
            /// </summary>
            EndTime
		}
		
		#endregion

		#region 属性
       

		/// <summary>
		/// 显示星期
		/// </summary>
		public int Week
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
		
		#endregion

		#region 私有函数
		/// <summary>
		/// 初始化午别
		/// </summary>
		private void InitNoon()
		{
			// 得到午别
            this.tempList = managerMgr.QueryConstantList("NOON");
			if (tempList == null)
			{
				MessageBox.Show("获取午别信息出错！" + bookingIntegrate.Err, "提示信息");
				return;
			}
			// 添加到午别选择控件
            //this.popUpListBox.AddItems(this.tempList);
            this.noonListHelper.ArrayObject = tempList;
			// 设置午别列的选择数据
			this.neuSpread1.SetColumnList(this.neuSpread1_Sheet1, 5, tempList);
		}

		/// <summary>
		/// 初始化数据集
		/// </summary>
		private void InitDataSet()
		{
			// 模板数据集
			dataTableMedTechItemTemp = new DataTable("Templet");
			// 设置字段
			dataTableMedTechItemTemp.Columns.AddRange(new DataColumn[]
			{               
				new DataColumn("ItemCode",System.Type.GetType("System.String")),
				new DataColumn("ItemName",System.Type.GetType("System.String")),
				new DataColumn("UnitFlag",System.Type.GetType("System.String")),
				new DataColumn("BookLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("SpecialBookLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("Noon",System.Type.GetType("System.String")),
				new DataColumn("Valid",System.Type.GetType("System.String")),
				new DataColumn("Remark",System.Type.GetType("System.String")),
                new DataColumn("OldNoon",System.Type.GetType("System.String")),
                new DataColumn("TmpFlag",System.Type.GetType("System.String")),
                 //{5A111831-190D-4187-8076-83E220BC97B2}
                new DataColumn("StartTime",System.Type.GetType("System.String")),
                new DataColumn("EndTime",System.Type.GetType("System.String"))
			});
		}

		/// <summary>
		/// 初始化farpoint的键盘屏蔽
		/// </summary>
		private void InitFarPoint()
		{
			InputMap inputMap;

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

			inputMap = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
			inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
			inputMap = neuSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused);
			inputMap.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
		}

		/// <summary>
		/// 设置Farpoint显示格式
		/// </summary>
		private void SetFarPointFormat()
		{
			Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numbType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
			FarPoint.Win.Spread.CellType.TextCellType txtonly = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType txttype = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType cmbType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dtimeType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			// 有效无效
			string[] items = new string[] { "有效", "无效" };
			
			numbType.DecimalPlaces = 0;
			numbType.MaximumValue = 99999;
			numbType.MinimumValue = 0;
			
			txtonly.ReadOnly = true;
			
			cmbType.AcceptsArrowKeys = FarPoint.Win.SuperEdit.AcceptsArrowKeys.CtrlArrows;
			cmbType.Items = items;

			this.neuSpread1_Sheet1.Columns[0].CellType = txtonly;
			this.neuSpread1_Sheet1.Columns[0].Width = 100;
			this.neuSpread1_Sheet1.Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			this.neuSpread1_Sheet1.Columns[1].CellType = txtonly;
			this.neuSpread1_Sheet1.Columns[1].Width = 140;
			this.neuSpread1_Sheet1.Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			this.neuSpread1_Sheet1.Columns[2].CellType = txtonly;
			this.neuSpread1_Sheet1.Columns[2].Width = 100;
			this.neuSpread1_Sheet1.Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.neuSpread1_Sheet1.Columns[2].Resizable = false;

			this.neuSpread1_Sheet1.Columns[3].CellType = numbType;
			this.neuSpread1_Sheet1.Columns[4].CellType = numbType;

			this.neuSpread1_Sheet1.Columns[5].CellType = txttype;
			this.neuSpread1_Sheet1.Columns[5].Width = 70;

			this.neuSpread1_Sheet1.Columns[6].CellType = cmbType;
			this.neuSpread1_Sheet1.Columns[6].Width = 80;

			this.neuSpread1_Sheet1.Columns[7].CellType = txttype;
			this.neuSpread1_Sheet1.Columns[7].Width = 200;
			this.neuSpread1_Sheet1.Columns[7].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

			this.neuSpread1_Sheet1.Columns[8].Visible = false;

		}

        ///// <summary>
        ///// 根据午别代码得到午别名称
        ///// </summary>
        ///// <param name="noonID">午别编码</param>
        ///// <returns>午别名称</returns>
        //private string GetNoonNameByID(string noonID)
        //{
        //    foreach (Neusoft.FrameWork.Models.NeuObject noon in this.popUpListBox.Items)
        //    {
        //        if (noon.ID == noonID)
        //        {
        //            return noon.Name;
        //        }
        //    }
        //    // 返回编码
        //    return noonID;
        //}

        ///// <summary>
        ///// 根据午别名称得到午别代码
        ///// </summary>
        ///// <param name="noonName">午别名称</param>
        ///// <returns>午别代码</returns>
        //private string noonListHelper.GetID(string noonName)
        //{
        //    foreach (Neusoft.FrameWork.Models.NeuObject noon in this.popUpListBox.Items)
        //    {
        //        if (noon.Name == noonName)
        //        {
        //            return noon.ID;
        //        }
        //    }
        //    // 返回空串
        //    return "";
        //}

		/// <summary>
		/// 根据单位标识名称获取单位标识代码
		/// </summary>
		/// <param name="unitName"><单位标识名称/param>
		/// <returns>单位标识编码</returns>
		private string GetUnitIDByName(string unitName)
		{
			// 单位标识编码
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
		private string GetUnitNameByID(string unitID)
		{
			// 单位标识名称
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
				unitName = "明细未知";
			}

			return unitName;
		}

		/// <summary>
		/// 检查是否有主键重复
		/// </summary>
		/// <returns>0－无重复；－1－重复</returns>
		private int ValidPrimaryKey()
		{
			// 返回值
			int intReturn = 0;

			// 没有记录
			if (this.neuSpread1_Sheet1.RowCount <= 0)
			{
				return intReturn;
			}

			for (int i = 0;i < this.neuSpread1_Sheet1.RowCount;i++)
			{
				// 项目编码
				string strID = this.neuSpread1_Sheet1.Cells[i, (int)cols.ItemCode].Text.Trim();
				// 午别
				string strNoon = this.neuSpread1_Sheet1.Cells[i, 5].Text.Trim();

                if (strNoon == null || strNoon == "")
                {
                    MessageBox.Show("午别不能为空");
                    return -1;
                }
				// 如果是最后一行
				if (i == this.neuSpread1_Sheet1.RowCount - 1)
				{
					break;
				}
				for (int j = i + 1;j < this.neuSpread1_Sheet1.RowCount;j++)
				{
					// 比较的项目编码
					string strCompareID = this.neuSpread1_Sheet1.Cells[j, (int)cols.ItemCode].Text.Trim();
					// 比较的午别
					string strCompareNoon = this.neuSpread1_Sheet1.Cells[j, 5].Text.Trim();
					// 如果找到重复
					if (strID == strCompareID && strNoon == strCompareNoon)
					{
                        MessageBox.Show("维护项目重复!请确定相同午别内没有重复项目后保存!");
						intReturn = -1;
						break;
					}
				}
				if (intReturn == -1)
				{
					break;
				}
			}
			// 返回
			return intReturn;
		}

        ///// <summary>
        ///// 验证
        ///// </summary>
        ///// <param name="dataTable">数据表</param>
        ///// <returns>0－成功；－1－失败</returns>
        //private int Valid(DataTable dataTable)
        //{
        //    if (dataTable != null)
        //    {
        //        foreach (DataRow dataRow in dataTable.Rows)
        //        {
        //            // 午别编码
        //            string noon = noonListHelper.GetID(dataRow["Noon"].ToString());

        //            if (dataRow["ItemCode"].ToString() == null || dataRow["ItemCode"].ToString() == "")
        //            {
        //                MessageBox.Show("项目代码不能为空!", "提示");
        //                return -1;
        //            }
        //            if (noon == "")
        //            {
        //                MessageBox.Show("午别不能为空!", "提示");
        //                return -1;
        //            }
        //            if (dataRow["BookLmt"].ToString() == null || dataRow["BookLmt"].ToString() == "")
        //            {
        //                MessageBox.Show("预约限额必须录入!", "提示");
        //                return -1;
        //            }
        //            if (dataRow["SpecialBookLmt"].ToString() == null || dataRow["SpecialBookLmt"].ToString() == "")
        //            {
        //                MessageBox.Show("特诊预约限额必须录入!", "提示");
        //                return -1;
        //            }
        //            if (Neusoft.FrameWork.Function.NConvert.ToInt32(dataRow["BookLmt"]) == 0 && Neusoft.FrameWork.Function.NConvert.ToInt32(dataRow["SpecialBookLmt"]) == 0)
        //            {
        //                MessageBox.Show("预约限额和特诊限额不允许同时为0", "提示");
        //                return -1;
        //            } 
        //            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(dataRow["Remark"].ToString(), 100) == false)
        //            {
        //                MessageBox.Show("备注不能超过100个汉字!", "提示");
        //                return -1;
        //            }
        //        }
        //    }
        //    // 成功返回
        //    return 0;
        //}

		/// <summary>
		/// 将表中数据转换为实体集合
		/// </summary>
		/// <param name="dataTable">数据表</param>
		/// <returns></returns>
		private ArrayList DataTableToArrayList(DataTable dataTable)
		{
			// 模板数据
			this.tempList = new ArrayList();

			if (dataTable != null)
			{
				try
				{
					foreach (DataRow dataRow in dataTable.Rows)
					{
						// 排班模板
						Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemp = new Neusoft.HISFC.Models.Terminal.MedTechItemTemp();
						// 有效性
						bool isValid = false;

						medTechItemTemp.MedTechItem.Item.ID = dataRow["ItemCode"].ToString();
						medTechItemTemp.MedTechItem.Item.Name = dataRow["ItemName"].ToString();
						medTechItemTemp.MedTechItem.ItemExtend.UnitFlag = this.GetUnitIDByName(dataRow["UnitFlag"].ToString());
						medTechItemTemp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(dataRow["BookLmt"]);
						medTechItemTemp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(dataRow["SpecialBookLmt"]);
						medTechItemTemp.NoonCode = noonListHelper.GetID(dataRow["Noon"].ToString());
						if (dataRow["Valid"].ToString() == "有效")
						{
							isValid = true;
						}
						medTechItemTemp.MedTechItem.Item.IsValid = isValid;
						medTechItemTemp.MedTechItem.Item.Notice = dataRow["Remark"].ToString();
						medTechItemTemp.MedTechItem.Item.Oper.ID = this.operEnvironment.ID;
						medTechItemTemp.MedTechItem.Item.Oper.OperTime = this.bookingIntegrate.GetCurrentDateTime();
						medTechItemTemp.Week = this.week.ToString();
						medTechItemTemp.MedTechItem.ItemExtend.Dept.ID = this.operEnvironment.Dept.ID;
						medTechItemTemp.Dept.Name = this.operEnvironment.Dept.Name;
                        // //{5A111831-190D-4187-8076-83E220BC97B2}
                        medTechItemTemp.StartTime = this.bookingIntegrate.GetCurrentDateTime().ToShortTimeString();
                        medTechItemTemp.EndTime = this.bookingIntegrate.GetCurrentDateTime().ToShortTimeString();
						// 添加进数组
						this.tempList.Add(medTechItemTemp);
					}
				}
				catch (Exception e)
				{
					MessageBox.Show("生成实体集合时出错!" + e.Message, "提示");
					return null;
				}
			}

			return tempList;
		}

		/// <summary>
		/// 保存增加的记录
		/// </summary>
		/// <param name="error">错误信息</param>
		/// <returns>－1－失败；0－成功</returns>
		private int SaveAdd(ref string error)
		{
			try
			{
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp templet in tempList)
				{
					if (this.bookingIntegrate.InsertMedTechItemTemp(templet) == -1)
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
			// 成功返回
			return 0;
		}

		/// <summary>
		/// 保存修改记录
		/// </summary>
		/// <param name="modifyTempList">修改的数组</param>
		/// <param name="dataTableModify">修改的数据表</param>
		/// <param name="error">错误信息</param>
		/// <returns>0－成功；－1－失败</returns>
		private int SaveModify(ArrayList modifyTempList, DataTable dataTableModify, ref string error)
		{
			try
			{
				foreach (DataRow dataRow in dataTableModify.Rows)
				{
					if (this.bookingIntegrate.DeleteMedTechItemTemp(this.operEnvironment.Dept.ID, dataRow["ItemCode"].ToString(), ((int)this.week).ToString(), noonListHelper.GetID(dataRow["OldNoon"].ToString())) == -1)
					{
						error = bookingIntegrate.Err;

						return -1;
					}
				}
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp templet in modifyTempList)
				{
					if (this.bookingIntegrate.InsertMedTechItemTemp(templet) == -1)
					{
						error = bookingIntegrate.Err;
						return -1;
					}
				}
			}
			catch (Exception e)
			{
				error = e.Message;
				return -1;
			}
			// 成功返回
			return 0;
		}

		/// <summary>
		/// 保存删除记录
		/// </summary>
		/// <param name="dataTableDelete">删除的数据表</param>
		/// <param name="error">错误信息</param>
		/// <returns>0－成功；－1－失败</returns>
		private int SaveDelete(DataTable dataTableDelete, ref string error)
		{
			try
			{
				foreach (DataRow dataRow in dataTableDelete.Rows)
				{
					if (this.bookingIntegrate.DeleteMedTechItemTemp(this.operEnvironment.Dept.ID, dataRow["ItemCode"].ToString(), ((int)this.week).ToString(), noonListHelper.GetID(dataRow["OldNoon"].ToString())) == -1)
					{
						error = bookingIntegrate.Err;
						return -1;
					}
				}
			}
			catch (Exception e)
			{
				error = e.Message;
				return -1;
			}

			// 成功返回
			return 0;
		}

		/// <summary>
		/// 获取并显示选择的午别
		/// </summary>
		/// <returns>0－成功；－1－失败</returns>
		private int ProcessNoon()
		{
			// 当前行
			int currentRow = this.neuSpread1_Sheet1.ActiveRowIndex;
			// 午别控件
			Neusoft.FrameWork.WinForms.Controls.PopUpListBox listBox = this.neuSpread1.getCurrentList(this.neuSpread1_Sheet1, 5);
			//选中的午别
			Neusoft.FrameWork.Models.NeuObject noon = null;
			
			if (currentRow < 0)
			{
				return 0;
			}
			// 获取选择的午别
			listBox.GetSelectedItem(out noon);
			if (noon == null)
			{
				return -1;
			}
			// 显示午别
			this.neuSpread1_Sheet1.SetValue(currentRow, 5, noon.Name);

			this.neuSpread1.SetAllListBoxUnvisible();
			
			// 成功返回
			return 0;
		}
		
		/// <summary>
		/// 根据行号获取一个实体
		/// </summary>
		/// <param name="itemTemp">实体</param>
		/// <param name="row">行号</param>
		/// <returns>1－成功；－1－失败</returns>
		private int GetItem(ref Neusoft.HISFC.Models.Terminal.MedTechItemTemp itemTemp, int row)
		{
			bool isValid = false;

			itemTemp.MedTechItem.Item.ID = this.neuSpread1_Sheet1.Cells[row, (int)cols.ItemCode].Text;
            if (itemTemp.MedTechItem.Item.ID == null || itemTemp.MedTechItem.Item.ID == "")
            {
                this.neuSpread1_Sheet1.SetActiveCell(row, (int)cols.ItemCode);
                MessageBox.Show("项目编码不能为空");
                return -1;
            }
			itemTemp.MedTechItem.Item.Name = this.neuSpread1_Sheet1.Cells[row, (int)cols.ItemName].Text;
			itemTemp.MedTechItem.ItemExtend.UnitFlag = this.GetUnitIDByName(this.neuSpread1_Sheet1.Cells[row, (int)cols.UnitFlag].Text);
			itemTemp.BookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[row, (int)cols.BookLmt].Text);
			itemTemp.SpecialBookLmt = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.neuSpread1_Sheet1.Cells[row, (int)cols.SpecialBookLmt].Text);
            if (itemTemp.BookLmt == 0 && itemTemp.SpecialBookLmt == 0)
            {
                this.neuSpread1_Sheet1.SetActiveCell(row, (int)cols.BookLmt);
                MessageBox.Show("预约限额和特诊限额不允许同时为0");
                return -1;
            }
			itemTemp.NoonCode = noonListHelper.GetID(this.neuSpread1_Sheet1.Cells[row, (int)cols.Noon].Text);
			if (this.neuSpread1_Sheet1.Cells[row, (int)cols.Valid].Text == "有效")
			{
				isValid = true;
			}
			itemTemp.MedTechItem.Item.IsValid = isValid;
			itemTemp.MedTechItem.Item.Notice = this.neuSpread1_Sheet1.Cells[row, (int)cols.Remark].Text;
			itemTemp.MedTechItem.Item.Oper.ID = this.operEnvironment.ID;
			itemTemp.MedTechItem.Item.Oper.OperTime = this.bookingIntegrate.GetCurrentDateTime();
			itemTemp.Week = this.week.ToString();
			itemTemp.MedTechItem.ItemExtend.Dept.ID = this.operEnvironment.Dept.ID;
			itemTemp.Dept.Name = this.operEnvironment.Dept.Name;
            itemTemp.TmpFlag = this.neuSpread1_Sheet1.Cells [row,(int)cols.TmpFlag].Text.ToString();
			if (itemTemp.NoonCode == "")
			{
                this.neuSpread1_Sheet1.SetActiveCell(row, (int)cols.Noon);
				MessageBox.Show("午别不能为空!", "提示");
				return -1;
			}
			if (Neusoft.FrameWork.Public.String.ValidMaxLengh(itemTemp.MedTechItem.Item.Notice, 100) == false)
			{
                this.neuSpread1_Sheet1.SetActiveCell(row, (int)cols.Remark);
				MessageBox.Show("备注不能超过100个汉字!", "提示");
				return -1;
			}
            // {5A111831-190D-4187-8076-83E220BC97B2}
            itemTemp.StartTime = this.neuSpread1_Sheet1.Cells[row, (int)cols.StartTime].Text;
            itemTemp.EndTime = this.neuSpread1_Sheet1.Cells[row, (int)cols.EndTime].Text;
			// 成功返回
			return 1;
		}
		
		#endregion

		#region 公有函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="tabIndex"></param>
		public void Init(int tabIndex)
		{
			// 星期
			this.week = tabIndex;
			// 初始化午别
			this.InitNoon();
			// 初始化模板数据集
			this.InitDataSet();

			// 响应事件
			this.neuSpread1.SetItem+=new NeuFpEnter.setItem(neuSpread1_SetItem);

            
            this.neuSpread1_Sheet1.Columns[(int)cols.Remark].Visible = false;
		}

		/// <summary>
		/// 初始化午别
		/// </summary>
		public void InitInfo()
		{
			try
			{
				//设置下拉列表
				this.InitNoon();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// 查询该科室一日排班记录
		/// </summary>
		/// <param name="deptCode">科室编码</param>
		/// <param name="currentWeek">星期</param>
		public void Query(string deptCode, string currentWeek)
		{
			// 获取排班记录
			this.tempList = this.bookingIntegrate.QueryTemp(deptCode, currentWeek);
			if (tempList == null)
			{
				return;
			}
			// 设置数据集
			dataTableMedTechItemTemp.Rows.Clear();
			dataTableMedTechItemTemp.AcceptChanges();

			try
			{
				foreach (Neusoft.HISFC.Models.Terminal.MedTechItemTemp medTechItemTemplet in tempList)
				{
					// 有效性
					string strValid = "无效";
					// 设置有效性
					if (medTechItemTemplet.MedTechItem.Item.IsValid)
					{
						strValid = "有效";
					}
					// 设置数据集
					dataTableMedTechItemTemp.Rows.Add(new object[]
					{
						// 项目编码
						medTechItemTemplet.MedTechItem.Item.ID,
						// 项目名称
						medTechItemTemplet.MedTechItem.Item.Name,
						// 单位标识
						this.GetUnitNameByID(medTechItemTemplet.MedTechItem.ItemExtend.UnitFlag),
						// 预约限额
						medTechItemTemplet.BookLmt,
						// 特殊预约限额
						medTechItemTemplet.SpecialBookLmt,
						// 午别名称
						noonListHelper.GetName(medTechItemTemplet.NoonCode),
						// 有效性
						strValid,
						// 注意事项
						medTechItemTemplet.MedTechItem.Item.Notice,
						// 午别名称
						noonListHelper.GetName(medTechItemTemplet.NoonCode),
                        //标识位
                        medTechItemTemplet.TmpFlag,
                        // //{5A111831-190D-4187-8076-83E220BC97B2}
                        //开始时间
                        medTechItemTemplet.StartTime,
                        //结束时间
                        medTechItemTemplet.EndTime
					});
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("查询排班信息生成DataSet时出错!" + e.Message, "提示信息");
				return;
			}

			dataTableMedTechItemTemp.AcceptChanges();
			// 设置视图
			dataViewMedTechItemTemp = dataTableMedTechItemTemp.DefaultView;
			// 设置数据源
			this.neuSpread1_Sheet1.DataSource = dataViewMedTechItemTemp;
            for(int i=0;i<this.neuSpread1_Sheet1.RowCount;i++)
            {
                this.neuSpread1_Sheet1.Cells[i, (int)cols.Noon].Locked = true;
            }
			// 设置FarPoint
			this.SetFarPointFormat();
		}

		/// <summary>
		///  增加项目
		/// </summary>
        public void Add(Neusoft.HISFC.Models.Terminal.MedTechItem medTechItem)
		{
			try
			{
				// 增加一行
				this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
				// 设置当前行
				this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
				int row = this.neuSpread1_Sheet1.ActiveRowIndex;

				this.neuSpread1_Sheet1.SetValue(row, (int)cols.ItemCode, medTechItem.Item.ID, false);
				this.neuSpread1_Sheet1.SetValue(row, (int)cols.ItemName, medTechItem.Item.Name, false);
				this.neuSpread1_Sheet1.SetValue(row, (int)cols.UnitFlag, this.GetUnitNameByID(medTechItem.ItemExtend.UnitFlag), false);
                this.neuSpread1_Sheet1.Cells[row,(int)cols.BookLmt].Text = "0";
                this.neuSpread1_Sheet1.Cells[row, (int)cols.SpecialBookLmt].Text = "0";
				this.neuSpread1_Sheet1.SetValue(row, (int)cols.Remark, " ", false);
				this.neuSpread1_Sheet1.SetValue(row, (int)cols.Valid, "有效", false);
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.TmpFlag , "1" , false );
                //{5A111831-190D-4187-8076-83E220BC97B2}
                this.neuSpread1_Sheet1.Cells[row, (int)cols.StartTime].Text = "00:00:00";
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EndTime].Text = "00:00:00";
				this.neuSpread1.Focus();
				this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, (int)cols.BookLmt, false);
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

                this.neuSpread1_Sheet1.Rows.Add ( this.neuSpread1_Sheet1.RowCount , 1 );
                 //设置当前行

                this.neuSpread1_Sheet1.ActiveRowIndex = this.neuSpread1_Sheet1.RowCount - 1;
                int row = this.neuSpread1_Sheet1.ActiveRowIndex;

                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.ItemCode ,terminalCarrier.CarrierCode , false );
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.ItemName ,terminalCarrier.CarrierName , false );
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.UnitFlag , this.GetUnitNameByID ( terminalCarrier.CarrierType ) , false );
                this.neuSpread1_Sheet1.Cells [ row , ( int ) cols.BookLmt ].Text = "0";
                this.neuSpread1_Sheet1.Cells [ row , ( int ) cols.SpecialBookLmt ].Text = "0";
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.Remark , " " , false );
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.Valid , "有效" , false );
                this.neuSpread1_Sheet1.SetValue ( row , ( int ) cols.TmpFlag , "2" , false );
                //{5A111831-190D-4187-8076-83E220BC97B2}
                this.neuSpread1_Sheet1.Cells[row, (int)cols.StartTime].Text = "00:00:00";
                this.neuSpread1_Sheet1.Cells[row, (int)cols.EndTime].Text = "00:00:00";
                this.neuSpread1.Focus ( );
                this.neuSpread1_Sheet1.SetActiveCell ( this.neuSpread1_Sheet1.ActiveRowIndex , ( int ) cols.BookLmt , false );
            }
            catch ( Exception e )
            {
                MessageBox.Show ( e.Message , "提示信息" );
                return;
            }
        }
		/// <summary>
		/// 删除
		/// </summary>
		public void Delete()
		{
			// 当前行号
			int row = this.neuSpread1_Sheet1.ActiveRowIndex;

			if (row < 0 || this.neuSpread1_Sheet1.RowCount == 0)
			{
				return;
			}

			if (MessageBox.Show("是否删除该条排班?",
								"提示",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question,
								MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}
            this.neuSpread1.StopCellEditing();
            if (!this.neuSpread1_Sheet1.Cells[row, (int)cols.Noon].Locked)
            {
                this.neuSpread1.SetAllListBoxUnvisible();
                this.neuSpread1.EditModePermanent = false;
                this.neuSpread1.EditModeReplace = false;
                this.neuSpread1_Sheet1.Rows.Remove(row, 1);
                this.neuSpread1.EditModePermanent = true;
                this.neuSpread1.EditModeReplace = true;
                MessageBox.Show("删除成功");
               
                return;
            }
			
			
			// 事务
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction transaction = new Transaction();			
            //transaction.BeginTransaction(Neusoft.FrameWork.Management.Connection.Instance);

            this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

			if (this.bookingIntegrate.DeleteMedTechItemTemp(this.operEnvironment.Dept.ID, this.neuSpread1_Sheet1.Cells[row, (int)cols.ItemCode].Text, this.week.ToString(), noonListHelper.GetID(this.neuSpread1_Sheet1.Cells[row, (int)cols.OldNoon].Text)) <=0)
			{
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
				MessageBox.Show("删除失败");
				return;
			}

			this.neuSpread1_Sheet1.Rows.Remove(row, 1);

            Neusoft.FrameWork.Management.PublicTrans.Commit();

			MessageBox.Show("删除成功");
           
			this.neuSpread1.Focus();
		}

		/// <summary>
		/// 是否修改数据？
		/// </summary>
		/// <returns>是否</returns>
		public bool IsChange()
		{
			// 发生修改的数据表
			DataTable dataTableMofify = dataTableMedTechItemTemp.GetChanges();

			this.neuSpread1.StopCellEditing();
			// 没有发生改变
			if (dataTableMofify == null || dataTableMofify.Rows.Count == 0)
			{
				return false;
			}
			// 发生改变
			return true;
		}

		/// <summary>
		/// 保存
		/// </summary>
		public int Save()
		{
			//// 增加数据表
			//DataTable dataTableAdd = dataTableMedTechItemTemp.GetChanges(DataRowState.Added);
			//// 修改数据表
			//DataTable dataTableModify = dataTableMedTechItemTemp.GetChanges(DataRowState.Modified);
			//// 删除数据表
			//DataTable dataTableDelete = dataTableMedTechItemTemp.GetChanges(DataRowState.Deleted);
			
			// 数据库事务
			Neusoft.FrameWork.Management.Transaction transaction = new Transaction();

			this.neuSpread1.StopCellEditing();
            neuSpread1.SetAllListBoxUnvisible();
			//验证有效性
			//if (this.Valid(dataTableAdd) == -1)
			//{
			//    return -1;
			//}
			//if (Valid(dataTableModify) == -1)
			//{
			//    return -1;
			//}
			//转为实体集合
			//ArrayList addList = this.DataTableToArrayList(dataTableAdd);
			//if (addList == null)
			//{
			//    return -1;
			//}
			//ArrayList modifyList = this.DataTableToArrayList(dataTableModify);
			//if (modifyList == null)
			//{
			//    return -1;
			//}
			
			//防止主键重复
			if (this.ValidPrimaryKey() == -1)
			{
                //MessageBox.Show("维护项目重复!请确定相同午别内没有重复项目后保存!");
				return -1;
			}
			// 开始事务			

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //transaction.BeginTransaction(Neusoft.FrameWork.Management.Connection.Instance);
			// 设置事务
            this.bookingIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

			for (int i = 0;i < this.neuSpread1_Sheet1.RowCount;i++)
			{
				Neusoft.HISFC.Models.Terminal.MedTechItemTemp tempItem = new MedTechItemTemp();
               
				if (this.GetItem(ref tempItem, i) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					return -1;
				}
				// 先删除
				if (this.bookingIntegrate.DeleteMedTechItemTemp(this.operEnvironment.Dept.ID, tempItem.MedTechItem.Item.ID, this.week.ToString(),noonListHelper.GetID(this.neuSpread1_Sheet1.Cells[i, (int)cols.OldNoon].Text)) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.bookingIntegrate.Err);
					return -1;
				}
				// 插入
				if (this.bookingIntegrate.InsertMedTechItemTemp(tempItem) == -1)
				{
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
					MessageBox.Show(this.bookingIntegrate.Err);
					return -1;
				}
			}
			
			//// 处理删除的记录
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
			//// 处理新增加的记录
			//if (this.SaveAdd(ref rtnText) == -1)
			//{
			//    transaction.RollBack();
			//    MessageBox.Show(rtnText, "提示");
			//    return -1;
			//}
			//// 处理修改的记录
			//if (modifyList != null && modifyList.Count != 0)
			//{
			//    if (this.SaveModify(modifyList, dataTableModify, ref rtnText) == -1)
			//    {
			//        transaction.RollBack();
			//        MessageBox.Show(rtnText, "提示");
			//        return -1;
			//    }
			//}
			// 提交
            Neusoft.FrameWork.Management.PublicTrans.Commit();

			dataTableMedTechItemTemp.AcceptChanges();
			this.SetFarPointFormat();
			// 成功返回
			return 0;
		}

		/// <summary>
		/// 设置焦点
		/// </summary>
		public new void Focus()
		{
			if (this.neuSpread1_Sheet1.RowCount > 0)
			{
				this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, 3, false);
			}
		}
        /// <summary>
        /// 判断标识位
        /// </summary>
        public string JudgeTmpFlag (  )
        {
            if ( this.neuSpread1_Sheet1.Rows.Count == 0 )
            {
                return "0";
            }
            else
            {
                if ( this.neuSpread1_Sheet1.Cells[0,9].Value.ToString() == "1" )
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
		/// 设置可见性
		/// </summary>
		public void SetVisible()
		{
			this.neuSpread1.SetAllListBoxUnvisible();
		}
		
		#endregion

		#region 事件

        int neuSpread1_KeyEnter(System.Windows.Forms.Keys key)
        {
            if (key.GetHashCode() == Keys.Enter.GetHashCode())
            {
                //回车
                if (this.neuSpread1.ContainsFocus)
                {
                    //回车操作 
                    int i = this.neuSpread1_Sheet1.ActiveColumnIndex;
                    if (i == 5)
                    {
                        ProcessNoon();
                    }

                    if (i <= 6)
                    {
                        this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex, i + 1);
                    }
                    if (i == 7)
                    {
                        if (this.neuSpread1_Sheet1.ActiveRowIndex == this.neuSpread1_Sheet1.RowCount - 1)
                        {
                            if (this.KeyEnter != null)
                                this.KeyEnter();
                        }
                        else
                        {
                            this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex + 1, 3);
                        }
                    }
                }
            }
            return 1;
        }

		/// <summary>
		/// 选择控件收起事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void neuSpread1_ComboCloseUp(object sender, EditorNotifyEventArgs e)
		{
			if (e.Column == 6)
			{
				this.neuSpread1_Sheet1.SetActiveCell(this.neuSpread1_Sheet1.ActiveRowIndex,
				this.neuSpread1_Sheet1.ActiveColumnIndex + 1);
			}
		}

		/// <summary>
		/// 响应事件
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		private int neuSpread1_SetItem(NeuObject obj)
		{
			this.ProcessNoon();
			
			return 0;
		}

		#endregion
	}
}

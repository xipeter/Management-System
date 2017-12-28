using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucBedList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBedList()
        {
            InitializeComponent();
            InitSpread();
        }

        #region 代码
        public string strTag = "";

        TreeNode CurrentNode = new TreeNode();//当前选中的节点

		System.Data.DataSet myDataSet = new System.Data.DataSet();

		public Neusoft.HISFC.Models.Base.Bed GetBedInfo()
		{			
			Neusoft.HISFC.Models.Base.Bed oBedInfo = new Neusoft.HISFC.Models.Base.Bed();
			int iIndex = fpSpread1.Sheets[0].ActiveRow.Index;
			oBedInfo.NurseStation.ID = fpSpread1.Sheets[0].Cells[iIndex,0].Text;//护士站编号
			oBedInfo.SickRoom.ID = fpSpread1.Sheets[0].Cells[iIndex,1].Text;//病区号
            oBedInfo.ID = oBedInfo.NurseStation.ID + fpSpread1.Sheets[0].Cells[iIndex, 2].Text;//病床号 liuxq070924
			oBedInfo.BedGrade.Memo = fpSpread1.Sheets[0].Cells[iIndex,3].Text;//病床等级
			oBedInfo.Status.Name = fpSpread1.Sheets[0].Cells[iIndex,4].Text;//病床状态
            oBedInfo.BedRankEnumService.Name = fpSpread1.Sheets[0].Cells[iIndex, 5].Text;//病床编制
			oBedInfo.Phone = fpSpread1.Sheets[0].Cells[iIndex,6].Text;//电话
			oBedInfo.SortID = Convert.ToInt32(fpSpread1.Sheets[0].Cells[iIndex,9].Text);//顺序号
			oBedInfo.OwnerPc = fpSpread1.Sheets[0].Cells[iIndex,7].Text;//归属
			oBedInfo.BedGrade.ID = fpSpread1.Sheets[0].Cells[iIndex,10].Text;
            oBedInfo.Status.ID = fpSpread1.Sheets[0].Cells[iIndex, 11].Text;
			oBedInfo.BedRankEnumService.ID = fpSpread1.Sheets[0].Cells[iIndex,12].Text;
            oBedInfo.InpatientNO = fpSpread1_Sheet1.Cells[iIndex,13].Text;
			return oBedInfo;
		}

		private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{

		}

		private void EventResultChanged(ArrayList s)
		{
		}

		/// <summary>
		/// 将传入的数组中的数据保存在myDataSet中
		/// </summary>
		/// <param name="arrBed">床位信息</param>
		public void dataSet_Init(ArrayList arrBed)
		{
			DataSet dts = new DataSet();
			dts.EnforceConstraints = true;//是否遵循约束规则
			this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
 
			//定义表并增加到myDataSet中
			DataTable myDataTable = dts.Tables.Add();			
			//清空当前myDataSet中的所有列
			myDataTable.Columns.Clear();			
			myDataTable.Columns.AddRange
				(new System.Data.DataColumn[] 
					{
						new System.Data.DataColumn("护士站号",Type.GetType("System.String")), //0
						new System.Data.DataColumn("病房号",Type.GetType("System.String")),   //1
						new System.Data.DataColumn("床号", Type.GetType("System.String")),    //2
						new System.Data.DataColumn("床位等级", Type.GetType("System.String")), //3
						new System.Data.DataColumn("床位状态", Type.GetType("System.String")), //4
						new System.Data.DataColumn("床位编制", Type.GetType("System.String")), //5
						new System.Data.DataColumn("病床电话", Type.GetType("System.String")), //6
						new System.Data.DataColumn("归属", Type.GetType("System.String")),     //7
						new System.Data.DataColumn("费用", Type.GetType("System.String")),     //8
						new System.Data.DataColumn("顺序号", Type.GetType("System.String")),   //9
						new System.Data.DataColumn("Levelid", Type.GetType("System.String")),  //10
						new System.Data.DataColumn("Stateid", Type.GetType("System.String")),  //11
 						new System.Data.DataColumn("Weaveid", Type.GetType("System.String")) ,  //12
                        new System.Data.DataColumn("住院号", Type.GetType("System.String"))
					}
				);
	
			DataRow dr;
			Neusoft.HISFC.Models.Base.Bed oEBed = new Neusoft.HISFC.Models.Base.Bed();;
			if(arrBed!=null)
			{
				//循环插入基本信息
				for( int i = 0; i < arrBed.Count; i++ )
				{	
					oEBed = (Neusoft.HISFC.Models.Base.Bed)arrBed[i];
					dr = myDataTable.NewRow();			
					this.SetRow( dr, oEBed );
					myDataTable.Rows.Add( dr );	
				}
			}

			//将与DataView绑定
			this.fpSpread1_Sheet1.DataSource = dts.Tables[0].DefaultView;
			InitSpread();
		}
        
		private Neusoft.HISFC.BizLogic.Manager.Bed oCBed = new Neusoft.HISFC.BizLogic.Manager.Bed();
		public int DelBedInfo()
		{
			int iRet = 0;
			int iIndex = fpSpread1.Sheets[0].ActiveRow.Index;		
			string strNurse = fpSpread1.Sheets[0].Cells[iIndex,0].Text;//护士站编号
            string strBedID = strNurse + fpSpread1.Sheets[0].Cells[iIndex, 2].Text;//病床号 liuxq070924
			string strWardNo = fpSpread1.Sheets[0].Cells[iIndex,1].Text;//病区号
			string strBedState = fpSpread1.Sheets[0].Cells[iIndex,4].Text;
			try
			{
                /*
                 * [2007/02/02] 跟着一起改吧.
                 * if(strBedState!="空床")
                 * {
				 *   	this.Err = "此床被占用不能删除!";
				 *	    iRet = -1;
				 *	    MessageBox.Show(Err);
                 * }
                 */
                if (strBedState=="占用" || strBedState=="请假" || strBedState=="包床" || strBedState=="挂床")
                {
					this.Err = "此床被占用不能删除!";
					iRet = -1;
					MessageBox.Show(Err);
                }
				else
				{
					if (this.oCBed.DeleteBedInfo(strBedID) == 0)
					{
						this.Err = "删除成功！";

                        //删除房间
                        deleteTreeNode();
					}
					else
					{
						this.Err = "删除失败！";
					}
				}
			}
			catch{}
			if(this.strTag=="0")
			{
				ReBind(strNurse,strTag,"");//护士站
			}
			if(this.strTag=="1")
			{
				ReBind(strWardNo,strTag,strNurse);//病床
			}

			
			return iRet;
		}

		
		private string Err;
		private void ReBind(string strID,string strTag,string strNurseID)
		{
			ArrayList arr = new ArrayList();
			if(strTag=="0")
			{
				arr = oCBed.GetBedList(strID);
			}
			if(strTag=="1")
			{
				arr = oCBed.GetBedListByRoom(strID,strNurseID);
			}
		
			this.dataSet_Init(arr);
			InitSpread();
		}


		private DataRow SetRow( DataRow dr, Neusoft.HISFC.Models.Base.Bed objBed )
		{
			if(objBed!=null)
			{
				dr["护士站号"] = objBed.NurseStation.ID ;//护士站编号
				//			oBedInfo.NurseStation.Name = cboNurseCell.Text.Trim();
				dr["病房号"] = objBed.SickRoom.ID;//.NurseStation.ID ;//病区号
				dr["床号"] = objBed.ID.Substring(objBed.NurseStation.ID.Length,(objBed.ID.Length - objBed.NurseStation.ID.Length)) ;//病床号 liuxq070924
				dr["床位等级"] = objBed.BedGrade.Name;//病床等级
				dr["床位状态"] = objBed.Status.Name ;//病床状态
				dr["床位编制"] = objBed.BedRankEnumService.Name ;//病床编制
				dr["病床电话"] = objBed.Phone ;//电话
				dr["顺序号"] = objBed.SortID ;//顺序号
				dr["归属"] = objBed.OwnerPc;//归属
				dr["费用"] = objBed.User03.ToString();//费用
				dr["Levelid"] = objBed.BedGrade.ID;
				dr["Stateid"] = objBed.Status.ID;
                dr["Weaveid"] = objBed.BedRankEnumService.ID;
                dr["住院号"] = objBed.InpatientNO;
			}
			return dr;
		}

		
		private void InitSpread()
		{
			this.fpSpread1_Sheet1.Columns[0].Width = 100;
			this.fpSpread1_Sheet1.Columns[1].Width = 60;
			this.fpSpread1_Sheet1.Columns[2].Width = 80;
			this.fpSpread1_Sheet1.Columns[3].Width = 80;
			this.fpSpread1_Sheet1.Columns[4].Width = 100;
			this.fpSpread1_Sheet1.Columns[5].Width = 100;
			this.fpSpread1_Sheet1.Columns[6].Width = 80;
			this.fpSpread1_Sheet1.Columns[7].Width = 80;
			this.fpSpread1_Sheet1.Columns[8].Width = 40;		
			this.fpSpread1_Sheet1.Columns[9].Width =50;
			this.fpSpread1_Sheet1.Columns[10].Width = 0;
			this.fpSpread1_Sheet1.Columns[11].Width = 0;
			this.fpSpread1_Sheet1.Columns[12].Width = 0;
            if (fpSpread1_Sheet1.Rows.Count > 0)
            {
                fpSpread1.ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                fpSpread1.ContextMenuStrip = null;

            }
		}
       
		public void SetActiveSell(string BedNo)
		{
			for(int i=0;i<fpSpread1_Sheet1.Rows.Count;i++)
			{
				if(fpSpread1_Sheet1.Cells[i,2].Text==BedNo)
				{
					fpSpread1_Sheet1.SetActiveCell(i,2);
					return ;
				}
			}
		}

		
        #endregion

        Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        /// <summary>
        /// 新增加的代码
        /// </summary>
        /// <param name="isEnabled"></param>
        protected override void OnPrintPreviewButtonChanged(bool isEnabled)
        {
            isEnabled = false;
            base.OnPrintPreviewButtonChanged(isEnabled);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
                p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
                p.PrintPreview(this);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return base.OnPrint(sender, neuObject);
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.fpSpread1_Sheet1.Rows.Count == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有要保存的数据!"), "消息");
                return -1;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.xls)|*.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.fpSpread1.SaveExcel(dlg.FileName);
                this.fpSpread1.SaveExcel(dlg.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
                return 1;
            }
            else
                return 0;

           // return base.Export(sender, neuObject);
        }

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.dataSet_Init(new ArrayList());
            toolbarService.AddToolButton("添加", "添加床位", 0, true, false, null);
            toolbarService.AddToolButton("批量添加", "批量添加床位", 0, true, false, null);
            toolbarService.AddToolButton("复制", "复制床位", 0, true, false, null);
            toolbarService.AddToolButton("删除", "删除床位", 0, true, false, null);
            return toolbarService;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void  ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "添加":
                    this.AddInfo();
                    break;
                case "批量添加":
                    this.BatchAddInfo();
                    break;
                case "复制":
                    this.CopyInfo();
                    break;
                case "删除":
                    this.DeleteBed();
                    break;
            }
 	        base.ToolStrip_ItemClicked(sender, e);
        }
        private void BatchAddInfo()
        {
            Forms.frmBatchAddBed f = new Manager.Forms.frmBatchAddBed(false);
            if (CurrentNode.Parent != null) // 判断节点类别获取  房间或护理站
            {
                if (CurrentNode.Parent.Parent == null)
                {
                    f.NurseStation = CurrentNode.Tag.ToString();
                    f.BedRoomNO = null;
                }
                else if (CurrentNode.Parent.Parent != null)
                {
                    f.NurseStation = CurrentNode.Parent.Tag.ToString();
                    f.BedRoomNO = CurrentNode.Text.ToString();
                }
            }

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((tvNurseList)tv).InitTree();
                }
                catch
                {
                }
            }

        }
        private void AddInfo()
		{
            Forms.frmBedManager f = new Manager.Forms.frmBedManager(false);
            if (CurrentNode.Parent != null) // 判断节点类别获取  房间或护理站
            {
                if ( CurrentNode.Parent.Parent == null)
                {
                    f.NurseStation = CurrentNode.Tag.ToString();
                    f.BedRoomNO = null;
                }
                else if (CurrentNode.Parent.Parent != null)
                {
                    f.NurseStation = CurrentNode.Parent.Tag.ToString();
                    f.BedRoomNO = CurrentNode.Text.ToString();
                }
            }

            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((tvNurseList)tv).InitTree();
                }
                catch { }
            }
             
		}
        private void ModifiedInfo()
        {
             
            Forms.frmBedManager f = new Manager.Forms.frmBedManager(true);
            f.SetBedInfo( this.GetBedInfo());
           
            if (f.ShowDialog() == DialogResult.OK)
            {
                //应该写刷新代码
                this.Refresh();
            }

        }

        /// <summary>
        /// 修改添加数据后刷新数据
        /// </summary>
        private void Refresh()
        {
            ArrayList arr = new ArrayList();
            if (strID == string.Empty) return;
            if (strTag == "1")
            {
                arr = oCBed.GetBedListByRoom(strID, NurseID);
            }
            else if (strTag == "0")
            {
                arr = oCBed.GetBedList(strID);
            }
            else
            {
                arr = oCBed.GetBedList(strID);
            }
            this.dataSet_Init(arr);
        }


        private void CopyInfo()
        {
            Forms.frmCopyBed f = new Manager.Forms.frmCopyBed(true);
            f.SetBedInfo(this.GetBedInfo());

            if (f.ShowDialog() == DialogResult.OK)
            {
                //应该写刷新代码
                this.Refresh();
            }

        }

        private void DeleteBed()
        {
            DialogResult result;
            if (this.fpSpread1.Sheets[0].ActiveRowIndex < 0) return;
            string bedno = fpSpread1.Sheets[0].Cells[this.fpSpread1.Sheets[0].ActiveRowIndex, 2].Text;
            result = MessageBox.Show(string.Format("确认要删除{0}床位信息？",bedno), "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (this.DelBedInfo() != -1)
                    {
                        MessageBox.Show("删除成功！");
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            //if (result == DialogResult.No)
            //{

            //}
        }
        string NurseID;
        string strID = string.Empty;
        protected override int  OnSetValue(object neuObject, TreeNode e)
        {
            //string strID = "";
            ArrayList arr = new ArrayList();
            Neusoft.HISFC.BizLogic.Manager.Bed oCBed = new Neusoft.HISFC.BizLogic.Manager.Bed();
            if (e != null)
            {
                CurrentNode = e;
                if (e.Parent != null && e.Parent.Parent != null)//病房号
                {
                    string strNurse = e.Parent.Tag.ToString();
                    strID = e.Text.Trim();
                    arr = oCBed.GetBedListByRoom(strID, strNurse);
                    //排序 {1E01AC87-5E6A-4dbc-AB55-7970C28DC843} wbo 2010-09-18
                    arr.Sort(new CompareByBedNO());
                    this.strTag = "1";
                    this.dataSet_Init(arr);
                    this.NurseID = strNurse; //护士站    
                }
                else if (e.Parent != null)//护士站号
                {
                    if (e.Tag != null)
                    {
                        strID = e.Tag.ToString();
                        arr = oCBed.GetBedList(strID);
                        //排序 {1E01AC87-5E6A-4dbc-AB55-7970C28DC843} wbo 2010-09-18
                        arr.Sort(new CompareByBedNO());
                        this.strTag = "0";
                        this.dataSet_Init(arr);
                        strID = "";
                    }
                }
                else
                {
                    strID = "ALL";
                    arr = oCBed.GetBedList(strID);
                    //排序 {1E01AC87-5E6A-4dbc-AB55-7970C28DC843} wbo 2010-09-18
                    arr.Sort(new CompareByBedNO());
                    this.dataSet_Init(arr);

                }
            }
            
            
            return base.OnSetValue(neuObject, e);
        }  
        private void fpSpread1_CellDoubleClick_1(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ModifiedInfo(); 
        }

        /// <summary>
        /// 房间床位和左侧树列表中同时刷新,当某个房间床位完全删除后该房间在左侧数列表中自动删除 bug 更改
        /// </summary>
        private void deleteTreeNode()
        {
            int i = 0;

            string currentNursestation = string.Empty;  // 要删除的病床所在护士站
            string currentBedroomno = string.Empty;// 要删除的病床所在病房号

            currentNursestation = fpSpread1_Sheet1.GetText(fpSpread1_Sheet1.ActiveRowIndex, 0);
            currentBedroomno = fpSpread1_Sheet1.GetText(fpSpread1_Sheet1.ActiveRowIndex, 1);

            fpSpread1.Sheets[0].ActiveRow.Remove();
            // 计算i值 用来计算当前选中行的护理站  和病床号在界面上是否还是存在
            if (fpSpread1_Sheet1.Rows.Count > 0)
            {
                for (int j = 0; j < fpSpread1_Sheet1.Rows.Count; j++)
                {
                    if (fpSpread1_Sheet1.GetText(j, 0) == currentNursestation && fpSpread1_Sheet1.GetText(j, 1) == currentBedroomno)  //护士站
                    {
                        i++;
                    }

                }
            }
            // 选中第一层节点删除床位
            if (CurrentNode.Parent == null) 
            {
                if (i <= 0)
                {
                    foreach (TreeNode tn in this.CurrentNode.Nodes)
                    {
                        if (tn.Tag.ToString() == currentNursestation)
                        {
                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                if (tn1.Text == currentBedroomno)
                                {
                                    tn1.Remove();
                                    break;
                                }
                            }
                        }
                        
                    }
                }
            }

            // 选中最末层节点删除床位
            if (this.fpSpread1_Sheet1.Rows.Count == 0 && CurrentNode.Parent != null && CurrentNode.Parent.Parent != null)
            {
                this.CurrentNode.Remove();
            }
            // 选择第二层节点删除床位
            else if (CurrentNode.Parent != null)
            {
                if (i <= 0)
                {
                    foreach (TreeNode tn in this.CurrentNode.Nodes)
                    {
                        if (tn.Text == currentBedroomno)
                        {
                            tn.Remove();
                        }
                    }
                }
            }
        }

        private void tsmCopyToAdd_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.Sheets[0].ActiveRowIndex < 0)
                return;
            CopyInfo();

        }
    }
    
    /// <summary>
    /// 排序 {1E01AC87-5E6A-4dbc-AB55-7970C28DC843} wbo 2010-09-18
    /// </summary>
    public class CompareByBedNO : System.Collections.IComparer
    {
        #region IComparer 成员
        public int Compare(object x, object y)
        {
            if (x == null)
            {
                return y == null ? 0 : 1;
            }
            else if (y == null)
            {
                return -1;
            }
            Neusoft.HISFC.Models.Base.Bed sX = x as Neusoft.HISFC.Models.Base.Bed;
            Neusoft.HISFC.Models.Base.Bed sY = y as Neusoft.HISFC.Models.Base.Bed;

            return string.Compare(sX.ID, sY.ID);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// [功能描述: 科室常用项目维护]<br></br>
    /// [创 建 者: 徐伟哲]<br></br>
    /// [创建时间: 2006－10－27]<br></br>
    /// 
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucDeptItemManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private Neusoft.HISFC.BizLogic.Manager.DeptItem diBusiness = new Neusoft.HISFC.BizLogic.Manager.DeptItem();
        private System.Data.DataView dvPharmacy = new DataView();
        private System.Data.DataView dvUndrugItem = new DataView();
        private System.Data.DataView dvCombo = new DataView();

        private FilterType filterType;

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("删除", "", 0, true, false, null);

            #region 增加批量增加 {D0D124E4-19EB-4b49-9D45-D014D1DD012F} wbo 2010-09-30
            this.toolBarService.AddToolButton("所有药品", "", 0, true, false, null);
            this.toolBarService.AddToolButton("所有非药品", "", 0, true, false, null);
            this.toolBarService.AddToolButton("所有组合", "", 0, true, false, null);
            #endregion

            return this.toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "删除":
                    this.DelItem();
                    break;
                case "所有药品"://增加批量增加 {D0D124E4-19EB-4b49-9D45-D014D1DD012F} wbo 2010-09-30
                    this.AddAll(0);
                    break;
                case "所有非药品"://增加批量增加 {D0D124E4-19EB-4b49-9D45-D014D1DD012F} wbo 2010-09-30
                    this.AddAll(1);
                    break;
                case "所有组合"://增加批量增加 {D0D124E4-19EB-4b49-9D45-D014D1DD012F} wbo 2010-09-30
                    this.AddAll(2);
                    break;
                default:
                    break;
            }
        }
        protected override int OnSave(object sender, object neuObject)
        {
            if( this.fpDeptItem_Sheet1.RowCount <= 0)
            {
                MessageBox.Show("没有要保存的数据","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return -1;
            }

            for (int i = 0, j = this.fpDeptItem_Sheet1.RowCount; i < j; i++)
            {
                Neusoft.HISFC.Models.Base.DeptItem deptItem = new Neusoft.HISFC.Models.Base.DeptItem();

                //deptItem.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
                deptItem.Dept.ID = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("科室编号"));
                deptItem.ItemProperty.ID = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目编号"));
                deptItem.ItemProperty.Name = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目名称"));

                switch (this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("单位标识")).Trim())
                {
                    case "药品":
                        deptItem.UnitFlag = "0";
                        break;
                    case "0":
                        deptItem.UnitFlag = "0";
                        break;
                    case "非药品":
                        deptItem.UnitFlag = "1";
                        break;
                    case "1":
                        deptItem.UnitFlag = "1";
                        break;
                    case "组合项目":
                        deptItem.UnitFlag = "2";
                        break;
                    case "2":
                        deptItem.UnitFlag = "2";
                        break;
                    default:
                        break;
                }

                deptItem.BookLocate = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("预约地"));
                deptItem.BookTime = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("预约固定时间"));
                deptItem.ExecuteLocate = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("执行地点"));
                deptItem.ReportDate = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("取报告时间"));
                deptItem.HurtFlag = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("是否有创")).Trim().Equals("有") ? "0" : "1";
                deptItem.SelfBookFlag = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("是否科内预约")).Trim().Equals("是") ? "0" : "1";
                deptItem.ReasonableFlag = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("知情同意书")).Trim().Equals("需要") ? "0" : "1";
                deptItem.IsStat = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("是否需要统计")).Trim().Equals("需要") ? "0" : "1";
                deptItem.IsAutoBook = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("是否自动预约")).Trim().Equals("需要") ? "0" : "1";
                deptItem.Speciality = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("所属专业"));
                deptItem.ClinicMeaning = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("临床意义"));
                deptItem.SampleKind = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("标本"));
                deptItem.SampleWay = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("采样方法"));
                deptItem.SampleUnit = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("标本单位"));

                deptItem.SampleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("标本量")));

                deptItem.SampleContainer = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("临床意义"));
                deptItem.Scope = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("正常值范围"));
                deptItem.ItemTime = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目执行所需时间"));
                deptItem.Memo = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("注意事项"));
                //
                deptItem.CustomName = this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("科内名称"));

                if (deptItem.Dept.ID == "" || deptItem.Dept.Name == null)
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();

                    this.diBusiness.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if (this.diBusiness.InsertItem(deptItem) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.diBusiness.Err, Neusoft.FrameWork.Management.Language.Msg("保存数据失败!"));
                        return -1;
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                    //MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功"));
                }
                else
                {
                    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                    //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                    //t.BeginTransaction();

                    this.diBusiness.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                    if (this.diBusiness.UpdateItem(deptItem) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.diBusiness.Err, Neusoft.FrameWork.Management.Language.Msg("保存数据失败!"));
                        return -1;
                    }
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                }

                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
                //t.BeginTransaction();
                //this.diBusiness.SetTrans(t.Trans);
                //if (this.diBusiness.InsertItem(deptItem) == -1)
                //{
                //    if (this.diBusiness.UpdateItem(deptItem) == -1)
                //    {
                //        Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                //        MessageBox.Show(this.diBusiness.Err, Neusoft.FrameWork.Management.Language.Msg("保存数据失败!"));
                //        return -1;
                //    }
                //}
                //Neusoft.FrameWork.Management.PublicTrans.Commit();;
            }

            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功!"));
                
            this.Init();
            //this.FillPharmacy();
            //this.FillUndrugItem();
            //this.FillComboItem();
            return 1;
        }

        private void DelItem()
        {
            if (this.fpDeptItem_Sheet1.RowCount <= 0)
            {
                return;
            }
            int rowIndex = this.fpDeptItem_Sheet1.ActiveRowIndex;

            if (rowIndex >= 0)
            {
                DialogResult rs = MessageBox.Show("是否确认删除项目", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.No)
                {
                    return;
                }
            }

            string deptID = this.fpDeptItem_Sheet1.GetText(rowIndex, 0);
            string itemID = this.fpDeptItem_Sheet1.GetText(rowIndex, 1);

            if (deptID == null || deptID == "")
            {
                this.fpDeptItem_Sheet1.RemoveRows(rowIndex, 1);
                return;
            }
            else
            {
                this.fpDeptItem_Sheet1.RemoveRows(rowIndex, 1);
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(this.diBusiness.Connection);
            //trans.BeginTransaction();
            this.diBusiness.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            try
            {
                if ( this.diBusiness.DeleteItem(deptID, itemID) == -1 )
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除数据失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            this.Init();
        }

        #endregion

        public ucDeptItemManager()
        {
            InitializeComponent();
        }

        private void ucDeptItemManager_Load(object sender, EventArgs e)
        {
            /*
             *  这个科室树原来是要用的，但是实际意义并不大，所以隐藏，
             * 
             *  它存在的原因：可以选择树中的节点(科室)，来维护一个科室的常用项目.
             * 
             *  如果不使用这个树，那么只维护当前操作员所登陆的科室的常用项目，
             * 
             *  在业务层里给出科室编号
             *  
             */
            this.npTree.Visible = false;
            this.tvPatientList1.Visible = false;
            /*******************************************************************/

            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据...", false);
                
                FillPharmacy();
                FillUndrugItem();
                FillComboItem();
                //{BF42D3A2-5342-40be-85EB-897DCBF9B794}
                //this.Init();

                this.neuSpread1.ActiveSheetIndex = 0;
                this.GetItems("0");

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <returns>1,成功; -1,失败</returns>
        private int Init()
        {
            //{BF42D3A2-5342-40be-85EB-897DCBF9B794}
            List<Neusoft.HISFC.Models.Base.DeptItem> lstItems = new List<Neusoft.HISFC.Models.Base.DeptItem>();
            if (this.diBusiness.SelectItem(ref lstItems) == -1)
            {
                return -1;
            }
            this.InitFarPoint(lstItems);

            this.GetItems(this.neuSpread1.ActiveSheetIndex.ToString());

            return 1;
        }
        private int GetItems(string UnitFlag)
        {
            List<Neusoft.HISFC.Models.Base.DeptItem> lstItems = new List<Neusoft.HISFC.Models.Base.DeptItem>();
            if (this.diBusiness.SelectItemByUint(ref lstItems,UnitFlag) == -1)
            {
                return -1;
            }
            this.InitFarPoint(lstItems);

         

            return 1;
 
        }

        /// <summary>
        /// 用对象初始化FarPoint
        /// </summary>
        /// <param name="item"></param>
        private void InitFarPoint(List<Neusoft.HISFC.Models.Base.DeptItem> lstItems)
        {
            if (this.fpDeptItem_Sheet1.RowCount > 0)
            {
                this.fpDeptItem_Sheet1.RemoveRows(0, this.fpDeptItem_Sheet1.RowCount);
            }
            this.fpDeptItem_Sheet1.Rows.Remove(0, this.fpDeptItem_Sheet1.Rows.Count);
            for (int i = 0, j = lstItems.Count; i < j; i++)
            {
                this.fpDeptItem_Sheet1.Rows.Add(i, 1);

                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("科室编号"), lstItems[i].Dept.ID);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("项目编号"), lstItems[i].ItemProperty.ID);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("项目名称"), lstItems[i].ItemProperty.Name);
                switch (lstItems[i].UnitFlag.Trim())
                {
                    case "0":
                        this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("单位标识"), "药品");
                        break;
                    case "1":
                        this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("单位标识"), "非药品");
                        break;
                    case "2":
                        this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("单位标识"), "组合项目");
                        break;
                    default:
                        break;
                }
                //this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("单位标识"), lstItems[i].UnitFlag);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("预约地"), lstItems[i].BookLocate);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("预约固定时间"), lstItems[i].BookTime);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("执行地点"), lstItems[i].ExecuteLocate);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("取报告时间"), lstItems[i].ReportDate);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("是否有创"), lstItems[i].HurtFlag);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("是否科内预约"), lstItems[i].SelfBookFlag);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("知情同意书"), lstItems[i].ReasonableFlag);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("所属专业"), lstItems[i].Speciality);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("临床意义"), lstItems[i].ClinicMeaning);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("标本"), lstItems[i].SampleKind);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("采样方法"), lstItems[i].SampleWay);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("标本单位"), lstItems[i].SampleUnit);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("标本量"), lstItems[i].SampleQty.ToString());
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("容器"), lstItems[i].SampleContainer);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("正常值范围"), lstItems[i].Scope);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("是否需要统计"), lstItems[i].IsStat);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("是否自动预约"), lstItems[i].IsAutoBook);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("项目执行所需时间"), lstItems[i].ItemTime);
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("注意事项"), lstItems[i].Memo);
                //
                this.fpDeptItem_Sheet1.SetText(i, this.GetCloumn("科内名称"), lstItems[i].CustomName);
            }
        }

        /// <summary>
        /// 项目是否存在
        /// </summary>
        /// <param name="itemID">项目编号</param>
        /// <param name="itemName">项目名称</param>
        /// <returns>true: 存在;  false:不存在</returns>
        private bool IsExist(string itemID, string itemName)
        {
            for (int i = 0, j = this.fpDeptItem_Sheet1.Rows.Count; i < j; i++)
            {
                if (this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目编号")).Trim().Equals(itemID) &&
                    this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目名称")).Trim().Equals(itemName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建一个新行，准备存入数据库
        /// </summary>
        /// <param name="itemID">项目编号</param>
        /// <param name="itemName">项目名称</param>
        /// <param name="itemType">单位标识(1.药品   2.非药品  3.复合项目)</param>
        private void CreateLine(string itemID, string itemName, string itemType)
        {
            //增加一个新行
            int rowIndex = 0;
            this.fpDeptItem_Sheet1.Rows.Add(rowIndex, 1);

            //第0列是在业务层转换得到的,所以在这里为暂时不加
            this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("项目编号"), itemID);
            this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("项目名称"), itemName);

            this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("科内名称"), itemName);

            switch (itemType)
            {
                case "0":
                    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("单位标识"), "药品");
                    break;
                case "1":
                    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("单位标识"), "非药品");
                    break;
                case "2":
                    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("单位标识"), "组合项目");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据FarPoint中的一行,创建一个对象
        /// </summary>
        /// <param name="row">所在行</param>
        /// <returns>对象</returns>
        private Neusoft.HISFC.Models.Base.DeptItem CreateDeptItem(int row)
        {
            Neusoft.HISFC.Models.Base.DeptItem deptitem = new Neusoft.HISFC.Models.Base.DeptItem();
            
            deptitem.Dept.ID = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("科室编号"));
            deptitem.ItemProperty.ID = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("项目编号"));
            deptitem.ItemProperty.Name = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("项目名称"));
            //系统类别:deptitem.ItemProperty.SysClass暂时先不写
            switch (this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("单位标识")).Trim())
            {
                case "药品":
                    deptitem.UnitFlag = "0";
                    break;
                case "非药品":
                    deptitem.UnitFlag = "1";
                    break;
                case "组合项目":
                    deptitem.UnitFlag = "2";
                    break;
                default:
                    break;
            }
        
            //deptitem.UnitFlag = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("单位标识"));
            deptitem.BookLocate = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("预约地"));
            deptitem.BookTime = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("预约固定时间"));
            deptitem.ExecuteLocate = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("执行地点"));
            deptitem.ReportDate = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("取报告时间"));
            deptitem.HurtFlag = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("是否有创"));
            deptitem.SelfBookFlag = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("是否科内预约"));
            deptitem.ReasonableFlag = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("知情同意书"));
            deptitem.Speciality = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("所属专业"));
            deptitem.ClinicMeaning = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("临床意义"));
            deptitem.SampleKind = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("标本"));
            deptitem.SampleWay = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("采样方法"));
            deptitem.SampleUnit = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("标本单位"));

            deptitem.SampleQty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("标本量")));
            
            deptitem.SampleContainer = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("容器"));
            deptitem.Scope = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("正常值范围"));
            deptitem.IsStat = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("是否需要统计"));
            deptitem.IsAutoBook = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("是否自动预约"));
            deptitem.ItemTime = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("项目执行所需时间"));
            deptitem.Memo = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("注意事项"));
            //
            deptitem.CustomName = this.fpDeptItem_Sheet1.GetText(row, this.GetCloumn("科内名称"));
            return deptitem;
        }

        /// <summary>
        /// 根据指定的列名,得到对应的位置索引
        /// </summary>
        /// <param name="name">列名</param>
        /// <returns>>=0:位置索引,  -1:失败</returns>
        private int GetCloumn(string name)
        {
            for (int i = 0; i < this.fpDeptItem_Sheet1.Columns.Count; i++)
            {
                if (name == this.fpDeptItem_Sheet1.Columns[i].Label)
                {
                    return i;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// 填充药品信息
        /// </summary>
        private void FillPharmacy()
        {
            DataSet ds = new DataSet();
            #region addby xuewj 2010-9-30 科常用维护增加单价列，调整列显示 {ED623D57-EA44-4f5b-BE41-B127215F5428}
            //if (this.diBusiness.QueryPhaItem(ref ds) == -1)
            if (this.diBusiness.QueryPhaItemNew(ref ds) == -1) 
            #endregion
            {
                MessageBox.Show("获得药品项目失败!");
                return;
            }
            this.dvPharmacy.Table = ds.Tables[0];
            this.fpsPha.DataSource = this.dvPharmacy;
        }

        /// <summary>
        /// 填充非药品信息
        /// </summary>
        private void FillUndrugItem()
        {
            DataSet ds = new DataSet();
            #region addby xuewj 2010-9-30 科常用维护增加单价列，调整列显示 {ED623D57-EA44-4f5b-BE41-B127215F5428}
            //if (this.diBusiness.QueryUndrugItem(ref ds) == -1) 
            if (this.diBusiness.QueryUndrugItemNew(ref ds) == -1) 
            #endregion
            {
                MessageBox.Show("获得非药品项目失败!");
                return;
            }
            
            this.dvUndrugItem.Table = ds.Tables[0];

            this.fpsUndrug.DataSource = this.dvUndrugItem;
        }

        /// <summary>
        /// 填充组合项目信息
        /// </summary>
        private void FillComboItem()
        {
            DataSet ds = new DataSet();
            #region addby xuewj 2010-9-30 科常用维护增加单价列，调整列显示 {ED623D57-EA44-4f5b-BE41-B127215F5428}
            //if (this.diBusiness.QueryComboItem(ref ds) == -1) 
            if (this.diBusiness.QueryComboItemNew(ref ds) == -1) 
            #endregion
            {
                MessageBox.Show("获得组合项目失败!");
                return;
            }
            this.dvCombo.Table = ds.Tables[0];
            this.fpsCombo.DataSource = this.dvCombo;
        }

        /// <summary>
        /// 填充科室(这个函数不用了)，需要根据科室列表维护项目时再加载
        /// </summary>
        private void FillDeptTree()
        {
            TreeNode root = new TreeNode("科室列表");
            root.Tag = null;
            this.tvPatientList1.Nodes.Add(root);

            // 管理员
            if (((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).IsManager)
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                System.Collections.ArrayList alDept = new System.Collections.ArrayList();
                alDept = deptManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.C);
                if (alDept == null)
                {
                    return;
                }
                foreach (Neusoft.FrameWork.Models.NeuObject obj in alDept)
                {
                    TreeNode node = new TreeNode();
                    node.Text = obj.Name;
                    node.Tag = obj;
                    root.Nodes.Add(node);
                }
            }
            else
            {
                Neusoft.FrameWork.Models.NeuObject obj = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept;
                TreeNode node = new TreeNode();
                node.Text = obj.Name;
                node.Tag = obj;
                root.Nodes.Add(node);
            }

            this.tvPatientList1.ExpandAll();
        }

        private void tbFilterValue_KeyUp(object sender, KeyEventArgs e)
        {
            switch (this.filterType)
            {
                case FilterType.P:
                    this.dvPharmacy.RowFilter = "商品名拼音码 like '" + this.tbFilterValue.Text + "%'" + " or 商品名五笔码 like '" + this.tbFilterValue.Text + "%'" + " or 商品名自定义码 like '" + this.tbFilterValue.Text + "%'" + " or 通用名拼音码 like '" + this.tbFilterValue.Text + "%'" + " or 通用名五笔码 like '" + this.tbFilterValue.Text + "%'" + " or 通用名自定义码 like '" + this.tbFilterValue.Text + "%'";
                    this.dvPharmacy.RowStateFilter = DataViewRowState.CurrentRows;
                    break;
                case FilterType.U:
                    this.dvUndrugItem.RowFilter = "输入码 like '" + this.tbFilterValue.Text + "%'" + " or 拼音码 like '" + this.tbFilterValue.Text + "%'" + " or 五笔 like '" + this.tbFilterValue.Text + "%'";
                    this.dvUndrugItem.RowStateFilter = DataViewRowState.CurrentRows;
                    break;
                case FilterType.C:
                    this.dvCombo.RowFilter = "输入码 like '" + this.tbFilterValue.Text + "%'" + " or 拼音码 like '" + this.tbFilterValue.Text + "%'" + " or 五笔 like '" + this.tbFilterValue.Text + "%'";
                    this.dvCombo.RowStateFilter = DataViewRowState.CurrentRows;
                    break;
                default:
                    break;
            }
        }

        private void neuSpread1_ActiveSheetChanging(object sender, FarPoint.Win.Spread.ActiveSheetChangingEventArgs e)
        {
            //每次都重新绑定可以保存数据最新，不知道对不对，速度是挺慢
            switch (e.ActivatedSheetIndex)
            {
                case 0:
                    this.filterType = FilterType.P;
                    this.dvPharmacy = new DataView();
                    this.FillPharmacy();
                    this.tbFilterValue.Text = "";
                    this.tbFilterValue.Focus();
                    this.GetItems("0");
                    break;
                case 1:
                    this.filterType = FilterType.U;
                    this.dvUndrugItem = new DataView();
                    this.FillUndrugItem();
                    this.tbFilterValue.Text = "";
                    this.tbFilterValue.Focus();
                    this.GetItems("1");
                    break;
                case 2:
                    this.filterType = FilterType.C;
                    this.dvCombo = new DataView();
                    this.FillComboItem();
                    this.tbFilterValue.Text = "";
                    this.tbFilterValue.Focus();
                    this.GetItems("2");
                    break;
                default:
                    break;
            }
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string itemID = this.neuSpread1.ActiveSheet.GetText(e.Row, 0);
            string itemName = this.neuSpread1.ActiveSheet.GetText(e.Row, 1);
            string itemType = this.neuSpread1.ActiveSheetIndex.ToString();

            if (IsExist(itemID, itemName))
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("项目已经存在"));
                return;
            }
            this.CreateLine(itemID, itemName, itemType);
        }

        private void fpDeptItem_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //
            // 如果双击的是列头，则返回
            //
            if (e.ColumnHeader)
            {
                return;
            }
            Neusoft.HISFC.Models.Base.DeptItem item = this.CreateDeptItem(e.Row);
            ucDeptItem deptItemWindow = new ucDeptItem();
            deptItemWindow.InsertSuccessed += new InsertSuccessedHandler(deptItemWindow_InsertSuccessed);

            //
            // 根据这个值，决定是更新还是插入
            //
            deptItemWindow.Tag = this.fpDeptItem_Sheet1.GetText(e.Row, this.GetCloumn("科室编号"));
            deptItemWindow.ShowWindow(item);

            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl(deptItemWindow);
        }

        /// <summary>
        /// 在弹出窗口中保存成功时的事件处理函数
        /// </summary>
        private void deptItemWindow_InsertSuccessed()
        {
            //this.fpDeptItem_Sheet1.Rows.Remove(0, this.fpDeptItem_Sheet1.Rows.Count);

            this.Init();
        }

        #region 过去用的

        //private void tvPatientList1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Node == null || e.Node.Tag == null)
        //    {
        //        MessageBox.Show("请选择一个有效科室!");
        //        return;
        //    }
        //    string deptID = ((Neusoft.FrameWork.Models.NeuObject)e.Node.Tag).ID;
        //    this.Init(deptID);
        //}
        ///// <summary>
        ///// 窗口初始化
        ///// </summary>
        ///// <returns>1,成功; -1,失败</returns>
        //private int Init(string deptID)
        //{
        //    List<Neusoft.HISFC.Models.Base.DeptItem> lstItems = new List<Neusoft.HISFC.Models.Base.DeptItem>();
        //    if (this.diBusiness.SelectItem(ref lstItems, deptID) == -1)
        //    {
        //        return -1;
        //    }
        //    this.InitFarPoint(lstItems);

        //    this.neuSpread1.ActiveSheetIndex = 0;

        //    return 1;
        //}
        //private void neuComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (this.neuComboBox1.Text.Trim())
        //    {
        //        case "药品项目":
        //            this.neuSpread1.ActiveSheetIndex = 0;
        //            this.filterType = FilterType.P;
        //            break;
        //        case "非药品项目":
        //            this.neuSpread1.ActiveSheetIndex = 1;
        //            this.filterType = FilterType.U;
        //            break;
        //        case "组合项目":
        //            this.neuSpread1.ActiveSheetIndex = 2;
        //            this.filterType = FilterType.C;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        ///// <summary>
        ///// 增加一个新行
        ///// </summary>
        ///// <param name="obj"></param>
        //private void CreateLine(Neusoft.FrameWork.Models.NeuObject obj)
        //{
        //    //增加一个新行
        //    int rowIndex = this.fpDeptItem_Sheet1.Rows.Count;
        //    this.fpDeptItem_Sheet1.Rows.Add(rowIndex, 1);

        //    //第0列是在业务层转换得到的,所以在这里为暂时不加
        //    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("项目编号"), obj.ID);
        //    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("项目名称"), obj.Name);
        //    //
        //    this.fpDeptItem_Sheet1.SetText(rowIndex, this.GetCloumn("科内名称"), obj.Name);
        //    this.fpDeptItem_Sheet1.ActiveRowIndex = rowIndex;
        //}

        ///// <summary>
        ///// 项目是否已经存在
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns>存在:true;  否则:false</returns>
        //private bool IsExist(Neusoft.FrameWork.Models.NeuObject obj)
        //{
        //    for (int i = 0, j = this.fpDeptItem_Sheet1.Rows.Count; i < j; i++)
        //    {
        //        if (this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目编号")).Trim().Equals(obj.ID) &&
        //            this.fpDeptItem_Sheet1.GetText(i, this.GetCloumn("项目名称")).Trim().Equals(obj.Name))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 双击上面控件时的事件处理程序
        ///// </summary>
        ///// <param name="sender"></param>
        //private void ucAllItems_SelectedItem(Neusoft.FrameWork.Models.NeuObject sender)
        //{
        //    if (IsExist(sender))
        //    {
        //        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("项目已经存在"));
        //        return;
        //    }

        //    this.CreateLine(sender);
        //}
        #endregion

        #region 增加批量增加 {D0D124E4-19EB-4b49-9D45-D014D1DD012F} wbo 2010-09-30

        /// <summary>
        /// 批量增加常用项目0药品1非药品2组合项目
        /// </summary>
        /// <param name="flag"></param>
        private void AddAll(int flag)
        {
            if (flag < 0 || flag >= this.neuSpread1.Sheets.Count)
            {
                return;
            }
            this.neuSpread1.ActiveSheet = this.neuSpread1.Sheets[flag];
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在添加，请稍后... ...");
            Application.DoEvents();
            int count = this.neuSpread1.Sheets[flag].Rows.Count;
            for (int i = 0; i < this.neuSpread1.Sheets[flag].Rows.Count; i++)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i, count);
                Application.DoEvents();

                string itemID = this.neuSpread1.Sheets[flag].GetText(i, 0);
                string itemName = this.neuSpread1.Sheets[flag].GetText(i, 1);
                string itemType = this.neuSpread1.Sheets[flag].ToString();

                if (IsExist(itemID, itemName))
                {
                    continue;
                }
                this.CreateLine(itemID, itemName, itemType);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        #endregion

    }

    internal enum FilterType
    {
        /// <summary>
        /// 药品
        /// </summary>
        P,
        /// <summary>
        /// 非药品
        /// </summary>
        U,
        /// <summary>
        /// 组合项目
        /// </summary>
        C
    }
}
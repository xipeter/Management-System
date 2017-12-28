using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// [功能描述: 固定费用维护]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBedFeeMaintenance : UserControl, Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucBedFeeMaintenance()
        {
            InitializeComponent();

        }

        #region 变量

        /// <summary>
        /// 管理业务层

        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 窗口
        /// </summary>
        private Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm maintenanceForm;

        /// <summary>
        /// 固定费用业务层出
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.BedFeeItem bedFeeItemManager = new Neusoft.HISFC.BizLogic.Fee.BedFeeItem();

        /// <summary>
        /// 项目信息业务层

        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Item itemManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 非药品信息实体

        /// </summary>
        private static ArrayList itemInfoList = new ArrayList();

        /// <summary>
        /// 更新UC
        /// </summary>
        private Maintenance.ucBedFeeItemModify ucModify = new ucBedFeeItemModify();

        /// <summary>
        /// [2007/02/06] 是否被更改

        /// </summary>
        private bool isDirty = false;

        #endregion


        #region 私有方法


        /// <summary>
        /// 初始化床位等级

        /// </summary>
        protected virtual int InitTree()
        {
            this.tvBedGrade.ImageList = new ImageList();
            this.tvBedGrade.ImageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.L楼房));
            this.tvBedGrade.ImageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.C床位维护));
            this.tvBedGrade.ImageList.Images.Add(Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选));
            
            this.tvBedGrade.Nodes.Clear();


            this.tvBedGrade.Nodes.AddRange(
                new TreeNode[] {
						  new TreeNode("床位等级")
                                });
            //床位等级树

            try
            {

                ArrayList reportTypes = new ArrayList();
                reportTypes = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BEDGRADE);

                for (int j = 0; j < reportTypes.Count; j++)
                {
                    Neusoft.HISFC.Models.Base.Const obj = new Neusoft.HISFC.Models.Base.Const();
                    obj = (Neusoft.HISFC.Models.Base.Const)reportTypes[j];
                    TreeNode tnReportName = new TreeNode();
                    tnReportName = new TreeNode(obj.Name);
                    tnReportName.Tag = obj.ID;
                    tnReportName.Text = obj.Name;
                    tnReportName.ImageIndex = 1;
                    tvBedGrade.Nodes[0].Nodes.Add(tnReportName);
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return -1;
            }

            this.tvBedGrade.ExpandAll();
            return 1;
        }


        /// <summary>
        /// 添充床位等级所包含内容
        /// </summary>
        /// <param name="feeCodeStat"></param>
        /// <param name="row"></param>
        private void SetValue(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem, int row)
        {
            //{21267B78-C198-43ed-8C52-5364C6F70FDA}
            Neusoft.HISFC.Models.Fee.Item.Undrug item = this.itemManager.GetUndrugByCode(bedFeeItem.ID);

            if (item.ValidState == "0")
            {
                this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].Text = "帐页停用";
                this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].ForeColor = Color.Red;
            }

             if (item.ValidState == "2")
            {
                this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].Text = "帐页废弃";
                this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].ForeColor = Color.Red;
            }

             if (item.ValidState == "1")
             {
                 this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].Text = string.Empty;
                 this.neuSpread1_Sheet1.RowHeader.Cells[row, 0].ForeColor = this.neuSpread1_Sheet1.ColumnHeader.Cells[0, 0].ForeColor;
                 
             }

            this.neuSpread1_Sheet1.SetValue(row,0,bedFeeItem.PrimaryKey);
            this.neuSpread1_Sheet1.SetValue(row, 1, bedFeeItem.ID);
            this.neuSpread1_Sheet1.SetValue(row,2,bedFeeItem.Name);
            this.neuSpread1_Sheet1.SetValue(row, 3, bedFeeItem.Qty);
            // {88D26424-49FC-4b64-A0C3-6569CD196970}

            //this.neuSpread1_Sheet1.SetValue(row, 4, itemManager.GetValidItemByUndrugCode(bedFeeItem.ID).Price.ToString());
            this.neuSpread1_Sheet1.SetValue(row, 4, itemManager.GetUndrugByCode(bedFeeItem.ID).Price.ToString());
            this.neuSpread1_Sheet1.SetValue(row, 5, bedFeeItem.BeginTime.Date == new DateTime(1,1,1).Date?string.Empty:bedFeeItem.BeginTime.Date.ToString("yyyy-MM-dd"));
    
            this.neuSpread1_Sheet1.SetValue(row, 6,bedFeeItem.EndTime.Date == new DateTime(1,1,1).Date?string.Empty:bedFeeItem.EndTime.Date.ToString("yyyy-MM-dd"));
            this.neuSpread1_Sheet1.SetValue(row, 7, bedFeeItem.IsBabyRelation);
            this.neuSpread1_Sheet1.SetValue(row, 8, bedFeeItem.IsTimeRelation);
            this.neuSpread1_Sheet1.SetValue(row, 9, GetValidName(bedFeeItem.ValidState));
            this.neuSpread1_Sheet1.SetValue(row, 10, bedFeeItem.SortID);

            this.neuSpread1_Sheet1.Rows[row].Tag = bedFeeItem;
        }

        #endregion

        /// <summary>
        /// 通过有效性ID得到名称
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        private string GetValidName(Neusoft.HISFC.Models.Base.EnumValidState strID)
        {
            switch (strID)
            {
                case Neusoft.HISFC.Models.Base.EnumValidState.Valid:
                    return "在用";
                case Neusoft.HISFC.Models.Base.EnumValidState.Invalid:
                    return "停用";
                case Neusoft.HISFC.Models.Base.EnumValidState.Ignore:
                    return  "废弃";
                default:
                    return "在用";
            }
  
        }
        #region IMaintenanceControlable 成员

        /// <summary>
        /// 在一个床位等级中增加新项目

        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            // [2007/02/06] 新增加代码开始

            if (tvBedGrade.SelectedNode == null)
            {
                MessageBox.Show("请注意一个床位等级");
                return 1;
            }
            // 新增加代码结束


            int activeRow = this.neuSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Fee.BedFeeItem obedFeeItem = new Neusoft.HISFC.Models.Fee.BedFeeItem();

            if (tvBedGrade.SelectedNode.Level == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择床位等级"));

                return 1;
            }
                 
            obedFeeItem.FeeGradeCode = tvBedGrade.SelectedNode.Tag.ToString();
            obedFeeItem.User03 = "ADD";

            // [2007/02/07] 新增加的代码
            this.ucModify = new ucBedFeeItemModify();
           ucModify.Save+= new ucBedFeeItemModify.ClickSave( ucModify_Save);
            // 新增加的代码结束
           

            ucModify.SaveType = ucBedFeeItemModify.EnumSaveTypes.Add;
            ucModify.BedFeeItem = obedFeeItem;
            ucModify.ItemInfo.Clear();
            ucModify.ItemInfo.AddRange(itemInfoList);

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucModify);

            // [2007/02/06] 新增加的代码开始

            this.isDirty = true;
            // 新增加代码结束


            return 1;
        }

        public int Copy()
        {
            return 1;
        }

        public int Cut()
        {
            return 1;
        }

        public int Delete()
        {
            return 1;
        }

        public int Export()
        {
            return 1;
        }

        public int Import()
        {
            return 1;
        }

        public int Init()
        {
            return this.InitTree();
        }

        public bool IsDirty
        {
            get
            {
                return this.isDirty;
                //return true;
            }
            set
            {

            }
        }

        public int Modify()
        {
            if (this.neuSpread1_Sheet1.RowCount == 0)
            {
                return -1;
            }

            int activeRow = this.neuSpread1_Sheet1.ActiveRowIndex;

            Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem = this.neuSpread1_Sheet1.Rows[activeRow].Tag as Neusoft.HISFC.Models.Fee.BedFeeItem;

            ucModify.SaveType = ucBedFeeItemModify.EnumSaveTypes.Modify;
            bedFeeItem.User03 = "MODIFY";
            ucModify.BedFeeItem = bedFeeItem;
            ucModify.ItemInfo.Clear();
            ucModify.ItemInfo.AddRange(itemInfoList);

            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucModify);

            // [2007/02/06] 新增加的代码开始

            this.isDirty = true;
            // 新增加代码结束


            return 1;
        }

        public int NextRow()
        {
            return 1;
        }

        public int Paste()
        {
            return 1;
        }

        public int PreRow()
        {
            return 1;
        }

        public int Print()
        {
            return 1;
        }

        public int PrintConfig()
        {
            return 1;
        }

        public int PrintPreview()
        {
            return 1;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public int Query()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在处理，请稍候^^"));
            
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            TreeNode treeNode = this.tvBedGrade.SelectedNode;

            if (treeNode == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            if (treeNode.Parent == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            if (treeNode.Tag == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            if (treeNode.Level == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("请选择床位等级"));
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            ArrayList bedFeeItemList = this.bedFeeItemManager.QueryBedFeeItemByMinFeeCode(treeNode.Tag.ToString());

            this.neuSpread1_Sheet1.RowCount = bedFeeItemList.Count;

            for (int i = 0; i < bedFeeItemList.Count; i++)
            {
                Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem = bedFeeItemList[i] as Neusoft.HISFC.Models.Fee.BedFeeItem;

                SetValue(bedFeeItem, i);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return this.maintenanceForm;
            }
            set
            {
                this.maintenanceForm = value;
            }
        }

        public int Save()
        {
            return 1;
        }

        #endregion

        private void tvBedGrade_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Query();
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.Modify();
        }

        private void ucBedFeeMaintenance_Load(object sender, EventArgs e)
        {
            this.ucModify.Save += new ucBedFeeItemModify.ClickSave(ucModify_Save);
            this.maintenanceForm.ShowCopyButton = false;
            this.maintenanceForm.ShowExportButton = false;
            this.maintenanceForm.ShowImportButton = false;
            this.maintenanceForm.ShowPreRowButton = false;
            this.maintenanceForm.ShowNextRowButton = false;
            this.maintenanceForm.ShowPrintButton = false;
            this.maintenanceForm.ShowPrintConfigButton = false;
            this.maintenanceForm.ShowPrintPreviewButton = false;
            this.maintenanceForm.ShowSaveButton = false;
            this.maintenanceForm.ShowDeleteButton = false;

            //Neusoft.FrameWork.WinForms.Forms.frmMaintenance f = (Neusoft.FrameWork.WinForms.Forms.frmMaintenance)this.maintenanceForm;
            //f.ShowQueryButton = false;
            
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在初始化窗口，请稍候^^"));
            Application.DoEvents();
            itemInfoList = this.itemManager.QueryValidItems();
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            
        }

        int ucModify_Save(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem)
        {
            // [2007/02/06] 新增加的代码
            //判断是否已经添加了

            //for (int i = 0, j = this.neuSpread1_Sheet1.Rows.Count; i < j; i++)
            //{
            //    if (this.neuSpread1_Sheet1.GetText(i,1).Equals(bedFeeItem.ID))
            //    {
            //        MessageBox.Show("数据已经存在,不能添加", "提示", MessageBoxButtons.OK);
            //        return;
            //    }
            //}
            // 新增加的代码结束
          
            if (bedFeeItem.User03 == "ADD")
            {
               
                for (int i = 0, j = this.neuSpread1_Sheet1.Rows.Count; i < j; i++)
                {
                    if (this.neuSpread1_Sheet1.GetText(i, 1).Equals(bedFeeItem.ID))
                    {
                        MessageBox.Show("数据已经存在,不能添加", "提示", MessageBoxButtons.OK);
                       
                        
                        return -1;
                    }
                }
                int row = this.neuSpread1_Sheet1.RowCount;

                this.neuSpread1_Sheet1.Rows.Add(row, 1);

                row = this.neuSpread1_Sheet1.Rows.Count - 1;

                this.SetValue(bedFeeItem, row);
                //修改人：路志鹏

                //时间：２００７－４－１０
                //目的：修改［当填写和存在的数据一致的项目，保存，给出信息提示不允许保存成功，此时再添加不同项目，保存成功，但却将提示的那个与存在数据一致的项目也保存成功了］

                //ArrayList bedFeeItemList = this.bedFeeItemManager.QueryBedFeeItemByMinFeeCode(bedFeeItem.FeeGradeCode);

                //this.neuSpread1_Sheet1.RowCount = bedFeeItemList.Count;

                //for (int i = 0; i < bedFeeItemList.Count; i++)
                //{
                //    Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItemQuery = bedFeeItemList[i] as Neusoft.HISFC.Models.Fee.BedFeeItem;

                //    SetValue(bedFeeItemQuery, i);
                //}
                return 0;
            }
            if (bedFeeItem.User03 == "MODIFY")
            {
                int activeRow = this.neuSpread1_Sheet1.ActiveRowIndex;

                this.SetValue(bedFeeItem, activeRow);
                return 0;
                              
            }
            return 0;
        }
        

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.Modify();
        }
    }
}

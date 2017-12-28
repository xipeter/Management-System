using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Classes;
using Neusoft.HISFC.Components.Manager.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucMaintenaceInterface : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private List<Neusoft.FrameWork.Models.NeuObject> resourceTypes = null;
        private List<ReportPrint> allInterfaceInfo = null;
        private Dictionary<string, string> resourceTypesMapping = null;
        private List<Neusoft.FrameWork.WinForms.Classes.ControlParam> allControlParamInfo = null;
        private List<Neusoft.FrameWork.WinForms.Classes.ControlParam> typeControlParamInfo = null;

        public ucMaintenaceInterface()
        {
            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Green);
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(neuSpread1);
            this.neuSpread1_Sheet1.RowCount = 0;
            Neusoft.FrameWork.WinForms.Classes.Function.SetTabControlStyle(tbControl);
            Neusoft.FrameWork.WinForms.Classes.Function.SetListViewStyle(tvInterface);
            this.splitter1.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor(Neusoft.FrameWork.WinForms.Classes.EnumSysColor.Green);
            //接口控件设置
            InittvContainType();
            InitInterfaceInfo();

            InitParamInfo();
        }


        #region  工具栏

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbar = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
            toolbar.AddToolButton("添加", "添加新接口及实现！", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolbar.AddToolButton("修改", "修改新接口及实现！", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改, true, false, null);
            toolbar.AddToolButton("删除", "删除新接口及实现！", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolbar.AddToolButton("添加分类", "删除新接口及实现！", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分类添加, true, false, null);
            toolbar.AddToolButton("删除分类", "删除新接口及实现！", Neusoft.FrameWork.WinForms.Classes.EnumImageList.F分类删除, true, false, null);
            return toolbar;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "添加分类")
            {
                this.AddType();
            }
            if (e.ClickedItem.Text == "删除分类")
            {
                DeleteType();
            }

            if (e.ClickedItem.Text == "添加")
            {
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.InterfaceInfo.ToString())
                {
                    AddInterfaceInfo();
                }
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.ParamInfo.ToString())
                {
                    AddParam();
                }
            }
            if (e.ClickedItem.Text == "修改")
            {
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.InterfaceInfo.ToString())
                {
                    tvInterface_DoubleClick(null, null);
                }
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.ParamInfo.ToString())
                {
                    UpdateParam();
                }
            }
            if (e.ClickedItem.Text == "删除")
            {
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.InterfaceInfo.ToString())
                {
                    DeleteInterfaceInfo();
                }
                if (this.tbControl.SelectedTab.Name.Trim() == PageType.ParamInfo.ToString())
                {
                    this.DeleteParam();
                }
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        #region   私有方法


        public void AddParam()
        {

            frmEditParam frmParm = new frmEditParam(resourceTypes);
            if (frmParm.ShowDialog() == DialogResult.OK)
            {
                InitNeuSpreed();
            }
        }

        public void UpdateParam()
        {
            if (neuSpread1_Sheet1.ActiveRow.Index == -1)
            {
                MessageBox.Show("请选择要修改的行！");
                return;
            }

            frmEditParam frmParm = new frmEditParam(resourceTypes, neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.FrameWork.WinForms.Classes.ControlParam, resourceTypesMapping);
            if (frmParm.ShowDialog() == DialogResult.OK)
            {
                InitNeuSpreed();
            }
        }

        public void DeleteParam()
        {
            if (neuSpread1_Sheet1.ActiveRow.Index == -1)
            {
                MessageBox.Show("请选择要删除行！");
                return;
            }
            if (MessageBox.Show("是否要删除该行?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new Neusoft.FrameWork.WinForms.Classes.ControlParamManager().Delete((neuSpread1_Sheet1.ActiveRow.Tag as Neusoft.FrameWork.WinForms.Classes.ControlParam).ID);
            if (ret != -1)
            {
                MessageBox.Show("删除成功");
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                InitNeuSpreed();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }

        }


        public void AddInterfaceInfo()
        {
            Neusoft.HISFC.Components.Manager.Forms.frmMaintenacePop newAddForm = new Neusoft.HISFC.Components.Manager.Forms.frmMaintenacePop(resourceTypes);
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                IntiTreeListView();
            }
        }

        public void UpdateInterfaceInfo(ReportPrint reportPrint)
        {
            Neusoft.HISFC.Components.Manager.Forms.frmMaintenacePop newAddForm = new Neusoft.HISFC.Components.Manager.Forms.frmMaintenacePop(reportPrint, resourceTypes, resourceTypesMapping);
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                IntiTreeListView();
            }
        }

        public void DeleteInterfaceInfo()
        {
            if (tvInterface.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除行！");
                return;
            }
            if (MessageBox.Show("是否要删除该行?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new ReportPrintManager().DeleteData(tvInterface.SelectedItems[0].Tag as ReportPrint);
            if (ret != -1)
            {
                MessageBox.Show("删除成功");
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                IntiTreeListView();
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
            }

        }

        public void AddType()
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            TreeNode newNode = new TreeNode();
            obj.ID = string.Empty;
            obj.Name = "新分类";
            
            if (this.SaveType(obj) <= 0)
            {
                return;
            }
            resourceTypes.Add(obj);
            newNode.Text = obj.Name;
            newNode.Tag = obj;
            tvContainType.Nodes[0].Nodes.Add(newNode);
            tvContainType.SelectedNode = newNode;
            newNode.BeginEdit();
        }

        public void DeleteType()
        {
            if (tvContainType.SelectedNode.Text == "组件模块分类")
            {
                MessageBox.Show("该结点不能被删除！");
                return;
            }
            //分类中存在接口，控件参数等等，就不能被删除，以后更新。
            if (new Neusoft.FrameWork.WinForms.Classes.ReportPrintManager().JudgeType(tvContainType.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject) == -1)
            {
                MessageBox.Show("该分类中存在子信息，不可以删除！");
                return;
            }

            if (MessageBox.Show("是否要删除该行?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new Neusoft.FrameWork.WinForms.Classes.ReportPrintManager().DeleteType(tvContainType.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject);
            if (ret == -1)
            {
                MessageBox.Show("删除失败!");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            InittvContainType();
        }

        private List<Neusoft.FrameWork.Models.NeuObject> GetResourceTypes()
        {
            return new Neusoft.FrameWork.WinForms.Classes.ReportPrintManager().QueryType();
        }

        private void InittvContainType()
        {
            tvContainType.Nodes.Clear();
            if (resourceTypes != null)
            {
                resourceTypes.Clear();
            }
            if (resourceTypesMapping != null)
            {
                resourceTypesMapping.Clear();
            }

            resourceTypes = GetResourceTypes();
            resourceTypesMapping = new Dictionary<string, string>();

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "组件模块分类";
            rootNode.ExpandAll();
            //只设置一级节点，不考虑多级节点。
            foreach (Neusoft.FrameWork.Models.NeuObject res in resourceTypes)
            {
                TreeNode newNode = new TreeNode();
                newNode.Tag = res;
                newNode.Text = res.Name;
                rootNode.Nodes.Add(newNode);
                resourceTypesMapping.Add(res.ID, res.Name);
            }

            tvContainType.Nodes.Add(rootNode);

        }

        private void InitInterfaceInfo()
        {
            allInterfaceInfo = new ReportPrintManager().LoadData();
        }

        private void IntiTreeListView()
        {
            tvInterface.Items.Clear();
            InitInterfaceInfo();
            foreach (ReportPrint pri in allInterfaceInfo)
            {
                TreeListViewItem newItem = new TreeListViewItem();
                newItem.Tag = pri;
                newItem.Text = pri.ContainerDllName;
                if (!resourceTypesMapping.ContainsKey(pri.ContainerType))
                {
                    newItem.SubItems.AddRange(new string[] { pri.ContainerContorl, "", pri.Name });

                }
                else
                {
                    newItem.SubItems.AddRange(new string[] { pri.ContainerContorl, resourceTypesMapping[pri.ContainerType], pri.Name });

                }
                tvInterface.Items.Add(newItem);
            }
        }

        private void InitParamInfo()
        {
            allControlParamInfo = new Neusoft.FrameWork.WinForms.Classes.ControlParamManager().Query();
        }

        private void InitNeuSpreed()
        {

            InitParamInfo();
            if (allControlParamInfo == null) return;

            neuSpread1_Sheet1.RowCount = allControlParamInfo.Count;
            for (int i = 0; i < allControlParamInfo.Count; i++)
            {
                neuSpread1_Sheet1.Cells[i, 0].Text = allControlParamInfo[i].ID;
                neuSpread1_Sheet1.Cells[i, 1].Text = allControlParamInfo[i].Name;
                neuSpread1_Sheet1.Cells[i, 3].Text = Neusoft.FrameWork.Function.NConvert.ToBoolean(allControlParamInfo[i].ParamState).ToString();
                neuSpread1_Sheet1.Rows[i].Tag = allControlParamInfo[i];

                if (allControlParamInfo[i].ParamControlKind == frmEditParam.ControlTypeValue.颜色.ToString())
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    neuSpread1_Sheet1.Cells[i, 2].Text = string.Empty;
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(allControlParamInfo[i].ParamValue));
                }
                else if (allControlParamInfo[i].ParamControlKind == frmEditParam.ControlTypeValue.选择框.ToString())
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType =new  FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.White;
                    neuSpread1_Sheet1.Cells[i, 2].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(allControlParamInfo[i].ParamValue).ToString();
                }
                else
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.White;
                    neuSpread1_Sheet1.Cells[i, 2].Text = allControlParamInfo[i].ParamValue;
                }
            }
        }


        private void InitNeuSpreed(List<Neusoft.FrameWork.WinForms.Classes.ControlParam> typeControlParamInfo)
        {

            if (typeControlParamInfo == null) return;

            neuSpread1_Sheet1.RowCount = typeControlParamInfo.Count;
            for (int i = 0; i < typeControlParamInfo.Count; i++)
            {
                neuSpread1_Sheet1.Cells[i, 0].Text = typeControlParamInfo[i].ID;
                neuSpread1_Sheet1.Cells[i, 1].Text = typeControlParamInfo[i].Name;
                neuSpread1_Sheet1.Cells[i, 3].Text = Neusoft.FrameWork.Function.NConvert.ToBoolean(typeControlParamInfo[i].ParamState).ToString();
                neuSpread1_Sheet1.Rows[i].Tag = typeControlParamInfo[i];

                if (typeControlParamInfo[i].ParamControlKind == frmEditParam.ControlTypeValue.颜色.ToString())
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    neuSpread1_Sheet1.Cells[i, 2].Text = string.Empty;
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.FromArgb(Neusoft.FrameWork.Function.NConvert.ToInt32(typeControlParamInfo[i].ParamValue));
                }
                else if (typeControlParamInfo[i].ParamControlKind == frmEditParam.ControlTypeValue.选择框.ToString())
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType =new  FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.White;
                    neuSpread1_Sheet1.Cells[i, 2].Value = Neusoft.FrameWork.Function.NConvert.ToBoolean(typeControlParamInfo[i].ParamValue).ToString();
                }
                else
                {
                    neuSpread1_Sheet1.Cells[i, 2].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    neuSpread1_Sheet1.Cells[i, 2].BackColor = Color.White;
                    neuSpread1_Sheet1.Cells[i, 2].Text = typeControlParamInfo[i].ParamValue;
                }
            }
        }

        private void InterfaceInfoByType()
        {
            tvInterface.Items.Clear();
            InitInterfaceInfo();
            if (tvContainType.SelectedNode != null)
            {
                if (tvContainType.SelectedNode.Text == "组件模块分类")
                {
                    IntiTreeListView();
                }
                else
                {
                    foreach (ReportPrint pri in allInterfaceInfo)
                    {
                        if (pri.ContainerType == (tvContainType.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).ID)
                        {
                            TreeListViewItem newItem = new TreeListViewItem();
                            newItem.Tag = pri;
                            newItem.Text = pri.ContainerDllName;
                            if (!resourceTypesMapping.ContainsKey(pri.ContainerType))
                            {
                                newItem.SubItems.AddRange(new string[] { pri.ContainerContorl, "", pri.Name });

                            }
                            else
                            {
                                newItem.SubItems.AddRange(new string[] { pri.ContainerContorl, resourceTypesMapping[pri.ContainerType], pri.Name });

                            }
                            tvInterface.Items.Add(newItem);
                        }
                    }
                }
            }
        }

        private void ParamInfoByType()
        {
            InitParamInfo();
            if (tvContainType.SelectedNode != null)
            {
                if (tvContainType.SelectedNode.Text == "组件模块分类")
                {
                    InitNeuSpreed();
                }
                else
                {
                    typeControlParamInfo = new List<ControlParam>();
                    if (allControlParamInfo == null)
                    {
                        return;
                    }
                    foreach (Neusoft.FrameWork.WinForms.Classes.ControlParam contorlParam in allControlParamInfo)
                    {
                        if (contorlParam.ParamKind == (tvContainType.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).ID)
                        {
                            typeControlParamInfo.Add(contorlParam);
                        }
                    }

                    InitNeuSpreed(typeControlParamInfo);
                }
            }
        }

        public enum PageType
        {
            InterfaceInfo,
            ParamInfo,
            TestInfo
        }

        private int SaveType(Neusoft.FrameWork.Models.NeuObject obj)
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            int ret = new Neusoft.FrameWork.WinForms.Classes.ReportPrintManager().SaveReportPrintType(obj);
            if (ret == -1)
            {
                MessageBox.Show("保存失败!");
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            return ret;
        }

        #endregion

        #region 事件

        public void tvInterface_DoubleClick(object sender, EventArgs e)
        {
            if (tvInterface.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改行！");
                return;
            }
            UpdateInterfaceInfo(tvInterface.SelectedItems[0].Tag as ReportPrint);
        }

        private void tvContainType_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //if (InterfaceInfo.Name.Trim() == PageType.InterfaceInfo.ToString())
            //{
            //    InterfaceInfoByType();
            //}
            //if (ParamInfo.Name.Trim() == PageType.ParamInfo.ToString())
            //{
            //    ParamInfoByType();
            //}

        }
        private void tvContainType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (InterfaceInfo.Name.Trim() == PageType.InterfaceInfo.ToString())
            {
                e.Node.EndEdit(false);
                InterfaceInfoByType();
            }
            if (ParamInfo.Name.Trim() == PageType.ParamInfo.ToString())
            {
                ParamInfoByType();
            }
        }

        private void tvContainType_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode _node = tvContainType.SelectedNode;
            if (_node == null) return;

            //不是分类,不许编辑
            if (_node.Level == 0) e.CancelEdit = true;

        }

        private void tvContainType_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return;
            Neusoft.FrameWork.Models.NeuObject obj = tvContainType.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
            obj.Name = e.Label;
            this.SaveType(obj);
        }

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbControl.SelectedTab.Name == PageType.InterfaceInfo.ToString())
            {
                IntiTreeListView();
            }
            else if (tbControl.SelectedTab.Name == PageType.ParamInfo.ToString())
            {
                InitNeuSpreed();

            }

        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row != -1 && e.Column != -1)
            {
                UpdateParam();
            }
        }

        #endregion












    }

}

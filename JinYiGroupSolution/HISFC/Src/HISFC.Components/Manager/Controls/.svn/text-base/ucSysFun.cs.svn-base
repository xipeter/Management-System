using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Manager.Controls
{
    /// <summary>
    /// UcSysFunction 的摘要说明。
    /// </summary>
    public class ucSysFunction : System.Windows.Forms.UserControl,
        Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView treeView;

        private DataTable table;
        private DataView view;
        bool isDirty = false;

        private Hashtable modelCache = new Hashtable();
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private Neusoft.FrameWork.WinForms.Controls.NeuSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip neuContextMenuStrip1;
        private ToolStripMenuItem mnuShow;
        private ToolStripMenuItem sQL维护ToolStripMenuItem;
        private System.ComponentModel.IContainer components;

        public ucSysFunction()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            this.Initialize();
            // TODO: 在 InitializeComponent 调用后添加任何初始化
          

        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        private FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fpSpread1 = new Neusoft.FrameWork.WinForms.Controls.NeuSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.neuContextMenuStrip1 = new Neusoft.FrameWork.WinForms.Controls.NeuContextMenuStrip();
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.sQL维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.neuContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(188, 416);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(188, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 416);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fpSpread1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(192, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 416);
            this.panel1.TabIndex = 3;
            // 
            // fpSpread1
            // 
            this.fpSpread1.About = "2.5.2007.2005";
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.BackColor = System.Drawing.Color.White;
            this.fpSpread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread1.FileName = "";
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = true;
            this.fpSpread1.Location = new System.Drawing.Point(0, 0);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(780, 416);
            this.fpSpread1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            this.fpSpread1.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpSpread1_CellDoubleClick);
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.RowHeader.Columns.Get(0).Width = 37F;
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "";
            // 
            // neuContextMenuStrip1
            // 
            this.neuContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShow,
            this.sQL维护ToolStripMenuItem});
            this.neuContextMenuStrip1.Name = "neuContextMenuStrip1";
            this.neuContextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            this.neuContextMenuStrip1.Style = Neusoft.FrameWork.WinForms.Controls.StyleType.Fixed3D;
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(152, 22);
            this.mnuShow.Text = "显示窗口";
            this.mnuShow.Click += new System.EventHandler(this.mnuShow_Click_1);
            // 
            // sQL维护ToolStripMenuItem
            // 
            this.sQL维护ToolStripMenuItem.Name = "sQL维护ToolStripMenuItem";
            this.sQL维护ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sQL维护ToolStripMenuItem.Text = "SQL维护";
            this.sQL维护ToolStripMenuItem.Click += new System.EventHandler(this.单表维护ToolStripMenuItem_Click);
            // 
            // ucSysFunction
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView);
            this.Name = "ucSysFunction";
            this.Size = new System.Drawing.Size(972, 416);
            this.Load += new System.EventHandler(this.ucSysFunction_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.neuContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        #region IToolBar 成员

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Del()
        {
            // TODO:  添加 UcSysFunction.Del 实现
            DeleteData();
            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            // TODO:  添加 UcSysFunction.Print 实现
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Border;
            p.PrintPreview(panel1);
            return 0;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            // TODO:  添加 UcSysFunction.Add 实现
            AddData();
            return 0;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public int Exit()
        {
            // TODO:  添加 UcSysFunction.Exit 实现
            this.fpSpread1.StopCellEditing();
            this.FindForm().Close();
            return 0;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            // TODO:  添加 UcSysFunction.Save 实现
            SaveData();
            return 0;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public int  Export()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "系统功能模块";

                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //以Excel 的形式导出数据
                    ret = fpSpread1.SaveExcel(saveFileDialog1.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
                    if (ret)
                    {
                        MessageBox.Show("导出成功！");
                        return 0;
                    }
                }
            }
            catch (Exception ee)
            {
                //出错了
                MessageBox.Show(ee.Message);
            }
            return -1;
        }
        #endregion

        public void Initialize()
        {
            
            comboBoxCellType1.Items = new string[] { "MDI", "Form", "FormDialog" };
            comboBoxCellType2.Items = new string[] { "Form", "Control", "Report" };

            TreeNode node = new TreeNode("系统模块列表");
            node.Tag = "";
            this.treeView.Nodes.Add(node);

            Neusoft.HISFC.BizLogic.Manager.SysModelManager modelMgr = new Neusoft.HISFC.BizLogic.Manager.SysModelManager();
            ArrayList modelList = modelMgr.LoadAll();
            foreach (Neusoft.HISFC.Models.Admin.SysModel model in modelList)
            {
                AddTreeNode(node, model);
            }

            node.ExpandAll();
            this.treeView.SelectedNode = node;

            #region 加载模块功能信息 --修改

            initDataSet();

            Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager funMgr = new Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager();
            ArrayList funList = funMgr.QuerySysModelFunction();
            foreach (Neusoft.HISFC.Models.Admin.SysModelFunction fun in funList)
            {
                table.Rows.Add(new object[] { 
                    fun.SysCode, 
                    fun.FunName, 
                    fun.WinName,
                    fun.DllName,
                    fun.FormShowType,
                    fun.FormType,
                    fun.Memo, 
                    fun.Param,
                    fun.TreeControl.DllName,
                    fun.TreeControl.WinName,
                    fun.TreeControl.Param,
                    fun.ID,
                    fun.SortID,
                    "old" });
            }
        
            view = table.DefaultView;
          
            view.RowFilter = "";

            this.fpSpread1_Sheet1.DataSource = view;
            this.table.AcceptChanges();
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;

            #endregion

            SetCellType();

            this.fpSpread1_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread1_Sheet1.Columns[2].Width = 200;
            this.fpSpread1_Sheet1.Columns[2].BackColor = Color.MistyRose;
            this.fpSpread1_Sheet1.Columns[2].ForeColor = Color.Black;
            this.fpSpread1.ContextMenuStrip = this.neuContextMenuStrip1;
            

        }

        private void AddTreeNode(TreeNode node, Neusoft.HISFC.Models.Admin.SysModel model)
        {
            TreeNode child = new TreeNode(model.SysCode);
            child.Text = model.SysName;
            child.Tag = model.SysCode;
            modelCache.Add(model.SysCode, model.SysName);
            node.Nodes.Add(child);
        }

        private void initDataSet()
        {
            table = new DataTable("ModelFunction");
            DataColumn c0 = new DataColumn("SysCode");
            //c0.Caption = "系统组";
            c0.DataType = typeof(System.String);
            table.Columns.Add(c0);

            DataColumn c1 = new DataColumn("窗口名称");//窗口名称
            c1.DataType = typeof(System.String);
            //c1.Caption = "窗口名称";
            table.Columns.Add(c1);

            DataColumn c2 = new DataColumn("控件/窗口名称");//控件/窗口名称
            c2.DataType = typeof(System.String);
            //c2.Caption = "控件/窗口名称";
            table.Columns.Add(c2);

            DataColumn c3 = new DataColumn("Dll名称");//dll名称
            c3.DataType = typeof(System.String);
            //c3.Caption = "Dll名称";
            table.Columns.Add(c3);

            DataColumn c4 = new DataColumn("窗口显示类型");//窗口显示类型
            c4.DataType = typeof(System.String);
            //c4.Caption = "窗口显示类型";
            table.Columns.Add(c4);

            DataColumn c5 = new DataColumn("窗口类型");//窗口类型
            c5.DataType = typeof(System.String);
            //c5.Caption = "窗口类型";
            table.Columns.Add(c5);

            DataColumn c6 = new DataColumn("窗口备注");//窗口备注
            c6.DataType = typeof(System.String);
            //c6.Caption = "窗口备注";
            table.Columns.Add(c6);

            DataColumn c7 = new DataColumn("窗口Tag");//窗口Tag
            c7.DataType = typeof(System.String);
            //c7.Caption = "窗口Tag";
            table.Columns.Add(c7);

            DataColumn c8 = new DataColumn("树的Dll名称");//TreeDllName
            c8.DataType = typeof(System.String);
            //c8.Caption = "树的Dll名称";
            table.Columns.Add(c8);

            DataColumn c9 = new DataColumn("TreeWinName");//TreeWinName
            c9.DataType = typeof(System.String);
            //c9.Caption = "树的功能名称";
            table.Columns.Add(c9);

            DataColumn c10 = new DataColumn("树的Tag");//TreeTag
            c10.DataType = typeof(System.String);
            //c10.Caption = "树的Tag";
            table.Columns.Add(c10);
            
            DataColumn c11 = new DataColumn("ID");//索引
            c11.DataType = typeof(System.String);
            c11.Caption = "ID";
            table.Columns.Add(c11);

            DataColumn c12 = new DataColumn("排序");//排序
            c12.DataType = typeof(System.String);
            c12.Caption = "排序";
            table.Columns.Add(c12);

            DataColumn c13 = new DataColumn("状态"); //如果为old 则窗口名称 不能更改 为new  则能修改
            c13.DataType = typeof(System.String);
            table.Columns.Add(c13);
            table.AcceptChanges();
        }
        private Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm iMaintenaceForm = null;

        private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node == this.treeView.Nodes[0])
                view.RowFilter = "";
            else
            {
                string filter = "SysCode = '" + e.Node.Tag.ToString() + "'";
                view.RowFilter = filter;
            }
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = comboBoxCellType2;
            SetCellType();
        }

        private Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager manager = new Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager();
        private void AddData()
        {
            if (this.treeView.SelectedNode == this.treeView.Nodes[0])
            {
                MessageBox.Show("请先选择系统模块！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            this.view.AllowNew = true;
            DataRowView rowView = this.view.AddNew();
            rowView["SysCode"] = this.treeView.SelectedNode.Tag.ToString();
            rowView["ID"] = manager.GetNewID();
            rowView["排序"] = "0";
            rowView["状态"] = "new";
          
            
            this.fpSpread1_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
            this.fpSpread1_Sheet1.Columns.Get(5).CellType = comboBoxCellType2;

            IsDirty = true;

        }

        private void treeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (IsDirty)
            {
                if (!ValidateValue())
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 校验数据正确性
        /// </summary>
        /// <returns></returns>
        private bool ValidateValue()
        {
            if (this.fpSpread1_Sheet1.Rows.Count > 0)
            {
                this.fpSpread1.StopCellEditing();
                for (int i = 0; i < this.fpSpread1_Sheet1.Rows.Count; i++)
                {
                    string temp = this.fpSpread1_Sheet1.GetText(i, 1).ToString();
                    if (temp == "")
                    {

                        MessageBox.Show("功能名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(temp, 50))
                    {
                        MessageBox.Show("功能名称过长");
                        return false;
                    }
                    string Gongneng = this.fpSpread1_Sheet1.GetText(i, 2).ToString();
                    if (Gongneng == "")
                    {
                        MessageBox.Show("窗口名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(Gongneng, 100))
                    {
                        MessageBox.Show("窗口名称过长");
                        return false;
                    }
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.fpSpread1_Sheet1.GetText(i, 3).ToString(), 50))
                    {
                        MessageBox.Show("程序集名称过长");
                        return false;
                    }
                    string FormShowType = fpSpread1_Sheet1.GetText(i, 4).ToString();
                  
                    if (FormShowType == "" || FormShowType == "MDI" || FormShowType == "Form" || FormShowType == "FormDialog" )
                    {

                    }
                    else
                    {
                        MessageBox.Show("显示模式 错误");
                        return false;
                    }
                    string FormType = fpSpread1_Sheet1.GetText(i, 5).ToString();
                    

                    string Mark = this.fpSpread1_Sheet1.GetText(i, 6).ToString();
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(Mark, 1000))
                    {
                        MessageBox.Show("tag过长");
                        return false;
                    }
                    string SortId = this.fpSpread1_Sheet1.GetText(i, 7).ToString();
                    if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(SortId, 6))
                    {
                        MessageBox.Show("顺序号过长");
                        return false;
                    }

                }
                return true;

            }
            else
                return true;
        }

        private bool SaveData()
        {
            if (IsDirty == false || ValidateValue() == false)
            {
                
                return false;
            }

            this.fpSpread1.StopCellEditing();
            for(int i=0;i<this.view.Count;i++)
                this.view[i].EndEdit();

            DataTable added = table.GetChanges(DataRowState.Added);
            DataTable modified = table.GetChanges(DataRowState.Modified);
            DataTable deleted = table.GetChanges(DataRowState.Deleted);
            if (added == null && deleted == null && modified == null)
            {
                IsDirty = false;
                MessageBox.Show("无变化！");
                return true;
            }
            Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager funMgr = new Neusoft.HISFC.BizLogic.Manager.SysModelFunctionManager();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(funMgr.Connection);

            bool saved = true;

            Neusoft.HISFC.Models.Admin.SysModelFunction errorFun = null;
            try
            {
                //trans.BeginTransaction();

                funMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                if (deleted != null)
                {
                    deleted.RejectChanges();
                    ArrayList entities = GetEntityFromTable(deleted);
                    if (entities != null)
                    {
                        foreach (Neusoft.HISFC.Models.Admin.SysModelFunction fun in entities)
                        {
                            if (funMgr.DeleteSysModelFunction(fun) < 0)
                            {
                                saved = false;
                                break;
                            }
                        }
                    }
                }
                if (added != null && saved)
                {
                    //added.AcceptChanges();
                    ArrayList entities = GetEntityFromTable(added);
                    if (entities != null)
                    {
                        foreach (Neusoft.HISFC.Models.Admin.SysModelFunction fun in entities)
                        {
                            if (funMgr.InsertSysModelFunction(fun) < 0)
                            {
                                errorFun = fun;

                                saved = false;
                                break;

                            }
                        }
                    }
                }
                if (modified != null && saved)
                {
                
                    ArrayList entities = GetEntityFromTable(modified);
                    if (entities != null)
                    {
                        foreach (Neusoft.HISFC.Models.Admin.SysModelFunction fun in entities)
                        {
                            if (funMgr.UpdateSysModelFunction(fun) < 0)
                            {
                                errorFun = fun;
                                saved = false;
                                break;

                            }
                        }
                    }
                }

                if (saved)
                {
                    Neusoft.FrameWork.Management.PublicTrans.Commit();
                }
            }
            catch
            {

                saved = false;
            }
            finally
            {
                if (!saved)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();

                    string error = string.Empty;

                    if (funMgr.DBErrCode == 1 && errorFun != null)
                        error = "系统模块\"" + modelCache[errorFun.SysCode].ToString() + "\"中窗口名称 \"" + errorFun.WinName + "\" 有重复！";
                    else
                        error = funMgr.Err;

                    SetCellType();
                    MessageBox.Show("数据保存失败!" + error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    table.AcceptChanges(); //因为用的是DataView ,所以先得置标志位，去除掉已经删除的行
                    foreach (DataRow row in table.Rows)
                    {
                        row["状态"] = "old";
                    }
                    table.AcceptChanges();
                    IsDirty = false;
                    SetCellType();

                }

            }
            if (saved)
            {

                MessageBox.Show("数据保存成功!" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsDirty = false;
                return true;
            }
            else
            {
                IsDirty = true;
                return false;
            }





        }

        private void DeleteData()
        {
            if (this.fpSpread1_Sheet1.Rows.Count < 1)
            {
                MessageBox.Show("没有数据可删除");
                return;
            }
            if (this.fpSpread1_Sheet1.ActiveRowIndex >= 0)
            {
                this.fpSpread1.StopCellEditing();
                this.fpSpread1_Sheet1.Rows.Remove(this.fpSpread1_Sheet1.ActiveRowIndex , 1);
                IsDirty = true;
            }
        }

        /// <summary>
        /// 添加实体给数据表
        /// </summary>
        /// <param name="changes"></param>
        /// <returns></returns>
        private ArrayList GetEntityFromTable(DataTable changes)
        {
            if (changes == null || changes.Rows.Count <= 0)
                return null;
            ArrayList entities = new ArrayList();

            foreach (DataRow row in changes.Rows)
            {
                Neusoft.HISFC.Models.Admin.SysModelFunction fun = new Neusoft.HISFC.Models.Admin.SysModelFunction();
                  fun.SysCode = row[0].ToString();
                    fun.FunName = row[1].ToString();
                    fun.WinName = row[2].ToString();
                    fun.DllName = row[3].ToString();
                    fun.FormShowType = row[4].ToString();
                    fun.FormType = row[5].ToString();
                    fun.Memo = row[6].ToString();
                    fun.Param = row[7].ToString();
                    fun.TreeControl.DllName = row[8].ToString();
                    fun.TreeControl.WinName = row[9].ToString();
                    fun.TreeControl.Param = row[10].ToString();
                    fun.ID = row[11].ToString();
                    fun.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(row[12].ToString());
                  entities.Add(fun);
            }
            return entities;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            if (IsDirty)
            {
                DataTable changes = table.GetChanges();
                if (changes == null)
                {
                    return true;
                }
                else
                {


                    DialogResult dlg = MessageBox.Show("数据已经被修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        if (SaveData())
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else if (dlg == DialogResult.Cancel)
                    {
                        return false;

                    }
                }

            }

            return true;
        }

        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 3)
            {

                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 3].Text;
                if (dllname == "") return;
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllname + ".dll");
                    Type[] type = assembly.GetTypes();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType funCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    string[] ss = new string[type.Length];
                    int i = 0;
                    foreach (Type mytype in type)
                    {
                        if (mytype.IsPublic && mytype.IsClass)
                        {
                            ss[i] = mytype.ToString();
                            i++;
                        }
                    }
                    funCellType.Editable = true;
                    funCellType.Items = ss;
                    this.fpSpread1_Sheet1.Cells[e.Row, 2].CellType = funCellType;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.Column == 8)
            {
                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 8].Text;
                if (dllname == "") return;
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllname + ".dll");
                    Type[] type = assembly.GetTypes();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType funCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    string[] ss = new string[type.Length];
                    int i = 0;
                    foreach (Type mytype in type)
                    {
                        if (mytype.IsPublic && mytype.IsClass && mytype.IsSubclassOf(typeof(System.Windows.Forms.TreeView)) )
                        {
                            ss[i] = mytype.ToString();
                            i++;
                        }
                    }
                    funCellType.Editable = true;
                    funCellType.Items = ss;
                    this.fpSpread1_Sheet1.Cells[e.Row, 9].CellType = funCellType;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            IsDirty = true;
        }

        private void SetCellType()
        {
            FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
            num.MaximumValue = 999;
            num.MinimumValue = 0;
            fpSpread1_Sheet1.Columns[4].CellType = comboBoxCellType1;
            fpSpread1_Sheet1.Columns[5].CellType = comboBoxCellType2;
            fpSpread1_Sheet1.Columns[12].CellType = num;
            for (int i = 0; i < fpSpread1_Sheet1.Rows.Count; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, 13].Text == "old")
                {
                    fpSpread1_Sheet1.Cells[i, 2].Locked = true;
                }
                else
                {
                    fpSpread1_Sheet1.Cells[i, 2].Locked = false;
                }
            }
            this.fpSpread1_Sheet1.SetColumnVisible(0, false);
            this.fpSpread1_Sheet1.SetColumnVisible(11, false);
            this.fpSpread1_Sheet1.SetColumnVisible(13, false);
        }

        private void fpSpread1_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.A.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //增加
                Add();
            }
            if (keyData.GetHashCode() == Keys.D.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //删除
                Del();
            }
            if (keyData.GetHashCode() == Keys.S.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //保存
                Save();
            }
            if (keyData.GetHashCode() == Keys.E.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //导出
                Export();
            }
            if (keyData.GetHashCode() == Keys.P.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //打印
                Print();
            }
            if (keyData.GetHashCode() == Keys.X.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //退出
                this.FindForm().Close();
            }

            return base.ProcessDialogKey(keyData);
        }


        #region IQueryControl 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            this.DeleteData();
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return this.isDirty;
            }
            set
            {
                this.isDirty = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Query()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return iMaintenaceForm;
            }
            set
            {
                iMaintenaceForm = value;
                if (iMaintenaceForm == null) return;
                iMaintenaceForm.ShowCopyButton = false;
                iMaintenaceForm.ShowCutButton = false;
                iMaintenaceForm.ShowExportButton = false;
                iMaintenaceForm.ShowImportButton = false;
                iMaintenaceForm.ShowModifyButton = false;
                iMaintenaceForm.ShowNextRowButton = false;
                iMaintenaceForm.ShowPasteButton = false;
                iMaintenaceForm.ShowPreRowButton = false;
                iMaintenaceForm.ShowPrintButton = false;
                iMaintenaceForm.ShowPrintConfigButton= false;
                iMaintenaceForm.ShowPrintPreviewButton = false;


            }
        }

        #endregion

        private void ucSysFunction_Load(object sender, EventArgs e)
        {
            this.fpSpread1.IsAutoSaveGridStatus = false;
            this.fpSpread1.IsCanCustomConfigColumn = false;
            if(iMaintenaceForm != null) iMaintenaceForm.ShowExportButton = false;
            this.fpSpread1_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(fpSpread1_Sheet1_CellChanged);
        }

        /// <summary>
        /// 双击打开窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

       

        private void mnuShow_Click_1(object sender, EventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveRowIndex < 0) return;

            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (this.fpSpread1_Sheet1.Cells[row, 5].Text == "Form" || this.fpSpread1_Sheet1.Cells[row, 5].Text == "")
            {
                Neusoft.HISFC.Models.Admin.SysMenu obj = new Neusoft.HISFC.Models.Admin.SysMenu();
                obj.ModelFuntion.DllName = this.fpSpread1_Sheet1.Cells[row, 3].Text;
                obj.ModelFuntion.WinName = this.fpSpread1_Sheet1.Cells[row, 2].Text;
                obj.MenuParm = this.fpSpread1_Sheet1.Cells[row, 7].Text;
                obj.MenuName = this.fpSpread1_Sheet1.Cells[row, 1].Text;
                obj.ModelFuntion.FormShowType = this.fpSpread1_Sheet1.Cells[row, 4].Text;
                obj.ModelFuntion.TreeControl.WinName = this.fpSpread1_Sheet1.Cells[row, 9].Text;
                obj.ModelFuntion.TreeControl.DllName = this.fpSpread1_Sheet1.Cells[row, 8].Text;
                obj.ModelFuntion.TreeControl.Param = this.fpSpread1_Sheet1.Cells[row, 10].Text;
                obj.MenuWin = this.fpSpread1_Sheet1.Cells[row, 11].Text;
                Classes.Function.ShowForm(obj);
            }
        }

        #region IMaintenanceControlable 成员


        public int Copy()
        {
            return 0;
        }

        public int Cut()
        {
            return 0;
        }

        public int Import()
        {
            return 0;
        }

        public int Init()
        {
            return 0;
        }

        public int Modify()
        {
            return 0;
        }

        public int NextRow()
        {
            return 0;
        }

        public int Paste()
        {
            return 0;
        }

        public int PreRow()
        {
            return 0;
        }

        public int PrintConfig()
        {
            return 0;
        }

        public int PrintPreview()
        {
            return 0;
        }

        #endregion

        private void 单表维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 11].Text;
            Neusoft.FrameWork.WinForms.Controls.ucMaintenanceXML m = new Neusoft.FrameWork.WinForms.Controls.ucMaintenanceXML(id);
            Neusoft.FrameWork.WinForms.Forms.frmQuery f = new Neusoft.FrameWork.WinForms.Forms.frmQuery(m);
            f.ShowDialog();
            
        }
    }
}

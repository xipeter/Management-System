using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Neusoft.HISFC.Components.Operation
{
    public partial class ucDeptWorktype : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDeptWorktype()
        {
            InitializeComponent();
            init();
        }

        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation tabMgr;

        Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        private Neusoft.HISFC.Models.Base.Employee var = null;
        private ArrayList al = new ArrayList();
        private DataSet ds = null;

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "增加", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除", "删除", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null); 
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "增加":
                    this.add(this.fpSpread1_Sheet1.ActiveRowIndex);
                    break;
                case "删除":
                    this.del(this.fpSpread2_Sheet1.ActiveRowIndex);
                    break; 
                default:
                    break;
            }
        }
        #endregion

        #endregion 

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            var = (Neusoft.HISFC.Models.Base.Employee)dataManager.Operator;
            initDept();
            this.initDataSet();
            this.initType();


        }
        /// <summary>
        /// 生成科室列表
        /// </summary>
        private void initDept()
        {
            TreeNode current = null;
            treeView1.Nodes.Clear();
            //科室类型
            ArrayList deptTypes = Neusoft.HISFC.Models.Base.DepartmentTypeEnumService.List();
            //一级为科室类型
            foreach (Neusoft.FrameWork.Models.NeuObject type in deptTypes)
            {
                TreeNode node = new TreeNode();
                node.Text = type.Name;//科室类型名称
                node.Tag = type;
                node.ImageIndex = 22;
                node.SelectedImageIndex = 22;

                treeView1.Nodes.Add(node);
                //Neusoft.HISFC.Models.Base.EnumDepartmentType t = (Neusoft.HISFC.Models.Base.EnumDepartmentType)type.ID;
                addDepts(type.ID, node, ref current);
            }
            //if(current!=null)current.Expand();
        }
        /// <summary>
        /// 添加科室类型包含的科室
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parent"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        private int addDepts(string type, TreeNode parent, ref TreeNode current)
        {
            try
            {
                
                //获取type类型科室
                ArrayList depts = deptManager.GetDeptmentByType(type);
                if (depts == null) return 0;
                //添加科室
                foreach (Neusoft.HISFC.Models.Base.Department dept in depts)
                {
                    TreeNode child = new TreeNode();
                    child.Text = dept.Name;
                    child.Tag = dept;
                    child.ImageIndex = 40;
                    child.SelectedImageIndex = 40;

                    if (dept.ID == var.Dept.ID)
                        current = parent;

                    parent.Nodes.Add(child);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取科室列表出错!" + e.Message, "提示");
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 生成排班类别列表
        /// </summary>
        private void initType()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            if (tabMgr == null) tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();

            al = tabMgr.Query(Neusoft.HISFC.BizLogic.Operation.QueryState.All);
            ds.Tables["items"].Rows.Clear();

            if (al != null)
            {
                foreach (Neusoft.HISFC.Models.Registration.WorkType obj in al)
                {
                    fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);
                    int row = this.fpSpread1_Sheet1.RowCount - 1;

                    addfp1(row, obj);
                    ds.Tables["items"].Rows.Add(new object[]
						{
							obj.ID,obj.Name,obj.SpellCode});
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="obj"></param>
        private void addfp1(int row, Neusoft.HISFC.Models.Registration.WorkType obj)
        {
            this.fpSpread1_Sheet1.Rows[row].Tag = obj;
            this.fpSpread1_Sheet1.SetValue(row, 0, obj.ID, false);
            this.fpSpread1_Sheet1.SetValue(row, 1, obj.Name, false);
            this.fpSpread1_Sheet1.SetValue(row, 2, obj.SpellCode, false);
            this.fpSpread1_Sheet1.SetValue(row, 3, obj.Sign, false);
            this.fpSpread1_Sheet1.SetValue(row, 4, obj.BeginTime.ToString("H:m:s"), false);
            this.fpSpread1_Sheet1.SetValue(row, 5, obj.EndTime.ToString("H:m:s"), false);
            this.fpSpread1_Sheet1.SetValue(row, 6, obj.PositiveDays, false);
            this.fpSpread1_Sheet1.SetValue(row, 7, obj.MinusDays, false);
            this.fpSpread1_Sheet1.SetValue(row, 8, obj.Memo, false);
        }
        /// <summary>
        /// 初始化dataset
        /// </summary>
        private void initDataSet()
        {
            ds = new DataSet();
            ds.Tables.Add("items");
            ds.Tables["items"].Columns.AddRange(new DataColumn[]
				{
					new DataColumn("ID",Type.GetType("System.String")),
					new DataColumn("Name",Type.GetType("System.String")),
					new DataColumn("Spell",Type.GetType("System.String"))
				});
            ds.Tables["items"].CaseSensitive = false;
        }
        /// <summary>
        /// 检索科常用排班类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode select = this.treeView1.SelectedNode;
            if (select == null || select.Parent == null) return;

            getDeptType((select.Tag as Neusoft.HISFC.Models.Base.Department).ID);
            this.fpSpread2_Sheet1.Tag = (select.Tag as Neusoft.HISFC.Models.Base.Department).ID;
        }
        /// <summary>
        /// 获取科常用排班类别
        /// </summary>
        /// <param name="deptID"></param>
        private void getDeptType(string deptID)
        {
            if (this.fpSpread2_Sheet1.RowCount > 0)
                this.fpSpread2_Sheet1.Rows.Remove(0, this.fpSpread2_Sheet1.RowCount);

            if (tabMgr == null) tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();
            ArrayList types = tabMgr.Query(deptID);


            if (types != null)
            {
                foreach (Neusoft.HISFC.Models.Registration.WorkType obj in types)
                {
                    this.fpSpread2_Sheet1.Rows.Add(this.fpSpread2_Sheet1.RowCount, 1);
                    int row = this.fpSpread2_Sheet1.RowCount - 1;

                    add(row, obj);
                }
            }

        }
        /// <summary>
        /// 添加倒fp
        /// </summary>
        /// <param name="row"></param>
        /// <param name="obj"></param>
        private void add(int row, Neusoft.HISFC.Models.Registration.WorkType obj)
        {
            this.fpSpread2_Sheet1.Rows[row].Tag = obj;
            this.fpSpread2_Sheet1.SetValue(row, 0, obj.ID, false);
            this.fpSpread2_Sheet1.SetValue(row, 1, obj.Name, false);
            this.fpSpread2_Sheet1.SetValue(row, 2, obj.SpellCode, false);
            this.fpSpread2_Sheet1.SetValue(row, 3, obj.BeginTime.ToString("H:m:s"), false);
            this.fpSpread2_Sheet1.SetValue(row, 4, obj.EndTime.ToString("H:m:s"), false);
            this.fpSpread2_Sheet1.SetValue(row, 5, obj.PositiveDays, false);
            this.fpSpread2_Sheet1.SetValue(row, 6, obj.MinusDays, false);
            this.fpSpread2_Sheet1.SetValue(row, 7, obj.OperID, false);
            this.fpSpread2_Sheet1.SetValue(row, 8, obj.OperDate.Date.ToString("yyyy-M-d"), false);
        }
        /// <summary>
        /// 添加一条科常用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0 || e.ColumnHeader) return;
            add(e.Row);
        }
        /// <summary>
        /// 添加一行
        /// </summary>
        private void add(int row)
        {
            if (row < 0) return;
            //判断是否已经添加,如果添加,返回
            Neusoft.HISFC.Models.Registration.WorkType type = this.fpSpread1_Sheet1.Rows[row].Tag
                as Neusoft.HISFC.Models.Registration.WorkType;
            if (this.fpSpread2_Sheet1.Tag == null || this.fpSpread2_Sheet1.Tag.ToString() == "")
            {
                MessageBox.Show("请选择科常用!", "提示");
                return;
            }

            for (int i = 0; i < this.fpSpread2_Sheet1.RowCount; i++)
            {
                if (type.ID == (this.fpSpread2_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.Registration.WorkType).ID)
                {
                    MessageBox.Show("该排班类别已经添加!", "提示");
                    return;
                }
            }
            //添加
            this.fpSpread2_Sheet1.Rows.Add(this.fpSpread2_Sheet1.RowCount, 1);
            int row1 = this.fpSpread2_Sheet1.RowCount - 1;
            type.OperID = var.ID;
            type.OperDate = DateTime.Now;

            add(row1, type);
        }
        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread2_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            del(e.Row);
        }
        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="row"></param>
        private void del(int row)
        {
            if (row < 0 || this.fpSpread2_Sheet1.RowCount == 0) return;
            if (this.fpSpread2_Sheet1.Tag == null || this.fpSpread2_Sheet1.Tag.ToString() == "") return;

            if (MessageBox.Show("是否删除该排班类型?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.No)
                return;

            //删除
            Neusoft.HISFC.Models.Registration.WorkType obj = this.fpSpread2_Sheet1.Rows[row].Tag as
                Neusoft.HISFC.Models.Registration.WorkType;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.deptManager.Connection);
            //t.BeginTransaction();

            if (tabMgr == null) tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();
            tabMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            try
            {
                if (tabMgr.Delete(this.fpSpread2_Sheet1.Tag.ToString(), obj.ID) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(tabMgr.Err, "提示");
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            this.fpSpread2_Sheet1.Rows.Remove(row, 1);

            MessageBox.Show("删除成功!", "提示");
        }
        protected override int OnSave(object sender, object neuObject)
        {
            if (this.fpSpread2_Sheet1.Tag == null || this.fpSpread2_Sheet1.Tag.ToString() == "")
            {
                MessageBox.Show("请先选择一个科室!", "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction();
            //t.BeginTransaction();
            try
            {
                if (this.tabMgr == null) this.tabMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Tabulation();
                tabMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                for (int i = 0; i < this.fpSpread2_Sheet1.RowCount; i++)
                {
                    Neusoft.HISFC.Models.Registration.WorkType obj = (Neusoft.HISFC.Models.Registration.WorkType)this.fpSpread2_Sheet1.Rows[i].Tag;
                    //先删除
                    if (tabMgr.Delete(this.fpSpread2_Sheet1.Tag.ToString(), obj.ID) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(tabMgr.Err, "提示");
                        return -1;
                    }

                    if (tabMgr.Insert(this.fpSpread2_Sheet1.Tag.ToString(), obj) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(tabMgr.Err, "提示");
                        return -1;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }

            MessageBox.Show("保存成功!", "提示");

            return base.OnSave(sender, neuObject);
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            DataView dv = new DataView(ds.Tables["items"]);
            string filter = this.txtSearch.Text.Trim();

            try
            {
                dv.RowFilter = "ID LIKE '%" + filter + "%' or Name LIKE '%" + filter + "%' or Spell LIKE '%" + filter + "%'";
            }
            catch { }
            for (int i = 0; i < dv.Count; i++)
            {
                DataRowView row = dv[i];
                foreach (Neusoft.HISFC.Models.Registration.WorkType obj in al)
                {
                    if (row["ID"].ToString() == obj.ID)
                    {
                        this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);
                        this.addfp1(this.fpSpread1_Sheet1.RowCount - 1, obj);
                        break;
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = this.fpSpread1_Sheet1.ActiveRowIndex;

                if (row <= this.fpSpread1_Sheet1.RowCount - 1)
                {
                    add(row);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                int row = this.fpSpread1_Sheet1.ActiveRowIndex;
                if (row > 0)
                {
                    row--;
                    this.fpSpread1_Sheet1.ActiveRowIndex = row;
                    //{0CD66D53-785C-4ba5-840B-885F01A31A42}
                    //this.fpSpread1_Sheet1.AddSelection(row, 0, 1, 0);
                    this.fpSpread1_Sheet1.AddSelection(row, 1, 1, 1);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                int row = this.fpSpread1_Sheet1.ActiveRowIndex;
                if (row < this.fpSpread1_Sheet1.RowCount - 1)
                {
                    row++;
                    this.fpSpread1_Sheet1.ActiveRowIndex = row;
                    //{0CD66D53-785C-4ba5-840B-885F01A31A42}
                    //this.fpSpread1_Sheet1.AddSelection(row, 0, 1, 0);
                    this.fpSpread1_Sheet1.AddSelection(row, 1, 1, 1);
                }
            }
        }
    }
}

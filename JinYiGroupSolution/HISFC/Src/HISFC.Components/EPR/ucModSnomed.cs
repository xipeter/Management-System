using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.EPR
{
    public partial class ucModSnomed : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// ucModSnomed<br></br>
        /// [功能描述: snomed编辑]<br></br>
        /// [创 建 者: 杨定钢]<br></br>
        /// [创建时间: 2007-09-18]<br></br>
        /// <修改记录
        ///		修改人=''
        ///		修改时间='yyyy-mm-dd'
        ///		修改目的=''
        ///		修改描述=''
        ///  />
        /// </summary>
        public ucModSnomed()
        {
            InitializeComponent();
        }

        #region 变量对象声明
        private Neusoft.HISFC.Models.EPR.SNOMED snomed = new Neusoft.HISFC.Models.EPR.SNOMED();
        //Neusoft.HISFC.Management.Manager.Spell mySpell = new Neusoft.HISFC.Management.Manager.Spell();
        DataSet ds;
        DataTable dataTable;

        #endregion

        /// <summary>
        /// toolBarService
        /// </summary>

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {

            return null;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            return this.Search(this.neuTreeView, this.txtSearch.Text);
        }

        #region 保存
        protected override int OnSave(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在保存....");
            Application.DoEvents();
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();

            bool save = true;
            bool insert = false;
            bool del = false;
            bool update = false;
            string strinsert = "";
            string strupdate = "";
            //遍历RowState为Added的所有行
            foreach (DataRow dr in ds.Tables["cnp_com_snopmed"].Select("", "", DataViewRowState.Added))
            {
                Neusoft.HISFC.Models.EPR.SNOMED snomedObject = new Neusoft.HISFC.Models.EPR.SNOMED();

                snomedObject.ID = dr["ID"].ToString();
                snomedObject.Name = dr["NAME"].ToString();
                snomedObject.SNOPCode = dr["SNOPCODE"].ToString();
                snomedObject.EnglishName = dr["ENGLISHNAME"].ToString();
                snomedObject.DiagnoseCode = dr["DIAGNOSECODE"].ToString();
                snomedObject.ParentCode = dr["PARENTCODE"].ToString();
                snomedObject.Memo = dr["MEMO"].ToString();
                snomedObject.SpellCode = dr["SPELLCODE"].ToString();
                snomedObject.WBCode = dr["WBCODE"].ToString();
                snomedObject.UserCode = dr["USERCODE"].ToString();
                snomedObject.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(dr["SORTID"].ToString());

                //调用业务层添加方法
                if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.InsertSNOMED(snomedObject) == -1)
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                    strinsert = dr["id"].ToString();
                    strinsert = strinsert + "\n";
                    insert = true;
                    save = false;
                }

            }
            if (insert)
            {
                MessageBox.Show("添加失败！\n" + strinsert);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }
            //遍历RowState为Deleted的所有行
            foreach (DataRow dr in ds.Tables["cnp_com_snopmed"].Select("", "", DataViewRowState.Deleted))
            {
                string id = dr[0, DataRowVersion.Original].ToString();

                //调用业务层删除方法
                if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.DelSNOPMEDByCode(id) == -1)
                {
                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                    del = true;
                    save = false;
                }

            }
            if (del)
            {
                MessageBox.Show("删除失败！");

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }

            //遍历RowState为Modified的所有行
            foreach (DataRow dr in ds.Tables["cnp_com_snopmed"].Select("", "", DataViewRowState.ModifiedCurrent))
            {
                Neusoft.HISFC.Models.EPR.SNOMED snomedObject = new Neusoft.HISFC.Models.EPR.SNOMED();

                snomedObject.ID = dr["ID"].ToString();
                snomedObject.Name = dr["NAME"].ToString();
                snomedObject.SNOPCode = dr["SNOPCODE"].ToString();
                snomedObject.EnglishName = dr["ENGLISHNAME"].ToString();
                snomedObject.DiagnoseCode = dr["DIAGNOSECODE"].ToString();
                snomedObject.ParentCode = dr["PARENTCODE"].ToString();
                snomedObject.Memo = dr["MEMO"].ToString();
                snomedObject.SpellCode = dr["SPELLCODE"].ToString();
                snomedObject.WBCode = dr["WBCODE"].ToString();
                snomedObject.UserCode = dr["USERCODE"].ToString();
                snomedObject.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(dr["SORTID"].ToString());

                //调用业务层修改方法
                if (Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateSNOMED(snomedObject) == -1)
                {

                    Neusoft.HISFC.BizProcess.Factory.Function.RollBack();
                    strupdate = dr["id"].ToString();
                    strupdate = strupdate + "\n";
                    update = true;
                    save = false;
                }
            }
            if (update)
            {
                MessageBox.Show("修改失败\n" + strupdate);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            if (save)
            {
                ds.Tables["cnp_com_snopmed"].AcceptChanges();
                Neusoft.HISFC.BizProcess.Factory.Function.Commit();
                MessageBox.Show("保存成功！");
                return 0;
            }
            else
                return -1;
        }
        #endregion


        #region 退出
        public override int Exit(object sender, object neuObject)
        {
            if (ds.HasChanges())
            {
                if (MessageBox.Show("记录已更改！需要保存么？", "保存提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        return OnSave(sender, neuObject);
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                }
            }
            return 0;
        }
        #endregion


        #region 初始化DataTable
        System.Collections.ArrayList allData = new System.Collections.ArrayList();
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        public void initialTable()
        {
            dataTable = new DataTable("cnp_com_snopmed");

            DataColumn dc1 = new DataColumn("ID");//编码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("NAME");//名字
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc2);

            DataColumn dc3 = new DataColumn("SNOPCODE");//SNOMED编码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc3);

            DataColumn dc4 = new DataColumn("ENGLISHNAME");//英文名称
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc4);

            DataColumn dc5 = new DataColumn("DIAGNOSECODE");//诊断编码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc5);

            DataColumn dc6 = new DataColumn("PARENTCODE");//父级编码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc6);

            DataColumn dc7 = new DataColumn("MEMO");//备注
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc7);

            DataColumn dc8 = new DataColumn("SPELLCODE");//拼音码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc8);

            DataColumn dc9 = new DataColumn("WBCODE");//五笔码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc9);

            DataColumn dc10 = new DataColumn("USERCODE");//自定义码
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc10);

            DataColumn dc11 = new DataColumn("SORTID");//排列顺序
            dc1.DataType = typeof(System.String);
            dataTable.Columns.Add(dc11);

            //设置DataTable主健
            //dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };

            allData  = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSNOMED();

            //foreach (Neusoft.HISFC.Models.EPR.SNOMED s in allData)
            //{
            //    dataTable.Rows.Add(
            //        new object[]{
            //        s.ID,
            //        s.Name,
            //        s.SNOPCode,
            //        s.EnglishName,
            //        s.DiagnoseCode,
            //        s.ParentCode,
            //        s.Memo,
            //        s.SpellCode,
            //        s.WBCode,
            //        s.UserCode,
            //        s.SortID});

            //}

        }
        #endregion

        #region 初始化TreeView
        public void initialTree(System.Windows.Forms.TreeView tv, System.Data.DataSet ds)
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();
            System.Windows.Forms.TreeNode tn = null;
            if (tv.Nodes.Count == 0)
            {
                tn = new System.Windows.Forms.TreeNode("SNOMED", 4, 4);
                tv.Nodes.Add(tn);
            }
            else
            {
                tn = tv.Nodes[0];
            }

            //添加子节点
            foreach (DataRow dr in ds.Tables["cnp_com_snopmed"].Rows)
            {

                TreeNode treeModual = null;
                if (string.Compare(dr["PARENTCODE"].ToString(), "root") == 0)
                {
                    foreach (TreeNode treeNode in tn.Nodes) //父亲结点
                    {
                        break;

                    }
                    if (treeModual == null)
                    {
                        treeModual = new TreeNode(dr["ID"].ToString(), 0, 1);
                        treeModual.Tag = dr["ID"].ToString();
                        tn.Nodes.Add(treeModual);
                        //添加孙子节点
                        foreach (DataRow dt in ds.Tables["cnp_com_snopmed"].Rows)
                        {

                            TreeNode treeType = null;
                            if (string.Compare(dt["PARENTCODE"].ToString(), treeModual.Text) == 0)
                            {
                                foreach (TreeNode treeNodeType in treeModual.Nodes)
                                {
                                    if (treeNodeType.Text == dr["ID"].ToString())
                                    {
                                        treeType = treeNodeType;
                                        break;
                                    }
                                }
                                if (treeType == null)
                                {
                                    treeType = new TreeNode(dr["ID"].ToString(), 0, 1);
                                    treeType.Tag = dt["ID"].ToString();
                                    treeType.Text = dt["NAME"].ToString();
                                    treeModual.Nodes.Add(treeType);
                                }
                            }
                        }
                        treeModual.Text = dr["NAME"].ToString();

                    }
                }

            }

            tv.EndUpdate();
        }
        private void CreateTree(System.Windows.Forms.TreeView tv, System.Data.DataSet ds)
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();
            TreeNode root = new TreeNode("元素");
            root.Tag = "ROOT";
            tv.Nodes.Add(root);
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            System.Collections.ArrayList alRoot = new System.Collections.ArrayList();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在读取...");
            int i = 0;
            //foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            //{
            //    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i++, ds.Tables[0].Rows.Count);
            //    Application.DoEvents();
              

            //    if (dr["ISLEAF"].ToString()=="1";
            //    {
            //        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            //        obj.ID = dr["ID"].ToString();
            //        obj.Name = dr["NAME"].ToString();
            //        obj.Memo = dr["PARENTCODE"].ToString();
            //        obj.User03 = obj.Memo;
            //        al.Add(obj);
            //    }
               
            //}
            foreach(Neusoft.HISFC.Models.EPR.SNOMED obj in allData)
            {
                if (obj.User01 == "1")
                    al.Add(obj.Clone());
            }

            i = 0;
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在设置...");
           
            foreach (Neusoft.HISFC.Models.EPR.SNOMED obj in al)
            {
                if (obj.SNOPCode.IndexOf('\\') > 0 )
                {
                    obj.User01 = obj.SNOPCode;
                }
                else
                {
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i++, al.Count);
                    Application.DoEvents();
                    obj.User01 = obj.Name;
                    obj.User03 = obj.ParentCode;
                    this.setFullPath(obj);
                    obj.SNOPCode = obj.User01;
                    Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateSNOMED(obj);
                }
            }
            i = 0;
            //获得所有叶子结点，循环添加到根上
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在添加...");
            foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(i++, al.Count);
                Application.DoEvents();
                string[] fullpath = obj.User01.ToString().Split('\\');
                string parpath = "元素";
                TreeNode nodeParent = tv.Nodes[0];
                foreach (string path in fullpath)
                {
                    parpath += "\\" + path;
                    TreeNode node = null;
                    GetNodeFromFullPath(parpath, nodeParent, ref node);
                    if (node == null)
                    {
                        node = nodeParent.Nodes.Add(path);
                    }
                    nodeParent = node;
                }
            }
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            tv.EndUpdate();

        }
        /// <summary>
        /// 把叶子的路径添加进来
        /// </summary>
        /// <param name="obj"></param>
        private void setFullPath(Neusoft.FrameWork.Models.NeuObject obj)
        {

            foreach (Neusoft.HISFC.Models.EPR.SNOMED parentDr in allData)
             {
                 if (obj.User03 == parentDr.ID && parentDr.User01 =="0") //枝才可以
                 {
                     obj.User01 = parentDr.Name + "\\" + obj.User01;

                     if (parentDr.ID != "ROOT" &&
                         parentDr.ID != parentDr.ParentCode)
                     {
                         obj.User03 = parentDr.ParentCode;
                         setFullPath(obj);
                     }
                 }
             }
        }

        private void GetNodeFromFullPath(string tag, TreeNode tv, ref TreeNode rtnNode)
        {
            if (tv.FullPath == tag)
            {
                rtnNode = tv;
                return;
            }

            foreach (TreeNode node in tv.Nodes)
            {
                if (node.FullPath == tag)
                {
                    rtnNode = node;
                    return;
                }
                if (tag.IndexOf(node.FullPath) > 0)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        GetNodeFromFullPath(tag, childNode, ref rtnNode);
                    }
                }
            }
        }
      
        #endregion

        #region TreeView MouseDown事件
        /// <summary>
        /// TreeView MouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point point = new Point(e.X, e.Y);
                TreeNode tn = this.neuTreeView.GetNodeAt(point);
                if (tn != null)
                    this.neuTreeView.SelectedNode = tn;

            }
        }
        #endregion

        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            initialTable();
            ds.Tables.Add(dataTable);
            ds.Tables["cnp_com_snopmed"].AcceptChanges();//更改挂起
            //initialTree(this.neuTreeView, ds);
            CreateTree(this.neuTreeView, ds);
            this.neuTreeView.ContextMenu = this.neuContexMenu1;

        }
        #endregion

        #region ContextMenu菜单显示
        /// <summary>
        /// ContextMenu菜单显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuContexMenu1_Popup(object sender, EventArgs e)
        {
            int selectNodeLength = this.neuTreeView.SelectedNode.FullPath.Length - this.neuTreeView.SelectedNode.FullPath.Replace("\\", "").Length;
            switch (selectNodeLength)
            {
                case 0:
                    this.AddChildmenuItem.Enabled = true;
                    this.DelmenuItem.Enabled = false;
                    this.MovemenuItem.Enabled = false;
                    this.ExtendmenuItem.Enabled = true;
                    break;
                case 1:
                    this.AddChildmenuItem.Enabled = true;
                    this.DelmenuItem.Enabled = true;
                    this.MovemenuItem.Enabled = false;
                    this.ExtendmenuItem.Enabled = true;
                    break;
                case 2:
                    this.AddChildmenuItem.Enabled = false;
                    this.DelmenuItem.Enabled = true;
                    this.MovemenuItem.Enabled = true;
                    this.ExtendmenuItem.Enabled = false;
                    break;
                default:
                    this.AddChildmenuItem.Enabled = false;
                    this.DelmenuItem.Enabled = true;
                    this.MovemenuItem.Enabled = true;
                    this.ExtendmenuItem.Enabled = false;
                    break;

            }
        }
        #endregion

        #region ContextMenu 全部展开/折叠事件
        /// <summary>
        /// 全部展开/折叠事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtendmenuItem_Click(object sender, EventArgs e)
        {
            if (this.neuTreeView.SelectedNode.IsExpanded)
            {
                this.neuTreeView.SelectedNode.Collapse();
            }
            else
            {
                this.neuTreeView.SelectedNode.Expand();
            }
        }
        #endregion

        #region ContextMenu添加子节点
        // <summary>
        // ContextMenu添加子节点
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        int ModualCount = 1;//新建子节点个数
        int TypeCount = 1;//新建孙子节点个数
        private void AddChildmenuItem_Click(object sender, EventArgs e)
        {
            string[] strPath = this.neuTreeView.SelectedNode.FullPath.Split('\\');
            int PathLength = strPath.Length;

            switch (PathLength)
            {
                case 1:
                    //得到子节点
                    string code1 = ModualCount.ToString();
                    code1 = "U" + code1.PadLeft(5, '0');
                    while (RearchIDName(code1) == -1)
                    {
                        ModualCount += 1;
                        code1 = ModualCount.ToString();
                        code1 = "U" + code1.PadLeft(5, '0');
                    }
                    TreeNode treeNodeModual = new TreeNode("子节点" + ModualCount.ToString(), 0, 1);
                    treeNodeModual.Tag = code1;
                    this.neuTreeView.SelectedNode.Nodes.Add(treeNodeModual);
                    DataRow drNew1 = ds.Tables["cnp_com_snopmed"].NewRow();
                    drNew1["ID"] = code1;
                    drNew1["PARENTCODE"] = "ROOT";
                    drNew1["NAME"] = "子节点" + ModualCount.ToString();
                    this.ds.Tables["cnp_com_snopmed"].Rows.Add(drNew1);
                    this.neuTreeView.SelectedNode = treeNodeModual;
                    ModualCount += 1;
                    break;
                case 2:
                    //得到孙子节点
                    string code2 = TypeCount.ToString();
                    TreeNode tr = this.neuTreeView.SelectedNode;
                    code2 = tr.Tag.ToString() + "U" + code2.PadLeft(5, '0');
                    while (RearchIDName(code2) == -1)
                    {
                        TypeCount += 1;
                        code2 = TypeCount.ToString();
                        code2 = tr.Tag.ToString() + "U" + code2.PadLeft(5, '0');
                    }
                    TreeNode treeNodeId = new TreeNode("孙子节点" + TypeCount.ToString(), 2, 3);
                    treeNodeId.Tag = code2;
                    this.neuTreeView.SelectedNode.Nodes.Add(treeNodeId);
                    DataRow drNew2 = ds.Tables["cnp_com_snopmed"].NewRow();
                    drNew2["ID"] = code2;
                    drNew2["PARENTCODE"] = tr.Tag.ToString();
                    drNew2["NAME"] = "孙子节点" + TypeCount.ToString();
                    this.ds.Tables["cnp_com_snopmed"].Rows.Add(drNew2);
                    this.neuTreeView.SelectedNode = treeNodeId;
                    TypeCount += 1;
                    break;
                default:
                    break;
            }

        }
        #endregion

        #region ContextMenu 删除节点
        /// <summary>
        /// ContextMenu删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelmenuItem_Click(object sender, EventArgs e)
        {
            string[] strPath = this.neuTreeView.SelectedNode.FullPath.Split('\\');
            int pathLength = strPath.Length;
            string fullPath = "";
            //删除DataRow行条件
            switch (pathLength)
            {
                case 1: break;
                case 2:
                    fullPath = "PARENTCODE='" + this.neuTreeView.SelectedNode.Tag.ToString() + "'or ID='" + this.neuTreeView.SelectedNode.Tag.ToString() + "'";
                    break;
                case 3:
                    fullPath = "ID='" + this.neuTreeView.SelectedNode.Tag.ToString() + "'";
                    break;
                default:
                    break;

            }
            DataRow[] dr = ds.Tables["cnp_com_snopmed"].Select(fullPath);
            //删除行
            foreach (DataRow dataRow in dr)
            {
                dataRow.Delete();
            }
            //删除结点
            this.neuTreeView.SelectedNode.Remove();

        }
        #endregion

        #region ContextMenu移动节点子菜单
        /// <summary>
        /// ContextMenu移动节点子菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovemenuItem_Popup(object sender, EventArgs e)
        {
            this.MovemenuItem.MenuItems.Clear();
            string[] strPath = this.neuTreeView.SelectedNode.FullPath.Split('\\');
            int pathLength = strPath.Length;
            switch (pathLength)
            {
                case 3:
                    foreach (TreeNode modualNode in this.neuTreeView.Nodes[0].Nodes)
                    {
                        if (modualNode != this.neuTreeView.SelectedNode.Parent)
                        {
                            MenuItem menuItem = this.MovemenuItem.MenuItems.Add(modualNode.Text);
                            menuItem.Tag = modualNode.Tag;
                            menuItem.Click += new EventHandler(mItem_Click);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 移动孙子节点事件
        /// <summary>
        /// 移动孙子节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string[] strPath = this.neuTreeView.SelectedNode.FullPath.Split('\\');
            int PathCount = strPath.Length;
            //修改DataTable中MODUAl
            string fullPath = "ID='" + this.neuTreeView.SelectedNode.Tag.ToString() + "'";
            DataRow[] dr = ds.Tables["cnp_com_snopmed"].Select(fullPath);
            foreach (DataRow d in dr)
            {
                d["PARENTCODE"] = menuItem.Tag.ToString();
            }
            //移动节点
            foreach (TreeNode treeNode in this.neuTreeView.Nodes[0].Nodes)
            {
                if (treeNode.Text == menuItem.Text)
                {
                    TreeNode cloneTreeNode = (TreeNode)this.neuTreeView.SelectedNode.Clone();
                    this.neuTreeView.SelectedNode.Remove();
                    treeNode.Nodes.Add(cloneTreeNode);
                    this.neuTreeView.SelectedNode = treeNode;
                    break;
                }
            }

        }
        #endregion

        private void MovemenuItem_Click(object sender, EventArgs e)
        {
            MovemenuItem_Popup(sender, e);
        }

        #region 点击节点后发生事件
        private void neuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int pathCount = this.neuTreeView.SelectedNode.FullPath.Length - this.neuTreeView.SelectedNode.FullPath.Replace("\\", "").Length;
            if (pathCount != 0)
            {
                foreach (Neusoft.HISFC.Models.EPR.SNOMED obj in allData)
                {
                    if((obj.SNOPCode !="" && obj.SNOPCode == e.Node.FullPath) || obj.Name == e.Node.Text)
                    {
                        this.txtCode.Text = obj.ID;
                        this.txtName.Text = obj.Name;
                        this.txtScode.Text = obj.SNOPCode;
                        this.txtEname.Text = obj.EnglishName;
                        this.comboBox.Text = obj.DiagnoseCode;
                        this.txtPcode.Text = obj.ParentCode;
                        this.txtMemo.Text = obj.Memo;
                        this.txtSpell.Text = obj.SpellCode;
                        this.txtWB.Text = obj.WBCode;
                        this.txtUcode.Text = obj.UserCode;
                        this.neuNumericTextBox.Text = obj.SortID.ToString();
                        break;
                    }
                }
            }
            else
            {
                this.txtCode.Text = "";
                this.txtEname.Text = "";
                this.txtMemo.Text = "";
                this.txtName.Text = "";
                this.txtPcode.Text = "";
                this.txtScode.Text = "";
                this.txtSpell.Text = "";
                this.txtUcode.Text = "";
                this.txtWB.Text = "";
                this.comboBox.Text = "";
                this.neuNumericTextBox.Text = "";
            }

            this.txtMemo.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtScode.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtEname.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtName.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtSpell.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtUcode.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.txtWB.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.comboBox.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);
            this.neuNumericTextBox.TextChanged += new EventHandler(this.txtneuTInput_TextChanged);

        }
        #endregion

        #region 更改每个textBox触发DataTable
        private void txtneuTInput_TextChanged(object sender, EventArgs e)
        {
            ModifiedDataTable();
        }
        #region 更改内容时，更改DataTable
        /// <summary>
        /// 更改内容时，更改DataTable
        /// </summary>
        void ModifiedDataTable()
        {
            DataRow[] dr = ds.Tables["cnp_com_snopmed"].Select("ID='" + this.txtCode.Text + "'");
            if (dr.Length != 0)
            {
                foreach (DataRow d in dr)
                {
                    d["ID"] = this.txtCode.Text;
                    d["ENGLISHNAME"] = this.txtEname.Text;
                    d["MEMO"] = this.txtMemo.Text;
                    d["NAME"] = this.txtName.Text;
                    this.neuTreeView.SelectedNode.Text = this.txtName.Text;
                    d["PARENTCODE"] = this.txtPcode.Text;
                    d["SNOPCODE"] = this.txtScode.Text;
                    if (this.txtSpell.Text == "" || this.txtWB.Text == "")
                    {
                        //根据名称生产拼音码和五笔码
                        Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();

                        spell = (Neusoft.HISFC.Models.Base.Spell)Neusoft.HISFC.BizProcess.Factory.Function.IntegrateManager.GetSpell(this.txtName.Text.Trim());
                        this.txtSpell.Text = spell.SpellCode;
                        this.txtWB.Text = spell.WBCode;
                    }
                    d["SPELLCODE"] = this.txtSpell.Text;
                    d["USERCODE"] = this.txtUcode.Text;
                    d["WBCODE"] = this.txtWB.Text;
                    d["DIAGNOSECODE"] = this.comboBox.Text;
                    d["SORTID"] = this.neuNumericTextBox.Text;
                }

            }
        }
        #endregion


        #endregion

        #region TreeView_BeforeSelect更改内容时发生
        private void neuTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.txtMemo.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtScode.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtEname.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtName.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtSpell.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtUcode.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.txtWB.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.comboBox.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);
            this.neuNumericTextBox.TextChanged -= new EventHandler(this.txtneuTInput_TextChanged);


        }
        #endregion

        #region 查找当前输入的ID值是否重命名
        /// <summary>
        /// 查找当前输入的ID值是否重命名
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="compareString"></param>
        /// <returns></returns>
        private int RearchIDName(string compareString)
        {
            foreach (DataRow dr in ds.Tables["cnp_com_snopmed"].Select("", "", DataViewRowState.Unchanged))
            {
                if (dr["ID"].ToString().ToLower() == compareString.ToLower())
                    return -1;
            }
            return 0;
        }
        #endregion

        #region 搜索文本回车事件
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtSearch.Text != "")
                    Search(this.neuTreeView, this.txtSearch.Text);
            }
        }
        #endregion

        #region 搜索按钮事件

        private void neuBSearch_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text != "")
                Search(this.neuTreeView, this.txtSearch.Text);
        }
        #endregion

        #region 搜索方法
        /// <summary>
        /// 搜索方法 
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="RearchText"></param>
        /// <returns></returns>
        public int Search(TreeView treeView, string RearchText)
        {
            if (treeView.Nodes.Count == 0) return -1;
            TreeNode currentNode = null;
            currentNode = treeView.Nodes[0];
            currentNode = currentNode.Nodes[0];
            TreeNode nodeModual = currentNode;
            while (true)
            {
                if (nodeModual == null) break;
                if (nodeModual.Text.ToLower().IndexOf(RearchText.ToLower()) != -1)
                {
                    treeView.SelectedNode = nodeModual;
                    return nodeModual.Index;
                }
                else
                {
                    foreach (TreeNode nodeType in nodeModual.Nodes)
                    {
                        if (nodeType.Text.ToLower().IndexOf(RearchText.ToLower()) != -1)
                        {
                            treeView.SelectedNode = nodeType;
                            return nodeType.Index;
                        }
                    }
                    nodeModual = nodeModual.NextNode;
                }

            }
            MessageBox.Show("没有找到匹配的项！");
            return -1;
        }
        #endregion


    }
}

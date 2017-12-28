using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: 用户常用文本]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2004-10-12]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucUserCommonText : UserControl
    {
        public ucUserCommonText()
        {
            InitializeComponent();

            this.treeView1.Nodes.Clear();
            nodeSign = new System.Windows.Forms.TreeNode("符号信息");
            nodeRelation = new System.Windows.Forms.TreeNode("相关信息");
            nodeWord = new System.Windows.Forms.TreeNode("字符信息");
            nodeNormal = new System.Windows.Forms.TreeNode("常用信息");

            this.treeView1.Nodes.Add(nodeSign);//0
            this.treeView1.Nodes.Add(nodeRelation);//1
            this.treeView1.Nodes.Add(nodeWord);//2
            this.treeView1.Nodes.Add(nodeNormal);//3
        }

        #region 变量
        TreeNode nodeSign = null;
        TreeNode nodeWord = null;
        TreeNode nodeRelation = null;
        TreeNode nodeNormal = null;
        #endregion

        private void ucUserCommonText_Load(object sender, EventArgs e)
        {
            try
            {
                this.RefreshList();
                this.treeView1.MouseHover += new EventHandler(treeView1_MouseHover);
                this.treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
                this.treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
                this.treeView1.MouseMove += new MouseEventHandler(treeView1_MouseMove);
                this.toolTip1.InitialDelay = 0;
                this.toolTip1.ReshowDelay = 0;
                this.toolTip1.AutomaticDelay = 0;
            }
            catch { }

        }

        Neusoft.HISFC.BizLogic.Manager.UserText manager = new Neusoft.HISFC.BizLogic.Manager.UserText();

        /// <summary>
        /// 刷新列表
        /// </summary>
        public void RefreshList()
        {
            this.nodeSign.Nodes.Clear();
            this.nodeRelation.Nodes.Clear();
            this.nodeWord.Nodes.Clear();

            //获得当前操作员工
            Neusoft.HISFC.Models.Base.Employee p = manager.Operator as Neusoft.HISFC.Models.Base.Employee;
            if (p == null) return;

            #region 获得常用符号列表
            ArrayList al = manager.GetList("SIGN", 2);//获得常用符号列表
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);
                try
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;
                }
                catch { }
                node.Tag = obj;
                this.nodeSign.Nodes.Add(node);//符号
            }
            #endregion

            #region 获得常用单词
            al = manager.GetList("WORD", 2);//获得常用单词列表
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);
                try
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;
                }
                catch { }
                node.Tag = obj;
                this.nodeWord.Nodes.Add(node);//单词
            }
            #endregion

            #region 相关信息

            if (this.myInpatientno == "")
            {
                al = manager.GetList("RELATION", 2);//获得常用相关信息列表
                if (al == null)
                {
                    MessageBox.Show(manager.Err);
                    return;
                }
                foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
                {
                    TreeNode node = new TreeNode(obj.Name);
                    try
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 2;
                    }
                    catch { }
                    node.Tag = obj;
                    this.nodeRelation.Nodes.Add(node);//相关信息
                }
            }
            else
            {
                this.SetPatient(this.myInpatientno, this.myTable, this.iSql);
            }
            #endregion


            this.treeView1.ExpandAll();
        }


        #region 患者更改

        protected string myInpatientno;
        protected string myTable;
        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="inpatientNo"></param>
        /// <param name="table"></param>
        public void SetPatient(string inpatientNo, string table, Neusoft.FrameWork.Management.Interface ISql)
        {
            Neusoft.HISFC.BizLogic.File.DataFile datafileManager = new Neusoft.HISFC.BizLogic.File.DataFile();

            this.nodeRelation.Nodes.Clear();
            this.nodeNormal.Nodes.Clear();

            myInpatientno = inpatientNo;
            myTable = table;

            ArrayList al = manager.GetList("RELATION", 2);//获得常用相关信息列表
            if (al == null)
            {
                MessageBox.Show(manager.Err);
                return;
            }
            foreach (Neusoft.HISFC.Models.Base.UserText obj in al)
            {
                TreeNode node = new TreeNode(obj.Name);
                string sName = obj.Name;

                //去掉[]
                if (sName.Substring(0, 1) == "[" && sName.Substring(sName.Length - 1) == "]")
                    sName = sName.Substring(1, sName.Length - 2);
                //获得节点数值
                string sValue = datafileManager.GetNodeValueFormDataStore(table, inpatientNo, sName);
                if (sValue == "-1") sValue = "";
                obj.Text = sValue;

                try
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 2;
                }
                catch { }
                node.Tag = obj;
                this.nodeRelation.Nodes.Add(node);//相关信息
            }

            if (ISql == null) return;
            this.iSql = ISql;
            for (int j = 0; j < ISql.Count; j++)
            {
                Neusoft.FrameWork.Models.NeuInfo obj = ISql.GetInfo(j);
                Neusoft.HISFC.Models.Base.UserText objText = new Neusoft.HISFC.Models.Base.UserText();
                objText.Name = obj.Name;
                objText.Text = obj.value;
                if (obj.showType.Trim() == "1" && obj.type == Neusoft.FrameWork.Models.NeuInfo.infoType.Temp)
                {
                    TreeNode node = new TreeNode(obj.Name);
                    try
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 2;
                    }
                    catch { }
                    node.Tag = objText;
                    this.nodeNormal.Nodes.Add(node);//常用信息
                }
            }
        }

        protected Neusoft.FrameWork.Management.Interface iSql = null;


        #endregion

        #region 其它操作事件
        private void treeView1_MouseHover(object sender, EventArgs e)
        {

        }
        protected Neusoft.HISFC.Models.Base.UserText GetSelectedObject(TreeNode node)
        {
            if (node.Tag == null) return null;
            return node.Tag as Neusoft.HISFC.Models.Base.UserText;
        }
        /// <summary>
        /// 新建立
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="RichText"></param>
        /// <returns></returns>
        public int Add(string Text, string RichText)
        {
            Neusoft.HISFC.Models.Base.UserText obj = new Neusoft.HISFC.Models.Base.UserText();
            obj.Text = Text;
            obj.RichText = RichText;
            ucUserTextControl u = new ucUserTextControl();
            u.IsShowGeneral = true;
            u.UserText = obj;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(u);
            this.RefreshList();
            return 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            Neusoft.HISFC.Models.Base.UserText obj = this.GetSelectedObject(this.treeView1.SelectedNode);
            if (obj == null) return;
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Manager.UserText m = new Neusoft.HISFC.BizLogic.Manager.UserText();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(m.Connection);
            //t.BeginTransaction();
            //m.SetTrans(t.Trans);
            int i = 0;
            i = m.Delete(obj.ID);
            if (i == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(m.Err);
            }
            else
            {
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("删除成功！");
                this.RefreshList();
            }
        }
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// 设置控件关联托拽事件
        /// </summary>
        /// <param name="c"></param>
        public void SetControl(IContainer c)
        {
            if (c == null) return;
            foreach (Component p in c.Components)
            {
                try
                {
                    ((Control)p).AllowDrop = true;
                    try
                    {
                        ((Control)p).DragEnter -= new DragEventHandler(ucUserText_DragEnter);
                        ((Control)p).DragDrop -= new DragEventHandler(ucUserText_DragDrop);
                    }
                    catch { }
                    ((Control)p).DragEnter += new DragEventHandler(ucUserText_DragEnter);
                    ((Control)p).DragDrop += new DragEventHandler(ucUserText_DragDrop);
                }
                catch { }

            }
        }
        private void ucUserText_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void ucUserText_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(System.String))) //Neusoft.HISFC.Models.Base.UserText
            {
                //Neusoft.HISFC.Models.Base.UserText obj = e.Data.GetData("Neusoft.HISFC.Models.Base.UserText") as Neusoft.HISFC.Models.Base.UserText;
                Neusoft.HISFC.Models.Base.UserText obj = new Neusoft.HISFC.Models.Base.UserText();
                string s = e.Data.GetData(DataFormats.StringFormat, true).ToString();
                obj.Text = s;
                if (s == "") return;
                try
                {
                    if (sender.GetType().ToString().IndexOf("RichTextBox") > 0)
                    {
                        ((RichTextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType().ToString().IndexOf("MultiLine") > 0)
                    {
                        ((RichTextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType() == typeof(System.Windows.Forms.TextBox))
                    {
                        ((TextBox)sender).SelectedText = obj.Text;
                    }
                    else if (sender.GetType().ToString().IndexOf("ComboBox") > 0)
                    {
                        ((ComboBox)sender).SelectedText = obj.Text;
                    }
                    else
                    {
                        try
                        {
                            ((TextBox)sender).SelectedText = obj.Text;
                        }
                        catch
                        {
                            ((Control)sender).Text = obj.Text;
                        }
                    }
                }
                catch { }
                e.Data.SetData("");
            }
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Neusoft.HISFC.Models.Base.UserText obj = this.GetSelectedObject(e.Item as TreeNode);
            if (obj == null) return;
            DoDragDrop(obj.Text, DragDropEffects.Copy);
        }



        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = this.treeView1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            TreeNode node = this.treeView1.GetNodeAt(p);
            if (node == null || node.Tag == null)
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
                this.toolTip1.Active = true;
            }
            else
            {
                this.toolTip1.SetToolTip(this.treeView1, this.GetSelectedObject(node).Text);
                this.toolTip1.Active = true;

            }
        }
        #endregion

        #region 彩蛋
        private int iLoop = 0;
        private void label1_DoubleClick(object sender, System.EventArgs e)
        {
            //if (iLoop > 10)
            //{
                Add("", "");
            //}
            //iLoop++;
        }
        #endregion

    }
}

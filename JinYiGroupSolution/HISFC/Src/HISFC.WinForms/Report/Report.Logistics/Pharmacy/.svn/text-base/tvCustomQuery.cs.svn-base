using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Report.Logistics.Pharmacy
{
    /// <summary>
    /// tvCustomQuery<br></br>
    /// [功能描述: tvCustomQuery自定义查询]<br></br>
    /// [创 建 者: zengft]<br></br>
    /// [创建时间: 2008-9-12]<br></br>
    /// <修改记录 {85997F7C-0E19-46e8-B552-2A60009747B4}
    ///		修改人='杨威' 
    ///		修改时间='2010-05-18' 
    ///		修改目的='移植加入5.0'
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class tvCustomQuery : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public tvCustomQuery()
        {
            this.Init();
            this.miEdit.Click += new EventHandler(miEdit_Click);
            this.miNewType.Click += new EventHandler(miNewType_Click);
            this.miNewDefine.Click += new EventHandler(miNewDefine_Click);
            this.miDeleteDefine.Click += new EventHandler(miDeleteDefine_Click);
        }

        public delegate void DeleteDefine();
        public event DeleteDefine DeleteDefineHandler;

        Neusoft.FrameWork.Management.DataBaseManger dbMgr = new Neusoft.FrameWork.Management.DataBaseManger();

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            string type = "All";
            if (this.Tag != null && string.IsNullOrEmpty(this.Tag.ToString()))
            {
                type = this.Tag.ToString();
            }
            string deptCode = ((Neusoft.HISFC.Models.Base.Employee)this.dbMgr.Operator).Dept.ID;
            //获取所有可用视图
            List<TreeNode> lsParentNodes = this.getObject("Local.CustomQuery.GetViewInfo", this.dbMgr.Operator.ID, type);

            this.ImageList = this.deptImageList;
            //将自定义查询按照试图分类显示
            foreach (TreeNode ParentNode in lsParentNodes)
            {
                ParentNode.ImageIndex = 0;
                ParentNode.SelectedImageIndex = 1;

                this.Nodes.Add(ParentNode);

                Neusoft.FrameWork.Models.NeuObject obj = ParentNode.Tag as Neusoft.FrameWork.Models.NeuObject;

                List<TreeNode> lsNode = this.getObject("Local.CustomQuery.GetDefineInfo", obj.ID, dbMgr.Operator.ID, deptCode);

                TreeNode typeNode = new TreeNode();
                typeNode.Tag = obj.Clone();
                string customType = obj.Name;
                foreach (TreeNode node in lsNode)
                {
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 5;

                    Neusoft.FrameWork.Models.NeuObject o = node.Tag as Neusoft.FrameWork.Models.NeuObject;

                    //和预定义的视图类型[说明]不同时，说明用户进行了归类
                    if (o.Name != obj.Name)
                    {

                        //用户归类可能有多个，结点按照类型排序后只要遇到不相同的就新增一个类型
                        if (o.Name != customType)
                        {
                            typeNode = new TreeNode();
                            customType = o.Name;

                            Neusoft.FrameWork.Models.NeuObject typeObject = obj.Clone();
                            typeObject.Name = customType;//类型赋值
                            typeNode.Tag = typeObject;

                            typeNode.Text = o.Name;
                            typeNode.ImageIndex = 2;
                            typeNode.SelectedImageIndex = 3;
                            ParentNode.Nodes.Add(typeNode);
                        }
                        typeNode.Nodes.Add(node);
                    }
                    else
                    {
                        ParentNode.Nodes.Add(node);
                    }
                }
            }
        }

        /// <summary>
        /// 获取树结点
        /// </summary>
        /// <param name="sqlIndex">sql索引</param>
        /// <param name="param">参数</param>
        /// <returns>树结点数组</returns>
        private List<TreeNode> getObject(string sqlIndex, params string[] param)
        {
            List<TreeNode> ls = new List<TreeNode>();
            string SQL = "";

            if (dbMgr.Sql.GetSql(sqlIndex, ref SQL) == -1)
            {
                this.ShowMessageBox("没有找到SQL：" + sqlIndex, "错误");
            }
            SQL = string.Format(SQL, param);
            if (dbMgr.ExecQuery(SQL) == -1)
            {
                this.ShowMessageBox("执行SQL发生错误：" + dbMgr.Err, "错误");
            }
            try
            {
                while (dbMgr.Reader.Read())
                {
                    Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                    TreeNode node = new TreeNode();
                    obj.ID = dbMgr.Reader[0].ToString();//试图名称
                    obj.Name = dbMgr.Reader[1].ToString();//自定义类型 试图说明
                    obj.Memo = dbMgr.Reader[2].ToString();//备注
                    obj.User01 = dbMgr.Reader[3].ToString();//强制条件 SQL索引
                    obj.User02 = dbMgr.Reader[4].ToString();//二级权限
                    //sql 如果是用户定义,则从界面获取
                    //如果是预定则为空
                    obj.User03 = dbMgr.Reader[5].ToString();

                    node.Tag = obj;
                    node.Text = string.IsNullOrEmpty(obj.Memo) ? obj.Name : obj.Memo;
                    //node.ImageIndex = 3;
                    //node.SelectedImageIndex = 4;

                    ls.Add(node);

                }
                dbMgr.Reader.Close();
            }
            catch (Exception ex)
            {
                this.ShowMessageBox("执行SQL发生错误：" + ex.Message, "错误");
            }
            return ls;
        }

        /// <summary>
        /// 显示MessageBox
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="caption">标题</param>
        private void ShowMessageBox(string text, string caption)
        {
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(text), Neusoft.FrameWork.Management.Language.Msg(caption));
        }

        #region 鼠标右键
        MenuItem miEdit = new MenuItem("编辑");
        MenuItem miNewType = new MenuItem("新建文件夹");
        MenuItem miNewDefine = new MenuItem("新增查询");
        MenuItem miDeleteDefine = new MenuItem("删除");

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.ContextMenu == null)
                {
                    this.ContextMenu = new ContextMenu();
                }

                //添加新的类型
                if (this.SelectedNode.Parent != null)
                {
                    //编辑
                    if (!this.ContextMenu.MenuItems.Contains(this.miEdit))
                    {
                        this.ContextMenu.MenuItems.Add(this.miEdit);
                    }
                    if (this.ContextMenu.MenuItems.Contains(this.miNewType))
                    {
                        this.ContextMenu.MenuItems.Remove(this.miNewType);
                    }
                }
                else
                {
                    //编辑
                    if (this.ContextMenu.MenuItems.Contains(this.miEdit))
                    {
                        this.ContextMenu.MenuItems.Remove(this.miEdit);
                    }

                    if (!this.ContextMenu.MenuItems.Contains(this.miNewType))
                    {
                        this.ContextMenu.MenuItems.Add(this.miNewType);
                    }
                }

                //添加新的自定义查询
                if (this.SelectedNode.ImageIndex > 3)
                {
                    if (this.ContextMenu.MenuItems.Contains(this.miNewDefine))
                    {
                        this.ContextMenu.MenuItems.Remove(this.miNewDefine);
                    }
                }
                else
                {
                    if (!this.ContextMenu.MenuItems.Contains(this.miNewDefine))
                    {
                        this.ContextMenu.MenuItems.Add(this.miNewDefine);
                    }
                }

                //删除
                if (!this.ContextMenu.MenuItems.Contains(this.miDeleteDefine))
                {
                    this.ContextMenu.MenuItems.Add(this.miDeleteDefine);
                }
            }
            base.OnMouseClick(e);
        }

        void miEdit_Click(object sender, EventArgs e)
        {
            this.LabelEdit = true;
            this.SelectedNode.BeginEdit();
        }

        void miNewType_Click(object sender, EventArgs e)
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = (this.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).Clone();
                TreeNode node = new TreeNode();
                node.Tag = obj;
                node.Text = "新建文件夹" + (this.SelectedNode.Nodes.Count + 1).ToString();
                node.ImageIndex = 2;
                node.SelectedImageIndex = 3;
                this.SelectedNode.Nodes.Add(node);
                this.SelectedNode = node;

                this.LabelEdit = true;
                node.BeginEdit();
            }
            catch
            { }
        }

        void miNewDefine_Click(object sender, EventArgs e)
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject d = (this.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).Clone();

                //保存后清空视图
                //d.ID = "";

                //类型
                d.Name = this.SelectedNode.Text;

                TreeNode node = new TreeNode();
                node.Tag = d;
                node.Text = "新建" + (this.SelectedNode.Nodes.Count + 1).ToString();
                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                this.SelectedNode.Nodes.Add(node);
                this.SelectedNode = node;

                this.LabelEdit = true;
                node.BeginEdit();
            }
            catch
            { }
        }

        void miDeleteDefine_Click(object sender, EventArgs e)
        {
            //Neusoft.FrameWork.Models.NeuObject obj = (this.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject).Clone();
            if (this.DeleteDefineHandler != null)
            {
                this.DeleteDefineHandler();
            }
        }
        #endregion
    }
}

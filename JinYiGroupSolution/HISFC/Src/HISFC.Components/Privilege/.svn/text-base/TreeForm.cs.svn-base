using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Privilege
{
    public partial class TreeForm<T> : System.Windows.Forms.Form
    {
        public TreeForm()
        {
            InitializeComponent();

            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.nTreeView1.DoubleClick += new EventHandler(nTreeView1_DoubleClick);
            this.OK.Click += new EventHandler(OK_Click);
            this.Cancel.Click += new EventHandler(Cancel_Click);
        }

        void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void nTreeView1_DoubleClick(object sender, EventArgs e)
        {
            if (!this.nTreeView1.CheckBoxes)
            {
                OK_Click(sender, e);
            }
        }

        private string _displayMember;

        /// <summary>
        /// 显示值
        /// </summary>
        public string DisplayMember
        {
            get { return _displayMember; }
            set { _displayMember = value; }
        }

        private string _dataMember;

        /// <summary>
        /// 数据值
        /// </summary>
        public string DataMember
        {
            get { return _dataMember; }
            set { _dataMember = value; }
        }

        private string _parentMember;

        /// <summary>
        /// 父级数据值
        /// </summary>
        public string ParentMember
        {
            get { return _parentMember; }
            set { _parentMember = value; }
        }

        private IList<T> _items;

        public void Add(IList<T> items)
        {
            _items = items;
        }

        private bool _multiChecked = false;
        /// <summary>
        /// 是否多选
        /// </summary>
        public bool MultiChecked
        {
            get { return _multiChecked; }
            set { _multiChecked = value; }
        }

        private ImageList _images;

        public void Show(IList<T> items, ImageList imageList,string currentId, Point point)
        {
            _items = items;
            //_images = imageList;

            //this.nTreeView1.ImageList = _images;
            this.nTreeView1.CheckBoxes = _multiChecked;

            this.AddTreeNode(currentId);

            if (!point.IsEmpty)
            {
                this.Location = point;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            this.ShowDialog();
        }

        public void Show(IList<T> items,string currentId, Point point)
        {
            //Show(items, defaultImage);
            Show(items, null,currentId, point);
        }

        public void Show(string currentId, Point point)
        {
            this.Show(_items, null, currentId, point);
        }

        private void AddTreeNode(string currentId)
        {
            foreach (T _item in _items)
            {
                if (typeof(T).GetProperty(_dataMember).GetValue(_item, null).ToString() == currentId)
                {
                    TreeNode _node = new TreeNode(typeof(T).GetProperty(_displayMember).GetValue(_item, null).ToString());
                    _node.Tag = _item;//typeof(T).GetProperty(_dataValue).GetValue(_item, null);
                   
                     this.nTreeView1.Nodes.Add(_node);                    

                    this.AddChildNode(_node, currentId);
                    _node.Expand();

                    break;
                }
            }
        }

        private void AddChildNode(TreeNode parent,string parentId)
        {
            foreach (T _item in _items)
            {
                if (typeof(T).GetProperty(_parentMember).GetValue(_item, null).ToString() == parentId)
                {
                    TreeNode _node = new TreeNode(typeof(T).GetProperty(_displayMember).GetValue(_item, null).ToString());
                    _node.Tag = _item;//typeof(T).GetProperty(_dataValue).GetValue(_item, null);

                    if (parent == null)
                    {
                        //_node.ImageIndex = 0;
                        this.nTreeView1.Nodes.Add(_node);
                    }
                    else
                    {
                        //_node.ImageIndex = 1;
                        parent.Nodes.Add(_node);
                    }

                    this.AddChildNode(_node, typeof(T).GetProperty(_dataMember).GetValue(_node.Tag,null).ToString());
                }
            }
        }

        public virtual T Search(string value)
        {
            return default(T);
        }

        public IList<T> GetSelectedNode()
        {
            IList<T> _items = new List<T>();

            if (this.nTreeView1.CheckBoxes)//多选
            {
                
            }
            else
            {
                if (this.nTreeView1.SelectedNode == null)
                {
                    return _items;
                }
                _items.Add((T)this.nTreeView1.SelectedNode.Tag);
            }

            return _items;
        }
    }
}
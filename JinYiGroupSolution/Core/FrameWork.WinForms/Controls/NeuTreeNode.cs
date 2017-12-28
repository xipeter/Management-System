using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 分别显示节点树形控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-10-25]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>    
    [System.Obsolete("应该使用NeuTreeView",false)]
    public class NeuTreeView2 : NeuTreeView
    {
    }

    public class NeuTreeNode : TreeNode
    {
        public NeuTreeNode()
        {
            TempTreeNode node = new TempTreeNode();
            this.Nodes.Add(node);
        }

        public NeuTreeNode(string text)
            : base(text)
        {
            TempTreeNode node = new TempTreeNode();
            this.Nodes.Add(node);
        }

        public NeuTreeNode(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
            TempTreeNode node = new TempTreeNode();
            this.Nodes.Add(node);
        }

        private bool isLoadedChildren;

        public bool IsLoadedChildren
        {
            get { return isLoadedChildren; }
            set
            {
                isLoadedChildren = value;
            }
        }

        internal void AfterExpand()
        {
            foreach (TreeNode childNode in this.Nodes)
            {
                if (childNode is TempTreeNode)
                {
                    this.Nodes.Remove(childNode);

                    return;
                }
            }
        }

        //internal void AfterCollapse()
        //{
        //    if(this.Nodes.Count==0)
        //    {
        //        TempTreeNode node = new TempTreeNode();
        //        this.Nodes.Add(node);
        //    }
        //}

        internal class TempTreeNode : TreeNode
        {

        }
    }


}

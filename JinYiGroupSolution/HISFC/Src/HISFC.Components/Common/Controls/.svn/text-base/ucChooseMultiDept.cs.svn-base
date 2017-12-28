using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucChooseMultiDept : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {

        public ucChooseMultiDept( )
        {
            InitializeComponent( );
            this.InitTreeView( );
        }

        public ucChooseMultiDept( IContainer container )
        {
            container.Add( this );

            InitializeComponent( );

            this.InitTreeView( );
        }

        #region 变量

        /// <summary>
        /// 科室列表
        /// </summary>
        private List<Neusoft.HISFC.Models.Base.Department> alDept = new List<Neusoft.HISFC.Models.Base.Department>();

        #endregion

        #region 属性

        /// <summary>
        /// 被选中的科室列表
        /// </summary>
        public List<Neusoft.HISFC.Models.Base.Department> SelectedDeptList
        {
            get
            {
                return alDept;
            }
            set
            {
                alDept = value;
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 初始化全院科室列表
        /// </summary>
        private void InitTreeView( )
        {
            TreeNode nodeParent = null;
            TreeNode node = null;
            string parentCode = "";
            try
            {
                //获取科室列表
                Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department( );
                ArrayList al = dept.GetDeptmentAllOrderByDeptType( );
                if( al == null )
                {
                    MessageBox.Show( dept.Err );
                    return;
                }
                foreach( Neusoft.HISFC.Models.Base.Department obj in al )
                {
                    //{9E7FB328-89B3-4f43-A417-2EC3ACFC7093}
                    //如果是废弃或者停用 则不加
                    if (obj.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid || obj.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
                    {
                        continue;
                    }
                    //添加父级节点
                    if( obj.DeptType.ID.ToString() != parentCode )
                    {
                        nodeParent = new TreeNode( );
                        nodeParent.Text = obj.DeptType.Name;
                        nodeParent.Tag = obj;
                        nodeParent.ImageIndex = 0;
                        nodeParent.SelectedImageIndex = 0;
                        this.tvDeptList.Nodes.Add( nodeParent );
                        parentCode = obj.DeptType.ID.ToString();
                    }

                    node = new TreeNode( );
                    node.Text = obj.Name;
                    node.Tag = obj;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    nodeParent.Nodes.Add( node );
                }
            }
            catch { }
        }

        /// <summary>
        /// 添加选中科室列表
        /// </summary>
        private void AddSelectedDept( )
        {
            //清空数组中的数据。
            this.alDept.Clear( );
            if( this.tvDeptList.Nodes.Count == 0 ) return;
            foreach( TreeNode node in this.tvDeptList.Nodes )
            {
                foreach( TreeNode tvNode in node.Nodes )
                {
                    //将选中的项保存到数组中
                    if( tvNode.Checked )
                    {
                        this.alDept.Add( tvNode.Tag as Neusoft.HISFC.Models.Base.Department);
                    }
                }
            }
        }

        #endregion

        #region 事件

        /// <summary>
        /// 高级查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuLinkLabel1_LinkClicked( object sender , LinkLabelLinkClickedEventArgs e )
        {
            ucTreeNodeSearch uc = new ucTreeNodeSearch( this.tvDeptList );
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "查找";
            Neusoft.FrameWork.WinForms.Classes.Function.ShowControl( uc );
        }

        /// <summary>
        /// 确认返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click( object sender , EventArgs e )
        {
            this.AddSelectedDept( );
            this.ParentForm.Close( );
        }
         /// <summary>
         ///  退出
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnCancel_Click( object sender , EventArgs e )
        {
            this.alDept.Clear( );
            this.ParentForm.Close( );
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
        }

        /// <summary>
        /// 遍历当前节点的所有子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDeptList_AfterCheck( object sender , TreeViewEventArgs e )
        {
            if( e.Node != null )
            {
                if( this.tvDeptList.CheckBoxes )
                {
                    foreach( TreeNode node in e.Node.Nodes )
                    {
                        if( node.Checked != e.Node.Checked )
                        {
                            node.Checked = e.Node.Checked;
                        }
                    }
                }
            }
        }

        #endregion
 
    }
}

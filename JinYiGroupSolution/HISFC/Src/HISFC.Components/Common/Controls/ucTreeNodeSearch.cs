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
    public partial class ucTreeNodeSearch : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tv">要查找的目标树</param>
        public ucTreeNodeSearch( TreeView tv )
        {
            InitializeComponent( );

            this.InitTreeViee( tv );
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tv">要查找的目标树</param>
        /// <param name="list">查找的列表</param>
        public ucTreeNodeSearch( TreeView tv,ArrayList list)
        {
            InitializeComponent( );
            this.InitTreeViee( tv , list );
        }

        #region 变量

        Neusoft.FrameWork.WinForms.Classes.Function fun = new Neusoft.FrameWork.WinForms.Classes.Function( );
        System.Windows.Forms.TreeView treeView = null;
        private int CurrentNode;
        
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        private int InitTreeViee( System.Windows.Forms.TreeView tv )
        {
            treeView = tv;
            treeView.HideSelection = false;
            this.comSearchText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            return 0;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="ItemList"></param>
        private int InitTreeViee( System.Windows.Forms.TreeView tv , ArrayList ItemList )
        {
            this.treeView = tv;
            treeView.HideSelection = false;
            ArrayList list = new ArrayList( );
            Neusoft.HISFC.Models.Base.Spell obj = null;
            if( ItemList == null )
            {

                foreach( TreeNode node in tv.Nodes )
                {
                    obj = new Neusoft.HISFC.Models.Base.Spell( );
                    obj.ID = node.Text;
                    obj.Name = node.Text;
                    list.Add( obj );
                }
            }
            else if( ItemList.Count == 0 )
            {
                foreach( TreeNode node in tv.Nodes )
                {
                    obj = new Neusoft.HISFC.Models.Base.Spell( );
                    obj.ID = node.Text;
                    obj.Name = node.Text;
                    list.Add( obj );
                }
            }
            else
            {
                list = ItemList;
            }
            this.comSearchText.Items.Add( list );
            return 0;
        }
        #endregion

        #region 恢复起始位置
        private void cbExact_CheckedChanged( object sender , System.EventArgs e )
        {
            //恢复从起始位置开始查
            this.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void cbUper_CheckedChanged( object sender , System.EventArgs e )
        {
            //恢复从起始位置开始查
            this.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void rbText_CheckedChanged( object sender , System.EventArgs e )
        {
            //恢复从起始位置开始查
            this.CurrentNode = 0;
            fun.LaserNode = 0;
        }

        private void rbTag_CheckedChanged( object sender , System.EventArgs e )
        {
            //恢复从起始位置开始查
            this.CurrentNode = 0;
            fun.LaserNode = 0;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 查找下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLookup_Click( object sender , System.EventArgs e )
        {
            //指示查询 名称还是tag 默认查名称
            bool TextOrTag = false;
            //查询的字符串
            string strSearch = "";
            if( this.rbTag.Checked )
            {
                TextOrTag = true;
            }
            if( comSearchText.DropDownStyle == System.Windows.Forms.ComboBoxStyle.Simple )
            {
                strSearch = comSearchText.Text;
            }
            else
            {
                #region 下拉框选择
                if( this.rbText.Checked )
                {
                    strSearch = comSearchText.Text;
                }
                else
                {
                    if( comSearchText.Tag != null )
                    {
                        strSearch = comSearchText.Tag.ToString( );
                    }
                    else
                    {
                        strSearch = "";
                    }
                }
                #endregion
            }
            this.treeView.SelectedNode = fun.FindTreeNodeByDepth( treeView.Nodes , strSearch , TextOrTag , cbExact.Checked , this.cbUper.Checked );

            if( this.CurrentNode >= treeView.GetNodeCount( true ) )
            {
                if( fun.LaserNode == 0 && treeView.SelectedNode == null )
                {
                    MessageBox.Show( "查找不到 (" + comSearchText.Text + ")" );
                }
                else if( fun.LaserNode != 0 && treeView.SelectedNode == null )
                {
                    MessageBox.Show( "查找回到起始点" );
                    this.CurrentNode = 0;
                    fun.LaserNode = 0;
                }

            }
            fun.LaserNode = this.CurrentNode;
            this.CurrentNode = 0;
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click( object sender , System.EventArgs e )
        {
            this.ParentForm.Close( );
        }

        private void comSearchText_KeyDown( object sender , System.Windows.Forms.KeyEventArgs e )
        {
            if( e.KeyData.GetHashCode( ) == Keys.Enter.GetHashCode( ) )
            {
                btnLookup_Click( new object( ) , new System.EventArgs( ) );
            }
        }
        #endregion 

    }
}

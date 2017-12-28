using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂管理药品列表]<br></br>
    /// [创 建 者: 彭真]<br></br>
    /// [创建时间: 2008-04]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class tvDrugList : Neusoft.HISFC.Components.Common.Controls.baseTreeView
    {
        public tvDrugList()
        {
            InitializeComponent();

            this.ImageList = this.groupImageList;
        }

        public tvDrugList ( IContainer container )
        {
            container.Add(this);

            InitializeComponent();

            this.ImageList = this.groupImageList;
        }
       
        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation ( );
        /// <summary>
        /// 处方成品信息
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> prescriptionList;
        /// <summary>
        /// 药品列表
        /// </summary>
        /// <param name="planState"></param>
        public void ShowDrugList( )
        {
            this.Nodes.Clear ( );
            this.prescriptionList = this.preparationManager.QueryPrescriptionList ( Neusoft.HISFC.Models.Base.EnumItemType.Drug);
            if ( this.prescriptionList == null )
            {
                MessageBox.Show ( Language.Msg ( "未正确获取成品配制处方信息 \n" + this.preparationManager.Err ) );
                return ;
            }
            if ( this.prescriptionList.Count == 0 )
            {
                this.Nodes.Add ( new System.Windows.Forms.TreeNode ( "没有药品" , 0 , 0 ) );
            }
            else
            {
                System.Windows.Forms.TreeNode parentNode= new System.Windows.Forms.TreeNode ( "药品列表" , 0 , 0 ) ;
                this.Nodes.Add ( parentNode );
                System.Windows.Forms.TreeNode drugNode = new TreeNode ( );
                foreach (Neusoft.FrameWork.Models.NeuObject info in this.prescriptionList)
                {
                    drugNode = new System.Windows.Forms.TreeNode ( info.Name+"（"+info.Memo+"）" );
                    drugNode.Tag = info;
                    drugNode.ImageIndex = 2;
                    drugNode.SelectedImageIndex = 4;
                    parentNode.Nodes.Add ( drugNode );
                }
                this.Nodes [ 0 ].ExpandAll ( );
                this.SelectedNode = this.Nodes [ 0 ];
            }
            
           
        }

       
    }
}

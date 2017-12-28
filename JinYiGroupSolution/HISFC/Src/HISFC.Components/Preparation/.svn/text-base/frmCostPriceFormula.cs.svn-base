using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PManager = Neusoft.HISFC.BizLogic.Pharmacy.Preparation;
using PObject = Neusoft.HISFC.Models.Preparation;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Preparation
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 成本价计算公式]<br></br>
    /// [创 建 者: 彭真]<br></br>
    /// [创建时间: 2008-04]<br></br>
    /// </summary>
    public partial class frmCostPriceFormula : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar
    {
        public frmCostPriceFormula ( )
        {
            InitializeComponent ( );
            this.ShowList ( );
        }
        #region 定义
       
        /// <summary>
        /// 树节点实体
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject neuObject;
        /// <summary>
        /// 树节点实体
        /// </summary>
        public Neusoft.FrameWork.Models.NeuObject NeuObject
        {
            get
            {
                neuObject = this.tvDrugList1.SelectedNode.Tag as Neusoft.FrameWork.Models.NeuObject;
                return neuObject;
            }
            set
            {
                neuObject = value;
            }
        }
        
        #endregion


        #region 方法
        /// <summary>
        /// 树列表加载
        /// </summary>
        /// <returns></returns>
        protected void ShowList ( )
        {
            this.tvDrugList1.ShowDrugList ( );

            
        }
        #endregion

        #region 事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click ( object sender , EventArgs e )
        {
            //this.ucCostPriceFormula1.OnSave ( NeuObject.ID );
        }
        /// <summary>
        /// 是节点变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDrugList1_AfterSelect ( object sender , TreeViewEventArgs e )
        {
            if ( e.Node.Level != 1 )
            {
                return;
            }

            this.ucCostPriceFormula1.ShowPrescription ( NeuObject.ID );
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click ( object sender , EventArgs e )
        {
            this.Close ( );
        }
        #endregion
        
       
    }
}
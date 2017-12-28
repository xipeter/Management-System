using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.InpatientFee.Fee
{
    /// <summary>
    /// ucNurseFee<br></br>
    /// [功能描述: 住院护士收费UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-06]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucNurseFee : ucCharge
    {
        /// <summary>
        /// 护士站收费构造函数
        /// </summary>
        public ucNurseFee()
        {
            InitializeComponent();
        }

        //#region 变量

        ///// <summary>
        ///// 加载项目类别
        ///// </summary>
        //protected Neusoft.HISFC.Components.Common.Controls.EnumShowItemType itemKind = Neusoft.HISFC.Components.Common.Controls.EnumShowItemType.Undrug;

        //#endregion

        //#region 属性

        ///// <summary>
        ///// 加载项目类别
        ///// </summary>
        //[Category("控件设置"), Description("加载的项目类别 All所有 Undrug非药品 drug药品")]
        //public Neusoft.HISFC.Components.Common.Controls.EnumShowItemType ItemKind 
        //{
        //    set 
        //    {
        //        this.itemKind = value;

        //        base.ucInpatientCharge.加载项目类别 = this.itemKind;
        //    }
        //    get 
        //    {
        //        return this.ucInpatientCharge.加载项目类别;
        //    }
        //}

        //#endregion

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            TreeView tvTemp = null;
            
            if (sender != null)
            {
                try
                {
                    tvTemp = sender as TreeView;
                }
                catch (Exception e) 
                {
                    MessageBox.Show(e.Message);

                    return null;
                }
            }
           
            tvTemp.AfterCheck  += new TreeViewEventHandler(tvTemp_AfterCheck);
           
            tvTemp.CheckBoxes = true;

            //this.tv.Click += new System.EventHandler(tv_Click);

          
            return base.OnInit(sender, neuObject, param);
        }

        /// <summary>
        ///  保存
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected override int Save()
        {
            if (base.Save() == -1) 
            {
                return -1;
            }

            this.Clear();

            return 1;
        }

        /// <summary>
        /// 清空方法
        /// </summary>
        protected override void Clear()
        {
            if (this.tv != null) 
            {
                foreach (TreeNode node in this.tv.Nodes[0].Nodes) 
                {
                    node.Checked = false;
                }
            }
            
            base.Clear();
        }

        void tvTemp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            base.patientList = this.GetSelectedTreeNodes();

            if (patientList.Count > 0)
            {
                 base.patientInfo = base.patientList[0] as Neusoft.HISFC.Models.RADT.PatientInfo;

                base.PatientInfo = base.radtIntegrate.GetPatientInfomation(base.patientInfo.ID);
            }
            else
            {
                base.PatientInfo = null;
            }
        }

        //void tv_Click(object sender, System.EventArgs e)
        //{
        //    this.tv.Nodes[0].Checked = false;
        //    if (this.tv.SelectedNode == this.tv.Nodes[0])
        //    {
        //        return;
        //    }
        //    this.tv.SelectedNode.Checked = !this.tv.SelectedNode.Checked;
        //    //e.Checked = !e.Checked;

        //    if (!this.tv.SelectedNode.Checked)
        //    {
        //        base.Clear();

        //        return ;
        //    }

        //    base.Clear();

        //    base.patientInfo = this.tv.SelectedNode.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;

        //    base.PatientInfo = base.radtIntegrate.GetPatientInfomation(base.patientInfo.ID);

        //    //return base.OnSetValue(neuObject, this.tv.SelectedNode.Checked);
        //}
        /// <summary>
        /// TreeView双击或者Selected响应事件
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            this.tv.Nodes[0].Checked = false;

            e.Checked = !e.Checked;

            if (!e.Checked) 
            {
                base.Clear();

                return -2;
            }

            base.Clear();
            
            base.patientInfo = neuObject as Neusoft.HISFC.Models.RADT.PatientInfo;

            base.PatientInfo = base.radtIntegrate.GetPatientInfomation(base.patientInfo.ID);
            
            return base.OnSetValue(neuObject, e);
        }
        
       
        /// <summary>
        /// 多选响应事件
        /// </summary>
        /// <param name="alValues"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValues(System.Collections.ArrayList alValues, object e)
        {   
            return base.OnSetValues(alValues, e);
        }
    }
}

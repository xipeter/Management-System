using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.HISFC.Models.Pharmacy;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Preparation.Prescription
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 制剂配置处方维护(基类容器)]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2008-05]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucPrescriptionContainer : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPrescriptionContainer()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 制剂管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Preparation preparationManager = new Neusoft.HISFC.BizLogic.Pharmacy.Preparation();     
     
        /// <summary>
        /// 处方成品列表信息
        /// </summary>
        private List<Neusoft.FrameWork.Models.NeuObject> prescriptionList;

        /// <summary>
        /// 当前已维护好的配制处方
        /// </summary>
        private System.Collections.Hashtable hsPrescription = new Hashtable();

        /// <summary>
        /// 当前显示的配制处方的成品编码
        /// </summary>
        private string nowProductPrescription = "";
        #endregion

        #region 接口实例处理

        /// <summary>
        /// 成品管理接口
        /// </summary>
        IPrescriptionProduct productInstance = null;

        /// <summary>
        /// 成品管理接口
        /// </summary>
        public IPrescriptionProduct ProductInstance
        {
            get
            {
                return this.productInstance;
            }
            set
            {
                this.productInstance = value;
            }
        }

        /// <summary>
        /// 原材料处方管理接口
        /// </summary>
        IPrescriptionMaterial materialInstance = null;

        /// <summary>
        /// 原材料处方管理接口
        /// </summary>
        public IPrescriptionMaterial MaterialInstance
        {
            get
            {
                return this.materialInstance;
            }
            set
            {
                this.materialInstance = value;
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加成品", "增加新制剂成品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
            toolBarService.AddToolButton("增加明细", "增加制剂成品原料明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolBarService.AddToolButton("删除成品", "删除制剂成品信息", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("删除处方", "删除制剂处方明细", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "增加成品")
            {
                this.productInstance.AddProduct();
            }
            if (e.ClickedItem.Text == "增加明细")
            {
                this.materialInstance.AddMaterial();
            }
            if (e.ClickedItem.Text == "删除成品")
            {
                this.productInstance.DeleteProduct();

                this.Clear();

                this.QueryProductList();
            }
            if (e.ClickedItem.Text == "删除处方")
            {
                this.materialInstance.DeleteMaterial();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.SavePrescription() == 1)
            {
                MessageBox.Show("保存成功");
            }

            return 1;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryProductList();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        /// <summary>
        /// 获取成品配制处方信息
        /// </summary>
        /// <returns></returns>
        protected virtual Neusoft.HISFC.Models.Base.EnumItemType GetItemType()
        {
            return Neusoft.HISFC.Models.Base.EnumItemType.Drug;
        }

        /// <summary>
        /// 获取成品配制处方信息
        /// </summary>
        /// <returns></returns>
        protected virtual int QueryProductList()
        {
            this.prescriptionList = this.preparationManager.QueryPrescriptionList(this.GetItemType());
            if (this.prescriptionList == null)
            {
                MessageBox.Show(Language.Msg("未正确获取成品配制处方信息 \n" + this.preparationManager.Err));
                return -1;
            }
            this.productInstance.Clear();

            foreach (Neusoft.FrameWork.Models.NeuObject info in this.prescriptionList)
            {
                if (this.productInstance.ShowProduct(info) == -1)
                {
                    return -1;
                }
            }

            return 1;
        }
    
        /// <summary>
        /// 保存配制处方信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        public int SavePrescription()
        {          
            List<Neusoft.HISFC.Models.Preparation.PrescriptionBase> prescriptionList = this.materialInstance.GetMaterial();
            if (prescriptionList == null)
            {
                MessageBox.Show("获取本次待保存处方明细信息失败");
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Preparation.PrescriptionBase info in prescriptionList)
            {
                info.ItemType = this.GetItemType();
            }

            if (this.preparationManager.SavePrescription(prescriptionList) == -1)
            {
                MessageBox.Show("保存制剂成品配置处方信息发生错误" + this.preparationManager.Err);

                return -1;
            }
           
            return 1;
        }

        /// <summary>
        /// 数据清屏
        /// </summary>
        /// <returns></returns>
        public int Clear()
        {
            this.productInstance.Clear();

            this.materialInstance.Clear();

            return 1;
        }

        #region 调用接口完成

        /// <summary>
        /// 获取接口实例
        /// </summary>
        /// <returns></returns>
        protected virtual int GetInterface()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载基础数据 请稍候...");
            Application.DoEvents();

            ucProduct ucP = new ucProduct();
            this.productInstance = ucP;
            ucP.Init();

            ucMaterial ucM = new ucMaterial();
            this.materialInstance = ucM;
            ucM.Init();

            this.splitContainer2.Panel1.Controls.Add(ucP);
            ucP.Dock = DockStyle.Fill;

            this.splitContainer2.Panel2.Controls.Add(ucM);
            ucM.Dock = DockStyle.Fill;

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        #endregion

        private void ucPrescription_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                if (this.GetInterface() == -1)
                {
                    return;
                }

                this.productInstance.ShowPrescriptionEvent += new EventHandler(productInstance_ShowPrescriptionEvent);

                this.QueryProductList();
            }
        }

        public void productInstance_ShowPrescriptionEvent(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject operProduct = sender as Neusoft.FrameWork.Models.NeuObject;

            this.materialInstance.ShowMaterial(operProduct);
        }

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] interfaceTypes = new Type[] { typeof(HISFC.Components.Preparation.IPrescription) };

                return interfaceTypes;
            }
        }

        #endregion
    }
}

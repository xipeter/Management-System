using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Management;

namespace Neusoft.UFC.DrugStore.Inpatient
{
    public partial class ucDrugManager : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDrugManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 住院摆药操作打印接口
        /// </summary>
        protected Neusoft.HISFC.Integrate.PharmacyInterface.IInpatientDrug IDrugManager = null;

        /// <summary>
        /// 本次操作的摆药通知信息
        /// </summary>
        private Neusoft.HISFC.Object.Pharmacy.DrugMessage nowDrugMessage = new Neusoft.HISFC.Object.Pharmacy.DrugMessage();

        /// <summary>
        /// 本次操作的配药台
        /// </summary>
        private Neusoft.HISFC.Object.Pharmacy.DrugControl drugControl = new Neusoft.HISFC.Object.Pharmacy.DrugControl();

        /// <summary>
        /// 当前科室的全部摆药台
        /// </summary>
        private ArrayList drugControlGather = null;

        /// <summary>
        /// 药房管理类
        /// </summary>
        protected Neusoft.HISFC.Management.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.Management.Pharmacy.DrugStore();

        #endregion

        #region 属性

        /// <summary>
        /// 是否显示明细
        /// </summary>
        public bool IsShowDetail
        {
            get { return this.ucDrugDetail1.Visible; }
            set
            {
                //设置是否显示明细
                this.ucDrugDetail1.Visible = value;
                this.ucDrugMessage1.Visible = !value;
                //根据显示的控件，设置接口的实现
                if (value)
                    this.IDrugManager = this.ucDrugDetail1 as Neusoft.HISFC.Integrate.PharmacyInterface.IInpatientDrug;
                else
                    this.IDrugManager = this.ucDrugMessage1 as Neusoft.HISFC.Integrate.PharmacyInterface.IInpatientDrug;
            }
        }

        /// <summary>
        /// 当前科室的全部摆药台
        /// </summary>
        public ArrayList DrugControlGather
        {
            set
            {
                this.drugControlGather = value;
            }
        }

        #endregion

        #region 工具栏按钮初始化

        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("保  存", "摆药确认 打印摆药单", 0, true, false, null);
            toolBarService.AddToolButton("全  选", "选择全部", 1, true, false, null);
            toolBarService.AddToolButton("全不选", "取消选择", 2, true, false, null);
            toolBarService.AddToolButton("刷  新", "刷新列表", 3, true, false, null);
            toolBarService.AddToolButton("摆药单", "摆药单补打 摆药核准", 4, true, false, null);
            toolBarService.AddToolButton("打  印", "补打摆药单", 3, true, false, null);
            toolBarService.AddToolButton("打印方式", "选择自动打印 还是 手工打印", 3, true, false, null);
            toolBarService.AddToolButton("刷新方式", "选择自动刷新 还是 手工刷新", 5, true, false, null);
            toolBarService.AddToolButton("台选择", "选择摆药台", 6, true, false, null);           

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (this.IDrugManager == null)
                return;

            switch (e.ClickedItem.Text)
            {
                case "保  存":
                    this.IDrugManager.Save(this.nowDrugMessage);
                    break;
                case "全  选":
                    this.IDrugManager.CheckAll();
                    break;
                case "全不选":
                    this.IDrugManager.CheckNone();
                    break;
                case "刷  新":
                    this.RefreshList();                    
                    break;
                case "摆药单":
                    break;
                case "打  印":
                    this.IDrugManager.Print();
                    break;
                case "打印方式":
                    break;
                case "刷新方式":
                    break;
                case "台选择":
                    this.ChooseControl();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
 
        }

        /// <summary>
        /// 摆药台选择
        /// </summary>
        protected virtual int ChooseControl()
        {
            string deptCode = "6711";

            //取本科室全部摆药台列表
            ArrayList al = this.drugStoreManager.QueryDrugControlList(deptCode);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("获取科室配药台列表发生错误") + this.drugStoreManager.Err);
                return -1;
            }
            this.DrugControlGather = al;
            return 1;
        }

        /// <summary>
        /// 设置配药台属性显示
        /// </summary>
        protected void SetDrugControlProperty()
        {
            if (this.drugControl.DrugAttribute.ID.ToString() == "S" || this.drugControl.DrugAttribute.ID.ToString() == "T")		//只有特殊配药台显示
            {
                this.ucDrugDetail1.IsAutoCheck = true;
            }
            else
            {
                this.ucDrugDetail1.IsAutoCheck = false;
            }
            if (this.drugControl.DrugAttribute.ID.ToString() == "R")		//退药台
            {
                this.ucDrugDetail1.IsFilterBillCode = true;
            }
            else
            {
                this.ucDrugDetail1.IsFilterBillCode = false;
            }
        }

        /// <summary>
        /// 刷新列表显示
        /// </summary>
        protected virtual void RefreshList()
        {
            this.tvDrugMessage1.ShowList(this.drugControl);
        }

        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            //清空摆药申请明细
            this.IDrugManager.Clear();

            //ArrayList al = new ArrayList();
            ////显示核准数据列表
            //switch (e.Node.ImageIndex)
            //{
            //    case 0:					//科室列表 点击显示该科室的摆药单
            //        this.DrugMessage = e.Node.Tag as neusoft.HISFC.Object.Pharmacy.DrugMessage;
            //        if (this.DrugMessage != null)
            //        {
            //            al = this.myDrugStore.GetDrugBillList(this.myDrugControl.ID, this.myDrugMessage);
            //            this.IsShowDetail = false;
            //        }
            //        break;
            //    case 1:
            //        //取科室节点中保存的摆药通知信息
            //        this.DrugMessage = e.Node.Tag as neusoft.HISFC.Object.Pharmacy.DrugMessage;
            //        if (this.DrugMessage != null)
            //        {
            //            //检索科室摆药申请明细数据
            //            al = this.myItem.GetApplyOutList(this.myDrugMessage);
            //            this.IsShowDetail = true;
            //        }
            //        break;
            //    case 2:
            //        //取患者节点的父级节点中保存的摆药通知信息
            //        this.DrugMessage = e.Node.Parent.Tag as neusoft.HISFC.Object.Pharmacy.DrugMessage;
            //        //取患者节点中保存的患者信息
            //        neusoft.neuFC.Object.neuObject obj = e.Node.Tag as neusoft.neuFC.Object.neuObject;
            //        this.DrugMessage.User01 = obj.User01;  //患者住院流水号
            //        if (this.DrugMessage != null)
            //        {
            //            //检索患者摆药申请明细数据
            //            al = this.myItem.GetApplyOutListByPatient(this.myDrugMessage);
            //            this.IsShowDetail = true;
            //        }
            //        break;
            //    default:
            //        //清空摆药申请明细
            //        //this.IsShowDetail = true;
            //        //this.myIDrugBase.Clear();
            //        MessageBox.Show("错误的摆药台");
            //        break;
            //}

            //if (al == null)
            //{
            //    MessageBox.Show(this.myItem.Err);
            //    return;
            //}
            ////显示数据
            //this.myIDrugBase.ShowData(al);

            return base.OnSetValue(neuObject, e);
        }
    }
}

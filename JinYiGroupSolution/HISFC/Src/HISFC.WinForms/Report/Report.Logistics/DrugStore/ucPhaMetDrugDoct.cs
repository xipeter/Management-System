using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Report.Logistics.DrugStore
{
    public partial class ucPhaMetDrugDoct : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaMetDrugDoct()
        {
            InitializeComponent();
        }
        #region 变量
        /// <summary>
        /// 查询范围
        /// </summary>
        private DeptZone deptZone1 = DeptZone.ALL;
        /// <summary>
        /// 药品进销存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 药品基本信息实体
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.Item itemObject = new Neusoft.HISFC.Models.Pharmacy.Item();
        /// <summary>
        /// 用于存储药品字典
        /// </summary>
        private ArrayList arrDrugList = null;
        /// <summary>
        /// 用于存储药品字典list
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> itemList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
        #endregion

        #region 属性
        /// <summary>
        /// 查询范围
        /// </summary>
        [Category("控制设置"), Description("查询范围：MZ:门诊、ZY:住院、ALL:全院")]
        public DeptZone DeptZone1
        {
            get
            {
                return deptZone1;
            }
            set
            {
                deptZone1 = value;
            }
        }
        #endregion

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string strFeelan = "全院";

            if (!string.IsNullOrEmpty(cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString()))
            {
                strFeelan = cmbFeelan.Items[cmbFeelan.SelectedIndex].ToString();
            }
            string drugName = "ALL";
            if (this.cmbDrugList.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDrugList.SelectedItem.Name))
                {
                    drugName = this.cmbDrugList.SelectedItem.Name;
                }
            }

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, strFeelan, drugName);
           
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            cmbFeelan.Items.Clear();
            cmbDrugList.Items.Clear();
            if (this.deptZone1 == DeptZone.ALL)
            {
                this.cmbFeelan.Items.Add("门诊");
                this.cmbFeelan.Items.Add("住院");
                this.cmbFeelan.Items.Add("全院");

                this.cmbFeelan.SelectedIndex = 0;
            }
            if (this.deptZone1 == DeptZone.MZ)
            {
                this.cmbFeelan.Items.Add("门诊");

                this.cmbFeelan.SelectedIndex = 0;

            }
            if (this.deptZone1 == DeptZone.ZY)
            {
                this.cmbFeelan.Items.Add("住院");

                this.cmbFeelan.SelectedIndex = 0;
            }

            arrDrugList = new ArrayList();
            itemList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            itemObject = new Neusoft.HISFC.Models.Pharmacy.Item();

            itemList = itemManager.QueryItemList();
            if (itemList != null)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Item itemObj in itemList)
                {
                    arrDrugList.Add(itemObj);
                }
                this.cmbDrugList.AddItems(arrDrugList);
            }

            this.isAcross = true;
            this.isSort = false;
        }


        /// <summary>
        /// 枚举
        /// </summary>
        public enum DeptZone
        {
            //门诊
            MZ = 0,
            //住院
            ZY = 1,
            //全院
            ALL = 2,
        }
    }
}

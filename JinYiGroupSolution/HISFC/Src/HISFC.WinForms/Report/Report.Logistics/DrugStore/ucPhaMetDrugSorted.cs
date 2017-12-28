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
    public partial class ucPhaMetDrugSorted : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaMetDrugSorted()
        {
            InitializeComponent();
        }
        #region 变量
      
        /// <summary>
        /// 部门管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant constManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        /// <summary>
        /// 药品常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        /// <summary>
        /// 药品进销存管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item phaItemManager =new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 用于存储药库科室列表
        /// </summary>
        private ArrayList deptArry = new ArrayList();
        /// <summary>
        /// 用于存储药品基本信息list
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> drugList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
        /// <summary>
        /// 用于存储药品基本信息
        /// </summary>
        private ArrayList drugArry = new ArrayList();
        /// <summary>
        /// 用于存储药品性质列表
        /// </summary>
        private ArrayList drugQulityArry = new ArrayList();
        /// <summary>
        /// 用于存储供应商列表
        /// </summary>
        private ArrayList companyArry = new ArrayList();

        private string strQuery = "(商品名拼音码 like '{0}%') or(商品名五笔码 like '{1}%') or (药品名称 like '{2}%')";
        #endregion


        #region 查询
        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string sortStr = string.Empty;
            string deptStr = "ALL";
            string deptNameStr = string.Empty;
            string companyStr = "ALL";
            string drugQualityStr = "ALL";            
            string drugStr = "ALL";
            int sortCount = 100;


            if (this.cmbSorted.Items[this.cmbSorted.SelectedIndex].ToString() != null)
            {
                sortStr = this.cmbSorted.Items[this.cmbSorted.SelectedIndex].ToString();
            }
            if (this.cmbDept.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDept.SelectedItem.Name))
                {
                    deptStr = this.cmbDept.SelectedItem.ID;
                    deptNameStr = this.cmbDept.SelectedItem.Name;
                }
            }
            if (this.cmbCompany.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbCompany.SelectedItem.ID))
                {
                    companyStr = this.cmbCompany.SelectedItem.ID;
                }
            }
            if (this.cmbDrug.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDrug.SelectedItem.ID))
                {
                    drugStr = this.cmbDrug.SelectedItem.ID;
                }
            }
            if (this.cmbDrugQulity.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDrugQulity.SelectedItem.ID))
                {
                    drugQualityStr = this.cmbDrugQulity.SelectedItem.ID;
                }
            }
            if(!string.IsNullOrEmpty(this.txtSortNum.Text))
            {
                sortCount = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtSortNum.Text);

            }
            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptStr, drugStr, companyStr, drugQualityStr,  sortCount,sortStr, this.employee.Name, deptNameStr);
            
        }

        #endregion

        #region 事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            this.init();

            this.isAcross = true;
            this.isSort = false;
        }

        /// <summary>
        /// 文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDrug_TextChanged(object sender, EventArgs e)
        {
            string drugStr = this.txtDrug.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();
            string drugSpellStr = this.txtDrug.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();
            string drugWBStr = this.txtDrug.Text.Trim().Replace(@"\", "").Replace(@"'", "").ToUpper();

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.txtDrug.Text))
            {
                //this.dwMain.SetFilter("");
                //this.dwMain.Filter();
                dv.RowFilter = "";
                return;

            }
            else
            {
                string str = string.Format(strQuery, drugSpellStr, drugWBStr, drugStr);
                //this.dwMain.SetFilter(str);
                //this.dwMain.Filter();
                dv.RowFilter = str;
               // return;
            }

        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            #region 加载科室
            this.cmbDept.Items.Clear();
            this.deptArry = new ArrayList();
            deptArry = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);//加载所有的药库科室
            if (deptArry != null)
            {
                this.cmbDept.AddItems(deptArry);
            }
            #endregion

            #region 加载供货商
            this.cmbCompany.Items.Clear();
            this.companyArry = new ArrayList();
            companyArry = phaConstManager.QueryCompany("1");//加载所有供货公司
            if (companyArry != null)
            {
                this.cmbCompany.AddItems(companyArry);
            }
            #endregion

            #region 加载药品性质
            this.cmbDrugQulity.Items.Clear();
            this.drugQulityArry = new ArrayList();
            drugQulityArry = constManager.GetAllList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            if (drugQulityArry != null)
            {
                this.cmbDrugQulity.AddItems(drugQulityArry);
            }
            #endregion

            #region 加载排序类型
            this.cmbSorted.Items.Clear();
            //this.cmbSorted.Items.Add("数量");
            //this.cmbSorted.Items.Add("购入金额");
            //this.cmbSorted.Items.Add("零售金额");
            ArrayList al = new ArrayList();
            al.Add(new Neusoft.FrameWork.Models.NeuObject("0","数量","根据数量排序"));
            al.Add(new Neusoft.FrameWork.Models.NeuObject("1", "购入金额", "根据购入金额排序"));
            al.Add(new Neusoft.FrameWork.Models.NeuObject("2", "零售金额", "根据零售金额排序"));
            this.cmbSorted.AddItems(al);

            this.cmbSorted.SelectedIndex = 0;
            #endregion

            #region 加载药品名称
            this.cmbDrug.Items.Clear();
            this.drugList.Clear();
            this.drugArry = new ArrayList();
            this.drugList = phaItemManager.QueryItemList();
            if (drugList != null)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Item itemObj in drugList)
                {
                    drugArry.Add(itemObj);
                }

                this.cmbDrug.AddItems(drugArry);
            }
            #endregion
        }


        #endregion

        private void cmbSorted_TextChanged(object sender, EventArgs e)
        {
            string filter = "{0} desc";

            DataView dv = this.dwMain.Dv;
            if (dv == null)
            {
                return;
            }
            
            
            if(!string.IsNullOrEmpty(this.cmbSorted.Items[this.cmbSorted.SelectedIndex].ToString()))            
            {
                string str = string.Format(filter, this.cmbSorted.Items[this.cmbSorted.SelectedIndex].ToString());



                dv.Sort = str;
                
                //dwMain.SetSort(str);
                //dwMain.Sort();


            }
           
        }

        



    }
}

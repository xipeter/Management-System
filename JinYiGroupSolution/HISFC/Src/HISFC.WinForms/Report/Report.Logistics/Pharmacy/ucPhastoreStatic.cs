using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Logistics.Pharmacy
{
    public partial class ucPhastoreStatic : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhastoreStatic()
        {
            InitializeComponent();
        }

        private string reportCode = string.Empty;
        private string reportName = string.Empty;

        #region 变量
        /// <summary>
        /// 科室管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant constManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
        /// <summary>
        /// 药品基本信息管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        /// <summary>
        /// 药品常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConstManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
        /// <summary>
        /// 用于存储科室列表
        /// </summary>
        private ArrayList deptArry = new ArrayList();
        /// <summary>
        /// 用于存储药库科室列表
        /// </summary>
        private ArrayList deptYKArry = new ArrayList();
        /// <summary>
        /// 用于存储药品性质列表
        /// </summary>
        private ArrayList constArry = new ArrayList();
        /// <summary>
        /// 用于存储药品基本信息
        /// </summary>
        private ArrayList drugArry = new ArrayList();
        /// <summary>
        /// 用于存储药品基本信息list
        /// </summary>
        private List<Neusoft.HISFC.Models.Pharmacy.Item> itemList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
        /// <summary>
        /// 用于存储供货公司列表
        /// </summary>
        private ArrayList companyArry = new ArrayList();
        /// <summary>
        /// 过滤字符串
        /// </summary>
        private string queryStr = "(drug_quality like '{0}%')";

        private string queryStr2 = "(药品性质 like '{0}%') or (pha_com_storage_药品名称 like '{1}%') or (供应商 like '{2}%')";    
        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            this.isAcross = true;
            this.isSort = false;

            base.OnLoad();


            this.init();

            this.neuTabControl1.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            #region 加载科室下拉框
            deptArry = new ArrayList();
            deptYKArry = new ArrayList();
            deptArry = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);
            deptYKArry = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);
            if (deptYKArry != null)
            {
                foreach (Neusoft.HISFC.Models.Base.Department deptObj in deptYKArry)
                {
                    deptArry.Add(deptYKArry);
                }
            }
            this.cmbDept.AddItems(deptArry);
            #endregion

            #region 加载药品性质
            constArry = new ArrayList();
            constArry = constManager.GetAllList(Neusoft.HISFC.Models.Base.EnumConstant.DRUGQUALITY);
            this.cmbDrugQuality.AddItems(constArry);
            #endregion

            #region 加载药品名称
            drugArry = new ArrayList();
            itemList = new List<Neusoft.HISFC.Models.Pharmacy.Item>();
            itemList = itemManager.QueryItemList();
            if (itemList != null)
            {
                foreach (Neusoft.HISFC.Models.Pharmacy.Item itemObj in itemList)
                {
                    drugArry.Add(itemObj);
                }

                this.cmbDrug.AddItems(drugArry);
            }
            #endregion

            #region 供货单位
            companyArry = new ArrayList();
            companyArry = phaConstManager.QueryCompany("1");
            if (constArry != null)
            {
                this.cmbCompany.AddItems(companyArry);
            }
            #endregion

            

        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <returns></returns>
        protected override int OnRetrieve(params object[] objects)
        {
            this.MainDWLabrary = "Report\\pharmacy.pbd;Report\\pharmacy.pbl";
            
           
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            
            if (this.neuTabControl1.SelectedTab.Text == "药品库存查询")
            {
                this.MainDWDataObject = "d_pha_valid_qry";

                //return this.dwNoConfirm.Retrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.employee.Dept.ID);
                return base.OnRetrieve(this.employee.Dept.ID);
               
            }
            if (this.neuTabControl1.SelectedTab.Text == "药品库存统计")
            {
                this.MainDWDataObject = "d_pha_storesum_static";

                return base.OnRetrieve(this.employee.Dept.ID);
            }

            return 1;
           
        }
        /// <summary>
        /// text更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_TextChanged(object sender, EventArgs e)
        {
           
            string dept = this.cmbDept.Text.Trim().ToUpper().Replace(@"\","");
            string drug = this.cmbDrug.Text.Trim().ToUpper().Replace(@"\","");
            string company = this.cmbCompany.Text.Trim().ToUpper().Replace(@"\","");
            string drugQuality = this.cmbDrugQuality.Text.Trim().ToUpper().Replace(@"\","");

            if (this.neuTabControl1.SelectedTab.Text == "药品库存查询")
            {
                if (!this.chkCompany.Checked &&  !this.chkDrug.Checked && !this.chkDrugQuality.Checked)
                {

                    this.dwNoConfirm.SetFilter("");                   
                    this.dwNoConfirm.Filter();
                  

                    return;
                }
                else if (string.IsNullOrEmpty(drug) && string.IsNullOrEmpty(company) && string.IsNullOrEmpty(drugQuality))
                {
                    this.dwNoConfirm.SetFilter("");
                    this.dwNoConfirm.Filter();

                    return;

                }
                else
                {
                    string str = string.Format(this.queryStr2, drugQuality, drug, company);                    
                    this.dwNoConfirm.SetFilter(str);
                    this.dwNoConfirm.Filter();
                }
            }
            else if (this.neuTabControl1.SelectedTab.Text == "药品库存统计")
            {
                if (!this.chkCompany.Checked &&  !this.chkDrugQuality.Checked)
                {
                    this.dwMain.SetFilter("");
                    this.dwMain.Filter();

                    return;
                }
                else if (string.IsNullOrEmpty(dept)   && string.IsNullOrEmpty(drugQuality))
                {
                    this.dwMain.SetFilter("");
                    this.dwMain.Filter();

                    return;

                }
                else
                {
                    string str = string.Format(this.queryStr, drugQuality);
                    this.dwMain.SetFilter(str);
                    this.dwMain.Filter();
                }

            }
            else
            {
                if (!this.chkCompany.Checked && !this.chkDept.Checked && !this.chkDrug.Checked && !this.chkDrugQuality.Checked)
                {

                    this.dwNoConfirm.SetFilter("");
                    this.dwNoConfirm.Filter();


                    return;
                }
                else if (string.IsNullOrEmpty(dept) && string.IsNullOrEmpty(drug) && string.IsNullOrEmpty(company) && string.IsNullOrEmpty(drugQuality))
                {
                    this.dwNoConfirm.SetFilter("");
                    this.dwNoConfirm.Filter();

                    return;

                }
                else
                {
                    string str = string.Format(this.queryStr, dept, drugQuality, drug, company);
                    this.dwNoConfirm.SetFilter(str);
                    this.dwNoConfirm.Filter();
                }
            }
        }

       

      
    }
}

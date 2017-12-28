using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.Pharmacy
{
    /// <summary>
    /// LC 门诊用药监控
    /// </summary>
    public partial class ucUseDrugMonitor : Neusoft.HISFC.Components.Pharmacy.Report.ucQueryBase
    {
        public ucUseDrugMonitor()
        {
            InitializeComponent();

            this.Init();
        }

        #region 域变量

        /// <summary>
        /// 是否可以选择药品查询
        /// </summary>
        private bool isShowDrug = false;

        /// <summary>
        /// 查询类别
        /// </summary>
        private Neusoft.HISFC.Models.Base.ServiceTypes type = Neusoft.HISFC.Models.Base.ServiceTypes.C;

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        #endregion

        #region 属性

        /// <summary>
        /// 是否可以选择药品查询
        /// </summary>
        public bool IsShowDrug
        {
            get            
            {
                return this.isShowDrug;
            }
            set
            {
                this.isShowDrug = value;
            }
        }

        /// <summary>
        /// 查询类别
        /// </summary>
        public Neusoft.HISFC.Models.Base.ServiceTypes Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        #endregion

        /// <summary>
        /// 数据初始化 
        /// </summary>
        protected void Init()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载基础查询数据 请稍候...");
            Application.DoEvents();

            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            System.Collections.ArrayList alDept = deptManager.GetDeptmentAll();
            if (alDept == null)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("加载科室列表失败");
                return;
            }
            System.Collections.ArrayList alData = new System.Collections.ArrayList();
            foreach (Neusoft.HISFC.Models.Base.Department info in alDept)
            {
                if (info.DeptType.ID.ToString() == "P" || info.DeptType.ID.ToString() == "PI")
                {
                    alData.Add(info);
                }
            }
            this.InitItemData(0, Neusoft.HISFC.Components.Pharmacy.Report.CustomItemTypeEnum.Custom, "查询药品：", alData);

            if (this.isShowDrug)
            {
                this.InitItemData(1, Neusoft.HISFC.Components.Pharmacy.Report.CustomItemTypeEnum.Drug, "", null);
                this.ckSingle.Visible = true;
            }
            else
            {
                this.ckSingle.Visible = false;
            }

            Neusoft.HISFC.BizLogic.Manager.Person personManager = new Neusoft.HISFC.BizLogic.Manager.Person();
            System.Collections.ArrayList alPerson = personManager.GetEmployeeAll();
            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPerson);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        protected override string GetSqlIndex()
        {
            if (this.type == Neusoft.HISFC.Models.Base.ServiceTypes.C)
            {
                if (this.ckSingle.Checked)
                {
                    return "DrugStore.Report.Out.UseDrugMonitor.Drug";
                }
                else
                {
                    return "DrugStore.Report.Out.UseDrugMonitor.AllDrug";
                }
            }
            else
            {
                if (this.ckSingle.Checked)
                {
                    return "DrugStore.Report.In.UseDrugMonitor.Drug";
                }
                else
                {
                    return "DrugStore.Report.In.UseDrugMonitor.AllDrug";
                }
                return null;
            }
        }

        protected override string FormatExecSql(string sql)
        {
            if (this.FirstItemData == null)
            {
                MessageBox.Show("请选择查询药房");
                return null;
            }
            if (this.ckSingle.Checked)
            {
                if (this.SecondItemData == null)
                {
                    MessageBox.Show("请选择查询药品");                    
                }
                return string.Format(sql, this.BeginDate.ToString(), this.EndDate.ToString(), this.FirstItemData,this.SecondItemData);
            }
            else
            {
                return string.Format(sql, this.BeginDate.ToString(), this.EndDate.ToString(), this.FirstItemData);
            }
        }

        protected override DataSet QueryDataSet(string sql)
        {
            DataSet ds = base.QueryDataSet(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Columns.Contains("开方医生"))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["开方医生"] = this.personHelper.GetName(dr["开方医生"].ToString());
                    }
                }
            }

            return ds;
        }

        private void ckSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckSingle.Checked)
            {
                this.cmbItem2.Enabled = true;
            }
            else
            {
                this.cmbItem2.Enabled = false;
            }
        }

    }
}

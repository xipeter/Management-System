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
    public partial class ucPhaMetDrugMonth : NeuDataWindow.Controls.ucQueryBaseForDataWindow
    {
        public ucPhaMetDrugMonth()
        {
            InitializeComponent();
        }
        #region 变量
      
        /// <summary>
        /// 部门管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 用于存储药库科室列表
        /// </summary>
        private ArrayList deptList = new ArrayList();
        /// <summary>
        /// 用于存储药库科室列表
        /// </summary>
        private ArrayList deptListYK = new ArrayList();
        /// <summary>
        /// 用于存储月结时间列
        /// </summary>
        private ArrayList dayList = new ArrayList();
        

        #endregion

    

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string deptNameStr = "全院";
            string dayStr = "ALL";

            if (this.cmbDept.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDept.SelectedItem.ID))
                {
                    deptNameStr = this.cmbDept.SelectedItem.ID;
                }
            }
            if (this.cmbDateList.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbDateList.SelectedItem.Name))
                {
                    dayStr = this.cmbDateList.SelectedItem.Name;
                }
            }

            return base.OnRetrieve(this.dtpBeginTime.Value, this.dtpEndTime.Value, deptNameStr, dayStr);            
           
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            this.cmbDept.Items.Clear();
            this.cmbDateList.Items.Clear();
            deptList = new ArrayList();
            deptListYK = new ArrayList();
            dayList = new ArrayList();
            deptList = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.P);//药房
            deptListYK = deptManager.GetDeptment(Neusoft.HISFC.Models.Base.EnumDepartmentType.PI);//药库          
  
            foreach(Neusoft.HISFC.Models.Base.Department deptObj in deptListYK)
            {
                deptList.Add(deptObj);
            }
            this.cmbDept.AddItems(deptList);            
           
            dayList = this.QueryDateList();
            if (dayList != null)
            {
                this.cmbDateList.AddItems(dayList);
                
                
            }           

            

            this.isAcross = true;
            this.isSort = false;
        }

        /// <summary>
        /// 获取已经月结的操作时间列
        /// </summary>
        /// <returns></returns>
        private ArrayList QueryDateList()
        {
            string strSql = string.Empty;

            strSql = string.Format("select distinct(to_char(t.oper_date,'yyyymmdd')) from pha_com_ms_drug t ");
           
            Neusoft.HISFC.BizLogic.Manager.Report reportManager = new Neusoft.HISFC.BizLogic.Manager.Report();
            if (reportManager.ExecQuery(strSql) == -1)
            {
                MessageBox.Show("没有找到索引!");

                return null;
            }
            ArrayList arrdayList = new ArrayList();
            string strday = string.Empty;
            Neusoft.HISFC.Models.Base.Const constObj = new Neusoft.HISFC.Models.Base.Const();
           
            try
            {
                while (reportManager.Reader.Read())
                {
                    constObj = new Neusoft.HISFC.Models.Base.Const();
                    constObj.ID = reportManager.Reader[0].ToString();
                    constObj.Name = reportManager.Reader[0].ToString();

                    arrdayList.Add(constObj);

                }

                reportManager.Reader.Close();

                return arrdayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                if (!reportManager.Reader.IsClosed)
                {
                    reportManager.Reader.Close();
                }

                return null;
            }
        }

        
    }
}

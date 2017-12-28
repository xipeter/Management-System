using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.Report.Finance.FinIpb
{
    public partial class ucFinIpbDeptFeeNum : NeuDataWindow.Controls.ucQueryBaseForDataWindow 
    {
        public ucFinIpbDeptFeeNum()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 统计大类管理层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeStatMger = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();
        #endregion

        protected override int OnRetrieve(params object[] objects)
        {
            if (base.GetQueryTime() == -1)
            {
                return -1;
            }
            string reportCode = string.Empty;
            string feeStatName = "ALL";

            if (this.cmbReport.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbReport.SelectedItem.ID))
                {
                    reportCode = this.cmbReport.SelectedItem.ID;
                }
            }
            if(this.cmbFeeState.SelectedItem != null)
            {
                if(!string.IsNullOrEmpty(this.cmbFeeState.SelectedItem.Name))
                {
                    feeStatName = this.cmbFeeState.SelectedItem.Name;
                }
            }
            
            return base.OnRetrieve(this.dtpBeginTime.Value,this.dtpEndTime.Value,reportCode,feeStatName);
            
        }

        protected override void OnLoad(EventArgs e)
        {
            this.isAcross = true;
            this.isSort = false;

            base.OnLoad(e);

            ArrayList reportList = new ArrayList();
            ArrayList feeStatList = new ArrayList();


            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            reportList = consManager.GetAllList("FEECODESTAT");
            this.cmbReport.AddItems(reportList);//加载统计大类表
            this.cmbReport.SelectedIndex = 0;//默认选中第一个



            this.setFeeState(this.cmbReport.SelectedItem.ID);
            //feeStatList = feeStatManager.QueryFeeCodeStatByReportCode(this.cmbReport.SelectedItem.ID);//根据统计类型查询统计大类
            //this.cmbFeeState.AddItems(feeStatList);//加载统计大类

        }
        /// <summary>
        /// 查询统计大类
        /// </summary>
        /// <param name="report_code">统计类型编码</param>
        /// <returns></returns>
        //private ArrayList GetFeeStatByRepotCode(string report_code)
        //{
        //    string strSql = string.Empty;
        //    strSql = string.Format("select distinct (f.fee_stat_name)  from fin_com_feecodestat f where f.report_code ={0} ",report_code);

        //    Neusoft.HISFC.BizLogic.Manager.Report reportManager = new Neusoft.HISFC.BizLogic.Manager.Report();
        //    if (reportManager.ExecQuery(strSql) == -1)
        //    {
        //        MessageBox.Show("查找统计大类出错!");

        //        return null;
        //    }
        //    ArrayList arrList = new ArrayList();   
        //    Neusoft.HISFC.Models.Base.Const constObj = new Neusoft.HISFC.Models.Base.Const();
        
        //    try
        //    {
        //        while (reportManager.Reader.Read())
        //        {
        //            constObj = new Neusoft.HISFC.Models.Base.Const();
        //            constObj.Name = reportManager.Reader[0].ToString();

                 

        //            arrList.Add(constObj);

        //        }

        //        reportManager.Reader.Close();

        //        return arrList;
        //    }
        //    catch (Exception ex)
        //    {
        //        reportManager.Err = ex.Message;

        //        if (!reportManager.Reader.IsClosed)
        //        {
        //            reportManager.Reader.Close();
        //        }

        //        return null;
        //    }

        //}


        #region 
        /// <summary>
        /// 设置统计大类
        /// </summary>
        /// <param name="reportCode">统计类型编码</param>
        private void setFeeState(string reportCode)
        {
            ArrayList feeStateList = new ArrayList();
            this.cmbFeeState.Items.Clear();
            feeStateList = feeCodeStatMger.QueryFeeCodeStatByReportCode(reportCode);

            ArrayList arryFeeStat = new ArrayList();
            Hashtable feeStatHash = new Hashtable();
            foreach (Neusoft.HISFC.Models.Fee.FeeCodeStat feeStatObj in feeStateList)
            {
                if (!feeStatHash.ContainsKey(feeStatObj.StatCate.ID))//将统计大类编码作为哈希表主键
                {
                    feeStatHash.Add(feeStatObj.StatCate.ID, feeStatObj.StatCate.Name);
                    arryFeeStat.Add(feeStatObj);//将不重复的统计大类实体添加到ArrayList中
                }
            }

            ArrayList feeCodeStatArry = new ArrayList();
            Neusoft.HISFC.Models.Base.Const constObj = new Neusoft.HISFC.Models.Base.Const();
           

            foreach (Neusoft.HISFC.Models.Fee.FeeCodeStat feeStatObj in arryFeeStat)
            {
                constObj = new Neusoft.HISFC.Models.Base.Const();
                constObj.ID =  feeStatObj.StatCate.ID;
                constObj.Name = feeStatObj.StatCate.Name;
                feeCodeStatArry.Add(constObj);
            }
            this.cmbFeeState.AddItems(feeCodeStatArry);//加载统计大类

        }
        #endregion


        /// <summary>
        /// 统计大类表现则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList feeStatArry = new ArrayList();
            ArrayList feeCodeStatArry = new ArrayList();
            
            if (this.cmbReport.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(this.cmbReport.SelectedItem.ID))
                {
                    //feeStatArry = feeCodeStatMger.QueryFeeCodeStatByReportCode(this.cmbReport.SelectedItem.ID);//根据统计类型查询统计大类
                    this.setFeeState(this.cmbReport.SelectedItem.ID);//根据统计类型查询统计大类
                }
            }
            //if (feeStatArry != null)
            //{
            //    this.setFeeState(feeStatArry);
            //    //Neusoft.HISFC.Models.Base.Const constObj = new Neusoft.HISFC.Models.Base.Const();
            //    //foreach (Neusoft.HISFC.Models.Fee.FeeCodeStat feeStatObj in feeStatArry)
            //    //{
            //    //    constObj.ID = feeStatObj.StatCate.ID;
            //    //    constObj.Name = feeStatObj.StatCate.Name;

            //    //    feeCodeStatArry.Add(constObj);
 
            //    //}
            //}
        }

    }
}

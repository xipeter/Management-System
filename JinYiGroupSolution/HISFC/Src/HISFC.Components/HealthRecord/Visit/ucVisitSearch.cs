using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.HealthRecord.EnumServer;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.Visit
{
    /// <summary>
    /// [功能描述: 随访记录查询]<br></br>
    /// [创建者:   金鹤]<br></br>
    /// [创建时间: 2009-09-27]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucVisitSearch : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucVisitSearch()
        {
            InitializeComponent();
           
        }

        #region 变量

        //定义变量
        Neusoft.HISFC.BizLogic.Manager.Constant con = new Neusoft.HISFC.BizLogic.Manager.Constant();

        //定义全局变量 DataView  DataSet 用来过滤数据
        private DataView dvICD = new DataView();
        private DataView dvOutPatientInfo = new DataView();

        private DataSet ds = new DataSet();
        DataSet dsOPI = new DataSet();

        //Visit业务层
        private Neusoft.HISFC.BizLogic.HealthRecord.Visit.Visit myICD = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.Visit();

        //全局变量，存储加载的类型 ICD10 ICD9 手术ICD 信息
        private ICDTypes type;

        //随访记录业务类
        Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitRecord visitRecordManager 
            = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.VisitRecord();

        //随访基本信息操作类
        Neusoft.HISFC.BizLogic.HealthRecord.Visit.LinkWay linkWayManager
            = new Neusoft.HISFC.BizLogic.HealthRecord.Visit.LinkWay();

        #endregion

        #region 工具栏事件

        public override int Export(object sender, object neuObject)
        {
            Export();
            return base.Export(sender, neuObject);
        }

        #endregion

        #region 事件

        private void ucVisitSearch_Load(object sender, EventArgs e)
        {
            #region 加载选择框

            //随访方式
            this.cmbLinkType.AddItems(con.GetList("CASE06"));
            //一般情况
            cmbCircs.AddItems(con.GetList("CASE07"));

            //随访结果
            cmbResult.AddItems(con.GetList("CASE14"));

            #endregion

            if (this.Tag == null)
            {
                return;
            }
            if (this.Tag.ToString() == "ICD10")
            {
                type = ICDTypes.ICD10;
            }
            else if (this.Tag.ToString() == "ICD9")
            {
                type = ICDTypes.ICD9;
            }
            else //if (this.Tag.ToString() == "ICDOperation")
            {
                type = ICDTypes.ICDOperation;
            }

            LoadInfo();

            LoadOutPatientInfo();

            tvIcdList.AfterSelect += tv_AfterSelect;
        }


        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(tvIcdList.SelectedNode.Index!=-1)
            {
                if (tvIcdList.SelectedNode.Parent==null)
                {
                    LoadOutPatientInfo();
                }
                else
                {
                    QueryOPInfoByIcd(tvIcdList.SelectedNode.Text.Trim());
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string filter = GetFilterStr();
            if (!string.IsNullOrEmpty(filter))
            {
                this.dvOutPatientInfo.RowFilter = GetFilterStr();
            }
            else
            {
                LoadOutPatientInfo();
            }
            SetFPStyle();
        }

        private void fpVisitInfo_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //当前选择的随访患者病历号
            string cardNo = fpVisitInfo_Sheet1.Cells[e.Row, 1].Text.Trim();

            string patientNo = fpVisitInfo_Sheet1.Cells[e.Row, 0].Text.Trim();

            if (!string.IsNullOrEmpty(cardNo) || !string.IsNullOrEmpty(patientNo))
            {
                GetLinkWay(patientNo, cardNo);
            }
           
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加载ICD数据
        /// </summary>
        private void LoadInfo()
        {
            ds.Tables.Clear();
            try
            {
                //如果是none 直接返回 
                if (ICDTypes.None == type)
                {
                    return;
                }
                //等待窗口
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();

                myICD.QueryVisitICD(type, ref ds); //查询 
                if (ds.Tables.Count == 1)
                {
                    //DataColumn[] keys = new DataColumn[] { ds.Tables[0].Columns["sequence_no"] }; //z设置主键 
                    //ds.Tables[0].PrimaryKey = keys;

                    this.dvICD = new DataView(ds.Tables[0]);
                }

                LoadICDTree(dvICD);
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 加载出院患者随访信息
        /// </summary>
        private void LoadOutPatientInfo()
        {
            dsOPI.Tables.Clear();
            try
            {
                //等待窗口
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();

                visitRecordManager.OutPatientQuery(ref dsOPI); //查询 
                if (dsOPI.Tables.Count == 1)
                {
                    //DataColumn[] keys = new DataColumn[] { ds.Tables[0].Columns["sequence_no"] }; //z设置主键 
                    //ds.Tables[0].PrimaryKey = keys;

                    this.dvOutPatientInfo = new DataView(dsOPI.Tables[0]);
                    this.fpVisitInfo.DataSource = dvOutPatientInfo;
                    SetFPStyle();
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        /// <summary>
        /// 按选择的ICD范围查询出院患者信息
        /// </summary>
        /// <param name="icdRange">ICD范围</param>
        private void QueryOPInfoByIcd(string icdRange)
        {
            dsOPI.Tables.Clear();
            try
            {
                //等待窗口
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();

                visitRecordManager.OutPatientQueryByICD(ref dsOPI, icdRange); //查询 
                if (dsOPI.Tables.Count == 1)
                {
                    //DataColumn[] keys = new DataColumn[] { ds.Tables[0].Columns["sequence_no"] }; //z设置主键 
                    //ds.Tables[0].PrimaryKey = keys;

                    this.dvOutPatientInfo = new DataView(dsOPI.Tables[0]);
                    this.fpVisitInfo.DataSource = dvOutPatientInfo;
                    SetFPStyle();
                }
                else
                {
                    this.fpVisitInfo.DataSource = null;
                }

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载随访ICD范围树
        /// </summary>
        /// <param name="dv"></param>
        private void LoadICDTree(DataView dv)
        {
            tvIcdList.ImageList = this.tv.ImageList;
            this.tvIcdList.Nodes.Clear();
            System.Windows.Forms.TreeNode parentNode = new System.Windows.Forms.TreeNode("病种范围", 0, 0);
            this.tvIcdList.Nodes.Add(parentNode);

            DataTable dt = dv.ToTable(true, "ICDRANGE");//合并重复范围

            foreach (DataRow dr in dt.Rows)
            {
                parentNode.Nodes.Add(dr["ICDRANGE"].ToString());
            }
            this.tvIcdList.ExpandAll();
        }

        /// <summary>
        /// 获取过滤字符串
        /// </summary>
        /// <returns>成功返回:过滤字符串 ; 失败返回:null</returns>
        private string GetFilterStr()
        {
            string filter = string.Empty;

            if (chkState.Checked)
            {
                if (cmbState.SelectedIndex > -1)
                {
                    switch (cmbState.Text.Trim())
                    {
                        case "待随访":
                            filter = "(CARD_NO is not null or PATIENT_NO is not null) and 随访时间 is null ";
                            break;
                        case "不随访":
                            filter = "CARD_NO is  null and PATIENT_NO is null and 随访时间 is null ";
                            break;
                        case "已随访":
                            filter = "  随访时间 is not null  ";
                            break;
                    }
                }
            }
            if (chkLinkType.Checked && cmbLinkType.SelectedIndex > -1)
            {
                filter += "and 随访方式='" + cmbLinkType.Text.Trim() + "' ";
            }
            if (chkResult.Checked && cmbResult.SelectedIndex > -1)
            {
                filter += "and 随访结果='" + cmbResult.Text.Trim() + "' ";
            }
            if (chkCircs.Checked && cmbCircs.SelectedIndex > -1)
            {
                filter += "and 一般情况='" + cmbCircs.Text.Trim() + "' ";
            }

            if (chkTime.Checked && dtpBegin.Value <= dtpEnd.Value)
            {
                filter += "and 随访时间>='"+dtpBegin.Value.ToShortDateString()
                    +"' and 随访时间<='"+dtpEnd.Value.ToShortDateString()+"' ";
            }


            if (filter.Length >= 3)
            {
                if (filter.Substring(0, 3) == "and")
                {
                    filter = filter.Substring(4);
                }
            }



            return filter;
        }

        /// <summary>
        /// 设置患者信息列表格式
        /// </summary>
        private void SetFPStyle()
        {
            fpVisitInfo_Sheet1.Columns.Get(0).Width = 70;
            fpVisitInfo_Sheet1.Columns.Get(1).Width = 70;
            fpVisitInfo_Sheet1.Columns.Get(2).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(3).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(4).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(5).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(6).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(7).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(8).Width = 80;
            fpVisitInfo_Sheet1.Columns.Get(9).Width = 80;
            fpVisitInfo_Sheet1.Columns.Get(10).Width = 80;
            fpVisitInfo_Sheet1.Columns.Get(11).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(12).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(13).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(14).Width = 60;
            fpVisitInfo_Sheet1.Columns.Get(15).Width = 60;

            foreach(FarPoint.Win.Spread.Column fpColumn in fpVisitInfo_Sheet1.Columns)
            {
                fpColumn.HorizontalAlignment =FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
        }

        /// <summary>
        /// 导出数据 
        /// </summary>
        private void Export()
        {
            bool ret = false;
            //导出数据
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel|.xls";
                saveFileDialog1.FileName = "";

                saveFileDialog1.Title = "导出数据";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    //以Excel 的形式导出数据
                    ret = fpVisitInfo.SaveExcel(saveFileDialog1.FileName);
                    if (ret)
                    {
                        MessageBox.Show("导出成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                //出错了
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 根据住院号或病历号查询患者联系人列表
        /// </summary>
        /// <param name="patientNo">住院号</param>
        /// <param name="cardNo">病历号</param>
        private void GetLinkWay(string patientNo, string cardNo)
        {
            fpLinkWay_Sheet1.RowCount = 0;

            ArrayList list = new ArrayList();

            list = linkWayManager.QueryLinkWay(patientNo, cardNo);
            if (list == null)
            {
                return;
            }
            fpLinkWay_Sheet1.Rows.Count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay linkWayObj
                    = list[i] as Neusoft.HISFC.Models.HealthRecord.Visit.LinkWay;


                if (linkWayObj != null)
                {
                    this.fpLinkWay_Sheet1.Cells[i, 0].Text = linkWayObj.Name;//联系人
                    this.fpLinkWay_Sheet1.Cells[i, 1].Text = linkWayObj.Memo;//与患者关系
                    this.fpLinkWay_Sheet1.Cells[i, 2].Text = linkWayObj.Phone;//联系电话
                    this.fpLinkWay_Sheet1.Cells[i, 3].Text = linkWayObj.User01;//电话状态
                    this.fpLinkWay_Sheet1.Cells[i, 4].Text = linkWayObj.Address;//联系地址
                    this.fpLinkWay_Sheet1.Cells[i, 5].Text = linkWayObj.Mail;//电子邮件

                    this.fpLinkWay_Sheet1.Rows[i].Tag = linkWayObj;

                }
            }

        }

        #endregion
    }
}

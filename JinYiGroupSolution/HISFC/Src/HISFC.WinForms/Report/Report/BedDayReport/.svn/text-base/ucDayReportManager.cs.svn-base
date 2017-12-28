using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;
using System.Collections;


namespace Neusoft.WinForms.Report.BedDayReport
{
    public partial class ucDayReportManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDayReportManager()
        {
            InitializeComponent();
         
        }

        private Neusoft.HISFC.BizLogic.RADT.InpatientDayReport dayReportManager = new Neusoft.HISFC.BizLogic.RADT.InpatientDayReport();

        private ZZLocal.HISFC.BizLogic.RADT.InpatientDayReport zzReportManager = new ZZLocal.HISFC.BizLogic.RADT.InpatientDayReport();

        #region {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能-
        //        int CommitNum = 0;
        //        string strSQL = @"select count(*) num  
        //                            from met_cas_inpatientdayreport a  
        //                            where a.date_stat = to_date('{0}', 'yyyy-mm-dd HH24:mi:ss') 
        //                            and a.dept_code = '{1}'
        //                            and  a.mark = '1'";

        #region 工具栏
        ///// <summary>
        ///// toolBarService
        ///// </summary>
        //protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();


        ///// <summary>
        ///// 增加ToolBar控件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="neuObject"></param>
        ///// <param name="param"></param>
        ///// <returns></returns>
        //protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        //{
        //    toolBarService.AddToolButton("提交", "提交后不能在修改数据", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);

        //    return this.toolBarService;
        //}
        ///// <summary>
        ///// 自定义按钮的事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    if (e.ClickedItem.Text == "提交")
        //    {
        //        if (this.deptZone1 == DeptZone.ALL)
        //        {
        //            MessageBox.Show("此操作由护士站完成");
        //            return;
        //        }
        //        dataCommit();
        //    }

        //    base.ToolStrip_ItemClicked(sender, e);
        //}

        //protected int dataCommit()
        //{
        //    Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
        //    this.dayReportManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
        //    //if (CommitNum > 0)
        //    //{
        //    //    MessageBox.Show("已经提交，不能再次提交！");
        //    //    return -1;
        //    //}
        //    for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
        //    {
        //        Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info = this.GetDayReport(i);

        //        info.Memo = "1";

        //        int param = this.dayReportManager.UpdateInpatientDayReport(info);
        //        if (param == -1)
        //        {
        //            Neusoft.FrameWork.Management.PublicTrans.RollBack();
        //            MessageBox.Show(Language.Msg("床位日报更新失败"));
        //            return -1;
        //        }
        //        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMemo].Text = "已提交";
        //        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMemo].Tag = "1";
        //    }

        //    Neusoft.FrameWork.Management.PublicTrans.Commit();
        //    MessageBox.Show("提交成功");
        //    return 1;
        //}

        #endregion

        /// <summary>
        /// 查询科室条件限制
        /// </summary>
        private DeptZone deptZone1 = DeptZone.ALL;
        private string deptID = "AAAA";


        /// <summary>
        /// 枚举
        /// </summary>
        public enum DeptZone
        {
            //全院
            ALL = 0,
            //科室
            DEPT = 1,

        }

        #region 属性
        [Category("控制设置"), Description("查询范围：DEPT:科室、ALL:全院")]
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


        //private int GetDayReportCount(DateTime reportDate,string deptID)
        //{
        //    //string deptID = Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID.ToString();
        //    string count = this.dayReportManager.ExecSqlReturnOne(string.Format(this.strSQL, reportDate.ToString("yyyy-MM-dd HH:mm:ss"), deptID));
        //    if (string.IsNullOrEmpty(count) || count == "-1")
        //    {
        //        // this.dayReportManager.Err;
        //        return -1;
        //    }
        //    return Neusoft.FrameWork.Function.NConvert.ToInt32(count);
        //}

        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        private Neusoft.HISFC.BizProcess.Integrate.Manager interManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能

        protected DateTime BeginDate
        {
            get
            {
                return NConvert.ToDateTime(this.dtpBeginDate.Text);
            }
        }

        protected DateTime EndDate
        {
            get
            {
                return NConvert.ToDateTime(this.dtpEndDate.Text);
            }
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryDayReport();

            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            #region {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            //if (CommitNum > 0 && this.deptZone1 == DeptZone.DEPT)
            //{
            //    MessageBox.Show("已经提交，不能更改数据！");
            //    return -1;
            //}
            #endregion {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能

            this.SaveDayReport();

            this.QueryDayReport();

            return base.OnSave(sender, neuObject);
        }

        /// <summary>
        /// 获取床位日报
        /// </summary>
        protected void QueryDayReport()
        {
            #region {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            /// <summary>
            /// 查询科室条件限制
            /// </summary>
            if (this.deptZone1 == DeptZone.ALL) //全部科室
            {
                deptID = this.cmbDept.Tag.ToString();
                //neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStarandNum].Locked = false;
                neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBeginNum].Locked = false;
            }
            else //单科室
            {


                deptID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID.ToString();
                neuSpread1_Sheet1.Columns[(int)ColumnSet.ColStarandNum].Locked = true;
                neuSpread1_Sheet1.Columns[(int)ColumnSet.ColBeginNum].Locked = true;


            }

            ArrayList alStatList = zzReportManager.GetInpatientDayReportList(this.BeginDate, this.EndDate, deptID);

            //ArrayList alStatList = dayReportManager.GetInpatientDayReportList(this.StatDate);





            #endregion{32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能

            if (alStatList == null)
            {
                MessageBox.Show("获取床位日报统计汇总信息发生错误");
                return;
            }

            this.neuSpread1_Sheet1.Rows.Count = 0;
            Hashtable hsDayReportDept = new Hashtable();

            foreach (Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info in alStatList)
            {
                //CommitNum = GetDayReportCount(this.StatDate,info.ID);
                //if (CommitNum > 0)
                //{
                //    info.Memo = "1";
                //}else
                //{
                //    info.Memo = "0";
                //}
                if (!hsDayReportDept.ContainsKey(info.ID))
                {
                    hsDayReportDept.Add(info.ID, null);
                }

                this.neuSpread1_Sheet1.Rows.Add(0, 1);

                this.AddDataToFp(0, info);
            }

            ArrayList al = this.QueryDeptStat();
            if (al != null)
            {
                foreach (Neusoft.FrameWork.Models.NeuObject tempStat in al)
                {
                    if (!hsDayReportDept.ContainsKey(tempStat.ID))
                    {
                        Neusoft.HISFC.Models.HealthRecord.InpatientDayReport temp = new Neusoft.HISFC.Models.HealthRecord.InpatientDayReport();
                        temp.ID = tempStat.ID;
                        temp.Name = tempStat.Name;
                        temp.DateStat = this.BeginDate;

                        this.neuSpread1_Sheet1.Rows.Add(0, 1);

                        this.AddDataToFp(0, temp);
                    }
                }
            }

            this.SetSum(alStatList);
        }

        private void SetSum(ArrayList al)
        {
            int bedSum = 0;
            int beginSum = 0;
            int inSum = 0;
            int transferInSum = 0;
            int transferOutSum = 0;
            int outSum = 0;
            int endSum = 0;
            foreach (Neusoft.HISFC.Models.HealthRecord.InpatientDayReport item in al)
            {
                bedSum += item.BedStand;
                beginSum += item.BeginningNum;
                inSum += item.InNormal;
                transferInSum += item.InTransfer;
                transferOutSum += item.OutTransfer;
                outSum += item.OutNormal;
                endSum += item.EndNum;
            }
            string sumInfo = "编制内床位合计：{0} 期初合计：{1} 入院合计：{2} 转入合计：{3} 转出合计：{4} 出院合计：{5} 期末合计：{6}";
            this.lblSum.Text = string.Format(sumInfo, bedSum, beginSum, inSum, transferInSum, transferOutSum, outSum, endSum);
        }

        private int AddDataToFp(int rowIndex, Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info)
        {
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColDateStat].Text = info.DateStat.ToString("yyyy-MM-dd");
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColDeptCode].Text = info.ID;
            //{32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColDeptName].Text = this.deptHelper.GetName(info.ID);

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text = info.BedStand.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColAddNum].Text = info.BedAdd.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColFreeNum].Text = info.BedFree.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Text = info.BeginningNum.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColInNum].Text = info.InNormal.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferIn].Text = info.InTransfer.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferOut].Text = info.OutTransfer.ToString();
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutNu].Text = info.OutNormal.ToString();
            //死亡数
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutDeathNu].Text = info.User01.ToString();
            
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColEndNum].Text = info.EndNum.ToString();

            //if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text == "0")
            //    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text == "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColAddNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColAddNum].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColFreeNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColFreeNum].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColInNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColInNum].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferIn].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferIn].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferOut].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferOut].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutNu].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutNu].Text = "";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutDeathNu].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutDeathNu].Text = " ";
            if (this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColEndNum].Text == "0")
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColEndNum].Text = "";

          
            #region {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            //if (info.Memo == "1")
            //{
            //    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text = "已提交";
            //    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Tag = "1";
            //}
            //else
            //{

            //this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Locked = false;
            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].BackColor = Color.White;
            this.neuSpread1_Sheet1.Rows[rowIndex].Locked = false;
            if (info.Memo == "0" || string.IsNullOrEmpty(info.Memo))
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text = "FALSE";
                if (this.deptZone1 == DeptZone.ALL)
                {
                    //暂时护士站未提交病案室也可以修改
                    //this.neuSpread1_Sheet1.Rows[rowIndex].Locked = true;
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].BackColor = Color.LightGray;
                }
            }
            else if (info.Memo == "1")
            {
                if (this.deptZone1 == DeptZone.ALL)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text = "FALSE";
                }
                else
                {
                    this.neuSpread1_Sheet1.Rows[rowIndex].Locked = true;
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].BackColor = Color.LightGray;
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text = "TRUE";
                }
            }
            else if (info.Memo == "2")
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text = "TRUE";

                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].BackColor = Color.LightPink;
                if (this.deptZone1 == DeptZone.DEPT)
                {
                    this.neuSpread1_Sheet1.Rows[rowIndex].Locked = true;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Locked = true;
                }
            }

            #region {5DC8523F-9E2A-413a-B77E-C62165F30C05}  上线初期病案室允许修改期初数

            if (this.deptZone1 == DeptZone.DEPT) //单科室
            {
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Locked = true;
                this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Locked = true;

            }
          

            //this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Locked = true;
             #endregion {5DC8523F-9E2A-413a-B77E-C62165F30C05}

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColEndNum].Locked = true;

            this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Tag = info.Memo;
            //}
            #endregion {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能

            this.neuSpread1_Sheet1.Rows[rowIndex].Tag = info;

            return 1;
        }

        /// <summary>
        /// 获取病案科室结构
        /// </summary>
        protected ArrayList QueryDeptStat()
        {
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager myDeptManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            //ArrayList al = myDeptManager.LoadDepartmentStat("72");
            ArrayList al = myDeptManager.LoadDepartmentStatAndByNodeKind("72", "1");
            //Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager myDepartmentStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            //ArrayList al = myDepartmentStatManager.LoadDepartmentStatAndByNodeKind("72", "0");

            if (al == null)
            {
                MessageBox.Show("获取病案科室结构失败");
                return null;
            }

            return al;
        }

        /// <summary>
        /// 日报明细查询
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int QueryDayReportDetail(DateTime dtDate, string deptCode, string nurseCell)
        {
            ArrayList alDetail = this.dayReportManager.GetDayReportDetailList(this.BeginDate, this.BeginDate.AddDays(1), deptCode, nurseCell);
            if (alDetail != null)
            {

            }

            return 1;
        }

        /// <summary>
        /// 由Fp内获取日报数据
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.HealthRecord.InpatientDayReport GetDayReport(int rowIndex)
        {
            Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info = this.neuSpread1_Sheet1.Rows[rowIndex].Tag as Neusoft.HISFC.Models.HealthRecord.InpatientDayReport;
            if (info == null)
            {
                return null;
            }

            info.ID = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColDeptCode].Text;
            info.Name = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColDeptName].Text;
            info.BedStand = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColStarandNum].Text);
            info.BedAdd = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColAddNum].Text);
            info.BedFree = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColFreeNum].Text);
            info.BeginningNum = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColBeginNum].Text);
            info.InNormal = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColInNum].Text);
            info.InTransfer = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferIn].Text);
            info.OutTransfer = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColTransferOut].Text);
            info.OutNormal = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutNu].Text);

            info.User01 = (NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColOutDeathNu].Text)).ToString();
            
            info.EndNum = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColEndNum].Text);

            //{32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            //info.Memo = this.neuSpread1_Sheet1.Cells[rowIndex,(int)ColumnSet.ColMemo].Tag.ToString();
            bool isConfirm = NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Text);
            if (isConfirm)
            {
                if (this.deptZone1 == DeptZone.ALL)
                {
                    info.Memo = "2";
                }
                else
                {
                    info.Memo = "1";
                }
            }
            else
            {
                info.Memo = this.neuSpread1_Sheet1.Cells[rowIndex, (int)ColumnSet.ColMemo].Tag.ToString();
            }

            return info;
        }

        /// <summary>
        /// 日报保存
        /// </summary>
        /// <returns></returns>
        protected int SaveDayReport()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.dayReportManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.zzReportManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info = this.GetDayReport(i);

                if (this.zzReportManager.UpdateAfterDayReportDetail(info) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("后续床位日报更新失败:" + this.dayReportManager.Err));
                    return -1;
                }

                int param = this.zzReportManager.UpdateInpatientDayReport(info);
                if (param == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("床位日报更新失败"));
                    return -1;
                }
                else if (param == 0)                                                                                                                                             
                {
                    if (this.dayReportManager.InsertInpatientDayReport(info) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("床位日报更新失败"));
                        return -1;
                    }
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功");

            return 1;
        }

        private enum ColumnSet
        {
            ColDateStat,
            ColDeptName,
           
            ColAddNum,
            ColFreeNum,
            ColBeginNum,

            ColInNum,
            ColTransferIn,
            ColTransferOut,
            ColOutNu,
            ColOutDeathNu,
            ColEndNum,

            

            ColDeptCode,
            #region {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            ColStarandNum,
            ColMemo
            #endregion {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
        }
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Visible = false;
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            print.PrintPage(30, 10, this);
            this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Visible = true;

        }
        protected override int OnPrint(object sender, object neuObject)
        {
            this.Print();
            return base.OnPrint(sender, neuObject);
        }
        /// <summary>
        /// 导出
        /// </summary>
        private void Export()
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }
        }
        public override int Export(object sender, object neuObject)
        {
            this.Export();

            return base.Export(sender, neuObject);
        }

        /// <summary>
        /// {2D052C32-3BA2-4302-B41B-97AC7C8810E7}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDayReportManager_Load(object sender, EventArgs e)
        {
            //床位日报明细没有实现，先隐藏掉
            this.neuSpread1_Sheet2.Visible = false;
            //{32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 床位日报审核功能
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(this.interManager.GetDepartment());
            if (this.deptZone1 == DeptZone.ALL)
            {
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMemo].Label = "是否结转";
                this.lblInfo.Text = "灰色表示护士站尚未提交，红色表示已经结转。";
            }
            else
            {
                this.lblDept.Visible = false;
                this.cmbDept.Visible = false;
            }
            //住院科室列表
            ArrayList alDeptList = this.interManager.GetDepartment(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
            alDeptList.Insert(0, new Neusoft.FrameWork.Models.NeuObject("AAAA", "全部", ""));
            this.cmbDept.AddItems(alDeptList);
            this.cmbDept.Tag = "AAAA";
        }

        private void neuSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == (int)ColumnSet.ColBeginNum ||
                e.Column == (int)ColumnSet.ColInNum ||
                e.Column == (int)ColumnSet.ColTransferIn ||
                e.Column == (int)ColumnSet.ColTransferOut ||
                e.Column == (int)ColumnSet.ColOutNu)
            {
                int beginNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColBeginNum].Text);
                int tnNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColInNum].Text);
                int transferIn = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColTransferIn].Text);
                int transferOut = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColTransferOut].Text);
                int outNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColOutNu].Text);
                this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColEndNum].Text = (beginNum + tnNum + transferIn - transferOut - outNum).ToString();
            }
            else if (e.Column == (int)ColumnSet.ColEndNum)
            {
                Neusoft.HISFC.Models.HealthRecord.InpatientDayReport info = this.neuSpread1_Sheet1.Rows[e.Row].Tag as Neusoft.HISFC.Models.HealthRecord.InpatientDayReport;
                if (info == null)
                {
                    return;
                }
                int endNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColEndNum].Text);
                string deptCode = info.ID;
                //DateTime lastDate = info.DateStat.Date;
                for (int i = e.Row + 1; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.HealthRecord.InpatientDayReport tmpInfo = this.neuSpread1_Sheet1.Rows[i].Tag as Neusoft.HISFC.Models.HealthRecord.InpatientDayReport;
                    if (tmpInfo == null)
                    {
                        continue;
                    }
                    string tmpDeptCode = tmpInfo.ID;
                    //DateTime tmpDate = tmpInfo.DateStat.Date;
                    if (tmpDeptCode == deptCode)
                    {
                        int tmpEndNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColEndNum].Text);
                        int tmpBeginNum = FrameWork.Function.NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBeginNum].Text);
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColBeginNum].Text = endNum.ToString();
                        this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColEndNum].Text = (tmpEndNum + (endNum - tmpBeginNum)).ToString();
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// {32357656-B32A-4fcc-BE5D-6FA1789CD5C9} 
        /// 床位日报审核功能-全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Rows[i].Locked)
                {
                    continue;
                }
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMemo].Text = this.chkAll.Checked ? "TRUE" : "FALSE";
            }
        }

       
    }
}

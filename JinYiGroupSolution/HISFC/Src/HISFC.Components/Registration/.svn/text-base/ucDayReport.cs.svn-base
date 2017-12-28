using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UFC.Registration
{
    /// <summary>
    /// 日结
    /// </summary>
    public partial class ucDayReport : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucDayReport()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucDayReport_Load);            
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
        }


        #region 变量
        /// <summary>
        /// 日结管理类
        /// </summary>
        Neusoft.HISFC.Management.Registration.DayReport dayReport = new Neusoft.HISFC.Management.Registration.DayReport();
        /// <summary>
        /// 挂号管理类
        /// </summary>
        Neusoft.HISFC.Management.Registration.Register regMgr = new Neusoft.HISFC.Management.Registration.Register();        
        /// <summary>
        /// 水晶报表
        /// </summary>
      //  Report.crDayReport crDayReport = new UFC.Registration.Report.crDayReport();
        /// <summary>
        /// 日结实体
        /// </summary>
        Neusoft.HISFC.Object.Registration.DayReport objDayReport;
        /// <summary>
        /// 数据源
        /// </summary>
        DataSet source = new Report.dsDayReport();
        DataSet dsRegInfo = new DataSet();
        private ArrayList al;
        private Boolean RepeatFlag = false;
        #endregion

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDayReport_Load(object sender, EventArgs e)
        {
            this.InitTree();
                        
            this.ShowReport();

            //默认选择当前操作员
            foreach (TreeNode node in this.treeView1.Nodes[0].Nodes)
            {
                if (node.Tag.ToString() == regMgr.Operator.ID)
                {
                    this.treeView1.SelectedNode = node;
                    break;
                }
            }
        }

        /// <summary>
        /// 生成挂号员列表
        /// </summary>
        private void InitTree()
        {
            this.treeView1.Nodes.Clear();

            TreeNode root = new TreeNode("挂号员", 22, 22);
            this.treeView1.Nodes.Add(root);
            
            //Neusoft.HISFC.Management.Registration.Permission perMgr = new Neusoft.HISFC.Management.Registration.Permission();
            ////获得操作挂号窗口的人员
            //this.al = perMgr.Query("UFC.Registration.ucRegister");
            //if (al == null)
            //{
            //    MessageBox.Show("获取挂号员信息时出错!" + perMgr.Err, "提示");
            //    return;
            //}
            
            
            //foreach (Neusoft.NFC.Object.NeuObject obj in al)
            //{
            //    TreeNode node = new TreeNode(obj.Name, 34, 35);
            //    node.Tag = obj.ID;
            //    root.Nodes.Add(node);
            //}
            TreeNode node = new TreeNode(this.dayReport.Operator.Name, 34, 35);
            node.Tag = this.dayReport.Operator.ID;
            root.Nodes.Add(node);

            root.Expand();
            this.SetQueryDateTime();
            
            this.nDTPBeginDate.Enabled = false;

            
            
        }

        /// <summary>
        /// 查询日结信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node.Parent != null)//不是父节点
            {
                Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在检索操作员日结信息,请稍后!");
                Application.DoEvents();

                this.Query(e.Node.Tag.ToString(), e.Node.Text);

                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.source.Tables[0].Rows.Clear();
            this.objDayReport = null;
            this.ShowReport();
        }

        /// <summary>
        /// 显示报表
        /// </summary>
        private void ShowReport()
        {
            //try
            //{
            //    this.crDayReport.SetDataSource(this.source);
            //    this.crystalReportViewer1.ReportSource = this.crDayReport;
            //    this.crystalReportViewer1.RefreshReport();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);                
            //}
        }
        /// <summary>
        /// 日结查询
        /// </summary>
        private void Query(string OperID, string OperName)
        {
            //开始时间、结束时间
            //如果一次日结也没有,默认起始时间为2000-01-01
            //DateTime beginDate = DateTime.Parse("2000-01-01");

            //string rtn = this.dayReport.GetBeginDate(OperID);
            //if (rtn == "-1") return;

            //if (rtn != "") beginDate = DateTime.Parse(rtn);

            //DateTime endDate = this.dayReport.GetDateTimeFromSysDateTime();
            this.RepeatFlag = false;
            DateTime beginDate = this.nDTPBeginDate.Value;
            DateTime endDate = this.nDTPEndDate.Value;
            //检索挂号明细
            this.dsRegInfo = this.GetRegDetail(OperID, beginDate, endDate);
            if (dsRegInfo == null) return;
            this.nDTPBeginDate.Value = beginDate;
            this.nDTPEndDate.Value = endDate;
            //if (dsRegInfo.Tables.Count == 0 || dsRegInfo.Tables[0].Rows.Count == 0)
            //{
            //    MessageBox.Show("该操作员无挂号信息!", "提示");
            //    return;
            //}

            

            #region 生成日结信息
            this.SetReportDetail(beginDate, endDate, OperID, OperName);
            this.SetReport();
            this.SetCR();
            #endregion

            this.ShowReport();
            this.ucRegDayBalanceReport1.InitUC();
            this.ucRegDayBalanceReport1.setFP(this.objDayReport);
        }
        private void SetQueryDateTime()
        {
            //开始时间、结束时间
            //如果一次日结也没有,默认起始时间为2000-01-01
            DateTime beginDate = DateTime.Parse("2000-01-01");

            string rtn = this.dayReport.GetBeginDate(this.dayReport.Operator.ID);
            if (rtn == "-1") return;

            if (rtn != "") beginDate = DateTime.Parse(rtn);

            DateTime endDate = this.dayReport.GetDateTimeFromSysDateTime();
            this.nDTPBeginDate.Value = beginDate;
            this.nDTPEndDate.Value = endDate;

        }

        /// <summary>
        /// 获取挂号明细
        /// </summary>
        /// <param name="OperId"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private DataSet GetRegDetail(string OperId, DateTime begin, DateTime end)
        {
            //string sql = "";

            //if (this.regMgr.Sql.GetSql("Registration.Register.Query.11", ref sql) == -1) return null;

            //try
            //{
            //    sql = string.Format(sql, begin.ToString(), end.ToString(), OperId);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("获取操作员挂号明细出错!" + e.Message, "提示");
            //    return null;
            //}

            DataSet ds = new DataSet();

            //if (this.regMgr.Sql.ExecQuery(sql, ref ds) == -1) return null;
            this.dayReport.QueryRegisterDetails(OperId, begin, end, ref ds);
            return ds;

        }

        /// <summary>
        /// 生成日结明细实体
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="operID"></param>
        /// <param name="operName"></param>
        private void SetReportDetail(DateTime begin, DateTime end, string operID, string operName)
        {

            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            this.objDayReport = new Neusoft.HISFC.Object.Registration.DayReport();
            this.objDayReport.BeginDate = begin;
            this.objDayReport.EndDate = end;
            this.objDayReport.Oper.ID = operID;
            this.objDayReport.Oper.Name = operName;
            this.objDayReport.Oper.OperTime = current;

            Neusoft.HISFC.Object.Registration.DayDetail detail = new Neusoft.HISFC.Object.Registration.DayDetail();
            detail.EndRecipeNo = "-1";

            //生成日报实体,原则：连续处方、处方状态一致的合为一条日结明细
            for (int i = 0; i < this.dsRegInfo.Tables[0].Rows.Count; i++)
            {
                DataRow row = this.dsRegInfo.Tables[0].Rows[i];


                ///
                ///挂号状态为退号、日结人不是作废人、未日结，此种情况为别人退该操作员号,此号有效
                ///
                if (row[8].ToString() == "0" && operID != row[9].ToString())
                {
                    row[8] = "1";//置为有效
                }


                if (long.Parse(row[0].ToString()) - 1 != long.Parse(detail.EndRecipeNo) ||//处方不连续
                    int.Parse(row[8].ToString()) != (int)detail.Status) //状态改变					
                {
                    //生成新的日结明细
                    if (i != 0)//第一条不处理
                    { this.objDayReport.Details.Add(detail); }

                    //重新生成新的明细
                    detail = new Neusoft.HISFC.Object.Registration.DayDetail();
                    detail.BeginRecipeNo = row[0].ToString();//开始号	
                    detail.EndRecipeNo = detail.BeginRecipeNo;//Convert.ToString(long.Parse(row[0].ToString()) -1) ;
                    detail.Status = (Neusoft.HISFC.Object.Base.EnumRegisterStatus)int.Parse(row[8].ToString());
                }

                detail.EndRecipeNo = row[0].ToString();
                detail.Count++;
                detail.RegFee += decimal.Parse(row[1].ToString());
                detail.ChkFee += decimal.Parse(row[2].ToString());
                detail.DigFee += decimal.Parse(row[3].ToString());
                detail.OthFee += decimal.Parse(row[4].ToString());
                detail.OwnCost += decimal.Parse(row[5].ToString());
                detail.PayCost += decimal.Parse(row[6].ToString());
                detail.PubCost += decimal.Parse(row[7].ToString());

                if (i == this.dsRegInfo.Tables[0].Rows.Count - 1)
                    this.objDayReport.Details.Add(detail);//最后一条也重新生成明细
            }
        }
        /// <summary>
        /// 生成日结实体
        /// </summary>
        private void SetReport()
        {
            for(int i = 0; i < this.objDayReport.Details.Count; i++)
            {
                Neusoft.HISFC.Object.Registration.DayDetail detail = this.objDayReport.Details[i];
                detail.OrderNO = i.ToString();

                this.objDayReport.SumCount += detail.Count;
                if (detail.Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Cancel) continue;

                this.objDayReport.SumRegFee += detail.RegFee;
                this.objDayReport.SumChkFee += detail.ChkFee;
                this.objDayReport.SumDigFee += detail.DigFee;
                this.objDayReport.SumOthFee += detail.OthFee;
                this.objDayReport.SumOwnCost += detail.OwnCost;
                this.objDayReport.SumPayCost += detail.PayCost;
                this.objDayReport.SumPubCost += detail.PubCost;
            }
        }
        /// <summary>
        /// 生成水晶报表
        /// </summary>
        private void SetCR()
        {
            DataSet ds = new Report.dsDayReport();

            string RMBCasch = Neusoft.NFC.Function.NConvert.ToCapital(this.objDayReport.SumOwnCost);

            foreach (Neusoft.HISFC.Object.Registration.DayDetail detail in this.objDayReport.Details)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = detail.BeginRecipeNo;
                dr[1] = detail.EndRecipeNo;
                dr[2] = detail.Count;


                //退号

                if (detail.Status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Back)
                {
                    dr[3] = -detail.RegFee;
                    dr[4] = -(detail.DigFee + detail.ChkFee);
                    dr[6] = -detail.OthFee;
                    dr[7] = -detail.OwnCost;
                }
                else
                {
                    dr[3] = detail.RegFee;
                    dr[4] = detail.DigFee + detail.ChkFee;
                    dr[6] = detail.OthFee;
                    dr[7] = detail.OwnCost;
                }

                dr[8] = this.getStatus(detail.Status);
                dr[9] = this.objDayReport.Oper.ID;
                dr[10] = this.treeView1.SelectedNode.Text;
                dr[11] = this.objDayReport.BeginDate;
                dr[12] = this.objDayReport.EndDate;
                dr[13] = this.objDayReport.Oper.OperTime;
                dr[15] = this.objDayReport.SumOwnCost;
                dr[16] = this.objDayReport.SumRegFee;
                dr[17] = this.objDayReport.SumDigFee + this.objDayReport.SumChkFee;
                dr[5] = this.objDayReport.SumOthFee;
                dr[18] = RMBCasch;

                ds.Tables[0].Rows.Add(dr);
            }

            //按状态进行排序
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "状态 DESC";

            source.Tables[0].Rows.Clear();
            foreach (DataRowView dvRow in dv)
            {
                DataRow dr = this.source.Tables[0].NewRow();
                #region 赋值
                dr[0] = dvRow[0];
                dr[1] = dvRow[1];
                dr[2] = dvRow[2];
                dr[3] = dvRow[3];
                dr[4] = dvRow[4];
                dr[5] = dvRow[5];
                dr[6] = dvRow[6];
                dr[7] = dvRow[7];
                dr[8] = dvRow[8];
                dr[9] = dvRow[9];
                dr[10] = dvRow[10];
                dr[11] = dvRow[11];
                dr[12] = dvRow[12];
                dr[13] = dvRow[13];
                dr[14] = dvRow[14];
                dr[15] = dvRow[15];
                dr[16] = dvRow[16];
                dr[17] = dvRow[17];
                dr[18] = dvRow[18];
                #endregion
                this.source.Tables[0].Rows.Add(dr);
            }

        }
        /// <summary>
        /// 获取处方状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private string getStatus(Neusoft.HISFC.Object.Base.EnumRegisterStatus status)
        {
            if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Valid)
            { return "正常"; }
            else if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Back)
            { return "退号"; }
            else if (status == Neusoft.HISFC.Object.Base.EnumRegisterStatus.Cancel)
            { return "作废"; }
            else
            { return "错误"; }
        }
        /// <summary>
        /// 获取医院名称
        /// </summary>
        /// <returns></returns>
        private string getHosName()
        {
            return "";
        }
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.Q.GetHashCode())
            {
                this.Query();

                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            {
                this.Save();

                return true;
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
            }
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.R.GetHashCode())
            {
                this.Reprint();

                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.FindForm().Close();
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 日结
        /// </summary>
        private void Save()
        {
            if (this.treeView1.SelectedNode == null) return;

            //先重新检索一遍，防止时间差，否则容易出错!
            this.treeView1_AfterSelect(new object(), new TreeViewEventArgs(this.treeView1.SelectedNode, TreeViewAction.Unknown));

            if (this.objDayReport == null)
            {
                MessageBox.Show("请选择挂号员,检索数据!", "提示");
                return;
            }
            if (this.objDayReport.ID != "")
            {
                MessageBox.Show("该日结信息已经保存,不能再次保存!", "提示");
                return;
            }
            if (this.objDayReport.Details.Count == 0)
            {
                MessageBox.Show("无日结信息,不需保存!", "提示");
                return;
            }
            if (this.objDayReport.Oper.ID != regMgr.Operator.ID)
            {
                MessageBox.Show("不允许日结不是本人的费用信息!", "提示");
                return;
            }

            Neusoft.NFC.Management.Transaction SQLCA = new Neusoft.NFC.Management.Transaction(regMgr.con);
            SQLCA.BeginTransaction();

            try
            {
                this.regMgr.SetTrans(SQLCA.Trans);
                this.dayReport.SetTrans(SQLCA.Trans);

                string seq = this.regMgr.GetSequence("Registration.DayReport.GetSequence");
                this.objDayReport.ID = seq;

                foreach (Neusoft.HISFC.Object.Registration.DayDetail detail in this.objDayReport.Details)
                {
                    detail.ID = seq;
                }
                if (this.dayReport.Insert(this.objDayReport) == -1)
                {
                    SQLCA.RollBack();
                    MessageBox.Show(this.dayReport.Err, "提示");
                    return;
                }

                int rtn = this.regMgr.Update(this.objDayReport.BeginDate, this.objDayReport.EndDate,
                    this.objDayReport.Oper.ID,seq);
                if (rtn == -1)
                {
                    SQLCA.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return;
                }

                if (rtn == 0)
                {
                    SQLCA.RollBack();
                    MessageBox.Show("日结信息状态已经变更,请重新日结!", "提示");
                    return;
                }

                SQLCA.Commit();
            }
            catch (Exception e)
            {
                SQLCA.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }

            MessageBox.Show("日结成功!", "提示");

            //this.crystalReportViewer1.PrintReport();
            this.PrintPanel(this.panel3);
            this.Clear();
            this.SetQueryDateTime();
            this.Query(this.dayReport.Operator.ID, this.dayReport.Operator.Name);
            
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void Query()
        {
            this.ucRegDayBalanceReport1.InitUC();
            if (this.treeView1.SelectedNode.Parent == null)
            {
                MessageBox.Show("请选择操作员!", "提示");
                return;
            }

            frmQueryDayReport f = new frmQueryDayReport();
            f.OperID = this.treeView1.SelectedNode.Tag.ToString();
            f.Query();
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                this.objDayReport = f.SelectedDayReport;
                if (this.objDayReport != null && this.objDayReport.ID != "")
                {
                    ArrayList aldetails = this.dayReport.Query(this.objDayReport.ID);
                    foreach (Neusoft.HISFC.Object.Registration.DayDetail obj in aldetails)
                    {
                        this.objDayReport.Details.Add(obj);
                    }

                    this.SetCR();
                    this.ShowReport();
                    this.ucRegDayBalanceReport1.setFP(this.objDayReport);
                }

            }
            f.Dispose();
            this.RepeatFlag = true;
        }
        /// <summary>
        /// 补打
        /// </summary>
        private void Reprint()
        {
            //this.crystalReportViewer1.PrintReport();
            if (this.RepeatFlag == true)
            {
                this.PrintPanel(this.panel3);
            }
            else 
            {
                MessageBox.Show("只有日结后才能使用补打功能");
                return;
            }
        }

        private Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();

        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("补打(&R)", "", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A查询, true, false, null);
            this.toolBarService.AddToolButton("日结(&S)", "", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A保存, true, false, null);
            this.toolBarService.AddToolButton("打印(&P)", "", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A打印, true, false, null);
            this.toolBarService.AddToolButton("查询(&Q)", "", (int)Neusoft.NFC.Interface.Classes.EnumImageList.A顾客, true, false, null);
            return this.toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "补打(&R)":
                    this.Query();

                    break;
                case "日结(&S)":
                    this.Save();

                    break;
                case "打印(&P)":
                    this.Reprint();

                    break;
                case "查询(&Q)":
                    this.Query(this.dayReport.Operator.ID,this.dayReport.Operator.Name);
                    break;

            }

            base.ToolStrip_ItemClicked(sender, e);
        }
        /// <summary>
        ///打印报表
        /// </summary>
        /// <param name="argPanel"></param>
        public void PrintPanel(System.Windows.Forms.Panel argPanel)
        {
            Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
            print.PrintPage(0,0,this.panel3);
        }
    }
}

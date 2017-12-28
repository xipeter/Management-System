using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.WinForms.Report.OutpatientFee.DayBalance
{
    /// <summary>
    /// 日结
    /// </summary>
    public partial class ucDayReport : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
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
        Neusoft.HISFC.BizLogic.Registration.DayReport dayReport = new Neusoft.HISFC.BizLogic.Registration.DayReport();
        /// <summary>
        /// 挂号管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();        
        /// <summary>
        /// 水晶报表
        /// </summary>
      //  Report.crDayReport crDayReport = new Neusoft.HISFC.Components.Registration.Report.crDayReport();
        /// <summary>
        /// 日结实体
        /// </summary>
        Neusoft.HISFC.Models.Registration.DayReport objDayReport;
        /// <summary>
        /// 数据源
        /// </summary>
        //DataSet source = new Report.dsDayReport();
        DataSet dsRegInfo = new DataSet();
        //private ArrayList al;
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
            this.treeView1.ImageList = this.treeView1.deptImageList;
            TreeNode root = new TreeNode("挂号员", 22, 22);
            root.SelectedImageIndex = 0;
            root.ImageIndex = 0;
            this.treeView1.Nodes.Add(root);
            
            //Neusoft.HISFC.BizLogic.Registration.Permission perMgr = new Neusoft.HISFC.BizLogic.Registration.Permission();
            ////获得操作挂号窗口的人员
            //this.al = perMgr.Query("Neusoft.HISFC.Components.Registration.ucRegister");
            //if (al == null)
            //{
            //    MessageBox.Show("获取挂号员信息时出错!" + perMgr.Err, "提示");
            //    return;
            //}
            
            
            //foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
            //{
            //    TreeNode node = new TreeNode(obj.Name, 34, 35);
            //    node.Tag = obj.ID;
            //    root.Nodes.Add(node);
            //}
            TreeNode node = new TreeNode(this.dayReport.Operator.Name, 34, 35);
            node.Tag = this.dayReport.Operator.ID;
            node.ImageIndex = 7;
            node.SelectedImageIndex = 6;
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
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索操作员日结信息,请稍后!");
                Application.DoEvents();

                this.Query(e.Node.Tag.ToString(), e.Node.Text);

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            //this.source.Tables[0].Rows.Clear();
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
            
            this.RepeatFlag = false;
            DateTime beginDate = this.nDTPBeginDate.Value;
            DateTime endDate = this.nDTPEndDate.Value;
            //检索挂号明细
            this.dsRegInfo = this.GetRegDetail(OperID, beginDate, endDate);
            if (dsRegInfo == null) return;
            this.nDTPBeginDate.Value = beginDate;
            this.nDTPEndDate.Value = endDate;
             

            

            #region 生成日结信息
            this.SetReportDetail(beginDate, endDate, OperID, OperName);
            this.SetReport();
            //this.SetCR();
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
             
            DataSet ds = new DataSet();

            
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

            this.objDayReport = new Neusoft.HISFC.Models.Registration.DayReport();
            this.objDayReport.BeginDate = begin;
            this.objDayReport.EndDate = end;
            this.objDayReport.Oper.ID = operID;
            this.objDayReport.Oper.Name = operName;
            this.objDayReport.Oper.OperTime = current;

            Neusoft.HISFC.Models.Registration.DayDetail detail = new Neusoft.HISFC.Models.Registration.DayDetail();
            detail.EndRecipeNo = "-1";

         
            //生成日报实体,原则：连续处方、处方状态一致的合为一条日结明细
            for (int i = 0; i < this.dsRegInfo.Tables[0].Rows.Count; i++)
            {
                DataRow row = this.dsRegInfo.Tables[0].Rows[i];
     
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
                    detail = new Neusoft.HISFC.Models.Registration.DayDetail();
                    detail.BeginRecipeNo = row[0].ToString();//开始号	
                    detail.EndRecipeNo = detail.BeginRecipeNo;//Convert.ToString(long.Parse(row[0].ToString()) -1) ;
                    detail.Status = (Neusoft.HISFC.Models.Base.EnumRegisterStatus)int.Parse(row[8].ToString());
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
                Neusoft.HISFC.Models.Registration.DayDetail detail = this.objDayReport.Details[i];
                detail.OrderNO = i.ToString();

                this.objDayReport.SumCount += detail.Count;
                if (detail.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel) continue;

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
        /// 获取处方状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private string getStatus(Neusoft.HISFC.Models.Base.EnumRegisterStatus status)
        {
            if (status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid)
            { return "正常"; }
            else if (status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back)
            { return "退号"; }
            else if (status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
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
            //if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.Q.GetHashCode())
            //{
                
            //    this.Query(this.dayReport.Operator.ID, this.dayReport.Operator.Name);
            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.S.GetHashCode())
            //{
            //    this.Save();

            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.R.GetHashCode())
            //{
                
            //    this.Query();

            //    return true;
            //}
            //else if (keyData == Keys.Escape)
            //{
            //    this.FindForm().Close();
            //}

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

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(regMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.dayReport.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                string seq = this.regMgr.GetSequence("Registration.DayReport.GetSequence");
                this.objDayReport.ID = seq;

                foreach (Neusoft.HISFC.Models.Registration.DayDetail detail in this.objDayReport.Details)
                {
                    detail.ID = seq;
                }
                if (this.dayReport.Insert(this.objDayReport) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.dayReport.Err, "提示");
                    return;
                }

                int rtn = this.regMgr.Update(this.objDayReport.BeginDate, this.objDayReport.EndDate,
                    this.objDayReport.Oper.ID,seq);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return;
                }

                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("日结信息状态已经变更,请重新日结!", "提示");
                    return;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return;
            }
            DialogResult result = MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("日结成功!是否打印？"), Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                this.Clear();
                this.SetQueryDateTime();
                this.Query(this.dayReport.Operator.ID, this.dayReport.Operator.Name);
                return;
            }

        
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

            frmQueryDayReport f =  new frmQueryDayReport();
            f.OperID = this.treeView1.SelectedNode.Tag.ToString();
            f.Query();
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                this.objDayReport = f.SelectedDayReport;
                if (this.objDayReport != null && this.objDayReport.ID != "")
                {
                    ArrayList aldetails = this.dayReport.Query(this.objDayReport.ID);
                    foreach (Neusoft.HISFC.Models.Registration.DayDetail obj in aldetails)
                    {
                        this.objDayReport.Details.Add(obj);
                    }

                    //this.SetCR();
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

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("补打", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询, true, false, null);
            this.toolBarService.AddToolButton("日结", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            //this.toolBarService.AddToolButton("打印", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A打印, true, false, null);
            //this.toolBarService.AddToolButton("查询", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A顾客, true, false, null);
            return this.toolBarService;
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query(this.dayReport.Operator.ID, this.dayReport.Operator.Name);
            return base.OnQuery(sender, neuObject);
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            this.Reprint();
            return base.OnPrint(sender, neuObject);
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "补打":
                    this.Query();

                    break;
                case "日结":
                    this.Save();
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
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();
            print.PrintPage(0,0,this.panel3);
        }
    }
}

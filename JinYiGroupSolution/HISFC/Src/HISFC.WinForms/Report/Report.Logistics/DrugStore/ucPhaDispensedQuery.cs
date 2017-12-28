using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Report.Logistics.DrugStore
{
    /// <summary>
    /// <修改记录>
    ///    1、初始化时间选择控件 by Sunjh 2010-8-23 {67896C13-1E0C-492e-B6A3-0843CC915D9E}
    /// </修改记录>
    /// </summary>
    public partial class ucPhaDispensedQuery : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucPhaDispensedQuery()
        {
            InitializeComponent();
            GetItemzFunctionInfo();
            InitCbInOutType();
            if (this.neuTabControl1.Contains(this.tabDetail))
            {
                this.neuTabControl1.TabPages.Remove(tabDetail);
            }
        }
        protected Neusoft.HISFC.Models.Base.Employee employee = null;
        private Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
        private Neusoft.HISFC.BizLogic.Manager.Department dept = new Neusoft.HISFC.BizLogic.Manager.Department();
        private Neusoft.HISFC.Models.Base.Employee emp = new Neusoft.HISFC.Models.Base.Employee();

        /// <summary>
        /// 初始化药品类别
        /// </summary>
        /// <returns></returns>
        private bool GetItemzFunctionInfo()
        {
            Neusoft.HISFC.BizLogic.RADT.InPatient Manager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            System.Collections.ArrayList alUsecodeList = new ArrayList();
            this.cbPhaName.alItems.Clear();
            this.cbPhaName.Items.Clear();
            Neusoft.HISFC.Models.Base.Spell sp = new Neusoft.HISFC.Models.Base.Spell();
            sp.Name = "全部";
            sp.ID = "ALL";
            alUsecodeList.Add(sp);
            //{3868F08C-D224-443b-94FB-FE4A493742B6} 药品过滤时要加上规格
            //string strSql = @" select tt.drug_code,tt.trade_name,tt.spell_code,tt.wb_code from pha_com_baseinfo tt";
            string strSql = @" select tt.drug_code,tt.trade_name,tt.specs,tt.spell_code,tt.wb_code from pha_com_baseinfo tt ";

            strSql = string.Format(strSql);
            DataSet ds = new DataSet();
            if (Manager.ExecQuery(strSql, ref ds) == -1)
            {
                return false;
            }
            if (ds == null || ds.Tables[0] == null)
            {
                MessageBox.Show("查询错误", "警告,药品加载错误！");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Neusoft.HISFC.Models.Base.Spell obj = new Neusoft.HISFC.Models.Base.Spell();
                    obj.ID = ds.Tables[0].Rows[i][0].ToString();
                    obj.Name = ds.Tables[0].Rows[i][1].ToString();
                    obj.Memo = ds.Tables[0].Rows[i][2].ToString();
                    obj.SpellCode = ds.Tables[0].Rows[i][3].ToString();
                    obj.WBCode = ds.Tables[0].Rows[i][4].ToString();
                    alUsecodeList.Add(obj);
                }
                int c = this.cbPhaName.AddItems(alUsecodeList);

            }
            else
            {
                return false;
            }
            this.cbPhaName.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// 初始化出入库类型
        /// </summary>
        /// <returns></returns>
        private bool InitCbInOutType()
        {
            ArrayList alInOut = new ArrayList();
            Neusoft.HISFC.Models.Base.Spell obj1 = new Neusoft.HISFC.Models.Base.Spell();
            obj1.ID = "IN";
            obj1.Name = "入库";
            alInOut.Add(obj1);
            Neusoft.HISFC.Models.Base.Spell obj2 = new Neusoft.HISFC.Models.Base.Spell();
            obj2.ID = "OUT";
            obj2.Name = "出库";
            alInOut.Add(obj2);
            this.cbInOutType.AddItems(alInOut);
            this.cbInOutType.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// 查询入库信息
        /// </summary>
        private void QueryInPut()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();

                DataSet ds = new DataSet();
                emp = (Neusoft.HISFC.Models.Base.Employee)dept.Operator;
                if (this.itemManager.ExecQuery("Neusoft.Pha.Out.Info", ref ds, this.dtpFrom.Value.ToString(),this.dtpTo.Value.ToString(),this.emp.Dept.ID,this.cbPhaName.SelectedItem.ID) == -1)
                {
                    MessageBox.Show(Language.Msg("数据查询失败，请与管理员联系！" + this.itemManager.Err));
                    return;
                }

                this.nfpStat.DataSource = ds;
                this.nfpStat_Sheet1.SheetName = emp.Dept.Name+"入库信息明细";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
        private void QueryOutPut()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();

                DataSet ds = new DataSet();
                emp = (Neusoft.HISFC.Models.Base.Employee)dept.Operator;
                //{3868F08C-D224-443b-94FB-FE4A493742B6} 出库查询中查询出所有出库数据
                //if (this.itemManager.ExecQuery("Neusoft.Pha.Dispense", ref ds, this.dtpFrom.Value.ToString(), this.dtpTo.Value.ToString(), this.emp.Dept.ID, this.cbPhaName.SelectedItem.ID) == -1)
                if (this.itemManager.ExecQuery("Neusoft.Pha.DispenseNew", ref ds, this.dtpFrom.Value.ToString(), this.dtpTo.Value.ToString(), this.emp.Dept.ID, this.cbPhaName.SelectedItem.ID) == -1)
                {
                    MessageBox.Show(Language.Msg("数据查询失败，请与管理员联系！" + this.itemManager.Err));
                    return;
                }

                this.nfpStat.DataSource = ds;
                this.nfpStat_Sheet1.SheetName = emp.Dept.Name + "出库信息明细";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }

        }
        private void QueryDetail()
        {
            try
            {
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在查询，请稍候..."));
                Application.DoEvents();

                string deptCode;

                DataSet ds = new DataSet();
                emp = (Neusoft.HISFC.Models.Base.Employee)dept.Operator;
                deptCode = this.nfpStat_Sheet1.Cells[this.nfpStat_Sheet1.ActiveRowIndex, 6].Text.ToString(); //this.nfpStat_Sheet1.Cells[this.nfpStat_Sheet1.ActiveRowIndex, this.nfpStat_Sheet1.Columns["科室编码"].Index].Text;
                
                string phaname=this.nfpStat_Sheet1.Cells[this.nfpStat_Sheet1.ActiveRowIndex,0].Text.ToString();
                if (this.itemManager.ExecQuery("Neusoft.Pha.DispensePerPatient", ref ds, this.dtpFrom.Value.ToString(), this.dtpTo.Value.ToString(), this.emp.Dept.ID, phaname,deptCode) == -1)
                {
                    MessageBox.Show(Language.Msg("数据查询失败，请与管理员联系！" + this.itemManager.Err));
                    return;
                }

                this.nfpDetail.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("开始时间不能大于截止时间！");
                return -1;
            }
            if (this.cbInOutType.SelectedItem.ID == "IN")
            {
                if (this.neuTabControl1.Contains(tabDetail))
                {
                    this.neuTabControl1.TabPages.Remove(tabDetail);
                }
                this.QueryInPut();
            }
            else 
            {
                if (this.neuTabControl1.Contains(tabDetail))
                {
                    this.neuTabControl1.TabPages.Remove(tabDetail);
                }
                this.QueryOutPut();
            }
            return 1;
        }

        private void nfpStat_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //郑大张晓坚主任要屏蔽此功能 xizf20110120
            return;
            if (this.cbInOutType.SelectedItem.ID == "IN")
            {
                return;
            }
            if (this.neuTabControl1.Contains(tabDetail) == false)
            {
                this.neuTabControl1.TabPages.Add(tabDetail);
            }
            this.neuTabControl1.SelectedIndex = 1;
            QueryDetail();
        }


        protected override void OnLoad(EventArgs e)
        {
            //初始化时间选择控件 by Sunjh 2010-8-23 {67896C13-1E0C-492e-B6A3-0843CC915D9E}
            this.dtpFrom.Value = DateTime.Now.Date;
            this.dtpTo.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            base.OnLoad(e);
        }

         //打印预览
        public override int PrintPreview(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print printview = new Neusoft.FrameWork.WinForms.Classes.Print();
    
            printview.PrintPreview(0, 0, this.neuTabControl1.SelectedTab);
            return base.OnPrintPreview(sender, neuObject);
        }

        //打印
        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Print print = new Neusoft.FrameWork.WinForms.Classes.Print();

            print.PrintPage(0, 0, this.neuTabControl1.SelectedTab);

            return base.OnPrint(sender, neuObject);
        }

        //导出
        public override int Export(object sender, object neuObject)
        {
            if (this.neuTabControl1.SelectedIndex ==0)
            {
                return nfpStat.Export();
            }
            else 
            {
                return nfpDetail.Export();
            }

        }

       
    }
}

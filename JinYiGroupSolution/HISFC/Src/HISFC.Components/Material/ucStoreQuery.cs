using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.NFC.Management;
using Neusoft.NFC.Function;

namespace Neusoft.UFC.Material
{
    /// <summary>
    /// 库存查询 临时查询窗口
    /// </summary>
    public partial class ucStoreQuery : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucStoreQuery()
        {
            InitializeComponent();
        }

        #region 工具栏

        private Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();

        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            return base.OnInit(sender, neuObject, param);
        }

        public override int Export(object sender, object neuObject)
        {
            if (this.neuSpread1.Export() == 1)
            {
                MessageBox.Show(Language.Msg("导出成功"));
            }

            return base.Export(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.Query();

            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 域变量

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.NFC.Public.ObjectHelper deptHelper = new Neusoft.NFC.Public.ObjectHelper();

        /// <summary>
        /// 显示所有药品库存情况Sql
        /// </summary>
        private string sql1 = "";

        /// <summary>
        /// 显示指定药品库存情况Sql
        /// </summary>
        private string sql2 = "";

        /// <summary>
        /// 显示明细信息
        /// </summary>
       // private string sql3 = "";

        /// <summary>
        /// 数据视图
        /// </summary>
        private System.Data.DataView dv = null;
        
        /// <summary>
        /// 操作员科室编码
        /// </summary>
        private  string stroeageCode = string.Empty;

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
           // Neusoft.HISFC.Management.Pharmacy.Item itemManager = new Neusoft.HISFC.Management.Pharmacy.Item();
           // List<Neusoft.HISFC.Object.Pharmacy.Item> itemList = itemManager.QueryItemList(true);
            //this.cmbDrug.AddItems(new ArrayList(itemList.ToArray()));


            Neusoft.HISFC.Management.Manager.Department deptManager = new Neusoft.HISFC.Management.Manager.Department();
            
            ArrayList alDept = deptManager.GetDeptmentAll();
            this.deptHelper = new Neusoft.NFC.Public.ObjectHelper(alDept);
           
            string operCode = string.Empty;
            Neusoft.NFC.Management.DataBaseManger data = new Neusoft.NFC.Management.DataBaseManger();

            operCode = ((Neusoft.HISFC.Object.Base.Employee)data.Operator).ID;
            
            //取该操作员所在科室即可
            stroeageCode = ((Neusoft.HISFC.Object.Base.Employee)data.Operator).Dept.ID;

            #region 加载Sql

            //            this.sql1 = @"
            //select s.trade_name 药品名称,s.specs 规格,t.drug_dept_code 库存科室,
            //       round(t.store_sum / t.pack_qty,2) 库存量,s.pack_unit 单位,
            //       s.spell_code 拼音码,s.wb_code 五笔码,s.custom_code 自定义码,
            //	   t.drug_code 药品编码,t.drug_dept_code 库存编码,t.valid_state 停用
            //from   pha_com_stockinfo t,pha_com_baseinfo s
            //where  t.drug_code = s.drug_code";
            //and t.storage_code= '{stroeageCode}'
            this.sql1 = @"
           select s.item_name 物品名称,s.specs 规格,t.store_num 库存,t.price 单价,t.stat_unit 包装单位,t.store_cost 库存金额,t.valid_state 有效标志,s.item_code,s.kind_code,s.spell_code 拼音码,t.place_code
           from  log_mat_baseinfo s,log_mat_stock t
           where t.item_code=s.item_code
            and t.storage_code= '{0}'"
                ;
            this.sql2 = @"
         select s.item_name 物品名称,s.item_code,s.kind_code,s.spell_code 拼音码,s.specs 规格,t.store_num 库存,t.price 单价,t.stat_unit 包装单位,t.store_cost 库存金额,,t.valid_state 有效标志s.item_code,s.kind_code,s.spell_code 拼音码,t.place_code
         from  log_mat_baseinfo s,log_mat_stock t
         where t.item_code=s.item_code
         and t.storage_code= '{0}'
         and t.item_code = '{1}'";

            #endregion

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            //this.neuSpread1_Sheet2.DefaultStyle.Locked = true;
        }

        /// <summary>
        /// 格式化 
        /// </summary>
        private void SetFormat()
        {
            //   this.neuSpread1_Sheet1.Columns[5].Visible = false;
            //  this.neuSpread1_Sheet1.Columns[6].Visible = false;
            this.neuSpread1_Sheet1.Columns[7].Visible = false;

            this.neuSpread1_Sheet1.Columns[8].Visible = false;
            this.neuSpread1_Sheet1.Columns[9].Visible = false;

            this.neuSpread1_Sheet1.Columns[10].Visible = false;

            RefreshFpFlag(this.neuSpread1_Sheet1);
        }

        /// <summary>
        /// 刷新显示药品，用于显示停用标志
        /// </summary>
        private void RefreshFpFlag(FarPoint.Win.Spread.SheetView sheet)
        {
            if (sheet.RowCount > 0)
            {
                for (int i = 0; i < sheet.RowCount; i++)
                {
                    if (sheet.Cells[i, 10].Text.ToString().Trim() == "1")
                        sheet.Cells[i, 2].BackColor = System.Drawing.Color.Red;
                    else
                        sheet.Cells[i, 2].BackColor = System.Drawing.Color.White;
                }
            }
        }

        /// <summary>
        /// 设置某列颜色
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="column"></param>
        /// <param name="valu"></param>
        private void SetColumnsColore(FarPoint.Win.Spread.SheetView sheet, int column, Color valu)
        {
            sheet.Columns[column].BackColor = valu;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Query()
        {
            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm("正在进行查询...请稍候");
            Application.DoEvents();

            string exeSql = "";
            if (this.ckAll.Checked)			//全部药品
            {
                exeSql = string.Format( this.sql1,stroeageCode);
            }
            else
            {
                if (this.cmbDrug.Tag != null && this.cmbDrug.Tag.ToString() != "")
                {
                    exeSql = string.Format(this.sql2,stroeageCode, this.cmbDrug.Tag.ToString());
                }
                else
                {
                    Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                    return;
                }
            }

            Neusoft.NFC.Management.DataBaseManger dataManager = new Neusoft.NFC.Management.DataBaseManger();

            DataSet ds = new DataSet();

            if (dataManager.ExecQuery(exeSql, ref ds) == -1)
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("执行Sql语句发生错误" + dataManager.Err));
                return;
            }

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    if (ds.Tables[0].Columns.Contains("库存科室"))
                        dr["库存科室"] = this.deptHelper.GetName(dr["库存科室"].ToString());
                }
            }

            this.dv = new DataView(ds.Tables[0]);

            this.neuSpread1_Sheet1.DataSource = dv;

            this.SetFormat();

            if (this.neuSpread1.ActiveSheet != this.neuSpread1_Sheet1)
            {
                this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet1;
            }

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Init();

            base.OnLoad(e);
        }

        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.dv != null)
                {
                    string rowFilter = string.Format("拼音码 like '%{0}%'", this.txtFilter.Text);

                    this.dv.RowFilter = rowFilter;

                    RefreshFpFlag(this.neuSpread1_Sheet1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       // private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        //{
            //if (this.neuSpread1.ActiveSheet == this.neuSpread1_Sheet2)
            //{
           //     this.neuSpread1.ActiveSheet = this.neuSpread1_Sheet1;
            //}
            //else
            
             //   string drugCode = this.neuSpread1_Sheet1.Cells[e.Row, 8].Text;
             //   string deptCode = this.neuSpread1_Sheet1.Cells[e.Row, 9].Text;

              //  Neusoft.NFC.Management.DataBaseManger dataManager = new Neusoft.NFC.Management.DataBaseManger();
              //  DataSet ds = new DataSet();

             //   string exeSql = string.Format(this.sql3, drugCode, deptCode);

              //  if (dataManager.ExecQuery(exeSql, ref ds) == -1)
             //   {
              //      MessageBox.Show(Language.Msg(dataManager.Err));
             //   }
                        

            
        
    }
}

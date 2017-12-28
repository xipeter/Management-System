using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucDrugLimitMaintenance : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDrugLimitMaintenance()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 药品业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Item pharmacyManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

        /// <summary>
        /// 医嘱药品限制业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.SpecialLimit specialLimitManager = new Neusoft.HISFC.BizLogic.Order.SpecialLimit();

        /// <summary>
        /// 路径
        /// </summary>
        private string filePath = Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + @".\OrderDrugLimit.xml";

        private DataTable dtOrderDrugLimit = new DataTable();

        private DataView dvOrderDrugLimit = new DataView();

        private ArrayList alDrugLimit = new ArrayList();

        /// <summary>
        /// 操作员
        /// </summary>
        private Neusoft.HISFC.Models.Base.Employee oper = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;

        /// <summary>
        /// ToolBarService
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.ucDrugList1.ChooseDataEvent += new Neusoft.HISFC.Components.Common.Controls.ucDrugList.ChooseDataHandler(ucDrugList1_ChooseDataEvent);
            this.ucDrugList1.ShowPharmacyList();
            this.InitFP();
            this.QueryAll();
        }

        /// <summary>
        /// 初始化FP
        /// </summary>
        private void InitFP()
        {
            this.dtOrderDrugLimit.Reset();
            if (System.IO.File.Exists(this.filePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(this.filePath, dtOrderDrugLimit, ref dvOrderDrugLimit, this.fpOrderDrugLimit_Sheet1);

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.fpOrderDrugLimit_Sheet1, this.filePath);
            }
            else
            {
                this.dtOrderDrugLimit.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("药品编码",typeof(string)),
                    new DataColumn("药品名称",typeof(string)),
                    new DataColumn("是否需上级医生审核",typeof(bool)),
                    new DataColumn("是否需手工处方",typeof(bool)),
                    new DataColumn("有效标记",typeof(bool)),
                    new DataColumn("备注",typeof(string)),
                    new DataColumn("操作员",typeof(string)),
                    new DataColumn("操作时间",typeof(DateTime))
                });

                this.dvOrderDrugLimit = new DataView(this.dtOrderDrugLimit);

                this.fpOrderDrugLimit_Sheet1.DataSource = this.dvOrderDrugLimit;

                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.fpOrderDrugLimit_Sheet1, this.filePath);
            }
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        private void QueryAll()
        {
            this.dtOrderDrugLimit.Clear();
            this.alDrugLimit = this.specialLimitManager.QueryPharmacyLimit();
            if (alDrugLimit != null || this.alDrugLimit.Count > 0)
            {
                foreach (Neusoft.HISFC.Models.Order.PharmacyLimit obj in alDrugLimit)
                {

                    Neusoft.HISFC.Models.Pharmacy.Item item = null;
                    item = this.pharmacyManager.GetItem(obj.ID);

                    DataRow row = this.dtOrderDrugLimit.NewRow();
                    row["药品编码"] = obj.ID;
                    row["药品名称"] = item.Name;
                    row["是否需上级医生审核"] = obj.IsLeaderCheck;
                    row["是否需手工处方"] = obj.IsNeedRecipe;
                    row["有效标记"] = obj.IsValid;
                    row["备注"] = obj.Remark;
                    row["操作员"] = obj.Oper.ID;
                    row["操作时间"] = obj.Oper.OperTime;

                    this.dtOrderDrugLimit.Rows.Add(row);
                }
            }
            this.dtOrderDrugLimit.AcceptChanges();
        }

        /// <summary>
        /// 将药品插入表格
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int AddDrugToFp(Neusoft.HISFC.Models.Pharmacy.Item item)
        {
            
            try
            {
                DataRow row = this.dtOrderDrugLimit.NewRow();
                row["药品编码"] = item.ID;
                row["药品名称"] = item.Name;
                row["是否需上级医生审核"] = false;
                row["是否需手工处方"] = false;
                row["有效标记"] = false;
                row["备注"] = "";
                row["操作员"] = this.oper.ID;
                row["操作时间"] = DateTime.Now;

                this.dtOrderDrugLimit.Rows.Add(row);
            }
            catch 
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private int SaveData()
        {
            this.fpOrderDrugLimit.StopCellEditing();
            foreach (System.Data.DataRow row in dtOrderDrugLimit.Rows)
            {
                row.EndEdit();
            }
                        
            DataTable dtSave = this.dtOrderDrugLimit.GetChanges();
            DataTable ss = this.dtOrderDrugLimit.GetChanges(System.Data.DataRowState.Modified);
            if (dtSave != null)
            {
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.specialLimitManager.Connection);
                //t.BeginTransaction();
                this.specialLimitManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                                
                foreach (DataRow row in dtSave.Rows )
                {
                    Neusoft.HISFC.Models.Order.PharmacyLimit obj = new Neusoft.HISFC.Models.Order.PharmacyLimit();

                    obj.ID = row["药品编码"].ToString().Trim();
                    obj.Name = row["药品名称"].ToString().Trim();
                    obj.IsLeaderCheck = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否需上级医生审核"]);
                    obj.IsNeedRecipe = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["是否需手工处方"]);
                    obj.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["有效标记"]);
                    obj.Remark = row["备注"].ToString().Trim();
                    obj.Oper.ID = oper.ID;
                    obj.Oper.OperTime = this.specialLimitManager.GetDateTimeFromSysDateTime();

                    int iReturn = 0;
                    iReturn = this.specialLimitManager.UpdateSpecialLimit(obj);
                    if (iReturn == 0)
                    {
                        if (this.specialLimitManager.InsertSpecialLimit(obj) < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("插入医嘱药品限制信息出错!") + this.specialLimitManager.Err);
                            return -1;
                        }
                    }
                    else if (iReturn < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("更新医嘱药品限制信息出错!") + this.specialLimitManager.Err);
                        return -1;
                    }
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                this.dtOrderDrugLimit.AcceptChanges();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存成功"));
            }
            
            return 0;
        }

        private void ColumnSet()
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.FilePath = this.filePath;
            uc.SetColVisible(true, true, false, false);
            uc.SetDataTable(this.filePath, this.fpOrderDrugLimit.Sheets[0]);
            Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "显示设置";
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
            uc.DisplayEvent += new EventHandler(ucSetColumn_DisplayEvent);
            this.ucSetColumn_DisplayEvent(null, null);
        }

        private void ucSetColumn_DisplayEvent(object sender, EventArgs e)
        {

        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.SaveData();
            this.QueryAll();
            return base.OnSave(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryAll();
            return base.OnQuery(sender, neuObject);
        }

        public override Neusoft.FrameWork.WinForms.Forms.ToolBarService Init(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("列设置", "表格列设置", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "列设置":
                    this.ColumnSet();
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }

        #endregion

        private void ucDrugList1_ChooseDataEvent(FarPoint.Win.Spread.SheetView sv,int activeRow)
        {
            if (activeRow < 0)
            {
                return;
            }
            string drugCode = sv.Cells[activeRow, 0].Text;

            Neusoft.HISFC.Models.Pharmacy.Item item = this.pharmacyManager.GetItem(drugCode);
            if (item == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg(this.pharmacyManager.Err));
            }
            this.AddDrugToFp(item);
        }

        private void ucDrugLimitMaintenance_Load(object sender, EventArgs e)
        {
            this.Init();
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Inject
{
    public partial class ucKickback : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        private DataTable dtTable = null;
        private DataView dvView = null;
        private Neusoft.HISFC.BizLogic.Nurse.InjectManager.KickbackMgr kbManager = new Neusoft.HISFC.BizLogic.Nurse.InjectManager.KickbackMgr();

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            this.toolBarService.AddToolButton("添加", "添加新不良反应", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            return this.toolBarService;
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text.Trim())
            {
                case "添加":
                    this.Add();
                    break;
            }
        }

        private void Add()
        {
            ucKBHandler uc = new ucKBHandler();
            uc.IsAdd = true;
            uc.InsertItem();
            uc.UpdateEvent +=new UpdateSuccessHandler(uc_UpdateEvent);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        public ucKickback()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
            this.dtTable = new DataTable();
            this.dtTable.Columns.AddRange( new DataColumn[]
                                           {
                                           new DataColumn("ID",typeof(string)),
                                           new DataColumn("名称",typeof(string)),
                                           new DataColumn("拼音码",typeof(string)),
                                           new DataColumn("五笔码",typeof(string)),
                                           new DataColumn("自定义码",typeof(string)),
                                           new DataColumn("是否有效",typeof(string)),
                                           new DataColumn("备注",typeof(string))
                                           });

            this.neuSpread1_Sheet1.DataSource = this.dtTable;
            this.dtTable.PrimaryKey = new DataColumn[] { this.dtTable.Columns[0] };
            List<Neusoft.HISFC.Models.Nurse.Kickback> kbList = this.kbManager.QueryKickback();
            if (kbList == null || kbList.Count == 0)
            {
                return;
            }
            foreach (Neusoft.HISFC.Models.Nurse.Kickback kb in kbList)
            {
                DataRow dr = this.dtTable.NewRow();
                FillTable(dr, kb);
                this.dtTable.Rows.Add(dr);
            }

            this.dtTable.AcceptChanges();
            this.dvView = new DataView();
            this.dvView = this.dtTable.DefaultView;
            this.dvView.AllowNew = true;
            this.neuSpread1_Sheet1.DataSource = this.dvView;
        }

        private void FillTable(DataRow dr, Neusoft.HISFC.Models.Nurse.Kickback kb)
        {
            dr["ID"] = kb.ID;
            dr["名称"] = kb.Name;
            dr["拼音码"] = kb.SpellCode;
            dr["五笔码"] = kb.WBCode;
            dr["自定义码"] = kb.UserCode;
            if (kb.IsValid)
            {
                dr["是否有效"] = "是";
            }
            else
            {
                dr["是否有效"] = "否";
            }
            dr["备注"] = kb.Memo;
        }

        private void ucKickback_Load(object sender, EventArgs e)
        {
            this.InitTable();
        }

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            Neusoft.HISFC.Models.Nurse.Kickback kb = new Neusoft.HISFC.Models.Nurse.Kickback();
            kb.ID = this.neuSpread1_Sheet1.GetText(e.Row, 0);
            kb.Name = this.neuSpread1_Sheet1.GetText(e.Row, 1).Replace("\r\n","");
            kb.SpellCode = this.neuSpread1_Sheet1.GetText(e.Row, 2);
            kb.WBCode = this.neuSpread1_Sheet1.GetText(e.Row, 3);
            kb.UserCode = this.neuSpread1_Sheet1.GetText(e.Row, 4);
            if (this.neuSpread1_Sheet1.GetText(e.Row, 5).Trim().Equals("是"))
            {
                kb.IsValid = true;
            }
            else
            {
                kb.IsValid = false;
            }
            kb.Memo = this.neuSpread1_Sheet1.GetText(e.Row, 6).Replace("\r\n", "");
            kb.OperEnv.ID = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).ID;
            kb.OperEnv.Name = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Name;
            kb.OperEnv.OperTime = this.kbManager.GetDateTimeFromSysDateTime();

            ucKBHandler uc = new ucKBHandler();
            uc.IsAdd = false;
            uc.UpdateItem(kb);
            uc.UpdateEvent += new UpdateSuccessHandler(uc_UpdateEvent);
            
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        private void uc_UpdateEvent()
        {
            this.InitTable();
        }
    }
}

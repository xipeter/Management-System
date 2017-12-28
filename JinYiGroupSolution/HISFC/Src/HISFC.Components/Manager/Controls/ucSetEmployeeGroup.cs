using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Manager.Controls
{
    public partial class ucSetEmployeeGroup : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,
        Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucSetEmployeeGroup()
        {
            InitializeComponent();
            this.spread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spread1_Sheet1.DataAutoSizeColumns = false;
            this.spread1_Sheet1.Columns[0].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spread1_Sheet1.Columns[1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spread1_Sheet1.Columns[2].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spread1_Sheet1.Columns[3].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.spread1_Sheet1.DataAutoCellTypes = false;

            
        }

        

        #region 初始化

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            Neusoft.FrameWork.WinForms.Forms.ToolBarService toolService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
            toolService.AddToolButton("添加", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加.GetHashCode(), true, false, null);
            toolService.AddToolButton("修改", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X修改.GetHashCode(), true, false, null);
            toolService.AddToolButton("删除", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除.GetHashCode(), true, false, null);
            toolService.AddToolButton("打印", "", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印预览.GetHashCode(), true, false, null);
            this.Init();
            return toolService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "添加")
            {
                this.Add();
            }
            else if (e.ClickedItem.Text == "修改")
            {
                this.Modify();
            }
            else if (e.ClickedItem.Text == "删除")
            {
                this.Delete();
            }
            else if (e.ClickedItem.Text == "打印")
            {
                this.Print();
            }
        }
        /// <summary>
        /// 初始化DATASET
        /// </summary>
        private void InitDataSet()
        {
            DataTable table = new DataTable("人员");

            DataColumn dataColumn1 = new DataColumn("编码");
            dataColumn1.DataType = typeof(System.String);
            table.Columns.Add(dataColumn1);

            DataColumn dataColumn2 = new DataColumn("人员名称");
            dataColumn2.DataType = typeof(System.String);
            table.Columns.Add(dataColumn2);

            DataColumn dataColumn3 = new DataColumn("登录名");
            dataColumn3.DataType = typeof(System.String);
            table.Columns.Add(dataColumn3);

            DataColumn dataColumn4 = new DataColumn("管理员标记");
            dataColumn4.DataType = typeof(System.String);
            table.Columns.Add(dataColumn4);

            DataColumn dataColumn5 = new DataColumn("拼音");
            dataColumn5.DataType = typeof(System.String);
            table.Columns.Add(dataColumn5);

            DataColumn dataColumn6 = new DataColumn("五笔");
            dataColumn6.DataType = typeof(System.String);
            table.Columns.Add(dataColumn6);

            ds.Tables.Add(table);
        }
        protected DataSet ds = new DataSet();
        private bool AddDataIntoTable(System.Data.DataTable table, ArrayList list)
        {
            if (table == null)
            {
                return false;
            }
            try
            {
                table.Clear();

                foreach (Neusoft.HISFC.Models.Base.Employee obj in list)
                {
                    table.Rows.Add(new object[] { obj.ID, obj.Name, obj.User01, obj.IsManager, obj.SpellCode, obj.WBCode });
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return false;
            }
            return true;

        }

        Neusoft.HISFC.BizLogic.Manager.UserManager userManager = new Neusoft.HISFC.BizLogic.Manager.UserManager();
        protected virtual void RefreshUserList()
        {
            //{1D7BC020-92AC-431b-B27B-1BFBEB0E566B} 
            Neusoft.HISFC.Models.Base.Employee person = Neusoft.FrameWork.Management.Connection.Operator as Neusoft.HISFC.Models.Base.Employee;
            ArrayList al = new ArrayList();
            //填充人员列表 
            if (person.IsManager)
            {
                al = userManager.GetPeronList();
            }
            else
            {
                //不是管理员获取该操作员所在科室的人员
                al = userManager.GetPeronList(person.Dept.ID);
            }

            if (al == null)
            {
                MessageBox.Show(userManager.Err);
                return;
            }
            AddDataIntoTable(ds.Tables[0], al); //填充数据
            dv = new DataView(ds.Tables[0]);   //初始化 DataView 
            this.spread1.DataSource = dv;          // 绑定数据源
            this.spread1_Sheet1.Columns[3].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
        }
        protected DataView dv = null;
        #endregion

        #region 函数
        private void ModifyUser()
        {
            try
            {
                Neusoft.HISFC.Models.Base.Employee obj = GetPersonInfo();
                if (obj == null)
                {
                    return;
                }
                Forms.frmSetUserGroup f = new Forms.frmSetUserGroup(obj);
                f.ShowDialog();
                this.RefreshUserList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private Neusoft.HISFC.Models.Base.Employee GetPersonInfo()
        {
            Neusoft.HISFC.Models.Base.Employee p = new Neusoft.HISFC.Models.Base.Employee();
            try
            {
                p.ID = spread1_Sheet1.Cells[spread1_Sheet1.ActiveRowIndex, 0].Text;
                p.Name = spread1_Sheet1.Cells[spread1_Sheet1.ActiveRowIndex, 1].Text;
                p.User01 = spread1_Sheet1.Cells[spread1_Sheet1.ActiveRowIndex, 2].Text;
                p.IsManager = Convert.ToBoolean(spread1_Sheet1.Cells[spread1_Sheet1.ActiveRowIndex, 3].Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                p = null;
            }
            return p;
        }
        private void AddUser()
        {
            try
            {
                Forms.frmSetUserGroup f = new Forms.frmSetUserGroup(new Neusoft.HISFC.Models.Base.Employee());
                f.CheckLogName+=new Neusoft.HISFC.Components.Manager.Forms.frmSetUserGroup.CheckLogNameHandler(f_CheckLogName);
                f.ShowDialog();
                this.RefreshUserList();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private bool f_CheckLogName(string logName,ref string error)
        {
            if (ds.Tables.Count <= 0)
            {
                error="数据初始化错误！";
                return false;
            }
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["登录名"].ToString().ToLower() == logName.ToLower())
                {
                    error = "该用户[" + dr["人员名称"].ToString() + "]的登陆名：" + logName + "已存在！";
                    return false;
                }
            }
            return true;
        }
        protected override void OnLoad(EventArgs e)
        {
            Neusoft.FrameWork.WinForms.Forms.frmQuery q = this.iMaintenaceForm as Neusoft.FrameWork.WinForms.Forms.frmQuery;
            if (q != null)
                q.ShowQueryButton = false;

            base.OnLoad(e);
        }
        #endregion

        #region IMaintenanceControlable 成员
        private Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm iMaintenaceForm = null;

        public int Add()
        {
            this.AddUser();
            return 0;
        }

        public int Delete()
        {
            return 0;   
        }

        public int Export()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "请选择保存的路径和名称";
            sf.CheckFileExists = false;
            sf.CheckPathExists = true;
            sf.DefaultExt = "*.xls";
            sf.Filter = "(*.xls)|*.xls";
            DialogResult result = sf.ShowDialog();
            if (result == DialogResult.Cancel || sf.FileName == string.Empty)
            {
                return -1;
            }
            string filePath = sf.FileName;

            bool resultValue = this.spread1.SaveExcel(filePath, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly);
            return 0;
            //return this.spread1.Export();
        }

        public bool IsDirty
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        public int Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsHaveGrid = true;
            p.PrintPage(0, 0, this.panel1);
            return 0;
        }

        public int Query()
        {
            this.RefreshUserList();
            return 0;
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                return iMaintenaceForm;
            }
            set
            {
                iMaintenaceForm = value;
                if (iMaintenaceForm == null) return;
                iMaintenaceForm.ShowCopyButton = false;
                iMaintenaceForm.ShowCutButton = false;
                iMaintenaceForm.ShowDeleteButton = false;
                iMaintenaceForm.ShowImportButton = false;
                iMaintenaceForm.ShowNextRowButton = false;
                iMaintenaceForm.ShowPasteButton = false;
                iMaintenaceForm.ShowPreRowButton = false;
                iMaintenaceForm.ShowPrintConfigButton = false;
                iMaintenaceForm.ShowSaveButton = false;
            }
        }
        private void spread1_CellDoubleClick_1(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.ModifyUser();
        }
        public int Save()
        {
            return 0;
        }

        #endregion

        #region IMaintenanceControlable 成员


        public int Copy()
        {
            return 0;
        }

        public int Cut()
        {
            return 0;
        }

        public int Import()
        {
            return 0;
        }

        public int Init()
        {
            InitDataSet();
            this.RefreshUserList();
            this.spread1_Sheet1.Columns[0].Width = 100;
            this.spread1_Sheet1.Columns[1].Width = 200;
            this.spread1_Sheet1.Columns[2].Width = 200;
            this.spread1_Sheet1.Columns[3].Width = 100;
            this.spread1_Sheet1.Columns[4].Width = 100;
            this.spread1_Sheet1.Columns[5].Width = 100;
            return 0;
        }

        public int Modify()
        {
            ModifyUser();
            return 0;
        }

        public int NextRow()
        {
            return 0;
        }

        public int Paste()
        {
            return 0;
        }

        public int PreRow()
        {
            return 0;
        }

        public int PrintConfig()
        {
            return 0;
        }

        public int PrintPreview()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsHaveGrid = true;
            p.PrintPreview( this.panel1);
            return 0;
        }

        #endregion

        #region 事件
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string temp = " like  '" + this.txtFilter.Text + "%' ";
                dv.RowFilter = "拼音" + temp + " or " + "五笔" + temp + " or " + "编码" + temp + " or " + "人员名称" + temp + " or " + "登录名" + temp;
            }
            catch (Exception ee)
            {
                string Error = ee.Message;
                txtFilter.Text = "";
            }
        }
        #endregion




    }
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 排班维护
    /// </summary>
    public partial class ucSchema : UserControl
    {
        public ucSchema()
        {
            InitializeComponent();

            this.fpSpread1.Change += new ChangeEventHandler(fpSpread1_Change);
            this.fpSpread1.EditModeOff += new EventHandler(fpSpread1_EditModeOff);
            this.fpSpread1.EditModeOn += new System.EventHandler(this.fpSpread1_EditModeOn);
            this.fpSpread1.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpSpread1_EditChange);
			
        }

        #region 域
        //--------------------------------------------------------------------
        /// <summary>
        /// 模板集合
        /// </summary>
        private DataTable dsItems;
        private DataView dv;
        /// <summary>
        /// 集合
        /// </summary>
        private ArrayList al;
        /// <summary>
        /// 出诊模板管理类
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Registration.Schema SchemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 科室管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager Mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();

        Neusoft.FrameWork.Public.ObjectHelper noonHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        
        private DateTime seeDate = DateTime.MinValue;
        /// <summary>
        /// 出诊日期
        /// </summary>
        public DateTime SeeDate
        {
            get { return seeDate; }
            set { seeDate = value.Date; }
        }
        /// <summary>
        /// 模板类型
        /// </summary>
        public Neusoft.HISFC.Models.Base.EnumSchemaType SchemaType = Neusoft.HISFC.Models.Base.EnumSchemaType.Dept;
        
        /// <summary>
        /// 科室列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbDept = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 午别列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbNoon = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 医生列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbDoct = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 医生类别
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbDoctType = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 停诊原因列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbStopRn = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 挂号级别列表
        /// </summary>
        private Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup lbRegLevel = new Neusoft.FrameWork.WinForms.Controls.NeuListBoxPopup();
        /// <summary>
        /// 当前科室
        /// </summary>
        public Neusoft.HISFC.Models.Base.Department Dept
        {
            set
            {
                dept = value;
                if (dept == null)
                {
                    dept = new Neusoft.HISFC.Models.Base.Department();
                }
            }
        }
        /// <summary>
        /// 当前科室
        /// </summary>
        private Neusoft.HISFC.Models.Base.Department dept = new Neusoft.HISFC.Models.Base.Department();

        /// <summary>
        /// 预约默认时间段
        /// </summary>
        private int timeZone = 0;

        /// <summary>
        /// 排班是否输入医生类别
        /// </summary>
        private bool IsShowDoctType = false;
        /// <summary>
        /// 是否显示挂号级别
        /// </summary>
        private bool IsShowRegLevel = false;
        public string SearchEmployee
        {
            get
            {
                return this.searchEmpl;
            }

            set
            {
                this.searchEmpl = value;

                if (value != "" && value != null)
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        if (this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctID) == value)
                        {
                            this.fpSpread1.Focus();
                            this.fpSpread1_Sheet1.ActiveRowIndex = i;
                            this.fpSpread1_Sheet1.SetActiveCell(i, (int)cols.DoctName, false);
                            break;
                        }
                    }
                }
            }
        }

        private string searchEmpl;

        //add by niuxinyuan

        public string SearchDepartment
        {
            get
            {
                return this.searchDept;
            }

            set
            {
                this.searchDept = value;

                if (value != "" && value != null)
                {
                    for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                    {
                        if (this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptID) == value)
                        {
                            this.fpSpread1.Focus();
                            this.fpSpread1_Sheet1.ActiveRowIndex = i;
                            this.fpSpread1_Sheet1.SetActiveCell(i, (int)cols.DeptName, false);
                            break;
                        }
                    }
                }
            }
        }

        private string searchDept;

        #endregion
        #region 列
        protected enum cols
        {
            /// <summary>
            /// ID
            /// </summary>
            ID,
            /// <summary>
            /// 科室代码
            /// </summary>
            DeptID,
            /// <summary>
            /// 科室名称
            /// </summary>
            DeptName,
            /// <summary>
            /// 医生代码
            /// </summary>
            DoctID,
            /// <summary>
            /// 医生名称
            /// </summary>
            DoctName,
            /// <summary>
            /// 医生类别
            /// </summary>
            DoctType,
            /// <summary>
            /// 挂号级别代码
            /// </summary>
            RegLevelCode,
            /// <summary>
            /// 挂号级别名次
            /// </summary>
            RegLevelName,
            /// <summary>
            /// 午别代码
            /// </summary>
            Noon,
            /// <summary>
            /// 开始时间
            /// </summary>
            BeginTime,
            /// <summary>
            /// 结束时间
            /// </summary>
            EndTime,
            /// <summary>
            /// 挂号限额
            /// </summary>
            RegLmt,
            /// <summary>
            /// 预约限额
            /// </summary>
            TelLmt,
            /// <summary>
            /// 特诊限额
            /// </summary>
            SpeLmt,
            /// <summary>
            /// 是否加号
            /// </summary>
            IsAppend,
            /// <summary>
            /// 是否有效
            /// </summary>
            Valid,
            /// <summary>
            /// 停诊原因
            /// </summary>
            StopReasonID,
            StopReasonName,
            Memo,
            Reged,
            Teling,
            Teled,
            Sped,
            StopID,
            StopDate,
            TempID
        }
        #endregion

        #region 初始化

        protected virtual void SetFarpoint()
        {
            this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)cols.BeginTime].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)cols.EndTime].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)cols.Sped].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)cols.IsAppend].Visible = false;
            this.fpSpread1_Sheet1.Columns[(int)cols.TempID].Visible = false;

            
        }
        /// <summary>
        ///  初始化
        /// </summary>
        /// <param name="basevar"></param>
        /// <param name="w"></param>
        /// <param name="type"></param>
        public void Init(DateTime seeDate, Neusoft.HISFC.Models.Base.EnumSchemaType type)
        {
            this.SeeDate = seeDate.Date;
            this.SchemaType = type;

            this.initDataSet();

            this.initNoon();
            this.initDept();
            this.initStopRn();

            if (type == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct)
            {
                this.initDoct();
                this.initDoctType();
                this.initRegLevl();
            }

            this.visible(false);

            this.initFp();
            SetFarpoint();

            //默认预约时间段
            Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();

            string rtn = ctlMgr.QueryControlerInfo("400018");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.timeZone = int.Parse(rtn);

            //排班是否显示医生类别
            rtn = ctlMgr.QueryControlerInfo("400025");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsShowDoctType = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            //医生排班是否到挂号级别
            rtn = ctlMgr.QueryControlerInfo("400030");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.IsShowRegLevel = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);
            this.initNoon();
        }

        /// <summary>
        /// Init DataSet
        /// </summary>
        private void initDataSet()
        {

            dsItems = new DataTable("Schema");

            dsItems.Columns.AddRange(new DataColumn[]
			{
				new DataColumn("ID",System.Type.GetType("System.String")),
				new DataColumn("DeptID",System.Type.GetType("System.String")),
				new DataColumn("DeptName",System.Type.GetType("System.String")),
				new DataColumn("DoctID",System.Type.GetType("System.String")),
				new DataColumn("DoctName",System.Type.GetType("System.String")),
				new DataColumn("DoctType",System.Type.GetType("System.String")),
				new DataColumn("RegLevelCode",System.Type.GetType("System.String")),
				new DataColumn("RegLevelName",System.Type.GetType("System.String")),
				new DataColumn("Noon",System.Type.GetType("System.String")),
				new DataColumn("BeginTime",System.Type.GetType("System.DateTime")),
				new DataColumn("EndTime",System.Type.GetType("System.DateTime")),
				new DataColumn("RegLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("TelLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("SpeLmt",System.Type.GetType("System.Decimal")),
				new DataColumn("IsAppend",System.Type.GetType("System.Boolean")),	
				new DataColumn("Valid",System.Type.GetType("System.Boolean")),	
				new DataColumn("StopReasonID",System.Type.GetType("System.String")),
				new DataColumn("StopReasonName",System.Type.GetType("System.String")),
				new DataColumn("Memo",System.Type.GetType("System.String")),
				new DataColumn("Reged",System.Type.GetType("System.Decimal")),
				new DataColumn("Teling",System.Type.GetType("System.Decimal")),
				new DataColumn("Teled",System.Type.GetType("System.Decimal")),
				new DataColumn("Sped",System.Type.GetType("System.Decimal")),
				new DataColumn("StopID",System.Type.GetType("System.String")),
				new DataColumn("StopDate",System.Type.GetType("System.DateTime")),
                new DataColumn("TempletID",System.Type.GetType("System.String"))
			});

        }
        /// <summary>
        /// 初始化farpoint
        /// </summary>
        private void initFp()
        {
            InputMap im;

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpread1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F3, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 初始化无别列表
        /// </summary>
        private void initNoon()
        {
            this.lbNoon.ItemSelected += new EventHandler(lbNoon_SelectItem);
            this.groupBox1.Controls.Add(this.lbNoon);
            this.lbNoon.BackColor = this.label1.BackColor;
            this.lbNoon.Font = new Font("宋体", 11F);
            this.lbNoon.BorderStyle = BorderStyle.None;
            this.lbNoon.Cursor = Cursors.Hand;
            this.lbNoon.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbNoon.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();
            //得到午别
            al = noonMgr.Query();

            if (al == null)
            {
                MessageBox.Show("获取午别信息时出错!" + noonMgr.Err, "提示");
                return;
            }

            this.lbNoon.AddItems(al);
        }

        void lbNoon_ItemSelected(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 初始化出诊科室
        /// </summary>
        private void initDept()
        {
            this.lbDept.ItemSelected += new EventHandler(lbDept_SelectItem);
            this.groupBox1.Controls.Add(this.lbDept);
            this.lbDept.BackColor = this.label1.BackColor;
            this.lbDept.Font = new Font("宋体", 11F);
            this.lbDept.BorderStyle = BorderStyle.None;
            this.lbDept.Cursor = Cursors.Hand;
            this.lbDept.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbDept.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);
                        
            //得到科室列表
            al = Mgr.QueryRegDepartment();
            if (al == null)
            {
                MessageBox.Show("获取门诊科室列表时出错!" + Mgr.Err, "提示");
                return;
            }

            this.lbDept.AddItems(al);
            this.lbDept.BringToFront();
        }
        /// <summary>
        /// 初始化出诊医生
        /// </summary>
        private void initDoct()
        {
            this.lbDoct.ItemSelected += new EventHandler(lbDoct_SelectItem);
            this.groupBox1.Controls.Add(this.lbDoct);
            this.lbDoct.BackColor = this.label1.BackColor;
            this.lbDoct.Font = new Font("宋体", 11F);
            this.lbDoct.BorderStyle = BorderStyle.None;
            this.lbDoct.Cursor = Cursors.Hand;
            this.lbDoct.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbDoct.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            //得到医生列表
            al = Mgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (al == null)
            {
                MessageBox.Show("获取门诊医生列表时出错!" + Mgr.Err, "提示");
                return;
            }

            this.lbDoct.AddItems(al);
            this.lbDoct.BringToFront();
        }

        /// <summary>
        /// 初始化医生类别
        /// </summary>
        private void initDoctType()
        {
            this.lbDoctType.ItemSelected += new EventHandler(lbDoctType_SelectItem);
            this.groupBox1.Controls.Add(this.lbDoctType);
            this.lbDoctType.BackColor = this.label1.BackColor;
            this.lbDoctType.Font = new Font("宋体", 11F);
            this.lbDoctType.BorderStyle = BorderStyle.None;
            this.lbDoctType.Cursor = Cursors.Hand;
            this.lbDoctType.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbDoctType.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //得到医生类别
            al = conMgr.QueryConstantList("DoctType");
            if (al == null)
            {
                MessageBox.Show("获取医生类别时出错!" + conMgr.Err, "提示");
                return;
            }

            this.lbDoctType.AddItems(al);
        }

        /// <summary>
        /// 初始化停诊原因列表
        /// </summary>
        private void initStopRn()
        {
            this.lbStopRn.ItemSelected += new EventHandler(lbStopRn_SelectItem);
            this.groupBox1.Controls.Add(this.lbStopRn);
            this.lbStopRn.BackColor = this.label1.BackColor;
            this.lbStopRn.Font = new Font("宋体", 11F);
            this.lbStopRn.BorderStyle = BorderStyle.None;
            this.lbStopRn.Cursor = Cursors.Hand;
            this.lbStopRn.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbStopRn.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            Neusoft.HISFC.BizProcess.Integrate.Manager conMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            //得到医生类别
            al = conMgr.QueryConstantList("StopReason");
            if (al == null)
            {
                MessageBox.Show("获取停诊原因时出错!" + conMgr.Err, "提示");
                return;
            }

            this.lbStopRn.AddItems(al);
        }
        /// <summary>
        /// 生成挂号级别列表
        /// </summary>
        private void initRegLevl()
        {
            this.lbRegLevel.ItemSelected += new EventHandler(lbRegLevel_SelectItem);
            this.groupBox1.Controls.Add(this.lbRegLevel);
            this.lbRegLevel.BackColor = this.label1.BackColor;
            this.lbRegLevel.Font = new Font("宋体", 11F);
            this.lbRegLevel.BorderStyle = BorderStyle.None;
            this.lbRegLevel.Cursor = Cursors.Hand;
            this.lbRegLevel.Location = new Point(this.label1.Left + 1, this.label1.Top + 1);
            this.lbRegLevel.Size = new Size(this.label1.Width - 2, this.label1.Height - 2);

            Neusoft.HISFC.BizLogic.Registration.RegLevel reglevlMgr = new Neusoft.HISFC.BizLogic.Registration.RegLevel();
            //得到挂号级别
            al = reglevlMgr.Query(true);

            this.lbRegLevel.AddItems(al);
        }

        protected virtual int InitNoon()
        {
          ArrayList alNoon =  this.noonMgr.Query();

          this.noonHelper.ArrayObject = alNoon;
          return 1;
        }
        #endregion

        #region 查找

        /// <summary>
        /// 根据午别代码得到午别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getNoonNameByID(string id)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.lbNoon.NeuItems)
            {
                if (obj.ID == id) return obj.Name;
            }
            return id;
        }
        /// <summary>
        /// 根据午别名称得到午别代码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getNoonIDByName(string name)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.lbNoon.NeuItems)
            {
                if (obj.Name == name) return obj.ID;
            }
            return "";
        }
        /// <summary>
        /// 获取午别结束时间
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private DateTime getNoonEndDate(string ID)
        {
            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.lbNoon.NeuItems)
            {
                if (obj.ID == ID) return (obj as Neusoft.HISFC.Models.Base.Noon).EndTime;
            }
            return DateTime.MinValue;
        }
        /// <summary>
        /// 根据代码获得医生类别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getTypeNameByID(string id)
        {
            if (id == null || id.Trim() == "")
            {
                return "";
            }

            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.lbDoctType.NeuItems)
            {
                if (obj.ID == id) return obj.Name;
            }

            return id;
        }
        /// <summary>
        /// 根据名称获取医生类别代码
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private string getTypeIDByName(string Name)
        {
            if (Name == null || Name.Trim() == "")
            {
                return "";
            }

            foreach (Neusoft.FrameWork.Models.NeuObject obj in this.lbDoctType.NeuItems)
            {
                if (obj.Name == Name) return obj.ID;
            }

            return "";
        }
        #endregion

        #region 公有
        /// <summary>
        /// 查询一日某出诊科室排班记录
        /// </summary>
        /// <param name="deptID"></param>
        public void Query(string deptID)
        {
            this.al = this.SchemaMgr.Query(this.SeeDate, this.SchemaType, deptID);
            if (al == null)
            {
                MessageBox.Show("查询排班信息出错!" + this.SchemaMgr.Err, "提示");
                return;
            }

            dsItems.Rows.Clear();

            try
            {
                foreach (Neusoft.HISFC.Models.Registration.Schema schema in al)
                {

                    dsItems.Rows.Add(new object[]
					{
						schema.Templet.ID,
						schema.Templet.Dept.ID,
						schema.Templet.Dept.Name,
						schema.Templet.Doct.ID,
						schema.Templet.Doct.Name,
						this.getTypeNameByID(schema.Templet.DoctType.ID),
						schema.Templet.RegLevel.ID,
						schema.Templet.RegLevel.Name,
						this.getNoonNameByID(schema.Templet.Noon.ID),
						schema.Templet.Begin,
						schema.Templet.End,
						schema.Templet.RegQuota,
						schema.Templet.TelQuota,
						schema.Templet.SpeQuota,
						schema.Templet.IsAppend,
						schema.Templet.IsValid,
						schema.Templet.StopReason.ID,
						schema.Templet.StopReason.Name,
						schema.Templet.Memo,
						schema.RegedQTY,
						schema.TelingQTY,
						schema.TeledQTY,
						schema.SpedQTY,
						schema.Templet.Stop.ID,
						schema.Templet.Stop.OperTime  });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("查询排班信息生成DataSet时出错!" + e.Message, "提示");
                return;
            }
            dsItems.AcceptChanges();

            dv = dsItems.DefaultView;
            //if (this.fpSpread1_Sheet1.Rows.Count > 0)
            //    this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.Rows.Count);
            this.fpSpread1_Sheet1.DataSource = dv;

            this.SetFpFormat();

            //if (!this.IsShowDoctType)
            //{
            //    this.Span();
            //}
            this.DisplayColor();
        }

        /// <summary>
        /// 抑止重复显示
        /// </summary>
        private void Span()
        {
            ///
            int colLastDept = 0;
            int colLastDoct = 0;
            int colLastNoon = 0;
            int rowCnt = this.fpSpread1_Sheet1.RowCount;

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

            for (int i = 0; i < rowCnt; i++)
            {

                if (i > 0 && this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptName) != this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName))
                {
                    if (i - colLastDept > 1)
                    {
                        this.fpSpread1_Sheet1.Models.Span.Add(colLastDept, (int)cols.DeptName, i - colLastDept, 1);
                    }

                    colLastDept = i;
                }

                //最后一行处理
                if (i > 0 && i == rowCnt - 1 && this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptName) == this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName))
                {
                    this.fpSpread1_Sheet1.Models.Span.Add(colLastDept, (int)cols.DeptName, i - colLastDept + 1, 1);
                }

                ///医生
                ///
                if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct&&
                    i > 0 &&
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctName) != this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DoctName))
                {
                    if (i - colLastDoct > 1)
                    {
                        this.fpSpread1_Sheet1.Models.Span.Add(colLastDoct, (int)cols.DoctName, i - colLastDoct, 1);
                    }
                    colLastDoct = i;
                }

                //最后一行
                if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct &&
                    i > 0 &&
                    i == rowCnt - 1 && this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctName) == this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DoctName))
                {
                    this.fpSpread1_Sheet1.Models.Span.Add(colLastDoct, (int)cols.DoctName, i - colLastDoct + 1, 1);
                }

                ///午别
                ///
                if (i > 0 &&
                    (this.fpSpread1_Sheet1.GetText(i, (int)cols.Noon) != this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.Noon) ||
                     this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptName) != this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName) ||
                     this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctName) != this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DoctName)))
                {
                    if (i - colLastNoon > 1)
                    {
                        this.fpSpread1_Sheet1.Models.Span.Add(colLastNoon, (int)cols.Noon, i - colLastNoon, 1);
                    }
                    colLastNoon = i;
                }
                //最后一行
                if (i > 0 && i == rowCnt - 1 &&
                    (this.fpSpread1_Sheet1.GetText(i, (int)cols.Noon) == this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.Noon) ||
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptName) == this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DeptName) ||
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctName) == this.fpSpread1_Sheet1.GetText(i - 1, (int)cols.DoctName)))
                {
                    this.fpSpread1_Sheet1.Models.Span.Add(colLastNoon, (int)cols.Noon, i - colLastNoon + 1, 1);
                }

            }
        }


        private void DisplayColor()
        {
            int rowCnt = this.fpSpread1_Sheet1.RowCount;

            for (int i = 0; i < rowCnt; i++)
            {
                //显示行状态
                //if (this.fpSpread1_Sheet1.GetText(i, (int)cols.Valid).ToUpper() == "FALSE")
                //{
                //    this.fpSpread1_Sheet1.Cells[i, (int)cols.BeginTime].BackColor = Color.Red;
                //    this.fpSpread1_Sheet1.Cells[i, (int)cols.EndTime].BackColor = Color.Red;
                //}
                this.showColor(i);
            }
        }
        /// <summary>
        /// 设置Farpoint显示格式
        /// </summary>
        private void SetFpFormat()
        {
            FarPoint.Win.Spread.CellType.NumberCellType numbCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numbCellType.DecimalPlaces = 0;
            numbCellType.MaximumValue = 9999;
            numbCellType.MinimumValue = 0;

            FarPoint.Win.Spread.CellType.TextCellType txtCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtCellType.ReadOnly = true;

            FarPoint.Win.Spread.CellType.DateTimeCellType dtCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
            dtCellType.UserDefinedFormat = "HH:mm";

            //科室模板
            if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
            {
                #region ""
                this.fpSpread1_Sheet1.Columns[(int)cols.ID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DeptID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctName].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctType].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelCode].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelName].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopReasonID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.Sped].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopDate].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.Memo].Visible = false;

                //没办法,要求压缩重复显示项，就不能再让人修改了，阉了它
                //if (!this.IsShowDoctType)
                //{
                //    if (this.fpSpread1_Sheet1.RowCount > 0)
                //    {
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.DeptName, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.DeptName].CellType = txtCellType;
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.Noon, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.Noon].CellType = txtCellType;
                //    }
                //}

                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].CellType = numbCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].ForeColor = Color.Red;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].Font = new Font("宋体", 9, FontStyle.Bold);
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].CellType = numbCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].ForeColor = Color.Blue;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].Font = new Font("宋体", 9, FontStyle.Bold);
                this.fpSpread1_Sheet1.Columns[(int)cols.BeginTime].CellType = dtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.EndTime].CellType = dtCellType;

                this.fpSpread1_Sheet1.Columns[(int)cols.DeptName].Width = 100F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Noon].Width = 70F;
                this.fpSpread1_Sheet1.Columns[(int)cols.BeginTime].Width = 60F;
                this.fpSpread1_Sheet1.Columns[(int)cols.EndTime].Width = 60F;

                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.IsAppend].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Valid].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopReasonName].Width = 100F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Memo].Width = 160F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].Width = 40F;
                #endregion
            }
            else
            {
                #region ""
                this.fpSpread1_Sheet1.Columns[(int)cols.ID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DeptID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelCode].Visible = false;

                if (this.IsShowDoctType)
                {
                    this.fpSpread1_Sheet1.Columns[(int)cols.DoctType].Visible = true;
                }
                else
                {
                    this.fpSpread1_Sheet1.Columns[(int)cols.DoctType].Visible = false;
                }

                if (this.IsShowRegLevel)
                {
                    this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelName].Visible = true;
                }
                else
                {
                    this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelName].Visible = false;
                }

                this.fpSpread1_Sheet1.Columns[(int)cols.StopReasonID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopID].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopDate].Visible = false;
                this.fpSpread1_Sheet1.Columns[(int)cols.Memo].Visible = false;

                //没办法,要求压缩重复显示项，就不能再让人修改了，阉了它
                //if (!this.IsShowDoctType)
                //{
                //    if (this.fpSpread1_Sheet1.RowCount > 0)
                //    {
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.DeptName, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.DeptName].CellType = txtCellType;
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.DoctName, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.DoctName].CellType = txtCellType;
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.Noon, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.Noon].CellType = txtCellType;
                //        this.fpSpread1_Sheet1.Cells[0, (int)cols.DoctType, this.fpSpread1_Sheet1.RowCount - 1, (int)cols.DoctType].CellType = txtCellType;
                //    }
                //}

                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.Sped].CellType = txtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.Sped].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].CellType = numbCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].ForeColor = Color.Red;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].Font = new Font("宋体", 9, FontStyle.Bold);
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].CellType = numbCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].ForeColor = Color.Blue;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].Font = new Font("宋体", 9, FontStyle.Bold);
                this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].CellType = numbCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].ForeColor = Color.Fuchsia;
                this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].Font = new Font("宋体", 9, FontStyle.Bold);
                this.fpSpread1_Sheet1.Columns[(int)cols.BeginTime].CellType = dtCellType;
                this.fpSpread1_Sheet1.Columns[(int)cols.EndTime].CellType = dtCellType;

                this.fpSpread1_Sheet1.Columns[(int)cols.DeptName].Width = 90F;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctName].Width = 80F;
                this.fpSpread1_Sheet1.Columns[(int)cols.DoctType].Width = 50F;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLevelName].Width = 50F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Noon].Width = 50F;
                this.fpSpread1_Sheet1.Columns[(int)cols.BeginTime].Width = 50F;
                this.fpSpread1_Sheet1.Columns[(int)cols.EndTime].Width = 50F;
                this.fpSpread1_Sheet1.Columns[(int)cols.RegLmt].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.TelLmt].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.SpeLmt].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.IsAppend].Width = 35F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Valid].Width = 35F;
                this.fpSpread1_Sheet1.Columns[(int)cols.StopReasonName].Width = 100F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Reged].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teling].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Teled].Width = 40F;
                this.fpSpread1_Sheet1.Columns[(int)cols.Sped].Width = 40F;
                #endregion
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Add()
        {
            if (dsItems.GetChanges(DataRowState.Deleted) != null)
            {
                if (MessageBox.Show("数据已经发生变化,点[确定]将保存上次操作!\n是否继续 ?", "提示 ", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else 
                {
                    Save();
                }
            }
            
            DataRowView dr = dv.AddNew();

            dr["ID"] = this.SchemaMgr.GetSequence("Registration.DeptSchema.ID");
            if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
            {
                dr["DoctID"] = "None";
            }

            //默认同上一行的科室、医生相同
            if (dv.Count > 1)
            {
                DataRowView temp = dv[dv.Count - 2];
                dr["DeptID"] = temp["deptID"];
                dr["DeptName"] = temp["DeptName"];

                if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct)
                {
                    dr["DoctID"] = temp["DoctID"];
                    dr["DoctName"] = temp["DoctName"];
                    dr["DoctType"] = temp["DoctType"];
                    dr["RegLevelCode"] = temp["RegLevelCode"];
                    dr["RegLevelName"] = temp["RegLevelName"];
                }
            }
            else//Count = 1 
            {
                dr["DeptID"] = dept.ID;
                dr["DeptName"] = dept.Name;
            }

            dr["RegLmt"] = 0;
            dr["TelLmt"] = 0;
            dr["SpeLmt"] = 0;
            dr["BeginTime"] = this.seeDate;
            dr["EndTime"] = this.seeDate;
            dr["Reged"] = 0;
            dr["Teling"] = 0;
            dr["Teled"] = 0;
            dr["Sped"] = 0;
            dr["Valid"] = true;

            dr.EndEdit();

            this.fpSpread1_Sheet1.ActiveRowIndex = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1.Focus();

            string deptId = "";

            deptId = this.fpSpread1_Sheet1.GetText(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptID);


            if (deptId == null || deptId == "")
            {
                this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptName, false);
            }
            else
            {
                if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
                {
                    this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
                }
                else
                {
                    this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DoctName, false);
                }
            }

        }
        /// <summary>
        /// 添加一条模板记录
        /// </summary>
        /// <param name="templet"></param>
        public void Add(Neusoft.HISFC.Models.Registration.SchemaTemplet templet)
        {
            DataRowView dr = dv.AddNew();

            dr["ID"] = this.SchemaMgr.GetSequence("Registration.DeptSchema.ID");
            dr["DeptID"] = templet.Dept.ID;
            dr["DeptName"] = templet.Dept.Name;
            dr["DoctID"] = templet.Doct.ID;
            dr["DoctName"] = templet.Doct.Name;
            dr["DoctType"] = this.getTypeNameByID(templet.DoctType.ID);
            dr["RegLevelCode"] = templet.RegLevel.ID;
            dr["RegLevelName"] = templet.RegLevel.Name;
            dr["Noon"] = this.getNoonNameByID(templet.Noon.ID);
            dr["BeginTime"] = templet.Begin;
            dr["EndTime"] = templet.End;
            dr["RegLmt"] = templet.RegQuota;
            dr["TelLmt"] = templet.TelQuota;
            dr["SpeLmt"] = templet.SpeQuota;
            dr["IsAppend"] = templet.IsAppend;
            dr["Valid"] = templet.IsValid;
            dr["Memo"] = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( templet.Memo, "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\", "*", "^", "@", "!");
               
            dr["Reged"] = 0m;
            dr["Teling"] = 0m;
            dr["Teled"] = 0m;
            dr["Sped"] = 0m;
            dr["StopReasonID"] = templet.StopReason.ID;
            dr["StopReasonName"] =  Neusoft.FrameWork.Public.String.TakeOffSpecialChar(templet.StopReason.Name, "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\", "*", "^", "@", "!");
            dr["TempletID"] = templet.ID;
            dr.EndEdit();

        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Del()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (row < 0 || this.fpSpread1_Sheet1.RowCount == 0) return;

            if (MessageBox.Show("是否删除该条排班?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.fpSpread1.Focus();
                return;
            }

            this.fpSpread1.StopCellEditing();

            if (decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)cols.Reged].Text) > 0 ||
                decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)cols.Teling].Text) > 0 ||
                decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)cols.Teled].Text) > 0 ||
                decimal.Parse(this.fpSpread1_Sheet1.Cells[row, (int)cols.Sped].Text) > 0)
            {
                MessageBox.Show("该排班信息已经使用,不能删除!", "提示");
                return;
            }

            if (this.ValidByIDForUpdate(this.fpSpread1_Sheet1.Cells[row,(int)cols.ID].Text) < 0)
            {
                return;
            }

            this.fpSpread1_Sheet1.Rows.Remove(row, 1);

            this.fpSpread1.Focus();
        }
        /// <summary>
        /// 删除全部
        /// </summary>
        public void DelAll()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) return;

            if (MessageBox.Show("是否删除全部排班?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.fpSpread1.Focus();
                return;
            }

            for (int i = this.fpSpread1_Sheet1.RowCount - 1; i >= 0; i--)
            {
                //{8FCEF5D9-FC8B-493c-8EE6-C00E67A02C74}

                if (this.fpSpread1_Sheet1.GetText(i, (int)cols.Reged) != "0" ||
                    //{D9040E13-6123-4b77-85A0-223EE3C93CBD}
                    Neusoft.FrameWork.Function.NConvert.ToInt32( this.fpSpread1_Sheet1.GetText(i, (int)cols.Sped)) != 0 ||
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.Teled) != "0" ||
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.Teling) != "0")
                {
                    MessageBox.Show("第"+(i + 1).ToString() + "行排班已经执行,不能修改");
                    return;
                }
            }

            for (int i = this.fpSpread1_Sheet1.RowCount - 1; i >= 0; i--)
            {
               this.fpSpread1_Sheet1.Rows.Remove(i, 1);
             
            }
            this.fpSpread1.Focus();
        }

        ////========================

        //private DataTable SetTable(DataTable dt)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dt.Rows[i]["DeptID"] = this.fpSpread1_Sheet1.Cells[i, (int)cols.DeptID].Text;
        //        dt.Rows[i]["Noon"] = this.fpSpread1_Sheet1.Cells[i, (int)cols.Noon].Text;
        //    }
        //    return dt;
        //}

        ///=======================

        /// <summary>
        /// 保存
        /// </summary>
        public int Save()
        {
            this.fpSpread1.StopCellEditing();

            if (fpSpread1_Sheet1.RowCount > 0)
            {
                dsItems.Rows[fpSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }

            //增加
            DataTable dtAdd = dsItems.GetChanges(DataRowState.Added);
            //修改
            DataTable dtModify = dsItems.GetChanges(DataRowState.Modified);
            //删除
            DataTable dtDel = dsItems.GetChanges(DataRowState.Deleted);
            
            //dtAdd = this.SetTable(dtAdd);
            //验证
            if (Valid(dtAdd) == -1) return -1;
            if (Valid(dtModify) == -1) return -1;
            //转为实体集合
            ArrayList alAdd = this.GetChanges(dtAdd);
            if (alAdd == null) return -1;
            ArrayList alModify = this.GetChanges(dtModify);
            if (alModify == null) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(SchemaMgr.con);
            //SQLCA.BeginTransaction();

            this.SchemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string rtnText = "";

            if (dtDel != null)
            {
                dtDel.RejectChanges();

                if (this.SaveDel(this.SchemaMgr, dtDel, ref rtnText) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(rtnText, "提示");
                    return -1;
                }
            }

            if (this.SaveAdd(this.SchemaMgr, alAdd, ref rtnText) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(rtnText, "提示");
                return -1;
            }

            if (this.SaveModify(this.SchemaMgr, alModify, ref rtnText) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(rtnText, "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            dsItems.AcceptChanges();
            this.SetFpFormat();

            return 0;
        }
        /// <summary>
        /// 是否修改数据？
        /// </summary>
        /// <returns></returns>
        public bool IsChange()
        {
            this.fpSpread1.StopCellEditing();

            if (fpSpread1_Sheet1.RowCount > 0)
            {
                dsItems.Rows[fpSpread1_Sheet1.ActiveRowIndex].EndEdit();
            }

            DataTable dt = dsItems.GetChanges();

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存增加的记录
        /// </summary>
        /// <param name="schMgr"></param>
        /// <param name="alAdd"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveAdd(Neusoft.HISFC.BizLogic.Registration.Schema schMgr, ArrayList alAdd, ref string Err)
        {
            
            try
            {
                foreach (Neusoft.HISFC.Models.Registration.Schema schema in alAdd)
                {
                    if (schMgr.Insert(schema) == -1)
                    {
                        if (SchemaMgr.DBErrCode == 1)
                        {


                            if (schema.Templet.EnumSchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct)
                            {
                                Err = "医生：【" + schema.Templet.Doct.Name + "】在" + "【" + schema.Templet.Dept.Name + "】" + "午别为：【" + this.noonMgr.Query(schema.Templet.Noon.ID) + "】已经有排班记录";
                            }
                        }
                        else
                        {
                            Err = schMgr.Err;
                        }
                        return -1;
                    }
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 保存修改记录
        /// </summary>
        /// <param name="templetMgr"></param>
        /// <param name="alModify"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveModify(Neusoft.HISFC.BizLogic.Registration.Schema schMgr, ArrayList alModify, ref string Err)
        {
            int rtn = 0;
            try
            {
                foreach (Neusoft.HISFC.Models.Registration.Schema schema in alModify)
                {
                    rtn = schMgr.UpdateUnused(schema);
                    if (rtn == -1)
                    {
                        Err = schMgr.Err;
                        return -1;
                    }
                    //没更新成功,没有未使用的排班,仍可以更新限额
                    if (rtn == 0)
                    {
                        if (schMgr.Update(schema) == -1)
                        {
                            Err = schMgr.Err;
                            return -1;
                        }
                    }
                   
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 保存删除记录
        /// </summary>
        /// <param name="schMgr"></param>
        /// <param name="dvDel"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int SaveDel(Neusoft.HISFC.BizLogic.Registration.Schema schMgr, DataTable dvDel, ref string Err)
        {
            try
            {
                foreach (DataRow row in dvDel.Rows)
                {
                    int rtn = schMgr.Delete(row["ID"].ToString());

                    if (rtn == -1)
                    {
                        Err = schMgr.Err;
                        return -1;
                    }
                    if (rtn == 0)
                    {
                        Err = "要删除的排班信息已经使用,不能删除!";
                        return -1;
                    }
                    string templetID = row["TempletID"].ToString();

                  
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }

            return 0;
        }
        /// <summary>
        /// 将表中数据转换为实体集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private ArrayList GetChanges(DataTable dt)
        {
            this.al = new ArrayList();
            if (dt != null)
            {
                try
                {
                    DateTime bookingTime;
                    DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime();

                    foreach (DataRow row in dt.Rows)
                    {
                        Neusoft.HISFC.Models.Registration.Schema obj = new Neusoft.HISFC.Models.Registration.Schema();

                        obj.Templet.ID = row["ID"].ToString();

                        if (this.ValidByIDForUpdate(obj.Templet.ID) == -1)
                        {
                            return null;
                        }
                        obj.Templet.EnumSchemaType = this.SchemaType;
                        obj.SeeDate = this.SeeDate;
                        obj.Templet.Week = this.SeeDate.DayOfWeek;
                        obj.Templet.Dept.ID = row["DeptID"].ToString();
                        obj.Templet.Dept.Name = row["DeptName"].ToString();
                        obj.Templet.Doct.ID = row["DoctID"].ToString();
                        obj.Templet.Doct.Name = row["DoctName"].ToString();
                        obj.Templet.DoctType.Name = row["DoctType"].ToString();
                        obj.Templet.DoctType.ID = this.getTypeIDByName(obj.Templet.DoctType.Name);
                        obj.Templet.RegLevel.ID = row["RegLevelCode"].ToString();
                        obj.Templet.RegLevel.Name = row["RegLevelName"].ToString();
                        obj.Templet.Noon.ID = this.getNoonIDByName(row["Noon"].ToString());
                        obj.Templet.IsAppend = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["IsAppend"]);

                        if (!obj.Templet.IsAppend)
                        {
                            bookingTime = DateTime.Parse(row["BeginTime"].ToString());
                            obj.Templet.Begin = DateTime.Parse(this.seeDate.ToString("yyyy-MM-dd") + " " + bookingTime.Hour +
                                ":" + bookingTime.Minute + ":00");

                            bookingTime = DateTime.Parse(row["EndTime"].ToString());
                            obj.Templet.End = DateTime.Parse(this.seeDate.ToString("yyyy-MM-dd") + " " + bookingTime.Hour +
                                ":" + bookingTime.Minute + ":00");

                            //必须指定时间段,不允许有00:00
                            if (obj.Templet.Begin == obj.Templet.End && obj.Templet.Begin == obj.Templet.Begin.Date)
                            {
                                MessageBox.Show("必须指定看诊时间范围!", "提示");
                                return null;
                            }
                        }
                        else
                        {
                            obj.Templet.Begin = DateTime.Parse(this.seeDate.ToString("yyyy-MM-dd") + " "
                                + this.getNoonEndDate(obj.Templet.Noon.ID).ToString("HH:mm:ss"));
                            obj.Templet.End = obj.Templet.Begin;
                        }

                        obj.Templet.RegQuota = decimal.Parse(row["RegLmt"].ToString());
                        obj.Templet.TelQuota = decimal.Parse(row["TelLmt"].ToString());
                        obj.Templet.SpeQuota = decimal.Parse(row["SpeLmt"].ToString());

                        //不是加号必须要输入一个限额,不允许都为空
                        //if (obj.Templet.RegQuota == 0 && obj.Templet.TelQuota == 0 && obj.Templet.SpeQuota == 0 && !obj.Templet.IsAppend)
                        //{
                        //    MessageBox.Show("挂号限额不能全部为零,请重新输入!", "提示");
                        //    return null;
                        //}
                        obj.Templet.IsValid = Neusoft.FrameWork.Function.NConvert.ToBoolean(row["Valid"]);
                        obj.Templet.StopReason.ID = row["StopReasonID"].ToString();
                        obj.Templet.StopReason.Name = Neusoft.FrameWork.Public.String.TakeOffSpecialChar( row["StopReasonName"].ToString(), "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\", "*", "^", "@", "!");
                        obj.Templet.Stop.ID = row["StopID"].ToString();

                        if (row["StopDate"].ToString() != null && row["StopDate"].ToString() != "")
                        {
                            obj.Templet.Stop.OperTime = DateTime.Parse(row["StopDate"].ToString());
                        }

                        obj.Templet.Memo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(row["Memo"].ToString(), "#", "%", "[", "'","\"", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\", "*", "^", "@", "!");
                        obj.Templet.Oper.ID = SchemaMgr.Operator.ID;
                        obj.Templet.Oper.OperTime = current;
                        obj.RegedQTY = decimal.Parse(row["Reged"].ToString());
                        obj.TelingQTY = decimal.Parse(row["Teling"].ToString());
                        obj.TeledQTY = decimal.Parse(row["Teled"].ToString());
                        obj.SpedQTY = decimal.Parse(row["Sped"].ToString());
                        obj.FromTempletID = row["TempletID"].ToString();
                        this.al.Add(obj);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("生成实体集合时出错!" + e.Message, "提示");
                    return null;
                }
            }

            return al;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int Valid(DataTable dt)
        {
            if (dt != null)
            {
                int rowNum = 1;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DeptID"].ToString() == null || row["DeptID"].ToString() == "")
                    {
                        MessageBox.Show("出诊科室不能为空!", "提示");
                        return -1;
                        
                    }

                    if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct)
                    {
                        if (row["DoctID"].ToString() == null || row["DoctID"].ToString() == "")
                        {
                            MessageBox.Show("出诊专家不能为空!", "提示");
                            return -1;
                        }
                        if (this.IsShowRegLevel && (row["RegLevelCode"] == null || row["RegLevelCode"].ToString() == ""))
                        {
                            MessageBox.Show("挂号级别不能为空!", "提示");
                            return -1;
                        }
                    }
                    string noon = this.getNoonIDByName(row["Noon"].ToString());
                    if (noon == "")
                    {
                        MessageBox.Show("出诊午别不能为空!", "提示");
                        return -1;
                    }

                    if (row["BeginTime"] == null || row["BeginTime"].ToString().Trim() == "" ||
                        row["EndTime"] == null || row["EndTime"].ToString().Trim() == "")
                    {
                        MessageBox.Show("请输入预约时间段!", "提示");
                        return -1;
                    }
                    if (DateTime.Parse(row["BeginTime"].ToString()).TimeOfDay > DateTime.Parse(row["EndTime"].ToString()).TimeOfDay)
                    {
                        MessageBox.Show("开始时间不能大于结束时间!", "提示");
                        return -1;
                    }

                    if (row[14].ToString() != "True")
                    {
                        if (DateTime.Parse(row["BeginTime"].ToString()).TimeOfDay == DateTime.Parse(row["EndTime"].ToString()).TimeOfDay)
                        {
                            MessageBox.Show("第"+rowNum.ToString()+ "行开始时间不能等于结束时间!", "提示");
                            return -1;
                        }
                    }

                    if (row["RegLmt"].ToString() == null || row["RegLmt"].ToString() == "")
                    {
                        MessageBox.Show("挂号限额必须录入!", "提示");
                        return -1;
                    }
                    if (row["TelLmt"].ToString() == null || row["TelLmt"].ToString() == "")
                    {
                        MessageBox.Show("预约限额必须录入!", "提示");
                        return -1;
                    }
                    if (row["SpeLmt"].ToString() == null || row["SpeLmt"].ToString() == "")
                    {
                        MessageBox.Show("特诊限额必须录入!", "提示");
                        return -1;
                    }

                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(row["Memo"].ToString(), 50) == false)
                    {
                        MessageBox.Show("备注不能超过25个汉字!", "提示");
                        return -1;
                    }
                    if (Neusoft.FrameWork.Public.String.ValidMaxLengh(row["StopReasonName"].ToString(), 16) == false)
                    {
                        MessageBox.Show("停诊原因不能超个8个汉字","提示");
                        return -1;
                    }
                    DateTime bookingTime;
                    bookingTime = DateTime.Parse(row["EndTime"].ToString());

                    if ((DateTime.Parse(this.seeDate.ToString("yyyy-MM-dd") + " " + bookingTime.Hour +":" + bookingTime.Minute + ":00")) <( Convert.ToDateTime(this.SchemaMgr.GetSysDateTime())))
                    {
                        MessageBox.Show("该条排班已经执行完毕(时间已过),不能修改", "提示");
                        return -1;
                    }
                    //if (Neusoft.FrameWork.Function.NConvert.ToDecimal(row["RegLmt"]) < Neusoft.FrameWork.Function.NConvert.ToDecimal(row["Reged"]) || Neusoft.FrameWork.Function.NConvert.ToDecimal(row["TelLmt"]) < Neusoft.FrameWork.Function.NConvert.ToDecimal(row["Teling"]) || Neusoft.FrameWork.Function.NConvert.ToDecimal(row["SpeLmt"]) < Neusoft.FrameWork.Function.NConvert.ToDecimal(row["Sped"]))
                    //{
                    //   MessageBox.Show("限额数不能小于已挂人数");
                    //    return -1;
                    //}
                    
                 
                    rowNum++;
                }

                if (this.valid() < 0)
                {
                    dt = null;
                    return -1;
                }

                

            }

           
            return 0;
        }
        /// <summary>
        /// 核对有没有重复时间段
        /// </summary>
        /// <returns></returns>
        private int valid()
        {

            if (this.fpSpread1_Sheet1.RowCount <= 0) return -1;
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount - 1; i++)
            {


                if (this.fpSpread1_Sheet1.Cells[i, 14].Text != "True")
                {
                    DateTime beginDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(i, 9));
                    DateTime endDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(i, 10));
                    for (int j = i + 1; j < this.fpSpread1_Sheet1.RowCount; j++)
                    {
                        if (this.fpSpread1_Sheet1.Cells[j, 14].Text != "True")
                        {
                            DateTime beginDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(j, 9));
                            DateTime endDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(j, 10));
                            if ((this.fpSpread1_Sheet1.GetValue(i, 1).ToString() == this.fpSpread1_Sheet1.GetValue(j, 1).ToString()) && (this.fpSpread1_Sheet1.GetValue(i, 3).ToString() == this.fpSpread1_Sheet1.GetValue(j, 3).ToString()) && ((beginDTj.TimeOfDay <= beginDTi.TimeOfDay && endDTj.TimeOfDay > beginDTi.TimeOfDay) || (beginDTj.TimeOfDay < endDTi.TimeOfDay && endDTj.TimeOfDay >= endDTi.TimeOfDay) || (beginDTj.TimeOfDay >= beginDTi.TimeOfDay && endDTj.TimeOfDay <= endDTi.TimeOfDay) || (beginDTj.TimeOfDay <= beginDTi.TimeOfDay && endDTj.TimeOfDay >= endDTi.TimeOfDay)))
                            {
                                MessageBox.Show("第" + (j + 1).ToString() + "行排班时间有误");
                                return -1;
                            }
                        }
                    }
                }

            }
            //加号
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount - 1; i++)
            {


                if (this.fpSpread1_Sheet1.Cells[i, (int)cols.IsAppend].Text == "True")
                {
                    DateTime beginDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(i, 9));
                    DateTime endDTi = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(i, 10));
                    for (int j = i + 1; j < this.fpSpread1_Sheet1.RowCount; j++)
                    {
                        if (this.fpSpread1_Sheet1.Cells[j, (int)cols.IsAppend].Text == "True")
                        {
                            DateTime beginDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(j, 9));
                            DateTime endDTj = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpSpread1_Sheet1.GetValue(j, 10));
                            if ((this.fpSpread1_Sheet1.GetValue(i, 1).ToString() == this.fpSpread1_Sheet1.GetValue(j, 1).ToString()) && (this.fpSpread1_Sheet1.GetValue(i, 3).ToString() == this.fpSpread1_Sheet1.GetValue(j, 3).ToString()) && (this.fpSpread1_Sheet1.GetValue(i, 8).ToString() == this.fpSpread1_Sheet1.GetValue(j, 8).ToString()))
                            
                            {
                                MessageBox.Show("第" + (j + 1).ToString() + "行排班时间有误,每个午别只能有一个时段为加号");
                                return -1;
                            }
                        }
                    }
                }

            }
            return 0;
        }
        /// <summary>
        /// 根据模板id查找end_time小于当前时间的记录数
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private int ValidByIDForUpdate(string ID)
        {
            int returnValue = this.SchemaMgr.QuerySchemaById(ID);
            if (returnValue < 0 )
            {
                MessageBox.Show( this.SchemaMgr.Err );
                return -1;
            }
            if (returnValue > 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("排班记录已经使用，不能修改或删除"));
                return -1;
            }
            return 1;
        }

        #endregion
        #region FarPoint操作
        /// <summary>
        /// 设置下来列表位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOn(object sender, System.EventArgs e)
        {
            //不可见

            this.visible(false);


            if (this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.DeptName ||
                this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.Noon ||
                this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.DoctName ||
                this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.DoctType ||
                this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.StopReasonName ||
                this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.RegLevelName)
            {
                this.setLocation();
                this.visible(false);
            }
            fpSpread1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            fpSpread1.EditingControl.DoubleClick += new EventHandler(EditingControl_DoubleClick);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                this.fpSpread1.EditingControl.KeyDown -= new KeyEventHandler(EditingControl_KeyDown);
                this.fpSpread1.EditingControl.DoubleClick -= new EventHandler(EditingControl_DoubleClick);
            }
            catch { }
        }
        /// <summary>
        /// 检索下来列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int col = this.fpSpread1_Sheet1.ActiveColumnIndex;
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            string text = this.fpSpread1_Sheet1.ActiveCell.Text.Trim();
           text =  Neusoft.FrameWork.Public.String.TakeOffSpecialChar(text, "#", "%", "[", "'", "]", ",", "$", "(", ")", "|", "\'", "\"", "\\","*","^","@","!","^");
            if (col == (int)cols.DeptName)
            {
                this.fpSpread1_Sheet1.Cells[row, (int)cols.DeptID].Text = "";
                this.lbDept.Filter(text);

                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.Noon)
            {
                this.lbNoon.Filter(text);
                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.DoctName)
            {
                this.fpSpread1_Sheet1.Cells[row, (int)cols.DoctID].Text = "";
                this.lbDoct.Filter(text);

                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.StopReasonName)
            {
                if (this.fpSpread1_Sheet1.Cells[row, (int)cols.Valid].Text.ToUpper() == "FALSE")
                {
                    this.fpSpread1_Sheet1.Cells[row, (int)cols.StopReasonID].Text = "";
                    this.lbStopRn.Filter(text);

                    if (this.groupBox1.Visible == false) this.visible(true);
                }
                else
                {
                    //MessageBox.Show("只有在无效的状态下才能输入挺诊原因");
                    this.fpSpread1_Sheet1.Cells[row, (int)cols.StopReasonID].Text = "";
                    this.fpSpread1_Sheet1.Cells[row, (int)cols.StopReasonName].Text = "";
                    
                    return;
                }
            }
            else if (col == (int)cols.DoctType)
            {
                this.lbDoctType.Filter(text);
                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.RegLevelName)
            {
                this.fpSpread1_Sheet1.Cells[row, (int)cols.RegLevelCode].Text = "";
                this.lbRegLevel.Filter(text);

                if (this.groupBox1.Visible == false) this.visible(true);
            }
            else if (col == (int)cols.Valid)
            {
                if (this.fpSpread1_Sheet1.Cells[row, (int)cols.Valid].Text.ToUpper() == "FALSE")
                {
                    this.fpSpread1_Sheet1.Cells[row, (int)cols.Valid].Locked = true;
                }
                else
                {
                    this.fpSpread1_Sheet1.Cells[row, (int)cols.Valid].Locked = false;
                }
                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_Change(object sender, ChangeEventArgs e)
        {
            if (this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.Valid)
            {
                string cellText = this.fpSpread1_Sheet1.GetText(this.fpSpread1_Sheet1.ActiveRowIndex, this.fpSpread1_Sheet1.ActiveColumnIndex);

                if (cellText.ToUpper() == "FALSE")
                {
                    this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.StopID, SchemaMgr.Operator.ID, false);
                    this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.StopDate, this.SchemaMgr.GetDateTimeFromSysDateTime(), false);
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime].BackColor = Color.MistyRose;
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime].BackColor = Color.MistyRose;
                }
                else
                {
                    this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.StopID, "", false);
                    this.fpSpread1_Sheet1.SetText(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.StopDate, "");
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime].BackColor = SystemColors.Window;
                    this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime].BackColor = SystemColors.Window;
                }
            }
            else if (this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.IsAppend)
            {
                string cellText = this.fpSpread1_Sheet1.GetText(this.fpSpread1_Sheet1.ActiveRowIndex, this.fpSpread1_Sheet1.ActiveColumnIndex);

                if (cellText.ToUpper() == "TRUE")
                {
                    //DateTime current = this.SchemaMgr.GetDateTimeFromSysDateTime().Date;
                    string noon_id = this.getNoonIDByName(this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex,(int)cols.Noon].Text);

                    DateTime current = this.getNoonEndDate(noon_id);

                    this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime, current, false);
                    this.fpSpread1_Sheet1.SetValue(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime, current, false);
                }
            }
        }


        /// <summary>
        /// 回车处理
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                #region enter
                if (this.fpSpread1.ContainsFocus)
                {
                    int col = this.fpSpread1_Sheet1.ActiveColumnIndex;

                    if (col == (int)cols.DeptName)
                    {
                        #region dept
                        if (this.selectDept() == -1) return false;

                        if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DoctName, false);
                        }
                        #endregion
                    }
                    else if (col == (int)cols.DoctName)
                    {
                        if (this.selectDoct() == -1) return false;

                        if (this.IsShowDoctType && this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct)
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DoctType, false);
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
                        }
                    }
                    else if (col == (int)cols.DoctType)
                    {
                        if (this.selectDoctType() == -1) return false;

                        if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Doct && this.IsShowRegLevel)
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.RegLevelName, false);
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
                        }
                    }
                    else if (col == (int)cols.RegLevelName)
                    {
                        if (this.selectRegLevel() == -1) return false;

                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Noon, false);
                    }
                    else if (col == (int)cols.Noon)
                    {
                        if (this.selectNoon() == -1) return false;
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.BeginTime, false);
                    }
                    else if (col == (int)cols.BeginTime)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.EndTime, false);
                    }
                    else if (col == (int)cols.EndTime)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.RegLmt, false);
                    }
                    else if (col == (int)cols.RegLmt)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.TelLmt, false);
                    }
                    else if (col == (int)cols.TelLmt)
                    {
                        if (this.SchemaType == Neusoft.HISFC.Models.Base.EnumSchemaType.Dept)
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.IsAppend, false);
                        }
                        else
                        {
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.SpeLmt, false);
                        }
                    }
                    else if (col == (int)cols.SpeLmt)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.IsAppend, false);
                    }
                    else if (col == (int)cols.IsAppend)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.Valid, false);
                    }
                    else if (col == (int)cols.Valid)
                    {
                        this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.StopReasonName, false);
                    }
                    else if (col == (int)cols.StopReasonName)
                    {
                        if (this.selectStopRn() == -1) return false;

                        if (this.fpSpread1_Sheet1.ActiveRowIndex != this.fpSpread1_Sheet1.RowCount - 1)
                        {
                            this.fpSpread1_Sheet1.ActiveRowIndex++;
                            this.fpSpread1_Sheet1.SetActiveCell(this.fpSpread1_Sheet1.ActiveRowIndex, (int)cols.DeptName, false);
                        }
                        else
                        {
                            this.Add();
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Up)
            {
                #region up
                if (this.fpSpread1.ContainsFocus)
                {
                    if (this.groupBox1.Visible)
                    { this.priorRow(); }
                    else
                    {
                        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow > 0)
                        {
                            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow - 1;
                            fpSpread1_Sheet1.AddSelection(CurrentRow - 1, 0, 1, 0);
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Down)
            {
                #region down
                if (this.fpSpread1.ContainsFocus)
                {
                    if (this.groupBox1.Visible)
                    { this.nextRow(); }
                    else
                    {
                        int CurrentRow = fpSpread1_Sheet1.ActiveRowIndex;
                        if (CurrentRow >= 0 && CurrentRow <= fpSpread1_Sheet1.RowCount - 2)
                        {
                            fpSpread1_Sheet1.ActiveRowIndex = CurrentRow + 1;
                            fpSpread1_Sheet1.AddSelection(CurrentRow + 1, 0, 1, 0);
                        }
                    }
                    return true;
                }
                #endregion

            }
            else if (keyData == Keys.Escape)
            {
                this.visible(false);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        #region 下拉控件功能
        /// <summary>
        /// 设置groupBox1的显示位置
        /// </summary>
        /// <returns></returns>
        private void setLocation()
        {
            Control cell = fpSpread1.EditingControl;
            if (cell == null) return;

            int y = fpSpread1.Top + cell.Top + cell.Height + this.groupBox1.Height + 7;
            if (y <= this.Height)
            {
                if (fpSpread1.Left + cell.Left + this.groupBox1.Width + 20 <= this.Width)
                {
                    this.groupBox1.Location = new Point(fpSpread1.Left + cell.Left + 20, y - this.groupBox1.Height);
                }
                else
                {
                    this.groupBox1.Location = new Point(this.Width - this.groupBox1.Width - 10, y - this.groupBox1.Height);
                }
            }
            else
            {
                if (fpSpread1.Left + cell.Left + this.groupBox1.Width + 20 <= this.Width)
                {
                    this.groupBox1.Location = new Point(fpSpread1.Left + cell.Left + 20, fpSpread1.Top + cell.Top - this.groupBox1.Height - 7);
                }
                else
                {
                    this.groupBox1.Location = new Point(this.Width - this.groupBox1.Width - 10, fpSpread1.Top + cell.Top - this.groupBox1.Height - 7);
                }
            }
        }

        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        /// <param name="visible"></param>
        private void visible(bool visible)
        {
            if (visible == false)
            { this.groupBox1.Visible = false; }
            else
            {
                int col = this.fpSpread1_Sheet1.ActiveColumnIndex;
                if (col == (int)cols.DeptName)
                {
                    this.lbDept.BringToFront();
                    this.groupBox1.Visible = true;
                }
                else if (col == (int)cols.Noon)
                {
                    this.lbNoon.BringToFront();
                    this.groupBox1.Visible = true;
                }
                else if (col == (int)cols.DoctName)
                {
                    this.lbDoct.BringToFront();
                    this.groupBox1.Visible = true;
                }
                else if (col == (int)cols.DoctType)
                {
                    this.lbDoctType.BringToFront();
                    this.groupBox1.Visible = true;
                }
                else if (col == (int)cols.StopReasonName)
                {
                    this.lbStopRn.BringToFront();
                    this.groupBox1.Visible = true;
                }
                else if (col == (int)cols.RegLevelName)
                {
                    this.lbRegLevel.BringToFront();
                    this.groupBox1.Visible = true;
                }
            }
        }
        /// <summary>
        /// 前一行
        /// </summary>
        private void nextRow()
        {
            int col = this.fpSpread1_Sheet1.ActiveColumnIndex;
            if (col == (int)cols.DeptName)
            {
                this.lbDept.NextRow();
            }
            else if (col == (int)cols.Noon)
            {
                this.lbNoon.NextRow();
            }
            else if (col == (int)cols.DoctName)
            {
                this.lbDoct.NextRow();
            }
            else if (col == (int)cols.DoctType)
            {
                this.lbDoctType.NextRow();
            }
            else if (col == (int)cols.StopReasonName)
            {
                this.lbStopRn.NextRow();
            }
            else if (col == (int)cols.RegLevelName)
            {
                this.lbRegLevel.NextRow();
            }
        }
        /// <summary>
        /// 上一行
        /// </summary>
        private void priorRow()
        {
            int col = this.fpSpread1_Sheet1.ActiveColumnIndex;
            if (col == (int)cols.DeptName)
            {
                this.lbDept.PriorRow();
            }
            else if (col == (int)cols.Noon)
            {
                this.lbNoon.PriorRow();
            }
            else if (col == (int)cols.DoctName)
            {
                this.lbDoct.PriorRow();
            }
            else if (col == (int)cols.DoctType)
            {
                this.lbDoctType.PriorRow();
            }
            else if (col == (int)cols.StopReasonName)
            {
                this.lbStopRn.PriorRow();
            }
            else if (col == (int)cols.RegLevelName)
            {
                this.lbRegLevel.PriorRow();
            }
        }
        /// <summary>
        /// 选择午别
        /// </summary>
        /// <returns></returns>
        private int selectNoon()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbNoon.GetSelectedItem();
                if (obj == null) return -1;

                this.fpSpread1_Sheet1.SetValue(row, (int)cols.Noon, obj.Name, false);

                if (this.timeZone == 0)
                {
                    //设定默认时间为午别的起始、结束时间
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.BeginTime,
                        (obj as Neusoft.HISFC.Models.Base.Noon).StartTime, false);
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.EndTime,
                        (obj as Neusoft.HISFC.Models.Base.Noon).EndTime, false);
                }
                else//医生模板默认从下找到的第一个结束时间为起始时间,结束时间+1
                {
                    this.SetTimeZone(row, (Neusoft.HISFC.Models.Base.Noon)obj);
                }

                this.visible(false);
            }

            return 0;
        }

        /// <summary>
        /// 设置医生排班默认时间段
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="noon"></param>
        /// <returns></returns>
        private int SetTimeZone(int currentRow, Neusoft.HISFC.Models.Base.Noon noon)
        {
            string doctID = this.fpSpread1_Sheet1.GetText(currentRow, (int)cols.DoctID);
            string deptID = this.fpSpread1_Sheet1.GetText(currentRow, (int)cols.DeptID);
            DateTime begin = DateTime.MinValue;
            object obj;

            if (doctID == "") return 0;

            for (int i = currentRow; i >= 0; i--)
            {
                if (i == currentRow) continue;

                if (this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctID) == doctID &&
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.Noon) == noon.Name &&
                    this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptID) == deptID)
                {
                    obj = this.fpSpread1_Sheet1.GetValue(i, (int)cols.EndTime);
                    if (obj == null) continue;

                    begin = DateTime.Parse(obj.ToString());
                    break;
                }
            }

            if (begin != DateTime.MinValue && begin.TimeOfDay < noon.EndTime.TimeOfDay)
            {
                this.fpSpread1_Sheet1.SetValue(currentRow, (int)cols.BeginTime, begin, false);
                begin = begin.AddHours(this.timeZone);

                if (begin.TimeOfDay > noon.EndTime.TimeOfDay)
                {
                    begin = noon.EndTime;
                }
                this.fpSpread1_Sheet1.SetValue(currentRow, (int)cols.EndTime, begin, false);
            }
            else
            {
                begin = noon.StartTime;
                this.fpSpread1_Sheet1.SetValue(currentRow, (int)cols.BeginTime, begin, false);

                begin = begin.AddHours(this.timeZone);
                if (begin.TimeOfDay > noon.EndTime.TimeOfDay)
                {
                    begin = noon.EndTime;
                }
                this.fpSpread1_Sheet1.SetValue(currentRow, (int)cols.EndTime, begin, false);
            }

            return 0;
        }
        /// <summary>
        /// 选择科室
        /// </summary>
        /// <returns></returns>
        private int selectDept()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbDept.GetSelectedItem();
                if (obj == null) return -1;

                this.fpSpread1_Sheet1.SetValue(row, (int)cols.DeptName, obj.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.DeptID, obj.ID, false);
                this.visible(false);
            }
            else
            {
                string deptId = this.fpSpread1_Sheet1.GetText(row, (int)cols.DeptID);

                if (deptId == null || deptId == "")
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.DeptName, "", false);
            }

            return 0;
        }

        /// <summary>
        /// 选择医生
        /// </summary>
        /// <returns></returns>
        private int selectDoct()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbDoct.GetSelectedItem();
                if (obj == null) return -1;

                //判断所选医生的科室和选择的科室是否是相同
                if (this.ValidDept(row, (Neusoft.HISFC.Models.Base.Employee)obj) == -1)
                {
                    this.fpSpread1.Focus();
                    return -1;
                }

                this.fpSpread1_Sheet1.SetValue(row, (int)cols.DoctName, obj.Name, false);
                this.fpSpread1_Sheet1.Cells[row, (int)cols.DoctName].Text = obj.Name;
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.DoctID, obj.ID, false);
                this.fpSpread1.Focus();
                this.visible(false);
            }
            else
            {
                string doctId = this.fpSpread1_Sheet1.GetText(row, (int)cols.DoctID);

                if (doctId == null || doctId == "")
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.DoctName, "", false);
            }

            return 0;
        }

        private int ValidDept(int CurrentRow, Neusoft.HISFC.Models.Base.Employee p)
        {
            string deptID = this.fpSpread1_Sheet1.GetText(CurrentRow, (int)cols.DeptID);
            Neusoft.HISFC.Models.Base.Department dept;

            if (deptID == null || deptID == "")//没有选择科室,直接默认医生所在的科室
            {
                dept = this.Mgr.GetDepartment(p.Dept.ID);
                this.fpSpread1_Sheet1.SetValue(CurrentRow, (int)cols.DeptID, p.Dept.ID, false);
                this.fpSpread1_Sheet1.SetValue(CurrentRow, (int)cols.DeptName, dept.Name, false);
            }
            else
            {
                if (p.Dept.ID != deptID)
                {
                    dept = this.Mgr.GetDepartment(p.Dept.ID);
                    if (dept == null)
                    {
                        dept = new Neusoft.HISFC.Models.Base.Department();
                        dept.Name = p.Dept.ID;
                    }

                    DialogResult dr = MessageBox.Show("选择医生的科室为:" + dept.Name +
                        ",与当前选择的科室不符,是否要继续?", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No) return -1;
                }
            }

            return 0;
        }

        /// <summary>
        /// 选择医生类别
        /// </summary>
        /// <returns></returns>
        private int selectDoctType()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbDoctType.GetSelectedItem();
                if (obj == null) return -1;

                this.fpSpread1_Sheet1.SetValue(row, (int)cols.DoctType, obj.Name, false);
                this.visible(false);
            }

            return 0;
        }
        /// <summary>
        /// 选择停诊原因
        /// </summary>
        /// <returns></returns>
        private int selectStopRn()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbStopRn.GetSelectedItem();
                if (obj == null) return -1;

                this.fpSpread1_Sheet1.SetValue(row, (int)cols.StopReasonName, obj.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.StopReasonID, obj.ID, false);
                this.visible(false);
            }
            else
            {
                string StopRnID = this.fpSpread1_Sheet1.GetText(row, (int)cols.StopReasonID);

                if (StopRnID == null || StopRnID == "")
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.StopReasonName, "", false);
            }

            return 0;
        }
        /// <summary>
        /// 选择挂号级别
        /// </summary>
        /// <returns></returns>
        private int selectRegLevel()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;
            Neusoft.FrameWork.Models.NeuObject obj;

            this.fpSpread1.StopCellEditing();

            if (this.groupBox1.Visible)
            {
                obj = this.lbRegLevel.GetSelectedItem();
                if (obj == null) return -1;


                this.fpSpread1_Sheet1.SetValue(row, (int)cols.RegLevelName, obj.Name, false);
                this.fpSpread1_Sheet1.SetValue(row, (int)cols.RegLevelCode, obj.ID, false);
                this.fpSpread1.Focus();
                this.visible(false);
            }
            else
            {
                string doctId = this.fpSpread1_Sheet1.GetText(row, (int)cols.RegLevelCode);

                if (doctId == null || doctId == "")
                    this.fpSpread1_Sheet1.SetValue(row, (int)cols.RegLevelName, "", false);
            }

            return 0;
        }

        /// <summary>
        /// 选择科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDept_SelectItem(object sender, EventArgs e)
        {
            this.selectDept();
            this.visible(false);
            
        }

        /// <summary>
        /// 选择午别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNoon_SelectItem(object sender, EventArgs e)
        {
            this.selectNoon();
            this.visible(false);
            
        }

        /// <summary>
        /// 选择医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDoct_SelectItem(object sender, EventArgs e)
        {
            this.selectDoct();
            this.visible(false);

        }
        
        private void lbDoctType_SelectItem(object sender, EventArgs e)
        {
            this.selectDoctType();
            this.visible(false);

        }

        
        private void lbStopRn_SelectItem(object sender, EventArgs e)
        {
            this.selectStopRn();
            this.visible(false);

        }

        private void lbRegLevel_SelectItem(object sender, EventArgs e)
        {
            this.selectRegLevel();
            this.visible(false);

        }
        #endregion

        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                FarPoint.Win.Spread.CellType.GeneralEditor t = fpSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;
                if (t.SelectionStart == 0 && t.SelectionLength == 0)
                {
                    int row = 0, column = 0;
                    if (fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.DeptName && fpSpread1_Sheet1.ActiveRowIndex != 0)
                    {
                        row = fpSpread1_Sheet1.ActiveRowIndex - 1;
                        column = (int)cols.Memo;
                    }
                    else if (fpSpread1_Sheet1.ActiveColumnIndex != (int)cols.DeptName)
                    {
                        row = fpSpread1_Sheet1.ActiveRowIndex;
                        column = this.getPriorVisibleColumn(this.fpSpread1_Sheet1.ActiveColumnIndex);

                    }
                    if (column != -1)
                    {
                        //屏蔽压缩显示报错

                        if ((column == (int)cols.DeptName || column == (int)cols.DoctName ||
                           column == (int)cols.Noon) && dv[row].Row.RowState != DataRowState.Added)
                        {
                            return;
                        }

                        fpSpread1_Sheet1.SetActiveCell(row, column, true);
                    }
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                FarPoint.Win.Spread.CellType.GeneralEditor t = fpSpread1.EditingControl as FarPoint.Win.Spread.CellType.GeneralEditor;

                if (t.Text == null || t.Text == "" || t.SelectionStart == t.Text.Length)
                {
                    int row = fpSpread1_Sheet1.RowCount - 1, column = fpSpread1_Sheet1.ColumnCount - 1;
                    if ((fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.StopReasonName || this.fpSpread1_Sheet1.ActiveColumnIndex == (int)cols.Sped)
                        && fpSpread1_Sheet1.ActiveRowIndex != row)
                    {
                        row = fpSpread1_Sheet1.ActiveRowIndex + 1;

                        if (dv[row].Row.RowState == DataRowState.Added)
                        {
                            column = (int)cols.DeptName;
                        }
                        else
                        {
                            column = (int)cols.RegLmt;
                        }
                    }
                    else if (fpSpread1_Sheet1.ActiveColumnIndex != (int)cols.StopReasonName)
                    {
                        row = fpSpread1_Sheet1.ActiveRowIndex;

                        column = this.getNextVisibleColumn(this.fpSpread1_Sheet1.ActiveColumnIndex);
                    }

                    if (column != -1)
                    {
                        //屏蔽压缩显示报错
                        if ((column == (int)cols.DeptName || column == (int)cols.DoctName ||
                             column == (int)cols.Noon) && dv[row].Row.RowState != DataRowState.Added)
                        {
                            return;
                        }

                        fpSpread1_Sheet1.SetActiveCell(row, column, true);
                    }
                }
            }
        }


        /// <summary>
        /// 双击作废
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditingControl_DoubleClick(object sender, EventArgs e)
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            if (row < 0) return;

            int col = this.fpSpread1_Sheet1.ActiveColumnIndex;

            if (col == (int)cols.BeginTime || col == (int)cols.EndTime)
            {
                //显示行状态
                this.showColor(row);
            }
            else if (col == (int)cols.Noon)
            {
                string deptId, doctId, noonID;

                deptId = this.fpSpread1_Sheet1.GetText(row, (int)cols.DeptID);
                doctId = this.fpSpread1_Sheet1.GetText(row, (int)cols.DoctID);
                noonID = this.fpSpread1_Sheet1.GetText(row, (int)cols.Noon);

                //将整个午别都置为相同状态
                for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
                {
                    if (this.fpSpread1_Sheet1.GetText(i, (int)cols.DeptID) == deptId &&
                        this.fpSpread1_Sheet1.GetText(i, (int)cols.DoctID) == doctId &&
                        this.fpSpread1_Sheet1.GetText(i, (int)cols.Noon) == noonID)
                    {
                        //显示行状态
                        this.showColor(i);
                    }
                }
            }
        }
        /// <summary>
        /// 设置行显示颜色
        /// </summary>
        /// <param name="row"></param>
        private void showColor(int row)
        {
            //显示行状态
            if (this.fpSpread1_Sheet1.GetText(row, (int)cols.Valid).ToUpper() == "TRUE")
            {
                //this.fpSpread1_Sheet1.SetValue(row, (int)cols.Valid, false, false);
                //this.fpSpread1_Sheet1.Cells[row, (int)cols.BeginTime].BackColor = Color.SeaGreen;
                //this.fpSpread1_Sheet1.Cells[row, (int)cols.EndTime].BackColor = Color.Green;
                this.fpSpread1_Sheet1.Cells[row, (int)cols.BeginTime].BackColor = SystemColors.Window;
                this.fpSpread1_Sheet1.Cells[row, (int)cols.EndTime].BackColor = SystemColors.Window;
            }
            else
            {
                //this.fpSpread1_Sheet1.SetValue(row, (int)cols.Valid, true, false);
                //this.fpSpread1_Sheet1.Cells[row, (int)cols.BeginTime].BackColor = SystemColors.Window;
                //this.fpSpread1_Sheet1.Cells[row, (int)cols.EndTime].BackColor = SystemColors.Window;
                this.fpSpread1_Sheet1.Cells[row, (int)cols.BeginTime].BackColor = Color.MistyRose;
                this.fpSpread1_Sheet1.Cells[row, (int)cols.EndTime].BackColor = Color.MistyRose;
            }
        }
        private int getNextVisibleColumn(int col)
        {
            int count = this.fpSpread1_Sheet1.Columns.Count;

            while (col < count - 1)
            {
                col++;

                if (this.fpSpread1_Sheet1.Columns[col].Visible)
                {
                    return col;
                }
            }

            return -1;
        }

        private int getPriorVisibleColumn(int col)
        {
            while (col > 0)
            {
                col--;

                if (this.fpSpread1_Sheet1.Columns[col].Visible)
                {
                    return col;
                }
            }

            return -1;
        }		
    }
}

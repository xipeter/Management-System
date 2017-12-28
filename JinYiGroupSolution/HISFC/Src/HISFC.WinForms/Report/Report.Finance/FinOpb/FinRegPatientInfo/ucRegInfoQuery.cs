using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.WinForms.Report.Finance.FinOpb.FinRegPatientInfo
{
    public partial class ucRegInfoQuery : FrameWork.WinForms.Controls.ucBaseControl
    {
        //
        // 变量
        //
        #region 变量       

        #region 枚举
        /// <summary>
        /// 设置查询范围枚举
        /// </summary>
        public enum DeptZone
        {
            MZ = 0,
            ZY = 1,
            ALL = 2,
        }
        /// <summary>
        /// 查询方式枚举
        /// </summary>
        public enum QueryType
        {
            CardCode = 0,
            PatientName = 1,
            PactCode = 2,
            SeeDepartment = 3,
            SeeDoctor = 4,
            MedicareCode = 5,
            InvoiceCode = 6
        }
        /// <summary>
        /// 查询操作方式枚举
        /// </summary>
        public enum OperateType
        {
            EqueQuery = 0,
            LikeQuery = 1
        }
        /// <summary>
        /// 挂号FarPoint字段枚举
        /// </summary>
        enum RegisterField
        {
            /// <summary>
            /// 病历号0
            /// </summary>
            CardCode = 0,
            /// <summary>
            /// 患者姓名1
            /// </summary>
            PatientName = 1,
            /// <summary>
            /// 挂号日期2
            /// </summary>
            RegisteDate = 2,
            /// <summary>
            /// 结算类别3
            /// </summary>
            PayKindName = 3,
            /// <summary>
            /// 合同单位4
            /// </summary>
            PactName = 4,
            /// <summary>
            /// 挂号级别5
            /// </summary>
            RegisteLevel = 5,
            /// <summary>
            /// 挂号科室6
            /// </summary>
            RegisteDepartment = 6,
            /// <summary>
            /// 挂号医生
            /// </summary>
            RegisterDoctor = 7,
            /// <summary>
            /// 看诊序号
            /// </summary>
            SeeNo = 8,
            /// <summary>
            /// 是否有效
            /// </summary>
            Valid = 9,
            /// <summary>
            /// 退号时间
            /// </summary>
            CancelDate = 10,
            /// <summary>
            /// 是否已看诊
            /// </summary>
            YnSee = 11,
        }
        #endregion
        /// <summary>
        /// 默认为门诊
        /// </summary>
        DeptZone deptZone1 = DeptZone.MZ;
        /// <summary>
        /// 是否选择了挂号时间限制
        /// </summary>
        bool boolRegisteDate = true;
        /// <summary>
        /// 返回值
        /// </summary>
        int intReturn = 0;
        /// <summary>
        /// 当前挂号信息
        /// </summary>
        Neusoft.HISFC.Models.Registration.Register register = new Neusoft.HISFC.Models.Registration.Register();
        /// <summary>
        /// 查询方式
        /// </summary>
        QueryType enumQuery = QueryType.CardCode;
        /// <summary>
        /// 查询操作方式
        /// </summary>
        OperateType enumOperate = OperateType.LikeQuery;
        /// <summary>
        /// 方法类 
        /// 可写到逻辑业务层BizLogic-Fee-Outpatient.cs里
        /// 为方便使用，暂时写到这儿
        /// </summary>
        BizLogicFeeOutPatient function = new BizLogicFeeOutPatient();
        /// <summary>
        /// 科室业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Manager.Department departmentFunction = new Neusoft.HISFC.BizLogic.Manager.Department();
        /// <summary>
        /// 合同单位数组
        /// </summary>
        ArrayList alPact = new ArrayList();
        /// <summary>
        /// 科室数组
        /// </summary>
        ArrayList alDepartment = new ArrayList();
        /// <summary>
        /// 医生数组
        /// </summary>
        ArrayList alEmployee = new ArrayList();
        /// <summary>
        /// 选择窗口
        /// </summary>
        //Neusoft.Common.Forms.frmEasyChoose frmChoose;
        #endregion

        #region 属性

        //[Category("控制设置"), Description("查询范围：ALL：全院、MZ：门诊、ZY：住院")]
        //public DeptZone DeptZone1
        //{
        //    get
        //    {
        //        return deptZone1;
        //    }
        //    set
        //    {
        //        deptZone1 = value;
        //    }
        //}

        #region 当前挂号信息
        /// <summary>
        /// 当前挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            get
            {
                return this.register;
            }
            set
            {
                this.register = value;
                // 病历号码
                this.textBoxCardCode.Text = this.register.PID.CardNO;
                // 门诊号
                this.textBoxClinicCode.Text = this.register.ID;
                // 姓名
                this.textBoxPatientName.Text = this.register.Name;
                // 性别/年龄
                this.textBoxAgeAndSex.Text = this.register.Sex.Name + "||" + departmentFunction.GetAge(this.register.Birthday);
                // 挂号日期
                this.textBoxRegisteDate.Text = this.register.DoctorInfo.SeeDate.ToString();
                // 身份证号
                this.textBoxIDCard.Text = this.register.IDCard;
                // 出生日期
                this.textBoxBornDate.Text = this.register.Birthday.Date.ToString();
                // 结算类别: 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
                switch (this.register.Pact.PayKind.ID)
                {
                    case "01":
                        this.textBoxBalanceType.Text = "自费";
                        break;
                    case "02":
                        this.textBoxBalanceType.Text = "医保";
                        break;
                    case "03":
                        this.textBoxBalanceType.Text = "公费";
                        break;
                }
                // 合同单位
                this.textBoxPactName.Text = this.register.Pact.Name;
                // 医疗证号
                this.textBoxMCardCode.Text = this.register.SSN;
                // 挂号级别
                this.textBoxRegistLevel.Text = this.register.DoctorInfo.Templet.RegLevel.Name;
                // 挂号科室
                this.textBoxRegistDepartment.Text = this.register.DoctorInfo.Templet.Dept.Name;
                // 挂号医生
                this.textBoxRegistDoctor.Text = this.register.DoctorInfo.Templet.Doct.Name;

                // 由于业务层没有取这两个字段，所以暂时不填
                // 看诊科室
                //this.textBoxSeeDepartment.Text = this.register.SeeDPCD;
                // 看诊医生
                //this.textBoxSeeDoctor.Text = this.register.SeeDOCD;

                // 挂号发票
                this.textBoxRegisteInvoice.Text = this.register.InvoiceNO;
                // 挂号费
                this.textBoxFeeRegist.Text = this.register.RegLvlFee.RegFee.ToString();
                // 检查费
                this.textBoxFeeCheck.Text = this.register.RegLvlFee.ChkFee.ToString();
                // 诊察费
                this.textBoxFeeDiagnose.Text = this.register.RegLvlFee.OwnDigFee.ToString();
                // 附加费
                this.textBoxFeeOther.Text = this.register.RegLvlFee.OthFee.ToString();
            }
        }
        #endregion

        #endregion

        public ucRegInfoQuery()
        {
            InitializeComponent();
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索信息...");
            Application.DoEvents();
            //先清空原来的挂号信息
            this.Clear();
            // 查询挂号信息
            this.QueryRegister();

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return base.OnQuery(sender, neuObject);
        }

        //
        // 函数
        //
        // 挂号信息
        #region 清空挂号信息显示
        /// <summary>
        /// 清空挂号信息的显示
        /// </summary>
        private void Clear()
        {
            // 病历号码
            this.textBoxCardCode.Text = "";
            // 门诊号
            this.textBoxClinicCode.Text = "";
            // 姓名
            this.textBoxPatientName.Text = "";
            // 性别/年龄
            this.textBoxAgeAndSex.Text = "";
            // 挂号日期
            this.textBoxRegisteDate.Text = "";
            // 身份证号
            this.textBoxIDCard.Text = "";
            // 出生日期
            this.textBoxBornDate.Text = "";
            // 结算类别: 01-自费  02-保险 03-公费在职 04-公费退休 05-公费高干
            this.textBoxBalanceType.Text = "";
            // 合同单位
            this.textBoxPactName.Text = "";
            // 医疗证号
            this.textBoxMCardCode.Text = "";
            // 挂号级别
            this.textBoxRegistLevel.Text = "";
            // 挂号科室
            this.textBoxRegistDepartment.Text = "";
            // 挂号医生
            this.textBoxRegistDoctor.Text = "";
            // 看诊科室
            this.textBoxSeeDepartment.Text = "";
            // 看诊医生
            this.textBoxSeeDoctor.Text = "";
            // 挂号发票
            this.textBoxRegisteInvoice.Text = "";
            // 挂号费
            this.textBoxFeeRegist.Text = "";
            // 检查费
            this.textBoxFeeCheck.Text = "";
            // 诊察费
            this.textBoxFeeDiagnose.Text = "";
            // 附加费
            this.textBoxFeeOther.Text = "";
        }

        #endregion
        #region 判断条件输入框是否合法
        /// <summary>
        /// 判断条件输入框是否合法
        /// </summary>
        /// <returns>1-合法,-1-不合法</returns>
        private int JudgeInput()
        {
            // 不允许为空
            if (this.textBoxPatientCondition.Text == null || this.textBoxPatientCondition.Text.Equals(""))
            {
                MessageBox.Show("查询条件不允许为空!");
                // 设置焦点到条件输入框
                this.textBoxPatientCondition.Focus();

                return -1;
            }

            // 成功返回
            return 1;
        }
        #endregion

        #region 获取挂号时间限制
        /// <summary>
        /// 获取挂号时间限制
        /// [参数1: ref DateTime dtFrom - 起始时间]
        /// [参数2: ref DateTime dtTo - 截止时间]
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <param name="dtFrom">起始时间</param>
        /// <param name="dtTo">截止时间</param>
        /// <returns>1-成功,-1-失败</returns>
        private int GetDateLimited(ref DateTime dtFrom, ref DateTime dtTo)
        {
            // 起始时间不能大于截止时间
            if (this.dateTimePickerRegisteFrom.Value > this.dateTimePickerRegisteTo.Value)
            {
                MessageBox.Show("起始时间不能大于截止时间!");
                // 设置焦点到起始时间控件
                this.dateTimePickerRegisteFrom.Focus();
                return -1;
            }

            // 起始时间
            dtFrom = this.dateTimePickerRegisteFrom.Value;
            // 截止时间
            dtTo = this.dateTimePickerRegisteTo.Value;

            // 成功返回
            return 1;
        }
        #endregion

        #region 查询挂号信息
        /// <summary>
        /// 查询挂号信息
        /// [返回: int,1-成功,-1-失败]
        /// </summary>
        /// <returns>1-成功,-1-失败</returns>
        private int QueryRegister()
        {
            // 查询条件值
            string QueryString = "";
            // 返回的挂号实体数组
            ArrayList alRegister = new ArrayList();

            // 判断输入是否合法
            if (this.JudgeInput() == -1)
            {
                return -1;
            }

            // 起始时间
            System.DateTime dtFrom = DateTime.MinValue;
            // 截止时间
            System.DateTime dtTo = DateTime.MinValue;
            if (this.boolRegisteDate)
            {
                // 获取时间限制
                this.intReturn = this.GetDateLimited(ref dtFrom, ref dtTo);
                if (this.intReturn == -1)
                {
                    return -1;
                }
            }
            // 根据不同的查询方式,设置不同的查询信息
            switch (this.enumQuery)
            {
                case QueryType.CardCode:
                    // 病历号
                    QueryString = this.textBoxPatientCondition.Text;
                    // 执行查询   
                    break;
                case QueryType.PatientName:
                    // 姓名
                    QueryString = this.textBoxPatientCondition.Text;
                    break;
                case QueryType.PactCode:
                    // 合同单位编码
                    if (this.textBoxPatientCondition.Tag == null)
                    {
                        return -1;
                    }
                    QueryString = this.textBoxPatientCondition.Tag.ToString();
                    break;
                case QueryType.SeeDepartment:
                    // 挂号科室
                    if (this.textBoxPatientCondition.Tag == null)
                    {
                        return -1;
                    }
                    QueryString = this.textBoxPatientCondition.Tag.ToString();
                    break;
                case QueryType.SeeDoctor:
                    // 开方医生
                    if (this.textBoxPatientCondition.Tag == null)
                    {
                        return -1;
                    }
                    QueryString = this.textBoxPatientCondition.Tag.ToString();
                    break;
                case QueryType.MedicareCode:
                    // 医疗证号
                    QueryString = this.textBoxPatientCondition.Text;
                    break;
                case QueryType.InvoiceCode:
                    // 发票号
                    QueryString = this.textBoxPatientCondition.Text;
                    break;
            }
            this.intReturn = this.function.GetRegisterList(QueryString, alRegister, this.enumQuery, this.enumOperate, boolRegisteDate, dtFrom, dtTo);

            // 判断查询结果查询
            if (this.intReturn == -1)
            {
                MessageBox.Show(this.function.Err);
                return -1;
            }

            // 设置FarPoint
            this.SetRegisterFarPoint(alRegister);

            // 成功返回
            return 1;
        }
        #endregion

        #region 设置挂号信息结果FarPoint
        /// <summary>
        /// 设置挂号信息结果FarPoint
        /// [参数: ArrayList alRegister - 挂号实体数组]
        /// </summary>
        /// <param name="alRegister">挂号实体数组</param>
        private void SetRegisterFarPoint(ArrayList alRegister)
        {
            // 行号
            int row = 0;

            // 清空FarPoint
            this.ResetSheet(this.SheetRegistRecord);

            // 循环插入FarPoint
            foreach (Neusoft.HISFC.Models.Registration.Register r in alRegister)
            {
                // 增加一行
                row = this.InsertRow(this.SheetRegistRecord);

                // 病历号
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.CardCode, r.PID.CardNO);
                // 患者姓名
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PatientName, r.Name);
                // 挂号日期
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.RegisteDate, r.DoctorInfo.SeeDate.ToString());
                // 结算类别
                switch (r.Pact.PayKind.ID)
                {
                    case "01":
                        this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PayKindName, "自费");
                        break;
                    case "02":
                        this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PayKindName, "医保");
                        break;
                    case "03":
                        this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PayKindName, "公费");
                        break;
                    //case "04":
                    //    this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PayKindName, "公费退休");
                    //    break;
                    //case "05":
                    //    this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PayKindName, "公费高干");
                    //    break;
                }
                // 合同单位
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.PactName, r.Pact.Name);
                // 挂号级别
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.RegisteLevel, r.DoctorInfo.Templet.RegLevel.Name);
                // 挂号科室
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.RegisteDepartment, r.DoctorInfo.Templet.Dept.Name);
                // 挂号医生
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.RegisterDoctor, r.DoctorInfo.Templet.Doct.Name);
                // 看诊序号
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.SeeNo, r.DoctorInfo.SeeNO.ToString());
                //是否有效
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.Valid, r.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid ? "有效" : "退号");

                //退号时间
                this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.CancelDate, "--");

                this.SheetRegistRecord.Rows[row].BackColor = Color.White;

                if (r.Status != Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid)
                {
                    this.SheetRegistRecord.Rows[row].BackColor = Color.MistyRose;
                    //退号时间
                    this.SetCell(this.SheetRegistRecord, row, (int)RegisterField.CancelDate, r.CancelOper.OperTime.ToString());
                }

                // 行Tag
                this.SetRowTag(this.SheetRegistRecord, row, r);
            }
            foreach (FarPoint.Win.Spread.Column col in this.SheetRegistRecord.Columns)
            {
                col.Width = col.GetPreferredWidth();
            }
        }
        #endregion

        #region 清空FarPoint
        /// <summary>
        /// 清空FarPoint
        /// [参数: FarPoint.Win.Spread.SheetView sheet - FarPoint页]
        /// </summary>
        /// <param name="sheet">FarPoint页</param>
        private void ResetSheet(FarPoint.Win.Spread.SheetView sheet)
        {
            sheet.RowCount = 0;
        }
        #endregion
        #region 在FarPoint增加一行
        /// <summary>
        /// 在FarPoint增加一行
        /// [参数: FarPoint.Win.Spread.SheetView sheet - FarPoint页]
        /// [返回: 增加后的行号]
        /// </summary>
        /// <param name="sheet">FarPoint页</param>
        /// <returns>增加后的行号</returns>
        private int InsertRow(FarPoint.Win.Spread.SheetView sheet)
        {
            // 临时行号
            int row = 0;
            // 增加一行
            sheet.AddRows(sheet.RowCount, 1);
            // 获取行号
            row = sheet.RowCount - 1;
            // 返回行号
            return row;
        }
        #endregion
        #region 设置FarPoint一个Cell的值
        /// <summary>
        /// 设置FarPoint一个Cell的值
        /// [参数1: FarPoint.Win.Spread.SheetView sheet - FarPoint页]
        /// [参数2: int row - 行号]
        /// [参数3: int col - 列号]
        /// [参数4: string stringValue - 值]
        /// </summary>
        /// <param name="sheet">FarPoint页</param>
        /// <param name="row">行号</param>
        /// <param name="col">列号</param>
        /// <param name="stringValue">值</param>
        private void SetCell(FarPoint.Win.Spread.SheetView sheet, int row, int col, string stringValue)
        {
            sheet.Cells[row, col].Text = stringValue;
        }
        #endregion
        #region 设置FarPoint某一行的Tag
        /// <summary>
        /// 设置FarPoint某一行的Tag
        /// [参数1: FarPoint.Win.Spread.SheetView sheet - FarPoint页]
        /// [参数2: int row - 行号]
        /// [参数3: System.Object objectTag - Tag值]
        /// </summary>
        /// <param name="sheet">FarPoint页</param>
        /// <param name="row">行号</param>
        /// <param name="objectTag">Tag值</param>
        private void SetRowTag(FarPoint.Win.Spread.SheetView sheet, int row, System.Object objectTag)
        {
            sheet.Rows[row].Tag = objectTag;
        }
        #endregion
        #region 获取FarPoint某一行的Tag
        /// <summary>
        /// 获取FarPoint某一行的Tag
        /// [参数1: FarPoint.Win.Spread.SheetView sheet - FarPoint页]
        /// [参数2: int row - 行号]
        /// [返回: Tag]
        /// </summary>
        /// <param name="sheet">FarPoint页</param>
        /// <param name="row">行号</param>
        /// <returns>Tag</returns>
        private System.Object GetRowTag(FarPoint.Win.Spread.SheetView sheet, int row)
        {
            return sheet.Rows[row].Tag;
        }
        #endregion

        #region 事件
        private void ucRegInfoQuery_Load(object sender, EventArgs e)
        {
            // 科室业务层
            Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            // 医生业务层
            Neusoft.HISFC.BizLogic.Manager.UserManager userFunction = new Neusoft.HISFC.BizLogic.Manager.UserManager();
            // 常数业务层
            Neusoft.HISFC.BizLogic.Manager.Constant constFunction = new Neusoft.HISFC.BizLogic.Manager.Constant();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在初始化信息...");
            Application.DoEvents();
            // 设置挂号信息FarPoint页自动排序
            this.SheetRegistRecord.SetColumnAllowAutoSort(-1, true);

            // 初始化科室
            this.alDepartment = manager.QueryRegDepartment();
            // 初始化医生
            this.alEmployee = manager.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            // 初始化合同单位
            this.alPact = constFunction.GetAllList("PACTUNIT");

            // 设置起始时间和截止时间
            this.dateTimePickerRegisteTo.Value = departmentFunction.GetDateTimeFromSysDateTime();
            this.dateTimePickerRegisteFrom.Value = new DateTime(this.dateTimePickerRegisteTo.Value.Year,
                                                                this.dateTimePickerRegisteTo.Value.Month,
                                                                this.dateTimePickerRegisteTo.Value.Day,
                                                                0,
                                                                0,
                                                                0);

            // 设置焦点到条件输入框
            this.textBoxPatientCondition.Focus();

            if (this.Parent.GetType() == typeof(TabPage))
            {
                TabControl tabControl = this.Parent.Parent as TabControl;

                foreach (TabPage page in tabControl.TabPages)
                {
                    tabControl.SelectTab(page);
                }
                tabControl.SelectTab(0);
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void comboBoxPatientCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置查询方式枚举
            this.enumQuery = (QueryType)this.comboBoxPatientCondition.SelectedIndex;
            // 设置焦点到查询操作方式
            this.comboBoxOperate.Focus();
            // 根据查询方式设置不同的查询效果 
            switch (this.enumQuery)
            {
                case QueryType.PactCode:
                    // 按合同单位查询,条件输入框只读
                    this.textBoxPatientCondition.ReadOnly = false;
                    this.textBoxPatientCondition.AddItems(this.alPact);
                    break;
                case QueryType.SeeDepartment:
                    // 按挂号科室查询,条件输入框只读
                    this.textBoxPatientCondition.ReadOnly = false;
                    this.textBoxPatientCondition.AddItems(this.alDepartment);
                    break;
                case QueryType.SeeDoctor:
                    // 按开方医生查询,条件输入框只读
                    this.textBoxPatientCondition.ReadOnly = false;
                    this.textBoxPatientCondition.AddItems(this.alEmployee);
                    break;
                default:
                    // 否则条件输入框可写
                    ArrayList al = new ArrayList();
                    this.textBoxPatientCondition.AddItems(al);
                    break;
            }
        }

        private void comboBoxPatientCondition_KeyDown(object sender, KeyEventArgs e)
        {
            // 如果回车,那么设置焦点到查询方式
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // 设置焦点到查询方式
                this.comboBoxOperate.Focus();
                // 设置查询方式枚举
                this.enumQuery = (QueryType)this.comboBoxPatientCondition.SelectedIndex;
            }
        }

        private void comboBoxOperate_KeyDown(object sender, KeyEventArgs e)
        {
            // 如果回车
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // 那么设置焦点到输入框
                this.textBoxPatientCondition.Focus();
                // 使条件输入框的内容全选
                this.textBoxPatientCondition.SelectAll();
                // 设置查询操作方式
                this.enumOperate = (OperateType)this.comboBoxOperate.SelectedIndex;
            }
        }

        private void comboBoxOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置焦点到条件输入框
            this.textBoxPatientCondition.Focus();
            // 全选内容
            this.textBoxPatientCondition.SelectAll();
            // 设置查询操作方式
            this.enumOperate = (OperateType)this.comboBoxOperate.SelectedIndex;
            // 清空查询条件输入框
            this.textBoxPatientCondition.Text = "";
        }

        private void checkBoxRegisteDate_CheckedChanged(object sender, EventArgs e)
        {
            // 设置是否有挂号时间限制
            this.boolRegisteDate = this.checkBoxRegisteDate.Checked;

            // 设置时间控件的可用性
            if (this.checkBoxRegisteDate.Checked)
            {
                // 如果有时间限制,那么设置两个时间选择控件可用
                this.dateTimePickerRegisteFrom.Enabled = true;
                this.dateTimePickerRegisteTo.Enabled = true;
            }
            else
            {
                // 否则不可用
                this.dateTimePickerRegisteFrom.Enabled = false;
                this.dateTimePickerRegisteTo.Enabled = false;
            }
        }

        private void textBoxPatientCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // 如果会车,那么执行查询
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索信息...");
                Application.DoEvents();
                //先清空原来的挂号信息
                this.Clear();
                // 查询挂号信息
                this.QueryRegister();

                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        } 

        private void fpSpreadRegistRecord_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            bool boolTabPageFocus = true;
            if (this.Parent.GetType() == typeof(TabPage))
            {
                TabControl tabControl = this.Parent.Parent as TabControl;

                foreach (TabPage page in tabControl.TabPages)
                {
                    foreach (Control c1 in page.Controls)
                    {
                        if (c1.GetType() == typeof(ucInvoiceInfoQuery))
                        {
                            if (boolTabPageFocus)
                            {
                                tabControl.SelectedTab = page;
                            }
                            boolTabPageFocus = false;
                            ucInvoiceInfoQuery ucInvoiceInfoQuery = c1 as ucInvoiceInfoQuery;

                            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在检索信息...");
                            Application.DoEvents();

                            // 费用明细数据集
                            System.Data.DataSet dsResult = new DataSet();

                            //初始化行数为0
                            ucInvoiceInfoQuery.SheetFeeDetail.Rows.Count = 0;

                            // 显示费用明细
                            this.intReturn = function.GetFeeDetailByClinicCode(this.Register.ID,ref dsResult);
                            if (this.intReturn == -1)
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("获取费用明细失败!\n" + function.Err);
                                return;
                            }

                            if (dsResult.Tables[0].Rows.Count == 0)
                            {
                                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                                MessageBox.Show("没有费用信息!");
                                return;
                            }
                            // 设置费用数据源为查询结果
                            
                            for (int k = 0; k < dsResult.Tables[0].Rows.Count; k++)
                            {
                                ucInvoiceInfoQuery.SheetFeeDetail.Rows.Add(k,1);
                                for (int j = 0; j < dsResult.Tables[0].Columns.Count; j++)
                                {
                                    ucInvoiceInfoQuery.SheetFeeDetail.Cells[k, j].Text = dsResult.Tables[0].Rows[k][j].ToString();
                                }
                            }
                            ucInvoiceInfoQuery.SheetFeeDetail.Rows.Count = dsResult.Tables[0].Rows.Count;
                            ucInvoiceInfoQuery.SheetFeeDetail.Columns.Count = dsResult.Tables[0].Columns.Count;

                            Neusoft.HISFC.Components.Common.Classes.Function.DrawCombo(ucInvoiceInfoQuery.SheetFeeDetail, 6, 6);

                            foreach (FarPoint.Win.Spread.Column col in ucInvoiceInfoQuery.SheetFeeDetail.Columns)
                            {
                                col.Width = col.GetPreferredWidth();
                            }
                            for (int i = 0; i < ucInvoiceInfoQuery.SheetFeeDetail.Rows.Count; i++)
                            {
                                ucInvoiceInfoQuery.SheetFeeDetail.Rows[i].BackColor = Color.White;

                                if (ucInvoiceInfoQuery.SheetFeeDetail.Cells[i, 2].Text == "退费")
                                {
                                    ucInvoiceInfoQuery.SheetFeeDetail.Rows[i].BackColor = Color.MistyRose;
                                }
                            }


                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                        }
                        else if (c1.GetType() == typeof(ucOrderHistoryQuery))
                        {
                            if (boolTabPageFocus)
                            {
                                tabControl.SelectedTab = page;
                            }
                            boolTabPageFocus = false;

                            ucOrderHistoryQuery ucOrderHistoryQuery = c1 as ucOrderHistoryQuery;

                            ucOrderHistoryQuery.OnSetValue(this.register);
                        }
                    }
                }
            }
        }
                
        private void fpSpreadRegistRecord_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            // 显示挂号信息
            this.Register = (Neusoft.HISFC.Models.Registration.Register)this.GetRowTag(this.SheetRegistRecord, e.Row);
        }

        #endregion
    }
}

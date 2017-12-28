using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Design;


namespace Neusoft.WinForms.Controls
{
    /// <summary>
    /// [功能描述: ComboBox组件]<br></br>
    /// [创建者:   张城]<br></br>
    /// [创建时间: 2008-05-15]<br></br>
    /// <说明>
    ///    自定义的ComboBox组件
    /// </说明>
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public class NComboBox : ComboBoxBase
    {
        #region 变量
        //WIN32对应的数值设置
        private const UInt32 WM_LBUTTONDOWN = 0x201;
        private const UInt32 WM_LBUTTONDBLCLK = 0x203;
        //private const int WM_KEYDOWN = 0x0100;
        //private const int VK_RETURN = 0x0D;
        //容器定义
        ToolStripControlHost dataGridViewHost;
        ToolStripControlHost cmbBoxHost;
        ToolStripDropDown dropDown;
        private DataTable _dt = new DataTable();
        DataGridView dataGridView;
        //下拉框的高度设置
        private int _neuHeight = 8 * 23 + 25;
        //返回的值
        private string resultName = null;
        //传进来的泛型实体
        private object formObject = null;
        //传进来的泛型实体包含的实体
        private object _inputObj = null;

        private object _name = "Name";
        private object _id = "Id";
        private string _UserCode = "CustomCode";
        private string _spellCode = "SpellCode";
        private string _wbCode = "WBCode";
        protected ToolTip tooltip = new ToolTip();
        protected int iSpellCode = 0;
        private string queryTypeList = "编码+名称+拼音码+五笔码+自定义码";
        private QueryTypeEnum queryType;


        //下拉框是否显示DataView
        private bool isShowDataView = false;
        //用来只加载一个DataView用
        private bool flag = true;
        //是否显示超出屏幕范围
        private bool isOutScreen = false;

        private bool isIllegibility = true;

        private string sign = "%";

        private int rowCout = 8;

        private bool isColumnHeader = true;


        private bool isRowsHeader = false;

        private bool isEnter = false;

        private bool isShowCodeColumn = true;

        private bool isShowDialog = true;

        private bool isShowF2 = true;

        private bool isSpellOrWbSearch = true;

        private bool showDialogFlag = true;
        //存放传进来的类型的所有属性
        private Hashtable ht;


        #endregion

        private ArrayList arrayList = null;

        private bool isLeave = false;

        private bool flag1 = true;

        #region 构造函数
        public NComboBox()
        {
            this.Init();
            flag1 = false;
        }

        private void Init()
        {
            #region DataGridViewHost处理
            dataGridView = new DataGridView();
            dataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.BorderStyle = BorderStyle.FixedSingle;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;


            #endregion

            #region ComboBoxHost处理
            ComboBoxBase cmbBox = new ComboBoxBase();
            //WindowsAPI.MoveWindow(cmbBox.Handle, cmbBox.Left, cmbBox.Top, cmbBox.Width, 1, true);
            //设置DataGridView的数据源
            Form frmDataSource = new Form();
            frmDataSource.Controls.Add(dataGridView);
            frmDataSource.Controls.Add(cmbBox);
            frmDataSource.SuspendLayout();

            dataGridViewHost = new ToolStripControlHost(dataGridView);
            cmbBoxHost = new ToolStripControlHost(cmbBox);

            CmbBox.Dock = DockStyle.Fill;
            #endregion

            #region dropDown处理
            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(cmbBoxHost);
            dropDown.Items.Add(dataGridViewHost);

            #endregion

            #region 处理事件
            CmbBox.TextChanged += new EventHandler(CmbBox_TextChanged);
            CmbBox.KeyDown += new KeyEventHandler(CmbBox_KeyDown);
            cmbBox.DropDownHandler += new dropDownHandler(cmbBox_DropDownHandler);

            DataGridView.KeyDown += new KeyEventHandler(DataGridView_KeyDown);
            DataGridView.Click += new EventHandler(DataGridView_Click);
            #endregion
        }
        #endregion

        #region 属性
        #region 公开的属性

        public new object DataSource
        {
            set
            {
                if (flag1)
                {
                    this.Init();
                    IsColumnHeader = isColumnHeader;
                }
                base.DataSource = value;
                arrayList = null;
                flag = true;

                if (value == null)
                {
                    this.Text = "";
                }
                if (value != null)
                {
                    Type _type = value.GetType();

                    if (_type.Name.IndexOf("[") > 0)
                    {
                        string listName = string.Format("System.Collections.Generic.List`1[[{0},{1}]]", _type.FullName.Substring(0, _type.FullName.IndexOf("[")), _type.Assembly.FullName);
                        object listObj = this.CreateInstance(listName);
                        IEnumerator enumerator = (IEnumerator)this.ExecuteMethod(value, "GetEnumerator", BindingFlags.Public, null);
                        while (enumerator.MoveNext())
                        {
                            this.ExecuteMethod(listObj, "Add", BindingFlags.Public, new object[] { enumerator.Current });
                        }
                        _type = listObj.GetType();
                        base.DataSource = listObj;

                    }

                    if (_type.Name == "List`1")
                    {
                        string _fullname = _type.GetGenericArguments()[0].FullName;
                        string str = _type.GetGenericArguments()[0].Assembly.FullName;
                        //初始化一个IList<>里面的实体
                        this._inputObj = this.CreateInstance(str.Substring(0, str.IndexOf(",")), _fullname);

                        //初始化SelectItemForm实体

                        string formName = string.Format("Neusoft.WinForms.Forms.SelectItemForm`1[[{0},{1}]]", _fullname, str);
                        this.formObject = this.CreateInstance("FrameWork.WinForms", formName);
                    }
                    ht = GetProperty(this._inputObj.GetType().GetProperties());
                    if (ht.ContainsValue("Name"))
                    {
                        this.DisplayMember = "Name";
                    }
                    if (ht.ContainsValue("Id"))
                    {
                        this.ValueMember = "Id";
                    }
                    else
                    {
                        if (ht.ContainsValue("Code"))
                        {
                            this.ValueMember = "Code";
                        }
                    }
                    showDialogFlag = true;
                    flag1 = true;
                }

            }
            get
            {
                return base.DataSource;
            }
        }

        [Browsable(false)]
        public new object ValueMember
        {
            set
            {
                if (formObject != null)
                {
                    this.SetProperty(this.formObject, "ID", value, null);
                }
                this._id = value;
                base.ValueMember = value.ToString(); ;
            }
            get
            {
                return base.ValueMember;
            }
        }
        [Browsable(false)]
        public new object DisplayMember
        {
            set
            {
                if (formObject != null)
                {
                    this.SetProperty(this.formObject, "Value", value, null);
                }
                this._name = value;
                base.DisplayMember = value.ToString();
                if (arrayList == null)
                {
                    IEnumerator enumer = (IEnumerator)this.ExecuteMethod(base.DataSource, "GetEnumerator", BindingFlags.Public, null);
                    if (enumer == null)
                    {
                        return;
                    }
                    arrayList = new ArrayList();
                    while (enumer.MoveNext())
                    {
                        arrayList.Add(this.GetProperty(enumer.Current, base.DisplayMember));
                    }
                }
            }
            get
            {
                return base.DisplayMember;
            }
        }

        [Browsable(false)]
        public int NeuHeight
        {
            get { return _neuHeight; }
            set { _neuHeight = value; }
        }




        [Description("是否支持空格索引，模糊查询等业务功能，Neusoft模块中优先级最高！使用前请确保DataSource已绑定IList<>数据列表"), DefaultValue(false), Browsable(true), Category("Neusoft")]
        public bool IsShowDataView
        {
            get { return isShowDataView; }
            set { isShowDataView = value; }
        }
        [Description("是否模糊查询"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsIllegibility
        {
            get
            {
                return isIllegibility;
            }
            set
            {
                isIllegibility = value;
                if (!isIllegibility)
                {
                    sign = "";
                }
            }
        }

        [Description("DropDown透明度"), TypeConverter(typeof(OpacityConverter)), DefaultValue((double)1.0), Browsable(true), Category("Neusoft")]
        public double Opacity
        {
            get { return dropDown.Opacity; }
            set
            {
                value = Math.Max(value, 0.5);
                dropDown.Opacity = value;
            }
        }
        [Description("DataView下拉条显示的个数"), DefaultValue(8), Browsable(true), Category("Neusoft")]
        public int RowCout
        {
            get { return rowCout; }
            set
            {
                rowCout = value;
                this.NeuHeight = RowCout * 23 + 25 * FrameWork.Function.NConvert.ToInt32(IsColumnHeader);
            }
        }
        [Description("是否显示列标题"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsColumnHeader
        {
            get { return isColumnHeader; }
            set
            {
                isColumnHeader = value;
                dataGridView.ColumnHeadersVisible = IsColumnHeader;
            }
        }

        [Description("是否显示行标题"), DefaultValue(false), Browsable(true), Category("Neusoft")]
        public bool IsRowsHeader
        {
            get { return isRowsHeader; }
            set
            {
                isRowsHeader = value;
                dataGridView.RowHeadersVisible = IsRowsHeader;
                this.NeuHeight = RowCout * 23 + 25 * FrameWork.Function.NConvert.ToInt32(IsColumnHeader);
            }
        }

        [Description("是否在选择后直接触发回车事件"), DefaultValue(false), Browsable(true), Category("Neusoft")]
        public bool IsEnter
        {
            get { return isEnter; }
            set { isEnter = value; }
        }

        [Description("是否显示编码列"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsShowCodeColumn
        {
            get { return isShowCodeColumn; }
            set { isShowCodeColumn = value; }
        }

        [Description("是否支持空格显示对话框"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsShowDialog
        {
            get { return isShowDialog; }
            set { isShowDialog = value; }
        }

        [Description("是否支持F2"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsShowF2
        {
            get { return isShowF2; }
            set
            {
                isShowF2 = value;
                if (!isShowF2)
                {
                    queryTypeList = "编码";
                }
            }
        }
        [Description("搜索的类型"), DefaultValue(1), Browsable(true), RefreshProperties(RefreshProperties.Repaint), Category("Neusoft")]
        public QueryTypeEnum QueryType
        {
            set
            {
                if (!IsShowF2)
                {
                    queryType = (QueryTypeEnum)value;
                    queryTypeList = Enum.GetName(typeof(QueryTypeEnum), queryType);
                }
                else
                {
                    queryType = (QueryTypeEnum)value;
                    queryTypeList = "编码+名称+拼音码+五笔码+自定义码";
                }
            }
            get
            {
                return queryType;
            }
        }

        [Description("是否支持自动生成拼音码，五笔码（主要针对枚举类的拼音码五笔码查询）"), DefaultValue(true), Browsable(true), Category("Neusoft")]
        public bool IsSpellOrWbSearch
        {
            get { return isSpellOrWbSearch; }
            set { isSpellOrWbSearch = value; }
        }

        [Description("自定义码"), DefaultValue("CustomCode"), Browsable(true), Category("Neusoft")]
        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }

        [Description("拼音码"), DefaultValue("SpellCode"), Browsable(true), Category("Neusoft")]
        public string SpellCode
        {
            get { return _spellCode; }
            set { _spellCode = value; }
        }

        [Description("五笔码"), DefaultValue("WBCode"), Browsable(true), Category("Neusoft")]
        public string WbCode
        {
            get { return _wbCode; }
            set { _wbCode = value; }
        }

        [Description("当用户输入数据不符合COMBOX里面数据时是否准许焦点离开"), DefaultValue(false), Browsable(true), Category("Neusoft")]
        public bool IsLeave
        {
            get { return isLeave; }
            set { isLeave = value; }
        }

        #endregion

        #region 私有的属性
        private DataTable DataView
        {
            get
            {

                if (formObject != null)
                {
                    DataTable dataTable = (DataTable)this.ExecuteGenericMethod(this, this.formObject.GetType().GetGenericArguments(), "FillInDataView", BindingFlags.NonPublic, new object[] { base.DataSource });

                    if (dataTable == null)
                    {
                        return null;
                    }
                    return dataTable;
                }
                return null;

            }
        }

        private DataGridView DataGridView
        {
            get
            {
                return dataGridViewHost.Control as DataGridView;
            }
        }

        private ComboBoxBase CmbBox
        {
            get
            {
                return cmbBoxHost.Control as ComboBoxBase;
            }

        }

        /// <summary>
        /// 当前输入码
        /// </summary>
        private int InputCode
        {
            set
            {
                this.iSpellCode = value;
                switch (iSpellCode)
                {
                    case 0:
                        queryTypeList = "编码+名称+拼音码+五笔码+自定义码";
                        this.BackColor = Color.FromArgb(255, 255, 255);
                        break;
                    case 1:
                        queryTypeList = "拼音码";
                        this.BackColor = Color.FromArgb(255, 225, 225);
                        break;
                    case 2:
                        this.BackColor = Color.FromArgb(255, 200, 200);
                        queryTypeList = "五笔码";
                        break;
                    case 3:
                        this.BackColor = Color.FromArgb(255, 150, 150);
                        queryTypeList = "编码";
                        break;
                    case 4:
                        this.BackColor = Color.FromArgb(255, 150, 150);
                        queryTypeList = "自定义码";
                        break;
                    default:
                        this.BackColor = Color.FromArgb(255, 255, 255);
                        break;
                }
                tooltip.SetToolTip(this, queryTypeList);
                tooltip.Active = true;
            }

        }
        #endregion

        #endregion

        #region 公开方法
        /// <summary>
        /// 设置ComboBox组件的DataSource
        /// </summary>
        /// <param name="ht"></param>
        public void NeuSetHashtableToDataSource(Hashtable ht)
        {
            IList<CmbObject> listObject = new List<CmbObject>();
            ICollection key = ht.Keys;
            IEnumerator e = key.GetEnumerator();
            while (e.MoveNext())
            {
                string value = (string)e.Current;
                CmbObject infoObject = new CmbObject();
                infoObject.Id = value;
                infoObject.Name = ht[value].ToString();
                listObject.Add(infoObject);
            }
            this.DataSource = listObject;
        }
        /// <summary>
        /// 设置ComboBox组件的DataSource
        /// </summary>
        /// <typeparam name="T">Enum类型</typeparam>
        public void NeuSetEnumObjectToDataSource<T>()
        {
            IList<FrameWork.Public.EnumHelper.EnumObject> list = FrameWork.Public.EnumHelper.Current.EnumList<T>();
            this.DataSource = list;
        }
        /// <summary>
        /// 设置ComboBox组件的DataSource
        /// </summary>
        /// <param name="str">字符串数组</param>
        public void NeuSetStringToDataSource(string[] str)
        {
            IList<CmbObject> list = new List<CmbObject>();
            for (int i = 0; i < str.Length; i++)
            {
                CmbObject cmbObject = new CmbObject();
                cmbObject.Name = str[i];
                int j = i + 1;
                cmbObject.Id = j.ToString();
                list.Add(cmbObject);
            }
            this.DataSource = list;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 设置DataGridView
        /// </summary>
        private void SetDataGridView()
        {
            if (flag && DataView != null)
            {
                _dt = this.DataView;
                DataGridView.DataSource = _dt.DefaultView;

                DataGridView.Columns[4].Visible = false;
                DataGridView.Columns[3].Visible = false;
                DataGridView.Columns[2].Visible = false;
                if (!IsShowCodeColumn)
                {
                    DataGridView.Columns[0].Visible = false;
                }
                DataGridView.Font = new Font("宋体", 9);

                dataGridViewHost.AutoSize = false;
                dataGridViewHost.Size = new Size(DropDownWidth, this.NeuHeight);


                dataGridViewHost.Padding = new Padding();
                dataGridViewHost.Margin = new Padding();


                cmbBoxHost.AutoSize = false;
                cmbBoxHost.Size = new Size(this.Width, this.Height);
                cmbBoxHost.Padding = new Padding();
                cmbBoxHost.Margin = new Padding();

                dropDown.Size = new Size(this.Width, this.Height);
                dropDown.Padding = new Padding();
                this.SetViewAutoSize();
                flag = false;
            }
        }
        /// <summary>
        /// 设置DropDown自动调整大小
        /// </summary>
        private void SetViewAutoSize()
        {
            int height = 47 + 23 * DataGridView.RowCount;
            if (height < this.NeuHeight)
            {
                if (!isOutScreen)
                {
                    dataGridViewHost.Size = new Size(DropDownWidth, height);
                }
            }
            else
            {
                dataGridViewHost.Size = new Size(DropDownWidth, this.NeuHeight);
            }

        }


        /// <summary>
        /// 显示DataView
        /// </summary>
        private void ShowDataView()
        {
            //CmbBox.Text = this.Text.Substring(0, this.Text.Length - 1);
            //this.Text = "";
            dropDown.Refresh();
            SetDataGridView();
            dropDown.Show(this, CalculatePoz());
            CmbBox.Text = CmbBox.Text.Trim();
            CmbBox.Focus();
            CmbBox.SelectionStart = CmbBox.Text.Length;
        }

        /// <summary>
        /// 显示Form控件
        /// </summary>
        private void ShowSelectDialog()
        {

            //调用SelectItemForm下的public void InitItem(IList<T> items)方法
            if (formObject != null)
            {
                if (showDialogFlag)
                {
                    this.ExecuteMethod(this.formObject, "InitItem", BindingFlags.Public, new object[] { base.DataSource });
                    showDialogFlag = false;
                }
                //初始化SelectItemForm下的方法
                Type[] types = new Type[0];
                DialogResult dialogResult = (DialogResult)this.ExecuteMethod(this.formObject, "ShowDialog", BindingFlags.Public, types, null);

                if (dialogResult == DialogResult.OK)
                {
                    object obj = this.GetProperty(this.formObject, "SelectedItem");
                    this.SelectedValue = this.GetProperty(obj, ToString(_id));
                    this.SelectionStart = this.Text.Length;
                }
                else
                {
                    this.Text = this.Text.Replace(" ", "");
                    this.SelectionStart = this.Text.Length;
                }
            }

        }

        /// <summary>
        /// 获取Combox中的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <returns></returns>
        private DataTable FillInDataView<T>(IList<T> datas)
        {

            using (DataTable dt = new DataTable())
            {
                DataColumn[] colDept = {new DataColumn("编码"),
						            new DataColumn("名称"),
						            new DataColumn("拼音码"),
						            new DataColumn("五笔码"),
                                    new DataColumn("自定义码")};
                dt.Columns.AddRange(colDept);

                foreach (T Info in datas)
                {
                    DataRow row = dt.NewRow();
                    row["编码"] = this.ToString(this.GetProperty(Info, base.ValueMember));
                    string name = this.ToString(this.GetProperty(Info, base.DisplayMember));
                    row["名称"] = name;

                    if (ht.ContainsValue(this.SpellCode))
                    {
                        row["拼音码"] = ToString(GetProperty(Info, SpellCode));
                    }
                    else
                    {
                        if (IsSpellOrWbSearch)
                        {
                            row["拼音码"] = FrameWork.Public.String.GetSpell(name);
                        }
                    }
                    if (ht.ContainsValue(WbCode))
                    {
                        row["五笔码"] = ToString(GetProperty(Info, WbCode));
                    }
                    else
                    {
                        row["五笔码"] = string.Empty;
                    }
                    if (ht.ContainsValue(UserCode))
                    {
                        row["自定义码"] = this.ToString(this.GetProperty(Info, UserCode));
                    }
                    dt.Rows.Add(row);
                }
                return dt;
            }
        }

        /// <summary>
        /// 通过输入的查询码，过滤数据列表
        /// </summary>
        private void Filter(string filter)
        {
            //设置过滤条件
            _dt.DefaultView.RowFilter = filter;
            this.SetViewAutoSize();
        }

        /// <summary>
        /// 设置Combox的值
        /// </summary>
        private void SetComboxText()
        {
            if (!string.IsNullOrEmpty(resultName))
            {
                if (base.ValueMember == null || base.DisplayMember == null)
                {
                    this.Text = resultName;
                }
                else
                {
                    this.SelectedValue = resultName;
                }
                this.SelectionStart = this.Text.Length;
                if (this.IsEnter)
                {
                    if (!this.Focused)
                    {
                        this.Focus();
                    }
                    //WindowsAPI.SendMessage(this.Handle, WM_KEYDOWN, VK_RETURN, 0);
                    SendKeys.SendWait("{ENTER}");
                }
            }
        }

        /// <summary>
        /// 处理显示框位置
        /// </summary>
        /// <returns></returns>
        private Point CalculatePoz()
        {
            Point point = new Point(0, 0);

            if ((this.PointToScreen(new Point(0, 0)).Y + this.Height + this.dataGridViewHost.Height) > Screen.PrimaryScreen.WorkingArea.Height)
            {
                point.Y = -this.dataGridViewHost.Height;
                dropDown.Items.Clear();
                dropDown.Items.Add(dataGridViewHost);
                dropDown.Items.Add(cmbBoxHost);
                this.isOutScreen = true;
            }
            else
            {
                if (isOutScreen)
                {
                    dropDown.Items.Clear();
                    dropDown.Items.Add(cmbBoxHost);
                    dropDown.Items.Add(dataGridViewHost);
                }

            }

            return point;
        }

        /// <summary>
        /// 处理按下UP或Down时，显示行的问题
        /// </summary>
        private void SetDisplayRow()
        {
            if (DataGridView.GetRowDisplayRectangle(DataGridView.SelectedRows[0].Index, true).Y <= 0)
            {
                DataGridView.FirstDisplayedScrollingRowIndex = DataGridView.SelectedRows[0].Index;
            }
            if (DataGridView.GetRowDisplayRectangle(DataGridView.SelectedRows[0].Index, true).Y >= this.NeuHeight - 40)
            {
                int currentrow = DataGridView.FirstDisplayedScrollingRowIndex + 1;
                DataGridView.FirstDisplayedScrollingRowIndex = currentrow;
            }
        }

        #endregion

        #region 事件

        private void cmbBox_DropDownHandler()
        {
            this.Focus();
            dropDown.Close();
            SetComboxText();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            CloseDropDown();
            SetComboxText();
        }

        private void CloseDropDown()
        {
            //this.SelectedIndex = -1;

            //this.Text = "";
            resultName = "";
            if (DataGridView.FirstDisplayedScrollingRowIndex != -1)
            {
                DataGridViewRow row = DataGridView.SelectedRows[0];
                if (base.ValueMember == null || base.DisplayMember == null)
                {
                    resultName = this.ToString(row.Cells[1].Value);
                }
                else
                {
                    resultName = this.ToString(row.Cells[0].Value);
                }
            }
            CmbBox.Text = "";
            dropDown.Close();

        }

        private void CmbBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        if (DataGridView.SelectedRows[0].Index < DataGridView.Rows.Count - 1)
                        {
                            DataGridView.Rows[DataGridView.SelectedRows[0].Index + 1].Selected = true;
                            SetDisplayRow();
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if (DataGridView.SelectedRows[0].Index > 0)
                        {
                            DataGridView.Rows[DataGridView.SelectedRows[0].Index - 1].Selected = true;
                            SetDisplayRow();
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (isShowDialog)
                        {
                            dropDown.Close();
                            e.Handled = true;
                            ShowSelectDialog();
                        }
                        break;
                    }
                case Keys.Enter:
                    {
                        CloseDropDown();
                        SetComboxText();
                        break;
                    }
            }
        }

        private void CmbBox_TextChanged(object sender, EventArgs e)
        {
            if (DataGridView.FirstDisplayedScrollingRowIndex != -1)
            {
                DataGridView.Rows[0].Selected = true;
            }
            string queryCode = "";
            queryCode = sign + FrameWork.Public.String.TakeOffSpecialChar(CmbBox.Text) + sign;
            string filter = "";
            if (queryTypeList.IndexOf("+") > 0)
            {
                string[] str = queryTypeList.Split('+');
                for (int i = 0; i < str.GetLength(0); i++)
                {
                    filter += "(" + str[i] + " LIKE '" + queryCode + "')OR ";
                }
                filter = filter.Substring(0, filter.LastIndexOf("OR"));
            }
            else
            {
                filter = "(" + queryTypeList + " LIKE '" + queryCode + "') ";
            }
            this.Filter(filter);
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CloseDropDown();
                SetComboxText();
            }
        }


        #endregion

        #region 重载方法
        /// <summary>
        /// WINDOWS消息处理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                if (IsShowDataView)
                {
                    if (!dropDown.Visible)
                    {
                        this.ShowDataView();
                        return;
                    }
                }
            }
            base.WndProc(ref m);

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (isShowDataView)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        {
                            e.Handled = true; break;
                        }
                    case Keys.F2:
                        {
                            if (IsShowF2)
                            {
                                e.Handled = true;
                                iSpellCode++;
                                if (iSpellCode >= 5) iSpellCode = 0;
                                InputCode = this.iSpellCode;
                            }
                            break;
                        }
                    case Keys.Space:
                        {
                            if (isShowDialog)
                            {
                                e.Handled = true;
                                ShowSelectDialog();
                            }
                            return;
                        }
                    case Keys.Back:
                        {
                            //e.Handled = true;
                            //this.ShowDataView();
                            return;
                        }
                    default:
                        {
                            e.Handled = true;
                            this.ShowDataView();
                            break;
                        }
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (isShowDataView)
            {
                if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar >= 97 && e.KeyChar <= 122)
                {
                    CmbBox.Text = e.KeyChar.ToString();
                    CmbBox.SelectionStart = CmbBox.Text.Length;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!IsLeave)
            {
                if (!string.IsNullOrEmpty(this.Text) && arrayList != null && !arrayList.Contains(this.Text))
                {
                    this.Focus();
                    return;
                }
            }
            base.OnLeave(e);
        }

        #endregion

        #region 反射常用方法
        /// <summary>
        /// 创建类型的一个实体
        /// </summary>
        /// <param name="assembly">要加载的程序集</param>
        /// <param name="name">该类型的全名</param>
        /// <returns>该类型的实体</returns>
        private object CreateInstance(string assembly, string name)
        {
            if (!string.IsNullOrEmpty(assembly))
            {
                Assembly objAssembly = Assembly.Load(assembly);
                if (!string.IsNullOrEmpty(name))
                {
                    Type type = objAssembly.GetType(name);
                    return Activator.CreateInstance(type);
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// 创建类型的一个实体
        /// </summary>
        /// <param name="name">该类型的全名</param>
        /// <returns>该类型的实体</returns>
        private object CreateInstance(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Type type = Type.GetType(name);
                return Activator.CreateInstance(type);
            }
            return null;
        }

        /// <summary>
        /// 设置类型属性值
        /// </summary>
        /// <param name="obj">类型的实体</param>
        /// <param name="propertyName">要设置的属性名称</param>
        /// <param name="value">要设置的数值</param>
        /// <param name="index">索引值，通常为NULL</param>
        private void SetProperty(object obj, string propertyName, object value, object[] index)
        {
            if (obj != null)
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(obj, value, index);
                }
            }
        }

        /// <summary>
        /// 返回类型的属性值
        /// </summary>
        /// <param name="obj">类型的实体</param>
        /// <param name="propertyName">要返回的属性名称</param>
        /// <returns>属性值</returns>
        private object GetProperty(object obj, string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    return propertyInfo.GetValue(obj, null);
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// 调用实体方法
        /// </summary>
        /// <param name="obj">类型的实体</param>
        /// <param name="methodName">方法的名称</param>
        /// <param name="bindingAttr">方法类型搜索的标志</param>
        /// <param name="types">方法的参数的类型（用来区别重载的）通常是NULL</param>
        /// <param name="args">方法的参数</param>
        /// <returns>方法执行后返回的值</returns>
        private object ExecuteMethod(object obj, string methodName, BindingFlags bindingAttr, Type[] types, object[] args)
        {
            if (obj != null)
            {
                MethodInfo method = obj.GetType().GetMethod(methodName, bindingAttr | BindingFlags.Instance, null, types, null);
                if (method != null)
                {
                    return method.Invoke(obj, args);
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// 调用实体方法
        /// </summary>
        /// <param name="obj">类型的实体</param>
        /// <param name="methodName">方法的名称</param>
        /// <param name="bindingAttr">方法类型搜索的标志</param>
        /// <param name="args">方法的参数</param>
        /// <returns>方法执行后返回的值</returns>
        private object ExecuteMethod(object obj, string methodName, BindingFlags bindingAttr, object[] args)
        {
            if (obj != null)
            {
                MethodInfo method = obj.GetType().GetMethod(methodName, bindingAttr | BindingFlags.Instance);
                if (method != null)
                {
                    return method.Invoke(obj, args);
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// 调用实体泛型方法
        /// </summary>
        /// <param name="obj">类型的实体</param>
        /// <param name="types">泛型方法中的泛型类型</param>
        /// <param name="methodName">方法的名称</param>
        /// <param name="bindingAttr">方法类型搜索的标志</param>
        /// <param name="args">方法的参数</param>
        /// <returns>方法执行后返回的值</returns>
        private object ExecuteGenericMethod(object obj, Type[] types, string methodName, BindingFlags bindingAttr, object[] args)
        {
            if (obj != null && args[0] != null)
            {
                MethodInfo method = obj.GetType().GetMethod(methodName, bindingAttr | BindingFlags.Instance);
                MethodInfo genericMethod = method.MakeGenericMethod(types);
                if (method != null && genericMethod != null)
                {
                    return genericMethod.Invoke(obj, args);
                }
                return null;
            }
            return null;
        }


        #endregion

        #region 不常用方法
        private string ToString(object obj)
        {
            if (obj == null) return "";

            return obj.ToString();
        }

        private Hashtable GetProperty(PropertyInfo[] property)
        {
            Hashtable result = new Hashtable();
            for (int i = 0; i < property.Length; i++)
            {
                string str = property[i].ToString();
                string s = str.Substring(str.IndexOf(' '), str.Length - str.IndexOf(' ')).Trim();
                result.Add(i, s);
            }
            return result;
        }

        #endregion

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(resultName))
        //    {
        //        this.Text = "";
        //    }
        //    base.OnTextChanged(e);
        //}

    }
    public enum QueryTypeEnum
    {
        编码,
        拼音码,
        五笔码,
        名称,
        自定义码
    }


    internal class CmbObject
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }





    #region 以后可能用得到，不要删除

    //Declare a class that inherits from ToolStripControlHost.
    //public class ToolStripDataGridViewHost : ToolStripControlHost
    //{
    //    #region Class Data
    //    #endregion

    //    // Call the base constructor passing in a MonthCalendar instance.
    //    public ToolStripDataGridViewHost(DataGridView dataGridView)
    //        : base(dataGridView)
    //    {
    //    }


    //    public DataGridView DataGridView
    //    {
    //        get
    //        {
    //            return Control as DataGridView;
    //        }
    //    }

    //    // Subscribe and unsubscribe the control events you wish to expose.
    //    protected override void OnSubscribeControlEvents(Control c)
    //    {
    //        // Call the base so the base events are connected.
    //        base.OnSubscribeControlEvents(c);

    //        // Cast the control to a MonthCalendar control.
    //        DataGridView gridView = (DataGridView)c;
    //        gridView.ReadOnly = true;
    //        // Add the event.
    //        gridView.KeyDown += new KeyEventHandler(OnKeyDown);
    //    }

    //    protected override void OnUnsubscribeControlEvents(Control c)
    //    {
    //        // Call the base method so the basic events are unsubscribed.
    //        base.OnUnsubscribeControlEvents(c);

    //        // Cast the control to a MonthCalendar control.
    //        DataGridView gridView = (DataGridView)c;
    //        gridView.ReadOnly = false;
    //        // Remove the event.
    //        gridView.KeyDown += new KeyEventHandler(OnKeyDown);
    //    }

    //    // Declare the DateChanged event.
    //    public event KeyEventHandler KeyDown;

    //    // Raise the DateChanged event.
    //    private void OnKeyDown(object sender, KeyEventArgs e)
    //    {
    //        if (KeyDown != null)
    //        {
    //            KeyDown(this, e);

    //        }
    //    }
    //}
    #endregion


}

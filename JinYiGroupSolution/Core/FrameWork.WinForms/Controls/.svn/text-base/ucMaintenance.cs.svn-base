using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using FarPoint.Win.Spread;
using Neusoft.FrameWork.WinForms.Forms;
using Neusoft.FrameWork.WinForms.Classes;
using System.Linq;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 查询控件]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-03]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMaintenance : UserControl, IMaintenanceControlable
    {
        #region 构造函数

        public ucMaintenance()
        {
            InitializeComponent();
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor( EnumSysColor.Green );
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle( this.fpSpread1 );
            this.Ini();
        }

        public ucMaintenance(string xmlID)
            : this()
        {
            this.BackColor = Neusoft.FrameWork.WinForms.Classes.Function.GetSysColor( EnumSysColor.Green );
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle( this.fpSpread1 );

            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
            string tempXmlID = xmlID;
            if (Neusoft.FrameWork.Management.Language.IsUseLanguage == true)            //多语言版本
            {
                tempXmlID = tempXmlID + "-" + Neusoft.FrameWork.Management.Language.CurrentLanguage;
            }
            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换

            Init( tempXmlID );
        }

        private void Init(string xmlID)
        {
            this.xmlID = xmlID;
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            string xml = new MaintenanceControlManager().LoadData( xmlID );

            try
            {
                if (xml != null)
                {
                    xmlDoc.LoadXml( xml );
                }
                else
                {
                    MessageBox.Show( "根据" + xmlID + "加载设置信息发生错误" );
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show( "根据" + xmlID + "加载设置信息发生错误" + e.Message );
                return;
            }

            this.xmlElement = xmlDoc.DocumentElement;
            this.InitXml();
            HideTreeView();
        }

        #endregion

        #region 字段

        private TreeView treeView;
        private IMaintenanceForm queryForm;
        private IMaintenanceModifyControl queryModifyControl;
        private bool isDirty;
        private bool isSQLChanged = true;                    //是否改变是SQL
        private bool isQuerying;                             //是否正在查询

        private string filterColumn;
        private string xmlID;                               //维护所使用的XML
        private string sql;                                 //SQL语句
        private Form modifyControlForm;

        protected XmlElement xmlElement;

        private Dictionary<string, Dictionary<string, string>> dictCombos = new Dictionary<string, Dictionary<string, string>>();       //存贮ComboBox项目

        private List<int> insertRows = new List<int>();
        private List<int> deleteRows = new List<int>();
        private List<int> updateRows = new List<int>();

        private List<string> primaryKeys = new List<string>();          //主键列
        private Dictionary<string, FieldInfo> fieldInfos = new Dictionary<string, FieldInfo>();     //字段信息

        private string tableName;
        private string insertSQL;
        private string deleteSQL;
        private string OperatorID;                          //操作员字段
        private string OperteDate;                          //操作时间

        private const string ComboValue = "Value";          //反查时用的Dictionary 的名字增加的标识
        Neusoft.FrameWork.Management.DataBaseManger DB = new Neusoft.FrameWork.Management.DataBaseManger();

        private string selectSQL = string.Empty;
        private string whereSQL = string.Empty;

        private Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numberCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();

        protected bool isDataLoaded = false;                //数据是否已经查出

        private Dictionary<string, int> columnLength = new Dictionary<string, int>();
        #endregion

        #region 属性

        private Form ModifyControlForm
        {
            get
            {
                if (this.modifyControlForm == null)
                {
                    this.modifyControlForm = new Form();
                }
                return this.modifyControlForm;
            }
        }

        private TreeView TreeView
        {
            get
            {
                if (this.treeView == null)
                {
                    this.treeView = new TreeView();
                    this.treeView.Dock = DockStyle.Fill;
                    this.treeView.Scrollable = true;
                    this.treeView.HideSelection = false;
                    this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.neuTreeView1_AfterSelect );
                    this.splitContainer1.Panel1.Controls.Add( this.treeView );
                }

                return this.treeView;
            }
        }

        private string InsertSQL
        {
            get
            {
                if (this.insertSQL == null)
                {
                    System.Text.StringBuilder sb = new StringBuilder();
                    sb.Append( "insert into " );
                    sb.Append( this.TableName );
                    sb.Append( "(" );

                    for (int i = 0; i < this.fpSpread1_Sheet1.Columns.Count; i++)
                    {
                        string columnID = this.fpSpread1_Sheet1.Columns[i].Tag.ToString().ToUpper();
                        //有操作员编码及操作日期，不在重复加入
                        if (this.OperatorID != null)
                        {
                            if (columnID == this.OperatorID)
                                continue;
                        }
                        if (this.OperteDate != null)
                        {
                            if (columnID == this.OperteDate)
                                continue;
                        }

                        sb.Append( " " );
                        sb.Append( columnID );
                        sb.Append( "," );
                    }
                    if (this.OperatorID != null && this.OperteDate != null)
                    {
                        sb.Append( this.OperatorID );
                        sb.Append( ", " );
                        sb.Append( this.OperteDate );
                    }
                    else
                        sb.Remove( sb.Length - 1, 1 );

                    sb.Append( ")" );

                    sb.Append( " values(" );
                    for (int i = 0; i < this.fpSpread1_Sheet1.Columns.Count; i++)
                    {
                        string fieldName = this.fpSpread1_Sheet1.Columns[i].Tag.ToString().ToUpper();
                        //有操作员编码及操作日期，不在重复加入
                        if (this.OperatorID != null)
                        {
                            if (fieldName == this.OperatorID)
                                continue;
                        }
                        if (this.OperteDate != null)
                        {
                            if (fieldName == this.OperteDate)
                                continue;
                        }

                        FieldInfo fieldInfo = this.fieldInfos[fieldName];



                        //根据不同字段类型进行不同设置
                        if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE)
                        {
                            if (fieldInfo.DataType == FieldType.Varchar2)
                            {
                                sb.Append( string.Format( "'{{{0}}}', ", i.ToString() ) );
                            }
                            else if (fieldInfo.DataType == FieldType.Date)
                            {
                                sb.Append( string.Format( "to_date('{{{0}}}','yyyymmdd24hhmiss'), ", i.ToString() ) );
                            }
                            else
                            {
                                sb.Append( string.Format( "{{{0}}}, ", i.ToString() ) );
                            }
                        }
                        else if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)//DB2专用
                        {
                            if (i == 7)
                            {
                                sb.Append( string.Format( "{{{0}}},", i.ToString() ) );
                            }
                            else if (i == 10)
                            {
                                sb.Append( string.Format( "timestamp_format('{{{0}}}','yyyy-mm-dd hh24:mi:ss'),", i.ToString() ) );
                            }
                            else
                            {
                                sb.Append( string.Format( "'{{{0}}}', ", i.ToString() ) );
                            }
                        }
                    }
                    if (this.OperatorID != null && this.OperteDate != null)
                    {
                        sb.Append( "'" );
                        sb.Append( Neusoft.FrameWork.Management.Connection.Operator.ID );
                        sb.Append( "', " );
                        if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
                        {
                            sb.Append( "current timestamp" );
                        }
                        else if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.ORACLE)
                        {
                            sb.Append( HIS.OperateDate );
                        }
                        else
                        {
                            sb.Append( HIS.OperateDate );
                        }
                    }
                    else
                        sb.Remove( sb.Length - 2, 1 );
                    sb.Append( ")" );

                    this.insertSQL = sb.ToString();
                }

                return this.insertSQL;
            }
        }

        private string DeleteSQL
        {
            get
            {
                if (this.deleteSQL == null)
                {
                    System.Text.StringBuilder sb = new StringBuilder();
                    sb.Append( "delete from " );
                    sb.Append( this.TableName );
                    sb.Append( " where " );

                    for (int i = 0; i < this.primaryKeys.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append( " and " );
                        }

                        sb.Append( this.primaryKeys[i] );
                        sb.Append( string.Format( "='{{{0}}}'", i.ToString() ) );
                    }

                    this.deleteSQL = sb.ToString();
                }

                return this.deleteSQL;
            }
        }

        private string TableName
        {
            get
            {
                if (this.tableName == null)
                {
                    int i, j;
                    i = this.sql.ToLower().IndexOf( "from" );
                    j = this.sql.IndexOf( " ", i + 6 );
                    if (j != -1)
                        this.tableName = this.sql.Substring( i + 5, j - i - 5 );
                    else
                        this.tableName = this.sql.Substring( i + 5 );
                }

                return this.tableName;
            }
        }

        protected virtual string SQL
        {
            get
            {
                return this.sql;
            }
        }

        protected virtual string SelectSQL
        {
            get
            {
                return this.selectSQL;
            }
        }

        protected virtual string WhereSQL
        {
            get
            {
                return this.whereSQL;
            }
        }

        #endregion

        private enum RecordState
        {
            Normal,
            Insert,
            Update,
            Delete
        }

        #region 初始化方法

        private void Ini()
        {
            this.fpSpread1_Sheet1.RowCount = 0;
            this.fpSpread1_Sheet1.Columns[-1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            this.fpSpread1_Sheet1.Columns[1].AllowAutoSort = true;
            this.fpSpread1_Sheet1.Columns[2].AllowAutoSort = true;

            this.numberCellType.SpinButton = true;
            this.numberCellType.DecimalPlaces = 0;
        }

        private void InitXml()
        {
            //设置显示风格
            foreach (XmlAttribute attribute in this.xmlElement.Attributes)
            {
                if (attribute.Name == "ShowFilter")
                {
                    if (attribute.Value.ToLower() != "true")
                    {
                        this.HideFilter();
                    }

                    continue;
                }

                if (attribute.Name == "ShowTreeView")
                {
                    if (attribute.Value.ToLower() != "true")
                    {
                        this.HideTreeView();
                    }
                }
            }
            //分析SQL语句
            XmlNode xmlSQL = this.xmlElement.SelectSingleNode( "SQL" );
            this.sql = xmlSQL.InnerText;
            XmlAttribute attribute1;
            attribute1 = this.GetXmlAttribute( xmlSQL, "OperatorID" );
            if (attribute1 != null)
            {
                this.OperatorID = attribute1.Value;
            }

            attribute1 = this.GetXmlAttribute( xmlSQL, "OperateDate" );
            if (attribute1 != null)
            {
                this.OperteDate = attribute1.Value;
            }

            //设置TreeView
            XmlNode xmlTree = this.xmlElement.SelectSingleNode( "TreeView" );
            if (xmlTree != null)
            {
                TreeNode node = new TreeNode();

                node.Text = xmlTree.FirstChild.Attributes["Text"].Value;
                XmlAttribute attribute2 = this.GetXmlAttribute( xmlTree.FirstChild, "SQL" );
                if (attribute2 != null)
                {
                    node.Tag = attribute2.Value;
                }
                this.TreeView.Nodes.Add( node );
                this.MakeTree( node, xmlTree.FirstChild );
                this.TreeView.ExpandAll();
            }

        }

        #endregion

        #region 方法

        /// <summary>
        /// 隐藏过滤条件
        /// </summary>
        protected void HideFilter()
        {
            this.panel1.Visible = false;
        }

        /// <summary>
        /// 隐藏TreeView
        /// </summary>
        protected void HideTreeView()
        {
            this.splitContainer1.SplitterDistance = 0;

            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.IsSplitterFixed = true;
        }      

        /// <summary>
        /// 得到字段默认值
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        protected virtual string GetDefaultValue(string fieldName)
        {
            XmlNode node = this.xmlElement.SelectSingleNode( string.Format( "Columns/Column[@ID='{0}']", fieldName ) );
            if (node == null)
            {
                return string.Empty;
            }
            return node.Attributes["Default"].Value;
        }

        private string GetDefaultValue(int index)
        {
            string fieldName = this.fpSpread1_Sheet1.Columns[index].Tag.ToString().ToUpper();
            return this.GetDefaultValue( fieldName );
        }

        private string GetColumnType(string fieldName)
        {
            XmlNode node = this.xmlElement.SelectSingleNode( string.Format( "Columns/Column[@ID='{0}']", fieldName.ToUpper() ) );
            if (node == null)
            {
                return string.Empty;
            }
            return node.Attributes["DataType"].Value;
        }

        /// <summary>
        /// 生成树形控件结点结构
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="xmlNode"></param>
        private void MakeTree(TreeNode treeNode, XmlNode xmlNode)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                TreeNode tNode = new TreeNode();
                if (node.Name == "Node")
                {
                    tNode.Text = node.Attributes["Text"].Value;
                    XmlAttribute attribute = this.GetXmlAttribute( node, "SQL" );
                    if (attribute != null)
                    {
                        tNode.Tag = attribute.Value;
                    }
                    treeNode.Nodes.Add( tNode );
                    if (node.HasChildNodes)
                        this.MakeTree( tNode, node );
                }
                else if (node.Name == "NodeList")
                {
                    string id = null;
                    string name = null;
                    string sql = null;

                    XmlAttribute attribute = this.GetXmlAttribute( node, "SQL" );
                    if (attribute != null)
                    {
                        sql = attribute.Value;
                    }
                    attribute = this.GetXmlAttribute( node, "ID" );
                    if (attribute != null)
                    {
                        id = attribute.Value;

                    }
                    attribute = this.GetXmlAttribute( node, "Name" );
                    if (attribute != null)
                    {
                        name = attribute.Value;

                    }
                    if (sql != null && id != null && name != null)
                    {
                        sql = MaintenanceUtil.GenSQL( sql );
                        if (this.DB.ExecQuery( sql ) != -1)
                        {
                            while (this.DB.Reader.Read())
                            {
                                TreeNode n = new TreeNode();
                                n.Text = this.DB.Reader[name].ToString();
                                n.Tag = this.DB.Reader[id].ToString();
                                treeNode.Nodes.Add( n );

                            }
                            this.DB.Reader.Dispose();
                        }
                    }
                }
            }
        }

        private XmlAttribute GetXmlAttribute(XmlNode node, string name)
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (attribute.Name == name)
                {
                    return attribute;
                }
            }

            return null;
        }

        private string GenFilterSQL()
        {
            if (this.filterColumn == null || this.txtFilter.Text.Length == 0)
                return this.SQL;
            string farmat;
            string lowSql = this.sql.ToLower();
            //string select = string.Empty;
            //string where = string.Empty;
            string orderby = string.Empty;
            //string ret;
            int intWhere = lowSql.IndexOf( "where" );
            int intOrderby = lowSql.IndexOf( "order by" );

            if (intWhere > 0)
            {
                this.selectSQL = this.sql.Substring( 0, intWhere );
                if (intOrderby > 0)
                {
                    this.whereSQL = this.sql.Substring( intWhere, intOrderby - intWhere );
                    orderby = this.sql.Substring( intOrderby );
                }
                else
                    this.whereSQL = this.sql.Substring( intWhere );
            }
            else
            {
                if (intOrderby > 0)
                {
                    selectSQL = this.sql.Substring( 0, intOrderby );
                    orderby = this.sql.Substring( intOrderby );
                }
                else
                    selectSQL = this.sql;
            }

            if (this.whereSQL.Length == 0)
            {
                this.whereSQL = "where ";
            }
            else
            {
                this.whereSQL = this.whereSQL + " and ";
            }

            if (this.chkBlur.Checked)
                farmat = "{0} {1} {2} like '%{3}%' {4}";
            else
                farmat = "{0} {1} {2} like '{3}%' {4}";


            return string.Format( farmat, this.SelectSQL, this.WhereSQL, this.filterColumn, this.txtFilter.Text, orderby );
        }

        public int Query(string sql)
        {
            this.isQuerying = true;

            this.fpSpread1_Sheet1.RowCount = 0;

            if (sql == null || sql == "")
            {

                return -1;
            }

            if (DB.ExecQuery( sql ) == -1)
            {
                MessageBox.Show( DB.Err );
                return -1;
            }
            if (this.isSQLChanged)
            {
                this.Reset();
                this.InitSpreadData();
                this.isSQLChanged = false;
            }

            //新增代码,给DB2用,什么东西啊
            if (Neusoft.FrameWork.Management.Connection.DBType == Neusoft.FrameWork.Management.Connection.EnumDBType.DB2)
            {
                if (DB.Reader != null)
                {
                    if (DB.Reader.IsClosed)
                    {
                        if (DB.ExecQuery( sql ) == -1)
                        {
                            MessageBox.Show( DB.Err );
                            return -1;
                        }
                    }
                }
            }

            while (DB.Reader.Read())
            {
                this.fpSpread1_Sheet1.RowCount += 1;
                this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.RowCount - 1].Tag = RecordState.Normal;

                for (int i = 0; i < DB.Reader.FieldCount; i++)
                {
                    if (this.dictCombos.ContainsKey( this.fpSpread1_Sheet1.Columns[i].Tag.ToString() ))
                    {
                        Dictionary<string, string> dict = this.dictCombos[this.fpSpread1_Sheet1.Columns[i].Tag.ToString()];
                        if (dict.ContainsKey( DB.Reader[i].ToString() ))
                            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1, i].Text = dict[DB.Reader[i].ToString()];
                        else
                            MessageBox.Show( string.Format( "选择项 {0} 未设置 {1} ,请与系统管理员联系！", DB.Reader.GetName( i ), DB.Reader[i].ToString() ) );
                    }
                    else
                    {
                        this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.RowCount - 1, i].Text = DB.Reader[i].ToString();
                    }
                }

            }
            DB.Reader.Dispose();
            //this.dataSet.Clear();
            //DB.FillDataSet(this.dataSet);
            //this.fpSpread1_Sheet1.DataSource = this.dataSet;
            this.isQuerying = false;
            return 0;
        }

        /// <summary>
        /// 根据XML初使化Spread
        /// </summary>
        private void InitSpreadData()
        {
            this.fpSpread1_Sheet1.ColumnCount = DB.Reader.FieldCount;
            for (int i = 0; i < DB.Reader.FieldCount; i++)
            {
                this.fpSpread1_Sheet1.Columns[i].Tag = DB.Reader.GetName( i ).ToLower();
            }
            //获得表字段信息
            this.fieldInfos = SqlManager.GetFieldInfo( this.TableName );
            //设置列
            XmlNodeList xmlColumns = this.xmlElement.SelectNodes( "Columns/Column" );
            foreach (XmlNode xmlColumn in xmlColumns)
            {
                XmlAttribute attribute;
                string columnID = xmlColumn.Attributes["ID"].Value.ToLower();
                FarPoint.Win.Spread.Column column = this.fpSpread1_Sheet1.Columns[columnID];
                column.Label = xmlColumn.Attributes["Name"].Value;

                attribute = this.GetXmlAttribute( xmlColumn, "PrimaryKey" );
                if (attribute != null)
                {
                    bool isPrimaryKey = Convert.ToBoolean( attribute.Value );
                    column.Locked = isPrimaryKey;
                    if (isPrimaryKey)
                        this.primaryKeys.Add( columnID );
                }

                if (!column.Locked)
                {
                    attribute = this.GetXmlAttribute( xmlColumn, "Locked" );
                    if (attribute != null)
                    {
                        column.Locked = Convert.ToBoolean( attribute.Value );
                    }
                }

                attribute = this.GetXmlAttribute( xmlColumn, "Filter" );
                if (attribute != null)
                {
                    if (Convert.ToBoolean( attribute.Value ))
                        this.filterColumn = columnID;
                }
                attribute = this.GetXmlAttribute( xmlColumn, "Visible" );
                if (attribute != null)
                {

                    column.Visible = Convert.ToBoolean( attribute.Value );
                }
                //  设置列类型
                //  Robin   2007-04-09
                attribute = this.GetXmlAttribute( xmlColumn, "CellType" );
                if (attribute != null)
                {
                    if (attribute.Value == "NumberCellType")
                        column.CellType = this.numberCellType;
                }
                //设置ComboBox
                XmlNodeList xmlComboItems = xmlColumn.SelectNodes( "ComboBoxItem" );
                if (xmlComboItems.Count > 0)
                {
                    Dictionary<string, string> comboDict = new Dictionary<string, string>();
                    Dictionary<string, string> comboDictValue = new Dictionary<string, string>();       //用于保存时反查
                    string[] combo = new string[xmlComboItems.Count];

                    for (int i = 0; i < xmlComboItems.Count; i++)
                    {
                        combo[i] = xmlComboItems[i].Attributes["Value"].Value;
                        comboDict.Add( xmlComboItems[i].Attributes["ID"].Value, xmlComboItems[i].Attributes["Value"].Value );
                        comboDictValue.Add( xmlComboItems[i].Attributes["Value"].Value, xmlComboItems[i].Attributes["ID"].Value );
                    }
                    this.dictCombos.Add( columnID, comboDict );
                    this.dictCombos.Add( columnID + ComboValue, comboDictValue );
                    FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    attribute = this.GetXmlAttribute( xmlColumn, "ComboBoxEditable" );
                    if (attribute != null)
                    {
                        comboBoxCellType.Editable = bool.Parse( attribute.Value );
                    }

                    comboBoxCellType.Items = combo;
                    column.CellType = comboBoxCellType;
                }

                //
                attribute = this.GetXmlAttribute( xmlColumn, "Length" );
                if (attribute != null)
                {

                    this.columnLength.Add( columnID, int.Parse( attribute.Value ) );
                }
            }
        }

        private void Reset()
        {
            this.dictCombos.Clear();
            this.primaryKeys.Clear();
            this.insertSQL = null;
            this.deleteSQL = null;
        }

        /// <summary>
        /// 检察数据是否合法
        /// </summary>
        /// <returns></returns>
        /// Robin   2007-04-09
        private bool IsValid()
        {
            #region 逐格校验

            //检察主键列是否为空
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                //{5D4DF178-D38D-4715-8B6B-9F1778C08CD2}
                string code = this.fpSpread1_Sheet1.Cells[i, 1].Text.Trim();                

                if (code.IndexOf( "'" ) >= 0)
                {
                    //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数编码中不能含有“ ' ”符号" ) );
                    return false;
                }

                if (code.IndexOf( "(" ) >= 0)
                {
                    //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数编码中不能含有 左括号'(' 或 右括号')' " ) );
                    return false;
                }

                if (code.IndexOf( ")" ) >= 0)
                {
                    //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数编码中不能含有 左括号'(' 或 右括号')' " ) );
                    return false;
                }


                for (int j = 0; j < this.fpSpread1_Sheet1.ColumnCount; j++)
                {
                    string strID = fpSpread1_Sheet1.Columns[j].Tag.ToString();
                    if (this.fpSpread1_Sheet1.Columns[j].Visible
                        && this.fpSpread1_Sheet1.Rows[i].Visible
                        && this.primaryKeys.Contains( strID )
                        && this.fpSpread1_Sheet1.Cells[i, j].Text.Length == 0)
                    {
                        string msg = string.Format( "{0} " + Neusoft.FrameWork.Management.Language.Msg( "不能为空，请重试" ), this.fpSpread1_Sheet1.Columns[j].Label );
                        MessageBox.Show( msg );
                        return false;
                    }

                    #region 校验字符类型的

                    if (this.columnLength.ContainsKey( strID ))
                    {
                        string data;
                        if (this.GetColumnType( strID ) == "Varchar2")
                        {
                            if (this.dictCombos.ContainsKey( strID ))
                            {
                                //进行反查
                                Dictionary<string, string> dict = this.dictCombos[strID + ComboValue];
                                if (dict.ContainsKey( fpSpread1_Sheet1.Cells[i, j].Text ))
                                    data = dict[fpSpread1_Sheet1.Cells[i, j].Text];
                                else
                                    data = string.Empty;
                            }
                            else
                                data = this.fpSpread1_Sheet1.Cells[i, j].Text;

                            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh( data, this.columnLength[strID] ))
                            {
                                //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                                MessageBox.Show( fpSpread1_Sheet1.Columns[j].Label + Neusoft.FrameWork.Management.Language.Msg( "超长" ) );
                                return false;
                            }
                        }
                    }

                    #endregion

                    #region 校验数字类型

                    if (this.GetColumnType( strID ) == "Number")
                    {
                        if (!Neusoft.FrameWork.Public.String.ValidMaxLengh( this.fpSpread1_Sheet1.Cells[i, j].Text, this.columnLength[strID] ))
                        {
                            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                            MessageBox.Show( fpSpread1_Sheet1.Columns[j].Label + Neusoft.FrameWork.Management.Language.Msg( "超长" ) );
                            return false;
                        }
                    }

                    #endregion
                }
            }

            #endregion

            #region 验证编码是否重复

            //liuke 20091104 add start
            List<string> codeList = new List<string>();
            int rowCount = this.fpSpread1_Sheet1.RowCount;
            int colIndex = this.fpSpread1_Sheet1.Columns["code"].Index;
            for (int row = 0; row < this.fpSpread1_Sheet1.RowCount; row++)
            {
                codeList.Add( this.fpSpread1_Sheet1.Cells[row, colIndex].Text );
            }
            int disRowCount = codeList.Distinct().Count();
            if (disRowCount < rowCount)
            {
                //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数编码不能重复" ) );
                return false;
            }
            //liuke 20091104 add end

            #endregion

            int col = -1;
            for (int index = -1; index < this.fpSpread1_Sheet1.Columns.Count; index++)
            {//寻找名称列
                //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                if (fpSpread1_Sheet1.Columns[index].Label == Neusoft.FrameWork.Management.Language.Msg("名称"))
                {
                    col = index;
                    break;
                }
            }

            if (col != -1)
            {

                for (int mm = 0; mm < this.fpSpread1_Sheet1.RowCount; mm++)
                {
                    #region 名称不能为空

                    if (fpSpread1_Sheet1.Cells[mm, col].Text == "")
                    {
                        //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                        MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数数据项名称不能为空" ) );
                        return false;
                    }
                    #endregion

                    if (!this.fpSpread1_Sheet1.Rows[mm].Visible)
                    {
                        continue;
                    }
                    for (int nn = 0; nn < this.fpSpread1_Sheet1.RowCount; nn++)
                    {
                        if (mm == nn)
                        {
                            continue;
                        }
                        if (!this.fpSpread1_Sheet1.Rows[nn].Visible)
                        {
                            continue;
                        }
                        if (fpSpread1_Sheet1.Cells[mm, col].Text == fpSpread1_Sheet1.Cells[nn, col].Text)
                        {
                            //{1B10BCB7-8133-4282-8479-9C41FE5A23FD} 区域语言转换
                            MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "常数数据项名称不能重复" ) );
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            this.Reset();
            this.insertRows.Clear();
            this.deleteRows.Clear();
            this.updateRows.Clear();

            if (base.Tag != null && base.Tag.ToString() != "")
                this.Init( base.Tag.ToString() );
            base.OnLoad( e );
        }
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.queryModifyControl != null)
            {
                if (this.modifyControlForm == null)
                {
                    this.modifyControlForm = new Form();

                    Control c = this.queryModifyControl as Control;
                    c.Dock = DockStyle.Fill;
                    this.modifyControlForm.Controls.Add( c );
                }

                this.modifyControlForm.ShowDialog();
            }
        }

        private void neuTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                string nodeTag = e.Node.Tag.ToString().ToLower();
                if (nodeTag.IndexOf( "select" ) > 0)
                {
                    this.sql = nodeTag;
                    this.isSQLChanged = true;
                    this.Query( this.GenFilterSQL() );
                }
                else
                {
                    this.Query( this.sql.Replace( "NeuNodeID", e.Node.Tag.ToString() ) );

                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Query( this.GenFilterSQL() );
            }
        }

        private void chkBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (this.txtFilter.Text.Length != 0)
            {
                this.Query( this.GenFilterSQL() );
            }
        }

        protected virtual void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (!this.isQuerying && (!this.insertRows.Contains( e.Row )) && (!this.updateRows.Contains( e.Row )) && e.Row >= 0)
            {
                this.updateRows.Add( e.Row );
                this.isDirty = true;
            }


        }
        protected virtual void fpSpread1_EditModeOff(object sender, EventArgs e)
        {

        }
        #endregion

        //private static class DB
        //{
        //    private static IDbConnection connection;
        //    private static IDbCommand command;
        //    public static IDataReader reader;
        //    private static OracleDataAdapter adapter;
        //    static DB()
        //    {
        //        connection = new OracleConnection();
        //        command = new OracleCommand();
        //        adapter = new OracleDataAdapter();
        //        command.Connection = connection;

        //        connection.ConnectionString = "data source=CHCC;password=his;persist security info=True;user id=HIS";
        //        connection.Open();

        //    }

        //    public static int ExecReader(string sql)
        //    {
        //        command.CommandText = sql;
        //        reader = command.ExecuteReader();
        //        return 0;
        //    }
        //    public static int ExecNonQuery(string sql)
        //    {
        //        command.CommandText = sql;
        //        return command.ExecuteNonQuery();

        //    }

        //    public static int FillDataSet(DataSet ds)
        //    {
        //        adapter.SelectCommand = command as OracleCommand;
        //        adapter.Fill(ds);
        //        return 0;
        //    }





        //}

        #region IMaintenanceControlable 成员

        public IMaintenanceForm QueryForm
        {
            get
            {
                return this.queryForm;
            }
            set
            {
                this.queryForm = value;
            }
        }

        public int Init()
        {
            if (this.xmlID == null)
            {
                if (this.Tag != null)
                {
                    //System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    //xmlDoc.Load(this.Tag.ToString());
                    //this.xmlElement = xmlDoc.DocumentElement;
                    //this.InitXml();
                }
                else
                {
                    MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "未设置初使化参数" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return -1;
                }
            }
            return 0;
        }

        public int Query()
        {
            this.insertRows.Clear();
            this.deleteRows.Clear();
            this.updateRows.Clear();
            this.isDirty = false;
            this.isDataLoaded = false;
            int ret = this.Query( this.GenFilterSQL() );
            this.isDataLoaded = true;

            return ret;
        }

        public int Add()
        {
            this.fpSpread1_Sheet1.RowCount += 1;
            int rowIndex = this.fpSpread1_Sheet1.RowCount - 1;

            if (!this.insertRows.Contains( rowIndex ))
                this.insertRows.Add( rowIndex );

            foreach (Column column in this.fpSpread1_Sheet1.Columns)
            {
                if (column.Locked)
                    this.fpSpread1_Sheet1.Cells[rowIndex, column.Index].Locked = false;
            }
            //this.fpSpread1_Sheet1.Cells[1, 2].Locked = false;
            this.isDirty = true;
            return 0;
        }

        public int Delete()
        {
            if (MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg( "确认要删除当前选择数据吗？"), "提示", MessageBoxButtons.YesNo ) == DialogResult.No)
            {
                return -1;
            }
            //  如果是新添加的就移除添加标记
            //  Robin   2007-04-16
            if (this.insertRows.Contains( this.fpSpread1_Sheet1.ActiveRowIndex ))
            {
                //this.insertRows.RemoveAt(this.fpSpread1_Sheet1.ActiveRowIndex);
                this.insertRows.Remove( this.fpSpread1_Sheet1.ActiveRowIndex );
                //liuke 20091030 mod start
                this.fpSpread1_Sheet1.ActiveRow.Remove();
                //this.fpSpread1_Sheet1.ActiveRow.Visible = false;
                //liuke 20091030 mod end
                return 0;
            }

            this.deleteRows.Add( this.fpSpread1_Sheet1.ActiveRowIndex );
            this.fpSpread1_Sheet1.ActiveRow.Visible = false;
            //string a = this.InsertSQL;
            //a = this.DeleteSQL;
            this.isDirty = true;
            return 0;
        }

        public int Save()
        {
            this.fpSpread1.StopCellEditing();
            if (!this.IsValid())
                return -2;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            DB.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );
            //添加记录
            foreach (int i in this.insertRows)
            {
                if (this.InsertRow( i ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    if (DB.DBErrCode == 1)
                    {
                        return -1;
                    }
                    MessageBox.Show( DB.Err );
                    return -1;
                }
                //锁定应该锁定的Cell
                foreach (Column column in this.fpSpread1_Sheet1.Columns)
                {
                    if (column.Locked)
                        this.fpSpread1_Sheet1.Cells[i, column.Index].Locked = true;
                }

            }

            foreach (int i in this.deleteRows)
            {
                if (this.DeleteRow( i ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( DB.Err );
                    return -1;
                }
            }

            foreach (int i in this.updateRows)
            {
                if (this.DeleteRow( i ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( DB.Err );
                    return -1;
                }
                if (this.InsertRow( i ) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show( DB.Err );
                    return -1;
                }
            }

            this.insertRows.Clear();
            this.deleteRows.Clear();
            this.updateRows.Clear();
            this.isDirty = false;
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            this.Refresh();
            MessageBox.Show( Neusoft.FrameWork.Management.Language.Msg( "保存成功" ), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
            return 0;
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="i">行Index</param>
        /// <returns>0 成功,-1 失败</returns>
        private int DeleteRow(int i)
        {
            string s1;
            string[] columns = new string[this.primaryKeys.Count];
            for (int k = 0; k < this.primaryKeys.Count; k++)
            {
                string key = this.primaryKeys[k];
                int j = this.fpSpread1_Sheet1.Columns[key].Index;
                //不显示则用默认值
                if (this.fpSpread1_Sheet1.Columns[key].Visible == false)
                {
                    columns[k] = this.GetDefaultValue( j );
                }
                else
                {
                    columns[k] = this.fpSpread1_Sheet1.Cells[i, j].Text;
                }
            }
            s1 = string.Format( this.DeleteSQL, columns );
            int ret = DB.ExecNoQuery( s1 );
            if (ret == -1)
            {
                MessageBox.Show( string.Format( "删除数据失败，第 {0} 行未能删除！", (i + 1).ToString() ) );
                this.fpSpread1_Sheet1.ActiveRowIndex = i;
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="i">行Index</param>
        /// <returns>0 成功,-1 失败</returns>
        private int InsertRow(int i)
        {
            string s1;
            string[] columns = new string[this.fpSpread1_Sheet1.Columns.Count];
            for (int j = 0; j < this.fpSpread1_Sheet1.Columns.Count; j++)
            {
                string cellText;
                //liuke 20091104 add start
                if (this.fpSpread1_Sheet1.Rows.Count < i)
                {
                    return 0;
                }
                //liuke 20091104 add end
                //不显示或为空则用默认值
                if (this.fpSpread1_Sheet1.Columns[j].Visible == false || this.fpSpread1_Sheet1.Cells[i, j].Text.Length == 0)
                {
                    cellText = columns[j] = this.GetDefaultValue( j );
                    continue;
                }
                else
                {
                    cellText = columns[j] = this.fpSpread1_Sheet1.Cells[i, j].Text;
                }

                string columnID = this.fpSpread1_Sheet1.Columns[j].Tag.ToString();
                if (this.dictCombos.ContainsKey( columnID ))
                {
                    //进行反查
                    Dictionary<string, string> dict = this.dictCombos[columnID + ComboValue];
                    if (dict.ContainsKey( cellText ))
                        columns[j] = dict[cellText];
                    else
                        columns[j] = string.Empty;
                }
                else
                    columns[j] = this.fpSpread1_Sheet1.Cells[i, j].Text;
            }
            //s1 = string.Format(this.InsertSQL, columns);
            int ret = DB.ExecNoQuery( InsertSQL, columns );
            if (ret == -1 && DB.DBErrCode == 1)
            {
                MessageBox.Show( string.Format( "第 {0} 行编码已存在！", (i + 1).ToString() ) );
                this.fpSpread1_Sheet1.ActiveRowIndex = i;
                return -1;
            }
            return ret;
        }

        public int Export()
        {
            return this.fpSpread1.Export();
        }

        public int Print()
        {
            return 0;
        }

        public bool IsDirty
        {
            get
            {
                return this.isDirty;
            }
            set
            {
                this.isDirty = value;
            }
        }



        public int Modify()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int Import()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int PrintPreview()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int PrintConfig()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int Cut()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int Copy()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int Paste()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int NextRow()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        public int PreRow()
        {
            throw new Exception( "The method or operation is not implemented." );
        }

        #endregion

        private void ucMaintenance_Load(object sender, EventArgs e)
        {

        }
    }

}


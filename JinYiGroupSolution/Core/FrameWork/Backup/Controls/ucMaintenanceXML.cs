using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
using System.Xml;
using Neusoft.FrameWork.WinForms.Classes;

namespace Neusoft.FrameWork.WinForms.Controls
{
    /// <summary>
    /// [功能描述: 维护 维护控件 所用的数据]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2006-11-15]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucMaintenanceXML : UserControl, IMaintenanceControlable
    {
        #region ctro
        public ucMaintenanceXML()
        {
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(neuSpread1);
            this.InitSpread();

        }

        public ucMaintenanceXML(string id)
            : this()
        {
            this.id = id;

        }
        #endregion

        #region 字段
        private bool isDirty;
        private string id;
        private IMaintenanceForm maintenanceForm;
        private MaintenanceControlManager manager = new MaintenanceControlManager();
        private Neusoft.FrameWork.Management.DataBaseManger DB = new Neusoft.FrameWork.Management.DataBaseManger();
        private XmlDocument xmlDoc = new XmlDocument();
        #endregion

        #region 属性
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        #endregion
        #region IMaintenanceControlable 成员

        public IMaintenanceForm QueryForm
        {
            get
            {
                return this.maintenanceForm;
            }
            set
            {
                this.maintenanceForm = value;
            }
        }

        public int Init()
        {
            if (this.Tag != null)
            {
                this.id = this.Tag.ToString();
            }
            else
                return -1;

            return 0;
        }

        public int Query()
        {
            if (this.id == null)
            {
                this.id = this.Tag.ToString();
            }

            string xml = this.manager.LoadData(this.id);
            if (xml != null)
            {
                this.xmlDoc.LoadXml(xml);

                this.AnalysisXml();
            }

            return 0;
        }

        public int Add()
        {

            return 0;
        }

        public int Delete()
        {
            return 0;
        }

        public int Modify()
        {
            return 0;
        }

        public int Save()
        {
            if (this.id == null)
            {
                MessageBox.Show("未设置ID！");
                return -1;
            }
            this.GenXML();
            int ret = this.manager.InsertData(this.id, this.xmlDoc.InnerXml);
            if (ret == -1)
            {
                MessageBox.Show("保存失败," + this.manager.Err);
            }
            return ret;
        }

        public int Import()
        {
            return 0;
        }

        public int Export()
        {
            return 0;
        }

        public int Print()
        {
            return 0;
        }

        public int PrintPreview()
        {
            return 0;
        }

        public int PrintConfig()
        {
            return 0;
        }

        public int Cut()
        {
            return 0;
        }

        public int Copy()
        {
            return 0;
        }

        public int Paste()
        {
            return 0;
        }

        public int NextRow()
        {
            return 0;
        }

        public int PreRow()
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

        #endregion


        #region 方法 
        private void InitSpread()
        {
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
            buttonCellType.Text = "...";
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();
            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            numCellType.DecimalPlaces = 0; 
            comboBoxCellType.Items = new string[] { "TextBox", "CheckBox", "ComboBox", "EditableComboBox", "DateTimePicker", "NumberCellType" };

            this.neuSpread1_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread1_Sheet1.ColumnCount = 12;
            this.neuSpread1_Sheet1.Columns[0].Label = "字段";
            this.neuSpread1_Sheet1.Columns[1].Label = "名称";
            this.neuSpread1_Sheet1.Columns[2].Label = "主键";
            this.neuSpread1_Sheet1.Columns[3].Label = "过滤条件";
            this.neuSpread1_Sheet1.Columns[4].Label = "锁定";
            this.neuSpread1_Sheet1.Columns[5].Label = "排序";
            this.neuSpread1_Sheet1.Columns[6].Label = "显示";
            this.neuSpread1_Sheet1.Columns[7].Label = "显示类型";
            this.neuSpread1_Sheet1.Columns[8].Label = "下拉框";
            this.neuSpread1_Sheet1.Columns[9].Label = "数据类型";
            this.neuSpread1_Sheet1.Columns[10].Label = "默认值";
            this.neuSpread1_Sheet1.Columns[11].Label = "长度";
            this.neuSpread1_Sheet1.Columns[0].Locked = true;
            this.neuSpread1_Sheet1.Columns[2].Locked = true;
            this.neuSpread1_Sheet1.Columns[9].Locked = true;
            this.neuSpread1_Sheet1.Columns[11].Locked = true;
            this.neuSpread1_Sheet1.Columns[2].CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns[3].CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns[4].CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns[5].CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns[6].CellType = checkBoxCellType;
            this.neuSpread1_Sheet1.Columns[7].CellType = comboBoxCellType;
            this.neuSpread1_Sheet1.Columns[8].CellType = buttonCellType;
            this.neuSpread1_Sheet1.Columns[10].CellType = textCellType;
            this.neuSpread1_Sheet1.Columns[11].CellType = numCellType;
            this.neuSpread1_Sheet1.Columns[0].Width = 120;
            this.neuSpread1_Sheet1.Columns[1].Width = 200;
            this.neuSpread1_Sheet1.Columns[7].Width = 120;
        }

        /// <summary>
        /// 生成XML
        /// </summary>
        private void GenXML()
        {
            //设置根节点
            this.xmlDoc.RemoveAll();
            XmlElement root = this.xmlDoc.CreateElement("MaintanceControl");
            root.SetAttribute("ShowFilter", this.chkFilter.Checked.ToString());
            this.xmlDoc.AppendChild(root);

            //设置SQL语句
            XmlElement xmlSQL = this.xmlDoc.CreateElement("SQL");
            if (this.cboOperator.SelectedIndex != 0)
                xmlSQL.SetAttribute("OperatorID", this.cboOperator.Text);
            if (this.cboOperDate.SelectedIndex != 0)
                xmlSQL.SetAttribute("OperateDate", this.cboOperDate.Text);

            xmlSQL.InnerText = this.txtSQL.Text;
            this.xmlDoc.DocumentElement.AppendChild(xmlSQL);

            //设置字段
            XmlElement xmlColumns = this.xmlDoc.CreateElement("Columns");
            this.xmlDoc.DocumentElement.AppendChild(xmlColumns);

            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                XmlElement xmlField = this.xmlDoc.CreateElement("Column");
                xmlField.SetAttribute("ID", this.neuSpread1_Sheet1.Cells[i, 0].Text);
                xmlField.SetAttribute("Name", this.neuSpread1_Sheet1.Cells[i, 1].Text);
                xmlField.SetAttribute("PrimaryKey", this.neuSpread1_Sheet1.Cells[i, 2].Value.ToString());
                xmlField.SetAttribute("Filter", this.neuSpread1_Sheet1.Cells[i, 3].Value.ToString());
                xmlField.SetAttribute("Locked", this.neuSpread1_Sheet1.Cells[i, 4].Value.ToString());
                xmlField.SetAttribute("Sort", this.neuSpread1_Sheet1.Cells[i, 5].Value.ToString());
                xmlField.SetAttribute("Visible", this.neuSpread1_Sheet1.Cells[i, 6].Value.ToString());
                xmlField.SetAttribute("CellType", this.neuSpread1_Sheet1.Cells[i, 7].Text);
                xmlField.SetAttribute("Default", this.neuSpread1_Sheet1.Cells[i, 10].Text);
                xmlField.SetAttribute("Length", this.neuSpread1_Sheet1.Cells[i, 11].Text);
                xmlField.SetAttribute("DataType", this.neuSpread1_Sheet1.Cells[i, 9].Text);

                //////////////////////////////////////////////////////////////////////////
                //  取出ComboBoxItems和ComboBoxSQL属性
                //  Robin   2006-11-17
                //////////////////////////////////////////////////////////////////////////                
                XmlNode fieldCombox = this.neuSpread1_Sheet1.Cells[i, 8].Tag as XmlNode;
                if (fieldCombox != null)
                {
                    if (fieldCombox.Attributes["ComboBoxSQL"] != null)
                    {
                        xmlField.SetAttribute("ComboBoxSQL", fieldCombox.Attributes["ComboBoxSQL"].Value);

                        foreach (XmlNode item in fieldCombox.ChildNodes)
                        {
                            xmlField.AppendChild(item.Clone());
                        }

                    }
                }
                //////////////////////////////////////////////////////////////////////////                

                xmlColumns.AppendChild(xmlField);

            }

        }
        private void AnalysisXml()
        {
            XmlElement xmlElement = this.xmlDoc.DocumentElement;
            //设置显示风格
            foreach (XmlAttribute attribute in xmlElement.Attributes)
            {
                if (attribute.Name == "ShowFilter")
                {
                    if (attribute.Value.ToLower() != "true")
                    {
                        this.chkFilter.Checked = true;
                    }
                    else
                        this.chkFilter.Checked = false;

                    continue;
                }

                if (attribute.Name == "ShowTreeView")
                {
                    if (attribute.Value.ToLower() != "true")
                    {

                    }
                }
            }
            //分析SQL语句
            XmlNode xmlSQL = xmlElement.SelectSingleNode("SQL");
            this.txtSQL.Text = xmlSQL.InnerText;
            this.btnTest_Click(null, null);
            XmlAttribute attribute1;
            attribute1 = this.GetXmlAttribute(xmlSQL, "OperatorID");
            if (attribute1 != null)
            {
                this.cboOperator.Text = attribute1.Value;
            }

            attribute1 = this.GetXmlAttribute(xmlSQL, "OperateDate");
            if (attribute1 != null)
            {
                this.cboOperDate.Text = attribute1.Value;
            }
            //分析字段属性
            XmlNodeList xmlColumns = xmlElement.SelectNodes("Columns/Column");
            foreach (XmlNode xmlColumn in xmlColumns)
            {
                XmlAttribute attribute;
                string columnID = xmlColumn.Attributes["ID"].Value.ToLower();
                int rowIndex = this.neuSpread1_Sheet1.Rows[columnID].Index;
                this.neuSpread1_Sheet1.Cells[rowIndex, 1].Text = xmlColumn.Attributes["Name"].Value;

                attribute = this.GetXmlAttribute(xmlColumn, "PrimaryKey");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 2].Value = Convert.ToBoolean(attribute.Value);
                }

                attribute = this.GetXmlAttribute(xmlColumn, "Filter");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 3].Value = Convert.ToBoolean(attribute.Value);
                }

                attribute = this.GetXmlAttribute(xmlColumn, "Locked");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 4].Value = Convert.ToBoolean(attribute.Value);
                }
                attribute = this.GetXmlAttribute(xmlColumn, "Sort");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 5].Value = Convert.ToBoolean(attribute.Value);
                }
                attribute = this.GetXmlAttribute(xmlColumn, "Visible");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 6].Value = Convert.ToBoolean(attribute.Value);
                }

                attribute = this.GetXmlAttribute(xmlColumn, "CellType");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 7].Value = attribute.Value;
                }

                attribute = this.GetXmlAttribute(xmlColumn, "Default");
                if (attribute != null)
                {
                    this.neuSpread1_Sheet1.Cells[rowIndex, 10].Value = attribute.Value;
                }

                //将 xmlColumn设为每行第8个Cell的Tag，用以生成ComboBoxItems
                this.neuSpread1_Sheet1.Cells[rowIndex, 8].Tag = xmlColumn;
            }
            //设置TreeView
            //XmlNode xmlTree = this.xmlElement.SelectSingleNode("TreeView");
            //if (xmlTree != null)
            //{
            //    TreeNode node = new TreeNode();

            //    node.Text = xmlTree.FirstChild.Attributes["Text"].Value;
            //    XmlAttribute attribute2 = this.GetXmlAttribute(xmlTree.FirstChild, "SQL");
            //    if (attribute2 != null)
            //    {
            //        node.Tag = attribute2.Value;
            //    }
            //    this.TreeView.Nodes.Add(node);
            //    this.MakeTree(node, xmlTree.FirstChild);
            //    this.TreeView.ExpandAll();
            //}

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
        #endregion

        #region 事件
        protected override void OnLoad(EventArgs e)
        {
            this.maintenanceForm.ShowAddButton = false;
            this.maintenanceForm.ShowDeleteButton = false;
            this.maintenanceForm.ShowModifyButton = false;
            this.maintenanceForm.ShowImportButton = false;
            this.maintenanceForm.ShowExportButton = false;
            this.maintenanceForm.ShowPrintButton = false;
            this.maintenanceForm.ShowPrintPreviewButton = false;
            this.ParentForm.Text = "单表维护 - " + this.id;
            base.OnLoad(e);
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            if (this.txtSQL.Text.Trim().Length == 0)
                return;

            this.neuSpread1_Sheet1.RowCount = 0;
            this.cboOperator.Items.Clear();
            this.cboOperDate.Items.Clear();
            this.cboOperator.Items.Add("无");
            this.cboOperDate.Items.Add("无");

            if (this.DB.ExecQuery(this.txtSQL.Text) == -1)
            {
                MessageBox.Show("SQL语句有错误，请确认后重试！");
                this.txtSQL.Focus();
                return;
            }
            this.DB.Reader.Read();

            this.neuSpread1_Sheet1.RowCount = DB.Reader.FieldCount;

            for (int i = 0; i < DB.Reader.FieldCount; i++)
            {
                string fieldName = DB.Reader.GetName(i);
                this.neuSpread1_Sheet1.Rows[i].Tag = fieldName.ToLower();
                this.neuSpread1_Sheet1.Cells[i, 0].Text = fieldName;
                this.cboOperator.Items.Add(fieldName);
                this.cboOperDate.Items.Add(fieldName);

                this.neuSpread1_Sheet1.Cells[i, 2].Value = false;
                this.neuSpread1_Sheet1.Cells[i, 3].Value = false;
                this.neuSpread1_Sheet1.Cells[i, 4].Value = false;
                this.neuSpread1_Sheet1.Cells[i, 5].Value = false;
                this.neuSpread1_Sheet1.Cells[i, 6].Value = true;
            }
            //得到字段信息
            string tableName = SqlManager.GetTableName(this.txtSQL.Text);
            Dictionary<string, FieldInfo> fieldInfos = SqlManager.GetFieldInfo(tableName);
            if (fieldInfos.Count == 0)
            {
                MessageBox.Show("此表不存在，请确认后重试！");
                this.txtSQL.Focus();
                return;
            }
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                FieldInfo fieldInfo = fieldInfos[this.neuSpread1_Sheet1.Cells[i, 0].Text];
                this.neuSpread1_Sheet1.Cells[i, 1].Text = fieldInfo.Name;
                this.neuSpread1_Sheet1.Cells[i, 2].Value = fieldInfo.IsPrimaryKey;
                this.neuSpread1_Sheet1.Cells[i, 9].Text = fieldInfo.DataType.ToString();
                this.neuSpread1_Sheet1.Cells[i, 11].Text = fieldInfo.Length.ToString();

            }
            //设置默认字段
            if (this.cboOperator.Items.Contains("OPER_CODE"))
                this.cboOperator.Text = "OPER_CODE";
            else
                this.cboOperator.SelectedIndex = 0;

            if (this.cboOperDate.Items.Contains("OPER_DATE"))
                this.cboOperDate.Text = "OPER_DATE";
            else
                this.cboOperDate.SelectedIndex = 0;

            this.DB.Reader.Dispose();



        }


        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuTabControl1.SelectedIndex == 1)
            {
                this.GenXML();
                this.txtXML.Text = this.xmlDoc.InnerXml;
            }
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 8)
            {
                this.GenXML();
                XmlNode node = this.xmlDoc.SelectSingleNode(string.Format("MaintanceControl/Columns/Column[@ID='{0}']", this.neuSpread1_Sheet1.Cells[e.Row, 0].Text));
                XmlElement field = node as XmlElement;
                frmQuery f = new frmQuery(new ucMaintenanceComboBox(field));
                f.ShowDialog();
                this.neuSpread1_Sheet1.Cells[e.Row, 8].Tag = field;
            }
        }
    }
        #endregion

    public class MaintenanceControlManager : Neusoft.FrameWork.Management.DataBaseManger
    {
        public int InsertData(String id, String data)
        {
            //FrameWork.Management.Transaction trans = new Neusoft.FrameWork.Management.Transaction(FrameWork.Management.Connection.Instance);
            //trans.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            string strSQL = string.Format("delete COM_MAINTENANCE where id='{0}'", id);
            int ret = this.ExecNoQuery(strSQL);
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }
            //插入
            strSQL = "insert into COM_MAINTENANCE (ID,DATA,OPER_CODE) values('{0}','{1}','{2}')";
            ret = this.ExecNoQuery(strSQL, id, data, Neusoft.FrameWork.Management.Connection.Operator.ID);
            if (ret == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            return ret;
        }

        public string LoadData(string id)
        {
            string strSQL = string.Format("select Data from COM_MAINTENANCE where ID='{0}'", id);
            if (this.ExecQuery(strSQL) == -1)
            {
                return null;
            }
            string ret = null;
            if (this.Reader.Read())
                ret = this.Reader[0].ToString();

            this.Reader.Dispose();

            return ret;
        }
    };
}


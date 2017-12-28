using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.WinForms.Forms;
using System.Xml;

namespace Neusoft.FrameWork.WinForms.Controls
{
    public partial class ucMaintenanceComboBox : UserControl, IMaintenanceControlable
    {
        public ucMaintenanceComboBox()
        {
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.SetFarPointStyle(neuSpread1_Sheet1);
            this.InitSpread();
        }

        public ucMaintenanceComboBox(XmlElement xmlColumn)
            : this()
        {
            this.xmlColumn = xmlColumn;
            this.AnalysisXML();
        }

#region 字段
        private bool isDirty;
        IMaintenanceForm maintenanceForm;
        private XmlElement xmlColumn;
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
            if (this.Tag == null && this.xmlColumn == null)
            {
                MessageBox.Show("未设置Tag!");
                return -1;
            }
            else if (this.Tag != null)
            {
                this.xmlColumn = this.Tag as XmlElement;
                this.AnalysisXML();
            }

            return 0;
        }

        public int Query()
        {
            return 0;
        }

        public int Add()
        {
            this.neuSpread1_Sheet1.RowCount += 1;
            return 0;
        }

        public int Delete()
        {
            this.neuSpread1.StopCellEditing();
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);
            
            return 0;
        }

        public int Modify()
        {
            return 0;
        }

        public int Save()
        {
            this.xmlColumn.SetAttribute("ComboBoxSQL", this.txtSQL.Text);
            for (int i = xmlColumn.ChildNodes.Count - 1; i >= 0;i-- )
            {
                this.xmlColumn.RemoveChild(xmlColumn.ChildNodes[i]);
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; ++i)
            {
                XmlElement item = this.xmlColumn.OwnerDocument.CreateElement("ComboBoxItem");
                item.SetAttribute("ID", this.neuSpread1_Sheet1.Cells[i, 0].Text);
                item.SetAttribute("Value", this.neuSpread1_Sheet1.Cells[i, 1].Text);
                
                this.xmlColumn.AppendChild(item);
            }
                return 0;
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
            this.neuSpread1_Sheet1.ColumnCount = 2;
            this.neuSpread1_Sheet1.Columns[0].Label = "编码";
            this.neuSpread1_Sheet1.Columns[1].Label = "名称";

            this.neuSpread1_Sheet1.RowCount = 0;

            this.neuSpread1_Sheet1.Columns[0].Width = 100;
            this.neuSpread1_Sheet1.Columns[1].Width = 150;
        }

        private void AnalysisXML()
        {
            XmlAttribute attribute = XmlUtil.GetXmlAttribute(this.xmlColumn, "ComboBoxSQL");
            if(attribute!=null)
            {
                this.txtSQL.Text = attribute.Value;
            }

            this.neuSpread1_Sheet1.RowCount = 0;
            
            XmlNodeList items = this.xmlColumn.SelectNodes("ComboBoxItem");
            
            foreach(XmlNode item in items)
            {
                this.neuSpread1_Sheet1.RowCount += 1;
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 0].Text = item.Attributes["ID"].Value;
                this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 1].Text = item.Attributes["Value"].Value;
            }
        }
#endregion
        #region 事件

        protected override void OnLoad(EventArgs e)
        {
            this.maintenanceForm.IsFormMaximized = false;
            this.maintenanceForm.ShowStatusBar = false;
            this.maintenanceForm.ShowImportButton = false;
            this.maintenanceForm.ShowExportButton = false;
            this.maintenanceForm.ShowPrintButton = false;
            this.maintenanceForm.ShowPrintPreviewButton = false;
            this.rdoItems.Checked = true;

            base.OnLoad(e);
        }
        private void rdoSQL_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.rdoSQL.Checked)
            {
                this.txtSQL.Enabled = true;
                this.neuSpread1.Enabled = false;
            }
            else
            {
                this.txtSQL.Enabled = false;
                this.neuSpread1.Enabled = true;
            }
        }
        #endregion
    }
}

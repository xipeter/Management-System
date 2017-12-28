using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Material.Report
{
    public partial class frmSetConfig : Form
    {
        public frmSetConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Spl配置段文件
        /// </summary>
        private System.Xml.XmlDocument sqlConfigDoc = null;

        /// <summary>
        /// Sql配置文件路径
        /// </summary>
        private string sqlConfigPath = "Report_Sql.xml";

        /// <summary>
        /// Fp格式配置段文件
        /// </summary>
        private System.Xml.XmlDocument fpPathDoc = null;

        /// <summary>
        /// 已保存过的Fp格式集合
        /// </summary>
        private System.Collections.Hashtable hsFpPathCollection = new System.Collections.Hashtable();

        private bool SqlConfigValid()
        {
            if (this.txtReportID.Text == "")
            {
                MessageBox.Show("请设置报表ID");
                return false;
            }
            if (this.txtSqlIndex.Text == "")
            {
                MessageBox.Show("请设置Sql索引");
                return false;
            }
            if (this.ckSqlXml.Checked && this.txtSql.Text == "")
            {
                MessageBox.Show("设置Sql语句位于Xml配置文件内时 必须设置Sql");
                return false;
            }
            if (this.txtFpPathName.Text == "")
            {
                DialogResult rs = MessageBox.Show("当前Fp配置文件为空 确认不设置相关联配置文件吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 设置Sql配置
        /// </summary>
        private void SaveSqlConfig()
        {
            if (!this.SqlConfigValid())
            {
                return;
            }

            System.Xml.XmlElement rootNode = null;
            if (this.sqlConfigDoc == null)
            {
                this.sqlConfigDoc = new System.Xml.XmlDocument();

                if (System.IO.File.Exists(Application.StartupPath + "\\" + this.sqlConfigPath))
                {
                    this.sqlConfigDoc.Load(Application.StartupPath + "\\" + this.sqlConfigPath);

                    rootNode = (System.Xml.XmlElement)this.sqlConfigDoc.SelectSingleNode("/Setting");
                    if (rootNode == null)
                    {
                        return;
                    }
                }
                else
                {
                    System.Xml.XmlNode declareNode = this.sqlConfigDoc.CreateNode(System.Xml.XmlNodeType.XmlDeclaration, "", "");
                    this.sqlConfigDoc.AppendChild(declareNode);

                    rootNode = this.sqlConfigDoc.CreateElement("Setting");
                    this.sqlConfigDoc.AppendChild(rootNode);
                }
            }
            else
            {
                rootNode = (System.Xml.XmlElement)this.sqlConfigDoc.SelectSingleNode("/Setting");
                if (rootNode == null)
                {
                    return;
                }
            }

            System.Xml.XmlElement reportXml = this.sqlConfigDoc.CreateElement("Report");
            reportXml.SetAttribute("ID", this.txtReportID.Text);
            reportXml.SetAttribute("sqlLocation", Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSqlXml.Checked).ToString());

            System.Xml.XmlElement sqlXml = this.sqlConfigDoc.CreateElement("Sql");
            sqlXml.SetAttribute("index", this.txtSqlIndex.Text);
            System.Xml.XmlNode sqlNode = this.sqlConfigDoc.CreateNode(System.Xml.XmlNodeType.CDATA, "Sql", "");
            sqlNode.InnerText = this.txtSql.Text;
            sqlXml.AppendChild(sqlNode);

            System.Xml.XmlElement fpXml = this.sqlConfigDoc.CreateElement("FormatPathName");
            fpXml.SetAttribute("fileName", this.txtFpPathName.Text);

            reportXml.AppendChild(sqlXml);
            reportXml.AppendChild(fpXml);

            rootNode.AppendChild(reportXml);

            this.sqlConfigDoc.Save(Application.StartupPath + "\\" + this.sqlConfigPath);

            MessageBox.Show("录入成功");

            if (this.ckContinue.Checked)
            {
                this.sqlConfigDoc.Load(Application.StartupPath + "\\" + this.sqlConfigPath);
            }
            else
            {
                this.sqlConfigDoc = null;
            }
        }

        /// <summary>
        /// 设置Fp配置
        /// </summary>
        private void SaveFpPath()
        {
            System.Xml.XmlElement rootNode = null;

            this.fpPathDoc = new System.Xml.XmlDocument();

            if (System.IO.File.Exists(Application.StartupPath + "\\" + this.txtPath.Text))
            {
                DialogResult rs = MessageBox.Show("该配置文件已存在 是否继续? 继续将再当前配置文件内追加", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }

                this.fpPathDoc.Load(Application.StartupPath + "\\" + this.txtPath.Text);

                rootNode = (System.Xml.XmlElement)this.fpPathDoc.SelectSingleNode("/Setting");
                if (rootNode == null)
                {
                    return;
                }
            }
            else
            {
                System.Xml.XmlNode declareNode = this.fpPathDoc.CreateNode(System.Xml.XmlNodeType.XmlDeclaration, "", "");
                this.fpPathDoc.AppendChild(declareNode);

                rootNode = this.fpPathDoc.CreateElement("Setting");
                this.fpPathDoc.AppendChild(rootNode);
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "")
                {
                    break;
                }

                System.Xml.XmlElement columnXml = this.fpPathDoc.CreateElement("Column");

                columnXml.SetAttribute("Label", this.neuSpread1_Sheet1.Cells[i, 0].Text);
                columnXml.SetAttribute("Visible", this.neuSpread1_Sheet1.Cells[i, 1].Text);
                if (this.neuSpread1_Sheet1.Cells[i, 2].Text == "")
                    columnXml.SetAttribute("Width", "80");
                else
                    columnXml.SetAttribute("Width", this.neuSpread1_Sheet1.Cells[i, 2].Text);
                if (this.neuSpread1_Sheet1.Cells[i, 3].Text == "")
                    columnXml.SetAttribute("CellType", "文本");
                else
                    columnXml.SetAttribute("CellType", this.neuSpread1_Sheet1.Cells[i, 3].Text);
                columnXml.SetAttribute("Param", this.neuSpread1_Sheet1.Cells[i, 4].Text);

                rootNode.AppendChild(columnXml);
            }

            this.fpPathDoc.Save(Application.StartupPath + "\\" + this.txtPath.Text);

            MessageBox.Show("录入成功");

            this.fpPathDoc = null;
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void Save()
        {
            if (this.neuTabControl1.SelectedTab == this.tpConfig)
            {
                this.SaveSqlConfig();
            }
            else
            {
                this.SaveFpPath();
            }
        }

        /// <summary>
        /// 根据配置文件设置Fp显示
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="doc"></param>
        public static void SetFpByConfig(FarPoint.Win.Spread.SheetView sv, System.Xml.XmlDocument doc)
        {
            System.Xml.XmlNode nodeCollection = doc.SelectSingleNode("/Setting");

            for (int i = 0; i < nodeCollection.ChildNodes.Count; i++)
            {
                if (sv.Columns.Count <= i)
                {
                    return;
                }
                System.Xml.XmlNode node = nodeCollection.ChildNodes[i];
                sv.Columns[i].Label = node.Attributes["Label"].Value;
                sv.Columns[i].Visible = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["Visible"].Value);
                sv.Columns[i].Width = (float)Neusoft.FrameWork.Function.NConvert.ToInt32(node.Attributes["Width"].Value);
                switch (node.Attributes["CellType"].Value)
                {
                    case "文本":
                        sv.Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                        break;
                    case "数值":
                        FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();
                        if (node.Attributes["Param"].Value != "")
                        {
                            num.DecimalPlaces = Neusoft.FrameWork.Function.NConvert.ToInt32(node.Attributes["Param"].Value);
                        }
                        sv.Columns[i].CellType = num;
                        break;
                    case "日期":
                        FarPoint.Win.Spread.CellType.DateTimeCellType timeCell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                        sv.Columns[i].CellType = timeCell;
                        break;
                    default:
                        sv.Columns[i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                        break;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtReportID.Text = "";
            this.txtPath.Text = "";
            this.txtFpPathName.Text = "";
            this.txtSql.Text = "";
            this.txtSqlIndex.Text = "";

            this.neuSpread1_Sheet1.Rows.Count = 0;
            this.neuSpread1_Sheet1.Rows.Count = 50;
        }
    }
}
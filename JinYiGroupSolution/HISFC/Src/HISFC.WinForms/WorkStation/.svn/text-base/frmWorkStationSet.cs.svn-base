using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    /// <summary>
    /// 界面配置窗口
    /// </summary>
    internal partial class frmWorkStationSet : Form
    {
        public frmWorkStationSet()
        {
            this.InitializeComponent();
        }

        private void frmWorkStationSet_Load(object sender, EventArgs e)
        {
            string xml = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSetting("0");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch { return ; }

            try
            {
                this.richTextBox1.Text = doc.SelectSingleNode("//LEFT").OuterXml;
            }
            catch { }

            this.richTextBox2.Text = doc.SelectSingleNode("//RIGHT").OuterXml;

            this.initFP();

            this.setRight(doc.SelectNodes("//RIGHT/PAD"));

        }

        /// <summary>
        /// xml
        /// </summary>
        public string xml
        {
            get
            {
                string left = this.richTextBox1.Text;

                this.richTextBox2.Text = this.getRight();

                string right = this.richTextBox2.Text;

                string strXML = "<?xml version=\"1.0\" encoding =\"GB2312\"?> \n <SETTING>" + left + right + "</SETTING>";

                return strXML;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlRight"></param>
        private void setRight(System.Xml.XmlNodeList nodes)
        {
            for(int i=0;i<nodes.Count;i++)
            {
                for (int j = 0; j < nodes[i].Attributes.Count; j++)
                    this.fpSpread1_Sheet1.Cells[i, j].Text = nodes[i].Attributes[j].Value;
                this.fpSpread1_Sheet1.Cells[i, 7].Text = nodes[i].InnerXml;
             }
        }

        /// <summary>
        /// 获得右信息
        /// </summary>
        /// <returns></returns>
        private string getRight()
        {
            string xmlnode = " {0}=\"{1}\" ";
            string xmlRight = "";
            for (int i = 0; i < this.fpSpread1_Sheet1.RowCount; i++)
            {
                if (this.fpSpread1_Sheet1.Cells[i, 1].Text.Trim() != "")
                {
                    string xmlRow = "<PAD ";
                    for (int j = 0; j < this.fpSpread1_Sheet1.Columns.Count - 2; j++)
                    {
                        xmlRow = xmlRow + string.Format(xmlnode, this.fpSpread1_Sheet1.Columns[j].Label, this.fpSpread1_Sheet1.Cells[i, j].Text);
                    }
                    xmlRow = xmlRow + ">\n";
                    xmlRow = xmlRow + this.fpSpread1_Sheet1.Cells[i,7].Text;
                    xmlRow = xmlRow + "</PAD>\n";
                    xmlRight = xmlRight + xmlRow;
                }
            }
            return "<RIGHT>" + xmlRight + "</RIGHT>";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "0";
            obj.Name ="医生工作站";
            Neusoft.HISFC.BizProcess.Factory.Function.BeginTransaction();
            Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.SaveSetting( obj, this.xml );
            Neusoft.HISFC.BizProcess.Factory.Function.Commit();
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog form = new ColorDialog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.fpSpread1_Sheet1.ActiveCell.Text = form.Color.ToArgb().ToString();
            }
        }

        private void initFP()
        {
            
             //<PAD NAME="科室患者" PARENT="MAINTOP"  DLLNAME="WorkStation" CONTROLNAME="WorkStation.Controls.ucPatientList" ISALLOWMOVE="false" TITLECOLOR="" BACKCOLOR="">
             //    <PROPERTY ID ="name">value</PROPERTY>
              //</PAD>

  
            this.fpSpread1_Sheet1.ColumnCount = 9;
            this.fpSpread1_Sheet1.RowCount = 4;
            FarPoint.Win.Spread.CellType.ComboBoxCellType combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType button = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.RichTextCellType rich = new FarPoint.Win.Spread.CellType.RichTextCellType();
            rich.Multiline = true;
            String[] ss = new String[7];
            ss[0] = "MAIN";
            ss[1] = "MAINTOP";
            ss[2] = "MAINTOP.LEFT";
            ss[3] = "MAINTOP.RIGHT";
            ss[4] = "MAINBOTTOM";
            ss[5] = "MAINBOTTOM.LEFT";
            ss[6] = "MAINBOTTOM.RIGHT";
            combo.Items = ss;
            this.fpSpread1_Sheet1.Rows.Default.Height = 150;
            this.fpSpread1_Sheet1.Columns[1].CellType = combo;
            this.fpSpread1_Sheet1.Columns[0].Label = "NAME";
            this.fpSpread1_Sheet1.Columns[0].Width = 80;
            this.fpSpread1_Sheet1.Columns[1].Label = "PARENT";
            this.fpSpread1_Sheet1.Columns[1].Width = 80;
            this.fpSpread1_Sheet1.Columns[2].Label = "DLLNAME";
            this.fpSpread1_Sheet1.Columns[2].Width = 80;
            this.fpSpread1_Sheet1.Columns[3].Label = "CONTROLNAME";
            this.fpSpread1_Sheet1.Columns[3].Width = 150;
            this.fpSpread1_Sheet1.Columns[4].Label = "ISALLOWMOVE";
            this.fpSpread1_Sheet1.Columns[5].Label = "TITLECOLOR";
            this.fpSpread1_Sheet1.Columns[5].Width = 80;
            this.fpSpread1_Sheet1.Columns[6].Label = "BACKCOLOR";
            this.fpSpread1_Sheet1.Columns[6].Width = 80;
            this.fpSpread1_Sheet1.Columns[7].Label = "PROPERTY"; //属性
            this.fpSpread1_Sheet1.Columns[7].CellType = rich;
            this.fpSpread1_Sheet1.Columns[7].Width = 200;
            this.fpSpread1_Sheet1.Columns[8].Label = "属性"; //属性
            this.fpSpread1_Sheet1.Columns[8].CellType = button;


        }

        private void fpSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
                string dllName = this.fpSpread1_Sheet1.Cells[e.Row, 2].Text;
                string controlName = this.fpSpread1_Sheet1.Cells[e.Row, 3].Text;
                if (dllName == "" || controlName == "") return;
                Control c = Neusoft.FrameWork.WinForms.Classes.Function.CreateControl(dllName, controlName);
                if (c == null) return;
                PropertyGrid property = new PropertyGrid();
                property.SelectedObject = c;
                property.Size = new Size(200, 400);
                property.PropertyValueChanged += new PropertyValueChangedEventHandler(property_PropertyValueChanged);
                this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 7].Text = "";
                Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(property);

        }

        void property_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string xmlproperty = "<PROPERTY ID = \"{0}\">{1}</PROPERTY>\n";

            xmlproperty = String.Format(xmlproperty, e.ChangedItem.Label, e.ChangedItem.Value.ToString());
            this.fpSpread1_Sheet1.Cells[this.fpSpread1_Sheet1.ActiveRowIndex, 7].Text += xmlproperty;

        }


        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (e.Column == 2)
            {
                string dllname = this.fpSpread1_Sheet1.Cells[e.Row, 2].Text;
                if (dllname == "") return;
                try
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(dllname + ".dll");
                    Type[] type = assembly.GetTypes();
                    FarPoint.Win.Spread.CellType.ComboBoxCellType funCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    string[] ss = new string[type.Length + 1];

                    int i = 0;
                    foreach (Type mytype in type)
                    {
                        if (mytype.IsPublic && mytype.IsClass)
                        {
                            ss[i] = mytype.ToString();
                            i++;
                        }
                    }
                    ss[i] = "";
                    funCellType.Editable = true;
                    funCellType.Items = ss;
                    this.fpSpread1_Sheet1.Cells[e.Row, 3].CellType = funCellType;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.richTextBox2.Text = this.getRight();
        }
    }
}

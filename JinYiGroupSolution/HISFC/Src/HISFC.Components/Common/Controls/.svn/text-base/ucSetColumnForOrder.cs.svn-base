using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Neusoft.FrameWork;

namespace Neusoft.HISFC.Components.Common.Controls
{
    /// <summary>
    /// [功能描述: Fp列设置类]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// <说明
    ///		 通过传入的Fp 显示Fp的列信息 并可维护是否显示/排序等信息
    ///  />
    /// </summary>
    public partial class ucSetColumnForOrder : UserControl
    {
        public ucSetColumnForOrder()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                this.InitDataTable();
                this.InitXmlDoc();
                this.ReadXmlSetData();

                //屏蔽上下移动功能 
                this.btnUp.Visible = false;
                this.btnDown.Visible = false;
            }
        }

        public event System.EventHandler DisplayEvent;

        #region 域变量

        /// <summary>
        /// 列配置文件存储路径
        /// </summary>
        public string FilePath = "PharmacyCol.xml";

        /// <summary>
        /// Xml文档
        /// </summary>
        private System.Xml.XmlDocument doc = null;

        /// <summary>
        /// DataTable初始化
        /// </summary>
        private System.Data.DataTable dt = null;

        #endregion

        /// <summary>
        /// 初始化DataSet
        /// </summary>
        private void InitDataTable()
        {
            dt = new DataTable("Setup");

            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtBool = System.Type.GetType("System.Boolean");


            dt.Columns.AddRange(new DataColumn[]{ new DataColumn("列名",dtStr), 
													 new DataColumn("显示",dtBool),                                                   
													 new DataColumn("排序",dtBool),
													 new DataColumn("打印",dtBool),
                                                     new DataColumn("维护",dtBool),
                                                     new DataColumn("宽度",dtStr),
                                                    });

            this.neuSpread1_Sheet1.DataSource = dt;

            this.neuSpread1_Sheet1.Columns[0].Locked = true;
        }

        /// <summary>
        /// 初始化Xml文档
        /// </summary>
        private void InitXmlDoc()
        {
            try
            {
                this.doc = new XmlDocument();
                if (System.IO.File.Exists(this.FilePath))
                    this.doc.Load(this.FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载Xml文档发生错误" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 根据传入的信息设置DataTable 如果配置文件存在 则由配置文件内获取信息 否则 由传入的SheetView自动生成
        /// </summary>
        /// <param name="savePath">配置文件保存路径</param>
        /// <param name="sv">需配置的SheetView</param>
        public void SetDataTable(string savePath, FarPoint.Win.Spread.SheetView sv)
        {
            this.FilePath = savePath;

            if (System.IO.File.Exists(savePath))
            {
                if (this.ReadXmlSetData() == -1)
                    this.SetDataTable(sv);
            }
            else
            {
                this.SetDataTable(sv);
            }
        }

        /// <summary>
        /// 根据传入的信息设置DataTable 由传入的SheetView自动生成
        /// </summary>
        /// <param name="sv">需配置的SheetView</param>
        public void SetDataTable(FarPoint.Win.Spread.SheetView sv)
        {
            this.dt.Rows.Clear();
            for (int i = 0; i < sv.Columns.Count; i++)
            {
                this.dt.Rows.Add(new Object[]{sv.Columns[i].Label,
											  sv.Columns[i].Visible,
											 sv.Columns[i].AllowAutoSort,
											 true,
                                             false,
                                             sv.Columns[i].Width});
            }
        }


        /// <summary>
        /// 根据传入的信息设置DataTable 由传入的SheetView的指定行自动生成
        /// </summary>
        /// <param name="sv">需配置的SheetView</param>
        public void SetDataTable(FarPoint.Win.Spread.SheetView sv, params int[] iIndexCollection)
        {
            this.dt.Rows.Clear();
            for (int i = 0; i < iIndexCollection.Length; i++)
            {
                this.dt.Rows.Add(new Object[]{sv.Columns[iIndexCollection[i]].Label,
											  sv.Columns[iIndexCollection[i]].Visible,
											 sv.Columns[iIndexCollection[i]].AllowAutoSort,
											 true,
                                             false,
                                            sv.Columns[iIndexCollection[i]].Width});

            }
        }

        /// <summary>
        /// 设置列显示
        /// </summary>
        /// <param name="displayVisible">'显示' 设置列是否有效</param>
        /// <param name="sortVisible">'排序' 设置列是否有效</param>
        /// <param name="printVisible">'打印'设置列是否有效</param>
        /// <param name="setVisible">'维护'设置列是否有效</param>
        public void SetColVisible(bool displayVisible, bool sortVisible, bool printVisible, bool setVisible)
        {
            this.neuSpread1_Sheet1.Columns[1].Visible = displayVisible;
            this.neuSpread1_Sheet1.Columns[2].Visible = sortVisible;
            this.neuSpread1_Sheet1.Columns[3].Visible = printVisible;
            this.neuSpread1_Sheet1.Columns[4].Visible = setVisible;
        }

        /// <summary>
        /// 获取当前指定列内选中的行
        /// </summary>
        /// <param name="checkCol">需检索的选中列</param>
        /// <returns>列显示名称数组</returns>
        public List<string> GetCheckCol(CheckCol checkCol)
        {
            List<string> strDisplay = new List<string>();
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, (int)checkCol].Text == "True")
                {
                    strDisplay.Add(this.neuSpread1_Sheet1.Cells[i, 0].Text);
                }
            }

            return strDisplay;
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sheetView"></param>
        public static void ReadXml(string fileName, FarPoint.Win.Spread.SheetView sheetView)
        {
            if (System.IO.File.Exists(fileName))
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                try
                {
                    doc.Load(fileName);
                }
                catch { return; }
                XmlNodeList nodes = doc.SelectNodes("//Column");
                if (nodes == null)
                {
                    MessageBox.Show("Xml文档格式不符合规范 请重新建立");
                    return;
                }
                for (int i = 0; i < sheetView.Columns.Count; i++)
                {
                    foreach (XmlNode node in nodes)
                    {
                        if (sheetView.Columns[i].Label == node.Attributes["displayname"].Value)
                        {
                            try
                            {
                                sheetView.Columns[i].Visible = bool.Parse(node.Attributes["visible"].Value);
                                sheetView.Columns[i].AllowAutoSort = bool.Parse(node.Attributes["sort"].Value);
                                sheetView.Columns[i].Width = float.Parse(node.Attributes["width"].Value);
                            }
                            catch { }
                        }
                    }

                }
            }

        }
        /// <summary>
        /// 根据Xml设置DataSet显示
        /// </summary>
        private int ReadXmlSetData()
        {
            if (System.IO.File.Exists(this.FilePath))
            {
                if (!this.doc.HasChildNodes)
                    this.InitXmlDoc();
                XmlNodeList nodes = doc.SelectNodes("//Column");
                if (nodes == null)
                {
                    MessageBox.Show("Xml文档格式不符合规范 请重新建立");
                    return -1;
                }
                this.dt.Rows.Clear();
                try
                {
                    foreach (XmlNode node in nodes)
                    {
                        this.dt.Rows.Add(new Object[]{ node.Attributes["displayname"].Value,
											 bool.Parse( node.Attributes["visible"].Value ),
											 bool.Parse( node.Attributes["sort"].Value ),
											 bool.Parse(node.Attributes["enable"].Value),
                                             false,
                                             node.Attributes["width"].Value});
                    }
                }
                catch { return -1; }
            }
            return 0;
        }

        /// <summary>
        /// 保存Xml文档并重新读取
        /// </summary>
        private void SaveAndReLoad()
        {

            {
                string xml = "";
                //xml += "<?xml version=\"1.0\" encoding=\"GB2312\"?>";
                xml = xml + @"<Setting>";
                for (int i = 0; i < this.neuSpread1.ActiveSheet.RowCount; i++)
                {
                    xml = xml + string.Format(@"<Column displayname=""{0}"" visible=""{1}"" sort=""{2}"" enable=""{3}""  width=""{4}""/>",
                        this.neuSpread1.ActiveSheet.Cells[i, 0].Text,
                        this.neuSpread1.ActiveSheet.Cells[i, 1].Text,
                        this.neuSpread1.ActiveSheet.Cells[i, 2].Text,
                        this.neuSpread1.ActiveSheet.Cells[i, 3].Text,
                        this.neuSpread1.ActiveSheet.Cells[i, 5].Text);
                }
                xml = xml + @"</Setting>";
                try
                {
                    doc.LoadXml(xml);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            }

            this.doc.Save(this.FilePath);
            this.dt.Rows.Clear();
            this.ReadXmlSetData();
        }

        /// <summary>
        /// 获取当前行对应的Xml节点
        /// </summary>
        /// <returns></returns>
        private XmlNode GetNowXmlNode()
        {
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;
            if (i < 0)
                return null;

            string colName = this.neuSpread1_Sheet1.Cells[i, 0].Text.Trim();
            string xPath = "Setting/Column[@displayname='" + colName + "']";

            XmlNode nowNode = this.doc.SelectSingleNode(xPath);

            return nowNode;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;

            if (i == 0)
            {
                return;
            }
            else
            {
                XmlNode nowNode = this.GetNowXmlNode();
                if (nowNode == null)
                    return;

                XmlNode preNode = nowNode.PreviousSibling;
                nowNode.ParentNode.InsertBefore(nowNode, preNode);



                i--;
                this.neuSpread1_Sheet1.ActiveRowIndex = i;
                this.neuSpread1_Sheet1.AddSelection(i, 0, 1, 3);
                this.neuSpread1.SetViewportTopRow(0, i - 15);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i = this.neuSpread1_Sheet1.ActiveRowIndex;

            if (i == this.neuSpread1_Sheet1.RowCount)
            {
                return;
            }
            else
            {
                XmlNode nowNode = this.GetNowXmlNode();
                if (nowNode == null)
                    return;
                XmlNode nextNode = nowNode.NextSibling;

                nowNode.ParentNode.InsertAfter(nowNode, nextNode);


                i++;
                this.neuSpread1_Sheet1.ActiveRowIndex = i;
                this.neuSpread1_Sheet1.AddSelection(i, 0, 1, 3);
                this.neuSpread1.SetViewportTopRow(0, i - 15);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveAndReLoad();
            if (this.DisplayEvent != null)
                this.DisplayEvent(sender, e);
            this.FindForm().DialogResult = DialogResult.OK;
            this.FindForm().Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string xmlField = "";
            switch (e.Column)
            {
                case 1:
                    xmlField = "visible";
                    break;
                case 2:
                    xmlField = "sort";
                    break;
                case 3:
                    xmlField = "enable";
                    break;
            }
            if (xmlField != "")
            {
                XmlNode myNode = this.GetNowXmlNode();
                if (myNode != null && this.doc != null)
                {
                    myNode.Attributes[xmlField].Value = this.neuSpread1_Sheet1.Cells[e.Row, e.Column].Text;
                    this.doc.Save(this.FilePath);
                }
            }
        }
    }

   
}

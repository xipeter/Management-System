using System;
using System.Xml;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace Neusoft.FrameWork.WinForms.Classes
{
	/// <summary>
	/// CustomerFp 的摘要说明。
	/// 通过配置文件调整用户farpoint配置信息
	/// </summary>
    public class CustomerFp
    {
        public CustomerFp()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        private string strFileName;
        /// <summary>
        /// 配置文件名
        /// </summary>
        public string FileName
        {
            get
            {
                return this.strFileName;
            }
            set
            {
                this.strFileName = value;
            }
        }
        public void ReadColumnProperty(FarPoint.Win.Spread.SheetView fv)
        {
            ReadColumnProperty(fv, this.strFileName);
        }

        /// <summary>
        /// 根据保存的XML信息,生成列信息
        /// </summary>
        /// <param name="pathName">XML文件存储位置</param>
        /// <param name="table">要初始化的DataTable</param>
        /// <param name="dv">DataTable的DataView</param>
        /// <param name="sv">绑定DataView的FarPointSheet</param>
        public static void CreatColumnByXML(string pathName, DataTable table, ref DataView dv, FarPoint.Win.Spread.SheetView sv)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                StreamReader sr = new StreamReader(pathName, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close(); 
            }
            catch
            {
                return;
            }

            XmlNodeList nodes = doc.SelectNodes("//Column");

            string tempString = "";

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["type"].Value == "TextCellType")
                {
                    tempString = "System.String";
                }
                else if (node.Attributes["type"].Value == "CheckBoxCellType")
                {
                    tempString = "System.Boolean";
                }
                else if (node.Attributes["type"].Value == "NumberCellType")
                {
                    tempString = "System.Decimal";
                }
                else if (node.Attributes["type"].Value == "DateTimeCellType")
                {
                    tempString = "System.DateTime";
                }
                else
                {
                    tempString = "System.String";
                }

                table.Columns.Add(new DataColumn(node.Attributes["displayname"].Value, Type.GetType(tempString)));
            }

            dv = new DataView(table);

            sv.DataSource = dv;
        }

        /// <summary>
        /// 设置列属性
        /// </summary>
        public static void ReadColumnProperty(FarPoint.Win.Spread.SheetView fv, string FileName)
        {
            XmlDocument doc = new XmlDocument();
            if (FileName == "") return;
            try
            {
                StreamReader sr = new StreamReader(FileName, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
                //				doc.LoadXml(FileName);
            }
            catch { return; }
            XmlNodeList nodes = doc.SelectNodes("//Column");
            int id = 0;
            fv.Columns.Count = nodes.Count;
            foreach (XmlNode node in nodes)
            {

                try
                {
                    int width = int.Parse(node.Attributes["width"].Value);
                    fv.Columns[id].Width = width;
                }
                catch { }
                try
                {
                    bool visible = bool.Parse(node.Attributes["visible"].Value);
                    fv.Columns[id].Visible = visible;
                }
                catch { }
                try
                {
                    bool enable = bool.Parse(node.Attributes["enable"].Value);
                    fv.Columns[id].Locked = !enable;
                }
                catch { }
                try
                {
                    string name = node.Attributes["name"].Value;
                    fv.Columns[id].Label = name;
                }
                catch { }
                try
                {
                    string displayname = node.Attributes["displayname"].Value;
                    if (displayname != "") fv.Columns[id].Label = displayname;
                }
                catch { }

                try
                {
                    string type = node.Attributes["type"].Value;
                    if (type == "TextCellType")//FarPoint.Win.Spread.CellType.
                    {
                        fv.Columns[id].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                    }
                    else if (type == "ComboBoxCellType")
                    {
                        fv.Columns[id].CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    }
                    else if (type == "CurrencyCellType")
                    {
                        fv.Columns[id].CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                    }
                    else if (type == "CheckBoxCellType")
                    {
                        fv.Columns[id].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    }
                    else if (type == "DateTimeCellType")
                    {
                        FarPoint.Win.Spread.CellType.DateTimeCellType dtCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                        dtCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;
                        fv.Columns[id].CellType = dtCellType;
                    }
                    else if (type == "ButtonCellType")
                    {
                        fv.Columns[id].CellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    }
                }
                catch { }

                try
                {
                    bool sort = bool.Parse(node.Attributes["sort"].Value);
                    fv.Columns[id].AllowAutoSort = sort;
                }
                catch { }
                id++;
            }
        }
        public static void SaveColumnProperty(FarPoint.Win.Spread.SheetView fv, string FileName)
        {
            string path;
            try
            {
                path = FileName.Substring(0, FileName.LastIndexOf(@"\"));
                if (System.IO.Directory.Exists(path) == false)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch { }

            Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            root = myXml.CreateRootElement(doc, "Setting", "1.0");
            for (int i = 0; i < fv.Columns.Count; i++)
            {
                XmlElement e = myXml.AddXmlNode(doc, root, "Column", "");
                myXml.AddNodeAttibute(e, "displayname", fv.Columns[i].Label);
                myXml.AddNodeAttibute(e, "width", fv.Columns[i].Width.ToString());
                myXml.AddNodeAttibute(e, "visible", fv.Columns[i].Visible.ToString());

                if (fv.Columns[i].Locked)
                {
                    myXml.AddNodeAttibute(e, "enable", "false");
                }
                else
                {
                    myXml.AddNodeAttibute(e, "enable", "true");
                }
                if (fv.Columns[i].CellType != null)
                    myXml.AddNodeAttibute(e, "type", fv.Columns[i].CellType.ToString());
                else
                    myXml.AddNodeAttibute(e, "type", "");
                myXml.AddNodeAttibute(e, "sort", fv.Columns[i].AllowAutoSort.ToString());
                try
                {
                    myXml.AddNodeAttibute(e, "tag", fv.Columns[i].Tag.ToString());
                }
                catch { }
            }
            try
            {
                StreamWriter sr = new StreamWriter(FileName, false, System.Text.Encoding.Default);
                string cleandown = doc.OuterXml;
                sr.Write(cleandown);
                sr.Close();
                //doc.Save(FileName);
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show("无法保存！" + ex.Message); }
        }
        public void SaveColumnProperty(FarPoint.Win.Spread.SheetView fv)
        {
            SaveColumnProperty(fv, this.strFileName);
        }

        /// <summary>
        /// 读取列格式化信息 不包括单元格属性信息
        /// </summary>
        /// <param name="fv">需设置的FarPoint</param>
        /// <param name="fileName">配置文件名称</param>
        public static void ReadColumnFormatProperty(FarPoint.Win.Spread.SheetView fv, string fileName)
        {
            if (fileName == "")
            {
                return;
            }

            XmlDocument doc = new XmlDocument();            
            try
            {
                StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("无法读取列配置文件！" + ex.Message); 
                return;
            }
            XmlNodeList nodes = doc.SelectNodes("//Column");

            //取配置文件和fv中列数目最少的
            int minColumnCount = fv.Columns.Count > nodes.Count ? nodes.Count : fv.Columns.Count;
            int columnIndex = 0;
            foreach (XmlNode node in nodes)
            {
                if (columnIndex > minColumnCount - 1)
                {
                    break;
                }

                if (node.Attributes["width"].Value != null)
                {
                    int width = Neusoft.FrameWork.Function.NConvert.ToInt32(node.Attributes["width"].Value);
                    fv.Columns[columnIndex].Width = width;
                }

                if (node.Attributes["visible"].Value != null)
                {
                    bool visible = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["visible"].Value);
                    fv.Columns[columnIndex].Visible = visible;
                }

                if (node.Attributes["enable"].Value != null)
                {
                    bool enable = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["enable"].Value);
                    fv.Columns[columnIndex].Locked = !enable;
                }

                if (node.Attributes["displayname"].Value != null)
                {
                    string displayname = node.Attributes["displayname"].Value;
                    fv.Columns[columnIndex].Label = displayname;
                }

                if (node.Attributes["sort"].Value != null)
                {
                    bool sort = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["sort"].Value);
                    fv.Columns[columnIndex].AllowAutoSort = sort;
                }

                columnIndex++;
            }
        }

        /// <summary>
        /// 设置列格式化信息 不包括单元格属性信息
        /// </summary>
        /// <param name="fv">需设置的FarPoint</param>
        /// <param name="fileName">配置文件名称</param>
        public static void SaveColumnFormatProperty(FarPoint.Win.Spread.SheetView fv, string fileName)
        {
            string path;
            try
            {
                path = fileName.Substring(0, fileName.LastIndexOf(@"\"));
                if (System.IO.Directory.Exists(path) == false)
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            catch { }

            Neusoft.FrameWork.Xml.XML myXml = new Neusoft.FrameWork.Xml.XML();
            XmlDocument doc = new XmlDocument();
            XmlElement root;
            root = myXml.CreateRootElement(doc, "Setting", "1.0");
            for (int i = 0; i < fv.Columns.Count; i++)
            {
                XmlElement e = myXml.AddXmlNode(doc, root, "Column", "");
                myXml.AddNodeAttibute(e, "displayname", fv.Columns[i].Label);
                myXml.AddNodeAttibute(e, "width", fv.Columns[i].Width.ToString());
                myXml.AddNodeAttibute(e, "visible", fv.Columns[i].Visible.ToString());

                if (fv.Columns[i].Locked)
                {
                    myXml.AddNodeAttibute(e, "enable", "false");
                }
                else
                {
                    myXml.AddNodeAttibute(e, "enable", "true");
                }

                myXml.AddNodeAttibute(e, "sort", fv.Columns[i].AllowAutoSort.ToString());
            }
            try
            {
                StreamWriter sr = new StreamWriter(fileName, false, System.Text.Encoding.Default);
                string cleandown = doc.OuterXml;
                sr.Write(cleandown);
                sr.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("无法保存！" + ex.Message); 
            }
        }

        /// <summary>
        /// sheetView列明多语言翻译
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="tempTranslateDictionary"></param>
        private static void ChangeSheetLable(FarPoint.Win.Spread.SheetView sv,ref Dictionary<string, string> tempTranslateDictionary)
        {
            if (sv.ColumnHeader.RowCount > 1)
            {
                for (int i = 0; i < sv.ColumnHeader.RowCount; i++)
                {
                    for (int j = 0; j < sv.ColumnHeader.Columns.Count; j++)
                    {
                        string translateStr = Neusoft.FrameWork.Management.Language.Msg(sv.ColumnHeader.Cells[i, j].Text);

                        if (tempTranslateDictionary.ContainsKey(translateStr) == false)
                        {
                            tempTranslateDictionary.Add(translateStr, sv.ColumnHeader.Cells[i, j].Text);
                        }

                        sv.ColumnHeader.Cells[i, j].Text = translateStr;
                    }
                }
            }
            else
            {
                for (int i = 0; i < sv.ColumnHeader.Columns.Count; i++)
                {
                    string translateStr = Neusoft.FrameWork.Management.Language.Msg(sv.Columns[i].Label);

                    if (tempTranslateDictionary.ContainsKey(translateStr) == false)
                    {
                        tempTranslateDictionary.Add(translateStr, sv.Columns[i].Label);
                    }

                    sv.Columns[i].Label = translateStr;
                }
            }
        }


        /// <summary>
        /// FarPoint 列名多语言翻译
        /// 
        /// {1B10BCB7-8133-4282-8479-9C41FE5A23FD}
        /// </summary>
        public static Dictionary<string,string> TranslateSheetViewLabel(FarPoint.Win.Spread.FpSpread fp)
        {
            Dictionary<string, string> tempTranslateDictionary = new Dictionary<string, string>();
            foreach (FarPoint.Win.Spread.SheetView sheet in fp.Sheets)
            {
                if (sheet.DataSource == null)
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ChangeSheetLable(sheet, ref tempTranslateDictionary);
                    if (sheet.GetChildSheets().Count > 0)
                    {
                        foreach (FarPoint.Win.Spread.SheetView sv in sheet.GetChildSheets())
                        {
                            Neusoft.FrameWork.WinForms.Classes.CustomerFp.ChangeSheetLable(sv, ref tempTranslateDictionary);
                        }

                    }
                }
                else
                {
                    SetFPDataSource(sheet, ref tempTranslateDictionary);
                }

                sheet.SheetName = Neusoft.FrameWork.Management.Language.Msg( sheet.SheetName );
            }

            return tempTranslateDictionary;
        }

       /// <summary>
        /// FarPoint 列名多语言翻译
       /// </summary>
       /// <param name="sv">SheetView</param>
       /// <param name="dicLanguage"></param>
        private static void SetFPDataSource(FarPoint.Win.Spread.SheetView sv, ref Dictionary<string, string> dicLanguage)
        {
            object dataSorce = sv.DataSource;
            DataTable dt = null;
            if (dataSorce is DataTable)
            {
                dt = dataSorce as DataTable;
                SetFpDataTable(sv,dt,false,ref dicLanguage);
            }
            if (dataSorce is DataView)
            {
                dt = (dataSorce as DataView).Table;
                SetFpDataTable(sv, dt, false, ref dicLanguage);
            }
            if (dataSorce is DataSet)
            {
                DataSet ds = dataSorce as DataSet;
                //存在dataTable的父子关系
                if (ds.Relations.Count > 0)
                {
                    foreach (DataRelation dr in ds.Relations)
                    {
                        SetFpDataTable(sv, dr.ParentTable, false, ref dicLanguage);
                        SetFpDataTable(sv, dr.ChildTable, true, ref dicLanguage);
                    }
                }
                else
                {
                    for(int i=0;i<ds.Tables.Count;i++)
                    {
                        dt = ds.Tables[i];
                        SetFpDataTable(sv, dt, false, ref dicLanguage);
                    }
                }
            }
        }

        /// <summary>
        /// FarPoint 列名多语言翻译
        /// </summary>
        /// <param name="sv">SheetView</param>
        /// <param name="dt">DataTable</param>
        /// <param name="isChild">是否是子表</param>
        /// <param name="dicLanguage"></param>
        private static void SetFpDataTable(FarPoint.Win.Spread.SheetView sv,DataTable dt,bool isChild , ref Dictionary<string, string> dicLanguage)
        {
            string translateStr = string.Empty;
            string dcName = string.Empty;
            for (int i = 0; i < dt.Columns.Count;i++ )
            {
                dcName = dt.Columns[i].ColumnName;
                translateStr = Neusoft.FrameWork.Management.Language.Msg(dcName);
                if (!string.IsNullOrEmpty(translateStr))
                {
                    dt.Columns[i].Caption = translateStr;
                }
                else
                {
                    dt.Columns[i].Caption = dcName;
                }

                if (dicLanguage.ContainsKey(translateStr) == false)
                {
                    dicLanguage.Add(translateStr, dcName);
                }
                if (!isChild)
                {
                    sv.Columns[i].Label = translateStr;
                }
            }
        }

        /// <summary>
        /// 自动适应表格中的最长的一列,Count是列的数量 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="fp"></param>
        public static void AutoFormatWidthView(int count, FarPoint.Win.Spread.SheetView fp)
        {
            for (int i = 0; i < count; i++)
            {
                float s = fp.GetPreferredColumnWidth( i, false );
                fp.Columns[i].Width = s + 10;
            }
        } 
    }
}

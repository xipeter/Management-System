using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Neusoft.HISFC.BizLogic.EPR
{
    ///<summary>
    /// NurseTend<br></br>
    /// [功能描述: 护理记录业务层类<br></br>
    /// [创 建 者: 刘志存]<br></br>
    /// [创建时间: 2007-11-09]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public class NurseTend:Neusoft.FrameWork.Management.Database
    {
        #region 护理记录设置
        /// <summary>
        /// 取得所有在用护理记录设置
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryNurseSheetSettingList()
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message obj = null;

            ArrayList lis = new ArrayList();

            if (this.Sql.GetSql("EPR.NURSE.QueryNurseSetting", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql);

                this.ExecQuery(strSql);

                while (this.Reader.Read())
                {
                    obj = new Neusoft.HISFC.Models.Base.Message();   //ID
                    obj.ID = this.Reader[0].ToString();         //ID
                    obj.Name = this.Reader[1].ToString();       //Dept_Code
                    obj.Memo = this.Reader[2].ToString();       //Dept_Name
                    obj.User01 = this.Reader[3].ToString();     //File_Name
                    obj.User02 = this.Reader[4].ToString();     //Data
                    obj.User03 = this.Reader[5].ToString();
                    obj.Oper.ID = this.Reader[6].ToString();    //Oper_Code
                    obj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString()); //Oper_Date
                    lis.Add(obj);
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();

                return null;
            }

            return lis;
        }

        /// <summary>
        /// 根据ID取护理记录设置
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.Message QueryNurseSheetSettingByID(string ID)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message obj = null;

            if (this.Sql.GetSql("EPR.NURSE.QueryNurseSettingByID", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, ID);

                this.ExecQuery(strSql);

                if (this.Reader.Read())
                {
                    obj = new Neusoft.HISFC.Models.Base.Message();   //ID
                    obj.ID = this.Reader[0].ToString();         //ID
                    obj.Name = this.Reader[1].ToString();       //Dept_Code
                    obj.Memo = this.Reader[2].ToString();       //Dept_Name
                    obj.User01 = this.Reader[3].ToString();     //File_Name
                    obj.User02 = this.Reader[4].ToString();     //Data
                    obj.User03 = this.Reader[5].ToString();     //Data
                    obj.Oper.ID = this.Reader[6].ToString();    //Oper_Code
                    obj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString()); //Oper_Date
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();

                return null;
            }

            return obj;

        }

        /// <summary>
        /// 根据ID取护理记录设置
        /// </summary>
        /// <returns></returns>
        public Neusoft.HISFC.Models.Base.Message QueryNurseSheetSettingByName(string Name)
        {
            string strSql = "";

            Neusoft.HISFC.Models.Base.Message obj = null;

            if (this.Sql.GetSql("EPR.NURSE.QueryNurseSettingByName", ref strSql) == -1) return null;

            try
            {
                strSql = string.Format(strSql, Name);

                this.ExecQuery(strSql);

                if (this.Reader.Read())
                {
                    obj = new Neusoft.HISFC.Models.Base.Message();   //ID
                    obj.ID = this.Reader[0].ToString();         //ID
                    obj.Name = this.Reader[1].ToString();       //Dept_Code
                    obj.Memo = this.Reader[2].ToString();       //Dept_Name
                    obj.User01 = this.Reader[3].ToString();     //File_Name
                    obj.User02 = this.Reader[4].ToString();     //Data
                    obj.User03 = this.Reader[5].ToString();     //Data
                    obj.Oper.ID = this.Reader[6].ToString();    //Oper_Code
                    obj.Oper.OperTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.Reader[7].ToString()); //Oper_Date
                }

                this.Reader.Close();
            }
            catch (Exception ex)
            {
                this.Err = ex.Message;
                this.WriteErr();

                return null;
            }

            return obj;

        }
        ///<summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertNurseSheetSetting(Neusoft.HISFC.Models.Base.Message obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.NURSE.InsertNurseSetting", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql,obj.Name, obj.Memo, obj.User01, obj.User03,obj.Oper.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.InputLong(strSql, obj.User02);
        }

        /// <summary>
        /// 修改护理记录设置
        /// </summary>
        /// <param name="obj">护理记录设置实体</param>
        /// <returns>成功，返回1</returns>
        public int UpdateNurseSheetSetting(Neusoft.HISFC.Models.Base.Message obj)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.NURSE.UpdateNurseSetting", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, obj.ID, obj.Name,obj.Memo,obj.User01,obj.User03, obj.Oper.ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.InputLong(strSql, obj.User02);


        }
        /// <summary>
        /// 删除一条护理记录设置
        /// </summary>
        /// <param name="ID">护理记录ID</param>
        /// <returns>删除成功，返回1</returns>
        public int DeleteNurseSheetSetting(string ID)
        {
            string strSql = "";

            if (this.Sql.GetSql("EPR.NURSE.DeleteNurseSetting", ref strSql) == -1) return -1;

            try
            {
                strSql = string.Format(strSql, ID);
            }
            catch (Exception ex)
            {
                this.ErrCode = ex.Message;
                this.Err = "接口错误！" + ex.Message;
                this.WriteErr();
                return -1;
            }

            return this.ExecNoQuery(strSql);
        }

        /// <summary>
        /// 从Xml中读取数据到NurseSheetSetting对象
        /// </summary>
        /// <param name="strXml">Xml字符串</param>
        /// <param name="setting">NurseSheetSetting对象</param>
        public void SetNurseSheetingSetting(string strXml, Neusoft.HISFC.Models.EPR.NurseSheetSetting setting)
        {
            if (setting == null)
            {
                setting = new Neusoft.HISFC.Models.EPR.NurseSheetSetting();
            }
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(strXml);
            //XmlElement elmHelp = (XmlElement)doc.DocumentElement.SelectSingleNode("Help");
            //if (elmHelp != null)
            //{
            //    if (elmHelp.HasAttribute("IsUseHelp"))
            //    {
            //        setting.IsUseHelp = bool.Parse(elmHelp.Attributes["IsUseHelp"].Value);
            //    }
            //    else
            //    {
            //        setting.IsUseHelp = false;
            //    }
            //    if (elmHelp.HasAttribute("Text"))
            //    {
            //        setting.Help = elmHelp.Attributes["Text"].Value.Split('\n');
            //    }
            //    else
            //    {
            //        setting.Help = new string[] { "" };
            //    }
            //}
            XmlElement elmPrint = (XmlElement)doc.DocumentElement.SelectSingleNode("Print");
            if (elmPrint != null)
            {
                //if (elmPrint.HasAttribute("PrintType"))
                //{
                //    setting.PrintType = int.Parse(elmPrint.Attributes["PrintType"].Value);
                //}
                //else
                //{
                //    setting.PrintType = 0;
                //}
                //if (elmPrint.HasAttribute("Page"))
                //{
                //    setting.Page = elmPrint.Attributes["Page"].Value;
                //}
                //else
                //{
                //    setting.Page = "A4";
                //}
                //if (elmPrint.HasAttribute("LandScape"))
                //{
                //    setting.LandSacpe = bool.Parse(elmPrint.Attributes["LandScape"].Value);
                //}
                //else
                //{
                //    setting.LandSacpe = false;
                //}
                //if (elmPrint.HasAttribute("RowHeight"))
                //{
                //    setting.RowHeight = int.Parse(elmPrint.Attributes["RowHeight"].Value);
                //}
                //else
                //{
                //    setting.RowHeight = 0;
                //}
                //if (elmPrint.HasAttribute("StartX"))
                //{
                //    setting.StartX = int.Parse(elmPrint.Attributes["StartX"].Value);
                //}
                //else
                //{
                //    setting.StartX = 0;
                //}
                //if (elmPrint.HasAttribute("StartY"))
                //{
                //    setting.StartY = int.Parse(elmPrint.Attributes["StartY"].Value);
                //}
                //else
                //{
                //    setting.StartY = 0;
                //}
                //if (elmPrint.HasAttribute("RowCount1"))
                //{
                //    setting.RowCount1 = int.Parse(elmPrint.Attributes["RowCount1"].Value);
                //}
                //else
                //{
                //    setting.RowCount1 = 0;
                //}
                //if (elmPrint.HasAttribute("RowCount2"))
                //{
                //    setting.RowCount2 = int.Parse(elmPrint.Attributes["RowCount2"].Value);
                //}
                //else
                //{
                //    setting.RowCount2 = 0;
                //}
                //if (elmPrint.HasAttribute("CaptionRowCount"))
                //{
                //    setting.CaptionRowCount = int.Parse(elmPrint.Attributes["CaptionRowCount"].Value);
                //}
                //else
                //{
                //    setting.CaptionRowCount = 0;
                //}
                //if (elmPrint.SelectSingleNode("BackGroundImage") != null)
                //{
                //    System.Text.UnicodeEncoding encoding = new UnicodeEncoding();
                //    string str = elmPrint.SelectSingleNode("BackGroundImage").InnerText;
                //    if (str.Trim().Length > 0)
                //    {
                //        byte[] byteimg = Convert.FromBase64String(str.Trim()); // encoding.GetBytes(str.Trim());
                //        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteimg); //(Application.StartupPath + "\\NurseBackImage.bmp", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                //        //stream.Write(byteimg, 0, byteimg.Length);
                //        Bitmap bmp = new Bitmap(stream);
                //        Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                //        Graphics draw = Graphics.FromImage(bmp2);
                //        draw.DrawImage(bmp, 0, 0);
                //        setting.BackImage = bmp2; // (Bitmap)Image.FromStream(stream); // (Application.StartupPath + "\\NurseBackImage.bmp");
                //        stream.Close();
                //        bmp.Dispose();
                //        stream.Dispose();
                //    }
                //}
            }
            XmlElement elmColumns = (XmlElement)doc.DocumentElement.SelectSingleNode("Columns");
            if (elmColumns != null && elmColumns.SelectNodes("Column") != null)
            {
                XmlNodeList elmColumnList = elmColumns.SelectNodes("Column");
                setting.Columns = new Neusoft.HISFC.Models.EPR.NurseSheetSettingColumn[elmColumnList.Count];
                for (int i = 0; i < elmColumnList.Count; i++)
                {
                    XmlElement elmColumn = (XmlElement)elmColumnList[i];
                    setting.Columns[i] = new Neusoft.HISFC.Models.EPR.NurseSheetSettingColumn();
                    if (elmColumn.HasAttribute("Caption"))
                    {
                        setting.Columns[i].Caption = elmColumn.Attributes["Caption"].Value;
                    }
                    else
                    {
                        setting.Columns[i].Caption = "";
                    }
                    //if (elmColumn.HasAttribute("WordCount"))
                    //{
                    //    setting.Columns[i].WordCount = int.Parse(elmColumn.Attributes["WordCount"].Value);
                    //}
                    //else
                    //{
                    //    setting.Columns[i].WordCount = 4;
                    //}
                    if (elmColumn.HasAttribute("Style"))
                    {
                        setting.Columns[i].Style = (Neusoft.HISFC.Models.EPR.ColumnStyle)Enum.Parse(typeof(Neusoft.HISFC.Models.EPR.ColumnStyle), elmColumn.Attributes["Style"].Value);
                    }
                    else
                    {
                        setting.Columns[i].Style = Neusoft.HISFC.Models.EPR.ColumnStyle.文本框;
                    }
                    if (elmColumn != null && elmColumn.SelectNodes("Item") != null)
                    {
                        XmlNodeList elmItemList = elmColumn.SelectNodes("Item");
                        setting.Columns[i].Items = new string[elmItemList.Count];
                        for (int j = 0; j < elmItemList.Count; j++)
                        {

                            setting.Columns[i].Items[j] = elmItemList[j].InnerText;
                        }
                    }
                    if (elmColumn.HasAttribute("IsDescription"))
                    {
                        setting.Columns[i].IsDescription = bool.Parse(elmColumn.Attributes["IsDescription"].Value);
                    }
                    else
                    {
                        setting.Columns[i].IsDescription = false;
                    }
                    if (elmColumn.HasAttribute("IsUseHelp"))
                    {
                        setting.Columns[i].IsUseHelp = bool.Parse(elmColumn.Attributes["IsUseHelp"].Value);
                    }
                    else
                    {
                        setting.Columns[i].IsUseHelp = false;
                    }
                    if (elmColumn.HasAttribute("Width"))
                    {
                        setting.Columns[i].Width = int.Parse(elmColumn.Attributes["Width"].Value);
                    }
                    else
                    {
                        setting.Columns[i].Width = 0;
                    }
                    if (elmColumn.HasAttribute("Left"))
                    {
                        setting.Columns[i].Left = int.Parse(elmColumn.Attributes["Left"].Value);
                    }
                    else
                    {
                        setting.Columns[i].Left = 0;
                    }
                    if (elmColumn.HasAttribute("Help"))
                    {
                        setting.Columns[i].Help = elmColumn.Attributes["Help"].Value.Split('\n');
                    }
                    else
                    {
                        setting.Columns[i].Help = null;
                    }
                }
            }
        }

        /// <summary>
        /// 从对象生成Xml
        /// </summary>
        /// <param name="setting"></param>
        public string GetXmlFromNurseSheetSetting(Neusoft.HISFC.Models.EPR.NurseSheetSetting setting)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            Neusoft.FrameWork.Xml.XML xml = new Neusoft.FrameWork.Xml.XML();
            XmlElement root = xml.CreateRootElement(doc, "Setting");

            ////Help
            //XmlElement elmHelp = xml.AddXmlNode(doc, root, "Help", "");
            //xml.AddNodeAttibute(elmHelp, "IsUseHelp", setting.IsUseHelp.ToString());
            //if (setting.Help != null && setting.Help.Length > 0)
            //{
            //    xml.AddNodeAttibute(elmHelp, "Text", string.Join("\n", setting.Help));
            //}

            //Print
            System.Xml.XmlElement elmPrint = xml.AddXmlNode(doc, root, "Print", "");
            //xml.AddNodeAttibute(elmPrint, "PrintType", setting.PrintType.ToString());
            //xml.AddNodeAttibute(elmPrint, "Page", setting.Page);
            //xml.AddNodeAttibute(elmPrint, "LandScape", setting.LandSacpe.ToString());
            //xml.AddNodeAttibute(elmPrint, "StartX", setting.StartX.ToString());
            //xml.AddNodeAttibute(elmPrint, "StartY", setting.StartY.ToString());
            //xml.AddNodeAttibute(elmPrint, "RowHeight", setting.RowHeight.ToString());
            //xml.AddNodeAttibute(elmPrint, "RowCount1", setting.RowCount1.ToString());
            //xml.AddNodeAttibute(elmPrint, "RowCount2", setting.RowCount2.ToString());
            //xml.AddNodeAttibute(elmPrint, "CaptionRowCount", setting.CaptionRowCount.ToString());
            //if (setting.BackImage != null)
            //{
            //    string fileName = Neusoft.NFC.Interface.Classes.Function.GetTempFileName() + ".bmp";
            //    setting.BackImage.Save(fileName);
            //    System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            //    byte[] byteimg = new byte[stream.Length];

            //    stream.Read(byteimg, 0, (int)stream.Length);
            //    stream.Close();
            //    System.Text.UnicodeEncoding encoding = new UnicodeEncoding();
            //    string strImg = Convert.ToBase64String(byteimg); // encoding.GetString(byteimg);
            //    xml.AddXmlCDataNode(doc, elmPrint, "BackGroundImage", strImg);
            //}
            System.Xml.XmlElement elmColumns = xml.AddXmlNode(doc, root, "Columns", "");
            //Columns
            if (setting.Columns != null && setting.Columns.Length > 0)
            {

                for (int i = 0; i < setting.Columns.Length; i++)
                {
                    System.Xml.XmlElement elmColumn = xml.AddXmlNode(doc, elmColumns, "Column", "");
                    xml.AddNodeAttibute(elmColumn, "Caption", setting.Columns[i].Caption);
                    xml.AddNodeAttibute(elmColumn, "Style", setting.Columns[i].Style.ToString());
                    //xml.AddNodeAttibute(elmColumn, "WordCount", setting.Columns[i].WordCount.ToString());
                    xml.AddNodeAttibute(elmColumn, "IsDescription", setting.Columns[i].IsDescription.ToString());
                    xml.AddNodeAttibute(elmColumn, "IsUseHelp", setting.Columns[i].IsUseHelp.ToString());
                    if (setting.Columns[i].Help != null)
                    {
                        xml.AddNodeAttibute(elmColumn, "Help", string.Join("\n", setting.Columns[i].Help));
                    }
                    xml.AddNodeAttibute(elmColumn, "Width", setting.Columns[i].Width.ToString());
                    xml.AddNodeAttibute(elmColumn, "Left", setting.Columns[i].Left.ToString());

                    if (setting.Columns[i].Items != null && setting.Columns[i].Items.Length > 0)
                    {
                        for (int j = 0; j < setting.Columns[i].Items.Length; j++)
                        {
                            System.Xml.XmlElement elemItem = xml.AddXmlNode(doc, elmColumn, "Item", setting.Columns[i].Items[j]);
                        }
                    }
                }
            }
            return doc.OuterXml;
        }

        #endregion 护理记录设置
        #region 护理记录
        public ArrayList GetStringList(string strText, int maxCount, Font font)
        {
            char chr;
            int startIndex = 0, currentLength, length;
            ArrayList arr = new ArrayList();
            if (strText == "")
            {
                return arr;
            }
            char chr127 = (char)127;

            System.Windows.Forms.RichTextBox r = new System.Windows.Forms.RichTextBox();
            r.Font = font;
            if (strText.Length > 2)
            {
                if (strText.Substring(0, 2) == @"{\")
                {
                    r.SelectedRtf = strText;
                }
                else
                {
                    r.SelectedText = strText;
                }
            }
            else
            {
                r.SelectedText = strText;
            }
            if (r.TextLength < 1)
            {
                return arr;
            }

            string[] strs = r.Lines;
            int len;

            int pos = 0;
            foreach (string str2 in strs)
            {
                len = str2.Length;
                string str1 = str2.TrimEnd(null);
                length = 0;
                startIndex = 0;
                if (str1.Trim() != "")
                {
                    for (int j = 0; j < str1.Length; j++)
                    {
                        chr = str1[j];
                        if (chr < chr127)
                        {
                            currentLength = 1;
                        }
                        else
                        {
                            currentLength = 2;
                        }
                        length += currentLength;
                        if (length > maxCount)
                        {
                            string s = str1.Substring(startIndex, j - startIndex);
                            s = s + " ";
                            r.Select(pos + j, 0);
                            r.SelectedText = " ";
                            r.Select(pos + startIndex, j - startIndex + 1);
                            arr.Add(r.SelectedRtf);
                            r.Select(pos + j, 1);
                            r.SelectedText = "";
                            startIndex = j;
                            length = currentLength;
                        }
                        else if (length == maxCount)
                        {
                            string s = str1.Substring(startIndex, j - startIndex + 1);
                            r.Select(pos + startIndex, j - startIndex + 1);
                            arr.Add(r.SelectedRtf);
                            startIndex = j + 1;
                            length = 0;
                        }
                    }
                    if (length != 0)
                    {
                        string s = str1.Substring(startIndex);
                        s = s + "".PadRight(maxCount - length);
                        r.Select(pos + startIndex, str1.Length - startIndex);
                        string strTemp = r.SelectedRtf;
                        int posTemp = strTemp.LastIndexOf("}");
                        strTemp = strTemp.Substring(0, posTemp) + "".PadRight(maxCount - length) + strTemp.Substring(posTemp);
                        arr.Add(strTemp);
                    }
                }
                pos += len + 1;
            }
            return arr;
        }
        public void GetInnerText(Control panel, string strInnerText)
        {
            try
            {
                int iStart;
                int iEnd;
                foreach (Control c in panel.Controls)
                {
                    if (c.Tag != null && c.Tag.ToString() != "")
                    {
                        iStart = strInnerText.IndexOf("<" + c.Tag.ToString() + ">");
                        iEnd = strInnerText.IndexOf("</" + c.Tag.ToString() + ">");
                        if (iStart >= 0 && iEnd >= 0)
                        {
                            string s = strInnerText.Substring(iStart + c.Tag.ToString().Length + 2, iEnd - iStart - c.Tag.ToString().Length - 2);
                            if (s.Length > 2 && s.Substring(0, 2) == @"{\")
                            {
                                ((RichTextBox)c).Rtf = strInnerText.Substring(iStart + c.Tag.ToString().Length + 2, iEnd - iStart - c.Tag.ToString().Length - 2);
                                //c.Text = strInnerText.Substring(iStart + Len(c.Tag) + 2, iEnd - iStart - Len(c.Tag) - 2)
                            }
                            else
                            {
                                if (c.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                                {
                                    ((DateTimePicker)c).Value = DateTime.Parse(strInnerText.Substring(iStart + c.Tag.ToString().Length + 2, iEnd - iStart - c.Tag.ToString().Length - 2));
                                    ((DateTimePicker)c).Text = strInnerText.Substring(iStart + c.Tag.ToString().Length + 2, iEnd - iStart - c.Tag.ToString().Length - 2);
                                }
                                else
                                {
                                    c.Text = strInnerText.Substring(iStart + c.Tag.ToString().Length + 2, iEnd - iStart - c.Tag.ToString().Length - 2);
                                }

                            }
                        }
                    }
                    if(c.Controls != null && c.Controls.Count > 0)
                    {
                        GetInnerText(c, strInnerText);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void GetInnerText(Control panel, XmlElement elemRecord)
        {
            try
            {
                foreach (Control c in panel.Controls)
                {
                    if (c.Tag != null && c.Tag.ToString() != "")
                    {
                        XmlElement elemTemp = (XmlElement)elemRecord.SelectSingleNode(c.Tag.ToString());
                        if(elemTemp != null)
                        {
                            string s = elemTemp.InnerText;
                            if (s.Length > 2 && s.Substring(0, 2) == @"{\")
                            {
                                ((RichTextBox)c).Rtf = s;
                                //c.Text = strInnerText.Substring(iStart + Len(c.Tag) + 2, iEnd - iStart - Len(c.Tag) - 2)
                            }
                            else
                            {
                                if (c.GetType() == typeof(DateTimePicker) || c.GetType().IsSubclassOf(typeof(DateTimePicker)))
                                {
                                    ((DateTimePicker)c).Value = DateTime.Parse(s);
                                    ((DateTimePicker)c).Text = s;
                                }
                                else
                                {
                                    c.Text = s;
                                }

                            }
                        }
                    }
                    if (c.Controls != null && c.Controls.Count > 0)
                    {
                        GetInnerText(c, elemRecord);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public string SetInnerText(Control panel)
        {
            string sReturn = "";
            foreach (Control c in panel.Controls)
            {
                string s = "<{0}>{1}</{0}>";
                if (c.Tag != null && c.Tag.ToString() != "")
                {
                    if (c.GetType() == typeof(System.Windows.Forms.RichTextBox) || c.GetType().IsSubclassOf(typeof(System.Windows.Forms.RichTextBox)))
                    {
                        RichTextBox r = (RichTextBox)c;
                        s = String.Format(s, c.Tag.ToString(), r.Rtf);
                    }
                    else if (c.GetType() == typeof(DateTimePicker) || c.GetType().IsSubclassOf(typeof(DateTimePicker)))
                    {
                        if (c.Text == "")
                        {
                            DateTimePicker d = (DateTimePicker)c;
                            if (d.Value.Hour == 0 && d.Value.Minute == 0 && d.Value.Second == 0)
                            {
                                s = String.Format(s, c.Tag.ToString(), d.Value.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                s = String.Format(s, c.Tag.ToString(), d.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        else
                        {
                            s = String.Format(s, c.Tag.ToString(), c.Text.TrimEnd( new char[]{(char)13, (char)10}));
                        }
                    }
                    else
                    {
                        s = String.Format(s, c.Tag.ToString(), c.Text.TrimEnd(new char[]{(char)13, (char)10}));
                    }
                    sReturn += s;
                    if (panel.Controls != null && panel.Controls.Count > 0)
                    {
                        sReturn += SetInnerText(c);
                    }
                }
            }
            return sReturn;
        }
        public XmlElement SetInnerText(Control panel, XmlDocument doc)
        {
            XmlElement elemRecord = doc.CreateElement("Record");

            foreach (Control c in panel.Controls)
            {
                //string s = "<{0}>{1}</{0}>";
                string s = "";
                if (c.Tag != null && c.Tag.ToString() != "")
                {
                    if (c.GetType() == typeof(System.Windows.Forms.RichTextBox) || c.GetType().IsSubclassOf(typeof(System.Windows.Forms.RichTextBox)))
                    {
                        RichTextBox r = (RichTextBox)c;
                        s = r.Rtf;
                    }
                    else if (c.GetType() == typeof(DateTimePicker) || c.GetType().IsSubclassOf(typeof(DateTimePicker)))
                    {
                        if (c.Text == "")
                        {
                            DateTimePicker d = (DateTimePicker)c;
                            if (d.Value.Hour == 0 && d.Value.Minute == 0 && d.Value.Second == 0)
                            {
                                s =d.Value.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                s = d.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        else
                        {
                            s = c.Text.TrimEnd(new char[] { (char)13, (char)10 });
                        }
                    }
                    else
                    {
                        s = c.Text.TrimEnd(new char[] { (char)13, (char)10 });
                    }
                    XmlCDataSection data = doc.CreateCDataSection(s);
                    XmlElement elemTemp = doc.CreateElement(c.Tag.ToString());
                    elemTemp.AppendChild(data);
                    elemRecord.AppendChild(elemTemp);
                }
                if (c.Controls != null && c.Controls.Count > 0)
                {
                    XmlElement elem2 = SetInnerText(c, doc);
                    for(int i = elem2.ChildNodes.Count - 1; i >= 0; i--)
                    {
                        elemRecord.AppendChild(elem2.ChildNodes[i]);
                    }
                }

            }
            return elemRecord;
        }
        public string GetString(string innerText, string sNode)
        {
            int iStart, iEnd;
            iStart = innerText.IndexOf("<" + sNode + ">");
            iEnd = innerText.IndexOf("</" + sNode + ">");
            if (iStart >= 0 && iEnd >= 0)
            {
                String s;
                try
                {
                    s = innerText.Substring(iStart + sNode.Length + 2, iEnd - iStart - sNode.Length - 2);
                    return s;
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";
        }

        #endregion 护理记录

        public const int WM_USER = 0x0400;
        public const int EM_GETPARAFORMAT = WM_USER + 61;
        public const int EM_SETPARAFORMAT = WM_USER + 71;
        public const long MAX_TAB_STOPS = 32;
        public const uint PFM_LINESPACING = 0x00000100;
        [StructLayout(LayoutKind.Sequential)]
        private struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT2 lParam);
        //调整高度
        public void AdjustLineSpace(RichTextBox rc, double times)
        {
            rc.SelectAll();
            //double RowDist = double.Parse(this.comboBox1.Text);
            //RichTextBox行距为RowDist

            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.bLineSpacingRule = 4; //4：固定高度
            fmt.dyLineSpacing = (int)(((int)rc.Font.Size) * 20 * times);
            fmt.dwMask = PFM_LINESPACING;
            SendMessage(new HandleRef(rc, rc.Handle), EM_SETPARAFORMAT, 0, ref fmt);

        }

    }
}

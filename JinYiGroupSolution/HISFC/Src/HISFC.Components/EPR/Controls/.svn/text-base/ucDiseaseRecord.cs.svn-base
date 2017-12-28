using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
namespace Neusoft.HISFC.Components.EPR.Controls
{
    public partial class ucDiseaseRecord : UserControl,Neusoft.FrameWork.EPRControl.IUserControlable,Neusoft.FrameWork.EPRControl.IQCDatable,Neusoft.FrameWork.EPRControl.IControlPrintable
    { 
        public ucDiseaseRecord()
        {
            InitializeComponent();
            this.emrMultiLineTextBox1.IsShowModify = false;
            this.AutoScaleMode = AutoScaleMode.None;
        }
        #region 变量
        private string modualRtf = "";//模板RTF字符串格式
        private string xmlStr;//文件属性
        Font f = new Font("宋体", 13.5f, FontStyle.Underline);
        #endregion
         
        #region  属性
        [CategoryAttribute("Neu-设计"), Browsable(true), DescriptionAttribute("模板RTF字符串，显示的格式, 参数{0},{1},{2},{3},{4},{5} 分别代表：日期,上级医生类别签名,上级医生类别,病程内容,医生签名,上级医生签名")]
        public string ModualRtf 
        {
            get 
            {
                 modualRtf = " {0}                                       {1} {2}   "+ "\r\n"+" \r\n"+"   {3}"+"\r\n"+"\r\n"+"\r\n"+"                                                                          {4}                {5}"+"\r\n";
                 return modualRtf;
            }
            set 
            {
                 modualRtf = " {0}                                       {1} {2}   " + "\r\n" + " \r\n" + "   {3}" + "\r\n" + "\r\n" + "\r\n" + "                                                                           {4}              {5}"+"\r\n";
            }
        }
        /// <summary>
        /// 设置字体
        /// </summary>
        [CategoryAttribute("Neu-设计"), Browsable(true), DescriptionAttribute("设置文本字体")]
        public Font RichFont
        {
            get 
            {
                return f;
            }
            set
            {
                f = value;
                this.emrMultiLineTextBox1.Font = value;
            }
        }
        /// <summary>
        /// 保存格式
        /// </summary>
        [Browsable (false )]
        public string Rich1Rtf
        {
            get 
            {
                return this.emrMultiLineTextBox1.Rtf;
            }
            set
            {
                this.emrMultiLineTextBox1.Rtf = value;
            }
        
        }

        /// <summary>
        /// XML文件
        /// </summary>
        [Browsable(false)]
        public string XmlStr
        {
            get 
            {
                return xmlStr ;
            }
            set 
            {
                xmlStr = value;

            }
        }


        #endregion
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.XmlStr != null)
            {
                WriteXmlFromAttribute();
            }
            frmDiseaseInput f = new frmDiseaseInput(this.XmlStr,RichFont);
            f.ShowDialog();             
             #region  uclist
            if (f.UcList != null)
            { 
                RichTextBox t = new RichTextBox();
                t.Font = this.RichFont;
                
                ArrayList al = f.UcList;
                foreach (Neusoft.FrameWork.Models.NeuObject obj in al)
                {
                    t.Select(t.TextLength, 0);
                    t.SelectedText = ModualRtf;
                    int index0 = t.Find("{0}");
                    if (index0 > 0)
                    {
                        t.Select(index0, 3);
                        t.SelectedText = obj.ID;
                        
                    }

                    int index1 = t.Find("{1}");
                    if (index1 > 0)
                    {
                        t.Select(index1, 3);
                        t.SelectedText = obj.Name;
                     
                    }

                    int index2 = t.Find("{2}");
                    if (index2 > 0)
                    {
                        t.Select(index2, 3);
                        t.SelectedText = obj.Memo;
                        
                    }

                    int index3 = t.Find("{3}");
                    if (index3 > 0)
                    {
                        t.Select(index3, 3);
                        t.SelectedRtf = obj.User01;
                        
                    }

                    int index4 = t.Find("{4}");
                    if (index4 > 0)
                    {
                        t.Select(index4, 3);
                        t.SelectedText = obj.User02;
                      
                    }

                    int index5 = t.Find("{5}");
                    if (index5 > 0)
                    {
                        t.Select(index5, 3);
                        t.SelectedText = obj.User03;
                       
                    }                    
                }
                try
                {
                    base.OnTextChanged(null);
                }
                catch { }
                try
                {

                    if (t.Rtf == "") return;
                  
                    this.emrMultiLineTextBox1.Rtf = t.Rtf;
                    
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            #endregion
            this.xmlStr=f.UcXmlStr;
            //this.emrMultiLineTextBox1.SelectAll();
            //this.emrMultiLineTextBox1.SelectionFont = this.RichFont;
            //this.emrMultiLineTextBox1.Select(0, 0);
          
        }

        #region IUserControlable 成员

        public void Init(object sender, string[] @params)
        {
           
        }

        public bool IsPrint
        {
            get
            {
                return false;
                
            }
            set
            {
                if (value)
                {
                    lastRichText = this.emrMultiLineTextBox1.Rtf;
                    this.SetVisibleText();
                }
                else
                {
                    if (lastRichText != "")
                        this.emrMultiLineTextBox1.Rtf = lastRichText;
                }
            }
        }
        string lastRichText = "";
        private void SetVisibleText()
        {

            for (int i = this.emrMultiLineTextBox1.TextLength; i >= 0; i--)
            {
                this.emrMultiLineTextBox1.Select(i, 1);
                bool b = emrMultiLineTextBox1.SelectionProtected;
                this.emrMultiLineTextBox1.SelectionProtected = false;
                if (emrMultiLineTextBox1.SelectionColor == Color.Red)
                {
                    emrMultiLineTextBox1.SelectionColor = Color.Black;
                }
                else if (emrMultiLineTextBox1.SelectionColor == Color.Blue && emrMultiLineTextBox1.SelectionFont.Strikeout == true)
                {

                    emrMultiLineTextBox1.SelectedText = "";
                }
                else
                {
                    emrMultiLineTextBox1.SelectionColor = Color.Black;
                }
                emrMultiLineTextBox1.SelectionProtected = b;

            }
        }
        public void RefreshUC(object sender, string[] @params)
        {
            
        }

        public int Save(object sender)
        {
            return 0;
            
        }

        public int Valid(object sender)
        {
            return 0;
          
        }

        public Control FocusedControl
        {
            get { return this.emrMultiLineTextBox1 ; }
        }

        #endregion

        private void ucDiseaseRecord_Load(object sender, EventArgs e)
        {
            this.emrMultiLineTextBox1.SelectionProtected = true;
            
        } 
        //0,2-副主任，主任。1-主治
        //bool tr = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetMedicalPermission(Neusoft.HISFC.Models.EPR.EnumPermissionType.Medical, 0);
        private void WriteXmlFromAttribute()
        {

            System.IO.StreamWriter str = System.IO.File.CreateText(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath +Neusoft.FrameWork.WinForms.Classes.Function.TempPath + @"\EprDisease.xml");
            str.Write(this.XmlStr);
            str.Close();
            str.Dispose();
        }
        
        /// <summary>
        /// 修改痕迹。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           
         
        }

        #region IQCDatable 成员

        public List<Neusoft.HISFC.Models.EPR.QC> GetQcData(string id, string memo, string patientId, string patientName, string deptcode)
        {
            if (this.XmlStr == null || this.xmlStr == "") return new List<Neusoft.HISFC.Models.EPR.QC>();

            System.Xml.XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(this.XmlStr);
            }
            catch { return new List<Neusoft.HISFC.Models.EPR.QC>(); }

            XmlNodeList nodeList = doc.SelectNodes (@"//病程记录//PatientInfo");
            List<Neusoft.HISFC.Models.EPR.QC> al = new List<Neusoft.HISFC.Models.EPR.QC>();
            foreach (XmlNode xNode in nodeList)
            {
                Neusoft.HISFC.Models.EPR.QC qc = new Neusoft.HISFC.Models.EPR.QC();
                qc.ID = id;
                qc.PatientInfo.ID = patientId;
                qc.PatientInfo.Name = patientName;
                qc.PatientInfo.PVisit.PatientLocation.Dept.ID = deptcode;
                qc.Memo = memo;
                
                qc.Name = xNode.Attributes["DocUpType"].Value;
                if (xNode.Attributes["IsUpSubMission"].Value == "1") //IsUpDocSign
                {
                    qc.QCData.Saver.ID = xNode.Attributes["DocSign"].Value;
                    qc.QCData.Saver.Name = xNode.Attributes["DocSign"].Value;
                    qc.QCData.Saver.Memo =  Neusoft.FrameWork.Function.NConvert.ToDateTime(xNode.Attributes["Date"].Value).ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (xNode.Attributes["IsUpDocSign"].Value == "1") //上级医生签名了
                {
                    qc.QCData.Sealer.ID = xNode.Attributes["DocUpSign"].Value;
                    
                }
                qc.QCData.Creater.ID = xNode.Attributes["DocSign"].Value;
                qc.QCData.Creater.Name = xNode.Attributes["DocSign"].Value;
                qc.QCData.Creater.Memo = xNode.Attributes["Date"].Value;
                qc.Index = xNode.Attributes["Date"].Value;
                al.Add(qc);
            }
            return al;
            
        }

        #endregion

        #region IControlPrintable 成员

        public Control PrintControl()
        {
            Neusoft.FrameWork.EPRControl.emrMultiLineTextBox c = new Neusoft.FrameWork.EPRControl.emrMultiLineTextBox();
            c.Width = this.Width;
            c.Height = this.Height;
            c.Rtf = this.emrMultiLineTextBox1.Rtf;
            return c;
        }

      
        #endregion
    }
}

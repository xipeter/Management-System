using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Text;

namespace Neusoft.HISFC.Models.EPR
{
    /// <summary>
    /// 首先续打
    /// </summary>
    /// 
    [System.Serializable]
    public class EPRPrintPage:Neusoft.FrameWork.Models.NeuObject
    {
        /// <summary>
        /// 打印图片
        /// </summary>
        private Image img;

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
        private Neusoft.HISFC.Models.Base.PageSize myPageSize;

        public Neusoft.HISFC.Models.Base.PageSize pageSize
        {
            get { return myPageSize; }
            set { myPageSize = value; }
        }
        /// <summary>
        /// 打印页
        /// </summary>
        private int myPage;

        public int Page
        {
            get { return myPage; }
            set { myPage = value; }
        }
        //private string myCheckPrints;
        /// <summary>
        /// 文件名称
        /// </summary>
        private string myFileName;

        public string FileName
        {
            get { return myFileName; }
            set { myFileName = value; }
        }
        /// <summary>
        /// 打印控件，包括Row，CheckPrint，和
        /// </summary>
        private ArrayList mySortedControls;

        /// <summary>
        /// 打印控件，包括Row，CheckPrint，和打印控件
        /// </summary>
        public ArrayList SortedControls
        {
            get { return mySortedControls; }
            set { mySortedControls = value; }
        }
        public string SortedControlsXml
        {
            get
            {
                Neusoft.FrameWork.Xml.XML xml = new Neusoft.FrameWork.Xml.XML();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                System.Xml.XmlElement root = xml.CreateRootElement(doc, "Controls");
                string strInnerXml = "";
                foreach (SortedControl ctr in this.SortedControls)
                {
                    strInnerXml += ctr.xmlNode.OuterXml;
                }
                root.InnerXml = strInnerXml;
                return doc.OuterXml;
            }
            set
            {
                this.SortedControls = new ArrayList();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(value);
                System.Xml.XmlElement root = doc.DocumentElement;
                foreach (System.Xml.XmlNode node in root.ChildNodes)
                {
                    SortedControl ctr = new SortedControl((System.Xml.XmlElement)node);
                    this.SortedControls.Add(ctr);
                }
            }
        }

        /// <summary>
        /// 开始日期
        /// 为写页眉转科、转床准备
        /// </summary>
        private DateTime myBeginDate;

        /// <summary>
        /// 开始日期
        /// 为写页眉转科、转床准备
        /// </summary>
        public DateTime BeginDate
        {
            get { return myBeginDate; }
            set { myBeginDate = value; }
        }

        /// <summary>
        /// 结束日期
        /// 为写页眉转科、转床信息准备
        /// </summary>
        private DateTime myEndDate;

        /// <summary>
        /// 结束日期
        /// 为写页眉转科、转床信息准备
        /// </summary>
        public DateTime EndDate
        {
            get { return myEndDate; }
            set { myEndDate = value; }
        }

        /// <summary>
        /// 患者住院号
        /// </summary>
        private string MyPatientNo;

        /// <summary>
        /// 患者住院号
        /// </summary>
        public string PatientNo
        {
            get { return MyPatientNo; }
            set { MyPatientNo = value; }
        }

        /// <summary>
        /// 起始行
        /// </summary>
        private int myStartRow;

        /// <summary>
        /// 起始行
        /// </summary>
        public int StartRow
        {
            get { return myStartRow; }
            set { myStartRow = value; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace Neusoft.HISFC.Models.EPR
{
    [System.Serializable]
    public class SortedControl:Neusoft.FrameWork.Models.NeuObject
    {
        public SortedControl(XmlElement node)
        {
            this.xmlNode = node;
            //this.SetControl(node);
        }
        public SortedControl()
        {
        }

        private int page;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }
        //private Point location;

        //public Point Location
        //{
        //    get { return location; }
        //    set { location = value; }
        //}
        private Rectangle rect;

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }
        //private Control ctr;

        //public Control Control
        //{
        //    get { return ctr; }
        //    set { ctr = value; }
        //}
        private Point location;
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                this.location = value;
            }
        }

        /// <summary>
        /// RichTextBox
        /// </summary>
        private int startpos;

        public int StartPosition
        {
            get { return startpos; }
            set { startpos = value; }
        }
        private int endpos;

        public int EndPosition
        {
            get { return endpos; }
            set { endpos = value; }
        }
        public XmlElement xmlNode
        {
            get
            {
                Neusoft.FrameWork.Xml.XML xml = new Neusoft.FrameWork.Xml.XML();
                XmlDocument doc = new XmlDocument();
                XmlElement root = xml.CreateRootElement(doc, "Control");
                xml.AddNodeAttibute(root, "ControlLocation", this.location.X.ToString() + "," + this.location.Y.ToString());
                xml.AddNodeAttibute(root, "Rectangle", this.rect.X.ToString() + "," + this.rect.Y.ToString() + "," + this.rect.Width.ToString() + "," + this.rect.Height.ToString());
                xml.AddNodeAttibute(root, "StartPosition", this.startpos.ToString());
                xml.AddNodeAttibute(root, "EndPosition", this.endpos.ToString());
                xml.AddNodeAttibute(root, "Page", this.page.ToString());
                xml.AddNodeAttibute(root, "Name", this.Name);
                return root;
            }
            set
            {
            this.page = int.Parse(value.Attributes["Page"].Value);
            string[] strLocation = value.Attributes["ControlLocation"].Value.Split(',');
            Location = new Point(int.Parse(strLocation[0]), int.Parse(strLocation[1]));
            string[] strRect = value.Attributes["Rectangle"].Value.Split(',');
            rect = new Rectangle(int.Parse(strRect[0]), int.Parse(strRect[1]), int.Parse(strRect[2]), int.Parse(strRect[3]));
            startpos = int.Parse(value.Attributes["StartPosition"].Value);
            endpos = int.Parse(value.Attributes["EndPosition"].Value);
            }
        }

        //public override string ToString()
        //{
        //    Neusoft.NFC.Xml.XML xml = new Neusoft.NFC.Xml.XML();
        //    XmlDocument doc = new XmlDocument();
        //    XmlElement root = xml.CreateRootElement(doc, "Control");
        //    xml.AddNodeAttibute(root, "ControlLocation", this.ctr.Left.ToString() + "," + this.ctr.Top.ToString());
        //    xml.AddNodeAttibute(root, "Rectangle", this.rect.X.ToString() + "," + this.rect.Y.ToString() + "," + this.rect.Width.ToString() + "," + this.rect.Height.ToString());
        //    xml.AddNodeAttibute(root, "StartPosition", this.startpos.ToString());
        //    xml.AddNodeAttibute(root, "EndPosition", this.endpos.ToString());
        //    xml.AddNodeAttibute(root, "Page", this.page.ToString());
        //    return root.OuterXml;
        //}
        //public void SetControl(XmlElement node)
        //{
        //    this.page = int.Parse(node.Attributes["Page"].Value);
        //    string[] strLocation = node.Attributes["ControlLocation"].Value.Split(',');
        //    this.ctr = new Control();
        //    ctr.Location = new Point(int.Parse(strLocation[0]), int.Parse(strLocation[1]));
        //    string[] strRect = node.Attributes["Rectangle"].Value.Split(',');
        //    rect = new Rectangle(int.Parse(strRect[0]), int.Parse(strRect[1]), int.Parse(strRect[2]), int.Parse(strRect[3]));
        //    startpos = int.Parse(node.Attributes["StartPosition"].Value);
        //    endpos = int.Parse(node.Attributes["EndPosition"].Value);
        //}

    }
}

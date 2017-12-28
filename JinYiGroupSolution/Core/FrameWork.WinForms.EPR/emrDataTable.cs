using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
namespace Neusoft.FrameWork.EPRControl
{
    [System.Drawing.ToolboxBitmap(typeof(FarPoint.Win.Spread.SpreadView))]
    public partial class emrDataTable:FarPoint.Win.Spread.FpSpread,IGroup
    {
        public emrDataTable()
        {
            try
            {
                this.Sheets[0].SerializeModels = true;
            }
            catch { }
        }

	    private string mytext;
	    
        [CategoryAttribute("设计"), Browsable(false), DescriptionAttribute("结点信息的文本，包括表里面的数据结构。")]
	    public override string Text 
        {
		    get {

                return GetXML();
            }
            //set {
            //    //mytext = value; 
            //}
	    }


        protected string GetXML()
        {
            if (this.Sheets.Count <= 0) return "";
            try
            {
                FarPoint.Win.Spread.SheetView sheet = this.Sheets[0];

                DataTable dt = new DataTable(this.名称);
                foreach (FarPoint.Win.Spread.Column column in sheet.Columns)
                {
                    dt.Columns.Add(column.Label, typeof(System.String));
                }

                for (int i = 0; i < sheet.RowCount; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 0; j < sheet.ColumnCount; j++)
                    {
                        row[j] = sheet.Cells[i, j].Value;
                    }
                    dt.Rows.Add(row);
                }

                string fileName = "temp.xml";
                dt.WriteXml(fileName);
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(fileName);
                return doc.OuterXml;
            }
            catch
            {
                return "";
            }

        }


        #region IGroup 成员

        public event NameChangedEventHandler NameChanged;

        public event IsGroupChangedEventHandler IsGroupChanged;

        public event GroupChangedEventHandler GroupChanged;
        private string ControlName;
        private string GroupName;
        private bool blnIsGroup;
        private System.EventArgs e;
        [CategoryAttribute("设计"), Browsable(true), DescriptionAttribute("设置控件名称，也是结点名称，不能包含'空格，\\,-,(,),,.%等特殊字符'")]
        public string 名称
        {
            get
            {
                if (this.ControlName == "")
                {
                    this.ControlName = this.Name;
                }
                return this.ControlName;
            }
            set
            {
                if (Module.ValidName(value) == false) return;

                ControlName = value.Trim();
                try
                {
                    if (NameChanged != null)
                    {
                        NameChanged(this, e);
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        [TypeConverter(typeof(emrGroup)), CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("选择控件所在组")]
        public string 组
        {
            get { return this.GroupName; }
            set
            {
                this.GroupName = value;
                try
                {
                    if (GroupChanged != null)
                    {
                        GroupChanged(this, e);
                    }
                }

                catch (Exception ex)
                {

                }
            }
        }
        private bool bIsGroup;

        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("是否是根结点!"), Browsable(false)]
        public bool 是否组
        {
            get { return this.bIsGroup; }
            set
            {
                this.bIsGroup = value;
                try
                {
                    if (IsGroupChanged != null)
                    {
                        IsGroupChanged(this, e);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        #endregion

        #region Snomed 成员

        string snomed = "";
        [CategoryAttribute("设计"), DefaultValueAttribute(""), DescriptionAttribute("Snomed编码")]
        public string Snomed
        {
            get
            {
                return snomed;
            }
            set
            {
                snomed = value;

            }
        }

        #endregion
    }

}

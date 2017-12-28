using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
namespace Neusoft.HISFC.Components.EPR.Controls
{ 
    /// <summary>
    /// [功能描述: 病程记录控件]<br></br>
    /// [创 建 者: zgx]<br></br>
    /// [创建时间: 2007-9-20></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// 
    /// </summary>
    internal partial class ucDiseaseInput : UserControl
    {
        public ucDiseaseInput()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 传参构造函数
        /// </summary>
        /// <param name="MainProperty">主窗口XmlStr属性</param>
        public ucDiseaseInput(string MainProperty,Font ftemp)
        {
            this.PropertyIndex = MainProperty;
            f = ftemp;
            InitializeComponent();
          
        }

        #region  变量
        string PropertyIndex = "";
        Font f = null;
        FarsiLibrary.Win.FATabStripItem item;//添加容器对象
        ucDiseaseInputOne controlOne;//添加实例对象
        public string datetimerChangerTempStr = "";
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
        public ArrayList alStore = new ArrayList();//存储item对象
        ArrayList ssal = new ArrayList();//存储NeuObj对象
        
        //0,2-副主任，主任。1-主治
        //bool tr = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetMedicalPermission(Neusoft.HISFC.Models.EPR.EnumPermissionType.Medical, 0);
        #region xml Operation

        XmlDocument xmlDoc = null;
        XmlNode xmlN = null;
        
        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 返回数据中最大值
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int ebullition(int[] t)
        {          
            int a;
            for (int i = 0; i < t.Length - 1; i++)
            {

                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[i] < t[j])
                    {
                        a = t[i];
                        t[i] = t[j];
                        t[j] = a;
                    }
                }
            }
            return t[0];        

        }
        /// <summary>
        /// 添加方法
        /// </summary>
        public void AddNew()
        {
            int a = ht.Count;
            ArrayList tempal = new ArrayList();
            int[] temparray = new int[a];
            int countindex = 0;
            foreach (FarsiLibrary.Win.FATabStripItem ft in this.TabControl1.Items)
            {
                temparray[countindex] = Neusoft.FrameWork.Function.NConvert.ToInt32(ft.Title.Substring(ft.Title.LastIndexOf('(') + 1).Replace(')', ' '));
                countindex++;
            }
            item = new FarsiLibrary.Win.FATabStripItem();
            int lastNumber = 0;
            if (temparray.Length > 0)
            {
                lastNumber = ebullition(temparray);
                item.Title = System.DateTime.Today.Date.ToString("yyyy-MM-dd") + "(" + Neusoft.FrameWork.Function.NConvert.ToInt32(lastNumber + 1) + ")";
            }
            else
            {
                item.Title = System.DateTime.Today.Date.ToString("yyyy-MM-dd") + "(" + lastNumber + ")";
            }
            
            #region  初始化COMBOX

            ht.Add(Neusoft.FrameWork.Function.NConvert.ToInt32(item.Title.Substring(item.Title.LastIndexOf('(') + 1).Replace(')', ' ')), item);
            
            this.cmdDiseaseSelect.Items.Add(item .Title );         

            #endregion

            controlOne = new ucDiseaseInputOne();
            controlOne.DateTimePickerChange += new ucDiseaseInputOne.DateTimePickerChanged(control_DateTimePickerChange);
            controlOne.Size = new Size(569, 480);
            Container tempC = new Container();
            foreach (Control t in controlOne.Controls)
            {
                string str = t.GetType().Name;
               
                if (t.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox))
                {
                    t.Font = f;
                    //if (tr)//false副主任，主任。true主治
                    //{
                    //    ((Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)t).IsShowModify = false;
                    //}
                    //else 
                    //{
                    //    ((Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)t).IsShowModify = true;
                    //}
                }
               if (t.GetType() != typeof(Label))
                {
                    tempC.Add(t);
                }
            }
            this.ucUserText1.SetControl(tempC);//设置组套

            item.Controls.Add(controlOne);
            item.Tag = controlOne;

            this.TabControl1.AddTab(item);            
            this.TabControl1.AlwaysShowClose = false;
            this.TabControl1.Refresh();
            this.TabControl1.SelectedItem = item;
        
        }

       

        /// <summary>
        /// 获得属性XML
        /// </summary>
        public string  GetXml()
        {   
            ArrayList al = getAllList();
            if (al == null) return "" ;
            ssal = new ArrayList();
            for (int i = 0; i < al.Count; i++)
            {
                FarsiLibrary.Win.FATabStripItem ftm = al[i] as FarsiLibrary.Win.FATabStripItem;
                if (ftm != null)
                {
                    //创建元素
                    XmlElement xmlEl = xmlDoc.CreateElement("PatientInfo");
                    xmlEl.SetAttribute("Title", ftm.Title);
                    XmlCDataSection xmlCData = null;
                    foreach (Control uc in ftm.Controls)
                    {
                        if (uc.GetType() == typeof(ucDiseaseInputOne))
                        {
                            string tempStr = "";//用于判断CDATA里数据是否为空，如果为空，则不写XML中
                            foreach (Control c in uc.Controls)
                            {

                                int a = Neusoft.FrameWork.Function.NConvert.ToInt32(c.Tag);
                                if (a == 1)
                                {
                                    xmlEl.SetAttribute("Date", ((DateTimePicker)c).Text);//添加元素-日期
                                }
                                else if (a == 2)
                                {
                                    xmlEl.SetAttribute("DocUpName", ((TextBox)c).Text);//添加元素-上级医生类别名称
                                }
                                else if (a == 3)
                                {
                                    xmlEl.SetAttribute("DocUpType", ((ComboBox)c).Text);//添加元素-上级医生类别
                                }
                                else if (a == 4)
                                {
                                    xmlCData = xmlDoc.CreateCDataSection(((RichTextBox)c).Rtf);//添加RTF格式到CDATA
                                    tempStr = ((RichTextBox)c).Text;
                                }
                                else if (a == 5)
                                {
                                    xmlEl.SetAttribute("DocSign", ((TextBox)c).Text);//添加元素-医生签名
                                }
                                else if (a == 6)
                                {
                                    xmlEl.SetAttribute("DocUpSign", ((TextBox)c).Text);//添加元素-上级医生签名
                                }
                            }
                            xmlEl.SetAttribute("IsUpSubMission", ((ucDiseaseInputOne)uc).IsUpSubmission);
                            xmlEl.SetAttribute("IsUpDocSign", ((ucDiseaseInputOne)uc).IsUpDocSign);
                            if (tempStr != "")
                            {
                                xmlEl.AppendChild(xmlCData);
                                xmlN.AppendChild(xmlEl);

                            }
                        }
                    }
                }
            }
            xmlDoc.AppendChild(xmlN);
            return xmlDoc.OuterXml;
        }

        void control_DateTimePickerChange(string str)
        {
            
            item.Title =str+item.Title.Substring(item.Title.IndexOf('('));

            this.cmdDiseaseSelect.Items.Clear();
            foreach (FarsiLibrary.Win.FATabStripItem f in this.TabControl1.Items)
            {
                this.cmdDiseaseSelect.Items.Add(f.Title);
            }
            this.cmdDiseaseSelect.Text = item.Title;

          

        }

        /// <summary>
        /// 初始化UC窗体(from xml)
        /// </summary>
        private void initialUC()
        { 
             if(File .Exists (Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.TempPath + @"\EprDisease.xml"))
              {
                 XmlDocument dt = new XmlDocument();
                 StreamReader sr = File.OpenText(Neusoft.FrameWork.WinForms.Classes.Function.CurrentPath + Neusoft.FrameWork.WinForms.Classes.Function.TempPath + @"\EprDisease.xml");
                 
                string str=sr.ReadToEnd();
                sr.Close();
                if (str =="") return;
                try
                {
                    dt.LoadXml(str);
                    
                }catch (Exception em){MessageBox.Show (em.Message );}
                 
                 XmlNodeList nodeList=dt.SelectNodes (@"//病程记录//PatientInfo");
                 ht.Clear();
                 Container tempC = new Container();
                 foreach (XmlNode xNode in nodeList )
                 {
                  FarsiLibrary.Win .FATabStripItem ft =new FarsiLibrary.Win.FATabStripItem ();                  
                  ucDiseaseInputOne contrOne = new ucDiseaseInputOne();
                  contrOne.DateTimePickerChange += new ucDiseaseInputOne.DateTimePickerChanged(control_DateTimePickerChange);
                  contrOne.Size = new Size(569, 480);
                  ft.Title = xNode.Attributes ["Title"].Value;                 
                 
                 
                  ft.Controls.Add(contrOne);
                  this.TabControl1.AddTab(ft);
                  
                  #region  给各控件赋值
                  foreach (Control  c in contrOne .Controls)
                    {
                        int a = Neusoft.FrameWork.Function.NConvert.ToInt32(c.Tag);
                      if (c.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox))
                      {
                          c.Font = f;
                          tempC.Add(c);
                      }
                                if (a ==1) 
                                {
                                   ((DateTimePicker)c).Text =xNode.Attributes ["Date"].Value ;
                                }
                                else if (a == 2)
                                {
                                   ((TextBox)c).Text=xNode.Attributes["DocUpName"].Value ;
                                }
                                else if (a == 3)
                                {
                                 ((ComboBox )c).Text=xNode.Attributes["DocUpType"].Value ;
                                }
                                else if (a == 4)
                                {
                                    //if (tr)//false副主任，主任。true主治
                                    //{
                                    //    ((Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)c).IsShowModify = false ;
                                    //}
                                    //else
                                    //{
                                    //    ((Neusoft.FrameWork.EPRControl.emrMultiLineTextBox)c).IsShowModify = true ;
                                    //}
                                  ((RichTextBox)c).Rtf=xNode .InnerText ;
                                }
                                else if (a == 5)
                                {
                                    ((TextBox)c).Text=xNode.Attributes["DocSign"].Value ;
                                }
                                else if (a == 6)
                                {
                                    ((TextBox)c).Text=xNode.Attributes ["DocUpSign"].Value ;
                                }
                    }
                
                  #endregion

                    //if (tr)
                    //{
                    //    if (xNode.Attributes["IsUpSubMission"].Value == "1")
                    //    {
                    //        contrOne.Enabled = false;
                    //    }
                    //}
                    contrOne.IsUpDocSign = xNode.Attributes["IsUpDocSign"].Value;
                    contrOne.IsUpSubmission = xNode.Attributes["IsUpSubMission"].Value;

                    int tmpName = Neusoft.FrameWork.Function.NConvert.ToInt32(ft.Title.LastIndexOf ('('));
                    string tt = ft.Title.Substring(tmpName + 1).Replace(')', ' ');
                    ht.Add(Neusoft.FrameWork.Function.NConvert.ToInt32(tt), ft);
                 }

                 this.ucUserText1.SetControl(tempC);
                 this.TabControl1.AlwaysShowClose = false;
                 this.TabControl1.Refresh();
                
             }
        }


        /// <summary>
        /// 获得HASHTABLE中所有的对象
        /// </summary>
        /// <returns></returns>
        public  ArrayList getAllList()
        {
            alStore.Clear();//清了，不欠你钱了
            foreach (Object o in ht.Keys )
            { 
                alStore.Add(ht[o]);
            }
            alStore.Reverse();
            return alStore;
        }
        /// <summary>
        /// 从ArrayList中获得对象并传出到FRMDiseaseInput窗体
        /// </summary>
        /// <returns></returns>
        public ArrayList getObjFromList()
        {
            ArrayList al = getAllList();
            if (al == null) return null;
            ssal = new ArrayList();
            for (int i = 0; i < al.Count; i++)
            {
                FarsiLibrary.Win.FATabStripItem ftm = al[i] as FarsiLibrary.Win.FATabStripItem;
                if (ftm != null)
                {
                    foreach (Control uc in ftm.Controls)
                    {
                        if (uc.GetType() == typeof(ucDiseaseInputOne))
                        {
                            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                            string tempStr = "";//如果RTF为空。则不加到ARRAYLIST中
                            foreach (Control c in uc.Controls)
                            {

                                int a = Neusoft.FrameWork.Function.NConvert.ToInt32(c.Tag);
                                if (a == 1)
                                {
                                    obj.ID = ((DateTimePicker)c).Text;
                                }
                                else if (a == 2)
                                {
                                    obj.Name = ((TextBox)c).Text;
                                }
                                else if (a == 3)
                                {
                                    obj.Memo = ((ComboBox)c).Text;
                                }
                                else if (a == 4)
                                {
                                    obj.User01 = ((RichTextBox)c).Rtf;
                                    tempStr = ((RichTextBox)c).Text;
                                }
                                else if (a == 5)
                                {
                                    obj.User02 = ((TextBox)c).Text;
                                }
                                else if (a == 6)
                                {
                                    obj.User03 = ((TextBox)c).Text;
                                }
                            }
                            if (tempStr != "")
                            {
                                ssal.Add(obj);
                            }
                        }
                    }
                }
            }
                return ssal;
            }

        #endregion


        #region 事件

        #region 上下标

        private void setControl(int index, RichTextBox c)
        {
            switch (index)
            {
                case 0: c.SelectionCharOffset = 4;
                    c.SelectionFont = new Font(c.SelectionFont.FontFamily.Name,7, c.SelectionFont.Style);
                    break;
                case 1: c.SelectionCharOffset = 0;
                    c.SelectionFont = new Font(c.SelectionFont.FontFamily.Name, 9, c.SelectionFont.Style);
                    break;
                case 2: c.SelectionCharOffset = -4;
                    c.SelectionFont = new Font(c.SelectionFont.FontFamily.Name, 7, c.SelectionFont.Style);
                    break;
                default: break;
            }
        }

        private void comTopBottomIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TabControl1.Items.Count == 0) return;
            
            foreach (Control temp in this.TabControl1.SelectedItem.Controls[0].Controls)
            { 
                bool isLock;
                if (temp.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox))
                {
                    isLock = ((RichTextBox)temp).SelectionProtected;
                    ((RichTextBox)temp).SelectionProtected = false;
                    setControl(this.comTopBottomIndex.SelectedIndex, temp as RichTextBox);
                    ((RichTextBox)temp).SelectionProtected = isLock;
                }
              
            }
        }
     
        #endregion

        #region 设置字体
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.TabControl1.Items.Count == 0) return;
            foreach (Control t in this.TabControl1.SelectedItem.Controls[0].Controls)
            {
                bool isLock;//临时
                if (t.GetType() == typeof(Neusoft.FrameWork.EPRControl.emrMultiLineTextBox))
                {
                    if (this.fontDialog1.ShowDialog() == DialogResult.OK)
                    {
                        isLock = ((RichTextBox)t).SelectionProtected;
                        ((RichTextBox)t).SelectionProtected = false;
                        ((RichTextBox)t).SelectionFont = this.fontDialog1.Font;
                        ((RichTextBox)t).SelectionProtected = isLock;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 添加病程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.AddNew();//添加页面
        }

        /// <summary>
        /// UCLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDiseaseInput_Load(object sender, EventArgs e)
        {
            if (this.PropertyIndex != null)
            {
                initialUC();//如果属性有值则初始化UC
                
            }
            #region 新建立XML

            //新建XML
            xmlDoc = new XmlDocument();
            //添写文件头信息
            //xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0",, ""));
            //建结点吧
            xmlN = xmlDoc.CreateElement("病程记录", "");
            #endregion

        }

  

        /// <summary>
        /// 选择病程comBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comDiseaseSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TabControl1.Items.Count == 0) return;         
            int a = this.cmdDiseaseSelect.Text.LastIndexOf('(');
            this.TabControl1.SelectedItem = ht[Neusoft.FrameWork.Function.NConvert.ToInt32(this.cmdDiseaseSelect.Text.Substring(a + 1).Replace(')', ' '))] as FarsiLibrary.Win.FATabStripItem;
        }

        /// <summary>
        /// TabStripItemSelectionChanged
        /// </summary>
        /// <param name="e"></param>
        private void TabControl1_TabStripItemSelectionChanged_1(FarsiLibrary.Win.TabStripItemChangedEventArgs e)
        {            
            if (this.TabControl1.Items.Count == 0) return;
            this.cmdDiseaseSelect.Text  = e.Item.Title;
            
            item = e.Item;
            this.button2.Enabled = !Neusoft.FrameWork.Function.NConvert.ToBoolean(((ucDiseaseInputOne)e.Item.Controls[0]).IsUpSubmission);
            this.button3.Enabled = !Neusoft.FrameWork.Function.NConvert.ToBoolean(((ucDiseaseInputOne)e.Item.Controls[0]).IsUpDocSign);
        }


        private void TabControl1_TabStripItemClosing(FarsiLibrary.Win.TabStripItemClosingEventArgs e)
        {
            e.Cancel = true;
        }


        /// <summary>
        /// 提交病程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>       
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("提交的病程记录主治医生不能修改，只有上级医生可以修改！" + "\r\n" + "  是否提交？？？", "提示！！", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Control c in item.Controls )
                {
                    if (c.GetType() == typeof(ucDiseaseInputOne))
                    {
                        ((ucDiseaseInputOne)c).IsUpSubmission = "1";//医生签名
                    }
                }
            }
         
        }
        /// <summary>
        /// 上级医生签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("上级医师签名！" + "\r\n" + "  是否签名？？？", "提示！！", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Control c in item.Controls)
                {
                    if (c.GetType() == typeof(ucDiseaseInputOne))
                    {
                        ((ucDiseaseInputOne)c).IsUpDocSign = "1";
                        foreach (Control tempUc in c.Controls)
                        {
                            int a = Neusoft.FrameWork.Function.NConvert.ToInt32(tempUc.Tag);
                            if (a == 6)
                            {
                                if (((TextBox)tempUc).Enabled&&((TextBox )tempUc ).Text.Trim () =="")
                                    ((TextBox)tempUc).Text = Neusoft.FrameWork.Management.Connection.Operator.Name;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0)//
            {
                this.cmdDiseaseSelect .Items.Clear();
                foreach (FarsiLibrary.Win.FATabStripItem ft in this.TabControl1.Items)
                {
                    foreach (Control c in ft.Controls)
                    {
                        if (c.GetType() == typeof(ucDiseaseInputOne))
                        {
                            if (((ucDiseaseInputOne)c).IsUpSubmission == "0")
                            {
                                this.cmdDiseaseSelect.Items.Add(ft.Title);
                            }
                        }
                      
                    }
                }
            }
            if (this.comboBox2.SelectedIndex == 1)
            {
                this.cmdDiseaseSelect.Items.Clear();
                foreach (FarsiLibrary.Win.FATabStripItem it in this.TabControl1.Items)
                {
                    string upText = "";
                    foreach (Control t in it.Controls)
                    {
                        if (t.GetType() == typeof(ucDiseaseInputOne))
                        {
                            foreach (Control c in t.Controls)
                            {
                                if (Neusoft.FrameWork.Function.NConvert.ToInt32(c.Tag) == 6)
                                {
                                    upText = ((TextBox)c).Text;                                
                                }                           
                            }
                        }
                        if(upText =="")
                        {
                            this.cmdDiseaseSelect .Items.Add(it.Title);
                        }
                    }                   
                }            
            }
            if (this.comboBox2.SelectedIndex == 2)
            {
                this.cmdDiseaseSelect.Items.Clear();
                foreach (FarsiLibrary.Win.FATabStripItem it in this.TabControl1.Items)
                {
                    this.cmdDiseaseSelect.Items.Add(it.Title); 
                }
            }
        }
    }
}

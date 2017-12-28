using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.WinForms.WorkStation
{
    public partial class frmWorkStation : Neusoft.FrameWork.WinForms.Forms.BaseStatusBar
    {
        public frmWorkStation()
        {
            InitializeComponent();
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载...");
            Application.DoEvents();

            string xml = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.GetSetting( "0" );
            if (xml == "" || xml == "-1")
                this.ReadConfig(this.GetDefaultXML());
            else
                this.ReadConfig(xml);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            IsShowToolbar = false;

            try
            {

                if (((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).IsManager)
                {
                    this.lblShowToolbar.Visible = true;
                }
                else
                {
                    this.lblShowToolbar.Visible = false;
                }
            }
            catch { }
        }

        private void faTabStripItem1_Changed(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 双击选择患者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmWorkStation_DoubleClick(object sender, EventArgs e)
        {
            //双击选择患者
            Object obj = ((TreeView)sender).SelectedNode.Tag;
            if (obj == null) return;
            foreach (Neusoft.FrameWork.WinForms.Controls.ucBaseControl uc in alControls)
            {
                uc.SetValue(obj, ((TreeView)sender).SelectedNode);
            }
        }
        
        #region 配置

        private string GetDefaultXML()
        {
            frmWorkStationSet form = new frmWorkStationSet();
            return form.xml;
         }
        private void btnSet_Click(object sender, EventArgs e)
        {
            frmWorkStationSet form = new frmWorkStationSet();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.ReadConfig(form.xml);
            }
        }

        public virtual int SaveConfig()
        {
            return 0;
        }

        public virtual int ReadConfig(string xml)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch { return -1; }
            
            this.readLeft(doc.SelectSingleNode("//LEFT"));

            this.readRight(doc.SelectSingleNode("//RIGHT"));

            return 0;
        }
        List<Neusoft.FrameWork.WinForms.Controls.ucBaseControl> alControls = null;
        protected void readLeft(System.Xml.XmlNode nodeLeft)
        {
            if (nodeLeft == null)
            {
                this.navigateBar1.Visible = false;
                return;
            }
            else
                this.navigateBar1.Visible = true;


            this.navigateBar1.NavigateBarButtons.Clear();

            try
            {
                foreach (System.Xml.XmlNode node in nodeLeft.ChildNodes)
                {
                    MT.WindowsUI.NavigationPane.NavigateBarButton button = new MT.WindowsUI.NavigationPane.NavigateBarButton();
                    button.Caption = node.Attributes["NAME"].Value;
                    button.ToolTipText = node.Attributes["MEMO"].Value;
                    button.IsShowCaption = false;
                    Control c = null;


                    c = Neusoft.FrameWork.WinForms.Classes.Function.CreateControl(node.Attributes["DLLNAME"].Value, node.Attributes["CONTROLNAME"].Value);
                    c.Visible = true;

                    if (c.GetType().IsSubclassOf(typeof(TreeView)))
                    {
                        ((TreeView)c).DoubleClick += new EventHandler(frmWorkStation_DoubleClick);
                    }

                    button.RelatedControl = c;

                    this.navigateBar1.NavigateBarButtons.Add(button);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            this.navigateBar1.DisplayedButtonCount = nodeLeft.ChildNodes.Count;
        }

       
        
        protected void readRight(System.Xml.XmlNode nodeRight)
        {
            this.panelMain1.Controls.Clear();

            this.panelMain2.Controls.Clear();

            container1.Panel1.Controls.Clear();
            container2.Panel1.Controls.Clear();
            container1.Panel2.Controls.Clear();
            container2.Panel2.Controls.Clear();

            alControls = new List<Neusoft.FrameWork.WinForms.Controls.ucBaseControl>();
            try
            {
                foreach (System.Xml.XmlNode node in nodeRight.ChildNodes)
                {
                    Neusoft.FrameWork.WinForms.Controls.AutoDockControl button = new Neusoft.FrameWork.WinForms.Controls.AutoDockControl();
                    button.Title = node.Attributes["NAME"].Value;
                    Control c = Neusoft.FrameWork.WinForms.Classes.Function.CreateControl(node.Attributes["DLLNAME"].Value, node.Attributes["CONTROLNAME"].Value);
                    c.Visible = true;
                    button.Dock = DockStyle.Fill;
                    button.RelateControl = c;
                    try
                    {
                        button.TitleColor = Color.FromArgb(int.Parse(node.Attributes["TITLECOLOR"].Value));
                    }
                    catch { }
                    try
                    {
                        c.BackColor = Color.FromArgb(int.Parse(node.Attributes["BACKCOLOR"].Value));
                    }
                    catch { }

                    Neusoft.FrameWork.WinForms.Controls.ucBaseControl ucbase = c as Neusoft.FrameWork.WinForms.Controls.ucBaseControl;
                    if (ucbase != null)
                        alControls.Add(ucbase);

                    //设置控件属性
                    System.Collections.ArrayList alProperty = new System.Collections.ArrayList();
                    foreach (System.Xml.XmlNode nodeProperty in node.ChildNodes)
                    {
                        alProperty.Add(new Neusoft.FrameWork.Models.NeuObject(nodeProperty.Attributes[0].Value, nodeProperty.InnerText, ""));
                    }

                    Neusoft.FrameWork.WinForms.Classes.Function.SetPropertyToControl(ucbase, alProperty);

                    button.IsCanMove = Neusoft.FrameWork.Function.NConvert.ToBoolean(node.Attributes["ISALLOWMOVE"].Value);
                    if (button.Title.Trim() == "")
                    {
                        this.AddPanel(node, ucbase);
                    }
                    else
                    {
                        this.AddPanel(node, button);
                    }
                    //this.faTabStripItem1.Controls.Add(button);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        SplitContainer container1 = new SplitContainer();
        SplitContainer container2 = new SplitContainer();
        private void AddPanel(System.Xml.XmlNode node, Control current)
        {
            this.panelMain1.Visible = true;
            this.panelMain2.Visible = true;
            switch (node.Attributes["PARENT"].Value)
            {
                case "MAINTOP":
                    this.panelMain1.Controls.Add(current);
                    break;
                case "MAINTOP.LEFT":

                    container1.Panel1.Controls.Add(current);
                    container1.Dock = DockStyle.Fill;
                    this.panelMain1.Controls.Add(container1);
                    break;
                case "MAINTOP.RIGHT":
                    container1.Panel2.Controls.Add(current);
                    container1.Dock = DockStyle.Fill;
                    this.panelMain1.Controls.Add(container1);
                    break;
                case "MAINBOTTOM":
                    this.panelMain2.Controls.Add(current);
                    break;
                case "MAINBOTTOM.LEFT":
                    container2.Panel1.Controls.Add(current);
                    container2.Dock = DockStyle.Fill;
                    this.panelMain2.Controls.Add(container2);
                    break;
                case "MAINBOTTOM.RIGHT":
                    container2.Panel2.Controls.Add(current);
                    container2.Dock = DockStyle.Fill;
                    this.panelMain2.Controls.Add(container2);
                    break;
                case "MAIN":
                    this.panelMain1.Controls.Add(current);
                    this.panelMain1.Dock = DockStyle.Fill;
                    this.panelMain2.Visible = false;
                    this.splitter1.Visible = false;
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void frmWorkStation_Load(object sender, EventArgs e)
        {
            
        }

        private void faTabStrip1_TabStripItemSelectionChanged(FarsiLibrary.Win.TabStripItemChangedEventArgs e)
        {

        }

        private void faTabStrip1_TabStripItemClosing(FarsiLibrary.Win.TabStripItemClosingEventArgs e)
        {
            e.Cancel = true;
        }



        private void lblShowToolbar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IsShowToolbar = !this.isShowToolbar;
        }

        private bool isShowToolbar = false;
        public bool IsShowToolbar
        {
            set
            {
                if (!value)
                {
                    this.lblShowToolbar.Text = "显示";
                    
                }
                else
                {
                    this.lblShowToolbar.Text = "隐藏";
                }
                isShowToolbar = value;
                this.panel2.Visible = value;
            }
        }
    }
}
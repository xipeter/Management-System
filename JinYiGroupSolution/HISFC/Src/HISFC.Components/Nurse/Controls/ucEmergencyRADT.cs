using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Nurse.Controls
{
    /// <summary>
    /// [功能描述: 急诊留观护士站病房管理切换控件]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-10-25]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucEmergencyRADT : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucEmergencyRADT()
        {
            InitializeComponent();

        }

        #region 函数
        protected TreeNode node = null;
        protected Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        Neusoft.FrameWork.WinForms.Forms.ToolBarService tooBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //try
            //{
            //    tv = sender as TreeView;
            //}
            //catch { }
            this.tooBarService.AddToolButton("刷新", "刷新", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
           
            this.neuTabControl1.TabPages.Clear();
            this.neuTabControl1.TabPages.Add(this.tbBedView);//默认显示病床
            ucBedListView uc = new ucBedListView();
            uc.ListViewItemChanged += new ListViewItemSelectionChangedEventHandler(uc_ListViewItemChanged);
            uc.Dock = DockStyle.Fill;
            uc.Visible = true;
            Neusoft.FrameWork.WinForms.Forms.IControlable ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
            if (ic != null)
            {
                ic.Init(this.tv, null, null);
                ic.SetValue(patient, this.tv.Nodes[0]);
                ic.RefreshTree += new EventHandler(ic_RefreshTree);
                ic.SendParamToControl += new Neusoft.FrameWork.WinForms.Forms.SendParamToControlHandle(ic_SendParamToControl);
                ic.StatusBarInfo += new Neusoft.FrameWork.WinForms.Forms.MessageEventHandle(ic_StatusBarInfo);
            
            }
            this.tbBedView.Controls.Add(uc);
            base.OnInit(sender, neuObject, param);
            return tooBarService;
           
        }
        /// <summary>
        /// 获得患者
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {
            string txtNode = "";

            //根据选中的节点层次和类型不同,显示不同的内容
            if (e.Parent == null)
            {
                //一级节点
                txtNode = e.Tag.ToString();
                //显示病区患者一览表
                type = EnumPatientType.Dept;
            }
            else
            {
                //二级(患者)节点
                txtNode = e.Parent.Tag.ToString();

                //根据节点类型的不同,显示不同的内容
                if (txtNode == EnumPatientType.In.ToString())
                {
                    type = EnumPatientType.In;
                }
                else if (txtNode == EnumPatientType.Arrive.ToString())
                {
                    type = EnumPatientType.Arrive;
                }else if (txtNode == EnumPatientType.ShiftIn.ToString())
                {
                    type = EnumPatientType.ShiftIn;
                }else if (txtNode == EnumPatientType.ShiftOut.ToString())
                {
                    type = EnumPatientType.ShiftOut;
                }
                else if (txtNode == EnumPatientType.Out.ToString())
                {
                    type = EnumPatientType.Out;
                }
                //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
                else if (txtNode == EnumPatientType.PreOut.ToString())
                {
                    type = EnumPatientType.PreOut;
                }
                else if (txtNode == EnumPatientType.PreIn.ToString())
                {
                    type = EnumPatientType.PreIn;
                }
                else
                {
                    type = EnumPatientType.In;
                }
                node = e;
                patient = e.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            }

            this.neuTabControl1_SelectedIndexChanged(null, null);
            return base.OnSetValue(neuObject, e);
        }

        private EnumPatientType mytype = EnumPatientType.Dept;
        /// <summary>
        /// 类型
        /// </summary>
        protected EnumPatientType type
        {
            get
            {
                return mytype;
            }
            set
            {
                if (mytype == value) return;
                mytype = value;
                try
                {
                    this.neuTabControl1.TabPages.Clear();
                }
                catch { };
                if (mytype == EnumPatientType.Dept)
                {
                    
                    this.neuTabControl1.TabPages.Add(this.tbBedView);
                }
                else if (mytype == EnumPatientType.In)
                {
                    
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    //this.neuTabControl1.TabPages.Add(this.tpDept);
                   // this.neuTabControl1.TabPages.Add(this.tpChangeDoc);
                   
                    
                }
                else if (mytype == EnumPatientType.Out)
                {
                    
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.neuTabControl1.TabPages.Add(this.tpCallBack);
                    
                }
                else if (mytype == EnumPatientType.Arrive)
                {
                    
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.neuTabControl1.TabPages.Add(this.tpArrive);
                    
                }
                else if (mytype == EnumPatientType.ShiftIn)
                {

                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.neuTabControl1.TabPages.Add(this.tpArrive);
                    
                }
                else if (mytype == EnumPatientType.ShiftOut)
                {
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.neuTabControl1.TabPages.Add(this.tpCancelDept);
                }
                //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
                else if (mytype == EnumPatientType.PreOut)
                {
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.tpOut.Text = "留观出院登记";
                    this.neuTabControl1.TabPages.Add(this.tpOut);
                }
                else if (mytype == EnumPatientType.PreIn)
                {
                    this.neuTabControl1.TabPages.Add(this.tpPatient);
                    this.tpIn.Text = "留观转住院";
                    this.neuTabControl1.TabPages.Add(this.tpIn);
                }
            }
        }

        private void neuTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tabControl Selected Changed
            Neusoft.FrameWork.WinForms.Forms.IControlable ic = null;
            if (this.neuTabControl1.SelectedTab == this.tbBedView)//床位一览
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBedListView uc = new ucBedListView();
                    uc.ListViewItemChanged += new ListViewItemSelectionChangedEventHandler(uc_ListViewItemChanged);
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if(ic!=null)
                    {
                        ic.Init(this.tv,null,null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpArrive)//接珍
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBasePatientArrive uc = new ucBasePatientArrive();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    if (this.node.Parent != null && this.node.Parent.Tag.ToString() == "ShiftIn")
                    {
                        uc.arrivetype = ArriveType.ShiftIn;
                        
                    }
                    else
                    {
                        uc.arrivetype = ArriveType.Regedit;
                        
                    }
                   
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if(ic!=null)
                    {
                        ic.Init(this.tv,null,null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                    
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    ucBasePatientArrive uc = ic as ucBasePatientArrive;
                    if (this.node.Parent != null && this.node.Parent.Tag.ToString() == "ShiftIn")
                    {
                        uc.arrivetype = ArriveType.ShiftIn;

                    }
                    else
                    {
                        uc.arrivetype = ArriveType.Regedit;

                    }
                    
                }
                
            }
            else if (this.neuTabControl1.SelectedTab == this.tpCallBack)//找回
            {
                 if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBasePatientArrive uc = new ucBasePatientArrive();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    uc.arrivetype = ArriveType.CallBack;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if(ic!=null)
                    {
                        ic.Init(this.tv,null,null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpCancelDept)//取消转科
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientShiftOut uc = new ucPatientShiftOut();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    uc.IsCancel = true;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpChangeDoc)//换医生
            {
                 if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBasePatientArrive uc = new ucBasePatientArrive();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    uc.arrivetype = ArriveType.ChangeDoc;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if(ic!=null)
                    {
                        ic.Init(this.tv,null,null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpDept)//换科室
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientShiftOut uc = new ucPatientShiftOut();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    uc.IsCancel = false;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
           
                 
            else if (this.neuTabControl1.SelectedTab == this.tpOut)//出院登记
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientOut uc = new ucPatientOut();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
            else if (this.neuTabControl1.SelectedTab == this.tpIn) //转住院
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientIn uc = new ucPatientIn();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else if (this.neuTabControl1.SelectedTab == this.tpPatient)//患者基本信息
            {

                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientInfo uc = new ucPatientInfo();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add(uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }
            else
            {
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    return;
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
            }

            if (ic != null)
            {
                ic.SetValue(patient, node);
                ic.RefreshTree -= new EventHandler(ic_RefreshTree);
                ic.SendParamToControl -= new Neusoft.FrameWork.WinForms.Forms.SendParamToControlHandle(ic_SendParamToControl);
                ic.StatusBarInfo -= new Neusoft.FrameWork.WinForms.Forms.MessageEventHandle(ic_StatusBarInfo);

                ic.RefreshTree += new EventHandler(ic_RefreshTree);
                ic.SendParamToControl += new Neusoft.FrameWork.WinForms.Forms.SendParamToControlHandle(ic_SendParamToControl);
                ic.StatusBarInfo += new Neusoft.FrameWork.WinForms.Forms.MessageEventHandle(ic_StatusBarInfo);
            
            }
        }

        void uc_ListViewItemChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo myPatientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            myPatientInfo = e.Item.Tag as Neusoft.HISFC.Models.RADT.PatientInfo;
            if (myPatientInfo != null)
            {
                string strBedInfo = myPatientInfo.PVisit.PatientLocation.Bed.ID;
                strBedInfo = strBedInfo.Length > 4 ? strBedInfo.Substring(4) : strBedInfo;
                e.Item.ToolTipText = myPatientInfo.Name + "-【" + strBedInfo + "床】-" + ((EnumBedState)e.Item.ImageIndex).ToString();
                base.OnStatusBarInfo(sender, myPatientInfo.Name + "-【" + strBedInfo + "床】-" + ((EnumBedState)e.Item.ImageIndex).ToString());
            }
            else
            {
                base.OnStatusBarInfo(sender,((EnumBedState)e.Item.ImageIndex).ToString());
            }
        }

        void ic_StatusBarInfo(object sender, string msg)
        {
            this.OnStatusBarInfo(sender, msg);
        }

        void ic_SendParamToControl(object sender, string dllName, string controlName, object objParams)
        {
            this.OnSendParamToControl(sender, dllName, controlName, objParams);
        }

        void ic_SendMessage(object sender, string msg)
        {
            this.OnSendMessage(sender, msg);
        }

        void ic_RefreshTree(object sender, EventArgs e)
        {
            this.OnRefreshTree();
            try
            {
                ucBedListView uc = this.tbBedView.Controls[0] as ucBedListView;
                uc.RefreshView();
            }
            catch { }
        }

        protected override void OnRefreshTree()
        {
           
            ((tvEmergencyPatientList)this.tv).Refresh();
            base.OnRefreshTree();
        }
        #endregion

        #region 共有函数
        /// <summary>
        /// 开放的Tabpage
        /// </summary>
        /// <param name="control"></param>
        /// <param name="title"></param>
        /// <param name="tag"></param>
        public void AddTabpage(Neusoft.FrameWork.WinForms.Controls.ucBaseControl control, string title, object tag)
        {
          
            foreach (TabPage tb in this.neuTabControl1.TabPages)
            {
                if (tb.Text == title)
                {
                    this.neuTabControl1.SelectedTab = tb;
                    return;
                }
            }
            TabPage tp = new TabPage(title);
            this.neuTabControl1.TabPages.Add(tp);
           
            control.Dock = DockStyle.Fill;
            control.Visible = true;
          
            Neusoft.FrameWork.WinForms.Forms.IControlable ic = control as Neusoft.FrameWork.WinForms.Forms.IControlable;
            if (ic != null)
            {
                ic.Init(this.tv, null, null);
            }
            tp.Controls.Add(control);
            if (ic != null)
                ic.SetValue(patient, node);
            this.neuTabControl1.SelectedTab = tp;
        }
        #region 菜单项
       
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "刷新":
                    {
                        ((tvEmergencyPatientList)this.tv).Refresh();

                        break;
                    }
                default:
                    break;
            }
            base.ToolStrip_ItemClicked(sender, e);
        }
        #endregion
        #endregion
        public enum EnumBedState
        {
            空床 = 0,
            男 = 1,
            女 = 2,
            关闭 = 3,
            三级护理 = 4,
            二级护理 = 5,
            一级护理 = 6,
            病危 = 7,
            重症 = 8,
            包床 = 9,
            放假 = 10,
            挂床 = 11,
            无 = 12,
            没有 = 13
        }

        //{1C0814FA-899B-419a-94D1-789CCC2BA8FF}
        public enum EnumPatientType
        {
            In = 0,//在院患者
            Arrive = 1,//待接诊患者
            Out = 2,//出院登记患者
            ShiftIn = 3,//转入患者
            ShiftOut = 4,//转出患者
            Dept = 5, //科室列表
            PreOut = 6,//出关登记
            PreIn = 7,//留观转住院
        }
    }
}

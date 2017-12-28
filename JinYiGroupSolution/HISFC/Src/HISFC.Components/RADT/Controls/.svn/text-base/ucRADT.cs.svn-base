using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.RADT.Controls
{
    /// <summary>
    /// [功能描述: 护士站病房管理切换控件]<br></br>
    /// [创 建 者: wolf]<br></br>
    /// [创建时间: 2006-11-30]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucRADT : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ucRADT()
        {
            InitializeComponent();

        }

        #region 函数
        protected TreeView tv = null;
        protected TreeNode node = null;
        protected Neusoft.HISFC.Models.RADT.PatientInfo patient = null;
        /// <summary>
        /// 患者业务类{81987883-BFB0-42f7-8B99-CF44CA44BDDA}
        /// </summary>
        Neusoft.HISFC.BizLogic.RADT.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            try
            {
                tv = sender as TreeView;
            }
            catch { }
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


            return base.OnInit(sender, neuObject, param);
        }
        #region 私有变量
        private bool sexReadOnly = true;
        private bool birthdayReadOnly = true;
        private bool relationReadOnly = true;
        private bool heightReadOnly = true;
        private bool weightReadOnly = true;
        private bool iDReadOnly = true;
        private bool professionReadOnly = true;
        private bool marryReadOnly = true;
        private bool homeAddrReadOnly = true;
        private bool homeTelReadOnly = true;
        private bool workReadOnly = true;
        private bool linkManReadOnly = true;
        private bool kinAddressReadOnly = true;
        private bool linkTelReadOnly = true;
        private bool memoReadOnly = true;
        private bool tpLeaveVisible = false;
        private bool tpNurseVisible = false;

        #region {9A2D53D3-25BE-4630-A547-A121C71FB1C5}
        private bool tpShiftNurseCellVisible = false;
        #endregion

        #endregion
        #region  属性
        /// <summary>
        /// 性别是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("性别是否允许修改")]
        public bool SexReadOnly
        {
            get
            {
                return sexReadOnly;
            }
            set
            {
                sexReadOnly = value;
            }
        }
        /// <summary>
        /// 生日是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("生日是否允许修改")]
        public bool BirthdayReadOnly
        {
            get
            {
                return birthdayReadOnly;
            }
            set
            {
                birthdayReadOnly = value;
            }
        }
        /// <summary>
        /// 身高是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("身高是否允许修改")]
        public bool HeightReadOnly
        {
            get
            {
                return heightReadOnly;
            }
            set
            {
                heightReadOnly = value;
            }
        }
        /// <summary>
        /// 体重是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("体重是否允许修改")]
        public bool WeightReadOnly
        {
            get
            {
                return weightReadOnly;
            }
            set
            {
                weightReadOnly = value;
            }
        }
        /// <summary>
        /// 身份证号是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("身份证号是否允许修改")]
        public bool IDReadOnly
        {
            get
            {
                return iDReadOnly;
            }
            set
            {
                iDReadOnly = value;
            }
        }
        /// <summary>
        /// 职业是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("职业是否允许修改")]
        public bool ProfessionReadOnly
        {
            get
            {
                return professionReadOnly;
            }
            set
            {
                professionReadOnly = value;
            }
        }
        /// <summary>
        /// 职业是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("婚姻是否允许修改")]
        public bool MarryReadOnly
        {
            get
            {
                return marryReadOnly;
            }
            set
            {
                marryReadOnly = value;
            }
        }
        /// <summary>
        /// 家庭住址是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("家庭住址是否允许修改")]
        public bool HomeAddrReadOnly
        {
            get
            {
                return homeAddrReadOnly;
            }
            set
            {
                homeAddrReadOnly = value;
            }
        }
        /// <summary>
        /// 家庭电话是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("家庭电话是否允许修改")]
        public bool HomeTelReadOnly
        {
            get
            {
                return homeTelReadOnly;
            }
            set
            {
                homeTelReadOnly = value;
            }
        }
        /// <summary>
        /// 工作单位是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("工作单位是否允许修改")]
        public bool WorkReadOnly
        {
            get
            {
                return workReadOnly;
            }
            set
            {
                workReadOnly = value;
            }
        }
        /// <summary>
        /// 联系人是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人是否允许修改")]
        public bool LinkManReadOnly
        {
            get
            {
                return linkManReadOnly;
            }
            set
            {
                linkManReadOnly = value;
            }
        }
        /// <summary>
        /// 联系人地址是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人地址是否允许修改")]
        public bool KinAddressReadOnly
        {
            get
            {
                return kinAddressReadOnly;
            }
            set
            {
                kinAddressReadOnly = value;
            }
        }
        /// <summary>
        /// 联系人电话是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人电话是否允许修改")]
        public bool LinkTelReadOnly
        {
            get
            {
                return linkTelReadOnly;
            }
            set
            {
                linkTelReadOnly = value;
            }
        }
        /// <summary>
        /// 联系人关系是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("联系人关系是否允许修改")]
        public bool RelationReadOnly
        {
            get
            {
                return relationReadOnly;
            }
            set
            {
                relationReadOnly = value;
            }
        }
        /// <summary>
        /// 特注处理是否允许修改
        /// </summary>
        [Category("患者基本信息"), Description("特注处理是否允许修改")]
        public bool MemoReadOnly
        {
            get
            {
                return memoReadOnly;
            }
            set
            {
                memoReadOnly = value;
            }
        }

        [Category("tab页设置"), Description("tpLeave请假管理是否显示")]
        public bool 请假管理是否显示
        {
            get
            {
                return tpLeaveVisible;
            }
            set
            {
                tpLeaveVisible = value;
            }
        }

        [Category("tab页设置"), Description("tpNurse婴儿登记管理是否显示")]
        public bool 婴儿登记是否显示
        {
            get
            {
                return tpNurseVisible;
            }
            set
            {
                tpNurseVisible = value;
            }
        }

        #region {9A2D53D3-25BE-4630-A547-A121C71FB1C5}

        [Category("tab页设置"), Description("转病区管理是否显示")]
        public bool 转病区是否显示
        {
            get
            {
                return this.tpShiftNurseCellVisible;
            }
            set
            {
                this.tpShiftNurseCellVisible = value;
            }
        }

        #endregion

        #region {5DF40042-300D-49b8-BB8D-4E4E906B7BAF}
        private bool isAllBedWave = false;
        [Category("床位维护设置"), Description("是否可以添加所有床位编制病床")]
        public bool IsAllBedWave
        {
            get
            {
                return this.isAllBedWave;
            }
            set
            {
                this.isAllBedWave = value;
            }
        }
       
        //{29F39131-89B4-4128-B4C9-EAB9F07B719F}
        private bool quitFeeApplyFlag = false;
        /// <summary>
        /// 有退费申请是否允许出院登记
        /// </summary>
        [Category("控件设置"), Description("存在退费申请是否允许做出院登记")]
        public bool QuitFeeApplyFlag
        {
            get
            {
                return quitFeeApplyFlag;
            }
            set
            {
                quitFeeApplyFlag = value;
            }
        }
        #endregion

        #endregion
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
                }
                else if (txtNode == EnumPatientType.ShiftIn.ToString())
                {
                    type = EnumPatientType.ShiftIn;
                }
                else if (txtNode == EnumPatientType.ShiftOut.ToString())
                {
                    type = EnumPatientType.ShiftOut;
                }
                else if (txtNode == EnumPatientType.Out.ToString())
                {
                    type = EnumPatientType.Out;
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
                    this.neuTabControl1.TabPages.Add(this.tpDept);
                    this.neuTabControl1.TabPages.Add(this.tpChangeDoc);
                    this.neuTabControl1.TabPages.Add(this.tpOut);

                    #region {9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                    if (this.tpShiftNurseCellVisible)
                    {
                        this.neuTabControl1.TabPages.Add(this.tpShiftNurseCell);
                    }
                    #endregion
                    

                    if (tpLeaveVisible)
                    {
                        this.neuTabControl1.TabPages.Add(this.tpLeave);
                    }
                    if (tpNurseVisible)
                    {
                        this.neuTabControl1.TabPages.Add(this.tpNurse);
                    }

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
                    #region {81987883-BFB0-42f7-8B99-CF44CA44BDDA}
                    if (this.转病区是否显示)
                    {
                        if (patient != null)
                        {
                            Neusoft.HISFC.Models.RADT.Location newLocation = new Neusoft.HISFC.Models.RADT.Location();
                            newLocation = this.inpatientManager.QueryShiftNewLocation(this.patient.ID, this.patient.PVisit.PatientLocation.Dept.ID);


                            if (newLocation.Dept.ID == "")
                            {
                                if (newLocation.NurseCell.ID != "")
                                {
                                    this.neuTabControl1.TabPages.Add(this.tpCancelNurseCell);
                                    return;
                                }
                            }
                        }
                    }
                    this.neuTabControl1.TabPages.Add(this.tpCancelDept);

                    #endregion
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
            else if (this.neuTabControl1.SelectedTab == this.tpArrive)//接珍
            {
                #region 接珍
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
                    if (ic != null)
                    {
                        ic.Init(this.tv, null, null);
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
                #endregion
            }
            else if (this.neuTabControl1.SelectedTab == this.tpCallBack)//找回
            {
                #region 找回
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    Neusoft.HISFC.BizProcess.Interface.ICallBackPatient uc = null;
                    uc = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.ICallBackPatient)) as Neusoft.HISFC.BizProcess.Interface.ICallBackPatient;
                    if (uc == null)
                    {
                        ucBasePatientArrive defaultuc = new ucBasePatientArrive();
                        defaultuc.Dock = DockStyle.Fill;
                        defaultuc.Visible = true;
                        defaultuc.arrivetype = ArriveType.CallBack;
                        ic = defaultuc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                        if (ic != null)
                        {
                            ic.Init(this.tv, null, null);
                        }
                        this.neuTabControl1.SelectedTab.Controls.Add((Neusoft.FrameWork.WinForms.Controls.ucBaseControl)defaultuc);
                    }
                    else
                    {
                        ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                        if (ic != null)
                        {
                            ic.Init(this.tv, null, null);
                        }
                        this.neuTabControl1.SelectedTab.Controls.Add((Neusoft.FrameWork.WinForms.Controls.ucBaseControl)uc);
                    }
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
                #endregion
            }
            else if (this.neuTabControl1.SelectedTab == this.tpCancelDept)//取消转科
            {
                #region 取消转科
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
                #endregion 
            }
            else if (this.neuTabControl1.SelectedTab == this.tpChangeDoc)//换医生
            {
                #region 换医生
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBasePatientArrive uc = new ucBasePatientArrive();
                    uc.Dock = DockStyle.Fill;
                    uc.Visible = true;
                    uc.arrivetype = ArriveType.ChangeDoc;
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
                #endregion  
            }
            else if (this.neuTabControl1.SelectedTab == this.tpDept)//换科室
            {
                #region 换科室
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
                #endregion 
            } 
            else if (this.neuTabControl1.SelectedTab == this.tpLeave)//请假
            {
                #region 请假
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientLeave uc = new ucPatientLeave();
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
                #endregion 
            }
            else if (this.neuTabControl1.SelectedTab == this.tpNurse)//婴儿登记
            {
                #region 婴儿登记
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucBabyInfo uc = new ucBabyInfo();
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
                #endregion 
            }
            else if (this.neuTabControl1.SelectedTab == this.tpOut)//出院登记
            {
                #region 出院登记
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    //ucPatientOut uc = new ucPatientOut();

                    Neusoft.HISFC.BizProcess.Interface.IucOutPatient uc = null;
                    uc = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.IucOutPatient)) as Neusoft.HISFC.BizProcess.Interface.IucOutPatient;
                    if (uc == null)
                    {
                        ucPatientOut ucDefault = new ucPatientOut();
                        ucDefault.Dock = DockStyle.Fill;
                        ucDefault.Visible = true;
                        //{29F39131-89B4-4128-B4C9-EAB9F07B719F}
                        ucDefault.QuitFeeApplyFlag = this.quitFeeApplyFlag;
                        ic = ucDefault as Neusoft.FrameWork.WinForms.Forms.IControlable;
                        if (ic != null)
                        {
                            ic.Init(this.tv, null, null);
                        }
                        this.neuTabControl1.SelectedTab.Controls.Add(ucDefault);
                    }
                    else
                    {
                        ((System.Windows.Forms.UserControl)uc).Dock = DockStyle.Fill;
                        ((System.Windows.Forms.UserControl)uc).Visible = true;
                        ic = uc as Neusoft.FrameWork.WinForms.Forms.IControlable;
                        if (ic != null)
                        {
                            ic.Init(this.tv, null, null);
                        }
                    }
                    this.neuTabControl1.SelectedTab.Controls.Add((System.Windows.Forms.UserControl)uc);
                }
                else
                {
                    ic = this.neuTabControl1.SelectedTab.Controls[0] as Neusoft.FrameWork.WinForms.Forms.IControlable;
                }
                #endregion
            }
            else if (this.neuTabControl1.SelectedTab == this.tpPatient)//患者基本信息
            {
                #region 患者基本信息
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientInfo uc = new ucPatientInfo();
                    uc.SexReadOnly = sexReadOnly;
                    uc.BirthdayReadOnly = birthdayReadOnly;
                    uc.RelationReadOnly = relationReadOnly;
                    uc.HeightReadOnly = heightReadOnly;
                    uc.WeightReadOnly = weightReadOnly;
                    uc.IDReadOnly = iDReadOnly;
                    uc.ProfessionReadOnly = professionReadOnly;
                    uc.MarryReadOnly = marryReadOnly;
                    uc.HomeAddrReadOnly = homeAddrReadOnly;
                    uc.HomeTelReadOnly = homeTelReadOnly;
                    uc.WorkReadOnly = workReadOnly;
                    uc.LinkManReadOnly = linkManReadOnly;
                    uc.KinAddressReadOnly = kinAddressReadOnly;
                    uc.LinkTelReadOnly = linkTelReadOnly;
                    uc.MemoReadOnly = memoReadOnly;
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
                #endregion
            }
            else if (this.neuTabControl1.SelectedTab == this.tpShiftNurseCell)//{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
            {
                #region 转病区{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientShiftNurseCell uc = new ucPatientShiftNurseCell();
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
                #endregion 
            }
            else if (this.neuTabControl1.SelectedTab == this.tpCancelNurseCell)//{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
            {
                #region 取消转病区{9A2D53D3-25BE-4630-A547-A121C71FB1C5}
                if (this.neuTabControl1.SelectedTab.Controls.Count == 0)
                {
                    ucPatientShiftNurseCell uc = new ucPatientShiftNurseCell();
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
                #endregion 
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
                base.OnStatusBarInfo(sender, ((EnumBedState)e.Item.ImageIndex).ToString());
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

        /// <summary>
        /// {997A8EEC-A27E-492f-941A-CDEAA3CC4AE7}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ic_RefreshTree(object sender, EventArgs e)
        {
            this.OnRefreshTree();
            try
            {
                ucBedListView uc = this.tbBedView.Controls[0] as ucBedListView;
                uc.RefreshView();
            }
            catch { }
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
            #region {5DF40042-300D-49b8-BB8D-4E4E906B7BAF}
            if (control.GetType() == typeof(Neusoft.HISFC.Components.RADT.Controls.ucBedManager))
            {
                Neusoft.HISFC.Components.RADT.Controls.ucBedManager uc = control as Neusoft.HISFC.Components.RADT.Controls.ucBedManager;

                uc.IsAllBedWave = this.isAllBedWave;

                tp.Controls.Add(uc);
            }
            else
            {
                tp.Controls.Add(control);
            }
            #endregion
            if (ic != null)
                ic.SetValue(patient, node);
            this.neuTabControl1.SelectedTab = tp;

            

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public enum EnumBedState
        {
            /// <summary>
            /// 
            /// </summary>
            空床 = 0,
            /// <summary>
            /// 
            /// </summary>
            男 = 1,
            /// <summary>
            /// 
            /// </summary>
            女 = 2,
            /// <summary>
            /// 
            /// </summary>
            关闭 = 3,
            /// <summary>
            /// 
            /// </summary>
            三级护理 = 4,
            /// <summary>
            /// 
            /// </summary>
            二级护理 = 5,
            /// <summary>
            /// 
            /// </summary>
            一级护理 = 6,
            /// <summary>
            /// 
            /// </summary>
            病危 = 7,
            /// <summary>
            /// 
            /// </summary>
            重症 = 8,
            /// <summary>
            /// 
            /// </summary>
            包床 = 9,
            /// <summary>
            /// 
            /// </summary>
            放假 = 10,
            /// <summary>
            /// 
            /// </summary>
            挂床 = 11,
            /// <summary>
            /// 
            /// </summary>
            无 = 12,
            /// <summary>
            /// 
            /// </summary>
            没有 = 13
        }


        #region IInterfaceContainer 成员

        Type[] Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer.InterfaceTypes
        {
            get
            {
                Type[] type = new Type[2];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.IucOutPatient);
                type[1] = typeof(Neusoft.HISFC.BizProcess.Interface.ICallBackPatient);
                return type;
            }
        }

        #endregion
    }
}

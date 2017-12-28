using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.EPR
{
    /// <summary>
    /// 电子病历控件
    /// wolf 2007-7-23
    /// </summary>
    public partial class ucEMRControl : Neusoft.FrameWork.WinForms.Controls.ucBaseControl,Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer    {
        public ucEMRControl()
        {
            try
            {
                InitializeComponent();
                if (DesignMode) return;
                this.panelToolbar.Visible = false;
                this.panelModual.Visible = false;



                this.ucDataFileLoader1.InterfaceFileName =
                   TemplateDesignerHost.Function.SystemPath + "\\interface.xml";
                this.ucDataFileLoader1.PageChanged += new EventHandler(ucDataFileLoader1_PageChanged);
                this.ucDataFileLoader1.AfterSaved += new EventHandler(ucDataFileLoader1_AfterSaved);
                this.ucDataFileLoader1.BeforOpen += new EventHandler(ucDataFileLoader1_BeforOpen);
            }
            catch { }


        }

       

        #region 变量

        protected Neusoft.FrameWork.Models.NeuObject objGroup = new Neusoft.FrameWork.Models.NeuObject();

        #endregion

        #region 属性
        private bool isShowModual = false;
        private Color templateColor = Color.LightBlue;

        /// <summary>
        /// 模板颜色
        /// </summary>
        public Color TemplateColor
        {
            get { return templateColor; }
            set {
                templateColor = value;
                this.navigateBar1.NavigateBarColorTable.CaptionEnd = value;
            }
        }

        /// <summary>
        /// 是否显示模板
        /// </summary>
        public  bool IsShowModual
        {
            get { return isShowModual; }
            set {
                if (ucDataFileLoader1.ucTemplateSelect.Files == null)
                    return;
                isShowModual = value;
                if (this.panelModual.Controls.Count<=0)
                {
                    this.panelModual.RelatedControl = this.ucDataFileLoader1.ucTemplateSelect;
                    this.navigateBar1.SelectedButton = this.panelModual;
                }
                this.panelModual.Visible = value;
            }
        }

        private bool isShowToolFunction = false;

        /// <summary>
        /// 是否显示工具按钮区
        /// </summary>
        public bool IsShowToolFunction
        {
            get { return isShowToolFunction; }
            set { isShowToolFunction = value;
            this.panelToolbar.Visible = isShowToolFunction;
            this.label1.Visible = !isShowToolFunction;

            }
        }

    

        private int currentType = 0;
        /// <summary>
        /// 当前类型
        /// </summary>
        public int Type
        {
            get
            {
                return currentType;
            }
            set
            {
                currentType = value;
              
            }
        }
        private bool isShowInterface = false;

        public bool IsShowInterface
        {
            get { return isShowInterface; }
            set { isShowInterface = value; }
        }

        private string pageName = "EMR";

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        private SQLType sqlType = SQLType.Inpatient;

        private bool isShowSendMessage = true;
        /// <summary>
        /// 是否显示发送错误报告菜单
        /// </summary>
        [Description("是否显示发送错误报告菜单")]
        public bool IsShowSendMessage
        {
            get
            {
                return this.isShowSendMessage;
            }
            set
            {
                this.isShowSendMessage = value;
                this.mnuSendMessage.Visible = value;
            }
        }

        #endregion

        #region 内部函数
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //事件处理
            this.ucDataFileLoader1.PageSelectedChanged += new EventHandler(ucDataFileLoader1_PageSelectedChanged);
            this.ucDataFileLoader1.ControlEnter += new EventHandler(ucDataFileLoader1_ControlEnter);
            this.navigateBar1.DisplayedButtonCount = 0;
            this.panelUserText.RelatedControl = this.ucUserText1;
            this.panelInfo.RelatedControl = this.ucUserCommonText1;
            this.btnEncap.Image = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.F封帐);
            SearchPatient.SearchControl.Location = new Point(299, 112);//new Point((this.panelEMR.Width - SearchPatient.SearchControl.Width) / 2, (this.panelEMR.Height - SearchPatient.SearchControl.Height) / 2);
            this.panelEMR.Controls.Add(SearchPatient.SearchControl);
            if(this.curPatient == null)
                SearchPatient.SearchControl.Visible = true;
            NameChange();
            this.FindForm().FormClosing += new FormClosingEventHandler(ucEMRControl_FormClosing);
            SearchPatient.SearchControl.BringToFront();

        }
        /// <summary>
        /// 给有问题的病历名前面加上标志 
        /// </summary>
        private void NameChange()
        {
            ArrayList lis = this.ucDataFileLoader1.Files;
            string InPatientNo = this.ucDataFileLoader1.index1;
            if (lis == null) return;
            //需要修改，应该按患者住院流水号过滤，全检索影响效率，数据库要建立索引
            ArrayList Msglis = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.QueryEmrId(InPatientNo); 

            if (Msglis == null) return;

            for (int i = 1; i < lis.Count; i++)
            {
                string emrid = ((Neusoft.FrameWork.Models.NeuObject)this.ucDataFileLoader1.Files[i]).ID;

                foreach (Neusoft.HISFC.Models.Base.Message message in Msglis)
                {
                    if (emrid == message.Emr.ID)
                    {
                        ucDataFileLoader1.ChangePageImage(emrid,true);
                        //c_NameChangedEvent(emrid, "[有问题]" + message.Emr.Name);
                    }
                }

            }
        }
        void ucEMRControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗口关闭时间
            if (AllowClosed() == false)
            {
                e.Cancel = true;
            }
            
        }

      
        void ucDataFileLoader1_PageSelectedChanged(object sender, EventArgs e)
        {
            try
            {	//设置组套
                this.ucUserText1.SetControl((System.ComponentModel.IContainer)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbar = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();
            toolbar.AddToolButton("模板", "显示模板", Neusoft.FrameWork.WinForms.Classes.EnumImageList.T添加, true, false, null);
            toolbar.AddToolButton("患者", "选择患者", Neusoft.FrameWork.WinForms.Classes.EnumImageList.G顾客, true, false, null);
            toolbar.AddToolButton("组套", "显示组套", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X信息, true, false, null);
            toolbar.AddToolButton("历史", "显示历史记录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查询历史, true, false, null);
            toolbar.AddToolButton("管理", "管理病历记录", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            toolbar.AddToolButton("字体", "更改字体", Neusoft.FrameWork.WinForms.Classes.EnumImageList.R日消耗, true, false, null);
            toolbar.AddToolButton("续打", "续打病历", Neusoft.FrameWork.WinForms.Classes.EnumImageList.D打印预览, true, false, null);

            return toolbar;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "模板")
            {
                this.IsShowModual = !this.IsShowModual;
            }
            else if (e.ClickedItem.Text == "患者")
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();
                p.ID = "ZY010008802223";
                p.Name = "aaa";
                this.OnSetValue(p, null);
            }
            else if (e.ClickedItem.Text == "组套")
            {
                this.navigateBar1.SelectedButton = this.panelUserText;
                
            }
            else if (e.ClickedItem.Text == "历史")
            {
                this.ucDataFileLoader1.CurrentLoader.RefreshLogo();
            }
            else if (e.ClickedItem.Text == "管理")
            {
                this.ManagerFile();
            }
            else if (e.ClickedItem.Text == "字体")
            {
                this.SetFont();
            }
            else if (e.ClickedItem.Text == "续打")
            {
                this.ContinuePrint();
            }
            base.ToolStrip_ItemClicked(sender, e);
        }


        Neusoft.HISFC.Components.EPR.Interface.ISearchPatient mySearchPatient = null;
        Neusoft.HISFC.Components.EPR.Interface.ISearchPatient SearchPatient
        {
            get
            {
                if (mySearchPatient == null)
                {
                    mySearchPatient = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(Neusoft.HISFC.Components.EPR.ucEMRControl), typeof(Neusoft.HISFC.Components.EPR.Interface.ISearchPatient)) as Neusoft.HISFC.Components.EPR.Interface.ISearchPatient;
                    if (mySearchPatient == null)
                    {
                        Neusoft.HISFC.Components.EPR.Interface.ucSearchPatient uc = new Neusoft.HISFC.Components.EPR.Interface.ucSearchPatient();
                        mySearchPatient = uc as Neusoft.HISFC.Components.EPR.Interface.ISearchPatient;
                    }
                }
                return mySearchPatient;
            }
        }

        /// <summary>
        /// 患者切换
        /// </summary>
        /// <param name="neuObject"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override int OnSetValue(object neuObject, TreeNode e)
        {

            if (neuObject == null) return -1;

            SearchPatient.SearchControl.Visible = false;

            if (curPatient!=null && curPatient.ID == ((Neusoft.FrameWork.Models.NeuObject)neuObject).ID)
            {
                return 0;
            }

            //判断是否可以切换
            if (AllowClosed() == false)
                return -1;

            

            string[] param = null;
           
            //住院患者
            if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
            {
                param = new string[]{ Neusoft.FrameWork.Management.Connection.Operator.ID, ((Neusoft.HISFC.Models.RADT.PatientInfo)neuObject).ID };
                this.ucDataFileLoader1.ISql = Common.Classes.Function.ISql;
                this.ucDataFileLoader1.InitSql("", param);
                SetUserText("rybl", "住院病历");
                setPatientInfo((Neusoft.HISFC.Models.RADT.PatientInfo)neuObject);

            }//门诊患者
            else if (neuObject.GetType() == typeof(Neusoft.HISFC.Models.Registration.Register))
            {
                 param = new string[] { Neusoft.FrameWork.Management.Connection.Operator.ID, ((Neusoft.HISFC.Models.Registration.Register)neuObject).ID };
                this.ucDataFileLoader1.ISql = Common.Classes.Function.ISqlOutPatient;
                this.ucDataFileLoader1.InitSql("", param);
                SetUserText("mzbl", "门诊病历");

            }
            else
            {
                param = new string[] { Neusoft.FrameWork.Management.Connection.Operator.ID, ((Neusoft.FrameWork.Models.NeuObject)neuObject).ID };
                this.ucDataFileLoader1.ISql = Common.Classes.Function.ISqlOther;
                this.ucDataFileLoader1.InitSql("", param);
                SetUserText("other", "其它档案");
            }
      

            curPatient = neuObject as Neusoft.FrameWork.Models.NeuObject;

            string id = param[1];
            this.ucDataFileLoader1.Init(this.currentType.ToString(), id );
            this.ucDataFileLoader1.index1 = id ;
            this.ucDataFileLoader1.index2 = ((Neusoft.FrameWork.Models.NeuObject)neuObject).Name;

            this.ucDataFileLoader1.IsShowInterface = this.isShowInterface;
            
            this.ucDataFileLoader1.RefreshForm();

            this.ucUserCommonText1.SetPatient(((Neusoft.FrameWork.Models.NeuObject)neuObject).ID, ucDataFileLoader1.DataStoreName, this.ucDataFileLoader1.ISql);

            if (this.IsShowModual == false )
                this.IsShowModual = true;
            return 0;
        }

        private void SetUserText(string groupID,string groupName)
        {
            if (objGroup.ID != groupID)
            {
                objGroup.ID = groupID;
                objGroup.Name = groupName;
                ucUserText1.GroupInfo = objGroup;
            }
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.ucDataFileLoader1.Save() == 0)
            {
                this.ucUserCommonText1.RefreshList();
            }
            this.Cursor = Cursors.Default;
            return 0;
        }

        protected Neusoft.FrameWork.Models.NeuObject curPatient = null;
        
        #endregion

        #region 公开函数
        /// <summary>
        ///病历管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ManagerFile()
        {
            if (this.curPatient == null) return;
            ucEMRManager c = new ucEMRManager(this.currentType.ToString());
            c.NameChangedEvent += new NameChangedHandler(c_NameChangedEvent);
            c.DeleteEvent += new DeleteHandler(c_DeleteEvent);
            c.InpatientNo = curPatient.ID;
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(c);
        }
        /// <summary>
        /// 病历名变更
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newName"></param>
        private void c_NameChangedEvent(int index, string newName)
        {
            this.ucDataFileLoader1.ChangePageName(index, newName);
        }
        /// <summary>
        /// 病历删除
        /// </summary>
        /// <param name="index"></param>
        private void c_DeleteEvent(int index)
        {
            this.ucDataFileLoader1.DeletePage(index);
        }
        #endregion

        #region 私有函数

        private void setPatientInfo(Neusoft.HISFC.Models.RADT.PatientInfo patient)
        {
            this.lblPatient.Text = string.Format("姓名：{0}   年龄：{1}   性别：{2}   合同单位：{3}   住院号：{4}", patient.Name, patient.Age, patient.Sex.Name, patient.Pact.Name, patient.PID.PatientNO);
        }

        private Control currentControl = null;

        void ucDataFileLoader1_ControlEnter(object sender, EventArgs e)
        {
            this.currentControl = sender as Control;
            Neusoft.FrameWork.EPRControl.IUserControlable ic = this.currentControl as Neusoft.FrameWork.EPRControl.IUserControlable;
            try
            {
                if (ic != null)
                    currentControl = ic.FocusedControl;
            }
            catch { }
            
        }

        protected void SetFont()
        {
            if (currentControl == null)
            {
                MessageBox.Show("请选择文字！");
                return;
            }
            FontDialog font = new FontDialog();
            bool bRichtTextBox = false;
            if (currentControl.GetType().IsSubclassOf(typeof(RichTextBox))) //多行文本
            {
                bRichtTextBox = true;
            }
            if (bRichtTextBox)
            {
                font.Font = ((RichTextBox)currentControl).SelectionFont;
            }
            else
            {
                font.Font = currentControl.Font;
            }
            if (font.ShowDialog(this) == DialogResult.OK)
            {
                if (bRichtTextBox)
                {
                    ((RichTextBox)currentControl).SelectionFont = font.Font;
                }
                else
                {
                    currentControl.Font = font.Font;
                }
            }
        }

        protected void SetFont1()
        {
            if (currentControl == null)
            {
                MessageBox.Show("请选择文字！");
                return;
            }
            frmSetFont form = new frmSetFont();
            
            if (currentControl.GetType().IsSubclassOf(typeof(RichTextBox))) //多行文本
            {
            }
            else
            {
                return ;
            }
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                //Modified by zhengxun at 2008-2-28
                //for Super and sub Character
                string str = ((RichTextBox)currentControl).SelectedRtf;
                str = str.Replace(@"\nosupersub", "");
                str = str.Replace(@"\super", "");
                str = str.Replace(@"\sub", "");
                
                switch (form.Type)
                {
                    case 0:
                        //((RichTextBox)currentControl).SelectionCharOffset = 4;
                        //((RichTextBox)currentControl).SelectionFont = new Font(((RichTextBox)currentControl).SelectionFont.FontFamily.Name, 7, ((RichTextBox)currentControl).SelectionFont.Style); ;
                        str = str.Replace(@"\lang2052\f0", @"\lang2052\super\f0");
                        break;
                    case 1:
                        //((RichTextBox)currentControl).SelectionCharOffset = 0;
                        //((RichTextBox)currentControl).SelectionFont = new Font(((RichTextBox)currentControl).SelectionFont.FontFamily.Name, 9, ((RichTextBox)currentControl).SelectionFont.Style); ;
                        break;
                    case 2:
                        //((RichTextBox)currentControl).SelectionCharOffset = -4;
                        //((RichTextBox)currentControl).SelectionFont = new Font(((RichTextBox)currentControl).SelectionFont.FontFamily.Name, 7, ((RichTextBox)currentControl).SelectionFont.Style); ;
                        str = str.Replace(@"\lang2052\f0", @"\lang2052\sub\f0");
                        break;
                }
                ((RichTextBox)currentControl).SelectedRtf = str;
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnPrintPreview(object sender, object neuObject)
        {
            myPrint();
            return 0;
        }

        private void myPrint()
        {
            print = new Neusoft.FrameWork.WinForms.Classes.Print();
            this.printpage(ref print);
        }

        
        Neusoft.FrameWork.WinForms.Classes.Print print = null;

        /// <summary>
        /// 打印
        /// </summary>
        private void printpage(ref Neusoft.FrameWork.WinForms.Classes.Print print)
        {
            if (this.ucDataFileLoader1.CurrentLoader == null) return;
            if (this.ucDataFileLoader1.CurrentLoader.dt == null) return;
            if (this.ucDataFileLoader1.CurrentLoader.dt.ID == "") return;

            ((Neusoft.FrameWork.EPRControl.emrPanel)this.ucDataFileLoader1.CurrntPanel).AutoScrollPosition = new Point(0, 0);


            Neusoft.HISFC.Models.Base.PageSize page = Common.Classes.Function.GetPageSize(pageName);

            if (page != null)
            {
                print.SetPageSize(page);
                if (page.Memo.Trim().Length == 1)
                    print.ControlBorder = (Neusoft.FrameWork.WinForms.Classes.enuControlBorder)Neusoft.FrameWork.Function.NConvert.ToInt32(page.Memo);
                else
                    print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Line;
            }
            else
            {
                print.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.Line;//default
            }

            bool autoExtend = ((Neusoft.FrameWork.EPRControl.emrPanel)this.ucDataFileLoader1.CurrntPanel).自动分页;

            print.IsDataAutoExtend = !autoExtend;
            print.IsHaveGrid = autoExtend;
            print.IsPrintInputBox = false;
            Neusoft.FrameWork.WinForms.Classes.PrintControlCompare p=new Neusoft.FrameWork.WinForms.Classes.PrintControlCompare();
            p.SetEPRControl();
            print.SetControlCompare(p);
            print.IsPrintBackImage = false;
            
            //设置控件打印状态
            print.PrintPreview(this.ucDataFileLoader1.CurrntPanel);

        }


        Neusoft.HISFC.Components.EPR.Interface.IContinuePrint myContinuePrint = null;
        Neusoft.HISFC.Components.EPR.Interface.IContinuePrint continuePrint
        {
            get
            {
                if (myContinuePrint == null)
                {
                    myContinuePrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(Neusoft.HISFC.Components.EPR.ucEMRControl), typeof(Neusoft.HISFC.Components.EPR.Interface.IContinuePrint)) as Neusoft.HISFC.Components.EPR.Interface.IContinuePrint;
                    if (myContinuePrint == null)
                    {
                        Neusoft.HISFC.Components.EPR.Interface.ContinuePrint uc = new Neusoft.HISFC.Components.EPR.Interface.ContinuePrint();
                        myContinuePrint = uc as Neusoft.HISFC.Components.EPR.Interface.IContinuePrint;
                    }
                }
                return myContinuePrint;
            }
        }
       
        /// <summary>
        /// 续打
        /// </summary>
        public void ContinuePrint()
        {

            //病程记录续打印
            if (continuePrint.IsCanContinuePrint(this.ucDataFileLoader1.CurrntPanel))
            {

                continuePrint.Print(this.ucDataFileLoader1.CurrntPanel);
            }
            else
            {
                MessageBox.Show("改页不提供续打功能！");
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.IsShowToolFunction = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
        }

        private void btnEncap_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrntPanel == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            this.groupBox2.Visible = !this.groupBox2.Visible;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = false;
        }
        /// <summary>
        /// 封存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInStore_Click(object sender, EventArgs e)
        {
            if (this.curPatient == null) return;
            TemplateDesignerHost.Function.SealEMR(this.curPatient as Neusoft.HISFC.Models.RADT.PatientInfo);
            this.groupBox2.Visible = false;
        }
        /// <summary>
        /// 解封
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutStore_Click(object sender, EventArgs e)
        {
            if (this.curPatient == null) return;
            TemplateDesignerHost.Function.UnSealEMR(this.curPatient as Neusoft.HISFC.Models.RADT.PatientInfo);
            this.groupBox2.Visible = false;
        }
        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                Type[] t = new Type[1];
                t[0] = typeof(Neusoft.HISFC.Components.EPR.Interface.ISearchPatient);
                t[1] = typeof(Neusoft.HISFC.Components.EPR.Interface.IContinuePrint);
                return t;
            }
        }


        #endregion

        #region 功能按钮
        private void label1_Click(object sender, EventArgs e)
        {
            this.IsShowToolFunction = true;

        }

       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.ucDataFileLoader1.RefreshPage();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //去掉问题标识

            if (this.ucDataFileLoader1.CurrentLoader != null)
            {
                if (ucDataFileLoader1.IsHaveImage(this.ucDataFileLoader1.CurrentLoader.dt.ID))
                {
                    Neusoft.HISFC.Models.File.DataFileInfo df = null;
                    string emrid = "";
                    string emrname = "";

                    try
                    {
                        df = this.ucDataFileLoader1.CurrentLoader.dt;

                        emrid = df.ID;

                        //emrname = df.Name.Remove(0, 5);

                    }
                    catch { }

                    int returnvalue = Neusoft.HISFC.BizProcess.Factory.Function.IntegrateEPR.UpdateMessage(2, emrid);

                    if (returnvalue == -1) return;

                    this.ucDataFileLoader1.ChangePageImage(emrid,false);

                    //c_NameChangedEvent(emrid, emrname);
                }
            }
            if (this.ucDataFileLoader1.Save() == 0)
            {
                this.ucUserCommonText1.RefreshList();
            }
            this.Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrentLoader == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            ucMapGroup ucMap = new ucMapGroup();
            ucMap.Dock = DockStyle.Fill;
            ucMap.SetLoader(this.ucDataFileLoader1, (Neusoft.HISFC.Models.RADT.PatientInfo)this.curPatient);
            ucMap.Visible = true;
            frmMap form = new frmMap();
            form.Controls.Add(ucMap);
            form.ShowDialog();
        }

        private void btnContinuePrint_Click(object sender, EventArgs e)
        {
            this.ContinuePrint();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrentLoader == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            this.SetFont();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            this.ManagerFile();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrentLoader == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            this.ucDataFileLoader1.CurrentLoader.RefreshLogo();
        }

        private void btnFont1_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrentLoader == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            this.SetFont1();
        }
        #endregion

        #region 背景
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ucDataFileLoader1.CurrntPanel == null)
            {
                MessageBox.Show("先选择病历页！");
                return;
            }
            this.groupBox1.Visible = !this.groupBox1.Visible;
        }

        /// <summary>
        /// 有无边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBorder_CheckedChanged(object sender, EventArgs e)
        {
            SetBorderStyle(!this.chkBorder.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ucDataFileLoader1.CurrntPanel.BackgroundImage = null;
        }

        private void SetBorderStyle(bool bHave)
        {
            foreach (Component c in ((Neusoft.FrameWork.EPRControl.emrPanel)this.ucDataFileLoader1.CurrntPanel).Components)
            {
                if (c.GetType().IsSubclassOf(typeof(TextBoxBase)))
                {
                    if (bHave)
                        ((TextBoxBase)c).BorderStyle = BorderStyle.None;
                    else
                        ((TextBoxBase)c).BorderStyle = BorderStyle.FixedSingle;
                }
                if (c.GetType().IsSubclassOf(typeof(ComboBox)) || c.GetType() == typeof(ComboBox))
                {
                    if (bHave)
                        ((ComboBox)c).FlatStyle = FlatStyle.Popup;
                    else
                        ((ComboBox)c).FlatStyle = FlatStyle.System;
                }
            }
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            this.ucDataFileLoader1.CurrntPanel.BackgroundImage = ((Button)sender).Image;
            foreach (Control c in this.ucDataFileLoader1.CurrntPanel.Controls)
            {
                if (c != null)
                {
                    try
                    {
                        c.BackColor = Color.Transparent;
                    }
                    catch { }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.bmp|*bmp|*.jpg|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.ucDataFileLoader1.CurrntPanel.BackgroundImage = Image.FromFile(dialog.FileName);
            }
        }

        private void ucDataFileLoader1_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = false;
        }

        #endregion

        #region 锁
        private void ucDataFileLoader1_PageChanged(object sender,EventArgs e)
        {
           
        }
        Lock myLock = new Lock();
        private void ucDataFileLoader1_BeforOpen(object sender, EventArgs e)
        {
            if(this.curPatient.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                myLock.BeforOpen(this.ucDataFileLoader1, (Neusoft.HISFC.Models.RADT.PatientInfo)this.curPatient, (Neusoft.HISFC.Models.File.DataFileInfo)sender);
        }
        private void ucDataFileLoader1_AfterSaved(object sender ,EventArgs e)
        {
           
        }

        public bool AllowClosed()
        {
            //判断是否有没有保存的病历进行提示，是否保存
            
            if (this.ucDataFileLoader1.ReadOnly == true) return true;
            if (ucDataFileLoader1.CurrentLoader == null || this.ucDataFileLoader1.CurrentLoader.dt == null) return true;
            if (this.ucDataFileLoader1.IsHaveSaved() == false) return false;
            if (this.curPatient.GetType() == typeof(Neusoft.HISFC.Models.RADT.PatientInfo))
                myLock.UnLock(this.ucDataFileLoader1, (Neusoft.HISFC.Models.RADT.PatientInfo)this.curPatient);
            return true;
            
        }
        #endregion

     

        #region 其它接口
        private void mnuSendMessage_Click(object sender, EventArgs e)
        {
            Neusoft.HISFC.Models.File.DataFileInfo dt = null;
            string eprid ="";
            string eprName ="";
            Neusoft.FrameWork.Models.NeuObject oper = new Neusoft.FrameWork.Models.NeuObject();
            try
            {
                dt = this.ucDataFileLoader1.CurrentLoader.dt;
                eprid = dt.ID;
                eprName = dt.Name;
            }catch{}
            Neusoft.HISFC.Components.EPR.Controls.ucSendMessage sendMessage = new Neusoft.HISFC.Components.EPR.Controls.ucSendMessage(this.curPatient, eprid, eprName, oper);
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(sendMessage);

        }

        private void mnuViewWriteRule_Click(object sender, EventArgs e)
        {
            ucCaseWriteRule uc = new ucCaseWriteRule();
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }

        #endregion


    }
    public enum SQLType
    {
        Outpatient,
        Inpatient,
        Other
    }
}

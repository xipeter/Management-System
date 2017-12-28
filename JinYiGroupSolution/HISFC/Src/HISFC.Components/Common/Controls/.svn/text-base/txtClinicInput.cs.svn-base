using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public delegate void selectedEventDelegate();

    public partial class txtClinicInput : Neusoft.FrameWork.WinForms.Controls.NeuTextBox
    {
        public txtClinicInput()
        {
            InitializeComponent();
        }

        public txtClinicInput(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        

        #region 私有变量

        private ArrayList alInfo = new ArrayList();
        private ArrayList alRegInfo = new ArrayList();
        //门诊号
        private string clinicCode = "";
        //门诊卡号
        private string cardNO = "";
        //是否只显示本科室信息
        private bool isShowOwnDept = false;
        //是否用于查询
        private bool isExecQuery = true;

        private DateTime dtNow = DateTime.Now;
        private string strFormatHeader = "";
        
        private int intLength = 10;
        private int validDays = 1;//挂号有效天数

        //挂号信息
        private Neusoft.HISFC.Models.Registration.Register regInfo = new Neusoft.HISFC.Models.Registration.Register();
        //查询类型
        private string queryType ="0";
        private System.Windows.Forms.Form listform;
        private System.Windows.Forms.ListBox lst;
        private bool isShowMarkNO = false;
        private string markNO = string.Empty;
        //判断是否刷卡用于是否显示卡号数据
        private bool isMarkNo = false;
        #region 业务层
        //医嘱业务层
        protected Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        //参数业务层
        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlManagement = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
        //挂号业务层
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regManagement = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        /// <summary>
        /// 帐户业务层
        /// </summary>
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        #endregion

        #endregion

        #region 公有属性、方法

        [Category("设置"), Description("只有在刷卡的时候这个属性才起作用，是否显示物理卡号")]
        public bool IsShowMarkNO
        {
            get
            {
                return isShowMarkNO;
            }
            set
            {
                isShowMarkNO = value;
            }
        }

        /// <summary>
        /// 门诊号
        /// </summary>
        public string ClinicCode
        {
            get { return this.clinicCode; }
        }
        /// <summary>
        /// 门诊卡号
        /// </summary>
        public string CardNO
        {
            get { return this.cardNO; }
        }

        /// <summary>
        /// 物理卡号
        /// </summary>
        public string MarkNO
        {
            get
            {
                return markNO;
            }
        }

        [Category("设置"),Description("是否用于查询"),Browsable(true),DefaultValue(true)]
        public bool IsExecQuery
        {
            get { return this.isExecQuery; }
            set { this.isExecQuery = value; }
        }
        
        [Category("设置"), Description("是否只显示本科室信息"), Browsable(true), DefaultValue(false)]
        public bool IsShowOwnDept
        {
            get { return this.isShowOwnDept; }
            set { this.isShowOwnDept = value; }
        }

        /// <summary>
        /// 挂号信息
        /// </summary>
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            get 
            {
                if (this.clinicCode != "")
                {
                    this.regInfo = this.regManagement.GetByClinic(this.clinicCode);
                }
                return this.regInfo; 
            }
        }
        /// <summary>
        /// 门诊卡号格式化参数（参数：字头字符；门诊号长度）
        /// </summary>
        /// <param name="Header"></param>
        /// <param name="Length"></param>
        public void SetCardNOFormat(string Header, int Length)
        {
            this.intLength = Length;
            this.strFormatHeader = Header;
        }
        /// <summary>
        /// 返回信息事件
        /// </summary>
        public event Controls.selectedEventDelegate selectedEvents;

        #endregion

        #region 方法

        /// <summary>
        /// 格式化输入的字符串（门诊卡号）
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        private string CardNOFormat(string Text)
        {
            
            string strText = Text;
            try
            {
                for (int i = 0; i < this.intLength - strText.Length; i++)
                {
                    Text = "0" + Text;
                }

                if (this.strFormatHeader != "")
                {
                    Text = this.strFormatHeader + Text.Substring(this.strFormatHeader.Length);
                }
            }
            catch { }
            
            return Text;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void Query()
        {
            string txtInput = this.CardNOFormat(this.Text.Trim());
            if (txtInput == string.Empty)
            {
                MessageBox.Show("请输入数据！");
                this.Focus();
                return;
            }
            this.alInfo = new ArrayList();
            this.QueryByCardNO(txtInput);
            this.QueryByMarkNO();
            //是刷卡
            if (isMarkNo)
            {
                //显示卡号
                if (isShowMarkNO)
                    this.Text = markNO;
                else
                    this.Text = cardNO;
            }
            else
            {
                this.Text = cardNO;
            }
            isMarkNo = false;
            if (this.alInfo.Count == 1)
            {
                this.clinicCode = ((Neusoft.FrameWork.Models.NeuObject)this.alInfo[0]).User03;
            }
            else if (this.alInfo.Count <= 0)
            {
                this.NoInfo();
                MessageBox.Show("未查询到信息","提示");
            }
            else
            {
                this.SelectPatient();
                return;
            }
            try
            {
                if (this.listform != null)
                {
                    this.listform.Close();
                }
            }
            catch { }
            try
            {
                this.selectedEvents();
            }
            catch { }
        }

        /// <summary>
        /// 根据卡号查询
        /// </summary>
        private void QueryByCardNO(string txtInput)
        {
            try
            {
                ArrayList alReg = new ArrayList();
                this.queryType = "0";
                this.cardNO = txtInput;
                this.validDays = this.ctrlManagement.GetControlParam<int>("MZ0014", false, 1);
                dtNow = this.orderManagement.GetDateTimeFromSysDateTime();
                alReg = this.regManagement.Query(txtInput, dtNow.AddDays(-this.validDays));
                if (alReg.Count > 0)
                {
                    for (int i = 0; i < alReg.Count; i++)
                    {
                        Neusoft.HISFC.Models.Registration.Register obj = alReg[i] as Neusoft.HISFC.Models.Registration.Register;
                        this.regInfo = obj;//在控件外面重新获得挂号信息
                        Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();
                        if (obj.DoctorInfo.SeeDate.Date == dtNow.Date)
                        {
                            o.ID = "新";
                            o.Memo = "今天          ";
                        }
                        else
                        {
                            o.ID = "  ";
                            o.Memo = obj.DoctorInfo.SeeDate.ToString("yyyy年MM月dd日");
                        }
                        o.Name = obj.Name + "(" + obj.RecipeNO + ")";  //添加了处方号,方便医生确认
                        o.User02 = obj.DoctorInfo.Templet.Dept.Name;
                        o.User03 = obj.ID;//门诊流水号
                        
                        o.User01 = ((Neusoft.HISFC.Models.Base.Employee)this.orderManagement.Operator).Dept.ID;
                        //显示看诊序号，姓名，看诊日期（去掉时间）,看诊科室
                        try
                        {
                            o.Name = o.ID + "  " + o.Name + "  " + o.User02 + "  " + o.Memo + "  " + o.User03;
                        }
                        catch
                        {
                            
                        }
                        o.ID = this.queryType;
                        this.alInfo.Insert(0, o);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 根据物理卡号查找门诊卡号
        /// </summary>
        protected virtual void QueryByMarkNO()
        {
            string txtinput = this.Text.Trim();
            this.markNO = string.Empty;
            //根据卡号规则判断是否是卡，并取出卡号
            //{E24EF7EC-94EE-45b2-B717-E722A2D10068}
            Neusoft.HISFC.Models.Account.AccountCard accountCard  = new Neusoft.HISFC.Models.Account.AccountCard ();
            //if (feeIntegrate.ValidMarkNO(txtinput, ref markNO) < 0) return;
            if (feeIntegrate.ValidMarkNO(txtinput, ref accountCard ) <0) return;
            markNO = accountCard.MarkNO;
            cardNO = string.Empty;
            //查找卡号所对应的
            //bool bl = feeIntegrate.GetCardNoByMarkNo(markNO, Neusoft.HISFC.Models.Account.MarkTypes.Magcard, ref cardNO);
            bool bl = feeIntegrate.GetCardNoByMarkNo(markNO, ref cardNO);
            if (!bl)
            {
                MessageBox.Show(this.feeIntegrate.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isMarkNo = true;
            this.QueryByCardNO(cardNO);
        }

        /// <summary>
        /// 获取选择的信息
        /// </summary>
        private void GetInfo()
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                                
                obj = lst.Items[lst.SelectedIndex] as Neusoft.FrameWork.Models.NeuObject;
                if (obj.ID == "0")
                {
                    this.clinicCode = obj.User03;
                    if (this.clinicCode != "")
                    {
                        this.regInfo = this.regManagement.GetByClinic(this.clinicCode);
                    }
                    this.cardNO = this.regInfo.PID.CardNO;
                    try
                    {
                        this.listform.Hide();
                    }
                    catch
                    {

                    }
                    try
                    {
                        this.selectedEvents();
                    }
                    catch { }
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.ToString()); 
                this.NoInfo(); 
            }
        }

        /// <summary>
        /// 选择病人
        /// </summary>
        private void SelectPatient()
        {
            lst = new System.Windows.Forms.ListBox();
            lst.Dock = System.Windows.Forms.DockStyle.Fill;
            lst.Items.Clear();
            this.listform = new System.Windows.Forms.Form();
            //用窗口显示			
            
            listform.Size = new Size(300, 200);
            listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Neusoft.HISFC.Models.Base.Employee user = this.orderManagement.Operator as Neusoft.HISFC.Models.Base.Employee;
            Neusoft.HISFC.BizLogic.Manager.Department managerDept = new Neusoft.HISFC.BizLogic.Manager.Department();
            for (int i = 0; i < this.alInfo.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj;
                obj = (Neusoft.FrameWork.Models.NeuObject)this.alInfo[i];
                bool b = false;
                if (this.isShowOwnDept)//过滤病区－科室
                {
                    b = false;
                    if (user.EmployeeType.ID.ToString() == "N")//护士站
                    {
                        Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
                        ArrayList alDept = managerDept.GetDeptFromNurseStation(user.Nurse);
                        if (alDept == null)
                        {

                        }
                        else
                        {
                            for (int k = 0; k < alDept.Count; i++)
                            {
                                dept = alDept[k] as Neusoft.FrameWork.Models.NeuObject;
                                if (dept.ID == obj.User01)
                                {
                                    b = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (user.Dept.ID == obj.User01)//科室对应上
                        {
                            b = true;
                        }
                    }
                }
                else
                {
                    b = true;
                }
                if (b)
                {

                    try
                    {
                        lst.Items.Add(obj);
                    }
                    catch { }
                                        
                }
            }
            if (lst.Items.Count == 1)
            {
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    
                    this.selectedEvents();
                }
                catch { }
                return;
            }

            if (lst.Items.Count <= 0)
            {
                this.NoInfo();
                this.selectedEvents();
                return;
            }

            lst.Visible = true;
            lst.DoubleClick += new EventHandler(lst_DoubleClick);
            lst.KeyDown += new KeyEventHandler(lst_KeyDown);
            lst.Show();

            listform.Controls.Add(lst);
            listform.TopMost = true;
            listform.Owner = this.FindForm();
            listform.Show();

            #region 设置显示位置
            Point tp = new Point(0, this.Height);
            Point p = this.PointToScreen(tp);
            Screen[] screens = Screen.AllScreens;
            int width = screens[0].Bounds.Width;
            int height = screens[0].Bounds.Height;

            if (width - p.X < listform.Width)
            {
                tp = new Point(tp.X-listform.Width+this.Width, tp.Y);
            }
            if (height - p.Y < listform.Height)
            {
                tp = new Point(tp.X, tp.Y - this.Height-listform.Height-4);
            }
            listform.Location = this.PointToScreen(tp);
            #endregion

            try
            {
                lst.SelectedIndex = 0;
                lst.Focus();
                lst.LostFocus += new EventHandler(lst_LostFocus);
            }
            catch { }
            return;
        }

        /// <summary>
        /// 无信息
        /// </summary>
        private void NoInfo()
        {
            this.clinicCode = "";
            this.cardNO = "";
            this.regInfo = new Neusoft.HISFC.Models.Registration.Register();
        }

        #endregion

        #region 弹出窗口事件

        private void lst_LostFocus(object sender, EventArgs e)
        {
            this.listform.Hide();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.GetInfo();
            }
            catch { }
        }

        private void lst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.GetInfo();
            }
        }

        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isExecQuery)
                {
                    this.Query();
                }               
            }
            base.OnKeyDown(e);
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == "/r")
        //    {
        //        if (isExecQuery)
        //        {
        //            e.Handled = true;
        //            this.Query();

        //        }
        //    }

        //    base.OnKeyPress(e);
        //}

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucQueryRegisterByCardNo : UserControl
    {
        public ucQueryRegisterByCardNo()
        {
            InitializeComponent();
        }

        #region 屏蔽

        //#region 私有变量
        //private ArrayList alSeeNo = new ArrayList();
        //private string strSeeNo = "-1";
        //private string clinicCode = "";//门诊流水号
        //private Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        //private System.Windows.Forms.Form listform;
        //private System.Windows.Forms.ListBox lst;
        
        //private string strFormatHeader = "";
        //private int intDateType = 0;
        //private int intLength = 10;
        //private int validDays = 1;//挂号有效天数
        //#endregion

        //#region 可控制公有属性、方法
        //protected int inputtype = 0;//当前输入类型
        ///// <summary>
        ///// 输入类型
        ///// </summary>
        //public int InputType
        //{
        //    get
        //    {
        //        return this.inputtype;
        //    }
        //    set
        //    {
        //        if (value >= 1) value = 0;
        //        this.inputtype = value;
        //        switch (inputtype)
        //        {
        //            //门诊号
        //            case 0:
        //                this.txtInputCode.BackColor = Color.White;
        //                this.neuLabel1.Text = "门诊号:";
        //                this.tooltip.SetToolTip(txtInputCode, "当前输入门诊号查询！");
        //                break;
        //            //姓名
        //            //case 1:
        //            //    this.label1.Text = "姓名:";
        //            //    this.txtInputCode.BackColor = Color.FromArgb(255, 190, 190);
        //            //    this.tooltip.SetToolTip(txtInputCode, "当前输入姓名查询！\n按F2切换查询方式！");
        //            //    break;
        //            default:
        //                this.neuLabel1.Text = "门诊号:";
        //                this.txtInputCode.BackColor = Color.White;
        //                this.tooltip.SetToolTip(txtInputCode, "当前输入门诊号查询！");
        //                break;
        //        }
        //        this.tooltip.Active = true;
        //    }
        //}

        //protected ToolTip tooltip = new ToolTip();
        ///// <summary>
        ///// 限制
        ///// </summary>
        //protected bool isRestrictOwnDept = false;
        
        ///// <summary>
        ///// 是否限制本科室患者
        ///// </summary>
        //public bool IsRestrictOwnDept
        //{
        //    set
        //    {
        //        this.isRestrictOwnDept = value;
        //    }
        //}
        
        ///// <summary>
        ///// 录入门诊号文本格式化—补零（参数：门诊号长度）
        ///// </summary>
        ///// <param name="Length"></param>
        //public void SetFormat(int Length)
        //{
        //    this.SetFormat("", 0, Length);
        //}
        ///// <summary>
        ///// 错误消息
        ///// </summary>
        //public string Err;
        ///// <summary>
        ///// 返回信息事件
        ///// </summary>
        //public event  Function.Controls.myEventDelegate myEvents;
        ///// <summary>
        ///// 得到多条看诊序号信息数组
        ///// </summary>
        //public ArrayList SeeNos
        //{
        //    get
        //    {
        //        return this.alSeeNo;
        //    }
        //}

        ///// <summary>
        ///// 得到一条看诊序号信息
        ///// </summary>
        //public string SeeNo
        //{
        //    get
        //    {
        //        if (this.strSeeNo == "新" || this.strSeeNo.Trim() == "") this.strSeeNo = "-1";
        //        return this.strSeeNo;
        //    }
        //}
        //public string ClinicCode
        //{
        //    get
        //    {
        //        return this.clinicCode;
        //    }
        //}
        ///// <summary>
        ///// 门诊号文本录入属性
        ///// </summary>
        //public new string Text
        //{
        //    get
        //    {
        //        return this.txtInputCode.Text;
        //    }
        //    set
        //    {
        //        this.txtInputCode.Text = value;
        //    }
        //}
        ///// <summary>
        ///// 当前输入的文本控件
        ///// </summary>
        //public Neusoft.FrameWork.WinForms.Controls.NeuTextBox TextBox
        //{
        //    get
        //    {
        //        return this.txtInputCode;
        //    }
        //    set
        //    {
        //        this.txtInputCode = value;
        //    }
        //}
        ///// <summary>
        ///// 当前label控件
        ///// </summary>
        //public Neusoft.FrameWork.WinForms.Controls.NeuLabel Label
        //{
        //    get { return this.neuLabel1; }
        //    set { this.neuLabel1 = value; }
        //}
        ///// <summary>
        ///// 录入门诊号文本格式化—加字头（参数：字头字符；门诊号长度）
        ///// </summary>
        ///// <param name="Header"></param>
        ///// <param name="Length"></param>
        //public void SetFormat(string Header, int Length)
        //{
        //    this.SetFormat(Header, 0, Length);
        //}
        ///// <summary>
        ///// 录入门诊号文本格式化—加字头添加日期（参数：字头字符；时间；门诊号长度）
        ///// </summary>
        ///// <param name="Header"></param>
        ///// <param name="DateType"></param>
        ///// <param name="Length"></param>
        //public void SetFormat(string Header, int DateType, int Length)
        //{
        //    this.intLength = Length;
        //    this.strFormatHeader = Header;
        //    this.intDateType = DateType;
        //}
        ///// <summary>
        ///// 聚焦
        ///// </summary>
        //public new void Focus()
        //{
        //    this.txtInputCode.SelectAll();
        //    this.txtInputCode.Focus();
        //}
        //private Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
        ///// <summary>
        ///// 当前登记信息
        ///// </summary>
        //public Neusoft.HISFC.Models.Registration.Register Register
        //{
        //    get
        //    {
                
        //        this.myRegister.DoctorInfo.SeeNO = int.Parse(this.SeeNo);
        //        if (this.clinicCode != "")
        //        {
        //            this.myRegister.ID = this.clinicCode;
        //        }
        //        return this.myRegister;
        //    }
        //    set
        //    {
        //        this.myRegister = value;
        //    }
        //}
                
        //#endregion

        //#region 不可控制私有属性、方法

        //private void txtInputCode_TextChanged(object sender, System.EventArgs e)
        //{

        //}

        //private void txtInputCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            this.query();
        //        }
        //        else if (e.KeyCode == Keys.F2)
        //        {
        //            this.InputType++;
        //        }
        //        else if (e.KeyCode == Keys.Space)
        //        {
        //            this.query();
        //        }
        //    }
        //    catch { }
        
        //}
        //private void SelectPatient()
        //{
        //    lst = new ListBox();
        //    lst.Dock = System.Windows.Forms.DockStyle.Fill;
        //    lst.Items.Clear();
        //    this.listform = new System.Windows.Forms.Form();
        //    //用窗口显示			
        //    try
        //    {
        //        //this.listform.Close();
        //    }
        //    catch { }
        //    listform.Size = new Size(300, 200);
        //    listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        //    Neusoft.HISFC.Models.Base.Employee user = this.orderManagement.Operator as Neusoft.HISFC.Models.Base.Employee;
        //    Neusoft.HISFC.BizLogic.Manager.Department managerDept = new Neusoft.HISFC.BizLogic.Manager.Department();
        //    for (int i = 0; i < this.alSeeNo.Count; i++)
        //    {
        //        Neusoft.FrameWork.Models.NeuObject obj;
        //        obj = (Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[i];
        //        bool b = false;
        //        if (this.isRestrictOwnDept)//过滤病区－科室
        //        {
        //            b = false;
        //            if (user.EmployeeType.ID.ToString() == "N")//护士站
        //            {
        //                Neusoft.FrameWork.Models.NeuObject dept = new Neusoft.FrameWork.Models.NeuObject();
        //                ArrayList alDept = managerDept.GetDeptFromNurseStation(user.Nurse);
        //                if (alDept == null)
        //                {

        //                }
        //                else
        //                {
        //                    for (int k = 0; k < alDept.Count; i++)
        //                    {
        //                        dept = alDept[k] as Neusoft.FrameWork.Models.NeuObject;
        //                        if (dept.ID == obj.User01)
        //                        {
        //                            b = true;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                if (user.Dept.ID == obj.User01)//科室对应上
        //                {
        //                    b = true;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            b = true;
        //        }
        //        if (b)
        //        {
        //            //显示看诊序号，姓名，看诊日期（去掉时间）,看诊科室
        //            try
        //            {
        //                lst.Items.Add(obj.ID + "  " + obj.Name + "  " + obj.User02 + "  " + obj.Memo.Substring(0, obj.Memo.IndexOf(" ")) + "  " + obj.User03);//+"  " + managerDept.GetDeptmentById(obj.User01).Name);
        //            }
        //            catch
        //            {
        //                lst.Items.Add(obj.ID + "  " + obj.Name + "  " + obj.User02 + "  " + obj.Memo + "  " + obj.User03);
        //            }
        //            this.strSeeNo = obj.ID;
        //        }
        //    }
        //    if (lst.Items.Count == 1)
        //    {
        //        try
        //        {
        //            this.listform.Close();

        //        }
        //        catch { }
        //        try
        //        {
        //            this.Text = this.strSeeNo.Substring(4, 10);
        //            this.myEvents();
        //        }
        //        catch { }
        //        return;
        //    }
                        
        //    if (lst.Items.Count <= 0)
        //    {
        //        this.strSeeNo = "";
        //        this.myEvents();
        //        return;
        //    }

        //    lst.Visible = true;
        //    lst.DoubleClick += new EventHandler(lst_DoubleClick);
        //    lst.KeyDown += new KeyEventHandler(lst_KeyDown);
        //    lst.Show();

        //    listform.Controls.Add(lst);

        //    listform.TopMost = true;

        //    listform.Show();
        //    listform.Location = this.txtInputCode.PointToScreen(new Point(this.txtInputCode.Width / 2 + this.txtInputCode.Left, this.txtInputCode.Height + this.txtInputCode.Top));
        //    try
        //    {
        //        lst.SelectedIndex = 0;
        //        lst.Focus();
        //        lst.LostFocus += new EventHandler(lst_LostFocus);
        //    }
        //    catch { }
        //    return;
        //}
        //private string formatInputCode(string Text)
        //{

        //    string strText = Text;
        //    try
        //    {
        //        for (int i = 0; i < this.intLength - strText.Length; i++)
        //        {
        //            Text = "0" + Text;
        //        }
        //        string strDateTime = "";
        //        try
        //        {
        //            strDateTime = this.orderManagement.GetSysDateNoBar();
        //        }
        //        catch { }
        //        switch (this.intDateType)
        //        {
        //            case 1:
        //                strDateTime = strDateTime.Substring(2);
        //                Text = strDateTime + Text.Substring(strDateTime.Length);
        //                break;
        //            case 2:
        //                Text = strDateTime + Text.Substring(strDateTime.Length);
        //                break;
        //        }
        //        if (this.strFormatHeader != "") Text = this.strFormatHeader + Text.Substring(this.strFormatHeader.Length);
        //    }
        //    catch { }
        //    //日期   
        //    return Text;
        //}


        //private void lst_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GetInfo();
        //    }
        //    catch { }
        //}

        //private void lst_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        GetInfo();
        //    }
        //}
        //private void GetInfo()
        //{
        //    try
        //    {
        //        Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                
        //        obj.ID = lst.Items[lst.SelectedIndex].ToString();
        //        this.strSeeNo = obj.ID.Substring(0, obj.ID.IndexOf(" "));//(0,14) ;
        //        char[] strRev = obj.ID.ToCharArray();
        //        System.Array.Reverse(strRev);
        //        string revStr = new string(strRev);
        //        revStr = revStr.Substring(0, revStr.IndexOf(" "));
        //        strRev = revStr.ToCharArray();
        //        System.Array.Reverse(strRev);
        //        this.clinicCode = new string(strRev);
        //        try
        //        {
        //            this.listform.Hide();
        //        }
        //        catch
        //        {

        //        }
        //        try
        //        {
        //            this.myEvents();
        //        }
        //        catch { }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString()); NoInfo(); }
        //}
        //private void NoInfo()
        //{
        //    this.txtInputCode.Text = "";
        //    this.txtInputCode.Focus();
        //}

        //private void ucQuerySeeNoByCardNo_Load(object sender, System.EventArgs e)
        //{
            
        //    try
        //    {
        //        Neusoft.HISFC.BizLogic.Manager.Controler myCtrl = new Neusoft.HISFC.BizLogic.Manager.Controler();
        //        this.validDays = Neusoft.FrameWork.Function.NConvert.ToInt32(myCtrl.QueryControlerInfo("MZ0014"));
                
        //    }
        //    catch
        //    { }
        //}


        //private void lst_LostFocus(object sender, EventArgs e)
        //{
        //    this.listform.Hide();
        //    if (this.strSeeNo == "") NoInfo();
        //}

        //#endregion

        //#region 查询
        //protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration patient = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        //protected void query()
        //{
        //    this.Err = "";
        //    this.alSeeNo.Clear();
        //    #region 门诊号查
        //    if (this.inputtype == 0)
        //    {
        //        this.Text = this.formatInputCode(this.Text).Trim();	//格式化
        //        try
        //        {
                    
        //            DateTime dtNow = this.orderManagement.GetDateTimeFromSysDateTime();
        //            ArrayList alReg = patient.Query(this.Text, dtNow.AddDays(-this.validDays));
                                        
        //            if (alReg == null || alReg.Count <= 0)
        //            {
        //                MessageBox.Show("没有查找到该患者在有效时间内的挂号信息");
        //                return;
        //            }
                    
        //            else
        //            {
        //                for (int i = 0; i < alReg.Count; i++)
        //                {
        //                    Neusoft.HISFC.Models.Registration.Register obj = alReg[i] as Neusoft.HISFC.Models.Registration.Register;
        //                    this.myRegister = obj;//在控件外面重新获得挂号信息
        //                    Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();
        //                    if (obj.DoctorInfo.SeeDate.Date == dtNow.Date)
        //                    {
        //                        o.ID = "新";
        //                        o.Memo = "今天";
        //                    }
        //                    else
        //                    {
        //                        o.ID = "";
        //                        o.Memo = obj.DoctorInfo.SeeDate.ToString("yyyy年MM月dd日");
        //                    }
        //                    o.Name = obj.Name + "(" + obj.InvoiceNO + ")";  //添加了处方号,方便医生确认
        //                    o.User02 = obj.DoctorInfo.Templet.Dept.Name;
        //                    o.User03 = obj.ID;//门诊流水号
                            
        //                    o.User01 = ((Neusoft.HISFC.Models.Base.Employee)this.orderManagement.Operator).Dept.ID;
        //                    this.alSeeNo.Insert(0, o);
        //                }
        //            }
        //            if (this.alSeeNo == null)
        //            {
        //                this.Err = "未查找到该门诊号！";
        //                return;
        //            }
        //            if (this.alSeeNo.Count == 1)
        //            {
        //                this.strSeeNo = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).ID;
                        
        //                this.clinicCode = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).User03;
        //                this.Register.ID = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).User03;
        //            }
        //            else if (this.alSeeNo.Count <= 0)
        //            {
        //                this.Err = "未查找到该门诊号！";
        //                this.strSeeNo = "";
        //                NoInfo();
        //            }
        //            else
        //            {
        //                this.strSeeNo = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).ID;
        //                this.SelectPatient();
        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            this.Err = ex.Message;
        //            NoInfo();
        //        }
        //        try
        //        {
        //            if (this.listform != null)
        //            {
        //                this.listform.Close();
        //            }
        //        }
        //        catch { }
        //        try
        //        {
        //            this.myEvents();
        //        }
        //        catch { }
        //    }
        //    #endregion

        //}
        //#endregion

        #endregion

    }
}

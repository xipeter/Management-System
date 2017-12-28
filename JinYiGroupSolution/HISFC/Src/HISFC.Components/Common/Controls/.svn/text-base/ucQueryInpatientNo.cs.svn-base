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

    public delegate void myEventDelegate();

    /// <summary>
    /// txtQueryInpatientNo 的摘要说明。
    /// 查询住院流水号控件
    /// 输出：InpatientNos
    ///		  InpatientNo
    ///	环境：需要父窗体继承baseForm的类。	  
    /// </summary>
    public partial class ucQueryInpatientNo : UserControl
    {
        public ucQueryInpatientNo()
        {
            InitializeComponent();
            Inpatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
        }

        #region 私有变量
        private ArrayList alInpatientNos;
        private string strInpatientNo;
        private Neusoft.HISFC.BizLogic.RADT.InPatient Inpatient = null;
        private System.Windows.Forms.Form listform;
        private System.Windows.Forms.ListBox lst;

        private string strFormatHeader = "";
        private int intDateType = 0;
        private int intLength = 10;
        #endregion

        #region 可控制公有属性、方法
        protected int inputtype = 0;//当前输入类型
        /// <summary>
        /// 输入类型
        /// </summary>
        public int InputType
        {
            get
            {
                return this.inputtype;
            }
            set
            {
                if (value >= 5) value = 0;
                this.inputtype = value;
                switch (inputtype)
                {
                    //住院号
                    case 0:
                        this.txtInputCode.BackColor = Color.White;
                        this.label1.Text = "住院号:";
                        this.tooltip.SetToolTip(txtInputCode, "当前输入住院号查询！\n按F2切换查询方式！");
                        break;
                    //病床
                    case 1:
                        this.label1.Text = "病床:";
                        this.txtInputCode.BackColor = Color.FromArgb(255, 220, 220); ;
                        this.tooltip.SetToolTip(txtInputCode, "当前输入病床号查询！\n按F2切换查询方式！");
                        break;
                    //姓名
                    case 2:
                        this.label1.Text = "姓名:";
                        this.txtInputCode.BackColor = Color.FromArgb(255, 190, 190);
                        this.tooltip.SetToolTip(txtInputCode, "当前输入姓名查询！\n按F2切换查询方式！");
                        break;
                    //
                    case 3:
                        this.label1.Text = "生育保险号:";
                        //						this.txtInputCode.BackColor =Color.FromArgb(255,150,150);
                        this.tooltip.SetToolTip(txtInputCode, "当前输入姓名查询！\n按F2切换查询方式！");
                        break;
                    case 4:
                        this.label1.Text = "医疗证号:";
                        //						this.txtInputCode.BackColor =Color.FromArgb(255,100,100);
                        this.tooltip.SetToolTip(txtInputCode, "当前输入姓名查询！\n按F2切换查询方式！");
                        break;
                    default:
                        this.label1.Text = "住院号:";
                        this.txtInputCode.BackColor = Color.White;
                        this.tooltip.SetToolTip(txtInputCode, "当前输入住院号查询！\n按F2切换查询方式！");
                        break;
                }
                this.tooltip.Active = true;
            }
        }

        protected ToolTip tooltip = new ToolTip();
        /// <summary>
        /// 限制
        /// </summary>
        protected bool isRestrictOwnDept = false;

        /// <summary>
        /// 是否限制本科室患者
        /// </summary>
        public bool IsRestrictOwnDept
        {
            set
            {
                this.isRestrictOwnDept = value;
            }
        }
       
        /// <summary>
        /// 录入住院号文本格式化—补零（参数：住院号长度）
        /// </summary>
        /// <param name="Length"></param>
        public void SetFormat(int Length)
        {
            this.SetFormat("", 0, Length);
        }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Err;
        /// <summary>
        /// 返回信息事件
        /// </summary>
        public event myEventDelegate myEvent;
        /// <summary>
        /// 得到多条住院流水号信息数组
        /// </summary>
        public ArrayList InpatientNos
        {
            get
            {
                return this.alInpatientNos;
            }
        }
        protected enuShowState myShowState = enuShowState.All;
        /// <summary>
        /// 显示患者状态
        /// </summary>
        public enuShowState ShowState
        {
            get
            {
                return this.myShowState;
            }
            set
            {
                this.myShowState = value;
            }
        }
        /// <summary>
        /// 得到一条住院流水号信息
        /// </summary>
        public string InpatientNo
        {
            get
            {
                return this.strInpatientNo;
            }
        }

        /// <summary>
        /// 住院号文本录入属性
        /// </summary>
        public new string Text
        {
            get
            {
                return this.txtInputCode.Text;
            }
            set
            {
                this.txtInputCode.Text = value;
            }
        }
        /// <summary>
        /// 当前输入的文本控件
        /// </summary>
        public TextBox TextBox
        {
            get
            {
                return this.txtInputCode;
            }
           
        }
        /// <summary>
        /// 当前label控件
        /// </summary>
        public Label Label
        {
            get { return this.label1; }
           
        }

        private bool isCanChangeInputType = true;
        /// <summary>
        /// 是否允许F2变换输入方式
        /// </summary>
        public bool IsCanChangeInputType
        {
            set
            {
                this.isCanChangeInputType = value;
            }
        }
        /// <summary>
        /// 前空白，来控制Label的文字
        /// </summary>
        public int LabelMarginLeft
        {
            set
            {
                this.label1.Left = value;
            }
        }

        /// <summary>
        /// 录入住院号文本格式化—加字头（参数：字头字符；住院号长度）
        /// </summary>
        /// <param name="Header"></param>
        /// <param name="Length"></param>
        public void SetFormat(string Header, int Length)
        {
            this.SetFormat(Header, 0, Length);
        }
        /// <summary>
        /// 录入住院号文本格式化—加字头添加日期（参数：字头字符；时间；住院号长度）
        /// </summary>
        /// <param name="Header"></param>
        /// <param name="DateType"></param>
        /// <param name="Length"></param>
        public void SetFormat(string Header, int DateType, int Length)
        {
            this.intLength = Length;
            this.strFormatHeader = Header;
            this.intDateType = DateType;
        }
        /// <summary>
        /// 
        /// </summary>
        public new void Focus()
        {
            this.txtInputCode.SelectAll();
            this.txtInputCode.Focus();
        }
        #endregion

        /// <summary>
        /// Label 字体颜色
        /// </summary>
        public System.Drawing.Color LabelColor
        {
            set
            {
                this.label1.ForeColor = value;
            }
        }

        #region 不可控制私有属性、方法

        private void txtInputCode_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtInputCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    query();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    if(isCanChangeInputType)
                        this.InputType++;
                }
                else if (e.KeyCode == Keys.Space)
                {
                    query();
                }
            }
            catch { }
        }
        private void SelectPatient()
        {
            lst = new ListBox();
            lst.Dock = System.Windows.Forms.DockStyle.Fill;

            this.listform = new System.Windows.Forms.Form();
            //用窗口显示			
            try
            {
                //this.listform.Close();
            }
            catch { }
            listform.Size = new Size(200, 100);
            listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Neusoft.HISFC.Models.Base.Employee user = new Neusoft.HISFC.Models.Base.Employee();
            Neusoft.HISFC.BizLogic.Manager.Department managerDept = new Neusoft.HISFC.BizLogic.Manager.Department();
            for (int i = 0; i < this.alInpatientNos.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj;
                obj = (Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[i];
                Neusoft.HISFC.Models.RADT.InStateEnumService VisitStatus = new Neusoft.HISFC.Models.RADT.InStateEnumService();
                VisitStatus.ID = obj.Memo;
                bool b = false;
                switch (this.myShowState)//过滤患者状态
                {
                    case enuShowState.InHos:
                        if (obj.Memo == "I") b = true;
                        break;
                    case enuShowState.OutHos:
                        if (obj.Memo == "B" || obj.Memo == "O" || obj.Memo == "P" || obj.Memo == "N") b = true;
                        break;
                    case enuShowState.BeforeArrived:
                        if (obj.Memo == "R") b = true;
                        break;
                    case enuShowState.AfterArrived:
                        if (obj.Memo != "R") b = true;
                        break;
                    case enuShowState.InhosBeforBalanced:
                        if (obj.Memo == "B" || obj.Memo == "I" || obj.Memo == "P" || obj.Memo == "R") b = true;
                        break;
                    case enuShowState.InhosAfterBalanced:
                        if (obj.Memo == "O") b = true;
                        break;
                    case enuShowState.InBalanced:
                        if (obj.Memo == "B") b = true;
                        break;
                    default:
                        b = true;
                        break;
                }
                if (b && this.isRestrictOwnDept)//过滤病区－科室
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
                if (b)
                {
                    //显示住院流水号，姓名，在院状态
                    try
                    {
                        lst.Items.Add(obj.ID + "  " + obj.Name + "  " + VisitStatus.Name);
                    }
                    catch
                    {
                        lst.Items.Add(obj.ID + "  " + obj.Name + "  " + obj.Memo);

                    }
                    this.strInpatientNo = obj.ID;
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
                    this.Text = this.strInpatientNo.Substring(4, 10);
                    this.myEvent();
                }
                catch { }
                return;
            }

            //			if(lst.Items.Count <=0) return;
            if (lst.Items.Count <= 0)
            {
                this.strInpatientNo = "";
                this.myEvent();
                return;
            }

            lst.Visible = true;
            lst.DoubleClick += new EventHandler(lst_DoubleClick);
            lst.KeyDown += new KeyEventHandler(lst_KeyDown);
            lst.Show();

            listform.Controls.Add(lst);

            listform.TopMost = true;

            listform.Show();
            listform.Location = this.txtInputCode.PointToScreen(new Point(this.txtInputCode.Width / 2 + this.txtInputCode.Left, this.txtInputCode.Height + this.txtInputCode.Top));
            try
            {
                lst.SelectedIndex = 0;
                lst.Focus();
                lst.LostFocus += new EventHandler(lst_LostFocus);
            }
            catch { }
            return;
        }
        private string formatInputCode(string Text)
        {

            string strText = Text;
            try
            {
                for (int i = 0; i < this.intLength - strText.Length; i++)
                {
                    Text = "0" + Text;
                }
                string strDateTime = "";
                try
                {
                    strDateTime = this.Inpatient.GetSysDateNoBar();
                }
                catch { }
                switch (this.intDateType)
                {
                    case 1:
                        strDateTime = strDateTime.Substring(2);
                        Text = strDateTime + Text.Substring(strDateTime.Length);
                        break;
                    case 2:
                        Text = strDateTime + Text.Substring(strDateTime.Length);
                        break;
                }
                if (this.strFormatHeader != "") Text = this.strFormatHeader + Text.Substring(this.strFormatHeader.Length);
            }
            catch { }
            //日期   
            return Text;
        }


        private void lst_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GetInfo();
            }
            catch { }
        }

        private void lst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInfo();
            }
        }
        private void GetInfo()
        {
            try
            {
                Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
                //				obj=(Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[lst.SelectedIndex];
                obj.ID = lst.Items[lst.SelectedIndex].ToString();
                this.strInpatientNo = obj.ID.Substring(0, 14);
                if (this.InputType != 3 && this.InputType != 4)
                {
                    this.Text = obj.ID.Substring(4, 10);
                }
                try
                {
                    this.listform.Hide();
                }
                catch
                {

                }
                try
                {
                    this.myEvent();
                }
                catch { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); NoInfo(); }
        }
        private void NoInfo()
        {
            this.txtInputCode.Text = "";
            this.txtInputCode.Focus();
        }

        private void txtQueryInpatientNo_Load(object sender, System.EventArgs e)
        {
            //			InputType =0;	

        }


        private void lst_LostFocus(object sender, EventArgs e)
        {
            this.listform.Hide();
            if (this.strInpatientNo == "") NoInfo();
        }

        #endregion

        #region 查询
        public void query()
        {
            this.Err = "";
            #region 住院号查
            if (this.inputtype == 0)
            {
                this.Text = this.formatInputCode(this.Text).Trim();
                try
                {
                    this.alInpatientNos = this.Inpatient.QueryInpatientNOByPatientNO(this.Text,true);
                    if (this.alInpatientNos == null)
                    {
                        this.Err = "未查找到该住院号！";
                        return;
                    }
                    if (this.alInpatientNos.Count == 1)
                    {
                        bool b = false;
                        Neusoft.FrameWork.Models.NeuObject obj = alInpatientNos[0] as Neusoft.FrameWork.Models.NeuObject;
                        switch (this.myShowState)//过滤患者状态
                        {
                            case enuShowState.InHos:
                                if (obj.Memo == "I") b = true;
                                break;
                            case enuShowState.OutHos:
                                if (obj.Memo == "B" || obj.Memo == "O" || obj.Memo == "P" || obj.Memo == "N") b = true;
                                break;
                            case enuShowState.BeforeArrived:
                                if (obj.Memo == "R") b = true;
                                break;
                            case enuShowState.AfterArrived:
                                if (obj.Memo != "R") b = true;
                                break;
                            case enuShowState.InhosBeforBalanced:
                                if (obj.Memo == "B" || obj.Memo == "I" || obj.Memo == "P" || obj.Memo == "R") b = true;
                                break;
                            case enuShowState.InhosAfterBalanced:
                                if (obj.Memo == "O") b = true;
                                break;
                            case enuShowState.InBalanced:
                                if (obj.Memo == "B") b = true;
                                break;
                            default:
                                b = true;
                                break;
                        }
                        if (b) this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        else
                        {
                            this.Err = "未查找到该住院号！";
                            this.strInpatientNo = "";
                            NoInfo();
                        }
                    }
                    else if (this.alInpatientNos.Count <= 0)
                    {
                        this.Err = "未查找到该住院号！";
                        this.strInpatientNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        this.SelectPatient();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    NoInfo();
                }
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    if (this.myEvent != null)
                        this.myEvent();
                }
                catch(Exception ee) {
                    MessageBox.Show(ee.Message);
                }
            }
            #endregion
            #region 病床号查
            if (this.inputtype == 1)
            {
                try
                {
                    this.alInpatientNos = this.Inpatient.QueryInpatientNOByBedNO(this.Text);
                    if (this.alInpatientNos == null)
                    {
                        this.Err = "未查找到该病床号！";
                        return;
                    }
                    if (this.alInpatientNos.Count == 1)
                    { this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID; }
                    else if (this.alInpatientNos.Count <= 0)
                    {
                        this.Err = "未查找到该病床号！";
                        this.strInpatientNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        this.SelectPatient();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    NoInfo();
                }
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    if (this.myEvent != null)
                        this.myEvent();
                }
                catch { }
            }
            #endregion
            #region 姓名查
            if (this.inputtype == 2)
            {
                try
                {
                    this.alInpatientNos = this.Inpatient.QueryInpatientNOByName(this.Text);
                    if (this.alInpatientNos == null)
                    {
                        this.Err = "未查找到该病床号！";
                        return;
                    }
                    if (this.alInpatientNos.Count == 1)
                    { this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID; }
                    else if (this.alInpatientNos.Count <= 0)
                    {
                        this.Err = "未查找到该病床号！";
                        this.strInpatientNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        this.SelectPatient();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    NoInfo();
                }
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    if (this.myEvent != null)
                        this.myEvent();
                }
                catch { }
            }
            #endregion
            #region 按生育保险号查
            if (this.inputtype == 3)
            {
                try
                {
                    this.alInpatientNos = this.Inpatient.PatientQueryByPcNoRetArray("", this.Text);
                    if (this.alInpatientNos == null)
                    {
                        this.Err = "未查找到该保险号！";
                        return;
                    }
                    if (this.alInpatientNos.Count == 1)
                    {
                        bool b = false;
                        Neusoft.FrameWork.Models.NeuObject obj = alInpatientNos[0] as Neusoft.FrameWork.Models.NeuObject;
                        switch (this.myShowState)//过滤患者状态
                        {
                            case enuShowState.InHos:
                                if (obj.Memo == "I") b = true;
                                break;
                            case enuShowState.OutHos:
                                if (obj.Memo == "B" || obj.Memo == "O" || obj.Memo == "P" || obj.Memo == "N") b = true;
                                break;
                            case enuShowState.BeforeArrived:
                                if (obj.Memo == "R") b = true;
                                break;
                            case enuShowState.AfterArrived:
                                if (obj.Memo != "R") b = true;
                                break;
                            case enuShowState.InhosBeforBalanced:
                                if (obj.Memo == "B" || obj.Memo == "I" || obj.Memo == "P" || obj.Memo == "R") b = true;
                                break;
                            case enuShowState.InhosAfterBalanced:
                                if (obj.Memo == "O") b = true;
                                break;
                            case enuShowState.InBalanced:
                                if (obj.Memo == "B") b = true;
                                break;
                            default:
                                b = true;
                                break;
                        }
                        if (b) this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        else
                        {
                            this.Err = "未查找到该住院号！";
                            this.strInpatientNo = "";
                            NoInfo();
                        }
                    }
                    else if (this.alInpatientNos.Count <= 0)
                    {
                        this.Err = "未查找到该保险号！";
                        this.strInpatientNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        this.SelectPatient();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    NoInfo();
                }
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    if (this.myEvent != null)
                        this.myEvent();
                }
                catch { }
            }
            #endregion
            #region 按电脑号查

            if (this.inputtype == 4)
            {
                try
                {
                    this.alInpatientNos = this.Inpatient.PatientQueryByPcNoRetArray(this.Text, "");
                    if (this.alInpatientNos == null)
                    {
                        this.Err = "未查找到该电脑号！";
                        return;
                    }
                    if (this.alInpatientNos.Count == 1)
                    {
                        bool b = false;
                        Neusoft.FrameWork.Models.NeuObject obj = alInpatientNos[0] as Neusoft.FrameWork.Models.NeuObject;
                        switch (this.myShowState)//过滤患者状态
                        {
                            case enuShowState.InHos:
                                if (obj.Memo == "I") b = true;
                                break;
                            case enuShowState.OutHos:
                                if (obj.Memo == "B" || obj.Memo == "O" || obj.Memo == "P" || obj.Memo == "N") b = true;
                                break;
                            case enuShowState.BeforeArrived:
                                if (obj.Memo == "R") b = true;
                                break;
                            case enuShowState.AfterArrived:
                                if (obj.Memo != "R") b = true;
                                break;
                            case enuShowState.InhosBeforBalanced:
                                if (obj.Memo == "B" || obj.Memo == "I" || obj.Memo == "P" || obj.Memo == "R") b = true;
                                break;
                            case enuShowState.InhosAfterBalanced:
                                if (obj.Memo == "O") b = true;
                                break;
                            case enuShowState.InBalanced:
                                if (obj.Memo == "B") b = true;
                                break;
                            default:
                                b = true;
                                break;
                        }
                        if (b) this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        else
                        {
                            this.Err = "未查找到该住院号！";
                            this.strInpatientNo = "";
                            NoInfo();
                        }
                    }
                    else if (this.alInpatientNos.Count <= 0)
                    {
                        this.Err = "未查找到该电脑号！";
                        this.strInpatientNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strInpatientNo = ((Neusoft.FrameWork.Models.NeuObject)this.alInpatientNos[0]).ID;
                        this.SelectPatient();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.Err = ex.Message;
                    NoInfo();
                }
                try
                {
                    this.listform.Close();

                }
                catch { }
                try
                {
                    if(this.myEvent!=null)
                        this.myEvent();
                }
                catch { }
            }
            #endregion

        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum enuShowState
    {
        /// <summary>
        /// 全部患者
        /// </summary>
        All,
        /// <summary>
        /// 在院患者 接诊后-出院前
        /// </summary>
        InHos,
        /// <summary>
        /// 出院登记后
        /// </summary>
        OutHos,
        /// <summary>
        /// 接诊后
        /// </summary>
        AfterArrived,
        /// <summary>
        /// 接诊前
        /// </summary>
        BeforeArrived,
        /// <summary>
        /// 入院后结算前
        /// </summary>
        InhosBeforBalanced,
        /// <summary>
        /// 入院后结算后
        /// </summary>
        InhosAfterBalanced,
        /// <summary>
        /// 待结算状态
        /// </summary>
        InBalanced
    }
}

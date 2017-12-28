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
    public partial class ucQuerySeeNoByCardNo : UserControl
    {
        public ucQuerySeeNoByCardNo()
        {
            InitializeComponent();
        }

        #region ˽�б���
        private ArrayList alSeeNo = new ArrayList();
        private string strSeeNo = "-1";
        private string clinicCode = "";//������ˮ��
        private Neusoft.HISFC.BizLogic.Order.OutPatient.Order orderManagement = new Neusoft.HISFC.BizLogic.Order.OutPatient.Order();
        private System.Windows.Forms.Form listform;
        private System.Windows.Forms.ListBox lst;
        private bool isDoctRegistration = false;
        private string strFormatHeader = "";
        private int intDateType = 0;
        private int intLength = 10;
        private int validDays = 1;//�Һ���Ч����
        private bool isICCard = false;//�Ƿ�ˢ������������Ϣ{18DEBFA3-0364-4730-8416-ECA87F3235FF}
        #endregion

        #region �ɿ��ƹ������ԡ�����
        //{18DEBFA3-0364-4730-8416-ECA87F3235FF}
        public bool IsICCard
        {
            get { return isICCard; }
            set { isICCard = value; }
        }
        protected int inputtype = 0;//��ǰ��������
        /// <summary>
        /// ��������
        /// </summary>
        public int InputType
        {
            get
            {
                return this.inputtype;
            }
            set
            {
                if (value >= 1) value = 0;
                this.inputtype = value;
                switch (inputtype)
                {
                    //�����
                    case 0:
                        this.txtInputCode.BackColor = Color.White;
                        this.neuLabel1.Text = "�����:";
                        this.tooltip.SetToolTip(txtInputCode, "��ǰ��������Ų�ѯ��\n��F2�л���ѯ��ʽ��");
                        break;
                    //����
                    //					case 1:
                    //						this.label1.Text ="����:";
                    //						this.txtInputCode.BackColor =Color.FromArgb(255,190,190);
                    //						this.tooltip.SetToolTip(txtInputCode,"��ǰ����������ѯ��\n��F2�л���ѯ��ʽ��");
                    //						break;
                    default:
                        this.neuLabel1.Text = "�����:";
                        this.txtInputCode.BackColor = Color.White;
                        this.tooltip.SetToolTip(txtInputCode, "��ǰ��������Ų�ѯ��");
                        break;
                }
                this.tooltip.Active = true;
            }
        }

        protected ToolTip tooltip = new ToolTip();
        /// <summary>
        /// ����
        /// </summary>
        protected bool isRestrictOwnDept = false;
        
        /// <summary>
        /// �Ƿ����Ʊ����һ���
        /// </summary>
        public bool IsRestrictOwnDept
        {
            set
            {
                this.isRestrictOwnDept = value;
            }
        }
        
        /// <summary>
        /// ¼��������ı���ʽ�������㣨����������ų��ȣ�
        /// </summary>
        /// <param name="Length"></param>
        public void SetFormat(int Length)
        {
            this.SetFormat("", 0, Length);
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Err;
        /// <summary>
        /// ������Ϣ�¼�
        /// </summary>
        public event  Controls.myEventDelegate myEvents;
        /// <summary>
        /// �õ��������������Ϣ����
        /// </summary>
        public ArrayList SeeNos
        {
            get
            {
                return this.alSeeNo;
            }
        }

        /// <summary>
        /// �õ�һ�����������Ϣ
        /// </summary>
        public string SeeNo
        {
            get
            {
                if (this.strSeeNo == "��" || this.strSeeNo.Trim() == "") this.strSeeNo = "-1";
                return this.strSeeNo;
            }
        }
        public string ClinicCode
        {
            get
            {
                return this.clinicCode;
            }
        }
        /// <summary>
        /// ������ı�¼������
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
        /// ��ǰ������ı��ؼ�
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuTextBox TextBox
        {
            get
            {
                return this.txtInputCode;
            }
            set
            {
                this.txtInputCode = value;
            }
        }
        /// <summary>
        /// ��ǰlabel�ؼ�
        /// </summary>
        public Neusoft.FrameWork.WinForms.Controls.NeuLabel Label
        {
            get { return this.neuLabel1; }
            set { this.neuLabel1 = value; }
        }
        /// <summary>
        /// ¼��������ı���ʽ��������ͷ����������ͷ�ַ�������ų��ȣ�
        /// </summary>
        /// <param name="Header"></param>
        /// <param name="Length"></param>
        public void SetFormat(string Header, int Length)
        {
            this.SetFormat(Header, 0, Length);
        }
        /// <summary>
        /// ¼��������ı���ʽ��������ͷ�������ڣ���������ͷ�ַ���ʱ�䣻����ų��ȣ�
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
        /// �۽�
        /// </summary>
        public new void Focus()
        {
            this.txtInputCode.SelectAll();
            this.txtInputCode.Focus();
        }
        private Neusoft.HISFC.Models.Registration.Register myRegister = new Neusoft.HISFC.Models.Registration.Register();
        /// <summary>
        /// ��ǰ�Ǽ���Ϣ
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Neusoft.HISFC.Models.Registration.Register Register
        {
            get
            {
                
                this.myRegister.DoctorInfo.SeeNO = int.Parse(this.SeeNo);
                if (this.clinicCode != "")
                {
                    this.myRegister.ID = this.clinicCode;
                }
                return this.myRegister;
            }
            set
            {
                this.myRegister = value;
            }
        }

        public bool IsDoctRegistration
        {
            get 
            {
                return this.isDoctRegistration;
            }
        }
        #endregion

        /// <summary>
        /// Label ������ɫ
        /// </summary>
        public System.Drawing.Color LabelColor
        {
            set
            {
                this.neuLabel1.ForeColor = value;
            }
        }

        #region ���ɿ���˽�����ԡ�����

        private void txtInputCode_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void txtInputCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.isDoctRegistration)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        string cardNO = this.txtInputCode.Text.Trim();
                        if (cardNO.StartsWith("/") || cardNO.StartsWith("+"))
                        {
                            DialogResult r = MessageBox.Show("�Ƿ�Ϊ�û��߲���Һ���Ϣ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (r == DialogResult.Yes)
                            {
                                string name = cardNO.Remove(0, 1);
                                Forms.frmRegistrationByDoctor frmDoctRegistration = new Forms.frmRegistrationByDoctor(name);
                                frmDoctRegistration.ShowDialog();
                                this.myRegister = frmDoctRegistration.PatientInfo;
                                if (this.myRegister.ID == "" || this.myRegister.ID == null)
                                {
                                    this.NoInfo();
                                }
                                else
                                {
                                    this.txtInputCode.Text = myRegister.PID.CardNO;
                                    this.myEvents();
                                }
                            }
                            else
                            {
                                this.NoInfo();
                            }
                        }
                        else
                        {
                            this.query();
                        }
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        this.InputType++;
                    }
                    else if (e.KeyCode == Keys.Space)
                    {
                        this.query();
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.query();
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        this.InputType++;
                    }
                    else if (e.KeyCode == Keys.Space)
                    {
                        this.query();
                    }
                }
                catch { }
            }
        }
        private void SelectPatient()
        {
            lst = new ListBox();
            lst.Dock = System.Windows.Forms.DockStyle.Fill;
            lst.Items.Clear();
            this.listform = new System.Windows.Forms.Form();
            //�ô�����ʾ			
            try
            {
                //this.listform.Close();
            }
            catch { }
            listform.Size = new Size(300, 200);
            listform.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Neusoft.HISFC.Models.Base.Employee user = this.orderManagement.Operator as Neusoft.HISFC.Models.Base.Employee;
            Neusoft.HISFC.BizLogic.Manager.Department managerDept = new Neusoft.HISFC.BizLogic.Manager.Department();
            for (int i = 0; i < this.alSeeNo.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj;
                obj = (Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[i];
                bool b = false;
                if (this.isRestrictOwnDept)//���˲���������
                {
                    b = false;
                    if (user.EmployeeType.ID.ToString() == "N")//��ʿվ
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
                        if (user.Dept.ID == obj.User01)//���Ҷ�Ӧ��
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
                    //��ʾ������ţ��������������ڣ�ȥ��ʱ�䣩,�������
                    try
                    {
                        lst.Items.Add(obj.ID + "  " + obj.Name + "  " + obj.User02 + "  " + obj.Memo.Substring(0, obj.Memo.IndexOf(" ")) + "  " + obj.User03);//+"  " + managerDept.GetDeptmentById(obj.User01).Name);
                    }
                    catch
                    {
                        lst.Items.Add(obj.ID + "  " + obj.Name + "  " + obj.User02 + "  " + obj.Memo + "  " + obj.User03);
                    }
                    this.strSeeNo = obj.ID;
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
                    this.Text = this.strSeeNo.Substring(4, 10);
                    this.myEvents();
                }
                catch { }
                return;
            }
                        
            if (lst.Items.Count <= 0)
            {
                this.strSeeNo = "";
                this.myEvents();
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
                    strDateTime = this.orderManagement.GetSysDateNoBar();
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
            //����   
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
                
                obj.ID = lst.Items[lst.SelectedIndex].ToString();
                this.strSeeNo = obj.ID.Substring(0, obj.ID.IndexOf(" "));//(0,14) ;
                char[] strRev = obj.ID.ToCharArray();
                System.Array.Reverse(strRev);
                string revStr = new string(strRev);
                revStr = revStr.Substring(0, revStr.IndexOf(" "));
                strRev = revStr.ToCharArray();
                System.Array.Reverse(strRev);
                this.clinicCode = new string(strRev);
                try
                {
                    this.listform.Hide();
                }
                catch
                {

                }
                try
                {
                    this.myEvents();
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

        private void ucQuerySeeNoByCardNo_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                Neusoft.HISFC.BizLogic.Manager.Controler myCtrl = new Neusoft.HISFC.BizLogic.Manager.Controler();
                this.validDays = Neusoft.FrameWork.Function.NConvert.ToInt32(myCtrl.QueryControlerInfo("MZ0014"));
                this.isDoctRegistration = Neusoft.FrameWork.Function.NConvert.ToBoolean(myCtrl.QueryControlerInfo("200030"));
            }
            catch
            { }
        }


        private void lst_LostFocus(object sender, EventArgs e)
        {
            this.listform.Hide();
            if (this.strSeeNo == "") NoInfo();
        }

        #endregion

        #region ��ѯ
        protected Neusoft.HISFC.BizProcess.Integrate.Registration.Registration patient = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        protected Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        protected void query()
        {
            this.Err = "";
            this.alSeeNo.Clear();
            #region ����Ų�
            if (this.inputtype == 0)
            {
                if (isICCard)//{18DEBFA3-0364-4730-8416-ECA87F3235FF}
                {
                    Neusoft.HISFC.Models.Account.AccountCard acObj = new Neusoft.HISFC.Models.Account.AccountCard();
                    if (this.feeIntegrate.ValidMarkNO(this.Text.ToString(), ref acObj) != -1)
                    {
                        if (acObj != null)
                        {
                            this.Text = acObj.Patient.PID.CardNO;
                        }
                        else
                        {
                            MessageBox.Show("û�в��ҵ��û��ߵĹҺ���Ϣ");
                            return;
                        }
                    }     
                }
                else
                {
                    this.Text = this.formatInputCode(this.Text).Trim();	//��ʽ��
                }
                try
                {
                    //this.alSeeNo = this.orderManagement.QuerySeeNoListByCardNo(this.Text);

                    DateTime dtNow = this.orderManagement.GetDateTimeFromSysDateTime();
                    ArrayList alReg = patient.Query(this.Text, dtNow.AddDays(-this.validDays));
                                        
                    if (alReg == null || alReg.Count <= 0)
                    {
                        MessageBox.Show("û�в��ҵ��û�������Чʱ���ڵĹҺ���Ϣ");
                        return;
                    }
                    
                    else
                    {
                        for (int i = 0; i < alReg.Count; i++)
                        {
                            Neusoft.HISFC.Models.Registration.Register obj = alReg[i] as Neusoft.HISFC.Models.Registration.Register;
                            this.myRegister = obj;//�ڿؼ��������»�ùҺ���Ϣ
                            Neusoft.FrameWork.Models.NeuObject o = new Neusoft.FrameWork.Models.NeuObject();
                            if (obj.DoctorInfo.SeeDate.Date == dtNow.Date)
                            {
                                o.ID = "��";
                                o.Memo = "����";
                            }
                            else
                            {
                                o.ID = "";
                                o.Memo = obj.DoctorInfo.SeeDate.ToString("yyyy��MM��dd��");
                            }
                            o.Name = obj.Name + "(" + obj.InvoiceNO + ")";  //�����˴�����,����ҽ��ȷ��
                            o.User02 = obj.DoctorInfo.Templet.Dept.Name;
                            o.User03 = obj.ID;//������ˮ��
                            
                            o.User01 = ((Neusoft.HISFC.Models.Base.Employee)this.orderManagement.Operator).Dept.ID;
                            this.alSeeNo.Insert(0, o);
                        }
                    }
                    if (this.alSeeNo == null)
                    {
                        this.Err = "δ���ҵ�������ţ�";
                        return;
                    }
                    if (this.alSeeNo.Count == 1)
                    {
                        this.strSeeNo = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).ID;
                        
                        this.clinicCode = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).User03;
                        this.Register.ID = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).User03;
                    }
                    else if (this.alSeeNo.Count <= 0)
                    {
                        this.Err = "δ���ҵ�������ţ�";
                        this.strSeeNo = "";
                        NoInfo();
                    }
                    else
                    {
                        this.strSeeNo = ((Neusoft.FrameWork.Models.NeuObject)this.alSeeNo[0]).ID;
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
                    if (this.listform != null)
                    {
                        this.listform.Close();
                    }
                }
                catch { }
                try
                {
                    this.myEvents();
                }
                catch { }
            }
            #endregion

        }
        #endregion

        #region {6E95A004-5A76-4fb7-9217-81DE7897F079} ����ҽ��վ�������� by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        private bool ICInit = false;
        //ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        
        //private void btnReadCard_Click(object sender, EventArgs e)
        //{
        //    if (icreader.GetConnect())
        //    {
        //        cardno = icreader.ReaderICCard();
        //        if (cardno == "0000000000")
        //        {
        //            isNewCard = true;
        //            MessageBox.Show("�ÿ�δд�뿨�ţ����ֹ����뻼�߿��Ų��á��س�����ȡ������Ϣ��");
        //        }
        //        else
        //        {
        //            this.txtInputCode.Text = cardno;
        //            this.txtInputCode_KeyDown(this.txtInputCode, new KeyEventArgs(Keys.Enter));
        //        }
        //        icreader.CloseConnection();
        //    }
        //    else
        //    {
        //        MessageBox.Show("����ʧ�ܣ�");
        //    }
        //}
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                //this.btnReadCard_Click(this.btnReadCard, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
    }
}
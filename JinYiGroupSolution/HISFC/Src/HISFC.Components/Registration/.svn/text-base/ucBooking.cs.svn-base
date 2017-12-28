using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 预约挂号
    /// </summary>
    public partial class ucBooking : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucBooking()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucBooking_Load);
            this.txtCardNo.KeyDown += new KeyEventHandler(txtCardNo_KeyDown);
            this.txtName.KeyDown += new KeyEventHandler(txtName_KeyDown);
            this.txtPhone.KeyDown += new KeyEventHandler(txtPhone_KeyDown);
            this.txtIdenNo.KeyDown += new KeyEventHandler(txtIdenNo_KeyDown);
            this.txtAdress.KeyDown += new KeyEventHandler(txtAdress_KeyDown);
            this.cmbDept.KeyDown += new KeyEventHandler(cmbDept_KeyDown);
            this.cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);
            this.cmbDoct.KeyDown += new KeyEventHandler(cmbDoct_KeyDown);
            this.cmbDoct.SelectedIndexChanged += new EventHandler(cmbDoct_SelectedIndexChanged);
            this.dtBookingDate.ValueChanged += new EventHandler(dtBookingDate_ValueChanged);
            this.dtBookingDate.KeyDown += new KeyEventHandler(dtBookingDate_KeyDown);
            this.dtBegin.ValueChanged += new EventHandler(dtBegin_ValueChanged);
            this.dtBegin.KeyDown += new KeyEventHandler(dtBegin_KeyDown);
            this.dtEnd.ValueChanged += new EventHandler(dtEnd_ValueChanged);
            this.dtEnd.KeyDown += new KeyEventHandler(dtEnd_KeyDown);
            this.bnQuery.Click += new EventHandler(bnQuery_Click);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);
            
            this.label13.Click += new EventHandler(label13_Click);
            this.txtOrder.KeyDown += new KeyEventHandler(txtOrder_KeyDown);
            this.txtOrder.Validating += new CancelEventHandler(txtOrder_Validating);
        }

        #region 变量
        /// <summary>
        /// 门诊科室列表
        /// </summary>
        private ArrayList alDept = new ArrayList();
        /// <summary>
        /// 门诊医生列表
        /// </summary>
        private ArrayList alDoct = new ArrayList();
        /// <summary>
        /// 预约管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Booking bookingMgr = new Neusoft.HISFC.BizLogic.Registration.Booking();
        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Schema schemaMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 人员管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager Mgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        /// <summary>
        /// 挂号管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        /// <summary>
        /// 患者信息管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.RADT patMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        /// <summary>
        /// 预约实体类
        /// </summary>
        private Neusoft.HISFC.Models.Registration.Booking booking;
        
        /// <summary>
        /// 预约时间选择表
        /// </summary>
        private ucChooseBookingDate ucChooseDate;
        /// <summary>
        /// 是否触发SelectedIndexChanged事件
        /// </summary>
        private bool IsTriggerSelectedIndexChanged = true;

        /// <summary>
        /// 是否是IC卡号{733F00D5-E9FA-42d5-ADC5-B9309254A05E}
        /// </summary>
        private bool isICCard = false;

        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 是否是IC卡号{733F00D5-E9FA-42d5-ADC5-B9309254A05E}
        /// </summary>
        [Category("控件设置"), Description("是否以IC卡号检索")]
        public bool IsICCard
        {
            get
            {
                return isICCard;
            }
            set
            {
                isICCard = value;
                if (isICCard)
                {
                    label4.Text = "IC 卡 号：";
                }
                else
                {
                    label4.Text = "病 历 号：";
                }
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBooking_Load(object sender, EventArgs e)
        {
            this.InitDept();
            this.InitDoct();
            this.InitChooseDate();

            this.Clear();

            this.Retrieve();
            
            this.cmbDoct.Focus();
            this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
        }
        /// <summary>
        /// 根据病历号检索患者基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //{A47CE41F-3AC7-4289-AFB2-01DC5481F917}
                string CardNo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtCardNo.Text.Trim(), "'");

                //if (CardNo == "")
                //{
                //    MessageBox.Show("请输入病历号!", "提示");
                //    this.txtCardNo.Focus();
                //    return;
                //}

                this.ClearPatient();

                if (!string.IsNullOrEmpty(CardNo))
                {
                    CardNo = CardNo.PadLeft(10, '0');
                }

                if (isICCard)//{733F00D5-E9FA-42d5-ADC5-B9309254A05E}
                {
                    this.feeMgr.GetCardNoByMarkNo(CardNo, ref CardNo);
                    this.txtCardNo.Text = CardNo;
                }

                if (this.ValidCardNO(CardNo) < 0)
                {
                    this.txtCardNo.Focus();
                    return;
                }

                this.booking = this.getPatientInfo(CardNo);
                if (this.booking == null) return;

                //赋值
                this.SetPatient(this.booking);

                //if(this.booking.Name == null ||this.booking.Name.Trim() == "")
                //{
                this.txtName.Focus();
                //}
                //else
                //{
                //this.cmbDoct.Focus() ;
                //}
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }
        /// <summary>
        /// 姓名回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.txtPhone.Focus();
                this.setNextControlFocus();
            }
            else 
            if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        /// <summary>
        /// 电话回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //				if(this.txtPhone.Text == null || this.txtPhone.Text.Trim() == "")
                //				{
                //					MessageBox.Show("请输入患者联系电话!","提示") ;
                //					this.txtPhone.Focus() ;
                //					return ;
                //				}

                this.txtIdenNo.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        /// <summary>
        /// 身份证号回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIdenNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(this.txtIdenNo.Text.Trim()))
                {
                    if (this.ProcessIDENNO(this.txtIdenNo.Text.Trim(), EnumCheckIDNOType.BeforeSave) < 0)
                    {
                        return;
                    }
                }

                this.txtAdress.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        /// <summary>
        /// 地址回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAdress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Save();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        /// <summary>
        /// 科室回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //设定预约时间段,默认为今天				
                if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")//没有选择科室
                {
                    DateTime today = this.bookingMgr.GetDateTimeFromSysDateTime();

                    this.SetBookingDate(today);

                    //没有选择科室,医生列表显示全部医生
                    this.cmbDoct.AddItems(this.alDoct);
                    this.cmbDoct.Tag = "";
                    //设定预约时间段,由于无排班信息,设置默认选择
                    this.SetDefaultBookingTime(today);
                }

                this.cmbDoct.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
        }


        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsTriggerSelectedIndexChanged == false) return;

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;

            //选择科室
            DateTime today = this.bookingMgr.GetDateTimeFromSysDateTime();
            //设定预约日期,默认为当日
            this.SetBookingDate(today);
            //不显示医生
            this.cmbDoct.Tag = "";
            //显示该科室下排班医生列表
            this.GetDoctByDept(this.cmbDept.Tag.ToString());
            //设定科室预约安排时间段
            this.SetDeptZone(this.cmbDept.Tag.ToString(), today);
            //显示流水号
            this.GetOrder();
        }
        /// <summary>
        /// 医生回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDoct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //没有选择医生,认为预约到专科
                if (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == "")
                {
                    if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
                    {
                        MessageBox.Show("请指定预约医生!", "提示");
                        this.cmbDoct.Focus();
                        return;
                    }

                    //					if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Dept,null,
                    //						this.cmbDept.Tag.ToString(), "") == -1)
                    //					{
                    //						this.cmbDept.Focus() ;
                    //						return ;
                    //					}
                }
                //				else
                //				{
                //					if( this.getLastSchema(neusoft.HISFC.Models.Registration.SchemaTypeNUM.Doct,null ,
                //						"", this.cmbDoct.Tag.ToString()) == -1)
                //					{
                //						this.cmbDoct.Focus() ;
                //						return ;
                //					}
                //				}

                this.dtBookingDate.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }


        private void cmbDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsTriggerSelectedIndexChanged == false) return;

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;

            //选择医生
            DateTime today = this.bookingMgr.GetDateTimeFromSysDateTime();
            //设定预约日期,默认为当日
            this.SetBookingDate(today);
            //设定医生默认安排时间段
            this.SetDoctZone(this.cmbDoct.Tag.ToString(), today);
            //显示流水号
            this.GetOrder();
        }
        /// <summary>
        /// 日期变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBookingDate_ValueChanged(object sender, EventArgs e)
        {
            this.SetBookingTag(null);
            //变更星期
            this.lbWeek.Text = this.getWeek(this.dtBookingDate.Value);

            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
        }
        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBookingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtBookingDate.Value.Date < this.bookingMgr.GetDateTimeFromSysDateTime().Date)
                {
                    MessageBox.Show("预约日期不能小于当前日期", "提示");
                    this.dtBookingDate.Focus();
                    return;
                }

                //this.dtBegin.Focus();
                this.txtCardNo.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.bnQuery_Click(new object(), new System.EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }
        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEnd.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.bnQuery_Click(new object(), new System.EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }
        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtCardNo.Focus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.bnQuery_Click(new object(), new System.EventArgs());
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        private void dtBegin_ValueChanged(object sender, EventArgs e)
        {
            this.SetBookingTag(null);
            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            this.SetBookingTag(null);
            if (this.ucChooseDate.Visible) this.ucChooseDate.Visible = false;
        }
        /// <summary>
        /// bnQuery button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnQuery_Click(object sender, EventArgs e)
        {
            if (this.ucChooseDate.Visible)
            {
                this.ucChooseDate.Visible = false;
                this.dtBookingDate.Focus();
            }
            else
            {
                this.SetZone();
            }
        }
        /// <summary>
        /// 选择预约时间段
        /// </summary>
        /// <param name="sender"></param>
        private void ucChooseDate_SelectedItem(Neusoft.HISFC.Models.Registration.Schema sender)
        {
            this.ucChooseDate.Visible = false;

            if (sender == null) return;

            //			if(sender.Templet.TelLmt <= sender.TelReging)
            //			{
            //				if(MessageBox.Show("预约号数已经大于设号数,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
            //					MessageBoxDefaultButton.Button2) == DialogResult.No)
            //				{
            //					this.dtBookingDate.Focus() ;
            //					return ;
            //				}
            //			}
            //科室
            this.IsTriggerSelectedIndexChanged = false;
            this.cmbDept.Tag = sender.Templet.Dept.ID;
            //医生
            if (sender.Templet.Doct.ID == "None")
            {
                this.cmbDoct.Tag = "";
            }
            else
            {
                this.cmbDoct.Tag = sender.Templet.Doct.ID;
            }
            this.IsTriggerSelectedIndexChanged = true;

            //预约时间
            this.SetBookingDate(sender.SeeDate);
            //预约时间段
            this.SetBookingTime(sender);
            this.dtEnd.Focus();

        }
        /// <summary>
        /// farpoint cell doubleclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || this.fpSpread1_Sheet1.RowCount == 0) return;

            //int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            //this.SetBookingInfo((Neusoft.HISFC.Models.Registration.Booking)this.fpSpread1_Sheet1.Rows[row].Tag);
        }
        #endregion

        #region 方法

        /// <summary>
        /// 生成门诊全部科室列表
        /// </summary>
        /// <returns></returns>
        private int InitDept()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager deptMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            this.alDept = deptMgr.QueryRegDepartment();
            if (alDept == null)
            {
                MessageBox.Show("获取门诊科室列表时出错!" + deptMgr.Err, "提示");
                return -1;
            }

            this.cmbDept.AddItems(alDept);

            return 0;
        }
        /// <summary>
        /// 生成门诊全部医生列表
        /// </summary>
        /// <returns></returns>
        private int InitDoct()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager personMgr = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            alDoct = personMgr.QueryEmployee(Neusoft.HISFC.Models.Base.EnumEmployeeType.D);
            if (alDoct == null)
            {
                MessageBox.Show("获取门诊医生列表时出错!" + personMgr.Err, "提示");
                return -1;
            }

            this.cmbDoct.AddItems(alDoct);

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitChooseDate()
        {
            this.ucChooseDate = new ucChooseBookingDate();

            this.panel1.Controls.Add(ucChooseDate);

            this.ucChooseDate.BringToFront();
            this.ucChooseDate.Location = new Point(this.dtBookingDate.Left, this.dtBookingDate.Top + this.dtBookingDate.Height);
            this.ucChooseDate.Visible = false;
            this.ucChooseDate.SelectedItem += new Registration.ucChooseBookingDate.dSelectedItem(ucChooseDate_SelectedItem);
        }

        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            this.cmbDept.Tag = "";
            this.cmbDoct.Tag = "";
            this.cmbDoct.AddItems(this.alDoct);//显示全院医生

            DateTime current = this.bookingMgr.GetDateTimeFromSysDateTime();

            this.SetBookingDate(current);
            this.SetDefaultBookingTime(current);
            this.SetBookingTag(null);

            this.lbOrder.Text = "";

            this.ClearPatient();
            this.cmbUnit.SelectedIndex = 0;
            this.cmbSex.Tag = "";
            this.txtAge.Text = "";
        }
        /// <summary>
        /// 清除患者信息
        /// </summary>
        private void ClearPatient()
        {
            this.txtCardNo.Text = "";
            this.txtName.Text = "";
            this.txtIdenNo.Text = "";
            this.txtPhone.Text = "";
            this.txtAdress.Text = "";

            this.booking = null;
            this.cmbUnit.SelectedIndex = 0;
            this.cmbSex.Tag = "";
            this.txtAge.Text = "";
        }

        /// <summary>
        /// 检索患者预约信息
        /// </summary>
        private void Retrieve()
        {
            DateTime today = this.bookingMgr.GetDateTimeFromSysDateTime();
            ArrayList al = this.bookingMgr.Query(today, this.bookingMgr.Operator.ID);

            if (al == null)
            {
                MessageBox.Show("获取患者预约信息时出错!" + this.bookingMgr.Err, "提示");
                return;
            }

            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            foreach (Neusoft.HISFC.Models.Registration.Booking obj in al)
            {
                this.AddBookingToFP(obj);
            }
        }
        /// <summary>
        /// 获取患者预约信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Booking getPatientInfo(string CardNo)
        {
            Neusoft.HISFC.Models.Registration.Booking objBooking;

            //先检索患者基本信息表,看是否存在该患者信息
            Neusoft.HISFC.BizProcess.Integrate.RADT PatientMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.BizLogic.Registration.Register RegMgr = new Neusoft.HISFC.BizLogic.Registration.Register();

            Neusoft.HISFC.Models.RADT.PatientInfo objPatient = PatientMgr.QueryComPatientInfo(CardNo);
            if (objPatient == null || objPatient.Name == "")
            {
                //不存在基本信息,看是否存在预约信息
                
                objBooking = this.getBooking(CardNo);                
            }
            else
            {
                //存在患者基本信息,取基本信息
                objBooking = new Neusoft.HISFC.Models.Registration.Booking();
                objBooking.PID.CardNO = CardNo;
                objBooking.Name = objPatient.Name;
                objBooking.IDCard = objPatient.IDCard;
                objBooking.Sex.ID = objPatient.Sex.ID;
                objBooking.Birthday = objPatient.Birthday;
                objBooking.PhoneHome = objPatient.PhoneHome;
                objBooking.AddressHome = objPatient.AddressHome;
                objBooking.Pact = objPatient.Pact;
                objBooking.Pact.PayKind.ID = objPatient.Pact.PayKind.ID;
                objBooking.SSN = objPatient.SSN;
                objBooking.Memo = objPatient.Memo;//证件类型

            }

            return objBooking;
        }
        /// <summary>
        /// 获取患者预约信息
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Booking getBooking(string CardNo)
        {
            Neusoft.HISFC.Models.Registration.Booking objBooking;

            objBooking = this.bookingMgr.Get(CardNo);
            if (objBooking == null)
            {
                MessageBox.Show("获取患者预约信息时出错!" + this.bookingMgr.Err, "提示");
                return null;
            }

            if (objBooking.ID == null || objBooking.ID == "")
            {
                objBooking.PID.CardNO = CardNo;
                objBooking.Pact.PayKind.ID = "01";//自费
            }

            objBooking.IsSee = false;

            return objBooking;
        }
        /// <summary>
        /// 设置界面信息
        /// </summary>
        /// <param name="objBooking"></param>
        private void SetPatient(Neusoft.HISFC.Models.Registration.Booking objBooking)
        {
            this.txtCardNo.Text = objBooking.PID.CardNO;
            this.txtName.Text = objBooking.Name;
            this.txtPhone.Text = objBooking.PhoneHome;
            this.txtAdress.Text = objBooking.AddressHome;
            this.txtIdenNo.Text = objBooking.IDCard;
            this.setAge(objBooking.Birthday);
            this.cmbSex.Tag = objBooking.Sex.ID;
        }
        /// <summary>
        /// 不允许使用直接收费生成的号再进行挂号
        /// </summary>
        /// <param name="CardNO"></param>
        /// <returns></returns>
        private int ValidCardNO(string CardNO)
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParams = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            string cardRule = controlParams.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");
            if (CardNO != "" && CardNO != string.Empty)
            {
                if (CardNO.Substring(0, 1) == cardRule)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("此号段为直接收费使用，请选择其它号段"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// set booking date
        /// </summary>
        /// <param name="seeDate"></param>
        private void SetBookingDate(DateTime seeDate)
        {
            this.dtBookingDate.Value = seeDate.Date;
            this.lbWeek.Text = this.getWeek(seeDate);

        }
        /// <summary>
        /// 设置无预约排班信息时,时间段显示情况
        /// </summary>
        /// <param name="seeDate"></param>
        private void SetDefaultBookingTime(DateTime seeDate)
        {
            Neusoft.HISFC.Models.Registration.Schema schema = new Neusoft.HISFC.Models.Registration.Schema();
            schema.Templet.Begin = seeDate.Date;
            schema.Templet.End = seeDate.Date;

            this.SetBookingTime(schema);
        }
        /// <summary>
        /// Set booking time;
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void SetBookingTime(Neusoft.HISFC.Models.Registration.Schema schema)
        {
            this.dtBegin.Value = schema.Templet.Begin;
            this.dtEnd.Value = schema.Templet.End;

            this.SetBookingTag(schema);
        }
        /// <summary>
        /// 保存使用的预约排班信息
        /// </summary>
        /// <param name="schema"></param>
        private void SetBookingTag(Neusoft.HISFC.Models.Registration.Schema schema)
        {
            this.dtBookingDate.Tag = schema;

            if (schema != null)
            {
                this.lbTelLmt.Text = schema.Templet.TelQuota.ToString();
                this.lbTelReging.Text = schema.TelingQTY.ToString();
            }
            else
            {
                this.lbTelLmt.Text = "0";
                this.lbTelReging.Text = "0";
            }
        }
        /// <summary>
        /// 获取使用的预约排班信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Schema GetBookingTag()
        {
            if (this.dtBookingDate.Tag == null) return null;

            return (Neusoft.HISFC.Models.Registration.Schema)this.dtBookingDate.Tag;
        }

        /// <summary>
        /// 生成预约流水号
        /// </summary>
        private void GetOrder()
        {
            if (this.lbOrder.Text == "")
            {
                this.lbOrder.Text = this.bookingMgr.GetSequence("Registration.Booking.Query.3");
            }
        }
        /// <summary>
        /// 根据日期获取星期
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private string getWeek(DateTime current)
        {
            string[] week = new string[] { "日", "一", "二", "三", "四", "五", "六" };

            return "星期" + week[(int)current.DayOfWeek];
        }
        /// <summary>
        /// 设定科室预约安排时间段
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        private int SetDeptZone(string deptID, DateTime bookingDate)
        {
            this.ucChooseDate.QueryDeptBooking(bookingDate, deptID, Registration.RegTypeNUM.Booking);

            //默认显示第一条符合条件（时间未过期、限额未满）的排班信息
            Neusoft.HISFC.Models.Registration.Schema schema = this.ucChooseDate.GetValidBooking(RegTypeNUM.Booking);

            if (schema == null)//没有符合条件的
            {
                this.SetDefaultBookingTime(bookingDate.Date);
            }
            else
            {
                this.SetBookingTime(schema);
            }

            return 0;
        }

        /// <summary>
        /// 根据科室代码,出诊时间查询排班医生
        /// </summary>
        /// <param name="deptID"></param>
        /// <returns></returns>
        private int GetDoctByDept(string deptID)
        {
            ArrayList al = this.Mgr.QueryEmployeeForScama(Neusoft.HISFC.Models.Base.EnumEmployeeType.D, deptID);
            if (al == null)
            {
                MessageBox.Show("获取排班医生时出错!" + this.Mgr.Err, "提示");
                return -1;
            }

            this.cmbDoct.AddItems(al);

            return 0;
        }
        /// <summary>
        /// 根据人员代码获取人员信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Employee GetPerson(string ID)
        {
            if (this.alDoct == null) return null;

            foreach (Neusoft.HISFC.Models.Base.Employee p in alDoct)
            {
                if (p.ID == ID) return p;
            }

            return null;
        }
        /// <summary>
        /// 设定医生预约安排时间段
        /// </summary>
        /// <param name="doctID"></param>
        /// <param name="bookingDate"></param>
        /// <returns></returns>
        private int SetDoctZone(string doctID, DateTime bookingDate)
        {
            this.ucChooseDate.QueryDoctBooking(bookingDate, doctID, Registration.RegTypeNUM.Booking);

            //默认显示第一条符合条件（时间未过期、限额未满）的排班信息
            Neusoft.HISFC.Models.Registration.Schema schema = this.ucChooseDate.GetValidBooking(Registration.RegTypeNUM.Booking);

            if (schema == null)//没有符合条件的
            {
                this.SetDefaultBookingTime(bookingDate.Date);
            }
            else
            {
                this.SetBookingTime(schema);
                //没有科室,指定科室
                if (this.cmbDept.Tag.ToString() == "")
                {
                    this.IsTriggerSelectedIndexChanged = false;
                    this.cmbDept.Tag = schema.Templet.Dept.ID;
                    this.IsTriggerSelectedIndexChanged = true;
                }
            }

            return 0;
        }
        /// <summary>
        /// 设置预约时间段
        /// </summary>
        /// <returns></returns>
        private int SetZone()
        {
            string deptID = this.cmbDept.Tag.ToString();
            string doctID = this.cmbDoct.Tag.ToString();

            DateTime bookingDate = this.dtBookingDate.Value;
            DateTime current = this.bookingMgr.GetDateTimeFromSysDateTime();

            if (bookingDate.Date < current.Date)
            {
                MessageBox.Show("预约日期不能小于当前日期!", "提示");
                this.dtBookingDate.Focus();
                return -1;
            }

            if (doctID == null || doctID == "")//没有选择医生,预约到专科
            {
                if (deptID == null || deptID == "")//也没有预约科室,显示默认
                {
                    MessageBox.Show("请指定预约专家!", "提示");
                    this.cmbDoct.Focus();
                    return 0;
                    //this.SetBookingTime(bookingDate,bookingDate) ;
                }
                else//预约到科室
                {
                    this.SetDeptZone(deptID, bookingDate);

                    if (this.ucChooseDate.Count > 0)
                    {
                        this.ucChooseDate.Visible = true;
                        this.ucChooseDate.Focus();
                    }
                    else if (this.ucChooseDate.Bookings.Count > 0)
                    {
                        MessageBox.Show("没有符合条件的排班信息,请重新选择预约日期", "提示");
                        this.dtBookingDate.Focus();
                        return -1;
                    }
                    else
                    {
                        MessageBox.Show("专科没有排班!", "提示");
                        this.dtBookingDate.Focus();
                        return -1;
                    }
                }
            }
            else//预约到医生
            {
                this.SetDoctZone(doctID, bookingDate);

                if (this.ucChooseDate.Count > 0)
                {
                    this.ucChooseDate.Visible = true;
                    this.ucChooseDate.Focus();
                }
                else if (this.ucChooseDate.Bookings.Count > 0)
                {
                    MessageBox.Show("没有符合条件的排班信息,请重新选择预约日期", "提示");
                    this.dtBookingDate.Focus();
                    return -1;
                }
                else
                {
                    MessageBox.Show("专家没有排班!", "提示");
                    this.dtBookingDate.Focus();
                    return -1;
                }
            }

            return 0;
        }
        /// <summary>
        /// 显示已预约登记患者信息
        /// </summary>
        /// <param name="booking"></param>
        private void SetBookingInfo(Neusoft.HISFC.Models.Registration.Booking booking)
        {
            this.Clear();

            //this.txtCardNo.Text = booking.Card.ID;
            this.txtName.Text = booking.Name;
            this.txtIdenNo.Text = booking.IDCard;
            this.txtPhone.Text = booking.PhoneHome;
            this.txtAdress.Text = booking.AddressHome;

            this.IsTriggerSelectedIndexChanged = false;
            this.cmbDept.Tag = booking.DoctorInfo.Templet.Dept.ID;
            this.cmbDoct.Tag = booking.DoctorInfo.Templet.Doct.ID;
            this.IsTriggerSelectedIndexChanged = true;

            this.dtBookingDate.Value = booking.DoctorInfo.SeeDate;
            this.dtBegin.Value = booking.DoctorInfo.Templet.Begin;
            this.dtEnd.Value = booking.DoctorInfo.Templet.End;
            this.txtCardNo.Text = booking.PID.CardNO;
            this.cmbSex.Tag = booking.Sex.ID;
            this.dtBirthday.Value = booking.Birthday;

            this.lbOrder.Text = booking.ID;
        }
        #endregion

        #region PageUp,PageDown切换焦点跳转
        /// <summary>
        /// 设置上一个控件获得焦点
        /// </summary>
        private void setPriorControlFocus()
        {
            System.Windows.Forms.SendKeys.Send("+{TAB}");
        }

        /// <summary>
        /// 设置下一个控件获得焦点
        /// </summary>
        private void setNextControlFocus()
        {
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }
        #endregion

        #region toolbarClick    

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int Save()
        {
            if (this.Valid() == -1) return -1;

            if (this.GetValue() == -1) return -1;
            if (this.ValidCardNO(this.booking.PID.CardNO) < 0)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.bookingMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.bookingMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.schemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.patMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                //更新看诊数
                Neusoft.HISFC.Models.Registration.Schema schema = this.GetBookingTag();

                if (this.schemaMgr.Increase(schema.Templet.ID, false, true, false, false) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新医生排班信息时出错!" + this.schemaMgr.Err, "提示");
                    return -1;
                }

                schema = this.schemaMgr.GetByID(schema.Templet.ID);
                if (schema == null || schema.Templet.ID == "" || (schema.Templet.TelQuota != 0 && schema.Templet.TelQuota < schema.TelingQTY))
                {
                    if (MessageBox.Show("排班信息限额已满,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.dtBookingDate.Focus();
                        return -1;
                    }
                }

                //登记预约信息
                this.booking.DoctorInfo.Templet.ID = schema.Templet.ID;

                if (this.bookingMgr.Insert(this.booking) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("登记患者预约信息时出错!" + this.bookingMgr.Err, "提示");
                    return -1;
                }

                //更新患者信息
                string Err = "";

                if (this.UpdatePatientinfo(booking, patMgr, regMgr, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新患者基本信息出错!" + Err, "提示");
                    return -1;
                }

            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("登记患者预约信息时出错!" + e.Message, "提示");
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功!", "提示");

            this.AddBookingToFP(this.booking);
            this.Clear();

            this.cmbDoct.Focus();

            return 0;
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private int Valid()
        {
            DateTime begin = this.dtBegin.Value;
            DateTime end = this.dtEnd.Value;
            //if (this.booking == null || this.booking.PID.CardNO == "")
            //{
            //    MessageBox.Show("请输入预约患者信息!", "提示");
            //    this.txtCardNo.Focus();
            //    return -1;
            //}
            //			if(this.txtName.Text.Trim() == "")
            //			{
            //				MessageBox.Show("请输入患者姓名!","提示") ;
            //				this.txtName.Focus() ;
            //				return -1;
            //			}
            //			if(this.txtPhone.Text.Trim() == "")
            //			{
            //				MessageBox.Show("请输入患者电话!","提示") ;
            //				this.txtPhone.Focus() ;
            //				return -1 ;
            //			}
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text.Trim(), 16) == false)
            {
                MessageBox.Show("患者名称过长!", "提示");
                this.txtName.Focus();
                return -1;
            }
            if (this.txtName.Text.Trim() == null || this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("患者名称不能为空!", "提示");
                this.txtName.Focus();
                return -1;
            }
            if (Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtAdress.Text.Trim(), 60) == false)
            {
                MessageBox.Show("地址不能超过30个汉字!", "提示");
                this.txtAdress.Focus();
                return -1;
            }
            if ((this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "") &&
                (this.cmbDoct.Tag == null || this.cmbDoct.Tag.ToString() == ""))
            {
                MessageBox.Show("请指定预约专家!", "提示");
                this.cmbDoct.Focus();
                return -1;
            }
            if (begin.TimeOfDay > end.TimeOfDay)
            {
                MessageBox.Show("预约起始时间不能大于截至时间");
                return -1;
            }
            #region ""
            /*neusoft.HISFC.Models.Registration.Schema schema = this.GetBookingTag() ;
			if(schema == null || schema.Templet.ID == null ||schema.Templet.ID == "")
			{
				MessageBox.Show("请选择预约时间!","提示") ;
				this.dtBookingDate.Focus() ;
				return -1 ;
			}			
			
			if(this.dtBegin.Value.TimeOfDay >this.dtEnd.Value.TimeOfDay)
			{
				MessageBox.Show("预约起始时间不能大于结束时间!","提示") ;
				this.dtBegin.Focus() ;
				return -1;
			}			

			DateTime current = this.bookingMgr.GetDateTimeFromSysDateTime() ;
			DateTime bookingDate = DateTime.Parse(this.dtBookingDate.Value.Date.ToString() +" "+this.dtEnd.Value.Hour.ToString() +
				":" + this.dtEnd.Value.Minute.ToString() + ":00") ;
			if(bookingDate <current) 
			{
				MessageBox.Show("预约时间小于当前时间!","提示") ;
				this.dtBegin.Focus() ;
				return -1 ;
			}*/

            if (!string.IsNullOrEmpty(this.txtIdenNo.Text.Trim()))
            {
                if (this.ProcessIDENNO(this.txtIdenNo.Text.Trim(),EnumCheckIDNOType.Saveing) < 0)
                {
                    return -1;
                }
            }
            #endregion

            return 0;
        }
        /// <summary>
        /// 实体赋值
        /// </summary>
        /// <returns></returns>
        private int GetValue()
        {
            if (this.booking == null )
            {
                this.booking = new Neusoft.HISFC.Models.Registration.Booking ();
            }
            if ( string.IsNullOrEmpty(this.booking.PID.ID))
            {
                int autoGetCardNO = 0;
                autoGetCardNO = regMgr.AutoGetCardNO();
                if (autoGetCardNO == -1)
                {
                    MessageBox.Show("未能成功自动产生卡号，请手动输入！", "提示");
                }
                else
                {

                    this.booking.PID.CardNO = autoGetCardNO.ToString().PadLeft(10, '0');
                }
            }
           
           



            this.booking.ID = this.lbOrder.Text;
            
            //{A47CE41F-3AC7-4289-AFB2-01DC5481F917}
            this.booking.Name = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtName.Text.Trim(), "'", "[", "]");
            //{A47CE41F-3AC7-4289-AFB2-01DC5481F917}
            this.booking.IDCard = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtIdenNo.Text.Trim(),"'","[", "]");
            //{A47CE41F-3AC7-4289-AFB2-01DC5481F917}
            this.booking.PhoneHome = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtPhone.Text.Trim(), "'", "[", "]");
            //{A47CE41F-3AC7-4289-AFB2-01DC5481F917}
            this.booking.AddressHome = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtAdress.Text.Trim(),"'", "[", "]");

            Neusoft.HISFC.Models.Registration.Schema schema = this.GetBookingTag();
            //造成这种情况是1、没有符合条件的排班信息,2、变动了预约日期、时间,所以重新检索一遍进行确认
            if (schema == null || schema.Templet.ID == null || schema.Templet.ID == "")
            {
                schema = this.GetValidSchema();
                if (schema == null)
                {
                    MessageBox.Show("预约时间指定错误,没有符合条件的排班信息!", "提示");
                    this.dtBookingDate.Focus();
                    return -1;
                }

                this.SetBookingTag(schema);
            }           

            this.booking.DoctorInfo = schema.Clone();
           
            if (this.booking.DoctorInfo.Templet.Doct.ID == "None") this.booking.DoctorInfo.Templet.Doct.ID = "";
            this.booking.DoctorInfo.SeeDate = DateTime.Parse(schema.SeeDate.ToString("yyyy-MM-dd") + " " +
                                                schema.Templet.Begin.ToString("HH:mm:ss"));
            /*
            this.booking.DoctorInfo.Templet.Begin = schema.Templet.Begin;
            this.booking.DoctorInfo.Templet.End = schema.Templet.End;
            this.booking.DoctorInfo.Templet.Dept.ID = schema.Templet.Dept.ID;
            this.booking.DoctorInfo.Templet.Dept.Name = schema.Templet.Dept.Name;
            this.booking.DoctorInfo.Templet.Doct.ID = schema.Templet.Doct.ID;
            if (this.booking.DoctorInfo.Templet.Doct.ID == "None") this.booking.DoctorInfo.Templet.Doct.ID = "";
            this.booking.DoctorInfo.Templet.Doct.Name = schema.Templet.Doct.Name;
            this.booking.Noon = schema.Templet.NoonID;
            this.booking.IsAppend = schema.Templet.IsAppend;*/
            this.booking.DoctorInfo.Templet.Begin = this.dtBegin.Value;
            this.booking.DoctorInfo.Templet.End = dtEnd.Value;
            this.booking.Oper.ID = this.bookingMgr.Operator.ID;
            this.booking.Oper.OperTime = this.bookingMgr.GetDateTimeFromSysDateTime();
            this.booking.DoctorInfo.Templet.RegLevel = schema.Templet.RegLevel;
            this.booking.Sex.ID = this.cmbSex.Tag.ToString();//性别

            this.booking.Birthday = this.dtBirthday.Value;//出生日期		


            return 0;
        }
        /// <summary>
        /// 重新获取有效的排班信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Schema GetValidSchema()
        {
            string deptID = this.cmbDept.Tag.ToString();
            string doctID = this.cmbDoct.Tag.ToString();

            DateTime bookingDate = this.dtBookingDate.Value.Date;

            ArrayList al;

            if (doctID == "")//预约专科
            {
                al = this.schemaMgr.QueryByDept(bookingDate, deptID);
                if (al == null || al.Count == 0) return null;

            }
            else//预约专家
            {
                al = this.schemaMgr.QueryByDoct(bookingDate, doctID);
                if (al == null || al.Count == 0) return null;
            }

            return this.GetValidSchema(al);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Schemas"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Schema GetValidSchema(ArrayList Schemas)
        {

            DateTime current = this.schemaMgr.GetDateTimeFromSysDateTime();
            DateTime begin = this.dtBegin.Value;
            DateTime end = this.dtEnd.Value;

            foreach (Neusoft.HISFC.Models.Registration.Schema obj in Schemas)
            {
                if (obj.SeeDate < current.Date) continue;//小于当前日期
                //if(obj.Templet.TelLmt == 0)continue ;//没有设定预约限额

                //by niuxy  在排班范围内任意预约时间
                //if (obj.Templet.Begin.TimeOfDay != begin.TimeOfDay) continue;//开始时间不等
                //if (obj.Templet.End.TimeOfDay != end.TimeOfDay) continue;//结束时间不等
                if ((obj.Templet.Begin.TimeOfDay > begin.TimeOfDay) || (obj.Templet.End.TimeOfDay < end.TimeOfDay)) continue;//开始时间不等


                //if(obj.Templet.TelLmt <= obj.TelReging) continue;//超出限额
                //
                //只有日期相同,才判断时间是否超时,否则就是预约到以后日期,时间不用判断
                //
                if (current.Date == this.dtBookingDate.Value.Date)
                {
                    if (obj.Templet.End.TimeOfDay < current.TimeOfDay) continue;//时间小于当前时间
                }

                return obj;
            }
            return null;
        }
        /// <summary>
        /// 添加预约信息到farpoint
        /// </summary>
        /// <param name="booking"></param>
        private void AddBookingToFP(Neusoft.HISFC.Models.Registration.Booking booking)
        {
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);
            int row = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1_Sheet1.SetValue(row, 0, booking.ID, false);
            this.fpSpread1_Sheet1.SetValue(row, 1, booking.PID.CardNO, false);
            this.fpSpread1_Sheet1.SetValue(row, 2, booking.Name, false);
            this.fpSpread1_Sheet1.SetValue(row, 3, booking.DoctorInfo.Templet.Dept.Name, false);
            this.fpSpread1_Sheet1.SetValue(row, 4, booking.DoctorInfo.Templet.Doct.Name, false);
            this.fpSpread1_Sheet1.SetValue(row, 5, booking.DoctorInfo.SeeDate.ToString("yyyy-MM-dd") + "[" + booking.DoctorInfo.Templet.Begin.ToString("HH:mm") + "~" + booking.DoctorInfo.Templet.End.ToString("HH:mm") + "]", false);
            this.fpSpread1_Sheet1.Rows[row].Tag = booking;
        }
        /// <summary>
        /// 更新患者基本信息
        /// </summary>
        /// <param name="booking"></param>
        /// <param name="patMgr"></param>
        /// <param name="registerMgr"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdatePatientinfo(Neusoft.HISFC.Models.Registration.Booking booking,
            Neusoft.HISFC.BizProcess.Integrate.RADT patMgr, Neusoft.HISFC.BizLogic.Registration.Register registerMgr,
            ref string Err)
        {
            Neusoft.HISFC.Models.Registration.Register regInfo = new Neusoft.HISFC.Models.Registration.Register();


            regInfo.PID.CardNO = booking.PID.CardNO;
            regInfo.Name = booking.Name;
            regInfo.Sex.ID = booking.Sex.ID;
            regInfo.Birthday = booking.Birthday;
            regInfo.Pact = booking.Pact;
            regInfo.Pact.PayKind.ID = booking.Pact.PayKind.ID;
            regInfo.SSN = booking.SSN;
            regInfo.PhoneHome = booking.PhoneHome;
            regInfo.AddressHome = booking.AddressHome;
            regInfo.IDCard = booking.IDCard;
            regInfo.CardType.ID = booking.Memo;

            int rtn = registerMgr.Update(Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.PatientInfo,
                                            regInfo);

            if (rtn == -1)
            {
                Err = registerMgr.Err;
                return -1;
            }

            if (rtn == 0)//没有更新到患者信息，插入
            {
                Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();

                p.PID.CardNO = regInfo.PID.CardNO;
                p.Name = regInfo.Name;
                p.Sex.ID = regInfo.Sex.ID;
                p.Birthday = regInfo.Birthday;
                p.Pact = regInfo.Pact;
                p.Pact.PayKind.ID = regInfo.Pact.PayKind.ID;
                p.SSN = regInfo.SSN;
                p.PhoneHome = regInfo.PhoneHome;
                p.AddressHome = regInfo.AddressHome;
                p.IDCard = regInfo.IDCard;
                p.Memo = regInfo.CardType.ID;

                if (patMgr.RegisterComPatient(p) == -1)
                {
                    Err = patMgr.Err;
                    return -1;
                }
            }

            return 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        private int Delete()
        {
            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            if (row < 0 || this.fpSpread1_Sheet1.RowCount == 0) return 0;

            if (this.Delete((Neusoft.HISFC.Models.Registration.Booking)this.fpSpread1_Sheet1.Rows[row].Tag) == -1)
            {
                this.Clear();
                return -1;
            }

            this.fpSpread1_Sheet1.Rows.Remove(row, 1);

            return 0;
        }
        /// <summary>
        /// 删除预约信息
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private int Delete(Neusoft.HISFC.Models.Registration.Booking b)
        {
            if (MessageBox.Show("是否删除该条预约信息?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction SQLCA = new Neusoft.FrameWork.Management.Transaction(this.bookingMgr.con);
            //SQLCA.BeginTransaction();

            try
            {
                this.bookingMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                this.schemaMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int rtn = this.bookingMgr.Delete(b.ID);

                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("删除预约信息时出错!" + this.bookingMgr.Err, "提示");
                    return -1;
                }

                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该预约信息已经挂号,不能删除!", "提示");
                    return -1;
                }

                ///恢复预约看诊限额
                ///
                rtn = this.schemaMgr.Reduce(b.DoctorInfo.Templet.ID, false, true, false, false);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("更新预约限额出错!" + this.schemaMgr.Err, "提示");
                    return -1;
                }
                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("已无排班信息,无法恢复限额!", "提示");
                    return -1;
                }
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(e.Message, "提示");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show("删除成功!", "提示");

            return 0;
        }
        #endregion
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                bool IsSelected = false;

                if (this.ucChooseDate.Visible)
                {
                    IsSelected = true;

                    this.ucChooseDate.Visible = false;
                    this.dtBookingDate.Focus();
                }

                if (!IsSelected)
                {
                    this.FindForm().Close();
                }

                return true;
            }// 自定义快捷键屏蔽 {6A58ADC6-04D1-48a5-AF0C-82B730D55094}
            //else if (keyData == Keys.F8)
            //{
            //    this.Clear();
            //    this.cmbDoct.Focus();

            //    return true;
            //}            
            else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            {
                this.FindForm().Close();
                return true;
            }//自定义快捷键屏蔽 {6A58ADC6-04D1-48a5-AF0C-82B730D55094}
            //else if (keyData == Keys.F12)
            //{
            //    this.Save();

            //    return true;
            //}
            //else if (keyData == Keys.Subtract || keyData == Keys.OemMinus)
            //{
            //    this.Delete();
            //    this.cmbDoct.Focus();

            //    return true;
            //}
            //else if (keyData == Keys.F1)
            //{
            //    this.Switch();
            //    return true;
            //}
            //else if (keyData == Keys.F9)
            //{
            //    this.ChangeCard();
            //}

            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// 切换到挂号窗口
        /// </summary>
        private void Switch()
        {
            //Form[] forms = this.ParentForm.MdiChildren;

            //foreach (Form f in forms)
            //{
            //    if (f.GetType().FullName == "Registration.frmRegister")
            //    {
            //        f.Show();
            //        f.BringToFront();
            //        return;
            //    }
            //}

            //frmRegister form = new frmRegister(var);

            //form.MdiParent = this.ParentForm;
            //form.Show();
        }

        /// <summary>
        /// 换卡
        /// </summary>
        private void ChangeCard()
        {
            //Local.Clinic.Form.frmCreateCard f = new Local.Clinic.Form.frmCreateCard(var);
            //f.ShowDialog();
            //f.Dispose();
        }

        #region 删除预约信息

        bool isLeave = true;
        /// <summary>
        /// 根据流水号检索预约信息,然后删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label13_Click(object sender, EventArgs e)
        {
            this.isLeave = true;
            this.txtOrder.Visible = true;
            this.txtOrder.Focus();
        }


        /// <summary>
        /// 删除预约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.isLeave = false;
                string ID = this.txtOrder.Text.Trim();

                if (ID == "")
                {
                    MessageBox.Show("请指定流水号!", "提示");
                    this.txtOrder.Focus();
                    this.isLeave = true;
                    return;
                }
                //获取预约实体

                Neusoft.HISFC.Models.Registration.Booking b = this.bookingMgr.GetByID(ID);
                if (b == null || b.ID == "")
                {
                    MessageBox.Show("没有流水号为:" + ID + "的预约信息!", "提示");
                    this.txtOrder.Focus();
                    this.isLeave = true;
                    return;
                }

                this.SetBookingInfo(b);

                //删除预约信息
                if (this.Delete(b) == -1)
                {
                    this.txtOrder.Focus();
                    this.isLeave = true;
                    this.Clear();
                    return;
                }

                //this.txtOrder.Visible = false ;				
                this.isLeave = true;
                this.Retrieve();
                this.Clear();
                this.cmbDoct.Focus();

            }
        }

        /// <summary>
        /// Set Age
        /// </summary>
        /// <param name="birthday"></param>
        private void setAge(DateTime birthday)
        {
            this.txtAge.Text = "";

            if (birthday == DateTime.MinValue)
            {
                return;
            }

            DateTime current;
            int year, month, day;

            current = this.regMgr.GetDateTimeFromSysDateTime();
            year = current.Year - birthday.Year;
            month = current.Month - birthday.Month;
            day = current.Day - birthday.Day;

            if (year > 1)
            {
                this.txtAge.Text = year.ToString();
                this.cmbUnit.SelectedIndex = 0;
            }
            else if (year == 1)
            {
                if (month >= 0)//一岁
                {
                    this.txtAge.Text = year.ToString();
                    this.cmbUnit.SelectedIndex = 0;
                }
                else
                {
                    this.txtAge.Text = Convert.ToString(12 + month);
                    this.cmbUnit.SelectedIndex = 1;
                }
            }
            else if (month > 0)
            {
                this.txtAge.Text = month.ToString();
                this.cmbUnit.SelectedIndex = 1;
            }
            else if (day > 0)
            {
                this.txtAge.Text = day.ToString();
                this.cmbUnit.SelectedIndex = 2;
            }
            this.txtAge.SelectionStart = this.txtAge.Text.Length;//{4B97388A-63E4-43c8-BB61-6E22CB2839A1}
        }

        /// <summary>
        /// 获取出生日期
        /// </summary>
        private void getBirthday()
        {
            string age = this.txtAge.Text.Trim();
            int i = 0;

            if (age == "") age = "0";

            try
            {
                i = int.Parse(age);
            }
            catch (Exception e)
            {
                string error = e.Message;
                MessageBox.Show("输入年龄不正确,请重新输入!", "提示");
                this.txtAge.Focus();
                return;
            }

            ///
            ///

            DateTime birthday = DateTime.MinValue;

            this.getBirthday(i, this.cmbUnit.Text, ref birthday);

            if (birthday < this.dtBirthday.MinDate)
            {
                MessageBox.Show("年龄不能过大!", "提示");
                this.txtAge.Select(0, this.txtAge.Text.Length);
                this.txtAge.Focus();
                return;
            }

            //this.dtBirthday.Value = birthday ;

            if (this.cmbUnit.Text == "岁")
            {

                //数据库中存的是出生日期,如果年龄单位是岁,并且算出的出生日期和数据库中出生日期年份相同
                //就不进行重新赋值,因为算出的出生日期生日为当天,所以以数据库中为准

                if (this.dtBirthday.Value.Year != birthday.Year)
                {
                    this.dtBirthday.Value = birthday;
                }
            }
            else
            {
                this.dtBirthday.Value = birthday;
            }
        }
        /// <summary>
        /// 根据年龄得到出生日期
        /// </summary>
        /// <param name="age"></param>
        /// <param name="ageUnit"></param>
        /// <param name="birthday"></param>
        private void getBirthday(int age, string ageUnit, ref DateTime birthday)
        {
            DateTime current = this.regMgr.GetDateTimeFromSysDateTime();

            if (ageUnit == "岁")
            {
                birthday = current.AddYears(-age);
            }
            else if (ageUnit == "月")
            {
                birthday = current.AddMonths(-age);
            }
            else if (ageUnit == "天")
            {
                birthday = current.AddDays(-age);
            }
        }

        private void txtOrder_Validating(object sender, CancelEventArgs e)
        {
            if (this.isLeave)
            {
                this.txtOrder.Visible = false;
            }
        }
        #endregion

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            //屏蔽{6A58ADC6-04D1-48a5-AF0C-82B730D55094}
            //this.toolBarService.AddToolButton("保存", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.A保存, true, false, null);
            this.toolBarService.AddToolButton("删除", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            this.toolBarService.AddToolButton("清屏", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);

            return this.toolBarService;
        }

        //新加{6A58ADC6-04D1-48a5-AF0C-82B730D55094}
        protected override int OnSave(object sender, object neuObject)
        {
            this.Save();
            return base.OnSave(sender, neuObject);
        }
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //屏蔽 {6A58ADC6-04D1-48a5-AF0C-82B730D55094}
                //case "保存":
                //    this.Save();

                //    break;
                case "删除":
                    this.Delete();
                    this.cmbDoct.Focus();

                    break;
                case "清屏":
                    this.Clear();
                    this.cmbDoct.Focus();

                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getBirthday();
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.getBirthday();

                this.cmbUnit.Focus();
            }
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            
            this.getBirthday();
           
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                this.setNextControlFocus();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                this.setPriorControlFocus();
            }
        }

        private int ProcessIDENNO(string idNO, EnumCheckIDNOType enumType)
        {
            string errText = string.Empty;

            //校验身份证号


            //{99BDECD8-A6FC-44fc-9AAA-7F0B166BB752}

            //string idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            string idNOTmp = string.Empty;
            if (idNO.Length == 15)
            {
                idNOTmp = Neusoft.FrameWork.WinForms.Classes.Function.TransIDFrom15To18(idNO);
            }
            else
            {
                idNOTmp = idNO;
            }

            //校验身份证号
            int returnValue = Neusoft.FrameWork.WinForms.Classes.Function.CheckIDInfo(idNOTmp, ref errText);



            if (returnValue < 0)
            {
                MessageBox.Show(errText);
                this.txtIdenNo.Focus();
                return -1;
            }
            string[] reurnString = errText.Split(',');
            if (enumType == EnumCheckIDNOType.BeforeSave)
            {
                this.dtBirthday.Text = reurnString[1];
                this.cmbSex.Text = reurnString[2];
                this.setAge(this.dtBirthday.Value);
                
            }
            else
            {
                if (this.dtBirthday.Text != reurnString[1])
                {
                    MessageBox.Show("输入的生日日期与身份证号码中的生日不符");
                    this.dtBirthday.Focus();
                    return -1;
                }

                if (this.cmbSex.Text != reurnString[2])
                {
                    MessageBox.Show("输入的性别与身份证中号的性别不符");
                    this.cmbSex.Focus();
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 判断身份证//{6B6167F7-3A9B-4f6c-9326-C5CD6AA3AC98}身份证信息
        /// </summary>
        private enum EnumCheckIDNOType
        {
            /// <summary>
            /// 保存之前校验
            /// </summary>
            BeforeSave = 0,

            /// <summary>
            /// 保存时校验
            /// </summary>
            Saveing
        }

        private void dtBirthday_ValueChanged(object sender, EventArgs e)
        {
            this.txtAge.TextChanged -= new EventHandler(txtAge_TextChanged);
            this.setAge(this.dtBirthday.Value);
            this.txtAge.TextChanged += new EventHandler(txtAge_TextChanged);
        }
    }
}

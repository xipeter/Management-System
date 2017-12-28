using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;
using System.Collections;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 功能：住院证开立、打印、补打
    /// 创建人：何志力
    /// 创建日期：2011.02.19
    /// </summary>
    public partial class ucInpatientProof : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucInpatientProof()
        {
            InitializeComponent();
            this.InitPopShowPatient();
            Init();
            this.tbCardNO.Focus();
            this.tbCardNO.SelectAll();
        }
        #region 变量
        private string cardNO = "";
        private bool isNewCard = false;
        /// <summary>
        /// 读卡
        /// </summary>
        /// 
        ZZlocal.Clinic.HISFC.OuterConnector.IDCard.IDReader idreader = new ZZlocal.Clinic.HISFC.OuterConnector.IDCard.IDReader();
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 显示患者信息
        /// </summary>
        protected ZZLocal.Clinic.HISFC.Components.OutpatientFee.Controls.ucShowPatientsForModify ucShow = new ZZLocal.Clinic.HISFC.Components.OutpatientFee.Controls.ucShowPatientsForModify();
        /// <summary>
        /// 多患者弹出窗口
        /// </summary>
        protected Form fPopWin = new Form();
        //private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        private Neusoft.HISFC.BizLogic.Fee.InPatient accountManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();
        #endregion
        
        
        #region 业务层
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        private Neusoft.HISFC.Models.RADT.InPatientProof inpatientproof = null;
        private Neusoft.HISFC.Models.RADT.InPatientProof inpatientproofinfo = null;
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;
        private Neusoft.HISFC.Models.Registration.Register tempRegister = null;
        /// <summary>
        /// 住院证打印接口
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientProofPrint inpatientproofPrint = null;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        protected virtual int Init()
        {
            try
            {
                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Models.Base.SexEnumService.List());
                this.cmbSex.Text = "男";
                //家庭住址信息
                this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //生日
                this.dtpBirthDay.Value = this.regMgr.GetDateTimeFromSysDateTime();//出生日期
                //开证医生
                this.cmbDoctor.AddItems(managerIntegrate.QueryEmployee(EnumEmployeeType.D));
                //住院科室
                this.cmbDept.AddItems(managerIntegrate.QueryDeptmentsInHos(true));
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            return 1;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="register"></param>
        public void setInfo(Neusoft.HISFC.Models.Registration.Register register)
        {
            if (register == null)
            {
                MessageBox.Show("该患者无此挂号信息！");
            }
            else
            {
                this.Clear();
                this.inpatientproofinfo = this.radtIntegrate.QueryInPatientProofinfo(register.ID);
                if (string.IsNullOrEmpty(inpatientproofinfo.Clinic_code)) //新增加
                {
                    this.patientInfo = this.radtIntegrate.QueryComPatientInfo(register.PID.CardNO);
                    this.cardNO = this.patientInfo.PID.CardNO;
                    SetPatient(register);
                }
                else //修改住院证信息
                {
                    SetInPatientProof(inpatientproofinfo);
                }
                this.cmbDept.Focus();
            }
        }
        /// <summary>
        /// 显示住院证基本信息
        /// </summary>
        /// 
        private void SetInPatientProof(Neusoft.HISFC.Models.RADT.InPatientProof inpatientproof1)
        {
            if (!string.IsNullOrEmpty(inpatientproof1.Clinic_code))
            {
                this.txtCLINIC.Text = this.inpatientproofinfo.Clinic_code;   //门诊号
                this.txtCARDNO.Text = this.inpatientproofinfo.Card_no; //卡号
                this.txtName.Text = this.inpatientproofinfo.Name; //姓名
                this.txtIDNO.Text = this.inpatientproofinfo.Idenno;             //身份证号
                this.cmbSex.Text = this.inpatientproofinfo.Sex_code.Name;            //性别
                this.cmbSex.Tag = this.inpatientproofinfo.Sex_code.ID;               //性别
                this.dtpBirthDay.Value = inpatientproofinfo.Birthday;      //出生日期
                this.txtAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.inpatientproofinfo.Birthday);//年龄

                this.cmbDept.Text = inpatientproofinfo.Dept_code.Name;//住院科室名称
                this.cmbDept.Tag = inpatientproofinfo.Dept_code.ID; //住院科室代码
                this.txtInDiagnosis.Text = this.inpatientproofinfo.Diagnose; //诊断
                this.cmbHomeAddress.Text = this.inpatientproofinfo.Address;  //家庭住址
                this.txtINTEXT.Text = this.inpatientproofinfo.Intext;
                this.cmbDoctor.Text = inpatientproofinfo.Doct_code.Name;//医生
                this.cmbDoctor.Tag = inpatientproofinfo.Doct_code.ID;
                this.neuTextBox1.Text = inpatientproofinfo.Inpatient_count.ToString();
                this.neuTextBox2.Text = inpatientproofinfo.Blood_qty.ToString();
                if (inpatientproofinfo.Wwfs == "半卧")
                {
                    this.CKB1.Checked = true;
                }
                if (inpatientproofinfo.Wwfs == "休克卧")
                {
                    this.CKB2.Checked = true;
                }
                if (inpatientproofinfo.Is_ys == "禁食")
                {
                    this.CKB3.Checked = true;
                }
                if (inpatientproofinfo.Is_ys == "食")
                {
                    this.CKB4.Checked = true;
                }
                if (inpatientproofinfo.Is_tj == "抬架")
                {
                    this.CKB5.Checked = true;
                }
                if (inpatientproofinfo.Is_zx == "自行")
                {
                    this.CKB6.Checked = true;
                }
                if (inpatientproofinfo.Is_my == "沐浴")
                {
                    this.CKB7.Checked = true;
                }
                if (inpatientproofinfo.Is_lf == "理发")
                {
                    this.CKB8.Checked = true;
                }
                if (inpatientproofinfo.Is_drug == "用")
                {
                    this.CB1.Checked = true;
                }
                if (inpatientproofinfo.Is_drug == "不用")
                {
                    this.CB2.Checked = true;
                }
                if (inpatientproofinfo.Ops_type == "大")
                {
                    this.CB3.Checked = true;
                }
                if (inpatientproofinfo.Ops_type == "中")
                {
                    this.CB4.Checked = true;
                }
                if (inpatientproofinfo.Ops_type == "小")
                {
                    this.CB5.Checked = true;
                }
                if (inpatientproofinfo.Xxfs == "一般")
                {
                    this.CB6.Checked = true;
                }
                if (inpatientproofinfo.Xxfs == "特别")
                {
                    this.CB7.Checked = true;
                }

            }
        }
        /// <summary>
        /// 显示患者基本信息
        /// </summary>
        /// 
        private void SetPatient(Neusoft.HISFC.Models.Registration.Register register)
        {
            if (!string.IsNullOrEmpty(register.PID.CardNO))
            {
                this.tempRegister = register;
                this.txtName.Text = this.patientInfo.Name; //姓名
                this.cmbSex.Text = this.patientInfo.Sex.Name;            //性别
                this.cmbSex.Tag = this.patientInfo.Sex.ID;               //性别
                this.txtCLINIC.Text = register.ID;   //门诊号
                this.txtCARDNO.Text = register.PID.CardNO; //卡号
                this.dtpBirthDay.Value = register.Birthday;      //出生日期
                this.txtAge.Text = Neusoft.HISFC.BizProcess.Integrate.Function.GetAge(this.patientInfo.Birthday);//年龄
                this.txtIDNO.Text = this.patientInfo.IDCard;             //身份证号
                this.cmbHomeAddress.Text = this.patientInfo.AddressHome;  //家庭住址
                this.cmbDept.Text = register.DoctorInfo.Templet.Dept.Name;
                this.cmbDept.Tag = register.DoctorInfo.Templet.Dept.ID;
                this.cmbDoctor.Text = register.DoctorInfo.Templet.Doct.Name;//看诊医生
                this.cmbDoctor.Tag = register.DoctorInfo.Templet.Doct.ID;
            }
        }
        /// <summary>
        /// 数据合理化校验
        /// </summary>
        /// <returns></returns>
        protected virtual bool InputValid()
        {
            if (this.txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入患者姓名，姓名不能为空！"));
                this.txtName.Focus();
                return false;
            }

            if (this.cmbSex.Tag.ToString() == string.Empty)
            {
                MessageBox.Show(Language.Msg("请输入患者性别，性别不能为空！"));
                this.cmbSex.Focus();
                return false;
            }


            //姓名长度过长
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text, 16))
            {
                MessageBox.Show(Language.Msg("姓名长度过长"));
                this.txtName.Focus();
                return false;
            }
            //判断性别
            if (this.cmbSex.Text.Trim() == "")
            {
                MessageBox.Show(Language.Msg("性别不能为空，请输入性别"));
                this.cmbSex.Focus();
                return false;
            }
            if (this.dtpBirthDay.Value.Date > this.regMgr.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();

                return false;
            }


            return true;
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        protected virtual void Clear()
        {
            this.txtName.Text = string.Empty;
            this.txtIDNO.Text = string.Empty;
            this.txtName.Enabled = false;
            this.txtIDNO.Enabled = true;
            this.cmbHomeAddress.Text = string.Empty;
            this.txtAge.Text = string.Empty;
            this.txtCLINIC.Text = string.Empty;
            this.txtCARDNO.Text = string.Empty;
            this.cmbDept.Text = string.Empty;
            this.cmbDoctor.Text = string.Empty;
            this.txtInDiagnosis.Text = string.Empty;
            this.dtpBirthDay.Value = System.DateTime.Now;
            this.txtINTEXT.Text = string.Empty;
            this.neuTextBox1.Text = string.Empty;
            this.neuTextBox2.Text = string.Empty;
            foreach (Control c in this.Controls)
            {
                if (c is Neusoft.FrameWork.WinForms.Controls.NeuCheckBox)
                {
                    (c as Neusoft.FrameWork.WinForms.Controls.NeuCheckBox).Checked = false;
                }
            }
        }

        /// <summary>
        /// 获取住院证实体
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.RADT.InPatientProof GetInPatientProofInfo()
        {
            inpatientproof = new Neusoft.HISFC.Models.RADT.InPatientProof();
            //InPatientProof.PID.CardNO = cardNO;
            inpatientproof.Card_no = this.txtCARDNO.Text;     //门诊卡号
            inpatientproof.Clinic_code = this.txtCLINIC.Text; //门诊流水号
            inpatientproof.Name = this.txtName.Text; //姓名
            inpatientproof.Idenno = this.txtIDNO.Text; //身份证
            inpatientproof.Sex_code.ID = this.cmbSex.Tag.ToString(); //性别
            inpatientproof.Birthday = this.dtpBirthDay.Value;//出生日期
            inpatientproof.Age = this.txtAge.Text;//年龄
            inpatientproof.Dept_code.ID = this.cmbDept.Tag.ToString();//科室
            inpatientproof.Dept_code.Name = this.cmbDept.Text.ToString(); //科室名称
            inpatientproof.Room = string.Empty; //病室
            inpatientproof.Diagnose = this.txtInDiagnosis.Text; //入院诊断
            inpatientproof.Address = this.cmbHomeAddress.Text.ToString(); //地址
            inpatientproof.Intext = this.txtINTEXT.Text; //内容
            if (this.CKB1.Checked == true)
            {
                inpatientproof.Wwfs = this.CKB1.Text;
            }
            if (this.CKB2.Checked == true)
            {
                inpatientproof.Wwfs = this.CKB2.Text;
            }
            if (this.CKB3.Checked == true)
            {
                inpatientproof.Is_ys = this.CKB3.Text;
            }
            if (this.CKB4.Checked == true)
            {
                inpatientproof.Is_ys = this.CKB4.Text;
            }
            if (this.CKB5.Checked == true)
            {
                inpatientproof.Is_tj = this.CKB5.Text;
            }

            if (this.CKB6.Checked == true)
            {
                inpatientproof.Is_zx = this.CKB6.Text;
            }
            if (this.CKB7.Checked == true)
            {
                inpatientproof.Is_my = this.CKB7.Text;
            }
            if (this.CKB8.Checked == true)
            {
                inpatientproof.Is_lf = this.CKB8.Text;
            }
            inpatientproof.In_date = this.accountManager.GetDateTimeFromSysDateTime();//开证日期
            inpatientproof.Doct_code.ID = this.cmbDoctor.Tag.ToString(); //医生
            inpatientproof.Doct_code.Name = this.cmbDoctor.Text.ToString();//医生姓名
            inpatientproof.Inpatient_count = NConvert.ToInt32(this.neuTextBox1.Text);//住院约计日数
            if (this.CB1.Checked == true) //是否贵重药品
            {
                inpatientproof.Is_drug = this.CB1.Text;
            }
            else if (this.CB2.Checked == true)
            {
                inpatientproof.Is_drug = this.CB2.Text;
            }
            else
            {
                inpatientproof.Is_drug = string.Empty; 
            }

            if (this.CB3.Checked == true) //手术类型
            {
                inpatientproof.Ops_type = this.CB3.Text;
            }
            else if (this.CB4.Checked == true)
            {
                inpatientproof.Ops_type = this.CB4.Text;
            }
            else if (this.CB5.Checked == true)
            {
                inpatientproof.Ops_type = this.CB5.Text;
            }
            else
            {
                inpatientproof.Ops_type = string.Empty;
            }
            inpatientproof.Blood_qty = NConvert.ToInt32(neuTextBox2.Text); //输血数量

            if (this.CB6.Checked == true) //X线
            {
                inpatientproof.Xxfs = this.CB6.Text;
            }
            else if (this.CB7.Checked == true)
            {
                inpatientproof.Xxfs = this.CB7.Text;
            }
            else
            {
                inpatientproof.Xxfs = string.Empty;
            }
            inpatientproof.Memo = string.Empty;
            inpatientproof.Memo1 = string.Empty;

            return inpatientproof;
        }
        protected override int OnSave(object sender, object neuObject)
        {
            this.save();

            return base.OnSave(sender, neuObject);
        }
        public virtual void save()
        {
            Neusoft.FrameWork.WinForms.Forms.frmWait frmWait = new Neusoft.FrameWork.WinForms.Forms.frmWait();
            frmWait.Text = "保存中，请稍后……";
            frmWait.Show();
            if (!this.InputValid())
            {
                return;
            }
            #region 设置事物

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            #endregion

            //住院证实体
            Neusoft.HISFC.Models.RADT.InPatientProof inpatientproof = this.GetInPatientProofInfo();
            if (inpatientproof == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("住院证信息不能为空"));
                return;
            }

            int returnValue = 0;

            returnValue = this.radtIntegrate.InPatientProof(inpatientproof);
            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新住院证信息失败！\n" + this.regMgr.Err);
                return;
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            #region 住院证打印
            if (string.IsNullOrEmpty(inpatientproof.Clinic_code))
            {
                MessageBox.Show("取住院证实体信息失败！\n" + this.regMgr.Err);
                return;
            }
            else
            {
                this.inpatientproofPrint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientProofPrint)) as Neusoft.HISFC.BizProcess.Interface.FeeInterface.IInpatientProofPrint;

                if (this.inpatientproofPrint == null)
                {

                }
                else
                {
                    this.inpatientproofPrint.Clear();
                    this.inpatientproofPrint.SetValue(this.inpatientproof);
                    this.inpatientproofPrint.Print();
                }
            }
            #endregion
            frmWait.Close();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功！"), Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Clear();
        }
        /// <summary>
        /// 初始化多患者弹出窗口
        /// </summary>
        protected virtual void InitPopShowPatient()
        {
            fPopWin.Width = ucShow.Width + 10;
            fPopWin.MinimizeBox = false;
            fPopWin.MaximizeBox = false;
            fPopWin.Controls.Add(ucShow);
            ucShow.Dock = DockStyle.Fill;
            fPopWin.Height = 200;
            fPopWin.Visible = false;
            fPopWin.KeyDown += new KeyEventHandler(fPopWin_KeyDown);
            this.ucShow.SelectedPatient += new ZZLocal.Clinic.HISFC.Components.OutpatientFee.Controls.ucShowPatientsForModify.GetPatient(ucShow_SelectedPatient);
        }
        /// <summary>
        /// 根据出生日期换算年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            ////{DA67A335-E85E-46e1-A672-4DB409BCC11B}
            //this.txtAge.Text = this.accountManager.GetAge(this.dtpBirthDay.Value);
            this.txtAge.Text = this.regMgr.GetAge(this.dtpBirthDay.Value);
        }
        #endregion

        #region 事件
  
        /// <summary>
        /// 打开患者多次挂号UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void fPopWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.fPopWin.Close();
            }
        }

        /// <summary>
        /// 选择患者事件
        /// </summary>
        /// <param name="register"></param>
        protected virtual void ucShow_SelectedPatient(Neusoft.HISFC.Models.Registration.Register register)
        {
            if (register == null)
            {
            }
            else
            {
                this.setInfo(register);
            }
        }
        //private void btnReadCard_Click(object sender, EventArgs e)
        //{
        //        if (icreader.GetConnect())
        //        {
        //            cardNO = icreader.ReaderICCard();
        //            if (cardNO == "0000000000")
        //            {
        //                isNewCard = true;
        //                MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
        //            }
        //            else
        //            {
        //                this.tbCardNO.Text = cardNO;
        //                this.tbCardNO_KeyDown(this.tbCardNO, new KeyEventArgs(Keys.Enter));
        //            }
        //            icreader.CloseConnection();
        //        }
        //        else
        //        {
        //            MessageBox.Show("读卡失败！");
        //        }
        //    }
        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            idreader.ReadICCardComplete += new ZZlocal.Clinic.HISFC.OuterConnector.IDCard.IDReader.De_ReadICCardComplete(idreader_ReadICCardComplete);
            idreader.ReadICCard();
        }

        void idreader_ReadICCardComplete(ZZlocal.Clinic.HISFC.OuterConnector.IDCard.clsEDZ objEDZ)
        {
            this.txtName.Text = objEDZ.Name.Trim();
            this.dtpBirthDay.Value = Convert.ToDateTime(objEDZ.BIRTH);
            this.cmbSex.Text = "";
            this.cmbSex.SelectedText = objEDZ.Sex_CName;
            this.dtpBirthDay_ValueChanged(null, null);
            //this.cmbCountry.SelectedText = "";
            //this.cmbCountry.SelectedText = "中国";
            //this.cmbRelation.SelectedText = objEDZ.People.Trim();
            //this.cmbCardType.SelectedText = "";
            //this.cmbCardType.SelectedText = "身份证";
            this.txtIDNO.Text = objEDZ.IDC.Trim();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (tbCardNO.ContainsFocus)
                {
                    this.tbCardNO_KeyDown(this.tbCardNO, new KeyEventArgs(Keys.Enter));
                    return true;
                }
                if (btnReadCard.ContainsFocus)
                {
                    btnReadCard_Click(this, null);
                }
                if (cmbDoctor.ContainsFocus)
                {
                    txtINTEXT.Focus();
                    return true;
                }
                if (btSave.ContainsFocus)
                {
                    btSave_Click(this, null);
                }
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        private void tbCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            string cardNO = this.tbCardNO.Text.Trim();

            if (cardNO == "" || cardNO == null)
            {
                MessageBox.Show("请输入就诊卡号");
                tbCardNO.Focus();
                return;
            }
            cardNO = cardNO.PadLeft(10, '0');

            this.tbCardNO.Text = cardNO;


            this.ucShow.CardNO = cardNO;
            ucShow.OrgCardNO = cardNO;
            ucShow.operType = "1";//直接输入
            ucShow.ValidDays = 0;
            ucShow.RecipeNOValidDays = 0;
            if (ucShow.PersonCount == 0)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("该患者没有挂号信息!"));
            }
            if (ucShow.PersonCount > 1)
            {
                fPopWin.Show();
                fPopWin.Hide();
                Point cardLocation = this.tbCardNO.Location;
                fPopWin.Location = new Point(cardLocation.X, cardLocation.Y - 3);
                //fPopWin.Location = ((Control)this.neuGroupBox1).PointToScreen(new Point(this.lblCardNO.Size.Width, -this.tbCardNO.Size.Width));
                fPopWin.ShowDialog();
                fPopWin.Focus();
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.save();
        }


        private void btnReadCard_Click(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardNO = icreader.ReaderICCard();
                if (cardNO == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.tbCardNO.Text = cardNO;
                    this.tbCardNO_KeyDown(this.tbCardNO, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
    }
}

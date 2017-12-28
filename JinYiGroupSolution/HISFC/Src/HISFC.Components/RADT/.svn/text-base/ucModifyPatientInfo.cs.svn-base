using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Management;
using Neusoft.HISFC.Object.RADT;
using Neusoft.HISFC.Object.Fee.Inpatient;
using Neusoft.HISFC.Object.Fee;
using Neusoft.HISFC.Object.Base;
using Neusoft.NFC.Function;
using Neusoft.NFC.Interface.Forms;

namespace Neusoft.UFC.RADT.Controls
{
    /// <summary>
    /// ucModifyPatientInfo<br></br>
    /// [功能描述: 修改住院登记的信息]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2007-1-8]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucModifyPatientInfo : Neusoft.NFC.Interface.Controls.ucBaseControl
    {
        public ucModifyPatientInfo()
        {
            InitializeComponent();
        }

        private void ucModifyPatientInfo_Load(object sender, EventArgs e)
        {
            Init();
        }

        #region 字段

        /// <summary>
        /// 打印病案
        /// </summary>
        Neusoft.HISFC.Integrate.HealthRecord.HealthRecordInterface healthPrint = null;

        /// <summary>
        /// 患者信息实体
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new PatientInfo();

        /// <summary>
        /// 患者信息实体副本
        /// </summary>
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfoOld;

        /// <summary>
        /// Manager业务层
        /// </summary>
        private Neusoft.HISFC.Integrate.Manager managerIntegrate = new Neusoft.HISFC.Integrate.Manager();

        /// <summary>
        /// 住院入出转业务层
        /// </summary>
        private Neusoft.HISFC.Management.RADT.InPatient inpatientManager = new Neusoft.HISFC.Management.RADT.InPatient();

        /// <summary>
        /// 住院费用大业务层
        /// </summary>
        private Neusoft.HISFC.Integrate.Fee feeManager = new Neusoft.HISFC.Integrate.Fee();

        /// <summary>
        /// 患者入出转转业务层
        /// </summary>
        private Neusoft.HISFC.Integrate.RADT radtIntegrate = new Neusoft.HISFC.Integrate.RADT();

        /// <summary>
        /// toolBarService
        /// </summary>
        protected Neusoft.NFC.Interface.Forms.ToolBarService toolBarService = new Neusoft.NFC.Interface.Forms.ToolBarService();

        
        #endregion

        #region 方法

        /// <summary>
        /// 增加ToolBar控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.NFC.Interface.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("确定", "确定",Neusoft.NFC.Interface.Classes.EnumImageList.A保存, true, false, null);
            toolBarService.AddToolButton("清屏", "清屏",Neusoft.NFC.Interface.Classes.EnumImageList.A清空, true, false, null);
            toolBarService.AddToolButton("帮助", "打开帮助文件", Neusoft.NFC.Interface.Classes.EnumImageList.A帮助, true, false, null);
            toolBarService.AddToolButton("退出", "退出", Neusoft.NFC.Interface.Classes.EnumImageList.A退出, true, true, null);
            toolBarService.AddToolButton("补打", "补打", Neusoft.NFC.Interface.Classes.EnumImageList.A打印, true, true, null);
            
            return this.toolBarService;
        }

        /// <summary>
        /// 定义toolbar按钮click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "确定":

                    this.Confirm();
                    break;

                case "清屏":
                    this.Clear();
                    this.ucQueryInpatientNo1.Text = "";
                    this.ucQueryInpatientNo1.Focus();
                    break;

                case "帮助":

                    break;
                case "退出":
                    this.FindForm().Close();
                    break;
                case "补打":
                    this.Print();
                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        /// <summary>
        /// 初始化控件,等信息
        /// </summary>
        /// <returns>成功 1 失败: -1</returns>
        protected virtual int Init()
        {

            Neusoft.NFC.Interface.Classes.Function.ShowWaitForm(Language.Msg("正在初始化窗口，请稍候^^"));
            Application.DoEvents();

            #region 病案打印
            object[] o = new object[] { };

            try
            {

                Neusoft.HISFC.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.Integrate.Common.ControlParam();

                System.Runtime.Remoting.ObjectHandle objHande = System.Activator.CreateInstance("UFC.HealthRecord", "Neusoft.UFC.HealthRecord.ucLCCasePrint", false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

                object oLabel = objHande.Unwrap();

                this.healthPrint = oLabel as Neusoft.HISFC.Integrate.HealthRecord.HealthRecordInterface;
            }
            catch (System.TypeLoadException ex)
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));
                return -1;
            }
            #endregion

            try
            {
                //性别列表
                this.cmbSex.AddItems(Neusoft.HISFC.Object.Base.SexEnumService.List());
                this.cmbSex.Text = "男";

                //民族
                this.cmbNation.AddItems(managerIntegrate.GetConstantList(EnumConstant.NATION));
                this.cmbNation.Text = "汉族";

                //婚姻状态
                this.cmbMarry.AddItems(Neusoft.HISFC.Object.RADT.MaritalStatusEnumService.List());

                //国家
                this.cmbCountry.AddItems(managerIntegrate.GetConstantList(EnumConstant.COUNTRY));
                this.cmbCountry.Text = "中国";

                //职业信息
                this.cmbProfession.AddItems(managerIntegrate.GetConstantList(EnumConstant.PROFESSION));

                //工作单位
                this.cmbWorkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //联系人信息
                this.cmbRelation.AddItems(managerIntegrate.GetConstantList(EnumConstant.RELATIVE));

                //联系人地址信息
                this.cmbLinkAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //家庭住址信息
                this.cmbHomeAddress.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //籍贯
                this.cmbDistrict.AddItems(managerIntegrate.GetConstantList(EnumConstant.DIST));

                //病人来源信息
                this.cmbInSource.AddItems(managerIntegrate.GetConstantList(EnumConstant.INSOURCE));
                this.cmbInSource.SelectedIndex = 0;

                //入院途径信息
                this.cmbApproach.AddItems(managerIntegrate.GetConstantList(EnumConstant.INAVENUE));
                this.cmbApproach.SelectedIndex = 0;

                //入院情况信息
                this.cmbCircs.AddItems(managerIntegrate.GetConstantList(EnumConstant.INCIRCS));
                this.cmbCircs.SelectedIndex = 0;

                //医生信息
                this.cmbDoctor.AddItems(managerIntegrate.QueryEmployee(EnumEmployeeType.D));

                //床位间隔
                this.txtBedInterval.Text = "1";

                //入院日期
                this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime(); //入院日期

                //生日
                this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();//出生日期

                //地区
                this.cmbArea.AddItems(managerIntegrate.GetConstantList(EnumConstant.AREA));

                //合同单位{B71C3094-BDC8-4fe8-A6F1-7CEB2AEC55DD}
                //this.cmbPact.AddItems(managerIntegrate.GetConstantList(EnumConstant.PACTUNIT));
                this.cmbPact.AddItems(managerIntegrate.QueryPactUnitAll());
                this.cmbPact.IsListOnly = true;

                this.cmbMark.AddItems(managerIntegrate.GetConstantList(Neusoft.HISFC.Object.Base.EnumConstant.REMARK));
                this.cmbMark.IsListOnly = true;

                //foreach (Control c in this.Controls)
                //{
                //    if (c is Neusoft.NFC.Interface.Controls.NeuComboBox)
                //    {
                //        ((Neusoft.NFC.Interface.Controls.NeuComboBox)c).Enter += new EventHandler(ucRegister_Enter);
                //    }
                //    else
                //    {
                //        c.Enter += new EventHandler(c_Enter);
                //    }
                //}
             
            }
            catch (Exception e)
            {
                Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
                MessageBox.Show(e.Message);

                return -1;
            }

            //this.RefreshPatientLists();

            Neusoft.NFC.Interface.Classes.Function.HideWaitForm();
            return 1;
        }



        /// <summary>
        /// 设置患者信息到控件
        /// </summary>
        /// <param name="patientInfo"></param>
        protected void SetPatientInfo(Neusoft.HISFC.Object.RADT.PatientInfo patientInfo)
        {
            this.patientInfo = patientInfo;
            Neusoft.HISFC.Object.RADT.Patient Patient = patientInfo;
            this.chbEncrypt.Checked = patientInfo.IsEncrypt;
            if (patientInfo.IsEncrypt)
            {
                patientInfo.Name = Neusoft.NFC.Interface.Classes.Function.Decrypt3DES(patientInfo.NormalName);
            }
            this.txtName.Text = patientInfo.Name;               //姓名
            this.cmbSex.Text = patientInfo.Sex.Name;            //性别
            this.cmbSex.Tag = patientInfo.Sex.ID;               //性别
            this.txtCardNO.Text = patientInfo.PID.CardNO;       //就诊卡号
            this.txtCardNO.ReadOnly = true;
            this.cmbPact.Text = patientInfo.Pact.Name;          //合同单位名称
            this.cmbPact.Tag = patientInfo.Pact.ID;             //合同单位ID
            this.cmbPact.IsListOnly = true;
            this.cmbArea.Tag = patientInfo.AreaCode;            //地区
            this.cmbCountry.Tag = patientInfo.Country.ID;       //国籍
            this.cmbNation.Tag = patientInfo.Nationality.ID;    //民族
            this.dtpBirthDay.Value = patientInfo.Birthday;      //出生日期
            this.txtAge.Text = this.inpatientManager.GetAge(patientInfo.Birthday);//年龄
            this.cmbDistrict.Text = patientInfo.DIST;            //籍贯
            this.cmbProfession.Tag = patientInfo.Profession.ID; //职业
            this.txtIDNO.Text = patientInfo.IDCard;             //身份证号
            this.cmbWorkAddress.Text = patientInfo.CompanyName; //工作单位
            this.txtWorkPhone.Text = patientInfo.PhoneBusiness; //单位电话
            this.cmbMarry.Tag = patientInfo.MaritalStatus.ID.ToString();//婚姻状况
            this.cmbHomeAddress.Text = patientInfo.AddressHome;  //家庭住址
            this.txtHomePhone.Text = patientInfo.PhoneHome;     //家庭电话
            this.txtLinkMan.Text = patientInfo.Kin.Name;        //联系人
            this.cmbRelation.Tag = patientInfo.Kin.Relation.ID; //联系人关系
            this.cmbLinkAddress.Text = patientInfo.Kin.RelationAddress;//联系人地址

            this.txtLinkPhone.Text = patientInfo.Kin.RelationPhone;//联系人电话
            this.cmbInSource.Tag = patientInfo.PVisit.InSource.ID;//入院来源
            this.cmbApproach.Tag = patientInfo.PVisit.AdmitSource.ID;//入院途径
            this.cmbCircs.Tag = patientInfo.PVisit.Circs.ID;    //入院情况
            this.txtBedInterval.Text = patientInfo.FT.FixFeeInterval.ToString();//床位间隔
            this.dtpInTime.Value = patientInfo.PVisit.InTime;   //入院日期
            this.cmbDoctor.Tag = patientInfo.DoctorReceiver.ID; //收住院医师
            this.cmbMark.Tag = patientInfo.Memo;                //特注
            this.ucQueryInpatientNo1.txtInputCode.Text = patientInfo.PID.PatientNO; //住院号            

            
        }



        #endregion

        /// <summary>
        ///　对控件进行赋值
        /// </summary>
        private void ucQueryInpatientNo1_myEvent()
        {
            patientInfo = null;
            if (this.ucQueryInpatientNo1.InpatientNo == "")
            {
                Neusoft.NFC.Interface.Classes.Function.Msg("不存在该患者，或者该患者已经出院！",111);
                this.Clear();
                return;
            }
            //获取住院号赋值给实体
            
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo1.InpatientNo);

            if (this.patientInfo == null)
            {
                MessageBox.Show(this.radtIntegrate.Err);
                this.ucQueryInpatientNo1.Focus();

                return;
            }

            this.patientInfoOld = this.patientInfo.Clone();

            SetPatientInfo(this.patientInfo);

            this.txtName.Focus();
        }

        /// <summary>
        /// 获得控件输入的信息,合成患者基本信息实体
        /// </summary>
        /// <param name="patient">患者基本信息实体</param>
        /// <returns> 成功: true 失败 : false</returns>
        private bool GetPatientInfomation(PatientInfo patientInfo)
        {
            if (patientInfo == null)
            {
                Neusoft.NFC.Interface.Classes.Function.Msg("患者信息实体为空!",111);

                return true;
            }

            patientInfo.Name = this.txtName.Text;                           //姓名
            if (cmbSex.Tag != null)
            {
                patientInfo.Sex.ID = this.cmbSex.Tag.ToString();                    //性别
            }
            if (cmbArea.Tag != null)
            {
                patientInfo.AreaCode = this.cmbArea.Tag.ToString();                 //地区
            }
            if (this.cmbCountry.Tag != null)
            {
                patientInfo.Country.ID = this.cmbCountry.Tag.ToString();            //国籍
            }
            if (this.cmbNation.Tag != null)
            {
                patientInfo.Nationality.ID = this.cmbNation.Tag.ToString();         //民族
            }
            patientInfo.Birthday = this.dtpBirthDay.Value;                      //出生日期
            if (this.cmbDistrict.Tag != null)
            {
                patientInfo.DIST = this.cmbDistrict.Text.ToString();                 //籍贯
            }
            if (this.cmbProfession.Tag != null)
            {
                patientInfo.Profession.ID = this.cmbProfession.Tag.ToString();      //职业
            }
            patientInfo.IDCard = this.txtIDNO.Text;                             //身份证号
            patientInfo.CompanyName = this.cmbWorkAddress.Text;       //工作单位
            //patientInfo.PhoneBusiness = this.txtHomePhone.Text;                 //单位电话
            patientInfo.PhoneBusiness =this.txtWorkPhone.Text;                 //单位电话
            if (this.cmbMarry.Tag != null)
            {
                patientInfo.MaritalStatus.ID = this.cmbMarry.Tag.ToString();        //婚姻状况
            }
            if (cmbHomeAddress.Tag != null)
            { 
                patientInfo.AddressHome = this.cmbHomeAddress.Text.ToString();       //家庭住址
            }
            patientInfo.PhoneHome = this.txtHomePhone.Text;                     //家庭电话
            patientInfo.Kin.Name = this.txtLinkMan.Text;                        //联系人
            if (cmbRelation.Tag != null)
            {
                patientInfo.Kin.Relation.ID = this.cmbRelation.Tag.ToString();      //与联系人关系
            }
            patientInfo.Kin.RelationAddress = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.RelationPhone = this.txtLinkPhone.Text;              //联系人电话

            if (cmbInSource.Tag != null)
            {
                patientInfo.PVisit.InSource.ID = this.cmbInSource.Tag.ToString();    //入院来源
            }
            if (cmbInSource.Tag != null)
            {
                patientInfo.PVisit.AdmitSource.ID = this.cmbInSource.Tag.ToString(); //入院途径
            }
            if (cmbCircs.Tag != null)
            {
                patientInfo.PVisit.Circs.ID = this.cmbCircs.Tag.ToString();          //入院情况
            }
            patientInfo.FT.FixFeeInterval = Neusoft.NFC.Function.NConvert.ToInt32(this.txtBedInterval.Text);//床费间隔
            patientInfo.PVisit.InTime = this.dtpInTime.Value;                    //入院日期
            if (cmbDoctor.Tag != null)
            {
                patientInfo.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString();       //收住院医师
            }
            patientInfo.Memo = this.cmbMark.Tag.ToString();                      //特注
            patientInfo.Kin.User01 = this.cmbLinkAddress.Text;//联系人地址
            patientInfo.Kin.Memo = this.txtLinkPhone.Text; //联系人电话
            if (cmbDoctor.Tag != null)
            {
                patientInfo.DoctorReceiver.ID = this.cmbDoctor.Tag.ToString(); //收住医师
            }
            patientInfo.IsEncrypt = this.chbEncrypt.Checked;
            if (this.chbEncrypt.Checked)
            {
                this.patientInfo.NormalName = Neusoft.NFC.Interface.Classes.Function.Encrypt3DES(this.patientInfo.Name);
                this.patientInfo.Name = "******";
                
            }
                        
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool InputValid()
        {
            //判断单位电话长度
            if(!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtWorkPhone.Text,25))
            {
                MessageBox.Show(Language.Msg("单位电话号码长度过长"));
                this.txtWorkPhone.Focus();
                return false;
            }
            //判断家庭电话号码长度
            if (!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("家庭电话号码长度过长"));
                this.txtHomePhone.Focus();
                return false;
            }
            
            //判断身份证号码长度
            string errText = string.Empty;
            if ((this.txtIDNO.Text.Trim() != null && this.txtIDNO.Text.Trim() !=""))
            {
                if (Neusoft.NFC.Interface.Classes.Function.CheckIDInfo(this.txtIDNO.Text, ref errText) == -1)
                {
                    MessageBox.Show(errText);
                    return false;
                }
            }
           
            //判断联系电话号码长度
            if(!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtLinkPhone.Text,30))
            {
                MessageBox.Show(Language.Msg("联系人电话号码长度过长"));
                this.txtLinkPhone.Focus();
                return false;
            }
            if(!Neusoft.NFC.Public.String.ValidMaxLengh(this.txtLinkMan.Text,12))
            {
                MessageBox.Show(Language.Msg("联系人姓名过长"));
                this.txtLinkMan.Focus();
                return false;
            }
            //判断性别
            if(this.cmbSex.Text.Trim() =="")
            {
                MessageBox.Show(Language.Msg("性别不能为空，请输入性别"));
                this.cmbSex.Focus();
                return false;
            }
            //判断入院来源
            if(this.cmbInSource.Text.Trim() =="")
            {
                MessageBox.Show(Language.Msg("入院来源不能为空，请输入入院来源"));
                return false;
            }

            if (this.dtpBirthDay.Value > this.inpatientManager.GetDateTimeFromSysDateTime().Date)
            {
                MessageBox.Show(Language.Msg("出生日期大于当前日期,请重新输入!"));
                this.dtpBirthDay.Focus();

                return false;
            }
            if (Convert.ToInt32(this.txtBedInterval.Text) == 0)
            {
                MessageBox.Show(Language.Msg("床费间隔只能为大于零的数，请重新输入！"));
                this.txtBedInterval.Focus();
                this.txtBedInterval.SelectAll();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 确定方法
        /// </summary>
        /// <returns></returns>
         protected virtual int Confirm()
        {
            if ( patientInfoOld == null||patientInfo == null)
            {
                Neusoft.NFC.Interface.Classes.Function.Msg("请输入住院号",111);
                return -1;
            }

            //验证有效性,如果有不符合录入,那么中止方法
            if (!this.InputValid())
            {
                return -1;
            }

            //得到患者基本信息
            if (!this.GetPatientInfomation(this.patientInfo))
            {
                return -1;
            }

            //创建数据库连接

            Neusoft.NFC.Management.PublicTrans.BeginTransaction();
            //Neusoft.NFC.Management.Transaction t = new Transaction(this.inpatientManager.Connection);
            ////开始事物
            //t.BeginTransaction();
            this.inpatientManager.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);
            this.radtIntegrate.SetTrans(Neusoft.NFC.Management.PublicTrans.Trans);

            //判断患者病床信息，是否已接诊，防止并发
            Neusoft.HISFC.Object.RADT.PatientInfo patientInfoReGet = new PatientInfo();
            patientInfoReGet = this.radtIntegrate.GetPatientInfoByPatientNO(this.patientInfo.ID);
            //如当前患者床位信息为空 且 重新获取患者床位信息不为空 则提示
            //{1C12B07D-82EE-4e27-A0CD-794F8AA58F9E}
            if (string.IsNullOrEmpty(this.patientInfo.PVisit.PatientLocation.Bed.ID) && !string.IsNullOrEmpty(patientInfoReGet.PVisit.PatientLocation.Bed.ID))
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                Neusoft.NFC.Interface.Classes.Function.Msg("保存失败！" + "患者信息已发生变动，请刷新后再试一次！", 211);
                return -1;
            }

            //{1C12B07D-82EE-4e27-A0CD-794F8AA58F9E}
            if (patientInfoReGet.PVisit.PatientLocation.Bed.ID != patientInfo.PVisit.PatientLocation.Bed.ID)
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                Neusoft.NFC.Interface.Classes.Function.Msg("保存失败！" + "患者信息已发生变动，请刷新后再试一次！", 211);
                return -1;
            }

             //更新患者住院信息
            if ( this.inpatientManager.UpdatePatient(this.patientInfo) != 1)
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                Neusoft.NFC.Interface.Classes.Function.Msg("保存失败！" + this.inpatientManager.Err, 211);
                
                return -1;
            }
            
            //更新患者基本信息
             if (this.inpatientManager.UpdatePatientInfo(this.patientInfo) !=1)
             {
                 Neusoft.NFC.Management.PublicTrans.RollBack();
                 Neusoft.NFC.Interface.Classes.Function.Msg("保存失败!" + this.inpatientManager.Err, 211);

                 return -1;
             }

            
            //插入变更信息
            if (this.radtIntegrate.InsertShiftData(this.patientInfo.ID, Neusoft.HISFC.Object.Base.EnumShiftType.F, "患者基本信息修改", patientInfoOld, patientInfo) == -1) 
            {
                Neusoft.NFC.Management.PublicTrans.RollBack();
                Neusoft.NFC.Interface.Classes.Function.Msg("插入变更信息出错!" + this.inpatientManager.Err, 211);

                return -1;
            }

            //提交事物
            Neusoft.NFC.Management.PublicTrans.Commit();
       
            

            Neusoft.NFC.Interface.Classes.Function.Msg("修改成功!",111);

            //清空控件
            this.Clear();

            return 1;
        }
        

        /// <summary>
        /// 清空控件信息
        /// </summary>
        protected virtual void Clear()
        {
            this.txtName.Text = string.Empty;
            this.txtIDNO.Text = string.Empty;
            this.cmbMarry.Text = string.Empty;
            this.cmbPact.Text = string.Empty;
            this.cmbArea.Text = string.Empty;
            this.cmbCountry.Text = string.Empty;
            this.cmbProfession.Text = string.Empty;
            this.txtLinkMan.Text = string.Empty;
            this.cmbRelation.Text = string.Empty;
            this.cmbLinkAddress.Text = string.Empty;
            this.txtHomePhone.Text = string.Empty;
            this.txtWorkPhone.Text = string.Empty;
            this.cmbInSource.Text = string.Empty;
            this.cmbDoctor.Text = string.Empty;
            this.cmbInSource.SelectedIndex = 0;
            this.cmbApproach.SelectedIndex = 0;
            this.cmbCircs.SelectedIndex = 0;
            this.txtBedInterval.Text = "1";
            this.cmbArea.Text = string.Empty;
            this.txtName.Enabled = true;
            this.txtIDNO.Enabled = true;
            this.cmbHomeAddress.Text = string.Empty;
            this.cmbWorkAddress.Text = string.Empty;
            this.txtCardNO.Text = string.Empty;
            //this.cmbSex.Text = string.Empty;
            //this.cmbNation.Text = string.Empty;
            this.dtpInTime.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.dtpBirthDay.Value = this.inpatientManager.GetDateTimeFromSysDateTime();
            this.txtAge.Text = string.Empty;
            this.txtAge.ReadOnly = true;
            this.txtHomePhone.Text = string.Empty;
            this.txtLinkPhone.Text = string.Empty;
            this.patientInfo = null;
            this.patientInfoOld = null;
            this.ucQueryInpatientNo1.Text = string.Empty;
            this.cmbMark.Text = string.Empty;
            this.chbEncrypt.Checked = false;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!this.ucQueryInpatientNo1.TextBox.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                   
                    return true;
                }
            }
            else 
            {
                return false;
            }
            
            return base.ProcessDialogKey(keyData);
        }

        
        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            DateTime nowTime = this.inpatientManager.GetDateTimeFromSysDateTime();

        

            if (this.dtpBirthDay.Value > nowTime)
            {
               
                //MessageBox.Show(Language.Msg("患者的生日不能大于当前系统时间!"));

                this.dtpBirthDay.Value = nowTime;

                return;
            }

            this.txtAge.Text = this.inpatientManager.GetAge(this.dtpBirthDay.Value);
        }

        protected void Print()
        {
            if (patientInfo == null)
            {
                MessageBox.Show("请输入患者");
                return;
            }
            # region 打印病案
            DialogResult rs = MessageBox.Show(Language.Msg("是否打印病案?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Neusoft.HISFC.Object.HealthRecord.Base parmPatientinfo = new Neusoft.HISFC.Object.HealthRecord.Base();
                parmPatientinfo.PatientInfo = this.patientInfo;

                this.healthPrint.ControlValue(parmPatientinfo);
                //this.healthPrint.PrintPreview();
                this.healthPrint.Print();
            }
            #endregion
        }

    }
}

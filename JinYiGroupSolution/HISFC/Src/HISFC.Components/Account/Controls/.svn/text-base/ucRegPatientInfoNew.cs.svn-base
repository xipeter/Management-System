using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;
using System.Collections;

namespace Neusoft.HISFC.Components.Account.Controls
{
    public partial class ucRegPatientInfoNew : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer
    {
        public ucRegPatientInfoNew()
        {
            InitializeComponent();
        }

        #region 变量 2011-3-10

        /// <summary>
        /// 业务管理层
        /// </summary>
        Neusoft.FrameWork.Management.DataBaseManger dataManger = new Neusoft.FrameWork.Management.DataBaseManger();

        private Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        private Neusoft.HISFC.BizProcess.Integrate.Registration.Registration regMgr = new Neusoft.HISFC.BizProcess.Integrate.Registration.Registration();
        
        //private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = null;

        /// <summary>
        /// 门诊卡号
        /// </summary>
        private string cardNO = string.Empty;

        /// <summary>
        /// 是否新建门诊卡号
        /// </summary>
        private bool IsNewCardNo = true;

        #endregion

        #region 属性 2011-3-10
        private Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        public Neusoft.HISFC.Models.RADT.PatientInfo Patient
        {
            get
            {
                return patientInfo;
            }
            set
            {
                patientInfo = value;
            }
        }
        #endregion

        #region 方法 2011-3-10

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        public virtual int Init()
        {
            //Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            this.txtCardID.Text = patientInfo.PID.CardNO;
            this.txtName.Text = patientInfo.Name;
            this.txtIDNO.Text = patientInfo.IDCard;
            this.txtHomePhone.Text = patientInfo.PhoneHome;
            try
            {
                this.txtName.Focus();
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
        /// 保存数据
        /// </summary>
        public virtual int save()
        {
            if (!this.InputValid())
            {
                return -1;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在操作，请稍等......");
            Application.DoEvents();

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            this.feeIntegrate.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.GetPatientInfomation();
            if (patientInfo == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者基本信息不能为空"));
                return -1;
            }

            int returnValue = 0;

            ///患者基本信息
            returnValue = this.RegisterPatient(patientInfo);
            if (returnValue <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据失败！") + this.dataManger.Err);

                return -1;
            }

            ///挂号信息补全
            returnValue = this.UpdateRegister(patientInfo);

            if (returnValue < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("更新患者信息失败！\n" + this.dataManger.Err);
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            //显示患者信息
            //this.setInfo(patientInfo);
            IsNewCardNo = false;
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("保存数据成功！"), Neusoft.FrameWork.Management.Language.Msg("提示"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 1;
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

            //判断家庭电话号码是否为空
            if (string.IsNullOrEmpty(this.txtHomePhone.Text))
            {
                MessageBox.Show(Language.Msg("家庭电话号码不能为空"));
                this.txtHomePhone.Focus();
                return false;
            }
            //判断家庭电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtHomePhone.Text, 25))
            {
                MessageBox.Show(Language.Msg("家庭电话号码长度过长"));
                this.txtHomePhone.Focus();
                return false;
            }

            //身份证号不能为空
            if ((this.txtIDNO.Text.Trim() != null && this.txtIDNO.Text.Trim() != ""))
            {
                int returnValue = this.ProcessIDENNO(this.txtIDNO.Text.Trim(), EnumCheckIDNOType.Saveing);
                if (returnValue < 0)
                {
                    //MessageBox.Show(Language.Msg("家庭电话号码长度过长"));
                    return false;
                }
            }

            //判断联系电话号码长度
            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text, 16))
            {
                MessageBox.Show(Language.Msg("姓名长度过长"));
                this.txtName.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// {FD1FD98C-1997-42a4-A046-3EFB15DCA804}
        /// </summary>
        /// <param name="idNO"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
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
                MessageBox.Show("身份证号码信息不对："+errText);
                this.txtIDNO.Focus();
                return -1;
            }
            //string[] reurnString = errText.Split(',');
            //if (enumType == EnumCheckIDNOType.BeforeSave)
            //{
            //    this.dtpBirthDay.Text = reurnString[1];
            //    this.cmbSex.Text = reurnString[2];
            //    this.txtAge.Text = this.regMgr.GetAge(this.dtpBirthDay.Value);

            //    //this.cmbPayKind.Focus();
            //}
            //else
            //{
            //    if (this.dtpBirthDay.Value.Date != (Neusoft.FrameWork.Function.NConvert.ToDateTime(reurnString[1])).Date)
            //    {
            //        MessageBox.Show("输入的生日日期与身份证中号的生日不符");
            //        this.dtpBirthDay.Focus();
            //        return -1;
            //    }

            //    if (this.cmbSex.Text != reurnString[2])
            //    {
            //        MessageBox.Show("输入的性别与身份证中号的性别不符");
            //        this.cmbSex.Focus();
            //        return -1;
            //    }
            //}
            return 1;
        }

        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfomation()
        {
            patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();
            patientInfo.PID.CardNO = this.txtCardID.Text;//门诊卡号
            patientInfo.Name = this.txtName.Text; //患者姓名       
            patientInfo.IDCard = this.txtIDNO.Text;//证件号
            patientInfo.PhoneHome = this.txtHomePhone.Text;//家庭电话
            patientInfo.IsEncrypt = this.ckEncrypt.Checked;

            return patientInfo;
        }

        /// <summary>
        /// 更新患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        public int UpdateRegister(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            string sql = @"update fin_opr_register a
        set a.name = '{1}',
       a.idenno = '{2}',
       a.rela_phone = '{3}'
 where a.card_no = '{0}'";
            try
            {
                string[] strParm = this.myGetParm(patientInfo);
                sql = string.Format(sql, strParm);
            }
            catch (Exception ex)
            {
                this.dataManger.Err = "SQL语句出错：" + ex.Message;
                return -1;
            }
            //finally
            //{
            //    this.dataManger.Reader.Close();
            //}
            return this.dataManger.ExecQuery(sql);
        }

        /// <summary>
        /// 更新患者信息
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <returns></returns>
        public int RegisterPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            string sql = @" update com_patientinfo b set b.name='{1}',b.idenno='{2}',b.home_tel='{3}' where b.card_no='{0}'";
            try
            {
                string[] strParm = this.myGetParm(patientInfo);
                sql = string.Format(sql, strParm);
            }
            catch (Exception ex)
            {
                this.dataManger.Err = "SQL语句出错：" + ex.Message;
                return -1;
            }
            //finally
            //{
            //    this.dataManger.Reader.Close();
            //}
            return this.dataManger.ExecNoQuery(sql);
        }

        /// <summary>
        /// 更新患者信息
        /// </summary>
        /// <param name="matBase"></param>
        /// <returns></returns>
        private string[] myGetParm(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            string[] parm ={ 
                                patientInfo.PID.CardNO,
                                patientInfo.Name,
                                patientInfo.IDCard,
                                patientInfo.PhoneHome
            };
            return parm;
        }

        #endregion

        #region 事件 2011-3-10

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPatientInfo_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Init();
            }
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.save() == 1)
            {
                //MessageBox.Show("挂号成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Parent.Dispose();
            }
        }

        #endregion

        #region 枚举类型2011-3-10

        /// <summary>
        /// 判断身份证//{FD1FD98C-1997-42a4-A046-3EFB15DCA804}身份证信息
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

        #endregion

        #region 读卡

        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();

        private void btReader_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region IInterfaceContainer 成员

        public Type[] InterfaceTypes
        {
            get
            {
                System.Type[] t = new Type[1];

                t[1] = typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IPrintBar);
                return t;
            }

        }

        #endregion
    }
}

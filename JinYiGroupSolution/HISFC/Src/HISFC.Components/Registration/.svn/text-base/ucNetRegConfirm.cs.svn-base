using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.Components.Registration
{
    public partial class ucNetRegConfirm : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucNetRegConfirm()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 集成平台挂号业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.NetRegister netRegManager = new Neusoft.HISFC.BizLogic.Registration.NetRegister();

        /// <summary>
        /// 午别业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();
        
        /// <summary>
        /// 午别帮助实体
        /// </summary>
        Neusoft.FrameWork.Public.ObjectHelper noonHelper = new Neusoft.FrameWork.Public.ObjectHelper();
        
        /// <summary>
        /// 性别服务类
        /// </summary>
        Neusoft.HISFC.Models.Base.SexEnumService sexService = new Neusoft.HISFC.Models.Base.SexEnumService();
        
        /// <summary>
        /// 挂号业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        

        Neusoft.HISFC.BizLogic.Registration.RegLevel regLevelMgr = new Neusoft.HISFC.BizLogic.Registration.RegLevel();

        protected Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam controlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

        private Neusoft.HISFC.BizProcess.Integrate.RADT patientMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        DataSet ds = null;

        string noRegFlagChar = string.Empty;
        #endregion

        #region 事件
        private void ucNetRegConfirm_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        protected override int OnSave(object sender, object neuObject)
        {
            this.Confirm();
            return base.OnSave(sender, neuObject);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.GetNetRegister();
            
            return base.OnQuery(sender, neuObject);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            InitData();
            GetNetRegister();

            return 1;
        }
        
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        private int InitData()
        {
            ArrayList al = noonMgr.Query();
            if (al == null)
            {
                MessageBox.Show("获取午别信息失败！" + noonMgr.Err);
                return -1;
            }
            noonHelper.ArrayObject = al;

            this.noRegFlagChar = this.controlParamIntegrate.GetControlParam<string>(Neusoft.HISFC.BizProcess.Integrate.Const.NO_REG_CARD_RULES, false, "9");
            DateTime dtNow = regMgr.GetDateTimeFromSysDateTime();
            dtBegin.Value = dtNow;
            dtEnd.Value = dtNow;
            return 1;
        }

        /// <summary>
        /// 获取集成平台挂号信息
        /// </summary>
        /// <returns></returns>
        private int GetNetRegister()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在加载数据，请等待.....");
            Application.DoEvents();
            try
            {
                if (dtBegin.Value > dtEnd.Value)
                {
                    MessageBox.Show("开始时间不能大于结束时间！");
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    this.dtBegin.Focus();
                    return -1;
                }
                DateTime dtbegin = Neusoft.FrameWork.Function.NConvert.ToDateTime(dtBegin.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00");
                DateTime dtend = Neusoft.FrameWork.Function.NConvert.ToDateTime(dtEnd.Value.Date.ToString("yyyy-MM-dd") + " 23:59:59");
                ds = netRegManager.GetNetRegister(dtbegin, dtend);
                if (ds == null)
                {
                    MessageBox.Show("获取集成平台挂号信息失败！" + netRegManager.Err);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0], ds.Tables[0].Columns[28] };
                this.SetFp();
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch(Exception ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(ex.Message);
            }
            return 1;
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        private void SetFp()
        {
            int count = this.fpReg_Sheet1.Rows.Count;
            if (count > 0)
            {
                this.fpReg_Sheet1.Rows.Remove(0, count);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SetFP(dr);
            }
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="dr"></param>
        private void SetFP(DataRow dr)
        {
            int count = this.fpReg_Sheet1.Rows.Count;
            this.fpReg_Sheet1.Rows.Add(count, 1);
            this.fpReg_Sheet1.Cells[count, 0].Text = Neusoft.FrameWork.Function.NConvert.ToDateTime(dr[1]).ToString("yyyy-MM-dd"); //看诊时间 
            this.fpReg_Sheet1.Cells[count, 1].Text = noonHelper.GetName(dr[2].ToString());//午别
            this.fpReg_Sheet1.Cells[count, 2].Text = dr[3].ToString();//姓名
            this.fpReg_Sheet1.Cells[count, 3].Text = dr[4].ToString();//身份证号
            sexService.ID = dr[5].ToString();
            this.fpReg_Sheet1.Cells[count, 4].Text = sexService.Name; //性别
            this.fpReg_Sheet1.Cells[count, 5].Text = Neusoft.FrameWork.Function.NConvert.ToDateTime(dr[6].ToString()).ToString("yyyy-MM-dd");//出生日期
            this.fpReg_Sheet1.Cells[count, 6].Text = dr[45].ToString();//联系电话
            this.fpReg_Sheet1.Cells[count, 7].Text = dr[8].ToString();//挂号科室
            this.fpReg_Sheet1.Cells[count, 8].Text = dr[43].ToString();//医生
            this.fpReg_Sheet1.Cells[count, 9].Text = dr[10].ToString();//挂号费
            this.fpReg_Sheet1.Cells[count, 10].Text = dr[11].ToString();//检查费
            this.fpReg_Sheet1.Cells[count, 11].Text = dr[12].ToString();//诊查费
            this.fpReg_Sheet1.Cells[count, 12].Text = dr[13].ToString();//病历本费
            this.fpReg_Sheet1.Cells[count, 13].Text = dr[23].ToString();//结算类别
            this.fpReg_Sheet1.Cells[count, 0].Tag = dr[0].ToString();
            this.fpReg_Sheet1.Cells[count, 1].Tag = dr[28].ToString();
        }

        /// <summary>
        /// 获取挂号信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Register GetReg(DataRow dr)
        {
            Neusoft.HISFC.Models.Registration.Register r = new Neusoft.HISFC.Models.Registration.Register();

            string autoCardNO = this.feeIntegrate.GetAutoCardNO();
            if (autoCardNO == string.Empty)
            {
                MessageBox.Show("获得门诊卡号出错!" + this.feeIntegrate.Err);
               

                return null;
            }

            autoCardNO = this.noRegFlagChar + autoCardNO;

            r.PID.CardNO = autoCardNO;

            r.ID = this.regMgr.GetSequence("Registration.Register.ClinicID");

            
            
            r.TranType = Neusoft.HISFC.Models.Base.TransTypes.Positive;//正交易

            r.DoctorInfo.Templet.RegLevel.ID = dr[31].ToString();

            r.DoctorInfo.Templet.Dept.ID = dr[7].ToString();
            r.DoctorInfo.Templet.Dept.Name = dr[8].ToString();

            r.DoctorInfo.Templet.Doct.ID = dr[42].ToString();
            r.DoctorInfo.Templet.Doct.Name = dr[43].ToString();

            //{0BA561B1-376F-4412-AAD0-F19A0C532A03}
            r.Name = dr[3].ToString();//患者姓名
            r.Sex.ID = dr[5].ToString(); ;//性别

            r.Birthday = Neusoft.FrameWork.Function.NConvert.ToDateTime(dr[6]);//出生日期			


            #region 结算类别
            r.Pact.ID = dr[25].ToString();
            r.Pact.PayKind.ID = dr[22].ToString();
            r.Pact.PayKind.Name = dr[23].ToString();

            #endregion

            r.PhoneHome = dr[45].ToString() ;//联系电话
            r.AddressHome = dr[46].ToString();//联系地址

            r.IsFee = true;
            r.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid;
            r.IsSee = false;
            r.InputOper.ID = this.regMgr.Operator.ID;
            r.InputOper.OperTime = this.regMgr.GetDateTimeFromSysDateTime();
            //add by niuxinyuan
            r.DoctorInfo.SeeDate = r.InputOper.OperTime;
            // add by niuxinyuan
            r.CancelOper.ID = "";
            r.CancelOper.OperTime = DateTime.MinValue;
            r.InvoiceNO = dr[34].ToString();//发票号
            r.DoctorInfo.Templet.Noon.ID = dr[2].ToString();//午别
            r.RecipeNO = "Net";
            return r;
            
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <returns></returns>
        private int Confirm()
        {
            if (this.fpReg_Sheet1.Rows.Count == 0) return -1;
            int index = this.fpReg_Sheet1.ActiveRowIndex;
            string hospitalCode = this.fpReg_Sheet1.Cells[index, 0].Tag.ToString();
            string seq = this.fpReg_Sheet1.Cells[index, 1].Tag.ToString();
            DataRow dr = ds.Tables[0].Rows.Find(new Object[] {hospitalCode,seq });
            if (dr == null)
            {
                MessageBox.Show("获取患者挂号信息失败！");
                return -1;
            }
            Neusoft.HISFC.Models.Registration.Register r = this.GetReg(dr);
            if (r == null) return -1;

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            int orderNo = 0;
            string errText = string.Empty;
            //2看诊序号		
            if (this.UpdateSeeID(r.DoctorInfo.Templet.Dept.ID, r.DoctorInfo.Templet.Doct.ID,
                r.DoctorInfo.Templet.Noon.ID, r.DoctorInfo.SeeDate, ref orderNo,
                ref errText) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(errText, "提示");
                return -1;
            }

            r.DoctorInfo.SeeNO = orderNo;

            //登记挂号信息
            if (this.regMgr.Insert(r) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.regMgr.Err, "提示");
                return -1;
            }

            //更新患者基本信息
            if (InserPatientInfo(r,ref errText) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(patientMgr.Err, "提示");
                return -1;
            }

            if (netRegManager.UpdateConfirm(hospitalCode, seq) <= 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(netRegManager.Err, "提示");
                return -1;
            }
            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show("保存成功！");
            this.fpReg_Sheet1.Rows.Remove(index, 1);
            ds.Tables[0].Rows.Remove(dr);
            return 1;

        }

        /// <summary>
        /// 插入患者信息主表
        /// </summary>
        /// <param name="r"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private int InserPatientInfo(Neusoft.HISFC.Models.Registration.Register r,ref string errText)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo p = new Neusoft.HISFC.Models.RADT.PatientInfo();

            p.PID.CardNO = r.PID.CardNO;
            p.Name = r.Name;
            p.Sex.ID = r.Sex.ID;
            p.Birthday = r.Birthday;
            p.Pact = r.Pact;
            p.Pact.PayKind.ID = r.Pact.PayKind.ID;
            p.SSN = r.SSN;
            p.PhoneHome = r.PhoneHome;
            p.AddressHome = r.AddressHome;
            p.IDCard = r.IDCard;
            p.Memo = r.CardType.ID;
            p.NormalName = r.NormalName;
            p.IsEncrypt = r.IsEncrypt;

            if (patientMgr.RegisterComPatient(p) == -1)
            {
                errText = patientMgr.Err;
                return -1;
            }
            return 1;
        }


        /// <summary>
        /// 更新医生或科室的看诊序号
        /// </summary>
        /// <param name="deptID"></param>
        /// <param name="doctID"></param>
        /// <param name="noonID"></param>
        /// <param name="regDate"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int UpdateSeeID(string deptID, string doctID, string noonID, DateTime regDate,
            ref int seeNo, ref string Err)
        {
            string Type = "", Subject = "";

            #region ""

            if (doctID != null && doctID != "")
            {
                Type = "1";//医生
                Subject = doctID;
            }
            else
            {
                Type = "2";//科室
                Subject = deptID;
            }

            #endregion

            //更新看诊序号
            if (this.regMgr.UpdateSeeNo(Type, regDate, Subject, noonID) == -1)
            {
                Err = this.regMgr.Err;
                return -1;
            }

            //获取看诊序号		
            if (this.regMgr.GetSeeNo(Type, regDate, Subject, noonID, ref seeNo) == -1)
            {
                Err = this.regMgr.Err;
                return -1;
            }

            return 0;
        }

        #endregion
    }


}

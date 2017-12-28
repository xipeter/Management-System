using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
using Neusoft.HISFC.Models.Registration;

namespace Neusoft.HISFC.Components.Registration
{
    /// <summary>
    /// 退号/注销
    /// </summary>
    public partial class ucCancel : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IInterfaceContainer//{B700292D-50A6-4cdf-8B03-F556F990BB9B}
    {
        public ucCancel()
        {
            InitializeComponent();

            this.fpSpread1.KeyDown  += new KeyEventHandler(fpSpread1_KeyDown);
            this.txtInvoice.KeyDown += new KeyEventHandler(txtInvoice_KeyDown);
            this.txtCardNo.KeyDown  += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            this.fpSpread1.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(fpSpread1_SelectionChanged);

            this.Init();
        }

        #region 域
        /// <summary>
        /// 挂号管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();
        /// <summary>
        /// 控制管理类
        /// </summary>
        private Neusoft.FrameWork.Management.ControlParam ctlMgr = new Neusoft.FrameWork.Management.ControlParam();

        /// <summary>
        /// 排班管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Registration.Schema schMgr = new Neusoft.HISFC.BizLogic.Registration.Schema();
        /// <summary>
        /// 费用
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Fee feeMgr = new Neusoft.HISFC.BizProcess.Integrate.Fee();
        /// <summary>
        /// 分诊管理类
        /// </summary>
        //private Neusoft.HISFC.BizProcess.Integrate assMgr = new Neusoft.HISFC.BizLogic.Nurse.Assign();
        /// <summary>
        /// 可退号天数
        /// </summary>
        private int PermitDays = 0;
        private ArrayList al = new ArrayList();

        //{DA67A335-E85E-46e1-A672-4DB409BCC11B}

        private bool isQuitAccount = false;

       


        //{B700292D-50A6-4cdf-8B03-F556F990BB9B}
        /// <summary>
        /// 是否打印退号票
        /// </summary>
        private bool isPrintBackBill = false;

        private bool isFree = false;
      
        #endregion
        //{B700292D-50A6-4cdf-8B03-F556F990BB9B}
        #region 属性
        [Category("控件设置"), Description("是否打印退号票"), DefaultValue(false)]
        public bool IsPrintBackBill
        {
            set
            {
                this.isPrintBackBill = value;
            }
            get
            {
                return this.isPrintBackBill;
            }
        } 

        /// <summary>
        /// //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
        /// </summary>
        [Category("控件设置"), Description("帐户患者是否退帐户"), DefaultValue(false)]
        public bool IsQuitAccount
        {
            get { return isQuitAccount; }
            set { isQuitAccount = value; }
        }

        //{182DA62D-6BCE-4c4c-956F-6F2A363138A0}
        private bool isSeeedCanCancelRegInfo = false;

        //{182DA62D-6BCE-4c4c-956F-6F2A363138A0}
        [Category("控件设置"), Description("已看诊挂号记录是否能退号？"), DefaultValue(false)]
        public bool IsSeeedCanCancelRegInfo
        {
            get { return isSeeedCanCancelRegInfo; }
            set { isSeeedCanCancelRegInfo = value; }
        }
       
        #endregion
        #region 医保接口
        /// <summary>
        /// 医保接口代理服务器
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy medcareInterfaceProxy = new Neusoft.HISFC.BizProcess.Integrate.FeeInterface.MedcareInterfaceProxy();

        //其他费类型
        string otherFeeType = string.Empty;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            string Days = this.ctlMgr.QueryControlerInfo("400006");

            if (Days == null || Days == "" || Days == "-1")
            {
                this.PermitDays = 1;
            }
            else
            {
                this.PermitDays = int.Parse(Days);
            }

            //查询其他费类型
            //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
            Days = this.ctlMgr.QueryControlerInfo("400027");

            if (string.IsNullOrEmpty(Days))
            {
                Days = "2"; //默认其他费
            }

            this.otherFeeType = Days;

            if (this.otherFeeType == "1")
            {
                this.chbQuitFeeBookFee.Checked = true;
                this.chbQuitFeeBookFee.Visible = true;
            }
            else
            {
                this.chbQuitFeeBookFee.Visible = false;
                this.chbQuitFeeBookFee.Checked = true;
            }

            string rtn = this.ctlMgr.QueryControlerInfo("400100");
            if (rtn == null || rtn == "-1" || rtn == "") rtn = "0";
            this.isFree = Neusoft.FrameWork.Function.NConvert.ToBoolean(rtn);

            this.txtCardNo.Focus();

            return 0;
        }
        
        /// <summary>
        /// 添加患者挂号明细
        /// </summary>
        /// <param name="registers"></param>
        private void addRegister(ArrayList registers)
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            Neusoft.HISFC.Models.Registration.Register obj;

            for (int i = registers.Count - 1; i >= 0; i--)
            {
                obj = (Neusoft.HISFC.Models.Registration.Register)registers[i];
                this.addRegister(obj);
            }
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
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("此号段为直接收费使用，不可以退号"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// add a record to farpoint
        /// </summary>
        /// <param name="reg"></param>
        private void addRegister(Neusoft.HISFC.Models.Registration.Register reg)
        {
            this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

            int cnt = this.fpSpread1_Sheet1.RowCount - 1;

            this.fpSpread1_Sheet1.SetValue(cnt, 0, reg.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 1, reg.Sex.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 2, reg.DoctorInfo.SeeDate.ToString(), false);
            this.fpSpread1_Sheet1.SetValue(cnt, 3, reg.DoctorInfo.Templet.Dept.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 4, reg.DoctorInfo.Templet.RegLevel.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 5, reg.DoctorInfo.Templet.Doct.Name, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 6, reg.RegLvlFee.RegFee , false);
            this.fpSpread1_Sheet1.SetValue(cnt, 7, reg.RegLvlFee.OwnDigFee + reg.RegLvlFee.ChkFee + reg.RegLvlFee.OthFee, false);
            this.fpSpread1_Sheet1.SetValue(cnt, 8, reg.InvoiceNO, false);
            this.fpSpread1_Sheet1.Rows[cnt].Tag = reg;

            if (reg.IsSee)
            {
                this.fpSpread1_Sheet1.Rows[cnt].BackColor = Color.LightCyan;
            }
            if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back||
                reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                this.fpSpread1_Sheet1.Rows[cnt].BackColor = Color.MistyRose;
            }
        }
       
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private int save()
        {
            #region 验证
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                MessageBox.Show("没有可退挂号记录!", "提示");
                return -1;
            }

            int row = this.fpSpread1_Sheet1.ActiveRowIndex;

            if (MessageBox.Show("是否要作废该挂号信息?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                return -1;

            //实体
            Neusoft.HISFC.Models.Registration.Register reg = (Neusoft.HISFC.Models.Registration.Register)this.fpSpread1_Sheet1.Rows[row].Tag;

            #endregion

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(this.regMgr.con);
            //t.BeginTransaction();

            this.regMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.schMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            this.feeMgr.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
            //this.assMgr.SetTrans(t.Trans);

            int rtn;
            Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus flag = Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.Cancel;

            try
            {
                DateTime current = this.regMgr.GetDateTimeFromSysDateTime();


                //重新获取患者实体,防止并发

                reg = this.regMgr.GetByClinic(reg.ID);
                if (this.ValidCardNO(reg.PID.CardNO) < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
                }
                //出错
                if (reg == null || reg.ID == null || reg.ID == "")
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return -1;
                }

                //使用,不能作废
                //{05E82D53-9B25-44b1-902E-36F8FF4F50F3}
                //{182DA62D-6BCE-4c4c-956F-6F2A363138A0}
                //if ((reg.IsSee || reg.IsFee) && !this.isSeeedCanCancelRegInfo)
                if (reg.IsSee  && !this.isSeeedCanCancelRegInfo)
                {
                   

                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该号已经看诊,不能作废!", "提示");
                    return -1;
                }

                //是否已经退号
                if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该挂号记录已经退号，不能再次退号!", "提示");
                    return -1;
                }

                //是否已经作废
                if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该挂号记录已经作废，不能进行退号!", "提示");
                    return -1;
                }

                #region 判断是不是门诊帐户患者
                decimal vacancy = 0;
                bool isAccountPay = false;
                string accountNO = string.Empty;
                if (!isFree)
                {
                    int result = this.feeMgr.GetAccountVacancy(reg.PID.CardNO, ref vacancy, ref accountNO);
                    if (result < 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.feeMgr.Err);
                        return -1;
                    }
                    if (result > 0)
                    {
                        DialogResult digResult = MessageBox.Show("该患者存在账户，是否退费入户？", "提示", MessageBoxButtons.YesNo);
                        if (digResult == DialogResult.Yes)
                        {
                            if (!feeMgr.CheckAccountPassWord(reg))
                            {
                                return -1;
                            }
                            isAccountPay = true;
                        }
                    }
                }

                #endregion
                //{5839C7FC-8162-4586-8473-B5F26C018DDE}
                //if (reg.InputOper.ID == regMgr.Operator.ID && reg.BalanceOperStat.IsCheck == false && result == 0  )
                //{
                //    #region 作废
                //    #endregion
                //}
                //else
                //{
                    #region 退号
                    Neusoft.HISFC.Models.Registration.Register objReturn = reg.Clone();
                    objReturn.RegLvlFee.ChkFee = -reg.RegLvlFee.ChkFee;//检查费
                    objReturn.RegLvlFee.OwnDigFee = -reg.RegLvlFee.OwnDigFee;//侦察费


                    objReturn.RegLvlFee.OthFee = -reg.RegLvlFee.OthFee;//其他费
                    objReturn.RegLvlFee.RegFee = -reg.RegLvlFee.RegFee;//挂号费
                    if (isAccountPay) //退到账户中
                    {
                        objReturn.PayCost = -(reg.OwnCost + reg.PayCost);
                        objReturn.OwnCost = 0;
                    }
                    else
                    {
                        objReturn.PayCost = 0;
                        objReturn.OwnCost = -(reg.OwnCost + reg.PayCost);
                    }
                    objReturn.PubCost = -reg.PubCost;
                    objReturn.BalanceOperStat.IsCheck = false;//是否结算
                    objReturn.BalanceOperStat.ID = "";
                    objReturn.BalanceOperStat.Oper.ID = "";
                    //objReturn.BeginTime = DateTime.MinValue; 
                    objReturn.CheckOperStat.IsCheck = false;//是否核查
                    objReturn.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back;//退号
                    objReturn.InputOper.OperTime = current;//操作时间
                    objReturn.InputOper.ID = regMgr.Operator.ID;//操作人
                    objReturn.CancelOper.ID = regMgr.Operator.ID;//退号人
                    objReturn.CancelOper.OperTime = current;//退号时间
                    //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
                    //objReturn.OwnCost = -reg.OwnCost;//自费
                    //objReturn.PayCost = -reg.PayCost;
                    objReturn.PubCost = -reg.PubCost;
                    //病历本本费处理
                    //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
                    if (this.otherFeeType == "1" && !this.chbQuitFeeBookFee.Checked)
                    {
                        objReturn.OwnCost = objReturn.OwnCost - objReturn.RegLvlFee.OthFee;
                        objReturn.RegLvlFee.OthFee = 0;
                    }

                    objReturn.TranType = Neusoft.HISFC.Models.Base.TransTypes.Negative;

                    if (isAccountPay)
                    {
                        objReturn.AccountNO = accountNO;
                    }

                    if (this.regMgr.Insert(objReturn) == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.regMgr.Err, "提示");
                        return -1;
                    }
                    if(isAccountPay)
                    {
                        string deptCode = (regMgr.Operator as Neusoft.HISFC.Models.Base.Employee).Dept.ID;
                        rtn = feeMgr.AccountCancelPay(objReturn,objReturn.PayCost,objReturn.InvoiceNO,deptCode,"R");
                        if (rtn < 0)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show("退费入户失败！" + feeMgr.Err);
                            return -1;
                        }

                    }
                    flag = Neusoft.HISFC.BizLogic.Registration.EnumUpdateStatus.Return;
                    
                    #endregion
                //}

                reg.CancelOper.ID = regMgr.Operator.ID;
                reg.CancelOper.OperTime = current;

                //更新原来项目为作废
                rtn = this.regMgr.Update(flag, reg);
                if (rtn == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(this.regMgr.Err, "提示");
                    return -1;
                }
                if (rtn == 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("该挂号信息状态已经变更,请重新检索数据!", "提示");
                    return -1;
                }

                //取消分诊4.5
                //if (this.assMgr.Delete(reg.ID) == -1)
                //{
                //    t.RollBack();
                //    MessageBox.Show("删除分诊信息出错!" + this.assMgr.Err, "提示");
                //    return -1;
                //}

                #region 恢复限额
                //恢复原来排班限额
                //如果原来更新限额,那么恢复限额
                if (reg.DoctorInfo.Templet.ID != null && reg.DoctorInfo.Templet.ID != "")
                {
                    //现场号、预约号、特诊号

                    bool IsReged = false, IsTeled = false, IsSped = false;

                    if (reg.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Pre)
                    {
                        IsTeled = true; //预约号
                    }
                    else if (reg.RegType == Neusoft.HISFC.Models.Base.EnumRegType.Reg)
                    {
                        IsReged = true;//现场号
                    }
                    else
                    {
                        IsSped = true;//特诊号
                    }

                    rtn = this.schMgr.Reduce(reg.DoctorInfo.Templet.ID, IsReged, false, IsTeled, IsSped);
                    if (rtn == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(this.schMgr.Err, "提示");
                        return -1;
                    }

                    if (rtn == 0)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show("已无排班信息,无法恢复限额!", "提示");
                        return -1;
                    }
                }
                #endregion

              
                    long returnValue = 0;
                    Neusoft.HISFC.Models.Registration.Register myYBregObject = reg.Clone();
                    this.medcareInterfaceProxy.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                    this.medcareInterfaceProxy.SetPactCode(reg.Pact.ID);
                    //初始化医保dll
                    returnValue = this.medcareInterfaceProxy.Connect();
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("初始化失败")+this.medcareInterfaceProxy.ErrMsg);
                        return -1;
                    }
                    //读卡取患者信息
                    returnValue = this.medcareInterfaceProxy.GetRegInfoOutpatient(myYBregObject);
                    if (returnValue == -1)
                    {

                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("读取患者信息失败") + this.medcareInterfaceProxy.ErrMsg);
                        return -1;
                    }
                    //医保信息赋值
                    reg.SIMainInfo = myYBregObject.SIMainInfo;
                    //退号
                    reg.User01 = "-1";//退号借用
                    //错误的调用了挂号方法{719DEE22-E3E3-4d3c-8711-829391BEA73C} by GengXiaoLei
                    //returnValue = this.medcareInterfaceProxy.UploadRegInfoOutpatient(reg);
                    returnValue = this.medcareInterfaceProxy.CancelRegInfoOutpatient(reg);
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者退号失败") + this.medcareInterfaceProxy.ErrMsg);
                        return -1;
                    }
                    returnValue = this.medcareInterfaceProxy.Commit();
                    if (returnValue == -1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        this.medcareInterfaceProxy.Rollback();
                        MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("患者退号提交失败") + this.medcareInterfaceProxy.ErrMsg);
                        return -1;
                    }
                    this.medcareInterfaceProxy.Disconnect();


                    Neusoft.FrameWork.Management.PublicTrans.Commit();
            }
            catch (Exception e)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show("退号出错!" + e.Message, "提示");
                return -1;
            }

            this.fpSpread1_Sheet1.Rows.Remove(row, 1);
            //如果已经打印发票,提示收回发票
            MessageBox.Show("退号成功!", "提示");

            //{B700292D-50A6-4cdf-8B03-F556F990BB9B}
            if (this.IsPrintBackBill)
            {
                //打印推退号票
                this.Print(reg);

            }
            this.Clear();

            return 0;
        }
        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            if (this.fpSpread1_Sheet1.RowCount > 0)
                this.fpSpread1_Sheet1.Rows.Remove(0, this.fpSpread1_Sheet1.RowCount);

            this.txtCardNo.Text = "";
            this.txtInvoice.Text = "";
            this.lbTot.Text = "";
            this.lbReturn.Text = "";

            this.txtCardNo.Focus();
        }

        /// <summary>
        /// 显示应退挂号金额
        /// </summary>
        /// <param name="row"></param>
        private void SetReturnFee(int row)
        {
            if (this.fpSpread1_Sheet1.RowCount <= 0) return;

            Neusoft.HISFC.Models.Registration.Register obj = (Neusoft.HISFC.Models.Registration.Register)this.fpSpread1_Sheet1.Rows[row].Tag;
 
            if (obj == null) return;

            decimal ownCost = 0;
            //病例本处理
            //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
            if (this.otherFeeType == "1" && !this.chbQuitFeeBookFee.Checked) //不退病例本
            {
                ownCost = obj.OwnCost - obj.RegLvlFee.OthFee;//减去病历本
            }

            //{DA67A335-E85E-46e1-A672-4DB409BCC11B}
            //帐户处理
            if (!IsQuitAccount)
            {
                if (this.otherFeeType == "1" && !this.chbQuitFeeBookFee.Checked) //不退病例本
                {
                    ownCost = obj.OwnCost - obj.RegLvlFee.OthFee + obj.PayCost;//减去病历本
                }
                else
                {
                    ownCost = obj.OwnCost + obj.PayCost;
                }
            }


            this.lbTot.Text = Convert.ToString(obj.OwnCost + obj.PayCost + obj.PubCost);
            this.lbReturn.Text = ownCost.ToString();
        }

        //{B700292D-50A6-4cdf-8B03-F556F990BB9B}
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="regObj"></param>
        private void Print(Neusoft.HISFC.Models.Registration.Register regObj)
        {

            Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint regprint = null;
            regprint = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(this.GetType(), typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint)) as Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint;

            if (regprint == null)
            {
                MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("打印票据失败,请在报表维护中维护退号票"));
            }
            else
            {

                if (regObj.IsEncrypt)
                {
                    regObj.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(regObj.NormalName);
                }

                regprint.SetPrintValue(regObj);
                regprint.Print();
            }



        }

        

        #endregion

        #region 事件

        #region {C9DDA7FB-BB9B-487a-B0BB-1866742C2E53} 退号读卡操作 by guanyx
        private event System.EventHandler ReadCardEvent;
        #endregion
        /// <summary>
        /// 处理快捷键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == Keys.F12)
            //{
            //    this.save();

            //    return true;
            //}
            //else if (keyData.GetHashCode() == Keys.Alt.GetHashCode() + Keys.X.GetHashCode())
            //{
            //    this.FindForm().Close();

            //    return true;
            //}
            //else if (keyData == Keys.Escape)
            //{
            //    this.FindForm().Close();

            //    return true;
            //}
            //else if (keyData == Keys.F8)
            //{
            //    this.Clear();

            //    return true;
            //}

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// fp回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.save();
            }
        }

        private void fpSpread1_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.SetReturnFee(e.Range.Row);
        }
        
        /// <summary>
        /// 根据病历号检索患者挂号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //{4661623D-235A-4380-A7E0-476C977650CD}
                string cardNo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtCardNo.Text.Trim(), "'", "[", "]");
                if (cardNo == "")
                {
                    MessageBox.Show("病历号不能为空!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }

                cardNo = cardNo.PadLeft(10, '0');
                this.txtCardNo.Text = cardNo;

                DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                //检索患者有效号
                this.al = this.regMgr.Query(cardNo, permitDate);
                if (this.al == null)
                {
                    MessageBox.Show("检索患者挂号信息时出错!" + this.regMgr.Err, "提示");
                    return;
                }

                if (this.al.Count == 0)
                {
                    MessageBox.Show("该患者没有可退号!", "提示");
                    this.txtCardNo.Focus();
                    return;
                }
                else
                {
                    this.addRegister(al);

                    this.SetReturnFee(0);

                    this.fpSpread1.Focus();
                    this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                    try
                    {
                        this.fpSpread1_Sheet1.AddSelection(0, 0, 1, 0);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 根据处方号检索挂号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //{4661623D-235A-4380-A7E0-476C977650CD}
                string recipeNo = Neusoft.FrameWork.Public.String.TakeOffSpecialChar(this.txtInvoice.Text.Trim(), "'", "[", "]");
                //string recipeNo = this.txtInvoice.Text.Trim();
                if (recipeNo == "")
                {
                    MessageBox.Show("发票号不能为空!", "提示");
                    this.txtInvoice.Focus();
                    return;
                }
                recipeNo = recipeNo.PadLeft(12, '0');
                this.txtInvoice.Text = recipeNo;

                DateTime permitDate = this.regMgr.GetDateTimeFromSysDateTime().AddDays(-this.PermitDays).Date;
                //检索患者有效号
                //{B6E76F4C-1D79-4fa2-ABAD-4A22DE89A6F7} by 牛鑫元
                //this.al = this.regMgr.QueryByRecipe(recipeNo);
                this.al = this.regMgr.QueryByRecipe( recipeNo);
                if (this.al == null)
                {
                    MessageBox.Show("检索患者挂号信息时出错!" + this.regMgr.Err, "提示");
                    return;
                }

                ArrayList alRegCollection = new ArrayList();

                ///移除超过限定时间的挂号信息
                ///
                foreach (Neusoft.HISFC.Models.Registration.Register obj in this.al)
                {
                    if (obj.DoctorInfo.SeeDate.Date < permitDate.Date) continue;

                    alRegCollection.Add(obj);
                }

                if (alRegCollection.Count == 0)
                {
                    MessageBox.Show("无发票号为：" + recipeNo + "的挂号信息!", "提示");
                    this.txtInvoice.Focus();
                    return;
                }
                else
                {
                    this.addRegister(alRegCollection);

                    this.SetReturnFee(0);

                    this.fpSpread1.Focus();
                    this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                    this.fpSpread1_Sheet1.AddSelection(0, 0, 1, 0);
                }
            }
        }

        #endregion

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolbarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolbarService.AddToolButton("退号", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.B保存, true, false, null);
            toolbarService.AddToolButton("清屏", "", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            #region {C9DDA7FB-BB9B-487a-B0BB-1866742C2E53} 退号读卡操作 by guanyx
            ReadCardEvent += new EventHandler(ucCancel_ReadCardEvent);
            toolbarService.AddToolButton("读卡", "读院内卡", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.C查找人员, true, false, this.ReadCardEvent);
            #endregion
            return toolbarService;
        }

        #region {C9DDA7FB-BB9B-487a-B0BB-1866742C2E53} 退号读卡操作 by guanyx
        private string cardno = "";
        private bool isNewCard = false;
        ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader icreader = new ZZlocal.Clinic.HISFC.OuterConnector.ICCard.ICReader();
        /// <summary>
        /// 读卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucCancel_ReadCardEvent(object sender, EventArgs e)
        {
            if (icreader.GetConnect())
            {
                cardno = icreader.ReaderICCard();
                if (cardno == "0000000000")
                {
                    isNewCard = true;
                    MessageBox.Show("该卡未写入卡号，请手工输入患者卡号并敲【回车】获取患者信息！");
                }
                else
                {
                    this.txtCardNo.Text = cardno;
                    this.txtCardNo_KeyDown(this.txtCardNo, new KeyEventArgs(Keys.Enter));
                }
                icreader.CloseConnection();
            }
            else
            {
                MessageBox.Show("读卡失败！");
            }
        }
        #endregion

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "退号":
                    //if (txtCardNo.Text == null || txtCardNo.Text.Trim() == "")
                    //{
                    //    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("输入病历号"), Neusoft.FrameWork.Management.Language.Msg("提示"));
                    //    return;
                    //}
                    e.ClickedItem.Enabled = false;
                    if (this.save() == -1)
                    {
                        e.ClickedItem.Enabled = true;
                        return;
                    }
                    e.ClickedItem.Enabled = true;

                    break;
                case "清屏":

                    this.Clear();

                    break;
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        private void txtCardNo_TextChanged(object sender, EventArgs e)
        {

        }

        #region IInterfaceContainer 成员
        //{B700292D-50A6-4cdf-8B03-F556F990BB9B}
        public Type[] InterfaceTypes
        {

            get
            {
                Type[] type = new Type[1];
                type[0] = typeof(Neusoft.HISFC.BizProcess.Interface.Registration.IRegPrint);

                return type;
            }
        }

        #endregion
        //{7E7ED83C-8A9D-4277-827A-4D8CB478FDDA}
        protected override int OnPrint(object sender, object neuObject)
        {
            Neusoft.HISFC.Models.Registration.Register reg = (Neusoft.HISFC.Models.Registration.Register)this.fpSpread1_Sheet1.Rows[this.fpSpread1_Sheet1.ActiveRowIndex].Tag;

            reg = this.regMgr.GetByClinic(reg.ID);
            if (this.ValidCardNO(reg.PID.CardNO) < 0)
            {
                return -1;
            }
            //出错
            if (reg == null || reg.ID == null || reg.ID == "")
            {
                MessageBox.Show(this.regMgr.Err, "提示");
                return -1;
            }

            //使用,不能作废
            //{05E82D53-9B25-44b1-902E-36F8FF4F50F3}
            //{182DA62D-6BCE-4c4c-956F-6F2A363138A0}
            //if ((reg.IsSee || reg.IsFee) && !this.isSeeedCanCancelRegInfo)
            if (reg.IsSee && !this.isSeeedCanCancelRegInfo)
            {
                MessageBox.Show("该号已经看诊,不能作废!", "提示");
                return -1;
            }

            //是否已经退号
            if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Back)
            {
                MessageBox.Show("该挂号记录已经退号，不能再次退号!", "提示");
                return -1;
            }

            //是否已经作废
            if (reg.Status == Neusoft.HISFC.Models.Base.EnumRegisterStatus.Cancel)
            {
                MessageBox.Show("该挂号记录已经作废，不能进行退号!", "提示");
                return -1;
            }

            this.Print(reg);

            return 1;
        }
        //{F3258E87-7BCC-411a-865E-A9843AD2C6DD}
        private void chbQuitFeeBookFee_CheckedChanged(object sender, EventArgs e)
        {
            this.SetReturnFee(this.fpSpread1_Sheet1.ActiveRowIndex);
        }

       
    }
}

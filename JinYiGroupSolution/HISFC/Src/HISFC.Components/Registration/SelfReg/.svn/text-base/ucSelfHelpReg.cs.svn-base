using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace Neusoft.HISFC.Components.Registration.SelfReg
{
    /// <summary>
    /// [功能描述: 自助挂号]<br></br>
    /// [创 建 者: 牛鑫元]<br></br>
    /// [创建时间: 2009-9]<br></br>
    /// <说明
    ///		贵港本地化
    ///  />
    /// </summary>
    public partial class ucRegSelfHelp : Form
    {
        public ucRegSelfHelp()
        {
            InitializeComponent();
      
        }

        #region 域
        /// <summary>
        ///  综合管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 如初转业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 患者基本信息
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 挂号管理业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Registration.Register regMgr = new Neusoft.HISFC.BizLogic.Registration.Register();

        Neusoft.HISFC.BizLogic.Registration.RegLvlFee regFeeMgr = new Neusoft.HISFC.BizLogic.Registration.RegLvlFee();

        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();
        //[DllImport("user32.dll")]
        //public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

       

        #endregion

        #region 属性
        /// <summary>
        /// 是否选用弹出窗口
        /// </summary>
        [Category("控件设置"),Description("是否选用弹出窗口"),DefaultValue(false)]
        //public bool IsPobForm
        //{
        //    set
        //    {
        //        this.plRight.Visible = !value;
        //        this.btChooseDept.Visible = value;
        //    }
        //    get
        //    {
        //        return (!this.plRight.Visible && this.btChooseDept.Visible);
        //    }
        //}
        #endregion

        #region 方法
        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <returns></returns>
        private int InitInfo()
        {
            this.FindForm().FormClosing += new FormClosingEventHandler(ucRegSelfHelp_FormClosing);
            this.FindForm().Resize += new EventHandler(ucRegSelfHelp_Resize);
            this.FindForm().Activated += new EventHandler(ucRegSelfHelp_Activated);
            this.FindForm().MaximizeBox = false;
            this.FindForm().MinimizeBox = false;
            this.FindForm().ControlBox = false;
            this.lblTip.Text = "欢迎使用东软自助挂号系统，请您刷卡！";
            this.ShowDeptInfo();
            return 1;
        }

        void ucRegSelfHelp_Activated(object sender, EventArgs e)
        {
            this.FindForm().WindowState = FormWindowState.Maximized;
        }

        void ucRegSelfHelp_Resize(object sender, EventArgs e)
        {
            this.FindForm().WindowState = FormWindowState.Maximized;
        }



        void ucRegSelfHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            HISFC.Components.Common.Forms.frmValidUserPassWord frm = new Neusoft.HISFC.Components.Common.Forms.frmValidUserPassWord();

            DialogResult dia = frm.ShowDialog();

            if (dia == DialogResult.OK)
            {
            }
            else
            {
                e.Cancel = true;
            }
            return;
        }

      
        /// <summary>
        /// 根据就诊卡号查询患者基本信息
        /// </summary>
        /// <param name="cardNO"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.RADT.PatientInfo GetPatientInfo(string cardNO)
        {
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = this.radtIntegrate.QueryComPatientInfo(cardNO);
            if (patientInfo == null)
            {
                MessageBox.Show("查询患者基本信息出错");
                return null;
            }

            if (string.IsNullOrEmpty(patientInfo.PID.CardNO))
            {
                MessageBox.Show("没有找到该患者信息");
                return null;
            }

            //界面赋值
            this.ucSelfHelpPatientInfo1.PatientInfo = patientInfo;



            this.txtDept.Focus();
            this.lblTip.Text = "请您选择挂号科室！";
            return patientInfo;
        }

        /// <summary>
        /// 获取挂号信息
        /// </summary>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Registration.Register GetRegisterInfo()
        {
            Neusoft.HISFC.Models.Registration.Register register = null;

            if (this.patientInfo != null && !string.IsNullOrEmpty(this.patientInfo.PID.CardNO))
            {
                register = new Neusoft.HISFC.Models.Registration.Register();
                register.PID.CardNO = this.patientInfo.PID.CardNO;
                register.Name = this.patientInfo.Name;
                register.Sex.ID = this.patientInfo.Sex.ID;
                register.Birthday = this.patientInfo.Birthday;
                register.Pact.ID = this.patientInfo.Pact.ID;
                register.Pact.PayKind.ID = this.patientInfo.Pact.PayKind.ID;
                register.SSN = this.patientInfo.SSN;
                register.PhoneHome = this.patientInfo.PhoneHome;
                register.AddressHome = this.patientInfo.AddressHome;
                register.IDCard = this.patientInfo.IDCard;
                register.NormalName = this.patientInfo.NormalName;
                register.IsEncrypt = this.patientInfo.IsEncrypt;
                register.IDCard = this.patientInfo.IDCard;
                if (this.patientInfo.IsEncrypt == true)
                {
                    register.Name = Neusoft.FrameWork.WinForms.Classes.Function.Decrypt3DES(this.patientInfo.NormalName);
                }

                register.CardType.ID = this.patientInfo.Memo;

                //挂号流水号
                register.ID = this.regMgr.GetSequence("Registration.Register.ClinicID");
                register.TranType = Neusoft.HISFC.Models.Base.TransTypes.Positive;//正交易

                //this.regObj.DoctorInfo.Templet.RegLevel.ID = this.cmbRegLevel.Tag.ToString();
                //this.regObj.DoctorInfo.Templet.RegLevel.Name = this.cmbRegLevel.Text;

                register.DoctorInfo.Templet.Dept.ID = (this.txtDept.Tag as Neusoft.FrameWork.Models.NeuObject).ID;
                register.DoctorInfo.Templet.Dept.Name = (this.txtDept.Tag as Neusoft.FrameWork.Models.NeuObject).Name;

                register.DoctorInfo.Templet.Doct.ID = string.Empty;
                register.DoctorInfo.Templet.Doct.Name = string.Empty;
                register.RegType = Neusoft.HISFC.Models.Base.EnumRegType.Reg;
                register.Pact = this.patientInfo.Pact;

                register.DoctorInfo.SeeDate = this.regMgr.GetDateTimeFromSysDateTime();
                register.DoctorInfo.Templet.RegLevel.ID = "1";
                register.DoctorInfo.Templet.RegLevel.Name = "普通号";

                Neusoft.HISFC.Models.Base.Noon noon = this.getNoon(register.DoctorInfo.SeeDate);
                register.DoctorInfo.Templet.Noon = noon;
                register.DoctorInfo.Templet.Begin = register.DoctorInfo.SeeDate.Date;
                register.DoctorInfo.Templet.End = register.DoctorInfo.SeeDate.Date;
                int returnValue = this.GetRegFee(register);
                if (returnValue < 0)
                {
                    MessageBox.Show("获得挂号费失败");
                    return null;
                }

                //处方号
                //  this.regObj.InvoiceNO = this.txtRecipeNo.Text.Trim();
                register.RecipeNO = "1";


                register.IsFee = false;
                register.Status = Neusoft.HISFC.Models.Base.EnumRegisterStatus.Valid;
                register.IsSee = false;
                register.InputOper.ID = this.regMgr.Operator.ID;
                register.InputOper.OperTime = this.regMgr.GetDateTimeFromSysDateTime();
                //add by niuxinyuan
                register.DoctorInfo.SeeDate = register.InputOper.OperTime;
                register.CancelOper.ID = "";
                register.CancelOper.OperTime = DateTime.MinValue;
                string invoice = this.feeIntegrate.GetNewInvoiceNO("C");
                if (invoice == null)
                {
                    MessageBox.Show(this.feeIntegrate.Err);
                    return null;
                }

                register.InvoiceNO = invoice;
                //查询患者就诊记录出错
                int regCount = this.regMgr.QueryRegiterByCardNO(register.PID.CardNO);
                if (regCount == 1)
                {
                    register.IsFirst = false;
                }
                else
                {
                    if (regCount == 0)
                    {
                        register.IsFirst = true;

                    }
                    else
                    {
                        MessageBox.Show("查询患者就诊记录出错");
                        return null;
                    }
                }

                if (register.DoctorInfo.Templet.Noon.ID == "")
                {
                    MessageBox.Show("未维护午别信息,请先维护!", "提示");
                    return null;
                }
                register.DoctorInfo.Templet.ID = "";

            }

            return register;
        }

        /// <summary>
        /// 获取午别
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Base.Noon getNoon(DateTime current)
        {
            Neusoft.HISFC.BizLogic.Registration.Noon noonMgr = new Neusoft.HISFC.BizLogic.Registration.Noon();

            System.Collections.ArrayList alNoon = noonMgr.Query();
            if (alNoon == null)
            {
                MessageBox.Show("获取午别信息时出错!" + noonMgr.Err, "提示");
                return null;
            }
            if (alNoon == null) return null;
            /*
             * 理解错误：以为午别应该是包含一天全部时间上午：06~12,下午:12~18其余为晚上,
             * 实际午别为医生出诊时间段,上午可能为08~11:30，下午为14~17:30
             * 所以如果挂号员如果不在这个时间段挂号,就有可能提示午别未维护
             * 所以改为根据传人时间所在的午别例如：9：30在06~12之间，那么就判断是否有午别在
             * 06~12之间，全包含就说明9:30是那个午别代码
             */
            //			foreach(Neusoft.HISFC.Models.Registration.Noon obj in alNoon)
            //			{
            //				if(int.Parse(current.ToString("HHmmss"))>=int.Parse(obj.BeginTime.ToString("HHmmss"))&&
            //					int.Parse(current.ToString("HHmmss"))<int.Parse(obj.EndTime.ToString("HHmmss")))
            //				{
            //					return obj.ID;
            //				}
            //			}



            int[,] zones = new int[,] { { 0, 120000 }, { 120000, 180000 }, { 180000, 235959 } };
            int time = int.Parse(current.ToString("HHmmss"));
            int begin = 0, end = 0;

            for (int i = 0; i < 3; i++)
            {
                if (zones[i, 0] <= time && zones[i, 1] > time)
                {
                    begin = zones[i, 0];
                    end = zones[i, 1];
                    break;
                }
            }

            foreach (Neusoft.HISFC.Models.Base.Noon obj in alNoon)
            {
                if (int.Parse(obj.StartTime.ToString("HHmmss")) >= begin &&
                    int.Parse(obj.EndTime.ToString("HHmmss")) <= end)
                {
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regObj"></param>
        /// <returns></returns>
        private int GetRegFee(Neusoft.HISFC.Models.Registration.Register regObj)
        {
            Neusoft.HISFC.Models.Registration.RegLvlFee p = this.regFeeMgr.Get(regObj.Pact.ID, regObj.DoctorInfo.Templet.RegLevel.ID);
            if (p == null)//出错
            {
                return -1;
            }
            if (p.ID == null || p.ID == "")//没有维护挂号费
            {
                return 1;
            }

            regObj.RegLvlFee = p;

            regObj.OwnCost = p.ChkFee + p.OwnDigFee + p.RegFee + p.OthFee;
            regObj.PayCost = 0;
            regObj.PubCost = 0;

            return 0;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        private void Clear()
        {
            this.txtCardNO.Text = string.Empty;
            this.txtCardNO.Focus();
            this.ucSelfHelpPatientInfo1.Clear();
            this.txtDept.Text = string.Empty;
            this.txtDept.Tag = null;
            this.patientInfo = null;
            this.lblTip.Text = "欢迎使用东软自助挂号系统，请您刷卡！";
            
            
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

        /// <summary>
        /// 更新全院看诊序号
        /// </summary>
        /// <param name="rMgr"></param>
        /// <param name="current"></param>
        /// <param name="seeNo"></param>
        /// <param name="Err"></param>
        /// <returns></returns>
        private int Update(DateTime current, ref int seeNo,
            ref string Err)
        {
            //更新看诊序号
            //全院是全天大排序，所以午别不生效，默认 1
            if (this.regMgr.UpdateSeeNo("4", current, "ALL", "1") == -1)
            {
                Err = regMgr.Err;
                return -1;
            }

            //获取全院看诊序号
            if (this.regMgr.GetSeeNo("4", current, "ALL", "1", ref seeNo) == -1)
            {
                Err = regMgr.Err;
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// 设置farpoint
        /// </summary>
        /// <param name="alColections"></param>
        private void SetFarpointValue(ArrayList alColections)
        {


           // decimal rowCount = Math.Ceiling(Neusoft.FrameWork.Function.NConvert.ToDecimal(alColections.Count / 3)); //求余和商
            int myMod = 0;
            int rowCount = Math.DivRem(alColections.Count, 3, out myMod);

            if (myMod > 0)
            {
                rowCount = rowCount + 1;
            }

            this.neuSpread1_Sheet1.RowCount = Neusoft.FrameWork.Function.NConvert.ToInt32(rowCount);
            this.neuSpread1_Sheet1.ColumnCount = 3;

            int j = 0;
            for (int i = 0; i < alColections.Count; i++)
            {
                int k = Neusoft.FrameWork.Function.NConvert.ToInt32(Math.Ceiling(Neusoft.FrameWork.Function.NConvert.ToDecimal(i / 3))); //求余和商

                int mod = 0;

                Math.DivRem(i, 3, out mod);


                Neusoft.FrameWork.Models.NeuObject obj = alColections[i] as Neusoft.FrameWork.Models.NeuObject;

                FarPoint.Win.Spread.CellType.ButtonCellType btCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                btCell.Text = obj.Name + "\n(" + obj.ID + ")";

                 
                    this.neuSpread1_Sheet1.Cells[k, mod].CellType = btCell;

                    //btCell.Picture = Neusoft.FrameWork.WinForms.Classes.Function.GetImage(Neusoft.FrameWork.WinForms.Classes.EnumImageList.K科室);
                    btCell.Picture = global::Neusoft.HISFC.Components.Registration.Properties.Resources.科室;
                    this.neuSpread1_Sheet1.Cells[k, mod].Tag = obj;
                
            }
        }

        /// <summary>
        /// 设置挂号信息
        /// </summary>
        /// <returns></returns>
        private int ShowDeptInfo()
        {

            ArrayList alDept = this.managerIntegrate.QueryRegDepartment();
            if (alDept == null)
            {
                MessageBox.Show("查询挂号科室出错" + this.managerIntegrate.Err);
            }

            this.SetFarpointValue(alDept);
            return 1;
        }
        #endregion

        #region 事件
        private void btChooseDept_Click(object sender, EventArgs e)
        {
            frmSelfHelpSelectPop frm = new frmSelfHelpSelectPop();
            frm.ChooseItem += new EventHandler(frm_ChooseItem);
            frm.EnumPopType = EnumPopType.Dept;
            frm.Text = "选择挂号科室";
       
            DialogResult dResult = frm.ShowDialog();
            if (dResult == DialogResult.OK)
            {

            }
        }

        /// <summary>
        /// 选择挂号科室方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frm_ChooseItem(object sender, EventArgs e)
        {
            Neusoft.FrameWork.Models.NeuObject obj = sender as Neusoft.FrameWork.Models.NeuObject;
            if (obj == null)
            {
                MessageBox.Show("选择挂号科室");
                return;
            }
            this.txtDept.Text = obj.Name;
            this.txtDept.Tag = obj;
        }

        /// <summary>
        /// 回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNO = this.txtCardNO.Text.Trim();

                this.ucSelfHelpPatientInfo1.Clear();
                if (string.IsNullOrEmpty(cardNO))
                {
                    MessageBox.Show("请您输入就诊卡号！");
                    return;
                }
                
                cardNO = cardNO.PadLeft(10, '0');
                this.patientInfo = this.GetPatientInfo(cardNO);

                this.txtDept.Focus();

            }
        }

        void txtCardNO_Enter(object sender, System.EventArgs e)
        {
            this.MouseMove(this.pbReadCard); 
            this.MouseLeave(this.ptReg);
            this.MouseLeave(this.ptDept);
        }

        void txtCardNO_Leave(object sender, System.EventArgs e)
        {
            this.MouseLeave(this.pbReadCard);
        }

        void txtDept_Leave(object sender, System.EventArgs e)
        {
            this.MouseLeave(this.ptDept);
        }

        void txtDept_Enter(object sender, System.EventArgs e)
        {
            this.MouseMove(this.ptDept);
            this.MouseLeave(this.ptReg);
            this.MouseLeave(this.pbReadCard);
        }


        /// <summary>
        /// 挂号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDept.Text) || this.txtDept.Tag == null)
            {
                MessageBox.Show("请您选择挂号科室！");
                this.lblTip.Text = "请您选择挂号科室！";
                return;
            }

            Neusoft.HISFC.Models.Registration.Register register = this.GetRegisterInfo();

            if (register == null)
            {
                MessageBox.Show("请输入卡号");
                this.txtCardNO.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show("您选择的挂号科室为," + register.DoctorInfo.Templet.Dept.Name + "\n是否继续？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.No)
            {
                
                MessageBox.Show("您已经取消了本次挂号操作，谢谢使用");
                this.Clear();
                return;
            }
            if (dr == DialogResult.Cancel)
            {
                return;
            }


            if (register != null)
            {
               

                int returnValue = 0;
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                int orderNO = 0;
                string Err = string.Empty;

                returnValue = this.UpdateSeeID(register.DoctorInfo.Templet.Dept.ID, register.DoctorInfo.Templet.Doct.ID, register.DoctorInfo.Templet.Noon.ID, register.DoctorInfo.SeeDate, ref orderNO, ref Err);

                if (returnValue < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return;
                }

                register.DoctorInfo.SeeNO = orderNO;

                //更新全院序号
                if (this.Update(register.InputOper.OperTime, ref orderNO, ref Err) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Err, "提示");
                    return;
                }
                register.OrderNO = orderNO;//全院序号

                // 插入挂号主表
                returnValue = this.regMgr.Insert(register);
                if (returnValue < 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("挂号失败" + this.regMgr.Err);
                    return;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                
                MessageBox.Show("自助挂号成功！\n本次挂号金额:" + (register.OwnCost + register.PubCost + register.PayCost).ToString() + "\n谢谢使用！");
                this.Clear();
            }
            else
            {
                MessageBox.Show("没有患者信息");
                this.lblTip.Text = "欢迎使用东软自助挂号系统，请您刷卡！";

            }
        }

        /// <summary>
        /// 清屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void btReadCard_Click(object sender, EventArgs e)
        {
            
        }

        int width, height;
        protected override void OnLoad(EventArgs e)
        {
            this.InitInfo();
            //width = this.FindForm().Width;
            //height = this.FindForm().Height;
            this.FindForm().WindowState = FormWindowState.Maximized;

            //try
            //{
            //    if (this.FindForm().GetType() == typeof(Neusoft.FrameWork.WinForms.Forms.frmBaseForm))
            //    {
            //        (this.FindForm() as Neusoft.FrameWork.WinForms.Forms.frmBaseForm).toolBar1.Visible = false;
            //        (this.FindForm() as Neusoft.FrameWork.WinForms.Forms.frmBaseForm). = false;
            //    }
            //    (this.FindForm() as Neusoft.FrameWork.WinForms.Forms.frmBaseForm).toolBar1.Visible = false;
            //}
            //catch { 


            this.BackColor = Color.FromArgb(244,244,252);

            this.MouseLeave(this.btReadCard);
            this.MouseLeave(this.btClear);
            this.MouseLeave(this.btOk);
            this.MouseLeave(this.btQuit);

            base.OnLoad(e);
        }

        private void neuSpread1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
           

            Neusoft.FrameWork.Models.NeuObject obj = this.neuSpread1_Sheet1.ActiveCell.Tag as Neusoft.FrameWork.Models.NeuObject;
            if (obj == null)
            {
                MessageBox.Show("选择的科室有误！");
                return;
            }
            this.txtDept.Text = obj.Name;
            this.txtDept.Tag = obj;
            this.lblTip.Text = "请您点击[挂号]!";

            this.btOk.Focus();
            this.MouseMove(this.ptReg);
            this.MouseLeave(this.ptDept);
            this.MouseLeave(this.pbReadCard);

            //this.FindForm().WindowState = FormWindowState.Maximized;
            
        }

        #endregion

        private void btQuit_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void btClear_MouseMove(object sender, MouseEventArgs e)
        {
            //this.tbClear.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.清屏_2;
            this.MouseMove(sender);
        }

        private void btClear_MouseLeave(object sender, EventArgs e)
        {
            //this.tbClear.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.清屏_1;
            this.MouseLeave(sender);        
        }



        private void MouseMove(object sender)
        {
            Control control = (Control)sender;

            if (control.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuButton")
            {
                if (control.Name == "btClear")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.清屏_2;
                }
                if (control.Name == "btQuit")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.退出_2;
                }
                if (control.Name == "btOk")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.挂号_2;
                }
                if (control.Name == "btReadCard")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.刷卡_2;
                }
            }
            if (control.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuPictureBox")
            {
                PictureBox pt = (PictureBox)control;

                if (pt.Name == "ptDept")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.点击右侧_2;
                }
                if (pt.Name == "ptReg")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.点击挂号_2;
                }
                if (pt.Name == "pbReadCard")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.刷卡_2;
                }
                 
            }
        }

        private void MouseLeave(object sender)
        {
            Control control = (Control)sender;

            if (control.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuButton")
            {
                if (control.Name == "btClear")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.清屏_1;
                }
                if (control.Name == "btQuit")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.退出_1;
                }
                if (control.Name == "btOk")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.挂号_1;
                }
                if (control.Name == "btReadCard")
                {
                    control.BackgroundImage = global::Neusoft.HISFC.Components.Registration.Properties.Resources.刷卡_1;
                }
            }
            if (control.GetType().FullName == "Neusoft.FrameWork.WinForms.Controls.NeuPictureBox")
            {
                PictureBox pt = (PictureBox)control;

                if (pt.Name == "ptDept")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.点击右侧_1;
                }
                if (pt.Name == "ptReg")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.点击挂号_1;
                }
                if (pt.Name == "pbReadCard")
                {
                    pt.Image = global::Neusoft.HISFC.Components.Registration.Properties.Resources.刷卡_1;
                }

            }

        }
       

    }
}

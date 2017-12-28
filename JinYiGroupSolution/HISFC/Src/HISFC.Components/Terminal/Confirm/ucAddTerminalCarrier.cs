using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.WinForms.Forms;

namespace Neusoft.HISFC.Components.Terminal.Confirm
{
    /// <summary>
    /// [功能描述: 医技设备信息维护控件]<br></br>
    /// [创 建 者: 王彦]<br></br>
    /// [创建时间: 2007-08]<br></br>
    /// </summary>
    /// <修改记录
    ///		修改人=''
    ///		修改时间=''
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucAddTerminalCarrier : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucAddTerminalCarrier()
        {
            InitializeComponent();

            this.txtDesignCode.Focus();

            this.Load += new EventHandler(ucAddTerminalCarrier_Load);
        }

        #region 初始化


        private void Init()
        {            
            this.InitComboBox();
            this.SetItem();
        }

        private void InitComboBox()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager consManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            ArrayList alConstant = consManager.QueryConstantList("BOOK01");
            ArrayList tempName = new ArrayList();

            if (alConstant == null)
            {
                return;
            }

            Neusoft.FrameWork.Models.NeuObject offerInfo;
            string[] strResults = new string[alConstant.Count];
            for (int i = 0; i < alConstant.Count; i++)
            {
                Neusoft.FrameWork.Models.NeuObject obj = alConstant[i] as Neusoft.FrameWork.Models.NeuObject;
                offerInfo = new Neusoft.FrameWork.Models.NeuObject();
                offerInfo.ID = obj.ID;
                offerInfo.Name = obj.Name;

                tempName.Add(offerInfo);
            }
            this.txtDesignType.AddItems(tempName);
            //加载设备类型  {1677D94C-1D5D-4854-8F81-2F63B754A1A7}

            //HIS 5.0 移植 设备部分独立化实现 此处对于设备业务层的引用稍后处理
            //ArrayList alType = new ArrayList();
            //ArrayList alTemp = new ArrayList();
            //alType = kindManager.QueryAllKind();
            //Neusoft.FrameWork.Models.NeuObject deviceType = new Neusoft.FrameWork.Models.NeuObject();
            //for (int i = 0; i < alType.Count; i++)
            //{
            //    Neusoft.FrameWork.Models.NeuObject obj = alType[i] as Neusoft.FrameWork.Models.NeuObject;
            //    deviceType = new Neusoft.FrameWork.Models.NeuObject();
            //    deviceType.ID = obj.ID;
            //    deviceType.Name = obj.Name;
            //    alTemp.Add(deviceType);
            //}
            //this.cmbDeviceType.AddItems(alTemp);
        }

        public void ucAddTerminalCarrier_Load(object sender, EventArgs e)
        {
            sysDate = this.terminalManager.GetDateTimeFromSysDateTime();
            sysDate2 = this.terminalManager.GetDateTimeFromSysDateTime().AddDays(1);
            Init();
        }

        #endregion

        #region 域变量

        /// <summary>
        /// 全局变量TerminalCarrier
        /// </summary>
        private Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = null;

        /// <summary>
        /// 操作类型 Update/Insert/Check
        /// </summary>
        public string inputType = "";

        Neusoft.HISFC.Models.Base.Spell spell = new Neusoft.HISFC.Models.Base.Spell();


        public delegate void SaveTerminalHandler(Neusoft.HISFC.Models.Terminal.TerminalCarrier Terminal);

        #endregion

        #region 管理类
        /// <summary>
        /// 医技设备管理类 
        /// </summary>
        private Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier terminalManager = new Neusoft.HISFC.BizLogic.Terminal.TerminalCarrier();

        DateTime sysDate = new DateTime();
        DateTime sysDate2 = new DateTime();

        /// <summary>
        /// 拼音管理类
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 设备实体类
        /// </summary>
        Neusoft.HISFC.Models.Terminal.TerminalCarrier terminalCarrier = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();

        /// <summary>
        /// 设备类型  //HIS 5.0 移植 设备部分独立化实现 此处对于设备业务层的引用稍后处理
        /// </summary>
        //Neusoft.HISFC.BizLogic.Equipment.Kind kindManager = new Neusoft.HISFC.BizLogic.Equipment.Kind();
        #endregion

        #region 属性


        /// <summary>
        /// 操作类型 Update/Insert/Check
        /// </summary>
        public string InputType
        {
            get
            {
                return this.inputType;
            }
            set
            {
                this.inputType = value;
                //if (value.ToString().ToUpper() == "UPDATE")
                //{
                //    this.continueCheckBox.Enabled = false;
                //    this.chbIsStop.Enabled = true;
                //}
                //else if (value.ToUpper().ToUpper() == "INSERT")
                //{
                //    this.continueCheckBox.Enabled = true;
                //}
            }
        }

        /// <summary>
        /// 属性TerminalCarrier
        /// </summary>
        public Neusoft.HISFC.Models.Terminal.TerminalCarrier Terminal
        {
            get
            {
                this.GetItem();
                return this.terminal;
            }
            set
            {
                if (value == null)
                {
                    this.terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();
                }
                else
                {
                    this.terminal = value;
                }
                this.SetItem();
            }
        }

        #endregion

        #region 方法

        public int validate()
        {
            if (this.dtbFreeDate.Value < this.sysDate)
            {
                MessageBox.Show("预计空闲日期必须大于当前日期");

                return -1;
            }

            if (this.dtbPreStartTime.Value < this.dtbPreStopTime.Value)
            {
                MessageBox.Show("预启动日期必须大于预停用日期");

                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtDesignCode.Text, 50))
            {
                MessageBox.Show("输入的设备编码太长");

                return -1;
            }

            if (!Neusoft.FrameWork.Public.String.ValidMaxLengh(this.txtName.Text, 50))
            {
                MessageBox.Show("输入的设备名称太长");

                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 清空控件
        /// </summary>
        protected virtual void Reset()
        {
            this.txtDesignCode.Text = "";
            this.txtName.Text = "";
            this.txtDesignType.Text = "";
            this.txtMemo.Text = "";
            this.txtSpellCode.Text = "";
            this.txtWbCode.Text = "";
            this.txtUserCode.Text = "";
            this.txtModel.Text = "";
            this.chbIsFree.Checked = false;
            this.dtbFreeDate.Text = this.terminalManager.GetSysDateTime();
            this.txtDayQuota.Text = "";
            this.txtDoc.Text = "";
            this.txtSelfQuota.Text = "";
            this.txtWebQuota.Text = "";
            this.txtBuilding.Text = "";
            this.txtFloor.Text = "";
            this.txtRoom.Text = "";
            this.txtSortId.Text = "";
            this.chbIsprestoptime.Checked = false;
            this.dtbPreStopTime.Text = this.terminalManager.GetSysDateTime();
            this.dtbPreStartTime.Text = this.terminalManager.GetSysDateTime();
            this.txtAvgTime.Text = "";
            this.txtCreateOper.Text = "";
            this.neuDateTimePicker3.Text = this.terminalManager.GetSysDateTime();
            this.chbIsValid.Checked = false;

            //System.Windows.Forms.Control c = new Control();

            //if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuGroupBox))
            //{
            //    c.Text = null;
            //    c.Tag = null; 
            //}
            //if (c.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuCheckBox))
            //{
            //    ((Neusoft.FrameWork.WinForms.Controls.NeuCheckBox)c).Checked = false;
            //}
        }

        /// <summary>
        /// 根据传入的Item实体信息 设置控件显示
        /// </summary>
        private void SetItem()
        {
            this.txtDesignCode.Text = this.terminal.CarrierCode;
            this.txtName.Text = this.terminal.CarrierName;
            this.txtDesignType.Text = this.terminal.CarrierType;
            this.txtMemo.Text = this.terminal.CarrierMemo;
            this.txtSpellCode.Text = spell.SpellCode;
            this.txtWbCode.Text = spell.WBCode;
            this.txtUserCode.Text = this.terminal.UserCode;
            this.txtModel.Text = this.terminal.Model;
            if (this.terminal.IsDisengaged == "1")
                this.chbIsFree.Checked = true;
            else
                this.chbIsFree.Checked = false;
            //this.dtbFreeDate.Text = this.terminal.DisengagedTime.ToString(); ;
            this.txtDayQuota.Text = this.terminal.DayQuota.ToString();
            this.txtDoc.Text = this.terminal.DoctorQuota.ToString();
            this.txtSelfQuota.Text = this.terminal.SelfQuota.ToString();
            this.txtWebQuota.Text = this.terminal.WebQuota.ToString();
            this.txtBuilding.Text = this.terminal.Building;
            this.txtFloor.Text = this.terminal.Floor;
            this.txtRoom.Text = this.terminal.Room;
            this.txtSortId.Text = this.terminal.SortId.ToString();
            if (this.terminal.IsPrestopTime == "1")
                this.chbIsprestoptime.Checked = true;
            else
                this.chbIsprestoptime.Checked = false;
            this.dtbPreStopTime.Text = (this.terminalManager.GetDateTimeFromSysDateTime()).ToString(); //this.terminal.PreStopTime.ToString();
            this.dtbPreStartTime.Text = (this.terminalManager.GetDateTimeFromSysDateTime().AddDays(1)).ToString(); //this.terminal.PreStartTime.ToString();
            this.txtAvgTime.Text = this.terminal.AvgTurnoverTime.ToString();
            this.txtCreateOper.Text = this.terminal.CreateOper;
            this.neuDateTimePicker3.Text = (this.terminalManager.GetDateTimeFromSysDateTime()).ToString(); //this.terminal.CreateTime.ToString();
            if (this.terminal.IsValid == "1")
            {
                this.chbIsValid.Checked = true;
            }
            else
            {
                this.chbIsValid.Checked = false;
            }
            this.cmbDeviceType.Text = this.terminal.DeviceType;

            this.InitComboBox();
        }

        /// <summary>
        /// 从控件中取数据，保存在item中 
        /// </summary>
        private Neusoft.HISFC.Models.Terminal.TerminalCarrier GetItem()
        {
            if (this.terminal == null)
                terminal = new Neusoft.HISFC.Models.Terminal.TerminalCarrier();

            this.terminal.Dept.ID = ((Neusoft.HISFC.Models.Base.Employee)this.terminalManager.Operator).Dept.ID;
            this.terminal.CarrierCode = this.txtDesignCode.Text;
            this.terminal.CarrierName = this.txtName.Text;
            this.terminal.CarrierType = this.txtDesignType.Text;
            this.terminal.CarrierMemo = this.txtMemo.Text;
            this.spell.SpellCode = this.txtSpellCode.Text;
            this.spell.WBCode = this.txtWbCode.Text;
            this.terminal.UserCode = this.txtUserCode.Text;
            this.terminal.Model = this.txtModel.Text;
            if (this.chbIsFree.Checked)
                this.terminal.IsDisengaged = "1";
            else
                this.terminal.IsDisengaged = "0";
            this.terminal.DisengagedTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtbFreeDate.Text);
            this.terminal.DoctorQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDoc.Text);
            this.terminal.SelfQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSelfQuota.Text);
            this.terminal.WebQuota = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWebQuota.Text);
            this.terminal.DayQuota = this.terminal.DoctorQuota + this.terminal.SelfQuota + this.terminal.WebQuota;
            this.terminal.Building = this.txtBuilding.Text;
            this.terminal.Floor = this.txtFloor.Text;
            this.terminal.Room = this.txtRoom.Text;
            this.terminal.SortId = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSortId.Text);
            if (this.chbIsprestoptime.Checked)
                this.terminal.IsPrestopTime = "1";
            else
                this.terminal.IsPrestopTime = "0";
            this.terminal.PreStopTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtbPreStopTime.Text);
            this.terminal.PreStartTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.dtbPreStartTime.Text);
            this.terminal.AvgTurnoverTime = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtAvgTime.Text);
            this.terminal.CreateOper = this.txtCreateOper.Text;
            this.terminal.CreateTime = terminalManager.GetDateTimeFromSysDateTime();
            if (this.chbIsValid.Checked)
            {
                this.terminal.IsValid = "1";
                this.terminal.ValidOper.ID = this.terminalManager.Operator.ID;
                this.terminal.ValidOper.OperTime = this.terminalManager.GetDateTimeFromSysDateTime();

            }
            else
            {
                this.terminal.IsValid = "0";

                this.terminal.InvalidOper.ID = this.terminalManager.Operator.ID;
                this.terminal.InvalidOper.OperTime = this.terminalManager.GetDateTimeFromSysDateTime();
            }
            this.terminal.DeviceType = this.cmbDeviceType.Text;
            return terminal;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected virtual void Close()
        {
            if (this.FindForm() != null)
            {
                this.FindForm().Close();
            }
            this.Reset();

            this.dtbPreStopTime.Enabled = false;
            this.dtbPreStartTime.Enabled = false;
        }

        /// <summary>
        /// 医技设备保存
        /// </summary>
        /// <returns>无</returns>
        protected virtual int Save()
        {
            if (this.validate() == -1)
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            terminalManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Terminal.TerminalCarrier terminal = this.GetItem();

            if (inputType.ToString().ToUpper() == "INSERT")
            {
                if (terminalManager.InsertTerminalCarrier(terminal) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("输入的设备编码不能重复");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");
            }
            else if (inputType.ToString().ToUpper() == "UPDATE")
            {
                if (terminalManager.UpdateTerminalCarrier(terminal) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show("输入的设备编码不能重复");
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();
                MessageBox.Show("保存成功");
            }
            this.Close();
            return 1;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 保存按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            this.Save();
        }

        /// <summary>
        /// 停止时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Enter转到下一个Tab事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }

        }

        private void txtDoc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtDayQuota.Text = (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDoc.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSelfQuota.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWebQuota.Text)).ToString();
            }
            catch (Exception ex)
            {
                this.txtDoc.Text = "";
                MessageBox.Show("请输入数字");
                return;
            }
        }

        private void txtWebQuota_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtDayQuota.Text = (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDoc.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSelfQuota.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWebQuota.Text)).ToString();
            }
            catch (Exception e3)
            {
                this.txtWebQuota.Text = "";
                MessageBox.Show("请输入数字");
                return;
            }
        }

        private void txtSelfQuota_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtDayQuota.Text = (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtDoc.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSelfQuota.Text) + Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtWebQuota.Text)).ToString();
            }
            catch (Exception e2)
            {
                this.txtSelfQuota.Text = "";
                MessageBox.Show("请输入数字");
                return;
            }
        }

        private void chbIsprestoptime_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.dtbPreStartTime.Enabled == true)
            {
                this.dtbPreStartTime.Enabled = false;
                this.dtbPreStopTime.Enabled = false;
            }
            else
            {
                this.dtbPreStopTime.Enabled = true;
                this.dtbPreStartTime.Enabled = true;
            }

        }

        /// <summary>
        /// 自动得到拼音码，五笔码 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();
            Neusoft.HISFC.BizProcess.Integrate.Manager mySpell = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(this.txtName.Text.ToString());


            this.txtSpellCode.Text = spCode.SpellCode;
            this.txtWbCode.Text = spCode.WBCode;
        }

        private void txtSortId_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                decimal d = (Neusoft.FrameWork.Function.NConvert.ToDecimal(this.txtSortId.Text)) % 1;
            }
            catch (Exception e3)
            {
                this.txtSortId.Text = "";
                MessageBox.Show("排序号应为数字");
                return;
            }
        }

        #endregion

    }
}

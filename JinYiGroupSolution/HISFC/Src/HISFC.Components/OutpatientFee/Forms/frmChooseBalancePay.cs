using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.Fee.Outpatient;
using FarPoint.Win.Spread;

namespace Neusoft.HISFC.Components.OutpatientFee.Froms
{
    public partial class frmChooseBalancePay : Form
    {
        public frmChooseBalancePay()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 所有支付方式信息
        /// </summary>
        private ArrayList payModes = new ArrayList();
        /// <summary>
        /// 查找支付方式信息
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper helpPayMode = new Neusoft.FrameWork.Public.ObjectHelper();
        /// <summary>
        /// 要冲帐的支付方式列表
        /// </summary>
        private ArrayList quitPayModes = new ArrayList();
        /// <summary>
        /// 修改后的冲帐支付方式
        /// </summary>
        private ArrayList modfiedPayModes = new ArrayList();
        /// <summary>
        /// 冲帐支付方式选择
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbQuitPayMode = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        /// <summary>
        /// 再收费支付方式选择
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbPayMode = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();
        /// <summary>
        /// 显示内容 0 冲帐信息 1 再收费信息
        /// </summary>
        private string displayInfo;
        /// <summary>
        /// 自费金额
        /// </summary>
        private decimal ownCost;
        /// <summary>
        /// 没有四舍五入的金额
        /// </summary>
        private decimal orgOwnCost;
        /// <summary>
        /// 是否选择确定
        /// </summary>
        public bool IsSelect = false;

        /// <summary>
        /// 费用业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();

        //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        #endregion

        #region 属性
        /// <summary>
        /// 自费金额
        /// </summary>
        public decimal OwnCost
        {
            set
            {
                ownCost = value;
                orgOwnCost = value;
            }
        }
        /// <summary>
        /// 显示内容 0 冲帐信息 1 再收费信息
        /// </summary>
        public string DisplayInfo
        {
            set
            {
                displayInfo = value;
                InitDisplayInfo();
            }
            get
            {
                return displayInfo;
            }
        }
        /// <summary>
        /// 要冲帐的支付方式
        /// </summary>
        public ArrayList QuitPayModes
        {
            set
            {
                quitPayModes = value;
            }
            get
            {
                return quitPayModes;
            }
        }

        /// <summary>
        /// 修改后的冲帐支付方式
        /// </summary>
        public ArrayList ModifiedPayModes
        {
            get
            {
                return modfiedPayModes;
            }
        }
        #endregion

        #region 函数
        /// <summary>
        /// 初始化信息
        /// </summary>
        public void Init()
        {
            //屏蔽FarPoint的一些热键信息
            this.InitFp();
            //获得所有支付方式
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //payModes = Neusoft.HISFC.Models.Fee.EnumPayTypeService.List();
            payModes = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);
            string socialCard = this.feeIntegrate.GetControlValue(Neusoft.HISFC.BizProcess.Integrate.Const.SOCIAL_CARD_DISPLAY, "0");

            if (socialCard != "1")
            {
                Neusoft.FrameWork.Models.NeuObject t = null;

                foreach (Neusoft.FrameWork.Models.NeuObject transType in payModes)
                {
                    if (transType.Name == "社保卡")
                    {
                        t = transType;
                        break;
                    }
                }

                if (t != null)
                {
                    payModes.Remove(t);
                }
            }
            //设置自查询
            helpPayMode.ArrayObject = payModes;
        }
        /// <summary>
        /// 显示内容 冲帐信息 再收费信息
        /// </summary>
        public void InitDisplayInfo()
        {
            //只显示冲帐信息
            if (displayInfo == "0")
            {

                this.fpSpead1.Enabled = true;
            }
            else//只显示再收费信息
            {
                this.fpSpead1.Enabled = false;

            }
        }

        /// <summary>
        /// 初始化冲帐支付方式列表
        /// </summary>
        /// <returns>-1 失败 0 成功</returns>
        public int InitQuitPayModes()
        {
            if (quitPayModes == null)
            {
                return -1;
            }

            lbQuitPayMode.AddItems(payModes);
            Controls.Add(lbQuitPayMode);
            lbQuitPayMode.Hide();
            lbQuitPayMode.BorderStyle = BorderStyle.FixedSingle;
            lbQuitPayMode.BringToFront();
            lbQuitPayMode.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbQuitPayMode_SelectItem);

            BalancePay pTempMode = null;

            this.fpSpead1_Sheet1.RowCount = quitPayModes.Count;

            for (int i = 0; i < quitPayModes.Count; i++)
            {
                pTempMode = quitPayModes[i] as BalancePay;
                this.fpSpead1_Sheet1.Cells[i, 0].Text = helpPayMode.GetName(pTempMode.PayType.ID.ToString());
                this.fpSpead1_Sheet1.Cells[i, 2].Text = helpPayMode.GetName(pTempMode.PayType.ID.ToString());
                //现金必须现金冲帐,不允许修改成其他支付方式
                //if (pTempMode.PayType.ID.ToString() == "CA")
                //{
                //    this.fpSpead1_Sheet1.Cells[i, 2].Locked = true;
                //}
                this.fpSpead1_Sheet1.Cells[i, 1].Text = pTempMode.FT.RealCost.ToString();

                this.fpSpead1_Sheet1.Rows[i].Tag = pTempMode;

                this.fpSpead1_Sheet1.Cells[i, 0].Locked = true;
                this.fpSpead1_Sheet1.Cells[i, 1].Locked = true;

            }
            this.fpSpead1.Focus();
            //找到第一个可以修改的支付方式,获得焦点
            for (int i = 0; i < quitPayModes.Count; i++)
            {
                if (this.fpSpead1_Sheet1.Cells[i, 2].Locked == false)
                {
                    this.fpSpead1_Sheet1.SetActiveCell(i, 2, false);
                    return 1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 设置选择支付方式ListBox的位置
        /// </summary>
        private void SetLocation()
        {
            if (this.fpSpead1_Sheet1.ActiveColumnIndex == 2)
            {
                Control cell = this.fpSpead1.EditingControl;
                lbQuitPayMode.Location = new Point(this.fpSpead1.Location.X + cell.Location.X + 4,
                    this.groupBox1.Location.Y + this.fpSpead1.Location.Y + cell.Location.Y + cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbQuitPayMode.Size = new Size(cell.Width + 50 + SystemInformation.Border3DSize.Width * 2, 150);
            }

        }

        /// <summary>
        /// 处理退费的冲帐支付方式选择
        /// </summary>
        /// <returns> -1 错误 1 正确</returns>
        private int ProcessQuitPayMode()
        {
            int currRow = this.fpSpead1_Sheet1.ActiveRowIndex;
            if (currRow < 0)
            {
                return 0;
            }
            Neusoft.FrameWork.Models.NeuObject item = null;
            int iReturn = lbQuitPayMode.GetSelectedItem(out item);
            if (iReturn == -1)
            {
                return -1;
            }
            if (item == null)
            {
                return -1;
            }
            fpSpead1_Sheet1.SetValue(currRow, 2, item.Name);

            fpSpead1.StopCellEditing();

            this.lbQuitPayMode.Visible = false;

            return 1;
        }


        private bool isValid()
        {
            for (int i = 0; i < this.fpSpead1_Sheet1.RowCount; i++)
            {
                if (this.fpSpead1_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpead1_Sheet1.Rows[i].Tag is BalancePay)
                    {
                        string tmpText = this.fpSpead1_Sheet1.Cells[i, 2].Text;
                        if (tmpText == null || tmpText == "")
                        {
                            MessageBox.Show("请填写冲帐支付方式!");
                            this.fpSpead1_Sheet1.SetActiveCell(i, 2, false);
                            return false;
                        }
                        string tmpId = helpPayMode.GetID(tmpText);
                        if (tmpId == null || tmpId == "")
                        {
                            MessageBox.Show("支付方式填写不合法!请重新填写!");
                            MessageBox.Show("请填写冲帐支付方式!");
                            this.fpSpead1_Sheet1.SetActiveCell(i, 2, false);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 获得更改后的支付方式
        /// </summary>
        public void GetNewPayMode()
        {
            this.modfiedPayModes = new ArrayList();
            for (int i = 0; i < this.fpSpead1_Sheet1.RowCount; i++)
            {
                if (this.fpSpead1_Sheet1.Rows[i].Tag != null)
                {
                    if (this.fpSpead1_Sheet1.Rows[i].Tag is BalancePay)
                    {
                        BalancePay p = this.fpSpead1_Sheet1.Rows[i].Tag as BalancePay;
                        p.PayType.ID = helpPayMode.GetID(this.fpSpead1_Sheet1.Cells[i, 2].Text);
                        modfiedPayModes.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化farpoint,屏蔽一些热键
        /// </summary>
        private void InitFp()
        {
            InputMap im;
            im = this.fpSpead1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpead1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpead1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpead1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpSpead1.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F4, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (lbQuitPayMode.Visible)
                {
                    lbQuitPayMode.Visible = false;
                    this.fpSpead1.StopCellEditing();
                }
                else
                {
                    IsSelect = false;
                    this.Close();
                }

            }
            if (keyData == Keys.F4)
            {
                if (!this.isValid())
                {
                    return false;
                }
                IsSelect = true;
                this.GetNewPayMode();
                this.Close();
            }
            if (this.fpSpead1.ContainsFocus)
            {
                if (keyData == Keys.Up)
                {
                    if (lbQuitPayMode.Visible)
                    {
                        lbQuitPayMode.PriorRow();
                    }
                    else
                    {
                        int currRow = this.fpSpead1_Sheet1.ActiveRowIndex;
                        if (currRow > 0)
                        {
                            this.fpSpead1_Sheet1.ActiveRowIndex = currRow - 1;
                            this.fpSpead1_Sheet1.SetActiveCell(currRow - 1, 2);
                        }
                    }
                }
                if (keyData == Keys.Down)
                {
                    if (lbQuitPayMode.Visible)
                    {
                        lbQuitPayMode.NextRow();
                    }
                    else
                    {
                        int currRow = this.fpSpead1_Sheet1.ActiveRowIndex;

                        this.fpSpead1_Sheet1.ActiveRowIndex = currRow + 1;
                        this.fpSpead1_Sheet1.SetActiveCell(currRow + 1, 2);
                    }
                }
                if (keyData == Keys.Enter)
                {
                    int currRow = this.fpSpead1_Sheet1.ActiveRowIndex;
                    int currCol = this.fpSpead1_Sheet1.ActiveColumnIndex;
                    if (currCol == 2)
                    {
                        ProcessQuitPayMode();
                        this.fpSpead1_Sheet1.SetActiveCell(currRow, 2, false);
                    }
                }
            }
            return base.ProcessDialogKey(keyData);
        }


        private int lbQuitPayMode_SelectItem(Keys key)
        {
            ProcessQuitPayMode();
            fpSpead1.Focus();
            return 0;
        }

        private void fpSpead1_EditModeOn(object sender, System.EventArgs e)
        {
            fpSpead1.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            SetLocation();
            if (fpSpead1_Sheet1.ActiveColumnIndex != 2)
            {
                lbQuitPayMode.Visible = false;
            }

        }

        private void EditingControl_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void fpSpead1_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 2)
            {
                string text = fpSpead1_Sheet1.ActiveCell.Text;
                lbQuitPayMode.Filter(text);
                if (!lbQuitPayMode.Visible)
                {
                    lbQuitPayMode.Visible = true;
                }
            }

        }

        private void frmChoosePayMode_Load(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch { }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!this.isValid())
            {
                return;
            }
            IsSelect = true;
            this.GetNewPayMode();
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            IsSelect = false;
            this.Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (!this.isValid())
            {
                return;
            }
            IsSelect = true;
            this.GetNewPayMode();
            this.Close();
        }
	
    }
}
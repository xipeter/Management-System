using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Common.Controls
{
    public partial class ucBalancePay : UserControl
    {
        public ucBalancePay()
        {
            InitializeComponent();
        }

        #region 变量

        /// <summary>
        /// 使用范围 Inpatient 住院 Outpatient 门诊
        /// </summary>
        private Neusoft.HISFC.Models.Base.ServiceTypes serviceType = Neusoft.HISFC.Models.Base.ServiceTypes.I;

        /// <summary>
        /// 支付方式列表
        /// </summary>
        private ArrayList payModes = new ArrayList();

        /// <summary>
        /// 银行列表
        /// </summary>
        private ArrayList banks = new ArrayList();

        /// <summary>
        /// 支付方式选择列表
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbPayMode = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();

        /// <summary>
        /// 银行选择控件
        /// </summary>
        Neusoft.FrameWork.WinForms.Controls.PopUpListBox lbBank = new Neusoft.FrameWork.WinForms.Controls.PopUpListBox();

        /// <summary>
        /// 管理业务层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 所有自费金额
        /// </summary>
        private decimal totOwnCost = 0;

        /// <summary>
        /// 实际花费金额
        /// </summary>
        private decimal realCost = 0;

        /// <summary>
        /// 当前数据库连接
        /// </summary>
        protected System.Data.IDbTransaction trans = null;

        /// <summary>
        /// 是否显示按钮
        /// </summary>
        protected bool isShowButton = false;

        /// <summary>
        /// 是否正确选择了支付方式,前提是IsShowButton属性为True如果关闭窗口和点击取消按钮,该值为false
        /// </summary>
        protected bool isCurrentChoose = false;

        #endregion

        #region 属性

        /// <summary>
        /// 当前数据库连接
        /// </summary>
        public System.Data.IDbTransaction Trans 
        {
            get 
            {
                return this.trans;
            }
            set 
            {
                this.trans = value;
            }
        }
        
        /// <summary>
        /// 所有自费金额
        /// </summary>
        public decimal TotOwnCost 
        {
            get 
            {
                return this.totOwnCost;
            }
            set 
            {
                this.totOwnCost = value;
                this.fpPayMode_Sheet1.CellChanged -= new SheetViewEventHandler(fpPayMode_Sheet1_CellChanged);
                this.fpPayMode_Sheet1.SetValue(0, (int)PayModeCols.Cost, this.totOwnCost);
                this.fpPayMode_Sheet1.CellChanged += new SheetViewEventHandler(fpPayMode_Sheet1_CellChanged);
            }
        }

        /// <summary>
        /// 实际花费金额
        /// </summary>
        public decimal RealCost 
        {
            get 
            {
                return this.realCost;
            }
            set 
            {
                this.realCost = value;
            }
        }

        /// <summary>
        /// 是否正确选择了支付方式,前提是IsShowButton属性为True如果关闭窗口和点击取消按钮,该值为false
        /// </summary>
        public bool IsCurrentChoose 
        {
            get 
            {
                return this.isCurrentChoose;
            }
        }


        /// <summary>
        /// 是否显示按钮
        /// </summary>
        [Category("控件设置"), Description("是否使用确定和取消按钮")]
        public bool IsShowButton 
        {
            get 
            {
                return this.isShowButton;
            }
            set 
            {
                this.isShowButton = value;
                if (this.isShowButton)
                {
                    this.plButton.Height = 40;
                }
                else 
                {
                    this.plButton.Height = 0;
                }
            }
        }

        /// <summary>
        /// 使用范围 Inpatient 住院 Outpatient 门诊
        /// </summary>
        [Category("控件设置"), Description("使用范围 Inpatient 住院 Outpatient 门诊")]
        public Neusoft.HISFC.Models.Base.ServiceTypes ServiceType 
        {
            get 
            {
                return this.serviceType;
            }
            set 
            {
                this.serviceType = value;
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化farpoint,屏蔽一些热键
        /// </summary>
        private void InitFp()
        {
            InputMap im;
            im = this.fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Down, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Up, Keys.None), FarPoint.Win.Spread.SpreadActions.None);

            im = fpPayMode.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 初始化支付方式信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual  int InitPayMode()
        {
            //{93E6443C-1FB5-45a7-B89D-F21A92200CF6}
            //payModes = Neusoft.HISFC.Models.Fee.EnumPayTypeService.List();
            payModes = managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.PAYMODES);

            ArrayList payModesClone = (ArrayList)payModes.Clone();

            //现金支付方式实体
            Neusoft.FrameWork.Models.NeuObject objCA = null;

            foreach (Neusoft.FrameWork.Models.NeuObject obj in payModesClone) 
            {
                if (obj.ID == "CA") 
                {
                    objCA = obj;
                    break;
                }
            }
          
            payModesClone.Remove(objCA);

            lbPayMode.AddItems(payModesClone);
            Controls.Add(lbPayMode);
            lbPayMode.Hide();
            lbPayMode.BorderStyle = BorderStyle.FixedSingle;
            lbPayMode.BringToFront();
            lbPayMode.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbPayMode_SelectItem);

            this.fpPayMode_Sheet1.Rows.Count = payModes.Count;

            this.fpPayMode_Sheet1.Rows.Add(0, 1);
            this.fpPayMode_Sheet1.SetValue(0, (int)PayModeCols.PayMode, objCA.Name);
            this.fpPayMode_Sheet1.Rows[0].Tag = objCA.ID;
            this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.PayMode].Locked = true;
            
            for (int i = 0; i < payModesClone.Count; i++) 
            {
                this.fpPayMode_Sheet1.SetValue(i + 1, (int)PayModeCols.PayMode, ((Neusoft.FrameWork.Models.NeuObject)payModesClone[i]).Name);
                this.fpPayMode_Sheet1.Rows[i + 1].Tag = ((Neusoft.FrameWork.Models.NeuObject)payModesClone[i]).ID;
                this.fpPayMode_Sheet1.Cells[i + 1, (int)PayModeCols.PayMode].Locked = true;
            }

            return 1;
        }

        /// <summary>
        /// 初始化银行信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int InitBanks()
        {
            if (trans != null)
            {
                this.managerIntegrate.SetTrans(this.trans);
            }
            banks = this.managerIntegrate.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.BANK);
            if (banks == null || banks.Count <= 0)
            {
                MessageBox.Show(Language.Msg("获取银行列表失败!") + this.managerIntegrate.Err);

                return -1;
            }

            this.lbBank.AddItems(banks);
            Controls.Add(this.lbBank);
            lbBank.Hide();
            lbBank.BorderStyle = BorderStyle.FixedSingle;
            lbBank.BringToFront();
            lbBank.SelectItem += new Neusoft.FrameWork.WinForms.Controls.PopUpListBox.MyDelegate(lbBank_SelectItem);
            
            return 1;
        }

        int lbBank_SelectItem(Keys key)
        {
            this.ProcessPayBank();
            this.fpPayMode.Focus();
            this.fpPayMode_Sheet1.SetActiveCell(fpPayMode_Sheet1.ActiveRowIndex, (int)PayModeCols.Account, true);

            return 1;
        }

        /// <summary>
        /// 设置弹出列表位置
        /// </summary>
        private void SetLocation()
        {
            if (this.fpPayMode_Sheet1.ActiveColumnIndex == (int)PayModeCols.PayMode)
            {
                Control cell = this.fpPayMode.EditingControl;
                lbPayMode.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4, this.fpPayMode.Location.Y + cell.Location.Y + cell.Height + SystemInformation.Border3DSize.Height * 2);   
                lbPayMode.Size = new Size(cell.Width + 50 + SystemInformation.Border3DSize.Width * 2, 150);
                
            }
            if (this.fpPayMode_Sheet1.ActiveColumnIndex == (int)PayModeCols.Bank)
            {
                Control cell = this.fpPayMode.EditingControl;
                lbBank.Location = new Point(this.fpPayMode.Location.X + cell.Location.X + 4,
                     + this.fpPayMode.Location.Y + cell.Location.Y + cell.Height + SystemInformation.Border3DSize.Height * 2);
                lbBank.Size = new Size(cell.Width + 200 + SystemInformation.Border3DSize.Width * 2, 150);
            }
        }

        /// <summary>
        /// 支付方式的回车
        /// </summary>
        /// <returns></returns>
        private int ProcessPayMode()
        {
            int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
            if (currRow < 0)
            {
                return 0;
            }
            Neusoft.FrameWork.Models.NeuObject item = null;
            int returnValue = lbPayMode.GetSelectedItem(out item);
            if (returnValue == -1)
            {
                return -1;
            }
            if (item == null)
            {
                return -1;
            }

            this.fpPayMode_Sheet1.SetValue(currRow, (int)PayModeCols.PayMode, item.Name);
            this.fpPayMode_Sheet1.Rows[currRow].Tag = item.ID;

            this.fpPayMode.StopCellEditing();

            decimal nowCost = 0;
            decimal currCost = 0;
            bool isOnlyCash = true;
            
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    
                    nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                }
            }

            currCost = NConvert.ToDecimal(this.totOwnCost) - nowCost;
            this.fpPayMode_Sheet1.SetValue(0, (int)PayModeCols.Cost, currCost);

            nowCost = 0;
            
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (this.fpPayMode_Sheet1.Rows[i].Tag.ToString() != "CA")
                    {
                        isOnlyCash = false;
                    }
                    if (i == currRow)
                    {
                        continue;
                    }

                    nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                }
            }
            if (isOnlyCash)
            {
                currCost = this.totOwnCost - nowCost;
            }
            else
            {
                currCost = this.realCost - nowCost;
            }

            this.fpPayMode_Sheet1.SetValue(currRow, (int)PayModeCols.Cost, currCost);

            this.lbPayMode.Visible = false;
            
            return 1;
        }

        /// <summary>
        /// 处理银行信息
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        private int ProcessPayBank()
        {
            if (lbBank.Visible == false)
            {
                return -1;
            }
            int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
            if (currRow < 0)
            {
                return 0;
            }
            Neusoft.FrameWork.Models.NeuObject item = null;
            int returnValue = lbBank.GetSelectedItem(out item);
            if (returnValue == -1)
            {
                return -1;
            }
            if (item == null)
            {
                return -1;
            }

            this.fpPayMode.StopCellEditing();
            this.fpPayMode_Sheet1.SetValue(currRow, (int)PayModeCols.Bank, item.Name);
            this.fpPayMode_Sheet1.Cells[currRow, (int)PayModeCols.Bank].Tag = item.ID;
      
            this.lbBank.Visible = false;
            
            return 1;
        }

        /// <summary>
        /// 计算金额是否合法
        /// </summary>
        /// <returns>True合法 False不合法</returns>
        private bool IsComputCostValid()
        {
            decimal tmpCost = 0;
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                tmpCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                if (tmpCost > NConvert.ToDecimal(this.totOwnCost))
                {
                    MessageBox.Show(Language.Msg("单项金额不能大于可拆分自费金额!"));
                    this.fpPayMode.Focus();
                    this.fpPayMode_Sheet1.SetActiveCell(i, (int)PayModeCols.Cost, false);
                    
                    return false;
                }
            }

            return true;
        }

        int lbPayMode_SelectItem(Keys key)
        {
            this.ProcessPayMode();
            this.fpPayMode.Focus();
            this.fpPayMode_Sheet1.SetActiveCell(fpPayMode_Sheet1.ActiveRowIndex, (int)PayModeCols.Cost, true);
            
            return 1;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        public virtual int Init()
        {
            //初始化Farpoint
            this.InitFp();

            //初始化支付方式
            if (this.InitPayMode() == -1)
            {
                return -1;
            }

            //初始化银行信息
            if (this.InitBanks() == -1)
            {
                return -1;
            }

            return 1;
        }
        
        /// <summary>
        /// 设置当前数据库连接
        /// </summary>
        /// <param name="trans">当前数据库连接</param>
        public void SetTrans(System.Data.IDbTransaction trans) 
        {
            this.trans = trans;
        }

        /// <summary>
        /// 获得支付方式列表
        /// </summary>
        /// <returns>成功 支付方式列表 失败 null</returns>
        public ArrayList QueryBalancePayList() 
        {
            ArrayList balancePayList = new ArrayList();
            Neusoft.HISFC.Models.Fee.BalancePayBase balancePay = null;

            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text == string.Empty)
                {
                    continue;
                }
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Text == string.Empty)
                {
                    continue;
                }
                if (NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) == 0)
                {
                    continue;
                }

                if (this.serviceType == Neusoft.HISFC.Models.Base.ServiceTypes.I)
                {
                    balancePay = new Neusoft.HISFC.Models.Fee.Inpatient.BalancePay();
                }
                else if (this.serviceType == Neusoft.HISFC.Models.Base.ServiceTypes.C) 
                {
                    balancePay = new Neusoft.HISFC.Models.Fee.Outpatient.BalancePay();
                }

                balancePay.PayType.Name = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text;
                balancePay.PayType.ID = this.fpPayMode_Sheet1.Rows[i].Tag.ToString();

                if (balancePay.PayType.ID == null || balancePay.PayType.ID.ToString() == string.Empty)
                {
                    return null;
                }
                
                balancePay.FT.TotCost = NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value.ToString());
                balancePay.FT.RealCost = balancePay.FT.TotCost;
                balancePay.Bank.Name = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Bank].Text;
                if (balancePay.Bank.Name != null && balancePay.Bank.Name != string.Empty)
                {
                    balancePay.Bank.ID = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Bank].Tag.ToString();
                }
                balancePay.Bank.Account = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Account].Text;

                if (balancePay.PayType.Name == "支票" || balancePay.PayType.Name == "汇票")
                {
                    balancePay.Bank.InvoiceNO = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PosNo].Text;
                }
                else
                {
                    balancePay.POSNO = this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PosNo].Text;
                }

                balancePay.TransType = Neusoft.HISFC.Models.Base.TransTypes.Positive;
                balancePay.RetrunOrSupplyFlag = "1";
                
                balancePayList.Add(balancePay);
            }

            return balancePayList;
        }

        #endregion

        #region 事件

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (lbPayMode.Visible)
                {
                    lbPayMode.Visible = false;
                    this.fpPayMode.StopCellEditing();
                }
                else if (lbBank.Visible)
                {
                    lbBank.Visible = false;
                    this.fpPayMode.StopCellEditing();
                }
            }

            if (this.fpPayMode.ContainsFocus)
            {
                if (keyData == Keys.Up)
                {
                    if (lbPayMode.Visible)
                    {
                        lbPayMode.PriorRow();
                    }
                    else if (lbBank.Visible)
                    {
                        lbBank.PriorRow();
                    }
                    else
                    {
                        int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                        if (currRow > 0)
                        {
                            this.fpPayMode_Sheet1.ActiveRowIndex = currRow - 1;
                            if (this.fpPayMode_Sheet1.Cells[currRow - 1, (int)PayModeCols.PayMode].Locked == true)
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow - 1, (int)PayModeCols.Cost);
                            }
                            else
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow - 1, (int)PayModeCols.PayMode);
                            }
                        }
                    }
                }
               
                if (keyData == Keys.Down)
                {
                    if (lbPayMode.Visible)
                    {
                        lbPayMode.NextRow();
                    }
                    else if (lbBank.Visible)
                    {
                        lbBank.NextRow();
                    }
                    else
                    {
                        int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                        this.fpPayMode_Sheet1.ActiveRowIndex = currRow + 1;
                        if (this.fpPayMode_Sheet1.Cells[currRow + 1, (int)PayModeCols.PayMode].Locked == true)
                        {
                            this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.Cost);
                        }
                        else
                        {
                            this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.PayMode);
                        }
                    }

                }
                if (keyData == Keys.Enter)
                {
                    int currRow = this.fpPayMode_Sheet1.ActiveRowIndex;
                    int currCol = this.fpPayMode_Sheet1.ActiveColumnIndex;
                    this.fpPayMode.StopCellEditing();
                    if (currCol == (int)PayModeCols.PayMode)
                    {
                        ProcessPayMode();
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Cost, false);

                    }
                    if (currCol == (int)PayModeCols.Cost)
                    {
                        decimal cost = NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[currRow, (int)PayModeCols.Cost].Value);
                        if (cost < 0)
                        {
                            MessageBox.Show("金额不能小于零");
                            this.fpPayMode.Focus();
                            this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Cost, false);
                            return false;
                        }
                        else
                        {
                            decimal tempOwnCost = NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Value);

                            if (!IsComputCostValid())
                            {
                                return false;
                            }
                            if (currRow == 0)//现金
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.PayMode, false);
                            }
                            else
                            {
                                this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Bank, false);
                            }
                        }
                    }
                    if (currCol == (int)PayModeCols.Bank)
                    {
                        this.ProcessPayBank();
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Account, false);
                    }
                    if (currCol == (int)PayModeCols.Account)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.Company, false);
                    }
                    if (currCol == (int)PayModeCols.Company)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow, (int)PayModeCols.PosNo, false);
                    }
                    if (currCol == (int)PayModeCols.PosNo)
                    {
                        this.fpPayMode_Sheet1.SetActiveCell(currRow + 1, (int)PayModeCols.PayMode, false);
                    }
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        private void fpPayMode_EditModeOn(object sender, EventArgs e)
        {
            this.SetLocation();
            if (fpPayMode_Sheet1.ActiveColumnIndex != (int)PayModeCols.PayMode)
            {
                lbPayMode.Visible = false;
            }
            if (fpPayMode_Sheet1.ActiveColumnIndex != (int)PayModeCols.Bank)
            {
                lbBank.Visible = false;
            }
        }

        private void fpPayMode_EditChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == (int)PayModeCols.PayMode)
            {
                string text = fpPayMode_Sheet1.ActiveCell.Text;
                lbPayMode.Filter(text);
                if (!lbPayMode.Visible)
                {
                    lbPayMode.Visible = true;
                }
            }
            if (e.Column == (int)PayModeCols.Bank)
            {
                string text = fpPayMode_Sheet1.ActiveCell.Text;
                lbBank.Filter(text);
                if (!lbBank.Visible)
                {
                    lbBank.Visible = true;
                }
            }
        }

        private void fpPayMode_Sheet1_CellChanged(object sender, SheetViewEventArgs e)
        {
            string tempString = this.fpPayMode_Sheet1.Cells[e.Row, (int)PayModeCols.PayMode].Text;
            if (tempString == string.Empty)
            {
                for (int i = 0; i < this.fpPayMode_Sheet1.Columns.Count; i++)
                {
                    this.fpPayMode_Sheet1.Cells[e.Row, i].Text = string.Empty;
                }
            }
            bool isOnlyCash = true;
            decimal nowCost = 0;
            for (int i = 0; i < this.fpPayMode_Sheet1.RowCount; i++)
            {
                if (this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.PayMode].Text != string.Empty)
                {
                    if (this.fpPayMode_Sheet1.Rows[i].Tag != null && this.fpPayMode_Sheet1.Rows[i].Tag.ToString() != "CA"
                        && NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value) > 0)
                    {
                        isOnlyCash = false;
                        nowCost += NConvert.ToDecimal(this.fpPayMode_Sheet1.Cells[i, (int)PayModeCols.Cost].Value);
                    }
                }
            }

            if (this.realCost == 0)
            {
                this.realCost = this.totOwnCost;
            }

            if (isOnlyCash)
            {
                this.totOwnCost = Neusoft.FrameWork.Public.String.FormatNumber(totOwnCost, 2);
                this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Text = totOwnCost.ToString();
            }
            else
            {
                if (realCost - nowCost < 0)
                {
                    this.fpPayMode_Sheet1.Cells[e.Row, (int)PayModeCols.Cost].Value = 0;
                    this.fpPayMode_Sheet1.SetActiveCell(e.Row, (int)PayModeCols.Cost, false);
                    nowCost = 0;
                }
                this.totOwnCost = Neusoft.FrameWork.Public.String.FormatNumber(realCost, 2);
                this.fpPayMode_Sheet1.Cells[0, (int)PayModeCols.Cost].Value = realCost - nowCost;
            }
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 使用范围
        /// </summary>
        public enum UsingAreas
        {
            /// <summary>
            /// 住院
            /// </summary>
            Inpatient = 0,

            /// <summary>
            /// 门诊
            /// </summary>
            Outpatient
        }

        /// <summary>
        /// 支付方式列枚举
        /// </summary>
        private enum PayModeCols
        {
            /// <summary>
            /// 支付方式
            /// </summary>
            PayMode = 0,
            /// <summary>
            /// 金额
            /// </summary>
            Cost = 1,
            /// <summary>
            /// 开户银行
            /// </summary>
            Bank = 2,
            /// <summary>
            /// 帐号
            /// </summary>
            Account = 3,
            /// <summary>
            /// 开据单位
            /// </summary>
            Company = 4,
            /// <summary>
            /// 支票，汇票，交易号
            /// </summary>
            PosNo = 5
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.isCurrentChoose = true;

            if (this.Parent is Form) 
            {
                this.ParentForm.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.isCurrentChoose = false;

            if (this.Parent is Form)
            {
                this.ParentForm.Close();
            }
        }

        
    }
}

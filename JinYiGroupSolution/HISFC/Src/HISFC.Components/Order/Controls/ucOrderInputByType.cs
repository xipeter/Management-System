using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// 项目选择变化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="changedField"></param>
    public delegate void ItemSelectedDelegate(Neusoft.HISFC.Models.Order.Inpatient.Order sender,EnumOrderFieldList changedField);
    /// <summary>
    /// 医嘱输入控件
    /// </summary>
    public partial class ucOrderInputByType : UserControl
    {
        public ucOrderInputByType()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 项目变化选择及变化事件
        /// </summary>
        public event ItemSelectedDelegate ItemSelected;
        /// <summary>
        /// 离开事件
        /// </summary>
        public new event System.EventHandler Leave;
        protected Neusoft.HISFC.Models.Order.Inpatient.Order myorder = null;
        protected bool dirty;
        protected bool isUndrugShowFrequency = true;
        public bool IsNew = true;

        #endregion

        #region 属性
        
        /// <summary>
        /// 当前Order
        /// </summary>
        public Neusoft.HISFC.Models.Order.Inpatient.Order Order
        {
            get
            {
                this.GetOrder();
                return this.myorder;
            }
            set
            {
                if (value == null) return;
                this.myorder = value;
                this.SetOrder();
            }
        }

  
        /// <summary>
        /// 是否非药品显示频次
        /// </summary>
        public bool IsUndrugShowFrequency
        {
            get { return isUndrugShowFrequency; }
            set { isUndrugShowFrequency = value; }
        }
      
        #endregion

        #region 函数
        protected void SetPanelVisible(int i)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            switch (i)
            {
                case 1:
                    this.panel1.Visible = true;
                    break;
                case 2:
                    this.panel2.Visible = true;
                    break;
                case 3:
                    this.panel3.Visible = true;
                    break;
            }
            this.panelFrequency.BringToFront();
            this.panelFrequency.Visible = true;
        }
        protected int GetVisiblePanel()
        {
            if (this.panel1.Visible) return 1;
            if (this.panel2.Visible) return 2;
            if (this.panel3.Visible) return 3;
            return 0;
        }
        private ComboBox MemoComboBox
        {
            get
            {
                switch (this.GetVisiblePanel())
                {
                    case 1:
                        return this.cmbMemo1;
                    case 2:
                        return this.cmbMemo2;
                    case 3:
                        return this.cmbMemo3;
                    default:
                        return null;
                }

            }

        }
        private Neusoft.FrameWork.WinForms.Controls.NeuComboBox UsageComboBox
        {
            get
            {
                switch (this.GetVisiblePanel())
                {
                    case 1:
                        return this.cmbUsage1;
                    case 2:
                        return this.cmbUsage2;
                    default:
                        return null;
                }
            }
        }
        /// <summary>
        /// 设置医嘱
        /// </summary>
        protected void SetOrder()
        {
            dirty = true;
            try
            {
                //药品
                //if (this.myorder.Item.IsPharmacy)
                if (this.myorder.Item.ItemType == Neusoft.HISFC.Models.Base.EnumItemType.Drug)
                {
                    //草药
                    if (this.myorder.Item.SysClass.ID.ToString() == "PCC")
                    {
                        if (this.GetVisiblePanel() != 2)
                            this.SetPanelVisible(2);
                        this.txtFu.Text = this.myorder.HerbalQty.ToString();
                        this.cmbMemo2.Text = this.myorder.Memo;
                    }
                    else//西药，中成药
                    {
                        if (this.GetVisiblePanel() != 1)
                            this.SetPanelVisible(1);
                        if (this.IsNew)
                        {
                            this.txtMultiple.Text = "1";//{AF432978-7709-4763-A4B6-9245873B4C64}
                            if ((this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).OnceDose == 0M)//一次剂量为零，默认显示基本剂量
                                this.txtDoseOnce.Text = (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose.ToString();
                            else
                                this.txtDoseOnce.Text = (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).OnceDose.ToString();

                            this.txtMinUnit.Text = (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).DoseUnit;
                            this.myorder.DoseOnce = decimal.Parse(this.txtDoseOnce.Text);

                        }
                        else
                        {

                            this.txtDoseOnce.Text = this.myorder.DoseOnce.ToString();
                            this.txtMinUnit.Text = (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).DoseUnit;
                            //{8E097F0F-C55F-41f2-8297-7AD98223FD99}
                            this.txtMin.Text = (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).MinUnit;
                        }
                        //可不可以编辑每次用量单位
                        if (this.myorder.Item.ID == "999")
                            this.txtMinUnit.Enabled = true ;
                        else
                            this.txtMinUnit.Enabled = false;
                        this.cmbMemo1.Text = this.myorder.Memo;
                        this.chkDrugEmerce.Checked = this.myorder.IsEmergency;
                    }
                }
                else//非药品-描述医嘱
                {
                    if (this.GetVisiblePanel() != 3)
                        this.SetPanelVisible(3);

                    if (myorder.OrderType.IsDecompose)
                        this.panelFrequency.Visible = this.isUndrugShowFrequency;//长期医嘱,非药品医嘱显不显示频次
                    else
                        this.panelFrequency.Visible = false;//临时医嘱，就是不用显示非药品频次

                    //执行科室
                    this.cmbExeDept.Tag = this.myorder.ExeDept.ID;
                    this.cmbMemo3.Text = this.myorder.Memo;
                    this.chkEmerce.Checked = this.myorder.IsEmergency;

                    #region {9BACAFFC-1A64-4132-ACFF-299E1A709BBF}
                    if (this.myorder.Item.SysClass.ID.ToString() == "UL")
                    {
                        this.txtSample.ClearItems();
                        this.txtSample.AddItems(HISFC.Components.Order.Classes.Function.HelperSample.ArrayObject);
                        this.neuLabel9.Text = "样本：";
                        this.txtSample.Text = this.myorder.Sample.Name;
                    }
                    else
                    {
                        this.txtSample.ClearItems();
                        this.txtSample.AddItems(HISFC.Components.Order.Classes.Function.HelperCheckPart.ArrayObject);
                        this.neuLabel9.Text = "部位：";
                        if (string.IsNullOrEmpty(this.myorder.CheckPartRecord))
                        {
                            this.txtSample.Text = this.myorder.Sample.Name;
                        }
                        else
                        {
                            this.txtSample.Text = this.myorder.CheckPartRecord;
                        }
                    }
                    //this.txtSample.Text = this.myorder.Sample.Name;
                    #endregion
                    
                }

            }
            catch { };

            if (this.myorder.Frequency!=null &&this.myorder.Frequency.ID != "")
            {
               
                this.cmbFrequency.Tag = this.myorder.Frequency.ID;
               
                if(myorder.Frequency.Name.Length>10)
                    this.txtFrequency.Text = this.myorder.Frequency.Name.Substring(0,10);
                else
                    this.txtFrequency.Text = this.myorder.Frequency.Name;
                this.toolTip1.SetToolTip(this.txtFrequency, this.myorder.Frequency.Name);
                if (this.myorder.Frequency.Time == "25:00")
                    this.myorder.Frequency.Time = ((Neusoft.HISFC.Models.Order.Frequency)this.cmbFrequency.SelectedItem).Time;

                this.lnkTime.Text = this.myorder.Frequency.Time;
            }
            this.cmbUsage1.Tag = this.myorder.Usage.ID;
            this.cmbUsage2.Tag = this.myorder.Usage.ID;

            dirty = false;
        }
        /// <summary>
        /// 获得项目信息
        /// </summary>
        protected virtual void GetOrder()
        {
            if (this.dirty) return;
          
            if (this.myorder == null) return;
            if (UsageComboBox==null || this.UsageComboBox.SelectedItem == null)
            {
                this.myorder.Usage.ID = "";
                this.myorder.Usage.Name = "";
            }
            else
            {
                this.myorder.Usage.ID = this.UsageComboBox.SelectedItem.ID;
                this.myorder.Usage.Name = this.UsageComboBox.SelectedItem.Name;
            }
            if (this.cmbFrequency.SelectedItem == null)
            {
                this.myorder.Frequency.ID = "";
                this.myorder.Frequency.Name = "";
                this.myorder.Frequency.Time = "";
            }
            else
            {
                this.myorder.Frequency.ID = this.cmbFrequency.SelectedItem.ID;
                this.myorder.Frequency.Name = this.cmbFrequency.SelectedItem.Name;
                this.myorder.Frequency.Time = this.lnkTime.Text;
            }

            switch (this.GetVisiblePanel())
            {
                case 1://西
                    try
                    {
                        this.myorder.DoseOnce = decimal.Parse(this.txtDoseOnce.Text);
                    }
                    catch
                    {
                        MessageBox.Show("每次用量输入不正确!", "提示");
                        return;
                    }
                    ((Neusoft.HISFC.Models.Pharmacy.Item)this.myorder.Item).DoseUnit = (this.txtMinUnit.Text);
                    this.myorder.Memo = this.cmbMemo1.Text;
                    this.myorder.IsEmergency = this.chkDrugEmerce.Checked;
                    break;
                case 2://草
                    this.myorder.HerbalQty = decimal.Parse(this.txtFu.Text);
                    this.myorder.Memo = this.cmbMemo2.Text;
                    break;
                case 3://非
                    if (this.cmbExeDept.Tag != null)
                    {
                        this.myorder.ExeDept.ID = this.cmbExeDept.Tag.ToString();
                        this.myorder.ExeDept.Name = this.cmbExeDept.Text;
                    }
                    this.myorder.Memo = this.cmbMemo3.Text;
                    this.myorder.IsEmergency = this.chkEmerce.Checked;
                    this.myorder.Sample.Name = this.txtSample.Text;
                    if (this.txtSample.Tag != null) this.myorder.Sample.ID = this.txtSample.Tag.ToString();
                    break;
                default:
                    break;
            }
           

        }
        protected override void OnLoad(EventArgs e)
        {
             if (Neusoft.FrameWork.Management.Connection.Operator.ID == "") return;
            if (DesignMode == false)
            {
                ArrayList al1 = new ArrayList();
                Neusoft.HISFC.BizProcess.Integrate.Manager manager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                try
                {
                    al1 = manager.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.ORDERMEMO);
                }
                catch
                {
                    return;
                }
                this.cmbMemo1.AddItems(al1);
                this.cmbMemo2.AddItems(al1);
                this.cmbMemo3.AddItems(al1);
            }
        }
        /// <summary>
        /// 文本框跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
               
                    this.GetOrder();
                    if (((Control)sender).Name.Length > 7 && ((Control)sender).Name.Substring(0, 7) == "cmbMemo")
                    {
                        if (this.Leave != null) this.Leave(sender, null);
                    }
                    else if (((Control)sender).Name == "cmbExeDept" && this.isUndrugShowFrequency == false)
                    {
                        if (this.Leave != null) this.Leave(sender,null);
                    }
                    else if (sender == this.cmbExeDept 
                        
                        || sender == this.txtMinUnit
                        || sender == this.txtFu)
                    {
                        if (!myorder.OrderType.IsDecompose)//{31EB54C5-C30E-4130-89F2-BBF57D6BAFF6}
                        {
                            this.txtSample.Focus();                            
                        }
                        else
                        {
                            this.cmbFrequency.Focus();
                        }
                    }
                    else if (sender == this.txtSample)//{31EB54C5-C30E-4130-89F2-BBF57D6BAFF6}
                    {
                        if (this.Leave != null) this.Leave(sender, null);
                    }
                    else if (sender == this.cmbFrequency)
                    {
                        switch (this.GetVisiblePanel())
                        {
                            case 1:
                                this.cmbUsage1.Focus();
                                break;
                            case 2:
                                this.cmbUsage2.Focus();
                                break;
                            default:
                                if (this.Leave != null) this.Leave(sender, null);
                                break;
                        }
                    }
                    else if (sender == this.txtDoseOnce && this.txtMinUnit.Enabled == true)
                    {//{76DF3C65-8215-4327-ACE2-10B307ACBA59}
                        this.txtMinUnit.Focus();
                        //this.ComputeDoseOnceMultiple();
                    }
                    else if (sender == this.txtDoseOnce && this.txtMinUnit.Enabled == false)
                    {//{76DF3C65-8215-4327-ACE2-10B307ACBA59}
                        this.cmbFrequency.Focus();
                        //this.ComputeDoseOnceMultiple();
                    }
                    else if (sender == this.txtMultiple)
                    {//{76DF3C65-8215-4327-ACE2-10B307ACBA59}
                        this.txtDoseOnce.Focus();
                        this.ComputeDoseOnce();
                    }
                    else
                    {
                        System.Windows.Forms.SendKeys.Send("{tab}");
                    }
                    e.Handled = true;
               
            }
        }

        /// <summary>
        /// 计算每次用量
        /// {76DF3C65-8215-4327-ACE2-10B307ACBA59}
        /// </summary>
        private void ComputeDoseOnce()
        {
            //{8E097F0F-C55F-41f2-8297-7AD98223FD99}
            //decimal doseOnce = decimal.Parse(this.txtMultiple.Text) * (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose; 
            //this.txtDoseOnce.Text = doseOnce.ToString();
            
            string strInput = this.txtMultiple.Text.Trim();
            if (strInput.Contains("/"))
            {
                string numerator = strInput.Substring(0, strInput.IndexOf("/"));
                string denominator = strInput.Substring(strInput.IndexOf("/") + 1);
                if (!Neusoft.FrameWork.Public.String.IsNumeric(numerator))
                {
                    MessageBox.Show("输入的数字不合法！");
                    return;
                }
                if (!Neusoft.FrameWork.Public.String.IsNumeric(denominator))
                {
                    MessageBox.Show("输入的数字不合法！");
                    return;
                }
                decimal doseOnce = Neusoft.FrameWork.Function.NConvert.ToDecimal(numerator) * (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose / Neusoft.FrameWork.Function.NConvert.ToDecimal(denominator);
                this.txtDoseOnce.Text = doseOnce.ToString();
            }
            else
            {
                if (Neusoft.FrameWork.Public.String.IsNumeric(strInput))
                {
                    decimal input = Neusoft.FrameWork.Function.NConvert.ToDecimal(strInput);
                    decimal doseOnce = input * (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose;
                    this.txtDoseOnce.Text = doseOnce.ToString();
                }
                else
                {
                    MessageBox.Show("输入的数字不合法！");
                    return;
                }
            }
        }

        /// <summary>
        /// 计算每次用量倍数（最小单位数量）
        /// {76DF3C65-8215-4327-ACE2-10B307ACBA59}
        /// </summary>
        private void ComputeDoseOnceMultiple()
        {
            decimal multiple = decimal.Parse(this.txtDoseOnce.Text) / (this.myorder.Item as Neusoft.HISFC.Models.Pharmacy.Item).BaseDose;
            this.txtMultiple.Text = multiple.ToString();
        }

        private void cmbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region {3B3748E1-1A30-4017-96D6-1EE6EEA77F57}
            if (this.cmbFrequency.SelectedIndex < 0) return;
            #endregion
            if (this.IsNew) return;
            if (this.myorder == null) return;
          
            string time = "";
            #region 2010-12-14 修改增加空值判断{BF58E89A-37A8-489a-A8F6-5BA038EAE5A7}
            //if (this.myorder.Frequency.ID == this.cmbFrequency.SelectedItem.ID)
            //    time = this.myorder.Frequency.Time;//获得频次时间点,当然也可以用IsNew来代替
            if (this.myorder.Frequency != null)
            {
                if (this.myorder.Frequency.ID == this.cmbFrequency.SelectedItem.ID)
                    time = this.myorder.Frequency.Time;//获得频次时间点,当然也可以用IsNew来代替
            }
            #endregion 
            this.myorder.Frequency = ((Neusoft.HISFC.Models.Order.Frequency)this.cmbFrequency.SelectedItem).Clone();
            if(time !="" ) this.myorder.Frequency.Time = time;//赋回时间点
            this.txtFrequency.Text = this.myorder.Frequency.Name;
            this.lnkTime.Text = this.myorder.Frequency.Time;
            if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.Frequency);
        }

        void CheckedChanged(object sender, EventArgs e)
        {
            if (this.IsNew) return;
            if (this.myorder == null) return;
            switch(this.GetVisiblePanel())
            {
                case 1:
                    this.myorder.IsEmergency = this.chkDrugEmerce.Checked;
                    break;
                case 2:
                    this.myorder.IsEmergency = false;
                    break;
                default:
                    this.myorder.IsEmergency = this.chkEmerce.Checked;
                    break;
            
             }
            if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.Emc);
        }

        void Mouse_Leave(object sender, EventArgs e)
        {
            if (this.IsNew) return;
            if (this.dirty) return;
            if (this.myorder == null) return;
            switch (((Control)sender).Name)
            {
                case "txtDoseOnce":
                    if (this.ItemSelected != null)
                    {
                        //this.ComputeDoseOnceMultiple();
                        this.ItemSelected(this.Order, EnumOrderFieldList.DoseOnce);
                    }
                    break;
                case "txtFrequency":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Frequency);
                    break;
                case "txtFu":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Fu);
                    break;
                case "txtMinUnit":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.MinUnit);
                    break;
                case "txtSample":
                    if (this.ItemSelected != null)
                    { this.ItemSelected(this.Order, EnumOrderFieldList.Sample);
                    this.txtSample.SelectionStart = this.txtSample.Text.Length;
                    }
                    break;
                case "cmbExeDept":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.ExeDept);
                    break;
                case "cmbMemo1":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Memo);
                    break;
                case "cmbMemo2":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Memo);
                    break;
                case "cmbMemo3":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Memo);
                    break;
                case "cmbUsage1":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Usage);
                    break;
                case "cmbUsage2":
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Usage);
                    break;
                case "txtMultiple"://{76DF3C65-8215-4327-ACE2-10B307ACBA59}
                    //this.ComputeDoseOnce();
                    break;
                default:
                    if (this.ItemSelected != null) this.ItemSelected(this.Order, EnumOrderFieldList.Item);
                    break;
            }
          
        }
        #endregion

        #region	"公共函数"
        /// <summary>
        /// 清空
        /// </summary>
        public virtual void Clear()
        {
            this.IsNew = true;
            this.myorder = null;
            this.txtDoseOnce.Text = "0";				//每次用量
            this.txtMinUnit.Text = "";				//每次用量单位
            this.cmbMemo1.Text = "";				//备注
            this.cmbMemo2.Text = "";
            this.cmbMemo3.Text = "";
            this.txtFu.Text = "0";					//付数
            this.cmbExeDept.Text = "";				//执行科室
            this.chkEmerce.Checked = false;			//加急
            this.chkDrugEmerce.Checked = false;		//加急
            this.txtSample.Text = "";
            this.cmbFrequency.Tag = "";
            this.cmbFrequency.Text = "";
            this.txtFrequency.Text = "";
            this.cmbUsage1.Text = "";
            this.cmbUsage1.Tag = "";
            this.cmbUsage2.Text = "";
            this.cmbUsage2.Tag = "";
            this.IsNew = false;
        }

        /// <summary>
        /// 快速跳转
        /// </summary>
        public void SetShortKey()
        {
            if (this.txtDoseOnce.Focused || this.txtFu.Focused || this.cmbExeDept.Focused)
            {
                if (this.Leave != null) this.Leave(null,null);
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="alFrequency"></param>
        /// <param name="alDept"></param>
        public virtual void InitControl(ArrayList alFrequency, ArrayList alDept,ArrayList alUsage)
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager d = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            try
            {
                //{9612FEE2-A951-4b33-82DF-B97167D0076E}
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager ();

                ArrayList alExecDeptList = managerIntegrate.GetConstantList("ExceDeptList");

                ArrayList alAddDept = new ArrayList();
                if (alDept == null)
                {
                     alDept = d.GetDepartment();

                     if (alExecDeptList.Count == 0)
                     {
                         alAddDept = alDept;
                     }
                     else
                     {
                         foreach (Neusoft.HISFC.Models.Base.Department deptObj in alDept)
                         {
                             foreach (Neusoft.FrameWork.Models.NeuObject item in alExecDeptList)
                             {
                                 if (deptObj.DeptType.ID.ToString() == item.ID)
                                 {
                                     alAddDept.Add(deptObj);
                                 }
                             }

                         }
                     }
                     

                }
                //this.cmbExeDept.AddItems(alDept);
                this.cmbExeDept.AddItems(alAddDept);
                this.cmbExeDept.IsListOnly = true;

                

                if (alFrequency == null)
                {
                    alFrequency = Classes.Function.HelperFrequency.ArrayObject;
                }

                this.cmbFrequency.ShowID = true;
                this.cmbFrequency.AddItems(alFrequency);
                this.cmbFrequency.IsListOnly = true;

                //初始化用法
                this.cmbUsage1.AddItems(Classes.Function.HelperUsage.ArrayObject);
                this.cmbUsage2.AddItems(this.cmbUsage1.alItems);
                this.cmbUsage1.IsListOnly = true;
                this.cmbUsage2.IsListOnly = true;
                //初始化样本类型
                this.txtSample.AddItems(d.GetConstantList(Neusoft.HISFC.Models.Base.EnumConstant.LABSAMPLE));
            }
            catch { }
            #region {76DF3C65-8215-4327-ACE2-10B307ACBA59}
            this.txtMultiple.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.txtMultiple.TextChanged += new EventHandler(Mouse_Leave);
            #endregion
            this.txtDoseOnce.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.txtFu.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbFrequency.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbUsage1.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbUsage2.KeyPress += new KeyPressEventHandler(ItemKeyPress);

            this.txtMinUnit.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbMemo1.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbMemo2.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.cmbMemo3.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.txtSample.KeyPress += new KeyPressEventHandler(ItemKeyPress);//{31EB54C5-C30E-4130-89F2-BBF57D6BAFF6}
            //处理鼠标离开后的备注刷新
            this.cmbMemo1.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbMemo2.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbMemo3.TextChanged += new EventHandler(Mouse_Leave);
            this.txtSample.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbExeDept.SelectedIndexChanged += new EventHandler(Mouse_Leave);
            this.cmbUsage1.SelectedIndexChanged += new EventHandler(Mouse_Leave);
            this.cmbUsage2.SelectedIndexChanged += new EventHandler(Mouse_Leave);
            this.cmbMemo1.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbMemo2.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbMemo3.TextChanged += new EventHandler(Mouse_Leave);
            this.txtDoseOnce.TextChanged += new EventHandler(Mouse_Leave);
            this.txtMinUnit.TextChanged += new EventHandler(Mouse_Leave);
            this.txtFu.TextChanged += new EventHandler(Mouse_Leave);
            this.cmbFrequency.SelectedIndexChanged += new EventHandler(cmbFrequency_SelectedIndexChanged);
            this.cmbExeDept.KeyPress += new KeyPressEventHandler(ItemKeyPress);
            this.chkEmerce.CheckedChanged += new EventHandler(CheckedChanged);
            this.chkDrugEmerce.CheckedChanged += new EventHandler(CheckedChanged);
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public new void Focus()
        {
            switch (GetVisiblePanel())
            {
                case 1://{76DF3C65-8215-4327-ACE2-10B307ACBA59}
                    this.txtMultiple.Focus();
                    this.txtMultiple.SelectAll();
                    //this.txtDoseOnce.Focus();
                    //this.txtDoseOnce.SelectAll();
                    break;
                case 2:
                    this.txtFu.Focus();
                    this.txtFu.SelectAll();
                    break;
                case 3:
                    this.cmbExeDept.Focus();
                    this.cmbExeDept.SelectAll();
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 时间点变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.myorder == null || this.myorder.Frequency ==null || this.myorder.Frequency.Times.Length > 5) return;
            
            Forms.frmSpecialFrequency f = new HISFC.Components.Order.Forms.frmSpecialFrequency();
            //if (this.myorder.OrderType.IsDecompose == false || this.myorder.Item.IsPharmacy == false)//临时医嘱,非药品医嘱 不能修改特殊频次的剂量
            if (this.myorder.OrderType.IsDecompose == false || this.myorder.Item.ItemType != Neusoft.HISFC.Models.Base.EnumItemType.Drug)//临时医嘱,非药品医嘱 不能修改特殊频次的剂量
                f.IsDoseCanModified = false;

            f.Frequency = this.myorder.Frequency.Clone();
            
            if (this.myorder.ExecDose == "")
                f.Dose = this.myorder.DoseOnce.ToString();
            else
                f.Dose = this.myorder.ExecDose;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.myorder.Frequency = f.Frequency.Clone();
                if (f.Dose.IndexOf("-")>0)
                {
                    this.myorder.ExecDose = f.Dose;
                    this.myorder.Memo = "时间："+f.Frequency.Time + " 剂量："+f.Dose;
                    if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.Memo);
                }
                else
                {
                    this.myorder.DoseOnce = Neusoft.FrameWork.Function.NConvert.ToDecimal(f.Dose);
                    this.myorder.ExecDose = "";
                    this.myorder.Memo = "";
                    if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.DoseOnce);
                    if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.Memo);
                }
                if (this.ItemSelected != null) this.ItemSelected(this.myorder, EnumOrderFieldList.Frequency);
            }
        }
       
    }
    /// <summary>
    /// 
    /// </summary>
    public enum EnumOrderFieldList
    {
        OrderType = 0,//医嘱类型
        Item = 1,//项目全变化了
        Qty = 1,//总量
        Unit = 2,//总量单位
        BeginDate = 3,//开始日期
        EndDate = 4,//结束日期
        DoseOnce  = 5,//一次剂量
        MinUnit = 6,//每次计量单位
        Fu = 7,//付数
        Memo = 8,//备注变化
        ExeDept = 9,//执行科室变化
        Emc = 10,//加急
        Sample =11,//样本类型
        Frequency = 12,//频次
        Usage = 13 //用法
    }
}

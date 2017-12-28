using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using System.Collections;
namespace Neusoft.HISFC.Components.Material.Base
{
    /// <summary>		
    /// ucMaterialManager的摘要说明。<br></br>
    /// [功能描述: 物资信息维护]<br></br>
    /// [创 建 者: 李超]<br></br>
    /// [创建时间: 2007-03-28<br></br>
    /// </summary>
    public partial class ucMaterialManager : UserControl
    {
        public ucMaterialManager()
        {
            InitializeComponent();
            this.Init();
        }

        #region 管理类

        /// <summary>
        /// 物资字典管理
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.MetItem magageMetItem = new Neusoft.HISFC.BizLogic.Material.MetItem();

        /// <summary>
        /// 物资库存管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store storeManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 取常数列表
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Constant constant = new Neusoft.HISFC.BizLogic.Manager.Constant();

        /// <summary>
        /// 拼音码
        /// </summary>
        private Neusoft.HISFC.BizLogic.Manager.Spell mySpell = new Neusoft.HISFC.BizLogic.Manager.Spell();

        /// <summary>
        /// 控制参数
        /// </summary>
        protected Neusoft.HISFC.BizLogic.Manager.Controler controler = new Neusoft.HISFC.BizLogic.Manager.Controler();

        /// <summary>
        /// 基础信息
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset baseInfo = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 厂商信息
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.ComCompany comCompany = new Neusoft.HISFC.BizLogic.Material.ComCompany();

        #endregion

        #region 域变量

        /// <summary>
        /// 物资字典实体
        /// </summary>
        private Neusoft.HISFC.Models.Material.MaterialItem item;

        /// <summary>
        /// 连续录入保留的最初字典实体
        /// </summary>
        private Neusoft.HISFC.Models.Material.MaterialItem originalItem;

        /// <summary>
        /// 操作类型
        /// </summary>
        private string inputType = "N";

        /// <summary>
        /// 控制参数
        /// </summary>
        private string checkCtrl = "0";

        /// <summary>
        /// 当前物资科目级别
        /// </summary>
        private string matKind = "";

        /// <summary>
        /// 回车跳转顺序
        /// </summary>
        private System.Collections.Hashtable hsJudgeOrder = new Hashtable();

        public delegate void SaveInput(Neusoft.HISFC.Models.Material.MaterialItem item);

        public event SaveInput MyInput;

        public string storageCode;//liuxq add

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
                if (value.ToString().ToUpper() == "U")
                {
                    this.continueCheckBox.Enabled = false;
                }
                else if (value.ToUpper().ToUpper() == "I")
                {
                    this.continueCheckBox.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 物资科目级别编码
        /// </summary>
        public string MatKind
        {
            get
            {
                return this.matKind;
            }
            set
            {
                this.matKind = value;
            }
        }

        /// <summary>
        /// 新增物品是否需要经过审核
        /// </summary>
        public bool IsCheck
        {
            get
            {
                if (checkCtrl == "1")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 是否处于只读状态 不允许修改
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return this.btnSave.Visible;
            }
            set
            {
                this.btnSave.Visible = !value;
            }
        }

        /// <summary>
        /// 控件内操作的物品实体
        /// </summary>
        public Neusoft.HISFC.Models.Material.MaterialItem Item
        {
            get
            {
                this.GetItem();
                return this.item;
            }
            set
            {
                if (value == null)
                {
                    this.item = new Neusoft.HISFC.Models.Material.MaterialItem();
                }
                else
                {
                    this.item = value;
                }

                this.originalItem = this.item.Clone();

                this.SetItem();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 从控件中取数据,赋予item实体
        /// </summary>
        private void GetItem()
        {
            Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();

            string operCode = ((Neusoft.HISFC.Models.Base.Employee)data.Operator).ID;

            if (this.item == null)
            {
                this.item = new Neusoft.HISFC.Models.Material.MaterialItem();
            }

            this.item.ID = this.txtItemId.Text;

            //if (this.inputType == "I")
            //{
            //    Neusoft.HISFC.BizLogic.Material.MetItem item = new Neusoft.HISFC.BizLogic.Material.MetItem();

            //    try
            //    {
            //        this.item.ID = item.GetMaxItemID(this.cmbKind.Tag.ToString());
            //        this.txtItemId.Text = this.item.ID;
            //    }
            //    catch { }
            //}
            this.item.Name = this.txtName.Text;
            this.item.SpellCode = this.txtSpellCode.Text;
            this.item.WBCode = this.txtWbCode.Text;
            this.item.UserCode = this.txtUserCode.Text;
            this.item.GbCode = this.txtGbCode.Text;
            this.item.MaterialKind.ID = this.cmbKind.Tag.ToString();
            this.item.Specs = this.txtSpec.Text;
            this.item.MinUnit = this.cmbUnit.Text.ToString();
            this.item.UnitPrice = NConvert.ToDecimal(txtPrice.Text);
            this.item.ApproveInfo = this.txtApprove.Text;
            if (this.cmbMet.Tag != null)
            {
                this.item.Compare.ID = this.cmbMet.Tag.ToString();
                this.item.Compare.Name = this.cmbMet.Text;
            }
            if (this.cmbUnDrug.Tag != null)
            {
                if (this.cmbUnDrug.Tag.ToString() == "None")
                {
                    this.item.UndrugInfo.ID = "";
                    this.item.UndrugInfo.Name = "";
                }
                else
                {
                    this.item.UndrugInfo.ID = this.cmbUnDrug.Tag.ToString();
                    this.item.UndrugInfo.Name = this.cmbUnDrug.Text;
                }
            }
            this.item.ValidState = !this.ckStop.Checked;
            this.item.SpecialFlag = Neusoft.FrameWork.Function.NConvert.ToInt32(this.ckSpecial.Checked).ToString();

            this.item.Factory.ID = this.cmbFactory.Tag.ToString();
            this.item.Company.ID = this.cmbCompany.Tag.ToString();
            this.item.MinFee.ID = this.cmbFeeKind.Tag.ToString();
            this.item.StatInfo.ID = this.cmbStatCode.Tag.ToString();
            this.item.InSource = this.txtSource.Text;
            this.item.Usage = this.txtUse.Text;
            this.item.PackUnit = this.cmbPackUnit.Text.ToString();
            this.item.PackQty = NConvert.ToDecimal(txtPackNum.Text);
            this.item.PackPrice = this.item.UnitPrice * this.item.PackQty;
            this.item.StorageInfo.ID = this.txtStorage.Text;
            this.item.Oper.ID = operCode;
            this.item.OperTime = Convert.ToDateTime(DateTime.Now.ToString("f"));
            this.item.FinanceState = this.ckFinance.Checked;
            this.item.Mader = this.txtMader.Text;
            this.item.ZCH = this.txtZCH.Text;
            this.item.SpeType = this.cmbSpeType.Text;
            this.item.ZCDate = this.dtZC.Value;
            this.item.OverDate = this.dtOver.Value;

        }

        /// <summary>
        /// 从item实体中取数据,赋予控件
        /// </summary>
        private void SetItem()
        {
            Neusoft.FrameWork.Management.DataBaseManger data = new Neusoft.FrameWork.Management.DataBaseManger();

            string operName = ((Neusoft.HISFC.Models.Base.Employee)data.Operator).Name;

            this.txtItemId.Text = this.item.ID;
            this.txtName.Text = this.item.Name;
            this.txtSpellCode.Text = this.item.SpellCode;
            this.txtWbCode.Text = this.item.WBCode;
            this.txtUserCode.Text = this.item.UserCode;
            this.txtGbCode.Text = this.item.GbCode;
            this.cmbKind.Tag = this.item.MaterialKind.ID;
            
            if (this.inputType == "I")
            {
                //{1349F10A-8E5D-4fba-8EDE-D6B09A6F88A7}根节点不允许增加物资 避免主键重复
                //this.cmbKind.Tag = this.item.MaterialKind.ID;
                if (this.cmbKind.Tag.ToString() == "0")
                {
                    this.cmbKind.Tag = "";
                }
                //----------------
                this.ckStop.Checked = false;
                this.ckFinance.Checked = false;
            }
            else
            {
                this.ckStop.Checked = !this.item.ValidState;
                this.ckFinance.Checked = this.item.FinanceState;

            }
            this.txtSpec.Text = this.item.Specs;
            this.cmbUnit.Text = this.item.MinUnit;
            this.txtPrice.Text = this.item.UnitPrice.ToString();
            this.txtApprove.Text = this.item.ApproveInfo;

            this.cmbMet.Tag = this.item.Compare.ID;
            if (this.cmbUnDrug.Tag.ToString() != "None")
            {
                this.cmbUnDrug.Tag = this.item.UndrugInfo.ID;
            }
            else
            {
                this.item.UndrugInfo.ID = "";
            }

            this.ckSpecial.Checked = Neusoft.FrameWork.Function.NConvert.ToBoolean(this.item.SpecialFlag);
            this.cmbFactory.Tag = this.item.Factory.ID;
            this.cmbCompany.Tag = this.item.Company.ID;
            this.cmbFeeKind.Tag = this.item.MinFee.ID;
            this.cmbStatCode.Tag = this.item.StatInfo.ID;
            this.txtSource.Text = this.item.InSource;
            this.txtUse.Text = this.item.Usage;
            this.cmbPackUnit.Text = this.item.PackUnit;
            this.txtPackNum.Text = this.item.PackQty.ToString();

            this.txtStorage.Text = this.item.StorageInfo.ID;//this.storageCode;		

            this.txtMader.Text = this.item.Mader;
            this.txtZCH.Text = this.item.ZCH;
            this.cmbSpeType.Text = this.item.SpeType;
            if (this.item.OverDate.ToString() == "0001-1-1 0:00:00")
            {
                this.item.OverDate = System.DateTime.Now;
            }
            this.dtOver.Value = this.item.OverDate;

            if (this.item.ZCDate.ToString() == "0001-1-1 0:00:00")
            {
                this.item.ZCDate = System.DateTime.Now;
            }
            this.dtZC.Value = this.item.ZCDate;

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>成功: 返回1,失败: 返回 -1</returns>
        public int Save()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            magageMetItem.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            int parm = 1;

            Neusoft.HISFC.Models.Material.MaterialItem matItem = new Neusoft.HISFC.Models.Material.MaterialItem();

            matItem = this.Item;

            #region 处理将物资有效性状态
            if (this.InputType == "U")
            {
                this.storeManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);
                string errMsg = "";

                if (this.SetMatVaild(matItem, out errMsg) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(errMsg);
                    return -1;
                }
            }
            #endregion

            switch (this.InputType)
            {
                case "U":
                    parm = magageMetItem.UpdateMetItem(matItem);
                    break;
                case "I":
                    matItem.ID = magageMetItem.GetMaxItemID(this.cmbKind.Tag.ToString());
                    parm = magageMetItem.InsertMetItem(matItem);
                    break;
                case "N":
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    return -1;
            }

            if (parm == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(this.magageMetItem.Err);
                return -1;
            }
            else
            {

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                if (this.inputType == "I")
                {
                    this.MyInput(matItem);
                }

                MessageBox.Show("保存成功！", "提示");

                return 1;
            }
        }

        /// <summary>
        /// 将该物品设置为无效状态：更新log_mat_stock和log_mat_stockinfo的有效标志字段
        /// </summary>
        /// <param name="matItem">物资项目实体</param>
        /// <returns>1:成功；-1:失败</returns>
        private int SetMatVaild(Neusoft.HISFC.Models.Material.MaterialItem matItem, out string errMsg)
        {
            errMsg = "";
            Neusoft.HISFC.Models.Material.MaterialItem oldMatItem = this.magageMetItem.GetMetItemByMetID(matItem.ID);
            if (oldMatItem == null)
            {
                errMsg = "获取原物资信息失败" + this.magageMetItem.Err;
                return -1;
            }
            if ((oldMatItem.ValidState && matItem.ValidState) || (!oldMatItem.ValidState && !matItem.ValidState))
            {
                return 1;
            }
            if (this.storeManager.SetMatVaild(matItem.ID, matItem.ValidState) == -1)
            {
                errMsg = "更改库存物资有效状态失败" + this.storeManager.Err;
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void Init()
        {
            try
            {
                this.cmbPackUnit.AddItems(constant.GetList("WZPACKUNIT"));
                this.cmbUnit.AddItems(constant.GetList("WZUNIT"));
                this.cmbFeeKind.AddItems(constant.GetList(Neusoft.HISFC.Models.Base.EnumConstant.MINFEE));
                this.cmbFactory.AddItems(comCompany.QueryCompany("0", "A"));
                this.cmbCompany.AddItems(comCompany.QueryCompany("1", "A"));
                this.cmbKind.AddItems(baseInfo.QueryKind());
                this.btnSave.Visible = true;

                Neusoft.HISFC.BizProcess.Integrate.Fee feeIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Fee();
                List<Neusoft.HISFC.Models.Fee.Item.Undrug> feeItemCollection = feeIntegrate.QueryAllItemsList();
                Neusoft.HISFC.Models.Fee.Item.Undrug info = new Neusoft.HISFC.Models.Fee.Item.Undrug();
                info.ID = "None";
                info.Name = "取消对照";
                feeItemCollection.Insert(0, info);

                this.cmbUnDrug.AddItems(new ArrayList(feeItemCollection.ToArray()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化物资项目维护窗口失败：" + ex.Message);
                return;
            }

        }

        /// <summary>
        /// 控制控件的只读
        /// </summary>
        /// <param name="flag"></param>
        public void ReadOnlySp(bool flag)
        {
        }

        /// <summary>
        /// 检查数据有效性
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (this.inputType == "I" && this.ckStop.Checked)
            {
                MessageBox.Show("不能增加无效状态的物资项目!请取消选择“停用”复选框");
                return false;
            }
            if (this.txtName.TextLength == 0)
            {
                MessageBox.Show("名称不能为空!");
                this.txtName.Focus();
                return false;
            }
            if (this.txtSpellCode.TextLength == 0)
            {
                MessageBox.Show("拼音不能为空!");
                this.txtSpellCode.Focus();
                return false;
            }
            if (this.cmbKind.Text == "" || this.cmbKind.Text == null)
            {
                MessageBox.Show("科目类别不能为空!");
                this.cmbKind.Focus();
                return false;
            }
            if (this.txtPrice.Text == "" || this.txtPrice.Text == null)
            {
                MessageBox.Show("单价不能空!");
                this.txtPrice.Focus();
                return false;
            }
            if (this.txtSpec.TextLength == 0)
            {
                MessageBox.Show("规格不能为空!");
                this.txtSpec.Focus();
                return false;
            }
            //			if (this.txtPackNum.TextLength == 0||this.txtPackNum.Text.Trim() == "0") 
            //			{
            //				MessageBox.Show("包装数量不能为空或者0!");
            //				this.txtPackNum.Focus();
            //				return false;
            //			}
            //			if (this.cmbPackUnit.Text == "" || this.cmbPackUnit.Text == null) 
            //			{
            //				MessageBox.Show("包装单位不能为空!");
            //				this.cmbPackUnit.Focus();
            //				return false;
            //			}
            if (this.cmbUnit.Text == "" || this.cmbUnit.Text == null)
            {
                MessageBox.Show("最小单位不能为空!");
                this.cmbUnit.Focus();
                return false;
            }
            if (this.txtUserCode.Text.Length == 0)
            {
                MessageBox.Show("自定义编码不能为空!");
                this.txtUserCode.Focus();
                return false;
            }
            if (this.ckFinance.Checked)
            {
                if (this.cmbFeeKind.Tag.ToString() == "")
                {
                    MessageBox.Show("财务收费项目必须填写费用类别!");
                    this.cmbFeeKind.Focus();
                    return false;
                }
            }
            //			if (this.txtPackPrice.Text.Length == 0||this.txtPackPrice.Text.Trim() == "0") 
            //			{
            //				MessageBox.Show("大包装价格不能为空或者0!");
            //				this.txtPackPrice.Focus();
            //				return false;
            //			}		

            System.Decimal decPrice;

            decPrice = Neusoft.FrameWork.Function.NConvert.ToDecimal(txtPrice.Text.Trim()) * Neusoft.FrameWork.Function.NConvert.ToDecimal(txtPackNum.Text.Trim());

            //			if (decPrice != Neusoft.FrameWork.Function.NConvert.ToDecimal(txtPackPrice.Text.Trim()))
            //			{
            //				MessageBox.Show("单价 × 包装数量 和 包装价格不相等!");
            //				return false;
            //			}
            return true;
        }

        /// <summary>
        /// 清空控件
        /// </summary>
        public void Reset()
        {
            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    foreach (System.Windows.Forms.Control crl in c.Controls)
                    {
                        if (crl.GetType() == typeof(Neusoft.FrameWork.WinForms.Controls.NeuComboBox))
                            continue;
                        if (crl.GetType() != typeof(System.Windows.Forms.Label) && crl.GetType() != typeof(System.Windows.Forms.CheckBox))
                        {
                            crl.Tag = "";
                            crl.Text = "";
                        }
                    }
                }
            }

            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    foreach (System.Windows.Forms.Control crl in c.Controls)
                    {
                        if (crl.GetType() != typeof(System.Windows.Forms.Label) && crl.GetType() != typeof(System.Windows.Forms.CheckBox))
                        {
                            crl.Tag = "";
                            crl.Text = "";
                        }
                    }
                }
            }

            this.item = null;
            //this.cmbKind.Tag = this.item.MaterialKind.ID;

            this.ckFinance.Checked = false;
            this.ckStop.Checked = false;
        }

        #endregion

        #region 事件

        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        SendKeys.Send("{TAB}");
        //    }

        //    return base.ProcessDialogKey(keyData);
        //}

        private void ucMaterialManager_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //检查数据有效性
            if (!this.IsValid()) return;

            //保存
            if (this.Save() == -1) return;


            switch (this.InputType)
            {
                case "U":
                    this.InputType = "N";
                    this.FindForm().Close();
                    break;
                case "I":

                    this.Reset();

                    if (this.continueCheckBox.Checked)
                    {
                        //						this.MyInput(this.Item);
                        this.InputType = "I";
                        this.Item = this.originalItem;
                        //{311DF45B-025A-4fac-A8FD-1B74AFFE4933}
                        this.txtName.Focus();
                    }
                    else
                    {
                        this.InputType = "N";
                        this.FindForm().Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.FindForm().Close();
        }

        /// <summary>
        /// 回车自动生成拼音码、五笔码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Neusoft.HISFC.Models.Base.Spell spCode = new Neusoft.HISFC.Models.Base.Spell();

                spCode = (Neusoft.HISFC.Models.Base.Spell)mySpell.Get(this.txtName.Text.Trim());
                this.txtSpellCode.Text = spCode.SpellCode;
                this.txtWbCode.Text = spCode.WBCode;
            }

        }

        private void txtPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.txtPackNum.Text = "1";
            }
        }

        private void cmbUnit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.txtPackNum.Text = "1";
                this.cmbPackUnit.Tag = this.cmbUnit.Tag;
                this.cmbPackUnit.Text = this.cmbUnit.Text;
            }
        }

        private void neuLabel11_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// [功能描述: 固定费用维护]<br></br>
    /// [创 建 者: 周雪松]<br></br>
    /// [创建时间: 2006-11-10]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucBedFeeItemModify : UserControl
    {
        public ucBedFeeItemModify()
        {
            InitializeComponent();
        }

        #region 变量定义

        /// <summary>
        ///当前的ID
        /// </summary>
        private string iD = string.Empty;

        /// <summary>
        ///固定费用实体
        /// </summary>
        private Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem = new Neusoft.HISFC.Models.Fee.BedFeeItem();

        /// <summary>
        /// 代理
        /// </summary>
        /// <param name="bedFeeItem"></param>
        public delegate int ClickSave(Neusoft.HISFC.Models.Fee.BedFeeItem bedFeeItem);

        /// <summary>
        /// 保存事件
        /// </summary>
        public event ClickSave Save;

        /// <summary>
        /// 管理业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.Item itemManager = new Neusoft.HISFC.BizLogic.Fee.Item();

        /// <summary>
        /// 费用业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.BedFeeItem bedFeeItemManager = new Neusoft.HISFC.BizLogic.Fee.BedFeeItem();

        /// <summary>
        /// 当前Uc是保存还是增加
        /// </summary>
        private EnumSaveTypes saveType;

        /// <summary>
        /// 最小费用列表
        /// </summary>
        private ArrayList itemInfo = new ArrayList();

        /// <summary>
        /// 原始床位费用信息
        /// </summary>
        private Neusoft.HISFC.Models.Fee.BedFeeItem originalFeeItem = null;
        #endregion

        #region 属性

        /// <summary>
        /// 项目列表
        /// </summary>
        public ArrayList ItemInfo
        {
            get
            {
                return this.itemInfo;
            }
            set
            {
                this.itemInfo = value;
            }
        }

        /// <summary>
        /// 是保存还是增加
        /// </summary>
        public EnumSaveTypes SaveType
        {
            get
            {
                return this.saveType;
            }
            set
            {
                this.saveType = value;
                if (this.saveType == EnumSaveTypes.Add)
                {
                    this.ckbContinue.Visible = true;
                }
                else
                {
                    this.ckbContinue.Visible = false;
                }
            }
        }

        /// <summary>
        /// 当前的ID
        /// </summary>
        public string ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD= value;
            }
        }

        /// <summary>
        /// 固定费用实体
        /// </summary>
        public Neusoft.HISFC.Models.Fee.BedFeeItem BedFeeItem
        {
            get
            {
                return this.bedFeeItem;
            }
            set
            {
                this.bedFeeItem = value;

                this.originalFeeItem = value.Clone();
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 增加在用、停用、废弃下拉框
        /// </summary>
        protected virtual void InitValidState()
        {
            ArrayList validStates = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "1";
            obj.Name = "在用";
            validStates.Add(obj);

            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "0";
            obj1.Name = "停用";
            validStates.Add(obj1);

            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "2";
            obj2.Name = "废弃";
            validStates.Add(obj2);

            this.cmbValidState.AddItems(validStates);
        }

        /// <summary>
        /// 修改规类属性
        /// </summary>
        protected virtual void Modify()
        {
            this.cmbItemInfo.Text = this.bedFeeItem.Name;
            this.ntxtPrice.Text = itemManager.GetValidItemByUndrugCode(this.bedFeeItem.ID).Price.ToString();
            this.ntxtQty.Text = this.bedFeeItem.Qty.ToString();
            try
            {
                if (bedFeeItem.IsTimeRelation == true)
                {
                    this.dtBegin.Checked = true;
                    this.dtBegin.Text = this.bedFeeItem.BeginTime.ToString();
                }
                else
                {
                    this.dtBegin.Checked = false;
                }
            }
            catch
            {
            }
            try
            {
                if (bedFeeItem.IsTimeRelation == true)
                {
                    this.dtEnd.Checked = true;
                    this.dtEnd.Text = this.bedFeeItem.EndTime.ToString();
                }
                else
                {
                    this.dtEnd.Checked = false;
                }
            }
            catch
            {
            }
            this.ckbBabyRelation.Checked = this.bedFeeItem.IsBabyRelation;
            this.ckbTimeRelation.Checked = this.bedFeeItem.IsTimeRelation;
            this.cmbValidState.Tag = ((int)this.bedFeeItem.ValidState).ToString();

            this.cmbItemInfo.Focus();
        }

        /// <summary>
        /// 增加规类
        /// </summary>
        protected virtual void Add()
        {
            this.cmbValidState.Tag = "0";
            this.cmbValidState.Text = "在用";
            this.cmbValidState.Enabled = true;
            
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>有效 True 无效 False</returns>
        protected virtual bool IsValid()
        {
            if (this.cmbItemInfo.Text == string.Empty || this.cmbItemInfo.Tag == null)
            {
                MessageBox.Show(Language.Msg("项目名称不能为空!"));
                this.cmbItemInfo.Focus();

                return false;
            }

            if (this.ntxtQty.Text == string.Empty || this.ntxtQty.Text == null || Convert.ToDecimal(this.ntxtQty.Text) == 0)
            {
                MessageBox.Show(Language.Msg("数量不能为空!"));
                this.ntxtQty.Focus();
                return false;
            }
            
            if (this.cmbValidState.Text == string.Empty || this.cmbValidState.Text == null)
            {
                MessageBox.Show("有效性标识不能为空!");
                this.cmbValidState.Focus();

                return false;
            }

            if (this.dtBegin.Value > this.dtEnd.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获得有效性的名称
        /// </summary>
        /// <param name="id">编码</param>
        /// <returns>成功 有效性的名称 失败 null</returns>
        protected virtual string GetValidName(string id)
        {
            string name = string.Empty;

            switch (id)
            {
                case "0":
                    name = "在用";
                    break;
                case "1":
                    name = "停用";
                    break;
                case "2":
                    name = "废弃";
                    break;
            }

            return name;
        }

        /// <summary>
        /// 确定事件
        /// </summary>
        /// <returns>成功 1 失败 -1</returns>
        protected virtual int Confirm()
        {
            //判断有效性
            if (!this.IsValid())
            {
                return -1;
            }
            
            this.bedFeeItem.ID = this.cmbItemInfo.Tag.ToString();//项目编码
            this.bedFeeItem.Name = this.cmbItemInfo.Text.ToString();//项目名称
            this.bedFeeItem.Qty = Neusoft.FrameWork.Function.NConvert.ToDecimal(this.ntxtQty.Text);//数量
            this.bedFeeItem.BeginTime = this.dtBegin.Value;//开始时间            
            this.bedFeeItem.EndTime = this.dtEnd.Value;//结束时间
            this.bedFeeItem.IsBabyRelation = this.ckbBabyRelation.Checked;//婴儿相关
            this.bedFeeItem.IsTimeRelation = this.ckbTimeRelation.Checked;//时间相关
            this.bedFeeItem.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState)Neusoft.FrameWork.Function.NConvert.ToInt32(this.cmbValidState.Tag);//有效性标识
            
            //把修改或者增加的obj传回去
            
            try
            {
                if (this.Save(bedFeeItem) == -1)
                {
                    return -1;
                };
                //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.bedFeeItemManager.Connection);
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

                this.bedFeeItemManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int returnValue = 0;

                if (this.saveType == EnumSaveTypes.Add)
                {

                    returnValue = this.bedFeeItemManager.InsertBedFeeItem(this.bedFeeItem);
                }
                else
                {
                    returnValue = this.bedFeeItemManager.UpdateBedFeeItem(this.bedFeeItem);
                }

                if (returnValue <= 0)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("插入或更新固定费用信息出错!") + this.bedFeeItemManager.Err);
                    return -1;
                }
                Neusoft.FrameWork.Management.PublicTrans.Commit();

                Neusoft.HISFC.BizProcess.Integrate.Function funIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Function();
                bool isInsert = false;
                if (this.saveType == EnumSaveTypes.Add)
                {
                    isInsert = true;
                }
                funIntegrate.SaveChange<Neusoft.HISFC.Models.Fee.BedFeeItem>("BedF", isInsert, false, this.bedFeeItem.FeeGradeCode + "-" +  this.bedFeeItem.ID, this.originalFeeItem, this.bedFeeItem);

                
               

                if (!this.ckbContinue.Checked)
                {
                    this.ParentForm.Close();
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;

                
        }

        /// <summary>
        /// [2007/02/06]清空
        /// </summary>
        private void Clear()
        {
            this.cmbItemInfo.Text = "";
            this.ntxtPrice.Text = "0";
            this.ntxtQty.Text = "0";
            this.ckbBabyRelation.Checked = false;
            this.ckbTimeRelation.Checked = true;
            this.ckbContinue.Checked = false;
            this.cmbValidState.Text = "";
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 根据传入参数初始化
        /// </summary>
        public void Init()
        {
            this.InitCmb();
            this.ntxtPrice.Enabled = false;
            this.ntxtPrice.BackColor = Color.White;
            if (this.saveType == EnumSaveTypes.Add)
            {
                this.Add();
            }
            if (this.saveType == EnumSaveTypes.Modify)
            {
                this.Modify();
            }

        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        protected virtual int InitCmb()
        {
            try
            {
                this.cmbItemInfo.AddItems(itemInfo);
                this.InitValidState();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return -1;
            }

            return 1;
        }

        #endregion

        #region 枚举

        /// <summary>
        /// 保存的类型
        /// </summary>
        public enum EnumSaveTypes
        {
            /// <summary>
            /// 增加
            /// </summary>
            Add = 0,

            /// <summary>
            /// 修改
            /// </summary>
            Modify = 1
        }

        #endregion

        #region 事件

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.Confirm();
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBedFeeItemModify_load(object sender, EventArgs e)
        {
            this.Init();

            // [2007/02/06] 新增加的代码
            // this.Clear();
            // 新增加的代码

            try
            {
                this.FindForm().Text = "固定费用";
                this.FindForm().MinimizeBox = false;
                this.FindForm().MaximizeBox = false;
            }
            catch { }
        }
        

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        #endregion

        /// <summary>
        /// 窗口关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.FindForm().Close();
            }
            catch { }
        }

        private void cmbItemInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ntxtPrice.Text = itemManager.GetValidItemByUndrugCode(this.cmbItemInfo.Tag.ToString()).Price.ToString();
            //if (itemManager.GetValidItemByUndrugCode(this.cmbItemInfo.Tag.ToString()).Price == 0)
            //{
                //this.ntxtPrice.Enabled = true;
                
            //}
            //else
            //{
            //单价只是显示不可修改
            this.ntxtPrice.Enabled = false;
            this.BackColor = Color.White;
            //}
        }

        private void ckbTimeRelation_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTimeRelation.Checked)
            {
                this.dtBegin.Enabled = true;
                this.dtEnd.Enabled = true;
                this.dtBegin.Checked = true;
                this.dtEnd.Checked = true;
            }
            else
            {
                this.dtBegin.Enabled = false;
                this.dtEnd.Enabled = false;
                this.dtBegin.Checked = false;
                this.dtEnd.Checked = false;
            }
        }
    }
}

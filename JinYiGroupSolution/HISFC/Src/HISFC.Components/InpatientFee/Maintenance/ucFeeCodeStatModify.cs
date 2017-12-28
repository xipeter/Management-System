using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.FrameWork.Function;

namespace Neusoft.HISFC.Components.InpatientFee.Maintenance
{
    /// <summary>
    /// ucFeeCodeStatModify<br></br>
    /// [功能描述: 统计大类维护UC]<br></br>
    /// [创 建 者: 王宇]<br></br>
    /// [创建时间: 2006-11-26]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucFeeCodeStatModify : UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ucFeeCodeStatModify()
        {
            InitializeComponent();
        }

        #region 变量定义

        /// <summary>
        ///最大的打印序号
        /// </summary>
        private string maxPrintOrder = string.Empty;

        /// <summary>
        /// 统计大类实体
        /// </summary>
        private Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat = new Neusoft.HISFC.Models.Fee.FeeCodeStat();

        /// <summary>
        /// 费用统计大类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.FeeCodeStat feeCodeStatManager = new Neusoft.HISFC.BizLogic.Fee.FeeCodeStat();

        /// <summary>
        /// 代理
        /// </summary>
        /// <param name="feeCodeStat"></param>
        public delegate void ClickSave(Neusoft.HISFC.Models.Fee.FeeCodeStat feeCodeStat);

        /// <summary>
        /// 保存事件
        /// </summary>
        public event ClickSave Save;

        /// <summary>
        /// 管理业务层
        /// </summary>
        private Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

        /// <summary>
        /// 费用业务层
        /// </summary>
        private Neusoft.HISFC.BizLogic.Fee.InPatient inpatientManager = new Neusoft.HISFC.BizLogic.Fee.InPatient();

        /// <summary>
        /// 当前Uc是保存还是增加
        /// </summary>
        private EnumSaveTypes saveType;

        /// <summary>
        /// 最小费用列表
        /// </summary>
        private ArrayList minFeeList = new ArrayList();

        #endregion

        #region 属性

        /// <summary>
        /// 最小费用列表
        /// </summary>
        public ArrayList MinFeeList 
        {
            get 
            {
                return this.minFeeList;
            }
            set 
            {
                this.minFeeList = value;
                if (this.minFeeList != null) 
                {
                    this.cmbMinFee.ClearItems();

                    this.cmbMinFee.AddItems(this.minFeeList);
                }
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
                    
                }
            }
        }

        /// <summary>
        /// 最大的打印序号
        /// </summary>
        public string MaxPrintOrder 
        {
            get 
            {
                return this.maxPrintOrder;
            }
            set 
            {
                this.maxPrintOrder = value;
            }
        }
        
        /// <summary>
        /// 统计大类实体
        /// </summary>
        public Neusoft.HISFC.Models.Fee.FeeCodeStat FeeCodeStat 
        {
            get 
            {
                return this.feeCodeStat;
            }
            set 
            {
                this.feeCodeStat = value;
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
        /// 增加报表类别下拉框
        /// </summary>
        protected virtual void InitReportType()
        {
            ArrayList reportTypes = new ArrayList();

            Neusoft.FrameWork.Models.NeuObject obj = new Neusoft.FrameWork.Models.NeuObject();
            obj.ID = "FP";
            obj.Name = "发票";
            reportTypes.Add(obj);
            
            Neusoft.FrameWork.Models.NeuObject obj1 = new Neusoft.FrameWork.Models.NeuObject();
            obj1.ID = "TJ";
            obj1.Name = "统计";
            reportTypes.Add(obj1);
            
            Neusoft.FrameWork.Models.NeuObject obj2 = new Neusoft.FrameWork.Models.NeuObject();
            obj2.ID = "BA";
            obj2.Name = "病案";
            reportTypes.Add(obj2);
            
            Neusoft.FrameWork.Models.NeuObject obj3 = new Neusoft.FrameWork.Models.NeuObject();
            obj3.ID = "ZQ";
            obj3.Name = "知情权";
            reportTypes.Add(obj3);
            
            this.cmbReportType.AddItems(reportTypes);
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <returns></returns>
        protected virtual int InitCmb()
        {
            try
            {
                this.cmbExecDept.AddItems(this.managerIntegrate.QueryDeptmentsInHos(false));
                this.cmbCenterStatCode.AddItems(this.managerIntegrate.GetConstantList("CENTERFEECODE"));
                this.InitValidState();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return -1;
            }

            InitReportType();

            return 1;
        }

        /// <summary>
        /// 修改规类属性
        /// </summary>
        protected  virtual void Modify()
        {
            this.txtReportCode.Text = feeCodeStat.ID;
            this.txtReportCode.Enabled = false;
            this.txtReportName.Text = feeCodeStat.Name;
            this.txtReportName.Enabled = false;
            this.cmbReportType.Tag = feeCodeStat.ReportType.ID;
            this.cmbReportType.Enabled = false;
            //this.cmbMinFee.Tag = feeCodeStat.MinFee.ID;
            this.cmbMinFee.Tag = feeCodeStat.MinFee.ID.ToString();
            this.cmbMinFee.Enabled = false;
            this.txtFeeStatCode.Text = feeCodeStat.StatCate.ID;
            this.txtFeeStatName.Text = feeCodeStat.StatCate.Name;
            this.txtPrintOrder.Text = feeCodeStat.SortID.ToString();
            this.cmbExecDept.Tag = feeCodeStat.ExecDept.ID;
            this.cmbExecDept.Text = feeCodeStat.ExecDept.Name;
            this.cmbCenterStatCode.Tag = feeCodeStat.CenterStat;
            this.cmbValidState.Tag = ((int)feeCodeStat.ValidState).ToString();
            this.cmbValidState.Text = this.GetValidName(((int)feeCodeStat.ValidState).ToString());
            this.ckbContinue.Enabled = false;
            this.tbp_Main.Focus();
            this.txtFeeStatCode.Focus();
        }
        
        /// <summary>
        /// 增加规类
        /// </summary>
        protected virtual void Add()
        {
            this.txtReportCode.Text = feeCodeStat.ID;
            this.txtReportCode.Enabled = false;
            this.txtReportName.Text = feeCodeStat.Name;
            this.txtReportName.Enabled = false;
            //this.cmbReportType.Text = feeCodeStat.ReportType.Name;
            this.cmbReportType.Tag = feeCodeStat.ReportType.ID;
            this.cmbReportType.Enabled = false;
            this.cmbMinFee.Enabled = true;
            this.cmbMinFee.Text = string.Empty;
            this.cmbMinFee.Tag = string.Empty;
            this.txtFeeStatCode.Text = string.Empty;
            this.txtFeeStatName.Text = string.Empty;
            this.txtPrintOrder.Text = maxPrintOrder;
            this.cmbExecDept.Tag = string.Empty;
            this.cmbExecDept.Text = string.Empty;
            this.txtFeeStatName.Text = string.Empty;
            this.cmbCenterStatCode.Tag = string.Empty;
            this.cmbValidState.Tag = "1";
            this.cmbValidState.Text = "在用";
            this.cmbValidState.Enabled = true;

            if (this.cmbMinFee.Items.Count == 0)
            {
                this.ckbContinue.Checked = false;
            }
            else
            {
                this.ckbContinue.Checked = true;
            }
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        /// <returns>有效 True 无效 False</returns>
        protected virtual bool IsValid()
        {
            if (this.cmbMinFee.Text == string.Empty || this.cmbMinFee.Tag == null)
            {
                MessageBox.Show(Language.Msg("费用名称不能为空!"));
                this.cmbMinFee.Focus();

                return false;
            }
            if (this.txtFeeStatCode.Text == string.Empty || this.txtFeeStatCode.Text == null)
            {
                MessageBox.Show(Language.Msg("统计代码不空!"));
                this.txtFeeStatCode.Focus();

                return false;
            }
            else
            {
                // [2007/02/07] 新增加的代码,检查是否是数字
                //              不能直接通过MaxLength=2来做限制,因为数据库该字段的长度是两个字节
                //              如果将MaxLength设为2,那么可以输入两个汉字(4个字节),就会有问题
                for (int i = 0, j = this.txtFeeStatCode.Text.Length; i < j; i++)
                {
                    if (!char.IsDigit(this.txtFeeStatCode.Text[i]))
                    {
                        MessageBox.Show("统计代码必须是小于等于2的数字", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }
            if (this.txtFeeStatName.Text == string.Empty || this.txtFeeStatName.Text == null)
            {
                MessageBox.Show(Language.Msg("统计名称不空!"));
                this.txtFeeStatName.Focus();

                return false;
            }

            if (this.txtPrintOrder.Text == "0" || this.txtPrintOrder.Text == null || this.txtPrintOrder.Text == string.Empty)
            {
                MessageBox.Show(Language.Msg("打印顺序不能为空!"));
                this.txtPrintOrder.Focus();
                
                return false;
            }
            for (int i = 0, j = this.txtPrintOrder.Text.Length; i < j; i++)
            {
                if (!char.IsDigit(this.txtPrintOrder.Text, i))
                {
                    MessageBox.Show("打印顺序只能为数字，请重新输入！", "提示", MessageBoxButtons.OK);
                    txtPrintOrder.Focus();
                    txtPrintOrder.SelectAll();
                    return false;
                }
            }

            if (this.cmbValidState.Text == string.Empty || this.cmbValidState.Text == null)
            {
                MessageBox.Show("有效性标识不能为空!");
                this.cmbValidState.Focus();

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
                case "1":
                    name = "在用";
                    break;
                case "0":
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
            this.feeCodeStat.MinFee.ID = this.cmbMinFee.Tag.ToString();//最小费用
            this.feeCodeStat.MinFee.Name = this.cmbMinFee.Text.ToString();//最小费用名称

            this.feeCodeStat.StatCate.ID = this.txtFeeStatCode.Text;//统计大类
            this.feeCodeStat.StatCate.Name = this.txtFeeStatName.Text;//统计大类名称
            this.feeCodeStat.SortID = Neusoft.FrameWork.Function.NConvert.ToInt32(this.txtPrintOrder.Text);//打印顺序
            this.feeCodeStat.ExecDept.ID = this.cmbExecDept.Tag.ToString();//执行科室ID
            this.feeCodeStat.ExecDept.Name = this.cmbExecDept.Text.ToString();//执科科室名称
            this.feeCodeStat.ReportType.ID = this.cmbReportType.Tag.ToString();//附加码.
            this.feeCodeStat.CenterStat = this.cmbCenterStatCode.Tag.ToString();//中心代码
            this.feeCodeStat.ValidState = (Neusoft.HISFC.Models.Base.EnumValidState) NConvert.ToInt32(this.cmbValidState.Tag);//有效性标识

            try
            {
                //Neusoft.FrameWork.Management.Transaction t = new Transaction(this.feeCodeStatManager.Connection);
                Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
                //t.BeginTransaction();

                this.feeCodeStatManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                int returnValue = 0;

                if (this.saveType == EnumSaveTypes.Add)
                {
                    returnValue = this.feeCodeStatManager.InsertFeeCodeStat(this.feeCodeStat);
                }
                else 
                {
                    returnValue = this.feeCodeStatManager.UpdateFeeCodeStat(this.feeCodeStat);
                }

                if (returnValue <= 0) 
                {
                    //{27950423-3D3C-4ca6-882E-254D455EA2E3}
                    if (this.feeCodeStatManager.DBErrCode == 1)
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();
                        MessageBox.Show(Language.Msg("插入或更新统计大类信息出错!信息已存在"));
                    }
                    else
                    {
                        Neusoft.FrameWork.Management.PublicTrans.RollBack();

                        MessageBox.Show(Language.Msg("插入或更新统计大类信息出错!") + this.feeCodeStatManager.Err);

                    }

                   
                    return -1;
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();
                
                this.Save(feeCodeStat);

                if (!this.ckbContinue.Checked)
                {
                    this.ParentForm.Close();
                }
            }
            catch 
            {
                return -1;
            }
           
            return 1;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 根据传入参数初始化
        /// </summary>
        public void Init()
        {
            this.InitCmb();
            
            if (this.saveType == EnumSaveTypes.Add)
            {
                this.Add();
            }
            if (this.saveType == EnumSaveTypes.Modify)
            {
                this.Modify();
            }

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
            Modify
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
            //判断有效性
            if (!this.IsValid())
            {
                return;
            }
            if (this.Confirm() == 1)
            {
                MessageBox.Show("保存数据成功", "提示", MessageBoxButtons.OK);
                this.FindForm().Close();
            }
            else
            {
                //{27950423-3D3C-4ca6-882E-254D455EA2E3}
               // MessageBox.Show("保存数据失败", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 窗口关闭按钮点击事件
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

        /// <summary>
        /// 初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucFeeCodeStatModify_Load(object sender, EventArgs e)
        {
            this.Init();

            try
            {
                this.FindForm().Text = "费用归类";
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
    }
}

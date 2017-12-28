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

namespace Neusoft.HISFC.Components.Order.Controls
{
    /// <summary>
    /// [功能描述: 配液中心管理的说]<br></br>
    /// [创 建 者: dorian]<br></br>
    /// [创建时间: 2007-04]<br></br>
    /// 
    /// </summary>
    public partial class ucOrderCompound : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucOrderCompound()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Order.Order orderManager = new Neusoft.HISFC.BizLogic.Order.Order();

        /// <summary>
        /// 医嘱功能管理类
        /// </summary>
        private HISFC.Components.Order.Classes.Function orderFun = new HISFC.Components.Order.Classes.Function();

        /// <summary>
        /// 列表是否显示患者病区
        /// </summary>
        private bool isShowNurseCell = true;

        /// <summary>
        /// 配液信息检索追溯天数
        /// </summary>
        private int beforeDays = 1;

        /// <summary>
        /// 配液信息检索延后天数
        /// </summary>
        private int afterDays = 2;

        /// <summary>
        /// 当前操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = new Neusoft.FrameWork.Models.NeuObject();

        /// <summary>
        /// 是否打印同时进行保存
        /// </summary>
        private bool isPrintWithSave = false;

        /// <summary>
        /// 配液人员信息
        /// </summary>
        private Neusoft.HISFC.Models.Base.OperEnvironment compoundOper = null;

        /// <summary>
        /// 开始时间
        /// </summary>
        private DateTime dtBegin;

        /// <summary>
        /// 起始时间
        /// </summary>
        private DateTime dtEnd;

        /// <summary>
        /// 患者信息
        /// </summary>
        private System.Collections.Hashtable hsPatientInfo = new Hashtable();

        #endregion

        #region 属性

        /// <summary>
        /// 列表是否显示患者病区 True 显示病区列表 False 显示科室列表
        /// </summary>
        [Description("列表是否显示患者病区 True 显示病区列表 False 显示科室列表"),Category("设置"),DefaultValue(true)]
        public bool IsShowNurseCell
        {
            get
            {
                return this.isShowNurseCell;
            }
            set
            {
                this.isShowNurseCell = value;
            }
        }

        /// <summary>
        /// 配液信息检索追溯天数
        /// </summary>
        [Description("配液信息检索追溯天数"), Category("设置"), DefaultValue(1)]
        public int BeforeDays
        {
            get
            {
                return this.beforeDays;
            }
            set
            {
                this.beforeDays = value;
            }
        }

        /// <summary>
        /// 配液信息检索延后天数
        /// </summary>
        [Description("配液信息检索延后天数"),Category("设置"),DefaultValue(2)]
        public int AfterDays
        {
            get
            {
                return this.afterDays;
            }
            set
            {
                this.afterDays = value;
            }
        }

        /// <summary>
        /// 是否打印同时进行保存
        /// </summary>
        [Description("是否打印同时进行保存操作 更新配液执行信息"),Category("设置"),DefaultValue(false)]
        public bool IsPrintWithSave
        {
            get
            {
                return this.isPrintWithSave;
            }
            set
            {
                this.isPrintWithSave = value;
            }
        }            

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("日期", "时间段区间设定", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S设置, true, false, null);
            toolBarService.AddToolButton("全选", "全选", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q全选, true, false, null);
            toolBarService.AddToolButton("全不选", "全不选", Neusoft.FrameWork.WinForms.Classes.EnumImageList.Q清空, true, false, null);
            
            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "全选")
            {
                this.Check(true);
            }
            if (e.ClickedItem.Text == "全不选")
            {
                this.Check(false);
            }
            if (e.ClickedItem.Text == "日期")
            {
                this.ChooseTime();
            }

            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnQuery(object sender, object neuObject)
        {
            this.ShowCompounding();

            return base.OnQuery(sender, neuObject);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.SaveCompounding() == 1)
            {
                this.ShowCompounding();
            }

            return 1;
        }

        protected override int OnPrint(object sender, object neuObject)
        {
            if (this.IPrint != null)
            {
                this.IPrint.SetTitle(this.compoundOper,this.operDept);

                this.IPrint.SetExecOrder(this.GetCheckExecOrder(), this.hsPatientInfo);

                this.IPrint.Print();
            }
            // 打印处理
            if (this.isPrintWithSave)
            {
                this.SaveCompounding();
            }
            return 1;
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        protected int Init()
        {
            this.compoundOper = new Neusoft.HISFC.Models.Base.OperEnvironment();

            this.compoundOper.ID = this.orderManager.Operator.ID;
            this.compoundOper.Name = this.orderManager.Operator.Name;
            this.compoundOper.Dept = ((Neusoft.HISFC.Models.Base.Employee)this.orderManager.Operator).Dept;

            DateTime sysTime = this.orderManager.GetDateTimeFromSysDateTime();

            dtBegin = sysTime.AddDays(-this.beforeDays);
            dtEnd = sysTime.AddDays(this.afterDays);

            this.SetQueryTimeShow();

            this.InitDeptTree();

            this.InitPrintInterface();

            return 1;
        }

        /// <summary>
        /// 初始化树型列表
        /// </summary>
        /// <returns></returns>
        protected int InitDeptTree()
        {
            Neusoft.HISFC.BizProcess.Integrate.Manager deptManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            if (this.isShowNurseCell)
            {
                ArrayList alNurse = deptManager.GetDeptmentIn(Neusoft.HISFC.Models.Base.EnumDepartmentType.N);
                if (alNurse == null)
                {
                    MessageBox.Show(Language.Msg("显示病区列表发生错误"));
                    return -1;
                }

                return this.AddDataToTree(alNurse);
            }
            else
            {
                ArrayList alDept = deptManager.GetDeptmentIn(Neusoft.HISFC.Models.Base.EnumDepartmentType.I);
                if (alDept == null)
                {
                    MessageBox.Show(Language.Msg("显示科室列表发生错误"));
                    return -1;
                }

                return this.AddDataToTree(alDept);
            }            
        }

        /// <summary>
        /// 加载数据到Tree显示
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int AddDataToTree(ArrayList alData)
        {
            this.tvDeptTree.Nodes.Clear();

            TreeNode parentNode = new TreeNode("配液科室列表");
            parentNode.Tag = null;

            foreach (Neusoft.HISFC.Models.Base.Department deptInfo in alData)
            {
                TreeNode node = new TreeNode(deptInfo.Name);
                node.Tag = deptInfo;

                parentNode.Nodes.Add(node);
            }

            this.tvDeptTree.Nodes.Add(parentNode);

            this.tvDeptTree.ExpandAll();

            return 1;
        }

        #endregion

        #region 打印处理

        private Neusoft.HISFC.BizProcess.Interface.IPrintExecDrug IPrint = null;

        /// <summary>
        /// 打印接口初始化
        /// </summary>
        protected void InitPrintInterface()
        {
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(Language.Msg("正在加载打印接口信息.."));
            Application.DoEvents();

            try
            {
                object[] o = new object[] { };
                ////以后由维护界面获取类名称
                //System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", "Report.Order.ucDrugCompound", false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                //if (objHandel != null)
                //{
                //    object oLabel = objHandel.Unwrap();

                //    this.IPrint = oLabel as Neusoft.HISFC.BizProcess.Integrate.IPrintExecDrug;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.Msg(ex.Message));
            }
            finally
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断两行是否具有相同的组合号
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool IsSameCombo(int i, int j)
        {
            try
            {
                if (this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColComboNO].Text == this.neuSpread1_Sheet1.Cells[j, (int)ColumnSet.ColComboNO].Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置组合选中、不选中的处理
        /// </summary>
        /// <param name="iOriginalRow">当前选中行</param>
        private void SetComboCheck(int activeRow)
        {
            //选中/取消组中某条项目后 对组中其他项目同样选中/取消
            bool isCheck = NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[activeRow, (int)ColumnSet.ColCheck].Value);

            int privIndex = activeRow - 1;
            while (privIndex >= 0 && this.IsSameCombo(privIndex, activeRow))
            {
                this.neuSpread1_Sheet1.Cells[privIndex, (int)ColumnSet.ColCheck].Value = isCheck;

                privIndex = privIndex - 1;
            }

            int nextIndex = activeRow + 1;
            while (nextIndex < this.neuSpread1_Sheet1.Rows.Count && this.IsSameCombo(nextIndex, activeRow))
            {
                this.neuSpread1_Sheet1.Cells[nextIndex, (int)ColumnSet.ColCheck].Value = isCheck;

                nextIndex = nextIndex + 1;
            }
        }

        /// <summary>
        /// 获取当前选中的医嘱执行信息
        /// </summary>
        /// <returns></returns>
        private ArrayList GetCheckExecOrder()
        {
            ArrayList alExecOrder = new ArrayList();

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCheck].Value))
                {
                    alExecOrder.Add(this.neuSpread1_Sheet1.Rows[i].Tag);
                }
            }

            return alExecOrder;
        }

        /// <summary>
        /// 查询区间显示
        /// </summary>
        private void SetQueryTimeShow()
        {
            this.lbTimeInfo.Text = string.Format("查询区间:{0} － {1}", dtBegin.ToString(), dtEnd.ToString());
        }

        /// <summary>
        /// 弹出日期选择
        /// </summary>
        private void ChooseTime()
        {
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseDate(ref this.dtBegin, ref this.dtEnd) == 1)
            {
                this.SetQueryTimeShow();

                this.ShowCompounding();
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        protected void Clear()
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 全选/全不选
        /// </summary>
        /// <param name="isCheck">是否选中</param>
        protected void Check(bool isCheck)
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCheck].Value = isCheck;
            }
        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            bool isHaveCheck = false;
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCheck].Value))
                {
                    isHaveCheck = true;
                    break;
                }
            }

            if (!isHaveCheck)
            {
                MessageBox.Show(Language.Msg("请选择确认执行的配液信息"));
                return false;
            }

            return true;
        }

        /// <summary>
        /// 向Fp内加入信息
        /// </summary>
        /// <param name="execOrder">医嘱执行挡信息</param>
        /// <param name="iRowIndex">行索引</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDataToFp(Neusoft.HISFC.Models.Order.ExecOrder execOrder,int iRowIndex)
        {
            this.neuSpread1_Sheet1.Rows.Add(iRowIndex, 1);

            string patientName = "";
            if (this.hsPatientInfo.ContainsKey(execOrder.Order.Patient.ID))
            {
                Neusoft.HISFC.Models.RADT.PatientInfo patient = this.hsPatientInfo[execOrder.Order.Patient.ID] as Neusoft.HISFC.Models.RADT.PatientInfo;

                patientName = "[" + patient.PVisit.PatientLocation.Bed.ID + "]" + patient.Name;
            }
            else
            {
                Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();
                Neusoft.HISFC.Models.RADT.PatientInfo patient = radtIntegrate.GetPatientInfoByPatientNO(execOrder.Order.Patient.ID);

                if (patient == null)
                {
                    MessageBox.Show(Language.Msg("根据患者流水号获取患者信息发生错误") + radtIntegrate.Err);
                    return -1;
                }

                patientName = "[" + patient.PVisit.PatientLocation.Bed.ID + "]" + patient.Name;

                this.hsPatientInfo.Add(patient.ID, patient);
            }


            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColName].Text = patientName;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColCheck].Value = true;

            Neusoft.HISFC.Models.Pharmacy.Item item = ((Neusoft.HISFC.Models.Pharmacy.Item)execOrder.Order.Item);
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColTradeNameSpecs].Text = item.Name + "[" + item.Specs + "]";
            
            //组标记  ...                      
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColDoseonce].Text = execOrder.Order.DoseOnce.ToString();
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColFrequency].Text = execOrder.Order.Frequency.Name;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColUsage].Text = execOrder.Order.Usage.Name;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColQty].Text = execOrder.Order.Qty.ToString() + execOrder.Order.Unit;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColEmergency].Value = execOrder.Order.IsEmergency;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColRecipeDoc].Text = execOrder.Order.ReciptDoctor.Name;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColMemo].Text = execOrder.Order.Memo;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColSortID].Text = execOrder.Order.SortID.ToString();
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColExecID].Text = execOrder.ID;
            this.neuSpread1_Sheet1.Cells[iRowIndex, (int)ColumnSet.ColComboNO].Text = execOrder.Order.Combo.ID + execOrder.DateUse.ToString();

            this.neuSpread1_Sheet1.Rows[iRowIndex].Tag = execOrder;
            return 1;
        }

        /// <summary>
        /// 刷新显示科室待配液信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1 </returns>
        protected int ShowCompounding()
        {
            this.Clear();

            ArrayList al = this.orderManager.QueryExecOrderForCompound(this.isShowNurseCell, this.operDept.ID, this.dtBegin, this.dtEnd,this.ckExec.Checked);
            if (al == null)
            {
                MessageBox.Show(Language.Msg("待配液信息查询失败") + this.orderManager.Err);
                return -1;
            }

            int iRowIndex = 0;
            foreach (Neusoft.HISFC.Models.Order.ExecOrder execOrder in al)
            {
                this.AddDataToFp(execOrder, iRowIndex);

                iRowIndex++;
            }

            HISFC.Components.Order.Classes.Function.DrawCombo(this.neuSpread1_Sheet1, (int)ColumnSet.ColComboNO, (int)ColumnSet.ColComboFlag);            
            return 1;   
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        protected int SaveCompounding()
        {
            if (!this.IsValid())
            {
                return -1;
            }

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.orderManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Order.Compound compoundInfo = new Neusoft.HISFC.Models.Order.Compound();
            compoundInfo.IsExec = true;
            compoundInfo.CompoundOper = this.compoundOper;
            compoundInfo.CompoundOper.OperTime = this.orderManager.GetDateTimeFromSysDateTime();

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (!NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColCheck].Value))
                {
                    continue;
                }

                string execID = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColExecID].Text;

                if (this.orderManager.UpdateOrderCompound(execID, compoundInfo) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();;
                    MessageBox.Show(Language.Msg("更新医嘱配液信息发生错误 医嘱执行流水号:" + execID + "\n" + this.orderManager.Err));
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        #endregion

        private void tvDeptTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Clear();

            if (e.Node.Tag != null)
            {
                this.operDept = e.Node.Tag as Neusoft.FrameWork.Models.NeuObject;

                this.ShowCompounding();
            }
        }

        private void ckUnExec_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowCompounding();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
            base.OnLoad(e);
        }

        private void neuSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColCheck].Value))
            {
                this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColCheck].Value = false;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[e.Row, (int)ColumnSet.ColCheck].Value = true;
            }

            this.SetComboCheck(e.Row);
        }

        #region 列设置

        private enum ColumnSet
        {
            /// <summary>
            /// [床号]姓名
            /// </summary>
            ColName,
            /// <summary>
            /// 是否选中
            /// </summary>
            ColCheck,
            /// <summary>
            /// 商品名称[规格]
            /// </summary>
            ColTradeNameSpecs,
            /// <summary>
            /// 组标记
            /// </summary>
            ColComboFlag,
            /// <summary>
            /// 每次量
            /// </summary>
            ColDoseonce,
            /// <summary>
            /// 频次
            /// </summary>
            ColFrequency,
            /// <summary>
            /// 用法
            /// </summary>
            ColUsage,
            /// <summary>
            /// 数量
            /// </summary>
            ColQty,
            /// <summary>
            /// 加急
            /// </summary>
            ColEmergency,
            /// <summary>
            /// 开方医生
            /// </summary>
            ColRecipeDoc,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 顺序号
            /// </summary>
            ColSortID,
            /// <summary>
            /// 流水号
            /// </summary>
            ColExecID,
            /// <summary>
            /// 组合号
            /// </summary>
            ColComboNO
        }

        #endregion            
       
    }
}

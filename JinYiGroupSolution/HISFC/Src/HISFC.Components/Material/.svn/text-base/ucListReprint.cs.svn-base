using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;
using System.Collections;

namespace Neusoft.HISFC.Components.Material
{
    /// <summary>
    /// [功能描述: 物资单据补打]
    /// [创 建 者: yuyun]
    /// [创建时间: 2008-8-1]
    /// </summary>
    public partial class ucListReprint : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        #region 构造方法

        public ucListReprint()
        {
            InitializeComponent();
        }

        #endregion        

        #region 变量

        /// <summary>
        /// 物资库存业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Store matManager = new Neusoft.HISFC.BizLogic.Material.Store();

        /// <summary>
        /// 物资基础业务类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Material.Baseset baseManager = new Neusoft.HISFC.BizLogic.Material.Baseset();

        /// <summary>
        /// 物资入库单打印变量
        /// </summary>
        private Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint iInPrint = null;

        /// <summary>
        /// 入库单打印实例
        /// </summary>
        protected object inputInstance;

        /// <summary>
        /// 出库单打印实例
        /// </summary>
        protected object outputInstance;

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (this.DesignMode)
            {
                return;
            }

            this.dtpBeginTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(matManager.GetSysDateTime()).AddDays(-3);
            this.dtpEndTime.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime(matManager.GetSysDateTime());
            this.SetStorageList();
            this.cmbStorage.Text = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.Name;
            this.cmbStorage.Tag = ((Neusoft.HISFC.Models.Base.Employee)Neusoft.FrameWork.Management.Connection.Operator).Dept.ID;
            this.SetSheet();
        }

        /// <summary>
        /// 创建2个打印接口实例，根据需要选择打印入库单还是出库单
        /// </summary>
        protected virtual void SetPrintObject()
        {
            object[] o = new object[] { };

            try
            {
                //反射接口---ModifyBy zj--如果是没有配置打印接口则用默认的实现
                ////入出库报表
                //Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
                //string billValue = "Neusoft.DongGuan.Report.Material.ucMatInputBill";
                //string billValue1 = "Neusoft.DongGuan.Report.Material.ucMatOutputBill";
                //System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("DongGuan.Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                //System.Runtime.Remoting.ObjectHandle objHandel1 = System.Activator.CreateInstance("DongGuan.Report", billValue1, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);

                //inputInstance = objHandel.Unwrap();
                //outputInstance = objHandel1.Unwrap();
                //---改用接口反射方法
                //
                inputInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(Neusoft.HISFC.Components.Material.In.ucMatIn), typeof(Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint));
                if (inputInstance == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有配置物资入库单打印接口，采用默认实现！"));
                    string billValue = "Neusoft.Report.Material.ucMatInputBill";
                    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                    inputInstance = objHandel.Unwrap();
                }
                outputInstance = Neusoft.FrameWork.WinForms.Classes.UtilInterface.CreateObject(typeof(Neusoft.HISFC.Components.Material.Out.ucMatOut), typeof(Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint));
                if (outputInstance == null)
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("没有配置物资出库单打印接口，采用默认实现！"));
                    string billValue = "Neusoft.Report.Material.ucMatOutputBill";
                    System.Runtime.Remoting.ObjectHandle objHandel = System.Activator.CreateInstance("Report", billValue, false, System.Reflection.BindingFlags.CreateInstance, null, o, null, null, null);
                    outputInstance = objHandel.Unwrap();
                }
            }
            catch (System.TypeLoadException ex)
            {
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show(Language.Msg("命名空间无效\n" + ex.Message));

                return;
            }
        }

        /// <summary>
        /// 设置表格格式
        /// </summary>
        private void SetSheet()
        {

            #region 表格1格式设置

            this.neuSpread1_Sheet1.DefaultStyle.Locked = true;
            this.neuSpread1_Sheet1.RowCount = 0;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.ListNO].Label = "单号";
            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.ListNO].Width = 120F;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.InvoiceNO].Label = "发票号";
            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.InvoiceNO].Width = 120F;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.OperType].Label = "操作类型";
            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.OperType].Width = 80F;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.TargetDept].Label = "目标单位";
            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.TargetDept].Width = 120F;

            //this.neuSpread1_Sheet1.Columns[(int)ColSheet1.Operator].Label = "操作人";
            //this.neuSpread1_Sheet1.Columns[(int)ColSheet1.Operator].Width = 80F;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.OperDate].Label = "操作时间";
            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.OperDate].Width = 120F;

            this.neuSpread1_Sheet1.Columns[(int)ColSheet1.OperDate + 1, this.neuSpread1_Sheet1.ColumnCount - 1].Visible = false;

            #endregion

            #region 表格2格式设置

            this.neuSpread2_Sheet1.DefaultStyle.Locked = true;
            this.neuSpread2_Sheet1.RowCount = 0;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.ItemCode].Label = "项目编码";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.ItemCode].Width = 120F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.ItemName].Label = "项目名称";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.ItemName].Width = 120F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Specs].Label = "规格";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Specs].Width = 80F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Qty].Label = "数量";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Qty].Width = 120F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Unit].Label = "单位";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Unit].Width = 60F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Price].Label = "单价";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Price].Width = 80F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Cost].Label = "金额";
            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Cost].Width = 80F;

            this.neuSpread2_Sheet1.Columns[(int)ColSheet2.Cost + 1, this.neuSpread2_Sheet1.ColumnCount - 1].Visible = false;

            #endregion
        }

        /// <summary>
        /// 加载库房下拉列表
        /// </summary>
        private void SetStorageList()
        {
            ArrayList alStorage = this.baseManager.GetStorageInfo();

            if (alStorage == null || alStorage.Count <= 0)
            {
                MessageBox.Show("加载库房信息失败" + baseManager.Err);

                return;
            }
            this.cmbStorage.AddItems(alStorage);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            ArrayList alListInfo = new ArrayList();
            if (this.cmbStorage.Tag == null || string.IsNullOrEmpty(this.cmbStorage.Tag.ToString()))
            {
                MessageBox.Show("请选择库房！");

                return -1;
            }
            this.Clear();
            //判断是查找入库单还是出库单
            if (this.rbtInputList.Checked)
            {
                alListInfo = this.QueryInputList(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.cmbStorage.Tag.ToString());
            }
            else if (this.rbtOutputList.Checked)
            {
                alListInfo = this.QueryOutputList(this.dtpBeginTime.Value, this.dtpEndTime.Value, this.cmbStorage.Tag.ToString());
            }
            else
            {
                MessageBox.Show("请选择单据类型！");

                return -1;
            }

            if (alListInfo != null && alListInfo.Count > 0)
            {
                this.AddDataToSheet(alListInfo);
            }

            return base.OnQuery(sender, neuObject);
        }

        public override int Print(object sender, object neuObject)
        {
            if (this.neuSpread2_Sheet1.RowCount == 0)
            {
                MessageBox.Show("请双击选择要补打的单据");

                return -1;
            }
            //判断是入库单补打还是出库单补打
            if (this.neuSpread2_Sheet1.Cells[0,(int)ColSheet2.ItemCode].Tag.ToString() == "input")
            {
                Function.IPrint = inputInstance as Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint;
                List<Neusoft.HISFC.Models.Material.Input> list = new List<Neusoft.HISFC.Models.Material.Input>();
                foreach (FarPoint.Win.Spread.Row r in neuSpread2_Sheet1.Rows)
                {
                    Neusoft.HISFC.Models.Material.Input input = neuSpread2_Sheet1.Rows[r.Index].Tag as Neusoft.HISFC.Models.Material.Input;
                    list.Add(input);
                }
                Function.IPrint.SetData(list);
            }
            else
            {
                Function.IPrint = outputInstance as Neusoft.HISFC.BizProcess.Interface.Material.IBillPrint;
                List<Neusoft.HISFC.Models.Material.Output> list = new List<Neusoft.HISFC.Models.Material.Output>();
                foreach (FarPoint.Win.Spread.Row r in neuSpread2_Sheet1.Rows)
                {
                    Neusoft.HISFC.Models.Material.Output output = neuSpread2_Sheet1.Rows[r.Index].Tag as Neusoft.HISFC.Models.Material.Output;
                    list.Add(output);
                }
                Function.IPrint.SetData(list);
            }

            this.Clear();
            return 1;
            return base.Print(sender, neuObject);
        }

        /// <summary>
        /// 清除表格里的数据
        /// </summary>
        private void Clear()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
            this.neuSpread2_Sheet1.RowCount = 0;
        }

        /// <summary>
        /// 将查询到的单据加入表格中
        /// </summary>
        /// <param name="alListInfo"></param>
        private void AddDataToSheet(ArrayList alListInfo)
        {
            Neusoft.HISFC.BizLogic.Manager.Department deptManager = new Neusoft.HISFC.BizLogic.Manager.Department();
            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            foreach (object obj in alListInfo)
            {
                if (this.rbtInputList.Checked)
                {
                    Neusoft.HISFC.Models.Material.Input input = obj as Neusoft.HISFC.Models.Material.Input;

                    this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.ListNO].Text = input.InListNO;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.InvoiceNO].Text = input.InvoiceNO;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.OperType].Text = input.StoreBase.Extend;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.TargetDept].Text = input.StoreBase.TargetDept.ID;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.OperDate].Text = input.StoreBase.Operation.Oper.OperTime.ToString();

                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.ListNO].Tag = cmbStorage.Tag.ToString();
                    this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.RowCount - 1].Tag = "input";
                }
                else
                {
                    Neusoft.HISFC.Models.Material.Output output = obj as Neusoft.HISFC.Models.Material.Output;

                    this.neuSpread1_Sheet1.AddRows(this.neuSpread1_Sheet1.RowCount, 1);
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.ListNO].Text = output.OutListNO;
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.InvoiceNO].Text = "";
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.OperType].Text = output.StoreBase.Extend;

                    Neusoft.HISFC.Models.Base.Department dept = deptManager.GetDeptmentById(output.StoreBase.TargetDept.ID);
                    if (dept != null)
                    {
                        this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.TargetDept].Text = dept.Name;
                    }
                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.OperDate].Text = output.StoreBase.Operation.Oper.OperTime.ToString();

                    this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, (int)ColSheet1.ListNO].Tag = cmbStorage.Tag.ToString();
                    this.neuSpread1_Sheet1.Rows[this.neuSpread1_Sheet1.RowCount - 1].Tag = "output";
                }
            }
        }

        /// <summary>
        /// 查找出库单
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="storageID">执行库房</param>
        private ArrayList QueryOutputList(DateTime beginTime, DateTime endTime, string storageID)
        {
            ArrayList al = new ArrayList();
            if (this.matManager.QueryOutputListInfoByStorageAndDate(beginTime, endTime, storageID, ref al) == -1)
            {
                MessageBox.Show("查找出库单信息失败" + matManager.Err);

                return null;
            }
            return al;
        }

        /// <summary>
        /// 查找入库单
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="storageID">执行库房</param>
        private ArrayList QueryInputList(DateTime beginTime, DateTime endTime, string storageID)
        {
            ArrayList al = new ArrayList();
            if (this.matManager.QueryInputListInfoByStorageAndDate(beginTime, endTime, storageID, ref al) == -1)
            {
                MessageBox.Show("查找入库单信息失败" + matManager.Err);

                return null;
            }
            return al;
        }

        /// <summary>
        /// 将查询到的出库记录插入到第二个表格里
        /// </summary>
        /// <param name="alInputInfo"></param>
        private void AddOutputToSheet2(List<Neusoft.HISFC.Models.Material.Output> alInputInfo)
        {
            foreach (Neusoft.HISFC.Models.Material.Output output in alInputInfo)
            {
                this.neuSpread2_Sheet1.AddRows(this.neuSpread2_Sheet1.RowCount, 1);
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemCode].Text = output.StoreBase.Item.ID;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemName].Text = output.StoreBase.Item.Name;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Specs].Text = output.StoreBase.Item.Specs;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Qty].Text = output.StoreBase.Quantity.ToString();
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Unit].Text = output.StoreBase.Item.MinUnit;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Price].Text = output.StoreBase.PriceCollection.PurchasePrice.ToString();

                decimal cost = output.StoreBase.PriceCollection.PurchasePrice * output.StoreBase.Quantity;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Cost].Text = cost.ToString();

                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemCode].Tag = "output";
                this.neuSpread2_Sheet1.Rows[this.neuSpread2_Sheet1.RowCount - 1].Tag = output;
            }
        }

        /// <summary>
        /// 将查询到的入库记录插入到第二个表格里
        /// </summary>
        /// <param name="alInputInfo"></param>
        private void AddInputToSheet2(ArrayList alInputInfo)
        {
            foreach (Neusoft.HISFC.Models.Material.Input input in alInputInfo)
            {
                this.neuSpread2_Sheet1.AddRows(this.neuSpread2_Sheet1.RowCount, 1);
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemCode].Text = input.StoreBase.Item.ID;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemName].Text = input.StoreBase.Item.Name;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Specs].Text = input.StoreBase.Item.Specs;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Qty].Text = input.StoreBase.Quantity.ToString();
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Unit].Text = input.StoreBase.Item.MinUnit;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Price].Text = input.StoreBase.PriceCollection.PurchasePrice.ToString();
                
                decimal cost = input.StoreBase.PriceCollection.PurchasePrice * input.StoreBase.Quantity;
                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.Cost].Text = cost.ToString();

                this.neuSpread2_Sheet1.Cells[this.neuSpread2_Sheet1.RowCount - 1, (int)ColSheet2.ItemCode].Tag = "input";
                this.neuSpread2_Sheet1.Rows[this.neuSpread2_Sheet1.RowCount - 1].Tag = input;
            }
        }

        /// <summary>
        /// 根据出库单号、出库科室查询出库记录
        /// </summary>
        /// <param name="listNO"></param>
        /// <param name="deptID"></param>
        private List<Neusoft.HISFC.Models.Material.Output> QueryOutputByListNO(string listNO, string deptID)
        {
            return matManager.QueryOutputByListNO(deptID, listNO);
        }

        /// <summary>
        /// 根据入库单号、入库科室查询入库记录
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        private ArrayList QueryInputByListNO(string listNO, string deptID)
        {
            return matManager.QueryInputDetailByListNO(deptID, listNO);
        } 

        #endregion

        #region 事件

        private void ucListReprint_Load(object sender, EventArgs e)
        {
            this.Init();
            this.SetPrintObject();
        }        

        /// <summary>
        /// 双击事件 查询选中行的入出库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.neuSpread2_Sheet1.RowCount = 0;
            ArrayList alInputInfo = new ArrayList();

            if (neuSpread1_Sheet1.Rows[neuSpread1_Sheet1.ActiveRowIndex].Tag.ToString() == "input")
            {
                alInputInfo = this.QueryInputByListNO(neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, (int)ColSheet1.ListNO].Text, neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, (int)ColSheet1.ListNO].Tag.ToString());
                if (alInputInfo != null && alInputInfo.Count > 0)
                {
                    this.AddInputToSheet2(alInputInfo);
                }
            }
            else
            {
                List<Neusoft.HISFC.Models.Material.Output> outputList = new List<Neusoft.HISFC.Models.Material.Output>();
                outputList = this.QueryOutputByListNO(neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, (int)ColSheet1.ListNO].Text, neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, (int)ColSheet1.ListNO].Tag.ToString());
                if (outputList != null && outputList.Count > 0)
                {
                    this.AddOutputToSheet2(outputList);
                }
            }
        } 
        #endregion

        #region 列枚举

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColSheet1
        {
            /// <summary>
            /// 单号
            /// </summary>
            ListNO,
            /// <summary>
            /// 发票号
            /// </summary>
            InvoiceNO,
            /// <summary>
            /// 类型
            /// </summary>
            OperType,
            /// <summary>
            /// 目标单位
            /// </summary>
            TargetDept,
            ///// <summary>
            ///// 操作员
            ///// </summary>
            //Operator,
            /// <summary>
            /// 操作时间
            /// </summary>
            OperDate
        }
        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColSheet2
        {
            /// <summary>
            /// 项目编码
            /// </summary>
            ItemCode,
            /// <summary>
            /// 项目名称
            /// </summary>
            ItemName,
            /// <summary>
            /// 规格
            /// </summary>
            Specs,
            /// <summary>
            /// 数量
            /// </summary>
            Qty,
            /// <summary>
            /// 单位
            /// </summary>
            Unit,
            /// <summary>
            /// 单价
            /// </summary>
            Price,
            /// <summary>
            /// 金额
            /// </summary>
            Cost,
        }

        #endregion

    }
}

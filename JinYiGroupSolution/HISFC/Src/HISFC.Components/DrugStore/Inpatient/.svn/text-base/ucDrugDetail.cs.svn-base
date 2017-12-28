using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 摆药明细显示控件]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2006-11]<br></br>
    /// </summary>
    public partial class ucDrugDetail : ucDrugBase, Neusoft.HISFC.BizProcess.Interface.Pharmacy.IInpatientDrug
    {
        public ucDrugDetail()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                try
                {
                    this.Init();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("初始化失败! " + ex.Message);
                }
            }
        }

        #region 域变量

        /// <summary>
        /// 根据医嘱类型编码检索医嘱类型名称
        /// </summary>
        protected Neusoft.FrameWork.Public.ObjectHelper orderTypeHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        /// <summary>
        /// 科室汇总时药品数据列表
        /// </summary>
        private ArrayList deptDrugInfo = new ArrayList();

        /// <summary>
        /// 科室汇总时药品数据总量
        /// </summary>
        private ArrayList deptDrugNum = new ArrayList();

        /// <summary>
        /// 本次显示的数据
        /// </summary>		
        private ArrayList alApplyOutInfo = new ArrayList();

        /// <summary>
        /// 存储本次处方号
        /// </summary>
        private ArrayList alBillCode = new ArrayList();

        /// <summary>
        /// 是否清空单据号(处方号)显示
        /// </summary>
        private bool isBillCodeClear = true;

        /// <summary>
        /// 摆药通知信息
        /// </summary>
        private Neusoft.HISFC.Models.Pharmacy.DrugBillClass myDrugBillClass = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();

        /// <summary>
        /// 全选或全不选时是否只处理选择的行
        /// </summary>
        private bool isCheckSelect = false;

        /// <summary>
        /// 对于摆药明细显示时 是否显示选中列
        /// </summary>
        private bool isShowCheckColumn = true;

        /// <summary>
        /// 摆药单类型集合
        /// </summary>
        private System.Collections.Hashtable hsDrugBillClass = new Hashtable();

        /// <summary>
        /// 是否增加了摆药单显示控件
        /// </summary>
        private bool isAddDrugBillControl = false;

        /// <summary>
        /// 患者帮助类
        /// </summary>
        private System.Collections.Hashtable hsPerson = new Hashtable();
        #endregion

        #region 属性

        /// <summary>
        /// 是否显示要打印的摆药单
        /// </summary>
        [Description("是否预览显示要打印的摆药单"), Category("设置"), DefaultValue(true)]
        public bool IsShowBillPreview
        {
            get
            {
                return this.tbDrugDetail.TabPages.Contains(this.tpDrugBill);
            }
            set
            {
                if (value)
                {
                    if (!this.tbDrugDetail.TabPages.Contains(this.tpDrugBill))
                    {
                        this.tbDrugDetail.TabPages.Insert(0, this.tpDrugBill);

                        this.tbDrugDetail.SelectTab(this.tpDrugBill);
                    }
                }
                if (!value)
                {
                    if (this.tbDrugDetail.TabPages.Contains(this.tpDrugBill))
                    {
                        this.tbDrugDetail.TabPages.Remove(this.tpDrugBill);
                    }
                }
            }
        }

        /// <summary>
        /// 是否显示要取/发药汇总
        /// </summary>
        [Description("是否显示本单据内患者发药汇总信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowPatientTot
        {
            get
            {
                return this.tbDrugDetail.TabPages.Contains(this.tpPatientMerge);
            }
            set
            {
                if (value)
                {
                    if (!this.tbDrugDetail.TabPages.Contains(this.tpPatientMerge))
                    {
                        this.tbDrugDetail.TabPages.Add(tpPatientMerge);
                    }
                }
                else
                {
                    if (this.tbDrugDetail.TabPages.Contains(this.tpPatientMerge))
                    {
                        this.tbDrugDetail.TabPages.Remove(tpPatientMerge);
                    }
                }
            }
        }

        /// <summary>
        /// 是否显示科室汇总
        /// </summary>
        [Description("是否显示本单据的科室汇总发药信息"), Category("设置"), DefaultValue(true)]
        public bool IsShowDeptTot
        {
            get
            {
                return this.tbDrugDetail.TabPages.Contains(this.tpDeptMerge);
            }
            set
            {
                if (value)
                {
                    if (!this.tbDrugDetail.TabPages.Contains(this.tpDeptMerge))
                    {
                        this.tbDrugDetail.TabPages.Add(tpDeptMerge);
                    }
                }
                else
                {
                    if (this.tbDrugDetail.TabPages.Contains(this.tpDeptMerge))
                    {
                        this.tbDrugDetail.TabPages.Remove(tpDeptMerge);
                    }
                }
            }
        }

        /// <summary>
        /// 是否可以通过输入摆药量自动计算摆药记录
        /// </summary>
        [Description("是否可以输入摆药量后自动选定摆药记录"), Category("设置"), DefaultValue(true)]
        public bool IsAutoCheck
        {
            get
            {
                return this.neuSpread3_DeptDetailSheet.Columns.Get(4).Visible;
            }
            set
            {
                this.neuSpread3_DeptDetailSheet.Columns[4].Visible = value;
            }
        }

        /// <summary>
        /// 是否显示顶部panel  按方号过滤
        /// </summary>
        [Description("是否允许显示退药单号过滤框"), Category("设置"), DefaultValue(false)]
        public bool IsFilterBillCode
        {
            get
            {
                return this.panelTop.Visible;
            }
            set
            {
                this.panelTop.Visible = value;
            }
        }

        /// <summary>
        /// 对于摆药明细显示时 是否显示选中列
        /// </summary>
        [Description("对于摆药明细显示时 是否显示选中列"), Category("设置"), DefaultValue(false)]
        public bool IsShowCheckColumn
        {
            get
            {
                return this.isShowCheckColumn;
            }
            set
            {
                this.neuSpread1_DetailSheet.Columns[2].Visible = value;

                this.isShowCheckColumn = value;
            }
        }

        /// <summary>
        /// 全选或全不选时是否只处理选择的行
        /// </summary>
        [Description("全选或全不选时是否只处理选择的行"), Category("设置"), DefaultValue(false)]
        public bool CheckSelect
        {
            get
            {
                return this.isCheckSelect;
            }
            set
            {
                this.isCheckSelect = value;
            }
        }

        /// <summary>
        /// 是否允许对行进行多选 处于多选状态时不能对行进行选中/不选中操作
        /// </summary>
        [Description("是否允许对行进行多选 处于多选状态时不能对行进行选中/不选中操作"), Category("设置"), DefaultValue(false)]
        public bool AllowMultiSelect
        {
            get
            {
                if (this.neuSpread1_DetailSheet.OperationMode == FarPoint.Win.Spread.OperationMode.RowMode)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value)
                    this.neuSpread1_DetailSheet.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
                else
                    this.neuSpread1_DetailSheet.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            }
        }

        #endregion

        #region 摆药单控件

        /// <summary>
        /// 添加摆药单打印显示控件
        /// </summary>
        /// <param name="ucBill">控件名称</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public virtual int AddDrugBill(object ucBill, bool isAddToContainer)
        {
            if (isAddToContainer)
            {
                Function.ucDrugBill = ucBill as Neusoft.FrameWork.WinForms.Controls.ucBaseControl;
                if (Function.ucDrugBill == null)
                {
                    MessageBox.Show("摆药单控件设置错误 需继承基类ucBaseControl");
                    return -1;
                }

                Function.ucDrugBill.Dock = DockStyle.Fill;
                this.tpDrugBill.Controls.Clear();
                this.tpDrugBill.Controls.Add(Function.ucDrugBill);
            }

            Function.IDrugPrint = ucBill as Neusoft.HISFC.BizProcess.Interface.Pharmacy.IDrugPrint;
            if (Function.IDrugPrint == null)
            {
                MessageBox.Show("摆药单控件实现错误 需实现基类IDrugPrint接口");
                return -1;
            }

            this.isAddDrugBillControl = isAddToContainer;

            return 1;
        }

        public virtual int AddDrugBill(object ucBill)
        {
            return AddDrugBill(ucBill, true);
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
            this.InitControlParam();

            //取医嘱类型，用于将编码转换成名称
            Neusoft.HISFC.BizLogic.Manager.OrderType orderManager = new Neusoft.HISFC.BizLogic.Manager.OrderType();
            this.orderTypeHelper.ArrayObject = orderManager.GetList();

            //合并重复值的列
            this.neuSpread1_DetailSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);
            this.neuSpread1_DetailSheet.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always);

            this.neuSpread2_PatientDetailSheet.SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);
            this.neuSpread2_PatientDetailSheet.SetColumnMerge(1, FarPoint.Win.Spread.Model.MergePolicy.Always);


            this.neuSpread1_DetailSheet.SetColumnAllowAutoSort(-1, false);

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType numCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.NumCellType();
            numCellType.DecimalPlaces = 0;
            this.neuSpread3_DeptDetailSheet.Columns[4].CellType = numCellType;

            Neusoft.HISFC.BizLogic.Pharmacy.DrugStore drugStoreManager = new Neusoft.HISFC.BizLogic.Pharmacy.DrugStore();
            ArrayList alDrugBillClass = drugStoreManager.QueryDrugBillClassList();
            if (alDrugBillClass == null)
            {
                MessageBox.Show(Language.Msg(""));
                return;
            }

            foreach (Neusoft.HISFC.Models.Pharmacy.DrugBillClass info in alDrugBillClass)
            {
                this.hsDrugBillClass.Add(info.ID, info.PrintType);
            }

            //集中发送方式选择摆药导致打印单子混乱，先封掉 {C388ED06-DFF8-4a9a-9359-1929F95CEEB7} wbo 2010-11-27
            this.neuSpread1_DetailSheet.Columns[2].Locked = true;
        }

        /// <summary>
        /// 初始化控制参数
        /// </summary>
        private void InitControlParam()
        {
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlParamIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();

            //屏蔽作废参数设置信息
            //this.IsShowBillPreview = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Priview_Bill, true, true);

            this.IsShowPatientTot = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Show_PatientTot, true, false);
            this.IsShowDeptTot = ctrlParamIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Show_DeptTot, true, true);

        }

        /// <summary>
        /// 用于摆药核准时 显示出库申请数据 
        /// </summary>
        /// <param name="arrayApplyOut">出库申请数据</param>
        /// <param name="drugBillClass">摆药通知信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        public void ShowData(ArrayList arrayApplyOut, Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClass)
        {
            this.myDrugBillClass = drugBillClass;

            this.ShowData(arrayApplyOut);

            //显示摆药单
            if (this.IsShowBillPreview && Function.IDrugPrint != null)
            {
                Function.IDrugPrint.AddAllData(this.GetCheckData(), this.myDrugBillClass);
            }
        }

        /// <summary>
        /// 根据出库申请数据 设置退药单方号显示
        /// </summary>
        /// <param name="applyOut">出库申请数据</param>
        private void SetBillCodeData(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            if (this.isBillCodeClear && this.IsFilterBillCode)
            {
                bool isNew = true;
                for (int i = 0; i < alBillCode.Count; i++)
                {
                    if (alBillCode[i] as string == applyOut.BillNO)
                    {
                        isNew = false;
                        break;
                    }
                }
                if (isNew)
                {
                    alBillCode.Add(applyOut.BillNO);
                    this.cmbBillCode.Items.Add(applyOut.BillNO);
                }
            }
        }

        /// <summary>
        /// 向FpDetail加入数据 显示摆药明细信息
        /// </summary>
        /// <param name="applyOut">出库申请信息</param>
        /// <param name="i"></param>
        protected void AddDataToFpDetail(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, int iIndex)
        {
            if (applyOut.User01.Length > 4)
                applyOut.User01 = applyOut.User01.Substring(4);
            this.neuSpread1_DetailSheet.Cells[iIndex, 0].Value = applyOut.User01;  //床号
            this.neuSpread1_DetailSheet.Cells[iIndex, 1].Value = applyOut.User02;  //姓名
            this.neuSpread1_DetailSheet.Cells[iIndex, 2].Value = true;
            this.neuSpread1_DetailSheet.Cells[iIndex, 3].Value = applyOut.Item.Name + "[" + applyOut.Item.Specs + "]";
            this.neuSpread1_DetailSheet.Cells[iIndex, 4].Value = applyOut.Item.PriceCollection.RetailPrice;
            this.neuSpread1_DetailSheet.Cells[iIndex, 5].Value = applyOut.DoseOnce;
            this.neuSpread1_DetailSheet.Cells[iIndex, 6].Value = applyOut.Item.DoseUnit;
            this.neuSpread1_DetailSheet.Cells[iIndex, 7].Value = applyOut.Operation.ApplyQty * applyOut.Days;
            this.neuSpread1_DetailSheet.Cells[iIndex, 8].Value = applyOut.Item.MinUnit;
            this.neuSpread1_DetailSheet.Cells[iIndex, 9].Value = applyOut.Frequency.ID;
            this.neuSpread1_DetailSheet.Cells[iIndex, 10].Value = applyOut.Usage.Name;
            this.neuSpread1_DetailSheet.Cells[iIndex, 11].Value = applyOut.Operation.ApplyOper.OperTime.ToString();

            if (this.hsPerson.ContainsKey( applyOut.Operation.ExamOper.ID ) == false)       //不包含人员编码/姓名信息 重新获取
            {
                Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();
                Neusoft.HISFC.Models.Base.Employee person = managerIntegrate.GetEmployeeInfo( applyOut.Operation.ExamOper.ID );
                if (person != null)
                {
                    applyOut.Operation.ExamOper.Name = person.Name;
                    this.hsPerson.Add( applyOut.Operation.ExamOper.ID, person.Name );
                }
            }
            else
            {
                applyOut.Operation.ExamOper.Name = this.hsPerson[applyOut.Operation.ExamOper.ID].ToString();
            }

            this.neuSpread1_DetailSheet.Cells[iIndex, 12].Value = applyOut.Operation.ExamOper.Name;

            if (applyOut.Operation.ExamOper.OperTime != System.DateTime.MinValue)
                this.neuSpread1_DetailSheet.Cells[iIndex, 13].Value = applyOut.Operation.ExamOper.OperTime.ToString();

            this.neuSpread1_DetailSheet.Cells[iIndex, 14].Value = this.orderTypeHelper.GetName(applyOut.OrderType.ID);
            this.neuSpread1_DetailSheet.Rows[iIndex].Tag = applyOut;
            //如果摆药单已作废或者不摆药，则用红色特殊显示此行
            if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid || applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
            {
                this.neuSpread1_DetailSheet.Rows[iIndex].ForeColor = System.Drawing.Color.Red;
            }
        }

        #region 摆药汇总显示

        /// <summary>
        /// 合并汇总计算患者药品总数量 金额
        /// </summary>
        public virtual void MergePatientData()
        {
            this.neuSpread2_PatientDetailSheet.Rows.Count = 0;
            string bed_Name = "";		//患者床号+ 姓名 唯一
            string drugCode = "";		//患者药品 
            decimal drugNum = 0;		//患者药品汇总 
            try
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut;
                int iRow = 0;
                Neusoft.HISFC.Models.Pharmacy.ApplyOut privApplyOut = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();

                for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
                {
                    if (this.neuSpread1_DetailSheet.Cells[i, 2].Value != null && this.neuSpread1_DetailSheet.Cells[i, 2].Value.ToString() == "True")
                    {
                        applyOut = this.neuSpread1_DetailSheet.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                        if (applyOut.User01 + applyOut.User02 != bed_Name) //初次 不等于床号+姓名
                        {
                            #region 不同患者

                            if (bed_Name != "")
                            {
                                this.neuSpread2_PatientDetailSheet.Rows.Add(iRow, 1);
                                this.AddDataToFpPatientMerge(iRow, privApplyOut, drugNum);
                                iRow = iRow + 1;
                                drugNum = 0;
                            }
                            drugNum = drugNum + applyOut.Operation.ApplyQty * applyOut.Days;
                            drugCode = applyOut.Item.ID;
                            bed_Name = applyOut.User01 + applyOut.User02;
                            privApplyOut = applyOut;
                            if (i == this.neuSpread1_DetailSheet.Rows.Count - 1)
                            {
                                this.neuSpread2_PatientDetailSheet.Rows.Add(iRow, 1);
                                this.AddDataToFpPatientMerge(iRow, applyOut, drugNum);
                                iRow = iRow + 1;
                            }

                            #endregion
                        }
                        else										//相同患者 
                        {
                            if (applyOut.Item.ID == drugCode)			//相同药品
                            {
                                #region 相同患者相同药品

                                drugNum = drugNum + applyOut.Operation.ApplyQty * applyOut.Days;	//汇总药品数量
                                if (i == this.neuSpread1_DetailSheet.Rows.Count - 1)
                                {
                                    this.neuSpread2_PatientDetailSheet.Rows.Add(iRow, 1);
                                    this.AddDataToFpPatientMerge(iRow, applyOut, drugNum);
                                    iRow = iRow + 1;
                                }

                                #endregion
                            }
                            else									//不同药品
                            {
                                #region 相同患者不同药品

                                this.neuSpread2_PatientDetailSheet.Rows.Add(iRow, 1);
                                this.AddDataToFpPatientMerge(iRow, privApplyOut, drugNum);
                                iRow = iRow + 1;
                                drugNum = applyOut.Operation.ApplyQty * applyOut.Days;	//汇总药品数量
                                privApplyOut = applyOut;
                                drugCode = applyOut.Item.ID;

                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 向FpPatientMerge内加入数据 显示患者摆药汇总信息
        /// </summary>
        /// <param name="iIndex">需加入行索引</param>
        /// <param name="applyOut">发药申请信息</param>
        /// <param name="drugTot">汇总数量</param>
        protected void AddDataToFpPatientMerge(int iIndex, Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal drugTot)
        {
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 0].Value = applyOut.User01;  //床号
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 1].Value = applyOut.User02;  //姓名
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 2].Value = applyOut.Item.Name + "[" + applyOut.Item.Specs + "]";
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 3].Value = applyOut.Item.PriceCollection.RetailPrice;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 4].Value = applyOut.DoseOnce;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 5].Value = applyOut.Item.DoseUnit;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 6].Value = drugTot;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 7].Value = applyOut.Item.MinUnit;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 8].Value = applyOut.Frequency.Name;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 9].Value = applyOut.Usage.Name;
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 10].Value = applyOut.Operation.ApplyOper.OperTime.ToString();
            this.neuSpread2_PatientDetailSheet.Cells[iIndex, 11].Value = this.orderTypeHelper.GetName(applyOut.OrderType.ID);
            this.neuSpread2_PatientDetailSheet.Rows[iIndex].Tag = applyOut;
            //如果摆药单已作废或者不摆药，则用红色特殊显示此行
            if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Invalid || applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Ignore)
            {
                this.neuSpread2_PatientDetailSheet.Rows[iIndex].ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// 合并汇总计算科室药品总数量 金额
        /// </summary>
        public virtual void MergeDeptData()
        {
            this.neuSpread3_DeptDetailSheet.Rows.Count = 0;
            this.deptDrugInfo = new ArrayList();
            this.deptDrugNum = new ArrayList();
            try
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut info;
                Neusoft.HISFC.Models.Pharmacy.ApplyOut privInfo = new Neusoft.HISFC.Models.Pharmacy.ApplyOut();

                for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
                {
                    if (this.neuSpread1_DetailSheet.Cells[i, 2].Value != null && this.neuSpread1_DetailSheet.Cells[i, 2].Value.ToString() == "True")
                    {
                        info = this.neuSpread1_DetailSheet.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                        if (info == null) continue;
                        bool isFind = false;
                        for (int j = 0; j < this.deptDrugInfo.Count; j++)
                        {
                            Neusoft.HISFC.Models.Pharmacy.ApplyOut temp = this.deptDrugInfo[j] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                            if (temp.Item.ID == info.Item.ID)
                            {
                                this.deptDrugNum[j] = (decimal)this.deptDrugNum[j] + info.Operation.ApplyQty * info.Days;
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            this.deptDrugInfo.Add(info);
                            this.deptDrugNum.Add(info.Operation.ApplyQty * info.Days);
                        }

                    }
                }
                for (int i = 0; i < this.deptDrugInfo.Count; i++)
                {
                    this.neuSpread3_DeptDetailSheet.Rows.Add(i, 1);
                    this.AddTotDataToFpDeptMerge(i, this.deptDrugInfo[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut, (decimal)this.deptDrugNum[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 向FpPatientMerge内加入数据 显示科室摆药汇总信息
        /// </summary>
        /// <param name="iIndex">需加入行索引</param>
        /// <param name="applyOut">发药申请信息</param>
        /// <param name="drugTot">汇总数量</param>
        protected void AddTotDataToFpDeptMerge(int iIndex, Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut, decimal drugNum)
        {
            this.neuSpread3_DeptDetailSheet.Cells[iIndex, 0].Value = applyOut.Item.Name + "[" + applyOut.Item.Specs + "]";
            this.neuSpread3_DeptDetailSheet.Cells[iIndex, 1].Value = applyOut.Item.PriceCollection.RetailPrice;
            this.neuSpread3_DeptDetailSheet.Cells[iIndex, 2].Value = drugNum;
            this.neuSpread3_DeptDetailSheet.Cells[iIndex, 3].Value = applyOut.Item.MinUnit;
            this.neuSpread3_DeptDetailSheet.Rows[iIndex].Tag = applyOut;
        }

        #endregion

        /// <summary>
        /// 根据所输入的摆药量自动选中需摆药数据
        /// </summary>
        /// <returns>计算成功返回 Ture 失败返回 False</returns>
        public bool AutoSetCheck()
        {

            #region 判断用户输入是否正确

            this.neuSpread1_DetailSheet.SortRows(7, false, false);

            for (int i = 0; i < this.neuSpread3_DeptDetailSheet.Rows.Count; i++)
            {
                //输入错误的摆药数量后，在输入新数量会弹出错误提示。
                //判断的摆药量与实际勾选量之间的差额。与界面显示不同
                //if ((decimal)this.deptDrugNum[i] < NConvert.ToDecimal(this.neuSpread3_DeptDetailSheet.Cells[i, 4].Text))
                //{
                //    MessageBox.Show("第" + (i + 1).ToString() + "行 药品 摆药量应小于等于于总量");
                //    return false;
                //}
                this.deptDrugNum[i] = NConvert.ToDecimal(this.neuSpread3_DeptDetailSheet.Cells[i, 4].Text);
            }

            #endregion

            this.CheckNone();

            for (int i = 0; i < this.deptDrugInfo.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut info = this.deptDrugInfo[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                int privI = 0;
                for (int j = 0; j < this.neuSpread1_DetailSheet.Rows.Count; j++)
                {
                    #region 遍历摆药明细
                    Neusoft.HISFC.Models.Pharmacy.ApplyOut temp = this.neuSpread1_DetailSheet.Rows[j].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                    if ((decimal)this.deptDrugNum[i] == 0)
                        break;
                    if (temp.Item.ID == info.Item.ID)
                    {
                        if ((decimal)this.deptDrugNum[i] >= temp.Operation.ApplyQty * temp.Days)
                        {
                            this.deptDrugNum[i] = (decimal)this.deptDrugNum[i] - temp.Operation.ApplyQty * temp.Days;
                            this.neuSpread1_DetailSheet.Cells[j, 2].Value = true;
                            privI = j;

                            if (j == this.neuSpread1_DetailSheet.Rows.Count - 1) break;

                            Neusoft.HISFC.Models.Pharmacy.ApplyOut tempObj = this.neuSpread1_DetailSheet.Rows[j + 1].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                            if ((decimal)this.deptDrugNum[i] == 0) break;
                            if ((decimal)this.deptDrugNum[i] < tempObj.Operation.ApplyQty * tempObj.Days)
                            {
                                bool isFind = false;
                                for (int k = j + 1; k < this.neuSpread1_DetailSheet.Rows.Count; k++)
                                {
                                    Neusoft.HISFC.Models.Pharmacy.ApplyOut obj = this.neuSpread1_DetailSheet.Rows[k].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                                    if (info.Item.ID != obj.Item.ID)
                                        continue;
                                    if ((decimal)this.deptDrugNum[i] == obj.Operation.ApplyQty * obj.Days)
                                    {
                                        this.neuSpread1_DetailSheet.Cells[k, 2].Value = true;
                                        this.deptDrugNum[i] = (decimal)this.deptDrugNum[i] - obj.Operation.ApplyQty * obj.Days;
                                        isFind = true;
                                        break;
                                    }
                                }
                                if (!isFind)
                                {
                                    this.neuSpread1_DetailSheet.Cells[j, 2].Value = false;
                                    this.deptDrugNum[i] = (decimal)this.deptDrugNum[i] + temp.Operation.ApplyQty * temp.Days;
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            for (int i = 0; i < this.deptDrugNum.Count; i++)
            {
                if ((decimal)this.deptDrugNum[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取当前用户选中的数据
        /// </summary>
        internal ArrayList GetCheckData()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                if (Neusoft.FrameWork.Function.NConvert.ToBoolean(this.neuSpread1_DetailSheet.Cells[i, 2].Value))
                    al.Add(this.neuSpread1_DetailSheet.Rows[i].Tag);
            }

            return al;
        }

        #region IInpatientDrug 成员

        /// <summary>
        /// 保存前
        /// </summary>
        public event EventHandler BeginSaveEvent;

        /// <summary>
        /// 保存后
        /// </summary>
        public event EventHandler EndSaveEvent;

        /// <summary>
        /// 清空表格中的数据
        /// </summary>
        public void Clear()
        {
            //清空核准数据
            this.neuSpread1_DetailSheet.Rows.Count = 0;
            try
            {
                //清空摆药单显示
                Function.IDrugPrint.AddAllData(new ArrayList());

                if (this.tbDrugDetail.TabPages.Contains(this.tpPatientMerge))
                {
                    if (this.tbDrugDetail.SelectedTab == this.tpPatientMerge)
                        this.tbDrugDetail.SelectedIndex = 0;
                }
                if (this.tbDrugDetail.TabPages.Contains(this.tpDeptMerge))
                {
                    if (this.tbDrugDetail.SelectedTab == this.tpDeptMerge)
                        this.tbDrugDetail.SelectedIndex = 0;
                }
            }
            catch { }
        }

        /// <summary>
        /// 选择全部数据
        /// </summary>
        public void CheckAll()
        {
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                if (this.isCheckSelect && !this.neuSpread1_DetailSheet.IsSelected(i, 0))
                    continue;
                this.neuSpread1_DetailSheet.Cells[i, 2].Value = true;
            }
        }

        /// <summary>
        /// 不选择任何数据
        /// </summary>
        public void CheckNone()
        {
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                if (this.isCheckSelect && !this.neuSpread1_DetailSheet.IsSelected(i, 0))
                    continue;
                this.neuSpread1_DetailSheet.Cells[i, 2].Value = false;
            }
        }

        /// <summary>
        /// 显示出库申请数据
        /// </summary>
        /// <param name="arrayApplyOut">出库申请数据</param>
        /// <returns>成功返回1 发生错误返回-1</returns>
        public void ShowData(ArrayList arrayApplyOut)
        {
            this.Clear();

            if (this.isBillCodeClear)
            {
                this.alBillCode = new ArrayList();
                this.cmbBillCode.Items.Clear();
                this.cmbBillCode.Text = "";
            }
            if (arrayApplyOut.Count == 0)
            {
                return;
            }

            arrayApplyOut.Sort(new CompareApplyOut());

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut;
            this.neuSpread1_DetailSheet.Rows.Add(0, arrayApplyOut.Count);
            //保存本次显示数据
            this.alApplyOutInfo = arrayApplyOut;

            for (int i = 0; i < arrayApplyOut.Count; i++)
            {
                applyOut = arrayApplyOut[i] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                this.AddDataToFpDetail(applyOut, i);

                this.SetBillCodeData(applyOut);
            }
        }

        /// <summary>
        /// 根据传入的摆药通知进行退药处理
        /// </summary>
        /// <param name="drugMessage">摆药通知</param>
        /// <returns>1成功，-1失败</returns>
        public virtual int Save(Neusoft.HISFC.Models.Pharmacy.DrugMessage drugMessage)
        {
            if (drugMessage == null || drugMessage.ApplyDept.ID == "" || this.neuSpread1_DetailSheet.Rows.Count <= 0)
                return -1;

            if (this.BeginSaveEvent != null)
                this.BeginSaveEvent(drugMessage, null);

            #region 对于特殊药品自动进行待摆药计算

            if (this.IsAutoCheck && this.tbDrugDetail.SelectedTab == this.tpDeptMerge)
            {
                if (!this.AutoSetCheck())
                {
                    MessageBox.Show(Language.Msg("对于您所输入的摆药量，未能正确算出需摆哪些申请记录 \n 请根据剩余数量进行手工调整"));
                    return -1;
                }
            }

            #endregion

            #region 对用户选择的数据进行摆药处理

            ArrayList al = this.GetCheckData();

            if (al.Count == 0)
            {
                MessageBox.Show(Language.Msg("请选择需核准发药的数据"));
                return -1;
            }

            //提示是否摆药 {152EF737-99B9-410f-BE97-B11C02B6F330} wbo 2010-09-22
            if (MessageBox.Show("是否确定摆药？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return -1;
            }
            //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在摆药，请稍后... ...");
            Application.DoEvents();

            if (drugMessage.DrugBillClass.ID == "R")
            {
                if (DrugStore.Function.DrugReturnConfirm(al, drugMessage, this.ArkDept, this.ApproveDept) == -1)
                {
                    //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }
            else
            {
                if (DrugStore.Function.DrugConfirm(al, drugMessage, this.ArkDept, this.ApproveDept) == -1)
                {
                    //提示正在摆药 {43593D0F-C93E-4a59-9037-F1FF3E0D5381} wbo 2010-09-22
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return -1;
                }
            }

            #endregion
            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            if (this.EndSaveEvent != null)
                this.EndSaveEvent(drugMessage, null);

            if (MessageBox.Show("是否打印?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //提示打印进度 {C9ADA757-AA2D-4674-8BEE-F647EE683A59} wbo 2010-09-22
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在打印... ...");
                Application.DoEvents();

                //保存摆药单号
                this.myDrugBillClass.DrugBillNO = drugMessage.DrugBillClass.Memo;

                if (this.hsDrugBillClass.ContainsKey(drugMessage.DrugBillClass.ID))
                {
                    this.myDrugBillClass.PrintType = this.hsDrugBillClass[drugMessage.DrugBillClass.ID] as Neusoft.HISFC.Models.Pharmacy.BillPrintType;
                    this.myDrugBillClass.Name = drugMessage.DrugBillClass.Name;
                }

                Function.Print(al, this.myDrugBillClass, this.IsAutoPrint, this.IsPrintLabel, this.IsNeedPreview);

                //提示打印进度 {C9ADA757-AA2D-4674-8BEE-F647EE683A59} wbo 2010-09-22
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                MessageBox.Show("打印完毕！");
            }
            return 1;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void Preview()
        {
            this.Print();
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            if (this.isAddDrugBillControl)      //如果增加了摆药单预览
            {
                if (this.tbDrugDetail.SelectedTab != this.tpDrugBill)
                {
                    #region donggq--20101122--{F1EBA464-FE20-479a-BD79-E63756E318B8}--毒麻摆药打印处理

                    if (this.tbDrugDetail.SelectedTab == this.tpDetail && this.myDrugBillClass.PrintType.ID.ToString()=="D") 
                    {
                        
                        ArrayList al = this.GetCheckData();

                        if (al.Count == 0)
                        {
                            MessageBox.Show(Language.Msg("请选择需核准发药的数据"));
                            return;
                        }

                        if (MessageBox.Show("是否进行选择打印?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在打印... ...");
                            Application.DoEvents();

                            this.myDrugBillClass.User01 = "NurseType";

                            Function.Print(al, this.myDrugBillClass, false, false, true);

                            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                            //MessageBox.Show("打印完毕！");
                            return;
                        }
                        else 
                        {
                            Neusoft.FrameWork.WinForms.Classes.Print pp = new Neusoft.FrameWork.WinForms.Classes.Print();

                            pp.PrintPage(0, 0, this);
                            return;
                        }
                        
                    }

                    #endregion

                    Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

                    p.PrintPage(0, 0, this);
                    return;
                }
            }

            if (this.hsDrugBillClass.ContainsKey(this.myDrugBillClass.ID))
            {
                this.myDrugBillClass.PrintType = this.hsDrugBillClass[this.myDrugBillClass.ID] as Neusoft.HISFC.Models.Pharmacy.BillPrintType;
            }

            //待解决 毒麻药打印问题
            Neusoft.HISFC.Models.Pharmacy.DrugBillClass drugBillClassTemp = new Neusoft.HISFC.Models.Pharmacy.DrugBillClass();
            if (this.myDrugBillClass.PrintType.ID.ToString() == "T" && this.tbDrugDetail.SelectedTab == this.tpDetail)
            {
                drugBillClassTemp = this.myDrugBillClass.Clone();
                drugBillClassTemp.PrintType.ID = "D";
            }
            else
            {
                drugBillClassTemp = this.myDrugBillClass.Clone();
            }

            if (this.isAddDrugBillControl && Function.IDrugPrint != null)
            {
                Function.IDrugPrint.Print();
            }
            else
            {
                if (this.IsPrintLabel)
                    Function.PrintLabelForOutpatient(this.GetCheckData());
                else
                    Function.PrintBill(this.GetCheckData(), drugBillClassTemp);
            }
        }

        #endregion

        private void cmbBillCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.neuSpread1_DetailSheet.Rows.Count < this.alApplyOutInfo.Count)
            {
                this.isBillCodeClear = false;
                this.ShowData(this.alApplyOutInfo);
                this.isBillCodeClear = true;
            }

            if (this.cmbBillCode.Text == "")
                return;

            for (int i = this.neuSpread1_DetailSheet.Rows.Count - 1; i >= 0; i--)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.neuSpread1_DetailSheet.Rows[i].Tag as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (applyOut.BillNO != this.cmbBillCode.Text)
                {
                    this.neuSpread1_DetailSheet.Rows[i].Remove();
                }
            }
        }

        private void tbDrugDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbDrugDetail.SelectedTab == this.tpPatientMerge)
            {
                this.MergePatientData();
            }
            if (this.tbDrugDetail.SelectedTab == this.tpDeptMerge)
            {
                this.IsAutoCheck = false;

                this.MergeDeptData();                
            }
        }        

        #region Fp弹出菜单

        System.Windows.Forms.ContextMenu fpContextMenu = new ContextMenu();

        private void neuSpread1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.fpContextMenu.MenuItems != null)
                this.fpContextMenu.MenuItems.Clear();
        }

        private void neuSpread1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.fpContextMenu.MenuItems != null)
                    this.fpContextMenu.MenuItems.Clear();

                MenuItem menuSelect = new MenuItem("选  中");
                menuSelect.Click += new EventHandler(menuSelect_Click);

                MenuItem menuCancelSelect = new MenuItem("取消选中");
                menuCancelSelect.Click += new EventHandler(menuCancelSelect_Click);

                MenuItem menuReverseSelect = new MenuItem("反向选择");
                menuReverseSelect.Click += new EventHandler(menuReverseSelect_Click);

                this.fpContextMenu.MenuItems.Add(menuReverseSelect);
                if (this.AllowMultiSelect)
                {
                    this.fpContextMenu.MenuItems.Add(menuCancelSelect);
                    this.fpContextMenu.MenuItems.Add(menuSelect);
                }

                this.fpContextMenu.Show(this.neuSpread1, new Point(e.X, e.Y));
            }
        }

        void menuCancelSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                if (this.neuSpread1_DetailSheet.IsSelected(i, 0))
                    this.neuSpread1_DetailSheet.Cells[i, 2].Value = false;
            }
        }

        void menuSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                if (this.neuSpread1_DetailSheet.IsSelected(i, 0))
                    this.neuSpread1_DetailSheet.Cells[i, 2].Value = true;
            }
        }

        void menuReverseSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.neuSpread1_DetailSheet.Rows.Count; i++)
            {
                this.neuSpread1_DetailSheet.Cells[i, 2].Value = !(bool)this.neuSpread1_DetailSheet.Cells[i, 2].Value;
            }
        }

        /// <summary>
        /// 控件初始化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            #region 反射读取摆药单打印dll

            try
            {
                //object obj = Neusoft.FrameWork.WinForms.Classes.Function.CreateControl( "TestInterface" , "TestInterface.ucDrugBillPrint" );
                //this.AddDrugBill( obj );
            }
            catch (System.TypeLoadException ex)
            {
                MessageBox.Show("摆药单的指定命名空间无效\n" + ex.Message);
                return;
            }

            #endregion

            base.OnLoad(e);
        }
        #endregion

        #region  排序

        protected class CompareApplyOut : IComparer
        {
            public int Compare(object x, object y)
            {
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o1 = (x as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();
                Neusoft.HISFC.Models.Pharmacy.ApplyOut o2 = (y as Neusoft.HISFC.Models.Pharmacy.ApplyOut).Clone();

                string oX = null;
                string oY = null;
                if (o1.User01.Length > 4)
                {
                    oX = o1.User01.Substring(4);
                }
                else
                {
                    oX = o1.User01;
                }
                if (o2.User01.Length > 4)
                {
                    oY = o2.User01.Substring(4);
                }
                else
                {
                    oY = o2.User01;
                }
                oX = oX.PadLeft(5, '0');
                oY = oY.PadLeft(5, '0');

                int nComp;
             
                if (oX == null)
                {
                    nComp = (oY != null) ? -1 : 0;
                }
                else if (oY == null)
                {
                    nComp = 1;
                }
                else
                {
                    nComp = string.Compare(oX.ToString(), oY.ToString());
                }

                return nComp;
            }
        }

        #endregion
    }
}

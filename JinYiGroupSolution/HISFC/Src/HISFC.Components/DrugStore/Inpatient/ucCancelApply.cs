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

namespace Neusoft.HISFC.Components.DrugStore.Inpatient
{
    /// <summary>
    /// <br></br>
    /// [功能描述: 直接退费（采用终端扣费流程时使用）]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-09]<br></br>
    /// <说明>
    ///     1、该窗口使用于护士站
    /// </说明>
    /// </summary>
    public partial class ucCancelApply : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucCancelApply()
        {
            InitializeComponent();

            this.Load += new EventHandler(ucCancelApply_Load);
        }
     
        #region 域变量

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 人员帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper personHelper = null;
       
        /// <summary>
        /// 用药申请信息
        /// </summary>
        private System.Collections.Hashtable hsApply = null;

        /// <summary>
        /// 正常用药申请
        /// </summary>
        private DataTable dtNormalApply = null;

        /// <summary>
        /// 作废用药申请
        /// </summary>
        private DataTable dtCancelApply = null;

        /// <summary>
        /// 患者显示信息
        /// </summary>
        private string strPatientInfo = "姓名：{0}  性别：{1}  病区：{2}  床号：{3}";

        /// <summary>
        /// 申请患者信息
        /// </summary>
        private Neusoft.HISFC.Models.RADT.PatientInfo applyPatient = null;

        /// <summary>
        /// 操作科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject operDept = null;

        #endregion

        #region 属性

        /// <summary>
        /// 起始时间
        /// </summary>
        protected DateTime BeginDate
        {
            get
            {
                return NConvert.ToDateTime(this.dtBegin.Text);
            }
        }

        /// <summary>
        /// 截至时间
        /// </summary>
        protected DateTime EndDate
        {
            get
            {
                return NConvert.ToDateTime(this.dtEnd.Text);
            }
        }

        #endregion

        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <returns></returns>
        private int Init()
        {
            #region 帮助类信息初始化

            Neusoft.HISFC.BizProcess.Integrate.Manager managerIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Manager();

            ArrayList alDept = managerIntegrate.GetDepartment();
            if (alDept == null)
            {
                MessageBox.Show(Language.Msg("获取全院科室列表失败") + managerIntegrate.Err);
                return -1;
            }
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(alDept);

            ArrayList alPerson = managerIntegrate.QueryEmployeeAll();
            if (alPerson == null)
            {
                MessageBox.Show(Language.Msg("获取全院人员列表失败") + managerIntegrate.Err);
                return -1;
            }
            this.personHelper = new Neusoft.FrameWork.Public.ObjectHelper(alPerson);

            #endregion

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            DateTime sysTime = dataManager.GetDateTimeFromSysDateTime();

            this.dtBegin.Value = sysTime.Date.AddDays(-1);

            this.operDept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;

            this.InitDataTable();

            return 1;
        }

        /// <summary>
        /// 数据集初始化
        /// </summary>
        /// <returns></returns>
        private int InitDataTable()
        {
            System.Type dtBol = System.Type.GetType("System.Boolean");
            System.Type dtStr = System.Type.GetType("System.String");
            System.Type dtDec = System.Type.GetType("System.Decimal");
            System.Type dtDate = System.Type.GetType("System.DateTime");

            #region 正常用药申请DataTable初始化

            this.dtNormalApply = new DataTable();

            this.dtNormalApply.Columns.AddRange(
                                    new System.Data.DataColumn[] {
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("金额",      dtDec),
                                                                    new DataColumn("申请科室",  dtStr),
                                                                    new DataColumn("发药科室",  dtStr),
                                                                    new DataColumn("申请人",    dtStr),
                                                                    new DataColumn("申请日期",  dtStr),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("流水号",    dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr)
                                                                   }
                                  );

            DataColumn[] normalKeys = new DataColumn[1];

            normalKeys[0] = this.dtNormalApply.Columns["流水号"];

            this.dtNormalApply.PrimaryKey = normalKeys;

            this.fpNormalApply_Sheet1.DataSource = this.dtNormalApply.DefaultView;

            #endregion

            #region 作废用药申请DataTable初始化

            this.dtCancelApply = new DataTable();

            this.dtCancelApply.Columns.AddRange(
                                    new System.Data.DataColumn[] {
                                                                    new DataColumn("商品名称",  dtStr),
                                                                    new DataColumn("规格",      dtStr),
                                                                    new DataColumn("零售价",    dtDec),
                                                                    new DataColumn("申请数量",  dtDec),
                                                                    new DataColumn("金额",      dtDec),
                                                                    new DataColumn("申请科室",  dtStr),
                                                                    new DataColumn("发药科室",  dtStr),
                                                                    new DataColumn("申请人",    dtStr),
                                                                    new DataColumn("申请日期",  dtStr),
                                                                    new DataColumn("备注",      dtStr),
                                                                    new DataColumn("流水号",    dtStr),
                                                                    new DataColumn("拼音码",    dtStr),
                                                                    new DataColumn("五笔码",    dtStr),
                                                                    new DataColumn("自定义码",  dtStr)
                                                                   }
                                  );

            DataColumn[] cancelKeys = new DataColumn[1];

            cancelKeys[0] = this.dtCancelApply.Columns["流水号"];

            this.dtCancelApply.PrimaryKey = cancelKeys;

            this.fpCancelApply_Sheet1.DataSource = this.dtCancelApply.DefaultView;

            #endregion            

            this.SetFormat();

            return 1;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private void SetFormat()
        {
            this.fpNormalApply_Sheet1.DataAutoSizeColumns = false;
            this.fpCancelApply_Sheet1.DataAutoSizeColumns = false;

            this.fpCancelApply_Sheet1.Columns[(int)ColumnSet.ColOper].Width = 80F;
            this.fpCancelApply_Sheet1.Columns[(int)ColumnSet.ColID].Visible = false;
            this.fpCancelApply_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.fpCancelApply_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.fpCancelApply_Sheet1.Columns[(int)ColumnSet.ColCustomeCode].Visible = false;

            this.fpNormalApply_Sheet1.Columns[(int)ColumnSet.ColOper].Width = 80F;
            this.fpNormalApply_Sheet1.Columns[(int)ColumnSet.ColID].Visible = false;
            this.fpNormalApply_Sheet1.Columns[(int)ColumnSet.ColSpellCode].Visible = false;
            this.fpNormalApply_Sheet1.Columns[(int)ColumnSet.ColWBCode].Visible = false;
            this.fpNormalApply_Sheet1.Columns[(int)ColumnSet.ColCustomeCode].Visible = false;
        }

        /// <summary>
        /// 患者信息显示设置
        /// </summary>
        private void SetPatientInfo()
        {
            this.lbPatientInfo.Text = string.Format(this.strPatientInfo,this.applyPatient.Name,this.applyPatient.Sex.Name,this.applyPatient.PVisit.PatientLocation.Dept.ID,this.applyPatient.PVisit.PatientLocation.Bed.ID);
        }

        /// <summary>
        /// 修改作废申请信息
        /// </summary>
        /// <param name="isAdd">是否增加作废信息</param>
        private int AddRemoveCancelApply(bool isAdd)
        {
            if (isAdd)
            {
                string applyID = this.fpNormalApply_Sheet1.Cells[this.fpNormalApply_Sheet1.ActiveRowIndex, (int)ColumnSet.ColID].Text;

                DataRow drNormal = this.dtNormalApply.Rows.Find(applyID);

                try
                {
                    if (drNormal != null)
                    {
                        DataRow dr = this.dtCancelApply.NewRow();
                        dr.ItemArray = drNormal.ItemArray;

                        this.dtNormalApply.Rows.Remove(drNormal);

                        this.dtNormalApply.AcceptChanges();

                        this.dtCancelApply.Rows.Add(dr);

                        this.dtCancelApply.AcceptChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
            else
            {
                string applyID = this.fpCancelApply_Sheet1.Cells[this.fpCancelApply_Sheet1.ActiveRowIndex, (int)ColumnSet.ColID].Text;

                DataRow drNormal = this.dtCancelApply.Rows.Find(applyID);

                try
                {
                    if (drNormal != null)
                    {
                        DataRow dr = this.dtNormalApply.NewRow();
                        dr.ItemArray = drNormal.ItemArray;

                        this.dtCancelApply.Rows.Remove(drNormal);

                        this.dtCancelApply.AcceptChanges();

                        this.dtNormalApply.Rows.Add(dr);

                        this.dtNormalApply.AcceptChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 正常用药申请信息检索
        /// </summary>
        /// <returns></returns>
        private int SetNormalApply(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.dtNormalApply.Rows.Add(new object[] { 
                                                        applyOut.Item.Name,
                                                        applyOut.Item.Specs,
                                                        applyOut.Item.PriceCollection.RetailPrice,
                                                        applyOut.Operation.ApplyQty,
                                                        System.Math.Round((applyOut.Operation.ApplyQty * applyOut.Days / applyOut.Item.PackQty) * applyOut.Item.PriceCollection.RetailPrice,2),
                                                        this.deptHelper.GetName(applyOut.ApplyDept.ID),
                                                        this.deptHelper.GetName(applyOut.StockDept.ID),
                                                        this.personHelper.GetName(applyOut.Operation.ApplyOper.ID),
                                                        applyOut.Operation.ApplyOper.OperTime,
                                                        applyOut.Memo,
                                                        applyOut.ID,
                                                        applyOut.Item.NameCollection.SpellCode,
                                                        applyOut.Item.NameCollection.WBCode,
                                                        applyOut.Item.NameCollection.UserCode                                                        
                                                        });
            return 1;
        }

        /// <summary>
        /// 作废用药申请信息检索
        /// </summary>
        /// <returns></returns>
        private int SetCancelApply(Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut)
        {
            this.dtCancelApply.Rows.Add(new object[] { 
                                                        applyOut.Item.Name,
                                                        applyOut.Item.Specs,
                                                        applyOut.Item.PriceCollection.RetailPrice,
                                                        applyOut.Operation.ApplyQty,
                                                        System.Math.Round((applyOut.Operation.ApplyQty * applyOut.Days / applyOut.Item.PackQty) * applyOut.Item.PriceCollection.RetailPrice,2),
                                                        this.deptHelper.GetName(applyOut.ApplyDept.ID),
                                                        this.deptHelper.GetName(applyOut.StockDept.ID),
                                                        this.personHelper.GetName(applyOut.Operation.ApplyOper.ID),
                                                        applyOut.Operation.ApplyOper.OperTime,
                                                        applyOut.Memo,
                                                        applyOut.ID,
                                                        applyOut.Item.NameCollection.SpellCode,
                                                        applyOut.Item.NameCollection.WBCode,
                                                        applyOut.Item.NameCollection.UserCode                                                        
                                                        });

            this.fpCancelApply_Sheet1.Rows[this.fpCancelApply_Sheet1.Rows.Count - 1].ForeColor = System.Drawing.Color.Red;

            return 1;
        }       

        /// <summary>
        /// 申请信息检索
        /// </summary>
        /// <returns></returns>
        internal int QueryApply()
        {
            if (this.applyPatient == null)
            {
                MessageBox.Show(Language.Msg("请输入住院号回车选择退费患者"));
                return 0;
            }

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            ArrayList alApply = itemManager.GetPatientApply(this.applyPatient.ID,"AAAA",this.operDept.ID,this.BeginDate,this.EndDate,"0");
            if (alApply == null)
            {
                MessageBox.Show(Language.Msg("患者获取申请信息失败") + itemManager.Err);
                return -1;
            }

            this.dtNormalApply.Rows.Clear();

            this.dtCancelApply.Rows.Clear();

            this.hsApply = new Hashtable();

            foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut in alApply)
            {
                if (applyOut.State != "0")
                {
                    continue;
                }
                //不显示退药申请
                if (applyOut.SystemType == Neusoft.HISFC.Models.Base.EnumIMAOutTypeService.GetNameFromEnum(Neusoft.HISFC.Models.Base.EnumIMAOutType.InpatientBackOutput))
                {
                    continue;
                }
                //1有效 0 无效
                if (applyOut.ValidState == Neusoft.HISFC.Models.Base.EnumValidState.Valid)
                {
                    this.SetNormalApply(applyOut);
                }
                else
                {
                    this.SetCancelApply(applyOut);
                }

                this.hsApply.Add(applyOut.ID, applyOut);
            }

            return 1;
        }

        /// <summary>
        /// 清屏
        /// </summary>
        internal void Clear()
        {
            this.dtCancelApply.Rows.Clear();

            this.dtNormalApply.Rows.Clear();

            this.hsApply.Clear();
        }

        /// <summary>
        /// 作废用药申请
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        internal int CancelApply()
        {
            if (this.fpCancelApply_Sheet1.Rows.Count <= 0)
            {
                return 0;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            //itemManager.SetTrans(t.Trans);
            //{E8849BB0-3C69-4d60-8771-C201E445BD5D}  预扣库存的判断处理
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            bool isPreOut = ctrlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Pre_Out, false, true);

            for (int i = 0; i < this.fpCancelApply_Sheet1.Rows.Count; i++)            
            {
                string applyID = this.fpCancelApply_Sheet1.Cells[i, (int)ColumnSet.ColID].Text;

                Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApply[applyID] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

                //对已经无效的数据 不重复保存
                if (applyOut.ValidState ==  Neusoft.HISFC.Models.Base.EnumValidState.Invalid)
                {
                    continue;
                }

                //作废摆药申请
                //{E8849BB0-3C69-4d60-8771-C201E445BD5D}  传入参数调整
                if (itemManager.CancelApplyOutByID(applyOut.ID, isPreOut) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("作废摆药申请失败"));
                    return -1;
                }

                //作废医嘱执行档
                
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("作废申请成功"));

            this.Clear();

            return 1;
        }

        /// <summary>
        /// 取消作废
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        protected int UnCancelApply()
        {
            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();
            //itemManager.SetTrans(t.Trans);

            //{E8849BB0-3C69-4d60-8771-C201E445BD5D}  预扣库存的判断处理
            Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam ctrlIntegrate = new Neusoft.HISFC.BizProcess.Integrate.Common.ControlParam();
            bool isPreOut = ctrlIntegrate.GetControlParam<bool>(Neusoft.HISFC.BizProcess.Integrate.PharmacyConstant.InDrug_Pre_Out, false, true);

            string applyID = this.fpCancelApply_Sheet1.Cells[this.fpCancelApply_Sheet1.ActiveRowIndex, (int)ColumnSet.ColID].Text;

            Neusoft.HISFC.Models.Pharmacy.ApplyOut applyOut = this.hsApply[applyID] as Neusoft.HISFC.Models.Pharmacy.ApplyOut;

            //取消作废摆药申请
            //{E8849BB0-3C69-4d60-8771-C201E445BD5D}  传入参数调整
            if (itemManager.UndoCancelApplyOutByID(applyOut.ID, isPreOut) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("取消作废摆药申请失败"));
                return -1;
            }

            //取消作废医嘱执行档

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("取消作废申请成功"));

            this.AddRemoveCancelApply(false);

            return 1;
        }

        #region 工具栏信息

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnQuery(object sender, object neuObject)
        {
            this.QueryApply();

            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <returns></returns>
        protected override int OnSave(object sender, object neuObject)
        {
            this.CancelApply();

            return base.OnSave(sender, neuObject);
        }

        #endregion

        private void ucCancelApply_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();
            }
        }

        private void ucQueryInpatientNo1_myEvent()
        {
            string patientNO = this.ucQueryInpatientNo1.InpatientNo;
            if (patientNO == null || patientNO == "")
            {
                MessageBox.Show(Language.Msg("住院号不存在"));
                return;
            }

            Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

            this.applyPatient = radtIntegrate.QueryPatientInfoByInpatientNO(patientNO);
            if (this.applyPatient == null)
            {
                MessageBox.Show(Language.Msg("根据住院流水号查找住院患者信息失败") + radtIntegrate.Err);
                return;
            }

            this.SetPatientInfo();

            this.QueryApply();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (this.dtNormalApply == null)
                return;

            //获得过滤条件
            string queryCode = "%" + this.txtFilter.Text + "%";

            string filter = string.Format("(拼音码 LIKE '{0}') OR (五笔码 LIKE '{0}') OR (自定义码 LIKE '{0}') OR (商品名称 LIKE '{0}')", queryCode);

            this.dtNormalApply.DefaultView.RowFilter = filter;
        }

        private void fpNormalApply_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                return;
            }

            this.AddRemoveCancelApply(true);
        }

        private void fpCancelApply_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader || e.ColumnHeader)
            {
                return;
            }

            this.fpCancelApply_Sheet1.ActiveRowIndex = e.Row;

            this.UnCancelApply();
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 商品名称
            /// </summary>
            ColTradeName,
            /// <summary>
            /// 规格
            /// </summary>
            ColSpecs,
            /// <summary>
            /// 零售价
            /// </summary>
            ColRetailPrice,
            /// <summary>
            /// 申请数量
            /// </summary>
            ColApplyQty,
            /// <summary>
            /// 金额
            /// </summary>
            ColCost,
            /// <summary>
            /// 申请科室
            /// </summary>
            ColApplyDept,
            /// <summary>
            /// 发药科室
            /// </summary>
            ColDrugDept,
            /// <summary>
            /// 申请/作废 人
            /// </summary>
            ColOper,
            /// <summary>
            /// 申请/作废 日期
            /// </summary>
            ColDate,
            /// <summary>
            /// 备注
            /// </summary>
            ColMemo,
            /// <summary>
            /// 流水号
            /// </summary>
            ColID,
            /// <summary>
            /// 拼音码
            /// </summary>
            ColSpellCode,
            /// <summary>
            /// 五笔码
            /// </summary>
            ColWBCode,
            /// <summary>
            /// 自定义码
            /// </summary>
            ColCustomeCode
        }
    }
}

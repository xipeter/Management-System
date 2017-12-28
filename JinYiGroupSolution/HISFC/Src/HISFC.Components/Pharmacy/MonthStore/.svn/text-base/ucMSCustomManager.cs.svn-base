using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Neusoft.FrameWork.Management;
using Neusoft.HISFC.Models.Base;
using Neusoft.HISFC.Models.Admin;


namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    /// <summary>
    /// [功能描述: 药品自定义月结设置]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-07-30]<br></br>
    /// </summary>
    public partial class ucMSCustomManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucMSCustomManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 科室类型
        /// </summary>
        private EnumDeptType deptTypeEnum = EnumDeptType.药库;

        /// <summary>
        /// 收支类型
        /// </summary>
        private string[] addFlagStrCollection = new string[] { "收入","支出"};

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 权限科室
        /// </summary>
        private Neusoft.FrameWork.Models.NeuObject privDept = null;

        /// <summary>
        /// 科室帮助类
        /// </summary>
        private Neusoft.FrameWork.Public.ObjectHelper deptHelper = null;

        /// <summary>
        /// 入库科室帮助集合
        /// </summary>
        private System.Collections.Hashtable hsPrivInDept = new Hashtable();

        /// <summary>
        /// 入库科室集合
        /// </summary>
        private string[] privInStrCollection = null;

        /// <summary>
        /// 出库科室帮助集合
        /// </summary>
        private System.Collections.Hashtable hsPrivOutDept = new Hashtable();

        /// <summary>
        /// 出库科室集合
        /// </summary>
        private string[] privOutStrCollection = null;

        /// <summary>
        /// 入库三级权限集合
        /// </summary>
        private string[] privInC3StrCollection = null;

        /// <summary>
        /// 入库三级权限帮助集合
        /// </summary>
        private System.Collections.Hashtable hsPrivInC3 = new Hashtable();

        /// <summary>
        /// 出库三级权限集合
        /// </summary>
        private string[] privOutC3StrCollection = null;

        /// <summary>
        /// 出库三级权限帮助集合
        /// </summary>
        private System.Collections.Hashtable hsPrivOutC3 = new Hashtable();

        /// <summary>
        /// 盘点盈亏集合
        /// </summary>
        private string[] strCheckCollection = new string[] { "盘点 - 盘亏", "盘点 - 盘盈" };

        /// <summary>
        /// 调价盈亏集合
        /// </summary>
        private string[] strAdjustCollection = new string[] { "调价 - 调亏", "调价 - 调盈" };
    
        #endregion

        #region 属性

        /// <summary>
        /// 科室类型
        /// </summary>
        [Description("自定义月结项目科室类型"),Category("设置")]
        public EnumDeptType DeptTypeEnum
        {
            get
            {
                return this.deptTypeEnum;
            }
            set
            {
                this.deptTypeEnum = value;
            }
        }

        /// <summary>
        /// 科室类型
        /// </summary>
        protected Neusoft.HISFC.Models.Base.EnumDepartmentType DeptType
        {
            get
            {
                if (this.deptTypeEnum == EnumDeptType.药库)
                {
                    return Neusoft.HISFC.Models.Base.EnumDepartmentType.PI;
                }
                else
                {
                    return Neusoft.HISFC.Models.Base.EnumDepartmentType.P;
                }
            }
        }

        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("增加", "新建计划单", Neusoft.FrameWork.WinForms.Classes.EnumImageList.X新建, true, false, null);
           
            toolBarService.AddToolButton("删除", "删除当前选择的计划药品", Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);

            return toolBarService;
        }

        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "删除")
            {
                this.DelData();
            }
            if (e.ClickedItem.Text == "增加")
            {
                this.AddNewData();
            }
           
            base.ToolStrip_ItemClicked(sender, e);
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.SaveMSCustom() == 1)
            {
                this.ShowMSCustomManager();
            }

            return 1;
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init()
        {
            FarPoint.Win.Spread.CellType.ComboBoxCellType addFlagCmbType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            addFlagCmbType.Items = this.addFlagStrCollection;

            this.neuSpread1_Sheet1.Columns[6].CellType = addFlagCmbType;

            Neusoft.FrameWork.Management.DataBaseManger dataManager = new DataBaseManger();

            this.privDept = ((Neusoft.HISFC.Models.Base.Employee)dataManager.Operator).Dept;

            Neusoft.HISFC.BizProcess.Integrate.Manager integrateManager = new Neusoft.HISFC.BizProcess.Integrate.Manager();
            
            ArrayList aldept = integrateManager.GetDepartment();
            this.deptHelper = new Neusoft.FrameWork.Public.ObjectHelper(aldept);

            int iIndex = 0;

            #region 获取出入库科室列表

            Neusoft.HISFC.BizLogic.Manager.PrivInOutDept privInOutManager = new Neusoft.HISFC.BizLogic.Manager.PrivInOutDept();

            ArrayList alPrivInDept = privInOutManager.GetPrivInOutDeptList(this.privDept.ID, "0310");
            if (alPrivInDept == null)
            {
                MessageBox.Show(Language.Msg("获取当前科室入库科室列表发生错误") + privInOutManager.Err);
                return;
            }

            this.privInStrCollection = new string[alPrivInDept.Count];
            iIndex = 0;
            foreach (Neusoft.HISFC.Models.Base.PrivInOutDept privInInfo in alPrivInDept)
            {
                this.privInStrCollection[iIndex] = "科室 － " + privInInfo.Dept.Name;

                this.hsPrivInDept.Add(this.privInStrCollection[iIndex], privInInfo.Dept.ID);

                iIndex++;
            }
            
            ArrayList alPrivOutDept = privInOutManager.GetPrivInOutDeptList(this.privDept.ID, "0320");
            if (alPrivOutDept == null)
            {
                MessageBox.Show(Language.Msg("获取当前科室出库科室列表发生错误") + privInOutManager.Err);
                return;
            }
            this.privOutStrCollection = new string[alPrivOutDept.Count];
            iIndex = 0;
            foreach (Neusoft.HISFC.Models.Base.PrivInOutDept privOutInfo in alPrivOutDept)
            {
                this.privOutStrCollection[iIndex] = "科室 － " + privOutInfo.Dept.Name;

                this.hsPrivOutDept.Add(this.privOutStrCollection[iIndex], privOutInfo.Dept.ID);

                iIndex++;
            }

            #endregion

            #region 入出库权限集合

            Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();
            
            ArrayList alPrivInC3 = powerManager.LoadLevel3ByLevel2("0310");
            if (alPrivInC3 == null)
            {
                MessageBox.Show(Language.Msg("获取当前入库三级权限类型发生错误") + powerManager.Err);
                return;
            }
            this.privInC3StrCollection = new string[alPrivInC3.Count];
            iIndex = 0;
            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 privInC3 in alPrivInC3)
            {
                this.privInC3StrCollection[iIndex] = "入库 － " + privInC3.Name;

                this.hsPrivInC3.Add(this.privInC3StrCollection[iIndex], privInC3.ID);

                iIndex++;
            }

            ArrayList alPrivOutC3 = powerManager.LoadLevel3ByLevel2("0320");
            if (alPrivOutC3 == null)
            {
                MessageBox.Show(Language.Msg("获取当前出库三级权限类型发生错误") + powerManager.Err);
                return;
            }
            this.privOutC3StrCollection = new string[alPrivOutC3.Count];
            iIndex = 0;
            foreach (Neusoft.HISFC.Models.Admin.PowerLevelClass3 privOutC3 in alPrivOutC3)
            {
                this.privOutC3StrCollection[iIndex] = "出库 － " + privOutC3.Name;

                this.hsPrivOutC3.Add(this.privOutC3StrCollection[iIndex], privOutC3.ID);

                iIndex++;
            }

            #endregion
        }

        #endregion

        /// <summary>
        /// 向Fp内加入数据
        /// </summary>
        /// <param name="msCustomLis">药品设置信息</param>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int AddDataToFp(List<Neusoft.HISFC.Models.Pharmacy.MSCustom> msCustomLis)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            foreach (Neusoft.HISFC.Models.Pharmacy.MSCustom info in msCustomLis)
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);

                this.neuSpread1_Sheet1.Cells[0, 0].Text = info.CustomItem.ID;
                this.neuSpread1_Sheet1.Cells[0, 1].Text = info.CustomItem.Name;
                this.neuSpread1_Sheet1.Cells[0, 2].Text = Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.GetNameFromEnum(info.CustomType);
                this.neuSpread1_Sheet1.Cells[0, 3].Text = info.CustomType.ToString();
                this.neuSpread1_Sheet1.Cells[0, 6].Text = info.Trans == Neusoft.HISFC.Models.Base.TransTypes.Positive ? "收入" : "支出";

                this.neuSpread1_Sheet1.Cells[0, 4].Text = info.TypeItem;

                FarPoint.Win.Spread.CellType.ComboBoxCellType cmbCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cmbCellType.Items = this.GetDescriptionFromType(info.CustomType, info.Trans);

                this.neuSpread1_Sheet1.Cells[0, 5].CellType = cmbCellType;
                this.neuSpread1_Sheet1.Cells[0, 5].Text = this.GetDescriptionFromTypeItem(info.CustomType, info.TypeItem,info.Trans);
                
                this.neuSpread1_Sheet1.Cells[0, 7].Text = info.ID;

                this.neuSpread1_Sheet1.Rows[0].Tag = info;
            }

            return 1;
        }

        /// <summary>
        /// 由Fp内获取数据
        /// </summary>
        /// <param name="iRowIndex">行索引</param>
        /// <returns></returns>
        protected Neusoft.HISFC.Models.Pharmacy.MSCustom GetDataFormFp(int iRowIndex)
        {
            Neusoft.HISFC.Models.Pharmacy.MSCustom msCustom = this.neuSpread1_Sheet1.Rows[iRowIndex].Tag as Neusoft.HISFC.Models.Pharmacy.MSCustom;

            msCustom.DeptType = this.DeptType;

            msCustom.CustomItem.ID = this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text;
            msCustom.CustomItem.Name = this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text;

            msCustom.ItemOrder = Neusoft.FrameWork.Function.NConvert.ToInt32(msCustom.CustomItem.ID);

            msCustom.CustomType = Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.GetEnumFromName(this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text);
            msCustom.TypeItem = this.neuSpread1_Sheet1.Cells[iRowIndex, 4].Text;
            msCustom.Trans = this.neuSpread1_Sheet1.Cells[iRowIndex, 6].Text == "支出" ? Neusoft.HISFC.Models.Base.TransTypes.Negative : Neusoft.HISFC.Models.Base.TransTypes.Positive;

            return msCustom;
        }

        /// <summary>
        /// 根据项目类别、分类内容获取描述信息
        /// </summary>
        /// <param name="customType">分类</param>
        /// <param name="typeItem">分类内容</param>
        /// <returns></returns>
        protected string GetDescriptionFromTypeItem(EnumMSCustomType customType,string typeItem,TransTypes trans)
        {
            switch (customType)
            {
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.入库:       //根据入库类型检索                         
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.出库:       //根据出库类型检索
                    Neusoft.HISFC.BizLogic.Manager.PowerLevelManager powerManager = new Neusoft.HISFC.BizLogic.Manager.PowerLevelManager();

                    PowerLevelClass3 pIn3 = powerManager.LoadLevel3ByPrimaryKey(Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.GetNameFromEnum(customType), typeItem);

                    return customType.ToString() + " － " + pIn3.Name;
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.科室:       //科室 根据入出库科室选择
                    Neusoft.HISFC.BizLogic.Manager.PrivInOutDept privInOutManager = new Neusoft.HISFC.BizLogic.Manager.PrivInOutDept();

                    return "科室 － " + this.deptHelper.GetName(typeItem);   
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.调价:
                    if (typeItem == "00")
                    {
                        return this.strAdjustCollection[0];
                    }
                    else
                    {
                        return this.strAdjustCollection[1];
                    }
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.盘点:       //根据盘点盈亏
                    if (typeItem == "00")
                    {
                        return this.strCheckCollection[0];
                    }
                    else
                    {
                        return this.strCheckCollection[1];
                    }              
                default:
                    return customType.ToString();
            }
        }

        /// <summary>
        /// 根据项目类别设置不同的分类内容
        /// </summary>
        /// <param name="customType">项目分类</param>
        /// <returns></returns>
        protected string[] GetDescriptionFromType(EnumMSCustomType customType,TransTypes trnas)
        {
            switch (customType)
            {
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.入库:       //根据入库类型检索  

                    return this.privInC3StrCollection;
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.出库:       //根据出库类型检索

                    return this.privOutC3StrCollection;
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.科室:       //科室 根据入出库科室选择
                    if (trnas == TransTypes.Positive)                       //正交易 取入库科室
                    {
                        return this.privInStrCollection;
                    }
                    else                                                    //反交易 取出库科室
                    {
                        return this.privOutStrCollection;
                    }

                case Neusoft.HISFC.Models.Base.EnumMSCustomType.调价:

                    return this.strAdjustCollection;
                case Neusoft.HISFC.Models.Base.EnumMSCustomType.盘点:       //根据盘点盈亏

                    return this.strCheckCollection;
                default:
                    return new string[] { customType.ToString() };
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        protected int AddNewData()
        {
            int rowCount = this.neuSpread1_Sheet1.Rows.Count;

            this.neuSpread1_Sheet1.Rows.Add(rowCount, 1);

            Neusoft.HISFC.Models.Pharmacy.MSCustom msCustom = new Neusoft.HISFC.Models.Pharmacy.MSCustom();
            msCustom.Trans = TransTypes.Positive;

            if (rowCount > 0)
            {
                this.neuSpread1_Sheet1.Cells[rowCount, 6].Text = this.neuSpread1_Sheet1.Cells[rowCount - 1, 6].Text;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[rowCount, 6].Text = this.addFlagStrCollection[0];
            }

            this.neuSpread1_Sheet1.Rows[rowCount].Tag = msCustom;
                        
            return 1;
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <returns></returns>
        public int DelData()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return -1;
            }

            DialogResult rs = MessageBox.Show(Language.Msg("是否确认删除当前选择的设置信息"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return -1;
            }

            int iIndex = this.neuSpread1_Sheet1.ActiveRowIndex;

            if (this.neuSpread1_Sheet1.Cells[iIndex, 7].Text != "")
            {
                if (this.consManager.DelMSCustom(this.neuSpread1_Sheet1.Cells[iIndex, 7].Text) == -1)
                {
                    MessageBox.Show(Language.Msg("数据删除失败") + this.consManager.Err);
                    return -1;
                }
            }

            this.neuSpread1_Sheet1.Rows.Remove(iIndex, 1);

            MessageBox.Show(Language.Msg("删除成功"));
            return 1;
        }

        /// <summary>
        /// 加载已维护自定义月结设置信息
        /// </summary>
        /// <returns></returns>
        public int ShowMSCustomManager()
        {
            List<Neusoft.HISFC.Models.Pharmacy.MSCustom> msCustomLis = this.consManager.QueryMSCustom(this.DeptType);

            if (msCustomLis == null)
            {
                MessageBox.Show(Language.Msg("加载已维护自定义月结设置信息发生错误"));
                return -1;
            }

            this.AddDataToFp(msCustomLis);

            return 1;
        }

        /// <summary>
        /// 分类选择
        /// </summary>
        /// <param name="iRow">行索引</param>
        protected int PopMSCustomType(int iRow)
        {
            ArrayList al = Neusoft.HISFC.Models.Base.EnumMSCustomTypeService.List();

            Neusoft.FrameWork.Models.NeuObject typeObj = new Neusoft.FrameWork.Models.NeuObject();
            if (Neusoft.FrameWork.WinForms.Classes.Function.ChooseItem(al, ref typeObj) == 0)
            {
                return -1;
            }
            else
            {
                this.neuSpread1_Sheet1.Cells[iRow,2].Text = typeObj.Name;
                this.neuSpread1_Sheet1.Cells[iRow,3].Text = typeObj.ID;

                this.SetTypeItem(iRow);
            }

            return 1;
        }

        /// <summary>
        /// 设置Fp分类内容
        /// </summary>
        /// <param name="iRow"></param>
        private void SetTypeItem(int iRow)
        {
            EnumMSCustomType customType = EnumMSCustomTypeService.GetEnumFromName(this.neuSpread1_Sheet1.Cells[iRow, 2].Text);

            TransTypes trans = this.neuSpread1_Sheet1.Cells[iRow, 6].Text.Trim() == "收入" ? TransTypes.Positive : TransTypes.Negative;

            FarPoint.Win.Spread.CellType.ComboBoxCellType typeItemCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();

            typeItemCellType.Items = this.GetDescriptionFromType(customType, trans);
            this.neuSpread1_Sheet1.Cells[iRow, 5].CellType = typeItemCellType;
        }

        /// <summary>
        /// 判断是否允许保存,是否已填全必要的信息
        /// </summary>
        /// <returns>成功返回True 失败返回False</returns>
        protected bool IsValid()
        {
            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                if (this.neuSpread1_Sheet1.Cells[i, 0].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置第" + (i+1).ToString() + "行项目编码,该编码同时标志需合并的项及项目顺序"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i, 1].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置第" + (i + 1).ToString() + "行项目名称,该名称同时标志报表相应项名称"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i, 3].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置第" + (i + 1).ToString() + "行项目分类"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i, 5].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置第" + (i + 1).ToString() + "行分类内容"));
                    return false;
                }
                if (this.neuSpread1_Sheet1.Cells[i,6].Text == "")
                {
                    MessageBox.Show(Language.Msg("请设置第" + (i + 1).ToString() + "行收支标记"));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <returns></returns>
        public int SaveMSCustom()
        {
            if (this.neuSpread1_Sheet1.Rows.Count <= 0)
            {
                return 0;
            }

            if (!this.IsValid())
            {
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.consManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.consManager.DelMSCustom(this.DeptType) == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("保存前删除原科室数据发生错误") + this.consManager.Err);
                return -1;
            }

            DateTime sysTime = this.consManager.GetDateTimeFromSysDateTime();

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.MSCustom msCustom = this.GetDataFormFp(i);

                msCustom.Oper.OperTime = sysTime;
                msCustom.Oper.ID = this.consManager.Operator.ID;

                if (this.consManager.InsertMSCustom(msCustom) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存科室数据发生错误") + this.consManager.Err);
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        /// <summary>
        /// 自定义月结分类选择
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                this.Init();

                this.ShowMSCustomManager();
            }

            base.OnLoad(e);
        }        

        #region 枚举

        /// <summary>
        /// 科室类别
        /// </summary>
        public enum EnumDeptType
        {
            药库,
            药房
        }

        #endregion

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column == 3)
            {
                this.PopMSCustomType(e.Row);
            }
        }

        private void neuSpread1_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 5 )
            {
                #region 根据选择的项目获取编码

                EnumMSCustomType customType = EnumMSCustomTypeService.GetEnumFromName(this.neuSpread1_Sheet1.Cells[e.Row, 2].Text);

                TransTypes trans = this.neuSpread1_Sheet1.Cells[e.Row, 6].Text.Trim() == "收入" ? TransTypes.Positive : TransTypes.Negative;

                string keys = this.neuSpread1_Sheet1.Cells[e.Row,5].Text;
                string typeItemID = "";
                switch (customType)
                {
                    case Neusoft.HISFC.Models.Base.EnumMSCustomType.入库:       //根据入库类型检索  
                        if (this.hsPrivInC3.ContainsKey(keys))
                        {
                            typeItemID = this.hsPrivInC3[keys].ToString();
                        }
                        break;
                    case Neusoft.HISFC.Models.Base.EnumMSCustomType.出库:       //根据出库类型检索
                        if (this.hsPrivOutC3.ContainsKey(keys))
                        {
                            typeItemID = this.hsPrivOutC3[keys].ToString();
                        }
                        break;
                    case Neusoft.HISFC.Models.Base.EnumMSCustomType.科室:       //科室 根据入出库科室选择
                        if (trans == TransTypes.Positive)                       //正交易 取入库科室
                        {
                            if (this.hsPrivInDept.ContainsKey(keys))
                            {
                                typeItemID = this.hsPrivInDept[keys].ToString();
                            }
                        }
                        else                                                    //反交易 取出库科室
                        {
                            if (this.hsPrivOutDept.ContainsKey(keys))
                            {
                                typeItemID = this.hsPrivOutDept[keys].ToString();
                            }
                        }
                        break;
                    case Neusoft.HISFC.Models.Base.EnumMSCustomType.调价:
                        typeItemID = keys == this.strAdjustCollection[0] ? "00" : "01";
                        break;
                    case Neusoft.HISFC.Models.Base.EnumMSCustomType.盘点:       //根据盘点盈亏
                        typeItemID = keys == this.strCheckCollection[0] ? "00" : "01";
                        break;
                    case EnumMSCustomType.门诊患者领药:
                        typeItemID = "M1";
                        break;
                    case EnumMSCustomType.门诊患者退药:
                        typeItemID = "M2";
                        break;
                    case EnumMSCustomType.住院患者领药:
                        typeItemID = "Z1";
                        break;
                    case EnumMSCustomType.住院患者退药:
                        typeItemID = "Z2";
                        break;
                    case EnumMSCustomType.小计:
                        typeItemID = "SUB";
                        break;
                }

                this.neuSpread1_Sheet1.Cells[e.Row, 4].Text = typeItemID;

                #endregion
            }
            if (e.Column == 6)      //收支标记
            {
                this.SetTypeItem(e.Row);
            }   
        }
    }
}

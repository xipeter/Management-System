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

namespace Neusoft.HISFC.Components.Pharmacy.Base
{
    /// <summary>
    /// [功能描述: 科室库存常数维护]<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-03]<br></br>
    /// 
    /// 
    /// {59C9BD46-05E6-43f6-82F3-C0E3B53155CB}   增加入库单起始号、出库单起始号的维护
    /// </summary>
    public partial class ucDeptConstant : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucDeptConstant()
        {
            InitializeComponent();
        }

        #region 说明

        /*
         *  1、新增科室(不一定是药房或药库)需要维护部门常数时 需先在科室结构内对03类别进行添加
         * 
         *  2、Sql
         *      SELECT  
				PHA_COM_DEPT.DEPT_CODE,                              --部门编码
				COM_DEPTSTAT.DEPT_NAME,				     --部门名称
				PHA_COM_DEPT.STORE_MAX_DAYS,                         --库房最高库存量(天)
				PHA_COM_DEPT.STORE_MIN_DAYS,                         --库房最低库存量(天)
				PHA_COM_DEPT.REFERENCE_DAYS,                         --参考天数
				PHA_COM_DEPT.BATCH_FLAG,                             --是否按批号管理药品
				PHA_COM_DEPT.STORE_FLAG,                             --是否管理药品库存
				PHA_COM_DEPT.UNIT_FLAG,                              --库存管理时默认的单位，1包装单位，0最小单位
				PHA_COM_DEPT.OPER_CODE,                              --操作员代码
				PHA_COM_DEPT.OPER_DATE                               --操作时间
			FROM 	PHA_COM_DEPT,
				COM_DEPTSTAT  
			WHERE 	PHA_COM_DEPT.PARENT_CODE  = COM_DEPTSTAT.PARENT_CODE 
			AND  	PHA_COM_DEPT.CURRENT_CODE = COM_DEPTSTAT.CURRENT_CODE 
			AND   	COM_DEPTSTAT.STAT_CODE = '03' 
			AND   	COM_DEPTSTAT.DEPT_CODE = PHA_COM_DEPT.DEPT_CODE 
			AND   	PHA_COM_DEPT.PARENT_CODE  =  fun_get_parentcode  
			AND  	PHA_COM_DEPT.CURRENT_CODE =  fun_get_currentcode  
         * 
         */

        #endregion

        #region 域变量

        /// <summary>
        /// 业务管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 是否可以设置库存管理单位
        /// </summary>
        private bool isManagerUnitFlag = true;

        /// <summary>
        /// 是否可以设置批号管理
        /// </summary>
        private bool isManagerBatch = true;

        /// <summary>
        /// 是否可以设置库存管理
        /// </summary>
        private bool isManagerStore = true;

        /// <summary>
        /// 是否可以设置库存警戒线参数
        /// </summary>
        private bool isManagerParam = true;

        /// <summary>
        /// 是否可以设置药柜管理标志
        /// </summary>
        private bool isManagerArk = true;

        /// <summary>
        /// 已维护的科室库存列表
        /// </summary>
        private System.Collections.Hashtable hsphaDept = new Hashtable();

        /// <summary>
        /// 是否允许设置入库单号
        /// </summary>
        private bool isManagerInListNO = false;

        /// <summary>
        /// 是否允许设置出库单号
        /// </summary>
        private bool isManagerOutListNO = false;
        #endregion

        #region 属性

        /// <summary>
        /// 是否可以设置库存管理单位
        /// </summary>
        [Description("是否可以设置库存管理单位"),Category("设置"),DefaultValue(true)]
        public bool IsManagerUnitFlag
        {
            get
            {
                return isManagerUnitFlag;
            }
            set
            {
                isManagerUnitFlag = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColUnitFlag].Visible = value;                
            }
        }

        /// <summary>
        /// 是否可以设置批号管理
        /// </summary>
        [Description("是否可以设置批号管理"), Category("设置"), DefaultValue(true)]
        public bool IsManagerBatch
        {
            get
            {
                return isManagerBatch;
            }
            set
            {
                isManagerBatch = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsBatch].Visible = value;
            }
        }

        /// <summary>
        /// 是否可以设置库存管理
        /// </summary>
        [Description("是否可以设置库存管理"), Category("设置"), DefaultValue(true)]
        public bool IsManagerStore
        {
            get
            {
                return isManagerStore;
            }
            set
            {
                isManagerStore = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsStore].Visible = value;
            }
        }

        /// <summary>
        /// 是否可以设置库存警戒线参数
        /// </summary>
        [Description("是否可以设置库存警戒线参数"), Category("设置"), DefaultValue(true)]
        public bool IsManagerParam
        {
            get
            {
                return isManagerParam;
            }
            set
            {
                isManagerParam = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMaxDays].Visible = value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColMinDays].Visible = value;
                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColReferenceDays].Visible = value;
            }
        }

        /// <summary>
        /// 是否可以设置药柜管理
        /// </summary>
        [Description("是否可以设置药柜管理"), Category("设置"), DefaultValue(true)]
        public bool IsManagerArk
        {
            get
            {
                return this.isManagerArk;
            }
            set
            {
                this.isManagerArk = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColIsArk].Visible = value;
            }
        }

        /// <summary>
        /// 是否允许设置入库单号
        /// </summary>
        [Description("是否允许设置入库单号"), Category("设置"), DefaultValue(true)]
        public bool IsManagerInListNO
        {
            get
            {
                return this.isManagerInListNO;
            }
            set
            {
                this.isManagerInListNO = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColInListNO].Visible = value;
            }
        }

        /// <summary>
        /// 是否允许设置出库单号
        /// </summary>
        [Description("是否允许设置出库单号"), Category("设置"), DefaultValue(true)]
        public bool IsManagerOutListNO
        {
            get
            {
                return this.isManagerOutListNO;
            }
            set
            {
                this.isManagerOutListNO = value;

                this.neuSpread1_Sheet1.Columns[(int)ColumnSet.ColOutListNO].Visible = value;
            }
        }
        #endregion

        #region 工具栏

        private Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {          
            return toolBarService;
        }

        protected override int OnSave(object sender, object neuObject)
        {
            return this.SaveDeptCons();
        }

        #endregion

        /// <summary>
        /// 显示科室列表
        /// </summary>
        private int ShowDeptList()
        {
            this.neuSpread1_Sheet1.RowCount = 0;

            //取科室常数信息
            ArrayList al = this.phaConsManager.QueryDeptConstantList();           
            if (al == null)
            {
                MessageBox.Show(Language.Msg(this.phaConsManager.Err));
                return -1;
            }

            try
            {
                this.hsphaDept.Clear();

                Neusoft.HISFC.Models.Pharmacy.DeptConstant deptConstant = null;
                this.neuSpread1_Sheet1.RowCount = 0;

                int iCount = 0;

                for (int i = 0; i < al.Count; i++)
                {                  
                    deptConstant = al[i] as Neusoft.HISFC.Models.Pharmacy.DeptConstant;

                    this.hsphaDept.Add(deptConstant.ID,null);

                    if (deptConstant.ID.Substring(0, 1) == "S")
                    {
                        continue;
                    }
                   
                    this.neuSpread1_Sheet1.Rows.Add(iCount, 1);

                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColDeptID].Value = deptConstant.ID;			//部门编码
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColDeptName].Value = deptConstant.Name;			//部门名称
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsStore].Value = deptConstant.IsStore;		//是否管理库存
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsBatch].Value = deptConstant.IsBatch;		//是否按批号管理
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColUnitFlag].Value = deptConstant.UnitFlag == "1" ? "包装单位" : "最小单位";//库存管理默认单位:0最小单位,1包装单位
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColMaxDays].Value = deptConstant.StoreMaxDays;	//库存上限天数
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColMinDays].Value = deptConstant.StoreMinDays;	//库存下限天数
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColReferenceDays].Value = deptConstant.ReferenceDays;//参考天数
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsArk].Value = deptConstant.IsArk;            //药柜管理标志 是否药柜管理
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColInListNO].Value = deptConstant.InListNO;
                    this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColOutListNO].Value = deptConstant.OutListNO;

                    iCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 获取科室结构信息
        /// </summary>
        /// <returns></returns>
        private int ShowDeptStat()
        {
            Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager deptStatManager = new Neusoft.HISFC.BizLogic.Manager.DepartmentStatManager();
            ArrayList alDeptStat = deptStatManager.LoadDepartmentStat("03");
            if (alDeptStat == null)
            {
                MessageBox.Show(Language.Msg("获取科室节点信息失败"));
                return -1;
            }

            foreach (Neusoft.HISFC.Models.Base.DepartmentStat deptStat in alDeptStat)
            {
                if (this.hsphaDept.ContainsKey(deptStat.DeptCode))
                {
                    continue;
                }

                if (deptStat.DeptCode.Substring(0, 1) == "S")
                {
                    continue;
                }

                Neusoft.HISFC.Models.Pharmacy.DeptConstant deptConstant = new Neusoft.HISFC.Models.Pharmacy.DeptConstant();

                deptConstant.ID = deptStat.DeptCode;
                deptConstant.Name = deptStat.DeptName;

                int iCount = this.neuSpread1_Sheet1.Rows.Count;

                this.neuSpread1_Sheet1.Rows.Add(iCount, 1);

                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColDeptID].Value = deptConstant.ID;			//部门编码
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColDeptName].Value = deptConstant.Name;			//部门名称        

                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsStore].Value = false;
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsBatch].Value = false ;		//是否按批号管理
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColUnitFlag].Value = "最小单位";//库存管理默认单位:0最小单位,1包装单位
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColIsArk].Value = false;            //药柜管理标志 是否药柜管理

                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColInListNO].Value = "";            //药柜管理标志 是否药柜管理
                this.neuSpread1_Sheet1.Cells[iCount, (int)ColumnSet.ColOutListNO].Value = "";            //药柜管理标志 是否药柜管理

            }
            return 1;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private int SaveDeptCons()
        {
            if (this.neuSpread1_Sheet1.RowCount == 0)
            {
                MessageBox.Show(Language.Msg("没有可以保存的数据"));
                return -1;
            }

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Neusoft.FrameWork.Management.Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            phaConsManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            Neusoft.HISFC.Models.Pharmacy.DeptConstant deptConstant = null;

            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                deptConstant = new Neusoft.HISFC.Models.Pharmacy.DeptConstant();

                deptConstant.ID = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDeptID].Text;			                                //部门编码
                deptConstant.Name = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColDeptName].Text;			                            //部门名称
                deptConstant.IsStore = NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColIsStore].Value.ToString());		//是否管理库存
                deptConstant.IsBatch = NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColIsBatch].Value.ToString());		//是否按批号管理
                deptConstant.UnitFlag = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColUnitFlag].Text.ToString() == "包装单位" ? "1" : "0";//库存管理默认单位:0最小单位,1包装单位
                deptConstant.StoreMaxDays = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMaxDays].Text);              //库存上限天数
                deptConstant.StoreMinDays = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColMinDays].Text);              //库存下限天数
                deptConstant.ReferenceDays = NConvert.ToInt32(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColReferenceDays].Text);       //参考天数
                deptConstant.IsArk = NConvert.ToBoolean(this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColIsArk].Value.ToString());         //是否药柜管理
                //{849BBA57-0A27-4e6b-BC8C-C92A9B9B325F}
                //deptConstant.InListNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColInListNO].Value.ToString();
                //deptConstant.OutListNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColOutListNO].Value.ToString();
                try
                {
                    deptConstant.InListNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColInListNO].Value.ToString();
                }
                catch (Exception)
                {

                    deptConstant.InListNO = "";
                }

                try
                {
                    deptConstant.OutListNO = this.neuSpread1_Sheet1.Cells[i, (int)ColumnSet.ColOutListNO].Value.ToString();
                }
                catch (Exception)
                {

                    deptConstant.OutListNO = "";
                }

                int parm = this.phaConsManager.UpdateDeptConstant(deptConstant);
                if (parm == 0)
                {                    
                        if (this.phaConsManager.InsertDeptConstant(deptConstant) != 1)
                        {
                            Neusoft.FrameWork.Management.PublicTrans.RollBack();
                            MessageBox.Show(Language.Msg(this.phaConsManager.Err));
                            return -1;
                        }
                }
                else if (parm == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg(this.phaConsManager.Err));
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper() != "DEVENV")
            {
                if (!Neusoft.HISFC.Components.Common.Classes.Function.ChoosePiv("0300"))
                {
                    MessageBox.Show(Neusoft.FrameWork.Management.Language.Msg("您无操作权限"));
                    this.toolBarService.SetToolButtonEnabled("保存", false);
                    return;
                }

                this.ShowDeptList();

                this.ShowDeptStat();
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// 列设置
        /// </summary>
        private enum ColumnSet
        {
            /// <summary>
            /// 科室名称
            /// </summary>
            ColDeptName,
            /// <summary>
            /// 是否管理库存
            /// </summary>
            ColIsStore,
            /// <summary>
            /// 是否管理批号
            /// </summary>
            ColIsBatch,
            /// <summary>
            /// 库存管理单位
            /// </summary>
            ColUnitFlag,
            /// <summary>
            /// 库存管理上限
            /// </summary>
            ColMaxDays,
            /// <summary>
            /// 库存管理下限
            /// </summary>
            ColMinDays,
            /// <summary>
            /// 参考天数
            /// </summary>
            ColReferenceDays,
            /// <summary>
            /// 是否药柜管理
            /// </summary>
            ColIsArk,
            ColInListNO,
            ColOutListNO,
            /// <summary>
            /// 科室编码
            /// </summary>
            ColDeptID
        }
    }
}

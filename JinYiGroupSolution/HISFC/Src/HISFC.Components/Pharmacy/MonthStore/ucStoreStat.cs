using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.Pharmacy.MonthStore
{
    /// <summary>
    /// [功能描述: 药品月结--程序运行]<br></br>
    /// [创 建 者: ]<br></br>
    /// [创建时间: 2010-06]<br></br>
    /// </summary>
    public partial class ucStoreStat : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucStoreStat()
        {
            InitializeComponent();
        }

        Neusoft.FrameWork.Management.DataBaseManger dataManager = new Neusoft.FrameWork.Management.DataBaseManger();

        /// <summary>
        /// 是否全院统一月结
        /// </summary>
        private bool isStatTogether = true;

        private bool isShowTime = false;

        /// <summary>
        /// 库存科室编码
        /// </summary>
        private string drugDeptCode = "";

        /// <summary>
        /// 数据校验信息显示
        /// </summary>
        ucPhaApplyList ucVeriftDataDisplay = new ucPhaApplyList();

        /// <summary>
        /// 药品管理类
        /// </summary>
        Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        #region 属性

        /// <summary>
        /// 是否全院统一月结
        /// </summary>
        [Category( "设置" ), Description( "设置月结时全院统一月结" ), DefaultValue( true )]
        public bool IsStatTogether
        {
            get
            {
                return this.isStatTogether;
            }
            set
            {
                this.isStatTogether = value;
            }
        }

        [Category("设置"), Description("是否显示月结性能显示"), DefaultValue(true)]
        public bool IsShowTime//{4E5ED663-D468-4a00-B376-652DE847CB14}
        {
            get
            {
                return this.isShowTime;
            }
            set
            {
                this.isShowTime = value;
            }
        }
        #endregion

        #region 获取月结数据

        /// <summary>
        /// 查询入库月结数据
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// 增加PURCHASE_COST{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// <returns></returns>
        private DataTable QueryInput(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(IN_NUM) IN_NUM,SUM(RETAIL_COST) RETAIL_COST,SUM(PURCHASE_COST) PURCHASE_COST,NVL                                                          (SPECIAL_FLAG,'0') SPECIAL_FLAG
                            FROM   PHA_COM_INPUT
                            WHERE  DRUG_DEPT_CODE = '{0}'
                            AND    IN_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    IN_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE,NVL(SPECIAL_FLAG,'0')
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";

            if (this.isStatTogether == true)                //全院月结
            {
                sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(IN_NUM) IN_NUM,SUM(RETAIL_COST) RETAIL_COST,SUM(PURCHASE_COST) PURCHASE_COST,NVL(SPECIAL_FLAG,'0')                                     SPECIAL_FLAG
                            FROM   PHA_COM_INPUT
                            WHERE  IN_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    IN_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE,NVL(SPECIAL_FLAG,'0')
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";
            }

            sql = string.Format( sql, deptCode, dtBegin.ToString(), dtEnd.ToString() );

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询入库月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[3];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];
            keys[2] = ds.Tables[0].Columns["SPECIAL_FLAG"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }

        /// <summary>
        /// 查询出库月结数据
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// 增加PURCHASE_COST{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// <returns></returns>
        private DataTable QueryOutput(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(OUT_NUM) OUT_NUM,SUM(SALE_COST) SALE_COST,
                            SUM(ROUND(OUT_NUM/PACK_QTY*PURCHASE_PRICE,2)) PURCHASE_COST,NVL(SPECIAL_FLAG,'0') SPECIAL_FLAG
                            FROM   PHA_COM_OUTPUT
                            WHERE  DRUG_DEPT_CODE = '{0}'
                            AND    OUT_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OUT_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE,NVL(SPECIAL_FLAG,'0')
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";

            if (this.isStatTogether == true)        //全院月结
            {
                sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(OUT_NUM) OUT_NUM,SUM(SALE_COST) SALE_COST,
                            SUM(ROUND(OUT_NUM/PACK_QTY*PURCHASE_PRICE,2)) PURCHASE_COST,NVL(SPECIAL_FLAG,'0') SPECIAL_FLAG
                            FROM   PHA_COM_OUTPUT
                            WHERE  OUT_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OUT_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE,NVL(SPECIAL_FLAG,'0')
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";
            }

            sql = string.Format( sql, deptCode, dtBegin.ToString(), dtEnd.ToString() );

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询出库月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[3];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];
            keys[2] = ds.Tables[0].Columns["SPECIAL_FLAG"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }

        /// <summary>
        /// 查询出库月结数据
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private DataTable QueryDispensingOutput(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(OUT_NUM) OUT_NUM,SUM(SALE_COST) SALE_COST
                            FROM   PHA_COM_OUTPUT
                            WHERE  DRUG_DEPT_CODE = '{0}'
                            AND    OUT_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OUT_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CLASS3_MEANING_CODE IN ('M1','M2','Z1','Z2')
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";

            if (this.isStatTogether == true)            //全院月结
            {
                sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(OUT_NUM) OUT_NUM,SUM(SALE_COST) SALE_COST
                            FROM   PHA_COM_OUTPUT
                            WHERE  OUT_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OUT_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CLASS3_MEANING_CODE IN ('M1','M2','Z1','Z2')
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";
            }

            sql = string.Format( sql, deptCode, dtBegin.ToString(), dtEnd.ToString() );

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询出库月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[2];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }

        /// <summary>
        /// 查询盘点月结数据
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// 增加PURCHASE_COST{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// <returns></returns>
        private DataTable QueryCheck(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(CSTORE_NUM - FSTORE_NUM) QTY, SUM(round((CSTORE_NUM - FSTORE_NUM) / PACK_QTY * RETAIL_PRICE ,2))  COST,
                            SUM(round((CSTORE_NUM - FSTORE_NUM) / PACK_QTY * PURCHASE_PRICE, 2)) PURCHASE_COST                
                            FROM   PHA_COM_CHECKDETAIL
                            WHERE  DRUG_DEPT_CODE = '{0}'
                            AND    OPER_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OPER_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CHECK_STATE = '1'
                            AND    ADD_FLAG = '0'
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";

            if (this.isStatTogether == true)            //全院月结
            {
                sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM(CSTORE_NUM - FSTORE_NUM) QTY, SUM(round((CSTORE_NUM - FSTORE_NUM) / PACK_QTY * RETAIL_PRICE ,2))  COST,
                            SUM(round((CSTORE_NUM - FSTORE_NUM) / PACK_QTY * PURCHASE_PRICE, 2)) PURCHASE_COST                
                            FROM   PHA_COM_CHECKDETAIL
                            WHERE  OPER_DATE > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    OPER_DATE <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CHECK_STATE = '1'
                            AND    ADD_FLAG = '0'
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";
            }

            sql = string.Format( sql, deptCode, dtBegin.ToString(), dtEnd.ToString() );                

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询盘点月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[2];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }
       
        /// <summary>
        /// 查询调价月结数据
        /// </summary>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        private DataTable QueryAdjust(string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM( STORE_SUM / PACK_QTY * (RETAIL_PRICE - PRE_RETAIL_PRICE)) COST
                            FROM   PHA_COM_ADJUSTPRICEDETAIL
                            WHERE  DRUG_DEPT_CODE = '{0}'
                            AND    INURE_TIME > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    INURE_TIME <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CURRENT_STATE = '1'
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";

            if (this.isStatTogether == true)            //全院月结 
            {
                sql = @" SELECT DRUG_DEPT_CODE,DRUG_CODE,SUM( STORE_SUM / PACK_QTY * (RETAIL_PRICE - PRE_RETAIL_PRICE)) COST
                            FROM   PHA_COM_ADJUSTPRICEDETAIL
                            WHERE  INURE_TIME > TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    INURE_TIME <= TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') 
                            AND    CURRENT_STATE = '1'
                            GROUP BY DRUG_DEPT_CODE,DRUG_CODE
                            ORDER BY DRUG_DEPT_CODE,DRUG_CODE
                                     ";
            }

            sql = string.Format( sql, deptCode, dtBegin.ToString(), dtEnd.ToString() );

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询调价月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[2];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }

        /// <summary>
        /// 查询上期月结数据
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <param name="dtEnd">截止时间</param>
        /// 增加CURRENT_MONTH_PURCHASE_COST{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// <returns></returns>
        private DataTable QueryLastMonthStat(string deptCode,DateTime dtEnd)
        {

            string sql = @" SELECT PHA_COM_MS_DRUG.DRUG_DEPT_CODE,PHA_COM_MS_DRUG.DRUG_CODE,
                                   PHA_COM_MS_DRUG.CURRENT_MONTH_NUM, PHA_COM_MS_DRUG.CURRENT_MONTH_COST,
                                    PHA_COM_MS_DRUG.CURRENT_MONTH_PURCHASE_COST
                            FROM   PHA_COM_MS_DRUG
                            WHERE  PHA_COM_MS_DRUG.TO_DATE = TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')
                            AND    PHA_COM_MS_DRUG.DRUG_DEPT_CODE = '{0}'
                            ORDER BY PHA_COM_MS_DRUG.DRUG_DEPT_CODE,PHA_COM_MS_DRUG.DRUG_CODE ";

            if (this.isStatTogether == true)
            {
                sql = @" SELECT PHA_COM_MS_DRUG.DRUG_DEPT_CODE,PHA_COM_MS_DRUG.DRUG_CODE,
                                   PHA_COM_MS_DRUG.CURRENT_MONTH_NUM, PHA_COM_MS_DRUG.CURRENT_MONTH_COST,
                                    PHA_COM_MS_DRUG.CURRENT_MONTH_PURCHASE_COST
                            FROM   PHA_COM_MS_DRUG
                            WHERE  PHA_COM_MS_DRUG.TO_DATE = TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS')
                            ORDER BY PHA_COM_MS_DRUG.DRUG_DEPT_CODE,PHA_COM_MS_DRUG.DRUG_CODE ";
                sql = string.Format( sql,  dtEnd.ToString() );
            }
            else
            {
                sql = string.Format( sql, deptCode, dtEnd.ToString() );
            }

            DataSet ds = new DataSet();
            if (this.dataManager.ExecQuery( sql, ref ds ) == -1)
            {
                MessageBox.Show( "查询上期月结数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return null;
            }
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            DataColumn[] keys = new DataColumn[2];
            keys[0] = ds.Tables[0].Columns["DRUG_DEPT_CODE"];
            keys[1] = ds.Tables[0].Columns["DRUG_CODE"];

            ds.Tables[0].PrimaryKey = keys;

            return ds.Tables[0];
        }

        #endregion

        /// <summary>
        /// 获取上次月结时间
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public DateTime GetMonthStoreLastDateTime(string deptCode)
        {
            string sql = @"
                             SELECT MAX(TO_DATE) FROM PHA_COM_MS_DEPT WHERE DRUG_DEPT_CODE = '" + deptCode + @"' 
                                     ";

            DateTime lastTime = DateTime.MinValue;

            string strLastTime = this.dataManager.ExecSqlReturnOne( sql );
            if (string.IsNullOrEmpty( strLastTime ))
            {
                lastTime = new DateTime( 1900, 1, 1, 0, 0, 1 );
            }
            else
            {
                lastTime = Neusoft.FrameWork.Function.NConvert.ToDateTime( strLastTime );
            }
            return lastTime;
        }

        /// <summary>
        /// 获取月结周期区间
        /// </summary>
        /// <param name="deptCode">月结科室</param>
        /// <returns>成功返回1 失败返回-1</returns>
        private int SetMonthStoreStatRange(string deptCode)
        {
            string sql = @"SELECT LAST_DTIME,NEXT_DTIME FROM COM_JOB WHERE JOB_CODE = 'PHA_MS'";
            if (this.isStatTogether == false)        //按科室月结
            {
                sql = string.Format( "SELECT LAST_DTIME,NEXT_DTIME FROM COM_JOB WHERE JOB_CODE = '{0}'", deptCode );
            }

            if (this.dataManager.ExecQuery( sql ) == -1)
            {
                return -1;
            }

            if (this.dataManager.Reader.Read())
            {
                this.dtpBeginStat.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dataManager.Reader[0] );         //上期月结截止时间、本期月结开始时间
                this.dtpEndStat.Value = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dataManager.Reader[1] );           //计划月结截止时间

                this.dtpBeginStat.Enabled = false;
            }
            else
            {
                DateTime sysDate = this.dataManager.GetDateTimeFromSysDateTime();

                this.dtpEndStat.Value = sysDate;
                this.dtpBeginStat.Value = sysDate.AddMonths( -1 );
            }

            return 1;
        }

        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        private int InitData()
        {
            Neusoft.HISFC.BizLogic.Pharmacy.Constant phaConsManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();
            System.Collections.ArrayList alCons = phaConsManager.QueryDeptConstantList();
            if (alCons == null)
            {
                MessageBox.Show( "加载科室列表发生错误" + phaConsManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return -1;
            }

            System.Collections.ArrayList alComboDept = new System.Collections.ArrayList();

            foreach (Neusoft.HISFC.Models.Pharmacy.DeptConstant info in alCons)
            {
                if (info.IsStore == true)           //科室管理库存
                {
                    alComboDept.Add( info );
                }
            }

            this.cmbDept.AddItems( alComboDept );

            return 1;
        }

        /// <summary>
        /// 创建本次月结明细数据表
        /// </summary>
        /// <param name="operCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// 增加{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// LAST_MONTH_PURCHASE_COST, --上期结存购入金额
        /// SUM(ROUND(T.STORE_SUM / T.PACK_QTY * T.Purchase_Price,2)) CURRENT_MONTH_PURCHASE_COST,    --本期结存购入金额
        /// IN_PURCHASE_COST,   --入库购入金额
        /// OUT_PURCHASE_COST,        --出库购入金额
        /// SPECIAL_IN_PURCHASE_COST,      --特殊入库购入金额
        /// SPECIAL_OUT_PURCHASE_COST,       --特殊出库购入金额
        /// CHECK_PROFIT_PURCHASE_COST,     --盘盈购入金额
        /// CHECK_LOSS_PURCHASE_COST         --盘亏购入金额
        /// <returns></returns>
        private DataTable CreatMonthStoreItem(string operCode, string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            string execSql = @" SELECT  T.DRUG_DEPT_CODE,T.DRUG_CODE,
                                        TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') TO_DATE,
                                        TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') FROM_DATE,
                                        S.TRADE_NAME,S.SPECS,
                                        T.MIN_UNIT,T.PACK_UNIT,T.PACK_QTY,T.RETAIL_PRICE,                           --最小单位、包装单位、包装数量、零售价
                                        S.WHOLESALE_PRICE,T.DRUG_TYPE,T.DRUG_QUALITY,
                                        0 LAST_MONTH_NUM,0 LAST_MONTH_COST,SUM(T.STORE_SUM) STORE_SUM,                             --上期结存数量\金额  本期结存数量/金额
                                        SUM(ROUND(T.STORE_SUM / T.PACK_QTY * T.RETAIL_PRICE,2)) STORE_COST,        --本期结存金额
                                        0 IN_NUM,0 IN_COST,0 OUT_NUM,0 OUT_COST,                                    --本期入库数量\金额  本期出库数量\金额
                                        0 SPECIAL_IN_NUM,0 SPECIAL_IN_COST,0 SPECIAL_OUT_NUM,0 SPECIAL_OUT_COST,    --本期特殊入库数量\金额  本期特殊出库数量\金额
                                        0 CHECK_PROFIT_NUM,0 CHECK_PROFIT_COST,0 CHECK_LOSS_NUM,0 CHECK_LOSS_COST,  --本期盘点盈亏数量\金额  
                                        0 WASTE_NUM, 0 WASTE_COST,                                                  --本期报损数量/金额
                                        0 ADJUST_PROFIT_COST,0 ADJUST_LOSS_COST,                                    --本期调盈、调亏
                                        '' BATCH_NO,                                                                --批号
                                        --SUM(T.STORE_COST) STORE_COST,                                                               --本期结存金额
                                        0 EXPEND_NUM,0 EXPEND_COST,                                                 --消耗数量/金额
                                        '{3}' OPER_CODE,'' OPER_NAME,                                               --操作员
                                        SYSDATE OPER_DATE,
                                        0 LAST_MONTH_PURCHASE_COST, --上期结存购入金额
                                        SUM(ROUND(T.STORE_SUM / T.PACK_QTY * T.Purchase_Price,2)) CURRENT_MONTH_PURCHASE_COST,    --本期结存购入金额
                                        0 IN_PURCHASE_COST,   --入库购入金额
                                        0 OUT_PURCHASE_COST,        --出库购入金额
                                        0 SPECIAL_IN_PURCHASE_COST,      --特殊入库购入金额
                                        0 SPECIAL_OUT_PURCHASE_COST,       --特殊出库购入金额
                                        0 CHECK_PROFIT_PURCHASE_COST,     --盘盈购入金额
                                        0 CHECK_LOSS_PURCHASE_COST         --盘亏购入金额
                                        FROM    PHA_COM_STORAGE T,PHA_COM_BASEINFO S
                                        WHERE   T.DRUG_CODE = S.DRUG_CODE
                                        AND     T.DRUG_DEPT_CODE = '{0}'
                                        group by T.DRUG_DEPT_CODE,T.DRUG_CODE,S.TRADE_NAME,S.SPECS,T.MIN_UNIT,T.PACK_UNIT,T.PACK_QTY,T.RETAIL_PRICE,S.WHOLESALE_PRICE,
                                        T.DRUG_TYPE,T.DRUG_QUALITY
                                    ";

            if (this.isStatTogether == true)        //全院月结
            {
                execSql = @"SELECT  T.DRUG_DEPT_CODE,T.DRUG_CODE,
                                        TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS') TO_DATE,
                                        TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') FROM_DATE,
                                        S.TRADE_NAME,S.SPECS,
                                        T.MIN_UNIT,T.PACK_UNIT,T.PACK_QTY,T.RETAIL_PRICE,                           --最小单位、包装单位、包装数量、零售价
                                        S.WHOLESALE_PRICE,T.DRUG_TYPE,T.DRUG_QUALITY,
                                        0 LAST_MONTH_NUM,0 LAST_MONTH_COST,SUM(T.STORE_SUM) STORE_SUM,                             --上期结存数量\金额  本期结存数量/金额
                                        SUM(ROUND(T.STORE_SUM / T.PACK_QTY * T.RETAIL_PRICE,2)) STORE_COST,
                                        0 IN_NUM,0 IN_COST,0 OUT_NUM,0 OUT_COST,                                    --本期入库数量\金额  本期出库数量\金额
                                        0 SPECIAL_IN_NUM,0 SPECIAL_IN_COST,0 SPECIAL_OUT_NUM,0 SPECIAL_OUT_COST,    --本期特殊入库数量\金额  本期特殊出库数量\金额
                                        0 CHECK_PROFIT_NUM,0 CHECK_PROFIT_COST,0 CHECK_LOSS_NUM,0 CHECK_LOSS_COST,  --本期盘点盈亏数量\金额  
                                        0 WASTE_NUM, 0 WASTE_COST,                                                  --本期报损数量/金额
                                        0 ADJUST_PROFIT_COST,0 ADJUST_LOSS_COST,                                    --本期调盈、调亏
                                        '' BATCH_NO,                                                                --批号
                                        --SUM(T.STORE_COST) STORE_COST,                                                               --本期结存金额
                                        0 EXPEND_NUM,0 EXPEND_COST,                                                 --消耗数量/金额
                                        '{2}' OPER_CODE,'' OPER_NAME,                                               --操作员
                                        SYSDATE OPER_DATE,
                                        0 LAST_MONTH_PURCHASE_COST, --上期结存购入金额
                                        SUM(ROUND(T.STORE_SUM / T.PACK_QTY * T.Purchase_Price,2)) CURRENT_MONTH_PURCHASE_COST,    --本期结存购入金额
                                        0 IN_PURCHASE_COST,   --入库购入金额
                                        0 OUT_PURCHASE_COST,        --出库购入金额
                                        0 SPECIAL_IN_PURCHASE_COST,      --特殊入库购入金额
                                        0 SPECIAL_OUT_PURCHASE_COST,       --特殊出库购入金额
                                        0 CHECK_PROFIT_PURCHASE_COST,     --盘盈购入金额
                                        0 CHECK_LOSS_PURCHASE_COST         --盘亏购入金额
                                        FROM    PHA_COM_STORAGE T,PHA_COM_BASEINFO S
                                        WHERE   T.DRUG_CODE = S.DRUG_CODE
                                        AND     T.DRUG_DEPT_CODE IN (SELECT R.DEPT_CODE FROM PHA_COM_DEPT R WHERE R.STORE_FLAG = '1')   
                                        group by T.DRUG_DEPT_CODE,T.DRUG_CODE,S.TRADE_NAME,S.SPECS,T.MIN_UNIT,T.PACK_UNIT,T.PACK_QTY,T.RETAIL_PRICE,S.WHOLESALE_PRICE,
                                        T.DRUG_TYPE,T.DRUG_QUALITY                                     
                                        ORDER BY T.DRUG_DEPT_CODE,T.DRUG_CODE
                                    ";

                execSql = string.Format( execSql, dtEnd.ToString(), dtBegin.ToString(), operCode );
            }
            else
            {
                execSql = string.Format( execSql, deptCode, dtEnd.ToString(), dtBegin.ToString(), operCode );
            }

            DataSet ds = new DataSet();
            this.dataManager.ExecQuery( execSql, ref ds );
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }
            DataTable dtItem = ds.Tables[0];

            DataColumn[] keys = new DataColumn[2];
            keys[0] = dtItem.Columns["DRUG_DEPT_CODE"];
            keys[1] = dtItem.Columns["DRUG_CODE"];

            dtItem.PrimaryKey = keys;

            return dtItem;
        }

        /// <summary>
        /// 创建本次月结汇总表
        /// </summary>
        /// <param name="operCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// 增加{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// LAST_MONTH_PURCHASE_COST,   --上期结存购入金额
         /// CURRENT_MONTH_PURCHASE_COST,  --本期结存购入金额
         /// IN_PURCHASE_COST,                  --入库购入金额
         /// OUT_PURCHASE_COST,               --出库购入金额
        ///  SPECIAL_IN_PURCHASE_COST,     --特殊入库购入金额
        ///  SPECIAL_OUT_PURCHASE_COST,  --特殊出库购入金额
        ///  CHECK_PROFIT_PURCHASE_COST,--盘盈购入金额
        ///  CHECK_LOSS_PURCHASE_COST    --盘亏购入金额
        /// <returns></returns>
        private DataTable CreatMonthStoreDept(string operCode, string deptCode, DateTime lastStatDate,DateTime dtBegin, DateTime dtEnd)
        {
            string sql = @"                                        
                     SELECT    DRUG_DEPT_CODE,                         --科室编码
	                           TO_DATE,                                --终止日期（月结时间）
	                           FROM_DATE,                              --起始日期（上次月结时间）
	                           LAST_MONTH_COST,                        --上期结存金额
	                           CURRENT_MONTH_COST,                     --本期结存金额
	                           IN_COST,                                --入库金额
	                           OUT_COST,                               --出库金额
	                           SPECIAL_IN_COST,                        --特殊入库金额
	                           SPECIAL_OUT_COST,                       --特殊出库金额
	                           CHECK_PROFIT_COST,                      --盘盈金额
	                           CHECK_LOSS_COST,                        --盘亏金额
	                           WASTE_COST,                             --报损金额
	                           ADJUST_PROFIT_COST,                     --调盈金额
	                           ADJUST_LOSS_COST,                       --调亏金额
	                           CURRENT_STORE_COST,                     --
	                           EXPEND_COST,                            --消耗金额
	                           OPER_CODE,                              --操作员编码
	                           OPER_NAME,                              --操作员名称
	                           OPER_DATE,                               --操作日期
                               LAST_MONTH_PURCHASE_COST,   --上期结存购入金额
                               CURRENT_MONTH_PURCHASE_COST,  --本期结存购入金额
                                IN_PURCHASE_COST,                  --入库购入金额
                                OUT_PURCHASE_COST,               --出库购入金额
                                SPECIAL_IN_PURCHASE_COST,     --特殊入库购入金额
                                SPECIAL_OUT_PURCHASE_COST,  --特殊出库购入金额
                                CHECK_PROFIT_PURCHASE_COST,--盘盈购入金额
                                CHECK_LOSS_PURCHASE_COST    --盘亏购入金额
                    FROM     PHA_COM_MS_DEPT
                    WHERE 	 DRUG_DEPT_CODE = '{0}'  
                    AND      TO_DATE = TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS')             
                                     ";

            if (this.isStatTogether == true)        //全院月结
            {
                sql = @"                                        
                     SELECT    DRUG_DEPT_CODE,                         --科室编码
	                           TO_DATE,                                --终止日期（月结时间）
	                           FROM_DATE,                              --起始日期（上次月结时间）
	                           LAST_MONTH_COST,                        --上期结存金额
	                           CURRENT_MONTH_COST,                     --本期结存金额
	                           IN_COST,                                --入库金额
	                           OUT_COST,                               --出库金额
	                           SPECIAL_IN_COST,                        --特殊入库金额
	                           SPECIAL_OUT_COST,                       --特殊出库金额
	                           CHECK_PROFIT_COST,                      --盘盈金额
	                           CHECK_LOSS_COST,                        --盘亏金额
	                           WASTE_COST,                             --报损金额
	                           ADJUST_PROFIT_COST,                     --调盈金额
	                           ADJUST_LOSS_COST,                       --调亏金额
	                           CURRENT_STORE_COST,                     --
	                           EXPEND_COST,                            --消耗金额
	                           OPER_CODE,                              --操作员编码
	                           OPER_NAME,                              --操作员名称
	                           OPER_DATE,                               --操作日期
                                LAST_MONTH_PURCHASE_COST,   --上期结存购入金额
                               CURRENT_MONTH_PURCHASE_COST,  --本期结存购入金额
                                IN_PURCHASE_COST,                  --入库购入金额
                                OUT_PURCHASE_COST,               --出库购入金额
                                SPECIAL_IN_PURCHASE_COST,     --特殊入库购入金额
                                SPECIAL_OUT_PURCHASE_COST,  --特殊出库购入金额
                                CHECK_PROFIT_PURCHASE_COST,--盘盈购入金额
                                CHECK_LOSS_PURCHASE_COST    --盘亏购入金额
                    FROM     PHA_COM_MS_DEPT
                    WHERE 	 TO_DATE = TO_DATE('{0}','YYYY-MM-DD HH24:MI:SS')  
                    AND      DRUG_DEPT_CODE IN (SELECT R.DEPT_CODE FROM PHA_COM_DEPT R WHERE R.STORE_FLAG = '1')
                    ORDER BY DRUG_DEPT_CODE           
                                     ";

                sql = string.Format( sql, lastStatDate.ToString() );
            }
            else
            {
                sql = string.Format( sql, deptCode, lastStatDate.ToString() );
            }

            DataSet ds = new DataSet();
            this.dataManager.ExecQuery( sql, ref ds );
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }
            DataTable dtDept = ds.Tables[0];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtDept.Columns["DRUG_DEPT_CODE"];

            dtDept.PrimaryKey = keys;

            DataRow dr = null;
            decimal lastMonthCost = 0;
            decimal lastMonthPurchaseCost = 0;

            DateTime sysDate = this.dataManager.GetDateTimeFromSysDateTime();

            foreach (DataRow tempDr in dtDept.Rows)
            {
                lastMonthCost = Neusoft.FrameWork.Function.NConvert.ToDecimal( tempDr["CURRENT_MONTH_COST"].ToString() );
                lastMonthPurchaseCost = Neusoft.FrameWork.Function.NConvert.ToDecimal(tempDr["CURRENT_MONTH_PURCHASE_COST"].ToString());

                tempDr["DRUG_DEPT_CODE"] = deptCode;              //科室编码
                tempDr["TO_DATE"] = dtEnd.ToString();               //终止日期（月结时间）
                tempDr["FROM_DATE"] = dtBegin.ToString();               //起始日期（上次月结时间）
                tempDr["LAST_MONTH_COST"] = lastMonthCost;               //上期结存金额
                tempDr["CURRENT_MONTH_COST"] = "0.0000";                //本期结存金额
                tempDr["IN_COST"] = "0.0000";                //入库金额
                tempDr["OUT_COST"] = "0.0000";                //出库金额
                tempDr["SPECIAL_IN_COST"] = "0.0000";                 //特殊入库金额
                tempDr["SPECIAL_OUT_COST"] = "0.0000";             //特殊出库金额
                tempDr["CHECK_PROFIT_COST"] = "0.0000";             //盘盈金额
                tempDr["CHECK_LOSS_COST"] = "0.0000";               //盘亏金额
                tempDr["WASTE_COST"] = "0.0000";               //报损金额
                tempDr["ADJUST_PROFIT_COST"] = "0.0000";                //调盈金额
                tempDr["ADJUST_LOSS_COST"] = "0.0000";               //调亏金额
                tempDr["CURRENT_STORE_COST"] = "0.0000";
                tempDr["EXPEND_COST"] = "0.0000";                 //消耗金额
                tempDr["OPER_CODE"] = operCode;                //操作员编码
                tempDr["OPER_NAME"] = "";               //操作员名称
                tempDr["OPER_DATE"] = sysDate;               //操作日期
                tempDr["LAST_MONTH_PURCHASE_COST"] = lastMonthPurchaseCost;   //上期结存购入金额
                tempDr["CURRENT_MONTH_PURCHASE_COST"] = "0.0000";                  //本期结存购入金额
                tempDr["IN_PURCHASE_COST"] = "0.0000";                                          //入库购入金额
                tempDr["OUT_PURCHASE_COST"] = "0.0000";                                       //出库购入金额
                tempDr["SPECIAL_IN_PURCHASE_COST"] = "0.0000";                             //特殊入库购入金额
                tempDr["SPECIAL_OUT_PURCHASE_COST"] = "0.0000";                          //特殊出库购入金额
                tempDr["CHECK_PROFIT_PURCHASE_COST"] = "0.0000";                        //盘盈购入金额
                tempDr["CHECK_LOSS_PURCHASE_COST"] = "0.0000";                           //盘亏购入金额
                                        
            }

            return dtDept;
        }

        /// <summary>
        /// 月结-非存储过程
        /// </summary>
        /// <param name="operCode"></param>
        /// <param name="deptCode"></param>
        /// <param name="dtBegin"></param>
        /// <param name="dtEnd"></param>
        /// <returns></returns>
        public int ExeMonthStore(string operCode, string deptCode, DateTime dtBegin, DateTime dtEnd)
        {
            DateTime lastStatDate = this.GetMonthStoreLastDateTime( deptCode );

            #region 载入要用到的DataTable

            //上次月结明细
            //DataTable dtLastItem = this.QueryLastMonthStat( deptCode ,dtEnd);
            DataTable dtLastItem = this.QueryLastMonthStat(deptCode, dtBegin);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
            if (dtLastItem == null)
            {
                return -1;
            }
            this.WriteLog( "加载上次入库明细",0 );
            long m1 = System.DateTime.Now.Ticks;

            //本次月结明细
            DataTable dtItem = this.CreatMonthStoreItem( operCode, deptCode, dtBegin, dtEnd );
            if (dtItem == null)
            {
                return -1;
            }
            long m2 = System.DateTime.Now.Ticks;

            this.WriteLog( "本次月结明细", new DateTime( m2 - m1 ).Millisecond );

            long m3 = System.DateTime.Now.Ticks;            

            //本次月结汇总
            DataTable dtDept = this.CreatMonthStoreDept( operCode, deptCode, lastStatDate,dtBegin, dtEnd );
            if (dtDept == null)
            {
                return -1;
            }
            long m4 = System.DateTime.Now.Ticks;

            this.WriteLog( "本次月结汇总", new DateTime( m4 - m3 ).Millisecond );

            long m5 = System.DateTime.Now.Ticks;
            //入库
            DataTable dtInput = this.QueryInput( deptCode, dtBegin, dtEnd );
            if (dtInput == null)
            {
                return -1;
            }

            long m6 = System.DateTime.Now.Ticks;

            this.WriteLog( "入库", new DateTime( m6 - m5 ).Millisecond );

            long m7 = System.DateTime.Now.Ticks;
            //出库
            DataTable dtOuput = this.QueryOutput( deptCode, dtBegin, dtEnd );
            if (dtOuput == null)
            {
                return -1;
            }
            long m8 = System.DateTime.Now.Ticks;
            this.WriteLog( "出库", new DateTime( m8 - m7 ).Millisecond );

            long m9 = System.DateTime.Now.Ticks;
            //患者发药消耗
            DataTable dtDispensingOutput = this.QueryDispensingOutput( deptCode, dtBegin, dtEnd );
            if (dtDispensingOutput == null)
            {
                return -1;
            }
            long m10 = System.DateTime.Now.Ticks;
            this.WriteLog( "患者发药消耗", new DateTime( m10 - m9 ).Millisecond );

            long m11 = System.DateTime.Now.Ticks;
            //盘点
            DataTable dtCheck = this.QueryCheck( deptCode, dtBegin, dtEnd );
            if (dtCheck == null)
            {
                return -1;
            }
            long m12 = System.DateTime.Now.Ticks;

            this.WriteLog( "盘点", new DateTime( m12 - m11 ).Millisecond );

            long m13 = System.DateTime.Now.Ticks;
            //调价
            DataTable dtAdjust = this.QueryAdjust( deptCode, dtBegin, dtEnd );
            if (dtAdjust == null)
            {
                return -1;
            }
            long m14 = System.DateTime.Now.Ticks;
            this.WriteLog( "调价", new DateTime( m14 - m13 ).Millisecond );
            #endregion

            this.WriteLog( "开始月结明细计算 循环处理",0);

            long m15 = System.DateTime.Now.Ticks;

            decimal currentMonthCost = 0;

            System.Collections.Generic.Dictionary<string, string> statDrugDept = new Dictionary<string, string>();

            #region 月结明细

            foreach (DataRow dr in dtItem.Rows)
            {
                object[] key = new string[2];
                key[0] = dr["DRUG_DEPT_CODE"].ToString();
                key[1] = dr["DRUG_CODE"].ToString();

                if (statDrugDept.ContainsKey( dr["DRUG_DEPT_CODE"].ToString() ) == false)
                {
                    statDrugDept.Add( dr["DRUG_DEPT_CODE"].ToString(), null );
                }

                #region 上期

                DataRow drLast = dtLastItem.Rows.Find( key );
                if (drLast == null)
                {
                    drLast = dtLastItem.NewRow();
                    drLast["CURRENT_MONTH_NUM"] = 0;
                    drLast["CURRENT_MONTH_COST"] = 0;
                    drLast["CURRENT_MONTH_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                dr["LAST_MONTH_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drLast["CURRENT_MONTH_NUM"].ToString() ).ToString();
                dr["LAST_MONTH_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drLast["CURRENT_MONTH_COST"].ToString() ).ToString();
                dr["LAST_MONTH_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drLast["CURRENT_MONTH_PURCHASE_COST"].ToString()).ToString();//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}

                #endregion

                #region 一般入库/特殊入库

                object[] inputKey = new string[3];
                inputKey[0] = dr["DRUG_DEPT_CODE"].ToString();
                inputKey[1] = dr["DRUG_CODE"].ToString();
                inputKey[2] = "0";

                DataRow drInput = dtInput.Rows.Find( inputKey );
                if (drInput != null)
                {
                    dr["IN_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drInput["IN_NUM"] );
                    dr["IN_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drInput["RETAIL_COST"] );
                    dr["IN_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drInput["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }
                else
                {
                    dr["IN_NUM"] = 0;
                    dr["IN_COST"] = 0;
                    dr["IN_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                inputKey[2] = "1";
                DataRow drSpeInput = dtInput.Rows.Find( inputKey );
                if (drSpeInput != null)
                {
                    dr["SPECIAL_IN_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drSpeInput["IN_NUM"]);
                    dr["SPECIAL_IN_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drSpeInput["RETAIL_COST"]);
                    dr["SPECIAL_IN_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drSpeInput["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }
                else
                {
                    dr["SPECIAL_IN_NUM"] = 0;
                    dr["SPECIAL_IN_COST"] = 0;
                    dr["SPECIAL_IN_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                #endregion

                #region 一般出库/特殊出库

                object[] outputKey = new string[3];
                outputKey[0] = dr["DRUG_DEPT_CODE"].ToString();
                outputKey[1] = dr["DRUG_CODE"].ToString();
                outputKey[2] = "0";

                DataRow drOutput = dtOuput.Rows.Find( outputKey );
                if (drOutput != null)
                {
                    dr["OUT_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drOutput["OUT_NUM"] );
                    dr["OUT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drOutput["SALE_COST"] );
                    dr["OUT_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drOutput["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }
                else
                {
                    dr["OUT_NUM"] = 0;
                    dr["OUT_COST"] = 0;
                    dr["OUT_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                outputKey[2] = "1";
                DataRow drSpeOutput = dtOuput.Rows.Find( outputKey );
                if (drSpeOutput != null)
                {
                    dr["SPECIAL_OUT_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drSpeOutput["OUT_NUM"] );
                    dr["SPECIAL_OUT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drSpeOutput["SALE_COST"] );
                    dr["SPECIAL_OUT_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drSpeOutput["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }
                else
                {
                    dr["SPECIAL_OUT_NUM"] = 0;
                    dr["SPECIAL_OUT_COST"] = 0;
                    dr["SPECIAL_OUT_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                #endregion

                #region 发药消耗

                DataRow drDispensingOutput = dtDispensingOutput.Rows.Find( key );

                if (drDispensingOutput != null)
                {
                    dr["EXPEND_NUM"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drDispensingOutput["OUT_NUM"].ToString() );
                    dr["EXPEND_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drDispensingOutput["SALE_COST"].ToString() );
                }
                else
                {
                    dr["EXPEND_NUM"] = 0;
                    dr["EXPEND_COST"] = 0;
                }

                #endregion

                #region 盘点

                DataRow drCheck = dtCheck.Rows.Find( key );

                if (drCheck != null)
                {
                    decimal checkQty = Neusoft.FrameWork.Function.NConvert.ToDecimal( drCheck["QTY"] );
                    if (checkQty >= 0)
                    {
                        dr["CHECK_PROFIT_NUM"] = checkQty;
                        dr["CHECK_PROFIT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drCheck["COST"] );
                        dr["CHECK_PROFIT_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drCheck["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                    }
                    else
                    {
                        dr["CHECK_LOSS_NUM"] = checkQty;
                        dr["CHECK_LOSS_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal( drCheck["COST"] );
                        dr["CHECK_LOSS_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drCheck["PURCHASE_COST"]);//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                    }
                }
                else
                {
                    dr["CHECK_PROFIT_NUM"] = 0;
                    dr["CHECK_PROFIT_COST"] = 0;
                    dr["CHECK_PROFIT_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                    dr["CHECK_LOSS_NUM"] = 0;
                    dr["CHECK_LOSS_COST"] = 0;
                    dr["CHECK_LOSS_PURCHASE_COST"] = 0;//{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                }

                #endregion

                #region 调价

                DataRow drAdjust = dtAdjust.Rows.Find( key );

                if (drAdjust != null)
                {
                    decimal adjustCost = Neusoft.FrameWork.Function.NConvert.ToDecimal( drAdjust["COST"] );
                    if (adjustCost >= 0)
                    {
                        dr["ADJUST_PROFIT_COST"] = adjustCost;
                    }
                    else
                    {
                        dr["ADJUST_LOSS_COST"] = adjustCost;
                    }
                }
                else
                {
                    dr["ADJUST_PROFIT_COST"] = 0;
                    dr["ADJUST_LOSS_COST"] = 0;
                }
                #endregion
            }
            #endregion

            long m16 = System.DateTime.Now.Ticks;
            this.WriteLog( "结束月结明细计算，开始月结汇总计算", new DateTime( m16 - m15 ).Millisecond );

            long m17 = System.DateTime.Now.Ticks;

            #region 月结汇总

            DateTime sysDate = this.dataManager.GetDateTimeFromSysDateTime();

            foreach (string deptKey in statDrugDept.Keys)
            {
                DataRow drDept = dtDept.Rows.Find(new string[] { deptKey });

                if (drDept == null)
                {
                    drDept = dtDept.NewRow();

                    drDept["DRUG_DEPT_CODE"] = deptKey;                     //科室编码
                    drDept["TO_DATE"] = dtEnd.ToString();                   //终止日期（月结时间）
                    drDept["FROM_DATE"] = dtBegin.ToString();               //起始日期（上次月结时间）
                    drDept["LAST_MONTH_COST"] = 0;                          //上期结存金额
                    drDept["OPER_CODE"] = operCode;                         //操作员编码
                    drDept["OPER_NAME"] = "";                               //操作员名称
                    drDept["OPER_DATE"] = sysDate;                          //操作日期

                    drDept["CURRENT_MONTH_COST"] = "0.0000";                //本期结存金额
                    drDept["IN_COST"] = "0.0000";                //入库金额
                    drDept["OUT_COST"] = "0.0000";                //出库金额
                    drDept["SPECIAL_IN_COST"] = "0.0000";                 //特殊入库金额
                    drDept["SPECIAL_OUT_COST"] = "0.0000";             //特殊出库金额
                    drDept["CHECK_PROFIT_COST"] = "0.0000";             //盘盈金额
                    drDept["CHECK_LOSS_COST"] = "0.0000";               //盘亏金额
                    drDept["WASTE_COST"] = "0.0000";               //报损金额
                    drDept["ADJUST_PROFIT_COST"] = "0.0000";                //调盈金额
                    drDept["ADJUST_LOSS_COST"] = "0.0000";               //调亏金额
                    drDept["CURRENT_STORE_COST"] = "0.0000";
                    drDept["EXPEND_COST"] = "0.0000";                 //消耗金额
                    drDept["LAST_MONTH_PURCHASE_COST"] = 0;//上期结存购入金额{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                    drDept["CURRENT_MONTH_PURCHASE_COST"] = "0.0000";//本期结存购入金额
                    drDept["IN_PURCHASE_COST"] = "0.0000";       //入库购入金额
                    drDept["OUT_PURCHASE_COST"] = "0.0000";    //出库购入金额
                    drDept["SPECIAL_IN_PURCHASE_COST"] = "0.0000";      //特殊入库购入金额
                    drDept["SPECIAL_OUT_PURCHASE_COST"] = "0.0000";   //特殊出库购入金额
                    drDept["CHECK_PROFIT_PURCHASE_COST"] = "0.0000";    //盘盈购入金额
                    drDept["CHECK_LOSS_PURCHASE_COST"] = "0.0000";       //盘亏购入金额

                    dtDept.Rows.Add(drDept);
                }

                string filter = string.Format("DRUG_DEPT_CODE = '{0}'", drDept["DRUG_DEPT_CODE"].ToString());

                drDept["CURRENT_MONTH_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(STORE_COST)", filter));  //本期结存金额
                drDept["CURRENT_STORE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(drDept["CURRENT_MONTH_COST"]);        
                drDept["IN_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(IN_COST)", filter));               //入库金额
                drDept["OUT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(OUT_COST)", filter));         //出库金额
                //{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
                drDept["CURRENT_MONTH_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(CURRENT_MONTH_PURCHASE_COST)", filter)); //本期结存购入金额
                drDept["IN_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(IN_PURCHASE_COST)", filter));                     //入库购入金额
                drDept["OUT_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(OUT_PURCHASE_COST)", filter));               //出库购入金额
                drDept["SPECIAL_IN_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(SPECIAL_IN_PURCHASE_COST)", filter));   //特殊入库购入金额
                drDept["SPECIAL_OUT_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(SPECIAL_OUT_PURCHASE_COST)", filter));     //特殊出库购入金额
                drDept["SPECIAL_OUT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(SPECIAL_OUT_COST)", filter));           //特殊出库金额
                drDept["SPECIAL_IN_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(SPECIAL_IN_COST)", filter));                 //特殊入库金额
                drDept["CHECK_PROFIT_PURCHASE_COST"]=Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(CHECK_PROFIT_PURCHASE_COST)", filter));//盘盈购入金额
                drDept["CHECK_LOSS_PURCHASE_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(CHECK_LOSS_PURCHASE_COST)", filter));//盘亏购入金额
                drDept["CHECK_PROFIT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(CHECK_PROFIT_COST)", filter));       //盘盈金额
                drDept["CHECK_LOSS_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(CHECK_LOSS_COST)", filter));             //盘亏金额
                drDept["ADJUST_PROFIT_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(ADJUST_PROFIT_COST)", filter));    //调盈金额
                drDept["ADJUST_LOSS_COST"] = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtItem.Compute("SUM(ADJUST_LOSS_COST)", filter));          //调亏金额

                //decimal cost = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtCheck.Compute("SUM(COST)", filter));
                //if (cost > 0)
                //{
                //    drDept["CHECK_PROFIT_COST"] = cost;
                //    drDept["CHECK_LOSS_COST"] = 0;
                //}
                //else
                //{
                //    drDept["CHECK_LOSS_COST"] = cost;
                //    drDept["CHECK_PROFIT_COST"] = 0;
                //}

                //cost = Neusoft.FrameWork.Function.NConvert.ToDecimal(dtAdjust.Compute("SUM(COST)", filter));
                //if (cost > 0)
                //{
                //    drDept["ADJUST_PROFIT_COST"] = cost;
                //    drDept["ADJUST_LOSS_COST"] = 0;
                //}
                //else
                //{
                //    drDept["ADJUST_PROFIT_COST"] = 0;
                //    drDept["ADJUST_LOSS_COST"] = cost;
                //}
            }

            #endregion

            long m18 = System.DateTime.Now.Ticks;
            this.WriteLog( "结束月结汇总计算，开始月结数据保存", new DateTime( m18 - m17 ).Millisecond );

            long m19 = System.DateTime.Now.Ticks;

            #region 插入月结数据

            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();
            this.dataManager.SetTrans( Neusoft.FrameWork.Management.PublicTrans.Trans );

            if (this.InsertMonthStoreDept( dtDept ) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( "月结汇总记录存储发生错误" + this.dataManager.Err ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);                   
                return -1;
            }
            if (this.InsertMonthStoreItem( dtItem ) < 0)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show( "月结明细记录存储发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );        
                return -1;
            }

            #endregion

            long m20 = System.DateTime.Now.Ticks;

            this.WriteLog( "月结计算完毕", new DateTime( m20 - m19 ).Millisecond );

            Neusoft.FrameWork.Management.PublicTrans.Commit();
            MessageBox.Show( "月结成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );

            #region {988F66A8-1744-4921-8A6F-95D0E75B0024}
            this.dtpBeginStat.Value = this.GetMonthStoreLastDateTime(deptCode);
            this.dtpEndStat.Value = this.dataManager.GetDateTimeFromSysDateTime();
            this.dtpBeginStat.Enabled = false;
            #endregion

            this.ShowMonthStoreHead();//{5BAC0ACF-80DC-443e-A194-FF791E261714}

            return 1;
        }

        /// <summary>
        /// 插入月结汇总
        /// </summary>
        /// <param name="dtDept"></param>
        /// 增加{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        /// LAST_MONTH_PURCHASE_COST,     CURRENT_MONTH_PURCHASE_COST,
        /// IN_PURCHASE_COST,      OUT_PURCHASE_COST,      SPECIAL_IN_PURCHASE_COST,     SPECIAL_OUT_PURCHASE_COST,
        /// CHECK_PROFIT_PURCHASE_COST,       CHECK_LOSS_PURCHASE_COST
        /// <returns></returns>
        private int InsertMonthStoreDept(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string execSql = @"INSERT INTO PHA_COM_MS_DEPT                 --药品月结表
                                  ( DRUG_DEPT_CODE,      TO_DATE,             FROM_DATE, 
                                    LAST_MONTH_COST,     CURRENT_MONTH_COST,  IN_COST,             
                                    OUT_COST,            SPECIAL_IN_COST,     SPECIAL_OUT_COST,    
                                    CHECK_PROFIT_COST,   CHECK_LOSS_COST,     ADJUST_PROFIT_COST,  
                                    ADJUST_LOSS_COST,    CURRENT_STORE_COST,  EXPEND_COST,      
                                    OPER_CODE,           OPER_DATE,     LAST_MONTH_PURCHASE_COST,     CURRENT_MONTH_PURCHASE_COST,
                                    IN_PURCHASE_COST,      OUT_PURCHASE_COST,      SPECIAL_IN_PURCHASE_COST,     SPECIAL_OUT_PURCHASE_COST,
                                    CHECK_PROFIT_PURCHASE_COST,       CHECK_LOSS_PURCHASE_COST                                    
                                   )        
                              VALUES
                                  ('{0}', TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS'),TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS'),
                                    {3},  {4},   {5},
                                    {6},  {7},   {8},
                                    {9},  {10},  {11},
                                    {12}, {13},  {14},
                                    {15}, SYSDATE,{17},{18},{19},{20},{21},{22},{23},{24}                                    
                                   )";

                execSql = string.Format(execSql, dr["DRUG_DEPT_CODE"].ToString(), dr["TO_DATE"].ToString(), dr["FROM_DATE"].ToString(),
                                                dr["LAST_MONTH_COST"].ToString(), dr["CURRENT_MONTH_COST"].ToString(), dr["IN_COST"].ToString(),
                                                dr["OUT_COST"].ToString(), dr["SPECIAL_IN_COST"].ToString(), dr["SPECIAL_OUT_COST"].ToString(),
                                                dr["CHECK_PROFIT_COST"].ToString(), dr["CHECK_LOSS_COST"].ToString(), dr["ADJUST_PROFIT_COST"].ToString(),
                                                dr["ADJUST_LOSS_COST"].ToString(), dr["CURRENT_STORE_COST"].ToString(), dr["EXPEND_COST"].ToString(),
                                                dr["OPER_CODE"].ToString(), dr["OPER_DATE"].ToString(), dr["LAST_MONTH_PURCHASE_COST"].ToString(),
                                                dr["CURRENT_MONTH_PURCHASE_COST"].ToString(), dr["IN_PURCHASE_COST"].ToString(), dr["OUT_PURCHASE_COST"].ToString(),
                                                dr["SPECIAL_IN_PURCHASE_COST"].ToString(), dr["SPECIAL_OUT_PURCHASE_COST"].ToString(), dr["CHECK_PROFIT_PURCHASE_COST"].ToString(),
                                                dr["CHECK_LOSS_PURCHASE_COST"].ToString());

                if (this.dataManager.ExecNoQuery( execSql ) < 0)
                {
                    return -1;
                }
            }

            return 1;
        }

        /// <summary>
        /// 插入月结明细
        /// </summary>
        /// <param name="dtItem"></param>
        /// 增加{A1F19F7E-69AE-407b-B033-D5FCA2BF2A0B}
        ///  LAST_MONTH_PURCHASE_COST,     CURRENT_MONTH_PURCHASE_COST,      IN_PURCHASE_COST,   
        /// OUT_PURCHASE_COST,     SPECIAL_IN_PURCHASE_COST,     SPECIAL_OUT_PURCHASE_COST,
        /// CHECK_PROFIT_PURCHASE_COST,           CHECK_LOSS_PURCHASE_COST
        /// <returns></returns>
        private int InsertMonthStoreItem(DataTable dtItem)
        {
            #region Sql 注释

            /*
             *  --13 上期结存数量    --14 上期结存金额   --15 本期结存数量
                --16 本期结存金额（经过各种情况计算得出）   --入库数量    --入库金额
                --19 出库数量        --出库金额
                --21 特殊入库数量    --特殊入库金额
                --23 特殊出库数量    --特殊出库金额
                --25 盘盈数量        --盘盈金额
                --27 盘亏数量        --盘亏金额
                --29 调盈金额        --调亏金额
                --31 本期药库结存金额（不同于财务的结存金额）   --消耗出库数量   
                --33 消耗出库金额    --操作员编码   --35 操作员日期
                --36 上期结存购入金额  --本期结存购入金额  --入库购入金额
                --39 出库购入金额  --特殊入库购入金额 --特殊出库购入金额
                --42 盘盈购入金额  --43 盘亏购入金额
             * 
             * */

            #endregion

            foreach (DataRow dr in dtItem.Rows)
            {
                if (string.IsNullOrEmpty( dr["WHOLESALE_PRICE"].ToString()) == true )
                {
                    dr["WHOLESALE_PRICE"] = 0;
                }

                string execSql = @"
                INSERT INTO pha_com_ms_drug      --药品月结表
                          ( drug_dept_code,        drug_code,        to_date,         from_date,           
                            trade_name,            specs,            min_unit,        pack_unit,       
                            pack_qty,              retail_price,     wholesale_price, 
                            drug_type,             drug_quality,          
                            last_month_num,        last_month_cost,  current_month_num,   
                            current_month_cost,    in_num,           in_cost,             
                            out_num,               out_cost,         
                            special_in_num,        special_in_cost,    
                            special_out_num,       special_out_cost,   
                            check_profit_num,      check_profit_cost,   
                            check_loss_num,        check_loss_cost,     
                            adjust_profit_cost,    adjust_loss_cost,    
                            CURRENT_STORE_COST,    EXPEND_NUM,          
                            EXPEND_COST,           oper_code,         oper_date,
                            LAST_MONTH_PURCHASE_COST,     CURRENT_MONTH_PURCHASE_COST,      IN_PURCHASE_COST,   
                            OUT_PURCHASE_COST,     SPECIAL_IN_PURCHASE_COST,     SPECIAL_OUT_PURCHASE_COST,
                            CHECK_PROFIT_PURCHASE_COST,           CHECK_LOSS_PURCHASE_COST                         
                           )           
                     VALUES
                          ( 
                            '{0}', '{1}', to_date('{2}','yyyy-mm-dd hh24:mi:ss'),to_date('{3}','yyyy-mm-dd hh24:mi:ss'),
                            '{4}', '{5}', '{6}','{7}',
                            {8},  {9},  {10},
                            '{11}',   '{12}',
                            {13},      {14},      {15},
                            {16},      {17},      {18},
                            {19},      {20},      {21},         {22},
                            {23},      {24},      {25},         {26},
                            {27},      {28},      {29},         {30},
                            {31},      {32},      {33},         '{34}',                            
                            SYSDATE,  {36},   {37},         {38},
                            {39},      {40},      {41},         {42},
                            {43})    ";

                execSql = string.Format( execSql, dr["DRUG_DEPT_CODE"].ToString(), dr["DRUG_CODE"].ToString(),dr["TO_DATE"].ToString(), dr["FROM_DATE"].ToString(),
                                                dr["TRADE_NAME"].ToString(), dr["SPECS"].ToString(),dr["MIN_UNIT"].ToString(),dr["PACK_UNIT"].ToString(),
                                                dr["PACK_QTY"].ToString(),dr["RETAIL_PRICE"].ToString(),dr["WHOLESALE_PRICE"].ToString(),
                                                dr["DRUG_TYPE"].ToString(),dr["DRUG_QUALITY"].ToString(),
                                                dr["LAST_MONTH_NUM"].ToString(), dr["LAST_MONTH_COST"].ToString(), dr["STORE_SUM"].ToString(),
                                                dr["STORE_COST"].ToString(), dr["IN_NUM"].ToString(), dr["IN_COST"].ToString(),
                                                dr["OUT_NUM"].ToString(),dr["OUT_COST"].ToString(), 
                                                dr["SPECIAL_IN_NUM"].ToString(),dr["SPECIAL_IN_COST"].ToString(), 
                                                dr["SPECIAL_OUT_NUM"].ToString(),dr["SPECIAL_OUT_COST"].ToString(),
                                                dr["CHECK_PROFIT_NUM"].ToString(),dr["CHECK_PROFIT_COST"].ToString(), 
                                                dr["CHECK_LOSS_NUM"].ToString(), dr["CHECK_LOSS_COST"].ToString(), 
                                                dr["ADJUST_PROFIT_COST"].ToString(),dr["ADJUST_LOSS_COST"].ToString(),
                                                dr["STORE_COST"].ToString(), dr["EXPEND_NUM"].ToString(),
                                                dr["EXPEND_COST"].ToString(),dr["OPER_CODE"].ToString(),dr["OPER_DATE"].ToString(),
                                                dr["LAST_MONTH_PURCHASE_COST"].ToString(),dr["CURRENT_MONTH_PURCHASE_COST"].ToString(),
                                                dr["IN_PURCHASE_COST"].ToString(), dr["OUT_PURCHASE_COST"].ToString(), dr["SPECIAL_IN_PURCHASE_COST"].ToString(),
                                                dr["SPECIAL_OUT_PURCHASE_COST"].ToString(), dr["CHECK_PROFIT_PURCHASE_COST"].ToString(),
                                                dr["CHECK_LOSS_PURCHASE_COST"].ToString()
                                         );

                if (this.dataManager.ExecNoQuery( execSql ) < 0)
                {
                    return -1;
                }
            }
            return 1;
        }

        /// <summary>
        /// 日志书写
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        private int WriteLog(string msg,int millisecond)
        {
            this.richTextBox1.Text = this.richTextBox1.Text + msg + "  耗时:" + millisecond.ToString() + "\n";
            return 1;
        }

        /// <summary>
        /// 查看出库明细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ShowOutListDetail(object info)
        {
            Neusoft.FrameWork.Models.NeuObject tempOutList = info as Neusoft.FrameWork.Models.NeuObject;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            System.Collections.ArrayList alDetail = itemManager.QueryOutputInfo( tempOutList.Memo, tempOutList.ID, "1" );

            if (alDetail == null)
            {
                System.Windows.Forms.MessageBox.Show( "未正确获取出库信息" + itemManager.Err);
                return -1;
            }

            this.ucVeriftDataDisplay.DetailSheet.Rows.Count = 0;
            this.ucVeriftDataDisplay.DetailSheet.Columns[2].Label = "计划出库量";
            this.ucVeriftDataDisplay.DetailSheet.Columns[3].Label = "审批出库量";
            foreach (Neusoft.HISFC.Models.Pharmacy.Output output in alDetail)
            {
                this.ucVeriftDataDisplay.DetailSheet.Rows.Add( 0, 1 );
                this.ucVeriftDataDisplay.DetailSheet.Cells[0, 0].Text = output.Item.Name;
                this.ucVeriftDataDisplay.DetailSheet.Cells[0, 1].Text = output.Item.Specs;
                this.ucVeriftDataDisplay.DetailSheet.Cells[0, 2].Text = output.Quantity.ToString();
                this.ucVeriftDataDisplay.DetailSheet.Cells[0, 3].Text = output.Operation.ExamQty.ToString();
                this.ucVeriftDataDisplay.DetailSheet.Cells[0, 4].Text = output.Item.MinUnit;
            }

            return 1;
        }

        /// <summary>
        /// 加载显示盘点明细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int ShowCheckListDetail(object info)
        {
            Neusoft.FrameWork.Models.NeuObject tempCheck = info as Neusoft.FrameWork.Models.NeuObject;

            Neusoft.HISFC.BizLogic.Pharmacy.Item itemManager = new Neusoft.HISFC.BizLogic.Pharmacy.Item();

            System.Collections.ArrayList alCheckDetil = itemManager.QueryCheckDetailByCheckCode( tempCheck.Memo, tempCheck.ID );

            if (alCheckDetil == null)
            {
                System.Windows.Forms.MessageBox.Show( "未正确获取盘点信息" + itemManager.Err );
                return -1;
            }

             this.ucVeriftDataDisplay.DetailSheet.Rows.Count = 0;
             this.ucVeriftDataDisplay.DetailSheet.Columns[2].Label = "封帐数量";
             this.ucVeriftDataDisplay.DetailSheet.Columns[3].Label = "实盘数量";
             foreach (Neusoft.HISFC.Models.Pharmacy.Check checkInstance in alCheckDetil)
             {
                 this.ucVeriftDataDisplay.DetailSheet.Rows.Add( 0, 1 );
                 this.ucVeriftDataDisplay.DetailSheet.Cells[0, 0].Text = checkInstance.Item.Name;
                 this.ucVeriftDataDisplay.DetailSheet.Cells[0, 1].Text = checkInstance.Item.Specs;
                 this.ucVeriftDataDisplay.DetailSheet.Cells[0, 2].Text = checkInstance.FStoreQty.ToString();
                 this.ucVeriftDataDisplay.DetailSheet.Cells[0, 3].Text = checkInstance.CStoreQty.ToString();
                 this.ucVeriftDataDisplay.DetailSheet.Cells[0, 4].Text = checkInstance.Item.MinUnit;
             }

             return 1;
        }

        /// <summary>
        /// 月结校验
        /// </summary>
        /// <param name="deptCode">科室编码</param>
        /// <returns></returns>
        private bool Verify()
        {
            if (this.cmbDept.Tag == null || string.IsNullOrEmpty( this.cmbDept.Tag.ToString() ) == true)
            {
                MessageBox.Show( "请选择月结科室", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            this.drugDeptCode = this.cmbDept.Tag.ToString();

            string verifySql = string.Empty;

            #region 校验是否存在未结存的盘点单

            verifySql = @"
                                SELECT  S.DEPT_NAME,T.CHECK_CODE,T.DRUG_DEPT_CODE
                                FROM    PHA_COM_CHECKSTATIC T,COM_DEPARTMENT S
                                WHERE   T.DRUG_DEPT_CODE = S.DEPT_CODE
                                AND     T.DRUG_DEPT_CODE = '{0}'
                                AND     T.CHECK_STATE = '0' ";

            if (this.isStatTogether == true)            //全院月结
            {
                verifySql = @"
                                SELECT  S.DEPT_NAME,T.CHECK_CODE,T.DRUG_DEPT_CODE
                                FROM    PHA_COM_CHECKSTATIC T,COM_DEPARTMENT S
                                WHERE   T.DRUG_DEPT_CODE = S.DEPT_CODE
                                AND     T.CHECK_STATE = '0' ";
            }
            else
            {
                verifySql = string.Format( verifySql, this.drugDeptCode );
            }

            if (this.dataManager.ExecQuery( verifySql ) == -1)
            {
                MessageBox.Show( "校验未结存盘点单数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            System.Collections.ArrayList alCheckList = new System.Collections.ArrayList();
            while (this.dataManager.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject tempCheck = new Neusoft.FrameWork.Models.NeuObject();
                tempCheck.ID = this.dataManager.Reader[1].ToString();             //单据号
                tempCheck.Name = this.dataManager.Reader[0].ToString();           //科室名称
                tempCheck.Memo = this.dataManager.Reader[2].ToString();           //科室编码

                alCheckList.Add( tempCheck );
            }

            if (alCheckList.Count > 0)
            {
                DialogResult rs = MessageBox.Show( "存在未结存盘点单，请结存后再进行月结。\n 是否查看详细单据信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
                if (rs == DialogResult.OK)
                {
                    this.ucVeriftDataDisplay.ShowData( alCheckList );
                    this.ucVeriftDataDisplay.DoubleClickInstanceMethod = new ucPhaApplyList.DoubleClickDelegate( ShowCheckListDetail );
                    this.ucVeriftDataDisplay.DisplayNotice = "说明：双击可查看盘点单明细数据";
                    this.ucVeriftDataDisplay.DisplaySheetName = "待结存盘点单";
                    this.ucVeriftDataDisplay.IsShowCancelButton = false;

                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "待结存盘点单";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucVeriftDataDisplay );
                }
                return false;
            }

            #endregion

            #region 校验是否存在入库未核准(出库审批后尚未核准)的数据

            verifySql = @"
                                SELECT  S.DEPT_NAME,T.OUT_LIST_CODE,T.DRUG_DEPT_CODE
                                FROM    PHA_COM_OUTPUT T,COM_DEPARTMENT S
                                WHERE   T.DRUG_STORAGE_CODE = S.DEPT_CODE
                                AND     T.DRUG_DEPT_CODE = '{0}'
                                AND     T.CLASS3_MEANING_CODE = '25' 
                                AND     T.OUT_STATE = '1'";

            if (this.isStatTogether == true)            //全院月结
            {
                verifySql = @"
                                SELECT  S.DEPT_NAME,T.OUT_LIST_CODE,T.DRUG_DEPT_CODE
                                FROM    PHA_COM_OUTPUT T,COM_DEPARTMENT S
                                WHERE   T.DRUG_STORAGE_CODE = S.DEPT_CODE
                                AND     T.CLASS3_MEANING_CODE = '25' 
                                AND     T.OUT_STATE = '1'";
            }
            else
            {
                verifySql = string.Format( verifySql, this.drugDeptCode );
            }

            if (this.dataManager.ExecQuery( verifySql ) == -1)
            {
                MessageBox.Show( "校验出库审批数据发生错误" + this.dataManager.Err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return false;
            }

            System.Collections.ArrayList alOutList = new System.Collections.ArrayList();
            while (this.dataManager.Reader.Read())
            {
                Neusoft.FrameWork.Models.NeuObject tempOutList = new Neusoft.FrameWork.Models.NeuObject();
                tempOutList.ID = this.dataManager.Reader[1].ToString();             //单据号
                tempOutList.Name = this.dataManager.Reader[0].ToString();           //科室名称
                tempOutList.Memo = this.dataManager.Reader[2].ToString();           //科室编码

                alOutList.Add( tempOutList );
            }
            if (alOutList.Count > 0)
            {
                DialogResult rs = MessageBox.Show( "存在出库审批后对方尚未进行核准的出库单，请核准后再进行月结。\n 是否查看详细待核准单据信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information );
                if (rs == DialogResult.OK)
                {
                    this.ucVeriftDataDisplay.ShowData( alOutList );
                    this.ucVeriftDataDisplay.DoubleClickInstanceMethod = new ucPhaApplyList.DoubleClickDelegate( ShowOutListDetail );
                    this.ucVeriftDataDisplay.DisplayNotice = "说明：双击可查看出库单明细数据";
                    this.ucVeriftDataDisplay.DisplaySheetName = "待审核出库单";
                    this.ucVeriftDataDisplay.IsShowCancelButton = false;

                    Neusoft.FrameWork.WinForms.Classes.Function.PopForm.Text = "出库待核准信息";
                    Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl( ucVeriftDataDisplay );
                }
                return false;
            }

            #endregion            

            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.isStatTogether == true)        //全院统一月结
            {
                this.drugDeptCode = "ALL";
            }
            else
            {
                if (this.cmbDept.Tag != null)
                {
                    this.drugDeptCode = this.cmbDept.Tag.ToString();
                }
            }
            if (!this.IsShowTime)//{4E5ED663-D468-4a00-B376-652DE847CB14}
            {
                this.neuPanel2.Visible = false;
            }
            else
            {
                this.neuPanel2.Visible = true;
            }

            this.InitData();

            this.SetMonthStoreStatRange(this.drugDeptCode);

            base.OnLoad( e );
        }

        protected override int OnSave(object sender, object neuObject)
        {
            if (this.Verify() == false)
            {
                return 0;
            }

            DateTime dtBegin = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dtpBeginStat.Text );
            DateTime dtEnd = Neusoft.FrameWork.Function.NConvert.ToDateTime( this.dtpEndStat.Text );

            string operCode = this.dataManager.Operator.ID;

            return this.ExeMonthStore( operCode, this.drugDeptCode, dtBegin, dtEnd );
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)//{988F66A8-1744-4921-8A6F-95D0E75B0024}
        {
            this.drugDeptCode = this.cmbDept.Tag.ToString();
            DateTime lastStatDate = this.GetMonthStoreLastDateTime(this.drugDeptCode);
            this.dtpBeginStat.Value = lastStatDate;
            this.dtpEndStat.Value = this.dataManager.GetDateTimeFromSysDateTime();
            this.dtpBeginStat.Enabled = false;

            this.ShowMonthStoreHead();//{5BAC0ACF-80DC-443e-A194-FF791E261714}
        }

        /// <summary>
        /// 显示月结记录//{5BAC0ACF-80DC-443e-A194-FF791E261714}
        /// </summary>
        /// <returns>成功返回1 失败返回－1</returns>
        protected int ShowMonthStoreHead()
        {
            if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
            {
                return -1;
            }

            this.neuSpread1.ActiveSheet = this.fpHeadSheet;

            DataSet dsHead = new DataSet();
            if (this.consManager.QueryMonthStoreHead(this.cmbDept.Tag.ToString(), ref dsHead) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结汇总信息失败") + this.consManager.Err);
                return -1;
            }
            if (dsHead.Tables.Count <= 0)
            {
                return -1;
            }

            this.fpHeadSheet.DataSource = dsHead;

            return 1;
        }

        //{5BAC0ACF-80DC-443e-A194-FF791E261714}
        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader || e.RowHeader)
            {
                return;
            }

            if (this.neuSpread1.ActiveSheet == this.fpDetailSheet)
            {
                return;
            }

            this.ShowMonthStoreDetail();
        }

        /// <summary>
        /// 获取月结明细信息//{5BAC0ACF-80DC-443e-A194-FF791E261714}
        /// </summary>
        /// <returns></returns>
        protected int ShowMonthStoreDetail()
        {
            DateTime dtBeginTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex, 0].Text);
            DateTime dtEndTime = Neusoft.FrameWork.Function.NConvert.ToDateTime(this.fpHeadSheet.Cells[this.fpHeadSheet.ActiveRowIndex, 1].Text);

            if (this.cmbDept.Tag == null || this.cmbDept.Tag.ToString() == "")
            {
                return -1;
            }

            DataSet dsDetail = new DataSet();
            if (this.consManager.QueryMonthStoreDetail(this.cmbDept.Tag.ToString(), dtBeginTime, dtEndTime, ref  dsDetail) == -1)
            {
                MessageBox.Show(Language.Msg("获取月结明细信息失败") + this.consManager.Err);
                return -1;
            }

            if (dsDetail.Tables.Count <= 0)
            {
                return -1;
            }

            this.fpDetailSheet.DataSource = dsDetail.Tables[0].DefaultView;

            if (dsDetail.Tables[0].Rows.Count > 0)
            {
                this.neuSpread1.ActiveSheet = this.fpDetailSheet;
            }

            return 1;

        }
    }
}
